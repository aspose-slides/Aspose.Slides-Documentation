---
title: 在 .NET 中自定义 PowerPoint 字体
linktitle: 自定义字体
type: docs
weight: 20
url: /zh/net/custom-font/
keywords:
- 字体
- 自定义字体
- 外部字体
- 加载字体
- 管理字体
- 字体文件夹
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 定制 PowerPoint 幻灯片中的字体，以确保您的演示文稿在任何设备上都保持清晰和一致。"
---
## **概述**

Aspose.Slides 允许您在演示文稿中使用自定义字体，而无需在操作系统上安装这些字体。您可以从自定义文件夹加载字体，通过文档级字体源为特定演示文稿提供字体，或直接从二进制数据加载外部字体。

加载的字体会在呈现或导出演示文稿时使用，例如导出为 PDF、图像以及其他受支持的格式。这有助于在不同环境中保持演示文稿输出的一致性。本文还说明了如何检查 Aspose.Slides 使用的字体文件夹以及在使用外部字体后如何清除字体缓存。

为渲染注册自定义字体与将字体嵌入 PPTX 文件是分开的。如果必须将字体存储在演示文稿本身中，请显式使用字体嵌入功能。

{{% alert color="info" %}} 

Aspose Slides 允许您使用 [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/zh/net/aspose.slides/fontsloader/loadexternalfonts/) 方法加载这些字体：

* TrueType (.ttf) 和 TrueType Collection (.ttc) 字体。参见 [TrueType](https://en.wikipedia.org/wiki/TrueType)。
* OpenType (.otf) 字体。参见 [OpenType](https://en.wikipedia.org/wiki/OpenType)。

{{% /alert %}}

## **加载自定义字体**

Aspose.Slides 允许您在不将字体安装到系统的情况下加载演示文稿使用的字体。这会影响导出输出——如 PDF、图像和其他受支持的格式——从而使生成的文档在不同环境中保持一致。字体从自定义目录加载。

1. 指定一个或多个包含字体文件的文件夹。
2. 调用静态 [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/zh/net/aspose.slides/fontsloader/loadexternalfonts/) 方法从这些文件夹加载字体。
3. 加载并呈现/导出演示文稿。
4. 调用 [FontsLoader.ClearCache](https://reference.aspose.com/slides/zh/net/aspose.slides/fontsloader/clearcache/) 清除字体缓存。

下面的代码示例演示了字体加载过程：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 定义包含自定义字体文件的文件夹。
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// 从指定的文件夹加载自定义字体。
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// 使用已加载的字体渲染/导出演示文稿（例如导出为 PDF、图像或其他格式）。
presentation.Save("output.pdf", SaveFormat.Pdf);

// 在工作完成后清除字体缓存。
FontsLoader.ClearCache();
```

{{% alert color="info" title="注意" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/zh/net/aspose.slides/fontsloader/loadexternalfonts/) 会向字体搜索路径添加额外的文件夹，但不会改变字体初始化顺序。字体的初始化顺序如下：

1. 默认操作系统字体路径。
1. 通过 [FontsLoader](https://reference.aspose.com/slides/zh/net/aspose.slides/fontsloader/) 加载的路径。

{{%/alert %}}

## **获取自定义字体文件夹**

Aspose.Slides 提供 [GetFontFolders](https://reference.aspose.com/slides/zh/net/aspose.slides/fontsloader/getfontfolders/) 方法，让您查找字体文件夹。此方法返回通过 `LoadExternalFonts` 方法添加的文件夹以及系统字体文件夹。

下面的 C# 代码展示了如何使用 [GetFontFolders](https://reference.aspose.com/slides/zh/net/aspose.slides/fontsloader/getfontfolders/)：

```c#
using Aspose.Slides;

// 此行输出检查字体文件的文件夹。
// 这些文件夹包括通过 LoadExternalFonts 方法添加的文件夹和系统字体文件夹。
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **为演示文稿指定使用的自定义字体**

Aspose.Slides 提供 [DocumentLevelFontSources](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/documentlevelfontsources/) 属性，允许您指定将在演示文稿中使用的外部字体。

下面的 C# 代码展示了如何使用 [DocumentLevelFontSources](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/documentlevelfontsources/) 属性：

```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // 对演示文稿进行操作
    // CustomFont1、CustomFont2，以及来自 assets\fonts 和 global\fonts 文件夹及其子文件夹的字体均可用于该演示文稿
}
```

## **外部管理字体**

Aspose.Slides 提供 [LoadExternalFont](https://reference.aspose.com/slides/zh/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) 方法，允许您从二进制数据加载外部字体。

下面的 C# 代码演示了字节数组字体加载过程：

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // 演示文稿生命周期期间已加载的外部字体
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **常见问题**

**自定义字体会影响所有格式的导出（PDF、PNG、SVG、HTML）吗？**

是的。已连接的字体会被渲染器在所有导出格式中使用。

**自定义字体会自动嵌入生成的 PPTX 吗？**

不会。为渲染注册字体并不等同于将其嵌入 PPTX。如果需要将字体随演示文稿文件一起携带，必须使用显式的[嵌入功能](/slides/zh/net/embedded-font/)。

**当自定义字体缺少某些字形时，我能控制回退行为吗？**

可以。通过配置[字体替代](/slides/zh/net/font-substitution/)、[替换规则](/slides/zh/net/font-replacement/)和[回退集](/slides/zh/net/fallback-font/)，可以精确定义在请求的字形缺失时使用哪个字体。

**我能在 Linux/Docker 容器中使用字体而不在系统范围内安装吗？**

可以。指向您自己的字体文件夹或从字节数组加载字体，这样就消除了对容器镜像中系统字体目录的任何依赖。

> **Linux/Docker 注意**：调用 `FontsLoader.LoadExternalFonts` 时，确保 `directories` 数组中的每个条目都包含指向现有目录的非空路径。如果用于构造字体路径的环境变量未定义或为空，Aspose.Slides 可能会尝试将空值解析为完整路径，从而导致 `System.ArgumentException`。

**关于授权——我可以在没有限制的情况下嵌入任何自定义字体吗？**

您须自行负责字体授权合规性。授权条款各不相同；某些授权禁止嵌入或商业使用。分发输出之前，请务必查看字体的最终用户许可协议 (EULA)。