---
title: Werkende oplossing voor het schalen van werkbladen
type: docs
weight: 20
url: /nl/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- voorbeeldafbeelding
- afbeeldingsschaling
- Excel
- werkblad
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Los het OLE-schalen van Excel-werkbladen op in presentaties: twee manieren om objectkaders consistent te houden - schaal het kader of het blad - over de PPT- en PPTX-formaten."
---
{{% alert color="primary" %}}

Er is geconstateerd dat Excel-werkbladen die als OLE-objecten in een PowerPoint‑presentatie via Aspose‑componenten zijn ingebed, na de eerste activering worden geschaald naar een onbekende grootte. Dit gedrag veroorzaakt een merkbaar visueel verschil in de presentatie tussen de vóór‑ en na‑activeringsstatus van het OLE‑object. We hebben dit probleem grondig onderzocht en een oplossing aangeboden, die in dit artikel wordt behandeld.

{{% /alert %}}

## **Achtergrond**

In het artikel [Manage OLE](/slides/nl/java/manage-ole/) legden we uit hoe je een OLE‑kader toevoegt aan een PowerPoint‑presentatie met Aspose.Slides for Java. Om het [object preview issue](/slides/nl/java/object-preview-issue-when-adding-oleobjectframe/) op te lossen, koppelden we een afbeelding van het geselecteerde werkbladgebied aan het OLE‑kader. In de uitvoer‑presentatie, wanneer je dubbelklikt op het OLE‑kader dat de werkbladafbeelding weergeeft, wordt de Excel‑werkmap geactiveerd. Eindgebruikers kunnen gewenste aanpassingen maken in de werkelijke Excel‑werkmap en vervolgens terugkeren naar de dia door buiten de geactiveerde Excel‑werkmap te klikken. De grootte van het OLE‑kader zal veranderen wanneer de gebruiker terugkeert naar de dia. De schaalfactor varieert afhankelijk van de grootte van het OLE‑kader en de ingebedde Excel‑werkmap.

## **Oorzaak van het schalen**

Aangezien de Excel‑werkmap zijn eigen venstergrootte heeft, probeert hij bij de eerste activering zijn oorspronkelijke grootte te behouden. Het OLE‑kader heeft daarentegen zijn eigen afmetingen. Volgens Microsoft, wanneer de Excel‑werkmap wordt geactiveerd, onderhandelen Excel en PowerPoint over de grootte om ervoor te zorgen dat de juiste verhoudingen behouden blijven als onderdeel van het embedproces. Het schalen gebeurt op basis van de verschillen tussen de Excel‑venstergrootte en de grootte en positie van het OLE‑kader.

## **Werkende oplossing**

Er zijn twee mogelijke oplossingen om het schaleffect te vermijden.

- Schaal de OLE‑kadergrootte in de PowerPoint‑presentatie zodat deze overeenkomt met de hoogte en breedte van het gewenste aantal rijen en kolommen in het OLE‑kader.
- Houd de OLE‑kadergrootte constant en schaal de grootte van de deelnemende rijen en kolommen zodat ze binnen de gekozen OLE‑kadergrootte passen.

### **Schalen van de OLE‑kadergrootte**

In deze aanpak leren we hoe we de OLE‑kadergrootte van de ingebedde Excel‑werkmap instellen zodat deze overeenkomt met de cumulatieve grootte van de deelnemende rijen en kolommen in het Excel‑werkblad.

Stel dat we een sjabloon‑Excel‑blad hebben en dit willen toevoegen aan een presentatie als OLE‑kader. In dit scenario wordt de grootte van het OLE‑objectkader eerst berekend op basis van de cumulatieve rijhoogtes en kolombreedtes van de deelnemende rijen en kolommen in de werkmap. Vervolgens stellen we de grootte van het OLE‑kader in op deze berekende waarde. Om de rode “EMBEDDED OLE OBJECT”‑melding voor het OLE‑kader in PowerPoint te vermijden, zullen we ook een afbeelding vastleggen van de gewenste delen van de rijen en kolommen in de werkmap en deze als OLE‑kaderafbeelding instellen.

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Stel de weergegeven grootte in wanneer het werkboekbestand wordt gebruikt als OLE‑object in PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Haal de breedte en hoogte van de OLE‑afbeelding op in punten.
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// We moeten het gewijzigde werkboek gebruiken.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Voeg de OLE‑afbeelding toe aan de presentatiemiddelen.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Maak het OLE‑objectkader.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
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

