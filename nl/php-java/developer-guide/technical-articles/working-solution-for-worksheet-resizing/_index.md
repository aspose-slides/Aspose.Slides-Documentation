---
title: Werkende oplossing voor werkbladformaatverandering
type: docs
weight: 20
url: /nl/php-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- voorbeeldafbeelding
- afbeeldingsgrootte aanpassen
- Excel
- werkblad
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Verhelp OLE-grootteaanpassing van Excel-werkbladen in presentaties: twee manieren om objectframes consistent te houden — schaal het frame of het blad — voor PPT- en PPTX-formaten."
---
{{% alert color="info" title="Opmerking" %}}

Excel‑werkbladen die als OLE‑objecten in een PowerPoint‑presentatie zijn ingebed met Aspose‑componenten, kunnen onverwacht van formaat veranderen na de eerste activering. Dit gedrag veroorzaakt een duidelijk visueel verschil tussen het OLE‑object vóór en na activering. Dit artikel legt het probleem uit en beschrijft twee manieren om het op te lossen.

{{% /alert %}}

## **Achtergrond**

In het artikel [Beheer OLE](/slides/nl/php-java/manage-ole/), legden we uit hoe een OLE‑frame aan een PowerPoint‑presentatie kan worden toegevoegd met Aspose.Slides voor PHP via Java. Om het [probleem met voorbeeldweergave van object](/slides/nl/php-java/object-preview-issue-when-adding-oleobjectframe/) aan te pakken, hebben we een afbeelding van het geselecteerde werkbladgebied toegewezen aan het OLE‑objectframe. In de gegenereerde presentatie, wanneer u dubbelklikt op het OLE‑objectframe dat de werkbladafbeelding toont, wordt de Excel‑werkmap geactiveerd. Eindgebruikers kunnen gewenste wijzigingen aanbrengen in de daadwerkelijke Excel‑werkmap en vervolgens terugkeren naar de dia door buiten de geactiveerde Excel‑werkmap te klikken. De grootte van het OLE‑objectframe verandert wanneer de gebruiker terugkeert naar de dia. De vergrotingsfactor varieert afhankelijk van de grootte van het OLE‑objectframe en de ingebedde Excel‑werkmap.

## **Oorzaak van formaatverandering**

Aangezien de Excel‑werkmap een eigen venstergrootte heeft, probeert deze bij de eerste activering de oorspronkelijke grootte te behouden. Het OLE‑objectframe heeft echter zijn eigen afmetingen. Volgens Microsoft onderhandelen Excel en PowerPoint over de grootte wanneer de Excel‑werkmap wordt geactiveerd, om ervoor te zorgen dat de juiste verhoudingen behouden blijven als onderdeel van het insluitingsproces. De grootte‑aanpassing ontstaat door de verschillen tussen de Excel‑venstergrootte en de afmetingen en positie van het OLE‑objectframe.

## **Werkende oplossing**

Er zijn twee mogelijke oplossingen om het formaatveranderings‑effect te voorkomen.

- Schaal het OLE‑frame in de PowerPoint‑presentatie zodat het overeenkomt met de totale hoogte en breedte van de geselecteerde rijen en kolommen.
- Houd de afmetingen van het OLE‑frame constant en schaal de geselecteerde rijen en kolommen zodat ze erin passen.

### **Schaal de OLE‑framegrootte**

Deze aanpak stelt de afmetingen van het OLE‑frame in zodat ze overeenkomen met de totale hoogte en breedte van de geselecteerde rijen en kolommen in het ingebedde Excel‑werkblad.

Het voorbeeld laadt een bestaande Excel‑werkmap en selecteert de eerste 10 rijen en 13 kolommen van het eerste werkblad met nul‑gebaseerde indexen. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) bepaalt het weer te geven bereik. De voorbeeldweergave wordt gerenderd op 96 DPI en de pixelafmetingen worden omgezet naar punten met 72 punten per inch. [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) embedde de aangepaste werkmap in een frame met die afmetingen. De voorbeeldweergave wordt toegewezen via [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) om de tijdelijke aanduiding "EMBEDDED OLE OBJECT" in de opgeslagen presentatie te vervangen.

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

    // Insluit de aangepaste werkmap en bewaar binaire gegevens in Java-byte arrays.
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

