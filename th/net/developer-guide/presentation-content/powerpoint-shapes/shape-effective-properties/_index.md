---
title: รับคุณสมบัติรูปทรงที่มีผลจากงานนำเสนอใน .NET
linktitle: คุณสมบัติที่มีผล
type: docs
weight: 50
url: /th/net/shape-effective-properties/
keywords:
- คุณสมบัติรูปทรง
- คุณสมบัติกล้อง
- อุปกรณ์กำหนดแสง
- รูปทรง bevel
- กรอบข้อความ
- สไตล์ข้อความ
- ความสูงฟอนต์
- รูปแบบการเติม
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ค้นพบวิธีที่ Aspose.Slides สำหรับ .NET คำนวณและนำคุณสมบัติรูปทรงที่มีผลไปใช้เพื่อการเรนเดอร์ PowerPoint อย่างแม่นยำ"
---
## **ภาพรวม**

หัวข้อนี้อธิบายความแตกต่างระหว่างคุณสมบัติ **ท้องถิ่น** และ **ที่มีผล** ค่าท้องถิ่นคือค่าที่ตั้งโดยตรงในระดับการจัดรูปแบบเฉพาะ เช่น  

1. คุณสมบัติส่วนของบนสไลด์.  
1. สไตล์ข้อความของรูปร่างต้นแบบบนเลย์เอาต์หรือสไลด์แม่, เมื่อรูปแบบกรอบข้อความของส่วนมีอยู่.  
1. การตั้งค่าข้อความระดับโลกในงานนำเสนอ.  

ค่าท้องถิ่นสามารถกำหนดหรือละเว้นได้ในระดับใดก็ได้ เมื่อต้องการฟอร์แมตขั้นสุดท้าย “ตามที่แสดงผล” Aspose.Slides จะทำการแก้ไขห่วงโซ่การสืบทอดและคืนค่า **ที่มีผล** คุณสามารถรับค่าเหล่านี้ได้โดยเรียกเมธอด `GetEffective` บนวัตถุรูปแบบท้องถิ่น  

ตัวอย่างต่อไปนี้แสดงวิธีรับค่า ที่มีผล โดยสมมติว่ารูปร่างแรกบนสไลด์แรกเป็น [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ที่มีกรอบข้อความและมีอย่างน้อยหนึ่งส่วน

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="info" %}}
ข้อมูลการจัดรูปแบบที่มีผลแสดงถึงการคำนวณรูปแบบปัจจุบันหลังจากการสืบทอดถูกนำไปใช้ ในการทำงานปัจจุบันบางวัตถุข้อมูลที่มีผล เช่น [IPortionFormatEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/iportionformateffectivedata/) อาจถูกแคชภายใน การเรียก `GetEffective` อีกครั้งหลังจากเปลี่ยนรูปแบบพ่อหรือรูปแบบที่สืบทอดสามารถรีเฟรชข้อมูลที่แคชได้ และวัตถุที่ได้ก่อนหน้านี้อาจไม่แสดงถึงสถานะก่อนหน้าอีกต่อไป หากคุณต้องการเก็บค่าที่มีผลไว้ใช้ในภายหลัง ให้คัดลอกคุณสมบัติที่จำเป็น เช่น ความสูงของฟอนต์ สีเติม สไตล์ฟอนต์ หรือการจัดแนว ไปยังออบเจ็กต์ข้อมูลของคุณเอง
{{% /alert %}}

## **รับคุณสมบัติที่มีผลของกล้อง**

Aspose.Slides ให้คุณรับคุณสมบัติที่มีผลของกล้อง อินเตอร์เฟซ [ICameraEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/icameraeffectivedata/) แทนวัตถุไม่เปลี่ยนแปลงที่บรรจุคุณสมบัติกล้องที่มีผล อินสแตนซ์ของ [ICameraEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/icameraeffectivedata/) ถูกเปิดเผยผ่าน [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformateffectivedata/) ซึ่งให้ค่าที่มีผลสำหรับ [IThreeDFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/)

โค้ดตัวอย่างต่อไปนี้แสดงวิธีรับคุณสมบัติที่มีผลของกล้อง โดยสมมติว่ารูปร่างแรกบนสไลด์แรกมีการจัดรูปแบบ 3 มิติ

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **รับคุณสมบัติที่มีผลของ Light Rig**

Aspose.Slides ให้คุณรับคุณสมบัติที่มีผลของ Light Rig อินเตอร์เฟซ [ILightRigEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/ilightrigeffectivedata/) แทนวัตถุไม่เปลี่ยนแปลงที่บรรจุคุณสมบัติ Light Rig ที่มีผล อินสแตนซ์ของ [ILightRigEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/ilightrigeffectivedata/) ถูกเปิดเผยผ่าน [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformateffectivedata/) ซึ่งให้ค่าที่มีผลสำหรับ [IThreeDFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/)

