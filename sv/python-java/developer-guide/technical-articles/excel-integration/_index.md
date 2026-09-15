---
title: Integrera Excel-data i PowerPoint-presentationer
linktitle: Excel-integration
type: docs
weight: 330
url: /sv/python-java/excel-integration/
keywords:
- Excel
- arbetsbok
- läsa Excel
- integrera Excel
- datakälla
- brevfletning
- importera tabell
- Excel till PowerPoint
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Läs data från Excel‑arbetsböcker i Aspose.Slides för Python via Java med hjälp av ExcelDataWorkbook‑API:t. Läs in blad och celler och använd värdena för att skapa datadrivna PowerPoint‑presentationer."
---
## **Introduktion**

PowerPoint‑presentationer är ett kraftfullt sätt att visa och kommunicera information. De används ofta tillsammans med Excel‑arbetsböcker, där Excel fungerar som en utmärkt källa för strukturerad data och PowerPoint briljerar i att visualisera den datan för en publik.

Det finns många praktiska scenarier där kombinationen av Excel och PowerPoint är nödvändig: brevfletningar, fylla i datatabeller, generera en bild per dataregister (batch‑generering av bilder), skapa träningsmaterial och samla flera Excel‑rapporter i en enda presentation, för att nämna några.

Tidigare krävde implementeringen av sådana funktioner med Aspose.Slides‑API:t att man förlitade sig på tredjepartslösningar som Aspose.Cells. Även om dessa verktyg är robusta kan de vara överdrivet komplexa och dyra för användare som bara behöver grundläggande data‑integrationsfunktionalitet.

## **Hur det fungerar**

För att göra arbetet med Excel‑data enklare och mer strömlinjeformat har Aspose.Slides introducerat nya klasser för att läsa data från Excel‑arbetsböcker och importera innehåll till en presentation. Denna funktion öppnar upp kraftfulla nya möjligheter för API‑användare som vill utnyttja Excel som datakälla i sina presentationsarbetsflöden.

Den nya funktionaliteten är avsedd för generellt data‑åtkomst och är inte integrerad i Presentation Document Object Model (DOM). Det betyder att *den tillåter inte redigering eller sparande av Excel‑filer* — dess enda syfte är att öppna arbetsböcker och navigera genom deras innehåll för att hämta cellvärden.

