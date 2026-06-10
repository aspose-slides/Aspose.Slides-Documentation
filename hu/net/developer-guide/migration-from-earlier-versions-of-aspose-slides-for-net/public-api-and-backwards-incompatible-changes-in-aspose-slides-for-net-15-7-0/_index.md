---
title: Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for .NET 15.7.0-ban
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
description: "Tekintse át a nyilvános API frissítéseket és a breaking változásokat az Aspose.Slides for .NET-ben, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="primary" %}} 

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) vagy [eltávolított](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) osztályt, metódust, tulajdonságot stb., valamint a Aspose.Slides for .NET 15.7.0 API-val bevezetett egyéb változásokat.

{{% /alert %}} 
## **Nyilvános API változások**
#### **Az ImagePixelFormat enumeráció hozzá lett adva**
Az Aspose.Slides.Export.ImagePixelFormat enumeráció hozzá lett adva a generált képek pixelformátumának megadásához.
#### **Az IChartDataPoint.GetAutomaticDataPointColor() metódus hozzá lett adva**
Visszaadja egy adatpont automatikus színét a sorozat index, az adatpont index, a ParentSeriesGroup, az IsColorVaried tulajdonság és a diagram stílusa alapján. Ez a szín alapértelmezés szerint használatos, ha a FillType értéke NotDefined.
#### **A RenderToGraphics metódus hozzá lett adva a Slide-hoz**
A RenderToGraphics metódus (és annak overloadjai) hozzá lettek adva az Aspose.Slides.Slide osztályhoz, a dia Graphics objektumba történő rendereléséhez.
#### **A PixelFormat tulajdonság hozzá lett adva az ITiffOptions és a TiffOptions osztályokhoz**
A PixelFormat tulajdonság hozzá lett adva az Aspose.Slides.Export.ITiffOptions és az Aspose.Slides.Export.TiffOptions osztályokhoz a generált TIFF képek pixelformátumának megadásához.