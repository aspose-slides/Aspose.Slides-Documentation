---
title: Diagram adatsorok kezelése prezentációkban Java-val
linktitle: Adatsorok
type: docs
url: /hu/java/chart-series/
keywords:
- diagram adatsorok
- sor átfedés
- sor szín
- kategória szín
- sor neve
- adatpont
- sor hézag
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan kezelje a diagram sorokat Java-ban a PowerPoint (PPT/PPTX) számára gyakorlati kódpéldákkal és bevált módszerekkel, az adatprezentációk javításához."
---
## **Áttekintés**

Ez a cikk leírja a [ChartSeries](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chartseries/) szerepét az Aspose.Slides-ben, kiemelve, hogyan van felépítve és megjelenítve az adat a prezentációkban. Ezek az objektumok biztosítják az alapvető elemeket, amelyek meghatározzák az egyes adatpontkészleteket, kategóriákat és megjelenési paramétereket egy diagramon. A [ChartSeries](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chartseries/) használatával a fejlesztők zökkenőmentesen integrálhatják a háttéradatforrásokat, és teljes irányítást tarthatnak a információ megjelenítése felett, ami dinamikus, adatvezérelt prezentációkat eredményez, amelyek világosan közvetítik a betekintéseket és elemzéseket.

A sor egy sor vagy oszlop számot jelent, amely a diagramon van ábrázolva.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Diagram sorok átfedésének beállítása**

A [IChartSeriesOverlap](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/properties/overlap) tulajdonsággal megadhatja, mennyire fedjék át egymást az oszlopok és sávok egy 2D diagramon (tartomány: -100 és 100). Ez a tulajdonság a szülő sorcsoport összes sorára vonatkozik: ez a megfelelő csoport tulajdonságának projekciója. Ennek következtében ez a tulajdonság csak olvasható.

Használja a `ParentSeriesGroup.Overlap` be/kiolvasási tulajdonságot az `Overlap` kívánt értékének beállításához.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Adjon hozzá egy csoportosított oszlopdiagramot egy diára.  
3. Hozzáférés az első diagram sorhoz.  
4. Hozzáférés a diagram sor `ParentSeriesGroup` tulajdonságához, és állítsa be a sor számára kívánt átfedés értékét.  
5. Írja a módosított prezentációt egy PPTX fájlba.  

Ez a Java kód bemutatja, hogyan állítható be a diagram sor átfedése:

```java
Presentation pres = new Presentation();
try {
    // Diagram hozzáadása
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // Beállítja a sor átfedését
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // A prezentáció fájlt lemezre írja
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **A sor színének módosítása**

Az Aspose.Slides for Java lehetővé teszi, hogy a sor színét a következő módon módosítsa:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Adjon hozzá egy diagramot a diára.  
3. Hozzáférés ahhoz a sorhoz, amelynek a színét módosítani kívánja.  
4. Állítsa be a kívánt kitöltéstípust és kitöltőszínt.  
5. Mentse el a módosított prezentációt.  

Ez a Java kód bemutatja, hogyan változtatható meg egy sor színe:

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

Az Aspose.Slides for Java lehetővé teszi, hogy a sor kategória színét a következő módon módosítsa:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Adjon hozzá egy diagramot a diára.  
3. Hozzáférés a sor kategóriához, amelynek a színét módosítani kívánja.  
4. Állítsa be a kívánt kitöltéstípust és kitöltőszínt.  
5. Mentse el a módosított prezentációt.  

Ez a Java kód bemutatja, hogyan változtatható meg egy sor kategória színe:

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

Alapértelmezés szerint a diagram jelmagyarázatának nevei a cellák tartalma, amelyek a minden oszlop vagy sor adat felett helyezkednek el.

A példánkban (minta kép) az oszlopok: *Series 1, Series 2,* és *Series 3*; a sorok: *Category 1, Category 2, Category 3,* és *Category 4.*

Az Aspose.Slides for Java lehetővé teszi, hogy frissítse vagy megváltoztassa egy sor nevét a diagram adataiban és a jelmagyarázatban.

Ez a Java kód bemutatja, hogyan változtatható meg egy sor neve a diagram adataiban, a `ChartDataWorkbook`-ben:

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

Ez a Java kód bemutatja, hogyan változtatható meg egy sor neve a jelmagyarázatban a `Series` használatával:

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

## **Diagram sor kitöltőszínének beállítása**

Az Aspose.Slides for Java lehetővé teszi, hogy a diagram sorok automatikus kitöltőszínét a rajzterületen a következő módon állítsa be:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg a dia referenciáját az indexe alapján.  
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, a kívánt típustól függően (az alábbi példában a `ChartType.ClusteredColumn` típust használtuk).  
4. Hozzáférés a diagram sorhoz, és állítsa be a kitöltőszínt Automatikusra.  
5. Mentse a prezentációt egy PPTX fájlba.  

Ez a Java kód bemutatja, hogyan állítható be az automatikus kitöltőszín egy diagram sorhoz:

```java
Presentation pres = new Presentation();
try {
    // Létrehoz egy csoportosított oszlopdiagramot
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // Beállítja a sor kitöltési formátumát automatikusra
    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }

    // A prezentáció fájlt lemezre írja
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Inverz kitöltőszín beállítása diagram sorhoz**

