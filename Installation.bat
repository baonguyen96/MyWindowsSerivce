@echo off
title Windows Service Installer

set "windowsServicePath=C:\Program Files\My Windows Service"
set "serviceFile=MyWindowsSerivce.exe"
set "currentDir=%cd%"

if exist "%windowsServicePath%" (
	echo Old version exists. Uninstalling...
	cd "%windowsServicePath%"
	.\"%serviceFile%" stop uninstall
	cd "%currentDir%"
	rmdir "%windowsServicePath%" /S /Q
) 

echo Installing My Windows Service...
mkdir "%windowsServicePath%"

if not exist "%windowsServicePath%\*" (
	echo Error: cannot create folder for service
) else (
	copy .\"%serviceFile%" "%windowsServicePath%\%serviceFile%"
	cd "%windowsServicePath%"
	.\"%serviceFile%" install start
)
echo Done
