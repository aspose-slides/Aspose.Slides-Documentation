---
title: VSTO और Aspose.Slides for Java का उपयोग करके नई प्रस्तुतियों का निर्माण
linktitle: नई प्रस्तुति बनाएं
type: docs
weight: 10
url: /hi/java/create-a-new-presentation/
keywords:
- प्रस्तुति बनाना
- नई प्रस्तुति
- स्थानांतरण
- VSTO
- Office स्वचालन
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Microsoft Office स्वचालन से Aspose.Slides for Java में माइग्रेट करें और Java में साफ, विश्वसनीय कोड के साथ नया PowerPoint (PPT, PPTX) प्रस्तुति बनाएं।"
---
{{% alert color="primary" %}} 

VSTO को इस उद्देश्य से विकसित किया गया था कि डेवलपर्स ऐसे अनुप्रयोग बना सकें जो Microsoft Office के भीतर चल सकें। VSTO COM-आधारित है, लेकिन इसे .NET ऑब्जेक्ट के भीतर लपेटा गया है ताकि इसे .NET अनुप्रयोगों में उपयोग किया जा सके। VSTO को .NET फ़्रेमवर्क समर्थन तथा Microsoft Office CLR-आधारित रनटाइम की आवश्यकता होती है। हालाँकि इसे Microsoft Office ऐड-इन के निर्माण के लिए इस्तेमाल किया जा सकता है, लेकिन इसे सर्वर-साइड घटक के रूप में उपयोग करना लगभग असंभव है। इसमें गंभीर डिप्लॉयमेंट समस्याएँ भी हैं।

Aspose.Slides for Java एक घटक है जिसका उपयोग Microsoft PowerPoint प्रस्तुतियों को संशोधित करने के लिए किया जा सकता है, ठीक VSTO की तरह, लेकिन इसके कई लाभ हैं:

- Aspose.Slides केवल प्रबंधित कोड शामिल करता है और Microsoft Office रनटाइम को स्थापित करने की आवश्यकता नहीं होती।
- इसे क्लाइंट-साइड घटक या सर्वर‑साइड घटक दोनों रूप में उपयोग किया जा सकता है।
- डिप्लॉयमेंट आसान है क्योंकि Aspose.Slides एक एकल jar फ़ाइल में शामिल है।

{{% /alert %}} 
## **प्रेज़ेंटेशन बनाना**
नीचे दो कोड उदाहरण हैं जो दर्शाते हैं कि VSTO और Aspose.Slides for Java का उपयोग करके समान लक्ष्य कैसे प्राप्त किया जा सकता है। पहला उदाहरण है [VSTO](/slides/hi/java/create-a-new-presentation/); [दूसरा उदाहरण](/slides/hi/java/create-a-new-presentation/) Aspose.Slides का उपयोग करता है।
### **VSTO उदाहरण**
**VSTO आउटपुट** 

![todo:image_alt_text](create-a-new-presentation_1.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-AddVSTOPresentation-AddVSTOPresentation.cs" >}}
### **Aspose.Slides for Java उदाहरण**
**Aspose.Slides का आउटपुट** 

![todo:image_alt_text](create-a-new-presentation_2.png)



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-CreatePresentation-CreatePresentation.java" >}}