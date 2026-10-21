---
title: Hantera diagramarbetsböcker i presentationer med Python
linktitle: Diagramarbetsbok
type: docs
weight: 70
url: /sv/python-net/chart-workbook/
keywords:
- diagramarbetsbok
- diagramdata
- arbetsbokscell
- datamärkning
- kalkylark
- datakälla
- extern arbetsbok
- extern data
- diagramcache
- arbetsboksåterställning
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Upptäck Aspose.Slides för Python via .NET: hantera enkelt diagramarbetsböcker i PowerPoint- och OpenDocument-format för att effektivisera dina presentationsdata."
---
## **Översikt**

Det här artikeln förklarar hur man arbetar med diagramarbetsböcker i Aspose.Slides. Den visar hur man läser och skriver diagramdata via arbetsbokströmmar, använder arbetsboksceller som diagramdatamärkningar, får åtkomst till kalkylarksamlingar och anger datakälltyp för diagramvärden.

Den täcker även arbete med externa arbetsböcker som diagramdatakällor. Exemplet demonstrerar hur man skapar och tilldelar en extern arbetsbok, hämtar sökvägen till en extern arbetsbok som är länkad till ett diagram, och redigerar diagramdata när arbetsboken är tillgänglig.

För arbetsboksceller som representerar saknad data, se [Kontrollera visning av tomma celler](/slides/sv/python-net/chart-series/) för skillnaden mellan en tom cell och noll, samt en linjediagramjämförelse av de tillgängliga visningslägena.

## **Inkludera data från dolda rader och kolumner**

Använd [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) för att styra om ett diagram plottar data från dolda kalkylarksrader och -kolumner. Sätt den till `True` för att plotta endast synliga celler, eller `False` för att inkludera både synliga och dolda celler. Denna inställning styr diagramplotting; den döljer eller visar inte kalkylarksrader eller -kolumner.

[Exempelpresentationen](hidden-source-data.pptx) innehåller ett stapeldiagram som den första formen på den första bilden. Det inbäddade kalkylarket, `Sheet1`, innehåller följande källintervall, `A1:C4`. Rad 3 och kolumn C är dolda, men deras celler innehåller fortfarande värden.

| Kalkylarkrad | A: Månad | B: Detaljhandel | C: Partihandel (dolt kolumn) |
| --- | --- | --- | --- |
| 2 | Januari | 10 | 30 |
| 3 (dolt rad) | Februari | 40 | 60 |
| 4 | Mars | 20 | 50 |

Få åtkomst till källceller via [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) och läs [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) för att inspektera deras dolda status. Denna egenskap är skrivskyddad. I den här filen är B2 synlig, B3 tillhör den dolda raden och C2 tillhör den dolda kolumnen; exemplet skriver ut `False`, `True` och `True` respektive.

För detta exempel, uppdatera diagramdata efter att ha ändrat plotinställningen: behåll den inbäddade arbetsboken med [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) och läs in den igen med [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). När alla celler inkluderas, använd också [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) för att återställa hela intervallet, inklusive den dolda februari-kategorin. Att bara ändra flaggan räcker inte för att uppdatera detta exempels cachelagrade diagramdata och kategorimärkningar.

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

            # Uppdatera diagramdata från den inbäddade arbetsboken.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Återställ hela källintervallet, inklusive dolda kategorier.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

Exemplet sparar två versioner av presentationen: en med endast de synliga detaljhandelsvärdena (10 och 20), och en med alla sex värden. Bilderna nedan renderades från de sparade presentationerna efter att de öppnats igen; båda filerna bevarar sin tilldelade plotinställning. Rad 3 och kolumn C förblir dolda i båda inbäddade arbetsböckerna.

| Endast synliga celler (`True`) | Alla celler (`False`) |
| --- | --- |
| ![Endast synliga celler: Detaljhandelsvärden 10 och 20 för Januari och Mars.](hidden_cells_True.png) | ![Alla celler: Detaljhandel- och Partihandelsvärden för Januari, Februari och Mars.](hidden_cells_False.png) |

