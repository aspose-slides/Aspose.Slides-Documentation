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
description: "Ontdek Aspose.Slides voor Python via .NET: beheer moeiteloos grafiekwerkboeken in PowerPoint- en OpenDocument-formaten om uw presentatiedata te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u met grafiekwerkboeken in Aspose.Slides kunt werken. Het laat zien hoe u grafiekgegevens kunt lezen en schrijven via werkboekstreams, werkboekcellen kunt gebruiken als grafiekdatummarkeringen, toegang krijgt tot werkbladcollecties en het type gegevensbron voor grafiekwaarden specificeert.

Het behandelt ook het werken met externe werkboeken als gegevensbronnen voor grafieken. De voorbeelden tonen hoe u een extern werkboek maakt en toewijst, het pad van een extern werkboek dat aan een grafiek is gekoppeld opvraagt, en grafiekgegevens bewerkt wanneer het werkboek beschikbaar is.

Voor werkboekcellen die ontbrekende gegevens vertegenwoordigen, zie [Controleer de weergave van lege cellen](/slides/nl/python-net/chart-series/) voor het verschil tussen een lege cel en nul, en een lijngrafiekvergelijking van de beschikbare weergavemodi.

## **Gegevens opnemen uit verborgen rijen en kolommen**

Gebruik [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) om te bepalen of een grafiek gegevens plot vanuit verborgen werkbladrijen en -kolommen. Stel in op `True` om alleen zichtbare cellen te plotten, of op `False` om zowel zichtbare als verborgen cellen op te nemen. Deze instelling regelt het plotten van de grafiek; het verbergt of toont geen werkbladrijen of -kolommen.

De [sample presentation](hidden-source-data.pptx) bevat een kolomgrafiek als eerste vorm op de eerste dia. Het ingesloten werkblad, `Sheet1`, bevat het volgende bronbereik, `A1:C4`. Rij 3 en kolom C zijn verborgen, maar hun cellen bevatten nog steeds waarden.

| Werkbladrij | A: Maand | B: Detailhandel | C: Groothandel (verborgen kolom) |
| --- | --- | --- | --- |
| 2 | Januari | 10 | 30 |
| 3 (verborgen rij) | Februari | 40 | 60 |
| 4 | Maart | 20 | 50 |

Toegang tot broncellen via [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) en lees [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) om hun verborgen status te inspecteren. Deze eigenschap is alleen‑lezen. In dit bestand is B2 zichtbaar, B3 behoort tot de verborgen rij, en C2 tot de verborgen kolom; het voorbeeld geeft `False`, `True` en `True` weer.

Voor dit voorbeeld ververst u de grafiekgegevens na het wijzigen van de plotinstelling: behoud het ingesloten werkboek met [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) en laad het opnieuw met [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). Wanneer alle cellen worden opgenomen, gebruik ook [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) om het volledige bereik te herstellen, inclusief de verborgen februari‑categorie. Alleen de vlag wijzigen is niet voldoende om de in dit voorbeeld gecachte grafiekgegevens en categorielabels te verversen.

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

            # Ververs de grafiekgegevens vanaf het ingesloten werkboek.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Herstel het volledige bronbereik, inclusief verborgen categorieën.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

Het voorbeeld slaat twee versies van de presentatie op: één met alleen de zichtbare Detailhandelwaarden (10 en 20), en een andere met alle zes waarden. De onderstaande afbeeldingen zijn gerenderd vanuit de opgeslagen presentaties na heropenen; beide bestanden behouden hun toegewezen plotinstelling. Rij 3 en kolom C blijven verborgen in beide ingesloten werkboeken.

| Alleen zichtbare cellen (`True`) | Alle cellen (`False`) |
| --- | --- |
| ![Alleen zichtbare cellen: Detailhandelwaarden 10 en 20 voor januari en maart.](hidden_cells_True.png) | ![Alle cellen: Detailhandels‑ en groothandelswaarden voor januari, februari en maart.](hidden_cells_False.png) |

