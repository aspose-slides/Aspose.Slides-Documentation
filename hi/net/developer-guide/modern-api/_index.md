---
title: "आधुनिक API के साथ इमेज प्रोसेसिंग को बेहतर बनाएं"
linktitle: "आधुनिक API"
type: docs
weight: 234
url: /hi/net/modern-api/
keywords:
- System.Drawing
- आधुनिक API
- ड्राइंग
- स्लाइड थंबनेल
- स्लाइड से इमेज
- शेप थंबनेल
- शेप से इमेज
- प्रेजेंटेशन थंबनेल
- प्रेजेंटेशन से इमेज
- इमेज जोड़ें
- चित्र जोड़ें
- .NET
- C#
- Aspose.Slides
description: "डिप्रिकेटेड इमेजिंग APIs को .NET आधुनिक API से बदलकर स्लाइड इमेज प्रोसेसिंग को आधुनिक बनाएं, जिससे PowerPoint और OpenDocument ऑटोमेशन सहज हो जाए।"
---
## **परिचय**

इतिहास में, Aspose Slides को System.Drawing पर निर्भरता थी और सार्वजनिक API में वहाँ से निम्नलिखित क्लासेस शामिल थीं:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

संस्करण 24.4 से, इस सार्वजनिक API को अप्रचलित घोषित किया गया है।

.NET6 और उससे ऊपर के संस्करणों में गैर‑Windows प्लेटफ़ॉर्म के लिए System.Drawing समर्थन हटाया गया है ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), इसलिए Slides ने दो‑पैकेज दृष्टिकोण अपनाया है:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) – Windows के लिए .NET6+, Windows/Linux/MacOS के लिए .NETStandard, Windows के लिए .NETFramework 2+।
  - इसमें [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) पर निर्भरता है।
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) – बिना निर्भरताओं वाला Windows/Linux/MacOS संस्करण।

[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) की असुविधा यह है कि यह उसी नेमस्पेस में System.Drawing की अपनी संस्करण को लागू करता है (पब्लिक API के साथ पीछे की संगतता बनाए रखने के लिए)। इसलिए, जब Aspose.Slides.NET6.CrossPlatform और .NET Framework या System.Drawing.Common पैकेज से System.Drawing को एक साथ उपयोग किया जाता है, तो नाम टकराव होता है जब तक कि उपनाम (alias) न उपयोग किया जाए।

मुख्य Aspose.Slides.NET पैकेज में System.Drawing पर निर्भरताओं को हटाने के लिए हमने तथाकथित “Modern API” जोड़ा है – यानी वह API जिसे अप्रचलित वाले के बजाय उपयोग करना चाहिए, जिसकी हस्ताक्षर में System.Drawing के निम्नलिखित प्रकारों पर निर्भरता होती है: [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) और [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)। [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) और [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) को अप्रचलित घोषित किया गया है और उनके समर्थन को सार्वजनिक Slides API से हटा दिया गया है।

वर्तमान संस्करणों में, System.Drawing पर निर्भर सार्वजनिक API को पुरानी/अप्रचलित मानें। नए कोड के लिए और मौजूदा इमेज‑प्रोसेसिंग वर्कफ़्लो को माइग्रेट करने के लिए Modern API का उपयोग करें।

## **Modern API**

पब्लिक API में निम्नलिखित क्लासेस और एनेम जोड़े गए हैं:

