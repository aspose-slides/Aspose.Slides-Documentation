---
title: Formatowanie tekstu
type: docs
weight: 110
url: /pl/net/format-text/
---
Zarówno metody VSTO, jak i Aspose.Slides wykonują następujące kroki:

- Otwórz prezentację źródłową.
- Uzyskaj dostęp do pierwszego slajdu.
- Uzyskaj dostęp do trzeciego pola tekstowego.
- Zmień formatowanie tekstu w trzecim polu tekstowym.
- Zapisz prezentację na dysku.

## **VSTO**
``` csharp

 //Otwórz prezentację

Presentation pres = new Presentation("source.ppt");

//Dodaj czcionkę Verdana

FontEntity font = pres.Fonts[0];

FontEntity verdanaFont = new FontEntity(pres, font);

verdanaFont.FontName = "Verdana";

int verdanaFontIndex = pres.Fonts.Add(verdanaFont);

//Uzyskaj dostęp do pierwszego slajdu

Slide slide = pres.GetSlideByPosition(1);

//Uzyskaj dostęp do trzeciego kształtu

Shape shp = slide.Shapes[2];

//Zmień czcionkę tekstu na Verdana i wysokość na 32

TextFrame tf = shp.TextFrame;

Paragraph para = tf.Paragraphs[0];

Portion port = para.Portions[0];

port.FontIndex = verdanaFontIndex;

port.FontHeight = 32;

//Pogrub go

port.FontBold = true;

//Ustaw kursywę

port.FontItalic = true;

//Zmień kolor tekstu

port.FontColor = Color.FromArgb(0x33, 0x33, 0xCC);

//Zmień kolor tła kształtu

shp.FillFormat.Type = FillType.Solid;

shp.FillFormat.ForeColor = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Zapisz wynik na dysku

pres.Write("outAspose.ppt");

``` 

## **Aspose.Slides**
``` csharp

 PowerPoint.Presentation pres = null;

//Otwórz prezentację

pres = Globals.ThisAddIn.Application.Presentations.Open("source.ppt",

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoTrue);

//Uzyskaj dostęp do pierwszego slajdu

PowerPoint.Slide slide = pres.Slides[1];

//Uzyskaj dostęp do trzeciego kształtu

PowerPoint.Shape shp = slide.Shapes[3];

//Zmień czcionkę tekstu na Verdana i wysokość na 32

PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

txtRange.Font.Name = "Verdana";

txtRange.Font.Size = 32;

//Pogrub go

txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Ustaw kursywę

txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Zmień kolor tekstu

txtRange.Font.Color.RGB = 0x00CC3333;

//Zmień kolor tła kształtu

shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Przesuń go w poziomie

shp.Left -= 70;

//Zapisz wynik na dysku

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

``` 

## **Pobierz przykładowy kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Format.Text.using.VSTO.and.Aspose.Slides.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides/)