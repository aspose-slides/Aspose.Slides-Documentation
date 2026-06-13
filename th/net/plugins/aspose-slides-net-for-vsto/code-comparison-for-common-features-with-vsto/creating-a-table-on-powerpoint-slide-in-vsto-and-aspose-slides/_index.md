---
title: สร้างตารางบนสไลด์ PowerPoint ด้วย VSTO และ Aspose.Slides
type: docs
weight: 90
url: /th/net/creating-a-table-on-powerpoint-slide-in-vsto-and-aspose-slides/
---
ขั้นตอนต่อไปนี้จะเพิ่มตารางลงในสไลด์ Microsoft PowerPoint โดยใช้ VSTO:

- สร้างพรีเซนเทชัน
- เพิ่มสไลด์เปล่าไปยังพรีเซนเทชัน
- เพิ่มตารางขนาด 15 x 15 ลงในสไลด์
- เพิ่มข้อความในแต่ละเซลล์ของตารางโดยใช้ขนาดฟอนต์ 10
- บันทึกพรีเซนเทชันลงดิสก์
## **VSTO**
``` csharp

 //สร้างพรีเซนเทชัน

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

		//ดึงเฟรมข้อความของแต่ละเซลล์

		PowerPoint.TextFrame tf = cell.Shape.TextFrame;

		//เพิ่มข้อความบางส่วน

		tf.TextRange.Text = "T" + i.ToString() + j.ToString();

		//ตั้งขนาดฟอนต์ของข้อความเป็น 10

		tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;

	}

}

//บันทึกพรีเซนเทชันลงดิสก์

pres.SaveAs("tblVSTO.ppt",

	  PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	  Microsoft.Office.Core.MsoTriState.msoFalse);

``` 

ขั้นตอนต่อไปนี้จะเพิ่มตารางลงในสไลด์ Microsoft PowerPoint โดยใช้ Aspose.Slides:

- สร้างพรีเซนเทชัน
- เพิ่มตารางขนาด 15 x 15 ไปยังสไลด์แรก
- เพิ่มข้อความในแต่ละเซลล์ของตารางโดยใช้ขนาดฟอนต์ 10
- เขียนพรีเซนเทชันลงดิสก์
## **Aspose.Slides**
``` csharp

 //สร้างพรีเซนเทชัน

Presentation pres = new Presentation();

//เข้าถึงสไลด์แรก

Slide sld = pres.GetSlideByPosition(1);

//เพิ่มตาราง

Aspose.Slides.Table tbl = sld.Shapes.AddTable(50, 50, pres.SlideSize.Width - 100, pres.SlideSize.Height - 100, 15, 15);

//วนลูปผ่านแถว

for (int i = 0; i < tbl.RowsNumber; i++)

	//วนลูปผ่านเซลล์

	for (int j = 0; j < tbl.ColumnsNumber; j++)

	{

		//ดึงเฟรมข้อความของแต่ละเซลล์

		TextFrame tf = tbl.GetCell(j, i).TextFrame;

		//เพิ่มข้อความบางส่วน

		tf.Text = "T" + i.ToString() + j.ToString();

		//ตั้งค่าขนาดฟอนต์เป็น 10

		tf.Paragraphs[0].Portions[0].FontHeight = 10;

		tf.Paragraphs[0].HasBullet = false;

	}

//เขียนพรีเซนเทชันลงดิสก์

pres.Write("tblSLD.ppt");

``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Creating.a.Table.on.PowerPoint.Slide.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide/)