- [Aspose.Slides.IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) – रास्टर या वेक्टर इमेज का प्रतिनिधित्व करता है।
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) – इमेज के फ़ाइल फ़ॉर्मेट का प्रतिनिधित्व करता है।
- [Aspose.Slides.Images](https://reference.aspose.com/slides/net/aspose.slides/images/) – [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) इंटरफ़ेस को इंस्टैंशिएट और उपयोग करने के मेथड्स।

कृपया ध्यान दें कि [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) डिस्पोज़ेबल है (यह [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) इंटरफ़ेस को इम्प्लीमेंट करता है और इसका उपयोग `using` में या किसी अन्य सुविधाजनक तरीके से डिस्पोज़ किया जाना चाहिए)।

एकल स्लाइड या शेप को रेंडर करने के लिए `GetImage` का उपयोग करें। कई प्रस्तुति स्लाइड्स को रेंडर करने के लिए `GetImages` का उपयोग करें। इमेज लोड करने के लिए [Images](https://reference.aspose.com/slides/net/aspose.slides/images/) मेथड्स, प्रस्तुति में जोड़ने के लिए `AddImage` के साथ [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/), तथा मौजूदा प्रस्तुति इमेज को अपडेट करने के लिए `ReplaceImage` के साथ [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) का उपयोग करें।

नई API के उपयोग का एक सामान्य परिदृश्य इस प्रकार हो सकता है:

``` csharp
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // डिस्क पर फ़ाइल से IImage का डिस्पोज़ेबल इंस्टेंस बनाएं।  
    using (IImage image = Images.FromFile("image.png"))
    {
        // प्रेजेंटेशन की इमेजेस में IImage का इंस्टेंस जोड़कर एक PowerPoint इमेज बनाएं।
        ppImage = pres.Images.AddImage(image);
    }

    // स्लाइड #1 पर एक चित्र शेप जोड़ें
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // स्लाइड #1 का प्रतिनिधित्व करने वाला IImage का इंस्टेंस प्राप्त करें।
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // इमेज को डिस्क पर सहेजें।
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## **पुराने कोड को Modern API से बदलना**

परिवर्तन को आसान बनाने के लिए, नया [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) इंटरफ़ेस [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) और [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap) क्लासेज़ के अलग‑अलग हस्ताक्षरों को दोहराता है। सामान्यतः, आपको System.Drawing वाले पुराने मेथड कॉल को नए वाले से बदलना होगा।

### **स्लाइड थंबनेल प्राप्त करना**

Legacy/deprecated API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```

Modern API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```

### **शेप थंबनेल प्राप्त करना**

Legacy/deprecated API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```

Modern API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```

### **प्रेजेंटेशन थंबनेल प्राप्त करना**

Legacy/deprecated API:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    var bitmaps = pres.GetThumbnails(new RenderingOptions(), new Size(1980, 1028));
    try
    {
        for (var index = 0; index < bitmaps.Length; index++)
        {
            Bitmap thumbnail = bitmaps[index];
            thumbnail.Save($"slide{index}.png", ImageFormat.Png);
        }
    }
    finally
    {
        foreach (Bitmap bitmap in bitmaps)
        {
            bitmap.Dispose();
        }
    }
}
```

Modern API:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    var images = pres.GetImages(new RenderingOptions(), new Size(1980, 1028));
    try
    {
        for (var index = 0; index < images.Length; index++)
        {
            IImage thumbnail = images[index];
            thumbnail.Save($"slide{index}.png", ImageFormat.Png);
        }
    }
    finally
    {
        foreach (IImage image in images)
        {
            image.Dispose();
        }
    }
}
```

### **प्रेजेंटेशन में चित्र जोड़ना**

Legacy/deprecated API:

``` csharp
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    using (Image image = Image.FromFile("image.png"))
    {
        ppImage = pres.Images.AddImage(image);
    }

    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
}
```

Modern API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    using (IImage image = Aspose.Slides.Images.FromFile("image.png"))
    {
        ppImage = pres.Images.AddImage(image);
    }

    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
}
```
## **Deprecated Methods/Properties and Their Replacement in Modern API**

### **Presentation**
| Method Signature | Replacement Method Signature |
|-------------------|------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Print() | No Modern API replacement |
| public void Print(PrinterSettings printerSettings) | No Modern API replacement |
| public void Print(string printerName) | No Modern API replacement |
| public void Print(PrinterSettings printerSettings, string presName) | No Modern API replacement |

### **Shape**
| Method Signature | Replacement Method Signature |
|-------------------|------------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| Method Signature | Replacement Method Signature |
|-------------------|------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY) | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options) | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize) | [GetImage(Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options) | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | No Modern API replacement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | No Modern API replacement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | No Modern API replacement |

### **Output**
| Method Signature | Replacement Method Signature |
|-------------------|------------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| Method Signature | Replacement Method Signature |
|-------------------|------------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| Method Signature | Replacement Method Signature |
|-------------------|------------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| Method/Property Signature | Replacement Method Signature |
|---------------------------|------------------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| Method Signature | Replacement Method Signature |
|-------------------|------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| Method Signature | Replacement Method Signature |
|-------------------|------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **API Support for Graphics and PrinterSettings**

[Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) क्लास .NET6 और उच्च संस्करणों के क्रॉस‑प्लेटफ़ॉर्म संस्करणों के लिए समर्थित नहीं है। Aspose Slides में, [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) को रेंडर करने वाली API के बजाय Modern API के इमेज‑रेंडरिंग मेथड्स का उपयोग करें:
[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

इसी प्रकार, [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) से संबंधित API के लिए कोई प्रत्यक्ष Modern API प्रतिस्थापन नहीं है:

[IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)

## **अक्सर पूछे जाने वाला प्रश्न**

### क्यों [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) को हटाया गया?

[Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) के समर्थन को सार्वजनिक API में अप्रचलित किया गया है ताकि रेंडरिंग और इमेज के साथ कार्य को एकीकृत किया जा सके, प्लेटफ़ॉर्म‑विशिष्ट निर्भरताओं को हटाया जा सके, और [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) के साथ क्रॉस‑प्लेटफ़ॉर्म दृष्टिकोण अपनाया जा सके। [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) के बजाय `GetImage` या `GetImages` का उपयोग करें।

### [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) का उपयोग [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)/[Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap) की तुलना में व्यावहारिक रूप से क्या लाभ देता है?

[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) रास्टर और वेक्टर दोनों इमेज के साथ काम करना एकीकृत करता है, विभिन्न फ़ॉर्मेट में सहेजने को [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) के माध्यम से सरल बनाता है, `System.Drawing` पर निर्भरता को कम करता है, और कोड को विभिन्न वातावरणों में अधिक पोर्टेबल बनाता है।

### क्या Modern API थंबनेल जनरेट करने के प्रदर्शन को प्रभावित करेगा?

`GetThumbnail` से `GetImage` में स्विच करने से प्रदर्शन ख़राब नहीं होता; नई मेथड्स वही क्षमताएँ प्रदान करती हैं, विकल्पों और आकारों के साथ इमेज उत्पन्न करने के लिए, जबकि रेंडरिंग विकल्पों को बनाए रखती हैं। विशिष्ट लाभ या हानि परिदृश्य पर निर्भर करती है, लेकिन कार्यात्मक रूप से प्रतिस्थापन समान हैं।