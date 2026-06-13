---
title: Python में फॉलबैक फ़ॉन्ट्स के साथ प्रस्तुतियों को रेंडर करें
linktitle: प्रस्तुतियों को रेंडर करें
type: docs
weight: 30
url: /hi/python-net/render-presentation-with-fallback-font/
keywords:
- फॉलबैक फ़ॉन्ट
- PowerPoint रेंडर करें
- प्रस्तुति रेंडर करें
- स्लाइड रेंडर करें
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python में फॉलबैक फ़ॉन्ट्स के साथ प्रस्तुतियों को .NET के माध्यम से रेंडर करें – PPT, PPTX और ODP में टेक्स्ट को सुसंगत रखें, चरण-दर-चरण कोड नमूनों के साथ।"
---
## **अवलोकन**

Aspose.Slides आपको फॉलबैक फ़ॉन्ट नियमों का उपयोग करके प्रस्तुतियों को रेंडर करने की अनुमति देता है। यह लेख दिखाता है कि कैसे एक फॉलबैक फ़ॉन्ट नियम संग्रह बनाया जाए, नियमों को फॉलबैक फ़ॉन्ट हटाकर या जोड़कर संशोधित किया जाए, और संग्रह को `FontsManager.font_fall_back_rules_collection` गुण को असाइन किया जाए।

एक बार फॉलबैक फ़ॉन्ट नियम संग्रह को प्रेज़ेंटेशन के `fonts_manager` को असाइन कर दिया जाता है, तो ये नियम सहेजना, रेंडर करना और प्रेज़ेंटेशन को कनवर्ट करना जैसे ऑपरेशनों के दौरान लागू होते हैं। यह उदाहरण दिखाता है कि कैसे कॉन्फ़िगर किए गए नियमों को स्लाइड थंबनेल रेंडर करने और उसे PNG इमेज के रूप में सहेजने के दौरान उपयोग किया जाता है।

## **फॉलबैक फ़ॉन्ट नियमों का उपयोग करके स्लाइड रेंडर करना**

1. हम [फ़ॉलबैक फ़ॉन्ट नियम संग्रह बनाते हैं](/slides/hi/python-net/create-fallback-fonts-collection/)।
2. [हटाएँ](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontfallbackrule/remove/) एक फ़ॉलबैक फ़ॉन्ट नियम और [add_fall_back_fonts](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) दूसरे नियम में जोड़ें।
3. नियम संग्रह को [FontsManager.font_fall_back_rules_collection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/) गुण पर सेट करें।
4. [Presentation.save()](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) विधि के साथ हम प्रस्तुति को उसी फॉर्मेट में या किसी अलग फॉर्मेट में सहेज सकते हैं। फॉलबैक फ़ॉन्ट नियम संग्रह को FontsManager पर सेट करने के बाद, ये नियम प्रस्तुति के किसी भी ऑपरेशन—सहेजना, रेंडर करना, कनवर्ट करना इत्यादि—के दौरान लागू होते हैं।

```py
import aspose.slides as slides

# नियम संग्रह का नया उदाहरण बनाएं
rulesList = slides.FontFallBackRulesCollection()

# कई नियम बनाएं
rulesList.add(slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"))

for fallBackRule in rulesList:
	# लोड किए गए नियमों से फ़ॉलबैक फ़ॉन्ट "Tahoma" को हटाने का प्रयास
	fallBackRule.remove("Tahoma")

	# निर्दिष्ट सीमा के लिए नियमों को अपडेट करना
	if fallBackRule.range_end_index >= 0x4000 and fallBackRule.range_start_index < 0x5000:
		fallBackRule.add_fall_back_fonts("Verdana")

# हम सूची से किसी भी मौजूदा नियम को हटा सकते हैं
if len(rulesList) > 0:
	rulesList.remove(rulesList[0])

with slides.Presentation(path + "input.pptx") as pres:
	# उपयोग के लिए तैयार नियम सूची को असाइन कर रहे हैं
	pres.fonts_manager.font_fall_back_rules_collection = rulesList

	# थंबनेल को रेंडर कर रहे हैं, प्रारंभित नियम संग्रह का उपयोग करके और PNG में सहेज रहे हैं
	with pres.slides[0].get_image(1, 1) as img:
		img.save("Slide_0.png", slides.ImageFormat.PNG)
```

{{% alert color="primary" %}} 
और पढ़ें कि कैसे [Python में PowerPoint स्लाइड्स को PNG में बदलें](/slides/hi/python-net/convert-powerpoint-to-png/)।
{{% /alert %}}