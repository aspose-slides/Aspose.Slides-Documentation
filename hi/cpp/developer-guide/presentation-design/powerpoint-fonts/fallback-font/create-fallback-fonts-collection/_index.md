---
title: C++ में फॉलबैक फ़ॉन्ट संग्रह को कॉन्फ़िगर करें
linktitle: फॉलबैक फ़ॉन्ट संग्रह
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
description: "C++ के लिए Aspose.Slides में एक फ़ॉलबैक फ़ॉन्ट संग्रह सेट अप करें ताकि PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट सुसंगत और स्पष्ट रहे।"
---
## **अवलोकन**

Aspose.Slides आपको प्रस्तुति के लिए फॉलबैक फ़ॉन्ट नियमों का संग्रह कॉन्फ़िगर करने की अनुमति देता है। प्रत्येक फॉलबैक नियम `FontFallBackRule` क्लास द्वारा दर्शाया जाता है और इसे `FontFallBackRulesCollection` में जोड़ा जा सकता है, जो `IFontFallBackRulesCollection` इंटरफ़ेस को लागू करता है।

संग्रह बनाने के बाद, आप इसे प्रस्तुति के `FontsManager` की `set_FontFallBackRulesCollection` मेथड का उपयोग करके असाइन कर सकते हैं। `FontsManager` प्रस्तुति भर में फ़ॉन्ट्स को नियंत्रित करता है, और प्रत्येक `Presentation` इंस्टेंस का अपना `FontsManager` होता है।

जब `FontsManager` को फॉलबैक फ़ॉन्ट संग्रह के साथ प्रारंभ किया जाता है, तो निर्दिष्ट फॉलबैक फ़ॉन्ट्स प्रस्तुति रेंडरिंग के दौरान लागू किए जाते हैं।

## **फॉलबैक नियम लागू करें**

इंस्टेंसेस को [FontFallBackRule](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontfallbackrule/) क्लास की [FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontfallbackrulescollection/) में व्यवस्थित किया जा सकता है, जो [IFontFallBackRulesCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifontfallbackrulescollection/) इंटरफ़ेस को लागू करता है। संग्रह से नियम जोड़ना या हटाना संभव है।

फिर यह संग्रह को [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) मेथड को [FontsManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsmanager/) क्लास के माध्यम से पास किया जा सकता है। FontsManager प्रस्तुति भर में फ़ॉन्ट्स को नियंत्रित करता है।

प्रत्येक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) में एक [get_FontsManager()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_fontsmanager/) मेथड होता है, जो FontsManager क्लास का अपना इंस्टेंस रखता है।

यहाँ एक उदाहरण है कि कैसे फॉलबैक फ़ॉन्ट नियमों का संग्रह बनाया जाए और किसी विशेष प्रस्तुति के FontsManager में असाइन किया जाए:  

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <DOM/Fonts/FontFallBackRulesCollection.h>
#include <DOM/IFontFallBackRule.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

FontsManager को फॉलबैक फ़ॉन्ट संग्रह के साथ प्रारंभ करने के बाद, फॉलबैक फ़ॉन्ट्स प्रस्तुति रेंडरिंग के दौरान लागू होते हैं।

{{% alert color="info" %}} 
और अधिक पढ़ें कि कैसे [फॉलबैक फ़ॉन्ट के साथ प्रस्तुति रेंडर करें](/slides/hi/cpp/render-presentation-with-fallback-font/)।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मेरे फॉलबैक नियम PPTX फ़ाइल में एम्बेड हो जाएंगे और सहेजने के बाद PowerPoint में दिखेंगे?

नहीं। फॉलबैक नियम रनटाइम रेंडरिंग सेटिंग्स हैं; इन्हें PPTX में क्रमबद्ध नहीं किया जाता और यह PowerPoint के UI में नहीं दिखेंगे।

### क्या फॉलबैक SmartArt, WordArt, चार्ट और टेबल के अंदर के टेक्स्ट पर लागू होता है?

हाँ। इन वस्तुओं के किसी भी टेक्स्ट के लिए वही glyph‑substitution तंत्र उपयोग किया जाता है।

### क्या Aspose लाइब्रेरी के साथ कोई फ़ॉन्ट वितरित करता है?

नहीं। आप फ़ॉन्ट्स को अपनी ओर से जोड़ते और उपयोग करते हैं और यह आपकी अपनी ज़िम्मेदारी है।

### क्या गायब फ़ॉन्ट्स के लिए रिप्लेसमेंट/सब्स्टिट्यूशन और गायब glyphs के लिए फॉलबैक को साथ में उपयोग किया जा सकता है?

हाँ। वे एक ही फ़ॉन्ट‑रिज़ॉल्यूशन पाइपलाइन के स्वतंत्र चरण हैं: पहले इंजन फ़ॉन्ट की उपलब्धता को हल करता है ([replacement](/slides/hi/cpp/font-replacement/)/[substitution](/slides/hi/cpp/font-substitution/)), फिर फॉलबैक उपलब्ध फ़ॉन्ट्स में गायब glyphs के लिए अंतर भरता है।