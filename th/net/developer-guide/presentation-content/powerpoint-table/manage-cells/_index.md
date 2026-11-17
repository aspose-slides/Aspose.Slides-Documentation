---
title: จัดการเซลล์ตารางในงานนำเสนอด้วย .NET
linktitle: จัดการเซลล์
type: docs
weight: 30
url: /th/net/manage-cells/
keywords:
- เซลล์ตาราง
- รวมเซลล์
- ลบเส้นขอบ
- แยกเซลล์
- ภาพในเซลล์
- สีพื้นหลัง
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "จัดการเซลล์ตาราง PowerPoint ด้วย C#: ระบุเซลล์ที่รวมกัน, ลบเส้นขอบ, แยกเซลล์, และตั้งค่าสีพื้นหลังและภาพด้วย Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

Aspose.Slides ให้คุณเข้าถึงและแก้ไขเซลล์ตารางในงานนำเสนอ PowerPoint บทความนี้อธิบายวิธีระบุเซลล์ตารางที่รวมกัน, ลบเส้นขอบเซลล์, ทำงานกับหมายเลขเซลล์หลังจากการรวมหรือแยกเซลล์, เปลี่ยนสีพื้นหลังของเซลล์, และเพิ่มรูปภาพภายในเซลล์ตาราง ตัวอย่างแสดงวิธีสร้างหรือเปิดงานนำเสนอ, ดึงตารางจากสไลด์, ปรับรูปแบบเซลล์ผ่านคุณสมบัติของเซลล์, และบันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

Aspose.Slides ใช้ดัชนีที่เริ่มจากศูนย์เพื่อเข้าถึงเซลล์ตารางในลำดับ `(column, row)`.

## **ระบุเซลล์ตารางที่รวมกัน**

ตัวอย่างเปิดงานนำเสนอที่มีอยู่และเข้าถึงรูปร่างแรกบนสไลด์แรกเป็นตาราง โดยสมมติว่ามีสไลด์และรูปร่างอยู่และรูปร่างเป็นตาราง จากนั้นวนลูปผ่านแถวและคอลัมน์ทั้งหมดและใช้ [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) เพื่อระบุเซลล์ในพื้นที่ที่รวมกัน สำหรับแต่ละการจับคู่จะพิมพ์พิกัดเซลล์ในลำดับ `row;column`, [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/), และพิกัดเริ่มต้นของพื้นที่, [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) และ [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_table.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var rowCount = table.Rows.Count;
for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    var columnCount = table.Columns.Count;
    for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        var cell = table[columnIndex, rowIndex];
        if (cell.IsMergedCell)
        {
            Console.WriteLine($"Cell {rowIndex};{columnIndex} belongs to a merged region with RowSpan={cell.RowSpan} and ColSpan={cell.ColSpan} starting at {cell.FirstRowIndex};{cell.FirstColumnIndex}.");
        }
    }
}
```

## **ลบเส้นขอบเซลล์ตาราง**

สร้าง [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) และเพิ่มตารางไปยังสไลด์แรกด้วย [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) ความกว้างคอลัมน์, ความสูงแถว, และตำแหน่งตารางระบุเป็นพอยต์ ตัวอย่างตั้งค่าเส้นขอบสี่ด้านของเซลล์เป็น [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/) ทำให้เส้นขอบไม่ปรากฏ

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 50, 50, 50, 50 };
double[] rowHeights = { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
    foreach (var cell in row)
    {
        cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
    }

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **เพิ่มเส้นขอบทแยงมุมของเซลล์**

ใช้ [BorderDiagonalDown](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonaldown/) เพื่อวาดเส้นจากมุมซ้ายบนไปมุมขวาล่าง, และ [BorderDiagonalUp](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonalup/) เพื่อวาดเส้นจากมุมซ้ายล่างไปมุมขวาบน เส้นทแยงมุมสามารถระบุหัวข้อมุม; เส้นทแยงมุมสองเส้นสามารถสร้างรูป X เพื่อบ่งบอกว่าเซลล์ไม่ใช้ได้

แต่ละเส้นทแยงมุมเป็น [ILineFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/). ใน [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) ตั้งค่า [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) เป็น [FillType.Solid](https://reference.aspose.com/slides/net/aspose.slides/filltype/) แล้วเลือก [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/). ตั้งค่า [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) ของเส้นในหน่วยพอยต์

ตัวอย่างสร้างสามเซลล์ในหนึ่งแถว: เส้นทแยงมุมสีแดงลง, เส้นทแยงมุมสีฟ้า lên, และทั้งสองเส้นทแยงมุม คงเส้นขอบด้านบน, ด้านล่าง, ด้านซ้าย, และด้านขวาไว้ตามเดิม

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 210, 210, 210 };
double[] rowHeights = { 160 };
var table = slide.Shapes.AddTable(45, 130, columnWidths, rowHeights);

var downwardBorder = table[0, 0].CellFormat.BorderDiagonalDown;
downwardBorder.FillFormat.FillType = FillType.Solid;
downwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
downwardBorder.Width = 3;

var upwardBorder = table[1, 0].CellFormat.BorderDiagonalUp;
upwardBorder.FillFormat.FillType = FillType.Solid;
upwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
upwardBorder.Width = 5;

var crossDownwardBorder = table[2, 0].CellFormat.BorderDiagonalDown;
crossDownwardBorder.FillFormat.FillType = FillType.Solid;
crossDownwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
crossDownwardBorder.Width = 3;

var crossUpwardBorder = table[2, 0].CellFormat.BorderDiagonalUp;
crossUpwardBorder.FillFormat.FillType = FillType.Solid;
crossUpwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
crossUpwardBorder.Width = 5;

presentation.Save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
```

