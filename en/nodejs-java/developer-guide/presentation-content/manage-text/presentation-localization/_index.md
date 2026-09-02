---
title: Automate Presentation Localization in JavaScript
linktitle: Presentation Localization
type: docs
weight: 100
url: /nodejs-java/presentation-localization/
keywords:
- change language
- spell check
- suppress spell check
- proofing language
- language id
- multilingual text
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Set proofing languages for PowerPoint and OpenDocument presentation text in JavaScript with Aspose.Slides, including defaults and multilingual paragraphs."
---

## **Overview**

Aspose.Slides for Node.js via Java lets you configure proofing metadata for individual text portions. Use [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) to identify the proofing language, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) to allow or suppress spelling checks, and [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) to control the broader no-proof state. Because these settings are applied at the portion level, one paragraph can contain multiple languages and different proofing rules.

This article explains how to assign a language to specific text, set the default language for new text with [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), build multilingual paragraphs, choose between `SpellCheck` and `ProofDisabled`, and preserve the intended settings when using [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--). These properties store metadata for presentation applications; they do not translate text, perform dictionary-based spell checking, or return misspelled words.

## **Set the Proofing Language for Text**

Create or load a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), access the required text portion through [Portion.getPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/#getPortionFormat--), and assign its language identifier. The following example creates a shape, sets British English as the proofing language, and saves the result with [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Set the Default Language for New Text**

Use [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) to specify the proofing language that Aspose.Slides assigns to newly created text. This setting is useful when most or all new text in a presentation uses the same language. It does not change the language metadata of text that already has an explicit language.

The following example creates a presentation whose new text uses German proofing rules:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Use Multiple Languages in One Paragraph**

A [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) contains a collection of text portions. Create a separate [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) for each language and set its `LanguageId` independently.

This example creates one paragraph with English and French portions:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const englishPortion = new aspose.slides.Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    const frenchPortion = new aspose.slides.Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Enable or Suppress Spell Checking for Individual Portions**

[PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) inherits the common text properties defined by [BasePortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/). Access a portion's format through [Portion.getPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/#getPortionFormat--) and use [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) to control whether a presentation application may check spelling for that portion. The default value is `false`: `true` allows spell checking, while `false` suppresses it.

The setting applies to individual text portions. Different portions in the same paragraph can therefore use different values. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) and `setSpellCheck` serve complementary purposes: `setLanguageId` identifies the proofing language, while `setSpellCheck` determines whether spelling checks are allowed for the portion.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) also controls proofing, but it represents the broader "do not proof" state as a [NullableBool](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/). Use `setSpellCheck` when you need a direct Boolean switch specifically for spelling checks. Use `setProofDisabled` when you need to preserve or explicitly control the presentation's no-proof metadata, including its `NotDefined` state. If you set both properties, keep their values consistent; do not combine `setSpellCheck(true)` with `setProofDisabled(NullableBool.True)`.

These properties configure proofing metadata used by PowerPoint and other presentation applications. Aspose.Slides does not use them to run dictionary-based spell checking or return a list of misspelled words.

The following complete example creates an input presentation, loads it, assigns different spell-check settings and proofing languages to two portions in the same paragraph, saves the result, reopens it, and verifies the stored values:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const inputFile = "spell_check_input.pptx";
const outputFile = "spell_check_settings.pptx";

const sourcePresentation = new aspose.slides.Presentation();
try {
    const sourceSlide = sourcePresentation.getSlides().get_Item(0);
    const sourceShape = sourceSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    const sourceEnglishPortion = new aspose.slides.Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    const sourceFrenchPortion = new aspose.slides.Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

const presentation = new aspose.slides.Presentation(inputFile);
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    const suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const firstPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(0).getPortionFormat().getLanguageId() === "en-US" && 
        storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    const secondPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(1).getPortionFormat().getLanguageId() === "fr-FR" && 
        !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        console.log("The proofing settings were stored correctly.");
    } else {
        console.log("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--) combines adjacent portions that have the same formatting. A difference in `SpellCheck` alone does not keep such portions separate; after they are joined, the resulting portion retains the `SpellCheck` value of the first portion. If portions need different spell-check settings, call `joinPortionsWithSameFormatting` before assigning those settings, or inspect the resulting portion boundaries and reapply the settings afterward. Portions with different `LanguageId` values remain separate because their proofing-language formatting differs.

## **FAQ**

**Does a language ID translate the text?**

No. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) stores proofing metadata for spelling and grammar; it does not alter the text content. Translate the text separately, and then set the appropriate language identifier for each translated portion.

**Does the proofing language control fonts, hyphenation, or line wrapping?**

No. The language identifier is for proofing. Text rendering and layout primarily depend on the available [fonts](/slides/nodejs-java/powerpoint-fonts/), the writing system, and the text-frame settings. For reliable rendering, provide the required fonts, configure [font substitution](/slides/nodejs-java/font-substitution/), or [embed fonts](/slides/nodejs-java/embedded-font/) in the presentation.

**Can one paragraph use several proofing languages?**

Yes. Assign each language to a separate portion, as shown in the multilingual paragraph example.

**Should I use `setDefaultTextLanguage` or `setLanguageId`?**

Use [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) when you want a default for newly created text. Use [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) when a specific portion needs an explicit proofing language or when a paragraph contains multiple languages.
