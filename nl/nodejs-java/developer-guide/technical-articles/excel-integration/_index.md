---
title: Integreren van Excel-gegevens in PowerPoint-presentaties
linktitle: Excel-integratie
type: docs
weight: 330
url: /nl/nodejs-java/excel-integration/
keywords:
- Excel
- werkmap
- Excel lezen
- Excel integreren
- gegevensbron
- mailmerge
- tabel importeren
- Excel naar PowerPoint
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Lees gegevens uit Excel-werkmappen in JavaScript met Aspose.Slides. Laad bladen en cellen en gebruik de waarden om gegevensgestuurde PowerPoint-presentaties te genereren."
---
## **Inleiding**

PowerPoint-presentaties zijn een krachtige manier om informatie weer te geven en te communiceren. Ze worden vaak gebruikt in combinatie met Excel-werkmappen, waarbij Excel een uitstekende bron van gestructureerde gegevens is en PowerPoint uitblinkt in het visualiseren van die gegevens voor een publiek.

Er zijn talloze praktische scenario's waarin het combineren van Excel en PowerPoint essentieel is: mail merges, het vullen van gegevenstabellen, het genereren van één dia per gegevensrecord (batchdia-generatie), het maken van trainingsmateriaal en het consolideren van meerdere Excel-rapporten in één presentatie, om er maar een paar te noemen.

Tot nu toe vereiste het implementeren van dergelijke functionaliteit met de Aspose.Slides API het afhankelijk zijn van oplossingen van derden zoals Aspose.Cells. Hoewel deze tools robuust zijn, kunnen ze te complex en duur zijn voor gebruikers die alleen basisgegevensintegratiefuncties nodig hebben.

## **Hoe het werkt**

Om het werken met Excel-gegevens makkelijker en gestroomlijnder te maken, heeft Aspose.Slides nieuwe klassen geïntroduceerd voor het lezen van gegevens uit Excel-werkmappen en het importeren van inhoud in een presentatie. Deze functie opent krachtige nieuwe mogelijkheden voor API‑gebruikers die Excel willen gebruiken als gegevensbron binnen hun presentatieworkflows.

De nieuwe functionaliteit is ontworpen voor algemeen gegevensgebruik en is niet geïntegreerd in de Presentation Document Object Model (DOM). Dat betekent dat *het geen bewerken of opslaan van Excel‑bestanden toestaat* — het enige doel is werkmappen te openen en door hun inhoud te navigeren om celgegevens op te halen.

