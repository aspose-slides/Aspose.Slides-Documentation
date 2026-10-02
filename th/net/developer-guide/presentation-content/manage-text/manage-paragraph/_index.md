---
title: จัดการข้อความย่อหน้า PowerPoint ใน .NET
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
- การเยื้องห้อย
- สัญลักษณ์หัวข้อย่อหน้า
- รายการลำดับเลข
- รายการมีสัญลักษณ์หัวข้อ
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
description: "เรียนรู้วิธีสร้างและจัดรูปแบบย่อหน้า, ส่วนย่อย, สัญลักษณ์หัวข้อ, รายการลำดับเลข, การเยื้อง, เนื้อหา HTML, และภาพย่อหน้าด้วย Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

Aspose.Slides for .NET แสดงข้อความเป็นลำดับขั้นของกรอบข้อความ (text frames), ย่อหน้า (paragraphs) และส่วนย่อย (portions):

* [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) แสดงคอนเทนเนอร์ของข้อความในรูปร่างและให้การเข้าถึงคอลเลกชันของย่อหน้า
* [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) แสดงย่อหน้าหนึ่งในกรอบข้อความและให้การเข้าถึงส่วนย่อยและการจัดรูปแบบระดับย่อหน้า
* [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) แสดงรันของข้อความภายในย่อหน้า แต่ละส่วนย่อยสามารถมีข้อความและการจัดรูปแบบระดับอักขระของตนเองได้

ดังนั้น ย่อหน้าจึงสามารถบรรจุข้อความที่มีฟอนต์, สี, ขนาดและการจัดรูปแบบอื่น ๆ ที่แตกต่างกันโดยใช้หลายส่วนย่อย

## **สร้างและจัดรูปแบบย่อหน้า**

### **สร้างย่อหน้าด้วยหลายส่วนย่อย**

ขั้นตอนต่อไปนี้จะสร้างกรอบข้อความที่มีย่อหน้า 3 ย่อหน้า แต่ละย่อหน้ามีส่วนย่อย 3 ส่วน:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)  
2. เข้าถึงสไลด์ที่ต้องการผ่านดัชนีของมัน  
3. เพิ่มรูปทรงสี่เหลี่ยม [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ลงในสไลด์  
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) ของรูปทรง  
5. ใช้ย่อหน้าเริ่มต้นและเพิ่ม [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) อีกสองอันลงในกรอบข้อความ  
6. เพิ่ม [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) ให้เพียงพอสำหรับแต่ละย่อหน้าที่ต้องการสามส่วนย่อย ย่อหน้าเริ่มต้นมีส่วนย่อยเปล่าอยู่แล้วหนึ่งส่วน  
7. ตั้งค่าข้อความของแต่ละส่วนย่อย  
8. ใช้การจัดรูปแบบระดับอักขระผ่าน [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/)  
9. บันทึกงานนำเสนอที่แก้ไขแล้ว  

ตัวอย่าง C# ด้านล่างแสดงการทำตามขั้นตอนเหล่านี้:

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

## **สร้างรายการแบบมีสัญลักษณ์และลำดับเลข**

### **สร้างรายการแบบมีสัญลักษณ์หรือแบบลำดับเลข**

