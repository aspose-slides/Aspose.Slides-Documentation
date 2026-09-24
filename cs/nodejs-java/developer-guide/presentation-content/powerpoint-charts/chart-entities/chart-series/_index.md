---
title: Správa datových sérií grafu v prezentacích pomocí JavaScriptu
linktitle: Datové série
type: docs
url: /cs/nodejs-java/chart-series/
keywords:
- série grafu
- překrytí série
- barva série
- název série
- datový bod
- buňka sešitu
- mezera mezi sériemi
- záporná hodnota
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Zjistěte, jak spravovat série grafu, datové body, buňky sešitu, formátování, překrytí, šířku mezery a záporné hodnoty v prezentacích pomocí JavaScriptu."
---
## **Přehled**

Graf ukládá svá vykreslená data do sešitu dat grafu. [ChartSeries](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartseries/) představuje jednu sadu souvisejících hodnot a každý [ChartDataPoint](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdatapoint/) v sérii odkazuje na jednu nebo více buněk sešitu. Objekt [ChartCategory](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartcategory/) poskytuje popisky nebo hodnoty seskupení sdílené sériemi. Název série, kategorie a hodnoty bodů jsou tedy propojeny s objekty [ChartDataCell](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdatacell/), místo aby byly uloženy jen jako zobrazovaný text.

