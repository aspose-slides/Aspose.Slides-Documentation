---
title: Text formatieren
type: docs
weight: 110
url: /net/format-text/
---

Sowohl die VSTO- als auch die Aspose.Slides-Methoden führen die folgenden Schritte aus:

- Öffnen der Quellpräsentation.
- Zugriff auf die erste Folie.
- Zugriff auf das dritte Textfeld.
- Ändern der Formatierung des Textes im dritten Textfeld.
- Speichern der Präsentation auf der Festplatte.
## **VSTO**
``` csharp

 //Präsentation öffnen

Presentation pres = new Presentation("source.ppt");

//Verdana-Schriftart hinzufügen

FontEntity font = pres.Fonts[0];

FontEntity verdanaFont = new FontEntity(pres, font);

verdanaFont.FontName = "Verdana";

int verdanaFontIndex = pres.Fonts.Add(verdanaFont);

//Zugriff auf die erste Folie

Slide slide = pres.GetSlideByPosition(1);

//Zugriff auf die dritte Form

Shape shp = slide.Shapes[2];

//Ändern der Schriftart des Textes in Verdana und Höhe auf 32

TextFrame tf = shp.TextFrame;

Paragraph para = tf.Paragraphs[0];

Portion port = para.Portions[0];

port.FontIndex = verdanaFontIndex;

port.FontHeight = 32;

//Fett formatieren

port.FontBold = true;

//Kursiv formatieren

port.FontItalic = true;

//Textfarbe ändern

port.FontColor = Color.FromArgb(0x33, 0x33, 0xCC);

//Hintergrundfarbe der Form ändern

shp.FillFormat.Type = FillType.Solid;

shp.FillFormat.ForeColor = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Ausgabe auf die Festplatte schreiben

pres.Write("outAspose.ppt");

``` 
## **Aspose.Slides**
``` csharp

 PowerPoint.Presentation pres = null;

//Präsentation öffnen

pres = Globals.ThisAddIn.Application.Presentations.Open("source.ppt",

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoTrue);

//Zugriff auf die erste Folie

PowerPoint.Slide slide = pres.Slides[1];

//Zugriff auf die dritte Form

PowerPoint.Shape shp = slide.Shapes[3];

//Ändern der Schriftart des Textes in Verdana und Höhe auf 32

PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

txtRange.Font.Name = "Verdana";

txtRange.Font.Size = 32;

//Fett formatieren

txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Kursiv formatieren

txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Textfarbe ändern

txtRange.Font.Color.RGB = 0x00CC3333;

//Hintergrundfarbe der Form ändern

shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Horizontal verschieben

shp.Left -= 70;

//Ausgabe auf die Festplatte schreiben

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **Beispielcode herunterladen**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772953)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Format.Text.using.VSTO.and.Aspose.Slides.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Format%20Text%20using%20VSTO%20and%20Aspose.Slides%20\(Aspose.Slides\).zip)