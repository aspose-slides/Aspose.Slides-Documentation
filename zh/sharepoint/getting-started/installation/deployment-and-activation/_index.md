---
title: 部署和激活
type: docs
weight: 20
url: /zh/sharepoint/deployment-and-activation/
description: "部署 Aspose.Slides for SharePoint 解决方案时在农场上安装的内容，以及激活时其站点集合功能添加的内容。"
---
## **部署**

在部署期间，Aspose.Slides for SharePoint 解决方案会：

- 将其程序集安装到全局程序集缓存 (GAC)，并在 **web.config** 文件中添加 SafeControl 条目。在 SharePoint 2010 及更高版本中，这些文件为 *Aspose.Slides.SharePoint2010.dll*、*Aspose.Slides.SharePoint2013.dll* 或 *Aspose.Slides.SharePoint2016.dll*（SharePoint 2019 包也会安装 *Aspose.Slides.SharePoint2016.dll*）。在 SharePoint 2007 中，则为 *Aspose.Slides.SharePointUI.dll*，以及 *Aspose.Slides.SharePoint.Deployment.dll*。
- 将转换页面及其图像和其他支持文件复制到 SharePoint 安装文件夹。
- 安装功能并使其在站点集合上可供激活。

## **激活**

Aspose.Slides for SharePoint 以站点集合功能的形式打包，可在站点集合上激活或停用。激活后，功能会添加：

- 在 SharePoint 2010 及更高版本中：
  - 将 **Convert via Aspose.Slides** 项添加到文档库的文档菜单中；
  - 在功能区添加 **Aspose Tools** 选项卡，其中包含 **Convert Slides** 按钮，用于转换所选文档；
  - 将 **View Slides** 项添加到 PPT、PPTX、PPS 和 PPSX 文件的菜单中。
- 在 SharePoint 2007 中：
  - 将 **Convert with Aspose.Slides** 项添加到文档库的文档菜单中；
  - 将 **Convert All with Aspose.Slides** 项添加到文档库的 **Actions** 菜单中。

在 SharePoint 2007 中，激活还会对站点集合的父 Web 应用程序的虚拟目录进行更改。它会：

- 将转换设置页面添加到 sitemap 文件。
- 将必要的资源文件复制到虚拟目录中的 App_GlobalResources 文件夹。

安装程序会在您于[安装](/slides/zh/sharepoint/installing-aspose-slides-for-sharepoint/)期间选择的站点集合上激活该功能。