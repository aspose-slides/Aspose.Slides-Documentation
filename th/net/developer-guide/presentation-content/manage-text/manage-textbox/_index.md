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
description: "สร้าง, ระบุ, จัดรูปแบบ, และอัปเดตกล่องข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides for .NET."
---
## **บทนำ**

ใน Aspose.Slides for .NET ข้อความสไลด์จะถูกเก็บในกรอบข้อความซึ่งเป็นส่วนหนึ่งของรูปร่าง อินเทอร์เฟซ [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) แสดงถึงรูปร่างที่มีข้อความทั่วไปที่สุดและเปิดเผยข้อความของมันผ่านคุณสมบัติ [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) 

{{% alert color="info" title="หมายเหตุ" %}}
รูปร่างอัตโนมัติทุกตัวจะทำการเขียนตามอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), แต่ไม่ใช่ทุกรูปร่างเป็นรูปร่างอัตโนมัติหรือสนับสนุนกรอบข้อความ เมื่อประมวลผลงานนำเสนอที่มีอยู่ ให้ตรวจสอบว่ารูปร่างทำการเขียนตาม `IAutoShape` ก่อนเข้าถึงข้อความของมัน.
{{% /alert %}}

## **สร้างกล่องข้อความบนสไลด์**

ในการสร้างกล่องข้อความ ให้เพิ่มรูปร่างอัตโนมัติลงบนสไลด์ เพิ่มข้อความลงในกรอบข้อความของมัน แล้วบันทึกงานนำเสนอ ตัวอย่างต่อไปนี้สร้างกล่องข้อความสี่เหลี่ยม:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

พิกัดและขนาดที่ส่งไปยัง [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) จะถูกวัดเป็นจุด [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) จะเริ่มต้นกรอบข้อความด้วยข้อความที่ได้รับ.

## **ตรวจสอบว่ารูปร่างเป็นกล่องข้อความหรือไม่**

ใช้คุณสมบัติ [AutoShape.IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) เพื่อตรวจสอบว่ารูปร่างอัตโนมัติถูกถือเป็นกล่องข้อความหรือไม่ สิ่งนี้มีประโยชน์เมื่องานนำเสนอมีทั้งรูปร่างที่มีข้อความและรูปร่างกราฟิกอย่างเดียว.

![กล่องข้อความและรูปร่าง](istextbox.png)

ตัวอย่างต่อไปนี้ตรวจสอบรูปร่างอัตโนมัติทุกตัวในงานนำเสนอ:

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

