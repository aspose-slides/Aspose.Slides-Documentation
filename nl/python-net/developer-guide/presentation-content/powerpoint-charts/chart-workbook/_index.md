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
- grafiekcache
- werkboekherstel
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Ontdek Aspose.Slides voor Python via .NET: beheer moeiteloos grafiekwerkboeken in PowerPoint- en OpenDocument-formaten om uw presentatiedata te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u met diagramwerkboeken in Aspose.Slides kunt werken. Het toont hoe u diagramgegevens kunt lezen en schrijven via werkboek‑streams, werkboekcellen kunt gebruiken als diagramgegevenslabels, werkbladcollecties kunt benaderen en het gegevenstype van de gegevensbron voor diagramwaarden kunt opgeven.

Het behandelt ook het werken met externe werkboeken als diagramgegevensbronnen. De voorbeelden laten zien hoe u een extern werkboek kunt maken en toewijzen, het pad van een extern werkboek dat aan een diagram is gekoppeld kunt ophalen, en diagramgegevens kunt bewerken wanneer het werkboek beschikbaar is.

Voor werkboekcellen die ontbrekende gegevens vertegenwoordigen, zie [De weergave van lege cellen beheren](/slides/nl/python-net/chart-series/) voor het verschil tussen een lege cel en nul, en een lijndiagram‑vergelijking van de beschikbare weergavemodi.

## **Gegevens opnemen uit verborgen rijen en kolommen**

Gebruik [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) om te bepalen of een diagram gegevens plotten uit verborgen werkbladrijen en -kolommen. Stel in op `True` om alleen zichtbare cellen te plotten, of op `False` om zowel zichtbare als verborgen cellen op te nemen. Deze instelling bepaalt het plotten van het diagram; ze verbergt of toont geen werkbladrijen of -kolommen.

De [voorbeeldpresentatie](hidden-source-data.pptx) bevat een kolomdiagram als de eerste vorm op de eerste dia. Het ingebedde werkblad, `Sheet1`, bevat het volgende bronbereik, `A1:C4`. Rij 3 en kolom C zijn verborgen, maar hun cellen bevatten nog steeds waarden.

| Werkbladrij | A: Maand | B: Detailhandel | C: Groothandel (verborgen kolom) |
| --- | --- | --- | --- |
| 2 | Januari | 10 | 30 |
| 3 (hidden row) | Februari | 40 | 60 |
| 4 | Maart | 20 | 50 |

Benader broncellen via [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) en lees [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) om hun verborgen status te inspecteren. Deze eigenschap is alleen‑lezen. In dit bestand is B2 zichtbaar, B3 behoort tot de verborgen rij, en C2 tot de verborgen kolom; het voorbeeld drukt respectievelijk `False`, `True` en `True` af.

Voor dit voorbeeld ververs de diagramgegevens na het wijzigen van de plotinstelling: behoud het ingebedde werkboek met [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) en laad het opnieuw met [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). Wanneer alle cellen worden meegenomen, gebruik ook [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) om het volledige bereik te herstellen, inclusief de verborgen categorie Februari. Alleen de vlag wijzigen is onvoldoende om de in dit voorbeeld gecachete diagramgegevens en categorielabels te verversen.

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

            # Vernieuw de diagramgegevens uit het ingebedde werkboek.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Herstel het volledige bronbereik, inclusief verborgen categorieën.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

Het voorbeeld slaat twee versies van de presentatie op: één met alleen de zichtbare detailhandelwaarden (10 en 20), en een andere met alle zes waarden. De onderstaande afbeeldingen zijn gerenderd vanuit de opgeslagen presentaties na het heropenen ervan; beide bestanden behouden hun toegewezen plotinstelling. Rij 3 en kolom C blijven verborgen in beide ingebedde werkboeken.

| Alleen zichtbare cellen (`True`) | Alle cellen (`False`) |
| --- | --- |
| ![Alleen zichtbare cellen: detailhandelwaarden 10 en 20 voor januari en maart.](hidden_cells_True.png) | ![Alle cellen: detailhandels- en groothandelswaarden voor januari, februari en maart.](hidden_cells_False.png) |

