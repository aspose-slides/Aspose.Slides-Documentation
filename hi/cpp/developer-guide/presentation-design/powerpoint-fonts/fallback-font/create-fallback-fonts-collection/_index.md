---
title: C++ में फ़ॉलबैक फ़ॉन्ट संग्रह को कॉन्फ़िगर करें
linktitle: फ़ॉलबैक फ़ॉन्ट संग्रह
type: docs
weight: 20
url: /hi/cpp/create-fallback-fonts-collection/
keywords:
- फ़ॉलबैक फ़ॉन्ट
- फ़ॉलबैक नियम
- फ़ॉन्ट संग्रह
- फ़ॉन्ट कॉन्फ़िगर करें
- फ़ॉन्ट सेट अप करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides के लिए C++ में एक फ़ॉलबैक फ़ॉन्ट संग्रह सेट अप करें ताकि PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट सुसंगत और स्पष्ट रहे।"
---
## **सारांश**

Aspose.Slides आपको प्रस्तुति के लिए फ़ॉलबैक फ़ॉन्ट नियमों के एक संग्रह को कॉन्फ़िगर करने की अनुमति देता है। प्रत्येक फ़ॉलबैक नियम `FontFallBackRule` क्लास द्वारा प्रस्तुत किया जाता है और इसे `FontFallBackRulesCollection` में जोड़ा जा सकता है, जो `IFontFallBackRulesCollection` इंटरफ़ेस को लागू करता है।

संग्रह बनाने के बाद, आप इसे प्रस्तुति के `FontsManager` की `set_FontFallBackRulesCollection` मेथड का उपयोग करके असाइन कर सकते हैं। `FontsManager` प्रस्तुति भर में फ़ॉन्ट को नियंत्रित करता है, और प्रत्येक `Presentation` इंस्टेंस का अपना `FontsManager` होता है।

एक बार `FontsManager` को फ़ॉलबैक फ़ॉन्ट संग्रह के साथ प्रारंभ कर दिया गया, तो निर्दिष्ट फ़ॉलबैक फ़ॉन्ट प्रस्तुति रेंडरिंग के दौरान लागू होते हैं।

## **फ़ॉलबैक नियम लागू करें**

[FontFallBackRule](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontfallbackrule/) क्लास के इंस्टेंस को [FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontfallbackrulescollection/) में व्यवस्थित किया जा सकता है, जो [IFontFallBackRulesCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifontfallbackrulescollection/) इंटरफ़ेस को लागू करता है। संग्रह से नियम जोड़ना या हटाना संभव है।

फिर इस संग्रह को [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) मेथड के माध्यम से [FontsManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsmanager/) क्लास को पास किया जा सकता है। FontsManager प्रस्तुति भर में फ़ॉन्ट को नियंत्रित करता है।

प्रत्येक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) के पास एक [get_FontsManager()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_fontsmanager/) मेथड होता है जो FontsManager क्लास का अपना इंस्टेंस प्रदान करता है।

यहाँ एक उदाहरण है कि कैसे फ़ॉलबैक फ़ॉन्ट नियमों का संग्रह बनाया जाए और किसी विशिष्ट प्रस्तुति के FontsManager में असाइन किया जाए:  

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

FontsManager को फ़ॉलबैक फ़ॉन्ट संग्रह के साथ प्रारम्भ करने के बाद, फ़ॉलबैक फ़ॉन्ट प्रस्तुति रेंडरिंग के दौरान लागू होते हैं।

{{% alert color="primary" %}} 
और अधिक पढ़ें कि कैसे [Render Presentation with Fallback Font](/slides/hi/cpp/render-presentation-with-fallback-font/)।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मेरे फ़ॉलबैक नियम PPTX फाइल में एम्बेड हो जाएंगे और सहेजने के बाद PowerPoint में दिखाई देंगे?**

नहीं। फ़ॉलबैक नियम रनटाइम रेंडरिंग सेटिंग्स हैं; इन्हें PPTX में सीरियलाइज़ नहीं किया जाता और PowerPoint के UI में नहीं दिखेंगे।

**क्या फ़ॉलबैक SmartArt, WordArt, चार्ट और टेबल के भीतर टेक्स्ट पर लागू होता है?**

हां। समान ग्लिफ़-सब्स्टिट्यूशन मैकेनिज़्म इन वस्तुओं के किसी भी टेक्स्ट पर उपयोग किया जाता है।

**क्या Aspose लाइब्रेरी के साथ कोई फ़ॉन्ट वितरित करता है?**

नहीं। आप अपने पक्ष से फ़ॉन्ट जोड़ते और उपयोग करते हैं और यह आपकी स्वयं की ज़िम्मेदारी है।

**क्या गायब फ़ॉन्ट के लिए रिप्लेसमेंट/सब्स्टिट्यूशन और गायब ग्लिफ़ के लिए फ़ॉलबैक को एक साथ उपयोग किया जा सकता है?**

हां। वे समान फ़ॉन्ट-रेज़ॉल्यूशन पाइपलाइन के स्वतंत्र चरण हैं: पहले इंजन फ़ॉन्ट उपलब्धता को हल करता है ([replacement](/slides/hi/cpp/font-replacement/)/[substitution](/slides/hi/cpp/font-substitution/)), फिर फ़ॉलबैक उपलब्ध फ़ॉन्ट में गायब ग्लिफ़ के लिए अंतर भरता है।