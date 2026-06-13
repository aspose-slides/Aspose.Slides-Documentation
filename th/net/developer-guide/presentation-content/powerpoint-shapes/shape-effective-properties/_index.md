---
title: รับคุณสมบัติรูปร่างที่มีประสิทธิภาพจากพรีเซนเทชันใน .NET
linktitle: คุณสมบัติมีประสิทธิภาพ
type: docs
weight: 50
url: /th/net/shape-effective-properties/
keywords:
- คุณสมบัติรูปร่าง
- คุณสมบัติกล้อง
- ระบบแสง
- รูปร่างบีเวล
- กรอบข้อความ
- สไตล์ข้อความ
- ความสูงของฟอนต์
- รูปแบบการเติม
- PowerPoint
- พรีเซนเทชัน
- .NET
- C#
- Aspose.Slides
description: "ค้นพบว่า Aspose.Slides for .NET คำนวณและประยุกต์ใช้คุณสมบัติรูปร่างที่มีประสิทธิภาพอย่างไรเพื่อการเรนเดอร์ PowerPoint ที่แม่นยำ."
---
## **ภาพรวม**

หัวข้อนี้อธิบายความแตกต่างระหว่างคุณสมบัติ **local** และ **effective** ค่า Local คือค่าที่ตั้งโดยตรงที่ระดับการจัดรูปแบบเฉพาะ เช่น:

1. คุณสมบัติส่วนของข้อความบนสไลด์
1. สไตล์ข้อความของรูปร่างต้นแบบบนเลย์เอาต์หรือสไลด์มาสเตอร์เมื่อรูปแบบกรอบข้อความของส่วนนั้นมีอยู่
1. การตั้งค่าข้อความทั่วโลกในพรีเซนเทชัน

ค่าท้องถิ่นสามารถกำหนดหรือละเว้นได้ที่ระดับใดก็ได้ เมื่อ Aspose.Slides ต้องการรูปแบบ “as rendered” สุดท้าย มันจะทำการแก้ไขสายการสืบทอดและคืนค่า **effective** คุณสามารถดึงค่าเหล่านี้ได้โดยเรียกเมธอด `GetEffective` บนวัตถุรูปแบบท้องถิ่น

ตัวอย่างต่อไปนี้แสดงวิธีดึงค่า effective โดยสมมติว่ารูปร่างแรกบนสไลด์แรกเป็น [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ที่มีกรอบข้อความและมีอย่างน้อยหนึ่งส่วน

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="primary" %}}
ข้อมูลการจัดรูปแบบที่ effective แสดงถึงการคำนวณรูปแบบปัจจุบันหลังจากนำการสืบทอดมาใช้ ในการนำไปใช้ปัจจุบันบางวัตถุข้อมูล effective เช่น [IPortionFormatEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/iportionformateffectivedata/) อาจถูกแคชไว้ภายใน การเรียก `GetEffective` อีกครั้งหลังจากเปลี่ยนรูปแบบจากพาเรนต์หรือจากการสืบทอดสามารถรีเฟรชข้อมูลแคชได้ และวัตถุที่เคยได้รับอาจไม่สอดคล้องกับสถานะก่อนหน้า หากต้องการเก็บค่าที่ effective ไว้ใช้ในภายหลัง ให้คัดลอกคุณสมบัติที่ต้องการ เช่น ความสูงของฟอนต์ สีเติม แบบอักษร หรือการจัดแนว ไปยังวัตถุข้อมูลของคุณเอง
{{% /alert %}}

## **ดึงคุณสมบัติ Effective ของกล้อง**

Aspose.Slides อนุญาตให้คุณดึงคุณสมบัติ effective ของกล้องได้ ส่วนต่อประสาน [ICameraEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/icameraeffectivedata/) แสดงวัตถุที่ไม่สามารถแก้ไขได้ซึ่งมีคุณสมบัติกล้องที่ effective ตัวอย่างของ [ICameraEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/icameraeffectivedata/) จะถูกเปิดเผยผ่าน [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformateffectivedata/) ซึ่งให้ค่าที่ effective สำหรับ [IThreeDFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/)

