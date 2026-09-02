---
title: Hantera diagramarböcker i presentationer med Python
linktitle: Diagramarbok
type: docs
weight: 70
url: /sv/python-net/chart-workbook/
keywords:
- diagramarbok
- diagramdata
- arbetsbokscell
- datamärke
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
description: "Upptäck Aspose.Slides för Python via .NET: hantera enkelt diagramarböcker i PowerPoint- och OpenDocument-format för att effektivisera dina presentationsdata."
---
## **Översikt**

Den här artikeln förklarar hur du arbetar med diagramarbetsböcker i Aspose.Slides. Den visar hur du läser och skriver diagramdata via arbetsbokströmmar, använder arbetsboks‑celler som diagramdatamärken, får åtkomst till arbetsbladssamlingar och anger datakälltyp för diagramvärden.

Den täcker också hur du arbetar med externa arbetsböcker som diagramdatakällor. Exemplen demonstrerar hur du skapar och tilldelar en extern arbetsbok, hämtar sökvägen för en extern arbetsbok som är länkad till ett diagram och redigerar diagramdata när arbetsboken är tillgänglig.

## **Läsa och skriva diagramdata från en arbetsbok**

Aspose.Slides tillhandahåller metoder för att läsa och skriva diagramdataarbetsböcker (som innehåller diagramdata redigerade med Aspose.Cells). **Obs:** Diagramdata måste vara organiserade på samma sätt eller ha en struktur som liknar källan.

Följande Python‑kod demonstrerar ett exempel:

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

## **Ange en arbetsboks­cell som ett diagramdatamärke**

I vissa fall behöver du diagrammärken som hämtas direkt från celler i den underliggande dataarboken. Aspose.Slides låter dig binda datamärken till specifika arbetsboks­celler så att märkestexten alltid återspeglar cellens värde. Exemplet nedan visar hur du aktiverar värde‑från‑cell‑märkningar och pekar utvalda märken till anpassade celler i diagrammets arbetsbok.

