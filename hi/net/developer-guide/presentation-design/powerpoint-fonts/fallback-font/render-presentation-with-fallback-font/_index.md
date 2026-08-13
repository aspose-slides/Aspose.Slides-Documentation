---
title: फ़ॉल्बैक फ़ॉन्ट्स के साथ प्रस्तुतियों को .NET में रेंडर करें
linktitle: प्रस्तुतियों को रेंडर करें
type: docs
weight: 30
url: /hi/net/render-presentation-with-fallback-font/
keywords:
- फ़ॉल्बैक फ़ॉन्ट
- PowerPoint रेंडर
- प्रस्तुति रेंडर
- स्लाइड रेंडर
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में फ़ॉल्बैक फ़ॉन्ट्स के साथ प्रस्तुतियों को रेंडर करें – PPT, PPTX और ODP में टेक्स्ट को सुसंगत रखें, चरण-दर-चरण C# कोड नमूनों के साथ।"
---
## **अवलोकन**

Aspose.Slides आपको फॉलबैक फ़ॉन्ट नियमों का उपयोग करके प्रस्तुतियों को रेंडर करने की अनुमति देता है। यह लेख दिखाता है कि कैसे फॉलबैक फ़ॉन्ट नियम संग्रह बनाएं, नियमों को फ़ॉन्ट हटाकर या जोड़कर संशोधित करें, और संग्रह को `FontsManager.FontFallBackRulesCollection` प्रॉपर्टी को असाइन करें।

एक बार फॉलबैक फ़ॉन्ट नियम संग्रह को प्रस्तुति के `FontsManager` को असाइन करने के बाद, नियम सहेजने, रेंडर करने और प्रस्तुति को रूपांतरित करने जैसी कार्यविधियों के दौरान लागू होते हैं। उदाहरण दर्शाता है कि स्लाइड थंबनेल रेंडर करने और उसे PNG छवि के रूप में सहेजने के दौरान कॉन्फ़िगर किए गए नियमों का उपयोग कैसे करें।

## **फॉलबैक फ़ॉन्ट नियमों का उपयोग करके स्लाइड रेंडर करना**

1. हम [फॉलबैक फ़ॉन्ट नियम संग्रह बनाते हैं](/slides/hi/net/create-fallback-fonts-collection/).
2. [Remove()](https://reference.aspose.com/slides/hi/net/aspose.slides/fontfallbackrule/methods/remove) एक फॉलबैक फ़ॉन्ट नियम हटाता है और [AddFallBackFonts()](https://reference.aspose.com/slides/hi/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) दूसरे नियम में जोड़ता है।
3. नियम संग्रह को [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) प्रॉपर्टी पर सेट करें।
4. हम [Presentation.Save()](https://reference.aspose.com/slides/hi/net/aspose.slides.presentation/save/methods/4) मेथड के साथ प्रस्तुति को उसी फ़ॉर्मेट में सहेज सकते हैं, या किसी अन्य फ़ॉर्मेट में। फॉलबैक फ़ॉन्ट नियम संग्रह को FontsManager पर सेट करने के बाद, ये नियम प्रस्तुति पर किए गए किसी भी ऑपरेशन के दौरान लागू होते हैं: सहेजना, रेंडर करना, रूपांतरित करना, आदि।

```c#
using Aspose.Slides;

// Create new instance of a rules collection
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

//	create a number of rules
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.Add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// Trying to remove FallBack font "Tahoma" from loaded rules
	fallBackRule.Remove("Tahoma");

	// And to update of rules for specified range
	if ((fallBackRule.RangeEndIndex >= 0x400) && (fallBackRule.RangeStartIndex < 0x500))
		fallBackRule.AddFallBackFonts("Verdana");
}

// Also we can remove any existing rules from list, keeping at least one rule to render with
if (rulesList.Count > 1)
	rulesList.Remove(rulesList[1]);

using (Presentation pres = new Presentation("input.pptx"))
{
    // Assigning a prepared rules list for using
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // Rendering of thumbnail with using of initialized rules collection and saving to PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="info" %}} 
[प्रस्तुति में सहेजना और रूपांतरण](/slides/hi/net/convert-powerpoint-to-png/) के बारे में और पढ़ें। 
{{% /alert %}}