---
title: Beheer grafiekwerkmappen in presentaties met JavaScript
linktitle: Grafiekwerkmap
type: docs
weight: 70
url: /nl/nodejs-java/chart-workbook/
keywords:
- grafiekwerkmap
- grafiekgegevens
- werkbladcel
- databelabel
- werkblad
- gegevensbron
- externe werkmap
- externe gegevens
- grafiekcache
- werkmapherstel
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Ontdek Aspose.Slides voor Node.js via Java: beheer moeiteloos grafiekwerkmappen in PowerPoint- en OpenDocument-formaat om uw presentatiedata te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u met grafiek‑werkmappen in Aspose.Slides kunt werken. Het laat zien hoe u grafiekgegevens kunt lezen en schrijven via werkmap‑streams, werkbladcellen kunt gebruiken als grafiek‑databladlabels, toegang krijgt tot werkbladcollecties en het type gegevensbron voor grafiekwaarden kunt opgeven.

Het behandelt ook het werken met externe werkmappen als gegevensbronnen voor grafieken. De voorbeelden laten zien hoe u een externe werkmap maakt en toewijst, het pad van een externe werkmap die aan een grafiek is gekoppeld opvraagt, en grafiekgegevens bewerkt wanneer de werkmap beschikbaar is.

## **Grafiekgegevens lezen en schrijven vanuit een werkmap**

Aspose.Slides biedt de [readWorkbookStream](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) en [writeWorkbookStream](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) methoden waarmee u grafiekgegevens‑werkmappen (bevat grafiekgegevens bewerkt met Aspose.Cells) kunt lezen en schrijven. **Opmerking** dat de grafiekgegevens op dezelfde manier moeten zijn gestructureerd of een vergelijkbare structuur moeten hebben als de bron.

Deze JavaScript‑code toont een voorbeeldbewerking:

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

## **Werkbladcel instellen als grafiek‑DataLabel**

