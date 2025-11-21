---
title: 安装
type: docs
weight: 70
url: /zh/net/installation/
keywords: "下载 Aspose.Slides, 安装 Aspose.Slides, Aspose.Slides 安装, Windows, macOS, .NET"
description: "在 Windows 或 macOS 上为 .NET 安装 Aspose.Slides"
---

## **Windows**
NuGet 提供了在 PC 上下载和安装 Aspose API for .NET 的最简路径。

### **Method 1: Install or Update Aspose.Slides from the NuGet Package Manager**
1. 打开 Microsoft Visual Studio。  
2. 创建一个简单的控制台应用程序或打开现有项目。  
3. 依次点击 **Tools** > **NuGet package manager**。  
4. 在 **Browse** 下，在文本框中搜索 *Aspose Slides*。  
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. 点击 **Aspose.Slides.NET**，然后点击 **Install**。  
   * 如果您想更新 Aspose.Slides（假设您已经安装），请改为点击 **Update**。  

选定的 API 将被下载并在项目中引用。

### **Method 2: Install or Update Aspose.Slides Through the Package Manager Console**
以下是在包管理器控制台中引用 [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) 的方法：
1. 打开 Microsoft Visual Studio。  
2. 创建一个简单的控制台应用程序或打开现有项目。  
3. 依次点击 **Tools** > **Library Package Manager** > **Package Manager Console**。  
![todo:image_alt_text](installation_2.png)
4. 运行以下命令：`Install-Package Aspose.Slides.NET`  
![todo:image_alt_text](installation_3.png)

最新的完整版本将安装到您的应用程序中。

* 或者，您可以在命令后添加 `-prerelease` 后缀，以指定也要安装最新的发布版（包括热修复）。

在窗口底部附近会出现 **Installing Aspose.Slides.NET** 提示。  
![todo:image_alt_text](installation_4.png)

下载完成后，您应该会看到一些确认信息。  

如果您不熟悉 [Aspose EULA](https://about.aspose.com/legal/eula)，可能想要阅读 URL 中引用的许可证。  
![todo:image_alt_text](installation_5.png)

在您的应用程序中，您应该会看到 Aspose.Slides 已成功添加并被引用。  
![todo:image_alt_text](installation_6.png)

在 Package Manager Console 中，您可以运行 `Update-Package Aspose.Slides.NET` 命令来检查 Aspose.Slides 包的更新。若发现更新，将自动安装。您也可以使用 `-prerelease` 后缀来更新最新的发布版。

#### **Considerations When Running on a Shared Server Environment**
我们强烈建议在运行所有 Aspose .NET 组件时使用 **Full Trust** 权限设置，因为 Aspose 组件有时需要访问注册表设置以及位于虚拟目录之外的文件，例如在读取字体时。  

此外，Aspose.NET 组件基于核心 .NET 系统类——其中一些类在特定情况下也需要 Full Trust 权限才能执行操作。  

互联网服务提供商（ISP）通常托管来自不同公司的多个应用程序，并且大多实施 Medium Trust 安全级别。在 .NET 2.0 环境中，这种安全级别可能导致限制，影响 Aspose.Slides 的操作：

- **RegistryPermission** 不可用。这意味着您无法访问注册表，而在渲染文档时需要枚举已安装的字体。  
- **FileIOPermission** 受限。这意味着只能访问应用程序虚拟目录层次结构中的文件。这也可能导致在导出操作期间无法读取字体。  

基于上述原因，我们强烈建议在 **Full Trust** 权限下运行 Aspose.Slides。如果您使用 **Medium trust**，可能会遇到不一致的情况——某些库功能（例如渲染）在执行特定任务时可能无法正常工作。

## **macOS**
NuGet 提供了在 mac 上下载和安装 Aspose.Slides for .NET 的最简路径。

**Install Prerequisite**
`System.Drawing` 命名空间在 macOS 上的行为不同，因此您必须安装 mono-libgdiplus。  

> 在 .NET 5 及之前的版本中，[System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) NuGet 包可在 Windows、Linux 和 macOS 上使用。但存在一些平台差异。在 Linux 和 macOS 上，GDI+ 功能由 [libgdiplus)](https://www.mono-project.com/docs/gui/libgdiplus/) 库实现。此库默认未随大多数 Linux 发行版安装，并且并未完全支持 Windows 和 macOS 上的 GDI+ 功能。某些平台根本没有 libgdiplus。要在 Linux 和 macOS 上使用 System.Drawing.Common 包中的类型，必须单独安装 libgdiplus。有关更多信息，请参阅 [Install .NET on Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux) 或 [Install .NET on macOS](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus).s  

要在 mac 上单独安装 mono-libgdiplus，请参阅 .NET 文档中的 [this article](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus)。

### **Install Aspose.Slides**
1. 打开 Visual Studio。  
2. 创建一个简单的控制台应用程序或打开现有项目。  
3. 依次点击 **Project** > **Manage NuGet Packages...**  
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. 在文本框中输入 *Aspose.Slides*。  
5. 点击 **Aspose.Slides for .NET**，然后点击 **Add Package**。  
6. 添加一段简单的代码片段。  
   * 您可以在 [此页面](/slides/zh/net/create-presentation/) 上复制代码。  
7. 运行应用程序。  
8. 打开项目的 *folder/bin/Debug/presentation_file_name*。

## **FAQ**
**是否有免费版或试用限制？**

是的，默认情况下，Aspose.Slides 以评估模式运行，会添加水印并可能存在其他限制。要取消限制，您需要使用有效的 [license](/slides/zh/net/licensing/)。