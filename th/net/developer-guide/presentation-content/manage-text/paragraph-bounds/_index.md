---
title: รับขอบเขตย่อหน้าจากงานนำเสนอใน .NET
linktitle: ขอบเขตย่อหน้า
type: docs
weight: 43
url: /th/net/paragraph-bounds/
keywords:
- ขอบเขตย่อหน้า
- พิกัดย่อหน้า
- ขนาดย่อหน้า
- กรอบข้อความ
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีดึงขอบเขตย่อหน้าใน Aspose.Slides สำหรับ .NET เพื่อปรับตำแหน่งข้อความให้เหมาะสมในงานนำเสนอ PowerPoint"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการรับขอบเขต ขนาด และพิกัดของย่อหน้าใน Aspose.Slides มันแสดงวิธีดึงสี่เหลี่ยมผืนภายใต้ย่อหน้าจาก [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) โดยใช้ [IParagraph.GetRect](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/getrect/), วิธีรับพิกัดย่อหน้าใน text frame ของเซลล์ตาราง, และเน้นรายละเอียดสำคัญเช่นหน่วยการวัด ผลของการตัดบรรทัดต่อขอบเขต การแปลงเป็นพิกเซล และค่าการจัดรูปแบบย่อหน้าที่มีผล

## **รับพิกัดสี่เหลี่ยมของย่อหน้า**

ใช้ [IParagraph.GetRect](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/getrect/) เพื่อรับสี่เหลี่ยมขอบเขตของย่อหน้า

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];
var paragraph = shape.TextFrame.Paragraphs[0];
var rectangle = paragraph.GetRect();
```

## **รับขนาดของย่อหน้าภายใน TextFrame ของเซลล์ตาราง**

เพื่อรับขนาดและพิกัดของ [IParagraph](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/) ใน text frame ของเซลล์ตาราง ให้ใช้ [IParagraph.GetRect](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/getrect/) สี่เหลี่ยมที่คืนค่าจะอ้างอิงถึง text frame ของเซลล์ตาราง ดังนั้นให้เพิ่มตำแหน่งตารางและออฟเซตของเซลล์เมื่อคุณต้องการพิกัดระดับสไลด์

ตัวอย่างต่อไปนี้รับขอบเขตของย่อหน้าในเซลล์ตารางและวาดสี่เหลี่ยมบนสไลด์เพื่อแสดงขอบเขตเหล่านั้น:

```csharp
using var presentation = new Presentation("source.pptx");
var slide = presentation.Slides[0];
var table = (ITable)slide.Shapes[0];
var cell = table.Rows[1][1];

var cellX = table.X + cell.OffsetX;
var cellY = table.Y + cell.OffsetY;

foreach (var paragraph in cell.TextFrame.Paragraphs)
{
    if (string.IsNullOrEmpty(paragraph.Text))
        continue;

    var paragraphRectangle = paragraph.GetRect();
    var paragraphRectangleX = paragraphRectangle.X + (float)cellX;
    var paragraphRectangleY = paragraphRectangle.Y + (float)cellY;

    var paragraphBoundsShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.Width,
        paragraphRectangle.Height);

    paragraphBoundsShape.FillFormat.FillType = FillType.NoFill;
    paragraphBoundsShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
    paragraphBoundsShape.LineFormat.FillFormat.FillType = FillType.Solid;
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **FAQ**

**พิกัดของย่อหน้าถูกวัดเป็นหน่วยอะไร?**

พวกมันวัดเป็นหน่วยจุด (points) โดยที่ 1 นิ้วเท่ากับ 72 จุด ซึ่งใช้กับพิกัดและขนาดทั้งหมดบนสไลด์

**การตัดบรรทัดอัตโนมัติมีผลต่อขอบเขตของย่อหน้าหรือไม่?**

ใช่ หาก [TextFrameFormat.WrapText](https://reference.aspose.com/slides/th/net/aspose.slides/textframeformat/wraptext/) ถูกเปิดใช้สำหรับ [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) ข้อความจะตัดบรรทัดให้พอดีกับความกว้างของพื้นที่ ซึ่งจะทำให้ขอบเขตจริงของย่อหน้าเปลี่ยนแปลง

**พิกัดของย่อหน้าสามารถแมปเป็นพิกเซลในภาพที่ส่งออกได้อย่างน่าเชื่อถือหรือไม่?**

ได้ ใช้สูตรต่อไปนี้เพื่อแปลงจุดเป็นพิกเซล: pixels = points × (DPI / 72) ผลลัพธ์จะขึ้นอยู่กับค่า DPI ที่เลือกสำหรับการเรนเดอร์หรือการส่งออก

**ฉันจะรับพารามิเตอร์การจัดรูปแบบย่อหน้าแบบ “effective” ที่คำนึงถึงการสืบทอดสไตล์ได้อย่างไร?**

ใช้ [effective paragraph formatting data structure](/slides/th/net/shape-effective-properties/) ซึ่งจะส่งคืนค่าที่สรุปขั้นสุดท้ายสำหรับการเยื้อง การเว้นระยะ การตัดบรรทัด การจัดข้อความจากขวาไปซ้าย (RTL) และอื่น ๆ