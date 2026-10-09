---
title: Beheer grafiekwerkboeken in presentaties op Android
linktitle: Grafiekwerkboek
type: docs
weight: 70
url: /nl/androidjava/chart-workbook/
keywords:
- grafiekwerkboek
- grafiekgegevens
- werkboekcel
- databelabel
- werkblad
- gegevensbron
- extern werkboek
- externe gegevens
- grafiekcache
- herstel van werkboek
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Ontdek Aspose.Slides voor Android via Java: beheer moeiteloos grafiekwerkboeken in PowerPoint- en OpenDocument-formaten om uw presentatiedata te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u met grafiek‑werkboeken werkt in Aspose.Slides. Het laat zien hoe u grafiekgegevens leest en schrijft via werkboek‑streams, werkboek‑cellen gebruikt als grafiek‑datablad‑labels, werkblad‑collecties benadert en het gegevenstype‑bron voor grafiekwaarden specificeert.

Het behandelt ook het gebruik van externe werkboeken als gegevensbron voor grafieken. De voorbeelden laten zien hoe u een extern werkboek maakt en toewijst, het pad van een extern werkboek dat aan een grafiek is gekoppeld opvraagt, en grafiekgegevens bewerkt wanneer het werkboek beschikbaar is.

Voor werkboek‑cellen die ontbrekende gegevens vertegenwoordigen, zie [De weergave van lege cellen beheren](/slides/nl/androidjava/chart-series/) voor het verschil tussen een lege cel en nul, en een lijngrafiek‑vergelijking van de beschikbare weergavemodi.

## **Gegevens opnemen uit verborgen rijen en kolommen**

Gebruik [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) om te bepalen of een grafiek gegevens plot uit verborgen werkblad‑rijen en -kolommen. Stel in op `true` om alleen zichtbare cellen te plotten, of op `false` om zowel zichtbare als verborgen cellen op te nemen. Deze instelling bepaalt het plotten van de grafiek; hij verbergt of toont geen werkblad‑rijen of -kolommen.

De [voorbeeldpresentatie](hidden-source-data.pptx) bevat een kolomgrafiek als het eerste object op de eerste dia. Het ingesloten werkblad, `Sheet1`, bevat het volgende bronbereik, `A1:C4`. Rij 3 en kolom C zijn verborgen, maar hun cellen bevatten nog steeds waarden.

| Werkblad‑rij | A: Maand | B: Detailhandel | C: Groothandel (verborgen kolom) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (verborgen rij) | February | 40 | 60 |
| 4 | March | 20 | 50 |

Benader broncellen via [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) en lees [IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) om hun verborgen‑status te inspecteren. Deze methode rapporteert de verborgen‑status zonder deze te wijzigen. In dit bestand is B2 zichtbaar, B3 behoort tot de verborgen rij, en C2 tot de verborgen kolom; het voorbeeld geeft respectievelijk `false`, `true` en `true` weer.

Voor dit voorbeeld, ververst u de grafiekgegevens na het wijzigen van de plot‑instelling: behoud het ingesloten werkboek met [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) en laad het opnieuw met [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---). Wanneer u alle cellen opneemt, gebruik dan ook [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) om het volledige bereik te herstellen, inclusief de verborgen februari‑categorie. Alleen het aanpassen van de vlag is onvoldoende om de in het voorbeeld gecachete grafiekgegevens en categorie‑labels te verversen.

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

Het voorbeeld slaat twee versies van de presentatie op: één met alleen de zichtbare detailhandelswaarden (10 en 20) en een andere met alle zes waarden. De afbeeldingen hieronder illustreren de twee plot‑modi. Rij 3 en kolom C blijven verborgen in beide ingesloten werkboeken.

| Alleen zichtbare cellen (`true`) | Alle cellen (`false`) |
| --- | --- |
| ![Alleen zichtbare cellen: Detailhandelswaarden 10 en 20 voor januari en maart.](hidden_cells_True.png) | ![Alle cellen: Detailhandels‑ en groothandelswaarden voor januari, februari en maart.](hidden_cells_False.png) |

