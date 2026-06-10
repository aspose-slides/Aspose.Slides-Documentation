---
title: "Buborékdiagramok testreszabása prezentációkban Java segítségével"
linktitle: "Buborékdiagram"
type: docs
url: /hu/java/bubble-chart/
keywords:
- buborékdiagram
- buborékméret
- méretezés
- ábrázolás
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Hozzon létre és testreszabjon hatékony buborékdiagramokat a PowerPointban az Aspose.Slides for Java-val, hogy egyszerűen javítsa adatvizualizációját."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet buborékképekkel dolgozni az Aspose.Slides-ban. Két konkrét testreszabási lehetőséget tárgyal: a buborékméret méretezését a `setBubbleSizeScale` metódussal, valamint a buborékméret értékek megjelenítésének szabályozását a `setBubbleSizeRepresentation` metódussal.

A példák bemutatják, hogyan hozhatunk létre buborékképet, állíthatjuk be a méretezést, és válthatunk a buborékméret ábrázolására a szélesség használatával. A cikk egy rövid GyIK szekciót is tartalmaz, amely tisztázza a „Bubble with 3-D” diagramtípus támogatását, megjegyzi, hogy a gyakorlatban a diagramkorlátok a teljesítménytől és a cél PowerPoint verziótól függenek, és elmagyarázza, hogy az exportálás megőrzi a diagram megjelenését az Aspose.Slides renderelő motorja által.

## **Buborékdiagram méretezése**
Az Aspose.Slides for Java támogatja a buborékdiagram méretezését. Az Aspose.Slides for Java [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) és [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) metódusok lettek hozzáadva. Az alábbi példakód látható.

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

## **Adatok ábrázolása buborékdiagramméretekként**
A [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) és a [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) metódusok hozzá lettek adva a [IChartSeries](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartSeriesGroup) interfészekhez és a kapcsolódó osztályokhoz. A **BubbleSizeRepresentation** meghatározza, hogyan jelennek meg a buborékméret értékek a buborékdiagramon. Lehetséges értékek: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/BubbleSizeRepresentationType#Area) és [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/BubbleSizeRepresentationType#Width). Ennek megfelelően a [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/BubbleSizeRepresentationType) felsorolt típus lett hozzáadva, hogy meghatározza a lehetséges módokat az adatok buborékdiagramméretekként történő ábrázolására. Az alábbiakban mintakód látható.

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

**Támogatott a „bubble chart with 3-D effect”, és miben különbözik egy normál diagramtól?**

Igen. Létezik egy külön diagramtípus, a “Bubble with 3‑D”. 3‑D stílust alkalmaz a buborékokra, de nem ad hozzá további tengelyt; az adatok továbbra is X‑Y‑S (méret) formában maradnak. A típus a [chart type](https://reference.aspose.com/slides/hu/java/com.aspose.slides/charttype/) osztályban érhető el.

**Van korlátozás a sorozatok és pontok számában egy buborékdiagramon?**

Az API szintjén nincs szigorú korlát; a korlátozások a teljesítménytől és a cél PowerPoint verziótól függenek. Ajánlott a pontok számát ésszerűen tartani az olvashatóság és a renderelési sebesség érdekében.

**Hogyan befolyásolja az export a buborékdiagram megjelenését (PDF, képek)?**

Az exportálás a támogatott formátumokba megőrzi a diagram megjelenését; a renderelést az Aspose.Slides motor végzi. Raszteres vagy vektoros formátumok esetén általános diagramgrafikai renderelési szabályok érvényesek (felbontás, élsimítás), ezért a nyomtatáshoz elegendő DPI-t válasszon.