---
title: จัดการกรอบรูปภาพในงานนำเสนอด้วย .NET
linktitle: กรอบรูปภาพ
type: docs
weight: 10
url: /th/net/picture-frame/
keywords:
- กรอบรูปภาพ
- เพิ่มกรอบรูปภาพ
- สร้างกรอบรูปภาพ
- ภาพฝัง
- ภาพเชื่อมโยง
- สกัดภาพ
- ภาพแรสเตอร์
- ภาพ SVG
- ครอบภาพ
- ลบพื้นที่ที่ครอป
- บีบอัดภาพ
- StretchOffset
- การจัดรูปแบบกรอบรูปภาพ
- สเกลสัมพัทธ์
- เอฟเฟ็กต์ภาพ
- อัตราส่วนภาพ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สร้าง, จัดรูปแบบ, เชื่อมโยง, ครอบ, สกัด, และบีบอัดกรอบรูปภาพในงานนำเสนอด้วย Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

กรอบรูปภาพเป็นรูปทรงสไลด์ที่แสดงภาพหนึ่งภาพ ใน Aspose.Slides, ทรัพยากรภาพและรูปทรงที่แสดงมันเป็นวัตถุแยกกัน: a [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) เป็นเจ้าของทรัพยากรภาพที่ฝังอยู่ผ่านคอลเลกชัน [Images](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/images/) , ในขณะที่ [IPictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ipictureframe/) ควบคุมตำแหน่ง, ขนาด, การจัดรูปแบบเส้น, การหมุน, การครอบ, ผลกระทบภาพ, และการตั้งค่าระดับกรอบอื่น ๆ

การแยกนี้มีประโยชน์เมื่อภาพเดียวกันถูกแสดงมากกว่าหนึ่งครั้ง เพิ่มภาพไปยังงานนำเสนอครั้งเดียว เก็บ [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) ที่ส่งคืนไว้ และใช้ทรัพยากรภาพนั้นเมื่อสร้างกรอบรูปภาพ

กรอบรูปภาพสามารถบรรจุภาพแรสเตอร์เช่น PNG หรือ JPEG และภาพเวกเตอร์ SVG ได้ นอกจากนี้ยังสามารถอ้างอิงภาพที่เชื่อมโยงแทนการเก็บไบต์ภาพในงานนำเสนอ ตัวเลือกนี้มีผลต่อการพกพา, ขนาดไฟล์, การสกัดและพฤติกรรมการส่งออก ดังนั้นจึงควรตัดสินใจว่าภาพจะถูกจัดเก็บอย่างไรก่อนทำการจัดรูปแบบหรือการปรับแต่ง

## **เพิ่มและจัดรูปแบบภาพฝัง**

สำหรับภาพฝัง ให้เพิ่มข้อมูลภาพไปยังงานนำเสนอและสร้างกรอบรูปภาพด้วย [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/addpictureframe/) ภาพจะกลายเป็นส่วนหนึ่งของแพ็กเกจงานนำเสนอ ดังนั้นงานนำเสนอจะยังคงเป็นอิสระเมื่อย้ายไปยังคอมพิวเตอร์เครื่องอื่น

ตัวอย่างต่อไปนี้เพิ่มภาพ JPEG, สร้างกรอบที่มีขนาดตามมิติเดิมของภาพ, และใช้การจัดรูปแบบเส้นและการหมุน:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
pictureFrame.LineFormat.Width = 3;
pictureFrame.Rotation = 15;

