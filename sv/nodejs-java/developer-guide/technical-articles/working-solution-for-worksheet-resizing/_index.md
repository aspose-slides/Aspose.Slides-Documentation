---
title: Fungerande lösning för kalkylbladsstorleksändring
type: docs
weight: 20
url: /sv/nodejs-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- förhandsgranskningsbild
- bildstorleksändring
- Excel
- kalkylblad
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Fixa OLE‑storleksändring av Excel‑kalkylblad i presentationer: två sätt att hålla objektramar konsekventa—skala ramen eller bladet—över PPT‑ och PPTX‑formaten."
---
{{% alert color="info" title="Obs" %}}
Excel‑kalkylblad som är inbäddade som OLE‑objekt i en PowerPoint‑presentation med Aspose‑komponenter kan ändra storlek oväntat efter deras första aktivering. Detta beteende skapar en märkbar visuell skillnad mellan OLE‑objektet före och efter aktiveringen. Den här artikeln förklarar problemet och beskriver två sätt att åtgärda det.
{{% /alert %}}

## **Bakgrund**

I artikeln [Hantera OLE](/slides/sv/nodejs-java/manage-ole/) förklarade vi hur man lägger till en OLE‑ram i en PowerPoint‑presentation med Aspose.Slides för Node.js via Java. För att åtgärda [objektförhandsgranskningsproblem](/slides/sv/nodejs-java/object-preview-issue-when-adding-oleobjectframe/) tilldelade vi en bild av det valda kalkylbladsområdet till OLE‑objektramen. I den resulterande presentationen, när du dubbelklickar på OLE‑objektramen som visar kalkylbladsbilden, aktiveras Excel‑arbetsboken. Slutanvändare kan göra önskade ändringar i den faktiska Excel‑arbetsboken och sedan återgå till bilden genom att klicka utanför den aktiverade Excel‑arbetsboken. Storleken på OLE‑objektramen ändras när användaren återvänder till bilden. Förstoringsfaktorn varierar beroende på storleken på OLE‑objektramen och den inbäddade Excel‑arbetsboken.

## **Orsak till storleksändring**

Eftersom Excel‑arbetsboken har sin egen fönsterstorlek försöker den behålla sin ursprungliga storlek vid första aktiveringen. Å andra sidan har OLE‑objektramen sin egen storlek. Enligt Microsoft, när Excel‑arbetsboken aktiveras, förhandlar Excel och PowerPoint fram storleken för att säkerställa att den behåller rätt proportioner som en del av inbäddningsprocessen. Storleksändringen sker baserat på skillnaderna mellan Excel‑fönstrets storlek och OLE‑objektrammens storlek och position.

## **Fungerande lösning**

Det finns två möjliga lösningar för att undvika storleksändringseffekten.

- Skala OLE‑ramen i PowerPoint‑presentationen så att den matchar den totala höjden och bredden på de valda raderna och kolumnerna.
- Behåll OLE‑ramens storlek konstant och skala de valda raderna och kolumnerna så att de passar inom den.

### **Skala OLE‑ramens storlek**

Detta tillvägagångssätt sätter OLE‑ramens storlek så att den matchar den totala höjden och bredden på de valda raderna och kolumnerna i det inbäddade Excel‑kalkylbladet.

Exemplet laddar en befintlig Excel‑arbetsbok och väljer de första 10 raderna och 13 kolumnerna i dess första kalkylblad med nollbaserade index. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) definierar det visade området. Förhandsgranskningen renderas med 96 DPI, och dess pixeldimensioner konverteras till punkter med 72 punkter per tum. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) bäddar in den modifierade arbetsboken i en ram med dessa dimensioner. Förhandsgranskningen tilldelas via [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) för att ersätta platshållaren "EMBEDDED OLE OBJECT" i den sparade presentationen.

Installera paketen `aspose.cells`, `aspose.slides.via.java` och `java` och placera `sample.xlsx` i arbetskatalogen. För varje tillvägagångssätt kör du förberedelsesskriptet först, sedan inbäddningsskriptet i en separat Node.js‑process i samma katalog. De två Aspose‑paketen initierar Java‑bron separat.

Spara detta förberedelsesskript som `prepare-frame-scaled.js` och kör det med `node prepare-frame-scaled.js`. Det skriver `frame-scaled.xlsx` och `frame-scaled.png`.

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

// Allt synkront arbete är slutfört; stoppa Java‑bryggprocessen.
process.exit(0);
```

Spara detta inbäddningsskript som `embed-frame-scaled.js` och kör det med `node embed-frame-scaled.js`. Det läser dessa filer och skriver `frame-scaled.pptx`.

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

// Allt synkront arbete är slutfört; stoppa Java-bryggprocessen.
process.exit(0);
```

