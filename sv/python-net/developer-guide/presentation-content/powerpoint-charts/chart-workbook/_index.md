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

Den här artikeln förklarar hur man arbetar med diagramarbetsböcker i Aspose.Slides. Den visar hur man läser och skriver diagramdata via arbetsboksströmmar, använder arbetsboks‑celler som diagramdatamärkningar, får åtkomst till arbetsbladssamlingar och anger datakälltyp för diagramvärden.

Den behandlar också hur man arbetar med externa arbetsböcker som diagramdatakällor. Exemplen visar hur man skapar och tilldelar en extern arbetsbok, hämtar sökvägen till en extern arbetsbok som är länkad till ett diagram och redigerar diagramdata när arbetsboken är tillgänglig.

För arbetsboks‑celler som representerar saknad data, se [Styr visning av tomma celler](/slides/sv/python-net/chart-series/) för skillnaden mellan en tom cell och noll, samt en linjediagramjämförelse av de tillgängliga visningslägena.

## **Läs och skriv diagramdata från en arbetsbok**

Aspose.Slides tillhandahåller metoder för att läsa och skriva diagramdatabehörande arbetsböcker (som innehåller diagramdata redigerad med Aspose.Cells). **Observera:** Diagramdata måste organiseras på samma sätt eller ha en struktur som liknar källan.

Följande Python‑kod visar ett exempel på en operation:

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

### **Validera diagramlayout efter arbetsboksändring**

När du ersätter en inbäddad arbetsbok med en modifierad behåller diagrammet sina ursprungliga serier och kategorisamlingar. Denna missmatch kan få [IChart.validate_chart_layout](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/ichart/validate_chart_layout/) att misslyckas med ett index‑out‑of‑range‑fel. Rensa de befintliga serierna och kategorierna innan du skriver den uppdaterade arbetsboken tillbaka till diagrammet.

```python
# Efter att ha modifierat arbetsboksströmmen (t.ex. med Aspose.Cells)
updated_workbook = chart_data.read_workbook_stream()

# Rensa befintliga datareferenser.
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

Genom att rensa samlingarna säkerställer du att diagramdatans struktur är konsekvent med den nya arbetsboken, vilket gör att `validate_chart_layout` kan slutföras utan fel.

## **Ange en arbetsboks‑cell som diagramdatamärkning**

Ibland behöver du diagrametiketter som kommer direkt från celler i den underliggande datarboken. Aspose.Slides låter dig binda datamärkningar till specifika arbetsboks‑celler så att etiketttexten alltid speglar cellens värde. Exemplet nedan visar hur du aktiverar värde‑från‑cell‑etiketter och pekar valda etiketter på anpassade celler i diagrammets arbetsbok.

1. Skapa en instans av klassen [Presentation](https://docs.aspose.com/slides/sv/python-net/api-reference/aspose.slides/presentation/).
2. Hämta en referens till bilden med index.
3. Lägg till ett bubbeldiagram med exempeldata.
4. Kom åt diagramserierna.
5. Använd en arbetsboks‑cell som datamärkning.
6. Spara presentationen.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Skapa en instans av Presentation-klassen som representerar en presentationsfil.
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

Följande Python‑kod visar hur du använder egenskapen `worksheets` för att få åtkomst till samlingen av arbetsblad:

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

## **Upptäck ej stödda inbäddade arbetsboksformat**

Aspose.Slides stödjer inte Excel‑binärarbetsboken (.xlsb) som kan vara inbäddad i vissa diagram. Du kan använda egenskapen `embedded_workbook_type` på [ChartData](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdata/) tillsammans med uppräkningen [WorkbookType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/workbooktype/) för att upptäcka ej stödda format och hoppa över dessa diagram.

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

Aspose.Slides stöder att använda externa arbetsböcker som datakälla för diagram.

### **Ställ in externa arbetsböcker**

Genom att använda metoden [ChartData.set_external_workbook](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdata/set_external_workbook/) kan du tilldela en extern arbetsbok till ett diagram som dess datakälla. Denna metod kan också uppdatera sökvägen till en extern arbetsbok om den har flyttats.

Även om du inte kan redigera data i arbetsböcker lagrade på fjärrplatser eller resurser, kan du fortfarande använda dem som externa datakällor. Om du anger en relativ sökväg för en extern arbetsbok konverteras den automatiskt till en fullständig sökväg.

Följande Python‑kod visar hur du anger en extern arbetsbok:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # Skicka False så endast sökvägen lagras: målarboken behöver inte finnas ännu.
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

Parametern `update_chart_data` för metoden [set_external_workbook](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdata/set_external_workbook/) anger huruvida Excel‑arbetsboken kommer att laddas.

- När `update_chart_data` är satt till `False` uppdateras endast arbetsbokens sökväg; diagramdata laddas inte eller uppdateras från målarboken. Använd denna inställning när målarboken inte finns eller är otillgänglig.
- När `update_chart_data` är satt till `True` (standardvärdet) laddas diagramdata och uppdateras från målarboken. Om den arbetsboken inte kan öppnas kastas ett undantag med meddelandet "External workbook is not available".

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

### **Hämta den externa datakällans arbetsboksökväg för ett diagram**

Ibland är ett diagramdatas kopplat till en extern Excel‑arbetsbok snarare än presentationens inbäddade data. Med Aspose.Slides kan du inspektera diagrammets datakälla och, om den är en extern arbetsbok, läsa den fullständiga arbetsboksökvägen.

1. Skapa en instans av klassen [Presentation](https://docs.aspose.com/slides/sv/python-net/api-reference/aspose.slides/presentation/).
2. Hämta en referens till bilden via dess index.
3. Hämta en referens till diagramformen.
4. Skaffa källan ([ChartDataSourceType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdatasourcetype/)) som representerar diagrammets datakälla.
5. Kontrollera om källtypen matchar den externa arbetsbokens datakälltyp.

Följande Python‑kod visar operationen:

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

### **Återskapa en arbetsbok från diagramcachen**

Om ett diagram använder en extern arbetsbok som saknas eller är otillgänglig kan Aspose.Slides rekonstruera diagramarboken från de data som cachats i presentationen. Skapa [LoadOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadoptions/), aktivera sedan [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/sv/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) via [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadoptions/spreadsheet_options/) innan du öppnar presentationen.

Följande Python‑exempel öppnar en presentation vars diagram refererar till en otillgänglig extern arbetsbok och åtnått de återställda data via [Chart.chart_data](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chart/chart_data/) och [ChartData.chart_data_workbook](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Läs eller ändra den återställda arbetsbokens data här.
```

