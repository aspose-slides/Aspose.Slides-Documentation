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
- จัดการ bullet
- ย่อหน้าการเยื่อง
- เยื้องห้อย
- bullet ย่อหน้า
- รายการหมายเลข
- รายการหัวข้อ
- คุณสมบัติย่อหน้า
- นำเข้า HTML
- ข้อความเป็น HTML
- ย่อหน้าเป็น HTML
- ย่อหน้าเป็นภาพ
- ข้อความเป็นภาพ
- ส่งออกย่อหน้า
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและจัดรูปแบบย่อหน้า, ส่วนข้อความ, bullet, รายการหมายเลข, การเยื้อง, เนื้อหา HTML, และภาพย่อหน้าด้วย Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

Aspose.Slides for .NET แสดงข้อความเป็นโครงสร้างลำดับชั้นของ text frames, paragraphs, และ portions:

* [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) เป็นตัวบรรจุข้อความใน shape และให้การเข้าถึงคอลเลกชันของ paragraph
* [IParagraph](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/) แทนหนึ่ง paragraph ใน text frame และให้การเข้าถึง portions และการจัดรูปแบบระดับ paragraph
* [IPortion](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/) แทนชุดข้อความภายใน paragraph แต่ละ portion สามารถมีข้อความและการจัดรูปแบบระดับอักขระของตนเองได้

ดังนั้น paragraph สามารถบรรจุข้อความที่มีฟอนท์ สี ขนาด และการจัดรูปแบบอื่น ๆ แตกต่างกันโดยใช้หลาย portion

## **สร้างและจัดรูปแบบย่อหน้า**

### **สร้างย่อหน้าด้วยหลาย Portion**

ขั้นตอนต่อไปนี้สร้าง text frame ที่มีสาม paragraph โดยแต่ละ paragraph มีสาม portion:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
2. เข้าถึงสไลด์ที่ต้องการโดยอ้างอิงจากดัชนีของมัน
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) แบบสี่เหลี่ยมลงในสไลด์
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) ของ shape
5. ใช้ paragraph เริ่มต้นและเพิ่มอีกสองอ็อบเจกต์ [IParagraph](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/) ลงใน text frame
6. เพิ่มอ็อบเจกต์ [IPortion](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/) ให้พอเพียงสำหรับแต่ละ paragraph เพื่อให้มีสาม portion แต่ละอัน paragraph เริ่มต้นมีหนึ่ง portion ว่างอยู่แล้ว
7. ตั้งค่าข้อความของแต่ละ portion
8. ใช้การจัดรูปแบบระดับอักขระผ่าน [IPortion.PortionFormat](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/portionformat/)
9. บันทึก presentation ที่แก้ไขแล้ว

ตัวอย่าง C# นี้ดำเนินตามขั้นตอนดังกล่าว:

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

## **สร้างรายการแบบหัวข้อแบบ Bullet และ Numbered**

### **สร้างรายการแบบ Bullet หรือ Numbered**

