Microsoft.Phone.Tasks;
using Microsoft.Phone.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPCordovaClassLib.Cordova;
using WPCordovaClassLib.Cordova.Commands;
using WPCordovaClassLib.Cordova.JSON;
 
namespace Cordova.Extension.Commands {
    public class AddCalendarEvents: BaseCommand {
        public void addCalendarEvents(String str) {
            string[] calendarValues = str.Split('|');
 
            SaveAppointmentTask saveAppointmentTask = new SaveAppointmentTask();
 
            int appointmentYear = Int32.Parse(calendarValues[3]);
            int appointmentMonth = Int32.Parse(calendarValues[4]);
            int appointmentDate = Int32.Parse(calendarValues[5]);
            float appointmentTime = float.Parse(calendarValues[6]);
 
            DateTime scheduleApptDateStart = (new DateTime(appointmentYear, appointmentMonth, appointmentDate, 7, 0, 0)).AddHours(appointmentTime);
            DateTime scheduleApptDateEnd = (new DateTime(appointmentYear, appointmentMonth, appointmentDate, 7, 30, 0)).AddHours(appointmentTime);
            saveAppointmentTask.StartTime = scheduleApptDateStart;
            saveAppointmentTask.EndTime = scheduleApptDateEnd;
            saveAppointmentTask.Subject = calendarValues[1];
            saveAppointmentTask.Location = calendarValues[2];
            saveAppointmentTask.Details = "";
            saveAppointmentTask.IsAllDayEvent = false;
            saveAppointmentTask.Reminder = Reminder.FifteenMinutes;
            saveAppointmentTask.AppointmentStatus = Microsoft.Phone.UserData.AppointmentStatus.Busy;
            saveAppointmentTask.Show();
        }
 
        public void getCalendarEventData(String str) {
            ButtonAppointments_Click();
        }
 
        private void ButtonAppointments_Click() {
            Appointments appts = new Appointments();
 
            //Identify the method that runs after the asynchronous search completes.
            appts.SearchCompleted += new EventHandler < AppointmentsSearchEventArgs > (Appointments_SearchCompleted);
 
            DateTime start = DateTime.Now;
            DateTime end = start.AddDays(7);
            int max = 20;
 
            //Start the asynchronous search.
            appts.SearchAsync(start, end, max, "Appointments Test #1");
        }
 
        void Appointments_SearchCompleted(object sender, AppointmentsSearchEventArgs e) {
            //Do something with the results.
            //MessageBox.Show(e.Results.Count().ToString());
            try {
                e.Results.ToList();
                MessageBox.Show("Success");
            } catch (System.Exception) {}
 
        }
    }
}