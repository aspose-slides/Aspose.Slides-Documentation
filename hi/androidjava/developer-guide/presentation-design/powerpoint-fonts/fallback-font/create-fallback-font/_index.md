---
title: Android पर प्रस्तुतियों के लिए फ़ॉलबैक फ़ॉन्ट निर्दिष्ट करें
linktitle: फ़ॉलबैक फ़ॉन्ट
type: docs
weight: 10
url: /hi/androidjava/create-fallback-font/
keywords:
- फ़ॉलबैक फ़ॉन्ट
- फ़ॉलबैक नियम
- फ़ॉन्ट लागू करें
- फ़ॉन्ट बदलें
- Unicode रेंज
- गायब ग्लिफ़
- सही ग्लिफ़
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Java के माध्यम से Android के लिए Aspose.Slides में निपुण बनें, PPT, PPTX और ODP फ़ाइलों में फ़ॉलबैक फ़ॉन्ट सेट करने के लिए, और किसी भी डिवाइस या OS पर सुसंगत टेक्स्ट डिस्प्ले को सुरक्षित रखें।"
---
## **अवलोकन**

Aspose.Slides आपको प्रस्तुति रेंडरिंग और निर्यात संचालन के लिए फ़ॉलबैक फ़ॉन्ट निर्दिष्ट करने की अनुमति देता है। फ़ॉलबैक फ़ॉन्ट तब उपयोग किए जाते हैं जब प्राथमिक फ़ॉन्ट में विशिष्ट अक्षरों के लिए ग्लिफ़ उपलब्ध नहीं होते हैं।

फ़ॉलबैक व्यवहार फ़ॉलबैक नियमों के माध्यम से कॉन्फ़िगर किया जाता है। प्रत्येक नियम एक यूनिकोड रेंज को एक या अधिक फ़ॉन्ट्स के साथ जोड़ता है जो आवश्यक ग्लिफ़ रख सकते हैं। आप विभिन्न अक्षर रेंजों के लिए नियम परिभाषित कर सकते हैं, मौजूदा नियमों से फ़ॉलबैक फ़ॉन्ट जोड़ या हटा सकते हैं, और कई नियमों को फ़ॉलबैक फ़ॉन्ट नियम संग्रह में व्यवस्थित कर सकते हैं।

फ़ॉलबैक नियम रन‑टाइम रेंडरिंग सेटिंग्स हैं। वे प्रस्तुति फ़ाइल को स्वयं संशोधित नहीं करते और PPTX फ़ाइल के भीतर संग्रहीत नहीं होते।

## **फ़ॉलबैक नियम**

Aspose.Slides [IFontFallBackRule](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IFontFallBackRule) इंटरफ़ेस और [FontFallBackRule](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontFallBackRule) क्लास का समर्थन करता है ताकि फ़ॉलबैक फ़ॉन्ट लागू करने के नियम निर्दिष्ट किए जा सकें। [FontFallBackRule](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontFallBackRule) क्लास निर्दिष्ट यूनिकोड रेंज (जो अनुपस्थित ग्लिफ़ की खोज के लिए उपयोग होती है) और उन फ़ॉन्ट्स की सूची के बीच संबंध को दर्शाती है जिनमें उचित ग्लिफ़ हो सकते हैं:

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//फ़ॉन्ट सूची जोड़ने के कई तरीके:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

यह भी संभव है कि आप [remove](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) फ़ॉलबैक फ़ॉन्ट को हटा सकें या [addFallBackFonts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) को मौजूदा [FontFallBackRule](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontFallBackRule) ऑब्जेक्ट में जोड़ सकें।

[FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontFallBackRulesCollection) का उपयोग कई यूनिकोड रेंजों के लिए फ़ॉलबैक फ़ॉन्ट प्रतिस्थापन नियमों को निर्दिष्ट करने की आवश्यकता होने पर [FontFallBackRule](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontFallBackRule) ऑब्जेक्ट्स की सूची को व्यवस्थित करने के लिए किया जा सकता है।

{{% alert color="primary" title="See also" %}} 
- [फ़ॉलबैक फ़ॉन्ट संग्रह बनाएं](/slides/hi/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**फ़ॉलबैक फ़ॉन्ट, फ़ॉन्ट प्रतिस्थापन और फ़ॉन्ट एम्बेडिंग में क्या अंतर है?**

फ़ॉलबैक फ़ॉन्ट केवल उन अक्षरों के लिए उपयोग किया जाता है जो प्राथमिक फ़ॉन्ट में अनुपलब्ध होते हैं। [फ़ॉन्ट प्रतिस्थापन](/slides/hi/androidjava/font-substitution/) पूरे निर्दिष्ट फ़ॉन्ट को किसी अन्य फ़ॉन्ट से बदल देता है। [फ़ॉन्ट एम्बेडिंग](/slides/hi/androidjava/embedded-font/) फ़ॉन्ट को आउटपुट फ़ाइल के भीतर पैकेज करता है ताकि प्राप्तकर्ता टेक्स्ट को इच्छित रूप में देख सकें।

**क्या फ़ॉलबैक फ़ॉन्ट केवल स्क्रीन रेंडरिंग पर लागू होते हैं या PDF, PNG, SVG जैसे निर्यातों में भी?**

हाँ। फ़ॉलबैक सभी [रेंडरिंग और निर्यात संचालन](/slides/hi/androidjava/convert-presentation/) को प्रभावित करता है जहाँ अक्षरों को ड्रॉ करना आवश्यक है लेकिन स्रोत फ़ॉन्ट में वे मौजूद नहीं होते।

**क्या फ़ॉलबैक सेट करने से प्रस्तुति फ़ाइल स्वयं बदलती है, और क्या यह सेटिंग भविष्यात खोलने पर बनी रहती है?**

नहीं। फ़ॉलबैक नियम आपके कोड में रन‑टाइम रेंडरिंग सेटिंग्स होते हैं; वे .pptx फ़ाइल में संग्रहीत नहीं होते और पावरपॉइंट में दिखाई नहीं देंगे।

**क्या ऑपरेटिंग सिस्टम (Windows/Linux/macOS) और फ़ॉन्ट डायरेक्टरी का सेट फ़ॉलबैक चयन को प्रभावित करता है?**

हाँ। इंजन उपलब्ध सिस्टम फ़ोल्डरों और आपके द्वारा प्रदान किए गए [अतिरिक्त पाथ](/slides/hi/androidjava/custom-font/) से फ़ॉन्ट खोजता है। यदि कोई फ़ॉन्ट शारीरिक रूप से उपलब्ध नहीं है, तो उसे संदर्भित करने वाला नियम प्रभावी नहीं हो सकेगा।

**क्या फ़ॉलबैक WordArt, SmartArt और चार्ट्स के लिए काम करता है?**

हाँ। जब इन वस्तुओं में टेक्स्ट होता है, तो वही ग्लिफ़‑प्रतिस्थापन तंत्र अनुपस्थित अक्षरों को रेंडर करने के लिए लागू होता है।