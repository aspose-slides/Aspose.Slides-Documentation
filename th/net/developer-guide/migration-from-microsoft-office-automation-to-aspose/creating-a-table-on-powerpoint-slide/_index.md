---
title: สร้างตารางโดยใช้ VSTO และ Aspose.Slides for .NET
linktitle: สร้างตาราง
type: docs
weight: 50
url: /th/net/creating-a-table-on-powerpoint-slide/
keywords:
- สร้างตาราง
- การย้าย
- VSTO
- การอัตโนมัตาของ Office
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ย้ายจากการอัตโนมัตาของ Microsoft Office ไปยัง Aspose.Slides for .NET และสร้างตารางในสไลด์ PowerPoint (PPT, PPTX) ด้วย C# พร้อมการจัดรูปแบบที่ยืดหยุ่น."
---
{{% alert color="info" %}} 
ตารางถูกใช้กันอย่างกว้างขวางเพื่อแสดงข้อมูลบนสไลด์การนำเสนอ บทความนี้แสดงวิธีสร้างตารางขนาด 15 x 15 โดยใช้ฟอนต์ขนาด 10 ผ่านโปรแกรมด้วยการใช้ [VSTO 2008](/slides/th/net/creating-a-table-on-powerpoint-slide/) ก่อนและจากนั้น [Aspose.Slides for .NET](/slides/th/net/creating-a-table-on-powerpoint-slide/). 
{{% /alert %}} 
## **การสร้างตาราง**
#### **VSTO 2008 ตัวอย่าง**
ขั้นตอนต่อไปนี้จะเพิ่มตารางลงในสไลด์ Microsoft PowerPoint โดยใช้ VSTO:

1. สร้างการนำเสนอ.
1. เพิ่มสไลด์เปล่าลงในการนำเสนอ.
1. เพิ่มตารางขนาด 15 x 15 ลงในสไลด์.
1. เพิ่มข้อความลงในแต่ละเซลล์ของตารางโดยใช้ฟอนต์ขนาด 10.
1. บันทึกการนำเสนอลงดิสก์.

```c#
//Create a presentation
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
              .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//Add a blank slide
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Add a 15 x 15 table
PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);
PowerPoint.Table tbl = shp.Table;
int i = -1;
int j = -1;

//Loop through all the rows
foreach (PowerPoint.Row row in tbl.Rows)
{
    i = i + 1;
    j = -1;

    //Loop through all the cells in the row
    foreach (PowerPoint.Cell cell in row.Cells)
    {
        j = j + 1;
        //Get text frame of each cell
        PowerPoint.TextFrame tf = cell.Shape.TextFrame;
        //Add some text
        tf.TextRange.Text = "T" + i.ToString() + j.ToString();
        //Set font size of the text as 10
        tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;
    }
}

//Save the presentation to disk
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```

### **Aspose.Slides for .NET ตัวอย่าง**
ขั้นตอนต่อไปนี้จะเพิ่มตารางลงในสไลด์ Microsoft PowerPoint โดยใช้ Aspose.Slides:

1. สร้างการนำเสนอ.
1. เพิ่มตารางขนาด 15 x 15 ลงในสไลด์แรก.
1. เพิ่มข้อความลงในแต่ละเซลล์ของตารางโดยใช้ฟอนต์ขนาด 10.
1. เขียนการนำเสนอลงดิสก์.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

Presentation pres = new Presentation();

//Access first slide
//เข้าถึงสไลด์แรก
ISlide sld = pres.Slides[0];

//Define columns with widths and rows with heights
//กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//Add a table
//เพิ่มตาราง
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//Set border format for each cell
//ตั้งค่ารูปแบบเส้นขอบสำหรับแต่ละเซลล์
foreach (IRow row in tbl.Rows)
{
	foreach (ICell cell in row)
	{

		//Get text frame of each cell
		//รับเฟรมข้อความของแต่ละเซลล์
		ITextFrame tf = cell.TextFrame;
		//Add some text
		//เพิ่มข้อความบางส่วน
		tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
		//Set font size of 10
		//ตั้งขนาดฟอนต์เป็น 10
		tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
		tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
	}
}

//Write the presentation to the disk
//บันทึกการนำเสนอลงดิสก์
pres.Save("tblSLD.ppt", SaveFormat.Ppt);
```