---
title: Beheer grafiekwerkboeken in presentaties met Python via Java
linktitle: Grafiekwerkboek
type: docs
weight: 70
url: /nl/python-java/chart-workbook/
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
- werkboekherstel
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Ontdek Aspose.Slides voor Python via Java: beheer moeiteloos grafiekwerkboeken in PowerPoint- en OpenDocument-formaten om uw presentatiedata te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u met grafiekwerkboeken in Aspose.Slides kunt werken. Het laat zien hoe u grafiekgegevens kunt lezen en schrijven via werkboek‑streams, werkboekcellen kunt gebruiken als grafiek‑databelabels, toegang kunt krijgen tot werkbladverzamelingen en het gegevenstypebron voor grafiekwaarden kunt specificeren.

Het behandelt ook het werken met externe werkboeken als gegevensbron voor grafieken. De voorbeelden demonstreren hoe u een extern werkboek kunt maken en toewijzen, het pad kunt ophalen van een extern werkboek dat aan een grafiek is gekoppeld, en grafiekgegevens kunt bewerken wanneer het werkboek beschikbaar is.

## **Grafiekgegevens lezen en schrijven vanuit een werkboek**

Aspose.Slides biedt de [readWorkbookStream](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdata/#readWorkbookStream) en [writeWorkbookStream](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdata/#writeWorkbookStream) methoden die u in staat stellen grafiekdataverwerkboeken te lezen en te schrijven (bevat grafiekgegevens bewerkt met Aspose.Cells). **Opmerking** dat de grafiekgegevens op dezelfde manier moeten worden georganiseerd of een structuur moeten hebben die vergelijkbaar is met de bron.

Deze Python‑code toont een voorbeeldoperatie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    workbook_data = chart_data.readWorkbookStream()
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(workbook_data)
finally:
    presentation.dispose()
```

### **Grafiekindeling valideren na wijziging van werkboek**

Wanneer u een ingesloten werkboek vervangt door een aangepast werkboek, behoudt de grafiek zijn oorspronkelijke serie‑ en categorie‑collecties. Deze inconsistentie kan er toe leiden dat [Chart.validateChartLayout](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chart/#validateChartLayout) een `ArgumentOutOfRangeException` (parameter: index) gooit. Om de uitzondering te vermijden, moet u de bestaande series en categorieën **voor** het terugschrijven van het bijgewerkte werkboek naar de grafiek wissen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

# Lees het werkboek na bewerken (bijv. met Aspose.Cells).
updated_workbook = Path("updatedWorkbook.xlsx").read_bytes()

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()

    # Wis bestaande gegevensreferenties.
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(jpype.JArray(jpype.JByte)(updated_workbook))
    chart.validateChartLayout()
finally:
    presentation.dispose()
```

Het wissen van de collecties zorgt ervoor dat de structuur van de grafiekgegevens overeenkomt met het nieuwe werkboek, waardoor [validateChartLayout](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chart/#validateChartLayout) zonder fouten kan worden voltooid.

## **Een werkboekcel instellen als grafiek‑databelabel**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.  
1. Haal een referentie naar een dia op basis van de index.  
1. Voeg een Bubbel‑grafiek toe met enkele gegevens.  
1. Toegang tot de grafiekseries.  
1. Stel de werkboekcel in als databelabel.  
1. Sla de presentatie op.

Deze Python‑code laat zien hoe u een werkboekcel als grafiek‑databelabel instelt:

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)
    series = chart.getChartData().getSeries()
    data_labels = series.get_Item(0).getLabels()
    data_labels.getDefaultDataLabelFormat().setShowLabelValueFromCell(True)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(3):
        label_cell = workbook.getCell(0, f"A{10 + i}", label_values[i])
        data_labels.get_Item(i).setValueFromCell(label_cell)
    presentation.save("resultchart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Werkbladen beheren**

Deze Python‑code demonstreert een bewerking waarbij de [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdataworkbook/#getWorksheets) methode wordt gebruikt om toegang te krijgen tot een werkbladcollectie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **Het gegevenstypebron specificeren**

Deze Python‑code laat zien hoe u een type voor een gegevensbron specificeert:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    series_name = chart.getChartData().getSeries().get_Item(0).getName()
    series_name.setDataSourceType(DataSourceType.StringLiterals)
    series_name.setData("LiteralString")
    series_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell")
    series_name.setData(name_cell)
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Detecteer niet‑ondersteunde ingesloten werkboekformaten**

Aspose.Slides ondersteunt het Excel‑binaire werkboekformaat (.xlsb) niet, dat in sommige grafieken kan worden ingesloten. U kunt de [getEmbeddedWorkbookType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) methode op [ChartData](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdata/) samen met de [WorkbookType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/workbooktype/) opsomming gebruiken om niet‑ondersteunde formaten te detecteren en die grafieken over te slaan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, WorkbookType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue
        chart_data = shape.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook and chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro:
            # Ingebed werkboek heeft .xlsb-formaat, wat niet wordt ondersteund.
            continue
        # Lees of wijzig hier de grafiekwerkboekgegevens.
finally:
    presentation.dispose()
```

### **Een extern werkboek maken**

Met behulp van de [readWorkbookStream](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdata/#readWorkbookStream) en [setExternalWorkbook](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdata/#setExternalWorkbook) methoden kunt u een extern werkboek vanaf nul maken of een intern werkboek extern maken.

Deze Python‑code demonstreert het proces van het aanmaken van een extern werkboek:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    workbook_path = "externalWorkbook1.xlsx"
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(workbook_path)
    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Een extern werkboek instellen**

Met behulp van de [setExternalWorkbook](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdata/#setExternalWorkbook) methode kunt u een extern werkboek aan een grafiek toewijzen als gegevensbron. Deze methode kan ook worden gebruikt om het pad naar het externe werkboek bij te werken (als het laatstgenoemde is verplaatst).

Hoewel u de gegevens in werkboeken die op externe locaties of bronnen zijn opgeslagen niet kunt bewerken, kunt u dergelijke werkboeken nog steeds gebruiken als externe gegevensbron. Als een relatief pad voor een extern werkboek wordt opgegeven, wordt dit automatisch omgezet naar een volledig pad.

Deze Python‑code laat zien hoe u een extern werkboek instelt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, False)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("externalWorkbook.xlsx")
    workbook = chart_data.getChartDataWorkbook()
    series_name_cell = workbook.getCell(0, "B1")
    series = chart_data.getSeries().add(series_name_cell, ChartType.Pie)
    for row in range(2, 5):
        value_cell = workbook.getCell(0, f"B{row}")
        series.getDataPoints().addDataPointForPieSeries(value_cell)
    for row in range(2, 5):
        category_cell = workbook.getCell(0, f"A{row}")
        chart_data.getCategories().add(category_cell)
    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De tweede (`bool`) parameter van de [setExternalWorkbook](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdata/#setExternalWorkbook) methode wordt gebruikt om op te geven of een Excel‑werkboek geladen moet worden of niet. 
* Wanneer de waarde `False` is, wordt alleen het pad van het werkboek bijgewerkt – de grafiekgegevens worden niet geladen of bijgewerkt vanuit het doel‑werkboek. Deze instelling is nuttig wanneer het doel‑werkboek niet bestaat of niet beschikbaar is. 
* Wanneer de waarde `True` is, worden de grafiekgegevens bijgewerkt vanuit het doel‑werkboek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("http://path/doesnt/exists", False)
    presentation.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Het pad van het externe gegevensbron‑werkboek van een grafiek ophalen**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.  
1. Haal een referentie naar een dia op basis van de index.  
1. Maak een object voor de grafiekvorm.  
1. Maak een object voor het bron‑type ([ChartDataSourceType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatasourcetype/)) dat de gegevensbron van de grafiek vertegenwoordigt.  
1. Specificeer de relevante voorwaarde op basis van het feit dat het bron‑type hetzelfde is als het externe werkboek‑gegevensbron‑type.

Deze Python‑code demonstreert de bewerking:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(1)
    chart = slide.getShapes().get_Item(0)
    source_type = chart.getChartData().getDataSourceType()
    if source_type == ChartDataSourceType.ExternalWorkbook:
        path = chart.getChartData().getExternalWorkbookPath()
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Grafiekgegevens bewerken**

U kunt de gegevens in externe werkboeken bewerken op dezelfde manier als u wijzigingen aanbrengt in de inhoud van interne werkboeken. Wanneer een extern werkboek niet kan worden geladen, wordt er een uitzondering gegooid.

Deze Python‑code is een implementatie van het beschreven proces:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    chart_data.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(jpype.JInt(100))
    presentation.save("presentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Een werkboek herstellen uit de grafiek‑cache**

Als een grafiek een extern werkboek gebruikt dat ontbreekt of niet beschikbaar is, kan Aspose.Slides het werkboek van de grafiek reconstrueren uit de in de presentatie gecachte gegevens. Maak [LoadOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/), configureer deze met [SpreadsheetOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/spreadsheetoptions/), en roep [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nl/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) aan met `True` voordat u de presentatie opent.

Het volgende Python‑voorbeeld opent een presentatie waarbij de grafiek een niet‑beschikbaar extern werkboek verwijst en benadert de herstelde gegevens via [Chart.getChartData](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chart/#getChartData) en [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)
load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    recovered_workbook = chart.getChartData().getChartDataWorkbook()

    # Lees of wijzig hier de herstelde werkboekgegevens.
finally:
    presentation.dispose()
```

Als het externe werkboek niet beschikbaar is en herstel is uitgeschakeld, gooit Aspose.Slides een uitzondering. Schakel herstel alleen in wanneer het gebruiken van de gecachte grafiekgegevens een acceptabele terugval is, omdat de cache mogelijk geen wijzigingen bevat die na de laatste bijwerking van de presentatie in het externe werkboek zijn aangebracht.

## **FAQ**

**Kan ik bepalen of een specifieke grafiek gekoppeld is aan een extern of ingesloten werkboek?**

Ja. Een grafiek heeft een [data source type](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdata/#getDataSourceType) en een [pad naar een extern werkboek](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); als de bron een extern werkboek is, kunt u het volledige pad lezen om te bevestigen dat een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkboeken ondersteund, en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. Dit is handig voor projectportabiliteit; houd er echter rekening mee dat de presentatie het absolute pad opslaat in het PPTX‑bestand.

**Kan ik werkboeken gebruiken die zich op netwerkbronnen/netwerkschijven bevinden?**

Ja, dergelijke werkboeken kunnen worden gebruikt als externe gegevensbron. Het direct bewerken van externe werkboeken vanuit Aspose.Slides wordt echter niet ondersteund – ze kunnen alleen als bron worden gebruikt.

**Overschrijft Aspose.Slides het externe XLSX‑bestand bij het opslaan van de presentatie?**

Nee. De presentatie slaat een [link naar het externe bestand](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) op en gebruikt deze om gegevens te lezen. Het externe bestand zelf wordt niet aangepast wanneer de presentatie wordt opgeslagen.

**Wat moet ik doen als het externe bestand met een wachtwoord is beveiligd?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gangbare aanpak is om de beveiliging vooraf te verwijderen of een ontcijferde kopie voor te bereiden (bijvoorbeeld met [Aspose.Cells](/cells/python-java/)) en naar die kopie te linken.

**Kunnen meerdere grafieken naar hetzelfde externe werkboek verwijzen?**

Ja. Elke grafiek slaat zijn eigen link op. Als ze allemaal naar hetzelfde bestand wijzen, zal een update van dat bestand in elke grafiek zichtbaar worden de volgende keer dat de gegevens worden geladen.