1. Skapa en instans av klassen [Presentation](https://docs.aspose.com/slides/sv/python-net/api-reference/aspose.slides/presentation/).
1. Hämta en referens till bilden genom index.
1. Lägg till ett bubbeldiagram med exempeldata.
1. Kom åt diagramserierna.
1. Använd en arbetsboks­cell som ett datamärke.
1. Spara presentationen.

Följande Python‑kod visar hur du anger en arbetsboks­cell som ett diagramdatamärke:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Instansiera Presentation-klassen som representerar en presentationsfil.
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

## **Hantera arbetsblad**

Följande Python‑kod demonstrerar hur du använder egenskapen `worksheets` för att komma åt arbetsblads­samlingen:

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

## **Ange datakälltyp**

Följande Python‑kod visar hur du anger en datakälltyp:

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

## **Detektera ej stödda inbäddade arbetsboksformat**

Aspose.Slides stöder inte Excel‑binärarboken (.xlsb) som kan vara inbäddad i vissa diagram. Du kan använda egenskapen `embedded_workbook_type` på [ChartData](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdata/) tillsammans med uppräkningen [WorkbookType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/workbooktype/) för att detektera ej stödda format och hoppa över dessa diagram.

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
            # Inbäddad arbetsbok är i .xlsb-format, vilket inte stöds.
            continue

        # Läs eller ändra diagramarbokens data här.
```

## **Externa arbetsböcker**

Aspose.Slides stöder användning av externa arbetsböcker som datakälla för diagram.

### **Ange externa arbetsböcker**

Genom att använda metoden [ChartData.set_external_workbook](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdata/set_external_workbook/) kan du tilldela en extern arbetsbok till ett diagram som dess datakälla. Denna metod kan också uppdatera sökvägen till en extern arbetsbok om den har flyttats.

Även om du inte kan redigera data i arbetsböcker som lagras på fjärrplatser eller resurser, kan du fortfarande använda dessa arbetsböcker som externa datakällor. Om du anger en relativ sökväg för en extern arbetsbok konverteras den automatiskt till en fullständig sökväg.

Följande Python‑kod visar hur du anger en extern arbetsbok:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

Parametern `update_chart_data` för metoden [set_external_workbook](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdata/set_external_workbook/) anger om Excel‑arboken ska laddas.

- När `update_chart_data` är `False` uppdateras endast arbetsbokens sökväg; diagramdata laddas inte eller uppdateras från målarboken. Använd denna inställning när målarboken saknas eller är otillgänglig.
- När `update_chart_data` är `True` laddas diagramdata och uppdateras från målarboken.

### **Skapa externa arbetsböcker**

Genom att använda metoderna [read_workbook_stream](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) och [set_external_workbook](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdata/set_external_workbook/) kan du antingen skapa en extern arbetsbok från början eller konvertera en intern arbetsbok till en extern.

Denna Python‑kod demonstrerar processen för att skapa en extern arbetsbok:

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

### **Hämta sökvägen till den externa datakällans arbetsbok för ett diagram**

Ibland är ett diagrams data länkat till en extern Excel‑arbok snarare än till presentationens inbäddade data. Med Aspose.Slides kan du inspektera diagrammets datakälla och, om den är en extern arbetsbok, läsa den fullständiga arbetsboks­sökvägen.

1. Skapa en instans av klassen [Presentation](https://docs.aspose.com/slides/sv/python-net/api-reference/aspose.slides/presentation/).
1. Hämta en referens till bilden via dess index.
1. Hämta en referens till diagramformen.
1. Skaffa källan ([ChartDataSourceType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdatasourcetype/)) som representerar diagrammets datakälla.
1. Kontrollera om källtypen matchar den externa arbetsboks­datakälltypen.

Följande Python‑kod demonstrerar operationen:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart_with_external_workbook.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    source_type = chart.chart_data.data_source_type
    if source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **Redigera diagramdata**

Du kan redigera data i externa arbetsböcker på samma sätt som du redigerar data i interna arbetsböcker. Om en extern arbetsbok inte kan laddas kastas ett undantag.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Återställ en arbetsbok från diagram‑cachen**

Om ett diagram använder en extern arbetsbok som saknas eller är otillgänglig kan Aspose.Slides rekonstruera diagramarboken från den data som cachats i presentationen. Skapa [LoadOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadoptions/), aktivera sedan [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/sv/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) via [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadoptions/spreadsheet_options/) innan du öppnar presentationen.

Följande Python‑exempel öppnar en presentation vars diagram refererar till en otillgänglig extern arbetsbok och får åtkomst till de återställda data via [Chart.chart_data](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chart/chart_data/) och [ChartData.chart_data_workbook](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Läs eller ändra den återställda arbetsbokens data här.
```

Om den externa arbetsboken är otillgänglig och återställning är inaktiverad kastar Aspose.Slides ett undantag. Aktivera återställning endast när användning av cachad diagramdata är ett acceptabelt alternativ, eftersom cachen kanske inte innehåller ändringar som gjorts i den externa arbetsboken efter att presentationen senast uppdaterades.

## **FAQ**

**Kan jag avgöra om ett specifikt diagram är länkat till en extern eller en inbäddad arbetsbok?**

Ja. Ett diagram har en [data source type](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdata/data_source_type/) och en [path to an external workbook](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdata/external_workbook_path/); om källan är en extern arbetsbok kan du läsa den fullständiga sökvägen för att säkerställa att en extern fil används.

**Stöds relativa sökvägar till externa arbetsböcker, och hur lagras de?**

Ja. Om du anger en relativ sökväg konverteras den automatiskt till en absolut sökväg. Detta är bekvämt för projektportabilitet; dock bör du vara medveten om att presentationen lagrar den absoluta sökvägen i PPTX‑filen.

**Kan jag använda arbetsböcker som ligger på nätverksresurser/delade mappar?**

Ja, sådana arbetsböcker kan användas som en extern datakälla. Att redigera fjärrarbetsböcker direkt från Aspose.Slides stöds dock inte – de kan endast användas som källa.

**Skriver Aspose.Slides över den externa XLSX‑filen när presentationen sparas?**

Nej. Presentationen lagrar en [link to the external file](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdata/external_workbook_path/) och använder den för att läsa data. Den externa filen själv modifieras inte när presentationen sparas.

**Vad gör jag om den externa filen är lösenordsskyddad?**

Aspose.Slides accepterar inte ett lösenord vid länkning. En vanlig strategi är att ta bort skyddet i förväg eller förbereda en avkrypterad kopia (t.ex. med [Aspose.Cells](/cells/python-net/)) och länka till den kopian.

**Kan flera diagram referera till samma externa arbetsbok?**

Ja. Varje diagram lagrar sin egen länk. Om de alla pekar på samma fil kommer en uppdatering av den filen att återspeglas i varje diagram nästa gång data laddas.