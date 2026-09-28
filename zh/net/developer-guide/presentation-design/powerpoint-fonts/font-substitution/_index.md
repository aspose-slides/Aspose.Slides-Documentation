---
title: 在 .NET 中配置演示文稿的字体替代
linktitle: 字体替代
type: docs
weight: 70
url: /zh/net/font-substitution/
keywords:
- 字体
- 替代字体
- 字体替代
- 替换字体
- 字体替换
- 替代规则
- 替换规则
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在渲染或转换 PowerPoint 和 OpenDocument 演示文稿时，配置 Aspose.Slides for .NET 的字体替代规则并检查被替代的字体。"
---
## **概述**

字体替代允许 Aspose.Slides 在呈现或转换演示文稿时使用可用的字体来代替无法访问的字体。此替代会影响渲染输出；但不会更改分配给演示文稿内容的字体。

您可以定义在特定字体不可用时使用的字体，并且可以检查 Aspose.Slides 在渲染期间将进行的替代。这有助于在安装的字体不同的环境之间保持输出一致。

## **获取字体替代**

使用 [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/zh/net/aspose.slides/ifontsmanager/getsubstitutions/) 方法确定在渲染演示文稿时将替代哪些字体。该方法返回标识原始字体名称和替代字体名称的 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh/net/aspose.slides/fontsubstitutioninfo/) 对象。

以下 C# 示例列出演示文稿的所有字体替代：

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **获取选定幻灯片的字体替代**

使用带有 `int[] slides` 参数的 [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/zh/net/aspose.slides/ifontsmanager/getsubstitutions/) 重载，仅检查渲染特定幻灯片所需的替代。这在以下情况下很有用：渲染或导出演示文稿的部分内容、增量检查大型演示文稿、定位依赖于不可用字体的幻灯片、为服务器或容器准备最小字体包，或在不处理无关幻灯片的情况下诊断渲染差异。

`slides` 数组使用基于 1 的幻灯片索引：`1` 标识第一张幻灯片。相比之下，[Presentation.Slides](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/slides/zh/) 集合的索引器是基于 0 的，因此同一张幻灯片应写作 `presentation.Slides[0]`。构建数组时请牢记此差异，以免出现越界错误。

通过 [Presentation.FontsManager](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/fontsmanager/) 属性调用该重载。它仅返回在渲染所选幻灯片时确定的替代。每个结果都是一个包含原始和替代字体名称的 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh/net/aspose.slides/fontsubstitutioninfo/) 对象。结果反映当前的字体环境以及 [externally loaded fonts](/slides/zh/net/custom-font/)。存储在 [IFontSubstRuleCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/ifontsubstrulecollection/) 中的替代规则会更改渲染输出，但不会在结果中体现。

同一替代可能被多个选定幻灯片所需。在创建字体清单或预检报告时请去重。以下示例报告每个返回的替代，然后创建唯一字体映射的排序列表：

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

[IFontsManager](https://reference.aspose.com/slides/zh/net/aspose.slides/ifontsmanager/) 接口提供这两个重载。根据渲染操作的范围选择使用：

| 重载 | 适用场景 |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/zh/net/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | 需要获取整个演示文稿的替代字体时。 |
| [GetSubstitutions](https://reference.aspose.com/slides/zh/net/aspose.slides/ifontsmanager/getsubstitutions/) with `int[] slides` | 需要获取选定范围、增量检查或部分导出的替代字体时。 |

## **设置字体替代规则**

指定当源字体不可用时 Aspose.Slides 应使用的字体：

1. 加载演示文稿。  
2. 为源字体和替代字体创建字体定义。  
3. 使用 [WhenInaccessible](https://reference.aspose.com/slides/zh/net/aspose.slides/fontsubstcondition/) 条件创建一个 [FontSubstRule](https://reference.aspose.com/slides/zh/net/aspose.slides/fontsubstrule/)。  
4. 将规则添加到 [FontSubstRuleCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/fontsubstrulecollection/)。  
5. 将集合分配给 [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/zh/net/aspose.slides/fontsmanager/fontsubstrulelist/) 属性。  
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
如需对整个演示文稿使用的字体进行无条件更改，请参阅 [字体替换](/slides/zh/net/font-replacement/)。
{{% /alert %}}

## **数学公式字体的限制**

字体替代规则是渲染和转换期间使用的标准字体选择过程的一部分。它们在 Aspose.Slides 能够使用规则指定的可用字体替代不可访问的字体时，对普通文本有效。

Office Math 公式有额外要求。如果公式使用 **Cambria Math**，Aspose.Slides 可能需要该确切字体来计算和渲染公式布局。将其替代为其他数学字体（例如 **STIX Two Math**）的规则无法替代 **Cambria Math**，渲染仍可能报告需要 **Cambria Math**。

要渲染或转换此类演示文稿，请确保 **Cambria Math** 对 Aspose.Slides 可用。可在操作系统中安装，或作为 [external font](/slides/zh/net/custom-font/) 加载。

此限制仅适用于公式布局。上述替代规则仍然适用于常规演示文稿文本。

## **常见问题**

**字体替换与字体替代有什么区别？**  
[Font replacement](/slides/zh/net/font-replacement/) 有意识地在整个演示文稿中将一种字体更改为另一种字体。字体替代在满足配置条件（例如原始字体不可用）时为渲染输出选择字体。

**替代规则何时生效？**  
规则参与渲染和转换期间的 [font selection sequence](/slides/zh/net/font-selection-sequence/)。使用 `WhenInaccessible` 时，仅在 Aspose.Slides 无法访问源字体时使用该规则。

**当缺少字体且未配置替代规则会怎样？**  
Aspose.Slides 将根据其字体选择过程选择最接近的可用字体。结果取决于运行时环境中可用的字体。

**我可以加载外部字体以避免替代吗？**  
可以。您可以 [load external fonts](/slides/zh/net/custom-font/)，使 Aspose.Slides 在渲染和转换期间使用它们。

**Aspose 会随库分发字体吗？**  
不会。您需自行提供字体并遵守其许可证。

**替代结果在 Windows、Linux 和 macOS 之间会不同吗？**  
会。不同操作系统安装的字体及搜索路径不同，某台机器上可用的字体在另一台机器上可能需要替代。

**如何在批量转换中保持字体选择的一致性？**  
在每台机器或容器上使用相同的字体文件和版本，[load required external fonts](/slides/zh/net/custom-font/)，并在许可允许时 [embed fonts](/slides/zh/net/embedded-font/)。您还可以在导出前调用 [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/zh/net/aspose.slides/ifontsmanager/getsubstitutions/) 以识别意外的替代。