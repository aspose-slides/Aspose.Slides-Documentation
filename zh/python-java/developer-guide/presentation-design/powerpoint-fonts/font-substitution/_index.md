---
title: 使用 Java 通过 Python 在演示文稿中配置字体替代
linktitle: 字体替代
type: docs
weight: 70
url: /zh/python-java/font-substitution/
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
- Python
- Java
- Aspose.Slides
description: "在使用 Python via Java 渲染或转换 PowerPoint 和 OpenDocument 演示文稿时，配置 Aspose.Slides 的字体替代规则并检查被替代的字体。"
---
## **概述**

字体替代允许 Aspose.Slides 在渲染或转换演示文稿时使用可用字体来代替无法访问的字体。替代会影响渲染输出；它不会更改分配给演示文稿内容的字体。

您可以定义在特定字体不可用时使用的字体，并且可以检查 Aspose.Slides 在渲染期间将进行的替代操作。这有助于在安装的字体不同的环境中保持输出的一致性。

## **获取字体替代**

使用 [FontsManager.getSubstitutions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/#getSubstitutions) 方法确定在渲染演示文稿时会被替代的字体。该方法返回标识原始字体名称和替代字体名称的 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsubstitutioninfo/) 对象。

以下 Python 示例列出演示文稿的所有字体替代：

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

## **获取所选幻灯片的字体替代**

使用带有 Java 整数数组参数的 [FontsManager.getSubstitutions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/#getSubstitutions) 重载，仅检查渲染特定幻灯片所需的替代。这在以下场景中很有用：渲染或导出演示文稿的部分内容、增量检查大型演示文稿、定位依赖不可用字体的幻灯片、为服务器或容器准备最小字体包，或在不处理无关幻灯片的情况下诊断渲染差异。

`slides` 数组使用一基索引：`1` 表示第一张幻灯片。相比之下，[Presentation.getSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getSlides) 集合访问器使用零基索引，同一幻灯片应通过 `presentation.getSlides().get_Item(0)` 访问。构建数组时请牢记此差异，以避免 off‑by‑one 错误。

通过 [Presentation.getFontsManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getFontsManager) 方法调用该重载。它仅返回在渲染所选幻灯片时确定的替代。每个结果都是包含原始和替代字体名称的 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsubstitutioninfo/) 对象。结果反映当前的字体环境、配置的回退规则、存储在 [FontSubstRuleCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsubstrulecollection/) 中的替代规则以及 [外部加载的字体](/slides/zh/python-java/custom-font/)。

同一替代可能由多个所选幻灯片需要。在创建字体清单或预检报告时请对结果去重。以下示例报告每个返回的替代，然后创建唯一字体映射的排序列表：

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

[FontsManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/) 类提供这两个重载。根据渲染操作的范围选择使用：

| 重载 | 使用场景 |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/#getSubstitutions) with no arguments | 需要整个演示文稿的替代。 |
| [getSubstitutions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/#getSubstitutions) with a Java integer array | 需要选定范围、增量检查或部分导出的替代。 |

## **设置字体替代规则**

指定当源字体不可用时 Aspose.Slides 应使用的替代字体：

1. 加载演示文稿。  
2. 为源字体和替代字体创建字体定义。  
3. 使用 [WhenInaccessible](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible) 条件创建一个 [FontSubstRule](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsubstrule/)。  
4. 将规则添加到 [FontSubstRuleCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsubstrulecollection/)。  
5. 使用 [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList) 方法分配该集合。  
6. 渲染或转换演示文稿。

以下 Python 示例在 `SomeRareFont` 不可用时将 `Arial` 用作 `SomeRareFont` 的替代，然后渲染第一张幻灯片以验证结果。替代字体必须对 Aspose.Slides 可用。

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
如需对整个演示文稿使用的字体进行无条件更改，请参阅 [Font Replacement](/slides/zh/python-java/font-replacement/)。
{{% /alert %}}

## **数学公式字体的限制**

字体替代规则是渲染和转换期间使用的标准字体选择流程的一部分。它们在 Aspose.Slides 能够用规则指定的可用字体替换不可访问字体时，对普通文本有效。

Office Math 公式还有额外要求。如果公式使用 **Cambria Math**，Aspose.Slides 可能需要该精确字体来计算和渲染公式布局。将另一种数学字体（如 **STIX Two Math**）作为替代的规则无法替代 **Cambria Math**，渲染时仍可能报告需要 **Cambria Math**。

要渲染或转换此类演示文稿，请确保 **Cambria Math** 对 Aspose.Slides 可用。可在操作系统中安装或作为 [外部字体](/slides/zh/python-java/custom-font/) 加载。

此限制仅适用于公式布局。上述替代规则仍适用于常规演示文稿文本。

## **常见问题**

**字体替换和字体替代有什么区别？**  
[Font replacement](/slides/zh/python-java/font-replacement/) 会在整个演示文稿中有意将一种字体更改为另一种字体。字体替代则在满足配置条件（例如原始字体不可用）时为渲染输出选择替代字体。

**替代规则何时应用？**  
规则参与渲染和转换过程中的 [font selection sequence](/slides/zh/python-java/font-selection-sequence/)。使用 `WhenInaccessible` 时，只有当 Aspose.Slides 无法访问源字体时才会使用该规则。

**当缺少字体且未配置替代规则会发生什么？**  
Aspose.Slides 会根据其字体选择流程选择最接近的可用字体。结果取决于运行时环境中可用的字体。

**我可以加载外部字体以避免替代吗？**  
可以。您可以 [load external fonts](/slides/zh/python-java/custom-font/) 让 Aspose.Slides 在渲染和转换期间使用它们。

**Aspose 是否随库分发字体？**  
不。字体及其许可证的提供由您自行负责。

**替代结果在 Windows、Linux 和 macOS 之间会不同吗？**  
会。不同操作系统的已安装字体和字体搜索位置不同，某台机器上可用的字体在另一台机器上可能需要替代。

**如何在批量转换中保持字体选择一致？**  
在每台机器或容器上使用相同的字体文件和版本，[load required external fonts](/slides/zh/python-java/custom-font/)，并在许可证允许的情况下 [embed fonts](/slides/zh/python-java/embedded-font/)。您还可以在导出前调用 [FontsManager.getSubstitutions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/#getSubstitutions) 以识别意外的替代。