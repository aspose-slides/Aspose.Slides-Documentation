---
title: Funkční řešení pro změnu velikosti listu
type: docs
weight: 20
url: /cs/php-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- náhledový obrázek
- změna velikosti obrázku
- Excel
- list
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Opravte změnu velikosti OLE listu Excel v prezentacích: dva způsoby, jak udržet rámce objektů konzistentní—škálovat rámec nebo list—ve formátech PPT a PPTX."
---
{{% alert color="info" title="Note" %}}

Excelové listy vložené jako OLE objekty v prezentaci PowerPoint pomocí komponent Aspose se mohou po první aktivaci neočekávaně změnit velikost. Toto chování vytváří patrný vizuální rozdíl mezi OLE objektem před a po aktivaci. Tento článek popisuje problém a uvádí dva způsoby, jak jej vyřešit.

{{% /alert %}}

## **Pozadí**

V článku [Manage OLE](/slides/cs/php-java/manage-ole/) jsme vysvětlili, jak přidat OLE rámeček do prezentace PowerPoint pomocí Aspose.Slides pro PHP přes Java. Pro řešení [object preview issue](/slides/cs/php-java/object-preview-issue-when-adding-oleobjectframe/) jsme přiřadili obrázek vybrané oblasti listu do OLE rámečku. V výstupní prezentaci, když dvakrát kliknete na OLE rámeček zobrazující obrázek listu, aktivuje se sešit Excelu. Uživatelé mohou provést požadované změny ve skutečném sešitu Excelu a poté se vrátit na snímek kliknutím mimo aktivovaný sešit Excelu. Velikost OLE rámečku se změní, když se uživatel vrátí na snímek. Faktor změny velikosti bude záviset na velikosti OLE rámečku a vloženého sešitu Excelu.

## **Příčina změny velikosti**

Protože má sešit Excelu vlastní velikost okna, snaží se při první aktivaci zachovat původní velikost. OLE rámeček má naopak svou vlastní velikost. Podle Microsoftu, když je sešit Excelu aktivován, Excel a PowerPoint vyjednávají velikost, aby zajistily zachování správných proporcí jako součást procesu vkládání. Změna velikosti nastává na základě rozdílů mezi velikostí okna Excelu a velikostí a polohou OLE rámečku.

## **Fungující řešení**

Existují dva možné způsoby, jak zabránit efektu změny velikosti.

- Změňte velikost OLE rámečku v prezentaci PowerPoint tak, aby odpovídala celkové výšce a šířce vybraných řádků a sloupců.
- Udržte velikost OLE rámečku konstantní a upravte velikost vybraných řádků a sloupců tak, aby se vešly dovnitř.

### **Změna velikosti OLE rámečku**

Tento přístup nastaví velikost OLE rámečku tak, aby odpovídala celkové výšce a šířce vybraných řádků a sloupců ve vloženém listu Excel.

Příklad načítá existující sešit Excel a pomocí nulových indexů vybírá prvních 10 řádků a 13 sloupců z jeho prvního listu. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) určuje zobrazovaný rozsah. Náhled je vykreslen při 96 DPI a jeho rozměry v pixelech jsou převedeny na body pomocí 72 bodů na palec. [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) vloží upravený sešit do rámečku s těmito rozměry. Náhled je přiřazen přes [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) k nahrazení zástupného textu „EMBEDDED OLE OBJECT“ v uložené prezentaci.

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

    // Vložte upravený sešit a uchovejte binární data v byte polích Javy.
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

