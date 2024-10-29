---
title: VSTO と Aspose.Slides および .NETを使用してテキストをフォーマットする
type: docs
weight: 30
url: /ja/net/format-text-using-vsto-and-aspose-slides-and-net/
---

{{% alert color="primary" %}} 

時には、スライド上のテキストをプログラムでフォーマットする必要があります。この記事では、[VSTO](/slides/ja/net/format-text-using-vsto-and-aspose-slides-and-net/) と [Aspose.Slides for .NET](/slides/ja/net/format-text-using-vsto-and-aspose-slides-and-net/) を使用して、最初のスライドにいくつかのテキストが含まれているサンプルプレゼンテーションを読み取る方法を示します。このコードは、スライド上の3番目のテキストボックスのテキストを、最後のテキストボックスのテキストのように見えるようにフォーマットします。

{{% /alert %}} 
## **テキストのフォーマット**
VSTO と Aspose.Slides の両方のメソッドは、次のステップを実行します：

1. ソースプレゼンテーションを開く。
1. 最初のスライドにアクセスする。
1. 3番目のテキストボックスにアクセスする。
1. 3番目のテキストボックスのテキストのフォーマットを変更する。
1. プレゼンテーションをディスクに保存する。

以下のスクリーンショットは、VSTO と Aspose.Slides for .NET のコードを実行する前後のサンプルスライドを示しています。

**入力プレゼンテーション** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **VSTO コード例**
以下のコードは、VSTO を使用してスライド上のテキストを再フォーマットする方法を示しています。

**VSTO でフォーマットされたテキスト** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)



```c#
//注意: PowerPoint はこのように上で定義された名前空間です
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
PowerPoint.Presentation pres = null;

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

//水平方向に再配置する
shp.Left -= 70;

//出力をディスクに書き込む
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```




### **Aspose.Slides for .NET 例**
Aspose.Slides を使用してテキストをフォーマットするには、テキストをフォーマットする前にフォントを追加します。

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
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//シェイプの背景色を変更する
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//出力をディスクに書き込む
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```