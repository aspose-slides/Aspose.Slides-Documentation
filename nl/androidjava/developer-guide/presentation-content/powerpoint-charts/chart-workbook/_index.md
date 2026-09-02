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
- datamarkering
- werkblad
- gegevensbron
- extern werkboek
- externe gegevens
- grafiekkache
- werkboekherstel
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Ontdek Aspose.Slides voor Android via Java: beheer moeiteloos grafiekwerkboeken in PowerPoint- en OpenDocument-formaten om uw presentatiedata te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u met grafiek‑werkboeken in Aspose.Slides werkt. Het laat zien hoe u grafiekgegevens kunt lezen en schrijven via werkboek‑streams, werkboekcellen als grafiek‑datamarkeringen kunt gebruiken, werkbladcollecties kunt benaderen en het type gegevensbron voor grafiekwaarden kunt specificeren.

Ook wordt behandeld hoe u externe werkboeken als gegevensbron voor grafieken kunt gebruiken. De voorbeelden demonstreren hoe u een extern werkboek maakt en toewijst, het pad van een extern werkboek dat aan een grafiek is gekoppeld ophaalt en grafiekgegevens bewerkt wanneer het werkboek beschikbaar is.

## **Grafiekgegevens lezen en schrijven vanuit een werkmap**

Aspose.Slides biedt de [ReadWorkbookStream](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) en [WriteWorkbookStream](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) methoden die u in staat stellen grafiekgegevens‑werkboeken (die grafiekgegevens bevatten die met Aspose.Cells zijn bewerkt) te lezen en te schrijven. **Opmerking** dat de grafiekgegevens op dezelfde manier moeten worden georganiseerd of een structuur moeten hebben die vergelijkbaar is met de bron.

```java
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

## **Een WorkBook‑cel instellen als grafiekdatummarkering**

1. Maak een instantie van de [Presentation](https://apireference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)-klasse.  
1. Haal een referentie naar een dia op via de index.  
1. Voeg een bubble‑grafiek toe met enkele gegevens.  
1. Toegang tot de grafiekreeks.  
1. Stel de werkmapcel in als datalabel.  
1. Sla de presentatie op.

Deze Java‑code laat zien hoe u een WorkBook‑cel instelt als een grafiekdatummarkering:

```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Instantieert een presentatieklasse die een presentatiebestand vertegenwoordigt
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

Deze Java‑code demonstreert een bewerking waarbij de [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) methode wordt gebruikt om een werkbladcollectie te benaderen:

```java
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

## **Het type gegevensbron specificeren**

Deze Java‑code laat zien hoe u een type voor een gegevensbron opgeeft:

```java
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

## **Detecteer niet‑ondersteunde ingebedde werkmapformaten**

Aspose.Slides ondersteunt het Excel‑binaire werkmapformaat (.xlsb) dat in sommige grafieken kan worden ingebed niet. U kunt de `getEmbeddedWorkbookType`‑methode op [IChartData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartData) gebruiken in combinatie met de [WorkbookType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/WorkbookType) enumeratie om niet‑ondersteunde formaten te detecteren en die grafieken over te slaan.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) continue;

        IChart chart = (IChart)shape;
        IChartData chartData = chart.getChartData();

        if (chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro) {
            // Ingebedde werkmap is in .xlsb-formaat, wat niet ondersteund wordt.
            continue;
        }

        // Lees hier de grafiekwerkmapgegevens of wijzig ze.
    }
} finally {
    presentation.dispose();
}
```

## **Externe werkmap**

Aspose.Slides ondersteunt externe werkboeken als gegevensbron voor grafieken.

### **Maak een externe werkmap**

Met de **`readWorkbookStream`** en **`setExternalWorkbook`** methoden kunt u ofwel een externe werkmap vanaf nul maken of een interne werkmap extern maken.

Deze Java‑code demonstreert het proces van het maken van een externe werkmap:

```java
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

### **Stel een externe werkmap in**

Met de **`setExternalWorkbook`** methode kunt u een externe werkmap aan een grafiek toewijzen als gegevensbron. Deze methode kan ook worden gebruikt om een pad naar de externe werkmap bij te werken (als die laatst is verplaatst).

Hoewel u de gegevens in werkboeken die op externe locaties of resources staan niet kunt bewerken, kunt u die werkboeken wel als externe gegevensbron gebruiken. Indien een relatief pad voor een externe werkmap wordt opgegeven, wordt dit automatisch omgezet naar een volledig pad.

Deze Java‑code laat zien hoe u een externe werkmap instelt:

