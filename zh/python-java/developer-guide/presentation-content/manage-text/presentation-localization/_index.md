---
title: 使用 Python via Java 自动化演示文稿本地化
linktitle: 演示文稿本地化
type: docs
weight: 100
url: /zh/python-java/presentation-localization/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python via Java 中为 PowerPoint 和 OpenDocument 演示文稿文本设置校对语言，包括默认语言和多语言段落。"
---
## **概述**

Aspose.Slides for Python via Java 允许您为单个文本段落配置校对元数据。使用 [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseportionformat/#setLanguageId) 来指定校对语言，使用 [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseportionformat/#setSpellCheck) 来允许或抑制拼写检查，并使用 [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseportionformat/#setProofDisabled) 来控制更广泛的“禁用校对”状态。由于这些设置在段落级别应用，一个段落可以包含多种语言和不同的校对规则。

本文说明如何为特定文本分配语言，使用 [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) 为新文本设置默认语言，构建多语言段落，在 [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseportionformat/#setSpellCheck) 与 [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseportionformat/#setProofDisabled) 之间进行选择，以及在使用 [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) 时保留预期的设置。这些属性存储演示文稿应用程序的元数据；它们不翻译文本，不执行基于词典的拼写检查，也不返回拼写错误的单词。

## **设置文本的校对语言**

创建或加载一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/)，通过 [Portion.getPortionFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portion/#getPortionFormat) 访问所需的文本段落，并分配其语言标识符。以下示例创建一个形状，将英国英语设为校对语言，并使用 [Presentation.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save) 保存结果：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Set the proofing language for this text.")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setLanguageId("en-GB")

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **为新文本设置默认语言**

使用 [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) 指定 Aspose.Slides 为新创建的文本分配的校对语言。当演示文稿中的大多数或全部新文本使用相同语言时，此设置非常有用。它不会更改已具有明确语言的文本的语言元数据。

以下示例创建一个演示文稿，其新文本使用德语校对规则：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("de-DE")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Willkommen zur Präsentation")

    presentation.save("default_text_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在同一段落中使用多种语言**

[Paragraph](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraph/) 包含一系列文本段落。为每种语言创建单独的 [Portion](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portion/) 并独立设置其 [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseportionformat/#setLanguageId)。

此示例创建一个包含英文和法文段落的段落：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    english_portion = Portion("Welcome")
    english_portion.getPortionFormat().setLanguageId("en-US")
    paragraph.getPortions().add(english_portion)

    french_portion = Portion(" — Bienvenue")
    french_portion.getPortionFormat().setLanguageId("fr-FR")
    paragraph.getPortions().add(french_portion)

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **为单个段落启用或抑制拼写检查**

[PortionFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portionformat/) 继承了由 [BasePortionFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseportionformat/) 定义的通用文本属性。通过 [Portion.getPortionFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portion/#getPortionFormat) 访问段落的格式，并使用 [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseportionformat/#setSpellCheck) 来控制演示文稿应用程序是否可以检查该段落的拼写。默认值为 `False`：`True` 允许拼写检查，而 `False` 抑制拼写检查。

此设置适用于单个文本段落。因此，同一段落中的不同段落可以使用不同的值。[BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseportionformat/#setLanguageId) 和 [setSpellCheck](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseportionformat/#setSpellCheck) 具有互补作用：[setLanguageId](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseportionformat/#setLanguageId) 确定校对语言，而 [setSpellCheck](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseportionformat/#setSpellCheck) 决定是否允许对该段落进行拼写检查。

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseportionformat/#setProofDisabled) 也控制校对，但它将更广泛的“不进行校对”状态表示为 [NullableBool](https://reference.aspose.com/slides/zh/python-java/aspose.slides/nullablebool/)。当您需要专门用于拼写检查的直接布尔开关时，请使用 [setSpellCheck](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseportionformat/#setSpellCheck)。当您需要保留或显式控制演示文稿的非校对元数据（包括其 [NullableBool.NotDefined](https://reference.aspose.com/slides/zh/python-java/aspose.slides/nullablebool/#NotDefined) 状态）时，请使用 [setProofDisabled](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseportionformat/#setProofDisabled)。如果同时设置这两个属性，请保持它们的值一致；不要将 [setSpellCheck](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseportionformat/#setSpellCheck) 设置为 `True` 时再将 [setProofDisabled](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseportionformat/#setProofDisabled) 设置为 [NullableBool.True](https://reference.aspose.com/slides/zh/python-java/aspose.slides/nullablebool/#True) 状态。

这些属性配置 PowerPoint 和其他演示文稿应用程序使用的校对元数据。Aspose.Slides 并不使用它们进行基于词典的拼写检查或返回拼写错误单词列表。

以下完整示例创建一个输入演示文稿，加载它，为同一段落中的两个段落分配不同的拼写检查设置和校对语言，保存结果，重新打开并验证存储的值：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

source_presentation = Presentation()
try:
    source_slide = source_presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    source_paragraph = source_shape.getTextFrame().getParagraphs().get_Item(0)
    source_paragraph.getPortions().clear()

    source_english_portion = Portion("Check this text. ")
    source_english_portion.getPortionFormat().setLanguageId("en-US")
    source_paragraph.getPortions().add(source_english_portion)

    source_french_portion = Portion("Ignorer ce code : ZX-81.")
    source_french_portion.getPortionFormat().setLanguageId("fr-FR")
    source_paragraph.getPortions().add(source_french_portion)

    source_presentation.save(input_file, SaveFormat.Pptx)
finally:
    source_presentation.dispose()

presentation = Presentation(input_file)
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    checked_portion = portions.get_Item(0)
    checked_portion.getPortionFormat().setLanguageId("en-US")
    checked_portion.getPortionFormat().setSpellCheck(True)

    suppressed_portion = portions.get_Item(1)
    suppressed_portion.getPortionFormat().setLanguageId("fr-FR")
    suppressed_portion.getPortionFormat().setSpellCheck(False)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    stored_portions = reopened_shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    first_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(0).getPortionFormat().getLanguageId() == "en-US" and stored_portions.get_Item(0).getPortionFormat().getSpellCheck()

    second_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(1).getPortionFormat().getLanguageId() == "fr-FR" and not stored_portions.get_Item(1).getPortionFormat().getSpellCheck()

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")

finally:
    reopened_presentation.dispose()
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) 将具有相同格式的相邻段落合并。仅在 [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseportionformat/#setSpellCheck) 上的差异不足以保持这些段落分离；合并后，生成的段落保留第一个段落的 [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseportionformat/#setSpellCheck) 值。如果段落需要不同的拼写检查设置，请在分配这些设置之前调用 [joinPortionsWithSameFormatting](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting)，或者在合并后检查生成的段落边界并重新应用设置。具有不同 [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseportionformat/#setLanguageId) 值的段落会保持分离，因为它们的校对语言格式不同。

## **FAQ**

**语言 ID 会翻译文本吗？**

不会。[BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseportionformat/#setLanguageId) 存储拼写和语法校对的元数据；它不会改变文本内容。请先单独翻译文本，然后为每个已翻译的段落设置相应的语言标识符。

**校对语言会控制字体、连字符或换行吗？**

不会。语言标识符用于校对。文本渲染和布局主要取决于可用的 [fonts](/slides/zh/python-java/powerpoint-fonts/)、书写系统以及文本框设置。为获得可靠的渲染，请提供所需字体，配置 [font substitution](/slides/zh/python-java/font-substitution/)，或在演示文稿中 [embed fonts](/slides/zh/python-java/embedded-font/)。

**一个段落可以使用多种校对语言吗？**

可以。如多语言段落示例所示，为每种语言分配单独的段落。

**应该使用 [setDefaultTextLanguage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) 还是 [setLanguageId](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseportionformat/#setLanguageId)？**

当您希望为新创建的文本提供默认语言时，请使用 [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage)。当特定段落需要显式校对语言或段落包含多种语言时，请使用 [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseportionformat/#setLanguageId)。