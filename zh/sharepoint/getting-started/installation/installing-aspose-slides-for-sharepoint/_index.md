---
title: 安装 Aspose.Slides for SharePoint
type: docs
weight: 10
url: /sharepoint/installing-aspose-slides-for-sharepoint/
---

{{% alert color="primary" %}} 

Aspose.Slides for SharePoint 作为 Aspose.Slides.SharePoint.zip 归档文件下载。该归档包含： 

- **Aspose.Slides.SharePoint.wsp**：SharePoint 解决方案文件。Aspose.Slides for SharePoint 被打包为 SharePoint 解决方案，以便在整个服务器农场中方便地激活和停用。
- **Aspose_LicenseAgreement.rtf**：最终用户许可协议。
- **Setup.exe**：安装程序。
- **Setup.exe.config**：安装配置文件。

{{% /alert %}} 
## **安装过程**
在运行安装之前，安装程序会检查以下内容：

- 是否安装了 WSS 3.0 或 MOSS 2007。
- 用户是否有权限安装 SharePoint 解决方案。
- SharePoint 数据库是否在线。
- WSS 管理服务是否已启动。
- WSS 定时器服务是否已启动。

WSS 管理和定时器服务是必需的，因为某些安装操作依赖于定时作业来传播到服务器农场中的所有服务器。 
### **运行安装**
要安装 Aspose.Slides for SharePoint： 

1. 将 Aspose.Slides.SharePoint zip 解压到 MOSS 7.0 或 WSS 3.0 服务器的本地驱动器。
2. 运行 setup.exe 并按照屏幕上的说明进行操作。
   安装程序执行以下操作： 
   1. 检查安装先决条件。如果任何检查失败，安装将不会继续。 

      **正在运行系统检查** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_1.png)




3. 显示最终用户许可协议。您必须接受该协议才能继续。 

   **EULA** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_2.png)




4. 显示部署目标选择。选择要激活该功能的 Web 应用程序和站点集合。 

   **选择部署目标** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_3.png)




5. 将功能部署到服务器农场。 

   **安装进度条** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_4.png)




6. 为所选站点集合激活 Aspose.Slides，并配置其父 Web 应用程序。
7. 显示已部署和激活该功能的 Web 应用程序和站点集合的列表。 

   **安装成功** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_5.png)