---
title: Publikus API és visszafelé nem kompatibilis változások az Aspose.Slides for .NET 15.5.0-ban
linktitle: Aspose.Slides for .NET 15.5.0
type: docs
weight: 160
url: /hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/
keywords:
- migráció
- örökölt kód
- modern kód
- örökölt megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tekintse át a publikus API frissítéseket és a törő változásokat az Aspose.Slides for .NET-ben, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="primary" %}} 

Ez az oldal felsorolja az összes [added](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) vagy [removed](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) osztályt, metódust, tulajdonságot és így tovább, valamint a Aspose.Slides for .NET 15.5.0 API-val bevezetett egyéb változásokat.

{{% /alert %}} 
## **Publikus API módosítások**
#### **A CommonSlideViewProperties osztály és az ICommonSlideViewProperties interfész hozzá lett adva**
Az Aspose.Slides.CommonSlideViewProperties osztály és az Aspose.Slides.ICommonSlideViewProperties interfész közös diavetítés tulajdonságokat képviseli (jelenleg a nézeti méretezési lehetőségek).
#### **Az IAxis.LabelOffset tulajdonság hozzá lett adva**
Az IAxis.LabelOffset tulajdonság megadja a címkék és a tengely közötti távolságot. Alkalmazható kategória vagy dátum tengelyre.
#### **Az IChartTextBlockFormat.AutofitType tulajdonság hozzá lett adva**
Ennek a tulajdonságnak a módosítása csak a következő diagramrészekre gyakorolhat hatást: DataLabel és DataLabelFormat (teljes támogatás a PowerPoint 2013-ban; a PowerPoint 2007-ben nincs hatása a megjelenítésre).
#### **Az IChartTextBlockFormat.WrapText tulajdonság hozzá lett adva**
Ennek a tulajdonságnak a módosítása csak a következő diagramrészekre gyakorolhat hatást: DataLabel és DataLabelFormat (teljes támogatás a PowerPoint 2007/2013-ban).
#### **A Margin tulajdonságok hozzá lettek adva az IChartTextBlockFormat-hoz**
Ezen tulajdonságok módosítása csak a következő diagramrészekre gyakorolhat hatást: DataLabel és DataLabelFormat (teljes támogatás a PowerPoint 2013-ban; a PowerPoint 2007-ben nincs hatása a megjelenítésre).
#### **A ViewProperties.NotesViewProperties tulajdonság hozzá lett adva**
Az Aspose.Slides.ViewProperties.NotesViewProperties tulajdonság hozzá lett adva. Ez a jegyzet nézet módhoz kapcsolódó közös nézeti tulajdonságokat határozza meg.
#### **A ViewProperties.SlideViewProperties tulajdonság hozzá lett adva**
Az Aspose.Slides.ViewProperties.SlideViewProperties tulajdonság hozzá lett adva. Ez a dia nézet módhoz kapcsolódó közös nézeti tulajdonságokat határozza meg.