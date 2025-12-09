---
title: VSTO と Aspose.Slides for .NET を使用したテキストの動的追加
linktitle: テキストの動的追加
type: docs
weight: 20
url: /ja/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
keywords:
- テキストを追加
- 移行
- VSTO
- Office オートメーション
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office のオートメーションから Aspose.Slides for .NET へ移行し、C# で PowerPoint (PPT、PPTX) プレゼンテーションに動的テキストを追加する方法をご覧ください。"
---

{{% alert color="primary" %}} 
開発者がよく行う一般的なタスクは、スライドにテキストを動的に追加することです。この記事では、[VSTO](/slides/ja/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) と [Aspose.Slides for .NET](/slides/ja/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) を使用してテキストを動的に追加するコード例を示します。
{{% /alert %}} 
## **テキストの動的追加**
両方の方法は次の手順に従います。

1. プレゼンテーションを作成する。
1. 空白のスライドを追加する。
1. テキストボックスを追加する。
1. テキストを設定する。
1. プレゼンテーションを書き出す。
## **VSTO コード例**
以下のコードスニペットは、シンプルなスライドとテキスト文字列を含むプレゼンテーションを生成します。

**VSTOで作成されたプレゼンテーション** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)
```c#
//注: PowerPoint は、以下のように上で定義された名前空間です
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//プレゼンテーションを作成
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//空白スライドのレイアウトを取得
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//空白スライドを追加
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//テキストを追加
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//テキストを設定
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Text added dynamically";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//出力をディスクに保存
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);

```




## **Aspose.Slides for .NET の例**
以下のコードスニペットは、Aspose.Slides を使用してシンプルなスライドとテキスト文字列を含むプレゼンテーションを作成します。

**Aspose.Slides for .NET を使用して作成されたプレゼンテーション** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)
```c#
//プレゼンテーションを作成
Presentation pres = new Presentation();

//デフォルトで空白スライドが追加されます、作成時に
//デフォルトコンストラクタからプレゼンテーション
//そのため、空白スライドを追加する必要はありません
ISlide sld = pres.Slides[1];

//テキストボックスを追加
//追加するには、まず矩形を追加します
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//線を非表示にする
shp.LineFormat.Style = LineStyle.NotDefined;

//その中にテキストフレームを追加
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//テキストを設定
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//出力をディスクに保存
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```
