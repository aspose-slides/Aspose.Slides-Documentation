---
title: Java में फ़ॉलबैक फ़ॉन्ट कलेक्शन कॉन्फ़िगर करें
linktitle: फ़ॉलबैक फ़ॉन्ट कलेक्शन
type: docs
weight: 20
url: /hi/java/create-fallback-fonts-collection/
keywords:
- फ़ॉलबैक फ़ॉन्ट
- फ़ॉलबैक नियम
- फ़ॉन्ट संग्रह
- फ़ॉन्ट कॉन्फ़िगर करें
- फ़ॉन्ट सेट अप करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Java के लिए Aspose.Slides में एक फ़ॉलबैक फ़ॉन्ट संग्रह स्थापित करें ताकि PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट सुसंगत और स्पष्ट रहे।"
---
## **अवलोकन**

Aspose.Slides आपको प्रस्तुति के लिए fallback फ़ॉन्ट नियमों का संग्रह कॉन्फ़िगर करने की अनुमति देता है। प्रत्येक fallback नियम `FontFallBackRule` क्लास द्वारा दर्शाया जाता है और इसे `FontFallBackRulesCollection` में जोड़ा जा सकता है, जो `IFontFallBackRulesCollection` इंटरफ़ेस को लागू करता है।

संग्रह बनाने के बाद, आप इसे प्रस्तुति के `FontsManager` की `FontFallBackRulesCollection` प्रॉपर्टी को असाइन कर सकते हैं। `FontsManager` प्रस्तुति में फ़ॉन्ट्स को नियंत्रित करता है, और प्रत्येक `Presentation` इंस्टेंस का अपना `FontsManager` होता है।

जब `FontsManager` को fallback फ़ॉन्ट संग्रह के साथ प्रारंभ किया जाता है, तो निर्दिष्ट fallback फ़ॉन्ट्स प्रस्तुति रेंडरिंग के दौरान लागू होते हैं।

## **फ़ॉलबैक नियम लागू करें**

FontFallBackRule क्लास के इंस्टेंस को [FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontFallBackRulesCollection) में व्यवस्थित किया जा सकता है, जो [IFontFallBackRulesCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IFontFallBackRulesCollection) इंटरफ़ेस को लागू करता है। संग्रह से नियम जोड़ना या हटाना संभव है।

फिर इस संग्रह को [FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontFallBackRulesCollection) मेथड को [FontsManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontsManager) क्लास की असाइन किया जा सकता है। FontsManager प्रस्तुति में फ़ॉन्ट्स को नियंत्रित करता है।

प्रत्येक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) में एक [getFontsManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#getFontsManager--) मेथड होता है, जिसका अपना [FontsManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontsManager) क्लास का इंस्टेंस होता है।

यहाँ एक उदाहरण है कि कैसे fallback फ़ॉन्ट नियमों का संग्रह बनाया जाए और किसी निश्चित प्रस्तुति के [FontsManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#getFontsManager--) में असाइन किया जाए:

```java
Presentation pres = new Presentation();
try {
    IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

    userRulesList.add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
    userRulesList.add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) pres.dispose();
}
```

जब FontsManager को fallback फ़ॉन्ट संग्रह के साथ प्रारंभ किया जाता है, तो fallback फ़ॉन्ट्स प्रस्तुति रेंडरिंग के दौरान लागू होते हैं।

{{% alert color="primary" %}} 
और अधिक पढ़ें कि कैसे [Render Presentation with Fallback Font](/slides/hi/java/render-presentation-with-fallback-font/)।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मेरे fallback नियम PPTX फ़ाइल में एम्बेड हो जाएंगे और सहेजने के बाद PowerPoint में दिखाई देंगे?**

नहीं। fallback नियम रनटाइम रेंडरिंग सेटिंग्स हैं; वे PPTX में सीरियलाइज़ नहीं होते और PowerPoint के UI में नहीं दिखेंगे।

**क्या fallback SmartArt, WordArt, चार्ट और तालिकाओं के अंदर के टेक्स्ट पर लागू होता है?**

हाँ। इन ऑब्जेक्ट्स के किसी भी टेक्स्ट के लिए समान glyph-substitution तंत्र का उपयोग किया जाता है।

**क्या Aspose लाइब्रेरी के साथ कोई फ़ॉन्ट वितरित करता है?**

नहीं। आप अपने पक्ष में फ़ॉन्ट जोड़ते और उपयोग करते हैं और यह आपकी जिम्मेदारी है।

**क्या अनुपलब्ध फ़ॉन्ट्स के प्रतिस्थापन/सब्स्टिट्यूशन और अनुपलब्ध glyphs के लिए fallback को एक साथ उपयोग किया जा सकता है?**

हां। वे एक ही फ़ॉन्ट‑रिज़ॉल्यूशन पाइपलाइन के स्वतंत्र चरण हैं: पहले इंजन फ़ॉन्ट उपलब्धता ([replacement](/slides/hi/java/font-replacement/)/[substitution](/slides/hi/java/font-substitution/)) को हल करता है, फिर fallback उपलब्ध फ़ॉन्ट्स में अनुपलब्ध glyphs के लिए अंतर भरता है।