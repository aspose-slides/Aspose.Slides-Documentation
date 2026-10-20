---
title: Fungerande lösning för diagramstorleksändring i PPTX
type: docs
weight: 60
url: /sv/python-net/working-solution-for-chart-resizing-in-pptx/
keywords:
- diagramstorleksändring
- Excel-diagram
- OLE-objekt
- bädda in diagram
- PowerPoint
- presentation
- Python via .NET
- Python
- Aspose.Slides
description: "Åtgärda oväntad diagramstorleksändring i PPTX när inbäddade Excel OLE-objekt används med Aspose.Slides för Python via .NET. Ange fasta diagramdimensioner för att hålla diagrammet och OLE-ramens storlekar konsekventa."
---
## **Översikt**

Excel-diagram som är inbäddade som OLE-objekt i PowerPoint-presentationer med hjälp av Aspose-komponenter kan ändra storlek efter sin första aktivering. Detta kan leda till en märkbar skillnad i diagrammets utseende före och efter aktivering. Denna artikel förklarar varför storleksändringen sker och visar hur man förhindrar den genom att matcha fasta diagramdimensioner med OLE-ramen.

I [Skapa Excel-diagram och bädda in dem som OLE-objekt i presentationer](/slides/sv/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), förklarade vi hur man skapar ett Excel-diagram med Aspose.Cells for Python via .NET och bäddar in det i en PowerPoint-presentation med Aspose.Slides for Python via .NET. För att åtgärda [objektförhandsgranskningsproblem](/slides/sv/python-net/object-preview-issue-when-adding-oleobjectframe/), tilldelade vi diagrambilden till diagrammets OLE-objektram. I den resulterande presentationen, när du dubbelklickar på OLE-objektramen som visar diagrambilden, aktiveras Excel-diagrammet. Användare kan redigera den inbäddade Excel-arbetsboken och sedan återgå till bilden genom att klicka utanför den aktiverade arbetsboken. Storleken på OLE-objektramen förändras när användaren återgår till bilden, och förändringsfaktorn varierar beroende på de ursprungliga storlekarna för både OLE-objektramen och den inbäddade Excel-arbetsboken.

## **Orsak till storleksändring**

Den inbäddade Excel-arbetsboken har egna fönsterdimensioner, som Excel försöker bevara när objektet först aktiveras. OLE-ramen på bilden har självständigt definierade dimensioner. När Excel-arbetsboken aktiveras, förhandlar Excel och PowerPoint om objektets storlek för att behålla dess proportioner som en del av inbäddningsprocessen. Skillnader mellan arbetsbokens fönster och OLE-ramen kan därför leda till att objektet ändrar storlek.

## **Fungerande lösning**

Matcha diagrammets storlek med OLE-ramen på bilden och håll diagrammets dimensioner oberoende av arbetsbokens fönster. Denna lösning fungerar med en ny presentation eller en befintlig mall.

Exemplet kräver Aspose.Cells for Python via .NET och Aspose.Slides for Python via .NET. Det skapar ett enkelt stapeldiagram på ett aktivt diagramblad och bäddar in arbetsboken i XLS-format. Ingen diagramförhandsgranskningsbild tilldelas; diagrammet blir synligt när OLE-objektet aktiveras i PowerPoint.