presentation.Save("picture-frame.pptx", SaveFormat.Pptx);
```

กรอบรูปภาพควบคุมเรขาคณิตที่แสดง; การเปลี่ยนขนาดกรอบจะไม่เปลี่ยนมิติพิกเซลเดิมที่เก็บในทรัพยากรภาพฝัง การแยกนี้สำคัญเมื่อทำการครอบหรือบีบอัดภาพในภายหลัง

## **ใช้สเกลสัมพัทธ์**

[IPictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ipictureframe/) เปิดเผยการสเกลความกว้างและความสูงแบบสัมพัทธ์สำหรับกรอบ ค่า `1.0` ตรงกับ 100% ของขนาดภาพต้นฉบับ สเกลสัมพัทธ์มีประโยชน์เมื่อเวิร์กโฟลว์ต้องคงความสัมพันธ์กับขนาดภาพต้นฉบับแทนการคำนวณมิติสุดท้ายด้วยตนเอง

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
pictureFrame.RelativeScaleWidth = 1.35f;
pictureFrame.RelativeScaleHeight = 0.8f;

presentation.Save("relative-scale.pptx", SaveFormat.Pptx);
```

สเกลสัมพัทธ์เปลี่ยนการตั้งค่าสเกลของกรอบ; มันไม่ทำการสุ่มตัวอย่างหรือบีบอัดภาพฝัง

## **ภาพฝังและภาพเชื่อมโยง**

