---
title: .NET में फ़ॉलबैक फ़ॉन्ट संग्रह कॉन्फ़िगर करें
linktitle: फ़ॉलबैक फ़ॉन्ट संग्रह
type: docs
weight: 20
url: /hi/net/create-fallback-fonts-collection/
keywords:
- फ़ॉलबैक फ़ॉन्ट
- फ़ॉलबैक नियम
- फ़ॉन्ट संग्रह
- फ़ॉन्ट कॉन्फ़िगर करें
- फ़ॉन्ट सेट अप करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में फ़ॉलबैक फ़ॉन्ट संग्रह सेट अप करें ताकि PowerPoint और OpenDocument प्रस्तुतियों में पाठ सुसंगत और स्पष्ट रहे।"
---
## **अवलोकन**

Aspose.Slides आपको प्रस्तुति के लिए फ़ॉलबैक फ़ॉन्ट नियमों का एक संग्रह कॉन्फ़िगर करने की अनुमति देता है। प्रत्येक फ़ॉलबैक नियम `FontFallBackRule` क्लास द्वारा प्रतिनिधित्व किया जाता है और इसे `FontFallBackRulesCollection` में जोड़ा जा सकता है, जो `IFontFallBackRulesCollection` इंटरफ़ेस को लागू करता है।

संग्रह बनाने के बाद, आप इसे प्रस्तुति के `FontsManager` की `FontFallBackRulesCollection` प्रॉपर्टी को असाइन कर सकते हैं। `FontsManager` प्रस्तुति में फ़ॉन्ट्स को नियंत्रित करता है, और प्रत्येक `Presentation` इंस्टेंस का अपना `FontsManager` होता है।

जब `FontsManager` को फ़ॉलबैक फ़ॉन्ट संग्रह के साथ प्रारंभ किया जाता है, तो निर्दिष्ट फ़ॉलबैक फ़ॉन्ट्स प्रस्तुति रेंडरिंग के दौरान लागू होते हैं।

## **फ़ॉलबैक नियम लागू करें**

`[FontFallBackRule](https://reference.aspose.com/slides/hi/net/aspose.slides/FontFallBackRule)` क्लास की इंस्टेंसों को `[FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/fontfallbackrulescollection)` में व्यवस्थित किया जा सकता है, जो `[IFontFallBackRulesCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/ifontfallbackrulescollection)` इंटरफ़ेस को लागू करता है। संग्रह में नियम जोड़ना या हटाना संभव है।

फिर इस संग्रह को `[FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection)` प्रॉपर्टी को `[FontsManager](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsmanager)` क्लास में असाइन किया जा सकता है। FontsManager प्रस्तुति में फ़ॉन्ट्स को नियंत्रित करता है।

प्रत्येक `[Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation)` के पास एक `FontsManager` प्रॉपर्टी होती है, जिसमें FontsManager क्लास की अपनी इंस्टेंस होती है।

यहां एक उदाहरण दिया गया है कि कैसे फ़ॉलबैक फ़ॉन्ट नियम संग्रह बनाया जाए और उसे किसी विशिष्ट प्रस्तुति के FontsManager में असाइन किया जाए:  

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

FontsManager को फ़ॉलबैक फ़ॉन्ट संग्रह के साथ प्रारंभ करने के बाद, फ़ॉलबैक फ़ॉन्ट्स प्रस्तुति रेंडरिंग के दौरान लागू होते हैं।

{{% alert color="info" %}} 
और पढ़ें कैसे [फ़ॉलबैक फ़ॉन्ट के साथ प्रस्तुति रेंडर करें](/slides/hi/net/render-presentation-with-fallback-font/)।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मेरे फ़ॉलबैक नियम PPTX फ़ाइल में एम्बेड हो जाएंगे और सहेजने के बाद PowerPoint में दिखाई देंगे?

नहीं। फ़ॉलबैक नियम रनटाइम रेंडरिंग सेटिंग्स हैं; वे PPTX में सीरियलाइज़ नहीं होते और PowerPoint के UI में नहीं दिखेंगे।

### क्या फ़ॉलबैक SmartArt, WordArt, चार्ट और तालिकाओं के अंदर के पाठ पर लागू होता है?

हां। इन ऑब्जेक्ट्स में किसी भी पाठ के लिये वही glyph‑substitution मेकेनिज़्म उपयोग किया जाता है।

### क्या Aspose लाइब्रेरी के साथ कोई फ़ॉन्ट वितरित करता है?

नहीं। आप फ़ॉन्ट्स को अपने पक्ष में जोड़ते और उपयोग करते हैं और इसकी पूरी ज़िम्मेदारी स्वयं लेनी होती है।

### क्या गायब फ़ॉन्ट्स के लिए प्रतिस्थापन/सब्स्टिट्यूशन और गायब ग्लाइफ़्स के लिए फ़ॉलबैक को साथ में इस्तेमाल किया जा सकता है?

हां। वे फ़ॉन्ट‑रिज़ॉल्यूशन पाइपलाइन के स्वतंत्र चरण हैं: पहले इंजन फ़ॉन्ट उपलब्धता को हल करता है ([replacement](/slides/hi/net/font-replacement/)/[substitution](/slides/hi/net/font-substitution/)), फिर फ़ॉलबैक उपलब्ध फ़ॉन्ट्स में गायब ग्लाइफ़्स के अंतर को भरता है।