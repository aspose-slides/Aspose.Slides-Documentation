---
title: Werkende oplossing voor werkbladgrootte‑aanpassing
type: docs
weight: 20
url: /nl/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- voorbeeldafbeelding
- afbeeldingsgrootte wijzigen
- Excel
- werkblad
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Los het OLE-grootte‑aanpassingsprobleem van Excel-werkbladen in presentaties op: twee manieren om objectframes consistent te houden — schaal het frame of het blad — over de PPT‑ en PPTX‑formaten."
---
{{% alert color="info" title="Opmerking" %}}

Excel‑werkbladen die als OLE‑objecten in een PowerPoint‑presentatie zijn ingebed met behulp van Aspose‑componenten, kunnen onverwacht van grootte veranderen na hun eerste activering. Dit gedrag veroorzaakt een opvallend visueel verschil tussen het OLE‑object vóór en na de activering. Dit artikel legt het probleem uit en beschrijft twee manieren om het op te lossen.

{{% /alert %}}

## **Achtergrond**

In het artikel [Manage OLE](/slides/nl/androidjava/manage-ole/) legden we uit hoe een OLE‑frame aan een PowerPoint‑presentatie kan worden toegevoegd met Aspose.Slides voor Android via Java. Om het [object preview issue](/slides/nl/androidjava/object-preview-issue-when-adding-oleobjectframe/) aan te pakken, hebben we een afbeelding van het geselecteerde werkbladgebied aan het OLE‑objectframe toegewezen. In de resulterende presentatie wordt, wanneer je dubbelklikt op het OLE‑objectframe dat de werkbladafbeelding toont, de Excel‑werkmap geactiveerd. Eindgebruikers kunnen gewenste wijzigingen aanbrengen in de daadwerkelijke Excel‑werkmap en vervolgens terugkeren naar de dia door buiten de geactiveerde werkmap te klikken. De grootte van het OLE‑objectframe verandert wanneer de gebruiker terugkeert naar de dia. De factor van de grootte‑aanpassing varieert afhankelijk van de grootte van het OLE‑objectframe en de ingebedde Excel‑werkmap.

## **Oorzaak van het formaat wijzigen**

Aangezien de Excel‑werkmap zijn eigen venstergrootte heeft, probeert deze bij de eerste activering zijn oorspronkelijke grootte te behouden. Aan de andere kant heeft het OLE‑objectframe zijn eigen afmetingen. Volgens Microsoft, wanneer de Excel‑werkmap wordt geactiveerd, onderhandelen Excel en PowerPoint over de grootte om ervoor te zorgen dat de juiste verhoudingen behouden blijven als onderdeel van het insluitingsproces. De aanpassing gebeurt op basis van de verschillen tussen de Excel‑venstergrootte en de grootte en positie van het OLE‑objectframe.

## **Werkende oplossing**

Er zijn twee mogelijke oplossingen om het formaat‑wijzigingseffect te voorkomen.

- Schaal het OLE‑frame in de PowerPoint‑presentatie zodat het overeenkomt met de totale hoogte en breedte van de geselecteerde rijen en kolommen.
- Houd de OLE‑framegrootte constant en schaal de geselecteerde rijen en kolommen zodat ze erin passen.

### **Schaal de OLE‑framegrootte**

Deze aanpak stelt de OLE‑framegrootte in zodat deze overeenkomt met de totale hoogte en breedte van de geselecteerde rijen en kolommen in het ingebedde Excel‑werkblad.

Het voorbeeld laadt een bestaande Excel‑werkmap en selecteert de eerste 10 rijen en 13 kolommen van het eerste werkblad met nul‑gebaseerde indexen. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) definieert het weergegeven bereik. De preview wordt gerenderd op 96 DPI en de pixelafmetingen worden omgezet naar punten met 72 punten per inch. [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) embedde de aangepaste werkmap in een frame met die afmetingen. De preview wordt toegewezen via [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) om de “EMBEDDED OLE OBJECT”‑plaatsvervanger in de opgeslagen presentatie te vervangen.

```java
import com.aspose.slides.*;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Set the displayed size when the workbook file is used as an OLE object in PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

// We need to use the modified workbook.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Add the OLE image to the presentation resources.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Create the OLE object frame.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

De preview‑helper stelt [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) in op het geselecteerde bereik en verwijdert marges, kopteksten en voetteksten. Met [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-) ingeschakeld, rendert [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) het bereik als een PNG‑afbeelding. De helper retourneert een nieuwe invoerstroom die de PNG‑afbeelding bevat, gepositioneerd aan het begin voor gebruik in de presentatie.

```java
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

### **Schaal de celbereikgrootte**

Deze aanpak schaalt de hoogtes van de geselecteerde rijen en de breedtes van de geselecteerde kolommen zodat ze overeenkomen met een aangepaste OLE‑framegrootte.

