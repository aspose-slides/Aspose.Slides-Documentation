---
title: 如何运行示例
type: docs
weight: 130
url: /net/how-to-run-examples/
---

## **软件要求**
在您下载并运行示例之前，请检查并确认您的设置满足以下要求：

- Visual Studio 2010 或更高版本。
- 在 Visual Studio 中安装了 NuGet 包管理器。请验证 Visual Studio 中是否安装了最新的 NuGet API 版本。

有关安装 NuGet 包管理器的说明，请访问此页面：https://docs.microsoft.com/en-us/nuget/install-nuget-client-tools

1. 依次点击 **工具** > **选项** > **NuGet 包管理器**。

1. 展开 **NuGet 包管理器**（双击它），然后选择 **包源**。

1. 检查并确认选中 nuget.org 参数。

   示例项目使用 NuGet 自动包还原功能，因此您需要具有活动的互联网连接。

   如果您打算在没有活动互联网连接的计算机上执行示例，请查看 [安装](https://docs.aspose.com/slides/net/installation/) 并（手动）在示例项目中添加对 Aspose.Slides.dll 的引用。
## **从 GitHub 下载**
所有 Aspose.Slides for .NET 示例都托管在 [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET)。

您可以使用您喜欢的 GitHub 客户端克隆存储库，或者在 [这里](https://github.com/aspose-slides/Aspose.Slides-for-.NET/archive/master.zip) 下载 ZIP 文件。

1. 如果您下载了 ZIP 文件，您必须将其中的内容提取到计算机上的一个文件夹中。

所有的示例都存储在 **Examples** 文件夹中。

有一个 C# Visual Studio 解决方案文件。项目是在 Visual Studio 2013 中创建的，但解决方案文件与 Visual Studio 2010 SP1 及更高版本兼容。

2. 在 Visual Studio 中打开解决方案文件并构建项目。

   在第一次运行时，依赖项会通过 NuGet 自动下载。

**Examples** 根文件夹中的 **Data** 文件夹包含在 C# 示例中使用的输入文件。您必须与示例项目一起下载 **Data** 文件夹。

3. 打开 RunExamples.cs 文件。所有示例均从此处调用。

4. 在项目中取消注释您想要运行的示例。

如果您在设置或运行示例时遇到问题，请随时通过我们的论坛与我们联系。
## **贡献**
您可以通过添加或改进示例来为项目做出贡献。存储库中的所有示例和展示项目都是开源的，因此您（和其他人）可以在应用程序中自由使用它们。

要贡献，您可以分叉存储库，编辑源代码并创建拉取请求。我们会审查更改。如果我们认为这些更改有用，我们将把它们添加到存储库中。