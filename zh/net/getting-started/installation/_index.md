---
title: 安装
type: docs
weight: 70
url: /zh/net/installation/
keywords:
- 安装 Aspose.Slides
- 下载 Aspose.Slides
- 使用 Aspose.Slides
- Aspose.Slides 安装
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何快速安装 Aspose.Slides for .NET。逐步指南、系统要求和代码示例 — 今日即可开始使用 PowerPoint 演示文稿！"
---
## **概述**

本文说明如何在 Windows、Linux 和 macOS 上安装 Aspose.Slides for .NET。它侧重于基于 NuGet 的安装，并展示如何在 Windows 上通过 NuGet 包管理器或包管理器控制台、在 Linux 上的 .NET 项目，以及在 macOS 上的 Visual Studio 项目中添加库。它还描述了如何在需要时更新包并安装预发行版本。

在安装之前，请在[系统要求](/slides/zh/net/system-requirements/)中查看受支持的操作系统、.NET 实现和其他依赖项。

## **Windows**
NuGet 提供了在 PC 上下载和安装 Aspose .NET API 的最简便途径。 

### **方法 1：从 NuGet 包管理器安装或更新 Aspose.Slides**

1. 打开 Microsoft Visual Studio。 
2. 创建一个简单的控制台应用程序或打开现有项目。 
3. 依次选择 **Tools** > **NuGet package manager**。 
4. 在 **Browse** 下的文本框中搜索 *Aspose Slides*。 
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. 点击 **Aspose.Slides.NET**，然后点击 **Install**。 
   * 如果您想更新 Aspose.Slides（假设您已安装），请改为点击 **Update**。 

选定的 API 将被下载并在项目中引用。

### **方法 2：通过包管理器控制台安装或更新 Aspose.Slides**

以下是在包管理器控制台中引用 [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) 的方式：

1. 打开 Microsoft Visual Studio。 
2. 创建一个简单的控制台应用程序或打开现有项目。 
3. 依次选择 **Tools** > **Library Package Manager** > **Package Manager Console**。 
![todo:image_alt_text](installation_2.png)
4. 运行以下命令：`Install-Package Aspose.Slides.NET` 
![todo:image_alt_text](installation_3.png)
最新的完整版本将安装到您的应用程序中。 

* 或者，您可以在命令后添加 `-prerelease` 后缀，以指定同时安装包含热修复的最新发布版本。

窗口底部会出现 **Installing Aspose.Slides.NET** 提示。 
![todo:image_alt_text](installation_4.png)

下载完成后，您应该会看到一些确认信息。 

如果您不熟悉 [Aspose EULA](https://about.aspose.com/legal/eula)，可以阅读 URL 中引用的许可证。 
![todo:image_alt_text](installation_5.png)

在您的应用程序中，您应能看到 Aspose.Slides 已成功添加并被引用。 
![todo:image_alt_text](installation_6.png)

在包管理器控制台中，您可以运行 `Update-Package Aspose.Slides.NET` 命令来检查 Aspose.Slides 包的更新。若有更新，将自动安装。您也可以使用 `-prerelease` 后缀来更新最新的发布版本。

#### **在共享服务器环境中运行的注意事项**
我们强烈建议您在 **Full Trust** 权限集下运行所有 Aspose .NET 组件，因为 Aspose 组件有时需要访问注册表设置和位于虚拟目录之外的文件，例如读取字体时。 

此外，Aspose.NET 组件基于核心 .NET 系统类——其中一些类在特定情况下也需要 Full Trust 权限才能执行操作。 

互联网服务提供商（托管多个公司应用的）通常强制使用 Medium Trust 安全级别。在 .NET 2.0 环境下，这种安全级别可能导致限制，影响 Aspose.Slides 的操作：

- **RegistryPermission** 不可用。这意味着您无法访问注册表，而在渲染文档时需要枚举已安装的字体。 
- **FileIOPermission** 受限。这意味着您只能访问应用程序虚拟目录层次结构中的文件，这也可能导致导出操作期间无法读取字体。 

基于上述原因，我们强烈建议您在 **Full Trust** 权限下运行 Aspose.Slides。如果使用 **Medium trust**，可能会出现不一致的情况——某些库功能（例如渲染）在执行特定任务时可能无法工作。 

## **Linux**

NuGet 提供了在 Linux 上下载和安装 Aspose.Slides for .NET 的最简便途径。将 [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) 包添加到您的 .NET 项目中。

## **macOS**

NuGet 提供了在 Mac 上下载和安装 Aspose.Slides for .NET 的最简便途径。

### **安装 Aspose.Slides**

1. 打开 Visual Studio。 
2. 创建一个简单的控制台应用程序或打开现有项目。 
3. 依次选择 **Project** > **Manage NuGet Packages...**  
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. 在文本框中输入 *Aspose.Slides*。 
5. 点击 **Aspose.Slides for .NET**，然后点击 **Add Package**。 
6. 添加一个简单的代码片段。  
   * 您可以复制 [此页面](/slides/zh/net/create-presentation/) 上的代码。 
7. 运行应用程序。 
8. 打开项目的 *folder/bin/Debug/presentation_file_name*。

## **常见问题**

**是否有免费版或试用限制？**

是的，默认情况下，Aspose.Slides 以评估模式运行，会添加水印并可能存在其他限制。要解除这些限制，您需要应用有效的 [许可证](/slides/zh/net/licensing/)。