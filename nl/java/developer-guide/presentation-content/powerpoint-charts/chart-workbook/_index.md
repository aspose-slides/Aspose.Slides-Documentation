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
- datamarkering
- werkblad
- gegevensbron
- extern werkboek
- externe gegevens
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Ontdek Aspose.Slides voor Java: beheer moeiteloos grafiekwerkboeken in PowerPoint- en OpenDocument-formaten om uw presentatiedata te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u met grafiek‑werkboeken in Aspose.Slides kunt werken. Het toont hoe u grafiekgegevens kunt lezen en schrijven via werkboek‑streams, werkboekcellen kunt gebruiken als grafiek‑datamarkeringen, werkbladcollecties kunt benaderen en het type gegevensbron voor grafiekwaarden kunt opgeven.

Het behandelt ook het werken met externe werkboeken als gegevensbronnen voor grafieken. De voorbeelden laten zien hoe u een extern werkboek kunt maken en toewijzen, het pad van een extern werkboek dat aan een grafiek is gekoppeld kunt ophalen, en grafiekgegevens kunt bewerken wanneer het werkboek beschikbaar is.

## **Grafiekgegevens lezen en schrijven vanuit een werkboek**
Aspose.Slides biedt de [ReadWorkbookStream](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartData#readWorkbookStream--) en [WriteWorkbookStream](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) methoden die u in staat stellen om grafiekgegevens‑werkboeken te lezen en te schrijven (met grafiekgegevens die met Aspose.Cells bewerkt zijn). **Opmerking** dat de grafiekgegevens op dezelfde manier moeten worden gestructureerd of een structuur moeten hebben die op de bron lijkt.

Deze Java‑code toont een voorbeeldoperatie:

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

## **Werkboekcel als grafiekdatamarkering instellen**

1. Maak een instantie van de [Presentation](https://apireference.aspose.com/slides/nl/java/com.aspose.slides/presentation) klasse.  
1. Haal een referentie naar een dia op via de index.  
1. Voeg een bolgrafiek toe met enkele gegevens.  
1. Benader de grafieksreeks.  
1. Stel de werkboekcel in als datamarkering.  
1. Sla de presentatie op.

Deze Java‑code laat zien hoe u een werkboekcel als grafiekdatamarkering instelt:

```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Maakt een presentatie‑klasse aan die een presentatiebestand vertegenwoordigt
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

Deze Java‑code toont een bewerking waarbij de [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) methode wordt gebruikt om toegang te krijgen tot een werkbladcollectie:

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

## **Gegevensbrontype opgeven**

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

## **Niet‑ondersteunde ingebedde werkboekformaten detecteren**

Aspose.Slides ondersteunt het Excel‑binaire werkboekformaat (.xlsb) dat in sommige grafieken kan worden ingebed, niet. U kunt de `getEmbeddedWorkbookType`‑methode op [IChartData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartData) samen met de [WorkbookType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/WorkbookType) opsomming gebruiken om niet‑ondersteunde formaten te detecteren en die grafieken over te slaan.

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
            // Ingebed werkboek is in .xlsb formaat, wat niet wordt ondersteund.
            continue;
        }

        // Lees of wijzig hier de grafiekwerkboekgegevens.
    }
} finally {
    presentation.dispose();
}
```

## **Extern werkboek**

{{% alert color="primary"%}}In [Aspose.Slides 19.4](https://docs.aspose.com/slides/nl/java/aspose-slides-for-java-19-4-release-notes/) hebben we ondersteuning toegevoegd voor externe werkboeken als gegevensbron voor grafieken.{{% /alert%}}

### **Extern werkboek maken**

Met de methoden **`readWorkbookStream`** en **`setExternalWorkbook`** kunt u een extern werkboek vanaf nul maken of een intern werkboek extern maken.

Deze Java‑code toont het proces van het creëren van een extern werkboek:

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

### **Extern werkboek instellen**

Met de methode **`setExternalWorkbook`** kunt u een extern werkboek aan een grafiek toewijzen als gegevensbron. Deze methode kan ook worden gebruikt om het pad naar het externe werkboek bij te werken (als dit laatstgenoemde verplaatst is).

Hoewel u de gegevens in werkboeken die op externe locaties of bronnen zijn opgeslagen niet kunt bewerken, kunt u dergelijke werkboeken nog steeds als externe gegevensbron gebruiken. Als een relatief pad voor een extern werkboek wordt opgegeven, wordt dit automatisch omgezet naar een volledig pad.

Deze Java‑code laat zien hoe u een extern werkboek instelt:

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

De `ChartData`‑parameter (onder de `setExternalWorkbook`‑methode) wordt gebruikt om op te geven of een Excel‑werkboek wordt geladen of niet.

* Wanneer de `ChartData`‑waarde op `false` wordt gezet, wordt alleen het pad naar het werkboek bijgewerkt — de grafiekgegevens worden niet geladen of bijgewerkt vanuit het doelwerkboek. Deze instelling kunt u gebruiken wanneer het doelwerkboek niet bestaat of niet beschikbaar is.  
* Wanneer de `ChartData`‑waarde op `true` wordt gezet, worden de grafiekgegevens bijgewerkt vanuit het doelwerkboek.

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

### **Pad naar het externe gegevensbron‑werkboek van een grafiek ophalen**

1. Maak een instantie van de [Presentation](https://apireference.aspose.com/slides/nl/java/com.aspose.slides/presentation) klasse.  
1. Haal een referentie naar een dia op via de index.  
1. Maak een object voor de grafiekvorm.  
1. Maak een object voor het bron‑type (`ChartDataSourceType`) dat de gegevensbron van de grafiek vertegenwoordigt.  
1. Geef de relevante voorwaarde op op basis van het feit dat het bron‑type hetzelfde is als het externe werkboek‑gegevensbrontype.

Deze Java‑code toont de bewerking:

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

U kunt de gegevens in externe werkboeken bewerken op dezelfde manier als u wijzigingen aanbrengt in de inhoud van interne werkboeken. Wanneer een extern werkboek niet kan worden geladen, wordt er een uitzondering gegooid.

Deze Java‑code is een implementatie van het beschreven proces:

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

## **FAQ**

**Kan ik bepalen of een specifieke grafiek gekoppeld is aan een extern of een ingebed werkboek?**

Ja. Een grafiek heeft een [data source type](https://reference.aspose.com/slides/nl/java/com.aspose.slides/chartdata/#getDataSourceType--) en een [pad naar een extern werkboek](https://reference.aspose.com/slides/nl/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); als de bron een extern werkboek is, kunt u het volledige pad lezen om er zeker van te zijn dat een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkboeken ondersteund, en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. Dit is handig voor projectportabiliteit; houd er echter rekening mee dat de presentatie het absolute pad opslaat in het PPTX‑bestand.

**Kan ik werkboeken gebruiken die zich op netwerklocaties/gedeelde mappen bevinden?**

Ja, dergelijke werkboeken kunnen worden gebruikt als externe gegevensbron. Het bewerken van externe werkboeken rechtstreeks vanuit Aspose.Slides wordt echter niet ondersteund — ze kunnen alleen als bron worden gebruikt.

**Vervangt Aspose.Slides het externe XLSX‑bestand bij het opslaan van de presentatie?**

Nee. De presentatie slaat een [link naar het externe bestand](https://reference.aspose.com/slides/nl/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) op en gebruikt deze om gegevens te lezen. Het externe bestand zelf wordt niet aangepast wanneer de presentatie wordt opgeslagen.

**Wat moet ik doen als het externe bestand met een wachtwoord is beveiligd?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gebruikelijke aanpak is om de beveiliging vooraf te verwijderen of een gedecodeerde kopie voor te bereiden (bijvoorbeeld met [Aspose.Cells](/cells/java/)) en naar die kopie te koppelen.

**Kunnen meerdere grafieken naar hetzelfde externe werkboek verwijzen?**

Ja. Elke grafiek slaat zijn eigen link op. Als ze allemaal naar hetzelfde bestand wijzen, wordt een wijziging van dat bestand bij de volgende keer dat de gegevens worden geladen, in elke grafiek weergegeven.