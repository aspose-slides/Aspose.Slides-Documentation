---
title: Skapa Excel-diagram och bädda in dem i presentationer som OLE-objekt
type: docs
weight: 50
url: /sv/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel-diagram
- bädda in diagram
- OLE-objekt
- PowerPoint
- presentation
- Python
- Python via .NET
- Aspose.Slides
description: "Skapa ett Excel-diagram med Aspose.Cells för Python via .NET och bädda in arbetsboken i en PowerPoint-presentation med Aspose.Slides, inklusive en diagramförhandsgranskning."
---
## **Översikt**

Denna artikel visar hur du skapar ett Excel-stapeldiagram med Aspose.Cells för Python via .NET och bäddar in dess arbetsbok i en PowerPoint-presentation med Aspose.Slides för Python via .NET. Den inbäddade arbetsboken innehåller både källdata och diagrammet. En separat PNG-förhandsgranskning visar diagrammet på bilden innan OLE-objektet aktiveras.

Resultatet är ett inbäddat Excel-objekt, inte ett inbyggt PowerPoint-diagram. Att redigera arbetsboken via OLE kräver ett skrivbordsprogram som stöder OLE-aktivering och en kompatibel Excel-installation.

## **Förutsättningar**

Installera paketen `aspose-cells-python` och `aspose-slides` i din Python-miljö. Microsoft Office krävs inte för att skapa presentationen med dessa bibliotek.

Inga indatafiler behövs: exemplet skapar data och diagram i minnet och skriver sedan `OutputChart.pptx` till den aktuella arbetskatalogen. Tillämpa licenser för båda produkterna när du kör utanför evalueringsläge.

## **Hur inbäddning fungerar**

1. Skapa en arbetsbok med ett dataarbetsblad och ett diagramblad.  
1. Aktivera diagrambladet så att arbetsboken öppnas på diagrammet.  
1. Ställ in arbetsbokens OLE-visningsområde och rendera diagrammet till PNG.  
1. Spara arbetsboken som XLSX i minnet och bädda in dessa byte i en bild.  
1. Tilldela PNG-filen som OLE-objektets förhandsgranskning och spara presentationen som PPTX.

Arbetsbokens visningsområde och ramverket på bilden har olika roller. [set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) tar nollbaserade start/slut rad- och kolumnindex. [ChartCollection.add](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chartcollection/add/) tar istället den övre raden, vänstra kolumnen, nedre raden och högra kolumnen. Exemplet använder radindex 55 och kolumnindex 25 som nedre högra gränser; dessa värden är layoutval, inte antalet datarader eller kolumner.

Bildramen använder punkter. Exemplet passar den inom bilden och centrerar den samtidigt som bildförhållandet för PNG bevaras, snarare än att sträcka förhandsgranskningen för att fylla bilden.

## **Skapa och bädda in diagrammet**

Följande kompletta exempel fyller `DataSheet` med fyra rader och fem kolumner av värden. Varje rad blir en diagramserie. `ChartSheet` väljs som det aktiva bladet innan arbetsboken sparas.

Arbetsboken sparas uttryckligen som XLSX, vilket matchar `xlsx`‑tillägget som skickas till [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/). PNG-filen laddas direkt från dess ström utan en mellanliggande bitmapkonvertering. Att tilldela den via [substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/ioleobjectframe/substitute_picture_format/) ersätter standard‑OLE‑platshållaren.

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.cells.drawing as drawing
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "DataSheet"

values = [
    [67, 44, 46, 43, 24],
    [86, 64, 97, 29, 40],
    [68, 89, 78, 69, 38],
    [91, 48, 60, 26, 25],
]

for row, row_values in enumerate(values):
    for column, value in enumerate(row_values):
        data_sheet.cells.get(row, column).put_value(value)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_sheet.name = "ChartSheet"

last_chart_row = 55
last_chart_column = 25
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
chart = chart_sheet.charts[chart_index]
for row in range(1, len(values) + 1):
    chart.n_series.add(f"DataSheet!A{row}:E{row}", False)

