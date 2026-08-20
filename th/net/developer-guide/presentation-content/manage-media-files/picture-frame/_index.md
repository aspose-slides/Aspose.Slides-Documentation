---
title: จัดการเฟรมรูปภาพในงานนำเสนอด้วย .NET
linktitle: เฟรมรูปภาพ
type: docs
weight: 10
url: /th/net/picture-frame/
keywords:
- เฟรมรูปภาพ
- เพิ่มเฟรมรูปภาพ
- สร้างเฟรมรูปภาพ
- ภาพฝังไว้
- ภาพเชื่อมโยง
- ดึงภาพ
- ภาพเรสเตอร์
- ภาพ SVG
- ครอปภาพ
- ลบพื้นที่ที่ถูกครอป
- บีบอัดภาพ
- StretchOffset
- การจัดรูปแบบเฟรมรูปภาพ
- สเกลสัมพัทธ์
- เอฟเฟกต์ภาพ
- อัตราส่วนภาพ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สร้าง, จัดรูปแบบ, เชื่อมโยง, ครอป, ดึง, และบีบอัดเฟรมรูปภาพในงานนำเสนอด้วย Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

เฟรมรูปภาพคือรูปร่างสไลด์ที่แสดงภาพ ใน Aspose.Slides แหล่งภาพและรูปร่างที่แสดงภาพเป็นอ็อบเจกต์แยกกัน: a [งานนำเสนอ](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) เป็นเจ้าของทรัพยากรภาพที่ฝังอยู่ผ่านคอลเลกชัน [รูปภาพ](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/images/) ในขณะที่ [IPictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ipictureframe/) ควบคุมตำแหน่งของภาพ ขนาด การจัดรูปแบบเส้น การหมุน การครอป เอฟเฟกต์รูปภาพ และการตั้งค่าอื่น ๆ ระดับเฟรม

การแยกกันนี้มีประโยชน์เมื่อภาพเดียวกันแสดงหลายครั้ง เพิ่มภาพลงในงานนำเสนอครั้งเดียว เก็บ [IPPImage] ที่ได้กลับมาและใช้ทรัพยากรภาพนั้นเมื่อสร้างเฟรมรูปภาพ

เฟรมรูปภาพสามารถบรรจุภาพเรสเตอร์เช่น PNG หรือ JPEG และภาพเวกเตอร์ SVG ได้ พวกมันยังสามารถอ้างอิงถึงภาพที่เชื่อมโยงแทนการเก็บไบต์ของภาพไว้ในงานนำเสนอ ตัวเลือกนี้ส่งผลต่อความพกพา ขนาดไฟล์ การดึงข้อมูลและพฤติกรรมการส่งออก ดังนั้นจึงควรตัดสินใจว่าภาพควรจัดเก็บอย่างไรก่อนนำไปจัดรูปแบบหรือเพิ่มประสิทธิภาพ

## **เพิ่มและจัดรูปแบบภาพที่ฝังไว้**

สำหรับภาพที่ฝังไว้ ให้เพิ่มข้อมูลภาพลงในงานนำเสนอและสร้างเฟรมรูปภาพด้วย [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/addpictureframe/). ภาพจะเป็นส่วนหนึ่งของแพ็คเกจงานนำเสนอ ดังนั้นงานนำเสนอจะคงเป็นแบบอิสระเมื่อนำไปย้ายไปยังคอมพิวเตอร์เครื่องอื่น

ตัวอย่างต่อไปนี้เพิ่มภาพ JPEG สร้างเฟรมที่ขนาดดั้งเดิมของภาพและใช้การจัดรูปแบบเส้นและการหมุน:

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

เฟรมรูปภาพควบคุมเรขาคณิตที่แสดง; การเปลี่ยนขนาดเฟรมไม่ได้เปลี่ยนมิติพิกเซลเดิมที่เก็บในทรัพยากรภาพที่ฝังไว้ ความแตกต่างนี้สำคัญเมื่อต้องการครอปหรือบีบอัดภาพภายหลัง

## **ใช้สเกลสัมพัทธ์**

[IPictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ipictureframe/) เปิดเผยการสเกลความกว้างและความสูงแบบสัมพัทธ์สำหรับเฟรม ค่า `1.0` เทียบเท่ากับ 100% ของขนาดภาพดั้งเดิม สเกลสัมพัทธ์มีประโยชน์เมื่อขั้นตอนการทำงานต้องการรักษาความสัมพันธ์กับขนาดภาพต้นฉบับแทนการคำนวณขนาดสุดท้ายด้วยตนเอง

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

