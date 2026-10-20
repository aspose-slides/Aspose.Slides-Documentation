---
title: Werkende oplossing voor het schalen van grafieken in PPTX
type: docs
weight: 40
url: /nl/php-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- grafiek schalen
- Excel-grafiek
- OLE-object
- grafiek insluiten
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Los onverwachte grafiekverkleining in PPTX op bij gebruik van ingesloten Excel OLE-objecten met Aspose.Slides for PHP via Java. Stel vaste grafiekafmetingen in om de grafiek- en OLE-framegroottes consistent te houden."
---
## **Overzicht**

Excel‑grafieken die als OLE‑objecten in PowerPoint‑presentaties worden ingebed met Aspose‑componenten, kunnen van grootte veranderen na hun eerste activering. Dit kan een merkbaar verschil in het uiterlijk van de grafiek veroorzaken vóór en na de activering. Dit artikel legt uit waarom het schalen gebeurt en laat zien hoe u dit kunt voorkomen door vaste grafiekafmetingen af te stemmen op het OLE‑frame.

In [Excel‑grafieken maken en insluiten als OLE‑objecten in presentaties](/slides/nl/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) legden we uit hoe u een Excel‑grafiek maakt met Aspose.Cells for PHP via Java en deze insluit in een PowerPoint‑presentatie met Aspose.Slides for PHP via Java. Om het [object preview issue](/slides/nl/php-java/object-preview-issue-when-adding-oleobjectframe/) aan te pakken, hebben we de grafiekafbeelding toegewezen aan het OLE‑objectframe van de grafiek. In de gegenereerde presentatie, wanneer u dubbelklikt op het OLE‑objectframe dat de grafiekafbeelding toont, wordt de Excel‑grafiek geactiveerd. Gebruikers kunnen de ingebedde Excel‑werkmap bewerken en vervolgens door buiten de geactiveerde werkmap te klikken, terugkeren naar de dia. De grootte van het OLE‑objectframe verandert wanneer de gebruiker terugkeert naar de dia, en de schaalfactor varieert afhankelijk van de oorspronkelijke groottes van zowel het OLE‑objectframe als de ingebedde Excel‑werkmap.

## **Oorzaak van de schaalverandering**

De ingebedde Excel‑werkmap heeft eigen venstergroottes, die Excel probeert te behouden wanneer het object voor het eerst wordt geactiveerd. Het OLE‑frame op de dia heeft onafhankelijk gedefinieerde afmetingen. Wanneer de Excel‑werkmap wordt geactiveerd, onderhandelen Excel en PowerPoint over de grootte van het object om de verhoudingen te behouden als onderdeel van het insluitingsproces. Verschillen tussen het werkmapvenster en het OLE‑frame kunnen daarom leiden tot het herschalen van het object.

## **Werkende oplossing**

Stem de grafiekgrootte af op het OLE‑frame op de dia en houd de grafiekafmetingen onafhankelijk van het werkmapvenster. Deze oplossing werkt met een nieuwe presentatie of een bestaand sjabloon.

Het voorbeeld vereist Aspose.Cells for PHP via Java en Aspose.Slides for PHP via Java. Configureer beide producten met dezelfde PHP/Java‑Bridge‑instantie, laad beide PHP‑wrappers en maak beide Java‑bibliotheken beschikbaar voor de bridge. Er zijn geen invoerbestanden nodig. Het maakt een eenvoudige kolomgrafiek op een actieve grafiekblad en embedt de werkmap in XLS‑formaat. Er wordt geen voorbeeldafbeelding voor de grafiek toegewezen; de grafiek wordt zichtbaar wanneer het OLE‑object wordt geactiveerd in PowerPoint.

