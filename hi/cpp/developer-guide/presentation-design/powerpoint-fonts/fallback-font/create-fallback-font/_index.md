---
title: C++ में प्रस्तुतियों के लिए फ़ॉलबैक फ़ॉन्ट्स निर्दिष्ट करें
linktitle: फ़ॉलबैक फ़ॉन्ट
type: docs
weight: 10
url: /hi/cpp/create-fallback-font/
keywords:
- फ़ॉलबैक फ़ॉन्ट
- फ़ॉलबैक नियम
- फ़ॉन्ट लागू करें
- फ़ॉन्ट बदलें
- Unicode रेंज
- छूटा ग्लिफ़
- उचित ग्लिफ़
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "C++ के लिए Aspose.Slides को महारत हासिल करें ताकि PPT, PPTX और ODP फ़ाइलों में फ़ॉलबैक फ़ॉन्ट सेट कर सकें, जिससे किसी भी डिवाइस या OS पर टेक्स्ट का निरंतर प्रदर्शन सुनिश्चित हो।"
---
## **सारांश**

Aspose.Slides आपको प्रस्तुति रेंडरिंग और निर्यात ऑपरेशन्स के लिए फ़ॉलबैक फ़ॉन्ट्स निर्दिष्ट करने की सुविधा देता है। फ़ॉलबैक फ़ॉन्ट्स तब उपयोग किए जाते हैं जब प्राथमिक फ़ॉन्ट में विशेष अक्षरों के लिए ग्लिफ़ नहीं होते।

फ़ॉलबैक व्यवहार फ़ॉलबैक नियमों के माध्यम से कॉन्फ़़िगर किया जाता है। प्रत्येक नियम एक Unicode रेंज को एक या अधिक फ़ॉन्ट्स के साथ जोड़ता है जो आवश्यक ग्लिफ़ रख सकते हैं। आप विभिन्न अक्षर रेंजों के लिए नियमों को परिभाषित कर सकते हैं, मौजूदा नियमों से फ़ॉलबैक फ़ॉन्ट्स जोड़ या हटा सकते हैं, और फ़ॉलबैक फ़ॉन्ट नियमों संग्रह में कई नियमों को व्यवस्थित कर सकते हैं।

फ़ॉलबैक नियम रनटाइम रेंडरिंग सेटिंग्स हैं। वे प्रस्तुति फ़ाइल को स्वयं संशोधित नहीं करते और PPTX फ़ाइल के अंदर संग्रहीत नहीं होते।

## **फ़ॉलबैक नियम**

Aspose.Slides [IFontFallBackRule](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifontfallbackrule/) इंटरफ़ेस और [FontFallBackRule](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontfallbackrule/) क्लास को समर्थन देता है ताकि फ़ॉलबैक फ़ॉन्ट लागू करने के नियम निर्दिष्ट किए जा सकें। [FontFallBackRule](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontfallbackrule/) क्लास निर्दिष्ट Unicode रेंज (जो अनुपलब्ध ग्लिफ़ खोजने के लिए उपयोग होती है) और संभावित उपयुक्त ग्लिफ़ वाले फ़ॉन्ट्स की सूची के बीच एक संबंध दर्शाती है:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// कई तरीकों से आप फ़ॉन्ट सूची जोड़ सकते हैं:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```



यह भी संभव है कि आप [Remove()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifontfallbackrule/remove/) के द्वारा फ़ॉलबैक फ़ॉन्ट को हटाएँ या मौजूदा [FontFallBackRule](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontfallbackrule/) ऑब्जेक्ट में [AddFallBackFonts()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) जोड़ें।

[FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontfallbackrulescollection/) का उपयोग तब किया जा सकता है जब कई Unicode रेंजों के लिए फ़ॉलबैक फ़ॉन्ट प्रतिस्थापन नियम निर्दिष्ट करने की आवश्यकता हो, ताकि [FontFallBackRule](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontfallbackrule/) ऑब्जेक्ट्स की सूची को व्यवस्थित किया जा सके।

{{% alert color="primary" title="See also" %}} 
- [फ़ॉलबैक फ़ॉन्ट्स संग्रह बनाएं](/slides/hi/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**फ़ॉलबैक फ़ॉन्ट, फ़ॉन्ट प्रतिस्थापन और फ़ॉन्ट एम्बेडिंग में क्या अंतर है?**

फ़ॉलबैक फ़ॉन्ट केवल उन अक्षरों के लिए उपयोग किया जाता है जो प्राथमिक फ़ॉन्ट में अनुपलब्ध होते हैं। [फ़ॉन्ट प्रतिस्थापन](/slides/hi/cpp/font-substitution/) पूरी निर्दिष्ट फ़ॉन्ट को दूसरी फ़ॉन्ट से बदल देता है। [फ़ॉन्ट एम्बेडिंग](/slides/hi/cpp/embedded-font/) फ़ॉन्ट्स को आउटपुट फ़ाइल के भीतर पैकेज कर देता है ताकि प्राप्तकर्ता इच्छित रूप में पाठ देख सकें।

**क्या फ़ॉलबैक फ़ॉन्ट्स निर्यात (PDF, PNG, या SVG) के दौरान लागू होते हैं, या केवल स्क्रीन पर रेंडरिंग के समय?**

हाँ। फ़ॉलबैक सभी [रेंडरिंग और निर्यात ऑपरेशन्स](/slides/hi/cpp/convert-presentation/) पर प्रभाव डालता है जहाँ अक्षरों को खींचना आवश्यक है लेकिन स्रोत फ़ॉन्ट में अनुपलब्ध हैं।

**क्या फ़ॉलबैक कॉन्फ़िगर करने से प्रस्तुति फ़ाइल स्वयं बदलती है, और क्या यह सेटिंग भविष्य में खोलने पर बनी रहती है?**

नहीं। फ़ॉलबैक नियम आपके कोड में रनटाइम रेंडरिंग सेटिंग्स होते हैं; वे .pptx फ़ाइल के अंदर संग्रहीत नहीं होते और PowerPoint में दिखाई नहीं देंगे।

**क्या ऑपरेटिंग सिस्टम (Windows/Linux/macOS) और फ़ॉन्ट डायरेक्टरीज़ का सेट फ़ॉलबैक चयन को प्रभावित करता है?**

हाँ। इंजन उपलब्ध सिस्टम फ़ोल्डर्स और किसी भी [अतिरिक्त पथ](/slides/hi/cpp/custom-font/) से फ़ॉन्ट खोजता है। यदि कोई फ़ॉन्ट शारीरिक रूप से उपलब्ध नहीं है, तो उसे संदर्भित करने वाला नियम प्रभावी नहीं हो सकेगा।

**क्या फ़ॉलबैक WordArt, SmartArt और चार्ट्स के लिए काम करता है?**

हाँ। जब इन वस्तुओं में पाठ होता है, तो वही ग्लिफ़-प्रतिस्थापन तंत्र अनुपलब्ध अक्षरों को रेंडर करने के लिए लागू होता है।