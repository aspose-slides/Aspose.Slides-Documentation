---
title: Diagramok formázása prezentációkban Python segítségével
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
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg a diagramok formázását az Aspose.Slides for Python segítségével .NET környezetben, és emelje elő PowerPoint vagy OpenDocument prezentációját professzionális, szemrevaló stílussal."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázhatók diagramok PowerPoint‑prezentációkban az Aspose.Slides használatával. Megmutatja, hogyan testreszabhatók a diagram fontos elemei, például a tengelyek, rácsvonalak, címek, jelmagyarázatok, a diagramterület és a falak kitöltései a diagram adatok megjelenésének és olvashatóságának javítása érdekében.

Az is bemutatásra kerül, hogyan állíthatók be a diagram szövegének betűtípus‑tulajdonságai, hogyan alkalmazhatók előre definiált és egyéni számformátumok a diagram adatokra, és hogyan engedélyezhetők a lekerekített sarkok a diagramterületen. Ezek a példák együtt azt mutatják, hogyan szabályozhatók a diagramok vizuális stílusa és adatmegjelenítése egy prezentációban.

## **Diagramelemek formázása**

Az Aspose.Slides for Python lehetővé teszi a fejlesztők számára, hogy saját diagramokat adjanak a diákhoz a semmiből. Ez a szakasz bemutatja, hogyan formázhatók a különféle diagramelemek, beleértve a kategória‑ és értéktengelyeket.

Aspose.Slides egyszerű API‑t biztosít a diagramelemek kezeléséhez és egyéni formázások alkalmazásához:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást a diára az indexe alapján.
1. Adjon hozzá egy diagramot a kívánt típusú alapértelmezett adatokkal (ebben a példában `ChartType.LINE_WITH_MARKERS`).
1. Hozzáférés a diagram értéktengelyéhez, és a következők beállítása:
   1. Állítsa be a **vonalformátumot** az értéktengely fő rácsvonalaira.
   1. Állítsa be a **vonalformátumot** az értéktengely segéd rácsvonalaira.
   1. Állítsa be a **számformátumot** az értéktengelyhez.
   1. Állítsa be a **minimum, maximum, fő és segéd egységeket** az értéktengelyhez.
   1. Állítsa be a **szövegtulajdonságokat** az értéktengely címkéihez.
   1. Állítsa be az **címet** az értéktengelyhez.
   1. Állítsa be a **vonalformátumot** az értéktengelyhez.
1. Hozzáférés a diagram kategóriatengelyéhez, és a következők beállítása:
   1. Állítsa be a **vonalformátumot** a kategóriatengely fő rácsvonalaira.
   1. Állítsa be a **vonalformátumot** a kategóriatengely segéd rácsvonalaira.
   1. Állítsa be a **szövegtulajdonságokat** a kategóriatengely címkéihez.
   1. Állítsa be az **címet** a kategóriatengelyhez.
   1. Állítsa be a **címke elhelyezését** a kategóriatengelyen.
   1. Állítsa be a **forgásszöget** a kategóriatengely címkéire.
1. Hozzáférés a diagram jelmagyarázatához, és állítsa be a **szövegtulajdonságait**.
1. A diagram jelmagyarázatának megjelenítése anélkül, hogy átfedné a diagramot.
1. Hozzáférés a diagram **másodlagos értéktengelyéhez**, és a következők beállítása:
   1. Engedélyezze a másodlagos **értéktengelyt**.
   1. Állítsa be a **vonalformátumot** a másodlagos értéktengelyhez.
   1. Állítsa be a **számformátumot** a másodlagos értéktengelyhez.
   1. Állítsa be a **minimum, maximum, fő és segéd egységeket** a másodlagos értéktengelyhez.
