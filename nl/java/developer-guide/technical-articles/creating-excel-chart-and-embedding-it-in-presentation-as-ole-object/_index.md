---
title: Maak Excel-diagrammen en embed ze in presentaties als OLE-objecten
type: docs
weight: 30
url: /nl/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel-diagram
- diagram insluiten
- OLE-object
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Maak een Excel-diagram met Aspose.Cells voor Java en embed de werkmap in een PowerPoint-presentatie met Aspose.Slides, inclusief een diagrampreview."
---
## **Overzicht**

Dit artikel laat zien hoe u een Excel‑kolomdiagram maakt met Aspose.Cells voor Java en de bijbehorende werkmap in een PowerPoint‑presentatie opneemt met Aspose.Slides voor Java. De ingebedde werkmap bevat zowel de brongegevens als het diagram. Een afzonderlijke PNG‑preview toont het diagram op de dia voordat het OLE‑object wordt geactiveerd.

Het resultaat is een ingebed Excel‑object, geen native PowerPoint‑diagram. Het bewerken van de werkmap via OLE vereist een desktop‑applicatie die OLE‑activatie ondersteunt en een compatibele Excel‑installatie.

## **Voorvereisten**

Voeg Aspose.Cells voor Java en Aspose.Slides voor Java toe aan de afhankelijkheden van uw project. Voer het voorbeeld uit binnen een Java‑methode. Microsoft Office is niet vereist om de presentatie te genereren met deze bibliotheken.

Er zijn geen invoerbestanden nodig: het voorbeeld maakt de gegevens en het diagram in het geheugen, en schrijft vervolgens `OutputChart.pptx` naar de huidige werkmap. Pas licenties toe voor beide producten wanneer u buiten de evaluatiemodus werkt.

## **Hoe het insluiten werkt**

1. Maak een werkmap met een gegevenswerkblad en een diagramblad.
1. Maak het diagramblad actief zodat de werkmap opent op het diagram.
1. Stel het OLE‑weergavebereik van de werkmap in en render het diagram naar PNG.
1. Sla de werkmap op als XLSX in het geheugen en embed die bytes in een dia.
1. Wijs de PNG toe als preview van het OLE‑object en sla de presentatie op als PPTX.

Het weergavebereik van de werkmap en het kader op de dia hebben verschillende rollen. [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) neemt nul‑gebaseerde start/eind‑rij‑ en kolom‑indices. [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) neemt daarentegen de bovenste rij, linkerkolom, onderste rij en rechterkolom. Het voorbeeld gebruikt rij‑index 55 en kolom‑index 25 als de rechter‑onder‑grenzen; deze waarden zijn layout‑keuzes, niet het aantal gegevensrijen of -kolommen.

Het dia‑kader gebruikt punten. Het voorbeeld past het binnen de dia en centreert het, terwijl de beeldverhouding van de PNG behouden blijft, in plaats van de preview uit te rekken om de dia te vullen.

## **Maak en embed het diagram**

Het volgende volledige voorbeeld vult `DataSheet` met vier rijen en vijf kolommen met waarden. Elke rij wordt een diagramreeks. `ChartSheet` wordt geselecteerd als het actieve blad voordat de werkmap wordt opgeslagen.

De werkmap wordt expliciet opgeslagen als XLSX, overeenkomend met de `xlsx`‑extensie die wordt doorgegeven aan [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/oleembeddeddatainfo/). De PNG wordt rechtstreeks uit de bytes geladen zonder een tussenliggende bitmap‑conversie. Het toewijzen via [getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) vervangt de standaard OLE‑placeholder.

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

        // Render de diagrampreview en serialiseer de bewerkbare werkmap afzonderlijk.
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

## **Verwacht resultaat**

`OutputChart.pptx` bevat één dia met een ingebedde Excel‑werkmap en een diagram‑preview. De werkmap bevat de oorspronkelijke gegevens en een kolomdiagram met vier reeksen. De preview staat gecentreerd op de dia en behoudt zijn verhoudingen.

![Excel‑kolomdiagram weergegeven als preview van een ingebedde werkmap](excel-chart-ole-preview.png)

In een compatibele desktop‑PowerPoint‑omgeving met Excel beschikbaar, dubbelklikt u op het object om het te activeren en de ingebedde werkmap te bewerken. Activatie en bewerking hangen af van de OLE‑ondersteuning en de beveiligingsinstellingen van de host‑applicatie.

## **Veelgestelde vragen**

**Waarom is een preview‑afbeelding nodig?**

De ingebedde werkmap en de dia‑preview zijn afzonderlijke inhoud. Voorzie een diagramafbeelding zodat de dia het diagram toont in plaats van de standaard “EMBEDDED OLE OBJECT”‑placeholder. Zie [Probleem met preview van object bij toevoegen van OleObjectFrame](/slides/nl/java/object-preview-issue-when-adding-oleobjectframe/).

**Werkt de preview automatisch bij als ik de werkmap in code wijzig?**

Beschouw de preview als een momentopname. Wanneer u de werkmapgegevens programmatisch bijwerkt, moet u de diagramafbeelding opnieuw genereren en zowel de preview als de ingebedde werkmapgegevens vervangen.

**Kan ik XLS in plaats van XLSX gebruiken?**

Ja. Sla de werkmap op in XLS‑formaat en gebruik `xls` als de extensie voor de ingebedde gegevens. De extensie moet overeenkomen met het daadwerkelijke werkmapformaat; alleen de extensie wijzigen converteert de gegevens niet.

**Waarom kan het object van formaat veranderen na activatie?**

De host‑applicatie kan de weergave van het OLE‑object bijwerken wanneer ze de werkmap activeert. Het OLE‑weergavebereik van de werkmap en de afmetingen van het dia‑kader zijn beide relevant. Zie [Werkende oplossing voor diagramschaling in PPTX](/slides/nl/java/working-solution-for-chart-resizing-in-pptx/).

## **Gerelateerde secties**

- [Werkende oplossing voor diagramschaling in PPTX](/slides/nl/java/working-solution-for-chart-resizing-in-pptx/)
- [Probleem met preview van object bij toevoegen van OleObjectFrame](/slides/nl/java/object-preview-issue-when-adding-oleobjectframe/)
- [OLE‑objecten automatisch bijwerken met een PowerPoint‑add‑in](/slides/nl/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)