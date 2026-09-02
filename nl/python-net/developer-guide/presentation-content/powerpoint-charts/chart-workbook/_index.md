---
title: Beheer grafiek werkboeken in presentaties met Python
linktitle: Grafiek werkboek
type: docs
weight: 70
url: /nl/python-net/chart-workbook/
keywords:
- grafiek werkboek
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
description: "Ontdek Aspose.Slides voor Python via .NET: beheer moeiteloos grafiek werkboeken in PowerPoint- en OpenDocument-formaten om uw presentatiedata te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe je met grafiek‑werkboeken in Aspose.Slides werkt. Het toont hoe je grafiekgegevens kunt lezen en schrijven via werkboek‑streams, werkboekcellen als grafiek‑databelabels kunt gebruiken, werkbladcollecties kunt benaderen en het gegevenstypetype voor grafiek‑waarden kunt opgeven.

Het behandelt ook het werken met externe werkboeken als bron voor grafiekgegevens. De voorbeelden laten zien hoe je een extern werkboek maakt en toewijst, het pad van een extern werkboek dat aan een grafiek is gekoppeld ophaalt, en grafiekgegevens bewerkt wanneer het werkboek beschikbaar is.

## **Grafiekgegevens lezen en schrijven vanuit een werkboek**

Aspose.Slides biedt methoden om grafiek‑werkboeken (die grafiekgegevens bevatten die met Aspose.Cells zijn bewerkt) te lezen en te schrijven. **Opmerking:** de grafiekgegevens moeten op dezelfde manier zijn georganiseerd of een structuur hebben die vergelijkbaar is met de bron.

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

### **Grafiekindeling valideren na wijziging van het werkboek**

Wanneer je een ingebed werkboek vervangt door een aangepast werkboek, behoudt de grafiek haar oorspronkelijke serie‑ en categorie‑collecties. Deze mismatch kan ertoe leiden dat [IChart.validate_chart_layout](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/ichart/validate_chart_layout/) faalt met een index‑out‑of‑range‑fout. Wis de bestaande series en categorieën voordat je het bijgewerkte werkboek terugschrijft naar de grafiek.

```python
# Na het aanpassen van de werkboek‑stream (bijv. met Aspose.Cells)
updated_workbook = chart_data.read_workbook_stream()

# Wis bestaande gegevenreferenties.
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

Het wissen van de collecties zorgt ervoor dat de structuur van de grafiekgegevens consistent is met het nieuwe werkboek, zodat `validate_chart_layout` zonder fouten kan worden voltooid.

## **Een werkboekcel instellen als grafiekdatabelabel**

Soms heb je grafieklabels nodig die rechtstreeks uit cellen in het onderliggende gegevenswerkboek komen. Aspose.Slides maakt het mogelijk om databelabels te binden aan specifieke werkboekcellen zodat de labeltekst altijd de waarde van de cel weergeeft. Het voorbeeld hieronder toont hoe je waardes‑uit‑cel‑labels inschakelt en geselecteerde labels naar aangepaste cellen in het werkboek van de grafiek laat wijzen.

1. Maak een instantie van de [Presentatie](https://docs.aspose.com/slides/nl/python-net/api-reference/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar de dia op basis van de index.
1. Voeg een bubbelgrafiek toe met voorbeeldgegevens.
1. Benader de grafiekseries.
1. Gebruik een werkboekcel als databelabel.
1. Sla de presentatie op.

De volgende Python‑code laat zien hoe je een werkboekcel instelt als grafiekdatabelabel:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Instantieer de Presentation-klasse die een presentatie-bestand vertegenwoordigt.
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

De volgende Python‑code toont hoe je de eigenschap `worksheets` gebruikt om de werkbladcollectie te benaderen:

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

## **Gegevenstypetype opgeven**

De volgende Python‑code laat zien hoe je een gegevenstypetype opgeeft:

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

## **Niet‑ondersteunde ingesloten werkboekformaten detecteren**

Aspose.Slides ondersteunt het Excel‑binaire werkboekformaat (.xlsb) niet, dat in sommige grafieken kan worden ingesloten. Je kunt de eigenschap `embedded_workbook_type` op [ChartData](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/) combineren met de enumeratie [WorkbookType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/workbooktype/) om niet‑ondersteunde formaten te detecteren en die grafieken over te slaan.

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

        # Lees of wijzig hier de grafiek‑werkboekgegevens.
```

## **Externe werkboeken**

Aspose.Slides ondersteunt het gebruik van externe werkboeken als bron voor grafieken.

### **Externe werkboeken instellen**

Met de methode [ChartData.set_external_workbook](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/set_external_workbook/) kun je een extern werkboek aan een grafiek toewijzen als gegevensbron. Deze methode kan ook het pad naar een extern werkboek bijwerken wanneer het is verplaatst.

Hoewel je gegevens in werkboeken die zich op externe locaties of resources bevinden niet kunt bewerken, kun je die werkboeken wel als externe gegevensbronnen gebruiken. Als je een relatief pad opgeeft voor een extern werkboek, wordt dit automatisch omgezet naar een volledig pad.

De volgende Python‑code toont hoe je een extern werkboek instelt:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # Geef False door zodat alleen het pad wordt opgeslagen: het doelwerkboek hoeft nog niet te bestaan.
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

De parameter `update_chart_data` van de [set_external_workbook](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/set_external_workbook/)‑methode geeft aan of het Excel‑werkboek geladen moet worden.