สัญลักษณ์และการจัดลำดับทำให้รายการที่เกี่ยวข้องอ่านง่ายขึ้น ใน Aspose.Slides การตั้งค่ารายการกำหนดผ่าน [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/)  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)  
2. เข้าถึงสไลด์ที่ต้องการผ่านดัชนีของมัน  
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ลงในสไลด์ที่เลือก  
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) ของรูปทรง  
5. ลบย่อหน้าเริ่มต้นออกจากกรอบข้อความ  
6. สร้าง [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) สำหรับสัญลักษณ์สัญลักษณ์ (symbol bullet)  
7. ตั้งค่า [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) เป็น [BulletType.Symbol](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) และระบุอักขระสัญลักษณ์  
8. ตั้งค่าข้อความของย่อหน้า, การเยื้อง, สีของสัญลักษณ์และความสูงของสัญลักษณ์  
9. เพิ่มย่อหน้าลงในกรอบข้อความ  
10. สร้างย่อหน้าที่สองและตั้งค่า [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) เป็น [BulletType.Numbered](https://reference.aspose.com/slides/net/aspose.slides/bullettype/)  
11. กำหนดสไตล์สัญลักษณ์ลำดับเลขและเพิ่มย่อหน้าลงในกรอบข้อความ  
12. บันทึกงานนำเสนอ  

ตัวอย่าง C# ด้านล่างสร้างสัญลักษณ์สัญลักษณ์และสัญลักษณ์ลำดับเลข:

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

### **ใช้สัญลักษณ์เป็นรูปภาพ**

สัญลักษณ์แบบรูปภาพให้คุณใช้รูปภาพกำหนดเองแทนสัญลักษณ์หรือเลข

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)  
2. เข้าถึงสไลด์ที่ต้องการผ่านดัชนีของมัน  
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) แล้วเข้าถึง [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) ของมัน  
4. ลบย่อหน้าเริ่มต้นออกจากกรอบข้อความ  
5. โหลดรูปภาพสัญลักษณ์และเพิ่มลงในคอลเลกชันรูปภาพของงานนำเสนอเป็น [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/)  
6. สร้าง [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) แล้วตั้งค่าข้อความของมัน  
7. ตั้งค่า [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) เป็น [BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/)  
8. กำหนดรูปภาพผ่าน [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/) แล้วตั้งค่าความสูงของสัญลักษณ์  
9. เพิ่มย่อหน้าลงในกรอบข้อความ  
10. บันทึกงานนำเสนอที่แก้ไขแล้ว  

ตัวอย่าง C# ด้านล่างสร้างสัญลักษณ์รูปภาพ:

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

ตั้งค่า [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) เพื่อวางย่อหน้าในระดับต่าง ๆ ของรายการ ระดับบนสุดมีความลึกเป็น `0`

1. สร้าง [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) แล้วเข้าถึงสไลด์หนึ่งสไลด์  
2. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) แล้วลบย่อหน้าเริ่มต้นออกจากกรอบข้อความของมัน  
3. สร้างย่อสี่ย่อหน้าและกำหนดสัญลักษณ์สัญลักษณ์ของแต่ละย่อหน้า  
4. ตั้งค่า [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) ของพวกเขาเป็น `0`, `1`, `2` และ `3`  
5. เพิ่มย่อหน้าเหล่านั้นลงในกรอบข้อความและบันทึกงานนำเสนอ  

ตัวอย่าง C# ด้านล่างสร้างรายการแบบมีสัญลักษณ์สี่ระดับ:

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

ใช้ [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) เพื่อตั้งค่าตัวเลขเริ่มต้นของย่อหน้าที่เป็นลำดับเลข

1. สร้าง [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) แล้วเพิ่ม [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ลงในสไลด์หนึ่ง  
2. ลบย่อหน้าเริ่มต้นออกจากกรอบข้อความของรูปทรง  
3. สร้างย่อหน้าเลขสามย่อหน้า  
4. ตั้งค่า [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) เป็น `2`, `3` และ `7` สำหรับย่อหน้าที่เกี่ยวข้องแต่ละอัน  
5. เพิ่มย่อหน้าเหล่านั้นลงในกรอบข้อความและบันทึกงานนำเสนอ  

ตัวอย่าง C# ด้านล่างกำหนดเลขเริ่มต้นแบบกำหนดเองให้กับแต่ละย่อหน้า:

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

## **ควบคุมการจัดเรียงและคุณสมบัติส่วนท้ายของย่อหน้า**

### **ตั้งค่าการเยื้องบรรทัดแรก**

ใช้คุณสมบัติ [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) เพื่อควบคุมการเยื้องบรรทัดแรกของย่อหน้า คุณสมบัตินี้จะย้ายบรรทัดแรกเท่านั้นเทียบกับขอบซ้ายของย่อหน้า ค่าบวกจะเลื่อนบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือคงอยู่ตรงกับเนื้อย่อหน้า  

ใช้ [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) เมื่อคุณต้องการย้ายย่อหน้าเต็มบรรทัด ใช้ [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) เมื่อต้องการย้ายเฉพาะบรรทัดแรก  

ตัวอย่างต่อไปนี้สร้างย่อหน้าหลายย่อหน้าและกำหนดค่าต่าง ๆ ของ [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) เพื่อแสดงผลว่า การเยื้องบรรทัดแรกส่งผลต่อการจัดเรียงอย่างไร  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)  
2. เข้าถึงสไลด์เป้าหมาย  
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) สี่เหลี่ยมลงในสไลด์  
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) ของรูปทรงและลบย่อหน้าเริ่มต้น  
5. สร้างย่อหน้าต่าง ๆ แล้วกำหนดค่า [Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) ที่แตกต่างกันให้กับแต่ละย่อหน้า  
6. เพิ่มย่อหน้าเหล่านั้นลงในกรอบข้อความ  
7. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ดนี้แสดงวิธีตั้งค่าการเยื้องย่อหน้า:

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

