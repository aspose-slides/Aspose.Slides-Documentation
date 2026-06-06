---
title: تعزيز معالجة الصور باستخدام الواجهة الحديثة
linktitle: الواجهة الحديثة
type: docs
weight: 237
url: /ar/net/modern-api/
keywords:
- System.Drawing
- الواجهة الحديثة
- الرسم
- صورة مصغرة للشرائح
- تحويل الشريحة إلى صورة
- صورة مصغرة للشكل
- تحويل الشكل إلى صورة
- صورة مصغرة للعرض التقديمي
- تحويل العرض إلى صور
- إضافة صورة
- إضافة صورة
- .NET
- C#
- Aspose.Slides
description: قم بتحديث معالجة صور الشرائح عن طريق استبدال واجهات برمجة التطبيقات التصويرية المهملة بواجهة .NET الحديثة لتحقيق أتمتة سلسة لـ PowerPoint و OpenDocument.
---
## **المقدمة**

تاريخيًا، تعتمد Aspose Slides على System.Drawing ولها في واجهة برمجة التطبيقات العامة الفئات التالية من هناك:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

اعتبارًا من الإصدار 24.4، تم إعلان أن هذه الواجهة العامة مهملة.

نظرًا لإزالة دعم System.Drawing في الإصدارات .NET6 وما فوق للإصدارات غير الويندوز ([تغيير كسرية](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only))، نفذت Slides نهجًا يتألف من حزمتين:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) - دعم لـ .NET6+ على ويندوز، .NETStandard على ويندوز/لينكس/ماك، .NETFramework 2+ (ويندوز).  
  - يعتمد على [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) - نسخة ويندوز/لينكس/ماك بدون تبعيات.

العقبة في [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) هي أنه ينفذ نسخته الخاصة من System.Drawing في نفس مساحة الاسم (لدعم التوافق مع الواجهة العامة). لذا، عند استخدام Aspose.Slides.NET6.CrossPlatform وSystem.Drawing من .NET Framework أو حزمة System.Drawing.Common في نفس الوقت، يحدث تعارض في الأسماء ما لم يتم استخدام اسم مستعار.

من أجل التخلص من التبعيات على System.Drawing في حزمة Aspose.Slides.NET الرئيسية، أضفنا ما يسمى بـ "الواجهة الحديثة" - أي الواجهة التي يجب استخدامها بدلاً من القديمة، والتي تحتوي توقيعاتها على تبعيات على الأنواع التالية من System.Drawing: [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) و[Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). تم إعلان [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) و[Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) مهملتين وتم إزالة دعمهما من واجهة برمجة التطبيقات العامة لـ Slides.

في الإصدارات الحالية، عُد الواجهة العامة التي تعتمد على System.Drawing إلى الحالة القديمة/المهملة. استخدم الواجهة الحديثة للشفرة الجديدة وعند ترحيل سير عمل معالجة الصور الحالي.

## **الواجهة الحديثة**

تمت إضافة الفئات والعدادات التالية إلى الواجهة العامة:

