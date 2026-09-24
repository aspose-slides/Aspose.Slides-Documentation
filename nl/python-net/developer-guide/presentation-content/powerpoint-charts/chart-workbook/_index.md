---
title: Beheer grafiekwerkboeken in presentaties met Python
linktitle: Grafiekwerkboek
type: docs
weight: 70
url: /nl/python-net/chart-workbook/
keywords:
- grafiekwerkboek
- grafiekgegevens
- werkboekcel
- datalabel
- werkblad
- gegevensbron
- extern werkboek
- externe gegevens
- grafiekcache
- werkboekherstel
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Ontdek Aspose.Slides voor Python via .NET: beheer eenvoudig grafiekwerkboeken in PowerPoint- en OpenDocument-formaten om uw presentatiedata te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe je werkt met grafiek‑werkboeken in Aspose.Slides. Het laat zien hoe je grafiek‑gegevens kunt lezen en schrijven via werkboek‑streams, werkboek‑cellen als grafiek‑databelabels kunt gebruiken, toegang krijgt tot werkblad‑collecties, en het gegevenstype voor grafiekwaarden kunt opgeven.

Het behandelt ook het werken met externe werkboeken als gegevensbron voor grafieken. De voorbeelden tonen hoe je een extern werkboek kunt maken en toewijzen, het pad van een extern werkboek dat aan een grafiek is gekoppeld kunt ophalen, en grafiek‑gegevens kunt bewerken wanneer het werkboek beschikbaar is.

Voor werkboek‑cellen die ontbrekende gegevens vertegenwoordigen, zie [De weergave van lege cellen regelen](/slides/nl/python-net/chart-series/) voor het verschil tussen een lege cel en nul, en een lijngrafiek‑vergelijking van de beschikbare weergavemodi.

## **Grafiek‑gegevens lezen en schrijven vanuit een werkboek**

Aspose.Slides biedt methoden om grafiek‑gegevens‑werkboeken (die grafiekgegevens bevatten die met Aspose.Cells zijn bewerkt) te lezen en te schrijven. **Opmerking:** De grafiek‑gegevens moeten op dezelfde manier of met een vergelijkbare structuur als de bron georganiseerd zijn.

De volgende Python‑code demonstreert een voorbeeldoperatie:

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

### **Grafiek‑lay‑out valideren na werkboek‑aanpassing**

Wanneer je een ingebed werkboek vervangt door een aangepast werkboek, behoudt de grafiek zijn originele serie‑ en categorie‑collecties. Deze mismatch kan ervoor zorgen dat [IChart.validate_chart_layout](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/ichart/validate_chart_layout/) faalt met een index‑out‑of‑range‑fout. Maak de bestaande series en categorieën leeg voordat je het bijgewerkte werkboek terugschrijft naar de grafiek.

