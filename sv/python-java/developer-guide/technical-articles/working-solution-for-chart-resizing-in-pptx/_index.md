---
title: Arbetslösning för diagramstorleksändring i PPTX
type: docs
weight: 40
url: /sv/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- diagramstorleksändring
- Excel-diagram
- OLE-objekt
- bädda in diagram
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Åtgärda oavsiktlig diagramstorleksändring i PPTX när inbäddade Excel OLE-objekt används med Aspose.Slides för Python via Java. Ange fasta diagramdimensioner för att hålla diagrammets och OLE-ramens storlekar konsekventa."
---
## **Bakgrund**

Excel-diagram som bäddas in som OLE-objekt i PowerPoint-presentationer med Aspose-komponenter kan ändra storlek efter deras första aktivering. Detta kan leda till en märkbar skillnad i diagrammets utseende före och efter aktivering. Den här artikeln förklarar varför storleksändringen sker och visar hur man förhindrar den genom att anpassa fasta diagramdimensioner till OLE-ramen.

I [Skapa Excel-diagram och bädda in dem som OLE-objekt i presentationer](/slides/sv/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), förklarade vi hur man skapar ett Excel-diagram med Aspose.Cells för Python via Java och bäddar in det i en PowerPoint-presentation med Aspose.Slides för Python via Java. För att åtgärda [objektförhandsgranskningsproblemet](/slides/sv/python-java/object-preview-issue-when-adding-oleobjectframe/), tilldelade vi diagrammets bild till diagrammets OLE-objektram. I den genererade presentationen, när du dubbelklickar på OLE-objektramen som visar diagrambilden, aktiveras Excel-diagrammet. Användare kan redigera den inbäddade Excel-arbetsboken och sedan återgå till bilden genom att klicka utanför den aktiverade arbetsboken. Storleken på OLE-objektramen ändras när användaren återvänder till bilden, och förändringsfaktorn varierar beroende på de ursprungliga storlekarna för både OLE-objektramen och den inbäddade Excel-arbetsboken.

## **Orsak till storleksändring**

Den inbäddade Excel-arbetsboken har sina egna fönsterdimensioner, som Excel försöker behålla när objektet först aktiveras. OLE-ramen på bilden har självständigt definierade dimensioner. När Excel-arbetsboken aktiveras förhandlar Excel och PowerPoint om objektets storlek för att behålla dess proportioner som en del av inbäddningsprocessen. Skillnader mellan arbetsbokens fönster och OLE-ramen kan därför orsaka att objektet ändrar storlek.

## **Fungerande lösning**

Anpassa diagrammets storlek till OLE-ramen på bilden och håll diagrammets dimensioner oberoende av arbetsbokens fönster. Denna lösning fungerar med en ny presentation eller en befintlig mall.

Exemplet kräver Aspose.Cells för Python via Java och Aspose.Slides för Python via Java. Det skapar ett enkelt stapeldiagram på ett aktivt diagramblad och bäddar in arbetsboken i XLS-format. Ingen förhandsgranskningsbild för diagrammet tilldelas; diagrammet blir synligt när OLE-objektet aktiveras i PowerPoint.

Exemplet skapar en ny presentation med en 9,5 × 4 tum OLE-ram placerad 0,5 tum från vänster kant och 1 tum från toppen. Bildkoordinater och dimensioner är i punkter (72 punkter per tum). För en befintlig presentation, se [Använd en mall](#use-a-template).

## **Ange en fast diagramstorlek**

Ange [setSizeWithWindow](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#sizewithwindow) till false så att diagrammets dimensioner är oberoende av arbetsbokens fönster. Ange dimensionerna för [getChartObject](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#chartobject) via [setWidth](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#width) och [setHeight](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#height), och konvertera punkter till pixlar med 96 pixlar per tum: en ram som mäter 684 × 288 punkter motsvarar ett diagram som mäter 912 × 384 pixlar. Ange [setPrintSize](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#printsize) till CUSTOM‑värdet för [PrintSizeType](https://reference.aspose.com/cells/python-java/asposecells.api/printsizetype/). Exemplet bäddar in arbetsboken med [addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) och sparar en presentation med en 9,5 × 4 tum OLE-ram.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import ChartType, FileFormatType, PrintSizeType, SheetType, Workbook
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("Data")
    data_sheet.getCells().get("A1").putValue(10)
    data_sheet.getCells().get("A2").putValue(20)

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add("Data!A1:A2", True)
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)

        # Bildkoordinater och dimensioner är i punkter (72 punkter per tum).
        width = 684.0  # 9,5 tum.
        height = 288.0  # 4 tum.

        chart.setSizeWithWindow(False)
        # Konvertera punkter till diagrampixel med 96 pixlar per tum.
        chart.getChartObject().setWidth(int(width / 72.0 * 96.0))
        chart.getChartObject().setHeight(int(height / 72.0 * 96.0))
        chart.setPrintSize(PrintSizeType.CUSTOM)

        workbook_stream = ByteArrayOutputStream()
        workbook.save(workbook_stream, FileFormatType.EXCEL_97_TO_2003)
        workbook_data = workbook_stream.toByteArray()
        data_info = OleEmbeddedDataInfo(workbook_data, "xls")
        slide.getShapes().addOleObjectFrame(36.0, 72.0, width, height, data_info)

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    workbook.dispose()
```

## **Använd en mall**

Storlekslogiken är densamma för en befintlig presentation. För att anpassa exemplet:

1. Läs in mallpresentationen istället för att skapa en tom presentation.
1. Kontrollera att den första bilden innehåller minst tre former och använd sedan formen på index 2 som platshållare.
1. Hämta ramens bredd och höjd från den formen istället för att använda de fasta värdena 684 och 288. Behåll storleksberäkningarna oförändrade.
1. Lägg till OLE-ramen på platshållarens position istället för de fasta koordinaterna 36 och 72.
1. Ta bort platshållaren innan presentationen sparas.

## **FAQ**

**Varför ändras mitt inbäddade Excel-diagram i storlek efter att det aktiverats i PowerPoint?**

Detta händer eftersom Excel försöker återställa det ursprungliga fönsterstorleken vid första aktiveringen, medan OLE-objektramen i PowerPoint har egna dimensioner. PowerPoint och Excel förhandlar om storleken för att bevara bildförhållandet, vilket kan leda till storleksändringen.

**Hur kan jag hålla diagram- och OLE-ramens storlekar konsekventa?**

Ange fasta diagramdimensioner som matchar OLE-ramen och använd en anpassad diagramutskriftsstorlek innan du bäddar in arbetsboken. Exemplet ovan visar de nödvändiga inställningarna och enhetsomvandlingarna.

**Är det tillräckligt att matcha arbetsbokens fönsterstorlek?**

Att enbart matcha arbetsbokens fönsterstorlek förhindrar inte på ett tillförlitligt sätt att OLE-ramen ändrar storlek efter aktivering. Använd fasta diagramdimensioner som visas i exemplet.

**Fungerar den här lösningen med både mallbaserade presentationer och nya presentationer?**

Ja. För en mall, använd platshållarens dimensioner och position. För en ny presentation, ange ramens dimensioner och position direkt.

**Kan jag använda detta exempel med diagram skapade i andra kalkylprogram?**

Exemplet använder en Excel-arbetsbok skapad med Aspose.Cells. Det visar inte aktiveringsbeteendet för andra kalkylprogram.

## **Relaterade avsnitt**

- [Skapa Excel-diagram och bädda in dem som OLE-objekt i presentationer](/slides/sv/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)