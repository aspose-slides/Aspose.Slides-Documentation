---
title: "จัดการรายการแบบมีสัญลักษณ์และลำดับเลขในงานนำเสนอด้วย .NET"
linktitle: "จัดการรายการ"
type: docs
weight: 70
url: /th/net/manage-lists/
aliases:
  - /net/manage-bullet-and-numbered-lists/
keywords:
  - สัญลักษณ์
  - รายการแบบมีสัญลักษณ์
  - รายการลำดับเลข
  - สัญลักษณ์สัญลักษณ์
  - สัญลักษณ์รูปภาพ
  - สัญลักษณ์กำหนดเอง
  - รายการหลายระดับ
  - สร้างสัญลักษณ์
  - เพิ่มสัญลักษณ์
  - เพิ่มรายการ
  - PowerPoint
  - OpenDocument
  - งานนำเสนอ
  - .NET
  - C#
  - Aspose.Slides
description: "เรียนรู้วิธีสร้างและจัดรูปแบบรายการแบบมีสัญลักษณ์, รูปภาพ, หลายระดับ และลำดับเลขในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

Aspose.Slides for .NET ช่วยให้คุณสร้างและจัดรูปแบบรายการแบบมีสัญลักษณ์และรายการลำดับเลขในงานนำเสนอ PowerPoint และ OpenDocument รายการแต่ละรายการคือย่อหน้าที่การตั้งค่าสัญลักษณ์ถูกควบคุมผ่านรูปแบบย่อหน้า

ใช้คุณสมบัติ [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/paragraphformat/) เพื่อเข้าถึงการตั้งค่ารายการระดับย่อหน้า จุดเข้าสำคัญคือ [IParagraphFormat.Bullet](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/bullet/), ซึ่งจะคืนค่าอ็อบเจกต์ [IBulletFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/) ด้วยอ็อบเจกต์นี้คุณสามารถตั้งค่าประเภทสัญลักษณ์, สัญลักษณ์, รูปภาพ, สี, ขนาด, รูปแบบการลำดับเลข และหมายเลขเริ่มต้นได้

บทความนี้แสดงวิธีการ:

- สร้างรายการแบบมีสัญลักษณ์ด้วยสัญลักษณ์กำหนดเอง
- สร้างสัญลักษณ์รูปภาพ
- สร้างรายการหลายระดับโดยตั้งค่าความลึกของย่อหน้า
- สร้างรายการลำดับเลข
- ตรวจสอบและเปลี่ยนแปลงการจัดรูปแบบรายการในงานนำเสนอที่มีอยู่

## **สร้างรายการแบบมีสัญลักษณ์**

