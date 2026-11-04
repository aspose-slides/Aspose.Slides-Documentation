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
- การเติมไล่ระดับสี
- การเติมลาย
- การเติมภาพ
- การเติมพื้นผิว
- การเติมสีทึบ
- ความโปร่งแสงของรูปร่าง
- การเรนเดอร์รูปร่างสีขาว-ดำ
- การเรนเดอร์รูปร่างระดับสีเทา
- หมุนรูปร่าง
- เอฟเฟกต์ bevel 3 มิติ
- เอฟเฟกต์การหมุน 3 มิติ
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีจัดรูปแบบรูปร่าง PowerPoint ใน C# ด้วย Aspose.Slides—ตั้งค่าการเติม, เส้น, และสไตล์เอฟเฟกต์สำหรับไฟล์ PPT และ PPTX อย่างแม่นยำและควบคุมเต็มที่"
---
## **บทนำ**

จัดรูปแบบรูปร่างใน PowerPoint โดยปรับเส้นขอบ การเติมสี และเอฟเฟกต์ต่าง ๆ Aspose.Slides สำหรับ .NET ให้คุณควบคุมการตั้งค่าเหล่านี้ด้วยโปรแกรม รวมถึงความโปร่งใส การหมุน และการจัดรูปแบบ 3 มิติ

![ตัวเลือกการจัดรูปแบบรูปร่างใน PowerPoint](format-shape-powerpoint.png)

Aspose.Slides สำหรับ .NET มีอินเทอร์เฟซและคุณสมบัติต่าง ๆ ที่ช่วยให้คุณจัดรูปแบบรูปร่างโดยใช้ตัวเลือกเดียวกับที่มีใน PowerPoint

## **จัดรูปแบบเส้น**

ใช้ [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) เพื่อควบคุมเส้นขอบของรูปร่าง ตัวอย่างนี้สร้างสี่เหลี่ยมผืนผ้าไม่มีการเติมสีที่มีเส้นขอบสีน้ำเงินเป็นจุดประแบบเส้นขีด จุดประแบบ [ILineFormat.Style](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/style/) จะเลือกเส้นแบบคอมพาวนด์หนา-บาง ในขณะที่ [ILineFormat.Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) ตั้งความกว้างเป็น 7 จุดและ [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) เลือกรูปแบบการขีด

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.Style = LineStyle.ThickThin;
shape.LineFormat.Width = 7;
shape.LineFormat.DashStyle = LineDashStyle.Dash;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![เส้นที่จัดรูปแบบในงานนำเสนอ](formatted-lines.png)

### **กำหนดรูปแบบจุดขีดแบบกำหนดเอง**

ใช้ [ILineFormat.CustomDashPattern](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/customdashpattern/) เมื่อรูปแบบเส้นที่กำหนดไว้ล่วงหน้าไม่สามารถให้ความยาวของจุดขีดและช่องว่างที่ต้องการได้ เช่น สำหรับเส้นขอบที่เป็นแบรนด์หรือแผนภาพเชิงเทคนิค การกำหนดรูปแบบจะตั้งค่า [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) เป็น [LineDashStyle.Custom](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/)

รายการอาเรย์สลับระหว่างความยาวของจุดขีดและช่องว่าง โดยเริ่มจากจุดขีด แต่ละค่าจะเป็นหลายเท่าของความกว้างของเส้น: `{ 4, 2 }` ที่ความกว้าง 3 จุดจะสร้างจุดขีด 12 จุดตามด้วยช่องว่าง 6 จุด ใช้คู่ของค่าจำกัดและเป็นจำนวนไม่ติดลบเพื่อกำหนดส่วนจุดขีดและช่องว่างที่สมบูรณ์ ตัวอย่างใช้ค่าเป็นบวกเพื่อให้จุดขีดและช่องว่างทั้งหมดมองเห็นได้

