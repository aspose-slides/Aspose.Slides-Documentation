---
title: จัดรูปแบบรูปร่าง PowerPoint ใน .NET
linktitle: การจัดรูปแบบรูปร่าง
type: docs
weight: 20
url: /th/net/shape-formatting/
keywords:
- จัดรูปแบบรูปร่าง
- จัดรูปแบบเส้น
- เอฟเฟ็กต์สเก็ตช์
- เส้นรูปร่างสเก็ตช์
- จัดรูปแบบสไตล์การเชื่อมต่อ
- การเติมสีไล่ระดับ
- การเติมลายพิมพ์
- การเติมรูปภาพ
- การเติมเทกเจอร์
- การเติมสีทึบ
- ความโปร่งใสของรูปร่าง
- หมุนรูปร่าง
- เอฟเฟ็กต์บีเวล 3 มิติ
- เอฟเฟ็กต์การหมุน 3 มิติ
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีจัดรูปแบบรูปร่าง PowerPoint ด้วย C# โดยใช้ Aspose.Slides — ตั้งค่าการเติม, เส้นและสไตล์เอฟเฟกต์สำหรับไฟล์ PPT และ PPTX อย่างแม่นยำและควบคุมเต็มที่"
---
## **บทนำ**

ใน PowerPoint คุณสามารถเพิ่มรูปทรงลงบนสไลด์ได้ เนื่องจากรูปทรงประกอบด้วยเส้น คุณจึงสามารถจัดรูปแบบได้โดยการแก้ไขหรือใช้เอฟเฟกต์กับขอบเส้นของรูปทรง นอกจากนี้คุณยังสามารถจัดรูปแบบรูปทรงโดยกำหนดการตั้งค่าที่ควบคุมการเติมสีภายใน

