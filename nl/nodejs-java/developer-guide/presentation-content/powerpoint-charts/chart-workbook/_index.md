---
title: Beheer grafiek‑werkboeken in presentaties met JavaScript
linktitle: Grafiek‑werkboek
type: docs
weight: 70
url: /nl/nodejs-java/chart-workbook/
keywords:
- grafiek‑werkboek
- grafiekgegevens
- werkboekcel
- databelabel
- werkblad
- gegevensbron
- extern werkboek
- externe gegevens
- grafiekkache
- werkboekherstel
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Ontdek Aspose.Slides voor Node.js via Java: beheer moeiteloos grafiek‑werkboeken in PowerPoint- en OpenDocument‑formaten om uw presentatiedata te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u kunt werken met grafiek‑werkboeken in Aspose.Slides. Het laat zien hoe u grafiekgegevens kunt lezen en schrijven via werkboek‑streams, werkboekcellen kunt gebruiken als grafiek‑databronlabels, toegang krijgt tot werkbladcollecties, en het type gegevensbron voor grafiekwaarden kunt specificeren.

Het behandelt ook het werken met externe werkboeken als gegevensbronnen voor grafieken. De voorbeelden tonen hoe u een extern werkboek kunt maken en toewijzen, het pad van een extern werkboek dat aan een grafiek is gekoppeld kunt ophalen, en grafiekgegevens kunt bewerken wanneer het werkboek beschikbaar is.

Voor werkboekcellen die ontbrekende gegevens vertegenwoordigen, zie [Control the Display of Empty Cells](/slides/nl/nodejs-java/chart-series/) voor het verschil tussen een lege cel en nul, en een lijngrafiek‑vergelijking van de beschikbare weergavemodi.

## **Gegevens opnemen van verborgen rijen en kolommen**

