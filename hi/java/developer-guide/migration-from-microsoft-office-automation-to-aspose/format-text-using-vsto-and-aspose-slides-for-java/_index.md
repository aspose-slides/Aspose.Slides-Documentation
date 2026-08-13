---
title: VSTO और Aspose.Slides for Java का उपयोग करके टेक्स्ट स्वरूपित करें
linktitle: टेक्स्ट स्वरूपित करें
type: docs
weight: 30
url: /hi/java/format-text-using-vsto-and-aspose-slides-for-java/
keywords:
- पाठ स्वरूपित करना
- स्थानांतरण
- VSTO
- ऑफिस ऑटोमेशन
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Microsoft Office ऑटोमेशन से Aspose.Slides for Java में माइग्रेट करें और PowerPoint (PPT, PPTX) प्रस्तुतियों में सटीक नियंत्रण के साथ पाठ स्वरूपित करें।"
---
{{% alert color="info" %}} 

कभी-कभी, आपको स्लाइड्स पर पाठ को प्रोग्रामेटिक रूप से स्वरूपित करने की आवश्यकता होती है। यह लेख दिखाता है कि कैसे पहला स्लाइड पर कुछ पाठ के साथ एक नमूना प्रस्तुति पढ़ी जाए, चाहे [VSTO](/slides/hi/java/format-text-using-vsto-and-aspose-slides-for-java/) या [Aspose.Slides for Java](/slides/hi/java/format-text-using-vsto-and-aspose-slides-for-java/) का उपयोग करके। कोड स्लाइड पर तीसरे टेक्स्टबॉक्स में पाठ को इस प्रकार स्वरूपित करता है कि वह अंतिम टेक्स्टबॉक्स के पाठ जैसा दिखे।

{{% /alert %}} 
## **पाठ स्वरूपित करना**
Both the VSTO and Aspose.Slides methods take the following steps:

1. स्रोत प्रस्तुति खोलें।
1. पहले स्लाइड तक पहुंचें।
1. तीसरे टेक्स्ट बॉक्स तक पहुंचें।
1. तीसरे टेक्स्ट बॉक्स में पाठ का स्वरूप बदलें।
1. प्रस्तुति को डिस्क पर सहेजें।

The screenshots below show the sample slide before and after the execution of the VSTO and Aspose.Slides for Java code.

**इनपुट प्रस्तुति** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **VSTO कोड उदाहरण**
The code below shows how to reformat text on a slide using VSTO.

**VSTO के साथ पुनः स्वरूपित किया गया पाठ** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}


### **Aspose.Slides for Java उदाहरण**
Aspose.Slides के साथ पाठ स्वरूपित करने के लिए, पाठ को स्वरूपित करने से पहले फ़ॉन्ट जोड़ें।

**Aspose.Slides द्वारा निर्मित आउटपुट प्रस्तुति** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}