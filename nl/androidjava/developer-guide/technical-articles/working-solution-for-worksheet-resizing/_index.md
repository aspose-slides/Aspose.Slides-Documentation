---
title: Werkende oplossing voor werkbladschaling
type: docs
weight: 20
url: /nl/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- voorbeeldafbeelding
- afbeeldingsgrootte aanpassen
- Excel
- werkblad
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Los Excel-werkblad OLE-schaling op in presentaties: twee manieren om objectframes consistent te houden—schalen van het frame of van het blad—over de PPT- en PPTX-formaten."
---
{{% alert color="info" %}}

Er is geconstateerd dat Excel‑werkbladen die als OLE‑objecten in een PowerPoint‑presentatie via Aspose‑componenten zijn ingebed, na de eerste activatie worden geschaald naar een onbekende schaal. Dit gedrag veroorzaakt een opvallend visueel verschil in de presentatie tussen de pre‑ en post‑activatiestatus van het OLE‑object. We hebben dit probleem uitvoerig onderzocht en een oplossing geboden, die in dit artikel wordt behandeld.

{{% /alert %}}

## **Achtergrond**

In het artikel [Beheer OLE](/slides/nl/androidjava/manage-ole/) legden we uit hoe je een OLE‑frame toevoegt aan een PowerPoint‑presentatie met Aspose.Slides voor Android via Java. Om het [object preview issue](/slides/nl/androidjava/object-preview-issue-when-adding-oleobjectframe/) op te lossen, hebben we een afbeelding van het geselecteerde werkbladgebied toegewezen aan het OLE‑objectframe. In de uiteindelijke presentatie, wanneer je dubbelklikt op het OLE‑objectframe dat de werkbladafbeelding toont, wordt de Excel‑werkmap geactiveerd. Eindgebruikers kunnen gewenste wijzigingen aanbrengen in de werkelijke Excel‑werkmap en vervolgens terugkeren naar de dia door buiten de geactiveerde Excel‑werkmap te klikken. De grootte van het OLE‑objectframe verandert wanneer de gebruiker terugkeert naar de dia. De schaalfactor varieert afhankelijk van de grootte van het OLE‑objectframe en de ingebedde Excel‑werkmap.

## **Oorzaak van het schalen**

Aangezien de Excel‑werkmap zijn eigen venstergrootte heeft, probeert hij bij de eerste activatie zijn oorspronkelijke grootte te behouden. Aan de andere kant heeft het OLE‑objectframe zijn eigen afmetingen. Volgens Microsoft onderhandelen Excel en PowerPoint over de grootte wanneer de Excel‑werkmap wordt geactiveerd, zodat de verhoudingen tijdens het insluitproces correct blijven. Het schalen gebeurt op basis van de verschillen tussen de Excel‑venstergrootte en de grootte en positie van het OLE‑objectframe.

## **Werkende oplossing**

Er zijn twee mogelijke oplossingen om het schaal effect te vermijden.

- Schaal de OLE‑framegrootte in de PowerPoint‑presentatie zodat deze overeenkomt met de hoogte en breedte van het gewenste aantal rijen en kolommen in het OLE‑frame.
- Houd de OLE‑framegrootte constant en schaal de grootte van de deelnemende rijen en kolommen zodat ze binnen de gekozen OLE‑framegrootte passen.

### **Schaal de OLE‑framegrootte**

In deze aanpak leren we hoe we de OLE‑framegrootte van de ingebedde Excel‑werkmap instellen zodat deze overeenkomt met de cumulatieve grootte van de deelnemende rijen en kolommen in het Excel‑werkblad.

Stel dat we een sjabloon‑Excel‑blad hebben en dit willen toevoegen aan een presentatie als OLE‑frame. In dit scenario wordt de grootte van het OLE‑objectframe eerst berekend op basis van de cumulatieve rijhoogtes en kolombreedtes van de deelnemende rijen en kolommen in de werkmap. Vervolgens stellen we de grootte van het OLE‑frame in op deze berekende waarde. Om het rode “EMBEDDED OLE OBJECT”‑bericht voor het OLE‑frame in PowerPoint te vermijden, leggen we ook een afbeelding vast van de gewenste delen van de rijen en kolommen in de werkmap en stellen deze in als OLE‑frame‑afbeelding.

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

