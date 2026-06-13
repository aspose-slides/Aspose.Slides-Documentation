---
title: เพิ่มประสิทธิภาพการประมวลผลภาพด้วย Modern API
linktitle: API สมัยใหม่
type: docs
weight: 237
url: /th/net/modern-api/
keywords:
- System.Drawing
- API สมัยใหม่
- การวาด
- ภาพย่อสไลด์
- สไลด์เป็นภาพ
- ภาพย่อรูปทรง
- รูปทรงเป็นภาพ
- ภาพย่อการนำเสนอ
- การนำเสนอเป็นภาพ
- เพิ่มภาพ
- เพิ่มรูปภาพ
- .NET
- C#
- Aspose.Slides
description: "ปรับสมัยการประมวลผลภาพสไลด์โดยแทนที่ API การทำภาพที่เลิกใช้ด้วย .NET Modern API เพื่อการอัตโนมัติ PowerPoint และ OpenDocument อย่างราบรื่น."
---
## **บทนำ**

โดยประวัติแล้ว Aspose Slides มีการพึ่งพา System.Drawing และใน API สาธารณะมีคลาสต่อไปนี้จาก System.Drawing:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

ตั้งแต่เวอร์ชัน 24.4 API สาธารณะนี้ถูกประกาศว่าเลิกใช้แล้ว

เนื่องจากการสนับสนุน System.Drawing ใน .NET 6 ขึ้นไปถูกลบสำหรับระบบที่ไม่ใช่ Windows ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only))  Slides จึงได้นำแนวทางแบบสองแพ็กเกจมาใช้:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) – รองรับ .NET 6+ สำหรับ Windows, .NETStandard สำหรับ Windows/Linux/macOS, .NETFramework 2+ (Windows) โดยมีการพึ่งพา [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/)  
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) – เวอร์ชัน Windows/Linux/macOS ที่ไม่มีการพึ่งพาใด ๆ

ความไม่สะดวกของ [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) คือมันได้ทำการจำลอง System.Drawing ของตัวเองใน namespace เดียวกัน (เพื่อสนับสนุนความเข้ากันได้ย้อนหลังกับ API สาธารณะ) ดังนั้นเมื่อใช้ Aspose.Slides.NET6.CrossPlatform ร่วมกับ System.Drawing จาก .NET Framework หรือแพ็กเกจ System.Drawing.Common พร้อมกัน จะเกิดการชนกันของชื่อเว้นแต่จะใช้ alias

เพื่อกำจัดการพึ่งพา System.Drawing ในแพ็กเกจหลัก Aspose.Slides.NET เราได้เพิ่ม “Modern API” – คือ API ที่ควรใช้แทน API ที่เลิกใช้ ซึ่งลายเซ็นของมันมีการพึ่งพา type ต่อไปนี้จาก System.Drawing: [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) และ [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)  ส่วน [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) และ [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) ถูกประกาศว่าเลิกใช้และการสนับสนุนถูกลบออกจาก API สาธารณะของ Slides

ในเวอร์ชันปัจจุบัน ให้ถือว่า API สาธารณะที่พึ่งพา System.Drawing เป็นแบบ legacy/เลิกใช้ ใช้ Modern API สำหรับโค้ดใหม่และเมื่อย้าย workflow การประมวลผลภาพที่มีอยู่

## **Modern API**

เพิ่มคลาสและ enum ต่อไปนี้เข้าสู่ API สาธารณะ:

- [Aspose.Slides.IImage](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/) – แสดงถึงภาพแบบ raster หรือ vector
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/th/net/aspose.slides/imageformat/) – แสดงรูปแบบไฟล์ของภาพ
- [Aspose.Slides.Images](https://reference.aspose.com/slides/th/net/aspose.slides/images/) – วิธีการสร้างและทำงานกับอินเตอร์เฟส [IImage](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/)

โปรดทราบว่า [IImage](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/) สามารถทำการกำจัด (dispose) ได้ (มัน implements อินเตอร์เฟส [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) และควรใช้ภายใน `using` หรือทำการกำจัดด้วยวิธีอื่นที่เหมาะสม)

ใช้ `GetImage` เพื่อเรนเดอร์สไลด์หรือรูปทรงเดียว ใช้ `GetImages` เพื่อเรนเดอร์หลายสไลด์ของงานนำเสนอ  ใช้เมธอดของ [Images](https://reference.aspose.com/slides/th/net/aspose.slides/images/) เพื่อโหลดภาพ, `AddImage` พร้อมกับ [IImage](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/) เพื่อเพิ่มภาพลงในงานนำเสนอ, และ `ReplaceImage` พร้อมกับ [IImage](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/) เพื่ออัปเดตภาพที่มีอยู่ในงานนำเสนอ

ตัวอย่างสถานการณ์การใช้ API ใหม่อาจมีลักษณะดังนี้:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // สร้างอินสแตนซ์ที่กำจัดได้ของ IImage จากไฟล์บนดิสก์.  
    using (IImage image = Images.FromFile("image.png"))
    {
        // สร้างภาพ PowerPoint โดยเพิ่มอินสแตนซ์ของ IImage ไปยังคอลเลกชันภาพของการนำเสนอ.
        ppImage = pres.Images.AddImage(image);
    }

    // เพิ่มรูปร่างรูปภาพบนสไลด์ #1
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // รับอินสแตนซ์ของ IImage ที่แสดงสไลด์ #1.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // บันทึกภาพลงบนดิสก์.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## **การแทนที่โค้ดเก่าด้วย Modern API**

เพื่ออำนวยความสะดวกในการเปลี่ยนแปลง อินเทอร์เฟสของ [IImage](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/) จะทำซ้ำลายเซ็นแยกของคลาส [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) และ [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap) โดยทั่วไป คุณเพียงแค่ต้องแทนที่การเรียกเมธอดเก่าที่ใช้ System.Drawing ด้วยเมธอดใหม่

### **การสร้าง Thumbnail ของสไลด์**

API Legacy/เลิกใช้:

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

### **การสร้าง Thumbnail ของรูปทรง**

API Legacy/เลิกใช้:

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

### **การสร้าง Thumbnail ของงานนำเสนอ**

API Legacy/เลิกใช้:

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

### **การเพิ่มรูปภาพลงในงานนำเสนอ**

API Legacy/เลิกใช้:

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

## **เมธอด/คุณสมบัติที่เลิกใช้และการแทนที่ใน Modern API**

### **Presentation**
| ลายเซ็นเมธอด | ลายเซ็นเมธอดทดแทน |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Print() | No Modern API replacement |
| public void Print(PrinterSettings printerSettings) | No Modern API replacement |
| public void Print(string printerName) | No Modern API replacement |
| public void Print(PrinterSettings printerSettings, string presName) | No Modern API replacement |

### **Shape**
| ลายเซ็นเมธอด | ลายเซ็นเมธอดทดแทน |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/th/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/th/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| ลายเซ็นเมธอด | ลายเซ็นเมธอดทดแทน |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY) | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/th/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/th/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options) | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/th/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize) | [GetImage(Size imageSize)](https://reference.aspose.com/slides/th/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options) | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/th/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/th/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/th/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | No Modern API replacement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | No Modern API replacement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | No Modern API replacement |

### **Output**
| ลายเซ็นเมธอด | ลายเซ็นเมธอดทดแทน |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/th/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| ลายเซ็นเมธอด | ลายเซ็นเมธอดทดแทน |
|-------------------------------------------|--------------------------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/th/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| ลายเซ็นเมธอด | ลายเซ็นเมธอดทดแทน |
|----------------------------------------------------------|---------------------------------------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/th/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| ลายเซ็นเมธอด/คุณสมบัติ | ลายเซ็นเมธอดทดแทน |
|---------------------------|-----------------------------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/th/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/th/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| ลายเซ็นเมธอด | ลายเซ็นเมธอดทดแทน |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/th/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/th/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| ลายเซ็นเมธอด | ลายเซ็นเมธอดทดแทน |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/th/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **การสนับสนุน API สำหรับ Graphics และ PrinterSettings**

คลาส [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) ไม่ได้รับการสนับสนุนสำหรับเวอร์ชันข้ามแพลตฟอร์มของ .NET 6 ขึ้นไป  ใน Aspose Slides ให้ใช้เมธอดการเรนเดอร์ภาพของ Modern API แทน API ที่เรนเดอร์ไปยัง [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics):
[ISlide](https://reference.aspose.com/slides/th/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/th/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/th/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/th/net/aspose.slides/slide/rendertographics/#rendertographics_5)

เช่นเดียวกัน API ที่เกี่ยวข้องกับการพิมพ์ผ่าน [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) ไม่มีการแทนที่โดย Modern API โดยตรง:

[IPresentation](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/print/#print_2)

## **FAQ**

**ทำไมถึงตัดการสนับสนุน [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) ลง?**

การสนับสนุน [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) ถูกเลิกใช้ใน API สาธารณะเพื่อทำให้การทำงานกับการเรนเดอร์และภาพเป็นแบบเดียวกัน ลดการพึ่งพาแพลตฟอร์มเฉพาะ และเปลี่ยนไปใช้แนวทางข้ามแพลตฟอร์มด้วย [IImage](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/) แทน ให้ใช้ `GetImage` หรือ `GetImages` แทนการเรนเดอร์ไปยัง [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)

**IImage มีประโยชน์เชิงปฏิบัติอย่างไรเมื่อเทียบกับ Image/Bitmap?**

[IImage](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/) ทำให้การทำงานกับภาพ raster และ vector เป็นหนึ่งเดียว, ทำให้การบันทึกเป็นหลายรูปแบบผ่าน [ImageFormat](https://reference.aspose.com/slides/th/net/aspose.slides/imageformat/) ง่ายขึ้น, ลดการพึ่งพา `System.Drawing`, และทำให้โค้ดพกพาได้ดีขึ้นในสภาพแวดล้อมต่าง ๆ

**Modern API จะส่งผลต่อประสิทธิภาพการสร้าง thumbnail หรือไม่?**

การเปลี่ยนจาก `GetThumbnail` ไปเป็น `GetImage` ไม่ทำให้สถานการณ์แย่ลง: เมธอดใหม่ให้ความสามารถเช่นเดียวกันสำหรับการสร้างภาพพร้อมตัวเลือกและขนาดต่าง ๆ พร้อมยังคงรองรับตัวเลือกการเรนเดอร์ ผลลัพธ์ที่เร็วหรือช้าจะขึ้นอยู่กับกรณีใช้ แต่โดยหลักการการแทนที่เป็นเทียบเท่ากัน