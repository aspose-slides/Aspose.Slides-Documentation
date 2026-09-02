---
title: Automate Presentation Localization in C++
linktitle: Presentation Localization
type: docs
weight: 100
url: /cpp/presentation-localization/
keywords:
- change language
- spell check
- suppress spell check
- proofing language
- language id
- multilingual text
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Set proofing languages for PowerPoint and OpenDocument presentation text in C++ with Aspose.Slides, including defaults and multilingual paragraphs."
---

## **Overview**

Aspose.Slides for C++ lets you configure proofing metadata for individual text portions. Use [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/) to identify the proofing language, [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_spellcheck/) to allow or suppress spelling checks, and [BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_proofdisabled/) to control the broader no-proof state. Because these settings are applied at the portion level, one paragraph can contain multiple languages and different proofing rules.

This article explains how to assign a language to specific text, set the default language for new text with [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/), build multilingual paragraphs, choose between `SpellCheck` and `ProofDisabled`, and preserve the intended settings when using [Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/joinportionswithsameformatting/). These properties store metadata for presentation applications; they do not translate text, perform dictionary-based spell checking, or return misspelled words.

## **Set the Proofing Language for Text**

Create or load a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), access the required text portion through [IPortion::get_PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/get_portionformat/), and assign its language identifier. The following example creates a shape, sets British English as the proofing language, and saves the result with [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Set the proofing language for this text.");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->set_LanguageId(u"en-GB");

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Set the Default Language for New Text**

Use [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) to specify the proofing language that Aspose.Slides assigns to newly created text. This setting is useful when most or all new text in a presentation uses the same language. It does not change the language metadata of text that already has an explicit language.

The following example creates a presentation whose new text uses German proofing rules:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"de-DE");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Willkommen zur Präsentation");

