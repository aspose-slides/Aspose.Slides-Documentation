---
title: स्लाइड को थंबनेल के रूप में JPEG में रेंडर करें
type: docs
weight: 60
url: /hi/net/render-slide-as-thumbnail-to-jpeg/
---
**Aspose.Slides for .NET** का उपयोग स्लाइड्स वाली प्रस्तुति फ़ाइलें बनाने के लिए किया जाता है। इन स्लाइड्स को Microsoft PowerPoint का उपयोग करके प्रस्तुति फ़ाइलें खोलकर देखा जा सकता है। लेकिन कभी‑कभी, डेवलपर्स को अपने पसंदीदा इमेज व्यूअर का उपयोग करके स्लाइड्स को छवियों के रूप में देखना पड़ सकता है। ऐसे मामलों में, Aspose.Slides for .NET आपको स्लाइड्स की थंबनेल छवियां बनाने में मदद करता है।

Aspose.Slides for .NET का उपयोग करके किसी भी इच्छित स्लाइड का थंबनेल बनाने के लिए:

1. **Presentation** क्लास का एक उदाहरण बनाएँ।
1. अपनी इच्छित स्लाइड का संदर्भ उसका ID या इंडेक्स उपयोग करके प्राप्त करें।
1. निर्दिष्ट स्केल पर संदर्भित स्लाइड की थंबनेल छवि प्राप्त करें।
1. थंबनेल छवि को किसी भी इच्छित इमेज फ़ॉर्मेट में सहेजें।

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//Presentation क्लास को इंस्टैंसिएट करें जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
using (Presentation pres = new Presentation(srcFileName))
{
    //पहली स्लाइड तक पहुंचें
    ISlide sld = pres.Slides[0];

    //पूरा स्केल इमेज बनाएं
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //इमेज को डिस्क पर JPEG फ़ॉर्मेट में सहेजें
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **नमूना कोड डाउनलोड करें**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)