Een verborgen cel met een waarde verschilt van een lege cel. [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) bepaalt hoe ontbrekende waarden worden weergegeven; het omvat of sluit geen verborgen brongegevens uit. Zie [De weergave van lege cellen beheren](/slides/nl/python-net/chart-series/#control-the-display-of-empty-cells) voor een voorbeeld.

## **Het gegevensbereik van een diagram ophalen**

Voordat u werkboekgegevens in een bestaande presentatie bijwerkt, inspecteer de bronbereiken om te bepalen welke werkbladcellen elk diagram gebruikt.

De [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) methode retourneert het huidige gegevensbereik als een werkblad‑gekwalificeerde formule, bijvoorbeeld `Sheet1!$A$1:$D$5`. Hier is `Sheet1` de werkbladnaam, `!` scheidt deze van het celbereik, en `$A$1:$D$5` identificeert de cellen A1 tot en met D5, inclusief. De dollartekens geven absolute rij‑ en kolomreferenties aan.

De methode leest het huidige bereik zonder het diagram of het werkboek te wijzigen. Als het diagram geen werkboek als gegevensbron gebruikt, wordt een uitzondering opgegooid. Voor meer informatie, zie de [ChartData API Reference](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/).

Dit voorbeeld opent een presentatie en controleert de vormen direct op elke dia op diagrammen. Het drukt de naam en het bronbereik van elk diagram af. Als het bereik niet kan worden opgehaald, wordt een diagnostisch bericht afgedrukt en gaat men verder met het volgende diagram.

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

Aspose.Slides for Python via .NET biedt de [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) en [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) methoden waarmee u diagramgegevens‑werkboeken (die diagramgegevens bevatten bewerkt met Aspose.Cells) kunt lezen en schrijven. **Opmerking** dat de diagramgegevens op dezelfde manier moeten worden georganiseerd of een structuur moeten hebben die vergelijkbaar is met de bron.

Dit voorbeeld gebruikt een presentatie met een diagram als de eerste vorm op de eerste dia. Het leest het ingebedde werkboek in een stream, wist de bestaande series en categorieën, en schrijft hetzelfde werkboek terug. De wijzigingen blijven in het geheugen; het voorbeeld slaat de presentatie niet op.

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

Wanneer u een ingebed werkboek vervangt door een gewijzigd werkboek, behoudt het diagram zijn oorspronkelijke series‑ en categorieverzamelingen. Deze afwijking kan ervoor zorgen dat [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) faalt met een index‑out‑of‑range‑fout. Wis de bestaande series en categorieën voordat u het bijgewerkte werkboek terugschrijft naar het diagram. Dit voorbeeld gebruikt een diagram dat de eerste vorm op de eerste dia is. Het commentaar markeert waar de bewerking van het werkboek zou plaatsvinden; het uitvoerbare voorbeeld schrijft het originele werkboek terug en valideert de lay‑out in het geheugen.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # Pas de werkboekstream hier aan, bijvoorbeeld met Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

Het legen van de collecties verwijdert verouderde gegevensreferenties voordat het werkboek wordt teruggeschreven. Bouw eventuele benodigde series‑ en categorietoewijzingen opnieuw op voor het bijgewerkte werkboek voordat u het diagram gebruikt.

## **Aangepaste getalnotaties instellen voor werkboekcellen**

Gebruik [ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) om te bepalen hoe numerieke waarden verschijnen in het ingebedde werkboek van een diagram. Bijvoorbeeld, een rapport kan een conversieratio nodig hebben die als percentage met vier decimalen wordt weergegeven en een coëfficiënt met vijf decimalen. Houd beide waarden numeriek zodat ze beschikbaar blijven voor berekeningen en diagramplotting.

Een getalnotatie wijzigt de weergave, niet de opgeslagen waarde. De notatie `0.0000%` toont `0.125` als `12.5000%`; het vervangt niet het opgeslagen getal door `12.5`. Evenzo toont `0.00000` `0.1234567` als `0.12346` zonder de opgeslagen waarde af te ronden. Als de aangepaste notatie een lege tekenreeks is (`""`), wordt [preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) gebruikt.

Het volgende voorbeeld maakt een kolomdiagram en benadert de cellen via [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/). Op werkblad 0 bevat B2 de conversieratio en C2 de coëfficiënt. Beide cellen leveren diagramwaarden. Het voorbeeld schakelt ook waardenlabels in die gekoppeld zijn aan de bronnotaties.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 270, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 20, 620, 210)
    chart.has_title = False

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00"
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A2", "Sample")
    chart.chart_data.categories.add(category_cell)

    percentage_cell = workbook.get_cell(0, "B2", 0.125)
    percentage_cell.custom_number_format = "0.0000%"
    percentage_name = workbook.get_cell(0, "B1", "Conversion rate")
    percentage_series = chart.chart_data.series.add(percentage_name, chart.type)
    percentage_series.data_points.add_data_point_for_bar_series(percentage_cell)

    precision_cell = workbook.get_cell(0, "C2", 0.1234567)
    precision_cell.custom_number_format = "0.00000"
    precision_name = workbook.get_cell(0, "C1", "Coefficient")
    precision_series = chart.chart_data.series.add(precision_name, chart.type)
    precision_series.data_points.add_data_point_for_bar_series(precision_cell)

    for series in chart.chart_data.series:
        label_format = series.data_points[0].label.data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = True

    presentation.save("CustomCellFormats.pptx", slides.export.SaveFormat.PPTX)
