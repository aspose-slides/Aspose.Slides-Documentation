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
- สัญลักษณ์หัวข้อย่อหน้า
- รายการลำดับเลข
- รายการหัวข้อ
- คุณสมบัติเย้อหน้า
- นำเข้า HTML
- ข้อความเป็น HTML
- ย่อหน้าเป็น HTML
- ย่อหน้าเป็นภาพ
- ขข้อความเป็นภาพ
- ส่งออกย่อหน้า
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและจัดรูปแบบย่อหน้า, portion, bullet, รายการลำดับเลข, การเยื้อง, เนื้อหา HTML, และภาพย่อหน้าโดยใช้ Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

Aspose.Slides for .NET แสดงข้อความเป็นโครงสร้างลำดับขั้นของ text frames, paragraphs, และ portions:

* [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) เป็นตัวบรรจุกข้อความในรูปร่างและให้การเข้าถึงคอลเลกชันของย่อหน้า
* [IParagraph](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/) เป็นย่อหน้าหนึ่งใน text frame และให้การเข้าถึงส่วนต่างๆ และการจัดรูปแบบระดับย่อหน้า
* [IPortion](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/) เป็นรันข้อความภายในย่อหน้า แต่ละ portion สามารถมีข้อความและการจัดรูปแบบระดับอักขระของตนเอง

ดังนั้นย่อหน้าจึงสามารถบรรจุข้อความที่มีฟอนต์, สี, ขนาด, และการจัดรูปแบบอื่นๆ ที่ต่างกันได้โดยใช้หลาย portion

## **สร้างและจัดรูปแบบย่อหน้า**

### **สร้างย่อหน้าด้วยหลาย Portion**

ขั้นตอนต่อไปนี้สร้าง text frame ที่มีสามย่อหน้า, แต่ละย่อหน้ามีสาม portion:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
2. เข้าถึงอ้างอิงของสไลด์ที่เกี่ยวข้องผ่านดัชนีของมัน
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) แบบสี่เหลี่ยมผืนผ้าไปยังสไลด์
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) ของรูปร่าง
5. ใช้ย่อหน้าเริ่มต้นและเพิ่มอ็อบเจ็กต์ [IParagraph](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/) เพิ่มอีกสองตัวไปยัง text frame
6. เพิ่มอ็อบเจ็กต์ [IPortion](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/) ให้เพียงพอสำหรับแต่ละย่อหน้าเพื่อให้มีสาม portion โดยย่อหน้าเริ่มต้นมีหนึ่ง portion ว่างอยู่แล้ว
7. ตั้งค่าข้อความของแต่ละ portion
8. ใช้การจัดรูปแบบระดับอักขระผ่าน [IPortion.PortionFormat](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/portionformat/)
9. บันทึกการนำเสนอที่แก้ไขแล้ว

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

## **สร้างรายการที่มีหัวข้อและลำดับเลข**

### **สร้างรายการหัวข้อหรือรายการลำดับเลข**

