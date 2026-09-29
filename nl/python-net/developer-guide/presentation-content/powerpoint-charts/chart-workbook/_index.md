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
- gegevenslabel
- werkblad
- gegevensbron
- extern werkboek
- externe gegevens
- grafiekkache
- werkboekherstel
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Ontdek Aspose.Slides for Python via .NET: beheer moeiteloos grafiekwerkboeken in PowerPoint- en OpenDocument-formaten om uw presentatiegegevens te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u met grafiek‑werkboeken in Aspose.Slides werkt. Het laat zien hoe u grafiekgegevens kunt lezen en schrijven via werkboek‑streams, werkboekcellen kunt gebruiken als grafiekdatacontlabels, werkbladcollecties kunt benaderen en het type gegevensbron voor grafiekwaarden kunt opgeven.

Het behandelt ook het werken met externe werkboeken als gegevensbronnen voor grafieken. De voorbeelden laten zien hoe u een extern werkboek maakt en toewijst, het pad van een extern werkboek dat aan een grafiek is gekoppeld opvraagt en grafiekgegevens bewerkt wanneer het werkboek beschikbaar is.

Voor werkboekcellen die ontbrekende gegevens vertegenwoordigen, zie [Controleer de weergave van lege cellen](/slides/nl/python-net/chart-series/) voor het verschil tussen een lege cel en nul, en een lijngrafiekvergelijking van de beschikbare weergavemodi.

## **Gegevens opnemen uit verborgen rijen en kolommen**

Gebruik [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) om te bepalen of een grafiek gegevens uit verborgen werkbladrijen en -kolommen plot. Stel deze in op `True` om alleen zichtbare cellen te plotten, of op `False` om zowel zichtbare als verborgen cellen op te nemen. Deze instelling beïnvloedt het plotten van de grafiek; hij verbergt of toont geen werkbladrijen of -kolommen.

Download [hidden-source-data.pptx](hidden-source-data.pptx) en plaats het in de werkmap. De eerste dia bevat een kolomgrafiek als eerste vorm. Het ingebedde werkblad, `Sheet1`, bevat het volgende bronbereik, `A1:C4`. Rij 3 en kolom C zijn verborgen, maar hun cellen bevatten nog steeds waarden.

| Werkbladrij | A: Maand | B: Detailhandel | C: Groothandel (verborgen kolom) |
| --- | --- | --- | --- |
| 2 | januari | 10 | 30 |
| 3 (verborgen rij) | februari | 40 | 60 |
| 4 | maart | 20 | 50 |

Benader de broncellen via [ChartData.chart_data_workbook](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) en lees [ChartDataCell.is_hidden](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatacell/is_hidden/) om hun verborgen status te inspecteren. Deze eigenschap is alleen‑lezen. In dit bestand is B2 zichtbaar, B3 behoort tot de verborgen rij, en C2 behoort tot de verborgen kolom; het voorbeeld geeft respectievelijk `False`, `True` en `True` weer.

