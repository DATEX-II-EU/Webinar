set schemapath=C:\Source\Webinar3\ServerExamples\LevelCService\Schema
set out="C:\Source\Webinar3\ServerExamples\LevelCService\Schema"
"C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\xsd.exe" /c /out:%out% "%schemapath%\LevelC_3_Common.xsd" "%schemapath%\LevelC_3_Extension.xsd" "%schemapath%\LevelC_3_D2Payload.xsd" 
pause