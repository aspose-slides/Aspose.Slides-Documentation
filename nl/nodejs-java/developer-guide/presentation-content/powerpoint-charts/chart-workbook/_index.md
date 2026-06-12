---
title: Beheer grafiek-werkboeken in presentaties met JavaScript
linktitle: Grafiek-werkboek
type: docs
weight: 70
url: /nl/nodejs-java/chart-workbook/
keywords:
- grafiek-werkboek
- grafiek-gegevens
- werkboekcel
- datalabel
- werkblad
- gegevensbron
- extern werkboek
- externe gegevens
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Ontdek Aspose.Slides voor Node.js via Java: beheer moeiteloos grafiek-werkboeken in PowerPoint- en OpenDocument-formaten om uw presentatiedata te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u met grafiek‑werkboeken in Aspose.Slides kunt werken. Het toont hoe u grafiekgegevens kunt lezen en schrijven via werkboek‑streams, werkboekcellen kunt gebruiken als grafiek‑datelabels, toegang krijgt tot werkbladcollecties en het gegevenstype van de gegevensbron voor grafiekwaarden kunt opgeven.

Het behandelt ook het werken met externe werkboeken als gegevensbron voor grafieken. De voorbeelden laten zien hoe u een extern werkboek kunt maken en toewijzen, het pad van een extern werkboek dat aan een grafiek is gekoppeld kunt ophalen, en grafiekgegevens kunt bewerken wanneer het werkboek beschikbaar is.

## **Grafiekgegevens lezen en schrijven vanuit een werkboek**

Aspose.Slides biedt de [readWorkbookStream](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) en [writeWorkbookStream](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) methoden waarmee u grafiekgegevens‑werkboeken kunt lezen en schrijven (bevat grafiekgegevens die met Aspose.Cells zijn bewerkt). **Opmerking** dat de grafiekgegevens op dezelfde manier moeten worden georganiseerd of een structuur moeten hebben die vergelijkbaar is met de bron.

Deze JavaScript‑code demonstreert een voorbeeldoperatie:

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

## **WerkBook‑cel instellen als Chart DataLabel**

