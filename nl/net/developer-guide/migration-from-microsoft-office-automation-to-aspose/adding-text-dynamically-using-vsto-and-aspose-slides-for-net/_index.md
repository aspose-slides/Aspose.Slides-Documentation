---
title: Tekst Dynamisch Toevoegen met VSTO en Aspose.Slides voor .NET
linktitle: Tekst Dynamisch Toevoegen
type: docs
weight: 20
url: /nl/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
keywords:
- tekst toevoegen
- migratie
- VSTO
- Office-automatisering
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Bekijk hoe u kunt migreren van Microsoft Office-automatisering naar Aspose.Slides voor .NET en dynamische tekst kunt toevoegen aan PowerPoint (PPT, PPTX) presentaties in C#."
---
{{% alert color="primary" %}} 
Een veelvoorkomende taak die ontwikkelaars moeten uitvoeren, is tekst dynamisch aan dia's toevoegen. Dit artikel toont code‑voorbeelden voor het dynamisch toevoegen van tekst met behulp van [VSTO](/slides/nl/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) en [Aspose.Slides for .NET](/slides/nl/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/).
{{% /alert %}} 
## **Tekst dynamisch toevoegen**
Beide methoden volgen de volgende stappen:

1. Maak een presentatie.
1. Voeg een lege dia toe.
1. Voeg een tekstvak toe.
1. Stel wat tekst in.
1. Sla de presentatie op.
## **VSTO‑codevoorbeeld**
De code‑fragmenten hieronder resulteren in een presentatie met een eenvoudige dia en een stuk tekst erop.

**De presentatie zoals gemaakt in VSTO** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)

```c#
//Opmerking: PowerPoint is een namespace die hierboven als volgt is gedefinieerd
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Maak een presentatie
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Haal de lege dia‑indeling op
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//Voeg een lege dia toe
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//Voeg tekst toe
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//Stel tekst in
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Text added dynamically";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//Schrijf de uitvoer naar schijf
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```



## **Aspose.Slides voor .NET‑voorbeeld**
De code‑fragmenten hieronder gebruiken Aspose.Slides om een presentatie te maken met een eenvoudige dia en een stuk tekst erop.

**De presentatie zoals gemaakt met Aspose.Slides voor .NET** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)

```c#
//Maak een presentatie
Presentation pres = new Presentation();

//Lege dia wordt standaard toegevoegd, wanneer je maakt
//presentatie vanuit de standaardconstructor
//Dus we hoeven geen lege dia toe te voegen
ISlide sld = pres.Slides[1];

//Voeg een tekstvak toe
//Om het toe te voegen, voegen we eerst een rechthoek toe
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//Hide its line
shp.LineFormat.Style = LineStyle.NotDefined;

//Then add a textframe inside it
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//Set a text
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//Write the output to disk
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```