### **ตั้งค่าการเยื้องห้อย**

การเยื้องห้อยเป็นการจัดเรียงย่อหน้าที่บรรทัดแรกเริ่มอยู่ทางซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟกต์นี้ด้วยคุณสมบัติ [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) ตั้งค่า `Indent` ให้เป็นค่าลบเพื่อย้ายบรรทัดแรกไปทางซ้ายเมื่อเทียบกับเนื้อย่อหน้า  

โดยทั่วไป [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) กำหนดตำแหน่งซ้ายของเนื้อย่อหน้า และ [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) กำหนดตำแหน่งของบรรทัดแรกสัมพันธ์กับขอบซ้ายนั้น เพื่อสร้างการเยืณ์ห้อยให้ตั้งค่า `MarginLeft` เป็นค่าบวกและ `Indent` เป็นค่าลบ  

การจัดรูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม, การอ้างอิง, บทสารานุกรม และย่อหน้าอื่น ๆ ที่ต้องการให้บรรทัดที่ต่อเนื่องอยู่ใต้เนื้อย่อหน้าแทนใต้ตัวอักษรแรกของบรรทัดแรก  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)  
2. เข้าถึงสไลด์เป้าหมาย  
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) สี่เหลี่ยมลงในสไลด์  
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) ของรูปทรงและลบย่อหน้าเริ่มต้น  
5. สร้างย่อหน้าและตั้งค่า [MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) เป็นค่าบวกสำหรับแต่ละย่อหน้า  
6. ตั้งค่า [Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) เป็นค่าลบเพื่อสร้างเอฟเฟกต์เยื้องห้อย  
7. เพิ่มย่อหน้าเหล่านั้นลงในกรอบข้อความ  
8. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ดนี้แสดงวิธีตั้งค่าการเยื้องห้อยสำหรับย่อหน้า:

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

![การเยื้องห้อยของย่อหน้า](hanging_indent.png)

### **ตั้งค่าคุณสมบัติส่วนท้ายของย่อหน้า**

คุณสมบัติ [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) ควบคุมการจัดรูปแบบของสัญลับจบย่อหน้า ตัวอย่างต่อไปนี้กำหนดขนาดฟอนต์และฟอนต์ละตินให้กับสัญลับจบของย่อหน้าที่สอง:

1. โหลด [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) และเข้าถึงสไลด์หนึ่ง  
2. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) แล้วลบย่อหน้าเริ่มต้นของมัน  
3. สร้างสองย่อหน้าและเพิ่มส่วนข้อความลงในแต่ละย่อหน้า  
4. สร้าง [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) สำหรับสัญลับจบของย่อหน้าที่สอง  
5. ตั้งค่า [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) และ [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/latinfont/)  
6. กำหนดฟอร์แมตให้กับ [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) แล้วบันทึกงานนำเสนอ  

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

