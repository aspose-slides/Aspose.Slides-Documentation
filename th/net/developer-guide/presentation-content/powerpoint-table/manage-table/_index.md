---
title: จัดการตารางการนำเสนอใน .NET
linktitle: จัดการตาราง
type: docs
weight: 10
url: /th/net/manage-table/
keywords:
- เพิ่มตาราง
- สร้างตาราง
- เข้าถึงตาราง
- อัตราส่วนรูปร่าง
- จัดแนวข้อความ
- การจัดรูปแบบข้อความ
- สไตล์ตาราง
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สร้างและแก้ไขตารางในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ .NET ค้นหาตัวอย่างโค้ด C# อย่างง่ายเพื่อทำให้กระบวนการทำงานกับตารางของคุณเป็นระบบยิ่งขึ้น"
---
## **บทนำ**

ตารางใน PowerPoint จัดระเบียบข้อมูลเป็นแถวและคอลัมน์ ทำให้อ่านและเปรียบเทียบค่าได้ง่ายขึ้น.

Aspose.Slides มีคลาส [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) , อินเตอร์เฟซ [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) , คลาส [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/) , อินเตอร์เฟซ [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) และประเภทอื่น ๆ เพื่อให้คุณสร้าง, อัปเดตและจัดการตารางในงานนำเสนอ.

## **สร้างตารางจากศูนย์**

