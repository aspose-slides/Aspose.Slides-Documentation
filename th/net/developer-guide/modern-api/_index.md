---
title: เพิ่มประสิทธิภาพการประมวลผลภาพด้วย Modern API
linktitle: Modern API
type: docs
weight: 234
url: /th/net/modern-api/
keywords:
- System.Drawing
- API สมัยใหม่
- การวาด
- ภาพย่อสไลด์
- สไลด์เป็นภาพ
- ภาพย่อรูปร่าง
- รูปร่างเป็นภาพ
- ภาพย่อการนำเสนอ
- การนำเสนอเป็นภาพ
- เพิ่มภาพ
- เพิ่มรูปภาพ
- .NET
- C#
- Aspose.Slides
description: "ทำให้การประมวลผลภาพสไลด์เป็นสมัยใหม่โดยการแทนที่ API การจัดการภาพที่เลิกใช้ด้วย .NET Modern API เพื่อการอัตโนมัติ PowerPoint และ OpenDocument อย่างราบรื่น."
---
## **บทนำ**

โดยประวัติศาสตร์ Aspose Slides มีการพึ่งพา System.Drawing และมีคลาสต่อไปนี้ใน API สาธารณะ:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

ตั้งแต่เวอร์ชัน 24.4 API สาธารณะนี้ถูกประกาศว่าเลิกใช้แล้ว

เนื่องจากการสนับสนุน System.Drawing ในเวอร์ชัน .NET6 ขึ้นไปถูกลบออกสำหรับแพลตฟอร์มที่ไม่ใช่ Windows ([การเปลี่ยนแปลงที่ทำให้แตก](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)) Slides จึงได้ใช้แนวทางสองแพคเกจ:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) - รองรับ .NET6+ สำหรับ Windows, .NETStandard สำหรับ Windows/Linux/MacOS, .NETFramework 2+ (Windows)  
  - มีการพึ่งพา [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) - เวอร์ชัน Windows/Linux/MacOS ที่ไม่มีการพึ่งพา

ข้อเสียของ [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) คือมันได้ทำการสร้าง System.Drawing เวอร์ชันของตนเองในเนมสเปซเดียวกัน (เพื่อรองรับความเข้ากันได้ย้อนกลับกับ API สาธารณะ) ดังนั้นเมื่อใช้ Aspose.Slides.NET6.CrossPlatform ร่วมกับ System.Drawing จาก .NET Framework หรือแพคเกจ System.Drawing.Common พร้อมกัน จะเกิดความขัดแย้งของชื่อเว้นแต่จะใช้ alias

เพื่อขจัดการพึ่งพา System.Drawing ในแพคเกจหลัก Aspose.Slides.NET เราได้เพิ่มสิ่งที่เรียกว่า “Modern API” — คือ API ที่ควรใช้แทนที่ API ที่เลิกใช้ ซึ่งลายเซ็นของมันมีการพึ่งพาแบบต่อไปนี้จาก System.Drawing: [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) และ [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap) ส่วน [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) และ [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) ถูกประกาศว่าเลิกใช้และการสนับสนุนของมันได้ถูกลบออกจาก API สาธารณะของ Slides

ในเวอร์ชันปัจจุบัน ให้ถือ API สาธารณะที่พึ่งพา System.Drawing เป็นรุ่นเก่า/เลิกใช้ ใช้ Modern API สำหรับโค้ดใหม่และเมื่อย้ายเวิร์กโฟลว์การประมวลผลภาพที่มีอยู่

## **API สมัยใหม่**

เพิ่มคลาสและอีนัมต่อไปนี้เข้าไปใน API สาธารณะ:

