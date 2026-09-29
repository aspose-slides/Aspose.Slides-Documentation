---
title: Správa pracovních sešitů grafů v prezentacích pomocí JavaScriptu
linktitle: Grafický pracovní sešit
type: docs
weight: 70
url: /cs/nodejs-java/chart-workbook/
keywords:
- pracovní sešit grafu
- data grafu
- buňka pracovního sešitu
- popisek dat
- list
- datový zdroj
- externí sešit
- externí data
- mezipaměť grafu
- obnova pracovního sešitu
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Objevte Aspose.Slides for Node.js via Java: snadno spravujte grafické pracovní sešity v formátech PowerPoint a OpenDocument a zefektivněte data vaší prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s grafickými sešity v Aspose.Slides. Ukazuje, jak číst a zapisovat data grafu pomocí streamů sešitu, používat buňky sešitu jako popisky dat grafu, přistupovat ke kolekcím listů a specifikovat typ datového zdroje pro hodnoty grafu.

Také se zabývá používáním externích sešitů jako datových zdrojů pro grafy. Příklady ukazují, jak vytvořit a přiřadit externí sešit, získat cestu k externímu sešitu propojenému s grafem a upravit data grafu, když je sešit k dispozici.

Pro buňky sešitu, které představují chybějící data, viz [Control the Display of Empty Cells](/slides/cs/nodejs-java/chart-series/) pro rozdíl mezi prázdnou buňkou a nulou a pro srovnání lineárního grafu dostupných režimů zobrazení.

## **Zahrnout data z skrytých řádků a sloupců**

