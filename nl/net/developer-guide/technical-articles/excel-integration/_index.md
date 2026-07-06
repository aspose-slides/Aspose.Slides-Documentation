---
title: "Excel-gegevens integreren in PowerPoint‑presentaties"
linktitle: "Excel‑integratie"
type: docs
weight: 330
url: /nl/net/excel-integration/
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
- .NET
- C#
- Aspose.Slides
description: "Lees gegevens uit Excel‑werkmappen in Aspose.Slides met behulp van de ExcelDataWorkbook‑API. Laad werkbladen en cellen en gebruik de waarden om data‑gedreven PowerPoint‑presentaties te genereren."
---
## **Inleiding**

PowerPoint‑presentaties zijn een krachtige manier om informatie weer te geven en te communiceren. Ze worden vaak samen met Excel‑werkmappen gebruikt, waarbij Excel een uitstekende bron van gestructureerde gegevens vormt en PowerPoint uitblinkt in het visualiseren van die gegevens voor een publiek.

Er zijn tal van praktische scenario’s waarbij het combineren van Excel en PowerPoint essentieel is: mail merges, het vullen van gegevenstabellen, het genereren van één dia per gegevensrecord (batch‑dia‑generatie), het maken van trainingsmateriaal en het consolideren van meerdere Excel‑rapporten tot één presentatie, om er maar een paar te noemen.

Tot nu toe vereiste het implementeren van dergelijke functies met de Aspose.Slides‑API het vertrouwen op oplossingen van derden zoals Aspose.Cells. Hoewel deze tools robuust zijn, kunnen ze te complex en kostbaar zijn voor gebruikers die alleen basisfunctionaliteit voor gegevensintegratie nodig hebben.

## **Hoe het werkt**

Om het werken met Excel‑gegevens makkelijker en efficiënter te maken, heeft Aspose.Slides nieuwe klassen geïntroduceerd voor het lezen van gegevens uit Excel‑werkmappen en het importeren van inhoud in een presentatie. Deze functie opent krachtige nieuwe mogelijkheden voor API‑gebruikers die Excel willen benutten als gegevensbron binnen hun presentatieworkflows.

De nieuwe functionaliteit is ontworpen voor algemeen gebruik van gegevens en is niet geïntegreerd in het Presentation Document Object Model (DOM). Dat betekent dat *het bewerken of opslaan van Excel‑bestanden niet mogelijk is* — het enige doel is om werkmappen te openen en door hun inhoud te navigeren om celgegevens op te halen.

