---
title: VSTOとAspose.Slides for .NETを使用してテキストを動的に追加する
type: docs
weight: 20
url: /ja/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
---

{{% alert color="primary" %}} 

開発者が達成する一般的なタスクは、スライドにテキストを動的に追加することです。この記事では、[VSTO](/slides/ja/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/)および[Aspose.Slides for .NET](/slides/ja/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/)を使用してテキストを動的に追加するためのコード例を示します。

{{% /alert %}} 
## **テキストを動的に追加する**
両方の方法は次の手順に従います：

1. プレゼンテーションを作成する。
2. 空白のスライドを追加する。
3. テキストボックスを追加する。
4. テキストを設定する。
5. プレゼンテーションを書き出す。
## **VSTOコード例**
以下のコードスニペットは、プレーンなスライドとその上にテキストの文字列を持つプレゼンテーションを生成します。

**VSTOで作成されたプレゼンテーション** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)

```c#
//注意: PowerPointは上で次のように定義された名前空間です
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//プレゼンテーションを作成する
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//空白のスライドレイアウトを取得する
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//空白のスライドを追加する
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//テキストを追加する
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//テキストを設定する
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "動的に追加されたテキスト";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//出力をディスクに保存する
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);

```



## **Aspose.Slides for .NETの例**
以下のコードスニペットは、Aspose.Slidesを使用してプレーンなスライドとその上にテキストの文字列を持つプレゼンテーションを作成します。

**Aspose.Slides for .NETを使用して作成されたプレゼンテーション** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)

```c#
//プレゼンテーションを作成する
Presentation pres = new Presentation();

//デフォルトのコンストラクターからプレゼンテーションを作成すると、空白のスライドが自動的に追加されます
//したがって、空白のスライドを追加する必要はありません
ISlide sld = pres.Slides[1];

//テキストボックスを追加する
//まずは長方形を追加します
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//その線を非表示にする
shp.LineFormat.Style = LineStyle.NotDefined;

//次に、その中にテキストフレームを追加します
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//テキストを設定する
tf.Text = "動的に追加されたテキスト";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//出力をディスクに保存する
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```