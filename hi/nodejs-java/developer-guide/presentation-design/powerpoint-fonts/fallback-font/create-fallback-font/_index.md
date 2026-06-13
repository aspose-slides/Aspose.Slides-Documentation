---
title: जावास्क्रिप्ट में प्रस्तुतियों के लिए फॉलबैक फ़ॉन्ट निर्दिष्ट करें
linktitle: फ़ॉलबैक फ़ॉन्ट
type: docs
weight: 10
url: /hi/nodejs-java/create-fallback-font/
keywords:
- फॉलबैक फ़ॉन्ट
- फॉलबैक नियम
- फ़ॉन्ट लागू करें
- फ़ॉन्ट बदलें
- यूनिकोड रेंज
- नहीं मिला ग्लिफ़
- उचित ग्लिफ़
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js के लिए Aspose.Slides को महारत हासिल करें ताकि जावास्क्रिप्ट में PPT, PPTX और ODP फ़ाइलों में फॉलबैक फ़ॉन्ट सेट किए जा सकें, जिससे किसी भी डिवाइस या ऑपरेटिंग सिस्टम पर सुसंगत टेक्स्ट डिस्प्ले सुरक्षित रहे।"
---
## **अवलोकन**

Aspose.Slides आपको प्रस्तुति रेंडरिंग और निर्यात संचालन के लिए फॉलबैक फ़ॉन्ट निर्दिष्ट करने की अनुमति देता है। फॉलबैक फ़ॉन्ट्स का उपयोग तब किया जाता है जब प्राथमिक फ़ॉन्ट में विशिष्ट अक्षरों के लिए ग्लिफ़ नहीं होते हैं।

फ़ॉलबैक व्यवहार को फॉलबैक नियमों के माध्यम से कॉन्फ़िगर किया जाता है। प्रत्येक नियम एक यूनिकोड रेंज को एक या अधिक फ़ॉन्ट्स के साथ जोड़ता है जो आवश्यक ग्लिफ़्स रख सकते हैं। आप विभिन्न अक्षर रेंजों के लिए नियम निर्धारित कर सकते हैं, मौजूदा नियमों से फ़ॉलबैक फ़ॉन्ट जोड़ या हटा सकते हैं, और कई नियमों को एक फ़ॉलबैक फ़ॉन्ट नियम संग्रह में व्यवस्थित कर सकते हैं।

फ़ॉलबैक नियम रनटाइम रेंडरिंग सेटिंग्स हैं। वे प्रस्तुति फ़ाइल को स्वयं नहीं बदलते और PPTX फ़ाइल के भीतर संग्रहीत नहीं होते।

## **फ़ॉलबैक नियम**

Aspose.Slides फ़ॉलबैक फ़ॉन्ट लागू करने के नियम निर्धारित करने के लिए [FontFallBackRule](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/FontFallBackRule) वर्ग और [FontFallBackRule](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/FontFallBackRule) वर्ग का समर्थन करता है। [FontFallBackRule](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/FontFallBackRule) वर्ग निर्दिष्ट यूनिकोड रेंज, जो खोई हुई ग्लिफ़्स की खोज के लिए उपयोग होती है, और फ़ॉन्ट्स की सूची के बीच एक संबन्ध को दर्शाता है जो उचित ग्लिफ़्स रख सकते हैं:

```javascript
var startUnicodeIndex = 0xb80;
var endUnicodeIndex = 0xbff;
var firstRule = new aspose.slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
var secondRule = new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
// कई तरीकों का उपयोग करके आप फ़ॉन्ट सूची जोड़ सकते हैं:
var fontNames = java.newArray("java.lang.String", ["Segoe UI Emoji, Segue UI Symbol", "Arial"]));
var thirdRule = new aspose.slides.FontFallBackRule(0x1f300, 0x1f64f, fontNames);
```

यह भी संभव है कि मौजूदा [FontFallBackRule](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/FontFallBackRule) ऑब्जेक्ट में फ़ॉलबैक फ़ॉन्ट को [remove](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) करें या [addFallBackFonts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) को जोड़ें।

[FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/FontFallBackRulesCollection) का उपयोग [FontFallBackRule](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/FontFallBackRule) ऑब्जेक्ट्स की सूची को व्यवस्थित करने के लिए किया जा सकता है, जब कई यूनिकोड रेंजों के लिए फ़ॉलबैक फ़ॉन्ट प्रतिस्थापन नियम निर्दिष्ट करने की आवश्यकता हो।

{{% alert color="primary" title="और देखें" %}} 
- [फ़ॉलबैक फ़ॉन्ट संग्रह बनाएँ](/slides/hi/nodejs-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**फ़ॉलबैक फ़ॉन्ट, फ़ॉन्ट प्रतिस्थापन, और फ़ॉन्ट एम्बेडिंग में क्या अंतर है?**

फ़ॉलबैक फ़ॉन्ट केवल उन वर्णों के लिए उपयोग किया जाता है जो प्राथमिक फ़ॉन्ट में अनुपस्थित होते हैं। [Font substitution](/slides/hi/nodejs-java/font-substitution/) निर्दिष्ट फ़ॉन्ट को पूरी तरह से किसी अन्य फ़ॉन्ट से बदल देता है। [Font embedding](/slides/hi/nodejs-java/embedded-font/) फ़ॉन्ट्स को आउटपुट फ़ाइल के भीतर पैकेज करता है ताकि प्राप्तकर्ता पाठ को इच्छित रूप में देख सकें।

**क्या फ़ॉलबैक फ़ॉन्ट्स को PDF, PNG, या SVG जैसे निर्यात के दौरान लागू किया जाता है, या केवल ऑन-स्क्रीन रेंडरिंग पर?**

हां। फ़ॉलबैक सभी [rendering and export operations](/slides/hi/nodejs-java/convert-presentation/) पर प्रभाव डालता है जहाँ वर्णों को खींचना आवश्यक है लेकिन स्रोत फ़ॉन्ट में वे अनुपस्थित होते हैं।

**क्या फ़ॉलबैक को कॉन्फ़िगर करने से प्रस्तुति फ़ाइल स्वयं बदलती है, और क्या यह सेटिंग भविष्य के खोलने पर बनी रहती है?**

नहीं। फ़ॉलबैक नियम आपके कोड में रनटाइम रेंडरिंग सेटिंग्स होते हैं; वे .pptx के भीतर संग्रहीत नहीं होते और PowerPoint में दिखाई नहीं देंगे।

**क्या ऑपरेटिंग सिस्टम (Windows/Linux/macOS) और फ़ॉन्ट डिरेक्टरी सेट फ़ॉलबैक चयन को प्रभावित करता है?**

हां। इंजन उपलब्ध सिस्टम फ़ोल्डर्स और आपके द्वारा प्रदान किए गए किसी भी [additional paths](/slides/hi/nodejs-java/custom-font/) से फ़ॉन्ट्स को खोजता है। यदि कोई फ़ॉन्ट वास्तविक रूप से उपलब्ध नहीं है, तो उसे संदर्भित करने वाला नियम प्रभावी नहीं हो सकता।

**क्या फ़ॉलबैक WordArt, SmartArt और चार्ट्स के लिए काम करता है?**

हां। जब इन ऑब्जेक्ट्स में पाठ होता है, तो समान ग्लिफ़-प्रतिस्थापन तंत्र लागू होता है जिससे अनुपस्थित वर्ण रेंडर हो जाते हैं।