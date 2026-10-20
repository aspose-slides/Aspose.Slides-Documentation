---
title: Skapa Excel-diagram och bädda in dem i presentationer som OLE-objekt
type: docs
weight: 30
url: /sv/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel-diagram
- bädda in diagram
- OLE-objekt
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Skapa ett Excel-diagram med Aspose.Cells för Java och bädda in arbetsboken i en PowerPoint-presentation med Aspose.Slides, inklusive en diagramförhandsgranskning."
---
## **Översikt**

Den här artikeln visar hur du skapar ett Excel stapeldiagram med Aspose.Cells for Java och bäddar in dess arbetsbok i en PowerPoint‑presentation med Aspose.Slides for Java. Den inbäddade arbetsboken innehåller både källdata och diagrammet. En separat PNG‑förhandsgranskning visar diagrammet på bilden innan OLE‑objektet aktiveras.

Resultatet blir ett inbäddat Excel‑objekt, inte ett inbyggt PowerPoint‑diagram. Att redigera arbetsboken via OLE kräver ett skrivbordsprogram som stödjer OLE‑aktivering och en kompatibel Excel‑installation.

## **Förutsättningar**

Lägg till Aspose.Cells for Java och Aspose.Slides for Java i ditt projekts beroenden. Kör exemplet inom en Java‑metod. Microsoft Office krävs inte för att generera presentationen med dessa bibliotek.

Inga indatafiler behövs: exemplet skapar data och diagram i minnet och skriver sedan `OutputChart.pptx` till den aktuella arbetskatalogen. Tilldela licenser för båda produkterna när du kör utanför utvärderingsläge.

## **Hur inbäddningen fungerar**

1. Skapa en arbetsbok med ett dataarbetsblad och ett diagramblad.  
2. Gör diagrambladet aktivt så att arbetsboken öppnas på diagrammet.  
3. Ställ in arbetsbokens OLE‑visningsområde och rendera diagrammet till PNG.  
4. Spara arbetsboken som XLSX i minnet och bädda in dessa bytes i en bild.  
5. Tilldela PNG‑filen som OLE‑objektets förhandsgranskning och spara presentationen som PPTX.  

Arbetsbokens visningsområde och bildramen har olika roller. [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) använder nollbaserade start‑ och slutrad‑ samt kolumnindex. [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) tar istället den översta raden, vänstra kolumnen, nedersta raden och högra kolumnen. Exemplet använder radindex 55 och kolumnindex 25 som nedre högra gränser; dessa värden är layoutval, inte antalet datarader eller -kolumner.

Bildramen använder punkter. Exemplet anpassar den inom bilden och centrerar den samtidigt som bildförhållandet för PNG bevaras, snarare än att sträcka förhandsgranskningen för att fylla bilden.

## **Skapa och bädda in diagrammet**

Följande kompletta exempel fyller `DataSheet` med fyra rader och fem kolumner med värden. Varje rad blir en diagramserie. `ChartSheet` väljs som det aktiva bladet innan arbetsboken sparas.

Arbetsboken sparas explicit som XLSX, vilket matchar `xlsx`‑tillägget som skickas till [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/oleembeddeddatainfo/). PNG‑filen laddas direkt från dess bytes utan en mellansteg av bitmapkonvertering. Att tilldela den via [getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) ersätter standard‑OLE‑platshållaren.

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import static com.aspose.cells.SaveFormat.XLSX;
import static com.aspose.slides.SaveFormat.Pptx;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.IImage;
import com.aspose.slides.Images;
import com.aspose.slides.IOleObjectFrame;
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import java.io.ByteArrayOutputStream;

