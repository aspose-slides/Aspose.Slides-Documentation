---
title: Trendvonalak hozzáadása a prezentáció diagramokhoz Java-ban
linktitle: Trendvonal
type: docs
url: /hu/java/trend-line/
keywords:
- diagram
- trendvonal
- exponenciális trendvonal
- lineáris trendvonal
- logaritmikus trendvonal
- mozgóátlag trendvonal
- polinomiális trendvonal
- hatványos trendvonal
- egyéni trendvonal
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Gyorsan adjon hozzá és testreszabjon trendvonalakat a PowerPoint-diagramokban az Aspose.Slides for Java segítségével – egy gyakorlati útmutató a közönség bevonásához."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan adhat trendvonalakat a bemutató diagramokhoz az Aspose.Slides használatával. Megmutatja, hogyan hozhat létre diagramot, hogyan adhat trendvonalakat a diagram sorozataihoz, és hogyan dolgozhat többféle trendvonal típussal, beleértve az exponenciális, lineáris, logaritmikus, mozgóátlag, polinomiális és hatványos trendvonalakat.

Emellett leírja, hogyan adhat egy egyéni vonalat a diagramhoz vonal alakzat beillesztésével, és tartalmaz egy rövid GYIK-ot a trendvonal előre és hátra kivetítési értékeiről, valamint arról, hogy a trendvonalak megmaradnak‑e a PDF vagy SVG formátumba exportáláskor, illetve a diagramok képként történő renderelésekor.

## **Trendvonal hozzáadása**
Aspose.Slides for Java egyszerű API-t biztosít a diagramok különböző trendvonalainak kezeléséhez:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.
1. Szerezze meg egy dia hivatkozását az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típus valamelyikével (ebben a példában a ChartType.ClusteredColumn‑t használjuk).
1. Exponenciális trendvonal hozzáadása az 1. diagram sorozathoz.
1. Lineáris trendvonal hozzáadása az 1. diagram sorozathoz.
1. Logaritmikus trendvonal hozzáadása a 2. diagram sorozathoz.
1. Mozgóátlag trendvonal hozzáadása a 2. diagram sorozathoz.
1. Polinomiális trendvonal hozzáadása a 3. diagram sorozathoz.
1. Hatványos trendvonal hozzáadása a 3. diagram sorozathoz.
1. Írja a módosított prezentációt egy PPTX fájlba.

Az alábbi kód a trendvonalakkal ellátott diagram létrehozásához használható.

```java
// Hozzon létre egy példányt a Presentation osztályból
Presentation pres = new Presentation();
try {
    // Klaszteres oszlopdiagram létrehozása
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
    
    // Mozgóátlag trendvonal hozzáadása a 2. diagram sorozathoz
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
Az Aspose.Slides for Java egyszerű API-t biztosít egyéni vonalak diagramhoz való hozzáadásához. Egy egyszerű egyenes vonal hozzáadásához a prezentáció kiválasztott diájához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból
- Szerezze meg egy dia hivatkozását az Index használatával
- Hozzon létre egy új diagramot a Shapes objektum által biztosított AddChart metódus használatával
- Adjon hozzá egy vonal típusú AutoShape‑et a Shapes objektum által biztosított AddAutoShape metódus használatával
- Állítsa be az alakzat vonalainak színét.
- Írja a módosított prezentációt PPTX fájlként

Az alábbi kód a saját vonalakkal ellátott diagram létrehozásához használható.

```java
// Hozzon létre egy példányt a Presentation osztályból
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

**Mit jelent a trendvonalnál a 'forward' és a 'backward'?**

Ezek a trendvonal előre vagy hátra kivetített hossza: szórt (XY) diagramoknál – tengelyegységekben; nem szórt diagramoknál – kategóriák számában. Csak nem negatív értékek megengedettek.

**Megmarad a trendvonal a prezentáció PDF vagy SVG formátumba exportálásakor, illetve a dia képként történő renderelésekor?**

Igen. Az Aspose.Slides a prezentációkat [PDF](/slides/hu/java/convert-powerpoint-to-pdf/)/[SVG](/slides/hu/java/render-a-slide-as-an-svg-image/) formátumba konvertálja, és a diagramokat képekké rendereli; a trendvonalak, mint a diagram része, megmaradnak ezeknél a műveleteknél. Egy metódus is elérhető a diagram [képének exportálásához](/slides/hu/java/create-shape-thumbnails/).