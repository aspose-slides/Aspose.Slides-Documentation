---
title: Működő megoldás a munkalap átméretezés problémájára
type: docs
weight: 20
url: /hu/php-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- előnézeti kép
- kép átméretezés
- Excel
- munkalap
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Javítsa az Excel munkalap OLE átméretezését a prezentációkban: két mód a objektumkeretek konzisztens megtartására – a keret vagy a lap méretezése – a PPT és PPTX formátumokban."
---
{{% alert color="info" title="Megjegyzés" %}}

Az Aspose komponensekkel PowerPoint prezentációba beágyazott OLE objektumként megjelenő Excel munkalapok az első aktiválás után váratlanul méretváltozhatnak. Ez a viselkedés észrevehető vizuális különbséget eredményez az OLE objektum aktiválás előtti és utáni állapota között. Ez a cikk ismerteti a problémát és leírja a megoldás két módját.

{{% /alert %}}

## **Háttér**

A [Manage OLE](/slides/hu/php-java/manage-ole/) című cikkben bemutattuk, hogyan lehet OLE keretet hozzáadni egy PowerPoint prezentációhoz az Aspose.Slides for PHP via Java segítségével. A [object preview issue](/slides/hu/php-java/object-preview-issue-when-adding-oleobjectframe/) kezelésére a kiválasztott munkalap-terület képét rendeltük az OLE objektumkerethez. A kimeneti prezentációban, ha duplán kattint a munkalap képet megjelenítő OLE objektumkeretre, az Excel munkafüzet aktiválódik. A végfelhasználók tetszőleges módosításokat végezhetnek a tényleges Excel munkafüzeten, majd a slide-ra visszatérhetnek a aktivált Excel munkafüzeten kívülre kattintva. Az OLE objektumkeret mérete megváltozik, amikor a felhasználó visszatér a slide-ra. A méretezési tényező a OLE objektumkeret és a beágyazott Excel munkafüzet méretétől függ.

## **A méretezés oka**

Mivel az Excel munkafüzet saját ablakmérettel rendelkezik, az első aktiváláskor megpróbálja megtartani eredeti méretét. Ezzel szemben az OLE objektumkeretnek saját mérete van. A Microsoft szerint, amikor az Excel munkafüzet aktiválódik, az Excel és a PowerPoint egyeztetik a méretet, hogy biztosítsák a megfelelő arányokat a beágyazási folyamat részeként. A méretezés az Excel ablakméret és az OLE objektumkeret mérete és pozíciója közötti különbségek alapján történik.

## **Működő megoldás**

Két lehetséges megoldás létezik a méretezési hatás elkerülésére.

- Méretezze át az OLE keretet a PowerPoint prezentációban, hogy megegyezzen a kiválasztott sorok és oszlopok teljes magasságával és szélességével.
- Tartsa állandóan az OLE keret méretét, és méretezze a kiválasztott sorokat és oszlopokat úgy, hogy illeszkedjenek bele.

### **Az OLE keret méretének méretezése**

Ez a megközelítés az OLE keret méretét úgy állítja be, hogy megegyezzen a beágyazott Excel munkalapban kiválasztott sorok és oszlopok teljes magasságával és szélességével.

A példa betölti egy meglévő Excel munkafüzetet, és a nulla alapú indexekkel az első 10 sor és 13 oszlop kiválasztásával az első munkalapon dolgozik. A [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) definiálja a megjelenített tartományt. Az előnézetet 96 DPI-n renderelik, és a pixelméreteket 72 pont per hüvelyk alapján pontokra konvertálják. A [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) beágyazza a módosított munkafüzetet egy ilyen méretű keretbe. Az előnézetet a [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) segítségével rendelik hozzá, hogy helyettesítse a mentett prezentációban a "EMBEDDED OLE OBJECT" helykitöltőt.

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // Beágyazza a módosított munkafüzetet, és tartsa a bináris adatokat Java bájt tömbökben.
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $frameWidth = java_values($image->getWidth()) * 72.0 / $imageResolution;
        $frameHeight = java_values($image->getHeight()) * 72.0 / $imageResolution;
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

Az előnézet segédprogram a [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) beállítást a kiválasztott tartományra állítja, és eltávolítja a margókat, fejléceket és lábléceket. Az [ImageOrPrintOptions::setOnlyArea](https://reference.aspose.com/cells/php/aspose.cells/imageorprintoptions/#onlyarea) engedélyezésével a [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage) a tartományt PNG képként rendereli. A segédprogram egy új bemeneti stream-et ad vissza, amely a PNG képet tartalmazza, az elejére pozícionálva a prezentációban való használathoz.

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

### **A cellatartomány méretének méretezése**

Ez a megközelítés a kiválasztott sorok magasságát és a kiválasztott oszlopok szélességét úgy méretezi, hogy megfeleljen egy egyéni OLE keretméretnek.

Hasonlóan, a példa betölti egy meglévő Excel munkafüzetet, és a nulla alapú indexekkel az első 10 sor és 13 oszlop kiválasztásával az első munkalapon dolgozik. A [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) definiálja a megjelenített tartományt, és az alábbi segédprogram a tartományt úgy méretezi, hogy illeszkedjen egy 400 pont széles és 100 pont magas kerethez. A módosított munkafüzetet a [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) a megadott mérettel ágyazza be. Egy 96 DPI-n renderelt előnézet a [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) segítségével kerül hozzárendelésre, így a mentett prezentáció a kiválasztott cellákat jeleníti meg az alapértelmezett helykitöltő helyett.

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);
    $frameWidth = 400;
    $frameHeight = 100;
    ScaleCellRange($cellRange, $frameWidth, $frameHeight);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // Beágyazza a módosított munkafüzetet, és a bináris adatokat Java bájt tömbökben tartja.
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

