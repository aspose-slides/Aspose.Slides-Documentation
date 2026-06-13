---
title: उपयोगकर्ता परिभाषित मानों द्वारा स्लाइड को थंबनेल के रूप में JPEG में रेंडर करें
type: docs
weight: 70
url: /hi/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---
कोई भी इच्छित slide की थंबनेल बनाने के लिए Aspose.Slides for .NET का उपयोग करके:

1. **Presentation** क्लास की एक instance बनाएं।
1. उसका ID या index उपयोग करके किसी भी इच्छित slide का संदर्भ प्राप्त करें।
1. उपयोगकर्ता द्वारा परिभाषित X और Y आयामों के आधार पर X और Y स्केलिंग फैक्टर्स प्राप्त करें।
1. निर्दिष्ट स्केल पर संदर्भित slide की थंबनेल इमेज प्राप्त करें।
1. थंबनेल इमेज को किसी भी इच्छित इमेज फ़ॉर्मेट में सहेजें।

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

// प्रस्तुति फ़ाइल को दर्शाने वाली Presentation क्लास का निर्माण करें
using (Presentation pres = new Presentation(srcFileName))
{
    // पहली स्लाइड तक पहुँचें
    ISlide sld = pres.Slides[0];

    // उपयोगकर्ता परिभाषित आयाम
    int desiredX = 1200;
    int desiredY = 800;

    // X और Y के स्केल्ड मान प्राप्त करना
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    // पूर्ण स्केल इमेज बनाएं
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        // इमेज को डिस्क पर JPEG फ़ॉर्मेट में सहेजें
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **नमूना कोड डाउनलोड करें**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)