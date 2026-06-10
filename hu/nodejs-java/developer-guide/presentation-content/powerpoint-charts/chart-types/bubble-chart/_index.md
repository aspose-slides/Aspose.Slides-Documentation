---
title: JavaScript használatával egyéni buborékdiagramok készítése előadásokhoz
linktitle: Buborékdiagram
type: docs
url: /hu/nodejs-java/bubble-chart/
keywords:
- buborékdiagram
- buborékméret
- méret skálázás
- méret ábrázolás
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Könnyedén hozhat létre és testreszabhat erőteljes buborékdiagramokat PowerPointban JavaScript és az Aspose.Slides for Node.js via Java segítségével, a adatvizualizáció javítása érdekében."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet buborékdiagramokkal dolgozni az Aspose.Slides-ben. Két konkrét testreszabási lehetőséget fed le: a buborékméret skálázását a `setBubbleSizeScale` metódus segítségével, valamint a buborékméret értékek ábrázolásának vezérlését a `setBubbleSizeRepresentation` metódus segítségével.

A példák bemutatják, hogyan hozhatunk létre buborékdiagramot, módosíthatjuk a méret skálázását, és átállíthatjuk a buborékméret ábrázolását szélesség használatára. A cikk egy rövid GyIK szekciót is tartalmaz, amely tisztázza a „Bubble with 3-D” diagramtípus támogatását, megjegyzi, hogy a gyakorlati diagramkorlátok a teljesítménytől és a célnak megfelelő PowerPoint-verziótól függenek, valamint elmagyarázza, hogy az export megőrzi a diagram megjelenését az Aspose.Slides renderelő motorja által.

## **Buborékdiagram méret skálázása**
Az Aspose.Slides for Node.js via Java támogatja a buborékdiagram méret skálázását. Az Aspose.Slides for Node.js via Java [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartSeries#getBubbleSizeScale--), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeScale--) és [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeScale-int-) metódusok lettek hozzáadva. Az alábbi példakód a következő.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 100, 100, 400, 300);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);
    pres.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Adatok ábrázolása buborékdiagram méretekként**
A [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeRepresentation-int-) és a [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeRepresentation--) metódusok lettek hozzáadva a [ChartSeries](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartSeries), [ChartSeriesGroup](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartSeriesGroup) osztályokhoz és a kapcsolódó osztályokhoz. A **BubbleSizeRepresentation** meghatározza, hogyan jelennek meg a buborékméret értékek a buborékdiagramon. Lehetséges értékek: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Area) és [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Width). Ennek megfelelően a [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/BubbleSizeRepresentationType) felsorolt típus lett hozzáadva, hogy meghatározza a lehetséges módokat az adatok buborékdiagram méretekként történő ábrázolására. Az alábbi példa kód látható.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(aspose.slides.BubbleSizeRepresentationType.Width);
    pres.save("Presentation_BubbleSizeRepresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Támogatott-e a "buborékdiagram 3-D effektussal", és miben különbözik a szabályostól?**

Igen. Létezik egy külön diagramtípus, a „Bubble with 3-D”. 3‑D stílust alkalmaz a buborékokra, de nem ad hozzá további tengelyt; az adatok továbbra is X‑Y‑S (méret) formátumban maradnak. A típus a [chart type](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/charttype/) felsorolásban érhető el.

**Van-e korlát a sorozatok és pontok számában egy buborékdiagramon?**

Nincs szigorú korlát az API szintjén; a korlátok a teljesítménytől és a célnak megfelelő PowerPoint-verziótól függenek. Ajánlott a pontok számát ésszerűen tartani az olvashatóság és a renderelési sebesség érdekében.

**Hogyan befolyásolja az export a buborékdiagram megjelenését (PDF, képek)?**

Az exportálás a támogatott formátumokba megőrzi a diagram megjelenését; a renderelést az Aspose.Slides motor végzi. Raszter/vektor formátumok esetén általános diagramgrafikai renderelési szabályok érvényesek (felbontás, élsimítás), ezért nyomtatáshoz elegendő DPI értéket válasszon.