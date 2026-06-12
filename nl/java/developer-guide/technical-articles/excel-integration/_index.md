---
title: Excel-gegevens integreren in PowerPoint-presentaties
linktitle: Excel-integratie
type: docs
weight: 330
url: /nl/java/excel-integration/
keywords:
- Excel
- werkboek
- Excel lezen
- Excel integreren
- gegevensbron
- mailmerge
- tabel importeren
- Excel naar PowerPoint
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Gegevens lezen uit Excel-werkboeken in Aspose.Slides met de ExcelDataWorkbook-API. Bladen en cellen laden en waarden gebruiken om gegevensgestuurde PowerPoint-presentaties te genereren."
---
## **Inleiding**

PowerPoint‑presentaties zijn een krachtige manier om informatie weer te geven en te communiceren. Ze worden vaak samen met Excel‑werkboeken gebruikt, waarbij Excel een uitstekende bron van gestructureerde gegevens vormt en PowerPoint uitblinkt in het visualiseren van die gegevens voor een publiek.

Er zijn veel praktische scenario’s waarin het combineren van Excel en PowerPoint essentieel is: mailing‑samenvoegingen, het vullen van gegevenstabellen, het genereren van één dia per gegevensrecord (batch‑dia‑generatie), het maken van trainingsmateriaal en het consolideren van meerdere Excel‑rapporten tot één presentatie, om er maar een paar te noemen.

Tot nu toe vereiste het implementeren van dergelijke functionaliteit met de Aspose.Slides‑API dat men afhankelijk was van derde‑partij‑oplossingen zoals Aspose.Cells. Hoewel deze tools robuust zijn, kunnen ze onnodig complex en kostbaar zijn voor gebruikers die alleen basale gegevens‑integratiefuncties nodig hebben.

## **Hoe het werkt**

Om het werken met Excel‑gegevens makkelijker en gestroomlijnder te maken, heeft Aspose.Slides nieuwe klassen geïntroduceerd voor het lezen van gegevens uit Excel‑werkboeken en het importeren van inhoud in een presentatie. Deze functie opent krachtige nieuwe mogelijkheden voor API‑gebruikers die Excel willen gebruiken als gegevensbron binnen hun presentatie‑workflows.

De nieuwe functionaliteit is ontworpen voor algemeen gegevens‑toegang en is niet geïntegreerd in het Presentation Document Object Model (DOM). Dat betekent dat *het geen bewerken of opslaan van Excel‑bestanden toestaat* — het enige doel is werkboeken te openen en door hun inhoud te navigeren om celgegevens op te halen.

