---
title: จัดการตารางงานนำเสนอใน .NET
linktitle: จัดการตาราง
type: docs
weight: 10
url: /th/net/manage-table/
keywords:
- เพิ่มตาราง
- สร้างตาราง
- เข้าถึงตาราง
- อัตราส่วน
- จัดแนวข้อความ
- การจัดรูปแบบข้อความ
- สไตล์ตาราง
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สร้างและแก้ไขตารางในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ .NET. ค้นพบตัวอย่างโค้ด C# อย่างง่ายเพื่อปรับปรุงกระบวนการทำงานกับตารางของคุณ."
---
## **บทนำ**

ตารางใน PowerPoint เป็นวิธีที่มีประสิทธิภาพในการแสดงและสื่อสารข้อมูล ข้อมูลในตารางเซลล์ (จัดเรียงเป็นแถวและคอลัมน์) มีความชัดเจนและเข้าใจง่าย  

Aspose.Slides ให้คลาส [Table](https://reference.aspose.com/slides/th/net/aspose.slides/table/) อินเทอร์เฟซ [ITable](https://reference.aspose.com/slides/th/net/aspose.slides/itable/) คลาส [Cell](https://reference.aspose.com/slides/th/net/aspose.slides/cell/) อินเทอร์เฟซ [ICell](https://reference.aspose.com/slides/th/net/aspose.slides/icell/) และประเภทอื่น ๆ เพื่อให้คุณสามารถสร้าง, ปรับปรุง, และจัดการตารางในงานนำเสนอได้ทุกประเภท  

## **สร้างตารางจากศูนย์**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
2. ดึงอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. กำหนดอาเรย์ของ `columnWidth`  
4. กำหนดอาเรย์ของ `rowHeight`  
5. เพิ่มอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/net/aspose.slides/itable/) ลงในสไลด์โดยใช้เมธอด [AddTable](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/addtable/)  
6. วนรอบผ่านแต่ละ [ICell](https://reference.aspose.com/slides/th/net/aspose.slides/icell/) เพื่อกำหนดรูปแบบของเส้นขอบบน, ล่าง, ขวา, และซ้าย  
7. รวมสองเซลล์แรกของแถวแรกของตาราง  
8. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/textframe/) ของ [ICell](https://reference.aspose.com/slides/th/net/aspose.slides/icell/)  
9. เพิ่มข้อความบางส่วนลงใน [TextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/textframe/)  
10. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด C# นี้แสดงวิธีสร้างตารางในงานนำเสนอ:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
Presentation pres = new Presentation();

// เข้าถึงสไลด์แรก
ISlide sld = pres.Slides[0];

// กำหนดคอลัมน์พร้อมความกว้างและแถวพร้อมความสูง
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// เพิ่มรูปร่างตารางลงในสไลด์
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// ตั้งค่ารูปแบบเส้นขอบสำหรับแต่ละเซลล์
for (int row = 0; row < tbl.Rows.Count; row++)
{
	for (int cell = 0; cell < tbl.Rows[row].Count; cell++)
	{
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderTop.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.FillType = (FillType.Solid);
		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.SolidFillColor.Color= Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderBottom.Width =5;

		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.SolidFillColor.Color =Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderLeft.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderRight.Width = 5;
	}
}

// รวมเซลล์ 1 และ 2 ของแถวที่ 1
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[1][1], false);

// เพิ่มข้อความบางส่วนลงในเซลล์ที่รวม
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// บันทึกงานนำเสนอลงดิสก์
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **การกำหนดหมายเลขในตารางมาตรฐาน**

ในตารางมาตรฐาน การกำหนดหมายเลขของเซลล์เป็นแบบง่ายและเริ่มจากศูนย์ เซลล์แรกในตารางจะมีดัชนีเป็น 0,0 (คอลัมน์ 0, แถว 0)  

ตัวอย่างเช่น เซลล์ในตารางที่มี 4 คอลัมน์และ 4 แถวจะถูกจัดหมายเลขดังนี้:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