De kern van deze functie is de nieuwe [ExcelDataWorkbook](https://reference.aspose.com/slides/nl/net/aspose.slides.excel/exceldataworkbook/)‑klasse. Deze klasse stelt u in staat een Excel‑werkmap te laden vanuit een lokaal bestand of een stream. Na het laden biedt ze verschillende overloads van de [GetCell](https://reference.aspose.com/slides/nl/net/aspose.slides.excel/exceldataworkbook/getcell/)‑methode, die u kunt gebruiken om specifieke cellen op te halen op basis van hun positie (bijv. rijen‑ en kolomindexen of benoemde bereiken).

Elke oproep van [GetCell](https://reference.aspose.com/slides/nl/net/aspose.slides.excel/exceldataworkbook/getcell/) retourneert een instantie van de [ExcelDataCell](https://reference.aspose.com/slides/nl/net/aspose.slides.excel/exceldatacell/)‑klasse. Dit object vertegenwoordigt een enkele cel in de Excel‑werkmap en geeft u toegang tot de waarde ervan op een eenvoudige en intuïtieve manier.

#### **Importeer een Excel‑grafiek**

De volgende stap om de functionaliteit uit te breiden is de [ExcelWorkbookImporter](https://reference.aspose.com/slides/nl/net/aspose.slides.import/excelworkbookimporter/)‑klasse. Deze hulpprogrammaklasse biedt functionaliteit voor het importeren van inhoud uit een Excel‑werkmap naar een presentatie. Ze bevat verschillende overloads van de [AddChartFromWorkbook](https://reference.aspose.com/slides/nl/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/)‑methode, die u helpt de geselecteerde grafiek uit de opgegeven Excel‑werkmap op te halen en toe te voegen aan het einde van de opgegeven vormverzameling op de opgegeven coördinaten.

#### **Importeer een Excel‑tabel**

De [ExcelWorkbookImporter](https://reference.aspose.com/slides/nl/net/aspose.slides.import/excelworkbookimporter/)‑klasse bevat ook verschillende overloads van de [AddTableFromWorkbook](https://reference.aspose.com/slides/nl/net/aspose.slides.import/excelworkbookimporter/addtablefromworkbook/)‑methode. Deze methoden stellen u in staat een opgegeven celbereik van een opgegeven werkblad te importeren en het als tabel toe te voegen aan het einde van de opgegeven vormverzameling op de opgegeven coördinaten.

In het kort is het een lichte en eenvoudige API voor het lezen van Excel‑gegevens — precies wat veel ontwikkelaars nodig hebben zonder de overhead van een volledige spreadsheet‑verwerkingsbibliotheek.

## **Laten we coderen**

### **Voorbeeld van mail‑merge scenario**

In het volgende voorbeeld implementeren we een eenvoudig mail‑merge scenario door meerdere presentaties te genereren op basis van gegevens die zijn opgeslagen in een Excel‑werkmap.

Om te beginnen hebben we twee dingen nodig:
1. Een Excel‑werkmap met de gegevens

![Excel data example](example1_image0.png)

2. PowerPoint‑presentatiesjabloon

![PowerPoint template example](example1_image1.png)

```csharp
// Laad de Excel-werkmap met werknemergegevens.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Laad de presentatiesjabloon.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Doorloop de Excel‑rijen (exclusief de koprij op rij 0).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // Maak een nieuwe presentatie voor elk werknemerrecord.
    using Presentation employeePresentation = new Presentation();

    // Verwijder de standaard lege dia.
    employeePresentation.Slides.RemoveAt(0);

    // Kloon de sjabloondia naar de nieuwe presentatie.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // Haal de alinea's op van de doelvorm (aangenomen dat vorm‑index 1 wordt gebruikt).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // Vervang de tijdelijke aanduidingen met gegevens uit Excel.
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

![Result](example1_image2.png)

### **Voorbeeld van Excel‑tabel**

In het tweede voorbeeld kopiëren we eenvoudig gegevens uit een Excel‑tabel en tonen ze op een PowerPoint‑dia in een visueel aantrekkelijker formaat.

In dit voorbeeld hergebruiken we dezelfde Excel‑werkmap als in het eerste voorbeeld, die een eenvoudige werknemers‑tabel bevat.

```csharp
// Laad de Excel-werkmap met de werknemergegevens.
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

// Sla de resulterende presentatie op naar een bestand.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![Result](example2_image0.png)

### **Voorbeeld van importeren van een Excel‑grafiek**

In dit voorbeeld importeren we een grafiek uit het eerste werkblad van de Excel‑werkmap die in het vorige voorbeeld werd gebruikt. De grafiek zal in de resulterende presentatie gelinkt worden aan de externe werkmap.

Eerst voegen we een cirkeldiagram toe aan de Excel‑werkmap op basis van de werknemers‑tabel.

![Excel Chart example](example3_image0.png)

```csharp
// Maak een nieuwe PowerPoint‑presentatie.
using Presentation presentation = new Presentation();

// Haal de vormverzameling op van de eerste dia.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Importeer de grafiek met de naam "Chart 1" van het eerste werkblad van de werkmap en voeg deze toe aan de vormverzameling.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// Sla de resulterende presentatie op naar een bestand.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![Result](example3_image1.png)

### **Voorbeeld van importeren van alle Excel‑grafieken**

Stel je voor dat je een Excel‑werkmap vol grafieken hebt en je moet ze allemaal importeren in een presentatie. Elke grafiek moet op een nieuwe dia geplaatst worden.

De onderstaande code doorloopt alle werkbladen in het bron‑Excel‑bestand, haalt de grafieken uit elk werkblad op en voegt elke grafiek toe aan een aparte dia met een lege dia‑lay‑out. In de resulterende presentatie wordt alleen de grafiekdata ingebed, niet de volledige werkmap.

```csharp
// Laad de Excel-werkmap met de werknemergegevens.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Maak een nieuwe PowerPoint-presentatie.
using Presentation presentation = new Presentation();

// Haal de lege dia‑lay‑out op.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Haal de namen op van alle werkbladen in de Excel-werkmap.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // Haal een woordenboek op dat de grafiek‑indexen koppelt aan grafieknamen voor het werkblad.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // Voeg een nieuwe dia toe met gebruik van de lege lay‑out.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Importeer de gespecificeerde grafiek uit de Excel-werkmap in de vormverzameling van de dia.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// Sla de resulterende presentatie op naar een bestand.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

### **Voorbeeld van importeren van een Excel‑tabel**

In dit voorbeeld importeren we een opgemaakte tabel vanuit een Excel‑werkblad direct in een PowerPoint‑presentatie.

Het bron‑Excel‑werkblad bevat een opgemaakte tabel met werknemersgegevens:

![Excel Table example](example4_image0.png)

```csharp
// Maak een nieuwe PowerPoint-presentatie.
using Presentation presentation = new Presentation();

// Haal de vormverzameling op van de eerste dia.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Importeer de tabel van het eerste werkblad van de werkmap en voeg deze toe aan de vormverzameling.
ExcelWorkbookImporter.AddTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5");

// Sla de resulterende presentatie op naar een bestand.
presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
```

![Result](example4_image1.png)


## **Samenvatting**

Dit mechanisme, direct beschikbaar in Aspose.Slides, combineert het werken met Excel‑gegevens en presentaties op één plek. Het stelt u in staat dia’s te maken met visuele grafieken en gegevens gepresenteerd als Excel‑tabellen — zonder extra bibliotheken of complexe integraties.