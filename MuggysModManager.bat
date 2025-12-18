@echo off
:menu
cls
echo =============================================================
echo Run (V)anilla Cuphead or modded with (B)epInEx or (M)elonLoader?
echo (V, B, M) Press ESC to end.
echo =============================================================

:: The choice command handles V, B, M, and the ESC key (represented by the bracket)
choice /c vbm /n

if errorlevel 4 goto end
if errorlevel 3 goto Melon
if errorlevel 2 goto BepInEx
if errorlevel 1 goto Vanilla
goto menu

:Vanilla
echo Setting up Vanilla...
rename "MelonLoader" "MelonLoader_bak" 2>nul
rename "Mods" "Mods_bak" 2>nul
rename "Plugins" "Plugins_bak" 2>nul
rename "UserData" "UserData_bak" 2>nul
rename "version.dll" "version.dll.bak" 2>nul
rename "BepInEx" "BepInEx_bak" 2>nul
rename "winhttp.dll" "winhttp.dll.bak" 2>nul
goto launch

:BepInEx
echo Setting up BepInEx...
rename "MelonLoader" "MelonLoader_bak" 2>nul
rename "Mods_bak" "Mods" 2>nul
rename "Plugins" "Plugins_bak" 2>nul
rename "UserData" "UserData_bak" 2>nul
rename "version.dll" "version.dll.bak" 2>nul
rename "BepInEx_bak" "BepInEx" 2>nul
rename "winhttp.dll.bak" "winhttp.dll" 2>nul
goto launch

:Melon
echo Setting up MelonLoader...
rename "MelonLoader_bak" "MelonLoader" 2>nul
rename "Mods_bak" "Mods" 2>nul
rename "Plugins_bak" "Plugins" 2>nul
rename "UserData_bak" "UserData" 2>nul
rename "version.dll.bak" "version.dll" 2>nul
rename "BepInEx" "BepInEx_bak" 2>nul
rename "winhttp.dll" "winhttp.dll.bak" 2>nul
goto launch

:launch
echo Launching Cuphead...
start "" "Cuphead.exe"
:: if you want to use the autohotkey script
start "" "cuphead.ahk" 
exit

:end
exit