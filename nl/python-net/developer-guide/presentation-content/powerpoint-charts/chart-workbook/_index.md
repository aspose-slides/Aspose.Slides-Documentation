---
title: Beheer diagram-werkboeken in presentaties met Python
linktitle: Diagram-werkboek
type: docs
weight: 70
url: /nl/python-net/chart-workbook/
keywords:
- diagram-werkboek
- diagramgegevens
- werkboekcel
- datalabel
- werkblad
- gegevensbron
- extern werkboek
- externe gegevens
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Ontdek Aspose.Slides voor Python via .NET: beheer moeiteloos diagram-werkboeken in PowerPoint- en OpenDocument-formaten om uw presentatiedata te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u met diagram‑werkboeken in Aspose.Slides kunt werken. Het laat zien hoe u diagramgegevens kunt lezen en schrijven via werkboek‑streams, werkboek‑cellen als diagram‑datumbalken kunt gebruiken, toegang krijgt tot werkbladcollecties en het type gegevensbron voor diagramwaarden kunt opgeven.

Het behandelt tevens het werken met externe werkboeken als diagram‑gegevensbronnen. De voorbeelden demonstreren hoe u een extern werkboek maakt en toewijst, het pad van een extern werkboek dat aan een diagram is gekoppeld opvraagt, en diagramgegevens bewerkt wanneer het werkboek beschikbaar is.

## **Diagramgegevens lezen en schrijven vanuit een werkboek**

Aspose.Slides biedt methoden om diagram‑gegevenswerkboeken te lezen en te schrijven (die diagramgegevens bevatten die met Aspose.Cells zijn bewerkt). **Opmerking:** De diagramgegevens moeten op dezelfde manier zijn georganiseerd of een structuur hebben die vergelijkbaar is met de bron.

De volgende Python‑code toont een voorbeeldbewerking:

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

## **Een werkboekcel instellen als diagramdatumbalk**

Soms heeft u diagram‑labels nodig die rechtstreeks uit cellen in het onderliggende gegevens‑werkboek komen. Aspose.Slides maakt het mogelijk om datalabels te binden aan specifieke werkboekcellen zodat de labeltekst altijd de waarde van de cel weergeeft. Het voorbeeld hieronder laat zien hoe u labels uit cellen inschakelt en geselecteerde labels naar aangepaste cellen in het werkboek van het diagram laat wijzen.

