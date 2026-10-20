---
title: Werkende oplossing voor grafiekgrootte aanpassen in PPTX
type: docs
weight: 40
url: /nl/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- grafiekgrootte aanpassen
- Excel-grafiek
- OLE-object
- grafiek insluiten
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Los onverwachte wijziging van grafiekgrootte in PPTX op bij het gebruik van ingebedde Excel OLE-objecten met Aspose.Slides for Python via Java. Stel vaste grafiekafmetingen in om de grafiek- en OLE-framegroottes consistent te houden."
---
## **Achtergrond**

Excel‑grafieken die als OLE‑objecten in PowerPoint‑presentaties zijn ingebed met behulp van Aspose‑componenten, kunnen van grootte veranderen na hun eerste activering. Dit kan een merkbaar verschil veroorzaken in het uiterlijk van de grafiek vóór en na activering. Dit artikel legt uit waarom het formaat verandert en laat zien hoe dit te voorkomen door vaste grafiekafmetingen af te stemmen op het OLE‑frame.

In [Maak Excel‑grafieken en embed ze als OLE‑objecten in presentaties](/slides/nl/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), legden we uit hoe je een Excel‑grafiek maakt met Aspose.Cells for Python via Java en deze in een PowerPoint‑presentatie embed met Aspose.Slides for Python via Java. Om het [probleem met voorbeeldweergave van object](/slides/nl/python-java/object-preview-issue-when-adding-oleobjectframe/) aan te pakken, hebben we de grafiekafbeelding toegewezen aan het OLE‑objectframe van de grafiek. In de gegenereerde presentatie, wanneer je dubbelklikt op het OLE‑objectframe dat de grafiekafbeelding toont, wordt de Excel‑grafiek geactiveerd. Gebruikers kunnen de ingebedde Excel‑werkmap bewerken en daarna terugkeren naar de dia door buiten de geactiveerde werkmap te klikken. De grootte van het OLE‑objectframe verandert wanneer de gebruiker terugkeert naar de dia, en de schaalfactor varieert afhankelijk van de oorspronkelijke afmetingen van zowel het OLE‑objectframe als de ingebedde Excel‑werkmap.

## **Oorzaak van formaatverandering**

De ingebedde Excel‑werkmap heeft eigen venstergrootte, die Excel probeert te behouden wanneer het object voor het eerst wordt geactiveerd. Het OLE‑frame op de dia heeft onafhankelijk gedefinieerde afmetingen. Wanneer de Excel‑werkmap wordt geactiveerd, onderhandelen Excel en PowerPoint over de grootte van het object om de verhoudingen te behouden als onderdeel van het embedproces. Verschillen tussen het werkmapvenster en het OLE‑frame kunnen daarom zorgen dat het object van grootte verandert.

## **Werkende oplossing**

Stem de grafiekgrootte af op het OLE‑frame op de dia en houd de grafiekafmetingen onafhankelijk van het werkmapvenster. Deze oplossing werkt met een nieuwe presentatie of een bestaande sjabloon.

Het voorbeeld vereist Aspose.Cells for Python via Java en Aspose.Slides for Python via Java. Het maakt een eenvoudige kolomgrafiek op een actief grafiekblad en embed de werkmap in XLS‑formaat. Er wordt geen voorbeeldafbeelding van de grafiek toegewezen; de grafiek wordt zichtbaar wanneer het OLE‑object wordt geactiveerd in PowerPoint.

