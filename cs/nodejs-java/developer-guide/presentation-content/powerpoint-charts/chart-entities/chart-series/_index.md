---
title: Správa datových řad v grafech v prezentacích pomocí JavaScriptu
linktitle: Datové řady
type: docs
url: /cs/nodejs-java/chart-series/
keywords:
- datové řady
- překrytí řad
- barva řady
- barva kategorie
- název řady
- datový bod
- mezera řady
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se, jak v JavaScriptu spravovat řady v grafech pro PowerPoint (PPT/PPTX) pomocí praktických ukázek kódu a osvědčených postupů pro vylepšení vašich datových prezentací."
---
## **Přehled**

Tento článek popisuje roli [ChartSeries](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartseries/) v Aspose.Slides, zaměřuje se na to, jak jsou data strukturována a vizualizována v prezentacích. Tyto objekty poskytují základní prvky, které definují jednotlivé sady datových bodů, kategorie a parametry vzhledu v grafu. Prací s [ChartSeries](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartseries/), vývojáři mohou bezproblémově integrovat podkladové zdroje dat a udržet plnou kontrolu nad tím, jak jsou informace zobrazovány, což vede k dynamickým, na datech založeným prezentacím, které jasně předávají postřehy a analýzu.

Řada je řádek nebo sloupec čísel vykreslených v grafu.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Nastavení překrytí řad grafu**

