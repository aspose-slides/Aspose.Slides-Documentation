---
title: 使用 JavaScript 在演示文稿中配置字体替代
linktitle: 字体替代
type: docs
weight: 70
url: /zh/nodejs-java/font-substitution/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "在渲染或转换 PowerPoint 和 OpenDocument 演示文稿时，通过 Java 为 Node.js 的 Aspose.Slides 配置字体替代规则并检查被替代的字体。"
---
## **概述**

字体替代使 Aspose.Slides 在渲染或转换演示文稿时能够使用可用的字体来替代无法访问的字体。替代仅影响渲染输出；它不会更改分配给演示文稿内容的字体。

您可以定义在特定字体不可用时使用的字体，并且可以检查 Aspose.Slides 在渲染期间将进行的替代。这有助于在安装了不同字体的环境中保持输出的一致性。

如果字体可用但没有专用的粗体字形，请参阅[处理没有专用粗体字形的字体](/slides/zh/nodejs-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface)。该章节解释了在 PDF 导出期间如何对受影响的文本进行光栅化以及对文本选择、搜索和缩放的影响。

## **获取字体替代**

使用[FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/)方法确定在渲染演示文稿时将替代哪些字体。该方法返回[FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/)对象，标识原始字体名称和替代字体名称。

以下 JavaScript 示例列出演示文稿的所有字体替代：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var substitutions = presentation.getFontsManager().getSubstitutions().iterator();
    while (substitutions.hasNext()) {
        var substitution = substitutions.next();
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **获取选定幻灯片的字体替代**

使用[FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/)重载并提供幻灯片索引数组，仅检查渲染特定幻灯片所需的替代。这在您只渲染或导出演示文稿的一部分、增量检查大型演示文稿、定位依赖不可用字体的幻灯片、为服务器或容器准备最小字体包，或在不处理无关幻灯片的情况下诊断渲染差异时非常有用。

该重载期望一个 Java 原始类型 `int[]`。使用 `java.newArray("int", [...])` 创建它；普通的 JavaScript 数组会转换为 `Integer[]`，与此重载不匹配。

数组包含基于 1 的幻灯片索引：`1` 标识第一张幻灯片。相反，[Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslides/) 集合访问器使用基于 0 的索引，因此相同的幻灯片应通过 `presentation.getSlides().get_Item(0)` 访问。构建数组时请记住此差异，以避免 off-by-one 错误。

通过[Presentation.getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getfontsmanager/)调用此重载。它仅返回在渲染选定幻灯片时确定的替代。每个结果都是一个包含原始和替代字体名称的 [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/) 对象。结果反映当前字体环境、配置的回退规则、存储在 [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/) 中的替代规则，以及[外部加载的字体](/slides/zh/nodejs-java/custom-font/)。

同一替代可能被多个选定幻灯片需求。创建字体清单或预检报告时请去重结果。以下示例报告每个返回的替代，然后创建唯一字体映射的排序列表：

```javascript
var aspose = aspose || {};
const java = require("java");
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var selectedSlides = java.newArray("int", [1, 3, 5]);
    var substitutions = [];
    var substitutionIterator = presentation.getFontsManager().getSubstitutions(selectedSlides).iterator();
    while (substitutionIterator.hasNext()) {
        substitutions.push(substitutionIterator.next());
    }

    console.log("Substitutions for the selected slides:");
    substitutions.forEach(function (substitution) {
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    });

    var preflightEntries = substitutions.map(function (substitution) {
        return substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
    });
    var sortedPreflightEntries = Array.from(new Set(preflightEntries)).sort(function (first, second) {
        return first.localeCompare(second, undefined, { sensitivity: "base" });
    });

    console.log("Deduplicated font preflight report:");
    sortedPreflightEntries.forEach(function (entry) {
        console.log(entry);
    });
} finally {
    presentation.dispose();
}
```

[FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/) 类提供这两种重载。根据渲染操作的范围选择使用：

| Overload | Use it when |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) with no arguments | 您需要整个演示文稿的替代。 |
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) with a Java `int[]` of slide indexes | 您需要选定范围、增量检查或部分导出的替代。 |

## **设置字体替代规则**

指定当源字体不可用时 Aspose.Slides 应使用的字体：

1. 加载演示文稿。
2. 为源字体和替代字体创建字体定义。
3. 使用[WhenInaccessible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstcondition/)条件创建一个 [FontSubstRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrule/)。
4. 将规则添加到 [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/)。
5. 通过调用 [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/) 方法分配该集合。
6. 渲染或转换演示文稿。

以下 JavaScript 示例在 `SomeRareFont` 不可用时将 `Arial` 替代为 `SomeRareFont`，随后渲染第一张幻灯片以验证结果。替代字体必须对 Aspose.Slides 可用。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    var substituteFont = new aspose.slides.FontData("Arial");
    var substitutionRule = new aspose.slides.FontSubstRule(sourceFont, substituteFont, aspose.slides.FontSubstCondition.WhenInaccessible);

    var substitutionRules = new aspose.slides.FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    var image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0);
    try {
        image.save("slide.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
如需对整个演示文稿使用的字体进行无条件更改，请参阅[字体替换](/slides/zh/nodejs-java/font-replacement/)。
{{% /alert %}}

## **数学公式字体的限制**

字体替代规则是渲染和转换期间标准字体选择过程的一部分。它们适用于普通文本，当 Aspose.Slides 能够用规则指定的可用字体替代不可访问的字体时即可工作。

Office Math 公式有额外要求。如果公式使用 **Cambria Math**，Aspose.Slides 可能需要该精确字体来计算和渲染公式布局。替代为其他数学字体（如 **STIX Two Math**）的规则不能取代 **Cambria Math**，渲染仍可能报告需要 **Cambria Math**。

要渲染或转换此类演示文稿，请确保 **Cambria Math** 对 Aspose.Slides 可用。将其安装在操作系统中或作为[外部字体](/slides/zh/nodejs-java/custom-font/)加载。

此限制仅适用于公式布局。上述替代规则仍适用于普通演示文稿文本。

## **常见问题**

**字体替换和字体替代之间有什么区别？**  
[字体替换](/slides/zh/nodejs-java/font-replacement/) 有意在整个演示文稿中将一种字体更改为另一种字体。字体替代在满足配置条件（例如原始字体不可用）时为渲染输出选择字体。

**替代规则何时应用？**  
这些规则参与渲染和转换期间的[字体选择顺序](/slides/zh/nodejs-java/font-selection-sequence/)。使用 `WhenInaccessible` 时，规则仅在 Aspose.Slides 无法访问源字体时使用。

**当字体缺失且未配置替代规则会怎样？**  
Aspose.Slides 将根据其字体选择过程选择最接近的可用字体。结果取决于运行时环境中可用的字体。

**我可以加载外部字体以避免替代吗？**  
可以。您可以[加载外部字体](/slides/zh/nodejs-java/custom-font/)，让 Aspose.Slides 在渲染和转换期间使用它们。

**Aspose 是否随库分发字体？**  
不。您需要自行提供字体并遵守其许可证。

**替代结果在 Windows、Linux 和 macOS 之间会不同吗？**  
会。不同操作系统的已安装字体和字体搜索位置不同，某台机器可用的字体在另一台机器上可能需要替代。

**如何在批量转换中保持字体选择的一致性？**  
在每台机器或容器上使用相同的字体文件和版本，[加载所需的外部字体](/slides/zh/nodejs-java/custom-font/)，并在许可证允许的情况下[嵌入字体](/slides/zh/nodejs-java/embedded-font/)。您还可以在导出前调用[FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/)以识别意外的替代。