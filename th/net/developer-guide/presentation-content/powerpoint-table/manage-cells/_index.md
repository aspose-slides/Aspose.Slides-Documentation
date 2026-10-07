---
title: จัดการเซลล์ตารางในงานนำเสนอด้วย .NET
linktitle: จัดการเซลล์
type: docs
weight: 30
url: /th/net/manage-cells/
keywords:
- เซลล์ตาราง
- ผสานเซลล์
- ลบขอบ
- แยกเซลล์
- รูปภาพในเซลล์
- สีพื้นหลัง
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "จัดการเซลล์ตาราง PowerPoint ด้วย C#: ระบุเซลล์ที่ผสาน, ลบขอบ, แยกเซลล์, และตั้งค่าสีพื้นหลังและรูปภาพด้วย Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณสามารถเข้าถึงและแก้ไขเซลล์ตารางในงานนำเสนอ PowerPoint ได้ บทความนี้อธิบายวิธีระบุเซลล์ตารางที่ถูกผสาน, ลบขอบเซลล์, ทำงานกับการจัดลำดับเซลล์หลังจากการผสานหรือแยกเซลล์, เปลี่ยนสีพื้นหลังของเซลล์, และเพิ่มรูปภาพภายในเซลล์ตาราง ตัวอย่างแสดงวิธีสร้างหรือเปิดงานนำเสนอ, ดึงตารางจากสไลด์, ปรับรูปแบบเซลล์ผ่านคุณสมบัติของเซลล์, และบันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

Aspose.Slides ใช้ดัชนีเริ่มจากศูนย์เพื่อเข้าถึงเซลล์ตารางตามลำดับ `(column, row)`.

## **ระบุเซลล์ตารางที่ผสาน**

ตัวอย่างเปิดงานนำเสนอที่มีอยู่และเข้าถึงรูปแบบแรกบนสไลด์แรกเป็นตาราง โดยสมมติว่าสไลด์และรูปแบบนั้นมีอยู่และรูปแบบเป็นตาราง จากนั้นวนลูปผ่านทุกแถวและคอลัมน์และใช้ [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) เพื่อระบุเซลล์ในพื้นที่ที่ผสาน สำหรับแต่ละที่ตรงกันจะแสดงพิกัดของเซลล์ในรูปแบบ `row;column` , [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/), และพิกัดเริ่มต้นของบริเวณนั้น ได้แก่ [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) และ [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/).

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

## **ลบขอบเซลล์ตาราง**

สร้าง [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) และเพิ่มตารางไปยังสไลด์แรกด้วย [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). ความกว้างของคอลัมน์, ความสูงของแถว, และตำแหน่งของตารางถูกกำหนดเป็นจุด ตัวอย่างตั้งค่าขอบเซลล์สี่ด้านทั้งหมดเป็น [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/), ทำให้ขอบไม่ปรากฏ.

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

## **ผสานเซลล์ตาราง**

ใช้ [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) เพื่อรวมช่วงสี่เหลี่ยมของเซลล์ตารางเป็นเซลล์เดียว ระบุเซลล์ที่มุมซ้ายบนและมุมขวาล่างของช่วง อาร์กิวเมนต์สุดท้ายควบคุมว่าการผสานอาจรวมเซลล์นอกช่วงที่กำหนดหรือไม่; `false` จะทำให้การผสานอยู่ภายในช่วงนั้นเท่านั้น.

ตัวอย่างสร้างตารางขนาด 4x4 โดยมีคอลัมน์และแถวที่มีความกว้าง/ความสูง 70 จุด แล้วผสานเซลล์กลางสี่เซลล์จาก `(1, 1)` ถึง `(2, 2)`. เซลล์ที่ได้จะครอบคลุมสองคอลัมน์และสองแถว ในขณะที่กริดพื้นฐานของตารางยังคงมีสี่คอลัมน์และสี่แถว เพื่อเข้าถึงเนื้อหาหรือรูปแบบของเซลล์ที่ผสาน ให้ใช้ตำแหน่งบนซ้าย: `table[1, 1]` ในตัวอย่างนี้ ตำแหน่งอื่นในช่วงที่ผสานยังคงเป็นส่วนหนึ่งของกริดตาราง ดังนั้นดัชนีของเซลล์นอกช่วงจะไม่ได้เปลี่ยนแปลง.

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

การผสานเซลล์ในตัวอย่างก่อนหน้ารักษาโครงสร้างกริดของตาราง การแยกเซลล์อาจทำให้เกิดคอลัมน์กริดใหม่และเปลี่ยนดัชนีคอลัมน์ของเซลล์ทางขวา Aspose.Slides ปฏิบัติตามโมเดลกริดของตารางใน PowerPoint.

ตัวอย่างนี้สร้างตารางขนาด 4x4 โดยมีคอลัมน์และแถวที่มีขนาด 70 จุดและเรียกใช้ [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) บนเซลล์ `(1, 1)`. ครึ่งหนึ่งของความกว้าง 70 จุดของเซลล์จะถูกใช้เพื่อสร้างเซลล์สองเซลล์ที่มีความกว้างเท่ากัน.

หลังจากการแยกนี้ ครึ่งสองส่วนจะเข้าถึงได้โดยใช้ `table[1, 1]` และ `table[2, 1]`. ตอนนี้กริดของตารางมีห้าคอลัมน์: เซลล์ที่เดิมอยู่ในคอลัมน์ 2 และ 3 จะย้ายไปที่คอลัมน์ 3 และ 4 ตามลำดับ ดัชนีแถวไม่เปลี่ยนแปลง ใช้ดัชนีคอลัมน์ที่อัปเดตนี้เมื่อต้องการเข้าถึงเซลล์หลังการแยก.

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

