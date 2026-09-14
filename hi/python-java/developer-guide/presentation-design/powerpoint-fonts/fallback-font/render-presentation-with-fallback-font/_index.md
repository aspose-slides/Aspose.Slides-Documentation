---
title: Python के माध्यम से Java में फ़ॉलबैक फ़ॉन्ट्स के साथ प्रस्तुतियों को रेंडर करें
linktitle: प्रस्तुतियों को रेंडर करें
type: docs
weight: 30
url: /hi/python-java/render-presentation-with-fallback-font/
keywords:
- फ़ॉलबैक फ़ॉन्ट
- PowerPoint रेंडर करें
- प्रस्तुति रेंडर करें
- स्लाइड रेंडर करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides के लिए Python के माध्यम से Java में फ़ॉलबैक फ़ॉन्ट्स के साथ प्रस्तुतियों को रेंडर करें – PPT, PPTX और ODP में टेक्स्ट को निरंतर बनाए रखने के लिए चरणबद्ध Python कोड नमूने प्रदान करता है।"
---
## **अवलोकन**

Aspose.Slides आपको फ़ॉलबैक फ़ॉन्ट नियमों का उपयोग करके प्रस्तुतियों को रेंडर करने की अनुमति देता है। यह लेख दिखाता है कि कैसे फ़ॉलबैक फ़ॉन्ट नियमों का संग्रह बनाया जाए, नियमों को फ़ॉन्ट हटाकर या जोड़कर संशोधित किया जाए, और संग्रह को [FontsManager.setFontFallBackRulesCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) मेथड का उपयोग करके निर्दिष्ट किया जाए।

एक बार फ़ॉलबैक फ़ॉन्ट नियमों का संग्रह प्रस्तुति के [FontsManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/) को सौंप दिया जाता है, तो नियमों को सहेजने, रेंडर करने और प्रस्तुति को परिवर्तित करने जैसी ऑपरेशनों के दौरान लागू किया जाता है। यह उदाहरण दिखाता है कि स्लाइड थंबनेल को रेंडर करते समय और उसे JPEG छवि के रूप में सहेजते समय कॉन्फ़िगर किए गए नियमों का कैसे उपयोग किया जाता है।

## **फ़ॉलबैक फ़ॉन्ट नियमों का उपयोग करके स्लाइड रेंडर करना**

1. [फ़ॉलबैक फ़ॉन्ट नियमों का संग्रह बनाएं](/slides/hi/python-java/create-fallback-fonts-collection/)।
1. [हटाएँ](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontfallbackrule/#remove) एक नियम से फ़ॉलबैक फ़ॉन्ट और [फ़ॉलबैक फ़ॉन्ट जोड़ें](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) दूसरे नियम में।
1. [getFontsManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getFontsManager) द्वारा लौटाए गए फ़ॉन्ट मैनेज़र पर [setFontFallBackRulesCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) का उपयोग करके नियम संग्रह को सौंपें।
1. प्रस्तुति को समान प्रारूप या किसी अन्य प्रारूप में सहेजने के लिए [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) मेथड का उपयोग करें। एक बार फ़ॉलबैक फ़ॉन्ट नियमों का संग्रह [FontsManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/) को सौंप दिया जाता है, तो ये नियम प्रस्तुति पर किए जाने वाले सभी ऑपरेशनों—जैसे सहेजना, रेंडर करना, परिवर्तित करना आदि—के दौरान लागू होते हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, ImageFormat, Presentation

# नया नियम संग्रह बनाएँ।
fallback_rules = FontFallBackRulesCollection()

# कई नियम बनाएँ।
cyrillic_rule = FontFallBackRule(0x400, 0x4FF, "Times New Roman")
fallback_rules.add(cyrillic_rule)
arabic_rule = FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial")
fallback_rules.add(arabic_rule)

for fallback_rule in fallback_rules:
    # नियमों से फ़ॉलबैक फ़ॉन्ट "Tahoma" को हटाने का प्रयास करें।
    fallback_rule.remove("Tahoma")

    # निर्धारित सीमा के लिए नियम अपडेट करें।
    if fallback_rule.getRangeEndIndex() >= 0x400 and fallback_rule.getRangeStartIndex() < 0x500:
        fallback_rule.addFallBackFonts("Verdana")

# एक मौजूदा नियम हटाएँ, रेंडरिंग के लिए कम से कम एक नियम रखें।
if fallback_rules.size() > 1:
    rule_to_remove = fallback_rules.get_Item(1)
    fallback_rules.remove(rule_to_remove)

presentation = Presentation("input.pptx")
try:
    # तैयार किए गए नियम संग्रह को सौंपें।
    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)

    # कॉन्फ़िगर किए गए नियम संग्रह का उपयोग करके थंबनेल रेंडर करें।
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # छवि को JPEG फ़ॉर्मेट में डिस्क पर सहेजें।
        slide_image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
[Python के माध्यम से Java में PPT और PPTX को JPG में बदलना](/slides/hi/python-java/convert-powerpoint-to-jpg/) के बारे में और पढ़ें।
{{% /alert %}}