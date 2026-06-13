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
- फ़ॉन्ट सेटअप करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: .NET के लिए Aspose.Slides में फ़ॉलबैक फ़ॉन्ट संग्रह सेट करें ताकि PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट सुसंगत और स्पष्ट रहे।
---
## **सारांश**

Aspose.Slides आपको प्रस्तुति के लिए फ़ॉलबैक फ़ॉन्ट नियमों का संग्रह कॉन्फ़िगर करने की अनुमति देता है। प्रत्येक फ़ॉलबैक नियम `FontFallBackRule` क्लास द्वारा दर्शाया जाता है और इसे `FontFallBackRulesCollection` में जोड़ा जा सकता है, जो `IFontFallBackRulesCollection` इंटरफ़ेस को लागू करता है।

कलेक्शन बनाने के बाद, आप इसे प्रस्तुति के `FontsManager` की `FontFallBackRulesCollection` प्रॉपर्टी को असाइन कर सकते हैं। `FontsManager` प्रस्तुति में फ़ॉन्ट्स को नियंत्रित करता है, और प्रत्येक `Presentation` इंस्टेंस का अपना `FontsManager` होता है।

जब `FontsManager` को फ़ॉलबैक फ़ॉन्ट कलेक्शन के साथ प्रारंभ किया जाता है, तो निर्दिष्ट फ़ॉलबैक फ़ॉन्ट्स प्रस्तुति रेंडरिंग के दौरान लागू होते हैं।

## **फ़ॉलबैक नियम लागू करें**

[FontFallBackRule](https://reference.aspose.com/slides/hi/net/aspose.slides/FontFallBackRule) क्लास के इंस्टेंस को [FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/fontfallbackrulescollection) में व्यवस्थित किया जा सकता है, जो [IFontFallBackRulesCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/ifontfallbackrulescollection) इंटरफ़ेस को लागू करता है। कलेक्शन से नियम जोड़ना या हटाना संभव है।

फिर इस कलेक्शन को [FontFallBackRulesCollection ](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection)प्रॉपर्टी को [FontsManager](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsmanager) क्लास में असाइन किया जा सकता है। FontsManager प्रस्तुति में फ़ॉन्ट्स को नियंत्रित करता है।

हर [Presentation ](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) के पास एक [FontsManager ](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/properties/fontsmanager)प्रॉपर्टी होती है, जिसमें FontsManager क्लास की अपनी इंस्टेंस होती है।

यहाँ एक उदाहरण दिया गया है कि कैसे फ़ॉलबैक फ़ॉन्ट नियमों का कलेक्शन बनाया जाए और इसे किसी विशिष्ट प्रस्तुति के FontsManager में असाइन किया जाए:

```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

जब FontsManager को फ़ॉलबैक फ़ॉन्ट कलेक्शन के साथ प्रारंभ किया जाता है, तो फ़ॉलबैक फ़ॉन्ट्स प्रस्तुति रेंडरिंग के दौरान लागू होते हैं।

{{% alert color="primary" %}} 
और अधिक पढ़ें कि कैसे [फ़ॉलबैक फ़ॉन्ट के साथ प्रस्तुति रेंडर करें](/slides/hi/net/render-presentation-with-fallback-font/)।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मेरे फ़ॉलबैक नियम PPTX फ़ाइल में एम्बेड हो जाएंगे और सहेजने के बाद PowerPoint में दिखाई देंगे?**

नहीं। फ़ॉलबैक नियम रनटाइम रेंडरिंग सेटिंग्स हैं; इन्हें PPTX में सीरियलाइज़ नहीं किया जाता और वे PowerPoint के UI में दिखाई नहीं देंगे।

**क्या फ़ॉलबैक SmartArt, WordArt, चार्ट और तालिकाओं के भीतर के टेक्स्ट पर लागू होता है?**

हां। इन वस्तुओं में किसी भी टेक्स्ट के लिए वही ग्लिफ़-स्थानापन्न तंत्र उपयोग किया जाता है।

**क्या Aspose लाइब्रेरी के साथ कोई फ़ॉन्ट वितरित करता है?**

नहीं। आप अपना फ़ॉन्ट स्वयं जोड़ते और उपयोग करते हैं और यह पूरी तरह आपकी जिम्मेदारी है।

**क्या अनुपलब्ध फ़ॉन्ट्स के लिए रिप्लेसमेंट/सब्स्टिट्यूशन और अनुपलब्ध ग्लिफ़्स के लिए फ़ॉलबैक को साथ में उपयोग किया जा सकता है?**

हां। वे समान फ़ॉन्ट-रिज़ॉल्यूशन पाइपलाइन के स्वतंत्र चरण हैं: पहले इंजन फ़ॉन्ट उपलब्धता को हल करता है ([replacement](/slides/hi/net/font-replacement/)/[substitution](/slides/hi/net/font-substitution/)), फिर फ़ॉलबैक उपलब्ध फ़ॉन्ट्स में अनुपलब्ध ग्लिफ़्स के अंतर को भरता है।