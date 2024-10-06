---
title: テキストのフォーマット
type: docs
weight: 110
url: /ja/net/format-text/
---

VSTOとAspose.Slidesの両方のメソッドは、以下の手順を実行します。

- ソースプレゼンテーションを開く。
- 最初のスライドにアクセスする。
- 三番目のテキストボックスにアクセスする。
- 三番目のテキストボックスのテキストのフォーマットを変更する。
- プレゼンテーションをディスクに保存する。
## **VSTO**
``` csharp

 //プレゼンテーションを開く

Presentation pres = new Presentation("source.ppt");

//Verdanaフォントを追加

FontEntity font = pres.Fonts[0];

FontEntity verdanaFont = new FontEntity(pres, font);

verdanaFont.FontName = "Verdana";

int verdanaFontIndex = pres.Fonts.Add(verdanaFont);

//最初のスライドにアクセス

Slide slide = pres.GetSlideByPosition(1);

//三番目のシェイプにアクセス

Shape shp = slide.Shapes[2];

//フォントをVerdanaに変更し、高さを32にする

TextFrame tf = shp.TextFrame;

Paragraph para = tf.Paragraphs[0];

Portion port = para.Portions[0];

port.FontIndex = verdanaFontIndex;

port.FontHeight = 32;

//太字にする

port.FontBold = true;

//イタリックにする

port.FontItalic = true;

//テキストの色を変更

port.FontColor = Color.FromArgb(0x33, 0x33, 0xCC);

//シェイプの背景色を変更

shp.FillFormat.Type = FillType.Solid;

shp.FillFormat.ForeColor = Color.FromArgb(0xCC, 0xCC, 0xFF);

//出力をディスクに書き込む

pres.Write("outAspose.ppt");

``` 
## **Aspose.Slides**
``` csharp

 PowerPoint.Presentation pres = null;

//プレゼンテーションを開く

pres = Globals.ThisAddIn.Application.Presentations.Open("source.ppt",

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoTrue);

//最初のスライドにアクセス

PowerPoint.Slide slide = pres.Slides[1];

//三番目のシェイプにアクセス

PowerPoint.Shape shp = slide.Shapes[3];

//フォントをVerdanaに変更し、高さを32にする

PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

txtRange.Font.Name = "Verdana";

txtRange.Font.Size = 32;

//太字にする

txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//イタリックにする

txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//テキストの色を変更

txtRange.Font.Color.RGB = 0x00CC3333;

//シェイプの背景色を変更

shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//水平方向に再配置する

shp.Left -= 70;

//出力をディスクに書き込む

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **サンプルコードをダウンロード**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772953)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Format.Text.using.VSTO.and.Aspose.Slides.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Format%20Text%20using%20VSTO%20and%20Aspose.Slides%20\(Aspose.Slides\).zip)