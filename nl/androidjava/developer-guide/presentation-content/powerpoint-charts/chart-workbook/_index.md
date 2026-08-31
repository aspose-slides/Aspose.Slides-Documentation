---
title: Beheer grafiekwerkbladen in presentaties op Android
linktitle: Grafiekwerkblad
type: docs
weight: 70
url: /nl/androidjava/chart-workbook/
keywords:
- grafiekwerkblad
- grafiekgegevens
- werkbladcel
- gegevenslabel
- werkblad
- gegevensbron
- extern werkblad
- externe gegevens
- grafiekkache
- werkbladherstel
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Ontdek Aspose.Slides voor Android via Java: beheer moeiteloos grafiekwerkbladen in PowerPoint- en OpenDocument-formaten om uw presentatiedata te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u met grafiek‑werkbladen in Aspose.Slides kunt werken. Het laat zien hoe u grafiekgegevens kunt lezen en schrijven via werkblad‑streams, werkbladcellen kunt gebruiken als grafiek‑datacontrolelabels, werkbladcollecties kunt benaderen en het gegevenstype voor grafiekwaarden kunt opgeven.

Het behandelt ook het werken met externe werkbladen als gegevensbron voor grafieken. De voorbeelden tonen hoe u een extern werkblad kunt maken en toewijzen, het pad van een extern werkblad dat aan een grafiek is gekoppeld kunt ophalen en grafiekgegevens kunt bewerken wanneer het werkblad beschikbaar is.

## **Grafiekgegevens lezen en schrijven vanuit een werkblad**
Aspose.Slides levert de [ReadWorkbookStream](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) en [WriteWorkbookStream](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) methoden die u in staat stellen grafiekgegevens‑werkbladen te lezen en te schrijven (bevatten grafiekgegevens bewerkt met Aspose.Cells). **Opmerking** dat de grafiekgegevens op dezelfde manier moeten zijn georganiseerd of een structuur moeten hebben die vergelijkbaar is met de bron.

Deze Java‑code toont een voorbeeldoperatie:

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

### **Grafieklayout valideren na werkbladwijziging**