Náhledový pomocník nastaví [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) na vybraný rozsah a odstraní okraje, záhlaví a zápatí. S povolenou možností [ImageOrPrintOptions::setOnlyArea](https://reference.aspose.com/cells/php/aspose.cells/imageorprintoptions/#onlyarea) [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage) vykreslí rozsah jako PNG obrázek. Pomocník vrátí nový vstupní stream obsahující PNG obrázek, umístěný na jeho začátku pro použití v prezentaci.

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

### **Změna velikosti oblasti buněk**

Tento přístup upravuje výšky vybraných řádků a šířky vybraných sloupců tak, aby odpovídaly vlastní velikosti OLE rámečku.

Příklad načítá existující sešit Excel a pomocí nulových indexů vybírá prvních 10 řádků a 13 sloupců z jeho prvního listu. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) určuje zobrazovaný rozsah a níže uvedený pomocník mění tento rozsah tak, aby se vešel do rámečku širokého 400 bodů a vysokého 100 bodů. Po uložení upraveného sešitu do streamu [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) vloží jej v určené velikosti. Náhled vykreslený při 96 DPI je přiřazen přes [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), takže uložená prezentace zobrazuje vybrané buňky místo výchozího zástupného textu.

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

    // Vložte upravený sešit a uchovejte binární data v byte polích Javy.
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

Nástroj pro změnu měřítka vypočítá samostatné poměry šířky a výšky pro vybraný rozsah, přičemž zachovává relativní šířky jeho sloupců a relativní výšky jeho řádků. Před aplikací převádí vypočtené rozměry z bodů na palce a použije je pomocí [Cells::setColumnWidthInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setcolumnwidthinch) a [Cells::setRowHeightInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setrowheightinch). Vybraný rozsah musí mít nenulovou šířku i výšku.

```php
use aspose\cells\CellsUnitType;

// Šířka a výška jsou očekávané rozměry oblasti buněk v bodech.
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

Tento nástroj pro náhled vykresluje změněný rozsah pomocí [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage). Omezí [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) na tento rozsah, odstraní okraje, záhlaví a zápatí a vrátí PNG stream umístěný na jeho začátku.

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

## **Závěr**

{{% alert color="info" title="Note" %}}

Existují dva přístupy k vyřešení problému se změnou velikosti listu. Vyberte přístup, který nejlépe vyhovuje vašim požadavkům a scénáři použití. Oba přístupy fungují stejným způsobem, ať už jsou prezentace vytvořeny ze šablony nebo od nuly. Navíc neexistuje žádný limit velikosti OLE rámečku v tomto řešení.

{{% /alert %}}

## **Často kladené otázky**

**Proč se vložený list Excelu změní velikost při první aktivaci v PowerPointu?**

Tento jev nastává, protože Excel se při aktivaci snaží zachovat původní velikost okna, zatímco OLE rámeček v PowerPointu má vlastní rozměry. PowerPoint a Excel vyjednávají velikost tak, aby zachovaly poměr stran, což může vést k změně velikosti.

**Je možné tomuto problému se změnou velikosti zcela zabránit?**

Ano. Úpravou velikosti OLE rámečku tak, aby odpovídal velikosti oblasti buněk v Excelu, nebo úpravou velikosti oblasti buněk tak, aby odpovídala požadované velikosti OLE rámečku, lze zabránit nechtěné změně velikosti.

**Kterou metodu škálování mám použít, škálování OLE rámečku nebo škálování oblasti buněk?**

Zvolte **škálování OLE rámečku**, pokud chcete zachovat původní velikosti řádků a sloupců v Excelu. Zvolte **škálování oblasti buněk**, pokud chcete mít v prezentaci pevnou velikost OLE rámečku.

**Budou tyto řešení fungovat, pokud je moje prezentace založena na šabloně?**

Ano. Obě řešení fungují pro prezentace vytvořené ze šablon i od nuly.

**Existuje limit velikosti OLE rámečku při použití těchto metod?**

Ne. Můžete nastavit OLE rámeček na libovolnou velikost, pokud správně nastavíte měřítko.

**Existuje způsob, jak se vyhnout textu zástupného textu „EMBEDDED OLE OBJECT“ v PowerPointu?**

Ano. Po vytvoření snímku cílové oblasti buněk v Excelu a nastavení tohoto snímku jako zástupného obrázku OLE rámečku můžete zobrazit vlastní náhledový obrázek místo výchozího zástupného textu.

## **Související články**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/cs/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/cs/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)