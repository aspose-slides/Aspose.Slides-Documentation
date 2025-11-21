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
description: "了解如何快速安装 Aspose.Slides for .NET。一步一步的指南、系统要求和代码示例——立即开始使用 PowerPoint 演示文稿！"
---

## **Windows**
NuGet 提供了在 PC 上下载和安装 Aspose .NET API 的最简捷途径。

### **方法 1：从 NuGet 包管理器安装或更新 Aspose.Slides**
1. 打开 Microsoft Visual Studio。 
2. 创建一个简单的控制台应用程序或打开现有项目。 
3. 依次点击 **Tools** > **NuGet package manager**。 
4. 在 **Browse** 下，在文本框中搜索 *Aspose Slides*。 
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. 点击 **Aspose.Slides.NET**，然后点击 **Install**。 
   * 如果你想更新 Aspose.Slides（假设已安装），请改为点击 **Update**。 

所选的 API 将被下载并在你的项目中引用。

### **方法 2：通过包管理器控制台安装或更新 Aspose.Slides**
以下是通过包管理器控制台引用 [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) 的方式：
1. 打开 Microsoft Visual Studio。 
2. 创建一个简单的控制台应用程序或打开现有项目。 
3. 依次点击 **Tools** > **Library Package Manager** > **Package Manager Console**。 
![todo:image_alt_text](installation_2.png)
5. 运行以下命令：`Install-Package Aspose.Slides.NET` 
![todo:image_alt_text](installation_3.png)
最新的完整版本将安装到你的应用程序中。 

* 或者，你可以在命令后添加 `-prerelease` 后缀，以指定也必须安装包括热修复在内的最新版本。 

**Installing Aspose.Slides.NET** 提示会出现在窗口底部附近。 
![todo:image_alt_text](installation_4.png)

下载完成后，你应该会看到一些确认消息。 

如果你不熟悉 [Aspose EULA](https://about.aspose.com/legal/eula)，可能需要阅读 URL 中引用的许可证。 
![todo:image_alt_text](installation_5.png)

在你的应用程序中，你应该会看到 Aspose.Slides 已成功添加并被引用。 
![todo:image_alt_text](installation_6.png)

在 Package Manager Console 中，你可以运行 `Update-Package Aspose.Slides.NET` 命令来检查 Aspose.Slides 包的更新。如果找到更新，将自动安装。你也可以使用 `-prerelease` 后缀来更新到最新发布版。

#### **在共享服务器环境中运行时的注意事项**
我们强烈建议在 **Full Trust** 权限设置下运行所有 Aspose .NET 组件，因为 Aspose 组件有时需要访问注册表设置和位于虚拟目录之外的文件——例如，当 Aspose 组件需要读取字体时。 
此外，Aspose.NET 组件基于核心 .NET 系统类——其中一些类在特定情况下也需要 Full Trust 权限才能执行操作。 
互联网服务提供商通常托管来自不同公司的多个应用程序，并主要强制使用 Medium Trust 安全级别。在 .NET 2.0 情况下，这种安全级别可能导致约束，影响 Aspose.Slides 的操作：
- **RegistryPermission** 不可用。这意味着你无法访问注册表，而在渲染文档时需要枚举已安装的字体。
- **FileIOPermission** 受限。这意味着你只能访问应用程序虚拟目录层级中的文件。这也可能导致在导出操作期间无法读取字体。 

鉴于上述原因，我们强烈建议在 **Full Trust** 权限下运行 Aspose.Slides。如果使用 **Medium trust**，可能会出现不一致的情况——例如，在执行某些任务时，某些库功能（如渲染）可能无法正常工作。

## **macOS**
NuGet 提供了在 mac 上下载和安装 Aspose.Slides for .NET 的最简捷途径。 

**安装前置条件**

`System.Drawing` 命名空间在 macOS 上的行为不同，因此你必须安装 mono-libgdiplus。 

> 在 .NET 5 及之前的版本中，[System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) NuGet 包可在 Windows、Linux 和 macOS 上使用。但是，存在一些平台差异。在 Linux 和 macOS 上，GDI+ 功能由 [libgdiplus)](https://www.mono-project.com/docs/gui/libgdiplus/) 库实现。该库在大多数 Linux 发行版中默认未安装，并且并未支持 Windows 和 macOS 上 GDI+ 的全部功能。还有一些平台根本没有 libgdiplus。要在 Linux 和 macOS 上使用 System.Drawing.Common 包中的类型，必须单独安装 libgdiplus。如需了解更多信息，请参阅 [Install .NET on Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux) 或 [Install .NET on macOS](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus).s

要在你的 mac 上单独安装 mono-libgdiplus，请参阅 .NET 文档中的 [this article](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus)。 

### **安装 Aspose.Slides**
1. 打开 Visual Studio。 
2. 创建一个简单的控制台应用程序或打开现有项目。 
3. 依次点击 **Project** > **Manage NuGet Packages...** 
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. 在文本框中输入 *Aspose.Slides*。 
5. 点击 **Aspose.Slides for .NET**，然后点击 **Add Package.** 
6. 添加一个简单的代码片段。 
   * 你可以复制 [this page](/slides/zh/net/create-presentation/) 上的代码。 
7. 运行应用程序。 
8. 打开你的项目的 *folder/bin/Debug/presentation_file_name*。 

## **FAQ**

**是否有免费版或试用限制？**

是的，默认情况下，Aspose.Slides 以评估模式运行，会添加水印并可能存在其他限制。要消除这些限制，你需要应用有效的 [license](/slides/zh/net/licensing/)。