โค้ดตัวอย่างต่อไปนี้แสดงวิธีรับคุณสมบัติที่มีผลของ Light Rig โดยสมมติว่ารูปร่างแรกบนสไลด์แรกมีการจัดรูปแบบ 3 มิติ

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **รับคุณสมบัติที่มีผลของขอบรูปทรง (Bevel Shape)**

Aspose.Slides ให้คุณรับคุณสมบัติที่มีผลของขอบรูปทรง อินเตอร์เฟซ [IShapeBevelEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/ishapebeveleffectivedata/) แทนวัตถุไม่เปลี่ยนแปลงที่บรรจุคุณสมบัติการรีลีฟของรูปทรง อินสแตนซ์ของ [IShapeBevelEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/ishapebeveleffectivedata/) ถูกเปิดเผยผ่าน [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformateffectivedata/) ซึ่งให้ค่าที่มีผลสำหรับ [IThreeDFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/)

โค้ดตัวอย่างต่อไปนี้แสดงวิธีรับคุณสมบัติที่มีผลของขอบด้านบนของรูปทรง โดยสมมติว่ารูปร่างแรกบนสไลด์แรกมีการจัดรูปแบบ 3 มิติ

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **รับคุณสมบัติที่มีผลของกรอบข้อความ (Text Frame)**

ด้วย Aspose.Slides คุณสามารถรับคุณสมบัติที่มีผลของกรอบข้อความ อินเตอร์เฟซ [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformateffectivedata/) มีคุณสมบัติการจัดรูปแบบกรอบข้อความที่มีผล  

