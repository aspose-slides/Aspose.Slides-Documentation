---
title: Buborékdiagramok testreszabása prezentációkban Androidon
linktitle: Buborékdiagram
type: docs
url: /hu/androidjava/bubble-chart/
keywords:
- buborékdiagram
- buborékméret
- méret skálázás
- méret ábrázolás
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Könnyedén hozhat létre és testreszabhat hatékony buborékdiagramokat a PowerPointban az Aspose.Slides for Android via Java segítségével, hogy javítsa adatok vizualizációját."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk buborékdiagramokkal az Aspose.Slides-ban. Két konkrét testreszabási lehetőséget fed le: a buborékméretek skálázását a `setBubbleSizeScale` metóduson keresztül, valamint a buborékméret-értékek megjelenítésének szabályozását a `setBubbleSizeRepresentation` metódussal. A példák bemutatják, hogyan hozhatunk létre egy buborékdiagramot, hogyan állíthatjuk be a méret skálázását, és hogyan válthatjuk át a buborékméret ábrázolását a szélesség használatára. A cikk rövid GyIK szekciót is tartalmaz, amely tisztázza a „Bubble with 3‑D” diagramtípus támogatását, megjegyzi, hogy a gyakorlati diagramkorlátok a teljesítménytől és a cél PowerPoint‑verziótól függnek, valamint elmagyarázza, hogy az export megőrzi a diagram megjelenését az Aspose.Slides renderelő motoron keresztül.

## **Buborékdiagram méret skálázása**
Az Aspose.Slides for Android via Java támogatja a buborékdiagram méret skálázását. Az Aspose.Slides for Android via Java [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) és [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) metódusok lettek hozzáadva. Az alábbi mintapélda látható. 

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);

    pres.save("Result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Adatok ábrázolása buborékdiagram méretekkel**
A [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) és [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) metódusok hozzá lettek adva az [IChartSeries](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartSeriesGroup) interfészekhez és a kapcsolódó osztályokhoz. **BubbleSizeRepresentation** meghatározza, hogyan jelennek meg a buborékméret értékek a buborékdiagramon. Lehetséges értékek: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Area) és [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Width). Ennek megfelelően a [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/BubbleSizeRepresentationType) felsorolás már elérhető, hogy megadja a lehetséges módokat az adatok buborékdiagram méretekként történő ábrázolására. Az alábbi mintakód látható.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width);

    pres.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Támogatott a „buborékdiagram 3‑D effektussal”, és miben különbözik egy normál diagramtól?**

Igen. Létezik egy külön diagramtípus, a „Bubble with 3‑D”. 3‑D stílust alkalmaz a buborékokra, de nem ad hozzá további tengelyt; az adatok továbbra is X‑Y‑S (méret) formában maradnak. A típus a [chart type](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/charttype/) osztályban érhető el.

**Van korlát a sorozatok és pontok számában egy buborékdiagramon?**

Az API szintjén nincs szigorú korlát; a korlátokat a teljesítmény és a cél PowerPoint‑verzió határozza meg. Ajánlott a pontok számát ésszerűen tartani az olvashatóság és a renderelési sebesség érdekében.

**Hogyan befolyásolja az export a buborékdiagram megjelenését (PDF, képek)?**

Az export a támogatott formátumokba megőrzi a diagram megjelenését; a renderelést az Aspose.Slides motor végzi. Raszteres/vektoros formátumoknál általános diagramgrafikai renderelési szabályok érvényesek (felbontás, élsimítás), ezért nyomtatáshoz megfelelő DPI‑t válasszon.