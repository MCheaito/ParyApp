rem The next line is an example on how to call this script from Visual Studio
rem "$(ProjectDir)Resources\BuildRes.bat" "$(ProjectDir)Resources\" "$(TargetDir)..\Resources\"
@echo off
rem %1 parameter should contain source path
SET source=%~1
rem %2 parameter should contain destination binary path
SET destination=%~2
rem SET vspath=D:\My Documents\Visual Studio Projects\Pierre\BACKUP20070508\BACKUP\AlliesWeb\Binaries\Tools\Build Resources\
SET vspath=%~3

rem SET alpath= C:\Windows\Microsoft.NET\Framework\v2.0.50727\
SET alpath=%~4

rem FOR %%f in ("%source%*.resx") do "%vspath%ResGen.exe" "%source%%%~nf.resx" "%destination%%%~nf.resources"

rem FOR %%f in ("%destination%*.ressources") do "%alpath%al.exe" "/out:%destination%%%~nf.dll" "/embed: %destination%%%~nf.ressources" 

rem "$(TargetDir)..\Tools\Build Resources\BuildRes.bat" "$(ProjectDir)Resources\" "$(TargetDir)..\Resources\" "$(DevEnvDir)\..\..\SDK\v2.0\Bin\"