เพื่อสร้างรายการแบบมีสัญลักษณ์ เพิ่มอ็อบเจกต์ [IParagraph](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/) ลงใน [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) และตั้งค่า [IBulletFormat.Type](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/type/) เป็น [BulletType.Symbol](https://reference.aspose.com/slides/th/net/aspose.slides/bullettype/) จากนั้นคุณสามารถตั้งค่า [IBulletFormat.Char](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/color/), และ [IBulletFormat.Height](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/height/) เพื่อควบคุมลักษณะของสัญลักษณ์

โค้ด C# ต่อไปนี้แสดงวิธีสร้างรายการแบบมีสัญลักษณ์ในสไลด์:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

static Paragraph CreateParagraph(string text)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    paragraph.ParagraphFormat.Bullet.Char = '*';
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
    paragraph.ParagraphFormat.Bullet.Color.Color = Color.IndianRed;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = CreateParagraph("The first paragraph");
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph");
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("symbol_bullets.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![สัญลักษณ์หัวข้อแบบสัญลักษณ์](symbol_bullets.png)

## **สร้างรายการลำดับเลข**

ใช้รายการลำดับเลขเมื่อลำดับของรายการมีความสำคัญ ตั้งค่า [IBulletFormat.Type](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/type/) เป็น [BulletType.Numbered](https://reference.aspose.com/slides/th/net/aspose.slides/bullettype/) คุณยังสามารถเลือกรูปแบบการนับเลขด้วย [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/numberedbulletstyle/) หรือกำหนดค่าเริ่มต้นด้วย [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/numberedbulletstartwith/) เมื่อรายการควรเริ่มจากค่าที่ไม่ใช่ 1

โค้ด C# ต่อไปนี้แสดงวิธีสร้างรายการลำดับเลขในสไลด์:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph1.Text = "Apple";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph2.Text = "Orange";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph3.Text = "Banana";
textFrame.Paragraphs.Add(paragraph3);

presentation.Save("numbered_bullets.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![สัญลักษณ์หัวข้อแบบลำดับเลข](numbered_bullets.png)

## **สร้างสัญลักษณ์รูปภาพ**

Aspose.Slides อนุญาตให้คุณแทนที่สัญลักษณ์มาตรฐานด้วยภาพ สัญลักษณ์รูปภาพทำงานได้ดีที่สุดกับภาพที่เรียบง่ายและอ่านได้เมื่อลดขนาดลง เช่น ไอคอนหรือไฟล์ PNG โปร่งใสขนาดเล็ก

{{% alert color="info" %}}
โดยทั่วไป หากคุณต้องการแทนที่สัญลักษณ์มาตรฐานด้วยภาพ ควรเลือกกราฟิกที่เรียบง่ายพร้อมพื้นหลังโปร่งแสง ภาพดังกล่าวทำงานได้ดีเป็นสัญลักษณ์กำหนดเอง

โปรดจำไว้ว่าภาพจะถูกย่อให้มีขนาดเล็กมาก ดังนั้นเราขอแนะนำให้เลือกภาพที่ยังคงคมชัดและมีประสิทธิภาพในการมองเห็นเมื่อใช้เป็นสัญลักษณ์ในรายการ
{{% /alert %}}

เพื่อสร้างสัญลักษณ์รูปภาพ เพิ่มภาพลงใน [Presentation.Images](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/images/) แล้วกำหนดอ็อบเจกต์ภาพที่ได้ให้กับ [IBulletFormat.Picture](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/picture/) ตั้งค่า [IBulletFormat.Type](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/type/) เป็น [BulletType.Picture](https://reference.aspose.com/slides/th/net/aspose.slides/bullettype/) ก่อนที่จะกำหนดภาพ

สมมติว่ามีไฟล์ "image.png":

![รูปภาพสำหรับสัญลักษณ์](picture_for_bullets.png)

โค้ด C# ต่อไปนี้แสดงวิธีสร้างสัญลักษณ์รูปภาพในสไลด์:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

static Paragraph CreateParagraph(string text, IPPImage image)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
    paragraph.ParagraphFormat.Bullet.Picture.Image = image;
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var imageBytes = File.ReadAllBytes("image.png");
var bulletImage = presentation.Images.AddImage(imageBytes);

var paragraph1 = CreateParagraph("The first paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("picture_bullets.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![สัญลักษณ์รูปภาพ](picture_bullets.png)

## **สร้างรายการหลายระดับ**

ใช้ [IParagraphFormat.Depth](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/depth/) เพื่อวางรายการบนระดับต่าง ๆ ระดับ 0 คือระดับบนสุด ระดับ 1 อยู่ภายในระดับนั้น และต่อ ๆ ไป

โค้ด C# ต่อไปนี้แสดงวิธีสร้างรายการแบบมีสัญลักษณ์หลายระดับ:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Depth = 0;
paragraph1.Text = "My text - Depth 0";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Depth = 1;
paragraph2.Text = "My text - Depth 1";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Depth = 2;
paragraph3.Text = "My text - Depth 2";
textFrame.Paragraphs.Add(paragraph3);

var paragraph4 = new Paragraph();
paragraph4.ParagraphFormat.Depth = 3;
paragraph4.Text = "My text - Depth 3";
textFrame.Paragraphs.Add(paragraph4);

presentation.Save("multilevel_bullets.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![รายการหลายระดับ](multilevel_list.png)

## **เปลี่ยนรายการที่มีอยู่**

เพื่อเปลี่ยนการจัดรูปแบบรายการในงานนำเสนอที่มีอยู่ ให้เข้าถึงย่อหน้าที่ต้องการและอัปเดตการตั้งค่า [IParagraphFormat.Bullet](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/bullet/) คุณสามารถใช้คุณสมบัติเช่นเดียวกับที่ใช้สร้างรายการเพื่อตรวจสอบหรือแก้ไขรายการที่โหลดจากไฟล์ PPT, PPTX หรือ ODP

โค้ด C# ต่อไปนี้เปลี่ยนย่อหน้าแรกในกรอบข้อความให้ใช้สไตล์รายการลำดับเลข:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var slide = presentation.Slides[0];
var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletRomanUCPeriod;
paragraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 1;
paragraph.ParagraphFormat.MarginLeft = 30;
paragraph.ParagraphFormat.Indent = -20;

presentation.Save("updated_list.pptx", SaveFormat.Pptx);
```

## **คำถามยอดพบบ่อย**

### สามารถส่งออกรายการแบบมีสัญลักษณ์และลำดับเลขเป็น PDF หรือรูปภาพได้หรือไม่?

ใช่ Aspose.Slides รักษาการจัดรูปแบบรายการเมื่อตัวแปลงเป้าหมายสนับสนุนการจัดวางข้อความและคุณลักษณะสัญลักษณ์ที่สอดคล้องกัน

### สามารถแก้ไขรายการในงานนำเสนอที่มีอยู่ได้หรือไม่?

ใช่ โหลดงานนำเสนอแล้วเข้าถึงย่อหน้าที่ต้องการ ตรวจสอบหรืออัปเดตการตั้งค่า [IParagraphFormat.Bullet](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/bullet/) แล้วบันทึกงานนำเสนอ

### รายการสามารถมีข้อความที่ไม่ใช่ลาตินได้หรือไม่?

ใช่ ข้อความของรายการสามารถประกอบด้วยอักขระ Unicode ดังนั้นคุณสามารถสร้างรายการในงานนำเสนอหลายภาษาได้ ตรวจสอบให้แน่ใจว่าแบบอักษรที่ใช้ในงานนำเสนอรองรับอักขระที่คุณต้องการ