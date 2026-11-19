---
title: 3D diagramok testreszabása prezentációkban Python segítségével
linktitle: 3D diagram
type: docs
url: /hu/python-net/3d-chart/
keywords:
- 3D diagram
- forgatás
- mélység
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Hozzon létre 3D diagramokat PowerPoint prezentációkban az Aspose.Slides for Python via .NET segítségével. Állítsa be a forgatást, a magasságarányokat, a diagram mélységét és a sorozatok közötti távolságot Python példákkal."
---
## **Áttekintés**

Az Aspose.Slides for Python via .NET lehetővé teszi, hogy testreszabja egy 3D diagram nézetét a [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/) tulajdonság segítségével. Ez a cikk bemutatja, hogyan állítható be a forgatás, a magasságarányok, a mélység, a derékszögű tengelyek és a sorok közötti távolság, majd hogyan menthető a bemutató PPTX formátumban.

## **Állítsa be egy 3D diagram forgatását és mélységét**

Az alábbi példa létrehoz egy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) és a [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) segítségével hozzáad egy rétegezett 3D oszlopdiagramot az első diájához. Lecseréli az alapértelmezett sorozatokat és kategóriákat két sorozatra, melyek mindegyike három értéket tartalmaz. A `0` munkalap-index a diagram első adatmunkalapját jelöli; a `0` sor a sorozatneveket, a `0` oszlop pedig a kategóriacímkéket tartalmazza.

A [rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) és a [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) tulajdonságok a diagram forgatását 40 illetve 270 fokra állítják. A [depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) a szélesség 150%-ára állítja a mélységet, míg a [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) a perspektíva helyett derékszögű tengelyeket engedélyezi. Az eredményül kapott bemutató a feltöltött diagramot tartalmazza ezekkel a 3D nézeti beállításokkal.

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

## **Állítsa be egy 3D diagram magasságarányait**

Használja a [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) tulajdonságot a 3D diagram magasságának a szélesség százalékaként történő beállításához. Ez a 3D jelenet arányait változtatja anélkül, hogy átméretezné a diagram objektumot a dián.

A következő példa a [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) diagramot hozza létre az alapértelmezett adatokkal: három sorozat és négy kategória. Három bemutatót ment 50 %, 100 % és 200 % magasságarányokkal. A diagram pozíciója, szélessége és magassága változatlan marad. Az adatok, a forgatás, a mélység, a sorok közti távolság és a formázás minden három fájlban azonos; csak a magasság százalékos értéke változik.

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

Az alábbi képek a generált bemutatókból a Microsoft PowerPoint segítségével exportálták. A kisebb százalék laposabb jelenetet eredményez, míg a nagyobb százalék magasabb jelenetet ugyanazon diagramobjektumban. A PowerPoint a jelenethez igazodva módosíthatja a tengelyek jelölő-intervaleit és a címkék elhelyezését is.

| Magasság: 50% | Magasság: 100% | Magasság: 200% |
| --- | --- | --- |
| ![3D oszlopdiagram, amelynek magassága a szélesség 50%-a](height_percent_50.png) | ![3D oszlopdiagram, amelynek magassága a szélesség 100%-a](height_percent_100.png) | ![3D oszlopdiagram, amelynek magassága a szélesség 200%-a](height_percent_200.png) |

Ezek a tulajdonságok a diagram különböző aspektusait szabályozzák:

| Tulajdonság | Hatás |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | A 3D jelenet magassága a szélességének százalékában. |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | A diagram objektum magassága a dián, pontokban. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | A 3D jelenet mélysége a szélességének százalékában. |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | A sorozatok közti távolság a mélységi tengelyen, a jelölő szélességének százalékában. |

A magasságbeállítás a 3D oszlop- és sávdiagramokra vonatkozik, beleértve a henger, kúp és piramis változatokat, valamint a 3D vonal-, terület-, kör- és felületdiagramokra. A fenti összehasonlítás a hitelesített `COLUMN_3D` típust használja. A beállítás nem változtatja meg egy 2D `CLUSTERED_COLUMN` vagy egy `BUBBLE_WITH_3D` diagram megjelenését; ezek a nevei a [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) felsorolásának elemei. A diagram egyéb megjelenésbeállításaiért lásd a [Chart Formatting](/slides/hu/python-net/chart-formatting/) oldalt.

## **A sorok közötti hézag állítása**

Használja a [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) tulajdonságot a 3D diagram adatsorai közötti távolság szabályozására a mélységi tengely mentén, a jelölő szélességének százalékában kifejezve. Az értékek **0‑tól 500‑ig** terjednek, beleértve a határokat: a `0` eltávolítja a hézagot, míg a nagyobb értékek növelik a távolságot. Rögzített diagrammélységgel a hézag növelése a jelölőket vékonyabbá teszi a mélységi tengelyen.

