---
title: Automate Presentation Localization in Python via Java
linktitle: Presentation Localization
type: docs
weight: 100
url: /python-java/presentation-localization/
keywords:
- change language
- spell check
- suppress spell check
- proofing language
- language id
- multilingual text
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Set proofing languages for PowerPoint and OpenDocument presentation text in Python via Java with Aspose.Slides, including defaults and multilingual paragraphs."
---

## **Overview**

Aspose.Slides for Python via Java lets you configure proofing metadata for individual text portions. Use [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId) to identify the proofing language, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpellCheck) to allow or suppress spelling checks, and [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setProofDisabled) to control the broader no-proof state. Because these settings are applied at the portion level, one paragraph can contain multiple languages and different proofing rules.

This article explains how to assign a language to specific text, set the default language for new text with [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage), build multilingual paragraphs, choose between [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpellCheck) and [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setProofDisabled), and preserve the intended settings when using [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting). These properties store metadata for presentation applications; they do not translate text, perform dictionary-based spell checking, or return misspelled words.

## **Set the Proofing Language for Text**

Create or load a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), access the required text portion through [Portion.getPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getPortionFormat), and assign its language identifier. The following example creates a shape, sets British English as the proofing language, and saves the result with [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save):

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

## **Set the Default Language for New Text**

Use [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) to specify the proofing language that Aspose.Slides assigns to newly created text. This setting is useful when most or all new text in a presentation uses the same language. It does not change the language metadata of text that already has an explicit language.

The following example creates a presentation whose new text uses German proofing rules:

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

## **Use Multiple Languages in One Paragraph**

A [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) contains a collection of text portions. Create a separate [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) for each language and set its [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId) independently.

This example creates one paragraph with English and French portions:

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

## **Enable or Suppress Spell Checking for Individual Portions**

[PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) inherits the common text properties defined by [BasePortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/). Access a portion's format through [Portion.getPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getPortionFormat) and use [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpellCheck) to control whether a presentation application may check spelling for that portion. The default value is `False`: `True` allows spell checking, while `False` suppresses it.

The setting applies to individual text portions. Different portions in the same paragraph can therefore use different values. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId) and [setSpellCheck](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpellCheck) serve complementary purposes: [setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId) identifies the proofing language, while [setSpellCheck](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpellCheck) determines whether spelling checks are allowed for the portion.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setProofDisabled) also controls proofing, but it represents the broader "do not proof" state as a [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/). Use [setSpellCheck](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpellCheck) when you need a direct Boolean switch specifically for spelling checks. Use [setProofDisabled](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setProofDisabled) when you need to preserve or explicitly control the presentation's no-proof metadata, including its [NullableBool.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/#NotDefined) state. If you set both properties, keep their values consistent; do not combine [setSpellCheck](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpellCheck) set to `True` with [setProofDisabled](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setProofDisabled) set to the [NullableBool.True](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/#True) state.

These properties configure proofing metadata used by PowerPoint and other presentation applications. Aspose.Slides does not use them to run dictionary-based spell checking or return a list of misspelled words.

The following complete example creates an input presentation, loads it, assigns different spell-check settings and proofing languages to two portions in the same paragraph, saves the result, reopens it, and verifies the stored values:

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

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) combines adjacent portions that have the same formatting. A difference in [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpellCheck) alone does not keep such portions separate; after they are joined, the resulting portion retains the [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpellCheck) value of the first portion. If portions need different spell-check settings, call [joinPortionsWithSameFormatting](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) before assigning those settings, or inspect the resulting portion boundaries and reapply the settings afterward. Portions with different [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId) values remain separate because their proofing-language formatting differs.

## **FAQ**

**Does a language ID translate the text?**

No. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId) stores proofing metadata for spelling and grammar; it does not alter the text content. Translate the text separately, and then set the appropriate language identifier for each translated portion.

**Does the proofing language control fonts, hyphenation, or line wrapping?**

No. The language identifier is for proofing. Text rendering and layout primarily depend on the available [fonts](/slides/python-java/powerpoint-fonts/), the writing system, and the text-frame settings. For reliable rendering, provide the required fonts, configure [font substitution](/slides/python-java/font-substitution/), or [embed fonts](/slides/python-java/embedded-font/) in the presentation.

**Can one paragraph use several proofing languages?**

Yes. Assign each language to a separate portion, as shown in the multilingual paragraph example.

**Should I use [setDefaultTextLanguage](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) or [setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId)?**

Use [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) when you want a default for newly created text. Use [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId) when a specific portion needs an explicit proofing language or when a paragraph contains multiple languages.
