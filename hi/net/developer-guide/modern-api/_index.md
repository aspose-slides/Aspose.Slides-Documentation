---
title: "आधुनिक API के साथ छवि प्रसंस्करण को उन्नत बनाएं"
linktitle: "आधुनिक API"
type: docs
weight: 237
url: /hi/net/modern-api/
keywords:
- System.Drawing
- "आधुनिक API"
- "ड्रॉइंग"
- "स्लाइड थंबनेल"
- "स्लाइड को छवि में"
- "शेप थंबनेल"
- "शेप को छवि में"
- "प्रेजेंटेशन थंबनेल"
- "प्रेजेंटेशन को छवियों में"
- "छवि जोड़ें"
- "चित्र जोड़ें"
- .NET
- C#
- Aspose.Slides
description: "डिप्रिकेटेड इमेजिंग API को .NET आधुनिक API से बदलकर स्लाइड इमेज प्रोसेसिंग को आधुनिक बनाएं, जिससे पावरपॉइंट और OpenDocument ऑटोमेशन सुगम हो जाए।"
---
## **परिचय**

ऐतिहासिक रूप से, Aspose Slides को System.Drawing पर निर्भरता है और सार्वजनिक API में वहां से निम्नलिखित क्लासें हैं:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

संस्करण 24.4 से, इस सार्वजनिक API को अप्रचलित घोषित किया गया है।

चूंकि .NET6 और उसके ऊपर संस्करणों में System.Drawing समर्थन गैर‑Windows संस्करणों के लिए हटा दिया गया है ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), Slides ने दो‑पैकेज दृष्टिकोण लागू किया है:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) - समर्थन .NET6+ Windows के लिए, .NETStandard Windows/Linux/MacOS के लिए, .NETFramework 2+ (Windows)। - [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) पर निर्भरता है।
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) - Windows/Linux/MacOS संस्करण बिना निर्भरताओं के।

[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) की असुविधा यह है कि यह उसी नेमस्पेस में System.Drawing का अपना संस्करण लागू करता है (पब्लिक API की बैकवर्ड संगतता के लिए)। इसलिए, जब Aspose.Slides.NET6.CrossPlatform और .NET Framework या System.Drawing.Common पैकेज से System.Drawing एक साथ उपयोग किए जाते हैं, तो एलियास न उपयोग करने पर नाम टकराव होता है।

मुख्य Aspose.Slides.NET पैकेज में System.Drawing पर निर्भरताओं से छुटकारा पाने के लिए, हमने तथाकथित "आधुनिक API" जोड़ा है — अर्थात् वह API जिसे अप्रचलित वाले की जगह उपयोग किया जाना चाहिए, जिसकी सिग्नेचर में System.Drawing के निम्नलिखित प्रकार शामिल हैं: [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) और [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)। [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) और [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) को अप्रचलित घोषित किया गया है और उनके समर्थन को सार्वजनिक Slides API से हटा दिया गया है।

वर्तमान संस्करणों में, System.Drawing पर निर्भर सार्वजनिक API को लेगेसी/अप्रचलित मानें। नई कोड के लिए और मौजूदा इमेज‑प्रोसेसिंग कार्यप्रवाह को माइग्रेट करते समय आधुनिक API का उपयोग करें।

## **आधुनिक API**

सार्वजनिक API में निम्नलिखित क्लास और एन्‍युम जोड़े गए हैं:

