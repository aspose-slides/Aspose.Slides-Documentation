---
title: Fungerande lösning för kalkylbladsstorleksändring
type: docs
weight: 20
url: /sv/php-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- förhandsgranskningsbild
- bildstorleksändring
- Excel
- kalkylblad
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Åtgärda OLE‑storleksändring av Excel‑kalkylblad i presentationer: två sätt att hålla objektramarna konsekventa—skala ramen eller bladet—över PPT‑ och PPTX‑formaten."
---
{{% alert color="info" title="Note" %}}

Excel-ark som bäddas in som OLE‑objekt i en PowerPoint‑presentation med Aspose‑komponenter kan ändra storlek oväntat efter den första aktiveringen. Detta beteende skapar en märkbar visuell skillnad mellan OLE‑objektet före och efter aktiveringen. Den här artikeln förklarar problemet och beskriver två sätt att åtgärda det.

{{% /alert %}}

## **Bakgrund**

I artikeln [Hantera OLE](/slides/sv/php-java/manage-ole/) förklarade vi hur man lägger till en OLE‑ram i en PowerPoint‑presentation med Aspose.Slides för PHP via Java. För att åtgärda [problemet med objektförhandsgranskning](/slides/sv/php-java/object-preview-issue-when-adding-oleobjectframe/) tilldelade vi en bild av det valda kalkylarksområdet till OLE‑ramen. I den resulterande presentationen, när du dubbelklickar på OLE‑ramen som visar kalkylarksbilden, aktiveras Excel‑arbetsboken. Slutanvändare kan göra önskade ändringar i den faktiska Excel‑arbetsboken och sedan återgå till bilden genom att klicka utanför den aktiverade Excel‑arbetsboken. Storleken på OLE‑ramen ändras när användaren återvänder till bilden. Förstoringsfaktorn varierar beroende på OLE‑ramens storlek och den inbäddade Excel‑arbetsbokens storlek.

## **Orsak till storleksändring**

Eftersom Excel‑arbetsboken har sin egen fönsterstorlek försöker den behålla sin ursprungliga storlek vid första aktiveringen. Å andra sidan har OLE‑ramen sin egen storlek. Enligt Microsoft, när Excel‑arbetsboken aktiveras, förhandlar Excel och PowerPoint om storleken för att säkerställa att den behåller korrekta proportioner som en del av inbäddningsprocessen. Storleksändringen sker baserat på skillnaderna mellan Excel‑fönstrets storlek och OLE‑ramens storlek och position.

## **Fungerande lösning**

Det finns två möjliga lösningar för att undvika storleksändringseffekten.

- Skala OLE‑ramen i PowerPoint‑presentationen så att den matchar den totala höjden och bredden på de valda raderna och kolumnerna.
- Håll OLE‑ramens storlek konstant och skala de valda raderna och kolumnerna så att de får plats i den.

### **Skala OLE‑ramens storlek**

Detta tillvägagångssätt sätter OLE‑ramens storlek så att den matchar den totala höjden och bredden på de valda raderna och kolumnerna i det inbäddade Excel‑arket.

Exemplet laddar en befintlig Excel‑arbetsbok och väljer de första 10 raderna och 13 kolumnerna i det första bladet med nollbaserade index. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) definierar det visade intervallet. Förhandsgranskningen renderas med 96 DPI, och dess pixeldimensioner konverteras till punkter med 72 punkter per tum. [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) bäddar in den ändrade arbetsboken i en ram med dessa dimensioner. Förhandsgranskningen tilldelas via [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) för att ersätta platshållaren "EMBEDDED OLE OBJECT" i den sparade presentationen.

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

    // Bädda in den modifierade arbetsboken och behåll binära data i Java-bytearrayer.
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

