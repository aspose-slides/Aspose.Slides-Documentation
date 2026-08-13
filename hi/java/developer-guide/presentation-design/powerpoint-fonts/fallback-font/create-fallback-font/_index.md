---
title: जावा में प्रस्तुतियों के लिए फ़ॉलबैक फ़ॉन्ट निर्दिष्ट करें
linktitle: फ़ॉलबैक फ़ॉन्ट
type: docs
weight: 10
url: /hi/java/create-fallback-font/
keywords:
- फ़ॉलबैक फ़ॉन्ट
- फ़ॉलबैक नियम
- फ़ॉन्ट लागू करें
- फ़ॉन्ट बदलें
- यूनिकोड रेंज
- छूटा हुआ ग्लाइफ़
- उपयुक्त ग्लाइफ़
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "जावा के लिए Aspose.Slides में महारत्व हासिल करें ताकि PPT, PPTX और ODP फ़ाइलों में फ़ॉलबैक फ़ॉन्ट सेट कर सकें, जिससे किसी भी डिवाइस या OS पर निरंतर टेक्स्ट प्रदर्शन सुनिश्चित हो।"
---
## **अवलोकन**

Aspose.Slides आपको प्रस्तुति रेंडरिंग और निर्यात संचालन के लिए फ़ॉलबैक फ़ॉन्ट निर्दिष्ट करने की अनुमति देता है। फ़ॉलबैक फ़ॉन्ट तब उपयोग किए जाते हैं जब प्राथमिक फ़ॉन्ट में विशिष्ट अक्षरों के लिए ग्लाइफ़ नहीं होते।

फ़ॉलबैक व्यवहार फ़ॉलबैक नियमों के माध्यम से कॉन्फ़िगर किया जाता है। प्रत्येक नियम यूनिकोड रेंज को एक या अधिक फ़ॉन्ट्स के साथ जोड़ता है जो आवश्यक ग्लाइफ़ रख सकते हैं। आप विभिन्न अक्षर रेंजों के लिए नियम परिभाषित कर सकते हैं, मौजूदा नियमों से फ़ॉलबैक फ़ॉन्ट जोड़ या हटा सकते हैं, और कई नियमों को फ़ॉलबैक फ़ॉन्ट नियम संग्रह में व्यवस्थित कर सकते हैं।

फ़ॉलबैक नियम रनटाइम रेंडरिंग सेटिंग्स हैं। वे प्रस्तुति फ़ाइल को स्वयं नहीं बदलते और PPTX फ़ाइल के अंदर संग्रहीत नहीं होते।

## **फ़ॉलबैक नियम**

Aspose.Slides [IFontFallBackRule](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IFontFallBackRule) इंटरफ़ेस और [FontFallBackRule](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontFallBackRule) क्लास को समर्थन देता है ताकि फ़ॉलबैक फ़ॉन्ट लागू करने के नियम निर्दिष्ट किए जा सकें। [FontFallBackRule](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontFallBackRule) क्लास निर्दिष्ट यूनिकोड रेंज, जो खोए हुए ग्लाइफ़ खोजने के लिए उपयोग होती है, और फ़ॉन्ट्स की सूची के बीच एक संबंध दर्शाती है जो उचित ग्लाइफ़ रख सकते हैं:

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//फ़ॉन्ट सूची जोड़ने के कई तरीके:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

यह भी संभव है कि मौजूदा [FontFallBackRule](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontFallBackRule) ऑब्जेक्ट से फ़ॉलबैक फ़ॉन्ट को [remove](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) किया जाए या [addFallBackFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) जोड़ें।

[FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontFallBackRulesCollection) का उपयोग कई यूनिकोड रेंजों के लिए फ़ॉलबैक फ़ॉन्ट प्रतिस्थापन नियम निर्दिष्ट करने की आवश्यकता होने पर [FontFallBackRule](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontFallBackRule) ऑब्जेक्ट की सूची व्यवस्थित करने के लिए किया जा सकता है।

{{% alert color="info" title="See also" %}} 
- [Create Fallback Fonts Collection](/slides/hi/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

### फ़ॉलबैक फ़ॉन्ट, फ़ॉन्ट प्रतिस्थापन और फ़ॉन्ट एम्बेडिंग में क्या अंतर है?

फ़ॉलबैक फ़ॉन्ट केवल उन अक्षरों के लिए उपयोग किया जाता है जो प्राथमिक फ़ॉन्ट में अनुपलब्ध हैं। [Font substitution](/slides/hi/java/font-substitution/) पूरी निर्दिष्ट फ़ॉन्ट को किसी अन्य फ़ॉन्ट से बदल देता है। [Font embedding](/slides/hi/java/embedded-font/) फ़ॉन्ट को आउटपुट फ़ाइल के भीतर पैकेज करता है ताकि प्राप्तकर्ता पाठ को इच्छित रूप में देख सकें।

### क्या फ़ॉलबैक फ़ॉन्ट निर्यातों जैसे PDF, PNG, या SVG में लागू होते हैं, या केवल स्क्रीन रेंडरिंग पर?

हां। फ़ॉलबैक उन सभी [rendering and export operations](/slides/hi/java/convert-presentation/) को प्रभावित करता है जहाँ अक्षरों को ड्रॉ करना आवश्यक है लेकिन स्रोत फ़ॉन्ट में वे मौजूद नहीं होते।

### क्या फ़ॉलबैक को कॉन्फ़िगर करना प्रस्तुति फ़ाइल को बदलता है, और क्या सेटिंग भविष्य में खोलने पर बनी रहती है?

नहीं। फ़ॉलबैक नियम आपके कोड में रनटाइम रेंडरिंग सेटिंग्स हैं; वे .pptx फ़ाइल के अंदर संग्रहीत नहीं होते और PowerPoint में नहीं दिखते।

### क्या ऑपरेटिंग सिस्टम (Windows/Linux/macOS) और फ़ॉन्ट डायरेक्टरी सेट फ़ॉलबैक चयन को प्रभावित करते हैं?

हां। इंजन उपलब्ध सिस्टम फ़ोल्डरों और आपके द्वारा प्रदान किए गए किसी भी [additional paths](/slides/hi/java/custom-font/) से फ़ॉन्ट हल करता है। यदि कोई फ़ॉन्ट शारीरिक रूप से उपलब्ध नहीं है, तो उसे संदर्भित करने वाला नियम प्रभावी नहीं हो सकता।

### क्या फ़ॉलबैक WordArt, SmartArt और चार्ट्स के लिए काम करता है?

हां। जब इन वस्तुओं में पाठ होता है, तो वही ग्लाइफ़‑सप्लेसमेंट तंत्र लागू होता है ताकि अनुपलब्ध अक्षरों को रेंडर किया जा सके।