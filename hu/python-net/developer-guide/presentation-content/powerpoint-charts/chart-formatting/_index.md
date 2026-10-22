---
title: Diagramok formázása prezentációkban Python használatával
linktitle: Diagram formázás
type: docs
weight: 60
url: /hu/python-net/chart-formatting/
keywords:
- diagram formázása
- diagram formázás
- diagram elem
- diagram tulajdonságok
- diagram beállítások
- diagram opciók
- betűtípus tulajdonságok
- lekerekített szegély
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg a diagramok formázását az Aspose.Slides Python számára .NET-en keresztül, és emelje fel PowerPoint prezentációját egyedi tengelyekkel, betűtípusokkal, számformátumokkal és lekerekített diagramszegélyekkel."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet diagramokat formázni PowerPoint‑prezentációkban az Aspose.Slides használatával. Megmutatja, hogyan lehet testreszabni a diagram fontos elemeit, például a tengelyeket, rácsvonalakat, címeket, jelmagyarázatokat, a diagramterületet és a falak kitöltését, hogy javítsa a diagram adatok megjelenését és olvashatóságát.

Az is bemutatja, hogyan lehet a diagram szövegeihez betűtípus‑tulajdonságokat beállítani, előre definiált számformátumokat alkalmazni a diagram adataira, valamint lekerekített sarkokat engedélyezni a diagramterületen. Együtt ezek a példák azt mutatják, hogyan lehet a diagramok vizuális stílusát és adatmegjelenítését egyaránt szabályozni a prezentációban.

## **Diagramelemek formázása**

Használja a [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) elemet a diagramcímek, tengelyek, rácsvonalak, jelmagyarázatok és a diagramterület formázásához. Ez a példa egy jelölőkkel ellátott vonaldiagramot hoz létre alapértelmezett adatokkal, majd külön szöveg‑ és vonalstílusokat alkalmaz az értéktengelyen és a kategóriatengelyen. A betűméreteket és vonalszélességet pontban adja meg; a kategóriacímkék 45‑ fokban vannak elfordítva.

Az értéktengely a [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) használatát a forráscelláktól függetlenül végzi. Skálája -2‑tól 15‑ig terjed, nagytávolságok 2, kistávolságok 0,5. A példa a százalékos formázást kombinálja a [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) ezredes beállításával, ezért a beállításokat az adatok jelentéséhez és nagyságához igazítsa. A jelmagyarázat a diagramterület kívül marad, mivel a [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) le van tiltva. A háttérfal és a padló kitöltései a [back_wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) és a [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/) segítségével vannak beállítva, de ezek a felületek csak 3D diagramokban láthatók.

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

## **Diagram betűtulajdonságainak beállítása**

Állítsa be a diagram szövegének alapértelmezett betűméretét a [Chart.text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/text_format/) segítségével. A példa egy csoportosított oszlopdiagramot hoz létre 20‑pontos betűmérettel, és az első sorozathoz a [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) segítségével engedélyezi az értékcímkéket. A saját, explicit betűtípus‑beállításokkal rendelkező szövegelemek felülbírrhatják a diagram alapértelmezését.

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

## **A numerikus formátum beállítása**

Használja a [ChartDataCell.preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) elemet, hogy beépített számformátumot alkalmazzon a diagram munkafüzet celláira. Ez a példa egy alapértelmezett, cella‑alapú adatokkal rendelkező csoportosított oszlopdiagramot hoz létre, és a formátumindexet 10 (`0.00%`) alkalmazza minden sorozat értékcellájára. Ez megváltoztatja, hogy a számok hogyan jelennek meg a munkafüzetben, anélkül hogy a valós értékek módosulnának; például a 0,25 25,00 %-ként jelenik meg. A tengely‑ és adatcímke‑formátumok külön‑külön konfigurálhatók.

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