เส้นทแยงมุมเป็นคุณสมบัติการจัดรูปแบบ, ไม่ใช่การแยกเซลล์ แต่ละเซลล์ยังคงมี [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) เพียงอันเดียว; พื้นที่ที่อยู่ด้านใดด้านหนึ่งของเส้นทแยงมุมไม่สามารถแก้ไขแยกกันได้

ตารางที่บันทึกไว้, แสดงใน Microsoft PowerPoint:

![Three table cells showing a red diagonal from top-left to bottom-right, a blue diagonal from bottom-left to top-right, and both diagonals forming an X.](diagonal-cell-borders.png)

*จากซ้ายไปขวา: เส้นทแยงมุมลง (สีแดง, 3 pt), เส้นทแยงมุมขึ้น (สีน้ำเงิน, 5 pt), และทั้งสองเส้นทแยงมุม*

## **รวมเซลล์ตาราง**

ใช้ [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) เพื่อนำช่วงสี่เหลี่ยมของเซลล์ตารางมารวมเป็นเซลล์เดียว ระบุเซลล์ที่มุมซ้ายบนและมุมขวาล่างของช่วง พารามิเตอร์สุดท้ายกำหนดว่าการรวมอาจรวมเซลล์ที่อยู่นอกช่วงที่ระบุหรือไม่; `false` จะทำให้การรวมอยู่ภายในช่วงเท่านั้น

ตัวอย่างสร้างตาราง 4x4 ที่คอลัมน์และแถวมีความกว้าง 70 พอยต์, แล้วรวมเซลล์ศูนย์กลางสี่เซลล์จาก `(1, 1)` ถึง `(2, 2)`. เซลล์ที่ได้ขยายครอบคลุมสองคอลัมน์และสองแถว, ในขณะที่กริดพื้นฐานของตารางยังคงมีสี่คอลัมน์และสี่แถว เพื่อเข้าถึงเนื้อหา หรือรูปแบบของเซลล์ที่รวม ให้ใช้ตำแหน่งซ้ายบน: `table[1, 1]` ในตัวอย่างนี้ ตำแหน่งอื่นๆ ในช่วงที่รวมยังคงเป็นส่วนหนึ่งของกริดตาราง, ดังนั้นดัชนีของเซลล์ที่อยู่นอกช่วงจึงไม่เปลี่ยนแปลง

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table.MergeCells(table[1, 1], table[2, 2], false);

presentation.Save("merged_cells.pptx", SaveFormat.Pptx);
```

## **แยกเซลล์ตาราง**

การรวมเซลล์ในตัวอย่างก่อนหน้านี้ทำให้กริดของตารางคงเดิม การแยกเซลล์อาจสร้างคอลัมน์กริดใหม่และเปลี่ยนดัชนีคอลัมน์ของเซลล์ที่อยู่ด้านขวา Aspose.Slides ปฏิบัติตามโมเดลกริดของ PowerPoint

ตัวอย่างนี้สร้างตาราง 4x4 ที่คอลัมน์และแถวมีความกว้าง 70 พอยต์และเรียกใช้ [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) บนเซลล์ `(1, 1)`. ครึ่งหนึ่งของความกว้าง 70 พอยต์ของเซลล์ถูกส่งเข้าเพื่อสร้างสองเซลล์ที่มีความกว้างเท่ากัน

หลังจากแยกนี้ ครึ่งสองส่วนจะเข้าถึงได้เป็น `table[1, 1]` และ `table[2, 1]`. กริดของตารางตอนนี้มีห้าคอลัมน์: เซลล์ที่เคยอยู่ในคอลัมน์ 2 และ 3 จะย้ายไปเป็นคอลัมน์ 3 และ 4 ตามลำดับ ดัชนีแถวคงที่ ใช้ดัชนีคอลัมน์ที่อัปเดตเมื่อเข้าถึงเซลล์หลังจากการแยก

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[1, 1].SplitByWidth(table[1, 1].Width / 2);

presentation.Save("split_cells.pptx", SaveFormat.Pptx);
```