สำหรับกฎของย่อหน้าที่มีผลต่อการตัดบรรทัดอัตโนมัติและเครื่องหมายวรรคตอนที่ปลายบรรทัด ดูที่ [Control Line Breaking](/slides/th/net/text-formatting/#control-line-breaking) และ [Control Hanging Punctuation](/slides/th/net/text-formatting/#control-hanging-punctuation)

ใช้ [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) เพื่อให้นับจำนวนบรรทัดที่ย่อหน้าใช้หลังจากการจัดรูปแบบข้อความ รวมถึงการตัดบรรทัดอัตโนมัติ ซึ่งมีประโยชน์เมื่อตรวจสอบความยาวและการจัดรูปแบบของข้อความในเทมเพลตงานนำเสนอ  

ย่อหน้าเป็นรายการหนึ่งใน [ITextFrame.Paragraphs](https://reference.aspose.com/slides/net/aspose.slides/itextframe/paragraphs/) และอาจครอบคลุมหลายบรรทัดที่แสดงผล การขึ้นบรรทัดใหม่แบบชัดเจนภายในย่อหน้าจะบังคับให้ขึ้นบรรทัดใหม่โดยไม่สร้างย่อหน้าใหม่ การตัดบรรทัดอัตโนมัติจะสร้างบรรทัดตามความกว้างที่มีอยู่โดยไม่แทรกอักขระขึ้นบรรทัดใหม่ลงในข้อความ ดังนั้นการนับย่อหน้าหรืออักขระขึ้นบรรทัดใหม่โดยตรงจะไม่ให้จำนวนบรรทัดที่แสดงผลที่แท้จริง  

ตัวอย่างต่อไปนี้สร้างรูปทรงข้อความ, นับบรรทัด, ลดความกว้างของรูปทรง, แล้วแทนที่ข้อความด้วยสตริงที่สั้นลง การตัดบรรทัดเปิดใช้งานและการปรับขนาดอัตโนมัติปิดเพื่อให้ความกว้างของรูปทรงเป็นตัวควบคุมการตัดบรรทัดโดยไม่ย่อข้อความหรือปรับขนาดรูปทรงเอง มิติของรูปทรงเป็นหน่วยพอยท์ สุดท้ายตัวอย่างเพิ่มย่อหน้าอีกหนึ่งย่อหน้าและรวมจำนวนบรรทัดทั้งหมดในกรอบข้อความ

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

ด้วยข้อความและมิตินี้ การลดความกว้างของรูปทรงจะเพิ่มจำนวนบรรทัด ในขณะที่การแทนที่ข้อความด้วยสตริงสั้นจะลดจำนวนบรรทัด จำนวนที่แน่นอนอาจแตกต่างกันตามการมีฟอนต์และการทดแทน, ขนาดฟอนต์, ระยะขอบ, การเยื้อง, การตัดบรรทัดและการตั้งค่าการปรับขนาดอัตโนมัติ ใช้ฟอนต์และการตั้งค่าการจัดรูปแบบที่ตั้งใจสำหรับสภาพแวดล้อมเป้าหมายเมื่อตรวจสอบเทมเพลต  

จำนวนบรรทัดเพียงอย่างเดียวไม่สามารถบ่งบอกได้ว่าข้อความล้นจากคอนเทนเนอร์หรือไม่ ความสูงที่มี, ความสูงของบรรทัด, ระยะห่างระหว่างย่อหน้าและบรรทัด, และพฤติกรรมการปรับขนาดอัตโนมัติก็มีผลเช่นกัน; แม้แต่บรรทัดเดียวอาจเกินความกว้างที่มีได้เมื่อปิดการตัดบรรทัด

## **นำเข้าและส่งออกเนื้อหาย่อหน้า**

### **นำเข้า HTML เข้าในย่อหน้า**

ใช้ [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) เพื่อแปลงมาร์กอัป HTML ให้เป็นย่อหน้าและส่วนย่อยในกรอบข้อความ  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)  
2. เข้าถึงสไลด์และเพิ่ม [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)  
3. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) ของรูปทรงและลบย่อหน้าเริ่มต้น  
4. อ่านไฟล์ HTML ต้นฉบับ  
5. ส่งสตริง HTML ให้กับ [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/)  
6. บันทึกงานนำเสนอที่แก้ไขแล้ว  

ตัวอย่าง C# ด้านล่างนำเข้า HTML ลงในกรอบข้อความ:

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

ใช้ [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) เพื่อส่งออกช่วงย่อหน้าที่เลือกเป็น HTML  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) และโหลดงานนำเสนอที่ต้องการ  
2. เข้าถึงสไลด์และค้นหา [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ที่มีข้อความอยู่  
3. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) ของรูปทรงนั้น  
4. เรียก [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) พร้อมกับดัชนีย่อหน้าเริ่มต้นและจำนวนย่อหน้าที่ต้องการส่งออก  
5. เขียนสตริง HTML ที่คืนค่ามาไปยังไฟล์  

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

### **แสดงย่อหน้าเป็นภาพ**

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) ทำการเรนเดอร์ย่อหน้าเดี่ยวโดยตรงและคืนค่าเป็น [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) บันทึกผลลัพธ์เป็นไฟล์หรือสตรีมด้วย [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) คุณไม่จำเป็นต้องเรนเดอร์รูปทรงทั้งหมดหรือครอปบิทแมพด้วยตนเอง  

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) อาจคืนค่า `null` หากย่อหน้าไม่พบในคอลเลกชันแม่, ไม่มีขอบเขตการเรนเดอร์ที่ถูกต้อง, หรือไม่สามารถเรนเดอร์ได้ ตรวจสอบผลลัพธ์ก่อนบันทึกและทำลายภาพที่คืนค่าหลังการใช้  

