---
title: "Fungerande lösning för diagramstorleksändring i PPTX"
type: docs
weight: 40
url: /sv/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- diagramstorleksändring
- Excel-diagram
- OLE-objekt
- bädda in diagram
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Åtgärda oväntad diagramstorleksändring i PPTX när inbäddade Excel OLE-objekt används med Aspose.Slides för Java. Ställ in fasta diagramdimensioner för att hålla diagram- och OLE-ramstorlekarna konsekventa."
---
## **Bakgrund**

Excel-diagram som är inbäddade som OLE-objekt i PowerPoint-presentationer med Aspose-komponenter kan ändra storlek efter sin första aktivering. Detta kan leda till en märkbar skillnad i diagrammets utseende före och efter aktiveringen. Denna artikel förklarar varför storleksändringen sker och visar hur man förhindrar den genom att matcha fasta diagramdimensioner med OLE-ramen.

I [Skapa Excel-diagram och bädda in dem som OLE-objekt i presentationer](/slides/sv/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) förklarade vi hur man skapar ett Excel-diagram med Aspose.Cells for Java och bäddar in det i en PowerPoint‑presentation med Aspose.Slides for Java. För att åtgärda [problem med förhandsgranskning av objekt](/slides/sv/java/object-preview-issue-when-adding-oleobjectframe/) tilldelade vi diagrammets bild till diagrammets OLE‑objektram. I den resulterande presentationen, när du dubbelklickar på OLE‑objektramen som visar diagrambilden, aktiveras Excel‑diagrammet. Användare kan redigera den inbäddade Excel‑arbetsboken och sedan återgå till bilden genom att klicka utanför den aktiverade arbetsboken. Storleken på OLE‑objektramen ändras när användaren återvänder till bilden, och omräkningsfaktorn varierar beroende på de ursprungliga storlekarna för både OLE‑objektramen och den inbäddade Excel‑arbetsboken.

## **Orsak till storleksändring**

Den inbäddade Excel‑arbetsboken har sina egna fönsterdimensioner, som Excel försöker bevara när objektet först aktiveras. OLE‑ramen på bilden har självständigt definierade dimensioner. När Excel‑arbetsboken aktiveras förhandlar Excel och PowerPoint om objektets storlek för att behålla dess proportioner som en del av inbäddningsprocessen. Skillnader mellan arbetsbokens fönster och OLE‑ramen kan därför få objektet att ändra storlek.

## **Fungerande lösning**

Matcha diagrammets storlek med OLE‑ramen på bilden och håll diagrammets dimensioner oberoende av arbetsbokens fönster. Denna lösning fungerar med en ny presentation eller en befintlig mall.

Exemplet kräver Aspose.Cells for Java och Aspose.Slides for Java. Det skapar ett enkelt stapeldiagram på ett aktivt diagramblad och bäddar in arbetsboken i XLS‑format. Ingen förhandsgranskningsbild för diagrammet tilldelas; diagrammet blir synligt när OLE‑objektet aktiveras i PowerPoint.

Exemplet skapar en ny presentation med en OLE‑ram på 9,5 × 4 tum placerad 0,5 tum från vänster kant och 1 tum från toppen. Bildkoordinater och dimensioner anges i punkter (72 punkter per tum). För en befintlig presentation, se [Använd en mall](#use-a-template).

## **Ställ in en fast diagramstorlek**

Ställ in [setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) till false så att diagramdimensionerna är oberoende av arbetsbokens fönster. Ställ in [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--)‑dimensionerna via [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) och [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-), och konvertera punkter till pixlar med 96 pixlar per tum: en ram som mäter 684 × 288 punkter motsvarar ett diagram som mäter 912 × 384 pixlar. Ställ in [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) till CUSTOM‑värdet av [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/). Exemplet bäddar in arbetsboken med [addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) och sparar en presentation med en OLE‑ram på 9,5 × 4 tum.

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.FileFormatType;
import com.aspose.cells.PrintSizeType;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Workbook workbook = new Workbook();
try {
    Worksheet dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
    Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10);
    Chart chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Bildens koordinater och dimensioner är i punkter (72 punkter per tum).
        float width = 684f; // 9,5 tum.
        float height = 288f; // 4 tum.

        chart.setSizeWithWindow(false);
        // Konvertera punkter till diagrampixlar med 96 pixlar per tum.
        chart.getChartObject().setWidth((int)(width / 72f * 96f));
        chart.getChartObject().setHeight((int)(height / 72f * 96f));
        chart.setPrintSize(PrintSizeType.CUSTOM);

        ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
        workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
        OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
        slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    workbook.dispose();
}
```

## **Använd en mall**

Storlekslogiken är densamma för en befintlig presentation. För att anpassa exemplet:

1. Läs in mallpresentationen istället för att skapa en tom presentation.  
2. Kontrollera att den första bilden innehåller minst tre former och använd sedan formen med index 2 som platshållare.  
3. Hämta ramens bredd och höjd från den formen istället för att använda de fasta värdena 684 och 288. Behåll storleksberäkningarna oförändrade.  
4. Lägg till OLE‑ramen på platshållarens position istället för de fasta koordinaterna 36 och 72.  
5. Ta bort platshållaren innan presentationen sparas.

## **Vanliga frågor**

**Varför ändrar mitt inbäddade Excel-diagram storlek efter att ha aktiverats i PowerPoint?**  
Detta händer eftersom Excel försöker återställa det ursprungliga fönsterstorleken vid första aktiveringen, medan OLE‑objektramen i PowerPoint har sina egna dimensioner. PowerPoint och Excel förhandlar om storleken för att behålla bildförhållandet, vilket kan leda till storleksändring.

**Hur kan jag hålla diagram- och OLE-ramstorlekar konsistenta?**  
Använd fasta diagramdimensioner som matchar OLE‑ramen och ange en anpassad utskriftsstorlek för diagrammet innan du bäddar in arbetsboken. Exemplet ovan visar de nödvändiga inställningarna och enhetsomvandlingarna.

**Är det tillräckligt att matcha arbetsbokens fönsterstorlek?**  
Att bara matcha arbetsbokens fönsterstorlek förhindrar inte på ett tillförlitligt sätt att OLE‑ramen ändrar storlek efter aktivering. Använd fasta diagramdimensioner som visas i exemplet.

**Fungerar denna lösning både för mallbaserade presentationer och nya presentationer?**  
Ja. För en mall använder du platshållarens dimensioner och position. För en ny presentation specificerar du ramens dimensioner och position direkt.

**Kan jag använda detta exempel med diagram skapade i andra kalkylprogram?**  
Exemplet använder en Excel‑arbetsbok som skapats med Aspose.Cells. Det demonstrerar inte aktiveringsbeteende för andra kalkylprogram.

## **Relaterade avsnitt**

- [Skapa Excel-diagram och bädda in dem som OLE-objekt i presentationer](/slides/sv/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)