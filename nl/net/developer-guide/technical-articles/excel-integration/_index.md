---
title: Integreer Excel-gegevens in PowerPoint-presentaties
linktitle: Excel-integratie
type: docs
weight: 330
url: /nl/net/excel-integration/
keywords:
- Excel
- werkmap
- Excel lezen
- Excel integreren
- gegevensbron
- mail-merge
- tabel importeren
- Excel naar PowerPoint
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Lees gegevens uit Excel-werkmappen in Aspose.Slides met de ExcelDataWorkbook-API. Laad bladen en cellen en gebruik waarden om gegevens-gedreven PowerPoint-presentaties te genereren."
---
## **Inleiding**

PowerPoint‑presentaties zijn een krachtig middel om informatie weer te geven en te communiceren. Ze worden vaak in combinatie met Excel‑werkmappen gebruikt, waarbij Excel een uitstekende bron van gestructureerde gegevens biedt en PowerPoint uitblinkt in het visualiseren van die gegevens voor een publiek.

Er zijn veel praktische scenario’s waarbij het combineren van Excel en PowerPoint essentieel is: mail‑merge, het vullen van datatabellen, het genereren van één dia per gegevensrecord (batch‑dia‑generatie), het maken van trainingsmateriaal en het consolideren van meerdere Excel‑rapporten tot één presentatie, om er maar een paar te noemen.

Tot nu toe vereiste de implementatie van dergelijke functies met de Aspose.Slides‑API dat men afhankelijk was van third‑party‑oplossingen zoals Aspose.Cells. Hoewel deze tools robuust zijn, kunnen ze te complex en kostbaar zijn voor gebruikers die alleen basis‑gegevensintegratie nodig hebben.

## **Hoe het werkt**

Om het werken met Excel‑gegevens makkelijker en efficiënter te maken, heeft Aspose.Slides nieuwe klassen geïntroduceerd voor het lezen van gegevens uit Excel‑werkmappen en het importeren van inhoud in een presentatie. Deze functie opent krachtige nieuwe mogelijkheden voor API‑gebruikers die Excel willen gebruiken als gegevensbron binnen hun presentatieworkflows.

De nieuwe functionaliteit is bedoeld voor algemeen gebruik bij gegevens‑toegang en is niet geïntegreerd in het Presentation Document Object Model (DOM). Dat betekent dat *het geen bewerken of opslaan van Excel‑bestanden toestaat* — het enige doel is werkmappen te openen en door hun inhoud te navigeren om cel‑gegevens op te halen.

