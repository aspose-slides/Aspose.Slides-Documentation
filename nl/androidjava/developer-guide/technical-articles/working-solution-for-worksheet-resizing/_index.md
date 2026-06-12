---
title: Werkende oplossing voor het aanpassen van de grootte van werkbladen
type: docs
weight: 20
url: /nl/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- previewafbeelding
- afbeeldingsgrootte aanpassen
- Excel
- werkblad
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Los het OLE‑schalingprobleem van Excel‑werkbladen in presentaties op: twee methoden om objectframes consistent te houden—schaal het frame of het werkblad—over de PPT‑ en PPTX‑formaten."
---
{{% alert color="primary" %}}
Er is geconstateerd dat Excel‑werkbladen die als OLE‑objecten in een PowerPoint‑presentatie zijn ingebed via Aspose‑componenten, na de eerste activering worden geschaald naar een onbekende schaal. Dit gedrag leidt tot een duidelijk visueel verschil in de presentatie tussen de voor‑ en na‑activatiestatus van het OLE‑object. We hebben dit probleem uitgebreid onderzocht en een oplossing geboden, die in dit artikel wordt behandeld.
{{% /alert %}}

## **Achtergrond**

In het artikel [OLE beheren](/slides/nl/androidjava/manage-ole/) legden we uit hoe je een OLE‑frame aan een PowerPoint‑presentatie toevoegt met Aspose.Slides voor Android via Java. Om het [probleem met voorbeeldweergave van object](/slides/nl/androidjava/object-preview-issue-when-adding-oleobjectframe/) aan te pakken, hebben we een afbeelding van het geselecteerde werkbladgedeelte aan het OLE‑objectframe toegewezen. In de geproduceerde presentatie wordt, wanneer je dubbelklikt op het OLE‑objectframe dat de werkbladafbeelding toont, het Excel‑werkboek geactiveerd. Eindgebruikers kunnen gewenste wijzigingen aanbrengen in het daadwerkelijke Excel‑werkboek en vervolgens terugkeren naar de dia door buiten het geactiveerde Excel‑werkboek te klikken. De grootte van het OLE‑objectframe verandert wanneer de gebruiker terugkeert naar de dia. De schaalfactor varieert afhankelijk van de grootte van het OLE‑objectframe en het ingebedde Excel‑werkboek.

## **Oorzaak van de schaalverandering**

Aangezien het Excel‑werkboek zijn eigen venstergrootte heeft, probeert het bij de eerste activering zijn originele grootte te behouden. Het OLE‑objectframe heeft echter zijn eigen afmetingen. Volgens Microsoft, wanneer het Excel‑werkboek wordt geactiveerd, onderhandelen Excel en PowerPoint over de grootte om de juiste verhoudingen te behouden als onderdeel van het insluitingsproces. De schaalverandering ontstaat door de verschillen tussen de Excel‑venstergrootte en de grootte en positie van het OLE‑objectframe.

## **Werkende oplossing**

Er zijn twee mogelijke oplossingen om het schaalveranderingseffect te vermijden.

- Schaal de OLE‑framegrootte in de PowerPoint‑presentatie zodat deze overeenkomt met de hoogte en breedte van het gewenste aantal rijen en kolommen in het OLE‑frame.
- Houd de OLE‑framegrootte constant en schaal de grootte van de deelnemende rijen en kolommen zodat ze binnen de geselecteerde OLE‑framegrootte passen.

### **Schaal de OLE‑framegrootte**

In deze benadering leren we hoe we de OLE‑framegrootte van het ingebedde Excel‑werkboek instellen zodat deze overeenkomt met de cumulatieve grootte van de deelnemende rijen en kolommen in het Excel‑werkblad.

