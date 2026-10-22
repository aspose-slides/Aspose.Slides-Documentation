---
title: Werkboek van diagrammen beheren in presentaties op Android
linktitle: Diagramwerkboek
type: docs
weight: 70
url: /nl/androidjava/chart-workbook/
keywords:
- diagramwerkboek
- diagramgegevens
- werkboekcel
- gegevenslabel
- werkblad
- gegevensbron
- extern werkboek
- externe gegevens
- diagramcache
- werkboekherstel
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Ontdek Aspose.Slides voor Android via Java: beheer moeiteloos diagramwerkboeken in PowerPoint- en OpenDocument-formaten om uw presentatiedata te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u kunt werken met diagram‑werkboeken in Aspose.Slides. Het toont hoe u diagramgegevens kunt lezen en schrijven via werkboek‑streams, werkboekcellen als diagramgegevens‑labels kunt gebruiken, verzamelingen van werkbladen kunt benaderen en het gegevenstype van de gegevensbron voor diagramwaarden kunt opgeven.

Het behandelt tevens het werken met externe werkboeken als gegevensbron voor diagrammen. De voorbeelden laten zien hoe u een extern werkboek kunt maken en toewijzen, het pad van een extern werkboek dat aan een diagram is gekoppeld kunt ophalen en diagramgegevens kunt bewerken wanneer het werkboek beschikbaar is.

Voor werkboekcellen die ontbrekende gegevens vertegenwoordigen, zie [Beheer de weergave van lege cellen](/slides/nl/androidjava/chart-series/) voor het verschil tussen een lege cel en nul, en een lijndiagram‑vergelijking van de beschikbare weergavemodi.

## **Gegevens van verborgen rijen en kolommen opnemen**

Gebruik [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) om te bepalen of een diagram gegevens plotst uit verborgen werkbladrijen en -kolommen. Stel in op `true` om alleen zichtbare cellen te plotten, of op `false` om zowel zichtbare als verborgen cellen op te nemen. Deze instelling bepaalt het plotten van het diagram; hij verbergt of toont geen werkbladrijen of -kolommen.

De [sample presentation](hidden-source-data.pptx) bevat een kolomdiagram als het eerste object op de eerste dia. Het ingebedde werkblad, `Sheet1`, bevat het volgende bronbereik, `A1:C4`. Rij 3 en kolom C zijn verborgen, maar hun cellen bevatten nog steeds waarden.

| Werkbladrij | A: Maand | B: Detailhandel | C: Groothandel (verborgen kolom) |
| --- | --- | --- | --- |
| 2 | Januari | 10 | 30 |
| 3 (verborgene rij) | Februari | 40 | 60 |
| 4 | Maart | 20 | 50 |

Toegang tot broncellen via [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) en lees [IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) om hun verborgen status te inspecteren. Deze methode meldt de verborgen status zonder deze te wijzigen. In dit bestand is B2 zichtbaar, B3 behoort tot de verborgen rij en C2 tot de verborgen kolom; het voorbeeld print respectievelijk `false`, `true` en `true`.

Voor dit voorbeeld, ververs de diagramgegevens na het wijzigen van de plotinstelling: behoud het ingebedde werkboek met [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) en laad het opnieuw met [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---). Bij het opnemen van alle cellen, gebruik ook [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) om het volledige bereik te herstellen, inclusief de verborgen februari‑categorie. Alleen de vlag veranderen is onvoldoende om de gecachete diagramgegevens en categorielabels van dit voorbeeld te verversen.

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

            // Ververs de diagramgegevens vanuit het ingebedde werkboek.
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

Het voorbeeld slaat twee versies van de presentatie op: één met alleen de zichtbare detailhandelswaarden (10 en 20) en één met alle zes waarden. De afbeeldingen hieronder illustreren de twee plotmodi. Rij 3 en kolom C blijven verborgen in beide ingebedde werkboeken.

| Alleen zichtbare cellen (`true`) | Alle cellen (`false`) |
| --- | --- |
| ![Alleen zichtbare cellen: detailhandelswaarden 10 en 20 voor januari en maart.](hidden_cells_True.png) | ![Alle cellen: detailhandels- en groothandelswaarden voor januari, februari en maart.](hidden_cells_False.png) |

