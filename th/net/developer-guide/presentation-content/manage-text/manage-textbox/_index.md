---
title: จัดการกล่องข้อความในงานนำเสนอใน .NET
linktitle: จัดการกล่องข้อความ
type: docs
weight: 20
url: /th/net/manage-textbox/
keywords:
- กล่องข้อความ
- กรอบข้อความ
- เพิ่มข้อความ
- อัปเดตข้อความ
- สร้างกล่องข้อความ
- ตรวจสอบกล่องข้อความ
- เพิ่มคอลัมน์ข้อความ
- เพิ่มไฮเปอร์ลิงก์
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สร้าง, ระบุ, จัดรูปแบบ, และอัปเดตกล่องข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides สำหรับ .NET."
---
## **บทนำ**

ใน Aspose.Slides for .NET ข้อความบนสไลด์จะถูกเก็บไว้ในกรอบข้อความที่เป็นส่วนหนึ่งของรูปร่าง อินเทอร์เฟซ [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) แสดงถึงรูปร่างที่มีข้อความบ่อยที่สุดและเปิดเผยข้อความของมันผ่านคุณสมบัติ [IAutoShape.TextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/textframe/)。

{{% alert color="info" title="Note" %}}
รูปร่างอัตโนมัติทุกตัวทำการ implements [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/) แต่ไม่ใช่รูปร่างทุกตัวเป็นรูปร่างอัตโนมัติหรือรองรับกรอบข้อความ เมื่อตรวจสอบการประมวลผลพรีเซนเทชันที่มีอยู่ ให้ตรวจสอบว่ารูปร่างทำการ implements `IAutoShape` ก่อนเข้าถึงข้อความของมัน.
{{% /alert %}}

## **สร้างกล่องข้อความบนสไลด์**

เพื่อสร้างกล่องข้อความ ให้เพิ่มรูปร่างอัตโนมัติลงในสไลด์ เพิ่มข้อความในกรอบข้อความของมัน และบันทึกพรีเซนเทชัน ตัวอย่างต่อไปนี้สร้างกล่องข้อความสี่เหลี่ยมผืนผ้า:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

พิกัดและมิติที่ส่งไปยัง [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/addautoshape/) จะวัดเป็นหน่วย point. [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/addtextframe/) จะเริ่มต้นกรอบข้อความด้วยข้อความที่ระบุ.

## **ตรวจสอบรูปร่างเป็นกล่องข้อความ**

ใช้คุณสมบัติ [AutoShape.IsTextBox](https://reference.aspose.com/slides/th/net/aspose.slides/autoshape/istextbox/) เพื่อกำหนดว่ารูปร่างอัตโนมัติได้รับการจัดให้เป็นกล่องข้อความหรือไม่ สิ่งนี้มีประโยชน์เมื่อพรีเซนเทชันมีทั้งรูปร่างอัตโนมัติที่มีข้อความและรูปร่างกราฟิกอย่างเดียว

![กล่องข้อความและรูปร่าง](istextbox.png)

ตัวอย่างต่อไปนี้ตรวจสอบรูปร่างอัตโนมัติทุกตัวในพรีเซนเทชัน:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
textBox.AddTextFrame("Text box");
slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

foreach (var currentSlide in presentation.Slides)
{
    foreach (var shape in currentSlide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "The shape is a text box." : "The shape is not a text box.");
        }
    }
}
```

รูปร่างอัตโนมัติที่เพิ่งเพิ่มใหม่จะไม่ถือว่าเป็นกล่องข้อความจนกว่าจะมีข้อความที่ไม่ว่างเปล่า คุณสามารถใส่ข้อความนั้นผ่าน [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/addtextframe/) หรือ [ITextFrame.Text](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/text/) การเพิ่มหรือกำหนดสตริงว่างจะทำให้ `IsTextBox` มีค่าเป็น `false`:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
shape1.AddTextFrame("Shape 1");
Console.WriteLine(shape1.IsTextBox);

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
shape2.TextFrame.Text = "Shape 2";
Console.WriteLine(shape2.IsTextBox);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
shape3.AddTextFrame("");
Console.WriteLine(shape3.IsTextBox);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
shape4.TextFrame.Text = "";
Console.WriteLine(shape4.IsTextBox);
```

สองการเรียกแรกพิมพ์ค่า `True`; สองการเรียกสุดท้ายพิมพ์ค่า `False`.

## **ค้นหารูปร่างที่เป็นเจ้าของกรอบข้อความ**

โค้ดการประมวลผลข้อความทั่วไปอาจได้รับ [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) โดยไม่ทราบว่าออบเจกต์พรีเซนเทชันใดเป็นเจ้าของ ใช้คุณสมบัติแบบอ่านอย่างเดียว [ITextFrame.ParentShape](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/parentshape/) เพื่อนำทางกลับไปยัง [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/) ที่เป็นเจ้าของของมัน