#### **เรนเดอร์ย่อหน้าที่ระดับสเกลค่าเริ่มต้น**

สมมติว่ามีไฟล์งานนำเสนอชื่อ `sample.pptx` ที่มีสไลด์เดียว ซึ่งรูปทรงแรกคือกล่องข้อความที่มีย่อหน้า 3 ย่อหน้า  

![กล่องข้อความที่มีสามย่อหน้า](paragraph_to_image_input.png)

ตัวอย่างต่อไปนี้เรนเดอร์ย่อหน้าที่สองในรูปทรงข้อความทั่วไปที่ระดับสเกลค่าเริ่มต้นและบันทึกภาพที่ได้เป็นรูปแบบ PNG คำสั่ง `using` ทำให้แน่ใจว่าภาพถูกทำลายอย่างถูกต้อง  

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

ใช้ overload ของ [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) ที่รับพารามิเตอร์ `float scaleX` และ `float scaleY` เพื่อกำหนดตัวคูณสเกลแนวนอนและแนวตั้ง ตัวอย่างต่อไปนี้สร้างตาราง, เรนเดอร์ย่อหน้าในเซลล์แรกที่กว้างและสูงเป็นสองเท่าของค่าเริ่มต้น, แล้วบันทึกผลเป็นภาพ PNG  

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

ค่าคูณสเกล `1` ทำให้แกนนั้นคงขนาดพิกเซลเริ่มต้น ตัวอย่างเช่น `2` สำหรับทั้งสองแกนจะทำให้ความกว้างและความสูงของภาพประมาณสองเท่าของขนาดเริ่มต้น ส่งผลให้มีพิกเซลมากขึ้นสี่เท่า ตัวคูณที่ใหญ่กว่ามักทำให้ข้อความคมชัดขึ้นสำหรับการซูมหรือเอาต์พุตความละเอียดสูง แต่ก็เพิ่มการใช้หน่วยความจำและขนาดไฟล์ ตัวคูณต่ำกว่า `1` จะทำให้ภาพเล็กลงและรายละเอียดน้อยลง ใช้ตัวคูณเท่ากันเพื่อคงอัตราส่วนของย่อหน้า; ตัวคูณแนวนอนและแนวตั้งที่ต่างกันจะยืดภาพออกตามอิสระ  

การเรนเดอร์รูปทรงทั้งหมดด้วย [IShape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/ishape/getimage/) ยังมีประโยชน์เมื่อเอาต์พุตต้องรวมการเติมสี, เส้นขอบ หรือบริบทภาพอื่น ๆ ของรูปทรง สำหรับภาพที่มีแค่ย่อหน้าเท่านั้นให้ใช้ [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/)

## **คำถามที่พบบ่อย**

**ฉันสามารถปิดการตัดบรรทัดอัตโนมัติในกรอบข้อความได้หรือไม่?**

ได้เลย ตั้งค่า [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) เพื่อปิดการตัดบรรทัด ทำให้บรรทัดไม่แตกที่ขอบของกรอบข้อความ

**ฉันจะได้ขอบเขตบนสไลด์ที่แม่นยำของย่อหน้าใดย่อหน้าหนึ่งอย่างไร?**

ใช้ [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/) เพื่อดึงสี่เหลี่ยมขอบของย่อหน้า [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/getrect/) จะให้ขอบเขตของส่วนย่อยแต่ละส่วน

**การจัดแนวของย่อหน้า (ซ้าย, ขวา, กลาง หรือ ชิดขอบ) ถูกควบคุมที่ไหน?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) เป็นการตั้งค่าระดับย่อหน้าและใช้กับย่อหน้าทั้งหมดโดยไม่คำนึงถึงการจัดรูปแบบของส่วนย่อยแต่ละส่วน  

หากต้องการจัดแนวฟอนต์ที่มีขนาดต่างกันภายในแต่ละบรรทัด ดูที่ [Align Fonts Within a Line](/slides/th/net/text-formatting/#align-fonts-within-a-line)

**ฉันสามารถตั้งค่าภาษา proofing สำหรับส่วนหนึ่งของย่อหน้าได้หรือไม่?**

ได้ ตั้งค่า [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) สำหรับส่วนย่อยแต่ละส่วน เพื่อให้ย่อหน้าหนึ่งสามารถมีข้อความหลายภาษาได้.