---
title: Configurazione di SharePoint sul server RS
type: docs
weight: 40
url: /it/reportingservices/setting-up-sharepoint-on-the-rs-server/
---
{{% alert color="primary" %}} 

Quindi, dobbiamo fare quello che abbiamo fatto per il WFE di SharePoint. La prima cosa è passare attraverso l'installazione dei prerequisiti e, successivamente, avviare l'installazione di SharePoint. 

Per l'installazione, scegliamo Server Farm e un'installazione completa per far corrispondere il mio SharePoint Box, poiché non vogliamo un'installazione standalone per SharePoint. 

{{% /alert %}} 
### **Configurazione di SharePoint**
Nella SharePoint Configuration Wizard, vogliamo connetterci a un farm esistente. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_1.png)

**Figura 13**: SharePoint Configuration Wizard 

Indicheremo quindi il database **SharePoint_Config** che il nostro farm utilizza. Se non sai dove si trovi, puoi scoprirlo tramite Central Admin nella sezione **System Settings -> Manager Servers in this farm.** 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_2.png)

**Figura 14**: SharePoint Configuration Wizard 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_3.png)

**Figura 15**: SharePoint Configuration Wizard 

Una volta completato il wizard, è tutto ciò che dobbiamo fare sul Report Server Box per ora. Tornando all'URL di ReportServer, vedremo un altro errore, ma è dovuto al fatto che non l'abbiamo configurato tramite Central Administrator. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_4.png)

**Figura 16**: Report Server Error