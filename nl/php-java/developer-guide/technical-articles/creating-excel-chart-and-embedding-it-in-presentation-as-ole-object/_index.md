---
title: Creëer Excel‑grafieken en embed ze in presentaties als OLE‑objecten
type: docs
weight: 30
url: /nl/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel‑grafiek
- grafiek insluiten
- OLE‑object
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Creëer een Excel‑grafiek met Aspose.Cells for PHP via Java en embed het werkboek in een PowerPoint‑presentatie met Aspose.Slides for PHP via Java, inclusief een voorbeeld van de grafiek."
---
## **Overzicht**

Dit artikel toont hoe u een Excel‑kolomgrafiek maakt met Aspose.Cells for PHP via Java en de werkmap erin inbedt in een PowerPoint‑presentatie met Aspose.Slides for PHP via Java. De ingebedde werkmap bevat zowel de brongegevens als de grafiek. Een aparte PNG‑voorbeeldweergave toont de grafiek op de dia voordat het OLE‑object wordt geactiveerd.

Het resultaat is een ingebed Excel‑object, geen native PowerPoint‑grafiek. Het bewerken van de werkmap via OLE vereist een desktop‑applicatie die OLE‑activatie ondersteunt en een compatibele Excel‑installatie.

## **Vereisten**

Configureer Aspose.Cells for PHP via Java en Aspose.Slides for PHP via Java met dezelfde PHP/Java Bridge‑instantie. Laad beide PHP‑wrappers en maak de Java‑bibliotheken van beide producten beschikbaar voor de bridge. Microsoft Office is niet vereist om de presentatie te genereren met deze bibliotheken.

Er zijn geen invoerbestanden nodig: het voorbeeld maakt de gegevens en de grafiek in het geheugen, waarna het `OutputChart.pptx` schrijft naar de huidige werkmap. Pas licenties toe voor beide producten wanneer u buiten de evaluatiemodus werkt.

## **Hoe de insluiting werkt**

1. Maak een werkmap met een gegevenswerkblad en een grafiekblad.  
1. Maak het grafiekblad actief zodat de werkmap opent op de grafiek.  
1. Stel het OLE‑weergavebereik van de werkmap in en render de grafiek naar PNG.  
1. Sla de werkmap op als XLSX in het geheugen en embed die bytes in een dia.  
1. Wijs de PNG toe als voorbeeld van het OLE‑object en sla de presentatie op als PPTX.

