---
title: Installationsvoraussetzungen
type: docs
weight: 20
url: /reportingservices/installation-prerequisites/
---

{{% alert color="primary" %}} 

Folgende Voraussetzungen müssen erfüllt sein, bevor wir mit der Installation fortfahren. 

{{% /alert %}} 
## **Reporting Services Add-In für SharePoint**
Das **Reporting Services Add-In für SharePoint** ist eine der wichtigsten Komponenten, um die Integration richtig zum Laufen zu bringen. Das Add-In muss auf einem der **Web Front Ends (WFE)** installiert werden, die sich in Ihrer SharePoint-Farm zusammen mit dem Central Admin-Server befinden. Eine der neuen Änderungen mit SQL 2008 R2 & SharePoint 2010 ist, dass das 2008 R2 Add-In jetzt eine Voraussetzung für die SharePoint-Installation ist. Das bedeutet, dass das RS Add-In beim Installieren von SharePoint abgeleitet wird. Dies wurde im untenstehenden Bild gezeigt und hervorgehoben. Dies vermeidet tatsächlich viele Probleme, die wir mit SP 2007 und RS 2008 beim Installieren des Add-Ins gesehen haben. 

![todo:image_alt_text](installation-prerequisites_1.png)


**Abbildung 1**: Reporting Services Add-In für SharePoint 
## **SharePoint-Authentifizierung**
Bevor wir uns mit den RS-Integrationskomponenten befassen, ist eine Sache wichtig, die beachtet werden muss: wie Sie Ihre **Site** in der SharePoint-Farm einrichten. Genauer gesagt, wie Sie die Authentifizierung für die Site konfigurieren; ob sie **Classic** oder **Claims** sein wird. Diese Wahl ist zu Beginn wichtig. Ich glaube nicht, dass Sie diese Option ändern können, sobald sie festgelegt ist. Wenn Sie sie ändern können, wäre es kein einfacher Prozess. 

{{% alert color="primary" %}} 

Reporting Services 2008 R2 ist NICHT Claims-bewusst 

{{% /alert %}} 

Selbst wenn Sie Ihre SharePoint-Site so konfigurieren, dass sie **Claims** verwendet, ist Reporting Services selbst nicht Claims-bewusst. Es beeinflusst, wie die Authentifizierung mit Reporting Services funktioniert. Also, was ist der Unterschied aus der Perspektive von Reporting Services? Es hängt davon ab, ob Sie Benutzerdaten an die Datenquelle weitergeben möchten. 

***Classic***   - Kann Kerberos verwenden und die Anmeldeinformationen des Benutzers an Ihre Backend-Datenquelle weitergeben (muss dafür Kerberos verwenden). 

***Claims*** ** - Ein Claims-Token wird verwendet und kein Windows-Token. RS wird in diesem Szenario immer die vertrauliche Authentifizierung verwenden und hat nur Zugriff auf das SPUser-Token. Sie müssen Ihre Anmeldeinformationen innerhalb Ihrer Datenquelle speichern. 

Im Moment möchten wir uns nur auf die Einrichtung von RS konzentrieren. An diesem Punkt ist SharePoint auf der SharePoint-Box installiert und mit einer **Classic Auth Site** auf **Port 80** eingerichtet. Außerdem habe ich auf dem RS-Server **gerade Reporting Services installiert** und das war's. 