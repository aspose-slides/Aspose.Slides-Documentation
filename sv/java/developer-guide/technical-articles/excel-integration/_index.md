---
title: Integrera Excel-data i PowerPoint-presentationer
linktitle: Excel-integration
type: docs
weight: 330
url: /sv/java/excel-integration/
keywords:
- Excel
- arbetsbok
- läsa Excel
- integrera Excel
- datakälla
- mail merge
- importera tabell
- Excel till PowerPoint
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Läs data från Excel-arbetsböcker i Aspose.Slides med hjälp av ExcelDataWorkbook API. Ladda blad och celler och använd värdena för att skapa datadrivna PowerPoint-presentationer."
---
## **Introduktion**

PowerPoint-presentationer är ett kraftfullt sätt att visa och kommunicera information. De används ofta i kombination med Excel-arbetsböcker, där Excel fungerar som en utmärkt källa till strukturerad data och PowerPoint briljerar i att visualisera den datan för en publik.

Det finns många praktiska scenarier där kombinationen av Excel och PowerPoint är avgörande: mail merge, fylla i datatabeller, generera en bild per datapost (batch-bildgenerering), skapa träningsmaterial och konsolidera flera Excel-rapporter till en enda presentation, för att nämna några.

Fram till nu krävde implementeringen av sådana funktioner med Aspose.Slides API att man förlitade sig på tredjepartslösningar som Aspose.Cells. Även om dessa verktyg är robusta kan de vara alltför komplexa och kostsamma för användare som bara behöver grundläggande dataintegrationsfunktionalitet.

## **Hur det fungerar**

För att göra arbetet med Excel-data enklare och mer strömlinjeformat har Aspose.Slides introducerat nya klasser för att läsa data från Excel-arbetsböcker och importera innehåll till en presentation. Denna funktion öppnar kraftfulla nya möjligheter för API-användare som vill utnyttja Excel som datakälla i sina presentationsarbetsflöden.

Den nya funktionaliteten är avsedd för allmän dataåtkomst och är inte integrerad i Presentation Document Object Model (DOM). Det betyder att *den inte tillåter redigering eller sparande av Excel-filer* — dess enda syfte är att öppna arbetsböcker och navigera genom deras innehåll för att hämta celldata.