Om den externa arbetsboken är otillgänglig och återställning är inaktiverad kastar Aspose.Slides ett undantag. Aktivera återställning endast när det är acceptabelt att använda de cachade diagramdata som en reserv, eftersom cachen kanske inte innehåller ändringar som gjorts i den externa arbetsboken efter att presentationen senast uppdaterades.

## **Vanliga frågor**

**Kan jag avgöra om ett specifikt diagram är länkat till en extern eller en inbäddad arbetsbok?**

Ja. Ett diagram har en [datakälltyp](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdata/data_source_type/) och en [sökväg till en extern arbetsbok](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdata/external_workbook_path/); om källan är en extern arbetsbok kan du läsa den fullständiga sökvägen för att säkerställa att en extern fil används.

**Stöds relativa sökvägar till externa arbetsböcker, och hur lagras de?**

Ja. Om du anger en relativ sökväg konverteras den automatiskt till en absolut sökväg. Detta är praktiskt för projektportabilitet; dock bör du vara medveten om att presentationen lagrar den absoluta sökvägen i PPTX‑filen.

**Kan jag använda arbetsböcker som ligger på nätverksresurser/delade mappar?**

Ja, sådana arbetsböcker kan användas som en extern datakälla. Att redigera fjärrarbetsböcker direkt från Aspose.Slides stöds dock inte – de kan endast användas som källa.

**Skriver Aspose.Slides över den externa XLSX‑filen när presentationen sparas?**

Endast om du har redigerat diagramdata. Presentationen lagrar en [länk till den externa filen](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdata/external_workbook_path/) och använder den för att läsa data, så att öppna och spara en presentation lämnar arbetsboken orörd. Däremot skrivs värden du ändrar via diagramdata (see [Redigera diagramdata](#edit-chart-data) above) tillbaka till den externa arbetsboken när presentationen sparas – arbeta på en kopia om originalet måste förbli intakt.

**Vad ska jag göra om den externa filen är lösenordsskyddad?**

Aspose.Slides accepterar inte ett lösenord vid länkning. En vanlig metod är att ta bort skyddet i förväg eller förbereda en avkrypterad kopia (t.ex. med [Aspose.Cells](/cells/python-net/)) och länka till den kopian.

**Kan flera diagram referera till samma externa arbetsbok?**

Ja. Varje diagram lagrar sin egen länk. Om de alla pekar på samma fil kommer en uppdatering av den filen att återspeglas i varje diagram nästa gång data laddas.