---
title: تحسين معالجة الصور باستخدام الواجهة الحديثة
linktitle: الواجهة الحديثة
type: docs
weight: 237
url: /ar/net/modern-api/
keywords:
- System.Drawing
- الواجهة الحديثة
- الرسم
- صورة مصغرة للشريحة
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
description: "حديث معالجة صور الشرائح عن طريق استبدال واجهات برمجة التطبيقات التصويرية القديمة بواجهة .NET الحديثة لتحقيق أتمتة سلسة لبرنامج PowerPoint وOpenDocument."
---

## **مقدمة**

تاريخيًا، يعتمد Aspose Slides على System.Drawing ويحتوي في واجهة برمجة التطبيقات العامة على الفئات التالية من هناك:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

اعتبارًا من الإصدار 24.4، تم الإشارة إلى أن هذه الواجهة العامة قديمة.

نظرًا لأن دعم System.Drawing في الإصدارات .NET6 فما فوق تم إزالته للإصدارات غير Windows ([تغيير كسرية](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only))، نفذت Slides نهجًا قائمًا على إصداري مكتبة:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) – دعم .NET6+ لنظام Windows، .NETStandard لنظام Windows/Linux/MacOS، .NETFramework 2+ (Windows).  
  - يعتمد على [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) – إصدار Windows/Linux/MacOS بدون تبعيات.

العائق في [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) هو أنه ينفّذ نسخته الخاصة من System.Drawing في نفس النطاق (لتوفير توافق رجعي مع الواجهة العامة). وبالتالي، عندما تُستخدم Aspose.Slides.NET6.CrossPlatform وSystem.Drawing من .NETFramework أو حزمة System.Drawing.Common في الوقت نفسه، يحدث تعارض في الأسماء ما لم يتم استخدام اسم مستعار.

للتخلص من التبعيات على System.Drawing في حزمة Aspose.Slides.NET الرئيسية، أضفنا ما يُسمى "الواجهة الحديثة" – أي الواجهة التي ينبغي استخدامها بدلاً من القديمة، والتي تحتوي توقيعاتها على تبعيات الأنواع التالية من System.Drawing: Image وBitmap. تم الإعلان عن أن PrinterSettings وGraphics قديمين وتم إزالة دعمهما من واجهة Slides العامة.

ستتم إزالة الواجهة العامة القديمة ذات التبعيات على System.Drawing في الإصدار 24.8.

## **الواجهة الحديثة**

أُضيفت الفئات والعدادات التالية إلى الواجهة العامة:

- Aspose.Slides.IImage – تمثّل الصورة النقطية أو المتجهة.
- Aspose.Slides.ImageFormat – تمثّل تنسيق ملف الصورة.
- Aspose.Slides.Images – طرق لإنشاء والعمل مع واجهة IImage.

يرجى ملاحظة أن IImage قابلة للتصرف (تنفّذ واجهة IDisposable ويجب تغليف استخدامها بـ using أو تحريرها بطريقة مناسبة أخرى).

سيناريو نموذجي لاستخدام الواجهة الحديثة قد يبدو كما يلي:
``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // إنشاء نسخة قابلة للتصريف من IImage من الملف الموجود على القرص.  
    using (IImage image = Images.FromFile("image.png"))
    {
        // إنشاء صورة PowerPoint بإضافة نسخة من IImage إلى صور العرض التقديمي.
        ppImage = pres.Images.AddImage(image);
    }

    // إضافة شكل صورة إلى الشريحة #1
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // الحصول على نسخة من IImage تمثّل الشريحة #1.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // حفظ الصورة على القرص.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```


## **استبدال الكود القديم بالواجهة الحديثة**

لتسهيل الانتقال، يكرّر واجهة IImage الجديدة التوقيعات المنفصلة لفئتي Image وBitmap. بصورة عامة، ستحتاج فقط إلى استبدال استدعاء الطريقة القديمة التي تستخدم System.Drawing بالاستدعاء الجديد.

### **الحصول على صورة مصغرة للشريحة**

الكود باستخدام الواجهة القديمة:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```


الواجهة الحديثة:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```


### **الحصول على صورة مصغرة للشكل**

الكود باستخدام الواجهة القديمة:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```


الواجهة الحديثة:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```


### **الحصول على صورة مصغرة للعرض التقديمي**

الكود باستخدام الواجهة القديمة:
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


الواجهة الحديثة:
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


### **إضافة صورة إلى عرض تقديمي**

الكود باستخدام الواجهة القديمة:
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


الواجهة الحديثة:
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


## **الطرق/الخصائص التي سيتم إزالتها واستبدالها في الواجهة الحديثة**

### **Presentation**
| توقيع الطريقة | توقيع طريقة الاستبدال |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)]() |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | سيُحذف بالكامل |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | سيُحذف بالكامل |
| public void Print() | سيُحذف بالكامل |
| public void Print(PrinterSettings printerSettings) | سيُحذف بالكامل |
| public void Print(string printerName) | سيُحذف بالكامل |
| public void Print(PrinterSettings printerSettings, string presName) | سيُحذف بالكامل |

### **Shape**
| توقيع الطريقة | توقيع طريقة الاستبدال |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| توقيع الطريقة | توقيع طريقة الاستبدال |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY) | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options) | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize) | [GetImage(Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options) | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | سيُحذف بالكامل |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | سيُحذف بالكامل |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | سيُحذف بالكامل |

### **Output**
| توقيع الطريقة | توقيع طريقة الاستبدال |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| توقيع الطريقة | توقيع طريقة الاستبدال |
|-------------------------------------------|--------------------------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| توقيع الطريقة | توقيع طريقة الاستبدال |
|----------------------------------------------------------|---------------------------------------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| توقيع الطريقة/الخاصية | توقيع طريقة الاستبدال |
|--------------------------------------|-----------------------------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| توقيع الطريقة | توقيع طريقة الاستبدال |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| توقيع الطريقة | توقيع طريقة الاستبدال |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **سيتم إيقاف دعم Graphics وPrinterSettings في الواجهة**

فئة [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) غير مدعومة في إصدارات .NET6 وما فوق المتعددة المنصات. في Aspose Slides، سيتم إزالة الجزء من الواجهة الذي يستخدمها:
[Slide](https://reference.aspose.com/slides/net/aspose.slides/slide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

كما سيتم إزالة الجزء المتعلق بالطباعة من الواجهة:

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)

# **الأسئلة المتكررة**

**لماذا تم إلغاء Graphics من System.Drawing؟**

يتم إزالة دعم `Graphics` من الواجهة العامة لتوحيد العمل مع التصيير والصور، وإزالة الروابط إلى تبعيات مخصصة للمنصة، والانتقال إلى نهج متعدد المنصات باستخدام [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/). سيتم حذف جميع طرق التصيير إلى `Graphics`.

**ما الفائدة العملية من IImage مقارنةً بـ Image/Bitmap؟**

[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) توحّد التعامل مع الصور النقطية والمتجهة، وتبسط الحفظ إلى صيغ مختلفة عبر [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/)، وتقلل الاعتماد على `System.Drawing`، وتجعل الشيفرة أكثر قابلية للنقل بين البيئات.

**هل ستؤثر الواجهة الحديثة على أداء إنشاء الصور المصغرة؟**

الانتقال من `GetThumbnail` إلى `GetImage` لا يفاقم الأداء: توفر الطرق الجديدة نفس القدرات لإنتاج الصور مع الخيارات والأحجام، مع الحفاظ على دعم خيارات التصيير. الفائدة أو الانخفاض المحدد يعتمد على السيناريو، لكن من الناحية الوظيفية التعويضات متكافئة.