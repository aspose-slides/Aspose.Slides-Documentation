---
title: Formatera diagram i presentationer med Python
linktitle: Diagramformatering
type: docs
weight: 60
url: /sv/python-net/chart-formatting/
keywords:
- formatera diagram
- diagramformatering
- diagramobjekt
- diagramegenskaper
- diagraminställningar
- diagramalternativ
- teckensnittegenskaper
- rundade kanter
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lär dig diagramformatering i Aspose.Slides för Python via .NET och förbättra din PowerPoint- eller OpenDocument-presentation med professionell, iögonfallande stil."
---
## **Översikt**

Den här artikeln förklarar hur man formaterar diagram i PowerPoint-presentationer med Aspose.Slides. Den visar hur man anpassar viktiga diagramdelar såsom axlar, rutnätlinjer, titlar, förklaringar, plotområdet och väggfyllningar för att förbättra diagrammens utseende och läsbarhet.

Den demonstrerar också hur man ställer in teckensnittsegenskaper för diagramtext, tillämpar förinställda och anpassade numeriska format på diagramdata samt aktiverar rundade hörn för diagramområdet. Tillsammans visar dessa exempel hur man styr både den visuella stilen och data presentationen av diagram i en presentation.

## **Formatera diagramdelar**

Aspose.Slides för Python låter utvecklare lägga till anpassade diagram i sina bilder från grunden. Detta avsnitt förklarar hur man formaterar olika diagramdelar, inklusive kategori- och värdeaxlar.

Aspose.Slides tillhandahåller ett enkelt API för att hantera diagramdelar och tillämpa anpassad formatering:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Hämta en referens till bilden med dess index.
3. Lägg till ett diagram med standarddata av önskad typ (i detta exempel, `ChartType.LINE_WITH_MARKERS`).
4. Få åtkomst till diagrammets värdeaxel och ställ in följande:
   1. Ange **linjeformatet** för värdeaxelns huvudrutnätlinjer.
   2. Ange **linjeformatet** för värdeaxelns sekundära rutnätlinjer.
   3. Ange **nummerformatet** för värdeaxeln.
   4. Ange **min, max, huvud- och sekundära enheter** för värdeaxeln.
   5. Ange **textegenskaperna** för värdeaxelns etiketter.
   6. Ange **titel** för värdeaxeln.
   7. Ange **linjeformatet** för värdeaxeln.
5. Få åtkomst till diagrammets kategori-axel och ställ in följande:
   1. Ange **linjeformatet** för kategori-axelns huvudrutnätlinjer.
   2. Ange **linjeformatet** för kategori-axelns sekundära rutnätlinjer.
   3. Ange **textegenskaperna** för kategori-axelns etiketter.
   4. Ange **titel** för kategori-axeln.
   5. Ange **etikettplaceringen** för kategori-axeln.
   6. Ange **rotationsvinkeln** för kategori-axelns etiketter.
6. Få åtkomst till diagrammets förklaring och ange dess **textegenskaper**.
7. Visa diagramförklaringen utan att den överlappar diagrammet.
8. Få åtkomst till diagrammets **sekundära värdeaxel** och ställ in följande:
   1. Aktivera den sekundära **värdeaxeln**.
   2. Ange **linjeformatet** för den sekundära värdeaxeln.
   3. Ange **nummerformatet** för den sekundära värdeaxeln.
   4. Ange **min, max, huvud- och sekundära enheter** för den sekundära värdeaxeln.
