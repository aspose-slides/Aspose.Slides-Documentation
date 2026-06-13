---
title: जावा में प्रस्तुतियों के लिए फ़ॉलबैक फ़ॉन्ट्स निर्धारित करें
linktitle: फ़ॉलबैक फ़ॉन्ट
type: docs
weight: 10
url: /hi/java/create-fallback-font/
keywords:
- फ़ॉलबैक फ़ॉन्ट
- फ़ॉलबैक नियम
- फ़ॉन्ट लागू करें
- फ़ॉन्ट बदलें
- Unicode रेंज
- ग़ायब ग्लिफ़
- उचित ग्लिफ़
- PowerPoint
- OpenDocument
- प्रस्तुतीकरण
- Java
- Aspose.Slides
description: "Aspose.Slides for Java को मास्टर करें ताकि PPT, PPTX और ODP फ़ाइलों में फ़ॉलबैक फ़ॉन्ट्स सेट कर सकें, जिससे किसी भी डिवाइस या OS पर सुसंगत टेक्स्ट डिस्प्ले सुनिश्चित हो।"
---
## **परिचय**

Aspose.Slides आपको प्रस्तुति रेंडरिंग और निर्यात कार्यों के लिए फ़ॉलबैक फ़ॉन्ट्स निर्दिष्ट करने की अनुमति देता है। फ़ॉलबैक फ़ॉन्ट्स तब उपयोग किए जाते हैं जब प्राथमिक फ़ॉन्ट में विशिष्ट अक्षरों के लिए ग्लिफ़ नहीं होते हैं।

फ़ॉलबैक व्यवहार को फ़ॉलबैक नियमों के माध्यम से कॉन्फ़िगर किया जाता है। प्रत्येक नियम एक यूनिकोड रेंज को एक या अधिक फ़ॉन्ट्स के साथ जोड़ता है जो आवश्यक ग्लिफ़ रख सकते हैं। आप विभिन्न अक्षर रेंजों के लिए नियम परिभाषित कर सकते हैं, मौजूदा नियमों से फ़ॉलबैक फ़ॉन्ट्स जोड़ या हटा सकते हैं, और कई नियमों को फ़ॉलबैक फ़ॉन्ट नियम संग्रह में व्यवस्थित कर सकते हैं।

फ़ॉलबैक नियम रनटाइम रेंडरिंग सेटिंग्स हैं। ये प्रस्तुति फ़ाइल को स्वयं नहीं बदलते और PPTX फ़ाइल के अंदर संग्रहीत नहीं होते।

## **फ़ॉलबैक नियम**

Aspose.Slides [IFontFallBackRule](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IFontFallBackRule) इंटरफ़ेस और [FontFallBackRule](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontFallBackRule) क्लास को फ़ॉलबैक फ़ॉन्ट लागू करने के नियम निर्दिष्ट करने के लिए समर्थन देता है। [FontFallBackRule](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontFallBackRule) क्लास निर्दिष्ट यूनिकोड रेंज, जो मिस्ड ग्लिफ़ खोजने के लिए उपयोग होती है, और उन फ़ॉन्ट्स की सूची के बीच एक एसोसिएशन का प्रतिनिधित्व करती है जो उचित ग्लिफ़ रख सकते हैं:

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Using multiple ways you can add fonts list:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

यह भी संभव है कि आप मौजूदा [FontFallBackRule](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontFallBackRule) ऑब्जेक्ट में फ़ॉलबैक फ़ॉन्ट को [remove](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) या [addFallBackFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) जोड़ सकें।

[FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontFallBackRulesCollection) का उपयोग तब किया जा सकता है जब कई यूनिकोड रेंजों के लिए फ़ॉलबैक फ़ॉन्ट प्रतिस्थापन नियमों को निर्दिष्ट करने की आवश्यकता हो, ताकि [FontFallBackRule](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontFallBackRule) ऑब्जेक्ट्स की सूची को व्यवस्थित किया जा सके।

{{% alert color="primary" title="See also" %}} 
- [फ़ॉलबैक फ़ॉन्ट्स संग्रह बनाएं](/slides/hi/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**फ़ॉलबैक फ़ॉन्ट, फ़ॉन्ट प्रतिस्थापन, और फ़ॉन्ट एम्बेडिंग में क्या अंतर है?**

फ़ॉलबैक फ़ॉन्ट केवल उन अक्षरों के लिए उपयोग किया जाता है जो प्राथमिक फ़ॉन्ट में अनुपलब्ध होते हैं। [Font substitution](/slides/hi/java/font-substitution/) पूरे निर्दिष्ट फ़ॉन्ट को किसी अन्य फ़ॉन्ट से बदल देता है। [Font embedding](/slides/hi/java/embedded-font/) फ़ॉन्ट्स को आउटपुट फ़ाइल के अंदर पैकेज करता है ताकि प्राप्तकर्ता टेक्स्ट को इच्छित रूप में देख सकें।

**क्या फ़ॉलबैक फ़ॉन्ट्स PDF, PNG, या SVG जैसे निर्यातों के दौरान लागू होते हैं, या केवल स्क्रीन रेंडरिंग पर?**

हाँ। फ़ॉलबैक सभी [rendering and export operations](/slides/hi/java/convert-presentation/) को प्रभावित करता है जहाँ अक्षरों को चित्रित करना आवश्यक है लेकिन स्रोत फ़ॉन्ट में वे मौजूद नहीं हैं।

**क्या फ़ॉलबैक को कॉन्फ़िगर करने से प्रस्तुति फ़ाइल स्वयं बदलती है, और क्या यह सेटिंग भविष्य में खुलने पर भी बनी रहती है?**

नहीं। फ़ॉलबैक नियम आपके कोड में रनटाइम रेंडरिंग सेटिंग्स होते हैं; वे .pptx के अंदर संग्रहीत नहीं होते और PowerPoint में दिखाई नहीं देते।

**क्या ऑपरेटिंग सिस्टम (Windows/Linux/macOS) और फ़ॉन्ट निर्देशिकाओं का सेट फ़ॉलबैक चयन को प्रभावित करता है?**

हाँ। इंजन उपलब्ध सिस्टम फ़ोल्डरों और आप द्वारा प्रदान किए गए किसी भी [additional paths](/slides/hi/java/custom-font/) से फ़ॉन्ट्स को हल करता है। यदि कोई फ़ॉन्ट शारीरिक रूप से उपलब्ध नहीं है, तो उसका संदर्भ देने वाला नियम प्रभावी नहीं हो सकता।

**क्या फ़ॉलबैक WordArt, SmartArt और चार्ट्स के लिए काम करता है?**

हाँ। जब इन वस्तुओं में टेक्स्ट होता है, तो वही ग्लिफ़‑प्रतिस्थापन तंत्र लागू होता है जिससे अनुपलब्ध अक्षर रेंडर किए जाते हैं।