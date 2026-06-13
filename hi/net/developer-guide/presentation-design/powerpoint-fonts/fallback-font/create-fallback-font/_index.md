---
title: ".NET में प्रस्तुतियों के लिए फ़ॉलबैक फ़ॉन्ट निर्दिष्ट करें"
linktitle: "फ़ॉलबैक फ़ॉन्ट"
type: docs
weight: 10
url: /hi/net/create-fallback-font/
keywords:
- फ़ॉलबैक फ़ॉन्ट
- फ़ॉलबैक नियम
- फ़ॉन्ट लागू करें
- फ़ॉन्ट बदलें
- Unicode श्रेणी
- छूटा ग्लिफ़
- सही ग्लिफ़
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET को महारत हासिल करें ताकि PPT, PPTX और ODP फ़ाइलों में फ़ॉलबैक फ़ॉन्ट सेट कर सकें, जिससे किसी भी डिवाइस या OS पर सुसंगत टेक्स्ट प्रदर्शन सुनिश्चित हो।"
---
## **सारांश**

Aspose.Slides आपको प्रस्तुति रेंडरिंग और निर्यात संचालन के लिए फ़ॉलबैक फ़ॉन्ट निर्दिष्ट करने की अनुमति देता है। फ़ॉलबैक फ़ॉन्ट तब उपयोग किए जाते हैं जब प्राथमिक फ़ॉन्ट में विशिष्ट अक्षरों के लिए ग्लिफ़ नहीं होते हैं।

फ़ॉलबैक व्यवहार को फ़ॉलबैक नियमों के माध्यम से कॉन्फ़िगर किया जाता है। प्रत्येक नियम एक Unicode सीमा को एक या अधिक फ़ॉन्ट्स से जोड़ता है जो आवश्यक ग्लिफ़ रख सकते हैं। आप विभिन्न अक्षर सीमाओं के लिए नियम परिभाषित कर सकते हैं, मौजूदा नियमों से फ़ॉलबैक फ़ॉन्ट जोड़ या हटा सकते हैं, और फ़ॉलबैक फ़ॉन्ट नियम संग्रह में कई नियमों को व्यवस्थित कर सकते हैं।

फ़ॉलबैक नियम रनटाइम रेंडरिंग सेटिंग्स हैं। वे प्रस्तुति फ़ाइल को स्वयं नहीं बदलते और PPTX फ़ाइल के भीतर संग्रहीत नहीं होते।

## **फ़ॉलबैक नियम**

Aspose.Slides [IFontFallBackRule](https://reference.aspose.com/slides/hi/net/aspose.slides/iFontFallBackRule) इंटरफ़ेस और [FontFallBackRule](https://reference.aspose.com/slides/hi/net/aspose.slides/FontFallBackRule) क्लास को समर्थन देता है ताकि फ़ॉलबैक फ़ॉन्ट लागू करने के नियम निर्दिष्ट किए जा सकें। [FontFallBackRule](https://reference.aspose.com/slides/hi/net/aspose.slides/FontFallBackRule) क्लास निर्दिष्ट Unicode सीमा, जो छूटे हुए ग्लिफ़ को खोजने के लिए उपयोग की जाती है, और फ़ॉन्ट्स की सूची के बीच संबंध दर्शाती है जो उपयुक्त ग्लिफ़ रख सकते हैं:

```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//कई तरीकों का उपयोग करके आप फ़ॉन्ट सूची जोड़ सकते हैं:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

मौजूद [FontFallBackRule](https://reference.aspose.com/slides/hi/net/aspose.slides/FontFallBackRule) ऑब्जेक्ट में फ़ॉलबैक फ़ॉन्ट को [Remove()](https://reference.aspose.com/slides/hi/net/aspose.slides/ifontfallbackrule/methods/remove) करके हटाना या [AddFallBackFonts()](https://reference.aspose.com/slides/hi/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) जोड़ना भी संभव है।

[FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/hi/net/aspose.slides/fontfallbackrulescollection) का उपयोग [FontFallBackRule](https://reference.aspose.com/slides/hi/net/aspose.slides/FontFallBackRule) ऑब्जेक्ट्स की सूची को व्यवस्थित करने के लिए किया जा सकता है, जब कई Unicode सीमाओं के लिए फ़ॉलबैक फ़ॉन्ट प्रतिस्थापन नियम निर्दिष्ट करने की आवश्यकता होती है।

{{% alert color="primary" title="साथ देखें" %}} 
- [फ़ॉलबैक फ़ॉन्ट संग्रह बनाएँ](/slides/hi/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**फ़ॉलबैक फ़ॉन्ट, फ़ॉन्ट प्रतिस्थापन, और फ़ॉन्ट एम्बेडिंग में क्या अंतर है?**

फ़ॉलबैक फ़ॉन्ट केवल प्राथमिक फ़ॉन्ट में लापता अक्षरों के लिए उपयोग किया जाता है। [Font substitution](/slides/hi/net/font-substitution/) निर्दिष्ट फ़ॉन्ट को पूरी तरह से किसी अन्य फ़ॉन्ट से बदलता है। [Font embedding](/slides/hi/net/embedded-font/) फ़ॉन्ट्स को आउटपुट फ़ाइल में पैकेज करता है ताकि प्राप्तकर्ता इच्छित रूप में टेक्स्ट देख सकें।

**क्या फ़ॉलबैक फ़ॉन्ट PDF, PNG, या SVG जैसे निर्यात के दौरान लागू होते हैं, या केवल स्क्रीन रेंडरिंग पर?**

हाँ। फ़ॉलबैक उन सभी [rendering and export operations](/slides/hi/net/convert-presentation/) को प्रभावित करता है जहाँ अक्षरों को ड्रॉ करना आवश्यक है लेकिन स्रोत फ़ॉन्ट में वे अनुपलब्ध हैं।

**क्या फ़ॉलबैक को कॉन्फ़िगर करना स्वयं प्रस्तुति फ़ाइल को बदलता है, और क्या यह सेटिंग भविष्य में खोलने पर बनी रहेगी?**

नहीं। फ़ॉलबैक नियम आपके कोड में रनटाइम रेंडरिंग सेटिंग्स हैं; वे .pptx के भीतर संग्रहीत नहीं होते और पॉवरपॉइंट में दिखाई नहीं देंगे।

**क्या ऑपरेटिंग सिस्टम (Windows/Linux/macOS) और फ़ॉन्ट डायरेक्टरीज़ का सेट फ़ॉलबैक चयन को प्रभावित करता है?**

हाँ। इंजन उपलब्ध सिस्टम फ़ोल्डरों और आपके द्वारा प्रदान किए गए किसी भी [additional paths](/slides/hi/net/custom-font/) से फ़ॉन्ट्स को हल करता है। यदि कोई फ़ॉन्ट शारीरिक रूप से उपलब्ध नहीं है, तो उसे संदर्भित करने वाला नियम प्रभावी नहीं हो सकता।

**क्या फ़ॉलबैक WordArt, SmartArt, और चार्ट्स के लिए काम करता है?**

हाँ। जब इन वस्तुओं में टेक्स्ट होता है, तो वही ग्लिफ़‑सब्स्टीट्यूशन तंत्र लापता अक्षरों को रेंडर करने के लिए लागू होता है।