Bullets และ numbering ทำให้รายการที่เกี่ยวข้องอ่านง่ายขึ้น ใน Aspose.Slides การตั้งค่ารายการกำหนดผ่าน [IBulletFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/)

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
2. เข้าถึงอ้างอิงของสไลด์ที่เกี่ยวข้องผ่านดัชนีของมัน
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ไปยังสไลด์ที่เลือก
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) ของรูปร่าง
5. ลบย่อหน้าเริ่มต้นออกจาก text frame
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/net/aspose.slides/paragraph/) สำหรับ bullet แบบสัญลักษณ์
7. ตั้งค่า [IBulletFormat.Type](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/type/) เป็น [BulletType.Symbol](https://reference.aspose.com/slides/th/net/aspose.slides/bullettype/) แล้วระบุอักขระ bullet
8. ตั้งค่าข้อความของย่อหน้า, ระยะเยื้อง, สีของ bullet, และความสูงของ bullet
9. เพิ่มย่อหน้าไปยัง text frame
10. สร้างย่อหน้าที่สองและตั้งค่า [IBulletFormat.Type](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/type/) เป็น [BulletType.Numbered](https://reference.aspose.com/slides/th/net/aspose.slides/bullettype/)
11. กำหนดสไตล์ของ bullet แบบลำดับเลขแล้วเพิ่มย่อหน้าไปยัง text frame
12. บันทึกการนำเสนอ

ตัวอย่าง C# นี้สร้าง bullet แบบสัญลักษณ์และ bullet แบบลำดับเลข:

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

### **ใช้หัวข้อแบบภาพ**

Picture bullets ให้คุณใช้ภาพที่กำหนดเองแทนสัญลักษณ์หรือหมายเลข

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
2. เข้าถึงอ้างอิงของสไลด์ที่เกี่ยวข้องผ่านดัชนีของมัน
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) แล้วเข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) ของมัน
4. ลบย่อหน้าเริ่มต้นออกจาก text frame
5. โหลดรูปภาพ bullet แล้วเพิ่มไปยังคอลเลกชันภาพของการนำเสนอเป็น [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/)
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/net/aspose.slides/paragraph/) แล้วตั้งค่าข้อความของมัน
7. ตั้งค่า [IBulletFormat.Type](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/type/) เป็น [BulletType.Picture](https://reference.aspose.com/slides/th/net/aspose.slides/bullettype/)
8. กำหนดภาพผ่าน [IBulletFormat.Picture](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/picture/) แล้วตั้งค่าความสูงของ bullet
9. เพิ่มย่อหน้าไปยัง text frame
10. บันทึกการนำเสนอที่แก้ไขแล้ว

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

### **สร้างรายการหลายระดับ**

ตั้งค่า [IParagraphFormat.Depth](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/depth/) เพื่อวางย่อหน้าในระดับต่างๆ ของรายการ ระดับบนสุดมีความลึก `0`

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) แล้วเข้าถึงสไลด์หนึ่งสไลด์
2. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) แล้วลบย่อหน้าเริ่มต้นออกจาก text frame ของมัน
3. สร้างสี่ย่อหน้าและกำหนดสัญลักษณ์ bullet ของแต่ละอัน
4. ตั้งค่าความลึกของพวกมันด้วย [IParagraphFormat.Depth](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/depth/) เป็น `0`, `1`, `2`, และ `3`
5. เพิ่มย่อหน้าเหล่านั้นไปยัง text frame แล้วบันทึกการนำเสนอ

ตัวอย่าง C# นี้สร้างรายการหัวข้อสี่ระดับ:

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

### **เริ่มรายการลำดับเลขที่ค่าที่กำหนดเอง**

ใช้ [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/numberedbulletstartwith/) เพื่อตั้งค่าตัวเลขเริ่มต้นที่จะแสดงสำหรับย่อหน้าแบบลำดับเลข

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) แล้วเพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ไปยังสไลด์หนึ่งสไลด์
2. ลบย่อหน้าเริ่มต้นออกจาก text frame ของรูปร่าง
3. สร้างย่อหน้าแบบลำดับเลขสามย่อหน้า
4. ตั้งค่า [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/th/net/aspose.slides/ibulletformat/numberedbulletstartwith/) เป็น `2`, `3`, และ `7` สำหรับย่อหน้าตามลำดับ
5. เพิ่มย่อหน้าเหล่านั้นไปยัง text frame แล้วบันทึกการนำเสนอ

ตัวอย่าง C# นี้กำหนดตัวเลขเริ่มต้นแบบกำหนดเองให้กับแต่ละย่อหน้า:

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

## **ควบคุมการจัดวางย่อหน้าและคุณสมบัติสิ้นสุด**

### **ตั้งระยะเยื้อมบรรทัดแรก**

