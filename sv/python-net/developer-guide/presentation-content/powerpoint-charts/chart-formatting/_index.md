---
title: Formatera diagram i presentationer med Python
linktitle: Diagramformatering
type: docs
weight: 60
url: /sv/python-net/chart-formatting/
keywords:
- formatera diagram
- diagramformatering
- diagramsobjekt
- diagramegenskaper
- diagraminställningar
- diagramalternativ
- teckensnittsegenskaper
- avrundade kanter
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig diagramformatering i Aspose.Slides för Python via .NET och förbättra din PowerPoint-presentation med anpassade axlar, teckensnitt, talformat och avrundade diagramkanter."
---
## **Översikt**

Den här artikeln förklarar hur man formaterar diagram i PowerPoint‑presentationer med Aspose.Slides. Den visar hur man anpassar viktiga diagramkomponenter såsom axlar, rutnät, titlar, förklaringar, plot‑området och väggfyllningar för att förbättra diagrammets utseende och läsbarhet.

Den demonstrerar också hur man anger teckensnittsegenskaper för diagramtext, använder förinställda numeriska format för diagramdata och aktiverar avrundade hörn för diagramområdet. Tillsammans visar dessa exempel hur man styr både den visuella stilen och datapresentationen för diagram i en presentation.

## **Formatera diagramobjekt**

Använd [Diagram](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) för att formatera diagramtitlar, axlar, rutnät, förklaringar och plot‑området. Detta exempel skapar ett linjediagram med markörer och standarddata, och tilldelar sedan separata text‑ och linjestilar till dess värde‑ och kategori‑axlar. Teckenstorlekar och linjebredd anges i punkter; kategorietiketter roteras 45 grader.

Värdeaxeln använder [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) oberoende av källcellerna. Dess skala går från -2 till 15, med huvudintervall på 2 och delintervall på 0,5. Exemplet kombinerar även procentformat med [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) satt till tusental, så anpassa dessa inställningar efter betydelse och omfattning för dina data. Förklaringen placeras utanför plot‑området eftersom [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) är inaktiverad. Bakväggs‑ och golvfyllningar konfigureras via [back_wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) och [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/), men dessa ytor är bara synliga i 3D‑diagram.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = slides.NullableBool.TRUE
    chart_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = slides.NullableBool.TRUE
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = slides.NullableBool.TRUE
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = slides.NullableBool.TRUE
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = slides.NullableBool.TRUE
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID
    legend_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_red

    chart.legend.overlay = False

    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = slides.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = slides.Color.red

    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = slides.Color.light_cyan

    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Ange teckensnittsegenskaper för ett diagram**

Ange standardteckensnittsstorlek för diagramtext via [Chart.text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/text_format/). Exemplet skapar ett grupperat stapeldiagram med 20‑punkts teckensnitt och aktiverar värdetiketter för den första serien via [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). Textobjekt med egna explicita teckensnitt kan åsidosätta diagramstandarderna.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **Ange det numeriska formatet**

Använd [ChartDataCell.preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) för att tillämpa ett inbyggt talformat på diagrammets arbetsboks­celler. Detta exempel skapar ett grupperat stapeldiagram med standard, cellstödd data och använder formatindex 10 (`0.00%`) för varje serievärdescell. Detta ändrar hur värdena visas i arbetsboken utan att ändra de underliggande siffrorna; exempelvis visas 0,25 som 25,00 %. Axel‑ och datatetikettformat kan konfigureras separat.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    for series in chart.chart_data.series:
        for data_point in series.data_points:
            data_point.value.as_cell.preset_number_format = 10  # 0.00%

    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

Följande tabell listar inbyggda talformatindex med representativa Excel‑format för den engelska (USA)‑lokalen. De exakta formatsträngarna och deras visning kan variera mellan program och språk, särskilt för valuta och datum. Vissa Excel‑format avviker också från standarderna i OOXML, enligt [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Index | Format |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Ange avrundade kanter för diagramområde**

Aktivera [Chart.has_rounded_corners](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_rounded_corners/) för att runda hörnen på diagramområdet. Exemplet skapar ett grupperat stapeldiagram och använder [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) för att ge dess kontur en solid grå färg och en enkel linjestil innan presentationen sparas.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.line_format.fill_format.fill_type = slides.FillType.SOLID
    chart.line_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart.line_format.style = slides.LineStyle.SINGLE
    chart.has_rounded_corners = True

    presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **Redigera befintliga diagramanteckningar**

Ett diagram kan innehålla anpassade former, exempelvis en textanteckning som förklarar statusen för en rapport. Åtkomst till dessa former sker via [Chart.user_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/user_shapes/). Dess [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/)‑samling innehåller de former som ägs av diagrammet.

En vanlig textruta placerad ovanpå ett diagram tillhör bilden, även om den ser ut som en del av diagrammet. Genom att iterera över [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) hittas både diagrammet och vanliga bildformer, men inte de enskilda formerna inuti diagrammet. Diagramtitlar och datatetiketter är separata diagramelement, inte anpassade anteckningar i denna samling.

Ladda ner [chart-annotations.pptx](chart-annotations.pptx) och placera den i applikationens arbetskatalog. Dess första bild innehåller ett diagram med en upplöst anteckning som lyder "Preliminary results", en diagramägd linje och en vanlig bildtextruta med texten "Slide overlay". Exemplet hittar första diagrammet på den bilden och ändrar anteckningen till "Final results" när rapporten är klar för publicering. Det kontrollerar om samlingen är tom och redigerar endast en [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) med en [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) som inte är `None` och som innehåller den förväntade texten.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-annotations.pptx") as presentation:
    slide = presentation.slides[0]
    chart = next((shape for shape in slide.shapes if isinstance(shape, charts.Chart)), None)

    if chart is None or len(chart.user_shapes.shapes) == 0:
        print("No chart or chart-owned shapes found.")
    else:
        updated = False
        for shape in chart.user_shapes.shapes:
            if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
                if shape.text_frame.text == "Preliminary results":
                    shape.text_frame.text = "Final results"
                    updated = True
                    break

        if updated:
            presentation.save("chart-annotations-updated.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("No matching text annotation found.")
```

Linjen och bildtextrutan förblir oförändrade. Följande bilder visar indata och det sparade, återöppnade resultatet:

| Före redigering | Efter redigering |
| --- | --- |
| ![Diagramanteckning som visar Preliminary results](chart-annotations-before.png) | ![Diagramanteckning som visar Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Exemplet granskar endast de top‑nivå diagramägda formerna. Om en anteckning finns i en [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), inspektera också den gruppens [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/)‑samling. Upprepa detta rekursivt för nästlade grupper och applicera samma textkontroller på deras underliggande former. En grupp är i sig en behållare; behandla den inte som en textruta.
{{% /alert %}}

## **FAQ**

**Kan jag ange halvtransparenta fyllningar för kolumner/områden samtidigt som kanten förblir opak?**

Ja. Fyllnadens transparens och konturen konfigureras separat. Detta är användbart för att förbättra läsbarheten i rutnätet och data i täta visualiseringar.

**Hur kan jag hantera datatetiketter när de överlappar?**

Minska teckenstorleken, inaktivera icke‑essentiella etikettkomponenter (t.ex. kategorier), justera etikettpositionen, visa etiketter endast för utvalda punkter vid behov, eller byt format till "värde + förklaring".

**Kan jag tillämpa gradient‑ eller mönsterfyllningar på serier?**

Ja. Serier stöder solid, gradient och mönsterfyllningar. I praktiken bör gradienter användas sparsamt och kombinationer som minskar kontrasten mot rutnätet och text undvikas.