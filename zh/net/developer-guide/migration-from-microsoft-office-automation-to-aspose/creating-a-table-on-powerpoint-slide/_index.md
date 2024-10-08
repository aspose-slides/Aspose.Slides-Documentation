---
title: 在PowerPoint幻灯片上创建表格
type: docs
weight: 50
url: /net/creating-a-table-on-powerpoint-slide/
---

{{% alert color="primary" %}} 

表格广泛用于在演示文稿幻灯片上显示数据。本文展示了如何使用 [VSTO 2008](/slides/net/creating-a-table-on-powerpoint-slide/) 以编程方式创建一个15 x 15的表格，字体大小为10，然后使用 [Aspose.Slides for .NET](/slides/net/creating-a-table-on-powerpoint-slide/)。

{{% /alert %}} 
## **创建表格**
#### **VSTO 2008 示例**
以下步骤使用VSTO向Microsoft PowerPoint幻灯片添加一个表格：

1. 创建一个演示文稿。
1. 向演示文稿添加一个空白幻灯片。
1. 向幻灯片添加一个15 x 15的表格。
1. 向表格的每个单元格添加字体大小为10的文本。
1. 将演示文稿保存到磁盘。

```c#
//创建演示文稿
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
              .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//添加一个空白幻灯片
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//添加一个15 x 15的表格
PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);
PowerPoint.Table tbl = shp.Table;
int i = -1;
int j = -1;

//循环遍历所有行
foreach (PowerPoint.Row row in tbl.Rows)
{
    i = i + 1;
    j = -1;

    //循环遍历行中的所有单元格
    foreach (PowerPoint.Cell cell in row.Cells)
    {
        j = j + 1;
        //获取每个单元格的文本框
        PowerPoint.TextFrame tf = cell.Shape.TextFrame;
        //添加一些文本
        tf.TextRange.Text = "T" + i.ToString() + j.ToString();
        //将文本字体大小设置为10
        tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;
    }
}

//将演示文稿保存到磁盘
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **Aspose.Slides for .NET 示例**
以下步骤使用Aspose.Slides向Microsoft PowerPoint幻灯片添加一个表格：

1. 创建一个演示文稿。
1. 向第一张幻灯片添加一个15 x 15的表格。
1. 向表格的每个单元格添加字体大小为10的文本。
1. 将演示文稿写入磁盘。

```c#
Presentation pres = new Presentation();

//访问第一张幻灯片
ISlide sld = pres.Slides[0];

//定义具有宽度的列和具有高度的行
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//添加一个表格
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//为每个单元格设置边框格式
foreach (IRow row in tbl.Rows)
{
	foreach (ICell cell in row)
	{

		//获取每个单元格的文本框
		ITextFrame tf = cell.TextFrame;
		//添加一些文本
		tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
		//设置字体大小为10
		tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
		tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
	}
}

//将演示文稿写入磁盘
pres.Save("C:\\data\\tblSLD.ppt", SaveFormat.Ppt);
```