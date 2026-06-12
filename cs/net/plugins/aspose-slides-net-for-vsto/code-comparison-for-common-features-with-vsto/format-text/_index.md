---
title: Formátování textu
type: docs
weight: 110
url: /cs/net/format-text/
---
Obě metody VSTO a Aspose.Slides provádějí následující kroky:

- Otevřete zdrojovou prezentaci.
- Přistupte k prvnímu snímku.
- Přistupte ke třetímu textovému rámečku.
- Změňte formátování textu ve třetím textovém rámečku.
- Uložte prezentaci na disk.
## **VSTO**
``` csharp

 //Otevřete prezentaci

Presentation pres = new Presentation("source.ppt");

//Přidejte písmo Verdana

FontEntity font = pres.Fonts[0];

FontEntity verdanaFont = new FontEntity(pres, font);

verdanaFont.FontName = "Verdana";

int verdanaFontIndex = pres.Fonts.Add(verdanaFont);

//Získejte první snímek

Slide slide = pres.GetSlideByPosition(1);

//Získejte třetí tvar

Shape shp = slide.Shapes[2];

//Změňte písmo textu na Verdana a výšku na 32

TextFrame tf = shp.TextFrame;

Paragraph para = tf.Paragraphs[0];

Portion port = para.Portions[0];

port.FontIndex = verdanaFontIndex;

port.FontHeight = 32;

//Ztučnit

port.FontBold = true;

//Kurzíva

port.FontItalic = true;

//Změňte barvu textu

port.FontColor = Color.FromArgb(0x33, 0x33, 0xCC);

//Změňte barvu pozadí tvaru

shp.FillFormat.Type = FillType.Solid;

shp.FillFormat.ForeColor = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Zapište výstup na disk

pres.Write("outAspose.ppt");

``` 
## **Aspose.Slides**
``` csharp

 PowerPoint.Presentation pres = null;

//Otevřete prezentaci

pres = Globals.ThisAddIn.Application.Presentations.Open("source.ppt",

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoTrue);

//Získejte první snímek

PowerPoint.Slide slide = pres.Slides[1];

//Získejte třetí tvar

PowerPoint.Shape shp = slide.Shapes[3];

//Změňte písmo jeho textu na Verdana a výšku na 32

PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

txtRange.Font.Name = "Verdana";

txtRange.Font.Size = 32;

//Ztučnit

txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Kurzíva

txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Změňte barvu textu

txtRange.Font.Color.RGB = 0x00CC3333;

//Změňte barvu pozadí tvaru

shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Přesuňte jej horizontálně

shp.Left -= 70;

//Zapište výstup na disk

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **Stáhnout ukázkový kód**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Format.Text.using.VSTO.and.Aspose.Slides.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides/)