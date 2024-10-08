---
title: 在 VSTO 和 Aspose.Slides 中创建 PowerPoint 幻灯片上的表格
type: docs
weight: 90
url: /zh/net/creating-a-table-on-powerpoint-slide-in-vsto-and-aspose-slides/
---

以下步骤使用 VSTO 向 Microsoft PowerPoint 幻灯片添加表格：

- 创建一个演示文稿。
- 向演示文稿添加一个空白幻灯片。
- 向幻灯片添加一个 15 x 15 的表格。
- 在表格的每个单元格中添加字体大小为 10 的文本。
- 将演示文稿保存到磁盘。
## **VSTO**
``` csharp

 //创建演示文稿

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

			  .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//添加一个空白幻灯片

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//添加一个 15 x 15 的表格

PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);

PowerPoint.Table tbl = shp.Table;

int i = -1;

int j = -1;

//遍历所有行

foreach (PowerPoint.Row row in tbl.Rows)

{

	i = i + 1;

	j = -1;

	//遍历行中的所有单元格

	foreach (PowerPoint.Cell cell in row.Cells)

	{

		j = j + 1;

		//获取每个单元格的文本框

		PowerPoint.TextFrame tf = cell.Shape.TextFrame;

		//添加一些文本

		tf.TextRange.Text = "T" + i.ToString() + j.ToString();

		//将文本字体大小设置为 10

		tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;

	}

}

//将演示文稿保存到磁盘

pres.SaveAs("tblVSTO.ppt",

	  PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	  Microsoft.Office.Core.MsoTriState.msoFalse);

``` 

以下步骤使用 Aspose.Slides 向 Microsoft PowerPoint 幻灯片添加表格：

- 创建一个演示文稿。
- 向第一张幻灯片添加一个 15 x 15 的表格。
- 在表格的每个单元格中添加字体大小为 10 的文本。
- 将演示文稿写入磁盘。
## **Aspose.Slides**
``` csharp

 //创建演示文稿

Presentation pres = new Presentation();

//访问第一张幻灯片

Slide sld = pres.GetSlideByPosition(1);

//添加一个表格

Aspose.Slides.Table tbl = sld.Shapes.AddTable(50, 50, pres.SlideSize.Width - 100, pres.SlideSize.Height - 100, 15, 15);

//遍历行

for (int i = 0; i < tbl.RowsNumber; i++)

	//遍历单元格

	for (int j = 0; j < tbl.ColumnsNumber; j++)

	{

		//获取每个单元格的文本框

		TextFrame tf = tbl.GetCell(j, i).TextFrame;

		//添加一些文本

		tf.Text = "T" + i.ToString() + j.ToString();

		//将字体大小设置为 10

		tf.Paragraphs[0].Portions[0].FontHeight = 10;

		tf.Paragraphs[0].HasBullet = false;

	}

//将演示文稿写入磁盘

pres.Write("tblSLD.ppt");

``` 
## **下载示例代码**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772951)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Creating.a.Table.on.PowerPoint.Slide.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Creating%20a%20Table%20on%20PowerPoint%20Slide%20\(Aspose.Slides\).zip)