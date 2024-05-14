set schemapath=C:\Source\Webinar3\ServerExamples\LevelBProfiledService\Schema
set out="C:\Source\Webinar3\ServerExamples\LevelBProfiledService\Schema"
"C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\xsd.exe" /c /out:%out% "%schemapath%\DATEXII_3_Common.xsd" "%schemapath%\DATEXII_3_Extension.xsd" "%schemapath%\DATEXII_3_D2Payload.xsd" 
pause