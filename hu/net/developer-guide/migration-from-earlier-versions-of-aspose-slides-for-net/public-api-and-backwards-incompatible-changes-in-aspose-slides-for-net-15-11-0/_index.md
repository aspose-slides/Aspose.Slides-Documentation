---
title: Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for .NET 15.11.0-ban
linktitle: Aspose.Slides for .NET 15.11.0
type: docs
weight: 210
url: /hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
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
description: "Tekintse át az Aspose.Slides for .NET nyilvános API frissítéseit és töréspontjait, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="primary" %}} 

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) vagy [eltávolított](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) osztályt, metódust, tulajdonságot stb., valamint a Aspose.Slides for .NET 15.11.0 API‑val bevezetett egyéb változásokat.

{{% /alert %}} 
## **Nyilvános API módosítások**

#### **Az DataLabelCollection osztály elavult tulajdonságai törölve lettek**
Az DataLabelCollection osztály elavult tulajdonságai törölve lettek:
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

#### **Az új FirstSlideNumber tulajdonság hozzá lett adva a Presentation osztályhoz**
Az új FirstSlideNumber tulajdonság, amely a Presentation osztályhoz lett hozzáadva, lehetővé teszi az első dia számának lekérdezését vagy beállítását a prezentációban.

Amikor új FirstSlideNumber értéket adunk meg, az összes dia száma újraszámításra kerül.

``` csharp

 using(var pres = new Presenation(path))

{

  int firstSlideNumber = pres.FirstSlideNumber;

  pres.FirstSlideNumber = 10;

  pres.Save(newPath, SaveFormat.Pptx);

}

```