Förhandsgranskningshjälpen sätter [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) till det valda intervallet och tar bort marginaler, sidhuvuden och sidfötter. Med [ImageOrPrintOptions::setOnlyArea](https://reference.aspose.com/cells/php/aspose.cells/imageorprintoptions/#onlyarea) aktiverat renderar [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage) intervallet som en PNG‑bild. Hjälpen returnerar en ny inmatningsström som innehåller PNG‑bilden, placerad i början för användning i presentationen.

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

### **Skala cellintervallens storlek**

Detta tillvägagångssätt skalar höjden på de valda raderna och bredden på de valda kolumnerna så att de matchar en anpassad OLE‑ramstorlek.

Exemplet laddar en befintlig Excel‑arbetsbok och väljer de första 10 raderna och 13 kolumnerna i det första bladet med nollbaserade index. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) definierar det visade intervallet, och hjälpen nedan skalar det intervallet så att det passar en ram som är 400 punkter bred och 100 punkter hög. Efter att den ändrade arbetsboken sparats till en ström bäddar [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) in den med den angivna storleken. En förhandsgranskning renderad med 96 DPI tilldelas via [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), så den sparade presentationen visar de valda cellerna istället för standardplatshållaren.

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

    // Bädda in den modifierade arbetsboken och behåll binära data i Java-bytearrayer.
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

Skaleringshjälpen beräknar separata bredd‑ och höjd‑förhållanden för det valda intervallet, vilket bevarar de relativa bredden på kolumnerna och den relativa höjden på raderna. Den konverterar de beräknade måtten från punkter till tum innan de tillämpas med [Cells::setColumnWidthInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setcolumnwidthinch) och [Cells::setRowHeightInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setrowheightinch). Det valda intervallet måste ha en bredd och höjd som är skild från noll.

```php
use aspose\cells\CellsUnitType;

// Bredd och höjd är de förväntade dimensionerna för cellintervallet i punkter.
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

Denna förhandsgranskningshjälp renderar det skalade intervallet med [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage). Den begränsar [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) till det intervallet, tar bort marginaler, sidhuvuden och sidfötter och returnerar en PNG‑ström placerad i början.

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

## **Slutsats**

{{% alert color="info" title="Note" %}}

Det finns två tillvägagångssätt för att lösa problemet med att kalkylbladet ändrar storlek. Välj det tillvägagångssätt som bäst passar dina krav och ditt användningsområde. Båda tillvägagångssätten fungerar på samma sätt, oavsett om presentationerna skapas från en mall eller från grunden. Dessutom finns det ingen gräns för storleken på OLE‑ramen i denna lösning.

{{% /alert %}}

## **Vanliga frågor**

**Varför ändrar ett inbäddat Excel‑ark storlek när det aktiveras för första gången i PowerPoint?**

Det beror på att Excel försöker behålla sitt ursprungliga fönsterstorlek vid aktivering, medan OLE‑ramen i PowerPoint har sina egna dimensioner. PowerPoint och Excel förhandlar om storleken för att bevara bildförhållandet, vilket kan leda till storleksändring.

**Är det möjligt att helt förhindra detta storleksändringsproblem?**

Ja. Genom att skala OLE‑ramen så att den matchar Excel‑cellintervallens storlek eller skala cellintervallet så att det passar den önskade OLE‑ramstorleken kan du förhindra oönskad storleksändring.

**Vilken skalningsmetod bör jag använda, OLE‑ramsskalning eller cellintervallsskalning?**

Välj **OLE‑ramsskalning** om du vill behålla de ursprungliga rad‑ och kolumnstorlekarna i Excel. Välj **cellintervallsskalning** om du vill ha en fast storlek på OLE‑ramen i presentationen.

**Fungerar dessa lösningar om min presentation bygger på en mall?**

Ja. Båda lösningarna fungerar för presentationer som skapats från mallar och från grunden.

**Finns det någon gräns för storleken på OLE‑ramen när man använder dessa metoder?**

Nej. Du kan göra OLE‑objektramen vilken storlek du vill så länge du ställer in skalan på rätt sätt.

**Finns det ett sätt att undvika platshållartexten "EMBEDDED OLE OBJECT" i PowerPoint?**

Ja. Genom att ta en ögonblicksbild av det mål‑Excel‑cellintervall du vill visa och ange den som OLE‑ramens platshållarbild kan du visa en anpassad förhandsgranskningsbild i stället för standardplatshållaren.

## **Relaterade artiklar**

[Skapa ett Excel‑diagram och bädda in det i en presentation som ett OLE‑objekt](/slides/sv/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Uppdatera OLE‑objekt automatiskt med ett MS PowerPoint‑tillägg](/slides/sv/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)