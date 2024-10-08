---
title: 安装
type: docs
weight: 70
url: /net/installation/
keywords: "下载 Aspose.Slides, 安装 Aspose.Slides, Aspose.Slides 安装, Windows, macOS, .NET"
description: "在 Windows 或 macOS 上安装 Aspose.Slides for .NET"
---

## **Windows**
NuGet 提供了在 PC 上下载和安装 Aspose .NET API 的最简单路径。

### **方法 1：通过 NuGet 包管理器安装或更新 Aspose.Slides**

1. 打开 Microsoft Visual Studio。
2. 创建一个简单的控制台应用程序或打开现有项目。
3. 依次选择 **工具** > **NuGet 包管理器**。
4. 在 **浏览** 下，在文本框中搜索 *Aspose Slides*。
{{% image img="installation_1.png" alt="通过 NuGet 包管理器安装 Aspose.Slides - 1" %}}
5. 点击 **Aspose.Slides.NET**，然后点击 **安装**。
   * 如果您想更新 Aspose.Slides（假设您已经安装了它），请点击 **更新**。

所选 API 将被下载并引用到您的项目中。

### **方法 2：通过包管理器控制台安装或更新 Aspose.Slides**

以下是通过包管理器控制台引用 [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) 的方法：

1. 打开 Microsoft Visual Studio。
2. 创建一个简单的控制台应用程序或打开现有项目。
3. 依次选择 **工具** > **库包管理器** > **包管理器控制台**。
![todo:image_alt_text](installation_2.png)
4. 运行以下命令：`Install-Package Aspose.Slides.NET`
![todo:image_alt_text](installation_3.png)
最新的完整版本将被安装到您的应用程序中。

* 另外，您可以在命令中添加 `-prerelease` 后缀，以指定必须安装最新版本（包括热修复）。

**安装 Aspose.Slides.NET** 的提示将在窗口底部出现。
![todo:image_alt_text](installation_4.png)

下载完成后，您应该看到一些确认消息。

如果您不熟悉 [Aspose EULA](https://about.aspose.com/legal/eula)，您可能需要阅读 URL 中提到的许可证。
![todo:image_alt_text](installation_5.png)

在您的应用程序中，您应该看到 Aspose.Slides 已成功添加并引用。
![todo:image_alt_text](installation_6.png)

在包管理器控制台中，您可以运行 `Update-Package Aspose.Slides.NET` 命令以检查 Aspose.Slides 包的更新。如果找到更新，将自动安装。您还可以使用 `-prerelease` 后缀来更新最新版本。

#### **在共享服务器环境中运行时的注意事项**
我们强烈建议您以 **完全信任** 权限集运行所有 Aspose .NET 组件，因为 Aspose 组件有时需要访问注册表设置和存放在虚拟目录以外的文件，例如，当 Aspose 组件需要读取字体时。

此外，Aspose.NET 组件基于核心 .NET 系统类，而其中一些类在某些情况下也需要完全信任权限来执行操作。

托管来自不同公司的多个应用程序的 Internet 服务提供商通常会强制执行中等信任安全级别。在 .NET 2.0 的情况下，这种安全级别可能会导致影响 Aspose.Slides 操作的限制：

- **RegistryPermission** 不可用。这意味着您无法访问注册表，访问注册表对于在渲染文档时枚举已安装的字体是必需的。
- **FileIOPermission** 受限。这意味着您只能访问应用程序的虚拟目录层次结构中的文件。这也可能意味着在导出操作期间无法读取字体。

基于以上原因，我们强烈建议您以 **完全信任** 权限运行 Aspose.Slides。如果您使用 **中等信任**，您可能会遇到不一致性—某些库功能（例如渲染）可能在执行某些任务时不起作用。

## **macOS**

NuGet 提供了在 Mac 上下载和安装 Aspose.Slides for .NET 的最简单路径。

**安装先决条件**

`System.Drawing` 命名空间在 macOS 中的操作方式不同，因此您必须安装 mono-libgdiplus。

> 在 .NET 5 和早期版本中，[System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) NuGet 包可以在 Windows、Linux 和 macOS 上工作。但是，存在一些平台差异。在 Linux 和 macOS 上，GDI+ 功能由 [libgdiplus](https://www.mono-project.com/docs/gui/libgdiplus/) 库实现。此库在大多数 Linux 发行版中未默认安装，并且并不支持 Windows 和 macOS 上 GDI+ 的所有功能。还有一些平台根本没有 libgdiplus。要在 Linux 和 macOS 上使用来自 System.Drawing.Common 包的类型，您必须单独安装 libgdiplus。有关更多信息，请参见 [在 Linux 上安装 .NET](https://docs.microsoft.com/en-us/dotnet/core/install/linux) 或 [在 macOS 上安装 .NET](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus)。

要在您的 Mac 上单独安装 mono-libgdiplus，请参阅 [.NET 文档](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus) 中的 [此文章](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus)。 

### **安装 Aspose.Slides**

1. 打开 Visual Studio。
2. 创建一个简单的控制台应用程序或打开现有项目。
3. 依次选择 **项目** > **管理 NuGet 包...**
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. 在文本框中输入 *Aspose.Slides*。
5. 点击 **Aspose.Slides for .NET**，然后点击 **添加包**。
6. 添加一个简单的代码片段。
   * 您可以复制 [此页面](slides/net/create-presentation/) 上的代码。
7. 运行应用程序。
8. 打开您的项目的 *folder/bin/Debug/presentation_file_name*。