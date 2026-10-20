---
title: Skapa Excel-diagram och bädda in dem i presentationer som OLE-objekt
type: docs
weight: 30
url: /sv/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel-diagram
- bädda in diagram
- OLE-objekt
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Skapa ett Excel-diagram med Aspose.Cells för Python via Java och bädda in arbetsboken i en PowerPoint-presentation med Aspose.Slides, inklusive en diagramförhandsgranskning."
---
## **Översikt**

Den här artikeln visar hur man skapar ett Excel‑stapeldiagram med Aspose.Cells för Python via Java och bäddar in dess arbetsbok i en PowerPoint‑presentation med Aspose.Slides för Python via Java. Den inbäddade arbetsboken innehåller både källdata och diagrammet. En separat PNG‑förhandsgranskning visar diagrammet på bilden innan OLE‑objektet aktiveras.

Resultatet är ett inbäddat Excel‑objekt, inte ett inbyggt PowerPoint‑diagram. Redigering av arbetsboken via OLE kräver ett skrivbordsprogram som stödjer OLE‑aktivering och en kompatibel Excel‑installation.

## **Förutsättningar**

Installera Python‑paketen `aspose-cells` och `aspose-slides-java` samt en kompatibel Java‑runtime. Importera båda paketen innan JVM startas så att deras Java‑bibliotek är tillgängliga för JPype. Microsoft Office krävs inte för att skapa presentationen med dessa bibliotek.

Inga indatafiler behövs: exemplet skapar data och diagram i minnet och skriver sedan `OutputChart.pptx` till den aktuella arbetskatalogen. Använd licenser för båda produkterna när du kör utanför utvärderingsläge.

## **Hur inbäddning fungerar**

1. Skapa en arbetsbok med ett dataarbetsblad och ett diagramblad.  
2. Gör diagrambladet aktivt så att arbetsboken öppnas på diagrammet.  
3. Ställ in arbetsbokens OLE‑visningsområde och rendera diagrammet till PNG.  
4. Spara arbetsboken som XLSX i minnet och bädda in dessa byte i en bild.  
5. Tilldela PNG‑filen som OLE‑objektets förhandsgranskning och spara presentationen som PPTX.

Arbetsbokens visningsområde och ramen på bilden har olika roller. [setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) tar emot nollbaserade start/slut rad‑ och kolumnindex. [ChartCollection.add](https://reference.aspose.com/cells/python-java/asposecells.api/chartcollection/#add) tar istället den översta raden, vänstra kolumnen, nedersta raden och högra kolumnen. Exemplet använder radindex 55 och kolumnindex 25 som nedre‑högra gränser; dessa värden är layoutval, inte antalet datarader eller -kolumner.

Bildramen använder punkter. Exemplet anpassar den till bilden och centrerar den samtidigt som bildförhållandet för PNG bevaras, istället för att sträcka förhandsgranskningen för att fylla bilden.

## **Skapa och bädda in diagrammet**

Följande kompletta exempel fyller `DataSheet` med fyra rader och fem kolumner av värden. Varje rad blir en diagramserie. `ChartSheet` väljs som aktivt blad innan arbetsboken sparas.

Arbetsboken sparas uttryckligen som XLSX, vilket matchar `xlsx`‑tillägget som skickas till [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/). Java‑byte‑array‑strömmar behåller arbetsboken och bilden i minnet och tillhandahåller de byte‑arrayer som krävs av Java‑API:erna. PNG‑filen laddas direkt från dess byte utan en mellanliggande bitmap‑konvertering. Att tilldela den via [getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) ersätter standard‑OLE‑platshållaren.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Images, OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("DataSheet")

    values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25],
    ]
    for row, row_values in enumerate(values):
        for column, value in enumerate(row_values):
            data_sheet.getCells().get(row, column).putValue(jpype.JInt(value))

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_sheet.setName("ChartSheet")

    last_chart_row = 55
    last_chart_column = 25
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
    chart = chart_sheet.getCharts().get(chart_index)
    for row in range(1, len(values) + 1):
        chart.getNSeries().add(f"DataSheet!A{row}:E{row}", False)

    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    workbook.getWorksheets().setOleSize(0, last_chart_row, 0, last_chart_column)

    # Rendera diagramförhandsgranskningen och serialisera den redigerbara arbetsboken separat.
    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    chart_image_stream = ByteArrayOutputStream()
    chart.toImage(chart_image_stream, image_options)
    chart_image_bytes = chart_image_stream.toByteArray()

    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.XLSX)
    workbook_bytes = workbook_stream.toByteArray()

    chart_image = Images.fromData(chart_image_bytes)
    try:
        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)
            slide_width = presentation.getSlideSize().getSize().getWidth()
            slide_height = presentation.getSlideSize().getSize().getHeight()

            # Anpassa förhandsgranskningen till bilden utan att ändra bildförhållandet.
            scale = min(slide_width / chart_image.getWidth(), slide_height / chart_image.getHeight())
            frame_width = chart_image.getWidth() * scale
            frame_height = chart_image.getHeight() * scale
            frame_x = (slide_width - frame_width) / 2
            frame_y = (slide_height - frame_height) / 2

            embedded_data = OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.getImages().addImage(chart_image)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(preview_image)

            presentation.save("OutputChart.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        chart_image.dispose()
finally:
    workbook.dispose()
```

## **Förväntat resultat**

`OutputChart.pptx` innehåller en bild med en inbäddad Excel‑arbetsbok och en diagramförhandsgranskning. Arbetsboken innehåller de ursprungliga data och ett stapeldiagram med fyra serier. Förhandsgranskningen är centrerad på bilden och behåller sina proportioner.

![Excel stapeldiagram som visas som förhandsgranskning av en inbäddad arbetsbok](excel-chart-ole-preview.png)

I en kompatibel skrivbordsmiljö för PowerPoint med Excel tillgängligt, dubbelklicka på objektet för att aktivera och redigera den inbäddade arbetsboken. Aktivering och redigering beror på värdprogrammets OLE‑stöd och säkerhetsinställningar.

## **Vanliga frågor**

**Varför behövs en förhandsgranskningsbild?**

Den inbäddade arbetsboken och dess bildförhandsgranskning är separata innehåll. Tillhandahåll en diagrambild så att bilden visar diagrammet istället för standard‑"EMBEDDED OLE OBJECT"‑platshållaren. Se [Object Preview Issue when Adding OleObjectFrame](/slides/sv/python-java/object-preview-issue-when-adding-oleobjectframe/).

**Uppdateras förhandsgranskningen automatiskt när jag ändrar arbetsboken i kod?**

Behandla förhandsgranskningen som ett ögonblicksbild. När arbetsboksdata uppdateras programatiskt, återskapa diagrambilden och ersätt både förhandsgranskningen och de inbäddade arbetsboksdata.

**Kan jag använda XLS istället för XLSX?**

Ja. Spara arbetsboken i XLS‑format och använd `xls` som inbäddad data‑tillägg. Tillägget måste matcha det faktiska arbetsboksformatet; att bara ändra tillägget konverterar inte data.

**Varför kan objektet ändra storlek efter aktivering?**

Värdprogrammet kan uppdatera OLE‑objektets presentation när det aktiverar arbetsboken. Arbetsbokens OLE‑visningsområde och bildramens dimensioner spelar båda roll. Se [Working Solution for Chart Resizing in PPTX](/slides/sv/python-java/working-solution-for-chart-resizing-in-pptx/).

## **Relaterade avsnitt**

- [Working Solution for Chart Resizing in PPTX](/slides/sv/python-java/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/sv/python-java/object-preview-issue-when-adding-oleobjectframe/)