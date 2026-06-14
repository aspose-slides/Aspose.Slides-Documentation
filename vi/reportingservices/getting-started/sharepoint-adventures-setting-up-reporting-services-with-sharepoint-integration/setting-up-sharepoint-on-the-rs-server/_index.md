---
title: Cài đặt SharePoint trên máy chủ RS
type: docs
weight: 40
url: /vi/reportingservices/setting-up-sharepoint-on-the-rs-server/
---
{{% alert color="primary" %}} 
Vì vậy, chúng ta cần làm như đã thực hiện cho SharePoint WFE. Điều đầu tiên là tiến hành cài đặt các điều kiện tiên quyết và sau đó khởi động cài đặt SharePoint. 

Đối với quá trình cài đặt, chúng tôi chọn Server Farm và cài đặt đầy đủ để phù hợp với SharePoint Box của mình, vì chúng tôi không muốn cài đặt độc lập cho SharePoint. 
{{% /alert %}} 
### **SharePoint Configuration**
Trong SharePoint Configuration Wizard, chúng ta muốn kết nối tới một farm hiện có. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_1.png)

**Figure 13**: SharePoint Configuration Wizard 

Sau đó chúng ta sẽ chỉ định nó tới cơ sở dữ liệu **SharePoint_Config** mà farm của chúng ta đang sử dụng. Nếu bạn không biết vị trí, có thể tìm thông qua Central Admin ở **System Settings -> Manager Servers in this farm.** 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_2.png)

**Figure 14**: SharePoint Configuration Wizard 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_3.png)

**Figure 15**: SharePoint Configuration Wizard 

Khi wizard hoàn tất, đó là tất cả những gì chúng ta cần làm trên Report Server Box hiện tại. Quay lại URL ReportServer, chúng ta sẽ thấy một lỗi khác, nhưng đó là do chúng ta chưa cấu hình nó qua Central Administrator. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_4.png)

**Figure 16**: Report Server Error