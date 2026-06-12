---
title: Správa popisků dat v grafech v prezentacích pomocí JavaScriptu
linktitle: Popisek dat
type: docs
url: /cs/nodejs-java/chart-data-label/
keywords:
- graf
- popisek dat
- přesnost dat
- procenta
- vzdálenost popisku
- umístění popisku
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se přidávat a formátovat popisky dat v grafech v PowerPoint prezentacích pomocí JavaScriptu a Aspose.Slides pro Node.js přes Java pro poutavější snímky."
---
## **Úvod**

Popisky dat v grafu zobrazují podrobnosti o sériích dat grafu nebo jednotlivých datových bodech. Umožňují čtenářům rychle rozpoznat sérii dat a také usnadňují pochopení grafu.

## **Nastavení přesnosti dat v popiscích dat grafu**

Tento JavaScriptový kód vám ukazuje, jak nastavit přesnost dat v popisku dat grafu:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);
    chart.getChartData().getSeries().get_Item(0).setNumberFormatOfValues("#,##0.00");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zobrazení procent jako popisků**

Aspose.Slides pro Node.js přes Java vám umožňuje nastavit procentuální popisky na zobrazovaných grafech. Tento JavaScriptový kód demonstruje operaci:

```javascript
// Vytvoří instanci třídy Presentation
var pres = new aspose.slides.Presentation();
try {
    // Získá první snímek
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 400, 400);
    var series;
    var total_for_Cat = new double[chart.getChartData().getCategories().size()];
    for (var k = 0; k < chart.getChartData().getCategories().size(); k++) {
        var cat = chart.getChartData().getCategories().get_Item(k);
        for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
            total_for_Cat[k] = total_for_Cat[k] + chart.getChartData().getSeries().get_Item(i).getDataPoints().get_Item(k).getValue().getData();
        }
    }
    var dataPontPercent = 0.0;
    for (var x = 0; x < chart.getChartData().getSeries().size(); x++) {
        series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);
        for (var j = 0; j < series.getDataPoints().size(); j++) {
            var lbl = series.getDataPoints().get_Item(j).getLabel();
            dataPontPercent = (series.getDataPoints().get_Item(j).getValue().getData() / total_for_Cat[j]) * 100;
            var port = new aspose.slides.Portion();
            port.setText(java.callStaticMethodSync("java.lang.String", "format", "{0:F2} %.2f", dataPontPercent));
            port.getPortionFormat().setFontHeight(8.0);
            lbl.getTextFrameForOverriding().setText("");
            var para = lbl.getTextFrameForOverriding().getParagraphs().get_Item(0);
            para.getPortions().add(port);
            lbl.getDataLabelFormat().setShowSeriesName(false);
            lbl.getDataLabelFormat().setShowPercentage(false);
            lbl.getDataLabelFormat().setShowLegendKey(false);
            lbl.getDataLabelFormat().setShowCategoryName(false);
            lbl.getDataLabelFormat().setShowBubbleSize(false);
        }
    }
    // Uloží prezentaci obsahující graf
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nastavení procentního znaku v popiscích dat grafu**

Tento JavaScriptový kód vám ukazuje, jak nastavit procentní znak pro popisek dat grafu:

```javascript
// Vytvoří instanci třídy Presentation
var pres = new aspose.slides.Presentation();
try {
    // Získá referenci snímku pomocí jeho indexu
    var slide = pres.getSlides().get_Item(0);
    // Vytvoří graf PercentsStackedColumn na snímku
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.PercentsStackedColumn, 20, 20, 500, 400);
    // Nastaví NumberFormatLinkedToSource na false
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");
    chart.getChartData().getSeries().clear();
    var defaultWorksheetIndex = 0;
    // Získá pracovní list dat grafu
    var workbook = chart.getChartData().getChartDataWorkbook();
    // Přidá novou sérii
    var series = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.getType());
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 1, 0.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 1, 0.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 1, 0.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 1, 0.65));
    // Nastaví barvu výplně série
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Nastaví vlastnosti LabelFormat
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Přidá novou sérii
    var series2 = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.getType());
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 2, 0.7));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 2, 0.5));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 2, 0.2));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 2, 0.35));
    // Nastaví typ výplně a barvu
    series2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    series2.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    // Zapíše prezentaci na disk
    pres.save("SetDataLabelsPercentageSign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nastavení vzdáleností popisků od osy**

Tento JavaScriptový kód vám ukazuje, jak nastavit vzdálenost popisku od kategoriální osy při práci s grafem vykresleným z os:

```javascript
// Vytvoří instanci třídy Presentation
var pres = new aspose.slides.Presentation();
try {
    // Získá referenci snímku
    var sld = pres.getSlides().get_Item(0);
    // Vytvoří graf na snímku
    var ch = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    // Nastaví vzdálenost popisku od osy
    ch.getAxes().getHorizontalAxis().setLabelOffset(500);
    // Zapíše prezentaci na disk
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Úprava umístění popisku**

Když vytvoříte graf, který nezávisí na žádné ose, například koláčový graf, mohou být popisky dat grafu příliš blízko okraji. V takovém případě musíte upravit umístění popisku dat, aby byly čáry spojující (leader lines) zobrazeny jasně.

Tento JavaScriptový kód vám ukazuje, jak upravit umístění popisku v koláčovém grafu:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 200, 200);
    var series = chart.getChartData().getSeries();
    var label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71);
    label.setY(0.04);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **Často kladené otázky**

**Jak mohu zabránit překrývání popisků dat v hustých grafech?**

Kombinujte automatické umisťování popisků, spojující čáry a zmenšenou velikost písma; v případě potřeby skryjte některá pole (například kategorii) nebo zobrazujte popisky jen pro extrémní/klíčové body.

**Jak mohu zakázat popisky pouze pro nulové, záporné nebo prázdné hodnoty?**

Filtrujte datové body před povolením popisků a vypněte jejich zobrazení pro hodnoty 0, záporné hodnoty nebo chybějící hodnoty podle definovaného pravidla.

**Jak mohu zajistit jednotný styl popisků při exportu do PDF/obrázků?**

Explicitně nastavte písma (rodinu, velikost) a ověřte, že je písmo k dispozici na straně vykreslování, aby nedošlo k náhradnímu písmu.