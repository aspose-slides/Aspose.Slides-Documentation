---
title: Configure Font Substitution in Presentations Using С++
linktitle: Font Substitution
type: docs
weight: 70
url: /cpp/font-substitution/
keywords:
- font
- substitute font
- font substitution
- replace font
- font replacement
- substitution rule
- replacement rule
- PowerPoint
- OpenDocument
- presentation
- С++
- Aspose.Slides
description: "Enable optimal font substitution in Aspose.Slides for С++ when converting PowerPoint & OpenDocument presentations to other file formats."
---

## **Set Font Substitution Rules**

Aspose.Slides allows you to set rules for fonts that determines what must be done in certain conditions (for example, when a font cannot be accessed) this way:

1. Load the relevant presentation.
2. Load the font that will be replaced.
3. Load the new font.
4. Add a rule for the replacement.
5. Add the rule to the presentation font replacement rule collection.
6. Generate the slide image to observe the effect.

This C++ code demonstrates the font substitution process:

```c++
// The path to the documents directory.
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Loads a presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Defines the font that will be replaced and the new font
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// Adds a font rule for font replacement
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// Adds the rule to font substitute rules collection
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// Adds the font rule collection to the rule list
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// Saves PPTX to disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 

You may want to see [**Font Replacement**](/slides/cpp/font-replacement/). 

{{% /alert %}}

## **FAQ**

**What is the difference between font replacement and font substitution?**

[Replacement](/slides/cpp/font-replacement/) is a forced override of one font with another across the entire presentation. Substitution is a rule that triggers under a specific condition, for example when the original font is unavailable, and then a designated fallback font is used.

**When exactly are substitution rules applied?**

The rules participate in the standard [font selection](/slides/cpp/font-selection-sequence/) sequence that is evaluated during loading, rendering, and conversion; if the chosen font is unavailable, replacement or substitution is applied.

**What is the default behavior if neither replacement nor substitution is configured and the font is missing on the system?**

The library will try to pick the closest available system font, similar to how PowerPoint would behave.

**Can I attach custom external fonts at runtime to avoid substitution?**

Yes. You can [add external fonts](/slides/cpp/custom-font/) at runtime so the library considers them for selection and rendering, including for subsequent conversions.

**Does Aspose distribute any fonts with the library?**

No. Aspose does not distribute paid or free fonts; you add and use fonts at your own discretion and responsibility.

**Are there differences in substitution behavior on Windows, Linux, and macOS?**

Yes. Font discovery starts from the operating system’s font directories. The set of default available fonts and the search paths differ across platforms, which affects availability and the need for substitution.

**How should I prepare the environment to minimize unexpected substitution during batch conversions?**

Synchronize the font set across machines or containers, [add the external fonts](/slides/cpp/custom-font/) required for the output documents, and [embed fonts](/slides/cpp/embedded-font/) in presentations when possible so the chosen fonts are available during rendering.
