---
title: Diagram adat sorok kezelése Android-prezentációkban
linktitle: Adatsorok
type: docs
url: /hu/androidjava/chart-series/
keywords:
- diagram sorok
- sor átfedés
- sor színe
- kategória színe
- sor neve
- adatpont
- sor hézag
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan kezelje a diagram sorokat Androidon PowerPoint (PPT/PPTX) számára gyakorlati Java kódrészletekkel és legjobb gyakorlatokkal, hogy javítsa adatprezentációit."
---
## **Áttekintés**

Ez a cikk leírja a [ChartSeries](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chartseries/) szerepét az Aspose.Slides-ben, az adatstruktúra és vizualizáció bemutatására a prezentációkban. Ezek az objektumok biztosítják az alapvető elemeket, amelyek meghatározzák az egyes adatpontcsoportok, kategóriák és megjelenési paraméterek definícióját egy diagramon. A [ChartSeries](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chartseries/) használatával a fejlesztők zökkenőmentesen integrálhatják az alatta lévő adatforrásokat, és teljes irányítást gyakorolhatnak az információ megjelenítése felett, így dinamikus, adatalapú prezentációkat hozva létre, amelyek világosan közvetítik a betekintéseket és az elemzést.

A sor egy sor vagy oszlop számból áll, amely egy diagramon van ábrázolva.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **A diagram sorok átfedésének beállítása**

Az [IChartSeries.getOverlap](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#getOverlap--) metódussal meghatározhatja, hogy a sávok és oszlopok mennyire fedjék át egymást egy 2D diagramon (tartomány: -100‑tól 100‑ig). Ez a tulajdonság a szülő sorcsoport összes sorára vonatkozik: ez a megfelelő csoport tulajdonságának leképezése. Ezért ez a tulajdonság csak olvasható.

Használja a `getParentSeriesGroup().setOverlap()` író metódust az átfedés kívánt értékének beállításához.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
2. Adjon hozzá egy csoportosított oszlop diagramot egy diára.  
3. Hozza el az első diagram sorát.  
4. Hozza el a diagram sor `ParentSeriesGroup` tulajdonságát, és állítsa be a kívánt átfedési értéket a sorra.  
5. Írja a módosított prezentációt egy PPTX fájlba.  

This Java code shows you how to set the overlap for a chart series:

```java
Presentation pres = new Presentation();
try {
    // Diagram hozzáadása
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // Sor átfedés beállítása
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // A prezentáció fájl mentése a lemezre
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **A sor színének módosítása**

Az Aspose.Slides for Android Java segítségével a sor színét a következőképpen módosíthatja:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
2. Adjon hozzá diagramot a diára.  
3. Hozza el azt a sort, amelynek a színét módosítani kívánja.  
4. Állítsa be a kívánt kitöltéstípust és kitöltőszínt.  
5. Mentse a módosított prezentációt.  

This Java code shows you how to change a series' color:

```java
Presentation pres = new Presentation("test.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);

    point.setExplosion(30);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **A sor kategória színének módosítása**

Az Aspose.Slides for Android Java segítségével a sor kategória színét a következőképpen módosíthatja:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
2. Adjon hozzá diagramot a diára.  
3. Hozza el a sor kategóriát, amelynek a színét módosítani kívánja.  
4. Állítsa be a kívánt kitöltéstípust és kitöltőszínt.  
5. Mentse a módosított prezentációt.  

This code in Java shows you how to change a series category's color:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);

    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **A sor nevének módosítása** 

Alapértelmezés szerint a diagram jelmagyarázatának nevei a megfelelő oszlop vagy sor feletti cellák tartalma.  

A példánkban (minta kép),

* a oszlopok *Series 1, Series 2,* és *Series 3*;  
* a sorok *Category 1, Category 2, Category 3,* és *Category 4.*  

Az Aspose.Slides for Android Java segítségével frissítheti vagy módosíthatja egy sor nevét a diagram adatában és a jelmagyarázatban.

This Java code shows you how to change a series' name in its chart data `ChartDataWorkbook`:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);

    IChartDataCell seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

This Java code shows you how to change a series name in its legend through`Series`:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IStringChartValue name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) pres.dispose();
}
```

## **A diagram sor kitöltőszínének beállítása**

Az Aspose.Slides for Android Java segítségével a diagram sorok automatikus kitöltőszínét a következőképpen állíthatja be a diagramterületen belül:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típus alapján (az alábbi példában a `ChartType.ClusteredColumn` típust használtuk).  
4. Hozza el a diagram sorát, és állítsa a kitöltőszínt Automatikusra.  
5. Mentse a prezentációt egy PPTX fájlba.  

This Java code shows you how to set the automatic fill color for a chart series:

```java
Presentation pres = new Presentation();
try {
    // Létrehoz egy csoportosított oszlop diagramot
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // Beállítja a sor kitöltési formátumát automatikusra
    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }

    // A prezentáció fájlt a lemezre írja
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Invertált kitöltőszín beállítása diagram sorhoz**

