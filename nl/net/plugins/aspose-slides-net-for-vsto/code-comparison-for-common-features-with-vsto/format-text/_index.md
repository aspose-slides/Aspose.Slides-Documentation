---
title: Tekst opmaken
type: docs
weight: 110
url: /nl/net/format-text/
---
Zowel de VSTO- als de Aspose.Slides-methoden doorlopen de volgende stappen:

- Open de bronpresentatie.
- Ga naar de eerste dia.
- Ga naar het derde tekstvak.
- Wijzig de opmaak van de tekst in het derde tekstvak.
- Sla de presentatie op schijf.
## **VSTO**
``` csharp

 //Open de presentatie

Presentation pres = new Presentation("source.ppt");

//Voeg Verdana-lettertype toe

FontEntity font = pres.Fonts[0];

FontEntity verdanaFont = new FontEntity(pres, font);

verdanaFont.FontName = "Verdana";

int verdanaFontIndex = pres.Fonts.Add(verdanaFont);

//Open de eerste dia

Slide slide = pres.GetSlideByPosition(1);

//Open de derde vorm

Shape shp = slide.Shapes[2];

//Verander het lettertype van de tekst naar Verdana en de hoogte naar 32

TextFrame tf = shp.TextFrame;

Paragraph para = tf.Paragraphs[0];

Portion port = para.Portions[0];

port.FontIndex = verdanaFontIndex;

port.FontHeight = 32;

//Maak het vet

port.FontBold = true;

//Maak het cursief

port.FontItalic = true;

//Verander tekstkleur

port.FontColor = Color.FromArgb(0x33, 0x33, 0xCC);

//Verander de achtergrondkleur van de vorm

shp.FillFormat.Type = FillType.Solid;

shp.FillFormat.ForeColor = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Schrijf de uitvoer naar schijf

pres.Write("outAspose.ppt");

``` 
## **Aspose.Slides**
``` csharp

 PowerPoint.Presentation pres = null;

//Open de presentatie

pres = Globals.ThisAddIn.Application.Presentations.Open("source.ppt",

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoTrue);

//Open de eerste dia

PowerPoint.Slide slide = pres.Slides[1];

//Open de derde vorm

PowerPoint.Shape shp = slide.Shapes[3];

//Verander het lettertype van de tekst naar Verdana en de hoogte naar 32

PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

txtRange.Font.Name = "Verdana";

txtRange.Font.Size = 32;

//Maak het vet

txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Maak het cursief

txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Verander de tekstkleur

txtRange.Font.Color.RGB = 0x00CC3333;

//Verander de achtergrondkleur van de vorm

shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Verplaats het horizontaal

shp.Left -= 70;

//Schrijf de uitvoer naar schijf

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **Voorbeeldcode downloaden**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Format.Text.using.VSTO.and.Aspose.Slides.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides/)