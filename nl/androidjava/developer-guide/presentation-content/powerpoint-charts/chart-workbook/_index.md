---
title: Beheer diagramwerkboeken in presentaties op Android
linktitle: Diagramwerkboek
type: docs
weight: 70
url: /nl/androidjava/chart-workbook/
keywords:
- diagramwerkboek
- diagramgegevens
- werkboekcel
- databelabel
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

Dit artikel legt uit hoe u met chart‑werkboeken in Aspose.Slides kunt werken. Het toont hoe u diagramgegevens kunt lezen en schrijven via werkboek‑streams, werkboekcellen kunt gebruiken als diagramdatabelabels, werkbladcollecties kunt benaderen en het gegevenstypebron kunt specificeren voor diagramwaarden.

Het behandelt ook het werken met externe werkboeken als diagram‑gegevensbronnen. De voorbeelden laten zien hoe u een extern werkboek maakt en toewijst, het pad van een extern werkboek dat aan een diagram is gekoppeld opvraagt en diagramgegevens bewerkt wanneer het werkboek beschikbaar is.

Voor werkboekcellen die ontbrekende gegevens vertegenwoordigen, zie [De weergave van lege cellen regelen](/slides/nl/androidjava/chart-series/) voor het verschil tussen een lege cel en nul, en een lijndiagram‑vergelijking van de beschikbare weergavemodi.

## **Diagramgegevens lezen en schrijven vanuit een werkboek**
Aspose.Slides biedt de [ReadWorkbookStream](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) en [WriteWorkbookStream](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) methoden die u in staat stellen diagram‑werkboeken (die diagramgegevens bevatten die met Aspose.Cells zijn bewerkt) te lezen en te schrijven. **Opmerking** dat de diagramgegevens op dezelfde manier moeten zijn georganiseerd of een structuur moeten hebben die vergelijkbaar is met de bron.

Deze Java‑code toont een voorbeeldbewerking:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("chart.pptx");
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartData data = chart.getChartData();

    byte[] stream = data.readWorkbookStream();

    data.getSeries().clear();
    data.getCategories().clear();

    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Diagramindeling valideren na wijziging van werkboek**