```

De celnotaties van het werkboek staan los van de notaties die rechtstreeks op diagramassen of gegevenslabels worden ingesteld. In dit voorbeeld toont elk label de waarde van de broncel omdat [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) is ingeschakeld, en volgt het de brongetalnotatie omdat [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) `True` is. Na het opslaan en opnieuw openen van de presentatie tonen de labels `12.5000%` en `0.12346`, zoals hieronder weergegeven. De verticale as gebruikt zijn eigen [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) van `0.00`, met [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) ingesteld op `False`.

Om een gegevenslabel onafhankelijk te formatteren, stel de bron‑koppelvlag in op `False` en wijs zijn [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) toe. Dit verandert de notatie van de werkboekcel niet. Bijvoorbeeld, een onafhankelijk label met notatie `0.00` toont de eerste waarde als `0.13`, terwijl B2 nog steeds `12.5000%` toont. Zie [Diagramgegevenslabels](/slides/nl/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels) voor directe labelopmaak.

![Kolomdiagram met bron‑gekoppelde labels die 12.5000% en 0.12346 tonen en een onafhankelijk geformatteerde numerieke as.](custom-cell-formats.png)

## **Een werkboekcel instellen als diagramgegevenslabel**

U kunt tekst uit werkboekcellen gebruiken als diagramgegevenslabels.

Dit voorbeeld voegt een bubbel­diagram met standaardgegevens toe aan de eerste dia van een bestaande presentatie. Het gebruikt cellen A10:A12 op werkblad 0 voor de eerste drie labels in de eerste serie, schakelt labels vanuit cellen in, en slaat de bijgewerkte presentatie op.

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

De [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) eigenschap geeft toegang tot de werkbladen in een diagramwerkboek. Dit voorbeeld maakt een cirkeldiagram met standaardgegevens en drukt elke werkbladnaam af naar de console.

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

Dit voorbeeld maakt een 3D‑kolomdiagram met standaardgegevens en stelt twee serienaam­s in met verschillende gegevensbronnen. De eerste naam gebruikt een tekenreeks‑literal; de tweede gebruikt cel C1 op werkblad 0. De [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) enumeratie selecteert de bron voor elke naam. Het voorbeeld slaat de presentatie op met de bijgewerkte serienaam­s.

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

## **Niet‑ondersteunde ingebedde werkboekformaten detecteren**

Aspose.Slides ondersteunt het Excel‑binaire werkboekformaat (.xlsb) dat in sommige diagrammen kan worden ingebed niet. U kunt de [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) eigenschap op [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) samen met de [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) enumeratie gebruiken om niet‑ondersteunde formaten te detecteren en die diagrammen over te slaan. Dit voorbeeld inspecteert de vormen op de eerste dia van een bestaande presentatie, slaat niet‑diagram vormen over, en drukt een diagnostisch bericht af voor elk diagram met een ingebed .xlsb‑werkboek.

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

Gebruik [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) en [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) om een ingebed diagramwerkboek naar een bestand te exporteren en het diagram aan dat externe werkboek te koppelen.

Dit voorbeeld maakt een cirkeldiagram met standaardgegevens en exporteert het werkboek. Het sluit de output‑stream voordat het externe werkboek als de diagramgegevensbron wordt toegewezen, en slaat vervolgens de gekoppelde presentatie op.

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

Met de [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) methode kunt u een extern werkboek aan een diagram toewijzen als zijn gegevensbron. Deze methode kan ook worden gebruikt om een pad naar het externe werkboek bij te werken (als het laatstgenoemde verplaatst is).

Hoewel u de gegevens in werkboeken die op externe locaties of bronnen zijn opgeslagen niet kunt bewerken, kunt u dergelijke werkboeken nog steeds als externe gegevensbron gebruiken. Als een relatief pad voor een extern werkboek wordt opgegeven, wordt dit automatisch omgezet naar een volledig pad.

Dit voorbeeld gebruikt een extern werkboek waarvan het werkblad `Sheet1` een serienaam bevat in B1, categorienamen in A2:A4, en numerieke waarden in B2:B4. Het voorbeeld maakt een cirkeldiagram, koppelt het werkboek, en gebruikt [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) om A1:B4 toe te wijzen aan één serie en drie categorieën. Het slaat de presentatie op met het gekoppelde diagram.

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

De `update_chart_data` parameter van [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) bepaalt of het werkboek wordt geladen.

* Wanneer `update_chart_data` `False` is, wordt alleen het werkboekpad bijgewerkt. De diagramgegevens worden niet geladen of bijgewerkt vanuit het doel‑werkboek, zodat het werkboek onbeschikbaar kan zijn.
* Wanneer `update_chart_data` `True` is, worden de diagramgegevens bijgewerkt vanuit het doel‑werkboek.

Het volgende voorbeeld wijst een tijdelijke URL toe met `update_chart_data` ingesteld op `False`. Het behoudt de standaardgegevens van het cirkeldiagram en slaat de presentatie op zonder het onbeschikbare werkboek te laden.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Het werkboek‑pad van de externe gegevensbron van een diagram opvragen**

Om het werkboek dat aan een diagram is gekoppeld te identificeren, controleer of het diagram een externe gegevensbron gebruikt en haal het werkboek‑pad op.

Dit voorbeeld inspecteert de eerste vorm op de eerste dia van een presentatie met een gekoppeld extern werkboek. Als het een diagram is dat aan een extern werkboek is gekoppeld, drukt het voorbeeld [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) af naar de console. Vervolgens slaat het een kopie van de presentatie op.

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

U kunt de gegevens in externe werkboeken bewerken op dezelfde manier als u wijzigingen aanbrengt in de inhoud van interne werkboeken. Wanneer een extern werkboek niet kan worden geladen, wordt er een uitzondering opgegooid.

Dit voorbeeld gebruikt een diagram dat de eerste vorm op de eerste dia is en gekoppeld aan een toegankelĳk extern werkboek. Het stelt de cel‑gebaseerde waarde van het eerste gegevenspunt in de eerste serie in op 100 en slaat de bijgewerkte presentatie op. Het bewerken van celwaarden kan het gekoppelde externe XLSX‑bestand bijwerken, dus gebruik een kopie als u het originele werkboek moet behouden.

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

### **Een werkboek uit de diagram‑cache herstellen**

Als een diagram een extern werkboek gebruikt dat ontbreekt of niet beschikbaar is, kan Aspose.Slides het diagramwerkboek reconstrueren uit de in de presentatie gecachete gegevens. Maak [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) aan, configureer de [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/), en stel [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) in op `True` voordat u de presentatie opent.

Het volgende Python‑voorbeeld herstelt werkboekgegevens voor een diagram dat de eerste vorm op de eerste dia is en een onbeschikbaar extern werkboek refereert. Het benadert de herstelde gegevens via [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) en [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

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

        # Lees of wijzig de herstelde werkboekgegevens hier.
    else:
        print("The first shape is not a chart.")
```

