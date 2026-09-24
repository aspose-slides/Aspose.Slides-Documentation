---
title: Anpassa diagramdatatabeller i presentationer i Python
linktitle: Datatabell
type: docs
url: /sv/python-net/chart-data-table/
keywords:
- diagramdata
- datatabell
- teckensnittsegenskaper
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Anpassa diagramdatatabellens teckensnitt, kanter och legendnycklar i PowerPoint-presentationer med Aspose.Slides för Python via .NET."
---
## **Översikt**

Aspose.Slides för Python via .NET låter dig visa ett diagrammets datatabell och anpassa dess textformatering, kanter och legendnycklar. Denna artikel förklarar hur du aktiverar tabellen, formaterar texten, kontrollerar varje typ av kant och visar eller döljer legendnycklar. Exemplen sparar de konfigurerade diagrammen i PPTX‑filer.

## **Ställ in teckensnittsegenskaper**

För att visa ett diagrammets datatabell, sätt [has_data_table](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chart/has_data_table/) till `True`. Använd [chart_data_table](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chart/chart_data_table/) för att komma åt tabellen och konfigurera dess textformatering.

1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Lägg till ett grupperat stapeldiagram på den första bilden.
1. Aktivera diagrammets datatabell.
1. Aktivera fet text med [font_bold](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseportionformat/font_bold/) och sätt [font_height](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseportionformat/font_height/) till `20` för 20‑punkts text.
1. Spara den modifierade presentationen.

Följande exempel kräver `test.pptx` i arbetskatalogen med minst en bild. Det lägger till ett diagram med standarddata på position (50, 50), med en bredd på 600 punkter och en höjd på 400 punkter. Den sparade `output.pptx` innehåller diagrammet med dess datatabell aktiverad och de angivna teckensnittsegenskaperna tillämpade.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    portion_format = chart.chart_data_table.text_format.portion_format
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Anpassa Datatabelskanter**

Aktivera tabellen med [Chart.has_data_table](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chart/has_data_table/) och nå den via [Chart.chart_data_table](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chart/chart_data_table/). Du kan kontrollera tre typer av kanter oberoende:

- [has_border_horizontal](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/datatable/has_border_horizontal/) styr horisontella cellkanter.
- [has_border_vertical](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/datatable/has_border_vertical/) styr vertikala cellkanter.
- [has_border_outline](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/datatable/has_border_outline/) styr tabellens yttre kant.

Sätt varje egenskap till `True` för att visa kanten eller `False` för att dölja den. Följande exempel skapar ett grupperat stapeldiagram med standarddata, visar horisontella kanter och den yttre kanten samt döljer vertikala kanter. Ingen indatafil krävs. Diagrammets position och storlek anges i punkter.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = False
    data_table.has_border_outline = True

    presentation.save("data-table-borders.pptx", slides.export.SaveFormat.PPTX)
```

Jämförelsen nedan använder samma diagramdata och legendnyckelinställning i alla fyra fallen. Med alla kanter aktiverade inaktiveras endast en kant i varje efterföljande variant. Den nedre vänstra varianten matchar kantinställningarna i exemplet.

![Diagramdatatabeller med alla kanter aktiverade, inga horisontella kanter, inga vertikala kanter och ingen ytterkant](data-table-borders.png)

## **Visa eller Dölj Legendnycklar**

Legendnycklar är små färgade markörer bredvid seriernas namn i datatabellen. De hjälper läsaren att matcha varje tabellrad med ett diagramserie. Sätt [show_legend_key](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/datatable/show_legend_key/) till `True` för att visa dessa markörer eller `False` för att dölja dem.

Diagrammets separata legend styrs av [Chart.has_legend](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chart/has_legend/). Dessa inställningar är oberoende: att dölja den separata legenden döljer inte nycklarna i datatabellen, och att dölja tabellens nycklar döljer inte den separata legenden.

Följande exempel skapar ett diagram med standarddata, aktiverar dess datatabell och visar legendnycklar i den samtidigt som den separata legenden döljs. Alla tabellkanter är uttryckligen aktiverade. Ingen indata‑presentation krävs. För att bara dölja tabellens nycklar, ändra `data_table.show_legend_key` till `False`.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True
    chart.has_legend = False

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = True
    data_table.has_border_outline = True
    data_table.show_legend_key = True

    presentation.save("data-table-legend-keys.pptx", slides.export.SaveFormat.PPTX)
```

Jämförelsen nedan visar samma tabell med legendnycklar aktiverade respektive inaktiverade. Alla kanter förblir aktiverade, och den separata diagramlegenden är dold i båda fallen.

![Diagramdatatabeller med legendnycklar visade till vänster och dolda till höger](data-table-legend-keys.png)

## **Vanliga frågor**

**Kan jag visa legendnycklar i ett diagrams datatabell?**

Ja. Sätt [show_legend_key](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/datatable/show_legend_key/) till `True` för att visa legendnycklar eller till `False` för att dölja dem.

**Behålls datatabellen vid export av presentationen till PDF, HTML eller bilder?**

Ja. Aspose.Slides renderar diagrammet och dess visade datatabell som en del av bilden när du exporterar till [PDF](/slides/sv/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/sv/python-net/convert-powerpoint-to-html/) eller [bilder](/slides/sv/python-net/convert-powerpoint-to-png/).

**Kan jag arbeta med datatabeller i diagram som laddats från en mall?**

Ja. För ett diagram som laddats från en befintlig presentation eller mall, använd [has_data_table](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chart/has_data_table/) för att kontrollera eller ändra om dess datatabell visas.

**Hur hittar jag diagram som har en aktiverad datatabell?**

Iterera genom formerna på varje bild, identifiera diagrammen och kontrollera deras [has_data_table](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chart/has_data_table/)‑egenskap. Värdet `True` indikerar att datatabellen är aktiverad.