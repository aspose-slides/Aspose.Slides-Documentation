---
title: قالب‌بندی متن
type: docs
weight: 110
url: /fa/net/format-text/
---
هر دو روش VSTO و Aspose.Slides مراحل زیر را انجام می‌دهند:

- ارائهٔ منبع را باز کنید.
- به اولین اسلاید دسترسی پیدا کنید.
- به جعبهٔ متن سوم دسترسی پیدا کنید.
- قالب‌بندی متن در جعبهٔ متن سوم را تغییر دهید.
- ارائه را روی دیسک ذخیره کنید.
## **VSTO**
``` csharp

 //باز کردن ارائه

Presentation pres = new Presentation("source.ppt");

//افزودن فونت Verdana

FontEntity font = pres.Fonts[0];

FontEntity verdanaFont = new FontEntity(pres, font);

verdanaFont.FontName = "Verdana";

int verdanaFontIndex = pres.Fonts.Add(verdanaFont);

//دسترسی به اولین اسلاید

Slide slide = pres.GetSlideByPosition(1);

//دسترسی به شکل سوم

Shape shp = slide.Shapes[2];

//تغییر فونت متن به Verdana و ارتفاع به 32

TextFrame tf = shp.TextFrame;

Paragraph para = tf.Paragraphs[0];

Portion port = para.Portions[0];

port.FontIndex = verdanaFontIndex;

port.FontHeight = 32;

//درشت کردن آن

port.FontBold = true;

//کج کردن آن

port.FontItalic = true;

//تغییر رنگ متن

port.FontColor = Color.FromArgb(0x33, 0x33, 0xCC);

//تغییر رنگ پس‌زمینه شکل

shp.FillFormat.Type = FillType.Solid;

shp.FillFormat.ForeColor = Color.FromArgb(0xCC, 0xCC, 0xFF);

//نوشتن خروجی به دیسک

pres.Write("outAspose.ppt");

``` 
## **Aspose.Slides**
``` csharp

 PowerPoint.Presentation pres = null;

//باز کردن ارائه

pres = Globals.ThisAddIn.Application.Presentations.Open("source.ppt",

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoTrue);

//دسترسی به اولین اسلاید

PowerPoint.Slide slide = pres.Slides[1];

//دسترسی به شکل سوم

PowerPoint.Shape shp = slide.Shapes[3];

//تغییر فونت متن به Verdana و ارتفاع به 32

PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

txtRange.Font.Name = "Verdana";

txtRange.Font.Size = 32;

//درشت کردن آن

txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//کج کردن آن

txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//تغییر رنگ متن

txtRange.Font.Color.RGB = 0x00CC3333;

//تغییر رنگ پس‌زمینه شکل

shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//جابجایی افقی آن

shp.Left -= 70;

//نوشتن خروجی به دیسک

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **بارگیری نمونه کد**
- [گیت‌هاب](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Format.Text.using.VSTO.and.Aspose.Slides.Aspose.Slides.zip)
- [سورسفورج](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides%20%28Aspose.Slides%29.zip/download)
- [بیت‌باکت](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides/)