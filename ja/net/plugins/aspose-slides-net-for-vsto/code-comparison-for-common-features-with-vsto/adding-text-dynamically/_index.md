---
title: テキストを動的に追加
type: docs
weight: 40
url: /ja/net/adding-text-dynamically/
---

両方のメソッドは以下の手順に従います：

- プレゼンテーションを作成します。
- 空白のスライドを追加します。
- テキストボックスを追加します。
- テキストを設定します。
- プレゼンテーションを書き出します。

## **VSTO**
``` csharp

 private void AddTextBox()

{

	// プレゼンテーションを作成

	PowerPoint.Presentation pres = Globals.ThisAddIn.Application

		.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

	// 空白のスライドレイアウトを取得

	PowerPoint.CustomLayout layout = pres.SlideMaster.

		CustomLayouts[7];

	// 空白のスライドを追加

	PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

	// テキストボックスを追加

	PowerPoint.Shape shp =sld.Shapes.AddTextbox

	(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,150, 100, 400, 100);

	// テキストを設定

	PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

	txtRange.Text = "Text added dynamically";

	txtRange.Font.Name = "Arial";

	txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;

	txtRange.Font.Size = 32;

	// 出力をディスクに保存

	pres.SaveAs("outVSTOAddingText.ppt",

		PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

		Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 static void AddTextBox()

{

	// プレゼンテーションを作成

	Presentation pres = new Presentation();

	// デフォルトコンストラクタで作成した場合、空白スライドはデフォルトで追加されます

	// したがって、空白スライドを追加する必要はありません

	Slide sld = pres.GetSlideByPosition(1);

	// Arial のフォントインデックスを取得

	// デフォルトコンストラクタで作成した場合は常に 0 です

	int arialFontIndex = 0;

	// テキストボックスを追加

	// まず矩形を追加します

	Shape shp = sld.Shapes.AddRectangle(1200, 800, 3200, 370);

	// 線を非表示にする

	shp.LineFormat.ShowLines = false;

	// その中にテキストフレームを追加

	TextFrame tf = shp.AddTextFrame("");

	// テキストを設定

	tf.Text = "Text added dynamically";

	Portion port = tf.Paragraphs[0].Portions[0];

	port.FontIndex = arialFontIndex;

	port.FontBold = true;

	port.FontHeight = 32;

	// 出力をディスクに保存

	pres.Write("outAspose.ppt");

}

``` 
## **サンプルコードをダウンロード**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Text.Dynamically.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20using%20VSTO%20and%20Aspose.Slides/)