Als het externe werkboek niet beschikbaar is en herstel is uitgeschakeld, werpt Aspose.Slides een uitzondering. Schakel herstel alleen in wanneer het gebruik van de gecachete diagramgegevens een acceptabele fallback is, omdat de cache mogelijk niet de wijzigingen bevat die na de laatste update van de presentatie aan het externe werkboek zijn aangebracht.

## **FAQ**

**Kan ik bepalen of een specifiek diagram is gekoppeld aan een extern of een ingebed werkboek?**

Ja. Een diagram heeft een [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) en een [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/); als de bron een extern werkboek is, kunt u het volledige pad lezen om er zeker van te zijn dat er een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkboeken ondersteund, en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. De presentatie slaat het absolute pad op in het PPTX‑bestand, zodat het verplaatsen van het werkboek mogelijk het bijwerken van de koppeling vereist.

**Kan ik werkboeken gebruiken die zich op netwerklocaties of -shares bevinden?**

Ja, dergelijke werkboeken kunnen worden gebruikt als een externe gegevensbron. Het rechtstreeks bewerken van externe werkboeken vanuit Aspose.Slides wordt echter niet ondersteund – ze kunnen alleen als bron worden gebruikt.

**Schrijft Aspose.Slides het externe XLSX‑bestand over bij het opslaan van de presentatie?**

De presentatie slaat een [link to the external file](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) op. Het bewerken van cel‑gebaseerde diagramgegevens kan ook het gekoppelde lokale XLSX‑bestand bijwerken. Gebruik een kopie van het werkboek als het origineel onveranderd moet blijven.

**Wat moet ik doen als het externe bestand met een wachtwoord is beveiligd?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gangbare aanpak is om de bescherming van tevoren te verwijderen of een gedecodeerde kopie voor te bereiden (bijvoorbeeld met [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) en naar die kopie te koppelen.

**Kunnen meerdere diagrammen naar hetzelfde externe werkboek verwijzen?**

Ja. Elk diagram slaat zijn eigen koppeling op. Als ze allemaal naar hetzelfde bestand wijzen, wordt het bijwerken van dat bestand bij de volgende keer dat de gegevens worden geladen in elk diagram weerspiegeld.