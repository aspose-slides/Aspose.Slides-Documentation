---  
title: Einrichtung von Reporting Services  
type: docs  
weight: 30  
url: /reportingservices/setting-up-reporting-services/  
---  

{{% alert color="primary" %}}  

Unser erster Halt auf dem RS-Server ist der Reporting Services Configuration Manager.  

{{% /alert %}}  
## **Dienstkonto**  
Stellen Sie sicher, dass Sie verstehen, welches Dienstkonto Sie für Reporting Services verwenden. Wenn wir auf Probleme stoßen, könnte das an dem Dienstkonto liegen, das Sie verwenden. Das Standardkonto ist Network Service. Wann immer ich neue Builds bereitstelle, verwende ich immer Domänenkonten, da ich dort wahrscheinlich Probleme haben werde. Für diese Konfiguration auf meinem Server habe ich ein Domänenkonto namens **RSService** verwendet.  
## **Webdienst-URL**  
Wir müssen die Webdienst-URL konfigurieren. Dies ist das virtuelle Verzeichnis (vdir) **ReportServer**, das die von Reporting Services verwendeten Webdienste hostet und mit dem SharePoint kommunizieren wird. Es sei denn, Sie möchten die Eigenschaften des vdir (d.h. SSL, Ports, Host-Header usw.) anpassen, sollten Sie hier einfach auf Anwenden klicken können und bereit sein.  

![todo:image_alt_text](setting-up-reporting-services_1.png)  

![todo:image_alt_text](setting-up-reporting-services_2.png)  

**Abbildung 3**: Einrichtung der Webdienst-URL  

Wenn das erledigt ist, sollten Sie die folgende Abbildung sehen.  

![todo:image_alt_text](setting-up-reporting-services_3.png)  

**Abbildung 4**: Erfolgreiche Einrichtung der Webdienst-URL  
## **Datenbank**  
Wir müssen die Katalogdatenbank für Reporting Services erstellen. Diese kann auf jedem SQL Server 2008 oder SQL Server 2008 R2-Datenbank-Engine platziert werden. SQL11 würde ebenfalls funktionieren, ist aber noch in der BETA-Phase. Diese Aktion wird standardmäßig zwei Datenbanken erstellen, **ReportServer** und **ReportServerTempDB**.  
Der andere wichtige Schritt dabei ist sicherzustellen, dass Sie SharePoint Integrated für den Datenbanktyp auswählen. Sobald diese Wahl getroffen wurde, kann sie nicht mehr geändert werden. Bitte beachten Sie die Abbildungen 5, 6 und 7 zur Orientierung.  

![todo:image_alt_text](setting-up-reporting-services_4.png)  

**Abbildung 5**: Erstellung der Report Server-Datenbank  

![todo:image_alt_text](setting-up-reporting-services_5.png)  

**Abbildung 6**: Einrichtung des Datenbankservers und des Authentifizierungstyps  

![todo:image_alt_text](setting-up-reporting-services_6.png)  

**Abbildung 7**: Einrichtung des Datenbanknamens und des Modus  

Für die Anmeldeinformationen ist dies, wie der Report Server mit dem SQL Server kommunizieren wird. Egal welches Konto Sie auswählen, es erhält bestimmte Berechtigungen innerhalb der Katalogdatenbank sowie einige der Systemdatenbanken über die RSExecRole. MSDB ist eine dieser Datenbanken für die Verwendung von Abonnements, da wir SQL-Agent verwenden.  

![todo:image_alt_text](setting-up-reporting-services_7.png)  

**Abbildung 8**: Einrichtung der Anmeldeinformationen der Report Server-Datenbank  

Sobald das erledigt ist, sollte es wie die folgende Abbildung aussehen.  

![todo:image_alt_text](setting-up-reporting-services_8.png)  

**Abbildung 9**: Fortschritt beim Abschluss der Einrichtung der Report Server-Datenbank  
## **Report Manager-URL**  
Wir können die Report Manager-URL überspringen, da sie im SharePoint Integrated-Modus nicht verwendet wird. SharePoint ist unser Frontend. Der Report Manager funktioniert nicht.  
## **Verschlüsselungsschlüssel**  
Sichern Sie Ihre Verschlüsselungsschlüssel und stellen Sie sicher, dass Sie wissen, wo Sie sie aufbewahren. Wenn Sie in eine Situation geraten, in der Sie die Datenbank migrieren oder wiederherstellen müssen, benötigen Sie diese.  

![todo:image_alt_text](setting-up-reporting-services_9.png)  

Das war's für den Reporting Services Configuration Manager. Wenn Sie zur URL im Tab Webdienst-URL navigieren, sollte etwas Ähnliches wie die folgende Abbildung angezeigt werden.  

![todo:image_alt_text](setting-up-reporting-services_10.png)  

**Abbildung 12**: Zugriff auf den Report Server nach der Installation  

Was ist passiert? SharePoint ist auf meinem WFE installiert und ich habe die Einrichtung von Reporting Services abgeschlossen. In diesem Beispiel laufen Reporting Services und SharePoint auf verschiedenen Maschinen. Wären sie auf derselben Maschine gewesen, hätten Sie diesen Fehler nicht gesehen. Technisch gesehen müssen wir SharePoint auf der RS-Box installieren. Das bedeutet, dass auch IIS aktiviert wird.  