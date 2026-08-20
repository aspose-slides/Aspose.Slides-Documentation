---
title: จัดการรูปร่างการนำเสนอใน .NET
linktitle: การจัดการรูปร่าง
type: docs
weight: 40
url: /th/net/shape-manipulations/
keywords:
- รูปร่าง PowerPoint
- รูปร่างการนำเสนอ
- รูปร่างบนสไลด์
- ค้นหารูปร่าง
- ทำสำเนารูปร่าง
- ลบรูปร่าง
- ซ่อนรูปร่าง
- เปลี่ยนลำดับรูปร่าง
- รับ ID รูปร่าง Interop
- ข้อความแทนรูปร่าง
- รูปแบบเลย์เอาต์ของรูปร่าง
- รูปร่างเป็น SVG
- แปลงรูปร่างเป็น SVG
- จัดแนวรูปร่าง
- พลิกรูปร่าง
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีระบุ, ทำสำเนา, ลบ, ซ่อน, จัดลำดับใหม่, ส่งออก, จัดแนว, และพลิกรูปร่างการนำเสนอด้วย Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

Aspose.Slides for .NET แสดงรูปร่างบนสไลด์เป็นลำดับของ [IShapeCollection](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/) คอลเลกชันนี้เป็นทั้งที่ที่คุณค้นหาและแก้ไขรูปร่างและเป็นแหล่งของลำดับการซ้อนกัน: ดัชนี `0` คือรูปร่างที่อยู่ด้านหลังสุด ส่วนดัชนีสุดท้ายคือรูปร่างที่อยู่ด้านหน้าสุด

บทความนี้อ้างอิงตามโมเดลนั้น ก่อนอื่นอธิบายวิธีระบุตัวรูปร่างอย่างมั่นคง จากนั้นแสดงวิธีทำสำเนา, ลบ, ซ่อนและจัดลำดับใหม่ของรูปร่าง ส่วนสุดท้ายครอบคลุมการจัดรูปแบบระดับเลย์เอาต์, การส่งออกเป็น SVG, การจัดแนวและการตั้งค่าการพลิก รูปแบบแต่ละตัวอย่างเป็นอิสระกัน ดังนั้นคุณสามารถใช้เฉพาะการดำเนินการที่เวิร์กโฟลว์ของคุณต้องการ

## **ระบุตัวและค้นหารูปร่าง**

ดัชนีของคอลเลกชันสะดวกเมื่อต้องประมวลผลไฟล์ที่รู้จัก แต่ไม่ได้เป็นตัวระบุที่คงที่ การเพิ่ม, ลบ หรือจัดลำดับใหม่ของรูปร่างอาจทำให้ดัชนีเปลี่ยน เลือกตัวระบุตามวิธีการสร้างและการดูแลพรีเซนเทชัน:

- [Name](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/name/) มีประโยชน์สำหรับเทมเพลตที่ควบคุมโดยนักพัฒนาและสามารถตรวจสอบได้ง่ายใน Selection Pane ของ PowerPoint ชื่อสามารถแก้ไขได้และไม่ได้รับประกันว่าจะยูนีค ดังนั้นจึงควรกำหนดกฎการตั้งชื่อหากโค้ดพึ่งพา
- [AlternativeText](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/alternativetext/) มีประโยชน์เมื่อคำอธิบายการเข้าถึงหรือแท็กที่ผู้เขียนใส่ไว้ได้ระบุตัวรูปร่างแล้ว มันมองเห็นได้โดยผู้ใช้, อาจแปลหรือเขียนใหม่เพื่อการเข้าถึง, และไม่ได้รับประกันว่าจะยูนีค อย่าใช้ข้อความการเข้าถึงที่มีความหมายเป็นคีย์ฐานข้อมูลโดยไม่ได้แจ้งให้ผู้ใช้ทราบ
- [OfficeInteropShapeId](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/officeinteropshapeid/) เป็นตัวระบุแบบอ่านอย่างเดียวที่ยูนีคภายในสไลด์และสอดคล้องกับ Shape ID ที่ PowerPoint interop ใช้ ใช้เมื่อต้องทำการบูรณาการกับ PowerPoint หรือเมื่อต้องการอ้างอิงที่ชัดเจนตลอดอายุของรูปร่าง รูปร่างที่ทำสำเนาหรือสร้างใหม่จะเป็นรูปร่างที่แตกต่างและจะได้รับ ID ของตัวเอง