1. Maak een instantie van de [Presentation](https://apireference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation)‑klasse.
1. Verkrijg een verwijzing naar een dia via de index.
1. Voeg een bubbeldiagram toe met enige gegevens.
1. Toegang tot de grafiekseries.
1. Stel de werkbladcel in als datablad‑label.
1. Sla de presentatie op.

Deze JavaScript‑code laat zien hoe u een werkbladcel als grafiek‑databelabel instelt:

```javascript
var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// Initialiseert een presentatieklasse die een presentatiebestand vertegenwoordigt
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

## **Werkbladen beheren**

Deze JavaScript‑code toont een bewerking waarbij de [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--)‑methode wordt gebruikt om toegang te krijgen tot een werkbladcollectie:

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

## **Gegevensbrontype opgeven**

Deze JavaScript‑code laat zien hoe u een type voor een gegevensbron opgeeft:

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

## **Detecteer niet‑ondersteunde ingebedde werkmap‑formaten**

Aspose.Slides ondersteunt niet het Excel‑binaire werkmapformaat (.xlsb) dat in sommige grafieken kan worden ingebed. U kunt de `getEmbeddedWorkbookType`‑methode op [ChartData](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/) samen met de [WorkbookType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/workbooktype/)‑enumeratie gebruiken om niet‑ondersteunde formaten te detecteren en die grafieken over te slaan.

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
            // Ingebedde werkmap is in .xlsb-formaat, wat niet ondersteund wordt.
            continue;
        }

        // Lees of wijzig hier de grafiekwerkmapgegevens.
    }
} finally {
    presentation.dispose();
}
```

## **Externe werkmap**

Aspose.Slides ondersteunt externe werkmappen als gegevensbron voor grafieken.

### **Externe werkmap maken**

Met de **`readWorkbookStream`**‑ en **`setExternalWorkbook`**‑methoden kunt u een externe werkmap vanaf nul maken of een interne werkmap extern maken.

Deze JavaScript‑code toont het proces voor het maken van een externe werkmap:

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

### **Externe werkmap instellen**

Met de **`setExternalWorkbook`**‑methode kunt u een externe werkmap aan een grafiek toewijzen als gegevensbron. Deze methode kan ook worden gebruikt om een pad naar de externe werkmap bij te werken (als die verplaatst is).

Hoewel u de gegevens in werkmappen die op externe locaties of bronnen zijn opgeslagen niet kunt bewerken, kunt u dergelijke werkmappen wel als externe gegevensbron gebruiken. Als er een relatief pad voor een externe werkmap wordt opgegeven, wordt dit automatisch omgezet naar een volledig pad.

Deze JavaScript‑code laat zien hoe u een externe werkmap instelt:

```javascript
// Maakt een instantie van de Presentation-klasse
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

De `ChartData`‑parameter (onder de `setExternalWorkbook`‑methode) wordt gebruikt om op te geven of een Excel‑werkmap wel of niet wordt geladen.

* Wanneer de `ChartData`‑waarde `false` is, wordt alleen het pad van de werkmap bijgewerkt — de grafiekgegevens worden niet geladen of bijgewerkt vanuit de doel‑werkmap. Gebruik deze instelling wanneer de doel‑werkmap niet bestaat of niet beschikbaar is.  
* Wanneer de `ChartData`‑waarde `true` is, worden de grafiekgegevens bijgewerkt vanuit de doel‑werkmap.

```javascript
// Maakt een instantie van de Presentation-klasse
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

### **Pad van externe gegevensbron‑werkmap ophalen**

1. Maak een instantie van de [Presentation](https://apireference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation)‑klasse.
1. Verkrijg een verwijzing naar een dia via de index.
1. Maak een object voor de grafiekvorm.
1. Maak een object voor het bron‑type (`ChartDataSourceType`) dat de gegevensbron van de grafiek vertegenwoordigt.
1. Specificeer de relevante voorwaarde op basis van het bron‑type dat gelijk is aan het type van de externe werkmap‑gegevensbron.

Deze JavaScript‑code toont de bewerking:

```javascript
// Maakt een instantie van de Presentation-klasse
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var slide = pres.getSlides().get_Item(1);
    var chart = slide.getShapes().get_Item(0);
    var sourceType = chart.getChartData().getDataSourceType();
    if (sourceType == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
        var path = chart.getChartData().getExternalWorkbookPath();
    }
    // Slaat de presentatie op
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Grafiekgegevens bewerken**

U kunt de gegevens in externe werkmappen op dezelfde manier bewerken als de inhoud van interne werkmappen. Wanneer een externe werkmap niet kan worden geladen, wordt er een uitzondering gegooid.

Deze JavaScript‑code is een implementatie van het beschreven proces:

```javascript
// Creëert een instantie van de Presentation-klasse
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

### **Werkmap uit de grafiek‑cache herstellen**

Als een grafiek een externe werkmap gebruikt die ontbreekt of niet beschikbaar is, kan Aspose.Slides de grafiek‑werkmap reconstrueren vanuit de gegevens die in de presentatie zijn opgeslagen. Maak een [LoadOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/) aan, configureer deze met [SpreadsheetOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/spreadsheetoptions/), en roep [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) aan met `true` voordat u de presentatie opent.

Het volgende JavaScript‑voorbeeld opent een presentatie waarvan de grafiek een niet‑beschikbare externe werkmap verwijst en krijgt de herstelde gegevens via [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

```javascript
const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Lees of wijzig hier de herstelde werkmapgegevens.
} finally {
    presentation.dispose();
}
```

Als de externe werkmap niet beschikbaar is en herstel is uitgeschakeld, gooit Aspose.Slides een uitzondering. Schakel herstel alleen in wanneer het gebruik van de in‑cache opgeslagen grafiekgegevens een acceptabele fallback is, omdat de cache mogelijk geen wijzigingen bevat die na de laatste presentatie‑update in de externe werkmap zijn aangebracht.

## **FAQ**

**Kan ik bepalen of een specifieke grafiek is gekoppeld aan een externe of een ingebedde werkmap?**

Ja. Een grafiek heeft een [data source type](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) en een [path to an external workbook](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); als de bron een externe werkmap is, kunt u het volledige pad lezen om zeker te weten dat er een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkmappen ondersteund en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. Dit is handig voor project‑portabiliteit; houd er echter rekening mee dat de presentatie het absolute pad in het PPTX‑bestand opslaat.

**Kan ik werkmappen gebruiken die op netwerklocaties of gedeelde mappen staan?**

Ja, dergelijke werkmappen kunnen worden gebruikt als externe gegevensbron. Direct bewerken van externe werkmappen vanuit Aspose.Slides wordt echter niet ondersteund — ze kunnen alleen als bron dienen.

**Schrijft Aspose.Slides de externe XLSX over bij het opslaan van de presentatie?**

Nee. De presentatie slaat een [link to the external file](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) op en gebruikt deze voor het lezen van gegevens. Het externe bestand zelf wordt niet gewijzigd wanneer de presentatie wordt opgeslagen.

**Wat moet ik doen als het externe bestand met een wachtwoord beveiligd is?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gangbare aanpak is om de beveiliging vooraf te verwijderen of een gedecrypteerde kopie voor te bereiden (bijvoorbeeld met [Aspose.Cells](/cells/nodejs-java/)) en naar die kopie te linken.

**Kunnen meerdere grafieken dezelfde externe werkmap gebruiken?**

Ja. Elke grafiek slaat zijn eigen link op. Als ze allemaal naar hetzelfde bestand wijzen, wordt het bijwerken van dat bestand weerspiegeld in elke grafiek wanneer de gegevens opnieuw worden geladen.