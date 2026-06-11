---
title: Integrera Excel-data i PowerPoint-presentationer
linktitle: Excel-integration
type: docs
weight: 330
url: /sv/php-java/excel-integration/
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
- PHP
- Aspose.Slides
description: "Läs data från Excel-arbetsböcker med Aspose.Slides för PHP via Java. Läs in blad och celler och använd värdena för att skapa datadrivna PowerPoint-presentationer."
---
## **Introduktion**

PowerPoint-presentationer är ett kraftfullt sätt att visa och kommunicera information. De används ofta tillsammans med Excel-arbetsböcker, där Excel fungerar som en utmärkt källa till strukturerad data och PowerPoint är starkt på att visualisera den datan för en publik.

Det finns många praktiska scenarier där kombinationen av Excel och PowerPoint är avgörande: kopplad utskick, ifyllning av datatabeller, generering av en bild per datapost (batch-bildgenerering), skapande av träningsmaterial och sammanslagning av flera Excel-rapporter till en enda presentation, för att nämna några.

Hittills har implementering av sådana funktioner med Aspose.Slides API krävt att man förlitade sig på tredjepartslösningar som Aspose.Cells. Även om dessa verktyg är robusta kan de vara onödigt komplexa och kostsamma för användare som bara behöver grundläggande funktionalitet för dataintegration.

## **Hur det fungerar**

För att göra arbetet med Excel-data enklare och mer strömlinjeformat har Aspose.Slides introducerat nya klasser för att läsa data från Excel-arbetsböcker och importera innehåll till en presentation. Denna funktion öppnar kraftfulla nya möjligheter för API-användare som vill utnyttja Excel som datakälla i sina presentationsarbetsflöden.

Den nya funktionaliteten är avsedd för allmän dataåtkomst och är inte integrerad i Presentation Document Object Model (DOM). Det innebär att *den inte tillåter redigering eller sparande av Excel-filer* — dess enda syfte är att öppna arbetsböcker och navigera genom deras innehåll för att hämta celldata.

