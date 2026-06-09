---
title: SharePoint'i RS Sunucusunda Kurma
type: docs
weight: 40
url: /tr/reportingservices/setting-up-sharepoint-on-the-rs-server/
---
{{% alert color="primary" %}} 

SharePoint WFE için yaptığımızı yapmamız gerekiyor. İlk adım olarak önkoşulları kurup ardından SharePoint kurulumunu başlatmalıyız. 

Kurulum için Server Farm seçiyor ve SharePoint kutumla eşleşecek şekilde tam bir kurulum yapıyoruz; çünkü SharePoint için tek başına bir kurulum istemiyoruz. 

{{% /alert %}} 
### **SharePoint Configuration**
SharePoint Configuration Wizard içinde mevcut bir farm’a bağlanmak istiyoruz. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_1.png)

**Şekil 13**: SharePoint Configuration Wizard 

Ardından farmımızın kullandığı **SharePoint_Config** veritabanına yönlendireceğiz. Bunun nerede olduğunu bilmiyorsanız, **System Settings -> Manager Servers in this farm** yolunu Central Admin üzerinden bulabilirsiniz. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_2.png)

**Şekil 14**: SharePoint Configuration Wizard 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_3.png)

**Şekil 15**: SharePoint Configuration Wizard 

Sihirbaz tamamlandığında, şu an için Report Server Box üzerinde yapmamız gereken tek şey bu kadar. ReportServer URL’sine geri döndüğümüzde başka bir hatayla karşılaşacağız; bu, Central Administrator üzerinden yapılandırmadığımız için ortaya çıkar. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_4.png)

**Şekil 16**: Report Server Error