workbook.worksheets.active_sheet_index = chart_sheet_index
workbook.worksheets.set_ole_size(0, last_chart_row, 0, last_chart_column)

# Rendera diagramförhandsgranskningen och serialisera den redigerbara arbetsboken separat.
with io.BytesIO() as chart_image_stream, io.BytesIO() as workbook_stream:
    chart.to_image(chart_image_stream, drawing.ImageType.PNG)
    chart_image_stream.seek(0)
    workbook.save(workbook_stream, cells.SaveFormat.XLSX)
    workbook_bytes = workbook_stream.getvalue()

    with slides.Images.from_stream(chart_image_stream) as chart_image:
        with slides.Presentation() as presentation:
            slide = presentation.slides[0]
            slide_size = presentation.slide_size.size

            # Anpassa förhandsgranskningen inom bilden utan att ändra bildförhållandet.
            scale = min(slide_size.width / chart_image.width, slide_size.height / chart_image.height)
            frame_width = chart_image.width * scale
            frame_height = chart_image.height * scale
            frame_x = (slide_size.width - frame_width) / 2
            frame_y = (slide_size.height - frame_height) / 2

            embedded_data = slides.dom.ole.OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.images.add_image(chart_image)
            ole_frame.substitute_picture_format.picture.image = preview_image

            presentation.save("OutputChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Förväntat resultat**

`OutputChart.pptx` innehåller en bild med en inbäddad Excel-arbetsbok och en diagramförhandsgranskning. Arbetsboken innehåller de ursprungliga data och ett stapeldiagram med fyra serier. Förhandsgranskningen är centrerad på bilden och behåller sina proportioner.

![Excel-stapeldiagram visat som förhandsgranskning av en inbäddad arbetsbok](excel-chart-ole-preview.png)

I en kompatibel skrivbordsmiljö för PowerPoint med Excel tillgängligt, dubbelklicka på objektet för att aktivera och redigera den inbäddade arbetsboken. Aktivering och redigering beror på värdprogrammets OLE‑stöd och säkerhetsinställningar.

## **Vanliga frågor**

**Varför behövs en förhandsgranskningsbild?**

Den inbäddade arbetsboken och dess bildförhandsgranskning är separat innehåll. Tillhandahåll en diagrambild så att bilden visar diagrammet istället för standard‑"EMBEDDED OLE OBJECT"‑platshållaren. Se [Object Preview Issue when Adding OleObjectFrame](/slides/sv/python-net/object-preview-issue-when-adding-oleobjectframe/).

**Uppdateras förhandsgranskningen automatiskt när jag ändrar arbetsboken i kod?**

Behandla förhandsgranskningen som en ögonblicksbild. När du uppdaterar arbetsbokens data programatiskt, generera om diagrambilden och ersätt förhandsgranskningen samt den inbäddade arbetsboksdata.

**Kan jag använda XLS istället för XLSX?**

Ja. Spara arbetsboken i XLS‑format och använd `xls` som den inbäddade data­tillägget. Tillägget måste matcha det faktiska arbetsboksformatet; att bara ändra tillägget konverterar inte data.

**Varför kan objektet ändra storlek efter aktivering?**

Värdprogrammet kan uppdatera OLE‑objektets presentation när det aktiverar arbetsboken. Arbetsbokens OLE‑visningsområde och bildramens dimensioner spelar båda en roll. Se [Resize OLE Objects Automatically in PowerPoint Presentations](/slides/sv/python-net/working-solution-for-worksheet-resizing/).

## **Relaterade avsnitt**

- [Ändra storlek på OLE-objekt automatiskt i PowerPoint-presentationer](/slides/sv/python-net/working-solution-for-worksheet-resizing/)
- [Problem med förhandsgranskning av objekt när OleObjectFrame läggs till](/slides/sv/python-net/object-preview-issue-when-adding-oleobjectframe/)
- [Hantera OLE-objekt](/slides/sv/python-net/manage-ole/)