Az Aspose.Slides for Android Java segítségével a diagram sorok invertált kitöltőszínét a következőképpen állíthatja be a diagramterületen belül:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típus alapján (az alábbi példában a `ChartType.ClusteredColumn` típust használtuk).  
4. Hozza el a diagram sorát, és állítsa a kitöltőszínt invertáltra.  
5. Mentse a prezentációt egy PPTX fájlba.  

This Java code demonstrates the operation:

```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Új sorokat és kategóriákat ad hozzá
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));

    // Az első diagram sorát veszi, és feltölti a sor adataival.
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    Color seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    
    pres.save("SetInvertFillColorChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Állítsa be, hogy egy sor invertáljon, ha az érték negatív**

Az Aspose.Slides lehetővé teszi az invertálás beállítását az `IChartDataPoint.InvertIfNegative` és `ChartDataPoint.InvertIfNegative` tulajdonságokon keresztül. Amikor a tulajdonságokkal invertálást állítanak be, az adatpont negatív érték esetén megfordítja színeit.  

This Java code demonstrates the operation:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();

    IChartSeries chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));

    chartSeries.setInvertIfNegative(false);

    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);

    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Specifikus pontadatok törlése**

Az Aspose.Slides for Android Java segítségével a `DataPoints` adatokat egy adott diagram sorra vonatkozóan a következőképpen törölheti:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Szerezze meg egy diagram hivatkozását az indexe alapján.  
4. Iteráljon a diagram összes `DataPoints` elemén, és állítsa az `XValue` és `YValue` értékét nullára.  
5. Törölje az összes `DataPoints` értéket a specifikus diagram sorból.  
6. Írja a módosított prezentációt egy PPTX fájlba.  

This Java code demonstrates the operation:

```java
Presentation pres = new Presentation("TestChart.pptx");
try {
    ISlide sl = pres.getSlides().get_Item(0);

    IChart chart = (IChart)sl.getShapes().get_Item(0);

    for (IChartDataPoint dataPoint : chart.getChartData().getSeries().get_Item(0).getDataPoints())
    {
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }

    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();

    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **A sor hézagszélességének beállítása**

Az Aspose.Slides for Android Java segítségével egy sor `GapWidth` értékét a **`GapWidth`** tulajdonságon keresztül a következőképpen állíthatja be:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
2. Hozza el az első diát.  
3. Adjon hozzá diagramot alapértelmezett adatokkal.  
4. Hozza el bármelyik diagram sort.  
5. Állítsa be a `GapWidth` tulajdonságot.  
6. Írja a módosított prezentációt egy PPTX fájlba.  

This code in Java shows you how to set a series' Gap Width:

```java
// Üres prezentáció létrehozása 
Presentation pres = new Presentation();
try {
    // A prezentáció első diájának elérése
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Alapértelmezett adatokkal diagramot ad hozzá
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // Beállítja a diagram adatlap indexét
    int defaultWorksheetIndex = 0;
    
    // Lekéri a diagram adatlapot
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Sorokat ad hozzá
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Kategóriákat ad hozzá
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // A második diagram sorát veszi
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Feltölti a sor adataival
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Beállítja a GapWidth értéket
    series.getParentSeriesGroup().setGapWidth(50);
    
    // A prezentációt lemezen menti
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Van korláta, hogy egy diagram hány sor tartalmazhat?**

Az Aspose.Slides nem állapít meg fix korlátot a hozzáadott sorok számában. A gyakorlati határ a diagram olvashatóságától és az alkalmazás rendelkezésre álló memóriájától függ.

**Mi van, ha a csoportos oszlopok túl közel vagy túl távol vannak egymástól?**

Állítsa be a `GapWidth` értéket a sorra (vagy annak szülő sorcsoportjára). Az érték növelése szélesíti az oszlopok közti távolságot, a csökkentése közelebb hozza őket.