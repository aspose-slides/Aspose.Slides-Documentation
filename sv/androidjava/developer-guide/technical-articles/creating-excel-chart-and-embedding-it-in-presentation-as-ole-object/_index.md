---
title: Skapa Excel-diagram och bädda in dem i presentationer som OLE-objekt
type: docs
weight: 30
url: /sv/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel-diagram
- bädda in diagram
- OLE-objekt
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Skapa ett Excel-diagram med Aspose.Cells för Android via Java och bädda in arbetsboken i en PowerPoint-presentation med Aspose.Slides för Android via Java, inklusive en diagramförhandsvisning."
---
## **Översikt**

Den här artikeln visar hur man skapar ett Excel‑stapeldiagram med Aspose.Cells för Android via Java och bäddar in dess arbetsbok i en PowerPoint‑presentation med Aspose.Slides för Android via Java. Den inbäddade arbetsboken innehåller både källdata och diagrammet. En separat PNG‑förhandsvisning visar diagrammet på bilden innan OLE‑objektet aktiveras.

Resultatet är ett inbäddat Excel‑objekt, inte ett inbyggt PowerPoint‑diagram. Redigering av arbetsboken via OLE kräver ett skrivbordsprogram som stödjer OLE‑aktivering och en kompatibel Excel‑installation.

## **Förutsättningar**

Lägg till Aspose.Cells för Android via Java och Aspose.Slides för Android via Java i ditt projekts beroenden. Anropa `ExcelChartEmbedding.createPresentation(getFilesDir())` från en Android‑aktivitet. Microsoft Office krävs inte för att generera presentationen med dessa bibliotek.

Inga indatafiler krävs: exemplet skapar data och diagram i minnet och skriver sedan `OutputChart.pptx` till applikationens interna filkatalog. Tilldela licenser för båda produkterna när du kör utanför utvärderingsläge.

## **Hur inbäddning fungerar**

1. Skapa en arbetsbok med ett data‑arbetsblad och ett diagramblad.  
2. Gör diagrambladet aktivt så att arbetsboken öppnas på diagrammet.  
3. Ställ in arbetsbokens OLE‑visningsområde och rendera diagrammet till PNG.  
4. Spara arbetsboken som XLSX i minnet och bädda in dessa byte i en bild.  
5. Tilldela PNG‑filen som OLE‑objektets förhandsvisning och spara presentationen som PPTX.

Arbetsbokens visningsområde och bildens ram har olika roller. [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) tar nollbaserade start‑/slutrad‑ och kolumnindex. [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) tar istället den översta raden, vänstra kolumnen, nedersta raden och högra kolumnen. Exemplet använder radindex 55 och kolumnindex 25 som de nedre‑högra gränserna; dessa värden är layoutval, inte antalet datarader eller -kolumner.

Bildramen använder punkter. Exemplet passar in den i bilden och centrerar den samtidigt som bildförhållandet i PNG bevaras, istället för att sträcka förhandsvisningen för att fylla bilden.

## **Skapa och bädda in diagrammet**

Det följande kompletta exemplet fyller `DataSheet` med fyra rader och fem kolumner med värden. Varje rad blir en diagramserie. `ChartSheet` väljs som aktivt blad innan arbetsboken sparas.

Arbetsboken sparas explicit som XLSX, vilket matchar `xlsx`‑tillägget som skickas till [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleembeddeddatainfo/). PNG‑filen laddas direkt från dess byte utan en mellanstegsbilduppsättning. Att tilldela den via [getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) ersätter standard‑OLE‑platshållaren.

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
import java.io.File;

public class ExcelChartEmbedding {
    public static void createPresentation(File filesDirectory) {
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

                // Rendera diagramförhandsvisningen och serialisera den redigerbara arbetsboken separat.
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

                        // Anpassa förhandsvisningen inom bilden utan att ändra dess bildförhållande.
                        double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                        float frameWidth = (float) (chartImage.getWidth() * scale);
                        float frameHeight = (float) (chartImage.getHeight() * scale);
                        float frameX = (float) ((slideWidth - frameWidth) / 2);
                        float frameY = (float) ((slideHeight - frameHeight) / 2);

                        OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                        IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                        IPPImage previewImage = presentation.getImages().addImage(chartImage);
                        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                        File outputFile = new File(filesDirectory, "OutputChart.pptx");
                        presentation.save(outputFile.getAbsolutePath(), Pptx);
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
    }
}
```

## **Förväntat resultat**

`OutputChart.pptx` innehåller en bild med en inbäddad Excel‑arbetsbok och en diagramförhandsvisning. Arbetsboken innehåller de ursprungliga data och ett stapeldiagram med fyra serier. Förhandsvisningen är centrerad på bilden och behåller sina proportioner.

![Excel‑stapeldiagram visas som förhandsvisning av en inbäddad arbetsbok](excel-chart-ole-preview.png)

I en kompatibel desktop‑PowerPoint‑miljö med Excel tillgängligt kan du dubbelklicka på objektet för att aktivera och redigera den inbäddade arbetsboken. Aktivering och redigering beror på värdprogrammets OLE‑stöd och säkerhetsinställningar.

## **FAQ**

**Varför behövs en förhandsvisningsbild?**

Den inbäddade arbetsboken och dess bildförhandsvisning är separat innehåll. Tillhandahåll en diagrambild så att bilden visar diagrammet istället för standard‑"EMBEDDED OLE OBJECT"-platshållaren. Se [Problem med objektförhandsvisning vid tillägg av OleObjectFrame](/slides/sv/androidjava/object-preview-issue-when-adding-oleobjectframe/).

**Uppdateras förhandsvisningen automatiskt när jag ändrar arbetsboken i kod?**

Behandla förhandsvisningen som ett ögonblicksbilder. När du uppdaterar arbetsbokens data programatiskt, generera om diagrambilden och ersätt både förhandsvisningen och de inbäddade arbetsboksdata.

**Kan jag använda XLS istället för XLSX?**

Ja. Spara arbetsboken i XLS‑format och använd `xls` som den inbäddade dataförlängningen. Förlängningen måste matcha det faktiska arbetsboksformatet; att bara ändra förlängningen konverterar inte data.

**Varför kan objektet ändra storlek efter aktivering?**

Värdprogrammet kan uppdatera OLE‑objektets presentation när det aktiverar arbetsboken. Arbetsbokens OLE‑visningsområde och bildramens dimensioner spelar båda roll. Se [Fungerande lösning för arbetssbladsändring](/slides/sv/androidjava/working-solution-for-worksheet-resizing/).

## **Relaterade avsnitt**

- [Fungerande lösning för arbetssbladsändring](/slides/sv/androidjava/working-solution-for-worksheet-resizing/)
- [Problem med objektförhandsvisning vid tillägg av OleObjectFrame](/slides/sv/androidjava/object-preview-issue-when-adding-oleobjectframe/)
- [Hantera OLE](/slides/sv/androidjava/manage-ole/)