ตัวอย่างนี้สร้างเส้นสีน้ำเงินห้าสายที่มีความยาวเท่ากันและหัวเส้นแบบแบนสามสายแรกเปรียบเทียบรูปแบบที่ความกว้าง 3 จุด สายที่สี่ทำซ้ำรูปแบบแรกที่สองเท่าของความกว้าง ทำให้จุดขีดและช่องว่างเพิ่มเป็นสองเท่า สายที่ห้าสลับจากรูปแบบกำหนดเองเป็นเส้นทึบ

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(600, 300, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var patterns = new[]
{
    new float[] { 4, 2 },
    new float[] { 1, 2 },
    new float[] { 6, 2, 1, 2 },
    new float[] { 4, 2 },
    new float[] { 4, 2 }
};

for (var i = 0; i < patterns.Length; i++)
{
    var line = slide.Shapes.AddAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
    line.LineFormat.Width = i == 3 ? 6 : 3;
    line.LineFormat.FillFormat.FillType = FillType.Solid;
    line.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    line.LineFormat.CapStyle = LineCapStyle.Flat;
    line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.CustomDashPattern = patterns[i];
}

// เปลี่ยนเส้นสุดท้ายให้เป็นสไตล์ทึบ.
slide.Shapes[4].LineFormat.DashStyle = LineDashStyle.Solid;

presentation.Save("custom_dash_patterns.pptx", SaveFormat.Pptx);
```

หากต้องการกลับไปใช้รูปแบบเส้นขีดที่กำหนดไว้ล่วงหน้า ให้กำหนด [LineDashStyle.Dash](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) ให้กับ [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) รูปแบบที่เลือกจะควบคุมลักษณะของเส้น

ผลลัพธ์ใน PowerPoint จากบนลงล่าง: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; และ **Solid, 3 pt**

![สามรูปแบบจุดขีดกำหนดเอง, เส้นกว้างที่ใช้รูปแบบแรก, และเส้นทึบใน PowerPoint](custom-dash-patterns.png)


### **กำหนดหัวเส้น (Line Caps)**

ใช้ [ILineFormat.CapStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/capstyle/) เพื่อกำหนดปลายของเส้นเปิด ตัวนับ [LineCapStyle](https://reference.aspose.com/slides/net/aspose.slides/linecapstyle/) มีสามรูปแบบหัวเส้นที่ระบุชัดเจน:

- `Flat`: เส้นหยุดที่จุดปลาย
- `Round`: หัวเส้นครึ่งวงกลมขยายเกินจุดปลายโดยครึ่งความกว้างของเส้น
- `Square`: หัวเส้นสี่เหลี่ยมขยายเกินจุดปลายโดยครึ่งความกว้างของเส้น

นอกจากนี้ยังมีค่า `NotDefined` ซึ่งหมายถึงไม่มีการกำหนดรูปแบบหัวเส้นอย่างชัดเจน

หัวเส้นแตกต่างจากลูกศรที่เพิ่มสัญลักษณ์ที่ปลายเส้นและการเชื่อมต่อที่ควบคุมมุมระหว่างส่วนของเส้น ตัวอย่างนี้ปิดการใช้หัวศรผ่าน [ILineFormat.BeginArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/beginarrowheadstyle/) และ [ILineFormat.EndArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/endarrowheadstyle/) เพื่อให้เปรียบเทียบเฉพาะรูปแบบหัวเส้น

ตัวอย่างต่อไปนี้สร้างเส้นแนวนอนสามเส้นที่เหมือนกัน ความกว้าง 20 จุด จากบนลงล่างใช้หัวเส้น flat, round, และ square ตามลำดับ จุดปลายของเส้นมีพิกัดแนวนอนเดียวกัน; หัวเส้น round และ square จะยืดออกเพิ่ม 10 จุดเกินแต่ละจุดปลาย

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(500, 240, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var capStyles = new[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

for (var i = 0; i < capStyles.Length; i++)
{
    var line = slide.Shapes.AddAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
    line.LineFormat.Width = 20;
    line.LineFormat.FillFormat.FillType = FillType.Solid;
    line.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    line.LineFormat.DashStyle = LineDashStyle.Solid;
    line.LineFormat.CapStyle = capStyles[i];
    line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
}

presentation.Save("line_caps.pptx", SaveFormat.Pptx);
```

ผลลัพธ์ใน PowerPoint จากบนลงล่าง: **Flat**, **Round**, และ **Square**

![หัวเส้นแบบ Flat, Round, และ Square บนเส้นหนาเดียวกันใน PowerPoint](line-caps.png)

## **ใช้เอฟเฟกต์สเก็ตช์กับเส้นรูปร่าง**

เอฟเฟกต์สเก็ตช์ทำให้เส้นรูปร่างดูเหมือนเขียนด้วยมือ ใช้ [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) เพื่อเข้าถึงการตั้งค่าเส้น, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) เพื่อเข้าถึงการตั้งค่าสเก็ตช์, และ [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) เพื่อเลือกค่าจากตัวนับ [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/)

โค้ด C# ด้านล่างแสดงวิธีใช้เอฟเฟกต์ [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) อ่านค่าที่กำหนดโดยชัดเจน และลบเอฟเฟกต์ด้วย [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/):

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

var sketchFormat = shape.LineFormat.SketchFormat;
sketchFormat.SketchType = LineSketchType.Curved;
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
sketchFormat.SketchType = LineSketchType.None;
```

ค่าที่คืนจาก [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) แสดงการตั้งค่าที่กำหนดโดยตรงให้กับรูปร่าง หากการจัดรูปแบบเส้นสืบทอดมาจากธีม สไลด์มาสเตอร์ หรือสไลด์เลเยาต์ ให้ใช้ [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/), เข้าถึง [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/), และอ่านค่า [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/) ค่าที่มีประสิทธิภาพจะแสดงการจัดรูปแบบที่ใช้จริงหลังจากการสืบทอดถูกแก้ไข ตัวอย่างนี้ต้องการงานนำเสนอที่มีรูปร่างอย่างน้อยหนึ่งรูปบนสไลด์แรกและพิมพ์ค่าทั้งสอง:

```csharp
using System;
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

## **จัดรูปแบบสไตล์การเชื่อมต่อ (Join Styles)**