Centraal in deze functie staat de nieuwe [ExcelDataWorkbook](https://reference.aspose.com/slides/nl/java/com.aspose.slides/exceldataworkbook/)‑klasse. Deze klasse stelt je in staat een Excel‑werkboek te laden vanaf een lokaal bestand of een stream. Eenmaal geladen biedt hij verschillende overloads van de [getCell](https://reference.aspose.com/slides/nl/java/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-)‑methode, die je kunt gebruiken om specifieke cellen op te halen op basis van hun positie (bijv. rij‑ en kolom‑indices of benoemde bereiken).

Elke oproep van [getCell](https://reference.aspose.com/slides/nl/java/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) levert een instantie op van de [ExcelDataCell](https://reference.aspose.com/slides/nl/java/com.aspose.slides/exceldatacell/)‑klasse. Dit object vertegenwoordigt een enkele cel in het Excel‑werkboek en geeft je op een eenvoudige en intuïtieve manier toegang tot de waarde ervan.

#### **Een Excel‑grafiek importeren**

De volgende stap om de functionaliteit uit te breiden is de [ExcelWorkbookImporter](https://reference.aspose.com/slides/nl/java/com.aspose.slides/excelworkbookimporter/)‑klasse. Deze hulpprogrammakelasse biedt functionaliteit voor het importeren van inhoud uit een Excel‑werkboek naar een presentatie. Hij bevat diverse overloads van de [addChartFromWorkbook](https://reference.aspose.com/slides/nl/java/com.aspose.slides/excelworkbookimporter/#addChartFromWorkbook-com.aspose.slides.IShapeCollection-float-float-com.aspose.slides.IExcelDataWorkbook-java.lang.String-int-boolean-)‑methode, waarmee je de geselecteerde grafiek uit het opgegeven Excel‑werkboek kunt ophalen en aan het einde van de opgegeven vormverzameling kunt toevoegen op de gespecificeerde coördinaten.

Kort samengevat is het een lichte en eenvoudige API voor het lezen van Excel‑gegevens — precies wat veel ontwikkelaars nodig hebben zonder de overhead van een volledige spreadsheet‑verwerkingsbibliotheek.

## **Laten we coden**

### **Voorbeeld van een mailing‑samenvoeging**

In het volgende voorbeeld implementeren we een eenvoudige mailing‑samenvoeging door meerdere presentaties te genereren op basis van gegevens die opgeslagen zijn in een Excel‑werkboek.

Om te beginnen hebben we twee dingen nodig:
1. Een Excel‑werkboek met de gegevens

![Excel data example](example1_image0.png)

2. PowerPoint‑presentatiesjabloon

![PowerPoint template example](example1_image1.png)

```java
// Laad het Excel-werkboek met werknemergegevens.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Laad de sjabloonpresentatie.
Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // Loop door de Excel-rijen (exclusief de koprij op rij 0).
    for (int rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // Maak een nieuwe presentatie aan voor elk werknemerrecord.
        Presentation employeePresentation = new Presentation();

        try {
            // Verwijder de standaard lege dia.
            employeePresentation.getSlides().removeAt(0);

            // Kloon de sjabloondia naar de nieuwe presentatie.
            ISlide slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // Haal alinea's op uit de doelvorm (aangenomen dat vormindex 1 wordt gebruikt).
            IParagraphCollection paragraphs = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame().getParagraphs();

            // Vervang de tijdelijke aanduidingen door gegevens uit Excel.
            String employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            IPortion namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            String department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            IPortion departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            String yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            IPortion yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // Sla de gepersonaliseerde presentatie op in een afzonderlijk bestand.
            employeePresentation.save(String.format("%s Report.pptx", employeeName), SaveFormat.Pptx);
        } finally {
            employeePresentation.dispose();
        }
    }
} finally {
    templatePresentation.dispose();
}
```

![Result](example1_image2.png)

### **Voorbeeld van een Excel‑tabel**

In het tweede voorbeeld kopiëren we simpelweg gegevens uit een Excel‑tabel en tonen we deze op een PowerPoint‑dia in een visueel aantrekkelijkere opmaak.

In dit voorbeeld hergebruiken we hetzelfde Excel‑werkboek als in het eerste voorbeeld, dat een eenvoudige werknemers‑tabel bevat.

```java
// Laad het Excel-werkboek met de werknemergegevens.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Maak een nieuwe PowerPoint-presentatie.
Presentation presentation = new Presentation();

try {
    // Voeg een tabelvorm toe aan de eerste dia.
    ITable table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            new double[]{200, 200, 200},
            new double[]{30, 30, 30, 30, 30}
    );

    // Vul de PowerPoint-tabel met gegevens uit het Excel-werkboek.
    for (int rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (int columnIndex = 0; columnIndex < 3; columnIndex++) {
            String cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // Sla de resulterende presentatie op in een bestand.
    presentation.save("Table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Result](example2_image0.png)

### **Voorbeeld van het importeren van een Excel‑grafiek**

In dit voorbeeld importeren we een grafiek van het eerste werkblad van het Excel‑werkboek dat in het vorige voorbeeld werd gebruikt. De grafiek zal in de resulterende presentatie naar het externe werkboek verwijzen.

Eerst voegen we een cirkeldiagram toe aan het Excel‑werkboek op basis van de werknemers‑tabel.

![Excel Chart example](example3_image0.png)

```java
// Maak een nieuwe PowerPoint-presentatie.
Presentation presentation = new Presentation();
try {
    // Haal de vormverzameling op van de eerste dia.
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    // Importeer de grafiek met de naam "Chart 1" van het eerste blad van het werkboek en voeg deze toe aan de vormverzameling.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Sla de resulterende presentatie op in een bestand.
    presentation.save("Chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Result](example3_image1.png)

### **Voorbeeld van het importeren van alle Excel‑grafieken**

Stel je voor dat je een Excel‑werkboek vol grafieken hebt en je moet ze allemaal importeren in een presentatie. Elke grafiek moet op een nieuwe dia worden geplaatst.

De onderstaande code doorloopt alle werkbladen in het bron‑Excel‑bestand, haalt de grafieken uit elk werkblad op en voegt elke grafiek toe aan een aparte dia met een lege dia‑indeling. In de resulterende presentatie wordt alleen de grafiek‑data ingebed, niet het volledige werkboek.

```java
// Laad het Excel-werkboek met de werknemergegevens.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Maak een nieuwe PowerPoint-presentatie.
Presentation presentation = new Presentation();
try {
    // Haal de lege dia-indeling op.
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Haal de namen op van alle werkbladen die zich in het Excel-werkboek bevinden.
    List<String> worksheetNames = workbook.getWorksheetNames();

    for (String name : worksheetNames) {
        // Haal een map op die chart-indexen naar chart-namen voor het werkblad koppelt.
        Dictionary<Integer, String> worksheetCharts = workbook.getChartsFromWorksheet(name);

        for (KeyValuePair<Integer, String> chart : worksheetCharts) {
            // Voeg een nieuwe dia toe met de lege indeling.
            ISlide slide = presentation.getSlides().addEmptySlide(blankLayout);

            // Importeer de opgegeven chart uit het Excel-werkboek in de vormverzameling van de dia.
            ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // Sla de resulterende presentatie op in een bestand.
    presentation.save("Charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Samenvatting**

Dit mechanisme, rechtstreeks beschikbaar in Aspose.Slides, combineert het werken met Excel‑gegevens en presentaties op één plek. Het stelt je in staat dia’s te maken met visuele grafieken en gegevens gepresenteerd als Excel‑tabellen — zonder extra bibliotheken of complexe integraties.