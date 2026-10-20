---
title: Řešení problému se změnou velikosti listu
type: docs
weight: 20
url: /cs/nodejs-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- náhledový obrázek
- měnění velikosti obrázku
- Excel
- list
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Opravte změnu velikosti OLE listu Excel v prezentacích: dva způsoby, jak udržet rámce objektů konzistentní—škálování rámce nebo listu—napříč formáty PPT a PPTX."
---
{{% alert color="info" title="Poznámka" %}}

Excel listy vložené jako OLE objekty v prezentaci PowerPoint pomocí komponent Aspose se mohou po svém prvním aktivování neočekávaně změnit velikost. Toto chování vytváří viditelný vizuální rozdíl mezi OLE objektem před a po aktivaci. Tento článek vysvětluje problém a popisuje dva způsoby, jak jej řešit.

{{% /alert %}}

## **Pozadí**

V článku [Spravovat OLE](/slides/cs/nodejs-java/manage-ole/) jsme vysvětlili, jak přidat OLE rámec do prezentace PowerPoint pomocí Aspose.Slides pro Node.js via Java. K vyřešení [problému s náhledem objektu](/slides/cs/nodejs-java/object-preview-issue-when-adding-oleobjectframe/) jsme přiřadili obrázek vybrané oblasti listu k OLE objektovému rámci. V vytvořené prezentaci, když dvakrát kliknete na OLE rámec zobrazující obrázek listu, aktivuje se sešit Excelu. Uživatelé mohou provést libovolné úpravy skutečného sešitu Excel a poté se vrátit na snímek kliknutím mimo aktivovaný sešit. Velikost OLE rámce se změní, když se uživatel vrátí na snímek. Faktor změny velikosti se liší v závislosti na velikosti OLE rámce a vloženého sešitu Excel.

## **Příčina změny velikosti**

Protože má sešit Excel vlastní velikost okna, snaží se po první aktivaci zachovat původní velikost. Na druhé straně má OLE rámec vlastní rozměry. Podle Microsoftu, když je sešit Excel aktivován, Excel a PowerPoint dohodnou velikost tak, aby zachovaly správné proporce jako součást procesu vkládání. Změna velikosti nastává na základě rozdílů mezi velikostí okna Excel a velikostí a polohou OLE rámce.

## **Řešení**

Existují dva možná řešení, jak předejít efektu změny velikosti.

- Změnit velikost OLE rámce v prezentaci PowerPoint tak, aby odpovídala celkové výšce a šířce vybraných řádků a sloupců.
- Zachovat konstantní velikost OLE rámce a přizpůsobit vybrané řádky a sloupce tak, aby se vešly dovnitř.

### **Změnit velikost OLE rámce**

Tento postup nastaví velikost OLE rámce tak, aby odpovídala celkové výšce a šířce vybraných řádků a sloupců ve vloženém listu Excel.

Příklad načte existující sešit Excel a vybere prvních 10 řádků a 13 sloupců z prvního listu pomocí nulových indexů. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) určuje zobrazovanou oblast. Náhled je vykreslen při 96 DPI a jeho rozměry v pixelech jsou převedeny na body pomocí 72 bodů na palec. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) vloží upravený sešit do rámce s těmito rozměry. Náhled je přiřazen přes [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) k nahrazení zástupného textu „EMBEDDED OLE OBJECT“ v uložené prezentaci.

Nainstalujte balíčky `aspose.cells`, `aspose.slides.via.java` a `java` a umístěte `sample.xlsx` do pracovního adresáře. Pro každý postup nejprve spusťte skript přípravy a poté skript vkládání v samostatném procesu Node.js ve stejném adresáři. Oba balíčky Aspose spouští Java most odděleně.

Uložte tento skript přípravy jako `prepare-frame-scaled.js` a spusťte jej pomocí `node prepare-frame-scaled.js`. Vytvoří soubory `frame-scaled.xlsx` a `frame-scaled.png`.

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

// Veškerá synchronní práce je dokončena; zastavte proces Java bridge.
process.exit(0);
```

Uložte tento skript vkládání jako `embed-frame-scaled.js` a spusťte jej pomocí `node embed-frame-scaled.js`. Načte tyto soubory a vytvoří `frame-scaled.pptx`.

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

// Veškerá synchronní práce je dokončena; zastavte proces Java bridge.
process.exit(0);
```

