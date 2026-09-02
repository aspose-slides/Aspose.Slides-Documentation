---
title: 在 Android 上配置演示文稿的字体替代
linktitle: 字体替代
type: docs
weight: 70
url: /zh/androidjava/font-substitution/
keywords:
- 字体
- 替代字体
- 字体替代
- 更换字体
- 字体替换
- 替代规则
- 替换规则
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "在使用 Java 渲染或转换演示文稿时，配置 Aspose.Slides for Android 的字体替代规则并检查被替代的字体。"
---
## **概述**

字体替代允许 Aspose.Slides 在渲染或转换演示文稿时使用可用字体来替代无法访问的字体。替代仅影响渲染输出；它不会更改演示文稿内容中分配的字体。

您可以定义在特定字体不可用时使用的字体，并且可以检查 Aspose.Slides 在渲染期间将进行的替代。这有助于在不同 Android 设备和可用字体环境中保持输出的一致性。

## **获取字体替代**

使用 [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) 方法来确定在渲染演示文稿时将被替代的字体。该方法返回标识原始字体名称和替代字体名称的 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/fontsubstitutioninfo/) 对象。

下面的 Java 示例列出演示文稿的所有字体替代：

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

使用带有 `int[] slides` 参数的 [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) 重载来仅检查渲染特定幻灯片所需的替代。当您只渲染或导出演示文稿的一部分、增量检查大型演示文稿、定位依赖不可用字体的幻灯片、为 Android 应用准备最小字体包，或在不处理无关幻灯片的情况下诊断渲染差异时，这非常有用。

`slides` 数组包含基于 1 的幻灯片索引：`1` 标识第一张幻灯片。相对地，[Presentation.getSlides](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#getSlides--) 集合访问器使用基于 0 的索引，因此同一幻灯片应通过 `presentation.getSlides().get_Item(0)` 访问。构建数组时请记住此差异，以避免 off-by-one 错误。

通过 [Presentation.getFontsManager](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#getFontsManager--) 方法调用该重载。它仅返回在渲染所选幻灯片时确定的替代。每个结果都是包含原始字体名称和替代字体名称的 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/fontsubstitutioninfo/) 对象。结果反映当前的字体环境、已配置的后备规则、存储在 [IFontSubstRuleCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifontsubstrulecollection/) 中的替代规则，以及[外部加载的字体](/slides/zh/androidjava/custom-font/)。

同一替代可能被多个所选幻灯片需要。在创建字体清单或预检查报告时请去重结果。以下示例报告每个返回的替代，然后创建唯一字体映射的排序列表：

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

[IFontsManager](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifontsmanager/) 接口提供这两种重载。根据渲染操作的范围选择使用哪一种：

| 重载 | 使用场景 |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) 无参数 | 需要为整个演示文稿获取替代。 |
| [getSubstitutions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) 带 `int[] slides` | 需要为选定范围、增量检查或部分导出获取替代。 |

## **设置字体替代规则**

要指定当源字体不可用时 Aspose.Slides 应使用的字体：

1. 加载演示文稿。  
2. 为源字体和替代字体创建字体定义。  
3. 使用 [WhenInaccessible](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/fontsubstcondition/) 条件创建一个 [FontSubstRule](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/fontsubstrule/)。  
4. 将规则添加到 [FontSubstRuleCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/fontsubstrulecollection/)。  
5. 使用 [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) 方法分配该集合。  
6. 渲染或转换演示文稿。

下面的 Java 示例在 `SomeRareFont` 不可用时用 `Arial` 替代 `SomeRareFont`，随后渲染第一页以验证结果。替代字体必须可供 Aspose.Slides 使用。

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
要对整个演示文稿使用的字体进行无条件更改，请参阅 [Font Replacement](/slides/zh/androidjava/font-replacement/)。
{{% /alert %}}

## **数学公式字体的限制**

字体替代规则是渲染和转换期间使用的标准字体选择过程的一部分。当 Aspose.Slides 能够用规则指定的可用字体替代不可访问的字体时，它们适用于普通文本。

Office Math 公式有额外的要求。如果公式使用 **Cambria Math**，Aspose.Slides 可能需要该精确字体来计算和渲染公式布局。替代为其他数学字体（例如 **STIX Two Math**）的规则无法替代 **Cambria Math**，渲染仍可能报告需要 **Cambria Math**。

要渲染或转换此类演示文稿，请确保 **Cambria Math** 对 Aspose.Slides 可用。将其作为[外部字体](/slides/zh/androidjava/custom-font/)加载，以便应用在渲染和转换期间使用。

此限制仅适用于公式布局。上述替代规则仍适用于演示文稿的普通文本。

## **常见问题**

**字体替换和字体替代之间有什么区别？**

[Font replacement](/slides/zh/androidjava/font-replacement/) 有意在整个演示文稿中将一种字体更改为另一种字体。字体替代在满足配置条件（例如原始字体不可用）时为渲染输出选择字体。

**替代规则何时应用？**

这些规则参与渲染和转换期间的[字体选择序列](/slides/zh/androidjava/font-selection-sequence/)。使用 `WhenInaccessible` 时，规则仅在 Aspose.Slides 无法访问源字体时使用。

**当字体缺失且未配置替代规则会怎样？**

Aspose.Slides 将根据其字体选择过程选择最接近的可用字体。结果取决于运行时环境中可用的字体。

**我可以加载外部字体以避免替代吗？**

可以。您可以[加载外部字体](/slides/zh/androidjava/custom-font/)，让 Aspose.Slides 在渲染和转换期间使用它们。

**Aspose 会随库分发字体吗？**

不会。您需自行提供字体并遵守其许可证。

**不同 Android 设备之间的替代结果会不同吗？**

会。不同 Android 版本、设备和供应商提供的系统字体可能不同，某一环境可用的字体在另一环境可能需要替代。

**如何在 Android 设备之间保持字体选择的一致性？**

将相同的必需字体文件随应用打包，[加载为外部字体](/slides/zh/androidjava/custom-font/)，并在许可允许的情况下[嵌入字体](/slides/zh/androidjava/embedded-font/)。还可以在导出前调用 [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) 以识别意外的替代。