คุณสมบัติ [UniqueId](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/uniqueid/) ที่เกี่ยวข้องมีขอบเขตระดับพรีเซนเทชัน แต่ถูกออกแบบมาสำหรับแอดอินและสามารถกำหนดค่าใหม่ได้ ไม่ควรถือเป็นคีย์ภายนอกถาวร หากต้องการการระบุตัวตนระยะยาว ให้เก็บการแมปในข้อมูลของแอปพลิเคชันและตรวจสอบว่ารูปร่างที่คาดหวังยังคงมีอยู่

ตัวอย่างต่อไปนี้ค้นหาโดย `Name` ด้วยการเปรียบเทียบเชิงลำดับและรายงาน ID interop ที่มีขอบเขตสไลด์ เมื่อเทมเพลตไม่มีรูปร่างที่คาดหวัง โค้ดจะแจ้งผลนั้นแทนที่จะดำเนินต่อด้วยออบเจ็กต์ที่ผิดพลาด

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? targetShape = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "RevenueChart", StringComparison.Ordinal))
    {
        targetShape = shape;
        break;
    }
}

if (targetShape is null)
{
    Console.WriteLine("The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console.WriteLine($"Found {targetShape.Name}; interop ID: {targetShape.OfficeInteropShapeId}");
}
```

เมื่อการดำเนินการจำเพาะกับประเภทของรูปร่าง ให้ตรวจสอบอินเตอร์เฟสก่อนใช้สมาชิกที่เฉพาะเจาะจงกับประเภท ตัวอย่างนี้อัปเดตข้อความและข้อความทางเลือกเฉพาะเมื่อออบเจ็กต์ที่มีชื่อเป็น [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/)

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? candidate = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "StatusLabel", StringComparison.Ordinal))
    {
        candidate = shape;
        break;
    }
}

if (candidate is IAutoShape autoShape)
{
    autoShape.TextFrame.Text = "Approved";
    autoShape.AlternativeText = "Approval status: approved";
    presentation.Save("identified-shape.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("'StatusLabel' is missing or is not an AutoShape.");
}
```

## **แก้ไขคอลเลกชันรูปร่าง**

เมธอดการเพิ่ม, ทำสำเนา, ลบและจัดลำดับใหม่ทำงานบนคอลเลกชันทันที หากการดำเนินการใดเปลี่ยนจำนวนหรือลำดับของรูปร่าง อย่าอ้างอิงดัชนีที่บันทึกไว้ก่อนการดำเนินการนั้นต่อไป

### **ทำสำเนารูปร่าง**

[AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/addclone/) สร้างสำเนาอิสระและเพิ่มลงในคอลเลกชันเป้าหมาย [InsertClone](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/insertclone/) ก็สร้างสำเนาเช่นกันแต่วางไว้ที่ดัชนี z‑order ที่ระบุ การโอเวอร์โหลดที่รับพิกัดจะย้ายสำเนาโดยไม่เปลี่ยนขนาด; การโอเวอร์โหลดที่รับความกว้างและความสูงจะสามารถปรับขนาดได้เช่นกัน

ตัวอย่างนี้สร้างสไลด์ปลายทาง, ทำสำเนาเรกทังเกิลที่มีป้ายกำกับไปยังด้านหน้า, และแทรกสำเนาที่สองไว้ที่ด้านหลัง การเปลี่ยนแปลงใด ๆ กับสำเนาใดสำเนาหนึ่งจะไม่กระทบรูปร่างต้นฉบับ

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var sourceSlide = presentation.Slides[0];
var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
sourceShape.Name = "SourceLabel";
sourceShape.TextFrame.Text = "Source";

var blankLayout = presentation.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
var destinationSlide = presentation.Slides.AddEmptySlide(blankLayout);

var frontCloneShape = destinationSlide.Shapes.AddClone(sourceShape, 80, 80);
frontCloneShape.Name = "FrontClone";
if (frontCloneShape is IAutoShape frontClone)
{
    frontClone.TextFrame.Text = "Front clone";
}
else
{
    Console.WriteLine("The front clone is not an AutoShape; its text was not changed.");
}

var backCloneShape = destinationSlide.Shapes.InsertClone(0, sourceShape, 80, 180);
backCloneShape.Name = "BackClone";
if (backCloneShape is IAutoShape backClone)
{
    backClone.TextFrame.Text = "Back clone";
}
else
{
    Console.WriteLine("The back clone is not an AutoShape; its text was not changed.");
}

presentation.Save("cloned-shapes.pptx", SaveFormat.Pptx);
```

การทำสำเนาจะคัดลอกเนื้อหาและการจัดรูปแบบของรูปร่างรวมถึงชื่อและข้อความทางเลือก กำหนดตัวระบุเชิงตรรกะใหม่ให้กับสำเนาเมื่อค่าดังกล่าวต้องยูนีค แหล่งทรัพยากรที่ใช้โดยรูปร่างซับซ้อนจะจัดการโดยพรีเซนเทชัน แต่สำเนาจะเป็นรายการใหม่ในคอลเลกชันพร้อมอัตลักษณ์รูปร่างใหม่

### **ลบรูปร่าง**

[Remove](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/remove/) ลบออบเจ็กต์รูปร่างเฉพาะจากคอลเลกชันของมัน เมื่อทำการลบหลายรายการขณะวนลูปโดยอิงดัชนี ให้วนจากท้ายเพื่อให้ดัชนีที่เหลือยังคงใช้ได้

ตัวอย่างนี้ลบทุกรูปร่างที่มีชื่อกำหนด มันอ่าน `slide.Shapes[i]` ไม่ใช่รายการคอลเลกชันคงที่ และไม่ได้ทำการคาสต์รูปร่างโดยไม่จำเป็น

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var keepShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
keepShape.Name = "Keep";

var firstTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
firstTemporaryShape.Name = "Temporary";

var secondTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
secondTemporaryShape.Name = "Temporary";

for (var i = slide.Shapes.Count - 1; i >= 0; i--)
{
    var shape = slide.Shapes[i];
    if (string.Equals(shape.Name, "Temporary", StringComparison.Ordinal))
    {
        slide.Shapes.Remove(shape);
    }
}

presentation.Save("removed-shapes.pptx", SaveFormat.Pptx);
```

หลังจากลบ จำนวนรูปร่างและดัชนีของรูปร่างที่ตามมาจะเปลี่ยน การอ้างอิงไปยังรูปร่างที่ไม่ได้รับผลกระทบจึงเชื่อถือได้มากกว่าดัชนีที่บันทึกไว้ อีกทั้งควรพิจารณา connector, animation และคุณลักษณะอื่น ๆ ของพรีเซนเทชันที่อาจอ้างอิงถึงออบเจ็กต์ที่ลบ; การลบรูปร่างที่มองเห็นได้อาจทำให้สิ่งที่ปรากฏบนสไลด์เปลี่ยนแปลงมากกว่าตัวรูปร่างเอง

### **ซ่อนรูปร่าง**

การตั้งค่า [Hidden](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/hidden/) เป็น `true` จะทำให้รูปร่างคงอยู่ในคอลเลกชันแต่ไม่ปรากฏในสไลด์โชว์ปกติ ดัชนี, การจัดรูปแบบและเนื้อหายังคงพร้อมให้โค้ดเข้าถึง จึงเหมาะกับองค์ประกอบที่เป็นตัวเลือกและอาจคืนค่ามาได้ในภายหลัง

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var visibleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
visibleShape.Name = "VisibleLabel";

var optionalShape = slide.Shapes.AddAutoShape(ShapeType.Moon, 240, 40, 100, 100);
optionalShape.Name = "OptionalDecoration";

foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "OptionalDecoration", StringComparison.Ordinal))
    {
        shape.Hidden = true;
    }
}

