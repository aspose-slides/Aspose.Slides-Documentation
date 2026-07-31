---
title: จัดการรายการแบบหัวข้อและลำดับเลขในงานนำเสนอด้วย .NET
linktitle: จัดการรายการ
type: docs
weight: 70
url: /th/net/manage-lists/
aliases:
  - /net/manage-bullet-and-numbered-lists/
keywords:
  - หัวข้อ
  - รายการแบบหัวข้อ
  - รายการลำดับเลข
  - หัวข้อสัญลักษณ์
  - หัวข้อรูปภาพ
  - หัวข้อกำหนดเอง
  - รายการหลายระดับ
  - สร้างหัวข้อ
  - เพิ่มหัวข้อ
  - เพิ่มรายการ
  - PowerPoint
  - OpenDocument
  - งานนำเสนอ
  - .NET
  - C#
  - Aspose.Slides
description: "เรียนรู้วิธีสร้างและจัดรูปแบบรายการแบบหัวข้อ, รูปภาพ, หลายระดับ, และลำดับเลขในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

Aspose.Slides for .NET ช่วยให้คุณสร้างและจัดรูปแบบรายการแบบหัวข้อและรายการลำดับเลขในงานนำเสนอ PowerPoint และ OpenDocument รายการหนึ่งเป็นย่อหน้าที่การตั้งค่าหัวข้อถูกควบคุมผ่านรูปแบบย่อหน้าของมัน.

ใช้คุณสมบัติ [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/paragraphformat/) เพื่อเข้าถึงการตั้งค่ารายการระดับย่อหน้า จุดเริ่มต้นหลักคือ [IParagraphFormat.Bullet](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/bullet/), ซึ่งจะคืนค่าอ็อบเจ็กต์ [IBulletFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/) ด้วยอ็อบเจ็กต์นี้คุณสามารถตั้งค่าชนิดของหัวข้อ สัญลักษณ์ รูปภาพ สี ขนาด รูปแบบการนับเลข และหมายเลขเริ่มต้นได้.

บทความนี้แสดงวิธีการ:

- สร้างรายการแบบหัวข้อด้วยสัญลักษณ์ที่กำหนดเอง
- สร้างหัวข้อรูปภาพ
- สร้างรายการหลายระดับโดยการกำหนดความลึกของย่อหน้า
- สร้างรายการลำดับเลข
- ตรวจสอบและเปลี่ยนการจัดรูปแบบรายการในงานนำเสนอที่มีอยู่

## **สร้างรายการแบบหัวข้อ**