### **แยกเซลล์ที่รวมตามแถวหรือคอลัมน์**

เพื่อเตรียมเซลล์แม่แบบที่รวมแล้วสำหรับการเติมข้อมูล, ใช้ [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) เพื่อแยกตามขอบแถวที่มีอยู่, หรือใช้ [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) เพื่อแยกตามขอบคอลัมน์

อาร์กิวเมนต์ `index` นับแถวในส่วนบนหรือคอลัมน์ในส่วนซ้ายของการแยก; ค่าตรงนี้อ้างอิงจากบริเวณที่รวม:

- แยกแถว: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- แยกคอลัมน์: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

ตัวอย่างคาดว่างานนำเสนอมีตารางเป็นรูปร่างแรกบนสไลด์แรก, โดยเซลล์ `(1, 2)` และ `(1, 3)` รวมกันแบบแนวตั้ง เริ่มจากตำแหน่งล่าง ใช้ [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) และ [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) เพื่อหาตำแหน่งต้นกำเนิดและตรวจสอบทั้งสองช่วง `SplitByRowSpan(1)` จะแยกแถวที่ 2 และ 3 สำหรับชื่อสินค้า สำหรับการรวมสองคอลัมน์แนวนอน ให้ใช้ `SplitByColSpan(1)` แทน

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table_template.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var selectedCell = table[1, 3];
var firstColumnIndex = selectedCell.FirstColumnIndex;
var firstRowIndex = selectedCell.FirstRowIndex;
var mergedCell = table[firstColumnIndex, firstRowIndex];

if (mergedCell.IsMergedCell && mergedCell.RowSpan == 2 && mergedCell.ColSpan == 1)
{
    mergedCell.SplitByRowSpan(1);

    // ดึงเซลล์ที่ได้จากตารางหลังจากทำการแยก.
    var upperCell = table[firstColumnIndex, firstRowIndex];
    var lowerCell = table[firstColumnIndex, firstRowIndex + 1];
    Console.WriteLine($"Upper cell merged: {upperCell.IsMergedCell}");
    Console.WriteLine($"Lower cell merged: {lowerCell.IsMergedCell}");

    upperCell.TextFrame.Text = "Product A";
    lowerCell.TextFrame.Text = "Product B";

    presentation.Save("split_template.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Select a merged region spanning exactly two rows and one column.");
}
```

กริดของตารางและดัชนีเซลล์โดยรอบคงเดิม ดึงเซลล์ผลลัพธ์โดยใช้พิกัด; ที่นี้ทั้งสองเซลล์มีช่วงเป็น 1 และ [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) แสดงค่า `False`. พื้นที่ที่ใหญ่กว่าสามารถคงไว้เป็นบางส่วนที่รวมอยู่หลังจากการแยกหนึ่งครั้ง

ข้อความต้นฉบับและรูปแบบยังคงอยู่ในเซลล์บน (หรือซ้าย) ส่วนเซลล์ใหม่จะว่างเปล่าแต่สืบทอดรูปแบบเซลล์เช่นการเติม, เส้นขอบ, และระยะขอบ เติมข้อมูลลงในเซลล์หลังจากการแยกและตั้งค่าการจัดรูปแบบข้อความที่ต้องการอย่างชัดเจน

งานนำเสนอที่บันทึกมีเซลล์ "Product A" และ "Product B" แยกจากกันโดยคงรูปแบบของเทมเพลตไว้ ดูรายละเอียดเพิ่มเติมที่ [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/)

<!-- visual-explanation:manage-cells:start -->
[![The merged cell at column 1, rows 2 and 3 splits into Product A and Product B with the same grid indices.](visual-manage-cells-62c80896698e.svg)](visual-manage-cells-62c80896698e.svg)

*การแยกตามแถว‑span ใช้ขอบที่มีอยู่แล้ว. Product A และ Product B อยู่ที่ (1, 2) และ (1, 3) ตามลำดับ.*
<!-- visual-explanation:manage-cells:end -->

### **แยกเซลล์ที่ความสูงเฉพาะ**

[SplitByHeight](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyheight/) รับค่าความสูงของส่วนบนเป็นพอยต์ [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) รับจำนวนแถวกริดที่มีอยู่ในส่วนบน เพื่อวางเซลล์ความสูง 40 พอยต์ไว้ตรงกลางคอลัมน์ขวา ให้ลบ 40 จากความสูงจริงของเซลล์แล้วแบ่งพื้นที่ที่เหลือเท่า ๆ กันด้านบนและด้านล่าง

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 160, 160 };
double[] rowHeights = { 140 };

var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);
table[0, 0].TextFrame.Text = "Left";

var height = table[1, 0].Height;
var margin = (height - 40) / 2;

table[1, 0].SplitByHeight(margin);
table[1, 1].SplitByHeight(40);
table[1, 1].TextFrame.Text = "Middle";

presentation.Save("split_by_height.pptx", SaveFormat.Pptx);
```

