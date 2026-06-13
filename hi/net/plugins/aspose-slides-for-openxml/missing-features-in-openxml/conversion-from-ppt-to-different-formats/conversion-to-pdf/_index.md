---
title: PDF में रूपांतरण
type: docs
weight: 30
url: /hi/net/conversion-to-pdf/
---
PDF दस्तावेज़ व्यापक रूप से संगठनों, सरकारी क्षेत्रों और व्यक्तियों के बीच दस्तावेज़ों का आदान‑प्रदान करने के मानक स्वरूप के रूप में उपयोग किए जाते हैं। यह एक लोकप्रिय स्वरूप है इसलिए डेवलपर्स से अक्सर Microsoft PowerPoint प्रस्तुति फ़ाइलों को PDF दस्तावेज़ों में बदलने की मांग की जाती है। इस संभावित आवश्यकता को देखते हुए, Aspose.Slides for .NET अन्य किसी घटक का उपयोग किए बिना प्रस्तुतियों को PDF दस्तावेज़ों में बदलने का समर्थन करता है।

**Aspose.Slides for .NET** एक Presentation क्लास प्रदान करता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है। **Presentation** क्लास Save मेथड को उजागर करता है जिसे पूरी प्रस्तुति को **PDF** दस्तावेज़ में बदलने के लिए बुलाया जा सकता है। **PdfOptions** क्लास PDF बनाने के विकल्प प्रदान करता है जैसे JpegQuality, TextCompression, Compliance और अन्य। इन विकल्पों का उपयोग करके आप वांछित PDF मानक प्राप्त कर सकते हैं।

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to PDF.pdf";

//प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाला Presentation ऑब्जेक्ट बनाते हैं

Presentation pres = new Presentation(srcFileName);

//डिफ़ॉल्ट विकल्पों के साथ प्रस्तुति को PDF में सहेजें

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Pdf);

``` 
## **नमूना कोड डाउनलोड करें**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20PDF%20%28Aspose.Slides%29.zip)