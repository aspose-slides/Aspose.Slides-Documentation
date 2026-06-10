---
title: Trendvonalak hozzáadása prezentáció diagramokhoz JavaScript-ben
linktitle: Trendvonal
type: docs
url: /hu/nodejs-java/trend-line/
keywords:
- diagram
- trendvonal
- exponenciális trendvonal
- lineáris trendvonal
- logaritmikus trendvonal
- mozgó átlag trendvonal
- polinomiális trendvonal
- hatvány trendvonal
- egyedi trendvonal
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Gyorsan adjon hozzá és testreszabjon trendvonalakat a PowerPoint diagramokban JavaScript és az Aspose.Slides for Node.js via Java segítségével – egy gyakorlati útmutató a közönség bevonásához."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan adhat trendvonalakat a prezentáció diagramjaihoz az Aspose.Slides használatával. Megmutatja, hogyan hozhat létre diagramot, adhat trendvonalakat a diagram sorozataihoz, és hogyan dolgozhat többféle trendvonal típussal, többek között exponenciális, lineáris, logaritmikus, mozgó átlag, polinomiális és hatvány típusú trendvonalakkal.

Leírja továbbá, hogyan adhat egyedi vonalat a diagramhoz egy vonalas alakzat beszúrásával, és tartalmaz egy rövid GYIK-ot a trendvonal előre és hátra vetített értékeiről, valamint arról, hogy a trendvonalak megmaradnak-e PDF‑ vagy SVG‑exportáláskor és a diagramok képként történő renderelésekor.

## **Trendvonal hozzáadása**

Az Aspose.Slides for Node.js via Java egyszerű API‑t biztosít a különféle diagram Trendvonalak kezeléséhez:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
2. Szerezze meg a dia hivatkozását az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, a kívánt típus valamelyikével (ez a példa a ChartType.ClusteredColumn típust használja).
4. Exponenciális trendvonal hozzáadása az 1. sorozathoz.
5. Lineáris trendvonal hozzáadása az 1. sorozathoz.
6. Logaritmikus trendvonal hozzáadása a 2. sorozathoz.
7. Mozgó átlag trendvonal hozzáadása a 2. sorozathoz.
8. Polinomiális trendvonal hozzáadása a 3. sorozathoz.
9. Hatvány trendvonal hozzáadása a 3. sorozathoz.
10. Írja a módosított prezentációt egy PPTX fájlba.

Az alábbi kód a trendvonalakkal rendelkező diagram létrehozásához használható.

```javascript
// Hozzon létre egy példányt a Presentation osztályból
var pres = new aspose.slides.Presentation();
try {
    // Csoportos oszlopdiagram létrehozása
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);
    // Exponenciális trendvonal hozzáadása a diagram 1. sorozatához
    var tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    // Lineáris trendvonal hozzáadása a diagram 1. sorozatához
    var tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Linear);
    tredLineLin.setTrendlineType(aspose.slides.TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Logaritmikus trendvonal hozzáadása a diagram 2. sorozatához
    var tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    // Mozgó átlag trendvonal hozzáadása a diagram 2. sorozatához
    var tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod(3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    // Polinomiális trendvonal hozzáadása a diagram 3. sorozatához
    var tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder(3);
    // Hatvány trendvonal hozzáadása a diagram 3. sorozatához
    var tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Power);
    tredLinePower.setTrendlineType(aspose.slides.TrendlineType.Power);
    tredLinePower.setBackward(1);
    // Prezentáció mentése
    pres.save("ChartTrendLines_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Egyéni vonal hozzáadása**

Az Aspose.Slides for Node.js via Java egyszerű API‑t biztosít egyedi vonalak diagramhoz való hozzáadásához. Egy egyszerű egyenes vonal hozzáadásához a prezentáció kiválasztott diájához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból
- Szerezze meg egy dia hivatkozását az Index használatával
- Hozzon létre egy új diagramot a Shapes objektum által biztosított AddChart metódussal
- Adjon hozzá egy vonal típusú AutoShape‑t a Shapes objektum által biztosított AddAutoShape metódussal
- Állítsa be a forma vonalainak színét.
- Írja a módosított prezentációt PPTX fájlként

Az alábbi kód a saját vonalakkal rendelkező diagram létrehozásához használható.

```javascript
// Hozzon létre egy példányt a Presentation osztályból
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    var shape = chart.getUserShapes().getShapes().addAutoShape(aspose.slides.ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("Presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Mit jelent a 'forward' és a 'backward' egy trendvonal esetén?**

A trendvonal előre/hátra vetített hossza: pontfelhő (XY) diagramok esetén – tengelyegységekben; nem pontfelhő diagramok esetén – kategóriák számban. Csak nem negatív értékek megengedettek.

**Megmarad a trendvonal a prezentáció PDF vagy SVG exportálásakor, vagy a diák képként történő renderelésekor?**

Igen. Az Aspose.Slides konvertálja a prezentációkat [PDF](/slides/hu/nodejs-java/convert-powerpoint-to-pdf/)/[SVG](/slides/hu/nodejs-java/render-a-slide-as-an-svg-image/) formátumra, és a diagramokat képekké rendereli; a trendvonalak, mint a diagram részei, megmaradnak ezek során. Emellett elérhető egy módszer a diagram [képként való exportálásához](/slides/hu/nodejs-java/create-shape-thumbnails/).