Een verborgen cel met een waarde verschilt van een lege cel. [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) bepaalt hoe ontbrekende waarden worden weergegeven; het omvat of sluit verborgen brongegevens niet uit. Zie [Controleer de weergave van lege cellen](/slides/nl/python-net/chart-series/#control-the-display-of-empty-cells) voor een voorbeeld.

## **Bereik van een grafiek ophalen**

Voordat u werkboekgegevens bijwerkt in een bestaande presentatie, inspecteert u de bronbereiken om te identificeren welke werkbladcellen elke grafiek gebruikt. De [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/)‑methode retourneert het huidige gegevensbereik als een werkblad‑gekwalificeerde formule, bijvoorbeeld `Sheet1!$A$1:$D$5`. Hier is `Sheet1` de werkbladnaam, `!` scheidt het van het celbereik, en `$A$1:$D$5` identificeert de cellen A1 tot en met D5, inclusief. De dollartekens duiden absolute rij‑ en kolomreferenties aan.

De methode leest het huidige bereik zonder de grafiek of het werkboek te wijzigen. Als de grafiek geen werkboek als gegevensbron gebruikt, wordt een uitzondering opgegooid. Voor meer informatie, zie de [ChartData API Reference](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/).

Dit voorbeeld opent een presentatie en controleert de vormen rechtstreeks op elke dia voor grafieken. Het print de naam en het bronbereik van elke grafiek. Als het bereik niet kan worden opgehaald, print het een diagnostisch bericht en gaat verder met de volgende grafiek.

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

## **Grafiekgegevens lezen en schrijven vanuit een werkboek**

Aspose.Slides for Python via .NET biedt de [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) en [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) methoden die u in staat stellen grafiekgegevens‑werkboeken (bevat grafiekgegevens bewerkt met Aspose.Cells) te lezen en te schrijven. **Opmerking** dat de grafiekgegevens op dezelfde manier moeten zijn georganiseerd of een structuur moeten hebben die vergelijkbaar is met de bron.

Dit voorbeeld gebruikt een presentatie met een grafiek als eerste vorm op de eerste dia. Het leest het ingesloten werkboek in een stream, wist de bestaande series en categorieën, en schrijft hetzelfde werkboek terug. De wijzigingen blijven in het geheugen; het voorbeeld slaat de presentatie niet op.

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

### **Grafieklayout valideren na wijziging van werkboek**

Wanneer u een ingesloten werkboek vervangt door een aangepast, behoudt de grafiek zijn oorspronkelijke series‑ en categorieverzamelingen. Deze mismatch kan ertoe leiden dat [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) faalt met een index‑out‑of‑range‑fout. Wis de bestaande series en categorieën voordat u het bijgewerkte werkboek terugschrijft naar de grafiek. Dit voorbeeld gebruikt een grafiek die de eerste vorm op de eerste dia is. De commentaarregel markeert waar werkboekbewerking zou plaatsvinden; het uitvoerbare voorbeeld schrijft het originele werkboek terug en valideert de layout in het geheugen.

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

Het wissen van de verzamelingen verwijdert verouderde gegevensreferenties voordat het werkboek wordt teruggeschreven. Bouw eventuele vereiste series‑ en categorietoewijzingen opnieuw voor het bijgewerkte werkboek voordat u de grafiek gebruikt.

## **Aangepaste getalnotaties instellen voor werkboekcellen**

Gebruik [ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) om te bepalen hoe numerieke waarden verschijnen in het ingesloten werkboek van een grafiek. Bijvoorbeeld, een rapport kan een conversieratio als percentage met vier decimalen en een coëfficiënt met vijf decimalen weergeven. Houd beide waarden numeriek zodat ze beschikbaar blijven voor berekeningen en grafiekplotting.

Een getalnotatie verandert de weergave, niet de opgeslagen waarde. De notatie `0.0000%` toont `0.125` als `12.5000%`; het vervangt niet het opgeslagen getal door `12.5`. Evenzo toont `0.00000` `0.1234567` als `0.12346` zonder het opgeslagen getal af te ronden. Als de aangepaste notatie een lege tekenreeks (`""`) is, wordt [preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) in plaats daarvan gebruikt.

Het volgende voorbeeld maakt een kolomgrafiek en krijgt toegang tot zijn cellen via [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/). Op werkblad 0 bevat B2 de conversieratio en C2 de coëfficiënt. Beide cellen leveren grafiekwaarden. Het voorbeeld schakelt ook waardelabels in die gekoppeld zijn aan de bronnotaties.

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

Werkboekcel‑notaties staan los van notaties die direct op grafiekassen of datalabels worden ingesteld. In dit voorbeeld toont elk label de waarde van de broncel omdat [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) is ingeschakeld, en omdat [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) `True` is. Na het opslaan en heropenen van de presentatie tonen de labels `12.5000%` en `0.12346`, zoals hieronder weergegeven. De verticale as gebruikt zijn eigen [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) van `0.00`, met [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) ingesteld op `False`.

Om een datalabel onafhankelijk te formatteren, zet u de bron‑koppeling op `False` en wijst u een eigen [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) toe. Dit wijzigt de notatie van de werkboekcel niet. Bijvoorbeeld, een onafhankelijke label‑notatie van `0.00` toont de eerste waarde als `0.13`, terwijl B2 nog steeds `12.5000%` toont. Zie [Chart Data Labels](/slides/nl/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels) voor directe label‑formattering.

![Kolomgrafiek met brongekoppelde labels die 12,5000% en 0,12346 tonen en een onafhankelijk geformatteerde numerieke as.](custom-cell-formats.png)

## **Een werkboekcel gebruiken als grafiekdatummarkering**

U kunt tekst uit werkboekcellen gebruiken als grafiekdatummarkeringen.

Dit voorbeeld voegt een bubble‑grafiek met standaardgegevens toe aan de eerste dia van een bestaande presentatie. Het gebruikt de cellen A10:A12 op werkblad 0 voor de eerste drie labels in de eerste serie, schakelt labels vanuit cellen in, en slaat de bijgewerkte presentatie op.

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

De eigenschap [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) biedt toegang tot de werkbladen in een grafiek‑werkboek. Dit voorbeeld maakt een cirkeldiagram met standaardgegevens en print elke werkbladnaam naar de console.

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

## **Gegevensbrontype specificeren**

Series‑puntwaarden kunnen ook rechtstreeks als numerieke literals worden opgeslagen. Zie [Set Series Values Using Numeric Literals](/slides/nl/python-net/chart-series/#set-series-values-using-numeric-literals) voor een compleet voorbeeld dat ze opslaat en leest. Het brontype van puntwaarden staat los van de interne of externe werkboekconfiguratie van de grafiek; het gebruik van numerieke literals verwijdert op zich niet het ingesloten werkboek.

Dit voorbeeld maakt een 3D‑kolomgrafiek met standaardgegevens en stelt twee serienamen in met verschillende gegevensbronnen. De eerste naam gebruikt een string‑literal; de tweede gebruikt cel C1 op werkblad 0. De enumeratie [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) selecteert de bron voor elke naam. Het voorbeeld slaat de presentatie op met de bijgewerkte serienamen.

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

## **Niet‑ondersteunde ingesloten werkboekformaten detecteren**

Aspose.Slides ondersteunt het Excel‑binaire werkboek‑formaat (.xlsb) niet wanneer het in sommige grafieken wordt ingesloten. U kunt de eigenschap [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) op [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) gebruiken in combinatie met de enumeratie [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) om niet‑ondersteunde formaten te detecteren en die grafieken over te slaan. Dit voorbeeld inspecteert de vormen op de eerste dia van een bestaande presentatie, slaat niet‑grafiek‑vormen over en print een diagnostisch bericht voor elke grafiek met een ingesloten .xlsb‑werkboek.

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

Gebruik [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) en [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) om een ingesloten grafiek‑werkboek naar een bestand te exporteren en de grafiek aan dat externe werkboek te koppelen.

Dit voorbeeld maakt een cirkeldiagram met standaardgegevens en exporteert het werkboek. Het sluit de output‑stream voordat het externe werkboek als gegevensbron van de grafiek wordt toegewezen, en slaat vervolgens de gekoppelde presentatie op.

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

Met de methode [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) kunt u een extern werkboek aan een grafiek toewijzen als gegevensbron. Deze methode kan ook worden gebruikt om een pad naar het externe werkboek bij te werken (als dat laatste is verplaatst).

Hoewel u de gegevens in werkboeken die op externe locaties of bronnen staan niet kunt bewerken, kunt u dergelijke werkboeken nog steeds als een externe gegevensbron gebruiken. Als een relatief pad voor een extern werkboek wordt opgegeven, wordt dit automatisch omgezet naar een volledig pad.

Dit voorbeeld gebruikt een extern werkboek waarvan het werkblad met de naam `Sheet1` een serienaam bevat in B1, categorienamen in A2:A4, en numerieke waarden in B2:B4. Het voorbeeld maakt een cirkeldiagram, koppelt het werkboek, en gebruikt [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) om A1:B4 te koppelen aan één serie en drie categorieën. Het slaat de presentatie op met de gekoppelde grafiek.

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

* Wanneer `update_chart_data` `False` is, wordt alleen het werkboekpad bijgewerkt. De grafiekgegevens worden niet geladen of bijgewerkt vanuit het doel‑werkboek, zodat het werkboek onbeschikbaar kan zijn.
* Wanneer `update_chart_data` `True` is, worden de grafiekgegevens bijgewerkt vanuit het doel‑werkboek.

Het volgende voorbeeld wijst een placeholder‑URL toe met `update_chart_data` op `False`. Het behoudt de standaardgegevens van de cirkeldiagram en slaat de presentatie op zonder het onbeschikbare werkboek te laden.

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

Om het werkboek te identificeren dat aan een grafiek is gekoppeld, controleert u of de grafiek een externe gegevensbron gebruikt en haalt u het werkboekpad op.

Dit voorbeeld inspecteert de eerste vorm op de eerste dia van een presentatie met een gekoppeld extern werkboek. Als het een grafiek is die aan een extern werkboek is gekoppeld, print het voorbeeld [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) naar de console. Vervolgens slaat het een kopie van de presentatie op.

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

U kunt de gegevens in externe werkboeken op dezelfde manier bewerken als u wijzigingen aanbrengt in de inhoud van interne werkboeken. Wanneer een extern werkboek niet kan worden geladen, wordt een uitzondering opgegooid.

Dit voorbeeld gebruikt een grafiek die de eerste vorm op de eerste dia is en die is gekoppeld aan een toegankelijk extern werkboek. Het stelt de cel‑ondersteunde waarde van het eerste gegevenspunt in de eerste serie in op 100 en slaat de bijgewerkte presentatie op. Het bewerken van celwaarden kan het gekoppelde externe XLSX‑bestand bijwerken, dus gebruik een kopie als u het oorspronkelijke werkboek moet behouden.

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

### **Een werkboek herstellen vanuit de grafiekcache**

Als een grafiek een extern werkboek gebruikt dat ontbreekt of niet beschikbaar is, kan Aspose.Slides het grafiekwerkboek reconstrueren vanuit de in de presentatie gecachede gegevens. Maak een [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) aan, configureer de [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/), en stel [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) in op `True` voordat u de presentatie opent.

Het volgende Python‑voorbeeld herstelt werkboekgegevens voor een grafiek die de eerste vorm op de eerste dia is en verwijst naar een niet‑beschikbaar extern werkboek. Het krijgt toegang tot de herstelde gegevens via [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) en [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

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

Als het externe werkboek niet beschikbaar is en herstel is uitgeschakeld, gooit Aspose.Slides een uitzondering. Schakel herstel alleen in wanneer het gebruik van de gecachede grafiekgegevens een acceptabele fallback is, omdat de cache mogelijk geen wijzigingen bevat die na de laatste update van de presentatie in het externe werkboek zijn aangebracht.

## **FAQ**

**Kan ik bepalen of een specifieke grafiek gekoppeld is aan een extern of een ingesloten werkboek?**

Ja. Een grafiek heeft een [gegevensbrontype](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) en een [pad naar een extern werkboek](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/); als de bron een extern werkboek is, kunt u het volledige pad lezen om zeker te zijn dat er een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkboeken ondersteund, en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. De presentatie slaat het absolute pad op in het PPTX‑bestand, dus bij het verplaatsen van het werkboek kan de koppeling moeten worden bijgewerkt.

**Kan ik werkboeken gebruiken die op netwerkbronnen of -shares staan?**

Ja, dergelijke werkboeken kunnen worden gebruikt als een externe gegevensbron. Het bewerken van externe werkboeken rechtstreeks vanuit Aspose.Slides wordt echter niet ondersteund — ze kunnen alleen als bron worden gebruikt.

**Overschrijft Aspose.Slides het externe XLSX‑bestand bij het opslaan van de presentatie?**

De presentatie slaat een [link to the external file](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) op. Het bewerken van cel‑ondersteunde grafiekgegevens kan ook het gekoppelde lokale XLSX‑bestand bijwerken. Gebruik een kopie van het werkboek als het origineel onveranderd moet blijven.

**Wat moet ik doen als het externe bestand met een wachtwoord is beveiligd?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gebruikelijke aanpak is om de bescherming vooraf te verwijderen of een gedecodeerde kopie (bijvoorbeeld met [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) te maken en naar die kopie te koppelen.

**Kunnen meerdere grafieken naar hetzelfde externe werkboek verwijzen?**

Ja. Elke grafiek slaat zijn eigen koppeling op. Als ze allemaal naar hetzelfde bestand wijzen, wordt het bijwerken van dat bestand gereflecteerd in elke grafiek bij de volgende keer dat de gegevens worden geladen.