สำหรับกรอบข้อความที่เป็นของรูปร่างอัตโนมัติหรือรูปร่างที่มีข้อความอื่น `ParentShape` จะมีเจ้าของและ [ITextFrame.ParentCell](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/parentcell/) จะเป็น `null` ตรวจสอบค่าที่ส่งคืนก่อนเข้าถึง เพื่อระบุทั้งเจ้าของรูปร่างและเซลล์ตาราง รวมถึงรูปร่างที่เชื่อมกับโหนด SmartArt ดูที่ [Search and Replace Text](/slides/th/net/search-and-replace-text/).

## **เพิ่มคอลัมน์ให้กับกล่องข้อความ**

คุณสมบัติ [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat/columncount/) แบ่งกรอบข้อความเป็นคอลัมน์ ส่วน [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat/columnspacing/) ตั้งค่าระยะห่างระหว่างคอลัมน์เป็นหน่วย point การตั้งค่าสองอย่างนี้เป็นส่วนของ [ITextFrameFormat](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat/) และสามารถเปลี่ยนได้ผ่านกรอบข้อความของกล่องข้อความที่มีอยู่แล้ว ข้อความจะไหลใหม่ระหว่างคอลัมน์ภายในรูปร่างเดียวกัน; จะไม่ต่อไปยังรูปร่างอื่น

ตัวอย่างต่อไปนี้สร้างกล่องข้อความสามคอลัมน์โดยมีระยะห่าง 10 point ระหว่างคอลัมน์, บันทึกพรีเซนเทชัน, และอ่านการตั้งค่าที่เก็บไว้จากไฟล์ผลลัพธ์:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
textBox.AddTextFrame("This text is distributed automatically across all columns in the text box.");

var textFrameFormat = textBox.TextFrame.TextFrameFormat;
textFrameFormat.ColumnCount = 3;
textFrameFormat.ColumnSpacing = 10;

presentation.Save("TextBoxColumns.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("TextBoxColumns.pptx");
var savedTextBox = (IAutoShape)savedPresentation.Slides[0].Shapes[0];
var savedFormat = savedTextBox.TextFrame.TextFrameFormat;
Console.WriteLine($"Columns: {savedFormat.ColumnCount}; spacing: {savedFormat.ColumnSpacing} points");
```

## **สกัดข้อความจากคอลัมน์แต่ละคอลัมน์**

ใช้ [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/th/net/aspose.slides/textframe/splittextbycolumns/) เพื่อดึงข้อความที่กำหนดให้แต่ละคอลัมน์ที่มองเห็นได้ในกรอบข้อความที่มีอยู่ วิธีการนี้คืนค่า string หนึ่งสำหรับแต่ละคอลัมน์ตามลำดับการอ่านแบบคอลัมน์ กรอบข้อความแบบคอลัมน์เดียวจะผลิตอาเรย์ที่มีองค์ประกอบหนึ่ง และคอลัมน์ที่ว่างเปล่าจะเป็นสตริงว่าง ข้อความที่คืนมาจะเป็นข้อความธรรมดาเท่านั้น; การจัดรูปแบบระดับส่วนจะไม่ถูกเก็บรักษา

สิ่งนี้มีประโยชน์เมื่อคุณต้องการ:
- สกัดข้อความพร้อมคงลำดับการอ่านแบบคอลัมน์
- ทำดัชนีหรือเปรียบเทียบเนื้อหาของสไลด์หลายคอลัมน์
- ส่งออกแต่ละคอลัมน์เป็นไฟล์แยก, ฟิลด์ฐานข้อมูล, หรือเป้าหมายอื่น
- ตรวจสอบว่าข้อความถูกกระจายใหม่อย่างไรหลังจากเปลี่ยน [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat/columncount/), [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat/columnspacing/), ฟอนต์, หรือขนาดของกรอบข้อความ

วิธีการนี้รายงานข้อความที่กระจายใน [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) ปัจจุบัน; มันจะไม่ได้ไหลข้อความอัตโนมัติระหว่างรูปร่างหรือกล่องข้อความแยกต่างหาก การกระจายคอลัมน์อาจขึ้นกับฟอนต์ที่มีและการตั้งค่าเลย์เอาต์ข้อความอื่นๆ ดังนั้นควรตรวจสอบว่าฟอนต์ที่ต้องการพร้อมใช้งานเมื่อผลลัพธ์ที่สอดคล้องกันเป็นสิ่งสำคัญ

ตัวอย่างต่อไปนี้โหลดพรีเซนเทชัน, ค้นหารูปร่างอัตโนมัติหลายคอลัมน์แรกที่มีกรอบข้อความ, อ่านจำนวนคอลัมน์ที่กำหนด, และเขียนข้อความจากแต่ละคอลัมน์เป็นไฟล์แยก รูปร่างที่ไม่มีกรอบข้อความจะถูกข้าม

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("MultiColumnText.pptx");

IAutoShape? textBox = null;
foreach (var shape in presentation.Slides[0].Shapes)
{
    if (shape is IAutoShape autoShape && autoShape.TextFrame is not null)
    {
        var columnCount = autoShape.TextFrame.TextFrameFormat.ColumnCount;
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox is null)
{
    Console.WriteLine("No multi-column text frame was found.");
}
else
{
    var textFrame = textBox.TextFrame;
    var configuredColumnCount = textFrame.TextFrameFormat.ColumnCount;
    var columnTexts = textFrame.SplitTextByColumns();

    Console.WriteLine($"Configured columns: {configuredColumnCount}");

    for (var columnIndex = 0; columnIndex < columnTexts.Length; columnIndex++)
    {
        var columnNumber = columnIndex + 1;
        var columnText = columnTexts[columnIndex];
        Console.WriteLine($"Column {columnNumber}: {columnText}");
        File.WriteAllText($"Column-{columnNumber}.txt", columnText);
    }
}
```

## **อัปเดตข้อความ**

เพื่ออัปเดตข้อความทั่วทั้งพรีเซนเทชัน ให้วนผ่านสไลด์และรูปร่าง, เลือกรูปร่างอัตโนมัติ, แล้วแก้ไขส่วนข้อความของพวกมัน การทำงานระดับส่วนช่วยให้คุณเปลี่ยนทั้งข้อความและการจัดรูปแบบตัวอักษร

ตัวอย่างต่อไปนี้แทนที่ทุกการปรากฏของ `years` ด้วย `months` ในข้อความของรูปร่างอัตโนมัติและทำให้ส่วนที่ได้รับผลกระทบทั้งหมดเป็นตัวหนา:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Text.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape)
        {
            continue;
        }

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                portion.Text = portion.Text.Replace("years", "months");
                portion.PortionFormat.FontBold = NullableBool.True;
            }
        }
    }
}

