---
title: Aspose.Slides for .NET 15.7.0 nyilvános API-ja és visszafelé kompatibilitásbontó változásai
linktitle: Aspose.Slides for .NET 15.7.0
type: docs
weight: 180
url: /hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
keywords:
- migráció
- régi kód
- modern kód
- régi megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tekintse át az Aspose.Slides for .NET nyilvános API frissítéseit és visszafelé nem kompatibilis változásait, hogy zökkenőmentesen migrálja PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="info" %}}
Ez az oldal felsorolja az összes [added](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) vagy [removed](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) osztályt, metódust, tulajdonságot stb., valamint a Aspose.Slides for .NET 15.7.0 API-val bevezetett egyéb változásokat.
{{% /alert %}}
## **Nyilvános API változások**
#### **Az ImagePixelFormat enumeráció hozzá lett adva**
Az Aspose.Slides.Export.ImagePixelFormat enumerációt hozzáadták a generált képek pixelformátumának megadásához.
#### **Az IChartDataPoint.GetAutomaticDataPointColor() metódus hozzá lett adva**
Automatikus színt ad vissza az adatponthoz, a sorozat indexe, az adatpont indexe, a ParentSeriesGroup, az IsColorVaried tulajdonság és a diagram stílusa alapján.
Ez a szín alapértelmezés szerint használatos, ha a FillType értéke NotDefined.
#### **A RenderToGraphics metódus hozzá lett adva a Slide-hez**
Az RenderToGraphics metódus (és annak túlterhelései) hozzá lett adva az Aspose.Slides.Slide osztályhoz, egy dia Graphics objektumba történő rendereléséhez.
#### **A PixelFormat tulajdonság hozzá lett adva az ITiffOptions és a TiffOptions osztályokhoz**
Az Aspose.Slides.Export.ITiffOptions és az Aspose.Slides.Export.TiffOptions osztályokhoz hozzá lett adva a PixelFormat tulajdonság, a generált TIFF képek pixelformátumának megadásához.