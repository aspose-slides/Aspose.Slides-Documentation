---
title: फ़ॉलबैक फ़ॉन्ट के साथ C++ में प्रस्तुतियों को रेंडर करें
linktitle: प्रस्तुतियों को रेंडर करें
type: docs
weight: 30
url: /hi/cpp/render-presentation-with-fallback-font/
keywords:
- फ़ॉलबैक फ़ॉन्ट
- PowerPoint रेंडर करें
- प्रस्तुति रेंडर करें
- स्लाइड रेंडर करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides के लिए C++ में फ़ॉलबैक फ़ॉन्ट के साथ प्रस्तुतियों को रेंडर करें – PPT, PPTX और ODP में टेक्स्ट को संगत रखें, चरण-दर-चरण C++ कोड नमूनों के साथ।"
---
## **अवलोकन**

Aspose.Slides आपको फॉलबैक फ़ॉन्ट नियमों का उपयोग करके प्रस्तुतियों को रेंडर करने की अनुमति देता है। यह लेख दिखाता है कि फॉलबैक फ़ॉन्ट नियमों का संग्रह कैसे बनाया जाए, नियमों को फ़ॉन्ट हटाकर या जोड़कर कैसे संशोधित किया जाए, और `FontsManager::set_FontFallBackRulesCollection` मेथड का उपयोग करके संग्रह को कैसे असाइन किया जाए।

एक बार फॉलबैक फ़ॉन्ट नियमों का संग्रह प्रस्तुति के `FontsManager` को असाइन हो जाने पर, नियम सहेजने, रेंडर करने और प्रस्तुति को कनवर्ट करने जैसी ऑपरेशनों के दौरान लागू हो जाते हैं। यह उदाहरण दिखाता है कि स्लाइड थंबनेल को रेंडर करते समय और उसे PNG छवि के रूप में सहेजते समय कॉन्फ़िगर किए गए नियमों का कैसे उपयोग किया जाए।

## **फ़ॉल्बैक फ़ॉन्ट नियमों का उपयोग करके स्लाइड रेंडर करें**

1. हम [फ़ॉलबैक फ़ॉन्ट नियमों का संग्रह बनाते हैं](/slides/hi/cpp/create-fallback-fonts-collection/)।
2. एक फ़ॉलबैक फ़ॉन्ट नियम को [Remove()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontfallbackrule/remove/) हटाएँ और किसी अन्य नियम में [AddFallBackFonts()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) जोड़ें।
3. नियमों के संग्रह को [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) मेथड को पास करें।
4. [Presentation::Save()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/save/) मेथड के साथ हम प्रस्तुति को उसी फ़ॉर्मेट में या किसी अन्य फ़ॉर्मेट में सहेज सकते हैं। फॉलबैक फ़ॉन्ट नियमों का संग्रह FontsManager में सेट होने के बाद, ये नियम प्रस्तुति पर की जाने वाली सभी ऑपरेशनों के दौरान लागू होते हैं: सहेजना, रेंडर करना, कनवर्ट करना, आदि।

``` cpp
// नियम संग्रह का नया उदाहरण बनाएं
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// कई नियम बनाएं
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// लोड किए गए नियमों से फ़ॉलबैक फ़ॉन्ट "Tahoma" हटाने का प्रयास
	fallBackRule->Remove(u"Tahoma");

	// और निर्दिष्ट रेंज के लिए नियमों को अपडेट करना
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) && 
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// हम सूची से कोई भी मौजूदा नियम हटा सकते हैं
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// उपयोग के लिए तैयार नियम सूची असाइन कर रहे हैं
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// इनिशियलाइज़्ड नियम संग्रह का उपयोग करके थंबनेल रेंडर करना और PNG में सहेजना
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="primary" %}} 
C++ में PowerPoint स्लाइड्स को PNG में कैसे कनवर्ट करें, इस बारे में और पढ़ें: [C++ में PowerPoint स्लाइड्स को PNG में कनवर्ट करें](/slides/hi/cpp/convert-powerpoint-to-png/)।
{{% /alert %}}