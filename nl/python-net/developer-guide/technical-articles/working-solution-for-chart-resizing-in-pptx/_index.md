---
title: Werkende oplossing voor grafiekgrootte-aanpassing in PPTX
type: docs
weight: 60
url: /nl/python-net/working-solution-for-chart-resizing-in-pptx/
keywords:
  - grafiekgrootte-aanpassing
  - Excel-grafiek
  - OLE-object
  - grafiek insluiten
  - PowerPoint
  - presentatie
  - Python via .NET
  - Python
  - Aspose.Slides
description: "Los onverwachte grafiekgrootte-aanpassing in PPTX op wanneer ingebedde Excel OLE-objecten worden gebruikt met Aspose.Slides voor Python via .NET. Stel vaste grafiekafmetingen in om de grafiek- en OLE-framegroottes consistent te houden."
---
## **Overzicht**

Excel‑grafieken die als OLE‑objecten in PowerPoint‑presentaties zijn ingebed met Aspose‑componenten, kunnen van grootte veranderen na de eerste activering. Dit kan een merkbaar verschil veroorzaken in het uiterlijk van de grafiek vóór en na de activering. Dit artikel legt uit waarom het formaat verandert en laat zien hoe u dit kunt voorkomen door vaste grafiekafmetingen af te stemmen op het OLE‑frame.

In [Maak Excel‑grafieken en embed ze als OLE‑objecten in presentaties](/slides/nl/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), legden we uit hoe u een Excel‑grafiek maakt met Aspose.Cells for Python via .NET en deze in een PowerPoint‑presentatie embed met Aspose.Slides for Python via .NET. Om het [probleem met voorbeeldweergave van object](/slides/nl/python-net/object-preview-issue-when-adding-oleobjectframe/) aan te pakken, hebben we de grafiekafbeelding toegewezen aan het OLE‑objectframe van de grafiek. In de gegenereerde presentatie, wanneer u dubbelklikt op het OLE‑objectframe dat de grafiekafbeelding weergeeft, wordt de Excel‑grafiek geactiveerd. Gebruikers kunnen de ingebedde Excel‑werkmap bewerken en vervolgens terugkeren naar de dia door buiten de geactiveerde werkmap te klikken. De grootte van het OLE‑objectframe verandert wanneer de gebruiker terugkeert naar de dia, en de factor van de grootteverandering varieert afhankelijk van de oorspronkelijke afmetingen van zowel het OLE‑objectframe als de ingebedde Excel‑werkmap.

## **Oorzaak van de grootteverandering**

De ingebedde Excel‑werkmap heeft eigen vensterafmetingen, die Excel probeert te behouden wanneer het object voor het eerst wordt geactiveerd. Het OLE‑frame op de dia heeft onafhankelijk gedefinieerde afmetingen. Wanneer de Excel‑werkmap wordt geactiveerd, onderhandelen Excel en PowerPoint over de grootte van het object om de verhoudingen te behouden als onderdeel van het embedproces. Verschillen tussen het werkmapvenster en het OLE‑frame kunnen daardoor het object van formaat laten veranderen.

## **Werkende oplossing**

Stem de grafiekgrootte af op het OLE‑frame op de dia en houd de grafiekafmetingen onafhankelijk van het werkmapvenster. Deze oplossing werkt met een nieuwe presentatie of een bestaand sjabloon.

Het voorbeeld vereist Aspose.Cells for Python via .NET en Aspose.Slides for Python via .NET. Het maakt een eenvoudige kolomgrafiek op een actief grafiekblad en embed de werkmap in XLS‑indeling. Er wordt geen voorbeeldafbeelding voor de grafiek toegewezen; de grafiek wordt zichtbaar wanneer het OLE‑object wordt geactiveerd in PowerPoint.

