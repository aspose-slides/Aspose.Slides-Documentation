---
title: VSTO और Aspose.Slides for Java का उपयोग करके OLE ऑब्जेक्ट्स के रूप में Excel चार्ट बनाना और एम्बेड करना
linktitle: VSTO और Aspose.Slides for Java का उपयोग करके Excel चार्ट को OLE ऑब्जेक्ट्स के रूप में एम्बेड करना
type: docs
weight: 60
url: /hi/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- चार्ट बनाएं
- Excel चार्ट एम्बेड करें
- OLE ऑब्जेक्ट
- माइग्रेशन
- VSTO
- Office ऑटोमेशन
- PowerPoint
- प्रेजेंटेशन
- Java
- Aspose.Slides
description: "Microsoft Office ऑटोमेशन से Aspose.Slides for Java में माइग्रेट करें और Java में PowerPoint (PPT, PPTX) स्लाइड्स में Excel चार्ट को OLE ऑब्जेक्ट्स के रूप में एम्बेड करें."
---
{{% alert color="info" %}} 
Charts आपके डेटा का दृश्य प्रतिनिधित्व हैं और प्रस्तुतिकरण स्लाइड्स में व्यापक रूप से उपयोग किए जाते हैं। यह लेख आपको कोड दिखाएगा जिससे आप प्रोग्रामैटिक रूप से [VSTO](/slides/hi/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) और [Aspose.Slides for Java](/slides/hi/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) का उपयोग करके Excel चार्ट को OLE ऑब्जेक्ट के रूप में PowerPoint स्लाइड में बनाकर एम्बेड कर सकते हैं।
{{% /alert %}} 
## **Excel चार्ट बनाना और एम्बेड करना**
निचे दो विस्तृत कोड उदाहरण हैं क्योंकि यह कार्य जटिल है। आप एक Microsoft Excel वर्कबुक बनाते हैं, एक चार्ट बनाते हैं और फिर Microsoft PowerPoint प्रस्तुति बनाते हैं जिसमें आप चार्ट को एम्बेड करेंगे। OLE ऑब्जेक्ट मूल दस्तावेज़ के लिंक रखते हैं इसलिए उपयोगकर्ता द्वारा एम्बेडेड फ़ाइल पर डबल‑क्लिक करने से फ़ाइल और उसका अनुप्रयोग लॉन्च हो जाएगा।
### **VSTO उदाहरण**
VSTO का उपयोग करते हुए निम्न चरण किए जाते हैं:

1. Microsoft Excel ApplicationClass ऑब्जेक्ट का एक इंस्टेंस बनाएं।
1. एक नई वर्कबुक बनाएं जिसमें एक शीट हो।
1. शीट में चार्ट जोड़ें।
1. वर्कबुक सहेजें।
1. उस Excel वर्कबुक को खोलें जिसमें चार्ट डेटा वाली शीट हो।
1. शीट के लिए ChartObjects संग्रह प्राप्त करें।
1. कॉपी करने के लिए चार्ट प्राप्त करें।
1. एक Microsoft PowerPoint प्रस्तुति बनाएं।
1. प्रस्तुति में एक खाली स्लाइड जोड़ें।
1. Excel वर्कशीट से चार्ट को क्लिपबोर्ड पर कॉपी करें।
1. चार्ट को PowerPoint प्रस्तुति में पेस्ट करें।
1. स्लाइड पर चार्ट को स्थित करें।
1. प्रस्तुति सहेजें।

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bea4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bea4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bea4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Aspose.Slides for Java उदाहरण**
Aspose.Slides for .NET का उपयोग करते हुए निम्न चरण किए जाते हैं:

1. Aspose.Cells for Java का उपयोग करके एक वर्कबुक बनाएं।
1. एक Microsoft Excel चार्ट बनाएं।
1. Excel चार्ट का OLE आकार सेट करें।
1. चार्ट की एक छवि प्राप्त करें।
1. Aspose.Slides for Java का उपयोग करके PPTX प्रस्तुति में Excel चार्ट को OLE ऑब्जेक्ट के रूप में एम्बेड करें।
1. ऑब्जेक्ट बदलने के मुद्दे को हल करने के लिए चरण 3 में प्राप्त छवि से ऑब्जेक्ट की बदली हुई छवि को बदलें।
1. आउटपुट प्रस्तुति को PPTX फ़ॉर्मेट में डिस्क पर लिखें।

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}