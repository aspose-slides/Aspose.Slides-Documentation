---
title: Publieke API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor .NET 15.7.0
linktitle: Aspose.Slides voor .NET 15.7.0
type: docs
weight: 180
url: /nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
keywords:
- migratie
- legacycode
- moderne code
- legacy-aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Bekijk de publieke API-updates en brekende wijzigingen in Aspose.Slides voor .NET om uw PowerPoint PPT-, PPTX- en ODP-presentatieoplossingen soepel te migreren."
---
{{% alert color="info" %}} 

Deze pagina geeft een overzicht van alle [toegevoegde](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) of [verwijderde](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) klassen, methoden, eigenschappen enzovoort, en andere wijzigingen die geïntroduceerd zijn met de Aspose.Slides for .NET 15.7.0 API.

{{% /alert %}} 
## **Openbare API-wijzigingen**
#### **Enum ImagePixelFormat is toegevoegd**
Enum Aspose.Slides.Export.ImagePixelFormat is toegevoegd om het pixelformaat voor de gegenereerde afbeeldingen op te geven.
#### **Methode IChartDataPoint.GetAutomaticDataPointColor() is toegevoegd**
Geeft een automatische kleur van het gegevenspunt terug op basis van de reeksindex, gegevenspuntindex, ParentSeriesGroup, de eigenschap IsColorVaried en de diagramstijl.
Deze kleur wordt standaard gebruikt als FillType gelijk is aan NotDefined.
#### **Methode RenderToGraphics is toegevoegd aan Slide**
Methode RenderToGraphics (en de overloads) is toegevoegd aan Aspose.Slides.Slide om een dia te renderen naar een Graphics‑object.
#### **Eigenschap PixelFormat is toegevoegd aan ITiffOptions en TiffOptions**
Eigenschap PixelFormat is toegevoegd aan Aspose.Slides.Export.ITiffOptions en Aspose.Slides.Export.TiffOptions om het pixelformaat voor de gegenereerde TIFF‑afbeeldingen op te geven.