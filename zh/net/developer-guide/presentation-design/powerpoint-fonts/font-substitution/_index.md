---
title: "在 .NET 中配置演示文稿的字体替换"
linktitle: "字体替换"
type: docs
weight: 70
url: /zh/net/font-substitution/
keywords:
- 字体
- 替代字体
- 字体替换
- 替换字体
- 字体更换
- 替换规则
- 更换规则
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在渲染或转换 PowerPoint 和 OpenDocument 演示文稿时，配置 Aspose.Slides for .NET 的字体替换规则并检查被替换的字体。"
---
## **概述**

字体替换允许 Aspose.Slides 在渲染或转换演示文稿时使用可用字体来代替无法访问的字体。替换仅影响渲染后的输出；它不会更改演示文稿内容中分配的字体。

您可以定义在特定字体不可用时使用的字体，并且可以检查 Aspose.Slides 在渲染期间将进行的替换。这有助于在安装了不同字体的环境中保持输出一致。

如果字体可用但没有专用的粗体字形，请参阅[处理没有专用粗体字形的字体](/slides/zh/net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface)。本节解释了在 PDF 导出期间如何对受影响的文本进行光栅化以及对文本选择、搜索和缩放的影响。

## **获取字体替换**

使用[IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/)方法确定在渲染演示文稿时将会替换哪些字体。该方法返回标识原始字体名称和替代字体名称的[FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/)对象。

以下 C# 示例列出演示文稿的所有字体替换：

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **获取选定幻灯片的字体替换**

使用带有 `int[] slides` 参数的[IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/)重载来仅检查渲染特定幻灯片所需的替换。当您仅渲染或导出演示文稿的一部分、增量检查大型演示文稿、定位依赖不可用字体的幻灯片、为服务器或容器准备最小字体包，或在不处理无关幻灯片的情况下诊断渲染差异时，这非常有用。

`slides` 数组包含基于 1 的幻灯片索引：`1` 表示第一张幻灯片。相比之下，[Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/)集合的索引器是基于 0 的，因此同一张幻灯片应使用 `presentation.Slides[0]` 访问。构建数组时请记住此差异，以避免出现 off-by-one 错误。

通过[Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/)属性调用该重载。它仅返回在渲染所选幻灯片时确定的替换。每个结果都是包含原始字体名称和替代字体名称的[FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/)对象。结果反映当前的字体环境以及[外部加载的字体](/slides/zh/net/custom-font/)。存储在[IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/)中的替换规则会更改渲染输出，但不会体现在结果中。

同一替换可能被多个选定幻灯片所需要。在创建字体清单或预检报告时请对结果进行去重。以下示例报告每个返回的替换，然后创建唯一字体映射的排序列表：

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

int[] selectedSlides = { 1, 3, 5 };
var substitutions = presentation.FontsManager.GetSubstitutions(selectedSlides).ToList();

Console.WriteLine("Substitutions for the selected slides:");
foreach (var substitution in substitutions)
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

var preflightEntries = substitutions.Select(substitution => $"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
var uniquePreflightEntries = preflightEntries.Distinct(StringComparer.OrdinalIgnoreCase);
var sortedPreflightEntries = uniquePreflightEntries.OrderBy(entry => entry, StringComparer.OrdinalIgnoreCase).ToList();

Console.WriteLine("Deduplicated font preflight report:");
foreach (var entry in sortedPreflightEntries)
{
    Console.WriteLine(entry);
}
```

[IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/)接口提供这两种重载。根据渲染操作的范围选择相应的方式：

| 重载 | 适用场景 |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/)（无参数） | 需要整个演示文稿的替换。 |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/)（`int[] slides`） | 需要选定范围、增量检查或部分导出时。 |

## **设置字体替换规则**

指定当源字体不可用时 Aspose.Slides 应使用的替代字体：

1. 加载演示文稿。
2. 为源字体和替代字体创建字体定义。
3. 创建带有[WhenInaccessible](https://reference.aspose.com/slides/net/aspose.slides/fontsubstcondition/)条件的[FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/)。
4. 将规则添加到[FontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrulecollection/)。
5. 将集合分配给[FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/fontsubstrulelist/)属性。
6. 渲染或转换演示文稿。

以下 C# 示例在 `SomeRareFont` 不可用时用 `Arial` 替代它，然后渲染第一张幻灯片以验证结果。替代字体必须对 Aspose.Slides 可用。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("Fonts.pptx");

var sourceFont = new FontData("SomeRareFont");
var substituteFont = new FontData("Arial");
var substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

var substitutionRules = new FontSubstRuleCollection();
substitutionRules.Add(substitutionRule);
presentation.FontsManager.FontSubstRuleList = substitutionRules;

using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("slide.jpg", ImageFormat.Jpeg);
```

{{% alert color="info" title="Note" %}}
若要对整个演示文稿中使用的字体进行无条件更改，请参阅[字体替换](/slides/zh/net/font-replacement/)。
{{% /alert %}}

## **数学公式字体的限制**

字体替换规则是渲染和转换过程中使用的标准字体选择过程的一部分。它们适用于普通文本，当 Aspose.Slides 能够用规则指定的可用字体替代不可访问的字体时即可生效。

Office Math 公式还有额外要求。如果公式使用 **Cambria Math**，Aspose.Slides 可能需要该精确字体来计算和渲染公式布局。替代为其他数学字体（例如 **STIX Two Math**）的规则无法替代 **Cambria Math**，渲染仍可能报告需要 **Cambria Math**。

要渲染或转换此类演示文稿，请确保 **Cambria Math** 对 Aspose.Slides 可用。可以在操作系统中安装或作为[外部字体](/slides/zh/net/custom-font/)加载。

此限制仅适用于公式布局。上述替换规则仍然适用于普通演示文稿文本。

## **常见问题**

**字体替换和字体替换（replacement）有什么区别？**

[字体替换](/slides/zh/net/font-replacement/)是有意在整个演示文稿中将一种字体改为另一种字体。字体替换（substitution）在满足配置条件（例如原始字体不可用）时为渲染输出选择字体。

**替换规则何时生效？**

这些规则参与渲染和转换期间的[字体选择序列](/slides/zh/net/font-selection-sequence/)。使用 `WhenInaccessible` 时，规则仅在 Aspose.Slides 无法访问源字体时生效。

**当字体缺失且未配置替换规则会怎样？**

Aspose.Slides 会根据其字体选择流程选取最接近的可用字体。结果取决于运行时环境中可用的字体。

**我可以加载外部字体以避免替换吗？**

可以。您可以[加载外部字体](/slides/zh/net/custom-font/)，使 Aspose.Slides 在渲染和转换期间使用它们。

**Aspose 是否随库分发字体？**

不。您需自行提供字体并遵守其许可协议。

**替换结果会在 Windows、Linux 和 macOS 之间不同吗？**

会。不同操作系统的已安装字体和字体搜索位置不同，某台机器上可用的字体在另一台机器上可能需要替换。

**如何在批量转换中保持字体选择的一致性？**

在每台机器或容器上使用相同的字体文件和版本，[加载所需的外部字体](/slides/zh/net/custom-font/)，并在许可允许时[嵌入字体](/slides/zh/net/embedded-font/)。您还可以在导出前调用[IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/)以识别意外的替换。