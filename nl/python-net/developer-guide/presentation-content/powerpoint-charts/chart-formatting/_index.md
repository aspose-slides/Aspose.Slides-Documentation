---
title: Grafieken opmaken in presentaties met Python
linktitle: Grafiekopmaak
type: docs
weight: 60
url: /nl/python-net/chart-formatting/
keywords:
- grafiek opmaken
- grafiekopmaak
- grafiekelement
- grafiekeigenschappen
- grafiekinstellingen
- grafiekopties
- lettertype-eigenschappen
- afgeronde rand
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer grafiekopmaak in Aspose.Slides voor Python via .NET en verbeter uw PowerPoint-presentatie met aangepaste assen, lettertypen, getalformaten en afgeronde grafiekranden."
---
## **Overzicht**

Dit artikel legt uit hoe je grafieken in PowerPoint‑presentaties kunt opmaken met Aspose.Slides. Het laat zien hoe je belangrijke grafiekelementen zoals assen, rasterlijnen, titels, legenda's, het plotgebied en wandvullingen kunt aanpassen om het uiterlijk en de leesbaarheid van grafiekinformatie te verbeteren.

Het toont ook hoe je lettertype‑eigenschappen voor grafiekttekst kunt instellen, vooringestelde numerieke opmaak op grafiekgegevens kunt toepassen en afgeronde hoeken voor het grafiekgebied kunt inschakelen. Samen laten deze voorbeelden zien hoe je zowel de visuele stijl als de gegevensweergave van grafieken in een presentatie kunt beheersen.

Voor afzonderlijke vullingen en omtreklijnen op stijgende en dalende intervallen, zie het [voorbeeld van een aandelengrafiek](/slides/nl/python-net/create-chart/#create-stock-charts).

## **Grafiekelementen opmaken**

Gebruik [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) om grafiektitels, assen, rasterlijnen, legenda's en het plotgebied op te maken. Dit voorbeeld maakt een lijngrafiek met markeringen en standaardgegevens, en past vervolgens verschillende tekst‑ en lijnastijlen toe op de waardenas en categoriebenen. Lettergrootte en lijndikte worden opgegeven in punten; categorielabels worden 45 graden gedraaid.

De waardenas gebruikt [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) onafhankelijk van de broncellen. De schaal loopt van -2 tot 15, met hoofd‑intervallen van 2 en sub‑intervallen van 0,5. Het voorbeeld combineert ook procentopmaak met [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) ingesteld op duizenden, dus pas deze instellingen aan op de betekenis en magnitude van je gegevens. De legenda blijft buiten het plotgebied omdat [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) is uitgeschakeld. Achter‑wand‑ en vloer‑vullingen worden geconfigureerd via [back_wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) en [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/), maar deze oppervlakken zijn alleen zichtbaar in 3D‑grafieken.

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

## **Lettertype‑eigenschappen instellen voor een grafiek**

Stel de standaardlettergrootte voor grafiekttekst in via [Chart.text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/text_format/). Het voorbeeld maakt een gegroepeerde kolomgrafiek met een lettertype van 20 punten en schakelt waardelabels in voor de eerste serie via [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). Tekstelementen met hun eigen expliciete lettertype‑instellingen kunnen de standaard van de grafiek overschrijven.

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

## **Tekstframe‑opmaak hergebruiken voor een grafieklegenda**

Om een legenda te laten overeenkomen met een dia‑kop, stel je het lettertype in via [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) op de eerste alinea van de kop. Roep [copy_from](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_from/) aan op de legenda’s [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/). Het kopieert de tekstframe‑instellingen, de opmaak van de eerste alinea en de standaardlettertype‑eigenschappen van die alinea. Opmaak die direct op individuele delen of op latere alinea’s wordt toegepast, blijft lokaal voor de bron.

Het voorbeeld gebruikt een kop in vet, marineblauw, 26‑punt Calibri als sjabloon. Na het stijlen van de legenda wordt [copy_to](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_to/) gebruikt om dezelfde opmaak toe te passen op een afzonderlijke bijschrift.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    heading = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 640, 40, False)
    source_text_frame = heading.add_text_frame("Quarterly sales")
    font = source_text_frame.paragraphs[0].paragraph_format.default_portion_format
    font.latin_font = slides.FontData("Calibri")
    font.font_height = 26
    font.font_bold = slides.NullableBool.TRUE
    font.fill_format.fill_type = slides.FillType.SOLID
    font.fill_format.solid_fill_color.color = slides.Color.from_argb(32, 64, 96)

    chart = shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 75, 640, 360)
    chart.style = charts.StyleType.STYLE3
    workbook = chart.chart_data.chart_data_workbook
    for column, name in enumerate(("Retail", "Online", "Wholesale"), start=1):
        workbook.get_cell(0, 0, column).value = name
    for quarter in range(1, 5):
        workbook.get_cell(0, quarter, 0).value = f"Q{quarter}"

    chart.has_legend = True
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.copy_from(source_text_frame)

    caption = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 460, 640, 40, False)
    caption_text_frame = caption.add_text_frame("Sales in millions of dollars")
    chart.legend.text_format.copy_to(caption_text_frame)

    presentation.save("legend-formatting.pptx", slides.export.SaveFormat.PPTX)
