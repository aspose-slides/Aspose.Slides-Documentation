---
title: Maak Excel-grafieken en embed ze in presentaties als OLE-objecten
type: docs
weight: 50
url: /nl/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel-grafiek
- grafiek insluiten
- OLE-object
- PowerPoint
- presentatie
- Python
- Python via .NET
- Aspose.Slides
description: "Maak een Excel-grafiek met Aspose.Cells for Python via .NET en embed het werkboek in een PowerPoint-presentatie met Aspose.Slides, inclusief een grafiekvoorbeeld."
---
## **Overzicht**

Dit artikel laat zien hoe je een Excel‑kolomgrafiek maakt met Aspose.Cells for Python via .NET en het bijbehorende werkboek in een PowerPoint‑presentatie embed met Aspose.Slides for Python via .NET. Het ingebedde werkboek bevat zowel de brongegevens als de grafiek. Een apart PNG‑voorbeeld toont de grafiek op de dia voordat het OLE‑object wordt geactiveerd.

Het resultaat is een ingebed Excel‑object, geen native PowerPoint‑grafiek. Het bewerken van het werkboek via OLE vereist een desktop‑applicatie die OLE‑activering ondersteunt en een compatibele Excel‑installatie.

## **Vereisten**

Installeer de pakketten `aspose-cells-python` en `aspose-slides` in je Python‑omgeving. Microsoft Office is niet vereist om de presentatie te genereren met deze bibliotheken.

Er zijn geen invoerbestanden nodig: het voorbeeld maakt de gegevens en de grafiek in het geheugen, en schrijft vervolgens `OutputChart.pptx` naar de huidige werkmap. Pas licenties toe voor beide producten wanneer je buiten de evaluatiemodus werkt.

## **Hoe de insluiting werkt**

1. Maak een werkboek met een gegevenswerkblad en een grafiekblad.  
2. Zet het grafiekblad actief zodat het werkboek opent op de grafiek.  
3. Stel het OLE‑weergavebereik van het werkboek in en rendereer de grafiek naar PNG.  
4. Sla het werkboek op als XLSX in het geheugen en embed die bytes in een dia.  
5. Wijs de PNG toe als voorbeeld van het OLE‑object en sla de presentatie op als PPTX.  

Het weergavebereik van het werkboek en het frame op de dia hebben verschillende functies. [set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) neemt nulgebaseerde start‑/eind‑rij‑ en kolomindexen. [ChartCollection.add](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chartcollection/add/) neemt daarentegen de bovenste rij, linkse kolom, onderste rij en rechte kolom. Het voorbeeld gebruikt rij‑index 55 en kolom‑index 25 als de rechter‑onder grenzen; deze waarden zijn lay‑outkeuzes, niet het aantal gegevensrijen of -kolommen.

Het dia‑frame werkt met punten. Het voorbeeld past het binnen de dia en centreert het terwijl de beeldverhouding van de PNG behouden blijft, in plaats van het voorbeeld uit te rekken om de dia te vullen.

## **Maak en embed de grafiek**

Het volgende volledige voorbeeld vult `DataSheet` met vier rijen en vijf kolommen met waarden. Elke rij wordt een grafiekserie. `ChartSheet` wordt gekozen als het actieve blad voordat het werkboek wordt opgeslagen.

Het werkboek wordt expliciet opgeslagen als XLSX, overeenkomstig de `xlsx`‑extensie die wordt doorgegeven aan [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/). De PNG wordt direct uit de stream geladen zonder een tussenliggende bitmap‑conversie. Door deze toe te wijzen via [substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/ioleobjectframe/substitute_picture_format/) wordt de standaard OLE‑plaatsvervanger vervangen.

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.cells.drawing as drawing
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "DataSheet"

values = [
    [67, 44, 46, 43, 24],
    [86, 64, 97, 29, 40],
    [68, 89, 78, 69, 38],
    [91, 48, 60, 26, 25],
]

for row, row_values in enumerate(values):
    for column, value in enumerate(row_values):
        data_sheet.cells.get(row, column).put_value(value)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_sheet.name = "ChartSheet"

last_chart_row = 55
last_chart_column = 25
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
chart = chart_sheet.charts[chart_index]
for row in range(1, len(values) + 1):
    chart.n_series.add(f"DataSheet!A{row}:E{row}", False)

