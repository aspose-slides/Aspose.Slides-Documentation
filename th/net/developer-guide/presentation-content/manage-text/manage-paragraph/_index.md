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
  - จัดการหัวข้อ
  - เยื้องย่อหน้า
  - เยื้องล้อย
  - หัวข้อย่อหน้า
  - รายการลำดับเลข
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
description: "เรียนรู้วิธีสร้างและจัดรูปแบบย่อหน้า ส่วนย่อย หัวข้อ รายการลำดับเลข เยื้อง เนื้อหา HTML และภาพย่อหน้าด้วย Aspose.Slides สำหรับ .NET"
---
## **ภาพรวม**

Aspose.Slides for .NET แสดงข้อความเป็นลำดับชั้นของกรอบข้อความ ย่อหน้า และส่วนย่อย:

* [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) เป็นตัวเก็บข้อความในรูปทรงและให้เข้าถึงคอลเลกชันของย่อหน้า
* [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) เป็นย่อหน้าเดียวในกรอบข้อความและให้เข้าถึงส่วนย่อยและการจัดรูปแบบระดับย่อหน้า
* [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) เป็นการรันข้อความภายในย่อหน้า แต่ละส่วนย่อยสามารถมีข้อความและการจัดรูปแบบระดับอักขระของตนเอง

ดังนั้น ย่อหน้าจึงสามารถมีข้อความที่มีฟอนต์ สี ขนาด และการจัดรูปแบบอื่น ๆ แตกต่างกันโดยใช้หลายส่วนย่อย

## **สร้างและจัดรูปแบบย่อหน้า**

สร้างย่อหน้าในกรอบข้อความของรูปทรงและใช้ส่วนย่อยเพื่อจัดรูปแบบการรันข้อความแต่ละอัน ส่วนนี้แสดงวิธีรวมหลายส่วนย่อยภายในแต่ละย่อหน้าและใช้สี ขนาดฟอนต์ และสไตล์ที่ต่างกัน

### **สร้างย่อหน้าด้วยหลายส่วนย่อย**

ตัวอย่าง C# ด้านล่างสร้างย่อหน้า 3 ย่อหน้า แต่ละย่อหน้ามีส่วนย่อย 3 ตัวในคอลเลกชัน [IParagraph.Portions](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/portions/) มันใช้ย่อหน้าเริ่มต้นและส่วนย่อยว่างเปล่า จากนั้นเพิ่มย่อหน้าและส่วนย่อยที่เหลือ การจัดรูปแบบทำผ่าน [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/) : ส่วนย่อยแรกของแต่ละย่อหน้าเป็นสีแดง หนาและขนาด 15 จุด ; ส่วนที่สองเป็นสีน้ำเงิน เอียงและขนาด 18 จุด ; ส่วนที่สามคงการจัดรูปแบบเริ่มต้นไว้:

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

จัดระเบียบข้อความย่อหน้าเป็นรายการด้วยสัญลักษณ์ ตัวเลข หรือภาพที่กำหนดเอง ตัวอย่างในส่วนนี้ครอบคลุมการจัดรูปแบบหัวข้อ รายการหลายระดับ และการกำหนดเลขเริ่มต้นแบบกำหนดเอง

### **สร้างรายการแบบหัวข้อหรือเลขลำดับ**

หัวข้อและการเรียงเลขทำให้รายการที่เกี่ยวข้องอ่านง่ายขึ้น ใน Aspose.Slides การตั้งค่ารายการกำหนดโดยผ่าน [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) 

ตัวอย่าง C# นี้เพิ่มหัวข้อสัญลักษณ์และรายการเลขในกรอบข้อความเดียวกัน [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) เลือกประเภทหัวข้อ ขณะที่ [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) ระบุสัญลักษณ์และ [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) เลือกสไตล์การนับเลข ทั้งสองรายการใช้หัวข้อสีดำ ความสูง 100 เปอร์เซ็นต์ และการเยื้องย่อหน้าที่ 25 จุด:

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

### **ใช้หัวข้อภาพ**

