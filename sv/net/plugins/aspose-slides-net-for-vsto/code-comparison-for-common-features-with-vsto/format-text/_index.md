---
title: Formatera text
type: docs
weight: 110
url: /sv/net/format-text/
---
Både VSTO‑ och Aspose.Slides‑metoderna följer följande steg:

- Öppna källpresentationen.
- Gå till den första bilden.
- Gå till den tredje textrutan.
- Ändra formateringen av texten i den tredje textrutan.
- Spara presentationen till disk.
## **VSTO**
```csharp

 //Öppna presentationen
Presentation pres = new Presentation("source.ppt");

//Lägg till Verdana-typsnitt
FontEntity font = pres.Fonts[0];

FontEntity verdanaFont = new FontEntity(pres, font);

verdanaFont.FontName = "Verdana";

int verdanaFontIndex = pres.Fonts.Add(verdanaFont);

//Åtkomst till den första bilden
Slide slide = pres.GetSlideByPosition(1);

//Åtkomst till den tredje formen
Shape shp = slide.Shapes[2];

//Ändra dess texts typsnitt till Verdana och höjd till 32
TextFrame tf = shp.TextFrame;

Paragraph para = tf.Paragraphs[0];

Portion port = para.Portions[0];

port.FontIndex = verdanaFontIndex;

port.FontHeight = 32;

//Gör den fet
port.FontBold = true;

//Gör den kursiv
port.FontItalic = true;

//Ändra textfärg
port.FontColor = Color.FromArgb(0x33, 0x33, 0xCC);

//Ändra formens bakgrundsfärg
shp.FillFormat.Type = FillType.Solid;

shp.FillFormat.ForeColor = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Skriv utdata till disk
pres.Write("outAspose.ppt");
``` 
## **Aspose.Slides**
```csharp

 PowerPoint.Presentation pres = null;

//Öppna presentationen
pres = Globals.ThisAddIn.Application.Presentations.Open("source.ppt",

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoTrue);

//Gå till den första bilden
PowerPoint.Slide slide = pres.Slides[1];

//Gå till den tredje formen
PowerPoint.Shape shp = slide.Shapes[3];

//Ändra dess texts typsnitt till Verdana och höjd till 32
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

txtRange.Font.Name = "Verdana";

txtRange.Font.Size = 32;

//Gör den fet
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Gör den kursiv
txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Ändra textfärg
txtRange.Font.Color.RGB = 0x00CC3333;

//Ändra formens bakgrundsfärg
shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Flytta den horisontellt
shp.Left -= 70;

//Skriv utdata till disk
pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);
``` 
## **Ladda ner exempel på kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Format.Text.using.VSTO.and.Aspose.Slides.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides/)