De preview‑helper stelt [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) in op het geselecteerde bereik en verwijdert marges, kop‑ en voetteksten. Met [ImageOrPrintOptions::setOnlyArea](https://reference.aspose.com/cells/php/aspose.cells/imageorprintoptions/#onlyarea) ingeschakeld rendert [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage) het bereik als een PNG‑afbeelding. De helper retourneert een nieuwe input‑stream met de PNG‑afbeelding, gepositioneerd aan het begin voor gebruik in de presentatie.

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

### **Schaal de celbereikgrootte**

Deze aanpak schaalt de hoogtes van de geselecteerde rijen en de breedtes van de geselecteerde kolommen om een aangepaste OLE‑framegrootte te evenaren.

Het voorbeeld laadt een bestaande Excel‑werkmap en selecteert de eerste 10 rijen en 13 kolommen van het eerste werkblad met nul‑gebaseerde indexen. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) bepaalt het weergegeven bereik, en de helper hieronder schaalt dat bereik om te passen in een frame van 400 punten breed en 100 punten hoog. Na het opslaan van de aangepaste werkmap naar een stream embedde [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) deze met de opgegeven afmeting. Een voorbeeldweergave gerenderd op 96 DPI wordt toegewezen via [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), zodat de opgeslagen presentatie de geselecteerde cellen toont in plaats van de standaard tijdelijke aanduiding.

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

    // Insluit de aangepaste werkmap en bewaar binaire gegevens in Java-byte arrays.
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

De schaal‑helper berekent afzonderlijke breedte‑ en hoogteratio’s voor het geselecteerde bereik, waarbij de relatieve breedtes van de kolommen en de relatieve hoogtes van de rijen behouden blijven. Hij zet de berekende afmetingen om van punten naar inches vóór dat ze worden toegepast met [Cells::setColumnWidthInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setcolumnwidthinch) en [Cells::setRowHeightInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setrowheightinch). Het geselecteerde bereik moet een niet‑nul breedte en hoogte hebben.

```php
use aspose\cells\CellsUnitType;

// Breedte en hoogte zijn de verwachte afmetingen van het celbereik in punten.
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

Deze preview‑helper rendert het geschaalde bereik met behulp van [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage). Hij beperkt [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) tot dat bereik, verwijdert marges, kop‑ en voetteksten, en retourneert een PNG‑stream die aan het begin gepositioneerd is.

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

## **Conclusie**

{{% alert color="info" title="Opmerking" %}}

Er zijn twee benaderingen om het probleem met de formaatverandering van het werkblad op te lossen. Kies de benadering die het beste bij uw eisen en gebruikssituatie past. Beide benaderingen werken op dezelfde manier, ongeacht of de presentaties vanuit een sjabloon of vanaf nul worden gemaakt. Bovendien is er geen limiet aan de grootte van het OLE‑objectframe in deze oplossing.

{{% /alert %}}

## **Veelgestelde vragen**

**Waarom verandert een ingebed Excel‑werkblad van grootte wanneer het voor het eerst wordt geactiveerd in PowerPoint?**

Dit gebeurt omdat Excel bij activatie probeert de oorspronkelijke venstergrootte te behouden, terwijl het OLE‑objectframe in PowerPoint zijn eigen afmetingen heeft. PowerPoint en Excel onderhandelen over de grootte om de beeldverhouding te behouden, wat de formaatverandering kan veroorzaken.

**Is het mogelijk om dit formaatveranderingsprobleem volledig te voorkomen?**

Ja. Door het OLE‑frame te schalen zodat het past bij de grootte van het Excel‑celbereik of door het celbereik te schalen naar de gewenste OLE‑framegrootte, kunt u ongewenste formaatverandering voorkomen.

**Welke schaalmethode moet ik gebruiken, OLE‑frame schalen of celbereik schalen?**

Kies **OLE‑frame schalen** als u de oorspronkelijke rij‑ en kolomgroottes van Excel wilt behouden. Kies **celbereik schalen** als u een vaste grootte voor het OLE‑frame in uw presentatie wilt.

**Werken deze oplossingen als mijn presentatie gebaseerd is op een sjabloon?**

Ja. Beide oplossingen werken voor presentaties die vanuit sjablonen of vanaf nul zijn gemaakt.

**Is er een limiet aan de grootte van het OLE‑frame bij het gebruik van deze methoden?**

Nee. U kunt het OLE‑objectframe elke gewenste grootte geven, zolang u de schaal correct instelt.

**Is er een manier om de tijdelijke aanduiding "EMBEDDED OLE OBJECT" in PowerPoint te vermijden?**

Ja. Door een snapshot van het doel‑Excel‑celbereik te maken en deze in te stellen als de tijdelijke‑plaatstafbeelding van het OLE‑frame, kunt u een aangepaste voorbeeldafbeelding weergeven in plaats van de standaard tijdelijke aanduiding.

## **Gerelateerde artikelen**

[Een Excel‑grafiek maken en inbedden in een presentatie als OLE‑object](/slides/nl/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[OLE‑objecten automatisch bijwerken met een MS PowerPoint‑addin](/slides/nl/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)