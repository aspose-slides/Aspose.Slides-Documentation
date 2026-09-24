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
description: "Anpassa diagrammets datatabellteckensnitt, kanter och förklaringsnycklar i PowerPoint-presentationer med Aspose.Slides för Python via Java."
---
## **Översikt**

Aspose.Slides for Python via Java låter dig visa ett diagramms datatabell och anpassa dess textformatering, kanter och förklaringsnycklar. Denna artikel förklarar hur du aktiverar tabellen, formaterar dess text, styr varje typ av kant och visar eller döljer förklaringsnycklar. Exemplen sparar de konfigurerade diagrammen i PPTX-filer.

## **Ange teckensnittsegenskaper**

För att visa ett diagramms datatabell, skicka `True` till [setDataTable](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chart/#setDataTable). Använd [getChartDataTable](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chart/#getChartDataTable) för att komma åt tabellen och konfigurera dess textformatering.

1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Lägg till ett grupperat stapeldiagram på den första bilden.
1. Aktivera diagrammets datatabell.
1. Aktivera fet text med [setFontBold](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setFontBold) och skicka `20` till [setFontHeight](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setFontHeight) för 20‑punkts text.
1. Spara den modifierade presentationen.

Följande exempel kräver `test.pptx` i arbetskatalogen med minst en bild. Det lägger till ett diagram med standarddata på position (50, 50), med en bredd på 600 punkter och en höjd på 400 punkter. Den sparade `output.pptx` innehåller diagrammet med dess datatabell aktiverad och de angivna teckensnittinställningarna tillämpade.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation("test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Anpassa datatabellens kanter**

Aktivera tabellen med [Chart.setDataTable](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chart/#setDataTable) och få åtkomst till den via [Chart.getChartDataTable](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chart/#getChartDataTable). Du kan kontrollera tre typer av kanter oberoende:

- [setBorderHorizontal](https://reference.aspose.com/slides/sv/python-java/aspose.slides/datatable/#setBorderHorizontal) styr horisontella cellkanter.
- [setBorderVertical](https://reference.aspose.com/slides/sv/python-java/aspose.slides/datatable/#setBorderVertical) styr vertikala cellkanter.
- [setBorderOutline](https://reference.aspose.com/slides/sv/python-java/aspose.slides/datatable/#setBorderOutline) styr tabellens yttre kant.

Skicka `True` till varje metod för att visa dess kanter eller `False` för att dölja dem. Följande exempel skapar ett grupperat stapeldiagram med standarddata, visar horisontella kanter och den yttre kanten, och döljer vertikala kanter. Det kräver ingen indatafil. Diagrammets position och storlek anges i punkter.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(False)
    data_table.setBorderOutline(True)

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Jämförelsen nedan använder samma diagramdata och förklaringsnyckelinställning i alla fyra fallen. Med alla kanter aktiverade, inaktiverar varje återstående variant bara en kantinställning. Den nedre vänstra varianten matchar kantinställningarna i exemplet.

![Diagramdatatabeller med alla kanter aktiverade, inga horisontella kanter, inga vertikala kanter och ingen ytterkant](data-table-borders.png)

## **Visa eller dölja förklaringsnycklar**

Förklaringsnycklar är små färgade markörer bredvid serienamnen i datatabellen. De hjälper läsarna att matcha varje tabellrad med en diagramserie. Skicka `True` till [setShowLegendKey](https://reference.aspose.com/slides/sv/python-java/aspose.slides/datatable/#setShowLegendKey) för att visa dessa markörer eller `False` för att dölja dem.

Diagrammets separata förklaring styrs av [Chart.setLegend](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chart/#setLegend). Dessa inställningar är oberoende: att dölja den separata förklaringen döljer inte nycklarna i datatabellen, och att dölja tabellens nycklar döljer inte den separata förklaringen.

Följande exempel skapar ett diagram med standarddata, aktiverar dess datatabell och visar förklaringsnycklar i den samtidigt som den separata förklaringen döljs. Alla tabellkanter är uttryckligen aktiverade. Ingen inmatningspresentation krävs. För att enbart dölja tabellens nycklar, skicka `False` till [setShowLegendKey](https://reference.aspose.com/slides/sv/python-java/aspose.slides/datatable/#setShowLegendKey).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)
    chart.setLegend(False)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(True)
    data_table.setBorderOutline(True)
    data_table.setShowLegendKey(True)

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Jämförelsen nedan visar samma tabell med förklaringsnycklar aktiverade och inaktiverade. Alla kanter förblir aktiverade, och diagrammets separata förklaring är dold i båda fallen.

![Diagramdatatabeller med förklaringsnycklar visade till vänster och dolda till höger](data-table-legend-keys.png)

## **Vanliga frågor**

**Kan jag visa förklaringsnycklar i ett diagramms datatabell?**

Ja. Skicka `True` till [setShowLegendKey](https://reference.aspose.com/slides/sv/python-java/aspose.slides/datatable/#setShowLegendKey) för att visa förklaringsnycklar eller `False` för att dölja dem.

**Kommer datatabellen att bevaras vid export av presentationen till PDF, HTML eller bilder?**

Ja. Aspose.Slides renderar diagrammet och dess visade datatabell som en del av bilden vid export till [PDF](/slides/sv/python-java/convert-powerpoint-to-pdf/), [HTML](/slides/sv/python-java/convert-powerpoint-to-html/), eller [images](/slides/sv/python-java/convert-powerpoint-to-png/).

**Kan jag arbeta med datatabeller i diagram som laddas från en mall?**

Ja. För ett diagram som laddas från en befintlig presentation eller mall, använd [hasDataTable](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chart/#hasDataTable) och [setDataTable](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chart/#setDataTable) för att kontrollera eller ändra om dess datatabell visas.

**Hur kan jag hitta diagram som har en datatabell aktiverad?**

Iterera genom formerna på varje bild, identifiera diagrammen och anropa deras [hasDataTable](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chart/#hasDataTable) metod. Ett värde av `True` indikerar att datatabellen är aktiverad.