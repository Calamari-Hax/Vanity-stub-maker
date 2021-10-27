set Filename = output
Ren "%Filename%.txt" "%Filename%.exe"

:start
if exist % Filename %.exe(start % Filename %.exe & Ren "%Filename%.exe" "%Filename%.txt" & ECHO FOUND) else (goto start)
PAUSE
