---
title: Správa datových řad v grafech v prezentacích pomocí JavaScriptu
linktitle: Datové řady
type: docs
url: /cs/nodejs-java/chart-series/
keywords:
- řada grafu
- překrytí řad
- barva řady
- název řady
- datový bod
- buňka sešitu
- mezera řady
- záporná hodnota
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se, jak spravovat řady grafu, datové body, buňky sešitu, formátování, překrytí, šířku mezery a záporné hodnoty v prezentacích pomocí JavaScriptu."
---
## **Přehled**

Graf může ukládat své vykreslené hodnoty v buňkách sešitu nebo přímo jako číselné literály. A [ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/) představuje jeden soubor souvisejících hodnot a každý [ChartDataPoint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/) představuje bod v této řadě. Objekt [ChartCategory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/) poskytuje popisky nebo hodnoty seskupení sdílené řadami. V grafech vytvořených s výchozími daty používají názvy řad, kategorie a hodnoty bodů objekty [ChartDataCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/) ze sešitu grafu.

U typického kategoriálního grafu výchozí sešit používá řádek 0 pro názvy řad, sloupec 0 pro názvy kategorií a zbylé buňky pro hodnoty řad. Indexy listu, řádku a sloupce předávané metodě [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcell/) jsou nulové. Toto uspořádání je užitečné, když vytvoříte graf s výchozími daty, ale nepředpokládejte, že každý existující graf jej používá. Pro načtenou prezentaci si před změnou hodnot sešitu prohlédněte buňky odkazované řadami, kategoriemi a datovými body.

Nastavení grafu mají tři různé úrovně:

- Nastavení na úrovni řady, jako je [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/), poskytuje výchozí vzhled pro všechny body v jedné řadě.
- Nastavení datových bodů, jako je [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/), přepisuje vzhled řady pro jeden bod.
- Skupinová nastavení se vztahují na kompatibilní řady, které patří do stejné [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/). Přístup ke skupině získáte pomocí [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/), když potřebujete nastavit možnosti jako překrytí nebo šířku mezery.

Když není explicitně nastaveno vyplnění bodu nebo řady, určují automatický vzhled styl grafu a téma. Když jsou přítomna jak formátování řady, tak bodu, má přednost formátování bodu.

![graf-serie-powerpoint](chart-series-powerpoint.png)

## **Nastavení hodnot řady pomocí číselných literálů**

Používejte číselné literály, když hodnoty řad pocházejí z aplikačních dat nebo výpočtů a nepotřebují odkazy na buňky listu. Zavolejte [setDataSourceTypeForValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) s [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) před přiřazením výsledku [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/) každého bodu pomocí [setAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/setasliteraldouble/).

Nastavení kolekce řídí typ zdroje všech hodnot bodů v dané řadě. Metoda [getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/basechartvalue/) každé hodnoty bodu vrací vybraný typ; změňte jej prostřednictvím nastavení kolekce. S `Worksheet` použijte [getAsCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getascell/) k přístupu k odkazované buňce. S `DoubleLiterals` použijte [getAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getasliteraldouble/) nebo `setAsLiteralDouble` k přímému čtení nebo zápisu čísla.