- [Aspose.Slides.IImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) - रास्टर या वेक्टर छवि को दर्शाता है।
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/imageformat/) - छवि के फ़ाइल स्वरूप को दर्शाता है।
- [Aspose.Slides.Images](https://reference.aspose.com/slides/hi/net/aspose.slides/images/) - [IImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) इंटरफ़ेस को इंस्टैंशिएट करने और उसके साथ काम करने के मेथड।

कृपया ध्यान दें कि [IImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) डिस्पोज़ेबल है (यह [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) इंटरफ़ेस को इम्प्लीमेंट करता है और इसका उपयोग `using` ब्लॉक में या किसी अन्य सुविधाजनक तरीके से डिस्पोज़ किया जाना चाहिए)।

`GetImage` का उपयोग करके एकल स्लाइड या श shape को रेंडर करें। कई प्रेजेंटेशन स्लाइड्स को रेंडर करने के लिए `GetImages` का उपयोग करें। छवियों को लोड करने के लिए [Images](https://reference.aspose.com/slides/hi/net/aspose.slides/images/) मेथड, प्रेजेंटेशन में जोड़ने के लिए `AddImage` के साथ [IImage] का प्रयोग, और मौजूदा प्रेजेंटेशन छवि को अपडेट करने के लिए `ReplaceImage` के साथ [IImage] का प्रयोग करें।

नया API उपयोग करने का एक सामान्य परिदृश्य इस प्रकार हो सकता है:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // डिस्क पर फाइल से IImage का डिस्पोज़ेबल इंस्टेंस बनाएं।  
    using (IImage image = Images.FromFile("image.png"))
    {
        // प्रेजेंटेशन की इमेजेज में IImage का इंस्टेंस जोड़कर एक PowerPoint इमेज बनाएं।
        ppImage = pres.Images.AddImage(image);
    }

    // स्लाइड #1 पर एक चित्र आकार जोड़ें।
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // स्लाइड #1 का प्रतिनिधित्व करने वाला IImage का इंस्टेंस प्राप्त करें।
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // इमेज को डिस्क पर सहेजें।
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## **पुराने कोड को आधुनिक API से बदलना**

संक्रमण को आसान बनाने के लिए, नए [IImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) का इंटरफ़ेस [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) और [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap) क्लासों के अलग‑अलग सिग्नेचर को दोहराता है। सामान्यतः, आपको System.Drawing का उपयोग करने वाले पुराने मेथड को नए मेथड से बदलना होगा।

### **स्लाइड थंबनेल प्राप्त करना**

लेगेसी/अप्रचलित API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```

आधुनिक API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```

### **श shape थंबनेल प्राप्त करना**

लेगेसी/अप्रचलित API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```

आधुनिक API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```

### **प्रेजेंटेशन थंबनेल प्राप्त करना**

लेगेसी/अप्रचलित API:

``` csharp
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

आधुनिक API:

``` csharp
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

लेगेसी/अप्रचलित API:

``` csharp
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

आधुनिक API:

``` csharp
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

## **अप्रचलित मेथड/प्रॉपर्टीज़ और उनका आधुनिक API में प्रतिस्थापन**

### **Presentation**
| मेथड सिग्नेचर | प्रतिस्थापन मेथड सिग्नेचर |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Print() | No Modern API replacement |
| public void Print(PrinterSettings printerSettings) | No Modern API replacement |
| public void Print(string printerName) | No Modern API replacement |
| public void Print(PrinterSettings printerSettings, string presName) | No Modern API replacement |

### **Shape**
| मेथड सिग्नेचर | प्रतिस्थापन मेथड सिग्नेचर |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/hi/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/hi/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| मेथड सिग्नेचर | प्रतिस्थापन मेथड सिग्नेचर |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY) | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/hi/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/hi/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options) | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/hi/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize) | [GetImage(Size imageSize)](https://reference.aspose.com/slides/hi/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options) | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/hi/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/hi/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/hi/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | No Modern API replacement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | No Modern API replacement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | No Modern API replacement |

### **Output**
| मेथड सिग्नेचर | प्रतिस्थापन मेथड सिग्नेचर |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/hi/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| मेथड सिग्नेचर | प्रतिस्थापन मेथड सिग्नेचर |
|-------------------------------------------|--------------------------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/hi/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| मेथड सिग्नेचर | प्रतिस्थापन मेथड सिग्नेचर |
|----------------------------------------------------------|---------------------------------------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/hi/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| मेथड/प्रॉपर्टी सिग्नेचर | प्रतिस्थापन मेथड सिग्नेचर |
|--------------------------------------|-----------------------------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/hi/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/hi/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| मेथड सिग्नेचर | प्रतिस्थापन मेथड सिग्नेचर |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/hi/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/hi/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| मेथड सिग्नेचर | प्रतिस्थापन मेथड सिग्नेचर |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/hi/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **Graphics और PrinterSettings के लिए API समर्थन**

[Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) क्लास .NET6 और उसके ऊपर के क्रॉस‑प्लैटफ़ॉर्म संस्करणों में समर्थित नहीं है। Aspose Slides में, [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) पर रेंडर करने वाले API की जगह आधुनिक API इमेज‑रेंडरिंग मेथड का उपयोग करें:
[ISlide](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/hi/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/hi/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/hi/net/aspose.slides/slide/rendertographics/#rendertographics_5)

इसी तरह, [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) से संबंधित API का कोई प्रत्यक्ष आधुनिक API प्रतिस्थापन नहीं है:

[IPresentation](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/print/#print_2)

## **अक्सर पूछे जाने वाले प्रश्न**

**Graphics को क्यों हटाया गया?**

[Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) का समर्थन सार्वजनिक API में अप्रचलित किया गया है ताकि रेंडरिंग और इमेज के साथ काम को एकीकृत किया जा सके, प्लेटफ़ॉर्म‑विशिष्ट निर्भरताओं को हटाया जा सके, और [IImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) के साथ क्रॉस‑प्लैटफ़ॉर्म दृष्टिकोण अपनाया जा सके। [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) पर रेंडर करने के बजाय `GetImage` या `GetImages` का उपयोग करें।

**[IImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) का [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)/[Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap) की तुलना में व्यावहारिक लाभ क्या है?**

[IImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) रास्टर और वेक्टर दोनों छवियों के साथ काम को एकीकृत करता है, [ImageFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/imageformat/) के माध्यम से विभिन्न स्वरूपों में सहेजना सरल बनाता है, `System.Drawing` पर निर्भरता को कम करता है, और कोड को विभिन्न वातावरणों में अधिक पोर्टेबल बनाता है।

**क्या आधुनिक API थंबनेल उत्पन्न करने के प्रदर्शन को प्रभावित करेगा?**

`GetThumbnail` से `GetImage` में स्विच करने से प्रदर्शन में गिरावट नहीं आती; नई मेथड समान क्षमताएँ प्रदान करती हैं, विकल्पों और आकारों के साथ इमेज उत्पन्न करने के लिए, और रेंडरिंग विकल्पों को भी संरक्षित रखती हैं। विशिष्ट लाभ या कमी परिदृश्य पर निर्भर करती है, परन्तु कार्यात्मक रूप से प्रतिस्थापन समतुल्य हैं।