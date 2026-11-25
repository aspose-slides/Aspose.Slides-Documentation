---
title: 3D diagramok testreszabása prezentációkban Python használatával
linktitle: 3D diagram
type: docs
url: /hu/python-net/3d-chart/
keywords:
- 3D diagram
- forgás
- mélység
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "3D diagramokat hozhat létre PowerPoint prezentációkban az Aspose.Slides for Python via .NET segítségével. Állítsa be a forgást, a magasság arányait, a diagram mélységét és a sorozatok közti távolságot Python példákkal."
---
## **Áttekintés**

Az Aspose.Slides for Python via .NET lehetővé teszi, hogy a 3D diagram nézetét a [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/) tulajdonság segítségével testre szabja. Ez a cikk bemutatja, hogyan állítható be a forgatás, a magasság arányok, a mélység, a derékszögű tengelyek és a sorok közötti távolság, majd hogyan menthető a prezentáció PPTX formátumban.

## **A 3D diagram forgatásának és mélységének beállítása**

Az alábbi példa egy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) objektumot hoz létre, és a [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) segítségével hozzáad egy rétegezett 3D oszlopdiagramot az első diahoz. Lecseréli az alapértelmezett sorozatokat és kategóriákat két, három értékkel rendelkező sorozatra. A munkalap index `0` a diagram első adatmunkalapját jelöli; a `0` sor a sorozatneveket, az `0` oszlop pedig a kategóriacímkéket tartalmazza.

A [rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) és a [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) tulajdonságok beállítják a diagram forgását 40 illetve 270 fokra. A [depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) a mélységet a szélesség 150%-ára állítja, míg a [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) derékszögű tengelyeket engedélyez perspektíva helyett. A kapott prezentáció tartalmazza a kitöltött diagramot ezekkel a 3D nézeti beállításokkal.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    
    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.get_cell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.chart_data.categories.add(category_cell)

    for series_index in range(2):
        series_cell = workbook.get_cell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.chart_data.series.add(series_cell, chart.type)

        for category_index in range(3):
            value_cell = workbook.get_cell(worksheet_index, category_index + 1, series_index + 1, values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Képpel kitöltés alkalmazása egy 3D diagram felületére**

A 3D diagram [oldalfal](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/side_wall/), [hátfal](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/), és [padló](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/) felületét külön-külön töltheti ki. Állítsa a felület [fill type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) értékét `PICTURE`-ra, és rendelje hozzá a képet. Ahhoz, hogy a kép egy példánya illeszkedjen a felületre, állítsa mind a [picture fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) és a felület [picture type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartwall/picture_type/) értékét `STRETCH`-re.

Mentse az [arrow.png](arrow.png) fájlt a munkakönyvtárba. A példa elforgatja a diagramot, és a függőleges tengelyen a maximális értéket megemeli, hogy a padló látható legyen az oszlopok között. A diát kétszer klónozza, majd minden diához egy másik felületre alkalmazza a nyilat. A három diagram ugyanazt az adatot, nézetet és háttérszínt használja.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 20, 30, 680, 480)
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 30
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 24

    back_slide = presentation.slides.add_clone(slide)
    floor_slide = presentation.slides.add_clone(slide)
    back_chart = back_slide.shapes[0]
    floor_chart = floor_slide.shapes[0]

    with open("arrow.png", "rb") as image_file:
        image_bytes = image_file.read()
    arrow = presentation.images.add_image(image_bytes)

    for surface in (chart.side_wall, back_chart.back_wall, floor_chart.floor):
        fill = surface.format.fill
        fill.fill_type = slides.FillType.PICTURE
        fill.picture_fill_format.picture.image = arrow
        fill.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        surface.picture_type = charts.PictureType.STRETCH

    presentation.save("chart-surfaces.pptx", slides.export.SaveFormat.PPTX)
