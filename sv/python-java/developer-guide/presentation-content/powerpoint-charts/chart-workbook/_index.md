---
title: Hantera diagramarbetsböcker i presentationer med Python via Java
linktitle: Diagramarbok
type: docs
weight: 70
url: /sv/python-java/chart-workbook/
keywords:
- diagramarbok
- diagramdata
- arbetsbokscell
- datamärkning
- arbetsblad
- datakälla
- extern arbetsbok
- extern data
- diagramcache
- återställning av arbetsbok
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Upptäck Aspose.Slides för Python via Java: hantera enkelt diagramarbetsböcker i PowerPoint- och OpenDocument-format för att förenkla dina presentationsdata."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med diagramarbetsböcker i Aspose.Slides. Den visar hur man läser och skriver diagramdata via arbetsbokströmmar, använder arbetsboksceller som diagramdatamärkningar, får åtkomst till arbetsbladssamlingar och specificerar datakälltyp för diagramvärden. Den täcker också hur man arbetar med externa arbetsböcker som diagramdatakällor. Exemplen demonstrerar hur man skapar och tilldelar en extern arbetsbok, hämtar sökvägen till en extern arbetsbok som är länkat till ett diagram och redigerar diagramdata när arbetsboken är tillgänglig.

## **Läsa och skriva diagramdata från en arbetsbok**
Aspose.Slides tillhandahåller metoderna [readWorkbookStream](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdata/#readWorkbookStream) och [writeWorkbookStream](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdata/#writeWorkbookStream) som låter dig läsa och skriva diagramdataarbetsböcker (innehållande diagramdata redigerad med Aspose.Cells). **Obs** att diagramdata måste vara organiserade på samma sätt eller ha en struktur som liknar källan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    workbook_data = chart_data.readWorkbookStream()
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(workbook_data)
finally:
    presentation.dispose()
```

### **Validera diagramlayout efter arbetsboksändring**
När du ersätter en inbäddad arbetsbok med en modifierad, behåller diagrammet sina ursprungliga serie- och kategorisamlingar. Denna inkonsekvens kan få [Chart.validateChartLayout](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chart/#validateChartLayout) att kasta ett `ArgumentOutOfRangeException` (parameter: index). För att undvika undantaget, rensa befintliga serier och kategorier **innan** du skriver den uppdaterade arbetsboken tillbaka till diagrammet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

# Läs arbetsboken efter att den har modifierats (t.ex. med Aspose.Cells).
updated_workbook = Path("updatedWorkbook.xlsx").read_bytes()

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()

    # Rensa befintliga datareferenser.
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(jpype.JArray(jpype.JByte)(updated_workbook))
    chart.validateChartLayout()
finally:
    presentation.dispose()
```

Genom att rensa samlingarna säkerställer du att diagramdatastrukturen överensstämmer med den nya arbetsboken, så att [validateChartLayout](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chart/#validateChartLayout) kan slutföras utan fel.

## **Ange en arbetsbokscell som en diagramdatamärkning**
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) .
2. Hämta en slides referens via dess index.
3. Lägg till ett bubbeldiagram med lite data.
4. Få åtkomst till diagramserierna.
5. Ange arbetsbokscellen som en datamärkning.
6. Spara presentationen.

Denna Python‑kod visar hur du anger en arbetsbokscell som en diagramdatamärkning:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)
    series = chart.getChartData().getSeries()
    data_labels = series.get_Item(0).getLabels()
    data_labels.getDefaultDataLabelFormat().setShowLabelValueFromCell(True)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(3):
        label_cell = workbook.getCell(0, f"A{10 + i}", label_values[i])
        data_labels.get_Item(i).setValueFromCell(label_cell)
    presentation.save("resultchart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hantera arbetsblad**
Denna Python‑kod demonstrerar en operation där metoden [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdataworkbook/#getWorksheets) används för att få åtkomst till en arbetsbladssamling:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **Specificera datakälltyp**
Denna Python‑kod visar hur du specificerar en typ för en datakälla:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    series_name = chart.getChartData().getSeries().get_Item(0).getName()
    series_name.setDataSourceType(DataSourceType.StringLiterals)
    series_name.setData("LiteralString")
    series_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell")
    series_name.setData(name_cell)
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Detektera osupporterade inbäddade arbetsboksformat**
Aspose.Slides stöder inte Excel‑binärarbetsboken (.xlsb) som kan vara inbäddad i vissa diagram. Du kan använda metoden [getEmbeddedWorkbookType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) på [ChartData](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdata/) tillsammans med uppräkningen [WorkbookType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/workbooktype/) för att upptäcka osupporterade format och hoppa över de diagrammen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, WorkbookType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue
        chart_data = shape.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook and chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro:
            # Inbäddad arbetsbok är i .xlsb-format, vilket inte stöds.
            continue
        # Read or modify the chart workbook data here.
finally:
    presentation.dispose()
```

### **Skapa en extern arbetsbok**
Genom att använda metoderna [readWorkbookStream](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdata/#readWorkbookStream) och [setExternalWorkbook](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdata/#setExternalWorkbook) kan du antingen skapa en extern arbetsbok från grunden eller göra en intern arbetsbok extern.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    workbook_path = "externalWorkbook1.xlsx"
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(workbook_path)
    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ange en extern arbetsbok**
Genom att använda metoden [setExternalWorkbook](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdata/#setExternalWorkbook) kan du tilldela en extern arbetsbok till ett diagram som dess datakälla. Metoden kan också användas för att uppdatera sökvägen till den externa arbetsboken (om den senare har flyttats). Även om du inte kan redigera data i arbetsböcker som lagras på fjärrplatser eller resurser, kan du fortfarande använda sådana arbetsböcker som en extern datakälla. Om en relativ sökväg för en extern arbetsbok anges, konverteras den automatiskt till en fullständig sökväg.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, False)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("externalWorkbook.xlsx")
    workbook = chart_data.getChartDataWorkbook()
    series_name_cell = workbook.getCell(0, "B1")
    series = chart_data.getSeries().add(series_name_cell, ChartType.Pie)
    for row in range(2, 5):
        value_cell = workbook.getCell(0, f"B{row}")
        series.getDataPoints().addDataPointForPieSeries(value_cell)
    for row in range(2, 5):
        category_cell = workbook.getCell(0, f"A{row}")
        chart_data.getCategories().add(category_cell)
    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Den andra (`bool`) parametern för metoden [setExternalWorkbook](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdata/#setExternalWorkbook) används för att ange om en Excel‑arbetskbook ska läsas in eller inte. 
* När dess värde är `False` uppdateras endast arbetsbokens sökväg – diagramdata kommer inte att läsas in eller uppdateras från målarbetsboken. Du kan vilja använda denna inställning när målarbetsboken saknas eller är otillgänglig. 
* När dess värde är `True` uppdateras diagramdata från målarbetsboken.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("http://path/doesnt/exists", False)
    presentation.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Hämta den externa datakällans arbetsbokssökväg för ett diagram**
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) .
2. Hämta en slides referens via dess index.
3. Skapa ett objekt för diagramformen.
4. Skapa ett objekt för källtypen ([ChartDataSourceType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdatasourcetype/)) som representerar diagrammets datakälla.
5. Specificera det relevanta villkoret baserat på att källtypen är densamma som den externa arbetsbokens datakälltyp.

Denna Python‑kod demonstrerar operationen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(1)
    chart = slide.getShapes().get_Item(0)
    source_type = chart.getChartData().getDataSourceType()
    if source_type == ChartDataSourceType.ExternalWorkbook:
        path = chart.getChartData().getExternalWorkbookPath()
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Redigera diagramdata**
Du kan redigera data i externa arbetsböcker på samma sätt som du gör ändringar i innehållet i interna arbetsböcker. När en extern arbetsbok inte kan läsas in kastas ett undantag.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    chart_data.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(jpype.JInt(100))
    presentation.save("presentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Återskapa en arbetsbok från diagramcachen**
Om ett diagram använder en extern arbetsbok som saknas eller är otillgänglig, kan Aspose.Slides rekonstruera diagramarbetsboken från data som cachats i presentationen. Skapa [LoadOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/), konfigurera den med [SpreadsheetOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/spreadsheetoptions/), och anropa [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/sv/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) med `True` innan presentationen öppnas.

Följande Python‑exempel öppnar en presentation vars diagram refererar till en otillgänglig extern arbetsbok och får åtkomst till den återställda datan via [Chart.getChartData](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chart/#getChartData) och [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)
load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    recovered_workbook = chart.getChartData().getChartDataWorkbook()

    # Läs eller ändra de återställda arbetsboksdata här.
finally:
    presentation.dispose()
```

Om den externa arbetsboken är otillgänglig och återställning är inaktiverad, kastar Aspose.Slides ett undantag. Aktivera återställning endast när användning av cachad diagramdata är ett acceptabelt alternativ, eftersom cachen kanske inte innehåller ändringar som gjorts i den externa arbetsboken efter att presentationen senast uppdaterades.

## **FAQ**

**Kan jag avgöra om ett specifikt diagram är länkat till en extern eller en inbäddad arbetsbok?**

Ja. Ett diagram har en [data source type](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdata/#getDataSourceType) och en [path to an external workbook](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); om källan är en extern arbetsbok kan du läsa den fullständiga sökvägen för att säkerställa att en extern fil används.

**Stöds relativa sökvägar till externa arbetsböcker, och hur lagras de?**

Ja. Om du anger en relativ sökväg konverteras den automatiskt till en absolut sökväg. Detta är praktiskt för projektsportabilitet; dock bör du vara medveten om att presentationen lagrar den absoluta sökvägen i PPTX‑filen.

**Kan jag använda arbetsböcker som finns på nätverksresurser/delningar?**

Ja, sådana arbetsböcker kan användas som en extern datakälla. Redigering av fjärrarbetsböcker direkt från Aspose.Slides stöds dock inte – de kan endast användas som källa.

**Skriver Aspose.Slides över den externa XLSX‑filen när presentationen sparas?**

Nej. Presentationen lagrar en [link to the external file](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) och använder den för att läsa data. Den externa filen ändras inte när presentationen sparas.

**Vad ska jag göra om den externa filen är lösenordsskyddad?**

Aspose.Slides accepterar inte ett lösenord vid länking. En vanlig metod är att ta bort skyddet i förväg eller förbereda en dekrypterad kopia (t.ex. med [Aspose.Cells](/cells/python-java/)) och länka till den kopian.

**Kan flera diagram referera till samma externa arbetsbok?**

Ja. Varje diagram lagrar sin egen länk. Om de alla pekar på samma fil kommer en uppdatering av den filen att återspeglas i varje diagram nästa gång data läses in.