---
title: Automate Presentation Localization on Android
linktitle: Presentation Localization
type: docs
weight: 100
url: /androidjava/presentation-localization/
keywords:
- change language
- spell check
- suppress spell check
- proofing language
- language id
- multilingual text
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Set proofing languages for PowerPoint and OpenDocument presentation text on Android with Aspose.Slides for Android via Java, including defaults and multilingual paragraphs."
---

## **Overview**

Aspose.Slides for Android via Java lets you configure proofing metadata for individual text portions. Use [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) to identify the proofing language, [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) to allow or suppress spelling checks, and [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) to control the broader no-proof state. Because these settings are applied at the portion level, one paragraph can contain multiple languages and different proofing rules.

This article explains how to assign a language to specific text, set the default language for new text with [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), build multilingual paragraphs, choose between `SpellCheck` and `ProofDisabled`, and preserve the intended settings when using [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--). These properties store metadata for presentation applications; they do not translate text, perform dictionary-based spell checking, or return misspelled words.

## **Set the Proofing Language for Text**

Create or load a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), access the required text portion through [IPortion.getPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/#getPortionFormat--), and assign its language identifier. The following example creates a shape, sets British English as the proofing language, and saves the result with [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-):

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IPortion;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Set the Default Language for New Text**

Use [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) to specify the proofing language that Aspose.Slides assigns to newly created text. This setting is useful when most or all new text in a presentation uses the same language. It does not change the language metadata of text that already has an explicit language.

The following example creates a presentation whose new text uses German proofing rules:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Use Multiple Languages in One Paragraph**

An [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) contains a collection of text portions. Create a separate [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) for each language and set its `LanguageId` independently.

This example creates one paragraph with English and French portions:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion englishPortion = new Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    Portion frenchPortion = new Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Enable or Suppress Spell Checking for Individual Portions**

[IPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/) inherits the common text properties defined by [IBasePortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/). Access a portion's format through [IPortion.getPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/#getPortionFormat--) and use [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) to control whether a presentation application may check spelling for that portion. The default value is `false`: `true` allows spell checking, while `false` suppresses it.

The setting applies to individual text portions. Different portions in the same paragraph can therefore use different values. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) and `setSpellCheck` serve complementary purposes: `setLanguageId` identifies the proofing language, while `setSpellCheck` determines whether spelling checks are allowed for the portion.

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) also controls proofing, but it represents the broader "do not proof" state as a [NullableBool](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/). Use `setSpellCheck` when you need a direct Boolean switch specifically for spelling checks. Use `setProofDisabled` when you need to preserve or explicitly control the presentation's no-proof metadata, including its `NotDefined` state. If you set both properties, keep their values consistent; do not combine `setSpellCheck(true)` with `setProofDisabled(NullableBool.True)`.

These properties configure proofing metadata used by PowerPoint and other presentation applications. Aspose.Slides does not use them to run dictionary-based spell checking or return a list of misspelled words.

The following complete example creates an input presentation, loads it, assigns different spell-check settings and proofing languages to two portions in the same paragraph, saves the result, reopens it, and verifies the stored values:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.IPortion;
import com.aspose.slides.IPortionCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

String inputFile = "spell_check_input.pptx";
String outputFile = "spell_check_settings.pptx";

Presentation sourcePresentation = new Presentation();
try {
    ISlide sourceSlide = sourcePresentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    Portion sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    Portion sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

Presentation presentation = new Presentation(inputFile);
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    IPortion checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    IPortion suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    IAutoShape reopenedShape = (IAutoShape) reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    boolean firstPortionStored = storedPortions.getCount() == 2 &&
            "en-US".equals(storedPortions.get_Item(0).getPortionFormat().getLanguageId()) &&
            storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    boolean secondPortionStored = storedPortions.getCount() == 2 &&
            "fr-FR".equals(storedPortions.get_Item(1).getPortionFormat().getLanguageId()) &&
            !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        System.out.println("The proofing settings were stored correctly.");
    } else {
        System.out.println("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) combines adjacent portions that have the same formatting. A difference in `SpellCheck` alone does not keep such portions separate; after they are joined, the resulting portion retains the `SpellCheck` value of the first portion. If portions need different spell-check settings, call `joinPortionsWithSameFormatting` before assigning those settings, or inspect the resulting portion boundaries and reapply the settings afterward. Portions with different `LanguageId` values remain separate because their proofing-language formatting differs.

## **FAQ**

**Does a language ID translate the text?**

No. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) stores proofing metadata for spelling and grammar; it does not alter the text content. Translate the text separately, and then set the appropriate language identifier for each translated portion.

**Does the proofing language control fonts, hyphenation, or line wrapping?**

No. The language identifier is for proofing. Text rendering and layout primarily depend on the available [fonts](/slides/androidjava/powerpoint-fonts/), the writing system, and the text-frame settings. For reliable rendering, provide the required fonts, configure [font substitution](/slides/androidjava/font-substitution/), or [embed fonts](/slides/androidjava/embedded-font/) in the presentation.

**Can one paragraph use several proofing languages?**

Yes. Assign each language to a separate portion, as shown in the multilingual paragraph example.

**Should I use `setDefaultTextLanguage` or `setLanguageId`?**

Use [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) when you want a default for newly created text. Use [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) when a specific portion needs an explicit proofing language or when a paragraph contains multiple languages.
