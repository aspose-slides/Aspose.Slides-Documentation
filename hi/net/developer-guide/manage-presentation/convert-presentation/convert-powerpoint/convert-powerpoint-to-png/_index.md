---
title: PowerPoint स्लाइड को .NET में PNG में परिवर्तित करें
linktitle: PowerPoint से PNG
type: docs
weight: 30
url: /hi/net/convert-powerpoint-to-png/
keywords:
- PowerPoint रूपांतरण
- प्रस्तुति रूपांतरण
- स्लाइड रूपांतरण
- PPT रूपांतरण
- PPTX रूपांतरण
- PowerPoint से PNG
- प्रस्तुति से PNG
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
description: "Aspose.Slides for .NET के साथ PowerPoint प्रस्तुतियों को उच्च-गुणवत्ता वाली PNG छवियों में तेज़ी से परिवर्तित करें, सटीक और स्वचालित परिणाम सुनिश्चित करते हुए।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को PNG छवियों में कन्वर्ट करने की प्रक्रिया बताता है। यह PPT, PPTX और ODP जैसे फ़ॉर्मेट में प्रस्तुति फ़ाइलों को लोड करने, स्लाइड्स को छवियों के रूप में रेंडर करने और परिणाम को PNG फ़ॉर्मेट में सहेजने को दिखाता है।

लेख यह भी दिखाता है कि स्केल मान सेट करके या इच्छित चौड़ाई और ऊँचाई निर्दिष्ट करके उत्पन्न PNG छवियों को कैसे अनुकूलित किया जा सकता है।

## **PowerPoint को PNG में बदलें**

इन चरणों को पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का उदाहरण बनाएं।
2. [Presentation.Slides](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/properties/slides) संग्रह से [ISlide](https://reference.aspose.com/slides/hi/net/aspose.slides/islide) इंटरफ़ेस के तहत स्लाइड ऑब्जेक्ट प्राप्त करें। 
3. आवश्यक स्केल पर प्रत्येक स्लाइड को रेंडर करने के लिए [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/getimage/) मेथड का उपयोग करें। 
4. स्लाइड थंबनेल को PNG फ़ॉर्मेट में सहेजने के लिए [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.ipresentation/save/methods/5) मेथड का उपयोग करें। 

यह C# कोड आपको दिखाता है कि PowerPoint प्रस्तुति को PNG में कैसे बदलें। Presentation ऑब्जेक्ट PPT, PPTX, ODP आदि को लोड कर सकता है, फिर प्रस्तुति ऑब्जेक्ट की प्रत्येक स्लाइड को PNG फ़ॉर्मेट या अन्य छवि फ़ॉर्मेट में परिवर्तित किया जाता है।

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(1f, 1f))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

{{% alert color="info" %}} 

**नोट:** स्केल आर्गुमेंट `1f, 1f` प्रत्येक स्लाइड को उसके पूर्ण आकार में रेंडर करते हैं, इसलिए 720×540 pt स्लाइड 720×540 px छवि उत्पन्न करती है। पैरामीटर-रहित [GetImage()](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/getimage/) ओवरलोड एक बहुत छोटा प्रीव्यू थंबनेल लौटाता है।

{{% /alert %}} 

## **कस्टम आयामों के साथ PowerPoint को PNG में बदलें**

यदि आप किसी निश्चित स्केल के आसपास PNG फ़ाइलें प्राप्त करना चाहते हैं, तो आप `desiredX` और `desiredY` के मान सेट कर सकते हैं, जो परिणामी थंबनेल के आयाम निर्धारित करते हैं। 

यह C# कोड वर्णित ऑपरेशन को प्रदर्शित करता है:

```c#
using Aspose.Slides;

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

## **कस्टम आकार के साथ PowerPoint को PNG में बदलें**

यदि आप किसी निश्चित आकार के आसपास PNG फ़ाइलें प्राप्त करना चाहते हैं, तो आप `imageSize` के लिए अपनी वांछित `width` और `height` आर्गुमेंट पास कर सकते हैं। 

यह कोड आपको दिखाता है कि कैसे PowerPoint को PNG में बदलें जबकि छवियों के आकार को निर्दिष्ट किया जाए: 

```c#
using System.Drawing;
using Aspose.Slides;

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

### मैं पूरे स्लाइड के बजाय केवल एक विशिष्ट आकार (जैसे चार्ट या चित्र) को कैसे एक्सपोर्ट कर सकता हूँ?

Aspose.Slides [व्यक्तिगत आकारों के लिए थंबनेल जनरेट करने](/slides/hi/net/create-shape-thumbnails/) का समर्थन करता है; आप किसी आकार को PNG छवि में रेंडर कर सकते हैं।

### क्या सर्वर पर समानांतर रूपांतरण समर्थित है?

हाँ, लेकिन एक ही presentation इन्स्टेंस को थ्रेड्स के बीच [साझा न करें](/slides/hi/net/multithreading/)। प्रत्येक थ्रेड या प्रोसेस के लिए अलग इन्स्टेंस उपयोग करें।

### PNG निर्यात करते समय ट्रायल-версन की सीमाएँ क्या हैं?

मूल्यांकन मोड आउटपुट छवियों में वॉटरमार्क जोड़ता है और लाइसेंस लागू होने तक [अन्य प्रतिबंध](/slides/hi/net/licensing/) लागू करता है।