```java
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

De `ChartData`‑parameter (onder de `setExternalWorkbook`‑methode) wordt gebruikt om aan te geven of een Excel‑werkmap wel of niet wordt geladen.

* Wanneer de `ChartData`‑waarde op `false` staat, wordt alleen het werkmap‑pad bijgewerkt – de grafiekgegevens worden niet geladen of bijgewerkt vanuit de doel‑werkmap. U wilt deze instelling mogelijk gebruiken wanneer de doel‑werkmap niet bestaat of niet beschikbaar is.  
* Wanneer de `ChartData`‑waarde op `true` staat, worden de grafiekgegevens bijgewerkt vanuit de doel‑werkmap.

```java
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

### **Haalt het pad van de externe gegevensbron‑werkmap van een grafiek op**

1. Maak een instantie van de [Presentation](https://apireference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)-klasse.  
1. Haal een referentie naar een dia op via de index.  
1. Maak een object voor de grafiekvorm.  
1. Maak een object voor het bron‑type (`ChartDataSourceType`) dat de gegevensbron van de grafiek vertegenwoordigt.  
1. Specificeer de relevante voorwaarde op basis van het bron‑type dat overeenkomt met het type van de externe werkmap‑gegevensbron.

Deze Java‑code demonstreert de bewerking:

```java
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

U kunt de gegevens in externe werkboeken op dezelfde manier bewerken als wanneer u wijzigingen aanbrengt in interne werkboeken. Wanneer een externe werkmap niet kan worden geladen, wordt er een uitzondering gegooid.

Deze Java‑code implementeert het beschreven proces:

```java
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

### **Een werkmap herstellen uit de grafiek‑cache**

Als een grafiek een externe werkmap gebruikt die ontbreekt of niet beschikbaar is, kan Aspose.Slides de grafiek‑werkmap reconstrueren vanuit de in de presentatie gecachte gegevens. Maak een [LoadOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadoptions/) aan, configureer deze met [SpreadsheetOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/spreadsheetoptions/) en roep [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) met `true` aan voordat u de presentatie opent.

Het volgende Java‑voorbeeld opent een presentatie waarvan de grafiek een niet‑beschikbare externe werkmap referert en krijgt toegang tot de herstelde gegevens via [IChart.getChartData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichart/#getChartData--) en [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Lees hier de herstelde werkmapgegevens of wijzig ze.
} finally {
    presentation.dispose();
}
```

Wanneer de externe werkmap niet beschikbaar is en herstel is uitgeschakeld, werpt Aspose.Slides een uitzondering. Schakel herstel alleen in wanneer het gebruiken van de gecachte grafiekgegevens een aanvaardbare fallback is, omdat de cache mogelijk geen wijzigingen bevat die na de laatste update van de presentatie in de externe werkmap zijn aangebracht.

## **FAQ**

**Kan ik bepalen of een specifieke grafiek is gekoppeld aan een externe of een ingebedde werkmap?**

Ja. Een grafiek heeft een [data source type](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) en een [path to an external workbook](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); als de bron een externe werkmap is, kunt u het volledige pad lezen om zeker te zijn dat een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkboeken ondersteund, en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. Dit is handig voor projectportabiliteit; wees er echter van bewust dat de presentatie het absolute pad opslaat in het PPTX‑bestand.

**Kan ik werkboeken gebruiken die zich op netwerkschijven of gedeelde locaties bevinden?**

Ja, dergelijke werkboeken kunnen worden gebruikt als een externe gegevensbron. Het direct bewerken van externe werkboeken vanuit Aspose.Slides wordt echter niet ondersteund – ze kunnen alleen als bron worden gebruikt.

**Overschrijft Aspose.Slides het externe XLSX‑bestand bij het opslaan van de presentatie?**

Nee. De presentatie slaat een [link to the external file](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) op en gebruikt die voor het lezen van gegevens. Het externe bestand zelf wordt niet gewijzigd wanneer de presentatie wordt opgeslagen.

**Wat moet ik doen als het externe bestand met een wachtwoord is beveiligd?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gebruikelijke aanpak is om de beveiliging vooraf te verwijderen of een gedecrypteerde kopie voor te bereiden (bijvoorbeeld met [Aspose.Cells](/cells/androidjava/)) en naar die kopie te linken.

**Kunnen meerdere grafieken naar dezelfde externe werkmap verwijzen?**

Ja. Elke grafiek slaat zijn eigen koppeling op. Als ze allemaal naar hetzelfde bestand wijzen, wordt een update van dat bestand in elke grafiek weerspiegeld bij de volgende keer dat de gegevens worden geladen.