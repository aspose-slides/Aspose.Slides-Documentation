---
title: 在 .NET 中管理脚本特定的主题字体
linktitle: 脚本特定主题字体
type: docs
weight: 15
url: /zh/net/script-specific-font-mappings/
keywords:
- 脚本特定字体
- 主题字体映射
- 多语言演示文稿
- 书写系统
- 西里尔字体
- 阿拉伯字体
- 日文字体
- 格鲁吉亚字体
- Thaana 字体
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 PowerPoint 主题中使用 Aspose.Slides for .NET 检查、添加、替换和删除脚本特定的字体映射。"
---
## **概述**

演示文稿主题可以为不同的书写系统选择不同的字体族。这使得仍使用主题字体的多语言文本能够在使用适合西里尔文、阿拉伯文、日文、格鲁吉亚文、Thaana 等脚本的字体的同时，保持统一的字体方案。

主题的[IFontScheme](https://reference.aspose.com/slides/zh/net/aspose.slides.theme/ifontscheme/)包含一个主要字体集合，通常用于标题，以及一个次要字体集合，通常用于正文文本。除了它们的拉丁和东亚字体属性外，这两个集合通过[IFonts](https://reference.aspose.com/slides/zh/net/aspose.slides/ifonts/)接口公开了从书写系统标签到字体族名称的映射。

本文展示如何检查和修改演示文稿母版主题中的这些映射，并验证更改在保存‑重新加载循环中是否仍然有效。

## **了解脚本标签**

脚本字体方法使用四字符 BCP 47 脚本子标签来标识书写系统。常见值包括：

| 脚本标签 | 书写系统 |
|---|---|
| `Cyrl` | Cyrillic |
| `Arab` | Arabic |
| `Hans` | Simplified Chinese |
| `Jpan` | Japanese |
| `Geor` | Georgian |
| `Thaa` | Thaana |

这些映射属于主题字体方案，而不是单个文本片段。一个演示文稿可以为主要和次要集合定义不同的映射，也可以对某些脚本省略映射。

## **访问并检查脚本字体映射**

使用[Presentation.MasterTheme](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/mastertheme/)访问演示文稿级别的主题。`FontScheme.Major` 和 `FontScheme.Minor` 属性返回两个 [IFonts](https://reference.aspose.com/slides/zh/net/aspose.slides/ifonts/) 集合。

调用 [IFonts.GetScriptFontMap](https://reference.aspose.com/slides/zh/net/aspose.slides/fonts/getscriptfontmap/) 可检索集合中的所有映射。若要查找单个书写系统，可使用其脚本标签调用 [IFonts.GetScriptFont](https://reference.aspose.com/slides/zh/net/aspose.slides/fonts/getscriptfont/)。当该集合未定义请求的映射时，`GetScriptFont` 返回 `null`。

## **修改映射并验证持久化**

使用 [IFonts.SetScriptFont](https://reference.aspose.com/slides/zh/net/aspose.slides/fonts/setscriptfont/) 创建映射或替换其当前字体族。使用 [IFonts.RemoveScriptFont](https://reference.aspose.com/slides/zh/net/aspose.slides/fonts/removescriptfont/) 删除映射。

下面的端到端示例读取所有现有的主要和次要映射，查找日文主要字体，修改西里尔文主要字体，删除 Thaana 次要映射，保存演示文稿并重新打开以验证两个更改。为了使删除步骤不依赖于初始主题，示例仅在未定义 Thaana 映射时才创建该映射。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

static void PrintScriptFontMap(string label, IFonts fonts)
{
    Console.WriteLine(label);
    foreach (var mapping in fonts.GetScriptFontMap())
    {
        Console.WriteLine($"  {mapping.Key}: {mapping.Value}");
    }
}

using var presentation = new Presentation();
var fontScheme = presentation.MasterTheme.FontScheme;
var majorFonts = fontScheme.Major;
var minorFonts = fontScheme.Minor;

PrintScriptFontMap("Existing major mappings:", majorFonts);
PrintScriptFontMap("Existing minor mappings:", minorFonts);

var japaneseFont = majorFonts.GetScriptFont("Jpan");
if (japaneseFont is null)
{
    Console.WriteLine("No major Japanese font is defined.");
}
else
{
    Console.WriteLine($"Major Japanese font: {japaneseFont}");
}

majorFonts.SetScriptFont("Cyrl", "Arial");

if (minorFonts.GetScriptFont("Thaa") is null)
{
    minorFonts.SetScriptFont("Thaa", "Arial");
}

minorFonts.RemoveScriptFont("Thaa");
presentation.Save("script-font-mappings.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("script-font-mappings.pptx");
var savedMajorFonts = savedPresentation.MasterTheme.FontScheme.Major;
var savedMinorFonts = savedPresentation.MasterTheme.FontScheme.Minor;
var savedCyrillicFont = savedMajorFonts.GetScriptFont("Cyrl");
var savedThaanaFont = savedMinorFonts.GetScriptFont("Thaa");

if (savedCyrillicFont == "Arial")
{
    Console.WriteLine("The Cyrillic mapping was preserved.");
}
else
{
    Console.WriteLine("The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont is null)
{
    Console.WriteLine("The Thaana mapping removal was preserved.");
}
else
{
    Console.WriteLine("The Thaana mapping still exists.");
}
```

验证使用与普通查找相同的 `null` 行为：删除并保存后，`GetScriptFont("Thaa")` 对次要集合返回 `null`。

## **区分主题映射与其他字体设置**

脚本特定的主题映射参与字体选择，但它们解决的问题不同于直接的文本格式化、替换和回退：

| 机制 | 目的 | 更改主题映射的影响 |
|---|---|---|
| 脚本特定的主题字体映射 | 为书写系统选择主要或次要主题字体。 | 仍然使用相应主题字体的文本可以解析为新的映射字体族。 |
| 显式分配给文本段的字体 | 在该段落上固定请求的字体族，而不是依赖主题。 | 由于直接格式设置覆盖了主题选择，该段落可能保持不变。 |
| 字体替换 | 当请求的字体不可用或出现替换规则时，替换该字体。 | 它在请求字体后生效；不会重新定义主题的脚本映射。 |
| 字体回退 | 提供所选字体不包含的字形，通常用于特定的 Unicode 范围。 | 它填补缺失的字形覆盖；不会更改已存储的主题映射。 |

有关后两种机制的更多信息，请参阅[字体替换](/slides/zh/net/font-substitution/)和[回退字体](/slides/zh/net/fallback-font/)。

在[Presentation.MasterTheme](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/mastertheme/)中更改映射仅影响其有效格式仍依赖该主题的内容。当可见结果未遵循演示文稿级别映射时，请检查母版、布局或幻灯片的主题覆盖，或查看是否使用了显式分配的字体。

## **使映射字体可用并验证结果**

脚本映射仅存储字体族名称；它不会安装或加载相应的字体文件。为实现一致的渲染和导出，必须在环境中安装每个映射字体，或通过自定义来源（如[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/zh/net/aspose.slides/fontsloader/loadexternalfonts/)或[LoadOptions.DocumentLevelFontSources](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/documentlevelfontsources/)）将字体提供给 Aspose.Slides。请参阅[自定义字体](/slides/zh/net/custom-font/)了解可用的加载选项。

验证已保存的映射只能确认主题定义已保留，不能证明字体可用、包含所有必需字形或产生预期布局。应对每个必需的书写系统渲染代表性文本为图像或 PDF，并检查输出。这可以在演示文稿分发前捕捉缺少字体、字形覆盖不足、回退行为和布局变化。请参阅[转换 PowerPoint 演示文稿](/slides/zh/net/convert-powerpoint/)获取渲染和导出示例。

## **常见问题**

**当脚本未映射时，`GetScriptFont` 返回什么？**

[IFonts.GetScriptFont](https://reference.aspose.com/slides/zh/net/aspose.slides/fonts/getscriptfont/) 在请求的脚本映射未在相应的主要或次要字体集合中定义时返回 `null`。

**当脚本已经存在时，`SetScriptFont` 会添加第二个映射吗？**

不会。[IFonts.SetScriptFont](https://reference.aspose.com/slides/zh/net/aspose.slides/fonts/setscriptfont/) 在缺失时创建映射，若已存在相同脚本标签则替换已映射的字体族。

**为什么更改主题映射后某些文本没有变化？**

文本可能显式分配了字体、通过覆盖继承了不同的主题，或在渲染时受到替换或回退的影响。演示文稿级别的脚本映射仅控制其有效格式仍引用该主题字体集合的文本。

**仅保存并重新打开是否足以验证多语言输出？**

不足。重新打开只能验证主题数据的持久化。还需渲染每个必需书写系统的代表性文本，以确认映射字体可用且包含必要字形。