![รูปแบบรูปร่างใน PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for .NET มีอินเตอร์เฟซและคุณสมบัติที่ทำให้คุณจัดรูปแบบรูปทรงได้ด้วยตัวเลือกเดียวกับที่มีใน PowerPoint

## **จัดรูปแบบเส้น**

โดยใช้ Aspose.Slides คุณสามารถระบุรูปแบบเส้นแบบกำหนดเองสำหรับรูปทรง ขั้นตอนต่อไปนี้อธิบายกระบวนการ:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์ตามหมายเลขลำดับ
1. เพิ่ม[IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/)ลงในสไลด์
1. ตั้งค่า[line style](https://reference.aspose.com/slides/th/net/aspose.slides/linestyle/)ของรูปทรง
1. ตั้งความกว้างของเส้น
1. ตั้งค่า[dash style](https://reference.aspose.com/slides/th/net/aspose.slides/linedashstyle/)ของเส้น
1. ตั้งค่าสีเส้นสำหรับรูปทรง
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด C# ด้านล่างแสดงวิธีจัดรูปแบบ AutoShape สี่เหลี่ยมผืนผ้า:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ.
using (Presentation presentation = new Presentation())
{
    // เรียกสไลด์แรก.
    ISlide slide = presentation.Slides[0];

    // เพิ่ม AutoShape ชนิด Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ตั้งค่าสีเติมสำหรับรูปทรงสี่เหลี่ยม.
    shape.FillFormat.FillType = FillType.NoFill;

    // ใช้การจัดรูปแบบกับเส้นของสี่เหลี่ยม.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // ตั้งค่าสีสำหรับเส้นของสี่เหลี่ยม.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![The formatted lines in the presentation](formatted-lines.png)

## **ใช้เอฟเฟกต์สเก็ตช์กับเส้นรูปทรง**

เอฟเฟกต์สเก็ตช์ทำให้เส้นของรูปทรงดูเหมือนวาดด้วยมือ ใช้[IShape.LineFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/lineformat/)เพื่อเข้าถึงการตั้งค่าเส้น,[ILineFormat.SketchFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ilineformat/sketchformat/)เพื่อเข้าถึงการตั้งค่าสเก็ตช์,และ[ISketchFormat.SketchType](https://reference.aspose.com/slides/th/net/aspose.slides/isketchformat/sketchtype/)เพื่อเลือกค่าจาก enumeration[LineSketchType](https://reference.aspose.com/slides/th/net/aspose.slides/linesketchtype/)

โค้ด C# ด้านล่างแสดงวิธีใช้เอฟเฟกต์[LineSketchType.Curved](https://reference.aspose.com/slides/th/net/aspose.slides/linesketchtype/) อ่านค่าที่กำหนดอย่างชัดเจนและลบเอฟเฟกต์ด้วย[LineSketchType.None](https://reference.aspose.com/slides/th/net/aspose.slides/linesketchtype/):

```csharp
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

ค่าที่คืนจาก `ISketchFormat.SketchType` แสดงการตั้งค่าที่กำหนดโดยตรงให้กับรูปทรง หากการจัดรูปแบบเส้นสามารถรับมาจากธีม มาสเตอร์สไลด์ หรือเลย์เอาต์สไลด์ ให้ใช้[ILineFormat.GetEffective](https://reference.aspose.com/slides/th/net/aspose.slides/ilineformat/geteffective/) เข้าถึง[ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ilineformateffectivedata/sketchformat/) และอ่าน[ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/th/net/aspose.slides/isketchformateffectivedata/sketchtype/) ค่าที่มีประสิทธิภาพจะแสดงการจัดรูปแบบที่นำมาใช้จริงหลังจากการสืบทอดได้รับการแก้ไข:

```csharp
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

ตัวเลือกสไตล์การเชื่อมต่อสามแบบมีดังนี้:

* Round
* Miter
* Bevel

โดยค่าปริยาย PowerPoint จะใช้การตั้งค่า **Round** เมื่อเชื่อมสองเส้นที่มุม (เช่นที่มุมของรูปทรง) อย่างไรก็ตาม หากคุณวาดรูปทรงที่มุมคม คุณอาจต้องการเลือก **Miter** แทน

![The join style in the presentation](join-style-powerpoint.png)

โค้ด C# ด้านล่างแสดงวิธีสร้างสี่เหลี่ยมสามรูป (ตามรูปด้านบน) โดยใช้การตั้งค่า Join Type เป็น Miter, Bevel, และ Round ตามลำดับ:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ.
using (Presentation presentation = new Presentation())
{
    // ดึงสไลด์แรก.
    ISlide slide = presentation.Slides[0];

    // เพิ่ม AutoShape สามรูปชนิด Rectangle.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // ตั้งค่าสีเติมสำหรับรูปสี่เหลี่ยมแต่ละรูป.
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // ตั้งค่าความกว้างของเส้น.
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // ตั้งค่าสีสำหรับเส้นของแต่ละสี่เหลี่ยม.
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // ตั้งค่าสไตล์การเชื่อมต่อ.
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // เพิ่มข้อความลงในแต่ละสี่เหลี่ยม.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **การเติมสีแบบไล่ระดับ**

ใน PowerPoint การเติมสีแบบ Gradient (ไล่ระดับ) คือออพชันที่ให้คุณใช้การผสมสีต่อเนื่องบนรูปทรง ตัวอย่างเช่น คุณสามารถใช้สองสีหรือมากกว่านั้นโดยให้สีหนึ่งค่อย ๆ หายไปสู่สีอื่น

วิธีการใช้ Gradient Fill กับรูปทรงโดยใช้ Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์ตามหมายเลขลำดับ
1. เพิ่ม[IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/)ลงในสไลด์
1. ตั้งค่า[FillType](https://reference.aspose.com/slides/th/net/aspose.slides/filltype/)ของรูปทรงเป็น `Gradient`
1. ใช้วิธี `Add` ของคอลเลกชัน gradient stop ที่เปิดให้เข้าถึงผ่านอินเตอร์เฟซ[IGradientFormat](https://reference.aspose.com/slides/th/net/aspose.slides/igradientformat/) เพื่อเพิ่มสองสีที่คุณต้องการพร้อมตำแหน่งที่กำหนด
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด C# ด้านล่างแสดงวิธีใช้เอฟเฟกต์ Gradient Fill กับวงรี:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ.
using (Presentation presentation = new Presentation())
{
    // ดึงสไลด์แรก.
    ISlide slide = presentation.Slides[0];

    // เพิ่ม AutoShape ชนิด Ellipse.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // ใช้การจัดรูปแบบ Gradient กับวงรี.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // ตั้งค่าทิศทางของ Gradient.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // เพิ่มสองจุด Gradient.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![The ellipse with gradient fill](gradient-fill.png)

## **การเติมแบบลายพิมพ์**

ใน PowerPoint การเติมแบบ Pattern (ลายพิมพ์) คือออพชันที่ให้คุณใช้การออกแบบสองสี—เช่น จุด, เส้นประ, ลายกากบาท หรือลายตาราง—บนรูปทรง คุณสามารถกำหนดสีพื้นหน้าและสีพื้นหลังของลายได้ตามต้องการ

Aspose.Slides มีลายพิมพ์สำเร็จรูปมากกว่า 45 แบบที่คุณสามารถใช้กับรูปทรงเพื่อเพิ่มความสวยงามให้การนำเสนอของคุณ แม้จะเลือกลายพิมพ์สำเร็จรูปแล้ว คุณก็ยังสามารถกำหนดสีที่ต้องการให้ลายใช้ได้

วิธีการใช้ Pattern Fill กับรูปทรงโดยใช้ Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์ตามหมายเลขลำดับ
1. เพิ่ม[IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/)ลงในสไลด์
1. ตั้งค่า[FillType](https://reference.aspose.com/slides/th/net/aspose.slides/filltype/)ของรูปทรงเป็น `Pattern`
1. เลือกรูปแบบลายจากตัวเลือกที่เตรียมไว้
1. ตั้งค่า[Background Color](https://reference.aspose.com/slides/th/net/aspose.slides/ipatternformat/backcolor/)ของลาย
1. ตั้งค่า[Foreground Color](https://reference.aspose.com/slides/th/net/aspose.slides/ipatternformat/forecolor/)ของลาย
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด C# ด้านล่างแสดงวิธีใช้ Pattern Fill กับสี่เหลี่ยม:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ.
using (Presentation presentation = new Presentation())
{
    // ดึงสไลด์แรก.
    ISlide slide = presentation.Slides[0];

    // เพิ่ม AutoShape ชนิด Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ตั้งค่า FillType เป็น Pattern.
    shape.FillFormat.FillType = FillType.Pattern;

    // ตั้งค่าสไตล์ลายพิมพ์.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // ตั้งค่าสีพื้นหลังและสีพื้นหน้าของลายพิมพ์.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![The rectangle with pattern fill](pattern-fill.png)

## **การเติมรูปภาพ**

ใน PowerPoint การเติมรูปภาพ (Picture Fill) คือออพชันที่ให้คุณใส่ภาพภายในรูปทรง—โดยใช้ภาพเป็นพื้นหลังของรูปทรง

วิธีใช้ Aspose.Slides เพื่อเติมรูปภาพให้กับรูปทรง:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์ตามหมายเลขลำดับ
1. เพิ่ม[IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/)ลงในสไลด์
1. ตั้งค่า[FillType](https://reference.aspose.com/slides/th/net/aspose.slides/filltype/)ของรูปทรงเป็น `Picture`
1. ตั้งค่าโหมดเติมรูปภาพเป็น `Tile` (หรือโหมดอื่นตามต้องการ)
1. สร้างอ็อบเจ็กต์[IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/)จากภาพที่คุณต้องการใช้
1. กำหนดภาพนี้ให้กับคุณสมบัติ`Picture.Image`ของ`PictureFillFormat`ของรูปทรง
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

สมมติว่าเรามีไฟล์ “lotus.png” ที่มีรูปภาพดังนี้:

![The lotus picture](lotus.png)

โค้ด C# ด้านล่างแสดงวิธีเติมรูปทรงด้วยรูปภาพ:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ.
using (Presentation presentation = new Presentation())
{
    // ดึงสไลด์แรก.
    ISlide slide = presentation.Slides[0];

    // เพิ่ม AutoShape ชนิด Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // ตั้งค่า FillType เป็น Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // ตั้งค่าโหมดเติมรูปภาพ.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // โหลดภาพและเพิ่มลงในทรัพยากรของการนำเสนอ.
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // ตั้งค่ารูปภาพ.
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![The shape with picture fill](picture-fill.png)

### **Tile Picture As Texture**

หากต้องการตั้งค่าภาพแบบเรียงต่อกันเป็นเทกเจอร์และปรับพฤติกรรมการเรียงต่อ คุณสามารถใช้คุณสมบัติดังต่อไปนี้ของอินเตอร์เฟซ[IPictureFillFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/)และคลาส[PictureFillFormat](https://reference.aspose.com/slides/th/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/picturefillmode/): ตั้งค่าโหมดเติมรูปภาพ—`Tile` หรือ `Stretch`
- [TileAlignment](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/tilealignment/): ระบุการจัดตำแหน่งของภาพต่อในรูปทรง
- [TileFlip](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/tileflip/): ควบคุมการพลิกภาพแนวนอน แนวตั้ง หรือทั้งสองอย่าง
- [TileOffsetX](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/tileoffsetx/): ตั้งค่าการเลื่อนแนวนอนของภาพ (เป็นพอยต์) จากจุดกำเนิดของรูปทรง
- [TileOffsetY](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/tileoffsety/): ตั้งค่าการเลื่อนแนวตั้งของภาพ (เป็นพอยต์) จากจุดกำเนิดของรูปทรง
- [TileScaleX](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/tilescalex/): กำหนดสเกลแนวนอนของภาพเป็นเปอร์เซ็นต์
- [TileScaleY](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/tilescaley/): กำหนดสเกลแนวตั้งของภาพเป็นเปอร์เซ็นต์

โค้ดตัวอย่างด้านล่างแสดงวิธีเพิ่มรูปทรงสี่เหลี่ยมพร้อมการเติมรูปภาพแบบต่อกันและกำหนดตัวเลือกการต่อกัน:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ.
using (Presentation presentation = new Presentation())
{
    // ดึงสไลด์แรก.
    ISlide firstSlide = presentation.Slides[0];

    // เพิ่ม AutoShape สี่เหลี่ยมผืนผ้า.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // ตั้งค่า FillType ของรูปทรงเป็น Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // โหลดภาพและเพิ่มลงในทรัพยากรของการนำเสนอ.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // กำหนดภาพให้กับรูปทรง.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // ตั้งค่าโหมดเติมรูปภาพและคุณสมบัติการต่อภาพ.
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

![The tile options](tile-options.png)

## **การเติมสีทึบ**

ใน PowerPoint การเติมสี Solid (สีทึบ) คือออพชันที่เติมรูปทรงด้วยสีเดียวที่สม่ำเสมอ พื้นหลังสีเดียวนี้จะไม่มีการไล่ระดับ พื้นผิวหรือรูปแบบใด ๆ

วิธีการใช้ Solid Color Fill กับรูปทรงโดยใช้ Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์ตามหมายเลขลำดับ
1. เพิ่ม[IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/)ลงในสไลด์
1. ตั้งค่า[FillType](https://reference.aspose.com/slides/th/net/aspose.slides/filltype/)ของรูปทรงเป็น `Solid`
1. กำหนดสีเติมที่คุณต้องการให้กับรูปทรง
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด C# ด้านล่างแสดงวิธีใช้ Solid Color Fill กับสี่เหลี่ยมในสไลด์ PowerPoint:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ.
using (Presentation presentation = new Presentation())
{
    // ดึงสไลด์แรก.
    ISlide slide = presentation.Slides[0];

    // เพิ่ม AutoShape ชนิด Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ตั้งค่า FillType เป็น Solid.
    shape.FillFormat.FillType = FillType.Solid;

    // ตั้งค่าสีเติม.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![The shape with solid color fill](solid-color-fill.png)

## **ตั้งค่าความโปร่งใส**

ใน PowerPoint เมื่อคุณใช้สีทึบ, Gradient, Picture หรือ Texture Fill กับรูปทรง คุณสามารถตั้งค่าระดับความโปร่งใสเพื่อควบคุมความทึบของการเติม สีที่ความโปร่งใสสูงจะทำให้รูปทรงใสมากขึ้นและทำให้พื้นหลังหรือวัตถุด้านล่างมองเห็นได้บางส่วน

Aspose.Slides ให้คุณตั้งค่าความโปร่งใสโดยปรับค่า alpha ในสีที่ใช้สำหรับการเติม วิธีทำดังนี้:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์ตามหมายเลขลำดับ
1. เพิ่ม[IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/)ลงในสไลด์
1. ตั้งค่า[FillType](https://reference.aspose.com/slides/th/net/aspose.slides/filltype/)เป็น `Solid`
1. ใช้ `Color.FromArgb(alpha, baseColor)` เพื่อกำหนดสีที่มีความโปร่งใส (ส่วน `alpha` ควบคุมความโปร่งใส)
1. บันทึกการนำเสนอ

โค้ด C# ด้านล่างแสดงวิธีใช้สีเติมที่โปร่งใสกับสี่เหลี่ยม:

```c#
const int alpha = 128;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ.
using (Presentation presentation = new Presentation())
{
    // ดึงสไลด์แรก.
    ISlide slide = presentation.Slides[0];

    // เพิ่ม AutoShape สี่เหลี่ยมผืนผ้าแบบสีทึบ.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // เพิ่ม AutoShape สี่เหลี่ยมผืนผ้าแบบโปร่งแสงเหนือรูปทรงสีทึบ.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![The transparent shape](shape-transparency.png)

## **หมุนรูปทรง**

Aspose.Slides ให้คุณหมุนรูปทรงในการนำเสนอ PowerPoint ซึ่งมีประโยชน์เมื่อต้องจัดตำแหน่งองค์ประกอบภาพให้ตรงกับการออกแบบหรือการจัดแนวที่ต้องการ

ขั้นตอนการหมุนรูปทรงบนสไลด์:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์ตามหมายเลขลำดับ
1. เพิ่ม[IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/)ลงในสไลด์
1. ตั้งค่าคุณสมบัติ`Rotation`ของรูปทรงเป็นมุมที่ต้องการ
1. บันทึกการนำเสนอ

โค้ด C# ด้านล่างแสดงวิธีหมุนรูปทรงโดย 5 องศา:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ.
using (Presentation presentation = new Presentation())
{
    // ดึงสไลด์แรก.
    ISlide slide = presentation.Slides[0];

    // เพิ่ม AutoShape ชนิด Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // หมุนรูปทรงด้วยมุม 5 องศา.
    shape.Rotation = 5;

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![The shape rotation](shape-rotation.png)

## **เพิ่มเอฟเฟกต์ Bevel 3 มิติ**

Aspose.Slides ให้คุณใช้เอฟเฟกต์ Bevel 3 มิติกับรูปทรงโดยกำหนดคุณสมบัติ[ThreeDFormat](https://reference.aspose.com/slides/th/net/aspose.slides/threedformat/)

ขั้นตอนการเพิ่มเอฟเฟกต์ Bevel 3 มิติ:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์ตามหมายเลขลำดับ
1. เพิ่ม[IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/)ลงในสไลด์
1. กำหนดค่า[ThreeDFormat](https://reference.aspose.com/slides/th/net/aspose.slides/threedformat/)ของรูปทรงเพื่อระบุการตั้งค่า bevel
1. บันทึกการนำเสนอ

โค้ด C# ด้านล่างแสดงวิธีใช้เอฟเฟกต์ Bevel 3 มิติกับรูปทรง:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // เพิ่มรูปทรงลงในสไลด์.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;

    // ตั้งค่าคุณสมบัติ ThreeDFormat ของรูปทรง.
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

    // บันทึกการนำเสนอเป็นไฟล์ PPTX.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![The 3D bevel effect](3D-bevel-effect.png)

## **เพิ่มเอฟเฟกต์การหมุน 3 มิติ**

Aspose.Slides ให้คุณใช้เอฟเฟกต์การหมุน 3 มิติกับรูปทรงโดยกำหนดคุณสมบัติ[ThreeDFormat](https://reference.aspose.com/slides/th/net/aspose.slides/threedformat/)

ขั้นตอนการใช้การหมุน 3 มิติกับรูปทรง:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์ตามหมายเลขลำดับ
1. เพิ่ม[IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/)ลงในสไลด์
1. ตั้งค่า[CameraType](https://reference.aspose.com/slides/th/net/aspose.slides/icamera/cameratype/)และ[LightType](https://reference.aspose.com/slides/th/net/aspose.slides/ilightrig/lighttype/)ของรูปทรงเพื่อกำหนดการหมุน 3 มิติ
1. บันทึกการนำเสนอ

โค้ด C# ด้านล่างแสดงวิธีใช้เอฟเฟกต์การหมุน 3 มิติกับรูปทรง:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // บันทึกการนำเสนอเป็นไฟล์ PPTX.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![The 3D rotation effect](3D-rotation-effect.png)

## **รีเซ็ตการจัดรูปแบบ**

โค้ด C# ด้านล่างแสดงวิธีรีเซ็ตการจัดรูปแบบของสไลด์และคืนค่าตำแหน่ง, ขนาดและการจัดรูปแบบของรูปทรงทั้งหมดที่มี placeholder บน[LayoutSlide](https://reference.aspose.com/slides/th/net/aspose.slides/layoutslide/)ให้กลับไปเป็นค่าตั้งต้น:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // รีเซ็ตแต่ละรูปทรงบนสไลด์ที่มี placeholder บนเลย์เอาต์.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**การจัดรูปแบบรูปทรงมีผลต่อขนาดไฟล์การนำเสนอสุดท้ายหรือไม่?**

มีผลเพียงเล็กน้อย ภาพและสื่อที่ฝังเป็นส่วนใหญ่ของขนาดไฟล์ ส่วนพารามิเตอร์ของรูปทรงเช่นสี, เอฟเฟกต์และไล่ระดับจะถูกเก็บเป็นเมตาดาต้าและเพิ่มขนาดไฟล์แทบไม่มี

**ฉันจะตรวจจับรูปทรงบนสไลด์ที่มีการจัดรูปแบบเท่ากันทั้งหมดเพื่อทำการกลุ่มได้อย่างไร?**

เปรียบเทียบคุณสมบัติการจัดรูปแบบหลักของแต่ละรูปทรง—การเติม, เส้น, และการตั้งค่าเอฟเฟกต์ หากค่าทั้งหมดตรงกัน ให้ถือว่าเป็นสไตล์เดียวกันและจัดกลุ่มรูปทรงเหล่านั้นตามลอจิก ซึ่งจะทำให้การจัดการสไตล์ในภายหลังง่ายขึ้น

**ฉันสามารถบันทึกชุดสไตล์รูปทรงที่กำหนดเองเป็นไฟล์แยกเพื่อใช้งานใหม่ในงานนำเสนออื่นได้หรือไม่?**

ทำได้โดยเก็บรูปทรงตัวอย่างที่มีสไตล์ที่ต้องการในสไลด์แม่แบบหรือไฟล์เทมเพลต .POTX เมื่อสร้างงานนำเสนอใหม่ ให้เปิดเทมเพลตและทำการคัดลอกรูปทรงที่ต้องการแล้วนำการจัดรูปแบบไปใช้ที่ต้องการต่อไป