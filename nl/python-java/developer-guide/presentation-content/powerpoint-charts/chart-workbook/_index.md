---
title: Beheer diagramwerkboeken in presentaties met Python via Java
linktitle: Diagramwerkboek
type: docs
weight: 70
url: /nl/python-java/chart-workbook/
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
- Python
- Java
- Aspose.Slides
description: "Ontdek Aspose.Slides voor Python via Java: beheer moeiteloos diagramwerkboeken in PowerPoint- en OpenDocument-formaten om uw presentatiedata te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u met diagram‑werkboeken in Aspose.Slides kunt werken. Het toont hoe u diagramgegevens kunt lezen en schrijven via werkboek‑streams, werkboekcellen als diagram‑datumnamen kunt gebruiken, toegang krijgt tot werkbladcollecties, en het type gegevensbron voor diagramwaarden kunt opgeven.

Het behandelt tevens het werken met externe werkboeken als diagram‑databronnen. De voorbeelden tonen hoe u een extern werkboek kunt maken en toewijzen, het pad van een extern werkboek dat aan een diagram is gekoppeld kunt ophalen, en diagramgegevens kunt bewerken wanneer het werkboek beschikbaar is.

Voor werkboekcellen die ontbrekende gegevens vertegenwoordigen, zie [De weergave van lege cellen](/slides/nl/python-java/chart-series/) voor het verschil tussen een lege cel en nul, en een lijndiagram‑vergelijking van de beschikbare weergavemodi.

## **Gegevens opnemen uit verborgen rijen en kolommen**

Gebruik [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) om te bepalen of een diagram gegevens plot uit verborgen werkblad‑rijen en -kolommen. Stel het in op `True` om alleen zichtbare cellen te plotten, of op `False` om zowel zichtbare als verborgen cellen op te nemen. Deze instelling regelt het plotten van het diagram; hij verbergt of maakt geen verborgen werkblad‑rijen of -kolommen zichtbaar.

De [sample presentation](hidden-source-data.pptx) bevat een kolomdiagram als eerste vorm op de eerste dia. Het ingesloten werkblad, `Sheet1`, bevat het bronbereik `A1:C4`. Rij 3 en kolom C zijn verborgen, maar hun cellen bevatten nog steeds waarden.

| Werkbladrij | A: Maand | B: Detailhandel | C: Groothandel (verborgen kolom) |
| --- | --- | --- | --- |
| 2 | januari | 10 | 30 |
| 3 (verborgen rij) | februari | 40 | 60 |
| 4 | maart | 20 | 50 |

Toegang tot broncellen via [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) en lees [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden) om hun verborgen status te inspecteren. Deze methode rapporteert de verborgen status zonder deze te wijzigen. In dit voorbeeld is B2 zichtbaar, B3 behoort tot de verborgen rij, en C2 tot de verborgen kolom; het voorbeeld drukt `False`, `True` en `True` af, respectievelijk.

