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
- možnosti výkresu
- barva výseče
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Vytvářejte a přizpůsobujte koláčové grafy v JavaScriptu s Aspose.Slides pro Node.js přes Java. Konfigurujte sekundární výkresy, zobrazujte popisky dat a aplikujte automatické barvy výsečí v PowerPointu."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s koláčovými grafy v Aspose.Slides. Ukazuje, jak nastavit možnosti sekundárního výkresu pro grafy Pie of Pie a Bar of Pie a jak povolit automatické barvení výsečů pro standardní koláčový graf.

Příklady se zaměřují na úlohy přizpůsobení grafu, jako je přidání grafu na snímek, úprava nastavení řad a popisků, nahrazení výchozích dat grafu vlastními kategoriemi a hodnotami a uložení aktualizované prezentace.

## **Možnosti sekundárního výkresu pro grafy Pie of Pie a Bar of Pie**

Aspose.Slides pro Node.js přes Java podporuje možnosti sekundárního výkresu pro grafy Pie of Pie a Bar of Pie. Tyto možnosti řídí velikost sekundárního výkresu a způsob, jakým jsou datové body rozděleny mezi oba výkresy.

Následující příklad vytvoří graf Pie of Pie v nové prezentaci a zobrazí hodnoty datových bodů jako popisky. Metoda [setSecondPieSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setSecondPieSize) nastaví velikost sekundárního výkresu na 149% hlavního výkresu. [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) vybere rozdělení založené na procentech a [setPieSplitPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) nastaví práh na 53%.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    const series = chart.getChartData().getSeries().get_Item(0);

    // Zobrazit hodnoty a nakonfigurovat sekundární výkres.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Vyberte kategorie pro sekundární výkres**

Použijte vlastní rozdělení, když chcete ve sekundárním výkresu seskupit konkrétní kategorie bez ohledu na jejich procentuální hodnoty. Například prodejní zpráva může zobrazovat Online a Events společně, aby si čtenáři mohli porovnat tyto dva kanály, i když představují 35% a 10% celkových prodejů.

Zavolejte [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) s [PieSplitType.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplittype/#Custom) a vyberte body pomocí [getPieSplitCustomPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). Metoda [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#add) kolekce přijímá nulový index v řadě; použijte [addItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#addItem) k přidání objektu datového bodu. V tomto příkladu index 1 vybere Online a bod s indexem 3 vybere Events. Partners je také přidán dočasně, pak vyloučen pomocí [removeItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 600, 200);

    // Nahradit výchozí data prodeji podle kanálu.
    const workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    const values = [ 40, 35, 15, 10 ];
    const seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // Vybrat Online podle jeho nulového indexu a Events podle objektu datového bodu.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Vyloučit Partners ze výběru bez odstranění jeho zdrojových dat.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) a Events (10) se v sekundárním výkresu zobrazují jako samostatné výseče. V hlavním výkresu jsou reprezentovány jednou spojenou výsečí s hodnotou 45, spolu s Retail (40) a Partners (15). Odebrání Partners z vlastního výběru jej ponechá v hlavním výkresu; neodstraňuje kategorii ani její hodnotu ze zdrojových dat grafu.

Následující obrázek zobrazuje uloženou prezentaci v PowerPointu:

![Graf Pie of Pie s Online a Events v sekundárním výkresu a jejich spojenou hodnotou 45 v hlavním výkresu](pie_of_pie_custom.png)

## **Nastavení automatických barev výsečí koláčového grafu**

Aspose.Slides pro Node.js přes Java může automaticky přiřadit různé barvy výsečím koláčového grafu. Následující příklad vytvoří koláčový graf se středovým titulkem a nahradí výchozí data třemi čtvrtletními kategoriemi a jejich hodnotami. Metoda [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/#setShowValue) zobrazuje hodnoty 20, 50 a 30 jako popisky, zatímco [setColorVaried](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setColorVaried) povoluje odlišnou barvu pro každou výseč.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);

    // Přidat centrovaný titulek grafu.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Nahradit výchozí data pomocí prvního pracovního listu.
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    const values = [ 20, 50, 30 ];
    const seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // Zobrazit hodnoty a přiřadit různé barvy výsečím.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Často kladené dotazy**

**Jsou variace Pie of Pie a Bar of Pie podporovány?**

Ano, knihovna [podporuje](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) sekundární výkres pro koláčové grafy, včetně typů Pie of Pie a Bar of Pie.

**Mohu exportovat pouze graf jako obrázek (například PNG)?**

Ano, můžete [exportovat samotný graf jako obrázek](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) (např. PNG) bez exportu celé prezentace.