การแยกครั้งแรกเพิ่มแถวกริด, ทำให้ส่วนล่าง 90 พอยต์อยู่ที่ `[1, 1]`. การแยกครั้งที่สองมุ่งเป้าเซลล์นั้นและเพิ่มอีกแถวด้านล่างคอลัมน์ขวาตอนนี้มี `[1, 0]` ที่ 50 พอยต์ (`margin`), `[1, 1]` ที่ 40 พอยต์, และ `[1, 2]` ที่ 50 พอยต์ (`margin`). เซลล์ซ้ายขยายครอบคลุมทั้งสามแถวด้วยความสูงเดิม 140 พอยต์

![The left cell spans the full table height beside three cells with Middle in the center.](split-by-height.png)

## **เปลี่ยนสีพื้นหลังของเซลล์ตาราง**

ตัวอย่างนี้สร้างตารางที่คอลัมน์ความกว้าง 150 พอยต์และแถวความสูง 50 พอยต์ ตั้งค่า [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) เป็นแบบทึบและ [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) เป็นสีแดงสำหรับเซลล์ `(2, 3)`, ซึ่งอยู่ในคอลัมน์ที่สามและแถวที่สี่

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 50, 50, 50, 50, 50 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

var cell = table[2, 3];
cell.CellFormat.FillFormat.FillType = FillType.Solid;
cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
```

## **เพิ่มรูปภาพภายในเซลล์ตาราง**

วางรูปภาพต้นฉบับในไดเรกทอรีทำงานก่อนรันตัวอย่าง นี้จะโหลดรูปภาพด้วย [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) และเพิ่มลงในคอล렉ชันรูปภาพของงานนำเสนอด้วย [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/). จากนั้นกำหนดรูปภาพให้กับการเติมรูปแบบภาพของเซลล์ `(0, 0)`, เซลล์แรกของตาราง

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) ขยายรูปภาพเพื่อเติมเต็มเซลล์ ซึ่งอาจทำให้สัดส่วนภาพเปลี่ยน คอลัมน์และแถวระบุเป็นพอยต์ ภาพที่โหลดจะถูกกำจัดโดยอัตโนมัติผ่านคำสั่ง using

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 100, 100, 100, 100, 90 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

using var image = Images.FromFile("aspose_logo.jpg");
var ppImage = presentation.Images.AddImage(image);

table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

presentation.Save("table_cell_with_image.pptx", SaveFormat.Pptx);
```

## **คำถามที่พบบ่อย**

**ฉันสามารถตั้งความหนาและสไตล์ของเส้นที่ต่างกันสำหรับแต่ละด้านของเซลล์เดียวได้หรือไม่?**

ได้. เส้นขอบด้านบน/[top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/), ด้านล่าง/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/), ด้านซ้าย/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/), และด้านขวา/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) มีคุณสมบัติแยกกัน ดังนั้นความหนาและสไตล์ของแต่ละด้านจึงสามารถแตกต่างกันได้

**ถ้าฉันเปลี่ยนขนาดคอลัมน์/แถวหลังจากตั้งรูปภาพเป็นพื้นหลังของเซลล์ จะเกิดอะไรขึ้นกับรูปภาพ?**

พฤติกรรมขึ้นกับ [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile). หากใช้การยืดรูปภาพจะปรับตามเซลล์ใหม่; หากใช้การซ้อนภาพ (tile) จะคำนวณตำแหน่งของแถบภาพใหม่

**ฉันสามารถกำหนดไฮเปอร์ลิงก์ให้กับเนื้อหาทั้งหมดของเซลล์ได้หรือไม่?**

[Hyperlinks](/slides/th/net/manage-hyperlinks/) ถูกตั้งค่าในระดับข้อความ (portion) ภายในกรอบข้อความของเซลล์หรือในระดับของตาราง/รูปร่างทั้งหมด ในการปฏิบัติจริงคุณจะกำหนดลิงก์ให้กับส่วนข้อความหรือให้กับข้อความทั้งหมดในเซลล์

**ฉันสามารถตั้งแบบอักษรที่ต่างกันภายในเซลล์เดียวได้หรือไม่?**

ได้. กรอบข้อความของเซลล์รองรับ [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (runs) ที่มีการจัดรูปแบบอิสระ—ครอบครัวฟอนต์, สไตล์, ขนาด, และสี.