ใช้คุณสมบัติ [IParagraphFormat.Indent](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/indent/) เพื่อควบคุมระยะเยื้องของบรรทัดแรกของย่อหน้า คุณสมบัตินี้จะย้ายเฉพาะบรรทัดแรกเทียบกับขอบซ้ายของย่อหน้า ค่าบวกจะเลื่อนบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือจะคงตำแหน่งตามตัวอักษรของย่อหน้า

ใช้ [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/marginleft/) เมื่อคุณต้องการย้ายทั้งย่อหน้า ใช้ [IParagraphFormat.Indent](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/indent/) เมื่อคุณต้องการย้ายเฉพาะบรรทัดแรก

ตัวอย่างด้านล่างสร้างย่อหน้าหลายย่อหน้าและกำหนดค่าต่างๆ ของ [IParagraphFormat.Indent] เพื่อแสดงว่า ระยะเยื้อมบรรทัดแรกมีผลต่อการจัดวางอย่างไร

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) แบบสี่เหลี่ยมผืนผ้าไปยังสไลด์
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) ของรูปร่างและลบย่อหน้าเริ่มต้นออก
5. สร้างย่อหน้าหลายย่อหน้าและกำหนดค่าต่างๆ ของ [Indent](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/indent/) ให้กับพวกมัน
6. เพิ่มย่อหน้าเหล่านั้นไปยัง text frame
7. บันทึกการนำเสนอที่แก้ไขแล้ว

โค้ดนี้แสดงวิธีตั้งระยะเยื้อมบรรทัดแรกของย่อหน้า:

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

![ระยะเยื้อมบรรทัดแรกของย่อหน้า](first_line_indent.png)

### **ตั้งระยะเยือนแบบห้อย**

ระยะเยือนแบบห้อยคือการจัดวางย่อหน้าที่บรรทัดแรกเริ่มอยู่ซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟกต์นี้ด้วยคุณสมบัติ [IParagraphFormat.Indent] ตั้งค่า `Indent` เป็นค่าติดลบเพื่อย้ายบรรทัดแรกไปทางซ้ายเมื่อเทียบกับตัวอักษรของย่อหน้า

ในการใช้งานจริง [IParagraphFormat.MarginLeft] กำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้า และ [IParagraphFormat.Indent] กำหนดตำแหน่งของบรรทัดแรกเทียบกับขอบซ้ายนั้น เพื่อสร้างระยะเยือนแบบห้อย ให้ตั้งค่า `MarginLeft` เป็นค่าบวกและ `Indent` เป็นค่าติดลบ

การจัดรูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม, การอ้างอิง, รายการพจนานุกรม, และย่อหน้าอื่นๆ ที่บรรทัดหักต้องจัดแนวไว้ใต้เนื้อหาย่อหน้าแทนที่จะอยู่ใต้ตัวอักษรแรกของบรรทัดแรก

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) แบบสี่เหลี่ยมผืนผ้าไปยังสไลด์
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) ของรูปร่างและลบย่อหน้าเริ่มต้นออก
5. สร้างย่อหน้าและตั้งค่า [MarginLeft](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/marginleft/) เป็นค่าบวกสำหรับแต่ละย่อหน้า
6. ตั้งค่า [Indent](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/indent/) เป็นค่าติดลบเพื่อสร้างเอฟเฟกต์ระยะเยือนแบบห้อย
7. เพิ่มย่อหน้าเหล่านั้นไปยัง text frame
8. บันทึกการนำเสนอที่แก้ไขแล้ว

โค้ดนี้แสดงวิธีตั้งระยะเยือนแบบห้อยสำหรับย่อหน้า:

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

![ระยะเยือนแบบห้อยของย่อหน้า](hanging_indent.png)

### **ตั้งคุณสมบัติการรันของสิ้นสุดย่อหน้า**

