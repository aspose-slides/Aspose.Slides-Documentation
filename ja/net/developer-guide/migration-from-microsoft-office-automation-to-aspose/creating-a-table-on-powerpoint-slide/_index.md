---
title: PowerPointスライドにテーブルを作成する
type: docs
weight: 50
url: /ja/net/creating-a-table-on-powerpoint-slide/
---

{{% alert color="primary" %}} 

テーブルはプレゼンテーションスライドでデータを表示するために広く使用されています。この記事では、最初に [VSTO 2008](/slides/ja/net/creating-a-table-on-powerpoint-slide/) を使用し、次に [Aspose.Slides for .NET](/slides/ja/net/creating-a-table-on-powerpoint-slide/) を使用して、フォントサイズ10の15 x 15テーブルをプログラムで作成する方法を示します。

{{% /alert %}} 
## **テーブルの作成**
#### **VSTO 2008の例**
次の手順で、VSTOを使用してMicrosoft PowerPointスライドにテーブルを追加します。

1. プレゼンテーションを作成します。
1. プレゼンテーションに空のスライドを追加します。
1. スライドに15 x 15テーブルを追加します。
1. フォントサイズ10でテーブルの各セルにテキストを追加します。
1. プレゼンテーションをディスクに保存します。

```c#
//プレゼンテーションを作成
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
              .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//空白のスライドを追加
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//15 x 15テーブルを追加
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
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **Aspose.Slides for .NETの例**
次の手順で、Aspose.Slidesを使用してMicrosoft PowerPointスライドにテーブルを追加します。

1. プレゼンテーションを作成します。
1. 最初のスライドに15 x 15テーブルを追加します。
1. フォントサイズ10でテーブルの各セルにテキストを追加します。
1. プレゼンテーションをディスクに書き込みます。

```c#
Presentation pres = new Presentation();

//最初のスライドにアクセス
ISlide sld = pres.Slides[0];

//幅が定義された列と高さが定義された行を定義
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//テーブルを追加
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//各セルの境界線形式を設定
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

//プレゼンテーションをディスクに書き込む
pres.Save("C:\\data\\tblSLD.ppt", SaveFormat.Ppt);
```