- [Aspose.Slides.IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) – แสดงภาพแบบแรสเตอร์หรือเวกเตอร์
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) – แสดงรูปแบบไฟล์ของภาพ
- [Aspose.Slides.Images](https://reference.aspose.com/slides/net/aspose.slides/images/) – เมธอดเพื่อสร้างและทำงานกับอินเทอร์เฟซ [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/)

โปรดทราบว่า [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) เป็นวัตถุที่ต้องทำลาย (implements [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) และควรใช้ภายใน `using` หรือทำลายในวิธีที่สะดวกอื่น)

ใช้ `GetImage` เพื่อเรนเดอร์สไลด์หรือรูปร่างเดียว ใช้ `GetImages` เพื่อเรนเดอร์หลายสไลด์ในงานนำเสนอ ใช้เมธอดจาก [Images](https://reference.aspose.com/slides/net/aspose.slides/images/) เพื่อโหลดภาพ, `AddImage` พร้อม [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) เพื่อเพิ่มภาพลงในงานนำเสนอ, และ `ReplaceImage` พร้อม [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) เพื่ออัปเดตภาพในงานนำเสนอที่มีอยู่

สถานการณ์ทั่วไปของการใช้ API ใหม่อาจเป็นดังต่อไปนี้:

``` csharp
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // สร้างอินสแตนซ์ IImage ที่สามารถทำลายได้จากไฟล์บนดิสก์.  
    using (IImage image = Images.FromFile("image.png"))
    {
        // สร้างภาพ PowerPoint โดยเพิ่มอินสแตนซ์ของ IImage ไปยังคอลเลกชันภาพของงานนำเสนอ.
        ppImage = pres.Images.AddImage(image);
    }

    // เพิ่มรูปร่างรูปภาพบนสไลด์ที่ 1
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // รับอินสแตนซ์ของ IImage ที่แทนสไลด์ที่ 1.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // บันทึกภาพลงบนดิสก์.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## **การแทนที่โค้ดเก่าด้วย Modern API**

เพื่อความสะดวกในการเปลี่ยนแปลง อินเทอร์เฟซของ [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) ใหม่ทำซ้ำลายเซ็นของคลาส [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) และ [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap) โดยทั่วไป คุณเพียงแค่ต้องแทนที่การเรียกเมธอดเก่าที่ใช้ System.Drawing ด้วยเมธอดใหม่

### **การรับ Thumbnail ของสไลด์**

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

### **การรับ Thumbnail ของรูปร่าง**

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

### **การรับ Thumbnail ของงานนำเสนอ**

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

### **การเพิ่มรูปภาพลงในงานนำเสนอ**

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

## **เมธอด/คุณสมบัติที่เลิกใช้และการแทนที่ใน Modern API**

### **Presentation**
| ลายเซ็นเมธอด | ลายเซ็นเมธอดทดแทน |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | ไม่มีการแทนที่ใน Modern API |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | ไม่มีการแทนที่ใน Modern API |
| public void Print() | ไม่มีการแทนที่ใน Modern API |
| public void Print(PrinterSettings printerSettings) | ไม่มีการแทนที่ใน Modern API |
| public void Print(string printerName) | ไม่มีการแทนที่ใน Modern API |
| public void Print(PrinterSettings printerSettings, string presName) | ไม่มีการแทนที่ใน Modern API |

### **Shape**
| ลายเซ็นเมธอด | ลายเซ็นเมธอดทดแทน |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| ลายเซ็นเมธอด | ลายเซ็นเมธอดทดแทน |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY) | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options) | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize) | [GetImage(Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options) | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | ไม่มีการแทนที่ใน Modern API |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | ไม่มีการแทนที่ใน Modern API |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | ไม่มีการแทนที่ใน Modern API |

### **Output**
| ลายเซ็นเมธอด | ลายเซ็นเมธอดทดแทน |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| ลายเซ็นเมธอด | ลายเซ็นเมธอดทดแทน |
|-------------------------------------------|--------------------------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| ลายเซ็นเมธอด | ลายเซ็นเมธอดทดแทน |
|----------------------------------------------------------|---------------------------------------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| ลายเซ็นเมธอด/คุณสมบัติ | ลายเซ็นเมธอดทดแทน |
|--------------------------------------|-----------------------------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| ลายเซ็นเมธอด | ลายเซ็นเมธอดทดแทน |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| ลายเซ็นเมธอด | ลายเซ็นเมธอดทดแทน |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **การสนับสนุน Graphics และ PrinterSettings ใน API**

คลาส [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) ไม่รองรับสำหรับเวอร์ชันครอสแพลตฟอร์มของ .NET6 ขึ้นไป ใน Aspose Slides ให้ใช้เมธอดเรนเดอร์ภาพของ Modern API แทน API ที่เรนเดอร์ไปยัง [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics):
[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

เช่นเดียวกัน API ที่เกี่ยวกับการพิมพ์ผ่าน [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) ไม่มีการแทนที่โดยตรงใน Modern API:

[IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)

## **คำถามที่พบบ่อย**

### ทำไมจึงตัดการใช้ [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)?

การสนับสนุน [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) ถูกเลิกใช้ใน API สาธารณะเพื่อทำให้การทำงานกับการเรนเดอร์และภาพเป็นเอกภาพ ลดการพึ่งพาแพลตฟอร์มเฉพาะ และเปลี่ยนไปใช้แนวทางครอสแพลตฟอร์มกับ [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) ใช้ `GetImage` หรือ `GetImages` แทนการเรนเดอร์ไปยัง [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics).

### มีประโยชน์เชิงปฏิบัติอย่างไรของ [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) เมื่อเทียบกับ [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)/[Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)?

[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) ทำให้การทำงานกับภาพ raster และ vector เป็นอันหนึ่งอันเดียว, ทำให้การบันทึกเป็นรูปแบบต่าง ๆ ง่ายขึ้นผ่าน [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/), ลดการพึ่งพา `System.Drawing`, และทำให้โค้ดพกพาได้ดีขึ้นในสภาพแวดล้อมต่าง ๆ.

### Modern API จะมีผลต่อประสิทธิภาพการสร้าง thumbnail หรือไม่?

การสลับจาก `GetThumbnail` ไปเป็น `GetImage` ไม่ทำให้สถานการณ์แย่ลง: เมธอดใหม่ให้ความสามารถเดียวกันในการสร้างภาพพร้อมตัวเลือกและขนาดต่าง ๆ พร้อมยังคงสนับสนุนตัวเลือกการเรนเดอร์ ผลลัพธ์ที่ดีหรือแย่ขึ้นขึ้นกับกรณีการใช้งาน แต่โดยฟังก์ชันการทำงานแล้ว การแทนที่เป็นแบบเทียบเท่ากัน.