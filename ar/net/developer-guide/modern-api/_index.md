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
description: "تحديث معالجة صور الشرائح عن طريق استبدال واجهات التصوير المهجّرة بواجهة .NET الحديثة لتحقيق أتمتة سلسة لبرنامج PowerPoint وOpenDocument."
---

## **المقدمة**

تاريخيًا، تعتمد مكتبة Aspose Slides على System.Drawing وتحتوي واجهة برمجة التطبيقات العامة على الفئات التالية منها:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

اعتبارًا من الإصدار 24.4، تم إعلان أن هذه الواجهة العامة مهجّرة.

نظرًا لإزالة دعم System.Drawing في الإصدارات .NET6 وما فوق للإصدارات غير Windows ([تغيير كسرية](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only))، اعتمدت Slides نهجًا يتضمن مكتبتين:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) – يدعم .NET6+ لـ Windows، .NETStandard لـ Windows/Linux/MacOS، .NETFramework 2+ (Windows).  
  - يعتمد على [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) – نسخة Windows/Linux/MacOS بدون تبعيات.

العائق في [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) هو أنه ينفّذ إصداره الخاص من System.Drawing في نفس مساحة الأسماء (لدعم التوافق مع الواجهة العامة القديمة). لذلك، عند استخدام Aspose.Slides.NET6.CrossPlatform مع System.Drawing من .NETFramework أو حزمة System.Drawing.Common في آنٍ واحد، يحدث تعارض في الأسماء ما لم يتم استخدام اسم مستعار.

للتخلص من تبعيات System.Drawing في حزمة Aspose.Slides.NET الأساسية، أضفنا ما يُسمى "الواجهة الحديثة" – أي الواجهة التي ينبغي استخدامها بدلاً من القديمة المهجّرة، والتي كانت توقيعاتها تعتمد على الأنواع التالية من System.Drawing: Image و Bitmap. تم إعلان PrinterSettings و Graphics مهجّرين وتم إزالة دعمهما من الواجهة العامة لـ Slides.

ستتم إزالة الواجهة العامة المهجّرة التي تعتمد على System.Drawing في الإصدار 24.8.

## **الواجهة الحديثة**

تمت إضافة الفئات والعدادات التالية إلى الواجهة العامة:

- Aspose.Slides.IImage – تمثّل الصورة النقطية أو المتجهة.
- Aspose.Slides.ImageFormat – تمثّل صيغة ملف الصورة.
- Aspose.Slides.Images – طرق لإنشاء والعمل مع واجهة IImage.

يرجى ملاحظة أن IImage قابل للإلغاء (يُطبق واجهة IDisposable ويجب تغليفه باستخدام using أو إلغاءه بطريقة مناسبة أخرى).

سيناريو نموذجي لاستخدام الواجهة الحديثة قد يبدو كما يلي:
``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // إنشاء كائن IImage قابل للتصرف من الملف الموجود على القرص.
    using (IImage image = Images.FromFile("image.png"))
    {
        // إنشاء صورة PowerPoint بإضافة كائن IImage إلى صور العرض التقديمي.
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

لتسهيل الانتقال، تُعيد واجهة IImage الجديدة توقيعات الفئات Image و Bitmap منفصلة. بشكل عام، ما عليك سوى استبدال استدعاء الطريقة القديمة التي تستخدم System.Drawing بالواحدة الجديدة.

### **الحصول على صورة مصغرة للشريحة**

الكود باستخدام واجهة مهجّرة:
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

الكود باستخدام واجهة مهجّرة:
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

الكود باستخدام واجهة مهجّرة:
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


### **إضافة صورة إلى العرض التقديمي**

الكود باستخدام واجهة مهجّرة:
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


## **الطرق/الخصائص التي ستُحذف وبدائلها في الواجهة الحديثة**

### **Presentation**
| توقيع الطريقة | توقيع الطريقة البديلة |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)]() |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | سيتم حذفها بالكامل |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | سيتم حذفها بالكامل |
| public void Print() | سيتم حذفها بالكامل |
| public void Print(PrinterSettings printerSettings) | سيتم حذفها بالكامل |
| public void Print(string printerName) | سيتم حذفها بالكامل |
| public void Print(PrinterSettings printerSettings, string presName) | سيتم حذفها بالكامل |

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
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | سيتم حذفها بالكامل |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | سيتم حذفها بالكامل |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | سيتم حذفها بالكامل |

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

## **ستتوقف دعم واجهة Graphics و PrinterSettings**

فئة [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) غير مدعومة في الإصدارات المتعددة المنصات من .NET6 وما فوق. في Aspose Slides، سيتم إزالة الجزء المتعلق بها من الواجهة:
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

# **FAQ**

**لماذا تم إلغاء Graphics من System.Drawing؟**

يتم إزالة دعم `Graphics` من الواجهة العامة لتوحيد العمل مع التصيير والصور، وإزالة الارتباطات بالاعتماديات الخاصة بالنظام، والانتقال إلى نهج متعدد المنصات باستخدام [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/). سيتم حذف جميع طرق التصيير التي تستهدف `Graphics`.

**ما الفائدة العملية من IImage مقارنةً بـ Image/Bitmap؟**

يُوحّد [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) التعامل مع الصور النقطية والمتجهة، يبسط حفظ الصور بصيغ متعددة عبر [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/)، يقلل الاعتماد على `System.Drawing`، ويجعل الكود أكثر قابلية للنقل بين البيئات.

**هل ستؤثر الواجهة الحديثة على أداء إنشاء الصور المصغرة؟**

التحول من `GetThumbnail` إلى `GetImage` لا يضيف عبئًا ملحوظًا؛ توفر الطرق الجديدة نفس القدرات لإنتاج الصور مع الخيارات والحجم المطلوب، مع الحفاظ على دعم خيارات التصيير. تعتمد الفائدة أو الفقدان على السيناريو، لكن وظيفيًا المتبدلات متكافئة.