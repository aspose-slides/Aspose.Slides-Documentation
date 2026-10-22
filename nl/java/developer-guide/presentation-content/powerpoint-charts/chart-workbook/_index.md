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
- datummarkering
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
description: "Ontdek Aspose.Slides voor Java: beheer moeiteloos grafiekwerkboeken in PowerPoint- en OpenDocument-formaten om uw presentatiedata te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u kunt werken met grafiek‑werkboeken in Aspose.Slides. Het laat zien hoe u grafiekgegevens kunt lezen en schrijven via werkboek‑streams, werkboekcellen kunt gebruiken als grafiekdatummarkeringen, werkbladcollecties kunt benaderen en het type gegevensbron voor grafiekwaarden kunt opgeven.

Het behandelt ook het werken met externe werkboeken als gegevensbron voor grafieken. De voorbeelden tonen hoe u een extern werkboek maakt en toekent, het pad van een extern werkboek dat aan een grafiek is gekoppeld opvraagt en grafiekgegevens bewerkt wanneer het werkboek beschikbaar is.

Voor werkboekcellen die ontbrekende gegevens vertegenwoordigen, zie [De weergave van lege cellen](/slides/nl/java/chart-series/) voor het verschil tussen een lege cel en nul, en een lijngrafiekvergelijking van de beschikbare weergavemodi.

## **Gegevens opnemen uit verborgen rijen en kolommen**

Gebruik [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) om te bepalen of een grafiek gegevens plot vanuit verborgen werkblad‑rijen en -kolommen. Stel in op `true` om alleen zichtbare cellen te plotten, of op `false` om zowel zichtbare als verborgen cellen op te nemen. Deze instelling bepaalt het plotten van de grafiek; hij verbergt of maakt geen werkblad‑rijen of -kolommen zichtbaar.

De [voorbeeldpresentatie](hidden-source-data.pptx) bevat een kolomgrafiek als eerste vorm op de eerste dia. Het ingesloten werkblad, `Sheet1`, bevat het volgende bronbereik, `A1:C4`. Rij 3 en kolom C zijn verborgen, maar hun cellen bevatten nog steeds waarden.

| Werkbladrij | A: Maand | B: Detailhandel | C: Groothandel (verborgen kolom) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (verborgen rij) | February | 40 | 60 |
| 4 | March | 20 | 50 |

