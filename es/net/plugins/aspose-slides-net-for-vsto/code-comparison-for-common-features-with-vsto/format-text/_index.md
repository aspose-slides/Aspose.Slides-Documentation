---
title: Formatear Texto
type: docs
weight: 110
url: /net/format-text/
---

Ambos métodos de VSTO y Aspose.Slides realizan los siguientes pasos:

- Abrir la presentación de origen.
- Acceder a la primera diapositiva.
- Acceder a la tercera caja de texto.
- Cambiar el formato del texto en la tercera caja de texto.
- Guardar la presentación en el disco.
## **VSTO**
``` csharp

 //Abrir la presentación

Presentation pres = new Presentation("source.ppt");

//Agregar la fuente Verdana

FontEntity font = pres.Fonts[0];

FontEntity verdanaFont = new FontEntity(pres, font);

verdanaFont.FontName = "Verdana";

int verdanaFontIndex = pres.Fonts.Add(verdanaFont);

//Acceder a la primera diapositiva

Slide slide = pres.GetSlideByPosition(1);

//Acceder a la tercera forma

Shape shp = slide.Shapes[2];

//Cambiar la fuente del texto a Verdana y altura a 32

TextFrame tf = shp.TextFrame;

Paragraph para = tf.Paragraphs[0];

Portion port = para.Portions[0];

port.FontIndex = verdanaFontIndex;

port.FontHeight = 32;

//Ponerlo en negrita

port.FontBold = true;

//Ponerlo en cursiva

port.FontItalic = true;

//Cambiar el color del texto

port.FontColor = Color.FromArgb(0x33, 0x33, 0xCC);

//Cambiar el color de fondo de la forma

shp.FillFormat.Type = FillType.Solid;

shp.FillFormat.ForeColor = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Guardar la salida en el disco

pres.Write("outAspose.ppt");

``` 
## **Aspose.Slides**
``` csharp

 PowerPoint.Presentation pres = null;

//Abrir la presentación

pres = Globals.ThisAddIn.Application.Presentations.Open("source.ppt",

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoTrue);

//Acceder a la primera diapositiva

PowerPoint.Slide slide = pres.Slides[1];

//Acceder a la tercera forma

PowerPoint.Shape shp = slide.Shapes[3];

//Cambiar la fuente del texto a Verdana y altura a 32

PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

txtRange.Font.Name = "Verdana";

txtRange.Font.Size = 32;

//Ponerlo en negrita

txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Ponerlo en cursiva

txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Cambiar el color del texto

txtRange.Font.Color.RGB = 0x00CC3333;

//Cambiar el color de fondo de la forma

shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Reubicarlo horizontalmente

shp.Left -= 70;

//Guardar la salida en el disco

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **Descargar Código de Ejemplo**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772953)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Format.Text.using.VSTO.and.Aspose.Slides.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Format%20Text%20using%20VSTO%20and%20Aspose.Slides%20\(Aspose.Slides\).zip)