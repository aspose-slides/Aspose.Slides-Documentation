---
title: Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for .NET 15.5.0-ban
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
description: "Tekintse át a nyilvános API frissítéseket és a tör-breaking változásokat az Aspose.Slides for .NET-ben, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="info" %}}

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) vagy [eltávolított](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) osztályt, metódust, tulajdonságot stb., valamint a Aspose.Slides for .NET 15.5.0 API-val bevezetett egyéb változásokat.

{{% /alert %}}
## **Nyilvános API változások**
#### **A CommonSlideViewProperties osztály és az ICommonSlideViewProperties interfész hozzáadva**
Az Aspose.Slides.CommonSlideViewProperties osztály és az Aspose.Slides.ICommonSlideViewProperties interfész közös dia nézet tulajdonságokat képviseli (jelenleg a nézet méretezési beállításait).

#### **Az IAxis.LabelOffset tulajdonság hozzáadva**
Az IAxis.LabelOffset tulajdonság a címkék és a tengely közötti távolságot határozza meg. Kategória vagy dátumtengelyre alkalmazható.

#### **Az IChartTextBlockFormat.AutofitType tulajdonság hozzáadva**
Ennek a tulajdonságnak a módosítása csak a következő diagramrészekre (DataLabel és DataLabelFormat) gyakorolhat hatást (teljes támogatás a PowerPoint 2013-ban; a PowerPoint 2007-ben nincs hatása a renderelésre).

#### **Az IChartTextBlockFormat.WrapText tulajdonság hozzáadva**
Ennek a tulajdonságnak a módosítása csak a következő diagramrészekre (DataLabel és DataLabelFormat) gyakorolhat hatást (teljes támogatás a PowerPoint 2007/2013-ban).

#### **A margin tulajdonságok hozzáadva az IChartTextBlockFormat-hoz**
Ezeknek a margin tulajdonságoknak a módosítása csak a következő diagramrészekre (DataLabel és DataLabelFormat) gyakorolhat hatást (teljes támogatás a PowerPoint 2013-ban; a PowerPoint 2007-ben nincs hatása a renderelésre).

#### **A ViewProperties.NotesViewProperties tulajdonság hozzáadva**
Az Aspose.Slides.ViewProperties.NotesViewProperties tulajdonság hozzá lett adva. Ez a jegyzet nézet módhoz kapcsolódó közös nézet tulajdonságokat határozza meg.

#### **A ViewProperties.SlideViewProperties tulajdonság hozzáadva**
Az Aspose.Slides.ViewProperties.SlideViewProperties tulajdonság hozzá lett adva. Ez a dia nézet módhoz kapcsolódó közös nézet tulajdonságokat határozza meg.