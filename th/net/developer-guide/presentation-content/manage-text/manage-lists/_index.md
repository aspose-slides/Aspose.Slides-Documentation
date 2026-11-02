---
title: จัดการรายการแบบหัวข้อสัญลักษณ์และลำดับเลขในงานนำเสนอด้วย .NET
linktitle: จัดการรายการ
type: docs
weight: 70
url: /th/net/manage-lists/
aliases:
  - /net/manage-bullet-and-numbered-lists/
keywords:
- หัวข้อสัญลักษณ์
- รายการแบบหัวข้อสัญลักษณ์
- รายการลำดับเลข
- สัญลักษณ์หัวข้อสัญลักษณ์
- หัวข้อสัญลักษณ์รูปภาพ
- หัวข้อสัญลักษณ์กำหนดเอง
- รายการหลายระดับ
- สร้างหัวข้อสัญลักษณ์
- เพิ่มหัวข้อสัญลักษณ์
- เพิ่มรายการ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและจัดรูปแบบรายการแบบหัวข้อสัญลักษณ์, รูปภาพ, หลายระดับ และลำดับเลขในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

Aspose.Slides for .NET ช่วยให้คุณสร้างและจัดรูปแบบรายการแบบหัวข้อสัญลักษณ์และรายการลำดับเลขในงานนำเสนอ PowerPoint และ OpenDocument รายการแต่ละรายการคือย่อหน้าที่การตั้งค่าหัวข้อสัญลักษณ์ถูกควบคุมผ่านรูปแบบย่อหน้า

ใช้คุณสมบัติ [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) เพื่อเข้าถึงการตั้งค่ารายการระดับย่อหน้า จุดเข้าสำคัญคือ [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/) ซึ่งคืนค่าออบเจกต์ [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) ด้วยออบเจกต์นี้ คุณสามารถตั้งค่าประเภทสัญลักษณ์, สัญลักษณ์, รูปภาพ, สี, ขนาด, รูปแบบการลำดับเลข, และหมายเลขเริ่มต้น

บทความนี้แสดงวิธีการ:

- สร้างรายการแบบหัวข้อสัญลักษณ์ด้วยสัญลักษณ์ที่กำหนดเอง
- สร้างหัวข้อสัญลักษณ์รูปภาพ
- สร้างรายการหลายระดับโดยกำหนดความลึกของย่อหน้า
- สร้างรายการลำดับเลข
- ตรวจสอบและเปลี่ยนการจัดรูปแบบรายการในงานนำเสนอที่มีอยู่
- อ่านสัญลักษณ์รายการและหมายเลขจริงพร้อมกับข้อความย่อหน้า

## **สร้างรายการแบบหัวข้อสัญลักษณ์**

