---
title: VSTO と Aspose.Slides for .NET を使用したテーブル作成
linktitle: テーブル作成
type: docs
weight: 50
url: /ja/net/creating-a-table-on-powerpoint-slide/
keywords:
- テーブル作成
- 移行
- VSTO
- Office 自動化
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office の自動化から Aspose.Slides for .NET に移行し、C# で柔軟な書式設定が可能な PowerPoint (PPT, PPTX) スライドにテーブルを作成します。"
---

{{% alert color="primary" %}} 

テーブルはプレゼンテーションスライド上でデータを表示するために広く使用されます。このガイドでは、まず[VSTO 2008](/slides/ja/net/creating-a-table-on-powerpoint-slide/)を使用し、次に[Aspose.Slides for .NET](/slides/ja/net/creating-a-table-on-powerpoint-slide/)を使用して、フォントサイズ10の15×15テーブルをプログラムで作成する方法を示します。

{{% /alert %}} 
## **テーブルの作成**
#### **VSTO 2008 の例**
以下の手順で、VSTO を使用して Microsoft PowerPoint スライドにテーブルを追加します。

1. プレゼンテーションを作成します。
1. 空のスライドをプレゼンテーションに追加します。
1. スライドに 15×15 テーブルを追加します。
1. テーブルの各セルにフォントサイズ 10 のテキストを追加します。
1. プレゼンテーションをディスクに保存します。
```c#
//プレゼンテーションを作成
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
              .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//空白のスライドを追加
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//15 x 15 のテーブルを追加
PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);
PowerPoint.Table tbl = shp.Table;
int i = -1;
int j = -1;

//すべての行をループ
foreach (PowerPoint.Row row in tbl.Rows)
{
    i = i + 1;
    j = -1;

    //行のすべてのセルをループ
    foreach (PowerPoint.Cell cell in row.Cells)
    {
        j = j + 1;
        //各セルのテキストフレームを取得
        PowerPoint.TextFrame tf = cell.Shape.TextFrame;
        //テキストを追加
        tf.TextRange.Text = "T" + i.ToString() + j.ToString();
        //テキストのフォントサイズを 10 に設定
        tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;
    }
}

//プレゼンテーションをディスクに保存
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```




### **Aspose.Slides for .NET の例**
以下の手順で、Aspose.Slides を使用して Microsoft PowerPoint スライドにテーブルを追加します。

1. プレゼンテーションを作成します。
1. 最初のスライドに 15×15 テーブルを追加します。
1. テーブルの各セルにフォントサイズ 10 のテキストを追加します。
1. プレゼンテーションを書き出してディスクに保存します。
```c#
Presentation pres = new Presentation();

//最初のスライドにアクセス
ISlide sld = pres.Slides[0];

//幅付きの列と高さ付きの行を定義
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//テーブルを追加
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//各セルの罫線書式を設定
foreach (IRow row in tbl.Rows)
{
	foreach (ICell cell in row)
	{

		//各セルのテキストフレームを取得
		ITextFrame tf = cell.TextFrame;
		//テキストを追加
		tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
		//フォントサイズを10に設定
		tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
		tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
	}
}

//プレゼンテーションを書き出してディスクに保存
pres.Save("C:\\data\\tblSLD.ppt", SaveFormat.Ppt);
```
