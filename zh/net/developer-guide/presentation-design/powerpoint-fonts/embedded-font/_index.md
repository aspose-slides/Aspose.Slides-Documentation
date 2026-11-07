---
title: .NET 中的演示文稿嵌入字体
linktitle: 嵌入字体
type: docs
weight: 40
url: /zh/net/embedded-font/
keywords:
- 添加字体
- 嵌入字体
- 字体嵌入
- 获取嵌入字体
- 添加嵌入字体
- 移除嵌入字体
- 压缩嵌入字体
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 中管理嵌入字体。使用 C# 添加、检索、移除和压缩字体，以保持文本外观并减小文件大小。"
---
## **介绍**

嵌入字体将字体数据存储在 PowerPoint 演示文稿中。当查看器支持嵌入字体时，即使目标系统未安装这些字体，也能使用这些字体显示文本。这有助于保留换行、文本间距和幻灯片布局。

Aspose.Slides for .NET 让您通过 [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) 属性在 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 上检索、添加和移除嵌入字体。您还可以通过删除演示文稿未使用的字符来减小嵌入字体数据的大小。

以下示例使用 PPTX 文件。在嵌入字体之前，请确保其字体数据可供 Aspose.Slides 使用，并且其许可证允许嵌入。

## **获取和移除嵌入字体**

使用 [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) 列出存储在演示文稿中的字体。要移除某个字体，请将列表中的字体传递给 [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont/)，然后保存演示文稿。

下面的示例列出 `EmbeddedFonts.pptx` 中的嵌入字体，并在存在时移除 Calibri：
```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("EmbeddedFonts.pptx");
var fontsManager = presentation.FontsManager;
var embeddedFonts = fontsManager.GetEmbeddedFonts();

foreach (var font in embeddedFonts)
{
    Console.WriteLine(font.FontName);
}

var fontToRemove = Array.Find(embeddedFonts, font => string.Equals(font.FontName, "Calibri", StringComparison.OrdinalIgnoreCase));
if (fontToRemove != null)
{
    fontsManager.RemoveEmbeddedFont(fontToRemove);
    presentation.Save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Calibri is not embedded. No output file was created.");
}
```

移除嵌入字体会删除其存储的字体数据；但不会更改文本所分配的字体。如果目标系统已安装该字体，文本仍可以使用它。否则，渲染可能需要 [字体替换](/slides/zh/net/font-substitution/)，这可能影响布局。

## **检查字体数据和嵌入权限**

