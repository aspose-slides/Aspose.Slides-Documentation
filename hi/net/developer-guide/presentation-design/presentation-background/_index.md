---
title: .NET में प्रस्तुति पृष्ठभूमियों का प्रबंधन
linktitle: स्लाइड पृष्ठभूमि
type: docs
weight: 20
url: /hi/net/presentation-background/
keywords:
- प्रस्तुति पृष्ठभूमि
- स्लाइड पृष्ठभूमि
- ठोस रंग
- ग्रेडियेंट रंग
- चित्र पृष्ठभूमि
- पृष्ठभूमि पारदर्शिता
- पृष्ठभूमि गुण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument फ़ाइलों में गतिशील पृष्ठभूमियां सेट करना सीखें, कोड टिप्स के साथ अपनी प्रस्तुतियों को बेहतर बनाएं।"
---
## **परिचय**

ठोस रंग, ग्रेडियेंट और चित्र आमतौर पर स्लाइड पृष्ठभूमियों के लिए उपयोग किए जाते हैं। आप **सामान्य स्लाइड** (एकल स्लाइड) या **मास्टर स्लाइड** (एक साथ कई स्लाइडों पर लागू) की पृष्ठभूमि सेट कर सकते हैं।

![PowerPoint पृष्ठभूमि](powerpoint-background.png)

## **सामान्य स्लाइड के लिए ठोस रंग पृष्ठभूमि सेट करें**

