---
title: Create Fallback Fonts Collection
type: docs
weight: 20
url: /cpp/create-fallback-fonts-collection/
---

Instances of [FontFallBackRule](https://apireference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) class can be organized into [FontFallBackRulesCollection](https://apireference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rules_collection), that implements [https://apireference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rules_collection) interface. It is possible to add or remove rules from the collection.

Then this collection may be passed to [set_FontFallBackRulesCollection() ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager#a375fc71abd64891a39673751d127d924)method of the [FontsManager](https://apireference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager) class. FontsManager controls fonts across the presentation. Read more [About FontsManager and FontsLoader](/slides/cpp/about-fontsmanager-and-fontsloader/).

Each [Presentation ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation)has a [get_FontsManager() ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation#acee582a9c243cbd63e30634c9714514a)method with its own instance of the FontsManager class.

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

