---
title: 配置 Python 演示文稿中的字体替换
linktitle: 字体替换
type: docs
weight: 70
url: /zh/python-net/font-substitution/
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
- Python
- Aspose.Slides
description: "在渲染或转换 PowerPoint 和 OpenDocument 演示文稿时，通过 .NET 为 Python 的 Aspose.Slides 配置字体替换规则并检查已替换的字体。"
---
## **概述**

字体替换允许 Aspose.Slides 在呈现或转换演示文稿时使用可用的字体来代替无法访问的字体。替换会影响渲染输出；但不会更改演示文稿内容所分配的字体。

您可以在特定字体不可用时定义要使用的字体，并且可以检查 Aspose.Slides 在渲染期间将进行的替换。这有助于在安装了不同字体的环境中保持输出的一致性。

## **获取字体替换**

使用[FontsManager.get_substitutions](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fontsmanager/get_substitutions/)方法确定在渲染演示文稿时将会替换哪些字体。该方法返回[FontSubstitutionInfo](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fontsubstitutioninfo/)对象，标识原始字体和替换后的字体名称。

下面的 Python 示例列出了演示文稿的所有字体替换：

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **获取选定幻灯片的字体替换**

使用[FontsManager.get_substitutions](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fontsmanager/get_substitutions/)并提供幻灯片索引列表，来仅检查渲染特定幻灯片所需的替换。这在您只渲染或导出演示文稿的一部分、增量检查大型演示文稿、定位依赖不可用字体的幻灯片、为服务器或容器准备最小字体包，或在不处理无关幻灯片的情况下诊断渲染差异时非常有用。

列表中包含的是从 1 开始的幻灯片索引：`1` 表示第一张幻灯片。相反，[Presentation.slides](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/slides/zh/)集合是从 0 开始的，因此同一张幻灯片的访问方式为 `presentation.slides[0]`。在构建列表时请记住此差异，以避免 off-by-one 错误。

通过[Presentation.fonts_manager](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/fonts_manager/)属性调用该方法。它仅返回在渲染所选幻灯片时确定的替换。每个结果都是一个[FontSubstitutionInfo](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fontsubstitutioninfo/)对象，包含原始和替换后的字体名称。结果反映了当前字体环境、已配置的回退规则、存储在[IFontSubstRuleCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ifontsubstrulecollection/)中的替换规则以及[外部加载的字体](/slides/zh/python-net/custom-font/)。

同一替换可能由多个选定幻灯片触发。创建字体清单或预检报告时请对结果去重。下面的示例报告了每个返回的替换，然后生成唯一字体映射的排序列表：

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

[FontsManager](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fontsmanager/)类提供了这两种形式的方法。根据渲染操作的范围选择使用：

| 方法调用 | 适用情形 |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fontsmanager/get_substitutions/)（无参数） | 需要获取整个演示文稿的替换。 |
| [get_substitutions](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fontsmanager/get_substitutions/)（带幻灯片索引列表） | 需要获取选定范围、增量检查或部分导出的替换。 |

## **设置字体替换规则**

要指定在源字体不可用时 Aspose.Slides 应使用的字体：

1. 加载演示文稿。  
2. 为源字体和替代字体创建字体定义。  
3. 使用[WHEN_INACCESSIBLE](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fontsubstcondition/)条件创建[FontSubstRule](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fontsubstrule/)。  
4. 将规则添加到[FontSubstRuleCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fontsubstrulecollection/)。  
5. 将集合分配给[FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fontsmanager/font_subst_rule_list/)属性。  
6. 渲染或转换演示文稿。

下面的 Python 示例在 `SomeRareFont` 不可用时将其替换为 `Arial`，然后渲染第一张幻灯片以验证结果。替代字体必须对 Aspose.Slides 可用。

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
若要无条件更改整个演示文稿中使用的字体，请参阅[字体替换](/slides/zh/python-net/font-replacement/)。
{{% /alert %}}

## **数学公式字体的限制**

字体替换规则是渲染和转换期间使用的标准字体选择过程的一部分。它们适用于普通文本，当 Aspose.Slides 能够使用规则指定的可用字体替换不可访问的字体时即可生效。

Office Math 公式还有额外要求。如果公式使用 **Cambria Math**，Aspose.Slides 可能需要该确切字体来计算并渲染公式布局。使用 **STIX Two Math** 等其他数学字体的替换规则无法替代 **Cambria Math**，渲染仍可能报告需要 **Cambria Math**。

要渲染或转换此类演示文稿，请确保 **Cambria Math** 对 Aspose.Slides 可用。可在操作系统中安装，或作为[外部字体](/slides/zh/python-net/custom-font/)加载。

此限制仅适用于公式布局。上述替换规则仍然适用于演示文稿的普通文本。

## **常见问题**

**字体替换和字体替换有什么区别？**  
[字体替换](/slides/zh/python-net/font-replacement/)会在整个演示文稿中有意将一种字体改为另一种字体。字体替换则在满足配置条件（例如原始字体不可用）时为渲染输出选择字体。

**替换规则何时生效？**  
规则参与渲染和转换期间的[字体选择序列](/slides/zh/python-net/font-selection-sequence/)。使用 `WHEN_INACCESSIBLE` 时，仅当 Aspose.Slides 无法访问源字体时才使用该规则。

**当字体缺失且未配置替换规则会怎样？**  
Aspose.Slides 将根据其字体选择过程选择最接近的可用字体。结果取决于运行时环境中可用的字体。

**我可以加载外部字体以避免替换吗？**  
可以。您可以[加载外部字体](/slides/zh/python-net/custom-font/)，使 Aspose.Slides 在渲染和转换时使用它们。

**Aspose 是否随库分发字体？**  
不。您需自行提供字体并遵守其许可协议。

**替换结果在 Windows、Linux 和 macOS 之间会不同吗？**  
会。不同操作系统的已安装字体和字体搜索位置不同，某台机器可用的字体在另一台机器上可能需要替换。

**如何在批量转换中保持字体选择的一致性？**  
在每台机器或容器上使用相同的字体文件和版本，[加载所需的外部字体](/slides/zh/python-net/custom-font/)，并在许可允许时[嵌入字体](/slides/zh/python-net/embedded-font/)。还可以在导出前调用[FontsManager.get_substitutions](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fontsmanager/get_substitutions/)以识别意外的替换情况。