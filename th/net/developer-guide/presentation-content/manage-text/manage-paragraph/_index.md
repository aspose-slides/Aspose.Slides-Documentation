---
title: จัดการย่อหน้าข้อความ PowerPoint ใน .NET
linktitle: จัดการย่อหน้า
type: docs
weight: 40
url: /th/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
- เพิ่มข้อความ
- เพิ่มย่อหน้า
- จัดการข้อความ
- จัดการย่อหน้า
- จัดการสัญลักษณ์หัวข้อ
- การเยื้องย่อหน้า
- การเยื้องแบบห้อย
- หัวข้อย่อยย่อหน้า
- รายการลำดับเลข
- รายการหัวข้อย่อย
- คุณสมบัติย่อหน้า
- นำเข้า HTML
- ข้อความเป็น HTML
- ย่อหน้าเป็น HTML
- ย่อหน้าเป็นภาพ
- ข้อความเป็นภาพ
- ส่งออกย่อหน้า
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและกำหนดรูปแบบย่อหน้า, ส่วนย่อย, สัญลักษณ์หัวข้อ, รายการลำดับเลข, การเยื้อง, เนื้อหา HTML, และภาพย่อหน้าด้วย Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

Aspose.Slides for .NET แสดงข้อความเป็นลำดับชั้นของกรอบข้อความ, ย่อหน้า, และส่วนย่อย:

* [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) แสดงถึงคอนเทนเนอร์ของข้อความในรูปทรงและให้การเข้าถึงคอลเลกชันของย่อหน้า
* [IParagraph](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/) แสดงถึงย่อหน้าเดียวในกรอบข้อความและให้การเข้าถึงส่วนย่อยและการกำหนดรูปแบบระดับย่อหน้า
* [IPortion](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/) แสดงถึงส่วนของข้อความภายในย่อหน้า ส่วนย่อยแต่ละส่วนสามารถมีข้อความและการกำหนดรูปแบบระดับอักขระของตัวเองได้

ดังนั้น ย่อหน้าจึงสามารถมีข้อความที่ใช้ฟอนต์, สี, ขนาด, และการกำหนดรูปแบบอื่น ๆ ที่แตกต่างกันได้โดยใช้หลายส่วนย่อย

## **สร้างและกำหนดรูปแบบย่อหน้า**

### **สร้างย่อหน้าที่มีหลายส่วนย่อย**

ขั้นตอนต่อไปนี้จะสร้างกรอบข้อความที่มีสามย่อหน้า, แต่ละย่อหน้ามีสามส่วนย่อย:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
2. เข้าถึงสไลด์ที่ต้องการโดยอ้างอิงจากดัชนีของมัน
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) สี่เหลี่ยมไปยังสไลด์
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) ของรูปทรง
5. ใช้ย่อหน้าเริ่มต้นและเพิ่มสองอ็อบเจ็กต์ [IParagraph](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/) อีกอ็อบเจ็กต์ไปยังกรอบข้อความ
6. เพิ่มอ็อบเจ็กต์ [IPortion](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/) จำนวนพอสำหรับแต่ละย่อหน้าเพื่อให้มีสามส่วนย่อย ส่วนย่อหน้าเริ่มต้นมีส่วนย่อยว่างเปล่าอยู่แล้วหนึ่งส่วน
7. ตั้งค่าข้อความของแต่ละส่วนย่อย
8. ใช้การกำหนดรูปแบบระดับอักขระผ่าน [IPortion.PortionFormat](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/portionformat/)
9. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่าง C# ด้านล่างแสดงการดำเนินขั้นตอนเหล่านั้น:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
var textFrame = shape.TextFrame;

var firstParagraph = textFrame.Paragraphs[0];
firstParagraph.Portions.Add(new Portion());
firstParagraph.Portions.Add(new Portion());

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph();
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(thirdParagraph);

var paragraphCount = textFrame.Paragraphs.Count;
for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    var paragragaph = textFrame.Paragraphs[paragraphIndex];
    var portionCount = paragragaph.Portions.Count;
    for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        var portion = paragragaph.Portions[portionIndex];
        portion.Text = $"Portion {paragraphIndex + 1}.{portionIndex + 1}";

        if (portionIndex == 0)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
            portion.PortionFormat.FontBold = NullableBool.True;
            portion.PortionFormat.FontHeight = 15;
        }
        else if (portionIndex == 1)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontHeight = 18;
        }
    }
}

