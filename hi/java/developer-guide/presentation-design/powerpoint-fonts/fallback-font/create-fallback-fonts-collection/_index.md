---
title: जावा में फ़ॉलबैक फ़ॉन्ट संग्रह कॉन्फ़िगर करें
linktitle: फ़ॉलबैक फ़ॉन्ट संग्रह
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
description: "Aspose.Slides for Java में फ़ॉलबैक फ़ॉन्ट संग्रह सेट अप करें ताकि PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट सुसंगत और स्पष्ट बना रहे।"
---
## **अवलोकन**

Aspose.Slides आपको एक प्रस्तुति के लिए फ़ॉलबैक फ़ॉन्ट नियमों का संग्रह कॉन्फ़िगर करने की सुविधा देता है। प्रत्येक फ़ॉलबैक नियम `FontFallBackRule` क्लास द्वारा दर्शाया जाता है और इसे `FontFallBackRulesCollection` में जोड़ा जा सकता है, जो `IFontFallBackRulesCollection` इंटरफ़ेस को लागू करता है।

संग्रह बनाने के बाद, आप इसे प्रस्तुति के `FontsManager` की `FontFallBackRulesCollection` प्रॉपर्टी को असाइन कर सकते हैं। `FontsManager` प्रस्तुति में फ़ॉन्ट्स को नियंत्रित करता है, और प्रत्येक `Presentation` इंस्टेंस का अपना `FontsManager` होता है।

जब `FontsManager` को फ़ॉलबैक फ़ॉन्ट संग्रह के साथ प्रारंभ किया जाता है, तो निर्दिष्ट फ़ॉलबैक फ़ॉन्ट्स प्रस्तुति रेंडरिंग के दौरान लागू हो जाते हैं।

## **फ़ॉलबैक नियम लागू करें**

क्लास [FontFallBackRule](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontFallBackRule) के इंस्टेंस को [FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontFallBackRulesCollection) में व्यवस्थित किया जा सकता है, जो [IFontFallBackRulesCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IFontFallBackRulesCollection) इंटरफ़ेस को लागू करता है। संग्रह से नियम जोड़ना या हटाना संभव है।

फिर इस संग्रह को [FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontFallBackRulesCollection) मेथड के माध्यम से [FontsManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontsManager) क्लास में असाइन किया जा सकता है। FontsManager प्रस्तुति में फ़ॉन्ट्स को नियंत्रित करता है।

प्रत्येक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) में एक [getFontsManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#getFontsManager--) मेथड होता है, जिसमें [FontsManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontsManager) क्लास का अपना इंस्टेंस होता है।

यहाँ एक उदाहरण है कि कैसे फ़ॉलबैक फ़ॉन्ट नियमों का संग्रह बनाते हैं और उसे किसी विशिष्ट प्रस्तुति के [FontsManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#getFontsManager--) में असाइन करते हैं:

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

जब FontsManager को फ़ॉलबैक फ़ॉन्ट संग्रह के साथ प्रारंभ किया जाता है, तो फ़ॉलबैक फ़ॉन्ट्स प्रस्तुति रेंडरिंग के दौरान लागू होते हैं।

{{% alert color="info" %}} 
और अधिक पढ़ें कि कैसे [फ़ॉलबैक फ़ॉन्ट के साथ प्रस्तुति रेंडर करना](/slides/hi/java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

### Will my fallback rules be embedded into the PPTX file and visible in PowerPoint after saving?

नहीं। फ़ॉलबैक नियम रन‑टाइम रेंडरिंग सेटिंग्स हैं; इन्हें PPTX में सीरियलाइज़ नहीं किया जाता और यह PowerPoint के यूआई में नहीं दिखेंगे।

### Does fallback apply to text inside SmartArt, WordArt, charts, and tables?

हां। इन ऑब्जेक्ट्स में किसी भी टेक्स्ट के लिए समान ग्लिफ़‑स्थापन (glyph‑substitution) तंत्र उपयोग किया जाता है।

### Does Aspose distribute any fonts with the library?

नहीं। आप अपने पक्ष में फ़ॉन्ट जोड़ते और उपयोग करते हैं और यह आपकी स्वयं की जिम्मेदारी है।

### Can replacement/substitution for missing fonts and fallback for missing glyphs be used together?

हां। ये समान फ़ॉन्ट‑रिज़ॉल्यूशन पाइपलाइन के स्वतंत्र चरण हैं: पहले इंजन फ़ॉन्ट उपलब्धता को हल करता है ([replacement](/slides/hi/java/font-replacement/)/[substitution](/slides/hi/java/font-substitution/)), फिर फ़ॉलबैक उपलब्ध फ़ॉन्ट्स में गायब ग्लिफ़्स के लिए अंतर भरता है।