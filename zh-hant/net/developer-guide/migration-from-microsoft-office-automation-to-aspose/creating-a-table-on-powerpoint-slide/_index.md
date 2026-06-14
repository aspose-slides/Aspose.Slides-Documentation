---
title: 使用 VSTO 與 Aspose.Slides for .NET 建立表格
linktitle: 建立表格
type: docs
weight: 50
url: /zh-hant/net/creating-a-table-on-powerpoint-slide/
keywords:
- 建立表格
- 遷移
- VSTO
- Office 自動化
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "從 Microsoft Office 自動化遷移至 Aspose.Slides for .NET，並以 C# 在 PowerPoint (PPT、PPTX) 投影片中建立表格，提供彈性格式設定。"
---
{{% alert color="primary" %}} 
表格廣泛用於在簡報投影片上顯示資料。本文說明如何先使用[VSTO 2008](/slides/zh-hant/net/creating-a-table-on-powerpoint-slide/)，再使用[Aspose.Slides for .NET](/slides/zh-hant/net/creating-a-table-on-powerpoint-slide/) 以程式方式建立一個 15 x 15、字型大小為 10 的表格。
{{% /alert %}} 
## **建立表格**
#### **VSTO 2008 範例**
以下步驟示範如何使用 VSTO 在 Microsoft PowerPoint 投影片中新增表格：

1. 建立簡報。
1. 在簡報中新增一張空白投影片。
1. 在投影片中新增一個 15 x 15 的表格。
1. 在表格的每個儲存格中加入字型大小為 10 的文字。
1. 將簡報儲存至磁碟。

```c#
//建立簡報
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
              .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//新增空白投影片
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Add a 15 x 15 table
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
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```

### **Aspose.Slides for .NET 範例**
以下步驟示範如何使用 Aspose.Slides 在 Microsoft PowerPoint 投影片中新增表格：

1. 建立簡報。
1. 在第一張投影片中新增一個 15 x 15 的表格。
1. 在表格的每個儲存格中加入字型大小為 10 的文字。
1. 將簡報寫入磁碟。

```c#
Presentation pres = new Presentation();

//存取第一張投影片
ISlide sld = pres.Slides[0];

//定義欄寬與列高
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//新增表格
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//設定每個儲存格的邊框格式
foreach (IRow row in tbl.Rows)
{
	foreach (ICell cell in row)
	{

		//取得每個儲存格的文字框
		ITextFrame tf = cell.TextFrame;
		//加入文字
		tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
		//設定字型大小為 10
		tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
		tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
	}
}

//將簡報寫入磁碟
pres.Save("C:\\data\\tblSLD.ppt", SaveFormat.Ppt);
```