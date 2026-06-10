---
title: Buborékdiagramok testreszabása prezentációkban .NET-ben
linktitle: Buborékdiagram
type: docs
url: /hu/net/bubble-chart/
keywords:
- buborékdiagram
- buborékméret
- méret skálázás
- méret reprezentáció
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Készítsen és testreszabjon hatékony buborékdiagramokat a PowerPointban az Aspose.Slides for .NET segítségével, hogy könnyedén javítsa adatvizualizációját."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhat buborékdiagramokkal az Aspose.Slides-ban. Két konkrét testreszabási lehetőséget fed le: a buborékméretek skálázását a `BubbleSizeScale` tulajdonságon keresztül, valamint a buborékméret-értékek megjelenítésének szabályozását a `BubbleSizeRepresentation` tulajdonsággal.  
A példák bemutatják, hogyan hozhatunk létre egy buborékdiagramot, állíthatjuk be a méret skálázását, és válthatjuk a buborékméret-megjelenítést a szélesség használatára. A cikk egy rövid GYIK részt is tartalmaz, amely tisztázza a „Bubble with 3-D” diagramtípus támogatását, megjegyzi, hogy a gyakorlati diagramhatárok a teljesítménytől és a célnak megfelelő PowerPoint verziótól függnek, valamint elmagyarázza, hogy az exportálás megőrzi a diagram megjelenését az Aspose.Slides renderelő motorja által.

## **Buborékdiagram méret skálázása**
Az Aspose.Slides for .NET támogatja a buborékdiagram méret skálázását. Az Aspose.Slides for .NET‑ben hozzáadták a **IChartSeries.BubbleSizeScale** és **IChartSeriesGroup.BubbleSizeScale** tulajdonságokat. Az alábbi példakód látható.  

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Adatok reprezentálása buborékdiagram méretekként**
A **BubbleSizeRepresentation** tulajdonságot hozzáadták az IChartSeries, IChartSeriesGroup interfészekhez és a kapcsolódó osztályokhoz. A **BubbleSizeRepresentation** meghatározza, hogyan vannak a buborékméret-értékek reprezentálva a buborékdiagramon. Lehetséges értékek: **BubbleSizeRepresentationType.Area** és **BubbleSizeRepresentationType.Width**. Ennek megfelelően hozzá lett adva a **BubbleSizeRepresentationType** enum is, amely a lehetséges módokat határozza meg az adatok buborékdiagram méretekként való ábrázolásához. Az alábbi példakód látható.  

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```

## **GYIK**

**Támogatott a „buborékdiagram 3-D hatással”, és miben különbözik egy szokásos diagramtól?**  
Igen. Létezik egy külön diagramtípus, a “Bubble with 3-D”. 3‑D stílust alkalmaz a buborékokra, de nem ad hozzá további tengelyt; az adatok továbbra is X‑Y‑S (méret) formában maradnak. A típus elérhető a [chart type](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/charttype/) felsorolásban.

**Van korlátozás a sorozatok és pontok számában egy buborékdiagramon?**  
Az API szintjén nincs szigorú korlát; a korlátozások a teljesítménytől és a célnak megfelelő PowerPoint verziótól függenek. Ajánlott a pontok számát ésszerűen tartani az olvashatóság és a renderelési sebesség érdekében.

**Hogyan befolyásolja az exportálás egy buborékdiagram megjelenését (PDF, képek)?**  
Az exportálás a támogatott formátumokba megőrzi a diagram megjelenését; a renderelést az Aspose.Slides motor végzi. Raszteres vagy vektorgrafikus formátumok esetén általános diagramgrafika renderelési szabályok érvényesek (felbontás, anti‑aliasing), ezért nyomtatáskor megfelelő DPI‑t válasszon.