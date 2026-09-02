---
title: 在 .NET 中配置演示文稿的字体替换
linktitle: 字体替换
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
description: "在渲染或转换 PowerPoint 和 OpenDocument 演示文稿时，为 .NET 的 Aspose.Slides 配置字体替换规则并检查被替换的字体。"
---
## **概述**

字体替换允许 Aspose.Slides 在呈现或转换演示文稿时使用可用的字体来代替无法访问的字体。替换仅影响渲染输出；它不会更改演示文稿内容中分配的字体。

您可以在特定字体不可用时定义要使用的字体，并检查 Aspose.Slides 在渲染期间将执行的替换。这有助于在不同已安装字体的环境中保持输出一致。

## **获取字体替换**

使用 [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/zh/net/aspose.slides/ifontsmanager/getsubstitutions/) 方法确定在渲染演示文稿时将会替换哪些字体。该方法返回标识原始字体和替换后字体名称的 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh/net/aspose.slides/fontsubstitutioninfo/) 对象。

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

使用带有 `int[] slides` 参数的 [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/zh/net/aspose.slides/ifontsmanager/getsubstitutions/) 重载，仅检查渲染特定幻灯片所需的替换。这在以下情形中很有用：渲染或导出演示文稿的一部分、增量检查大型演示文稿、定位依赖不可用字体的幻灯片、为服务器或容器准备最小字体包，或在不处理无关幻灯片的情况下诊断渲染差异。

`slides` 数组使用基于 1 的幻灯片索引：`1` 表示第一张幻灯片。相比之下，[Presentation.Slides](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/slides/zh/) 集合的索引器是基于 0 的，因此同一张幻灯片应通过 `presentation.Slides[0]` 访问。构建数组时请记住此差异，以避免出现 off‑by‑one 错误。

通过 [Presentation.FontsManager](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/fontsmanager/) 属性调用该重载。它仅返回在渲染所选幻灯片时确定的替换。每个结果都是包含原始字体和替换后字体名称的 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh/net/aspose.slides/fontsubstitutioninfo/) 对象。结果反映当前的字体环境、已配置的回退规则、存储在 [IFontSubstRuleCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/ifontsubstrulecollection/) 中的替换规则，以及 [externally loaded fonts](/slides/zh/net/custom-font/)。

同一替换可能被多个选定幻灯片需要。创建字体清单或预检报告时请去重。以下示例报告每个返回的替换，然后生成唯一字体映射的排序列表：

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

[IFontsManager](https://reference.aspose.com/slides/zh/net/aspose.slides/ifontsmanager/) 接口提供两种重载。根据渲染操作的范围选择使用哪一种：

| 重载 | 适用场景 |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/zh/net/aspose.slides/ifontsmanager/getsubstitutions/)（无参数） | 需要获取整个演示文稿的替换。 |
| [GetSubstitutions](https://reference.aspose.com/slides/zh/net/aspose.slides/ifontsmanager/getsubstitutions/)（`int[] slides`） | 需要获取选定范围、增量检查或部分导出的替换。 |

## **设置字体替换规则**

指定当源字体不可用时 Aspose.Slides 应使用的字体：

1. 加载演示文稿。  
2. 为源字体和替代字体创建字体定义。  
3. 使用 [WhenInaccessible](https://reference.aspose.com/slides/zh/net/aspose.slides/fontsubstcondition/) 条件创建一个 [FontSubstRule](https://reference.aspose.com/slides/zh/net/aspose.slides/fontsubstrule/)。  
4. 将规则添加到 [FontSubstRuleCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/fontsubstrulecollection/)。  
5. 将集合分配给 [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/zh/net/aspose.slides/fontsmanager/fontsubstrulelist/) 属性。  
6. 渲染或转换演示文稿。

以下 C# 示例在 `SomeRareFont` 不可用时用 `Arial` 替代，并渲染第一张幻灯片以验证结果。替代字体必须对 Aspose.Slides 可用。

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
如需对整个演示文稿使用的字体进行无条件更改，请参阅 [Font Replacement](/slides/zh/net/font-replacement/)。
{{% /alert %}}

## **数学公式字体的限制**

字体替换规则是渲染和转换期间标准字体选择过程的一部分。它们适用于普通文本，当 Aspose.Slides 能够使用规则指定的可用字体替换不可访问的字体时即可生效。

Office Math 公式有额外的要求。如果公式使用 **Cambria Math**，Aspose.Slides 可能需要该特定字体来计算和渲染公式布局。将其他数学字体（如 **STIX Two Math**）作为替代的规则无法替换 **Cambria Math**，渲染仍可能报告需要 **Cambria Math**。

要渲染或转换此类演示文稿，请确保 **Cambria Math** 对 Aspose.Slides 可用。可以在操作系统中安装它，或将其作为 [external font](/slides/zh/net/custom-font/) 加载。

此限制仅适用于公式布局。上述替换规则仍然适用于普通演示文稿文本。

## **常见问题**

**字体替换和字体替换有什么区别？**  
[Font replacement](/slides/zh/net/font-replacement/) 有意在整个演示文稿中将一种字体更改为另一种。字体替换则在满足配置条件（例如原始字体不可用）时，为渲染输出选择替代字体。

**替换规则何时生效？**  
规则参与渲染和转换期间的 [font selection sequence](/slides/zh/net/font-selection-sequence/)。使用 `WhenInaccessible` 时，仅在 Aspose.Slides 无法访问源字体时才使用该规则。

**如果字体缺失且未配置替换规则会怎样？**  
Aspose.Slides 将根据其字体选择过程选择最接近的可用字体。结果取决于运行时环境中可用的字体。

**我可以加载外部字体以避免替换吗？**  
可以。您可以 [load external fonts](/slides/zh/net/custom-font/)，让 Aspose.Slides 在渲染和转换期间使用它们。

**Aspose 是否随库分发字体？**  
不。您需自行提供字体并遵守其许可。

**替换结果在 Windows、Linux 和 macOS 之间会不同吗？**  
会。不同操作系统的已安装字体和字体搜索位置各不相同，某台机器可用的字体在另一台机器上可能需要替换。

**如何在批量转换中保持字体选择的一致性？**  
在每台机器或容器上使用相同的字体文件和版本，[load required external fonts](/slides/zh/net/custom-font/)，并在许可允许的情况下 [embed fonts](/slides/zh/net/embedded-font/)。您还可以在导出前调用 [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/zh/net/aspose.slides/ifontsmanager/getsubstitutions/) 以识别意外的替换。