In het hart van deze functie staat de nieuwe [ExcelDataWorkbook](https://reference.aspose.com/slides/nl/net/aspose.slides.excel/exceldataworkbook/)‑klasse. Deze klasse stelt je in staat een Excel‑werkmap te laden vanuit een lokaal bestand of een stream. Eenmaal geladen biedt ze verschillende overloads van de [GetCell](https://reference.aspose.com/slides/nl/net/aspose.slides.excel/exceldataworkbook/getcell/)‑methode, die je kunt gebruiken om specifieke cellen op te halen op basis van hun positie (bijv. rij‑ en kolom‑indexen of benoemde bereiken).

Elke oproep naar [GetCell](https://reference.aspose.com/slides/nl/net/aspose.slides.excel/exceldataworkbook/getcell/) retourneert een instantie van de [ExcelDataCell](https://reference.aspose.com/slides/nl/net/aspose.slides.excel/exceldatacell/)‑klasse. Dit object vertegenwoordigt een enkele cel in de Excel‑werkmap en geeft je toegang tot de waarde op een eenvoudige en intuïtieve manier.

#### **Een Excel‑grafiek importeren**

De volgende stap om de functionaliteit uit te breiden is de [ExcelWorkbookImporter](https://reference.aspose.com/slides/nl/net/aspose.slides.import/excelworkbookimporter/)‑klasse. Deze hulpprogrammaklasse biedt functionaliteit voor het importeren van inhoud vanuit een Excel‑werkmap in een presentatie. Ze bevat verschillende overloads van de [AddChartFromWorkbook](https://reference.aspose.com/slides/nl/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/)‑methode, die je helpt de geselecteerde grafiek uit de opgegeven Excel‑werkmap op te halen en deze aan het einde van de opgegeven vormverzameling toe te voegen op de opgegeven coördinaten.

Kortom, het is een lichte en eenvoudige API voor het lezen van Excel‑gegevens — precies wat veel ontwikkelaars nodig hebben zonder de overhead van een volledige spreadsheet‑verwerkingsbibliotheek.

## **Laten we coderen**

### **Voorbeeld van een mail‑merge‑scenario**

In het volgende voorbeeld implementeren we een eenvoudig mail‑merge‑scenario door meerdere presentaties te genereren op basis van gegevens die opgeslagen zijn in een Excel‑werkmap.

Om te beginnen hebben we twee dingen nodig:
1. Een Excel‑werkmap met de gegevens

![Voorbeeld van Excel‑gegevens](example1_image0.png)

2. PowerPoint‑presentatiesjabloon

![Voorbeeld van PowerPoint‑sjabloon](example1_image1.png)

```csharp
// Laad de Excel-werkmap met personeelsgegevens.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Laad de presentatie-sjabloon.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Loop door de Excel-rijen (exclusief de koprij op rij 0).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // Maak een nieuwe presentatie voor elke personeelsrecord.
    using Presentation employeePresentation = new Presentation();

    // Verwijder de standaard lege dia.
    employeePresentation.Slides.RemoveAt(0);

    // Kloon de sjabloondia naar de nieuwe presentatie.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // Haal de alinea's op uit de doelvorm (ervan uitgaande dat vorm-index 1 wordt gebruikt).
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

### **Voorbeeld van een Excel‑tabel**

In het tweede voorbeeld kopiëren we simpelweg gegevens uit een Excel‑tabel en tonen we deze op een PowerPoint‑dia in een visueel aantrekkelijker formaat.

In dit voorbeeld hergebruiken we dezelfde Excel‑werkmap als in het eerste voorbeeld, die een eenvoudige medewerkers‑tabel bevat.

```csharp
// Laad de Excel-werkmap met de personeelsgegevens.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Maak een nieuwe PowerPoint-presentatie.
using Presentation presentation = new Presentation();

// Voeg een tabelvorm toe aan de eerste dia.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// Vul de PowerPoint-tabel met gegevens uit de Excel-werkmap.
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

### **Voorbeeld van het importeren van een Excel‑grafiek**

In dit voorbeeld importeren we een grafiek uit het eerste werkblad van de Excel‑werkmap die in het vorige voorbeeld werd gebruikt. De grafiek zal in de resulterende presentatie linken naar de externe werkmap.

Eerst voegen we een cirkeldiagram toe aan de Excel‑werkmap op basis van de medewerkers‑tabel.

![Voorbeeld van Excel‑grafiek](example3_image0.png)

```csharp
// Maak een nieuwe PowerPoint-presentatie.
using Presentation presentation = new Presentation();

// Haal de vormverzameling van de eerste dia op.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Importeer de grafiek met de naam "Chart 1" van het eerste blad van de werkmap en voeg deze toe aan de vormverzameling.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// Sla de resulterende presentatie op in een bestand.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![Resultaat](example3_image1.png)

### **Voorbeeld van het importeren van alle Excel‑grafieken**

Stel je voor dat je een Excel‑werkmap vol met grafieken hebt en je moet ze allemaal importeren in een presentatie. Elke grafiek moet op een nieuwe dia worden geplaatst.

De volgende code doorloopt alle werkbladen in het bron‑Excel‑bestand, haalt de grafieken uit elk werkblad op en voegt elke grafiek toe aan een aparte dia met een lege dia‑lay‑out. In de resulterende presentatie zal alleen de grafiek‑data worden ingebed, niet de volledige werkmap.

```csharp
// Laad de Excel-werkmap met de personeelsgegevens.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Maak een nieuwe PowerPoint-presentatie.
using Presentation presentation = new Presentation();

// Haal de lege dia‑lay‑out op.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Haalt de namen op van alle werkbladen die zich in de Excel-werkmap bevinden.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // Haal een woordenboek op dat diagram‑indexen naar diagram‑namen voor het werkblad afbeeldt.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // Voeg een nieuwe dia toe met de lege lay‑out.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Importeer het opgegeven diagram uit de Excel-werkmap in de vormverzameling van de dia.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// Sla de resulterende presentatie op in een bestand.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

## **Samenvatting**

Dit mechanisme, direct beschikbaar in Aspose.Slides, combineert het werken met Excel‑gegevens en presentaties op één plek. Het stelt je in staat om dia’s te maken met visuele grafieken en gegevens gepresenteerd als Excel‑tabellen — zonder extra bibliotheken of complexe integraties.