I kärnan av denna funktion ligger den nya klassen [ExcelDataWorkbook](https://reference.aspose.com/slides/sv/java/com.aspose.slides/exceldataworkbook/). Denna klass låter dig läsa in en Excel-arbetsbok från en lokal fil eller en ström. När den är inläst tillhandahåller den flera överlagringar av metoden [getCell](https://reference.aspose.com/slides/sv/java/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) som du kan använda för att hämta specifika celler efter deras position (t.ex. rad- och kolumnindex eller namngivna områden).

Varje anrop till [getCell](https://reference.aspose.com/slides/sv/java/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) returnerar en instans av klassen [ExcelDataCell](https://reference.aspose.com/slides/sv/java/com.aspose.slides/exceldatacell/). Detta objekt representerar en enskild cell i Excel-arbetsboken och ger dig åtkomst till dess värde på ett enkelt och intuitivt sätt.

#### **Importera ett Excel-diagram**

Nästa steg för att utöka funktionaliteten är klassen [ExcelWorkbookImporter](https://reference.aspose.com/slides/sv/java/com.aspose.slides/excelworkbookimporter/). Denna verktygsklass tillhandahåller funktionalitet för att importera innehåll från en Excel-arbetsbok till en presentation. Den innehåller flera överlagringar av metoden [addChartFromWorkbook](https://reference.aspose.com/slides/sv/java/com.aspose.slides/excelworkbookimporter/#addChartFromWorkbook-com.aspose.slides.IShapeCollection-float-float-com.aspose.slides.IExcelDataWorkbook-java.lang.String-int-boolean-) som hjälper dig att hämta det valda diagrammet från den angivna Excel-arbetsboken och lägga till det i slutet av den angivna formsamlingen på de specificerade koordinaterna.

Kort sagt är det ett lättviktigt och okomplicerat API för att läsa Excel-data — exakt vad många utvecklare behöver utan den extra bördan av ett fullständigt kalkylbladsbearbetningsbibliotek.

## **Låt oss koda**

### **Exempel på mail merge-scenario**

I följande exempel kommer vi att implementera ett enkelt mail merge-scenario genom att generera flera presentationer baserade på data lagrad i en Excel-arbetsbok.

För att komma igång behöver vi två saker:
1. En Excel-arbetsbok som innehåller datan

![Excel-dataexempel](example1_image0.png)

2. PowerPoint-presentationmall

![PowerPoint-mallexempel](example1_image1.png)

```java
// Läs in Excel-arbetsboken med anställdas data.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Läs in presentationsmallen.
Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // Iterera genom Excel-rader (exkluderar rubrik på rad 0).
    for (int rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // Skapa en ny presentation för varje anställdpost.
        Presentation employeePresentation = new Presentation();

        try {
            // Ta bort den förvalda tomma bilden.
            employeePresentation.getSlides().removeAt(0);

            // Klona mallbilden till den nya presentationen.
            ISlide slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // Hämta stycken från målformen (antar att formindex 1 används).
            IParagraphCollection paragraphs = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame().getParagraphs();

            // Ersätt platshållarna med data från Excel.
            String employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            IPortion namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            String department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            IPortion departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            String yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            IPortion yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // Spara den personliga presentationen till en separat fil.
            employeePresentation.save(String.format("%s Report.pptx", employeeName), SaveFormat.Pptx);
        } finally {
            employeePresentation.dispose();
        }
    }
} finally {
    templatePresentation.dispose();
}
```

![Resultat](example1_image2.png)

### **Exempel på Excel-tabell**

I det andra exemplet kopierar vi helt enkelt data från en Excel-tabell och visar den på en PowerPoint-bild i ett mer visuellt tilltalande format.

I detta exempel återanvänder vi samma Excel-arbetsbok som i det första exemplet, som innehåller en enkel anställdtabell.

```java
// Läs in Excel-arbetsboken som innehåller anställdas data.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Skapa en ny PowerPoint-presentation.
Presentation presentation = new Presentation();

try {
    // Lägg till en tabellform på den första bilden.
    ITable table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            new double[]{200, 200, 200},
            new double[]{30, 30, 30, 30, 30}
    );

    // Fyll PowerPoint-tabellen med data från Excel-arbetsboken.
    for (int rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (int columnIndex = 0; columnIndex < 3; columnIndex++) {
            String cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // Spara den resulterande presentationen till en fil.
    presentation.save("Table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Resultat](example2_image0.png)

### **Exempel på import av Excel-diagram**

I detta exempel importerar vi ett diagram från det första kalkylbladet i den Excel-arbetsbok som användes i föregående exempel. Diagrammet kommer att länkas till den externa arbetsboken i den resulterande presentationen.

Först lägger vi till ett cirkeldiagram i Excel-arbetsboken baserat på anställdstabellen.

![Excel-diagramexempel](example3_image0.png)

```java
// Skapa en ny PowerPoint-presentation.
Presentation presentation = new Presentation();
try {
    // Hämta samlingen av former på den första bilden.
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    // Importera diagrammet med namn "Chart 1" från det första bladet i arbetsboken och lägg till det i samlingen av former.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Spara den resulterande presentationen till en fil.
    presentation.save("Chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Resultat](example3_image1.png)

### **Exempel på import av alla Excel-diagram**

Låt oss föreställa oss att du har en Excel-arbetsbok full av diagram och att du behöver importera dem alla till en presentation. Varje diagram ska placeras på en ny bild.

Följande kod itererar genom alla kalkylblad i käll-Excel-filen, extraherar diagrammen från varje kalkylblad och lägger varje diagram på en separat bild med hjälp av en tom bildlayout. I den resulterande presentationen kommer endast diagramdata att bäddas in, inte hela arbetsboken.

```java
// Läs in Excel-arbetsboken som innehåller anställdas data.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Skapa en ny PowerPoint-presentation.
Presentation presentation = new Presentation();
try {
    // Hämta den tomma bildlayouten.
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Hämta namnen på alla kalkylblad som finns i Excel-arbetsboken.
    List<String> worksheetNames = workbook.getWorksheetNames();

    for (String name : worksheetNames) {
        // Hämta en karta som mappar diagramindex till diagramnamn för kalkylbladet.
        Dictionary<Integer, String> worksheetCharts = workbook.getChartsFromWorksheet(name);

        for (KeyValuePair<Integer, String> chart : worksheetCharts) {
            // Lägg till en ny bild med den tomma layouten.
            ISlide slide = presentation.getSlides().addEmptySlide(blankLayout);

            // Importera det specificerade diagrammet från Excel-arbetsboken till bildens samling av former.
            ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // Spara den resulterande presentationen till en fil.
    presentation.save("Charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sammanfattning**

Denna mekanism, som finns direkt i Aspose.Slides, kombinerar arbete med Excel-data och presentationer på ett ställe. Den låter dig skapa bilder med visuella diagram och data presenterade som Excel-tabeller — utan några extra bibliotek eller komplexa integrationer.