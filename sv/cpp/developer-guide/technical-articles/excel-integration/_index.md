---
title: Integrera Excel-data i PowerPoint-presentationer
linktitle: Excel-integration
type: docs
weight: 330
url: /sv/cpp/excel-integration/
keywords:
- Excel
- arbetsbok
- läs Excel
- integrera Excel
- datakälla
- mailutskick
- importera tabell
- Excel till PowerPoint
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Läs data från Excel-arbetsböcker i Aspose.Slides med hjälp av ExcelDataWorkbook-API:t. Läs in blad och celler och använd värdena för att skapa datadrivna PowerPoint-presentationer."
---
## **Introduktion**

PowerPoint-presentationer är ett kraftfullt sätt att visa och förmedla information. De används ofta tillsammans med Excel-arbetsböcker, där Excel fungerar som en utmärkt källa till strukturerad data och PowerPoint är bra på att visualisera den för en publik.

Det finns många praktiska scenarier där kombinationen av Excel och PowerPoint är avgörande: kopplade utskick (mail merge), fylla i datatabeller, skapa en bild per datapost (batch‑bildgenerering), skapa träningsmaterial och samla flera Excel-rapporter i en enda presentation, för att nämna några.

Hittills har implementeringen av sådana funktioner med Aspose.Slides‑API:t krävt att man förlitade sig på tredjepartslösningar som Aspose.Cells. Även om dessa verktyg är robusta kan de vara alltför komplexa och dyra för användare som bara behöver grundläggande funktionalitet för dataintegration.

## **Hur det fungerar**

För att göra arbetet med Excel‑data enklare och smidigare har Aspose.Slides introducerat nya klasser för att läsa data från Excel‑arbetsböcker och importera innehåll till en presentation. Denna funktion öppnar upp kraftfulla nya möjligheter för API‑användare som vill utnyttja Excel som datakälla i sina presentationsarbetsflöden.

Den nya funktionaliteten är avsedd för allmän datatillgång och är inte integrerad i Presentation Document Object Model (DOM). Det betyder att *den inte tillåter redigering eller sparande av Excel‑filer* — dess enda syfte är att öppna arbetsböcker och navigera i deras innehåll för att hämta celldata.

