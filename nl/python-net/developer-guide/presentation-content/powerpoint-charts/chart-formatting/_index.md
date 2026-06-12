---
title: Diagrammen opmaken in presentaties met Python
linktitle: Diagramopmaak
type: docs
weight: 60
url: /nl/python-net/chart-formatting/
keywords:
- diagram opmaken
- diagramopmaak
- diagramobject
- diagrameigenschappen
- diagraminstellingen
- diagramopties
- lettertype‑eigenschappen
- afgeronde rand
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Leer diagramopmaak in Aspose.Slides voor Python via .NET en til uw PowerPoint- of OpenDocument‑presentatie naar een professioneel, opvallend ontwerp."
---
## **Overzicht**

Dit artikel legt uit hoe je diagrammen in PowerPoint‑presentaties kunt opmaken met Aspose.Slides. Het laat zien hoe je belangrijke diagramonderdelen zoals assen, rasterlijnen, titels, legenda’s, het plotgebied en wandvullingen kunt aanpassen om het uiterlijk en de leesbaarheid van diagramgegevens te verbeteren.

Het toont tevens hoe je lettertype‑eigenschappen voor diagramtekst instelt, vooraf ingestelde en aangepaste numerieke opmaak toepast op diagramgegevens, en afgeronde hoeken inschakelt voor het diagramgebied. Samen laten deze voorbeelden zien hoe je zowel de visuele stijl als de gegevenspresentatie van diagrammen in een presentatie kunt beheersen.

## **Diagramonderdelen opmaken**

Aspose.Slides for Python stelt ontwikkelaars in staat om vanaf nul aangepaste diagrammen aan hun dia’s toe te voegen. Deze sectie legt uit hoe verschillende diagramonderdelen, inclusief de categorie‑ en waardenassen, kunnen worden opgemaakt.

Aspose.Slides biedt een eenvoudige API voor het beheren van diagramonderdelen en het toepassen van aangepaste opmaak:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Haal een referentie naar de dia op basis van de index.
1. Voeg een diagram toe met standaardgegevens van het gewenste type (in dit voorbeeld `ChartType.LINE_WITH_MARKERS`).
1. Toegang tot de waardenas van het diagram en stel het volgende in:
   1. Stel het **lijnformaat** in voor de hoofd‑rasterlijnen van de waardenas.
   1. Stel het **lijnformaat** in voor de onder‑rasterlijnen van de waardenas.
   1. Stel het **getalformaat** in voor de waardenas.
   1. Stel de **min‑, max‑, hoofd‑ en onder‑eenheden** in voor de waardenas.
   1. Stel de **tekst‑eigenschappen** in voor de labels van de waardenas.
   1. Stel de **titel** in voor de waardenas.
   1. Stel het **lijnformaat** in voor de waardenas.
1. Toegang tot de categorieas van het diagram en stel het volgende in:
   1. Stel het **lijnformaat** in voor de hoofd‑rasterlijnen van de categorieas.
   1. Stel het **lijnformaat** in voor de onder‑rasterlijnen van de categorieas.
   1. Stel de **tekst‑eigenschappen** in voor de labels van de categorieas.
   1. Stel de **titel** in voor de categorieas.
   1. Stel de **labelpositionering** in voor de categorieas.
   1. Stel de **rotatiehoek** in voor de labels van de categorieas.
1. Toegang tot de legenda van het diagram en stel de **tekst‑eigenschappen** in.
1. Toon de legende van het diagram zonder deze te overlappen.
1. Toegang tot de **secundaire waardenas** van het diagram en stel het volgende in:
   1. Schakel de secundaire **waardenas** in.
   1. Stel het **lijnformaat** in voor de secundaire waardenas.
   1. Stel het **getalformaat** in voor de secundaire waardenas.
   1. Stel de **min‑, max‑, hoofd‑ en onder‑eenheden** in voor de secundaire waardenas.
