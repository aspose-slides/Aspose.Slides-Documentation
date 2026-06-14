---
title: 在 VSTO 與 Aspose.Slides 中於 PowerPoint 投影片建立表格
type: docs
weight: 90
url: /zh-hant/net/creating-a-table-on-powerpoint-slide-in-vsto-and-aspose-slides/
---
以下步驟使用 VSTO 在 Microsoft PowerPoint 投影片中新增表格：

- 建立簡報。
- 向簡報新增空白投影片。
- 在投影片上新增 15 x 15 的表格。
- 在表格的每個儲存格中加入字型大小為 10 的文字。
- 將簡報儲存至磁碟。

## **VSTO**
``` csharp

 //建立簡報

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

			  .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//新增空白投影片

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//新增 15 x 15 表格

PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);

PowerPoint.Table tbl = shp.Table;

int i = -1;

int j = -1;

//遍歷所有列

foreach (PowerPoint.Row row in tbl.Rows)

{

	i = i + 1;

	j = -1;

	//遍歷該列中的所有儲存格

	foreach (PowerPoint.Cell cell in row.Cells)

	{

		j = j + 1;

		//取得每個儲存格的文字框

		PowerPoint.TextFrame tf = cell.Shape.TextFrame;

		//加入文字

		tf.TextRange.Text = "T" + i.ToString() + j.ToString();

		//將文字字型大小設定為 10

		tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;

	}

}

//將簡報儲存至磁碟

pres.SaveAs("tblVSTO.ppt",

	  PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	  Microsoft.Office.Core.MsoTriState.msoFalse);

``` 

以下步驟使用 Aspose.Slides 在 Microsoft PowerPoint 投影片中新增表格：

- 建立簡報。
- 在第一張投影片上新增 15 x 15 的表格。
- 在表格的每個儲存格中加入字型大小為 10 的文字。
- 將簡報寫入磁碟。

## **Aspose.Slides**
``` csharp

 //建立簡報
Presentation pres = new Presentation();

//存取第一張投影片
Slide sld = pres.GetSlideByPosition(1);

//新增表格
Aspose.Slides.Table tbl = sld.Shapes.AddTable(50, 50, pres.SlideSize.Width - 100, pres.SlideSize.Height - 100, 15, 15);

//遍歷列
for (int i = 0; i < tbl.RowsNumber; i++)
	//遍歷儲存格
	for (int j = 0; j < tbl.ColumnsNumber; j++)
	{
		//取得每個儲存格的文字框
		TextFrame tf = tbl.GetCell(j, i).TextFrame;
		//加入文字
		tf.Text = "T" + i.ToString() + j.ToString();
		//將字型大小設定為 10
		tf.Paragraphs[0].Portions[0].FontHeight = 10;
		tf.Paragraphs[0].HasBullet = false;
	}

//將簡報寫入磁碟
pres.Write("tblSLD.ppt");
``` 
## **下載範例程式碼**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Creating.a.Table.on.PowerPoint.Slide.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide/)