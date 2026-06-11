---
title: Konfigurowanie SharePoint na serwerze RS
type: docs
weight: 40
url: /pl/reportingservices/setting-up-sharepoint-on-the-rs-server/
---
{{% alert color="primary" %}} 

Zatem musimy zrobić to, co zrobiliśmy dla SharePoint WFE. Najpierw przejdźmy przez instalację wymagań wstępnych, a następnie uruchommy instalację SharePoint.

Podczas instalacji wybieramy tryb Server Farm i pełną instalację, aby dopasować się do mojego środowiska SharePoint, ponieważ nie chcemy instalacji standalone dla SharePoint. 

{{% /alert %}} 
### **Konfiguracja SharePoint**
W kreatorze konfiguracji SharePoint chcemy połączyć się z istniejącą farmą. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_1.png)

**Rysunek 13**: Kreator konfiguracji SharePoint 

Następnie wskażemy bazę danych **SharePoint_Config**, której używa nasza farma. Jeśli nie wiesz, gdzie się ona znajduje, możesz to sprawdzić w Centralnym Administracji, w sekcji **System Settings -> Manager Servers in this farm.** 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_2.png)

**Rysunek 14**: Kreator konfiguracji SharePoint 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_3.png)

**Rysunek 15**: Kreator konfiguracji SharePoint 

Gdy kreator zakończy działanie, to wszystko, co musimy zrobić na serwerze raportów w tej chwili. Wracając do adresu URL ReportServer, zobaczymy kolejny błąd, ale wynika to z faktu, że nie skonfigurowaliśmy go w Centralnym Administratorze. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_4.png)

**Rysunek 16**: Błąd serwera raportów