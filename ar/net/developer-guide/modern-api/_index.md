---
title: API الحديثة
type: docs
weight: 237
url: /ar/net/modern-api/
keywords: "CrossPlatform API الحديثة System.Drawing"
description: "API الحديثة"
---

## **المقدمة**

تاريخيًا، يعتمد Aspose Slides على System.Drawing ويحتوي في الـ API العام على الفئات التالية من هناك:
- [رسومات](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [صورة](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [صورة نقطية](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [إعدادات الطابعة](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

اعتبارًا من الإصدار 24.4، تم إعلان أن هذا الـ API العام مهمل.

نظرًا لأن دعم System.Drawing في الإصدارات .NET6 وما فوق تم إزالته للإصدارات غير الويندوز ([تغيّر كبير](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only))، اتبع Aspose Slides نهجًا يتضمن مكتبتين:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) – يدعم .NET6+ للويندوز، .NETStandard للويندوز/لينكس/ماك OS، .NETFramework 2+ (ويندوز).  
  - يعتمد على [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) – إصدار للويندوز/لينكس/ماك OS بدون تبعيات.

العيب في [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) هو أنه ينفذ نسخته الخاصة من System.Drawing في نفس النطاق (لدعم التوافق العكسي مع الـ API العام). لذا، عند استخدام Aspose.Slides.NET6.CrossPlatform وSystem.Drawing من .NETFramework أو حزمة System.Drawing.Common في نفس الوقت، يحدث تعارض بالأسماء ما لم يُستخدم alias.

من أجل التخلص من التبعيات على System.Drawing في حزمة Aspose.Slides.NET الرئيسية، أضفنا ما يُسمى بـ "الـ API الحديث" – أي الـ API الذي يجب استخدامه بدلًا من الـ API المهمل، والتي تُظهر توقيعات تعتمد على الأنواع التالية من System.Drawing: Image و Bitmap. تُعلن عن إهمال PrinterSettings و Graphics وتم إزالة دعمهما من الـ API العام لـ Slides.

سيتم إزالة الـ API العام المهمل الذي يعتمد على System.Drawing في الإصدار 24.8.

## **الـ API الحديث**

أُضيفت الفئات والتعدادات التالية إلى الـ API العام:

- Aspose.Slides.IImage – تمثّل الصورة النقطية أو المتجهة.  
- Aspose.Slides.ImageFormat – تمثّل تنسيق ملف الصورة.  
- Aspose.Slides.Images – طرق لإنشاء والعمل مع واجهة IImage.

يرجى ملاحظة أن IImage قابل للتصرف (يمتد من واجهة IDisposable ويجب اعتماد ‎using‎ أو إلغاءه بطريقة مناسبة).

سيناريو نموذجي لاستخدام الـ API الجديد قد يبدو كما يلي:
``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // إنشاء نسخة قابلة للتصريف من IImage من الملف الموجود على القرص.  
    using (IImage image = Images.FromFile("image.png"))
    {
        // إنشاء صورة PowerPoint عن طريق إضافة نسخة من IImage إلى صور العرض التقديمي.
        ppImage = pres.Images.AddImage(image);
    }

    // إضافة شكل صورة على الشريحة #1
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // الحصول على نسخة من IImage تمثل الشريحة #1.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // حفظ الصورة على القرص.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```


## **استبدال الكود القديم بالـ API الحديث**

للتسهيل أثناء الانتقال، تُعيد واجهة IImage الجديدة تكرار التواقيع المنفصلة لفئتي Image و Bitmap. بوجه عام، كل ما عليك هو استبدال استدعاء الطريقة القديمة التي تستخدم System.Drawing بالجديد.

### **الحصول على صورة مصغرة للشفرة**

الكود باستخدام الـ API المهمل:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```


الـ API الحديث:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```


### **الحصول على صورة مصغرة للشكل**

الكود باستخدام الـ API المهمل:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```


الـ API الحديث:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```


### **الحصول على صورة مصغرة للعرض التقديمي**

الكود باستخدام الـ API المهمل:
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


الـ API الحديث:
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

الكود باستخدام الـ API المهمل:
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


الـ API الحديث:
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


## **الطرق/الخصائص التي ستُزال واستبدالها في الـ API الحديث**

### **Presentation**
| توقيع الطريقة | توقيع الطريقة البديلة |
|---------------|----------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)]() |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | سيتم حذفها تمامًا |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | سيتم حذفها تمامًا |
| public void Print() | سيتم حذفها تمامًا |
| public void Print(PrinterSettings printerSettings) | سيتم حذفها تمامًا |
| public void Print(string printerName) | سيتم حذفها تمامًا |
| public void Print(PrinterSettings printerSettings, string presName) | سيتم حذفها تمامًا |

### **Shape**
| توقيع الطريقة | توقيع الطريقة البديلة |
|---------------|----------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| توقيع الطريقة | توقيع الطريقة البديلة |
|---------------|----------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY) | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options) | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize) | [GetImage(Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options) | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | سيتم حذفها تمامًا |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | سيتم حذفها تمامًا |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | سيتم حذفها تمامًا |

### **Output**
| توقيع الطريقة | توقيع الطريقة البديلة |
|---------------|----------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| توقيع الطريقة | توقيع الطريقة البديلة |
|---------------|----------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| توقيع الطريقة | توقيع الطريقة البديلة |
|---------------|----------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| توقيع/خاصية الطريقة | توقيع الطريقة البديلة |
|---------------------|----------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| توقيع الطريقة | توقيع الطريقة البديلة |
|---------------|----------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| توقيع الطريقة | توقيع الطريقة البديلة |
|---------------|----------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **ستتوقف دعم Graphics و PrinterSettings في الـ API**

فئة [رسومات](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) غير مدعومة للإصدارات المتعددة المنصات من .NET6 وما فوق. في Aspose Slides، سيتم إزالة الجزء المتعلق بها من الـ API:
[Slide](https://reference.aspose.com/slides/net/aspose.slides/slide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

كما سيتم إزالة الجزء المتعلق بالطباعة من الـ API:

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)

# **الأسئلة المتكررة**

**لماذا تم إلغاء System.Drawing.Graphics؟**

يتم إزالة دعم `Graphics` من الـ API العام لتوحيد العمل مع التصيّر والصور، وإلغاء الاعتماد على تبعيات منصات محددة، والانتقال إلى نهج متعدد المنصات باستخدام [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/). ستُحذف جميع طرق التصيّر إلى `Graphics`.

**ما الفائدة العملية من IImage مقارنةً بـ Image/Bitmap؟**

يُوحّد [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) العمل مع الصور النقطية والمتجهة، يبسط الحفظ إلى تنسيقات متعددة عبر [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/)، يقلل الاعتماد على `System.Drawing`، ويجعل الكود أكثر قابلية للنقل بين البيئات.

**هل سيؤثر الـ API الحديث على أداء إنشاء الصور المصغرة؟**

التحول من `GetThumbnail` إلى `GetImage` لا يضعف السيناريوهات: توفر الطرق الجديدة نفس الإمكانات لإنتاج الصور مع خيارات وأحجام مختلفة، مع الحفاظ على دعم خيارات التصيّر. الفائدة أو الخسارة المحددة تعتمد على السيناريو، لكن الاستبدالات متكافئة وظيفيًا.