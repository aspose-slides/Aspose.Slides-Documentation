---
title: تنسيق النص
type: docs
weight: 110
url: /ar/net/format-text/
---

تتبع طرق VSTO و Aspose.Slides الخطوات التالية:

- فتح العرض التقديمي المصدر.
- الوصول إلى الشريحة الأولى.
- الوصول إلى مربع النص الثالث.
- تغيير تنسيق النص في مربع النص الثالث.
- حفظ العرض التقديمي على القرص.
## **VSTO**
``` csharp

 //فتح العرض التقديمي

Presentation pres = new Presentation("source.ppt");

//إضافة خط فيردانا

FontEntity font = pres.Fonts[0];

FontEntity verdanaFont = new FontEntity(pres, font);

verdanaFont.FontName = "Verdana";

int verdanaFontIndex = pres.Fonts.Add(verdanaFont);

//الوصول إلى الشريحة الأولى

Slide slide = pres.GetSlideByPosition(1);

//الوصول إلى الشكل الثالث

Shape shp = slide.Shapes[2];

//تغيير خط النص إلى فيردانا وارتفاعه إلى 32

TextFrame tf = shp.TextFrame;

Paragraph para = tf.Paragraphs[0];

Portion port = para.Portions[0];

port.FontIndex = verdanaFontIndex;

port.FontHeight = 32;

//جعله عريضًا

port.FontBold = true;

//جعله مائلًا

port.FontItalic = true;

//تغيير لون النص

port.FontColor = Color.FromArgb(0x33, 0x33, 0xCC);

//تغيير لون خلفية الشكل

shp.FillFormat.Type = FillType.Solid;

shp.FillFormat.ForeColor = Color.FromArgb(0xCC, 0xCC, 0xFF);

//كتابة الناتج إلى القرص

pres.Write("outAspose.ppt");

``` 
## **Aspose.Slides**
``` csharp

 PowerPoint.Presentation pres = null;

//فتح العرض التقديمي

pres = Globals.ThisAddIn.Application.Presentations.Open("source.ppt",

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoTrue);

//الوصول إلى الشريحة الأولى

PowerPoint.Slide slide = pres.Slides[1];

//الوصول إلى الشكل الثالث

PowerPoint.Shape shp = slide.Shapes[3];

//تغيير خط النص إلى فيردانا وارتفاعه إلى 32

PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

txtRange.Font.Name = "Verdana";

txtRange.Font.Size = 32;

//جعله عريضًا

txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//جعله مائلًا

txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//تغيير لون النص

txtRange.Font.Color.RGB = 0x00CC3333;

//تغيير لون خلفية الشكل

shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//إعادة وضعه أفقيًا

shp.Left -= 70;

//كتابة الناتج إلى القرص

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **تنزيل كود المثال**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772953)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Format.Text.using.VSTO.and.Aspose.Slides.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Format%20Text%20using%20VSTO%20and%20Aspose.Slides%20\(Aspose.Slides\).zip)