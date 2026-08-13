---
title: Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for .NET 15.2.0-ban
linktitle: Aspose.Slides for .NET 15.2.0
type: docs
weight: 140
url: /hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
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
description: "Tekintse át az Aspose.Slides for .NET nyilvános API frissítéseit és visszafelé nem kompatibilis változásait, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="info" %}} 
Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) vagy [eltávolított](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) osztályt, metódust, tulajdonságot stb., valamint az Aspose.Slides for .NET 15.2.0 API-val bevezetett egyéb változtatásokat.
{{% /alert %}} 
## **Nyilvános API változások**
#### **AddDataPointForDoughnutSeries metódusok hozzá lettek adva**
Az IChartDataPointCollection.AddDataPointForDoughnutSeries() metódus két túlterhelése hozzá lett adva a Doughnut diagram sorozataiba adatpontok felvételéhez.
#### **Az Aspose.Slides.SmartArt.SmartArtShape osztály örököl az Aspose.Slides.GeometryShape osztálytól**
Az Aspose.Slides.SmartArt.SmartArtShape osztály örököl az Aspose.Slides.GeometryShape osztályból. Ez a változtatás javítja az Aspose.Slides objektummodellt, és új funkciókat ad a SmartArtShape osztályhoz.
#### **Módszerek a diagram adatpont és diagram kategória index szerinti eltávolítására hozzá lettek adva**
Az IChartDataPointCollection.RemoveAt(int index) metódus hozzá lett adva a diagram adatpont index szerinti eltávolításához. Az IChartCategoryCollection.RemoveAt(int index) metódus hozzá lett adva a diagram kategória index szerinti eltávolításához.
#### **A PptXPptY érték hozzá lett adva az Aspose.Slides.Animation.PropertyType enumerációhoz**
A PptXPptY érték hozzá lett adva az Aspose.Slides.Animation.PropertyType enumerációhoz a sorosítási hiba javítása érdekében.
#### **System.Drawing.Color GetAutomaticSeriesColor() metódus hozzá lett adva az Aspose.Slides.Charts.IChartSeries-hez**
A GetAutomaticSeriesColor metódus automatikus színt ad vissza a sorozathoz a sorozat indexe és a diagram stílusa alapján. Ez a szín alapértelmezés szerint kerül felhasználásra, ha a FillType értéke NotDefined.
``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;




using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}
```