---
title: C++ में fallback फ़ॉन्ट्स के साथ प्रस्तुतियों को रेंडर करें
linktitle: प्रस्तुतियों को रेंडर करें
type: docs
weight: 30
url: /hi/cpp/render-presentation-with-fallback-font/
keywords:
- fallback फ़ॉन्ट
- PowerPoint रेंडर करें
- प्रस्तुति रेंडर करें
- स्लाइड रेंडर करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में fallback फ़ॉन्ट्स के साथ प्रस्तुतियों को रेंडर करें – PPT, PPTX और ODP में टेक्स्ट को सुसंगत रखने के लिए चरण-दर-चरण C++ कोड नमूने प्रदान करता है।"
---
## **Overview**

Aspose.Slides आपको fallback फ़ॉन्ट नियमों का उपयोग करके प्रस्तुतियों को रेंडर करने की अनुमति देता है। यह लेख दिखाता है कि कैसे fallback फ़ॉन्ट नियमों का संग्रह बनाया जाए, नियमों को हटाकर या फ़ॉन्ट जोड़कर संशोधित किया जाए, और `FontsManager::set_FontFallBackRulesCollection` मेथड का उपयोग करके इस संग्रह को असाइन किया जाए।

एक बार fallback फ़ॉन्ट नियमों का संग्रह प्रस्तुति के `FontsManager` को असाइन हो जाने के बाद, ये नियम सहेजने, रेंडर करने और प्रस्तुतियों को बदलने जैसे कार्यों के दौरान लागू होते हैं। उदाहरण दर्शाता है कि कॉन्फ़िगर किए गए नियमों का उपयोग स्लाइड थंबनेल रेंडर करने और उसे PNG छवि के रूप में सहेजने में कैसे किया जाता है।

## **Render a Slide Using Fallback Font Rules**

निम्न उदाहरण में ये चरण शामिल हैं:

1. हम [fallback फ़ॉन्ट नियम संग्रह बनाते हैं](/slides/hi/cpp/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontfallbackrule/remove/) एक fallback फ़ॉन्ट नियम हटाते हैं और [AddFallBackFonts()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) को दूसरे नियम में जोड़ते हैं.
1. नियम संग्रह को [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) मेथड को पास करें.
1. [Presentation::Save()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/save/) मेथड के साथ हम प्रस्तुति को उसी प्रारूप में या किसी अन्य प्रारूप में सहेज सकते हैं। fallback फ़ॉन्ट नियम संग्रह को FontsManager में सेट करने के बाद, ये नियम प्रस्तुति पर किए जाने वाले सभी कार्यों जैसे सहेजना, रेंडर करना, बदलना आदि के दौरान लागू होते हैं.

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <DOM/Fonts/FontFallBackRulesCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

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
image->Save(u"Slide_0.png", Aspose::Slides::ImageFormat::Png);
image->Dispose();

pres->Dispose();
```


{{% alert color="info" %}} 
और अधिक पढ़ें कि C++ में [PowerPoint स्लाइड्स को PNG में कैसे बदलें](/slides/hi/cpp/convert-powerpoint-to-png/).
{{% /alert %}}