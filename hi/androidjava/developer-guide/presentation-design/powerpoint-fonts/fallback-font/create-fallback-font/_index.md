---
title: Android पर प्रस्तुतियों के लिए फ़ॉलबैक फ़ॉन्ट्स निर्दिष्ट करें
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
- लापता ग्लिफ़
- उचित ग्लिफ़
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Java के माध्यम से Android के लिए Aspose.Slides में निपुण बनें, ताकि PPT, PPTX और ODP फ़ाइलों में फ़ॉलबैक फ़ॉन्ट सेट किए जा सकें, जिससे किसी भी उपकरण या OS पर स्थिर टेक्स्ट प्रदर्शन सुनिश्चित हो।"
---
## **अवलोकन**

Aspose.Slides आपको प्रस्तुति रेंडरिंग और निर्यात संचालन के लिए फॉलबैक फ़ॉन्ट्स निर्दिष्ट करने की अनुमति देता है। फॉलबैक फ़ॉन्ट्स का उपयोग तब किया जाता है जब मुख्य फ़ॉन्ट में विशेष अक्षरों के लिए ग्लिफ़ उपलब्ध नहीं होते हैं।

फ़ॉलबैक व्यवहार फ़ॉलबैक नियमों के माध्यम से कॉन्फ़िगर किया जाता है। प्रत्येक नियम एक यूनिकोड सीमा को एक या अधिक फ़ॉन्ट्स के साथ जोड़ता है जो आवश्यक ग्लिफ़ रख सकते हैं। आप विभिन्न अक्षर रेंज के लिए नियम परिभाषित कर सकते हैं, मौजूदा नियमों से फ़ॉलबैक फ़ॉन्ट जोड़ या हटाकर, और कई नियमों को फ़ॉलबैक फ़ॉन्ट नियम संग्रह में व्यवस्थित कर सकते हैं।

फ़ॉलबैक नियम रन‑टाइम रेंडरिंग सेटिंग्स हैं। वे प्रस्तुति फ़ाइल को स्वयं संशोधित नहीं करते और PPTX फ़ाइल के अंदर संग्रहीत नहीं होते।

## **फ़ॉलबैक नियम**

Aspose.Slides [IFontFallBackRule](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IFontFallBackRule) इंटरफ़ेस और [FontFallBackRule](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontFallBackRule) क्लास का समर्थन करता है ताकि फ़ॉलबैक फ़ॉन्ट लागू करने के नियम निर्दिष्ट किए जा सकें। [FontFallBackRule](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontFallBackRule) क्लास उन यूनिकोड रेंज के बीच एक संबध दर्शाता है, जिसका उपयोग लापता ग्लिफ़ खोजने के लिए किया जाता है, और एक फ़ॉन्ट्स की सूची जो उपयुक्त ग्लिफ़ रख सकते हैं:

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//फ़ॉन्ट सूची जोड़ने के कई तरीकों का उपयोग करके:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

यह भी संभव है कि आप मौजूदा [FontFallBackRule](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontFallBackRule) ऑब्जेक्ट में फ़ॉलबैक फ़ॉन्ट को [remove](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) कर सकें या [addFallBackFonts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) जोड़ सकें।

[FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontFallBackRulesCollection) का उपयोग कई यूनिकोड रेंज के लिए फ़ॉलबैक फ़ॉन्ट प्रतिस्थापन नियम निर्दिष्ट करने की आवश्यकता होने पर [FontFallBackRule](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontFallBackRule) ऑब्जेक्ट्स की सूची को व्यवस्थित करने के लिए किया जा सकता है।

{{% alert color="info" title="इसी को भी देखें" %}} 
- [फ़ॉलबैक फ़ॉन्ट्स संग्रह बनाएं](/slides/hi/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

### फॉलबैक फ़ॉन्ट, फ़ॉन्ट प्रतिस्थापन, और फ़ॉन्ट एम्बेडिंग में क्या अंतर है?

फ़ॉलबैक फ़ॉन्ट केवल उन अक्षरों के लिए उपयोग किया जाता है जो मुख्य फ़ॉन्ट में अनुपलब्ध होते हैं। [फ़ॉन्ट प्रतिस्थापन](/slides/hi/androidjava/font-substitution/) निर्दिष्ट फ़ॉन्ट को पूरी तरह से किसी अन्य फ़ॉन्ट से बदल देता है। [फ़ॉन्ट एम्बेडिंग](/slides/hi/androidjava/embedded-font/) फ़ॉन्ट को आउटपुट फ़ाइल में पैकेज करता है ताकि प्राप्तकर्ता टेक्स्ट को इच्छित रूप में देख सकें।

### क्या फ़ॉलबैक फ़ॉन्ट केवल स्क्रीन रेंडरिंग के लिए लागू होते हैं या PDF, PNG, SVG जैसे निर्यात में भी?

हां। फ़ॉलबैक सभी [रेंडरिंग और निर्यात संचालन](/slides/hi/androidjava/convert-presentation/) पर प्रभाव डालता है जहाँ अक्षर चाहिए होते हैं लेकिन स्रोत फ़ॉन्ट में उपलब्ध नहीं होते।

### क्या फ़ॉलबैक को कॉन्फ़िगर करने से प्रस्तुति फ़ाइल स्वयं बदलती है, और क्या यह सेटिंग भविष्य में खोलने पर बनी रहती है?

नहीं। फ़ॉलबैक नियम आपके कोड में रन‑टाइम रेंडरिंग सेटिंग्स हैं; वे .pptx फ़ाइल के अंदर संग्रहीत नहीं होते और पॉवरपॉइंट में दिखाई नहीं देते।

### क्या ऑपरेटिंग सिस्टम (Windows/Linux/macOS) और फ़ॉन्ट डायरेक्टरीज़ का सेट फ़ॉलबैक चयन को प्रभावित करता है?

हां। इंजन उपलब्ध सिस्टम फ़ोल्डर्स और आप द्वारा निर्दिष्ट किसी भी [अतिरिक्त पथ](/slides/hi/androidjava/custom-font/) से फ़ॉन्ट्स खोजता है। यदि कोई फ़ॉन्ट शारीरिक रूप से उपलब्ध नहीं है, तो उसे संदर्भित करने वाला नियम प्रभावी नहीं हो सकता।

### क्या फ़ॉलबैक WordArt, SmartArt, और चार्ट्स के लिए काम करता है?

हां। जब इन वस्तुओं में टेक्स्ट होता है, तो लापता अक्षरों को रेंडर करने के लिए वही ग्लिफ़‑सब्सटिट्यूशन मैकेनिज़्म लागू होता है।