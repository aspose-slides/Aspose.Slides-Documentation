---
title: 在 VSTO 和 Aspose.Slides 中在 PowerPoint 幻灯片上创建表格
type: docs
weight: 90
url: /zh/net/creating-a-table-on-powerpoint-slide-in-vsto-and-aspose-slides/
---

以下步骤使用 VSTO 向 Microsoft PowerPoint 幻灯片添加表格：

- 创建演示文稿。
- 向演示文稿添加一个空白幻灯片。
- 在幻灯片上添加一个 15 x 15 的表格。
- 向表格的每个单元格添加文字，字体大小为 10。
- 将演示文稿保存到磁盘。

## **VSTO**
``` csharp

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

pres.SaveAs("tblVSTO.ppt",

	  PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	  Microsoft.Office.Core.MsoTriState.msoFalse);

``` 

以下步骤使用 Aspose.Slides 向 Microsoft PowerPoint 幻灯片添加表格：

- 创建演示文稿。
- 在第一张幻灯片上添加一个 15 x 15 的表格。
- 向表格的每个单元格添加文字，字体大小为 10。
- 将演示文稿写入磁盘。

## **Aspose.Slides**
``` csharp

 //Create a presentation

Presentation pres = new Presentation();

//Access first slide

Slide sld = pres.GetSlideByPosition(1);

//Add a table

Aspose.Slides.Table tbl = sld.Shapes.AddTable(50, 50, pres.SlideSize.Width - 100, pres.SlideSize.Height - 100, 15, 15);

//Loop through rows

for (int i = 0; i < tbl.RowsNumber; i++)

	//Loop through cells

	for (int j = 0; j < tbl.ColumnsNumber; j++)

	{

		//Get text frame of each cell

		TextFrame tf = tbl.GetCell(j, i).TextFrame;

		//Add some text

		tf.Text = "T" + i.ToString() + j.ToString();

		//Set font size of 10

		tf.Paragraphs[0].Portions[0].FontHeight = 10;

		tf.Paragraphs[0].HasBullet = false;

	}

//Write the presentation to the disk

pres.Write("tblSLD.ppt");

``` 
## **下载示例代码**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Creating.a.Table.on.PowerPoint.Slide.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide/)