โค้ดตัวอย่างต่อไปนี้แสดงวิธีรับคุณสมบัติการจัดรูปแบบกรอบข้อความที่มีผล โดยสมมติว่ารูปร่างแรกบนสไลด์แรกเป็น [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ที่มีกรอบข้อความ

```csharp
using Aspose.Slides;

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

## **รับคุณสมบัติที่มีผลของสไตล์ข้อความ (Text Style)**

ด้วย Aspose.Slides คุณสามารถรับคุณสมบัติที่มีผลของสไตล์ข้อความ อินเตอร์เฟซ [ITextStyleEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/itextstyleeffectivedata/) มีคุณสมบัติสไตล์ข้อความที่มีผล  

โค้ดตัวอย่างต่อไปนี้แสดงวิธีรับคุณสมบัติสไตล์ข้อความที่มีผล โดยสมมติว่ารูปร่างแรกบนสไลด์แรกเป็น [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ที่มีกรอบข้อความ

```csharp
using Aspose.Slides;

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

## **รับค่า ความสูงของฟอนต์ ที่มีผล**

ด้วย Aspose.Slides คุณสามารถรับความสูงของฟอนต์ที่มีผล ตัวอย่างโค้ดต่อไปนี้สาธิตการเปลี่ยนแปลงความสูงฟอนต์ที่มีผลของส่วนหลังจากตั้งค่าความสูงฟอนต์ท้องถิ่นในระดับโครงสร้างงานนำเสนอที่ต่างกัน

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **รับการเติมรูปแบบที่มีผลสำหรับตาราง**

ด้วย Aspose.Slides คุณสามารถรับการเติมรูปแบบที่มีผลสำหรับส่วนต่าง ๆ ของตาราง อินเตอร์เฟซ [IFillFormatEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/ifillformateffectivedata/) มีคุณสมบัติการเติมรูปแบบที่มีผล การจัดรูปแบบเซลล์มีลำดับความสำคัญสูงกว่าการจัดรูปแบบแถว, การจัดรูปแบบแถวสูงกว่าการจัดรูปแบบคอลัมน์, และการจัดรูปแบบคอลัมน์สูงกว่าการจัดรูปแบบตารางทั้งหมด  

ดังนั้นคุณสมบัติของ [ICellFormatEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/icellformateffectivedata/) จะถูกใช้ในการวาดเซลล์ตาราง โค้ดตัวอย่างต่อไปนี้แสดงวิธีรับการเติมรูปแบบที่มีผลสำหรับส่วนต่าง ๆ ของตาราง โดยสมมติว่ารูปร่างแรกบนสไลด์แรกเป็น [ITable](https://reference.aspose.com/slides/th/net/aspose.slides/itable/)

```csharp
using Aspose.Slides;

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

## **FAQ**

### `GetEffective` คืนค่าภาพสแนปช็อตหรือไม่?

ไม่เสมอไป ข้อมูลที่มีผลแสดงถึงการจัดรูปแบบที่คำนวณหลังการสืบทอด แต่บางวัตถุข้อมูลที่มีผลอาจถูกแคชภายใน การเรียก `GetEffective` อีกครั้งอาจทำให้คำนวณใหม่และรีเฟรชข้อมูลที่แคช ดังนั้นวัตถุที่ได้ก่อนหน้านี้ไม่ควรถือว่าเป็นภาพสแนปช็อตที่คงที่

### ควรอ่านคุณสมบัติที่มีผลใหม่เมื่อใด?

เรียก `GetEffective` อีกครั้งหลังจากเปลี่ยนการจัดรูปแบบท้องถิ่น, สไตล์พาเรนต์, การจัดรูปแบบเลย์เอาต์, การจัดรูปแบบมาสเตอร์ หรือค่าเริ่มต้นระดับงานนำเสนอ การเรียกครั้งต่อไปจะประเมินลำดับชั้นการจัดรูปแบบใหม่และคืนค่าที่มีผลปัจจุบัน

### การเปลี่ยนหรือการลบสไลด์เลย์เอาต์/มาสเตอร์มีผลต่อคุณสมบัติที่มีผลที่ได้แล้วหรือไม่?

มีผล แต่การเปลี่ยนแปลงจะสะท้อนในการเรียก `GetEffective` ครั้งต่อไป หากแหล่งข้อมูลการจัดรูปแบบพาเรนต์ถูกเปลี่ยนหรือถูกลบ ข้อมูลที่มีผลที่ได้ก่อนหน้านี้อาจล้าสมัย เมื่อเรียก `GetEffective` อีกครั้ง Aspose.Slides จะประเมินต้นไม้การจัดรูปแบบใหม่และฟอนต์, สี, ขนาด หรือค่าที่อื่นอาจเปลี่ยนแปลง

### สามารถแก้ไขค่าผ่านวัตถุข้อมูลที่มีผลได้หรือไม่?

ไม่ได้ วัตถุข้อมูลที่มีผลเปิดเผยค่าที่คำนวณแล้ว ให้ทำการเปลี่ยนแปลงในวัตถุการจัดรูปแบบท้องถิ่นและจากนั้นรับค่าที่มีผลอีกครั้ง

### หากคุณสมบัติไม่ได้ถูกตั้งค่าที่ระดับรูปร่าง, เลย์เอาต์/มาสเตอร์ หรือการตั้งค่าทั่วไป จะเกิดอะไรขึ้น?

ค่าที่มีผลจะถูกกำหนดโดยกลไกค่าเริ่มต้น ซึ่งรวมถึงค่าเริ่มต้นของ PowerPoint และ Aspose.Slides ค่าที่ได้จะกลายเป็นส่วนหนึ่งของข้อมูลที่มีผลปัจจุบัน

### จากค่าฟอนต์ที่มีผล สามารถบอกได้ระดับใดที่ให้ขนาดหรือฟอนต์หรือไม่?

ไม่โดยตรง ข้อมูลที่มีผลให้ค่าขั้นสุดท้าย เพื่อหาต้นทางให้ตรวจสอบค่าท้องถิ่นที่ส่วน, ย่อหน้า, กรอบข้อความ, และสไตล์ข้อความที่เลย์เอาต์, มาสเตอร์, และระดับงานนำเสนอเพื่อดูว่าการกำหนดที่ชัดเจนแรกปรากฏที่ไหน

### ทำไมค่าที่มีผลบางครั้งดูเหมือนกับค่าท้องถิ่น?

เพราะค่าท้องถิ่นนั้นกลายเป็นค่าขั้นสุดท้าย (ไม่มีการสืบทอดระดับสูงกว่า) ในกรณีเช่นนั้นค่าที่มีผลจะแมทช์ค่าท้องถิ่น

### ควรใช้คุณสมบัติที่มีผลเมื่อไรและควรใช้เฉพาะคุณสมบัติท้องถิ่นเมื่อไร?

ใช้ข้อมูลที่มีผลเมื่อคุณต้องการผลลัพธ์ “ตามที่แสดงผล” หลังจากการสืบทอดทั้งหมด เช่น การจัดแนวสี, ระยะเยื้อง, หรือขนาด หากคุณต้องการเก็บค่าต่าง ๆ ไว้โดยไม่สนใจการเปลี่ยนแปลงการจัดรูปแบบต่อไป ให้คัดลอกคุณสมบัติที่จำเป็นไปยังออบเจ็กต์ของคุณเอง หากต้องการเปลี่ยนการจัดรูปแบบที่ระดับเฉพาะให้แก้ไขคุณสมบัติท้องถิ่นและจากนั้น (หากจำเป็น) อ่านข้อมูลที่มีผลอีกครั้งเพื่อยืนยันผลลัพธ์.