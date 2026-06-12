---
title: Tekst opmaken met VSTO en Aspose.Slides voor .NET
linktitle: Tekst opmaken
type: docs
weight: 30
url: /nl/net/format-text-using-vsto-and-aspose-slides-and-net/
keywords:
- tekst opmaken
- migratie
- VSTO
- Office-automatisering
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Migreer van Microsoft Office-automatisering naar Aspose.Slides for .NET en formatteer tekst in PowerPoint (PPT, PPTX) presentaties met nauwkeurige controle."
---
{{% alert color="primary" %}} 

Soms moet je de tekst op dia's programmatisch opmaken. Dit artikel laat zien hoe je een voorbeeldpresentatie met tekst op de eerste dia kunt lezen met behulp van [VSTO](/slides/nl/net/format-text-using-vsto-and-aspose-slides-and-net/) en [Aspose.Slides for .NET](/slides/nl/net/format-text-using-vsto-and-aspose-slides-and-net/). De code formatteert de tekst in het derde tekstvak op de dia zodat deze eruitziet als de tekst in het laatste tekstvak.

{{% /alert %}} 
## **Tekst opmaken**
Zowel de VSTO- als de Aspose.Slides-methoden doorlopen de volgende stappen:

1. Open de bronpresentatie.
1. Open de eerste dia.
1. Open het derde tekstvak.
1. Wijzig de opmaak van de tekst in het derde tekstvak.
1. Sla de presentatie op schijf.

De onderstaande schermafbeeldingen tonen de voorbeelddia vóór en na de uitvoering van de VSTO- en Aspose.Slides for .NET-code.

**De invoerpresentatie** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **VSTO-code voorbeeld**
De onderstaande code toont hoe je tekst op een dia kunt herformatteren met VSTO.

**De tekst die met VSTO herformatteerd is** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)



```c#
//Opmerking: PowerPoint is een namespace die hierboven als volgt is gedefinieerd
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
PowerPoint.Presentation pres = null;

//Open de presentatie
pres = Globals.ThisAddIn.Application.Presentations.Open("c:\\source.ppt",
    Microsoft.Office.Core.MsoTriState.msoFalse,
    Microsoft.Office.Core.MsoTriState.msoFalse,
    Microsoft.Office.Core.MsoTriState.msoTrue);

//Open de eerste dia
PowerPoint.Slide slide = pres.Slides[1];

//Open de derde vorm
PowerPoint.Shape shp = slide.Shapes[3];

//Verander het lettertype van de tekst naar Verdana en de grootte naar 32
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
pres.SaveAs("c:\\outVSTO.ppt",
    PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
    Microsoft.Office.Core.MsoTriState.msoFalse);
```




### **Aspose.Slides for .NET-voorbeeld**
Om tekst te formatteren met Aspose.Slides, voeg je eerst het lettertype toe voordat je de tekst opmaakt.

**De uitvoerpresentatie gemaakt met Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)



```c#
 //Open de presentatie
Presentation pres = new Presentation("c:\\source.ppt");

//Open de eerste dia
ISlide slide = pres.Slides[0];

//Open de derde vorm
IShape shp = slide.Shapes[2];

//Verander het lettertype van de tekst naar Verdana en de hoogte naar 32
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//Maak het vet
port.PortionFormat.FontBold = NullableBool.True;

//Maak het cursief
port.PortionFormat.FontItalic = NullableBool.True;

//Verander tekstkleur
//Stel letterkleur in
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//Verander de achtergrondkleur van de vorm
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Schrijf de uitvoer naar schijf
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```