Aspose.Slides आपको प्रस्तुति में किसी विशिष्ट स्लाइड की पृष्ठभूमि को ठोस रंग में सेट करने की अनुमति देता है—भले ही प्रस्तुति में मास्टर स्लाइड उपयोग हो। यह परिवर्तन केवल चयनित स्लाइड पर लागू होता है।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. स्लाइड के [BackgroundType](https://reference.aspose.com/slides/hi/net/aspose.slides/backgroundtype/) को `OwnBackground` सेट करें।
3. स्लाइड पृष्ठभूमि के [FillType](https://reference.aspose.com/slides/hi/net/aspose.slides/filltype/) को `Solid` सेट करें।
4. [FillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/fillformat/) पर [SolidFillColor](https://reference.aspose.com/slides/hi/net/aspose.slides/fillformat/solidfillcolor/) प्रॉपर्टी का उपयोग करके ठोस पृष्ठभूमि रंग निर्दिष्ट करें।
5. संशोधित प्रस्तुति को सहेजें।

नीचे दिया गया C# उदाहरण दिखाता है कि सामान्य स्लाइड की पृष्ठभूमि को नीला ठोस रंग कैसे सेट किया जाए:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation वर्ग का एक उदाहरण बनाएं।

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // स्लाइड की पृष्ठभूमि रंग को नीला सेट करें।
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // प्रस्तुति को डिस्क पर सहेजें।
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```

## **मास्टर स्लाइड के लिए ठोस रंग पृष्ठभूमि सेट करें**

Aspose.Slides आपको प्रस्तुति की मास्टर स्लाइड की पृष्ठभूमि को ठोस रंग में सेट करने की अनुमति देता है। मास्टर स्लाइड सभी स्लाइडों के लिए एक टेम्पलेट के रूप में कार्य करती है, इसलिए जब आप मास्टर स्लाइड की पृष्ठभूमि के लिए ठोस रंग चुनते हैं, तो वह प्रत्येक स्लाइड पर लागू हो जाता है।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. मास्टर स्लाइड के [BackgroundType](https://reference.aspose.com/slides/hi/net/aspose.slides/backgroundtype/) को (`masters` के माध्यम से) `OwnBackground` सेट करें।
3. मास्टर स्लाइड पृष्ठभूमि के [FillType](https://reference.aspose.com/slides/hi/net/aspose.slides/filltype/) को `Solid` सेट करें।
4. ठोस पृष्ठभूमि रंग निर्दिष्ट करने के लिए [SolidFillColor](https://reference.aspose.com/slides/hi/net/aspose.slides/fillformat/solidfillcolor/) का उपयोग करें।
5. संशोधित प्रस्तुति को सहेजें।

नीचे दिया गया C# उदाहरण दिखाता है कि मास्टर स्लाइड की पृष्ठभूमि को फॉरेस्ट ग्रीन ठोस रंग कैसे सेट किया जाए:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation वर्ग का एक उदाहरण बनाएं।
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // मास्टर स्लाइड की पृष्ठभूमि रंग को फ़ॉरेस्ट ग्रीन सेट करें।
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // प्रस्तुति को डिस्क पर सहेजें।
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```

## **स्लाइड के लिए ग्रेडियेंट पृष्ठभूमि सेट करें**

ग्रेडियेंट एक ग्राफ़िकल प्रभाव है जो रंगों के क्रमिक परिवर्तन से बनता है। स्लाइड पृष्ठभूमि के रूप में उपयोग करने पर ग्रेडियेंट प्रस्तुतियों को अधिक कलात्मक और पेशेवर बनाते हैं। Aspose.Slides आपको स्लाइडों की पृष्ठभूमि को ग्रेडियेंट रंग में सेट करने की सुविधा देता है।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. स्लाइड के [BackgroundType](https://reference.aspose.com/slides/hi/net/aspose.slides/backgroundtype/) को `OwnBackground` सेट करें।
3. स्लाइड पृष्ठभूमि के [FillType](https://reference.aspose.com/slides/hi/net/aspose.slides/filltype/) को `Gradient` सेट करें।
4. अपने इच्छित ग्रेडियेंट सेटिंग्स को कॉन्फ़िगर करने के लिए [FillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/fillformat/) पर [GradientFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/fillformat/gradientformat/) प्रॉपर्टी का उपयोग करें।
5. संशोधित प्रस्तुति को सहेजें।

नीचे दिया गया C# उदाहरण दिखाता है कि स्लाइड की पृष्ठभूमि को ग्रेडियेंट रंग कैसे सेट किया जाए:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation वर्ग का एक उदाहरण बनाएं।
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // पृष्ठभूमि पर ग्रेडियेंट प्रभाव लागू करें।
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // प्रस्तुति को डिस्क पर सहेजें।
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```

## **स्लाइड पृष्ठभूमि के रूप में चित्र सेट करें**

ठोस और ग्रेडियेंट फाइल्स के अलावा, Aspose.Slides आपको स्लाइड पृष्ठभूमियों के रूप में चित्र उपयोग करने की अनुमति देता है।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. स्लाइड के [BackgroundType](https://reference.aspose.com/slides/hi/net/aspose.slides/backgroundtype/) को `OwnBackground` सेट करें।
3. स्लाइड पृष्ठभूमि के [FillType](https://reference.aspose.com/slides/hi/net/aspose.slides/filltype/) को `Picture` सेट करें।
4. वह चित्र लोड करें जिसे आप स्लाइड पृष्ठभूमि के रूप में उपयोग करना चाहते हैं।
5. चित्र को प्रस्तुति की इमेज कलेक्शन में जोड़ें।
6. [FillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/fillformat/) पर [PictureFillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/fillformat/picturefillformat/) प्रॉपर्टी का उपयोग करके चित्र को पृष्ठभूमि के रूप में असाइन करें।
7. संशोधित प्रस्तुति को सहेजें।

नीचे दिया गया C# उदाहरण दिखाता है कि स्लाइड की पृष्ठभूमि के रूप में चित्र कैसे सेट किया जाए:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation वर्ग का एक उदाहरण बनाएं।
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // पृष्ठभूमि चित्र गुण सेट करें।
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Picture;
    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // चित्र लोड करें।
    IImage image = Images.FromFile("Tulips.jpg");
    // चित्र को प्रस्तुति की इमेज कलेक्शन में जोड़ें।
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // प्रस्तुति को डिस्क पर सहेजें।
    presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
}
```

नीचे दिया गया कोड नमूना दिखाता है कि पृष्ठभूमि फ़िल टाइप को टाइल्ड चित्र में कैसे बदलें और टाइलिंग प्रॉपर्टीज़ को संशोधित करें:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide firstSlide = presentation.Slides[0];

    IBackground background = firstSlide.Background;

    background.Type = BackgroundType.OwnBackground;
    background.FillFormat.FillType = FillType.Picture;

    IPPImage ppImage;
    using (IImage newImage = Aspose.Slides.Images.FromFile("image.png"))
        ppImage = presentation.Images.AddImage(newImage);

    // पृष्ठभूमि फिल के लिए उपयोग किए गए चित्र को सेट करें।
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // चित्र फिल मोड को टाइल पर सेट करें और टाइल गुण समायोजित करें।
    backPictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    backPictureFillFormat.TileOffsetX = 15f;
    backPictureFillFormat.TileOffsetY = 15f;
    backPictureFillFormat.TileScaleX = 46f;
    backPictureFillFormat.TileScaleY = 87f;
    backPictureFillFormat.TileAlignment = RectangleAlignment.Center;
    backPictureFillFormat.TileFlip = TileFlip.FlipY;

    presentation.Save("TileBackground.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}

और पढ़ें: [**टाइल चित्र टेक्सचर के रूप में**](/slides/hi/net/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **पृष्ठभूमि चित्र की पारदर्शिता बदलें**

आप स्लाइड की पृष्ठभूमि चित्र की पारदर्शिता को समायोजित करना चाह सकते हैं ताकि स्लाइड की सामग्री अधिक स्पष्ट दिखे। नीचे दिया गया C# कोड दिखाता है कि स्लाइड पृष्ठभूमि चित्र की पारदर्शिता कैसे बदलें:

```cs
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

var transparencyValue = 30; // उदाहरण के लिए।

using (Presentation presentation = new Presentation("ImageAsBackground.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // चित्र ट्रांसफॉर्म ऑपरेशनों का संग्रह प्राप्त करें।
    var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

    // मौजूदा स्थिर-प्रतिशत पारदर्शिता प्रभाव खोजें।
    var transparencyOperation = null as IAlphaModulateFixed;
    foreach (var operation in imageTransform)
    {
        if (operation is IAlphaModulateFixed alphaModulateFixed)
        {
            transparencyOperation = alphaModulateFixed;
            break;
        }
    }

    // नया पारदर्शिता मान सेट करें।
    if (transparencyOperation == null)
    {
        imageTransform.AddAlphaModulateFixedEffect(100 - transparencyValue);
    }
    else
    {
        transparencyOperation.Amount = (100 - transparencyValue);
    }

    presentation.Save("ImageBackgroundTransparency.pptx", SaveFormat.Pptx);
}
```

## **स्लाइड पृष्ठभूमि मान प्राप्त करें**

Aspose.Slides स्लाइड की प्रभावी पृष्ठभूमि मान प्राप्त करने के लिए [IBackgroundEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/ibackgroundeffectivedata/) इंटरफ़ेस प्रदान करता है। यह इंटरफ़ेस प्रभावी [FillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ibackgroundeffectivedata/fillformat/) और [EffectFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ibackgroundeffectivedata/effectformat/) को उजागर करता है।

[BaseSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/baseslide/) वर्ग की `background` प्रॉपर्टी का उपयोग करके आप स्लाइड की प्रभावी पृष्ठभूमि प्राप्त कर सकते हैं।

नीचे दिया गया C# उदाहरण स्लाइड की प्रभावी पृष्ठभूमि मान प्राप्त करने को दर्शाता है:

```cs
using Aspose.Slides;

// Presentation वर्ग का एक उदाहरण बनाएं।
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // मास्टर, लेआउट और थीम को ध्यान में रखते हुए प्रभावी पृष्ठभूमि प्राप्त करें।
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं कस्टम पृष्ठभूमि को रीसेट करके थीम/लेआउट पृष्ठभूमि को पुनर्स्थापित कर सकता हूँ?

हाँ। स्लाइड की कस्टम फ़िल को हटाएँ, और पृष्ठभूमि फिर से संबंधित [layout](/slides/hi/net/slide-layout/)/[master](/slides/hi/net/slide-master/) स्लाइड (अर्थात् [theme background](/slides/hi/net/presentation-theme/)) से विरासत में मिल जाएगी।

### यदि मैं बाद में प्रस्तुति की थीम बदलूँ तो पृष्ठभूमि पर क्या प्रभाव पड़ेगा?

यदि स्लाइड की अपनी फ़िल है, तो वह अपरिवर्तित रहेगी। यदि पृष्ठभूमि [layout](/slides/hi/net/slide-layout/)/[master](/slides/hi/net/slide-master/) से विरासत में मिली है, तो वह नई थीम के अनुसार अपडेट हो जाएगी।