presentation.Save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
```

## **สร้างรายการแบบหัวข้อและลำดับเลข**

### **สร้างรายการแบบหัวข้อหรือแบบลำดับเลข**

หัวข้อและการจัดลำดับทำให้รายการที่เกี่ยวข้องอ่านง่ายขึ้น ใน Aspose.Slides การตั้งค่ารายการจะกำหนดผ่าน [IBulletFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/)

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
2. เข้าถึงสไลด์ที่ต้องการโดยอ้างอิงจากดัชนีของมัน
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ไปยังสไลด์ที่เลือก
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) ของรูปทรง
5. ลบย่อหน้าเริ่มต้นออกจากกรอบข้อความ
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/net/aspose.slides/paragraph/) สำหรับหัวข้อสัญลักษณ์
7. ตั้งค่า [IBulletFormat.Type](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/type/) เป็น [BulletType.Symbol](https://reference.aspose.com/slides/th/net/aspose.slides/bullettype/) และระบุอักขระหัวข้อ
8. ตั้งค่าข้อความย่อหน้า, ระยะเยื้อง, สีหัวข้อ, และความสูงของหัวข้อ
9. เพิ่มย่อหน้าเข้าไปในกรอบข้อความ
10. สร้างย่อหน้าที่สองและตั้งค่า [IBulletFormat.Type](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/type/) เป็น [BulletType.Numbered](https://reference.aspose.com/slides/th/net/aspose.slides/bullettype/)
11. ปรับสไตล์หัวข้อแบบลำดับเลขและเพิ่มย่อหน้าเข้าไปในกรอบข้อความ
12. บันทึกงานนำเสนอ

ตัวอย่าง C# ด้านล่างสร้างหัวข้อสัญลักษณ์และหัวข้อแบบลำดับเลข:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var symbolParagraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
symbolParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
symbolParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
symbolParagraph.ParagraphFormat.Indent = 25;
symbolParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
symbolParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
symbolParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
symbolParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(symbolParagraph);

var numberedParagraph = new Paragraph { Text = "This is a numbered item" };
numberedParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
numberedParagraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;
numberedParagraph.ParagraphFormat.Indent = 25;
numberedParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
numberedParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
numberedParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
numberedParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(numberedParagraph);

presentation.Save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
```

### **ใช้หัวข้อแบบรูปภาพ**

