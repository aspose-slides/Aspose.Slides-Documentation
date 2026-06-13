---
title: स्लाइड थंबनेल को JPEG के रूप में जनरेट करें
type: docs
weight: 90
url: /hi/net/generate-slide-thumbnail-as-jpeg/
---
Aspose.Slides for .NET का उपयोग करके किसी भी इच्छित स्लाइड का थंबनेल बनाने के लिए:

- Presentation क्लास की एक इंस्टेंस बनाएं।
- उसके ID या इंडेक्स का उपयोग करके किसी भी इच्छित स्लाइड का रेफ़रेंस प्राप्त करें।
- निर्धारित स्केल पर संदर्भित स्लाइड की थंबनेल इमेज प्राप्त करें।
- थंबनेल इमेज को किसी भी इच्छित इमेज फ़ॉर्मेट में सहेजें।

## **उदाहरण**
```cs
//प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
    //पहली स्लाइड तक पहुँचें
    ISlide sld = pres.Slides[0];

    //पूर्ण स्केल की इमेज बनाएं
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //इमेज को JPEG फ़ॉर्मेट में डिस्क पर सहेजें
        image.Save("Test Thumbnail.jpg", ImageFormat.Jpeg);
    }
}
``` 

## **चल रहा उदाहरण डाउनलोड करें**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Slide%20Thumbnail%20to%20JPEG)

## **नमूना कोड डाउनलोड करें**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

अधिक विवरण के लिए, देखें [PPT और PPTX को .NET में JPG में बदलें](/slides/hi/net/convert-powerpoint-to-jpg/).

{{% /alert %}}