หัวข้อภาพให้คุณใช้ภาพกำหนดเองแทนสัญลักษณ์หรือเลข

ตัวอย่าง C# นี้เพิ่มรูปภาพลงในคอลเลกชันรูปภาพของงานนำเสนอเป็น [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) และใช้เป็นหัวข้อย่อหน้า มันตั้งค่า [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) ให้ใช้หัวข้อภาพและกำหนดภาพผ่าน [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/) [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) ตั้งเป็น 100 เปอร์เซ็นต์เพื่อกำหนดขนาดหัวข้อสัมพันธ์กับข้อความย่อหน้า:

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

ตั้งค่า [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) เพื่อวางย่อหน้าในระดับต่าง ๆ ของรายการ ระดับบนสุดมีความลึก `0`

ตัวอย่าง C# นี้กำหนดค่า [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) จาก 0 ถึง 3 ให้กับย่อสี่ย่อหน้า สร้างลำดับชั้นภายในกรอบข้อความเดียว แต่ละย่อหน้าใช้หัวข้อสัญลักษณ์ โดยที่ [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) สลับระหว่างหัวข้อวงกลมและขีด เพื่อแยกระดับที่อยู่ติดกัน:

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

### **เริ่มรายการเลขที่ค่าที่กำหนดเอง**

ใช้ [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) เพื่อตั้งค่าตัวเลขเริ่มต้นของย่อหน้าที่เป็นเลขลำดับ

ตัวอย่าง C# นี้ตั้งค่า [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) ให้ใช้การนับเลขสำหรับสามย่อหน้าและกำหนดค่า [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) เป็น 2, 3, และ 7 ค่าเริ่มต้นกำหนดแยกสำหรับแต่ละย่อหน้า ทำให้เลขที่แสดงข้ามค่าได้:

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

## **ควบคุมการจัดวางและคุณสมบัติการจบของย่อหน้า**

ปรับระยะขอบและการเยื้องของย่อหน้าเพื่อควบคุมตำแหน่งของบรรทัดแรกและบรรทัดหุ้ม คุณยังสามารถจัดรูปแบบเครื่องหมายจบย่อหน้าแยกจากส่วนข้อความที่มองเห็นได้

### **ตั้งค่าเยื้องบรรทัดแรก**

ใช้คุณสมบัติ [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) เพื่อควบคุมเยื้องบรรทัดแรกของย่อหน้า คุณสมบัตินี้ย้ายบรรทัดแรกเท่านั้นสัมพันธ์กับระยะขอบซ้ายของย่อหน้า ค่าเป็นบวกจะย้ายบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือคงอยู่ตามตำแหน่งของย่อหน้า

ใช้ [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) เมื่อคุณต้องการย้ายย่อหน้าทั้งหมด ใช้ [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) เมื่อคุณต้องการย้ายเฉพาะบรรทัดแรก

ตัวอย่างต่อไปนี้ให้ย่อหน้า 3 ย่อหน้ามี [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) เท่ากับ 20 จุดและค่า [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) เป็น 0, 20, และ 40 จุด บรรทัดแรกเริ่มที่ระยะห่างเพิ่มขึ้นเรื่อย ๆ ในขณะที่บรรทัดหุ้มคงระยะขอบซ้ายเดิม:

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

### **ตั้งค่าเยื้องล้อย**

เยื้องล้อยคือการจัดวางย่อหน้าที่บรรทัดแรกเริ่มอยู่ซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟกต์นี้ด้วยคุณสมบัติ [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) ตั้งค่า `Indent` เป็นค่าลบเพื่อย้ายบรรทัดแรกไปทางซ้ายสัมพันธ์กับเนื้อหาย่อหน้า

โดยปกติ [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) กำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้า และ [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) กำหนดตำแหน่งของบรรทัดแรกสัมพันธ์กับระยะขอบนั้น เพื่อสร้างเยื้องล้อย ให้ตั้งค่า `MarginLeft` เป็นบวกและ `Indent` เป็นลบ

การจัดรูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม อ้างอิง รายการอภิธานศัพท์ และย่อหน้าอื่น ๆ ที่บรรทัดหุ้มต้องจัดแนวใต้เนื้อหาย่อหน้าแทนที่จะอยู่ใต้ตัวอักษรแรกของบรรทัดแรก

ตัวอย่าง C# ต่อไปนี้จับคู่ค่า [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) ที่ 40 และ 60 จุดกับค่า [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) ที่ -20 และ -30 จุด ในแต่ละย่อหน้า บรรทัดแรกเริ่มอยู่ซ้ายของบรรทัดหุ้ม; ย่อหน้าที่สองมีเยื้องล้อยที่ลึกกว่า:

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

![การเยื้องล้อยของย่อหน้า](hanging_indent.png)

### **ตั้งค่าคุณสมบัติการรันย่อหน้าสิ้นสุด**

คุณสมบัติ [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) ควบคุมการจัดรูปแบบของเครื่องหมายจบย่อหน้า ตัวอย่างต่อไปนี้สร้าง [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) ที่ตั้งค่า [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) เป็น 48 จุดและ [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/latinfont/) เป็น Times New Roman จากนั้นกำหนดรูปแบบนี้ให้กับเครื่องหมายจบของย่อหน้าที่สองโดยไม่กระทบส่วนข้อความที่มองเห็น:

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

