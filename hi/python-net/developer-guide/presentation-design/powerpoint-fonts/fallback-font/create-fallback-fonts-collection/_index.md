---
title: Python में फ़ॉलबैक फ़ॉन्ट संग्रह कॉन्फ़िगर करें
linktitle: फ़ॉलबैक फ़ॉन्ट संग्रह
type: docs
weight: 20
url: /hi/python-net/create-fallback-fonts-collection/
keywords:
- फ़ॉलबैक फ़ॉन्ट
- फ़ॉलबैक नियम
- फ़ॉन्ट संग्रह
- फ़ॉन्ट कॉन्फ़िगर करें
- फ़ॉन्ट सेटअप करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET में फ़ॉलबैक फ़ॉन्ट संग्रह सेटअप करें ताकि PowerPoint और OpenDocument प्रस्तुतियों में पाठ सुसंगत और स्पष्ट रहे।"
---
## **अवलोकन**

Aspose.Slides आपको किसी प्रस्तुति के लिए फ़ॉलबैक फ़ॉन्ट नियमों का संग्रह कॉन्फ़िगर करने की सुविधा देता है। प्रत्येक फ़ॉलबैक नियम `FontFallBackRule` क्लास द्वारा दर्शाया जाता है और इसे `FontFallBackRulesCollection` में जोड़ा जा सकता है।

संग्रह बनाने के बाद, आप इसे प्रस्तुति के `fonts_manager` की `font_fall_back_rules_collection` प्रॉपर्टी को असाइन कर सकते हैं। `fonts_manager` प्रस्तुति में फ़ॉन्ट्स को नियंत्रित करता है, और प्रत्येक `Presentation` इंस्टैंस का अपना `FontsManager` होता है।

जब `FontsManager` को फ़ॉलबैक फ़ॉन्ट संग्रह के साथ प्रारम्भ किया जाता है, तो निर्दिष्ट फ़ॉलबैक फ़ॉन्ट्स प्रस्तुति रेंडरिंग के दौरान लागू होते हैं।

## **फ़ॉलबैक नियम लागू करें**

क्लास के [FontFallBackRule](https://reference.aspose.com/slides/hi/python-net/aspose.slides/FontFallBackRule/) के उदाहरणों को [FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontfallbackrulescollection/) में व्यवस्थित किया जा सकता है। संग्रह से नियम जोड़ना या हटाना संभव है।

फिर इस संग्रह को [font_fall_back_rules_collection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/) प्रॉपर्टी को [FontsManager](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/) क्लास में असाइन किया जा सकता है। FontsManager प्रस्तुति में फ़ॉन्ट्स को नियंत्रित करता है।

प्रत्येक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) में एक [fonts_manager](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/fonts_manager/) प्रॉपर्टी होती है जिसमें FontsManager क्लास का अपना इंस्टैंस होता है।

नीचे एक उदाहरण दिया गया है कि कैसे फ़ॉलबैक फ़ॉन्ट नियमों का संग्रह बनाया जाए और किसी विशिष्ट प्रस्तुति के FontsManager में असाइन किया जाए:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```

जब FontsManager को फ़ॉलबैक फ़ॉन्ट संग्रह के साथ प्रारम्भ किया जाता है, तो फ़ॉलबैक फ़ॉन्ट्स प्रस्तुति रेंडरिंग के दौरान लागू होते हैं।

{{% alert color="primary" %}} 
फ़ॉलबैक फ़ॉन्ट के साथ प्रस्तुति रेंडर करने के बारे में अधिक पढ़ें: [फ़ॉलबैक फ़ॉन्ट के साथ प्रस्तुति रेंडर](/slides/hi/python-net/render-presentation-with-fallback-font/). 
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मेरे फ़ॉलबैक नियम PPTX फ़ाइल में एम्बेड हो जाएंगे और सहेजने के बाद PowerPoint में दिखाई देंगे?**

नहीं। फ़ॉलबैक नियम रनटाइम रेंडरिंग सेटिंग्स हैं; वे PPTX में सीरियलाइज़ नहीं होते और PowerPoint के UI में दिखाई नहीं देंगे।

**क्या फ़ॉलबैक SmartArt, WordArt, चार्ट और टेबल के अंदर के टेक्स्ट पर लागू होता है?**

हां। इन ऑब्जेक्ट्स में किसी भी टेक्स्ट के लिए समान ग्लिफ़-सब्स्टिट्यूशन मैकेनिज़्म का उपयोग किया जाता है।

**क्या Aspose लाइब्रेरी के साथ कोई फ़ॉन्ट वितरित करता है?**

नहीं। आप फ़ॉन्ट स्वयं जोड़ते और उपयोग करते हैं और यह पूरी तरह आपकी ज़िम्मेदारी है।

**क्या लापता फ़ॉन्ट्स के लिए रिप्लेसमेंट/सब्स्टिट्यूशन और लापता ग्लिफ़्स के फ़ॉलबैक को साथ में उपयोग किया जा सकता है?**

हां। ये एक ही फ़ॉन्ट-रिज़ॉल्यूशन पाइपलाइन के स्वतंत्र चरण हैं: पहले इंजन फ़ॉन्ट उपलब्धता को हल करता है ([replacement](/slides/hi/python-net/font-replacement/)/[substitution](/slides/hi/python-net/font-substitution/)), फिर फ़ॉलबैक उपलब्ध फ़ॉन्ट्स में लापता ग्लिफ़्स के अंतर को भरता है।