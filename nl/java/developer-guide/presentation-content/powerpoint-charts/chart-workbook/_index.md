---
title: Beheer grafiekwerkmappen in presentaties met Java
linktitle: Grafiekwerkmap
type: docs
weight: 70
url: /nl/java/chart-workbook/
keywords:
- grafiekwerkmap
- grafiekgegevens
- werkmapcel
- datummarker
- werkblad
- gegevensbron
- externe werkmap
- externe gegevens
- grafiekcache
- werkmapherstel
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Ontdek Aspose.Slides voor Java: beheer eenvoudig grafiekwerkmappen in PowerPoint- en OpenDocument-formaten om uw presentatiedata te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u met grafiek‑werkmappen in Aspose.Slides kunt werken. Het laat zien hoe u grafiekgegevens kunt lezen en schrijven via werkmap‑streams, werkmapcellen als grafiek‑datummarkers kunt gebruiken, toegang krijgt tot werkbladcollecties en het type gegevensbron voor grafiekwaarden kunt opgeven.

Het behandelt ook het werken met externe werkmappen als gegevensbronnen voor grafieken. De voorbeelden laten zien hoe u een externe werkmap maakt en toewijst, het pad van een externe werkmap die aan een grafiek is gekoppeld opvraagt en grafiekgegevens bewerkt wanneer de werkmap beschikbaar is.

