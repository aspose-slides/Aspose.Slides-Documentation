---
title: Szöveg formázása
type: docs
weight: 110
url: /hu/net/format-text/
---
Mind a VSTO, mind az Aspose.Slides módszerek a következő lépéseket hajtják végre:

- Nyissa meg a forrás prezentációt.
- Hozzáférés az első diához.
- Hozzáférés a harmadik szövegdobozhoz.
- Módosítsa a szöveg formázását a harmadik szövegdobozban.
- Mentse a prezentációt lemezre.
## **VSTO**
``` csharp

 //A prezentáció megnyitása
Presentation pres = new Presentation("source.ppt");

//Verdana betűtípus hozzáadása
FontEntity font = pres.Fonts[0];

FontEntity verdanaFont = new FontEntity(pres, font);

verdanaFont.FontName = "Verdana";

int verdanaFontIndex = pres.Fonts.Add(verdanaFont);

//Az első dia elérése
Slide slide = pres.GetSlideByPosition(1);

//A harmadik alakzat elérése
Shape shp = slide.Shapes[2];

//A szöveg betűtípusának módosítása Verdana-ra és a magasság 32-re
TextFrame tf = shp.TextFrame;

Paragraph para = tf.Paragraphs[0];

Portion port = para.Portions[0];

port.FontIndex = verdanaFontIndex;

port.FontHeight = 32;

//Félkövérre állítása
port.FontBold = true;

//Dőltre állítása
port.FontItalic = true;

//A szöveg színének módosítása
port.FontColor = Color.FromArgb(0x33, 0x33, 0xCC);

//Az alakzat háttérszínének módosítása
shp.FillFormat.Type = FillType.Solid;

shp.FillFormat.ForeColor = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Az eredmény írása lemezre
pres.Write("outAspose.ppt");

``` 
## **Aspose.Slides**
``` csharp

 PowerPoint.Presentation pres = null;

//A prezentáció megnyitása
pres = Globals.ThisAddIn.Application.Presentations.Open("source.ppt",

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoTrue);

//Az első dia elérése
PowerPoint.Slide slide = pres.Slides[1];

//A harmadik alakzat elérése
PowerPoint.Shape shp = slide.Shapes[3];

//A szöveg betűtípusának módosítása Verdana-ra és a magasság 32-re
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Font.Name = "Verdana";
txtRange.Font.Size = 32;

//Félkövérre állítása
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Dőltre állítása
txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//A szöveg színének módosítása
txtRange.Font.Color.RGB = 0x00CC3333;

//Az alakzat háttérszínének módosítása
shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Vízszintesen áthelyezése
shp.Left -= 70;

//Az eredmény írása lemezre
pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **Minta kód letöltése**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Format.Text.using.VSTO.and.Aspose.Slides.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides/)