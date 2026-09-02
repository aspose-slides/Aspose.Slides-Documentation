---
title: 使用 Java 在演示文稿中配置字体替换
linktitle: 字体替换
type: docs
weight: 70
url: /zh/java/font-substitution/
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
- Java
- Aspose.Slides
description: "在渲染或转换 PowerPoint 和 OpenDocument 演示文稿时，配置 Aspose.Slides for Java 的字体替换规则并检查被替换的字体。"
---
## **概述**

字体替换允许 Aspose.Slides 在渲染或转换演示文稿时使用可用的字体来替代无法访问的字体。替换仅影响渲染后的输出；它不会更改演示文稿内容中所分配的字体。

您可以定义在特定字体不可用时使用的字体，并且可以检查 Aspose.Slides 在渲染过程中将进行的替换。这有助于在安装了不同字体的环境之间保持输出的一致性。

## **获取字体替换**

使用 [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) 方法来确定在渲染演示文稿时将替换哪些字体。该方法返回标识原始字体名称和替代字体名称的 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh/java/com.aspose.slides/fontsubstitutioninfo/) 对象。

下面的 Java 示例列出了演示文稿的所有字体替换：

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

## **获取选定幻灯片的字体替换**

使用带有 `int[] slides` 参数的 [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) 重载，可以仅检查渲染特定幻灯片所需的替换。此功能在以下情况下非常有用：渲染或导出演示文稿的部分内容、逐步检查大型演示文稿、定位依赖不可用字体的幻灯片、为服务器或容器准备最小字体包，或在不处理无关幻灯片的情况下诊断渲染差异。

`slides` 数组使用1 基准的幻灯片索引：`1` 表示第一张幻灯片。相比之下，[Presentation.getSlides](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getSlides--) 集合访问器使用0 基准索引，因此同一幻灯片应写作 `presentation.getSlides().get_Item(0)`。在构建数组时请注意此差异，以避免因索引偏移导致的错误。

通过 [Presentation.getFontsManager](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getFontsManager--) 方法调用此重载。它仅返回在渲染选定幻灯片时确定的替换。每个结果都是包含原始字体名称和替代字体名称的 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh/java/com.aspose.slides/fontsubstitutioninfo/) 对象。该结果反映了当前的字体环境、已配置的回退规则、存储在 [IFontSubstRuleCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ifontsubstrulecollection/) 中的替换规则，以及 [外部加载的字体](/slides/zh/java/custom-font/)。

同一替换可能被多个选定幻灯片需求。创建字体清单或预检报告时请对结果进行去重。下面的示例报告每个返回的替换，然后创建唯一字体映射的排序列表：

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

接口 [IFontsManager](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ifontsmanager/) 提供这两种重载。根据渲染操作的范围选择相应的方式：

| 重载 | 使用场景 |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ifontsmanager/#getSubstitutions--)（无参数） | 需要对整个演示文稿进行字体替换。 |
| [getSubstitutions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---)（`int[] slides`） | 需要对选定范围、增量检查或部分导出进行字体替换。 |

## **设置字体替换规则**

指定当源字体不可用时 Aspose.Slides 应使用的字体：

1. 加载演示文稿。
2. 为源字体和替代字体创建字体定义。
3. 使用 [WhenInaccessible](https://reference.aspose.com/slides/zh/java/com.aspose.slides/fontsubstcondition/) 条件创建一个 [FontSubstRule](https://reference.aspose.com/slides/zh/java/com.aspose.slides/fontsubstrule/)。
4. 将该规则添加到 [FontSubstRuleCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/fontsubstrulecollection/) 中。
5. 通过调用 [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/zh/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) 方法来分配该集合。
6. 渲染或转换演示文稿。

下面的 Java 示例在 `SomeRareFont` 不可用时将其替换为 `Arial`，随后渲染第一张幻灯片以验证结果。替代字体必须对 Aspose.Slides 可用。

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

{{% alert color="info" title="注意" %}}
若要对整个演示文稿中使用的字体进行无条件更改，请参阅 [Font Replacement](/slides/zh/java/font-replacement/)。
{{% /alert %}}

## **数学公式字体的限制**

字体替换规则是渲染和转换过程中标准字体选择流程的一部分。当 Aspose.Slides 能够使用规则指定的可用字体替换不可访问的字体时，它们适用于普通文本。

Office Math 公式还有额外的要求。如果公式使用 **Cambria Math**，Aspose.Slides 可能需要该确切字体来计算并渲染公式布局。将另一种数学字体（例如 **STIX Two Math**）作为替代的规则无法替代 **Cambria Math**，渲染仍可能报告需要 **Cambria Math**。

要渲染或转换此类演示文稿，请确保 **Cambria Math** 对 Aspose.Slides 可用。可在操作系统中安装它或将其作为 [external font](/slides/zh/java/custom-font/) 加载。

此限制仅适用于公式布局。上述替换规则仍然适用于普通演示文稿文本。

## **常见问题**

**字体替换和字体替代之间有什么区别？**  
[Font replacement](/slides/zh/java/font-replacement/) 有意地在整个演示文稿中将一种字体更改为另一种字体。字体替代则在满足配置条件（例如原始字体不可用）时，为渲染输出选择一种字体。

**何时会应用替代规则？**  
这些规则在渲染和转换期间参与 [font selection sequence](/slides/zh/java/font-selection-sequence/)。使用 `WhenInaccessible` 时，规则仅在 Aspose.Slides 无法访问源字体时生效。

**当缺少字体且未配置替代规则时会怎样？**  
Aspose.Slides 会根据其字体选择流程选择最接近的可用字体。结果取决于运行时环境中可用的字体。

**我可以加载外部字体以避免替代吗？**  
可以。您可以 [load external fonts](/slides/zh/java/custom-font/) 让 Aspose.Slides 在渲染和转换期间使用它们。

**Aspose 是否随库一起分发字体？**  
不。您需自行提供字体并遵守其许可证。

**不同操作系统（Windows、Linux、macOS）之间的替代结果会不同吗？**  
会。不同操作系统的已安装字体和搜索路径各不相同，某台机器上可用的字体在另一台机器上可能需要替代。

**如何在批量转换中保持字体选择的一致性？**  
在每台机器或容器上使用相同的字体文件和版本，[load required external fonts](/slides/zh/java/custom-font/)，并在许可允许时 [embed fonts](/slides/zh/java/embedded-font/)。还可以在导出前调用 [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) 以识别意外的替代情况。