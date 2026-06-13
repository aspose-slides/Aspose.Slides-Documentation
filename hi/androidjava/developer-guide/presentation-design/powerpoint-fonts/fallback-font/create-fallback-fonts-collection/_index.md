---
title: Android पर फ़ॉलबैक फ़ॉन्ट संग्रह कॉन्फ़िगर करें
linktitle: फ़ॉलबैक फ़ॉन्ट संग्रह
type: docs
weight: 20
url: /hi/androidjava/create-fallback-fonts-collection/
keywords:
- फ़ॉलबैक फ़ॉन्ट
- फ़ॉलबैक नियम
- फ़ॉन्ट संग्रह
- फ़ॉन्ट कॉन्फ़िगर करें
- फ़ॉन्ट सेट अप करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides के लिए Android में Java के माध्यम से फ़ॉलबैक फ़ॉन्ट संग्रह सेट अप करें ताकि PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट सुसंगत और स्पष्ट रहे।"
---
## **अवलोकन**

Aspose.Slides आपको प्रस्तुति के लिए फ़ॉलबैक फ़ॉन्ट नियमों के संग्रह को कॉन्फ़िगर करने की अनुमति देता है। प्रत्येक फ़ॉलबैक नियम `FontFallBackRule` क्लास द्वारा दर्शाया जाता है और इसे `FontFallBackRulesCollection` में जोड़ा जा सकता है, जो `IFontFallBackRulesCollection` इंटरफ़ेस को लागू करता है।

संग्रह बनाने के बाद, आप इसे प्रस्तुति के `FontsManager` की `FontFallBackRulesCollection` प्रॉपर्टी को असाइन कर सकते हैं। `FontsManager` पूरे प्रस्तुति में फ़ॉन्ट्स को नियंत्रित करता है, और प्रत्येक `Presentation` इंस्टेंस का अपना `FontsManager` होता है।

एक बार `FontsManager` को फ़ॉलबैक फ़ॉन्ट संग्रह के साथ प्रारम्भ किया जाता है, निर्दिष्ट फ़ॉलबैक फ़ॉन्ट्स प्रस्तुति रेंडरिंग के दौरान लागू हो जाते हैं।

## **फ़ॉलबैक नियम लागू करें**

सभी [FontFallBackRule](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontFallBackRule) क्लास की इंस्टेंसेज़ को [FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontFallBackRulesCollection) में व्यवस्थित किया जा सकता है, जो [IFontFallBackRulesCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IFontFallBackRulesCollection) इंटरफ़ेस को लागू करता है। संग्रह से नियम जोड़ना या हटाना संभव है।

फिर इस संग्रह को [FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontFallBackRulesCollection) मेथड को [FontsManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontsManager) क्लास में असाइन किया जा सकता है। FontsManager पूरे प्रस्तुति में फ़ॉन्ट्स को नियंत्रित करता है।

प्रत्येक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) में एक [getFontsManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#getFontsManager--) मेथड होता है, जिसके पास अपना [FontsManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontsManager) क्लास का इंस्टेंस होता है।

यहां एक उदाहरण दिया गया है कि कैसे फ़ॉलबैक फ़ॉन्ट नियम संग्रह बनाया जाए और उसे किसी विशेष प्रस्तुति के [FontsManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#getFontsManager--) में असाइन किया जाए:  

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

जब FontsManager को फ़ॉलबैक फ़ॉन्ट संग्रह के साथ प्रारम्भ किया जाता है, तो फ़ॉलबैक फ़ॉन्ट्स प्रस्तुति रेंडरिंग के दौरान लागू हो जाते हैं।

{{% alert color="primary" %}} 
फ़ॉलबैक फ़ॉन्ट के साथ प्रस्तुति रेंडर करने के बारे में अधिक पढ़ें: [फ़ॉलबैक फ़ॉन्ट के साथ प्रस्तुति रेंडर करें](/slides/hi/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मेरे फ़ॉलबैक नियम PPTX फ़ाइल में एम्बेड हो जाएंगे और सहेजने के बाद PowerPoint में दिखाई देंगे?**

नहीं। फ़ॉलबैक नियम रनटाइम रेंडरिंग सेटिंग्स हैं; वे PPTX में सीरियलाइज़ नहीं होते और PowerPoint के UI में नहीं दिखेंगे।

**क्या फ़ॉलबैक SmartArt, WordArt, चार्ट और टेबल के भीतर के टेक्स्ट पर लागू होता है?**

हां। इन ऑब्जेक्ट्स के किसी भी टेक्स्ट के लिए वही glyph‑substitution तंत्र उपयोग किया जाता है।

**क्या Aspose लाइब्रेरी के साथ कोई फ़ॉन्ट वितरित करता है?**

नहीं। आप अपने पक्ष में फ़ॉन्ट जोड़ते और उपयोग करते हैं और यह आपकी स्वयं की जिम्मेदारी है।

**क्या गायब फ़ॉन्ट्स के लिए रिप्लेसमेंट/सब्स्टिट्यूशन और गायब ग्लिफ़्स के लिए फ़ॉलबैक को एक साथ उपयोग किया जा सकता है?**

हां। वे समान फ़ॉन्ट‑रिज़ॉल्यूशन पाइपलाइन के स्वतंत्र चरण हैं: पहले इंजन फ़ॉन्ट की उपलब्धता को हल करता है ([replacement](/slides/hi/androidjava/font-replacement/)/[substitution](/slides/hi/androidjava/font-substitution/)), फिर फ़ॉलबैक उपलब्ध फ़ॉन्ट्स में गायब ग्लिफ़्स के अंतर को पूरित करता है।