Az alábbi táblázat felsorolja a beépített számformátum‑indexeket a megfelelő Excel‑formátumokkal az angol (Egyesült Államok) nyelvi beállításhoz. A pontos formátumkarakterláncok és megjelenítésük alkalmazásonként és nyelv szerint változhat, különösen a pénznemek és dátumok esetén. Néhány Excel‑formátum eltér az OOXML szabvány alapértelmezett beállításaitól, ahogyan azt a [Microsoft számformátum-implementációs jegyzeteiben](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) leírják.

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

## **Diagramterület lekerekített szegélyeinek beállítása**

Engedélyezze a [Chart.has_rounded_corners](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_rounded_corners/) beállítást, hogy lekerekítse a diagramterület sarkait. A példa egy csoportosított oszlopdiagramot hoz létre, és a [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) segítségével szilárd szürke színt és egyszerű vonalstílust ad a körvonalnak a prezentáció mentése előtt.

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

## **Meglévő diagramannotációk szerkesztése**

Egy diagram egyedi alakzatokat tartalmazhat, például egy szöveges annotációt, amely a jelentés állapotát magyarázza. Ezekhez az alakzatokhoz a [Chart.user_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/user_shapes/) segítségével férhet hozzá. A [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) gyűjteménye a diagramhoz tartozó alakzatokat tartalmazza.

Egy diagram felett elhelyezett szokványos szövegdoboz a diára tartozik, még ha úgy is néz ki, mintha a diagram része lenne. A [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) bejárása megtalálja a diagramot és a szokványos diaelemeket, de nem sorolja fel a diagramon belüli egyedi alakzatokat. A diagramcímek és adatcímkék külön diagramelemek, nem egyedi annotációk ebben a gyűjteményben.

Töltse le a [chart-annotations.pptx](chart-annotations.pptx) fájlt, és helyezze el az alkalmazás munkakönyvtárában. Első diája egy diagramot tartalmaz, amely egy csoportosítatlan annotációt „Preliminary results”, egy diagramhoz tartozó vonalat és egy szokványos dia szövegdobozt „Slide overlay” felirattal tartalmaz. A példa megtalálja az első diagramot ezen a dián, és a jelentés közzétételére készülve a annotációt „Final results” szövegre módosítja. Ellenőrzi, hogy a gyűjtemény nem üres, és csak egy [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) elemet szerkeszt, amelynek [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) nem `None`, és a várt szöveget tartalmazza.

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

A vonal és a dia szövegdoboz változatlan marad. Az alábbi képek mutatják a bemenetet és a mentett, újra megnyitott eredményt:

| Szerkesztés előtt | Szerkesztés után |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
A példa csak a legfelső szintű, diagramhoz tartozó alakzatokat vizsgálja. Ha egy annotáció egy [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) belsejében van, akkor azt a csoport [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) gyűjteményét is ellenőrizze. Ismételje meg rekurzívan a beágyazott csoportoknál, ugyanazokat a szövegellenőrzéseket alkalmazva a gyermekalakzatokra. Magát a csoportot egy tárolónak tekintse; ne kezelje szövegdobozként.
{{% /alert %}}

## **GYIK**

**Beállíthatok félig áttetsző kitöltéseket oszlopoknak/területeknek, miközben a szegély átlátszatlan marad?**

Igen. A kitöltés átlátszósága és a körvonal külön‑külön konfigurálható. Ez hasznos a rács és az adatok olvashatóságának javításához sűrű vizualizációkban.

**Hogyan kezelhetem az adatcímkéket, amikor átfedik egymást?**

Csökkentse a betűméretet, tiltsa le a nem lényeges címkeelemeket (például a kategóriákat), állítsa be a címke helyzetét, ha szükséges, csak a kiválasztott pontokhoz jelenítse meg a címkéket, vagy váltson a „érték + jelmagyarázat” formátumra.

**Alkalmazhatok színátmenetes vagy mintás kitöltéseket sorozatokra?**

Igen. A sorozatok támogatják a szilárd, színátmenetes és mintás kitöltéseket. Gyakorlatban használjon színátmeneteket takarékosan, és kerülje az olyan kombinációkat, amelyek csökkentik a kontrasztot a rácssal és a szöveggel.