En dold cell som innehåller ett värde skiljer sig från en tom cell. [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) styr hur saknade värden visas; den inkluderar inte eller exkluderar inte dold källdata. Se [Kontrollera visning av tomma celler](/slides/sv/python-net/chart-series/#control-the-display-of-empty-cells) för ett exempel.

## **Hämta diagrammets dataområde**

Innan du uppdaterar arbetsboksdata i en befintlig presentation, inspektera källintervallen för att identifiera vilka kalkylarks-celler varje diagram använder. Metoden [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) returnerar det aktuella dataintervallet som en kalkylarks‑kvalificerad formel, t.ex. `Sheet1!$A$1:$D$5`. Här är `Sheet1` kalkylarksnamnet, `!` separerar det från cellintervallet, och `$A$1:$D$5` identifierar cellerna A1 till D5, inklusive. Dollartecknen indikerar absoluta rad‑ och kolumnreferenser.

Metoden läser det aktuella intervallet utan att ändra diagrammet eller dess arbetsbok. Om diagrammet inte använder en arbetsbok som datakälla, kastas ett undantag. För mer information, se [ChartData API‑referens](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/).

Detta exempel öppnar en presentation och kontrollerar formerna direkt på varje bild för diagram. Det skriver ut varje diagram namn och källintervall. Om intervallet inte kan hämtas, skriver det ut ett diagnostiskt meddelande och fortsätter till nästa diagram.

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

## **Läsa och skriva diagramdata från en arbetsbok**

Aspose.Slides för Python via .NET tillhandahåller metoderna [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) och [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) som låter dig läsa och skriva diagramarbetsböcker (innehållande diagramdata redigerade med Aspose.Cells). **Obs!** att diagramdata måste vara organiserad på samma sätt eller ha en struktur liknande källan.

Detta exempel använder en presentation med ett diagram som den första formen på den första bilden. Det läser in den inbäddade arbetsboken till en ström, rensar befintliga serier och kategorier, och skriver tillbaka samma arbetsbok. Ändringarna kvarstår i minnet; exemplet sparar inte presentationen.

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

### **Validera diagramlayout efter arbetsboksmodifikation**

När du ersätter en inbäddad arbetsbok med en modifierad, behåller diagrammet sina ursprungliga serie‑ och kategorisamlingar. Detta missmatch kan få [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) att misslyckas med ett index‑out‑of‑range‑fel. Rensa befintliga serier och kategorier innan du skriver tillbaka den uppdaterade arbetsboken till diagrammet. Detta exempel använder ett diagram som är den första formen på den första bilden. Kommentarerna markerar var arbetsboksredigering skulle ske; det körbara exemplet skriver tillbaka den ursprungliga arbetsboken och validerar layouten i minnet.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # Ändra arbetsboksströmmen här, till exempel med Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

Att rensa samlingarna tar bort föråldrade datreferenser innan arbetsboken skrivs tillbaka. Återskapa eventuella nödvändiga serie‑ och kategorimappningar för den uppdaterade arbetsboken innan du använder diagrammet.

## **Ange anpassade talformat för arbetsboksceller**

Använd [ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) för att styra hur numeriska värden visas i diagrammets inbäddade arbetsbok. Till exempel kan en rapport behöva en konverteringsgrad visas som procent med fyra decimaler och en koefficient med fem decimaler. Behåll båda värdena numeriska så de förblir tillgängliga för beräkningar och diagramplotting.

Ett talformat ändrar bara visningen, inte det lagrade värdet. Formatet `0.0000%` visar `0.125` som `12.5000%`; det ersätter inte det lagrade talet med `12.5`. På samma sätt visar `0.00000` `0.1234567` som `0.12346` utan att avrunda det lagrade värdet. Om det anpassade formatet är en tom sträng (`""`), används [preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) istället.

Följande exempel skapar ett stapeldiagram och får åtkomst till dess celler via [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/). På kalkylark 0 innehåller B2 konverteringsgraden och C2 koefficienten. Båda cellerna levererar diagramvärden. Exemplet aktiverar också värdemärkningar länkade till källformaten.

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

Arbetsbokscellformat är separata från format som sätts direkt på diagramaxlar eller datamärkningar. I detta exempel visar varje märkning sitt källcellsvärde eftersom [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) är aktiverat, och följer källans talformat eftersom [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) är `True`. Efter att presentationen sparats och öppnats igen visar märkningarna `12.5000%` och `0.12346`, som visas nedan. Den vertikala axeln använder sitt eget [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) `0.00`, med [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) satt till `False`.

För att formatera en datamärkning självständigt, sätt dess käll‑länk‑flagga till `False` och tilldela dess [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/). Detta ändrar inte arbetsbokscellens format. Till exempel visar ett oberoende märkningformat `0.00` det första värdet som `0.13`, medan B2 fortfarande visar `12.5000%`. Se [Diagramdatamärkningar](/slides/sv/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels) för direkt märkningformatering.

Bilden nedan renderades från den sparade presentationen efter att den öppnats igen:

![Stapeldiagram med käll‑länkade märkningar som visar 12.5000% och 0.12346 samt en oberoende formaterad numerisk axel.](custom-cell-formats.png)

## **Ange en arbetsbokscell som diagramdatamärkning**

Du kan använda text från arbetsboksceller som diagramdatamärkningar.

Detta exempel lägger till ett bubbeldiagram med standarddata på den första bilden i en befintlig presentation. Det använder cellerna A10:A12 på kalkylark 0 för de första tre märkningsvärdena i den första serien, aktiverar märkningar från celler, och sparar den uppdaterade presentationen.

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

## **Hantera kalkylark**

Egenskapen [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) ger åtkomst till kalkylarken i en diagramarbetsbok. Detta exempel skapar ett cirkeldiagram med standarddata och skriver ut varje kalkylarks namn till konsolen.

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

## **Ange datakälltyp**

Detta exempel skapar ett 3D‑stapeldiagram med standarddata och sätter två serienamn med olika datakällor. Det första namnet använder en strängliteral; det andra använder cell C1 på kalkylark 0. Uppräkningen [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) väljer källan för varje namn. Exemplet sparar presentationen med de uppdaterade serienamnen.

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

## **Upptäcka icke‑stödda inbäddade arbetsboksformat**

Aspose.Slides stödjer inte Excel‑binärarbetsboksformatet (.xlsb) som kan vara inbäddat i vissa diagram. Du kan använda egenskapen [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) på [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) tillsammans med uppräkningen [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) för att upptäcka icke‑stödda format och hoppa över de diagrammen. Detta exempel inspekterar formerna på den första bilden i en befintlig presentation, hoppar över icke‑diagramformer, och skriver ut ett diagnostiskt meddelande för varje diagram med en inbäddad .xlsb‑arbetsbok.

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

        # Läs eller ändra stödd diagramarbetsboksdata här.
```

## **Extern arbetsbok**

Aspose.Slides stödjer att använda externa arbetsböcker som datakälla för diagram.

### **Skapa en extern arbetsbok**

Använd [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) och [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) för att exportera en inbäddad diagramarbetsbok till en fil och länka diagrammet till den externa arbetsboken.

Detta exempel skapar ett cirkeldiagram med standarddata och exporterar dess arbetsbok. Det stänger utdata‑strömmen innan den externa arbetsboken tilldelas som diagrammets datakälla, och sparar sedan den länkade presentationen.

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

### **Tilldela en extern arbetsbok**

Genom att använda metoden [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) kan du tilldela en extern arbetsbok till ett diagram som dess datakälla. Metoden kan också användas för att uppdatera en sökväg till den externa arbetsboken (om den senare har flyttats).

Även om du inte kan redigera data i arbetsböcker som lagras på fjärrplatser eller resurser, kan du fortfarande använda sådana arbetsböcker som en extern datakälla. Om en relativ sökväg för en extern arbetsbok anges, konverteras den automatiskt till en fullständig sökväg.

Detta exempel använder en extern arbetsbok där kalkylarket `Sheet1` innehåller ett serienamn i B1, kategorinamn i A2:A4 och numeriska värden i B2:B4. Exemplet skapar ett cirkeldiagram, länkar arbetsboken, och använder [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) för att mappa A1:B4 till en serie och tre kategorier. Det sparar presentationen med det länkade diagrammet.

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

Parametern `update_chart_data` för [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) styr om arbetsboken laddas.

* När `update_chart_data` är `False` uppdateras endast arbetsbokens sökväg. Diagramdata laddas eller uppdateras inte från målarbetsboken, så arbetsboken kan vara otillgänglig.
* När `update_chart_data` är `True` uppdateras diagramdata från målarbetsboken.

Följande exempel tilldelar en platshållar‑URL med `update_chart_data` satt till `False`. Det behåller cirkeldiagrammets standarddata och sparar presentationen utan att ladda den otillgängliga arbetsboken.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Hämta den externa datakällans arbetsboksökväg för ett diagram**

För att identifiera arbetsboken som är länkad till ett diagram, kontrollera om diagrammet använder en extern datakälla och hämta dess arbetsboksökväg.

Detta exempel inspekterar den första formen på den första bilden i en presentation med en länkad extern arbetsbok. Om det är ett diagram länkat till en extern arbetsbok, skriver exemplet ut [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) till konsolen. Det sparar sedan en kopia av presentationen.

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

### **Redigera diagramdata**

Du kan redigera data i externa arbetsböcker på samma sätt som du ändrar innehållet i interna arbetsböcker. När en extern arbetsbok inte kan laddas kastas ett undantag.

Detta exempel använder ett diagram som är den första formen på den första bilden och är länkat till en tillgänglig extern arbetsbok. Det sätter det cell‑stödda värdet för den första datapunkten i den första serien till 100 och sparar den uppdaterade presentationen. Att redigera cellvärden kan uppdatera den länkade externa XLSX‑filen, så använd en kopia om du måste bevara original‑arbetsboken.

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

### **Återskapa en arbetsbok från diagram‑cachen**

Om ett diagram använder en extern arbetsbok som saknas eller är otillgänglig, kan Aspose.Slides rekonstruera diagramarbetsboken från den cachelagrade datan i presentationen. Skapa [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/), konfigurera dess [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/), och sätt [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) till `True` innan du öppnar presentationen.

Följande Python‑exempel återställer arbetsboksdata för ett diagram som är den första formen på den första bilden och refererar en otillgänglig extern arbetsbok. Det får åtkomst till den återställda datan via [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) och [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

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

        # Läs eller ändra den återställda arbetsboksdata här.
    else:
        print("The first shape is not a chart.")
```

Om den externa arbetsboken är otillgänglig och återställning är inaktiverad, kastar Aspose.Slides ett undantag. Aktivera återställning endast när användning av cachelagrad diagramdata är ett acceptabelt alternativ, eftersom cachen kanske inte innehåller ändringar som gjorts i den externa arbetsboken efter att presentationen senast uppdaterades.

## **FAQ**

**Kan jag avgöra om ett specifikt diagram är länkat till en extern eller en inbäddad arbetsbok?**

Ja. Ett diagram har en [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) och en [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/); om källan är en extern arbetsbok kan du läsa den fullständiga sökvägen för att säkerställa att en extern fil används.

**Stöds relativa sökvägar till externa arbetsböcker, och hur lagras de?**

Ja. Om du anger en relativ sökväg konverteras den automatiskt till en absolut sökväg. Presentationen lagrar den absoluta sökvägen i PPTX‑filen, så att flytta arbetsboken kan kräva en uppdatering av länken.

**Kan jag använda arbetsböcker som ligger på nätverksresurser/delade mappar?**

Ja, sådana arbetsböcker kan användas som en extern datakälla. Att redigera fjärrarbetsböcker direkt från Aspose.Slides stöds dock inte — de kan endast användas som källa.

**Skriver Aspose.Slides över den externa XLSX‑filen när presentationen sparas?**

Presentationen lagrar en [link to the external file](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Att redigera cell‑stödd diagramdata kan också uppdatera den länkade lokala XLSX‑filen. Använd en kopia av arbetsboken om originalet måste förbli oförändrat.

**Vad gör jag om den externa filen är lösenordsskyddad?**

Aspose.Slides accepterar inte ett lösenord vid länkning. En vanlig lösning är att ta bort skyddet i förväg eller förbereda en avkrypterad kopia (t.ex. med [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) och länka till den kopian.

**Kan flera diagram referera till samma externa arbetsbok?**

Ja. Varje diagram lagrar sin egen länk. Om de alla pekar på samma fil, kommer en uppdatering av den filen att återspeglas i varje diagram nästa gång data laddas.