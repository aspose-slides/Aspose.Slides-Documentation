---
title: टेक्स्ट फ़ॉर्मेट
type: docs
weight: 110
url: /hi/net/format-text/
---
VSTO और Aspose.Slides दोनों विधियाँ निम्नलिखित चरणों को अपनाती हैं:

- स्रोत प्रस्तुति खोलें।
- पहली स्लाइड तक पहुँचें।
- तीसरे टेक्स्ट बॉक्स तक पहुँचें।
- तीसरे टेक्स्ट बॉक्स के टेक्स्ट का फॉर्मेट बदलें।
- प्रस्तुति को डिस्क पर सहेजें।
## **VSTO**
``` csharp

 //प्रस्तुति खोलें
Presentation pres = new Presentation("source.ppt");

//Verdana फ़ॉन्ट जोड़ें
FontEntity font = pres.Fonts[0];

FontEntity verdanaFont = new FontEntity(pres, font);

verdanaFont.FontName = "Verdana";

int verdanaFontIndex = pres.Fonts.Add(verdanaFont);

//पहली स्लाइड तक पहुँचें
Slide slide = pres.GetSlideByPosition(1);

//तीसरे आकार तक पहुँचें
Shape shp = slide.Shapes[2];

//उसके टेक्स्ट का फ़ॉन्ट Verdana और आकार 32 सेट करें
TextFrame tf = shp.TextFrame;

Paragraph para = tf.Paragraphs[0];

Portion port = para.Portions[0];

port.FontIndex = verdanaFontIndex;

port.FontHeight = 32;

//बोल्ड बनाएं
port.FontBold = true;

//इटैलिक बनाएं
port.FontItalic = true;

//टेक्स्ट का रंग बदलें
port.FontColor = Color.FromArgb(0x33, 0x33, 0xCC);

//शेप की पृष्ठभूमि रंग बदलें
shp.FillFormat.Type = FillType.Solid;

shp.FillFormat.ForeColor = Color.FromArgb(0xCC, 0xCC, 0xFF);

//आउटपुट को डिस्क पर लिखें
pres.Write("outAspose.ppt");

``` 
## **Aspose.Slides**
``` csharp

//प्रस्तुति खोलें
pres = Globals.ThisAddIn.Application.Presentations.Open("source.ppt",
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoTrue);
//पहली स्लाइड तक पहुँचें
PowerPoint.Slide slide = pres.Slides[1];
//तीसरे आकार तक पहुँचें
PowerPoint.Shape shp = slide.Shapes[3];
//उसके टेक्स्ट का फ़ॉन्ट Verdana और आकार 32 सेट करें
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Font.Name = "Verdana";
txtRange.Font.Size = 32;
//बोल्ड बनाएं
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;
//इटैलिक बनाएं
txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;
//टेक्स्ट का रंग बदलें
txtRange.Font.Color.RGB = 0x00CC3333;
//आकार की पृष्ठभूमि रंग बदलें
shp.Fill.ForeColor.RGB = 0x00FFCCCC;
//को क्षैतिज रूप से पुनः स्थित करें
shp.Left -= 70;
//आउटपुट को डिस्क पर लिखें
pres.SaveAs("outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
``` 
## **नमूना कोड डाउनलोड करें**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Format.Text.using.VSTO.and.Aspose.Slides.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides/)