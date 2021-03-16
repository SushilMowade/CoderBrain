// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
	GetSpaceXData(false);
	$("#btnFilterData").click(function () {
		GetSpaceXData(true);
	});
});



function GetSpaceXData(isFilterRequest) {

	var loadHtml = "<img src='https://cdn.dribbble.com/users/159302/screenshots/1900376/material-spinner2.gif' alt='Loading please wait..'></img>";

	var pageSize = $("#selPageSize").val();
	var launchSuccess = $("#selLaunchSuccess").val();
	var landSuccess = $("#selLandSuccess").val();
	var launchYear = $("#selLaunchYear").val();
	$("#divResult").html(loadHtml);
	$.ajax({
		url: 'http://localhost:65196/Home/GetSpaceXData?pageSize=' + pageSize + '&launchSuccess=' + launchSuccess + '&landSuccess=' + landSuccess + '&launchYear=' + launchYear + '&isFilterRequest=' + isFilterRequest,
		data: null,
		type: 'GET',
		dataType: 'json',
		error: function () {
			$('#divResult').html('<p>An error has occurred</p>');
		},
		success: function (data) {
			$("#divResult").html(GenerateHtml(data));
		}

	});

}


function GenerateHtml(data) {
	var html = "";

	if (data !== null && data !== undefined && data.length > 0) {
		$.each(data, function (i, d) {
			html = html + "<div class='col-lg-3 mt-2' style='border-right:1px dashed black'>";
			html = html + "<h3>" + d.mission_name + "</h3>";
			if (d.details !== null) {
				html = html + "<p>" + d.details + "</p>";
			}
			html = html + "<p><small>Launch Date: " + d.launch_date_utc + "</small></p>";
			if (d.launch_site !== null) {
				html = html + "<p><small>Launch Site: " + d.launch_site.site_name_long + "</small></p>";
			}
			if (d.rocket !== null) {
				html = html + "<p><small>Rocket: " + d.rocket.rocket_name + "</small></p>";
			}
			if (d.launch_failure_details !== null) {
				html = html + "<p><small>Launch Failure Details: " + d.launch_failure_details.reason + "</small></p>";
			}
			html = html + "</div>";
		});
	} else {
		html = html = "<h2 class='text-center'>No data found</h2>";
	}

	return html;
}

