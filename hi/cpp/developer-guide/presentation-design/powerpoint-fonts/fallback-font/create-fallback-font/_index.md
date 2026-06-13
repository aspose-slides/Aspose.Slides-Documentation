---
title: C++ में प्रस्तुतियों के लिए फ़ॉलबैक फ़ॉन्ट निर्दिष्ट करें
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
- लापता ग्लिफ़
- सही ग्लिफ़
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "C++ के लिए Aspose.Slides में निपुण बनें ताकि PPT, PPTX और ODP फ़ाइलों में फ़ॉलबैक फ़ॉन्ट सेट कर सकें, और किसी भी डिवाइस या OS पर सुसंगत टेक्स्ट प्रदर्शन सुनिश्चित हो सके।"
---
## **अवलोकन**

Aspose.Slides आपको प्रस्तुति रेंडरिंग और निर्यात संचालन के लिए फ़ॉलबैक फ़ॉन्ट निर्दिष्ट करने की अनुमति देता है। फ़ॉलबैक फ़ॉन्ट तब उपयोग किए जाते हैं जब प्राथमिक फ़ॉन्ट में विशेष वर्णों के लिए ग्लिफ़ नहीं होते।

फ़ॉलबैक व्यवहार फ़ॉलबैक नियमों के माध्यम से कॉन्फ़िगर किया जाता है। प्रत्येक नियम एक यूनिकोड रेंज को एक या अधिक फ़ॉन्टों के साथ जोड़ता है जो आवश्यक ग्लिफ़ रख सकते हैं। आप विभिन्न वर्ण रेंजों के लिए नियम परिभाषित कर सकते हैं, मौजूदा नियमों में फ़ॉलबैक फ़ॉन्ट जोड़ या हट सकते हैं, और कई नियमों को फ़ॉलबैक फ़ॉन्ट नियम संग्रह में व्यवस्थित कर सकते हैं।

फ़ॉलबैक नियम रनटाइम रेंडरिंग सेटिंग्स हैं। वे प्रस्तुति फ़ाइल को स्वयं संशोधित नहीं करते और PPTX फ़ाइल के भीतर संग्रहीत नहीं होते।

## **फ़ॉलबैक नियम**

Aspose.Slides [IFontFallBackRule](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifontfallbackrule/) इंटरफ़ेस और [FontFallBackRule](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontfallbackrule/) क्लास का समर्थन करता है ताकि फ़ॉलबैक फ़ॉन्ट लागू करने के नियम निर्दिष्ट किए जा सकें। [FontFallBackRule](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontfallbackrule/) क्लास उस यूनिकोड रेंज, जिसका उपयोग लापता ग्लिफ़ खोजने के लिए किया जाता है, और फ़ॉन्टों की सूची के बीच संबंध को दर्शाती है जो उचित ग्लिफ़ रख सकते हैं:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// कई तरीकों से आप फ़ॉन्ट सूची जोड़ सकते हैं:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```



यह भी संभव है कि आप मौजूदा [FontFallBackRule](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontfallbackrule/) ऑब्जेक्ट में फ़ॉलबैक फ़ॉन्ट को [Remove()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifontfallbackrule/remove/) करें या [AddFallBackFonts()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) जोड़ें।

[FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontfallbackrulescollection/) का उपयोग [FontFallBackRule](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontfallbackrule/) ऑब्जेक्ट्स की सूची को व्यवस्थित करने के लिए किया जा सकता है, जब कई यूनिकोड रेंजों के लिए फ़ॉलबैक फ़ॉन्ट प्रतिस्थापन नियमों को निर्दिष्ट करने की आवश्यकता होती है।

{{% alert color="primary" title="और देखें" %}} 
- [फ़ॉलबैक फ़ॉन्ट संग्रह बनाएं](/slides/hi/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**फ़ॉलबैक फ़ॉन्ट, फ़ॉन्ट प्रतिस्थापन और फ़ॉन्ट एम्बेडिंग में क्या अंतर है?**

फ़ॉलबैक फ़ॉन्ट केवल उन वर्णों के लिए उपयोग किया जाता है जो प्राथमिक फ़ॉन्ट में अनुपलब्ध होते हैं। [फ़ॉन्ट प्रतिस्थापन](/slides/hi/cpp/font-substitution/) निर्दिष्ट फ़ॉन्ट को पूरी तरह से किसी अन्य फ़ॉन्ट से बदल देता है। [फ़ॉन्ट एम्बेडिंग](/slides/hi/cpp/embedded-font/) फ़ॉन्ट को आउटपुट फ़ाइल में पैकेज कर देता है ताकि प्राप्तकर्ता टेक्स्ट को इरादे के अनुसार देख सकें।

**क्या फ़ॉलबैक फ़ॉन्ट निर्यात जैसे PDF, PNG, या SVG के दौरान लागू होते हैं, या केवल स्क्रीन रेंडरिंग पर?**

हाँ। फ़ॉलबैक सभी [रेंडरिंग और निर्यात संचालन](/slides/hi/cpp/convert-presentation/) को प्रभावित करता है जहाँ वर्णों को ड्रॉ करना आवश्यक है लेकिन स्रोत फ़ॉन्ट में वे उपस्थित नहीं होते।

**क्या फ़ॉलबैक कॉन्फ़िगर करने से प्रस्तुति फ़ाइल स्वयं बदलती है, और क्या सेटिंग भविष्य में खोलने पर बनी रहती है?**

नहीं। फ़ॉलबैक नियम आपके कोड में रनटाइम रेंडरिंग सेटिंग्स होते हैं; वे .pptx के अंदर संग्रहीत नहीं होते और PowerPoint में दिखाई नहीं देंगे।

**क्या ऑपरेटिंग सिस्टम (Windows/Linux/macOS) और फ़ॉन्ट डायरेक्टरी सेट फ़ॉलबैक चयन को प्रभावित करते हैं?**

हाँ। इंजन उपलब्ध सिस्टम फ़ोल्डरों और आप द्वारा प्रदान किए गए किसी भी [अतिरिक्त पथ](/slides/hi/cpp/custom-font/) से फ़ॉन्ट को हल करता है। यदि कोई फ़ॉन्ट शारीरिक रूप से उपलब्ध नहीं है, तो उसे संदर्भित करने वाला नियम प्रभावी नहीं हो सकता।

**क्या फ़ॉलबैक WordArt, SmartArt और चार्ट्स के लिए काम करता है?**

हाँ। जब इन वस्तुओं में टेक्स्ट होता है, तो लापता वर्णों को रेंडर करने हेतु वही ग्लिफ़‑प्रतिस्थापन तंत्र लागू होता है।