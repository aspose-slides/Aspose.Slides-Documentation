---
title: नोट्स के साथ प्रस्तुति को TIFF में बदलें
type: docs
weight: 50
url: /hi/net/convert-presentation-to-tiff-with-notes/
---
TIFF एक कई व्यापक रूप से उपयोग किए जाने वाले इमेज फ़ॉर्मेट्स में से एक है जिसे Aspose.Slides for .NET नोट्स सहित प्रस्तुति को इमेज में बदलने के लिए समर्थन करता है। आप नोट्स स्लाइड दृश्य में स्लाइड थंबनेल भी जेनरेट कर सकते हैं। नीचे दो कोड स्निपेट्स हैं जो दिखाते हैं कि नोट्स स्लाइड दृश्य में प्रस्तुति के TIFF इमेज कैसे उत्पन्न करें।

Presentation क्लास द्वारा प्रदान किया गया [Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/methods/save) मेथड का उपयोग नोट्स स्लाइड दृश्य में पूरी प्रस्तुति को TIFF में बदलने के लिए किया जा सकता है। आप व्यक्तिगत स्लाइड्स के लिए भी नोट्स स्लाइड दृश्य में स्लाइड थंबनेल जेनरेट कर सकते हैं।

## **उदाहरण**

``` 

  //एक Presentation ऑब्जेक्ट बनाते हैं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है

 Presentation pres = new Presentation("Conversion.pptx");

 //प्रस्तुति को TIFF नोट्स के साथ सहेजना

 pres.Save("ConvertedwithNotes.tiff", SaveFormat.TiffNotes);

``` 
## **चल रहा उदाहरण डाउनलोड करें**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Tiff%20conversion%20with%20note)
## **नमूना कोड डाउनलोड करें**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
अधिक विवरण के लिए, देखें [PowerPoint प्रस्तुतियों को नोट्स के साथ .NET में TIFF में बदलें](/slides/hi/net/convert-powerpoint-to-tiff-with-notes/)।
{{% /alert %}}