presentation.Save("hidden-shape.pptx", SaveFormat.Pptx);
```

การซ่อนไม่ได้หมายถึงการลบหรือความปลอดภัย อ็อบเจ็กต์ยังสามารถถูกค้นพบและยกเลิกการซ่อนโดยผู้ใช้หรือโดยโค้ด และยังคงเป็นส่วนหนึ่งของไฟล์พรีเซนเทชัน

### **เปลี่ยนลำดับ Z‑Order**

รูปร่างที่ซ้อนกันจะถูกวาดตามลำดับของคอลเลกชัน [Reorder](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/reorder/) ย้ายรูปร่างที่มีอยู่ไปยังดัชนีเป้าหมายโดยไม่ต้องทำสำเนา ดัชนี `0` คือด้านหลัง; `Count - 1` คือด้านหน้า

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var blueRectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
blueRectangle.Name = "BlueRectangle";
blueRectangle.FillFormat.FillType = FillType.Solid;
blueRectangle.FillFormat.SolidFillColor.Color = Color.SteelBlue;

var orangeEllipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
orangeEllipse.Name = "OrangeEllipse";
orangeEllipse.FillFormat.FillType = FillType.Solid;
orangeEllipse.FillFormat.SolidFillColor.Color = Color.Orange;

slide.Shapes.Reorder(slide.Shapes.Count - 1, blueRectangle);
presentation.Save("reordered-shapes.pptx", SaveFormat.Pptx);
```

