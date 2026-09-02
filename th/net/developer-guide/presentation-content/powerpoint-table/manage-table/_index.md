---
title: จัดการตารางการนำเสนอใน .NET
linktitle: จัดการตาราง
type: docs
weight: 10
url: /th/net/manage-table/
keywords:
- เพิ่มตาราง
- สร้างตาราง
- เขาถึงตาราง
- อัตราส่วน
- จัดแนวข้อความ
- การจัดรูปแบบข้อความ
- สไตล์ตาราง
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สร้างและแก้ไขตารางในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ .NET ค้นหาตัวอย่างโค้ด C# อย่างง่ายเพื่อปรับปรุงกระบวนการทำงานกับตารางของคุณ"
---
## **บทนำ**

ตารางใน PowerPoint เป็นวิธีที่มีประสิทธิภาพในการแสดงและสื่อสารข้อมูล ข้อมูลในตารางที่ประกอบด้วยเซลล์ (จัดเรียงเป็นแถวและคอลัมน์) เป็นเรื่องง่ายและเข้าใจได้อย่างรวดเร็ว  

Aspose.Slides มีคลาส [Table](https://reference.aspose.com/slides/th/net/aspose.slides/table/) , อินเทอร์เฟซ [ITable](https://reference.aspose.com/slides/th/net/aspose.slides/itable/) , คลาส [Cell](https://reference.aspose.com/slides/th/net/aspose.slides/cell/) , อินเทอร์เฟซ [ICell](https://reference.aspose.com/slides/th/net/aspose.slides/icell/) และชนิดอื่น ๆ เพื่อให้คุณสามารถสร้าง, อัปเดตและจัดการตารางในงานนำเสนอทุกประเภท  

## **สร้างตารางจากศูนย์**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. กำหนดอาเรย์ของ `columnWidth`  
4. กำหนดอาเรย์ของ `rowHeight`  
5. เพิ่มวัตถุ [ITable](https://reference.aspose.com/slides/th/net/aspose.slides/itable/) ลงในสไลด์โดยใช้เมธอด [AddTable](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/addtable/)  
6. วนรอบแต่ละ [ICell](https://reference.aspose.com/slides/th/net/aspose.slides/icell/) เพื่อกำหนดรูปแบบเส้นขอบบน, ล่าง, ขวา และซ้าย  
7. รวมสองเซลล์แรกของแถวแรกของตาราง  
8. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/textframe/) ของ [ICell](https://reference.aspose.com/slides/th/net/aspose.slides/icell/)  
9. เพิ่มข้อความบางส่วนเข้าไปใน [TextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/textframe/)  
10. บันทึกงานนำเสนอที่แก้ไขแล้ว  

This C# code shows you how to create a table in a presentation:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
Presentation pres = new Presentation();

// เขาถึงสไลด์แรก
ISlide sld = pres.Slides[0];

// กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง
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
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[0][1], false);

// เพิ่มข้อความบางส่วนลงในเซลล์ที่รวม
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// บันทึกงานนำเสนอลงดิสก์
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **การตั้งหมายเลขในตารางมาตรฐาน**

ในตารางมาตรฐาน การตั้งหมายเลขเซลล์เป็นแบบศูนย์‑อิมพอตต์ (zero‑based) เซลล์แรกในตารางมีดัชนีเป็น 0,0 (คอลัมน์ 0, แถว 0)  

ตัวอย่างเช่น เซลล์ในตารางที่มี 4 คอลัมน์และ 4 แถวจะถูกจัดหมายเลขดังนี้  

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

This C# code creates the standard 4 × 4 table numbered above and sets the border format for each of its cells:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
using (Presentation pres = new Presentation())
{

    // เขาถึงสไลด์แรก
    ISlide sld = pres.Slides[0];

    // กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง
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
2. รับอ้างอิงสไลด์ที่มีตารางผ่านดัชนีของมัน  
3. สร้างวัตถุ [ITable](https://reference.aspose.com/slides/th/net/aspose.slides/itable/) แล้วตั้งค่าเป็น null  
4. วนรอบทั้งหมดของวัตถุ [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/) จนกว่าจะพบตาราง  

   หากคุณสงสัยว่า สไลด์ที่กำลังทำงานอยู่ มีตารางเพียงตารางเดียว คุณสามารถตรวจสอบทุกรูปทรงที่สไลด์มีได้ เมื่อรูปทรงระบุว่าเป็นตาราง คุณสามารถทำการคาสท์เป็นวัตถุ [Table](https://reference.aspose.com/slides/th/net/aspose.slides/table/) ได้ แต่หากสไลด์มีหลายตาราง คุณควรค้นหาตารางที่ต้องการผ่านคุณสมบัติ [AlternativeText](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/alternativetext/) ของมัน  

5. ใช้วัตถุ [ITable](https://reference.aspose.com/slides/th/net/aspose.slides/itable/) เพื่อทำงานกับตาราง ในตัวอย่างด้านล่าง เราได้เพิ่มแถวใหม่เข้าสู่ตาราง  
6. บันทึกงานนำเสนอที่แก้ไขแล้ว  

This C# code shows you how to access and work with an existing table:

```c#
using Aspose.Slides;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // เขาถึงสไลด์แรก
    ISlide sld = pres.Slides[0];

    // กำหนด TableEx ให้เป็น null
    ITable tbl = null;

    // วนผ่านรูปร่างทั้งหมดและตั้งอ้างอิงไปยังตารางที่พบ
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // ตั้งข้อความสำหรับคอลัมน์แรกของแถวที่สอง
    tbl[0, 1].TextFrame.Text = "New";

    // บันทึกงานนำเสนอที่แก้ไขแล้วลงดิสก์
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **ค้นหาเซลล์ที่เป็นเจ้าของ Text Frame**

เมื่อโค้ดการประมวลผลข้อความทั่วไปได้รับวัตถุ [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) จากตารางให้ใช้คุณสมบัติ [ITextFrame.ParentCell](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/parentcell/) เพื่อดึง [ICell](https://reference.aspose.com/slides/th/net/aspose.slides/icell/) เจ้าของ สำหรับ Text Frame ของเซลล์ตาราง [ITextFrame.ParentCell](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/parentcell/) จะถูกตั้งค่าและ [ITextFrame.ParentShape](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/parentshape/) จะเป็น `null` แม้ว่าตารางเองเป็น Shape  

พิกัดของเซลล์สามารถเข้าถึงได้ผ่านคุณสมบัติอ่าน‑เท่านั้น [ICell.FirstColumnIndex](https://reference.aspose.com/slides/th/net/aspose.slides/icell/firstcolumnindex/) และ [ICell.FirstRowIndex](https://reference.aspose.com/slides/th/net/aspose.slides/icell/firstrowindex/)  [ITextFrame.ParentCell](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/parentcell/) ก็เป็นอ่าน‑เท่านั้นเช่นกัน: มันให้การนำทางไปยังเจ้าของแต่ไม่ได้เปลี่ยนความเป็นเจ้าของ ตรวจสอบว่าเซลล์ที่คืนค่ามาไม่เป็น `null` ก่อนนำไปใช้เสมอ  

สำหรับตัวอย่างเต็มที่ระบุเจ้าของของเซลล์ตารางและ Shape รวมถึง Shape ที่เกี่ยวข้องกับโหนด SmartArt ดูที่ [Search and Replace Text](/slides/th/net/search-and-replace-text/)  

## **จัดแนวข้อความในตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เพิ่มวัตถุ [ITable](https://reference.aspose.com/slides/th/net/aspose.slides/itable/) ลงในสไลด์  
4. เข้าถึงวัตถุ [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) จากตาราง  
5. เข้าถึง [IParagraph](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/) ของ [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/)  
6. จัดแนวข้อความในแนวตั้ง  
7. บันทึกงานนำเสนอที่แก้ไขแล้ว  

This C# code shows you how to align the text in a table:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

// เขาถึง Text Frame
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// สร้างออบเจกต์ Paragraph สำหรับ Text Frame
IParagraph paragraph = txtFrame.Paragraphs[0];

// สร้างออบเจกต์ Portion สำหรับ Paragraph
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

1. สร้างอินสแตนซ์ของ คลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เข้าถึงวัตถุ [ITable](https://reference.aspose.com/slides/th/net/aspose.slides/itable/) จากสไลด์  
4. ตั้งค่า [FontHeight](https://reference.aspose.com/slides/th/net/aspose.slides/baseportionformat/fontheight/) สำหรับข้อความ  
5. ตั้งค่า [Alignment](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/alignment/) และ [MarginRight](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/marginright/)  
6. ตั้งค่า [TextVerticalType](https://reference.aspose.com/slides/th/net/aspose.slides/textframeformat/textverticaltype/)  
7. บันทึกงานนำเสนอที่แก้ไขแล้ว  

This C# code shows you how to apply your preferred formatting options to the text in a table:

```c#
using Aspose.Slides;

// สร้างอินสแตนซ์ของคลาส Presentation
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // สมมติว่ารูปร่างแรกบนสไลด์แรกเป็นตาราง

// ตั้งค่าความสูงของฟอนต์ในเซลล์ตาราง
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// ตั้งค่าการจัดแนวข้อความและระยะขอบด้านขวาในเซลล์ตารางในหนึ่งครั้ง
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// ตั้งค่าชนิดการจัดแนวข้อความแนวตั้งในเซลล์ตาราง
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **รับคุณสมบัติสไตล์ของตาราง**

Aspose.Slides ให้คุณดึงคุณสมบัติสไตล์ของตารางเพื่อใช้ในตารางอื่นหรือในที่อื่น ๆ โค้ด C# นี้แสดงวิธีการรับคุณสมบัติสไตล์จากสไตล์ตารางที่กำหนดไว้ล่วงหน้า:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // เปลี่ยนธีม preset สไตล์เริ่มต้น 

    // ดึงค่า preset สไตล์ของตาราง.
    TableStylePreset stylePreset = table.StylePreset;
    Console.WriteLine($"Table style preset: {stylePreset}");

    // ใช้ preset สไตล์ที่ดึงมาบนตารางอื่น.
    ITable anotherTable = pres.Slides[0].Shapes.AddTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.StylePreset = stylePreset;

    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **ล็อกอัตราส่วนของตาราง**

อัตราส่วนของรูปทรงเรขาคณิตคืออัตราส่วนของขนาดในมิติที่ต่างกัน Aspose.Slides มีคุณสมบัติ `AspectRatioLocked` เพื่อให้คุณล็อกการตั้งค่าอัตราส่วนของตารางและรูปทรงอื่น ๆ  

โค้ด C# นี้แสดงวิธีการล็อกอัตราส่วนสำหรับตาราง:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // สลับ

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถเปิดใช้ทิศทางการอ่านจากขวาไปซ้าย (RTL) สำหรับตารางทั้งหมดและข้อความในเซลล์ได้หรือไม่?**

ใช่ ตารางมีคุณสมบัติ [RightToLeft](https://reference.aspose.com/slides/th/net/aspose.slides/table/righttoleft/) และย่อหน้ามี [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/th/net/aspose.slides/paragraphformat/righttoleft/) การใช้ทั้งสองจะทำให้แนว RTL แสดงผลอย่างถูกต้องภายในเซลล์  

**ฉันจะป้องกันไม่ให้ผู้ใช้ย้ายหรือปรับขนาดตารางในไฟล์สุดท้ายได้อย่างไร?**

ใช้ [shape locks](/slides/th/net/applying-protection-to-presentation/) เพื่อปิดการย้าย, ปรับขนาด, การเลือก ฯลฯ การล็อกเหล่านี้ใช้กับตารางด้วยเช่นกัน  

**การแทรกรูปภาพเป็นพื้นหลังภายในเซลล์ได้รับการสนับสนุนหรือไม่?**

ใช่ คุณสามารถตั้งค่า [picture fill](https://reference.aspose.com/slides/th/net/aspose.slides/picturefillformat/) สำหรับเซลล์ได้ รูปภาพจะครอบคลุมพื้นที่เซลล์ตามโหมดที่เลือก (stretch หรือ tile)。