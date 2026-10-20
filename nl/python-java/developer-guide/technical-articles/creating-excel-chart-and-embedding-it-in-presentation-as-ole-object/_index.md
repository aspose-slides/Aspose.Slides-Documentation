---
title: Maak Excel-grafieken en embed ze in presentaties als OLE-objecten
type: docs
weight: 30
url: /nl/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel-grafiek
- grafiek embedden
- OLE-object
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Maak een Excel-grafiek met Aspose.Cells for Python via Java en embed het werkboek in een PowerPoint-presentatie met Aspose.Slides, inclusief een grafiekpreview."
---
## **Overzicht**

Dit artikel laat zien hoe je een Excel-kolomgrafiek maakt met Aspose.Cells for Python via Java en het bijbehorende werkboek in een PowerPoint‑presentatie embed met Aspose.Slides for Python via Java. Het ingebedde werkboek bevat zowel de brongegevens als de grafiek. Een aparte PNG‑preview toont de grafiek op de dia voordat het OLE‑object wordt geactiveerd.

Het resultaat is een ingebed Excel‑object, geen native PowerPoint‑grafiek. Het bewerken van het werkboek via OLE vereist een desktop‑applicatie die OLE‑activatie ondersteunt en een compatibele Excel‑installatie.

## **Voorvereisten**

Installeer de Python‑pakketten `aspose-cells` en `aspose-slides-java` en een compatibele Java‑runtime. Importeer beide pakketten vóór het starten van de JVM zodat hun Java‑bibliotheken beschikbaar zijn voor JPype. Microsoft Office is niet vereist om de presentatie te genereren met deze bibliotheken.

Er zijn geen invoerbestanden nodig: het voorbeeld maakt de gegevens en de grafiek in het geheugen en schrijft vervolgens `OutputChart.pptx` naar de huidige werkmap. Pas licenties toe voor beide producten wanneer je buiten de evaluatiemodus werkt.

## **Hoe het insluiten werkt**

1. Maak een werkboek met een gegevenswerkblad en een grafiekblad.  
1. Maak het grafiekblad actief zodat het werkboek op de grafiek opent.  
1. Stel het OLE‑weergavebereik van het werkboek in en render de grafiek naar PNG.  
1. Sla het werkboek op als XLSX in het geheugen en embed die bytes in een dia.  
1. Wijs de PNG toe als preview van het OLE‑object en sla de presentatie op als PPTX.

