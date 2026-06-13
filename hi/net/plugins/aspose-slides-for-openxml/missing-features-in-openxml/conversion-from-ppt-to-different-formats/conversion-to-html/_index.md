---
title: HTML में रूपांतरण
type: docs
weight: 20
url: /hi/net/conversion-to-html/
---
**HTML** कई व्यापक रूप से उपयोग किए जाने वाले फ़ॉर्मेट्स में से एक है जो डेटा का विनिमय करने के लिए प्रयोग होते हैं। **Aspose.Slides for .NET** प्रस्तुति को HTML में परिवर्तित करने के लिए समर्थन प्रदान करता है। नीचे कोड स्निपेट है जो आपको दिखाता है कि कैसे करना है।

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to HTML.html";

//एक Presentation ऑब्जेक्ट बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है

Presentation pres = new Presentation(srcFileName);

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//प्रस्तुति को HTML में सहेज रहे हैं

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **नमूना कोड डाउनलोड करें**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20HTML%20%28Aspose.Slides%29.zip)