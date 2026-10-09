---
title: Hantera diagramarbok i presentationer med Python
linktitle: Diagramarbok
type: docs
weight: 70
url: /sv/python-net/chart-workbook/
keywords:
- diagramarbok
- diagramdata
- arbetsbokscell
- datamärkning
- arbetsblad
- datakälla
- extern arbetsbok
- extern data
- diagramcache
- arbetsboksåterställning
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Upptäck Aspose.Slides för Python via .NET: hantera enkelt diagramarböcker i PowerPoint- och OpenDocument-format för att förenkla dina presentationsdata."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med diagramarbetsböcker i Aspose.Slides. Den visar hur man läser och skriver diagramdata via arbetsbokströmmar, använder arbetsboksceller som diagramdatamärkningar, får åtkomst till arbetsbladsamlingar och anger datakälltypen för diagramvärden.

Den behandlar också hur man arbetar med externa arbetsböcker som diagramdatakällor. Exemplen demonstrerar hur man skapar och tilldelar en extern arbetsbok, hämtar sökvägen till en extern arbetsbok som är länkat till ett diagram och redigerar diagramdata när arbetsboken är tillgänglig.

För arbetsboksceller som representerar saknad data, se [Styr visning av tomma celler](/slides/sv/python-net/chart-series/) för skillnaden mellan en tom cell och noll samt en linjediagramjämförelse av de tillgängliga visningslägena.

## **Inkludera data från dolda rader och kolumner**

Använd [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) för att kontrollera om ett diagram ritar data från dolda arbetsbladsrader och -kolumner. Sätt den till `True` för att rita endast synliga celler, eller `False` för att inkludera både synliga och dolda celler. Denna inställning styr diagramritning; den döljer eller visar inte arbetsbladsrader eller -kolumner.

[exempelpresentation](hidden-source-data.pptx) innehåller ett stapeldiagram som den första formen på den första bilden. Det inbäddade arbetsbladet, `Sheet1`, innehåller följande källintervall, `A1:C4`. Rad 3 och kolumn C är dolda, men deras celler innehåller fortfarande värden.

| Arbetsbladsrad | A: Månad | B: Detaljhandel | C: Partihandel (dolt kolumn) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (dolt rad) | February | 40 | 60 |
| 4 | March | 20 | 50 |

Få åtkomst till källceller via [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) och läs [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) för att inspektera deras dolda status. Denna egenskap är skrivskyddad. I detta exempel är B2 synlig, B3 tillhör den dolda raden och C2 tillhör den dolda kolumnen; exemplet skriver ut `False`, `True` och `True` respektive.

För detta exempel, uppdatera diagramdata efter att plottinginställningen ändrats: behåll den inbäddade arbetsboken med [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) och läs in den igen med [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). När alla celler inkluderas, använd även [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) för att återställa hela intervallet, inklusive den dolda februari‑kategorin. Att bara ändra flaggan är otillräckligt för att uppdatera detta exempels cachade diagramdata och kategorimärkningar.

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

Exemplet sparar två versioner av presentationen: en med endast de synliga Detaljhandelsvärdena (10 och 20), och en annan med alla sex värden. Bilderna nedan renderades från de sparade presentationerna efter att de öppnats igen; båda filerna behåller sin tilldelade plottinginställning. Rad 3 och kolumn C förblir dolda i båda inbäddade arbetsböckerna.

| Endast synliga celler (`True`) | Alla celler (`False`) |
| --- | --- |
| ![Endast synliga celler: Detaljhandelsvärden 10 och 20 för januari och mars.](hidden_cells_True.png) | ![Alla celler: Detaljhandels- och partihandelsvärden för januari, februari och mars.](hidden_cells_False.png) |

