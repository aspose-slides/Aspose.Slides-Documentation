---
title: Správa pracovních sešitů grafů v prezentacích pomocí JavaScriptu
linktitle: Pracovní sešit grafu
type: docs
weight: 70
url: /cs/nodejs-java/chart-workbook/
keywords:
- pracovní sešit grafu
- data grafu
- buňka pracovního sešitu
- popisek dat
- list
- zdroj dat
- externí pracovní sešit
- externí data
- vyrovnávací paměť grafu
- obnovení pracovního sešitu
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Objevte Aspose.Slides pro Node.js přes Java: snadno spravujte pracovní sešity grafů ve formátech PowerPoint a OpenDocument a zefektivněte data své prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s grafickými sešity v Aspose.Slides. Ukazuje, jak číst a zapisovat data grafu prostřednictvím streamů sešitu, používat buňky sešitu jako popisky dat grafu, přistupovat ke kolekcím listů a specifikovat typ zdroje dat pro hodnoty grafu.

Také se zabývá používáním externích sešitů jako zdrojů dat pro grafy. Příklady demonstrují, jak vytvořit a přiřadit externí sešit, získat cestu k externímu sešitu propojenému s grafem a upravit data grafu, když je sešit k dispozici.

Pro buňky sešitu, které představují chybějící data, viz [Kontrola zobrazování prázdných buněk](/slides/cs/nodejs-java/chart-series/) pro rozdíl mezi prázdnou buňkou a nulou a porovnání čárových grafů dostupných režimů zobrazení.

## **Zahrnout data z skrytých řádků a sloupců**

Použijte [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setplotvisiblecellsonly/) k řízení, zda graf vykresluje data ze skrytých řádků a sloupců listu. Nastavte na `true`, aby se vykreslovaly jen viditelné buňky, nebo na `false`, aby se zahrnovaly jak viditelné, tak skryté buňky. Toto nastavení řídí vykreslování grafu; neskrývá ani neodkrývá řádky nebo sloupce listu.

[ukázková prezentace](hidden-source-data.pptx) obsahuje sloupcový graf jako první objekt na první snímku. Vložený list, `Sheet1`, obsahuje následující zdrojový rozsah `A1:C4`. Řádek 3 a sloupec C jsou skryté, ale jejich buňky stále obsahují hodnoty.

| Řádek listu | A: Měsíc | B: Maloobchod | C: Velkoobchod (skrytý sloupec) |
| --- | --- | --- | --- |
| 2 | leden | 10 | 30 |
| 3 (skrytý řádek) | únor | 40 | 60 |
| 4 | březen | 20 | 50 |

Přistupujte ke zdrojovým buňkám přes [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) a čtěte [ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/ishidden/) pro kontrolu jejich skrytého stavu. Tato metoda vrací skrytý stav, aniž by jej měnila. V tomto souboru je B2 viditelná, B3 patří do skrytého řádku a C2 do skrytého sloupce; příklad vypíše `false`, `true` a `true`.

