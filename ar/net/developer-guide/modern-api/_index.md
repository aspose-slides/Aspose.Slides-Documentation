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
description: "تحديث معالجة صور الشرائح عن طريق استبدال واجهات برمجة التطبيقات القديمة للصور بـ .NET Modern API لتسهيل أتمتة PowerPoint و OpenDocument."
---

## **المقدمة**

تقليديًا، تعتمد Aspose Slides على System.Drawing وتحتوي API العامة على الفئات التالية منها:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

بدءًا من الإصدار 24.4، تم الإعلان عن إهمال هذه API العامة.

نظرًا لإزالة دعم System.Drawing في الإصدارات .NET6 وما فوق للإصدارات غير Windows ([تغيير كسرية](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only))، قامت Slides بتنفيذ نهج مكتبتين:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) - دعم لـ .NET6+ على Windows، .NETStandard لـ Windows/Linux/MacOS، .NETFramework 2+ (Windows).  
  - يعتمد على [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).  
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) - إصدار Windows/Linux/MacOS بدون تبعيات.

العائق في [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) هو أنه ينفذ نسخته الخاصة من System.Drawing في نفس الفضاء الاسمي (لدعم التوافق مع الإصدارات السابقة). وبالتالي، عندما يتم استخدام Aspose.Slides.NET6.CrossPlatform وSystem.Drawing من .NETFramework أو حزمة System.Drawing.Common في نفس الوقت، يحدث تعارض في الأسماء ما لم يتم استخدام alias.

للتخلص من التبعيات على System.Drawing في حزمة Aspose.Slides.NET الرئيسية، قمنا بإضافة ما يُسمى "Modern API" – أي API يجب استخدامها بدلاً من القديمة، والتي لا تحتوي توقيعاتها على تبعيات على الأنواع التالية من System.Drawing: Image و Bitmap. تم إعلان PrinterSettings و Graphics كمهملين وإزالة دعمهما من API العامة لـ Slides.

ستتم إزالة API العامة المهملة ذات التبعيات على System.Drawing في الإصدار 24.8.

## **Modern API**

أضيفت الفئات والعدادات التالية إلى API العامة:

- Aspose.Slides.IImage – تمثل الصورة النقطية أو المتجهة.  
- Aspose.Slides.ImageFormat – تمثل تنسيق ملف الصورة.  
- Aspose.Slides.Images – طرق لإنشاء والعمل مع واجهة IImage.

يرجى ملاحظة أن IImage قابل للتصرف (يت implements واجهة IDisposable ويجب تغليفه باستخدام using أو التخلص منه بطريقة مناسبة).

سيناريو نموذجي لاستخدام API الجديدة قد يبدو كما يلي:
``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // إنشاء مثيل قابل للتصريف من IImage من الملف على القرص.  
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


## **استبدال الكود القديم بـ Modern API**

لتسهيل الانتقال، تعيد واجهة IImage الجديدة توقيعات الفئات Image و Bitmap بشكل منفصل. عمومًا، ما عليك سوى استبدال استدعاء الطريقة القديمة التي تستخدم System.Drawing بالجديدة.

### **الحصول على صورة مصغرة للشريحة**

الكود باستخدام API مهملة:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```


Modern API:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```


### **الحصول على صورة مصغرة للشكل**

الكود باستخدام API مهملة:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```


Modern API:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```


### **الحصول على صورة مصغرة للعرض التقديمي**

الكود باستخدام API مهملة:
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


Modern API:
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

الكود باستخدام API مهملة:
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


Modern API:
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


## **الطرق/الخصائص التي ستُحذف واستبدالها في Modern API**

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

## **ستتوقف الدعم لواجهة Graphics و PrinterSettings**

فئة [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) غير مدعومة في الإصدارات المتعددة المنصات من .NET6 وما فوق. في Aspose Slides، سيتم إزالة الجزء المتعلق بها من API:
[Slide](https://reference.aspose.com/slides/net/aspose.slides/slide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

كما سيتم إزالة الجزء المتعلق بالطباعة من API:

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)

# **الأسئلة الشائعة**

**لماذا تم حذف System.Drawing.Graphics؟**

يتم إزالة دعم `Graphics` من API العامة لتوحيد التعامل مع التصيّر والصور، وإزالة الاعتمادية على مكتبات منصة محددة، والانتقال إلى نهج متعدد المنصات باستخدام [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/). جميع طرق التصيّر إلى `Graphics` ستُحذف.

**ما الفائدة العملية من IImage مقارنةً بـ Image/Bitmap؟**

يوحد [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) العمل مع الصور النقطية والمتجهة، يبسط الحفظ إلى صيغ متعددة عبر [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/)، يقلل الاعتماد على `System.Drawing`، ويجعل الكود أكثر قابلية للنقل بين البيئات.

**هل سيؤثر Modern API على أداء إنشاء الصور المصغرة؟**

التحول من `GetThumbnail` إلى `GetImage` لا يفاقم الأداء: الطرق الجديدة توفر نفس القدرات لإنشاء الصور مع خيارات وأحجام مختلفة، مع الحفاظ على دعم خيارات التصيّر. الفائدة أو الفقدان يعتمد على السيناريو، لكن من الناحية الوظيفية البدائل متكافئة.