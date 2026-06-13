---
title: Aspose.Slides में PPT से PPTX फ़ॉर्मेट में रूपांतरण
type: docs
weight: 10
url: /hi/net/conversion-from-ppt-to-pptx-format-in-aspose-slides/
---
**Aspose.Slides** for .NET अब डेवलपर्स को Presentation क्लास इंस्टेंस का उपयोग करके PPT तक पहुँचने और उसे संबंधित PPTX फ़ॉर्मेट में परिवर्तित करने की सुविधा देता है। वर्तमान में, यह PPT को PPTX में आंशिक रूप से बदलने का समर्थन करता है। PPT से PPTX रूपांतरण में कौन‑से फीचर समर्थित और असमर्थित हैं, इसके बारे में अधिक विवरण के लिए कृपया इस दस्तावेज़ लिंक पर जाएँ।

**Aspose.Slides** for .NET Presentation क्लास प्रदान करता है जो PPTX प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है। अब Presentation क्लास ऑब्जेक्ट को इंस्टैंशिएट करने पर PPT तक भी पहुँच सकता है।

``` csharp

 //एक Presentation ऑब्जेक्ट को इनस्टैंशिएट करें जो एक PPTX फ़ाइल का प्रतिनिधित्व करता है

PresentationEx pres = new PresentationEx("Conversion.ppt");

//PPTX प्रस्तुति को PPTX फ़ॉर्मेट में सहेजना

pres.Save(MyDir +"Converted.pptx", SaveFormat.Pptx);

``` 
## **उदाहरण कोड डाउनलोड करें**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20PPT%20to%20PPTX%20%28Aspose.Slides%29.zip)