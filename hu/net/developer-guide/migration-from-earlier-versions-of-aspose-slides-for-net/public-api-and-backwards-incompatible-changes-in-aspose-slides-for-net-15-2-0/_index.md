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
description: "Tekintse át a nyilvános API frissítéseket és a visszafelé nem kompatibilis változásokat az Aspose.Slides for .NET-ben, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="primary" %}} 

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) vagy [eltávolított](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) osztályt, metódust, tulajdonságot stb., valamint a Aspose.Slides for .NET 15.2.0 API-val bevezetett egyéb változásokat.

{{% /alert %}} 
## **Nyilvános API változások**
#### **AddDataPointForDoughnutSeries metódusok hozzá lettek adva**
Az IChartDataPointCollection.AddDataPointForDoughnutSeries() metódus két túlterhelése került hozzáadásra, hogy adatpontokat adhassunk a Donut (Fánk) diagram sorozataihoz.
#### **Aspose.Slides.SmartArt.SmartArtShape osztályt örökölték az Aspose.Slides.GeometryShape osztályból**
Az Aspose.Slides.SmartArt.SmartArtShape osztályt örökölték az Aspose.Slides.GeometryShape osztályból. Ez a változás javítja az Aspose.Slides objektummodellt, és új funkciókat ad a SmartArtShape osztályhoz.
#### **Metódusok került hozzáadásra a diagram adatpontjának és kategóriájának index szerinti eltávolításához**
IChartDataPointCollection.RemoveAt(int index) metódust hozzáadtuk a diagram adatpontjának index szerinti eltávolításához.  
IChartCategoryCollection.RemoveAt(int index) metódust hozzáadtuk a diagram kategóriájának index szerinti eltávolításához.
#### **PptXPptY érték hozzá lett adva az Aspose.Slides.Animation.PropertyType felsoroláshoz**
A PptXPptY értéket hozzáadták az Aspose.Slides.Animation.PropertyType felsoroláshoz a sorosítási probléma javítása keretében.
#### **System.Drawing.Color GetAutomaticSeriesColor() metódus hozzáadva az Aspose.Slides.Charts.IChartSeries-hez**
A GetAutomaticSeriesColor metódus automatikus színt ad vissza a sorozat indexe és a diagram stílusa alapján. Ez a szín alapértelmezés szerint használatos, ha a FillType értéke NotDefined.

``` csharp



using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}
```