1. Plot de eerste diagramreeks op de secundaire waardenas.
1. Stel de vulkleur van de achterwand van het diagram in.
1. Stel de vulkleur van het plot‑gebied van het diagram in.
1. Schrijf de gewijzigde presentatie weg naar een PPTX‑bestand.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantieer de Presentation‑klasse.
with slides.Presentation() as presentation:

    # Toegang tot de eerste dia.
    slide = presentation.slides[0]

    # Voeg een voorbeelddiagram toe.
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # Stel de diagramtitel in.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = 1
    chart_title.portion_format.font_italic = 1

    # Stel het formaat van de hoofd‑rasterlijnen in voor de waardenas.
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # Stel het formaat van de onder‑rasterlijnen in voor de waardenas.
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # Stel het getalformaat van de waardenas in.
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # Stel de maximale, minimale, hoofd‑ en onder‑eenheden van de waardenas in.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # Stel de tekst‑eigenschappen van de waardenas in.
    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = 1
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = 1
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    vertical_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    # Stel de titel van de waardenas in.
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = 1
    vertical_axis_title.portion_format.font_italic = 1

    # Stel het formaat van de hoofd‑rasterlijnen in voor de categorieas.
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # Stel het formaat van de onder‑rasterlijnen in voor de categorieas.
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # Stel de tekst‑eigenschappen van de categorieas in.
    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = 1
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = 1
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    # Stel de titel van de categorieas in.
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = 1
    horizontal_axis_title.portion_format.font_italic = 1

    # Stel de label‑positionering van de categorieas in.
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # Stel de rotatiehoek van de categorieas‑labels in.
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # Stel de tekst‑eigenschappen van de legenda in.
    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = 1
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = 1
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

    # Toon de diagramlegenda overlappend op het diagram.
    chart.legend.overlay = True
                
    # Stel de kleur van de achterwand van het diagram in.
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red

    # Stel de kleur van het plot‑gebied in.
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # Sla de presentatie op.
    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Lettertype‑eigenschappen voor diagrammen instellen**

Aspose.Slides for Python ondersteunt het instellen van lettertypegerelateerde eigenschappen voor diagrammen. Volg de onderstaande stappen om de lettertype‑eigenschappen van een diagram te configureren:

1. Instantieer een [Presentatie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑object.
1. Voeg een diagram toe aan de dia.
1. Stel de letterhoogte in.
1. Sla de gewijzigde presentatie op.

Een voorbeeldcode wordt hieronder gegeven.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **Getalformaat instellen**

Aspose.Slides for Python biedt een eenvoudige API voor het beheren van diagram‑gegevensopmaak:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar de dia op basis van de index.
1. Voeg een diagram toe met standaardgegevens van het gewenste type.
1. Stel een vooraf ingesteld getalformaat in uit de beschikbare preset‑waarden.
1. Doorloop de diagram‑gegevenscellen in elke reeks en stel het getalformaat in.
1. Sla de presentatie op.
1. Stel een aangepast getalformaat in.
1. Doorloop de diagram‑gegevenscellen in elke reeks en stel een ander getalformaat in.
1. Sla de presentatie op.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Instantieer de Presentation‑klasse.
with slides.Presentation() as presentation:
    # Toegang tot de eerste dia.
    slide = presentation.slides[0]

    # Voeg een standaard gegroepeerde kolomdiagram toe.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # Stel het vooraf ingestelde getalformaat in.
    # Doorloop elke diagramreeks.
    for series in chart.chart_data.series:
        # Doorloop elk gegevenspunt in de reeks.
        for cell in series.data_points:
            # Stel het getalformaat in.
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # Sla de presentatie op.
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

De beschikbare vooraf ingestelde getalformaten en hun bijbehorende indexen staan hieronder opgesomd.

|**0**|Algemeen|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Afgeronde randen voor het diagramgebied instellen**

Aspose.Slides for Python ondersteunt het configureren van het diagramgebied via de eigenschap `Chart.has_rounded_corners`.

1. Instantieer een [Presentatie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑object.
2. Voeg een diagram toe aan de dia.
3. Stel het vultype en de vulkleur van het diagram in.
4. Stel de eigenschap voor afgeronde hoeken in op `True`.
5. Sla de gewijzigde presentatie op.

Een voorbeeld wordt hieronder getoond.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
	slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
	chart.line_format.fill_format.fill_type = slides.FillType.SOLID
	chart.line_format.style = slides.LineStyle.SINGLE
	chart.has_rounded_corners = True

	presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan ik semi‑transparante vullingen voor kolommen/gebieden instellen terwijl de rand ondoorzichtig blijft?**

Ja. De transparantie van de vulling en de omtreklijn worden afzonderlijk geconfigureerd. Dit is handig om de leesbaarheid van het raster en de gegevens in drukke visualisaties te verbeteren.

**Hoe ga ik om met gegevenslabels wanneer ze elkaar overlappen?**

Verminder de lettergrootte, schakel niet‑essentiële labelonderdelen uit (bijvoorbeeld categorieën), stel de label‑offset/positie in, toon alleen labels voor geselecteerde punten indien nodig, of wijzig het formaat naar “waarde + legende”.

**Kan ik gradient‑ of patroonvullingen toepassen op reeksen?**

Ja. Zowel effen als gradient‑/patroonvullingen zijn doorgaans beschikbaar. Gebruik in de praktijk gradients spaarzaam en vermijd combinaties die het contrast met het raster en de tekst verminderen.