Het voorbeeld maakt een nieuwe presentatie met een OLE‑frame van 9,5 × 4 inch, geplaatst 0,5 inch vanaf de linkerrand en 1 inch vanaf de bovenkant. Dia‑coördinaten en -afmetingen worden opgegeven in points (72 points per inch). Voor een bestaande presentatie, zie [Gebruik een sjabloon](#use-a-template).

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "Data"
data_sheet.cells.get("A1").put_value(10)
data_sheet.cells.get("A2").put_value(20)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, 20, 10)
chart = chart_sheet.charts[chart_index]
chart.n_series.add("Data!A1:A2", True)
workbook.worksheets.active_sheet_index = chart_sheet_index

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Dia‑coördinaten en -afmetingen zijn in points (72 points per inch).
    width = 684.0  # 9,5 inches.
    height = 288.0  # 4 inches.

    chart.size_with_window = False
    # Converteer points naar grafiekpixels met 96 pixels per inch.
    chart.chart_object.width = int(width / 72 * 96)
    chart.chart_object.height = int(height / 72 * 96)
    chart.print_size = cells.PrintSizeType.CUSTOM

    with io.BytesIO() as workbook_stream:
        workbook.save(workbook_stream, cells.SaveFormat.EXCEL_97_TO_2003)
        data_info = slides.dom.ole.OleEmbeddedDataInfo(workbook_stream.getvalue(), "xls")
        slide.shapes.add_ole_object_frame(36, 72, width, height, data_info)

    presentation.save("chart-fixed-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Stel een vaste grafiekgrootte in**

Stel [size_with_window](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/size_with_window/) in op false zodat de grafiekafmetingen onafhankelijk zijn van het werkmapvenster. Stel de afmetingen van [chart_object](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/chart_object/) in via [width](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/width/) en [height](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/height/), waarbij points worden omgerekend naar pixels met 96 pixels per inch: een frame van 684 × 288 points komt overeen met een grafiek van 912 × 384 pixels. Stel [print_size](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/print_size/) in op de CUSTOM‑waarde van [PrintSizeType](https://reference.aspose.com/cells/python-net/aspose.cells/printsizetype/). Het voorbeeld embedt de werkmap met [add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/add_ole_object_frame/) en slaat een presentatie op met een OLE‑frame van 9,5 × 4 inch.

## **Gebruik een sjabloon**

De logica voor het bepalen van de grootte is hetzelfde voor een bestaande presentatie. Om het voorbeeld aan te passen:

1. Laad de sjabloonpresentatie in plaats van een lege presentatie te maken.  
2. Controleer dat de eerste dia minstens drie vormen bevat, en gebruik vervolgens de vorm op index 2 als de tijdelijke aanduiding.  
3. Haal de framebreedte en -hoogte uit die vorm in plaats van de vaste waarden 684 en 288 te gebruiken. Houd de berekeningen voor de grootte ongewijzigd.  
4. Voeg het OLE‑frame toe op de positie van de tijdelijke aanduiding in plaats van de vaste coördinaten 36 en 72.  
5. Verwijder de tijdelijke aanduiding voordat u de presentatie opslaat.

## **Veelgestelde vragen**

**Waarom verandert mijn ingebedde Excel‑grafiek van grootte nadat deze in PowerPoint is geactiveerd?**

Dit gebeurt omdat Excel bij de eerste activering probeert het oorspronkelijke vensterformaat te herstellen, terwijl het OLE‑objectframe in PowerPoint zijn eigen afmetingen heeft. PowerPoint en Excel onderhandelen over de grootte om de beeldverhouding te behouden, wat kan leiden tot een grootteverandering.

**Hoe kan ik de grafiek‑ en OLE‑framegroottes consistent houden?**

Stel vaste grafiekafmetingen in die overeenkomen met het OLE‑frame en gebruik een aangepaste afdrukgrootte voor de grafiek voordat u de werkmap embedt. Het bovenstaande voorbeeld toont de benodigde instellingen en eenheidsconversies.

**Is het afstemmen van de grootte van het werkmapvenster voldoende?**

Alleen het afstemmen van de grootte van het werkmapvenster voorkomt niet betrouwbaar dat het OLE‑frame van grootte verandert na activering. Gebruik vaste grafiekafmetingen zoals in het voorbeeld.

**Werkt deze oplossing zowel met sjabloon‑gebaseerde presentaties als met nieuwe presentaties?**

Ja. Voor een sjabloon gebruikt u de afmetingen en positie van de tijdelijke aanduiding. Voor een nieuwe presentatie geeft u de frame‑afmetingen en positie direct op.

**Kan ik dit voorbeeld gebruiken met grafieken die in andere spreadsheet‑programma's zijn gemaakt?**

Het voorbeeld maakt gebruik van een Excel‑werkmap die is gemaakt met Aspose.Cells. Het laat het activatiegedrag voor andere spreadsheet‑programma's niet zien.

## **Gerelateerde secties**

- [Maak Excel‑grafieken en embed ze als OLE‑objecten in presentaties](/slides/nl/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Werk OLE‑objecten automatisch bij met een PowerPoint‑add‑in](/slides/nl/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)