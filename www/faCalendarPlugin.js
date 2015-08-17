var faCalendar = {
    GetDescription: function (successCallback, errorCallback) {
        cordova.exec(successCallback, errorCallback, "faCalendar", "GetDescription", []);
    },
	AddEvent: function(successCallback, errorCallback, notes, location, title, year, month, day, duration){
		var strInput = notes + '|' + title + '|' + location + '|' + year + '|' + month + '|' + day + '|' + duration' + '|' + ' ';
		
		cordova.exec(successCallback, errorCallback, "faCalendar", "AddEvent", [strInput]);
	}
}

module.exports = faCalendar;