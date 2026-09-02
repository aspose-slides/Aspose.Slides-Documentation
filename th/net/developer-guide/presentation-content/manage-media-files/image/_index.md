---
title: เพิ่มประสิทธิภาพการจัดการภาพในงานนำเสนอด้วย .NET
linktitle: จัดการภาพ
type: docs
weight: 10
url: /th/net/image/
keywords:
- เพิ่มภาพ
- เพิ่มรูปภาพ
- เพิ่มบิตแมพ
- แทนที่ภาพ
- แทนที่รูปภาพ
- จากเว็บ
- พื้นหลัง
- เพิ่ม PNG
- เพิ่ม JPG
- เพิ่ม SVG
- ทรัพยากร SVG ภายนอก
- ตัวแก้ไข SVG
- ภาพ SVG ที่เชื่อมโยง
- ฟอนต์ SVG
- เพิ่ม EMF
- เพิ่ม WMF
- เพิ่ม TIFF
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ทำให้การจัดการภาพใน PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ .NET เป็นกระบวนการที่ราบรื่น เพิ่มประสิทธิภาพการทำงานและอัตโนมัติกระบวนการของคุณ."
---
## **บทนำ**

ภาพทำให้การนำเสนอมีความน่าสนใจและดึงดูดสายตามากขึ้น ใน Microsoft PowerPoint คุณสามารถแทรกรูปภาพลงในสไลด์จากไฟล์ อินเทอร์เน็ต หรือแหล่งอื่น ๆ เช่นเดียวกับ Aspose.Slides ที่อนุญาตให้คุณเพิ่มภาพลงในสไลด์การนำเสนอได้หลายวิธี