โค้ดตัวอย่างต่อไปนี้แสดงวิธีดึงคุณสมบัติ effective ของกล้อง โดยสมมติว่ารูปร่างแรกบนสไลด์แรกมีการจัดรูปแบบ 3 มิติ

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **ดึงคุณสมบัติ Effective ของ Light Rig**

Aspose.Slides อนุญาตให้คุณดึงคุณสมบัติ effective ของ Light Rig ได้ ส่วนต่อประสาน [ILightRigEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/ilightrigeffectivedata/) แสดงวัตถุที่ไม่สามารถแก้ไขได้ซึ่งมีคุณสมบัติ Light Rig ที่ effective ตัวอย่างของ [ILightRigEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/ilightrigeffectivedata/) จะถูกเปิดเผยผ่าน [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformateffectivedata/) ซึ่งให้ค่าที่ effective สำหรับ [IThreeDFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/)

โค้ดตัวอย่างต่อไปนี้แสดงวิธีดึงคุณสมบัติ effective ของ Light Rig โดยสมมติว่ารูปร่างแรกบนสไลด์แรกมีการจัดรูปแบบ 3 มิติ

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **ดึงคุณสมบัติ Effective ของ Bevel Shape**

Aspose.Slides อนุญาตให้คุณดึงคุณสมบัติ effective ของ bevel รูปร่างได้ ส่วนต่อประสาน [IShapeBevelEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/ishapebeveleffectivedata/) แสดงวัตถุที่ไม่สามารถแก้ไขได้ซึ่งมีคุณสมบัติ relief ของหน้าแบบ effective สำหรับรูปร่าง ตัวอย่างของ [IShapeBevelEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/ishapebeveleffectivedata/) จะถูกเปิดเผยผ่าน [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformateffectivedata/) ซึ่งให้ค่าที่ effective สำหรับ [IThreeDFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/)

โค้ดตัวอย่างต่อไปนี้แสดงวิธีดึงคุณสมบัติ effective ของ bevel ด้านบนของรูปร่าง โดยสมมติว่ารูปร่างแรกบนสไลด์แรกมีการจัดรูปแบบ 3 มิติ

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **ดึงคุณสมบัติ Effective ของ Text Frame**

ด้วย Aspose.Slides คุณสามารถดึงคุณสมบัติ effective ของกรอบข้อความได้ ส่วนต่อประสาน [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformateffectivedata/) มีคุณสมบัติการจัดรูปแบบกรอบข้อความที่ effective

