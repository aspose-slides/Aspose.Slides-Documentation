---
title: Formatera text med VSTO och Aspose.Slides för .NET
linktitle: Formatera text
type: docs
weight: 30
url: /sv/net/format-text-using-vsto-and-aspose-slides-and-net/
keywords:
- formatera text
- migration
- VSTO
- Office-automatisering
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Migrera från Microsoft Office-automatisering till Aspose.Slides för .NET och formatera text i PowerPoint (PPT, PPTX) presentationer med exakt kontroll."
---
{{% alert color="info" %}}

Ibland behöver du formatera texten på bildspel programatiskt. Denna artikel visar hur du läser en exempelpresentation med lite text på den första bilden med antingen [VSTO](/slides/sv/net/format-text-using-vsto-and-aspose-slides-and-net/) och [Aspose.Slides for .NET](/slides/sv/net/format-text-using-vsto-and-aspose-slides-and-net/). Koden formaterar texten i den tredje textrutan på bilden så att den ser ut som texten i den sista textrutan.

{{% /alert %}} 
## **Formatera text**
Båda VSTO- och Aspose.Slides-metoderna följer följande steg:

1. Öppna källpresentationen.
1. Hämta den första bilden.
1. Hämta den tredje textrutan.
1. Ändra formateringen av texten i den tredje textrutan.
1. Spara presentationen till disk.

Skärmdumparna nedan visar exempelbilden före och efter körning av VSTO- och Aspose.Slides for .NET-koden.

**Ingångspresentationen** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **VSTO kodexempel**
Koden nedan visar hur du omformaterar text på en bild med VSTO.

**Texten omformaterad med VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)



```c#
//Obs: PowerPoint är en namnrymd som har definierats ovan så här
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
PowerPoint.Presentation pres = null;

//Öppna presentationen
pres = Globals.ThisAddIn.Application.Presentations.Open("c:\\source.ppt",
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoTrue);

//Hämta den första bilden
PowerPoint.Slide slide = pres.Slides[1];

//Hämta den tredje formen
PowerPoint.Shape shp = slide.Shapes[3];

//Ändra textens teckensnitt till Verdana och storlek till 32
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

//Placera om den horisontellt
shp.Left -= 70;

//Skriv utdata till disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```




### **Aspose.Slides for .NET-exempel**
För att formatera text med Aspose.Slides, lägg till teckensnittet innan du formaterar texten.

**Utgångspresentationen skapad med Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)



```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

 //Öppna presentationen
Presentation pres = new Presentation("source.ppt");

//Hämta den första bilden
ISlide slide = pres.Slides[0];

//Hämta den tredje formen
IShape shp = slide.Shapes[2];

//Ändra textens teckensnitt till Verdana och höjd till 32
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//Gör den fet
port.PortionFormat.FontBold = NullableBool.True;

//Gör den kursiv
port.PortionFormat.FontItalic = NullableBool.True;

//Ändra textfärg
//Sätt teckenfärg
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//Ändra formens bakgrundsfärg
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Skriv utdata till disk
pres.Save("outAspose.ppt", SaveFormat.Ppt);
```