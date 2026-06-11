---
title: Integrera Excel-data i PowerPoint-presentationer
linktitle: Excel-integration
type: docs
weight: 330
url: /sv/python-net/excel-integration/
keywords:
- Excel
- arbetsbok
- Läs Excel
- integrera Excel
- datakälla
- kopplad utskick
- importera tabell
- Excel till PowerPoint
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Läs data från Excel-arbetsböcker i Aspose.Slides med ExcelDataWorkbook API. Läs in blad och celler och använd värdena för att generera datadrivna PowerPoint-presentationer."
---
## **Introduktion**

PowerPoint-presentationer är ett kraftfullt sätt att visa och kommunicera information. De används ofta i samband med Excel-arbetsböcker, där Excel fungerar som en utmärkt källa till strukturerad data och PowerPoint är utmärkt på att visualisera den datan för en publik.

Det finns många praktiska scenarier där kombinationen av Excel och PowerPoint är avgörande: kopplad utskick, ifyllning av datatabeller, generering av en bild per datapost (batch-bildgenerering), skapande av träningsmaterial och konsolidering av flera Excel-rapporter till en enda presentation, för att nämna några.

Hittills har implementeringen av sådana funktioner med Aspose.Slides API krävt att man förlitar sig på tredjepartslösningar som Aspose.Cells. Även om dessa verktyg är robusta kan de vara alltför komplexa och kostsamma för användare som bara behöver grundläggande funktionalitet för dataintegration.

## **Hur det fungerar**

För att göra arbetet med Excel-data enklare och mer strömlinjeformat har Aspose.Slides introducerat nya klasser för att läsa data från Excel-arbetsböcker och importera innehåll till en presentation. Denna funktion öppnar upp kraftfulla nya möjligheter för API-användare som vill utnyttja Excel som datakälla i sina presentationsarbetsflöden.

Den nya funktionaliteten är utformad för allmän datatillgång och är inte integrerad i Presentation Document Object Model (DOM). Det betyder att *den inte tillåter redigering eller sparande av Excel-filer* — dess enda syfte är att öppna arbetsböcker och navigera genom deras innehåll för att hämta celldata.

