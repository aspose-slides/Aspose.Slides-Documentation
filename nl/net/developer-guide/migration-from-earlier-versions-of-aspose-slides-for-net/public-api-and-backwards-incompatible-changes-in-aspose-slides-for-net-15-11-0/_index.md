---
title: Openbare API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor .NET 15.11.0
linktitle: Aspose.Slides voor .NET 15.11.0
type: docs
weight: 210
url: /nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
keywords:
- migratie
- legacy-code
- moderne code
- legacy-aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Bekijk de updates van de openbare API en brekende wijzigingen in Aspose.Slides voor .NET om moeiteloos uw PowerPoint PPT, PPTX en ODP presentatiesoplossingen te migreren."
---
{{% alert color="primary" %}} 

Deze pagina geeft een overzicht van alle [toegevoegd](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) of [verwijderd](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) klassen, methoden, eigenschappen enzovoort, en andere wijzigingen die zijn geïntroduceerd met de Aspose.Slides for .NET 15.11.0 API.

{{% /alert %}} 
## **Openbare API-wijzigingen**

#### **Verouderde eigenschappen in de DataLabelCollection‑klasse zijn verwijderd**
Verouderde eigenschappen in de DataLabelCollection‑klasse zijn verwijderd:
Aspose.Slides.Charts.DataLabelCollection.Delete
Aspose.Slides.Charts.DataLabelCollection.Format
Aspose.Slides.Charts.DataLabelCollection.LinkedSource
Aspose.Slides.Charts.DataLabelCollection.NumberFormat
Aspose.Slides.Charts.DataLabelCollection.Position
Aspose.Slides.Charts.DataLabelCollection.Separator
Aspose.Slides.Charts.DataLabelCollection.ShowBubbleSize
Aspose.Slides.Charts.DataLabelCollection.ShowCategoryName
Aspose.Slides.Charts.DataLabelCollection.ShowLeaderLines
Aspose.Slides.Charts.DataLabelCollection.ShowLegendKey
Aspose.Slides.Charts.DataLabelCollection.ShowPercentage
Aspose.Slides.Charts.DataLabelCollection.ShowSeriesName
Aspose.Slides.Charts.DataLabelCollection.ShowValue

#### **De nieuwe eigenschap FirstSlideNumber is toegevoegd aan de Presentation‑klasse**
De nieuw toegevoegde eigenschap FirstSlideNumber in Presentation maakt het mogelijk om het nummer van de eerste dia in een presentatie te lezen of in te stellen.

Wanneer een nieuwe FirstSlideNumber‑waarde wordt opgegeven, worden alle dia‑nummers opnieuw berekend.

``` csharp

 using(var pres = new Presenation(path))

{

  int firstSlideNumber = pres.FirstSlideNumber;

  pres.FirstSlideNumber = 10;

  pres.Save(newPath, SaveFormat.Pptx);

}

```