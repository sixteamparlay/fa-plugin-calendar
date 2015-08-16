var exec = require('cordova/exec');
var calendarExport = {};

calendarExport.addEvent = function(notes, title, location, year, month, day, duration){
	duration = duration || "1.0"
	var inputCalendarString = notes + '|' + title + '|' + location + '|' + year + '|' + month + '|' + day + '|' + duration' + '|' + ' ';
	
	exec(null, null, "AddCalendarEvents", "addCalendarEvents", inputCalendarString);
};

module.exports = calendarExport;