### **แยกเซลล์ที่ผสานตามการครอบคลุมแถวหรือคอลัมน์**

เพื่อเตรียมเซลล์เทมเพลตที่ผสานสำหรับการเติมข้อมูล ให้ใช้ [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) เพื่อแยกตามขอบแถวที่มีอยู่ หรือ [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) เพื่อแยกตามขอบคอลัมน์.

อาร์กิวเมนต์ `index` จะนับแถวในส่วนบนหรือคอลัมน์ในส่วนซ้ายของการแยก; มันสัมพันธ์กับพื้นที่ที่ผสาน:

- การแยกแถว: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/)
- การแยกคอลัมน์: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/)

ตัวอย่างคาดว่างานนำเสนอมีตารางเป็นรูปแบบแรกบนสไลด์แรก โดยมีเซลล์ `(1, 2)` และ `(1, 3)` ผสานแนวตั้ง เริ่มจากตำแหน่งล่าง จะใช้ [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) และ [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) เพื่อหาแหล่งกำเนิดและตรวจสอบการครอบคลุมทั้งสองแบบ `SplitByRowSpan(1)` จะทำการแยกแถวที่ 2 และ 3 สำหรับชื่อสินค้า สำหรับการผสานสองคอลัมน์แนวนอน ให้ใช้ `SplitByColSpan(1)` แทน.

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

    // ดึงเซลล์ที่ได้จากตารางหลังจากการแยก.
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

กริดของตารางและดัชนีเซลล์โดยรอบยังคงไม่เปลี่ยนแปลง ดึงเซลล์ที่ได้โดยใช้พิกัดของมัน; ที่นี่ทั้งสองเซลล์มีการครอบคลุมเป็น 1 และ [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) แสดงผล `False`. พื้นที่ที่ใหญ่กว่าอาจยังคงผสานบางส่วนหลังจากการแยกครั้งหนึ่ง.

ข้อความต้นฉบับและรูปแบบของมันยังคงอยู่ในเซลล์บน (หรือซ้าย); เซลล์ใหม่เป็นค่าว่างแต่สืบทอดรูปแบบเซลล์เช่นการเติม, ขอบ, และระยะขอบ เติมข้อมูลลงในเซลล์หลังการแยกและตั้งค่าการจัดรูปแบบข้อความที่ต้องการอย่างชัดเจน.

งานนำเสนอที่บันทึกแล้วจะมีเซลล์แยกกันสำหรับ "Product A" และ "Product B" พร้อมกับรูปแบบเซลล์ของเทมเพลตที่คงไว้ ดูที่ [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) สำหรับรายละเอียด.

## **เปลี่ยนสีพื้นหลังของเซลล์ตาราง**

ตัวอย่างนี้สร้างตารางโดยมีคอลัมน์ขนาด 150 จุดและแถวขนาด 50 จุด ตั้งค่า [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) เป็นแบบสีทึบและ [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) เป็นสีแดงสำหรับเซลล์ `(2, 3)`, ซึ่งอยู่ในคอลัมน์ที่สามและแถวที่สี่.

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

วางรูปภาพอินพุตไว้ในไดเรกทอรีทำงานก่อนรันตัวอย่างนี้ โปรแกรมจะโหลดรูปภาพด้วย [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) และเพิ่มลงในคอล렉ชันรูปภาพของงานนำเสนอด้วย [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/). จากนั้นจะกำหนดรูปภาพให้กับการเติมภาพของเซลล์ `(0, 0)`, เซลล์แรกของตาราง.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) ขยายรูปภาพให้เต็มเซลล์ ซึ่งอาจเปลี่ยนสัดส่วนของรูป ความกว้างของคอลัมน์และความสูงของแถวเป็นหน่วยจุด รูปภาพที่โหลดจะถูกทำลายโดยอัตโนมัติโดยคำสั่ง using.

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

**ฉันสามารถตั้งความหนาและสไตล์ของเส้นขอบที่แตกต่างกันสำหรับแต่ละด้านของเซลล์เดียวได้หรือไม่?**

ใช่. The [ด้านบน](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[ด้านล่าง](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[ด้านซ้าย](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[ด้านขวา](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) borders have separate properties, so the thickness and style of each side can differ.

**อะไรจะเกิดขึ้นกับรูปภาพหากฉันเปลี่ยนขนาดคอลัมน์/แถวหลังจากตั้งรูปเป็นพื้นหลังของเซลล์?**

พฤติกรรมขึ้นอยู่กับ [โหมดการเติม](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile). หากใช้การยืดรูปภาพจะปรับให้เข้ากับเซลล์ใหม่; หากใช้การต_tile รูปภาพย่อยจะถูกคำนวณใหม่.

**ฉันสามารถกำหนดไฮเปอร์ลิงก์ให้กับเนื้อหาทั้งหมดของเซลล์ได้หรือไม่?**

[ไฮเปอร์ลิงก์](/slides/th/net/manage-hyperlinks/) ถูกตั้งค่าที่ระดับข้อความ (portion) ภายในกรอบข้อความของเซลล์หรือที่ระดับของตาราง/รูปทั้งหมด ในการปฏิบัติคุณจะกำหนดลิงก์ให้กับส่วนหนึ่งหรือให้กับข้อความทั้งหมดในเซลล์.

**ฉันสามารถตั้งค่าฟอนต์ที่แตกต่างกันภายในเซลล์เดียวได้หรือไม่?**

ใช่. A cell’s text frame supports [ส่วนข้อความ](https://reference.aspose.com/slides/net/aspose.slides/portion/) (runs) with independent formatting—font family, style, size, and color.