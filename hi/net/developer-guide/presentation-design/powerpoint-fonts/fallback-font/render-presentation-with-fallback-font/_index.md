---
title: .NET में फ़ॉल्बैक फ़ॉन्ट के साथ प्रस्तुतियों को रेंडर करें
linktitle: प्रस्तुतियों को रेंडर करें
type: docs
weight: 30
url: /hi/net/render-presentation-with-fallback-font/
keywords:
- फ़ॉल्बैक फ़ॉन्ट
- PowerPoint को रेंडर करें
- प्रस्तुति रेंडर करें
- स्लाइड रेंडर करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: ".NET के लिए Aspose.Slides में फ़ॉल्बैक फ़ॉन्ट के साथ प्रस्तुतियों को रेंडर करें – PPT, PPTX और ODP में टेक्स्ट को सुसंगत रखें, चरण-दर-चरण C# कोड नमूनों के साथ।"
---
## **सारांश**

Aspose.Slides आपको फ़ॉल्बैक फ़ॉन्ट नियमों का उपयोग करके प्रस्तुतियों को रेंडर करने की अनुमति देता है। यह लेख दिखाता है कि कैसे फ़ॉल्बैक फ़ॉन्ट नियमों का संग्रह बनाया जाए, नियमों को हटाकर या फ़ॉल्बैक फ़ॉन्ट जोड़कर संशोधित किया जाए, और इस संग्रह को `FontsManager.FontFallBackRulesCollection` प्रॉपर्टी में असाइन किया जाए।

एक बार फ़ॉल्बैक फ़ॉन्ट नियमों का संग्रह प्रस्तुति के `FontsManager` को असाइन हो जाए, तो नियम सहेजने, रेंडर करने और प्रस्तुति को रूपांतरित करने जैसे कार्यों के दौरान लागू होते हैं। यह उदाहरण दिखाता है कि स्लाइड थंबनेल रेंडर करते समय और इसे PNG छवि के रूप में सहेजते समय कॉन्फ़िगर किए गए नियमों का कैसे उपयोग किया जाए।

## **फ़ॉल्बैक फ़ॉन्ट नियमों का उपयोग करके स्लाइड रेंडर करना**

1. हम [फ़ॉल्बैक फ़ॉन्ट नियमों का संग्रह बनाएं](/slides/hi/net/create-fallback-fonts-collection/)।
2. [Remove()](https://reference.aspose.com/slides/hi/net/aspose.slides/fontfallbackrule/methods/remove) एक फ़ॉल्बैक फ़ॉन्ट नियम को हटाता है और [AddFallBackFonts()](https://reference.aspose.com/slides/hi/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) दूसरे नियम में जोड़ता है।
3. नियम संग्रह को [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) प्रॉपर्टी में सेट करें।
4. [Presentation.Save()](https://reference.aspose.com/slides/hi/net/aspose.slides.presentation/save/methods/4) मेथड के साथ हम प्रस्तुति को उसी फ़ॉर्मेट में सहेज सकते हैं, या किसी अन्य में। फ़ॉल्बैक फ़ॉन्ट नियमों का संग्रह FontsManager में सेट होने के बाद, ये नियम प्रस्तुति पर किए गए किसी भी ऑपरेशन: सहेजना, रेंडर करना, रूपांतरित करना आदि के दौरान लागू होते हैं।

```c#
// नियम संग्रह का नया उदाहरण बनाएं
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// कई नियम बनाएं
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	//लोड किए गए नियमों से फ़ॉल्बैक फ़ॉन्ट "Tahoma" को हटाने का प्रयास
	fallBackRule.Remove("Tahoma");

	//निर्दिष्ट सीमा के लिए नियमों को अपडेट करने के लिए
	if ((fallBackRule.RangeEndIndex >= 0x4000) && (fallBackRule.RangeStartIndex < 0x5000))
		fallBackRule.AddFallBackFonts("Verdana");
}

//हम सूची से कोई भी मौजूदा नियम हटा सकते हैं
if (rulesList.Count > 0)
	rulesList.Remove(rulesList[0]);

using (Presentation pres = new Presentation("input.pptx"))
{
    //उपयोग के लिए तैयार किए गए नियम सूची को असाइन करना
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    //आरंभीकृत नियम संग्रह का उपयोग करके थंबनेल रेंडर करना और PNG में सहेजना
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="primary" %}} 
और अधिक पढ़ें [Save and Convertion in Presentation](/slides/hi/net/convert-powerpoint-to-png/)।
{{% /alert %}}