Bullet และ numbering ทำให้รายการที่เกี่ยวข้องอ่านง่ายขึ้น ใน Aspose.Slides การตั้งค่ารายการกำหนดโดยใช้ [IBulletFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/)

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
2. เข้าถึงสไลด์ที่ต้องการโดยอ้างอิงจากดัชนีของมัน
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ลงในสไลด์ที่เลือก
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) ของ shape
5. ลบ paragraph เริ่มต้นออกจาก text frame
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/net/aspose.slides/paragraph/) สำหรับ bullet แบบสัญลักษณ์
7. ตั้งค่า [IBulletFormat.Type](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/type/) เป็น [BulletType.Symbol](https://reference.aspose.com/slides/th/net/aspose.slides/bullettype/) และระบุอักขระ bullet
8. ตั้งค่าข้อความของ paragraph, ระยะเยื้อง, สี bullet, และความสูงของ bullet
9. เพิ่ม paragraph ลงใน text frame
10. สร้าง paragraph ที่สองและตั้งค่า [IBulletFormat.Type](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/type/) เป็น [BulletType.Numbered](https://reference.aspose.com/slides/th/net/aspose.slides/bullettype/)
11. กำหนดสไตล์ bullet แบบหมายเลขและเพิ่ม paragraph ลงใน text frame
12. บันทึก presentation

ตัวอย่าง C# นี้สร้าง bullet สัญลักษณ์และ bullet แบบหมายเลข:

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

### **ใช้ Picture Bullets**

Picture bullets ให้คุณใช้รูปภาพที่กำหนดเองแทนสัญลักษณ์หรือหมายเลข

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
2. เข้าถึงสไลด์ที่ต้องการโดยอ้างอิงจากดัชนีของมัน
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) แล้วเข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) ของมัน
4. ลบ paragraph เริ่มต้นออกจาก text frame
5. โหลดรูปภาพ bullet แล้วเพิ่มเข้าไปในคอลเลกชันรูปภาพของ presentation เป็น [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/)
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/net/aspose.slides/paragraph/) แล้วตั้งค่าข้อความของมัน
7. ตั้งค่า [IBulletFormat.Type](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/type/) เป็น [BulletType.Picture](https://reference.aspose.com/slides/th/net/aspose.slides/bullettype/)
8. กำหนดรูปภาพผ่าน [IBulletFormat.Picture](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/picture/) แล้วตั้งค่าความสูงของ bullet
9. เพิ่ม paragraph ลงใน text frame
10. บันทึก presentation ที่แก้ไขแล้ว

ตัวอย่าง C# นี้สร้าง picture bullet:

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

### **สร้าง Multilevel List**

ตั้งค่า [IParagraphFormat.Depth](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/depth/) เพื่อกำหนดระดับของ paragraph ในรายการ ระดับบนสุดมีค่า depth เป็น `0`

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) แล้วเข้าถึงสไลด์หนึ่ง
2. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) แล้วล้าง paragraph เริ่มต้นออกจาก text frame ของมัน
3. สร้างสี่ paragraph และกำหนดสัญลักษณ์ bullet ให้แต่ละรายการ
4. ตั้งค่าค่า [IParagraphFormat.Depth](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/depth/) เป็น `0`, `1`, `2`, และ `3`
5. เพิ่ม paragraph ทั้งหมดลงใน text frame แล้วบันทึก presentation

ตัวอย่าง C# นี้สร้างรายการ bullet สี่ระดับ:

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

### **กำหนดจุดเริ่มต้นของ Numbered List ให้เป็นค่า Customized**

ใช้ [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/numberedbulletstartwith/) เพื่อกำหนดหมายเลขเริ่มต้นที่แสดงสำหรับ paragraph ที่เป็น numbered

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) แล้วเพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ลงในสไลด์
2. ลบ paragraph เริ่มต้นออกจาก text frame ของ shape
3. สร้าง paragraph numbered สามรายการ
4. ตั้งค่า [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/numberedbulletstartwith/) เป็น `2`, `3`, และ `7` สำหรับแต่ละ paragraph ที่เกี่ยวข้อง
5. เพิ่ม paragraph เหล่านั้นลงใน text frame แล้วบันทึก presentation

ตัวอย่าง C# นี้กำหนดหมายเลขเริ่มต้นแบบกำหนดเองให้กับแต่ละ paragraph:

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

## **ควบคุมการจัดวางและคุณสมบัติ End ของ Paragraph**

### **ตั้งค่า First-Line Indent**

ใช้คุณสมบัติ [IParagraphFormat.Indent](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/indent/) เพื่อควบคุมการเยื้องบรรทัดแรกของ paragraph ค่าติดลบหรือบวกจะย้ายบรรทัดแรกเทียบกับขอบซ้ายของ paragraph เท่านั้น ค่าบวกจะทำให้บรรทัดแรกเลื่อนไปขวา ส่วนบรรทัดที่เหลือคงที่

ใช้ [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/marginleft/) เมื่อคุณต้องการย้ายทั้ง paragraph ใช้ [IParagraphFormat.Indent](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/indent/) หากต้องการย้ายเฉพาะบรรทัดแรก

ตัวอย่างด้านล่างสร้างหลาย paragraph และใช้ค่า [IParagraphFormat.Indent](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/indent/) ที่ต่างกันเพื่อแสดงผลของการเยื้องบรรทัดแรกต่อการจัดวางของ paragraph

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) แบบสี่เหลี่ยมลงในสไลด์
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) ของ shape แล้วลบ paragraph เริ่มต้น
5. สร้างหลาย paragraph แล้วตั้งค่า [Indent](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/indent/) ที่ต่างกันสำหรับแต่ละอัน
6. เพิ่ม paragraph เหล่านั้นลงใน text frame
7. บันทึก presentation ที่แก้ไขแล้ว