{{% alert  title="Tip" color="primary" %}} 
Aspose มีตัวแปลงฟรี—[JPEG to PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG to PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt)—ที่ช่วยให้คุณสร้างการนำเสนอจากภาพได้อย่างรวดเร็ว. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
หากคุณต้องการเพิ่มภาพเป็นกรอบรูป—โดยเฉพาะอย่างยิ่งหากคุณวางแผนที่จะปรับขนาด ใส่เอฟเฟกต์ หรือใช้ตัวเลือกการจัดรูปแบบมาตรฐานอื่น ๆ—ดูที่ [Picture Frame](/slides/th/net/picture-frame/). 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
คุณสามารถแปลงภาพจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่ง ดูหน้าต่อไปนี้: แปลง [image to JPG](https://products.aspose.com/slides/th/net/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/th/net/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/th/net/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/th/net/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/th/net/conversion/png-to-svg/), และ [SVG to PNG](https://products.aspose.com/slides/th/net/conversion/svg-to-png/). 
{{% /alert %}}

Aspose.Slides รองรับภาพในรูปแบบที่นิยม เช่น JPEG, PNG, BMP, GIF และอื่น ๆ. 

## **เพิ่มภาพที่เก็บไว้ในเครื่องลงสไลด์**

คุณสามารถเพิ่มภาพหนึ่งหรือหลายภาพที่เก็บไว้บนคอมพิวเตอร์ของคุณลงในสไลด์การนำเสนอ ตัวอย่างโค้ด C# ด้านล่างแสดงวิธีการเพิ่มภาพลงในสไลด์:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **เพิ่มภาพจากเว็บลงสไลด์**

หากภาพที่คุณต้องการเพิ่มลงสไลด์ไม่ได้เก็บไว้บนคอมพิวเตอร์ของคุณ คุณสามารถเพิ่มมันโดยตรงจากเว็บได้.

ตัวอย่างโค้ด C# ด้านล่างแสดงวิธีการเพิ่มภาพจากเว็บลงในสไลด์:

```c#
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **เพิ่มภาพลงใน Slide Master**

Slide Master จัดเก็บและควบคุมข้อมูลเช่นธีมและเค้าโครงสำหรับสไลด์ที่ใช้มัน เมื่อคุณเพิ่มภาพลงใน Slide Master ภาพจะปรากฏบนทุกสไลด์ที่อิงจากมาสเตอร์นั้น.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **เพิ่มภาพเป็นพื้นหลังสไลด์**

คุณสามารถใช้รูปภาพเป็นพื้นหลังสำหรับหนึ่งหรือหลายสไลด์ สำหรับรายละเอียดดู *[Setting Images as Backgrounds for Slides](/slides/th/net/presentation-background/#setting-images-as-background-for-slides)*.

## **เพิ่ม SVG ในการนำเสนอ**

คุณสามารถเพิ่มเนื้อหา SVG ไปยังการนำเสนอได้โดยใช้คลาส [SvgImage](https://reference.aspose.com/slides/th/net/aspose.slides/svgimage/) วัตถุ [ISvgImage](https://reference.aspose.com/slides/th/net/aspose.slides/isvgimage/) ที่ได้สามารถเพิ่มลงในคอลเลกชันภาพของการนำเสนอและใช้สร้างกรอบรูปได้.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string svgContent = @"
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>";

using (Presentation presentation = new Presentation())
{
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("self-contained-svg.pptx", SaveFormat.Pptx);
}
```

## **นำเข้าเนื้อหา SVG พร้อมทรัพยากรภายนอก**

ไฟล์ SVG ที่ส่งออกจากเครื่องมือออกแบบ โปรแกรมแก้ไขแผนภาพ ระบบไอคอน หรือ pipeline บนเว็บอาจอ้างอิงทรัพยากรที่เก็บอยู่นอกเอกสาร SVG ตัวอย่างเช่น SVG อาจมีลิงก์ภาพเช่น `images/photo.png` ค่า CSS `url(...)` หรือ URL ของฟอนต์.

เพื่อจะนำเข้าเนื้อหา SVG แบบนี้ ให้สร้างการนำไปใช้ของ [IExternalResourceResolver](https://reference.aspose.com/slides/th/net/aspose.slides.import/iexternalresourceresolver/) แล้วส่งผ่านร่วมกับ base URI ไปยังคอนสตรัคเตอร์ `SvgImage` ที่เหมาะสม base URI ระบุตำแหน่งของเอกสาร SVG และใช้ในการแก้ลิงก์แบบ relative.

อินเทอร์เฟซ [ISvgImage](https://reference.aspose.com/slides/th/net/aspose.slides/isvgimage/) ให้การเข้าถึงข้อมูลเกี่ยวกับ SVG ที่นำเข้า:

- `SvgContent` ส่งกลับ markup ของ SVG เป็นสตริง.
- `SvgData` ส่งกลับเนื้อหา SVG เป็นอาร์เรย์ของไบต์.
- `BaseUri` ส่งกลับ base URI ที่ใช้สำหรับลิงก์แบบ relative.
- `ExternalResourceResolver` ส่งกลับ resolver ที่กำหนดให้กับภาพ SVG.

### **ดำเนินการสร้าง External Resource Resolver**

Resolver มีสองเมธอด:

- [ResolveUri](https://reference.aspose.com/slides/th/net/aspose.slides.import/iexternalresourceresolver/resolveuri/) รวม base URI และลิงก์ทรัพยากรแบบ relative แล้วส่งกลับ URI แบบ absolute. คืนค่า `null` เมื่อไม่สามารถแก้ลิงก์หรือไม่ได้รับอนุญาต.
- [GetEntity](https://reference.aspose.com/slides/th/net/aspose.slides.import/iexternalresourceresolver/getentity/) ส่งกลับสตรีมที่อ่านได้สำหรับ URI ของทรัพยากรแบบ absolute. คืนค่า `null` เมื่อทรัพยากรหาย บล็อก หรือไม่สามารถเข้าถึงได้. สามารถคืนสตรีมสำรองได้เมื่อเหมาะสม.

Resolver ด้านล่างโหลดทรัพยากรที่เชื่อมโยงเฉพาะจากไดเรกทอรีในที่อนุญาตเท่านั้น ทรัพยากรเครือข่ายและเส้นทางนอกไดเรกทอรีที่อนุญาตจะถูกบล็อก ภาพสำรองแบบเลือกได้จะถูกคืนค่าเมื่อไม่สามารถแก้ลิงก์ภาพได้.

```csharp
using System;
using System.IO;
using Aspose.Slides.Import;

internal sealed class LocalSvgResourceResolver : IExternalResourceResolver
{
    private readonly string _allowedRoot;
    private readonly byte[] _fallbackImageData;

    public LocalSvgResourceResolver(string allowedRoot, byte[] fallbackImageData = null)
    {
        _allowedRoot = Path.GetFullPath(allowedRoot);
        _fallbackImageData = fallbackImageData;
    }

    public string ResolveUri(string baseUri, string relativeUri)
    {
        if (string.IsNullOrWhiteSpace(baseUri) ||
            string.IsNullOrWhiteSpace(relativeUri))
        {
            return null;
        }

        if (!Uri.TryCreate(baseUri, UriKind.Absolute, out Uri baseAddress) ||
            !Uri.TryCreate(baseAddress, relativeUri, out Uri absoluteAddress))
        {
            return null;
        }

        // ตัว resolver นี้โดยเจตนาให้อนุญาตเฉพาะไฟล์ในเครื่องเท่านั้น.
        if (!absoluteAddress.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(absoluteAddress.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        return absoluteAddress.AbsoluteUri;
    }

    public Stream GetEntity(string absoluteUri)
    {
        if (!Uri.TryCreate(absoluteUri, UriKind.Absolute, out Uri resourceUri) ||
            !resourceUri.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(resourceUri.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        if (File.Exists(resourcePath))
        {
            return File.OpenRead(resourcePath);
        }

        // ใช้ fallback เฉพาะสำหรับทรัพยากรภาพ การคืนสตรีมภาพ
        // สำหรับฟอนต์หรือสไตล์ชีตที่ขาดหายจะไม่ถูกต้อง.
        if (_fallbackImageData != null && IsImageFile(resourcePath))
        {
            return new MemoryStream(_fallbackImageData, writable: false);
        }

        return null;
    }

    private bool IsInsideAllowedRoot(string resourcePath)
    {
        string normalizedRoot = _allowedRoot.TrimEnd(
            Path.DirectorySeparatorChar,
            Path.AltDirectorySeparatorChar) + Path.DirectorySeparatorChar;

        string normalizedPath = Path.GetFullPath(resourcePath);
        StringComparison comparison = Path.DirectorySeparatorChar == '\\'
            ? StringComparison.OrdinalIgnoreCase
            : StringComparison.Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               string.Equals(normalizedPath, _allowedRoot, comparison);
    }

    private static bool IsImageFile(string path)
    {
        string extension = Path.GetExtension(path);

        return extension.Equals(".png", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".gif", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".bmp", StringComparison.OrdinalIgnoreCase);
    }
}
```

### **แก้ปัญหาแหล่งทรัพยากรที่เชื่อมโยงในระหว่างการนำเข้า SVG**

สมมติว่า `assets/diagram.svg` มีการอ้างอิงแบบ relative เช่น:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

ตัวอย่าง C# ด้านล่างส่ง URI ของไฟล์ SVG เป็น base URI และให้ resolver ที่กำหนดเอง Resolver นี้จะแปลงลิงก์ภาพแบบ relative ให้เป็น URI แบบ absolute และส่งกลับสตรีมที่มีทรัพยากรที่เชื่อมโยงขณะ Aspose.Slides ประมวลผล SVG.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

string svgFilePath = Path.GetFullPath(Path.Combine("assets", "diagram.svg"));
string assetDirectory = Path.GetDirectoryName(svgFilePath) ?? Directory.GetCurrentDirectory();
string svgContent = File.ReadAllText(svgFilePath);

// Base URI แสดงตำแหน่งที่ตั้งของเอกสาร SVG.
string baseUri = new Uri(svgFilePath).AbsoluteUri;

byte[] fallbackImageData = null;
string fallbackImagePath = Path.Combine(assetDirectory, "fallback.png");
if (File.Exists(fallbackImagePath))
{
    fallbackImageData = File.ReadAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory, fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage ให้เข้าถึงเนื้อหาต้นฉบับ, ข้อมูลไบต์, Base URI, และ resolver.
string importedContent = svgImage.SvgContent;
byte[] importedData = svgImage.SvgData;
string importedBaseUri = svgImage.BaseUri;
IExternalResourceResolver importedResolver = svgImage.ExternalResourceResolver;

using (Presentation presentation = new Presentation())
{
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
}
```

คลาส `SvgImage` ยังมี overloads ที่รับข้อมูล SVG เป็นอาร์เรย์ของไบต์หรือสตรีม พร้อมกับ external resource resolver และ base URI.

{{% alert title="Important" color="warning" %}}
ตัวแก้ไขทรัพยากรทำให้ทรัพยากรภายนอกพร้อมใช้งานในระหว่างที่ Aspose.Slides ประมวลผลและเรนเดอร์ SVG อย่างไรก็ตามไม่ทำการแก้ไข markup ของ SVG ดั้งเดิมหรือฝังทรัพยากรที่แก้ไขโดยอัตโนมัติ

เมื่อ `ISvgImage` ถูกเพิ่มเข้าไปในคอลเลกชันภาพของการนำเสนอ ไฟล์ PPTX อาจมีทั้งการแทน SVG ดั้งเดิมและภาพ raster สำรอง ภาพที่เชื่อมโยงอาจปรากฏในภาพสำรองที่สร้างขึ้นในขณะที่ลิงก์แบบ relative เช่น `images/photo.png` ยังคงไม่เปลี่ยนแปลงใน SVG ที่เก็บไว้ โปรแกรมที่เรนเดอร์การแทน SVG ดั้งเดิมจึงอาจละเว้นเนื้อหาที่เชื่อมโยงเมื่อทรัพยากรภายนอกต้นฉบับไม่สามารถเข้าถึงได้.
{{% /alert %}}

### **สร้างภาพ SVG ที่พกพาได้**

เพื่อสร้างภาพ SVG ที่ไม่พึ่งพาไฟล์ภายนอก ทำให้ SVG เป็นอิสระก่อนสร้าง `SvgImage` ตัวอย่างเช่น แทนที่ URL ของภาพที่เชื่อมโยงด้วย URI `data:` ที่มีข้อมูลภาพอยู่:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

หลังจากฝังทรัพยากรที่จำเป็นทั้งหมดลงในเนื้อหา SVG แล้ว ให้สร้าง `SvgImage` เพิ่มลงในคอลเลกชันภาพของการนำเสนอ และแทรกเข้าไปในกรอบรูปตามตัวอย่างก่อนหน้า.

### **จัดการกับทรัพยากรที่หายไปหรือถูกบล็อก**

คืนค่า `null` จาก `ResolveUri` เมื่อ URI ของทรัพยากรไม่ถูกต้อง ถูกห้าม หรือไม่สามารถแก้ได้ คืนค่า `null` จาก `GetEntity` เมื่อไม่สามารถอ่านทรัพยากรได้ Aspose.Slides จะดำเนินการประมวลผล SVG ต่อไปโดยไม่มีทรัพยากรนั้น หากทำได้

สตรีมสำรองสามารถคืนค่าได้สำหรับทรัพยากรที่หายไป แต่เนื้อหาต้องเข้ากันได้กับประเภททรัพยากรที่ร้องขอ ตัวอย่างเช่น คืนสตรีมภาพเฉพาะสำหรับภาพที่หายไป ไม่ใช่สำหรับฟอนต์หรือสไตล์ชีต

{{% alert title="Security" color="warning" %}}
ห้ามแก้ไขลิงก์ไฟล์โดยสุ่มหรือ URL เครือข่ายไม่จำกัดจากไฟล์ SVG ที่ไม่เชื่อถือได้ จำกัดสคีม ไดเรกทอรี และโฮสต์ที่อนุญาต สำหรับทรัพยากรเครือข่ายควรกำหนด timeout การเชื่อมต่อ ขนาดการตอบกลับ และการตรวจสอบความถูกต้องของเนื้อหา.
{{% /alert %}}

## **แปลง SVG เป็นชุดของรูปทรง**
Aspose.Slides สามารถแปลง SVG ให้เป็นชุดของรูปทรงได้ คล้ายกับฟังก์ชันที่สอดคล้องกันใน PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

ฟังก์ชันนี้ให้โดย overload ของเมธอด [AddGroupShape](https://reference.aspose.com/slides/th/net/aspose.slides.ishapecollection/addgroupshape/methods/1) ของอินเทอร์เฟซ [IShapeCollection](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection) ที่รับออบเจกต์ [ISvgImage](https://reference.aspose.com/slides/th/net/aspose.slides/isvgimage) เป็นอาร์กิวเมนต์แรก

ตัวอย่างโค้ด C# ด้านล่างแสดงวิธีใช้เมธอดนี้เพื่อแปลงไฟล์ SVG เป็นชุดของรูปทรง:

``` csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// ชื่อไฟล์ SVG ต้นฉบับ
string svgFileName = "sample.svg";

// ชื่อไฟล์การนำเสนอผลลัพธ์
string outPptxPath = "presentation.pptx";

// สร้างการนำเสนอใหม่
using (IPresentation presentation = new Presentation())
{
    // อ่านเนื้อหาไฟล์ SVG
    string svgContent = File.ReadAllText(svgFileName);

    // สร้างออบเจกต์ SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // รับขนาดสไลด์
    SizeF slideSize = presentation.SlideSize.Size;

    // แปลงภาพ SVG ให้เป็นกลุ่มรูปทรงและปรับขนาดให้พอดีกับสไลด์
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // บันทึกการนำเสนอในรูปแบบ PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **เพิ่มภาพเป็น EMF ลงสไลด์**
Aspose.Slides for .NET อนุญาตให้คุณสร้างภาพ EMF จากแผ่นงาน Excel ด้วย Aspose.Cells และเพิ่มลงในสไลด์การนำเสนอ

ตัวอย่างโค้ด C# ด้านล่างแสดงวิธีทำเช่นนั้น:

``` csharp 
using Aspose.Slides;
using Aspose.Cells;
using Aspose.Cells.Rendering;


using (Workbook book = new Workbook("chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageType = Aspose.Cells.Drawing.ImageType.Emf;

    // บันทึก workbook ไปยังสตรีม
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save("Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **แทนที่ภาพใน Image Collection**
Aspose.Slides ให้คุณแทนที่ภาพที่เก็บอยู่ในคอลเลกชันภาพของการนำเสนอ รวมถึงภาพที่ใช้โดยรูปร่างของสไลด์ ส่วนนี้อธิบายหลายวิธีในการอัปเดตภาพในคอลเลกชัน คุณสามารถแทนที่ภาพโดยใช้ข้อมูลไบต์ดิบ, อินสแตนซ์ [IImage](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/) หรือภาพอื่นที่มีอยู่แล้วในคอลเลกชัน

1. โหลดไฟล์การนำเสนอที่มีภาพโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/).
2. โหลดภาพใหม่จากไฟล์ลงในอาร์เรย์ของไบต์.
3. แทนที่ภาพเป้าหมายด้วยภาพใหม่โดยใช้ไบต์อาร์เรย์.
4. ในวิธีที่สอง โหลดภาพเข้าสู่วัตถุ [IImage](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/) แล้วแทนที่ภาพเป้าหมายด้วยวัตถุนั้น.
5. ในวิธีที่สาม แทนที่ภาพเป้าหมายด้วยภาพที่มีอยู่แล้วในคอลเลกชันภาพของการนำเสนอ.
6. เขียนการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ.
using Presentation presentation = new Presentation("sample.pptx");

// วิธีแรก.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// วิธีที่สอง.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// วิธีที่สาม.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// บันทึกการนำเสนอลงในไฟล์.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Info" color="info" %}}
ด้วยตัวแปลงฟรี [Text to GIF](https://products.aspose.app/slides/th/text-to-gif) ของ Aspose คุณสามารถทำให้ข้อความเคลื่อนไหวและสร้าง GIF จากข้อความได้อย่างง่ายดาย. 
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ภาพต้นฉบับยังคงความละเอียดเดิมหลังจากแทรกหรือไม่?**

ใช่ พิกเซลต้นฉบับจะถูกเก็บไว้ แต่ลักษณะสุดท้ายขึ้นอยู่กับการสเกล [picture](/slides/th/net/picture-frame/) บนสไลด์และการบีบอัดที่ทำตอนบันทึก.

**วิธีที่ดีที่สุดในการแทนที่โลโก้เดียวกันในหลายสิบสไลด์พร้อมกันคืออะไร?**

วางโลโก้บน master slide หรือ layout แล้วแทนที่ในคอลเลกชันภาพของการนำเสนอ—การอัปเดตจะกระจายไปยังทุกองค์ประกอบที่ใช้ทรัพยากรนั้น.

**สามารถแปลง SVG ที่แทรกเข้ามาเป็นรูปทรงที่แก้ไขได้หรือไม่?**

ใช่ คุณสามารถแปลง SVG เป็นกลุ่มของรูปทรงได้ หลังจากนั้นส่วนย่อยแต่ละส่วนจะสามารถแก้ไขได้ด้วยคุณสมบัติมาตรฐานของรูปทรง.

**ฉันจะตั้งภาพเป็นพื้นหลังสำหรับหลายสไลด์พร้อมกันได้อย่างไร?**

[Assign the image as the background](/slides/th/net/presentation-background/) บน master slide หรือ layout ที่เกี่ยวข้อง—สไลด์ใดก็ตามที่ใช้ master/layout นั้นจะสืบทอดพื้นหลัง.

**ฉันจะป้องกันไม่ให้การนำเสนอใหญ่เกินไปเนื่องจากมีรูปภาพจำนวนมากได้อย่างไร?**

ใช้ทรัพยากรภาพเดียวซ้ำแทนการทำซ้ำหลายครั้ง เลือกความละเอียดที่สมเหตุสมผล ใช้การบีบอัดเมื่อบันทึก และเก็บกราฟิกที่ใช้บ่อยบน master ตามความเหมาะสม.