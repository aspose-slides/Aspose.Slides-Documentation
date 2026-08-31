---
title: Správa sešitů diagramů v prezentacích pomocí JavaScriptu
linktitle: Sešit diagramu
type: docs
weight: 70
url: /cs/nodejs-java/chart-workbook/
keywords:
- sešit diagramu
- data diagramu
- buňka sešitu
- popisek dat
- list
- zdroj dat
- externí sešit
- externí data
- mezipaměť diagramu
- obnovení sešitu
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Objevte Aspose.Slides pro Node.js pomocí Java: snadno spravujte sešity diagramů v formátech PowerPoint a OpenDocument a zjednodušte data vaší prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat se sešity diagramů v Aspose.Slides. Ukazuje, jak číst a zapisovat data diagramu pomocí proudů sešitu, používat buňky sešitu jako popisky dat diagramu, přistupovat ke kolekcím listů a určit typ zdroje dat pro hodnoty diagramu.

Také se zabývá používáním externích sešitů jako zdrojů dat diagramu. Příklady ukazují, jak vytvořit a přiřadit externí sešit, získat cestu k externímu sešitu propojenému s diagramem a upravit data diagramu, když je sešit dostupný.

## **Čtení a zápis dat diagramu ze sešitu**

Aspose.Slides poskytuje metody [readWorkbookStream](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) a [writeWorkbookStream](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) , které umožňují číst a zapisovat sešity dat diagramu (obsahující data diagramu upravená pomocí Aspose.Cells). **Note** že data diagramu musí být uspořádána stejným způsobem nebo mít strukturu podobnou zdroji.

Tento JavaScriptový kód demonstruje ukázkovou operaci:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var data = chart.getChartData();
    var stream = data.readWorkbookStream();
    data.getSeries().clear();
    data.getCategories().clear();
    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Ověřit rozvržení diagramu po úpravě sešitu**

Když nahradíte vložený sešit upraveným, diagram si zachová původní kolekce řad a kategorií. Tento nesoulad může způsobit selhání [Chart.validateChartLayout](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Chart#validateChartLayout--) s chybou „index-out-of-range“. Před zápisem aktualizovaného sešitu zpět do diagramu vymažte existující řady a kategorie.

```javascript
// Po úpravě proudu sešitu (např. pomocí Aspose.Cells)
var updatedWorkbook = chartData.readWorkbookStream();

// Vymazat existující odkazy na data.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Vyprázdnění kolekcí zajišťuje, že struktura dat diagramu je konzistentní s novým sešitem, což umožní `validateChartLayout` dokončit bez chyb.

## **Nastavit buňku sešitu jako popisek dat diagramu**

1. Vytvořte instanci třídy [Presentation](https://apireference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte bublinový diagram s některými daty.
1. Přistupte k řadám diagramu.
1. Nastavte buňku sešitu jako popisek dat.
1. Uložte prezentaci.

Tento JavaScriptový kód ukazuje, jak nastavit buňku sešitu jako popisek dat diagramu:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// Vytvoří instanci třídy prezentace, která představuje soubor prezentace
var pres = new aspose.slides.Presentation("chart2.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    var dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    var wb = chart.getChartData().getChartDataWorkbook();
    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));
    pres.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Správa listů**

Tento JavaScriptový kód demonstruje operaci, kde je metoda [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) použita k přístupu ke kolekci listů:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    var wb = chart.getChartData().getChartDataWorkbook();
    for (var i = 0; i < wb.getWorksheets().size(); i++) {
        console.log(wb.getWorksheets().get_Item(i).getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Určení typu zdroje dat**

Tento JavaScriptový kód ukazuje, jak určit typ pro zdroj dat:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var val = chart.getChartData().getSeries().get_Item(0).getName();
    val.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    val.setData("LiteralString");
    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Detekce nepodporovaných formátů vložených sešitů**

Aspose.Slides nepodporuje binární formát Excelu (.xlsb), který může být vložen v některých diagramech. Můžete použít metodu `getEmbeddedWorkbookType` na [ChartData](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/) spolu s výčtem [WorkbookType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/workbooktype/) k detekci nepodporovaných formátů a tyto diagramy přeskočit.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapes = slide.getShapes();

    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        let shape = shapes.get_Item(shapeIndex);

        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) continue;

        let chart = shape;
        let chartData = chart.getChartData();

        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro) {
            // Vložený sešit je ve formátu .xlsb, který není podporován.
            continue;
        }

        // Zde přečtěte nebo upravte data sešitu diagramu.
    }
} finally {
    presentation.dispose();
}
```

## **Externí sešit**

Aspose.Slides podporuje externí sešity jako zdroj dat pro diagramy.

### **Vytvořit externí sešit**

Pomocí metod **`readWorkbookStream`** a **`setExternalWorkbook`** můžete buď vytvořit externí sešit od nuly, nebo učinit interní sešit externím.

Tento JavaScriptový kód demonstruje proces vytváření externího sešitu:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fileSystem = require("fs");

var pres = new aspose.slides.Presentation();
try {
    var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    // readWorkbookStream vrací bajty sešitu jako Buffer v Node.
    var workbookData = chart.getChartData().readWorkbookStream();
    fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
    chart.getChartData().setExternalWorkbook(workbookPath);
    pres.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Nastavit externí sešit**

Metodou **`setExternalWorkbook`** můžete přiřadit externí sešit k diagramu jako jeho zdroj dat. Tuto metodu lze také použít k aktualizaci cesty k externímu sešitu (pokud byl přesunut).

Zatímco nemůžete upravovat data v sešitech uložených na vzdálených místech nebo ve zdrojích, můžete takové sešity i nadále používat jako externí zdroj dat. Pokud je zadána relativní cesta k externímu sešitu, automaticky se převede na úplnou cestu.

Tento JavaScriptový kód ukazuje, jak nastavit externí sešit:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Vytvoří instanci třídy Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, false);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("externalWorkbook.xlsx");
    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), aspose.slides.ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    pres.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Druhý parametr metody `setExternalWorkbook`, `updateChartData`, určuje, zda bude Excelový sešit načten či ne.

