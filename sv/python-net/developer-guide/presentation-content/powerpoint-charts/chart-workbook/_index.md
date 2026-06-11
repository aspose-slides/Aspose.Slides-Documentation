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
- datamärkning
- kalkylblad
- datakälla
- extern arbetsbok
- extern data
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Upptäck Aspose.Slides för Python via .NET: hantera enkelt diagramarböcker i PowerPoint- och OpenDocument-format för att effektivisera dina presentationsdata."
---
## **Översikt**

Denna artikel förklarar hur man arbetar med diagramarbetsböcker i Aspose.Slides. Den visar hur man läser och skriver diagramdata via arbetsbokströmmar, använder arbetsboksceller som diagramdatamärkningar, får åtkomst till kalkylbladsamlingar och anger datakältyp för diagramvärden. Den täcker också hur man arbetar med externa arbetsböcker som diagramdatakällor. Exempelen demonstrerar hur man skapar och tilldelar en extern arbetsbok, hämtar sökvägen till en extern arbetsbok som är länkad till ett diagram, och redigerar diagramdata när arbetsboken är tillgänglig.

## **Läsa och skriva diagramdata från en arbetsbok**

Aspose.Slides tillhandahåller metoder för att läsa och skriva diagramdataarbetsböcker (som innehåller diagramdata redigerade med Aspose.Cells). **Obs:** Diagramdata måste vara organiserade på samma sätt eller ha en struktur som liknar källan.

Följande Python‑kod demonstrerar ett exempel på en operation:

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

## **Ange en arbetsbokscell som diagramdatamärkning**

Ibland behövs diagrametiketter som hämtas direkt från celler i den underliggande datarboken. Aspose.Slides låter dig binda datamärkningar till specifika arbetsboksceller så att etiketttexten alltid återspeglar cellens värde. Exemplet nedan visar hur man aktiverar etiketter med värde från cell och pekar utvalda etiketter till anpassade celler i diagrammets arbetsbok.

1. Skapa en instans av klassen [Presentation](https://docs.aspose.com/slides/sv/python-net/api-reference/aspose.slides/presentation/).
1. Hämta en referens till bilden med index.
1. Lägg till ett bubbeldiagram med exempeldata.
1. Få åtkomst till diagramserierna.
1. Använd en arbetsbokscell som datamärkning.
1. Spara presentationen.

Följande Python‑kod visar hur man anger en arbetsbokscell som diagramdatamärkning:

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

## **Hantera kalkylblad**

Följande Python‑kod demonstrerar hur man använder egenskapen `worksheets` för att komma åt kalkylbladsamlingen:

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

## **Ange datakältyp**

Följande Python‑kod visar hur man specificerar en datakältyp:

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

## **Upptäcka ej stödda inbäddade arbetsboksformat**

Aspose.Slides stöder inte Excel‑binärarbetsboksformatet (.xlsb) som kan bäddas in i vissa diagram. Du kan använda egenskapen `embedded_workbook_type` på [ChartData](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdata/) tillsammans med uppräkningen [WorkbookType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/workbooktype/) för att upptäcka ej stödda format och hoppa över dessa diagram.

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

Aspose.Slides stödjer att använda externa arbetsböcker som datakälla för diagram.

### **Ange externa arbetsböcker**

Genom att använda metoden [ChartData.set_external_workbook](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdata/set_external_workbook/) kan du tilldela en extern arbetsbok till ett diagram som dess datakälla. Denna metod kan också uppdatera sökvägen till en extern arbetsbok om den har flyttats.

Även om du inte kan redigera data i arbetsböcker som lagras på fjärrplatser eller resurser, kan du fortfarande använda dessa arbetsböcker som externa datakällor. Om du anger en relativ sökväg för en extern arbetsbok konverteras den automatiskt till en fullständig sökväg.

Följande Python‑kod visar hur man anger en extern arbetsbok:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

Parametern `update_chart_data` för metoden [set_external_workbook](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdata/set_external_workbook/) anger om Excel‑arbetsboken ska laddas.

- När `update_chart_data` är satt till `False` uppdateras endast arbetsbokens sökväg; diagramdata laddas inte eller uppdateras från målarbetsboken. Använd denna inställning när målarbetsboken inte finns eller är otillgänglig.
- När `update_chart_data` är satt till `True` laddas diagramdata och uppdateras från målarbetsboken.

### **Skapa externa arbetsböcker**

Genom att använda metoderna [read_workbook_stream](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) och [set_external_workbook](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdata/set_external_workbook/) kan du antingen skapa en extern arbetsbok från grunden eller konvertera en intern arbetsbok till en extern.

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

Ibland är ett diagramdata länkat till en extern Excel‑arbetsbok istället för presentationens inbäddade data. Med Aspose.Slides kan du undersöka diagrammets datakälla och, om det är en extern arbetsbok, läsa den fullständiga arbetsboksökvägen.

1. Skapa en instans av klassen [Presentation](https://docs.aspose.com/slides/sv/python-net/api-reference/aspose.slides/presentation/).
1. Hämta en referens till bilden med dess index.
1. Hämta en referens till diagramformen.
1. Hämta källan ([ChartDataSourceType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdatasourcetype/)) som representerar diagrammets datakälla.
1. Kontrollera om källtypen matchar den externa arbetsbokens datakält typ.

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

## **FAQ**

**Kan jag avgöra om ett specifikt diagram är länkat till en extern eller inbäddad arbetsbok?**

Ja. Ett diagram har en [datakältyp](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdata/data_source_type/) och en [sökväg till en extern arbetsbok](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdata/external_workbook_path/); om källan är en extern arbetsbok kan du läsa den fullständiga sökvägen för att säkerställa att en extern fil används.

**Stöds relativa sökvägar till externa arbetsböcker, och hur lagras de?**

Ja. Om du anger en relativ sökväg konverteras den automatiskt till en absolut sökväg. Detta är praktiskt för projektportabilitet; dock bör du vara medveten om att presentationen kommer att lagra den absoluta sökvägen i PPTX‑filen.

**Kan jag använda arbetsböcker som finns på nätverksresurser/delade mappar?**

Ja, sådana arbetsböcker kan användas som en extern datakälla. Redigering av fjärrarbetsböcker direkt från Aspose.Slides stöds dock inte—de kan endast användas som källa.

**Skriver Aspose.Slides över den externa XLSX‑filen när presentationen sparas?**

Nej. Presentationen lagrar en [länk till den externa filen](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdata/external_workbook_path/) och använder den för att läsa data. Den externa filen ändras inte när presentationen sparas.

**Vad ska jag göra om den externa filen är lösenordsskyddad?**

Aspose.Slides accepterar inte ett lösenord vid länken. Ett vanligt tillvägagångssätt är att ta bort skyddet i förväg eller förbereda en avkrypterad kopia (t.ex. med [Aspose.Cells](/cells/python-net/)) och länka till den kopian.

**Kan flera diagram referera till samma externa arbetsbok?**

Ja. Varje diagram lagrar sin egen länk. Om de alla pekar på samma fil kommer en uppdatering av filen att återspeglas i varje diagram nästa gång data laddas.