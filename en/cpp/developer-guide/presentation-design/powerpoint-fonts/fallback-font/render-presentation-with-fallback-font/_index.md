---
title: Render Presentations with Fallback Fonts in С++
linktitle: Render Presentations
type: docs
weight: 30
url: /cpp/render-presentation-with-fallback-font/
keywords:
- fallback font
- render PowerPoint
- render presentation
- render slide
- PowerPoint
- OpenDocument
- presentation
- С++
- Aspose.Slides
description: "Render presentations with fallback fonts in Aspose.Slides for С++ – keep text consistent across PPT, PPTX and ODP with step-by-step С++ code samples."
---

The following example includes these steps:

1. We [create fallback font rules collection](/slides/cpp/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/remove/) a fallback font rule and [AddFallBackFonts()](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) to another rule.
1. Pass the rules collection to [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) method.
1. With [Presentation::Save()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) method we can save presentation in the same format, or save it in another one. After fallback font rules collection is set to FontsManager, these rules are applied during any operations over the presentation: save, render, convert, etc.

``` cpp
// Create new instance of a rules collection
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Create a number of rules
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Trying to remove FallBack font "Tahoma" from loaded rules
	fallBackRule->Remove(u"Tahoma");

	// And to update of rules for specified range
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) && 
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// Also we can remove any existing rules from list
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// Assigning a prepared rules list for using
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Rendering of thumbnail with using of initialized rules collection and saving to PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```


{{% alert color="primary" %}} 
Read more about how to [Convert PowerPoint Slides to PNG in C++](/slides/cpp/convert-powerpoint-to-png/).
{{% /alert %}}