使用 [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) 接口在嵌入前检查字体。调用 [IFontsManager.GetFonts](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfonts/) 可检索演示文稿中使用的字体。对于每个字体，传入一个 [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/) 对象和所需的 [FontStyleType](https://reference.aspose.com/slides/net/aspose.slides/fontstyletype/) 值给 [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontbytes/)。该方法返回该字体样式的二进制数据，如果请求的字体或样式不可用，则返回 `null`。不要将 `null` 结果传递给 [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontembeddinglevel/)，因为该方法需要字节数组。

[EmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/embeddinglevel/) 是一个标志枚举，用于报告字体中存储的嵌入限制：

- `Installable` 允许嵌入并在其他系统上永久安装，受字体许可证约束。
- `Restricted` 禁止嵌入，除非在它是唯一使用权限标志时从字体的合法所有者处获得许可。
- `PreviewPrint` 允许临时用于查看和打印；包含该字体的文档必须为只读。
- `Editable` 允许临时使用，并且文档可以被编辑和保存。
- `NoSubsetting` 是额外限制，禁止仅嵌入字形的子集。如果出现此标志，则嵌入所有字符。
- `BitmapOnly` 是额外限制，只允许嵌入位图字形，而非轮廓数据。如果字体没有位图字形，则无法嵌入。

前四个值描述使用权限，而 `NoSubsetting` 和 `BitmapOnly` 可以与它们组合。使用位运算检查这些修饰符。由于 `Installable` 为零，请勿使用 `HasFlag` 来检测它；应对使用权限位进行掩码并将结果与 `Installable` 比较。当前字体应最多设置一个使用权限位。为兼容设置了多个位的旧字体，下面的辅助方法会选择最宽松的权限：`Editable`，然后是 `PreviewPrint`，最后是 `Restricted`。

以下示例审计 `GetFonts` 返回的每种字体的常规、粗体、斜体和粗斜体数据。它会跳过不可用的样式、受限字体、仅位图字体、仅限预览和打印的字体（因为输出仍保持可编辑），以及已经嵌入的字体。如果任何可用样式具有 `NoSubsetting`，则为该字体族嵌入所有字符。
```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

static EmbeddingLevel GetUsagePermission(EmbeddingLevel level)
{
    const EmbeddingLevel permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel.Editable) != 0)
    {
        return EmbeddingLevel.Editable;
    }

    if ((permissions & EmbeddingLevel.PreviewPrint) != 0)
    {
        return EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & EmbeddingLevel.Restricted) != 0)
    {
        return EmbeddingLevel.Restricted;
    }

    return EmbeddingLevel.Installable;
}

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var fontStyles = new[]
{
    FontStyleType.Regular,
    FontStyleType.Bold,
    FontStyleType.Italic,
    FontStyleType.Bold | FontStyleType.Italic
};

var embeddedFontNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
foreach (var embeddedFont in fontsManager.GetEmbeddedFonts())
{
    embeddedFontNames.Add(embeddedFont.FontName);
}

var embeddingPlan = new List<(IFontData Font, EmbedFontCharacters Rule)>();
foreach (var font in fontsManager.GetFonts())
{
    if (embeddedFontNames.Contains(font.FontName))
    {
        Console.WriteLine($"{font.FontName}: already embedded.");
        continue;
    }

    var hasAvailableData = false;
    var allAvailableStylesCanBeEmbedded = true;
    var previewPrintOnly = false;
    var requiresFullFont = false;

    foreach (var fontStyle in fontStyles)
    {
        var fontBytes = fontsManager.GetFontBytes(font, fontStyle);
        if (fontBytes == null)
        {
            Console.WriteLine($"{font.FontName} ({fontStyle}): font data is unavailable.");
            continue;
        }

        hasAvailableData = true;
        var embeddingLevel = fontsManager.GetFontEmbeddingLevel(fontBytes, font.FontName);
        var usagePermission = GetUsagePermission(embeddingLevel);
        var noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
        var bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

        Console.WriteLine($"{font.FontName} ({fontStyle}): {embeddingLevel}.");
    }

    if (!hasAvailableData)
    {
        Console.WriteLine($"{font.FontName}: skipped because no requested style is available.");
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console.WriteLine($"{font.FontName}: skipped because at least one available style does not permit outline embedding.");
    }
    else if (previewPrintOnly)
    {
        Console.WriteLine($"{font.FontName}: skipped because this example produces an editable presentation.");
    }
    else
    {
        var rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
        embeddingPlan.Add((font, rule));
    }
}

foreach (var item in embeddingPlan)
{
    fontsManager.AddEmbeddedFont(item.Font, item.Rule);
}

presentation.Save("WithAuditedFonts.pptx", SaveFormat.Pptx);
```

此检查报告每个字体文件中编码的限制。它不授予许可证，也不证明您合法获取了该字体，亦不能替代在分发嵌入副本前检查字体许可协议的步骤。

## **添加嵌入字体**

使用 [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/) 嵌入字体。它的重载接受 [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/) 对象或包含字体数据的字节数组。[EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) 枚举控制包含哪些字符：

- [All](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) 嵌入字体中的所有字符。当接收者需要编辑演示文稿并输入新文本时使用此选项。
- [OnlyUsed](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) 只嵌入演示文稿中使用的字符，以减小文件大小。针对主要用于查看的最终演示文稿请选择此选项。

下面的示例使用 [GetFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) 检索 `Fonts.pptx` 中使用的字体，并嵌入尚未嵌入的字体。要添加的字体必须在运行代码的机器上可用。已有的嵌入字体保留其当前字符集。
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var allFonts = fontsManager.GetFonts();
var embeddedFonts = fontsManager.GetEmbeddedFonts();
var embeddedFontNames = embeddedFonts.Select(font => font.FontName);
var embeddedNames = new HashSet<string>(embeddedFontNames, StringComparer.OrdinalIgnoreCase);

foreach (var font in allFonts)
{
    if (!embeddedNames.Contains(font.FontName))
    {
        fontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
        embeddedNames.Add(font.FontName);
    }
}

presentation.Save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
```

## **压缩嵌入字体**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) 通过移除未使用的字符来减小嵌入字体数据。它作用于已经嵌入的字体，因此大小的缩减取决于演示文稿中未使用的字体数据量。

下面的示例压缩 `EmbeddedFonts.pptx` 中的字体，并将结果保存为单独的文件：
```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

如果接收者以后可能需要添加文本，请保留原始文件。压缩期间移除的字符将不再可从嵌入字体中获取，即使您最初嵌入了所有字符。

若希望在导出时让匹配的已注册字体优先，而不移除嵌入字体，请参阅 [优先使用已注册字体而不是嵌入字体](/slides/zh/net/font-selection-sequence/#prefer-registered-fonts-over-embedded-fonts)（.NET 26.11 或更高版本）。

## **常见问题**

**如何检查嵌入字体在渲染时是否仍会被替换？**

在渲染演示文稿的环境中调用 [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/)，以查看 Aspose.Slides 将替换哪些字体。同时检查 [字体替换](/slides/zh/net/font-substitution/) 设置和 [字体回退](/slides/zh/net/fallback-font/) 规则。Fallback 负责处理缺失字符，因此嵌入字体并不能解决该字体本身不包含的字符。

**我应该嵌入常用字体如 Arial 和 Calibri 吗？**

根据目标环境决定。如果所需字体在每台打开或渲染演示文稿的机器上都可用，嵌入它们可能会增加不必要的文件大小。如果接收者或服务器可能缺少这些字体，嵌入它们可以帮助保留预期的外观，前提是其许可证允许。