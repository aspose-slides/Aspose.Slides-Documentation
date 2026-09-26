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
description: "从 NuGet 在 Windows、Linux 和 macOS 上为 .NET 安装 Aspose.Slides：在两个包之间进行选择，使用 .NET CLI 或 Visual Studio 添加其中一个，并安装 Linux 的先决条件。"
---
## **概述**

本文说明如何在 Windows、Linux 和 macOS 上将 Aspose.Slides for .NET 添加到项目中。Aspose.Slides 通过 NuGet 分发。您可以在任意操作系统上使用 .NET CLI 添加，或在 Windows 上使用 Visual Studio 的 NuGet 包管理器或程序包管理器控制台。本文还说明了两个 NuGet 包的选择以及 Linux 需要的额外内容。

在安装之前，请在[系统要求](/slides/zh/net/system-requirements/)中查看受支持的操作系统、.NET 实现以及额外依赖项。

## **选择包**

Aspose.Slides for .NET 以两个 NuGet 包的形式发布。两者提供相同的 Aspose.Slides 命名空间和类，因此在切换时代码无需更改；仅包引用和平台要求不同。

| 包 | 适用于 | 其他要求 |
|---|---|---|
| [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) | Windows 和 .NET Framework 应用程序 | 在 Linux 和 macOS 上：`libgdiplus` 库，以及在应用启动时启用 `System.Drawing.EnableUnixSupport` 开关 |
| [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) | Windows、Linux 和 macOS 上的 .NET 6 或更高版本 | 在 Linux 上：如果系统未预装，需要 `fontconfig` 库 |

如果不确定，请在 Windows 上使用 Aspose.Slides.NET，在 Linux 和 macOS 上使用 Aspose.Slides.NET6.CrossPlatform。对于 Alpine Linux，以及 glibc 低于 2.23（x64）或 2.39（ARM64）的 Linux 系统，请使用 Aspose.Slides.NET。[系统要求](/slides/zh/net/system-requirements/) 列出了每个包支持的平台。

## **使用 .NET CLI 安装**

以下步骤适用于安装 .NET SDK 6 或更高版本的 Windows、Linux 和 macOS。创建一个控制台应用程序：

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

然后为您的平台添加相应的包。项目中只能添加这两个包中的一个。

- 在 Windows 上：`dotnet add package Aspose.Slides.NET`
- 在 Linux 和 macOS 上：`dotnet add package Aspose.Slides.NET6.CrossPlatform`（在 Linux 上，请先安装其前置依赖；参见[Linux](#linux)）

要验证包是否工作，请将 *Program.cs* 的内容替换为[创建演示文稿](/slides/zh/net/create-presentation/)中的第一个示例，然后运行 `dotnet run`。它会在项目文件夹中生成 *hello.pptx*。

## **Windows**

### **方法 1：从 NuGet 包管理器安装或更新 Aspose.Slides**

1. 打开 Microsoft Visual Studio。  
2. 创建一个控制台应用或打开现有项目。  
3. 在**解决方案资源管理器**中，右键单击项目并选择**管理 NuGet 包**（或转到**项目** > **管理 NuGet 包**）。  
4. 在**浏览**选项卡中搜索 *Aspose.Slides*。  
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}  
5. 单击 **Aspose.Slides.NET**，然后点击 **安装**。  
   * 如果已安装 Aspose.Slides 且想更新，请改为单击 **更新**。

包会被下载并在项目中引用。

### **方法 2：通过程序包管理器控制台安装或更新 Aspose.Slides**

以下示例演示如何通过程序包管理器控制台引用 [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) 包：

1. 打开 Microsoft Visual Studio。  
2. 创建一个控制台应用或打开现有项目。  
3. 转到 **工具** > **NuGet 包管理器** > **程序包管理器控制台**。  
![打开程序包管理器控制台](installation_2.png)  
4. 运行以下命令：`Install-Package Aspose.Slides.NET`  
![运行 Install-Package 命令](installation_3.png)  
最新版本将被安装到项目中。

窗口底部会出现 **Installing Aspose.Slides.NET** 消息。  
![程序包管理器控制台中的安装进度](installation_4.png)  

下载完成后，会显示确认信息。该包遵循 [Aspose EULA](https://about.aspose.com/legal/eula)。  
![安装确认信息](installation_5.png)  

Aspose.Slides 已添加到项目并被引用。  
![项目中引用的 Aspose.Slides](installation_6.png)  

要更新包，请在程序包管理器控制台中运行 `Update-Package Aspose.Slides.NET`。

## **Linux**

使用上述 .NET CLI 步骤。选择相应的包并使用发行版的包管理器安装其前置依赖。以 Debian 和 Ubuntu 为例：

- **Aspose.Slides.NET6.CrossPlatform**：安装 `fontconfig`。  

  ```bash
  sudo apt-get update && sudo apt-get install -y libfontconfig1
  dotnet add package Aspose.Slides.NET6.CrossPlatform
  ```

- **Aspose.Slides.NET**：安装 `libgdiplus`，并在应用使用 Aspose.Slides 之前启用 System.Drawing 的 Unix 支持。  

  ```bash
  sudo apt-get update && sudo apt-get install -y libgdiplus
  dotnet add package Aspose.Slides.NET
  ```

  在应用程序的入口处（在任何 Aspose.Slides 调用之前）添加以下语句。对于使用顶层语句的 *Program.cs*，请在 `using` 指令之后添加：  

  ```c#
  System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
  ```

  在 Alpine Linux 以及 glibc 过旧而不支持 Aspose.Slides.NET6.CrossPlatform 的系统上，请使用此包。

演示文稿中使用的字体或合适的替代字体必须已安装到系统上，才能正确渲染文本。[系统要求](/slides/zh/net/system-requirements/) 描述了 Aspose.Slides.NET 在 Alpine Linux 上所需的包，包括字体。

## **macOS**

使用上面的 .NET CLI 步骤，并选择 **Aspose.Slides.NET6.CrossPlatform** 包，该包支持 Intel (x86_64) 和 Apple Silicon (ARM64) Mac：

```bash
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

## **FAQ**

**是否提供免费版或试用限制？**

是的。若未授权，Aspose.Slides 将以评估模式运行：所有保存的幻灯片上会添加评估水印，并截断从演示文稿中读取的文本。要移除这些限制，请应用有效的[授权](/slides/zh/net/licensing/)。