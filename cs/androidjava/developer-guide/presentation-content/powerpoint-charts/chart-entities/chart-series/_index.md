---
title: Správa datových řad grafu v prezentacích pro Android
linktitle: Datové řady
type: docs
url: /cs/androidjava/chart-series/
keywords:
- řada grafu
- překrytí řady
- barva řady
- barva kategorie
- název řady
- datový bod
- mezera řady
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Naučte se spravovat řady grafu na Androidu pro PowerPoint (PPT/PPTX) s praktickými ukázkami kódu v Javě a osvědčenými postupy pro vylepšení vašich datových prezentací."
---
## **Přehled**

Tento článek popisuje roli [ChartSeries](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/chartseries/) v Aspose.Slides, se zaměřením na to, jak jsou data strukturována a vizualizována v prezentacích. Tyto objekty poskytují základní prvky, které definují jednotlivé sady datových bodů, kategorie a parametry vzhledu v grafu. Prací s [ChartSeries](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/chartseries/) mohou vývojáři snadno integrovat podkladové zdroje dat a mít plnou kontrolu nad tím, jak jsou informace zobrazovány, což vede k dynamickým, na datech založeným prezentacím, které jasně předávají postřehy a analýzy.

Řada je řádek nebo sloupec čísel vykreslených v grafu.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Nastavení překrytí řady grafu**

