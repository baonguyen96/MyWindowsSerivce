@echo off
title Windows Service Installer

set "windowsServicePath=C:\Program Files\My Windows Service"
set "serviceFile=MyWindowsSerivce.exe"

if exist "%windowsServicePath%" (
	echo Old version exist. Uninstalling...
	RMDIR "%windowsServicePath%" /S /Q
) 

echo Installing My Windows Service...
mkdir "%windowsServicePath%"

if not exist "%windowsServicePath%\*" (
	echo Error: cannot create folder for service
) else (
	copy ".\%serviceFile%" "%windowsServicePath%\%serviceFile%"
	.\%serviceFile% install
)
echo Done