En dold cell som innehåller ett värde skiljer sig från en tom cell. [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) styr hur saknade värden visas; den inkluderar eller exkluderar inte dold källdata. Se [Styr visning av tomma celler](/slides/sv/python-net/chart-series/#control-the-display-of-empty-cells) för ett exempel.

## **Hämta ett diagrams dataområde**

Innan du uppdaterar arbetsboksdata i en befintlig presentation, inspektera källintervall för att identifiera vilka arbetsbladceller varje diagram använder. Metoden [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) returnerar det aktuella dataområdet som en arbetsblads‑kvalificerad formel, exempelvis `Sheet1!$A$1:$D$5`. Här är `Sheet1` arbetsbladsnamnet, `!` separerar det från cellintervallet, och `$A$1:$D$5` identifierar cellerna A1 till D5, inklusivt. Dollartecknen indikerar absoluta rad‑ och kolumnreferenser.

Metoden läser det aktuella intervallet utan att ändra diagrammet eller dess arbetsbok. Om diagrammet inte använder en arbetsbok som datakälla, kastas ett undantag. För mer information, se [ChartData API‑referens](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/).

Detta exempel öppnar en presentation och kontrollerar formerna direkt på varje bild för diagram. Det skriver ut varje diagrams namn och källintervall. Om intervallet inte kan hämtas, skrivs ett diagnostiskt meddelande och programmet fortsätter till nästa diagram.

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

Aspose.Slides for Python via .NET tillhandahåller metoderna [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) och [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) som låter dig läsa och skriva diagramdataböcker (innehållande diagramdata redigerade med Aspose.Cells). **Observera** att diagramdata måste vara organiserade på samma sätt eller ha en struktur som liknar källan.

Detta exempel använder en presentation med ett diagram som den första formen på den första bilden. Det läser den inbäddade arbetsboken till en ström, rensar befintliga serier och kategorier och skriver tillbaka samma arbetsbok. Ändringarna finns kvar i minnet; exemplet sparar inte presentationen.

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

### **Validera diagramlayout efter arbetsboksmodifiering**

När du ersätter en inbäddad arbetsbok med en modifierad, behåller diagrammet sina ursprungliga serie‑ och kategorisamlingar. Denna mismatch kan göra så att [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) misslyckas med ett index‑out‑of‑range‑fel. Rensa befintliga serier och kategorier innan den uppdaterade arbetsboken skrivs tillbaka till diagrammet. Detta exempel använder ett diagram som är den första formen på den första bilden. Kommentarerna markerar var arbetsboksredigering skulle ske; det körbara exemplet skriver tillbaka den ursprungliga arbetsboken och validerar layouten i minnet.

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

Rensning av samlingarna tar bort föråldrade datareferenser innan arbetsboken skrivs tillbaka. Bygg om eventuella nödvändiga serie‑ och kategorikartor för den uppdaterade arbetsboken innan diagrammet används.

## **Ange en arbetsbokscell som diagramdatamärkning**

Du kan använda text från arbetsboks­celler som diagramdatamärkningar.

Detta exempel lägger till ett bubbeldiagram med standarddata på den första bilden i en befintlig presentation. Det använder cellerna A10:A12 på arbetsblad 0 för de första tre märkena i den första serien, aktiverar märkningar från celler och sparar den uppdaterade presentationen.

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

## **Hantera arbetsblad**

Egenskapen [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) ger åtkomst till arbetsbladen i en diagramarbetsbok. Detta exempel skapar ett cirkeldiagram med standarddata och skriver ut varje arbetsblads namn till konsolen.

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

Detta exempel skapar ett 3D‑stapeldiagram med standarddata och sätter två serienamn med olika datakällor. Det första namnet använder en strängliteral; det andra använder cell C1 på arbetsblad 0. Upplägget [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) väljer källan för varje namn. Exemplet sparar presentationen med de uppdaterade serienamnen.

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

## **Detektera ej stödda inbäddade arbetsboksformat**

Aspose.Slides stöder inte Excel‑binärarbetsboksformatet (.xlsb) som kan inbäddas i vissa diagram. Du kan använda egenskapen [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) på [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) tillsammans med uppräkningen [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) för att identifiera ej stödda format och hoppa över de diagrammen. Detta exempel inspekterar formerna på den första bilden i en befintlig presentation, hoppar över former som inte är diagram och skriver ut ett diagnostiskt meddelande för varje diagram med en inbäddad .xlsb‑arbetsbok.

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

        # Läs eller ändra stödd diagramarbokdata här.
```

## **Extern arbetsbok**

Aspose.Slides stöder att använda externa arbetsböcker som datakälla för diagram.

### **Skapa en extern arbetsbok**

Använd [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) och [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) för att exportera en inbäddad diagramarbetsbok till en fil och länka diagrammet till den externa arbetsboken.

Detta exempel skapar ett cirkeldiagram med standarddata och exporterar dess arbetsbok. Det stänger utströmmen innan den externa arbetsboken tilldelas som diagrammets datakälla, och sparar sedan den länkade presentationen.

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

Genom att använda metoden [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) kan du tilldela en extern arbetsbok till ett diagram som dess datakälla. Metoden kan även användas för att uppdatera sökvägen till den externa arbetsboken (om den senare har flyttats).

Även om du inte kan redigera data i arbetsböcker som lagras på fjärrplatser eller resurser, kan sådana arbetsböcker fortfarande användas som extern datakälla. Om en relativ sökväg för en extern arbetsbok anges, konverteras den automatiskt till en fullständig sökväg.

Detta exempel använder en extern arbetsbok där arbetsbladet med namn `Sheet1` innehåller ett serienamn i B1, kategorinamnen i A2:A4 och numeriska värden i B2:B4. Exemplet skapar ett cirkeldiagram, länkar arbetsboken och använder [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) för att mappa A1:B4 till en serie och tre kategorier. Det sparar presentationen med det länkade diagrammet.

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

* När `update_chart_data` är `False`, uppdateras endast arbetsbokens sökväg. Diagramdata laddas inte och uppdateras inte från mål‑arbetsboken, så arbetsboken kan vara otillgänglig.
* När `update_chart_data` är `True`, uppdateras diagramdata från mål‑arbetsboken.

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

### **Hämta den externa datakällans arbetsbokssökväg för ett diagram**

För att identifiera arbetsboken som är länkad till ett diagram, kontrollera om diagrammet använder en extern datakälla och hämta dess arbetsbokssökväg.

Detta exempel inspekterar den första formen på den första bilden i en presentation med en länkad extern arbetsbok. Om det är ett diagram som är länkat till en extern arbetsbok, skriver exemplet ut [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) till konsolen. Därefter sparas en kopia av presentationen.

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

Du kan redigera data i externa arbetsböcker på samma sätt som du gör ändringar i innehållet i interna arbetsböcker. När en extern arbetsbok inte kan laddas kastas ett undantag.

Detta exempel använder ett diagram som är den första formen på den första bilden och som är länkat till en åtkomlig extern arbetsbok. Det sätter det cell‑stödda värdet för den första datapunkten i den första serien till 100 och sparar den uppdaterade presentationen. Redigering av cellvärden kan uppdatera den länkade externa XLSX‑filen, så använd en kopia om du måste bevara den ursprungliga arbetsboken.

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

### **Återskapa en arbetsbok från diagramcachen**

Om ett diagram använder en extern arbetsbok som saknas eller är otillgänglig, kan Aspose.Slides rekonstruera diagramarboken från de data som cachas i presentationen. Skapa [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/), konfigurera dess [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/), och sätt [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) till `True` innan presentationen öppnas.

Följande Python‑exempel återställer arbetsboksdata för ett diagram som är den första formen på den första bilden och refererar en otillgänglig extern arbetsbok. Det får åtkomst till de återställda data via [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) och [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

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

Om den externa arbetsboken är otillgänglig och återställning är inaktiverad, kastar Aspose.Slides ett undantag. Aktivera återställning endast när användning av cachad diagramdata är ett acceptabelt alternativ, eftersom cachen kanske inte innehåller ändringar som gjorts i den externa arbetsboken efter att presentationen senast uppdaterades.

## **FAQ**

**Kan jag avgöra om ett specifikt diagram är länkat till en extern eller en inbäddad arbetsbok?**

Ja. Ett diagram har en [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) och en [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/); om källan är en extern arbetsbok kan du läsa hela sökvägen för att säkerställa att en extern fil används.

**Stöds relativa sökvägar till externa arbetsböcker, och hur lagras de?**

Ja. Om du anger en relativ sökväg konverteras den automatiskt till en absolut sökväg. Presentationen lagrar den absoluta sökvägen i PPTX‑filen, så att flytta arbetsboken kan kräva en uppdatering av länken.

**Kan jag använda arbetsböcker som ligger på nätverksresurser/delade mappar?**

Ja, sådana arbetsböcker kan användas som extern datakälla. Däremot stöds inte direkt redigering av fjärrarbetsböcker från Aspose.Slides – de kan endast användas som källa.

**Skriver Aspose.Slides över den externa XLSX‑filen när presentationen sparas?**

Presentationen lagrar en [link to the external file](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Redigering av cell‑stödd diagramdata kan även uppdatera den länkade lokala XLSX‑filen. Använd en kopia av arbetsboken om originalet måste förbli oförändrat.

**Vad gör jag om den externa filen är lösenordsskyddad?**

Aspose.Slides accepterar inte ett lösenord vid länkning. En vanlig metod är att i förväg ta bort skyddet eller förbereda en avkrypterad kopia (t.ex. med [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) och länka till den kopian.

**Kan flera diagram referera till samma externa arbetsbok?**

Ja. Varje diagram lagrar sin egen länk. Om de alla pekar på samma fil kommer en uppdatering av den filen att återspeglas i varje diagram nästa gång data laddas.