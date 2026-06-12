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
- zdroj dat
- externí sešit
- externí data
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Objevte Aspose.Slides pro Node.js přes Java: snadno spravujte sešity grafů v PowerPoint a OpenDocument formátech a zjednodušte data své prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s grafickými sešity v Aspose.Slides. Ukazuje, jak číst a zapisovat data grafu pomocí proudů sešitu, používat buňky sešitu jako popisky dat grafu, přistupovat ke kolekcím listů a specifikovat typ zdroje dat pro hodnoty grafu.

Také se věnuje práci s externími sešity jako zdroji dat grafu. Příklady demonstrují, jak vytvořit a přiřadit externí sešit, získat cestu k externímu sešitu propojenému s grafem a upravit data grafu, když je sešit k dispozici.

## **Čtení a zápis dat grafu ze sešitu**

Aspose.Slides poskytuje metody [readWorkbookStream](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) a [writeWorkbookStream](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) , které umožňují číst a zapisovat sešity dat grafu (obsahující data grafu upravená pomocí Aspose.Cells). **Poznámka** že data grafu musí být uspořádána stejným způsobem nebo mít podobnou strukturu jako zdroj.

Tento JavaScriptový kód demonstruje ukázkovou operaci:

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

## **Nastavení buňky sešitu jako popisku dat grafu**

1. Vytvořte instanci třídy [Presentation](https://apireference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte bublinový graf s některými daty.
1. Přistupte k sérii grafu.
1. Nastavte buňku sešitu jako popisek dat.
1. Uložte prezentaci.

Tento JavaScriptový kód ukazuje, jak nastavit buňku sešitu jako popisek dat grafu:

```javascript
var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// Vytváří instanci třídy prezentace, která představuje soubor prezentace
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

Aspose.Slides nepodporuje binární formát Excelu (.xlsb), který může být vložen v některých grafech. Můžete použít metodu `getEmbeddedWorkbookType` na [ChartData](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/) spolu s výčtem [WorkbookType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/workbooktype/) k detekci nepodporovaných formátů a přeskočení těchto grafů.

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

        // Zde načtěte nebo upravte data sešitu grafu.
    }
} finally {
    presentation.dispose();
}
```

## **Externí sešit**

Aspose.Slides podporuje externí sešity jako zdroj dat pro grafy.

### **Vytvoření externího sešitu**

Pomocí metod **`readWorkbookStream`** a **`setExternalWorkbook`** můžete buď vytvořit nový externí sešit, nebo učinit interní sešit externím.

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

### **Nastavení externího sešitu**

Pomocí metody **`setExternalWorkbook`** můžete přiřadit externí sešit grafu jako jeho zdroj dat. Tato metoda může být také použita k aktualizaci cesty k externímu sešitu (pokud byl přesunut).

I když nemůžete upravovat data v sešitech uložených na vzdálených místech nebo zdrojích, můžete takové sešity i nadále použít jako externí zdroj dat. Pokud je zadána relativní cesta k externímu sešitu, automaticky se převede na úplnou cestu.

Tento JavaScriptový kód ukazuje, jak nastavit externí sešit:

```javascript
// Vytváří instanci třídy Presentation
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

Parametr `ChartData` (ve metodě `setExternalWorkbook`) určuje, zda bude excelový sešit načten.

* Když je hodnota `ChartData` nastavena na `false`, aktualizuje se pouze cesta k sešitu — data grafu nebudou načtena ani aktualizována ze cílového sešitu. Toto nastavení je užitečné, pokud cílový sešit neexistuje nebo není dostupný.
* Když je hodnota `ChartData` nastavena na `true`, data grafu se aktualizují ze cílového sešitu.

```javascript
// Vytváří instanci třídy Presentation
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

### **Získání cesty k externímu zdroji dat grafu**

1. Vytvořte instanci třídy [Presentation](https://apireference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
1. Získejte odkaz na snímek podle jeho indexu.
1. Vytvořte objekt pro tvar grafu.
1. Vytvořte objekt pro typ zdroje (`ChartDataSourceType`), který představuje zdroj dat grafu.
1. Zadejte příslušnou podmínku na základě toho, zda je typ zdroje stejný jako typ externího sešitu.

Tento JavaScriptový kód demonstruje operaci:

```javascript
// Vytváří instanci třídy Presentation
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

Data v externích sešitech můžete upravovat stejným způsobem, jako měníte obsah interních sešitů. Pokud nelze externí sešit načíst, vyvolá se výjimka.

Tento JavaScriptový kód je implementací popsaného procesu:

```javascript
// Vytváří instanci třídy Presentation
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

## **Často kladené otázky**

**Mohu zjistit, zda je konkrétní graf propojen s externím nebo vloženým sešitem?**

Ano. Graf má [typ zdroje dat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) a [cestu k externímu sešitu](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); pokud je zdroj externí sešit, můžete přečíst úplnou cestu a ověřit, že je používán externí soubor.

**Podporují se relativní cesty k externím sešitům a jak jsou uloženy?**

Ano. Pokud zadáte relativní cestu, automaticky se převede na absolutní. To je výhodné pro přenositelnost projektu; mějte však na paměti, že prezentace uloží absolutní cestu v souboru PPTX.

**Mohu použít sešity umístěné na síťových zdrojích/sdíleních?**

Ano, takové sešity mohou být použity jako externí zdroj dat. Úprava vzdálených sešitů přímo z Aspose.Slides však není podporována — lze je použít pouze jako zdroj.

**Přepisuje Aspose.Slides externí XLSX při ukládání prezentace?**

Ne. Prezentace uloží [odkaz na externí soubor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) a použije jej při čtení dat. Externí soubor samotný není při uložení prezentace změněn.

**Co mám dělat, když je externí soubor chráněn heslem?**

Aspose.Slides nepřijímá heslo při propojení. Obvyklý postup je odstranit ochranu předem nebo připravit dešifrovanou kopii (například pomocí [Aspose.Cells](/cells/nodejs-java/)) a odkazovat na tuto kopii.

**Může více grafů odkazovat na stejný externí sešit?**

Ano. Každý graf uloží svůj vlastní odkaz. Pokud všechny odkazují na stejný soubor, jeho aktualizace se projeví v každém grafu při dalším načtení dat.