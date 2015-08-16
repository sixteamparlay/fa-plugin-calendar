var calendarExport.addEvent = function(notes, title, location, year, month, day, duration){
	var inputCalendarString = notes + '|' + title + '|' + location + '|' + year + '|' + month + '|' + day + '|' + duration' + '|' + ' ';
	
	cordova.exec(null, null, "AddCalendarEvents", "addCalendarEvents", inputCalendarString);
};

module.exports = calendarExport;