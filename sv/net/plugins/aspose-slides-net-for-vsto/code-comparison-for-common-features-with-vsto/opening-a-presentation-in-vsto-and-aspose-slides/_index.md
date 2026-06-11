---
title: Öppna en presentation i VSTO och Aspose.Slides
type: docs
weight: 120
url: /sv/net/opening-a-presentation-in-vsto-and-aspose-slides/
---
## **VSTO**
Nedan följer kodsnutten för att öppna en presentation:

``` csharp

  string FileName = "Open Presentation.pptx";

 Application.Presentations.Open(FileName);


``` 
## **Aspose.Slides**
Aspose.Slides för .NET tillhandahåller **Presentation**-klassen som används för att öppna en befintlig presentation. Den erbjuder några överlagrade konstruktorer och vi kan använda en av de lämpliga konstruktorerna i **Presentation**-klassen för att skapa ett objekt baserat på en befintlig presentation. I exemplet nedan har vi skickat namnet på presentationsfilen (som ska öppnas) till Presentation-klassens konstruktor. När filen har öppnats får vi det totala antalet bilder i presentationen för att skriva ut på skärmen.

``` csharp

  string FileName = "Open Presentation.pptx";

 Presentation MyPresentation = new Presentation(FileName);

``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Opening%20a%20Presentation)