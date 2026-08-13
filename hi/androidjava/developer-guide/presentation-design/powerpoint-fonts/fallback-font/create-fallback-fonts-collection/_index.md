---
title: Android पर फ़ॉलबैक फ़ॉन्ट संग्रह को कॉन्फ़िगर करें
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
description: "Android के लिए Java के माध्यम से Aspose.Slides में फ़ॉलबैक फ़ॉन्ट संग्रह सेट अप करें जिससे PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट सुसंगत और स्पष्ट रहे।"
---
## **परिचय**

Aspose.Slides आपको प्रस्तुति के लिए फ़ॉलबैक फ़ॉन्ट नियमों का संग्रह कॉन्फ़िगर करने की अनुमति देता है। प्रत्येक फ़ॉलबैक नियम को `FontFallBackRule` क्लास द्वारा दर्शाया जाता है और इसे `FontFallBackRulesCollection` में जोड़ा जा सकता है, जो `IFontFallBackRulesCollection` इंटरफ़ेस को लागू करता है।

संग्रह बनाने के बाद, आप इसे प्रस्तुति के `FontsManager` की `FontFallBackRulesCollection` प्रॉपर्टी को असाइन कर सकते हैं। `FontsManager` प्रस्तुति भर में फ़ॉन्ट को नियंत्रित करता है, और प्रत्येक `Presentation` इंस्टेंस का अपना `FontsManager` होता है।

एक बार `FontsManager` को फ़ॉलबैक फ़ॉन्ट संग्रह के साथ प्रारंभ किया जाने के बाद, निर्दिष्ट फ़ॉलबैक फ़ॉन्ट प्रस्तुति रेंडरिंग के दौरान लागू होते हैं।

## **फ़ॉलबैक नियम लागू करें**

[FontFallBackRule](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontFallBackRule) क्लास के इंस्टेंस को [FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontFallBackRulesCollection) में व्यवस्थित किया जा सकता है, जो [IFontFallBackRulesCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IFontFallBackRulesCollection) इंटरफ़ेस को लागू करता है। संग्रह से नियम जोड़ना या हटाना संभव है।

फिर इस संग्रह को [FontsManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontsManager) क्लास की [FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontFallBackRulesCollection) मेथड को असाइन किया जा सकता है। FontsManager प्रस्तुति भर में फ़ॉन्ट को नियंत्रित करता है।

प्रत्येक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) के पास अपना स्वयं का [FontsManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontsManager) इंस्टेंस के साथ एक [getFontsManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#getFontsManager--) मेथड होता है।

यहाँ एक उदाहरण है कि कैसे फ़ॉलबैक फ़ॉन्ट नियमों का संग्रह बनाया जाए और उसे किसी विशिष्ट प्रस्तुति के [FontsManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#getFontsManager--) में असाइन किया जाए:  

```java
import com.aspose.slides.*;

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

FontsManager को फ़ॉलबैक फ़ॉन्ट संग्रह के साथ प्रारंभ करने के बाद, फ़ॉलबैक फ़ॉन्ट प्रस्तुति रेंडरिंग के दौरान लागू होते हैं।

{{% alert color="info" %}} 
और अधिक पढ़ें कि कैसे [फ़ॉलबैक फ़ॉन्ट के साथ प्रस्तुति रेंडर करें](/slides/hi/androidjava/render-presentation-with-fallback-font/)।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मेरे फ़ॉलबैक नियम PPTX फ़ाइल में एम्बेड हो जाएंगे और सहेजने के बाद PowerPoint में दिखाई देंगे?

नहीं। फ़ॉलबैक नियम रन‑टाइम रेंडरिंग सेटिंग्स हैं; इन्हें PPTX में अनुक्रमित नहीं किया जाता और PowerPoint के यूज़र इंटरफ़ेस में नहीं दिखेंगे।

### क्या फ़ॉलबैक SmartArt, WordArt, चार्ट और टेबल के भीतर टेक्स्ट पर लागू होता है?

हां। इन वस्तुओं में किसी भी टेक्स्ट के लिए वही ग्लिफ़‑सबस्टीट्यूशन मैकेनिज़्म उपयोग किया जाता है।

### क्या Aspose लाइब्रेरी के साथ कोई फ़ॉन्ट वितरित करता है?

नहीं। फ़ॉन्ट आपको अपनी ओर से जोड़ने और उपयोग करने होते हैं और यह आपकी स्वयं की ज़िम्मेदारी है।

### क्या गायब फ़ॉन्ट के लिए प्रतिस्थापन/सब्स्टीट्यूशन और गायब ग्लिफ़ के लिए फ़ॉलबैक को एक साथ उपयोग किया जा सकता है?

हां। ये एक ही फ़ॉन्ट‑रिज़ॉल्यूशन पाइपलाइन के स्वतंत्र चरण हैं: पहले इंजन फ़ॉन्ट उपलब्धता को हल करता है ([replacement](/slides/hi/androidjava/font-replacement/)/[substitution](/slides/hi/androidjava/font-substitution/)), फिर फ़ॉलबैक उपलब्ध फ़ॉन्ट में गायब ग्लिफ़ के लिए अंतर भरता है।