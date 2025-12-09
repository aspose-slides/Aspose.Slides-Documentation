---
title: 使用 VSTO 和 Aspose.Slides for .NET 创建表格
linktitle: 创建表格
type: docs
weight: 50
url: /zh/net/creating-a-table-on-powerpoint-slide/
keywords:
- 创建表格
- 迁移
- VSTO
- Office 自动化
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "从 Microsoft Office 自动化迁移到 Aspose.Slides for .NET，并在 C# 中以灵活的格式创建 PowerPoint（PPT、 PPTX）幻灯片中的表格。"
---

{{% alert color="primary" %}} 

表格广泛用于在演示幻灯片上显示数据。本文展示了如何先使用[VSTO 2008](/slides/zh/net/creating-a-table-on-powerpoint-slide/)然后使用[Aspose.Slides for .NET](/slides/zh/net/creating-a-table-on-powerpoint-slide/)以编程方式创建一个 15 x 15、字体大小为 10 的表格。

{{% /alert %}} 
## **创建表格**
#### **VSTO 2008 示例**
以下步骤使用 VSTO 在 Microsoft PowerPoint 幻灯片中添加表格：

1. 创建一个演示文稿。
1. 向演示文稿添加一个空白幻灯片。
1. 在幻灯片上添加一个 15 x 15 的表格。
1. 向表格的每个单元格添加字体大小为 10 的文本。
1. 将演示文稿保存到磁盘。
```c#
//创建演示文稿
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
              .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//添加空白幻灯片
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//添加一个 15 x 15 表格
PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);
PowerPoint.Table tbl = shp.Table;
int i = -1;
int j = -1;

//遍历所有行
foreach (PowerPoint.Row row in tbl.Rows)
{
    i = i + 1;
    j = -1;

    //遍历该行中的所有单元格
    foreach (PowerPoint.Cell cell in row.Cells)
    {
        j = j + 1;
        //获取每个单元格的文本框架
        PowerPoint.TextFrame tf = cell.Shape.TextFrame;
        //添加一些文本
        tf.TextRange.Text = "T" + i.ToString() + j.ToString();
        //将文本的字体大小设置为 10
        tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;
    }
}

//将演示文稿保存到磁盘
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Aspose.Slides for .NET 示例**
以下步骤使用 Aspose.Slides 在 Microsoft PowerPoint 幻灯片中添加表格：

1. 创建一个演示文稿。
1. 在第一张幻灯片上添加一个 15 x 15 的表格。
1. 向表格的每个单元格添加字体大小为 10 的文本。
1. 将演示文稿写入磁盘。
```c#
Presentation pres = new Presentation();

//Access first slide
//访问第一张幻灯片
ISlide sld = pres.Slides[0];

//Define columns with widths and rows with heights
//定义列宽和行高
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//Add a table
//添加表格
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//Set border format for each cell
//为每个单元格设置边框格式
foreach (IRow row in tbl.Rows)
{
	foreach (ICell cell in row)
	{

		//Get text frame of each cell
		//获取每个单元格的文本框架
		ITextFrame tf = cell.TextFrame;
		//Add some text
		//添加一些文本
		tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
		//Set font size of 10
		//将字体大小设置为 10
		tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
		tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
	}
}

//Write the presentation to the disk
pres.Save("C:\\data\\tblSLD.ppt", SaveFormat.Ppt);
```
