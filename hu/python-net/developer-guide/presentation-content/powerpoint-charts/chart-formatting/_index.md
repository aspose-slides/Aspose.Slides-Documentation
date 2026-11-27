---
title: Diagramok formázása prezentációkban Python használatával
linktitle: Diagramformázás
type: docs
weight: 60
url: /hu/python-net/chart-formatting/
keywords:
- diagram formázása
- diagram formázás
- diagramelem
- diagram tulajdonságok
- diagram beállítások
- diagram opciók
- betűtípus tulajdonságok
- lekerekített szegély
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg a diagramok formázását az Aspose.Slides for Python .NET-en keresztül, és emelje szintre PowerPoint prezentációját egyedi tengelyekkel, betűtípusokkal, számformátumokkal és lekerekített diagramszegélyekkel."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázhatók a diagramok PowerPoint‑prezentációkban az Aspose.Slides használatával. Megmutatja, hogyan testreszabhatók a diagram kulcsfontosságú elemei, például tengelyek, rácsvonalak, címek, jelmagyarázatok, ábrázolási terület és a falak kitöltései, a diagramadatok megjelenésének és olvashatóságának javítása érdekében.

Ez továbbá bemutatja, hogyan állítható be a betűtípus-tulajdonság a diagram szövegéhez, hogyan alkalmazhatók előre definiált számalakzatok a diagram adatokra, és hogyan engedélyezhetők lekerekített sarkok a diagram területén. Ezek a példák együtt megmutatják, hogyan irányítható a diagram vizuális stílusa és az adatok bemutatása egy prezentációban.

