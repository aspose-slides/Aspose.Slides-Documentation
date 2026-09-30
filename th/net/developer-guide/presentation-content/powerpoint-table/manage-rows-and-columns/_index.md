---
title: "จัดการแถวและคอลัมน์ในตาราง PowerPoint ด้วย .NET"
linktitle: "แถวและคอลัมน์"
type: docs
weight: 20
url: /th/net/manage-rows-and-columns/
keywords:
- "แถวตาราง"
- "คอลัมน์ตาราง"
- "แถวแรก"
- "หัวตาราง"
- "คัดลอกแถว"
- "คัดลอกคอลัมน์"
- "ทำสำเนาแถว"
- "ทำสำเนาคอลัมน์"
- "ลบแถว"
- "ลบคอลัมน์"
- "การจัดรูปแบบข้อความแถว"
- "การจัดรูปแบบข้อความคอลัมน์"
- "สไตล์ตาราง"
- "PowerPoint"
- "งานนำเสนอ"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "จัดการแถวและคอลัมน์ของตารางใน PowerPoint ด้วย Aspose.Slides for .NET เพื่อเร่งการแก้ไขงานนำเสนอและอัปเดตข้อมูล."
---
## **บทนำ**

Aspose.Slides for .NET ให้คุณจัดการโครงสร้างและการจัดรูปแบบตารางในงานนำเสนอ PowerPoint ผ่านคลาส [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) และอินเทอร์เฟซ [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) คุณสามารถกำหนดแถวหัวเรื่อง, คัดลอกหรือเอาแถวและคอลัมน์ออก, และใช้การจัดรูปแบบข้อความกับแถวหรือคอลัมน์ทั้งหมดได้

บทความนี้อธิบายการดำเนินการเหล่านี้ด้วยตัวอย่าง C# นอกจากนี้ยังแสดงวิธีดึงสไตล์ของตารางเพื่อให้คุณสามารถนำกลับมาใช้ใหม่ ดัชนีแถวและคอลัมน์ของตารางเริ่มต้นจากศูนย์

## **ควบคุมความสูงแถว**