- [Aspose.Slides.IImage](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/) - تمثّل الصورة النقطية أو المتجهة.
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/imageformat/) - تمثّل تنسيق ملف الصورة.
- [Aspose.Slides.Images](https://reference.aspose.com/slides/ar/net/aspose.slides/images/) - طرق لإنشاء والعمل مع واجهة [IImage](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/).

يرجى ملاحظة أن [IImage](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/) قابل للتصرف (ينفّذ واجهة [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) ويجب تغليفه باستخدام `using` أو إخلاؤه بطريقة ملائمة أخرى).

استخدم `GetImage` لتصوير شريحة واحدة أو شكل واحد. استخدم `GetImages` لتصوير عدة شرائح عرض. استخدم طرق [Images](https://reference.aspose.com/slides/ar/net/aspose.slides/images/) لتحميل الصور، `AddImage` مع [IImage](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/) لإضافتها إلى عرض تقديمي، و`ReplaceImage` مع [IImage](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/) لتحديث صورة موجودة في العرض.

سيناريو نموذجي لاستخدام الواجهة الحديثة قد يبدو كما يلي:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // إنشاء مثيل قابل للتصرف من IImage من الملف على القرص.  
    using (IImage image = Images.FromFile("image.png"))
    {
        // إنشاء صورة PowerPoint بإضافة مثيل من IImage إلى صور العرض التقديمي.
        ppImage = pres.Images.AddImage(image);
    }

    // إضافة شكل صورة إلى الشريحة #1
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // الحصول على مثيل من IImage يمثل الشريحة #1.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // حفظ الصورة على القرص.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## **استبدال الشفرة القديمة بالواجهة الحديثة**

لتسهيل الانتقال، يكرر واجهـة [IImage](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/) التوقيعات المنفصلة للفئتين [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) و[Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). بصورة عامة، كل ما عليك هو استبدال استدعاء الطريقة القديمة التي تستخدم System.Drawing بالاستدعاء الجديد.

### **إنتاج صورة مصغرة للشريحة**

الواجهة القديمة/المهملة:

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

### **إنتاج صورة مصغرة للشكل**

الواجهة القديمة/المهملة:

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

### **إنتاج صورة مصغرة للعرض التقديمي**

الواجهة القديمة/المهملة:

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

الواجهة القديمة/المهملة:

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

## **الطرق/الخصائص المهملة واستبدالها في الواجهة الحديثة**

### **Presentation**
| توقيع الطريقة | توقيع الطريقة البديلة |
|---|---|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | لا يوجد استبدال في الواجهة الحديثة |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | لا يوجد استبدال في الواجهة الحديثة |
| public void Print() | لا يوجد استبدال في الواجهة الحديثة |
| public void Print(PrinterSettings printerSettings) | لا يوجد استبدال في الواجهة الحديثة |
| public void Print(string printerName) | لا يوجد استبدال في الواجهة الحديثة |
| public void Print(PrinterSettings printerSettings, string presName) | لا يوجد استبدال في الواجهة الحديثة |

### **Shape**
| توقيع الطريقة | توقيع الطريقة البديلة |
|---|---|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/ar/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/ar/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| توقيع الطريقة | توقيع الطريقة البديلة |
|---|---|
| public Bitmap GetThumbnail(float scaleX, float scaleY) | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/ar/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/ar/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options) | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/ar/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize) | [GetImage(Size imageSize)](https://reference.aspose.com/slides/ar/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options) | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/ar/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/ar/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/ar/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | لا يوجد استبدال في الواجهة الحديثة |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | لا يوجد استبدال في الواجهة الحديثة |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | لا يوجد استبدال في الواجهة الحديثة |

### **Output**
| توقيع الطريقة | توقيع الطريقة البديلة |
|---|---|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/ar/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| توقيع الطريقة | توقيع الطريقة البديلة |
|---|---|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/ar/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| توقيع الطريقة | توقيع الطريقة البديلة |
|---|---|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/ar/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| توقيع الطريقة/الخاصية | توقيع الطريقة البديلة |
|---|---|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/ar/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/ar/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| توقيع الطريقة | توقيع الطريقة البديلة |
|---|---|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/ar/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/ar/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| توقيع الطريقة | توقيع الطريقة البديلة |
|---|---|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/ar/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **دعم الواجهة للرسوميات وPrinterSettings**

فئة [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) غير مدعومة في إصدارات .NET6 وما فوق متعددة المنصات. في Aspose Slides، استخدم طرق تصوير الصور في الواجهة الحديثة بدلاً من الواجهة التي تُصوّر إلى [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics):
[ISlide](https://reference.aspose.com/slides/ar/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/ar/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/ar/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/ar/net/aspose.slides/slide/rendertographics/#rendertographics_5)

كما أن الواجهة المتعلقة بالطباعة عبر [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) ليس لها استبدال مباشر في الواجهة الحديثة:

[IPresentation](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/print/#print_2)

## **الأسئلة الشائعة**

**لماذا تم إلغاء [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)؟**

تم إلغاء دعم [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) في الواجهة العامة لتوحيد العمل مع التصوير والصور، وإزالة الاعتماد على التبعيات الخاصة بالنظام، والانتقال إلى نهج متعدد المنصات باستخدام [IImage](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/). استخدم `GetImage` أو `GetImages` بدلاً من التصوير إلى [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics).

**ما الفائدة العملية من [IImage](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/) مقارنةً بـ [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)/[Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)؟**

توحد [IImage](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/) العمل مع الصور النقطية والمتجهة، تبسّط الحفظ إلى صيغ متعددة عبر [ImageFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/imageformat/)، تقلل الاعتماد على `System.Drawing`، وتجعل الشفرة أكثر قابلية للنقل بين البيئات.

**هل ستؤثر الواجهة الحديثة على أداء إنشاء الصور المصغرة؟**

التحويل من `GetThumbnail` إلى `GetImage` لا يضعف السيناريوهات: توفر الطرق الجديدة نفس القدرات لإنتاج الصور مع الخيارات والأحجام، مع الحفاظ على دعم خيارات التصوير. يعتمد التحسن أو الانخفاض الفعلي على السيناريو، لكن من الناحية الوظيفية التعويضات متكافئة.