// Stel de weergegeven grootte in wanneer het werkmapbestand wordt gebruikt als OLE-object in PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Haal de breedte en hoogte van de OLE-afbeelding op in punten.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

// We moeten de aangepaste werkmap gebruiken.
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

In deze aanpak leren we hoe we de hoogtes van de deelnemende rijen en de breedte van de deelnemende kolommen schalen zodat ze passen bij een aangepaste OLE‑framegrootte.

Stel dat we een sjabloon‑Excel‑blad hebben en dit willen toevoegen aan een presentatie als OLE‑frame. In dit scenario stellen we de grootte van het OLE‑frame in en schalen we de grootte van de rijen en kolommen die deelnemen aan het OLE‑frame‑gebied. Vervolgens slaan we de werkmap op in een stream om de wijzigingen toe te passen en converteren we deze naar een byte‑array om toe te voegen aan het OLE‑frame. Om het rode “EMBEDDED OLE OBJECT”‑bericht voor het OLE‑frame in PowerPoint te vermijden, leggen we ook een afbeelding vast van de gewenste delen van de rijen en kolommen in de werkmap en stellen deze in als OLE‑frame‑afbeelding.

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

// Stel de weergegeven grootte in wanneer het werkmapbestand wordt gebruikt als OLE-object in PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Schaal het celbereik zodat het past in de framegrootte.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// We moeten de aangepaste werkmap gebruiken.
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

{{% alert color="info" %}} 

Er zijn twee benaderingen om het schaalprobleem van het werkblad op te lossen. De keuze voor de juiste benadering hangt af van de specifieke eisen en het gebruiksscenario. Beide benaderingen werken op dezelfde manier, of de presentaties nu vanaf een sjabloon of vanaf nul worden gemaakt. Bovendien is er geen limiet op de grootte van het OLE‑objectframe in deze oplossing.

{{% /alert %}}

## **FAQ**

### Waarom verandert de grootte van een ingebed Excel‑werkblad bij de eerste activatie in PowerPoint?

Dit gebeurt omdat Excel probeert de oorspronkelijke venstergrootte te behouden bij activatie, terwijl het OLE‑objectframe in PowerPoint zijn eigen afmetingen heeft. PowerPoint en Excel onderhandelen over de grootte om de beeldverhouding te behouden, waardoor het schalen kan optreden.

### Is het mogelijk om dit schaalprobleem volledig te voorkomen?

Ja. Door het OLE‑frame te schalen naar de grootte van het Excel‑celbereik of door het celbereik te schalen naar de gewenste OLE‑framegrootte, kun je ongewenst schalen voorkomen.

### Welke schaalmethode moet ik gebruiken, OLE‑frame schalen of celbereik schalen?

Kies **OLE‑frame schalen** als je de oorspronkelijke grootte van Excel‑rijen en -kolommen wilt behouden. Kies **celbereik schalen** als je een vaste grootte voor het OLE‑frame in je presentatie wilt.

### Werken deze oplossingen ook als mijn presentatie gebaseerd is op een sjabloon?

Ja. Beide oplossingen werken voor presentaties die zijn gemaakt op basis van sjablonen en voor presentaties die vanaf nul zijn opgebouwd.

### Is er een limiet aan de grootte van het OLE‑frame bij het gebruik van deze methoden?

Nee. Je kunt het OLE‑objectframe zo groot maken als je wilt, zolang je de schaal correct instelt.

### Is er een manier om de “EMBEDDED OLE OBJECT”‑plaatsvervullende tekst in PowerPoint te vermijden?

Ja. Door een snapshot te maken van het doel‑Excel‑celbereik en deze in te stellen als de placeholder‑afbeelding van het OLE‑frame, kun je een aangepaste voorbeeldafbeelding tonen in plaats van de standaard placeholder.