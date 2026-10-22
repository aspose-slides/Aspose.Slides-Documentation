---
title: Diagrammen opmaken in presentaties met Python
linktitle: Diagramopmaak
type: docs
weight: 60
url: /nl/python-net/chart-formatting/
keywords:
- diagram opmaken
- diagramopmaak
- diagramonderdeel
- diagrameigenschappen
- diagraminstellingen
- diagramopties
- lettertype-eigenschappen
- afgeronde rand
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer diagramopmaak in Aspose.Slides voor Python via .NET en verbeter uw PowerPoint-presentatie met aangepaste assen, lettertypen, getalformaten en afgeronde diagramranden."
---
## **Overzicht**

Dit artikel legt uit hoe je diagrammen in PowerPoint‑presentaties kunt opmaken met Aspose.Slides. Het toont hoe je belangrijke diagramonderdelen zoals assen, rasterlijnen, titels, legenden, het plotgebied en wand‑vullingen kunt aanpassen om het uiterlijk en de leesbaarheid van diagramgegevens te verbeteren.

Het laat ook zien hoe je lettertype‑eigenschappen voor diagramtekst kunt instellen, vooraf ingestelde numerieke opmaak kunt toepassen op diagramgegevens, en afgeronde hoeken kunt inschakelen voor het diagramgebied. Samen laten deze voorbeelden zien hoe je zowel de visuele stijl als de gegevenspresentatie van diagrammen in een presentatie kunt beheersen.

## **Diagramonderdelen opmaken**

Gebruik [Grafiek](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) om diagramtitels, assen, rasterlijnen, legenden en het plotgebied op te maken. Dit voorbeeld maakt een lijndiagram met markeringen en standaardgegevens, en past vervolgens afzonderlijke tekst‑ en lijneigenschappen toe op de waarde‑ en categorisatie‑assen. Lettergrootte en lijndikte worden opgegeven in punten; categorielabels worden 45 graden gedraaid.

De waarde‑as gebruikt [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) onafhankelijk van de broncellen. De schaal loopt van –2 tot 15, met hoofd‑intervallen van 2 en sub‑intervallen van 0,5. Het voorbeeld combineert ook procent‑opmaak met [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) ingesteld op duizendtallen, dus pas deze instellingen aan op de betekenis en grootte van jouw gegevens. De legende blijft buiten het plotgebied omdat [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) gedeactiveerd is. Achter‑wand‑ en vloervullingen worden geconfigureerd via [back_wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) en [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/), maar deze oppervlakken zijn alleen zichtbaar in 3D‑diagrammen.

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

## **Lettertype‑eigenschappen voor een diagram instellen**

Stel de standaardlettergrootte voor diagramtekst in via [Chart.text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/text_format/). Het voorbeeld maakt een gegroepeerde kolomgrafiek met een lettertype van 20 punten en schakelt waardelabels in voor de eerste reeks via [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). Tekstelementen met hun eigen expliciete lettertype‑instellingen kunnen de standaard van het diagram overschrijven.

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

## **Numerieke opmaak instellen**

Gebruik [ChartDataCell.preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) om een ingebouwde getal‑opmaak toe te passen op werkbladcellen van het diagram. Dit voorbeeld maakt een gegroepeerde kolomgrafiek met standaard, cel‑ondersteunde gegevens en past opmaakindex 10 (`0.00%`) toe op elke reekswaarde‑cel. Dit verandert hoe de waarden in het werkboek worden weergegeven zonder de onderliggende cijfers te wijzigen; bijvoorbeeld, 0,25 wordt weergegeven als 25,00 %. As‑ en gegevens‑label‑opmaak kunnen apart worden geconfigureerd.

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

De volgende tabel geeft ingebouwde getal‑opmaakindices weer met representatieve Excel‑opmaken voor de Engelse (Verenigde Staten) locale. De exacte opmaak‑strings en weergave kunnen per toepassing en locale verschillen, met name voor valuta en datums. Sommige Excel‑opmaken wijken ook af van de standaardinstellingen in de OOXML‑norm, zoals beschreven in [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Index | Opmaak |
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

## **Afgeronde randen voor diagramgebied inschakelen**

Schakel [Chart.has_rounded_corners](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_rounded_corners/) in om de hoeken van het diagramgebied af te ronden. Het voorbeeld maakt een gegroepeerde kolomgrafiek en gebruikt [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) om de omtrek een effen grijze kleur en een enkel‑lijn‑stijl te geven voordat de presentatie wordt opgeslagen.

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

## **Bestaande diagram‑annotaties bewerken**

Een diagram kan aangepaste vormen bevatten, zoals een tekstantwoord die de status van een rapport uitlegt. Toegang tot deze vormen krijg je via [Chart.user_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/user_shapes/). De [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/)‑collectie bevat de vormen die bij het diagram horen.

Een gewone tekst‑vak die over een diagram is geplaatst, behoort tot de dia, zelfs als het eruitziet als een onderdeel van het diagram. Het doorlopen van [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) vindt het diagram en de gewone dia‑vormen, maar telt de individuele vormen binnen het diagram niet op. Diagramtitels en gegevens‑labels zijn afzonderlijke diagramonderdelen, geen aangepaste annotaties in deze collectie.

Download [chart-annotations.pptx](chart-annotations.pptx) en plaats deze in de werkmap van de toepassing. De eerste dia bevat een diagram met een niet‑gegroepeerde annotatie “Preliminary results”, een diagram‑eigene lijn, en een gewoon dia‑tekstvak met “Slide overlay”. Het voorbeeld vindt het eerste diagram op die dia en wijzigt de annotatie naar “Final results” zodra het rapport klaar is om te publiceren. Het controleert of de collectie leeg is en bewerkt alleen een [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) met een [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) dat niet `None` is en de verwachte tekst bevat.

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

De lijn en het dia‑tekstvak blijven ongewijzigd. De volgende afbeeldingen tonen het invoer‑ en het opgeslagen, heropende resultaat:

| Voor bewerking | Na bewerking |
| --- | --- |
| ![Diagramannotatie met tekst Preliminary results](chart-annotations-before.png) | ![Diagramannotatie met tekst Final results](chart-annotations-after.png) |

{{% alert color="info" title="Opmerking" %}}

Het voorbeeld kijkt alleen naar de boven‑niveau diagram‑eigene vormen. Als een annotatie zich binnen een [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) bevindt, inspecteer dan ook de [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/)‑collectie van die groep. Herhaal dit recursief voor geneste groepen, waarbij je dezelfde tekstcontroles toepast op hun onderliggende vormen. Een groep zelf is een container; behandel deze niet als een tekstvak.

{{% /alert %}}

## **FAQ**

**Kan ik halfdoorzichtige vullingen voor kolommen/gebieden instellen terwijl de rand ondoorzichtig blijft?**

Ja. Vullingstransparantie en de omtrek worden apart geconfigureerd. Dit is nuttig om de leesbaarheid van het raster en de gegevens in dichte visualisaties te verbeteren.

**Hoe ga ik om met gegevens‑labels die overlappen?**

Verklein de lettergrootte, schakel niet‑essentiële labelonderdelen uit (bijvoorbeeld categorieën), pas de labelpositie aan, geef alleen labels weer voor geselecteerde punten indien nodig, of wissel het formaat naar “waarde + legende”.

**Kan ik verloop‑ of patroon‑vullingen toepassen op reeksen?**

Ja. Reeksen ondersteunen massieve, verloop‑ en patroon‑vullingen. Gebruik verloopspatronen spaarzaam en vermijd combinaties die het contrast met het raster en de tekst verminderen.