Benader broncellen via [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) en lees [IChartDataCell.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#isHidden--) om hun verborgen status te inspecteren. Deze methode meldt de verborgen status zonder deze te wijzigen. In dit bestand is B2 zichtbaar, B3 behoort tot de verborgen rij en C2 tot de verborgen kolom; het voorbeeld geeft respectievelijk `false`, `true` en `true` weer.

Voor dit voorbeeld ververst u de grafiekgegevens nadat u de plot‑instelling hebt gewijzigd: behoud het ingesloten werkboek met [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) en laad het opnieuw met [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---). Wanneer u alle cellen opneemt, gebruik dan ook [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) om het volledige bereik te herstellen, inclusief de verborgen februari‑categorie. Alleen de vlag wijzigen is onvoldoende om de in cache opgeslagen grafiekgegevens en categorielabels in dit voorbeeld te verversen.

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

            // Vernieuw de grafiekgegevens vanuit het ingesloten werkboek.
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

Het voorbeeld slaat twee versies van de presentatie op: één met alleen de zichtbare detailhandelswaarden (10 en 20), en een andere met alle zes waarden. De afbeeldingen hieronder illustreren de twee plot‑modi. Rij 3 en kolom C blijven verborgen in beide ingesloten werkboeken.

| Alleen zichtbare cellen (`true`) | Alle cellen (`false`) |
| --- | --- |
| ![Alleen zichtbare cellen: Detailhandelswaarden 10 en 20 voor januari en maart.](hidden_cells_True.png) | ![Alle cellen: Detailhandels‑ en groothandelswaarden voor januari, februari en maart.](hidden_cells_False.png) |

Een verborgen cel met een waarde verschilt van een lege cel. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) bepaalt hoe ontbrekende waarden worden weergegeven; hij neemt geen verborgen brongegevens op of sluit ze uit. Zie [De weergave van lege cellen](/slides/nl/java/chart-series/#control-the-display-of-empty-cells) voor een voorbeeld.

## **Gegevensbereik van een grafiek ophalen**

Voordat u werkboekgegevens bijwerkt in een bestaande presentatie, inspecteert u de bronbereiken om te bepalen welke werkbladcellen elke grafiek gebruikt. De [IChartData.getRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getRange--)‑methode geeft het huidige gegevensbereik terug als een werkblad‑gekwalificeerde formule, zoals `Sheet1!$A$1:$D$5`. Hier is `Sheet1` de naam van het werkblad, `!` scheidt het van het celbereik en `$A$1:$D$5` identificeert de cellen A1 tot en met D5, inclusief. De dollartekens geven absolute rij‑ en kolomreferenties aan.

De methode leest het huidige bereik zonder de grafiek of het werkboek te wijzigen. Als de grafiek geen werkboek als gegevensbron gebruikt, wordt `InvalidOperationException` gegooid. Voor meer informatie, zie de [ChartData API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/).

Dit voorbeeld opent een presentatie en controleert de vormen direct op elke dia voor grafieken. Het drukt de naam en het bronbereik van elke grafiek af. Als een grafiek geen werkboek gebruikt, geeft het een bericht weer en gaat door naar de volgende grafiek.

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

Aspose.Slides for Java biedt de [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) en [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---)‑methoden waarmee u werkboeken met grafiekgegevens (die bewerkt zijn met Aspose.Cells) kunt lezen en schrijven. **Opmerking** dat de grafiekgegevens op dezelfde manier moeten zijn georganiseerd of een structuur moeten hebben die vergelijkbaar is met de bron.

Dit voorbeeld gebruikt een presentatie met een grafiek als eerste vorm op de eerste dia. Het leest het ingesloten werkboek in een byte‑array, wist de bestaande reeksen en categorieën, en schrijft hetzelfde werkboek terug. De wijzigingen blijven in het geheugen; het voorbeeld slaat de presentatie niet op.

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

### **Grafieklay-out valideren na wijziging van werkboek**

Wanneer u een ingesloten werkboek vervangt door een aangepast werkboek, behoudt de grafiek de oorspronkelijke reeks‑ en categorieverzamelingen. Deze discrepantie kan ervoor zorgen dat [IChart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#validateChartLayout--) faalt met een index‑out‑of‑range‑fout. Wis de bestaande reeksen en categorieën voordat u het bijgewerkte werkboek terugschrijft naar de grafiek. Dit voorbeeld gebruikt een grafiek die de eerste vorm is op de eerste dia. Het commentaar markeert waar bewerking van het werkboek zou plaatsvinden; het uitvoerbare voorbeeld schrijft het oorspronkelijke werkboek terug en valideert de lay-out in het geheugen.

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

Het wissen van de verzamelingen verwijdert verouderde gegevensreferenties voordat het werkboek wordt weggeschreven. Herbouw eventuele benodigde reeks‑ en categorietoewijzingen voor het bijgewerkte werkboek voordat u de grafiek gebruikt.

## **Aangepaste getalnotaties instellen voor werkboekcellen**

Gebruik [IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) om te bepalen hoe numerieke waarden verschijnen in het ingesloten werkboek van een grafiek. Bijvoorbeeld, een rapport kan een conversieratio nodig hebben die als een percentage met vier decimalen wordt weergegeven en een coëfficiënt met vijf decimalen. Houd beide waarden numeriek zodat ze beschikbaar blijven voor berekeningen en grafiekplotting.

Een getalnotatie wijzigt de weergave, niet de opgeslagen waarde. De notatie `0.0000%` toont `0.125` als `12.5000%`; hij vervangt het opgeslagen getal niet door `12.5`. Evenzo toont `0.00000` `0.1234567` als `0.12346` zonder de opgeslagen waarde af te ronden. Als de aangepaste notatie een lege tekenreeks is (`""`), wordt de notatie die wordt geretourneerd door [getPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--) gebruikt.

Het volgende voorbeeld maakt een kolomgrafiek en benadert de cellen via [getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--). Op werkblad 0 bevat B2 de conversieratio en C2 de coëfficiënt. Beide cellen leveren grafiekwaarden. Het voorbeeld schakelt ook waardelabels in die zijn gekoppeld aan de bronnotaties.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210);
    chart.setTitle(false);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00");
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(0);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell categoryCell = workbook.getCell(0, "A2", "Sample");
    chart.getChartData().getCategories().add(categoryCell);

    IChartDataCell percentageCell = workbook.getCell(0, "B2", 0.125);
    percentageCell.setCustomNumberFormat("0.0000%");
    IChartDataCell percentageName = workbook.getCell(0, "B1", "Conversion rate");
    IChartSeries percentageSeries = chart.getChartData().getSeries().add(percentageName, chart.getType());
    percentageSeries.getDataPoints().addDataPointForBarSeries(percentageCell);

    IChartDataCell precisionCell = workbook.getCell(0, "C2", 0.1234567);
    precisionCell.setCustomNumberFormat("0.00000");
    IChartDataCell precisionName = workbook.getCell(0, "C1", "Coefficient");
    IChartSeries precisionSeries = chart.getChartData().getSeries().add(precisionName, chart.getType());
    precisionSeries.getDataPoints().addDataPointForBarSeries(precisionCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat labelFormat = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(true);
    }

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Werkboekcel‑notaties staan los van notaties die direct op grafiekassen of datalabels zijn ingesteld. In dit voorbeeld toont elk label de waarde van de broncel omdat [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) is ingesteld op `true`, en de brongetalnotatie volgt omdat [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) is ingesteld op `true`. Na het opslaan en opnieuw openen van de presentatie tonen de labels `12.5000%` en `0.12346`, zoals hieronder weergegeven. De verticale as gebruikt zijn eigen getalnotatie, toegewezen met [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) als `0.00`, waarbij [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) is ingesteld op `false`.

Om een datalabel onafhankelijk te formatteren, zet u de bron‑koppeling op `false` en kent u een notatie toe met [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-). Dit verandert de notatie van de werkboekcel niet. Bijvoorbeeld, een onafhankelijke labelnotatie van `0.00` toont de eerste waarde als `0.13`, terwijl B2 nog steeds `12.5000%` weergeeft. Zie [Grafiekdatummarkeringen](/slides/nl/java/chart-data-label/#set-percentage-sign-with-chart-data-labels) voor directe labelformattering.

De afbeelding hieronder is gerenderd vanuit de opgeslagen presentatie na het opnieuw openen:

![Kolomgrafiek met bron‑gekoppelde labels die 12.5000% en 0.12346 tonen en een onafhankelijk geformatteerde numerieke as.](custom-cell-formats.png)

## **Een werkboekcel instellen als grafiekdatummarkering**

U kunt tekst uit werkboekcellen gebruiken als grafiekdatummarkeringen.

Dit voorbeeld voegt een bolgrafiek met standaardgegevens toe aan de eerste dia van een bestaande presentatie. Het gebruikt de cellen A10:A12 op werkblad 0 voor de eerste drie labels in de eerste reeks, schakelt labels vanuit cellen in, en slaat de bijgewerkte presentatie op.

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

De [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--)‑methode geeft toegang tot de werkbladen in een grafiek‑werkboek. Dit voorbeeld maakt een cirkeldiagram met standaardgegevens en drukt elke werkbladnaam af naar de console.

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

## **Het type gegevensbron opgeven**

Reeks‑puntwaarden kunnen ook rechtstreeks als numerieke letterlijke waarden worden opgeslagen. Zie [Reekswaarden instellen met numerieke letterlijke waarden](/slides/nl/java/chart-series/#set-series-values-using-numeric-literals) voor een compleet voorbeeld dat ze opslaat en leest. Het bron‑type van puntwaarden staat los van de interne of externe werkboekconfiguratie van de grafiek; het gebruik van numerieke letterlijke waarden verwijdert op zich niet het ingesloten werkboek.

Dit voorbeeld maakt een 3D‑kolomgrafiek met standaardgegevens en stelt twee reeksnamen in met verschillende gegevensbronnen. De eerste naam gebruikt een tekenreeks‑literal; de tweede gebruikt cel C1 op werkblad 0. De [DataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/)‑enumeratie selecteert de bron voor elke naam. Het voorbeeld slaat de presentatie op met de bijgewerkte reeksnamen.

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

Aspose.Slides ondersteunt het Excel‑binaire werkboekformaat (.xlsb) dat in sommige grafieken kan worden ingesloten niet. U kunt de [getEmbeddedWorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--)‑methode op [IChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/) samen met de [WorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/workbooktype/)‑enumeratie gebruiken om niet‑ondersteunde formaten te detecteren en die grafieken over te slaan. Dit voorbeeld inspecteert de vormen op de eerste dia van een bestaande presentatie, slaat niet‑grafiek‑vormen over en drukt een diagnostisch bericht af voor elke grafiek met een ingesloten .xlsb‑werkboek.

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

## **Extern werkboek**

Aspose.Slides ondersteunt het gebruik van externe werkboeken als gegevensbron voor grafieken.

### **Extern werkboek aanmaken**

Gebruik [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) en [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) om een ingesloten grafiek‑werkboek naar een bestand te exporteren en de grafiek aan dat externe werkboek te koppelen.

Dit voorbeeld maakt een cirkeldiagram met standaardgegevens en exporteert het werkboek. Het voltooit het schrijven van het bestand voordat het externe werkboek wordt toegewezen als de grafiek‑gegevensbron, en slaat vervolgens de gekoppelde presentatie op.

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

### **Extern werkboek instellen**

Met de [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-)‑methode kunt u een extern werkboek toewijzen aan een grafiek als gegevensbron. Deze methode kan ook worden gebruikt om een pad naar het externe werkboek bij te werken (als het werkboek is verplaatst).

Hoewel u de gegevens in werkboeken die zich op externe locaties of bronnen bevinden niet kunt bewerken, kunt u dergelijke werkboeken nog steeds gebruiken als externe gegevensbron. Als een relatief pad voor een extern werkboek wordt opgegeven, wordt dit automatisch omgezet naar een volledig pad.

Dit voorbeeld gebruikt een extern werkboek waarvan het werkblad met de naam `Sheet1` een reeksnaam in B1, categorienamen in A2:A4 en numerieke waarden in B2:B4 bevat. Het voorbeeld maakt een cirkeldiagram, koppelt het werkboek, en gebruikt [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) om A1:B4 te koppelen aan één reeks en drie categorieën. Het slaat de presentatie op met de gekoppelde grafiek.

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

De `updateChartData`‑parameter van [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) bepaalt of het werkboek wordt geladen.

* Wanneer `updateChartData` `false` is, wordt alleen het werkboekpad bijgewerkt. De grafiekgegevens worden niet geladen of bijgewerkt vanuit het doel‑werkboek, zodat het werkboek onbeschikbaar kan zijn.
* Wanneer `updateChartData` `true` is, worden de grafiekgegevens bijgewerkt vanuit het doel‑werkboek.

Het volgende voorbeeld kent een tijdelijke URL toe met `updateChartData` ingesteld op `false`. Het behoudt de standaardgegevens van de cirkeldiagram en slaat de presentatie op zonder het onbeschikbare werkboek te laden.

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

### **Pad naar extern gegevensbron‑werkboek van een grafiek ophalen**

Om het werkboek dat aan een grafiek is gekoppeld te identificeren, controleert u of de grafiek een externe gegevensbron gebruikt en haalt u het werkboekpad op.

Dit voorbeeld inspecteert de eerste vorm op de eerste dia van een presentatie met een gekoppeld extern werkboek. Als het een grafiek is die aan een extern werkboek is gekoppeld, drukt het voorbeeld [getExternalWorkbookPath](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) af naar de console. Vervolgens slaat het een kopie van de presentatie op.

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

U kunt de gegevens in externe werkboeken op dezelfde manier bewerken als u wijzigingen aanbrengt in de inhoud van interne werkboeken. Wanneer een extern werkboek niet kan worden geladen, wordt een uitzondering gegooid.

Dit voorbeeld gebruikt een grafiek die de eerste vorm is op de eerste dia en die is gekoppeld aan een toegankelijke extern werkboek. Het stelt de cel‑gebaseerde waarde van het eerste datumpunt in de eerste reeks in op 100 en slaat de bijgewerkte presentatie op. Het bewerken van celwaarden kan het gekoppelde externe XLSX‑bestand bijwerken, dus gebruik een kopie als u het oorspronkelijke werkboek wilt behouden.

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

### **Een werkboek herstellen uit de grafiekcache**

Als een grafiek een extern werkboek gebruikt dat ontbreekt of niet beschikbaar is, kan Aspose.Slides het grafiek‑werkboek reconstrueren vanuit de in de presentatie gecachte gegevens. Maak [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) aan, roep [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) op, en stel [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) in op `true` voordat u de presentatie opent.

Het volgende Java‑voorbeeld herstelt werkboekgegevens voor een grafiek die de eerste vorm is op de eerste dia en die een onbeschikbaar extern werkboek referenceert. Het benadert de herstelde gegevens via [IChart.getChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getChartData--) en [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

Als het externe werkboek niet beschikbaar is en herstel is uitgeschakeld, gooit Aspose.Slides een uitzondering. Schakel herstel alleen in wanneer het gebruik van de in cache opgeslagen grafiekgegevens een acceptabele fallback is, omdat de cache mogelijk niet de wijzigingen bevat die in het externe werkboek zijn aangebracht nadat de presentatie voor het laatst is bijgewerkt.

## **FAQ**

**Kan ik bepalen of een specifieke grafiek is gekoppeld aan een extern of een ingesloten werkboek?**

Ja. Een grafiek heeft een [data source type](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) en een [pad naar een extern werkboek](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); als de bron een extern werkboek is, kunt u het volledige pad lezen om te bevestigen dat een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkboeken ondersteund, en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. De presentatie slaat het absolute pad op in het PPTX‑bestand, dus het verplaatsen van het werkboek kan een bijwerking van de koppeling vereisen.

**Kan ik werkboeken gebruiken die zich op netwerkbronnen/share‑s bevinden?**

Ja, dergelijke werkboeken kunnen worden gebruikt als externe gegevensbron. Het bewerken van externe werkboeken rechtstreeks vanuit Aspose.Slides wordt echter niet ondersteund – ze kunnen alleen als bron worden gebruikt.

**Schrijft Aspose.Slides het externe XLSX‑bestand over bij het opslaan van de presentatie?**

De presentatie slaat een [link naar het externe bestand](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) op. Het bewerken van cel‑gebaseerde grafiekgegevens kan ook het gekoppelde lokale XLSX‑bestand bijwerken. Gebruik een kopie van het werkboek als het origineel ongewijzigd moet blijven.

**Wat moet ik doen als het externe bestand een wachtwoordbescherming heeft?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gebruikelijke aanpak is het wachtwoord vooraf te verwijderen of een gedecodeerde kopie voor te bereiden (bijvoorbeeld met [Aspose.Cells](https://reference.aspose.com/cells/java/)) en naar die kopie te koppelen.

**Kunnen meerdere grafieken naar hetzelfde externe werkboek verwijzen?**

Ja. Elke grafiek slaat zijn eigen link op. Als ze allemaal naar hetzelfde bestand wijzen, wordt een wijziging van dat bestand in elke grafiek weergegeven de volgende keer dat de gegevens worden geladen.