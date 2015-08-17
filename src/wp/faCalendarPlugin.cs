using Microsoft.Phone.Tasks;
using Microsoft.Phone.UserData;
using System;
using WPCordovaClassLib.Cordova;
using WPCordovaClassLib.Cordova.Commands;
using WPCordovaClassLib.Cordova.JSON;

namespace WPCordovaClassLib.Cordova.Commands
{
    public class faCalendarPlugin : BaseCommand
    {
        public void GetDescription(string options)
        {
            PluginResult result;

            try
            {
                result = new PluginResult(PluginResult.Status.OK, "Cordova plugin by FrostAura to allow for adding events to Windows Phone native calendar.");
            }
            catch (Exception ex)
            {
                result = new PluginResult(PluginResult.Status.ERROR, ex.Message);
            }

            DispatchCommandResult(result);
        }

        public void AddEvent(string options)
        {
            PluginResult result;

            try
            {
                string[] args = JsonHelper.Deserialize<string[]>(options);
                string[] calendarValues = args[0].Split('|');

                SaveAppointmentTask saveAppointmentTask = new SaveAppointmentTask();

                int appointmentYear = int.Parse(calendarValues[3]);
                int appointmentMonth = int.Parse(calendarValues[4]);
                int appointmentDate = int.Parse(calendarValues[5]);
                float appointmentTime = float.Parse(calendarValues[6]);

                DateTime scheduleApptDateStart = (new DateTime(appointmentYear, appointmentMonth, appointmentDate, 7, 0, 0)).AddHours(appointmentTime);
                DateTime scheduleApptDateEnd = (new DateTime(appointmentYear, appointmentMonth, appointmentDate, 7, 30, 0)).AddHours(appointmentTime);

                saveAppointmentTask.StartTime = scheduleApptDateStart;
                saveAppointmentTask.EndTime = scheduleApptDateEnd;
                saveAppointmentTask.Subject = calendarValues[1];
                saveAppointmentTask.Location = calendarValues[2];
                saveAppointmentTask.Details = calendarValues[0];
                saveAppointmentTask.IsAllDayEvent = false;
                saveAppointmentTask.Reminder = Reminder.OneHour;
                saveAppointmentTask.AppointmentStatus = AppointmentStatus.Busy;

                saveAppointmentTask.Show();

                result = new PluginResult(PluginResult.Status.OK, "Calendar event added successfully.");
            }
            catch (Exception ex)
            {
                result = new PluginResult(PluginResult.Status.ERROR, ex.Message);
            }

            DispatchCommandResult(result);
        }
    }
}