เพื่อสร้างรายการแบบหัวข้อสัญลักษณ์ ให้เพิ่มออบเจกต์ [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) ไปยัง [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) และตั้งค่า [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) เป็น [BulletType.Symbol](https://reference.aspose.com/slides/net/aspose.slides/bullettype/). จากนั้นคุณสามารถตั้งค่า [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/color/), และ [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) เพื่อควบคุมลักษณะของหัวข้อสัญลักษณ์ได้

โค้ด C# ด้านล่างแสดงวิธีการสร้างรายการแบบหัวข้อสัญลักษณ์ในสไลด์:

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

![หัวข้อสัญลักษณ์](symbol_bullets.png)

## **สร้างรายการลำดับเลข**

ใช้รายการลำดับเลขเมื่อลำดับของรายการสำคัญ ตั้งค่า [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) เป็น [BulletType.Numbered](https://reference.aspose.com/slides/net/aspose.slides/bullettype/). คุณยังสามารถเลือกรูปแบบเลขลำดับด้วย [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) หรือกำหนด [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) เมื่อรายการควรเริ่มจากค่าที่ไม่ใช่ 1

โค้ด C# ด้านล่างแสดงวิธีการสร้างรายการลำดับเลขในสไลด์:

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

![หัวข้อสัญลักษณ์ลำดับเลข](numbered_bullets.png)

## **สร้างหัวข้อสัญลักษณ์รูปภาพ**

Aspose.Slides ให้คุณแทนที่สัญลักษณ์หัวข้อสัญลักษณ์ปกติด้วยรูปภาพ. หัวข้อสัญลักษณ์รูปภาพทำงานได้ดีที่สุดกับรูปภาพที่เรียบง่ายและยังคงอ่านได้ที่ขนาดเล็ก เช่น ไอคอนหรือไฟล์ PNG โปร่งใสขนาดเลาะ.

{{% alert color="info" title="Note" %}}
โดยทั่วไป หากคุณวางแผนที่จะแทนที่สัญลักษณ์หัวข้อสัญลักษณ์ปกติด้วยรูปภาพ ควรเลือกกราฟิกที่เรียบง่ายพร้อมพื้นหลังโปร่งแสง รูปภาพเช่นนี้ทำงานได้ดีเป็นสัญลักษณ์หัวข้อสัญลักษณ์แบบกำหนดเอง.

ควรจำไว้ว่า รูปภาพจะถูกย่อให้เล็กลงมาก สำหรับเหตุผลนี้ เราขอแนะนำอย่างยิ่งให้เลือกภาพที่ยังคงชัดเจนและเห็นผลภาพได้ดีเมื่อใช้เป็นหัวข้อสัญลักษณ์ในรายการ.
{{% /alert %}}

เพื่อสร้างหัวข้อสัญลักษณ์รูปภาพ ให้เพิ่มรูปภาพไปยัง [Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/images/) และกำหนดออบเจกต์รูปภาพที่คืนค่าให้กับ [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/). ตั้งค่า [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) เป็น [BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) ก่อนการกำหนดรูปภาพ.

สมมุติว่าเรามีไฟล์ "image.png":

![รูปภาพสำหรับหัวข้อสัญลักษณ์](picture_for_bullets.png)

โค้ด C# ด้านล่างแสดงวิธีการสร้างหัวข้อสัญลักษณ์รูปภาพในสไลด์:

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

![หัวข้อสัญลักษณ์รูปภาพ](picture_bullets.png)

## **สร้างรายการหลายระดับ**

ใช้ [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) เพื่อวางรายการในระดับต่าง ๆ ระดับ 0 คือระดับบนสุด, ระดับ 1 อยู่ด้านล่างในระดับย่อย, เป็นต้น.

โค้ด C# ด้านล่างแสดงวิธีการสร้างรายการแบบหัวข้อสัญลักษณ์หลายระดับ:

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

เพื่อเปลี่ยนการจัดรูปแบบรายการในงานนำเสนอที่มีอยู่ ให้เข้าถึงย่อหน้าเป้าหมายและอัปเดตการตั้งค่า [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/) ของมัน คุณสมบัติเหมือนกันที่ใช้สร้างรายการสามารถใช้เพื่อสอบถามหรือแก้ไขรายการที่โหลดจากไฟล์ PPT, PPTX หรือ ODP ได้.

โค้ด C# ด้านล่างเปลี่ยนย่อหน้าแรกในฟรมข้อความให้ใช้สไตล์รายการลำดับเลข:

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

## **อ่านค่าหัวข้อสัญลักษณ์จริง**

เมื่อสกัดเนื้องานนำเสนอ ให้เก็บสัญลักษณ์รายการพร้อมกับข้อความย่อหน้า เรียกใช้ [IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/) และเข้าถึง [IParagraphFormatEffectiveData.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformateffectivedata/bullet/) เพื่อรับรูปแบบหัวข้อสัญลักษณ์ที่มีผล ตรวจสอบ [Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/type/) ก่อนอ่าน [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/).

สำหรับรายการลำดับเลข ให้แยกแยะค่าต่อไปนี้สามค่า:

- [NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/numberedbulletstyle/) กำหนดรูปแบบ เช่น ตัวเลขอารบิกตามด้วยจุด หรือ ตัวอักษรตัวเล็กตามด้วยจุด.
- [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/numberedbulletstartwith/) ระบุหมายเลขเริ่มต้นสำหรับกลุ่มย่อหน้าลำดับเลข.
- [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/) คืนค่าตัวบ่งชี้ที่จัดรูปแบบสำหรับย่อหน้าที่กำหนด ตัวอย่าง รายการที่สองในรายการที่เริ่มจาก 5 จะคืนค่า `6.`.

รักษา [Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) กับแต่ละย่อหน้าเพื่อคงระดับการซ้อนกันของมัน ตัวบ่งชี้จริงไม่ได้เข้ารหัสลำดับขั้นทั้งหมด: รายการซ้อนอาจคืนค่า `c.` แทนที่จะเป็นป้ายกำกับรวมเช่น `6.c.`.

ตัวอย่างที่ทำงานอิสระต่อไปนี้สร้างรายการ, บันทึกลงในงานนำเสนอ, และโหลดงานนำเสนอใหม่เพื่อรายงานข้อความของแต่ละย่อหน้า, ความลึก, ประเภทหัวข้อสัญลักษณ์, และค่าจริง. ตัวบ่งชี้รูปภาพสีน้ำเงินขนาดเล็กถูกสร้างจาก SVG ในบรรทัด.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    presentation.SlideSize.SetSize(720, 440, SlideSizeScaleType.DoNotScale);
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20, 660, 400);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.Paragraphs.Clear();

    // สร้างสัญลักษณ์รูปภาพโดยไม่ต้องอ้างอิงไฟล์ภาพภายนอก.
    var svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    var bulletImage = presentation.Images.AddImage(svg);

    void AddParagraph(string text, short depth, BulletType type, short start = 1, NumberedBulletStyle style = NumberedBulletStyle.BulletArabicPeriod)
    {
        var paragraph = new Paragraph { Text = text };

        var format = paragraph.ParagraphFormat;
        format.Depth = depth;
        format.MarginLeft = 30 + depth * 40;
        format.Indent = -28;
        format.SpaceAfter = 8;
        format.DefaultPortionFormat.FontHeight = 22;
        format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
        format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
        format.Bullet.Type = type;
        format.Bullet.IsBulletHardColor = NullableBool.True;
        format.Bullet.Color.Color = Color.Black;
        if (type == BulletType.Numbered)
        {
            format.Bullet.NumberedBulletStyle = style;
            format.Bullet.NumberedBulletStartWith = start;
        }
        else if (type == BulletType.Symbol)
        {
            format.Bullet.Char = '\u2022';
        }
        else if (type == BulletType.Picture)
        {
            format.Bullet.Picture.Image = bulletImage;
        }

        textFrame.Paragraphs.Add(paragraph);
    }

    AddParagraph("First item", 0, BulletType.Numbered, 5);
    AddParagraph("Second item", 0, BulletType.Numbered, 5);
    AddParagraph("Nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    AddParagraph("Next nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    AddParagraph("Deep item", 2, BulletType.Numbered, 4, NumberedBulletStyle.BulletRomanLCPeriod);
    AddParagraph("Back to top level", 0, BulletType.Numbered, 5);
    AddParagraph("Symbol marker", 0, BulletType.Symbol);
    AddParagraph("No bullet", 0, BulletType.None);
    AddParagraph("Picture marker", 0, BulletType.Picture);
    presentation.Save("actual_bullet_values.pptx", SaveFormat.Pptx);
}

using var loadedPresentation = new Presentation("actual_bullet_values.pptx");
var loadedShape = (IAutoShape)loadedPresentation.Slides[0].Shapes[0];
Console.WriteLine("Text | Depth | Type | Actual value");
foreach (var paragraph in loadedShape.TextFrame.Paragraphs)
{
    var bullet = paragraph.ParagraphFormat.GetEffective().Bullet;
    string marker;
    switch (bullet.Type)
    {
        case BulletType.Numbered:
        case BulletType.Symbol:
            marker = bullet.ActualBulletValue;
            break;
        case BulletType.None:
            marker = $"{bullet.ActualBulletValue ?? "null"} (no bullet)";
            break;
        case BulletType.Picture:
            marker = $"{bullet.ActualBulletValue ?? "null"} (image required)";
            break;
        default:
            marker = "unsupported bullet type";
            break;
    }
    Console.WriteLine($"{paragraph.Text} | {paragraph.ParagraphFormat.Depth} | {bullet.Type} | {marker}");
}
```

รายการที่แสดงด้านล่างเป็นแหล่งข้อมูลของรายการ:

![รายการที่เริ่มจาก 5, รายการอักษรและเลขโรมันซ้อน, สัญลักษณ์, ย่อหน้าไม่มีหัวข้อสัญลักษณ์, และตัวบ่งชี้รูปภาพสีน้ำเงิน](actual_bullet_values.png)

รายงานตรงกับสัญลักษณ์ที่แสดงใน PowerPoint:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

สำหรับ [BulletType.None and BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/) คืนค่า `null` ไม่ใช่สตริงว่าง ให้จัดการประเภทเหล่านี้แยกกัน: ประเภทแรกไม่มีตัวบ่งชี้, ในขณะที่ประเภทที่สองต้องทำการสกัดรูปภาพหัวข้อสัญลักษณ์แยกต่างหาก. หัวข้อสัญลักษณ์รูปภาพไม่สามารถจำลองได้โดยเพียงสกัดตัวบ่งชี้ข้อความ.

## **คำถามที่พบบ่อย**

**สามารถส่งออกรายการแบบหัวข้อสัญลักษณ์และลำดับเลขเป็น PDF หรือภาพได้หรือไม่?**

ใช่. Aspose.Slides รักษาการจัดรูปแบบรายการเมื่อรูปแบบเป้าหมายสนับสนุนการจัดวางข้อความและฟีเจอร์หัวข้อสัญลักษณ์ที่สอดคล้อง.

**ฉันสามารถแก้ไขรายการในงานนำเสนอที่มีอยู่ได้หรือไม่?**

ใช่. โหลดงานนำเสนอ, เข้าถึงย่อหน้าเป้าหมาย, ตรวจสอบหรืออัปเดตการตั้งค่า [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/) ของมัน, แล้วบันทึกงานนำเสนอ.

**รายการสามารถประกอบด้วยข้อความที่ไม่ใช่ละตินได้หรือไม่?**

ใช่. ข้อความของรายการสามารถมีอักขระ Unicode, ดังนั้นคุณสามารถสร้างรายการในงานนำเสนอหลายภาษาได้. ตรวจสอบให้แน่ใจว่าแบบอักษรที่ใช้ในงานนำเสนอสนับสนุนอักขระที่คุณต้องการ.