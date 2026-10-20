---
title: Werkende oplossing voor diagramgrootte‑aanpassing in PPTX
type: docs
weight: 40
url: /nl/androidjava/working-solution-for-chart-resizing-in-pptx/
keywords:
- diagramgrootte‑aanpassing
- Excel-diagram
- OLE-object
- diagram insluiten
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Los onverwachte diagramgrootte‑aanpassing in PPTX op bij gebruik van ingebedde Excel OLE-objecten met Aspose.Slides for Android via Java. Stel vaste diagramafmetingen in om de diagram- en OLE-framegroottes consistent te houden."
---
## **Overzicht**

Excel-diagrammen die als OLE-objecten in PowerPoint‑presentaties zijn ingebed met Aspose‑componenten, kunnen van grootte veranderen na hun eerste activering. Dit kan een duidelijk verschil veroorzaken in het uiterlijk van het diagram vóór en na de activering. Dit artikel legt uit waarom het formaat verandert en toont hoe u dit kunt voorkomen door vaste diagramafmetingen af te stemmen op het OLE‑frame.

In [Maak Excel-diagrammen en embed ze als OLE-objecten in presentaties](/slides/nl/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), hebben we uitgelegd hoe u een Excel-diagram maakt met Aspose.Cells for Android via Java en het in een PowerPoint‑presentatie embed met Aspose.Slides for Android via Java. Om het [objectvoorvertoningsprobleem](/slides/nl/androidjava/object-preview-issue-when-adding-oleobjectframe/) aan te pakken, hebben we de diagramafbeelding toegewezen aan het OLE‑objectframe van het diagram. In de gegenereerde presentatie, wanneer u dubbelklikt op het OLE‑objectframe dat de diagramafbeelding toont, wordt het Excel-diagram geactiveerd. Gebruikers kunnen de ingebedde Excel‑werkmap bewerken en vervolgens terugkeren naar de dia door buiten de geactiveerde werkmap te klikken. De grootte van het OLE‑objectframe verandert wanneer de gebruiker terugkeert naar de dia, en de wijzigingsfactor varieert afhankelijk van de oorspronkelijke afmetingen van zowel het OLE‑objectframe als de ingebedde Excel‑werkmap.

## **Oorzaak van de grootteverandering**

De ingebedde Excel‑werkmap heeft zijn eigen venstergrootte, die Excel probeert te behouden wanneer het object voor het eerst wordt geactiveerd. Het OLE‑frame op de dia heeft onafhankelijk gedefinieerde afmetingen. Wanneer de Excel‑werkmap wordt geactiveerd, onderhandelen Excel en PowerPoint over de grootte van het object om de verhoudingen te behouden als onderdeel van het embedproces. Verschillen tussen het werkmapvenster en het OLE‑frame kunnen daardoor het object van grootte laten veranderen.

## **Werkende oplossing**

Stem de diagramgrootte af op het OLE‑frame op de dia en houd de diagramafmetingen onafhankelijk van het werkmapvenster. Deze oplossing werkt met een nieuwe presentatie of een bestaand sjabloon.

Het voorbeeld vereist Aspose.Cells for Android via Java en Aspose.Slides for Android via Java. Het maakt een eenvoudig kolomdiagram op een actueel diagramblad en embedde de werkmap in XLS-formaat. Roep `FixedChartSize.createPresentation(getFilesDir())` aan vanuit een Android‑activiteit om de output op te slaan in de interne bestandsmap van de applicatie. OLE‑activering vereist desktop‑PowerPoint en een compatibele Excel‑installatie. Er wordt geen voorvertoningsafbeelding van het diagram toegewezen; het diagram wordt zichtbaar wanneer het OLE‑object in PowerPoint wordt geactiveerd.

