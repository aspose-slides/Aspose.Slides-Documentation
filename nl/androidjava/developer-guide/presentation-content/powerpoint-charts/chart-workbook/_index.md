---
title: Beheer grafiekwerkboeken in presentaties op Android
linktitle: Grafiekwerkboek
type: docs
weight: 70
url: /nl/androidjava/chart-workbook/
keywords:
- grafiekwerkboek
- grafiekgegevens
- werkbladcel
- databelabel
- werkblad
- gegevensbron
- extern werkboek
- externe gegevens
- grafiekcache
- werkboekherstel
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Ontdek Aspose.Slides voor Android via Java: beheer moeiteloos grafiekwerkboeken in PowerPoint- en OpenDocument-formaten om uw presentatiedata te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u met grafiekwerkbladen in Aspose.Slides kunt werken. Het laat zien hoe u grafiekgegevens kunt lezen en schrijven via werkblad‑streams, werkbladcellen kunt gebruiken als grafiekdatabeetiketten, toegang krijgt tot werkbladenverzamelingen en het gegevenstype voor grafiekwaarden kunt opgeven.

Het behandelt ook het werken met externe werkbladen als gegevensbron voor grafieken. De voorbeelden tonen hoe u een extern werkblad kunt maken en toewijzen, het pad van een extern werkblad dat aan een grafiek is gekoppeld kunt opvragen, en grafiekgegevens kunt bewerken wanneer het werkblad beschikbaar is.

Voor werkbladcellen die ontbrekende gegevens vertegenwoordigen, zie [Regel de weergave van lege cellen](/slides/nl/androidjava/chart-series/) voor het verschil tussen een lege cel en nul, en een lijngrafiekvergelijking van de beschikbare weergavemodi.

## **Gegevens opnemen uit verborgen rijen en kolommen**

Gebruik [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) om te bepalen of een grafiek gegevens plot uit verborgen werkbladrijen en -kolommen. Stel in op `true` om alleen zichtbare cellen te plotten, of op `false` om zowel zichtbare als verborgen cellen op te nemen. Deze instelling regelt het plotten van de grafiek; hij verbergt of toont geen werkbladrijen of -kolommen.

Download [hidden-source-data.pptx](hidden-source-data.pptx) en plaats het in de werkmap. De eerste dia bevat een kolomgrafiek als eerste vorm. Het ingebedde werkblad, `Sheet1`, bevat het volgende bronbereik, `A1:C4`. Rij 3 en kolom C zijn verborgen, maar hun cellen bevatten nog steeds waarden.

| Werkbladrij | A: Maand | B: Detailhandel | C: Groothandel (verborgen kolom) |
| --- | --- | --- | --- |
| 2 | januari | 10 | 30 |
| 3 (verborgen rij) | februari | 40 | 60 |
| 4 | maart | 20 | 50 |

Toegang tot broncellen via [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) en lees [IChartDataCell.isHidden](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) om hun verborgen status te inspecteren. Deze methode meldt de verborgen status zonder deze te wijzigen. In dit bestand is B2 zichtbaar, B3 behoort tot de verborgen rij, en C2 tot de verborgen kolom; het voorbeeld print respectievelijk `false`, `true` en `true`.

Voor dit voorbeeld, ververst u de grafiekgegevens na het wijzigen van de plotinstelling: behoud het ingebedde werkblad met [readWorkbookStream](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) en laad het opnieuw met [writeWorkbookStream](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-). Bij het opnemen van alle cellen gebruikt u tevens [setRange](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) om het volledige bereik, inclusief de verborgen februari‑categorie, te herstellen. Alleen de vlag wijzigen is onvoldoende om de in dit voorbeeld gecachete grafiek‑ en categorielabels te vernieuwen.

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

            // Ververs de grafiekgegevens van het ingebedde werkblad.
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

Het voorbeeld slaat `hidden_cells_true.pptx` op met alleen de zichtbare detailhandelswaarden (10 en 20), en `hidden_cells_false.pptx` met alle zes waarden. De afbeeldingen hieronder illustreren de twee plotmodi. Rij 3 en kolom C blijven verborgen in beide ingebedde werkbladen.

