---
title: จัดรูปแบบรูปร่าง PowerPoint ใน .NET
linktitle: การจัดรูปแบบรูปร่าง
type: docs
weight: 20
url: /th/net/shape-formatting/
keywords:
- จัดรูปแบบรูปร่าง
- จัดรูปแบบเส้น
- เอฟเฟกต์สเก็ตช์
- เส้นรูปร่างสเก็ตช์
- จัดรูปแบบสไตล์การเชื่อมต่อ
- การเติมไล่สี
- การเติมลวดลาย
- การเติมภาพ
- การเติมเทกซ์เจอร์
- การเติมสีทึบ
- ความโปร่งแสงของรูปร่าง
- การแสดงผลรูปร่างขาว-ดำ
- การแสดงผลรูปร่างในโทนสีเทา
- หมุนรูปร่าง
- เอฟเฟกต์บีเวล 3 มิติ
- เอฟเฟกต์การหมุน 3 มิติ
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีจัดรูปแบบรูปร่าง PowerPoint ด้วย C# โดยใช้ Aspose.Slides—กำหนดการเติม, เส้นและสไตล์เอฟเฟกต์สำหรับไฟล์ PPT และ PPTX อย่างแม่นยำและควบคุมเต็มที่"
---
## **บทนำ**

ใน PowerPoint คุณสามารถเพิ่มรูปร่างลงในสไลด์ได้ เนื่องจากรูปร่างประกอบด้วยเส้น คุณจึงสามารถจัดรูปแบบโดยการแก้ไขหรือใช้เอฟเฟกต์กับเส้นขอบของมัน นอกจากนี้ คุณยังสามารถจัดรูปแบบรูปร่างโดยระบุการตั้งค่าที่ควบคุมการเติมสีภายในของรูปร่างได้

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for .NET ให้ส่วนติดต่อและคุณสมบัติที่ช่วยให้คุณจัดรูปแบบรูปร่างโดยใช้ตัวเลือกเดียวกับที่มีใน PowerPoint

## **จัดรูปแบบเส้น**

