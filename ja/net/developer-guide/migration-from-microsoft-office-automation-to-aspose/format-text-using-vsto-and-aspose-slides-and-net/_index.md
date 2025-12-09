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
description: "Microsoft Office automation から Aspose.Slides for .NET へ移行し、PowerPoint (PPT, PPTX) プレゼンテーションのテキストを書式設定し、正確に制御します。"
---

{{% alert color="primary" %}} 

スライド上のテキストをプログラムで書式設定する必要がある場合があります。このガイドでは、[VSTO](/slides/ja/net/format-text-using-vsto-and-aspose-slides-and-net/) または [Aspose.Slides for .NET](/slides/ja/net/format-text-using-vsto-and-aspose-slides-and-net/) を使用して、最初のスライドにテキストが含まれるサンプルプレゼンテーションを読み込む方法を示します。コードは、スライド上の 3 番目のテキストボックスのテキストを書式設定し、最後のテキストボックスのテキストと同じ外観にします。

{{% /alert %}} 
## **テキストの書式設定**
VSTO と Aspose.Slides の両方の方法は、以下の手順で実行されます。

1. 元のプレゼンテーションを開く。
1. 最初のスライドにアクセスする。
1. 3 番目のテキストボックスにアクセスする。
1. 3 番目のテキストボックス内のテキストの書式を変更する。
1. プレゼンテーションをディスクに保存する。

以下のスクリーンショットは、VSTO と Aspose.Slides for .NET のコードを実行した前後のサンプルスライドを示しています。

**入力プレゼンテーション** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **VSTO コード例**
以下のコードは、VSTO を使用してスライド上のテキストを書き換える方法を示しています。

**VSTO で書式設定されたテキスト** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)
```c#
//注: PowerPoint は上記のように定義された名前空間です
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
PowerPoint.Presentation pres = null;

//プレゼンテーションを開く
pres = Globals.ThisAddIn.Application.Presentations.Open("c:\\source.ppt",
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoTrue);

//最初のスライドにアクセス
PowerPoint.Slide slide = pres.Slides[1];

//3番目のシェイプにアクセス
PowerPoint.Shape shp = slide.Shapes[3];

//テキストのフォントを Verdana に、サイズを 32 に変更
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Font.Name = "Verdana";
txtRange.Font.Size = 32;

//太字にする
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//斜体にする
txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//テキストの色を変更
txtRange.Font.Color.RGB = 0x00CC3333;

//シェイプの背景色を変更
shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//水平方向に位置を変更
shp.Left -= 70;

//出力をディスクに保存
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```





### **Aspose.Slides for .NET の例**
Aspose.Slides でテキストを書式設定するには、テキストを書式設定する前にフォントを追加します。

**Aspose.Slides で作成された出力プレゼンテーション** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)
```c#
 //プレゼンテーションを開く
Presentation pres = new Presentation("c:\\source.ppt");

//最初のスライドにアクセス
ISlide slide = pres.Slides[0];

//3番目のシェイプにアクセス
IShape shp = slide.Shapes[2];

//テキストのフォントを Verdana に、サイズを 32 に変更
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//太字にする
port.PortionFormat.FontBold = NullableBool.True;

//斜体にする
port.PortionFormat.FontItalic = NullableBool.True;

//テキストの色を変更
//フォントの色を設定
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//シェイプの背景色を変更
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//出力をディスクに保存
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```
