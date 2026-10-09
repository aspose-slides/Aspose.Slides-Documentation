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
description: "Ontdek Aspose.Slides for Python via .NET: beheer moeiteloos diagramwerkboeken in PowerPoint- en OpenDocument-formaten om uw presentatiegegevens te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe je met diagramwerkboeken in Aspose.Slides kunt werken. Het laat zien hoe je diagramgegevens kunt lezen en schrijven via werkboek‑streams, werkboekcellen als diagramgegevenslabels kunt gebruiken, toegang krijgt tot werkbladcollecties en het gegevenstype voor diagramwaarden kunt opgeven.

Het behandelt ook het gebruik van externe werkboeken als diagramgegevensbronnen. De voorbeelden tonen hoe je een extern werkboek maakt en toewijst, het pad van een extern werkboek dat aan een diagram is gekoppeld ophaalt, en diagramgegevens bewerkt wanneer het werkboek beschikbaar is.

Voor werkboekcellen die ontbrekende gegevens vertegenwoordigen, zie [Beheer weergave van lege cellen](/slides/nl/python-net/chart-series/) voor het verschil tussen een lege cel en nul, en een lijndiagram‑vergelijking van de beschikbare weergavemodi.

## **Gegevens opnemen uit verborgen rijen en kolommen**

Gebruik [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) om te bepalen of een diagram gegevens plot uit verborgen werkbladrijen en -kolommen. Stel in op `True` om alleen zichtbare cellen te plotten, of op `False` om zowel zichtbare als verborgen cellen op te nemen. Deze instelling regelt het plotten van het diagram; hij verbergt of maakt werkbladrijen of -kolommen niet zichtbaar.

De [sample presentation](hidden-source-data.pptx) bevat een kolomdiagram als het eerste object op de eerste dia. Het ingebedde werkblad, `Sheet1`, bevat het bronbereik `A1:C4`. Rij 3 en kolom C zijn verborgen, maar hun cellen bevatten nog steeds waarden.

| Werkbladrij | A: Maand | B: Detailhandel | C: Groothandel (verborgen kolom) |
| --- | --- | --- | --- |
| 2 | januari | 10 | 30 |
| 3 (verborgen rij) | februari | 40 | 60 |
| 4 | maart | 20 | 50 |

Toegang tot broncellen via [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) en lees [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) om hun verborgen status te inspecteren. Deze eigenschap is alleen-lezen. In dit bestand is B2 zichtbaar, B3 behoort tot de verborgen rij, en C2 behoort tot de verborgen kolom; het voorbeeld drukt `False`, `True` en `True` af, respectievelijk.

Voor dit voorbeeld, ververs de diagramgegevens na het wijzigen van de plotinstelling: behoud het ingebedde werkboek met [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) en laad het opnieuw met [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). Wanneer alle cellen worden opgenomen, gebruik ook [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) om het volledige bereik, inclusief de verborgen februari‑categorie, te herstellen. Alleen de vlag wijzigen is onvoldoende om de in het voorbeeld gecachede diagramgegevens en categorielabels te verversen.

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

            # Ververs de diagramgegevens vanuit het ingebedde werkboek.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Herstel het volledige bronbereik, inclusief verborgen categorieën.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

Het voorbeeld slaat twee versies van de presentatie op: één met alleen de zichtbare Detailhandelwaarden (10 en 20), en een andere met alle zes waarden. De onderstaande afbeeldingen zijn gerenderd uit de opgeslagen presentaties na het opnieuw openen; beide bestanden behouden hun toegewezen plotinstelling. Rij 3 en kolom C blijven verborgen in beide ingebedde werkboeken.

| Alleen zichtbare cellen (`True`) | Alle cellen (`False`) |
| --- | --- |
| ![Alleen zichtbare cellen: Detailhandelwaarden 10 en 20 voor januari en maart.](hidden_cells_True.png) | ![Alle cellen: Detailhandel‑ en Groothandelwaarden voor januari, februari en maart.](hidden_cells_False.png) |

