---
title: Automate Presentation Localization in .NET
linktitle: Presentation Localization
type: docs
weight: 100
url: /net/presentation-localization/
keywords:
- change language
- spell check
- suppress spell check
- proofing language
- language id
- multilingual text
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Set proofing languages for PowerPoint and OpenDocument presentation text in .NET with Aspose.Slides, including defaults and multilingual paragraphs."
---

## **Overview**

Aspose.Slides for .NET lets you configure proofing metadata for individual text portions. Use [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) to identify the proofing language, [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/spellcheck/) to allow or suppress spelling checks, and [BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/proofdisabled/) to control the broader no-proof state. Because these settings are applied at the portion level, one paragraph can contain multiple languages and different proofing rules.

This article explains how to assign a language to specific text, set the default language for new text with [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/), build multilingual paragraphs, choose between `SpellCheck` and `ProofDisabled`, and preserve the intended settings when using [Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/net/aspose.slides/presentation/joinportionswithsameformatting/). These properties store metadata for presentation applications; they do not translate text, perform dictionary-based spell checking, or return misspelled words.

## **Set the Proofing Language for Text**

Create or load a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), access the required text portion through [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/), and assign its language identifier. The following example creates a shape, sets British English as the proofing language, and saves the result with [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/):

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Set the proofing language for this text.";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LanguageId = "en-GB";

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **Set the Default Language for New Text**

Use [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) to specify the proofing language that Aspose.Slides assigns to newly created text. This setting is useful when most or all new text in a presentation uses the same language. It does not change the language metadata of text that already has an explicit language.

The following example creates a presentation whose new text uses German proofing rules:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DefaultTextLanguage = "de-DE"
};

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Willkommen zur Präsentation";

presentation.Save("default_text_language.pptx", SaveFormat.Pptx);
```

## **Use Multiple Languages in One Paragraph**

An [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) contains a collection of text portions. Create a separate [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) for each language and set its `LanguageId` independently.

This example creates one paragraph with English and French portions:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var englishPortion = new Portion("Welcome");
englishPortion.PortionFormat.LanguageId = "en-US";
paragraph.Portions.Add(englishPortion);

var frenchPortion = new Portion(" — Bienvenue");
frenchPortion.PortionFormat.LanguageId = "fr-FR";
paragraph.Portions.Add(frenchPortion);

presentation.Save("multilingual_text.pptx", SaveFormat.Pptx);
```

## **Enable or Suppress Spell Checking for Individual Portions**

[IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/) inherits the common text properties defined by [IBasePortionFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/). Access a portion's format through [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/) and set [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/spellcheck/) to control whether a presentation application may check spelling for that portion. The default value is `false`: `true` allows spell checking, while `false` suppresses it.

The setting applies to individual text portions. Different portions in the same paragraph can therefore use different values. [BasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) and `SpellCheck` serve complementary purposes: `LanguageId` identifies the proofing language, while `SpellCheck` determines whether spelling checks are allowed for the portion.

[BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/proofdisabled/) also controls proofing, but it represents the broader "do not proof" state as a [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/). Use `SpellCheck` when you need a direct Boolean switch specifically for spelling checks. Use `ProofDisabled` when you need to preserve or explicitly control the presentation's no-proof metadata, including its `NotDefined` state. If you set both properties, keep their values consistent; do not combine `SpellCheck = true` with `ProofDisabled = NullableBool.True`.

These properties configure proofing metadata used by PowerPoint and other presentation applications. Aspose.Slides does not use them to run dictionary-based spell checking or return a list of misspelled words.

The following complete example creates an input presentation, loads it, assigns different spell-check settings and proofing languages to two portions in the same paragraph, saves the result, reopens it, and verifies the stored values:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputFile = "spell_check_input.pptx";
const string outputFile = "spell_check_settings.pptx";

using (var sourcePresentation = new Presentation())
{
    var sourceSlide = sourcePresentation.Slides[0];
    var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    var sourceParagraph = sourceShape.TextFrame.Paragraphs[0];
    sourceParagraph.Portions.Clear();

    var sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.PortionFormat.LanguageId = "en-US";
    sourceParagraph.Portions.Add(sourceEnglishPortion);

    var sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.PortionFormat.LanguageId = "fr-FR";
    sourceParagraph.Portions.Add(sourceFrenchPortion);

    sourcePresentation.Save(inputFile, SaveFormat.Pptx);
}

using (var presentation = new Presentation(inputFile))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var portions = shape.TextFrame.Paragraphs[0].Portions;

    var checkedPortion = portions[0];
    checkedPortion.PortionFormat.LanguageId = "en-US";
    checkedPortion.PortionFormat.SpellCheck = true;

    var suppressedPortion = portions[1];
    suppressedPortion.PortionFormat.LanguageId = "fr-FR";
    suppressedPortion.PortionFormat.SpellCheck = false;

    presentation.Save(outputFile, SaveFormat.Pptx);
}

using var reopenedPresentation = new Presentation(outputFile);
var reopenedShape = (IAutoShape)reopenedPresentation.Slides[0].Shapes[0];
var storedPortions = reopenedShape.TextFrame.Paragraphs[0].Portions;

var firstPortionStored = storedPortions.Count == 2 &&
    storedPortions[0].PortionFormat.LanguageId == "en-US" &&
    storedPortions[0].PortionFormat.SpellCheck;

var secondPortionStored = storedPortions.Count == 2 &&
    storedPortions[1].PortionFormat.LanguageId == "fr-FR" &&
    !storedPortions[1].PortionFormat.SpellCheck;

if (firstPortionStored && secondPortionStored)
{
    Console.WriteLine("The proofing settings were stored correctly.");
}
else
{
    Console.WriteLine("The proofing settings could not be verified.");
}
```

[Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/net/aspose.slides/presentation/joinportionswithsameformatting/) combines adjacent portions that have the same formatting. A difference in `SpellCheck` alone does not keep such portions separate; after they are joined, the resulting portion retains the `SpellCheck` value of the first portion. If portions need different spell-check settings, call `JoinPortionsWithSameFormatting` before assigning those settings, or inspect the resulting portion boundaries and reapply the settings afterward. Portions with different `LanguageId` values remain separate because their proofing-language formatting differs.

## **FAQ**

**Does a language ID translate the text?**

No. [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) stores proofing metadata for spelling and grammar; it does not alter the text content. Translate the text separately, and then set the appropriate language identifier for each translated portion.

**Does the proofing language control fonts, hyphenation, or line wrapping?**

No. The language identifier is for proofing. Text rendering and layout primarily depend on the available [fonts](/slides/net/powerpoint-fonts/), the writing system, and the text-frame settings. For reliable rendering, provide the required fonts, configure [font substitution](/slides/net/font-substitution/), or [embed fonts](/slides/net/embedded-font/) in the presentation.

**Can one paragraph use several proofing languages?**

Yes. Assign each language to a separate portion, as shown in the multilingual paragraph example.

**Should I use `DefaultTextLanguage` or `LanguageId`?**

Use [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) when you want a default for newly created text. Use [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) when a specific portion needs an explicit proofing language or when a paragraph contains multiple languages.