## **Grafiekgegevens lezen en schrijven vanuit een werkmap**
Aspose.Slides biedt de [ReadWorkbookStream](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartData#readWorkbookStream--) en [WriteWorkbookStream](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) methoden waarmee u grafiek‑werkmappen (die grafiekgegevens bevatten die met Aspose.Cells zijn bewerkt) kunt lezen en schrijven. **Opmerking** dat de grafiekgegevens op dezelfde manier georganiseerd moeten zijn of een structuur moeten hebben die vergelijkbaar is met de bron.

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

### **Grafieklayout valideren na bewerken van werkmap**

Wanneer u een ingesloten werkmap vervangt door een gewijzigde versie, behoudt de grafiek zijn oorspronkelijke serie‑ en categorie‑collecties. Deze inconsistentie kan ervoor zorgen dat [IChart.validateChartLayout](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichart/#validateChartLayout--) een `ArgumentOutOfRangeException` (parameter: index) gooit. Om de uitzondering te voorkomen, ruim de bestaande series en categorieën **voor** het wegschrijven van de bijgewerkte werkmap terug naar de grafiek op.

```java
// Na het wijzigen van de werkmap‑stream (bijv. met Aspose.Cells)
byte[] updatedWorkbook = baos.toByteArray();

// Verwijder bestaande gegevenverwijzingen.
chart.getChartData().getSeries().clear();
chart.getChartData().getCategories().clear();

chart.getChartData().writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Het legen van de collecties zorgt ervoor dat de structuur van de grafiekgegevens overeenkomt met de nieuwe werkmap, zodat `validateChartLayout` zonder fouten kan worden voltooid.

## **Een werkmapcel instellen als grafiek‑datummarker**

1. Maak een instantie van de [Presentation](https://apireference.aspose.com/slides/nl/java/com.aspose.slides/presentation) klasse.
1. Haal een slide op via het bijbehorende indexnummer.
1. Voeg een Bubble‑grafiek met enkele gegevens toe.
1. Benader de grafiekseries.
1. Stel de werkmapcel in als datummarker.
1. Sla de presentatie op.

Deze Java‑code laat zien hoe u een werkmapcel als datummarker instelt:

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Instantieert een presentatie-klasse die een presentatie-bestand vertegenwoordigt
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

Deze Java‑code demonstreert een operatie waarbij de [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) methode wordt gebruikt om een werkbladcollectie te benaderen:

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

## **Het type gegevensbron opgeven**

Deze Java‑code toont hoe u een type voor een gegevensbron specificeert:

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

## **Detecteren van niet‑ondersteunde ingesloten werkmapformaten**

Aspose.Slides ondersteunt het Excel‑binaire werkmapformaat (.xlsb) dat in sommige grafieken kan worden ingesloten niet. U kunt de `getEmbeddedWorkbookType` methode op [IChartData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartData) gebruiken in combinatie met de [WorkbookType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/WorkbookType) enumeratie om niet‑ondersteunde formaten te detecteren en die grafieken over te slaan.

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
            // Ingesloten werkmap is in .xlsb-formaat, wat niet wordt ondersteund.
            continue;
        }

        // Lees of wijzig hier de grafiekwerkmapgegevens.
    }
} finally {
    presentation.dispose();
}
```

## **Externe werkmap**

{{% alert color="info" %}} 
In [Aspose.Slides 19.4](https://docs.aspose.com/slides/nl/java/aspose-slides-for-java-19-4-release-notes/) hebben we ondersteuning geïmplementeerd voor externe werkmappen als gegevensbron voor grafieken.
{{% /alert %}} 

### **Een externe werkmap maken**

Met de **`readWorkbookStream`** en **`setExternalWorkbook`** methoden kunt u ofwel een externe werkmap vanaf nul maken, of een interne werkmap extern maken.

Deze Java‑code demonstreert het proces van het creëren van een externe werkmap:

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

### **Een externe werkmap instellen**

Met de **`setExternalWorkbook`** methode kunt u een externe werkmap aan een grafiek toewijzen als gegevensbron. Deze methode kan ook worden gebruikt om een pad naar de externe werkmap bij te werken (indien deze is verplaatst).

Hoewel u de gegevens in werkmappen die zich op externe locaties of resources bevinden niet kunt bewerken, kunt u zulke werkmappen wel als externe gegevensbron gebruiken. Als er een relatieve padnaam voor een externe werkmap wordt opgegeven, wordt deze automatisch omgezet naar een volledig pad.

Deze Java‑code laat zien hoe u een externe werkmap instelt:

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

De tweede (`boolean`) parameter van de `setExternalWorkbook` methode geeft aan of een Excel‑werkmap wel of niet wordt geladen. 

* Wanneer de waarde `false` is, wordt alleen het werkmappad bijgewerkt – de grafiekgegevens worden niet geladen of bijgewerkt vanuit de doel‑werkmap. Deze instelling kan nuttig zijn wanneer de doel‑werkmap ontbreekt of niet beschikbaar is. 
* Wanneer de waarde `true` is, worden de grafiekgegevens bijgewerkt vanuit de doel‑werkmap.

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

### **Het pad van de externe gegevensbron‑werkmap van een grafiek ophalen**

1. Maak een instantie van de [Presentation](https://apireference.aspose.com/slides/nl/java/com.aspose.slides/presentation) klasse.
1. Haal een slide op via het bijbehorende indexnummer.
1. Maak een object voor de grafiekvorm.
1. Maak een object voor het bron‑type (`ChartDataSourceType`) dat de gegevensbron van de grafiek vertegenwoordigt.
1. Specificeer de relevante voorwaarde op basis van het bron‑type dat gelijk is aan het externe werkmap‑type.

Deze Java‑code demonstreert de operatie:

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

U kunt de gegevens in externe werkmappen bewerken op dezelfde manier als u wijzigingen aanbrengt in interne werkmappen. Wanneer een externe werkmap niet kan worden geladen, wordt er een uitzondering gegooid.

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

### **Een werkmap herstellen vanuit de grafiekcache**

Als een grafiek een externe werkmap gebruikt die ontbreekt of niet beschikbaar is, kan Aspose.Slides de werkmap van de grafiek reconstrueren vanuit de gegevens die in de presentatie zijn gecached. Maak [LoadOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/) aan, configureer deze met [SpreadsheetOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/spreadsheetoptions/), en roep [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) aan met `true` voordat u de presentatie opent.

Het onderstaande Java‑voorbeeld opent een presentatie waarvan de grafiek verwijst naar een niet‑beschikbare externe werkmap en benadert de herstelde gegevens via [IChart.getChartData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichart/#getChartData--) en [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Lees of wijzig hier de herstelde werkmapgegevens.
} finally {
    presentation.dispose();
}
```

Als de externe werkmap niet beschikbaar is en herstel is uitgeschakeld, gooit Aspose.Slides een uitzondering. Schakel herstel alleen in wanneer het gebruik van de gecachte grafiekgegevens een acceptabele fallback is, omdat de cache mogelijk geen wijzigingen bevat die na de laatste presentatie‑update in de externe werkmap zijn aangebracht.

## **FAQ**

**Kan ik bepalen of een specifieke grafiek is gekoppeld aan een externe of een ingesloten werkmap?**

Ja. Een grafiek heeft een [data source type](https://reference.aspose.com/slides/nl/java/com.aspose.slides/chartdata/#getDataSourceType--) en een [pad naar een externe werkmap](https://reference.aspose.com/slides/nl/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); als de bron een externe werkmap is, kunt u het volledige pad lezen om te bevestigen dat een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkmappen ondersteund en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. Dit is handig voor project‑portabiliteit; houd er echter rekening mee dat de presentatie het absolute pad in het PPTX‑bestand opslaat.

**Kan ik werkmappen gebruiken die zich op netwerkresources/shares bevinden?**

Ja, dergelijke werkmappen kunnen worden gebruikt als externe gegevensbron. Het direct bewerken van remote werkmappen vanuit Aspose.Slides wordt echter niet ondersteund – ze kunnen alleen als bron dienen.

**Overschrijft Aspose.Slides de externe XLSX bij het opslaan van de presentatie?**

Nee. De presentatie slaat een [link naar het externe bestand](https://reference.aspose.com/slides/nl/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) op en gebruikt deze voor het lezen van gegevens. Het externe bestand zelf wordt niet aangepast bij het opslaan van de presentatie.

**Wat moet ik doen als het externe bestand beveiligd is met een wachtwoord?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een veelgebruikte aanpak is om de bescherming vooraf te verwijderen of een gedecrypteerde kopie voor te bereiden (bijvoorbeeld met [Aspose.Cells](/cells/java/)) en naar die kopie te linken.

**Kunnen meerdere grafieken naar dezelfde externe werkmap verwijzen?**

Ja. Elke grafiek slaat zijn eigen link op. Als ze allemaal naar hetzelfde bestand wijzen, wordt een update van dat bestand in elke grafiek weerspiegeld de volgende keer dat de gegevens worden geladen.