try {
    Workbook workbook = new Workbook();
    try {
        Worksheet dataSheet = workbook.getWorksheets().get(0);
        dataSheet.setName("DataSheet");

        int[][] values = {
            { 67, 44, 46, 43, 24 },
            { 86, 64, 97, 29, 40 },
            { 68, 89, 78, 69, 38 },
            { 91, 48, 60, 26, 25 }
        };

        for (int row = 0; row < values.length; row++) {
            for (int column = 0; column < values[row].length; column++) {
                dataSheet.getCells().get(row, column).putValue(values[row][column]);
            }
        }

        int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
        Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
        chartSheet.setName("ChartSheet");

        int lastChartRow = 55;
        int lastChartColumn = 25;
        int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
        Chart chart = chartSheet.getCharts().get(chartIndex);
        for (int row = 1; row <= values.length; row++) {
            chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
        }

        workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
        workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

        // Rendera diagramförhandsgranskningen och serialisera den redigerbara arbetsboken separat.
        ImageOrPrintOptions imageOptions = new ImageOrPrintOptions();
        imageOptions.setImageType(ImageType.PNG);
        ByteArrayOutputStream chartImageStream = new ByteArrayOutputStream();
        chart.toImage(chartImageStream, imageOptions);
        byte[] chartImageBytes = chartImageStream.toByteArray();

        ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
        workbook.save(workbookStream, XLSX);
        byte[] workbookBytes = workbookStream.toByteArray();

        IImage chartImage = Images.fromData(chartImageBytes);
        try {
            Presentation presentation = new Presentation();
            try {
                ISlide slide = presentation.getSlides().get_Item(0);
                double slideWidth = presentation.getSlideSize().getSize().getWidth();
                double slideHeight = presentation.getSlideSize().getSize().getHeight();

                // Använd förhandsgranskningen inom bilden utan att ändra bildförhållandet.
                double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                float frameWidth = (float) (chartImage.getWidth() * scale);
                float frameHeight = (float) (chartImage.getHeight() * scale);
                float frameX = (float) ((slideWidth - frameWidth) / 2);
                float frameY = (float) ((slideHeight - frameHeight) / 2);

                OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                IPPImage previewImage = presentation.getImages().addImage(chartImage);
                oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                presentation.save("OutputChart.pptx", Pptx);
            } finally {
                presentation.dispose();
            }
        } finally {
            chartImage.dispose();
        }
    } finally {
        workbook.dispose();
    }
} catch (Exception exception) {
    System.err.println("Could not create the presentation: " + exception.getMessage());
}
```
## **Förväntat resultat**

`OutputChart.pptx` innehåller en bild med en inbäddad Excel‑arbetsbok och en diagramförhandsgranskning. Arbetsboken innehåller de ursprungliga data och ett stapeldiagram med fyra serier. Förhandsgranskningen är centrerad på bilden och behåller sina proportioner.

![Excel stapeldiagram som visas som förhandsgranskning av en inbäddad arbetsbok](excel-chart-ole-preview.png)

I en kompatibel skrivbordsmiljö för PowerPoint med Excel tillgängligt kan du dubbelklicka på objektet för att aktivera och redigera den inbäddade arbetsboken. Aktivering och redigering beror på värdprogrammets OLE‑stöd och säkerhetsinställningar.

## **Vanliga frågor**

**Varför behövs en förhandsgranskningsbild?**

Den inbäddade arbetsboken och dess bildförhandsgranskning är separata innehåll. Tillhandahåll en diagrambild så att bilden visar diagrammet istället för standard‑"EMBEDDED OLE OBJECT"‑platshållaren. Se [Object Preview Issue when Adding OleObjectFrame](/slides/sv/java/object-preview-issue-when-adding-oleobjectframe/).

**Uppdateras förhandsgranskningen automatiskt när jag ändrar arbetsboken i kod?**

Behandla förhandsgranskningen som en ögonblicksbild. När du uppdaterar arbetsbokens data programatiskt, generera diagrambilden på nytt och ersätt både förhandsgranskningen och de inbäddade arbetsboksdata.

**Kan jag använda XLS istället för XLSX?**

Ja. Spara arbetsboken i XLS‑format och använd `xls` som den inbäddade data‑tillägget. Tillägget måste matcha det faktiska arbetsboksformatet; att bara ändra tillägget konverterar inte data.

**Varför kan objektet ändra storlek efter aktivering?**

Värdprogrammet kan uppdatera OLE‑objektets presentation när det aktiverar arbetsboken. Arbetsbokens OLE‑visningsområde och bildramens dimensioner är båda viktiga. Se [Working Solution for Chart Resizing in PPTX](/slides/sv/java/working-solution-for-chart-resizing-in-pptx/).

## **Relaterade avsnitt**

- [Arbetslösning för diagramstorleksjustering i PPTX](/slides/sv/java/working-solution-for-chart-resizing-in-pptx/)
- [Problem med förhandsgranskning av objekt när OleObjectFrame läggs till](/slides/sv/java/object-preview-issue-when-adding-oleobjectframe/)
- [Uppdatera OLE‑objekt automatiskt med ett PowerPoint‑tillägg](/slides/sv/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)