A csoportot a [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) segítségével érheti el. A beállítás a csoport minden sorozatára érvényes, nem csak arra, amelyen keresztül elérte. A [ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) csak olvasható, és a szülőcsoport beállítását tükrözi.

Ez a beállítás a 3D oszlop- és sávdiagramokra, beleértve a henger, kúp és piramis változatokat, valamint a 3D vonal‑ és területdiagramokra vonatkozik. A megjelenés attól függ, hogy a sorozatok mélységben vannak-e elrendezve, csoportosítottak vagy rétegezettek. A sorok közti hézagok egyértelmű összehasonlításához használja a `ChartType.COLUMN_3D` típust a [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) felsorolásból.

Ezek a tulajdonságok a diagram különböző aspektusait szabályozzák:

| Tulajdonság | Hatás |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | A sorozatok közti távolság a mélységi tengelyen, a jelölő szélességének százalékában. |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | A szomszédos oszlop‑ vagy sávcsoportok közti távolság, a sáv vagy oszlop szélességének százalékában. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | A diagram teljes mélysége, a diagram szélességének százalékában. |

Az alábbi önmagában álló példa az alapértelmezett diagramadatokat használja, amelyek három sorozatot és négy kategóriát tartalmaznak. Két bemutatót ment azonos adatokkal, forgatással, hézag‑szélességgel és diagrammélységgel; csak a hézag‑mélység változik.

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

Az alábbi képek a generált bemutatókból a Microsoft PowerPoint segítségével exportálták.

| Hézag‑mélység: 0% | Hézag‑mélység: 500% |
| --- | --- |
| ![3D oszlopdiagram, amelynek a sorozatok között nincs hézag a mélységi tengelyen](gap_depth_0.png) | ![3D oszlopdiagram, amelynek a sorozatok között 500 % hézag van a mélységi tengelyen](gap_depth_500.png) |

## **A 3D sorozattípus és az oszlop alakjának módosítása**

Egy csoportosított hengerdiagram első sorozata henger alakú oszlopokkal kezdődik. A példa a [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) és a [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/) értékét olvassa a módosítások előtt és után.

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

| Változtatás az első sorozaton | `type` | `bar_3d_shape` |
| --- | --- | --- |
| Diagram létrehozása | `CLUSTERED_CYLINDER` | `CYLINDER` |
| `type` beállítása `CLUSTERED_CONE`‑ra | `CLUSTERED_CONE` | `CONE` |
| `bar_3d_shape` beállítása `BOX`‑ra | `CLUSTERED_COLUMN_3D` | `BOX` |

A `BOX` alakra való beállítás a sorozattípust is `CLUSTERED_COLUMN_3D`‑re változtatja. Ha a kód a sorozattípus alapján ágakat hoz létre, a forma módosítása után olvassa a `series.type` értékét. A hozzárendelés előtt tárolt érték továbbra is a `CLUSTERED_CONE` ágat választaná.

![PowerPoint összehasonlítás, amely balról jobbra mutatja az első sorozatot henger, kúp és téglalap alakú oszlopokként](series-shapes.png)

## **GYIK**

**Mely diagramtípusok támogatják a 3D módot az Aspose.Slides‑ban?**

Az Aspose.Slides támogatja a 3D változatokat az oszlopdiagramoknál, beleértve a Column 3D, Clustered Column 3D, Stacked Column 3D és 100 % Stacked Column 3D diagramokat, valamint a kapcsolódó 3D típusokat, amelyeket a [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) felsorolás tartalmaz. A pontos, naprakész listaért tekintse meg a [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) elemeit az Ön által telepített verzió API‑referenciájában.

**Kaphatok raszteres képet egy 3D diagramról jelentéshez vagy a webhez?**

Igen. Exportálhat egy diagramot képként a [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) vagy a [teljes dia renderelése](/slides/hu/python-net/convert-powerpoint-to-png/) segítségével PNG vagy JPEG formátumba. Ez hasznos, ha raszteres előnézetre van szükség, vagy a diagramot dokumentumokba, műszerfalakba vagy weboldalakba szeretné beágyazni PowerPoint nélkül.

**Milyen teljesítményű a nagy 3D diagramok építése és renderelése?**

A teljesítmény az adatmérettől és a vizuális összetettségtől függ. A legjobb eredmény érdekében tartsa minimális szinten a 3D‑effekteket, kerüljön el nehéz textúrákat a falakon és a diagramterületen, korlátozza sorozatonként az adatpontok számát, ha lehetséges, és rendereljen megfelelő méretű kimenetre (felbontás és méretek) a célmegjelenítő vagy nyomtatási igényekhez.