Pomocník pro náhled nastaví [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) na vybranou oblast a odstraní okraje, záhlaví i zápatí. S povoleno [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/nodejs/aspose.cells/imageorprintoptions/#setonlyarea) [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage) vykreslí oblast jako PNG obrázek. Pomocník uloží PNG obrázek do souboru pro použití v prezentaci.

### **Změnit velikost oblasti buněk**

Tento postup mění výšky vybraných řádků a šířky vybraných sloupců tak, aby odpovídaly vlastní velikosti OLE rámce.

Příklad načte existující sešit Excel a vybere prvních 10 řádků a 13 sloupců z prvního listu pomocí nulových indexů. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) určuje zobrazovanou oblast a pomocník tuto oblast přizpůsobí tak, aby se vešla do rámce o šířce 400 bodů a výšce 100 bodů. Po uložení upraveného sešitu do souboru [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) vloží jej v zadané velikosti. Náhled vykreslený při 96 DPI je přiřazen přes [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), takže uložená prezentace zobrazuje vybrané buňky místo výchozího zástupného textu.

Uložte tento skript přípravy jako `prepare-cells-scaled.js` a spusťte jej pomocí `node prepare-cells-scaled.js`. Vytvoří soubory `cells-scaled.xlsx` a `cells-scaled.png`.

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

// Veškerá synchronní práce je dokončena; zastavte proces Java bridge.
process.exit(cellsPrepared ? 0 : 1);
```

Uložte tento skript vkládání jako `embed-cells-scaled.js` a spusťte jej pomocí `node embed-cells-scaled.js`. Načte tyto soubory a vytvoří `cells-scaled.pptx`.

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

// Veškerá synchronní práce je dokončena; zastavte proces Java bridge.
process.exit(0);
```

Pomocník pro škálování vypočítá samostatné poměry šířky a výšky pro vybranou oblast, přičemž zachová relativní šířky jejích sloupců a relativní výšky řádků. Převádí vypočtené rozměry z bodů na palce před jejich aplikací pomocí [Cells.setColumnWidthInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setcolumnwidthinch) a [Cells.setRowHeightInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setrowheightinch). Vybraná oblast musí mít nenulovou šířku i výšku.

Tento pomocník pro náhled vykresluje změněnou oblast pomocí [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage). Omezí [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) na tuto oblast, odstraní okraje, záhlaví a zápatí a uloží PNG obrázek do souboru.

## **Závěr**

{{% alert color="info" title="Poznámka" %}}

Existují dva přístupy k vyřešení problému se změnou velikosti listu. Vyberte přístup, který nejlépe vyhovuje vašim požadavkům a případovému použití. Oba přístupy fungují stejně, ať už jsou prezentace vytvořeny z šablony nebo od nuly. Navíc není v tomto řešení žádný limit na velikost OLE rámce.

{{% /alert %}}

## **Často kladené otázky**

**Proč se vložený list Excel po první aktivaci v PowerPointu mění velikost?**

K tomu dochází, protože Excel se snaží zachovat původní velikost okna po aktivaci, zatímco OLE rámec v PowerPoint má své vlastní rozměry. PowerPoint a Excel dohodnou velikost tak, aby zachovaly poměr stran, což může způsobit změnu velikosti.

**Je možné zcela zabránit tomuto problému se změnou velikosti?**

Ano. Škálováním OLE rámce tak, aby odpovídal velikosti rozsahu buněk Excel, nebo škálováním rozsahu buněk tak, aby odpovídal požadované velikosti OLE rámce, můžete zabránit nežádoucí změně velikosti.

**Kterou metodu škálování mám použít, škálování OLE rámce nebo škálování rozsahu buněk?**

Vyberte **škálování OLE rámce**, pokud chcete zachovat původní velikosti řádků a sloupců Excelu. Vyberte **škálování rozsahu buněk**, pokud chcete mít v prezentaci pevnou velikost OLE rámce.

**Budou tyto řešení fungovat, pokud je moje prezentace založena na šabloně?**

Ano. Obě řešení fungují pro prezentace vytvořené ze šablon i od nuly.

**Existuje limit na velikost OLE rámce při použití těchto metod?**

Ne. OLE objekt můžete nastavit na libovolnou velikost, pokud správně nastavíte měřítko.

**Je způsob, jak se vyhnout textu „EMBEDDED OLE OBJECT“ v PowerPointu?**

Ano. Pořízením snímku cílového rozsahu buněk Excel a nastavením tohoto snímku jako zástupného obrázku OLE rámce můžete v prezentaci zobrazit vlastní obrázek náhledu místo výchozího zástupného textu.

## **Související články**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/cs/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/cs/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)