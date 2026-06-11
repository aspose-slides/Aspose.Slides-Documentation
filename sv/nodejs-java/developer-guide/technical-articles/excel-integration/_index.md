---
title: Integrera Excel-data i PowerPoint-presentationer
linktitle: Excel-integration
type: docs
weight: 330
url: /sv/nodejs-java/excel-integration/
keywords:
- Excel
- arbetsbok
- läsa Excel
- integrera Excel
- datakälla
- mailmerge
- importera tabell
- Excel till PowerPoint
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Läs data från Excel-arbetsböcker i JavaScript med Aspose.Slides. Ladda blad och celler och använd värden för att skapa datadrivna PowerPoint-presentationer."
---
## **Introduktion**

PowerPoint‑presentationer är ett kraftfullt sätt att visa och kommunicera information. De används ofta tillsammans med Excel‑arbetsböcker, där Excel är en utmärkt källa för strukturerad data och PowerPoint är bra på att visualisera den datan för en publik.

Det finns många praktiska scenarier där kombinationen av Excel och PowerPoint är avgörande: kopplade utskick, fylla i datatabeller, generera en bild per datapost (batch‑bildgenerering), skapa träningsmaterial och samla flera Excel‑rapporter i en enda presentation, för att nämna några.

Tidigare krävde implementering av sådana funktioner med Aspose.Slides‑API:t att man förlitade sig på tredjepartslösningar som Aspose.Cells. Även om dessa verktyg är robusta kan de vara onödigt komplexa och dyra för användare som bara behöver grundläggande data‑integrationsfunktionalitet.

## **Hur det fungerar**

För att göra arbetet med Exceldatat enklare och mer strömlinjeformat har Aspose.Slides introducerat nya klasser för att läsa data från Excel‑arbetsböcker och importera innehåll till en presentation. Denna funktion öppnar kraftfulla nya möjligheter för API‑användare som vill utnyttja Excel som datakälla i sina presentationsarbetsflöden.

Den nya funktionaliteten är avsedd för allmän dataåtkomst och är inte integrerad i presentations‑DOM‑modellen. Det betyder att *den tillåter inte redigering eller sparande av Excel‑filer* — dess enda syfte är att öppna arbetsböcker och navigera genom deras innehåll för att hämta cellvärden.