ใช้ [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) เพื่อตั้งค่าความสูงขั้นต่ำของแถวเป็นหน่วยจุด เป็นค่าต่ำสุด ไม่ใช่ความสูงคงที่ [IRow.Height](https://reference.aspose.com/slides/net/aspose.slides/irow/height/) คืนค่าความสูงจริงและอ่านได้อย่างเดียว เข้าถึงแถวผ่าน [ITable.Rows](https://reference.aspose.com/slides/net/aspose.slides/itable/rows/)

ตัวอย่างโหลด [row-height-input.pptx](row-height-input.pptx) ซึ่งมีตารางเป็นรูปทรงแรกบนสไลด์แรก แถวแรกเริ่มที่ 70 จุด เซลล์ใช้ข้อความ Arial ขนาด 18 จุด การห่อข้อความ และระยะขอบบนและล่าง 6 จุด; ข้อความยาวในคอลัมน์ที่สองห่อหลายบรรทัด ตัวอย่างเพิ่มค่าขั้นต่ำเป็น 100 จุด แล้วลดลงเป็น 20 จุด พิมพ์ความสูงจริงหลังการเปลี่ยนแต่ละครั้ง และบันทึกผลลัพธ์ทั้งสอง

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("row-height-input.pptx");
var table = (ITable)presentation.Slides[0].Shapes[0];
var row = table.Rows[0];

row.MinimalHeight = 100;
Console.WriteLine($"Increased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-increased.pptx", SaveFormat.Pptx);

row.MinimalHeight = 20;
Console.WriteLine($"Decreased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-decreased.pptx", SaveFormat.Pptx);
```

ด้วยงานนำเสนอที่ให้มา การเพิ่มค่าขั้นต่ำจะเพิ่มพื้นที่ให้กับแถว การลดค่าจะลบพื้นที่ส่วนที่เพิ่มนั้นออก แต่ความสูงจริงยังคงมากกว่า 20 จุดเนื่องจากข้อความและระยะขอบของเซลล์ต้องการพื้นที่มากกว่าที่กำหนด การลดค่าขั้นต่ำอย่างเดียวไม่สามารถบังคับให้แถวต่ำกว่าพื้นที่ที่เนื้อหาต้องการได้

หลายปัจจัยมีผลต่อความสูงจริง:

- **ข้อความและขนาดฟอนต์:** ข้อความยาว, การขึ้นบรรทัดใหม่โดยเจตนา, หรือฟอนต์ที่ใหญ่ขึ้นอาจต้องการพื้นที่แนวตั้งเพิ่ม
- **การห่อและความกว้างคอลัมน์:** เมื่อเปิดการห่อไว้ ความกว้างที่แคบของ [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) สามารถทำให้เกิดบรรทัดเพิ่มขึ้น คอลัมน์ที่กว้างขึ้นสามารถลดพื้นที่แนวตั้งที่ต้องการ
- **ระยะขอบเซลล์:** [ICell.MarginTop](https://reference.aspose.com/slides/net/aspose.slides/icell/margintop/) และ [ICell.MarginBottom](https://reference.aspose.com/slides/net/aspose.slides/icell/marginbottom/) เพิ่มพื้นที่แนวตั้ง [ICell.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/icell/marginleft/) และ [ICell.MarginRight](https://reference.aspose.com/slides/net/aspose.slides/icell/marginright/) ลดความกว้างที่ใช้ได้สำหรับข้อความและอาจทำให้เกิดการห่อเพิ่มเติม

สำหรับตารางนี้ไม่มีการรวมเซลล์ เซลล์ที่ต้องการพื้นที่แนวตั้งมากที่สุดจะกำหนดขีดจำกัดล่างที่ขับเคลื่อนโดยเนื้อหาเพื่อทั้งแถว หากต้องการให้แถวสั้นลง คุณอาจต้องย่อข้อความ, ลดขนาดฟอนต์หรือระยะขอบ, หรือทำให้คอลัมน์กว้างขึ้น

ภาพด้านล่างแสดงตารางเดียวกันในสเกลเดียวกัน ในการรันนี้ ความสูงจริงเป็น 70, 100, และ 55.2 จุด: แถวสุดท้ายยังคงสูงกว่าค่าขั้นต่ำ 20 จุด การวัดข้อความที่แม่นยำอาจแตกต่างตามฟอนต์ที่มีในสภาพแวดล้อมของคุณ ดาวน์โหลดผลลัพธ์ที่บันทึกไว้: [increased minimum](row-height-increased.pptx) และ [decreased minimum](row-height-decreased.pptx)

| ต้นฉบับ: ขั้นต่ำ 70 pt, จริง 70 pt | เพิ่ม: ขั้นต่ำ 100 pt, จริง 100 pt | ลด: ขั้นต่ำ 20 pt, จริง 55.2 pt |
| --- | --- | --- |
| ![ตารางต้นฉบับที่มีแถวแรก 70 จุด.](row-height-before.png) | ![ตารางหลังจากเพิ่มค่าขั้นต่ำของแถวแรกเป็น 100 จุด.](row-height-increased.png) | ![ตารางหลังจากลดค่าขั้นต่ำของแถวแรกเป็น 20 จุด; ข้อความห่อทำให้แถวสูงกว่าขั้นต่ำ.](row-height-decreased.png) |

## **ตั้งค่าแถวแรกเป็นหัวเรื่อง**

ใช้คุณสมบัติ [FirstRow](https://reference.aspose.com/slides/net/aspose.slides/itable/firstrow/) เพื่อทำเครื่องหมายแถวแรกสำหรับการจัดรูปแบบหัวเรื่อง การแสดงผลขึ้นอยู่กับสไตล์ตารางที่ใช้กับตาราง

1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)
2. เข้าถึงสไลด์แรก
3. เข้าถึงตารางที่เก็บเป็นรูปทรงแรกบนสไลด์
4. เปิดการจัดรูปแบบหัวเรื่องสำหรับแถวแรกของมัน
5. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างต้องการ `table.pptx` ที่มีตารางเป็นรูปทรงแรกบนสไลด์แรก มันเปิดการจัดรูปแบบหัวเรื่องสำหรับแถวแรกและบันทึกเป็น `First_row_header.pptx`

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];
table.FirstRow = true;

presentation.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **คัดลอกแถวหรือคอลัมน์ของตาราง**

คัดลอกแถวหรือคอลัมน์เพื่อใช้เนื้อหาและการจัดรูปแบบซ้ำ คุณสามารถต่อท้ายสำเนาที่คัดลอกไว้ที่ส่วนท้ายของตารางหรือแทรกในตำแหน่งที่กำหนด

1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)
2. เข้าถึงสไลด์แรก
3. กำหนดความกว้างของคอลัมน์และความสูงของแถว
4. เพิ่มตารางด้วยวิธีการ [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/)
5. คัดลอกแถวที่ต้องการ
6. คัดลอกคอลัมน์ที่ต้องการ
7. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างต้องการ `Test.pptx` ที่มีอย่างน้อยหนึ่งสไลด์ มันสร้างตารางที่มีสามคอลัมน์และห้าแถว โดยกำหนดขนาดเป็นหน่วยจุด มันต่อท้ายสำเนาของแถวแรกและคอลัมน์แรก, จากนั้นแทรกสำเนาของแถวที่สองและคอลัมน์ที่สองที่ตำแหน่งดัชนี 3 (ตำแหน่งที่สี่) ตารางที่ได้จะมีเจ็ดแถวและห้าคอลัมน์ อาร์กิวเมนต์ `false` ปิดการคัดลอกไปยังแถวหรือคอลัมน์ที่รวมติดกัน; ตารางนี้ไม่มีการรวมเซลล์

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[0, 0].TextFrame.Text = "Row 1 Cell 1";
table[1, 0].TextFrame.Text = "Row 1 Cell 2";
table.Rows.AddClone(table.Rows[0], false);

table[0, 1].TextFrame.Text = "Row 2 Cell 1";
table[1, 1].TextFrame.Text = "Row 2 Cell 2";
table.Rows.InsertClone(3, table.Rows[1], false);

table.Columns.AddClone(table.Columns[0], false);
table.Columns.InsertClone(3, table.Columns[1], false);

presentation.Save("table_out.pptx", SaveFormat.Pptx);
```

## **ลบแถวหรือคอลัมน์จากตาราง**

ลบแถวหรือคอลัมน์ที่ไม่ต้องการในตาราง การลบรายการจะเลื่อนดัชนีของแถวหรือคอลัมน์ที่ตามมาหลังจากนั้น

1. สร้างงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)
2. เข้าถึงสไลด์แรก
3. กำหนดความกว้างของคอลัมน์และความสูงของแถว
4. เพิ่มตารางด้วยวิธีการ [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/)
5. ลบแถวที่สองและคอลัมน์ที่สอง
6. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างนี้สร้างตาราง 3x3 และลบแถวและคอลัมน์ที่ดัชนี 1 ทำให้เหลือตาราง 2x2 ในไฟล์ `TestTable_out.pptx` ขนาดเป็นหน่วยจุด อาร์กิวเมนต์ `false` ปิดการลบแถวหรือคอลัมน์ที่รวมติดกัน; ตารางนี้ไม่มีการรวมเซลล์

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 50, 30 };
var rowHeights = new double[] { 30, 50, 30 };
var table = slide.Shapes.AddTable(100, 100, columnWidths, rowHeights);

