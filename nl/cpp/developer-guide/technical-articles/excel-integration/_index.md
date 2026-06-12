---
title: Excel-gegevens integreren in PowerPoint-presentaties
linktitle: Excel-integratie
type: docs
weight: 330
url: /nl/cpp/excel-integration/
keywords:
- Excel
- werkboek
- Excel lezen
- Excel integreren
- gegevensbron
- mail-merge
- tabel importeren
- Excel naar PowerPoint
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Lees gegevens uit Excel-werkboeken in Aspose.Slides met behulp van de ExcelDataWorkbook-API. Laad werkbladen en cellen en gebruik de waarden om gegevensgestuurde PowerPoint-presentaties te genereren."
---
## **Inleiding**

PowerPoint‑presentaties zijn een krachtige manier om informatie weer te geven en te communiceren. Ze worden vaak gebruikt in combinatie met Excel‑werkboeken, waarbij Excel een uitstekende bron van gestructureerde gegevens is en PowerPoint uitblinkt in het visualiseren van die gegevens voor een publiek.

Er zijn veel praktische scenario’s waarbij het combineren van Excel en PowerPoint essentieel is: standaardbrieven, het vullen van datatabellen, het genereren van één dia per gegevensrecord (batch‑dia‑generatie), het maken van trainingsmateriaal, en het samenvoegen van meerdere Excel‑rapporten tot één enkele presentatie, om er maar een paar te noemen.

Tot nu toe vereiste het implementeren van dergelijke functionaliteit met de Aspose.Slides‑API het gebruik van derde‑partij‑oplossingen zoals Aspose.Cells. Hoewel deze tools robuust zijn, kunnen ze onnodig complex en kostbaar zijn voor gebruikers die alleen basis‑integratie van gegevens nodig hebben.

## **Hoe het werkt**

Om het werken met Excel‑gegevens eenvoudiger en efficiënter te maken, heeft Aspose.Slides nieuwe klassen geïntroduceerd voor het lezen van gegevens uit Excel‑werkboeken en het importeren van inhoud in een presentatie. Deze functie opent krachtige nieuwe mogelijkheden voor API‑gebruikers die Excel willen gebruiken als gegevensbron binnen hun presentatieworkflows.

De nieuwe functionaliteit is bedoeld voor algemene gegevens­toegang en is niet geïntegreerd in het Presentation Document Object Model (DOM). Dat betekent *dat het geen bewerken of opslaan van Excel‑bestanden toestaat* – het enige doel is het openen van werkboeken en doorlopen van hun inhoud om celgegevens op te halen.

