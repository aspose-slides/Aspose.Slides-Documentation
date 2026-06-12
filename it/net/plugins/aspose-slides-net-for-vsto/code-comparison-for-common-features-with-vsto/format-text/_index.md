---
title: Formattare il Testo
type: docs
weight: 110
url: /it/net/format-text/
---
Entrambi i metodi VSTO e Aspose.Slides eseguono i seguenti passaggi:

- Apri la presentazione di origine.
- Accedi alla prima diapositiva.
- Accedi alla terza casella di testo.
- Modifica la formattazione del testo nella terza casella di testo.
- Salva la presentazione su disco.
## **VSTO**
``` csharp

 //Apri la presentazione

Presentation pres = new Presentation("source.ppt");

//Aggiungi il font Verdana

FontEntity font = pres.Fonts[0];

FontEntity verdanaFont = new FontEntity(pres, font);

verdanaFont.FontName = "Verdana";

int verdanaFontIndex = pres.Fonts.Add(verdanaFont);

//Accedi alla prima diapositiva

Slide slide = pres.GetSlideByPosition(1);

//Accedi alla terza forma

Shape shp = slide.Shapes[2];

//Cambia il font del testo in Verdana e l'altezza a 32

TextFrame tf = shp.TextFrame;

Paragraph para = tf.Paragraphs[0];

Portion port = para.Portions[0];

port.FontIndex = verdanaFontIndex;

port.FontHeight = 32;

//Rendilo grassetto

port.FontBold = true;

//Rendilo corsivo

port.FontItalic = true;

//Cambia il colore del testo

port.FontColor = Color.FromArgb(0x33, 0x33, 0xCC);

//Cambia il colore di sfondo della forma

shp.FillFormat.Type = FillType.Solid;

shp.FillFormat.ForeColor = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Scrivi l'output su disco

pres.Write("outAspose.ppt");

``` 
## **Aspose.Slides**
``` csharp

 PowerPoint.Presentation pres = null;

//Apri la presentazione

pres = Globals.ThisAddIn.Application.Presentations.Open("source.ppt",

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoTrue);

//Accedi alla prima diapositiva

PowerPoint.Slide slide = pres.Slides[1];

//Accedi alla terza forma

PowerPoint.Shape shp = slide.Shapes[3];

//Cambia il font del testo in Verdana e l'altezza a 32

PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

txtRange.Font.Name = "Verdana";

txtRange.Font.Size = 32;

//Rendilo grassetto

txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Rendilo corsivo

txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Cambia il colore del testo

txtRange.Font.Color.RGB = 0x00CC3333;

//Cambia il colore di sfondo della forma

shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Riposizionalo orizzontalmente

shp.Left -= 70;

//Scrivi l'output su disco

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **Scarica il Codice di Esempio**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Format.Text.using.VSTO.and.Aspose.Slides.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides/)