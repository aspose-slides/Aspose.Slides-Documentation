---
title: 使用 JavaScript 在演示文稿中配置字体替换
linktitle: 字体替换
type: docs
weight: 70
url: /zh/nodejs-java/font-substitution/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "在使用 Java 渲染或转换 PowerPoint 和 OpenDocument 演示文稿时，通过 Node.js 的 Aspose.Slides 配置字体替换规则并检查被替代的字体。"
---
## **概述**

字体替换允许 Aspose.Slides 在呈现或转换演示文稿时使用可用的字体来替代无法访问的字体。替换仅影响渲染输出；它不会更改演示文稿内容所分配的字体。

您可以在特定字体不可用时定义要使用的字体，并且可以检查 Aspose.Slides 在渲染期间将进行的替换。这有助于在安装了不同字体的环境之间保持输出的一致性。

## **获取字体替换**

使用 [FontsManager.getSubstitutions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) 方法来确定在渲染演示文稿时会替换哪些字体。该方法返回 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsubstitutioninfo/) 对象，标识原始字体和替代字体的名称。

下面的 JavaScript 示例列出演示文稿的所有字体替换：

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

## **获取所选幻灯片的字体替换**

使用带有幻灯片索引数组的 [FontsManager.getSubstitutions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) 重载，仅检查渲染特定幻灯片所需的替换。这在以下场景中非常有用：渲染或导出演示文稿的部分内容、增量检查大型演示文稿、定位依赖不可用字体的幻灯片、为服务器或容器准备最小字体包，或在不处理无关幻灯片的情况下诊断渲染差异。

该重载期望一个 Java 原始 `int[]`。使用 `java.newArray("int", […])` 创建；普通的 JavaScript 数组会被转换为 `Integer[]`，与此重载不匹配。

数组使用基于 1 的幻灯片索引：`1` 标识第一张幻灯片。相比之下，[Presentation.getSlides](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/getslides/) 集合访问器使用基于 0 的索引，因此同一幻灯片应通过 `presentation.getSlides().get_Item(0)` 访问。在构建数组时请牢记此差异，以避免出现 off‑by‑one 错误。

通过 [Presentation.getFontsManager](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/getfontsmanager/) 调用该重载。它仅返回在渲染所选幻灯片时确定的替换。每个结果都是一个 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsubstitutioninfo/) 对象，包含原始字体和替代字体的名称。结果反映了当前的字体环境、已配置的回退规则、存储在 [FontSubstRuleCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsubstrulecollection/) 中的替换规则以及 [外部加载的字体](/slides/zh/nodejs-java/custom-font/)。

同一替换可能被多个所选幻灯片所需。创建字体清单或预检报告时请对结果去重。下面的示例报告每个返回的替换，然后生成唯一字体映射的排序列表：

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

[FontsManager](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsmanager/) 类同时提供这两种重载。根据渲染操作的范围选择使用：

| 重载 | 使用情形 |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/)（无参数） | 需要整个演示文稿的替换。 |
| [getSubstitutions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/)（Java `int[]` 幻灯片索引） | 需要选定范围、增量检查或部分导出的替换。 |

## **设置字体替换规则**

指定当源字体不可用时 Aspose.Slides 应使用的替代字体：

1. 加载演示文稿。  
2. 为源字体和替代字体创建字体定义。  
3. 使用 [WhenInaccessible](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsubstcondition/) 条件创建一个 [FontSubstRule](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsubstrule/)。  
4. 将规则添加到 [FontSubstRuleCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsubstrulecollection/)。  
5. 通过 [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/) 方法分配该集合。  
6. 渲染或转换演示文稿。

下面的 JavaScript 示例在 `SomeRareFont` 不可用时将 `Arial` 替代为 `SomeRareFont`，然后渲染第一张幻灯片以验证结果。替代字体必须对 Aspose.Slides 可用。

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
如需无条件更改整个演示文稿中使用的字体，请参阅 [Font Replacement](/slides/zh/nodejs-java/font-replacement/)。
{{% /alert %}}

## **数学公式字体的限制**

字体替换规则是渲染和转换期间使用的标准字体选择过程的一部分。它们适用于普通文本，当 Aspose.Slides 能够使用规则指定的可用字体替代不可访问的字体时即可工作。

Office Math 公式还有额外的要求。如果公式使用 **Cambria Math**，Aspose.Slides 可能需要该确切字体来计算和渲染公式布局。将其他数学字体（例如 **STIX Two Math**）替代 **Cambria Math** 的规则无法满足此需求，渲染仍可能报告需要 **Cambria Math**。

要渲染或转换此类演示文稿，请确保 **Cambria Math** 对 Aspose.Slides 可用。可在操作系统中安装，或将其作为 [外部字体](/slides/zh/nodejs-java/custom-font/) 加载。

此限制仅适用于公式布局。上述替换规则仍适用于演示文稿的普通文本。

## **常见问题**

**字体替换（font replacement）和字体替代（font substitution）有什么区别？**

[Font replacement](/slides/zh/nodejs-java/font-replacement/) 会在整个演示文稿中有意地将一种字体更改为另一种字体。字体替代则在满足配置条件（例如原始字体不可用）时为渲染输出选择字体。

**替代规则何时生效？**

规则参与渲染和转换期间的 [font selection sequence](/slides/zh/nodejs-java/font-selection-sequence/)。使用 `WhenInaccessible` 时，规则仅在 Aspose.Slides 无法访问源字体时使用。

**当字体缺失且未配置替代规则会怎样？**

Aspose.Slides 将根据其字体选择过程选择最接近的可用字体。结果取决于运行时环境中可用的字体。

**我可以加载外部字体以避免替代吗？**

可以。您可以 [load external fonts](/slides/zh/nodejs-java/custom-font/)，让 Aspose.Slides 在渲染和转换时使用它们。

**Aspose 会随库分发字体吗？**

不会。您需自行提供字体并遵守其许可证。

**替代结果在 Windows、Linux 和 macOS 之间会不同吗？**

会。不同操作系统的已安装字体和字体搜索路径不同，某台机器可用的字体在另一台机器上可能需要替代。

**如何在批量转换中保持字体选择的一致性？**

在每台机器或容器上使用相同的字体文件和版本，[加载所需的外部字体](/slides/zh/nodejs-java/custom-font/)，并在许可证允许的情况下 [embed fonts](/slides/zh/nodejs-java/embedded-font/)。还可以在导出前调用 [FontsManager.getSubstitutions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) 以识别意外的替代。