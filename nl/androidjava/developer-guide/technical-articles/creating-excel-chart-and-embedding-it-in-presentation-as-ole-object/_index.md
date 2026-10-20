---
title: Maak Excel-diagrammen en embed ze in presentaties als OLE-objecten
type: docs
weight: 30
url: /nl/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel-diagram
- diagram embedden
- OLE-object
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Maak een Excel-diagram met Aspose.Cells for Android via Java en embed de werkmap in een PowerPoint-presentatie met Aspose.Slides for Android via Java, inclusief een diagrampreview."
---
## **Overzicht**

Dit artikel toont hoe u een Excel‑kolomdiagram maakt met Aspose.Cells for Android via Java en de werkmap erin embedt in een PowerPoint‑presentatie met Aspose.Slides for Android via Java. De ingebedde werkmap bevat zowel de brongegevens als het diagram. Een aparte PNG‑preview toont het diagram op de dia voordat het OLE‑object wordt geactiveerd.

Het resultaat is een ingebed Excel‑object, geen native PowerPoint‑diagram. Het bewerken van de werkmap via OLE vereist een desktop‑applicatie die OLE‑activatie ondersteunt en een compatibele Excel‑installatie.

## **Voorvereisten**

Voeg Aspose.Cells for Android via Java en Aspose.Slides for Android via Java toe aan de afhankelijkheden van uw project. Roep `ExcelChartEmbedding.createPresentation(getFilesDir())` aan vanuit een Android‑activiteit. Microsoft Office is niet vereist om de presentatie te genereren met deze bibliotheken.

Er zijn geen invoerbestanden nodig: het voorbeeld maakt de gegevens en het diagram in het geheugen aan, en schrijft vervolgens `OutputChart.pptx` naar de interne bestandsmap van de applicatie. Pas licenties toe voor beide producten wanneer u buiten de evaluatiemodus werkt.

## **Hoe de insluiting werkt**

1. Maak een werkmap met een gegevenswerkblad en een diagramblad.
1. Maak het diagramblad actief zodat de werkmap opent op het diagram.
1. Stel het OLE‑displaybereik van de werkmap in en render het diagram naar PNG.
1. Sla de werkmap op als XLSX in het geheugen op en embed die bytes in een dia.
1. Wijs de PNG toe als preview van het OLE‑object en sla de presentatie op als PPTX.

Het displaybereik van de werkmap en het kader op de dia hebben verschillende rollen. [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) neemt nul‑gebaseerde start‑/eind‑rij‑ en kolomindexen. [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) neemt in plaats daarvan de bovenste rij, de linkerkolom, de onderste rij en de rechterkolom. Het voorbeeld gebruikt rij‑index 55 en kolom‑index 25 als de rechter‑ondergrenzen; deze waarden zijn lay‑outkeuzes, niet het aantal gegevensrijen of -kolommen.

Het dia‑kader gebruikt punten. Het voorbeeld past het binnen de dia en centreert het, terwijl het beeldverhouding van de PNG behouden blijft, in plaats van de preview uit te rekken tot de hele dia te vullen.

## **Maak en embed het diagram**

Het volgende volledige voorbeeld vult `DataSheet` met vier rijen en vijf kolommen met waarden. Elke rij wordt een diagramreeks. `ChartSheet` wordt geselecteerd als het actieve blad vóórdat de werkmap wordt opgeslagen.

De werkmap wordt expliciet opgeslagen als XLSX, overeenkomend met de `xlsx`‑extensie die wordt doorgegeven aan [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleembeddeddatainfo/). De PNG wordt rechtstreeks uit de bytes geladen zonder een tussenliggende bitmap‑conversie. Toewijzing via [getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) vervangt de standaard OLE‑placeholder.

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

                // Render de diagram-preview en serialiseer de bewerkbare werkmap afzonderlijk.
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

                        // Pas de preview aan binnen de dia zonder de beeldverhouding te wijzigen.
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

## **Verwacht resultaat**

`OutputChart.pptx` bevat één dia met een ingebedde Excel‑werkmap en een diagram‑preview. De werkmap bevat de oorspronkelijke gegevens en een kolomdiagram met vier reeksen. De preview is gecentreerd op de dia en behoudt zijn verhoudingen.

![Excel kolomdiagram weergegeven als preview van een ingebedde werkmap](excel-chart-ole-preview.png)

In een compatibele desktop‑PowerPoint‑omgeving met Excel beschikbaar, dubbelklikt u op het object om het ingebedde werkmap te activeren en te bewerken. Activatie en bewerking hangen af van de OLE‑ondersteuning en beveiligingsinstellingen van de host‑applicatie.

## **Veelgestelde vragen**

**Waarom is een preview‑afbeelding nodig?**

De ingebedde werkmap en de dia‑preview zijn afzonderlijke inhoud. Lever een diagramafbeelding zodat de dia het diagram toont in plaats van de standaard “EMBEDDED OLE OBJECT” placeholder. Zie [Objectpreview‑probleem bij het toevoegen van OleObjectFrame](/slides/nl/androidjava/object-preview-issue-when-adding-oleobjectframe/).

**Werk de preview automatisch bij wanneer ik de werkmap in code wijzig?**

Beschouw de preview als een momentopname. Bij het programmatisch bijwerken van werkmapgegevens, genereer de diagramafbeelding opnieuw en vervang zowel de preview als de ingebedde werkmapgegevens.

**Kan ik XLS in plaats van XLSX gebruiken?**

Ja. Sla de werkmap op in XLS‑formaat en gebruik `xls` als de extensie voor de ingebedde gegevens. De extensie moet overeenkomen met het daadwerkelijke werkmapformaat; alleen de extensie wijzigen converteert de gegevens niet.

**Waarom kan het object van grootte veranderen na activatie?**

De host‑applicatie kan de presentatie van het OLE‑object bijwerken wanneer ze de werkmap activeert. Het OLE‑displaybereik van de werkmap en de afmetingen van het dia‑kader zijn beide van belang. Zie [Werkende oplossing voor het aanpassen van werkbladgrootte](/slides/nl/androidjava/working-solution-for-worksheet-resizing/).

## **Gerelateerde secties**

- [Werkende oplossing voor het aanpassen van werkbladgrootte](/slides/nl/androidjava/working-solution-for-worksheet-resizing/)
- [Objectpreview‑probleem bij het toevoegen van OleObjectFrame](/slides/nl/androidjava/object-preview-issue-when-adding-oleobjectframe/)
- [OLE beheren](/slides/nl/androidjava/manage-ole/)