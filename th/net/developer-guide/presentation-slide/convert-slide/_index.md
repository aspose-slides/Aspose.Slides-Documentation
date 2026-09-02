---
title: แปลงสไลด์การนำเสนอเป็นภาพใน .NET
linktitle: สไลด์เป็นภาพ
type: docs
weight: 41
url: /th/net/convert-slide/
keywords:
- แปลงสไลด์
- ส่งออกสไลด์
- สไลด์เป็นภาพ
- บันทึกสไลด์เป็นภาพ
- สไลด์เป็น EMF
- สไลด์เป็น PNG
- สไลด์เป็น JPEG
- สไลด์เป็นบิตแมพ
- สไลด์เป็น TIFF
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "แปลงสไลด์จากการนำเสนอรูปแบบ PPT, PPTX และ ODP เป็น PNG, JPEG, GIF, TIFF, EMF และรูปแบบภาพอื่น ๆ ด้วย C# และ Aspose.Slides สำหรับ .NET."
---
## **บทนำ**

Aspose.Slides สำหรับ .NET สามารถแสดงสไลด์แต่ละสไลด์จากการนำเสนอ PowerPoint และ OpenDocument เป็นรูปแบบ PNG, JPEG, GIF, TIFF และรูปแบบภาพอื่น ๆ

เพื่อแปลงสไลด์เป็นภาพ ให้ทำตามขั้นตอนต่อไปนี้:

1. โหลดการนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) .
2. เลือกสไลด์ที่คุณต้องการเรนเดอร์.
3. หากจำเป็น ให้กำหนดค่าการเรนเดอร์ด้วยคลาส [RenderingOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/renderingoptions/) หรือ [TiffOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/) .
4. เรียกเมธอด [GetImage](https://reference.aspose.com/slides/th/net/aspose.slides/islide/getimage/) เมธอดนี้จะคืนค่าอ็อบเจ็กต์ [IImage](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/) .
5. เรียกเมธอด [IImage.Save](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/save/) และระบุรูปแบบเอาต์พุตด้วยค่า [ImageFormat](https://reference.aspose.com/slides/th/net/aspose.slides/imageformat/) .

## **แปลงสไลด์เป็นภาพ PNG**

การแปลงที่ง่ายที่สุดใช้การตั้งค่าเรนเดอร์เริ่มต้น อ็อบเจ็กต์ [IImage](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/) ที่ได้สามารถประมวลผลในหน่วยความจำหรือบันทึกเป็นไฟล์ได้

ตัวอย่าง C# ด้านล่างนี้เรนเดอร์สไลด์แรกและบันทึกเป็นภาพ PNG:

```cs
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage();
image.Save("Slide_0.png", ImageFormat.Png);
```

## **แปลงสไลด์เป็นภาพด้วยขนาดกำหนดเอง**

ใช้เมธอดโอเวอร์โหลดของ [GetImage](https://reference.aspose.com/slides/th/net/aspose.slides/islide/getimage/) ที่รับค่า [Size](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.size) เพื่อเรนเดอร์สไลด์ด้วยขนาดพิกเซลที่แม่นยำ

ตัวอย่างต่อไปนี้สร้างภาพ JPEG ขนาด 1820 × 1040 พิกเซล:

```cs
using System.Drawing;
using Aspose.Slides;

var imageSize = new Size(1820, 1040);

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(imageSize);
image.Save("Slide_0.jpg", ImageFormat.Jpeg);
```

## **แปลงสไลด์พร้อมโน้ตและคอมเมนต์เป็นภาพ**

โดยค่าเริ่มต้น ภาพสไลด์จะไม่รวมโน้ตหรือคอมเมนต์ ให้กำหนดอ็อบเจ็กต์ [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/notescommentslayoutingoptions/) ให้กับคุณสมบัติ [RenderingOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/renderingoptions/slideslayoutoptions/) เพื่อควบคุมตำแหน่งที่โน้ตและคอมเมนต์ปรากฏ

ตัวอย่างต่อไปนี้วางโน้ตที่ถูกตัดทอนไว้ด้านล่างสไลด์และคอมเมนต์อยู่ทางด้านขวา:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var scaleX = 2f;
var scaleY = scaleX;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated,
    CommentsPosition = CommentsPositions.Right,
    CommentsAreaWidth = 500,
    CommentsAreaColor = Color.AntiqueWhite
};

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layoutOptions };

using var presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(renderingOptions, scaleX, scaleY);
image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
```

{{% alert title="Warning" color="warning" %}}
สำหรับการแปลงสไลด์เป็นภาพ อย่าตั้งค่าคุณสมบัติ [NotesPosition](https://reference.aspose.com/slides/th/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) เป็น [BottomFull](https://reference.aspose.com/slides/th/net/aspose.slides.export/notespositions/). โน้ตอาจมีข้อความมากกว่าขนาดภาพที่กำหนด ใช้ [BottomTruncated](https://reference.aspose.com/slides/th/net/aspose.slides.export/notespositions/) แทน
{{% /alert %}}

## **แปลงสไลด์เป็นภาพโดยใช้ TIFF Options**

คลาส [TiffOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/) ช่วยให้คุณควบคุมขนาด ความละเอียด และคุณสมบัติอื่น ๆ ของภาพ TIFF ที่เรนเดอร์

ตัวอย่างต่อไปนี้เรนเดอร์สไลด์แรกเป็นภาพ TIFF ขนาด 2160 × 2880 พิกเซล ที่ 300 DPI:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var tiffOptions = new TiffOptions
{
    ImageSize = new Size(2160, 2880),
    DpiX = 300,
    DpiY = 300
};

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(tiffOptions);
image.Save("output.tiff", ImageFormat.Tiff);
```

## **แปลงสไลด์ทั้งหมดเป็นภาพ**

วนรอบคอลเลกชันสไลด์เพื่อแปลงการนำเสนอทั้งหมดเป็นชุดของภาพ สไลด์ที่ซ่อนอยู่จะถูกรวมด้วย เว้นแต่คุณจะข้ามอย่างเจตนา

ตัวอย่างต่อไปนี้เรนเดอร์ทุกสไลด์เป็นภาพ JPEG โดยใช้สเกลแนวนอนและแนวตั้งที่ 2:

```cs
using Aspose.Slides;

var scaleX = 2f;
var scaleY = scaleX;

using var presentation = new Presentation("Presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"Slide_{index}.jpg", ImageFormat.Jpeg);
}
```

## **สร้างเอาต์พุต Enhanced Metafile**

Enhanced Metafile (EMF) มีประโยชน์เมื่อกราฟิกแบบเวกเตอร์ต้องแลกเปลี่ยนกับ Microsoft Office หรือแอปพลิเคชัน Windows อื่น ๆ ที่รองรับ Windows metafile ต่างจากภาพแบบพิกเซล EMF สามารถเก็บการวาดเวกเตอร์ที่ขยายได้โดยไม่เสียความคมชัด อย่างไรก็ตาม EMF เป็นรูปแบบความเข้ากันได้หลักสำหรับแอปพลิเคชันที่รองรับ Windows metafile ไม่ใช่รูปแบบการแลกเปลี่ยนสากล นอกจากนี้ เนื้อหาสไลด์ที่ซับซ้อน เช่น ภาพบิตแมพและเอฟเฟกต์บางอย่าง อาจถูกเก็บเป็นองค์ประกอบแบบแรสเตอร์ในคอนเทนเนอร์เวกเตอร์เมตาไฟล์

### **ส่งออกสไลด์เป็น EMF**

เมธอด [ISlide.WriteAsEmf](https://reference.aspose.com/slides/th/net/aspose.slides/islide/writeasemf/) เขียนอ็อบเจ็กต์ [ISlide](https://reference.aspose.com/slides/th/net/aspose.slides/islide/) ไปยังสตรีมเป้าหมายในรูปแบบ EMF ตัวอย่างต่อไปนี้โหลดการนำเสนอ เลือกสไลด์แรกและเขียนลงสตรีมไฟล์ EMF:

```cs
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var emfStream = File.Create("Slide_0.emf");
slide.WriteAsEmf(emfStream);
```

ผู้เรียกต้องเป็นเจ้าของสตรีมที่ส่งให้กับ [ISlide.WriteAsEmf](https://reference.aspose.com/slides/th/net/aspose.slides/islide/writeasemf/) และต้องปิดหรือทำลายมัน Aspose.Slides จะเขียนที่ตำแหน่งปัจจุบันของสตรีมและทิ้งสตรีมเปิดไว้

### **แปลงภาพ SVG เป็น EMF แล้วเพิ่มลงในการนำเสนอ**

ใช้ [ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/th/net/aspose.slides/isvgimage/writeasemf/) เพื่อแปลงเนื้อหา SVG เป็น EMF ไบต์ที่ได้สามารถเพิ่มลงในการนำเสนอผ่าน [IImageCollection.AddImage](https://reference.aspose.com/slides/th/net/aspose.slides/iimagecollection/addimage/) และวางบนสไลด์ด้วย [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/addpictureframe/).

ตัวอย่างต่อไปนี้สร้าง [SvgImage](https://reference.aspose.com/slides/th/net/aspose.slides/svgimage/) จาก markup ของ SVG แปลงเป็น EMF ในหน่วยความจำ แทรกเมตาไฟล์ลงสไลด์แรก และบันทึกการนำเสนอ:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var emfStream = new MemoryStream();
svgImage.WriteAsEmf(emfStream);

emfStream.Position = 0;
var image = presentation.Images.AddImage(emfStream);
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);

presentation.Save("Presentation_with_emf.pptx", SaveFormat.Pptx);
```

[ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/th/net/aspose.slides/isvgimage/writeasemf/) ไม่ได้เป็นเจ้าของสตรีมปลายทาง หลังจากเขียนตำแหน่งของสตรีมจะอยู่ที่ส่วนท้ายของข้อมูลที่สร้างขึ้น รีเซ็ต `Position` ไปที่จุดเริ่มต้นก่อนส่งสตรีมที่สามารถเลื่อนได้เดียวกันให้กับรีดเดอร์ตามที่แสดงข้างต้น เก็บสตรีมเปิดไว้จนกว่าผู้บริโภคจะอ่านเสร็จแล้วทำลายภายหลัง หรือเรียก `ToArray` แล้วส่งอาเรย์ไบต์ที่คืนให้กับ [IImageCollection.AddImage](https://reference.aspose.com/slides/th/net/aspose.slides/iimagecollection/addimage/); `ToArray` จะคืนบัฟเฟอร์เต็มแม้ตำแหน่งสตรีมปัจจุบันจะอยู่ที่ใด

การสร้าง EMF มีให้ใช้บนระบบปฏิบัติการที่สนับสนุนโดยการสร้าง Aspose.Slides for .NET ที่เลือก แต่การเรนเดอร์อาจแตกต่างกันในแพลตฟอร์มที่ไม่มีฟอนต์หรือการพึ่งพากราฟิกเนทีฟ ติดตั้งฟอนต์ที่ใช้ในเนื้อหาแหล่งหรือกำหนดการทดแทนที่เหมาะสม ปฏิบัติตาม [platform requirements](/slides/th/net/system-requirements/) สำหรับแพ็กเกจ Aspose.Slides ของคุณ และตรวจสอบผลลัพธ์ในแอปพลิเคชันที่รับ EMF เป้าหมาย แอปพลิเคชันบน Linux และ macOS มักมีการสนับสนุนที่จำกัดหรือไม่สอดคล้องในการแสดงและแก้ไข Windows metafiles

## **การเรนเดอร์อีโมจีสี**

{{% alert title="Note" color="info" %}}
เพื่อให้เรนเดอร์อีโมจีสีได้อย่างถูกต้องเมื่อแปลงสไลด์การนำเสนอเป็นภาพ ฟอนต์อีโมจีที่ใช้ในการนำเข้าต้องติดตั้งและพร้อมใช้งานบนระบบที่ทำการแปลง ตัวอย่างเช่น หากการนำเสนอใช้ **Segoe UI Emoji** แต่ฟอนต์นี้ไม่มีอยู่ อีโมจีอาจปรากฏเป็นสีเดียวในภาพผลลัพธ์
{{% /alert %}}

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับการเรนเดอร์สไลด์พร้อมแอนิเมชันหรือไม่?**

ไม่. เมธอด [GetImage](https://reference.aspose.com/slides/th/net/aspose.slides/islide/getimage/) เรนเดอร์ภาพนิ่งของสไลด์และไม่ส่งออกแอนิเมชัน

**สามารถส่งออกสไลด์ที่ซ่อนอยู่เป็นภาพได้หรือไม่?**

ได้. สไลด์ที่ซ่อนสามารถเรนเดอร์ได้เช่นสไลด์ปกติ รวมไว้ในลูปการประมวลผลตามที่แสดงในตัวอย่างข้างต้น

**เงาและเอฟเฟกต์อื่น ๆ ถูกเก็บไว้ในภาพสไลด์หรือไม่?**

ได้. Aspose.Slides จะเรนเดอร์เงา ความโปร่งแสง และเอฟเฟกต์กราฟิกที่รองรับอื่น ๆ ในภาพสไลด์