Förhandsgranskningshjälpen anger [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) till det valda området och tar bort marginaler, sidhuvud och sidfot. Med [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/nodejs/aspose.cells/imageorprintoptions/#setonlyarea) aktiverat renderar [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage) området som en PNG‑bild. Hjälpen sparar PNG‑bilden till en fil för användning i presentationen.

### **Skala cellområdets storlek**

Detta tillvägagångssätt skalar höjderna på de valda raderna och breddarna på de valda kolumnerna så att de matchar en anpassad OLE‑ramstorlek.

Exemplet laddar en befintlig Excel‑arbetsbok och väljer de första 10 raderna och 13 kolumnerna i dess första kalkylblad med nollbaserade index. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) definierar det visade området, och hjälpen skalar det området för att passa en ram som är 400 punkter bred och 100 punkter hög. Efter att den modifierade arbetsboken har sparats till en fil, bäddar [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) in den med den angivna storleken. En förhandsgranskning renderad med 96 DPI tilldelas via [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), så den sparade presentationen visar de valda cellerna istället för standardplatshållaren.

Spara detta förberedelsesskript som `prepare-cells-scaled.js` och kör det med `node prepare-cells-scaled.js`. Det skriver `cells-scaled.xlsx` och `cells-scaled.png`.

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

// Allt synkront arbete är slutfört; stoppa Java-bryggprocessen.
process.exit(cellsPrepared ? 0 : 1);
```

Spara detta inbäddningsskript som `embed-cells-scaled.js` och kör det med `node embed-cells-scaled.js`. Det läser dessa filer och skriver `cells-scaled.pptx`.

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

// Allt synkront arbete är slutfört; stoppa Java-bryggprocessen.
process.exit(0);
```

Skaleringshjälpen beräknar separata bredd‑ och höjdratioer för det valda området, vilket bevarar kolumnernas relativa bredd och radernas relativa höjd. Den konverterar de beräknade dimensionerna från punkter till tum innan de appliceras med [Cells.setColumnWidthInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setcolumnwidthinch) och [Cells.setRowHeightInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setrowheightinch). Det valda området måste ha icke‑noll bredd och höjd.

Denna förhandsgranskningshjälp renderar det omdimensionerade området med [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage). Den begränsar [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) till det området, tar bort marginaler, sidhuvud och sidfot, och sparar PNG‑bilden till en fil.

## **Slutsats**

{{% alert color="info" title="Obs" %}}
Det finns två tillvägagångssätt för att åtgärda problemet med kalkylbladsstorleksändring. Välj det tillvägagångssätt som bäst passar dina krav och ditt användningsfall. Båda tillvägagångssätten fungerar på samma sätt, oavsett om presentationerna skapas från en mall eller från grunden. Dessutom finns det ingen begränsning på storleken på OLE‑objektramen i denna lösning.
{{% /alert %}}

## **Vanliga frågor**

**Varför ändrar ett inbäddat Excel‑kalkylblad storlek när det aktiveras för första gången i PowerPoint?**

Detta händer eftersom Excel försöker behålla den ursprungliga fönsterstorleken vid aktivering, medan OLE‑objektramen i PowerPoint har sina egna dimensioner. PowerPoint och Excel förhandlar fram storleken för att behålla bildförhållandet, vilket kan orsaka storleksändringen.

**Är det möjligt att helt förhindra detta storleksändringsproblem?**

Ja. Genom att skala OLE‑ramen så att den passar Excel‑cellområdets storlek eller skala cellområdet så att det passar den önskade OLE‑ramstorleken, kan du förhindra oönskad storleksändring.

**Vilken skalningsmetod bör jag använda, OLE‑ramskalning eller cellområdeskalning?**

Välj **OLE‑ramskalning** om du vill behålla de ursprungliga Excel‑rad‑ och kolumnstorlekarna. Välj **cellområdeskalning** om du vill ha en fast storlek på OLE‑ramen i din presentation.

**Fungerar dessa lösningar om min presentation är baserad på en mall?**

Ja. Båda lösningarna fungerar för presentationer som skapats från mallar och från grunden.

**Finns det någon begränsning för OLE‑ramens storlek när man använder dessa metoder?**

Nej. Du kan göra OLE‑objektramen vilken storlek som helst så länge du ställer in skalan på ett lämpligt sätt.

**Finns det ett sätt att undvika platshållartexten "EMBEDDED OLE OBJECT" i PowerPoint?**

Ja. Genom att ta en avbildning av det önskade Excel‑cellområdet och använda den som OLE‑ramens platshållarbild kan du visa en anpassad förhandsgranskningsbild i stället för standardplatshållaren.

## **Relaterade artiklar**

[Skapa ett Excel‑diagram och bädda in det i en presentation som ett OLE‑objekt](/slides/sv/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Uppdatera OLE‑objekt automatiskt med ett MS PowerPoint‑tillägg](/slides/sv/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)