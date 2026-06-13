---
title: नोट्स के साथ Tiff में रूपांतरण
type: docs
weight: 10
url: /hi/net/conversion-to-tiff-with-notes/
---
TIFF कई व्यापक रूप से उपयोग किए जाने वाले इमेज फॉर्मैट्स में से एक है, जिसे Aspose.Slides for .NET नोट्स के साथ प्रस्तुतियों को इमेज में परिवर्तित करने के लिए समर्थन करता है। आप नोट्स स्लाइड व्यू में स्लाइड थंबनेल भी बना सकते हैं। नीचे दो कोड स्निपेट्स हैं जो दिखाते हैं कि नोट्स स्लाइड व्यू में प्रस्तुतियों की TIFF इमेजेज कैसे जनरेट करें।

**Save** मेथड, जो **Presentation** क्लास द्वारा प्रदान किया गया है, का उपयोग नोट्स स्लाइड व्यू में पूरी प्रस्तुति को TIFF में बदलने के लिए किया जा सकता है। आप व्यक्तिगत स्लाइड्स के लिए भी नोट्स स्लाइड व्यू में स्लाइड थंबनेल बना सकते हैं।

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Tiff conversion with note.pptx";

string destFileName = FilePath + "Tiff conversion with note.tiff";

//एक Presentation ऑब्जेक्ट को इंस्टैंशीएट करें जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है

Presentation pres = new Presentation(srcFileName);

//प्रस्तुति को TIFF नोट्स में सहेजना

pres.Save(destFileName, SaveFormat.TiffNotes);

``` 
## **नमूना कोड डाउनलोड करें**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)