---
title: 使用 Python 自动化演示文稿本地化
linktitle: 演示文稿本地化
type: docs
weight: 100
url: /zh/python-net/presentation-localization/
keywords:
- 更改语言
- 拼写检查
- 抑制拼写检查
- 校对语言
- 语言标识
- 多语言文本
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中为 PowerPoint 和 OpenDocument 演示文稿文本设置校对语言，包括默认语言和多语言段落。"
---
## **概览**

Aspose.Slides for Python via .NET 允许您为单独的文本片段配置校对元数据。使用 [BasePortionFormat.language_id](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseportionformat/language_id/) 指定校对语言，使用 [BasePortionFormat.spell_check](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseportionformat/spell_check/) 允许或抑制拼写检查，使用 [BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseportionformat/proof_disabled/) 控制更广泛的“不校对”状态。由于这些设置在片段级别应用，同一段落可以包含多种语言和不同的校对规则。

本文介绍如何为特定文本分配语言，使用 [LoadOptions.default_text_language](https://reference.aspose.com/slides/zh/python-net/aspose.slides/loadoptions/default_text_language/) 为新文本设置默认语言，构建多语言段落，在 `spell_check` 与 `proof_disabled` 之间进行选择，以及在使用 [Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/join_portions_with_same_formatting/) 时保留预期的设置。这些属性存储演示文稿应用程序的元数据；它们不翻译文本、执行基于词典的拼写检查或返回拼写错误的单词。

## **为文本设置校对语言**

创建或加载一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/)，通过 [Portion.portion_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portion/portion_format/) 访问所需的文本片段，并为其分配语言标识符。以下示例创建一个形状，将校对语言设置为英式英语，并使用 [Presentation.save](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/save/) 保存结果：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Set the proofing language for this text."

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.language_id = "en-GB"

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **为新文本设置默认语言**