Az Aspose.Slides lehetővé teszi, hogy a diagram sorok inverz kitöltőszínét a rajzterületen a következő módon állítsa be:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg a dia referenciáját az indexe alapján.  
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, a kívánt típustól függően (az alábbi példában a `ChartType.ClusteredColumn` típust használtuk).  
4. Hozzáférés a diagram sorhoz, és állítsa be a kitöltőszínt invertáltra.  
5. Mentse a prezentációt egy PPTX fájlba.  

Ez a Java kód bemutatja a műveletet:

```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Új sorok és kategóriák hozzáadása
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

## **Sor invertálása negatív érték esetén**

Az Aspose.Slides lehetővé teszi az invertálás beállítását az `IChartDataPoint.InvertIfNegative` és a `ChartDataPoint.InvertIfNegative` tulajdonságokkal. Amikor a tulajdonságokkal invertálás van beállítva, az adatpont színei megfordulnak, ha negatív értéket kap.  

Ez a Java kód bemutatja a műveletet:

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

Az Aspose.Slides for Java lehetővé teszi a `DataPoints` adatainak törlését egy adott diagram sor számára a következő módon:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia referenciáját az indexe alapján.  
3. Szerezze meg egy diagram referenciáját az indexe alapján.  
4. Iteráljon végig az összes diagram `DataPoints` elemén, és állítsa az `XValue` és `YValue` értékeket nullára.  
5. Törölje az összes`DataPoints`-ot egy adott diagram sorhoz.  
6. Írja a módosított prezentációt egy PPTX fájlba.  

Ez a Java kód bemutatja a műveletet:

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

## **Sor hézag szélességének beállítása**

Az Aspose.Slides for Java lehetővé teszi, hogy a sor `GapWidth` (hézag szélesség) tulajdonságával a következő módon állítsa be:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Hozzáférés az első diára.  
3. Diagram hozzáadása alapértelmezett adatokkal.  
4. Hozzáférés bármely diagram sorhoz.  
5. Állítsa be a `GapWidth` tulajdonságot.  
6. Írja a módosított prezentációt egy PPTX fájlba.  

Ez a Java kód bemutatja, hogyan állítható be egy sor hézag szélessége:

```java
// Üres prezentáció létrehozása
Presentation pres = new Presentation();
try {
    // A prezentáció első diájának elérése
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Diagram hozzáadása alapértelmezett adatokkal
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // A diagram adatlap indexének beállítása
    int defaultWorksheetIndex = 0;
    
    // A diagram adatlap lekérése
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Sorok hozzáadása
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Kategóriák hozzáadása
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // A második diagram sorának kiválasztása
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // A sor adatainak feltöltése
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // GapWidth érték beállítása
    series.getParentSeriesGroup().setGapWidth(50);
    
    // Prezentáció mentése lemezre
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Van korlát arra, hogy egy diagram hány sor tartalmazhat?**

Az Aspose.Slides nem szab ki fix korlátot a hozzáadott sorok számára. A gyakorlati határ a diagram olvashatóságától és az alkalmazás rendelkezésére álló memóriától függ.

**Mi van, ha egy csoporton belüli oszlopok túl közel vagy túl távol vannak egymástól?**

Állítsa be a `GapWidth` értéket az adott sorra (vagy annak szülő sorcsoportjára). Az érték növelése megnöveli az oszlopok közötti távolságot, míg csökkentése közelebb hozza őket egymáshoz.