---
title: Lägga till text dynamiskt med VSTO och Aspose.Slides för .NET
linktitle: Lägga till text dynamiskt
type: docs
weight: 20
url: /sv/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
keywords:
- lägga till text
- migration
- VSTO
- Office-automatisering
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Se hur du migrerar från Microsoft Office-automatisering till Aspose.Slides för .NET och lägger till dynamisk text i PowerPoint (PPT, PPTX)-presentationer i C#."
---
{{% alert color="primary" %}} 

Ett vanligt uppdrag som utvecklare har är att lägga till text i bilder dynamiskt. Denna artikel visar kodexempel för att lägga till text dynamiskt med [VSTO](/slides/sv/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) och [Aspose.Slides for .NET](/slides/sv/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/).

{{% /alert %}} 
## **Lägga till text dynamiskt**
Båda metoderna följer dessa steg:

1. Skapa en presentation.
1. Lägg till en tom bild.
1. Lägg till en textruta.
1. Ange lite text.
1. Skriv presentationen.
## **VSTO kodexempel**
Kodsnuttarna nedan resulterar i en presentation med en enkel bild och en textsträng på den.

**Presentationen som skapades i VSTO** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)

```c#
//Obs: PowerPoint är ett namnrum som har definierats ovan så här
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Skapa en presentation
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



## **Aspose.Slides for .NET exempel**
Kodsnuttarna nedan använder Aspose.Slides för att skapa en presentation med en enkel bild och en textsträng på den.

**Presentationen som skapades med Aspose.Slides for .NET** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)

```c#
//Skapa en presentation
Presentation pres = new Presentation();

//Tom bild läggs till som standard, när du skapar
//presentation från standardkonstruktor
//Så, vi behöver inte lägga till någon tom bild
ISlide sld = pres.Slides[1];

//Lägg till en textruta
//För att lägga till den, lägger vi först till en rektangel
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//Dölj dess linje
shp.LineFormat.Style = LineStyle.NotDefined;

//Lägg sedan till en textram i den
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//Ange en text
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//Skriv utdata till disk
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```