เรกทังเกิลถูกสร้างขึ้นก่อนและโดยค่าเริ่มต้นอยู่หลังวงรี การย้ายมันไปยังดัชนีสุดท้ายจะทำให้มันอยู่ด้านหน้า สรุปลำดับ Z‑order หลังจากเพิ่มหรือทำสำเนารูปร่างที่เกี่ยวข้องทั้งหมด เพราะการดำเนินการเหล่านั้นจะเพิ่มหรือแทรกรายการใหม่ในคอลเลกชันและอาจเปลี่ยนสแต็กที่ต้องการ

## **ตรวจสอบรูปร่างบน Layout Slides**

สไลด์ปกติ, layout slides, และ master slides มีคอลเลกชันรูปร่างแยกกัน รูปร่างในคอลเลกชัน layout ไม่ใช่ออบเจ็กต์เดียวกับรูปร่างที่อยู่ในตำแหน่งเดียวกันบนสไลด์ปกติ ตรวจสอบรูปร่างใน layout เมื่อคุณต้องการเข้าใจหรือเปลี่ยนการจัดรูปแบบที่มาจาก layout

ตัวอย่างต่อไปนี้อ่าน [FillFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/fillformat/) และ [LineFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/lineformat/) ของแต่ละรูปร่างใน layout โดยไม่สมมติว่าทุกรูปร่างเป็น `AutoShape`

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var layoutSlide in presentation.LayoutSlides)
{
    foreach (var shape in layoutSlide.Shapes)
    {
        var fillType = shape.FillFormat.FillType;
        var lineWidth = shape.LineFormat.Width;
        Console.WriteLine($"{layoutSlide.Name} / {shape.Name}: fill={fillType}, line width={lineWidth}");
    }
}
```

การแก้ไข layout อาจส่งผลต่อหลายสไลด์ที่ใช้มัน ก่อนเปลี่ยนรูปร่างใน layout ให้ตรวจสอบว่าก่อนหน้าเป็นการสืบทอดจากสไลด์ปกติหรือมีการกำหนดค่าเฉพาะในระดับสไลด์ และทดสอบทุกสไลด์ที่ใช้ layout นั้น

## **ส่งออกรูปร่างเป็น SVG**

[WriteAsSvg](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/writeassvg/) เขียนเนื้อหาที่เรนเดอร์ของรูปร่างหนึ่งลงในสตรีม ผลลัพธ์จะมีเฉพาะรูปร่างนั้น ไม่รวมพื้นหลังสไลด์ทั้งหมดหรือรูปร่างใกล้เคียง

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes.Count == 0)
{
    Console.WriteLine("Slide 1 does not contain a shape to export.");
}
else
{
    var shape = slide.Shapes[0];
    using var svgStream = File.Create("shape.svg");
    shape.WriteAsSvg(svgStream);
}
```

ให้เปิดพรีเซนเทชันขณะทำการเรนเดอร์ ผลลัพธ์ขึ้นอยู่กับการจัดรูปแบบของรูปร่างและทรัพยากรเช่น ฟอนท์และรูปภาพ หากต้องการส่งออกทั้งคอมโพสชัน ให้ออกรายการสไลด์แทนการส่งออกรูปร่างเดียว ผู้เรียกต้องเป็นเจ้าของสตรีมและต้อง Dispose สตรีมนั้น

## **จัดแนวรูปร่าง**