I centrum av denna funktion ligger den nya klassen [ExcelDataWorkbook](https://reference.aspose.com/slides/sv/python-java/aspose.slides/exceldataworkbook/). Klassen låter dig läsa in en Excel‑arbetsbok från en lokal fil eller en ström. När den är inläst erbjuder den flera överlagringar av metoden [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/sv/python-java/aspose.slides/exceldataworkbook/#getCell), som du kan använda för att hämta specifika celler efter deras position (t.ex. rad‑ och kolumnindex eller namngivna områden).

Varje anrop till [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/sv/python-java/aspose.slides/exceldataworkbook/#getCell) returnerar ett [ExcelDataCell](https://reference.aspose.com/slides/sv/python-java/aspose.slides/exceldatacell/)-objekt. Detta objekt representerar en enskild cell i Excel‑arbetsboken och ger dig åtkomst till dess värde på ett enkelt och intuitivt sätt.

#### **Importera ett Excel‑diagram**

Nästa steg för att utöka funktionaliteten är klassen [ExcelWorkbookImporter](https://reference.aspose.com/slides/sv/python-java/aspose.slides/excelworkbookimporter/). Denna verktygsklass tillhandahåller funktioner för att importera innehåll från en Excel‑arbetsbok till en presentation. Den innehåller flera överlagringar av metoden [ExcelWorkbookImporter.addChartFromWorkbook](https://reference.aspose.com/slides/sv/python-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook), som hjälper dig att hämta det valda diagrammet från den angivna Excel‑arbetsboken och lägga till det i slutet av den givna formsamlingen på de specificerade koordinaterna.

#### **Importera en Excel‑tabell**

Klassen [ExcelWorkbookImporter](https://reference.aspose.com/slides/sv/python-java/aspose.slides/excelworkbookimporter/) innehåller också flera överlagringar av metoden [ExcelWorkbookImporter.addTableFromWorkbook](https://reference.aspose.com/slides/sv/python-java/aspose.slides/excelworkbookimporter/#addTableFromWorkbook). Dessa metoder låter dig importera ett angivet cellområde från ett specificerat arbetsblad och lägga till det som en tabell i slutet av den givna formsamlingen på de specificerade koordinaterna.

Kort sagt är det ett lättviktigt och rakt på sak‑API för att läsa Excel‑data — exakt vad många utvecklare behöver utan overheaden av ett komplett kalkylblads‑bibliotek.

## **Låt oss koda**

### **Exempel på mail‑merge‑scenario**

I följande exempel implementerar vi ett enkelt mail‑merge‑scenario genom att generera flera presentationer baserat på data lagrad i en Excel‑arbetsbok.

För att komma igång behöver vi två saker:

1. En Excel‑arbetsbok som innehåller data

![Excel‑dataexempel](example1_image0.png)

2. En PowerPoint‑presentationsmall

![PowerPoint‑mallexempel](example1_image1.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# Läs in Excel‑arbetsboken med medarbetardata.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Läs in presentationsmallen.
template_presentation = Presentation("PresentationTemplate.pptx")

try:
    # Iterera genom Excel‑rader (exklusive rubrik på rad 0).
    for row_index in range(1, 5):

        # Skapa en presentation för varje medarbetarpost.
        employee_presentation = Presentation()

        try:
            # Ta bort den standardtomma bilden.
            employee_presentation.getSlides().removeAt(0)

            # Klona mallbilden till presentationen.
            slide = employee_presentation.getSlides().addClone(template_presentation.getSlides().get_Item(0))

            # Hämta stycken från målformen (antar att formindex 1 används).
            paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs()

            # Ersätt platshållarna med data från Excel.
            employee_name = str(workbook.getCell(worksheet_index, row_index, 0).getValue())
            name_portion = paragraphs.get_Item(0).getPortions().get_Item(0)
            name_portion.setText(str(name_portion.getText()).replace("{{EmployeeName}}", employee_name))

            department = str(workbook.getCell(worksheet_index, row_index, 1).getValue())
            department_portion = paragraphs.get_Item(1).getPortions().get_Item(0)
            department_portion.setText(str(department_portion.getText()).replace("{{Department}}", department))

            years_of_service = str(workbook.getCell(worksheet_index, row_index, 2).getValue())
            years_portion = paragraphs.get_Item(2).getPortions().get_Item(0)
            years_portion.setText(str(years_portion.getText()).replace("{{YearsOfService}}", years_of_service))

            # Spara den personliga presentationen till en separat fil.
            employee_presentation.save(f"{employee_name} Report.pptx", SaveFormat.Pptx)
        finally:
            employee_presentation.dispose()
finally:
    template_presentation.dispose()
```

![Resultat](example1_image2.png)

### **Exempel på Excel‑tabell**

I det andra exemplet kopierar vi helt enkelt data från en Excel‑tabell och visar den på en PowerPoint‑bild i ett mer visuellt tilltalande format.

I detta exempel återanvänder vi samma Excel‑arbetsbok som i det första exemplet, som innehåller en enkel medarbetartabell.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# Läs in Excel‑arbetsboken som innehåller medarbetardata.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Skapa en PowerPoint‑presentation.
presentation = Presentation()

try:
    # Lägg till en tabellform på den första bilden.
    column_widths = jpype.JArray(jpype.JDouble)([200, 200, 200])
    row_heights = jpype.JArray(jpype.JDouble)([30, 30, 30, 30, 30])
    table = presentation.getSlides().get_Item(0).getShapes().addTable(50, 200, column_widths, row_heights)

    # Fyll PowerPoint‑tabellen med data från Excel‑arbetsboken.
    for row_index in range(5):
        for column_index in range(3):
            cell_value = str(workbook.getCell(worksheet_index, row_index, column_index).getValue())
            table.getColumns().get_Item(column_index).get_Item(row_index).getTextFrame().setText(cell_value)

    # Spara den resulterande presentationen till en fil.
    presentation.save("Table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Resultat](example2_image0.png)

### **Exempel på att importera ett Excel‑diagram**

I detta exempel importerar vi ett diagram från det första arbetsbladet i den Excel‑arbetsbok som användes i föregående exempel. Diagrammet kommer att länkas till den externa arbetsboken i den resulterande presentationen.

Först lägger vi till ett cirkeldiagram i Excel‑arbetsboken baserat på medarbetartabellen.

![Excel‑diagramexempel](example3_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# Skapa en PowerPoint-presentation.
presentation = Presentation()
try:
    # Hämta shapes-samlingen för den första bilden.
    shapes = presentation.getSlides().get_Item(0).getShapes()

    # Importera diagrammet med namn "Chart 1" från det första bladet i arbetsboken och lägg till det i shapes-samlingen.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # Spara den resulterande presentationen till en fil.
    presentation.save("Chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Resultat](example3_image1.png)

### **Exempel på att importera alla Excel‑diagram**

Tänk dig att du har en Excel‑arbetsbok full av diagram och du behöver importera dem alla till en presentation. Varje diagram ska placeras på en ny bild.

Koden nedan itererar genom alla arbetsblad i käll‑Excel‑filen, extraherar diagrammen från varje arbetsblad och lägger till varje diagram på en separat bild med en tom bildlayout. I den resulterande presentationen kommer endast diagramdata att bäddas in, inte hela arbetsboken.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, ExcelWorkbookImporter, Presentation, SaveFormat, SlideLayoutType

# Läs in Excel‑arbetsboken som innehåller medarbetardata.
workbook = ExcelDataWorkbook("ExcelWithCharts.xlsx")

# Skapa en PowerPoint‑presentation.
presentation = Presentation()
try:
    # Hämta den tomma bildlayouten.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    # Ta bort standardbilden så att resultatet innehåller en bild per diagram.
    presentation.getSlides().removeAt(0)

    # Hämta namnen på alla arbetsblad som finns i Excel‑arbetsboken.
    worksheet_names = workbook.getWorksheetNames()

    for name in worksheet_names:
        # Hämta en karta som kartlägger diagramindex till diagramnamn för arbetsbladet.
        worksheet_charts = workbook.getChartsFromWorksheet(name)

        for chart in worksheet_charts:
            # Lägg till en bild med den tomma layouten.
            slide = presentation.getSlides().addEmptySlide(blank_layout)

            # Importera det angivna diagrammet från Excel‑arbetsboken till bildens shapes‑samling.
            ExcelWorkbookImporter.addChartFromWorkbook(slide.getShapes(), 10, 10, workbook, name, chart.getKey(), False)

    # Spara den resulterande presentationen till en fil.
    presentation.save("Charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Exempel på att importera en Excel‑tabell**

I detta exempel importerar vi en formaterad tabell från ett Excel‑arbetsblad direkt till en PowerPoint‑presentation.

Käll‑Excel‑arbetsbladet innehåller en formaterad tabell med medarbetardata:

![Excel‑tabellexempel](example4_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# Skapa en PowerPoint-presentation.
presentation = Presentation()
try:
    # Hämta den första bilden och dess shapes-samling.
    slide = presentation.getSlides().get_Item(0)
    shapes = slide.getShapes()

    # Importera tabellen från det första bladet i arbetsboken och lägg till den i shapes-samlingen.
    ExcelWorkbookImporter.addTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5")

    # Spara den resulterande presentationen till en fil.
    presentation.save("FormattedTable.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Resultat](example4_image1.png)

## **Sammanfattning**

Denna mekanism, som finns direkt i Aspose.Slides, kombinerar arbete med Excel‑data och presentationer på ett och samma ställe. Den gör det möjligt att skapa bilder med visuella diagram och data presenterade som Excel‑tabeller — utan några extra bibliotek eller komplexa integrationer.