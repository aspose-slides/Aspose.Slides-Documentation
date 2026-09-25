---
title: จัดการรูปทรงการนำเสนอใน .NET
linktitle: การจัดการรูปทรง
type: docs
weight: 40
url: /th/net/shape-manipulations/
keywords:
- รูปทรง PowerPoint
- รูปทรงการนำเสนอ
- รูปทรงบนสไลด์
- ค้นหารูปทรง
- ทำสำเนารูปทรง
- ลบรูปทรง
- ซ่อนรูปทรง
- เปลี่ยนลำดับรูปทรง
- รับ ID รูปทรง Interop
- ข้อความแทนรูปทรง
- จุดการปรับรูปทรง
- การปรับรูปทรงที่ตั้งค่าไว้
- เรขาคณิตรูปทรง
- รูปแบบการจัดวางรูปทรง
- รูปทรงเป็น SVG
- แปลงรูปทรงเป็น SVG
- จัดแนวรูปทรง
- พลิกรูปทรง
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีระบุ ปรับแต่ง ทำสำเนา ลบ ซ่อน จัดลำดับใหม่ ส่งออก จัดแนว และพลิกรูปทรงการนำเสนอด้วย Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

Aspose.Slides for .NET แสดงรูปทรงบนสไลด์เป็น [IShapeCollection](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/) ที่จัดลำดับไว้. คอลเลกชันนี้เป็นทั้งที่ที่คุณค้นหาและแก้ไขรูปทรงและเป็นแหล่งกำเนิดของลำดับการซ้อน: ดัชนี `0` คือรูปทรงที่อยู่สุดท้ายด้านหลัง, ส่วนดัชนีสุดท้ายคือรูปทรงที่อยู่ด้านหน้าที่สุด.

บทความนี้ใช้โมเดลดังกล่าว. มันอธิบายวิธีระบุรูปทรงอย่างแม่นยำและปรับจุดการปรับรูปทรงที่ตั้งค่าไว้, จากนั้นแสดงวิธีทำสำเนา, ลบ, ซ่อน, และจัดลำดับรูปทรงใหม่. ส่วนสุดท้ายครอบคลุมการจัดรูปแบบระดับเลย์เอาต์, การส่งออก SVG, การจัดแนว, และการตั้งค่าการพลิก. ตัวอย่างแต่ละตัวเป็นอิสระ, ดังนั้นคุณสามารถใช้เพียงการดำเนินการที่เวิร์กโฟลว์ของคุณต้องการ.

## **ระบุและค้นหารูปทรง**

- [Name](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/name/) มีประโยชน์สำหรับเทมเพลตที่ควบคุมโดยนักพัฒนาและตรวจสอบได้ง่ายใน Selection Pane ของ PowerPoint. ชื่อสามารถแก้ไขได้และไม่ได้รับการรับประกันว่าเป็นเอกลักษณ์, ดังนั้นควรกำหนดแนวทางตั้งชื่อหากโค้ดพึ่งพา.
- [AlternativeText](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/alternativetext/) มีประโยชน์เมื่อคำอธิบายการเข้าถึงหรือแท็กที่ผู้เขียนกำหนดไว้ระบุรูปทรงแล้ว. มันมองเห็นได้โดยผู้ใช้, สามารถแปลเป็นภาษาต่าง ๆ หรือเขียนใหม่เพื่อการเข้าถึง, แต่ไม่ได้รับการรับประกันว่าเป็นเอกลักษณ์. อย่าใช้ข้อความการเข้าถึงที่มีความหมายเป็นคีย์ฐานข้อมูลโดยไม่ได้แจ้งให้ผู้ใช้ทราบ.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/officeinteropshapeid/) เป็นตัวระบุแบบอ่านอย่างเดียวที่เฉพาะเจาะจงภายในสไลด์และสอดคล้องกับ Shape ID ที่ PowerPoint interop ใช้. ใช้มันเมื่อผสานกับ PowerPoint หรือเมื่อคุณต้องการอ้างอิงที่ไม่มีความกำกวมตลอดอายุของรูปทรง. รูปทรงที่ถูกทำสำเนาหรือสร้างใหม่เป็นรูปทรงที่ต่างออกไปและจะได้รับ ID ของตนเอง.

