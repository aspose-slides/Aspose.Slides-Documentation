---
title: Python में प्रस्तुतियों के लिए फ़ॉलबैक फ़ॉन्ट निर्दिष्ट करें
linktitle: फ़ॉलबैक फ़ॉन्ट
type: docs
weight: 10
url: /hi/python-net/create-fallback-font/
keywords:
- फ़ॉलबैक फ़ॉन्ट
- फ़ॉलबैक नियम
- फ़ॉन्ट लागू करें
- फ़ॉन्ट बदलें
- Unicode रेंज
- छूटा ग्लिफ़
- सही ग्लिफ़
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python को .NET के माध्यम से महारत हासिल करें ताकि PPT, PPTX और ODP फ़ाइलों में फ़ॉलबैक फ़ॉन्ट सेट किए जा सकें, जो किसी भी डिवाइस या ऑपरेटिंग सिस्टम पर सुसंगत टेक्स्ट प्रदर्शन को सुनिश्चित करता है।"
---
## **अवलोकन**

Aspose.Slides आपको प्रस्तुति रेंडरिंग और निर्यात कार्यों के लिए फ़ॉलबैक फ़ॉन्ट निर्दिष्ट करने की अनुमति देता है। फ़ॉलबैक फ़ॉन्ट तब उपयोग किए जाते हैं जब प्राथमिक फ़ॉन्ट में विशिष्ट अक्षरों के लिए ग्लिफ़ नहीं होते हैं।

फ़ॉलबैक व्यवहार को फ़ॉलबैक नियमों के माध्यम से कॉन्फ़िगर किया जाता है। प्रत्येक नियम एक Unicode रेंज को एक या अधिक फ़ॉन्ट्स से जोड़ता है जो आवश्यक ग्लिफ़ रख सकते हैं। आप विभिन्न अक्षर रेंजों के लिए नियम निर्धारित कर सकते हैं, मौजूदा नियमों से फ़ॉलबैक फ़ॉन्ट जोड़ या हटा सकते हैं, और कई नियमों को फ़ॉलबैक फ़ॉन्ट नियम संग्रह में व्यवस्थित कर सकते हैं।

फ़ॉलबैक नियम रन‑टाइम रेंडरिंग सेटिंग्स होते हैं। वे प्रस्तुति फ़ाइल को स्वयं संशोधित नहीं करते और PPTX फ़ाइल के भीतर संग्रहीत नहीं होते।

## **फ़ॉलबैक फ़ॉन्ट निर्दिष्ट करें**

Aspose.Slides फ़ॉलबैक फ़ॉन्ट लागू करने के नियम निर्दिष्ट करने के लिए [FontFallBackRule](https://reference.aspose.com/slides/hi/python-net/aspose.slides/FontFallBackRule/) क्लास का समर्थन करता है। [FontFallBackRule](https://reference.aspose.com/slides/hi/python-net/aspose.slides/FontFallBackRule/) क्लास निर्दिष्ट Unicode रेंज, जो मिस हुए ग्लिफ़ खोजने के लिए उपयोग होती है, और संभावित उपयुक्त ग्लिफ़ वाले फ़ॉन्ट्स की सूची के बीच एक संबंध दर्शाती है:

```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#विभिन्न तरीकों से आप फ़ॉन्ट सूची जोड़ सकते हैं:
fontNames =  ["Segoe UI Emoji, Segumo UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```

मौजूदा [FontFallBackRule](https://reference.aspose.com/slides/hi/python-net/aspose.slides/FontFallBackRule/) ऑब्जेक्ट में फ़ॉलबैक फ़ॉन्ट को [remove](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontfallbackrule/remove/) करना या [add_fall_back_fonts](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) जोड़ना भी संभव है।

[FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontfallbackrulescollection/) का उपयोग कई Unicode रेंजों के लिए फ़ॉलबैक फ़ॉन्ट प्रतिस्थापन नियम निर्दिष्ट करने की आवश्यकता होने पर [FontFallBackRule](https://reference.aspose.com/slides/hi/python-net/aspose.slides/FontFallBackRule/) ऑब्जेक्ट्स की सूची को व्यवस्थित करने के लिए किया जा सकता है।

{{% alert color="primary" title="See also" %}} 
- [फ़ॉलबैक फ़ॉन्ट संग्रह बनाएं](/slides/hi/python-net/create-fallback-fonts-collection/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**फ़ॉलबैक फ़ॉन्ट, फ़ॉन्ट प्रतिस्थापन और फ़ॉन्ट एम्बेडिंग में क्या अंतर है?**  
फ़ॉलबैक फ़ॉन्ट केवल उन अक्षरों के लिए उपयोग किया जाता है जो प्राथमिक फ़ॉन्ट में अनुपलब्ध होते हैं। [Font substitution](/slides/hi/python-net/font-substitution/) निर्दिष्ट फ़ॉन्ट को पूरी तरह से किसी अन्य फ़ॉन्ट से बदल देता है। [Font embedding](/slides/hi/python-net/embedded-font/) फ़ॉन्ट्स को आउटपुट फ़ाइल के भीतर पैकेज करता है जिससे प्राप्तकर्ता पाठ को इच्छित रूप में देख सकें।

**क्या फ़ॉलबैक फ़ॉन्ट्स को PDF, PNG, या SVG जैसे निर्यातों के दौरान लागू किया जाता है, या केवल स्क्रीन पर रेंडरिंग के लिए?**  
हाँ। फ़ॉलबैक सभी [रेंडरिंग और निर्यात ऑपरेशन्स](/slides/hi/python-net/convert-presentation/) पर प्रभाव डालता है जहाँ अक्षरों को ड्रॉ किया जाना आवश्यक है लेकिन स्रोत फ़ॉन्ट में वे उपलब्ध नहीं होते।

**क्या फ़ॉलबैक कॉन्फ़िगर करने से प्रस्तुति फ़ाइल स्वयं बदलती है, और क्या यह सेटिंग भविष्य के खोलने पर बनी रहती है?**  
नहीं। फ़ॉलबैक नियम आपके कोड में रन‑टाइम रेंडरिंग सेटिंग्स होते हैं; वे .pptx फ़ाइल के भीतर संग्रहीत नहीं होते और पावरपॉइंट में दिखाई नहीं देंगे।

**क्या ऑपरेटिंग सिस्टम (Windows/Linux/macOS) और फ़ॉन्ट निर्देशिकाओं का सेट फ़ॉलबैक चयन को प्रभावित करता है?**  
हाँ। इंजन उपलब्ध सिस्टम फ़ोल्डर्स और आपके द्वारा प्रदान किए गए किसी भी [अतिरिक्त पथ](/slides/hi/python-net/custom-font/) से फ़ॉन्ट्स को हल करता है। यदि कोई फ़ॉन्ट शारीरिक रूप से उपलब्ध नहीं है, तो उसे संदर्भित करने वाला नियम प्रभावी नहीं हो सकता।

**क्या फ़ॉलबैक WordArt, SmartArt और चार्ट्स के लिए काम करता है?**  
हाँ। जब इन ऑब्जेक्ट्स में टेक्स्ट होता है, तो समान ग्लिफ़‑प्रतिस्थापन तंत्र लागू होता है जिससे अनुपलब्ध अक्षरों को रेंडर किया जा सके।