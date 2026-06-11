---
title: Integrera Excel-data i PowerPoint-presentationer
linktitle: Excel-integration
type: docs
weight: 330
url: /sv/net/excel-integration/
keywords:
- Excel
- arbetsbok
- läsa Excel
- integrera Excel
- datakälla
- mailutskick
- importera tabell
- Excel till PowerPoint
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Läs data från Excel-arbetsböcker i Aspose.Slides med ExcelDataWorkbook API. Läs in blad och celler och använd värdena för att skapa data-drivna PowerPoint-presentationer."
---
## **Introduktion**

PowerPoint-presentationer är ett kraftfullt sätt att visa och kommunicera information. De används ofta tillsammans med Excel-arbetsböcker, där Excel fungerar som en utmärkt källa till strukturerad data och PowerPoint briljerar i att visualisera den datan för en publik.

Det finns många praktiska scenarier där kombinationen av Excel och PowerPoint är avgörande: massutskick, ifyllning av datatabeller, generering av en bild per datapost (batch-bildgenerering), skapande av utbildningsmaterial och sammanslagning av flera Excel-rapporter till en enda presentation, för att nämna några.

Hittills har implementeringen av sådana funktioner med Aspose.Slides-API:t krävt att man förlitar sig på tredjepartslösningar som Aspose.Cells. Även om dessa verktyg är robusta kan de vara överdrivet komplexa och kostsamma för användare som bara behöver grundläggande funktionalitet för dataintegration.

## **Hur det fungerar**

För att göra arbetet med Excel-data enklare och mer strömlinjeformat har Aspose.Slides introducerat nya klasser för att läsa data från Excel-arbetsböcker och importera innehåll till en presentation. Denna funktion öppnar kraftfulla nya möjligheter för API-användare som vill utnyttja Excel som datakälla i sina presentationsarbetsflöden.

Den nya funktionaliteten är avsedd för allmän datatillgång och är inte integrerad i Presentation Document Object Model (DOM). Det innebär *att den inte tillåter redigering eller sparande av Excel-filer* — dess enda syfte är att öppna arbetsböcker och navigera genom deras innehåll för att hämta celldata.

