---
title: 動的にテキストを追加する
type: docs
weight: 40
url: /net/adding-text-dynamically/
---

両方の方法は次のステップに従います：

- プレゼンテーションを作成します。
- 空のスライドを追加します。
- テキストボックスを追加します。
- テキストを設定します。
- プレゼンテーションを書き出します。
## **VSTO**
``` csharp

 private void AddTextBox()

{

	//プレゼンテーションを作成します

	PowerPoint.Presentation pres = Globals.ThisAddIn.Application

		.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

	//空白スライドのレイアウトを取得します

	PowerPoint.CustomLayout layout = pres.SlideMaster.

		CustomLayouts[7];

	//空のスライドを追加します

	PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

	//テキストを追加します

	PowerPoint.Shape shp =sld.Shapes.AddTextbox

	(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,150, 100, 400, 100);

	//テキストを設定します

	PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

	txtRange.Text = "動的に追加されたテキスト";

	txtRange.Font.Name = "Arial";

	txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;

	txtRange.Font.Size = 32;

	//出力をディスクに書き込みます

	pres.SaveAs("outVSTOAddingText.ppt",

		PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

		Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 static void AddTextBox()

{

	//プレゼンテーションを作成します

	Presentation pres = new Presentation();

	//デフォルトコンストラクタからプレゼンテーションを作成すると

	//空白スライドがデフォルトで追加されます

	//したがって、空のスライドを追加する必要はありません

	Slide sld = pres.GetSlideByPosition(1);

	//Arialフォントのインデックスを取得します

	//デフォルトコンストラクタからプレゼンテーションを作成すると常に0です

	int arialFontIndex = 0;

	//テキストボックスを追加します

	//追加するには、最初に長方形を追加します

	Shape shp = sld.Shapes.AddRectangle(1200, 800, 3200, 370);

	//その線を隠します

	shp.LineFormat.ShowLines = false;

	//次に、その中にテキストフレームを追加します

	TextFrame tf = shp.AddTextFrame("");

	//テキストを設定します

	tf.Text = "動的に追加されたテキスト";

	Portion port = tf.Paragraphs[0].Portions[0];

	port.FontIndex = arialFontIndex;

	port.FontBold = true;

	port.FontHeight = 32;

	//出力をディスクに書き込みます

	pres.Write("outAspose.ppt");

}

``` 
## **サンプルコードのダウンロード**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772947)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Text.Dynamically.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Adding%20Text%20Dynamically%20\(Aspose.Slides\).zip)