A méretező segédprogram külön szélesség- és magasságarányokat számít ki a kiválasztott tartományra, megőrizve az oszlopok relatív szélességét és a sorok relatív magasságát. Az számított méreteket pontból hüvelykbe konvertálja, mielőtt a [Cells::setColumnWidthInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setcolumnwidthinch) és a [Cells::setRowHeightInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setrowheightinch) függvényekkel alkalmazná. A kiválasztott tartománynak nem lehet nulla szélessége vagy magassága.

```php
use aspose\cells\CellsUnitType;

// A szélesség és magasság a cellatartomány várható méretei pontban.
function ScaleCellRange($cellRange, $width, $height) {
    $rangeWidth = java_values($cellRange->getWidth());
    $rangeHeight = java_values($cellRange->getHeight());
    $cells = $cellRange->getWorksheet()->getCells();
    $columnCount = java_values($cellRange->getColumnCount());
    $rowCount = java_values($cellRange->getRowCount());
    $firstColumn = java_values($cellRange->getFirstColumn());
    $firstRow = java_values($cellRange->getFirstRow());

    for ($i = 0; $i < $columnCount; $i++) {
        $columnIndex = $firstColumn + $i;
        $columnWidth = java_values($cells->getColumnWidth($columnIndex, false, CellsUnitType::POINT));
        $newColumnWidth = $columnWidth * $width / $rangeWidth;
        $widthInInches = $newColumnWidth / 72.0;
        $cells->setColumnWidthInch($columnIndex, $widthInInches);
    }

    for ($i = 0; $i < $rowCount; $i++) {
        $rowIndex = $firstRow + $i;
        $rowHeight = java_values($cells->getRowHeight($rowIndex, false, CellsUnitType::POINT));
        $newRowHeight = $rowHeight * $height / $rangeHeight;
        $heightInInches = $newRowHeight / 72.0;
        $cells->setRowHeightInch($rowIndex, $heightInInches);
    }
}
```

Ez az előnézet segédprogram a [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage) segítségével rendereli a átméretezett tartományt. A [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) csak erre a tartományra korlátozza, eltávolítja a margókat, fejléceket és lábléceket, és egy PNG stream-et ad vissza, amely a kezdetére van pozícionálva.

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

## **Következtetés**

{{% alert color="info" title="Megjegyzés" %}}

Az alábbi két megközelítés létezik a munkalap méretezési probléma megoldására. Válassza ki azt a megközelítést, amely leginkább megfelel az igényeinek és felhasználási esetének. Mindkét megközelítés ugyanúgy működik, függetlenül attól, hogy a prezentáció sablonból vagy a semmiből készült. Emellett nincs korlátozás az OLE objektumkeret méretére ebben a megoldásban.

{{% /alert %}}

## **GYIK**

**Miért változik méretét egy beágyazott Excel munkalapnak, amikor először aktiválják PowerPointban?**

Ez azért történik, mert az Excel megpróbálja megtartani az eredeti ablakméretet az aktiváláskor, míg a PowerPointban az OLE objektumkeret saját méretekkel rendelkezik. A PowerPoint és az Excel egyeztetik a méretet az arányok megtartása érdekében, ami méretezést okozhat.

**Lehet-e teljesen elkerülni ezt a méretezési problémát?**

Igen. Az OLE keret méretezésével, hogy illeszkedjen az Excel cellatartomány méretéhez, vagy a cellatartomány méretezésével, hogy illeszkedjen a kívánt OLE keret méretéhez, megakadályozható a nem kívánt méretezés.

**Melyik méretezési módszert kell használnom, az OLE keret méretezését vagy a cellatartomány méretezését?**

Válassza az **OLE keret méretezését**, ha az eredeti Excel sor- és oszlopszélességeket szeretné megőrizni. Válassza a **cellatartomány méretezését**, ha egy fix méretű OLE keretet szeretne a prezentációban.

**Működnek-e ezek a megoldások, ha a prezentációm sablonon alapul?**

Igen. Mindkét megoldás működik sablonból vagy a semmiből készült prezentációk esetén.

**Van-e korlátozás az OLE keret méretére ezeknek a módszereknek a használata során?**

Nem. Az OLE objektumkeret bármilyen méretű lehet, amíg a méretezést megfelelően állítja be.

**Van lehetőség elkerülni az "EMBEDDED OLE OBJECT" helykitöltő szöveget a PowerPointban?**

Igen. Ha a cél Excel cellatartományról készít pillanatképet, és azt állítja be az OLE keret helykitöltő képének, akkor egy egyéni előnézeti képet jeleníthet meg az alapértelmezett helykitöltő helyett.

## **Kapcsolódó cikkek**

[Excel diagram létrehozása és OLE objektumként történő beágyazása egy prezentációba](/slides/hu/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[OLE objektumok automatikus frissítése MS PowerPoint kiegészítő használatával](/slides/hu/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)