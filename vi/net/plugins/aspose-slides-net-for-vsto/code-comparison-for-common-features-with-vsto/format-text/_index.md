---
title: Định dạng Văn bản
type: docs
weight: 110
url: /vi/net/format-text/
---
Cả hai phương pháp VSTO và Aspose.Slides thực hiện các bước sau:

- Mở bản trình chiếu nguồn.
- Truy cập slide đầu tiên.
- Truy cập hộp văn bản thứ ba.
- Thay đổi định dạng của văn bản trong hộp văn bản thứ ba.
- Lưu bản trình chiếu vào đĩa.
## **VSTO**
``` csharp

 //Mở bản trình chiếu

Presentation pres = new Presentation("source.ppt");

//Thêm phông chữ Verdana

FontEntity font = pres.Fonts[0];

FontEntity verdanaFont = new FontEntity(pres, font);

verdanaFont.FontName = "Verdana";

int verdanaFontIndex = pres.Fonts.Add(verdanaFont);

//Truy cập slide đầu tiên

Slide slide = pres.GetSlideByPosition(1);

//Truy cập hình thứ ba

Shape shp = slide.Shapes[2];

//Thay đổi phông chữ của văn bản thành Verdana và kích thước thành 32

TextFrame tf = shp.TextFrame;

Paragraph para = tf.Paragraphs[0];

Portion port = para.Portions[0];

port.FontIndex = verdanaFontIndex;

port.FontHeight = 32;

//Đặt chữ in đậm

port.FontBold = true;

//Đặt chữ in nghiêng

port.FontItalic = true;

//Thay đổi màu văn bản

port.FontColor = Color.FromArgb(0x33, 0x33, 0xCC);

//Thay đổi màu nền của hình

shp.FillFormat.Type = FillType.Solid;

shp.FillFormat.ForeColor = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Ghi đầu ra vào đĩa

pres.Write("outAspose.ppt");

```
## **Aspose.Slides**
``` csharp

 PowerPoint.Presentation pres = null;

//Mở bản trình chiếu

pres = Globals.ThisAddIn.Application.Presentations.Open("source.ppt",

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoTrue);

//Truy cập slide đầu tiên

PowerPoint.Slide slide = pres.Slides[1];

//Truy cập hình dạng thứ ba

PowerPoint.Shape shp = slide.Shapes[3];

//Thay đổi phông chữ của văn bản thành Verdana và độ cao thành 32

PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

txtRange.Font.Name = "Verdana";

txtRange.Font.Size = 32;

//Đặt chữ in đậm

txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Đặt chữ in nghiêng

txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Thay đổi màu văn bản

txtRange.Font.Color.RGB = 0x00CC3333;

//Thay đổi màu nền của hình dạng

shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Di chuyển nó theo chiều ngang

shp.Left -= 70;

//Ghi kết quả ra đĩa

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

```
## **Tải Mã Mẫu**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Format.Text.using.VSTO.and.Aspose.Slides.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides/)