Kärnan i denna funktion är den nya klassen [ExcelDataWorkbook](https://reference.aspose.com/slides/sv/php-java/aspose.slides/exceldataworkbook/). Denna klass låter dig läsa in en Excel-arbetsbok från en lokal fil eller en ström. När den är inläst erbjuder den flera överlagringar av metoden [getCell](https://reference.aspose.com/slides/sv/php-java/aspose.slides/exceldataworkbook/#getCell), som du kan använda för att hämta specifika celler efter deras position (t.ex. rad‑ och kolumnindex eller namngivna områden).

Varje anrop till [getCell](https://reference.aspose.com/slides/sv/php-java/aspose.slides/exceldataworkbook/#getCell) returnerar en instans av klassen [ExcelDataCell](https://reference.aspose.com/slides/sv/php-java/aspose.slides/exceldatacell/). Detta objekt representerar en enskild cell i Excel-arbetsboken och ger dig tillgång till dess värde på ett enkelt och intuitivt sätt.

#### **Importera ett Excel‑diagram**

Nästa steg för att utöka funktionaliteten är klassen [ExcelWorkbookImporter](https://reference.aspose.com/slides/sv/php-java/aspose.slides/excelworkbookimporter/). Denna verktygsklass tillhandahåller funktionalitet för att importera innehåll från en Excel-arbetsbok till en presentation. Den innehåller flera överlagringar av metoden [addChartFromWorkbook](https://reference.aspose.com/slides/sv/php-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook), som hjälper dig att hämta det valda diagrammet från den angivna Excel-arbetsboken och lägga till det i slutet av den angivna formsamlingen på de specificerade koordinaterna.

Kort sagt är det ett lättviktigt och enkelt API för att läsa Excel-data — exakt vad många utvecklare behöver utan belastningen av ett fullständigt kalkylbladsbibliotek.

## **Låt oss koda**

### **Exempel på utskick med kopplad data**

I följande exempel kommer vi att implementera ett enkelt utskick‑scenario genom att generera flera presentationer baserade på data lagrade i en Excel-arbetsbok.

För att komma igång behöver vi två saker:
1. En Excel-arbetsbok som innehåller data

![Exempel på Excel‑data](example1_image0.png)

2. PowerPoint‑presentationsmall

![Exempel på PowerPoint‑mall](example1_image1.png)

```php
// Läs in Excel-arbetsboken med medarbetardata.
$workbook = new ExcelDataWorkbook("TemplateData.xlsx");
$worksheetIndex = 0;

// Läs in presentationsmallen.
$templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // Iterera genom Excel-raderna (exkluderar rubrik på rad 0).
    for ($rowIndex = 1; $rowIndex <= 4; $rowIndex++) {

        // Skapa en ny presentation för varje medarbetarpost.
        $employeePresentation = new Presentation();

        try {
            // Ta bort den förvalda tomma bilden.
            $employeePresentation->getSlides()->removeAt(0);

            // Klona mallbilden till den nya presentationen.
            $slide = $employeePresentation->getSlides()->addClone($templatePresentation->getSlides()->get_Item(0));

            // Hämta stycken från målformen (antar att formindex 1 används).
            $paragraphs = $slide->getShapes()->get_Item(1)->getTextFrame()->getParagraphs();

            // Ersätt platshållarna med data från Excel.
            $employeeName = $workbook->getCell($worksheetIndex, $rowIndex, 0)->getValue()->toString();
            $namePortion = $paragraphs->get_Item(0)->getPortions()->get_Item(0);
            $namePortion->setText($namePortion->getText()->replace("{{EmployeeName}}", $employeeName));

            $department = $workbook->getCell($worksheetIndex, $rowIndex, 1)->getValue()->toString();
            $departmentPortion = $paragraphs->get_Item(1)->getPortions()->get_Item(0);
            $departmentPortion->setText($departmentPortion->getText()->replace("{{Department}}", $department));

            $yearsOfService = $workbook->getCell($worksheetIndex, $rowIndex, 2)->getValue()->toString();
            $yearsPortion = $paragraphs->get_Item(2)->getPortions()->get_Item(0);
            $yearsPortion->setText($yearsPortion->getText()->replace("{{YearsOfService}}", $yearsOfService));

            // Spara den personliga presentationen till en separat fil.
            $employeePresentation->save(sprintf("%s Report.pptx", $employeeName), SaveFormat::Pptx);
        } finally {
            $employeePresentation->dispose();
        }
    }
} finally {
    $templatePresentation->dispose();
}
```

![Resultat](example1_image2.png)

### **Exempel på Excel‑tabell**

I det andra exemplet kopierar vi helt enkelt data från en Excel‑tabell och visar den på en PowerPoint‑bild i ett mer visuellt tilltalande format.

I detta exempel återanvänder vi samma Excel‑arbetsbok som i det första exemplet, som innehåller en enkel medarbetartabell.

```php
// Läs in Excel-arbetsboken som innehåller medarbetardatan.
$workbook = new ExcelDataWorkbook("TemplateData.xlsx");
$worksheetIndex = 0;

// Skapa en ny PowerPoint-presentation.
$presentation = new Presentation();

try {
    // Lägg till en tabellform på den första bilden.
    $table = $presentation->getSlides()->get_Item(0)->getShapes()->addTable(
            50, 200,
            array(200, 200, 200),
            array(30, 30, 30, 30, 30)
    );

    // Fyll PowerPoint-tabellen med data från Excel-arbetsboken.
    for ($rowIndex = 0; $rowIndex < 5; $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < 3; $columnIndex++) {
            $cellValue = $workbook->getCell($worksheetIndex, $rowIndex, $columnIndex)->getValue()->toString();
            $table->getColumns()->get_Item($columnIndex)->get_Item($rowIndex)->getTextFrame()->setText($cellValue);
        }
    }

    // Spara den resulterande presentationen till en fil.
    $presentation->save("Table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Resultat](example2_image0.png)

### **Exempel på import av Excel‑diagram**

I detta exempel importerar vi ett diagram från det första kalkylbladet i den Excel‑arbetsbok som användes i föregående exempel. Diagrammet kommer att länka till den externa arbetsboken i den resulterande presentationen.

Först lägger vi till ett pajdiagram i Excel‑arbetsboken baserat på medarbetartabellen.

![Exempel på Excel‑diagram](example3_image0.png)

```php
// Skapa en ny PowerPoint-presentation.
$presentation = new Presentation();
try {
    // Hämta samlingen av former på den första bilden.
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    // Importera diagrammet med namnet "Chart 1" från det första bladet i arbetsboken och lägg till det i formsamlingen.
    ExcelWorkbookImporter::addChartFromWorkbook($shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Spara den resulterande presentationen till en fil.
    $presentation->save("Chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Resultat](example3_image1.png)

### **Exempel på import av alla Excel‑diagram**

Låt oss föreställa oss att du har en Excel‑arbetsbok full av diagram och att du behöver importera dem alla till en presentation. Varje diagram bör placeras på en ny bild.

Följande kod itererar genom alla kalkylblad i käll‑Excel‑filen, extraherar diagrammen från varje kalkylblad och lägger till varje diagram på en separat bild med en tom bildlayout. I den resulterande presentationen kommer endast diagramdata att bäddas in, inte hela arbetsboken.

```php
// Läs in Excel-arbetsboken som innehåller medarbetardatan.
$workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Skapa en ny PowerPoint-presentation.
$presentation = new Presentation();
try {
    // Hämta den tomma bildlayouten.
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // Hämta namnen på alla kalkylblad som finns i Excel-arbetsboken.
    $worksheetNames = $workbook->getWorksheetNames()->iterator();

    while (java_values($worksheetNames->hasNext())) {
        $name = $worksheetNames->next();
        // Hämta en karta som mappar diagramindex till diagramnamn för kalkylbladet.
        $worksheetCharts = $workbook->getChartsFromWorksheet($name)->iterator();

        while (java_values($worksheetCharts->hasNext())) {
            $chart = $worksheetCharts->next();
            // Lägg till en ny bild med den tomma layouten.
            $slide = $presentation->getSlides()->addEmptySlide($blankLayout);

            // Importera det angivna diagrammet från Excel-arbetsboken till bildens formsamling.
            ExcelWorkbookImporter::addChartFromWorkbook(
                    $slide->getShapes(), 10, 10, $workbook, $name, $chart->getKey(), false);
        }
    }

    // Spara den resulterande presentationen till en fil.
    $presentation->save("Charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Sammanfattning**

Denna mekanism, som är tillgänglig direkt i Aspose.Slides, kombinerar arbete med Excel‑data och presentationer på ett ställe. Den låter dig skapa bilder med visuella diagram och data presenterade som Excel‑tabeller – utan några extra bibliotek eller komplexa integrationer.