1. Ábrázolja az első diagram sorozatot a másodlagos értéktengelyen.
1. Állítsa be a diagram hátfalának kitöltőszínét.
1. Állítsa be a diagram diagramterületének kitöltőszínét.
1. Írja a módosított prezentációt egy PPTX fájlba.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Példányosítsa a Presentation osztályt.
with slides.Presentation() as presentation:

    # Érje el az első diát.
    slide = presentation.slides[0]

    # Adjon hozzá egy minta diagramot.
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # Állítsa be a diagram címét.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = 1
    chart_title.portion_format.font_italic = 1

    # Állítsa be az értéktengely fő rácsvonalának formátumát.
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # Állítsa be az értéktengely segéd rácsvonalának formátumát.
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # Állítsa be az értéktengely számformátumát.
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # Állítsa be az értéktengely maximumát, minimumát, fő és segéd egységét.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # Állítsa be az értéktengely szövegtulajdonságait.
    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = 1
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = 1
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    vertical_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    # Állítsa be az értéktengely címét.
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = 1
    vertical_axis_title.portion_format.font_italic = 1

    # Állítsa be a kategóriatengely fő rácsvonalának formátumát.
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # Állítsa be a kategóriatengely segéd rácsvonalának formátumát.
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # Állítsa be a kategóriatengely szövegtulajdonságait.
    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = 1
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = 1
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    # Állítsa be a kategóriatengely címét.
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = 1
    horizontal_axis_title.portion_format.font_italic = 1

    # Állítsa be a kategóriatengely címke pozícióját.
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # Állítsa be a kategóriatengely címke forgatási szögét.
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # Állítsa be a jelmagyarázat szövegtulajdonságait.
    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = 1
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = 1
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

    # Jelenítse meg a diagram jelmagyarázatát átfedve a diagramot.
    chart.legend.overlay = True
                
    # Állítsa be a diagram hátfal színét.
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red

    # Állítsa be a diagram ábrázolási terület színét.
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # Mentse a prezentációt.
    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Diagram betűtípus‑tulajdonságok beállítása**

Az Aspose.Slides for Python támogatja a diagramok betűtípus‑kapcsolódó tulajdonságainak beállítását. Kövesse az alábbi lépéseket a diagram betűtípus‑tulajdonságainak konfigurálásához:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektumot.
1. Adjon hozzá egy diagramot a diára.
1. Állítsa be a betű magasságát.
1. Mentse a módosított prezentációt.

Az alábbiakban egy példakód található.

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

## **Számformátum beállítása**

Az Aspose.Slides for Python egyszerű API‑t biztosít a diagram adatformátumok kezeléséhez:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást a diára az indexe alapján.
1. Adjon hozzá egy diagramot bármilyen kívánt típusú alapértelmezett adatokkal.
1. Állítson be egy előre definiált számformátumot a rendelkezésre álló előre definiált értékek közül.
1. A diagram adatcelláit minden sorozatban bejárva állítsa be a számformátumot.
1. Mentse a prezentációt.
1. Állítson be egy egyéni számformátumot.
1. A diagram adatcelláit minden sorozatban bejárva állítsa be egy másik számformátumot.
1. Mentse a prezentációt.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Példányosítsa a Presentation osztályt.
with slides.Presentation() as presentation:
    # Érje el az első diát.
    slide = presentation.slides[0]

    # Adjon hozzá egy alapértelmezett csoportos oszlop diagramot.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # Állítsa be az előre definiált számformátumot.
    # Bejárja a diagram sorozatait.
    for series in chart.chart_data.series:
        # Bejárja a sorozat adatpontjait.
        for cell in series.data_points:
            # Állítsa be a számformátumot.
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # Mentse a prezentációt.
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

Az elérhető előre definiált számformátumok és a hozzájuk tartozó indexek az alábbiakban találhatók.

|**0**|Általános|
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

## **Lekerekített szegélyek beállítása a diagramterületen**

Az Aspose.Slides for Python támogatja a diagramterület konfigurálását a `Chart.has_rounded_corners` tulajdonság használatával.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektumot.
2. Adjon hozzá egy diagramot a diára.
3. Állítsa be a diagram kitöltésének típusát és színét.
4. Állítsa a lekerekített-sarkok tulajdonságot `True`‑ra.
5. Mentse a módosított prezentációt.

Az alábbiakban egy példa található.

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

## **GYIK**

**Beállíthatok félig átlátszó kitöltést oszlopoknak/területeknek, miközben a szegély átlátszatlan marad?**  
Igen. A kitöltés átlátszósága és a körvonal külön-külön állítható be. Ez hasznos a rács és az adatok olvashatóságának javításához sűrű vizualizációk esetén.

**Hogyan kezeljem az adatcímkéket, ha átfedik egymást?**  
Csökkentse a betűméretet, tiltsa le a nem létfontosságú címkeelemeket (például a kategóriákat), állítsa be a címke eltolását/pozícióját, szükség esetén csak a kiválasztott pontok címkéit jelenítse meg, vagy cserélje a formátumot „érték + jelmagyarázat” formára.

**Alkalmazhatok színátmenetes vagy mintázott kitöltést sorozatokra?**  
Igen. A tömör és a színátmenetes/mintázott kitöltések is általában elérhetők. Gyakorlatban használjon színátmeneteket mértékkel, és kerülje azokat a kombinációkat, amelyek csökkentik a kontrasztot a rács és a szöveg között.