Wanneer u een ingebed werkblad vervangt door een aangepast exemplaar, behoudt de grafiek zijn oorspronkelijke serie‑ en categorie‑collecties. Deze mismatch kan ervoor zorgen dat [IChart.validateChartLayout](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChart#validateChartLayout--) faalt met een index‑out‑of‑range‑fout. Maak de bestaande series en categorieën leeg voordat u het bijgewerkte werkblad terugschrijft naar de grafiek.

```java
// Na het aanpassen van de werkbladstream (bijv. met Aspose.Cells)
byte[] updatedWorkbook = chartData.readWorkbookStream();

// Verwijder bestaande gegevensreferenties.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Het leegmaken van de collecties zorgt ervoor dat de structuur van de grafiekgegevens consistent is met het nieuwe werkblad, zodat `validateChartLayout` kan worden voltooid zonder fouten.

## **Een werkbladcel instellen als een grafiek‑datacontrolelabel**

1. Maak een instantie van de [Presentation](https://apireference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) klasse.  
1. Haal de referentie van een dia op via de index.  
1. Voeg een bubbelgrafiek toe met enige gegevens.  
1. Benader de grafiekseries.  
1. Stel de werkbladcel in als een datacontrolelabel.  
1. Sla de presentatie op.

Deze Java‑code laat zien hoe u een werkbladcel als een grafiek‑datacontrolelabel kunt instellen:

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Instancieert een presentatieklasse die een presentatiebestand vertegenwoordigt
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

Deze Java‑code toont een bewerking waarbij de [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) methode wordt gebruikt om een werkbladcollectie te benaderen:

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

## **Gegevenstypebron opgeven**

Deze Java‑code laat zien hoe u een type voor een gegevensbron kunt specificeren:

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

## **Niet‑ondersteunde ingesloten werkbladformaten detecteren**

Aspose.Slides ondersteunt het binaire Excel‑werkbladformaat (.xlsb) dat in sommige grafieken kan worden ingesloten niet. U kunt de `getEmbeddedWorkbookType`‑methode op [IChartData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartData) samen met de [WorkbookType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/WorkbookType)‑enumeratie gebruiken om niet‑ondersteunde formaten te detecteren en die grafieken over te slaan.

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
            // Ingesloten werkblad is in .xlsb-formaat, wat niet wordt ondersteund.
            continue;
        }

        // Lees of wijzig hier de grafiekwerkbladgegevens.
    }
} finally {
    presentation.dispose();
}
```

## **Extern werkblad**

Aspose.Slides ondersteunt externe werkbladen als gegevensbron voor grafieken.

### **Extern werkblad maken**

Met behulp van de **`readWorkbookStream`** en **`setExternalWorkbook`** methoden kunt u een extern werkblad vanaf nul maken of een intern werkblad extern maken.

Deze Java‑code toont het proces voor het maken van een extern werkblad:

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

### **Extern werkblad instellen**

Met behulp van de **`setExternalWorkbook`** methode kunt u een extern werkblad aan een grafiek toewijzen als gegevensbron. Deze methode kan ook worden gebruikt om een pad naar het externe werkblad bij te werken (indien het werkblad is verplaatst).

Hoewel u de gegevens in werkbladen die zich op externe locaties of bronnen bevinden niet kunt bewerken, kunt u die werkbladen nog steeds als externe gegevensbron gebruiken. Als een relatief pad voor een extern werkblad wordt opgegeven, wordt dit automatisch omgezet naar een volledig pad.

Deze Java‑code laat zien hoe u een extern werkblad instelt:

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

De `updateChartData`‑parameter (onder de `setExternalWorkbook`‑methode) geeft aan of een Excel‑werkblad wel of niet wordt geladen.

* Wanneer de waarde van `updateChartData` op `false` staat, wordt alleen het werkbladpad bijgewerkt – de grafiekgegevens worden niet geladen of bijgewerkt vanuit het doelwerkblad. Deze instelling is nuttig wanneer het doelwerkblad niet bestaat of niet beschikbaar is.  
* Wanneer de waarde van `updateChartData` op `true` staat, worden de grafiekgegevens bijgewerkt vanuit het doelwerkblad.

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

### **Het pad van het externe gegevensbron‑werkblad van een grafiek ophalen**

1. Maak een instantie van de [Presentation](https://apireference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) klasse.  
1. Haal de referentie van een dia op via de index.  
1. Maak een object voor de grafiekvorm.  
1. Maak een object voor het bron‑type (`ChartDataSourceType`) dat de gegevensbron van de grafiek vertegenwoordigt.  
1. Specificeer de relevante voorwaarde op basis van het feit dat het bron‑type gelijk is aan het externe werkblad‑gegevenstype.

Deze Java‑code toont de bewerking:

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

### **Grafiekgegevens bewerken**

U kunt de gegevens in externe werkbladen op dezelfde manier bewerken als u wijzigingen aanbrengt in de inhoud van interne werkbladen. Wanneer een extern werkblad niet kan worden geladen, wordt er een uitzondering gegooid.

Deze Java‑code implementeert het beschreven proces:

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

### **Een werkblad herstellen uit de grafiek‑cache**

Als een grafiek een extern werkblad gebruikt dat ontbreekt of niet beschikbaar is, kan Aspose.Slides het grafiek‑werkblad reconstrueren vanuit de in de presentatie gecachte gegevens. Maak een [LoadOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadoptions/) aan, configureer deze met [SpreadsheetOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/spreadsheetoptions/), en roep [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) aan met `true` voordat u de presentatie opent.

Het volgende Java‑voorbeeld opent een presentatie waarvan de grafiek een niet‑beschikbaar extern werkblad referereert en benadert de herstelde gegevens via [IChart.getChartData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichart/#getChartData--) en [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

    // Lees of wijzig hier de herstelde werkbladgegevens.
} finally {
    presentation.dispose();
}
```

Wanneer het externe werkblad niet beschikbaar is en herstel is uitgeschakeld, gooit Aspose.Slides een uitzondering. Schakel herstel alleen in wanneer het gebruik van de gecachte grafiekgegevens een acceptabele fallback is, omdat de cache mogelijk niet de wijzigingen bevat die na de laatste update van de presentatie in het externe werkblad zijn aangebracht.

## **FAQ**

**Kan ik bepalen of een specifieke grafiek is gekoppeld aan een extern of een ingebed werkblad?**

Ja. Een grafiek heeft een [data source type](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) en een [path to an external workbook](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); als de bron een extern werkblad is, kunt u het volledige pad lezen om te bevestigen dat een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkbladen ondersteund en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. Dit is handig voor projectportabiliteit; let wel op dat de presentatie het absolute pad in het PPTX‑bestand opslaat.

**Kan ik werkbladen gebruiken die zich op netwerkresources/shares bevinden?**

Ja, dergelijke werkbladen kunnen worden gebruikt als externe gegevensbron. Het rechtstreeks bewerken van remote werkbladen vanuit Aspose.Slides wordt echter niet ondersteund – ze kunnen alleen als bron dienen.

**Overschrijft Aspose.Slides het externe XLSX‑bestand bij het opslaan van de presentatie?**

Nee. De presentatie slaat een [link to the external file](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) op en gebruikt deze voor het lezen van gegevens. Het externe bestand zelf wordt niet gewijzigd bij het opslaan van de presentatie.

**Wat moet ik doen als het externe bestand met een wachtwoord is beveiligd?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gangbare aanpak is om de beveiliging vooraf te verwijderen of een gedecrypteerde kopie (bijvoorbeeld met [Aspose.Cells](/cells/androidjava/)) voor te bereiden en naar die kopie te linken.

**Kunnen meerdere grafieken naar hetzelfde externe werkblad verwijzen?**

Ja. Elke grafiek slaat zijn eigen link op. Als ze allemaal naar hetzelfde bestand wijzen, wordt een update van dat bestand in elke grafiek zichtbaar bij de volgende gegevenslading.