Pro tento příklad obnovte data grafu po změně nastavení vykreslování: zachovejte vložený sešit pomocí [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) a načtěte jej znovu pomocí [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/). Při zahrnování všech buněk také použijte [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) k obnovení kompletního rozsahu, včetně skryté únorové kategorie. Pouze změna příznaku nestačí k obnovení kešovaných dat grafu a popisků kategorií v tomto příkladu. Příklad převádí vrácený buffer Node.js na pole bajtů Java před předáním do zápisové metody.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("hidden-source-data.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const workbook = chart.getChartData().getChartDataWorkbook();
        console.log("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        console.log("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        console.log("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        const workbookBuffer = chart.getChartData().readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);
        for (const visibleOnly of [true, false]) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

                // Obnovte data grafu z vloženého pracovního sešitu.
                chart.getChartData().writeWorkbookStream(workbookData);
                if (!visibleOnly) {
                    // Obnovte úplný zdrojový rozsah, včetně skrytých kategorií.
                    chart.getChartData().setRange("Sheet1!$A$1:$C$4");
                }

                presentation.save("hidden_cells_" + visibleOnly + ".pptx", aspose.slides.SaveFormat.Pptx);
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Příklad uloží dvě verze prezentace: jednu s pouze viditelnými hodnotami maloobchodu (10 a 20) a druhou se všemi šesti hodnotami. Obrázky níže ilustrují dva režimy vykreslování. Řádek 3 a sloupec C zůstávají skryté v obou vložených sešitech.

| Pouze viditelné buňky (`true`) | Všechny buňky (`false`) |
| --- | --- |
| ![Pouze viditelné buňky: hodnoty maloobchodu 10 a 20 pro leden a březen.](hidden_cells_True.png) | ![Všechny buňky: hodnoty maloobchodu a velkoobchodu pro leden, únor a březen.](hidden_cells_False.png) |

Skrytá buňka obsahující hodnotu se liší od prázdné buňky. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) řídí, jak jsou zobrazovány chybějící hodnoty; nezahrnuje ani nevynechává skryté zdrojové údaje. Viz [Kontrola zobrazování prázdných buněk](/slides/cs/nodejs-java/chart-series/#control-the-display-of-empty-cells) pro příklad.

## **Získání rozsahu dat grafu**

Před aktualizací dat sešitu v existující prezentaci zkontrolujte zdrojové rozsahy, abyste zjistili, které buňky listu používá konkrétní graf. Metoda [ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getrange/) vrací aktuální datový rozsah jako vzorec kvalifikovaný listem, např. `Sheet1!$A$1:$D$5`. Zde `Sheet1` je název listu, `!` jej odděluje od rozsahu buněk a `$A$1:$D$5` určuje buňky A1 až D5 včetně. Znak `$` označuje absolutní odkazy na řádky a sloupce.

Metoda načte aktuální rozsah, aniž by měnila graf nebo jeho sešit. Pokud graf nepoužívá sešit jako zdroj dat, vyvolá `InvalidOperationException`. Další informace najdete v [ChartData API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/).

Tento příklad otevře prezentaci a přímo na každém snímku prozkoumá objekty, zda jsou grafy. Vypíše název každého grafu a jeho zdrojový rozsah. Pokud graf nepoužívá sešit, vypíše zprávu a pokračuje dalším grafem.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                const chart = shape;
                try {
                    const range = chart.getChartData().getRange();
                    console.log(chart.getName() + ": " + range);
                } catch (exception) {
                    if (exception.cause && java.instanceOf(exception.cause, "com.aspose.slides.exceptions.InvalidOperationException")) {
                        console.log(chart.getName() + ": The chart does not use a workbook as its data source.");
                    } else {
                        console.log(chart.getName() + ": Could not retrieve the data range: " + exception.message);
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Čtení a zápis dat grafu z pracovního sešitu**

Aspose.Slides for Node.js via Java poskytuje metody [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) a [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/), které umožňují číst a zapisovat sešity s daty grafu (obsahující data upravená pomocí Aspose.Cells). **Poznámka**: data grafu musí být uspořádána stejným způsobem nebo mít strukturu podobnou zdroji.

Tento příklad používá prezentaci s grafem jako první objekt na první snímku. Načte vložený sešit do pole bajtů, vymaže existující řady a kategorie a zapíše stejný sešit zpět. Změny zůstanou v paměti; příklad prezentaci neukládá.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Ověření rozvržení grafu po úpravě pracovního sešitu**

Když nahradíte vložený sešit upraveným, graf si zachová původní kolekce řad a kategorií. Tento nesoulad může způsobit selhání [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) s chybou indexu mimo rozsah. Před zápisem aktualizovaného sešitu vyčistěte existující řady a kategorie. Tento příklad používá graf, který je prvním objektem na první snímku. Komentář označuje místo, kde by probíhala úprava sešitu; spustitelný příklad zapisuje zpět originální sešit a ověřuje rozvržení v paměti.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        // Upravte bajty pracovního sešitu zde, například pomocí Aspose.Cells.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Vyčištění kolekcí odstraní zastaralé odkazy na data před zápisem sešitu zpět. Před použitím grafu přestavte potřebné mapování řad a kategorií pro aktualizovaný sešit.

## **Nastavení vlastních číselných formátů pro buňky pracovního sešitu**

Použijte [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) k řízení, jak se číselné hodnoty zobrazují ve vloženém sešitu grafu. Například zpráva může potřebovat zobrazit konverzní poměr jako procenta se čtyřmi desetinnými místy a koeficient s pěti desetinnými místy. Uchovejte obě hodnoty jako číselné, aby zůstaly použitelné pro výpočty a vykreslování grafu.

Číselný formát mění jen zobrazení, ne uloženou hodnotu. Formát `0.0000%` zobrazí `0.125` jako `12,5000%`; nenahrazuje uložené číslo `12,5`. Podobně `0.00000` zobrazí `0.1234567` jako `0.12346` bez zaokrouhlení uložené hodnoty. Pokud je vlastní formát prázdný řetězec (`""`), použije se formát vrácený metodou [getPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/getpresetnumberformat/).

Následující příklad vytvoří sloupcový graf a přistoupí k jeho buňkám pomocí [getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/). V listu 0 obsahuje B2 konverzní poměr a C2 koeficient. Obě buňky dodávají hodnoty grafu. Příklad také povolí popisky hodnot odkazované na zdrojové formáty.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 270, aspose.slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 20, 620, 210);
    chart.setTitle(false);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00");
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(0);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const categoryCell = workbook.getCell(0, "A2", "Sample");
    chart.getChartData().getCategories().add(categoryCell);

    const percentageCell = workbook.getCell(0, "B2", 0.125);
    percentageCell.setCustomNumberFormat("0.0000%");
    const percentageName = workbook.getCell(0, "B1", "Conversion rate");
    const percentageSeries = chart.getChartData().getSeries().add(percentageName, chart.getType());
    percentageSeries.getDataPoints().addDataPointForBarSeries(percentageCell);

    const precisionCell = workbook.getCell(0, "C2", 0.1234567);
    precisionCell.setCustomNumberFormat("0.00000");
    const precisionName = workbook.getCell(0, "C1", "Coefficient");
    const precisionSeries = chart.getChartData().getSeries().add(precisionName, chart.getType());
    precisionSeries.getDataPoints().addDataPointForBarSeries(precisionCell);

    for (let seriesIndex = 0; seriesIndex < chart.getChartData().getSeries().size(); seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const labelFormat = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(true);
    }

    presentation.save("CustomCellFormats.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Formáty buněk sešitu jsou oddělené od formátů nastavených přímo na osách grafu nebo popiscích dat. V tomto příkladu každý popisek zobrazuje hodnotu zdrojové buňky, protože [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) je nastaveno na `true`, a následuje zdrojový číselný formát, protože [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) je nastaveno na `true`. Po uložení a opětovném otevření prezentace popisky zobrazí `12,5000%` a `0,12346`, jak je znázorněno níže. Vertikální osa používá vlastní číselný formát nastavený pomocí [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) na `0.00`, přičemž [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) je nastaveno na `false`.

Pro nezávislé formátování popisku nastavte jeho příznak odkazování na zdroj na `false` a přiřaďte formát pomocí [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/). Tím se nezmění formát buňky sešitu. Například nezávislý formát popisku `0.00` zobrazí první hodnotu jako `0,13`, zatímco B2 stále ukazuje `12,5000%`. Viz [Chart Data Labels](/slides/cs/nodejs-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) pro přímé formátování popisků.

![Sloupcový graf s etiketami odkazujícími na zdroj, zobrazující 12,5000 % a 0,12346 a samostatně formátovanou číselnou osou.](custom-cell-formats.png)

## **Nastavení buňky pracovního sešitu jako popisku dat grafu**

Můžete použít text z buněk sešitu jako popisky dat grafu.

Tento příklad přidá bublinový graf s výchozími daty na první snímek existující prezentace. Použije buňky A10:A12 v listu 0 pro první tři popisky první řady, povolí popisky z buněk a uloží aktualizovanou prezentaci.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("chart2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    const series = chart.getChartData().getSeries().get_Item(0);
    const workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Správa listů**

Metoda [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getworksheets/) poskytuje přístup k listům v pracovním sešitu grafu. Tento příklad vytvoří koláčový graf s výchozími daty a vypíše název každého listu do konzole.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    const workbook = chart.getChartData().getChartDataWorkbook();

    for (let i = 0; i < workbook.getWorksheets().size(); i++) {
        console.log(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **Určení typu zdroje dat**

Hodnoty bodů řady mohou být také uloženy přímo jako číselné literály. Viz [Nastavení hodnot řad pomocí číselných literálů](/slides/cs/nodejs-java/chart-series/#set-series-values-using-numeric-literals) pro kompletní příklad, který je ukládá a čte. Typ zdroje hodnot bodů je oddělený od interní nebo externí konfigurace sešitu grafu; použití číselných literálů samo o sobě neodstraňuje vložený sešit.

Tento příklad vytvoří 3D sloupcový graf s výchozími daty a nastaví dva názvy řad pomocí různých zdrojů dat. První název používá řetězcový literál; druhý používá buňku C1 v listu 0. Výčtový typ [DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) vybírá zdroj pro každý název. Příklad uloží prezentaci s aktualizovanými názvy řad.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    const literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    const cellName = chart.getChartData().getSeries().get_Item(1).getName();
    const nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(aspose.slides.DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Detekce nepodporovaných formátů vložených pracovních sešitů**

Aspose.Slides nepodporuje formát binárního Excel sešitu (.xlsb), který může být vložen v některých grafech. Můžete použít metodu `getEmbeddedWorkbookType` na [ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) spolu s výčtem [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/) k detekci nepodporovaných formátů a přeskočit tyto grafy. Tento příklad prozkoumá objekty na první snímku existující prezentace, přeskočí ne‑grafické objekty a pro každý graf s vloženým .xlsb sešitem vypíše diagnostickou zprávu.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (!(java.instanceOf(shape, "com.aspose.slides.IChart"))) {
            continue;
        }

        const chart = shape;
        const chartData = chart.getChartData();
        const isInternalWorkbook = chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook;
        const isBinaryMacro = chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            console.log("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // Přečtěte nebo upravte podporovaná data pracovního sešitu grafu zde.
    }
} finally {
    presentation.dispose();
}
```

## **Externí pracovní sešit**

Aspose.Slides podporuje použití externích sešitů jako zdroje dat pro grafy.

### **Vytvoření externího pracovního sešitu**

Použijte [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) a [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) k exportu vloženého sešitu grafu do souboru a propojení grafu s tímto externím sešitem.

Tento příklad vytvoří koláčový graf s výchozími daty a exportuje jeho sešit. Dokončí zápis souboru před přiřazením externího sešitu jako zdroje dat grafu, poté uloží propojenou prezentaci.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");
const fileSystem = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    const workbookPath = path.resolve("externalWorkbook1.xlsx");
    const workbookData = chart.getChartData().readWorkbookStream();
    try {
        fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
        chart.getChartData().setExternalWorkbook(workbookPath);
        
        presentation.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
    } catch (exception) {
        console.log("Could not write the external workbook: " + exception.message);
    }
} finally {
    presentation.dispose();
}
```

### **Nastavení externího pracovního sešitu**

Pomocí metody [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) můžete přiřadit externí sešit grafu jako jeho zdroj dat. Tato metoda může být také použita k aktualizaci cesty k externímu sešitu (pokud byl přesunut).

I když nemůžete upravovat data v sešitech uložených na vzdálených místech nebo v zdrojích, můžete je stále používat jako externí zdroj dat. Pokud je zadána relativní cesta k externímu sešitu, automaticky se převede na úplnou cestu.

Tento příklad používá externí sešit, jehož list pojmenovaný `Sheet1` obsahuje název řady v B1, názvy kategorií v A2:A4 a číselné hodnoty v B2:B4. Příklad vytvoří koláčový graf, propojí sešit a použije [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) k mapování A1:B4 na jednu řadu a tři kategorie. Uloží prezentaci s propojeným grafem.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    const chartData = chart.getChartData();
    const workbookPath = path.resolve("externalWorkbook.xlsx");

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Parametr `updateChartData` metody [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) řídí, zda je sešit načten.

* Když je `updateChartData` `false`, aktualizuje se jen cesta k sešitu. Data grafu nejsou načtena ani aktualizována ze cílového sešitu, takže sešit může být nedostupný.
* Když je `updateChartData` `true`, data grafu jsou aktualizována ze cílového sešitu.

Následující příklad přiřadí zástupnou URL s `updateChartData` nastaveným na `false`. Zachová výchozí data koláčového grafu a uloží prezentaci bez načtení nedostupného sešitu.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Získání cesty k externímu pracovního sešitu datového zdroje grafu**

Chcete‑li zjistit, který sešit je k grafu připojen, zkontrolujte, zda graf používá externí zdroj dat, a získejte jeho cestu.

Tento příklad prozkoumá první objekt na prvním snímku prezentace s propojeným externím sešitem. Pokud jde o graf propojený s externím sešitem, vypíše [getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) do konzole. Poté uloží kopii prezentace.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("externalWorkbook.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
            console.log(chartData.getExternalWorkbookPath());
        } else {
            console.log("The chart does not use an external workbook.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Úprava dat grafu**

Můžete upravovat data v externích sešitech stejným způsobem, jako provádíte změny v obsahu interních sešitů. Když externí sešit nelze načíst, vyvolá se výjimka.

Tento příklad používá graf, který je prvním objektem na prvním snímku a je propojen s přístupným externím sešitem. Nastaví hodnotu buňky pro první datový bod první řady na 100 a uloží aktualizovanou prezentaci. Úprava hodnot buněk může aktualizovat propojený externí soubor XLSX, proto použijte kopii, pokud potřebujete zachovat originální sešit.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            const valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
            } else {
                console.log("The first data point is not linked to a workbook cell.");
            }
        } else {
            console.log("The chart has no data points to edit.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Obnovení pracovního sešitu z vyrovnávací paměti grafu**

Pokud graf používá externí sešit, který chybí nebo není dostupný, může Aspose.Slides rekonstruovat sešit grafu z dat uložených v cache prezentace. Vytvořte [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/), zavolejte [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setspreadsheetoptions/) a nastavte [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) na `true` před otevřením prezentace.

Následující JavaScriptový příklad obnoví data sešitu pro graf, který je prvním objektem na prvním snímku a odkazuje na nedostupný externí sešit. Přistupuje k obnoveným datům přes [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getchartdata/) a [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // Přečtěte nebo upravte obnovená data pracovního sešitu zde.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Pokud je externí sešit nedostupný a obnovení je vypnuté, Aspose.Slides vyvolá výjimku. Povolit obnovení použijte pouze v případech, kdy je použití kešovaných dat grafu přijatelné, protože cache nemusí obsahovat změny provedené v externím sešitu po poslední aktualizaci prezentace.

## **Často kladené otázky**

**Mohu zjistit, zda je konkrétní graf propojen s externím nebo vloženým pracovním sešitem?**

Ano. Graf má [typ zdroje dat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) a [cestu k externímu pracovního sešitu](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); pokud je zdroj externí sešit, můžete přečíst úplnou cestu a ověřit, že je používán externí soubor.

**Jsou podporovány relativní cesty k externím sešitům a jak jsou ukládány?**

Ano. Pokud zadáte relativní cestu, automaticky se převede na absolutní. Prezentace ukládá absolutní cestu v souboru PPTX, takže přesunutí sešitu může vyžadovat aktualizaci odkazu.

**Mohu používat sešity umístěné na síťových zdrojích/ sdílených úložištích?**

Ano, takové sešity lze použít jako externí zdroj dat. Úprava vzdálených sešitů přímo z Aspose.Slides však není podporována – lze je použít pouze jako zdroj.

**Přepisuje Aspose.Slides při uložení prezentace externí XLSX?**

Prezentace ukládá [odkaz na externí soubor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/). Úprava hodnot grafu uložených v buňkách může také aktualizovat propojený lokální soubor XLSX. Použijte kopii sešitu, pokud musí originál zůstat beze změny.

**Co dělat, když je externí soubor chráněn heslem?**

Aspose.Slides nepřijímá heslo při vytváření odkazu. Obvyklý přístup je odstranit ochranu předem nebo připravit dešifrovanou kopii (např. pomocí [Aspose.Cells](https://reference.aspose.com/cells/java/)) a odkázat se na tuto kopii.

**Mohou více grafů odkazovat na stejný externí sešit?**

Ano. Každý graf ukládá svůj vlastní odkaz. Pokud všechny ukazují na stejný soubor, aktualizace tohoto souboru se projeví ve všech grafech při dalším načtení dat.