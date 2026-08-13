---
title: เพิ่มประสิทธิภาพการจัดการรูปภาพในงานนำเสนอด้วย .NET
linktitle: จัดการรูปภาพ
type: docs
weight: 10
url: /th/net/image/
keywords:
- เพิ่มรูปภาพ
- เพิ่มรูป
- เพิ่มบิตแมพ
- แทนที่รูปภาพ
- แทนที่รูป
- จากเว็บ
- พื้นหลัง
- เพิ่ม PNG
- เพิ่ม JPG
- เพิ่ม SVG
- ทรัพยากร SVG ภายนอก
- ตัวแก้ไข SVG
- รูป SVG ที่เชื่อมโยง
- ฟอนท์ SVG
- เพิ่ม EMF
- เพิ่ม WMF
- เพิ่ม TIFF
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ทำให้การจัดการรูปภาพใน PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ .NET ราบรื่นขึ้นด้วยการเพิ่มประสิทธิภาพการทำงานและอัตโนมัติขั้นตอนการทำงานของคุณ."
---
## **บทนำ**

ภาพทำให้การนำเสนอมีส่วนร่วมและน่าสนใจมากขึ้น ใน Microsoft PowerPoint คุณสามารถแทรกรูปภาพลงในสไลด์จากไฟล์ อินเทอร์เน็ต หรือแหล่งอื่น ๆ เช่นเดียวกับ Aspose.Slides ที่ให้คุณเพิ่มรูปภาพในสไลด์การนำเสนอหลายวิธี

{{% alert  title="เคล็ดลับ" color="info" %}} 
Aspose มีตัวแปลงฟรี—[JPEG เป็น PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG เป็น PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt)—ที่ช่วยให้คุณสร้างการนำเสนอจากรูปภาพได้อย่างรวดเร็ว 
{{% /alert %}} 

{{% alert title="ข้อมูล" color="info" %}}
หากคุณต้องการเพิ่มรูปภาพเป็นกรอบรูป—โดยเฉพาะเมื่อคุณต้องการปรับขนาด ใส่เอฟเฟกต์ หรือใช้ตัวเลือกการจัดรูปแบบมาตรฐานอื่น ๆ—ดูที่ [กรอบรูป](/slides/th/net/picture-frame/) 
{{% /alert %}} 

