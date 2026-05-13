---
title: Configure Fallback Font Collections in С++
linktitle: Fallback Font Collection
type: docs
weight: 20
url: /cpp/create-fallback-fonts-collection/
keywords:
- fallback font
- fallback rule
- font collection
- configure font
- set up font
- PowerPoint
- OpenDocument
- presentation
- С++
- Aspose.Slides
description: "Set up a fallback fonts collection in Aspose.Slides for С++ to keep text consistent and crisp in PowerPoint and OpenDocument presentations."
---

## **Overview**

Aspose.Slides allows you to configure a collection of fallback font rules for a presentation. Each fallback rule is represented by the `FontFallBackRule` class and can be added to a `FontFallBackRulesCollection`, which implements the `IFontFallBackRulesCollection` interface.

After creating the collection, you can assign it using the `set_FontFallBackRulesCollection` method of the presentation’s `FontsManager`. The `FontsManager` controls fonts across the presentation, and each `Presentation` instance has its own `FontsManager`.

Once the `FontsManager` is initialized with the fallback font collection, the specified fallback fonts are applied during presentation rendering.

## **Apply Fallback Rules**

Instances of [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/) class can be organized into [FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrulescollection/), that implements [IFontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ifontfallbackrulescollection/) interface. It is possible to add or remove rules from the collection.

Then this collection may be passed to [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) method of the [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/) class. FontsManager controls fonts across the presentation.

Each [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) has a [get_FontsManager()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/) method with its own instance of the FontsManager class.

Here is an examples how to create fallback fonts rules collection and assign in into the FontsManager of a certain presentation:  

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

After FontsManager is initialised with fallback fonts collection, the fallback fonts are applied during presentation rendering.

{{% alert color="primary" %}} 
Read more how to [Render Presentation with Fallback Font](/slides/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Will my fallback rules be embedded into the PPTX file and visible in PowerPoint after saving?**

No. Fallback rules are runtime rendering settings; they are not serialized into PPTX and will not appear in PowerPoint's UI.

**Does fallback apply to text inside SmartArt, WordArt, charts, and tables?**

Yes. The same glyph-substitution mechanism is used for any text in these objects.

**Does Aspose distribute any fonts with the library?**

No. You add and use fonts on your side and under your own responsibility.

**Can replacement/substitution for missing fonts and fallback for missing glyphs be used together?**

Yes. They are independent stages of the same font-resolution pipeline: first the engine resolves font availability ([replacement](/slides/cpp/font-replacement/)/[substitution](/slides/cpp/font-substitution/)), then fallback fills gaps for missing glyphs in available fonts.
