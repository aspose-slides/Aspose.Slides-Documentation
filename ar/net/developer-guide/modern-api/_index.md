---
title: تحسين معالجة الصور باستخدام الواجهة الحديثة
linktitle: الواجهة الحديثة
type: docs
weight: 234
url: /ar/net/modern-api/
keywords:
- System.Drawing
- واجهة حديثة
- رسم
- صورة مصغرة للشرائح
- تحويل الشريحة إلى صورة
- صورة مصغرة للشكل
- تحويل الشكل إلى صورة
- صورة مصغرة للعرض التقديمي
- تحويل العرض التقديمي إلى صور
- إضافة صورة
- إضافة صورة
- .NET
- C#
- Aspose.Slides
description: "تحديث معالجة صور الشرائح عن طريق استبدال واجهات برمجة التطبيقات القديمة للصور بواجهة .NET الحديثة لتسهيل أتمتة PowerPoint وOpenDocument بسلاسة."
---
## **المقدمة**

تاريخيًا، Aspose Slides لديها اعتماد على System.Drawing وتحتوي في واجهة برمجة التطبيقات العامة على الفئات التالية منها:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

اعتبارًا من الإصدار 24.4، تم إعلان أن واجهة برمجة التطبيقات العامة هذه مهجورة.

نظرًا لأن دعم System.Drawing في الإصدارات .NET6 وما فوق قد تم إزالته للإصدارات غير Windows ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only))، قامت Slides بتنفيذ نهج حزمين:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) – دعم لـ .NET6+ على Windows، .NETStandard لـ Windows/Linux/MacOS، .NETFramework 2+ (Windows).  
  - يعتمد على [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) – نسخة Windows/Linux/MacOS بدون تبعيات.

إن الإزعاج المتعلق بـ [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) هو أنه ينفذ نسخة خاصة به من System.Drawing في نفس الفضاء الاسمي (لدعم التوافق العكسي مع الواجهة العامة). وبالتالي، عند استخدام Aspose.Slides.NET6.CrossPlatform وSystem.Drawing من .NET Framework أو حزمة System.Drawing.Common في نفس الوقت، ينشأ تعارض في الأسماء ما لم يتم استخدام alias.

من أجل التخلص من التبعيات على System.Drawing في حزمة Aspose.Slides.NET الرئيسية، أضفنا ما يُسمى "الواجهة الحديثة" – أي الواجهة التي يجب استخدامها بدلًا من الواجهة المهجورة، والتي تحتوي توقيعاتها على تبعيات على الأنواع التالية من System.Drawing: [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) و[Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). تم إعلان [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) و[Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) مهجورين وتم إزالة دعمهما من واجهة برمجة التطبيقات العامة لـ Slides.

في الإصدارات الحالية، يُعامل الواجهة العامة التي تعتمد على System.Drawing على أنها قديمة/مهجورة. استخدم الواجهة الحديثة للكود الجديد وعند نقل عمليات معالجة الصور القائمة.

## **الواجهة الحديثة**

تم إضافة الفئات والعدادات التالية إلى الواجهة العامة:

- [Aspose.Slides.IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) – تمثِّل الصورة النقطية أو المتجهة.
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) – تمثِّل تنسيق ملف الصورة.
- [Aspose.Slides.Images](https://reference.aspose.com/slides/net/aspose.slides/images/) – طرق لإنشاء والعمل مع واجهة [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/).

يرجى ملاحظة أن [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) قابل للتصرف (يُطبق واجهة [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) ويجب تغليفه داخل using أو إخلاؤه بطريقة مناسبة).

استخدم `GetImage` لتصوير شريحة واحدة أو شكل واحد. استخدم `GetImages` لتصوير عدة شرائح عرض. استخدم طرق [Images](https://reference.aspose.com/slides/net/aspose.slides/images/) لتحميل الصور، `AddImage` مع [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) لإضافتها إلى عرض تقديمي، و`ReplaceImage` مع [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) لتحديث صورة موجودة في العرض.

سيناريو نموذجي لاستخدام الواجهة الحديثة قد يبدو كما يلي:

``` csharp
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // إنشاء كائن IImage قابل للتصرف من الملف الموجود على القرص.  
    using (IImage image = Images.FromFile("image.png"))
    {
        // إنشاء صورة PowerPoint بإضافة كائن IImage إلى مجموعة الصور في العرض.
        ppImage = pres.Images.AddImage(image);
    }

    // إضافة شكل صورة إلى الشريحة #1
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // الحصول على كائن IImage الذي يمثل الشريحة #1.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // حفظ الصورة على القرص.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## **استبدال الكود القديم بالواجهة الحديثة**

لتسهيل الانتقال، تجعل واجهة [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) الجديدة توقيعات منفصلة مماثلة لتوقيعات فئتي [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) و[Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). بشكل عام، ستحتاج فقط إلى استبدال استدعاء الطريقة القديمة المستخدمة في System.Drawing بالواحدة الجديدة.

### **إنشاء صورة مصغرة للشرائح**

واجهة قديمة/مهجورة:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```

الواجهة الحديثة:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```

### **إنشاء صورة مصغرة للأشكال**

واجهة قديمة/مهجورة:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```

الواجهة الحديثة:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```

### **إنشاء صورة مصغرة للعرض التقديمي**

واجهة قديمة/مهجورة:

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

الواجهة الحديثة:

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

### **إضافة صورة إلى عرض تقديمي**

واجهة قديمة/مهجورة:

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

الواجهة الحديثة:

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

## **الطرق/الخصائص المهجورة واستبدالها في الواجهة الحديثة**

### **Presentation**
| توقيع الطريقة | توقيع الطريقة البديلة |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | لا توجد بديلة في الواجهة الحديثة |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | لا توجد بديلة في الواجهة الحديثة |
| public void Print() | لا توجد بديلة في الواجهة الحديثة |
| public void Print(PrinterSettings printerSettings) | لا توجد بديلة في الواجهة الحديثة |
| public void Print(string printerName) | لا توجد بديلة في الواجهة الحديثة |
| public void Print(PrinterSettings printerSettings, string presName) | لا توجد بديلة في الواجهة الحديثة |

### **Shape**
| توقيع الطريقة | توقيع الطريقة البديلة |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| توقيع الطريقة | توقيع الطريقة البديلة |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY) | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options) | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize) | [GetImage(Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options) | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | لا توجد بديلة في الواجهة الحديثة |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | لا توجد بديلة في الواجهة الحديثة |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | لا توجد بديلة في الواجهة الحديثة |

### **Output**
| توقيع الطريقة | توقيع الطريقة البديلة |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| توقيع الطريقة | توقيع الطريقة البديلة |
|-------------------------------------------|--------------------------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| توقيع الطريقة | توقيع الطريقة البديلة |
|----------------------------------------------------------|---------------------------------------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| توقيع الطريقة/الخاصية | توقيع الطريقة البديلة |
|--------------------------------------|-----------------------------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| توقيع الطريقة | توقيع الطريقة البديلة |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| توقيع الطريقة | توقيع الطريقة البديلة |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **دعم الواجهة للرسوميات وPrinterSettings**

فئة [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) غير مدعومة في الإصدارات متعددة المنصات من .NET6 وما فوق. في Aspose Slides، استخدم طرق تصيير الصور في الواجهة الحديثة بدلاً من الواجهة التي تصيّر إلى [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics):
[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

كما أن الواجهة المتعلقة بالطباعة عبر [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) لا توجد لها بديلة مباشرة في الواجهة الحديثة:

[IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)

## **الأسئلة المتكررة**

### لماذا تم إلغاء [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)؟

تم إهدار دعم [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) في الواجهة العامة لتوحيد العمل مع التصيير والصور، وإزالة الروابط إلى تبعيات منصة معينة، والانتقال إلى نهج متعدد المنصات باستخدام [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/). استخدم `GetImage` أو `GetImages` بدلاً من التصيير إلى [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics).

### ما الفائدة العملية من [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) مقارنةً بـ [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) / [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)؟

[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) توحّد العمل مع كل من الصور النقطية والمتجهة، وتبسّط الحفظ إلى صيغ مختلفة عبر [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/)، وتقلل الاعتماد على `System.Drawing`، وتجعل الشيفرة أكثر قابلية للنقل عبر البيئات.

### هل ستؤثر الواجهة الحديثة على أداء إنشاء الصور المصغرة؟

التحويل من `GetThumbnail` إلى `GetImage` لا يفاقم الأداء في السيناريوهات العامة: الطرق الجديدة توفر نفس القدرات لإنتاج الصور مع الخيارات والأحجام، مع الحفاظ على دعم خيارات التصيير. الفائدة أو الفقدان المحدد يعتمد على السيناريو، لكن من الناحية الوظيفية البدائل متكافئة.