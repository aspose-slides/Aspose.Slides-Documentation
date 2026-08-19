---
title: เพิ่มประสิทธิภาพการจัดการรูปภาพในงานนำเสนอด้วย .NET
linktitle: จัดการรูปภาพ
type: docs
weight: 10
url: /th/net/image/
keywords:
- เพิ่มรูปภาพ
- เพิ่มรูป
- แทนที่รูปภาพ
- คอลเลกชันรูปภาพ
- กรอบรูป
- รูปภาพเชื่อมโยง
- พื้นหลัง
- เพิ่ม PNG
- เพิ่ม JPG
- เพิ่ม SVG
- SVG เป็นรูปร่าง
- แหล่ง SVG ภายนอก
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่ม ใช้ซ้ำ เชื่อมโยง แทนที่ และจัดการรูปภาพแบบแรสเตอร์และ SVG ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ .NET."
---
## **คำนำ**

Aspose.Slides for .NET มีวิธีการทำงานกับรูปภาพหลายวิธี ซึ่งแต่ละวิธีมีจุดประสงค์ที่แตกต่างกัน คุณสามารถเก็บรูปภาพไว้ในงานนำเสนอ แสดงในกรอบรูป ใช้เป็นพื้นหลังสไลด์ เชื่อมโยงไปยังรูปภาพภายนอก แทนที่แหล่งข้อมูลรูปภาพที่ใช้ร่วมกัน หรือแปลงเนื้อหา SVG เป็นรูปร่างที่แก้ไขได้

บทความนี้มุ่งเน้นที่แหล่งข้อมูลรูปภาพและวิธีการใช้ในงานนำเสนอทั้งหมด สำหรับการครอบตัด ความโปร่งใส การใส่เอฟเฟ็กต์ การยืดและการจัดรูปแบบอื่น ๆ ที่ใช้กับกรอบรูปแต่ละกรอบ ดูที่ [Picture Frame](/slides/th/net/picture-frame/)

## **ทำความเข้าใจโมเดลรูปภาพ**

แนวคิด API ต่อไปนี้เกี่ยวข้องกันอย่างใกล้ชิดแต่ไม่สามารถทดแทนกันได้:

- [presentation image collection](https://reference.aspose.com/slides/th/net/aspose.slides/iimagecollection/) เก็บแหล่งข้อมูลรูปภาพที่ใช้ในงานนำเสนอ ใช้ [ImageCollection.AddImage](https://reference.aspose.com/slides/th/net/aspose.slides/imagecollection/addimage/) เพื่อเพิ่มข้อมูลรูปภาพและรับแหล่งข้อมูล [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/)
- [picture frame](https://reference.aspose.com/slides/th/net/aspose.slides/ipictureframe/) คือรูปร่างที่แสดงรูปภาพบนสไลด์ เลย์เอาต์ หรือมาสเตอร์ ใช้ [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/addpictureframe/) เพื่อวางแหล่งข้อมูลรูปภาพบนสไลด์
- พื้นหลังสไลด์ใช้รูปภาพเป็นส่วนหนึ่งของการเติมสไลด์ ไม่ได้ทำงานเหมือนกรอบรูป
- [IPPImage.ReplaceImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/replaceimage/) แทนที่แหล่งข้อมูลรูปภาพ หากหลายองค์ประกอบของงานนำใช้แหล่งนั้นทั้งหมดจะใช้ภาพที่แทนที่
- การแปลง SVG เป็นรูปร่างจะสร้างรูปร่างสไลด์ที่แก้ไขได้ หลังการแปลง เนื้อหาไม่ถูกจัดการเป็นรูปภาพเดียวอีกต่อไป

กระบวนการทำงานทั่วไปคือ: เพิ่มข้อมูลรูปภาพเข้าสู่คอลเล็กชัน รับ [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) แล้วใช้แหล่งนั้นในกรอบรูปหรือการเติมหลาย ๆ รูป

## **เพิ่มรูปภาพที่ฝังไว้**

เพื่อแทรกรูปภาพจากไฟล์ท้องถิ่น อ่านไฟล์ เพิ่มข้อมูลลงในคอลเล็กชันรูปภาพ และสร้างกรอบรูปที่ใช้ `IPPImage` ที่คืนค่า

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

รูปภาพที่เพิ่มด้วยวิธีนี้จะฝังอยู่ในงานนำเสนอ ดังนั้นไฟล์ที่ได้จึงไม่พึ่งพาไฟล์รูปภาพต้นฉบับที่ยังคงอยู่

### **เพิ่มรูปภาพจากเว็บ**

เมื่อรูปภาพสามารถเข้าถึงได้ผ่าน HTTP หรือ HTTPS ให้ดาวน์โหลดไบต์ด้วย `HttpClient` เพิ่มลงในคอลเล็กชันรูปภาพของงานนำเสนอ และใช้แหล่งรูปภาพที่คืนค่าเช่นเดียวกับรูปภาพท้องถิ่น

```csharp
using System;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

var imageUri = new Uri("https://example.com/image.png");
using var httpClient = new HttpClient();
var imageData = await httpClient.GetByteArrayAsync(imageUri);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(imageData);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation-from-web.pptx", SaveFormat.Pptx);
```

ในแอปพลิเคชันที่ทำงานเป็นเวลานาน ควรใช้ `HttpClient` ซ้ำแทนการสร้างอินสแตนซ์ใหม่สำหรับทุกคำขอ นอกจากนี้ควรตรวจสอบ URL ระยะไกล ขนาดการตอบสนอง และประเภทเนื้อหาเมื่อแหล่งที่มามิ่นเชื่อถือ

## **ใช้รูปภาพซ้ำในหลายสไลด์**

หากต้องการใช้รูปเดียวกันหลายครั้ง ให้เพิ่มภาพนั้นเข้าสู่งานนำเสนอครั้งเดียวแล้วใช้ [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) ที่รับคืนเมื่อต้องสร้างกรอบรูปเพิ่มเติม วิธีนี้ช่วยหลีกเลี่ยงการโหลดข้อมูลแหล่งเดียวกันซ้ำหลายครั้ง และทำให้ความสัมพันธ์ระหว่างแหล่งรูปภาพที่ใช้ร่วมกันกับการใช้ของมันชัดเจน

สำหรับกราฟิกที่ควรปรากฏอัตโนมัติบนหลายสไลด์ เช่น โลโก้บริษัท ให้พิจารณาวางกรอบรูปบน [slide master](/slides/th/net/slide-master/) หรือเลย์เอาต์ แทนการเพิ่มรูปร่างที่เทียบเท่าในแต่ละสไลด์

## **ใช้รูปภาพเป็นพื้นหลังสไลด์**

รูปภาพพื้นหลังถูกกำหนดให้กับการเติมสไลด์ ไม่ได้ถูกเพิ่มเป็นรูปร่างกรอบรูป วิธีนี้เหมาะเมื่อต้องการให้รูปภาพครอบพื้นหลังสไลด์และไม่ต้องการจัดการเป็นออบเจกต์สไลด์ปกติ

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("background.jpg");
var image = presentation.Images.AddImage(imageData);
slide.Background.Type = BackgroundType.OwnBackground;
slide.Background.FillFormat.FillType = FillType.Picture;
slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
slide.Background.FillFormat.PictureFillFormat.Picture.Image = image;

presentation.Save("background-image.pptx", SaveFormat.Pptx);
```

สำหรับตัวเลือกพื้นหลังเพิ่มเติม รวมถึงพื้นหลังมาสเตอร์และเลย์เอาต์ ให้ดูที่ [Presentation Background](/slides/th/net/presentation-background/)

## **รูปภาพฝังและรูปภาพเชื่อมโยง**

รูปภาพฝังและรูปภาพเชื่อมโยงมีข้อดีข้อเสียเรื่องความพกพาและขนาดไฟล์ต่างกัน:

- **รูปภาพฝัง:** ข้อมูลรูปภาพถูกเก็บอยู่ภายในงานนำเสนอ งานนำเสนอเป็นไฟล์เดียวแต่ขนาดไฟล์รวมข้อมูลรูปภาพ
- **รูปภาพเชื่อมโยง:** งานนำจัดเก็บเส้นทางหรือ URL ไปยังรูปภาพภายนอก ซึ่งอาจลดขนาดงานนำเสนอได้ แต่ต้องให้แหล่งภายนอกสามารถเข้าถึงได้เมื่อเปิดหรือแสดงผลงานนำเสนอ

สามารถสร้างรูปภาพเชื่อมโยงโดยกำหนดเส้นทางหรือ URL ภายนอกผ่าน [ISlidesPicture.LinkPathLong](https://reference.aspose.com/slides/th/net/aspose.slides/islidespicture/linkpathlong/) แทนการฝังข้อมูลรูปภาพ

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = "https://example.com/image.png";

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

ใช้รูปภาพเชื่อมโยงเฉพาะเมื่อสภาพแวดล้อมการปรับใช้เข้าถึงแหล่งภายนอกได้อย่างเชื่อถือได้ สำหรับงานนำเสนอที่ต้องทำงานแบบออฟไลน์หรือย้ายระหว่างระบบ รูปภาพฝังมักปลอดภัยกว่า

## **ทำงานกับรูปภาพ SVG**

SVG เป็นฟอร์แมตเวกเตอร์ จึงเหมาะสำหรับไอคอน ไดอะแกรม และกราฟิกอื่น ๆ ที่ต้องการขยายโดยไม่สูญเสียรายละเอียดเหมือนรูปภาพแรสเตอร์ Aspose.Slides รองรับ SVG ทั้งเป็นแหล่งข้อมูลรูปภาพและเป็นแหล่งสำหรับรูปร่างสไลด์ที่แก้ไขได้

### **เพิ่ม SVG เป็นรูปภาพ**

สร้าง [SvgImage](https://reference.aspose.com/slides/th/net/aspose.slides/svgimage/) เพิ่มลงในคอลเล็กชันรูปภาพ และวางแหล่งข้อมูลรูปภาพที่ได้ในกรอบรูป

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("icon.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(svgImage);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

presentation.Save("svg-image.pptx", SaveFormat.Pptx);
```

### **ไฟล์ SVG ที่มีแหล่งภายนอก**

SVG สามารถอ้างอิงรูปภาพ สไตล์ชีต หรือฟอนต์จากภายนอก สำหรับกรณีเหล่านี้ [SvgImage](https://reference.aspose.com/slides/th/net/aspose.slides/svgimage/) มีคอนสตรัคเตอร์ที่รับ [IExternalResourceResolver](https://reference.aspose.com/slides/th/net/aspose.slides.import/iexternalresourceresolver/) และ URI พื้นฐาน ตัวแก้ไขสามารถแมป URI เชิงสัมพันธ์เป็น URI เชิงสัมบูรณ์ที่อนุญาตและคืนสตรีมสำหรับแหล่งที่ร้องขอ

ตัวแก้ไขทำให้แหล่งภายนอกพร้อมใช้งานขณะ Aspose.Slides ประมวลผล SVG แต่จะไม่เขียนใหม่ SVG ให้เป็นเอกสารที่แยกตัวเองได้ หาก SVG ต้องคงความพกพา ให้ฝังแหล่งที่จำเป็นไว้ใน SVG เอง เช่น ใช้ URI แบบ `data:` สำหรับรูปภาพเชื่อมโยง

เมื่อไฟล์ SVG มาจากแหล่งที่ไม่เชื่อถือ ควรจำกัดสกีม ไฟล์โลเคชัน และโฮสต์ที่ตัวแก้ไขสามารถเข้าถึงได้ ตัวแก้ไขเครือข่ายควรกำหนด timeout ขีดจำกัดขนาดการตอบสนองและการตรวจสอบความถูกต้องของเนื้อหา

### **แปลง SVG เป็นรูปร่างแก้ไขได้**

Aspose.Slides สามารถแปลง SVG เป็นกลุ่มรูปร่างสไลด์ที่แก้ไขได้ คล้ายกับคำสั่งใน PowerPoint

![PowerPoint Popup Menu](img_01_01.png)

ใช้ [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/addgroupshape/) ที่รับ [ISvgImage](https://reference.aspose.com/slides/th/net/aspose.slides/isvgimage/) เพื่อทำการแปลง

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("diagram.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[0];
slide.Shapes.AddGroupShape(svgImage, 0, 0, slideSize.Width, slideSize.Height);

presentation.Save("editable-svg-shapes.pptx", SaveFormat.Pptx);
```

ใช้การแปลง SVG‑to‑shapes เมื่อองค์ประกอบเวกเตอร์แต่ละอันต้องการการแก้ไขเป็นรูปร่าง PowerPoint หาก SVG ต้องการเพียงแสดงผล การเก็บไว้เป็นรูปภาพจะง่ายกว่าและหลีกเลี่ยงการสร้างรูปร่างแยกหลายอัน

## **แทนที่แหล่งรูปภาพที่มีอยู่**

ใช้ [IPPImage.ReplaceImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/replaceimage/) เมื่อคุณต้องการแทนที่แหล่งรูปภาพที่มีอยู่ ซึ่งเป็นประโยชน์มากสำหรับกราฟิกที่ใช้ร่วมกันเช่นโลโก้

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var imageToReplace = presentation.Images[0];
imageToReplace.ReplaceImage(File.ReadAllBytes("new-logo.png"));

presentation.Save("output.pptx", SaveFormat.Pptx);
```

หากหลายกรอบรูป พื้นหลัง มาสเตอร์ หรือเลย์เอาต์ใช้แหล่งรูปเดียวกัน การแทนที่แหล่งนั้นจะอัปเดตการใช้ทั้งหมด หากต้องการเปลี่ยนกรอบรูปเพียงอันเดียว ให้กำหนดรูปภาพอื่นให้กับกรอบนั้นแทนการแทนที่แหล่งที่ใช้ร่วมกัน

`ReplaceImage` ยังมีโอเวอร์โหลดที่รับ [IImage](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/) หรือ [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) อื่น ๆ อีกด้วย

## **แนวทางการจัดการรูปภาพเชิงปฏิบัติ**

### **ควบคุมขนาดงานนำเสนอ**

รูปแรสเตอร์ที่มีขนาดใหญ่ทำให้งานนำเสนอใหญ่เกินจำเป็น ใช้รูปภาพต้นฉบับที่มีมิติเหมาะสมกับขนาดการแสดงที่ต้องการ ใช้แหล่งรูปภาพที่ใช้ร่วมกันเมื่อทำได้ และหลีกเลี่ยงการฝังสำเนาเต็มความละเอียดเดียวกันหลายครั้ง

สำหรับรูปแรสเตอร์ที่ได้ถูกวางไว้ในกรอบรูปแล้ว [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/compressimage/) สามารถลดข้อมูลรูปภาพตามความละเอียดและการครอบที่เลือกได้ สิ่งนี้เป็นการประมวลผลกรอบรูป ไม่ใช่การจัดการคอลเล็กชันรูปภาพ ดังนั้นดูที่ [Picture Frame](/slides/th/net/picture-frame/) เพื่อทำการจัดรูปแบบที่เกี่ยวข้อง

### **เลือกใช้ระหว่างเนื้อหาแบบฝังและแบบเชื่อมโยง**

การฝังทำให้งานนำเสนอพกพาได้ง่ายเนื่องจากข้อมูลรูปทั้งหมดอยู่ในไฟล์เดียว การเชื่อมโยงอาจลดขนาดไฟล์แต่เพิ่มการพึ่งพาแหล่งภายนอก ใช้ลิงก์เฉพาะเมื่อการพึ่งพานั้นยอมรับได้และเสถียร

### **ใช้แบรนด์ที่แชร์ร่วมกัน**

สำหรับโลโก้ น้ำหนักน้ำ หรือกราฟิกตกแต่งที่ใช้ซ้ำ ให้ใช้แหล่งรูปภาพเดียวและนำกลับมาใช้ใหม่ หากกราฟิกเป็นส่วนของการออกแบบงานนำเสนอ มากกว่าข้อความสไลด์ ให้วางไว้บนมาสเตอร์หรือเลย์เอาต์เพื่อให้สไลด์ที่เกี่ยวข้องสืบทอดอัตโนมัติ

### **ทำให้แหล่ง SVG พกพาได้**

SVG ที่เป็นไฟล์เดียวทำให้ย้ายและแสดงผลได้สม่ำเสมอกว่าที่ต้องพึ่งพาไฟล์หรือแหล่งเครือข่ายภายนอก หากทำได้ ให้ฝังแหล่งที่จำเป็นก่อนนำเข้า SVG แปลง SVG เป็นรูปร่างเฉพาะเมื่อจำเป็นต้องแก้ไของค์ประกอบเวกเตอร์แต่ละอัน

### **ใช้ Modern Cross-Platform Image API**

สำหรับโค้ด .NET ใหม่ ให้ใช้ API ของ Aspose.Slides ได้แก่ [IImage](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/) และ [Images](https://reference.aspose.com/slides/th/net/aspose.slides/images/) แทนการพึ่งพา `System.Drawing.Image` หรือ `Bitmap` ดูที่ [Modern API](/slides/th/net/modern-api/) เพื่อแนวทางการย้าย

WMF และ EMF ต้องพิจารณาเป็นพิเศษ เมื่อฟอร์แมตเหล่านี้ถูกส่งผ่าน [IImage](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/) การใช้ [ImageCollection.AddImage](https://reference.aspose.com/slides/th/net/aspose.slides/imagecollection/addimage/) จะเปลี่ยนเมตาไฟล์เป็น PNG แรสเตอร์ก่อนแทรก หากต้องการรักษาข้อมูลเมตาไฟล์ ควรใช้โอเวอร์โหลดแบบสตรีมของ [ImageCollection.AddImage](https://reference.aspose.com/slides/th/net/aspose.slides/imagecollection/addimage/) การสร้างเนื้อหา EMF จากสเปรดชีตหรือผลิตภัณฑ์อื่นเป็นเวิร์กโฟลว์การรวมแยกต่างหากและอยู่นอกขอบเขตของบทความนี้

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่าง image collection กับ picture frame คืออะไร?**

image collection เก็บแหล่งรูปภาพที่สามารถใช้ซ้ำได้ picture frame เป็นรูปร่างบนสไลด์ที่แสดงหนึ่งในแหล่งเหล่านั้นและให้การจัดรูปแบบเฉพาะของรูปภาพเช่นการครอบและเอฟเฟ็กต์

**วิธีที่ดีที่สุดในการแทนที่โลโก้เดียวกันทั่วทั้งงานนำเสนอคืออะไร?**

หากโลโก้ถูกแชร์เป็นแหล่งรูปภาพเดียว ให้แทนที่แหล่งนั้นด้วย [IPPImage.ReplaceImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/replaceimage/) สำหรับการแบรนด์ระดับงานนำเสนอ การวางโลโก้บนมาสเตอร์หรือเลย์เอาต์ก็ช่วยลดเนื้อหาซ้ำในสไลด์ได้เช่นกัน

**ทำไมรูปภาพเชื่อมโยงถึงหายไปบนคอมพิวเตอร์เครื่องอื่น?**

รูปภาพเชื่อมโยงพึ่งพาไฟล์หรือ URL ภายนอก หากแหล่งนั้นไม่สามารถเข้าถึงได้จากคอมพิวเตอร์เครื่องอื่น รูปภาพเชื่อมโยงอาจไม่ปรากฏ ให้ฝังรูปภาพเมื่อจำเป็นต้องให้งานนำเสนอเป็นไฟล์เดียว

**สามารถแก้ไข SVG ที่แทรกแล้วเป็นรูปร่าง PowerPoint ได้หรือไม่?**

ได้ ใช้ [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/addgroupshape/) เพื่อแปลง SVG; กลุ่มที่ได้จะมีรูปร่างสไลด์ที่แก้ไขได้แทนการเป็นรูป SVG เดียว

**จะทำอย่างไรให้งานนำเสนอที่มีรูปภาพหลายรูปมีขนาดเล็กลง?**

ใช้แหล่งรูปภาพที่ใช้ร่วมกัน หลีกเลี่ยงแหล่งแรสเตอร์ที่ใหญ่เกินจำเป็น บีบอัดรูปแรสเตอร์ที่เหมาะสมเมื่อจำเป็น เก็บแบรนด์ที่ซ้ำกันบนมาสเตอร์หรือเลย์เอาต์ และใช้รูปภาพเชื่อมโยงเฉพาะเมื่อการพึ่งพาแหล่งภายนอกรับได้