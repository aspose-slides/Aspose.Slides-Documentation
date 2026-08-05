---
title: "Excel‑gegevens integreren in PowerPoint‑presentaties"
linktitle: "Excel‑integratie"
type: docs
weight: 330
url: /nl/net/excel-integration/
aliases:
  - /net/developer-guide/technical-articles/excel-integration/
keywords:
  - Excel
  - werkmap
  - Excel lezen
  - Excel integreren
  - gegevensbron
  - mail merge
  - tabel importeren
  - Excel naar PowerPoint
  - PowerPoint
  - presentatie
  - .NET
  - C#
  - Aspose.Slides
description: "Gegevens lezen uit Excel‑werkmappen in Aspose.Slides met behulp van de ExcelDataWorkbook‑API. Bladen en cellen laden en de waarden gebruiken om gegevensgestuurde PowerPoint‑presentaties te genereren."
---
## **Inleiding**

PowerPoint‑presentaties zijn een krachtige manier om informatie weer te geven en te communiceren. Ze worden vaak gebruikt in combinatie met Excel‑werkmappen, waarbij Excel een uitstekende bron van gestructureerde gegevens is en PowerPoint uitblinkt in het visualiseren van die gegevens voor een publiek.

Er zijn veel praktische scenario’s waarin het combineren van Excel en PowerPoint essentieel is: mail‑merges, het vullen van datatabellen, het genereren van één dia per gegevensrecord (batch‑dia‑generatie), het maken van trainingsmateriaal en het consolideren van meerdere Excel‑rapporten in één presentatie, om er maar een paar te noemen.

Tot nu toe vereiste de implementatie van dergelijke functionaliteit met de Aspose.Slides‑API het gebruik van oplossingen van derde partijen zoals Aspose.Cells. Hoewel deze tools robuust zijn, kunnen ze overmatig complex en kostbaar zijn voor gebruikers die alleen basis‑integratiefuncties nodig hebben.

## **Hoe het werkt**

Om het werken met Excel‑gegevens gemakkelijker en gestroomlijnder te maken, heeft Aspose.Slides nieuwe klassen geïntroduceerd voor het lezen van gegevens uit Excel‑werkmappen en het importeren van inhoud in een presentatie. Deze functie opent krachtige nieuwe mogelijkheden voor API‑gebruikers die Excel willen benutten als gegevensbron binnen hun presentatiewerkstromen.

De nieuwe functionaliteit is ontworpen voor algemeen data‑toegang en is niet geïntegreerd in het Presentation Document Object Model (DOM). Dat betekent dat *het geen bewerken of opslaan van Excel‑bestanden toestaat* — het enige doel is werkmappen te openen en door hun inhoud te navigeren om celgegevens op te halen.