Stel dat we een sjabloon‑Excel‑blad hebben en dit willen toevoegen aan een presentatie als OLE‑frame. In dit scenario wordt de grootte van het OLE‑objectframe eerst berekend op basis van de cumulatieve rijhoogtes en kolombreedtes van de deelnemende rijen en kolommen in het werkboek. Vervolgens stellen we de grootte van het OLE‑frame in op deze berekende waarde. Om het rode “EMBEDDED OLE OBJECT”-bericht voor het OLE‑frame in PowerPoint te voorkomen, leggen we ook een afbeelding vast van de gewenste delen van de rijen en kolommen in het werkboek en stellen we deze in als OLE‑frame‑afbeelding.

```java
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
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// We moeten het aangepaste werkboek gebruiken.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Voeg de OLE-afbeelding toe aan de presentatieresources.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Maak het OLE-objectframe aan.
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

### **Schaal de grootte van het cellenbereik**

In deze benadering leren we hoe we de hoogtes van de deelnemende rijen en de breedtes van de deelnemende kolommen schalen zodat ze overeenkomen met een aangepaste OLE‑framegrootte.

Stel dat we een sjabloon‑Excel‑blad hebben en dit willen toevoegen aan een presentatie als OLE‑frame. In dit scenario stellen we de grootte van het OLE‑frame in en schalen we de grootte van de rijen en kolommen die deelnemen aan het OLE‑frame‑gebied. Vervolgens slaan we het werkboek op in een stream om de wijzigingen toe te passen en converteren we het naar een byte‑array om toe te voegen aan het OLE‑frame. Om het rode “EMBEDDED OLE OBJECT”-bericht voor het OLE‑frame in PowerPoint te vermijden, leggen we ook een afbeelding vast van de gewenste delen van de rijen en kolommen in het werkboek en stellen we deze in als OLE‑frame‑afbeelding.

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

// Scha… (the original comment line)
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
Er zijn twee benaderingen om het schaalprobleem van het werkblad op te lossen. De keuze voor de juiste benadering hangt af van de specifieke eisen en het gebruiksscenario. Beide benaderingen werken op dezelfde manier, ongeacht of de presentaties vanuit een sjabloon of vanaf nul worden aangemaakt. Bovendien is er geen limiet aan de grootte van het OLE‑objectframe in deze oplossing.
{{% /alert %}}

## **FAQ**

**Waarom verandert de grootte van een ingebed Excel‑werkblad bij de eerste activering in PowerPoint?**  
Dit gebeurt omdat Excel bij het activeren probeert de oorspronkelijke venstergrootte te behouden, terwijl het OLE‑objectframe in PowerPoint zijn eigen afmetingen heeft. PowerPoint en Excel onderhandelen over de grootte om de beeldverhouding te behouden, wat kan leiden tot schaalverandering.

**Is het mogelijk om dit schaalprobleem volledig te voorkomen?**  
Ja. Door het OLE‑frame te schalen naar de grootte van het Excel‑cellenbereik of door het cellenbereik te schalen naar de gewenste OLE‑framegrootte, kun je ongewenste schaalverandering voorkomen.

**Welke schaalmethode moet ik gebruiken, OLE‑frame­schaal of cellenbereik­schaal?**  
Kies **OLE frame scaling** als je de oorspronkelijke Excel‑rij‑ en kolomgroottes wilt behouden. Kies **cell range scaling** als je een vaste grootte voor het OLE‑frame in je presentatie wilt.

**Werken deze oplossingen ook als mijn presentatie gebaseerd is op een sjabloon?**  
Ja. Beide oplossingen werken voor presentaties die zijn gemaakt op basis van sjablonen en voor presentaties die vanaf nul worden opgebouwd.

**Is er een limiet aan de grootte van het OLE‑frame bij het gebruik van deze methoden?**  
Nee. Je kunt het OLE‑objectframe zo groot maken als je wilt, zolang je de schaal correct instelt.

**Is er een manier om de “EMBEDDED OLE OBJECT”-plaatsaanduidingstekst in PowerPoint te vermijden?**  
Ja. Door een snapshot van het beoogde Excel‑cellenbereik te nemen en deze in te stellen als de plaatsaanduidingsafbeelding van het OLE‑frame, kun je een aangepaste voorbeeldafbeelding weergeven in plaats van de standaardtekst.