ภาพฝังเก็บข้อมูลภาพภายในงานนำเสนอและจึงเป็นตัวเลือกที่ปลอดภัยที่สุดสำหรับการพกพาและการเรนเดอร์ที่คาดเดาได้ ภาพเชื่อมโยงเก็บตำแหน่งภายนอกผ่านพาธลิงก์ของ [ISlidesPicture](https://reference.aspose.com/slides/th/net/aspose.slides/islidespicture/) แทนการฝังข้อมูลภาพในวิธีเดียวกัน

ภาพเชื่อมโยงสามารถลดปริมาณข้อมูลภาพที่เก็บใน PPTX ได้ แต่จะนำพาขึ้นอยู่กับไฟล์ภายนอก ไฟล์ที่เชื่อมโยงต้องสามารถเข้าถึงได้โดยแอปพลิเคชันที่เปิดหรือเรนเดอร์งานนำเสนอ หากพาธเปลี่ยน, ไฟล์ถูกย้าย, หรือทรัพยากรไม่พร้อมใช้งาน ภาพเชื่อมโยงอาจไม่แสดงตามที่คาดไว้ สำหรับงานนำเสนอที่ต้องส่งอีเมล, จัดเก็บ, หรือเรนเดอร์ในสภาพแวดล้อมที่แยกจากกัน, ภาพฝังมักจะเชื่อถือได้มากกว่า

### **เพิ่มภาพเชื่อมโยง**

ตัวอย่างต่อไปนี้สร้างกรอบรูปภาพและชี้ไปที่ไฟล์ภาพในเครื่อง มุ่งเน้นเฉพาะการเชื่อมโยงภาพ; การเชื่อมโยงวิดีโอเป็นเวิร์กโฟลว์สื่อแยกต่างหากและไม่ได้ผสมเข้ากับตัวอย่างนี้โดยเจตนา

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = Path.GetFullPath("linked-image.jpg");

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

ใช้ลิงก์เมื่อการจัดการไฟล์ภายนอกเป็นเจตนา ไม่ควรใช้เป็นการแทนที่การบีบอัด: PPTX ขนาดเล็กที่มีการพึ่งพาภาพเสียหายมักจะใช้งานได้น้อยกว่าการนำเสนอที่เป็นอิสระแต่มีขนาดใหญ่กว่า

## **สกัดภาพจากกรอบรูปภาพ**

ก่อนสกัดภาพจากงานนำเสนอที่มีอยู่, ตรวจสอบให้แน่ใจว่ารูปทรงเป็น [IPictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ipictureframe/) จริงและมีภาพฝังอยู่ กรอบรูปภาพที่เชื่อมโยงอาจไม่มีไบต์ภาพที่สามารถสกัดได้ในลักษณะเดียวกัน

### **สกัดภาพแรสเตอร์**

API ภาพสมัยใหม่ใช้ [IImage](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/) โดยตรงและไม่ต้องอาศัย wrapper ระบบภาพแบบเก่า ตัวอย่างต่อไปนี้ค้นหาภาพแรสเตอร์ฝังแรกบนสไลด์และบันทึกเป็น PNG:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    if (embeddedImage == null || embeddedImage.SvgImage != null)
    {
        continue;
    }

    using var rasterImage = embeddedImage.Image;
    rasterImage.Save("extracted-image.png", Aspose.Slides.ImageFormat.Png);
    break;
}
```

การบันทึกผ่าน [IImage](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/) จะเปลี่ยนภาพที่สกัดเป็นรูปแบบผลลัพธ์ที่ต้องการ หากต้องการไบต์ที่เข้ารหัสที่เก็บในงานนำเสนอแทนไฟล์แรสเตอร์ที่แปลงแล้วให้ใช้ข้อมูลไบนารีของทรัพยากรภาพแทน

### **สกัดภาพ SVG**

สำหรับภาพ SVG, [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) เปิดเผยออบเจ็กต์ [ISvgImage](https://reference.aspose.com/slides/th/net/aspose.slides/isvgimage/) ซึ่งทำให้คุณดึงข้อมูล SVG ได้โดยตรงแทนการเรนเดอร์ภาพก่อน

```csharp
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    var svgImage = embeddedImage?.SvgImage;
    if (svgImage == null)
    {
        continue;
    }

    File.WriteAllBytes("extracted-image.svg", svgImage.SvgData);
    break;
}
```

การเก็บเนื้อหา SVG เป็น SVG จะคงไว้ซึ่งแหล่งเวกเตอร์ภายในงานนำเสนอ การส่งออกเป็นแรสเตอร์เช่น PNG หรือ JPEG จะต้องแปลงเนื้อหาเวกเตอร์เป็นพิกเซล การส่งออกสไลด์เป็น PDF หรือ SVG ก็เป็นกระบวนการเรนเดอร์เช่นกัน ดังนั้นกราฟิกที่ส่งออกจึงไม่ควรถือว่าเป็นสำเนาแบบไบต์ต่อไบต์ของ SVG ฝังต้นฉบับ; ใช้ข้อมูล [ISvgImage](https://reference.aspose.com/slides/th/net/aspose.slides/isvgimage/) ฝังเมื่อจำเป็นต้องใช้ทรัพยากรเวกเตอร์ดั้งเดิมเอง

## **ครอปภาพ**

การครอปเปลี่ยนส่วนที่มองเห็นของภาพภายในกรอบ ค่าครอปบน [IPictureFillFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/) เป็นเปอร์เซ็นต์ของมิติต้นฉบับของภาพ การครอปไม่ได้ลบพิกเซลที่ซ่อนอยู่จากภาพฝัง; มันเพียงเปลี่ยนพื้นที่ที่มองเห็น

ตัวอย่างต่อไปนี้ค้นหากรอบรูปภาพอย่างปลอดภัยและใช้ค่าครอป:

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    pictureFrame.PictureFormat.CropLeft = 23.6f;
    pictureFrame.PictureFormat.CropRight = 21.5f;
    pictureFrame.PictureFormat.CropTop = 3f;
    pictureFrame.PictureFormat.CropBottom = 31f;
    presentation.Save("cropped-image.pptx", SaveFormat.Pptx);
}
```

เพราะข้อมูลภาพที่ซ่อนอยู่ยังคงอยู่, การครอปสามารถเปลี่ยนแปลงได้ภายหลังโดยไม่สูญเสียพิกเซลต้นฉบับ หากขนาดไฟล์เป็นสิ่งสำคัญกว่าการย้อนกลับ, พื้นที่ที่ครอปสามารถลบออกจริงได้ตามที่อธิบายในส่วนต่อไป