Exemplet skapar en ny presentation med en 9,5 × 4 tum OLE-ram placerad 0,5 tum från vänster kant och 1 tum från toppen. Bildens koordinater och dimensioner är i punkter (72 punkter per tum). För en befintlig presentation, se [Använd en mall](#use-a-template).

## **Ange en fast diagramstorlek**

Ställ in [size_with_window](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/size_with_window/) till false så att diagrammets dimensioner är oberoende av arbetsbokens fönster. Ställ in [chart_object](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/chart_object/) dimensionerna via [width](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/width/) och [height](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/height/), genom att konvertera punkter till pixlar med 96 pixlar per tum: en ram som mäter 684 × 288 punkter motsvarar ett diagram som mäter 912 × 384 pixlar. Ställ in [print_size](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/print_size/) till CUSTOM‑värdet för [PrintSizeType](https://reference.aspose.com/cells/python-net/aspose.cells/printsizetype/). Exemplet bäddar in arbetsboken med [add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/add_ole_object_frame/) och sparar en presentation med en 9,5 × 4 tum OLE-ram.

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "Data"
data_sheet.cells.get("A1").put_value(10)
data_sheet.cells.get("A2").put_value(20)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, 20, 10)
chart = chart_sheet.charts[chart_index]
chart.n_series.add("Data!A1:A2", True)
workbook.worksheets.active_sheet_index = chart_sheet_index

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Bildens koordinater och dimensioner är i punkter (72 punkter per tum).
    width = 684.0  # 9,5 tum.
    height = 288.0  # 4 tum.

    chart.size_with_window = False
    # Konvertera punkter till diagrampixlar med 96 pixlar per tum.
    chart.chart_object.width = int(width / 72 * 96)
    chart.chart_object.height = int(height / 72 * 96)
    chart.print_size = cells.PrintSizeType.CUSTOM

    with io.BytesIO() as workbook_stream:
        workbook.save(workbook_stream, cells.SaveFormat.EXCEL_97_TO_2003)
        data_info = slides.dom.ole.OleEmbeddedDataInfo(workbook_stream.getvalue(), "xls")
        slide.shapes.add_ole_object_frame(36, 72, width, height, data_info)

    presentation.save("chart-fixed-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Använd en mall**

Storlekslogiken är densamma för en befintlig presentation. För att anpassa exemplet:

1. Läs in mall-presentationen istället för att skapa en tom presentation.  
2. Kontrollera att den första bilden innehåller minst tre former, och använd sedan formen på index 2 som platshållare.  
3. Ta ramens bredd och höjd från den formen istället för att använda de fasta värdena 684 och 288. Behåll storleksberäkningarna oförändrade.  
4. Lägg till OLE-ramen på platshållarens position istället för de fasta koordinaterna 36 och 72.  
5. Ta bort platshållaren innan presentationen sparas.

## **FAQ**

**Varför ändras mitt inbäddade Excel-diagram i storlek efter att det aktiverats i PowerPoint?**  
Detta sker eftersom Excel försöker återställa det ursprungliga fönsterstorleken vid första aktiveringen, medan OLE-objektramen i PowerPoint har sina egna dimensioner. PowerPoint och Excel förhandlar om storleken för att bevara bildförhållandet, vilket kan leda till storleksändring.

**Hur kan jag hålla diagram- och OLE-ramstorlekarna konsekventa?**  
Ange fasta diagramdimensioner som matchar OLE-ramen och använd en anpassad diagramutskriftsstorlek innan arbetsboken bäddas in. Exemplet ovan visar de nödvändiga inställningarna och enhetskonverteringarna.

**Är det tillräckligt att matcha arbetsbokens fönsterstorlek?**  
Att endast matcha arbetsbokens fönsterstorlek förhindrar inte på ett pålitligt sätt att OLE-ramen förändras i storlek efter aktivering. Använd fasta diagramdimensioner som visas i exemplet.

**Fungerar denna lösning både för mallbaserade presentationer och nya presentationer?**  
Ja. För en mall, använd platshållarens dimensioner och position. För en ny presentation, ange ramens dimensioner och position direkt.

**Kan jag använda detta exempel med diagram skapade i andra kalkylbladsprogram?**  
Exemplet använder en Excel-arbetsbok skapad med Aspose.Cells. Det visar inte aktiveringsbeteende för andra kalkylbladsprogram.

## **Relaterade avsnitt**

- [Skapa Excel-diagram och bädda in dem som OLE-objekt i presentationer](/slides/sv/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Uppdatera OLE-objekt automatiskt med ett PowerPoint‑tillägg](/slides/sv/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)