Wanneer u een ingebed werkboek vervangt door een aangepast werkboek, behoudt het diagram de oorspronkelijke reeks‑ en categorie‑collecties. Deze mismatch kan ertoe leiden dat [IChart.validateChartLayout](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChart#validateChartLayout--) faalt met een index‑out‑of‑range‑fout. Maak de bestaande reeksen en categorieën leeg voordat u het bijgewerkte werkboek terugschrijft naar het diagram.

```java
// Na het wijzigen van de werkboekstream (bijv. met Aspose.Cells)
byte[] updatedWorkbook = chartData.readWorkbookStream();

// Verwijder bestaande gegevensreferenties.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Het legen van de collecties zorgt ervoor dat de diagramgegevensstructuur consistent is met het nieuwe werkboek, zodat `validateChartLayout` zonder fouten kan worden voltooid.

## **Een werkboekcel instellen als diagramdatabelabel**

1. Maak een instantie van de [Presentation](https://apireference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Voeg een Bubbeldiagram toe met enkele gegevens.  
4. Benader de diagramreeksen.  
5. Stel de werkboekcel in als databelabel.  
6. Sla de presentatie op.

Deze Java‑code laat zien hoe u een werkboekcel als diagramdatabelabel instelt:

```java
// Instantieert een presentatieklasse die een presentatiebestand voorstelt
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Instantiates a presentation class that represents a presentation file
Presentation pres = new Presentation("chart2.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    IDataLabelCollection dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));

    pres.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Werkbladen beheren**

Deze Java‑code demonstreert een bewerking waarbij de [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--)‑methode wordt gebruikt om een werkbladcollectie te benaderen:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook wb =  chart.getChartData().getChartDataWorkbook();
    for (int i = 0; i < wb.getWorksheets().size(); i++)
        System.out.println(wb.getWorksheets().get_Item(i).getName());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gegevenstypebron specificeren**

Deze Java‑code toont hoe u een type voor een gegevensbron kunt specificeren:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.getChartData().getSeries().get_Item(0).getName();

    val.setDataSourceType(DataSourceType.StringLiterals);
    val.setData("LiteralString");

    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Detecteer niet‑ondersteunde ingesloten werkboekformaten**

Aspose.Slides ondersteunt het Excel‑binaire werkboekformaat (.xlsb) niet, dat in sommige diagrammen kan worden ingebed. U kunt de `getEmbeddedWorkbookType`‑methode op [IChartData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartData) gebruiken in combinatie met de [WorkbookType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/WorkbookType)‑enumeratie om niet‑ondersteunde formaten te detecteren en die diagrammen over te slaan.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) continue;

        IChart chart = (IChart)shape;
        IChartData chartData = chart.getChartData();

        if (chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro) {
            // Ingesloten werkboek is in .xlsb-formaat, wat niet wordt ondersteund.
            continue;
        }

        // Lees of wijzig hier de diagramwerkboekgegevens.
    }
} finally {
    presentation.dispose();
}
```

## **Extern werkboek**

Aspose.Slides ondersteunt het gebruik van externe werkboeken als gegevensbron voor diagrammen.

### **Extern werkboek maken**

Met de **`readWorkbookStream`**‑ en **`setExternalWorkbook`**‑methoden kunt u ofwel een extern werkboek vanaf nul maken of een intern werkboek extern maken.

Deze Java‑code toont het proces voor het maken van een extern werkboek:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation pres = new Presentation();
try {
    final String workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    FileOutputStream fileStream = new FileOutputStream(workbookPath);
    try {
        byte[] workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) fileStream.close();
    }

    chart.getChartData().setExternalWorkbook(workbookPath);

    pres.save("externalWorkbook.pptx", SaveFormat.Pptx);
} catch (IOException e) {    
} finally {
    if (pres != null) pres.dispose();
}
```

### **Extern werkboek instellen**

Met de **`setExternalWorkbook`**‑methode kunt u een extern werkboek aan een diagram toewijzen als diens gegevensbron. Deze methode kan ook worden gebruikt om een pad naar het externe werkboek bij te werken (als het laatstgenoemde is verplaatst).

Hoewel u de gegevens in werkboeken die op externe locaties of bronnen zijn opgeslagen niet direct kunt bewerken, kunt u dergelijke werkboeken wel als externe gegevensbron gebruiken. Als een relatief pad voor een extern werkboek wordt opgegeven, wordt dit automatisch omgezet naar een volledig pad.

Deze Java‑code laat zien hoe u een extern werkboek instelt:

```java
import com.aspose.slides.*;

// Maakt een instantie van de Presentation-klasse
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.getChartData();

    chartData.setExternalWorkbook("externalWorkbook.xlsx");

    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));

    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    
    pres.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

De `updateChartData`‑parameter (onder de `setExternalWorkbook`‑methode) wordt gebruikt om op te geven of een Excel‑werkboek wel of niet wordt geladen.

* Wanneer `updateChartData` is ingesteld op `false`, wordt alleen het pad van het werkboek bijgewerkt — de diagramgegevens worden niet geladen of bijgewerkt vanuit het doel‑werkboek. Gebruik deze instelling wanneer het doel‑werkboek niet bestaat of niet beschikbaar is.  
* Wanneer `updateChartData` is ingesteld op `true`, worden de diagramgegevens bijgewerkt vanuit het doel‑werkboek.

```java
import com.aspose.slides.*;

// Maakt een instantie van de Presentation-klasse
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();

    ((ChartData)chartData).setExternalWorkbook("http://path/doesnt/exists", false);

    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Het pad van het externe gegevensbron‑werkboek van een diagram ophalen**