## **ลบข้อมูลภาพที่ถูกครอป**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) จะลบข้อมูลภาพที่อยู่นอกสี่เหลี่ยมครอปปัจจุบันและส่งคืนทรัพยากรภาพที่ได้ผลลัพธ์นี้ ซึ่งสามารถลดขนาดไฟล์ได้ แต่เป็นการเพิ่มประสิทธิภาพที่ทำลาย: หลังจากบันทึกงานนำเสนอแล้ว พิกเซลที่ลบจะไม่สามารถเรียกคืนสำหรับการยกเลิกครอปในภายหลังได้

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("cropped-image.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var croppedImage = pictureFrame.PictureFormat.DeletePictureCroppedAreas();
    if (croppedImage != null)
    {
        presentation.Save("cropped-data-removed.pptx", SaveFormat.Pptx);
    }
}
```

เมธอดนี้อาจเพิ่มทรัพยากรภาพใหม่ลงในงานนำเสนอ หากภาพต้นฉบับถูกใช้โดยกรอบรูปภาพอื่น ๆ ด้วย, กรอบเหล่านั้นยังคงต้องการทรัพยากรเดิมอยู่ ดังนั้นการลบพื้นที่ที่ครอปไม่จำเป็นต้องลดจำนวนภาพทั้งหมด การครอปเนื้อหา WMF หรือ EMF ด้วยเมธอดนี้จะทำให้ผลลัพธ์ที่ครอปเป็น PNG

## **บีบอัดภาพแรสเตอร์**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/compressimage/) ลดความละเอียดของภาพแรสเตอร์สัมพันธ์กับขนาดที่ภาพแสดง มันยังสามารถลบพื้นที่ที่ครอปในขั้นตอนเดียวได้ เมธอดจะคืนค่า `true` เมื่อภาพถูกปรับขนาดหรือครอปและคืนค่า `false` เมื่อไม่มีการเปลี่ยนแปลงใด ๆ จำเป็น

ใช้ค่ากำหนดล่วงหน้า [PicturesCompression](https://reference.aspose.com/slides/th/net/aspose.slides.export/picturescompression/) เมื่อความละเอียดเป้าหมายมาตรฐานเพียงพอ:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var compressed = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);
    Console.WriteLine(compressed ? "The image was compressed." : "No compression was necessary.");
    presentation.Save("compressed-image.pptx", SaveFormat.Pptx);
}
```

สามารถส่งค่า DPI บวกที่กำหนดเองแทนค่าที่เป็น enum ได้เมื่อจำเป็นต้องกำหนดเป้าหมายเฉพาะ

การบีบอัดมุ่งเน้นที่ภาพแรสเตอร์ SVG และเนื้อหาเมทาฟายล์จะไม่ได้รับผลจากเวิร์กโฟลว์บีบอัดแรสเตอร์นี้ อย่าลืมว่าความละเอียดที่ต่ำลงและการลบพื้นที่ที่ครอปไม่สามารถกู้คืนจากงานนำเสนอที่ปรับปรุงแล้วได้ เลือกความละเอียดเป้าหมายตามขนาดสูงสุดที่ภาพจะถูกดูหรือส่งออกจริง ๆ แทนการใช้ DPI ต่ำสุดทั่วทั้งงาน

## **จัดการเอฟเฟ็กต์การแปลงภาพ**

สำหรับเวิร์กโฟลว์ครบถ้วนที่ครอบคลุมความสว่าง, ความคอนทราสต์, การแปลงสี, เบลอ, เอฟเฟ็กต์อัลฟา, เชนที่สั่ง, การตรวจสอบ, การลบ, และการตรวจสอบรอบสอง, ดู [Image Transform Effects](/slides/th/net/image-transform-effects/)

## **ล็อกเรขาคณิตกรอบรูปภาพ**

