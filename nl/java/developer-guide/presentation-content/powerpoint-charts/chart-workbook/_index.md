---
title: Beheer grafiekwerkboeken in presentaties met Java
linktitle: Grafiekwerkboek
type: docs
weight: 70
url: /nl/java/chart-workbook/
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
- Java
- Aspose.Slides
description: "Ontdek Aspose.Slides voor Java: beheer moeiteloos grafiekwerkboeken in PowerPoint- en OpenDocumentformaten om uw presentatiedata te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u met grafiek-werkboeken in Aspose.Slides kunt werken. Het laat zien hoe u grafiekgegevens kunt lezen en schrijven via werkboek‑streams, werkboek‑cellen als grafiek‑datatlabels kunt gebruiken, toegang krijgt tot werkblad‑collecties en het gegevenstype voor grafiekwaarden kunt opgeven.

Het behandelt ook het werken met externe werkboeken als bron voor grafiekgegevens. De voorbeelden tonen hoe u een extern werkboek maakt en toewijst, het pad van een extern werkboek dat aan een grafiek is gekoppeld opvraagt en grafiekgegevens bewerkt wanneer het werkboek beschikbaar is.

Voor werkboekcellen die ontbreken, zie [Control the Display of Empty Cells](/slides/nl/java/chart-series/) voor het verschil tussen een lege cel en nul, en een lijngrafiek‑vergelijking van de beschikbare weergavemodi.

## **Gegevens opnemen uit verborgen rijen en kolommen**

Gebruik [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) om te bepalen of een grafiek gegevens plot uit verborgen werkblad‑rijen en -kolommen. Stel in op `true` om alleen zichtbare cellen te plotten, of op `false` om zowel zichtbare als verborgen cellen op te nemen. Deze instelling bepaalt het plotten van de grafiek; het verbergt of toont geen werkblad‑rijen of -kolommen.

Download [hidden-source-data.pptx](hidden-source-data.pptx) en plaats het in de werkdirectory. De eerste dia bevat een kolomgrafiek als eerste vorm. Het ingesloten werkblad, `Sheet1`, bevat het volgende bronbereik, `A1:C4`. Rij 3 en kolom C zijn verborgen, maar hun cellen bevatten nog steeds waarden.

| Werkblad‑rij | A: Maand | B: Retail | C: Wholesale (verborgen kolom) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (verborgen rij) | February | 40 | 60 |
| 4 | March | 20 | 50 |