Metodou [IChartSeries.getOverlap](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartseries/#getOverlap--) můžete určit, jak moc se mají sloupce a tyčové grafy překrývat v 2D grafu (rozsah: -100 až 100). Tato vlastnost se vztahuje na všechny řady nadřazené skupiny řad: jedná se o projekci příslušné skupinové vlastnosti. Proto je tato vlastnost jen pro čtení.

Použijte zápis `getParentSeriesGroup().setOverlap()` pro nastavení požadované hodnoty překrytí.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
1. Přidejte seskupený sloupcový graf na snímek.
1. Získejte první řadu grafu.
1. Získejte `ParentSeriesGroup` řady a nastavte požadovanou hodnotu překrytí.
1. Uložte upravenou prezentaci do souboru PPTX.

Tento Java kód ukazuje, jak nastavit překrytí pro řadu grafu:

```java
Presentation pres = new Presentation();
try {
    // Přidá graf
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // Nastaví překrytí řady
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // Zapíše soubor prezentace na disk
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Změna barvy řady**
Aspose.Slides for Android via Java umožňuje změnit barvu řady tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
1. Přidejte graf na snímek.
1. Získejte řadu, jejíž barvu chcete změnit.
1. Nastavte požadovaný typ výplně a barvu výplně.
1. Uložte upravenou prezentaci.

Tento Java kód ukazuje, jak změnit barvu řady:

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

## **Změna barvy kategorie řady**
Aspose.Slides for Android via Java umožňuje změnit barvu kategorie řady tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
1. Přidejte graf na snímek.
1. Získejte kategorii řady, jejíž barvu chcete změnit.
1. Nastavte požadovaný typ výplně a barvu výplně.
1. Uložte upravenou prezentaci.

Tento kód v Javě ukazuje, jak změnit barvu kategorie řady:

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

## **Změna názvu řady**

Ve výchozím nastavení jsou názvy legendy pro graf obsahem buněk nad každým sloupcem nebo řádkem dat.

V našem příkladu (ukázkový obrázek),

* sloupce jsou *Series 1, Series 2,* a *Series 3*;
* řádky jsou *Category 1, Category 2, Category 3,* a *Category 4*.

Aspose.Slides for Android via Java umožňuje aktualizovat nebo změnit název řady v jejích datech grafu a legendě.

Tento Java kód ukazuje, jak změnit název řady v datech grafu `ChartDataWorkbook`:

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

Tento Java kód ukazuje, jak změnit název řady v legendě pomocí `Series`:

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

## **Nastavení výplně barvy řady grafu**

Aspose.Slides for Android via Java umožňuje nastavit automatickou výplň barvy pro řady grafu v oblasti vykreslování tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte graf s výchozími daty na základě požadovaného typu (v níže uvedeném příkladu jsme použili `ChartType.ClusteredColumn`).
1. Získejte řadu grafu a nastavte výplň barvy na Automatic.
1. Uložte prezentaci do souboru PPTX.

Tento Java kód ukazuje, jak nastavit automatickou výplň barvy pro řadu grafu:

```java
Presentation pres = new Presentation();
try {
    // Vytvoří seskupený sloupcový graf
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // Nastaví výplň řady na automatickou
    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }

    // Zapíše soubor prezentace na disk
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nastavení invertované výplně barvy pro řadu grafu**
Aspose.Slides umožňuje nastavit invertovanou výplň barvy pro řady grafu v oblasti vykreslování tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte graf s výchozími daty na základě požadovaného typu (v níže uvedeném příkladu jsme použili `ChartType.ClusteredColumn`).
1. Získejte řadu grafu a nastavte výplň barvy na invert.
1. Uložte prezentaci do souboru PPTX.

Tento Java kód demonstruje operaci:

```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Přidá nové řady a kategorie
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));

    // Vezme první řadu grafu a vyplní její data.
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

## **Nastavení invertování řady při záporné hodnotě**
Aspose.Slides umožňuje nastavit invertování pomocí vlastností `IChartDataPoint.InvertIfNegative` a `ChartDataPoint.InvertIfNegative`. Když je invertování nastaveno pomocí těchto vlastností, datový bod invertuje své barvy při záporné hodnotě.

Tento Java kód demonstruje operaci:

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

## **Vymazání konkrétních dat bodu**
Aspose.Slides for Android via Java umožňuje vymazat data `DataPoints` pro konkrétní řadu grafu tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
2. Získejte odkaz na snímek podle jeho indexu.
3. Získejte odkaz na graf podle jeho indexu.
4. Procházejte všechny `DataPoints` grafu a nastavte `XValue` a `YValue` na null.
5. Vymažte všechny `DataPoints` pro konkrétní řadu grafu.
6. Uložte upravenou prezentaci do souboru PPTX.

Tento Java kód demonstruje operaci:

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

## **Nastavení šířky mezery řady**
Aspose.Slides for Android via Java umožňuje nastavit šířku mezery řady pomocí vlastnosti **`GapWidth`** tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
1. Získejte první snímek.
1. Přidejte graf s výchozími daty.
1. Získejte libovolnou řadu grafu.
1. Nastavte vlastnost `GapWidth`.
1. Uložte upravenou prezentaci do souboru PPTX.

Tento kód v Javě ukazuje, jak nastavit šířku mezery řady:

```java
// Vytvoří prázdnou prezentaci
Presentation pres = new Presentation();
try {
    // Přistupuje k prvnímu snímku prezentace
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Přidá graf s výchozími daty
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // Nastaví index listu dat grafu
    int defaultWorksheetIndex = 0;
    
    // Získá list dat grafu
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Přidá řady
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Přidá kategorie
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Vybere druhou řadu grafu
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Vyplní data řady
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Nastaví hodnotu GapWidth
    series.getParentSeriesGroup().setGapWidth(50);
    
    // Uloží prezentaci na disk
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Existuje limit počtu řad, které může jediný graf obsahovat?**

Aspose.Slides nekladá žádný pevný limit na počet řad, které můžete přidat. Praktický limit určuje čitelnost grafu a paměť dostupná vaší aplikaci.

**Co když jsou sloupce v klastru příliš blízko u sebe nebo příliš daleko od sebe?**

Upravte nastavení `GapWidth` pro danou řadu (nebo její nadřazenou skupinu řad). Zvýšením hodnoty zvětšíte odstup mezi sloupci, snížením jej přiblížíte.