Následující příklad vytvoří sloupcový graf s výchozími řadami a kategoriemi a poté přiřadí vypočítané hodnoty 10, 20 atd. k existujícím bodům první řady. Uloží prezentaci, znovu ji otevře a vytiskne uložené hodnoty.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(aspose.slides.DataSourceType.DoubleLiterals);
    for (let i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("numeric_literals.pptx");
try {
    const reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    const reopenedChart = reopenedSlide.getShapes().get_Item(0);
    const reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (let i = 0; i < reopenedSeries.getDataPoints().size(); i++) {
        const point = reopenedSeries.getDataPoints().get_Item(i);
        console.log(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

Typ zdroje hodnoty bodu je oddělený od [ChartData.getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/), který určuje interní nebo externí konfiguraci sešitu grafu. Použití číselných literálů samo o sobě neodstraňuje vložený sešit. V tomto příkladu zůstává sešit dostupný pro popisky kategorií, názvy řad a ostatní řady. Viz [Chart Workbook](/slides/cs/nodejs-java/chart-workbook/) pro správu sešitu.

Pro rozptylové a bublinové grafy použijte [setDataSourceTypeForXValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) a [setDataSourceTypeForYValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) k výběru zdrojů pro [getXValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getxvalue/) a [getYValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getyvalue/). Bublinové grafy také používají [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) pro [getBubbleSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getbubblesize/). Nastavte každý příslušný zdroj na `DoubleLiterals` před přiřazením čísel pomocí metody `setAsLiteralDouble` dané hodnoty.

## **Nastavení překrytí řady v grafu**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getoverlap/) udává, jak moc se překrývají pruhy nebo sloupce v 2D grafu, v rozmezí -100 až 100 procent. Jedná se o jen‑read‑only projekci nastavení ve skupině nadřazených řad. Použijte [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/) pro aktualizaci každé kompatibilní řady ve skupině. Tato možnost se vztahuje na typy grafů, které zobrazují seskupené pruhy nebo sloupce; neovlivní nesouvisející skupiny řad v kombinovaném grafu.

Následující příklad nastaví překrytí pro skupinu, která obsahuje první řadu:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const overlapPercent = java.newByte(30);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Nový graf obsahuje ukázkové řady, kategorie a hodnoty.
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Překrytí řad](series_overlap.png)

## **Změna barvy výplně řady**

Použijte [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/) k nastavení výchozí výplně pro celou řadu. Pokud má bod již explicitní výplň, jeho nastavení [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/) přepíše výplň řady pro tento bod.

Následující příklad použije plnou modrou výplň na první řadu:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(blueColor);

    presentation.save("series_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Barva řady](series_color.png)

## **Změna názvu řady**

Název řady je uložen v sešitu grafu a obvykle se zobrazuje v legendě. Ve výchozím sešitu vytvořeném pro seskupený sloupcový graf je buňka B1 v řádku 0, sloupci 1 a obsahuje název první řady. Následující pojmenované konstanty dělají tuto strukturu explicitní:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const seriesNameRowIndex = 0;
const firstSeriesColumnIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const workbook = chart.getChartData().getChartDataWorkbook();
    const seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Můžete také aktualizovat buňku již odkazovanou metodou [ChartSeries.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getname/). Tento přístup se vyhýbá předpokladu konkrétního řádku a sloupce v existujícím grafu:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const firstNameCellIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Název řady](series_name.png)

### **Vytvoření řady s názvem ze více buněk**

Složený název řady je užitečný, když je název produktu a vykazovací období uloženo v samostatných buňkách sešitu. Například můžete zkombinovat `Product A` v B1 a `2026` v C1 do jediného názvu řady a přitom zachovat obě části propojené s jejich zdrojovými buňkami.

Použijte [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcellcollection/) pro získání rozsahu názvu a poté předávejte tuto kolekci metodě [ChartSeriesCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriescollection/add/). Argument `skipHiddenCells` určuje, zda jsou zahrnuty skryté buňky: `true` je vyloučí, `false` zahrne. Tento příklad používá `false` k zahrnutí všech buněk v rozsahu názvu.

Následující příklad vytvoří prezentaci s jednou řadou a dvěma datovými body. Buňky B1:C1 poskytují jen název řady; A2:A3 poskytují popisky kategorií a B2:B3 číselné hodnoty.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // Tyto dvě buňky poskytují název řady.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    const nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    const series = chart.getChartData().getSeries().add(nameCells, aspose.slides.ChartType.ClusteredColumn);

    // Samostatné buňky poskytují kategorie a číselné datové body.
    const northCategory = workbook.getCell(0, 1, 0, "North");
    const southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    const northValue = workbook.getCell(0, 1, 1, 120);
    const southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledný název řady je `Product A 2026` s mezerou mezi dvěma hodnotami buněk. Legenda jej zobrazuje jako jeden záznam pro oba sloupce. Obrázek níže ukazuje výsledek:

![Sloupcový graf s hodnotami North a South a složeným názvem řady Product A 2026 v legendě](composite_series_name.png)

## **Získání automatické barvy výplně řady**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getautomaticseriescolor/) vrací barvu vypočtenou z indexu řady a stylu grafu. Jedná se o barvu použité, když výplň řady není explicitně definována. Volání metody pouze čte vypočtenou barvu; nepřiřazují se nové výplně.

Následující příklad vytiskne automatickou barvu každé výchozí řady:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const seriesCount = chart.getChartData().getSeries().size();
    for (let seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const automaticColor = series.getAutomaticSeriesColor();
        const automaticColorText = automaticColor.toString();
        console.log("Series " + seriesIndex + ": " + automaticColorText);
    }
} finally {
    presentation.dispose();
}
```

Ukázkový výstup pro výchozí styl grafu:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Přesné barvy závisí na stylu grafu a tématu.

## **Nastavení invertované výplně pro řadu grafu**

Pro pruhové, sloupcové a bublinové řady může [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) zobrazovat záporné hodnoty jinou výplní. Nastavte běžnou výplň řady na plnou, povolte inverzi a přiřaďte barvu záporné hodnoty pomocí [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Záporná čísla zůstávají v sešitu beze změny; mění se jen jejich zobrazovaná barva.

Následující příklad nahradí výchozí data grafu jednou řadou. Řádek 0 listu obsahuje název řady, sloupec 0 názvy kategorií a sloupec 1 hodnoty:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const headerRowIndex = 0;
const categoryColumnIndex = 0;
const firstSeriesColumnIndex = 1;
const firstDataRowIndex = 1;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const categoryNames = ["Category 1", "Category 2", "Category 3"];
const seriesValues = [-20, 50, -30];

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    const chartType = chart.getType();
    const series = chartData.getSeries().add(seriesNameCell, chartType);

    for (let categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        const dataRowIndex = firstDataRowIndex + categoryIndex;
        const categoryName = categoryNames[categoryIndex];
        const seriesValue = seriesValues[categoryIndex];

        const categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(redColor);

    presentation.save("inverted_solid_fill_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Invertovaná plná výplň](inverted_solid_fill_color.png)

Inverzi můžete povolit jen pro jeden bod pomocí [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/). V následujícím příkladu je inverze zakázána pro řadu a povolena pouze pro vybraný bod. Bod je také přiřazen zápornou hodnotou, aby byl efekt viditelný:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 2;
const negativeValue = -30;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(redColor);
    series.setInvertIfNegative(false);

    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Vymazání konkrétní hodnoty datového bodu**

Pro vyprázdnění jednoho bodu bez odstranění ostatních bodů nastavte jeho podporující buňku sešitu na `null`. U sloupcového grafu je vykreslená hodnota dostupná přes [ChartDataPoint.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/). Datový bod zůstává na stejné pozici kategorie, ale graf ho podle nastavení prázdných hodnot interpretuje jako prázdný.

Následující příklad vymaže pouze druhý bod v první řadě:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rozptylové grafy používají samostatné buňky X a Y a bublinové grafy také buňku velikosti. Vymažte jen buňku, která představuje hodnotu, kterou chcete odstranit. Nevolajte [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/) pokud chcete zachovat ostatní body, protože tato metoda odstraní všechny datové body z kolekce.

## **Ovládání zobrazení prázdných buněk**

Skryté buňky, které obsahují hodnoty, jsou odlišné od prázdných buněk. Pro zahrnutí nebo vyloučení dat ze skrytých řádků a sloupců listu viz [Include Data from Hidden Rows and Columns](/slides/cs/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Prázdná buňka sešitu představuje chybějící data; buňka obsahující `0` představuje známou číselnou hodnotu. Zavolejte [ChartDataCell.setValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setvalue/) s `null` pro vyprázdnění buňky. Číselná nula zůstává nulou bez ohledu na nastavení prázdných buněk.

Použijte [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) pro volbu, jak má graf zobrazovat prázdné buňky. Toto nastavení se vztahuje na celý graf. Mění způsob, jakým jsou prázdná místa vykreslována, aniž by prázdná buňka byla zaplněna nulou nebo interpolovanou hodnotou.

Následující samostatně fungující příklad vytvoří čárový graf s jednou řadou, vymaže hodnotu pro den 3 a uloží stejný graf ve všech režimech. Vstupní soubor není potřeba. [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) používá list 0, sloupec 0 pro popisky kategorií a sloupec 1 pro hodnoty; řádek 0 obsahuje název řady. Konečná data jsou `10, 20, empty, 30, 40`.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 40, 40, 640, 400);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    const series = chartData.getSeries().add(seriesNameCell, chart.getType());
    const values = [10, 20, 25, 30, 40];

    for (let i = 0; i < values.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Nechte den 3 skutečně prázdný, při zachování jeho kategorie a datového bodu.
    workbook.getCell(0, 3, 1).setValue(null);

    const modes = [aspose.slides.DisplayBlanksAsType.Gap, aspose.slides.DisplayBlanksAsType.Zero, aspose.slides.DisplayBlanksAsType.Span];
    const modeNames = ["Gap", "Zero", "Span"];
    for (let i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Každý výstupní soubor ukládá režim nastavený před uložením: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` a `empty_cells_Span.pptx`. Pro uložení jen jedné verze nastavte požadovaný režim a prezentaci uložte jednou místo opakovaného iterování přes režimy.

Porovnání níže ukazuje stejná data ve všech třech souborech. Den 3 je v sešitu v každém případě prázdný:

![Čárové grafy se stejnými daty: Gap přeruší čáru v den 3, Zero spustí čáru na nulu, a Span spojí den 2 s dnem 4.](display_blanks_as.png)

Viditelný efekt závisí na typu grafu. Čárový graf usnadňuje porovnání všech tří režimů. Pruhové a sloupcové grafy nemají čáru, kterou by bylo možné propojit přes chybějící kategorii, takže `Span` nemůže vytvořit ukázaný spojující úsek; chybějící sloupec a sloupec o výšce nula mohou také vypadat podobně. Podobně u rozptylových grafů pouze s markery neexistuje spojující čára. Neočekávejte tři odlišné výsledky pro každý typ grafu; ověřte výstup pro typ, který používáte.

## **Nastavení šířky mezery řad**

Šířka mezery udává prostor mezi sousedními shluky pruhů nebo sloupců, vyjádřený v procentech šířky pruhu nebo sloupce. Stejně jako překrytí patří k nadřazené skupině řad, nikoli k jedné řadě. Zavolejte [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) jednou pro skupinu. Větší hodnota vytvoří více prostoru mezi shluky; menší hodnota je učiní hustšími.

Následující příklad změní šířku mezery a uloží pouze finální prezentaci:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const gapWidthPercent = 30;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Šířka mezery](gap_width.png)

## **Často kladené otázky**

**Které typy grafů podporují datové řady?**

Všechny typy grafů reprezentované výčtem [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) používají data grafu, ale jejich řady nemají vždy stejnou strukturu hodnot ani nastavení. Například kategoriální grafy používají kategorie a hodnoty, rozptylové grafy používají X a Y hodnoty a bublinové grafy přidávají velikosti bublin. Používejte metodu vytváření datových bodů, která odpovídá typu řady. Volby jako překrytí a šířka mezery se vztahují pouze na kompatibilní skupiny pruhů nebo sloupců.

**Co je skupina řad grafu?**

[ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) obsahuje kompatibilní řady, které sdílejí nastavení úrovně skupiny. Kombinovaný graf může obsahovat více než jednu skupinu, takže změna skupiny získaná přes jednu řadu nemusí nutně změnit každou řadu v grafu.

**Obsahuje nově vytvořený graf výchozí data?**

Ano. Ve výchozím nastavení metoda [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) vytvoří ukázkové řady, kategorie a hodnoty. Tyto buňky můžete upravit nebo před přidáním zcela vlastního datového souboru vymazat kolekce řad i kategorií. Přetížená verze může také vytvořit graf bez výchozích dat.

**Jak jsou objekty grafu propojeny s buňkami sešitu?**

Názvy řad, popisky kategorií a hodnoty datových bodů odkazují na buňky v [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/). Změna odkazované buňky aktualizuje odpovídající prvek grafu. Při vytváření vlastních dat udržujte řádky kategorií a řádky hodnot řad zarovnané, aby byl každý bod vykreslen pod zamýšlenou kategorií.

**Jak vymazat jeden bod místo celé řady?**

Nastavte příslušnou buňku hodnoty na `null`, aby bod zachoval svou pozici v kategorii jako prázdný bod. Používejte [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/) pouze tehdy, když chcete odstranit všechny body z řady. Pokud odstraňujete i kategorie, aktualizujte všechny řady tak, aby jejich hodnoty zůstaly zarovnané s kolekcí kategorií.

**Jak jsou prázdné body zobrazovány?**

Výsledek závisí na typu grafu a hodnotě nastavené metodou [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/). Podporované grafy mohou zobrazovat prázdná místa jako mezery, jako nulové hodnoty nebo propojením sousedních bodů. Zvolte nastavení, které odpovídá významu chybějících dat ve vaší prezentaci. Viz [Ovládání zobrazení prázdných buněk](#control-the-display-of-empty-cells) pro kompletní příklad a vizuální srovnání.

**Jak jsou formátovány záporné hodnoty?**

Pro podporované pruhové, sloupcové a bublinové řady zavolejte [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) a nastavte barvu vrácenou metodou [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Chování můžete přepsat pro jednotlivý bod pomocí [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/). Tyto metody ovlivňují formátování, ne uložené číselné hodnoty.

**Které formátování má přednost, když je řada i bod formátován?**

Explicitní formátování datového bodu má přednost pro tento bod. Ostatní body nadále používají explicitní formát řady nebo, pokud není definován, automatický styl a téma grafu. Skupinová nastavení jako překrytí a šířka mezery řídí rozložení a nejsou přepisem formátování na úrovni bodu.

**Existuje limit počtu řad, které může graf obsahovat?**

Aspose.Slides neukládá pevný limit počtu řad. V praxi určují omezení souboru prezentace, dostupná paměť, doba vykreslování a přehlednost grafu praktické limity.

**Co změnit, když jsou sloupce příliš blízko nebo příliš daleko od sebe?**

Zavolejte [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) na příslušné nadřazené skupině řad. Zvyšte hodnotu pro rozšíření prostoru mezi shluky nebo ji snižte pro jejich přiblížení.