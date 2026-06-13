---
title: ข้อความคณิตศาสตร์
type: docs
weight: 160
url: /th/net/examples/elements/math-text/
keywords:
- ข้อความคณิตศาสตร์
- เพิ่มข้อความคณิตศาสตร์
- เข้าถึงข้อความคณิตศาสตร์
- ลบข้อความคณิตศาสตร์
- จัดรูปแบบข้อความคณิตศาสตร์
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สำรวจตัวอย่าง MathematicalText ของ Aspose.Slides for .NET: สร้างและจัดรูปแบบสมการ, เศษส่วน, เมทริกซ์, และสัญลักษณ์ด้วย C# ในการนำเสนอ PPT, PPTX, และ ODP."
---
บทความนี้สาธิตการทำงานกับรูปแบบข้อความคณิตศาสตร์และการจัดรูปแบบสมการโดยใช้ **Aspose.Slides for .NET**.

## **เพิ่มข้อความคณิตศาสตร์**

สร้างรูปแบบคณิตศาสตร์ที่มีส่วนของเศษส่วนและสูตรพีทากอรัส.

```csharp
static void AddMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // เพิ่มรูปแบบ Math ลงในสไลด์.
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // เข้าถึงย่อหน้าคณิตศาสตร์.
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

    // เพิ่มเศษส่วนง่าย: x / y
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    // เพิ่มสมการ: c² = a² + b²
    var mathBlock = new MathematicalText("c")
        .SetSuperscript("2")
        .Join("=")
        .Join(new MathematicalText("a").SetSuperscript("2"))
        .Join("+")
        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);
}
```

## **เข้าถึงข้อความคณิตศาสตร์**

ค้นหารูปแบบที่มีย่อหน้าคณิตศาสตร์บนสไลด์.

```csharp
static void AccessMathText()
{
    using var presentation = new Presentation("sample.pptx");
    var slide = presentation.Slides[0];

    // ค้นหารูปแบบแรกที่มีย่อหน้าคณิตศาสตร์.
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // ตัวอย่าง: สร้างเศษส่วน (ไม่ได้เพิ่มที่นี่).
        var fraction = new MathematicalText("x").Divide("y");

        // ใช้ mathParagraph หรือ fraction ตามต้องการ...
    }
}
```

## **ลบข้อความคณิตศาสตร์**

ลบรูปแบบคณิตศาสตร์ออกจากสไลด์.

```csharp
static void RemoveMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var mathShape = slide.Shapes.AddMathShape(50, 50, 100, 50);
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    slide.Shapes.Remove(mathShape);
}
```

## **จัดรูปแบบข้อความคณิตศาสตร์**

ตั้งค่าคุณสมบัติตัวอักษรสำหรับส่วนของคณิตศาสตร์.

```csharp
static void FormatMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var mathShape = slide.Shapes.AddMathShape(50, 50, 100, 50);
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    mathShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 20;
}
```