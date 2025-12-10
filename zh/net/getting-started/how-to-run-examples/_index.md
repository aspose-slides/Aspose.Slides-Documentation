---
title: 如何运行示例
type: docs
weight: 130
url: /zh/net/how-to-run-examples/
keywords:
- 示例
- 软件要求
- NuGet
- GitHub
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "快速运行 Aspose.Slides for .NET 示例：克隆仓库，恢复包，然后构建并测试 PPT、PPTX 和 ODP 的功能。"
---

## **软件要求**
在下载和运行示例之前，请检查并确认您的环境满足以下要求：

- Visual Studio 2010或更高版本。
- 在Visual Studio中安装了NuGet包管理器。验证已在Visual Studio中安装最新的NuGet API版本。

有关安装NuGet包管理器的说明，请访问此页面：https://docs.microsoft.com/en-us/nuget/install-nuget-client-tools

1. 依次打开**Tools** > **Options** > **NuGet Package Manager**。

1. 展开**NuGet Package Manager**（双击展开）并选择**Package Sources**。

1. 检查并确认已选中nuget.org参数。

   示例项目使用NuGet自动包还原功能，因此您需要保持活跃的互联网连接。

   如果您在执行示例的机器上没有活跃的互联网连接，请查看[Installation](https://docs.aspose.com/slides/net/installation/)并（手动）在示例项目中添加对Aspose.Slides.dll的引用。

## **从GitHub下载Aspose.Slides**
所有Aspose.Slides for .NET示例均托管在[GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET)。

您可以使用喜欢的GitHub客户端克隆仓库，或下载ZIP文件[here](https://github.com/aspose-slides/Aspose.Slides-for-.NET/archive/master.zip)。

1. 如果您下载ZIP文件，需要将其内容解压到计算机上的文件夹中。

所有示例均存放在**Examples**文件夹中。

其中有一个C# Visual Studio解决方案文件。项目在Visual Studio 2013中创建，但解决方案文件兼容Visual Studio 2010 SP1及更高版本。

2. 在Visual Studio中打开解决方案文件并构建项目。

   首次运行时，依赖项会通过NuGet自动下载。

**Examples**根目录下的**Data**文件夹包含C#示例使用的输入文件。您需要将**Data**文件夹与示例项目一起下载。

3. 打开RunExamples.cs文件。所有示例均从此文件调用。

4. 在项目中取消注释您想运行的示例。

如果在设置或运行示例时遇到问题，请随时通过我们的论坛寻求帮助。

## **贡献**
您可以通过添加或改进示例为项目做出贡献。仓库中的所有示例和展示项目都是开源的，您（以及其他人）可以在应用程序中自由使用它们。

要贡献代码，您可以fork仓库，编辑源码，并创建pull request。我们会审查更改。如果有价值，我们会将其合并到仓库中。