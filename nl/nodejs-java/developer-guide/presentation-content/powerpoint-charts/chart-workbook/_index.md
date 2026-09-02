---
title: Beheer grafiekwerkboeken in presentaties met JavaScript
linktitle: Grafiekwerkboek
type: docs
weight: 70
url: /nl/nodejs-java/chart-workbook/
keywords:
- grafiekwerkboek
- grafiekgegevens
- werkboekcel
- gegevenslabel
- werkblad
- gegevensbron
- extern werkboek
- externe gegevens
- grafiekcache
- werkboekherstel
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Ontdek Aspose.Slides voor Node.js via Java: beheer moeiteloos grafiekwerkboeken in PowerPoint- en OpenDocument-formaten om uw presentatiedata te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u met grafiek‑werkboeken kunt werken in Aspose.Slides. Het toont hoe u grafiekgegevens kunt lezen en schrijven via werkboek‑streams, werkboekcellen kunt gebruiken als gegevenslabels voor grafieken, werkbladcollecties kunt benaderen en het gegevenstype van de gegevensbron voor grafiekwaarden kunt opgeven.

Het behandelt ook het werken met externe werkboeken als gegevensbron voor grafieken. De voorbeelden laten zien hoe u een extern werkboek maakt en toewijst, het pad van een extern werkboek dat aan een grafiek gekoppeld is ophaalt en grafiekgegevens bewerkt wanneer het werkboek beschikbaar is.

## **Lees en schrijf grafiekgegevens vanuit een werkboek**

Aspose.Slides biedt de [readWorkbookStream](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) en [writeWorkbookStream](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) methoden waarmee u grafiek‑werkboeken (bevatten grafiekgegevens bewerkt met Aspose.Cells) kunt lezen en schrijven. **Opmerking** dat de grafiekgegevens op dezelfde manier georganiseerd moeten zijn of een structuur moeten hebben die vergelijkbaar is met de bron.

Deze JavaScript‑code toont een voorbeeldoperatie:

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

### **Grafieklay‑out valideren na wijziging van werkboek**