นี่คือสามตัวเลือกของประเภทการเชื่อมต่อ:

* Round
* Miter
* Bevel

สไตล์การเชื่อมต่อควบคุมว่าจุดขอบสองส่วนมาพบกันอย่างไรที่มุม ใช้ **Round** สำหรับมุมโค้ง, **Miter** สำหรับมุมคม, หรือ **Bevel** สำหรับมุมตัดราบ

![สไตล์การเชื่อมต่อในงานนำเสนอ](join-style-powerpoint.png)

ตัวอย่างนี้สร้างสี่เหลี่ยมสีดำสามรูปที่มีเส้นขอบสีน้ำเงินความกว้าง 15 จุด มันตั้งค่า [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) ให้เป็นค่ามิตเตอร์, เบเวล, และรันของ [LineJoinStyle](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/) ตามลำดับ เพื่อเปรียบเทียวนำมุมที่วาดอย่างไร

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var miterShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
var bevelShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
var roundShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

miterShape.FillFormat.FillType = FillType.Solid;
miterShape.FillFormat.SolidFillColor.Color = Color.Black;
bevelShape.FillFormat.FillType = FillType.Solid;
bevelShape.FillFormat.SolidFillColor.Color = Color.Black;
roundShape.FillFormat.FillType = FillType.Solid;
roundShape.FillFormat.SolidFillColor.Color = Color.Black;

miterShape.LineFormat.Width = 15;
bevelShape.LineFormat.Width = 15;
roundShape.LineFormat.Width = 15;

miterShape.LineFormat.FillFormat.FillType = FillType.Solid;
miterShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
bevelShape.LineFormat.FillFormat.FillType = FillType.Solid;
bevelShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
roundShape.LineFormat.FillFormat.FillType = FillType.Solid;
roundShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

miterShape.LineFormat.JoinStyle = LineJoinStyle.Miter;
bevelShape.LineFormat.JoinStyle = LineJoinStyle.Bevel;
roundShape.LineFormat.JoinStyle = LineJoinStyle.Round;

miterShape.TextFrame.Text = "Miter Join Style";
bevelShape.TextFrame.Text = "Bevel Join Style";
roundShape.TextFrame.Text = "Round Join Style";

presentation.Save("join_styles.pptx", SaveFormat.Pptx);
```

### **จำกัดการเชื่อมต่อ Miter ที่มุมคม**

ใช้ [ILineFormat.MiterLimit](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/miterlimit/) ร่วมกับ [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) ที่ตั้งเป็น [LineJoinStyle.Miter](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/) เพื่อจำกัดระยะที่มุมคมสามารถยื่นออกไปได้

ขีดจำกัดเป็นอัตราส่วนของระยะห่างระหว่างมุมในและมุมนอกของการเชื่อมต่อต่อความกว้างของเส้น ตัวอย่างเช่น ค่า `8` อนุญาตให้ความยาวมิตเตอร์ยาวได้สูงถึงแปดเท่าความกว้างของเส้น; ไม่ได้เป็นหน่วยจุด หากมุมเกินขีดจำกัด PowerPoint จะใช้การเชื่อมต่อแบบเบเวลที่มุมนั้น ขีดจำกัดที่ใหญ่ขึ้นทำให้จุดคมมากขึ้น การตั้งค่านี้ส่งผลต่อการเชื่อมต่อแบบมิตเตอร์เท่านั้น และการเปลี่ยนแปลงจะไม่มีผลต่อการแสดงผลเมื่อมุมยังคงอยู่ภายในขีดจำกัดทั้งสอง

ตัวอย่างนี้สร้างสามเหลี่ยมไม่มีการเติมสีสองรูปที่เส้นขอบกว้าง 20 จุด สามเหลี่ยมด้านซ้ายใช้ขีดจำกัด `2` ส่วนขวาใช้ `8` แต่ละสามเหลี่ยมกว้าง 80 จุด สูง 160 จุด ทำให้มุมบนมีอัตราส่วนความยาวมิตเตอร์ต่อความกว้างของเส้นประมาณ `4.12` ดังนั้น PowerPoint จะทำเบเวลที่ยอดซ้ายและรักษายอดขวาให้คม

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(500, 320, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var miterLimits = new[] { 2f, 8f };

for (var i = 0; i < miterLimits.Length; i++)
{
    var triangle = slide.Shapes.AddAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
    triangle.FillFormat.FillType = FillType.NoFill;
    triangle.LineFormat.Width = 20;
    triangle.LineFormat.FillFormat.FillType = FillType.Solid;
    triangle.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    triangle.LineFormat.JoinStyle = LineJoinStyle.Miter;
    triangle.LineFormat.MiterLimit = miterLimits[i];
}

presentation.Save("miter_limits.pptx", SaveFormat.Pptx);
```

ผลลัพธ์ใน PowerPoint: **Miter limit 2** ด้านซ้ายและ **miter limit 8** ด้านขวา

![ยอดที่เบเวลด้วยมิตเตอร์ลิมิต 2 และยอดที่คมด้วยมิตเตอร์ลิมิต 8 ใน PowerPoint](miter-limits.png)