สร้างตารางโดยระบุตำแหน่ง, ความกว้างของคอลัมน์, และความสูงของแถว หลังจากเพิ่มลงในสไลด์ คุณสามารถจัดรูปแบบขอบเซลล์, รวมเซลล์, และแทรกข้อความได้.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. รับการอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน.
3. กำหนดอาเรย์ของความกว้างคอลัมน์เป็นหน่วยพอยท์.
4. กำหนดอาเรย์ของความสูงแถวเป็นหน่วยพอยท์.
5. เพิ่มออบเจ็กต์ [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) ลงในสไลด์โดยใช้เมธอด [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
6. วนผ่านแต่ละ [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) เพื่อนำการจัดรูปแบบไปที่ขอบบน, ล่าง, ขวา, และซ้าย.
7. รวมสองเซลล์แรกของแถวแรกของตาราง.
8. เข้าถึงเซลล์ที่รวมแล้วผ่านคุณสมบัติ [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/).
9. ตั้งค่าข้อความในเซลล์ที่รวม.
10. บันทึกงานนำเสนอที่แก้ไขแล้ว.

ตัวอย่างด้านล่างสร้างตารางที่มีสามคอลัมน์และห้าแถวที่ตำแหน่ง (100, 50) พอยท์ ใช้ขอบสีแดงความกว้าง 5 พอยท์ รวมสองเซลล์แรกในแถวแรกและบันทึกผลลัพธ์เป็น `table.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

table.MergeCells(table[0, 0], table[1, 0], false);
table[0, 0].TextFrame.Text = "Merged Cells";

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **การจัดหมายเลขในตารางมาตรฐาน**

ในตารางมาตรฐาน, ดัชนีเซลล์เริ่มจากศูนย์และใช้ลำดับ (คอลัมน์, แถว) เซลล์แรกมีดัชนีเป็น (0, 0).

ตัวอย่างเช่น, เซลล์ในตารางที่มี 4 คอลัมน์และ 4 แถวจะถูกจัดหมายเลขดังนี้:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

ตัวอย่างนี้สร้างตาราง 4 × 4 ตามที่แสดงด้านบน, โดยความกว้างคอลัมน์และความสูงแถวเป็น 70 พอยท์และขอบเซลล์สีแดงความกว้าง 5 พอยท์ พิกัดแสดงดัชนีเซลล์; ตัวอย่างนี้เว้นเซลล์ไว้เป็นค่าว่างและบันทึกตารางเป็น `StandardTables_out.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 70, 70, 70, 70 };
var rowHeights = new double[] { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

presentation.Save("StandardTables_out.pptx", SaveFormat.Pptx);
```

## **เข้าถึงตารางที่มีอยู่**

ตารางจะถูกจัดเก็บในคอลเลกชันรูปทรงของสไลด์. วนผ่านรูปทรงเพื่อค้นหาตาราง, แล้วใช้อินเตอร์เฟซ [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) เพื่ออ่านหรืออัปเดตเซลล์ของมัน.

1. โหลดงานนำเสนอโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. รับการอ้างอิงสไลด์ที่มีตารางโดยใช้ดัชนีของมัน.
3. วนผ่านออบเจ็กต์ [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) และหยุดเมื่อพบตาราง หากสไลด์มีหลายตาราง ให้ใช้ [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/) เพื่อระบุตารางที่ต้องการ.
4. อัปเดตข้อความในเซลล์เป้าหมาย.
5. บันทึกงานนำเสนอที่แก้ไข.

ตัวอย่างด้านล่างเปิดไฟล์ `UpdateExistingTable.pptx` และค้นหาตารางแรกบนสไลด์แรก มันตั้งค่าเซลล์ที่คอลัมน์ 0, แถว 1 เป็น `New` และบันทึกผลลัพธ์เป็น `table1_out.pptx` อินพุตต้องมีอย่างน้อยหนึ่งสไลด์และตารางแรกบนสไลด์นั้นต้องมีอย่างน้อยหนึ่งคอลัมน์และสองแถว.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("UpdateExistingTable.pptx");
var slide = presentation.Slides[0];
ITable? table = null;

foreach (var shape in slide.Shapes)
{
    if (shape is ITable candidateTable)
    {
        table = candidateTable;
        break;
    }
}

table![0, 1].TextFrame.Text = "New";

presentation.Save("table1_out.pptx", SaveFormat.Pptx);
```

To resize a row in an existing table and understand why its actual height can exceed the requested minimum, see [Control Row Height](/slides/th/net/manage-rows-and-columns/#control-row-height).

## **ค้นหาเซลล์ที่เป็นเจ้าของ Text Frame**

เมื่อโค้ดประมวลผลข้อความทั่วไปได้รับออบเจ็กต์ [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) จากตาราง ให้ใช้คุณสมบัติ [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) เพื่อดึง [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) เจ้าของ สำหรับ Text Frame ของเซลล์ตาราง, [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) จะถูกตั้งค่าและ [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) จะเป็น `null` แม้ว่าตารางเองเป็นรูปทรง.

พิกัดเซลล์สามารถเข้าถึงได้ผ่านคุณสมบัติอ่านอย่างเดียว [ICell.FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) และ [ICell.FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/). [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) ยังเป็นอ่านอย่างเดียว: มันให้การนำทางไปยังเจ้าของแต่ไม่เปลี่ยนความเป็นเจ้าของ ควรตรวจสอบเซลล์ที่คืนค่าว่าเป็น `null` ก่อนใช้งานเสมอ.

สำหรับตัวอย่างสมบูรณ์ที่ระบุเจ้าของเซลล์ตารางและรูปทรง รวมถึงรูปทรงที่เชื่อมโยงกับโหนด SmartArt ให้ดูที่ [Search and Replace Text](/slides/th/net/search-and-replace-text/).

## **จัดแนวข้อความในตาราง**

คุณสามารถควบคุมการยึดแนวตั้งและทิศทางข้อความของเซลล์ตารางแต่ละเซลล์ ตัวอย่างในส่วนนี้ทำให้ข้อความอยู่กลางในเซลล์แรกและหมุน 270 องศา.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. รับการอ้างอิงสไลด์โดยใช้ดัชนีของมัน.
3. เพิ่มออบเจ็กต์ [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) ลงในสไลด์.
4. เข้าถึงออบเจ็กต์ [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) จากตาราง.
5. เข้าถึง [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) ตัวแรกและตั้งข้อความและสีของมัน.
6. ตั้งค่า [TextAnchorType](https://reference.aspose.com/slides/net/aspose.slides/icell/textanchortype/) และ [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/icell/textverticaltype/) ของเซลล์.
7. บันทึกงานนำเสนอที่แก้ไข.

ตัวอย่างนี้สร้างตาราง 4 × 4 โดยความกว้างคอลัมน์ 120 พอยท์และความสูงแถว 100 พอยท์ จัดรูปแบบข้อความในเซลล์ (0, 0), เพิ่มค่าให้เซลล์ที่เหลือในแถวแรก, และบันทึกผลลัพธ์เป็น `Vertical_Align_Text_out.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 120, 120, 120, 120 };
var rowHeights = new double[] { 100, 100, 100, 100 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);
table[1, 0].TextFrame.Text = "10";
table[2, 0].TextFrame.Text = "20";
table[3, 0].TextFrame.Text = "30";

var cell = table[0, 0];
var paragraph = cell.TextFrame.Paragraphs[0];
var portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **ตั้งค่าการจัดรูปแบบข้อความระดับตาราง**

ใช้ [SetTextFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulktextformattable/settextformat/) เพื่อใช้การจัดรูปแบบข้อความกับเซลล์ทั้งหมดในตาราง. การโอเวอร์โหลดของมันรับการจัดรูปแบบส่วน, ย่อหน้า, และ Text Frame, ดังนั้นคุณสามารถตั้งค่าคุณลักษณะเหล่านี้โดยไม่ต้องวนผ่านเซลล์แต่ละเซลล์.

1. โหลดงานนำเสนอโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. รับการอ้างอิงสไลด์โดยใช้ดัชนีของมัน.
3. เข้าถึงออบเจ็กต์ [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) จากสไลด์.
4. ตั้งค่า [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) สำหรับข้อความ.
5. ตั้งค่า [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) และ [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/).
6. ตั้งค่า [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/).
7. บันทึกงานนำเสนอที่แก้ไข.

ตัวอย่างด้านล่างเปิดไฟล์ `table.pptx` ซึ่งต้องมีอย่างน้อยหนึ่งสไลด์ที่มีตารางเป็นรูปทรงแรก มันตั้งขนาดฟอนต์เป็น 25 พอยท์, จัดย่อหน้าทางขวาด้วยขอบขวา 20 พอยท์, และทำให้ข้อความตั้งแนวตั้ง. งานนำเสนอที่จัดรูปแบบแล้วจะถูกบันทึกเป็น `result.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
table.SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
table.SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
table.SetTextFormat(textFrameFormat);

presentation.Save("result.pptx", SaveFormat.Pptx);
```

## **รับคุณสมบัติสไตล์ของตาราง**

ใช้ [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) เพื่ออ่านหรือกำหนดสไตล์ preset ของตาราง ตัวอย่างนี้ใช้ [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/) กับตารางหนึ่ง, พิมพ์ชื่อ preset, แล้วกำหนด preset เดียวกันให้กับตารางที่สอง ตารางทั้งสองถูกบันทึกใน `table-style.pptx`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 150 };
var rowHeights = new double[] { 5, 5, 5 };
var table = slide.Shapes.AddTable(10, 10, columnWidths, rowHeights);
table.StylePreset = TableStylePreset.DarkStyle1;

var stylePreset = table.StylePreset;
Console.WriteLine($"Table style preset: {stylePreset}");

var anotherTable = slide.Shapes.AddTable(10, 100, columnWidths, rowHeights);
anotherTable.StylePreset = stylePreset;

presentation.Save("table-style.pptx", SaveFormat.Pptx);
```

## **ล็อกอัตราส่วนของตาราง**

อัตราส่วนของตารางคืออัตราส่วนระหว่างความกว้างและความสูงของมัน ใช้ [AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/aspectratiolocked/) เพื่อล็อกอัตราส่วนนี้สำหรับตาราง.

ตัวอย่างนี้เปิดไฟล์ `pres.pptx` ซึ่งต้องมีอย่างน้อยหนึ่งสไลด์ที่มีตารางเป็นรูปทรงแรก มันพิมพ์สถานะล็อกปัจจุบัน, เปิดการล็อกอัตราส่วน, พิมพ์สถานะที่อัปเดต (`True`), และบันทึกผลลัพธ์เป็น `pres-out.pptx`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

table.ShapeLock.AspectRatioLocked = true;
Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

presentation.Save("pres-out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Can I enable right-to-left (RTL) reading direction for an entire table and the text in its cells?**  
ใช่. ตารางมีคุณสมบัติ [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/) และย่อหน้ามี [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/). การใช้ทั้งสองจะทำให้ลำดับ RTL และการเรนเดอร์ภายในเซลล์ถูกต้อง.

**How can I prevent users from moving or resizing a table in the final file?**  
ใช้ [shape locks](/slides/th/net/applying-protection-to-presentation/) เพื่อปิดการย้าย, ปรับขนาด, การเลือก ฯลฯ การล็อกเหล่านี้ยังใช้กับตารางด้วย.

**Is inserting an image inside a cell as a background supported?**  
ใช่. คุณสามารถตั้งค่า [picture fill](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) สำหรับเซลล์; ภาพจะครอบพื้นที่เซลล์ตามโหมดที่เลือก (stretch หรือ tile).