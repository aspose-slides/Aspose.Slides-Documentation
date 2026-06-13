---
title: การสร้างตารางโดยใช้ VSTO และ Aspose.Slides สำหรับ .NET
linktitle: การสร้างตาราง
type: docs
weight: 50
url: /th/net/creating-a-table-on-powerpoint-slide/
keywords:
- สร้างตาราง
- การย้ายข้อมูล
- VSTO
- การทำงานอัตโนมัติของ Office
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ย้ายจากการทำงานอัตโนมัติของ Microsoft Office ไปยัง Aspose.Slides สำหรับ .NET และสร้างตารางในสไลด์ PowerPoint (PPT, PPTX) ด้วย C# พร้อมการจัดรูปแบบที่ยืดหยุ่น."
---
{{% alert color="primary" %}}

ตารางถูกใช้อย่างแพร่หลายเพื่อแสดงข้อมูลบนสไลด์การนำเสนอ. บทความนี้แสดงวิธีสร้างตารางขนาด 15 x 15 ด้วยขนาดฟอนต์ 10 แบบโปรแกรมมิ่งโดยใช้แรก [VSTO 2008](/slides/th/net/creating-a-table-on-powerpoint-slide/) แล้วจึงใช้ [Aspose.Slides for .NET](/slides/th/net/creating-a-table-on-powerpoint-slide/).

{{% /alert %}} 
## **สร้างตาราง**
#### **ตัวอย่าง VSTO 2008**
ขั้นตอนต่อไปนี้จะเพิ่มตารางลงในสไลด์ Microsoft PowerPoint โดยใช้ VSTO:

1. สร้างงานนำเสนอ.
1. เพิ่มสไลด์เปล่าไปยังงานนำเสนอ.
1. เพิ่มตารางขนาด 15 x 15 ลงบนสไลด์.
1. เพิ่มข้อความในแต่ละเซลล์ของตารางด้วยขนาดฟอนต์ 10.
1. บันทึกงานนำเสนอไปยังดิสก์.

```c#
//สร้างการนำเสนอ
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
              .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//เพิ่มสไลด์เปล่า
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//เพิ่มตารางขนาด 15 x 15
PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);
PowerPoint.Table tbl = shp.Table;
int i = -1;
int j = -1;

//วนลูปผ่านทุกแถว
foreach (PowerPoint.Row row in tbl.Rows)
{
    i = i + 1;
    j = -1;

    //วนลูปผ่านทุกเซลล์ในแถว
    foreach (PowerPoint.Cell cell in row.Cells)
    {
        j = j + 1;
        //ดึงกรอบข้อความของแต่ละเซลล์
        PowerPoint.TextFrame tf = cell.Shape.TextFrame;
        //เพิ่มข้อความบางส่วน
        tf.TextRange.Text = "T" + i.ToString() + j.ToString();
        //ตั้งค่าขนาดฟอนต์ของข้อความเป็น 10
        tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;
    }
}

//บันทึกการนำเสนอลงดิสก์
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **ตัวอย่าง Aspose.Slides for .NET**
ขั้นตอนต่อไปนี้จะเพิ่มตารางลงในสไลด์ Microsoft PowerPoint โดยใช้ Aspose.Slides:

1. สร้างงานนำเสนอ.
1. เพิ่มตารางขนาด 15 x 15 ไปยังสไลด์แรก.
1. เพิ่มข้อความในแต่ละเซลล์ของตารางด้วยขนาดฟอนต์ 10.
1. เขียนงานนำเสนอลงดิสก์.

```c#
Presentation pres = new Presentation();

//เข้าถึงสไลด์แรก
ISlide sld = pres.Slides[0];

//กำหนดคอลัมน์พร้อมความกว้างและแถวพร้อมความสูง
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//เพิ่มตาราง
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//ตั้งค่ารูปแบบขอบสำหรับแต่ละเซลล์
foreach (IRow row in tbl.Rows)
{
	foreach (ICell cell in row)
	{

		//ดึงกรอบข้อความของแต่ละเซลล์
		ITextFrame tf = cell.TextFrame;
		//เพิ่มข้อความบางส่วน
		tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
		//ตั้งค่าขนาดฟอนต์เป็น 10
		tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
		tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
	}
}

//บันทึกการนำเสนอลงดิสก์
pres.Save("C:\\data\\tblSLD.ppt", SaveFormat.Ppt);
```