Kärnan i denna funktion är den nya klassen [ExcelDataWorkbook](https://reference.aspose.com/slides/sv/cpp/aspose.slides.excel/exceldataworkbook/). Denna klass låter dig läsa in en Excel‑arbetsbok från en lokal fil eller ett flöde. När den är inläst erbjuder den flera överlagringar av metoden [GetCell](https://reference.aspose.com/slides/sv/cpp/aspose.slides.excel/exceldataworkbook/getcell/), som du kan använda för att hämta specifika celler efter deras position (t.ex. rad‑ och kolumnindex eller namngivna områden).

Varje anrop till [GetCell](https://reference.aspose.com/slides/sv/cpp/aspose.slides.excel/exceldataworkbook/getcell/) returnerar en instans av klassen [ExcelDataCell](https://reference.aspose.com/slides/sv/cpp/aspose.slides.excel/exceldatacell/). Detta objekt representerar en enskild cell i Excel‑arbetsboken och ger dig åtkomst till dess värde på ett enkelt och intuitivt sätt.

#### **Importera ett Excel‑diagram**

Nästa steg för att utöka funktionaliteten är klassen [ExcelWorkbookImporter](https://reference.aspose.com/slides/sv/cpp/aspose.slides.import/excelworkbookimporter/). Denna verktygsklass tillhandahåller funktioner för att importera innehåll från en Excel‑arbetsbok till en presentation. Den innehåller flera överlagringar av metoden [AddChartFromWorkbook](https://reference.aspose.com/slides/sv/cpp/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/), som hjälper dig att hämta det valda diagrammet från den specificerade Excel‑arbetsboken och lägga till det i slutet av den angivna formsamlingen på de angivna koordinaterna.

Kort sagt är det ett lättviktigt och enkelt API för att läsa Excel‑data — precis vad många utvecklare behöver utan bördan av ett fullständigt kalkylbladsbibliotek.

## **Låt oss koda**

### **Exempel på mail‑merge‑scenario**

I följande exempel kommer vi att implementera ett enkelt mail‑merge‑scenario genom att generera flera presentationer baserade på data som lagras i en Excel‑arbetsbok.

För att komma igång behöver vi två saker:
1. En Excel‑arbetsbok som innehåller data

![Exempel på Excel‑data](example1_image0.png)

2. PowerPoint‑presentationsmall

![Exempel på PowerPoint‑mall](example1_image1.png)

```cpp
// Läs in Excel-arbetsboken med anställdas data.
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// Läs in presentationsmallen.
auto templatePresentation = MakeObject<Presentation>(u"PresentationTemplate.pptx");

    // Loopa igenom Excel-rader (exklusive rubriken på rad 0).
for (auto rowIndex = 1; rowIndex <= 4; rowIndex++) {

    // Skapa en ny presentation för varje anställdpost.
    auto employeePresentation = MakeObject<Presentation>();

    // Ta bort den standardtomma bilden.
    employeePresentation->get_Slides()->RemoveAt(0);

    // Klona mallbilden till den nya presentationen.
    auto slide = employeePresentation->get_Slides()->AddClone(templatePresentation->get_Slide(0));

    // Hämta stycken från målformen (antar att formindex 1 används).
    auto paragraphs = ExplicitCast<IAutoShape>(slide->get_Shape(1))->get_TextFrame()->get_Paragraphs();

    // Byt ut platshållarna med data från Excel.
    auto employeeName = workbook->GetCell(worksheetIndex, rowIndex, 0)->get_Value()->ToString();
    auto namePortion = paragraphs->idx_get(0)->get_Portion(0);
    namePortion->set_Text(namePortion->get_Text().Replace(u"{{EmployeeName}}", employeeName));

    auto department = workbook->GetCell(worksheetIndex, rowIndex, 1)->get_Value()->ToString();
    auto departmentPortion = paragraphs->idx_get(1)->get_Portion(0);
    departmentPortion->set_Text(departmentPortion->get_Text().Replace(u"{{Department}}", department));

    auto yearsOfService = workbook->GetCell(worksheetIndex, rowIndex, 2)->get_Value()->ToString();
    auto yearsPortion = paragraphs->idx_get(2)->get_Portion(0);
    yearsPortion->set_Text(yearsPortion->get_Text().Replace(u"{{YearsOfService}}", yearsOfService));

    // Spara den personliga presentationen till en separat fil.
    employeePresentation->Save(String::Format(u"{0} Report.pptx", employeeName), SaveFormat::Pptx);
    employeePresentation->Dispose();
}

templatePresentation->Dispose();
```

![Resultat](example1_image2.png)

### **Exempel på Excel‑tabell**

I det andra exemplet kopierar vi helt enkelt data från en Excel‑tabell och visar den på en PowerPoint‑bild i ett mer visuellt tilltalande format.

I detta exempel återanvänder vi samma Excel‑arbetsbok som i det första exemplet, som innehåller en enkel anställdatabel.

```cpp
// Läs in Excel-arbetsboken som innehåller anställdas data.
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// Skapa en ny PowerPoint-presentation.
auto presentation = MakeObject<Presentation>();

// Lägg till en tabellform på den första bilden.
auto table = presentation->get_Slide(0)->get_Shapes()->AddTable(
    50, 200,
    MakeArray<double>({200, 200, 200}),
    MakeArray<double>({30, 30, 30, 30, 30})
);

// Fyll PowerPoint-tabellen med data från Excel-arbetsboken.
for (auto rowIndex = 0; rowIndex < 5; rowIndex++) {
    for (auto columnIndex = 0; columnIndex < 3; columnIndex++) {
        auto cellValue = workbook->GetCell(worksheetIndex, rowIndex, columnIndex)->get_Value()->ToString();
        table->get_Column(columnIndex)->idx_get(rowIndex)->get_TextFrame()->set_Text(cellValue);
    }
}

// Spara den resulterande presentationen till en fil.
presentation->Save(u"Table.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Resultat](example2_image0.png)

### **Exempel på import av Excel‑diagram**

I detta exempel importerar vi ett diagram från det första kalkylbladet i den Excel‑arbetsbok som användes i föregående exempel. Diagrammet kommer att länkas till den externa arbetsboken i den resulterande presentationen.

Först lägger vi till ett cirkeldiagram i Excel‑arbetsboken baserat på anställdatabeln.

![Exempel på Excel‑diagram](example3_image0.png)

```cpp
// Skapa en ny PowerPoint-presentation.
auto presentation = MakeObject<Presentation>();

// Hämta shapes-samlingen för den första bilden.
auto shapes = presentation->get_Slide(0)->get_Shapes();

// Importera diagrammet med namnet "Chart 1" från det första bladet i arbetsboken och lägg till det i shapes-samlingen.
ExcelWorkbookImporter::AddChartFromWorkbook(shapes, 10.0, 10.0, u"TemplateData.xlsx", u"Sheet1", u"Chart 1", false);

// Spara den resulterande presentationen till en fil.
presentation->Save(u"Chart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Resultat](example3_image1.png)

### **Exempel på import av alla Excel‑diagram**

Föreställ dig att du har en Excel‑arbetsbok full av diagram och du behöver importera dem alla till en presentation. Varje diagram ska placeras på en ny bild.

Följande kod itererar genom alla kalkylblad i käll‑Excel‑filen, extraherar diagrammen från varje blad och lägger till varje diagram på en separat bild med en tom bildlayout. I den resulterande presentationen kommer endast diagramdata att bäddas in, inte hela arbetsboken.

```cpp
// Läs in Excel-arbetsboken som innehåller anställdas data.
auto workbook = MakeObject<ExcelDataWorkbook>(u"ExcelWithCharts.xlsx");

// Skapa en ny PowerPoint-presentation.
auto presentation = MakeObject<Presentation>();

// Hämta den tomma bildlayouten.
auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// Hämta namnen på alla kalkylblad som finns i Excel-arbetsboken.
auto worksheetNames = workbook->GetWorksheetNames();

for (auto&& name : worksheetNames)
{
    // Hämta en dictionary som mappar diagramindex till diagramnamn för kalkylbladet.
    auto worksheetCharts = workbook->GetChartsFromWorksheet(name);

    for (auto&& chart : worksheetCharts)
    {
        // Lägg till en ny bild med den tomma layouten.
        auto slide = presentation->get_Slides()->AddEmptySlide(blankLayout);

        // Importera det angivna diagrammet från Excel-arbetsboken till bildens shapes-samling.
        ExcelWorkbookImporter::AddChartFromWorkbook(slide->get_Shapes(), 10.0, 10.0, workbook, name, chart.get_Key(), false);
    }
}

// Spara den resulterande presentationen till en fil.
presentation->Save(u"Charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Sammanfattning**

Denna mekanism, som finns direkt i Aspose.Slides, kombinerar arbete med Excel‑data och presentationer på ett ställe. Den låter dig skapa bilder med visuella diagram och data presenterade som Excel‑tabeller – utan några ytterligare bibliotek eller komplexa integrationer.