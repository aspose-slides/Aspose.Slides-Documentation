---
title: Format de Texte
type: docs
weight: 110
url: /fr/net/format-text/
---

Les méthodes VSTO et Aspose.Slides suivent les étapes suivantes :

- Ouvrir la présentation source.
- Accéder à la première diapositive.
- Accéder à la troisième zone de texte.
- Modifier le formatage du texte dans la troisième zone de texte.
- Enregistrer la présentation sur le disque.
## **VSTO**
``` csharp

 //Ouvrir la présentation

Presentation pres = new Presentation("source.ppt");

//Ajouter la police Verdana

FontEntity font = pres.Fonts[0];

FontEntity verdanaFont = new FontEntity(pres, font);

verdanaFont.FontName = "Verdana";

int verdanaFontIndex = pres.Fonts.Add(verdanaFont);

//Accéder à la première diapositive

Slide slide = pres.GetSlideByPosition(1);

//Accéder à la troisième forme

Shape shp = slide.Shapes[2];

//Modifier la police du texte en Verdana et la hauteur à 32

TextFrame tf = shp.TextFrame;

Paragraph para = tf.Paragraphs[0];

Portion port = para.Portions[0];

port.FontIndex = verdanaFontIndex;

port.FontHeight = 32;

//Mettre en gras

port.FontBold = true;

//Mettre en italique

port.FontItalic = true;

//Modifier la couleur du texte

port.FontColor = Color.FromArgb(0x33, 0x33, 0xCC);

//Modifier la couleur de fond de la forme

shp.FillFormat.Type = FillType.Solid;

shp.FillFormat.ForeColor = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Écrire la sortie sur le disque

pres.Write("outAspose.ppt");

``` 
## **Aspose.Slides**
``` csharp

 PowerPoint.Presentation pres = null;

//Ouvrir la présentation

pres = Globals.ThisAddIn.Application.Presentations.Open("source.ppt",

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoTrue);

//Accéder à la première diapositive

PowerPoint.Slide slide = pres.Slides[1];

//Accéder à la troisième forme

PowerPoint.Shape shp = slide.Shapes[3];

//Modifier la police du texte en Verdana et la hauteur à 32

PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

txtRange.Font.Name = "Verdana";

txtRange.Font.Size = 32;

//Mettre en gras

txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Mettre en italique

txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Modifier la couleur du texte

txtRange.Font.Color.RGB = 0x00CC3333;

//Modifier la couleur de fond de la forme

shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Repositionner horizontalement

shp.Left -= 70;

//Écrire la sortie sur le disque

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **Télécharger le Code Exemple**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772953)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Format.Text.using.VSTO.and.Aspose.Slides.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Format%20Text%20using%20VSTO%20and%20Aspose.Slides%20\(Aspose.Slides\).zip)