หัวข้อแบบรูปภาพช่วยให้คุณใช้ภาพที่กำหนดเองแทนสัญลักษณ์หรือหมายเลข

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
2. เข้าถึงสไลด์ที่ต้องการโดยอ้างอิงจากดัชนีของมัน
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) และเข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) ของมัน
4. ลบย่อหน้าเริ่มต้นออกจากกรอบข้อความ
5. โหลดภาพหัวข้อและเพิ่มเข้าไปในคอลลเลกชันภาพของงานนำเสนอเป็น [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/)
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/net/aspose.slides/paragraph/) แล้วตั้งค่าข้อความของมัน
7. ตั้งค่า [IBulletFormat.Type](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/type/) เป็น [BulletType.Picture](https://reference.aspose.com/slides/th/net/aspose.slides/bullettype/)
8. กำหนดภาพผ่าน [IBulletFormat.Picture](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/picture/) แล้วตั้งค่าความสูงของหัวข้อ
9. เพิ่มย่อหน้าเข้าไปในกรอบข้อความ
10. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่าง C# ด้านล่างสร้างหัวข้อแบบรูปภาพ:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var bulletImage = Images.FromFile("bullets.png");
var presentationImage = presentation.Images.AddImage(bulletImage);

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = presentationImage;
paragraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(paragraph);

presentation.Save("picture_bullet.pptx", SaveFormat.Pptx);
presentation.Save("picture_bullet.ppt", SaveFormat.Ppt);
```

### **สร้างรายการหลายระดับ**

ตั้งค่า [IParagraphFormat.Depth](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/depth/) เพื่อกำหนดระดับของย่อหน้าในรายการ ระดับบนสุดมีความลึกเป็น `0`

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) แล้วเข้าถึงสไลด์หนึ่งสไลด์
2. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) แล้วลบย่อหน้าเริ่มต้นออกจากกรอบข้อความของมัน
3. สร้างสี่ย่อหน้าและกำหนดสัญลักษณ์หัวข้อของแต่ละย่อหน้า
4. ตั้งค่า [IParagraphFormat.Depth](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/depth/) เป็น `0`, `1`, `2`, และ `3`
5. เพิ่มย่อหน้าเข้าไปในกรอบข้อความแล้วบันทึกงานนำเสนอ

ตัวอย่าง C# ด้านล่างสร้างรายการหัวข้อสี่ระดับ:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Content" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
firstParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.Depth = 0;

var secondParagraph = new Paragraph { Text = "Second level" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
secondParagraph.ParagraphFormat.Bullet.Char = '-';
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.Depth = 1;

var thirdParagraph = new Paragraph { Text = "Third level" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
thirdParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.Depth = 2;

var fourthParagraph = new Paragraph { Text = "Fourth level" };
fourthParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
fourthParagraph.ParagraphFormat.Bullet.Char = '-';
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
fourthParagraph.ParagraphFormat.Depth = 3;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);
textFrame.Paragraphs.Add(fourthParagraph);

presentation.Save("multilevel_list.pptx", SaveFormat.Pptx);
```

### **กำหนดค่าเริ่มต้นของรายการลำดับเลขให้เป็นค่าที่กำหนดเอง**

ใช้ [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/numberedbulletstartwith/) เพื่อกำหนดหมายเลขเริ่มต้นที่แสดงสำหรับย่อหน้าแบบลำดับเลข

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) แล้วเพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ไปยังสไลด์หนึ่งสไลด์
2. ล้างย่อหน้าเริ่มต้นออกจากกรอบข้อความของรูปทรง
3. สร้างย่อหน้าแบบลำดับเลขสามรายการ
4. ตั้งค่า [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/numberedbulletstartwith/) เป็น `2`, `3`, และ `7` สำหรับย่อหน้าแต่ละรายการ
5. เพิ่มย่อหน้าเข้าไปในกรอบข้อความแล้วบันทึกงานนำเสนอ

ตัวอย่าง C# ด้านล่างกำหนดหมายเลขเริ่มต้นที่กำหนดเองให้กับแต่ละย่อหน้า:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Start at 2" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
firstParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
textFrame.Paragraphs.Add(firstParagraph);

