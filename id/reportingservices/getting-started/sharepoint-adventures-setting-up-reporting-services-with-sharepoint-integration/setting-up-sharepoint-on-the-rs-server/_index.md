---
title: Menyiapkan SharePoint pada Server RS
type: docs
weight: 40
url: /id/reportingservices/setting-up-sharepoint-on-the-rs-server/
---
{{% alert color="primary" %}} 

Jadi, kita perlu melakukan apa yang telah kita lakukan untuk SharePoint WFE. Langkah pertama adalah melewati instalasi prasyarat dan setelah itu memulai pengaturan SharePoint. 

Untuk pengaturannya, kita memilih Server Farm dan instalasi lengkap untuk menyesuaikan SharePoint Box saya, karena kita tidak menginginkan instalasi standalone untuk SharePoint. 

{{% /alert %}} 
### **Konfigurasi SharePoint**
Di dalam SharePoint Configuration Wizard, kita ingin terhubung ke farm yang sudah ada. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_1.png)

**Gambar 13**: SharePoint Configuration Wizard 

Kita kemudian akan menunjuk ke basis data **SharePoint_Config** yang digunakan oleh farm kami. Jika Anda tidak tahu di mana itu, Anda dapat menemukannya melalui Central Admin di **System Settings -> Manager Servers in this farm.** 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_2.png)

**Gambar 14**: SharePoint Configuration Wizard 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_3.png)

**Gambar 15**: SharePoint Configuration Wizard 

Setelah wizard selesai, itu semua yang perlu kita lakukan pada Report Server Box untuk saat ini. Kembali ke URL ReportServer, kita akan melihat kesalahan lain, tetapi itu karena kita belum mengkonfigurasinya melalui Central Administrator. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_4.png)

**Gambar 16**: Report Server Error