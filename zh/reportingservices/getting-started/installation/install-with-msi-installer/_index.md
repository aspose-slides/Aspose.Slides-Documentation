---
title: 使用MSI安装程序安装
type: docs
weight: 20
url: /reportingservices/install-with-msi-installer/
---

## **安装**
您可以通过MSI安装程序安装Aspose.Slides for Reporting Services。

{{% alert title="注意" color="warning" %}} 

**Aspose.Slides for Reporting Services**需要在主机上安装**.NET Framework 3.5**。

{{% /alert %}}

运行***Aspose.Slides.ReportingServices.msi***并按照安装程序提供的步骤进行操作。

安装程序将把程序集和其他文件复制到指定目录，并在默认的Reporting Services实例上安装该产品。除非您想添加特殊的配置参数，否则无需手动复制或修改任何文件。

在大多数情况下，通过MSI安装程序进行安装是最佳选择。但是，在某些情况下，您可能希望手动安装该产品：

- 由于安全问题或其他原因，自动安装失败。
- 产品必须安装在命名的（而非默认）Reporting Services实例上或多个实例上。
- 在升级到最新版本后，您只想替换程序集，而不想卸载旧版本并使用MSI安装程序安装新版本。**注意**，在这种情况下您可能会有其他文件。