คุณสมบัติ [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/endparagraphportionformat/) ควบคุมการจัดรูปแบบของเครื่องหมายสิ้นสุดย่อหน้า ตัวอย่างต่อไปนี้กำหนดขนาดฟอนต์และฟอนต์ Latin ให้กับเครื่องหมายสิ้นสุดของย่อหน้าที่สอง:

1. โหลด [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) แล้วเข้าถึงสไลด์หนึ่งสไลด์
2. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) แล้วลบย่อหน้าเริ่มต้นออก
3. สร้างย่อหน้าสองย่อหน้าและเพิ่มส่วนข้อความลงในแต่ละย่อหน้า
4. สร้าง [PortionFormat](https://reference.aspose.com/slides/th/net/aspose.slides/portionformat/) สำหรับเครื่องหมายสิ้นสุดของย่อหน้าที่สอง
5. ตั้งค่า [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseportionformat/fontheight/) และ [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseportionformat/latinfont/)
6. กำหนดรูปแบบให้กับ [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/endparagraphportionformat/) แล้วบันทึกการนำเสนอ

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

## **นำเข้าและส่งออกเนื้อหาย่อหน้า**

### **นำเข้าข้อความ HTML ไปยังย่อหน้า**

ใช้ [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/th/net/aspose.slides/paragraphcollection/addfromhtml/) เพื่อแปลง markup HTML ให้เป็นย่อหน้าและ portion ภายใน text frame

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
2. เข้าถึงสไลด์และเพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/)
3. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) ของรูปร่างและลบย่อหน้าเริ่มต้นออก
4. อ่านไฟล์ HTML ต้นทาง
5. ส่งสตริง HTML ให้กับ [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/th/net/aspose.slides/paragraphcollection/addfromhtml/)
6. บันทึกการนำเสนอที่แก้ไขแล้ว

ตัวอย่าง C# นี้นำเข้า HTML เข้าไปใน text frame:

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

ใช้ [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/th/net/aspose.slides/paragraphcollection/exporttohtml/) เพื่อส่งออกช่วงย่อหน้าที่เลือกเป็น HTML

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) แล้วโหลดการนำเสนอที่ต้องการ
2. เข้าถึงสไลด์และค้นหา [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ที่มีข้อความ
3. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) ของรูปร่าง
4. เรียก [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/th/net/aspose.slides/paragraphcollection/exporttohtml/) พร้อมดัชนีย่อหน้าเริ่มต้นและจำนวนย่อหน้าที่ต้องส่งออก
5. เขียนสตริง HTML ที่ส่งกลับไปยังไฟล์

ตัวอย่าง C# นี้ส่งออกย่อหน้าทั้งหมดจากรูปข้อความแรก:

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

[IParagraph.GetImage](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/getimage/) เรนเดอร์ย่อหน้าเดี่ยวโดยตรงและคืนค่าเป็น [IImage](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/) ให้บันทึกผลลัพธ์เป็นไฟล์หรือสตรีมด้วย [IImage.Save](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/save/) คุณไม่จำเป็นต้องเรนเดอร์รูปร่างที่บรรจุหรือครอบตัดบิตแมปด้วยตนเอง

[IParagraph.GetImage](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/getimage/) อาจคืนค่า `null` หากไม่พบย่อหน้าในคอลเลกชันแม่, มีขอบเขตการเรนเดอร์ที่ไม่ถูกต้อง, หรือไม่สามารถเรนเดอร์ได้ ตรวจสอบผลลัพธ์ก่อนบันทึกและทำการ dispose ภาพที่คืนค่าหลังใช้งาน

#### **เรนเดอร์ย่อหน้าที่สเกลเริ่มต้น**

สมมติว่าเรามีไฟล์การนำเสนอชื่อ sample.pptx ที่มีสไลด์หนึ่งสไลด์ โดยรูปร่างแรกเป็นกล่องข้อความที่มีสามย่อหน้า

![กล่องข้อความที่มีสามย่อหน้า](paragraph_to_image_input.png)

