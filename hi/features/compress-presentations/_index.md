---
title: प्रस्तुति संपीड़न
description: चित्रों को संपीड़ित करके और अप्रयुक्त सामग्री हटाकर प्रस्तुति का आकार कम करें।
type: docs
url: /hi/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **समीक्षा**

चित्रों को संपीड़ित करें, जब उन्हें अब आवश्यकता न हो तो क्रॉप किए गए चित्र क्षेत्रों को हटा दें, और सहेजने से पहले प्रस्तुति संपीड़न सेटिंग्स चुनें। यह बड़े फ़ोटोग्राफ़ या दोहराए गए मीडिया वाली डेक्स के लिए उपयोगी है। बचत की मात्रा आपके द्वारा चुनी गई सामग्री और सेटिंग्स पर निर्भर करती है।

## **उपयोग उदाहरण**

यह C# उदाहरण `input.pptx` को लोड करता है, प्रस्तुति को संपीड़ित करता है, और इसे `compressed.pptx` के रूप में सहेजता है।

Aspose.Slides for .NET 26.11 या बाद के संस्करण का उपयोग करें। सेटअप के लिए देखें [Aspose.Slides for .NET स्थापित करें](/slides/hi/net/installation/)।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```


<!-- visual-explanation:compress-presentations:start -->
[![संपीड़न से पहले और बाद समान रूप से स्केल की गई तस्वीरें, उसके बाद मापी गई PPTX फ़ाइल आकार बार और संग्रहित चित्र आयाम।](visual-compress-presentations-1adbf86268a5.svg)](visual-compress-presentations-1adbf86268a5.svg)

*एक सिंथेटिक डिटेल‑ग्रिड फ़िक्स्चर पर मापा गया: 584,030 → 128,323 बाइट। दोनों रेंडर समान स्केल और 252 × 336‑पॉइंट फ्रेम का उपयोग करते हैं। संपीड़न क्रॉप किए गए मार्जिन को हटाता है और संग्रहित चित्र को 525 × 700 पिक्सेल तक घटा देता है; आकार बचत इनपुट पर निर्भर करती है।*
<!-- visual-explanation:compress-presentations:end -->

## **अक्सर पूछे जाने वाले प्रश्न**

### **क्या यह एकल संपूर्ण‑फ़ाइल अनुकूलन स्विच है?**

Aspose.Slides for .NET 26.11 ने [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/) जोड़ा है, जो अप्रयुक्त लेआउट/मास्टर हटाना, एम्बेडेड‑फ़ॉन्ट उपसेटिंग और 150‑DPI चित्र संपीड़न को संयोजित करता है। यह स्थायी रूप से कटे हुए चित्र क्षेत्रों को हटा देता है। केवल चित्र‑परिकल्पना के लिए, [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/) का उपयोग करें; अधिक सूक्ष्म नियंत्रण के लिए, देखें [व्यक्तिगत‑चित्र संपीड़न उदाहरण](/slides/hi/net/examples/optimization-batch/compression/)। संस्करण 26.11 से, वही संपूर्ण‑प्रस्तुति कॉल Java, Java के माध्यम से Node.js, Python के माध्यम से .NET और C++ में भी उपलब्ध है। इस पृष्ठ पर उदाहरण और लिंक केवल .NET के लिए हैं।

### **क्या चित्र संपीड़न संपादन योग्य पाठ या चार्ट को बदलता है?**

चित्र संपीड़न चित्र डेटा को लक्ष्य करता है, न कि संपादन योग्य पाठ या चार्ट डेटा को। चित्रों की समीक्षा करें क्योंकि आकार बदलना या पुनः‑संपीड़न उनकी विवरण को घटा सकता है।

### **प्रस्तुति चित्रों के लिए रिज़ॉल्यूशन कैसे चुनें?**

लक्षित चित्र आकार और इच्छित स्क्रीन या प्रिंट उपयोग के आधार पर लक्ष्य चुनें। बड़े डिस्प्ले, प्रिंटिंग और विस्तृत आरेखों के लिए अधिक रिज़ॉल्यूशन रखें, और मूल को हटाने से पहले रेंडर किए गए आउटपुट की तुलना करें।

## **मार्गदर्शिकाएँ**

- [पूरा प्रस्तुति .NET में संपीड़ित करें](/slides/hi/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [प्रस्तुति में छवि प्रबंधन को अनुकूलित करें .NET में](/slides/hi/net/image/)

संबंधित फीचर: [अप्रयुक्त मास्टर, लेआउट और मीडिया हटाएँ](/slides/hi/features/remove-unused-content/)।

## चलाने योग्य .NET उदाहरण

- [प्रस्तुति आकार घटाएँ](/slides/hi/net/examples/optimization-batch/compression/)