1. Maak een instantie van de [Presentation](https://apireference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Maak een object voor de diagramvorm.  
4. Maak een object voor het bron‑type (`ChartDataSourceType`) dat de gegevensbron van het diagram vertegenwoordigt.  
5. Specificeer de relevante voorwaarde op basis van het bron‑type dat gelijk is aan het type van de externe werkboek‑gegevensbron.

Deze Java‑code demonstreert de bewerking:

```java
import com.aspose.slides.*;

// Maakt een instantie van de Presentation-klasse
Presentation pres = new Presentation("chart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(1);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    int sourceType = chart.getChartData().getDataSourceType();
    
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        String path = chart.getChartData().getExternalWorkbookPath();
    }
	
	// Slaat de presentatie op
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Diagramgegevens bewerken**

U kunt de gegevens in externe werkboeken op dezelfde manier bewerken als wanneer u de inhoud van interne werkboeken wijzigt. Wanneer een extern werkboek niet kan worden geladen, wordt er een uitzondering gegooid.

Deze Java‑code is een implementatie van het beschreven proces:

```java
import com.aspose.slides.*;

// Maakt een instantie van de Presentation-klasse
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = (IChart)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ChartData chartData = (ChartData)chart.getChartData();
    
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    
    pres.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Een werkboek herstellen uit de diagram‑cache**

Als een diagram een extern werkboek gebruikt dat ontbreekt of niet beschikbaar is, kan Aspose.Slides het diagram‑werkboek reconstrueren uit de in de presentatie gecachte gegevens. Maak [LoadOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadoptions/) aan, configureer deze met [SpreadsheetOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/spreadsheetoptions/), en roep [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) aan met `true` vóór het openen van de presentatie.

Het volgende Java‑voorbeeld opent een presentatie waarvan het diagram een niet‑beschikbaar extern werkboek verwijst en krijgt de herstelde gegevens via [IChart.getChartData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichart/#getChartData--) en [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Lees of wijzig hier de herstelde werkboekgegevens.
} finally {
    presentation.dispose();
}
```

Als het externe werkboek niet beschikbaar is en herstel is uitgeschakeld, gooit Aspose.Slides een uitzondering. Schakel herstel alleen in wanneer het gebruik van de gecachte diagramgegevens een acceptabele fallback is, omdat de cache mogelijk geen wijzigingen bevat die in het externe werkboek zijn aangebracht nadat de presentatie voor het laatst is bijgewerkt.

## **FAQ**

**Kan ik bepalen of een specifiek diagram gekoppeld is aan een extern of een ingesloten werkboek?**

Ja. Een diagram heeft een [data source type](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) en een [path to an external workbook](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); als de bron een extern werkboek is, kunt u het volledige pad uitlezen om er zeker van te zijn dat er een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkboeken ondersteund, en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. Dit is handig voor project‑portabiliteit; echter, wees ervan bewust dat de presentatie het absolute pad opslaat in het PPTX‑bestand.

**Kan ik werkboeken gebruiken die zich op netwerkbronnen of shares bevinden?**

Ja, dergelijke werkboeken kunnen worden gebruikt als externe gegevensbron. Het direct bewerken van externe werkboeken vanuit Aspose.Slides wordt echter niet ondersteund — ze kunnen alleen als bron worden gebruikt.

**Overschrijft Aspose.Slides het externe XLSX‑bestand bij het opslaan van de presentatie?**

Nee. De presentatie slaat een [link to the external file](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) op en gebruikt die voor het lezen van gegevens. Het externe bestand zelf wordt niet aangepast wanneer de presentatie wordt opgeslagen.

**Wat moet ik doen als het externe bestand met een wachtwoord beveiligd is?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gebruikelijke aanpak is om de bescherming vooraf te verwijderen of een gedecrypteerde kopie (bijvoorbeeld met [Aspose.Cells](/cells/androidjava/)) voor te bereiden en naar die kopie te linken.

**Kunnen meerdere diagrammen verwijzen naar hetzelfde externe werkboek?**

Ja. Elk diagram slaat zijn eigen link op. Als ze allemaal naar hetzelfde bestand wijzen, wordt een wijziging van dat bestand bij de volgende keer dat de gegevens worden geladen in elk diagram weerspiegeld.