Wanneer u een ingesloten werkboek vervangt door een aangepast werkboek, behoudt de grafiek zijn oorspronkelijke series‑ en categorieverzamelingen. Deze mismatch kan ertoe leiden dat [Chart.validateChartLayout](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Chart#validateChartLayout--) faalt met een index‑out‑of‑range‑fout. Wis de bestaande series en categorieën voordat u het bijgewerkte werkboek terugschrijft naar de grafiek.

```javascript
// Na het aanpassen van de werkboek-stream (bijvoorbeeld met Aspose.Cells)
var updatedWorkbook = chartData.readWorkbookStream();

// Wis bestaande gegevensreferenties.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Het wissen van de collecties zorgt ervoor dat de structuur van de grafiekgegevens overeenkomt met het nieuwe werkboek, zodat `validateChartLayout` zonder fouten kan worden voltooid.

## **Werkbladcel instellen als grafiek‑gegevenslabel**

1. Maak een instantie van de [Presentation](https://apireference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation) klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Voeg een Bubble‑grafiek toe met enkele gegevens.  
4. Benader de grafiekseries.  
5. Stel de werkbladcel in als gegevenslabel.  
6. Sla de presentatie op.

Deze JavaScript‑code laat zien hoe u een werkbladcel instelt als grafiek‑gegevenslabel:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// Instantiëert een presentatieklasse die een presentatiebestand vertegenwoordigt
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

Deze JavaScript‑code demonstreert een operatie waarbij de [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) methode wordt gebruikt om een werkbladcollectie te benaderen:

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

## **Gegevenstype van gegevensbron opgeven**

Deze JavaScript‑code laat zien hoe u een type voor een gegevensbron opgeeft:

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

## **Niet‑ondersteunde ingesloten werkboekformaten detecteren**

Aspose.Slides ondersteunt het Excel‑binaire werkboekformaat (.xlsb) niet, dat in sommige grafieken kan worden ingesloten. U kunt de `getEmbeddedWorkbookType`‑methode op [ChartData](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/) samen met de [WorkbookType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/workbooktype/)‑enumeratie gebruiken om niet‑ondersteunde formaten te detecteren en die grafieken over te slaan.

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
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fileSystem = require("fs");

var pres = new aspose.slides.Presentation();
try {
    var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    // readWorkbookStream retourneert de werkboekbytes als een Node Buffer.
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

### **Extern werkboek instellen**

Met de **`setExternalWorkbook`**‑methode kunt u een extern werkboek aan een grafiek toewijzen als gegevensbron. Deze methode kan ook worden gebruikt om een pad naar het externe werkboek bij te werken (als het werkboek is verplaatst).

Hoewel u de gegevens in werkboeken die op externe locaties of bronnen staan niet kunt bewerken, kunt u die werkboeken wel als externe gegevensbron gebruiken. Als een relatief pad voor een extern werkboek wordt opgegeven, wordt dit automatisch omgezet naar een volledig pad.

Deze JavaScript‑code toont hoe u een extern werkboek instelt:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Creëert een instantie van de Presentation-klasse
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

De tweede parameter van de `setExternalWorkbook`‑methode, `updateChartData`, geeft aan of het Excel‑werkboek wel of niet wordt geladen.

* Wanneer `updateChartData` is ingesteld op `false`, wordt alleen het werkboekpad bijgewerkt — de grafiekgegevens worden niet geladen of bijgewerkt vanuit het doelwerkboek. Gebruik deze instelling wanneer het doelwerkboek niet bestaat of niet beschikbaar is.  
* Wanneer `updateChartData` is ingesteld op `true`, worden de grafiekgegevens bijgewerkt vanuit het doelwerkboek.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Creëert een instantie van de Presentation-klasse
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
2. Haal een referentie naar een dia op via de index.  
3. Maak een object voor de grafiekvorm.  
4. Maak een object voor het bron‑type (`ChartDataSourceType`) dat de gegevensbron van de grafiek vertegenwoordigt.  
5. Geef de relevante voorwaarde op op basis van het feit dat het bron‑type hetzelfde is als het type van de externe werkboek‑gegevensbron.

Deze JavaScript‑code demonstreert de operatie:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Creëert een instantie van de Presentation-klasse
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

U kunt de gegevens in externe werkboeken bewerken op dezelfde manier als u wijzigingen aanbrengt in de inhoud van interne werkboeken. Wanneer een extern werkboek niet kan worden geladen, wordt een uitzondering gegooid.

Deze JavaScript‑code is een implementatie van het beschreven proces:

```javascript
// Creëert een instantie van de Presentation-klasse
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **Werkboek herstellen vanuit de cache van de grafiek**

Als een grafiek een extern werkboek gebruikt dat ontbreekt of niet beschikbaar is, kan Aspose.Slides het werkboek van de grafiek reconstrueren vanuit de in de presentatie gecachete gegevens. Maak een [LoadOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/) aan, configureer deze met [SpreadsheetOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/spreadsheetoptions/), en roep [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) aan met `true` voordat u de presentatie opent.

Het volgende JavaScript‑voorbeeld opent een presentatie waarvan de grafiek verwijst naar een niet‑beschikbaar extern werkboek en benadert de herstelde gegevens via [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

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

    // Lees of wijzig hier de herstelde werkboekgegevens.
} finally {
    presentation.dispose();
}
```

Als het externe werkboek niet beschikbaar is en herstel is uitgeschakeld, gooit Aspose.Slides een uitzondering. Schakel herstel alleen in wanneer het gebruik van de gecachete grafiekgegevens een acceptabele fallback is, omdat de cache mogelijk geen wijzigingen bevat die na de laatste update van de presentatie in het externe werkboek zijn aangebracht.

## **FAQ**

**Kan ik bepalen of een specifieke grafiek is gekoppeld aan een extern of een ingesloten werkboek?**

Ja. Een grafiek heeft een [data source type](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) en een [pad naar een extern werkboek](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); als de bron een extern werkboek is, kunt u het volledige pad lezen om te bevestigen dat er een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkboeken ondersteund en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. Dit is handig voor projectportabiliteit; houd er echter rekening mee dat de presentatie het absolute pad opslaat in het PPTX‑bestand.

**Kan ik werkboeken gebruiken die zich op netwerk‑resources/shares bevinden?**

Ja, dergelijke werkboeken kunnen als externe gegevensbron worden gebruikt. Het rechtstreeks bewerken van externe werkboeken vanuit Aspose.Slides wordt echter niet ondersteund — zij kunnen alleen als bron worden gebruikt.

**Overschrijft Aspose.Slides het externe XLSX‑bestand bij het opslaan van de presentatie?**

Nee. De presentatie slaat een [link naar het externe bestand](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) op en gebruikt die voor het lezen van gegevens. Het externe bestand zelf wordt niet gewijzigd bij het opslaan van de presentatie.

**Wat moet ik doen als het externe bestand met een wachtwoord is beschermd?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gebruikelijke aanpak is om de bescherming vooraf te verwijderen of een ontsleutelde kopie voor te bereiden (bijvoorbeeld met [Aspose.Cells](/cells/nodejs-java/)) en naar die kopie te linken.

**Kunnen meerdere grafieken dezelfde externe werkmap gebruiken?**

Ja. Elke grafiek slaat zijn eigen link op. Als ze allemaal naar hetzelfde bestand wijzen, wordt een update van dat bestand in elke grafiek weergegeven de volgende keer dat de gegevens worden geladen.