สเกลสัมพัทธ์เปลี่ยนการตั้งค่าสเกลของเฟรม; มันไม่ได้ทำการสุ่มตัวอย่างหรือบีบอัดภาพที่ฝังไว้

## **ภาพฝังและภาพเชื่อมโยง**

ภาพที่ฝังไว้เก็บข้อมูลภาพภายในงานนำเสนอจึงเป็นตัวเลือกที่ปลอดภัยที่สุดสำหรับความพกพาและการเรนเดอร์ที่คาดการณ์ได้ ภาพที่เชื่อมโยงจะเก็บตำแหน่งภายนอกผ่านเส้นทางลิงก์ของ [ISlidesPicture](https://reference.aspose.com/slides/th/net/aspose.slides/islidespicture/) แทนการฝังข้อมูลภาพในแบบเดียวกัน

ภาพที่เชื่อมโยงสามารถลดปริมาณข้อมูลภาพที่เก็บใน PPTX ได้ แต่จะทำให้เกิดการพึ่งพาภายนอก ไฟล์ที่เชื่อมโยงต้องสามารถเข้าถึงได้โดยแอปพลิเคชันที่เปิดหรือเรนเดอร์งานนำเสนอ หากเส้นทางเปลี่ยน ไฟล์ถูกย้าย หรือทรัพยากรไม่พร้อมใช้งาน ภาพที่เชื่อมโยงอาจไม่แสดงตามที่คาด หากต้องการส่งงานนำเสนอทางอีเมล เก็บถาวร หรือเรนเดอร์ในสภาพแวดล้อมแยกภาพที่ฝังไว้มักจะน่าเชื่อถือมากกว่า

### **เพิ่มภาพเชื่อมโยง**

ตัวอย่างต่อไปนี้สร้างเฟรมรูปภาพและชี้ไปที่ไฟล์ภาพในเครื่อง มันจัดการเฉพาะการเชื่อมโยงภาพ; การเชื่อมโยงวิดีโอเป็นขั้นตอนสื่อแยกต่างหากและไม่ได้ผสานเข้ากับตัวอย่างนี้โดยเจตนา

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

ใช้ลิงก์เมื่อการจัดการไฟล์ภายนอกเป็นจุดประสงค์ อย่าใช้เป็นเพียงการทดแทนการบีบอัด: PPTX ขนาดเล็กที่มีการพึ่งพาภาพเสียหายมักจะไม่มีประโยชน์เท่ากับงานนำเสนอที่อิสระและใหญ่กว่า

## **ดึงภาพจากเฟรมรูปภาพ**

ก่อนดึงภาพจากงานนำเสนอที่มีอยู่ ให้ตรวจสอบว่ารูปร่างเป็น [IPictureFrame] จริงและว่ามีภาพที่ฝังอยู่หรือไม่ เฟรมรูปภาพที่เชื่อมโยงอาจไม่มีไบต์ของภาพที่สามารถดึงได้ในลักษณะเดียวกัน

### **ดึงภาพเรสเตอร์**

API ภาพสมัยใหม่ใช้ [IImage] โดยตรงและไม่ต้องการตัวหุ้มระบบภาพเก่า ตัวอย่างต่อไปนี้ค้นหาภาพเรสเตอร์ที่ฝังอยู่แรกบนสไลด์และบันทึกเป็น PNG:

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

การบันทึกผ่าน [IImage] แปลงภาพที่ดึงออกเป็นรูปแบบเอาต์พุตที่ร้องขอ หากคุณต้องการไบต์ที่เข้ารหัสที่เก็บในงานนำเว็บไซต์แทนไฟล์เรสเตอร์ที่แปลงแล้ว ให้ใช้ข้อมูลไบนารีของทรัพยากรภาพแทน

### **ดึงภาพ SVG**

สำหรับภาพ SVG, [IPPImage] เปิดเผยอ็อบเจกต์ [ISvgImage] ซึ่งทำให้คุณดึงข้อมูล SVG โดยตรงแทนการเรสเตอร์ไลซ์ภาพก่อน

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

การเก็บเนื้อหา SVG เป็น SVG จะคงไว้ซึ่งแหล่งเวกเตอร์ภายในงานนำเสนอ การส่งออกสไลด์เป็นเรสเตอร์เช่น PNG หรือ JPEG จะต้องเรนเดอร์เนื้อหาเวกเตอร์เป็นพิกเซล การส่งออกสไลด์เป็น PDF หรือ SVG ก็เป็นการเรนเดอร์เช่นกัน ดังนั้นกราฟิกที่ส่งออกไม่ควรถือเป็นสำเนาไบต์ต่อไบต์ของ SVG ที่ฝังไว้; ให้ใช้ข้อมูล [ISvgImage] ที่ฝังไว้เมื่อจำเป็นต้องใช้ทรัพยากรเวกเตอร์ต้นฉบับ

## **ครอปภาพ**

การครอปเปลี่ยนส่วนของภาพที่มองเห็นได้ภายในเฟรม ค่าครอปบน [IPictureFillFormat] เป็นเปอร์เซ็นต์ของมิติภาพต้นฉบับ การครอปไม่ได้ลบพิกเซลที่ซ่อนอยู่จากภาพที่ฝังไว้ในตอนแรก; มันเพียงเปลี่ยนพื้นที่ที่มองเห็น

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

เนื่องจากข้อมูลภาพที่ซ่อนอยู่ยังคงอยู่ ค่าครอปสามารถเปลี่ยนได้ภายหลังโดยไม่สูญเสียพิกเซลเดิม หากขนาดไฟล์เป็นปัจจัยสำคัญกว่าการย้อนกลับ พื้นที่ที่ครอปสามารถลบออกจริงตามที่อธิบายในส่วนถัดไป

## **ลบข้อมูลภาพที่ถูกครอป**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) ลบข้อมูลภาพที่อยู่นอกสี่เหลี่ยมครอปปัจจุบันและคืนทรัพยากรภาพผลลัพธ์ วิธีนี้สามารถลดขนาดไฟล์ได้ แต่เป็นการเพิ่มประสิทธิภาพที่ทำลาย: หลังจากบันทึกงานนำเสนอแล้ว พิกเซลที่ถูกลบจะไม่มีอยู่สำหรับการยกเลิกครอปในภายหลัง

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

เมธอดนี้อาจเพิ่มทรัพยากรภาพใหม่ลงในงานนำเสนอ หากภาพต้นฉบับถูกใช้โดยเฟรมรูปภาพอื่น ๆ เฟรมเหล่านั้นยังต้องการทรัพยากรที่มีอยู่ ดังนั้นการลบพื้นที่ที่ครอปไม่ได้จำเป็นต้องลดจำนวนภาพทั้งหมด การครอปเนื้อหา WMF หรือ EMF ด้วยเมธอดนี้จะทำให้ผลลัพธ์ที่ครอปเป็นเรสเตอร์เป็น PNG

## **บีบอัดภาพเรสเตอร์**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/compressimage/) ลดความละเอียดของภาพเรสเตอร์สัมพันธ์กับขนาดที่แสดงภาพ สามารถลบพื้นที่ที่ครอปในขั้นตอนเดียวได้ เมธอดคืนค่า `true` เมื่อภาพถูกปรับขนาดหรือครอปและ `false` เมื่อไม่มีการเปลี่ยนแปลงใด ๆ จำเป็น

ใช้ค่าที่กำหนดล่วงหน้า [PicturesCompression](https://reference.aspose.com/slides/th/net/aspose.slides.export/picturescompression/) เมื่อความละเอียดเป้าหมายมาตรฐานเพียงพอ:

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

สามารถส่งค่าดีพีไอเป็นจำนวนเต็มบวกแทนค่าการอีนนัมเมื่อจำเป็นต้องมีเป้าหมายเฉพาะ

การบีบอัดออกแบบมาสำหรับภาพเรสเตอร์ SVG และเนื้อหาเมตาไฟล์จะไม่ได้รับการลดลงจากกระบวนการบีบอัดเรสเตอร์นี้ นอกจากนี้ควรจำไว้ว่า ความละเอียดที่ต่ำลงและพื้นที่ที่ครอปที่ถูกลบไม่สามารถกู้คืนจากงานนำเสนอที่ถูกเพิ่มประสิทธิภาพได้ เลือกความละเอียดเป้าหมายบนพื้นฐานของขนาดที่ใหญ่ที่สุดที่ภาพจะถูกมองหรือส่งออกจริง ๆ แทนการใช้ดีพีไอต่ำสุดทั่วทั้งไฟล์

## **ตรวจสอบเอฟเฟกต์ภาพ**

เอฟเฟกต์รูปภาพถูกเก็บบนรูปภาพที่ใช้โดยเฟรม คอลเลกชันการแปลงภาพอาจมีเอฟเฟกต์เช่นการปรับค่าแอลฟ่าคงที่สำหรับความโปร่งใสและลูมินานซ์สำหรับความสว่างและความคอนทราสต์ ตัวอย่างด้านล่างอ่านเอฟเฟกต์ทั้งสองประเภทจากเฟรมรูปภาพแรกบนสไลด์อย่างปลอดภัย:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    foreach (var effect in pictureFrame.PictureFormat.Picture.ImageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparency = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Transparency: " + transparency);
        }

        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            Console.WriteLine("Brightness: " + luminance.Brightness);
            Console.WriteLine("Contrast: " + luminance.Contrast);
        }
    }
}
```

เอฟเฟกต์เหล่านี้เปลี่ยนวิธีการเรนเดอร์ภาพในเฟรม; พวกมันไม่ได้เขียนทับไบต์ของภาพที่ฝังไว้เดิม

## **ล็อคเรขาคณิตของเฟรมรูปภาพ**

การตั้งค่า [IPictureFrameLock](https://reference.aspose.com/slides/th/net/aspose.slides/ipictureframelock/) ควบคุมการดำเนินการแก้ไขที่ถูกปิดการใช้งานสำหรับเฟรมรูปภาพ ตัวอย่างเช่น การล็อคอัตราส่วนภาพช่วยรักษาสัดส่วนของรูปร่างขณะปรับขนาด

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

การล็อคนี้ใช้กับรูปร่างของเฟรมรูปภาพ ไม่บังคับให้ภาพต้นฉบับต้องถูกสุ่มตัวอย่างหรือเปลี่ยนเป็นอัตราส่วนเดียวกันแบบถาวร

## **ปรับค่าการยืด StretchOffset**

เมื่อโหมดการเติมรูปภาพเป็นการยืด ค่าการยืด‑offset บน [IPictureFillFormat] กำหนดสี่เหลี่ยมเติมสัมพันธ์กับกล่องขอบของเฟรมรูปภาพ เปอร์เซ็นต์บวกสร้างการเว้นจากขอบ ในขณะที่เปอร์เซ็นต์ลบสร้างการขยายออก

นี่ต่างจากการครอป ค่าครอปเลือกส่วนของภาพต้นฉบับที่จะแสดง; การยืด‑offset เปลี่ยนสี่เหลี่ยมที่ภาพเติมที่มองเห็นถูกยืดเข้า

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

ใช้การยืด‑offset สำหรับการวางเติม ใช้คุณสมบัติกรอปเมื่อเป้าหมายคือซ่อนขอบของภาพต้นฉบับ

## **การจัดเก็บ ขนาดไฟล์ และข้อพิจารณาการส่งออก**

การตัดสินใจหลักจะง่ายต่อการจัดการเมื่อการจัดเก็บภาพและการจัดรูปแบบเฟรมรูปภาพถูกปฏิบัติเกี่ยวกับแยกกัน:

- **ภาพฝังไว้** ทำให้งานนำเสนอเป็นแบบอิสระและเป็นที่เชื่อถือได้ที่สุดสำหรับการแชร์และการเรนเดอร์ฝั่งเซิร์ฟเวอร์ แต่ภาพเรสเตอร์ขนาดใหญ่จะเพิ่มขนาด PPTX และการใช้หน่วยความจำ
- **ภาพเชื่อมโยง** สามารถทำให้แพ็กเกจเล็กลงได้ แต่งานนำเสนอจะพึ่งพาไฟล์ภายนอกที่ต้องยังคงเข้าถึงได้ตามเส้นทางหรือสถานที่ที่เก็บไว้
- **การครอป** เริ่มต้นเป็นแบบไม่ทำลาย พิกเซลที่ซ่อนอยู่ยังคงฝังไว้จนกว่าจะลบพื้นที่ที่ครอปโดยชัดเจนหรือระหว่างการบีบอัด
- **การบีบอัด** สามารถลดขนาดไฟล์อย่างมากสำหรับภาพเรสเตอร์ที่ใหญ่เกินไป แต่จะลดความละเอียดต้นฉบับ ควรทำหลังจากทราบขนาดที่แสดงบนสไลด์แล้ว
- **ภาพ SVG** ควรคงเป็น SVG เมื่อความคงทนของเวกเตอร์สำคัญ ดึง SVG ที่ฝังไว้โดยตรงเมื่อคุณต้องการทรัพยากรเวกเตอร์เอง การส่งออกสไลด์เป็นเรสเตอร์จะเปลี่ยนสไลด์ที่เรนเดอร์เป็นพิกเซลเสมอ
- **ภาพที่ซ้ำกัน** ควรใช้ทรัพยากร [IPPImage] ที่มีอยู่ใหม่เมื่อเป็นไปได้ แทนการโหลดไฟล์เดียวกันหลายครั้งเข้าสู่ขั้นตอนการทำงานของงานนำเสนอ

สำหรับงานนำเสนอขนาดใหญ่ การเพิ่มประสิทธิภาพภาพมักจะมีประสิทธิผลที่สุดเมื่อทำแบบเลือกเฉพาะ: เก็บโลโก้และแผนภูมิเพื่อเป็นเนื้อหาเวกเตอร์ บีบอัดภาพถ่ายตามขนาดการแสดงจริง ลบพิกเซลที่ครอปเฉพาะเมื่อไม่ต้องการแก้ไขต่อไป และหลีกเลี่ยงลิงก์ภายนอกเว้นแต่การจัดการการพึ่งพาจะเป็นส่วนหนึ่งของการออกแบบการปรับใช้

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างเฟรมรูปภาพและทรัพยากรภาพคืออะไร?**

[IPPImage] เป็นตัวแทนของทรัพยากรภาพที่เชื่อมโยงกับงานนำเสนอ ส่วน [IPictureFrame] เป็นรูปร่างบนสไลด์ที่แสดงภาพและเก็บเรขาคณิตและการจัดรูปแบบระดับเฟรม เช่น ขนาด การหมุน ค่าครอป เอฟเฟกต์และการล็อค

**ฉันควรฝังหรือเชื่อมโยงภาพหรือไม่?**

ควรฝังภาพเมื่อจำเป็นต้องให้งานนำเสนอพกพา สามารถเก็บถาวร หรือเรนเดอร์โดยไม่ต้องเข้าถึงทรัพยากรภายนอก ให้เชื่อมโยงภาพเฉพาะเมื่อต้องการเก็บไฟล์ภาพแยกออกและตำแหน่งภายนอกสามารถจัดการได้อย่างเชื่อถือได้

**การครอปทำให้ขนาดไฟล์ PPTX ลดลงหรือไม่?**

ไม่โดยตรง การตั้งค่าครอปปกติจะซ่อนส่วนของภาพต้นฉบับแต่ยังคงพิกเซลอยู่ ใช้ [IPictureFillFormat.DeletePictureCroppedAreas] หรือการบีบอัดพร้อมการลบพื้นที่ที่ครอปเมื่อพิกเซลเหล่านั้นสามารถทิ้งได้อย่างถาวร

**ฉันสามารถคืนคุณภาพภาพหลังการบีบอัดได้หรือไม่?**

ไม่ได้ การบีบอัดอาจลดความละเอียดเรสเตอร์ที่จัดเก็บและการลบพื้นที่ที่ครอปจะกำจัดข้อมูลภาพ ควรเก็บภาพต้นฉบับแยกไว้หากต้องการแก้ไขคุณภาพสูงในภายหลัง

**ควรจัดการกับภาพ SVG อย่างไร?**

ควรเก็บเนื้อหา SVG เป็น SVG เมื่อความคงทนของเวกเตอร์สำคัญ สามารถดึง [ISvgImage] ที่ฝังไว้โดยตรงเมื่อจำเป็นต้องใช้ทรัพยากรเวกเตอร์ การเรนเดอร์สไลด์เป็นรูปแบบเรสเตอร์เช่น PNG หรือ JPEG จะทำให้ SVG แปลงเป็นพิกเซล

**ฉันจะหลีกเลี่ยงการแคสต์ที่ไม่ปลอดภัยเมื่อตรวจสอบสไลด์ที่มีอยู่ได้อย่างไร?**

ตรวจสอบประเภทของรูปร่างก่อนใช้สมาชิกเฉพาะเฟรมรูปภาพ การจับคู่แบบ pattern ด้วย [IPictureFrame] หรือการกรองคอลเลกชันรูปร่างตามอินเทอร์เฟซนั้นช่วยหลีกเลี่ยงการแคสต์ที่ไม่ถูกต้องและทำให้โค้ดจัดการกับสไลด์ที่ไม่มีเฟรมรูปภาพได้อย่างปลอดภัย