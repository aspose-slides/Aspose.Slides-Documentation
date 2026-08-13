---
title: VSTO と Aspose.Slides for .NET を使用したテキストの動的追加
linktitle: テキストの動的追加
type: docs
weight: 20
url: /ja/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
keywords:
- テキストの追加
- 移行
- VSTO
- Office 自動化
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office の自動化から Aspose.Slides for .NET へ移行し、C# で PowerPoint (PPT, PPTX) プレゼンテーションに動的テキストを追加する方法を確認してください。"
---
{{% alert color="info" %}} 

開発者が一般的に行うタスクは、スライドにテキストを動的に追加することです。本記事では、[VSTO](/slides/ja/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) と [Aspose.Slides for .NET](/slides/ja/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) を使用したテキストの動的追加のコード例を示します。

{{% /alert %}} 
## **Adding Text Dynamically**
両方の方法は以下の手順に従います：

1. プレゼンテーションを作成します。
1. 空白のスライドを追加します。
1. テキストボックスを追加します。
1. テキストを設定します。
1. プレゼンテーションを書き出します。
## **VSTO Code Example**
以下のコードスニペットは、プレーンなスライドとテキスト文字列が配置されたプレゼンテーションを生成します。

**The presentation as created in VSTO** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)

```c#
//注: PowerPoint は上記のように定義された名前空間です
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



## **Aspose.Slides for .NET Example**
以下のコードスニペットは、Aspose.Slides を使用して、プレーンなスライドとテキスト文字列が配置されたプレゼンテーションを作成します。

**The presentation as created using Aspose.Slides for .NET** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

//プレゼンテーションを作成
Presentation pres = new Presentation();

//デフォルトでは、作成時に空白スライドが追加されます
//デフォルトコンストラクタからのプレゼンテーション
//したがって、空白スライドを追加する必要はありません
ISlide sld = pres.Slides[1];

//テキストボックスを追加
//追加するには、まず矩形を追加します
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//線を非表示にする
shp.LineFormat.Style = LineStyle.NotDefined;

//次にその内部にテキストフレームを追加
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//テキストを設定
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//Write the output to disk
pres.Save("outAspose.ppt", SaveFormat.Ppt);
```