I kärnan av denna funktion finns den nya klassen [ExcelDataWorkbook](https://reference.aspose.com/slides/sv/python-net/aspose.slides.excel/exceldataworkbook/). Denna klass låter dig läsa in en Excel-arbetsbok från en lokal fil eller en ström. När den är inläst erbjuder den flera överlagringar av metoden [get_cell](https://reference.aspose.com/slides/sv/python-net/aspose.slides.excel/exceldataworkbook/get_cell/), som du kan använda för att hämta specifika celler efter deras position (t.ex. rad- och kolumnindex eller namngivna områden).

Varje anrop till [get_cell](https://reference.aspose.com/slides/sv/python-net/aspose.slides.excel/exceldataworkbook/get_cell/) returnerar en instans av klassen [ExcelDataCell](https://reference.aspose.com/slides/sv/python-net/aspose.slides.excel/exceldatacell/). Detta objekt representerar en enda cell i Excel-arbetsboken och ger dig åtkomst till dess värde på ett enkelt och intuitivt sätt.

#### **Importera ett Excel-diagram**

Nästa steg för att utöka funktionaliteten är klassen [ExcelWorkbookImporter](https://reference.aspose.com/slides/sv/python-net/aspose.slides.importing/excelworkbookimporter/). Denna verktygsklass tillhandahåller funktionalitet för att importera innehåll från en Excel-arbetsbok till en presentation. Den innehåller flera överlagringar av metoden [add_chart_from_workbook](https://reference.aspose.com/slides/sv/python-net/aspose.slides.importing/excelworkbookimporter/add_chart_from_workbook/), som hjälper dig att hämta det valda diagrammet från den angivna Excel-arbetsboken och lägga till det i slutet av den angivna formsamlingen på de specificerade koordinaterna.

Kort sagt är det ett lättviktigt och enkelt API för att läsa Excel-data — exakt vad många utvecklare behöver utan belastningen av ett komplett kalkylbladsbearbetningsbibliotek.

## **Låt oss koda**

### **Exempel på Mail Merge-scenario**

I följande exempel ska vi implementera ett enkelt Mail Merge-scenario genom att generera flera presentationer baserade på data lagrade i en Excel-arbetsbok.

För att komma igång behöver vi två saker:
1. En Excel-arbetsbok som innehåller data

![Excel data example](example1_image0.png)

2. PowerPoint-presentationmall

![PowerPoint template example](example1_image1.png)

```py
import aspose.slides as slides

# Ladda Excel-arbetsboken med anställdas data.
workbook = slides.excel.ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Ladda presentationsmallen.
with slides.Presentation("PresentationTemplate.pptx") as template_presentation:

    # Loopa igenom Excel-rader (exklusive rubrik på rad 0).
    for row_index in range(1, 5):

        # Skapa en ny presentation för varje anställds post.
        with slides.Presentation() as employee_presentation:

            # Ta bort den förinställda tomma bilden.
            employee_presentation.slides.remove_at(0)

            # Klona mallbilden till den nya presentationen.
            slide = employee_presentation.slides.add_clone(template_presentation.slides[0])

            # Hämta stycken från målformen (förutsätter att formindex 1 används).
            paragraphs = slide.shapes[1].text_frame.paragraphs

            # Ersätt platshållarna med data från Excel.
            employee_name = workbook.get_cell(worksheet_index, row_index, 0).value
            name_portion = paragraphs[0].portions[0]
            name_portion.text = name_portion.text.replace("{{EmployeeName}}", employee_name)

            department = workbook.get_cell(worksheet_index, row_index, 1).value
            department_portion = paragraphs[1].portions[0]
            department_portion.text = department_portion.text.replace("{{Department}}", department)

            years_of_service = str(workbook.get_cell(worksheet_index, row_index, 2).value)
            years_portion = paragraphs[2].portions[0]
            years_portion.text = years_portion.text.replace("{{YearsOfService}}", years_of_service)

            # Spara den personliga presentationen till en separat fil.
            employee_presentation.save(f"{employee_name} Report.pptx", slides.export.SaveFormat.PPTX)
```

![Resultat](example1_image2.png)

### **Exempel på Excel-tabell**

I det andra exemplet kopierar vi helt enkelt data från en Excel-tabell och visar den på en PowerPoint-bild i ett mer visuellt tilltalande format.

I detta exempel återanvänder vi samma Excel-arbetsbok som i det första exemplet, som innehåller en enkel anställdtabell.

```py
# Ladda Excel-arbetsboken som innehåller anställdas data.
workbook = slides.excel.ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Skapa en ny PowerPoint-presentation.
with slides.Presentation() as presentation:

    # Lägg till en tabellform på den första bilden.
    table = presentation.slides[0].shapes.add_table(
        50, 200,
        [200, 200, 200],
        [30, 30, 30, 30, 30]
    )

    # Fyll PowerPoint-tabellen med data från Excel-arbetsboken.
    for row_index in range(0, 5):
        for column_index in range(0, 3):
            cell_value = str(workbook.get_cell(worksheet_index, row_index, column_index).value)
            table.columns[column_index][row_index].text_frame.text = cell_value

    # Spara den resulterande presentationen till en fil.
    presentation.save("Table.pptx", slides.export.SaveFormat.PPTX)
```

![Resultat](example2_image0.png)

### **Exempel på att importera ett Excel-diagram**

I detta exempel importerar vi ett diagram från det första kalkylbladet i den Excel-arbetsbok som användes i föregående exempel. Diagrammet kommer att länka till den externa arbetsboken i den resulterande presentationen.

Först lägger vi till ett cirkeldiagram i Excel-arbetsboken baserat på anställdtabellen.

![Excel Chart example](example3_image0.png)

```py
# Skapa en ny PowerPoint-presentation.
with slides.Presentation() as presentation:
    # Hämta formsamlingen för den första bilden.
    shapes = presentation.slides[0].shapes

    # Importera diagrammet med namnet "Chart 1" från det första bladet i arbetsboken och lägg till det i formsamlingen.
    slides.importing.ExcelWorkbookImporter.add_chart_from_workbook(
        shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # Spara den resulterande presentationen till en fil.
    presentation.save("Chart.pptx", slides.export.SaveFormat.PPTX)
```

![Resultat](example3_image1.png)

### **Exempel på att importera alla Excel-diagram**

Föreställ dig att du har en Excel-arbetsbok full av diagram och att du måste importera dem alla till en presentation. Varje diagram ska placeras på en ny bild.

Följande kod itererar genom alla kalkylblad i käll-Excel-filen, extraherar diagrammen från varje kalkylblad och lägger till varje diagram på en separat bild med hjälp av en tom bildlayout. I den resulterande presentationen kommer endast diagramdata att bäddas in, inte hela arbetsboken.

```py
# Ladda Excel-arbetsboken som innehåller anställdadata.
workbook = slides.excel.ExcelDataWorkbook("ExcelWithCharts.xlsx")

# Skapa en ny PowerPoint-presentation.
with slides.Presentation() as presentation:
    # Hämta den tomma bildlayouten.
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # Hämta namnen på alla arbetsblad i Excel-arbetsboken.
    worksheet_names = workbook.get_worksheet_names()

    for name in worksheet_names:
        # Hämta en dictionary som mappar diagramindex till diagramnamn för arbetsbladet.
        worksheet_charts = workbook.get_charts_from_worksheet(name)
        
        for chart in worksheet_charts:
            # Lägg till en ny bild med den tomma layouten.
            slide = presentation.slides.add_empty_slide(blank_layout)

            # Importera det angivna diagrammet från Excel-arbetsboken till bildens formsamling.
            slides.importing.ExcelWorkbookImporter.add_chart_from_workbook(
                slide.shapes, 10, 10, workbook, name, chart.key, False)

    # Spara den resulterande presentationen till en fil.
    presentation.save("Charts.pptx", slides.export.SaveFormat.PPTX)
```

## **Sammanfattning**

Denna mekanism, tillgänglig direkt i Aspose.Slides, kombinerar arbete med Excel-data och presentationer på ett ställe. Den låter dig skapa bilder med visuella diagram och data presenterade som Excel-tabeller – utan några extra bibliotek eller komplexa integrationer.