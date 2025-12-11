---
title: 安装
type: docs
weight: 70
url: /zh/cpp/installation/
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
- C++
- Aspose.Slides
description: "快速了解如何安装 Aspose.Slides for C++。一步一步的指南、系统要求和代码示例——立即开始使用 PowerPoint 演示文稿！"
---

## **Windows**
NuGet 提供了在 PC 上下载和安装 Aspose C++ API 的最简便途径。 

### **Option One: Install or Update Aspose.Slides for C++ from the NuGet Package Manager**
1. 打开 Microsoft Visual Studio。 
2. 创建一个简单的控制台应用程序，或者打开您喜欢的项目。 
3. 依次点击 **Tools** > **NuGet package manager**。 
4. **Browse** 中，输入 *Aspose.Slides.Cpp* 到文本框。 

![todo:image_alt_text](installation_1.png)

点击所需的 **Aspose.Slides.Cpp** 版本，然后点击 **Install**。 
* 如果您想更新 Aspose.Slides（即已经安装），请选择 **Update**。 

所选的 API 将被下载并在项目中引用。

### **Option 2: Install or Update Aspose.Slides Through the Package Manager Console**
要在包管理控制台中引用 [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.Cpp/) ，请执行以下操作：

1. 在 Visual Studio 中打开您的 solution/project。 

1. 依次点击 **Tools** > **NuGet Package Manager** > **Package Manager Console**。 

Package Manager Console 将打开。 

![todo:image_alt_text](installation_2.png)

输入以下命令：`Install-Package Aspose.Slides.Cpp` 
> 如果您想安装 x86 版本，请使用 Aspose.Slides.Cpp.x86 包：`Install-Package Aspose.Slides.Cpp.x86`

按 Enter 键。 

最新的完整版本将安装到您的应用程序中。 

* 或者，您可以在命令后添加 `-prerelease` 后缀，以便安装包括热修复在内的最新版本。

![todo:image_alt_text](installation_3.png)

下载完成后，您应该会看到一些确认信息。  

![todo:image_alt_text](installation_4.png)

如果您不熟悉 [Aspose EULA](https://about.aspose.com/legal/eula)，可以查看该链接中的许可协议。  

在 Package Manager Console 中，您可以运行 `Update-Package Aspose.Slides.Cpp` 命令来检查 Aspose.Slides 包的更新。若有更新，将自动安装。您也可以使用 `-prerelease` 后缀来更新到最新版本。

### **Using Include and lib Folders**
1. 下载最新的 Aspose.Slides for C++ 版本。 
1. 将文件夹解压到生产环境中。 
1. 在项目中引用 Include 和 lib 文件夹以使用 Aspose.Slides for C++。

## **FAQ**

**Is there a free version or trial limitation?**

是的，默认情况下，Aspose.Slides 以评估模式运行，会添加水印并可能存在其他限制。要解除这些限制，需要使用有效的 [license](/slides/zh/cpp/licensing/)。