## **การเติมสีไล่ระดับ (Gradient Fill)**

การเติมสีไล่ระดับจะผสมสีทั่วรูปร่าง ตัวอย่างนี้เติมรูปวงรีด้วยไล่ระดับเชิงเส้นที่มุม 45 องศาจากสีแดงไปสีม่วงโดยใช้ [IFillFormat.GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/gradientformat/) วิธี [IGradientStopCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/igradientstopcollection/add/) จะวางจุดหยุดสีที่ 0 และ 1 ซึ่งคือจุดเริ่มต้นและจุดสิ้นสุดของการไล่สี การลบจุดหยุดที่มีอยู่จะทำให้ใช้สีสองสีนี้เท่านั้น

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
shape.FillFormat.GradientFormat.LinearGradientAngle = 45;
shape.FillFormat.GradientFormat.GradientStops.Clear();
shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![วงรีที่เติมด้วยไล่ระดับสี](gradient-fill.png)

หากไล่ระดับสีแสดงผลต่างกันในภาพที่ส่งออกเทียบกับ PowerPoint ดูที่ [Choose a Gradient Rendering Style](/slides/th/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) คุณสามารถเลือกสไตล์การเรนเดอร์โดยไม่ต้องเปลี่ยนการเติมไล่ระดับที่เก็บไว้ในงานนำเสนอ

### **กำหนดมุมของไล่ระดับเชิงเส้น**

ใช้ [IGradientFormat.LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/) เพื่อควบคุมการวางแนวของการเติม [GradientShape.Linear](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/) มุมวัดเป็นองศาและเพิ่มตามเข็มนาฬิกา: `0` จากซ้ายไปขวา, `90` จากบนลงล่าง, `180` จากขวาไปซ้าย, `270` จากล่างขึ้นบน มุมทศนิยมก็รองรับ มุมที่อยู่นอกช่วง `[0, 360)` จะทำให้เป็นหนึ่งรอบ เช่น `-45` กลายเป็น `315` และ `360` กลายเป็น `0`

ตัวอย่างนี้สร้างสารางหกรูปที่มีจุดหยุดสีแดง, เขียว, น้ำเงินเดียวกันที่ตำแหน่ง `0`, `0.5`, และ `1` การสเกลถูกปิดเพื่อให้เปรียบเทียบมุมโดยไม่ต้องคำนึงถึงอัตราส่วนของสาราง มุมจากซ้ายไปขวาในแถวแรกคือ `0`, `45`, `90` และในแถวที่สองคือ `135`, `180`, `270`

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var angles = new float[] { 0, 45, 90, 135, 180, 270 };

for (var i = 0; i < angles.Length; i++)
{
    var x = 30 + (i % 3) * 230;
    var y = 30 + (i / 3) * 190;

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 200, 150);
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.FillFormat.FillType = FillType.Gradient;

    var gradient = shape.FillFormat.GradientFormat;
    gradient.GradientShape = GradientShape.Linear;
    gradient.GradientStops.Clear();
    gradient.GradientStops.Add(0f, Color.Red);
    gradient.GradientStops.Add(0.5f, Color.Lime);
    gradient.GradientStops.Add(1f, Color.Blue);
    gradient.LinearGradientScaled = NullableBool.False;
    gradient.LinearGradientAngle = angles[i];
}

presentation.Save("linear_gradient_angles.pptx", SaveFormat.Pptx);
```

ผลลัพธ์ใน PowerPoint:

![ไล่ระดับเชิงเส้นที่ 0°, 45°, 90° ในแถวบนและ 135°, 180°, 270° ในแถวล่าง](linear-gradient-angles.png)

### **สเกลไล่ระดับเชิงเส้นตามรูปร่าง**

[IGradientFormat.LinearGradientScaled](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientscaled/) รับค่า [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) ตั้งค่าเป็น `False` อย่างชัดเจนเพื่อให้มุมไล่ระดับเรขาคณิตคงที่เมื่อตัวรูปร่างเปลี่ยนอัตราส่วน, หรือเป็น `True` เพื่อสเกลไล่ระดับตามความกว้างและความสูงของรูปร่าง เมื่อเปิดสเกลมุมที่มองเห็นอาจต่างจากมุมที่กำหนดเมื่อรูปร่างไม่เป็นสี่เหลี่ยมจัตุรัส

ตัวอย่างต่อไปนี้ใช้มุม `45` องศาและจุดหยุดสีเดียวกับการเปรียบเทียบมุม คอลัมน์ซ้ายตั้งค่า `False`; คอลัมน์ขวาตั้งค่า `True` แต่ละคอลัมน์มีสารางกว้างเหนือสารางสูง ทั้งสองเริ่มจากขนาดกว้างเดียวกัน; การเปลี่ยนความกว้างและความสูงของสารางที่สองแสดงว่าการเติมสีตอบสนองต่อการปรับขนาดโดยไม่ต้องเปลี่ยนการตั้งค่าไล่ระดับ

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 460, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var scalingOptions = new[] { NullableBool.False, NullableBool.True };

for (var column = 0; column < scalingOptions.Length; column++)
{
    for (var row = 0; row < 2; row++)
    {
        var x = 30 + column * 360;
        var y = row == 0 ? 30 : 150;
        
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 300, 90);
        shape.LineFormat.FillFormat.FillType = FillType.NoFill;
        shape.FillFormat.FillType = FillType.Gradient;

        var gradient = shape.FillFormat.GradientFormat;
        gradient.GradientShape = GradientShape.Linear;
        gradient.GradientStops.Clear();
        gradient.GradientStops.Add(0f, Color.Red);
        gradient.GradientStops.Add(0.5f, Color.Lime);
        gradient.GradientStops.Add(1f, Color.Blue);
        gradient.LinearGradientAngle = 45;
        gradient.LinearGradientScaled = scalingOptions[column];

        if (row == 1)
        {
            shape.Width = 90;
            shape.Height = 280;
        }
    }
}

presentation.Save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
```