Het weergavebereik van het werkboek en het frame op de dia hebben verschillende functies. [setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) gebruikt nul‑gebaseerde start/eind‑rij‑ en kolom‑indices. [ChartCollection.add](https://reference.aspose.com/cells/python-java/asposecells.api/chartcollection/#add) daarentegen neemt de bovenste rij, linkerkolom, onderste rij en rechterkolom. Het voorbeeld gebruikt rij‑index 55 en kolom‑index 25 als de rechter‑onder‑grenzen; deze waarden zijn lay‑out‑keuzes, niet het aantal gegevensrijen of -kolommen.

Het dia‑frame gebruikt punten. Het voorbeeld past het binnen de dia in en centreert het terwijl de beeldverhouding van de PNG behouden blijft, in plaats van de preview uit te rekken tot de dia te vullen.

## **Grafiek maken en embedden**

Het onderstaande complete voorbeeld vult `DataSheet` met vier rijen en vijf kolommen waarden. Elke rij wordt een grafiekserie. `ChartSheet` wordt geselecteerd als het actieve blad voordat het werkboek wordt opgeslagen.

Het werkboek wordt expliciet opgeslagen als XLSX, overeenkomstig de `xlsx`‑extensie die wordt doorgegeven aan [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/). Java‑byte‑array‑streams houden het werkboek en de afbeelding in het geheugen en leveren de byte‑arrays die de Java‑API’s nodig hebben. De PNG wordt direct vanuit de bytes geladen zonder een tussenliggende bitmap‑conversie. Toewijzing via [getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) vervangt de standaard OLE‑placeholder.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Images, OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("DataSheet")

    values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25],
    ]
    for row, row_values in enumerate(values):
        for column, value in enumerate(row_values):
            data_sheet.getCells().get(row, column).putValue(jpype.JInt(value))

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_sheet.setName("ChartSheet")

    last_chart_row = 55
    last_chart_column = 25
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
    chart = chart_sheet.getCharts().get(chart_index)
    for row in range(1, len(values) + 1):
        chart.getNSeries().add(f"DataSheet!A{row}:E{row}", False)

    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    workbook.getWorksheets().setOleSize(0, last_chart_row, 0, last_chart_column)

    # Render de grafiekpreview en serialiseer het bewerkbare werkboek afzonderlijk.
    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    chart_image_stream = ByteArrayOutputStream()
    chart.toImage(chart_image_stream, image_options)
    chart_image_bytes = chart_image_stream.toByteArray()

    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.XLSX)
    workbook_bytes = workbook_stream.toByteArray()

    chart_image = Images.fromData(chart_image_bytes)
    try:
        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)
            slide_width = presentation.getSlideSize().getSize().getWidth()
            slide_height = presentation.getSlideSize().getSize().getHeight()

            # Pas de preview aan binnen de dia zonder de beeldverhouding te wijzigen.
            scale = min(slide_width / chart_image.getWidth(), slide_height / chart_image.getHeight())
            frame_width = chart_image.getWidth() * scale
            frame_height = chart_image.getHeight() * scale
            frame_x = (slide_width - frame_width) / 2
            frame_y = (slide_height - frame_height) / 2

            embedded_data = OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.getImages().addImage(chart_image)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(preview_image)

            presentation.save("OutputChart.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        chart_image.dispose()
finally:
    workbook.dispose()
```

## **Verwacht resultaat**

`OutputChart.pptx` bevat één dia met een ingebed Excel‑werkboek en een grafiekpreview. Het werkboek bevat de oorspronkelijke gegevens en een kolomgrafiek met vier series. De preview is gecentreerd op de dia en behoudt de verhoudingen.

![Excel‑kolomgrafiek weergegeven als preview van een ingebed werkboek](excel-chart-ole-preview.png)

In een compatibele desktop‑PowerPoint‑omgeving met Excel beschikbaar, dubbelklik je op het object om het ingebedde werkboek te activeren en bewerken. Activatie en bewerken zijn afhankelijk van de OLE‑ondersteuning en beveiligingsinstellingen van de host‑applicatie.

## **Veelgestelde vragen**

**Waarom is een voorbeeldafbeelding nodig?**

Het ingebedde werkboek en de dia‑preview zijn afzonderlijke inhoud. Lever een grafiekafbeelding zodat de dia de grafiek toont in plaats van de standaard "EMBEDDED OLE OBJECT"-placeholder. Zie [Object Preview Issue when Adding OleObjectFrame](/slides/nl/python-java/object-preview-issue-when-adding-oleobjectframe/) .

**Wordt de preview automatisch bijgewerkt wanneer ik het werkboek in code wijzig?**

Beschouw de preview als een momentopname. Wanneer je werkboekgegevens programmatisch bijwerkt, genereer je de grafiekafbeelding opnieuw en vervang je zowel de preview als de ingebedde werkboekgegevens.

**Kan ik XLS in plaats van XLSX gebruiken?**

Ja. Sla het werkboek op in XLS‑formaat en gebruik `xls` als de extensie van de ingebedde data. De extensie moet overeenkomen met het daadwerkelijke werkboekformaat; alleen de extensie wijzigen zet de gegevens niet om.

**Waarom kan het object van grootte veranderen na activatie?**

De host‑applicatie kan de weergave van het OLE‑object aanpassen wanneer het werkboek wordt geactiveerd. Zowel het OLE‑weergavebereik van het werkboek als de afmetingen van het dia‑frame zijn hierbij relevant. Zie [Working Solution for Chart Resizing in PPTX](/slides/nl/python-java/working-solution-for-chart-resizing-in-pptx/) .

## **Gerelateerde secties**

- [Working Solution for Chart Resizing in PPTX](/slides/nl/python-java/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/nl/python-java/object-preview-issue-when-adding-oleobjectframe/)