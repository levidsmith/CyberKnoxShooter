SET PROJ_SERVER=conway-shooter
SET PROJ_EXE=ConwayShooter
SET BUTLER_EXE=D:\ldsmith\itch\butler\butler.exe

call %BUTLER_EXE% push build\%PROJ_EXE%Windows ldsmith/%PROJ_SERVER%:win

REM call %BUTLER_EXE% push build\%PROJ_EXE%Mac ldsmith/%PROJ_SERVER%:osx

REM call %BUTLER_EXE% push build\%PROJ_EXE%Linux ldsmith/%PROJ_SERVER%:linux

@echo 

REM pause > nul