workbook.worksheets.active_sheet_index = chart_sheet_index
workbook.worksheets.set_ole_size(0, last_chart_row, 0, last_chart_column)

# Render de grafiekpreview en serialiseer het bewerkbare werkboek afzonderlijk.
with io.BytesIO() as chart_image_stream, io.BytesIO() as workbook_stream:
    chart.to_image(chart_image_stream, drawing.ImageType.PNG)
    chart_image_stream.seek(0)
    workbook.save(workbook_stream, cells.SaveFormat.XLSX)
    workbook_bytes = workbook_stream.getvalue()

    with slides.Images.from_stream(chart_image_stream) as chart_image:
        with slides.Presentation() as presentation:
            slide = presentation.slides[0]
            slide_size = presentation.slide_size.size

            # Pas de preview aan binnen de dia zonder de beeldverhouding te wijzigen.
            scale = min(slide_size.width / chart_image.width, slide_size.height / chart_image.height)
            frame_width = chart_image.width * scale
            frame_height = chart_image.height * scale
            frame_x = (slide_size.width - frame_width) / 2
            frame_y = (slide_size.height - frame_height) / 2

            embedded_data = slides.dom.ole.OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.images.add_image(chart_image)
            ole_frame.substitute_picture_format.picture.image = preview_image

            presentation.save("OutputChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Verwacht resultaat**

`OutputChart.pptx` bevat één dia met een ingebed Excel‑werkboek en een grafiekvoorbeeld. Het werkboek bevat de originele gegevens en een kolomgrafiek met vier series. Het voorbeeld is gecentreerd op de dia en behoudt zijn verhoudingen.

![Excel kolomgrafiek weergegeven als voorbeeld van een ingebed werkboek](excel-chart-ole-preview.png)

In een compatibele desktop‑PowerPoint‑omgeving met Excel beschikbaar, dubbelklik op het object om het ingebedde werkboek te activeren en te bewerken. Activering en bewerken zijn afhankelijk van de OLE‑ondersteuning en beveiligingsinstellingen van de host‑applicatie.

## **FAQ**

**Waarom is een voorbeeldafbeelding nodig?**  
Het ingebedde werkboek en zijn dia‑voorbeeld zijn afzonderlijke inhoud. Lever een grafiekafbeelding zodat de dia de grafiek toont in plaats van de standaard “EMBEDDED OLE OBJECT”‑plaatsvervanger. Zie [Probleem met voorbeeld van object bij toevoegen van OleObjectFrame](/slides/nl/python-net/object-preview-issue-when-adding-oleobjectframe/).

**Werkt het voorbeeld automatisch bij wanneer ik het werkboek in code wijzig?**  
Beschouw het voorbeeld als een momentopname. Wanneer je de werkboekgegevens programmatically bijwerkt, maak je de grafiekafbeelding opnieuw en vervang je zowel het voorbeeld als de gegevens van het ingebedde werkboek.

**Kan ik XLS gebruiken in plaats van XLSX?**  
Ja. Sla het werkboek op in XLS‑formaat en gebruik `xls` als de extensie voor de ingeembedde data. De extensie moet overeenkomen met het daadwerkelijke werkboekformaat; alleen de extensie wijzigen converteert de gegevens niet.

**Waarom kan het object van grootte veranderen na activatie?**  
De host‑applicatie kan de weergave van het OLE‑object bijwerken wanneer het het werkboek activeert. Zowel het OLE‑weergavebereik van het werkboek als de afmetingen van het dia‑frame zijn van belang. Zie [OLE-objecten automatisch aanpassen in PowerPoint‑presentaties](/slides/nl/python-net/working-solution-for-worksheet-resizing/).

## **Gerelateerde secties**

- [OLE-objecten automatisch aanpassen in PowerPoint‑presentaties](/slides/nl/python-net/working-solution-for-worksheet-resizing/)
- [Probleem met voorbeeld van object bij toevoegen van OleObjectFrame](/slides/nl/python-net/object-preview-issue-when-adding-oleobjectframe/)
- [OLE-objecten beheren](/slides/nl/python-net/manage-ole/)