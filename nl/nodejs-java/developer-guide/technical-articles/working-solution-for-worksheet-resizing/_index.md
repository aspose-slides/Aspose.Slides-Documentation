---
title: Werkende oplossing voor het wijzigen van de grootte van werkbladen
type: docs
weight: 20
url: /nl/nodejs-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- preview-afbeelding
- afbeeldingsgrootte aanpassen
- Excel
- werkblad
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Los het OLE-grootte‑aanpassingsprobleem van Excel‑werkbladen in presentaties op: twee manieren om objectframes consistent te houden—het frame of het blad schalen—over de PPT‑ en PPTX‑formaten."
---
{{% alert color="info" title="Note" %}}
Excel-werkbladen die als OLE-objecten in een PowerPoint-presentatie zijn ingesloten met Aspose-componenten, kunnen onverwacht van grootte veranderen na de eerste activering. Dit gedrag veroorzaakt een duidelijk visueel verschil tussen het OLE-object vóór en na activering. Dit artikel legt het probleem uit en beschrijft twee manieren om het op te lossen.
{{% /alert %}}

## **Achtergrond**

In het artikel [Manage OLE](/slides/nl/nodejs-java/manage-ole/), legden we uit hoe je een OLE-frame aan een PowerPoint-presentatie kunt toevoegen met Aspose.Slides voor Node.js via Java. Om het [object preview issue](/slides/nl/nodejs-java/object-preview-issue-when-adding-oleobjectframe/) aan te pakken, hebben we een afbeelding van het geselecteerde werkbladgebied aan het OLE-objectframe toegewezen. In de gegenereerde presentatie, wanneer je dubbelklikt op het OLE-objectframe dat de werkbladafbeelding toont, wordt het Excel-werkboek geactiveerd. Eindgebruikers kunnen gewenste wijzigingen aanbrengen in het daadwerkelijke Excel-werkboek en vervolgens terugkeren naar de dia door buiten het geactiveerde Excel-werkboek te klikken. De grootte van het OLE-objectframe zal wijzigen wanneer de gebruiker terugkeert naar de dia. De resize‑factor varieert afhankelijk van de grootte van het OLE-objectframe en het ingesloten Excel-werkboek.

## **Oorzaak van het verkleinen**

Aangezien het Excel-werkboek een eigen venstergrootte heeft, probeert het bij de eerste activering zijn oorspronkelijke grootte te behouden. Daarentegen heeft het OLE-objectframe een eigen afmeting. Volgens Microsoft onderhandelen Excel en PowerPoint, wanneer het Excel-werkboek geactiveerd wordt, over de grootte om ervoor te zorgen dat de juiste verhoudingen behouden blijven als onderdeel van het insluitproces. De aanpassing van de grootte gebeurt op basis van de verschillen tussen de Excel-venstergrootte en de grootte en positie van het OLE-objectframe.

## **Werkende oplossing**

Er zijn twee mogelijke oplossingen om het effect van het aanpassen van de grootte te voorkomen.

- Schaal het OLE-frame in de PowerPoint-presentatie zodat het overeenkomt met de totale hoogte en breedte van de geselecteerde rijen en kolommen.
- Houd de grootte van het OLE-frame constant en schaalt de geselecteerde rijen en kolommen zodat ze erin passen.

### **Schaal de OLE-framegrootte**

Deze methode stelt de grootte van het OLE-frame in zodat deze overeenkomt met de totale hoogte en breedte van de geselecteerde rijen en kolommen in het ingesloten Excel-werkblad.

Het voorbeeld laadt een bestaand Excel-werkboek en selecteert de eerste 10 rijen en 13 kolommen van het eerste werkblad met nulgebaseerde indexen. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) definieert het weer te geven bereik. De preview wordt gerenderd op 96 DPI en de pixelafmetingen worden omgezet naar punten met 72 punten per inch. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) embedde het gewijzigde werkboek in een frame met die afmetingen. De preview wordt toegewezen via [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) om de plaatsaanduiding "EMBEDDED OLE OBJECT" in de opgeslagen presentatie te vervangen.