Voor dit voorbeeld ververst u de diagramgegevens na het wijzigen van de plotinstelling: behoud het ingesloten werkboek met [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) en laad het opnieuw met [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream). Bij het opnemen van alle cellen gebruikt u ook [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) om het volledige bereik te herstellen, inclusief de verborgen februari‑categorie. Het simpelweg wijzigen van de vlag is onvoldoende om de gecachete diagramgegevens en categorielabels in dit voorbeeld te verversen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("hidden-source-data.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        workbook = chart.getChartData().getChartDataWorkbook()
        print("B2 hidden:", workbook.getCell(0, "B2").isHidden())
        print("B3 hidden:", workbook.getCell(0, "B3").isHidden())
        print("C2 hidden:", workbook.getCell(0, "C2").isHidden())

        workbook_data = chart.getChartData().readWorkbookStream()
        for visible_only in (True, False):
            chart.setPlotVisibleCellsOnly(visible_only)

            # Ververs de diagramgegevens uit het ingesloten werkboek.
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # Herstel het volledige bronbereik, inclusief verborgen categorieën.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Het voorbeeld slaat twee versies van de presentatie op: één met alleen de zichtbare detailhandelwaarden (10 en 20), en één met alle zes waarden. De afbeeldingen hieronder illustreren de twee plotmodi. Rij 3 en kolom C blijven verborgen in beide ingesloten werkboeken.

| Alleen zichtbare cellen (`True`) | Alle cellen (`False`) |
| --- | --- |
| ![Alleen zichtbare cellen: detailhandelswaarden 10 en 20 voor januari en maart.](hidden_cells_True.png) | ![Alle cellen: detailhandel‑ en groothandelswaarden voor januari, februari en maart.](hidden_cells_False.png) |

Een verborgen cel met een waarde verschilt van een lege cel. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) bepaalt hoe ontbrekende waarden worden weergegeven; hij omvat of sluit geen verborgen brongegevens uit. Zie [De weergave van lege cellen](/slides/nl/python-java/chart-series/#control-the-display-of-empty-cells) voor een voorbeeld.

## **Het gegevensbereik van een diagram ophalen**

Voordat u werkboekgegevens bijwerkt in een bestaande presentatie, inspecteert u de bronbereiken om te bepalen welke werkbladcellen elk diagram gebruikt. De methode [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) retourneert het huidige gegevensbereik als een werkblad‑gekwalificeerde formule, zoals `Sheet1!$A$1:$D$5`. Hier is `Sheet1` de naam van het werkblad, `!` scheidt het van het celbereik, en `$A$1:$D$5` identificeert de cellen A1 tot en met D5, inclusief. De dollartekens duiden absolute rij‑ en kolomreferenties aan.

De methode leest het huidige bereik zonder het diagram of het werkboek te wijzigen. Als het diagram geen werkboek als gegevensbron gebruikt, wordt een `InvalidOperationException` opgegooid. Zie voor meer informatie de [ChartData API‑referentie](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/).

Dit voorbeeld opent een presentatie en controleert de vormen direct op elke dia op diagrammen. Het drukt de naam en het bronbereik van elk diagram af. Als een diagram geen werkboek gebruikt, drukt het een bericht af en gaat door naar het volgende diagram.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

InvalidOperationException = jpype.JClass("com.aspose.slides.exceptions.InvalidOperationException")

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                try:
                    data_range = shape.getChartData().getRange()
                    print(f"{shape.getName()}: {data_range}")
                except InvalidOperationException:
                    print(f"{shape.getName()}: The chart does not use a workbook as its data source.")
finally:
    presentation.dispose()
```

## **Diagramgegevens lezen en schrijven vanuit een werkboek**

Aspose.Slides for Python via Java biedt de methoden [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) en [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) waarmee u diagram‑werkboeken (die diagramgegevens bevatten die met Aspose.Cells zijn bewerkt) kunt lezen en schrijven. **Opmerking** dat de diagramgegevens op dezelfde manier moeten zijn georganiseerd of een structuur moeten hebben die vergelijkbaar is met de bron.

Dit voorbeeld gebruikt een presentatie met een diagram als eerste vorm op de eerste dia. Het leest het ingesloten werkboek in een byte‑array, wist de bestaande series en categorieën, en schrijft hetzelfde werkboek terug. De wijzigingen blijven in het geheugen; het voorbeeld slaat de presentatie niet op.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **Diagram‑lay‑out valideren na wijziging van het werkboek**

Wanneer u een ingesloten werkboek vervangt door een aangepast werkboek, behoudt het diagram zijn oorspronkelijke series‑ en categorieverzamelingen. Deze mismatch kan ervoor zorgen dat [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) faalt met een index‑out‑of‑range‑fout. Wis de bestaande series en categorieën voordat u het bijgewerkte werkboek terugschrijft naar het diagram. Dit voorbeeld gebruikt een diagram dat de eerste vorm op de eerste dia is. Het commentaar markeert waar de bewerking van het werkboek zou plaatsvinden; het uitvoerbare voorbeeld schrijft het originele werkboek terug en valideert de lay‑out in het geheugen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        # Wijzig hier de workbook-bytes, bijvoorbeeld met Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Het wissen van de verzamelingen verwijdert verouderde gegevensreferenties vóór het terugschrijven van het werkboek. Herbouw eventuele vereiste series‑ en categorietoewijzingen voor het bijgewerkte werkboek voordat u het diagram gebruikt.

## **Een werkboekcel instellen als diagram‑datumnamen**

U kunt tekst uit werkboekcellen gebruiken als diagram‑datumnamen.

Dit voorbeeld voegt een bubbel‑diagram met standaardgegevens toe aan de eerste dia van een bestaande presentatie. Het gebruikt de cellen A10:A12 op werkblad 0 voor de eerste drie namen in de eerste serie, schakelt namen van cellen in, en slaat de bijgewerkte presentatie op.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    
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

De methode [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) biedt toegang tot de werkbladen in een diagram‑werkboek. Dit voorbeeld maakt een taartdiagram met standaardgegevens en drukt elke werkbladnaam af naar de console.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **Het type gegevensbron opgeven**

Dit voorbeeld maakt een 3D‑kolomdiagram met standaardgegevens en stelt twee seriesnamen in met verschillende gegevensbronnen. De eerste naam gebruikt een tekenreeks‑literal; de tweede gebruikt cel C1 op werkblad 0. De enumeratie [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) selecteert de bron voor elke naam. Het voorbeeld slaat de presentatie op met de bijgewerkte serienamen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    literal_name = chart.getChartData().getSeries().get_Item(0).getName()
    literal_name.setDataSourceType(DataSourceType.StringLiterals)
    literal_name.setData("LiteralString")
    cell_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell")
    cell_name.setDataSourceType(DataSourceType.Worksheet)
    cell_name.setData(name_cell)
    
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Niet‑ondersteunde formaten van ingesloten werkboeken detecteren**

Aspose.Slides ondersteunt het Excel‑binaire werkboek‑formaat (.xlsb) niet wanneer dit in sommige diagrammen kan worden ingesloten. U kunt de methode [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) op [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) gebruiken in combinatie met de enumeratie [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) om niet‑ondersteunde formaten te detecteren en die diagrammen over te slaan. Dit voorbeeld inspecteert de vormen op de eerste dia van een bestaande presentatie, slaat niet‑diagramvormen over, en drukt een diagnostisch bericht af voor elk diagram met een ingesloten .xlsb‑werkboek.

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

        is_internal_workbook = chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook
        is_binary_macro = chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue
        # Lees of wijzig ondersteunde diagram-werkboekgegevens hier.
finally:
    presentation.dispose()
```

## **Extern werkboek**

Aspose.Slides ondersteunt het gebruik van externe werkboeken als gegevensbron voor diagrammen.

### **Een extern werkboek maken**

Gebruik [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) en [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) om een ingesloten diagram‑werkboek naar een bestand te exporteren en het diagram aan dat externe werkboek te koppelen.

Dit voorbeeld maakt een taartdiagram met standaardgegevens en exporteert het werkboek. Het voltooit het wegschrijven van het bestand voordat het externe werkboek als diagram‑gegevensbron wordt toegewezen, daarna slaat het de gekoppelde presentatie op.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_path = Path("externalWorkbook1.xlsx").resolve()
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(str(workbook_path))

    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Een extern werkboek instellen**

Met de methode [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) kunt u een extern werkboek aan een diagram toewijzen als gegevensbron. Deze methode kan ook worden gebruikt om een pad naar het externe werkboek bij te werken (als dit verplaatst is).

Hoewel u de gegevens in werkboeken die zich op externe locaties of bronnen bevinden niet kunt bewerken, kunt u dergelijke werkboeken wel als externe gegevensbron gebruiken. Als een relatief pad voor een extern werkboek wordt opgegeven, wordt dit automatisch omgezet naar een volledig pad.

Dit voorbeeld gebruikt een extern werkboek waarvan het werkblad `Sheet1` een serienaam in B1, categorienamen in A2:A4, en numerieke waarden in B2:B4 bevat. Het voorbeeld maakt een taartdiagram, koppelt het werkboek, en gebruikt [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) om A1:B4 te mappen naar één serie en drie categorieën. Het slaat de presentatie op met het gekoppelde diagram.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())
    chart_data.setExternalWorkbook(workbook_path)
    chart_data.setRange("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De parameter `updateChartData` van [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) bepaalt of het werkboek wordt geladen.

* Wanneer `updateChartData` `False` is, wordt alleen het pad van het werkboek bijgewerkt. De diagramgegevens worden niet geladen of bijgewerkt vanuit het doelwerkboek, zodat het werkboek onbeschikbaar kan zijn.
* Wanneer `updateChartData` `True` is, worden de diagramgegevens bijgewerkt vanuit het doelwerkboek.

Het volgende voorbeeld wijst een placeholder‑URL toe met `updateChartData` ingesteld op `False`. Het behoudt de standaardgegevens van het taartdiagram en slaat de presentatie op zonder het onbeschikbare werkboek te laden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", False)

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Het pad van de externe gegevensbron‑werkboek van een diagram ophalen**

Om het werkboek te identificeren dat aan een diagram is gekoppeld, controleert u of het diagram een externe gegevensbron gebruikt en haalt u het werkboekpad op.

Dit voorbeeld inspecteert de eerste vorm op de eerste dia van een presentatie met een gekoppeld extern werkboek. Als het een diagram is dat is gekoppeld aan een extern werkboek, drukt het voorbeeld [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) af naar de console. Daarna slaat het een kopie van de presentatie op.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("externalWorkbook.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.ExternalWorkbook:
            print(chart_data.getExternalWorkbookPath())
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Diagramgegevens bewerken**

U kunt de gegevens in externe werkboeken bewerken op dezelfde manier als u wijzigingen aanbrengt in interne werkboeken. Wanneer een extern werkboek niet kan worden geladen, wordt een uitzondering opgegooid.

Dit voorbeeld gebruikt een diagram dat de eerste vorm op de eerste dia is en is gekoppeld aan een toegankelijk extern werkboek. Het stelt de cel‑gebaseerde waarde van het eerste gegevenspunt in de eerste serie in op 100 en slaat de bijgewerkte presentatie op. Het bewerken van celwaarden kan het gekoppelde externe XLSX‑bestand bijwerken; gebruik een kopie als u het originele werkboek moet behouden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        series = chart.getChartData().getSeries()
        if series.size() > 0 and series.get_Item(0).getDataPoints().size() > 0:
            value_cell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell()
            if value_cell is not None:
                value_cell.setValue(jpype.JInt(100))
                presentation.save("presentation_out.pptx", SaveFormat.Pptx)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **Een werkboek herstellen uit de diagram‑cache**

Als een diagram een extern werkboek gebruikt dat ontbreekt of onbeschikbaar is, kan Aspose.Slides het diagram‑werkboek reconstrueren uit de in de presentatie opgeslagen cache. Maak een [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/) aan, roep [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) aan, en stel [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) in op `True` voordat u de presentatie opent.

Het volgende Python‑voorbeeld herstelt werkboekgegevens voor een diagram dat de eerste vorm op de eerste dia is en verwijst naar een onbeschikbaar extern werkboek. Het haalt de herstelde gegevens op via [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) en [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        recovered_workbook = chart.getChartData().getChartDataWorkbook()

        # Lees of wijzig hier de herstelde werkboekgegevens.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Als het externe werkboek onbeschikbaar is en herstel is uitgeschakeld, gooit Aspose.Slides een uitzondering. Schakel herstel alleen in wanneer het gebruik van de gecachete diagramgegevens een acceptabele fallback is, omdat de cache mogelijk geen wijzigingen bevat die na de laatste update van de presentatie in het externe werkboek zijn aangebracht.

## **FAQ**

**Kan ik bepalen of een specifiek diagram is gekoppeld aan een extern of een ingesloten werkboek?**

Ja. Een diagram heeft een [data source type](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) en een [path to an external workbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); als de bron een extern werkboek is, kunt u het volledige pad lezen om te bevestigen dat er een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkboeken ondersteund, en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. De presentatie slaat het absolute pad op in het PPTX‑bestand, dus het verplaatsen van het werkboek kan vereisen dat de koppeling wordt bijgewerkt.

**Kan ik werkboeken gebruiken die zich op netwerken/resources‑shares bevinden?**

Ja, dergelijke werkboeken kunnen worden gebruikt als externe gegevensbron. Het rechtstreeks bewerken van remote werkboeken vanuit Aspose.Slides wordt echter niet ondersteund – ze kunnen alleen als bron worden gebruikt.

**Overschrijft Aspose.Slides het externe XLSX‑bestand bij het opslaan van de presentatie?**

De presentatie slaat een [link to the external file](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) op. Het bewerken van cel‑gebaseerde diagramgegevens kan ook het gekoppelde lokale XLSX‑bestand bijwerken. Gebruik een kopie van het werkboek als het origineel ongewijzigd moet blijven.

**Wat moet ik doen als het externe bestand met een wachtwoord is beveiligd?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gebruikelijke aanpak is het wachtwoord vooraf te verwijderen of een gedecrypteerde kopie voor te bereiden (bijvoorbeeld met [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) en naar die kopie te koppelen.

**Kunnen meerdere diagrammen dezelfde externe werkboek gebruiken?**

Ja. Elk diagram slaat zijn eigen link op. Als ze allemaal naar hetzelfde bestand wijzen, wordt een wijziging in dat bestand in elk diagram weerspiegeld de volgende keer dat de gegevens worden geladen.