| Alleen zichtbare cellen (`true`) | Alle cellen (`false`) |
| --- | --- |
| ![Alleen zichtbare cellen: detailhandelswaarden 10 en 20 voor januari en maart.](hidden_cells_True.png) | ![Alle cellen: detailhandels‑ en groothandelswaarden voor januari, februari en maart.](hidden_cells_False.png) |

Een verborgen cel met een waarde verschilt van een lege cel. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) bepaalt hoe ontbrekende waarden worden weergegeven; hij neemt geen verborgen brongegevens op of sluit ze uit. Zie [Regel de weergave van lege cellen](/slides/nl/androidjava/chart-series/#control-the-display-of-empty-cells) voor een voorbeeld.

## **Grafiekgegevens lezen en schrijven vanuit een werkblad**

Aspose.Slides for Android via Java biedt de [readWorkbookStream](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) en [writeWorkbookStream](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-) methoden waarmee u grafiek‑werkbladen (die grafiekgegevens bevatten bewerkt met Aspose.Cells) kunt lezen en schrijven. **Opmerking**: de grafiekgegevens moeten op dezelfde manier zijn georganiseerd of een structuur hebben die vergelijkbaar is met de bron.

Dit voorbeeld opent `chart.pptx`, dat een grafiek moet bevatten als eerste vorm op de eerste dia. Het leest het ingebedde werkblad in een byte‑array, wist de bestaande series en categorieën, en schrijft hetzelfde werkblad terug. De wijzigingen blijven alleen in het geheugen; het voorbeeld slaat de presentatie niet op.

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

### **Grafieklay‑out valideren na bewerking van het werkblad**

Wanneer u een ingebed werkblad vervangt door een aangepast werkblad, behoudt de grafiek de oorspronkelijke serie‑ en categorieverzamelingen. Deze mismatch kan ertoe leiden dat [IChart.validateChartLayout](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichart/#validateChartLayout--) faalt met een index‑out‑of‑range‑fout. Wis de bestaande series en categorieën voordat u het bijgewerkte werkblad terugschrijft naar de grafiek. Dit voorbeeld vereist `chart.pptx` met een grafiek als eerste vorm op de eerste dia. De commentaarregels markeren waar de bewerking van het werkblad zou plaatsvinden; het uitvoerbare voorbeeld schrijft het oorspronkelijke werkblad terug en valideert de lay‑out in het geheugen.

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

Het wissen van de verzamelingen verwijdert verouderde gegevensreferenties voordat het werkblad wordt teruggeschreven. Bouw eventuele vereiste serie‑ en categorietoewijzingen opnieuw op voor het bijgewerkte werkblad voordat u de grafiek gebruikt.

## **Een werkbladcel instellen als grafiekdatabelabel**

U kunt tekst uit werkbladcellen gebruiken als grafiekdatabelabels. De volgende stappen tonen hoe u de labels in een bubbelsgrafiek koppelt aan cellen in het bijbehorende gegevens‑werkblad.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse.
2. Open de eerste dia op basis van de nul‑gebaseerde index.
3. Voeg een bubbelsgrafiek toe met standaardgegevens.
4. Open de grafiekseries.
5. Stel de werkbladcel in als databelabel.
6. Sla de presentatie op.

Dit voorbeeld opent `chart2.pptx`, dat minstens één dia moet bevatten, en voegt een bubbelsgrafiek toe met standaardgegevens. Het gebruikt cellen A10:A12 op werkblad 0 voor de eerste drie labels in de eerste serie, schakelt labels vanuit cellen in, en slaat het resultaat op als `resultchart.pptx`.

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

De methode [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) biedt toegang tot de werkbladen in een grafiek‑werkboek. Dit voorbeeld maakt een taartgrafiek met standaardgegevens en drukt elke werkbladnaam af naar de console.

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

## **Gegevenstype van de gegevensbron opgeven**

Dit voorbeeld maakt een 3D‑kolomgrafiek met standaardgegevens en stelt twee serienamen in via verschillende gegevensbronnen. De eerste naam wordt ingesteld met een tekenreeks‑literal; de tweede met cel C1 op werkblad 0. De enumeratie [DataSourceType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/datasourcetype/) bepaalt de bron voor elke naam. Het resultaat wordt opgeslagen als `pres.pptx`.

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

## **Detecteren van niet‑ondersteunde ingebedde werkbladformaten**

Aspose.Slides ondersteunt het Excel‑binaire werkbladformaat (.xlsb) niet wanneer het in sommige grafieken is ingebed. U kunt de methode [getEmbeddedWorkbookType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) op [IChartData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdata/) gebruiken samen met de enumeratie [WorkbookType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/workbooktype/) om niet‑ondersteunde formaten te detecteren en die grafieken over te slaan. Dit voorbeeld inspecteert de vormen op de eerste dia van `sample.pptx`, slaat niet‑grafiekvormen over en drukt een diagnostisch bericht af voor elke grafiek met een ingebed .xlsb‑werkblad.

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

        // Lees of wijzig ondersteunde grafiekwerkboekgegevens hier.
    }
} finally {
    presentation.dispose();
}
```

## **Extern werkblad**

Aspose.Slides ondersteunt het gebruik van externe werkbladen als gegevensbron voor grafieken.

### **Een extern werkblad aanmaken**

Gebruik [readWorkbookStream](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) en [setExternalWorkbook](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) om een ingebed grafiek‑werkblad naar een bestand te exporteren en de grafiek aan dat externe werkblad te koppelen.

Dit voorbeeld maakt een taartgrafiek met standaardgegevens, schrijft het werkblad naar `externalWorkbook1.xlsx`, en voltooit de bestands­schrijfbewerking voordat het bestand als gegevensbron voor de grafiek wordt toegewezen. Het slaat de gekoppelde presentatie op als `externalWorkbook.pptx`.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    File workbookFile = new File("externalWorkbook1.xlsx").getAbsoluteFile();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        try (FileOutputStream workbookStream = new FileOutputStream(workbookFile)) {
            workbookStream.write(workbookData);
        }
        chart.getChartData().setExternalWorkbook(workbookFile.getAbsolutePath());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Extern werkblad instellen**

Met de methode [setExternalWorkbook](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) kunt u een extern werkblad aan een grafiek toewijzen als diens gegevensbron. Deze methode kan ook worden gebruikt om een pad naar het externe werkblad bij te werken (indien het bestand is verplaatst).

Hoewel u de gegevens in werkbladen die op externe locaties of bronnen staan niet kunt bewerken, kunt u dergelijke werkbladen wel gebruiken als externe gegevensbron. Als een relatief pad voor een extern werkblad wordt opgegeven, wordt dit automatisch omgezet naar een volledig pad.

Dit voorbeeld vereist `externalWorkbook.xlsx` in de werkmap. Het werkblad met de naam `Sheet1` moet een serienaam bevatten in B1, categorienamen in A2:A4, en numerieke waarden in B2:B4. Het voorbeeld maakt een taartgrafiek, koppelt het werkblad, en gebruikt [setRange](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) om A1:B4 naar één serie en drie categorieën te mappen. Het slaat het resultaat op als `Presentation_with_externalWorkbook.pptx`.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    File workbookFile = new File("externalWorkbook.xlsx");
    String workbookPath = workbookFile.getAbsolutePath();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De parameter `updateChartData` van [setExternalWorkbook](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) bepaalt of het werkblad wordt geladen.

* Wanneer `updateChartData` `false` is, wordt alleen het pad van het werkblad bijgewerkt. De grafiekgegevens worden niet geladen of bijgewerkt vanuit het doel‑werkblad, zodat het werkblad onbeschikbaar kan zijn.
* Wanneer `updateChartData` `true` is, worden de grafiekgegevens bijgewerkt vanuit het doel‑werkblad.

Het volgende voorbeeld wijst een tijdelijke URL toe met `updateChartData` ingesteld op `false`. Het behoudt de standaardgegevens van de taartgrafiek en slaat de presentatie op zonder het onbeschikbare werkblad te laden.

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

### **Het pad van de externe gegevensbron‑werkblad van een grafiek ophalen**

Om het werkblad te identificeren dat aan een grafiek is gekoppeld, controleert u eerst of de grafiek een externe gegevensbron gebruikt. Zo ja, dan kunt u het pad van het werkblad ophalen door de volgende stappen te volgen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse.
2. Open de eerste dia op basis van de nul‑gebaseerde index.
3. Controleer of de eerste vorm een grafiek is.
4. Lees het type gegevensbron van de grafiek.
5. Als de bron een extern werkblad is, lees dan het pad.

Dit voorbeeld opent `externalWorkbook.pptx`, aangemaakt in het vorige voorbeeld, en inspecteert de eerste vorm op de eerste dia. Als het een grafiek is die is gekoppeld aan een extern werkblad, print het voorbeeld [getExternalWorkbookPath](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) naar de console. Vervolgens wordt een kopie van de presentatie opgeslagen als `Result.pptx`.

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

U kunt de gegevens in externe werkbladen bewerken op dezelfde manier als u wijzigingen aanbrengt in de inhoud van interne werkbladen. Wanneer een extern werkblad niet kan worden geladen, wordt een uitzondering gegooid.

Dit voorbeeld vereist `presentation.pptx` met een grafiek als eerste vorm op de eerste dia en een toegankelijk extern werkblad. Het stelt de cel‑gebaseerde waarde van het eerste gegevenspunt in de eerste serie in op 100 en slaat de presentatie op als `presentation_out.pptx`. Het bewerken van celwaarden kan het gekoppelde externe XLSX‑bestand bijwerken; gebruik een kopie als u het originele werkblad moet behouden.

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

### **Een werkblad herstellen vanuit de grafiek‑cache**

Als een grafiek een extern werkblad gebruikt dat ontbreekt of niet beschikbaar is, kan Aspose.Slides het grafiek‑werkblad reconstrueren vanuit de in de presentatie gecachede gegevens. Maak een [LoadOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadoptions/) object, roep [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) aan, en stel [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) in op `true` voordat u de presentatie opent.

Het volgende Java‑voorbeeld opent `presentation.pptx`, waarvan de eerste vorm op de eerste dia een grafiek moet zijn die een niet‑beschikbaar extern werkblad referentiert, en krijgt de herstelde gegevens via [IChart.getChartData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichart/#getChartData--) en [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

        // Lees of wijzig hier de herstelde werkboekgegevens.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Als het externe werkblad niet beschikbaar is en herstel is uitgeschakeld, gooit Aspose.Slides een uitzondering. Schakel herstel alleen in wanneer het gebruik van de gecachede grafiekgegevens een acceptabele fallback is, omdat de cache mogelijk geen wijzigingen bevat die na de laatste updates van de presentatie in het externe werkblad zijn aangebracht.

## **FAQ**

**Kan ik bepalen of een specifieke grafiek is gekoppeld aan een extern of een ingebed werkblad?**

Ja. Een grafiek heeft een [data source type](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) en een [path to an external workbook](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); als de bron een extern werkblad is, kunt u het volledige pad lezen om te bevestigen dat een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkbladen ondersteund en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. De presentatie slaat het absolute pad op in het PPTX‑bestand, dus het verplaatsen van het werkblad kan vereisen dat de link wordt bijgewerkt.

**Kan ik werkbladen gebruiken die op netwerk‑resources of gedeelde mappen staan?**

Ja, dergelijke werkbladen kunnen worden gebruikt als externe gegevensbron. Bewerken van remote werkbladen rechtstreeks vanuit Aspose.Slides wordt echter niet ondersteund – ze kunnen alleen als bron dienen.

**Schrijft Aspose.Slides het externe XLSX‑bestand overschreven bij het opslaan van de presentatie?**

De presentatie slaat een [link to the external file](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) op. Het bewerken van cel‑gebaseerde grafiekgegevens kan ook het gekoppelde lokale XLSX‑bestand bijwerken. Gebruik een kopie van het werkblad als het origineel onveranderd moet blijven.

**Wat moet ik doen als het externe bestand met een wachtwoord is beschermd?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gangbare aanpak is om de bescherming vooraf te verwijderen of een gedecrypteerde kopie voor te bereiden (bijvoorbeeld met [Aspose.Cells](https://reference.aspose.com/cells/java/)) en die kopie te koppelen.

**Kunnen meerdere grafieken dezelfde externe werkmap refereren?**

Ja. Elke grafiek slaat zijn eigen link op. Als ze allemaal naar hetzelfde bestand wijzen, wordt een wijziging van dat bestand in elke grafiek weerspiegeld bij de volgende gegevenslading.