table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);

presentation.Save("TestTable_out.pptx", SaveFormat.Pptx);
```

## **ตั้งค่าการจัดรูปแบบข้อความระดับแถวของตาราง**

ใช้การจัดรูปแบบข้อความกับแถวทั้งหมดเพื่อให้เซลล์สอดคล้องกัน คุณสามารถตั้งค่าคุณสมบัติฟอนต์, การจัดย่อหน้า, และทิศทางข้อความโดยไม่ต้องจัดรูปแบบแต่ละเซลล์แยกกัน

1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)
2. เข้าถึงตารางบนสไลด์แรก
3. ตั้งค่า [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) สำหรับแถวแรก
4. ตั้งค่า [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) และ [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) สำหรับแถวแรก
5. ตั้งค่า [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) สำหรับแถวที่สอง
6. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างต้องการ `table.pptx` ที่มีตารางเป็นรูปทรงแรกบนสไลด์แรกและอย่างน้อยสองแถว มันใช้ข้อความขนาด 25 จุด, การจัดชิดขวา, และระยะขอบย่อหน้าขวา 20 จุดสำหรับแถวแรก, แล้วตั้งค่าข้อความแนวตั้งในแถวที่สอง

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Rows[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Rows[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Rows[1].SetTextFormat(textFrameFormat);

presentation.Save("row_formatting.pptx", SaveFormat.Pptx);
```