ตัวอย่างต่อไปนี้เรนเดอร์ย่อหน้าที่สองในรูปข้อความทั่วไปที่สเกลเริ่มต้นและบันทึกภาพที่คืนค่าเป็นรูป PNG คำสั่ง `using` ทำให้แน่ใจว่าภาพจะถูก dispose อย่างถูกต้อง

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

![ภาพของย่อหน้า](paragraph_to_image_output.png)

#### **เรนเดอร์ย่อหน้าในเซลล์ตารางพร้อมการสเกล**

ใช้ overload ของ [IParagraph.GetImage](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/getimage/) ที่รับพารามิเตอร์ `float scaleX` และ `float scaleY` เพื่อกำหนดค่าปัจจัยสเกลแนวนอนและแนวตั้ง ตัวอย่างต่อไปนี้สร้างตาราง, เรนเดอร์ย่อหน้าในเซลล์แรกที่กว้างและสูงเป็นสองเท่าของค่าปริยาย, แล้วบันทึกผลเป็นภาพ PNG

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

ค่าปัจจัยสเกล `1` จะทำให้แกนนั้นคงขนาดพิกเซลปริยาย ตัวอย่างเช่น `2` สำหรับทั้งสองแกนจะให้ภาพที่กว้างและสูงประมาณสองเท่าของขนาดปริยาย ทำให้จำนวนพิกเซลเพิ่มเป็นสี่เท่า ปัจจัยที่มากกว่าจะทำให้ข้อความคมชัดยิ่งขึ้นสำหรับการซูมหรือเอาต์พุตความละเอียดสูง, แต่ก็เพิ่มการใช้หน่วยความจำและขนาดไฟล์ ปัจจัยต่ำกว่า `1` จะให้ภาพเล็กลงพร้อมรายละเอียดน้อยลง ใช้ปัจจัยเท่ากันเพื่อคงอัตราส่วนของย่อหน้า; ปัจจัยแนวนอนและแนวตั้งที่ต่างกันจะยืดภาพออกอย่างอิสระ

การเรนเดอร์รูปร่างทั้งหมดด้วย [IShape.GetImage](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/getimage/) ยังคงมีประโยชน์เมื่อผลลัพธ์ต้องรวมการเติมสี, เส้นขอบ, หรือบริบทภาพอื่นของรูปร่าง สำหรับภาพเฉพาะย่อหน้าให้ใช้ [IParagraph.GetImage](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/getimage/)

## **คำถามที่พบบ่อย**

**ฉันสามารถปิดการเติมบรรทัดภายใน text frame ได้หรือไม่?**

ใช่. ตั้งค่า [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat/wraptext/) เพื่อปิดการเติมบรรทัดเพื่อให้บรรทัดไม่ตัดที่ขอบของ text frame

**ฉันจะรับขอบเขตบนสไลด์ที่แน่นอนของย่อหน้าเฉพาะได้อย่างไร?**

ใช้ [IParagraph.GetRect](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/getrect/) เพื่อดึงสี่เหลี่ยมขอบเขตของย่อหน้า [IPortion.GetRect](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/getrect/) ให้ขอบเขตของ portion รายบุคคล

**ตำแหน่งการจัดย่อหน้า (ซ้าย, ขวา, กลาง หรือจัดเต็ม) ควบคุมที่ไหน?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/alignment/) เป็นการตั้งค่าระดับย่อหน้าและใช้กับทั้งย่อหน้าโดยไม่คำนึงถึงการจัดรูปแบบของ portion แยกแต่ละอัน

**ฉันสามารถตั้งค่าภาษา proofing สำหรับบางส่วนของย่อหน้าได้หรือไม่?**

ใช่. ตั้งค่า [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseportionformat/languageid/) สำหรับ portion แต่ละอัน เพื่อให้ย่อหน้าหนึ่งสามารถมีข้อความหลายภาษาได้