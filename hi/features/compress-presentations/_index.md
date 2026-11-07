---
title: प्रस्तुतियों को संपीड़ित करें
description: चित्रों को संपीड़ित करके और अप्रयुक्त सामग्री को हटाकर प्रस्तुति आकार कम करें।
type: docs
url: /hi/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: ऑपरेशन्स
translationKey: स्लाइड्स-फ़ीचर-प्रेजेंटेशन-संकुचित
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **अवलोकन**

तस्वीरों को संपीड़ित करें, जब आवश्यकता न रहे तो क्रॉप किए गए चित्र क्षेत्रों को हटाएँ, और सहेजने से पहले प्रस्तुति संपीड़न सेटिंग्स चुनें। यह बड़े फ़ोटोग्राफ़ों या दोहराए गए मीडिया वाले डेक्स के लिए उपयोगी है। बचत की मात्रा आपके द्वारा चुनी गई सामग्री और सेटिंग्स पर निर्भर करती है।

## **उपयोग का उदाहरण**

यह C# उदाहरण `input.pptx` को लोड करता है, प्रस्तुति को संपीड़ित करता है, और इसे `compressed.pptx` के रूप में सहेजता है।  
Aspose.Slides for .NET 26.11 या बाद का संस्करण उपयोग करें। सेटअप के लिए, देखें [Aspose.Slides for .NET स्थापित करें](/slides/hi/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

### **क्या यह एकल संपूर्ण फ़ाइल अनुकूलन स्विच है?**

Aspose.Slides for .NET 26.11 में [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/) जोड़ा गया है, जो अप्रयुक्त लेआउट/मास्टर हटाने, एम्बेडेड फ़ॉन्ट उपसमुच्चय और 150‑DPI चित्र संपीड़न को संयोजित करता है। यह स्थायी रूप से क्रॉप किए गए चित्र क्षेत्रों को हटाता है। केवल चित्र प्रसंस्करण के लिए, [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/) का उपयोग करें; अधिक सूक्ष्म नियंत्रण के लिए, देखें [व्यक्तिगत-चित्र संपीड़न उदाहरण](/slides/hi/net/examples/optimization-batch/compression/)। ये नए सहायक निर्दिष्ट .NET संस्करण के लिए विशिष्ट हैं; अन्य SDKs के लिए संबंधित गाइड देखें।

### **क्या चित्र संपीड़न संपादन योग्य पाठ या चार्ट को बदलता है?**

चित्र संपीड़न चित्र डेटा को लक्षित करता है, न कि संपादन योग्य पाठ या चार्ट डेटा को। चित्रों की समीक्षा करें क्योंकि आकार बदलने या पुनःसंपीड़न से उनकी विवरण घट सकती है।

### **मुझे प्रस्तुति चित्रों के लिए रिज़ॉल्यूशन कैसे चुनना चाहिए?**

दिखाए गए चित्र के आकार और इच्छित स्क्रीन या प्रिंट उपयोग के आधार पर लक्ष्य चुनें। बड़े डिस्प्ले, प्रिंटिंग और विस्तृत आरेखों के लिए अधिक रिज़ॉल्यूशन रखें, और मूल को हटाने से पहले रेंडर किए गए आउटपुट की तुलना करें।

## **मार्गदर्शिकाएँ**

- [.NET में संपूर्ण प्रस्तुति संपीड़ित करें](/slides/hi/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [.NET में प्रस्तुतियों में छवि प्रबंधन को अनुकूलित करें](/slides/hi/net/image/)

संबंधित फीचर: [अप्रयुक्त मास्टर, लेआउट और मीडिया हटाएँ](/slides/hi/features/remove-unused-content/).

## चलाने योग्य .NET उदाहरण

- [प्रस्तुति आकार घटाएँ](/slides/hi/net/examples/optimization-batch/compression/)