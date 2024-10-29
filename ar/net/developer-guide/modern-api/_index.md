---
title: واجهة برمجة التطبيقات الحديثة
type: docs
weight: 237
url: /ar/net/modern-api/
keywords: "نظام واجهة برمجة التطبيقات الحديثة المتعددة المنصات System.Drawing"
description: "واجهة برمجة التطبيقات الحديثة"
---

## المقدمة

تاريخياً، كانت Aspose Slides تعتمد على System.Drawing وتحتوي في واجهة برمجة التطبيقات العامة على الفئات التالية من هناك:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

اعتبارًا من الإصدار 24.4، تم إعلان أن واجهة برمجة التطبيقات العامة هذه أصبحت قديمة.

نظرًا لأن دعم System.Drawing في الإصدارات .NET6 وما فوق تم إزالته للإصدارات غير الخاصة بنظام ويندوز ([تغيير جذري](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only))، قامت Slides بتنفيذ نهج يعتمد على إصدارين من المكتبة:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) - دعم لـ .NET6+ على ويندوز و .NETStandard لنظامي ويندوز / لينوكس / ماك أو إس و .NETFramework 2+ (ويندوز).
  - تعتمد على [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) - إصدار ويندوز / لينوكس / ماك أو إس بدون تبعيات.

العيب في [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) هو أنه ينفذ نسخته الخاصة من System.Drawing في نفس المساحة الاسمية (للدعم التوافقي مع واجهة برمجة التطبيقات العامة). وبالتالي، عند استخدام Aspose.Slides.NET6.CrossPlatform و System.Drawing من .NETFramework أو حزمة System.Drawing.Common في نفس الوقت، يحدث تعارض في الأسماء ما لم يتم استخدام اسم مستعار.

للتخلص من التبعيات على System.Drawing في الحزمة الرئيسية Aspose.Slides.NET، أضفنا ما يسمى "واجهة برمجة التطبيقات الحديثة" - أي الواجهة التي ينبغي استخدامها بدلاً من الواجهة الموقوفة، والتي تحتوي تواقيعها على تبعيات من الأنواع التالية من System.Drawing: Image و Bitmap. وتم إعلان أن PrinterSettings و Graphics أصبحت قديمة وتمت إزالة دعمها من واجهة برمجة التطبيقات العامة لـ Slides.

سيتم إزالة واجهة برمجة التطبيقات العامة القديمة التي تحتوي على تبعيات على System.Drawing في الإصدار 24.8.

## واجهة برمجة التطبيقات الحديثة

تم إضافة الفئات والإعدادات التالية إلى واجهة برمجة التطبيقات العامة:

- Aspose.Slides.IImage - تمثل الصورة النقطية أو الصورة المتجهة.
- Aspose.Slides.ImageFormat - تمثل تنسيق ملف الصورة.
- Aspose.Slides.Images - طرق لإنشاء والعمل مع واجهة IImage.

يرجى ملاحظة أن IImage قابلة للتصرف (تنفذ واجهة IDisposable ويجب إلحاق استخدامها بـ using أو التخلص منها بطريقة أخرى ملائمة).

قد يبدو سيناريو الاستخدام النموذجي للواجهة الجديدة كما يلي:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // إنشاء مثيل يمكن التخلص منه من IImage من الملف على القرص.  
    using (IImage image = Images.FromFile("image.png"))
    {
        // إنشاء صورة PowerPoint عن طريق إضافة مثيل من IImage إلى صور العرض التقديمي.
        ppImage = pres.Images.AddImage(image);
    }

    // إضافة شكل صورة على الشريحة #1
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // الحصول على مثيل من IImage يمثل الشريحة #1.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // حفظ الصورة على القرص.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## استبدال الشيفرة القديمة بواجهة برمجة التطبيقات الحديثة

لتسهيل الانتقال، تكرر واجهة IImage الجديدة التواقيع المنفصلة للفئات Image و Bitmap. بشكل عام، تحتاج فقط إلى استبدال استدعاء الطريقة القديمة المستخدمة لـ System.Drawing بالطريقة الجديدة.

### الحصول على صورة مصغرة للشريحة

شيفرة تستخدم واجهة برمجة التطبيقات القديمة:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```

واجهة برمجة التطبيقات الحديثة:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```

### الحصول على صورة مصغرة لشكل