โค้ดตัวอย่างต่อไปนี้แสดงวิธีดึงคุณสมบัติการจัดรูปแบบกรอบข้อความที่ effective โดยสมมติว่ารูปร่างแรกบนสไลด์แรกเป็น [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ที่มีกรอบข้อความ

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var textFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = textFrameFormat.GetEffective();

Console.WriteLine("Anchoring type: " + effectiveTextFrameFormat.AnchoringType);
Console.WriteLine("Autofit type: " + effectiveTextFrameFormat.AutofitType);
Console.WriteLine("Text vertical type: " + effectiveTextFrameFormat.TextVerticalType);
Console.WriteLine("Margins");
Console.WriteLine("   Left: " + effectiveTextFrameFormat.MarginLeft);
Console.WriteLine("   Top: " + effectiveTextFrameFormat.MarginTop);
Console.WriteLine("   Right: " + effectiveTextFrameFormat.MarginRight);
Console.WriteLine("   Bottom: " + effectiveTextFrameFormat.MarginBottom);
```

## **ดึงคุณสมบัติ Effective ของ Text Style**

ด้วย Aspose.Slides คุณสามารถดึงคุณสมบัติ effective ของสไตล์ข้อความได้ ส่วนต่อประสาน [ITextStyleEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/itextstyleeffectivedata/) มีคุณสมบัติสไตล์ข้อความที่ effective

โค้ดตัวอย่างต่อไปนี้แสดงวิธีดึงคุณสมบัติสไตล์ข้อความที่ effective โดยสมมติว่ารูปร่างแรกบนสไลด์แรกเป็น [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ที่มีกรอบข้อความ

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();
var levelCount = 9;

for (var levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    var effectiveStyleLevel = effectiveTextStyle.GetLevel(levelIndex);
    Console.WriteLine("= Effective paragraph formatting for style level #" + levelIndex + " =");

    Console.WriteLine("Depth: " + effectiveStyleLevel.Depth);
    Console.WriteLine("Indent: " + effectiveStyleLevel.Indent);
    Console.WriteLine("Alignment: " + effectiveStyleLevel.Alignment);
    Console.WriteLine("Font alignment: " + effectiveStyleLevel.FontAlignment);
}
```

## **ดึงค่าความสูงฟอนต์ Effective**

ด้วย Aspose.Slides คุณสามารถดึงความสูงฟอนต์ที่ effective ได้ โค้ดต่อไปนี้สาธิตว่าความสูงฟอนต์ของส่วน (portion) ที่ effective จะเปลี่ยนแปลงอย่างไรเมื่อกำหนดค่าความสูงฟอนต์ท้องถิ่นที่ระดับโครงสร้างพรีเซนเทชันต่าง ๆ

```csharp
using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
autoShape.AddTextFrame("");

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var firstPortion = new Portion("Sample text with first portion");
var secondPortion = new Portion(" and second portion.");

paragraph.Portions.Add(firstPortion);
paragraph.Portions.Add(secondPortion);

var firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
var secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height just after creation:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting the presentation default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 40;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting paragraph default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

firstPortion.PortionFormat.FontHeight = 55;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #0 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

secondPortion.PortionFormat.FontHeight = 18;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #1 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.Save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
```

## **ดึงรูปแบบเติม (Fill) Effective สำหรับตาราง**

ด้วย Aspose.Slides คุณสามารถดึงการจัดรูปแบบเติมที่ effective สำหรับส่วนต่าง ๆ ของตารางได้ ส่วนต่อประสาน [IFillFormatEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/ifillformateffectivedata/) มีคุณสมบัติการจัดรูปแบบเติมที่ effective การจัดรูปแบบเซลล์มีลำดับความสำคัญสูงกว่าการจัดรูปแบบแถว, แถวสูงกว่าคอลัมน์, คอลัมน์สูงกว่าการจัดรูปแบบตารางทั้งหมด

ผลคือ คุณสมบัติของ [ICellFormatEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/icellformateffectivedata/) จะถูกใช้ในการวาดเซลล์ตาราง โค้ดตัวอย่างต่อไปนี้แสดงวิธีดึงการจัดรูปแบบเติมที่ effective สำหรับส่วนต่าง ๆ ของตาราง โดยสมมติว่ารูปร่างแรกบนสไลด์แรกเป็น [ITable](https://reference.aspose.com/slides/th/net/aspose.slides/itable/)

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var table = (ITable)presentation.Slides[0].Shapes[0];

var tableFormatEffective = table.TableFormat.GetEffective();
var rowFormatEffective = table.Rows[0].RowFormat.GetEffective();
var columnFormatEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellFormatEffective = table[0, 0].CellFormat.GetEffective();

var tableFillFormatEffective = tableFormatEffective.FillFormat;
var rowFillFormatEffective = rowFormatEffective.FillFormat;
var columnFillFormatEffective = columnFormatEffective.FillFormat;
var cellFillFormatEffective = cellFormatEffective.FillFormat;
```

## **คำถามที่พบบ่อย**

**`GetEffective` คืนค่าภาพรวมหรือไม่?**

ไม่เสมอไป ข้อมูลที่ effective แสดงถึงการจัดรูปแบบที่คำนวณแล้วหลังจากการสืบทอด แต่บางวัตถุข้อมูล effective อาจถูกแคชภายใน การเรียก `GetEffective` ครั้งต่อมาหลังจากเปลี่ยนการจัดรูปแบบพาเรนต์หรือการสืบทอดอาจทำการคำนวณใหม่และรีเฟรชข้อมูลแคช ดังนั้นวัตถุที่เคยได้มาก่อนหน้านี้ไม่ควรถูกพิจารณาเป็นภาพสแนปช็อตที่คงที่

**ควรอ่านคุณสมบัติ effective อีกครั้งเมื่อใด?**

ให้เรียก `GetEffective` อีกครั้งหลังจากเปลี่ยนการจัดรูปแบบท้องถิ่น, สไตล์พาเรนต์, การจัดรูปแบบเลย์เอาต์, การจัดรูปแบบมาสเตอร์ หรือค่าเริ่มต้นระดับพรีเซนเทชัน การเรียกครั้งต่อไปจะประเมินลำดับการจัดรูปแบบใหม่และคืนค่าที่ effective ปัจจุบัน

**การเปลี่ยนหรือเอาออกสไลด์เลย์เอาต์/มาสเตอร์ส่งผลต่อคุณสมบัติ effective ที่ดึงไว้แล้วหรือไม่?**

ใช่ แต่การเปลี่ยนแปลงจะแสดงผลในครั้งเรียก `GetEffective` ถัดไป หากแหล่งข้อมูลการจัดรูปแบบพาเรนต์ถูกเปลี่ยนหรือเอาออก ข้อมูล effective ที่ได้มาก่อนหน้าอาจล้าสมัย เมื่อเรียก `GetEffective` อีกครั้ง Aspose.Slides จะประเมินต้นไม้การจัดรูปแบบใหม่และฟอนต์, สี, ขนาด หรือค่าต่าง ๆ อาจเปลี่ยนแปลง

**สามารถแก้ไขค่าผ่านวัตถุข้อมูล effective ได้หรือไม่?**

ไม่ได้ วัตถุข้อมูล effective เปิดเผยค่าที่คำนวณแล้ว ให้ทำการเปลี่ยนแปลงในวัตถุการจัดรูปแบบท้องถิ่นแล้วจึงดึงค่าที่ effective ใหม่อีกครั้ง

**ถ้าคุณสมบัติไม่ได้ตั้งค่าที่ระดับรูปร่าง ไม่ได้ตั้งค่าในเลย์เอาต์/มาสเตอร์ หรือไม่ในการตั้งค่าทั่วโลก จะเกิดอะไรขึ้น?**

ค่าที่ effective จะถูกกำหนดโดยกลไกค่าเริ่มต้น ซึ่งรวมถึงค่าเริ่มต้นของ PowerPoint และ Aspose.Slides ค่าที่แก้ไขแล้วจะเป็นส่วนหนึ่งของข้อมูลที่ effective ปัจจุบัน

**จากค่าฟอนต์ที่ effective ฉันสามารถบอกได้หรือไม่ว่าระดับใดให้ค่าขนาดหรือฟอนต์?**

โดยตรงไม่ได้ ข้อมูลที่ effective คืนค่าผลลัพธ์สุดท้าย เพื่อตรวจสอบแหล่งที่มาควรตรวจสอบค่าท้องถิ่นที่ส่วน, ย่อหน้า, กรอบข้อความ, และสไตล์ข้อความที่เลย์เอาต์, มาสเตอร์, และระดับพรีเซนเทชันเพื่อค้นหาการกำหนดที่ชัดเจนเป็นครั้งแรก

**ทำไมค่าที่ effective บางครั้งดูเหมือนกับค่าท้องถิ่น?**

เพราะค่าท้องถิ่นกลายเป็นค่าที่สุดท้าย (ไม่มีการสืบทอดจากระดับที่สูงกว่า) ในกรณีนี้ค่าที่ effective จึงตรงกับค่าท้องถิ่น

**ควรใช้คุณสมบัติ effective เมื่อใด และเมื่อใดควรทำงานเฉพาะกับค่าท้องถิ่น?**

ใช้ข้อมูลที่ effective เมื่อคุณต้องการผลลัพธ์ “as rendered” หลังจากการสืบทอดทั้งหมด เช่น การจัดสี, ระยะเยื้อง หรือขนาด หากต้องการเก็บค่าดังกล่าวไว้โดยไม่ต้องกังวลกับการเปลี่ยนแปลงรูปแบบในภายหลัง ให้วางค่าที่ต้องการลงในวัตถุของคุณเอง หากต้องการเปลี่ยนรูปแบบที่ระดับใดระดับหนึ่ง ให้แก้ไขคุณสมบัติท้องถิ่นและจากนั้น (หากจำเป็น) อ่านข้อมูลที่ effective อีกครั้งเพื่อยืนยันผลลัพธ์