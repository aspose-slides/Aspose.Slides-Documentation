---
title: Správa popisků dat grafu v prezentacích pomocí JavaScriptu
linktitle: Popisek dat
type: docs
url: /cs/nodejs-java/chart-data-label/
keywords:
- graf
- popisek dat
- přesnost dat
- procento
- vzdálenost popisku
- umístění popisku
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se přidávat a formátovat popisky dat grafů v prezentacích PowerPoint pomocí JavaScriptu a Aspose.Slides pro Node.js přes Java pro poutavější snímky."
---
## **Úvod**

Popisky dat zobrazují informace o řadách grafu a jednotlivých bodech dat, což čtenářům pomáhá identifikovat hodnoty a pochopit graf. Tento článek vysvětluje, jak formátovat hodnoty, zobrazovat procenta, číst text popisků, řídit popisky mimo maximum osy, upravit rozestup popisků osy kategorií a umístit popisky koláčového grafu.

## **Nastavení přesnosti dat v popiscích grafu**

Použijte [setNumberFormatOfValues](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartseries/setnumberformatofvalues/) k formátování hodnot řad. Tento příklad vytvoří čárový graf s výchozími daty, zobrazí jeho datovou tabulku a povolí popisky hodnot pro první řadu. Formát `#,##0.00` zobrazuje oddělovač tisíců a dvě desetinná místa, aniž by měnil podkladové hodnoty.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);

    const series = chart.getChartData().getSeries().get_Item(0);
    series.setNumberFormatOfValues("#,##0.00");
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("PrecisionOfDatalabels_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zobrazení procent jako popisků**

Pro sloupcový graf se zásobníkem vypočítejte každou hodnotu jako procento celkového součtu kategorie a přiřaďte text do textového rámce vráceného metodou [getTextFrameForOverriding](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/). Tento příklad používá výchozí data grafu a zobrazuje procenta se dvěma desetinnými místy v písmeni o velikosti 8 bodů. Kategorie s nulovým součtem jsou přeskočeny, aby se zabránilo dělení nulou. Přepočítejte vlastní text popisku, pokud se data grafu změní.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 400, 400);

    const categoryTotals = new Array(chart.getChartData().getCategories().size()).fill(0);
    for (let k = 0; k < chart.getChartData().getCategories().size(); k++) {
        for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
            const series = chart.getChartData().getSeries().get_Item(i);
            const pointValue = series.getDataPoints().get_Item(k).getValue().getData();
            categoryTotals[k] += Number(pointValue);
        }
    }

    for (let x = 0; x < chart.getChartData().getSeries().size(); x++) {
        const series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);

        for (let j = 0; j < series.getDataPoints().size(); j++) {
            const label = series.getDataPoints().get_Item(j).getLabel();
            if (categoryTotals[j] == 0) {
                continue;
            }

            const pointValue = series.getDataPoints().get_Item(j).getValue().getData();
            const dataPointPercent = (Number(pointValue) / categoryTotals[j]) * 100;

            const portion = new aspose.slides.Portion();
            portion.setText(dataPointPercent.toFixed(2) + " %");
            portion.getPortionFormat().setFontHeight(8);

            label.getTextFrameForOverriding().setText("");
            const paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0);
            paragraph.getPortions().add(portion);

            label.getDataLabelFormat().setShowValue(true);
            label.getDataLabelFormat().setShowSeriesName(false);
            label.getDataLabelFormat().setShowPercentage(false);
            label.getDataLabelFormat().setShowLegendKey(false);
            label.getDataLabelFormat().setShowCategoryName(false);
            label.getDataLabelFormat().setShowBubbleSize(false);
        }
    }

    presentation.save("DisplayPercentageAsLabels_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavení procentního znaku v popiscích grafu**

Když jsou hodnoty uloženy jako zlomky, použijte [setNumberFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) k zobrazení procent. Předávejte `false` metodě [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/), aby se formát popisku použil nezávisle na buňkách zdroje.

Tento příklad vytvoří sloupcový graf se 100% zásobníkem s červenou a modrou řadou ve čtyřech kategoriích. Každý pár hodnot sečte na 1. Formát popisku `0.0%` zobrazí 0,30 jako 30,0 %, zatímco svislá osa používá dvě desetinná místa. Obě řady používají bílý text popisku o velikosti 10 bodů.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PercentsStackedColumn, 20, 20, 500, 400);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    for (let i = 0; i < 4; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    const seriesNames = ["Reds", "Blues"];
    const white = java.getStaticFieldValue("java.awt.Color", "WHITE");
    const seriesColors = [java.getStaticFieldValue("java.awt.Color", "RED"), java.getStaticFieldValue("java.awt.Color", "BLUE")];
    const values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]];

    for (let i = 0; i < seriesNames.length; i++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, i + 1, seriesNames[i]);
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());
        for (let j = 0; j < 4; j++) {
            const valueCell = workbook.getCell(worksheetIndex, j + 1, i + 1, values[i][j]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
        series.getFormat().getFill().getSolidFillColor().setColor(seriesColors[i]);

        const labelFormat = series.getLabels().getDefaultDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(false);
        labelFormat.setNumberFormat("0.0%");
        labelFormat.getTextFormat().getPortionFormat().setFontHeight(10);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(white);
    }

    presentation.save("SetDataLabelsPercentageSign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Přečtení skutečného textu popisků dat**

Použijte [getActualLabelText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) k získání textu vytvořeného nastavením popisku dat. To je užitečné při extrahování popisků pro zprávy, vyhledávání obsahu prezentace nebo ověřování vygenerovaných grafů. V níže uvedeném příkladu výchozí [formát popisku dat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/datalabelformat/) kombinuje název každé kategorie, název řady a hodnotu. Jeden bod formátuje svou hodnotu jako procento a jiný používá vlastní text z [getTextFrameForOverriding](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const firstCategoryCell = workbook.getCell(0, 1, 0, "Q1");
    chart.getChartData().getCategories().add(firstCategoryCell);
    const secondCategoryCell = workbook.getCell(0, 2, 0, "Q2");
    chart.getChartData().getCategories().add(secondCategoryCell);

    const northSeriesCell = workbook.getCell(0, 0, 1, "North");
    const north = chart.getChartData().getSeries().add(northSeriesCell, chart.getType());
    const northFirstValueCell = workbook.getCell(0, 1, 1, 0.25);
    north.getDataPoints().addDataPointForBarSeries(northFirstValueCell);
    const northSecondValueCell = workbook.getCell(0, 2, 1, 0.75);
    north.getDataPoints().addDataPointForBarSeries(northSecondValueCell);

    const southSeriesCell = workbook.getCell(0, 0, 2, "South");
    const south = chart.getChartData().getSeries().add(southSeriesCell, chart.getType());
    const southFirstValueCell = workbook.getCell(0, 1, 2, 0.40);
    south.getDataPoints().addDataPointForBarSeries(southFirstValueCell);
    const southSecondValueCell = workbook.getCell(0, 2, 2, 0.60);
    south.getDataPoints().addDataPointForBarSeries(southSecondValueCell);

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        const series = chart.getChartData().getSeries().get_Item(i);
        const format = series.getLabels().getDefaultDataLabelFormat();
        format.setShowCategoryName(true);
        format.setShowSeriesName(true);
        format.setShowValue(true);
    }

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(false);
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%");
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed");

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        const series = chart.getChartData().getSeries().get_Item(i);
        for (let j = 0; j < series.getDataPoints().size(); j++) {
            const point = series.getDataPoints().get_Item(j);
            const label = point.getLabel();
            if (!label.isVisible()) {
                continue;
            }

            console.log("Value: " + point.getValue().getData() + "; label: " + label.getActualLabelText());
        }
    }
} finally {
    presentation.dispose();
}
```

Číslo uložené v datovém bodu zůstává `0.75`, i když jeho popisek zobrazuje `75 %` spolu s názvy kategorie a řady. Vlastní text nahradí vygenerovaný text popisku. [getActualLabelText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) vrací výsledný řetězec popisku v obou případech. Zkontrolujte [isVisible](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/datalabel/isvisible/) samostatně, jak je uvedeno výše, pokud chcete extrahovat pouze viditelné popisky.

## **Řízení popisků dat mimo maximum osy**

Když omezíte rozsah osy ručně, některé datové body mohou překročit její maximum. Použijte [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chart/setshowdatalabelsovermaximum/) k řízení, zda se jejich popisky dat zobrazí. Toto nastavení mění viditelnost popisků; nemění rozsah osy ani podkladové hodnoty dat.

Níže uvedený příklad vytvoří 2D seskupený sloupcový graf s hodnotami 60 a 120. Předá `false` metodě [setAutomaticMaxValue](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/axis/setautomaticmaxvalue/) a nastaví maximum na 100 pomocí [setMaxValue](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/axis/setmaxvalue/) na svislé ose. První snímek umožňuje popisky přesahující maximum; kopie tohoto snímku je zakáže. Oba snímky jsou uloženy v `DataLabelsOverMaximum.pptx`.

Povolte popisky hodnot pomocí [setShowValue](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/datalabelformat/setshowvalue/). Nastavení na úrovni grafu samo o sobě nezpůsobí zobrazení hodnot ani nepřepíše zakázané zobrazení hodnot u jednotlivých popisků. Tento příklad povoluje hodnoty pro celou řadu a používá [setPosition](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/datalabelformat/setposition/) k umístění popisků na vnější konec každého sloupce.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();

    const firstCategory = workbook.getCell(0, 1, 0, "Within range");
    const secondCategory = workbook.getCell(0, 2, 0, "Above maximum");

    chart.getChartData().getCategories().add(firstCategory);
    chart.getChartData().getCategories().add(secondCategory);

    const seriesName = workbook.getCell(0, 0, 1, "Values");
    const series = chart.getChartData().getSeries().add(seriesName, chart.getType());

    const firstValue = workbook.getCell(0, 1, 1, 60);
    const secondValue = workbook.getCell(0, 2, 1, 120);

    series.getDataPoints().addDataPointForBarSeries(firstValue);
    series.getDataPoints().addDataPointForBarSeries(secondValue);

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(100);
    chart.setShowDataLabelsOverMaximum(true);

    const secondSlide = presentation.getSlides().addClone(slide);
    const secondChart = secondSlide.getShapes().get_Item(0);
    secondChart.setShowDataLabelsOverMaximum(false);

    presentation.save("DataLabelsOverMaximum.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Následující obrázky ukazují uložené snímky vykreslené v Microsoft PowerPoint. S `true` je popisek **120** viditelný na horní hranici; s `false` je skrytý. Popisek **60** zůstává viditelný, maximum osy zůstává na **100** a druhý datový bod zůstává **120** v obou případech.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![Graf PowerPoint zobrazující popisek hodnoty 120 s max. osy 100](data-labels-over-maximum-true.png) | ![Graf PowerPoint skrývající popisek hodnoty 120 s max. osy 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Tento příklad používá 2D sloupcový graf s hodnotovou osou. Grafy bez hodnotové osy, jako jsou koláčové a prstencové grafy, nemají maximum osy, které by šlo tímto způsobem omezit.
{{% /alert %}}

## **Nastavení vzdálenosti popisku od osy**

Použijte [setLabelOffset](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/axis/setlabeloffset/) k řízení vzdálenosti mezi popisky osy kategorií a samotnou osou. Hodnota je procento maximální velikosti písma popisků osy. Tento příklad vytvoří seskupený sloupcový graf a nastaví odsazení popisků vodorovné osy na 500. Toto nastavení ovlivňuje popisky osy kategorií, nikoli popisky připojené k jednotlivým datovým bodům.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.getAxes().getHorizontalAxis().setLabelOffset(500);

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Úprava umístění popisku**

U koláčového grafu upravte umístění popisků dat, aby se zlepšilo rozestup a vytvořil prostor pro vodící čáry.

Tento příklad zobrazuje hodnotu prvního datového bodu, umístí jeho popisek mimo část a upraví jeho vodorovné a svislé posuny pomocí [setX](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/datalabel/setx/) a [setY](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/datalabel/sety/). Tyto posuny jsou relativní k šířce a výšce grafu.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 200, 200);
    const series = chart.getChartData().getSeries();

    const label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    label.setX(java.newFloat(0.71));
    label.setY(java.newFloat(0.04));

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Koláčový graf s upraveným umístěním popisku dat](pie-chart-adjusted-label.png)

## **Často kladené otázky**

**Jak mohu zabránit překrývání popisků dat v hustých grafech?**  
Kombinujte automatické umístění popisků, vodící čáry a zmenšenou velikost písma; v případě potřeby skryjte některá pole (například kategorii) nebo zobrazte popisky pouze pro extrémní hodnoty či klíčové body.

**Jak mohu zakázat popisky jen pro nulové, záporné nebo prázdné hodnoty?**  
Filtrované datové body před povolením popisků a vypněte zobrazení pro hodnoty 0, záporné hodnoty nebo chybějící hodnoty podle definovaného pravidla.

**Jak mohu zajistit konzistentní styl popisků při exportu do PDF/obrázků?**  
Explicitně nastavte rodinu písma a velikost a ověřte, že je písmo k dispozici v prostředí vykreslování, aby nedošlo k náhradnímu písmu.