การตั้งค่า [IPictureFrameLock](https://reference.aspose.com/slides/th/net/aspose.slides/ipictureframelock/) ควบคุมการดำเนินการแก้ไขใด ๆ ที่ถูกปิดสำหรับกรอบรูปภาพ ตัวอย่างเช่น การล็อกอัตราส่วนภาพจะคงอัตราส่วนของรูปทรงขณะเปลี่ยนขนาด

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.PictureFrameLock.AspectRatioLocked = true;

presentation.Save("locked-picture-frame.pptx", SaveFormat.Pptx);
```

การล็อกนี้ใช้กับรูปทรงกรอบรูปภาพ ไม่บังคับให้ภาพต้นฉบับต้องถูกสุ่มตัวอย่างหรือเปลี่ยนแปลงถาวรให้เป็นอัตราส่วนเดียวกัน

## **ปรับค่า StretchOffset**

เมื่อโหมดการเติมภาพเป็น stretch, ค่า stretch‑offset บน [IPictureFillFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/) จะกำหนดสี่เหลี่ยมเติมสัมพันธ์กับกรอบรูปภาพ ค่าร้อยละบวกจะสร้างการย่อจากขอบ, ขณะที่ค่าร้อยละลบจะสร้างการขยายออก

นี่แตกต่างจากการครอป ค่าครอปเลือกส่วนของภาพต้นฉบับที่มองเห็น; stretch offsets ปรับสี่เหลี่ยมที่ภาพเติมที่มองเห็นถูกยืด

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
pictureFrame.PictureFormat.StretchOffsetLeft = 12f;
pictureFrame.PictureFormat.StretchOffsetRight = 12f;
pictureFrame.PictureFormat.StretchOffsetTop = 8f;
pictureFrame.PictureFormat.StretchOffsetBottom = 8f;

presentation.Save("stretch-offsets.pptx", SaveFormat.Pptx);
```

ใช้ stretch offsets เพื่อจัดตำแหน่งการเติม ใช้คุณสมบัติครอปเมื่อเป้าหมายคือการซ่อนขอบของภาพต้นฉบับ

## **การจัดเก็บ, ขนาดไฟล์, และข้อควรพิจารณาการส่งออก**

การต่อรองหลักจะง่ายขึ้นเมื่อการจัดเก็บภาพและการจัดรูปแบบกรอบรูปภาพถูกแยกกันจัดการ:

- **ภาพฝัง** ทำให้การนำเสนอเป็นอิสระและเป็นทางเลือกที่เชื่อถือได้ที่สุดสำหรับการแชร์และการเรนเดอร์ฝั่งเซิร์ฟเวอร์, แต่ภาพแรสเตอร์ขนาดใหญ่จะเพิ่มขนาด PPTX และการใช้หน่วยความจำ
- **ภาพเชื่อมโยง** สามารถทำให้แพ็กเกจเล็กลง, แต่การนำเสนอพึ่งพาไฟล์ภายนอกที่ต้องคงอยู่ที่พาธหรือที่ตั้งที่บันทึกไว้
- **การครอป** เริ่มต้นเป็นแบบไม่ทำลาย; พิกเซลที่ซ่อนอยู่ยังคงฝังอยู่จนกว่าจะมีการลบพื้นที่ที่ครอปโดยเจตนาหรือระหว่างการบีบอัด
- **การบีบอัด** สามารถลดขนาดไฟล์อย่างมีนัยสำคัญสำหรับภาพแรสเตอร์ที่ใหญ่เกินไป, แต่จะเสียความละเอียดของต้นฉบับ ควรทำหลังจากทราบขนาดบนสไลด์ที่ต้องการแล้ว
- **ภาพ SVG** ควรคงเป็น SVG เมื่อความสมบูรณ์ของเวกเตอร์สำคัญ; สกัด SVG ฝังโดยตรงเมื่อคุณต้องการทรัพยากรเวกเตอร์เอง การส่งออกสไลด์เป็นแรสเตอร์จะเปลี่ยนสไลด์ที่เรนเดอร์เป็นพิกเซลเสมอ
- **ภาพซ้ำ** ควรใช้ทรัพยากร [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) ที่มีอยู่แล้วเมื่อทำได้แทนการโหลดไฟล์เดียวกันหลายครั้งในเวิร์กโฟลว์ของงานนำเสนอ

สำหรับงานนำเสนอขนาดใหญ่, การปรับภาพมักจะมีประสิทธิภาพที่สุดเมื่อทำอย่างเลือกสรร: รักษาโลโก้และแผนภาพเป็นเนื้อหาเวกเตอร์, บีบอภาพถ่ายตามขนาดการแสดงจริง, ลบพิกเซลที่ครอปเฉพาะเมื่อไม่ต้องการการแก้ไขภายหลัง, และหลีกเลี่ยงลิงก์ภายนอกเว้นแต่การจัดการการพึ่งพาจะเป็นส่วนหนึ่งของการออกแบบการปรับใช้

## **FAQ**

**ความแตกต่างระหว่างกรอบรูปภาพและทรัพยากรภาพคืออะไร?**

[IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) แสดงถึงทรัพยากรภาพที่เชื่อมโยงกับงานนำเสนอ [IPictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ipictureframe/) คือรูปทรงบนสไลด์ที่แสดงภาพและเก็บเรขาคณิตระดับกรอบและการจัดรูปแบบ เช่น ขนาด, การหมุน, ค่าครอป, เอฟเฟ็กต์, และการล็อก

**ควรฝังหรือเชื่อมโยงภาพ?**

ฝังภาพเมื่อการนำเสนอจำเป็นต้องพกพา, เก็บถาวร, หรือเรนเดอร์โดยไม่ต้องอาศัยทรัพยากรภายนอก เชื่อมโยงภาพเฉพาะเมื่อต้องการเก็บไฟล์ภาพอยู่นอก PPTX โดยตั้งใจและตำแหน่งภายนอกสามารถจัดการได้อย่างเชื่อถือได้

**การครอปลดขนาดไฟล์ PPTX หรือไม่?**

ไม่โดยตรง การตั้งค่าครอปปกติจะซ่อนส่วนของภาพต้นฉบับแต่ยังคงพิกเซลไว้ ใช้ [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) หรือบีบอัดภาพพร้อมการลบพื้นที่ที่ครอปเมื่อพิกเซลเหล่านั้นสามารถทิ้งได้อย่างถาวร

**ฉันสามารถเรียกคืนคุณภาพภาพหลังบีบอัดได้หรือไม่?**

ไม่ได้ การบีบอัดสามารถลดความละเอียดแรสเตอร์ที่จัดเก็บและการลบพื้นที่ที่ครอปจะทำให้ข้อมูลภาพหายไป เก็บภาพต้นฉบับไว้ภายนอกงานนำเสนอหากอาจต้องแก้ไขด้วยความละเอียดสูงในภายหลัง

**ควรจัดการภาพ SVG อย่างไร?**

เก็บเนื้อหา SVG เป็น SVG เมื่อความแม่นยำของเวกเตอร์สำคัญ สามารถสกัด [ISvgImage](https://reference.aspose.com/slides/th/net/aspose.slides/isvgimage/) ฝังโดยตรง การเรนเดอร์สไลด์เป็นรูปแบบแรสเตอร์เช่น PNG หรือ JPEG จะทำให้ SVG ถูกแปลงเป็นพิกเซล

**จะหลีกเลี่ยงการแคสต์ที่ไม่ปลอดภัยเมื่ออ่านสไลด์ที่มีอยู่ได้อย่างไร?**

ตรวจสอบประเภทของรูปทรงก่อนใช้สมาชิกเฉพาะกรอบรูปภาพ ใช้การจับคู่รูปแบบกับ [IPictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ipictureframe/) หรือกรองคอลเลกชันรูปทรงด้วยอินเทอร์เฟซนั้นเพื่อหลีกเลี่ยงการแคสต์ที่ไม่ถูกต้องและให้โค้ดจัดการสไลด์ที่ไม่มีกรอบรูปภาพได้อย่างเหมาะสม