Het voorbeeld maakt een nieuwe presentatie met een OLE‑frame van 9,5 × 4 inch, geplaatst 0,5 inch van de linkerkant en 1 inch van de bovenkant. Dia‑coördinaten en -afmetingen zijn in punten (72 punten per inch). Voor een bestaande presentatie, zie [Gebruik een sjabloon](#use-a-template).

## **Stel een vaste diagramgrootte in**

Stel [setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) in op false zodat de diagramafmetingen onafhankelijk zijn van het werkmapvenster. Stel de afmetingen van [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) in via [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) en [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-), waarbij punten worden omgezet naar pixels met 96 pixels per inch: een frame van 684 × 288 punten komt overeen met een diagram van 912 × 384 pixels. Stel [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) in op de AANGEPASTE waarde van [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/). Het voorbeeld embedde de werkmap met [addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) en slaat een presentatie op met een OLE‑frame van 9,5 × 4 inch.

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
import java.io.File;

public class FixedChartSize {
    public static void createPresentation(File filesDirectory) {
        try {
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

                    // Dia‑coördinaten en afmetingen zijn in punten (72 punten per inch).
                    float width = 684f; // 9,5 inch.
                    float height = 288f; // 4 inch.

                    chart.setSizeWithWindow(false);
                    // Zet punten om naar diagrampixels met 96 pixels per inch.
                    chart.getChartObject().setWidth((int)(width / 72f * 96f));
                    chart.getChartObject().setHeight((int)(height / 72f * 96f));
                    chart.setPrintSize(PrintSizeType.CUSTOM);

                    ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
                    workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
                    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
                    slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

                    File outputFile = new File(filesDirectory, "chart-fixed-size.pptx");
                    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
                } finally {
                    presentation.dispose();
                }
            } finally {
                workbook.dispose();
            }
        } catch (Exception exception) {
            System.err.println("Unable to create the presentation: " + exception.getMessage());
        }
    }
}
```

## **Gebruik een sjabloon**

De logica voor de afmetingen is dezelfde voor een bestaande presentatie. Om het voorbeeld aan te passen:

1. Laad de sjabloonpresentatie in plaats van een lege presentatie te maken.
1. Controleer of de eerste dia minstens drie vormen bevat, en gebruik vervolgens de vorm op index 2 als tijdelijke aanduiding.
1. Neem de framebreedte en -hoogte van die vorm in plaats van de vaste waarden 684 en 288 te gebruiken. Houd de berekeningen voor de afmetingen ongewijzigd.
1. Voeg het OLE‑frame toe op de positie van de tijdelijke aanduiding in plaats van de vaste coördinaten 36 en 72.
1. Verwijder de tijdelijke aanduiding voordat u de presentatie opslaat.

## **FAQ**

**Waarom verandert mijn ingebedde Excel-diagram van grootte nadat het in PowerPoint is geactiveerd?**

Dit gebeurt omdat Excel bij de eerste activering probeert de oorspronkelijke venstergrootte te herstellen, terwijl het OLE‑objectframe in PowerPoint zijn eigen afmetingen heeft. PowerPoint en Excel onderhandelen over de grootte om de beeldverhouding te behouden, wat de wijziging kan veroorzaken.

**Hoe kan ik de diagram‑ en OLE‑frame‑groottes consistent houden?**

Stel vaste diagramafmetingen in die overeenkomen met het OLE‑frame en gebruik een aangepaste afdrukgrootte voor het diagram vóór het embedden van de werkmap. Het bovenstaande voorbeeld toont de benodigde instellingen en eenhedenomzettingen.

**Is het afstemmen van de werkmap‑venstergrootte voldoende?**

Het alleen afstemmen van de werkmap‑venstergrootte voorkomt niet betrouwbaar dat het OLE‑frame na activering van grootte verandert. Gebruik vaste diagramafmetingen zoals getoond in het voorbeeld.

**Werkt deze oplossing zowel voor sjabloon‑gebaseerde presentaties als voor nieuwe presentaties?**

Ja. Voor een sjabloon gebruikt u de afmetingen en positie van de tijdelijke aanduiding. Voor een nieuwe presentatie geeft u de frame‑afmetingen en -positie direct op.

**Kan ik dit voorbeeld gebruiken met diagrammen die in andere spreadsheet‑programma’s zijn gemaakt?**

Het voorbeeld maakt gebruik van een Excel‑werkmap die is gemaakt met Aspose.Cells. Het laat geen activatie‑gedrag zien voor andere spreadsheet‑programma’s.

## **Gerelateerde secties**

- [Maak Excel-diagrammen en embed ze als OLE-objecten in presentaties](/slides/nl/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)