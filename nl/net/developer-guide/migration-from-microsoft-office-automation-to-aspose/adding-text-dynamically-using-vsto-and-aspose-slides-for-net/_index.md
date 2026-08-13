---
title: Tekst dynamisch toevoegen met VSTO en Aspose.Slides voor .NET
linktitle: Tekst dynamisch toevoegen
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
description: "Zie hoe u van Microsoft Office-automatisering naar Aspose.Slides voor .NET kunt migreren en dynamische tekst kunt toevoegen aan PowerPoint‑presentaties (PPT, PPTX) in C#."
---
{{% alert color="info" %}} 

Een veelvoorkomende taak die ontwikkelaars moeten uitvoeren, is tekst dynamisch aan dia's toevoegen. Dit artikel toont code‑voorbeelden voor het dynamisch toevoegen van tekst met behulp van [VSTO](/slides/nl/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) en [Aspose.Slides for .NET](/slides/nl/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/).

{{% /alert %}} 
## **Tekst dynamisch toevoegen**
Beide methoden volgen de volgende stappen:

1. Een presentatie maken.
1. Een lege dia toevoegen.
1. Een tekstvak toevoegen.
1. Tekst instellen.
1. De presentatie opslaan.
## **VSTO-codevoorbeeld**
De code‑fragmenten hieronder resulteren in een presentatie met een eenvoudige dia en een tekststring erop.

**De presentatie zoals gemaakt in VSTO** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)

```c#
//Opmerking: PowerPoint is een namespace die hierboven als volgt is gedefinieerd
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Create a presentation
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Get the blank slide layout
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//Add a blank slide
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//Add a text
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//Set a text
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Text added dynamically";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//Write the output to disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```



## **Aspose.Slides voor .NET voorbeeld**
De code‑fragmenten hieronder gebruiken Aspose.Slides om een presentatie te maken met een eenvoudige dia en een tekststring erop.

**De presentatie zoals gemaakt met Aspose.Slides voor .NET** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

//Maak een presentatie
Presentation pres = new Presentation();

//Een lege dia wordt standaard toegevoegd, wanneer u een presentatie maakt
//van de default constructor
//Dus we hoeven geen lege dia toe te voegen
ISlide sld = pres.Slides[1];

//Voeg een tekstvak toe
//Om dit te doen, voegen we eerst een rechthoek toe
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//Verberg de lijn
shp.LineFormat.Style = LineStyle.NotDefined;

//Voeg vervolgens een tekstframe toe
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//Stel een tekst in
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//Schrijf de output naar schijf
pres.Save("outAspose.ppt", SaveFormat.Ppt);
```