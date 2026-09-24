---
title: Spravujte sešity grafů v prezentacích pomocí JavaScriptu
linktitle: Sešit grafu
type: docs
weight: 70
url: /cs/nodejs-java/chart-workbook/
keywords:
- sešit grafu
- data grafu
- buňka sešitu
- popisek dat
- list
- zdroj dat
- externí sešit
- externí data
- mezipaměť grafu
- obnovení sešitu
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Objevte Aspose.Slides pro Node.js pomocí Javy: snadno spravujte sešity grafů v PowerPoint a OpenDocument formátech a zjednodušte data vaší prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s sešity grafů v Aspose.Slides. Ukazuje, jak číst a zapisovat data grafu pomocí streamů sešitu, používat buňky sešitu jako popisky dat grafu, přistupovat k kolekcím listů a specifikovat typ zdroje dat pro hodnoty grafu.

Také se zabývá prací s externími sešity jako zdroji dat pro grafy. Příklady ukazují, jak vytvořit a přiřadit externí sešit, získat cestu k externímu sešitu propojenému s grafem a upravit data grafu, když je sešit k dispozici.

Pro buňky sešitu, které představují chybějící data, viz [Řízení zobrazení prázdných buněk](/slides/cs/nodejs-java/chart-series/) pro rozdíl mezi prázdnou buňkou a nulou a srovnání režimů zobrazení v čárovém grafu.

## **Čtení a zápis dat grafu ze sešitu**

Aspose.Slides poskytuje metody [readWorkbookStream](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) a [writeWorkbookStream](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) , které umožňují číst a zapisovat sešity dat grafu (obsahující data grafu upravená pomocí Aspose.Cells). **Poznámka** že data grafu musí být uspořádána stejným způsobem nebo musí mít strukturu podobnou zdroji.

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

### **Ověření rozvržení grafu po úpravě sešitu**

