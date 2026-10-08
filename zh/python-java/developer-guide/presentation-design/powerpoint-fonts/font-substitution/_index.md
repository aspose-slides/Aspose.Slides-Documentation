---
title: 使用 Python via Java 在演示文稿中配置字体替换
linktitle: 字体替换
type: docs
weight: 70
url: /zh/python-java/font-substitution/
keywords:
- 字体
- 替代字体
- 字体替换
- 更换字体
- 字体替代
- 替代规则
- 替换规则
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "在通过 Java 使用 Python 渲染或转换 PowerPoint 和 OpenDocument 演示文稿时，配置字体替代规则并检查 Aspose.Slides 中的已替代字体。"
---
## **概述**

字体替换允许 Aspose.Slides 在呈现或转换演示文稿时使用可用的字体来代替无法访问的字体。替换会影响渲染输出；但不会更改演示文稿内容中分配的字体。

您可以定义在特定字体不可用时使用的字体，并且可以检查 Aspose.Slides 在渲染过程中将进行的替换。这有助于在安装的字体不同的环境中保持输出的一致性。

如果字体可用但没有专用的粗体字形，请参阅[处理没有专用粗体字形的字体](/slides/zh/python-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface)。该部分解释了在 PDF 导出期间如何对受影响的文本进行光栅化以及对文本选择、搜索和缩放的影响。

## **获取字体替代**

使用 [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) 方法来确定在渲染演示文稿时会被替换的字体。该方法返回 [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/) 对象，标识原始字体名称和替代字体名称。

以下 Python 示例列出了演示文稿的所有字体替代：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    for substitution in presentation.getFontsManager().getSubstitutions():
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")
finally:
    presentation.dispose()
```

## **获取选定幻灯片的字体替代**

使用带有 Java 整数数组参数的 [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) 重载，仅检查渲染特定幻灯片所需的替代。这在您仅渲染或导出演示文稿的一部分、增量检查大型演示文稿、定位依赖不可用字体的幻灯片、为服务器或容器准备最小字体包，或在不处理无关幻灯片的情况下诊断渲染差异时非常有用。

`slides` 数组包含基于 1 的幻灯片索引：`1` 标识第一张幻灯片。相比之下，[Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) 集合访问器使用基于 0 的索引，因此同一张幻灯片应写作 `presentation.getSlides().get_Item(0)`。构建数组时请牢记此差异，以免出现 off‑by‑one 错误。

通过 [Presentation.getFontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getFontsManager) 方法调用该重载。它仅返回在渲染所选幻灯片时确定的替代。每个结果都是一个包含原始和替代字体名称的 [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/) 对象。结果反映当前的字体环境、已配置的回退规则、存储在 [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/) 中的替代规则，以及[外部加载的字体](/slides/zh/python-java/custom-font/)。

相同的替代可能被多个选定幻灯片所需要。在创建字体清单或预检报告时请对结果去重。以下示例报告每个返回的替代，然后创建唯一字体映射的排序列表：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    selected_slides = jpype.JArray(jpype.JInt)([1, 3, 5])
    substitutions = list(presentation.getFontsManager().getSubstitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")

    unique_entries = {}
    for substitution in substitutions:
        entry = f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}"
        unique_entries.setdefault(entry.casefold(), entry)

    print("Deduplicated font preflight report:")
    for key in sorted(unique_entries):
        print(unique_entries[key])
finally:
    presentation.dispose()
```

[FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/) 类提供这两种重载。请根据渲染操作的范围选择使用：

| 重载 | 使用场景 |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) with no arguments | 您需要对整个演示文稿进行替代。 |
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) with a Java integer array | 您需要对选定范围、增量检查或部分导出进行替代。 |

## **设置字体替代规则**

要指定在源字体不可用时 Aspose.Slides 应使用的字体：

1. 加载演示文稿。
2. 为源字体和替代字体创建字体定义。
3. 使用 [WhenInaccessible](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible) 条件创建一个 [FontSubstRule](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrule/)。
4. 将规则添加到 [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/)。
5. 使用 [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList) 方法分配该集合。
6. 渲染或转换演示文稿。

以下 Python 示例在 `SomeRareFont` 不可用时用 `Arial` 替代 `SomeRareFont`，随后渲染第一张幻灯片以验证结果。替代字体必须对 Aspose.Slides 可用。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, FontSubstCondition, FontSubstRule, FontSubstRuleCollection, ImageFormat, Presentation

presentation = Presentation("Fonts.pptx")
try:
    source_font = FontData("SomeRareFont")
    substitute_font = FontData("Arial")
    substitution_rule = FontSubstRule(source_font, substitute_font, FontSubstCondition.WhenInaccessible)

    substitution_rules = FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.getFontsManager().setFontSubstRuleList(substitution_rules)

    image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        image.save("slide.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
对于对整个演示文稿中使用的字体进行无条件更改，请参阅[字体替换](/slides/zh/python-java/font-replacement/)。
{{% /alert %}}

## **数学公式字体的限制**

字体替代规则是渲染和转换期间使用的标准字体选择过程的一部分。当 Aspose.Slides 能够使用规则指定的可用字体替代不可访问的字体时，它们适用于普通文本。

Office Math 公式还有额外的要求。如果公式使用 **Cambria Math**，Aspose.Slides 可能需要该确切字体来计算和渲染公式布局。替代另一种数学字体（例如 **STIX Two Math**）的规则不能取代 **Cambria Math**，渲染仍可能报告需要 **Cambria Math**。

要渲染或转换此类演示文稿，请确保 **Cambria Math** 对 Aspose.Slides 可用。可在操作系统中安装，或将其作为[外部字体](/slides/zh/python-java/custom-font/)加载。

此限制适用于公式布局。上述替代规则仍然适用于普通演示文稿文本。

## **常见问题**

**字体替换和字体替代之间有什么区别？**  
[字体替换](/slides/zh/python-java/font-replacement/) 有意在整个演示文稿中将一种字体更改为另一种字体。字体替代在满足配置的条件（例如原始字体不可用）时为渲染输出选择字体。

**何时应用替代规则？**  
这些规则在渲染和转换期间参与[字体选择序列](/slides/zh/python-java/font-selection-sequence/)。使用 `WhenInaccessible` 时，规则仅在 Aspose.Slides 无法访问源字体时生效。

**当字体缺失且未配置替代规则时会发生什么？**  
Aspose.Slides 会根据其字体选择流程选择最接近的可用字体。结果取决于运行时环境中可用的字体。

**我可以加载外部字体以避免替代吗？**  
可以。您可以[加载外部字体](/slides/zh/python-java/custom-font/)，以便 Aspose.Slides 在渲染和转换期间使用它们。

**Aspose 是否随库分发字体？**  
不。您需自行提供字体并遵守其许可证。

**替代结果在 Windows、Linux 和 macOS 之间会有所不同吗？**  
会。不同操作系统的已安装字体和字体搜索位置不同，因此在一台机器上可用的字体在另一台机器上可能需要替代。

**如何在批量转换中保持字体选择的一致性？**  
在每台机器或容器上使用相同的字体文件和版本，[加载所需的外部字体](/slides/zh/python-java/custom-font/)，并在许可允许的情况下[嵌入字体](/slides/zh/python-java/embedded-font/)。还可以在导出前调用 [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) 以识别意外的替代情况。