شيفرة تستخدم واجهة برمجة التطبيقات القديمة:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```

واجهة برمجة التطبيقات الحديثة:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```

### الحصول على صورة مصغرة للعرض التقديمي

شيفرة تستخدم واجهة برمجة التطبيقات القديمة:

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

واجهة برمجة التطبيقات الحديثة:

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

### إضافة صورة إلى عرض تقديمي

شيفرة تستخدم واجهة برمجة التطبيقات القديمة:

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

واجهة برمجة التطبيقات الحديثة:

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

## الطرق / الخصائص التي ستتم إزالتها واستبدالها في واجهة برمجة التطبيقات الحديثة

### عرض تقديمي
| توقيع الطريقة                               | توقيع طريقة الاستبدال                             |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages)                   |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_1)   |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)]() |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | سيتم حذفه تمامًا |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | سيتم حذفه تمامًا |
| public void Print()                           | سيتم حذفه تمامًا                               |
| public void Print(PrinterSettings printerSettings) | سيتم حذفه تمامًا                            |
| public void Print(string printerName)         | سيتم حذفه تمامًا                               |
| public void Print(PrinterSettings printerSettings, string presName) | سيتم حذفه تمامًا                          |

### شكل
| توقيع الطريقة                                                      | توقيع طريقة الاستبدال                                       |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public Bitmap GetThumbnail()                                          | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage)                                                           |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage_1) |

### شريحة
| توقيع الطريقة                                                      | توقيع طريقة الاستبدال                                           |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY)                | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_5)                                 |
| public Bitmap GetThumbnail()                                         | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage)                                                              |
| public Bitmap GetThumbnail(IRenderingOptions options)                | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_1)                                  |
| public Bitmap GetThumbnail(Size imageSize)                           | [GetImage(Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_6)                                             |
| public Bitmap GetThumbnail(ITiffOptions options)                    | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_4)                                      |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_3)               |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | سيتم حذفه تمامًا                                       |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | سيتم حذفه تمامًا                             |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | سيتم حذفه تمامًا                                    |

#### مخرجات
| توقيع الطريقة                                                | توقيع طريقة الاستبدال                                |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public IOutputFile Add(string path, Image image)               | [Add(string path, IImage image)](https://reference.aspose.com/slides/net/aspose.slides.export.web/output/add#add_1)                               |

### مجموعة الصور
| توقيع الطريقة                          | توقيع طريقة الاستبدال               |
|-------------------------------------------|--------------------------------------------|
| IPPImage AddImage(Image image)           | [AddImage(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/addimage#addimage)                      |

### مصنع غلاف الصورة
| توقيع الطريقة                                         | توقيع طريقة الاستبدال                            |
|----------------------------------------------------------|---------------------------------------------------------|
| IImageWrapper CreateImageWrapper(Image image)           | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper)                        |

### صورة العرض
| توقيع / خاصية                                       | توقيع طريقة الاستبدال   |
|--------------------------------------|-----------------------------------------|
| void ReplaceImage(Image newImage)   | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/net/aspose.slides/ppimage/replaceimage#replaceimage)            |
| Image SystemImage { get; }          | [IImage Image { get; }](https://reference.aspose.com/slides/net/aspose.slides/ppimage/image)                    |

### تنسيق نمط
| توقيع الطريقة                                          | توقيع طريقة الاستبدال                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground)   | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile_1)         |
| Bitmap GetTileImage(Color styleColor)                     | [GetTile(Color styleColor)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile)                           |

### بيانات فعالة لتنسيق النمط
| توقيع الطريقة                                          | توقيع طريقة الاستبدال                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground)   | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/net/aspose.slides/ipatternformateffectivedata/gettileiimage)                    |

## دعم Aspose.Slides.NET6.CrossPlatform سيتم إيقافه

بعد إصدار [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) الإصدار 24.8، سيتم إيقاف دعم [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform).

## دعم واجهة برمجة التطبيقات لـ Graphics و PrinterSettings سيتم إيقافه

فئة [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) غير مدعومة للإصدارات المتعددة المنصات من .NET6 وما فوق. في Aspose Slides، سيتم إزالة جزء من واجهة برمجة التطبيقات الذي يستخدمها:
[Slide](https://reference.aspose.com/slides/net/aspose.slides/slide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

أيضًا، سيتم إزالة جزء من واجهة برمجة التطبيقات المتعلقة بالطباعة:

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)