De kern van deze functionaliteit is de nieuwe [ExcelDataWorkbook](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/exceldataworkbook/)‑klasse. Deze klasse maakt het mogelijk een Excel‑werkmap te laden vanuit een lokaal bestand of een stream. Zodra deze geladen is, biedt hij verschillende overloads van de [getCell](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/exceldataworkbook/#getCell)‑methode, die je kunt gebruiken om specifieke cellen op te halen op basis van hun positie (bijv. rij‑ en kolomindexen of benoemde bereiken).

Elke oproep naar [getCell](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/exceldataworkbook/#getCell) retourneert een instantie van de [ExcelDataCell](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/exceldatacell/)‑klasse. Dit object vertegenwoordigt een enkele cel in de Excel‑werkmap en geeft je op een eenvoudige en intuïtieve manier toegang tot de waarde ervan.

#### **Importeer een Excel‑grafiek**

De volgende stap om de functionaliteit uit te breiden is de [ExcelWorkbookImporter](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/excelworkbookimporter/)‑klasse. Deze hulpprogrammaklasse biedt functionaliteit om inhoud uit een Excel‑werkmap in een presentatie te importeren. Ze bevat verschillende overloads van de [addChartFromWorkbook](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook)‑methode, die je helpen de geselecteerde grafiek uit de opgegeven Excel‑werkmap op te halen en deze aan het einde van de opgegeven vormverzameling toe te voegen op de gespecificeerde coördinaten.

Kortom, het is een lichtgewicht en eenvoudige API voor het lezen van Excel‑gegevens — precies wat veel ontwikkelaars nodig hebben zonder de overhead van een volledige spreadsheet‑verwerkingsbibliotheek.

## **Laten we coderen**

### **Voorbeeld van mail merge‑scenario**

In het volgende voorbeeld implementeren we een eenvoudig mail‑merge‑scenario door meerdere presentaties te genereren op basis van gegevens die zijn opgeslagen in een Excel‑werkmap.

Om te beginnen hebben we twee dingen nodig:
1. Een Excel‑werkmap met de gegevens

![Excel-gegevensvoorbeeld](example1_image0.png)

2. PowerPoint‑presentatiesjabloon

![PowerPoint-sjabloonvoorbeeld](example1_image1.png)

```js
// Laad de Excel-werkmap met werknemersgegevens.
let workbook = new aspose.slides.ExcelDataWorkbook("TemplateData.xlsx");
const worksheetIndex = 0;

// Laad de presentatiesjabloon.
let templatePresentation = new aspose.slides.Presentation("PresentationTemplate.pptx");

try {
    // Loop door Excel-rijen (exclusief header op rij 0).
    for (let rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // Maak een nieuwe presentatie voor elk werknemersrecord.
        let employeePresentation = new aspose.slides.Presentation();

        try {
            // Verwijder de standaard lege dia.
            employeePresentation.getSlides().removeAt(0);

            // Kloon de sjabloondia naar de nieuwe presentatie.
            let slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // Haal alinea's op van de doelfiguur (neemt aan dat vormindex 1 wordt gebruikt).
            let paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs();

            // Vervang de tijdelijke aanduidingen met gegevens uit Excel.
            let employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            let namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            let department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            let departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            let yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            let yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // Sla de gepersonaliseerde presentatie op naar een apart bestand.
            employeePresentation.save(`${employeeName} Report.pptx`, aspose.slides.SaveFormat.Pptx);
        } finally {
            employeePresentation.dispose();
        }
    }
} finally {
    templatePresentation.dispose();
}
```

![Resultaat](example1_image2.png)

### **Voorbeeld van Excel‑tabel**

In het tweede voorbeeld kopiëren we eenvoudig gegevens uit een Excel‑tabel en tonen deze op een PowerPoint‑dia in een visueel aantrekkelijker formaat.

In dit voorbeeld hergebruiken we dezelfde Excel‑werkmap als in het eerste voorbeeld, die een eenvoudige werknemers‑tabel bevat.

```js
// Laad de Excel-werkmap met de werknemersgegevens.
let workbook = new aspose.slides.ExcelDataWorkbook("TemplateData.xlsx");
const worksheetIndex = 0;

// Creëer een nieuwe PowerPoint-presentatie.
let presentation = new aspose.slides.Presentation();

try {
    // Voeg een tabelvorm toe aan de eerste dia.
    let table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            java.newArray("double", [200, 200, 200]),
            java.newArray("double", [30, 30, 30, 30, 30])
    );

    // Vul de PowerPoint-tabel met gegevens uit de Excel-werkmap.
    for (let rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (let columnIndex = 0; columnIndex < 3; columnIndex++) {
            let cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // Sla de resulterende presentatie op naar een bestand.
    presentation.save("Table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Resultaat](example2_image0.png)

### **Voorbeeld van het importeren van een Excel‑grafiek**

In dit voorbeeld importeren we een grafiek uit het eerste werkblad van de Excel‑werkmap die in het vorige voorbeeld is gebruikt. De grafiek zal in de uiteindelijke presentatie naar de externe werkmap linken.

Eerst voegen we een cirkeldiagram toe aan de Excel‑werkmap op basis van de werknemers‑tabel.

![Voorbeeld van Excel‑grafiek](example3_image0.png)

```js
// Maak een nieuwe PowerPoint-presentatie.
let presentation = new aspose.slides.Presentation();
try {
    // Haal de vormverzameling op van de eerste dia.
    let shapes = presentation.getSlides().get_Item(0).getShapes();

    // Importeer de grafiek met de naam "Chart 1" van het eerste werkblad van de werkmap en voeg deze toe aan de vormverzameling.
    aspose.slides.ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Sla de resulterende presentatie op naar een bestand.
    presentation.save("Chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Resultaat](example3_image1.png)

### **Voorbeeld van het importeren van alle Excel‑grafieken**

Stel je voor dat je een Excel‑werkmap vol met grafieken hebt en dat je ze allemaal in een presentatie moet importeren. Elke grafiek moet op een nieuwe dia worden geplaatst.

De onderstaande code doorloopt alle werkbladen in het bron‑Excel‑bestand, haalt de grafieken uit elk werkblad op en voegt elke grafiek toe aan een aparte dia met behulp van een lege dia‑indeling. In de uiteindelijke presentatie worden alleen de grafiekgegevens ingebed, niet de volledige werkmap.

```js
// Laad de Excel-werkmap met de werknemersgegevens.
let workbook = new aspose.slides.ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Maak een nieuwe PowerPoint-presentatie.
let presentation = new aspose.slides.Presentation();
try {
    // Haal de lege dia-indeling op.
    let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

    // Haal de namen op van alle werkbladen die in de Excel-werkmap zitten.
    let worksheetNames = workbook.getWorksheetNames().iterator();

    while (worksheetNames.hasNext()) {
        let name = worksheetNames.next();
        // Haal een map op die grafiekinidices naar grafieknamen voor het werkblad koppelt.
        let worksheetCharts = workbook.getChartsFromWorksheet(name).iterator();

        while (worksheetCharts.hasNext()) {
            let chart = worksheetCharts.next();
            // Voeg een nieuwe dia toe met gebruik van de lege indeling.
            let slide = presentation.getSlides().addEmptySlide(layoutSlide);

            // Importeer de opgegeven grafiek van de Excel-werkmap in de vormverzameling van de dia.
            aspose.slides.ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // Sla de resulterende presentatie op naar een bestand.
    presentation.save("Charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Samenvatting**

Dit mechanisme, direct beschikbaar in Aspose.Slides, combineert het werken met Excel‑gegevens en presentaties op één plek. Het stelt je in staat om dia's te maken met visuele grafieken en gegevens die als Excel‑tabellen worden weergegeven — zonder extra bibliotheken of complexe integraties.