1. Maak een instantie van de [Presentation](https://docs.aspose.com/slides/nl/python-net/api-reference/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar de dia op index.
1. Voeg een bol‑diagram toe met voorbeeldgegevens.
1. Toegang tot de diagramreeks.
1. Gebruik een werkboekcel als datalabel.
1. Sla de presentatie op.

De volgende Python‑code toont hoe u een werkboekcel als diagramdatumbalk instelt:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Instantieer de Presentation‑klasse die een presentatie‑bestand vertegenwoordigt.
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

De volgende Python‑code laat zien hoe u de eigenschap `worksheets` gebruikt om toegang te krijgen tot de werkbladcollectie:

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

## **Het type gegevensbron opgeven**

De volgende Python‑code laat zien hoe u een type gegevensbron opgeeft:

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

## **Detecteren van niet‑ondersteunde ingebedde werkboekformaten**

Aspose.Slides ondersteunt het Excel‑binaire werkboekformaat (.xlsb) niet, dat in sommige diagrammen kan worden ingebed. U kunt de eigenschap `embedded_workbook_type` op [ChartData](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/) combineren met de enumeratie [WorkbookType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/workbooktype/) om niet‑ondersteunde formaten te detecteren en die diagrammen over te slaan.

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
            # Ingebed werkboek is in .xlsb-formaat, wat niet wordt ondersteund.
            continue

        # Lees of wijzig hier de diagram-werkboekgegevens.
```

## **Externe werkboeken**

Aspose.Slides ondersteunt het gebruik van externe werkboeken als gegevensbron voor diagrammen.

### **Externe werkboeken instellen**

Met de methode [ChartData.set_external_workbook](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/set_external_workbook/) kunt u een extern werkboek toewijzen aan een diagram als gegevensbron. Deze methode kan ook het pad naar een extern werkboek bijwerken wanneer het is verplaatst.

Hoewel u gegevens in werkboeken die op externe locaties of bronnen staan niet kunt bewerken, kunt u die werkboeken wel als externe gegevensbronnen gebruiken. Wanneer u een relatief pad opgeeft voor een extern werkboek, wordt dit automatisch omgezet naar een volledig pad.

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

De parameter `update_chart_data` van de methode [set_external_workbook](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/set_external_workbook/) geeft aan of het Excel‑werkboek zal worden geladen.

- Wanneer `update_chart_data` is ingesteld op `False`, wordt alleen het werkboekpad bijgewerkt; de diagramgegevens worden niet geladen of ververst vanuit het doel‑werkboek. Gebruik deze instelling wanneer het doel‑werkboek niet bestaat of niet beschikbaar is.
- Wanneer `update_chart_data` is ingesteld op `True`, worden de diagramgegevens geladen en bijgewerkt vanuit het doel‑werkboek.

### **Externe werkboeken maken**

Met de methoden [read_workbook_stream](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) en [set_external_workbook](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/set_external_workbook/) kunt u een extern werkboek vanaf nul maken of een intern werkboek omzetten naar een extern werkboek.

Deze Python‑code demonstreert het proces van het maken van een extern werkboek:

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

### **Het pad van de externe gegevensbron‑werkboek voor een diagram opvragen**

Soms is de gegevensbron van een diagram gekoppeld aan een extern Excel‑werkboek in plaats van aan de ingebedde gegevens van de presentatie. Met Aspose.Slides kunt u de gegevensbron van het diagram inspecteren en, indien het een extern werkboek betreft, het volledige werkboekpad lezen.

1. Maak een instantie van de [Presentation](https://docs.aspose.com/slides/nl/python-net/api-reference/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar de dia op zijn index.
1. Verkrijg een referentie naar de diagramvorm.
1. Haal de bron ([ChartDataSourceType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatasourcetype/)) op die de diagram‑gegevensbron vertegenwoordigt.
1. Controleer of het bron‑type overeenkomt met het type externe werkboek‑gegevensbron.

De volgende Python‑code demonstreert deze bewerking:

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

U kunt gegevens in externe werkboeken bewerken op dezelfde manier als u gegevens in interne werkboeken bewerkt. Als een extern werkboek niet kan worden geladen, wordt er een uitzondering opgegooid.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan ik bepalen of een specifiek diagram gekoppeld is aan een extern of een ingebed werkboek?**

Ja. Een diagram heeft een [data source type](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/data_source_type/) en een [pad naar een extern werkboek](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/external_workbook_path/); als de bron een extern werkboek is, kunt u het volledige pad lezen om te bevestigen dat een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkboeken ondersteund, en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. Dit is handig voor project‑portabiliteit; houd er echter rekening mee dat de presentatie het absolute pad opslaat in het PPTX‑bestand.

**Kan ik werkboeken gebruiken die zich op netwerkbronnen of -shares bevinden?**

Ja, dergelijke werkboeken kunnen worden gebruikt als externe gegevensbron. Het direct bewerken van externe werkboeken vanuit Aspose.Slides wordt echter niet ondersteund – ze kunnen alleen als bron worden gebruikt.

**Schrijft Aspose.Slides het externe XLSX‑bestand over bij het opslaan van de presentatie?**

Nee. De presentatie slaat een [link naar het externe bestand](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/external_workbook_path/) op en gebruikt die voor het lezen van de gegevens. Het externe bestand zelf wordt niet gewijzigd wanneer de presentatie wordt opgeslagen.

**Wat moet ik doen als het externe bestand met een wachtwoord beschermd is?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gebruikelijke aanpak is om de bescherming vooraf te verwijderen of een ontsleutelde kopie voor te bereiden (bijvoorbeeld met [Aspose.Cells](/cells/python-net/)) en naar die kopie te linken.

**Kunnen meerdere diagrammen naar hetzelfde externe werkboek verwijzen?**

Ja. Elk diagram slaat zijn eigen link op. Als ze allemaal naar hetzelfde bestand wijzen, wordt een wijziging in dat bestand bij de volgende gegevens‑lading weerspiegeld in elk diagram.