var secondParagraph = new Paragraph { Text = "Start at 3" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
secondParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 3;
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph { Text = "Start at 7" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
thirdParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("custom_numbered_list.pptx", SaveFormat.Pptx);
```

## **ควบคุมการจัดวางและคุณสมบัติส่วนท้ายของย่อหน้า**

### **ตั้งค่าการเยื่ยงบรรทัดแรก**

ใช้คุณสมบัติ [IParagraphFormat.Indent](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/indent/) เพื่อควบคุมการเยื้องบรรทัดแรกของย่อหน้า คุณสมบัตินี้จะย้ายเพียงบรรทัดแรกเทียบกับขอบซ้ายของย่อหน้า ค่าเป็นบวกจะเยื้องบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือคงอยู่ที่ตำแหน่งเดิมของเนื้อหาย่อหน้า

ใช้ [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/marginleft/) เมื่อคุณต้องการย้ายย่อหน้าทั้งหมด ใช้ [IParagraphFormat.Indent](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/indent/) เมื่อต้องการย้ายเฉพาะบรรทัดแรกเท่านั้น

ตัวอย่างต่อไปนี้สร้างหลายย่อหน้าและกำหนดค่าต่าง ๆ ของ [IParagraphFormat.Indent](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/indent/) เพื่อแสดงให้เห็นว่าการเยื้องบรรทัดแรกมีผลต่อการจัดวางอย่างไร

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) สี่เหลี่ยมไปยังสไลด์
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) ของรูปทรงและลบย่อหน้าเริ่มต้น
5. สร้างหลายย่อหน้าและกำหนดค่าต่าง ๆ ของ [Indent](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/indent/) ให้กับแต่ละย่อหน้า
6. เพิ่มย่อหน้าเข้าไปในกรอบข้อความ
7. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ดตัวอย่างแสดงวิธีตั้งค่าการเยื้องของย่อหน้า:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "No first-line indent. Wrapped lines start at the same position as the first line." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 20;
firstParagraph.ParagraphFormat.Indent = 0;

var secondParagraph = new Paragraph { Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 20;
secondParagraph.ParagraphFormat.Indent = 20;

var thirdParagraph = new Paragraph { Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see." };
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.MarginLeft = 20;
thirdParagraph.ParagraphFormat.Indent = 40;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![การเยื้องบรรทัดแรกของย่อหน้า](first_line_indent.png)

### **ตั้งค่าการเยื้องแบบห้อย**

การเยื้องแบบห้อยคือการจัดวางย่อหน้าที่บรรทัดแรกเริ่มอยู่ด้านซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟกต์นี้ด้วยคุณสมบัติ [IParagraphFormat.Indent](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/indent/) ตั้งค่า `Indent` เป็นค่าลบเพื่อย้ายบรรทัดแรกไปทางซ้ายเมื่อเทียบกับเนื้อหาย่อหน้า

โดยปฏิบัติ [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/marginleft/) กำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้า และ [IParagraphFormat.Indent](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/indent/) กำหนดตำแหน่งของบรรทัดแรก相對於該邊距 การสร้างการเยื้องแบบห้อยให้ตั้งค่า `MarginLeft` เป็นบวกและ `Indent` เป็นลบ

การกำหนดรูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม, การอ้างอิง, รายการอภิธานศัพท์, และย่อหน้าอื่น ๆ ที่ต้องให้บรรทัดที่ต่อเนื่องเรียงต่อกันภายใต้เนื้อหาย่อหน้าแทนที่จะอยู่ใต้ตัวอักษรแรกของบรรทัดแรก

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) สี่เหลี่ยมไปยังสไลด์
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) ของรูปทรงและลบย่อหน้าเริ่มต้น
5. สร้างย่อหน้าและตั้งค่า [MarginLeft](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/marginleft/) เป็นบวกสำหรับแต่ละย่อหน้า
6. ตั้งค่า [Indent](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/indent/) เป็นลบเพื่อสร้างเอฟเฟกต์การเยื้องแบบห้อย
7. เพิ่มย่อหน้าเข้าไปในกรอบข้อความ
8. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ดตัวอย่างแสดงวิธีตั้งค่าการเยื้องแบบห้อยสำหรับย่อหน้า:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 40;
firstParagraph.ParagraphFormat.Indent = -20;

var secondParagraph = new Paragraph { Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 60;
secondParagraph.ParagraphFormat.Indent = -30;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![การเยื้องแบบห้อยของย่อหน้า](hanging_indent.png)

### **กำหนดคุณสมบัติส่วนท้ายของย่อหน้า**

คุณสมบัติ [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/endparagraphportionformat/) ควบคุมการกำหนดรูปแบบของเครื่องหมายจบย่อหน้า ตัวอย่างต่อไปนี้กำหนดขนาดฟอนต์และฟอนต์ละตินให้กับเครื่องหมายจบของย่อหน้าที่สอง:

1. โหลด [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) แล้วเข้าถึงสไลด์หนึ่งสไลด์
2. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) แล้วลบย่อหน้าเริ่มต้นของมัน
3. สร้างย่อหน้าสองรายการและเพิ่มส่วนข้อความให้กับแต่ละย่อหน้า
4. สร้าง [PortionFormat](https://reference.aspose.com/slides/th/net/aspose.slides/portionformat/) สำหรับเครื่องหมายจบของย่อหน้าที่สอง
5. ตั้งค่า [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseportionformat/fontheight/) และ [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseportionformat/latinfont/)
6. กำหนดรูปแบบให้กับ [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/endparagraphportionformat/) แล้วบันทึกงานนำเสนอ

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph();
firstParagraph.Portions.Add(new Portion("Sample text"));

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion("Sample text 2"));

var endParagraphFormat = new PortionFormat();
endParagraphFormat.FontHeight = 48;
endParagraphFormat.LatinFont = new FontData("Times New Roman");
secondParagraph.EndParagraphPortionFormat = endParagraphFormat;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("end_paragraph_format.pptx", SaveFormat.Pptx);
```

## **นับจำนวนบรรทัดที่แสดงผล**

ใช้ [IParagraph.GetLinesCount](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/getlinescount/) เพื่อคำนวนจำนวนบรรทัดที่ย่อหน้าครอบคลุมหลังการจัดวางข้อความรวมถึงการห่ออัตโนมัติ ซึ่งเป็นประโยชน์เมื่อทำการตรวจสอบความยาวของข้อความและการจัดวางในเทมเพลตงานนำเสนอ

ย่อหน้าเป็นรายการหนึ่งใน [ITextFrame.Paragraphs](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/paragraphs/) และอาจครอบคลุมหลายบรรทัดที่แสดงผล การใส่ตัวแบ่งบรรทัดโดยเจตนาในย่อหน้าจะทำให้เกิดบรรทัดใหม่โดยไม่ต้องสร้างย่อหน้าใหม่ การห่ออัตโนมัติจะสร้างบรรทัดตามความกว้างที่มีอยู่โดยไม่ต้องแทรกตัวแบ่งบรรทัดลงในข้อความ ดังนั้นการนับย่อหน้าหรืออักขระตัวแบ่งบรรทัดจะไม่ให้จำนวนบรรทัดที่แสดงผลได้

ตัวอย่างต่อไปนี้สร้างรูปทรงข้อความ, นับจำนวนบรรทัด, ลดความกว้างของรูปทรง, แล้วแทนที่ข้อความด้วยสตริงสั้นกว่าที่มีการเปิดใช้งานการห่อและปิดการปรับอัตโนมัติเพื่อให้ความกว้างของรูปทรงควบคุมการห่อโดยไม่ต้องย่อข้อความหรือเปลี่ยนขนาดรูปทรง ขนาดของรูปทรงวัดเป็นพอยท์ สุดท้าย ตัวอย่างเพิ่มย่อหน้าอีกหนึ่งรายการและรวมจำนวนบรรทัดจากกรอบข้อความทั้งหมด

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;

var paragraph = textFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
paragraph.Text = "This text demonstrates how automatic wrapping changes the number of rendered lines.";
Console.WriteLine($"Original width: {paragraph.GetLinesCount()}");

shape.Width = 150;
Console.WriteLine($"Narrower shape: {paragraph.GetLinesCount()}");

paragraph.Text = "Short text.";
Console.WriteLine($"Shorter text: {paragraph.GetLinesCount()}");

var secondParagraph = new Paragraph { Text = "Another paragraph." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
textFrame.Paragraphs.Add(secondParagraph);

var totalLineCount = 0;
foreach (var currentParagraph in textFrame.Paragraphs)
{
    totalLineCount += currentParagraph.GetLinesCount();
}
Console.WriteLine($"Total lines in the text frame: {totalLineCount}");
```

ด้วยข้อความและขนาดเหล่านี้ การลดความกว้างของรูปทรงจะเพิ่มจำนวนบรรทัด ในขณะที่การแทนที่ข้อความด้วยสตริงสั้นจะลดจำนวนบรรทัด จำนวนที่แน่นอนอาจแตกต่างไปตามฟอนต์ที่มีและการแทนที่, ขนาดฟอนต์, ระยะขอบ, ระยะเยื้อง, การห่อและการตั้งค่าการปรับอัตโนมัติ ใช้ฟอนต์และการตั้งค่าการจัดวางที่ตั้งใจสำหรับสภาพแวดล้อมเป้าหมายเมื่อทำการตรวจสอบเทมเพลต

จำนวนบรรทัดเพียงอย่างเดียวไม่สามารถบ่งบอกว่าข้อความจะล้นขอบของคอนเทนเนอร์หรือไม่ ความสูงที่มี, ความสูงของบรรทัด, ระยะห่างระหว่างย่อหน้าและบรรทัด, และการทำงานของการปรับอัตโนมัติก็มีผลเช่นกัน; แม้แต่บรรทัดเดียวก็อาจเกินความกว้างที่มีเมื่อการห่อถูกปิด

## **นำเข้าและส่งออกเนื้อหาย่อหน้า**

### **นำเข้า HTML เข้าในย่อหน้า**

ใช้ [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/th/net/aspose.slides/paragraphcollection/addfromhtml/) เพื่อแปลง markup HTML ให้เป็นย่อหน้าและส่วนย่อยในกรอบข้อความ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
2. เข้าถึงสไลด์และเพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/)
3. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) ของรูปทรงและลบย่อหน้าเริ่มต้น
4. อ่านไฟล์ HTML ต้นฉบับ
5. ส่งสตริง HTML ไปยัง [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/th/net/aspose.slides/paragraphcollection/addfromhtml/)
6. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่าง C# ด้านล่างนำเข้า HTML ไปยังกรอบข้อความ:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shapeWidth = presentation.SlideSize.Size.Width - 20;
var shapeHeight = presentation.SlideSize.Size.Height - 20;
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
shape.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

using var reader = new StreamReader("file.html");
var html = reader.ReadToEnd();
shape.TextFrame.Paragraphs.AddFromHtml(html);

presentation.Save("html_text.pptx", SaveFormat.Pptx);
```

### **ส่งออกข้อความย่อหน้าเป็น HTML**

ใช้ [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/th/net/aspose.slides/paragraphcollection/exporttohtml/) เพื่อส่งออกช่วงของย่อหน้าที่เลือกเป็น HTML

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) แล้วโหลดงานนำเสนอที่ต้องการ
2. เข้าถึงสไลด์และค้นหา [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ที่มีข้อความ
3. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) ของรูปทรงนั้น
4. เรียก [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/th/net/aspose.slides/paragraphcollection/exporttohtml/) พร้อมดัชนีย่อหน้าเริ่มต้นและจำนวนย่อหน้าที่ต้องการส่งออก
5. เขียนสตริง HTML ที่ได้ลงไฟล์

ตัวอย่าง C# ด้านล่างส่งออกย่อหน้าทั้งหมดจากรูปทรงข้อความแรก:

```csharp
using System;
using System.IO;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("ExportingHTMLText.pptx");
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape textShape && textShape.TextFrame != null)
{
    var paragraphs = textShape.TextFrame.Paragraphs;
    var html = paragraphs.ExportToHtml(0, paragraphs.Count, null);
    using var writer = new StreamWriter("paragraphs.html", false, Encoding.UTF8);
    writer.Write(html);
}
else
{
    Console.WriteLine("The first shape is not a text shape.");
}
```

### **เรนเดอร์ย่อหน้าเป็นภาพ**

[IParagraph.GetImage](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/getimage/) เรนเดอร์ย่อหน้าเดี่ยวโดยตรงและคืนค่า [IImage](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/) สามารถบันทึกผลลัพธ์ลงไฟล์หรือสตรีมด้วย [IImage.Save](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/save/) ไม่จำเป็นต้องเรนเดอร์รูปทรงที่บรรจุหรือครอบตัดบิทแมปด้วยตนเอง

[IParagraph.GetImage](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/getimage/) อาจคืนค่า `null` หากไม่พบย่อหน้าในคอลลเลกชันแม่, ไม่มีขอบเขตการเรนเดอร์ที่ถูกต้อง, หรือไม่สามารถเรนเดอร์ได้ ตรวจสอบผลลัพธ์ก่อนบันทึกและทำการปล่อยภาพที่คืนค่าหลังใช้งาน

#### **เรนเดอร์ย่อหน้าที่อัตราส่วนเริ่มต้น**

สมมติว่าเรามีไฟล์งานนำเสนอชื่อ sample.pptx ที่มีหนึ่งสไลด์ โดยรูปทรงแรกเป็นกล่องข้อความที่มีสามย่อหน้า

![กล่องข้อความที่มีสามย่อหน้า](paragraph_to_image_input.png)

ตัวอย่างต่อไปนี้เรนเดอร์ย่อหน้าที่สองในรูปทรงข้อความปกติที่อัตราส่วนเริ่มต้นและบันทึกภาพที่ได้เป็นรูปแบบ PNG การประกาศ `using` ทำให้แน่ใจว่าภาพจะถูกปล่อยอย่างถูกต้อง

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
if (shape is IAutoShape textShape && 
    textShape.TextFrame != null && 
    textShape.TextFrame.Paragraphs.Count > 1)
{
    var paragraph = textShape.TextFrame.Paragraphs[1];
    using var paragraphImage = paragraph.GetImage();

    if (paragraphImage != null)
    {
        paragraphImage.Save("paragraph.png", ImageFormat.Png);
    }
    else
    {
        Console.WriteLine("The paragraph could not be rendered.");
    }
}
else
{
    Console.WriteLine("The expected text shape or paragraph was not found.");
}
```

ผลลัพธ์:

![ภาพย่อหน้า](paragraph_to_image_output.png)

#### **เรนเดอร์ย่อหน้าในเซลล์ตารางพร้อมการสเกล**

ใช้ overload ของ [IParagraph.GetImage](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/getimage/) ที่รับพารามิเตอร์ `float scaleX` และ `float scaleY` เพื่อกำหนดค่าอัตราส่วนแนวนอนและแนวตั้ง ตัวอย่างต่อไปนี้สร้างตาราง, เรนเดอร์ย่อหน้าในเซลล์แรกโดยขยายความกว้างและความสูงเป็นสองเท่าของค่าเริ่มต้น, แล้วบันทึกผลเป็นภาพ PNG

```csharp
using System;
using Aspose.Slides;

var scaleX = 2f;
var scaleY = 2f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var table = slide.Shapes.AddTable(50, 50, new[] { 300d }, new[] { 80d });
var paragraph = table[0, 0].TextFrame.Paragraphs[0];
paragraph.Text = "Text in a table cell";

using var paragraphImage = paragraph.GetImage(scaleX, scaleY);
if (paragraphImage != null)
{
    paragraphImage.Save("table_paragraph.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The paragraph could not be rendered.");
}
```

ค่าสเกล `1` ทำให้แกนนั้นคงขนาดพิกเซลเริ่มต้น ตัวอย่างเช่น `2` สำหรับทั้งสองค่า จะให้ภาพที่กว้างและสูงประมาณสองเท่าของขนาดเริ่มต้น, ทำให้จำนวนพิกเซลมากกว่าตัวเดิมสี่เท่า ค่าใหญ่กว่าจะให้ข้อความคมชัดยิ่งขึ้นสำหรับการซูมหรือเอาต์พุตความละเอียดสูง, แต่ก็เพิ่มการใช้หน่วยความจำและขนาดไฟล์ ค่าใตᴁ `1` จะให้ภาพเล็กลงและรายละเอียดน้อยลง ใช้ค่าที่เท่ากันเพื่อรักษาสัดส่วนของย่อหน้า; ค่าต่างกันระหว่างแกนแนวนอนและแนวตั้งจะยืดหรือหดเอาต์พุตแยกกัน

การเรนเดอร์รูปทรงทั้งหมดด้วย [IShape.GetImage](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/getimage/) ยังคงมีประโยชน์เมื่อต้องการรวมการเติมสี, เส้นขอบ, หรือบริบทภาพอื่น ๆ ของรูปทรง อย่างไรก็ตามสำหรับภาพที่ต้องการเพียงย่อหน้าเดียวให้ใช้ [IParagraph.GetImage](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/getimage/)

## **คำถามที่พบบ่อย**

**ฉันสามารถปิดการห่อบรรทัดภายในกรอบข้อความได้ทั้งหมดหรือไม่?**

ใช่. ตั้งค่า [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat/wraptext/) เพื่อปิดการห่อให้บรรทัดไม่ตัดที่ขอบของกรอบข้อความ

**ฉันจะรับขอบเขตบนสไลด์ที่แน่นอนของย่อหน้าเฉพาะได้อย่างไร?**

ใช้ [IParagraph.GetRect](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/getrect/) เพื่อดึงสี่เหลี่ยมขอบของย่อหน้า [IPortion.GetRect](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/getrect/) ให้ขอบของส่วนย่อยแต่ละส่วน

**การจัดแนวของย่อหน้า (ซ้าย, ขวา, กลาง, หรือจัดเต็ม) ถูกควบคุมที่ไหน?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/alignment/) เป็นการตั้งค่าระดับย่อหน้าและนำไปใช้กับย่อหน้าทั้งหมดโดยไม่คำนึงถึงการกำหนดรูปแบบของส่วนย่อยแต่ละส่วน

**ฉันสามารถตั้งค่าภาษา proofing สำหรับบางส่วนของย่อหน้าได้หรือไม่?**

ใช่. ตั้งค่า [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseportionformat/languageid/) สำหรับส่วนย่อยแต่ละส่วน เพื่อให้ย่อหน้าหนึ่งสามารถมีข้อความในหลายภาษาได้