Een verborgen cel met een waarde verschilt van een lege cel. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) bepaalt hoe ontbrekende waarden worden weergegeven; hij omvat of sluit geen verborgen brongegevens uit. Zie [Beheer de weergave van lege cellen](/slides/nl/androidjava/chart-series/#control-the-display-of-empty-cells) voor een voorbeeld.

## **Bereik van diagramgegevens ophalen**

Voordat u werkboekgegevens bijwerkt in een bestaande presentatie, inspecteert u de bronbereiken om te bepalen welke werkbladcellen elk diagram gebruikt. De [IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--)‑methode retourneert het huidige gegevensbereik als een werkblad‑gekwalificeerde formule, zoals `Sheet1!$A$1:$D$5`. Hier is `Sheet1` de naam van het werkblad, `!` scheidt het van het celbereik, en `$A$1:$D$5` identificeert de cellen A1 tot en met D5, inclusief. De dollartekens duiden absolute rij‑ en kolomreferenties aan.

De methode leest het huidige bereik zonder het diagram of het werkboek te wijzigen. Als het diagram geen werkboek als gegevensbron gebruikt, wordt een `InvalidOperationException` gegooid. Zie voor meer informatie de [ChartData API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/).

Dit voorbeeld opent een presentatie en controleert de objecten direct op elke dia op diagrammen. Het print de naam en het bronbereik van elk diagram. Als een diagram geen werkboek gebruikt, wordt een bericht geprint en gaat de verwerking door met het volgende diagram.

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

## **Diagramgegevens lezen en schrijven vanuit een werkboek**

Aspose.Slides for Android via Java biedt de [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) en [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---)‑methoden die u in staat stellen diagramgegevens‑werkboeken te lezen en te schrijven (bevat diagramgegevens bewerkt met Aspose.Cells). **Opmerking**: de diagramgegevens moeten op dezelfde manier georganiseerd zijn of een structuur hebben die lijkt op de bron.

Dit voorbeeld gebruikt een presentatie met een diagram als het eerste object op de eerste dia. Het leest het ingebedde werkboek in een byte‑array, wist de bestaande series en categorieën, en schrijft hetzelfde werkboek terug. De wijzigingen blijven in het geheugen; het voorbeeld slaat de presentatie niet op.

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

### **Diagramindeling valideren na werkboekmodificatie**

Wanneer u een ingebed werkboek vervangt door een aangepast werkboek, behoudt het diagram zijn oorspronkelijke series‑ en categorieverzamelingen. Deze mismatch kan ertoe leiden dat [IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--) faalt met een index‑out‑of‑range‑fout. Wis de bestaande series en categorieën voordat u het bijgewerkte werkboek terugschrijft naar het diagram. Dit voorbeeld gebruikt een diagram dat het eerste object op de eerste dia is. Het commentaar markeert waar de werkboekbewerking zou plaatsvinden; het uitvoerbare voorbeeld schrijft het originele werkboek terug en valideert de indeling in het geheugen.

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

        // Wijzig hier de werkboekbytes, bijvoorbeeld met Aspose.Cells.

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

Het wissen van de verzamelingen verwijdert verouderde gegevensreferenties voordat het werkboek wordt teruggeschreven. Bouw eventuele benodigde series‑ en categorietoewijzingen opnieuw op voor het bijgewerkte werkboek voordat u het diagram gebruikt.

## **Aangepaste getalnotaties instellen voor werkboekcellen**

Gebruik [IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) om te bepalen hoe numerieke waarden verschijnen in het ingebedde werkboek van een diagram. Bijvoorbeeld, een rapport kan een conversieratio willen weergeven als een percentage met vier decimalen en een coëfficiënt met vijf decimalen. Houd beide waarden numeriek zodat ze beschikbaar blijven voor berekeningen en diagramplotting.

Een getalnotatie wijzigt de weergave, niet de opgeslagen waarde. Het formaat `0.0000%` toont `0.125` als `12.5000%`; het vervangt niet het opgeslagen getal door `12.5`. Evenzo toont `0.00000` `0.1234567` als `0.12346` zonder de opgeslagen waarde af te ronden. Als het aangepaste formaat een lege tekenreeks (`""`) is, wordt het formaat dat wordt geretourneerd door [getPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--) gebruikt.

Het volgende voorbeeld maakt een kolomdiagram en krijgt toegang tot de cellen via [getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--). Op werkblad 0 bevat B2 de conversieratio en C2 de coëfficiënt. Beide cellen leveren diagramwaarden. Het voorbeeld schakelt ook waardelabels in die gekoppeld zijn aan de bronformaten.

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

Werkboekcel‑formaten staan los van de formaten die rechtstreeks op diagramassen of datalabels worden ingesteld. In dit voorbeeld toont elk label de waarde van de broncel omdat [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) is ingesteld op `true`, en omdat [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) is ingesteld op `true`. Na het opslaan en heropenen van de presentatie tonen de labels `12.5000%` en `0.12346`, zoals hieronder weergegeven. De verticale as gebruikt een eigen getalnotatie, toegewezen via [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) als `0.00`, met [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) ingesteld op `false`.

Om een datalabel onafhankelijk te formatteren, zet u de bron‑koppeling op `false` en kent u een notatie toe met [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-). Dit verandert de notatie van de werkboekcel niet. Bijvoorbeeld, een onafhankelijke labelnotatie van `0.00` toont de eerste waarde als `0.13`, terwijl B2 nog steeds `12.5000%` toont. Zie [Chart Data Labels](/slides/nl/androidjava/chart-data-label/#set-the-percentage-sign-with-chart-data-labels) voor directe labelformattering.

De onderstaande afbeelding is gerenderd uit de opgeslagen presentatie na het heropenen ervan:

![Kolomdiagram met bron‑gekoppelde labels die 12.5000% en 0.12346 tonen en een onafhankelijk geformatteerde numerieke as.](custom-cell-formats.png)

## **Een werkboekcel als diagram‑databel label instellen**

U kunt tekst uit werkboekcellen gebruiken als diagramdatabel‑labels.

Dit voorbeeld voegt een bubbel‑diagram met standaardgegevens toe aan de eerste dia van een bestaande presentatie. Het gebruikt de cellen A10:A12 op werkblad 0 voor de eerste drie labels in de eerste serie, schakelt labels vanuit cellen in, en slaat de bijgewerkte presentatie op.

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

De [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--)‑methode biedt toegang tot de werkbladen in een diagramwerkboek. Dit voorbeeld maakt een cirkel‑diagram met standaardgegevens en print elke werkbladnaam naar de console.

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

## **Gegevenstype van de gegevensbron specificeren**

Seriespuntwaarden kunnen ook rechtstreeks als numerieke letterlijke waarden worden opgeslagen. Zie [Set Series Values Using Numeric Literals](/slides/nl/androidjava/chart-series/#set-series-values-using-numeric-literals) voor een volledig voorbeeld dat ze opslaat en leest. Het gegevenstype van de puntwaarden staat los van de interne of externe werkboekconfiguratie van het diagram; het gebruik van numerieke letterlijke waarden verwijdert op zich niet het ingebedde werkboek.

Dit voorbeeld maakt een 3D‑kolomdiagram met standaardgegevens en stelt twee serienaam­instellingen in met verschillende gegevensbronnen. De eerste naam gebruikt een tekenreeks‑literal; de tweede gebruikt cel C1 op werkblad 0. De enumeratie [DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) selecteert de bron voor elke naam. Het voorbeeld slaat de presentatie op met de bijgewerkte serienaam­instellingen.

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

## **Niet‑ondersteunde formaten van ingebedde werkboeken detecteren**

Aspose.Slides ondersteunt het Excel‑binaire werkboekformaat (.xlsb) niet wanneer dit in sommige diagrammen is ingebed. U kunt de [getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--)‑methode op [IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/) samen met de enumeratie [WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/) gebruiken om niet‑ondersteunde formaten te detecteren en die diagrammen over te slaan. Dit voorbeeld inspecteert de objecten op de eerste dia van een bestaande presentatie, slaat niet‑diagramobjecten over en print een diagnostisch bericht voor elk diagram met een ingebed .xlsb‑werkboek.

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

        // Lees of wijzig hier ondersteunde diagram‑werkboekgegevens.
    }
} finally {
    presentation.dispose();
}
```

## **Extern werkboek**

Aspose.Slides ondersteunt het gebruik van externe werkboeken als gegevensbron voor diagrammen.

### **Een extern werkboek maken**

Gebruik [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) en [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) om een ingebed diagramwerkboek naar een bestand te exporteren en het diagram aan dat externe werkboek te koppelen.

Dit voorbeeld maakt een cirkel‑diagram met standaardgegevens en exporteert het werkboek. Het voltooit het bestandsschrijven voordat het externe werkboek als diagram‑gegevensbron wordt toegewezen, waarna de gekoppelde presentatie wordt opgeslagen.

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

Met de [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-)‑methode kunt u een extern werkboek aan een diagram toewijzen als gegevensbron. Deze methode kan ook worden gebruikt om een pad naar het externe werkboek bij te werken (indien het werkboek is verplaatst).

Hoewel u de gegevens in werkboeken die op externe locaties of bronnen zijn opgeslagen niet kunt bewerken, kunt u dergelijke werkboeken wel als externe gegevensbron gebruiken. Als een relatief pad voor een extern werkboek wordt opgegeven, wordt dit automatisch omgezet naar een volledig pad.

Dit voorbeeld gebruikt een extern werkboek waarvan het werkblad `Sheet1` een serienaam bevat in B1, categorienamen in A2:A4 en numerieke waarden in B2:B4. Het voorbeeld maakt een cirkel‑diagram, koppelt het werkboek en gebruikt [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) om A1:B4 te mappen naar één serie en drie categorieën. Het slaat de presentatie met het gekoppelde diagram op.

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

De `updateChartData`‑parameter van [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) bepaalt of het werkboek wordt geladen.

* Wanneer `updateChartData` `false` is, wordt alleen het pad naar het werkboek bijgewerkt. De diagramgegevens worden niet geladen of bijgewerkt vanuit het doel‑werkboek, zodat het werkboek afwezig kan zijn.
* Wanneer `updateChartData` `true` is, worden de diagramgegevens bijgewerkt vanuit het doel‑werkboek.

Het volgende voorbeeld kent een tijdelijke URL toe met `updateChartData` ingesteld op `false`. Het behoudt de standaardgegevens van het cirkel‑diagram en slaat de presentatie op zonder het onbeschikbare werkboek te laden.

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

### **Het pad van het externe gegevensbron‑werkboek van een diagram ophalen**

Om het werkboek te identificeren dat aan een diagram is gekoppeld, controleert u of het diagram een externe gegevensbron gebruikt en haalt u het werkboekpad op.

Dit voorbeeld inspecteert het eerste object op de eerste dia van een presentatie met een gekoppeld extern werkboek. Als het een diagram is dat naar een extern werkboek verwijst, print het voorbeeld [getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) naar de console. Vervolgens wordt een kopie van de presentatie opgeslagen.

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

### **Diagramgegevens bewerken**

U kunt de gegevens in externe werkboeken bewerken op dezelfde manier als u wijzigingen aanbrengt in de inhoud van interne werkboeken. Als een extern werkboek niet kan worden geladen, wordt een uitzondering gegooid.

Dit voorbeeld gebruikt een diagram dat het eerste object op de eerste dia is en dat gekoppeld is aan een toegankelijk extern werkboek. Het stelt de cel‑gebaseerde waarde van het eerste datapunt in de eerste serie in op 100 en slaat de bijgewerkte presentatie op. Het bewerken van celwaarden kan het gekoppelde externe XLSX‑bestand bijwerken; gebruik een kopie als u het oorspronkelijke werkboek moet behouden.

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

### **Een werkboek herstellen uit de diagram‑cache**

Als een diagram een extern werkboek gebruikt dat ontbreekt of niet beschikbaar is, kan Aspose.Slides het diagramwerkboek reconstrueren uit de gegevens die in de presentatie zijn gecachet. Maak een [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) aan, roep [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) aan en stel [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) in op `true` voordat u de presentatie opent.

Het volgende Java‑voorbeeld herstelt werkboekgegevens voor een diagram dat het eerste object op de eerste dia is en dat naar een niet‑beschikbaar extern werkboek verwijst. Het krijgt toegang tot de herstelde gegevens via [IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) en [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

Als het externe werkboek niet beschikbaar is en herstel is uitgeschakeld, gooit Aspose.Slides een uitzondering. Schakel herstel alleen in wanneer het gebruik van de gecachete diagramgegevens een acceptabele fallback is, omdat de cache mogelijk geen wijzigingen bevat die in het externe werkboek zijn aangebracht sinds de laatste presentatie‑update.

## **FAQ**

**Kan ik bepalen of een specifiek diagram is gekoppeld aan een extern of een ingebed werkboek?**

Ja. Een diagram heeft een [data source type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) en een [path to an external workbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); als de bron een extern werkboek is, kunt u het volledige pad lezen om te bevestigen dat een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkboeken ondersteund en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. De presentatie slaat het absolute pad op in het PPTX‑bestand, dus het verplaatsen van het werkboek kan vereisen dat de koppeling wordt bijgewerkt.

**Kan ik werkboeken gebruiken die zich op netwerkbronnen/‑shares bevinden?**

Ja, dergelijke werkboeken kunnen worden gebruikt als externe gegevensbron. Het bewerken van externe werkboeken rechtstreeks vanuit Aspose.Slides wordt echter niet ondersteund – ze kunnen alleen als bron worden gebruikt.

**Schrijft Aspose.Slides het externe XLSX‑bestand over bij het opslaan van de presentatie?**

De presentatie slaat een [link to the external file](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) op. Het bewerken van cel‑gebaseerde diagramgegevens kan ook het gekoppelde lokale XLSX‑bestand bijwerken. Gebruik een kopie van het werkboek als het origineel ongewijzigd moet blijven.

**Wat moet ik doen als het externe bestand met een wachtwoord is beveiligd?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gebruikelijke aanpak is het wachtwoord vooraf te verwijderen of een gedecodeerde kopie (bijvoorbeeld met [Aspose.Cells](https://reference.aspose.com/cells/java/)) voor te bereiden en naar die kopie te koppelen.

**Kunnen meerdere diagrammen naar hetzelfde externe werkboek verwijzen?**

Ja. Elk diagram slaat zijn eigen koppeling op. Als ze allemaal naar hetzelfde bestand wijzen, worden wijzigingen in dat bestand in elk diagram weerspiegeld de volgende keer dat de gegevens worden geladen.