```python
# Na het aanpassen van de werkboek‑stream (bijv. met Aspose.Cells)
updated_workbook = chart_data.read_workbook_stream()

# Verwijder bestaande gegevenreferenties.
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

Het leegmaken van de collecties zorgt ervoor dat de structuur van de grafiek‑gegevens consistent is met het nieuwe werkboek, zodat `validate_chart_layout` kan worden voltooid zonder fouten.

## **Een werkboekcel instellen als grafiek‑databelabel**

Soms heb je grafiek‑labels nodig die rechtstreeks uit cellen in het onderliggende gegevens‑werkboek komen. Aspose.Slides stelt je in staat om databelabels te binden aan specifieke werkboekcellen zodat de labeltekst altijd de waarde van de cel weerspiegelt. Het voorbeeld hieronder laat zien hoe je labels op basis van celwaarden inschakelt en geselecteerde labels naar aangepaste cellen in het werkboek van de grafiek wijst.

1. Maak een instantie van de [Presentation](https://docs.aspose.com/slides/nl/python-net/api-reference/aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar de dia op basis van index.
1. Voeg een bubbelsgrafiek toe met voorbeeldgegevens.
1. Toegang tot de grafiek‑series.
1. Gebruik een werkboekcel als datalabel.
1. Sla de presentatie op.

De volgende Python‑code toont hoe je een werkboekcel instelt als grafiek‑databelabel:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Maak een instantie van de Presentation‑klasse die een presentatie‑bestand vertegenwoordigt.
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

De volgende Python‑code demonstreert hoe je de eigenschap `worksheets` gebruikt om toegang te krijgen tot de werkblad‑collectie:

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

## **Gegevenstype van bron opgeven**

De volgende Python‑code toont hoe je een gegevenstype van bron specificeert:

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

## **Niet‑ondersteunde formaten van ingebedde werkboeken detecteren**

Aspose.Slides ondersteunt het Excel‑binaire werkboek‑formaat (.xlsb) niet dat in sommige grafieken kan worden ingebed. Je kunt de eigenschap `embedded_workbook_type` op [ChartData](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/) combineren met de enumeratie [WorkbookType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/workbooktype/) om niet‑ondersteunde formaten te detecteren en die grafieken over te slaan.

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

        # Lees of wijzig hier de grafiek‑werkboekgegevens.
```

## **Externe werkboeken**

Aspose.Slides ondersteunt het gebruik van externe werkboeken als gegevensbron voor grafieken.

### **Externe werkboeken instellen**

Door de methode [ChartData.set_external_workbook](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/set_external_workbook/) te gebruiken, kun je een extern werkboek aan een grafiek toewijzen als diens gegevensbron. Deze methode kan ook het pad naar een extern werkboek bijwerken wanneer het is verplaatst.

Hoewel je geen gegevens kunt bewerken in werkboeken die op externe locaties of bronnen zijn opgeslagen, kun je die werkboeken wel gebruiken als externe gegevensbronnen. Als je een relatief pad opgeeft voor een extern werkboek, wordt dit automatisch omgezet naar een volledig pad.

De volgende Python‑code toont hoe je een extern werkboek instelt:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # Geef False door zodat alleen het pad wordt opgeslagen: het doel‑werkboek hoeft nog niet te bestaan.

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

De parameter `update_chart_data` van de [set_external_workbook](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/set_external_workbook/)‑methode geeft aan of het Excel‑werkboek geladen moet worden.

- Wanneer `update_chart_data` op `False` staat, wordt alleen het werkboek‑pad bijgewerkt; de grafiek‑gegevens worden niet geladen of ververst vanuit het doel‑werkboek. Gebruik deze instelling wanneer het doel‑werkboek niet bestaat of niet beschikbaar is.
- Wanneer `update_chart_data` op `True` staat (standaard), worden de grafiek‑gegevens geladen en bijgewerkt vanuit het doel‑werkboek. Als dat werkboek niet kan worden geopend, wordt een uitzondering met de boodschap “External workbook is not available” opgegooid.

### **Externe werkboeken maken**

Door de methoden [read_workbook_stream](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) en [set_external_workbook](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/set_external_workbook/) te gebruiken, kun je een extern werkboek vanaf nul creëren of een intern werkboek omzetten naar een extern werkboek.

Deze Python‑code demonstreert het proces voor het maken van een extern werkboek:

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

### **Het pad van de externe gegevensbron‑werkboek ophalen voor een grafiek**

Soms is de gegevens van een grafiek gekoppeld aan een extern Excel‑werkboek in plaats van aan de ingebedde gegevens van de presentatie. Met Aspose.Slides kun je de gegevensbron van de grafiek inspecteren en, als het een extern werkboek is, het volledige werkboek‑pad lezen.