ผลลัพธ์ใน PowerPoint, สเกลปิดที่ซ้ายและเปิดที่ขวา:

![สารางกว้างและสารางสูงที่มีไล่ระดับ 45°, เปรียบเทียบ LinearGradientScaled False ทางซ้ายกับ True ทางขวา](linear-gradient-scaling.png)

เมื่อสเกลปิด แถบสีทแยงมุมยังคงทิศทางเดิมในทั้งสองสาราง เมื่อสเกลเปิด แถบสีจะยืดตามอัตราส่วนของรูปร่าง สิ่งนี้ช่วยให้ทำสำเนาไล่ระดับของแม่แบบเมื่อปรับขนาดรูปร่างให้ต่างกันบนสี่เหลี่ยมจัตุรัส การเปิดสเกลบนสี่เหลี่ยมจัตุรัสจะไม่เปลี่ยนลักษณะของไล่ระดับ `45` องศานี้

ทั้งมุมและการตั้งค่าสเกลใช้ได้เฉพาะไล่ระดับเชิงเส้น ไม่ควบคุมการเติมแบบ [GradientShape.Radial หรือ GradientShape.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/)

### **รวมมุมกับทิศทางของไล่ระดับ**

[IGradientFormat.GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/gradientdirection/) เลือกรูปแบบไล่ระดับจากตัวนับ [GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/gradientdirection/) ซึ่งไม่ใช่การทดแทนมุมเชิงตัวเลข สำหรับไล่ระดับเชิงเส้น สไตล์มุมสามารถเปลี่ยนพื้นที่ที่สีกระจายโดยไม่ต้องเปลี่ยน [LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/) รักษาทิศทางคงที่เมื่อต้องการเปรียบเทียบมุมหรือสเกล

ตัวอย่างต่อไปนี้นำการตั้งค่าเดียวกันมาใช้ในลำดับตรงข้าม สารางสองรูปมีลักษณะเหมือนกัน: การกำหนดทิศทางก่อนหรือหลังมุมไม่ทำให้ผลลัพธ์เปลี่ยน

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

for (var i = 0; i < 2; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.FillFormat.FillType = FillType.Gradient;

    var gradient = shape.FillFormat.GradientFormat;
    gradient.GradientShape = GradientShape.Linear;
    gradient.GradientStops.Clear();
    gradient.GradientStops.Add(0f, Color.Red);
    gradient.GradientStops.Add(0.5f, Color.Lime);
    gradient.GradientStops.Add(1f, Color.Blue);
    gradient.LinearGradientScaled = NullableBool.True;

    if (i == 0)
    {
        gradient.GradientDirection = GradientDirection.FromCorner1;
        gradient.LinearGradientAngle = 30;
    }
    else
    {
        gradient.LinearGradientAngle = 30;
        gradient.GradientDirection = GradientDirection.FromCorner1;
    }
}

