---
title: 部署和激活
type: docs
weight: 20
url: /zh/sharepoint/deployment-and-activation/
---

## **部署**
在部署过程中，Aspose.Slides for SharePoint: 

- 将 **Aspose.Slides.SharePoint.dll** 安装到全局程序集缓存，并在 **web.config** 文件中添加 SafeControl 条目。
- 将功能清单和其他必要文件安装到适当的目录中。
- 在 SharePoint 数据库中注册该功能，并使其在功能范围内可用于激活。
## **激活**
Aspose.Slides for SharePoint 被打包为站点（站点集合）级别的功能，可以在站点集合上进行激活或禁用。在激活过程中，该功能对站点集合的父 web 应用程序的虚拟目录进行了一些更改。它：

- 将转换设置页面添加到网站地图文件中。
- 将必要的资源文件复制到虚拟目录的 App_GlobalResources 文件夹中。