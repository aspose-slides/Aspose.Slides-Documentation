---
title: प्रस्तुति को XPS में बदलें
type: docs
weight: 60
url: /hi/net/convert-presentation-to-xps/
---
**XPS** फ़ॉर्मेट डेटा के आदान‑प्रदान के लिए भी व्यापक रूप से उपयोग किया जाता है। Aspose.Slides for .NET इसकी महत्ता को समझता है और प्रस्तुति को XPS दस्तावेज़ में बदलने के लिए अंतर्निहित समर्थन प्रदान करता है।

Presentation क्लास द्वारा प्रदान की गई **Save** मेथड का उपयोग पूरी प्रस्तुति को **XPS** दस्तावेज़ में परिवर्तित करने के लिए किया जा सकता है। आगे, **XpsOptions** क्लास **SaveMetafileAsPng** प्रॉपर्टी को आवश्यकतानुसार true या false पर सेट किया जा सकता है।
## **उदाहरण**

``` 

 //एक Presentation वस्तु बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करती है

Presentation pres = new Presentation("Conversion.ppt");

//प्रस्तुति को TIFF दस्तावेज़ में सहेज रहा है

pres.Save("converted.xps", Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **चल रही उदाहरण डाउनलोड करें**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20XPS)
## **नमूना कोड डाउनलोड करें**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

अधिक विवरण के लिए, देखें [Convert PowerPoint Presentations to XPS in .NET](/slides/hi/net/convert-powerpoint-to-xps/)।

{{% /alert %}}