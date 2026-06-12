---
title: Integratie van Excel‑gegevens in PowerPoint‑presentaties
linktitle: Excel‑integratie
type: docs
weight: 330
url: /nl/php-java/excel-integration/
keywords:
- Excel
- werkmap
- Excel lezen
- Excel integreren
- gegevensbron
- mail‑merge
- tabel importeren
- Excel naar PowerPoint
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Lees gegevens uit Excel‑werkmappen met Aspose.Slides voor PHP via Java. Laad bladen en cellen en gebruik de waarden om data‑gedreven PowerPoint‑presentaties te genereren."
---
## **Inleiding**

PowerPoint‑presentaties zijn een krachtige manier om informatie weer te geven en te communiceren. Ze worden vaak in combinatie gebruikt met Excel‑werkmappen, waarbij Excel een uitstekende bron van gestructureerde gegevens biedt en PowerPoint die gegevens visueel aantrekkelijk maakt voor een publiek.

Er zijn veel praktische scenario’s waarbij het combineren van Excel en PowerPoint essentieel is: mail‑merges, gegevens‑tabellen vullen, één dia per gegevensrecord genereren (batch‑dia‑generatie), trainingsmateriaal maken en meerdere Excel‑rapporten consolideren tot één presentatie, om er maar een paar te noemen.

Tot nu toe vereiste het implementeren van zulke functies met de Aspose.Slides‑API dat er op derde‑partij‑oplossingen zoals Aspose.Cells werd vertrouwd. Hoewel deze hulpmiddelen robuust zijn, kunnen ze onnodig complex en kostbaar zijn voor gebruikers die alleen basis‑integratie van gegevens nodig hebben.

## **Hoe het werkt**

Om het werken met Excel‑gegevens makkelijker en gestroomlijnder te maken, heeft Aspose.Slides nieuwe klassen geïntroduceerd voor het lezen van gegevens uit Excel‑werkmappen en het importeren van inhoud in een presentatie. Deze functie biedt krachtige nieuwe mogelijkheden voor API‑gebruikers die Excel willen benutten als gegevensbron binnen hun presentatieworkflows.

De nieuwe functionaliteit is ontworpen voor algemeen gegevens‑toegang en is niet geïntegreerd in het Presentation Document Object Model (DOM). Dat betekent dat *het niet mogelijk is om Excel‑bestanden te bewerken of op te slaan* — het enige doel is werkmappen te openen en door hun inhoud te navigeren om celwaarden op te halen.