A növekvő és csökkenő intervallumokhoz külön kitöltések és keretek esetén lásd a [stock chart example](/slides/hu/python-net/create-chart/#create-stock-charts) példát.

## **Diagramelemek formázása**

Használja a [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) elemet diagramcímek, tengelyek, rácsvonalak, jelmagyarázatok és ábrázolási terület formázásához. Ez a példa egy jelölőkkel ellátott vonaldiagramot hoz létre alapértelmezett adatokkal, majd külön szöveg- és vonalstílusokat alkalmaz az érték‑ és kategória‑tengelyeire. A betűméretek és vonalszélességek pontban vannak megadva; a kategória‑címkék 45 fokban vannak elforgatva.

Az értéktengely a [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) beállítást használja a forráscelláktól függetlenül. A skála -2-től 15-ig terjed, fő intervallumok 2‑esek, kisebb intervallumok 0,5‑esek. A példa a százalékos formázást kombinálja a [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) ezresekre állított beállításával, így ezeket a beállításokat a saját adatai jelentésének és nagyságának megfelelően kell testre szabni. A jelmagyarázat a ábrázolási terület kívül marad, mivel az [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) ki van kapcsolva. A háttér‑fal és a padló kitöltései a [back_wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) és a [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/) segítségével állíthatók be, de ezek a felületek csak 3D diagramoknál láthatók.

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

## **Diagram betűtípus‑tulajdonságainak beállítása**

A diagram szövegéhez alapértelmezett betűméretet a [Chart.text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/text_format/) segítségével állíthatja be. A példa egy csoportos oszlopdiagramot hoz létre 20‑pontos betűvel, és az első sorozat értékcímkéit a [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) segítségével engedélyezi. Az egyedi betűbeállításokkal rendelkező szövegelemek felülírhatják a diagram alapértelmezett beállításait.

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

## **Szövegkeret formázásának újrafelhasználása diagram jelmagyarázatához**

A jelmagyarázatot a dia címsorához igazítva a cím első bekezdésének [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) tulajdonságát állítsa be. Hívja meg a [copy_from](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_from/) metódust a jelmagyarázat [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) objektumán. Ez átmásolja a szövegkeret beállításait, az első bekezdés formázását és a bekezdés alapértelmezett betűtulajdonságait. Az egyedi szakaszokra vagy későbbi bekezdésekre közvetlenül alkalmazott formázás a forrásra korlátozódik.

A példa egy félkövér, tengerészkék, 26‑pontos Calibri címsort használ sablonként. A jelmagyarázat stilizálása után a [copy_to](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_to/) segítségével ugyanazt a formázást alkalmazza egy külön feliratra.

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

A mentett prezentációban a jelmagyarázat és a felirat méretben, súlyban és színben megegyezik a címsorral. A jelmagyarázat továbbra is a sorozatneveket jeleníti meg, a felirat pedig a saját szövegét tartja meg. Ha a felirat egy része már explicit betűmérettel rendelkezik, az a méret felülírja a másolt bekezdés alapértelmezett értékét.

| Másolás előtt | Másolás után |
| --- | --- |
| ![Negyedéves értékesítési diagram rendszeres fekete jelmagyarázat-címkékkel és fekete felirattal](legend-formatting-before.png) | ![Ugyanez a diagram nagyobb, félkövér tengerészkék jelmagyarázat-címkékkel és egyező felirattal](legend-formatting.png) |

## **Számformátum beállítása**

Használja a [ChartDataCell.preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) metódust beépített számformátum alkalmazásához a diagram munkafüzetcelláira. Ez a példa egy csoportos oszlopdiagramot hoz létre alapértelmezett, cellához kötött adatokkal, és a 10‑es formátumindexet (`0.00%`) minden sorozatérték‑cellára alkalmazza. Ez megváltoztatja, hogyan jelennek meg az értékek a munkafüzetben anélkül, hogy a tényleges számok módosulnának; például a 0,25 25.00%-ként jelenik meg. A tengely‑ és adatcímke‑formátumok külön is konfigurálhatók.

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

Az alábbi táblázat a beépített számformátum‑indexeket sorolja fel tipikus Excel‑formátumokkal az angol (Egyesült Államok) nyelvi beállításra. A pontos formátumkarakterláncok és megjelenítésük alkalmazásonként és helyi beállításonként eltérhet, különösen pénznemek és dátumok esetén. Egyes Excel‑formátumok eltérnek az OOXML szabvány alapértelmezéseitől, amint azt a [Microsoft számalakzat‑implementációs jegyzetek](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) leírja.

| Index | Formátum |
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

## **Diagram terület lekerekített szegélyeinek beállítása**

A [Chart.has_rounded_corners](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_rounded_corners/) engedélyezésével lekerekítheti a diagram terület sarkait. A példa egy csoportos oszlopdiagramot hoz létre, és a [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) segítségével szilárd szürke színű, egyvonalas körvonalat ad a diagramnak, mielőtt a prezentációt mentené.

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

## **Meglévő diagram annotációk szerkesztése**

Egy diagram tartalmazhat egyedi alakzatokat, például egy szöveges annotációt, amely a jelentés állapotát magyarázza. Ezeket az alakzatokat a [Chart.user_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/user_shapes/) segítségével érheti el. Az [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) gyűjteménye a diagramhoz tartozó alakzatokat tartalmazza.

Egy egyszerű szövegdoboz, amely egy diagram fölé van helyezve, a diára tartozik, még ha úgy néz is ki, mintha a diagram része lenne. A [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) bejárása megtalálja a diagramot és a szokásos diaképeket, de nem sorolja fel a diagramon belüli egyedi alakzatokat. A diagramcímek és adattulajdonság‑címkék külön diagramelemek, nem egyéni annotációk ebben a gyűjteményben.

Töltse le a [chart-annotations.pptx](chart-annotations.pptx) fájlt, és helyezze az alkalmazás munkakönyvtárába. Az első dián egy diagram található egy csoportosítatlan annotációval, amely a „Preliminary results” feliratot, egy diagramhoz tartozó vonalat és egy egyszerű diaszövegdobozt tartalmaz, amely a „Slide overlay” feliratot jeleníti meg. A példa megtalálja az első diagramot azon a dián, és a jelentés publikálásra készülésekor a „Final results” szövegre módosítja az annotációt. Ellenőrzi, hogy a gyűjtemény nem üres, és csak egy [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) alakzatot szerkeszt, amelynél a [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) nem `None`, és a várt szöveget tartalmazza.

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

A vonal és a diaszövegdoboz változatlan marad. Az alábbi képek a bemeneti és a mentett, újra megnyitott eredményt mutatják:

| Szerkesztés előtt | Szerkesztés után |
| --- | --- |
| ![Diagram annotáció, amely a „Preliminary results” szöveget tartalmazza](chart-annotations-before.png) | ![Diagram annotáció, amely a „Final results” szöveget tartalmazza](chart-annotations-after.png) |

{{% alert color="info" title="Megjegyzés" %}}
A példa csak a felső szintű, diagramhoz tartozó alakzatokat vizsgálja. Ha egy annotáció egy [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) belsejében van, akkor a csoport [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) gyűjteményét is ellenőrizni kell. Ezt rekurzívan kell végrehajtani a beágyazott csoportok esetén, a gyermekalakzatokra is alkalmazva ugyanazt a szöveg‑ellenőrzést. A csoport maga egy tároló; ne kezelje szövegdobozként.
{{% /alert %}}

## **GYIK**

**Beállíthatok félig áttetsző kitöltéseket oszlopoknak/területeknek, miközben a szegély átlátszatlan marad?**

Igen. A kitöltés átlátszósága és a körvonal külön-külön konfigurálható. Ez hasznos a rács és az adatok olvashatóságának javításához sűrű vizualizációkban.

**Hogyan kezeljem az adatcímkéket, ha átfedik egymást?**

Csökkentse a betűméretet, tiltsa le a nem lényeges címkeelemeket (például a kategóriákat), állítsa be a címke pozícióját, szükség esetén csak a kiválasztott pontok címkéit jelenítse meg, vagy váltson „érték + jelmagyarázat” formátumra.

**Alkalmazhatok-e gradient vagy minta kitöltéseket sorozatokra?**

Igen. A sorozatok támogatják a szilárd, gradient és minta kitöltéseket. Gyakorlatban használjon gradientokat mértékkel, és kerülje az olyan kombinációkat, amelyek csökkentik a kontrasztot a rács és a szöveg között.