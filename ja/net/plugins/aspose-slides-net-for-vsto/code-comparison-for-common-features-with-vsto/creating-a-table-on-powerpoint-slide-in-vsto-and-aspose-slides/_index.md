---
title: VSTOとAspose.Slidesを使用してPowerPointスライドにテーブルを作成する
type: docs
weight: 90
url: /ja/net/creating-a-table-on-powerpoint-slide-in-vsto-and-aspose-slides/
---

以下の手順で、VSTOを使用してMicrosoft PowerPointスライドにテーブルを追加します。

- プレゼンテーションを作成します。
- 空のスライドをプレゼンテーションに追加します。
- スライドに15 x 15のテーブルを追加します。
- テーブルの各セルにフォントサイズ10のテキストを追加します。
- プレゼンテーションをディスクに保存します。
## **VSTO**
``` csharp

 //プレゼンテーションを作成

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

			  .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//空白のスライドを追加

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//15 x 15のテーブルを追加

PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);

PowerPoint.Table tbl = shp.Table;

int i = -1;

int j = -1;

//すべての行をループ

foreach (PowerPoint.Row row in tbl.Rows)

{

	i = i + 1;

	j = -1;

	//行内のすべてのセルをループ

	foreach (PowerPoint.Cell cell in row.Cells)

	{

		j = j + 1;

		//各セルのテキストフレームを取得

		PowerPoint.TextFrame tf = cell.Shape.TextFrame;

		//テキストを追加

		tf.TextRange.Text = "T" + i.ToString() + j.ToString();

		//テキストのフォントサイズを10に設定

		tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;

	}

}

//プレゼンテーションをディスクに保存

pres.SaveAs("tblVSTO.ppt",

	  PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	  Microsoft.Office.Core.MsoTriState.msoFalse);

``` 

以下の手順で、Aspose.Slidesを使用してMicrosoft PowerPointスライドにテーブルを追加します。

- プレゼンテーションを作成します。
- 最初のスライドに15 x 15のテーブルを追加します。
- テーブルの各セルにフォントサイズ10のテキストを追加します。
- プレゼンテーションをディスクに書き込みます。
## **Aspose.Slides**
``` csharp

 //プレゼンテーションを作成

Presentation pres = new Presentation();

//最初のスライドにアクセス

Slide sld = pres.GetSlideByPosition(1);

//テーブルを追加

Aspose.Slides.Table tbl = sld.Shapes.AddTable(50, 50, pres.SlideSize.Width - 100, pres.SlideSize.Height - 100, 15, 15);

//行をループ

for (int i = 0; i < tbl.RowsNumber; i++)

	//セルをループ

	for (int j = 0; j < tbl.ColumnsNumber; j++)

	{

		//各セルのテキストフレームを取得

		TextFrame tf = tbl.GetCell(j, i).TextFrame;

		//テキストを追加

		tf.Text = "T" + i.ToString() + j.ToString();

		//フォントサイズを10に設定

		tf.Paragraphs[0].Portions[0].FontHeight = 10;

		tf.Paragraphs[0].HasBullet = false;

	}

//プレゼンテーションをディスクに書き込む

pres.Write("tblSLD.ppt");

``` 
## **サンプルコードのダウンロード**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772951)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Creating.a.Table.on.PowerPoint.Slide.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Creating%20a%20Table%20on%20PowerPoint%20Slide%20\(Aspose.Slides\).zip)