Een verborgen cel die een waarde bevat, verschilt van een lege cel. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) bepaalt hoe ontbrekende waarden worden weergegeven; hij neemt geen verborgen brongegevens op of sluit ze uit. Zie [De weergave van lege cellen beheren](/slides/nl/androidjava/chart-series/#control-the-display-of-empty-cells) voor een voorbeeld.

## **Bereik van grafiekgegevens ophalen**

Voordat u werkboek‑gegevens bijwerkt in een bestaande presentatie, inspecteert u de bronbereiken om te bepalen welke werkblad‑cellen elke grafiek gebruikt. De methode [IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--) retourneert het huidige gegevens‑bereik als een werkblad‑gekwalificeerde formule, bijvoorbeeld `Sheet1!$A$1:$D$5`. Hier is `Sheet1` de werkbladnaam, `!` scheidt deze van het celbereik, en `$A$1:$D$5` geeft de cellen A1 tot en met D5 weer, inclusief. De dollartekens duiden absolute rij‑ en kolom‑referenties aan.

De methode leest het huidige bereik zonder de grafiek of het werkboek te wijzigen. Als de grafiek geen werkboek als gegevensbron gebruikt, wordt een `InvalidOperationException` gegooid. Zie voor meer informatie de [ChartData API‑referentie](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/).

Dit voorbeeld opent een presentatie en controleert de objecten direct op elke dia voor grafieken. Het geeft de naam en het bronbereik van elke grafiek weer. Als een grafiek geen werkboek gebruikt, wordt een bericht weergegeven en gaat de loop door naar de volgende grafiek.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.InvalidOperationException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                try {
                    String range = chart.getChartData().getRange();
                    System.out.println(chart.getName() + ": " + range);
                } catch (InvalidOperationException exception) {
                    System.out.println(chart.getName() + ": The chart does not use a workbook as its data source.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Grafiekgegevens lezen en schrijven vanuit een werkboek**

Aspose.Slides for Android via Java biedt de methoden [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) en [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) waarmee u grafiek‑werkboeken (bevatten grafiekgegevens bewerkt met Aspose.Cells) kunt lezen en schrijven. **Opmerking**: de grafiekgegevens moeten op dezelfde manier georganiseerd zijn of een structuur hebben die vergelijkbaar is met de bron.

Dit voorbeeld gebruikt een presentatie met een grafiek als het eerste object op de eerste dia. Het leest het ingesloten werkboek in een byte‑array, wist de bestaande series en categorieën, en schrijft hetzelfde werkboek terug. De wijzigingen blijven in het geheugen; het voorbeeld slaat de presentatie niet op.

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

### **Grafieklay‑out valideren na werkboek‑aanpassing**

Wanneer u een ingesloten werkboek vervangt door een aangepast werkboek, behoudt de grafiek zijn oorspronkelijke series‑ en categorie‑collecties. Deze mismatch kan ertoe leiden dat [IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--) faalt met een index‑out‑of‑range‑fout. Wis de bestaande series en categorieën voordat u het bijgewerkte werkboek terugschrijft naar de grafiek. Dit voorbeeld gebruikt een grafiek die het eerste object op de eerste dia is. Het commentaar markeert waar de werkboekbewerking zou plaatsvinden; het uitvoerbare voorbeeld schrijft het oorspronkelijke werkboek terug en valideert de lay‑out in het geheugen.

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

        // Wijzig hier de workbook-bytes, bijvoorbeeld met Aspose.Cells.

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

Het wissen van de collecties verwijdert verouderde gegevensreferenties voordat het werkboek wordt weggeschreven. Bouw eventuele vereiste series‑ en categorie‑toewijzingen opnieuw op voor het bijgewerkte werkboek voordat u de grafiek gebruikt.

## **Een werkboekcel instellen als grafiek‑databelabel**

U kunt tekst uit werkboekcellen gebruiken als grafiek‑databelabels.

Dit voorbeeld voegt een bubbelgrafiek met standaardgegevens toe aan de eerste dia van een bestaande presentatie. Het gebruikt cellen A10:A12 op werkblad 0 voor de eerste drie labels in de eerste serie, schakelt labels vanuit cellen in, en slaat de bijgewerkte presentatie op.

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

De methode [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) biedt toegang tot de werkbladen in een grafiek‑werkboek. Dit voorbeeld maakt een cirkeldiagram met standaardgegevens en drukt de naam van elk werkblad af naar de console.

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

## **Gegevenstype‑bron specificeren**

Dit voorbeeld maakt een 3D‑kolomgrafiek met standaardgegevens en stelt twee series‑namen in met verschillende gegevensbronnen. De eerste naam gebruikt een tekenreeks‑literal; de tweede gebruikt cel C1 op werkblad 0. De enumeratie [DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) selecteert de bron voor elke naam. Het voorbeeld slaat de presentatie op met de bijgewerkte series‑namen.

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

## **Niet‑ondersteunde ingesloten werkboek‑formaten detecteren**

Aspose.Slides ondersteunt het Excel‑binaire werkboek‑formaat (.xlsb) niet, dat in sommige grafieken kan worden ingesloten. U kunt de methode [getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) op [IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/) samen met de enumeratie [WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/) gebruiken om niet‑ondersteunde formaten te detecteren en die grafieken over te slaan. Dit voorbeeld inspecteert de objecten op de eerste dia van een bestaande presentatie, slaat niet‑grafiek‑objecten over, en drukt een diagnostisch bericht af voor elke grafiek met een ingesloten .xlsb‑werkboek.

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

        // Lees of wijzig hier de ondersteunde grafiek‑werkboekgegevens.
    }
} finally {
    presentation.dispose();
}
```

## **Extern werkboek**

Aspose.Slides ondersteunt het gebruik van externe werkboeken als gegevensbron voor grafieken.

### **Een extern werkboek maken**

Gebruik [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) en [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) om een ingesloten grafiek‑werkboek naar een bestand te exporteren en de grafiek aan dat externe werkboek te koppelen.

Dit voorbeeld maakt een cirkeldiagram met standaardgegevens en exporteert het werkboek. Het voltooit het schrijven van het bestand voordat het externe werkboek als gegevensbron van de grafiek wordt toegewezen, waarna het de gekoppelde presentatie opslaat.

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

### **Een extern werkboek instellen**

Met de methode [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) kunt u een extern werkboek aan een grafiek toewijzen als gegevensbron. Deze methode kan ook worden gebruikt om een pad naar het externe werkboek bij te werken (als het laatste is verplaatst).

Hoewel u de gegevens in werkboeken die zich op externe locaties of resources bevinden niet kunt bewerken, kunt u die werkboeken wel als externe gegevensbron gebruiken. Als een relatief pad voor een extern werkboek wordt opgegeven, wordt dit automatisch omgezet naar een volledig pad.

Dit voorbeeld gebruikt een extern werkboek waarvan het werkblad `Sheet1` een seriesnaam in B1, categorienamen in A2:A4 en numerieke waarden in B2:B4 bevat. Het voorbeeld maakt een cirkeldiagram, koppelt het werkboek, en gebruikt [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) om A1:B4 te koppelen aan één serie en drie categorieën. Het slaat de presentatie op met de gekoppelde grafiek.

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

De parameter `updateChartData` van [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) bepaalt of het werkboek wordt geladen.

* Wanneer `updateChartData` `false` is, wordt alleen het werkboekpad bijgewerkt. De grafiekgegevens worden niet geladen of bijgewerkt vanuit het doel‑werkboek, zodat het werkboek onbeschikbaar kan zijn.
* Wanneer `updateChartData` `true` is, worden de grafiekgegevens bijgewerkt vanuit het doel‑werkboek.

Het volgende voorbeeld kent een tijdelijke URL toe met `updateChartData` ingesteld op `false`. Het behoudt de standaardgegevens van de cirkelgrafiek en slaat de presentatie op zonder het onbeschikbare werkboek te laden.

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

### **Het pad van de externe gegevensbron‑werkboek van een grafiek ophalen**

Om het werkboek dat aan een grafiek is gekoppeld te identificeren, controleert u of de grafiek een externe gegevensbron gebruikt en haalt u het werkboekpad op.

Dit voorbeeld inspecteert het eerste object op de eerste dia van een presentatie met een gekoppeld extern werkboek. Als het een grafiek gekoppeld aan een extern werkboek is, drukt het voorbeeld [getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) af naar de console. Vervolgens slaat het een kopie van de presentatie op.

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

U kunt de gegevens in externe werkboeken bewerken op dezelfde manier als u wijzigingen aanbrengt in de inhoud van interne werkboeken. Als een extern werkboek niet kan worden geladen, wordt er een uitzondering gegooid.

Dit voorbeeld gebruikt een grafiek die het eerste object op de eerste dia is en gekoppeld is aan een toegankelijk extern werkboek. Het stelt de cel‑ondersteunde waarde van het eerste datumpunt in de eerste serie in op 100 en slaat de bijgewerkte presentatie op. Het bewerken van celwaarden kan het gekoppelde externe XLSX‑bestand bijwerken; gebruik daarom een kopie als u het oorspronkelijke werkboek moet behouden.

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

### **Een werkboek van de grafiek‑cache herstellen**

Als een grafiek een extern werkboek gebruikt dat ontbreekt of onbeschikbaar is, kan Aspose.Slides het grafiek‑werkboek reconstrueren vanuit de in de presentatie gecachete gegevens. Maak [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) aan, roep [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) aan, en stel [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) in op `true` vóór het openen van de presentatie.

Het volgende Java‑voorbeeld herstelt werkboekgegevens voor een grafiek die het eerste object op de eerste dia is en verwijst naar een onbeschikbaar extern werkboek. Het benadert de herstelde gegevens via [IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) en [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

Als het externe werkboek onbeschikbaar is en herstel is uitgeschakeld, gooit Aspose.Slides een uitzondering. Schakel herstel alleen in wanneer het gebruik van de gecachete grafiekgegevens een acceptabele fallback is, omdat de cache mogelijk geen wijzigingen bevat die in het externe werkboek zijn aangebracht na de laatste update van de presentatie.

## **FAQ**

**Kan ik bepalen of een specifieke grafiek is gekoppeld aan een extern of een ingesloten werkboek?**

Ja. Een grafiek heeft een [gegevensbron‑type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) en een [pad naar een extern werkboek](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); als de bron een extern werkboek is, kunt u het volledige pad uitlezen om te bevestigen dat een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkboeken ondersteund, en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. De presentatie slaat het absolute pad op in het PPTX‑bestand, zodat het verplaatsen van het werkboek mogelijk een bijwerking van de koppeling vereist.

**Kan ik werkboeken op netwerk‑resources of gedeelde stations gebruiken?**

Ja, dergelijke werkboeken kunnen als externe gegevensbron worden gebruikt. Het direct bewerken van remote werkboeken vanuit Aspose.Slides wordt echter niet ondersteund – ze kunnen alleen als bron dienen.

**Overschrijft Aspose.Slides het externe XLSX‑bestand bij het opslaan van de presentatie?**

De presentatie slaat een [koppeling naar het externe bestand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) op. Het bewerken van cel‑ondersteunde grafiekgegevens kan ook het gekoppelde lokale XLSX‑bestand bijwerken. Gebruik een kopie van het werkboek als het origineel onveranderd moet blijven.

**Wat moet ik doen als het externe bestand met een wachtwoord is beveiligd?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een veelgebruikte aanpak is om de beveiliging vooraf te verwijderen of een ontsleutelde kopie (bijvoorbeeld met [Aspose.Cells](https://reference.aspose.com/cells/java/)) te maken en die kopie te koppelen.

**Kunnen meerdere grafieken naar hetzelfde externe werkboek verwijzen?**

Ja. Elke grafiek slaat zijn eigen koppeling op. Als ze allemaal naar hetzelfde bestand wijzen, wordt een wijziging van dat bestand in elke grafiek weerspiegeld de volgende keer dat de gegevens worden geladen.