{{% alert title="หมายเหตุ" color="warning" %}}
คุณสามารถแปลงรูปภาพจากรูปแบบหนึ่งเป็นอีกรูปแบบได้ ดูหน้าเหล่านี้: แปลง [ภาพเป็น JPG](https://products.aspose.com/slides/th/net/conversion/image-to-jpg/), [JPG เป็นภาพ](https://products.aspose.com/slides/th/net/conversion/jpg-to-image/), [JPG เป็น PNG](https://products.aspose.com/slides/th/net/conversion/jpg-to-png/), [PNG เป็น JPG](https://products.aspose.com/slides/th/net/conversion/png-to-jpg/), [PNG เป็น SVG](https://products.aspose.com/slides/th/net/conversion/png-to-svg/), และ [SVG เป็น PNG](https://products.aspose.com/slides/th/net/conversion/svg-to-png/) 
{{% /alert %}}

Aspose.Slides รองรับรูปภาพในรูปแบบยอดนิยมเช่น JPEG, PNG, BMP, GIF และอื่น ๆ 

## **เพิ่มรูปภาพที่จัดเก็บในเครื่องลงในสไลด์**

คุณสามารถเพิ่มรูปภาพหนึ่งหรือหลายรูปที่จัดเก็บบนคอมพิวเตอร์ของคุณลงในสไลด์การนำเสนอ โค้ดตัวอย่าง C# ด้านล่างแสดงวิธีการเพิ่มรูปภาพลงในสไลด์:

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

## **เพิ่มรูปภาพจากเว็บลงในสไลด์**

หากรูปภาพที่คุณต้องการเพิ่มลงในสไลด์ไม่ได้จัดเก็บบนคอมพิวเตอร์ คุณสามารถเพิ่มโดยตรงจากเว็บได้

โค้ดตัวอย่าง C# ด้านล่างแสดงวิธีการเพิ่มรูปภาพจากเว็บลงในสไลด์:

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

## **เพิ่มรูปภาพลงใน Slide Masters**

Slide master เก็บและควบคุมข้อมูลเช่นธีมและเค้าโครงสำหรับสไลด์ที่ใช้มัน เมื่อคุณเพิ่มรูปภาพลงใน slide master รูปภาพจะปรากฏบนทุกสไลด์ที่อ้างอิงมาสไลด์มาสเตอร์นั้น

โค้ดตัวอย่าง C# ด้านล่างแสดงวิธีการเพิ่มรูปภาพลงใน slide master:

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

## **เพิ่มรูปภาพเป็นพื้นหลังสไลด์**

คุณสามารถใช้รูปภาพเป็นพื้นหลังสำหรับหนึ่งหรือหลายสไลด์สำหรับรายละเอียดดู *[ตั้งค่ารูปภาพเป็นพื้นหลังสำหรับสไลด์](/slides/th/net/presentation-background/#setting-images-as-background-for-slides)*

## **เพิ่ม SVG ลงในการนำเสนอ**

เนื้อหา SVG สามารถเพิ่มลงในการนำเสนอโดยใช้คลาส [SvgImage](https://reference.aspose.com/slides/th/net/aspose.slides/svgimage/) วัตถุ [ISvgImage](https://reference.aspose.com/slides/th/net/aspose.slides/isvgimage/) ที่ได้จากนั้นสามารถเพิ่มไปยังคอลเลกชันรูปภาพของการนำเสนอและใช้สร้างกรอบรูปได้

โค้ดตัวอย่าง C# ด้านล่างนำเข้า SVG ที่เป็นสตริงแบบ self‑contained ทั้งรูปภาพ สไตล์ และทรัพยากรอื่น ๆ ถูกฝังไว้โดยตรงในเนื้อหา SVG:

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

ไฟล์ SVG ที่ส่งออกจากเครื่องมือออกแบบ ตัวแก้ไขไดอะแกรม ระบบไอคอน และกระบวนการเว็บอาจอ้างอิงทรัพยากรที่จัดเก็บนอกเอกสาร SVG ตัวอย่างเช่น SVG อาจมีลิงก์รูปภาพเช่น `images/photo.png` ค่าของ CSS `url(...)` หรือ URL ของฟอนท์

เพื่อให้นำเข้าเนื้อหา SVG ดังกล่าว ให้สร้างการทำงานของ [IExternalResourceResolver](https://reference.aspose.com/slides/th/net/aspose.slides.import/iexternalresourceresolver/) แล้วส่งร่วมกับ base URI ไปยังคอนสตรัคเตอร์ `SvgImage` ที่เหมาะสม base URI ระบุตำแหน่งของเอกสาร SVG และใช้สำหรับแก้ลิงก์แบบ relative

อินเทอร์เฟซ [ISvgImage](https://reference.aspose.com/slides/th/net/aspose.slides/isvgimage/) ให้เข้าถึงข้อมูลเกี่ยวกับ SVG ที่นำเข้า:

- `SvgContent` คืนค่า SVG markup เป็นสตริง
- `SvgData` คืนค่าเนื้อหา SVG เป็นอาร์เรย์ไบต์
- `BaseUri` คืนค่า base URI ที่ใช้สำหรับลิงก์แบบ relative
- `ExternalResourceResolver` คืนค่า resolver ที่กำหนดให้กับรูปภาพ SVG

### **สร้าง External Resource Resolver**

Resolver มีสองเมธอด:

- [ResolveUri](https://reference.aspose.com/slides/th/net/aspose.slides.import/iexternalresourceresolver/resolveuri/) ผสาน base URI กับลิงก์ทรัพยากรแบบ relative และคืนค่า URI แบบ absolute คืน `null` เมื่อไม่สามารถแก้ลิงก์หรือไม่ได้รับอนุญาต
- [GetEntity](https://reference.aspose.com/slides/th/net/aspose.slides.import/iexternalresourceresolver/getentity/) คืนสตรีมที่อ่านได้สำหรับ URI ของทรัพยากรแบบ absolute คืน `null` เมื่อทรัพยากรหาย บล็อก หรือไม่สามารถเข้าถึงได้ สามารถคืนสตรีมสำรองเมื่อเหมาะสม

โค้ดตัวอย่างด้านล่างโหลดทรัพยากรที่เชื่อมโยงเฉพาะจากไดเรกทอรีท้องถิ่นที่อนุญาต เท่านั้น ทรัพยากรเครือข่ายและเส้นทางนอกไดเรกทอรีที่อนุญาตจะถูกบล็อก ภาพสำรองทางเลือกจะคืนค่าหากไม่สามารถแก้ลิงก์รูปภาพได้

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

        // ตัวแก้ไขนี้จงใจอนุญาตให้ใช้ไฟล์ในเครื่องเท่านั้น.
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

        // ใช้ภาพสำรองเฉพาะสำหรับทรัพยากรรูปภาพเท่านั้น การคืนสตรีมรูปภาพ
        // สำหรับฟอนต์หรือสไตล์ชีทที่หายไปจะไม่เป็นที่ถูกต้อง.
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

### **แก้ลิงก์ทรัพยากรระหว่างการนำเข้า SVG**

สมมติว่า `assets/diagram.svg` มีการอ้างอิงแบบ relative เช่น:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

โค้ดตัวอย่าง C# ด้านล่างส่ง URI ของไฟล์ SVG เป็น base URI แล้วให้ resolver แบบกำหนดเอง Resolver จะเปลี่ยนลิงก์รูปภาพแบบ relative ให้เป็น URI แบบ absolute และคืนสตรีมที่มีทรัพยากรที่เชื่อมโยงในขณะที่ Aspose.Slides ประมวลผล SVG

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

string svgFilePath = Path.GetFullPath(Path.Combine("assets", "diagram.svg"));
string assetDirectory = Path.GetDirectoryName(svgFilePath) ?? Directory.GetCurrentDirectory();
string svgContent = File.ReadAllText(svgFilePath);

// Base URI แสดงตำแหน่งของเอกสาร SVG.
string baseUri = new Uri(svgFilePath).AbsoluteUri;

byte[] fallbackImageData = null;
string fallbackImagePath = Path.Combine(assetDirectory, "fallback.png");
if (File.Exists(fallbackImagePath))
{
    fallbackImageData = File.ReadAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory, fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage ให้ข้อมูลเกี่ยวกับเนื้อหาแหล่งที่มา ข้อมูลไบนารี Base URI และ resolver.
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

คลาส `SvgImage` ยังมี overloads ที่รับข้อมูล SVG เป็นอาร์เรย์ไบต์หรือสตรีม พร้อมกับ external resource resolver และ base URI

{{% alert title="สำคัญ" color="warning" %}}

Resolver ทำให้ทรัพยากรภายนอกพร้อมใช้งานในขณะที่ Aspose.Slides ประมวลผลและเรนเดอร์ SVG ไม่ได้แก้ไข markup ของ SVG ดั้งเดิมหรือฝังทรัพยากรที่แก้ไขโดยอัตโนมัติ

เมื่อ `ISvgImage` ถูกเพิ่มไปยังคอลเลกชันรูปภาพของการนำเสนอ ไฟล์ PPTX อาจมีทั้งการแสดงผล SVG ดั้งเดิมและภาพ raster สำรอง ทรัพยากรที่เชื่อมโยงอาจปรากฏในภาพสำรองที่สร้างขึ้น ในขณะที่ลิงก์แบบ relative เช่น `images/photo.png` ยังคงไม่เปลี่ยนแปลงใน SVG ที่จัดเก็บ แอปพลิเคชันที่เรนเดอร์ SVG แบบดั้งเดิมอาจละเว้นเนื้อหาที่เชื่อมโยงเมื่อทรัพยากรภายนอกต้นฉบับไม่พร้อมใช้งาน
{{% /alert %}}

### **สร้างภาพ SVG แบบพกพา**

เพื่อสร้างภาพ SVG ที่ไม่พึ่งพาไฟล์ภายนอก ให้ทำให้ SVG เป็น self‑contained ก่อนสร้าง `SvgImage` ตัวอย่างเช่น แทนที่ URL ของรูปภาพที่เชื่อมโยงด้วย URI `data:` ที่มีข้อมูลรูปภาพอยู่ในตัว

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

เมื่อฝังทรัพยากรทั้งหมดลงในเนื้อหา SVG แล้ว สร้าง `SvgImage` เพิ่มลงในคอลเลกชันรูปภาพของการนำเสนอ และแทรกลงในกรอบรูปตามตัวอย่างก่อนหน้า

### **จัดการทรัพยากรที่หายหรือถูกบล็อก**

ให้คืนค่า `null` จาก `ResolveUri` เมื่อ URI ของทรัพยากรไม่ถูกต้อง ห้าม หรือไม่สามารถแก้ได้ ให้คืนค่า `null` จาก `GetEntity` เมื่อไม่สามารถอ่านทรัพยากรได้ Aspose.Slides จะดำเนินการต่อโดยไม่มีทรัพยากรนั้นเมื่อเป็นไปได้

สตรีมสำรองสามารถคืนค่าได้สำหรับทรัพยากรที่หาย แต่เนื้อหาต้องสอดคล้องกับประเภทของทรัพยากรที่ร้องขอ ตัวอย่างเช่น ให้คืนสตรีมรูปภาพเท่านั้นสำหรับภาพที่หาย ไม่ใช่สำหรับฟอนท์หรือสไตล์ชีท

{{% alert title="ความปลอดภัย" color="warning" %}}

ห้ามแก้ไขลิงก์ไฟล์ใด ๆ หรือ URL เครือข่ายโดยไม่มีการตรวจสอบจากไฟล์ SVG ที่ไม่น่าเชื่อถือ จำกัดสกีมที่อนุญาต ไดเรกทอรีและโฮสต์ที่อนุญาตสำหรับทรัพยากรภายนอก สำหรับทรัพยากรเครือข่ายควรกำหนดเวลาเชื่อมต่อ ขนาดการตอบรับสูงสุด และการตรวจสอบความถูกต้องของเนื้อหา
{{% /alert %}}

## **แปลง SVG เป็นชุดของ Shape**
Aspose.Slides สามารถแปลง SVG ให้เป็นชุดของ Shape ได้เช่นเดียวกับฟังก์ชันที่สอดคล้องกันใน PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

ฟังก์ชันนี้ให้โดย overload ของเมธอด [AddGroupShape](https://reference.aspose.com/slides/th/net/aspose.slides.ishapecollection/addgroupshape/methods/1) ของอินเทอร์เฟซ [IShapeCollection](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection) ที่รับอ็อบเจกต์ [ISvgImage](https://reference.aspose.com/slides/th/net/aspose.slides/isvgimage) เป็นอาร์กิวเมนต์แรก

โค้ดตัวอย่าง C# ด้านล่างแสดงวิธีใช้เมธอดนี้เพื่อแปลงไฟล์ SVG เป็นชุดของ Shape:

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

    // สร้างอ็อบเจกต์ SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // รับขนาดสไลด์
    SizeF slideSize = presentation.SlideSize.Size;

    // แปลงภาพ SVG เป็นกลุ่มของ Shape และปรับขนาดให้พอดีกับสไลด์
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // บันทึกการนำเสนอในรูปแบบ PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **เพิ่ม SVG เป็น EMF ลงในสไลด์**
Aspose.Slides for .NET อนุญาตให้คุณสร้างภาพ EMF จากแผ่นงาน Excel ด้วย Aspose.Cells และเพิ่มลงในสไลด์การนำเสนอ

โค้ดตัวอย่าง C# ด้านล่างแสดงวิธีทำ:

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

    // บันทึกเวิร์กบุ๊กไปยังสตรีม
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

## **แทนที่รูปภาพใน Image Collection**

Aspose.Slides ให้คุณแทนที่รูปภาพที่เก็บอยู่ใน Image Collection ของการนำเสนอ รวมถึงรูปภาพที่ใช้โดย Shape ของสไลด์ ส่วนนี้อธิบายวิธีการอัปเดตรูปภาพในคอลเลกชันหลายวิธี คุณสามารถแทนที่รูปภาพด้วยข้อมูลไบต์ดิบ อินสแตนซ์ของ [IImage](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/) หรือรูปภาพอื่นที่มีอยู่แล้วในคอลเลกชัน

ทำตามขั้นตอนต่อไปนี้:

1. โหลดไฟล์การนำเสนอที่มีรูปภาพโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
1. โหลดรูปภาพใหม่จากไฟล์ลงในอาร์เรย์ไบต์
1. แทนที่รูปภาพเป้าหมายด้วยรูปภาพใหม่โดยใช้อาร์เรย์ไบต์
1. ในวิธีที่สอง โหลดรูปภาพเข้าสู่วัตถุ [IImage](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/) แล้วแทนที่รูปภาพเป้าหมายด้วยวัตถุนั้น
1. ในวิธีที่สาม แทนที่รูปภาพเป้าหมายด้วยรูปภาพที่มีอยู่แล้วใน Image Collection ของการนำเสนอ
1. เขียนการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ
using Presentation presentation = new Presentation("sample.pptx");

// วิธีแรก
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// วิธีที่สอง
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// วิธีที่สาม
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// บันทึกการนำเสนอลงไฟล์
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="ข้อมูล" color="info" %}}
ด้วยตัวแปลงฟรีของ Aspose อย่าง [Text to GIF](https://products.aspose.app/slides/th/text-to-gif) คุณสามารถทำให้ข้อความเคลื่อนไหวและสร้าง GIF จากข้อความได้
{{% /alert %}}

## **FAQ**

**ความละเอียดของรูปภาพต้นฉบับยังคงเหมือนเดิมหลังจากแทรกหรือไม่?**  
ใช่ พิกเซลต้นฉบับจะถูกเก็บรักษาไว้ แต่รูปลักษณ์สุดท้ายขึ้นอยู่กับการสเกลของ [picture](/slides/th/net/picture-frame/) บนสไลด์และการบีบอัดเมื่อบันทึก

**วิธีที่ดีที่สุดในการแทนที่โลโก้เดียวกันในหลายสิบสไลด์พร้อมกันคืออะไร?**  
วางโลโก้บน slide master หรือ layout แล้วแทนที่ใน Image Collection ของการนำเสนอ—การอัปเดตจะกระจายไปยังทุกองค์ประกอบที่ใช้ทรัพยากรนั้น

**SVG ที่แทรกเข้ามาสามารถแปลงเป็น Shape ที่แก้ไขได้หรือไม่?**  
ใช่ คุณสามารถแปลง SVG เป็นกลุ่มของ Shape ได้ หลังจากนั้นส่วนย่อยแต่ละส่วนจะสามารถแก้ไขด้วยคุณสมบัติ Shape มาตรฐาน

**จะตั้งค่ารูปภาพเป็นพื้นหลังสำหรับหลายสไลด์พร้อมกันอย่างไร?**  
[กำหนดรูปภาพเป็นพื้นหลัง](/slides/th/net/presentation-background/) บน slide master หรือ layout ที่เกี่ยวข้อง—สไลด์ใดที่ใช้ master/layout นั้นจะสืบทอดพื้นหลังโดยอัตโนมัติ

**ทำอย่างไรเพื่อป้องกันไม่ให้การนำเสนอใหญ่เกินไปจากรูปภาพจำนวนมาก?**  
ใช้ทรัพยากรรูปภาพเดียวซ้ำแทนการทำซ้ำ เลือกความละเอียดที่เหมาะสม ใช้การบีบอัดเมื่อบันทึก และเก็บกราฟิกที่ซ้ำซ้อนไว้บน master เมื่อเหมาะสม