1. Maak een instantie van de [Presentation](https://apireference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation) klasse.  
1. Haal een referentie naar een dia op via de index.  
1. Voeg een Bubble‑grafiek toe met enkele gegevens.  
1. Toegang tot de grafiekseries.  
1. Stel de werkboekcel in als datalabel.  
1. Sla de presentatie op.

Deze JavaScript‑code laat zien hoe u een werkboekcel als grafiek‑datelabel instelt:

```javascript
var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// Instantieert een presentatieklasse die een presentatiebestand vertegenwoordigt
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

Deze JavaScript‑code demonstreert een bewerking waarbij de [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) methode wordt gebruikt om toegang te krijgen tot een werkbladcollectie:

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

## **Gegevenstype van gegevensbron opgeven**

Deze JavaScript‑code laat zien hoe u een type voor een gegevensbron specificeert:

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

## **Detecteer niet‑ondersteunde ingesloten werkboekformaten**

Aspose.Slides ondersteunt het binaire Excel‑werkboekformaat (.xlsb) dat in sommige grafieken kan worden ingesloten niet. U kunt de `getEmbeddedWorkbookType`‑methode op [ChartData](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/) samen met de [WorkbookType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/workbooktype/) enumeratie gebruiken om niet‑ondersteunde formaten te detecteren en die grafieken over te slaan.

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
            // Ingesloten werkboek is in .xlsb-formaat, wat niet wordt ondersteund.
            continue;
        }

        // Lees of wijzig hier de grafiek-werkboekgegevens.
    }
} finally {
    presentation.dispose();
}
```

## **Extern werkboek**

Aspose.Slides ondersteunt externe werkboeken als gegevensbron voor grafieken.

### **Extern werkboek maken**

Met de **`readWorkbookStream`**‑ en **`setExternalWorkbook`**‑methoden kunt u een extern werkboek vanaf nul maken of een intern werkboek extern maken.

Deze JavaScript‑code demonstreert het proces van het maken van een extern werkboek:

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

### **Extern werkboek instellen**

Met de **`setExternalWorkbook`**‑methode kunt u een extern werkboek aan een grafiek toewijzen als gegevensbron. Deze methode kan ook worden gebruikt om het pad naar het externe werkboek bij te werken (als het laatstgenoemde is verplaatst).

Hoewel u de gegevens in werkboeken die op externe locaties of bronnen zijn opgeslagen niet kunt bewerken, kunt u dergelijke werkboeken nog steeds als externe gegevensbron gebruiken. Als een relatief pad voor een extern werkboek wordt opgegeven, wordt dit automatisch omgezet naar een volledig pad.

Deze JavaScript‑code laat zien hoe u een extern werkboek instelt:

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

De `ChartData`‑parameter (onder de `setExternalWorkbook`‑methode) wordt gebruikt om op te geven of een Excel‑werkboek wel of niet wordt geladen.

* Wanneer de `ChartData`‑waarde is ingesteld op `false`, wordt alleen het pad van het werkboek bijgewerkt — de grafiekgegevens worden niet geladen of bijgewerkt vanuit het doel‑werkboek. U kunt deze instelling gebruiken wanneer het doel‑werkboek niet bestaat of niet beschikbaar is.  
* Wanneer de `ChartData`‑waarde is ingesteld op `true`, worden de grafiekgegevens bijgewerkt vanuit het doel‑werkboek.

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

### **Pad van extern gegevensbron‑werkboek van grafiek ophalen**

1. Maak een instantie van de [Presentation](https://apireference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation) klasse.  
1. Haal een referentie naar een dia op via de index.  
1. Maak een object voor de grafiekvorm.  
1. Maak een object voor het bron‑type (`ChartDataSourceType`) dat de gegevensbron van de grafiek vertegenwoordigt.  
1. Specificeer de relevante voorwaarde op basis van het feit dat het bron‑type gelijk is aan het type van de externe werkboek‑gegevensbron.

Deze JavaScript‑code demonstreert de bewerking:

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

U kunt de gegevens in externe werkboeken op dezelfde manier bewerken als u wijzigingen aanbrengt in de inhoud van interne werkboeken. Wanneer een extern werkboek niet kan worden geladen, wordt er een uitzondering gegooid.

Deze JavaScript‑code is een implementatie van het beschreven proces:

```javascript
// Maakt een instantie van de Presentation-klasse
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

## **FAQ**

**Kan ik bepalen of een specifieke grafiek is gekoppeld aan een extern of een ingesloten werkboek?**

Ja. Een grafiek heeft een [data source type](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) en een [pad naar een extern werkboek](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); als de bron een extern werkboek is, kunt u het volledige pad lezen om te controleren dat er een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkboeken ondersteund, en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. Dit is handig voor projectportabiliteit; houd er echter rekening mee dat de presentatie het absolute pad opneemt in het PPTX‑bestand.

**Kan ik werkboeken gebruiken die zich op netwerkbronnen of gedeelde mappen bevinden?**

Ja, dergelijke werkboeken kunnen worden gebruikt als een externe gegevensbron. Het bewerken van externe werkboeken rechtstreeks vanuit Aspose.Slides wordt echter niet ondersteund — ze kunnen alleen als bron worden gebruikt.

**Overschrijft Aspose.Slides het externe XLSX‑bestand bij het opslaan van de presentatie?**

Nee. De presentatie slaat een [link naar het externe bestand](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) op en gebruikt deze om gegevens te lezen. Het externe bestand zelf wordt niet gewijzigd wanneer de presentatie wordt opgeslagen.

**Wat moet ik doen als het externe bestand met een wachtwoord is beveiligd?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gebruikelijke aanpak is om de beveiliging vooraf te verwijderen of een ontsleutelde kopie voor te bereiden (bijvoorbeeld met [Aspose.Cells](/cells/nodejs-java/)) en naar die kopie te linken.

**Kunnen meerdere grafieken naar hetzelfde externe werkboek verwijzen?**

Ja. Elke grafiek slaat zijn eigen link op. Als ze allemaal naar hetzelfde bestand wijzen, wordt een bijwerking van dat bestand bij de volgende keer dat de gegevens worden geladen in elke grafiek weerspiegeld.