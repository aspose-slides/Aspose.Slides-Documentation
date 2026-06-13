---
title: VSTO और Aspose.Slides में प्रस्तुति खोलना
type: docs
weight: 120
url: /hi/net/opening-a-presentation-in-vsto-and-aspose-slides/
---
## **VSTO**
नीचे प्रस्तुति खोलने के लिए कोड स्निपेट दिया गया है:

``` csharp

  string FileName = "Open Presentation.pptx";

 Application.Presentations.Open(FileName);


``` 
## **Aspose.Slides**
Aspose.Slides for .NET **Presentation** क्लास प्रदान करता है जिसका उपयोग मौजूदा प्रस्तुति खोलने के लिए किया जाता है। यह कुछ ओवरलोडेड कन्स्ट्रक्टर्स प्रदान करता है और हम **Presentation** क्लास के उपयुक्त कन्स्ट्रक्टर्स में से एक का उपयोग करके मौजूदा प्रस्तुति के आधार पर उसका ऑब्जेक्ट बना सकते हैं। नीचे दिए गए उदाहरण में, हमने प्रस्तुति फ़ाइल (जिसे खोलना है) का नाम Presentation क्लास के कन्स्ट्रक्टर में पास किया है। फ़ाइल खोलने के बाद, हम स्क्रीन पर प्रदर्शित करने के लिए प्रस्तुति में मौजूद स्लाइडों की कुल संख्या प्राप्त करते हैं।

``` csharp

  string FileName = "Open Presentation.pptx";

 Presentation MyPresentation = new Presentation(FileName);

``` 
## **चल रहा कोड डाउनलोड**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **नमूना कोड डाउनलोड**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Opening%20a%20Presentation)