1. Maak een instantie van de [Presentation](https://docs.aspose.com/slides/nl/python-net/api-reference/aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar de dia op basis van index.
1. Haal een referentie op naar de grafiekvorm.
1. Verkrijg de bron ([ChartDataSourceType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatasourcetype/)) die de gegevensbron van de grafiek representeert.
1. Controleer of het brontype overeenkomt met het externe werkboek‑gegevenstype.

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

### **Grafiek‑gegevens bewerken**

Je kunt gegevens in externe werkboeken bewerken op dezelfde manier als je gegevens in interne werkboeken bewerkt. Als een extern werkboek niet kan worden geladen, wordt er een uitzondering opgegooid.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Een werkboek herstellen vanuit de grafiek‑cache**

Als een grafiek een extern werkboek gebruikt dat ontbreekt of niet beschikbaar is, kan Aspose.Slides het grafiek‑werkboek reconstrueren vanuit de in de presentatie gecachete gegevens. Maak een [LoadOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/)‑object aan, schakel daarna [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/nl/python-net/aspose.slides.spreadsheetoptions/recover_workbook_from_chart_cache/) in via [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/spreadsheet_options/) voordat je de presentatie opent.

De volgende Python‑voorbeeldcode opent een presentatie waarvan de grafiek verwijst naar een niet‑beschikbaar extern werkboek en krijgt toegang tot de herstelde gegevens via [Chart.chart_data](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chart/chart_data/) en [ChartData.chart_data_workbook](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Lees of wijzig hier de herstelde werkboekgegevens.
```

Als het externe werkboek niet beschikbaar is en herstel is uitgeschakeld, werpt Aspose.Slides een uitzondering. Schakel herstel alleen in wanneer het gebruik van de gecachete grafiek‑gegevens een acceptabele fallback is, omdat de cache mogelijk geen wijzigingen bevat die in het externe werkboek zijn aangebracht nadat de presentatie voor het laatst is bijgewerkt.

## **FAQ**

**Kan ik bepalen of een specifieke grafiek gekoppeld is aan een extern of een ingebed werkboek?**

Ja. Een grafiek heeft een [data source type](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/data_source_type/) en een [path to an external workbook](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/external_workbook_path/); als de bron een extern werkboek is, kun je het volledige pad lezen om er zeker van te zijn dat er een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkboeken ondersteund, en hoe worden ze opgeslagen?**

Ja. Als je een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. Dit is handig voor project‑portabiliteit; houd er echter rekening mee dat de presentatie het absolute pad opslaat in het PPTX‑bestand.

**Kan ik werkboeken gebruiken die zich bevinden op netwerkresources/‑shares?**

Ja, dergelijke werkboeken kunnen worden gebruikt als externe gegevensbron. Het direct bewerken van externe werkboeken vanuit Aspose.Slides wordt echter niet ondersteund — ze kunnen alleen als bron worden gebruikt.

**Schrijft Aspose.Slides het externe XLSX‑bestand over bij het opslaan van de presentatie?**

Alleen als je de grafiek‑gegevens hebt bewerkt. De presentatie slaat een [link to the external file](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/external_workbook_path/) op en gebruikt deze voor het lezen van gegevens, dus het openen en opslaan van een presentatie laat het werkboek onaangetast. Echter, waarden die je via de grafiek‑gegevens wijzigt (zie [Edit Chart Data](#edit-chart-data) hierboven) worden teruggeschreven naar het externe werkboek wanneer de presentatie wordt opgeslagen — werk op een kopie als het origineel intact moet blijven.

**Wat moet ik doen als het externe bestand met een wachtwoord is beveiligd?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gebruikelijke aanpak is om de beveiliging van tevoren te verwijderen of een gedecodeerde kopie voor te bereiden (bijvoorbeeld met [Aspose.Cells](/cells/python-net/)) en naar die kopie te koppelen.

**Kunnen meerdere grafieken naar hetzelfde externe werkboek verwijzen?**

Ja. Elke grafiek slaat zijn eigen link op. Als ze allemaal naar hetzelfde bestand verwijzen, wordt het bijwerken van dat bestand in elke grafiek gereflecteerd bij de volgende keer dat de gegevens worden geladen.