Gebruik [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chart/#setPlotVisibleCellsOnly) om te bepalen of een grafiek gegevens plot uit verborgen werkbladrijen en -kolommen. Zet dit op `true` om alleen zichtbare cellen te plotten, of op `false` om zowel zichtbare als verborgen cellen op te nemen. Deze instelling regelt het plotten van de grafiek; hij verbergt of toont geen werkbladrijen of -kolommen.

Download [hidden-source-data.pptx](hidden-source-data.pptx) en plaats het in de werkmap. De eerste dia bevat een kolomgrafiek als eerste vorm. Het ingesloten werkblad, `Sheet1`, bevat het volgende bronbereik, `A1:C4`. Rij 3 en kolom C zijn verborgen, maar hun cellen bevatten nog steeds waarden.

| Werkbladrij | A: Maand | B: Detailhandel | C: Groothandel (verborgen kolom) |
| --- | --- | --- | --- |
| 2 | januari | 10 | 30 |
| 3 (verborgen rij) | februari | 40 | 60 |
| 4 | maart | 20 | 50 |

Toegang tot broncellen via [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) en lees [ChartDataCell.isHidden](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdatacell/#isHidden) om hun verborgen status te inspecteren. Deze methode rapporteert de verborgen status zonder deze te wijzigen. In dit bestand is B2 zichtbaar, B3 hoort bij de verborgen rij, en C2 hoort bij de verborgen kolom; het voorbeeld drukt respectievelijk `false`, `true` en `true` af.

Voor dit voorbeeld, vernieuw de grafiekgegevens na het wijzigen van de plot‑instelling: behoud het ingebedde werkboek met [readWorkbookStream](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) en laad het opnieuw met [writeWorkbookStream](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream). Bij het opnemen van alle cellen, gebruik ook [setRange](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/#setRange) om het volledige bereik te herstellen, inclusief de verborgen februari‑categorie. Alleen de vlag wijzigen is onvoldoende om de gecachete grafiekgegevens en categorie‑labels in dit voorbeeld te vernieuwen. Het voorbeeld converteert de geretourneerde Node.js‑buffer naar een Java‑byte‑array voordat het aan de schrijf‑methode wordt doorgegeven.

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

            // Vernieuw de grafiekgegevens vanuit het ingebedde werkboek.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Herstel het volledige bronbereik, inclusief verborgen categorieën.
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

Het voorbeeld slaat `hidden_cells_true.pptx` op met alleen de zichtbare Detailhandelswaarden (10 en 20), en `hidden_cells_false.pptx` met alle zes waarden. De afbeeldingen hieronder illustreren de twee plot‑modi. Rij 3 en kolom C blijven verborgen in beide ingebedde werkboeken.

| Alleen zichtbare cellen (`true`) | Alle cellen (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

Een verborgen cel met een waarde verschilt van een lege cel. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) bepaalt hoe ontbrekende waarden worden weergegeven; hij omvat of sluit verborgen brongegevens niet uit. Zie [Control the Display of Empty Cells](/slides/nl/nodejs-java/chart-series/#control-the-display-of-empty-cells) voor een voorbeeld.

## **Grafiekgegevens lezen en schrijven vanuit een werkboek**

Aspose.Slides for Node.js via Java biedt de methoden [readWorkbookStream](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) en [writeWorkbookStream](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) waarmee u grafiek‑werkboeken (bevatten grafiekgegevens bewerkt met Aspose.Cells) kunt lezen en schrijven. **Opmerking** dat de grafiekgegevens op dezelfde manier moeten zijn georganiseerd of een structuur moeten hebben die vergelijkbaar is met de bron.

Dit voorbeeld opent `chart.pptx`, dat een grafiek moet bevatten als eerste vorm op de eerste dia. Het leest het ingebedde werkboek in een byte‑array, wist de bestaande reeksen en categorieën, en schrijft hetzelfde werkboek terug. De wijzigingen blijven in het geheugen; het voorbeeld slaat de presentatie niet op.

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

### **Grafiekindeling valideren na werkboekwijziging**

Wanneer u een ingebed werkboek vervangt door een aangepast werkboek, behoudt de grafiek de oorspronkelijke reeksen‑ en categorieverzamelingen. Deze mismatch kan ervoor zorgen dat [Chart.validateChartLayout](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chart/#validateChartLayout) faalt met een “index‑out‑of‑range”‑fout. Wis de bestaande reeksen en categorieën voordat u het bijgewerkte werkboek terugschrijft naar de grafiek. Dit voorbeeld vereist `chart.pptx` met een grafiek als eerste vorm op de eerste dia. Het commentaar geeft aan waar de bewerking van het werkboek zou plaatsvinden; het uitvoerbare voorbeeld schrijft het originele werkboek terug en valideert de indeling in het geheugen.

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

        // Pas hier de werkboekbytes aan, bijvoorbeeld met Aspose.Cells.

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

Het wissen van de collecties verwijdert verouderde gegevensreferenties voordat het werkboek wordt weggeschreven. Bouw eventuele benodigde reeksen‑ en categorietoewijzingen opnieuw op voor het aangepaste werkboek voordat u de grafiek gebruikt.

## **Een werkboekcel instellen als grafiek‑databelabel**

U kunt tekst uit werkboekcellen gebruiken als databelabels voor een grafiek. De volgende stappen tonen hoe u de labels in een bubbelgrafiek koppelt aan cellen in het gegevens‑werkboek.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse.
2. Toegang tot de eerste dia via de index 0.
3. Voeg een bubbelgrafiek toe met standaardgegevens.
4. Toegang tot de grafiekreeksen.
5. Stel de werkboekcel in als databelabel.
6. Sla de presentatie op.

Dit voorbeeld opent `chart2.pptx`, dat ten minste één dia moet bevatten, en voegt een bubbelgrafiek met standaardgegevens toe. Het gebruikt cellen A10:A12 op werkblad 0 voor de eerste drie labels in de eerste reeks, schakelt labels vanuit cellen in, en slaat het resultaat op als `resultchart.pptx`.

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

## **Werkbladen beheren**

De methode [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdataworkbook/#getWorksheets) biedt toegang tot de werkbladen in een grafiek‑werkboek. Dit voorbeeld maakt een cirkeldiagram met standaardgegevens en drukt elke werkbladnaam af naar de console.

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

## **Het type gegevensbron specificeren**

Dit voorbeeld maakt een 3D‑kolomgrafiek met standaardgegevens en stelt twee reeksnamen in met verschillende gegevensbronnen. De eerste naam gebruikt een tekenreeks‑literal; de tweede gebruikt cel C1 op werkblad 0. De enumeratie [DataSourceType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/datasourcetype/) selecteert de bron voor elke naam. Het resultaat wordt opgeslagen als `pres.pptx`.

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

## **Detecteren van niet‑ondersteunde ingesloten werkboekformaten**

Aspose.Slides ondersteunt het Excel‑binaire werkboek‑formaat (.xlsb) niet, dat in sommige grafieken kan worden ingesloten. U kunt de methode [getEmbeddedWorkbookType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) op [ChartData](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/) samen met de enumeratie [WorkbookType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/workbooktype/) gebruiken om niet‑ondersteunde formaten te detecteren en die grafieken over te slaan. Dit voorbeeld inspecteert de vormen op de eerste dia van `sample.pptx`, slaat niet‑grafiek‑vormen over, en drukt een diagnostisch bericht af voor elke grafiek met een ingesloten .xlsb‑werkboek.

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

        // Lees of wijzig ondersteunde grafiek‑werkboekgegevens hier.
    }
} finally {
    presentation.dispose();
}
```

## **Extern werkboek**

Aspose.Slides ondersteunt het gebruik van externe werkboeken als gegevensbron voor grafieken.

### **Een extern werkboek maken**

Gebruik [readWorkbookStream](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) en [setExternalWorkbook](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) om een ingebed grafiek‑werkboek naar een bestand te exporteren en de grafiek te koppelen aan dat externe werkboek.

Dit voorbeeld maakt een cirkeldiagram met standaardgegevens, schrijft het werkboek naar `externalWorkbook1.xlsx`, en voltooit het bestandsschrijf‑proces voordat het bestand wordt toegewezen als de grafiek‑gegevensbron. Het slaat de gekoppelde presentatie op als `externalWorkbook.pptx`.

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


### **Een extern werkboek instellen**

Met de methode [setExternalWorkbook](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) kunt u een extern werkboek aan een grafiek toewijzen als gegevensbron. Deze methode kan ook worden gebruikt om het pad naar het externe werkboek bij te werken (als het bestand is verplaatst).

Hoewel u de gegevens in werkboeken die zich op externe locaties of resources bevinden niet kunt bewerken, kunt u die werkboeken wel gebruiken als externe gegevensbron. Als een relatief pad voor een extern werkboek wordt opgegeven, wordt dit automatisch omgezet naar een volledig pad.

Dit voorbeeld vereist `externalWorkbook.xlsx` in de werkmap. Het werkblad met de naam `Sheet1` moet een reeksennaam in B1, categorienamen in A2:A4 en numerieke waarden in B2:B4 bevatten. Het voorbeeld maakt een cirkeldiagram, koppelt het werkboek, en gebruikt [setRange](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/#setRange) om A1:B4 te koppelen aan één reeks en drie categorieën. Het resultaat wordt opgeslagen als `Presentation_with_externalWorkbook.pptx`.

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

De parameter `updateChartData` van [setExternalWorkbook](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) bepaalt of het werkboek wordt geladen.

* Wanneer `updateChartData` `false` is, wordt alleen het pad van het werkboek bijgewerkt. De grafiek‑gegevens worden niet geladen of bijgewerkt vanuit het doel‑werkboek, zodat het werkboek onbeschikbaar kan blijven.
* Wanneer `updateChartData` `true` is, worden de grafiek‑gegevens bijgewerkt vanuit het doel‑werkboek.

Het volgende voorbeeld wijst een placeholder‑URL toe met `updateChartData` ingesteld op `false`. Het behoudt de standaardgegevens van de cirkeldiagram en slaat de presentatie op zonder het onbeschikbare werkboek te laden.

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

### **Het pad van het externe gegevensbron‑werkboek van een grafiek ophalen**

Om het werkboek te identificeren dat aan een grafiek is gekoppeld, controleer eerst of de grafiek een externe gegevensbron gebruikt. Als dat het geval is, kunt u het pad van het werkboek ophalen via de volgende stappen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse.
2. Toegang tot de eerste dia via de index 0.
3. Controleer of de eerste vorm een grafiek is.
4. Lees het type gegevensbron van de grafiek.
5. Als de bron een extern werkboek is, lees dan het pad.

Dit voorbeeld opent `externalWorkbook.pptx`, dat in het eerdere voorbeeld is aangemaakt, en inspecteert de eerste vorm op de eerste dia. Als het een grafiek is die gekoppeld is aan een extern werkboek, drukt het voorbeeld [getExternalWorkbookPath](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) af naar de console. Vervolgens slaat het een kopie van de presentatie op als `Result.pptx`.

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

### **Grafiekgegevens bewerken**

U kunt de gegevens in externe werkboeken op dezelfde manier bewerken als u wijzigingen aanbrengt in interne werkboeken. Wanneer een extern werkboek niet kan worden geladen, wordt een uitzondering gegooid.

Dit voorbeeld vereist `presentation.pptx` met een grafiek als eerste vorm op de eerste dia en een toegankelijk extern werkboek. Het stelt de cel‑ondersteunde waarde van het eerste gegevenspunt in de eerste reeks in op 100 en slaat de presentatie op als `presentation_out.pptx`. Het bewerken van celwaarden kan het gekoppelde externe XLSX‑bestand bijwerken; gebruik een kopie als u het originele werkboek moet behouden.

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

### **Een werkboek herstellen uit de grafiek‑cache**

Als een grafiek een extern werkboek gebruikt dat ontbreekt of onbeschikbaar is, kan Aspose.Slides het grafiek‑werkboek reconstrueren vanuit de in de presentatie gecachete gegevens. Maak een [LoadOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/) object, roep [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions) aan, en stel [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) in op `true` voordat u de presentatie opent.

Het volgende JavaScript‑voorbeeld opent `presentation.pptx`, waarvan de eerste vorm op de eerste dia een grafiek moet zijn die naar een onbeschikbaar extern werkboek verwijst, en krijgt de herstelde gegevens via [Chart.getChartData](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chart/#getChartData) en [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

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

        // Lees of wijzig hier de herstelde werkboekgegevens.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Als het externe werkboek onbeschikbaar is en herstel is uitgeschakeld, gooit Aspose.Slides een uitzondering. Schakel herstel alleen in wanneer het gebruik van de gecachete grafiekgegevens een aanvaardbare terugval is, omdat de cache mogelijk geen wijzigingen bevat die in het externe werkboek zijn aangebracht nadat de presentatie voor het laatst is bijgewerkt.

## **FAQ**

**Kan ik bepalen of een specifieke grafiek is gekoppeld aan een extern of een ingebed werkboek?**

Ja. Een grafiek heeft een [data source type](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/#getDataSourceType) en een [path to an external workbook](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath); als de bron een extern werkboek is, kunt u het volledige pad lezen om te bevestigen dat er een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkboeken ondersteund, en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. De presentatie slaat het absolute pad op in het PPTX‑bestand, dus het verplaatsen van het werkboek kan vereisen dat de koppeling wordt bijgewerkt.

**Kan ik werkboeken gebruiken die zich op netwerkresources of shares bevinden?**

Ja, dergelijke werkboeken kunnen worden gebruikt als een externe gegevensbron. Het direct bewerken van externe werkboeken vanuit Aspose.Slides wordt echter niet ondersteund – ze kunnen alleen als bron worden gebruikt.

**Schrijft Aspose.Slides het externe XLSX‑bestand overschrijven bij het opslaan van de presentatie?**

De presentatie slaat een [link to the external file](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) op. Het bewerken van cel‑ondersteunde grafiekgegevens kan ook het gekoppelde lokale XLSX‑bestand bijwerken. Gebruik een kopie van het werkboek als het origineel onveranderd moet blijven.

**Wat moet ik doen als het externe bestand met een wachtwoord is beveiligd?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gangbare aanpak is om de beveiliging vooraf te verwijderen of een gedecrypteerde kopie voor te bereiden (bijvoorbeeld met [Aspose.Cells](https://reference.aspose.com/cells/java/)) en naar die kopie te koppelen.

**Kunnen meerdere grafieken dezelfde externe werkboekreferentie gebruiken?**

Ja. Elke grafiek slaat zijn eigen koppeling op. Als ze allemaal naar hetzelfde bestand wijzen, wordt een wijziging in dat bestand in elke grafiek weerspiegeld de volgende keer dat de gegevens worden geladen.