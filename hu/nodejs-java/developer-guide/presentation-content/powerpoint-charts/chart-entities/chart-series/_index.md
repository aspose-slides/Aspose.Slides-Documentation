---
title: Diagram adat sorozatok kezelése prezentációkban JavaScript használatával
linktitle: Adatsorozatok
type: docs
url: /hu/nodejs-java/chart-series/
keywords:
- diagram sorozat
- sorozat átfedés
- sorozat szín
- kategória szín
- sorozat név
- adatpont
- sorozat hézag
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan kezelje a diagram sorozatokat JavaScript-ben PowerPoint (PPT/PPTX) számára, gyakorlati kódpéldákkal és bevált módszerekkel, hogy javítsa adatprezentációit."
---
## **Áttekintés**

Ez a cikk leírja a [ChartSeries](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/) szerepét az Aspose.Slides-ben, a hangsúly a adatstruktúrák és a prezentációkban történő megjelenítés módjára. Ezek az objektumok az alapvető elemeket biztosítják, amelyek egyedi adatpontkészleteket, kategóriákat és megjelenési paramétereket definiálnak egy diagramon. A [ChartSeries](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/) használatával a fejlesztők zökkenőmentesen integrálhatják az adatforrásokat, és teljes ellenőrzést gyakorolhatnak az információk megjelenítése felett, így dinamikus, adat‑vezérelt prezentációkat hozhatnak létre, amelyek egyértelműen közvetítik a betekintéseket és elemzéseket.

Egy sorozat egy sor vagy oszlop szám, amely diagramon jelenik meg.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Diagram sorozat átfedés beállítása**

A [ChartSeries.getOverlap](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/#getOverlap) metódussal megadhatja, hogy a sávok és oszlopok mennyire fedjék át egymást egy 2D diagramon (tartomány: -100‑tól 100‑ig). Ez a tulajdonság a szülő sorozatcsoport összes sorozatára vonatkozik: ez a megfelelő csoporttulajdonság leképezése. Ennek következtében ez a tulajdonság csak olvasható.

Használja a `ParentSeriesGroup.getOverlap` olvasás‑írás tulajdonságot, hogy beállítsa a kívánt értéket az `Overlap` számára. 

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.  
2. Adjon hozzá egy csoportosított oszlopdiagramot a diára.  
3. Érje el az első diagram sorozatot.  
4. Érje el a diagram sorozat `ParentSeriesGroup` tulajdonságát, és állítsa be a kívánt átfedés értéket a sorozat számára.  
5. Írja a módosított prezentációt egy PPTX fájlba.  

Ez a JavaScript kód megmutatja, hogyan állítható be a diagram sorozat átfedése:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Diagram hozzáadása
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0) {
        // Sorozat átfedés beállítása
        series.get_Item(0).getParentSeriesGroup().setOverlap(-30);
    }
    // Írja a prezentáció fájlt a lemezre
    pres.save("SetChartSeriesOverlap_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Sorozat színének módosítása**

Az Aspose.Slides for Node.js via Java lehetővé teszi a sorozat színének módosítását a következő módon:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.  
2. Adjon hozzá egy diagramot a diára.  
3. Érje el azt a sorozatot, amelynek a színét módosítani kívánja.  
4. Állítsa be a kívánt kitöltéstípust és kitöltőszínt.  
5. Mentse a módosított prezentációt.  

Ez a JavaScript kód megmutatja, hogyan módosítható egy sorozat színe:

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);
    point.setExplosion(30);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Sorozat kategória színének módosítása**

Az Aspose.Slides for Node.js via Java lehetővé teszi egy sorozat kategória színének módosítását a következő módon:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.  
2. Adjon hozzá egy diagramot a diára.  
3. Érje el azt a sorozatkategóriát, amelynek a színét módosítani kívánja.  
4. Állítsa be a kívánt kitöltéstípust és kitöltőszínt.  
5. Mentse a módosított prezentációt.  

Ez a JavaScript kód megmutatja, hogyan módosítható egy sorozat kategória színe:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Sorozat nevének módosítása**

Alapértelmezés szerint egy diagram jelmagyarázatának nevei a sorok vagy oszlopok felett lévő cellák tartalma. 

A példánkban (minta kép):

* az oszlopok nevei *Series 1, Series 2* és *Series 3*;  
* a sorok nevei *Category 1, Category 2, Category 3* és *Category 4*.  

Az Aspose.Slides for Node.js via Java lehetővé teszi egy sorozat nevének frissítését vagy módosítását a diagram adataiban és a jelmagyarázatban.

Ez a JavaScript kód megmutatja, hogyan módosítható egy sorozat neve a diagram adatában `ChartDataWorkbook` használatával:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ez a JavaScript kód megmutatja, hogyan módosítható egy sorozat neve a jelmagyarázatban a `Series` használatával:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries().get_Item(0);
    var name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Diagram sorozat kitöltőszínének beállítása**

