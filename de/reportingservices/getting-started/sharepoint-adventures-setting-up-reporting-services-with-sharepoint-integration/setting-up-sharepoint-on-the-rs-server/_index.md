---
title: SharePoint auf dem RS-Server einrichten
type: docs
weight: 40
url: /reportingservices/setting-up-sharepoint-on-the-rs-server/
---

{{% alert color="primary" %}} 

Wir müssen also das tun, was wir für das SharePoint WFE gemacht haben. Zuerst gehen wir die Installation der Voraussetzungen durch und danach starten wir die SharePoint-Einrichtung. 

Für die Einrichtung wählen wir Serverfarm und eine vollständige Installation, um mit meiner SharePoint-Box übereinzustimmen, da wir keine eigenständige Installation für SharePoint möchten. 

{{% /alert %}} 
### **SharePoint-Konfiguration**
Im Assistenten zur SharePoint-Konfiguration wollen wir uns mit einer vorhandenen Farm verbinden. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_1.png)

**Abbildung 13**: Assistent zur SharePoint-Konfiguration 

Wir werden dann auf die **SharePoint_Config**-Datenbank verweisen, die unsere Farm verwendet. Wenn Sie nicht wissen, wo sich diese befindet, können Sie dies über die zentrale Verwaltung unter **Systemeinstellungen -> Server in dieser Farm verwalten** herausfinden. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_2.png)

**Abbildung 14**: Assistent zur SharePoint-Konfiguration 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_3.png)

**Abbildung 15**: Assistent zur SharePoint-Konfiguration 

Sobald der Assistent abgeschlossen ist, ist das alles, was wir vorerst auf der Report-Server-Box tun müssen. Wenn wir zur ReportServer-URL zurückgehen, werden wir einen weiteren Fehler sehen, aber das liegt daran, dass wir es nicht über den Zentraladministrator konfiguriert haben. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_4.png)

**Abbildung 16**: Fehler des Report-Servers