Toegang tot broncellen via [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) en lees [IChartDataCell.isHidden](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdatacell/#isHidden--) om hun verborgen status te inspecteren. Deze methode geeft de verborgen status terug zonder deze te wijzigen. In dit bestand is B2 zichtbaar, B3 behoort tot de verborgen rij, en C2 tot de verborgen kolom; het voorbeeld drukt respectievelijk `false`, `true` en `true` af.

Voor dit voorbeeld vernieuwt u de grafiekgegevens na het wijzigen van de plot‑instelling: behoud het ingesloten werkboek met [readWorkbookStream](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdata/#readWorkbookStream--) en laad het opnieuw met [writeWorkbookStream](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-). Wanneer u alle cellen opneemt, gebruik dan ook [setRange](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) om het volledige bereik, inclusief de verborgen februari‑categorie, te herstellen. Alleen de vlag wijzigen is onvoldoende om de in dit voorbeeld gecachete grafiek‑ en categorielabels te vernieuwen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hidden-source-data.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        System.out.println("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        System.out.println("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        System.out.println("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        byte[] workbookData = chart.getChartData().readWorkbookStream();
        for (boolean visibleOnly : new boolean[] { true, false }) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // Ververs de grafiekgegevens vanuit het ingesloten werkboek.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Herstel het volledige bronbereik, inclusief verborgen categorieën.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", SaveFormat.Pptx);
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Het voorbeeld slaat `hidden_cells_true.pptx` op met alleen de zichtbare Retail‑waarden (10 en 20), en `hidden_cells_false.pptx` met alle zes waarden. De afbeeldingen hieronder illustreren de twee plot‑modi. Rij 3 en kolom C blijven verborgen in beide ingesloten werkboeken.

| Alleen zichtbare cellen (`true`) | Alle cellen (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

Een verborgen cel met een waarde verschilt van een lege cel. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) bepaalt hoe ontbrekende waarden worden weergegeven; het omvat of sluit geen verborgen brongegevens uit. Zie [Control the Display of Empty Cells](/slides/nl/java/chart-series/#control-the-display-of-empty-cells) voor een voorbeeld.

## **Grafiekgegevens lezen en schrijven vanuit een werkboek**

Aspose.Slides for Java biedt de methoden [readWorkbookStream](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdata/#readWorkbookStream--) en [writeWorkbookStream](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-) waarmee u grafiek‑werkboeken (bevatten grafiekgegevens bewerkt met Aspose.Cells) kunt lezen en schrijven. **Opmerking** dat de grafiekgegevens op dezelfde manier moeten zijn georganiseerd of een structuur moeten hebben die vergelijkbaar is met de bron.

Dit voorbeeld opent `chart.pptx`, dat een grafiek moet bevatten als eerste vorm op de eerste dia. Het leest het ingesloten werkboek in een byte‑array, wist de bestaande series en categorieën, en schrijft hetzelfde werkboek terug. De wijzigingen blijven in het geheugen; het voorbeeld slaat de presentatie niet op.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Grafiek‑indeling valideren na wijziging van werkboek**

Wanneer u een ingesloten werkboek vervangt door een aangepast werkboek, behoudt de grafiek de oorspronkelijke series‑ en categorieverzamelingen. Deze mismatch kan ervoor zorgen dat [IChart.validateChartLayout](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichart/#validateChartLayout--) faalt met een index‑out‑of‑range‑fout. Wis de bestaande series en categorieën voordat u het bijgewerkte werkboek terugschrijft naar de grafiek. Dit voorbeeld vereist `chart.pptx` met een grafiek als eerste vorm op de eerste dia. De commentaarregel markeert waar bewerking van het werkboek zou plaatsvinden; het uitvoerbare voorbeeld schrijft het originele werkboek terug en valideert de indeling in het geheugen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        // Pas hier de werkboekbytes aan, bijvoorbeeld met Aspose.Cells.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Het wissen van de verzamelingen verwijdert verouderde gegevensreferenties voordat het werkboek wordt weggeschreven. Bouw eventuele vereiste series‑ en categorietoewijzingen opnieuw op voor het bijgewerkte werkboek voordat u de grafiek gebruikt.

## **Een werkboekcel instellen als grafiek‑datatlabel**

U kunt tekst uit werkboekcellen gebruiken als grafiek‑datatlabels. De volgende stappen laten zien hoe u de labels in een bubbelfiguur koppelt aan cellen in het bijbehorende gegevens‑werkboek.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse.
2. Open de eerste dia via de nul‑gebaseerde index.
3. Voeg een bubbelfiguur toe met standaardgegevens.
4. Open de grafiekseries.
5. Stel de werkboekcel in als datatlabel.
6. Sla de presentatie op.

Dit voorbeeld opent `chart2.pptx`, dat minimaal één dia moet bevatten, en voegt een bubbelfiguur toe met standaardgegevens. Het gebruikt de cellen A10:A12 op werkblad 0 voor de eerste drie labels in de eerste serie, schakelt labels vanuit cellen in, en slaat het resultaat op als `resultchart.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Werkbladen beheren**

De methode [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) biedt toegang tot de werkbladen in een grafiek‑werkboek. Dit voorbeeld maakt een cirkeldiagram met standaardgegevens en drukt elke werkbladnaam af naar de console.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    for (int i = 0; i < workbook.getWorksheets().size(); i++) {
        System.out.println(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **Het gegevenstype van de bron opgeven**

Dit voorbeeld maakt een 3D‑kolomgrafiek met standaardgegevens en stelt twee serienaam­instellingen in met verschillende gegevensbronnen. De eerste naam gebruikt een string‑literal; de tweede gebruikt cel C1 op werkblad 0. De enumeratie [DataSourceType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/datasourcetype/) selecteert de bron voor elke naam. Het resultaat wordt opgeslagen als `pres.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    IStringChartValue cellName = chart.getChartData().getSeries().get_Item(1).getName();
    IChartDataCell nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Niet‑ondersteunde ingesloten werkboekformaten detecteren**

Aspose.Slides ondersteunt het Excel‑binaire werkboekformaat (.xlsb) niet, dat in sommige diagrammen kan worden ingesloten. U kunt de methode [getEmbeddedWorkbookType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) op [IChartData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdata/) gebruiken in combinatie met de enumeratie [WorkbookType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/workbooktype/) om niet‑ondersteunde formaten te detecteren en die diagrammen over te slaan. Dit voorbeeld inspecteert de vormen op de eerste dia van `sample.pptx`, slaat niet‑grafiek‑vormen over en geeft een diagnostisch bericht voor elk diagram met een ingesloten .xlsb‑werkboek.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IChartData chartData = chart.getChartData();
        boolean isInternalWorkbook = chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook;
        boolean isBinaryMacro = chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            System.out.println("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // Lees of bewerk ondersteunde grafiekwerkboekgegevens hier.
    }
} finally {
    presentation.dispose();
}
```

## **Extern werkboek**

Aspose.Slides ondersteunt het gebruik van externe werkboeken als gegevensbron voor grafieken.

### **Een extern werkboek maken**

Gebruik [readWorkbookStream](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdata/#readWorkbookStream--) en [setExternalWorkbook](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) om een ingesloten grafiek‑werkboek naar een bestand te exporteren en de grafiek te koppelen aan dat externe werkboek.

Dit voorbeeld maakt een cirkeldiagram met standaardgegevens, schrijft het werkboek naar `externalWorkbook1.xlsx`, en voltooit de bestands‑schrijft voordat het bestand als bron voor de grafiek wordt toegewezen. Het gekoppelde bestand wordt opgeslagen als `externalWorkbook.pptx`.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    Path workbookPath = Paths.get("externalWorkbook1.xlsx").toAbsolutePath();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        Files.write(workbookPath, workbookData);
        chart.getChartData().setExternalWorkbook(workbookPath.toString());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Een extern werkboek instellen**

Met de methode [setExternalWorkbook](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) kunt u een extern werkboek aan een grafiek toewijzen als gegevensbron. Deze methode kan ook worden gebruikt om een pad naar het externe werkboek bij te werken (als het bestand is verplaatst).

Hoewel u de gegevens in werkboeken die zich op externe locaties of resources bevinden niet kunt bewerken, kunt u dergelijke werkboeken wel als externe gegevensbron gebruiken. Als een relatief pad voor een extern werkboek wordt opgegeven, wordt dit automatisch omgezet naar een volledig pad.

Dit voorbeeld vereist `externalWorkbook.xlsx` in de werkdirectory. Het werkblad met de naam `Sheet1` moet een serienaam bevatten in B1, categorienamen in A2:A4, en numerieke waarden in B2:B4. Het voorbeeld maakt een cirkeldiagram, koppelt het werkboek, en gebruikt [setRange](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) om A1:B4 toe te wijzen aan één serie en drie categorieën. Het resultaat wordt opgeslagen als `Presentation_with_externalWorkbook.pptx`.

```java
import com.aspose.slides.*;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    String workbookPath = Paths.get("externalWorkbook.xlsx").toAbsolutePath().toString();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De parameter `updateChartData` van [setExternalWorkbook](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) bepaalt of het werkboek wordt geladen.

* Als `updateChartData` `false` is, wordt alleen het pad naar het werkboek bijgewerkt. De grafiekgegevens worden niet geladen of bijgewerkt vanuit het doel‑werkboek, zodat het werkboek niet beschikbaar hoeft te zijn.
* Als `updateChartData` `true` is, worden de grafiekgegevens bijgewerkt vanuit het doel‑werkboek.

Het volgende voorbeeld kent een tijdelijke URL toe met `updateChartData` ingesteld op `false`. Het behoudt de standaardgegevens van de cirkelgrafiek en slaat de presentatie op zonder het niet‑beschikbare werkboek te laden.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Het pad van het externe gegevensbron‑werkboek van een grafiek opvragen**

Om het werkboek dat aan een grafiek is gekoppeld te identificeren, controleert u eerst of de grafiek een externe gegevensbron gebruikt. Zo ja, dan kunt u het pad van het werkboek opvragen via de volgende stappen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse.
2. Open de eerste dia via de nul‑gebaseerde index.
3. Controleer of de eerste vorm een grafiek is.
4. Lees het gegevenstype van de grafiekbron.
5. Als de bron een extern werkboek is, lees dan het pad.

Dit voorbeeld opent `externalWorkbook.pptx`, gemaakt in het eerdere voorbeeld, en inspecteert de eerste vorm op de eerste dia. Als het een grafiek is die gekoppeld is aan een extern werkboek, drukt het voorbeeld [getExternalWorkbookPath](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) af naar de console. Vervolgens wordt een kopie van de presentatie opgeslagen als `Result.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("externalWorkbook.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        if (chartData.getDataSourceType() == ChartDataSourceType.ExternalWorkbook) {
            System.out.println(chartData.getExternalWorkbookPath());
        } else {
            System.out.println("The chart does not use an external workbook.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Grafiekgegevens bewerken**

U kunt de gegevens in externe werkboeken op dezelfde manier bewerken als de inhoud van interne werkboeken. Wanneer een extern werkboek niet kan worden geladen, wordt er een uitzondering gegooid.

Dit voorbeeld vereist `presentation.pptx` met een grafiek als eerste vorm op de eerste dia en een toegankelijk extern werkboek. Het stelt de cel‑gebaseerde waarde van het eerste gegevenspunt in de eerste serie in op 100 en slaat de presentatie op als `presentation_out.pptx`. Het bewerken van celwaarden kan het gekoppelde externe XLSX‑bestand bijwerken; gebruik een kopie als u het originele werkboek wilt behouden.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartSeriesCollection series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            IChartDataCell valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", SaveFormat.Pptx);
            } else {
                System.out.println("The first data point is not linked to a workbook cell.");
            }
        } else {
            System.out.println("The chart has no data points to edit.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Een werkboek herstellen uit de grafiek‑cache**

Als een grafiek een extern werkboek gebruikt dat ontbreekt of niet beschikbaar is, kan Aspose.Slides het werkboek van de grafiek reconstrueren uit de in de presentatie gecachete gegevens. Maak een [LoadOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/) object, roep [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) aan, en stel [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) in op `true` voordat u de presentatie opent.

Het volgende Java‑voorbeeld opent `presentation.pptx`, waarvan de eerste vorm op de eerste dia een grafiek moet zijn die verwijst naar een niet‑beschikbaar extern werkboek, en krijgt toegang tot de herstelde gegevens via [IChart.getChartData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichart/#getChartData--) en [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // Lees of bewerk hier de herstelde werkboekgegevens.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Als het externe werkboek niet beschikbaar is en herstel is uitgeschakeld, gooit Aspose.Slides een uitzondering. Schakel herstel alleen in wanneer het gebruik van de gecachete grafiekgegevens een aanvaardbare fallback is, omdat de cache mogelijk geen wijzigingen bevat die na de laatste update van de presentatie in het externe werkboek zijn aangebracht.

## **FAQ**

**Kan ik bepalen of een specifieke grafiek is gekoppeld aan een extern of een ingesloten werkboek?**

Ja. Een grafiek heeft een [data source type](https://reference.aspose.com/slides/nl/java/com.aspose.slides/chartdata/#getDataSourceType--) en een [path to an external workbook](https://reference.aspose.com/slides/nl/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); als de bron een extern werkboek is, kunt u het volledige pad lezen om zeker te zijn dat een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkboeken ondersteund, en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. De presentatie slaat het absolute pad op in het PPTX‑bestand, dus het verplaatsen van het werkboek kan vereisen dat de koppeling wordt bijgewerkt.

**Kan ik werkboeken gebruiken die zich op netwerklocaties of gedeelde mappen bevinden?**

Ja, zulke werkboeken kunnen als externe gegevensbron worden gebruikt. Het direct bewerken van remote werkboeken vanuit Aspose.Slides wordt echter niet ondersteund – ze kunnen alleen als bron worden gebruikt.

**Overschrijft Aspose.Slides het externe XLSX‑bestand bij het opslaan van de presentatie?**

De presentatie slaat een [link to the external file](https://reference.aspose.com/slides/nl/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) op. Het bewerken van cel‑gebaseerde grafiekgegevens kan ook het gekoppelde lokale XLSX‑bestand bijwerken. Gebruik een kopie van het werkboek als het origineel onveranderd moet blijven.

**Wat moet ik doen als het externe bestand met een wachtwoord is beveiligd?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gebruikelijke aanpak is om de beveiliging vooraf te verwijderen of een ontsleutelde kopie te maken (bijvoorbeeld met [Aspose.Cells](https://reference.aspose.com/cells/java/)) en naar die kopie te koppelen.

**Kunnen meerdere grafieken naar hetzelfde externe werkboek verwijzen?**

Ja. Elke grafiek slaat zijn eigen koppeling op. Als ze allemaal naar hetzelfde bestand wijzen, wordt een wijziging in dat bestand doorgevoerd in elke grafiek wanneer de gegevens opnieuw worden geladen.