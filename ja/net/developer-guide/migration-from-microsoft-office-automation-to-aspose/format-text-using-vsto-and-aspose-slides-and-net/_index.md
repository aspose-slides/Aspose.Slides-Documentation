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
- Office の自動化
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office の自動化から Aspose.Slides for .NET に移行し、PowerPoint (PPT、PPTX) プレゼンテーションのテキストを正確に制御しながら書式設定します。"
---

{{% alert color="primary" %}} 
時々、スライド上のテキストをプログラムでフォーマットする必要があります。このガイドでは、[VSTO](/slides/ja/net/format-text-using-vsto-and-aspose-slides-and-net/) または[Aspose.Slides for .NET](/slides/ja/net/format-text-using-vsto-and-aspose-slides-and-net/) を使用して、最初のスライドにテキストが含まれるサンプルプレゼンテーションを読み取る方法を示します。コードはスライド上の3番目のテキストボックスのテキストを、最後のテキストボックスのテキストと同じようにフォーマットします。
{{% /alert %}} 
## **テキストの書式設定**
VSTO と Aspose.Slides の両方の方法は、以下の手順を実行します：

1. ソースプレゼンテーションを開く。
1. 最初のスライドにアクセスする。
1. 3番目のテキストボックスにアクセスする。
1. 3番目のテキストボックスのテキストの書式設定を変更する。
1. プレゼンテーションをディスクに保存する。

以下のスクリーンショットは、VSTO と Aspose.Slides for .NET のコード実行前後のサンプルスライドを示しています。

**入力プレゼンテーション** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **VSTO コード例**
以下のコードは、VSTO を使用してスライド上のテキストを再フォーマットする方法を示します。

**VSTO で再フォーマットされたテキスト** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)
```c#
//注: PowerPoint は、上記のように定義された名前空間です
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
 //プレゼンテーションを開く
pres = Globals.ThisAddIn.Application.Presentations.Open("c:\\source.ppt",
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoTrue);

//最初のスライドにアクセスする
PowerPoint.Slide slide = pres.Slides[1];

//3番目のシェイプにアクセスする
PowerPoint.Shape shp = slide.Shapes[3];

//テキストのフォントを Verdana に、サイズを 32 に変更する
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Font.Name = "Verdana";
txtRange.Font.Size = 32;

//太字にする
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//イタリック体にする
txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//テキストの色を変更する
txtRange.Font.Color.RGB = 0x00CC3333;

//シェイプの背景色を変更する
shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//横方向に位置を調整する
shp.Left -= 70;

//出力をディスクに保存する
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Aspose.Slides for .NET の例**
Aspose.Slides でテキストをフォーマットするには、テキストをフォーマットする前にフォントを追加します。

**Aspose.Slides で作成された出力プレゼンテーション** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)
```c#
 //プレゼンテーションを開く
Presentation pres = new Presentation("c:\\source.ppt");

//最初のスライドにアクセスする
ISlide slide = pres.Slides[0];

//3番目のシェイプにアクセスする
IShape shp = slide.Shapes[2];

//テキストのフォントを Verdana に、サイズを 32 に変更する
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//太字にする
port.PortionFormat.FontBold = NullableBool.True;

//イタリック体にする
port.PortionFormat.FontItalic = NullableBool.True;

//テキストの色を変更する
//フォントの色を設定する
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//シェイプの背景色を変更する
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//出力をディスクに保存する
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```
