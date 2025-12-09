---
title: VSTO と Aspose.Slides for .NET を使用したテキストの書式設定
linktitle: テキストの書式設定
type: docs
weight: 30
url: /ja/net/format-text-using-vsto-and-aspose-slides-and-net/
keywords:
- テキストの書式設定
- 移行
- VSTO
- Office 自動化
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office の自動化から Aspose.Slides for .NET へ移行し、PowerPoint (PPT, PPTX) プレゼンテーションのテキストを正確に制御して書式設定します。"
---

{{% alert color="primary" %}} 

スライド上のテキストをプログラムで書式設定する必要がある場合があります。この記事では、[VSTO](/slides/ja/net/format-text-using-vsto-and-aspose-slides-and-net/) および [Aspose.Slides for .NET](/slides/ja/net/format-text-using-vsto-and-aspose-slides-and-net/) のいずれかを使用して、最初のスライドにテキストがあるサンプル プレゼンテーションを読み取る方法を示します。コードは、スライド上の 3 番目のテキスト ボックスのテキストの書式を、最後のテキスト ボックスのテキストと同じように変更します。

{{% /alert %}} 
## **テキストの書式設定**
VSTO と Aspose.Slides の両方のメソッドは、次の手順を実行します。

1. 元のプレゼンテーションを開く。
1. 最初のスライドにアクセスする。
1. 3 番目のテキスト ボックスにアクセスする。
1. 3 番目のテキスト ボックス内のテキストの書式を変更する。
1. プレゼンテーションをディスクに保存する。

以下のスクリーンショットは、VSTO と Aspose.Slides for .NET のコード実行前後のサンプル スライドを示しています。

**入力プレゼンテーション** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **VSTO コード例**
以下のコードは、VSTO を使用してスライド上のテキストを書き直す方法を示します。

**VSTO で書式変更されたテキスト** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)
```c#
//注: PowerPoint は上で次のように定義された名前空間です
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
PowerPoint.Presentation pres = null;

//プレゼンテーションを開く
pres = Globals.ThisAddIn.Application.Presentations.Open("c:\\source.ppt",
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoTrue);

//最初のスライドにアクセスする
PowerPoint.Slide slide = pres.Slides[1];

//3 番目の図形にアクセスする
PowerPoint.Shape shp = slide.Shapes[3];

//テキストのフォントを Verdana、サイズを 32 に変更する
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Font.Name = "Verdana";
txtRange.Font.Size = 32;

//太字にする
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//斜体にする
txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//テキストの色を変更する
txtRange.Font.Color.RGB = 0x00CC3333;

//図形の背景色を変更する
shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//水平方向に位置を変更する
shp.Left -= 70;

//出力をディスクに保存する
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Aspose.Slides for .NET の例**
Aspose.Slides でテキストをフォーマットするには、テキストを書式設定する前にフォントを追加します。

**Aspose.Slides で作成された出力プレゼンテーション** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)
```c#
 //プレゼンテーションを開く
Presentation pres = new Presentation("c:\\source.ppt");

//Access the first slide
//最初のスライドにアクセスする
ISlide slide = pres.Slides[0];

//Access the third shape
//3番目の図形にアクセスする
IShape shp = slide.Shapes[2];

//Change its text's font to Verdana and height to 32
//テキストのフォントを Verdana に、サイズを 32 に変更する
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//Bolden it
//太字にする
port.PortionFormat.FontBold = NullableBool.True;

//Italicize it
//斜体にする
port.PortionFormat.FontItalic = NullableBool.True;

//Change text color
//テキストの色を変更する
//Set font color
//フォントの色を設定する
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//Change shape background color
//図形の背景色を変更する
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Write the output to disk
//出力をディスクに保存する
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```