Kärnan i denna funktion är den nya [ExcelDataWorkbook](https://reference.aspose.com/slides/sv/net/aspose.slides.excel/exceldataworkbook/)-klassen. Denna klass låter dig läsa in en Excel-arbetsbok från en lokal fil eller en ström. När den är laddad erbjuder den flera överlagringar av [GetCell](https://reference.aspose.com/slides/sv/net/aspose.slides.excel/exceldataworkbook/getcell/)-metoden, som du kan använda för att hämta specifika celler efter deras position (t.ex. rad- och kolumnindex eller namngivna områden).

Varje anrop till [GetCell](https://reference.aspose.com/slides/sv/net/aspose.slides.excel/exceldataworkbook/getcell/) returnerar en instans av [ExcelDataCell](https://reference.aspose.com/slides/sv/net/aspose.slides.excel/exceldatacell/)-klassen. Detta objekt representerar en enskild cell i Excel-arbetsboken och ger dig åtkomst till dess värde på ett enkelt och intuitivt sätt.

#### **Importera ett Excel-diagram**

Nästa steg för att utöka funktionaliteten är [ExcelWorkbookImporter](https://reference.aspose.com/slides/sv/net/aspose.slides.import/excelworkbookimporter/)-klassen. Denna nytta-klass tillhandahåller funktionalitet för att importera innehåll från en Excel-arbetsbok till en presentation. Den innehåller flera överlagringar av [AddChartFromWorkbook](https://reference.aspose.com/slides/sv/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/)-metoden, som hjälper dig att hämta det valda diagrammet från den angivna Excel-arbetsboken och lägga till det i slutet av den givna form-samlingen på de angivna koordinaterna.

Kort sagt är det ett lättviktigt och enkelt API för att läsa Excel-data — exakt vad **många utvecklare behöver** utan **...**.

## **Låt oss koda**

### **Exempel på mail-merge scenario**

I det följande exemplet kommer vi att implementera ett enkelt mail-merge-scenario genom att generera flera presentationer baserat på data lagrad i en Excel-arbetsbok.

För att komma igång behöver vi två saker:
1. En Excel-arbetsbok som innehåller datan

![Exempel på Excel-data](example1_image0.png)

2. PowerPoint-presentation mall

![Exempel på PowerPoint-mall](example1_image1.png)

```csharp
// Ladda Excel-arbetsboken med anställdas data.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Ladda presentationsmallen.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Loopa igenom Excel-rader (exklusive rubrik på rad 0).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // Skapa en ny presentation för varje anställds post.
    using Presentation employeePresentation = new Presentation();

    // Ta bort den förvalda tomma bilden.
    employeePresentation.Slides.RemoveAt(0);

    // Klona mallbilden till den nya presentationen.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // Hämta stycken från målformen (antar att formindex 1 används).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // Ersätt platshållarna med data från Excel.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // Spara den personliga presentationen till en separat fil.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![Resultat](example1_image2.png)

### **Exempel på Excel-tabell**

I det andra exemplet kopierar vi helt enkelt data från en Excel-tabell och visar den på en PowerPoint-bild i ett mer visuellt tilltalande format.

I detta exempel återanvänder vi samma Excel-arbetsbok som i det första exemplet, som innehåller en enkel medarbetartabell.

```csharp
// Ladda Excel-arbetsboken som innehåller anställdas data.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Skapa en ny PowerPoint-presentation.
using Presentation presentation = new Presentation();

// Lägg till en tabellform på den första bilden.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// Fyll PowerPoint-tabellen med data från Excel-arbetsboken.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// Spara den resulterande presentationen till en fil.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![Resultat](example2_image0.png)

### **Exempel på import av Excel-diagram**

I detta exempel importerar vi ett diagram från det första kalkylbladet i den Excel-arbetsbok som användes i föregående exempel. Diagrammet kommer att länka till den externa arbetsboken i den resulterande presentationen.

Först lägger vi till ett cirkeldiagram i Excel-arbetsboken baserat på medarbetartabellen.

![Exempel på Excel-diagram](example3_image0.png)

```csharp
// Skapa en ny PowerPoint-presentation.
using Presentation presentation = new Presentation();

// Get the shapes collection of the first slide.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Importera diagrammet med namnet "Chart 1" från arbetsbokens första blad och lägg till det i form-samlingen.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// Spara den resulterande presentationen till en fil.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![Resultat](example3_image1.png)

### **Exempel på import av alla Excel-diagram**

Föreställ dig att du har en Excel-arbetsbok full av diagram och att du behöver importera dem alla till en presentation. Varje diagram ska placeras på en ny bild.

Följande kod itererar genom alla kalkylblad i käll-Excel-filen, extraherar diagrammen från varje kalkylblad och lägger till varje diagram på en separat bild med ett tomt bildlayout. I den resulterande presentationen kommer endast diagramdata att bäddas in, inte hela arbetsboken.

```csharp
// Ladda Excel-arbetsboken som innehåller anställdas data.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Skapa en ny PowerPoint-presentation.
using Presentation presentation = new Presentation();

// Hämta den tomma bildlayouten.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Hämta namnen på alla kalkylblad som finns i Excel-arbetsboken.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // Hämta en ordbok som mappar diagramindex till diagramnamn för kalkylbladet.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // Lägg till en ny bild med den tomma layouten.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Importera det angivna diagrammet från Excel-arbetsboken till bildens form-samling.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// Spara den resulterande presentationen till en fil.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

## **Sammanfattning**

Denna mekanism, som finns direkt i Aspose.Slides, kombinerar arbete med Excel-data och presentationer på ett ställe. Den låter dig skapa bilder med visuella diagram och data presenterade som Excel-tabeller — utan några extra bibliotek eller komplexa integrationer.