---
title: Python के माध्यम से Java में फॉलबैक फ़ॉन्ट संग्रह को कॉन्फ़िगर करें
linktitle: फॉलबैक फ़ॉन्ट संग्रह
type: docs
weight: 20
url: /hi/python-java/create-fallback-fonts-collection/
keywords:
- फॉलबैक फ़ॉन्ट
- फॉलबैक नियम
- फ़ॉन्ट संग्रह
- फ़ॉन्ट कॉन्फ़िगर करें
- फ़ॉन्ट सेट अप करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides के लिए Python द्वारा Java में फॉलबैक फ़ॉन्ट संग्रह सेट अप करें ताकि PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट सुसंगत और स्पष्ट रहे।"
---
## **सारांश**

Aspose.Slides आपको प्रस्तुति के लिए फॉलबैक फ़ॉन्ट नियमों का संग्रह कॉन्फ़िगर करने की अनुमति देता है। प्रत्येक फॉलबैक नियम को [FontFallBackRule](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontfallbackrule/) क्लास द्वारा प्रतिनिधित्व किया जाता है और इसे एक [FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontfallbackrulescollection/) में जोड़ा जा सकता है।

संग्रह बनाने के बाद, आप इसे प्रस्तुति के [FontsManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/) की [setFontFallBackRulesCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) विधि का उपयोग करके असाइन कर सकते हैं। [FontsManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/) प्रस्तुति भर में फ़ॉन्ट्स को नियंत्रित करता है, और प्रत्येक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) उदाहरण का अपना एक [FontsManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/) होता है।

एक बार [FontsManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/) को फॉलबैक फ़ॉन्ट संग्रह के साथ प्रारंभ कर दिया जाता है, तो निर्दिष्ट फॉलबैक फ़ॉन्ट्स प्रस्तुति रेंडरिंग के दौरान लागू होते हैं।

## **फ़ॉलबैक नियम लागू करें**

[FontFallBackRule](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontfallbackrule/) क्लास के उदाहरणों को एक [FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontfallbackrulescollection/) में व्यवस्थित किया जा सकता है। आप संग्रह से नियम जोड़ या हटा सकते हैं।

इस संग्रह को फिर [FontsManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/) क्लास की [setFontFallBackRulesCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) विधि का उपयोग करके असाइन किया जा सकता है, जो प्रस्तुति भर में फ़ॉन्ट्स को नियंत्रित करता है।

प्रत्येक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) के पास एक [getFontsManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getFontsManager) विधि होती है जो उसके अपने [FontsManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/) इंस्टेंस को लौटाती है।

निम्नलिखित उदाहरण दर्शाता है कि फॉलबैक फ़ॉन्ट नियमों का संग्रह कैसे बनाएं और उसे प्रस्तुति के [FontsManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/) को असाइन करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, Presentation

presentation = Presentation()
try:
    fallback_rules = FontFallBackRulesCollection()

    tamil_rule = FontFallBackRule(0x0B80, 0x0BFF, "Vijaya")
    fallback_rules.add(tamil_rule)
    hiragana_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")
    fallback_rules.add(hiragana_rule)

    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)
finally:
    presentation.dispose()
```

एक बार [FontsManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/) को फॉलबैक फ़ॉन्ट संग्रह के साथ प्रारंभ कर दिया जाता है, तो फॉलबैक फ़ॉन्ट्स प्रस्तुति रेंडरिंग के दौरान लागू होते हैं।

{{% alert color="info" title="Note" %}}
फॉलबैक फ़ॉन्ट के साथ प्रस्तुति को रेंडर करने के बारे में अधिक पढ़ें: [फॉलबैक फ़ॉन्ट के साथ प्रस्तुति को रेंडर करना](/slides/hi/python-java/render-presentation-with-fallback-font/)।
{{% /alert %}}

## **पूछे जाने वाले प्रश्न**

**क्या मेरे फॉलबैक नियम PPTX फ़ाइल में एम्बेड होंगे और सहेजने के बाद PowerPoint में दिखाई देंगे?**

नहीं। फॉलबैक नियम रन‑टाइम रेंडरिंग सेटिंग्स हैं; वे PPTX में सीरियलाइज़ नहीं किए जाते और PowerPoint के UI में नहीं दिखेंगे।

**क्या फॉलबैक SmartArt, WordArt, चार्ट और टेबल के भीतर के टेक्स्ट पर लागू होता है?**

हाँ। इन वस्तुओं के किसी भी टेक्स्ट के लिए वही ग्लिफ़‑सब्स्टिट्यूशन मेकेनिज़्म उपयोग किया जाता है।

**क्या Aspose लाइब्रेरी के साथ कोई फ़ॉन्ट वितरित करता है?**

नहीं। आप फ़ॉन्ट अपने पक्ष से जोड़ते और उपयोग करते हैं और इसकी पूरी जिम्मेदारी स्वयं लेते हैं।

**क्या गुम फ़ॉन्ट के लिए प्रतिस्थापन/सब्स्टिट्यूशन और गुम ग्लिफ़ के लिए फॉलबैक को साथ में उपयोग किया जा सकता है?**

हाँ। वे एक ही फ़ॉन्ट‑रिज़ॉल्यूशन पाइपलाइन के स्वतंत्र चरण हैं: पहले इंजन फ़ॉन्ट उपलब्धता को हल करता है ([replacement](/slides/hi/python-java/font-replacement/)/[substitution](/slides/hi/python-java/font-substitution/)), फिर फॉलबैक उपलब्ध फ़ॉन्ट्स में गुम ग्लिफ़ के लिए अंतर भरता है।