Het voorbeeld maakt een nieuwe presentatie met een OLE‑frame van 9,5 × 4 inch, geplaatst 0,5 inch vanaf de linkerrand en 1 inch vanaf de bovenkant. Dia‑coördinaten en afmetingen worden in points opgeslagen (72 points per inch). Voor een bestaande presentatie, zie [Gebruik een sjabloon](#use-a-template).

## **Stel een vaste grafiekgrootte in**

Stel [Chart::setSizeWithWindow](https://reference.aspose.com/cells/php/aspose.cells/chart/#sizewithwindow) in op false zodat de grafiekafmetingen onafhankelijk zijn van het werkmapvenster. Stel de dimensies van [Chart::getChartObject](https://reference.aspose.com/cells/php/aspose.cells/chart/#chartobject) in via [Shape::setWidth](https://reference.aspose.com/cells/php/aspose.cells/shape/#width) en [Shape::setHeight](https://reference.aspose.com/cells/php/aspose.cells/shape/#height), waarbij points naar pixels worden omgerekend met 96 pixels per inch: een frame van 684 × 288 points komt overeen met een grafiek van 912 × 384 pixels. Stel [Chart::setPrintSize](https://reference.aspose.com/cells/php/aspose.cells/chart/#printsize) in op de CUSTOM‑waarde van [PrintSizeType](https://reference.aspose.com/cells/php/aspose.cells/printsizetype/). Het voorbeeld embedt de werkmap met [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) en slaat een presentatie op met een OLE‑frame van 9,5 × 4 inch.

Java‑numerieke resultaten worden geconverteerd met `java_values` voordat ze worden gebruikt als PHP‑indices. De bytes van de werkmap blijven in een Java‑byte‑array wanneer ze worden doorgegeven aan [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/).

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\FileFormatType;
use aspose\cells\PrintSizeType;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("Data");
    $dataSheet->getCells()->get("A1")->putValue(10);
    $dataSheet->getCells()->get("A2")->putValue(20);

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, 20, 10));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    $chart->getNSeries()->add("Data!A1:A2", true);
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);

    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Dia-coördinaten en afmetingen zijn in points (72 points per inch).
        $width = 684; // 9,5 inches.
        $height = 288; // 4 inches.

        $chart->setSizeWithWindow(false);
        // Converteer points naar grafiekpixels met 96 pixels per inch.
        $chart->getChartObject()->setWidth((int)($width / 72 * 96));
        $chart->getChartObject()->setHeight((int)($height / 72 * 96));
        $chart->setPrintSize(PrintSizeType::CUSTOM);

        $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
        $workbook->save($workbookStream, FileFormatType::EXCEL_97_TO_2003);
        $workbookBytes = $workbookStream->toByteArray();
        $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xls");
        $slide->getShapes()->addOleObjectFrame(36, 72, $width, $height, $dataInfo);

        $presentation->save("chart-fixed-size.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **Gebruik een sjabloon**

De logica voor het bepalen van de grootte is dezelfde voor een bestaande presentatie. Pas het voorbeeld aan als volgt:

1. Laad de sjabloonpresentatie in plaats van een lege presentatie te maken.  
2. Controleer of de eerste dia minstens drie shapes bevat, en gebruik vervolgens de shape op index 2 als placeholder.  
3. Neem de breedte en hoogte van het frame uit die shape in plaats van de vaste waarden 684 en 288. Houd de berekeningen voor de afmetingen ongewijzigd.  
4. Voeg het OLE‑frame toe op de positie van de placeholder in plaats van de vaste coördinaten 36 en 72.  
5. Verwijder de placeholder vóór het opslaan van de presentatie.

## **Veelgestelde vragen**

**Waarom verandert mijn ingebedde Excel‑grafiek van grootte nadat deze geactiveerd is in PowerPoint?**

Dit gebeurt omdat Excel probeert de oorspronkelijke venstergrootte te herstellen bij de eerste activering, terwijl het OLE‑objectframe in PowerPoint eigen afmetingen heeft. PowerPoint en Excel onderhandelen over de grootte om de beeldverhouding te behouden, wat kan leiden tot het herschalen.

**Hoe kan ik de afmetingen van de grafiek en het OLE‑frame consistent houden?**

Stel vaste grafiekafmetingen in die overeenkomen met het OLE‑frame en gebruik een aangepaste grafiek‑printgrootte voordat u de werkmap embedt. Het bovenstaande voorbeeld toont de benodigde instellingen en eenheden‑omrekeningen.

**Is het afstemmen van de grootte van het werkbladvenster voldoende?**

Alleen het afstemmen van de grootte van het werkbladvenster voorkomt niet betrouwbaar dat het OLE‑frame van grootte verandert na activering. Gebruik vaste grafiekafmetingen zoals in het voorbeeld weergegeven.

**Werkt deze oplossing zowel voor op sjablonen gebaseerde presentaties als voor nieuwe presentaties?**

Ja. Voor een sjabloon gebruikt u de afmetingen en positie van de placeholder. Voor een nieuwe presentatie specificeert u de frame‑afmetingen en positie rechtstreeks.

**Kan ik dit voorbeeld gebruiken met grafieken die zijn gemaakt in andere spreadsheetprogramma's?**

Het voorbeeld maakt gebruik van een Excel‑werkmap die is aangemaakt met Aspose.Cells. Het demonstreert geen activatie‑gedrag voor andere spreadsheetprogramma's.

## **Gerelateerde secties**

- [Excel‑grafieken maken en insluiten als OLE‑objecten in presentaties](/slides/nl/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)