Het weergavebereik van de werkmap en het frame op de dia hebben verschillende rollen. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) neemt nulgebaseerde begin/eind‑rij‑ en kolomindices. [ChartCollection::add](https://reference.aspose.com/cells/php/aspose.cells/chartcollection/#add) neemt in plaats daarvan de bovenste rij, de linkerkolom, de onderste rij en de rechterkolom. Het voorbeeld gebruikt rij‑index 55 en kolom‑index 25 als de rechter‑onder‑grenzen; deze waarden zijn layout‑keuzes, geen aantal gegevensrijen of -kolommen.

Het dia‑frame gebruikt punten. Het voorbeeld past het binnen de dia en centreert het terwijl de beeldverhouding van de PNG behouden blijft, in plaats van de voorbeeldweergave uit te rekken om de dia te vullen.

## **Maak en voeg de grafiek in**

Het onderstaande volledige voorbeeld vult `DataSheet` met vier rijen en vijf kolommen waarden. Elke rij wordt een grafiekreeks. `ChartSheet` wordt geselecteerd als het actieve blad voordat de werkmap wordt opgeslagen.

De werkmap wordt expliciet opgeslagen als XLSX, passend bij de `xlsx`‑extensie die wordt meegegeven aan [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/). Java‑numerieke resultaten worden geconverteerd met `java_values` voordat PHP rekenkundige bewerkingen uitvoert, terwijl binaire gegevens blijven in Java‑byte‑arrays. De PNG wordt direct uit de bytes geladen zonder een tussenliggende bitmap‑conversie. Toewijzing via [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) vervangt de standaard OLE‑plaatsaanduiding.

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("DataSheet");
    $values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];
    foreach ($values as $row => $rowValues) {
        foreach ($rowValues as $column => $value) {
            $dataSheet->getCells()->get($row, $column)->putValue($value);
        }
    }

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartSheet->setName("ChartSheet");
    $lastChartRow = 55;
    $lastChartColumn = 25;
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, $lastChartRow, $lastChartColumn));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    for ($row = 1; $row <= count($values); $row++) {
        $chart->getNSeries()->add("DataSheet!A" . $row . ":E" . $row, false);
    }
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);
    $workbook->getWorksheets()->setOleSize(0, $lastChartRow, 0, $lastChartColumn);

    // Bewaar de PNG en XLSX als Java‑byte‑arrays wanneer je ze doorgeeft aan Slides.
    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $chartImageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $chart->toImage($chartImageStream, $imageOptions);
    $chartImageBytes = $chartImageStream->toByteArray();

    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();

    $chartImage = Images::fromData($chartImageBytes);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $slideWidth = java_values($presentation->getSlideSize()->getSize()->getWidth());
            $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
            $imageWidth = java_values($chartImage->getWidth());
            $imageHeight = java_values($chartImage->getHeight());

            // Pas de voorbeeldweergave aan en centreer deze terwijl de beeldverhouding behouden blijft.
            $scale = min($slideWidth / $imageWidth, $slideHeight / $imageHeight);
            $frameWidth = $imageWidth * $scale;
            $frameHeight = $imageHeight * $scale;
            $frameX = ($slideWidth - $frameWidth) / 2;
            $frameY = ($slideHeight - $frameHeight) / 2;

            $embeddedData = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame($frameX, $frameY, $frameWidth, $frameHeight, $embeddedData);
            $previewImage = $presentation->getImages()->addImage($chartImage);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $presentation->save("OutputChart.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $chartImage->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **Verwacht resultaat**

`OutputChart.pptx` bevat één dia met een ingebedde Excel‑werkmap en een voorbeeld van de grafiek. De werkmap bevat de oorspronkelijke gegevens en een kolomgrafiek met vier reeksen. Het voorbeeld staat gecentreerd op de dia en behoudt zijn verhoudingen.

![Excel‑kolomgrafiek weergegeven als voorbeeld van een ingebedde werkmap](excel-chart-ole-preview.png)

In een compatibele desktop‑PowerPoint‑omgeving met Excel beschikbaar, dubbelklik op het object om de ingebedde werkmap te activeren en te bewerken. Activatie en bewerking hangen af van de OLE‑ondersteuning en beveiligingsinstellingen van de host‑applicatie.

## **Veelgestelde vragen**

**Waarom is een voorbeeldafbeelding nodig?**

De ingebedde werkmap en zijn dia‑voorbeeld zijn afzonderlijke inhoud. Voorzie een grafiekafbeelding zodat de dia de grafiek toont in plaats van de standaardplaceholder "EMBEDDED OLE OBJECT". Zie [Probleem met voorbeeldobject bij het toevoegen van OleObjectFrame](/slides/nl/php-java/object-preview-issue-when-adding-oleobjectframe/).

**Werkt de voorbeeldafbeelding automatisch bij wanneer ik de werkmap in code wijzig?**

Beschouw de voorbeeldweergave als een momentopname. Bij het programmatisch bijwerken van de werkmapgegevens moet u de grafiekafbeelding opnieuw genereren en zowel de voorbeeldweergave als de ingebedde werkmapgegevens vervangen.

**Kan ik XLS gebruiken in plaats van XLSX?**

Ja. Sla de werkmap op in XLS‑formaat en gebruik `xls` als de extensie van de ingebedde gegevens. De extensie moet overeenkomen met het daadwerkelijke werkmapformaat; alleen de extensie wijzigen converteert de gegevens niet.

**Waarom kan het object van grootte veranderen na activatie?**

De host‑applicatie kan de weergave van het OLE‑object bijwerken wanneer ze de werkmap activeert. Het OLE‑weergavebereik van de werkmap en de afmetingen van het dia‑frame zijn beide van belang. Zie [Werkende oplossing voor grafiekgrootte aanpassen in PPTX](/slides/nl/java/working-solution-for-chart-resizing-in-pptx/).

## **Gerelateerde secties**

- [Werkende oplossing voor grafiekgrootte aanpassen in PPTX](/slides/nl/java/working-solution-for-chart-resizing-in-pptx/)
- [Probleem met voorbeeldobject bij het toevoegen van OleObjectFrame](/slides/nl/php-java/object-preview-issue-when-adding-oleobjectframe/)
- [Beheer OLE‑objecten](/slides/nl/php-java/manage-ole/)