U typického kategoriálního grafu výchozí sešit používá řádek 0 pro názvy sérií, sloupec 0 pro názvy kategorií a zbývající buňky pro hodnoty sérií. Indexy listu, řádku a sloupce předávané metodě [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdataworkbook/#getCell) jsou nulové (zero‑based). Toto rozložení je užitečné při vytváření grafu s výchozími daty, ale nepředpokládejte, že každá existující graf používá právě toto uspořádání. Pro načtenou prezentaci si před změnou hodnot v sešitu prohlédněte buňky, na které odkazují série, kategorie a datové body.

Nastavení grafu mají tři různé úrovně:

- Nastavení na úrovni série, například [ChartSeries.getFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartseries/#getFormat), poskytují výchozí vzhled pro všechny body v jedné sérii.
- Nastavení datových bodů, například [ChartDataPoint.getFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdatapoint/#getFormat), přepisují vzhled série pro jeden bod.
- Skupinová nastavení platí pro kompatibilní série, které patří do stejné [ChartSeriesGroup](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartseriesgroup/). Přístup ke skupině získáte pomocí [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup), pokud potřebujete nastavit např. překrytí nebo šířku mezery.

Když není explicitně nastaveno vyplnění bodu nebo série, určuje automatický vzhled styl a motiv grafu. Když jsou přítomna jak nastavení série, tak bodu, má přednost formátování bodu.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Nastavení překrytí sérií grafu**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartseries/#getOverlap) uvádí, o kolik procent se překrývají sloupce nebo pruhy ve 2D grafu, v rozmezí -100 až 100 %. Jedná se o jen‑read‑only projekci nastavení na nadřazenou skupinu sérií. Použijte [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) pro aktualizaci všech kompatibilních sérií v této skupině. Tato volba se vztahuje na typy grafů, které zobrazují seskupené sloupce nebo pruhy; neovlivňuje nesouvisející skupiny sérií v kombinovaném grafu.

Následující příklad nastaví překrytí pro skupinu, která obsahuje první sérii:

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

    // Nový graf obsahuje ukázkové série, kategorie a hodnoty.
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![The series overlap](series_overlap.png)

## **Změna barvy výplně série**

Použijte [ChartSeries.getFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartseries/#getFormat) k nastavení výchozí výplně celé série. Pokud má bod již explicitně nastavenou výplň, jeho nastavení [ChartDataPoint.getFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdatapoint/#getFormat) přepisuje výplň série pro tento bod.

Následující příklad použije jednolitou modrou výplň pro první sérii:

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

![The color of the series](series_color.png)

## **Změna názvu série**

Název série je uložen v sešitu dat grafu a normálně se zobrazuje v legendě. Ve výchozím sešitu vytvořeném pro sloupcový graf s více seskupeními je buňka B1 v řádku 0, sloupci 1 a obsahuje název první série. Pojmenované konstanty v následujícím příkladu tuto strukturu explicitně uvádějí:

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

Můžete také aktualizovat buňku, na kterou již odkazuje [ChartSeries.getName](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartseries/#getName). Tento přístup zabraňuje předpokládání konkrétního řádku a sloupce v existujícím grafu:

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

![The series name](series_name.png)

## **Získání automatické barvy výplně série**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) vrací barvu vypočtenou z indexu série a stylu grafu. Toto je barva použitá, když výplň série není explicitně definována. Volání metody pouze načte vypočtenou barvu; nepřiřazuje novou výplň.

Následující příklad vypíše automatickou barvu každé výchozí série:

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

Přesné barvy závisí na stylu a motivu grafu.

## **Nastavení invertované barvy výplně pro sérii grafu**

Pro sloupcové, pruhové a bublinové série lze pomocí [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) zobrazit záporné hodnoty jinou výplní. Nastavte běžnou výplň série na jednolitou, povolte inverzi a přiřaďte barvu záporných hodnot pomocí [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Záporná čísla zůstávají v sešitu nezměněna; mění se pouze jejich zobrazovaná barva.

Následující příklad nahradí výchozí data grafu jednou sérií. Řádek 0 listu obsahuje název série, sloupec 0 obsahuje názvy kategorií a sloupec 1 obsahuje hodnoty:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

Inverzi lze povolit pro jeden bod pomocí [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). V následujícím příkladu je inverze zakázána pro sérii a povolena jen pro vybraný bod. Bod má také přiřazenu zápornou hodnotu, aby byl efekt viditelný:

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

Chcete‑li prázdný bod, aniž byste odstraňovali ostatní body, nastavte jeho buňku v sešitu na `null`. U sloupcového grafu je vykreslená hodnota dostupná přes [ChartDataPoint.getValue](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdatapoint/#getValue). Datový bod zůstává na stejné pozici kategorie, ale graf s jeho hodnotou zachází jako s prázdnou dle nastavení prázdných hodnot grafu.

Následující příklad vymaže pouze druhý bod v první sérii:

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

U rozptylových grafů se používají samostatné buňky X a Y a u bublinových grafů i buňka velikosti. Vymažte jen buňku, která představuje hodnotu, kterou chcete odstranit. Nepoužívejte [ChartDataPointCollection.clear](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdatapointcollection/#clear), pokud chcete zachovat ostatní body, protože tato metoda odstraní všechny datové body ze sbírky.

## **Řízení zobrazení prázdných buněk**

Prázdná buňka sešitu představuje chybějící data; buňka obsahující `0` představuje známou číselnou hodnotu. Zavolejte [ChartDataCell.setValue](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdatacell/#setValue) s `null`, abyste buňku učinili prázdnou. Číselná nula zůstává nulou bez ohledu na nastavení prázdné buňky.

Použijte [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) k výběru, jak graf zobrazuje prázdné buňky. Toto nastavení se vztahuje na celý graf. Mění způsob, jakým jsou prázdná místa vykreslena, aniž by prázdná buňka byla vyplněna nulou nebo interpolovanou hodnotou.

Následující samostatný příklad vytvoří čárový graf s jednou sérií, vymaže hodnotu pro den 3 a uloží stejný graf ve třech režimech. Vstupní soubor není potřeba. [ChartDataWorkbook](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdataworkbook/) používá list 0, sloupec 0 pro popisky kategorií a sloupec 1 pro hodnoty; řádek 0 obsahuje název série. Výsledná data jsou `10, 20, empty, 30, 40`.

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

    // Zanechat den 3 skutečně prázdný, přičemž zachovat jeho kategorii a datový bod.
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

Každý výstupní soubor uloží režim přiřazený před uložením: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` a `empty_cells_Span.pptx`. Pro uložení jen jedné verze nastavte požadovaný režim a uložte prezentaci jednou místo iterace přes režimy.

Níže uvedené srovnání ukazuje stejná data ve všech třech souborech. Den 3 je v sešitu v každém případě prázdný:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Viditelný efekt závisí na typu grafu. Čárový graf umožňuje snadné porovnání všech tří režimů. U sloupcových a pruhových grafů není žádná čára, která by spojovala chybějící kategorii, takže `Span` nemůže vytvořit spojovací úsek zobrazený výše; chybějící sloupec a sloupec s nulovou výškou mohou vypadat podobně. Podobně u rozptylového grafu s jen značkami neexistuje spojovací čára. Neočekávejte tři odlišné výsledky u každého typu grafu; zkontrolujte výstup pro typ, který používáte.

## **Nastavení šířky mezery mezi sériemi**

Šířka mezery je prostor mezi sousedními skupinami sloupců nebo pruhů, vyjádřený v procentech šířky sloupce nebo pruhu. Stejně jako překrytí patří k nadřazené skupině sérií, nikoli k jedné sérii. Zavolejte [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) jednou pro skupinu. Větší hodnota vytvoří více prostoru mezi skupinami; menší hodnota je učiní hustšími.

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

![The gap width](gap_width.png)

## **Často kladené otázky**

**Jaké typy grafů podporují datové série?**

Všechny typy grafů reprezentované výčtem [ChartType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/charttype/) používají grafická data, ale jejich série nemají vždy stejnou strukturu hodnot nebo nastavení. Například kategoriální grafy používají kategorie a hodnoty, rozptylové grafy používají X a Y hodnoty a bublinové grafy přidávají velikosti bublin. Použijte metodu vytváření datových bodů, která odpovídá typu série. Možnosti jako překrytí a šířka mezery platí jen pro kompatibilní skupiny sloupců nebo pruhů.

**Co je skupina sérií grafu?**

[ChartSeriesGroup](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartseriesgroup/) obsahuje kompatibilní série, které sdílejí nastavení na úrovni skupiny. Kombinovaný graf může obsahovat více než jednu skupinu, takže změna skupiny získané přes jednu sérii nemusí nutně změnit všechny série v grafu.

**Obsahuje nově vytvořený graf výchozí data?**

Ano. Ve výchozím nastavení metoda [ShapeCollection.addChart](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapecollection/#addChart) vytvoří vzorové série, kategorie a hodnoty. Tyto buňky můžete upravit nebo před přidáním úplně vlastního datového souboru vymazat jak série, tak kolekce kategorií. Přetížení může také vytvořit graf bez výchozích dat.

**Jak jsou grafické objekty napojeny na buňky sešitu?**

Názvy sérií, popisky kategorií a hodnoty datových bodů odkazují na buňky v [ChartDataWorkbook](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdataworkbook/). Změna odkazované buňky aktualizuje odpovídající prvek grafu. Při vytváření vlastních dat udržujte řádky kategorií a řádky hodnot sérií zarovnané tak, aby každý bod byl zakreslen pod zamýšlenou kategorií.

**Jak vymazat jeden bod místo celé série?**

Nastavte relevantní buňku s hodnotou na `null`, aby bod zůstal na své pozici kategorie jako prázdný bod. Používejte [ChartDataPointCollection.clear](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdatapointcollection/#clear) pouze tehdy, když chcete odstranit všechny body ze série. Pokud také odstraňujete kategorie, aktualizujte všechny série, aby jejich hodnoty zůstaly zarovnané s kolekcí kategorií.

**Jak jsou prázdné body zobrazovány?**

Výsledek závisí na typu grafu a na hodnotě nastavené pomocí [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs). Podporované grafy mohou zobrazovat prázdná místa jako mezery, jako nulové hodnoty nebo spojením sousedních bodů. Vyberte nastavení, které odpovídá významu chybějících dat ve vaší prezentaci. Viz **Řízení zobrazení prázdných buněk** pro kompletní příklad a vizuální srovnání.

**Jak jsou formátovány záporné hodnoty?**

U podporovaných sloupcových, pruhových a bublinových sérií zavolejte [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) a nastavte barvu vrácenou metodou [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Chování můžete přepsat pro jednotlivý bod pomocí [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Tyto metody ovlivňují formátování, nikoli uložené číselné hodnoty.

**Které formátování má přednost, když je série i bod formátován?**

Explicitní formátování datového bodu má přednost pro tento bod. Ostatní body nadále používají explicitní formát série nebo, pokud formát série není definován, automatický styl a motiv grafu. Skupinová nastavení jako překrytí a šířka mezery řídí rozložení a nejsou přepisovány na úrovni bodu.

**Existuje limit počtu sérií, které může graf obsahovat?**

Aspose.Slides neukládá pevný limit počtu sérií. V praxi omezují velikost souboru prezentace, dostupná paměť, doba vykreslování a čitelnost grafu.

**Co změnit, když jsou sloupce příliš blízko nebo příliš daleko od sebe?**

Zavolejte [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) na příslušnou nadřazenou skupinu sérií. Zvýšením hodnoty rozšíříte prostor mezi skupinami, snížením jej přiblížíte.