รูปร่างอัตโนมัติที่เพิ่มเข้ามาใหม่จะไม่ถูกพิจารณาว่าเป็นกล่องข้อความจนกว่าจะมีข้อความที่ไม่ว่างเปล่า คุณสามารถกำหนดข้อความนั้นผ่าน [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) หรือ [ITextFrame.Text](https://reference.aspose.com/slides/net/aspose.slides/itextframe/text/) การเพิ่มหรือกำหนดสตริงว่างจะทำให้ `IsTextBox` มีค่า `false`:

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

การเรียกสองครั้งแรกพิมพ์ `True`; สองครั้งสุดท้ายพิมพ์ `False`.

## **ค้นหารูปร่างที่เป็นเจ้าของกรอบข้อความ**

โค้ดประมวลผลข้อความทั่วไปอาจได้รับ [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) โดยไม่รู้ว่ามีวัตถุงานนำเสนอใดเป็นเจ้าของ ใช้คุณสมบัติอ่านอย่างเดียว [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) เพื่อย้อนกลับไปยัง [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) ที่เป็นเจ้าของ

สำหรับกรอบข้อความที่เป็นของรูปร่างอัตโนมัติหรือรูปร่างที่มีข้อความอื่น `ParentShape` จะบรรจุเจ้าของและ [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) จะเป็น `null` ตรวจสอบค่าที่คืนมาก่อนเข้าถึง เพื่อระบุทั้งเจ้าของรูปร่างและเซลล์ตาราง รวมถึงรูปร่างที่เชื่อมกับโหนด SmartArt ดู [Search and Replace Text](/slides/th/net/search-and-replace-text/)

## **รับสี่เหลี่ยมข้อความของรูปร่าง**

ตั้งแต่ Aspose.Slides for .NET 26.11, [ITextFrame.GetTextRect](https://reference.aspose.com/slides/net/aspose.slides/itextframe/gettextrect/) จะคืนพื้นที่ข้อความที่กำหนดโดยเรขาคณิตของรูปร่างแม่ พิกัดและขนาดอยู่ในหน่วยจุดและอิงจากมุมบนซ้ายของรูปร่างนั้น ตัวอย่างเช่น รูปวงรีจะมีสี่เหลี่ยมข้อความที่เล็กกว่าขอบนอกของมัน

สี่เหลี่ยมนี้อธิบายรูปร่าง ไม่ใช่อักขระที่เรนเดอร์ การเปลี่ยนข้อความหรือระยะขอบของกรอบข้อความไม่ทำให้มันกลายเป็นการวัดข้อความที่ครอบครอง ใช้ [paragraph bounds](/slides/th/net/paragraph-bounds/) หรือ [portion bounds](/slides/th/net/portion-bounds/) สำหรับการวัดข้อความที่เรนเดร

หลังจาก [installing Aspose.Slides for .NET](/slides/th/net/installation/) 26.11 หรือใหม่กว่า ให้รันตัวอย่างนี้เพื่อวาดสี่เหลี่ยมข้อความของเรขาคณิตด้วยสีแดง รูปร่างไม่มีการหมุนและไม่มีการจัดกลุ่ม ดังนั้นการเพิ่มตำแหน่ง X/Y ของพวกมันจึงเพียงพอที่จะวางภาพซ้อนบนสไลด์

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

foreach (var shapeType in new[] { ShapeType.Rectangle, ShapeType.Ellipse })
{
    var x = shapeType == ShapeType.Rectangle ? 50 : 300;
    var shape = slide.Shapes.AddAutoShape(shapeType, x, 200, 200, 100);
    shape.AddTextFrame("Text area");
    var rectangle = shape.TextFrame.GetTextRect();
    Console.WriteLine($"{shapeType}: {rectangle}");

    var overlayX = shape.X + rectangle.X;
    var overlayY = shape.Y + rectangle.Y;
    var outline = slide.Shapes.AddAutoShape(ShapeType.Rectangle, overlayX, overlayY, rectangle.Width, rectangle.Height);
    outline.FillFormat.FillType = FillType.NoFill;
    outline.LineFormat.FillFormat.FillType = FillType.Solid;
    outline.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
}

presentation.Save("text-rectangles.pptx", SaveFormat.Pptx);
```

สำหรับรูปร่างขนาด 200 × 100 จุดที่แสดงข้างต้น สี่เหลี่ยมจะคืนค่า `(0, 0, 200, 100)`; รูปวงรีประมาณ `(29.289, 14.645, 141.421, 70.711)` วิธีนี้ยังอ่านสี่เหลี่ยมข้อความที่ประกาศไว้ของเรขาคณิตย์ที่กำหนดเอง ไม่นำการหมุนของสไลด์หรือการแปลงกลุ่มมาใช้; ต้องคำนึงถึงเหล่านั้นแยกต่างหากเมื่อกำหนดตำแหน่งภาพซ้อน กรอบข้อความที่ไม่มีรูปร่างเรขาคณิตย์ เช่น กรอบข้อความในเซลล์ตาราง อาจทำให้เกิด `InvalidOperationException`.

## **เพิ่มคอลัมน์ให้กับกล่องข้อความ**

คุณสมบัติ [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/) แบ่งกรอบข้อความเป็นคอลัมน์, ส่วน [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/) ตั้งระยะห่างระหว่างคอลัมน์เป็นหน่วยจุด การตั้งค่าสองอย่างนี้เป็นของ [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/) และสามารถเปลี่ยนได้ผ่านกรอบข้อความของกล่องข้อความที่มีอยู่ ข้อความจะไหลใหม่ระหว่างคอลัมน์ภายในรูปร่างเดียวกัน ไม่ไหลต่อไปยังรูปร่างอื่น

ตัวอย่างต่อไปนี้สร้างกล่องข้อความสามคอลัมน์โดยมีช่องว่าง 10 จุดระหว่างคอลัมน์ บันทึกงานนำเสนอและอ่านการตั้งค่าที่เก็บไว้จากไฟล์ผลลัพธ์:

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

## **สกัดข้อความจากคอลัมน์แยกกัน**

ใช้ [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/net/aspose.slides/textframe/splittextbycolumns/) เพื่อดึงข้อความที่กำหนดให้แต่ละคอลัมน์แบบมองเห็นในกรอบข้อความที่มีอยู่ วิธีนี้คืนสตริงหนึ่งค่าต่อคอลัมน์ ตามลำดับการอ่านตามคอลัมน์ กรอบข้อความแบบคอลัมน์เดียวจะให้อาร์เรย์ที่มีหนึ่งรายการ และคอลัมน์ที่ว่างเปล่าจะแทนด้วยสตริงว่าง สตริงเหล่านี้มีเฉพาะข้อความธรรมดา; การฟอร์แมตระดับส่วน (portion) จะไม่ถูกรักษา

สิ่งนี้มีประโยชน์เมื่อคุณต้องการ:

- สกัดข้อความขณะรักษาลำดับการอ่านตามคอลัมน์ไว้
- ทำดัชนีหรือเปรียบเทียบเนื้อหาของสไลด์หลายคอลัมน์
- ส่งออกแต่ละคอลัมน์ไปยังไฟล์แยกต่างหาก, ฟิลด์ฐานข้อมูล หรือปลายทางอื่น
- ตรวจสอบว่าข้อความถูกแจกจ่ายใหม่อย่างไรหลังจากเปลี่ยน [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/), [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/), ฟอนต์ หรือขนาดของกรอบข้อความ

วิธีนี้รายงานข้อความที่กระจายอยู่ภายใน [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) ปัจจุบัน; มันไม่ไหลอัตโนมัติระหว่างรูปร่างหรือกล่องข้อความแยกต่างหาก การกระจายคอลัมน์อาจขึ้นกับฟอนต์ที่มีอยู่และการตั้งค่าเค้าโครงข้อความอื่นๆ ดังนั้นควรตรวจสอบว่าฟอนต์ที่ต้องการพร้อมใช้งานเมื่อผลลัพธ์ที่สม่ำเสมอสำคัญ

ตัวอย่างต่อไปนี้โหลดงานนำเสนอ, ค้นหาอัตโนมัติรูปร่างหลายคอลัมน์แรกที่มีกรอบข้อความ, อ่านจำนวนคอลัมน์ที่ตั้งค่า, แล้วเขียนข้อความจากทุกคอลัมน์ลงในไฟล์แยก รูปร่างที่ไม่มีกรอบข้อความจะถูกข้าม

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

เพื่ออัปเดตข้อความทั่วทั้งงานนำเสนอ ให้วนลูปผ่านสไลด์และรูปร่าง, เลือกรูปร่างอัตโนมัติ, แล้วแก้ไขส่วนข้อความของพวกมัน การทำงานระดับส่วนทำให้คุณสามารถเปลี่ยนข้อความและการฟอร์แมตของอักขระได้พร้อมกัน

ตัวอย่างต่อไปนี้แทนที่ทุกครั้งของ `years` ด้วย `months` ในข้อความของรูปร่างอัตโนมัติและทำให้ส่วนที่ได้รับผลกระทบเป็นตัวหนา:

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

การวนลูปนี้อัปเดตข้อความเฉพาะในรูปร่างอัตโนมัติ ข้อความที่เก็บในตาราง, แผนภูมิ, SmartArt หรือรูปร่างเป็นกลุ่มต้องการการวนลูปผ่านคอลเลกชันของวัตถุเหล่านั้นเอง

## **เพิ่มกล่องข้อความพร้อมลิงก์**

ลิงก์สามารถกำหนดให้กับส่วนข้อความเฉพาะได้ ดังนั้นเฉพาะข้อความนั้นจะทำหน้าที่เป็นลิงก์ที่คลิกได้ ใช้ [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) เพื่อเชื่อมต่อส่วนกับ URL ภายนอก

ตัวอย่างต่อไปนี้สร้างข้อความที่เชื่อมโยงและบันทึกลงในงานนำเสนอ:

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

**กล่องข้อความกับตัวแทนตำแหน่งข้อความบนสไลด์แม่หรือแบบเลย์เอาต์ต่างกันอย่างไร?**

ตัว [placeholder](/slides/th/net/manage-placeholder/) สามารถสืบทอดตำแหน่งและการจัดรูปแบบจาก [master slide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) หรือ [layout slide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) สไลด์ปกติเป็นรูปร่างอิสระบนสไลด์ที่สร้างขึ้นและจะไม่รับพฤติกรรมตัวแทนตำแหน่งเมื่อรูปแบบเปลี่ยนแปลง.

**ฉันจะทำให้ข้อความถูกแทนที่โดยไม่กระทบข้อความในแผนภูมิ, ตาราง หรือ SmartArt อย่างไร?**

จำกัดการวนลูปให้กับรูปร่างที่ทำตาม [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ตามที่แสดงในตัวอย่างอัปเดตข้อความ แผนภูมิ, ตาราง, และ SmartArt เก็บข้อความในโมเดลวัตถุของตนเอง ดังนั้นจึงไม่ถูกแก้ไขโดยลูปนั้น.