โดยใช้ Aspose.Slides คุณสามารถระบุสไตล์เส้นแบบกำหนดเองสำหรับรูปร่าง ขั้นตอนต่อไปนี้อธิบายกระบวนการ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ไปยังสไลด์
1. ตั้งค่า [line style](https://reference.aspose.com/slides/net/aspose.slides/linestyle/) ของรูปร่าง
1. ตั้งค่าความกว้างของเส้น
1. ตั้งค่า [dash style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) ของเส้น
1. ตั้งค่าสีของเส้นสำหรับรูปร่าง
1. บันทึกพรเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

โค้ด C# ต่อไปนี้แสดงวิธีจัดรูปแบบ `AutoShape` รูปสี่เหลี่ยม:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน
using (Presentation presentation = new Presentation())
{
    // รับสไลด์แรก
    ISlide slide = presentation.Slides[0];

    // เพิ่มรูปร่างอัตโนมัติประเภทสี่เหลี่ยม
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ตั้งค่าสีเติมสำหรับรูปร่างสี่เหลี่ยม
    shape.FillFormat.FillType = FillType.NoFill;

    // ใช้การจัดรูปแบบกับเส้นของสี่เหลี่ยม
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // ตั้งค่าสีสำหรับเส้นของสี่เหลี่ยม
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // บันทึกไฟล์ PPTX ลงดิสก์
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![เส้นที่จัดรูปแบบในพรีเซนเทชัน](formatted-lines.png)

## **ใช้เอฟเฟกต์สเก็ตช์กับเส้นของรูปร่าง**

เอฟเฟกต์สเก็ตช์ทำให้เส้นของรูปร่างดูเหมือนถูกวาดด้วยมือ ใช้ [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) เพื่อเข้าถึงการตั้งค่าเส้น, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) เพื่อเข้าถึงการตั้งค่าสเก็ตช์, และ [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) เพื่อเลือกค่าจาก enumeration [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/)

โค้ด C# ต่อไปนี้แสดงวิธีใช้เอฟเฟกต์ [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) อ่านค่าที่กำหนดโดยเฉพาะ และลบเอฟเฟกต์ด้วย [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
var sketchFormat = shape.LineFormat.SketchFormat;

// Apply a sketch effect.
sketchFormat.SketchType = LineSketchType.Curved;

// Read the sketch effect assigned directly to the shape.
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");

// Remove the sketch effect.
sketchFormat.SketchType = LineSketchType.None;
```

ค่าที่ `ISketchFormat.SketchType` คืนมาจะเป็นการตั้งค่าที่กำหนดโดยตรงให้กับรูปร่าง หากการจัดรูปแบบเส้นสามารถสืบทอดจากธีม, มาสเตอร์สไลด์ หรือเลเอาต์สไลด์ให้ใช้ [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/), เข้าถึง [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/), และอ่าน [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/). ค่าที่มีประสิทธิภาพจะแสดงการจัดรูปแบบที่ใช้จริงหลังจากการสืบทอดได้รับการแก้ไข:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var shape = presentation.Slides[0].Shapes[0];
var lineFormat = shape.LineFormat;

var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **จัดรูปแบบสไตล์การเชื่อมต่อ**

นี่คือสามตัวเลือกประเภทการเชื่อมต่อ:

* Round
* Miter
* Bevel

โดยค่าเริ่มต้น PowerPoint จะเชื่อมต่อสองเส้นที่มุม (เช่นที่มุมของรูปร่าง) โดยใช้การตั้งค่า **Round** อย่างไรก็ตาม หากคุณกำลังวาดรูปร่างที่มีมุมคม คุณอาจต้องการเลือกตัวเลือก **Miter**

![สไตล์การเชื่อมต่อในพรีเซนเทชัน](join-style-powerpoint.png)

โค้ด C# ต่อไปนี้แสดงว่ารูปสี่เหลี่ยมสามรูป (ตามที่แสดงในภาพด้านบน) ถูกสร้างด้วยการตั้งค่า Miter, Bevel, และ Round:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน
using (Presentation presentation = new Presentation())
{
    // รับสไลด์แรก
    ISlide slide = presentation.Slides[0];

    // เพิ่มรูปร่างอัตโนมัติสามอันประเภทสี่เหลี่ยม
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // ตั้งค่าสีเติมสำหรับแต่ละรูปร่างสี่เหลี่ยม
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // ตั้งค่าความกว้างของเส้น
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // ตั้งค่าสีสำหรับเส้นของแต่ละสี่เหลี่ยม
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // ตั้งค่าสไตล์การเชื่อมต่อ
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // เพิ่มข้อความลงในแต่ละสี่เหลี่ยม
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // บันทึกไฟล์ PPTX ลงดิสก์
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **การเติมไล่สี**

ใน PowerPoint การเติมไล่สีเป็นตัวเลือกการจัดรูปแบบที่ทำให้คุณสามารถใช้การผสมสีอย่างต่อเนื่องกับรูปร่างได้ ตัวอย่างเช่น คุณสามารถใช้สองสีหรือมากกว่าที่สีหนึ่งค่อยๆ จางลงสู่สีอื่น

วิธีใช้การเติมไล่สีกับรูปร่างโดยใช้ Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ไปยังสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) ของรูปร่างเป็น `Gradient`
1. เพิ่มสีสองสีที่คุณต้องการพร้อมตำแหน่งที่กำหนดโดยใช้เมธอด `Add` ของคอลเลกชัน gradient stop ที่เปิดให้เข้าถึงโดยอินเทอร์เฟซ [IGradientFormat](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/)
1. บันทึกพรเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

โค้ด C# ต่อไปนี้แสดงวิธีใช้เอฟเฟกต์การเติมไล่สีกับวงรี:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน
using (Presentation presentation = new Presentation())
{
    // รับสไลด์แรก
    ISlide slide = presentation.Slides[0];

    // เพิ่มรูปร่างอัตโนมัติประเภท Ellipse
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // ใช้การจัดรูปแบบไล่สีกับวงรี
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // ตั้งทิศทางของไล่สี
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // เพิ่มจุดหยุดไล่สีสองจุด
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // บันทึกไฟล์ PPTX ลงดิสก์
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![รูปวงรีที่มีการเติมแบบไล่สี](gradient-fill.png)

หากการไล่สีดูแตกต่างในภาพที่ส่งออกเมื่อเทียบกับ PowerPoint ให้ดูที่ [Choose a Gradient Rendering Style](/slides/th/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) คุณสามารถเลือกสไตล์การเรนเดอร์โดยไม่ต้องเปลี่ยนการเติมไล่สีที่เก็บไว้ในพรเซนเทชัน

## **การเติมลวดลาย**

ใน PowerPoint การเติมลวดลายเป็นตัวเลือกการจัดรูปแบบที่ให้คุณใช้การออกแบบสองสี—เช่นจุด, ลายเส้น, ขีดครอส หรือเช็ค—กับรูปร่าง คุณสามารถเลือกสีกำหนดเองสำหรับพื้นหน้าและพื้นหลังของลวดลายได้

Aspose.Slides มีรูปแบบลวดลายที่กำหนดล่วงหน้ากว่า 45 แบบที่คุณสามารถใช้กับรูปร่างเพื่อทำให้การนำเสนอของคุณดูสวยงามยิ่งขึ้น แม้คุณจะเลือกลวดลายที่กำหนดล่วงหน้าแล้ว คุณยังสามารถระบุสีที่ต้องการให้ลวดลายใช้ได้

วิธีใช้การเติมลวดลายกับรูปร่างโดยใช้ Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ไปยังสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) ของรูปร่างเป็น `Pattern`
1. เลือกรูปแบบลวดลายจากตัวเลือกที่กำหนดล่วงหน้า
1. ตั้งค่า [Background Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) ของลวดลาย
1. ตั้งค่า [Foreground Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) ของลวดลาย
1. บันทึกพรเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

โค้ด C# ต่อไปนี้แสดงวิธีใช้การเติมลวดลายกับสี่เหลี่ยม:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน
using (Presentation presentation = new Presentation())
{
    // รับสไลด์แรก
    ISlide slide = presentation.Slides[0];

    // เพิ่มรูปร่างอัตโนมัติประเภทสี่เหลี่ยม
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ตั้งค่าชนิดการเติมเป็น Pattern
    shape.FillFormat.FillType = FillType.Pattern;

    // ตั้งค่าสไตล์ลวดลาย
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // ตั้งค่าสีพื้นหลังและสีพื้นหน้า ของลวดลาย
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // บันทึกไฟล์ PPTX ลงดิสก์
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![สี่เหลี่ยมที่มีการเติมลวดลาย](pattern-fill.png)

## **การเติมภาพ**

ใน PowerPoint การเติมภาพเป็นตัวเลือกการจัดรูปแบบที่ให้คุณแทรกรูปภาพเข้าไปในรูปร่าง—โดยใช้รูปภาพเป็นพื้นหลังของรูปร่าง

วิธีใช้ Aspose.Slides เพื่อเติมภาพในรูปร่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ไปยังสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) ของรูปร่างเป็น `Picture`
1. ตั้งค่าโหมดการเติมภาพเป็น `Tile` (หรือโหมดอื่นที่ต้องการ)
1. สร้างอ็อบเจกต์ [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) จากรูปภาพที่ต้องการใช้
1. กำหนดรูปภาพนี้ให้กับคุณสมบัติ `Picture.Image` ของ `PictureFillFormat` ของรูปร่าง
1. บันทึกพรเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

สมมติว่าเรามีไฟล์ "lotus.png" พร้อมรูปภาพต่อไปนี้:

![รูปภาพบัว](lotus.png)

โค้ด C# ต่อไปนี้แสดงวิธีเติมรูปร่างด้วยภาพ:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน
using (Presentation presentation = new Presentation())
{
    // รับสไลด์แรก
    ISlide slide = presentation.Slides[0];

    // เพิ่มรูปร่างอัตโนมัติประเภทสี่เหลี่ยม
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // ตั้งค่าชนิดการเติมเป็น Picture
    shape.FillFormat.FillType = FillType.Picture;

    // ตั้งค่าโหมดการเติมภาพ
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // โหลดภาพและเพิ่มลงในทรัพยากรของพรีเซนเทชัน
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // ตั้งค่าภาพ
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // บันทึกไฟล์ PPTX ลงดิสก์
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![รูปร่างที่เติมด้วยภาพ](picture-fill.png)

### **ปูกระเบื้องภาพเป็นพื้นผิว**

หากต้องการตั้งค่าภาพเป็นเทกซ์เจอร์แบบปูกระเบื้องและปรับพฤติกรรมการปูกระเบื้อง คุณสามารถใช้คุณสมบัติดังต่อไปนี้ของอินเทอร์เฟซ [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) และคลาส [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): ตั้งค่าโหมดการเติมภาพ—`Tile` หรือ `Stretch`
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): ระบุการจัดตำแหน่งของกระเบื้องภายในรูปร่าง
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): ควบคุมว่ากระเบื้องจะพลิกแนวนอน แนวตั้ง หรือทั้งสองแบบ
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): ตั้งค่าการเลื่อนแนวนอนของกระเบื้อง (จุด) จากจุดกำเนิดของรูปร่าง
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): ตั้งค่าการเลื่อนแนวตั้งของกระเบื้อง (จุด) จากจุดกำเนิดของรูปร่าง
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): กำหนดสเกลแนวนอนของกระเบื้องเป็นเปอร์เซ็นต์
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): กำหนดสเกลแนวตั้งของกระเบื้องเป็นเปอร์เซ็นต์

โค้ดตัวอย่างต่อไปนี้แสดงวิธีเพิ่มรูปร่างสี่เหลี่ยมที่มีการเติมภาพแบบปูกระเบื้องและกำหนดตัวเลือกกระเบื้อง:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน.
using (Presentation presentation = new Presentation())
{
    // รับสไลด์แรก.
    ISlide firstSlide = presentation.Slides[0];

    // เพิ่มรูปร่างอัตโนมัติสี่เหลี่ยม.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // ตั้งค่าชนิดการเติมของรูปร่างเป็น Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // โหลดภาพและเพิ่มลงในทรัพยากรของพรีเซนเทชัน.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // กำหนดภาพให้กับรูปร่าง.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // กำหนดค่าโหมดการเติมภาพและคุณสมบัติการปูกระเบื้อง.
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![ตัวเลือกการปูกระเบื้อง](tile-options.png)

## **การเติมสีทึบ**

ใน PowerPoint การเติมสีทึบเป็นตัวเลือกการจัดรูปแบบที่ทำให้รูปร่างเติมด้วยสีเดียวที่สม่ำเสมอ สีพื้นหลังทั่วไปนี้จะถูกใช้โดยไม่มีการไล่สี, เทกซ์เจอร์หรือรูปแบบลวดลายใดๆ

วิธีเติมสีทึบให้กับรูปร่างโดยใช้ Aspose.Slides ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ไปยังสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) ของรูปร่างเป็น `Solid`
1. กำหนดสีเติมที่คุณต้องการให้กับรูปร่าง
1. บันทึกพรเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

โค้ด C# ต่อไปนี้แสดงวิธีเติมสีทึบให้กับสี่เหลี่ยมในสไลด์ PowerPoint:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน.
using (Presentation presentation = new Presentation())
{
    // รับสไลด์แรก.
    ISlide slide = presentation.Slides[0];

    // เพิ่มรูปร่างอัตโนมัติประเภทสี่เหลี่ยม.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ตั้งค่าชนิดการเติมเป็น Solid.
    shape.FillFormat.FillType = FillType.Solid;

    // ตั้งค่าสีเติม.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![รูปร่างที่เติมสีทึบ](solid-color-fill.png)

## **ตั้งค่าการโปร่งแสง**

ใน PowerPoint เมื่อคุณเติมสีทึบ, ไล่สี, ภาพ หรือเทกซ์เจอร์ให้กับรูปร่าง คุณยังสามารถตั้งค่าระดับการโปร่งแสงเพื่อควบคุมความทึบของสีเติมได้ ค่าการโปร่งแสงที่สูงจะทำให้รูปร่างดูโปร่งแสงมากขึ้น ทำให้พื้นหลังหรือวัตถุที่อยู่ด้านล่างมองเห็นได้บางส่วน

Aspose.Slides ให้คุณตั้งค่าการโปร่งแสงโดยปรับค่าอัลฟ่าในสีที่ใช้สำหรับการเติม วิธีทำดังต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ไปยังสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) เป็น `Solid`
1. ใช้ `Color.FromArgb(alpha, baseColor)` เพื่อกำหนดสีที่มีการตั้งค่าการโปร่งแสง (ส่วน `alpha` ควบคุมระดับการโปร่งแสง)
1. บันทึกพรเซนเทชัน

โค้ด C# ต่อไปนี้แสดงวิธีเติมสีโปร่งแสงให้กับสี่เหลี่ยม:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน.
using (Presentation presentation = new Presentation())
{
    // รับสไลด์แรก.
    ISlide slide = presentation.Slides[0];

    // เพิ่มรูปร่างอัตโนมัติสี่เหลี่ยมแบบทึบ.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // เพิ่มรูปร่างอัตโนมัติสี่เหลี่ยมโปร่งแสงเหนือรูปร่างทึบ.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![รูปร่างโปร่งแสง](shape-transparency.png)

## **หมุนรูปร่าง**

Aspose.Slides ให้คุณหมุนรูปร่างในพรีเซนเทชัน PowerPoint ซึ่งเป็นประโยชน์เมื่อกำหนดตำแหน่งองค์ประกอบภาพโดยต้องการการจัดแนวหรือการออกแบบเฉพาะ

ขั้นตอนการหมุนรูปร่างบนสไลด์:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ไปยังสไลด์
1. ตั้งค่า `Rotation` ของรูปร่างเป็นมุมที่ต้องการ
1. บันทึกพรเซนเทชัน

โค้ด C# ต่อไปนี้แสดงวิธีหมุนรูปร่าง 5 องศา:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน.
using (Presentation presentation = new Presentation())
{
    // รับสไลด์แรก.
    ISlide slide = presentation.Slides[0];

    // เพิ่มรูปร่างอัตโนมัติประเภทสี่เหลี่ยม.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // หมุนรูปร่าง 5 องศา.
    shape.Rotation = 5;

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![การหมุนรูปร่าง](shape-rotation.png)

## **เพิ่มเอฟเฟกต์บีเวล 3 มิติ**

Aspose.Slides อนุญาตให้คุณใช้เอฟเฟกต์บีเวล 3 มิติกับรูปร่างโดยการกำหนดคุณสมบัติของ [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/)

ขั้นตอนการเพิ่มเอฟเฟกต์บีเวล 3 มิติให้กับรูปร่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ไปยังสไลด์
1. กำหนดค่า [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) ของรูปร่างเพื่อกำหนดการตั้งค่าบีเวล
1. บันทึกพรเซนเทชัน

โค้ด C# ต่อไปนี้แสดงวิธีใช้เอฟเฟกต์บีเวล 3 มิติกับรูปร่าง:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // เพิ่มรูปร่างลงในสไลด์.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;

    // ตั้งค่าคุณสมบัติ ThreeDFormat ของรูปร่าง.
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

    // บันทึกพรีเซนเทชันเป็นไฟล์ PPTX.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![เอฟเฟ็กต์บีเวล 3 มิติ](3D-bevel-effect.png)

## **เพิ่มเอฟเฟกต์การหมุน 3 มิติ**

Aspose.Slides อนุญาตให้คุณใช้เอฟเฟกต์การหมุน 3 มิติกับรูปร่างโดยการกำหนดคุณสมบัติของ [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/)

ขั้นตอนการใช้การหมุน 3 มิติกับรูปร่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ไปยังสไลด์
1. ตั้งค่า [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) และ [LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/) ของรูปร่างเพื่อกำหนดการหมุน 3 มิติ
1. บันทึกพรเซนเทชัน

โค้ด C# ต่อไปนี้แสดงวิธีใช้เอฟเฟกต์การหมุน 3 มิติกับรูปร่าง:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // บันทึกพรีเซนเทชันเป็นไฟล์ PPTX.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![เอฟเฟ็กต์การหมุน 3 มิติ](3D-rotation-effect.png)

## **ควบคุมการแสดงผลขาว-ดำสำหรับรูปร่าง**

คุณสมบัติ [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) ระบุว่ารูปร่างแต่ละอันจะแสดงผลอย่างไรเมื่อพรีเซนเทชันถูกดูหรือประมวลผลในโหมดขาว-ดำ มันไม่ได้เปิดใช้งานการแสดงผลขาว-ดำโดยอัตโนมัติและไม่ได้เปลี่ยนการเติมสี, เส้น หรือการจัดรูปแบบอื่นในโหมดสีปกติ

ใช้ค่าจาก enumeration [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) เพื่อเลือกพฤติกรรมที่ต้องการ ตัวอย่างเช่น `Automatic` ให้แอปพลิเคชันเรนเดอร์เลือกการแปลง, `Gray` และ `LightGray` ใช้สีเทา, `BlackWhite` ใช้เฉพาะสีดำและขาว, `Black` และ `White` บังคับเป็นสีเดียว, `Color` คงสีปกติ, `Hidden` ไม่แสดงรูปร่างในโหมดขาว-ดำ, `NotDefined` หมายถึงไม่มีการกำหนดโหมดระดับรูปร่าง

โค้ด C# ต่อไปนี้สร้างรูปร่างสีและทำให้แสดงเป็นสีเทาในโหมดแสดงผลขาว-ดำ:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// Keep the orange fill in color mode, but render the shape with gray coloring in black-and-white mode.
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

ในโหมดสีปกติ สี่เหลี่ยมคงสีเติมส้มไว้ ส่วนในเวิร์กโฟลว์แสดงผลขาว-ดำ จะใช้สีเทาเนื่องจากโหมดตั้งเป็น `Gray` ซึ่งช่วยให้คุณรักษาสไลด์สีเต็มในขณะกำหนดลักษณะการแสดงผลสำหรับการพิมพ์, การพรีวิว หรือเวิร์กโฟลว์อื่นที่เคารพการตั้งค่าการแสดงผลขาว-ดำของพรีเซนเทชัน

## **รีเซ็ตการจัดรูปแบบ**

โค้ด C# ต่อไปนี้แสดงวิธีรีเซ็ตการจัดรูปแบบของสไลด์และคืนตำแหน่ง, ขนาด, และการจัดรูปแบบของรูปร่างทั้งหมดที่มี placeholders บน [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) ไปยังการตั้งค่าเริ่มต้น:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // รีเซ็ตแต่ละรูปร่างบนสไลด์ที่มี placeholder บนเลเอาต์.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**การจัดรูปแบบรูปร่างส่งผลต่อขนาดไฟล์พรีเซนเทชันสุดท้ายหรือไม่?**

ผลกระทบมีเพียงเล็กน้อย ภาพและสื่อที่ฝังอยู่เป็นส่วนใหญ่ของขนาดไฟล์ ส่วนพารามิเตอร์ของรูปร่าง เช่น สี, เอฟเฟกต์, และการไล่สีถูกเก็บเป็นเมตาดาต้าและไม่เพิ่มขนาดอย่างมีนัยสำคัญ

**ฉันจะตรวจจับรูปร่างบนสไลด์ที่มีการจัดรูปแบบเหมือนกันเพื่อที่จะจัดกลุ่มได้อย่างไร?**

เปรียบเทียบคุณสมบัติการจัดรูปแบบหลักของแต่ละรูปร่าง—การเติม, เส้น, และการตั้งค่าเอฟเฟกต์ หากค่าทั้งหมดตรงกันให้ถือว่าสไตล์เหมือนกันและจัดกลุ่มรูปร่างเหล่านั้นแบบตรรกะ ซึ่งจะทำให้การจัดการสไตล์ในภายหลังง่ายขึ้น

**ฉันสามารถบันทึกชุดสไตล์รูปร่างแบบกำหนดเองเป็นไฟล์แยกเพื่อใช้ซ้ำในพรีเซนเทชันอื่นได้หรือไม่?**

ได้ คุณสามารถเก็บรูปร่างตัวอย่างที่มีสไตล์ที่ต้องการในสไลด์เทมเพลตหรือไฟล์เทมเพลต .POTX เมื่อต้องการสร้างพรีเซนเทชันใหม่ เปิดเทมเพลต, คัดลอกรูปร่างที่สไตล์ต้องการและนำการจัดรูปแบบของมันไปใช้ใหม่ตามที่ต้องการ.