presentation.Save("linear_gradient_direction.pptx", SaveFormat.Pptx);
```

## **การเติมแบบลาย (Pattern Fill)**

การเติมแบบลายใช้การออกแบบสองสี เช่น จุด, แถบ, หรือ เช็ค ตัวอย่างนี้ใช้ [IPatternFormat.PatternStyle](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/patternstyle/) เพื่อเลือกลาย trellis. [IPatternFormat.BackColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) ให้พื้นหลังสีเทาอ่อน, และ [IPatternFormat.ForeColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) ให้สีเหลืองของลาย

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Pattern;
shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;
shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![สี่เหลี่ยมที่เติมด้วยลาย](pattern-fill.png)

## **การเติมภาพ (Picture Fill)**

การเติมภาพใช้รูปภาพภายในรูปร่าง ตัวอย่างนี้ต้องการรูปภาพโล컬และใช้ [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) โหลดเข้าคอลเลกชันภาพของงานนำเสนอ ตั้งค่า [IPictureFillFormat.PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) เป็นโหมด tiled เพื่อทำซ้ำภาพภายในสี่เหลี่ยม ภาพต้นแบบที่ใช้แสดงด้านล่าง:

![รูปภาพ lotus](lotus.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

using var image = Images.FromFile("lotus.png");
var presentationImage = presentation.Images.AddImage(image);
shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![รูปร่างที่เติมด้วยภาพ](picture-fill.png)

### **ทำให้ภาพเป็น Texture แบบ Tile**

หากต้องการตั้งค่าภาพที่ทำซ้ำเป็น texture และปรับพฤติกรรมการทำซ้ำ คุณสามารถใช้คุณสมบัติต่อไปนี้ของอินเทอร์เฟซ [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) และคลาส [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) :

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): ตั้งโหมดการเติมภาพ—`Tile` หรือ `Stretch`
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): ระบุตำแหน่งการจัดเรียงของไทล์ภายในรูปร่าง
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): ควบคุมว่าทำการพลิกไทล์แนวนอน แนวตั้ง หรือทั้งสองอย่าง
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): ตั้งค่าออฟเซ็ตแนวนอนของไทล์ (หน่วย points) จากจุดกำเนิดของรูปร่าง
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): ตั้งค่าออฟเซ็ตแนวตั้งของไทล์ (หน่วย points) จากจุดกำเนิดของรูปร่าง
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): กำหนดสเกลแนวนอนของไทล์เป็นเปอร์เซ็นต์
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): กำหนดสเกลแนวตั้งของไทล์เป็นเปอร์เซ็นต์

ตัวอย่างนี้ต้องการภาพโล컬และกำหนดค่า [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) ให้ทำซ้ำที่ขนาด 50% ของขนาดต้นแบบ การออฟเซ็ต `−32` จุดทำให้ไทล์เลื่อนไปแนวนอนและแนวตั้ง; การจัดตำแหน่งด้านล่างขวาและการพลิกทั้งสองทิศกำหนดวิธีการจัดเรียง texture ที่ทำซ้ำ

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];

var shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
shape.FillFormat.FillType = FillType.Picture;

using var sourceImage = Images.FromFile("lotus.png");
var presentationImage = presentation.Images.AddImage(sourceImage);

var pictureFillFormat = shape.FillFormat.PictureFillFormat;
pictureFillFormat.Picture.Image = presentationImage;
pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
pictureFillFormat.TileOffsetX = -32;
pictureFillFormat.TileOffsetY = -32;
pictureFillFormat.TileScaleX = 50;
pictureFillFormat.TileScaleY = 50;
pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
pictureFillFormat.TileFlip = TileFlip.FlipBoth;

presentation.Save("tile.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![ตัวเลือกการทำ Tile](tile-options.png)

## **การเติมสีทึบ (Solid Color Fill)**

การเติมสีทึบทำให้รูปร่างมีสีเดียวสม่ำเสมอ ตัวอย่างนี้ตั้งค่า [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) เป็นโหมดเติมสีทึบและกำหนดสีเหลืองผ่าน [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) แล้วบันทึกสี่เหลี่ยมในงานนำเสนอ

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Yellow;

presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![รูปร่างที่เติมสีทึบ](solid-color-fill.png)

## **ใช้พื้นหลังสไลด์เป็นการเติมรูปร่าง**

ใช้ [IAutoShape.UseBackgroundFill](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/usebackgroundfill/) เมื่อรูปร่างควรตรงกับพื้นหลังสไลด์ เช่น ในแม่แบบงานนำเสนอ ตั้งค่า [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) เป็น [FillType.NotDefined](https://reference.aspose.com/slides/net/aspose.slides/filltype/) ก่อนเพื่อเอาการเติมสีที่ชัดเจนออก ด้วยการผสมนี้รูปร่างจะใช้พื้นหลังสไลด์แทนการเติมสไตล์ของมันเอง การเปิดค่าสถานะเพียงอย่างเดียวไม่ทำให้การเติมสีที่ชัดเจนที่มีอยู่หายไป

สิ่งนี้แตกต่างจาก [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/): การเติมพื้นหลังจะคลุมวัตถุที่อยู่หลังรูปร่างด้วยพื้นที่พื้นหลังสไลด์ที่สอดคล้องกัน ส่วน NoFill จะทำให้วัตถุเหล่านั้นมองเห็นได้ การไล่ระดับยังคงจัดตำแหน่งกับสไลด์แทนที่จะเริ่มใหม่ภายในแต่ละรูปร่าง

ตัวอย่างต่อไปนี้สร้างพื้นหลังมาสเตอร์ที่สไลด์สืบทอดและวางแถบสีม่วงแดงอยู่ด้านหลังสามสี่เหลี่ยม สี่เหลี่ยมซ้ายใช้พื้นหลัง, สี่เหลี่ยมกลางไม่มีการเติมสี, และสี่เหลี่ยมขวาเปลี่ยนจากการเติมพื้นหลังเป็นการเติมสีส้มที่ชัดเจน

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

// สืบทอดไล่ระดับจากมาสเตอร์.
slide.Background.Type = BackgroundType.NotDefined;
slide.LayoutSlide.Background.Type = BackgroundType.NotDefined;
var background = slide.LayoutSlide.MasterSlide.Background;
background.Type = BackgroundType.OwnBackground;
background.FillFormat.FillType = FillType.Gradient;
var gradient = background.FillFormat.GradientFormat;
gradient.GradientShape = GradientShape.Linear;
gradient.LinearGradientAngle = 0;
gradient.GradientStops.Clear();
gradient.GradientStops.Add(0, Color.DarkBlue);
gradient.GradientStops.Add(1, Color.LightSkyBlue);

// เพิ่มวัตถุนี้ก่อนเพื่อให้แสดงอยู่ด้านหลังสี่เหลี่ยม.
var band = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.Magenta;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var backgroundShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
backgroundShape.FillFormat.FillType = FillType.NotDefined;
backgroundShape.UseBackgroundFill = true;

var noFillShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
noFillShape.FillFormat.FillType = FillType.NoFill;

var explicitShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
explicitShape.FillFormat.FillType = FillType.NotDefined;
explicitShape.UseBackgroundFill = true;

// ปิดการเติมพื้นหลังก่อนที่จะกำหนดการเติมแบบชัดเจน.
explicitShape.UseBackgroundFill = false;
explicitShape.FillFormat.FillType = FillType.Solid;
explicitShape.FillFormat.SolidFillColor.Color = Color.Orange;

presentation.Save("background_fill.pptx", SaveFormat.Pptx);
```

