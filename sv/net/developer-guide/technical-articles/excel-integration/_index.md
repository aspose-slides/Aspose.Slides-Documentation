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
- mail-sammanfogning
- importera tabell
- Excel till PowerPoint
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Läs data från Excel-arbetsböcker i Aspose.Slides med ExcelDataWorkbook-API:t. Läs in blad och celler och använd värdena för att skapa datadrivna PowerPoint-presentationer."
---
## **Introduktion**

PowerPoint-presentationer är ett kraftfullt sätt att visa och kommunicera information. De används ofta tillsammans med Excel-arbetsböcker, där Excel fungerar som en utmärkt källa till strukturerad data och PowerPoint är utmärkt på att visualisera den data för en publik.

Det finns många praktiska scenarier där kombinationen av Excel och PowerPoint är nödvändig: mail merges, fylla i datatabeller, generera en bild per datapost (batch slide generation), skapa träningsmaterial och samla flera Excel-rapporter i en enda presentation, för att nämna några.

Hittills har implementeringen av sådana funktioner med Aspose.Slides API krävt att man förlitar sig på tredjepartslösningar som Aspose.Cells. Även om dessa verktyg är robusta kan de vara alltför komplexa och kostsamma för användare som bara behöver grundläggande funktionalitet för dataintegration.

## **Hur det fungerar**

För att göra arbetet med Excel-data enklare och mer strömlinjeformat har Aspose.Slides introducerat nya klasser för att läsa data från Excel-arbetsböcker och importera innehåll till en presentation. Denna funktion öppnar upp kraftfulla nya möjligheter för API-användare som vill utnyttja Excel som datakälla i sina presentationsarbetsflöden.

Den nya funktionaliteten är avsedd för generell dataåtkomst och är inte integrerad i Presentation Document Object Model (DOM). Det innebär att *den inte tillåter redigering eller sparande av Excel-filer* — dess enda syfte är att öppna arbetsböcker och navigera genom deras innehåll för att hämta celldata.