```

A Microsoft PowerPoint a három diát a következőképpen jeleníti meg.

| Oldalfal | Hátfal | Padló |
| --- | --- | --- |
| ![Nyíl, amely a diagramra mutat az oldalfal mentén](side-wall.png) | ![Nyíl, amely jobbra mutat a hátfalon](back-wall.png) | ![Nyíl, amely jobbra mutat a padlón az oszlopok között](floor.png) |

## **3D diagram magasság arányainak beállítása**

Használja a [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) metódust a 3D diagram magasságának a szélességéhez viszonyított százalékos beállításához. Ez a 3D jelenet arányait módosítja anélkül, hogy átméretezné a diagram objektumot a dián.

Az alábbi példa egy [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) diagramot hoz létre az alapértelmezett adatokkal: három sorozat és négy kategória. Három prezentációt ment 50%, 100% és 200% magasság arányokkal. A diagram pozíciója, szélessége és magassága változatlan marad. Az adatok, a forgatás, a mélység, a sorozatok közti távolság és a formázás minden három fájlban azonos; csak a magasság százaléka változik.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 460)
    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.depth_percents = 100
    chart.chart_data.series[0].parent_series_group.gap_depth = 150

    for height_percent in (50, 100, 200):
        chart.rotation_3d.height_percents = height_percent
        presentation.save(f"chart_height_{height_percent}.pptx", slides.export.SaveFormat.PPTX)
```

Az alábbi képeket a generált prezentációkból a Microsoft PowerPoint segítségével exportálták. A kisebb százalék laposabb jelenetet eredményez, míg a nagyobb százalék magasabb jelenetet hoz létre ugyanabban a diagramobjektumban. A PowerPoint az tengelyjelölések intervallumát és a címkék elhelyezését is módosíthatja a jelenethez igazítva.

| Magasság: 50% | Magasság: 100% | Magasság: 200% |
| --- | --- | --- |
| ![3D oszlopdiagram, amelynek magassága a szélesség 50%-a](height_percent_50.png) | ![3D oszlopdiagram, amelynek magassága a szélesség 100%-a](height_percent_100.png) | ![3D oszlopdiagram, amelynek magassága a szélesség 200%-a](height_percent_200.png) |

Ezek a tulajdonságok a diagram különböző aspektusait szabályozzák:

| Tulajdonság | Hatás |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | A 3D jelenet magassága a szélességének százalékában. |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | A diagram objektum magassága a dián, pontban. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | A 3D jelenet mélysége a szélesség százalékában. |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | A sorozatok közti távolság a mélységi tengely mentén, a jelölő szélességének százalékában. |

A magasság beállítás befolyásolja a 3D oszlop- és oszlopdiagramokat, beleértve a henger, kúp és piramis változatokat, valamint a 3D vonal-, terület-, kör- és felületi diagramokat. A fenti összehasonlítás a hitelesített `COLUMN_3D` típust használja. A beállítás nem változtatja meg a 2D `CLUSTERED_COLUMN` diagram vagy a `BUBBLE_WITH_3D` diagram megjelenését; ezek a nevek a [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) felsorolás tagjai. Az egyéb diagram megjelenítési beállításokért tekintse meg a [Chart Formatting](/slides/hu/python-net/chart-formatting/) oldalt.

## **A sorozatok közti rés beállítása**

Használja a [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) metódust a 3D diagram adatcsorozatai közötti távolság szabályozására a mélységi tengelyen, a jelölő szélességének százalékában kifejezve. Az értékek **0 és 500** között választhatók, beleértve: `0` eltávolítja a részt, míg a nagyobb értékek növelik a távolságot. Rögzített diagrammélység esetén a rés növelése vékonyabbá teszi a jelölőket a mélységi tengelyen.

A csoportot a [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) útján érheti el. A beállítás az adott csoport minden sorozatára érvényes, nem csak arra a sorozatra, amelyen keresztül elérte. A [ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) csak olvasható, és a szülőcsoport beállítását tükrözi.

Ez a beállítás a 3D oszlop- és oszlopdiagramokat, beleértve a henger, kúp és piramis változatokat, valamint a 3D vonal- és területdiagramokat befolyásolja. A megjelenés attól függ, hogy a sorozatok mélységben, csoportosítva vagy rétegezve legyenek. Az egyes sorozatok közti rés tiszta összehasonlításához használja a `ChartType.COLUMN_3D` típust a [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) felsorolásból.

Ezek a tulajdonságok a diagram különböző aspektusait szabályozzák:

| Tulajdonság | Hatás |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | A sorozatok közti távolság a mélységi tengely mentén, a jelölő szélességének százalékában. |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | A szomszédos oszlop vagy oszlopcsoportok közti távolság, a sáv vagy oszlop szélességének százalékában. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | A diagram mélysége a diagram szélességének százalékában. |

Az alábbi önálló példa az alapértelmezett diagramadatokat használja, amelyek három sorozatot és négy kategóriát tartalmaznak. Két prezentációt ment azonos adatokkal, forgatással, rész szélességgel és diagrammélységgel; csak a rés mélysége változik.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 230)

    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.depth_percents = 100

    series = chart.chart_data.series[0]
    group = series.parent_series_group
    group.gap_width = 150

    for gap_depth in (0, 500):
        group.gap_depth = gap_depth
        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

Az alábbi képeket a generált prezentációkból a Microsoft PowerPoint segítségével exportálták.

| Répmélység: 0% | Répmélység: 500% |
| --- | --- |
| ![3D oszlopdiagram, amelynek nincs rés a sorozatok között a mélységi tengelyen](gap_depth_0.png) | ![3D oszlopdiagram, amelynek 500 százalékos rés van a sorozatok között a mélységi tengelyen](gap_depth_500.png) |

## **3D sorozattípus és sáv alakjának módosítása**

Egy csoportosított henger diagram első sorozata henger alakú sávokkal kezdődik. A példa a [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) és a [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/) értékeket olvassa ki minden változtatás előtt és után.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_CYLINDER, 20, 20, 500, 300)
    series = chart.chart_data.series[0]
    
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.type = charts.ChartType.CLUSTERED_CONE
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.bar_3d_shape = charts.ChartShapeType.BOX
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    presentation.save("series_shape.pptx", slides.export.SaveFormat.PPTX)
```

| Változtatás az első sorozaton | type | bar_3d_shape |
| --- | --- | --- |
| Diagram létrehozása | `CLUSTERED_CYLINDER` | `CYLINDER` |
| Állítsa a `type`-ot `CLUSTERED_CONE`-ra | `CLUSTERED_CONE` | `CONE` |
| Állítsa a `bar_3d_shape`-t `BOX`-ra | `CLUSTERED_COLUMN_3D` | `BOX` |

A `BOX` alak beállítása a sorozattípust is `CLUSTERED_COLUMN_3D`-re változtatja. Ha a kódja a sorozattípus szerint ágazik, akkor a forma módosítása után olvassa ki a `series.type` értéket. A hozzárendelés előtt tárolt érték továbbra is a `CLUSTERED_CONE` ágat választaná.

![PowerPoint összehasonlítás, amely az első sorozatot henger, kúp és téglalap alakú oszlopként mutatja balról jobbra](series-shapes.png)

## **GYIK**

**Mely diagramtípusok támogatják a 3D módot az Aspose.Slides-ban?**

Az Aspose.Slides a oszlopdiagramok 3D változatait támogatja, beleértve a Column 3D, Clustered Column 3D, Stacked Column 3D és a 100% Stacked Column 3D típusokat, valamint a kapcsolódó 3D típusokat, amelyek a [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) felsorolásban vannak. A pontos, naprakész lista megtekintéséhez ellenőrizze a [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) elemeit a telepített verzió API-referenciájában.

**Kaphatok raszterképet egy 3D diagramról jelentéshez vagy a webhez?**

Igen. A diagramot exportálhatja képként a [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) metódussal, vagy az [az egész dia renderelése](/slides/hu/python-net/convert-powerpoint-to-png/) segítségével PNG vagy JPEG formátumba. Ez akkor hasznos, ha raszter előnézetre van szüksége, vagy a diagramot dokumentumokba, irányítópultokba vagy weboldalakba szeretné beágyazni PowerPoint nélkül.

**Mennyire hatékony nagy 3D diagramok építése és renderelése?**

A teljesítmény az adatmérettől és a vizuális összetettségtől függ. A legjobb eredmény érdekében tartsa a 3D hatásokat minimális szinten, kerüljön el nehéz textúrákat a falakon és a grafikonterületen, korlátozza a sorozatonkénti adatpontok számát, amennyire csak lehetséges, és a kimenetet a célkijelzőhöz vagy nyomtatáshoz megfelelő felbontásra és méretre renderelje.