In het hart van deze functie staat de nieuwe [ExcelDataWorkbook](https://reference.aspose.com/slides/nl/php-java/aspose.slides/exceldataworkbook/)‑klasse. Deze klasse stelt je in staat een Excel‑werkmap te laden vanuit een lokaal bestand of een stream. Eenmaal geladen biedt hij verschillende overloads van de [getCell](https://reference.aspose.com/slides/nl/php-java/aspose.slides/exceldataworkbook/#getCell)‑methode, waarmee je specifieke cellen kunt ophalen op basis van hun positie (bijvoorbeeld rij‑ en kolom‑indices of benoemde bereiken).

Elke oproep naar [getCell](https://reference.aspose.com/slides/nl/php-java/aspose.slides/exceldataworkbook/#getCell) geeft een instantie van de [ExcelDataCell](https://reference.aspose.com/slides/nl/php-java/aspose.slides/exceldatacell/)‑klasse terug. Dit object vertegenwoordigt één cel in de Excel‑werkmap en geeft je op een eenvoudige en intuïtieve manier toegang tot de waarde ervan.

#### **Importeer een Excel‑diagram**

De volgende stap om functionaliteit uit te breiden is de [ExcelWorkbookImporter](https://reference.aspose.com/slides/nl/php-java/aspose.slides/excelworkbookimporter/)‑klasse. Deze hulpprogrammaklasse biedt functionaliteit om inhoud van een Excel‑werkmap te importeren in een presentatie. Hij bevat verschillende overloads van de [addChartFromWorkbook](https://reference.aspose.com/slides/nl/php-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook)‑methode, waarmee je het geselecteerde diagram uit de opgegeven Excel‑werkmap kunt ophalen en toevoegen aan het einde van de opgegeven vormverzameling op de opgegeven coördinaten.

Kortom, het is een lichte en eenvoudige API voor het lezen van Excel‑gegevens — precies wat veel developers nodig hebben zonder de overhead van een volledige spreadsheet‑verwerkingsbibliotheek.

## **Laten we coderen**

### **Voorbeeld van een mail‑merge scenario**

In het onderstaande voorbeeld implementeren we een eenvoudig mail‑merge scenario door meerdere presentaties te genereren op basis van gegevens die zijn opgeslagen in een Excel‑werkmap.

Om te beginnen hebben we twee dingen nodig:
1. Een Excel‑werkmap met de gegevens

![Voorbeeld Excel‑gegevens](example1_image0.png)

2.  PowerPoint‑presentatiesjabloon

![Voorbeeld PowerPoint‑sjabloon](example1_image1.png)

```php
// Laad de Excel-werkmap met gegevens van medewerkers.
$workbook = new ExcelDataWorkbook("TemplateData.xlsx");
$worksheetIndex = 0;

// Laad de presentatiesjabloon.
$templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // Doorloop de Excel-rijen (exclusief koprij op rij 0).
    for ($rowIndex = 1; $rowIndex <= 4; $rowIndex++) {

        // Maak een nieuwe presentatie aan voor elke medewerkerrecord.
        $employeePresentation = new Presentation();

        try {
            // Verwijder de standaard lege dia.
            $employeePresentation->getSlides()->removeAt(0);

            // Kloon de sjabloondia naar de nieuwe presentatie.
            $slide = $employeePresentation->getSlides()->addClone($templatePresentation->getSlides()->get_Item(0));

            // Haal alinea's op uit de doelvorm (veronderstelt dat vormindex 1 wordt gebruikt).
            $paragraphs = $slide->getShapes()->get_Item(1)->getTextFrame()->getParagraphs();

            // Vervang de tijdelijke aanduidingen door gegevens uit Excel.
            $employeeName = $workbook->getCell($worksheetIndex, $rowIndex, 0)->getValue()->toString();
            $namePortion = $paragraphs->get_Item(0)->getPortions()->get_Item(0);
            $namePortion->setText($namePortion->getText()->replace("{{EmployeeName}}", $employeeName));

            $department = $workbook->getCell($worksheetIndex, $rowIndex, 1)->getValue()->toString();
            $departmentPortion = $paragraphs->get_Item(1)->getPortions()->get_Item(0);
            $departmentPortion->setText($departmentPortion->getText()->replace("{{Department}}", $department));

            $yearsOfService = $workbook->getCell($worksheetIndex, $rowIndex, 2)->getValue()->toString();
            $yearsPortion = $paragraphs->get_Item(2)->getPortions()->get_Item(0);
            $yearsPortion->setText($yearsPortion->getText()->replace("{{YearsOfService}}", $yearsOfService));

            // Sla de gepersonaliseerde presentatie op in een apart bestand.
            $employeePresentation->save(sprintf("%s Report.pptx", $employeeName), SaveFormat::Pptx);
        } finally {
            $employeePresentation->dispose();
        }
    }
} finally {
    $templatePresentation->dispose();
}
```

![Resultaat](example1_image2.png)

### **Voorbeeld van een Excel‑tabel**

In het tweede voorbeeld kopiëren we simpelweg gegevens uit een Excel‑tabel en tonen ze op een PowerPoint‑dia in een meer visueel aantrekkelijke indeling.

In dit voorbeeld hergebruiken we dezelfde Excel‑werkmap als in het eerste voorbeeld, die een eenvoudige medewerkers‑tabel bevat.

```php
// Laad de Excel-werkmap met de gegevens van de medewerkers.
$workbook = new ExcelDataWorkbook("TemplateData.xlsx");
$worksheetIndex = 0;

// Maak een nieuwe PowerPoint-presentatie.
$presentation = new Presentation();

try {
    // Voeg een tabelvorm toe aan de eerste dia.
    $table = $presentation->getSlides()->get_Item(0)->getShapes()->addTable(
            50, 200,
            array(200, 200, 200),
            array(30, 30, 30, 30, 30)
    );

    // Vul de PowerPoint-tabel met gegevens uit de Excel-werkmap.
    for ($rowIndex = 0; $rowIndex < 5; $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < 3; $columnIndex++) {
            $cellValue = $workbook->getCell($worksheetIndex, $rowIndex, $columnIndex)->getValue()->toString();
            $table->getColumns()->get_Item($columnIndex)->get_Item($rowIndex)->getTextFrame()->setText($cellValue);
        }
    }

    // Sla de resulterende presentatie op in een bestand.
    $presentation->save("Table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Resultaat](example2_image0.png)

### **Voorbeeld: een Excel‑diagram importeren**

In dit voorbeeld importeren we een diagram uit het eerste werkblad van de Excel‑werkmap die in het vorige voorbeeld werd gebruikt. Het diagram zal in de resulterende presentatie naar de externe werkmap verwijzen.

Eerst voegen we een cirkeldiagram toe aan de Excel‑werkmap op basis van de medewerkers‑tabel.

![Voorbeeld Excel‑diagram](example3_image0.png)

```php
// Maak een nieuwe PowerPoint-presentatie.
$presentation = new Presentation();
try {
    // Haal de vormverzameling op van de eerste dia.
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    // Importeer het diagram met de naam "Chart 1" uit het eerste blad van de werkmap en voeg het toe aan de vormverzameling.
    ExcelWorkbookImporter::addChartFromWorkbook($shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Sla de resulterende presentatie op in een bestand.
    $presentation->save("Chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Resultaat](example3_image1.png)

### **Voorbeeld: alle Excel‑diagrammen importeren**

Stel je voor dat je een Excel‑werkmap vol diagrammen hebt en je moet ze allemaal importeren in een presentatie. Elk diagram moet op een nieuwe dia worden geplaatst.

De volgende code doorloopt alle werkbladen in het bron‑Excel‑bestand, extraheert de diagrammen uit elk werkblad en voegt elk diagram toe aan een aparte dia met een lege dia‑lay‑out. In de resulterende presentatie wordt alleen de diagram‑data ingebed, niet de volledige werkmap.

```php
// Laad de Excel-werkmap met de gegevens van de medewerkers.
$workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Maak een nieuwe PowerPoint-presentatie.
$presentation = new Presentation();
try {
    // Haal de lege dia‑lay‑out op.
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // Haal de namen op van alle werkbladen die in de Excel-werkmap zitten.
    $worksheetNames = $workbook->getWorksheetNames()->iterator();

    while (java_values($worksheetNames->hasNext())) {
        $name = $worksheetNames->next();
        // Haal een map op die diagramindexen naar diagramnamen voor het werkblad koppelt.
        $worksheetCharts = $workbook->getChartsFromWorksheet($name)->iterator();

        while (java_values($worksheetCharts->hasNext())) {
            $chart = $worksheetCharts->next();
            // Voeg een nieuwe dia toe met de lege lay‑out.
            $slide = $presentation->getSlides()->addEmptySlide($blankLayout);

            // Importeer het opgegeven diagram uit de Excel-werkmap in de vormverzameling van de dia.
            ExcelWorkbookImporter::addChartFromWorkbook(
                    $slide->getShapes(), 10, 10, $workbook, $name, $chart->getKey(), false);
        }
    }

    // Sla de resulterende presentatie op in een bestand.
    $presentation->save("Charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Samenvatting**

Dit mechanisme, direct beschikbaar in Aspose.Slides, combineert het werken met Excel‑gegevens en presentaties op één plek. Het stelt je in staat dia's te maken met visuele diagrammen en gegevens gepresenteerd als Excel‑tabellen — zonder extra bibliotheken of complexe integraties.