---
title: จัดรูปแบบรูปร่าง PowerPoint ใน .NET
linktitle: การจัดรูปแบบรูปร่าง
type: docs
weight: 20
url: /th/net/shape-formatting/
keywords:
- จัดรูปแบบรูปร่าง
- จัดรูปแบบเส้น
- เอฟเฟคต์สเก็ตช์
- เส้นรูปร่างสเก็ตช์
- จัดรูปแบบสไตล์จอยน์
- การเติมสีไล่โทน
- การเติมลวดลาย
- การเติมรูปภาพ
- การเติมพื้นผิว
- การเติมสีทึบ
- ความโปร่งใสของรูปร่าง
- การเรนเดอร์รูปร่างสีขาว-ดำ
- การเรนเดอร์รูปร่างระดับสีเทา
- หมุนรูปร่าง
- เอฟเฟคต์ bevel 3 มิติ
- เอฟเฟคต์การหมุน 3 มิติ
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีจัดรูปแบบรูปร่าง PowerPoint ด้วย C# และ Aspose.Slides—ตั้งค่าการเติม, เส้น, และสไตล์เอฟเฟกต์สำหรับไฟล์ PPT และ PPTX อย่างแม่นยำและควบคุมเต็มที่"
---
## **บทนำ**

ใน PowerPoint คุณสามารถเพิ่มรูปร่างลงในสไลด์ได้ เนื่องจากรูปร่างประกอบด้วยเส้น คุณสามารถจัดรูปแบบได้โดยการแก้ไขหรือใช้เอฟเฟกต์กับโครงร่างของพวกมัน นอกจากนี้คุณยังสามารถจัดรูปแบบรูปร่างโดยระบุการตั้งค่าที่ควบคุมวิธีที่ส่วนภายในของรูปร่างถูกเติมสีได้

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for .NET มีอินเทอร์เฟซและคุณสมบัติที่อนุญาตให้คุณจัดรูปแบบรูปร่างโดยใช้ตัวเลือกเดียวกันที่มีใน PowerPoint

## **จัดรูปแบบเส้น**