Een verborgen cel met een waarde verschilt van een lege cel. [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) bepaalt hoe ontbrekende waarden worden weergegeven; het omvat of sluit geen verborgen brongegevens uit. Zie [Beheer weergave van lege cellen](/slides/nl/python-net/chart-series/#control-the-display-of-empty-cells) voor een voorbeeld.

## **Bronbereik van een diagram ophalen**

Voordat je werkboekgegevens bijwerkt in een bestaande presentatie, inspecteer je de bronbereiken om te identificeren welke werkbladcellen elk diagram gebruikt. De methode [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) retourneert het huidige gegevensbereik als een werkblad‑gekwalificeerde formule, bijvoorbeeld `Sheet1!$A$1:$D$5`. Hier is `Sheet1` de werkbladnaam, `!` scheidt deze van het celbereik, en `$A$1:$D$5` identificeert de cellen A1 tot en met D5, inclusief. De dollartekens geven absolute rij‑ en kolomreferenties aan.

De methode leest het huidige bereik zonder het diagram of het werkboek te wijzigen. Als het diagram geen werkboek als gegevensbron gebruikt, wordt een uitzondering opgegooid. Zie voor meer informatie de [ChartData API‑referentie](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/).

Dit voorbeeld opent een presentatie en controleert de objecten rechtstreeks op elke dia voor diagrammen. Het drukt de naam en het bronbereik van elk diagram af. Als het bereik niet kan worden opgehaald, drukt het een diagnostisch bericht af en gaat door naar het volgende diagram.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                try:
                    data_range = shape.chart_data.get_range()
                    print(f"{shape.name}: {data_range}")
                except RuntimeError as error:
                    print(f"{shape.name}: Unable to retrieve the chart data range. {error}")
```

## **Diagramgegevens lezen en schrijven vanuit een werkboek**

Aspose.Slides for Python via .NET biedt de methoden [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) en [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) die het lezen en schrijven van diagram‑werkboeken (bevatten diagramgegevens bewerkt met Aspose.Cells) mogelijk maken. **Opmerking** dat de diagramgegevens op dezelfde manier moeten zijn georganiseerd of een structuur moeten hebben die vergelijkbaar is met de bron.

Dit voorbeeld gebruikt een presentatie met een diagram als het eerste object op de eerste dia. Het leest het ingebedde werkboek in een stream, wist de bestaande reeksen en categorieën, en schrijft hetzelfde werkboek terug. De wijzigingen blijven in het geheugen; het voorbeeld slaat de presentatie niet op.

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

### **Diagramlay-out valideren na werkboekmodificatie**

Wanneer je een ingebed werkboek vervangt door een aangepast werkboek, behoudt het diagram zijn oorspronkelijke reeksen‑ en categorieverzamelingen. Deze mismatch kan ertoe leiden dat [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) faalt met een index‑out‑of‑range‑fout. Wis de bestaande reeksen en categorieën vóór het schrijven van het bijgewerkte werkboek terug naar het diagram. Dit voorbeeld gebruikt een diagram dat het eerste object op de eerste dia is. Het commentaar markeert waar bewerking van het werkboek zou plaatsvinden; het uitvoerbare voorbeeld schrijft het oorspronkelijke werkboek terug en valideert de lay‑out in het geheugen.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # Wijzig de werkboekstream hier, bijvoorbeeld met Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

Het wissen van de verzamelingen verwijdert verouderde gegevensreferenties vóór het terugschrijven van het werkboek. Herbouw eventueel vereiste reeksen‑ en categorietoewijzingen voor het bijgewerkte werkboek voordat je het diagram gebruikt.

## **Een werkboekcel instellen als diagramgegevenslabel**

Je kunt tekst uit werkboekcellen gebruiken als diagramgegevenslabels.

Dit voorbeeld voegt een bubbel‑diagram met standaardgegevens toe aan de eerste dia van een bestaande presentatie. Het gebruikt de cellen A10:A12 op werkblad 0 voor de eerste drie labels in de eerste reeks, schakelt labels vanuit cellen in, en slaat de bijgewerkte presentatie op.

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

De eigenschap [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) biedt toegang tot de werkbladen in een diagram‑werkboek. Dit voorbeeld maakt een cirkel‑diagram met standaardgegevens en drukt elke werkbladnaam af in de console.

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

## **Gegevenstype van de gegevensbron specificeren**

Dit voorbeeld maakt een 3D‑kolomdiagram met standaardgegevens en stelt twee reeksen‑namen in met verschillende gegevensbronnen. De eerste naam gebruikt een tekenreeks‑literal; de tweede gebruikt cel C1 op werkblad 0. De enumeratie [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) selecteert de bron voor elke naam. Het voorbeeld slaat de presentatie op met de bijgewerkte reeksen‑namen.

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

## **Niet‑ondersteunde ingebedde werkboek‑formaten detecteren**

Aspose.Slides ondersteunt het Excel‑binaire werkboekformaat (.xlsb) niet, dat in sommige diagrammen kan worden ingebed. Je kunt de eigenschap [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) op [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) gebruiken samen met de enumeratie [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) om niet‑ondersteunde formaten te detecteren en die diagrammen over te slaan. Dit voorbeeld inspecteert de objecten op de eerste dia van een bestaande presentatie, slaat objecten die geen diagrammen zijn over, en drukt een diagnostisch bericht af voor elk diagram met een ingebed .xlsb‑werkboek.

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

        # Lees of wijzig ondersteunde diagramwerkboekgegevens hier.
```

## **Extern werkboek**

Aspose.Slides ondersteunt het gebruik van externe werkboeken als gegevensbron voor diagrammen.

### **Een extern werkboek maken**

Gebruik [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) en [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) om een ingebed diagram‑werkboek naar een bestand te exporteren en het diagram te koppelen aan dat externe werkboek.

Dit voorbeeld maakt een cirkel‑diagram met standaardgegevens en exporteert het werkboek. Het sluit de uitvoerstroom voordat het externe werkboek als gegevensbron voor het diagram wordt toegewezen, en slaat vervolgens de gekoppelde presentatie op.

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

Met de methode [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) kun je een extern werkboek aan een diagram toewijzen als gegevensbron. Deze methode kan ook worden gebruikt om een pad naar het externe werkboek bij te werken (als het laatstgenoemde is verplaatst).

Hoewel je de gegevens in werkboeken die op externe locaties of bronnen zijn opgeslagen niet kunt bewerken, kun je dergelijke werkboeken toch als externe gegevensbron gebruiken. Als er een relatief pad voor een extern werkboek wordt opgegeven, wordt dit automatisch omgezet naar een volledig pad.

Dit voorbeeld gebruikt een extern werkboek waarvan het werkblad `Sheet1` een reeksennaam in B1, categorienamen in A2:A4 en numerieke waarden in B2:B4 bevat. Het voorbeeld maakt een cirkel‑diagram, koppelt het werkboek, en gebruikt [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) om A1:B4 te mappen naar één reeks en drie categorieën. Het slaat de presentatie met het gekoppelde diagram op.

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

De parameter `update_chart_data` van [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) bepaalt of het werkboek wordt geladen.

* Wanneer `update_chart_data` `False` is, wordt alleen het pad van het werkboek bijgewerkt. De diagramgegevens worden niet geladen of bijgewerkt vanuit het doel­werkboek, zodat het werkboek onbeschikbaar kan blijven.
* Wanneer `update_chart_data` `True` is, worden de diagramgegevens bijgewerkt vanuit het doel­werkboek.

Het volgende voorbeeld kent een tijdelijke URL toe met `update_chart_data` ingesteld op `False`. Het behoudt de standaardgegevens van het cirkel‑diagram en slaat de presentatie op zonder het onbeschikbare werkboek te laden.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Het pad van de externe gegevensbron‑werkboek van een diagram ophalen**

Om het werkboek te identificeren dat aan een diagram is gekoppeld, controleer je of het diagram een externe gegevensbron gebruikt en haal je het werkboekpad op.

Dit voorbeeld inspecteert het eerste object op de eerste dia van een presentatie met een gekoppeld extern werkboek. Als het een diagram is dat naar een extern werkboek linkt, drukt het voorbeeld [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) af in de console. Vervolgens slaat het een kopie van de presentatie op.

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

### **Diagramgegevens bewerken**

Je kunt de gegevens in externe werkboeken op dezelfde manier bewerken als de inhoud van interne werkboeken. Wanneer een extern werkboek niet kan worden geladen, wordt een uitzondering opgegooid.

Dit voorbeeld gebruikt een diagram dat het eerste object op de eerste dia is en gekoppeld is aan een toegankelijk extern werkboek. Het stelt de cel‑gebaseerde waarde van het eerste gegevenspunt in de eerste reeks in op 100 en slaat de bijgewerkte presentatie op. Het bewerken van celwaarden kan het gekoppelde externe XLSX‑bestand bijwerken; gebruik een kopie als je het oorspronkelijke werkboek ongewijzigd wilt houden.

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

### **Een werkboek herstellen uit de diagram‑cache**

Als een diagram een extern werkboek gebruikt dat ontbreekt of niet beschikbaar is, kan Aspose.Slides het diagram‑werkboek reconstrueren uit de in de presentatie gecachete gegevens. Maak een [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) aan, configureer de [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/), en stel [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) in op `True` voordat je de presentatie opent.

De volgende Python‑code herstelt werkboekgegevens voor een diagram dat het eerste object op de eerste dia is en verwijst naar een niet‑beschikbaar extern werkboek. Het krijgt toegang tot de herstelde gegevens via [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) en [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

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

Als het externe werkboek niet beschikbaar is en herstel is uitgeschakeld, gooit Aspose.Slides een uitzondering. Schakel herstel alleen in wanneer het gebruik van de gecachete diagramgegevens een aanvaardbare fallback is, omdat de cache mogelijk geen wijzigingen bevat die na de laatste update van de presentatie in het externe werkboek zijn aangebracht.

## **FAQ**

**Kan ik bepalen of een specifiek diagram is gekoppeld aan een extern of een ingebed werkboek?**

Ja. Een diagram heeft een [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) en een [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/); als de bron een extern werkboek is, kun je het volledige pad lezen om zeker te weten dat een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkboeken ondersteund, en hoe worden ze opgeslagen?**

Ja. Als je een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. De presentatie slaat het absolute pad op in het PPTX‑bestand, dus het verplaatsen van het werkboek kan vereisen dat de koppeling wordt bijgewerkt.

**Kan ik werkboeken gebruiken die zich op netwerkbronnen/share bevinden?**

Ja, dergelijke werkboeken kunnen worden gebruikt als externe gegevensbron. Het direct bewerken van externe werkboeken vanuit Aspose.Slides wordt echter niet ondersteund — ze kunnen alleen als bron worden gebruikt.

**Overschrijft Aspose.Slides het externe XLSX‑bestand bij het opslaan van de presentatie?**

De presentatie slaat een [link to the external file](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) op. Het bewerken van cel‑gebaseerde diagramgegevens kan ook het gekoppelde lokale XLSX‑bestand bijwerken. Gebruik een kopie van het werkboek als het origineel ongewijzigd moet blijven.

**Wat moet ik doen als het externe bestand met een wachtwoord is beveiligd?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gangbare aanpak is om de beveiliging vooraf te verwijderen of een gedecrypteerde kopie voor te bereiden (bijvoorbeeld met [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) en naar die kopie te linken.

**Kunnen meerdere diagrammen naar hetzelfde externe werkboek verwijzen?**

Ja. Elk diagram slaat zijn eigen koppeling op. Als ze allemaal naar hetzelfde bestand wijzen, wordt een wijziging in dat bestand in elk diagram weerspiegeld de volgende keer dat de gegevens worden geladen.