Het voorbeeld laadt een bestaande Excel‑werkmap en selecteert de eerste 10 rijen en 13 kolommen van het eerste werkblad met nul‑gebaseerde indexen. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) definieert het weergegeven bereik, en de helper hieronder schaalt dat bereik zodat het in een frame van 400 punten breed en 100 punten hoog past. Na het opslaan van de aangepaste werkmap naar een stroom, embedde [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) deze op de opgegeven grootte. Een preview gerenderd op 96 DPI wordt toegewezen via [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) zodat de opgeslagen presentatie de geselecteerde cellen weergeeft in plaats van de standaardplaatsvervanger.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Stel de weergegeven grootte in wanneer het werkboekbestand wordt gebruikt als OLE-object in PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Schaal het celbereik zodat het in de framegrootte past.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// We moeten het aangepaste werkboek gebruiken.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Voeg de OLE-afbeelding toe aan de presentatieresources.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Maak het OLE-objectframe.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

De schaal‑helper berekent afzonderlijke breedte‑ en hoogteratio’s voor het geselecteerde bereik, waardoor de relatieve breedtes van de kolommen en de relatieve hoogtes van de rijen behouden blijven. De berekende dimensies worden van punten naar inches omgezet voordat ze worden toegepast met [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) en [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-). Het geselecteerde bereik moet een niet‑nul breedte en hoogte hebben.

```java
/**
 * @param width     De verwachte breedte van het celbereik in punten.
 * @param height    De verwachte hoogte van het celbereik in punten.
 */
static void ScaleCellRange(com.aspose.cells.Range cellRange, float width, float height) {
    double rangeWidth = cellRange.getWidth();
    double rangeHeight = cellRange.getHeight();

    for (int i = 0; i < cellRange.getColumnCount(); i++) {
        int columnIndex = cellRange.getFirstColumn() + i;
        double columnWidth = cellRange.getWorksheet()
                .getCells()
                .getColumnWidth(columnIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newColumnWidth = columnWidth * width / rangeWidth;
        double widthInInches = newColumnWidth / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.getRowCount(); i++) {
        int rowIndex = cellRange.getFirstRow() + i;
        double rowHeight = cellRange.getWorksheet()
                .getCells()
                .getRowHeight(rowIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newRowHeight = rowHeight * height / rangeHeight;
        double heightInInches = newRowHeight / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setRowHeightInch(rowIndex, heightInInches);
    }
}
```

Deze preview‑helper rendert het gewijzigde bereik met [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-). Hij beperkt [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) tot dat bereik, verwijdert marges, kopteksten en voetteksten, en retourneert een PNG‑stroom die aan het begin is gepositioneerd.

```java
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

## **Conclusie**

{{% alert color="info" title="Opmerking" %}}

Er zijn twee benaderingen om het probleem met de grootte‑aanpassing van het werkblad op te lossen. Kies de benadering die het beste past bij uw vereisten en gebruiksscenario. Beide benaderingen werken op dezelfde manier, of de presentaties nu vanuit een sjabloon of vanaf nul worden gemaakt. Bovendien is er geen limiet aan de grootte van het OLE‑objectframe in deze oplossing.

{{% /alert %}}

## **Veelgestelde vragen**

**Waarom verandert een ingebed Excel‑werkblad van grootte bij de eerste activering in PowerPoint?**

Dit gebeurt omdat Excel probeert de oorspronkelijke venstergrootte te behouden bij activatie, terwijl het OLE‑objectframe in PowerPoint zijn eigen afmetingen heeft. PowerPoint en Excel onderhandelen over de grootte om de beeldverhouding te behouden, wat de resizing kan veroorzaken.

**Is het mogelijk om dit resizing‑probleem volledig te voorkomen?**

Ja. Door het OLE‑frame te schalen zodat het past bij de grootte van het Excel‑celbereik, of door het celbereik te schalen zodat het past binnen de gewenste OLE‑framegrootte, kun je ongewenste grootte‑aanpassingen voorkomen.

**Welke schaal‑methode moet ik gebruiken, OLE‑frame schalen of celbereik schalen?**

Kies **OLE‑frame schalen** als je de oorspronkelijke Excel‑rij‑ en kolomgroottes wilt behouden. Kies **celbereik schalen** als je een vaste grootte voor het OLE‑frame in je presentatie wilt.

**Werken deze oplossingen als mijn presentatie gebaseerd is op een sjabloon?**

Ja. Beide oplossingen werken voor presentaties die zijn gemaakt vanuit sjablonen en voor presentaties die vanaf nul zijn opgebouwd.

**Is er een limiet aan de grootte van het OLE‑frame bij gebruik van deze methoden?**

Nee. Je kunt het OLE‑objectframe elke gewenste grootte geven, zolang je de schaal correct instelt.

**Is er een manier om de “EMBEDDED OLE OBJECT”‑plaatsvervangertekst in PowerPoint te vermijden?**

Ja. Door een snapshot van het doel‑Excel‑celbereik te maken en deze in te stellen als de placeholder‑afbeelding van het OLE‑frame, kun je een aangepast preview‑beeld weergeven in plaats van de standaardplaatsvervanger.

## **Gerelateerde artikelen**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/nl/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/nl/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)