Když nahradíte vložený sešit upraveným, graf si ponechá své původní kolekce řad a kategorií. Toto nesoulad může způsobit, že [Chart.validateChartLayout](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Chart#validateChartLayout--) selže s chybou indexu mimo rozsah. Vymažte existující řady a kategorie před tím, než zapíšete aktualizovaný sešit zpět do grafu.

```javascript
// Po úpravě streamu sešitu (např. pomocí Aspose.Cells)
var updatedWorkbook = chartData.readWorkbookStream();

// Vymazat existující odkazy na data.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Vymazání kolekcí zajistí, že struktura dat grafu bude konzistentní s novým sešitem, což umožní, aby `validateChartLayout` dokončil bez chyb.

## **Nastavení buňky sešitu jako popisek dat grafu**

1. Vytvořte instanci třídy [Presentation](https://apireference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation) .
2. Získejte referenci snímku pomocí jeho indexu.
3. Přidejte bublinový graf s některými daty.
4. Přistupte k řadám grafu.
5. Nastavte buňku sešitu jako popisek dat.
6. Uložte prezentaci.

Tento JavaScriptový kód ukazuje, jak nastavit buňku sešitu jako popisek dat grafu:

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

Tento JavaScriptový kód demonstruje operaci, při které se používá metoda [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) k přístupu ke kolekci listů:

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

Tento JavaScriptový kód ukazuje, jak specifikovat typ pro zdroj dat:

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

## **Detekce nepodporovaných vložených formátů sešitů**

Aspose.Slides nepodporuje binární formát Excel sešitu (.xlsb), který může být vložen v některých grafech. Můžete použít metodu `getEmbeddedWorkbookType` na [ChartData](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/) spolu s výčtem [WorkbookType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/workbooktype/), abyste detekovali nepodporované formáty a takové grafy přeskočili.

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

        // Zde přečtěte nebo upravte data sešitu grafu.
    }
} finally {
    presentation.dispose();
}
```

## **Externí sešit**

Aspose.Slides podporuje externí sešity jako zdroj dat pro grafy.

### **Vytvoření externího sešitu**

Pomocí metod **`readWorkbookStream`** a **`setExternalWorkbook`** můžete buď vytvořit externí sešit od nuly, nebo učinit interní sešit externím.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fileSystem = require("fs");

var pres = new aspose.slides.Presentation();
try {
    var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    // readWorkbookStream vrací bajty sešitu jako Node Buffer.
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

### **Nastavení externího sešitu**

Pomocí metody **`setExternalWorkbook`** můžete přiřadit externí sešit grafu jako jeho zdroj dat. Tato metoda může být také použita k aktualizaci cesty k externímu sešitu (pokud byl přesunut).

Ačkoliv nemůžete upravovat data v sešitech uložených na vzdálených místech nebo zdrojích, můžete takové sešity stále použít jako externí zdroj dat. Pokud je zadána relativní cesta k externímu sešitu, automaticky se převede na úplnou cestu.

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

Druhý parametr metody `setExternalWorkbook`, `updateChartData`, určuje, zda bude Excel sešit načten nebo ne.

* Když je `updateChartData` nastaven na `false`, aktualizuje se pouze cesta k sešitu – data grafu nebudou načtena ani aktualizována z cílového sešitu. Toto nastavení můžete použít v situaci, kdy cílový sešit neexistuje nebo není dostupný.
* Když je `updateChartData` nastaven na `true`, data grafu se aktualizují z cílového sešitu.

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

### **Získání cesty k externímu sešitu zdroje dat grafu**

1. Vytvořte instanci třídy [Presentation](https://apireference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation) .
2. Získejte referenci snímku pomocí jeho indexu.
3. Vytvořte objekt pro tvar grafu.
4. Vytvořte objekt pro typ zdroje (`ChartDataSourceType`), který představuje zdroj dat grafu.
5. Specifikujte relevantní podmínku na základě toho, že typ zdroje je stejný jako typ externího sešitu.

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

### **Úprava dat grafu**

Data v externích sešitech můžete upravovat stejným způsobem, jako měníte obsah interních sešitů. Když externí sešit nelze načíst, je vyvolána výjimka.

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

### **Obnovení sešitu z mezipaměti grafu**

Pokud graf používá externí sešit, který chybí nebo není dostupný, Aspose.Slides může rekonstruovat sešit grafu z dat uložených v mezipaměti prezentace. Vytvořte [LoadOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/), nakonfigurujte jej pomocí [SpreadsheetOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/spreadsheetoptions/), a zavolejte [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) s `true` před otevřením prezentace.

Následující JavaScriptový příklad otevírá prezentaci, jejíž graf odkazuje na nedostupný externí sešit, a přistupuje k obnoveným datům pomocí [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

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

    // Zde přečtěte nebo upravte data obnoveného sešitu.
} finally {
    presentation.dispose();
}
```

Pokud je externí sešit nedostupný a obnovení je vypnuté, Aspose.Slides vyvolá výjimku. Povolit obnovení byste měli pouze tehdy, když je použití dat z mezipaměti grafu přijatelným řešením, protože mezipaměť nemusí obsahovat změny provedené v externím sešitu po poslední aktualizaci prezentace.

## **Často kladené otázky**

**Mohu zjistit, zda je konkrétní graf propojen s externím nebo vloženým sešitem?**

Ano. Graf má [typ zdroje dat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) a [cestu k externímu sešitu](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); pokud je zdroj externí sešit, můžete přečíst úplnou cestu a ověřit, že je používán externí soubor.

**Jsou relativní cesty k externím sešitům podporovány a jak jsou uloženy?**

Ano. Pokud zadáte relativní cestu, automaticky se převede na absolutní cestu. To je výhodné pro přenositelnost projektu; však mějte na vědomí, že prezentace uloží absolutní cestu v souboru PPTX.

**Mohu používat sešity umístěné na síťových zdrojích/sdílených složkách?**

Ano, takové sešity mohou být použity jako externí zdroj dat. Úpravy vzdálených sešitů přímo z Aspose.Slides však nejsou podporovány – mohou být použity pouze jako zdroj.

**Přepisuje Aspose.Slides externí XLSX při ukládání prezentace?**

Ne. Prezentace uloží [odkaz na externí soubor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) a používá jej k načítání dat. Samotný externí soubor není při uložení prezentace upravován.

**Co mám dělat, pokud je externí soubor chráněn heslem?**

Aspose.Slides neakceptuje heslo při propojení. Běžný postup je odstranit ochranu předem nebo připravit dešifrovanou kopii (například pomocí [Aspose.Cells](/cells/nodejs-java/)) a odkazovat na tuto kopii.

**Mohou více grafů odkazovat na stejný externí sešit?**

Ano. Každý graf ukládá svůj vlastní odkaz. Pokud všechny odkazují na stejný soubor, jeho aktualizace se projeví v každém grafu při příštím načtení dat.