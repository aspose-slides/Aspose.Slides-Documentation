---
title: 格式文字
type: docs
weight: 110
url: /zh-hant/net/format-text/
---
VSTO 與 Aspose.Slides 方法皆採取以下步驟：

- 開啟來源簡報。
- 取得第一張投影片。
- 取得第三個文字方塊。
- 變更第三個文字方塊內文字的格式。
- 將簡報儲存至磁碟。

## **VSTO**
``` csharp

 //開啟簡報

Presentation pres = new Presentation("source.ppt");

//新增 Verdana 字型

FontEntity font = pres.Fonts[0];

FontEntity verdanaFont = new FontEntity(pres, font);

verdanaFont.FontName = "Verdana";

int verdanaFontIndex = pres.Fonts.Add(verdanaFont);

//取得第一張投影片

Slide slide = pres.GetSlideByPosition(1);

//取得第三個形狀

Shape shp = slide.Shapes[2];

//將其文字字型改為 Verdana 並將字高設為 32

TextFrame tf = shp.TextFrame;

Paragraph para = tf.Paragraphs[0];

Portion port = para.Portions[0];

port.FontIndex = verdanaFontIndex;

port.FontHeight = 32;

//設為粗體

port.FontBold = true;

//設為斜體

port.FontItalic = true;

//更改文字顏色

port.FontColor = Color.FromArgb(0x33, 0x33, 0xCC);

//更改形狀背景顏色

shp.FillFormat.Type = FillType.Solid;

shp.FillFormat.ForeColor = Color.FromArgb(0xCC, 0xCC, 0xFF);

//將輸出寫入磁碟

pres.Write("outAspose.ppt");

``` 
## **Aspose.Slides**
``` csharp

 PowerPoint.Presentation pres = null;

//開啟簡報

pres = Globals.ThisAddIn.Application.Presentations.Open("source.ppt",

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoTrue);

//取得第一張投影片

PowerPoint.Slide slide = pres.Slides[1];

//取得第三個形狀

PowerPoint.Shape shp = slide.Shapes[3];

//將其文字字型改為 Verdana 並將字高設為 32

PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

txtRange.Font.Name = "Verdana";

txtRange.Font.Size = 32;

//設為粗體

txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//設為斜體

txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//更改文字顏色

txtRange.Font.Color.RGB = 0x00CC3333;

//更改形狀背景顏色

shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//水平重新定位

shp.Left -= 70;

//將輸出寫入磁碟

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **下載範例程式碼**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Format.Text.using.VSTO.and.Aspose.Slides.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides/)