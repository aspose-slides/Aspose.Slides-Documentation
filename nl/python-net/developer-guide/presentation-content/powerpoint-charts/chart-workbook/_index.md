---
title: Beheer diagramwerkboeken in presentaties met Python
linktitle: Diagramwerkboek
type: docs
weight: 70
url: /nl/python-net/chart-workbook/
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
- Aspose.Slides
description: "Ontdek Aspose.Slides voor Python via .NET: beheer moeiteloos diagramwerkboeken in PowerPoint- en OpenDocument-formaten om uw presentatiedata te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u met diagramwerkboeken in Aspose.Slides kunt werken. Het laat zien hoe u diagramgegevens kunt lezen en schrijven via werkboek‑streams, werkboekcellen kunt gebruiken als diagramgegevenslabels, toegang krijgt tot werkbladcollecties en hoe u het gegevenstype‑bron voor diagramwaarden kunt opgeven.

Het behandelt ook het werken met externe werkboeken als diagramgegevensbronnen. De voorbeelden tonen hoe een extern werkboek te maken en toe te wijzen, het pad van een extern werkboek dat aan een diagram is gekoppeld op te halen, en diagramgegevens te bewerken wanneer het werkboek beschikbaar is.

## **Diagramgegevens lezen en schrijven vanuit een werkboek**

Aspose.Slides biedt methoden om diagramgegevens‑werkboeken (die diagramgegevens bevatten die met Aspose.Cells zijn bewerkt) te lezen en te schrijven. **Opmerking:** De diagramgegevens moeten op dezelfde manier georganiseerd zijn of een structuur hebben die vergelijkbaar is met de bron.

De volgende Python‑code toont een voorbeeldoperatie:

```py
import aspose.slides as slides

with slides.Presentation("chart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]

    data_stream = chart.chart_data.read_workbook_stream()

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    data_stream.seek(0)
    chart.chart_data.write_workbook_stream(data_stream)
```

## **Een werkboekcel instellen als diagramgegevenslabel**

Soms heeft u diagramlabels nodig die rechtstreeks afkomstig zijn van cellen in het onderliggende gegevenswerkboek. Aspose.Slides maakt het mogelijk om gegevenslabels te binden aan specifieke werkboekcellen, zodat de labeltekst altijd de waarde van de cel weergeeft. Het voorbeeld hieronder laat zien hoe u waarden‑van‑cel‑labels inschakelt en geselecteerde labels toewijst aan aangepaste cellen in het werkboek van het diagram.

1. Maak een instantie van de [Presentation](https://docs.aspose.com/slides/nl/python-net/api-reference/aspose.slides/presentation/) klasse aan.
1. Krijg een referentie naar de dia op index.
1. Voeg een bubbel‑diagram toe met voorbeeldgegevens.
1. Toegang tot de diagramreeksen.
1. Gebruik een werkboekcel als gegevenslabel.
1. Sla de presentatie op.

De volgende Python‑code laat zien hoe u een werkboekcel instelt als diagramgegevenslabel:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_label_value_from_cell = True

    workbook = chart.chart_data.chart_data_workbook

    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2")

    presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **Werkbladen beheren**

De volgende Python‑code toont hoe u de `worksheets`‑eigenschap gebruikt om de werkbladcollectie te benaderen:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)

    workbook = chart.chart_data.chart_data_workbook
    for i in range(len(workbook.worksheets)):
        print(workbook.worksheets[i].name)
```

## **Gegevenstype‑bron opgeven**

De volgende Python‑code laat zien hoe u een gegevenstype‑bron opgeeft:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)

    series_name = chart.chart_data.series[0].name
    series_name.data_source_type = slides.charts.DataSourceType.STRING_LITERALS
    series_name.data = "LiteralString"

    series_name = chart.chart_data.series[1].name
    series_name.data = chart.chart_data.chart_data_workbook.get_cell(0, "B1", "NewCell")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Niet‑ondersteunde ingebedde werkboekformaten detecteren**

Aspose.Slides ondersteunt het binaire Excel‑werkboekformaat (.xlsb) dat in sommige diagrammen kan worden ingesloten niet. U kunt de `embedded_workbook_type`‑eigenschap op [ChartData](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/) gebruiken in combinatie met de [WorkbookType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/workbooktype/)‑enumeratie om niet‑ondersteunde formaten te detecteren en die diagrammen over te slaan.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart = shape
        chart_data = chart.chart_data

        if (chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK and
                chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO):
            # Ingesloten werkboek is in .xlsb-formaat, wat niet wordt ondersteund.
            continue

        # Lees of wijzig hier de diagramwerkboekgegevens.
```

## **Externe werkboeken**

Aspose.Slides ondersteunt het gebruik van externe werkboeken als gegevensbron voor diagrammen.

### **Externe werkboeken instellen**

Door de [ChartData.set_external_workbook](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/set_external_workbook/)‑methode te gebruiken, kunt u een extern werkboek aan een diagram toewijzen als gegevensbron. Deze methode kan ook het pad naar een extern werkboek bijwerken als het wordt verplaatst.

Hoewel u geen gegevens kunt bewerken in werkboeken die op externe locaties of bronnen zijn opgeslagen, kunt u die werkboeken nog steeds gebruiken als externe gegevensbronnen. Als u een relatief pad opgeeft voor een extern werkboek, wordt dit automatisch naar een volledig pad omgezet.

De volgende Python‑code toont hoe u een extern werkboek instelt:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

