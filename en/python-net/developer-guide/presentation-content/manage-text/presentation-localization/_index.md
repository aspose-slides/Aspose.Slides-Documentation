---
title: Automate Presentation Localization with Python
linktitle: Presentation Localization
type: docs
weight: 100
url: /python-net/presentation-localization/
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
- Aspose.Slides
description: "Set proofing languages for PowerPoint and OpenDocument presentation text in Python with Aspose.Slides, including defaults and multilingual paragraphs."
---

## **Overview**

Aspose.Slides for Python via .NET lets you configure proofing metadata for individual text portions. Use [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) to identify the proofing language, [BasePortionFormat.spell_check](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spell_check/) to allow or suppress spelling checks, and [BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/proof_disabled/) to control the broader no-proof state. Because these settings are applied at the portion level, one paragraph can contain multiple languages and different proofing rules.

This article explains how to assign a language to specific text, set the default language for new text with [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/), build multilingual paragraphs, choose between `spell_check` and `proof_disabled`, and preserve the intended settings when using [Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/join_portions_with_same_formatting/). These properties store metadata for presentation applications; they do not translate text, perform dictionary-based spell checking, or return misspelled words.

## **Set the Proofing Language for Text**

Create or load a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), access the required text portion through [Portion.portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/portion/portion_format/), and assign its language identifier. The following example creates a shape, sets British English as the proofing language, and saves the result with [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/):

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

## **Set the Default Language for New Text**

Use [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) to specify the proofing language that Aspose.Slides assigns to newly created text. This setting is useful when most or all new text in a presentation uses the same language. It does not change the language metadata of text that already has an explicit language.

The following example creates a presentation whose new text uses German proofing rules:

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

## **Use Multiple Languages in One Paragraph**

A [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) contains a collection of text portions. Create a separate [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) for each language and set its `language_id` independently.

This example creates one paragraph with English and French portions:

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

## **Enable or Suppress Spell Checking for Individual Portions**

[PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) inherits the common text properties defined by [BasePortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/). Access a portion's format through [Portion.portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/portion/portion_format/) and set [BasePortionFormat.spell_check](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spell_check/) to control whether a presentation application may check spelling for that portion. The default value is `False`: `True` allows spell checking, while `False` suppresses it.

The setting applies to individual text portions. Different portions in the same paragraph can therefore use different values. [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) and `spell_check` serve complementary purposes: `language_id` identifies the proofing language, while `spell_check` determines whether spelling checks are allowed for the portion.

[BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/proof_disabled/) also controls proofing, but it represents the broader "do not proof" state as a [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/). Use `spell_check` when you need a direct Boolean switch specifically for spelling checks. Use `proof_disabled` when you need to preserve or explicitly control the presentation's no-proof metadata, including its `NOT_DEFINED` state. If you set both properties, keep their values consistent; do not combine `spell_check = True` with `proof_disabled = slides.NullableBool.TRUE`.

These properties configure proofing metadata used by PowerPoint and other presentation applications. Aspose.Slides does not use them to run dictionary-based spell checking or return a list of misspelled words.

The following complete example creates an input presentation, loads it, assigns different spell-check settings and proofing languages to two portions in the same paragraph, saves the result, reopens it, and verifies the stored values:

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

[Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/join_portions_with_same_formatting/) combines adjacent portions that have the same formatting. A difference in `spell_check` alone does not keep such portions separate; after they are joined, the resulting portion retains the `spell_check` value of the first portion. If portions need different spell-check settings, call `join_portions_with_same_formatting` before assigning those settings, or inspect the resulting portion boundaries and reapply the settings afterward. Portions with different `language_id` values remain separate because their proofing-language formatting differs.

## **FAQ**

**Does a language ID translate the text?**

No. [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) stores proofing metadata for spelling and grammar; it does not alter the text content. Translate the text separately, and then set the appropriate language identifier for each translated portion.

**Does the proofing language control fonts, hyphenation, or line wrapping?**

No. The language identifier is for proofing. Text rendering and layout primarily depend on the available [fonts](/slides/python-net/powerpoint-fonts/), the writing system, and the text-frame settings. For reliable rendering, provide the required fonts, configure [font substitution](/slides/python-net/font-substitution/), or [embed fonts](/slides/python-net/embedded-font/) in the presentation.

**Can one paragraph use several proofing languages?**

Yes. Assign each language to a separate portion, as shown in the multilingual paragraph example.

**Should I use `default_text_language` or `language_id`?**

Use [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) when you want a default for newly created text. Use [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) when a specific portion needs an explicit proofing language or when a paragraph contains multiple languages.
