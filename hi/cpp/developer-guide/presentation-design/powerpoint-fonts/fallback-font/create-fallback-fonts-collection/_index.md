---
title: C++ में फॉलबैक फ़ॉन्ट संग्रह को कॉन्फ़िगर करें
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
- С++
- Aspose.Slides
description: "PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को सुसंगत और स्पष्ट रखने के लिए Aspose.Slides में C++ हेतु एक फ़ॉलबैक फ़ॉन्ट संग्रह सेट अप करें।"
---
## **अवलोकन**

Aspose.Slides आपको प्रस्तुति के लिए फॉलबैक फ़ॉन्ट नियमों का संग्रह कॉन्फ़िगर करने की सुविधा देता है। प्रत्येक फॉलबैक नियम को `FontFallBackRule` क्लास द्वारा दर्शाया जाता है और इसे `FontFallBackRulesCollection` में जोड़ा जा सकता है, जो `IFontFallBackRulesCollection` इंटरफ़ेस को लागू करता है।

संग्रह बनाने के बाद, आप इसे प्रस्तुति के `FontsManager` की `set_FontFallBackRulesCollection` मेथड का उपयोग करके असाइन कर सकते हैं। `FontsManager` पूरे प्रस्तुति में फ़ॉन्ट्स को नियंत्रित करता है, और प्रत्येक `Presentation` इंस्टेंस का अपना `FontsManager` होता है।

एक बार `FontsManager` को फॉलबैक फ़ॉन्ट संग्रह के साथ प्रारंभ किया गया, तो निर्दिष्ट फॉलबैक फ़ॉन्ट्स प्रस्तुति रेंडरिंग के दौरान लागू हो जाते हैं।

## **फॉलबैक नियम लागू करें**

`[FontFallBackRule](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontfallbackrule/)` क्लास की इंस्टेंसेज़ को `[FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontfallbackrulescollection/)` में व्यवस्थित किया जा सकता है, जो `[IFontFallBackRulesCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifontfallbackrulescollection/)` इंटरफ़ेस को लागू करता है। संग्रह में नियमों को जोड़ना या हटाना संभव है।

फिर यह संग्रह `[set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/)` मेथड के माध्यम से `[FontsManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsmanager/)` क्लास को पास किया जा सकता है। FontsManager पूरे प्रस्तुति में फ़ॉन्ट्स को नियंत्रित करता है।

प्रत्येक `[Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/)` में एक `[get_FontsManager()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_fontsmanager/)` मेथड होता है, जिसके पास अपना FontsManager इंस्टेंस होता है।

यहाँ एक उदाहरण है कि कैसे फॉलबैक फ़ॉन्ट नियमों का संग्रह बनाया जाए और किसी विशेष प्रस्तुति के FontsManager में असाइन किया जाए:

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

FontsManager को फॉलबैक फ़ॉन्ट संग्रह के साथ प्रारंभ करने के बाद, फॉलबैक फ़ॉन्ट्स प्रस्तुति रेंडरिंग के दौरान लागू होते हैं।

{{% alert color="primary" %}} 
फ़ॉलबैक फ़ॉन्ट के साथ प्रस्तुति रेंडर करने के बारे में अधिक पढ़ें[/slides/hi/cpp/render-presentation-with-fallback-font/].
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मेरे फॉलबैक नियम PPTX फ़ाइल में एम्बेड हो जाएंगे और सहेजने के बाद PowerPoint में दिखेंगे?**

नहीं। फॉलबैक नियम रनटाइम रेंडरिंग सेटिंग्स हैं; इन्हें PPTX में सीरियलाइज़ नहीं किया जाता और PowerPoint के UI में नहीं दिखेंगे।

**क्या फॉलबैक SmartArt, WordArt, चार्ट्स और टेबल्स के अंदर के टेक्स्ट पर लागू होता है?**

हां। इन वस्तुओं के किसी भी टेक्स्ट के लिए वही ग्लिफ़-सब्स्टिट्यूशन मैकेनिज़्म उपयोग किया जाता है।

**क्या Aspose लाइब्रेरी के साथ कोई फ़ॉन्ट वितरित करता है?**

नहीं। आप स्वयं फ़ॉन्ट्स जोड़ते और उपयोग करते हैं और इसकी जिम्मेदारी आपके ऊपर होती है।

**क्या लापता फ़ॉन्ट्स के लिए प्रतिस्थापन/सब्स्टिट्यूशन और लापता ग्लिफ़्स के लिए फॉलबैक को साथ में उपयोग किया जा सकता है?**

हां। ये एक ही फ़ॉन्ट-रिज़ॉल्यूशन पाइपलाइन के स्वतंत्र चरण हैं: पहले इंजन फ़ॉन्ट उपलब्धता ([replacement](/slides/hi/cpp/font-replacement/)/[substitution](/slides/hi/cpp/font-substitution/)) को हल करता है, फिर फॉलबैक उपलब्ध फ़ॉन्ट्स में लापता ग्लिफ़्स के अंतर को भरता है।