โดยใช้ Aspose.Slides คุณสามารถระบุสไตล์เส้นที่กำหนดเองสำหรับรูปร่าง ขั้นตอนต่อไปนี้สรุปกระบวนการ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ลงในสไลด์
1. ตั้งค่า [line style](https://reference.aspose.com/slides/th/net/aspose.slides/linestyle/) ของรูปร่าง
1. ตั้งความกว้างของเส้น
1. ตั้งค่า [dash style](https://reference.aspose.com/slides/th/net/aspose.slides/linedashstyle/) ของเส้น
1. ตั้งค่าสีของเส้นสำหรับรูปร่าง
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด C# ด้านล่างแสดงวิธีการจัดรูปแบบ `AutoShape` รูปสี่เหลี่ยม:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ
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

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![เส้นที่จัดรูปแบบในงานนำเสนอ](formatted-lines.png)

## **ใช้เอฟเฟกต์สเก็ตช์กับเส้นของรูปร่าง**

เอฟเฟกต์สเก็ตช์ทำให้เส้นของรูปร่างดูเหมือนวาดมือ ใช้ [IShape.LineFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/lineformat/) เพื่อเข้าถึงการตั้งค่าเส้น, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ilineformat/sketchformat/) เพื่อเข้าถึงการตั้งค่าสเก็ตช์, และ [ISketchFormat.SketchType](https://reference.aspose.com/slides/th/net/aspose.slides/isketchformat/sketchtype/) เพื่อเลือกค่าจาก enumeration [LineSketchType](https://reference.aspose.com/slides/th/net/aspose.slides/linesketchtype/)

โค้ด C# ด้านล่างแสดงวิธีการใช้เอฟเฟกต์ [LineSketchType.Curved](https://reference.aspose.com/slides/th/net/aspose.slides/linesketchtype/) อ่านค่าที่กำหนดโดยตรงและลบเอฟเฟกต์ด้วย [LineSketchType.None](https://reference.aspose.com/slides/th/net/aspose.slides/linesketchtype/):

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

ค่าที่คืนโดย `ISketchFormat.SketchType` แทนการตั้งค่าที่กำหนดโดยตรงให้กับรูปร่าง หากการจัดรูปแบบเส้นสามารถสืบทอดจากธีม, มาสเตอร์สไลด์ หรือเลย์เอาต์สไลด์ ให้ใช้ [ILineFormat.GetEffective](https://reference.aspose.com/slides/th/net/aspose.slides/ilineformat/geteffective/), เข้าถึง [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ilineformateffectivedata/sketchformat/), และอ่านค่า [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/th/net/aspose.slides/isketchformateffectivedata/sketchtype/). ค่าที่มีผลสะท้อนการจัดรูปแบบที่ใช้จริงหลังจากการสืบทอดได้รับการแก้ไขแล้ว:

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

## **จัดรูปแบบสไตล์จอยน์**

ต่อไปนี้เป็นตัวเลือกสามประเภทของจอยน์:

* กลม
* มิเชอร์
* บีเวล

โดยค่าเริ่มต้น เมื่อ PowerPoint จอยน์เส้นสองเส้นที่มุม (เช่นที่มุมของรูปร่าง) จะใช้การตั้งค่า **กลม** อย่างไรก็ตาม หากคุณวาดรูปร่างที่มีมุมแหลม คุณอาจต้องการตัวเลือก **มิเชอร์** แทน

![สไตล์จอยน์ในงานนำเสนอ](join-style-powerpoint.png)

โค้ด C# ด้านล่างแสดงวิธีการสร้างสี่เหลี่ยมสามรูป (ตามภาพด้านบน) โดยใช้การตั้งค่าจอยน์แบบ มิเชอร์, บีเวล, และ กลม:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ
using (Presentation presentation = new Presentation())
{
    // รับสไลด์แรก
    ISlide slide = presentation.Slides[0];

    // เพิ่มรูปร่างอัตโนมัติประเภทสี่เหลี่ยมจำนวนสามรูป
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // ตั้งค่าสีเติมสำหรับรูปร่างสี่เหลี่ยมแต่ละรูป
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

    // ตั้งค่าสีสำหรับเส้นของสี่เหลี่ยมแต่ละรูป
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // ตั้งค่าสไตล์จอยน์
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // เพิ่มข้อความให้กับสี่เหลี่ยมแต่ละรูป
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **การเติมสีไล่โทน**

ใน PowerPoint การเติมสีไล่โทนเป็นตัวเลือกการจัดรูปแบบที่ให้คุณเติมสีต่อเนื่องหลายสีลงในรูปร่าง ตัวอย่างเช่น คุณสามารถใช้สองสีหรือมากกว่านั้นโดยที่สีหนึ่งค่อย ๆ จางลงสู่สีอีกสีหนึ่ง

วิธีการใช้การเติมสีไล่โทนในรูปร่างด้วย Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ลงในสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/net/aspose.slides/filltype/) ของรูปร่างเป็น `Gradient`
1. เพิ่มสีที่คุณต้องการสองสีพร้อมตำแหน่งที่กำหนดโดยใช้เมธอด `Add` ของคอลเลกชัน gradient stop ที่เปิดให้ใช้งานโดยอินเทอร์เฟซ [IGradientFormat](https://reference.aspose.com/slides/th/net/aspose.slides/igradientformat/)
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด C# ด้านล่างแสดงวิธีการใช้เอฟเฟกต์การเติมสีไล่โทนบนวงรี:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ
using (Presentation presentation = new Presentation())
{
    // รับสไลด์แรก
    ISlide slide = presentation.Slides[0];

    // เพิ่มรูปร่างอัตโนมัติประเภทวงรี
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // ใช้การจัดรูปแบบไล่โทนกับวงรี
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // ตั้งค่าทิศทางของไล่โทน
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // เพิ่มจุดหยุดไล่โทนสองจุด
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![วงรอบที่เติมสีไล่โทน](gradient-fill.png)

## **การเติมลวดลาย**

ใน PowerPoint การเติมลวดลายเป็นตัวเลือกการจัดรูปแบบที่ให้คุณเติมการออกแบบสองสี—เช่น จุด, ลายเส้น, เส้นตัดกัน หรือการตรวจสอบ—ลงในรูปร่าง คุณสามารถเลือกสีที่กำหนดเองสำหรับพื้นหน้าลวดลายและพื้นหลังได้

Aspose.Slides มีลักษณะลวดลายพร้อมใช้งานมากกว่า 45 แบบที่คุณสามารถนำไปใช้กับรูปร่างเพื่อเพิ่มความสวยงามให้กับการนำเสนอของคุณ แม้หลังจากเลือกลวดลายที่กำหนดไว้ล่วงหน้าแล้ว คุณยังสามารถระบุสีที่แน่นอนที่ลวดลายควรใช้ได้

วิธีการใช้การเติมลวดลายบนรูปร่างด้วย Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ลงในสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/net/aspose.slides/filltype/) ของรูปร่างเป็น `Pattern`
1. เลือกสไตล์ลวดลายจากตัวเลือกที่กำหนดไว้ล่วงหน้า
1. ตั้งค่า [Background Color](https://reference.aspose.com/slides/th/net/aspose.slides/ipatternformat/backcolor/) ของลวดลาย
1. ตั้งค่า [Foreground Color](https://reference.aspose.com/slides/th/net/aspose.slides/ipatternformat/forecolor/) ของลวดลาย
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด C# ด้านล่างแสดงวิธีการใช้การเติมลวดลายบนสี่เหลี่ยม:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ
using (Presentation presentation = new Presentation())
{
    // รับสไลด์แรก
    ISlide slide = presentation.Slides[0];

    // เพิ่มรูปร่างอัตโนมัติประเภทสี่เหลี่ยม
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ตั้งค่าประเภทการเติมเป็นลวดลาย
    shape.FillFormat.FillType = FillType.Pattern;

    // ตั้งค่าสไตล์ลวดลาย
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // ตั้งค่าสีพื้นหลังและสีหน้าของลวดลาย
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![สี่เหลี่ยมที่เติมลวดลาย](pattern-fill.png)

## **การเติมรูปภาพ**

ใน PowerPoint การเติมรูปภาพเป็นตัวเลือกการจัดรูปแบบที่ให้คุณแทรกรูปภาพภายในรูปร่าง—โดยใช้รูปภาพเป็นพื้นหลังของรูปร่างได้อย่างมีประสิทธิภาพ

วิธีการใช้ Aspose.Slides เพื่อเติมรูปภาพบนรูปร่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ลงในสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/net/aspose.slides/filltype/) ของรูปร่างเป็น `Picture`
1. ตั้งค่าโหมดการเติมรูปภาพเป็น `Tile` (หรือโหมดที่คุณต้องการอื่น)
1. สร้างอ็อบเจกต์ [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) จากรูปภาพที่คุณต้องการใช้
1. กำหนดภาพนี้ให้กับคุณสมบัติ `Picture.Image` ของ `PictureFillFormat` ของรูปร่าง
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

สมมุติว่าเรามีไฟล์ "lotus.png" ที่มีรูปภาพต่อไปนี้:

![รูปภาพดอกบัว](lotus.png)

โค้ด C# ด้านล่างแสดงวิธีการเติมรูปภาพลงในรูปร่าง:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ
using (Presentation presentation = new Presentation())
{
    // รับสไลด์แรก
    ISlide slide = presentation.Slides[0];

    // เพิ่มรูปร่างอัตโนมัติประเภทสี่เหลี่ยม
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // ตั้งค่าประเภทการเติมเป็นรูปภาพ
    shape.FillFormat.FillType = FillType.Picture;

    // ตั้งค่าโหมดการเติมรูปภาพ
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // โหลดรูปภาพและเพิ่มเข้าไปในทรัพยากรของงานนำเสนอ
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // ตั้งค่ารูปภาพ
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![รูปร่างที่เติมรูปภาพ](picture-fill.png)

### **ต่อภาพเป็นพื้นผิว**

หากคุณต้องการตั้งค่าภาพต่อเป็นพื้นผิวและกำหนดพฤติกรรมการต่อ คุณสามารถใช้คุณสมบัติต่อไปนี้ของอินเทอร์เฟซ [IPictureFillFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/) และคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/picturefillmode/): ตั้งค่าโหมดการเติมรูปภาพ—`Tile` หรือ `Stretch`
- [TileAlignment](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/tilealignment/): ระบุมาตรฐานการจัดตำแหน่งของไทล์ภายในรูปร่าง
- [TileFlip](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/tileflip/): ควบคุมว่าภาพไทล์จะพลิกแนวนอน แนวตั้ง หรือทั้งสองอย่างหรือไม่
- [TileOffsetX](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/tileoffsetx/): ตั้งค่าการเยื้องแนวนอนของไทล์ (เป็นพอยต์) จากจุดกำเนิดของรูปร่าง
- [TileOffsetY](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/tileoffsety/): ตั้งค่าการเยื้องแนวตั้งของไทล์ (เป็นพอยต์) จากจุดกำเนิดของรูปร่าง
- [TileScaleX](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/tilescalex/): กำหนดสเกลแนวนอนของไทล์เป็นเปอร์เซ็นต์
- [TileScaleY](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/tilescaley/): กำหนดสเกลแนวตั้งของไทล์เป็นเปอร์เซ็นต์

โค้ดตัวอย่างด้านล่างแสดงวิธีการเพิ่มรูปร่างสี่เหลี่ยมที่มีการเติมรูปภาพแบบต่อและกำหนดตัวเลือกไทล์:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ
using (Presentation presentation = new Presentation())
{
    // รับสไลด์แรก
    ISlide firstSlide = presentation.Slides[0];

    // เพิ่มรูปร่างอัตโนมัติประเภทสี่เหลี่ยม
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // ตั้งค่าประเภทการเติมของรูปร่างเป็นรูปภาพ
    shape.FillFormat.FillType = FillType.Picture;

    // โหลดรูปภาพและเพิ่มเข้าไปในทรัพยากรของงานนำเสนอ
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // กำหนดรูปภาพให้กับรูปร่าง
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // กำหนดค่าโหมดการเติมรูปภาพและคุณสมบัติการต่อภาพ
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![ตัวเลือกไทล์](tile-options.png)

## **การเติมสีทึบ**

ใน PowerPoint การเติมสีทึบเป็นตัวเลือกการจัดรูปแบบที่เติมสีเดียวที่เป็นสีสม่ำเสมอบนรูปร่าง สีพื้นหลังแบบเรียบนี้จะไม่มีการไล่โทน พื้นผิว หรือลวดลายใด ๆ

วิธีการใช้ Aspose.Slides เพื่อเติมสีทึบบนรูปร่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ลงในสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/net/aspose.slides/filltype/) ของรูปร่างเป็น `Solid`
1. กำหนดสีเติมที่คุณต้องการให้กับรูปร่าง
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด C# ด้านล่างแสดงวิธีการเติมสีทึบบนสี่เหลี่ยมในสไลด์ PowerPoint:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ
using (Presentation presentation = new Presentation())
{
    // รับสไลด์แรก
    ISlide slide = presentation.Slides[0];

    // เพิ่มรูปร่างอัตโนมัติประเภทสี่เหลี่ยม
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ตั้งค่าประเภทการเติมเป็นสีทึบ
    shape.FillFormat.FillType = FillType.Solid;

    // ตั้งค่าสีเติม
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![รูปร่างที่เติมสีทึบ](solid-color-fill.png)

## **ตั้งค่าความโปร่งใส**

ใน PowerPoint เมื่อคุณเติมสีทึบ, ไล่โทน, รูปภาพ หรือพื้นผิวบนรูปร่าง คุณยังสามารถตั้งค่าระดับความโปร่งใสเพื่อควบคุมความทึบของการเติม สีที่มีค่าความโปร่งใสสูงทำให้รูปร่างดูโปร่งใสมากขึ้นและทำให้พื้นหลังหรือวัตถุที่อยู่ด้านล่างมองเห็นได้บางส่วน

Aspose.Slides ให้คุณตั้งค่าระดับความโปร่งใสโดยการปรับค่าอัลфаในสีที่ใช้สำหรับการเติม วิธีทำดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ลงในสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/net/aspose.slides/filltype/) เป็น `Solid`
1. ใช้ `Color.FromArgb(alpha, baseColor)` เพื่อกำหนดสีที่มีความโปร่งใส (ส่วน `alpha` ควบคุมความโปร่งใส)
1. บันทึกงานนำเสนอ

โค้ด C# ด้านล่างแสดงวิธีการใช้สีเติมที่มีความโปร่งใสบนสี่เหลี่ยม:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ
using (Presentation presentation = new Presentation())
{
    // รับสไลด์แรก
    ISlide slide = presentation.Slides[0];

    // เพิ่มรูปร่างอัตโนมัติสี่เหลี่ยมสีทึบ
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // เพิ่มรูปร่างอัตโนมัติสี่เหลี่ยมโปร่งใสเหนือรูปร่างสีทึบ
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![รูปร่างที่โปร่งใส](shape-transparency.png)

## **หมุนรูปร่าง**

Aspose.Slides ให้คุณหมุนรูปร่างในงานนำเสนอ PowerPoint ซึ่งมีประโยชน์เมื่อกำหนดตำแหน่งองค์ประกอบภาพตามการจัดแนวหรือความต้องการออกแบบเฉพาะ

ขั้นตอนการหมุนรูปร่างบนสไลด์:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ลงในสไลด์
1. ตั้งค่าคุณสมบัติ `Rotation` ของรูปร่างเป็นมุมที่ต้องการ
1. บันทึกงานนำเสนอ

โค้ด C# ด้านล่างแสดงวิธีการหมุนรูปร่างด้วยมุม 5 องศา:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ
using (Presentation presentation = new Presentation())
{
    // รับสไลด์แรก
    ISlide slide = presentation.Slides[0];

    // เพิ่มรูปร่างอัตโนมัติประเภทสี่เหลี่ยม
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // หมุนรูปร่างด้วยมุม 5 องศา
    shape.Rotation = 5;

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![การหมุนของรูปร่าง](shape-rotation.png)

## **เพิ่มเอฟเฟกต์ bevel 3D**

Aspose.Slides อนุญาตให้คุณใช้เอฟเฟกต์ bevel 3D กับรูปร่างโดยกำหนดค่าคุณสมบัติ [ThreeDFormat](https://reference.aspose.com/slides/th/net/aspose.slides/threedformat/)

ขั้นตอนการเพิ่มเอฟเฟกต์ bevel 3D ให้กับรูปร่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ลงในสไลด์
1. กำหนดค่า [ThreeDFormat](https://reference.aspose.com/slides/th/net/aspose.slides/threedformat/) ของรูปร่างเพื่อระบุการตั้งค่า bevel
1. บันทึกงานนำเสนอ

โค้ด C# ด้านล่างแสดงวิธีการใช้เอฟเฟกต์ bevel 3D กับรูปร่าง:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // เพิ่มรูปร่างลงในสไลด์
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;

    // ตั้งค่าคุณสมบัติ ThreeDFormat ของรูปร่าง
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

    // บันทึกงานนำเสนอเป็นไฟล์ PPTX
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![เอฟเฟกต์ bevel 3D](3D-bevel-effect.png)

## **เพิ่มเอฟเฟกต์การหมุน 3D**

Aspose.Slides อนุญาตให้คุณใช้เอฟเฟกต์การหมุน 3D กับรูปร่างโดยกำหนดค่าคุณสมบัติ [ThreeDFormat](https://reference.aspose.com/slides/th/net/aspose.slides/threedformat/)

ขั้นตอนการใช้การหมุน 3D กับรูปร่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ลงในสไลด์
1. ตั้งค่า [CameraType](https://reference.aspose.com/slides/th/net/aspose.slides/icamera/cameratype/) และ [LightType](https://reference.aspose.com/slides/th/net/aspose.slides/ilightrig/lighttype/) ของรูปร่างเพื่อกำหนดการหมุน 3D
1. บันทึกงานนำเสนอ

โค้ด C# ด้านล่างแสดงวิธีการใช้เอฟเฟกต์การหมุน 3D กับรูปร่าง:

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

    // บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![เอฟเฟกต์การหมุน 3D](3D-rotation-effect.png)

## **ควบคุมการเรนเดอร์สีขาว-ดำสำหรับรูปร่าง**

คุณสมบัติ [IShape.BlackWhiteMode](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/blackwhitemode/) ระบุวิธีการที่รูปร่างแต่ละชิ้นจะถูกเรนเดอร์เมื่อการนำเสนอถูกดูหรือประมวลผลในโหมดสีขาว-ดำ ซึ่งไม่ทำให้โหมดสีขาว-ดำเปิดใช้งานโดยอัตโนมัติและไม่ได้เปลี่ยนการเติม, เส้น หรือการจัดรูปแบบอื่น ๆ ของรูปร่างในโหมดสีปกติ

ใช้ค่าจาก enumeration [BlackWhiteMode](https://reference.aspose.com/slides/th/net/aspose.slides/blackwhitemode/) เพื่อเลือกพฤติกรรมที่ต้องการ ตัวอย่างเช่น `Automatic` ให้แอปพลิเคชันที่ทำการเรนเดอร์เลือกการแปลง, `Gray` และ `LightGray` ใช้สีเทา, `BlackWhite` ใช้เฉพาะสีดำและสีขาว, `Black` และ `White` บังคับให้เป็นสีเดียว, `Color` รักษาสีปกติ, และ `Hidden` ไม่แสดงรูปร่างในโหมดสีขาว-ดำ, `NotDefined` หมายถึงไม่มีการกำหนดโหมดระดับรูปร่าง

โค้ด C# ด้านล่างสร้างรูปร่างสีและทำให้มันแสดงเป็นสีเทาในโหมดแสดงผลสีขาว-ดำ:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// คงสีเติมส้มไว้ในโหมดสี แต่เรนเดอร์รูปร่างด้วยสีเทาในโหมดสีขาว-ดำ
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

ในโหมดสีปกติ สี่เหลี่ยมจะคงสีส้มของมันไว้ ในกระบวนการแสดงผลสีขาว-ดำ มันจะใช้สีเทาเพราะโหมดถูกตั้งเป็น `Gray` ซึ่งทำให้คุณสามารถเก็บสไลด์สีเต็มไว้ขณะกำหนดการแสดงผลที่แตกต่างสำหรับการพิมพ์, การดูตัวอย่าง หรือกระบวนการอื่น ๆ ที่เคารพการตั้งค่าแสดงผลสีขาว-ดำของงานนำเสนอ

## **รีเซ็ตการจัดรูปแบบ**

โค้ด C# ด้านล่างแสดงวิธีการรีเซ็ตการจัดรูปแบบของสไลด์และคืนตำแหน่ง, ขนาด, และการจัดรูปแบบของรูปร่างทั้งหมดที่มี placeholders บน [LayoutSlide](https://reference.aspose.com/slides/th/net/aspose.slides/layoutslide/) ไปยังการตั้งค่าเริ่มต้นของพวกมัน:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // รีเซ็ตรูปร่างแต่ละอันบนสไลด์ที่มี placeholder บนเลย์เอาต์.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **คำถามที่พบบ่อย**

**การจัดรูปแบบรูปร่างมีผลต่อขนาดไฟล์งานนำเสนอสุดท้ายหรือไม่?**

ผลกระทบค่อนข้างน้อย ภาพและสื่อที่ฝังอยู่ใช้พื้นที่ไฟล์ส่วนใหญ่ ส่วนพารามิเตอร์ของรูปร่าง เช่น สี, เอฟเฟกต์, และไล่โทนถูกบันทึกเป็นเมทาดาต้าและไม่เพิ่มขนาดไฟล์อย่างมีนัยสำคัญ

**ฉันจะตรวจจับรูปร่างบนสไลด์ที่มีการจัดรูปแบบเดียวกันทั้งหมดเพื่อที่จะจัดกลุ่มได้อย่างไร?**

เปรียบเทียบคุณสมบัติการจัดรูปแบบหลักของแต่ละรูปร่าง—การเติม, เส้น, และการตั้งค่าเอฟเฟกต์ หากค่าตรงกันทั้งหมด ให้ถือว่าสไตล์เดียวกันและกลุ่มรูปร่างนั้น ๆ อย่างเชิงตรรกะ ซึ่งทำให้การจัดการสไตล์ภายหลังง่ายขึ้น

**ฉันสามารถบันทึกชุดสไตล์รูปร่างแบบกำหนดเองลงในไฟล์แยกเพื่อใช้ซ้ำในงานนำเสนออื่นได้หรือไม่?**

ได้ คุณสามารถเก็บรูปร่างตัวอย่างที่มีสไตล์ที่ต้องการไว้ในเทมเพลตสไลด์เด็คหรือไฟล์เทมเพลต .POTX เมื่อต้องสร้างงานนำเสนอใหม่ ให้เปิดเทมเพลต คัดลอกรูปร่างที่สไตล์ต้องการและนำไปใช้ใหม่ตามที่ต้องการ