# Cordova Calendar Plugin For Windows Phone
####by FrostAura

## Description
This plugin allows for adding of calendar events to the device native calendar.

## Supported Platforms
* Windows Phone 8

## Installation
phonegap plugin add https://github.com/faGH/fa-plugin-calendar.git

## Usage
```
var onSuccess = function(){
	// Success code
};

var onFailure = function(error){
	// Error code
};

window.faCalendar.AddEvent(
	onSuccess, 
	onFailure, 
	"Event Notes",
	"Event Title",
	"Event Location",
	2015, // Event Year
	8, // Event Month
	21, // Event Day
	1.0 // Event Duration in Hours
);
```