Voor dit voorbeeld, ververs de grafiekgegevens nadat de plotinstelling is gewijzigd: behoud het ingebedde werkboek met [read_workbook_stream](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) en laad het opnieuw met [write_workbook_stream](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). Bij het opnemen van alle cellen, gebruik ook [set_range](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/set_range/) om het volledige bereik te herstellen, inclusief de verborgen februari‑categorie. Alleen de vlag wijzigen is onvoldoende om de in cache opgeslagen grafiekgegevens en categorie‑labels van dit voorbeeld te verversen.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("hidden-source-data.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        workbook = chart.chart_data.chart_data_workbook
        print(f"B2 hidden: {workbook.get_cell(0, 'B2').is_hidden}")
        print(f"B3 hidden: {workbook.get_cell(0, 'B3').is_hidden}")
        print(f"C2 hidden: {workbook.get_cell(0, 'C2').is_hidden}")

        workbook_stream = chart.chart_data.read_workbook_stream()
        for visible_only in [True, False]:
            chart.plot_visible_cells_only = visible_only

            # Vernieuw de grafiekgegevens van het ingebedde werkboek.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Herstel het volledige bronbereik, inclusief verborgen categorieën.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

Het voorbeeld slaat `hidden_cells_True.pptx` op met alleen de zichtbare detailhandelwaarden (10 en 20), en `hidden_cells_False.pptx` met alle zes waarden. De onderstaande afbeeldingen zijn gegenereerd uit de opgeslagen presentaties na het opnieuw openen; beide bestanden behouden hun toegewezen plotinstelling. Rij 3 en kolom C blijven verborgen in beide ingebedde werkboeken.

| Alleen zichtbare cellen (`True`) | Alle cellen (`False`) |
| --- | --- |
| ![Alleen zichtbare cellen: detailhandelwaarden 10 en 20 voor januari en maart.](hidden_cells_True.png) | ![Alle cellen: detailhandel- en groothandelwaarden voor januari, februari en maart.](hidden_cells_False.png) |

Een verborgen cel met een waarde verschilt van een lege cel. [Chart.display_blanks_as](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chart/display_blanks_as/) bepaalt hoe ontbrekende waarden worden weergegeven; hij omvat of sluit geen verborgen brongegevens uit. Zie [Controleer de weergave van lege cellen](/slides/nl/python-net/chart-series/#control-the-display-of-empty-cells) voor een voorbeeld.

## **Grafiekgegevens lezen en schrijven vanuit een werkboek**

Aspose.Slides for Python via .NET biedt de methoden [read_workbook_stream](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) en [write_workbook_stream](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) waarmee u grafiekgegevens‑werkboeken kunt lezen en schrijven (bevatten grafiekgegevens bewerkt met Aspose.Cells). **Opmerking** dat de grafiekgegevens op dezelfde manier moeten worden georganiseerd of een structuur moeten hebben die vergelijkbaar is met de bron.

Dit voorbeeld opent `chart.pptx`, die een grafiek moet bevatten als de eerste vorm op de eerste dia. Het leest het ingebedde werkboek in een stream, wist de bestaande reeksen en categorieën, en schrijft hetzelfde werkboek terug. De wijzigingen blijven in het geheugen; het voorbeeld slaat de presentatie niet op.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
    else:
        print("The first shape is not a chart.")
```

### **Grafieklay-out valideren na bewerking van werkboek**

Wanneer u een ingebed werkboek vervangt door een aangepast werkboek, behoudt de grafiek de oorspronkelijke reeksen‑ en categorieverzamelingen. Deze mismatch kan ervoor zorgen dat [Chart.validate_chart_layout](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chart/validate_chart_layout/) faalt met een index‑out‑of‑range‑fout. Wis de bestaande reeksen en categorieën voordat u het bijgewerkte werkboek terugschrijft naar de grafiek. Dit voorbeeld vereist `chart.pptx` met een grafiek als de eerste vorm op de eerste dia. Het commentaar geeft aan waar bewerking van het werkboek zou plaatsvinden; het uitvoerbare voorbeeld schrijft het originele werkboek terug en valideert de lay‑out in het geheugen.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # Pas de werkboek-stream hier aan, bijvoorbeeld met Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

Het wissen van de collecties verwijdert verouderde gegevensreferenties voordat het werkboek wordt teruggeschreven. Bouw eventuele benodigde reeksen‑ en categorizerings‑mappings opnieuw op voor het bijgewerkte werkboek alvorens de grafiek te gebruiken.

## **Een werkboekcel instellen als gegevenslabel van een grafiek**

U kunt tekst uit werkboekcellen gebruiken als gegevenslabels voor grafieken. De volgende stappen tonen hoe u de labels in een bubbelgrafiek koppelt aan cellen in het bijbehorende gegevens‑werkboek.

1. Maak een instantie van de class [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) aan.
2. Benader de eerste dia via de nul‑gebaseerde index.
3. Voeg een bubbelgrafiek toe met standaardgegevens.
4. Benader de grafiekreeksen.
5. Stel de werkboekcel in als gegevenslabel.
6. Sla de presentatie op.

Dit voorbeeld opent `chart2.pptx`, die minstens één dia moet bevatten, en voegt een bubbelgrafiek met standaardgegevens toe. Het gebruikt cellen A10:A12 op werkblad 0 voor de eerste drie labels in de eerste reeks, schakelt labels uit cellen in, en slaat het resultaat op als `resultchart.pptx`.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart2.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    series = chart.chart_data.series[0]
    workbook = chart.chart_data.chart_data_workbook

    series.labels.default_data_label_format.show_label_value_from_cell = True
    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0 cell value")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1 cell value")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2 cell value")

    presentation.save("resultchart.pptx", slides.export.SaveFormat.PPTX)
```

## **Werkbladen beheren**

De eigenschap [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) geeft toegang tot de werkbladen in een grafiek‑werkboek. Dit voorbeeld maakt een cirkelgrafiek met standaardgegevens en drukt elke werkbladnaam af naar de console.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
    workbook = chart.chart_data.chart_data_workbook

    for worksheet in workbook.worksheets:
        print(worksheet.name)
```

## **Het type gegevensbron opgeven**

Dit voorbeeld maakt een 3D‑kolomgrafiek met standaardgegevens en stelt twee reeksnamen in met verschillende gegevensbronnen. De eerste naam gebruikt een tekenreeks‑literal; de tweede gebruikt cel C1 op werkblad 0. De enumeratie [DataSourceType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/datasourcetype/) selecteert de bron voor elke naam. Het resultaat wordt opgeslagen als `pres.pptx`.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    literal_name = chart.chart_data.series[0].name

    literal_name.data_source_type = charts.DataSourceType.STRING_LITERALS
    literal_name.data = "LiteralString"

    cell_name = chart.chart_data.series[1].name
    name_cell = chart.chart_data.chart_data_workbook.get_cell(0, "C1", "NewCell")
    cell_name.data_source_type = charts.DataSourceType.WORKSHEET
    cell_name.data = name_cell

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Onondersteunde ingesloten werkboekformaten detecteren**

Aspose.Slides ondersteunt het Excel‑binaire werkboekformaat (.xlsb) dat in sommige grafieken kan worden ingebed niet. U kunt de eigenschap [embedded_workbook_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) op [ChartData](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/) samen met de enumeratie [WorkbookType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/workbooktype/) gebruiken om niet‑ondersteunde formaten te detecteren en die grafieken over te slaan. Dit voorbeeld inspecteert de vormen op de eerste dia van `sample.pptx`, negeert niet‑grafiekvormen, en drukt een diagnostisch bericht af voor elke grafiek met een ingebed .xlsb‑werkboek.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart_data = shape.chart_data
        is_internal_workbook = chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK
        is_binary_macro = chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue

        # Lees of wijzig ondersteunde grafiekwerkboekgegevens hier.
```

## **Extern werkboek**

Aspose.Slides ondersteunt het gebruik van externe werkboeken als gegevensbron voor grafieken.

### **Een extern werkboek maken**

Gebruik [read_workbook_stream](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) en [set_external_workbook](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/set_external_workbook/) om een ingebed grafiek‑werkboek naar een bestand te exporteren en de grafiek aan dat externe werkboek te koppelen.

Dit voorbeeld maakt een cirkelgrafiek met standaardgegevens, schrijft het werkboek naar `externalWorkbook1.xlsx`, en sluit de output‑stream voordat het bestand wordt toegewezen als de gegevensbron van de grafiek. Het slaat de gekoppelde presentatie op als `externalWorkbook.pptx`.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)
    workbook_path = str(Path("externalWorkbook1.xlsx").resolve())

    workbook_stream = chart.chart_data.read_workbook_stream()
    workbook_data = workbook_stream.read()
    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    chart.chart_data.set_external_workbook(workbook_path)
    presentation.save("externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

### **Een extern werkboek instellen**

Met de methode [set_external_workbook](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/set_external_workbook/) kunt u een extern werkboek aan een grafiek toewijzen als gegevensbron. Deze methode kan ook worden gebruikt om een pad naar het externe werkboek bij te werken (als dat laatste verplaatst is).

Hoewel u de gegevens in werkboeken die op externe locaties of bronnen zijn opgeslagen niet kunt bewerken, kunt u dergelijke werkboeken nog steeds gebruiken als externe gegevensbron. Als een relatief pad voor een extern werkboek wordt opgegeven, wordt dit automatisch omgezet naar een volledig pad.

Dit voorbeeld vereist `externalWorkbook.xlsx` in de werkmap. Het werkblad met de naam `Sheet1` moet een reeksnamen in B1 bevatten, categorienamen in A2:A4, en numerieke waarden in B2:B4. Het voorbeeld maakt een cirkelgrafiek, koppelt het werkboek, en gebruikt [set_range](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/set_range/) om A1:B4 te koppelen aan één reeks en drie categorieën. Het slaat het resultaat op als `Presentation_with_externalWorkbook.pptx`.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart_data = chart.chart_data
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())

    chart_data.set_external_workbook(workbook_path)
    chart_data.set_range("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

De parameter `update_chart_data` van [set_external_workbook](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/set_external_workbook/) bepaalt of het werkboek wordt geladen.

* Wanneer `update_chart_data` `False` is, wordt alleen het pad van het werkboek bijgewerkt. De grafiekgegevens worden niet geladen of bijgewerkt vanuit het doel‑werkboek, dus het werkboek kan afwezig zijn.
* Wanneer `update_chart_data` `True` is, worden de grafiekgegevens bijgewerkt vanuit het doel‑werkboek.

Het volgende voorbeeld kent een tijdelijke URL toe met `update_chart_data` ingesteld op `False`. Het behoudt de standaardgegevens van de cirkelgrafiek en slaat de presentatie op zonder het niet‑beschikbare werkboek te laden.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)

    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Het pad van het externe gegevensbron‑werkboek van een grafiek ophalen**

Om het werkboek dat aan een grafiek is gekoppeld te identificeren, controleer eerst of de grafiek een externe gegevensbron gebruikt. Indien ja, kunt u het pad van het werkboek opvragen door de volgende stappen te volgen.

1. Maak een instantie van de class [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) aan.
2. Benader de eerste dia via de nul‑gebaseerde index.
3. Controleer of de eerste vorm een grafiek is.
4. Lees het type gegevensbron van de grafiek.
5. Indien de bron een extern werkboek is, lees dan het pad.

Dit voorbeeld opent `externalWorkbook.pptx`, gemaakt in het eerdere voorbeeld, en inspecteert de eerste vorm op de eerste dia. Als dit een grafiek is die gekoppeld is aan een extern werkboek, drukt het voorbeeld [external_workbook_path](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/external_workbook_path/) af naar de console. Vervolgens slaat het een kopie van de presentatie op als `Result.pptx`.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("externalWorkbook.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        if chart_data.data_source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
            print(chart_data.external_workbook_path)
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

### **Grafiekgegevens bewerken**

U kunt de gegevens in externe werkboeken bewerken op dezelfde manier als wanneer u wijzigingen aanbrengt in de inhoud van interne werkboeken. Als een extern werkboek niet kan worden geladen, wordt er een uitzondering gegooid.

Dit voorbeeld vereist `presentation.pptx` met een grafiek als de eerste vorm op de eerste dia en een toegankelijke externe werkboek. Het stelt de cel‑gebaseerde waarde van het eerste datapunt in de eerste reeks in op 100 en slaat de presentatie op als `presentation_out.pptx`. Het bewerken van celwaarden kan het gekoppelde externe XLSX‑bestand bijwerken, dus gebruik een kopie indien u het originele werkboek moet behouden.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        series = chart.chart_data.series
        if len(series) > 0 and len(series[0].data_points) > 0:
            value_cell = series[0].data_points[0].value.as_cell
            if value_cell is not None:
                value_cell.value = 100
                presentation.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
```

### **Een werkboek herstellen uit de grafiekkache**

Als een grafiek een extern werkboek gebruikt dat ontbreekt of niet beschikbaar is, kan Aspose.Slides het grafiek‑werkboek reconstrueren uit de in de presentatie gecachete gegevens. Maak [LoadOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/)..., configureer de eigenschap [spreadsheet_options](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/spreadsheet_options/), en stel [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/nl/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) in op `True` voordat u de presentatie opent.

Het volgende Python‑voorbeeld opent `presentation.pptx`, waarvan de eerste vorm op de eerste dia een grafiek moet zijn die verwijst naar een niet‑beschikbaar extern werkboek, en benadert de herstelde gegevens via [Chart.chart_data](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chart/chart_data/) en [ChartData.chart_data_workbook](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        recovered_workbook = chart.chart_data.chart_data_workbook

        # Lees of wijzig hier de herstelde werkboekgegevens.
    else:
        print("The first shape is not a chart.")
```

Als het externe werkboek niet beschikbaar is en herstel uitgeschakeld is, werpt Aspose.Slides een uitzondering. Schakel herstel alleen in wanneer het gebruik van de gecachete grafiekgegevens een acceptabele fallback is, omdat de cache mogelijk niet de wijzigingen bevat die in het externe werkboek zijn aangebracht na de laatste update van de presentatie.

## **FAQ**

**Kan ik bepalen of een specifieke grafiek is gekoppeld aan een extern of een ingebed werkboek?**

Ja. Een grafiek heeft een [data source type](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/data_source_type/) en een [path to an external workbook](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/external_workbook_path/); als de bron een extern werkboek is, kunt u het volledige pad lezen om te bevestigen dat een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkboeken ondersteund, en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. De presentatie slaat het absolute pad op in het PPTX‑bestand, dus bij het verplaatsen van het werkboek kan het nodig zijn de koppeling bij te werken.

**Kan ik werkboeken op netwerkbronnen/‑shares gebruiken?**

Ja, zulke werkboeken kunnen worden gebruikt als een externe gegevensbron. Het direct bewerken van externe werkboeken via Aspose.Slides wordt echter niet ondersteund — ze kunnen alleen als bron worden gebruikt.

**Schrijft Aspose.Slides het externe XLSX‑bestand overschrijven bij het opslaan van de presentatie?**

De presentatie slaat een [link to the external file](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/external_workbook_path/) op. Het bewerken van cell‑gebaseerde grafiekgegevens kan ook het gekoppelde lokale XLSX‑bestand bijwerken. Gebruik een kopie van het werkboek als het origineel ongewijzigd moet blijven.

**Wat moet ik doen als het externe bestand met een wachtwoord beveiligd is?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gebruikelijke aanpak is om de beveiliging vooraf te verwijderen of een gedecrypteerde kopie voor te bereiden (bijvoorbeeld met [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) en die kopie te koppelen.

**Kunnen meerdere grafieken naar hetzelfde externe werkboek verwijzen?**

Ja. Elke grafiek slaat zijn eigen koppeling op. Als ze allemaal naar hetzelfde bestand wijzen, wordt een update van dat bestand bij het volgende laden van de gegevens in elke grafiek weergegeven.