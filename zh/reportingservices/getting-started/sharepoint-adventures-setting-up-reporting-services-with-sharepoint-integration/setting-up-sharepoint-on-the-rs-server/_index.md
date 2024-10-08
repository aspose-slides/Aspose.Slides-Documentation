---  
title: 在 RS 服务器上设置 SharePoint  
type: docs  
weight: 40  
url: /reportingservices/setting-up-sharepoint-on-the-rs-server/  
---  

{{% alert color="primary" %}}  

所以，我们需要做我们为 SharePoint WFE 所做的工作。第一步是进行前提条件安装，之后启动 SharePoint 设置。  

在设置中，我们选择服务器农场和完全安装，以匹配我的 SharePoint 盒子，因为我们不想要 SharePoint 的独立安装。  

{{% /alert %}}  
### **SharePoint 配置**  
在 SharePoint 配置向导中，我们想要连接到一个现有的农场。  

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_1.png)  

**图 13**：SharePoint 配置向导  

接下来，我们将其指向我们的农场正在使用的 **SharePoint_Config** 数据库。如果您不知道在哪里，可以通过中央管理找到，路径是 **系统设置 -> 管理此农场中的服务器。**  

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_2.png)  

**图 14**：SharePoint 配置向导  

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_3.png)  

**图 15**：SharePoint 配置向导  

一旦向导完成，目前为止我们在报告服务器盒子上需要做的就是这些。返回到 ReportServer URL，我们会看到另一个错误，但那是因为我们尚未通过中央管理员进行配置。  

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_4.png)  

**图 16**：报告服务器错误  