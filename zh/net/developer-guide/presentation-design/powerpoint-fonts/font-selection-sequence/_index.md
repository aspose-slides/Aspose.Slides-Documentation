---
title: Aspose.Slides for .NET 中的字体选择顺序
linktitle: 字体选择
type: docs
weight: 80
url: /zh/net/font-selection-sequence/
keywords:
- 字体选择
- 字体替代
- 字体替换
- 替代规则
- 可用字体
- 缺失字体
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解 Aspose.Slides for .NET 如何选择字体，确保 PPT、PPTX 和 ODP 文件呈现清晰一致——立即提升您的幻灯片。"
---
## **概述**

当加载、呈现或转换为其他格式时，Aspose.Slides 会考虑演示文稿中嵌入的字体以及应用程序可用的字体。如果所需字体不可用，Aspose.Slides 会选择一个尽可能接近 PowerPoint 将使用的字体的替代字体。

可用的字体可以包括系统字体、应用程序加载的字体以及嵌入在演示文稿中的字体。对于匹配的嵌入字体和已注册字体，下面描述的 .NET 26.11 首选项用于控制哪个拥有优先级。通过 [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) 定义的字体替换规则是另一种机制。

您还可以在应用程序运行时添加字体、使用演示文稿中的嵌入字体，或为输出文档（如 PDF 文件）加载外部字体。

## **字体选择**

文本可以引用主题字体，例如 `+mn-lt`，而不是显式的字体族名称。请参阅 [Resolve Theme Font References](/slides/zh/net/presentation-theme/#resolve-theme-font-references) 以获取适用主题指定的字体族。解析该引用与检查字体可用性以及在渲染时进行替换或字形回退是分开的；它并不确定最终用于渲染文本的字体文件。

在渲染幻灯片或转换演示文稿时，请检查请求的字体是否已嵌入或可从已注册的来源获取。缺失的字体可能需要替换或替代；请参阅 [**Font Replacement**](/slides/zh/net/font-replacement/) 和 [**Font Substitution**](/slides/zh/net/font-substitution/)。

在调查字体选择时：

1. 解析请求的字体族和样式，包括任何主题引用。
2. 检查嵌入字体和已注册来源，包括系统字体和应用程序加载的字体。当匹配的嵌入版本与已注册版本竞争时，使用下面的首选项。
3. 如果请求的字体或字符不可用，请查看 [字体替换规则](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) 和字形回退。

Aspose.Slides 允许您在应用程序运行时添加字体，然后使用这些字体。请参阅 [**自定义字体**](/slides/zh/net/custom-font/)。

当在演示文稿中放置额外的字体时，它们称为 [**嵌入字体**](/slides/zh/net/embedded-font/)。

Aspose.Slides 允许您添加仅适用于 *仅* 输出文档的字体。例如，如果您要转换为 PDF 的演示文稿中缺少系统和嵌入字体，您可以将所需的字体添加或加载为 **外部字体**。

{{% alert title="Note" color="info" %}} 
我们不提供任何字体，无论是付费的还是免费的。我们的 API 允许您加载外部字体并将其嵌入文档，但请自行决定并自行承担使用这些字体的责任。
{{% /alert %}}

## **首选已注册字体而非嵌入字体**

从 .NET 26.11 开始，[IFontsManager.PreferRegisteredFontsOverEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/preferregisteredfontsoverembedded/) 允许在导出期间让匹配的已注册字体优先于嵌入字体。默认值为 `false`。匹配使用字体名称和样式；不同的族名不算替换匹配。已注册字体可以来自系统或 [显式加载的字体来源](/slides/zh/net/custom-font/)。

下面的示例在 .NET 8 上使用 **Aspose.Slides.NET6.CrossPlatform 26.11** 包。请按照您的环境遵循 [安装指南](/slides/zh/net/installation/)。提供包含嵌入字体的 `embedded-fonts.pptx` 和具有相同族名及样式的 `preferred.ttf`。如果您想比较输出结果，这两个字体文件应在外观上有所差异。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var fontBytes = File.ReadAllBytes("preferred.ttf");
FontsLoader.LoadExternalFont(fontBytes);
using var presentation = new Presentation("embedded-fonts.pptx");

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("embedded-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = true;
presentation.Save("registered-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("restored-preference.pdf", SaveFormat.Pdf);
```

此设置会在导出期间更改字体优先级；它不会重命名文本的字体、删除嵌入的字体数据或重新嵌入已注册的文件。这是一个运行时设置：在重新打开演示文稿后需要再次设置。如果没有匹配的已注册字体，可启用此首选项也不会提供字体；请在目标环境中验证生成的字体和布局。

已对上述配置使用显式加载的常规字体的 PNG 和 PDF 输出进行了检查。在依赖相同结果之前，请检查您自己的字体文件、样式、SDK 构建和输出格式。字体度量可能会改变换行和定位。当需要不同的字体族时，使用 [字体替换](/slides/zh/net/font-replacement/) 或 [字体替代](/slides/zh/net/font-substitution/)；当需要更改演示文稿中存储的字体时，使用 [嵌入字体操作](/slides/zh/net/embedded-font/)。

## **常见问题**

**如何在转换前确定演示文稿实际使用了哪些字体？**

Aspose.Slides 让您通过 [字体管理器](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) 检查使用的字体，以便决定是 [嵌入](/slides/zh/net/embedded-font/)、[替换](/slides/zh/net/font-replacement/) 还是添加 [外部来源](/slides/zh/net/custom-font/)。这有助于防止在渲染和导出期间出现不期望的替换。

**我可以在不将字体安装到操作系统的情况下添加额外的字体目录吗？**

可以。您可以注册诸如文件夹或内存流等 [外部字体来源](/slides/zh/net/custom-font/) 用于渲染和导出。这消除了对主机系统字体的依赖，并保持布局可预测。

**当字形缺失时，如何防止无声回退到不合适的字体？**

提前定义明确的 [字体替换](/slides/zh/net/font-replacement/) 和字体 [回退规则](/slides/zh/net/fallback-font/)。通过分析使用的字体并为替代品设定受控的优先级，您可以确保排版一致并避免意外结果。