คุณสมบัติ [UniqueId](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/uniqueid/) ที่เกี่ยวข้องมีขอบเขตของการนำเสนอ, แต่ถูกออกแบบมาสำหรับแอดอินและสามารถกำหนดใหม่ได้. ไม่ควรถือว่าเป็นคีย์ภายนอกถาวร. หากต้องการอัตลักษณ์ระยะยาว, เก็บการแมพในข้อมูลแอปพลิเคชันและตรวจสอบว่ารูปทรงที่คาดหวังยังคงมีอยู่.

สำหรับตัวอย่างการอ่านและอัปเดตทั้งชื่อและคำอธิบายของข้อความทางเลือก, ดู [Manage Alternative Text Titles and Descriptions](/slides/th/net/presentation-accessibility/). ใช้ข้อความทางเลือกเพื่ออธิบายความหมายของภาพให้ผู้อ่าน, และเก็บแยกจากชื่อรูปทรงที่โค้ดใช้เพื่อค้นหารูปทรง.

ตัวอย่างต่อไปนี้ค้นหาโดย `Name` ด้วยการเปรียบเทียบแบบลำดับและแสดงผล ID interop ที่มีขอบเขตของสไลด์. เมื่อเทมเพลตไม่มีรูปทรงที่คาดหวัง, โค้ดจะแสดงผลนั้นแทนที่จะดำเนินการต่อกับวัตถุที่ผิด.

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

เมื่อการดำเนินการเฉพาะกับประเภทรูปทรง, ตรวจสอบอินเทอร์เฟซก่อนใช้สมาชิกที่เฉพาะเจาะจงประเภท. ตัวอย่างนี้อัปเดตข้อความและข้อความทางเลือกเฉพาะเมื่อวัตถุที่ระบุเป็น [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/).

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

## **ระบุและแก้ไขการปรับรูปทรงที่ตั้งค่าไว้**

