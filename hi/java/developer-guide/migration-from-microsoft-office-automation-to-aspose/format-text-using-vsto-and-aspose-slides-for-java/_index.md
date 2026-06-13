---
title: VSTO और Aspose.Slides for Java का उपयोग करके पाठ स्वरूपित करें
linktitle: पाठ स्वरूपित करें
type: docs
weight: 30
url: /hi/java/format-text-using-vsto-and-aspose-slides-for-java/
keywords:
- पाठ स्वरूपित करना
- स्थांतरण
- VSTO
- ऑफिस स्वचालन
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Microsoft Office स्वचालन से Aspose.Slides for Java में माइग्रेट करें और PowerPoint (PPT, PPTX) प्रस्तुतियों में पाठ को सटीक नियंत्रण के साथ स्वरूपित करें।"
---
{{% alert color="primary" %}}

कभी‑कभी, आपको स्लाइड्स पर पाठ को प्रोग्रामेटिक रूप से स्वरूपित करने की आवश्यकता होती है। यह लेख दर्शाता है कि कैसे किसी नमूना प्रस्तुति को पढ़ा जाए जिसमें पहले स्लाइड पर कुछ पाठ है, लक्ष्य [VSTO](/slides/hi/java/format-text-using-vsto-and-aspose-slides-for-java/) या [Aspose.Slides for Java](/slides/hi/java/format-text-using-vsto-and-aspose-slides-for-java/) का उपयोग करके। कोड स्लाइड पर तीसरे टेक्स्टबॉक्स के पाठ को इस प्रकार स्वरूपित करता है कि वह अंतिम टेक्स्टबॉक्स के पाठ जैसा दिखे।

{{% /alert %}}
## **पाठ स्वरूपित करना**
Both the VSTO and Aspose.Slides methods take the following steps:

1. स्रोत प्रस्तुति खोलें।
2. पहले स्लाइड तक पहुँचें।
3. तीसरे टेक्स्टबॉक्स तक पहुँचें।
4. तीसरे टेक्स्टबॉक्स में पाठ का स्वरूप बदलें।
5. प्रस्तुति को डिस्क पर सेव करें।

नीचे दिए गए स्क्रीनशॉट्स दिखाते हैं कि VSTO और Aspose.Slides for Java कोड के चलाने से पहले और बाद में नमूना स्लाइड कैसी दिखती है।

**इनपुट प्रस्तुति**

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **VSTO कोड उदाहरण**
नीचे दिया गया कोड दर्शाता है कि VSTO का उपयोग करके स्लाइड पर पाठ को कैसे पुनः स्वरूपित किया जाए।

**VSTO के साथ पुनः स्वरूपित पाठ**

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}

### **Aspose.Slides for Java उदाहरण**
Aspose.Slides के साथ पाठ को स्वरूपित करने के लिए, टेक्स्ट को स्वरूपित करने से पहले फ़ॉन्ट जोड़ें।

**Aspose.Slides के साथ निर्मित आउटपुट प्रस्तुति**

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}