โค้ดนี้แสดงวิธีตั้งค่าเยื้องของ paragraph:

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

![การเยื้องบรรทัดแรกของ paragraph](first_line_indent.png)

### **ตั้งค่า Hanging Indent**

Hanging indent คือการจัดวาง paragraph ที่บรรทัดแรกเริ่มอยู่ทางซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟกต์นี้ด้วยคุณสมบัติ [IParagraphFormat.Indent](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/indent/) ตั้งค่า `Indent` เป็นค่าลบเพื่อย้ายบรรทัดแรกไปซ้ายเมื่อเทียบกับเนื้อหา paragraph

โดยปกติ [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/marginleft/) กำหนดตำแหน่งซ้ายของเนื้อหา paragraph ส่วน [IParagraphFormat.Indent](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/indent/) กำหนดตำแหน่งของบรรทัดแรกเทียบกับ margin นั้น การสร้าง hanging indent ทำได้โดยตั้งค่า `MarginLeft` เป็นค่าบวกและ `Indent` เป็นค่าลบ

การจัดรูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม, การอ้างอิง, รายการอภิธานศัพท์, และ paragraph อื่น ๆ ที่บรรทัดพับต้องจัดแนวใต้เนื้อหา paragraph แทนที่จะอยู่ใต้ตัวอักษรแรกของบรรทัดแรก

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) แบบสี่เหลี่ยมลงในสไลด์
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) ของ shape แล้วลบ paragraph เริ่มต้น
5. สร้าง paragraph และตั้งค่า [MarginLeft](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/marginleft/) เป็นค่าบวกสำหรับแต่ละ paragraph
6. ตั้งค่า [Indent](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/indent/) เป็นค่าลบเพื่อสร้างเอฟเฟกต์ hanging indent
7. เพิ่ม paragraph เหล่านั้นลงใน text frame
8. บันทึก presentation ที่แก้ไขแล้ว

โค้ดนี้แสดงวิธีตั้งค่า hanging indent สำหรับ paragraph:

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

![การเยื้องแบบ hanging ของ paragraph](hanging_indent.png)

### **ตั้งค่า End Paragraph Run Properties**

คุณสมบัติ [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/endparagraphportionformat/) ควบคุมการจัดรูปแบบของสัญลักษณ์จบ paragraph ตัวอย่างต่อไปนี้กำหนดขนาดฟอนท์และฟอนท์ Latin ให้กับสัญลักษณ์จบของ paragraph ที่สอง:

1. โหลด [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) แล้วเข้าถึงสไลด์หนึ่ง
2. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) แล้วลบ paragraph เริ่มต้น
3. สร้างสอง paragraph แล้วเพิ่ม portion ของข้อความลงไป
4. สร้าง [PortionFormat](https://reference.aspose.com/slides/th/net/aspose.slides/portionformat/) สำหรับสัญลักษณ์จบของ paragraph ที่สอง
5. ตั้งค่า [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseportionformat/fontheight/) และ [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseportionformat/latinfont/)
6. กำหนดรูปแบบให้กับ [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/endparagraphportionformat/) แล้วบันทึก presentation

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

สำหรับกฎของ paragraph ที่ส่งผลต่อการตัดบรรทัดอัตโนมัติและเครื่องหมายวรรคตอนที่ปลายบรรทัด โปรดดู [Control Line Breaking](/slides/th/net/text-formatting/#control-line-breaking) และ [Control Hanging Punctuation](/slides/th/net/text-formatting/#control-hanging-punctuation)

ใช้ [IParagraph.GetLinesCount](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/getlinescount/) เพื่อให้นับจำนวนบรรทัดที่ paragraph ใช้หลังจากการจัด layout ของข้อความ รวมถึงการตัดบรรทัดอัตโนมัติ ซึ่งมีประโยชน์เมื่อทำการตรวจสอบความยาวของข้อความและการจัด layout ในเทมเพลต presentation

paragraph คือรายการหนึ่งใน [ITextFrame.Paragraphs](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/paragraphs/) และอาจใช้หลายบรรทัดที่แสดงผล การใส่ line break แบบชัดเจนภายใน paragraph จะสร้างบรรทัดใหม่โดยไม่ต้องสร้าง paragraph เพิ่มเติม การตัดบรรทัดอัตโนมัติสร้างบรรทัดตามความกว้างที่มีอยู่โดยไม่แทรก line break ลงในข้อความ ดังนั้นการนับ paragraph หรือตัวอักษร line‑break จะไม่ให้จำนวนบรรทัดที่แสดงผลได้

ตัวอย่างต่อไปนี้สร้างรูปทรงข้อความ, นับบรรทัด, ลดความกว้างของรูปทรง, แล้วเปลี่ยนข้อความเป็นสตริงสั้นกว่า เปิดการตัดบรรทัดและปิด autofit เพื่อให้ความกว้างของรูปทรงควบคุมการตัดบรรทัดโดยไม่ปรับขนาดข้อความหรือรูปทรงโดยอัตโนมัติ ขนาดของรูปทรงกำหนดเป็นพอยต์ สุดท้ายตัวอย่างเพิ่ม paragraph อีกหนึ่งรายการและรวมจำนวนบรรทัดทั้งหมดใน text frame

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

ด้วยข้อความและขนาดเหล่านี้ การทำให้รูปทรงแคบลงจะเพิ่มจำนวนบรรทัด ส่วนการเปลี่ยนข้อความเป็นสตริงสั้นจะลดจำนวนบรรทัด จำนวนที่แน่นอนอาจแตกต่างตามฟอนท์ที่มีอยู่และการแทนที่, ขนาดฟอนท์, margin, การเยื้อง, การตัดบรรทัด, และการตั้งค่า autofit ใช้ฟอนท์และการตั้งค่า layout ที่ตั้งใจสำหรับสภาพแวดล้อมเป้าหมายเมื่อทำการตรวจสอบเทมเพลต

จำนวนบรรทัดเพียงอย่างเดียวไม่บ่งบอกว่าข้อความล้นพื้นที่ของคอนเทนเนอร์หรือไม่ ความสูงที่มีอยู่, ความสูงของบรรทัด, ระยะห่างของ paragraph และบรรทัด, และพฤติกรรม autofit ยังมีส่วนสำคัญ; แม้บรรทัดเดียวก็อาจเกินความกว้างที่มีอยู่เมื่อปิดการตัดบรรทัด

## **นำเข้าและส่งออกเนื้อหา Paragraph**

### **นำเข้า HTML Text ไปยัง Paragraphs**

ใช้ [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/th/net/aspose.slides/paragraphcollection/addfromhtml/) เพื่อแปลง markup HTML เป็น paragraph และ portion ภายใน text frame

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
2. เข้าถึงสไลด์และเพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/)
3. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) ของ shape แล้วลบ paragraph เริ่มต้น
4. อ่านไฟล์ HTML ต้นทาง
5. ส่งสตริง HTML ไปยัง [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/th/net/aspose.slides/paragraphcollection/addfromhtml/)
6. บันทึก presentation ที่แก้ไขแล้ว

ตัวอย่าง C# นี้นำเข้า HTML ไปยัง text frame:

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

### **ส่งออกข้อความ Paragraph เป็น HTML**

ใช้ [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/th/net/aspose.slides/paragraphcollection/exporttohtml/) เพื่อส่งออกช่วงของ paragraph ที่เลือกเป็น HTML

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) แล้วโหลด presentation ที่ต้องการ
2. เข้าถึงสไลด์และค้นหา [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ที่มีข้อความอยู่
3. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) ของ shape
4. เรียก [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/th/net/aspose.slides/paragraphcollection/exporttohtml/) พร้อมกับดัชนี paragraph เริ่มต้นและจำนวน paragraph ที่ต้องการส่งออก
5. เขียนสตริง HTML ที่ได้ไปยังไฟล์

ตัวอย่าง C# นี้ส่งออก paragraph ทั้งหมดจาก shape ข้อความแรก:

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

### **เรนเดอร์ Paragraph ให้เป็นภาพ**

[IParagraph.GetImage](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/getimage/) เรนเดอร์ paragraph แยกแต่ละอันโดยตรงและคืนค่า [IImage](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/) คุณสามารถบันทึกผลลัพธ์เป็นไฟล์หรือสตรีมด้วย [IImage.Save](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/save/) ไม่จำเป็นต้องเรนเดอร์ shape ที่บรรจุหรือครอภาพด้วยตนเอง