Pomocí metody [ChartSeries.getOverlap](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartseries/#getOverlap) můžete určit, jak moc mají sloupce a pruhy překrývat v 2D grafu (rozsah: -100 až 100). Tato vlastnost se vztahuje na všechny řady rodičovské skupiny řad: jde o projekci odpovídající vlastnosti skupiny. Proto je tato vlastnost pouze ke čtení.

Použijte vlastnost `ParentSeriesGroup.getOverlap`, která je čtení/zápis, k nastavení požadované hodnoty pro `Overlap`.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
1. Přidejte seskupený sloupcový graf na snímek.
1. Získejte první řadu grafu.
1. Přistupte k `ParentSeriesGroup` řady grafu a nastavte požadovanou hodnotu překrytí pro řadu.
1. Zapište upravenou prezentaci do souboru PPTX.

Tento kód v JavaScriptu ukazuje, jak nastavit překrytí pro řadu grafu:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Přidá graf
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0) {
        // Nastaví překrytí řady
        series.get_Item(0).getParentSeriesGroup().setOverlap(-30);
    }
    // Zapíše soubor prezentace na disk
    pres.save("SetChartSeriesOverlap_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Změna barvy řady**

Aspose.Slides for Node.js via Java umožňuje změnit barvu řady tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
1. Přidejte graf na snímek.
1. Získejte řadu, jejíž barvu chcete změnit.
1. Nastavte požadovaný typ výplně a barvu výplně.
1. Uložte upravenou prezentaci.

Tento kód v JavaScriptu ukazuje, jak změnit barvu řady:

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

## **Změna barvy kategorie řady**

Aspose.Slides for Node.js via Java umožňuje změnit barvu kategorie řady tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
1. Přidejte graf na snímek.
1. Získejte kategorii řady, jejíž barvu chcete změnit.
1. Nastavte požadovaný typ výplně a barvu výplně.
1. Uložte upravenou prezentaci.

Tento kód v JavaScriptu ukazuje, jak změnit barvu kategorie řady:

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

## **Změna názvu řady**

Ve výchozím nastavení jsou názvy legendy pro graf obsahem buněk nad každým sloupcem nebo řádkem dat. 

V našem příkladu (ukázkový obrázek),

* sloupce jsou *Series 1, Series 2* a *Series 3*;
* řádky jsou *Category 1, Category 2, Category 3* a *Category 4*.

Aspose.Slides for Node.js via Java umožňuje aktualizovat nebo změnit název řady v datech grafu a legendě.

Tento kód v JavaScriptu ukazuje, jak změnit název řady v datech grafu `ChartDataWorkbook`:

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

Tento kód v JavaScriptu ukazuje, jak změnit název řady v legendě pomocí `Series`:

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

## **Nastavení výplně barvy řady grafu**

Aspose.Slides for Node.js via Java umožňuje nastavit automatickou barvu výplně řady grafu v oblasti vykreslování tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
1. Získejte referenci na snímek podle jeho indexu.
1. Přidejte graf s výchozími daty podle vámi preferovaného typu (v níže uvedeném příkladu jsme použili `ChartType.ClusteredColumn`).
1. Získejte řadu grafu a nastavte barvu výplně na Automatic.
1. Uložte prezentaci do souboru PPTX.

Tento kód v JavaScriptu ukazuje, jak nastavit automatickou barvu výplně pro řadu grafu:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Vytvoří seskupený sloupcový graf
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 50, 600, 400);
    // Nastaví výplň řady na automatickou
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }
    // Zapíše soubor prezentace na disk
    pres.save("AutoFillSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nastavení invertované výplně barvy řady grafu**

Aspose.Slides umožňuje nastavit invertovanou barvu výplně řady grafu v oblasti vykreslování tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
1. Získejte referenci na snímek podle jeho indexu.
1. Přidejte graf s výchozími daty podle vámi preferovaného typu (v níže uvedeném příkladu jsme použili `ChartType.ClusteredColumn`).
1. Získejte řadu grafu a nastavte barvu výplně na invert.
1. Uložte prezentaci do souboru PPTX.

Tento kód v JavaScriptu demonstruje operaci:

```javascript
var inverColor = java.getStaticFieldValue("java.awt.Color", "RED");
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Přidá nové řady a kategorie
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));
    // Vezme první řadu grafu a naplní její data řady.
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

## **Nastavení invertování řady při záporné hodnotě**

Aspose.Slides umožňuje nastavit invertování pomocí metody `ChartDataPoint.setInvertIfNegative`. Když je invertování nastaveno pomocí vlastností, datový bod invertuje své barvy, když získá zápornou hodnotu.

Tento kód v JavaScriptu demonstruje operaci:

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

## **Vymazání dat konkrétních datových bodů**

Aspose.Slides for Node.js via Java umožňuje vymazat data `DataPoints` pro konkrétní řadu grafu tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2. Získejte referenci na snímek pomocí jeho indexu.
3. Získejte referenci na graf pomocí jeho indexu.
4. Procházejte všechny `DataPoints` grafu a nastavte `XValue` a `YValue` na null.
5. Vymažte všechny`DataPoints` pro konkrétní řadu grafu.
6. Zapište upravenou prezentaci do souboru PPTX.

Tento kód v JavaScriptu demonstruje operaci:

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

## **Nastavení šířky mezery řady**

Aspose.Slides for Node.js via Java umožňuje nastavit šířku mezery řady přes vlastnost **`GapWidth`** tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
1. Získejte první snímek.
1. Přidejte graf s výchozími daty.
1. Získejte libovolnou řadu grafu.
1. Nastavte vlastnost `GapWidth`.
1. Zapište upravenou prezentaci do souboru PPTX.

Tento kód v JavaScriptu ukazuje, jak nastavit šířku mezery řady:

```javascript
// Vytvoří prázdnou prezentaci
var pres = new aspose.slides.Presentation();
try {
    // Získá první snímek prezentace
    var slide = pres.getSlides().get_Item(0);
    // Přidá graf s výchozími daty
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 0, 0, 500, 500);
    // Nastaví index listu s daty grafu
    var defaultWorksheetIndex = 0;
    // Získá list s daty grafu
    var fact = chart.getChartData().getChartDataWorkbook();
    // Přidá řady
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Přidá kategorie
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Vezme druhou řadu grafu
    var series = chart.getChartData().getSeries().get_Item(1);
    // Naplní data řady
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Nastaví hodnotu GapWidth
    series.getParentSeriesGroup().setGapWidth(50);
    // Uloží prezentaci na disk
    pres.save("GapWidth_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Existuje limit na počet řad, které může jeden graf obsahovat?**

Aspose.Slides neklade žádný pevný limit na počet řad, které přidáte. Praktický strop určuje čitelnost grafu a množství paměti dostupné vaší aplikaci.

**Co když jsou sloupce v rámci clusteru příliš blízko u sebe nebo příliš daleko?**

Upravte nastavení šířky mezery pro danou řadu (nebo její rodičovskou skupinu řad). Zvýšením hodnoty rozšíříte prostor mezi sloupci, snížením ho přiblížíte.