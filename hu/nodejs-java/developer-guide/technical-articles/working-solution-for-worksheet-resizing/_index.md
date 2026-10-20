---
title: Működő megoldás a munkalap átméretezéséhez
type: docs
weight: 20
url: /hu/nodejs-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- előnézeti kép
- kép átméretezés
- Excel
- munkalap
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Javítsa az Excel munkalap OLE átméretezését a prezentációkban: két módja van az objektumkeretek konzisztens megtartásának—a keret vagy a lap méretezésével—mind a PPT, mind a PPTX formátumokban."
---
{{% alert color="info" title="Note" %}}
Az Aspose komponensek használatával PowerPoint‑prezentációba beágyazott OLE‑objektumként megjelenő Excel‑munkalapok az első aktiválás után váratlanul átméreteződhetnek. Ez a viselkedés észrevehető vizuális különbséget eredményez az OLE‑objektum aktiválás előtti és utáni állapota között. Ez a cikk ismerteti a problémát, és két megoldási lehetőséget mutat be.
{{% /alert %}}

## **Háttér**

Az [OLE kezelése](/slides/hu/nodejs-java/manage-ole/) című cikkben ismertettük, hogyan lehet OLE‑keretet hozzáadni egy PowerPoint‑prezentációhoz az Aspose.Slides for Node.js Java‑n keresztül történő használatával. Az [objektum előnézeti probléma](/slides/hu/nodejs-java/object-preview-issue-when-adding-oleobjectframe/) megoldásához a kiválasztott munkalap‑terület képét rendeltük az OLE‑objektum kerethez. A kimeneti prezentációban, ha duplán kattint a munkalapképet megjelenítő OLE‑objektum keretre, az Excel‑munkafüzet aktiválódik. A végfelhasználók a tényleges Excel‑munkafüzettel elvégezhetik a kívánt módosításokat, majd a kattintással a aktivált Excel‑munkafüzeten kívül visszatérhetnek a diára. Az OLE‑objektum keret mérete megváltozik, amikor a felhasználó visszatér a diára. Az átméretezési arány a OLE‑objektum keret és a beágyazott Excel‑munkafüzet méretétől függ.

## **Az átméretezés oka**

Mivel az Excel‑munkafüzetnek saját ablakmérete van, az első aktiváláskor megpróbálja megtartani az eredeti méretét. Ezzel szemben az OLE‑objektum keretnek saját mérete van. A Microsoft szerint, amikor az Excel‑munkafüzet aktiválódik, az Excel és a PowerPoint egyeztetik a méretet, hogy a beágyazási folyamat során a megfelelő arányokat megőrizze. Az átméretezés a Excel‑ablak mérete és az OLE‑objektum keret mérete és pozíciója közötti különbségek alapján történik.

## **Működő megoldás**

Két lehetséges megoldás van az átméretezési hatás elkerülésére.

- Méretezze át az OLE‑keretet a PowerPoint‑prezentációban úgy, hogy megegyezzen a kiválasztott sorok és oszlopok teljes magasságával és szélességével.
- Tartsa állandó méretűn az OLE‑keretet, és méretezze a kiválasztott sorokat és oszlopokat úgy, hogy beleilljenek.

### **Az OLE‑keret méretének méretezése**

Ez a megközelítés az OLE‑keret méretét úgy állítja be, hogy megegyezzen a beágyazott Excel‑munkalapban a kiválasztott sorok és oszlopok teljes magasságával és szélességével. A példában egy meglévő Excel‑munkafüzetet tölt be, és a nulla alapú indexekkel kiválasztja az első munkalap első 10 sorát és 13 oszlopát. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) határozza meg a megjelenített tartományt. Az előnézet 96 DPI‑n kerül renderelésre, és a pixelméretek pontokra konvertálásra kerülnek, 72 pont hüvelykenként. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) beágyazza a módosított munkafüzettet egy olyan keretbe, amely ezekkel a méretekkel rendelkezik. Az előnézetet a [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) segítségével rendeljük hozzá, hogy lecserélje a mentett prezentációban a "EMBEDDED OLE OBJECT" helyőrzőt. Telepítse az `aspose.cells`, `aspose.slides.via.java` és `java` csomagokat, és helyezze a `sample.xlsx` fájlt a munkakönyvtárba. Minden megközelítéshez először futtassa az előkészítő szkriptet, majd a beágyazó szkriptet egy külön Node.js folyamatban ugyanabban a könyvtárban. A két Aspose csomag külön‑külön inicializálja a Java‑hidat.  

Mentse el ezt az előkészítő szkriptet `prepare-frame-scaled.js` néven, és futtassa a `node prepare-frame-scaled.js` paranccsal. A szkript `frame-scaled.xlsx` és `frame-scaled.png` fájlokat hoz létre.  

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

// Az összes szinkron munkát befejeztük; leállítjuk a Java híd folyamatot.
process.exit(0);
```

Mentse el ezt a beágyazó szkriptet `embed-frame-scaled.js` néven, és futtassa a `node embed-frame-scaled.js` paranccsal. A szkript beolvassa a fájlokat, és `frame-scaled.pptx` fájlt hoz létre.  

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

// Az összes szinkron munkát befejeztük; leállítjuk a Java híd folyamatot.
process.exit(0);
```

