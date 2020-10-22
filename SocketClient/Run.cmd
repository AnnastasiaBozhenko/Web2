for %%N in (1 2 3 4 5 6 7 8 9 10) do (ping 127.0.0.1 -n 2 > nul & start "SocketClient %%N" bin\Debug\netcoreapp3.1\SocketClient.exe %%N)
pause