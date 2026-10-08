---
title: 配置 Python 中演示文稿的字体替代
linktitle: 字体替代
type: docs
weight: 70
url: /zh/python-net/font-substitution/
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
- Aspose.Slides
description: "在使用 .NET 的 Aspose.Slides for Python 渲染或转换 PowerPoint 和 OpenDocument 演示文稿时，配置字体替代规则并检查被替代的字体。"
---
## **概述**

字体替代使 Aspose.Slides 能在呈现或转换演示文稿时，用可用的字体替换无法访问的字体。替代仅影响渲染后的输出；它不会更改演示文稿内容中分配的字体。

您可以定义在特定字体不可用时使用的字体，并可以检查 Aspose.Slides 在渲染期间将执行的替代。这有助于在安装的字体不同的环境中保持输出的一致性。

如果字体可用但没有专用的粗体字形，请参阅[处理没有专用粗体字形的字体](/slides/zh/python-net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface)。该章节解释了在 PDF 导出期间如何对受影响的文本进行光栅化以及对文本选择、搜索和缩放的影响。

## **获取字体替代**

使用[FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/)方法确定在渲染演示文稿时将会替代哪些字体。该方法返回[FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/)对象，标识原始字体名称和替代字体名称。

下面的 Python 示例列出演示文稿的所有字体替代：

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **获取选定幻灯片的字体替代**

使用[FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/)并提供幻灯片索引列表，可仅检查渲染特定幻灯片所需的替代。当您只渲染或导出演示文稿的部分内容、增量检查大型演示文稿、定位依赖不可用字体的幻灯片、为服务器或容器准备最小字体包，或在不处理无关幻灯片的情况下诊断渲染差异时，这非常有用。

列表使用基于 1 的幻灯片索引：`1` 标识第一张幻灯片。相对地，[Presentation.slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/)集合是基于 0 的，因此相同的幻灯片应通过`presentation.slides[0]`访问。构建列表时请记住此差异，以避免出现 off‑by‑one 错误。

通过[Presentation.fonts_manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/)属性调用该方法。它仅返回在渲染选定幻灯片时确定的替代。每个结果都是一个[FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/)对象，包含原始和替代字体名称。结果反映当前的字体环境、已配置的回退规则、存储在[IFontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontsubstrulecollection/)中的替代规则以及[外部加载的字体](/slides/zh/python-net/custom-font/)。

同一替代可能被多个选定幻灯片需要。在创建字体清单或预检报告时请对结果去重。下面的示例报告每个返回的替代，然后创建唯一字体映射的排序列表：

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    selected_slides = [1, 3, 5]
    substitutions = list(presentation.fonts_manager.get_substitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")

    preflight_entries = [f"{substitution.original_font_name} -> {substitution.substituted_font_name}" for substitution in substitutions]
    unique_preflight_entries = {entry.casefold(): entry for entry in preflight_entries}
    sorted_preflight_entries = sorted(unique_preflight_entries.values(), key=str.casefold)

    print("Deduplicated font preflight report:")
    for entry in sorted_preflight_entries:
        print(entry)
```

[FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/)类同时提供上述两种形式的方法。根据渲染操作的范围选择合适的调用方式：

| 方法调用 | 使用场景 |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) with no arguments | 需要为整个演示文稿获取替代。 |
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) with a list of slide indexes | 需要为选定范围、增量检查或部分导出获取替代。 |

## **设置字体替代规则**

要指定当源字体不可用时 Aspose.Slides 应使用的字体：

1. 加载演示文稿。  
2. 为源字体和替代字体创建字体定义。  
3. 使用[WHEN_INACCESSIBLE](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstcondition/)条件创建一个[FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/)。  
4. 将规则添加到[FontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrulecollection/)。  
5. 将集合分配给[FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/font_subst_rule_list/)属性。  
6. 渲染或转换演示文稿。

下面的 Python 示例在`SomeRareFont`不可用时用`Arial`替代`SomeRareFont`，随后渲染第一张幻灯片以验证结果。替代字体必须对 Aspose.Slides 可用。

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    source_font = slides.FontData("SomeRareFont")
    substitute_font = slides.FontData("Arial")
    substitution_rule = slides.FontSubstRule(source_font, substitute_font, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    substitution_rules = slides.FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.fonts_manager.font_subst_rule_list = substitution_rules

    with presentation.slides[0].get_image(1, 1) as image:
        image.save("slide.jpg", slides.ImageFormat.JPEG)
```

{{% alert color="info" title="Note" %}}
对于对整个演示文稿中使用的字体进行无条件更改，请参阅[字体替换](/slides/zh/python-net/font-replacement/)。
{{% /alert %}}

## **数学公式字体的限制**

字体替代规则是渲染和转换期间使用的标准字体选择过程的一部分。它们在 Aspose.Slides 能用规则指定的可用字体替代不可访问字体时，对普通文本有效。

Office Math 公式还有额外的要求。如果公式使用**Cambria Math**，Aspose.Slides 可能需要该确切字体来计算和渲染公式布局。替代为其他数学字体（例如**STIX Two Math**）的规则无法替代**Cambria Math**，渲染仍可能报告需要**Cambria Math**。

要渲染或转换此类演示文稿，请确保 Aspose.Slides 能够使用**Cambria Math**。可以在操作系统中安装该字体或将其作为[外部字体](/slides/zh/python-net/custom-font/)加载。

此限制仅适用于公式布局。上述替代规则仍然适用于普通演示文稿文本。

## **常见问题**

**字体替换和字体替代有什么区别？**

[字体替换](/slides/zh/python-net/font-replacement/)会有意在整个演示文稿中将一种字体更改为另一种。字体替代则在满足配置的条件（例如原始字体不可用）时，为渲染输出选择字体。

**替代规则何时生效？**

规则参与渲染和转换期间的[字体选择序列](/slides/zh/python-net/font-selection-sequence/)。使用`WHEN_INACCESSIBLE`时，规则仅在 Aspose.Slides 无法访问源字体时使用。

**当字体缺失且未配置替代规则会怎样？**

Aspose.Slides 会根据其字体选择过程选择最接近的可用字体。结果取决于运行时环境中可用的字体。

**我可以加载外部字体以避免替代吗？**

可以。[加载外部字体](/slides/zh/python-net/custom-font/)后，Aspose.Slides 在渲染和转换时即可使用这些字体。

**Aspose 是否随库分发字体？**

不。字体的提供和许可证合规由您自行负责。

**替代结果会在 Windows、Linux 和 macOS 之间有所不同吗？**

会。不同操作系统的已安装字体和字体搜索位置不同，某台机器上可用的字体在另一台机器上可能需要替代。

**如何在批量转换中保持字体选择的一致性？**

在每台机器或容器上使用相同的字体文件和版本，[加载所需的外部字体](/slides/zh/python-net/custom-font/)，并在许可允许的情况下[嵌入字体](/slides/zh/python-net/embedded-font/)。还可以在导出前调用[FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/)以识别意外的替代。