De `update_chart_data`‑parameter van de [set_external_workbook](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/set_external_workbook/)‑methode geeft aan of het Excel‑werkboek wordt geladen.

- Wanneer `update_chart_data` is ingesteld op `False`, wordt alleen het werkboekpad bijgewerkt; de diagramgegevens worden niet geladen of vernieuwd vanuit het doelwerkboek. Gebruik deze instelling wanneer het doelwerkboek niet bestaat of niet beschikbaar is.
- Wanneer `update_chart_data` is ingesteld op `True`, worden de diagramgegevens geladen en bijgewerkt vanuit het doelwerkboek.

### **Externe werkboeken maken**

Door de [read_workbook_stream](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) en [set_external_workbook](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/set_external_workbook/)‑methoden te gebruiken, kunt u een extern werkboek van nul af aan maken of een intern werkboek omzetten naar een extern werkboek.

De Python‑code toont het proces van het maken van een extern werkboek:

```python
import pathlib
import aspose.slides as slides
import aspose.slides.charts as charts

workbook_path = "external_workbook.xlsx"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)

    workbook_data = chart.chart_data.read_workbook_stream().read()

    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    full_path = str(pathlib.Path(workbook_path).resolve())
    chart.chart_data.set_external_workbook(full_path)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

### **Het pad van de externe gegevensbron‑werkboek voor een diagram ophalen**

Soms is de gegevensbron van een diagram gekoppeld aan een extern Excel‑werkboek in plaats van aan de ingebedde gegevens van de presentatie. Met Aspose.Slides kunt u de gegevensbron van het diagram inspecteren en, indien het een extern werkboek betreft, het volledige pad van het werkboek lezen.

1. Maak een instantie van de [Presentation](https://docs.aspose.com/slides/nl/python-net/api-reference/aspose.slides/presentation/) klasse aan.
1. Krijg een referentie naar de dia op zijn index.
1. Krijg een referentie naar de diagramvorm.
1. Verkrijg de bron ([ChartDataSourceType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatasourcetype/)) die de gegevensbron van het diagram vertegenwoordigt.
1. Controleer of het bron‑type overeenkomt met het externe werkboek‑gegevensbron‑type.

De volgende Python‑code toont de bewerking:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart_with_external_workbook.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    source_type = chart.chart_data.data_source_type
    if source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **Diagramgegevens bewerken**

U kunt gegevens in externe werkboeken bewerken op dezelfde manier als u gegevens in interne werkboeken bewerkt. Als een extern werkboek niet kan worden geladen, wordt er een uitzondering gegooid.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Een werkboek herstellen uit de diagram‑cache**

Als een diagram een extern werkboek gebruikt dat ontbreekt of niet beschikbaar is, kan Aspose.Slides het diagram‑werkboek reconstrueren uit de in de presentatie gecachete gegevens. Maak [LoadOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/) aan en schakel [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/nl/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) in via [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/spreadsheet_options/) voordat u de presentatie opent.

De volgende Python‑code opent een presentatie waarvan het diagram verwijst naar een niet‑beschikbaar extern werkboek en krijgt toegang tot de herstelde gegevens via [Chart.chart_data](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chart/chart_data/) en [ChartData.chart_data_workbook](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Lees of wijzig hier de herstelde werkboekgegevens.
```

Als het externe werkboek niet beschikbaar is en herstel is uitgeschakeld, werpt Aspose.Slides een uitzondering. Schakel herstel alleen in wanneer het gebruik van de gecachete diagramgegevens een acceptabele fallback is, omdat de cache mogelijk geen wijzigingen bevat die later in het externe werkboek zijn aangebracht nadat de presentatie voor het laatst is bijgewerkt.

## **FAQ**

**Kan ik bepalen of een specifiek diagram is gekoppeld aan een extern of een ingebed werkboek?**

Ja. Een diagram heeft een [data source type](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/data_source_type/) en een [path to an external workbook](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/external_workbook_path/); als de bron een extern werkboek is, kunt u het volledige pad lezen om zeker te zijn dat een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkboeken ondersteund, en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. Dit is handig voor de overdraagbaarheid van projecten; houd er echter rekening mee dat de presentatie het absolute pad opslaat in het PPTX‑bestand.

**Kan ik werkboeken gebruiken die zich op netwerkmiddelen/shares bevinden?**

Ja, dergelijke werkboeken kunnen worden gebruikt als een externe gegevensbron. Het rechtstreeks bewerken van externe werkboeken vanuit Aspose.Slides wordt echter niet ondersteund – ze kunnen alleen als bron worden gebruikt.

**Schrijft Aspose.Slides het externe XLSX‑bestand over bij het opslaan van de presentatie?**

Nee. De presentatie slaat een [link to the external file](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/external_workbook_path/) op en gebruikt deze voor het lezen van gegevens. Het externe bestand zelf wordt niet gewijzigd wanneer de presentatie wordt opgeslagen.

**Wat moet ik doen als het externe bestand met een wachtwoord is beveiligd?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gangbare aanpak is om de beveiliging van tevoren te verwijderen of een gedecodeerde kopie voor te bereiden (bijvoorbeeld met [Aspose.Cells](/cells/python-net/)) en naar die kopie te verwijzen.

**Kunnen meerdere diagrammen naar hetzelfde externe werkboek verwijzen?**

Ja. Elk diagram slaat zijn eigen link op. Als ze allemaal naar hetzelfde bestand wijzen, wordt een update van dat bestand in elk diagram weerspiegeld de volgende keer dat de gegevens worden geladen.