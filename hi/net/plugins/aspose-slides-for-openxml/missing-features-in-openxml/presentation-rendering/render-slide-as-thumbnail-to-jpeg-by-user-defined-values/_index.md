---
title: उपयोगकर्ता‑परिभाषित मानों द्वारा स्लाइड को थंबनेल के रूप में JPEG में रेंडर करें
type: docs
weight: 70
url: /hi/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---
Aspose.Slides for .NET का उपयोग करके किसी भी वांछित स्लाइड का थंबनेल जनरेट करने के लिए:

1. **Presentation** क्लास का एक इंस्टेंस बनाएँ।
1. उसके ID या इंडेक्स का उपयोग करके वांछित स्लाइड का रेफ़रेंस प्राप्त करें।
1. उपयोगकर्ता‑परिभाषित X और Y आयामों के आधार पर X और Y स्केलिंग फ़ैक्टर प्राप्त करें।
1. निर्दिष्ट स्केल पर संदर्भित स्लाइड की थंबनेल इमेज प्राप्त करें।
1. थंबनेल इमेज को किसी भी वांछित इमेज फ़ॉर्मेट में सहेजें।

``` csharp
using Aspose.Slides;

string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

//Presentation क्लास का इंस्टेंस बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
using (Presentation pres = new Presentation(srcFileName))
{
    //पहली स्लाइड तक पहुँचें
    ISlide sld = pres.Slides[0];

    //उपयोगकर्ता द्वारा परिभाषित आयाम
    int desiredX = 1200;
    int desiredY = 800;

    //X और Y के स्केल किए गए मान प्राप्त करना
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //पूर्ण स्केल वाली छवि बनाएं
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //छवि को JPEG फ़ॉर्मेट में डिस्क पर सहेजें
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **नमूना कोड डाउनलोड करें**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)