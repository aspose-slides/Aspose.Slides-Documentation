---
title: .NET में प्रस्तुति पृष्ठभूमियों को प्रबंधित करें
linktitle: स्लाइड पृष्ठभूमि
type: docs
weight: 20
url: /hi/net/presentation-background/
keywords:
- प्रस्तुति पृष्ठभूमि
- स्लाइड पृष्ठभूमि
- ठोस रंग
- ग्रेडिएंट रंग
- छवि पृष्ठभूमि
- पृष्ठभूमि पारदर्शिता
- पृष्ठभूमि गुण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument फाइलों में गतिशील पृष्ठभूमि सेट करना सीखें, तथा अपनी प्रस्तुतियों को सुधारने के लिए कोड टिप्स प्राप्त करें।"
---
## **परिचय**

Solid colors, gradients, and images are commonly used for slide backgrounds. You can set the background for a **normal slide** (a single slide) or a **master slide** (applies to multiple slides at once).

![PowerPoint पृष्ठभूमि](powerpoint-background.png)

## **सामान्य स्लाइड के लिए सॉलिड रंग पृष्ठभूमि सेट करें**

Aspose.Slides आपको प्रस्तुति में किसी विशिष्ट स्लाइड के लिए सॉलिड रंग को पृष्ठभूमि के रूप में सेट करने की अनुमति देता है — चाहे प्रस्तुति में मास्टर स्लाइड का उपयोग हो रहा हो। यह परिवर्तन केवल चयनित स्लाइड पर लागू होता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
2. स्लाइड का [BackgroundType](https://reference.aspose.com/slides/hi/net/aspose.slides/backgroundtype/) `OwnBackground` पर सेट करें।
3. स्लाइड पृष्ठभूमि का [FillType](https://reference.aspose.com/slides/hi/net/aspose.slides/filltype/) `Solid` पर सेट करें।
4. सॉलिड पृष्ठभूमि रंग निर्दिष्ट करने के लिए [FillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/fillformat/) पर [SolidFillColor](https://reference.aspose.com/slides/hi/net/aspose.slides/fillformat/solidfillcolor/) प्रॉपर्टी का उपयोग करें।
5. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित C# उदाहरण दर्शाता है कि सामान्य स्लाइड के लिए नीला सॉलिड रंग पृष्ठभूमि कैसे सेट किया जाए:

```cs
// Presentation क्लास का एक उदाहरण बनाएं।
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // स्लाइड की पृष्ठभूमि का रंग नीला सेट करें।
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // प्रस्तुति को डिस्क पर सहेजें।
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```

## **मास्टर स्लाइड के लिए सॉलिड रंग पृष्ठभूमि सेट करें**

Aspose.Slides आपको प्रस्तुति में मास्टर स्लाइड की पृष्ठभूमि के लिए सॉलिड रंग सेट करने की अनुमति देता है। मास्टर स्लाइड एक टेम्पलेट के रूप में कार्य करती है जो सभी स्लाइडों के फ़ॉर्मेटिंग को नियंत्रित करती है, इसलिए जब आप मास्टर स्लाइड की पृष्ठभूमि के लिए सॉलिड रंग चुनते हैं, तो यह प्रत्येक स्लाइड पर लागू होता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
2. `masters` के माध्यम से मास्टर स्लाइड का [BackgroundType](https://reference.aspose.com/slides/hi/net/aspose.slides/backgroundtype/) `OwnBackground` पर सेट करें।
3. मास्टर स्लाइड पृष्ठभूमि का [FillType](https://reference.aspose.com/slides/hi/net/aspose.slides/filltype/) `Solid` पर सेट करें।
4. [SolidFillColor](https://reference.aspose.com/slides/hi/net/aspose.slides/fillformat/solidfillcolor/) का उपयोग करके सॉलिड पृष्ठभूमि रंग निर्दिष्ट करें।
5. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित C# उदाहरण दर्शाता है कि मास्टर स्लाइड की पृष्ठभूमि के लिए सॉलिड रंग (फ़ॉरेस्ट ग्रीन) कैसे सेट किया जाए:

```cs
// Presentation क्लास का एक उदाहरण बनाएं।
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // मास्टर स्लाइड की पृष्ठभूमि का रंग फ़ॉरेस्ट ग्रीन सेट करें।
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // प्रस्तुति को डिस्क पर सहेजें।
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```

## **स्लाइड के लिए ग्रेडिएंट पृष्ठभूमि सेट करें**

ग्रेडिएंट एक ग्राफ़िकल प्रभाव है जो रंग के क्रमिक परिवर्तन से निर्मित होता है। स्लाइड पृष्ठभूमि के रूप में उपयोग करने पर ग्रेडिएंट प्रस्तुति को अधिक कलात्मक और पेशेवर बना सकता है। Aspose.Slides आपको स्लाइडों की पृष्ठभूमि के लिए ग्रेडिएंट रंग सेट करने की अनुमति देता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
2. स्लाइड का [BackgroundType](https://reference.aspose.com/slides/hi/net/aspose.slides/backgroundtype/) `OwnBackground` पर सेट करें।
3. स्लाइड पृष्ठभूमि का [FillType](https://reference.aspose.com/slides/hi/net/aspose.slides/filltype/) `Gradient` पर सेट करें।
4. [FillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/fillformat/) पर [GradientFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/fillformat/gradientformat/) प्रॉपर्टी का उपयोग करके अपनी पसंदीदा ग्रेडिएंट सेटिंग्स कॉन्फ़िगर करें।
5. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित C# उदाहरण दर्शाता है कि स्लाइड की पृष्ठभूमि के लिए ग्रेडिएंट रंग कैसे सेट किया जाए:

```cs
// Presentation क्लास का एक उदाहरण बनाएं।
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // पृष्ठभूमि पर ग्रेडिएंट प्रभाव लागू करें।
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // प्रस्तुति को डिस्क पर सहेजें।
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```

## **स्लाइड पृष्ठभूमि के रूप में छवि सेट करें**

सॉलिड और ग्रेडिएंट भराव के अलावा, Aspose.Slides आपको स्लाइड पृष्ठभूमियों के रूप में छवियों का उपयोग करने की अनुमति देता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
2. स्लाइड का [BackgroundType](https://reference.aspose.com/slides/hi/net/aspose.slides/backgroundtype/) `OwnBackground` पर सेट करें।
3. स्लाइड पृष्ठभूमि का [FillType](https://reference.aspose.com/slides/hi/net/aspose.slides/filltype/) `Picture` पर सेट करें।
4. स्लाइड पृष्ठभूमि के रूप में उपयोग करने वाली छवि लोड करें।
5. छवि को प्रस्तुति के Image Collection में जोड़ें।
6. [FillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/fillformat/) पर [PictureFillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/fillformat/picturefillformat/) प्रॉपर्टी का उपयोग करके छवि को पृष्ठभूमि के रूप में असाइन करें।
7. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित C# उदाहरण दर्शाता है कि स्लाइड की पृष्ठभूमि के रूप में छवि कैसे सेट की जाए:

```c#
 // Presentation क्लास का एक उदाहरण बनाएं।
 using (Presentation presentation = new Presentation())
 {
     ISlide slide = presentation.Slides[0];

     // पृष्ठभूमि छवि गुण सेट करें।
     slide.Background.Type = BackgroundType.OwnBackground;
     slide.Background.FillFormat.FillType = FillType.Picture;
     slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

     // छवि लोड करें।
     IImage image = Images.FromFile("Tulips.jpg");
     // छवि को प्रस्तुति की इमेज कलेक्शन में जोड़ें।
     IPPImage ppImage = presentation.Images.AddImage(image);
     image.Dispose();

     slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

     // प्रस्तुति को डिस्क पर सहेजें।
     presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
 }
```

निम्नलिखित कोड नमूना दर्शाता है कि पृष्ठभूमि भराव प्रकार को टाइल्ड चित्र पर कैसे सेट किया जाए और टाइलिंग गुणों को कैसे संशोधित किया जाए:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide firstSlide = presentation.Slides[0];

    IBackground background = firstSlide.Background;

    background.Type = BackgroundType.OwnBackground;
    background.FillFormat.FillType = FillType.Picture;

    IPPImage ppImage;
    using (IImage newImage = Aspose.Slides.Images.FromFile("image.png"))
        ppImage = presentation.Images.AddImage(newImage);

    // पृष्ठभूमि भराव के लिए उपयोग की जाने वाली छवि सेट करें।
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // चित्र भराव मोड को टाइल पर सेट करें और टाइल गुणों को समायोजित करें।
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

{{% alert color="primary" %}}
और पढ़ें: [**टाइल चित्र बनावट के रूप में**](/slides/hi/net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **पृष्ठभूमि छवि की पारदर्शिता बदलें**

आप स्लाइड की पृष्ठभूमि छवि की पारदर्शिता को समायोजित करना चाह सकते हैं ताकि स्लाइड की सामग्री अधिक स्पष्ट दिखे। निम्नलिखित C# कोड दर्शाता है कि स्लाइड पृष्ठभूमि छवि की पारदर्शिता कैसे बदली जाए:

```cs
var transparencyValue = 30; // उदाहरण के लिए।

// चित्र रूपांतरण संचालन संग्रह प्राप्त करें।
var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

// मौजूदा निश्चित-प्रतिशत पारदर्शिता प्रभाव खोजें।
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
```

## **स्लाइड पृष्ठभूमि मान प्राप्त करें**

Aspose.Slides एक [IBackgroundEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/ibackgroundeffectivedata/) इंटरफ़ेस प्रदान करता है जो स्लाइड के प्रभावी पृष्ठभूमि मानों को प्राप्त करने में मदद करता है। यह इंटरफ़ेस प्रभावी [FillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ibackgroundeffectivedata/fillformat/) और [EffectFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ibackgroundeffectivedata/effectformat/) को उजागर करता है।

[BaseSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/baseslide/) क्लास की `background` प्रॉपर्टी का उपयोग करके आप स्लाइड की प्रभावी पृष्ठभूमि प्राप्त कर सकते हैं।

निम्नलिखित C# उदाहरण दर्शाता है कि स्लाइड के प्रभावी पृष्ठभूमि मान को कैसे प्राप्त किया जाए:

```cs
// Presentation क्लास का एक उदाहरण बनाएं।
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

**क्या मैं एक कस्टम पृष्ठभूमि को रीसेट करके थीम/लेआउट पृष्ठभूमि को पुनर्स्थापित कर सकता हूँ?**

हाँ। स्लाइड की कस्टम भराव को हटा दें, और पृष्ठभूमि फिर से संबंधित [लेआउट](/slides/hi/net/slide-layout/)/[मास्टर](/slides/hi/net/slide-master/) स्लाइड (अर्थात् [थीम पृष्ठभूमि](/slides/hi/net/presentation-theme/)) से विरासत में मिल जाएगी।

**यदि मैं बाद में प्रस्तुति का थीम बदलता हूँ तो पृष्ठभूमि पर क्या प्रभाव पड़ता है?**

यदि किसी स्लाइड की अपनी भराव है, तो वह अपरिवर्तित रहेगी। यदि पृष्ठभूमि [लेआउट](/slides/hi/net/slide-layout/)/[मास्टर](/slides/hi/net/slide-master/) से विरासत में मिली है, तो वह [नया थीम](/slides/hi/net/presentation-theme/) के अनुरूप अपडेट हो जाएगी।