In de kern van deze functie staat de nieuwe [ExcelDataWorkbook](https://reference.aspose.com/slides/nl/net/aspose.slides.excel/exceldataworkbook/)‑klasse. Deze klasse stelt je in staat een Excel‑werkmap te laden vanuit een lokaal bestand of een stream. Eenmaal geladen biedt hij verschillende overloads van de [GetCell](https://reference.aspose.com/slides/nl/net/aspose.slides.excel/exceldataworkbook/getcell/)‑methode, waarmee je specifieke cellen kunt opvragen op basis van hun positie (bijv. rij‑ en kolom‑indices of benoemde bereiken).

Elke aanroep van [GetCell](https://reference.aspose.com/slides/nl/net/aspose.slides.excel/exceldataworkbook/getcell/) retourneert een instantie van de [ExcelDataCell](https://reference.aspose.com/slides/nl/net/aspose.slides.excel/exceldatacell/)‑klasse. Dit object stelt een enkele cel in de Excel‑werkmap voor en geeft je op een eenvoudige en intuïtieve manier toegang tot de waarde ervan.

#### **Een Excel‑diagram importeren**

De volgende stap om functionaliteit uit te breiden is de [ExcelWorkbookImporter](https://reference.aspose.com/slides/nl/net/aspose.slides.import/excelworkbookimporter/)‑klasse. Deze hulpprogrammaklasse biedt functionaliteit voor het importeren van inhoud uit een Excel‑werkmap in een presentatie. Ze bevat verschillende overloads van de [AddChartFromWorkbook](https://reference.aspose.com/slides/nl/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/)‑methode, waarmee je het geselecteerde diagram uit de opgegeven Excel‑werkmap kunt ophalen en aan het einde van de opgegeven vormverzameling op de opgegeven coördinaten kunt toevoegen.

#### **Een Excel‑tabel importeren**

De [ExcelWorkbookImporter](https://reference.aspose.com/slides/nl/net/aspose.slides.import/excelworkbookimporter/)‑klasse bevat ook verschillende overloads van de [AddTableFromWorkbook](https://reference.aspose.com/slides/nl/net/aspose.slides.import/excelworkbookimporter/addtablefromworkbook/)‑methode. Deze methoden stellen je in staat een opgegeven celbereik van een opgegeven werkblad te importeren en als een tabel toe te voegen aan het einde van de opgegeven vormverzameling op de opgegeven coördinaten.

Kortom, het is een lichte en eenvoudige API voor het lezen van Excel‑gegevens — precies wat veel ontwikkelaars nodig hebben zonder de overhead van een volledige spreadsheet‑verwerkingsbibliotheek.

## **Laten we code**

### **Voorbeeld van mail‑merge scenario**

In het volgende voorbeeld implementeren we een eenvoudig mail‑merge‑scenario door meerdere presentaties te genereren op basis van gegevens die zijn opgeslagen in een Excel‑werkmap.

Om te beginnen hebben we twee dingen nodig:
1. Een Excel‑werkmap met de gegevens

![Voorbeeld van Excel‑gegevens](example1_image0.png)

2. PowerPoint‑presentatiesjabloon

![Voorbeeld van PowerPoint‑sjabloon](example1_image1.png)

```csharp
// Laad de Excel-werkmap met personeelsgegevens.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Laad de presentatiesjabloon.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Itereer door de Excel‑rijen (exclusief de koprij op rij 0).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // Maak een nieuwe presentatie aan voor elk personeelsrecord.
    using Presentation employeePresentation = new Presentation();

    // Verwijder de standaard lege dia.
    employeePresentation.Slides.RemoveAt(0);

    // Kloon de sjabloondia naar de nieuwe presentatie.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // Haal alinea’s op van de doelvorm (veronderstelt dat vormindex 1 wordt gebruikt).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // Vervang de tijdelijke aanduidingen door gegevens uit Excel.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // Sla de gepersonaliseerde presentatie op in een apart bestand.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![Resultaat](example1_image2.png)

### **Voorbeeld van Excel‑tabel**

In het tweede voorbeeld kopiëren we simpelweg gegevens uit een Excel‑tabel en tonen we deze op een PowerPoint‑dia in een visueel aantrekkelijker formaat.

In dit voorbeeld hergebruiken we dezelfde Excel‑werkmap als in het eerste voorbeeld, die een eenvoudige medewerkers‑tabel bevat.

```csharp
// Laad de Excel-werkmap met de personeelsgegevens.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Maak een nieuwe PowerPoint‑presentatie.
using Presentation presentation = new Presentation();

// Voeg een tabelvorm toe aan de eerste dia.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// Vul de PowerPoint‑tabel met gegevens uit de Excel‑werkmap.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// Sla de resulterende presentatie op in een bestand.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![Resultaat](example2_image0.png)

### **Voorbeeld van een Excel‑diagram importeren**

In dit voorbeeld importeren we een diagram vanuit het eerste werkblad van de Excel‑werkmap die in het vorige voorbeeld werd gebruikt. Het diagram zal in de resulterende presentatie linken naar de externe werkmap.

Eerst voegen we een cirkeldiagram toe aan de Excel‑werkmap op basis van de medewerkers‑tabel.

![Voorbeeld van Excel‑diagram](example3_image0.png)

```csharp
// Maak een nieuwe PowerPoint‑presentatie.
using Presentation presentation = new Presentation();

// Verkrijg de vormverzameling van de eerste dia.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Importer het diagram met de naam "Chart 1" van het eerste blad van de werkmap en voeg het toe aan de vormverzameling.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// Sla de resulterende presentatie op in een bestand.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![Resultaat](example3_image1.png)

### **Voorbeeld van het importeren van alle Excel‑diagrammen**

Stel je voor dat je een Excel‑werkmap vol diagrammen hebt en je moet ze allemaal importeren in een presentatie. Elk diagram moet op een nieuwe dia worden geplaatst.

De onderstaande code doorloopt alle werkbladen in het bron‑Excel‑bestand, haalt de diagrammen uit elk werkblad op en voegt elk diagram toe aan een afzonderlijke dia met een lege dia‑lay‑out. In de resulterende presentatie worden alleen de diagramgegevens geïntegreerd, niet de volledige werkmap.

```csharp
// Laad de Excel-werkmap met de personeelsgegevens.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Maak een nieuwe PowerPoint-presentatie.
using Presentation presentation = new Presentation();

// Haal de lege dia‑lay‑out op.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Haal de namen op van alle werkbladen in de Excel-werkmap.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // Haal een woordenboek op dat diagram‑indexen naar diagram­namen mappt voor het werkblad.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // Voeg een nieuwe dia toe met de lege lay‑out.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Import het opgegeven diagram uit de Excel-werkmap in de vormverzameling van de dia.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// Sla de resulterende presentatie op in een bestand.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

### **Voorbeeld van een Excel‑tabel importeren**

In dit voorbeeld importeren we een opgemaakte tabel vanuit een Excel‑werkblad direct in een PowerPoint‑presentatie.

Het bron‑Excel‑werkblad bevat een opgemaakte tabel met medewerkers‑gegevens:

![Voorbeeld van Excel‑tabel](example4_image0.png)

```csharp
// Maak een nieuwe PowerPoint‑presentatie.
using Presentation presentation = new Presentation();

// Haal de vormverzameling op van de eerste dia.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Importeer de tabel van het eerste blad van de werkmap en voeg deze toe aan de vormverzameling.
ExcelWorkbookImporter.AddTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5");

// Sla de resulterende presentatie op in een bestand.
presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
```

![Resultaat](example4_image1.png)

## **Samenvatting**

Dit mechanisme, direct beschikbaar in Aspose.Slides, combineert het werken met Excel‑gegevens en presentaties op één plek. Het stelt je in staat dia’s te maken met visuele diagrammen en data gepresenteerd als Excel‑tabellen — zonder extra bibliotheken of complexe integraties.