---
title: Een presentatie openen in VSTO en Aspose.Slides
type: docs
weight: 120
url: /nl/net/opening-a-presentation-in-vsto-and-aspose-slides/
---
## **VSTO**
Hieronder staat het codefragment om een presentatie te openen:

``` csharp

  string FileName = "Open Presentation.pptx";

 Application.Presentations.Open(FileName);


``` 
## **Aspose.Slides**
Aspose.Slides for .NET biedt de **Presentation**-klasse die gebruikt wordt om een bestaande presentatie te openen. Het biedt een paar overladen constructors en we kunnen één van de geschikte constructors van de **Presentation**-klasse gebruiken om een object te maken op basis van een bestaande presentatie. In het voorbeeld hieronder hebben we de naam van het presentatiebestand (dat moet worden geopend) doorgegeven aan de constructor van de **Presentation**-klasse. Nadat het bestand is geopend, verkrijgen we het totale aantal dia's in de presentatie om op het scherm te tonen.

``` csharp

  string FileName = "Open Presentation.pptx";

 Presentation MyPresentation = new Presentation(FileName);

``` 
## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Opening%20a%20Presentation)