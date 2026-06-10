---
title: Trendvonalak hozzáadása a prezentáció diagramjaihoz Androidon
linktitle: Trendvonal
type: docs
url: /hu/androidjava/trend-line/
keywords:
- diagram
- trendvonal
- exponenciális trendvonal
- lineáris trendvonal
- logaritmikus trendvonal
- mozgó átlag trendvonal
- polinomiális trendvonal
- hatványos trendvonal
- egyéni trendvonal
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Gyorsan adjon hozzá és testreszabjon trendvonalakat a PowerPoint diagramokban az Aspose.Slides for Android via Java segítségével — egy gyakorlati útmutató, hogy közönségét lekösse."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet trendvonalakat hozzáadni a prezentáció diagramjaihoz az Aspose.Slides használatával. Megmutatja, hogyan kell diagramot létrehozni, trendvonalakat hozzáadni a diagram sorozataihoz, és különböző trendvonal típusokkal dolgozni, beleértve az exponenciális, lineáris, logaritmikus, mozgó átlag, polinomiális és hatványos trendvonalakat.

Leírja továbbá, hogyan lehet egy egyéni vonalat hozzáadni a diagramhoz egy vonal alakzat beszúrásával, valamint egy rövid GYIK‑ot tartalmaz a trendvonal előre és hátra vetített értékeiről, valamint arról, hogy a trendvonalak megmaradnak‑e PDF‑ vagy SVG‑exportáláskor és a diagramok képként történő renderelésekor.

## **Trendvonal hozzáadása**
Aspose.Slides for Android via Java egyszerű API‑t biztosít a különböző diagram Trendvonalak kezeléséhez:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
1. Szerezze meg a dia hivatkozását az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típusú diagrammal (ebben a példában a ChartType.ClusteredColumn kerül felhasználásra).
1. Exponenciális trendvonal hozzáadása az 1. sorozathoz.
1. Lineáris trendvonal hozzáadása az 1. sorozathoz.
1. Logaritmikus trendvonal hozzáadása a 2. sorozathoz.
1. Mozgó átlag trendvonal hozzáadása a 2. sorozathoz.
1. Polinomiális trendvonal hozzáadása a 3. sorozathoz.
1. Hatványos trendvonal hozzáadása a 3. sorozathoz.
1. Írja a módosított prezentációt PPTX fájlba.

Az alábbi kódot használjuk diagram Trendvonalakkal történő létrehozásához.

```java
// Példányosít egy Presentation osztályt
Presentation pres = new Presentation();
try {
    // Összevonott oszlopdiagram létrehozása
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // Exponenciális trendvonal hozzáadása az 1. diagram sorozathoz
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // Lineáris trendvonal hozzáadása az 1. diagram sorozathoz
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // Logaritmikus trendvonal hozzáadása a 2. diagram sorozathoz
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // Mozgó átlag trendvonal hozzáadása a 2. diagram sorozathoz
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // Polinomiális trendvonal hozzáadása a 3. diagram sorozathoz
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // Hatványos trendvonal hozzáadása a 3. diagram sorozathoz
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // Prezentáció mentése
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Egyéni vonal hozzáadása**
Aspose.Slides for Android via Java egyszerű API‑t kínál egyéni vonalak diagramba történő hozzáadásához. Egy egyszerű egyenes vonal hozzáadásához a prezentáció kiválasztott diájára kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból
- Szerezze meg a dia hivatkozását az Index használatával
- Hozzon létre egy új diagramot a Shapes objektum által nyújtott AddChart metódussal
- Adjon hozzá egy Line típusú AutoShape‑t a Shapes objektum által nyújtott AddAutoShape metódussal
- Állítsa be a forma vonalainak színét.
- Írja a módosított prezentációt PPTX fájlként

Az alábbi kódot használjuk diagram Egyéni Vonalakkal történő létrehozásához.

```java
// Példányosít egy Presentation osztályt
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight()/2, chart.getWidth(), 0);
    
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.RED);
    
    pres.save("Presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Mit jelentenek a 'forward' és a 'backward' a trendvonalak esetén?**

Ezek a trendvonal előre/hátra vetített hosszát jelentik: szórt (XY) diagramok esetén – tengelyegységekben; nem szórt diagramok esetén – kategóriák számában. Csak nem negatív értékek megengedettek.

**Megmarad a trendvonal a prezentáció PDF vagy SVG formátumba exportálásakor, illetve a dia képként való renderelésekor?**

Igen. Az Aspose.Slides a prezentációkat [PDF](/slides/hu/androidjava/convert-powerpoint-to-pdf/)/[SVG](/slides/hu/androidjava/render-a-slide-as-an-svg-image/) formátumba konvertálja és a diagramokat képekké rendereli; a trendvonalak a diagram részeként megmaradnak ezek során. Egy módszer is elérhető a [a diagram képének exportálása](/slides/hu/androidjava/create-shape-thumbnails/) számára.