Az Aspose.Slides for Node.js via Java lehetővé teszi a diagram sorozat automatikus kitöltőszínének beállítását a diagram területén a következő módon:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.  
2. Szerezze meg a dia hivatkozását index alapján.  
3. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típus szerint (a példában a `ChartType.ClusteredColumn` típust használtuk).  
4. Érje el a diagram sorozatát, és állítsa a kitöltőszínt Automatikusra.  
5. Mentse a prezentációt egy PPTX fájlba.  

Ez a JavaScript kód megmutatja, hogyan állítható be a diagram sorozat automatikus kitöltőszíne:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Létrehozza egy csoportosított oszlopdiagramot
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 50, 600, 400);
    // Beállítja a sorozat kitöltési formátumát automatikusra
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }
    // A prezentáció fájlt a lemezre írja
    pres.save("AutoFillSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Diagram sorozat invertált kitöltőszínének beállítása**

Az Aspose.Slides lehetővé teszi a diagram sorozat invertált kitöltőszínének beállítását a diagram területén a következő módon:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.  
2. Szerezze meg a dia hivatkozását index alapján.  
3. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típus szerint (a példában a `ChartType.ClusteredColumn` típust használtuk).  
4. Érje el a diagram sorozatát, és állítsa a kitöltőszínt invertáltra.  
5. Mentse a prezentációt egy PPTX fájlba.  

Ez a JavaScript kód bemutatja a műveletet:

```javascript
var inverColor = java.getStaticFieldValue("java.awt.Color", "RED");
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Új sorozatokat és kategóriákat ad hozzá
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));
    // Az első diagram sorozatot veszi és kitölti a sorozat adataival.
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    var seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    pres.save("SetInvertFillColorChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Sorozat inverz beállítása negatív érték esetén**

Az Aspose.Slides lehetővé teszi az inverz beállítását a `ChartDataPoint.setInvertIfNegative` metóduson keresztül. Amikor egy invertet állít be a tulajdonságokkal, az adatpont megfordítja a színeit negatív érték esetén. 

Ez a JavaScript kód bemutatja a műveletet:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();
    var chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));
    chartSeries.setInvertIfNegative(false);
    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Specifikus adatpontok adatainak törlése**

Az Aspose.Slides for Node.js via Java lehetővé teszi a `DataPoints` adatainak törlését egy adott diagram sorozatra a következő módon:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását index alapján.  
3. Szerezze meg egy diagram hivatkozását index alapján.  
4. Iteráljon végig az összes diagram `DataPoints` elemen, és állítsa az `XValue` és `YValue` értékeket nullára.  
5. Törölje az összes `DataPoints` elemet a specifikus diagram sorozatra.  
6. Írja a módosított prezentációt egy PPTX fájlba.  

Ez a JavaScript kód bemutatja a műveletet:

```javascript
var pres = new aspose.slides.Presentation("TestChart.pptx");
try {
    var sl = pres.getSlides().get_Item(0);
    var chart = sl.getShapes().get_Item(0);
    for (let i = 0; i < chart.getChartData().getSeries().get_Item(0).getDataPoints().size(); i++) {
        let dataPoint = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(i);
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }
    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();
    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Sorozat hézag szélességének beállítása**

Az Aspose.Slides for Node.js via Java lehetővé teszi egy sorozat hézag szélességének beállítását a **`GapWidth`** tulajdonságon keresztül a következő módon:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.  
2. Érje el az első diát.  
3. Adjon hozzá egy diagramot alapértelmezett adatokkal.  
4. Érje el bármely diagram sorozatot.  
5. Állítsa be a `GapWidth` tulajdonságot.  
6. Írja a módosított prezentációt egy PPTX fájlba.  

Ez a JavaScript kód megmutatja, hogyan állítható be egy sorozat hézag szélessége:

```javascript
// Üres prezentáció létrehozása
var pres = new aspose.slides.Presentation();
try {
    // A prezentáció első diájának elérése
    var slide = pres.getSlides().get_Item(0);
    // Diagram hozzáadása alapértelmezett adatokkal
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 0, 0, 500, 500);
    // A diagram adatlap indexének beállítása
    var defaultWorksheetIndex = 0;
    // A diagram adatlapjának lekérése
    var fact = chart.getChartData().getChartDataWorkbook();
    // Sorozatok hozzáadása
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Kategóriák hozzáadása
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // A második diagram sorozat kiválasztása
    var series = chart.getChartData().getSeries().get_Item(1);
    // A sorozat adatainak feltöltése
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // A GapWidth érték beállítása
    series.getParentSeriesGroup().setGapWidth(50);
    // Prezentáció mentése lemezre
    pres.save("GapWidth_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Van-e korlátozás arra, hogy egy diagram hány sorozatot tartalmazhat?**

Az Aspose.Slides nem állít fel fix felső határt a sorozatok számát illetően. A gyakorlati limit a diagram olvashatóságától és az alkalmazás rendelkezésére álló memóriától függ.

**Mi a teendő, ha a csoporton belüli oszlopok túl közel vagy túl messze helyezkednek el?**

Állítsa be a sorozat (vagy annak szülő sorozatcsoportja) hézag szélességét. Az érték növelése növeli az oszlopok közti távolságot, míint csökkentése szorítja őket.