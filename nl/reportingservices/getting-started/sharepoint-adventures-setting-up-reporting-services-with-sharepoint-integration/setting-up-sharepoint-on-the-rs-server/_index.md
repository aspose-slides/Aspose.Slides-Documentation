---
title: Instellen van SharePoint op de RS server
type: docs
weight: 40
url: /nl/reportingservices/setting-up-sharepoint-on-the-rs-server/
---
{{% alert color="primary" %}} 

Dus, we moeten doen wat we voor de SharePoint WFE hebben gedaan. Het eerste is om de installatie van de vereisten door te lopen en daarna de SharePoint‑installatie te starten. 

Voor de installatie kiezen we Server Farm en een volledige installatie om overeen te komen met mijn SharePoint‑box, omdat we geen standalone‑installatie voor SharePoint willen. 

{{% /alert %}} 
### **SharePoint Configuration**
In de SharePoint Configuratie‑wizard willen we verbinden met een bestaande farm. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_1.png)

**Figuur 13**: SharePoint Configuratie‑wizard 

We wijzen vervolgens naar de **SharePoint_Config**‑database die onze farm gebruikt. Als je niet weet waar deze zich bevindt, kun je het vinden via Central Admin onder **System Settings -> Manager Servers in this farm.** 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_2.png)

**Figuur 14**: SharePoint Configuratie‑wizard 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_3.png)

**Figuur 15**: SharePoint Configuratie‑wizard 

Zodra de wizard voltooid is, is dat voorlopig alles wat we op de Report Server‑box moeten doen. Als we terugkeren naar de ReportServer‑URL, zien we een andere fout, maar dat komt omdat we deze nog niet via Central Administrator hebben geconfigureerd. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_4.png)

**Figuur 16**: Rapportserver‑fout