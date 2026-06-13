---
title: PHP में फॉलबैक फ़ॉन्ट संग्रह को कॉन्फ़िगर करें
linktitle: फॉलबैक फ़ॉन्ट संग्रह
type: docs
weight: 20
url: /hi/php-java/create-fallback-fonts-collection/
keywords:
- फ़ॉलबैक फ़ॉन्ट
- फ़ॉलबैक नियम
- फ़ॉन्ट संग्रह
- फ़ॉन्ट कॉन्फ़िगर करें
- फ़ॉन्ट सेट अप करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides के लिए PHP में Java के माध्यम से एक फ़ॉलबैक फ़ॉन्ट संग्रह सेट अप करें ताकि PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट सुसंगत और स्पष्ट रहे।"
---
## **परिचय**

Aspose.Slides आपको एक प्रस्तुति के लिए फॉलबैक फ़ॉन्ट नियमों का संग्रह कॉन्फ़िगर करने की अनुमति देता है। प्रत्येक फॉलबैक नियम `FontFallBackRule` क्लास द्वारा दर्शाया जाता है और इसे `FontFallBackRulesCollection` में जोड़ा जा सकता है।

संग्रह बनाने के बाद, आप इसे प्रस्तुति के `FontsManager` की `setFontFallBackRulesCollection` मेथड का उपयोग करके असाइन कर सकते हैं। `FontsManager` प्रस्तुति में फ़ॉन्ट्स को नियंत्रित करता है, और प्रत्येक `Presentation` इंस्टेंस का अपना `FontsManager` होता है।

जब `FontsManager` को फॉलबैक फ़ॉन्ट संग्रह के साथ प्रारंभ किया जाता है, तो निर्दिष्ट फॉलबैक फ़ॉन्ट्स प्रस्तुति रेंडरिंग के दौरान लागू होते हैं।

## **फ़ॉलबैक नियम लागू करें**

[FontFallBackRule](https://reference.aspose.com/slides/hi/php-java/aspose.slides/FontFallBackRule) क्लास के इंस्टेंस को [FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/FontFallBackRulesCollection) में व्यवस्थित किया जा सकता है। संग्रह से नियम जोड़ना या हटाना संभव है।

फिर इस संग्रह को [FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/FontFallBackRulesCollection) मेथड के माध्यम से [FontsManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/FontsManager) क्लास में असाइन किया जा सकता है। FontsManager प्रस्तुति में फ़ॉन्ट्स को नियंत्रित करता है।

प्रत्येक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) में एक [getFontsManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation#getFontsManager) मेथड होता है, जो अपनी स्वयं की [FontsManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/FontsManager) क्लास की इंस्टेंस प्रदान करता है।

एक उदाहरण यहाँ दिया गया है कि कैसे फॉलबैक फ़ॉन्ट नियमों का संग्रह बनाया जाए और किसी निश्चित प्रस्तुति के [FontsManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation#getFontsManager) में असाइन किया जाए:  

```php
  $pres = new Presentation();
  try {
    $userRulesList = new FontFallBackRulesCollection();
    $userRulesList->add(new FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    $userRulesList->add(new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    $pres->getFontsManager()->setFontFallBackRulesCollection($userRulesList);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

जब FontsManager को फॉलबैक फ़ॉन्ट संग्रह के साथ प्रारम्भ किया जाता है, तो फॉलबैक फ़ॉन्ट्स प्रस्तुति रेंडरिंग के दौरान लागू होते हैं।

{{% alert color="primary" %}} 
अधिक पढ़ें कि कैसे [फ़ाल्बैक फ़ॉन्ट के साथ प्रस्तुति को रेंडर करने](/slides/hi/php-java/render-presentation-with-fallback-font/)।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मेरे फ़ॉलबैक नियम PPTX फ़ाइल में एम्बेड हो जाएंगे और सहेजने के बाद PowerPoint में दिखाई देंगे?**

नहीं। फ़ॉलबैक नियम रन‑टाइम रेंडरिंग सेटिंग्स हैं; इन्हें PPTX में सीरियलाइज़ नहीं किया जाता और PowerPoint के UI में नहीं दिखेंगे।

**क्या फ़ॉलबैक SmartArt, WordArt, चार्ट और तालिकाओं के अंदर के टेक्स्ट पर लागू होता है?**

हां। इन सभी ऑब्जेक्ट्स में टेक्स्ट के लिए वही ग्लिफ़‑सब्स्टिट्यूशन मैकेनिज़्म उपयोग किया जाता है।

**क्या Aspose लाइब्रेरी के साथ कोई फ़ॉन्ट वितरित करता है?**

नहीं। आपको फ़ॉन्ट्स स्वयं जोड़ने और उपयोग करने होते हैं, और यह आपके अपने ज़िम्मेदारी में है।

**क्या गुम फ़ॉन्ट्स के लिए रिप्लेसमेंट/सब्स्टिट्यूशन और गुम ग्लिफ़्स के लिए फ़ॉलबैक को साथ में उपयोग किया जा सकता है?**

हां। वे फ़ॉन्ट‑रिज़ॉल्यूशन पाइपलाइन के स्वतंत्र चरण हैं: पहले इंजन फ़ॉन्ट उपलब्धता को हल करता है ([replacement](/slides/hi/php-java/font-replacement/)/[substitution](/slides/hi/php-java/font-substitution/)), फिर फ़ॉलबैक उपलब्ध फ़ॉन्ट्स में गुम ग्लिफ़्स के अंतर को भरता है।