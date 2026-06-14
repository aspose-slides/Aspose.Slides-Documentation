---
title: 在 RS 伺服器上設定 SharePoint
type: docs
weight: 40
url: /zh-hant/reportingservices/setting-up-sharepoint-on-the-rs-server/
---
{{% alert color="primary" %}} 

所以，我們需要做與 SharePoint WFE 相同的操作。第一步是完成先決條件的安裝，然後啟動 SharePoint 安裝程序。

在安裝過程中，我們選擇 Server Farm 並執行完整安裝，以符合我的 SharePoint 環境，因為我們不想使用單機安裝的 SharePoint。

{{% /alert %}} 
### **SharePoint Configuration**
在 SharePoint Configuration Wizard 中，我們希望連接到現有的農場。

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_1.png)

**圖 13**: SharePoint Configuration Wizard 

接著，我們會指向農場所使用的 **SharePoint_Config** 資料庫。如果您不知道它的位置，可以透過 Central Admin 的 **System Settings -> Manager Servers in this farm.** 來查詢。

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_2.png)

**圖 14**: SharePoint Configuration Wizard 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_3.png)

**圖 15**: SharePoint Configuration Wizard 

當精靈完成後，這就是目前在 Report Server Box 上需要執行的全部操作。返回 ReportServer URL 時，我們會看到另一個錯誤，這是因為尚未透過 Central Administrator 進行設定。

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_4.png)

**圖 16**: Report Server 錯誤