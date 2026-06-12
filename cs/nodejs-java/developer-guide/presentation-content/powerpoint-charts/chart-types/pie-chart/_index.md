---
title: Přizpůsobení koláčových grafů v prezentacích pomocí JavaScriptu
linktitle: Koláčový graf
type: docs
url: /cs/nodejs-java/pie-chart/
keywords:
- koláčový graf
- správa grafu
- přizpůsobení grafu
- možnosti grafu
- nastavení grafu
- možnosti vykreslení
- barva výseče
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se vytvářet a přizpůsobovat koláčové grafy v JavaScriptu pomocí Aspose.Slides pro Node.js, exportovatelné do PowerPointu, a posílit tak vyprávění vašich dat během několika vteřin."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s koláčovými grafy v Aspose.Slides. Ukazuje, jak nastavit možnosti sekundárního výkresu pro grafy Pie of Pie a Bar of Pie a jak povolit automatické barvení výsečů pro standardní koláčový graf.

Příklady se zaměřují na praktické kroky přizpůsobení grafu, jako je přidání grafu na snímek, úprava nastavení sérií a popisků, nahrazení výchozích dat grafu vlastními kategoriemi a hodnotami a uložení aktualizované prezentace.

## **Možnosti sekundárního výkresu pro grafy Pie of Pie a Bar of Pie**
Aspose.Slides for Node.js via Java nyní podporuje možnosti sekundárního výkresu pro grafy Pie of Pie nebo Bar of Pie. V tomto tématu vám ukážeme, jak tyto možnosti specifikovat pomocí Aspose.Slides. Pro nastavení vlastností postupujte takto:

1. Vytvořte instanci třídy [Presentation].
1. Přidejte graf na snímek.
1. Zadejte možnosti sekundárního výkresu grafu.
1. Uložte prezentaci na disk.

V ukázce uvedené níže jsme nastavili různé vlastnosti grafu Pie of Pie.

```javascript
// Vytvořte instanci třídy Presentation
var pres = new aspose.slides.Presentation();
try {
    // Přidejte graf na snímek
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    // Nastavte různé vlastnosti
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    // Uložte prezentaci na disk
    pres.save("SecondPlotOptionsforCharts_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nastavte automatické barvy výsečů koláčového grafu**
Aspose.Slides for Node.js via Java poskytuje jednoduché rozhraní API pro nastavení automatických barev výsečů koláčového grafu. Vzorový kód ukazuje, jak nastavit výše zmíněné vlastnosti.

1. Vytvořte instanci třídy [Presentation].
1. Získejte první snímek.
1. Přidejte graf s výchozími daty.
1. Nastavte název grafu.
1. Nastavte první sérii na Zobrazit hodnoty.
1. Nastavte index listu dat grafu.
1. Získejte list dat grafu.
1. Odstraňte výchozí generované série a kategorie.
1. Přidejte nové kategorie.
1. Přidejte novou sérii.

Uložte upravenou prezentaci do souboru PPTX.

```javascript
// Vytvořte instanci třídy Presentation
var pres = new aspose.slides.Presentation();
try {
    // Přidejte graf s výchozími daty
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Nastavení názvu grafu
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Nastavte první sérii na Zobrazit hodnoty
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Nastavení indexu listu dat grafu
    var defaultWorksheetIndex = 0;
    // Získání listu dat grafu
    var fact = chart.getChartData().getChartDataWorkbook();
    // Odstranění výchozích generovaných sérií a kategorií
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Přidání nových kategorií
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Přidání nové série
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Nyní naplňování dat série
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Jsou varianty 'Pie of Pie' a 'Bar of Pie' podporovány?**

Ano, knihovna [podporuje](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/charttype/) sekundární výkres pro koláčové grafy, včetně typů 'Pie of Pie' a 'Bar of Pie'.

**Mohu exportovat jen graf jako obrázek (například PNG)?**

Ano, můžete [exportovat samotný graf jako obrázek](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/#getImage) (např. PNG) bez celé prezentace.