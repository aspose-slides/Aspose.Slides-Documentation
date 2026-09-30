---
title: Anpassa diagramlegender i presentationer med Python
linktitle: Diagramlegend
type: docs
url: /sv/python-net/chart-legend/
keywords:
- diagramlegend
- legendplacering
- teckenstorlek
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Anpassa diagramlegender med Aspose.Slides for Python via .NET för att optimera PowerPoint-presentationer med skräddarsydd legendformatering."
---
## **Översikt**

Aspose.Slides for Python via .NET erbjuder alternativ för att anpassa diagramlegender i PowerPoint-presentationer. Den här artikeln visar hur man positionerar och storlekar en legend, ställer in teckenstorleken för hela legenden, formaterar ett enskilt legendelement och döljer eller återställer valda element.

FAQ:n täcker relaterade beteenden, inklusive att reservera utrymme för legenden, visa flerradiga etiketter och ärva formatering från presentationstemat.

## **Placering av legend**

Använd legendens [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/x/), [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/y/), [bredd](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/width/), och [höjd](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/height/) egenskaper för att ange dess position och storlek som bråkdelar av diagrammets dimensioner.

Det här exemplet skapar en presentation och lägger till ett grupperat stapeldiagram med standarddata på den första bilden. Genom att dividera de önskade legendförskjutningarna och dimensionerna med diagrammets bredd och höjd omvandlas de till relativa värden: legenden förskjuts 50 punkter från diagrammets övre vänstra hörn och får storleken 100 gånger 100 punkter.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 500)

    # Uttryck legendens position och storlek relativt till diagrammet.
    chart.legend.x = 50 / chart.width
    chart.legend.y = 50 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    presentation.save("legend_position.pptx", slides.export.SaveFormat.PPTX)
```

## **Ställ in teckenstorleken för en legend**

Använd legendens [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) för att komma åt dess textformatering och ställ in [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) i punkter.

Det här exemplet skapar ett diagram med standarddata och sätter legendentexten till 20 punkter. Det inaktiverar också automatiska gränser för den vertikala axeln och sätter dess intervall till -5 till 10.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    chart.legend.text_format.portion_format.font_height = 20
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = -5
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 10

    presentation.save("legend_font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Ställ in teckenstorleken för ett enskilt legendelement**

Använd legendens [entries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/entries/)-samling för att komma åt formatering för ett specifikt element. Index för element är nollbaserade, så index `1` avser det andra elementet.

Det här exemplet skapar ett grupperat stapeldiagram vars standarddata innehåller minst två serier. Det formaterar det andra legendelementet med fetstil, kursiv och 20-punkts blå text.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    text_format = chart.legend.entries[1].text_format
    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry_format.pptx", slides.export.SaveFormat.PPTX)
```

## **Dölj enskilda legendelement**

För att utesluta en hjälpserie från legenden medan dess data förblir synlig, sätt [ILegendEntryProperties.hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) till `True` via [IChartSeries.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartseries/related_legend_entry/). Detta döljer endast det valda legendelementet; det tar inte bort serien eller dess datapunkter. Att sätta [IChart.has_legend](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichart/has_legend/) till `False` döljer däremot hela legenden.

Exemplet nedan skapar ett grupperat stapeldiagram med flera serier med standarddata. Det döljer den andra seriens legendelement (index `1`) och sparar presentationen. Det återställer sedan elementet genom att sätta [hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) till `False` och sparar en andra kopia. Kolumnerna förblir synliga i båda filerna.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = True

    legend_entry = chart.chart_data.series[1].related_legend_entry
    legend_entry.hide = True

    presentation.save("hidden_legend_entry.pptx", slides.export.SaveFormat.PPTX)

    # Återställ samma element utan att ändra diagramdata.
    legend_entry.hide = False

    presentation.save("restored_legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

Jämförelsen nedan visar samma diagram med alla element synliga och med det andra elementet dolt. Den andra seriens kolumner förblir oförändrade.

![Jämförelse av ett diagram med alla legendelement synliga och med Serie 2 dold från legenden; alla kolumner förblir synliga.](hide-legend-entry.png)

I stapel-, stapelhorisontella- och linjediagram identifierar legendelement serier. För cirkeldiagram identifierar de enskilda datapunkter (skivor), så använd [IChartDataPoint.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapoint/related_legend_entry/) på den valda skivan istället. API:et dokumenterar denna datapunktsegenskap för diagramtyperna `PIE`, `PIE3D`, `EXPLODED_PIE`, `EXPLODED_PIE3D`, `PIE_OF_PIE` och `BAR_OF_PIE`. Anta inte att den gäller för doughnut-diagram, som inte ingår i listan.

## **FAQ**

**Kan jag få diagrammet att reservera utrymme för legenden istället för att överlappa den?**

Ja. Sätt [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) till `False` för att reservera utrymme för legenden istället för att låta den överlappa plotområdet.

**Kan jag skapa flerradiga legendeetiketter?**

Ja. Långa etiketter kan radbrytas när den tillgängliga bredden är otillräcklig. Du kan också använda nyrader i serienamn för att begära radbrytningar.

**Hur får jag legenden att följa presentationens färgschema?**

Låt legenden färger, fyllningar och teckensnitt vara odefinierade så att den kan ärva temats formatering. Explicit formatering åsidosätter motsvarande temainställningar.