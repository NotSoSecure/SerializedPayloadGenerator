powershell Invoke-WebRequest -OutFile ./Resource/php.zip -Uri https://windows.php.net/downloads/releases/php-8.4.12-Win32-vs17-x64.zip
powershell Expand-Archive -Path ./Resource/php.zip -DestinationPath ./Resource/php
powershell Remove-Item ./Resource/php.zip

powershell Invoke-WebRequest -OutFile ./Resource/ysoserialnet.zip -Uri https://github.com/pwntester/ysoserial.net/releases/download/v1.36/ysoserial-1dba9c4416ba6e79b6b262b758fa75e2ee9008e9.zip
powershell Expand-Archive -Path ./Resource/ysoserialnet.zip -DestinationPath ./Resource/ysoserialnet
powershell Remove-Item ./Resource/ysoserialnet.zip
powershell Move-Item -Path ./Resource/ysoserialnet/Release/* -Destination ./Resource/ysoserialnet

powershell Invoke-WebRequest -OutFile ./Resource/phpggc.zip -Uri https://github.com/ambionics/phpggc/archive/refs/heads/master.zip
powershell Expand-Archive -Path ./Resource/phpggc.zip -DestinationPath ./Resource/phpggc
powershell Remove-Item ./Resource/phpggc.zip

powershell Invoke-WebRequest -OutFile ./Resource/ysoserial.jar -Uri https://github.com/frohoff/ysoserial/releases/latest/download/ysoserial-all.jar

powershell Invoke-WebRequest -OutFile ./Resource/python.zip -Uri https://www.python.org/ftp/python/3.9.12/python-3.9.12-embed-amd64.zip
powershell Expand-Archive -Path ./Resource/python.zip -DestinationPath ./Resource/python
powershell Remove-Item ./Resource/python.zip

powershell Invoke-WebRequest -OutFile ./Resource/java.zip -Uri https://github.com/AdoptOpenJDK/openjdk8-binaries/releases/download/jdk8u292-b10/OpenJDK8U-jre_x86-32_windows_hotspot_8u292b10.zip
powershell Expand-Archive -Path ./Resource/java.zip -DestinationPath ./Resource
powershell Rename-Item ./Resource/jdk8u292-b10-jre ./java
powershell Remove-Item ./Resource/java.zip