ผลลัพธ์จากซ้ายไปขวา: **การเติมพื้นหลัง**, **ไม่มีการเติมสี**, และ **การเติมสีที่ชัดเจน** แถบสีม่วงแดงถูกซ่อนโดยสี่เหลี่ยมซ้ายและขวาแต่ยังคงมองเห็นผ่านสี่เหลี่ยมกลาง

![การเติมพื้นหลัง, ไม่มีการเติมสี, และการเติมสีส้มชัดเจนบนแถบสีม่วงแดง](background-fill.png)

พฤติกรรมเดียวกันใช้กับพื้นหลังที่กำหนดโดยตรงบนสไลด์หรือสืบทอดจากเลเอาต์ รูปร่างจะใช้พื้นหลังที่แก้ไขแล้วของสไลด์; ตัวอย่างนี้ไม่ได้กำหนดพื้นหลังของสไลด์และเลเอาต์เพื่อให้มาสเตอร์เป็นผู้ให้ค่าพื้นหลัง

## **ตั้งค่าความโปร่งใส (Transparency)**

สำหรับการเติมสีทึบ ส่วนประกอบ alpha ของสีจะควบคุมความทึบ: 0 คือโปร่งใสเต็มที่และ 255 คือทึบเต็มที่ ตัวอย่างนี้ใช้ค่า alpha 128 สำหรับสี่เหลี่ยมสีเหลือง ทำให้โปร่งใสประมาณ 50% เพื่อให้สี่เหลี่ยมด้านล่างยังมองเห็นอยู่ สีถูกกำหนดผ่าน [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/)

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

var transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
transparentShape.FillFormat.FillType = FillType.Solid;
transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![รูปร่างที่โปร่งใส](shape-transparency.png)

## **หมุนรูปร่าง (Rotate Shapes)**

ใช้ [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) เพื่อหมุนรูปร่างในระนาบสไลด์ มุมวัดเป็นองศา; ตัวอย่างนี้หมุนสี่เหลี่ยม 5 องศาในเข็มนาฬิกาและบันทึกงานนำเสนอ

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.Rotation = 5;

presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![การหมุนรูปร่าง](shape-rotation.png)

## **เพิ่มเอฟเฟกต์ Bevel 3 มิติ**

ใช้ [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/) เพื่อให้รูปร่างมีความลึกและขอบ bevel ตัวอย่างนี้สร้างวงรีสีเขียวที่มีเส้นขอบสีส้ม ตั้งค่า [IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/depth/) เป็น 4 จุดและใช้ bevel บนด้านบนแบบวงกลมที่กว้างและสูง 6 จุดผ่าน [IThreeDFormat.BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/beveltop/) กล้องแบบออร์โธกราฟิกที่มองหน้าและแสงสามจุดทำให้ bevel มองเห็นได้

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Green;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.Width = 2.0;
shape.ThreeDFormat.Depth = 4;
shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
shape.ThreeDFormat.BevelTop.Height = 6;
shape.ThreeDFormat.BevelTop.Width = 6;
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![เอฟเฟกต์ bevel 3 มิติ](3D-bevel-effect.png)

## **เพิ่มเอฟเฟกต์การหมุน 3 มิติ**

มุมมอง 3 มิติของรูปร่างถูกควบคุมโดยการตั้งค่ากล้อง ตัวอย่างนี้ใช้ [ICamera.SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/) ตั้งค่ามุมละติจูด, ลองจิจูด, และรอบการหมุนเป็น 40, 35, และ 20 องศาตามลำดับ เลือกกล้องแบบ isometric ผ่าน [ICamera.CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) และแสงแบบ balanced ผ่าน [ILightRig.LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/) แล้วบันทึกสี่เหลี่ยมที่จัดรูปแบบ

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
autoShape.TextFrame.Text = "Hello, Aspose!";
autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![เอฟเฟกต์การหมุน 3 มิติ](3D-rotation-effect.png)