[IParagraph.GetImage](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/getimage/) อาจคืนค่า `null` หากไม่พบ paragraph ในคอลเลกชันแม่, ไม่มีขอบเขตการเรนเดอร์ที่ถูกต้อง, หรือไม่สามารถเรนเดอร์ได้ ตรวจสอบผลลัพธ์ก่อนบันทึกและทำลายภาพที่คืนค่าหลังใช้

#### **เรนเดอร์ Paragraph ที่สเกลเริ่มต้น**

สมมติว่าเรามีไฟล์ presentation ชื่อ sample.pptx มีหนึ่งสไลด์ ซึ่ง shape แรกเป็น text box ที่มีสาม paragraph

![Text box ที่มีสาม paragraph](paragraph_to_image_input.png)

ตัวอย่างต่อไปนี้เรนเดอร์ paragraph ที่สองใน text shape ปกติที่สเกลเริ่มต้นและบันทึกภาพที่ได้เป็น PNG การใช้ `using` ทำให้แน่ใจว่าภาพถูกทำลายอย่างถูกต้อง

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

![ภาพของ paragraph](paragraph_to_image_output.png)

#### **เรนเดอร์ Paragraph ในเซลล์ตารางพร้อมสเกล**

ใช้การโอเวอร์โหลดของ [IParagraph.GetImage](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/getimage/) ที่รับพารามิเตอร์ `float scaleX` และ `float scaleY` เพื่อตั้งค่าปัจจัยสเกลแนวนอนและแนวตั้ง ตัวอย่างต่อไปนี้สร้างตาราง, เรนเดอร์ paragraph ในเซลล์แรกโดยขยายความกว้างและความสูงเป็นสองเท่าของค่ามาตรฐาน, แล้วบันทึกผลเป็นภาพ PNG

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

ปัจจัยสเกล `1` รักษาขนาดพิกเซลเริ่มต้น ตัวอย่างเช่น `2` สำหรับทั้งสองปัจจัยจะให้ภาพที่กว้างและสูงประมาณสองเท่าของขนาดมาตรฐาน ทำให้จำนวนพิกเซลเพิ่มเป็นสี่เท่า ปัจจัยที่สูงกว่าให้ข้อความคมชัดมากขึ้นสำหรับการซูมหรือการส่งออกความละเอียดสูง แต่ก็เพิ่มการใช้หน่วยความจำและขนาดไฟล์ ปัจจัยที่ต่ำกว่า `1` ให้ภาพเล็กลงและรายละเอียดน้อยลง ใช้ปัจจัยเท่ากันเพื่อรักษาอัตราส่วนของ paragraph; ปัจจัยแนวนอนและแนวตั้งที่แตกต่างกันจะยืดผลลัพธ์อย่างอิสระ

การเรนเดอร์ shape ทั้งหมดด้วย [IShape.GetImage](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/getimage/) ยังคงมีประโยชน์เมื่อผลลัพธ์ต้องรวมการเติมสี, เส้นขอบ หรือบริบทภาพอื่นของ shape สำหรับภาพที่มีเฉพาะ paragraph ให้ใช้ [IParagraph.GetImage](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/getimage/)

## **FAQ**

**ฉันสามารถปิดการตัดบรรทัดอัตโนมัติภายใน text frame ได้ทั้งหมดหรือไม่?**

ได้. ตั้งค่า [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat/wraptext/) เพื่อปิดการตัดบรรทัด ทำให้บรรทัดไม่แตกที่ขอบของ text frame

**ฉันจะดึงค่าขอบเขตบนสไลด์ของ paragraph เฉพาะได้อย่างไร?**

ใช้ [IParagraph.GetRect](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/getrect/) เพื่อรับสี่เหลี่ยมขอบของ paragraph. [IPortion.GetRect](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/getrect/) ให้ขอบเขตของ portion แต่ละอัน

**การจัดแนวของ paragraph (ซ้าย, ขวา, กลาง, หรือจัดเต็ม) ถูกควบคุมที่ไหน?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/alignment/) เป็นการตั้งค่าระดับ paragraph และใช้กับทั้ง paragraph โดยไม่คำนึงถึงการจัดรูปแบบของ portion แยกต่างหาก

**ฉันสามารถตั้งค่าภาษาตรวจสอบของส่วนหนึ่งของ paragraph ได้หรือไม่?**

ได้. ตั้งค่า [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseportionformat/languageid/) สำหรับ portion แต่ละอัน ทำให้ paragraph หนึ่งสามารถมีข้อความหลายภาษาได้