I centrum för denna funktion finns den nya klassen [ExcelDataWorkbook](https://reference.aspose.com/slides/sv/net/aspose.slides.excel/exceldataworkbook/). Denna klass låter dig läsa in en Excel-arbetsbok från en lokal fil eller en ström. När den är inläst erbjuder den flera överlagringar av metoden [GetCell](https://reference.aspose.com/slides/sv/net/aspose.slides.excel/exceldataworkbook/getcell/), som du kan använda för att hämta specifika celler efter deras position (t.ex. rad- och kolumn-index eller namngivna områden).

Varje anrop till [GetCell](https://reference.aspose.com/slides/sv/net/aspose.slides.excel/exceldataworkbook/getcell/) returnerar en instans av klassen [ExcelDataCell](https://reference.aspose.com/slides/sv/net/aspose.slides.excel/exceldatacell/). Detta objekt representerar en enskild cell i Excel‑arbetsboken och ger dig åtkomst till dess värde på ett enkelt och intuitivt sätt.

#### **Importera ett Excel‑diagram**

Nästa steg för att utöka funktionaliteten är klassen [ExcelWorkbookImporter](https://reference.aspose.com/slides/sv/net/aspose.slides.import/excelworkbookimporter/). Denna verktygsklass tillhandahåller funktionalitet för att importera innehåll från en Excel‑arbetsbok till en presentation. Den innehåller flera överlagringar av metoden [AddChartFromWorkbook](https://reference.aspose.com/slides/sv/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/), som hjälper dig att hämta det valda diagrammet från den angivna Excel‑arbetsboken och lägga till det i slutet av den givna formsamlingen på de specificerade koordinaterna.

#### **Importera en Excel‑tabell**

[ExcelWorkbookImporter](https://reference.aspose.com/slides/sv/net/aspose.slides.import/excelworkbookimporter/)-klassen innehåller också flera överlagringar av metoden [AddTableFromWorkbook](https://reference.aspose.com/slides/sv/net/aspose.slides.import/excelworkbookimporter/addtablefromworkbook/). Dessa metoder låter dig importera ett specificerat cellområde från ett specificerat arbetsblad och lägga till det som en tabell i slutet av den givna formsamlingen på de specificerade koordinaterna.

Kort sagt är det ett lättviktigt och okomplicerat API för att läsa Excel-data — precis vad många utvecklare behöver utan overheaden från ett fullständigt kalkylbladsbearbetningsbibliotek.

## **Låt oss koda**

### **Exempel på mail‑sammanfogning**

I följande exempel kommer vi att implementera ett enkelt mail‑merge‑scenario genom att skapa flera presentationer baserade på data lagrade i en Excel‑arbetsbok.

För att komma igång behöver vi två saker:
1. En Excel‑arbetsbok som innehåller data

![Excel data example](example1_image0.png)

2. PowerPoint‑presentationsmall

![PowerPoint template example](example1_image1.png)

```csharp
// Läs in Excel-arbetsboken med anställdas data.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Läs in presentationsmallen.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Iterera genom Excel-rader (exkluderar rubrik på rad 0).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // Skapa en ny presentation för varje anställds post.
    using Presentation employeePresentation = new Presentation();

    // Ta bort den förinställda tomma bilden.
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

    // Spara den anpassade presentationen till en separat fil.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![Result](example1_image2.png)

### **Exempel på Excel‑tabell**

I det andra exemplet kopierar vi helt enkelt data från en Excel‑tabell och visar den på en PowerPoint‑bild i ett mer visuellt tilltalande format.

I detta exempel återanvänder vi samma Excel‑arbetsbok som i det första exemplet, vilken innehåller en enkel medarbetartabell.

```csharp
// Läs in Excel-arbetsboken som innehåller anställdas data.
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

![Result](example2_image0.png)

### **Exempel på import av Excel‑diagram**

I detta exempel importerar vi ett diagram från det första arbetsbladet i den Excel‑arbetsbok som användes i föregående exempel. Diagrammet kommer att länka till den externa arbetsboken i den resulterande presentationen.

Först lägger vi till ett cirkeldiagram i Excel‑arbetsboken baserat på medarbetartabellen.

![Excel Chart example](example3_image0.png)

```csharp
// Skapa en ny PowerPoint-presentation.
using Presentation presentation = new Presentation();

// Hämta formsamlingen för den första bilden.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Importera diagrammet med namnet "Chart 1" från det första bladet i arbetsboken och lägg till det i formsamlingen.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// Spara den resulterande presentationen till en fil.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![Result](example3_image1.png)

### **Exempel på import av alla Excel‑diagram**

Föreställ dig att du har en Excel‑arbetsbok full av diagram och att du behöver importera dem alla till en presentation. Varje diagram ska placeras på en ny bild.

Den följande koden itererar genom alla arbetsblad i käll‑Excel‑filen, extraherar diagrammen från varje arbetsblad och lägger till varje diagram på en separat bild med ett tomt bildlayout. I den resulterande presentationen kommer endast diagramdata att bäddas in, inte hela arbetsboken.

```csharp
// Läs in Excel-arbetsboken som innehåller anställdas data.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Skapa en ny PowerPoint-presentation.
using Presentation presentation = new Presentation();

// Hämta den tomma bildlayouten.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Hämta namnen på alla arbetsblad som finns i Excel-arbetsboken.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // Hämta en dictionary som mappar diagramindex till diagramnamn för arbetsbladet.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // Lägg till en ny bild med den tomma layouten.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Importera det specificerade diagrammet från Excel-arbetsboken till bildens formsamling.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// Spara den resulterande presentationen till en fil.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

### **Exempel på import av en Excel‑tabell**

I detta exempel importerar vi en formaterad tabell från ett Excel‑arbetsblad direkt till en PowerPoint‑presentation.

Käll‑Excel‑arbetsbladet innehåller en formaterad tabell med medarbetardata:

![Excel Table example](example4_image0.png)

```csharp
// Skapa en ny PowerPoint-presentation.
using Presentation presentation = new Presentation();

// Hämta formsamlingen för den första bilden.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Importera tabellen från det första bladet i arbetsboken och lägg till den i formsamlingen.
ExcelWorkbookImporter.AddTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5");

// Spara den resulterande presentationen till en fil.
presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
```
![Result](example4_image1.png)

## **Sammanfattning**

Denna mekanism, tillgänglig direkt i Aspose.Slides, kombinerar arbete med Excel-data och presentationer på ett ställe. Den låter dig skapa bilder med visuella diagram och data presenterade som Excel‑tabeller – utan några ytterligare bibliotek eller komplexa integrationer.