## **ตั้งค่าการจัดรูปแบบข้อความระดับคอลัมน์ของตาราง**

ใช้การจัดรูปแบบข้อความกับคอลัมน์ทั้งหมดเพื่อให้เซลล์สอดคล้องกัน คุณสามารถตั้งค่าคุณสมบัติฟอนต์, การจัดย่อหน้า, และทิศทางข้อความโดยไม่ต้องจัดรูปแบบแต่ละเซลล์แยกกัน

1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)
2. เข้าถึงตารางบนสไลด์แรก
3. ตั้งค่า [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) สำหรับคอลัมน์แรก
4. ตั้งค่า [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) และ [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) สำหรับคอลัมน์แรก
5. ตั้งค่า [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) สำหรับคอลัมน์ที่สอง
6. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างต้องการ `table.pptx` ที่มีตารางเป็นรูปทรงแรกบนสไลด์แรกและอย่างน้อยสองคอลัมน์ มันใช้ข้อความขนาด 25 จุด, การจัดชิดขวา, และระยะขอบย่อหน้าขวา 20 จุดสำหรับคอลัมน์แรก, แล้วตั้งค่าข้อความแนวตั้งในคอลัมน์ที่สอง

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Columns[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Columns[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Columns[1].SetTextFormat(textFrameFormat);

presentation.Save("column_formatting.pptx", SaveFormat.Pptx);
```

## **รับคุณสมบัติสไตล์ของตาราง**

ใช้คุณสมบัติ [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) เพื่อดึงสไตล์พรีเซ็ตที่ใช้กับตารางและนำไปใช้กับตารางอื่น นี่จะระบุพรีเซ็ตแทนการเขียนทับการจัดรูปแบบของเซลล์แต่ละเซลล์

ตัวอย่างสร้างตาราง, ใช้ [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/) แล้วอ่านพรีเซ็ตกลับมา พิมพ์ `DarkStyle1` และบันทึกตารางในไฟล์ `table.pptx`

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

Console.WriteLine(table.StylePreset);

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้ธีม/สไตล์ PowerPoint กับตารางที่สร้างแล้วได้หรือไม่?**

ได้ ตารางสืบทอดธีมของสไลด์/เลเอาต์/มาสเตอร์, และคุณยังสามารถเขียนทับการเติมสี, เส้นขอบ, และสีข้อความเหนือธีมนั้นได้

**ฉันสามารถจัดเรียงแถวของตารางแบบ Excel ได้หรือไม่?**

ไม่ได้, ตารางของ Aspose.Slides ไม่มีการจัดเรียงหรือฟิลเตอร์ในตัว คุณต้องจัดเรียงข้อมูลในหน่วยความจำก่อน แล้วคัดลอกแถวตารางใหม่ตามลำดับนั้น

**ฉันสามารถมีคอลัมน์ลายทาง (striped) พร้อมกับสีกำหนดเองในเซลล์บางเซลล์ได้หรือไม่?**

ได้ เปิดการใช้คอลัมน์ลายทาง, แล้วเขียนทับเซลล์เฉพาะด้วยการจัดรูปแบบท้องถิ่น; การจัดรูปแบบระดับเซลล์มีลำดับความสำคัญเหนือสไตล์ของตาราง