9. Rita den första diagramserien på den sekundära värdeaxeln.
10. Ange diagrammets bakväggsfyllningsfärg.
11. Ange diagrammets plot-områdes fyllningsfärg.
12. Skriv den modifierade presentationen till en PPTX‑fil.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Skapa en instans av Presentation-klassen.
with slides.Presentation() as presentation:

    # Hämta den första bilden.
    slide = presentation.slides[0]

    # Lägg till ett exempel-diagram.
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # Ställ in diagramtiteln.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = 1
    chart_title.portion_format.font_italic = 1

    # Angiv huvudrutnätformat för värdeaxeln.
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # Angiv sekundärt rutnätformat för värdeaxeln.
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # Angiv nummerformat för värdeaxeln.
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # Angiv värdeaxelns max-, min-, huvud- och sekundära enheter.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # Angiv textegenskaper för värdeaxeln.
    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = 1
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = 1
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    vertical_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    # Angiv titel för värdeaxeln.
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = 1
    vertical_axis_title.portion_format.font_italic = 1

    # Angiv huvudrutnätformat för kategori-axeln.
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # Angiv sekundärt rutnätformat för kategori-axeln.
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # Angiv textegenskaper för kategori-axeln.
    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = 1
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = 1
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    # Angiv titel för kategori-axeln.
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = 1
    horizontal_axis_title.portion_format.font_italic = 1

    # Angiv etikettposition för kategori-axeln.
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # Angiv rotationsvinkel för kategori-axelns etiketter.
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # Angiv textegenskaper för förklaringen.
    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = 1
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = 1
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

    # Visa diagramförklaringen överlappande diagrammet.
    chart.legend.overlay = True
                
    # Angiv bakväggens färg för diagrammet.
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red

    # Angiv färg för plot-området.
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # Spara presentationen.
    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Ställ in diagramteckensnittsegenskaper**

Aspose.Slides för Python stöder att ställa in teckensnittsegenskaper för diagram. Följ stegen nedan för att konfigurera diagrammets teckensnittsegenskaper:

1. Instansiera ett [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)‑objekt.
2. Lägg till ett diagram på bilden.
3. Ange teckensnittshöjden.
4. Spara den modifierade presentationen.

Ett exempel på kod finns nedan.

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

## **Ange numeriskt format**

Aspose.Slides för Python tillhandahåller ett enkelt API för att hantera diagramdatas format:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Hämta en referens till bilden med dess index.
3. Lägg till ett diagram med standarddata av vilken önskad typ som helst.
4. Ange ett förinställt nummerformat från de tillgängliga förinställda värdena.
5. Gå igenom diagramdatacellerna i varje serie och ange nummerformatet.
6. Spara presentationen.
7. Ange ett anpassat nummerformat.
8. Gå igenom diagramdatacellerna i varje serie och ange ett annat nummerformat.
9. Spara presentationen.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Instansiera Presentation-klassen.
with slides.Presentation() as presentation:
    # Hämta den första bilden.
    slide = presentation.slides[0]

    # Lägg till ett standardklustrat stapeldiagram.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # Ställ in det förinställda nummerformatet.
    # Gå igenom varje diagramserie.
    for series in chart.chart_data.series:
        # Gå igenom varje datapunkt i serien.
        for cell in series.data_points:
            # Ställ in nummerformatet.
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # Spara presentationen.
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

De tillgängliga förinställda nummerformaten och deras motsvarande index listas nedan.

|**0**|Allmänt|
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

## **Ange rundade kanter för diagramområdet**

Aspose.Slides för Python stöder konfigurering av diagramområdet med egenskapen `Chart.has_rounded_corners`.

1. Instansiera ett [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)‑objekt.
2. Lägg till ett diagram på bilden.
3. Ange diagrammets fyllningstyp och fyllningsfärg.
4. Ställ in egenskapen rounded-corners till `True`.
5. Spara den modifierade presentationen.

Ett exempel finns nedan.

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

**Kan jag ange halvtransparenta fyllningar för kolumner/områden samtidigt som kanten förblir opak?**

Ja. Fyllnadens transparens och konturen konfigureras separat. Detta är användbart för att förbättra läsbarheten av rutnätet och data i täta visualiseringar.

**Hur kan jag hantera datalabels när de överlappar?**

Minska teckensnittsstorleken, inaktivera icke nödvändiga labelkomponenter (till exempel kategorier), justera labelns förskjutning/position, visa endast etiketter för valda punkter om det behövs, eller byt formatet till "värde + förklaring".

**Kan jag använda gradient‑ eller mönsterfyllningar på serier?**

Ja. Både solida och gradient-/mönsterfyllningar är vanligtvis tillgängliga. I praktiken bör gradienter användas sparsamt och kombinationer som minskar kontrasten mot rutnätet och texten undvikas.