Kärnan i funktionen är den nya [ExcelDataWorkbook](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/exceldataworkbook/)‑klassen. Klassen låter dig läsa in en Excel‑arbetsbok från en lokal fil eller en ström. När den är laddad erbjuder den flera överlagringar av metoden [getCell](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/exceldataworkbook/#getCell), som du kan använda för att hämta specifika celler efter deras position (t.ex. rad‑ och kolumnindex eller namngivna områden).

Varje anrop till [getCell](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/exceldataworkbook/#getCell) returnerar en instans av klassen [ExcelDataCell](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/exceldatacell/). Detta objekt representerar en enskild cell i Excel‑arbetsboken och ger dig tillgång till dess värde på ett enkelt och intuitivt sätt.

#### **Importera ett Excel‑diagram**

Nästa steg för att utöka funktionaliteten är klassen [ExcelWorkbookImporter](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/excelworkbookimporter/). Denna verktygsklass erbjuder funktion för att importera innehåll från en Excel‑arbetsbok till en presentation. Den innehåller flera överlagringar av metoden [addChartFromWorkbook](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook), som hjälper dig att hämta det valda diagrammet från den angivna Excel‑arbetsboken och lägga till det i slutet av den angivna shapekollektionen på de specificerade koordinaterna.

Kort sagt är det ett lättviktigt och okomplicerat API för att läsa Excel‑data — exakt vad många utvecklare behöver utan belastningen av ett komplett kalkylblads‑bibliotek.

## **Låt oss koda**

### **Exempel på Mail Merge‑scenario**

I följande exempel implementerar vi ett enkelt Mail Merge‑scenario genom att generera flera presentationer baserat på data lagrad i en Excel‑arbetsbok.

För att komma igång behöver vi två saker:
1. En Excel‑arbetsbok som innehåller data

![Exempel på Excel‑data](example1_image0.png)

2. PowerPoint‑presentationsmall

![Exempel på PowerPoint‑mall](example1_image1.png)

```js
// Ladda Excel-arbetsboken med anställdas data.
let workbook = new aspose.slides.ExcelDataWorkbook("TemplateData.xlsx");
const worksheetIndex = 0;

// Ladda presentationsmallen.
let templatePresentation = new aspose.slides.Presentation("PresentationTemplate.pptx");

try {
    // Iterera genom Excel-raderna (exkluderar rubrik på rad 0).
    for (let rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // Skapa en ny presentation för varje anställds post.
        let employeePresentation = new aspose.slides.Presentation();

        try {
            // Ta bort den förvalda tomma bilden.
            employeePresentation.getSlides().removeAt(0);

            // Klona mallbilden till den nya presentationen.
            let slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // Hämta stycken från målformen (antar att formindex 1 används).
            let paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs();

            // Ersätt platshållarna med data från Excel.
            let employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            let namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            let department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            let departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            let yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            let yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // Spara den personliga presentationen till en separat fil.
            employeePresentation.save(`${employeeName} Report.pptx`, aspose.slides.SaveFormat.Pptx);
        } finally {
            employeePresentation.dispose();
        }
    }
} finally {
    templatePresentation.dispose();
}
```

![Resultat](example1_image2.png)

### **Exempel på Excel‑tabell**

I det andra exemplet kopierar vi helt enkelt data från en Excel‑tabell och visar den på en PowerPoint‑bild i ett mer visuellt tilltalande format.

I detta exempel återanvänder vi samma Excel‑arbetsbok som i det första exemplet, som innehåller en enkel medarbetartabell.

```js
// Ladda Excel-arbetsboken som innehåller anställdas data.
let workbook = new aspose.slides.ExcelDataWorkbook("TemplateData.xlsx");
const worksheetIndex = 0;

// Skapa en ny PowerPoint-presentation.
let presentation = new aspose.slides.Presentation();

try {
    // Lägg till en tabellform på den första bilden.
    let table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            java.newArray("double", [200, 200, 200]),
            java.newArray("double", [30, 30, 30, 30, 30])
    );

    // Fyll PowerPoint-tabellen med data från Excel-arbetsboken.
    for (let rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (let columnIndex = 0; columnIndex < 3; columnIndex++) {
            let cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // Spara den resulterande presentationen till en fil.
    presentation.save("Table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Resultat](example2_image0.png)

### **Exempel på att importera ett Excel‑diagram**

I detta exempel importerar vi ett diagram från det första kalkylbladet i den Excel‑arbetsbok som användes i föregående exempel. Diagrammet kommer att länkas till den externa arbetsboken i den färdiga presentationen.

Först lägger vi till ett cirkeldiagram i Excel‑arbetsboken baserat på medarbetartabellen.

![Exempel på Excel‑diagram](example3_image0.png)

```js
// Skapa en ny PowerPoint-presentation.
let presentation = new aspose.slides.Presentation();
try {
    // Hämta samlingen av former på den första bilden.
    let shapes = presentation.getSlides().get_Item(0).getShapes();

    // Importera diagrammet med namnet "Chart 1" från det första bladet i arbetsboken och lägg till det i formsamlingen.
    aspose.slides.ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Spara den resulterande presentationen till en fil.
    presentation.save("Chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Resultat](example3_image1.png)

### **Exempel på att importera alla Excel‑diagram**

Tänk dig att du har en Excel‑arbetsbok full av diagram och du behöver importera dem alla till en presentation. Varje diagram ska placeras på en ny bild.

Följande kod itererar igenom alla kalkylblad i käll‑Excel‑filen, extraherar diagrammen från varje blad och lägger till varje diagram på en separat bild med ett tomt bildlayout. I den resulterande presentationen kommer endast diagramdata att bäddas in, inte hela arbetsboken.

```js
// Ladda Excel-arbetsboken som innehåller anställdas data.
let workbook = new aspose.slides.ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Skapa en ny PowerPoint-presentation.
let presentation = new aspose.slides.Presentation();
try {
    // Hämta den tomma bildlayouten.
    let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

    // Hämta namnen på alla kalkylblad som finns i Excel-arbetsboken.
    let worksheetNames = workbook.getWorksheetNames().iterator();

    while (worksheetNames.hasNext()) {
        let name = worksheetNames.next();
        // Hämta en karta som mappar diagramindex till diagramnamn för kalkylbladet.
        let worksheetCharts = workbook.getChartsFromWorksheet(name).iterator();

        while (worksheetCharts.hasNext()) {
            let chart = worksheetCharts.next();
            // Lägg till en ny bild med den tomma layouten.
            let slide = presentation.getSlides().addEmptySlide(layoutSlide);

            // Importera det angivna diagrammet från Excel-arbetsboken till bildens formsamling.
            aspose.slides.ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // Spara den resulterande presentationen till en fil.
    presentation.save("Charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sammanfattning**

Denna mekanism, tillgänglig direkt i Aspose.Slides, kombinerar arbete med Excel‑data och presentationer på ett ställe. Den låter dig skapa bilder med visuella diagram och data presenterade som Excel‑tabeller — utan några extra bibliotek eller komplexa integrationer.