In het hart van deze functie staat de nieuwe [ExcelDataWorkbook](https://reference.aspose.com/slides/nl/cpp/aspose.slides.excel/exceldataworkbook/)‑klasse. Deze klasse maakt het mogelijk een Excel‑werkboek te laden vanuit een lokaal bestand of een stream. Eenmaal geladen biedt hij verschillende overloads van de [GetCell](https://reference.aspose.com/slides/nl/cpp/aspose.slides.excel/exceldataworkbook/getcell/)‑methode, waarmee je specifieke cellen kunt ophalen op basis van hun positie (bijv. rij‑ en kolom‑indices of benoemde bereiken).

Elke oproep van [GetCell](https://reference.aspose.com/slides/nl/cpp/aspose.slides.excel/exceldataworkbook/getcell/) retourneert een instantie van de [ExcelDataCell](https://reference.aspose.com/slides/nl/cpp/aspose.slides.excel/exceldatacell/)‑klasse. Dit object vertegenwoordigt één cel in het Excel‑werkboek en geeft je eenvoudige en intuïtieve toegang tot de waarde ervan.

#### **Een Excel‑grafiek importeren**

De volgende stap om de functionaliteit uit te breiden is de [ExcelWorkbookImporter](https://reference.aspose.com/slides/nl/cpp/aspose.slides.import/excelworkbookimporter/)‑klasse. Deze hulpprogrammaklasse biedt functionaliteit voor het importeren van inhoud uit een Excel‑werkboek naar een presentatie. Hij bevat verschillende overloads van de [AddChartFromWorkbook](https://reference.aspose.com/slides/nl/cpp/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/)‑methode, die je helpen de geselecteerde grafiek uit het opgegeven Excel‑werkboek op te halen en toe te voegen aan het einde van de opgegeven shape‑collectie op de opgegeven coördinaten.

Kortom, het is een lichte en eenvoudige API voor het lezen van Excel‑gegevens – precies wat veel ontwikkelaars nodig hebben zonder de overhead van een volledige spreadsheet‑verwerkingsbibliotheek.

## **Laten we coderen**

### **Voorbeeld van een mail‑merge‑scenario**

In het volgende voorbeeld implementeren we een eenvoudig mail‑merge‑scenario door meerdere presentaties te genereren op basis van gegevens die opgeslagen zijn in een Excel‑werkboek.

Om te beginnen hebben we twee dingen nodig:
1. Een Excel‑werkboek met de gegevens

![Excel data example](example1_image0.png)

2. PowerPoint‑presentatiesjabloon

![PowerPoint template example](example1_image1.png)

```cpp
// Laad het Excel-werkboek met werknemersgegevens.
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// Laad de presentatiesjabloon.
auto templatePresentation = MakeObject<Presentation>(u"PresentationTemplate.pptx");

    // Loop door de Excel-rijen (exclusief koprij op rij 0).
for (auto rowIndex = 1; rowIndex <= 4; rowIndex++) {

    // Maak een nieuwe presentatie aan voor elk werknemersrecord.
    auto employeePresentation = MakeObject<Presentation>();

    // Verwijder de standaard lege dia.
    employeePresentation->get_Slides()->RemoveAt(0);

    // Kloon de sjabloondia naar de nieuwe presentatie.
    auto slide = employeePresentation->get_Slides()->AddClone(templatePresentation->get_Slide(0));

    // Haal de alinea's op van de doelvorm (ervan uitgaande dat vorm-index 1 wordt gebruikt).
    auto paragraphs = ExplicitCast<IAutoShape>(slide->get_Shape(1))->get_TextFrame()->get_Paragraphs();

    // Vervang de placeholders door gegevens uit Excel.
    auto employeeName = workbook->GetCell(worksheetIndex, rowIndex, 0)->get_Value()->ToString();
    auto namePortion = paragraphs->idx_get(0)->get_Portion(0);
    namePortion->set_Text(namePortion->get_Text().Replace(u"{{EmployeeName}}", employeeName));

    auto department = workbook->GetCell(worksheetIndex, rowIndex, 1)->get_Value()->ToString();
    auto departmentPortion = paragraphs->idx_get(1)->get_Portion(0);
    departmentPortion->set_Text(departmentPortion->get_Text().Replace(u"{{Department}}", department));

    auto yearsOfService = workbook->GetCell(worksheetIndex, rowIndex, 2)->get_Value()->ToString();
    auto yearsPortion = paragraphs->idx_get(2)->get_Portion(0);
    yearsPortion->set_Text(yearsPortion->get_Text().Replace(u"{{YearsOfService}}", yearsOfService));

    // Sla de gepersonaliseerde presentatie op in een apart bestand.
    employeePresentation->Save(String::Format(u"{0} Report.pptx", employeeName), SaveFormat::Pptx);
    employeePresentation->Dispose();
}

templatePresentation->Dispose();
```

![Result](example1_image2.png)

### **Voorbeeld van een Excel‑tabel**

In het tweede voorbeeld kopiëren we eenvoudig gegevens uit een Excel‑tabel en tonen we die op een PowerPoint‑dia in een aantrekkelijker formaat.

In dit voorbeeld gebruiken we opnieuw hetzelfde Excel‑werkboek als in het eerste voorbeeld, dat een eenvoudige medewerkers‑tabel bevat.

```cpp
// Laad het Excel-werkboek met de werknemersgegevens.
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// Maak een nieuwe PowerPoint-presentatie.
auto presentation = MakeObject<Presentation>();

// Voeg een tabelvorm toe aan de eerste dia.
auto table = presentation->get_Slide(0)->get_Shapes()->AddTable(
    50, 200,
    MakeArray<double>({200, 200, 200}),
    MakeArray<double>({30, 30, 30, 30, 30})
);

// Vul de PowerPoint-tabel met gegevens uit het Excel-werkboek.
for (auto rowIndex = 0; rowIndex < 5; rowIndex++) {
    for (auto columnIndex = 0; columnIndex < 3; columnIndex++) {
        auto cellValue = workbook->GetCell(worksheetIndex, rowIndex, columnIndex)->get_Value()->ToString();
        table->get_Column(columnIndex)->idx_get(rowIndex)->get_TextFrame()->set_Text(cellValue);
    }
}

// Sla de resulterende presentatie op naar een bestand.
presentation->Save(u"Table.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Result](example2_image0.png)

### **Voorbeeld van het importeren van een Excel‑grafiek**

In dit voorbeeld importeren we een grafiek van het eerste werkblad van het Excel‑werkboek dat in het vorige voorbeeld werd gebruikt. De grafiek zal in de resulterende presentatie koppelen naar het externe werkboek.

Eerst voegen we een taartgrafiek toe aan het Excel‑werkboek op basis van de medewerkers‑tabel.

![Excel Chart example](example3_image0.png)

```cpp
// Maak een nieuwe PowerPoint-presentatie.
auto presentation = MakeObject<Presentation>();

// Haal de vormverzameling op van de eerste dia.
auto shapes = presentation->get_Slide(0)->get_Shapes();

// Importeer de grafiek met de naam "Chart 1" van het eerste blad van het werkboek en voeg deze toe aan de vormverzameling.
ExcelWorkbookImporter::AddChartFromWorkbook(shapes, 10.0, 10.0, u"TemplateData.xlsx", u"Sheet1", u"Chart 1", false);

// Sla de resulterende presentatie op naar een bestand.
presentation->Save(u"Chart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Result](example3_image1.png)

### **Voorbeeld van het importeren van alle Excel‑grafieken**

Stel je voor dat je een Excel‑werkboek vol grafieken hebt en je wilt ze allemaal importeren in een presentatie. Elke grafiek moet op een nieuwe dia worden geplaatst.

De volgende code loopt door alle werkbladen in het bron‑Excel‑bestand, haalt de grafieken uit elk werkblad op en voegt elke grafiek toe aan een aparte dia met een lege dia‑lay‑out. In de resulterende presentatie wordt alleen de grafiek‑data ingebed, niet het volledige werkboek.

```cpp
// Laad het Excel-werkboek met de werknemersgegevens.
auto workbook = MakeObject<ExcelDataWorkbook>(u"ExcelWithCharts.xlsx");

// Maak een nieuwe PowerPoint-presentatie.
auto presentation = MakeObject<Presentation>();

// Haal de lege dia‑lay-out op.
auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// Haal de namen op van alle werkbladen die in het Excel-werkboek zitten.
auto worksheetNames = workbook->GetWorksheetNames();

for (auto&& name : worksheetNames)
{
    // Haal een woordenboek op dat diagram‑indexen naar diagramnamen voor het werkblad koppelt.
    auto worksheetCharts = workbook->GetChartsFromWorksheet(name);

    for (auto&& chart : worksheetCharts)
    {
        // Voeg een nieuwe dia toe met de lege lay-out.
        auto slide = presentation->get_Slides()->AddEmptySlide(blankLayout);

        // Importeer het opgegeven diagram uit het Excel-werkboek naar de vormverzameling van de dia.
        ExcelWorkbookImporter::AddChartFromWorkbook(slide->get_Shapes(), 10.0, 10.0, workbook, name, chart.get_Key(), false);
    }
}

// Sla de resulterende presentatie op naar een bestand.
presentation->Save(u"Charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Samenvatting**

Dit mechanisme, direct beschikbaar in Aspose.Slides, combineert het werken met Excel‑gegevens en presentaties op één plaats. Het stelt je in staat dia’s te maken met visuele grafieken en gegevens weergegeven als Excel‑tabellen – zonder extra bibliotheken of complexe integraties.