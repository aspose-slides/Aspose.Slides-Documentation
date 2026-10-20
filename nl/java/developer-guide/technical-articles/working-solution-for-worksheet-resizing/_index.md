---
title: Werkende oplossing voor het aanpassen van werkbladen
type: docs
weight: 20
url: /nl/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- voorbeeldafbeelding
- afbeeldingsgrootte-aanpassing
- Excel
- werkblad
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Los het OLE-grootteprobleem van Excel-werkbladen op in presentaties: twee manieren om objectframes consistent te houden—het frame of het werkblad schalen—over de PPT- en PPTX-formaten."
---
{{% alert color="info" title="Note" %}}

Excel-werkbladen die als OLE-objecten in een PowerPoint‑presentatie zijn ingebed met Aspose‑componenten kunnen onverwacht van grootte veranderen na hun eerste activering. Dit gedrag veroorzaakt een opvallend visueel verschil tussen het OLE‑object vóór en na de activering. Dit artikel legt het probleem uit en beschrijft twee manieren om het op te lossen.

{{% /alert %}}

## **Achtergrond**

In het artikel [Beheer OLE](/slides/nl/java/manage-ole/), legden we uit hoe je een OLE‑frame aan een PowerPoint‑presentatie kunt toevoegen met Aspose.Slides for Java. Om het [probleem met voorbeeldweergave van object](/slides/nl/java/object-preview-issue-when-adding-oleobjectframe/) aan te pakken, hebben we een afbeelding van het geselecteerde werkbladgebied aan het OLE‑objectframe toegekend. In de gegenereerde presentatie, wanneer je dubbelklikt op het OLE‑objectframe dat de werkbladafbeelding weergeeft, wordt de Excel‑werkmap geactiveerd. Eindgebruikers kunnen gewenste wijzigingen aanbrengen in de werkelijke Excel‑werkmap en vervolgens terugkeren naar de dia door buiten de geactiveerde Excel‑werkmap te klikken. De grootte van het OLE‑objectframe zal veranderen wanneer de gebruiker terugkeert naar de dia. De factor van de grootteaanpassing varieert afhankelijk van de grootte van het OLE‑objectframe en de ingebedde Excel‑werkmap.

## **Oorzaak van de grootteaanpassing**

Aangezien de Excel‑werkmap een eigen venstergrootte heeft, probeert deze bij de eerste activering de oorspronkelijke grootte te behouden. Aan de andere kant heeft het OLE‑objectframe een eigen afmeting. Volgens Microsoft onderhandelen Excel en PowerPoint, wanneer de Excel‑werkmap wordt geactiveerd, over de grootte om ervoor te zorgen dat de correcte verhoudingen behouden blijven als onderdeel van het insluitingsproces. De grootteaanpassing ontstaat op basis van de verschillen tussen de Excel‑venstergrootte en de afmetingen en positie van het OLE‑objectframe.

## **Werkende oplossing**

Er zijn twee mogelijke oplossingen om het effect van de grootteaanpassing te voorkomen.

- Schaal het OLE‑frame in de PowerPoint‑presentatie zodat het overeenkomt met de totale hoogte en breedte van de geselecteerde rijen en kolommen.
- Houd de grootte van het OLE‑frame constant en schaal de geselecteerde rijen en kolommen zodat ze erin passen.

### **Schaal de OLE‑framegrootte**

Deze aanpak stelt de grootte van het OLE‑frame in zodat deze overeenkomt met de totale hoogte en breedte van de geselecteerde rijen en kolommen in het ingebedde Excel‑werkblad.

Het voorbeeld laadt een bestaande Excel‑werkmap en selecteert de eerste 10 rijen en 13 kolommen van het eerste werkblad met behulp van nul‑gebaseerde indexen. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) definieert het weergegeven bereik. De preview wordt gerenderd op 96 DPI, en de pixelafmetingen worden omgezet naar punten met 72 punten per inch. [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) embedt de aangepaste werkmap in een frame met die afmetingen. De preview wordt toegewezen via [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) om de tijdelijke aanduiding "EMBEDDED OLE OBJECT" in de opgeslagen presentatie te vervangen.

