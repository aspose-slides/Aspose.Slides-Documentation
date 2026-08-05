---
title: फ़ॉलबैक फ़ॉन्ट्स के साथ C++ में प्रस्तुतियों को रेंडर करें
linktitle: प्रस्तुतियों को रेंडर करें
type: docs
weight: 30
url: /hi/cpp/render-presentation-with-fallback-font/
keywords:
- फ़ॉलबैक फ़ॉन्ट
- PowerPoint रेंडर
- प्रस्तुति रेंडर
- स्लाइड रेंडर
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides के लिए C++ में फ़ॉलबैक फ़ॉन्ट्स के साथ प्रस्तुतियों को रेंडर करें – PPT, PPTX और ODP में टेक्स्ट को सुसंगत रखें, चरण-दर-चरण C++ कोड नमूनों के साथ।"
---
## **अवलोकन**

Aspose.Slides आपको फॉलबैक फ़ॉन्ट नियमों का उपयोग करके प्रस्तुतियों को रेंडर करने की अनुमति देता है। यह लेख दर्शाता है कि फॉलबैक फ़ॉन्ट नियमों का संग्रह कैसे बनाया जाए, नियमों को फॉलबैक फ़ॉन्ट हटाकर या जोड़कर कैसे संशोधित किया जाए, और `FontsManager::set_FontFallBackRulesCollection` मेथड का उपयोग करके संग्रह को कैसे असाइन किया जाए।

एक बार फॉलबैक फ़ॉन्ट नियमों का संग्रह प्रस्तुति के `FontsManager` को असाइन हो जाने के बाद, नियमों को सहेजने, रेंडर करने और प्रस्तुति को परिवर्तित करने जैसी प्रक्रियाओं के दौरान लागू किया जाता है। यह उदाहरण दिखाता है कि स्लाइड थंबनेल को रेंडर करते समय और उसे PNG छवि के रूप में सहेजते समय कॉन्फ़िगर किए गए नियमों का कैसे उपयोग किया जाता है।

## **फ़ॉल्बैक फ़ॉन्ट नियमों का उपयोग करके स्लाइड रेंडर करना**

निम्नलिखित उदाहरण में ये चरण शामिल हैं:

1. We [फ़ॉलबैक फ़ॉन्ट नियमों का संग्रह बनाएँ](/slides/hi/cpp/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontfallbackrule/remove/) एक फ़ॉलबैक फ़ॉन्ट नियम को हटाएँ और [AddFallBackFonts()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) किसी अन्य नियम में जोड़ें।
1. नियमों के संग्रह को [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) मेथड को पास करें।
1. [Presentation::Save()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/save/) मेथड का उपयोग करके हम प्रस्तुति को उसी फॉर्मेट में सहेज सकते हैं, या किसी अन्य फॉर्मेट में सहेज सकते हैं। फ़ॉलबैक फ़ॉन्ट नियमों का संग्रह FontsManager को सेट होने के बाद, ये नियम प्रस्तुति पर किए जाने वाले किसी भी ऑपरेशन के दौरान लागू होते हैं: सहेजना, रेंडर करना, परिवर्तित करना, आदि।

``` cpp
// नियम संग्रह का नया उदाहरण बनाएं
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// कई नियम बनाएं
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// लोड किए गए नियमों से फॉलबैक फ़ॉन्ट "Tahoma" को हटाने का प्रयास
	fallBackRule->Remove(u"Tahoma");

	// और निर्दिष्ट रेंज के लिए नियमों को अपडेट करना
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) && 
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// हम सूची से किसी भी मौजूदा नियम को भी हटा सकते हैं
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// उपयोग के लिए तैयार नियम सूची को असाइन करना
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// आरंभ किए गए नियम संग्रह का उपयोग करके थंबनेल रेंडर करना और PNG में सहेजना
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```


{{% alert color="primary" %}} 
और अधिक जानें कि C++ में [PowerPoint स्लाइड को PNG में कैसे परिवर्तित करें](/slides/hi/cpp/convert-powerpoint-to-png/)। 
{{% /alert %}}