โค้ด C# นี้แสดงวิธีกำหนดหมายเลขสำหรับเซลล์ในตาราง:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
using (Presentation pres = new Presentation())
{

    // เข้าถึงสไลด์แรก
    ISlide sld = pres.Slides[0];

    // กำหนดคอลัมน์พร้อมความกว้างและแถวพร้อมความสูง
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // เพิ่มรูปร่างตารางลงในสไลด์
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // ตั้งค่ารูปแบบเส้นขอบสำหรับแต่ละเซลล์
    foreach (IRow row in tbl.Rows)
    {
        foreach (ICell cell in row)
        {
			cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderTop.Width = 5;

			cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderBottom.Width = 5;

			cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderLeft.Width = 5;

			cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderRight.Width = 5;
        }
    }

    // บันทึกงานนำเสนอลงดิสก์
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```

## **เข้าถึงตารางที่มีอยู่**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
2. ดึงอ้างอิงถึงสไลด์ที่มีตารางผ่านดัชนีของมัน  
3. สร้างอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/net/aspose.slides/itable/) และกำหนดค่าเป็น null  
4. วนรอบผ่านอ็อบเจ็กต์ [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/) ทั้งหมดจนกว่าจะพบตาราง  

   หากคุณสงสัยว่าสไลด์ที่กำลังทำงานอยู่มีเพียงตารางเดียว คุณสามารถตรวจสอบทุกรูปทรงที่สไลด์มีได้อย่างง่ายดาย เมื่อรูปทรงถูกระบุว่าเป็นตาราง คุณสามารถแคสต์เป็นอ็อบเจ็กต์ [Table](https://reference.aspose.com/slides/th/net/aspose.slides/table/) ได้ แต่หากสไลด์นั้นมีหลายตาราง คุณควรค้นหาตารางที่ต้องการผ่าน [AlternativeText](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/alternativetext/) ของมัน  

5. ใช้อ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/net/aspose.slides/itable/) เพื่อทำงานกับตาราง ในตัวอย่างด้านล่าง เราได้เพิ่มแถวใหม่เข้าสู่ตาราง  
6. บันทึกงานนำเสนอที่แก้ไขแล้ว  

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // เข้าถึงสไลด์แรก
    ISlide sld = pres.Slides[0];

    // กำหนดค่าเริ่มต้นให้ TableEx เป็น null
    ITable tbl = null;

    // วนลูปผ่านรูปทรงและกำหนดอ้างอิงไปยังตารางที่พบ
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // ตั้งค่าข้อความสำหรับคอลัมน์แรกของแถวที่สอง
    tbl[0, 1].TextFrame.Text = "New";

    // บันทึกงานนำเสนอที่แก้ไขลงดิสก์
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **จัดแนวข้อความในตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
2. ดึงอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. เพิ่มอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/net/aspose.slides/itable/) ลงในสไลด์  
4. เข้าถึงอ็อบเจ็กต์ [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) จากตาราง  
5. เข้าถึง [IParagraph](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/) ของ [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/)  
6. จัดแนวข้อความในแนวตั้ง  
7. บันทึกงานนำเสนอที่แก้ไขแล้ว  

```c#
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation presentation = new Presentation();

// ดึงสไลด์แรก 
ISlide slide = presentation.Slides[0];

// กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// เพิ่มรูปร่างตารางลงในสไลด์
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// เข้าถึงเฟรมข้อความ
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// สร้างอ็อบเจ็กต์ Paragraph สำหรับเฟรมข้อความ
IParagraph paragraph = txtFrame.Paragraphs[0];

// สร้างอ็อบเจ็กต์ Portion สำหรับย่อหน้า
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// จัดแนวข้อความในแนวตั้ง
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// บันทึกงานนำเสนอลงดิสก์
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **ตั้งค่าการจัดรูปแบบข้อความในระดับตาราง**

1. สร้างอินสแตนซ์ของ the [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) class.  
2. ดึงอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. เข้าถึงอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/net/aspose.slides/itable/) จากสไลด์  
4. กำหนดค่า [FontHeight](https://reference.aspose.com/slides/th/net/aspose.slides/baseportionformat/fontheight/) สำหรับข้อความ  
5. กำหนดค่า [Alignment](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/alignment/) และ [MarginRight](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/marginright/)  
6. กำหนดค่า [TextVerticalType](https://reference.aspose.com/slides/th/net/aspose.slides/textframeformat/textverticaltype/)  
7. บันทึกงานนำเสนอที่แก้ไขแล้ว  

```c#
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // สมมติว่ารูปร่างแรกบนสไลด์แรกเป็นตาราง

// ตั้งค่าความสูงของฟอนต์ในเซลล์ตาราง
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// ตั้งค่าการจัดแนวข้อความและขอบด้านขวาในเซลล์ตารางในหนึ่งคำสั่ง
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// ตั้งค่าชนิดการวางแนวข้อความในเซลล์ตาราง
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **รับคุณสมบัติสไตล์ของตาราง**

Aspose.Slides อนุญาตให้คุณดึงคุณสมบัติสไตล์ของตารางเพื่อให้คุณใช้รายละเอียดเหล่านั้นกับตารางอื่นหรือที่อื่น โค้ด C# นี้แสดงวิธีรับคุณสมบัติสไตล์จากสไตล์ตารางที่กำหนดไว้ล่วงหน้า:

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // เปลี่ยนธีม preset สไตล์เริ่มต้น
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **ล็อคอัตราส่วนของตาราง**

อัตราส่วนของรูปทรงเรขาคณิตคืออัตราส่วนของขนาดในมิติที่ต่างกัน Aspose.Slides ให้คุณสมบัติ `AspectRatioLocked` เพื่อให้คุณสามารถล็อคการตั้งค่าอัตราส่วนของตารางและรูปทรงอื่น ๆ  

โค้ด C# นี้แสดงวิธีล็อคอัตราส่วนสำหรับตาราง:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // กลับด้าน

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Can I enable right-to-left (RTL) reading direction for an entire table and the text in its cells?**

ได้. ตารางมีคุณสมบัติ [RightToLeft](https://reference.aspose.com/slides/th/net/aspose.slides/table/righttoleft/) และย่อหน้า มี [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/th/net/aspose.slides/paragraphformat/righttoleft/) การใช้ทั้งสองจะทำให้การจัดลำดับและการแสดงผล RTL ถูกต้องภายในเซลล์  

**How can I prevent users from moving or resizing a table in the final file?**

ใช้ [shape locks](/slides/th/net/applying-protection-to-presentation/) เพื่อปิดการย้าย, ปรับขนาด, การเลือก ฯลฯ การล็อกเหล่านี้ใช้กับตารางด้วย  

**Is inserting an image inside a cell as a background supported?**

ได้. คุณสามารถตั้งค่า [picture fill](https://reference.aspose.com/slides/th/net/aspose.slides/picturefillformat/) สำหรับเซลล์; ภาพจะครอบพื้นที่เซลล์ตามโหมดที่เลือก (stretch หรือ tile)