Az előnézetsegéd a [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) beállítással a kiválasztott tartományra állítja be a nyomtatási területet, és eltávolítja a margókat, fejlécet és láblécet. A [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/nodejs/aspose.cells/imageorprintoptions/#setonlyarea) engedélyezésével a [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage) PNG‑képet készít a tartományról. A segéd elmenti a PNG képet egy fájlba a prezentációhoz való használathoz.

### **A cellatartomány méretének méretezése**

Ez a megközelítés a kiválasztott sorok magasságát és a kiválasztott oszlopok szélességét úgy méretezi, hogy egy egyedi OLE‑keret méretéhez illeszkedjen. A példában egy meglévő Excel‑munkafüzetet tölt be, és nulla alapú indexekkel kiválasztja az első munkalap első 10 sorát és 13 oszlopát. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) definiálja a megjelenített tartományt, a segéd pedig ezt a tartományt úgy méretezi, hogy egy 400 pont széles és 100 pont magas keretbe illeszkedjen. A módosított munkafüzet fájlba mentése után a [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) a megadott mérettel ágyazza be. Az 96 DPI‑n renderelt előnézetet a [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) segítségével rendeljük hozzá, így a mentett prezentáció a kiválasztott cellákat mutatja az alapértelmezett helyőrző helyett.  

Mentse el ezt az előkészítő szkriptet `prepare-cells-scaled.js` néven, és futtassa a `node prepare-cells-scaled.js` paranccsal. A szkript `cells-scaled.xlsx` és `cells-scaled.png` fájlokat hoz létre.  

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

// Az összes szinkron munkát befejeztük; leállítjuk a Java híd folyamatot.
process.exit(cellsPrepared ? 0 : 1);
```

Mentse el ezt a beágyazó szkriptet `embed-cells-scaled.js` néven, és futtassa a `node embed-cells-scaled.js` paranccsal. A szkript beolvassa a fájlokat, és `cells-scaled.pptx` fájlt hoz létre.  

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

// Az összes szinkron munkát befejeztük; leállítjuk a Java híd folyamatot.
process.exit(0);
```

A méretező segéd kiszámítja a kiválasztott tartomány különálló szélességi és magassági arányait, megőrizve az oszlopok relatív szélességét és a sorok relatív magasságát. A kiszámított méreteket pontból hüvelykre konvertálja, mielőtt a [Cells.setColumnWidthInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setcolumnwidthinch) és a [Cells.setRowHeightInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setrowheightinch) segítségével alkalmazná. A kiválasztott tartománynak nem lehet nullszélességű vagy nullmagasságú.  

Ez az előnézetsegéd a [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage) használatával rendereli a méretezett tartományt. A [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) korlátozza azt a tartományra, eltávolítja a margókat, fejlécet és láblécet, majd elmenti a PNG képet egy fájlba.

## **Összegzés**
{{% alert color="info" title="Note" %}}
Két megközelítés létezik a munkalap átméretezési probléma megoldására. Válassza azt a megközelítést, amely a legjobban megfelel az igényeinek és a felhasználási esetnek. Mindkét megközelítés ugyanúgy működik, függetlenül attól, hogy a prezentációkat sablonból vagy a semmiből hozza létre. Ezenkívül ebben a megoldásban nincs korlátozás az OLE‑objektum keret méretére.
{{% /alert %}}

## **GYIK**

**Miért változik méretét egy beágyazott Excel‑munkalapnak, amikor először aktiválják a PowerPointban?**  
Ez azért történik, mert az Excel az aktiváláskor megpróbálja megtartani az eredeti ablakméretét, míg a PowerPointban az OLE‑objektum keretnek saját méretei vannak. A PowerPoint és az Excel egyeztetik a méretet az arányok megőrzése érdekében, ami az átméretezést okozhat.

**Lehetséges-e ezt az átméretezési problémát teljesen elkerülni?**  
Igen. Az OLE‑keret méretezésével az Excel cellatartomány méretéhez vagy a cellatartomány méretezésével a kívánt OLE‑keret méretéhez elkerülhető a nem kívánt átméretezés.

**Melyik méretezési módszert használjam, az OLE‑keret méretezést vagy a cellatartomány méretezést?**  
Válassza az **OLE‑keret méretezést**, ha az eredeti Excel‑sorok és oszlopok méretét szeretné megtartani. Válassza a **cellatartomány méretezést**, ha fix méretű OLE‑keretet szeretne a prezentációjában.

**Működnek-e ezek a megoldások, ha a prezentációm sablonon alapul?**  
Igen. Mindkét megoldás működik sablonokból és a semmiből létrehozott prezentációk esetén egyaránt.

**Van korlátozás az OLE‑keret méretére ezen módszerek használata során?**  
Nem. Az OLE‑objektum keretet bármilyen méretűre beállíthatja, amennyiben a skálát megfelelően állítja be.

**Van mód arra, hogy elkerüljük a "EMBEDDED OLE OBJECT" helyőrző szöveget a PowerPointban?**  
Igen. A cél Excel cellatartomány pillanatképének elkészítésével, és azt OLE‑keret helyőrző képeként beállítva saját előnézeti képet jeleníthet meg az alapértelmezett helyőrző helyett.

## **Kapcsolódó cikkek**

[Excel‑diagram létrehozása és OLE‑objektumként történő beágyazása a prezentációba](/slides/hu/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[OLE‑objektumok automatikus frissítése MS PowerPoint kiegészítő segítségével](/slides/hu/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)