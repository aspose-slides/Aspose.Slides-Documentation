---
title: Beheer grafiekwerkmappen in presentaties met Python via Java
linktitle: Grafiekwerkmap
type: docs
weight: 70
url: /nl/python-java/chart-workbook/
keywords:
- grafiekwerkmap
- grafiekgegevens
- werkbladcel
- gegevenslabel
- werkblad
- gegevensbron
- externe werkmap
- externe gegevens
- grafiekcache
- werkmapherstel
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Ontdek Aspose.Slides voor Python via Java: beheer grafiekwerkmappen moeiteloos in PowerPoint- en OpenDocument-formaten om uw presentatiedata te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u met grafiek‑werkmappen werkt in Aspose.Slides. Het toont hoe u grafiekgegevens kunt lezen en schrijven via werkmap‑streams, werkbladcellen kunt gebruiken als grafiekgegevens‑labels, toegang krijgt tot werkbladcollecties, en het type gegevensbron voor grafiekwaarden kunt specificeren.

Het behandelt ook het werken met externe werkmappen als grafiekgegevensbronnen. De voorbeelden laten zien hoe u een externe werkmap kunt maken en toewijzen, het pad van een externe werkmap die aan een grafiek is gekoppeld kunt ophalen, en grafiekgegevens kunt bewerken wanneer de werkmap beschikbaar is.

Voor werkbladcellen die ontbrekende gegevens vertegenwoordigen, zie [Beheer de weergave van lege cellen](/slides/nl/python-java/chart-series/) voor het verschil tussen een lege cel en nul, en een lijngrafiekvergelijking van de beschikbare weergavemodi.