presentation.Save("TextChanged.pptx", SaveFormat.Pptx);
```

การวนนี้อัปเดตข้อความเฉพาะในรูปร่างอัตโนมัติ ข้อความที่จัดเก็บในตาราง, แผนภูมิ, SmartArt, หรือรูปร่างที่จัดกลุ่มต้องการการวนผ่านคอลเลกชันของออบเจกต์เหล่านั้น

## **เพิ่มกล่องข้อความพร้อมไฮเปอร์ลิงก์**

ไฮเปอร์ลิงก์สามารถกำหนดให้กับส่วนข้อความเฉพาะได้ ดังนั้นจึงเป็นข้อความนั้นเท่านั้นที่ทำหน้าที่เป็นลิงก์ที่คลิกได้ ใช้ [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) เพื่อลิงก์ส่วนนั้นกับ URL ภายนอก

ตัวอย่างต่อไปนี้สร้างข้อความที่มีลิงก์และบันทึกลงในพรีเซนเทชัน:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
textBox.AddTextFrame("Aspose.Slides");

var textPortion = textBox.TextFrame.Paragraphs[0].Portions[0];
textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com/");

presentation.Save("Hyperlink.pptx", SaveFormat.Pptx);
```

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างกล่องข้อความและตัวแบบข้อความบนสไลด์มาสเตอร์หรือเลย์เอาต์คืออะไร?**

[placeholder](/slides/th/net/manage-placeholder/) สามารถสืบทอดตำแหน่งและการจัดรูปแบบจาก [master slide](https://reference.aspose.com/slides/th/net/aspose.slides/masterslide/) หรือ [layout slide](https://reference.aspose.com/slides/th/net/aspose.slides/layoutslide/) กล่องข้อความธรรมดาเป็นรูปร่างอิสระบนสไลด์ที่สร้างขึ้นและจะไม่รับพฤติกรรมของ placeholder เมื่อตัวแบบมีการเปลี่ยนแปลง

**ฉันจะทำอย่างไรเพื่อตัวแทนข้อความโดยไม่เปลี่ยนข้อความในแผนภูมิ, ตาราง, หรือ SmartArt?**

จำกัดการวนเพียงรูปร่างที่ทำการ implements [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ตามที่แสดงในตัวอย่างอัปเดตข้อความ แผนภูมิ, ตาราง, และ SmartArt เก็บข้อความในโมเดลออบเจกต์ของตัวเอง ดังนั้นพวกมันจะไม่ถูกแก้ไขโดยลูปนั้น