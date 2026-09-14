---
title: "Python के माध्यम से Java में प्रस्तुतियों के लिए फ़ॉलबैक फ़ॉन्ट्स निर्दिष्ट करें"
linktitle: "फ़ॉलबैक फ़ॉन्ट"
type: docs
weight: 10
url: /hi/python-java/create-fallback-font/
keywords:
- "फ़ॉलबैक फ़ॉन्ट"
- "फ़ॉलबैक नियम"
- "फ़ॉन्ट लागू करें"
- "फ़ॉन्ट बदलें"
- "Unicode रेंज"
- "छूटा ग्लाइफ़"
- "सही ग्लाइफ़"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Python के माध्यम से Java में Aspose.Slides को मास्टर करें ताकि PPT, PPTX और ODP फ़ाइलों में फ़ॉलबैक फ़ॉन्ट्स सेट किए जा सकें, और किसी भी उपकरण या OS पर सुसंगत पाठ प्रदर्शन सुनिश्चित हो।"
---
## **सारांश**

Aspose.Slides आपको प्रस्तुति रेंडरिंग और निर्यात संचालन के लिए फ़ॉलबैक फ़ॉन्ट्स निर्दिष्ट करने की अनुमति देता है। फ़ॉलबैक फ़ॉन्ट्स तब उपयोग किए जाते हैं जब प्राथमिक फ़ॉन्ट में विशिष्ट अक्षरों के लिए ग्लाइफ़ नहीं होते।

फ़ॉलबैक व्यवहार को फ़ॉलबैक नियमों के माध्यम से कॉन्फ़िगर किया जाता है। प्रत्येक नियम एक यूनिकोड रेंज को एक या अधिक फ़ॉन्ट्स से जोड़ता है जो आवश्यक ग्लाइफ़्स रख सकते हैं। आप विभिन्न अक्षर रेंजों के लिए नियम परिभाषित कर सकते हैं, मौजूदा नियमों में फ़ॉलबैक फ़ॉन्ट्स जोड़ या हटा सकते हैं, और फ़ॉलबैक फ़ॉन्ट नियम संग्रह में कई नियमों को व्यवस्थित कर सकते हैं।

फ़ॉलबैक नियम रनटाइम रेंडरिंग सेटिंग्स हैं। वे प्रस्तुति फ़ाइल को स्वयं संशोधित नहीं करते और PPTX फ़ाइल के भीतर संग्रहीत नहीं होते।

## **फ़ॉलबैक नियम**

Aspose.Slides फ़ॉलबैक फ़ॉन्ट्स लागू करने के नियम निर्दिष्ट करने के लिए [FontFallBackRule](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontfallbackrule/) क्लास प्रदान करता है। यह क्लास एक यूनिकोड रेंज, जिसका उपयोग गायब ग्लाइफ़्स की खोज में किया जाता है, और फ़ॉन्ट्स की सूची के बीच संबंध दर्शाती है, जो आवश्यक ग्लाइफ़्स रख सकते हैं:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule

start_unicode_index = 0x0B80
end_unicode_index = 0x0BFF

first_rule = FontFallBackRule(start_unicode_index, end_unicode_index, "Vijaya")
second_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

# फ़ॉन्ट्स की सूची निर्दिष्ट करने के कई तरीके उपयोग करें।
font_names = jpype.JArray(jpype.JString)(["Segoe UI Emoji, Segoe UI Symbol", "Arial"])

third_rule = FontFallBackRule(0x1F300, 0x1F64F, font_names)
```

आप मौजूदा [FontFallBackRule](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontfallbackrule/) ऑब्जेक्ट में [remove](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontfallbackrule/#remove) का उपयोग करके फ़ॉलबैक फ़ॉन्ट हटा सकते हैं या [addFallBackFonts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) का उपयोग करके फ़ॉलबैक फ़ॉन्ट्स जोड़ सकते हैं।

[FontFallBackRulesCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontfallbackrulescollection/) कई यूनिकोड रेंजों के लिए फ़ॉलबैक फ़ॉन्ट प्रतिस्थापन नियम निर्धारित करने की आवश्यकता होने पर [FontFallBackRule](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontfallbackrule/) ऑब्जेक्ट्स की सूची को व्यवस्थित कर सकता है।

{{% alert color="info" title="इसी तरह देखें" %}} 
- [फ़ॉलबैक फ़ॉन्ट्स संग्रह बनाएँ](/slides/hi/python-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**फ़ॉलबैक फ़ॉन्ट, फ़ॉन्ट प्रतिस्थापन, और फ़ॉन्ट एम्बेडिंग के बीच क्या अंतर है?**

फ़ॉलबैक फ़ॉन्ट केवल प्राथमिक फ़ॉन्ट में अभाव वाले अक्षरों के लिए उपयोग किया जाता है। [Font substitution](/slides/hi/python-java/font-substitution/) निर्दिष्ट फ़ॉन्ट को पूरी तरह से दूसरे फ़ॉन्ट से बदल देता है। [Font embedding](/slides/hi/python-java/embedded-font/) फ़ॉन्ट्स को आउटपुट फ़ाइल के भीतर पैकेज करता है जिससे प्राप्तकर्ता पाठ को इच्छानुसार देख सकें।

**क्या फ़ॉलबैक फ़ॉन्ट्स PDF, PNG, या SVG जैसे निर्यातों के दौरान लागू होते हैं, या केवल स्क्रीन पर रेंडरिंग के लिए?**

हां। फ़ॉलबैक उन सभी [रेंडरिंग और निर्यात संचालन](/slides/hi/python-java/convert-presentation/) को प्रभावित करता है जहाँ अक्षरों को ड्रॉ किया जाना आवश्यक है लेकिन स्रोत फ़ॉन्ट में मौजूद नहीं होते।

**क्या फ़ॉलबैक को कॉन्फ़िगर करने से प्रस्तुति फ़ाइल स्वयं बदलती है, और क्या यह सेटिंग भविष्य के खोलने पर बनी रहती है?**

नहीं। फ़ॉलबैक नियम आपके कोड में रनटाइम रेंडरिंग सेटिंग्स हैं; वे .pptx के भीतर संग्रहीत नहीं होते और PowerPoint में दिखाई नहीं देंगे।

**क्या ऑपरेटिंग सिस्टम (Windows/Linux/macOS) और फ़ॉन्ट डायरेक्टरी सेट फ़ॉलबैक चयन को प्रभावित करता है?**

हां। इंजन उपलब्ध सिस्टम फ़ोल्डरों और आप द्वारा प्रदान किए गए किसी भी [अतिरिक्त पथ](/slides/hi/python-java/custom-font/) से फ़ॉन्ट्स खोजता है। यदि कोई फ़ॉन्ट वास्तव में उपलब्ध नहीं है, तो उस फ़ॉन्ट को संदर्भित करने वाला नियम प्रभावी नहीं हो सकता।

**क्या फ़ॉलबैक WordArt, SmartArt, और चार्ट्स के लिए काम करता है?**

हां। जब इन ऑब्जेक्ट्स में पाठ होता है, तो वही ग्लाइफ़-प्रतिस्थापन तंत्र लागू होता है जिससे अभाव वाले अक्षरों को रेंडर किया जा सके।