## **Grafiekgegevens lezen en schrijven vanuit een werkmap**
Aspose.Slides biedt de methoden [readWorkbookStream](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdata/#readWorkbookStream) en [writeWorkbookStream](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdata/#writeWorkbookStream) waarmee u werkmappen met grafiekgegevens kunt lezen en schrijven (bevat graficgegevens bewerkt met Aspose.Cells). **Opmerking** dat de grafiekgegevens op dezelfde manier moeten worden georganiseerd of een structuur moeten hebben die vergelijkbaar is met de bron.

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

### **Grafieklay-out valideren na wijziging van de werkmap**
Wanneer u een ingesloten werkmap vervangt door een gewijzigde versie, behoudt de grafiek zijn oorspronkelijke serie‑ en categorie‑collecties. Deze inconsistentie kan ervoor zorgen dat [Chart.validateChartLayout](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chart/#validateChartLayout) een `ArgumentOutOfRangeException` (parameter: index) gooit. Om de uitzondering te vermijden, verwijdert u de bestaande series en categorieën **voordat** u de bijgewerkte werkmap terugschrijft naar de grafiek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

# Lees de werkmap na bewerking (bijv. met Aspose.Cells).
updated_workbook = Path("updatedWorkbook.xlsx").read_bytes()

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()

    # Verwijder bestaande gegevensreferenties.
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart.writeWorkbookStream(jpype.JArray(jpype.JByte)(updated_workbook))
    chart.validateChartLayout()
finally:
    presentation.dispose()
```

Het legen van de collecties zorgt ervoor dat de structuur van de grafiekgegevens overeenkomt met de nieuwe werkmap, waardoor [validateChartLayout](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chart/#validateChartLayout) zonder fouten kan worden voltooid.

## **Een werkbladcel instellen als een grafiekgegevens‑label**
1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) .
2. Haal een referentie naar een dia op via de index.
3. Voeg een Bubble‑grafiek toe met enkele gegevens.
4. Toegang tot de grafiekseries.
5. Stel de werkbladcel in als een gegevenslabel.
6. Sla de presentatie op.

Deze Python‑code laat zien hoe u een werkbladcel instelt als een grafiekgegevens‑label:

```python
import jpype
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
Deze Python‑code toont een operatie waarbij de methode [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdataworkbook/#getWorksheets) wordt gebruikt om een werkbladcollectie te benaderen:

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

## **Het type gegevensbron specificeren**
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

## **Niet‑ondersteunde ingesloten werkmapformaten detecteren**
Aspose.Slides ondersteunt het binaire Excel‑werkmapformaat (.xlsb) dat in sommige grafieken kan worden ingesloten niet. U kunt de methode [getEmbeddedWorkbookType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) op [ChartData](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdata/) samen met de enumeratie [WorkbookType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/workbooktype/) gebruiken om niet‑ondersteunde formaten te detecteren en die grafieken over te slaan.

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
            # Ingesloten werkmap is in .xlsb-formaat, wat niet wordt ondersteund.
            continue
        # Lees of wijzig hier de grafiekwerkmapgegevens.
finally:
    presentation.dispose()
```

## **Externe werkmap**
Aspose.Slides ondersteunt het gebruik van externe werkmappen als gegevensbron voor grafieken.

### **Een externe werkmap maken**
Met behulp van de methoden [readWorkbookStream](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdata/#readWorkbookStream) en [setExternalWorkbook](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdata/#setExternalWorkbook) kunt u een externe werkmap vanaf nul maken of een interne werkmap extern maken.

Deze Python‑code toont het proces van het maken van een externe werkmap:

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

### **Een externe werkmap toewijzen**
Met de methode [setExternalWorkbook](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdata/#setExternalWorkbook) kunt u een externe werkmap aan een grafiek toewijzen als gegevensbron. Deze methode kan ook worden gebruikt om het pad naar de externe werkmap bij te werken (als die verplaatst is).

Hoewel u de gegevens in werkmappen die op externe locaties of bronnen zijn opgeslagen niet kunt bewerken, kunt u dergelijke werkmappen nog steeds als externe gegevensbron gebruiken. Als een relatief pad voor een externe werkmap wordt opgegeven, wordt dit automatisch omgezet naar een volledig pad.

Deze Python‑code laat zien hoe u een externe werkmap instelt:

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

De tweede (`bool`)‑parameter van de methode [setExternalWorkbook](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdata/#setExternalWorkbook) wordt gebruikt om op te geven of een Excel‑werkmap al dan niet wordt geladen.

* Wanneer de waarde is ingesteld op `False`, wordt alleen het pad van de werkmap bijgewerkt – de grafiekgegevens worden niet geladen of bijgewerkt vanuit de doelwerkmap. U kunt deze instelling gebruiken wanneer de doelwerkmap niet bestaat of niet beschikbaar is.
* Wanneer de waarde is ingesteld op `True`, worden de grafiekgegevens bijgewerkt vanuit de doelwerkmap.

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

### **Het pad van de externe gegevensbron‑werkmap van een grafiek ophalen**
1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) .
2. Haal een referentie naar een dia op via de index.
3. Maak een object voor de grafiekvorm.
4. Maak een object voor het bron‑type ([ChartDataSourceType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatasourcetype/)) dat de gegevensbron van de grafiek vertegenwoordigt.
5. Specificeer de relevante voorwaarde op basis van het feit dat het bron‑type gelijk is aan het type van de externe werkmapgegevensbron.

Deze Python‑code toont de operatie:

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
U kunt de gegevens in externe werkmappen bewerken op dezelfde manier als u wijzigingen aanbrengt in de inhoud van interne werkmappen. Wanneer een externe werkmap niet kan worden geladen, wordt er een uitzondering gegooid.

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

### **Een werkmap herstellen uit de grafiekkachel**
Als een grafiek een externe werkmap gebruikt die ontbreekt of niet beschikbaar is, kan Aspose.Slides de grafiekwerkmap reconstrueren uit de gegevens die in de presentatie zijn gecached. Maak [LoadOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/), configureer deze met [SpreadsheetOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/spreadsheetoptions/), en roep [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nl/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) aan met `True` voordat u de presentatie opent.

Het volgende Python‑voorbeeld opent een presentatie waarvan de grafiek verwijst naar een niet‑beschikbare externe werkmap en haalt de herstelde gegevens op via [Chart.getChartData](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chart/#getChartData) en [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

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

    # Lees of wijzig hier de herstelde werkmapgegevens.
finally:
    presentation.dispose()
```

Als de externe werkmap niet beschikbaar is en herstel is uitgeschakeld, gooit Aspose.Slides een uitzondering. Schakel herstel alleen in wanneer het gebruik van de gecachete grafiekgegevens een acceptabele fallback is, omdat de cache mogelijk geen wijzigingen bevat die na de laatste update van de presentatie in de externe werkmap zijn aangebracht.

## **Veelgestelde vragen**

**Kan ik bepalen of een specifieke grafiek is gekoppeld aan een externe of een ingesloten werkmap?**  
Ja. Een grafiek heeft een [data source type](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdata/#getDataSourceType) en een [pad naar een externe werkmap](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); als de bron een externe werkmap is, kunt u het volledige pad lezen om te bevestigen dat er een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkmappen ondersteund, en hoe worden ze opgeslagen?**  
Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. Dit is handig voor de portabiliteit van het project; houd er echter rekening mee dat de presentatie het absolute pad opslaat in het PPTX‑bestand.

**Kan ik werkmappen gebruiken die zich bevinden op netwerkbronnen/gedeelde mappen?**  
Ja, dergelijke werkmappen kunnen worden gebruikt als een externe gegevensbron. Het bewerken van externe werkmappen rechtstreeks vanuit Aspose.Slides wordt echter niet ondersteund – ze kunnen alleen als bron worden gebruikt.

**Overschrijft Aspose.Slides het externe XLSX‑bestand bij het opslaan van de presentatie?**  
Nee. De presentatie slaat een [link naar het externe bestand](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) op en gebruikt deze voor het lezen van gegevens. Het externe bestand zelf wordt niet gewijzigd wanneer de presentatie wordt opgeslagen.

**Wat moet ik doen als het externe bestand met een wachtwoord is beveiligd?**  
Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gangbare aanpak is om de bescherming vooraf te verwijderen of een gedecrypteerde kopie voor te bereiden (bijvoorbeeld met [Aspose.Cells](/cells/python-java/)) en naar die kopie te linken.

**Kunnen meerdere grafieken naar dezelfde externe werkmap verwijzen?**  
Ja. Elke grafiek slaat zijn eigen link op. Als ze allemaal naar hetzelfde bestand wijzen, zal het bijwerken van dat bestand bij de volgende lading van de gegevens in elke grafiek worden weerspiegeld.