使用 [LoadOptions.default_text_language](https://reference.aspose.com/slides/zh/python-net/aspose.slides/loadoptions/default_text_language/) 指定 Aspose.Slides 为新创建的文本分配的校对语言。当演示文稿中的大多数或全部新文本使用相同语言时，此设置非常有用。它不会更改已显式设置语言的文本的语言元数据。

以下示例创建一个演示文稿，其新文本使用德语校对规则：

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "de-DE"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Willkommen zur Präsentation"

    presentation.save("default_text_language.pptx", slides.export.SaveFormat.PPTX)
```

## **在同一段落中使用多种语言**

[Paragraph](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/) 包含一组文本片段。为每种语言创建单独的 [Portion](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portion/)，并独立设置其 `language_id`。

此示例创建一个包含英文和法文片段的段落：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    english_portion = slides.Portion("Welcome")
    english_portion.portion_format.language_id = "en-US"
    paragraph.portions.add(english_portion)

    french_portion = slides.Portion(" — Bienvenue")
    french_portion.portion_format.language_id = "fr-FR"
    paragraph.portions.add(french_portion)

    presentation.save("multilingual_text.pptx", slides.export.SaveFormat.PPTX)
```

## **为单个片段启用或抑制拼写检查**

[PortionFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portionformat/) 继承了由 [BasePortionFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseportionformat/) 定义的通用文本属性。通过 [Portion.portion_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portion/portion_format/) 访问片段的格式，并设置 [BasePortionFormat.spell_check](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseportionformat/spell_check/) 以控制演示文稿应用程序是否检查该片段的拼写。默认值为 `False`：`True` 允许拼写检查，`False` 抑制拼写检查。

此设置适用于单个文本片段。因此，同一段落中的不同片段可以使用不同的值。[BasePortionFormat.language_id](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseportionformat/language_id/) 与 `spell_check` 具有互补作用：`language_id` 标识校对语言，而 `spell_check` 决定是否允许对该片段进行拼写检查。

[BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseportionformat/proof_disabled/) 也控制校对，但它表示更广泛的“不要校对”状态，采用 [NullableBool](https://reference.aspose.com/slides/zh/python-net/aspose.slides/nullablebool/)。在仅需要针对拼写检查的布尔开关时使用 `spell_check`。在需要保留或显式控制演示文稿的无校对元数据（包括其 `NOT_DEFINED` 状态）时使用 `proof_disabled`。如果同时设置两个属性，请保持它们的值一致；不要将 `spell_check = True` 与 `proof_disabled = slides.NullableBool.TRUE` 混用。

这些属性配置 PowerPoint 和其他演示文稿应用程序使用的校对元数据。Aspose.Slides 并不利用它们进行基于词典的拼写检查或返回拼写错误单词列表。

以下完整示例创建一个输入演示文稿，加载它，为同一段落中的两个片段分配不同的拼写检查设置和校对语言，保存结果，重新打开并验证存储的值：

```python
import aspose.slides as slides

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

with slides.Presentation() as source_presentation:
    source_slide = source_presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    source_paragraph = source_shape.text_frame.paragraphs[0]
    source_paragraph.portions.clear()

    source_english_portion = slides.Portion("Check this text. ")
    source_english_portion.portion_format.language_id = "en-US"
    source_paragraph.portions.add(source_english_portion)

    source_french_portion = slides.Portion("Ignorer ce code : ZX-81.")
    source_french_portion.portion_format.language_id = "fr-FR"
    source_paragraph.portions.add(source_french_portion)

    source_presentation.save(input_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(input_file) as presentation:
    shape = presentation.slides[0].shapes[0]
    portions = shape.text_frame.paragraphs[0].portions

    checked_portion = portions[0]
    checked_portion.portion_format.language_id = "en-US"
    checked_portion.portion_format.spell_check = True

    suppressed_portion = portions[1]
    suppressed_portion.portion_format.language_id = "fr-FR"
    suppressed_portion.portion_format.spell_check = False

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]
    stored_portions = reopened_shape.text_frame.paragraphs[0].portions

    has_two_portions = stored_portions.count == 2

    first_portion_stored = (
        has_two_portions 
        and stored_portions[0].portion_format.language_id == "en-US" 
        and stored_portions[0].portion_format.spell_check
    )

    second_portion_stored = (
        has_two_portions
        and stored_portions[1].portion_format.language_id == "fr-FR" 
        and not stored_portions[1].portion_format.spell_check
    )

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")
```

[Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/join_portions_with_same_formatting/) 将具有相同格式的相邻片段合并。仅 `spell_check` 的差异不足以保持片段分离；合并后，结果片段保留首个片段的 `spell_check` 值。如果片段需要不同的拼写检查设置，请在分配这些设置之前调用 `join_portions_with_same_formatting`，或检查合并后的片段边界并在随后重新应用设置。具有不同 `language_id` 值的片段会保持分离，因为它们的校对语言格式不同。

## **常见问答**

**语言 ID 会翻译文本吗？**

不会。[BasePortionFormat.language_id](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseportionformat/language_id/) 只存储用于拼写和语法校对的元数据；它不改变文本内容。请单独翻译文本，然后为每个翻译后的片段设置相应的语言标识符。

**校对语言会控制字体、连字符或换行吗？**

不会。语言标识符用于校对。文本渲染和布局主要取决于可用的[字体](/slides/zh/python-net/powerpoint-fonts/)、书写系统和文本框设置。为确保可靠渲染，请提供所需的字体，配置[字体替换](/slides/zh/python-net/font-substitution/)，或在演示文稿中[嵌入字体](/slides/zh/python-net/embedded-font/)。

**一个段落可以使用多种校对语言吗？**

可以。如多语言段落示例所示，将每种语言分配给独立的片段。

**应该使用 `default_text_language` 还是 `language_id`？**

当您希望为新创建的文本提供默认语言时，使用 [LoadOptions.default_text_language](https://reference.aspose.com/slides/zh/python-net/aspose.slides/loadoptions/default_text_language/)。当特定片段需要显式校对语言，或段落中包含多种语言时，使用 [BasePortionFormat.language_id](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseportionformat/language_id/)。