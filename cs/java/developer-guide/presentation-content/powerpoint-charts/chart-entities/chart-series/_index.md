---
title: Správa datových řad grafu v prezentacích pomocí Javy
linktitle: Datové řady
type: docs
url: /cs/java/chart-series/
keywords:
- řady grafu
- překrytí řad
- barva řady
- barva kategorie
- název řady
- datový bod
- mezera řady
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Zjistěte, jak spravovat řady grafu v Javě pro PowerPoint (PPT/PPTX) pomocí praktických ukázek kódu a osvědčených postupů pro vylepšení vašich datových prezentací."
---
## **Přehled**

Tento článek popisuje roli [ChartSeries](https://reference.aspose.com/slides/cs/java/com.aspose.slides/chartseries/) v Aspose.Slides, se zaměřením na to, jak jsou data strukturována a vizualizována v prezentacích. Tyto objekty poskytují základní prvky, které definují jednotlivé sady datových bodů, kategorie a parametry vzhledu v grafu. Prací s [ChartSeries](https://reference.aspose.com/slides/cs/java/com.aspose.slides/chartseries/) mohou vývojáři snadno integrovat podkladové zdroje dat a mít plnou kontrolu nad tím, jak jsou informace zobrazovány, což vede k dynamickým, na datech založeným prezentacím, které jasně předávají postřehy a analýzy.

Série je řada nebo sloupec čísel vykreslených v grafu.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Nastavení překrytí řady grafu**

Pomocí vlastnosti [IChartSeriesOverlap](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseries/properties/overlap) můžete určit, jak moc se mají sloupce a pruhy překrývat v 2D grafu (rozsah: -100 až 100). Tato vlastnost se vztahuje na všechny řady v rodičovské skupině řad: je to projekce příslušné skupinové vlastnosti. Proto je tato vlastnost pouze pro čtení.

Pro nastavení požadované hodnoty `Overlap` použijte zápis‑čtení/výpisovou vlastnost `ParentSeriesGroup.Overlap`.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
1. Přidejte seskupený sloupcový graf na snímek.
1. Získejte první řadu grafu.
1. Získejte `ParentSeriesGroup` řady a nastavte požadovanou hodnotu překrytí.
1. Zapište upravenou prezentaci do souboru PPTX.

Tento Java kód ukazuje, jak nastavit překrytí pro řadu grafu:

```java
Presentation pres = new Presentation();
try {
    // Přidá graf
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // Nastaví překrytí řad
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // Zapíše soubor prezentace na disk
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Změna barvy řady**
Aspose.Slides for Java umožňuje změnit barvu řady tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
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
Aspose.Slides for Java umožňuje změnit barvu kategorie řady tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
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

V našem příkladu (vzorek obrázku),

* sloupce jsou *Series 1, Series 2,* a *Series 3*;
* řádky jsou *Category 1, Category 2, Category 3,* a *Category 4.*

Aspose.Slides for Java umožňuje aktualizovat nebo změnit název řady v datech grafu a v legendě.

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

Tento Java kód ukazuje, jak změnit název řady v legendě přes `Series`:

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

## **Nastavení barvy výplně řady grafu**

Aspose.Slides for Java umožňuje nastavit automatickou barvu výplně pro řady grafu v oblasti vykreslování tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte graf s výchozími daty na základě požadovaného typu (v příkladu níže jsme použili `ChartType.ClusteredColumn`).
1. Získejte řadu grafu a nastavte barvu výplně na Automatic.
1. Uložte prezentaci do souboru PPTX.

Tento Java kód ukazuje, jak nastavit automatickou barvu výplně pro řadu grafu:

```java
Presentation pres = new Presentation();
try {
    // Vytvoří seskupený sloupcový graf
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // Nastaví formát výplně řady na automatický
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

## **Nastavení invertované barvy výplně pro řadu grafu**
Aspose.Slides umožňuje nastavit invertovanou barvu výplně pro řady grafu v oblasti vykreslování tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte graf s výchozími daty na základě požadovaného typu (v příkladu níže jsme použili `ChartType.ClusteredColumn`).
1. Získejte řadu grafu a nastavte barvu výplně na invert.
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

## **Nastavení inverze řady při záporné hodnotě**
Aspose.Slides umožňuje nastavit inverzi pomocí vlastností `IChartDataPoint.InvertIfNegative` a `ChartDataPoint.InvertIfNegative`. Když je inverze nastavena pomocí těchto vlastností, datový bod inverzuje své barvy, pokud získá zápornou hodnotu.

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

## **Vymazání dat konkrétního bodu**
Aspose.Slides for Java umožňuje vymazat data `DataPoints` pro konkrétní řadu grafu tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Získejte odkaz na snímek podle jeho indexu.
3. Získejte odkaz na graf podle jeho indexu.
4. Procházejte všechny `DataPoints` grafu a nastavte `XValue` a `YValue` na null.
5. Vymažte všechny `DataPoints` pro konkrétní řadu grafu.
6. Zapište upravenou prezentaci do souboru PPTX.

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
Aspose.Slides for Java umožňuje nastavit šířku mezery řady pomocí vlastnosti **`GapWidth`** tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
1. Získejte první snímek.
1. Přidejte graf s výchozími daty.
1. Získejte libovolnou řadu grafu.
1. Nastavte vlastnost `GapWidth`.
1. Zapište upravenou prezentaci do souboru PPTX.

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
    
    // Získá list s daty grafu
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Přidá řady
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Přidá kategorie
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Získá druhou řadu grafu
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

## **Často kladené otázky**

**Existuje limit počtu řad, které může jeden graf obsahovat?**

Aspose.Slides nekladí žádný pevný limit na počet řad, které přidáte. Praktický strop je dán čitelností grafu a dostupnou pamětí vaší aplikace.

**Co když jsou sloupce v klastru příliš blízko u sebe nebo příliš daleko?**

Upravte nastavení `GapWidth` pro tuto řadu (nebo její rodičovskou skupinu řad). Zvýšením hodnoty zvětšíte odstup mezi sloupci, snížením jej zmenšíte.