---
title: Anpassa diagramdatatabeller i presentationer med Python
linktitle: Datatabell
type: docs
url: /sv/python-java/chart-data-table/
keywords:
- diagramdata
- datatabell
- teckensnittsegenskaper
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Anpassa diagramdatatabeller i Python för PPT och PPTX med Aspose.Slides för Python via Java för att öka effektiviteten och attraktiviteten i presentationer."
---
## **Översikt**

Denna artikel förklarar hur man arbetar med diagramdatatabeller i Aspose.Slides. Den visar hur man visar en datatabell för ett diagram och anpassar dess textformatering genom att ange teckensnittsegenskaper såsom fet stil och teckenhöjd. Exemplet demonstrerar hur man skapar en presentation, lägger till ett diagram, aktiverar diagrammets datatabell, tillämpar teckensnittinställningar och sparar den uppdaterade presentationen.

Den innehåller även korta svar på vanliga frågor om att visa förklaringsnycklar i en diagramdatatabell, bevara datatabellen vid export, arbeta med diagram som laddas från befintliga presentationer eller mallar och identifiera diagram där datatabellen är aktiverad.

## **Ange teckensnittsegenskaper för en diagramdatatabell**

Aspose.Slides for Python via Java låter dig visa datatabellen för ett diagram och ändra teckensnittsegenskaperna för dess text.

1. Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Lägg till ett diagram på bilden.
1. Visa diagrammets datatabell.
1. Ange fet stil och teckenhöjd för datatabellens text.
1. Spara den ändrade presentationen.

Följande exempel demonstrerar dessa steg.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Skapa en tom presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Vanliga frågor**

**Kan jag visa små förklaringsnycklar bredvid värdena i diagrammets datatabell?**

Ja. Datatabellen stöder [förklaringsnycklar](https://reference.aspose.com/slides/sv/python-java/aspose.slides/datatable/#setShowLegendKey), och du kan slå på eller av dem.

**Kommer datatabellen att bevaras när presentationen exporteras till PDF, HTML eller bilder?**

Ja. Aspose.Slides återger diagrammet som en del av bilden, så den exporterade [PDF](/slides/sv/python-java/convert-powerpoint-to-pdf/)/[HTML](/slides/sv/python-java/convert-powerpoint-to-html/)/[image](/slides/sv/python-java/convert-powerpoint-to-png/) innehåller diagrammet med dess datatabell.

**Stöds datatabeller för diagram som kommer från en mallfil?**

Ja. För varje diagram som laddas från en befintlig presentation eller mall kan du kontrollera och ändra om en datatabell [is shown](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chart/#hasDataTable) med hjälp av diagrammets egenskaper.

**Hur kan jag snabbt hitta vilka diagram i en fil som har datatabellen aktiverad?**

Inspektera varje diagram­egenskap som indikerar om datatabellen [is shown](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chart/#hasDataTable) och iterera genom bilderna för att identifiera diagrammen där den är aktiverad.