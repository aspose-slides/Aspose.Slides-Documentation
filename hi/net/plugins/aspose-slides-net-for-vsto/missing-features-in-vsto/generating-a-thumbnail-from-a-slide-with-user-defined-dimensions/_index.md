---
title: उपयोगकर्ता परिभाषित आयामों के साथ स्लाइड से थंबनेल उत्पन्न करना
type: docs
weight: 100
url: /hi/net/generating-a-thumbnail-from-a-slide-with-user-defined-dimensions/
---
Aspose.Slides for .NET का उपयोग करके किसी भी इच्छित स्लाइड की थंबनेल उत्पन्न करने के लिए:

- Presentation क्लास की एक इंस्टेंस बनाएं।
- उसके ID या इंडेक्स का उपयोग करके किसी भी इच्छित स्लाइड का रेफ़रेंस प्राप्त करें।
- उपयोगकर्ता द्वारा परिभाषित X और Y आयामों के आधार पर X और Y स्केलिंग फैक्टर्स प्राप्त करें।
- निर्दिष्ट स्केल पर संदर्भित स्लाइड की थंबनेल इमेज प्राप्त करें।
- थंबनेल इमेज को किसी भी इच्छित इमेज फ़ॉर्मेट में सहेजें।

## **उदाहरण**
```cs
//प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
using (Presentation pres = new Presentation("TestPresentation.pptx"))
{
    //पहली स्लाइड तक पहुंचें
    ISlide sld = pres.Slides[0];

    //उपयोगकर्ता परिभाषित आयाम
    int desiredX = 1200;
    int desiredY = 800;

    //X और Y के स्केल किए हुए मान प्राप्त कर रहे हैं
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //पूर्ण स्केल इमेज बनाएं
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //इमेज को JPEG फ़ॉर्मेट में डिस्क पर सहेजें
        image.Save("Thumbnail2.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **चल रहा उदाहरण डाउनलोड**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/User%20Defined%20Thumbnail)
## **नमूना कोड डाउनलोड**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
अधिक विवरण के लिए, देखें [स्लाइड रूपांतरित करें](/slides/hi/net/convert-slide/).
{{% /alert %}}