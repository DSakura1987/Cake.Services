#addin "Cake.Powershell"
#addin "Cake.Services"

#r System.ServiceProcess

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");





///////////////////////////////////////////////////////////////////////////////
// TASK DEFINITIONS
///////////////////////////////////////////////////////////////////////////////

Task("Windows-Service")
    .Description("Stop / Start windows service")
    .Does(() =>
	{
		bool status = IsServiceRunning("MpsSvc", "");

		if (status)
		{
			StopService("MpsSvc", "", 60000);
		}
		else
		{
			StartService("MpsSvc", "", 60000, null);
		}
	});



//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Windows-Service");





///////////////////////////////////////////////////////////////////////////////
// EXECUTION
///////////////////////////////////////////////////////////////////////////////

RunTarget(target);