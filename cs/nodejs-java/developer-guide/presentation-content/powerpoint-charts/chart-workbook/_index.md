---
title: Správa sešitů grafů v prezentacích pomocí JavaScriptu
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
- datový zdroj
- externí sešit
- externí data
- mezipaměť grafu
- obnovení sešitu
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Objevte Aspose.Slides pro Node.js prostřednictvím Java: snadno spravujte sešity grafů v formátech PowerPoint a OpenDocument a zjednodušte data své prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s grafickými sešity v Aspose.Slides. Ukazuje, jak číst a zapisovat data grafu přes streamy sešitu, používat buňky sešitu jako popisky dat grafu, přistupovat k kolekcím listů a určovat typ datového zdroje pro hodnoty grafu.

Také popisuje práci s externími sešity jako datovými zdroji grafu. Příklady demonstrují, jak vytvořit a přiřadit externí sešit, získat cestu k externímu sešitu propojenému s grafem a upravit data grafu, když je sešit k dispozici.

## **Číst a zapisovat data grafu ze sešitu**

Aspose.Slides poskytuje metody [readWorkbookStream](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) a [writeWorkbookStream](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) , které umožňují číst a zapisovat sešity s daty grafu (obsahující data upravená v Aspose.Cells). **Poznámka** že data grafu musí být uspořádána stejným způsobem nebo mít strukturu podobnou zdroji.

Tento JavaScriptový kód ukazuje ukázkovou operaci:

```javascript
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

## **Nastavit buňku WorkBook jako DataLabel**

1. Vytvořte instanci třídy [Presentation](https://apireference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
1. Získejte referenci snímku podle jeho indexu.
1. Přidejte bublinový graf s nějakými daty.
1. Přistupte k sériím grafu.
1. Nastavte buňku sešitu jako popisek dat.
1. Uložte prezentaci.

Tento JavaScriptový kód ukazuje, jak nastavit buňku sešitu jako popisek dat grafu:

```javascript
var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// Instancuje třídu prezentace, která představuje soubor prezentace
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

## **Spravovat listy**

Tento JavaScriptový kód demonstruje operaci, při které je použita metoda [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) k přístupu k kolekci listů:

```javascript
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

## **Zadat typ datového zdroje**

Tento JavaScriptový kód ukazuje, jak určit typ pro datový zdroj:

```javascript
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

## **Detekovat nepodporované vložené formáty sešitu**

Aspose.Slides nepodporuje formát binárního sešitu Excel (.xlsb), který může být vložen v některých grafech. K detekci nepodporovaných formátů a přeskočení takových grafů můžete použít metodu `getEmbeddedWorkbookType` na třídě [ChartData](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/) spolu s enumerací [WorkbookType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/workbooktype/).