* Když je `updateChartData` nastaveno na `false`, aktualizuje se pouze cesta k sešitu — data diagramu nebudou načtena ani aktualizována z cílového sešitu. Toto nastavení je vhodné, pokud cílový sešit neexistuje nebo není dostupný.
* Když je `updateChartData` nastaveno na `true`, data diagramu jsou aktualizována z cílového sešitu.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Vytvoří instanci třídy Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("http://path/doesnt/exists", false);
    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Získat cestu k externímu zdroji dat diagramu**

1. Vytvořte instanci třídy [Presentation](https://apireference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
1. Získejte odkaz na snímek podle jeho indexu.
1. Vytvořte objekt pro tvar diagramu.
1. Vytvořte objekt pro typ zdroje (`ChartDataSourceType`), který představuje zdroj dat diagramu.
1. Upřesněte relevantní podmínku na základě toho, že typ zdroje je stejný jako typ externího zdroje sešitu.

Tento JavaScriptový kód demonstruje operaci:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Vytvoří instanci třídy Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var slide = pres.getSlides().get_Item(1);
    var chart = slide.getShapes().get_Item(0);
    var sourceType = chart.getChartData().getDataSourceType();
    if (sourceType == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
        var path = chart.getChartData().getExternalWorkbookPath();
    }
    // Uloží prezentaci
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Upravit data diagramu**

Data v externích sešitech můžete upravovat stejným způsobem, jako měníte obsah interních sešitů. Když nelze externí sešit načíst, je vyhozena výjimka.

Tento JavaScriptový kód je implementací popsaného postupu:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Vytvoří instanci třídy Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var chartData = chart.getChartData();
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    pres.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Obnovit sešit z mezipaměti diagramu**

Pokud diagram používá externí sešit, který chybí nebo není dostupný, Aspose.Slides může rekonstruovat sešit diagramu z dat uložených v mezipaměti prezentace. Vytvořte [LoadOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/), nakonfigurujte jej pomocí [SpreadsheetOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/spreadsheetoptions/), a zavolejte [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) s hodnotou `true` před otevřením prezentace.

Následující JavaScriptový příklad otevírá prezentaci, jejíž diagram odkazuje na nedostupný externí sešit, a přistupuje k obnoveným datům pomocí [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Zde přečtěte nebo upravte obnovená data sešitu.
} finally {
    presentation.dispose();
}
```

Pokud je externí sešit nedostupný a obnova je vypnuta, Aspose.Slides vyhodí výjimku. Zapněte obnovu jen tehdy, když je použití dat z mezipaměti přijatelnou náhradou, protože mezipaměť nemusí obsahovat změny provedené v externím sešitu po poslední aktualizaci prezentace.

## **FAQ**

**Mohu zjistit, zda je konkrétní diagram spojen s externím nebo vloženým sešitem?**

Ano. Diagram má [typ zdroje dat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) a [cestu k externímu sešitu](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); pokud je zdroj externí sešit, můžete přečíst úplnou cestu a ověřit, že je použito externí soubor.

**Jsou relativní cesty k externím sešitům podporovány a jak jsou uloženy?**

Ano. Pokud zadáte relativní cestu, automaticky se převede na absolutní cestu. To je výhodné pro přenositelnost projektu; buďte však vědomi, že prezentace uloží absolutní cestu v souboru PPTX.

**Lze použít sešity umístěné na síťových zdrojích/ sdíleních?**

Ano, takové sešity mohou být použity jako externí zdroj dat. Úprava vzdálených sešitů přímo z Aspose.Slides však není podporována — lze je použít jen jako zdroj.

**Přepíše Aspose.Slides externí soubor XLSX při ukládání prezentace?**

Ne. Prezentace ukládá [odkaz na externí soubor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) a používá jej pro čtení dat. Externí soubor samotný není při ukládání prezentace modifikován.

**Co mám dělat, když je externí soubor chráněn heslem?**

Aspose.Slides neakceptuje heslo při vytváření odkazu. Obvyklý postup je odstranit ochranu předem nebo připravit dešifrovanou kopii (například pomocí [Aspose.Cells](/cells/nodejs-java/)) a odkazovat na tuto kopii.

**Mohou více diagramů odkazovat na stejný externí sešit?**

Ano. Každý diagram ukládá svůj vlastní odkaz. Pokud všechny ukazují na stejný soubor, aktualizace tohoto souboru se projeví v každém diagramu při dalším načtení dat.