เพื่อสร้างรายการแบบหัวข้อ ให้เพิ่มอ็อบเจ็กต์ [IParagraph](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/) ไปยัง [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) และตั้งค่า [IBulletFormat.Type](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/type/) เป็น [BulletType.Symbol](https://reference.aspose.com/slides/th/net/aspose.slides/bullettype/). จากนั้นคุณสามารถตั้งค่า [IBulletFormat.Char](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/color/), และ [IBulletFormat.Height](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/height/) เพื่อควบคุมรูปแบบของหัวข้อได้.

โค้ด C# ต่อไปนี้แสดงวิธีสร้างรายการแบบหัวข้อในสไลด์:

```csharp
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

![หัวข้อสัญลักษณ์](symbol_bullets.png)

## **สร้างรายการลำดับเลข**

ใช้รายการลำดับเลขเมื่อลำดับของรายการมีความสำคัญ ตั้งค่า [IBulletFormat.Type](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/type/) เป็น [BulletType.Numbered](https://reference.aspose.com/slides/th/net/aspose.slides/bullettype/). คุณยังสามารถเลือกรูปแบบการนับเลขด้วย [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/numberedbulletstyle/) หรือกำหนดค่า [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/numberedbulletstartwith/) เมื่อต้องการให้รายการเริ่มจากค่าที่ไม่ใช่ 1.

โค้ด C# ต่อไปนี้แสดงวิธีสร้างรายการลำดับเลขในสไลด์:

```csharp
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

![หัวข้อเลข](numbered_bullets.png)

## **สร้างหัวข้อรูปภาพ**

Aspose.Slides ให้คุณสามารถแทนที่สัญลักษณ์หัวข้อปกติด้วยรูปภาพได้ หัวข้อรูปภาพทำงานดีที่สุดกับรูปภาพที่เรียบง่ายและยังคงอ่านได้ในขนาดเล็ก เช่น ไอคอนหรือไฟล์ PNG โปร่งใสขนาดเล็ก.

{{% alert color="primary" %}}
โดยอุดมการณ์ หากคุณวางแผนที่จะแทนที่สัญลักษณ์หัวข้อปกติด้วยรูปภาพ ควรเลือกกราฟิกที่เรียบง่ายพร้อมพื้นหลังโปร่งใส รูปภาพเช่นนี้ทำงานได้ดีเป็นสัญลักษณ์หัวข้อแบบกำหนดเอง.

ควรจำไว้ว่ารูปภาพจะถูกย่อขนาดลงเป็นขนาดเล็กมาก ด้วยเหตุนี้เราขอแนะนำให้เลือกภาพที่ยังคงชัดเจนและมีประสิทธิภาพทางสายตาเมื่อนำไปใช้เป็นหัวข้อในรายการ.
{{% /alert %}}

เพื่อสร้างหัวข้อรูปภาพ ให้เพิ่มรูปภาพไปที่ [Presentation.Images](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/images/) แล้วกำหนดอ็อบเจ็กต์รูปภาพที่คืนค่ามาให้กับ [IBulletFormat.Picture](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/picture/). ตั้งค่า [IBulletFormat.Type](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/type/) เป็น [BulletType.Picture](https://reference.aspose.com/slides/th/net/aspose.slides/bullettype/) ก่อนกำหนดรูปภาพ.

สมมติว่าเรามีไฟล์ "image.png":

![รูปภาพสำหรับหัวข้อ](picture_for_bullets.png)

โค้ด C# ต่อไปนี้แสดงวิธีสร้างหัวข้อรูปภาพในสไลด์:

```csharp
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

![หัวข้อรูปภาพ](picture_bullets.png)

## **สร้างรายการหลายระดับ**

ใช้ [IParagraphFormat.Depth](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/depth/) เพื่อวางรายการในระดับที่ต่างกัน ระดับ 0 คือระดับบนสุด ระดับ 1 อยู่ใต้มันและต่อไป.

โค้ด C# ต่อไปนี้แสดงวิธีสร้างรายการหัวข้อหลายระดับ:

```csharp
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

เพื่อเปลี่ยนการจัดรูปแบบรายการในงานนำเสนอที่มีอยู่ ให้เข้าถึงย่อหน้าที่ต้องการและอัปเดตการตั้งค่า [IParagraphFormat.Bullet](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/bullet/) ของมัน คุณสมบัติเช่นเดียวกับที่ใช้สร้างรายการสามารถใช้ตรวจสอบหรือแก้ไขรายการที่โหลดมาจากไฟล์ PPT, PPTX หรือ ODP ได้.

```csharp
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

## **คำถามที่พบบ่อย**

**สามารถส่งออกรายการแบบหัวข้อและลำดับเลขเป็น PDF หรือรูปภาพได้หรือไม่?**

ได้. Aspose.Slides รักษาการจัดรูปแบบรายการเมื่อรูปแบบเป้าหมายรองรับการจัดวางข้อความและคุณสมบัติหัวข้อที่สอดคล้องกัน.

**ฉันสามารถแก้ไขรายการในงานนำเสนอที่มีอยู่ได้หรือไม่?**

ได้. โหลดงานนำเสนอ เข้าไปที่ย่อหน้าที่ต้องการ ตรวจสอบหรืออัปเดตการตั้งค่า [IParagraphFormat.Bullet](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/bullet/) แล้วบันทึกงานนำเสนอ.

**รายการสามารถมีข้อความที่ไม่ใช่ละตินได้หรือไม่?**

ได้. ข้อความของรายการสามารถมีอักขระ Unicode ได้ ดังนั้นคุณจึงสามารถสร้างรายการในงานนำเสนอหลายภาษาได้ ตรวจสอบให้แน่ใจว่าแบบอักษรที่ใช้ในงานนำเสนอสนับสนุนอักขระที่คุณต้องการ.