Het voorbeeld maakt een nieuwe presentatie met een 9,5 × 4‑inch OLE‑frame dat 0,5 inch van de linkerkant en 1 inch van de bovenkant is gepositioneerd. Diacoördinaten en afmetingen zijn in points (72 points per inch). Voor een bestaande presentatie, zie [Gebruik een sjabloon](#use-a-template).

## **Stel een vaste grafiekgrootte in**

Stel [setSizeWithWindow](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#sizewithwindow) in op false zodat de grafiekafmetingen onafhankelijk zijn van het werkmapvenster. Stel de afmetingen van [getChartObject](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#chartobject) in via [setWidth](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#width) en [setHeight](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#height), waarbij points worden omgezet naar pixels met 96 pixels per inch: een frame van 684 × 288 points komt overeen met een grafiek van 912 × 384 pixels. Stel [setPrintSize](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#printsize) in op de CUSTOM‑waarde van [PrintSizeType](https://reference.aspose.com/cells/python-java/asposecells.api/printsizetype/). Het voorbeeld embedde de werkmap met [addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) en slaat een presentatie op met een 9,5 × 4‑inch OLE‑frame.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import ChartType, FileFormatType, PrintSizeType, SheetType, Workbook
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("Data")
    data_sheet.getCells().get("A1").putValue(10)
    data_sheet.getCells().get("A2").putValue(20)

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add("Data!A1:A2", True)
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)

        # Dia‑coördinaten en afmetingen zijn in points (72 points per inch).
        width = 684.0  # 9,5 inch.
        height = 288.0  # 4 inch.

        chart.setSizeWithWindow(False)
        # Converteer points naar grafiekpixels met 96 pixels per inch.
        chart.getChartObject().setWidth(int(width / 72.0 * 96.0))
        chart.getChartObject().setHeight(int(height / 72.0 * 96.0))
        chart.setPrintSize(PrintSizeType.CUSTOM)

        workbook_stream = ByteArrayOutputStream()
        workbook.save(workbook_stream, FileFormatType.EXCEL_97_TO_2003)
        workbook_data = workbook_stream.toByteArray()
        data_info = OleEmbeddedDataInfo(workbook_data, "xls")
        slide.getShapes().addOleObjectFrame(36.0, 72.0, width, height, data_info)

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    workbook.dispose()
```

## **Gebruik een sjabloon**

De logica voor de afmetingen is hetzelfde voor een bestaande presentatie. Om het voorbeeld aan te passen:

1. Laad de sjabloonpresentatie in plaats van een lege presentatie te maken.
1. Controleer of de eerste dia minstens drie shapes bevat, en gebruik vervolgens de shape op index 2 als de placeholder.
1. Neem de framebreedte en -hoogte van die shape in plaats van de vaste waarden 684 en 288 te gebruiken. Houd de berekeningen voor de afmetingen ongewijzigd.
1. Voeg het OLE‑frame toe op de positie van de placeholder in plaats van de vaste coördinaten 36 en 72.
1. Verwijder de placeholder vóór het opslaan van de presentatie.

## **FAQ**

**Waarom verandert mijn ingebedde Excel‑grafiek van grootte na activering in PowerPoint?**

Dit gebeurt omdat Excel bij de eerste activering probeert de oorspronkelijke venstergrootte te herstellen, terwijl het OLE‑objectframe in PowerPoint zijn eigen afmetingen heeft. PowerPoint en Excel onderhandelen over de grootte om de beeldverhouding te behouden, wat kan leiden tot het aanpassen van de grootte.

**Hoe kan ik de grafiek‑ en OLE‑framegroottes consistent houden?**

Stel vaste grafiekafmetingen in die overeenkomen met het OLE‑frame en gebruik een aangepaste grafiekprintgrootte voordat je de werkmap embedt. Het bovenstaande voorbeeld toont de benodigde instellingen en eenhedenconversies.

**Is het afstemmen van de werkmapvenstergrootte voldoende?**

Alleen de werkmapvenstergrootte afstemmen voorkomt niet betrouwbaar dat het OLE‑frame van grootte verandert na activering. Gebruik vaste grafiekafmetingen zoals in het voorbeeld.

**Werkt deze oplossing zowel met sjabloongebaseerde presentaties als met nieuwe presentaties?**

Ja. Voor een sjabloon gebruik je de afmetingen en positie van de placeholder. Voor een nieuwe presentatie specificeer je de frame‑afmetingen en positie direct.

**Kan ik dit voorbeeld gebruiken met grafieken die in andere spreadsheet‑programma's zijn gemaakt?**

Het voorbeeld gebruikt een Excel‑werkmap gemaakt met Aspose.Cells. Het toont geen activatie‑gedrag voor andere spreadsheet‑programma's.

## **Gerelateerde secties**

- [Maak Excel‑grafieken en embed ze als OLE‑objecten in presentaties](/slides/nl/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)