```

In de opgeslagen presentatie komen de legenda en het bijschrift overeen met de kop in grootte, gewicht en kleur. De legenda toont nog steeds de serienamen, en het bijschrift behoudt zijn eigen tekst. Als een deel in het bijschrift al een expliciete lettergrootte heeft, heeft die grootte voorrang op de gekopieerde alinea‑standaard.

| Voor kopiëren | Na kopiëren |
| --- | --- |
| ![Kwartaalverkoopgrafiek met reguliere zwarte legendarlabels en een zwarte bijschrift](legend-formatting-before.png) | ![Dezelfde grafiek met grotere, vette marineblauwe legendarlabels en een passend bijschrift](legend-formatting.png) |

## **Numeriek formaat instellen**

Gebruik [ChartDataCell.preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) om een ingebouwd getalformaat toe te passen op werkboekcellen van de grafiek. Dit voorbeeld maakt een gegroepeerde kolomgrafiek met standaard, cel‑gebaseerde gegevens en past formatindex 10 (`0.00%`) toe op elke waardecel van de serie. Hierdoor wordt de weergave van de waarden in het werkboek aangepast zonder de onderliggende getallen te wijzigen; bijvoorbeeld, 0,25 wordt weergegeven als 25,00 %. As‑ en datalabel‑formaten kunnen afzonderlijk worden geconfigureerd.

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

De volgende tabel somt ingebouwde getalformaat‑indices op met representatieve Excel‑formaten voor de Engelse (Verenigde Staten) locale. De exacte opmaaktekenreeksen en hun weergave kunnen variëren per applicatie en locale, vooral voor valuta en datums. Sommige Excel‑formaten wijken ook af van de standaardinstellingen in de OOXML‑standaard, zoals beschreven in [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Index | Formaat |
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

## **Afgeronde randen van grafiekgebied instellen**

Schakel [Chart.has_rounded_corners](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_rounded_corners/) in om de hoeken van het grafiekgebied af te ronden. Het voorbeeld maakt een gegroepeerde kolomgrafiek en gebruikt [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) om de omtrek een solide grijze kleur en een enkel‑lijnstijl te geven vóór het opslaan van de presentatie.

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

## **Bestaande grafiekaanmerkingen bewerken**

Een grafiek kan aangepaste vormen bevatten, zoals een tekst‑annotatie die de status van een rapport uitlegt. Toegang tot deze vormen krijg je via [Chart.user_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/user_shapes/). De [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/)‑collectie bevat de grafiek‑eigen vormen.

Een gewone tekst‑vak geplaatst boven een grafiek behoort tot de dia, zelfs als het eruitziet als onderdeel van de grafiek. Doorlopen van [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) vindt de grafiek en de gewone dia‑vormen, maar enumerateert niet de individuele vormen binnen de grafiek. Grafiektitels en datalabels zijn afzonderlijke grafiekelementen, geen aangepaste annotaties in deze collectie.

Download [chart-annotations.pptx](chart-annotations.pptx) en plaats deze in de werkmap van de applicatie. De eerste dia bevat een grafiek met een niet‑gegroepeerde annotatie met de tekst “Voorlopige resultaten”, een grafiek‑eigen lijn, en een gewoon dia‑tekstvak met de tekst “Dia‑overlay”. Het voorbeeld vindt de eerste grafiek op die dia en wijzigt de annotatie naar “Eindresultaten” wanneer het rapport klaar is om te publiceren. Het controleert op een lege collectie en bewerkt alleen een [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) met een [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) dat niet `None` is en de verwachte tekst bevat.

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

De lijn en het dia‑tekstvak blijven ongewijzigd. De volgende afbeeldingen tonen de invoer en het opgeslagen, opnieuw geopende resultaat:

| Voor bewerken | Na bewerken |
| --- | --- |
| ![Grafiekannotatie met tekst Voorlopige resultaten](chart-annotations-before.png) | ![Grafiekannotatie met tekst Eindresultaten](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Het voorbeeld inspecteert alleen de top‑level grafiek‑eigen vormen. Als een annotatie zich binnen een [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) bevindt, inspecteer dan ook die groeps [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) collectie. Herhaal dit recursief voor geneste groepen, met dezelfde tekstantwoorden voor hun kind‑vormen. Een groep zelf is een container; behandel deze niet als een tekstvak.
{{% /alert %}}

## **FAQ**

**Kan ik halfdoorzichtige vullingen instellen voor kolommen/gebieden terwijl de rand ondoorzichtig blijft?**

Ja. Vullings‑transparantie en de omtrek worden afzonderlijk geconfigureerd. Dit is nuttig om de leesbaarheid van het raster en de gegevens in dichte visualisaties te verbeteren.

**Hoe kan ik omgaan met datalabels wanneer ze overlappen?**

Verminder de lettergrootte, schakel niet‑essentiële labelcomponenten uit (bijvoorbeeld categorieën), pas de labelpositie aan, toon labels alleen voor geselecteerde punten indien nodig, of schakel over naar het formaat “waarde + legenda”.

**Kan ik verlopen of patroonvullingen toepassen op series?**

Ja. Series ondersteunen solide, verlopen en patroonvullingen. Gebruik verlopen spaarzaam en vermijd combinaties die het contrast met het raster en de tekst verminderen.