## **ควบคุมการเรนเดอร์สีขาว-ดำสำหรับรูปร่าง**

คุณสมบัติ [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) ระบุว่ารูปร่างแต่ละอันจะเรนเดอร์อย่างไรเมื่อดูหรือประมวลผลงานนำเสนอในโหมดสีขาว-ดำ มันไม่ได้เปิดการแสดงผลสีขาว-ดำด้วยตัวเองและไม่ได้เปลี่ยนการเติมสี, เส้น, หรือการจัดรูปแบบอื่น ๆ ของรูปร่างในโหมดสีปกติ

ใช้ค่าจากตัวนับ [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) เพื่อเลือกพฤติกรรมที่ต้องการ ตัวอย่างเช่น `Automatic` ให้แอปพลิเคชันเรนเดอร์เลือกการแปลง, `Gray` และ `LightGray` ใช้สีเทา, `BlackWhite` ใช้สีดำและขาวเท่านั้น, `Black` และ `White` บังคับให้เป็นสีเดียว, `Color` คงสีปกติ, และ `Hidden` ไม่แสดงรูปร่างในโหมดสีขาว-ดำ `NotDefined` หมายถึงไม่ได้กำหนดโหมดระดับรูปร่าง

ตัวอย่างนี้สร้างสี่เหลี่ยมสีส้มและตั้งค่า [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) ให้เป็นสีเทา รูปร่างที่บันทึกจะคงสีส้มสำหรับการแสดงผลสีปกติและร้องขอการแสดงสีเทาในแอปพลิเคชันที่เคารพการตั้งค่าแสดงผลสีขาว-ดำ

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

ในโหมดสีปกติ สี่เหลี่ยมคงสีส้มไว้ ในกระบวนการแสดงผลสีขาว-ดำ จะใช้สีเทาเพราะโหมดตั้งเป็น `Gray` สิ่งนี้ทำให้คุณคงสไลด์สีเต็มในขณะที่กำหนดลักษณะการแสดงผลที่แตกต่างสำหรับการพิมพ์, ตัวอย่าง preview, หรือกระบวนการอื่นที่เคารพการตั้งค่าแสดงผลสีขาว-ดำของงานนำเสนอ

## **รีเซ็ตการจัดรูปแบบ (Reset Formatting)**

ใช้ [ISlide.Reset](https://reference.aspose.com/slides/net/aspose.slides/islide/reset/) เพื่อกู้คืนตำแหน่ง, ขนาด, และการจัดรูปแบบของตัวตำแหน่งของสไลด์จากตำแหน่งในเลเอาต์ที่สอดคล้องกัน ตัวอย่างนี้ต้องมีงานนำเสนอที่มีตัวตำแหน่งเชื่อมโยงกับเลเอาต์และรีเซ็ตทุกสไลด์ก่อนบันทึก รูปร่างที่ไม่มีตำแหน่งที่สอดคล้องกับเลเอาต์จะไม่ถูกรีเซ็ต

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
foreach (var slide in presentation.Slides)
{
    slide.Reset();
}

presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
```

## **FAQ**

**การจัดรูปแบบรูปร่างมีผลต่อขนาดไฟล์งานนำเสนอสุดท้ายหรือไม่?**

สี, รูปแบบเส้น, และการตั้งค่าเอฟเฟกต์มักเพิ่มข้อมูลเพียงเล็กน้อยเมื่อเทียบกับภาพและสื่อที่ฝังอยู่ การเติมภาพสามารถเพิ่มขนาดไฟล์ได้เนื่องจากภาพถูกเก็บในงานนำเสนอ

**ฉันจะตรวจจับรูปร่างบนสไลด์ที่มีการจัดรูปแบบเดียวกันเพื่อทำการจัดกลุ่มได้อย่างไร?**

เปรียบเทียบคุณสมบัติการจัดรูปแบบหลักของแต่ละรูปร่าง—การเติมสี, เส้น, และการตั้งค่าเอฟเฟกต์ หากค่าทั้งหมดตรงกัน ให้นับสไตล์ของพวกมันว่าเหมือนกันและจัดกลุ่มตรรกะเพื่อความง่ายในการจัดการสไตล์ในภายหลัง

**ฉันสามารถบันทึกชุดสไตล์รูปร่างแบบกำหนดเองเป็นไฟล์แยกเพื่อใช้งานซ้ำในงานนำเสนออื่นได้หรือไม่?**

ได้. เก็บรูปร่างตัวอย่างที่มีสไตล์ที่ต้องการในสไลด์เทมเพลตหรือไฟล์เทมเพลต .POTX เมื่อสร้างงานนำเสนอใหม่, เปิดเทมเพลต, คัดลอกรูปร่างที่สไตล์แล้วและนำไปใช้ใหม่ตามต้องการ