Použijte [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chart/#setPlotVisibleCellsOnly) k ovládání, zda graf vykresluje data ze skrytých řádků a sloupců listu. Nastavte jej na `true`, aby byly vykresleny jen viditelné buňky, nebo na `false`, aby byly zahrnuty jak viditelné, tak skryté buňky. Toto nastavení řídí vykreslování grafu; nehideuje ani neodkrývá řádky či sloupce listu.

Stáhněte [hidden-source-data.pptx](hidden-source-data.pptx) a umístěte jej do pracovního adresáře. Jeho první snímek obsahuje sloupcový graf jako první tvar. Vložení listu `Sheet1` obsahuje následující zdrojový rozsah `A1:C4`. Řádek 3 a sloupec C jsou skryté, ale jejich buňky stále obsahují hodnoty.

| Řádek listu | A: Měsíc | B: Maloobchod | C: Velkoobchod (skrytý sloupec) |
| --- | --- | --- | --- |
| 2 | leden | 10 | 30 |
| 3 (skrytý řádek) | únor | 40 | 60 |
| 4 | březen | 20 | 50 |

Přistupujte ke zdrojovým buňkám pomocí [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) a čtěte [ChartDataCell.isHidden](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdatacell/#isHidden) pro kontrolu jejich skrytého stavu. Tato metoda hlásí skrytý stav, aniž by jej měnila. V tomto souboru je B2 viditelná, B3 patří ke skrytému řádku a C2 patří ke skrytému sloupci; příklad vypíše `false`, `true` a `true`.

Pro tento příklad obnovte data grafu po změně nastavení vykreslování: zachovejte vložený sešit pomocí [readWorkbookStream](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) a načtěte jej znovu pomocí [writeWorkbookStream](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream). Při zahrnutí všech buněk také použijte [setRange](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/#setRange) k obnovení kompletního rozsahu, včetně skryté kategorie únor. Pouhé změnění příznaku není dostačující k obnovení mezipaměti dat grafu a popisků kategorií v tomto vzorku. Příklad převádí vrácený Node.js buffer na pole bajtů Java před předáním do zápisové metody.

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

                // Obnovit data grafu z vloženého pracovního sešitu.
                chart.getChartData().writeWorkbookStream(workbookData);
                if (!visibleOnly) {
                    // Obnovit celý zdrojový rozsah, včetně skrytých kategorií.
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

Příklad ukládá `hidden_cells_true.pptx` pouze s viditelnými hodnotami Maloobchod (10 a 20) a `hidden_cells_false.pptx` se všemi šesti hodnotami. Obrázky níže ilustrují dva režimy vykreslování. Řádek 3 a sloupec C zůstávají skryté v obou vložených sešitech.

| Pouze viditelné buňky (`true`) | Všechny buňky (`false`) |
| --- | --- |
| ![Pouze viditelné buňky: Hodnoty Maloobchod 10 a 20 pro leden a březen.](hidden_cells_True.png) | ![Všechny buňky: Hodnoty Maloobchod a Velkoobchod pro leden, únor a březen.](hidden_cells_False.png) |

Skrytá buňka obsahující hodnotu se liší od prázdné buňky. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) řídí, jak jsou zobrazovány chybějící hodnoty; neinkluzuje ani nevynechává skrytá zdrojová data. Viz [Control the Display of Empty Cells](/slides/cs/nodejs-java/chart-series/#control-the-display-of-empty-cells) pro příklad.

## **Čtení a zápis dat grafu z sešitu**

Aspose.Slides for Node.js via Java poskytuje metody [readWorkbookStream](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) a [writeWorkbookStream](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream), které umožňují číst a zapisovat sešity dat grafu (obsahující data grafu upravená pomocí Aspose.Cells). **Poznámka**: data grafu musí být uspořádána stejným způsobem nebo musí mít strukturu podobnou zdroji.

Tento příklad otevírá `chart.pptx`, který musí obsahovat graf jako první tvar na svém prvním snímku. Načte vložený sešit do pole bajtů, vymaže existující řady a kategorie a zapíše stejný sešit zpět. Změny zůstávají v paměti; příklad neukládá prezentaci.

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

### **Ověření rozvržení grafu po úpravě sešitu**

Když nahradíte vložený sešit upraveným, graf si ponechá své původní kolekce řad a kategorií. Tento nesoulad může způsobit selhání [Chart.validateChartLayout](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chart/#validateChartLayout) s chybou index‑out‑of‑range. Vymažte existující řady a kategorie před zápisem aktualizovaného sešitu zpět do grafu. Tento příklad vyžaduje `chart.pptx` s grafem jako první tvar na prvním snímku. Komentář označuje místo, kde by úprava sešitu proběhla; spustitelný příklad zapíše původní sešit zpět a ověří rozvržení v paměti.

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

Vymazání kolekcí odstraní zastaralé reference na data před zápisem sešitu zpět. Před použitím grafu znovu sestavte potřebné mapování řad a kategorií pro aktualizovaný sešit.

## **Nastavit buňku sešitu jako popisek dat grafu**

Můžete použít text z buněk sešitu jako popisky dat grafu. Následující kroky ukazují, jak propojit popisky v bublinovém grafu s buňkami v jeho datovém sešitu.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
2. Přistupte k prvnímu snímku podle nulového indexu.
3. Přidejte bublinový graf s výchozími daty.
4. Přistupte k řadám grafu.
5. Nastavte buňku sešitu jako popisek dat.
6. Uložte prezentaci.

Tento příklad otevírá `chart2.pptx`, který musí obsahovat alespoň jeden snímek, a přidává bublinový graf s výchozími daty. Používá buňky A10:A12 na listu 0 pro první tři popisky v první řadě, povoluje popisky z buněk a uloží výsledek do `resultchart.pptx`.

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

Metoda [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdataworkbook/#getWorksheets) poskytuje přístup k listům v sešitu grafu. Tento příklad vytvoří koláčový graf s výchozími daty a vypíše každé jméno listu do konzole.

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

## **Určení typu datového zdroje**

Tento příklad vytvoří 3D sloupcový graf s výchozími daty a nastaví dva názvy řad pomocí různých datových zdrojů. První název používá řetězcový literál; druhý používá buňku C1 na listu 0. Výčtová hodnota [DataSourceType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/datasourcetype/) vybírá zdroj pro každý název. Výsledek je uložen do `pres.pptx`.

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

## **Detekce nepodporovaných formátů vložených sešitů**

Aspose.Slides nepodporuje binární formát Excel sešitu (.xlsb), který může být vložen v některých grafech. Můžete použít metodu [getEmbeddedWorkbookType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) na [ChartData](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/) spolu s výčtem [WorkbookType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/workbooktype/) k detekci nepodporovaných formátů a přeskočení těchto grafů. Tento příklad kontroluje tvary na prvním snímku `sample.pptx`, přeskočí tvary, které nejsou grafy, a vypíše diagnostickou zprávu pro každý graf s vloženým sešitem .xlsb.

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

        // Zde přečtěte nebo upravte podporovaná data pracovního sešitu grafu.
    }
} finally {
    presentation.dispose();
}
```

## **Externí sešit**

Aspose.Slides podporuje používání externích sešitů jako datového zdroje pro grafy.

### **Vytvořit externí sešit**

Použijte [readWorkbookStream](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) a [setExternalWorkbook](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) k exportu vloženého sešitu grafu do souboru a propojení grafu s tím externím sešitem.

Tento příklad vytvoří koláčový graf s výchozími daty, zapíše jeho sešit do `externalWorkbook1.xlsx` a dokončí zápis souboru před přiřazením souboru jako datového zdroje grafu. Uloží propojenou prezentaci do `externalWorkbook.pptx`.

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

### **Nastavit externí sešit**

Použitím metody [setExternalWorkbook](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) můžete přiřadit externí sešit grafu jako jeho datový zdroj. Tuto metodu lze také použít k aktualizaci cesty k externímu sešitu (pokud byl přesunut).

I když nemůžete upravovat data v sešitech uložených na vzdálených místech nebo v zdrojích, můžete takové sešity stále použít jako externí datový zdroj. Pokud je zadána relativní cesta k externímu sešitu, automaticky se převede na úplnou cestu.

Tento příklad vyžaduje `externalWorkbook.xlsx` v pracovním adresáři. Jeho list s názvem `Sheet1` musí obsahovat název řady v B1, názvy kategorií v A2:A4 a číselné hodnoty v B2:B4. Příklad vytvoří koláčový graf, propojí sešit a použije [setRange](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/#setRange) k mapování A1:B4 na jednu řadu a tři kategorie. Výsledek uloží do `Presentation_with_externalWorkbook.pptx`.

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

Parametr `updateChartData` metody [setExternalWorkbook](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) řídí, zda je sešit načten.

* Když je `updateChartData` nastaven na `false`, aktualizuje se pouze cesta k sešitu. Data grafu nejsou načtena ani aktualizována z cílového sešitu, takže sešit může být nedostupný.
* Když je `updateChartData` nastaven na `true`, data grafu jsou aktualizována z cílového sešitu.

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

### **Získat cestu k externímu sešitu zdroje dat grafu**

Chcete‑li identifikovat sešit propojený s grafem, nejprve zjistěte, zda graf používá externí datový zdroj. Pokud ano, můžete získat cestu k sešitu podle následujících kroků.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
2. Přistupte k prvnímu snímku podle nulového indexu.
3. Zkontrolujte, že první tvar je graf.
4. Přečtěte typ datového zdroje grafu.
5. Pokud je zdroj externí sešit, přečtěte jeho cestu.

Tento příklad otevírá `externalWorkbook.pptx`, vytvořený v předchozím příkladu, a kontroluje první tvar na prvním snímku. Pokud je to graf propojený s externím sešitem, příklad vypíše [getExternalWorkbookPath](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) do konzole. Poté uloží kopii prezentace do `Result.pptx`.

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

### **Upravit data grafu**

Můžete upravit data v externích sešitech stejným způsobem, jako provádíte změny v obsahu interních sešitů. Když externí sešit nelze načíst, je vyhozena výjimka.

Tento příklad vyžaduje `presentation.pptx` s grafem jako první tvar na prvním snímku a přístupný externí sešit. Nastaví hodnotu buňky první datové bodu v první řadě na 100 a uloží prezentaci do `presentation_out.pptx`. Úprava hodnot buněk může aktualizovat propojený externí soubor XLSX, proto použijte kopii, pokud potřebujete zachovat originální sešit.

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

### **Obnovení sešitu z vyrovnávací paměti grafu**

Pokud graf používá externí sešit, který chybí nebo není dostupný, Aspose.Slides může rekonstruovat sešit grafu z dat uložených v mezipaměti prezentace. Vytvořte [LoadOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/), zavolejte [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions) a nastavte [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) na `true` před otevřením prezentace.

Následující JavaScriptový příklad otevírá `presentation.pptx`, jehož první tvar na prvním snímku musí být graf odkazující na nedostupný externí sešit, a přistupuje k obnoveným datům pomocí [Chart.getChartData](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chart/#getChartData) a [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

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

        // Prečtěte nebo upravte zde data obnoveného pracovního sešitu.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Pokud je externí sešit nedostupný a obnova je vypnuta, Aspose.Slides vyhodí výjimku. Obnovu povolte jen tehdy, když je použití dat z mezipaměti grafu přijatelnou náhradou, protože mezipaměť nemusí obsahovat změny provedené v externím sešitu po poslední aktualizaci prezentace.

## **Často kladené otázky**

**Mohu zjistit, jestli je konkrétní graf propojen s externím nebo vloženým sešitem?**

Ano. Graf má [data source type](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/#getDataSourceType) a [cestu k externímu sešitu](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath); pokud je zdroj externí sešit, můžete přečíst úplnou cestu a ujistit se, že je používán externí soubor.

**Jsou relativní cesty k externím sešitům podporovány a jak jsou uloženy?**

Ano. Pokud zadáte relativní cestu, automaticky se převede na absolutní cestu. Prezentace ukládá absolutní cestu v souboru PPTX, takže přesunutí sešitu může vyžadovat aktualizaci odkazu.

**Mohu použít sešity umístěné na síťových zdrojích/úložištích?**

Ano, takové sešity lze použít jako externí datový zdroj. Úprava vzdálených sešitů přímo z Aspose.Slides však není podporována – mohou být použity jen jako zdroj.

**Přepisuje Aspose.Slides externí XLSX při ukládání prezentace?**

Prezentace ukládá [odkaz na externí soubor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath). Úprava dat grafu založených na buňkách může také aktualizovat propojený lokální soubor XLSX. Použijte kopii sešitu, pokud musí originál zůstat nezměněn.

**Co mám dělat, když je externí soubor chráněn heslem?**

Aspose.Slides nepřijímá heslo při propojení. Běžný postup je odstranit ochranu předem nebo připravit dešifrovanou kopii (např. pomocí [Aspose.Cells](https://reference.aspose.com/cells/java/)) a odkazovat na tuto kopii.

**Mohou více grafů odkazovat na stejný externí sešit?**

Ano. Každý graf ukládá svůj vlastní odkaz. Pokud všechny odkazují na stejný soubor, aktualizace tohoto souboru se projeví ve všech grafech při dalším načtení dat.