Installeer de pakketten `aspose.cells`, `aspose.slides.via.java` en `java` en plaats `sample.xlsx` in de werkmap. Voor elke methode voer je eerst het voorbereidingsscript uit, daarna het insluitscript in een apart Node.js‑proces in dezelfde map. De twee Aspose‑pakketten initialiseren de Java‑brug afzonderlijk.

Sla dit voorbereidingsscript op als `prepare-frame-scaled.js` en voer het uit met `node prepare-frame-scaled.js`. Het schrijft `frame-scaled.xlsx` en `frame-scaled.png`.

```javascript
const cells = require("aspose.cells");

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

prepareWorkbook("frame-scaled");

// Alle synchronisatiewerk is voltooid; stop het Java-bridgeproces.
process.exit(0);
```

Sla dit insluitscript op als `embed-frame-scaled.js` en voer het uit met `node embed-frame-scaled.js`. Het leest die bestanden en schrijft `frame-scaled.pptx`.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("frame-scaled", false);

// Alle synchronisatiewerk is voltooid; stop het Java-bridgeproces.
process.exit(0);
```

De preview‑helper stelt [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) in op het geselecteerde bereik en verwijdert marges, kop- en voetteksten. Met [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/nodejs/aspose.cells/imageorprintoptions/#setonlyarea) ingeschakeld, rendert [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage) het bereik als een PNG‑afbeelding. De helper slaat de PNG‑afbeelding op in een bestand voor gebruik in de presentatie.

### **Schaal de celbereikgrootte**

Deze methode schaalt de hoogtes van de geselecteerde rijen en de breedtes van de geselecteerde kolommen zodat ze overeenkomen met een aangepaste OLE-framegrootte.

Het voorbeeld laadt een bestaand Excel-werkboek en selecteert de eerste 10 rijen en 13 kolommen van het eerste werkblad met nulgebaseerde indexen. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) definieert het weergegeven bereik, en de helper schaalt dat bereik om in een frame van 400 punten breed en 100 punten hoog te passen. Na het opslaan van het gewijzigde werkboek naar een bestand, embedde [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) het met de opgegeven grootte. Een preview gerenderd op 96 DPI wordt toegewezen via [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), zodat de opgeslagen presentatie de geselecteerde cellen toont in plaats van de standaardplaatsaanduiding.

Sla dit voorbereidingsscript op als `prepare-cells-scaled.js` en voer het uit met `node prepare-cells-scaled.js`. Het schrijft `cells-scaled.xlsx` en `cells-scaled.png`.

```javascript
const cells = require("aspose.cells");

function scaleCellRange(cellRange, width, height) {
    const rangeWidth = cellRange.getWidth();
    const rangeHeight = cellRange.getHeight();
    if (rangeWidth <= 0 || rangeHeight <= 0) {
        console.error("The selected range must have nonzero width and height.");
        return false;
    }

    const worksheetCells = cellRange.getWorksheet().getCells();
    for (let i = 0; i < cellRange.getColumnCount(); i++) {
        const columnIndex = cellRange.getFirstColumn() + i;
        const columnWidth = worksheetCells.getColumnWidth(columnIndex, false, cells.CellsUnitType.POINT);
        const widthInInches = columnWidth * width / rangeWidth / 72;
        worksheetCells.setColumnWidthInch(columnIndex, widthInInches);
    }
    for (let i = 0; i < cellRange.getRowCount(); i++) {
        const rowIndex = cellRange.getFirstRow() + i;
        const rowHeight = worksheetCells.getRowHeight(rowIndex, false, cells.CellsUnitType.POINT);
        const heightInInches = rowHeight * height / rangeHeight / 72;
        worksheetCells.setRowHeightInch(rowIndex, heightInInches);
    }
    return true;
}

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName, scaleCells) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
        if (scaleCells && !scaleCellRange(cellRange, 400, 100)) {
            return false;
        }

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

const cellsPrepared = prepareWorkbook("cells-scaled", true);