presentation->Save(u"default_text_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Use Multiple Languages in One Paragraph**

An [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) contains a collection of text portions. Create a separate [Portion](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) for each language and set its `LanguageId` independently.

This example creates one paragraph with English and French portions:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto englishPortion = System::MakeObject<Portion>(u"Welcome");
englishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
paragraph->get_Portions()->Add(englishPortion);

auto frenchPortion = System::MakeObject<Portion>(u" — Bienvenue");
frenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
paragraph->get_Portions()->Add(frenchPortion);

presentation->Save(u"multilingual_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Enable or Suppress Spell Checking for Individual Portions**

[IPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/) inherits the common text properties defined by [IBasePortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/). Access a portion's format through [IPortion::get_PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/get_portionformat/) and call [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_spellcheck/) to control whether a presentation application may check spelling for that portion. The default value is `false`: `true` allows spell checking, while `false` suppresses it.

The setting applies to individual text portions. Different portions in the same paragraph can therefore use different values. [BasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) and `SpellCheck` serve complementary purposes: `LanguageId` identifies the proofing language, while `SpellCheck` determines whether spelling checks are allowed for the portion.

[BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_proofdisabled/) also controls proofing, but it represents the broader "do not proof" state as a [NullableBool](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/). Use `SpellCheck` when you need a direct Boolean switch specifically for spelling checks. Use `ProofDisabled` when you need to preserve or explicitly control the presentation's no-proof metadata, including its `NullableBool::NotDefined` state. If you set both properties, keep their values consistent; do not combine `SpellCheck = true` with `ProofDisabled = NullableBool::True`.

These properties configure proofing metadata used by PowerPoint and other presentation applications. Aspose.Slides does not use them to run dictionary-based spell checking or return a list of misspelled words.

The following complete example creates an input presentation, loads it, assigns different spell-check settings and proofing languages to two portions in the same paragraph, saves the result, reopens it, and verifies the stored values:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputFile = u"spell_check_input.pptx";
const System::String outputFile = u"spell_check_settings.pptx";

{
    auto sourcePresentation = System::MakeObject<Presentation>();
    auto sourceSlide = sourcePresentation->get_Slide(0);
    auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
    auto sourceParagraph = sourceShape->get_TextFrame()->get_Paragraph(0);
    sourceParagraph->get_Portions()->Clear();

    auto sourceEnglishPortion = System::MakeObject<Portion>(u"Check this text. ");
    sourceEnglishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    sourceParagraph->get_Portions()->Add(sourceEnglishPortion);

    auto sourceFrenchPortion = System::MakeObject<Portion>(u"Ignorer ce code : ZX-81.");
    sourceFrenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    sourceParagraph->get_Portions()->Add(sourceFrenchPortion);

    sourcePresentation->Save(inputFile, SaveFormat::Pptx);
    sourcePresentation->Dispose();
}

{
    auto presentation = System::MakeObject<Presentation>(inputFile);
    auto firstShape = presentation->get_Slide(0)->get_Shape(0);
    auto shape = System::ExplicitCast<IAutoShape>(firstShape);
    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

    auto checkedPortion = paragraph->get_Portion(0);
    checkedPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    checkedPortion->get_PortionFormat()->set_SpellCheck(true);

    auto suppressedPortion = paragraph->get_Portion(1);
    suppressedPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    suppressedPortion->get_PortionFormat()->set_SpellCheck(false);

    presentation->Save(outputFile, SaveFormat::Pptx);
    presentation->Dispose();
}

auto reopenedPresentation = System::MakeObject<Presentation>(outputFile);
auto reopenedFirstShape = reopenedPresentation->get_Slide(0)->get_Shape(0);
auto reopenedShape = System::ExplicitCast<IAutoShape>(reopenedFirstShape);
auto storedParagraph = reopenedShape->get_TextFrame()->get_Paragraph(0);

bool portionsStored = storedParagraph->get_Portions()->get_Count() == 2;
if (portionsStored)
{
    auto firstStoredPortion = storedParagraph->get_Portion(0);
    auto secondStoredPortion = storedParagraph->get_Portion(1);

    bool firstPortionStored = firstStoredPortion->get_PortionFormat()->get_LanguageId() == u"en-US" && 
        firstStoredPortion->get_PortionFormat()->get_SpellCheck();

    bool secondPortionStored = secondStoredPortion->get_PortionFormat()->get_LanguageId() == u"fr-FR" && 
        !secondStoredPortion->get_PortionFormat()->get_SpellCheck();

    if (firstPortionStored && secondPortionStored)
    {
        System::Console::WriteLine(u"The proofing settings were stored correctly.");
    }
    else
    {
        System::Console::WriteLine(u"The proofing settings could not be verified.");
    }
}
else
{
    System::Console::WriteLine(u"The proofing settings could not be verified.");
}

reopenedPresentation->Dispose();
```

[Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/joinportionswithsameformatting/) combines adjacent portions that have the same formatting. A difference in `SpellCheck` alone does not keep such portions separate; after they are joined, the resulting portion retains the `SpellCheck` value of the first portion. If portions need different spell-check settings, call `JoinPortionsWithSameFormatting` before assigning those settings, or inspect the resulting portion boundaries and reapply the settings afterward. Portions with different `LanguageId` values remain separate because their proofing-language formatting differs.

## **FAQ**

**Does a language ID translate the text?**

No. [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/) stores proofing metadata for spelling and grammar; it does not alter the text content. Translate the text separately, and then set the appropriate language identifier for each translated portion.

**Does the proofing language control fonts, hyphenation, or line wrapping?**

No. The language identifier is for proofing. Text rendering and layout primarily depend on the available [fonts](/slides/cpp/powerpoint-fonts/), the writing system, and the text-frame settings. For reliable rendering, provide the required fonts, configure [font substitution](/slides/cpp/font-substitution/), or [embed fonts](/slides/cpp/embedded-font/) in the presentation.

**Can one paragraph use several proofing languages?**

Yes. Assign each language to a separate portion, as shown in the multilingual paragraph example.

**Should I use `DefaultTextLanguage` or `LanguageId`?**

Use [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) when you want a default for newly created text. Use [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/) when a specific portion needs an explicit proofing language or when a paragraph contains multiple languages.
