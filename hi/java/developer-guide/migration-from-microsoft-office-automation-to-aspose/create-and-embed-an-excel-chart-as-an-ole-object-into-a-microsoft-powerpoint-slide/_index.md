---
title: VSTO और Aspose.Slides for Java का उपयोग करके Excel चार्ट को OLE ऑब्जेक्ट्स के रूप में बनाएं और एम्बेड करें
linktitle: Excel चार्ट को OLE ऑब्जेक्ट्स के रूप में बनाएं और एम्बेड करें
type: docs
weight: 60
url: /hi/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- चार्ट बनाएं
- Excel चार्ट एम्बेड करें
- OLE ऑब्जेक्ट
- माइग्रेशन
- VSTO
- ऑफिस ऑटोमेशन
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Microsoft Office ऑटोमेशन से Aspose.Slides for Java में माइग्रेट करें और Java में PowerPoint (PPT, PPTX) स्लाइड्स में Excel चार्ट को OLE ऑब्जेक्ट्स के रूप में एम्बेड करें।"
---
{{% alert color="primary" %}} 

चार्ट आपके डेटा का दृश्यमान प्रतिनिधित्व हैं और प्रस्तुति स्लाइड्स में व्यापक रूप से उपयोग किए जाते हैं। यह लेख आपको कोड दिखाएगा जिससे आप प्रोग्रामेटिकली Excel चार्ट को OLE ऑब्जेक्ट के रूप में PowerPoint स्लाइड में बनाकर एम्बेड कर सकते हैं, इसके लिए आप [VSTO](/slides/hi/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) और [Aspose.Slides for Java](/slides/hi/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) का उपयोग करेंगे।

{{% /alert %}} 
## **Excel चार्ट बनाना और एम्बेड करना**
निचे दिए गए दो कोड उदाहरण लंबी और विस्तृत हैं क्योंकि वर्णित कार्य जटिल है। आप एक Microsoft Excel वर्कबुक बनाते हैं, एक चार्ट बनाते हैं और फिर Microsoft PowerPoint प्रस्तुति बनाते हैं जिसमें आप चार्ट को एम्बेड करेंगे। OLE ऑब्जेक्ट्स मूल दस्तावेज़ के लिंक रखते हैं इसलिए एम्बेडेड फ़ाइल पर डबल‑क्लिक करने वाला उपयोगकर्ता फ़ाइल और उसका एप्लिकेशन लॉन्च करेगा।
### **VSTO उदाहरण**
VSTO का उपयोग करके, निम्नलिखित चरण किए जाते हैं:

1. Microsoft Excel ApplicationClass ऑब्जेक्ट का एक इंस्टेंस बनाएं।
1. एक नई वर्कबुक बनाएं जिसमें एक शीट हो।
1. शीट में एक चार्ट जोड़ें।
1. वर्कबुक को सहेजें।
1. चार्ट डेटा वाली वर्कशीट वाले Excel वर्कबुक को खोलें।
1. शीट के लिए ChartObjects संग्रह प्राप्त करें।
1. कॉपी करने के लिए चार्ट प्राप्त करें।
1. Microsoft PowerPoint प्रस्तुति बनाएं।
1. प्रस्तुति में एक खाली स्लाइड जोड़ें।
1. Excel वर्कशीट से चार्ट को क्लिपबोर्ड में कॉपी करें।
1. चार्ट को PowerPoint प्रस्तुति में पेस्ट करें।
1. स्लाइड पर चार्ट को स्थानित करें।
1. प्रस्तुति को सहेजें.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Aspose.Slides for Java उदाहरण**
.NET के लिए Aspose.Slides का उपयोग करके, निम्नलिखित चरण किए जाते हैं:

1. Aspose.Cells for Java का उपयोग करके एक वर्कबुक बनाएं।
1. एक Microsoft Excel चार्ट बनाएं।
1. Excel चार्ट का OLE आकार सेट करें।
1. चार्ट की एक इमेज प्राप्त करें।
1. Aspose.Slides for Java का उपयोग करके PPTX प्रस्तुति में Excel चार्ट को OLE ऑब्जेक्ट के रूप में एम्बेड करें।
1. ऑब्जेक्ट बदलने की समस्या को संभालने के लिए चरण 3 में प्राप्त इमेज से ऑब्जेक्ट बदलने की इमेज को बदलें।
1. आउटपुट प्रस्तुति को डिस्क पर PPTX फॉर्मेट में लिखें।



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}