// Alle synchronisatiewerk is voltooid; stop het Java-bridgeproces.
process.exit(cellsPrepared ? 0 : 1);
```

Sla dit insluitscript op als `embed-cells-scaled.js` en voer het uit met `node embed-cells-scaled.js`. Het leest die bestanden en schrijft `cells-scaled.pptx`.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("cells-scaled", true);

// Alle synchronisatiewerk is voltooid; stop het Java-bridgeproces.
process.exit(0);
```

De schaal‑helper berekent afzonderlijke breedte‑ en hoogte‑ratio’s voor het geselecteerde bereik, waarbij de relatieve breedtes van de kolommen en de relatieve hoogtes van de rijen behouden blijven. Hij zet de berekende afmetingen van punten naar inches om voordat ze worden toegepast met [Cells.setColumnWidthInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setcolumnwidthinch) en [Cells.setRowHeightInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setrowheightinch). Het geselecteerde bereik moet een breedte en hoogte hebben die niet nul is.

Deze preview‑helper rendert het vergrote bereik met behulp van [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage). Hij beperkt [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) tot dat bereik, verwijdert marges, kop‑ en voetteksten, en slaat de PNG‑afbeelding op in een bestand.

## **Conclusie**
{{% alert color="info" title="Note" %}}
Er zijn twee benaderingen om het probleem van het aanpassen van de werkbladgrootte op te lossen. Kies de benadering die het beste past bij uw eisen en gebruikssituatie. Beide benaderingen werken op dezelfde manier, of de presentaties nu vanuit een sjabloon of vanaf nul worden gemaakt. Bovendien is er geen limiet aan de grootte van het OLE-objectframe in deze oplossing.
{{% /alert %}}

## **FAQ**

**Waarom verandert een ingesloten Excel-werkblad van grootte wanneer het voor het eerst wordt geactiveerd in PowerPoint?**

Dit gebeurt omdat Excel probeert de oorspronkelijke venstergrootte te behouden bij activatie, terwijl het OLE‑objectframe in PowerPoint zijn eigen afmetingen heeft. PowerPoint en Excel onderhandelen over de grootte om de beeldverhouding te behouden, wat de aanpassing van de grootte kan veroorzaken.

**Is het mogelijk om dit probleem met het aanpassen van de grootte volledig te voorkomen?**

Ja. Door het OLE‑frame te schalen zodat het past bij de grootte van het Excel‑celbereik, of door het celbereik te schalen zodat het past bij de gewenste OLE‑framegrootte, kun je ongewenste aanpassingen voorkomen.

**Welke schaalmethode moet ik gebruiken, OLE‑frame schalen of celbereik schalen?**

Kies **OLE‑frame schalen** als je de oorspronkelijke Excel‑rij‑ en kolomgroottes wilt behouden. Kies **celbereik schalen** als je een vaste grootte voor het OLE‑frame in uw presentatie wilt.

**Werken deze oplossingen als mijn presentatie gebaseerd is op een sjabloon?**

Ja. Beide oplossingen werken voor presentaties die vanuit sjablonen of vanaf nul zijn gemaakt.

**Is er een limiet aan de grootte van het OLE‑frame bij het gebruik van deze methoden?**

Nee. Je kunt het OLE‑objectframe elke gewenste grootte geven, zolang je de schaal correct instelt.

**Is er een manier om de plaatsaanduidingstexte "EMBEDDED OLE OBJECT" in PowerPoint te vermijden?**

Ja. Door een snapshot van het gewenste Excel‑celbereik te nemen en deze in te stellen als de plaatsaanduidingsafbeelding van het OLE‑frame, kun je een aangepaste preview‑afbeelding weergeven in plaats van de standaardplaatsaanduiding.

## **Gerelateerde artikelen**

[Een Excel‑grafiek maken en insluiten in een presentatie als OLE‑object](/slides/nl/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[OLE‑objecten automatisch bijwerken met een MS PowerPoint‑add‑in](/slides/nl/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)