---
title: Font Substitution
type: docs
weight: 70
url: /cpp/font-substitution/
keywords: "Font, substitute font, PowerPoint presentation, C++, CPP, Aspose.Slides for C++"
description: "Substitute font in PowerPoint in C++"
---

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