รูปทรงเรขาคณิตที่ตั้งค่าล่วงหน้าสามารถเปิดเผยจุดการปรับที่ควบคุมคุณสมบัติเช่น ขนาดมุม, อัตราส่วนของลูกศร, หรือมุมโค้ง. เข้าถึงผ่านคอลเลกชันอ่านอย่างเดียว [IGeometryShape.Adjustments](https://reference.aspose.com/slides/th/net/aspose.slides/igeometryshape/adjustments/) . คอลเลกชันนี้จัดหาโดยรูปทรง, แต่แต่ละ [IAdjustValue](https://reference.aspose.com/slides/th/net/aspose.slides/iadjustvalue/) มีค่าที่สามารถเปลี่ยนได้.

อย่าพึ่งพาเฉพาะดัชนีคอลเลกชันที่คงที่. วนลูปผ่านการปรับและตรวจสอบคุณสมบัติอ่านอย่างเดียว [Type](https://reference.aspose.com/slides/th/net/aspose.slides/adjustvalue/type/) ซึ่งค่าของ [ShapeAdjustmentType](https://reference.aspose.com/slides/th/net/aspose.slides/shapeadjustmenttype/) บรรยายว่าการปรับควบคุมอะไร. คุณสมบัติอ่านอย่างเดียว [Name](https://reference.aspose.com/slides/th/net/aspose.slides/adjustvalue/name/) ให้ข้อมูลการระบุตัวเพิ่มเติมและเป็นประโยชน์โดยเฉพาะเมื่อชุดตั้งค่ามีการปรับมากกว่าหนึ่งค่าที่มีประเภทเชิงความหมายเดียวกัน.

ใช้คุณสมบัติค่าที่ตรงกับความหมายของการปรับ:

| ประเภทการปรับ | จุดประสงค์ | ค่าเพื่อเปลี่ยน |
|---|---|---|
| `CornerSize` | ขนาดของมุมโค้ง | [RawValue](https://reference.aspose.com/slides/th/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | ความหนาของหางลูกศร | `RawValue` |
| `ArrowheadLength` | ความยาวของหัวลูกศร | `RawValue` |
| `ArrowheadWidth` | ความกว้างของหัวลูกศร | `RawValue` |
| `StartAngle` | มุมเริ่มต้นของพายหรือโค้ง | [AngleValue](https://reference.aspose.com/slides/th/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | มุมสิ้นสุดของพายหรือโค้ง | `AngleValue` |

`Type` และ `Name` ไม่สามารถกำหนดค่าได้. `RawValue` เป็นจำนวนเต็มที่อ่านและเขียนในหน่วยเรขาคณิตพื้นฐานของชุดตั้งค่า, ส่วน `AngleValue` เป็นมุมที่อ่านและเขียนเป็นองศา. จำนวน, ลำดับ, ความหมายและช่วงค่าที่ถูกต้องของการปรับขึ้นอยู่กับ [ShapeType](https://reference.aspose.com/slides/th/net/aspose.slides/igeometryshape/shapetype/) ของชุดตั้งค่า. ค่าที่ถูกต้องสำหรับชุดตั้งค่าหนึ่งอาจไม่ถูกต้องหรือให้ผลแตกต่างสำหรับชุดอื่น.

เมื่อ `Type` เป็น `ShapeAdjustmentType.Custom`, API ไม่รับรู้ความหมายเชิงความหมายมาตรฐาน. ตรวจสอบ `Name`, ประเภทชุดตั้งค่า, และค่าที่มีอยู่, และอย่าเปลี่ยนการปรับหากไม่ได้รู้ความหมายและช่วงค่าที่คาดหวัง. แม้สำหรับประเภทที่รับรู้แล้ว, ตรวจสอบว่าประเภทเดียวกันปรากฏมากกว่าหนึ่งครั้งก่อนเลือกค่า. บทความ [Connector](/slides/th/net/connector/) แสดงสถานการณ์นี้กับการปรับพับของคอนเนคเตอร์.

ตัวอย่างเต็มต่อไปนี้สร้างเวอร์ชันเริ่มต้นและที่แก้ไขของรูปทรงที่ตั้งค่าไว้สามแบบ. มันวนลูปผ่านการปรับทุกค่า, แสดง `Name` และ `Type`, เปลี่ยนค่าที่เกี่ยวข้องกับขนาดผ่าน `RawValue`, เปลี่ยนมุมผ่าน `AngleValue`, และบันทึกผลลัพธ์. คอลัมน์ซ้ายคงเรขาคณิตเริ่มต้น; คอลัมน์ขวาแสดงสี่เหลี่ยมกลมมุม, ลูกศรสี่ทาง, และพายที่ปรับแล้ว.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// เพิ่มหัวข้อสำหรับคอลัมน์รูปทรงเริ่มต้นและรูปทรงที่ปรับค่า.
var defaultColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
defaultColumnLabel.TextFrame.Text = "Default preset geometry";
var adjustedColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
adjustedColumnLabel.TextFrame.Text = "Modified adjustment values";

slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
var modifiedRoundedRectangle = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle.Name = "ModifiedRoundedRectangle";

slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
var modifiedArrow = slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
modifiedArrow.Name = "ModifiedQuadArrow";

slide.Shapes.AddAutoShape(ShapeType.Pie, 95, 330, 130, 130);
var modifiedPie = slide.Shapes.AddAutoShape(ShapeType.Pie, 445, 330, 130, 130);
modifiedPie.Name = "ModifiedPie";

var shapesToAdjust = new IGeometryShape[]
{
    modifiedRoundedRectangle,
    modifiedArrow,
    modifiedPie
};

foreach (var shape in shapesToAdjust)
{
    for (var adjustmentIndex = 0; adjustmentIndex < shape.Adjustments.Count; adjustmentIndex++)
    {
        var adjustment = shape.Adjustments[adjustmentIndex];
        Console.WriteLine($"{shape.Name} / {adjustment.Name}: {adjustment.Type}");

        switch (adjustment.Type)
        {
            case ShapeAdjustmentType.CornerSize:
                adjustment.RawValue = 5000;
                break;
            case ShapeAdjustmentType.ArrowTailThickness:
                adjustment.RawValue = 25000;
                break;
            case ShapeAdjustmentType.ArrowheadLength:
                adjustment.RawValue = 30000;
                break;
            case ShapeAdjustmentType.ArrowheadWidth:
                adjustment.RawValue = 40000;
                break;
            case ShapeAdjustmentType.StartAngle:
                adjustment.AngleValue = 30;
                break;
            case ShapeAdjustmentType.EndAngle:
                adjustment.AngleValue = 300;
                break;
            case ShapeAdjustmentType.Custom:
                Console.WriteLine($"Custom adjustment '{adjustment.Name}' was not changed.");
                break;
        }
    }
}

presentation.Save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
```

การตรวจสอบประเภทเชิงความหมายก่อนเปลี่ยนค่า ทำให้โค้ดระบุเจตนาชัดเจนและหลีกเลี่ยงการสันนิษฐานว่าดัชนีคอลเลกชันเดียวกันมีความหมายเดียวกันในรูปทรงชุดตั้งค่าอื่น.

## **แก้ไขคอลเลกชันรูปทรง**

เมธอดเพิ่ม, ทำสำเนา, ลบ, และจัดลำดับใหม่ทำงานกับคอลเลกชันโดยทันที. หากการดำเนินการทำให้จำนวนหรือลำดับของรูปทรงเปลี่ยนแปลง, อย่าใช้ดัชนีที่บันทึกก่อนการดำเนินการต่อ.

### **ทำสำเนารูปทรง**

[AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/addclone/) สร้างสำเนาอิสระและเพิ่มเข้าคอลเลกชันเป้าหมาย. [InsertClone](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/insertclone/) ก็สร้างสำเนาแต่วางไว้ที่ดัชนี z-order ตามที่ระบุ. ตัวโอเวอร์โหลดที่รับพิกัดย้ายสำเนาโดยไม่เปลี่ยนขนาด; ตัวโอเวอร์โหลดที่รับความกว้างและความสูงสามารถปรับขนาดได้ด้วย.

ตัวอย่างสร้างสไลด์ปลายทาง, ทำสำเนาสี่เหลี่ยมที่มีป้ายกำกับไปด้านหน้า, และแทรกสำเนาที่สองไปด้านหลัง. การเปลี่ยนแปลงใด ๆ กับสำเนาใดสำเนาก็ไม่ส่งผลต่อรูปทรงต้นฉบับ.

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

การทำสำเนาจะคัดลอกเนื้อหาและการจัดรูปแบบของรูปทรง, รวมถึงชื่อและข้อความทางเลือก. กำหนดตัวระบุตรรกะใหม่ให้กับสำเนาหากค่าดังกล่าวต้องเป็นเอกลักษณ์. ทรัพยากรที่ใช้โดยรูปทรงซับซ้อนจะจัดการโดยการนำเสนอ, แต่สำเนายังคงเป็นรายการคอลเลกชันใหม่ที่มีอัตลักษณ์รูปทรงใหม่.

### **ลบรูปทรง**

[Remove](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/remove/) ลบวัตถุรูปทรงเฉพาะจากคอลเลกชันของมัน. เมื่อทำการลบหลายรายการขณะวนลูปโดยใช้ดัชนี, ควรเดินจากท้ายเพื่อให้ดัชนีที่เหลือยังคงถูกต้อง.

ตัวอย่างนี้ลบรูปทรงทุกรูปที่มีชื่อที่กำหนด. มันอ่าน `slide.Shapes[i]`, ไม่ใช่รายการคอลเลกชันคงที่, และไม่ทำการแคสท์รูปทรงโดยไม่จำเป็น.

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

หลังการลบ จำนวนรูปทรงและดัชนีของรูปทรงต่อมาจะเปลี่ยน. การอ้างอิงถึงรูปทรงที่ไม่ได้รับผลกระทบจะเชื่อถือได้มากกว่าดัชนีที่บันทึกไว้. ควรพิจารณาคอนเนคเตอร์, แอนิเมชัน, และฟีเจอร์การนำเสนออื่น ๆ ที่อาจอ้างอิงวัตถุที่ลบ; การลบรูปทรงที่มองเห็นได้อาจเปลี่ยนมากกว่าลักษณะของสไลด์.

### **ซ่อนรูปทรง**

การตั้งค่า [Hidden](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/hidden/) เป็น `true` ทำให้รูปทรงคงอยู่ในคอลเลกชันแต่ไม่ปรากฏในการแสดงสไลด์ปกติ. ดัชนี, การจัดรูปแบบ, และเนื้อหายังคงพร้อมให้โค้ดใช้, ดังนั้นการซ่อนเหมาะสำหรับองค์ประกอบที่เป็นตัวเลือกและอาจทำการกู้คืนในภายหลัง.

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

การซ่อนไม่ใช่การลบหรือความปลอดภัย. วัตถุยังคงสามารถค้นพบและยกเลิกการซ่อนได้โดยผู้ใช้หรือโค้ด, และยังเป็นส่วนหนึ่งของไฟล์การนำเสนอ.

### **เปลี่ยนลำดับ Z**

รูปทรงที่ทับซ้อนกันจะถูกวาดตามลำดับคอลเลกชัน. [Reorder](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/reorder/) ย้ายรูปทรงที่มีอยู่ไปยังดัชนีเป้าหมายโดยไม่ทำสำเนา. ดัชนี `0` คือด้านหลัง; `Count - 1` คือด้านหน้า.

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

สี่เหลี่ยมถูกสร้างขึ้นก่อนและเริ่มต้นอยู่หลังวงรี. การย้ายไปดัชนีสุดท้ายทำให้มันอยู่ด้านหน้า. สรุปลำดับ z หลังจากเพิ่มหรือทำสำเนาทุกรูปที่เกี่ยวข้อง, เพราะการดำเนินการเหล่านั้นจะเพิ่มหรือแทรกรายการคอลเลกชันใหม่และอาจเปลี่ยนสแตกที่ตั้งใจ.

## **ตรวจสอบรูปทรงบนสไลด์เค้าโครง**

สไลด์ปกติ, สไลด์เค้าโครง, และสไลด์แม่มีคอลเลกชันรูปทรงแยกกัน. รูปทรงในคอลเลกชันเค้าโครงไม่ใช่วัตถุเดียวกับรูปทรงที่อยู่ในตำแหน่งคล้ายกันบนสไลด์ปกติ. ตรวจสอบรูปทรงเค้าโครงเมื่อคุณต้องการเข้าใจหรือเปลี่ยนการจัดรูปแบบที่เค้าโครงจัดให้.

ตัวอย่างต่อไปนี้อ่าน [FillFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/fillformat/) และ [LineFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/lineformat/) ของแต่ละรูปทรงในเค้าโครงโดยไม่สันนิษฐานว่าทุกรูปเป็น `AutoShape`.

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

การแก้ไขเค้าโครงอาจส่งผลต่อหลายสไลด์ที่ใช้เค้าโครงนั้น. ก่อนเปลี่ยนรูปทรงเค้าโครง, ตรวจสอบว่าสไลด์ปกติสืบทอดวัตถุหรือมีการทับซ้อนแบบโลคอล, และทดสอบทุกสไลด์ที่ใช้เค้าโครงนั้น.

## **ส่งออกรูปทรงเป็น SVG**

[WriteAsSvg](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/writeassvg/) เขียนเนื้อหาที่เรนเดอร์ของรูปทรงหนึ่งลงสตรีม. ผลลัพธ์จะมีรูปทรงเท่านั้น, ไม่ใช่พื้นหลังสไลด์ทั้งหมดหรือรูปทรงใกล้เคียง.

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

ควรเปิดการนำเสนอขณะทำการเรนเดอร์. ผลลัพธ์ขึ้นอยู่กับการจัดรูปแบบของรูปทรงและทรัพยากรเช่นฟอนต์และรูปภาพ. หากต้องการส่งออกภาพรวมทั้งหมด, ควรส่งออกรายการสไลด์แทนการส่งออกรูปทรงเดี่ยว. ผู้เรียกต้องเป็นเจ้าของสตรีมและต้องทำการ dispose.

## **จัดแนวรูปทรง**

[SlideUtil.AlignShapes](https://reference.aspose.com/slides/th/net/aspose.slides.util/slideutil/alignshapes/) มีหลายเวอร์ชันที่จัดแนวทั้งทั้งหมดหรือดัชนีคอลเลกชันที่เลือก. [ShapesAlignmentType](https://reference.aspose.com/slides/th/net/aspose.slides/shapesalignmenttype/) ระบุขอบ, เส้นศูนย์กลาง, หรือโหมดการกระจาย. ตั้ง `alignToSlide` เป็น `true` เพื่อใช้ขอบสไลด์; ตั้งเป็น `false` เพื่อจัดแนวรูปทรงที่เลือกสัมพันธ์กัน.

ตัวอย่างนี้จัดแนวสามรูปทรงให้กับขอบบนของสไลด์. ตัวอ้างอิงรูปทรงที่ส่งกลับจะถูกแปลงเป็นดัชนีปัจจุบันทันทีก่อนการจัดแนว.

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

การจัดแนวเปลี่ยนตำแหน่ง, ไม่ใช่ลำดับ z. การจัดแนวสัมพันธ์ทั่วไปต้องมีอย่างน้อยสองรูปทรง, ส่วนการกระจายแนวนอนหรือแนวตั้งต้องมีรูปทรงเพียงพอเพื่อกำหนดระยะห่าง. ให้คำนวณดัชนีใหม่หากคุณแก้ไขคอลเลกชันก่อนเรียกเมธอด.

## **พลิกรูปทรง**

คลาส [ShapeFrame](https://reference.aspose.com/slides/th/net/aspose.slides/shapeframe/) เก็บตำแหน่ง, ขนาด, การตั้งค่าการพลิกแนวนอนและแนวตั้ง, และการหมุน. ค่าที่ `FlipH` และ `FlipV` ใช้ [NullableBool](https://reference.aspose.com/slides/th/net/aspose.slides/nullablebool/): `True` เปิดการพลิก, `False` ปิด, และ `NotDefined` รักษาสถานะที่ไม่ได้กำหนด/ค่าเริ่มต้น.

การนำเสนออินพุตด้านล่างมีรูปทรงหนึ่งที่ไม่ได้พลิก.

![รูปทรงก่อนการพลิก](shape_to_be_flipped.png)

ตัวอย่างนี้เก็บค่ากรอบอื่นทั้งหมดและเปลี่ยนเฉพาะการตั้งค่าพลิกสองค่า. สิ่งนี้สำคัญเพราะการกำหนด [Frame](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/frame/) ใหม่จะเปลี่ยนกรอบทั้งหมด.

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

รูปทรงที่บันทึกแล้วจะถูกสะท้อนในแนวนอนและแนวตั้งโดยคงตำแหน่ง, ขนาด, และการหมุน.

![รูปทรงหลังการพลิก](flipped_shape.png)

## **คำถามที่พบบ่อย**

**ควรใช้ดัชนีคอลเลกชันเป็นตัวระบุตัวรูปทรงหรือไม่?**

เฉพาะในกระบวนการที่ใช้เวลาสั้น ๆ เมื่อคอลเลกชันจะไม่เปลี่ยนแปลงก่อนที่ดัชนีจะถูกใช้. ควรใช้ `Name` หรือ `AlternativeText` ที่ตรวจสอบแล้วเป็นแนวทางสำหรับเทมเพลตที่สร้าง, หรือ `OfficeInteropShapeId` สำหรับงาน interop ที่มีขอบเขตสไลด์.

**การซ่อนรูปทรงทำให้มันหายไปจากลำดับ z หรือไม่?**

ไม่. รูปทรงที่ซ่อนยังคงอยู่ในคอลเลกชันที่ดัชนีเดียวกัน. สามารถค้นหา, จัดลำดับใหม่, แก้ไข, หรือทำให้มองเห็นได้อีก.

**ทำไมรูปทรงที่ทำสำเนาถึงปรากฏอยู่ข้างหน้ารูปทรงอื่น?**

`AddClone` เพิ่มสำเนาที่ท้ายของคอลเลกชัน, ซึ่งเป็นด้านหน้าของลำดับ z. ใช้ `InsertClone` เพื่อเลือกดัชนีเริ่มต้นหรือ `Reorder` หลังจากเพิ่มรูปทรงทั้งหมดแล้ว.

**ฉันสามารถใช้ดัชนีคงที่เพื่อระบุการปรับรูปทรงที่ตั้งค่าไว้ได้หรือไม่?**

ได้เฉพาะหลังจากตรวจสอบชุดตั้งค่าและรูปแบบคอลเลกชันที่แน่นอน. ควรวนลูปผ่าน `IGeometryShape.Adjustments` และตรวจสอบ `IAdjustValue.Type`; ใช้ `IAdjustValue.Name` เป็นข้อมูลเพิ่มเติมเมื่อประเภทเชิงความหมายเดียวกันปรากฏมากกว่าหนึ่งครั้ง.