---
title: 使用 Java 配置演示文稿中的字体替换
linktitle: 字体替换
type: docs
weight: 70
url: /zh/java/font-substitution/
keywords:
- 字体
- 替代字体
- 字体替换
- 替换字体
- 字体替换
- 替代规则
- 替换规则
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中配置字体替换规则并在渲染或转换 PowerPoint 和 OpenDocument 演示文稿时检查被替代的字体。"
---
## **概述**

字体替换允许 Aspose.Slides 在渲染或转换演示文稿时使用可用的字体来代替无法访问的字体。替换仅影响渲染后的输出；它不会更改演示文稿内容中分配的字体。

您可以定义在特定字体不可用时使用的字体，并且可以检查 Aspose.Slides 在渲染期间将进行的替换。这有助于在安装的字体不同的环境中保持输出的一致性。

如果字体可用但没有专用的粗体字形，请参阅[处理没有专用粗体字形的字体](/slides/zh/java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface)。该章节解释了在 PDF 导出期间如何光栅化受影响的文本以及对文本选择、搜索和缩放的影响。

## **获取字体替代**

使用 [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) 方法来确定在渲染演示文稿时将被替换的字体。该方法返回 [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/) 对象，标识原始字体名称和替代字体名称。

下面的 Java 示例列出了演示文稿的所有字体替代：

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **获取所选幻灯片的字体替代**

使用带有 `int[] slides` 参数的 [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) 重载来仅检查渲染特定幻灯片所需的替代。这在以下情况下很有用：渲染或导出演示文稿的部分内容、逐步检查大型演示文稿、定位依赖不可用字体的幻灯片、为服务器或容器准备最小字体包，或在不处理无关幻灯片的情况下诊断渲染差异。

`slides` 数组使用基于 1 的幻灯片索引：`1` 表示第一张幻灯片。相比之下，[Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) 集合访问器使用基于 0 的索引，因此同一幻灯片应写作 `presentation.getSlides().get_Item(0)`。在构建数组时请牢记此差异，以避免因索引偏移导致的错误。

通过 [Presentation.getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getFontsManager--) 方法调用该重载。它仅返回在渲染所选幻灯片时确定的替代。每个结果都是一个包含原始字体和替代字体名称的 [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/) 对象。结果反映了当前的字体环境、配置的回退规则以及[外部加载的字体](/slides/zh/java/custom-font/)。存储在 [IFontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsubstrulecollection/) 中的替代规则会在渲染演示文稿时应用，但结果中不会列出它们；请检查输出文件中的字体。

同一替代可能被多个所选幻灯片需要。在创建字体清单或预检报告时，请对结果进行去重。下面的示例报告了每个返回的替代，然后创建唯一字体映射的排序列表：

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import java.util.TreeSet;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int[] selectedSlides = { 1, 3, 5 };
    List<FontSubstitutionInfo> substitutions = new ArrayList<>();
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions(selectedSlides)) {
        substitutions.add(substitution);
    }

    System.out.println("Substitutions for the selected slides:");
    for (FontSubstitutionInfo substitution : substitutions) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }

    Set<String> sortedPreflightEntries = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
    for (FontSubstitutionInfo substitution : substitutions) {
        String entry = substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
        sortedPreflightEntries.add(entry);
    }

    System.out.println("Deduplicated font preflight report:");
    for (String entry : sortedPreflightEntries) {
        System.out.println(entry);
    }
} finally {
    presentation.dispose();
}
```

[IFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/) 接口提供了这两种重载。根据渲染操作的范围选择合适的重载：

| 重载 | 何时使用 |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) with no arguments | 您需要整个演示文稿的字体替代。 |
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) with `int[] slides` | 您需要对选定范围、增量检查或部分导出进行字体替代。 |

## **设置字体替代规则**

要指定当源字体不可用时 Aspose.Slides 应使用的字体，请执行以下步骤：

1. 加载演示文稿。
2. 为源字体和替代字体创建字体定义。
3. 使用 [WhenInaccessible](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstcondition/) 条件创建一个 [FontSubstRule](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrule/)。
4. 将该规则添加到 [FontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrulecollection/)。
5. 使用 [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) 方法分配该集合。
6. 渲染或转换演示文稿。

下面的 Java 示例在 `SomeRareFont` 不可用时用 `Arial` 替代它，然后渲染第一张幻灯片以验证结果。替代字体必须对 Aspose.Slides 可用。

```java
import com.aspose.slides.FontData;
import com.aspose.slides.FontSubstCondition;
import com.aspose.slides.FontSubstRule;
import com.aspose.slides.FontSubstRuleCollection;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontSubstRule;
import com.aspose.slides.IFontSubstRuleCollection;
import com.aspose.slides.IImage;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData substituteFont = new FontData("Arial");
    IFontSubstRule substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection substitutionRules = new FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    IImage image = presentation.getSlides().get_Item(0).getImage(1f, 1f);
    try {
        image.save("slide.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
若要对整个演示文稿使用的字体进行无条件更改，请参阅[字体替换](/slides/zh/java/font-replacement/)。
{{% /alert %}}

## **数学公式字体的限制**

字体替代规则是渲染和转换期间使用的标准字体选择过程的一部分。当 Aspose.Slides 能够用规则指定的可用字体替换不可访问的字体时，它们适用于普通文本。

Office Math 公式还有额外的要求。如果公式使用 **Cambria Math**，Aspose.Slides 可能需要该确切字体来计算并渲染公式布局。将 **STIX Two Math** 等其他数学字体作为替代的规则无法替代 **Cambria Math**，渲染仍可能报告需要 **Cambria Math**。

要渲染或转换此类演示文稿，请确保 **Cambria Math** 对 Aspose.Slides 可用。可在操作系统中安装它，或将其作为[外部字体](/slides/zh/java/custom-font/) 加载。

此限制仅适用于公式布局。上述替代规则仍然适用于普通演示文稿文本。

## **常见问题**

**字体替换和字体替代有什么区别？**

[Font replacement](/slides/zh/java/font-replacement/) 有意在整个演示文稿中将一种字体更改为另一种字体。字体替代在满足配置的条件时（例如原始字体不可用）为渲染输出选择字体。

**何时应用替代规则？**

这些规则在渲染和转换期间参与[字体选择顺序](/slides/zh/java/font-selection-sequence/)。使用 `WhenInaccessible` 时，规则仅在 Aspose.Slides 无法访问源字体时生效。

**当字体缺失且未配置替代规则时会发生什么？**

Aspose.Slides 会根据其字体选择流程选择最接近的可用字体。结果取决于运行时环境中可用的字体。

**我能加载外部字体以避免替代吗？**

可以。您可以[加载外部字体](/slides/zh/java/custom-font/)，让 Aspose.Slides 在渲染和转换期间使用它们。

**Aspose 是否随库一起分发字体？**

不。字体需由您自行提供并遵守其许可证。

**替代结果在 Windows、Linux 和 macOS 之间会不同吗？**

会。不同操作系统的已安装字体和字体搜索路径不同，因此在一台机器上可用的字体可能在另一台机器上需要替代。

**如何在批量转换中保持字体选择的一致性？**

在每台机器或容器上使用相同的字体文件和版本，[加载所需的外部字体](/slides/zh/java/custom-font/)，并在许可允许的情况下[嵌入字体](/slides/zh/java/embedded-font/)。还可以在导出前调用 [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) 以识别意外的替代。