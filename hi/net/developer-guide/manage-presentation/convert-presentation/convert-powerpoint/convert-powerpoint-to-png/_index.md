---
title: .NET में PowerPoint स्लाइड्स को PNG में बदलें
linktitle: PowerPoint से PNG
type: docs
weight: 30
url: /hi/net/convert-powerpoint-to-png/
keywords:
- PowerPoint रूपांतरण
- प्रेजेंटेशन रूपांतरण
- स्लाइड रूपांतरण
- PPT रूपांतरण
- PPTX रूपांतरण
- PowerPoint से PNG
- प्रेजेंटेशन से PNG
- स्लाइड से PNG
- PPT से PNG
- PPTX से PNG
- PPT को PNG के रूप में सहेजें
- PPTX को PNG के रूप में सहेजें
- PPT को PNG में निर्यात करें
- PPTX को PNG में निर्यात करें
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint प्रस्तुतियों को तेज़ी से उच्च-गुणवत्ता वाली PNG छवियों में बदलें, सटीक और स्वचालित परिणाम सुनिश्चित करते हुए।"
---
## **समीक्षा**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को PNG छवियों में बदलने के तरीके को समझाता है। यह दिखाता है कि PPT, PPTX और ODP जैसे प्रारूपों में प्रस्तुतियों को कैसे लोड किया जाए, स्लाइड को छवियों के रूप में रेंडर किया जाए, और परिणाम को PNG प्रारूप में सहेजा जाए।

लेख यह भी प्रदर्शित करता है कि स्केल मान सेट करके या वांछित चौड़ाई और ऊँचाई निर्दिष्ट करके उत्पन्न PNG छवियों को कैसे अनुकूलित किया जा सकता है।

## **PowerPoint को PNG में बदलें**

इन चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
2. [ISlide](https://reference.aspose.com/slides/hi/net/aspose.slides/islide) इंटरफ़ेस के तहत [Presentation.Slides](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/properties/slides) संग्रह से स्लाइड ऑब्जेक्ट प्राप्त करें।
3. प्रत्येक स्लाइड के थंबनेल को प्राप्त करने के लिए [ISlide.GetImage](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/getimage/) मेथड का उपयोग करें।
4. [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.ipresentation/save/methods/5) मेथड का उपयोग करके स्लाइड थंबनेल को PNG प्रारूप में सहेजें।

यह C# कोड दर्शाता है कि PowerPoint प्रस्तुति को PNG में कैसे बदला जाए। Presentation ऑब्जेक्ट PPT, PPTX, ODP आदि लोड कर सकता है, फिर प्रस्तुति ऑब्जेक्ट में प्रत्येक स्लाइड को PNG प्रारूप या अन्य छवि प्रारूप में बदला जाता है।

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage())
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **PowerPoint को PNG में कस्टम आयामों के साथ बदलें**

यदि आप किसी निश्चित स्केल के आसपास PNG फ़ाइलें प्राप्त करना चाहते हैं, तो आप `desiredX` और `desiredY` के मान सेट कर सकते हैं, जो परिणामी थंबनेल के आयाम निर्धारित करते हैं।

यह C# कोड वर्णित प्रक्रिया को दर्शाता है:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    float scaleX = 2f;
    float scaleY = 2f;
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(scaleX, scaleY))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **PowerPoint को PNG में कस्टम आकार के साथ बदलें**

यदि आप किसी निश्चित आकार के आसपास PNG फ़ाइलें प्राप्त करना चाहते हैं, तो आप `imageSize` के लिए अपने पसंदीदा `width` और `height` मान पास कर सकते हैं।

यह कोड दर्शाता है कि छवियों के आकार निर्दिष्ट करते हुए PowerPoint को PNG में कैसे बदला जाए:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Size size = new Size(960, 720);
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(size))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं पूरे स्लाइड के बजाय केवल एक विशिष्ट आकार (जैसे चार्ट या चित्र) को कैसे निर्यात कर सकता हूँ?**

Aspose.Slides [व्यक्तिगत आकारों के लिए थंबनेल उत्पन्न करने](/slides/hi/net/create-shape-thumbnails/) का समर्थन करता है; आप किसी आकार को PNG छवि के रूप में रेंडर कर सकते हैं।

**क्या सर्वर पर समानांतर रूपांतरण समर्थित है?**

हां, लेकिन एक ही प्रस्तुति इंस्टेंस को थ्रेड्स के बीच [साझा न करें](/slides/hi/net/multithreading/). प्रत्येक थ्रेड या प्रक्रिया के लिए एक अलग इंस्टेंस उपयोग करें।

**PNG निर्यात करने पर ट्रायल- संस्करण की सीमाएं क्या हैं?**

मूल्यांकन मोड आउटपुट छवियों पर वॉटरमार्क जोड़ता है और लाइसेंस लागू होने तक [अन्य प्रतिबंध](/slides/hi/net/licensing/) को लागू करता है।