สำหรับกฎย่อหน้าที่ส่งผลต่อการห่ออัตโนมัติและเครื่องหมายวรรคตอนที่ท้ายบรรทัด ดู [Control Line Breaking](/slides/th/net/text-formatting/#control-line-breaking) และ [Control Hanging Punctuation](/slides/th/net/text-formatting/#control-hanging-punctuation)

ใช้ [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) เพื่อหารจำนวนบรรทัดที่ย่อหน้าใช้หลังจากการวางข้อความรวมถึงการห่ออัตโนมัติ ซึ่งเป็นประโยชน์เมื่อพิจารณาความยาวและการจัดวางข้อความในเทมเพลตงานนำเสนอ

ย่อหน้าเป็นหนึ่งรายการใน [ITextFrame.Paragraphs](https://reference.aspose.com/slides/net/aspose.slides/itextframe/paragraphs/) และอาจใช้หลายบรรทัดที่แสดงผล การใส่การตัดบรรทัดอย่างชัดเจนในย่อหน้าให้บรรทัดใหม่โดยไม่ต้องสร้างย่อหน้าใหม่ การห่ออัตโนมัติสร้างบรรทัดโดยอิงความกว้างที่มีอยู่โดยไม่ต้องแทรกอักขระตัดบรรทัด การนับย่อหน้าหรืออักขระ \n จึงไม่ให้จำนวนบรรทัดที่แสดงผล

ตัวอย่างต่อไปนี้สร้างรูปแบบข้อความ นับบรรทัดของมัน แคบรูปทรงลง แล้วแทนที่ข้อความด้วยสตริงสั้นกว่า ตัวอย่างเปิดใช้ [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) และปิด [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) เพื่อให้ความกว้างรูปทรงควบคุมการห่อโดยไม่ย่อข้อความหรือปรับขนาดรูปทรง การวัดแต่ละครั้งใช้ [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) มิติของรูปทรงเป็นจุด สุดท้าย ตัวอย่างเพิ่มย่อหน้าอีกหนึ่งย่อหน้าและรวมจำนวนบรรทัดทั้งหมดในกรอบข้อความ

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

ด้วยข้อความและมิติเหล่านี้ การแคบรูปทรงเพิ่มจำนวนบรรทัด ส่วนการแทนที่ด้วยสตริงสั้นลดจำนวนบรรทัด จำนวนที่แน่นอนอาจแตกต่างตามฟอนต์ที่ใช้และการทดแทน ขนาดฟอนต์ ระยะขอบ การเยื้อง การห่อ และการตั้งค่า autofit ใช้ฟอนต์และการตั้งค่าการจัดวางที่ตั้งใจสำหรับสภาพแวดล้อมเป้าหมายเมื่อทดสอบเทมเพลต

จำนวนบรรทัดเพียงอย่างเดียวไม่บ่งบอกว่าข้อความจะล้นขอบหรือไม่ ความสูงที่มี, ความสูงบรรทัด, ระยะห่างย่อหน้าและบรรทัด, และพฤติกรรม autofit ก็มีผลเช่นกัน; แม้บรรทัดเดียวก็อาจเกินความกว้างที่มีเมื่อปิดการห่อ

## **นำเข้าและส่งออกเนื้อหาย่อหน้า**

ใช้ HTML เพื่อนำข้อความเข้าสู่การนำเสนอหรือส่งออกย่อมาที่มีอยู่เพื่อใช้ภายนอก ส่วนนี้ยังแสดงวิธีเรนเดอร์ย่อหน้าแต่ละอันเป็นภาพ รวมถึงย่อหน้าในเซลล์ตาราง

### **นำเข้า HTML ไปยังย่อหน้า**

ใช้ [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) เพื่อแปลง HTML ให้เป็นย่อหน้าและส่วนย่อยในกรอบข้อความ

ตัวอย่าง C# นี้อ่าน HTML จากไฟล์และส่งต่อ markup ให้กับ [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) มันล้างย่อหน้าเริ่มต้นของกรอบข้อความเพื่อให้กรอบประกอบด้วยเนื้อหาที่นำเข้าเท่านั้น รูปร่างสี่เหลี่ยมจะเว้นระยะขอบ 10 จุดในแต่ละด้านของสไลด์:

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

ใช้ [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) เพื่อส่งออกช่วงย่อหน้าที่เลือกเป็น HTML เมื่อใช้ข้อความงานนำเสนอบนเว็บไซต์ คุณอาจต้องการเก็บการเน้นแบบท้องถิ่นโดยไม่ต้องนำฟอนต์ ขนาด หรือสไตล์กล่องข้อความของงานนำเสนอไปด้วย ตั้งค่า [TextToHtmlConversionOptions.TextInheritanceLimit](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/textinheritancelimit/) เพื่อควบคุมระดับที่ตัวส่งออกสืบทอดรูปแบบ

ดาวน์โหลด [the sample presentation](text-inheritance.pptx) และวางไว้ในไดเรกทอรีทำงานของแอปพลิเคชัน สไลด์แรกมีรูปข้อความหนึ่งรูปที่มีข้อความ “Inherited text; explicit red 18pt” อินพุตใช้หลายระดับการจัดรูปแบบโดยเจตนา:

- สไตล์ข้อความเริ่มต้นของงานนำเสนอใช้ Calibri ขนาด 28 pt
- สไตล์ข้อความระดับแรกของกรอบข้อความใช้ข้อความสีน้ำเงินและเอียง
- ย่อหน้ากำหนดให้ข้อความเป็นหนาอย่างชัดเจน
- ส่วนที่สอง “explicit red 18pt” กำหนดสีแดงและขนาด 18 pt อย่างชัดเจน

ตัวอย่างเต็มต่อไปนี้ส่งออกย่อหน้าเดียวกันสามครั้ง โดยส่งผ่าน [TextToHtmlConversionOptions](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/) ไปยังเมธ็อดส่งออกและเขียนผลลัพธ์แต่ละอันเป็นไฟล์ HTML UTF-8 แยกกัน:

```csharp
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("text-inheritance.pptx");
var textShape = (IAutoShape)presentation.Slides[0].Shapes[0];

var paragraphs = textShape.TextFrame.Paragraphs;
var modes = new[] { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };

foreach (var mode in modes)
{
    var options = new TextToHtmlConversionOptions { TextInheritanceLimit = mode };

    var html = paragraphs.ExportToHtml(0, paragraphs.Count, options);
    File.WriteAllText($"{mode}.html", html, Encoding.UTF8);
}
```

HTML ที่สร้างจะมี CSS ต่อไปนี้สำหรับส่วนแรก “Inherited text; ” ตารางแสดงการประกาศที่เกี่ยวข้อง; คุณสมบัติที่สร้างอื่น ๆ จะถูกละเว้นเพื่อความกระชับ

| ผลลัพธ์ | CSS ที่เกี่ยวข้องสำหรับส่วนแรก | ลักษณะ |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | ข้อความสีน้ำเงิน หนา เอียง ขนาด 28 pt ใน Calibri หากมีฟอนต์นั้น |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | ข้อความสีน้ำเงิน หนา เอียง; หน้า หรือเบราว์เซอร์จะให้ฟอนต์และขนาด |
| `ParagraphOnly.html` | `font-weight:bold` | ข้อความหนา; หน้า หรือเบราว์เซอร์จะให้ฟอนต์ ขนาด สี และสไตล์เอียง |

ส่วนที่สองคง `color:#ff0000`, `font-size:18pt`, และ `font-weight:bold` ในทั้งสามไฟล์ รวมทั้งเอียงใน `All` และ `TextBox` แต่ไม่ใน `ParagraphOnly` การจำกัดการสืบทอดจึงไม่ได้ลบรูปแบบที่กำหนดโดยตรงให้กับย่อหน้าหรือส่วนย่อย

เปิดไฟล์ในเบราว์เซอร์เดียวกันเพื่อเปรียบเทียบ ในโหมดที่จำกัด การละเว้นคุณสมบัติ CSS จะได้รับการแก้โดยสไตล์ของหน้าเป้าหมายหรือค่าเริ่มต้นของเบราว์เซอร์ ดังนั้นลักษณะผลลัพธ์ขึ้นกับที่ใช้ HTML

### **สร้าง HTML Clipboard Fragment**

ตั้งค่า [AddClipboardFragmentHeader](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/addclipboardfragmentheader/) เป็น `false` สำหรับ HTML ธรรมดา หรือ `true` เพื่อรวมส่วนหัวของคลิปบอร์ด ทั้งสองการเรียกคืนสตริง ส่วนหัวจะให้ค่าออฟเซ็ตไบต์ UTF-8 ของ HTML รอบ ๆ (`StartHTML` และ `EndHTML`) และเนื้อหาที่จะวาง (`StartFragment` และ `EndFragment`)

ตัวอย่างนี้ส่งออกสองย่อหน้าที่จัดรูปแบบเป็น HTML ธรรมดา (`html`) และเป็นคลิปบอร์ด HTML fragment (`clipboardHtml`) การเขียน fragment ไปยังคลิปบอร์ดระบบเป็นขั้นตอนแอปพลิเคชันแยกต่างหาก API ของคลิปบอร์ดที่รับไบต์ HTML ดิบต้องเป็น UTF-8 โดยไม่มี BOM

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 400, 100);
var paragraphs = shape.TextFrame.Paragraphs;
paragraphs.Clear();
paragraphs.AddFromHtml("<p>Status: <b>Ready</b></p><p><i>Next steps</i></p>");

var options = new TextToHtmlConversionOptions { AddClipboardFragmentHeader = false };
var html = paragraphs.ExportToHtml(0, paragraphs.Count, options);

options.AddClipboardFragmentHeader = true;
var clipboardHtml = paragraphs.ExportToHtml(0, paragraphs.Count, options);
```

### **เรนเดอร์ย่อหน้าเป็นภาพ**

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) เรนเดอร์ย่อหน้าเดี่ยวโดยตรงและคืนค่า [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) บันทึกผลลัพธ์เป็นไฟล์หรือสตรีมด้วย [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) คุณไม่จำเป็นต้องเรนเดอร์รูปทรงที่บรรจุหรือครอบตัดบิตแมพด้วยตนเอง

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) สามารถคืนค่า `null` หากไม่พบย่อหน้าในคอลเลกชันแม่ ไม่มีขอบเขตการเรนเดอร์ที่ถูกต้อง หรือไม่สามารถเรนเดอร์ได้ ตรวจสอบผลลัพธ์ก่อนบันทึกและทำลายภาพที่คืนค่าหลังใช้งาน

#### **เรนเดอร์ย่อหน้าในสเกลเริ่มต้น**

ตัวอย่างใช้งานนำเสนอที่มีสไลด์หนึ่งสไลด์ที่รูปแรกเป็นกล่องข้อความที่มีย่อหน้า 3 ย่อหน้า

![กล่องข้อความที่มีสามย่อหน้า](paragraph_to_image_input.png)

ตัวอย่างต่อไปนี้เลือกย่อหน้าที่สองที่ตำแหน่งดัชนี 1 และเรียก [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) โดยไม่มีพารามิเตอร์สเกล ตรวจสอบว่ารูปทรงมีย่อหน้าที่ต้องการและการเรนเดอร์คืนภาพก่อนเรียก [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) เพื่อบันทึกเป็น PNG คำสั่ง `using` ทำลายภาพหลังการใช้

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

#### **เรนเดอร์ย่อหน้าในเซลล์ตารางพร้อมสเกล**

ใช้การโอเวอร์โหลดของ [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) ที่รับพารามิเตอร์ `float scaleX` และ `float scaleY` เพื่อกำหนดสเกลแนวนอนและแนวตั้ง ตัวอย่างต่อไปนี้สร้างตารางเรนเดอร์ย่อหน้าในเซลล์แรกโดยขยายความกว้างและความสูงเป็นสองเท่าและบันทึกผลเป็นไฟล์ PNG

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

สเกลค่า `1` ทำให้แกนนั้นคงขนาดพิกเซลเริ่มต้น ตัวอย่าง `2` สำหรับทั้งสองสเกลทำให้ภาพที่ได้มีความกว้างและความสูงประมาณสองเท่าของมิติเริ่มต้น ส่งผลให้มีพิกเซลสี่เท่า ปัจจัยที่ใหญ่กว่าจะให้ข้อความคมชัดขึ้นสำหรับการซูมหรือเอาต์พุตความละเอียดสูง แต่อาจเพิ่มการใช้หน่วยความจำและขนาดไฟล์ ปัจจัยต่ำกว่า `1` จะให้ภาพขนาดเล็กพร้อมรายละเอียดน้อยลง ใช้ค่าที่เท่ากันเพื่อรักษาอัตราส่วนภาพของย่อหน้า; ค่าแนวนอนและแนวตั้งที่ต่างกันจะยืดผลลัพธ์แยกกัน

การเรนเดอร์รูปทรงทั้งหมดด้วย [IShape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/ishape/getimage/) ยังคงมีประโยชน์เมื่อผลลัพธ์ต้องรวมการเติมสี เส้นขอบ หรือบริบทภาพอื่นของรูปทรง สำหรับภาพที่มีแค่ย่อหน้าให้ใช้ [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/)

## **FAQ**

**ฉันสามารถปิดการห่อบรรทัดในกรอบข้อความได้ทั้งหมดหรือไม่?**

ได้ เรียกใช้ [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) เพื่อปิดการห่อบรรทัด so บรรทัดจะไม่ตัดที่ขอบของกรอบข้อความ

**ฉันจะวิธีรับขอบเขตบนสไลด์ของย่อหน้าเฉพาะได้อย่างแม่นยำ?**

ใช้ [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/) เพื่อดึงสี่เหลี่ยมขอบของย่อหน้า [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/getrect/) ให้ขอบของส่วนย่อยแต่ละอัน

**การจัดแนวย่อหน้า (ซ้าย, ขวา, ศูนย์, หรือจัดเต็ม) ถูกควบคุมที่ไหน?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) เป็นการตั้งค่าระดับย่อหน้าและใช้กับย่อหน้าทั้งหมดไม่ว่าการจัดรูปแบบส่วนย่อยจะเป็นอย่างไร

เพื่อจัดแนวส่วนย่อยของฟอนต์ขนาดต่างกันในแต่ละบรรทัด ดู [Align Fonts Within a Line](/slides/th/net/text-formatting/#align-fonts-within-a-line)

**ฉันสามารถตั้งค่าภาษาการตรวจสอบการสะกดสำหรับบางส่วนของย่อหน้าได้หรือไม่?**

ได้ ตั้งค่า [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) สำหรับส่วนย่อยแต่ละอัน เพื่อให้ย่อหน้าหนึ่งสามารถมีข้อความหลายภาษาได้