เมธอด [SlideUtil.AlignShapes](https://reference.aspose.com/slides/th/net/aspose.slides.util/slideutil/alignshapes/) มีการโอเวอร์โหลดที่จัดแนวทั้งกลุ่มหรือดัชนีที่เลือกในคอลเลกชัน [ShapesAlignmentType](https://reference.aspose.com/slides/th/net/aspose.slides/shapesalignmenttype/) ระบุขอบ, เส้นศูนย์กลางหรือโหมดการกระจาย ตั้งค่า `alignToSlide` เป็น `true` เพื่อใช้ขอบสไลด์; ตั้งค่าเป็น `false` เพื่อจัดแนวรูปร่างที่เลือกสัมพันธ์กัน

ตัวอย่างนี้จัดแนวสามรูปร่างให้ชิดด้านบนของสไลด์ การอ้างอิงรูปร่างที่คืนค่าจะถูกแปลงเป็นดัชนีปัจจุบันทันทีก่อนทำการจัดแนว

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
var thirdShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
firstShape.Name = "FirstAlignedShape";
secondShape.Name = "SecondAlignedShape";
thirdShape.Name = "ThirdAlignedShape";

var shapeIndexes = new[]
{
    slide.Shapes.IndexOf(firstShape),
    slide.Shapes.IndexOf(secondShape),
    slide.Shapes.IndexOf(thirdShape)
};

SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
presentation.Save("aligned-shapes.pptx", SaveFormat.Pptx);
```

การจัดแนวเปลี่ยนตำแหน่งไม่ใช่ลำดับ Z‑order การจัดแนวสัมพันธ์ทั่วไปต้องมีอย่างน้อยสองรูปร่าง ส่วนการกระจายแนวนอนหรือแนวตั้งต้องมีรูปร่างเพียงพอเพื่อกำหนดระยะห่าง หากคุณแก้ไขคอลเลกชันก่อนเรียกเมธอดให้คำนวณดัชนีใหม่

## **พลิกรูปร่าง**

คลาส [ShapeFrame](https://reference.aspose.com/slides/th/net/aspose.slides/shapeframe/) เก็บตำแหน่ง, ขนาด, ตั้งค่าการพลิกแนวนอนและแนวตั้ง, และการหมุน ค่า `FlipH` และ `FlipV` ใช้ [NullableBool](https://reference.aspose.com/slides/th/net/aspose.slides/nullablebool/): `True` เปิดการพลิก, `False` ปิด, `NotDefined` รักษาสถานะที่ไม่ได้กำหนด/ค่าเริ่มต้น

พรีเซนเทชันตัวอย่างด้านล่างมีรูปร่างหนึ่งรายการที่ยังไม่ได้พลิก

![The shape before flipping](shape_to_be_flipped.png)

ตัวอย่างนี้เก็บค่ากรอบอื่น ๆ ไว้ทั้งหมดและเปลี่ยนเฉพาะสองการตั้งค่าการพลิกเท่านั้น สิ่งนี้สำคัญเพราะการกำหนดค่าใหม่ให้กับ [Frame](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/frame/) จะทำให้กรอบทั้งหมดถูกแทนที่

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];
var frame = shape.Frame;

Console.WriteLine($"Horizontal flip before change: {frame.FlipH}");
Console.WriteLine($"Vertical flip before change: {frame.FlipV}");

shape.Frame = new ShapeFrame(
    frame.X, frame.Y, frame.Width, frame.Height,
    NullableBool.True, NullableBool.True, frame.Rotation);

presentation.Save("flipped-shape.pptx", SaveFormat.Pptx);
```

รูปร่างที่บันทึกจะถูกสะท้อนแนวนอนและแนวตั้งพร้อมคงตำแหน่ง, ขนาดและการหมุนเดิม

![The shape after flipping](flipped_shape.png)

## **FAQ**

**ควรใช้ดัชนีคอลเลกชันเป็นตัวระบุรูปร่างหรือไม่?**

ใช้ได้เฉพาะในกระบวนการสั้น ๆ ที่คอลเลกชันจะไม่เปลี่ยนแปลงก่อนใช้ดัชนี แนะนำให้ใช้ `Name` หรือ `AlternativeText` ที่ตรวจสอบแล้วสำหรับเทมเพลตที่สร้างโดยผู้เขียน, หรือ `OfficeInteropShapeId` สำหรับการทำงานที่อิง interop ระดับสไลด์

**การซ่อนรูปร่างทำให้มันออกจาก Z‑order หรือไม่?**

ไม่ การซ่อนทำให้รูปร่างคงอยู่ในคอลเลกชันที่ดัชนีเดียวกัน สามารถค้นหา, จัดลำดับใหม่, แก้ไข หรือทำให้แสดงผลอีกครั้งได้

**ทำไมรูปร่างที่ทำสำเนาจึงปรากฏอยู่หน้ารูปร่างอื่น?**

`AddClone` เพิ่มสำเนาที่ท้ายคอลเลกชัน ซึ่งเป็นหน้าสุดของ Z‑order ใช้ `InsertClone` เพื่อเลือกดัชนีเริ่มต้นหรือใช้ `Reorder` หลังจากเพิ่มรูปร่างทั้งหมดแล้ว