```java
import com.aspose.slides.*;
import java.awt.Image;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import javax.imageio.ImageIO;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Stel de weergegeven grootte in wanneer het werkboekbestand wordt gebruikt als OLE-object in PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// We moeten het gewijzigde werkboek gebruiken.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Voeg de OLE-afbeelding toe aan de presentatieresources.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Maak het OLE-objectframe.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

De preview‑helper stelt [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) in op het geselecteerde bereik en verwijdert marges, kopteksten en voetteksten. Met [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-) ingeschakeld, rendert [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) het bereik als een PNG‑afbeelding. De helper retourneert een nieuwe inputstream die de PNG‑afbeelding bevat, gepositioneerd aan het begin voor gebruik in de presentatie.

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

Het voorbeeld laadt een bestaande Excel‑werkmap en selecteert de eerste 10 rijen en 13 kolommen van het eerste werkblad met behulp van nul‑gebaseerde indexen. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) definieert het weergegeven bereik, en de onderstaande helper schaalt dat bereik zodat het in een frame van 400 punten breed en 100 punten hoog past. Na het opslaan van de aangepaste werkmap naar een stream, embedt [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) deze op de opgegeven grootte. Een preview die op 96 DPI is gerenderd, wordt toegewezen via [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--), zodat de opgeslagen presentatie de geselecteerde cellen toont in plaats van de standaard tijdelijke aanduiding.

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

// We moeten het gewijzigde werkboek gebruiken.
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

De schaalhelper berekent afzonderlijke breedte‑ en hoogteverhoudingen voor het geselecteerde bereik, waarbij de relatieve breedtes van de kolommen en de relatieve hoogtes van de rijen behouden blijven. Het converteert de berekende afmetingen van punten naar inches voordat ze worden toegepast met [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) en [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-). Het geselecteerde bereik moet een niet‑nul breedte en hoogte hebben.

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

Deze preview‑helper rendert het geschaalde bereik met behulp van [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-). Het beperkt [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) tot dat bereik, verwijdert marges, kopteksten en voetteksten, en retourneert een PNG‑stream die aan het begin gepositioneerd is.

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

{{% alert color="info" title="Note" %}}

Er zijn twee benaderingen om het probleem met de grootteaanpassing van het werkblad op te lossen. Kies de aanpak die het beste bij uw eisen en gebruikssituatie past. Beide benaderingen werken op dezelfde manier, of de presentaties nu vanuit een sjabloon of vanaf nul worden aangemaakt. Bovendien is er geen limiet aan de grootte van het OLE‑objectframe in deze oplossing.

{{% /alert %}}

## **Veelgestelde vragen**

**Waarom verandert een ingebed Excel‑werkblad van grootte wanneer het voor het eerst wordt geactiveerd in PowerPoint?**

Dit gebeurt omdat Excel probeert de oorspronkelijke venstergrootte te behouden bij activering, terwijl het OLE‑objectframe in PowerPoint zijn eigen afmetingen heeft. PowerPoint en Excel onderhandelen over de grootte om de beeldverhouding te behouden, wat de grootteaanpassing kan veroorzaken.

**Is het mogelijk om dit grootteaanpassingsprobleem volledig te voorkomen?**

Ja. Door het OLE‑frame te schalen zodat het past bij de grootte van het Excel‑celbereik of door het celbereik te schalen zodat het past bij de gewenste OLE‑framegrootte, kun je ongewenste grootteaanpassingen voorkomen.

**Welke schaalmethode moet ik gebruiken, OLE‑frame schalen of celbereik schalen?**

Kies **OLE‑frame schalen** als je de oorspronkelijke rijen‑ en kolomgroottes van Excel wilt behouden. Kies **celbereik schalen** als je een vaste grootte voor het OLE‑frame in je presentatie wilt.

**Werken deze oplossingen als mijn presentatie gebaseerd is op een sjabloon?**

Ja. Beide oplossingen werken voor presentaties die vanuit sjablonen zijn gemaakt en voor presentaties die vanaf nul zijn aangemaakt.

**Is er een limiet aan de grootte van het OLE‑frame bij het gebruik van deze methoden?**

Nee. Je kunt het OLE‑objectframe elke gewenste grootte geven, zolang je de schaal correct instelt.

**Is er een manier om de tijdelijke aanduiding "EMBEDDED OLE OBJECT" in PowerPoint te vermijden?**

Ja. Door een momentopname van het gewenste Excel‑celbereik te maken en deze in te stellen als de tijdelijke afbeelding van het OLE‑frame, kun je een aangepaste preview‑afbeelding tonen in plaats van de standaard tijdelijke aanduiding.

## **Gerelateerde artikelen**

[Een Excel‑diagram maken en insluiten in een presentatie als OLE‑object](/slides/nl/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[OLE‑objecten automatisch bijwerken met een MS PowerPoint‑add‑in](/slides/nl/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)