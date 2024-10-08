---
title: Reporting Services SharePoint-Konfiguration
type: docs
weight: 50
url: /de/reportingservices/reporting-services-sharepoint-configuration/
---

{{% alert color="primary" %}} 

Jetzt, wo SharePoint auf dem RS-Server installiert und konfiguriert ist und RS über den Reporting Services-Konfigurationsmanager eingerichtet wurde, können wir mit der Konfiguration in der zentralen Verwaltung fortfahren. RS 2008 R2 hat diesen Prozess wirklich vereinfacht. Früher mussten wir einen dreistufigen Prozess durchlaufen, um dies zum Laufen zu bringen. Jetzt haben wir nur noch einen Schritt. 

Wir möchten zur zentralen Administrator-Webseite gehen und dann zu den allgemeinen Anwendungseinstellungen. Weiter unten werden wir die Reporting Services sehen. 

{{% /alert %}} 

![todo:image_alt_text](reporting-services-sharepoint-configuration_1.png)


**Abbildung 17**: SharePoint-Konfiguration 

{{% alert color="primary" %}} 

Klicken Sie auf "**Reporting Services-Integration**". 

{{% /alert %}} 
## **Webdienst-URL**
Wir geben die URL für den Berichtserver an, die wir im Reporting Services-Konfigurationsmanager gefunden haben. 
## **Authentifizierungsmodus**
Wir wählen auch einen Authentifizierungsmodus aus. Der folgende MSDN-Link erklärt im Detail, was diese sind. 
[Übersicht über die Sicherheit von Reporting Services im SharePoint-Integrationsmodus](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb283324(v=sql.105)) 

Kurz gesagt, wenn Ihre Website die **Anspruchsauthentifizierung** verwendet, verwenden Sie immer die vertrauenswürdige Authentifizierung, unabhängig davon, was Sie hier auswählen. Wenn Sie Windows-Anmeldeinformationen übergeben möchten, sollten Sie die Windows-Authentifizierung wählen. Für die vertrauenswürdige Authentifizierung übergeben wir das SPUser-Token und verlassen uns nicht auf die Windows-Anmeldeinformationen. 

Sie sollten auch die vertrauenswürdige Authentifizierung verwenden, wenn Sie Ihre Classic Mode-Sites für NTLM konfiguriert haben und RS für NTLM eingerichtet ist. Kerberos wäre erforderlich, um die Windows-Authentifizierung zu verwenden und diese für Ihre Datenquelle zu übergeben. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_2.png)


**Abbildung 18**: Einstellungen der Anmeldeinformationen für die Reporting Services-Integration
## **Funktion aktivieren**
Dies gibt Ihnen die Möglichkeit, die Reporting Services für alle Websitesammlungen zu aktivieren, oder Sie können auswählen, für welche Sie sie aktivieren möchten. Das bedeutet einfach, welche Websites die Reporting Services nutzen können. 
Wenn es abgeschlossen ist, sollten Sie die folgende Abbildung sehen. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_3.png)


**Abbildung 19**: Erfolgreiche Integration der Reporting Services in die SharePoint-Umgebung 

Zurück zur Berichtserver-URL, wie in Abbildung 14 angegeben, sollten wir etwas Ähnliches wie in der folgenden Abbildung sehen. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_4.png)


**Abbildung 20**: Erfolgreiche Überprüfung der Reporting Services in der SharePoint-Umgebung 

{{% alert color="primary" %}} 

Wenn Ihre SharePoint-Website für SSL konfiguriert ist, wird sie nicht in dieser Liste angezeigt. Es ist ein bekanntes Problem und bedeutet nicht, dass es ein Problem gibt. Ihre Berichte sollten dennoch funktionieren. 

{{% /alert %}} 

Jetzt sind wir bereit, die Reporting Services in SharePoint 2010 zu verwenden. Wie in der vorherigen Version haben wir eine Funktion (aktiviert, wenn wir die Reporting Services-Integration konfigurieren) in der „Webseiten-Sammlung-Funktion“. Außerdem hat die Installation 3 Inhaltstypen hinzugefügt, die wir zu unserer Website hinzufügen können. In Abbildung 21 sehen wir 2 dieser Inhaltstypen, die in einer Dokumentbibliothek hinzugefügt wurden, um einen benutzerdefinierten Bericht zu erstellen, wie wir ihn in Abbildung 21 sehen können. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_5.png)


**Abbildung 21**: Berichtsgenerator 

Der "**Berichtsgenerator**" ist ein ActiveX, das wir auf dem Server herunterladen müssen, wie wir in Abbildung 22 sehen können. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_6.png)


**Abbildung 22**: Berichtsgenerator herunterladen und installieren 

Wenn der Download abgeschlossen ist, führen Sie den **„Berichtsgenerator“** aus. Jetzt sind wir bereit, unseren ersten Bericht zu entwerfen, wie wir in Abbildung 23 sehen können. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_7.png)

**Abbildung 23**: Berichterstellung neues Berichtsgenerierungsassistent 

Nachdem wir unseren Bericht erstellt haben, können wir ihn in der Dokumentbibliothek speichern, die erstellt wurde, um die Berichte in unserem SharePoint 2010 zu speichern. 


Der andere Inhaltstyp muss verwendet werden, um eine gemeinsame Verbindung als Datenquelle zu erstellen und sie in einer Dokumentbibliothek in SharePoint zu speichern. Wir können eine Dokumentbibliothek erstellen, diesen Inhaltstyp hinzufügen und danach können wir unsere Verbindungen verfügbar haben, um die Datenquelle der Berichte zu ändern. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_8.png)


**Abbildung 24**: Erfolgreicher Export des Berichts an den Berichtserver 