- Wanneer `update_chart_data` op `False` staat, wordt alleen het werkboekpad bijgewerkt; de grafiekgegevens worden niet geladen of vernieuwd vanuit het doelwerkboek. Gebruik deze instelling wanneer het doelwerkboek niet bestaat of niet beschikbaar is.
- Wanneer `update_chart_data` op `True` staat (standaard), worden de grafiekgegevens geladen en bijgewerkt vanuit het doelwerkboek. Als dat werkboek niet kan worden geopend, wordt een uitzondering met het bericht “External workbook is not available” opgegooid.

### **Externe werkboeken maken**

Met de methoden [read_workbook_stream](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) en [set_external_workbook](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/set_external_workbook/) kun je een extern werkboek van nul af aan maken of een intern werkboek naar een extern werkboek converteren.

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

### **Het pad van de externe gegevensbron‑werkboek voor een grafiek ophalen**

Soms is de gegevensbron van een grafiek gekoppeld aan een extern Excel‑werkboek in plaats van aan de ingesloten gegevens van de presentatie. Met Aspose.Slides kun je de gegevensbron van de grafiek inspecteren en, als het een extern werkboek betreft, het volledige pad van het werkboek lezen.

1. Maak een instantie van de [Presentatie](https://docs.aspose.com/slides/nl/python-net/api-reference/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar de dia op basis van de index.
1. Verkrijg een referentie naar de grafiekvorm.
1. Haal de bron ([ChartDataSourceType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatasourcetype/)) op die de gegevensbron van de grafiek vertegenwoordigt.
1. Controleer of het bron‑type overeenkomt met het type van een extern werkboek.

De volgende Python‑code demonstreert de bewerking:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart_with_external_workbook.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    source_type = chart.chart_data.data_source_type
    if source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **Grafiekgegevens bewerken**

Je kunt gegevens in externe werkboeken bewerken op dezelfde manier als in interne werkboeken. Als een extern werkboek niet kan worden geladen, wordt er een uitzondering gegooid.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Een werkboek herstellen vanuit de grafiek‑cache**

Als een grafiek een extern werkboek gebruikt dat ontbreekt of niet beschikbaar is, kan Aspose.Slides het grafiekwerkboek reconstrueren vanuit de gegevens die in de presentatie zijn gecached. Maak een [LoadOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/)‑object aan en schakel [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/nl/python-net/aspose.slides.spreadsheetoptions/recover_workbook_from_chart_cache/) in via [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/spreadsheet_options/) voordat je de presentatie opent.

De volgende Python‑voorbeeldcode opent een presentatie waarvan de grafiek verwijst naar een niet‑beschikbaar extern werkboek en haalt de herstelde gegevens op via [Chart.chart_data](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chart/chart_data/) en [ChartData.chart_data_workbook](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Lees of bewerk hier de herstelde werkboekgegevens.
```

Als het externe werkboek niet beschikbaar is en herstel is uitgeschakeld, gooit Aspose.Slides een uitzondering. Schakel herstel alleen in wanneer het gebruik van de gecachete grafiekgegevens een acceptabele fallback is, omdat de cache mogelijk geen wijzigingen bevat die na het laatste bijwerken van de presentatie in het externe werkboek zijn aangebracht.

## **FAQ**

**Kan ik bepalen of een specifieke grafiek gekoppeld is aan een extern of een ingesloten werkboek?**

Ja. Een grafiek heeft een [gegevenstypetype](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/data_source_type/) en een [pad naar een extern werkboek](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/external_workbook_path/); als de bron een extern werkboek is, kun je het volledige pad lezen om te bevestigen dat een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkboeken ondersteund, en hoe worden ze opgeslagen?**

Ja. Als je een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. Dit is handig voor project‑portabiliteit; houd er echter rekening mee dat de presentatie het absolute pad opslaat in het PPTX‑bestand.

**Kan ik werkboeken gebruiken die zich op netwerkresources of -shares bevinden?**

Ja, zulke werkboeken kunnen worden gebruikt als externe gegevensbron. Direct bewerken van remote werkboeken vanuit Aspose.Slides wordt echter niet ondersteund – ze kunnen alleen als bron dienen.

**Overschrijft Aspose.Slides het externe XLSX‑bestand bij het opslaan van de presentatie?**

Alleen als je de grafiekgegevens hebt bewerkt. De presentatie slaat een [link naar het externe bestand](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/external_workbook_path/) op en gebruikt die voor het lezen van gegevens, dus openen en opslaan laat het werkboek onaangetast. Waarden die je via de grafiekgegevens wijzigt (zie [Grafiekgegevens bewerken](#edit-chart-data) hierboven) worden echter teruggeschreven naar het externe werkboek wanneer de presentatie wordt opgeslagen – werk met een kopie als het origineel onveranderd moet blijven.

**Wat moet ik doen als het externe bestand met een wachtwoord beveiligd is?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gangbare aanpak is om de bescherming vooraf te verwijderen of een ontcijferde kopie voor te bereiden (bijvoorbeeld met [Aspose.Cells](/cells/python-net/)) en naar die kopie te koppelen.

**Kunnen meerdere grafieken naar hetzelfde externe werkboek verwijzen?**

Ja. Elke grafiek slaat haar eigen link op. Als ze allemaal naar hetzelfde bestand wijzen, worden veranderingen in dat bestand weergegeven in elke grafiek bij de volgende gegevenslading.