### **Schalen van het bereik van cellen**

In deze aanpak leren we hoe we de hoogtes van de deelnemende rijen en de breedtes van de deelnemende kolommen schalen zodat ze overeenkomen met een aangepaste OLE‑kadergrootte.

Stel dat we een sjabloon‑Excel‑blad hebben en dit willen toevoegen aan een presentatie als OLE‑kader. In dit scenario stellen we de grootte van het OLE‑kader in en schalen we de grootte van de rijen en kolommen die deelnemen aan het OLE‑kadergebied. Vervolgens slaan we de werkmap op naar een stream om de wijzigingen toe te passen en zetten we deze om naar een byte‑array om toe te voegen aan het OLE‑kader. Om de rode “EMBEDDED OLE OBJECT”‑melding voor het OLE‑kader in PowerPoint te vermijden, zullen we ook een afbeelding vastleggen van de gewenste delen van de rijen en kolommen in de werkmap en deze als OLE‑kaderafbeelding instellen.

```java
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

// Schaal het celbereik om te passen in de kadergrootte.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// We moeten het gewijzigde werkboek gebruiken.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Voeg de OLE-afbeelding toe aan de presentatiemiddelen.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Maak het OLE-objectkader.
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

{{% alert color="primary" %}} 

Er zijn twee benaderingen om het schalen van het werkblad op te lossen. De keuze voor de juiste benadering hangt af van de specifieke eisen en het gebruiksscenario. Beide benaderingen werken op dezelfde manier, of de presentaties nu vanuit een sjabloon of vanaf nul worden gemaakt. Bovendien is er geen limiet aan de grootte van het OLE‑objectkader in deze oplossing.

{{% /alert %}}

## **FAQ**

**Waarom verandert een ingebed Excel‑werkblad van grootte wanneer het voor het eerst wordt geactiveerd in PowerPoint?**

Dit gebeurt omdat Excel probeert de oorspronkelijke venstergrootte te behouden bij activering, terwijl het OLE‑objectkader in PowerPoint zijn eigen afmetingen heeft. PowerPoint en Excel onderhandelen over de grootte om de beeldverhouding te behouden, wat kan leiden tot schalen.

**Is het mogelijk dit schaleffect volledig te voorkomen?**

Ja. Door het OLE‑kader te schalen naar de grootte van het Excel‑celbereik of door het celbereik te schalen naar de gewenste OLE‑kadergrootte, kun je ongewenst schalen voorkomen.

**Welke schaalmethode moet ik gebruiken, OLE‑kader schalen of celbereik schalen?**

Kies **OLE‑kader schalen** als je de oorspronkelijke Excel‑rij‑ en kolomgroottes wilt behouden. Kies **celbereik schalen** als je een vaste grootte voor het OLE‑kader in je presentatie wilt.

**Werken deze oplossingen ook als mijn presentatie gebaseerd is op een sjabloon?**

Ja. Beide oplossingen werken voor presentaties die vanuit sjablonen of vanaf nul zijn gemaakt.

**Is er een limiet aan de grootte van het OLE‑kader bij gebruik van deze methoden?**

Nee. Je kunt het OLE‑objectkader op elke gewenste grootte instellen, zolang je de schaal correct aanpast.

**Is er een manier om de “EMBEDDED OLE OBJECT”‑tekstplaceholder in PowerPoint te vermijden?**

Ja. Door een snapshot te maken van het doel‑Excel‑celbereik en deze in te stellen als de placeholder‑afbeelding van het OLE‑kader, kun je een aangepaste voorbeeldafbeelding weergeven in plaats van de standaardplaceholder.

## **Gerelateerde artikelen**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/nl/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/nl/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)