```js
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

Aspose.Slides podporuje externí sešity jako datový zdroj pro grafy.

### **Vytvořit externí sešit**

Pomocí metod **`readWorkbookStream`** a **`setExternalWorkbook`** můžete buď vytvořit externí sešit od nuly, nebo učinit interní sešit externím.

Tento JavaScriptový kód demonstruje proces vytvoření externího sešitu:

```javascript
var pres = new aspose.slides.Presentation();
try {
    final var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    var fileStream = java.newInstanceSync("java.io.FileOutputStream", workbookPath);
    try {
        var workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
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

Pomocí metody **`setExternalWorkbook`** můžete přiřadit externí sešit k grafu jako jeho datový zdroj. Tato metoda může být také použita k aktualizaci cesty k externímu sešitu (pokud byl přesunut).

I když nemůžete upravovat data v sešitech uložených na vzdálených místech nebo prostředcích, můžete takové sešity i nadále používat jako externí datový zdroj. Pokud je zadána relativní cesta k externímu sešitu, automaticky se převede na úplnou cestu.

Tento JavaScriptový kód ukazuje, jak nastavit externí sešit:

```javascript
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

Parametr `ChartData` (v rámci metody `setExternalWorkbook`) určuje, zda bude Excel sešit načten.

* Když je hodnota `ChartData` nastavena na `false`, aktualizuje se pouze cesta k sešitu – data grafu nebudou načtena ani aktualizována ze cílového sešitu. Toto nastavení je vhodné, když cílový sešit neexistuje nebo není dostupný.
* Když je hodnota `ChartData` nastavena na `true`, data grafu se aktualizují z cílového sešitu.

```javascript
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

### **Získat cestu k externímu datovému zdroji sešitu grafu**

1. Vytvořte instanci třídy [Presentation](https://apireference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
1. Získejte referenci snímku podle jeho indexu.
1. Vytvořte objekt pro tvar grafu.
1. Vytvořte objekt pro typ zdroje (`ChartDataSourceType`), který představuje datový zdroj grafu.
1. Určete relevantní podmínku na základě toho, že typ zdroje je stejný jako typ externího datového zdroje sešitu.

Tento JavaScriptový kód demonstruje operaci:

```javascript
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

### **Upravit data grafu**

Data v externích sešitech můžete upravovat stejně jako v interních sešitech. Když externí sešit nelze načíst, je vyvolána výjimka.

Tento JavaScriptový kód je implementací popsaného postupu:

```javascript
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

### **Obnovit sešit z mezipaměti grafu**

Pokud graf používá externí sešit, který chybí nebo není dostupný, Aspose.Slides může z dat uložených v prezentaci rekonstruovat sešit grafu. Vytvořte [LoadOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/), nakonfigurujte jej pomocí [SpreadsheetOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/spreadsheetoptions/) a před otevřením prezentace zavolejte [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) s parametrem `true`.

Následující JavaScriptový příklad otevře prezentaci, jejíž graf odkazuje na nedostupný externí sešit, a přistoupí k obnoveným datům přes [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

```javascript
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

Pokud je externí sešit nedostupný a obnova je vypnuta, Aspose.Slides vyvolá výjimku. Zapněte obnovu jen tehdy, když je použití dat z mezipaměti přijatelnou náhradou, protože mezipaměť nemusí obsahovat změny provedené v externím sešitu po poslední aktualizaci prezentace.

## **FAQ**

**Mohu zjistit, zda je konkrétní graf propojen s externím nebo vloženým sešitem?**

Ano. Graf má [typ datového zdroje](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) a [ cestu k externímu sešitu](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); pokud je zdroj externí sešit, můžete přečíst úplnou cestu a ověřit, že je použita externí soubor.

**Jsou podporovány relativní cesty k externím sešitům a jak jsou uloženy?**

Ano. Pokud zadáte relativní cestu, automaticky se převede na absolutní cestu. To je výhodné pro přenositelnost projektu; však buďte si vědomi, že prezentace uloží absolutní cestu v souboru PPTX.

**Mohu používat sešity umístěné na síťových zdrojích/ sdílených jednotkách?**

Ano, takové sešity lze použít jako externí datový zdroj. Úpravy vzdálených sešitů přímo z Aspose.Slides však nejsou podporovány – lze je použít jen jako zdroj.

**Přepisuje Aspose.Slides externí soubor XLSX při ukládání prezentace?**

Ne. Prezentace uloží [odkaz na externí soubor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) a použije jej pro čtení dat. Externí soubor samotný není při uložení prezentace změněn.

**Co mám dělat, pokud je externí soubor chráněn heslem?**

Aspose.Slides neakceptuje heslo při propojení. Běžný postup je odstranit ochranu předem nebo připravit dešifrovanou kopii (například pomocí [Aspose.Cells](/cells/nodejs-java/)) a odkázat na tuto kopii.

**Mohou více grafů odkazovat na stejný externí sešit?**

Ano. Každý graf ukládá svůj vlastní odkaz. Pokud všechny odkazují na stejný soubor, aktualizace souboru se projeví ve všech grafech při dalším načtení dat.