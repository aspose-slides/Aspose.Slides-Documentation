---
title: "تعزيز معالجة الصور باستخدام الواجهة الحديثة"
linktitle: "الواجهة الحديثة"
type: docs
weight: 237
url: /ar/net/modern-api/
keywords:
- "System.Drawing"
- "الواجهة الحديثة"
- "الرسم"
- "صورة مصغرة للشرائح"
- "تحويل الشريحة إلى صورة"
- "صورة مصغرة للشكل"
- "تحويل الشكل إلى صورة"
- "صورة مصغرة للعرض التقديمي"
- "تحويل العرض التقديمي إلى صور"
- "إضافة صورة"
- "إضافة صورة"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "تحديث معالجة صور الشرائح عن طريق استبدال واجهات التصوير التي تم إهمالها بواجهة .NET الحديثة لتوفير أتمتة سلسة لـ PowerPoint وOpenDocument."
---

## **المقدمة**

تاريخيًا، Aspose Slides يعتمد على System.Drawing وكان يحتوي في واجهة برمجة التطبيقات العامة على الفئات التالية من هناك:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

اعتبارًا من الإصدار 24.4، تم الإعلان عن إهمال واجهة برمجة التطبيقات العامة هذه.

نظرًا لإزالة دعم System.Drawing في الإصدارات .NET6 وما فوق للإصدارات غير الويندوز ([تغيير كسرية](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only))، نفذت Slides نهج إصدار مكتبتين:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) - دعم .NET6+ للويندوز، .NETStandard للويندوز/لينكس/ماك، .NETFramework 2+ (ويندوز).
  - يعتمد على [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) - إصدار ويندوز/لينكس/ماك بدون تبعيات.

العيب في [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) هو أنه يطبق نسخة خاصة به من System.Drawing في نفس مساحة الاسم (لدعم التوافق الرجعي مع الواجهة العامة). وبالتالي، عندما يُستخدم Aspose.Slides.NET6.CrossPlatform مع System.Drawing من .NETFramework أو حزمة System.Drawing.Common في نفس الوقت، يحدث تعارض في الأسماء ما لم يُستخدم الاسم المستعار.

من أجل التخلص من التبعيات على System.Drawing في حزمة Aspose.Slides.NET الرئيسية، أضفنا ما يُسمى "الواجهة الحديثة" – أي الواجهة التي يجب استخدامها بدلاً من الواجهة المهملة، والتي تحتوي توقيعاتها على تبعيات الأنواع التالية من System.Drawing: Image و Bitmap. تم إعلان PrinterSettings و Graphics مهملتين وتم إزالة دعمهما من واجهة برمجة التطبيقات العامة لـ Slides.

إزالة الواجهة العامة المهملة التي تعتمد على System.Drawing ستكون في الإصدار 24.8.

## **الواجهة الحديثة**

أضيفت الفئات والعدادات التالية إلى الواجهة العامة:

- Aspose.Slides.IImage – تمثل الصورة النقطية أو المتجهة.
- Aspose.Slides.ImageFormat – تمثل تنسيق ملف الصورة.
- Aspose.Slides.Images – طرق لإنشاء والعمل مع واجهة IImage.

يرجى ملاحظة أن IImage قابلة للتصرف (تطبق واجهة IDisposable ويجب تغليف استخدامها في using أو التخلص منها بطريقة مناسبة).

سيناريو نموذجي لاستخدام الواجهة الحديثة قد يبدو كما يلي:
``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // إنشاء نسخة قابلة للتخلص من IImage من الملف على القرص.  
    using (IImage image = Images.FromFile("image.png"))
    {
        // إنشاء صورة PowerPoint بإضافة نسخة من IImage إلى صور العرض التقديمي.
        ppImage = pres.Images.AddImage(image);
    }

    // إضافة شكل صورة إلى الشريحة #1
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // الحصول على نسخة من IImage تمثل الشريحة #1.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // حفظ الصورة على القرص.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```


## **استبدال الكود القديم بالواجهة الحديثة**

لتسهيل الانتقال، تُعيد واجهة IImage الجديدة توقيعات الفئات Image و Bitmap بشكل منفصل. بصورة عامة، ستحتاج فقط إلى استبدال استدعاء الطريقة القديمة التي تستخدم System.Drawing بالجديدة.

### **الحصول على صورة مصغرة للشرائح**

الكود باستخدام واجهة مهملة:
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

الكود باستخدام واجهة مهملة:
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

الكود باستخدام واجهة مهملة:
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

الكود باستخدام واجهة مهملة:
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
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | Will be deleted completely |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | Will be deleted completely |
| public void Print() | Will be deleted completely |
| public void Print(PrinterSettings printerSettings) | Will be deleted completely |
| public void Print(string printerName) | Will be deleted completely |
| public void Print(PrinterSettings printerSettings, string presName) | Will be deleted completely |

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
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | Will be deleted completely |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | Will be deleted completely |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | Will be deleted completely |

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

## **دعم Graphics و PrinterSettings سيتم إيقافه**

فئة [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) غير مدعومة للإصدارات المتعددة المنصات من .NET6 وما فوق. في Aspose Slides، سيتم إزالة الجزء من الواجهة التي تستخدمها:
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

## **الأسئلة الشائعة**

**لماذا تم حذف System.Drawing.Graphics؟**

يتم إزالة الدعم لـ `Graphics` من الواجهة العامة لتوحيد العمل مع العرض والصور، وإلغاء الارتباط بالاعتماديات الخاصة بالنظام، والانتقال إلى نهج متعدد المنصات باستخدام [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/). سيتم حذف جميع طرق العرض إلى `Graphics`.

**ما الفائدة العملية من IImage مقارنةً بـ Image/Bitmap؟**

[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) يوحد العمل مع الصور النقطية والمتجهة، يبسط حفظها بصيغ متعددة عبر [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/)، يقلل الاعتماد على `System.Drawing`، ويجعل الشفرة أكثر قابلية للنقل بين البيئات.

**هل ستؤثر الواجهة الحديثة على أداء إنشاء الصور المصغرة؟**

التحول من `GetThumbnail` إلى `GetImage` لا يسبب تدهورًا في السيناريوهات: الطرق الجديدة توفر نفس القدرات لإنتاج الصور مع الخيارات والأحجام، مع الحفاظ على دعم خيارات العرض. الفائدة أو الخسارة المحددة تعتمد على السيناريو، لكن الاستبدالات وظيفيًا متكافئة.
