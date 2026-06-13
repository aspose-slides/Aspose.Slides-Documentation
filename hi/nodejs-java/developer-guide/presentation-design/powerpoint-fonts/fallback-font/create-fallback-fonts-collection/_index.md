---
title: JavaScript में फ़ॉलबैक फ़ॉन्ट संग्रह कॉन्फ़िगर करें
linktitle: फ़ॉलबैक फ़ॉन्ट संग्रह
type: docs
weight: 20
url: /hi/nodejs-java/create-fallback-fonts-collection/
keywords:
- फ़ॉलबैक फ़ॉन्ट
- फ़ॉलबैक नियम
- फ़ॉन्ट संग्रह
- फ़ॉन्ट कॉन्फ़िगर करें
- फ़ॉन्ट सेट अप करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js के साथ JavaScript में फ़ॉलबैक फ़ॉन्ट संग्रह स्थापित करें ताकि PowerPoint और OpenDocument प्रस्तुतियों में पाठ सुसंगत और स्पष्ट रहे।"
---
## **अवलोकन**

Aspose.Slides आपको प्रस्तुति के लिए फ़ॉलबैक फ़ॉन्ट नियमों का संग्रह कॉन्फ़िगर करने की अनुमति देता है। प्रत्येक फ़ॉलबैक नियम `FontFallBackRule` क्लास द्वारा प्रतिनिधित्व किया गया है और इसे `FontFallBackRulesCollection` में जोड़ा जा सकता है।

संग्रह बनाने के बाद, आप इसे प्रस्तुति के `FontsManager` के `setFontFallBackRulesCollection` मेथड का उपयोग करके असाइन कर सकते हैं। `FontsManager` प्रस्तुति भर में फ़ॉन्ट्स को नियंत्रित करता है, और प्रत्येक `Presentation` इंस्टेंस का अपना `FontsManager` होता है।

जब `FontsManager` को फ़ॉलबैक फ़ॉन्ट संग्रह के साथ इनिशियलाइज़ किया जाता है, तो निर्दिष्ट फ़ॉलबैक फ़ॉन्ट्स प्रस्तुति रेंडरिंग के दौरान लागू होते हैं।

## **फ़ॉलबैक नियम लागू करें**

`[FontFallBackRule](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/FontFallBackRule)` क्लास के इंस्टैंसेज़ को `[FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/FontFallBackRulesCollection)` में व्यवस्थित किया जा सकता है, जो `[FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/FontFallBackRulesCollection)` क्लास को इम्प्लीमेंट करता है। संग्रह से नियम जोड़ना या हटाना संभव है।

फिर इस संग्रह को `[FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/FontFallBackRulesCollection)` मेथड के माध्यम से `[FontsManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/FontsManager)` क्लास को असाइन किया जा सकता है। `FontsManager` प्रस्तुति भर में फ़ॉन्ट्स को नियंत्रित करता है।

प्रत्येक `[Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation)` के पास एक `[getFontsManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#getFontsManager--)` मेथड होता है, जिसमें उसका अपना `FontsManager` क्लास इंस्टांस होता है।

यहाँ एक उदाहरण दिया गया है कि कैसे फ़ॉलबैक फ़ॉन्ट नियमों का संग्रह बनाया जाए और किसी विशिष्ट प्रस्तुति के `[FontsManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#getFontsManager--)` में असाइन किया जाए:  

```javascript
var pres = new aspose.slides.Presentation();
try {
    var userRulesList = new aspose.slides.FontFallBackRulesCollection();
    userRulesList.add(new aspose.slides.FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    userRulesList.add(new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

`FontsManager` को फ़ॉलबैक फ़ॉन्ट संग्रह के साथ इनिशियलाइज़ करने के बाद, फ़ॉलबैक फ़ॉन्ट्स प्रस्तुति रेंडरिंग के दौरान लागू होते हैं।

{{% alert color="primary" %}} 
और पढ़ें कि कैसे [फ़ॉलबैक फ़ॉन्ट के साथ प्रस्तुति रेंडर करें](/slides/hi/nodejs-java/render-presentation-with-fallback-font/)।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मेरे फ़ॉलबैक नियम PPTX फ़ाइल में एम्बेड होंगे और सहेजने के बाद PowerPoint में दिखाई देंगे?**

नहीं। फ़ॉलबैक नियम रनटाइम रेंडरिंग सेटिंग्स हैं; वे PPTX में सीरियलाइज़ नहीं होते और PowerPoint के UI में दिखाई नहीं देंगे।

**क्या फ़ॉलबैक SmartArt, WordArt, चार्ट और तालिकाओं के भीतर के टेक्स्ट पर लागू होता है?**

हाँ। इन ऑब्जेक्ट्स के किसी भी टेक्स्ट के लिए वही ग्लिफ़-प्रतिस्थापन तंत्र उपयोग किया जाता है।

**क्या Aspose लाइब्रेरी के साथ कोई फ़ॉन्ट वितरित करता है?**

नहीं। आप अपने पक्ष में फ़ॉन्ट जोड़ते और उपयोग करते हैं और इसकी पूरी जिम्मेदारी आपके ऊपर है।

**क्या गायब फ़ॉन्ट्स के लिए प्रतिस्थापन/परिवर्तन और गायब ग्लिफ़्स के लिए फ़ॉलबैक एक साथ उपयोग किए जा सकते हैं?**

हाँ। ये एक ही फ़ॉन्ट-रिज़ॉल्यूशन पाइपलाइन के स्वतंत्र चरण हैं: पहले इंजन फ़ॉन्ट उपलब्धता को हल करता है ([replacement](/slides/hi/nodejs-java/font-replacement/)/[substitution](/slides/hi/nodejs-java/font-substitution/)), फिर फ़ॉलबैक उपलब्ध फ़ॉन्ट्स में गायब ग्लिफ़्स के अंतर को पूरा करता है।