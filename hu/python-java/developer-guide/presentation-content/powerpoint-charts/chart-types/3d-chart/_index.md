---
title: 3D diagramok testreszabása prezentációkban Python segítségével
linktitle: 3D diagram
type: docs
url: /hu/python-java/3d-chart/
keywords:
- 3D diagram
- forgás
- mélység
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Hozzon létre 3D diagramokat PowerPoint prezentációkban az Aspose.Slides for Python via Java segítségével. Állítsa be a forgást, a magasság arányait, a diagram mélységét és a sorozatok közötti távolságot Python példákkal."
---
## **Áttekintés**

Aspose.Slides for Python via Java lehetővé teszi, hogy a 3D diagram nézetét a [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D) metódus segítségével testreszabja. Ez a cikk bemutatja, hogyan állítható be a forgatás, a magasság arányai, a mélység, a derékszögű tengelyek és a sorok közötti távolság, majd hogyan menthető a prezentáció PPTX formátumban.

## **A 3D diagram forgatásának és mélységének beállítása**

Az alábbi példa egy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) objektumot hoz létre, és a [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) segítségével egy csoportosított 3D oszlopdiagramot ad hozzá az első diájához. Lecseréli az alapértelmezett sorozatokat és kategóriákat két, három értéket tartalmazó sorozatra. A `0` munkalap-index a diagram első adatmunkalapját jelöli; a `0` sor a sorozatneveket, az `0` oszlop pedig a kategóriacímkéket tartalmazza.

A [setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) és a [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) metódusok a diagram forgását 40 és 270 fokra állítják. A [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) a mélységet a szélesség 150%-ára állítja, míg a [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) jobb-szögű tengelyeket engedélyez a perspektíva helyett. Az eredményül kapott prezentáció a kitöltött diagramot tartalmazza ezekkel a 3D nézeti beállításokkal.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.getCell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.getChartData().getCategories().add(category_cell)

    for series_index in range(2):
        series_cell = workbook.getCell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())

        for category_index in range(3):
            value_cell = workbook.getCell(worksheet_index, category_index + 1, series_index + 1, jpype.JDouble(values[series_index][category_index]))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **A 3D diagram magasságarányainak állítása**

A [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) használatával állítható be egy 3D diagram magassága a szélességének százalékában. Ez megváltoztatja a 3D jelenet arányait anélkül, hogy átméretezné a dián lévő diagram objektumot.

Az alábbi példában egy [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) diagramot hozunk létre az alapértelmezett adatokkal: három sorozattal és négy kategóriával. Három prezentációt ment három magasságarányban: 50%, 100% és 200%. A diagram pozíciója, szélessége és magassága változatlan marad. Az adatok, a forgatás, a mélység, a sorozatok közötti távolság és a formázás minden három fájlban azonos; csak a magasság százalékos értéke változik.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460)
    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setDepthPercents(100)
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150)

    for height_percent in [50, 100, 200]:
        chart.getRotation3D().setHeightPercents(height_percent)
        presentation.save(f"chart_height_{height_percent}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az alábbi képek bemutatják ugyanazokat a magasságbeállításokat a megfelelő .NET példában, és a Microsoft PowerPoint segítségével exportálták. A kisebb százalék laposabb jelenetet eredményez, míg a nagyobb százalék magasabb jelenetet a diagram objektumon belül. A PowerPoint módosíthatja a tengelyek jelölőit és a címkék elhelyezését is, hogy illeszkedjen a jelenethez.

| Magasság: 50% | Magasság: 100% | Magasság: 200% |
| --- | --- | --- |
| ![3D oszlopdiagram, amelynek magassága a szélességének 50 százalékára van beállítva](height_percent_50.png) | ![3D oszlopdiagram, amelynek magassága a szélességének 100 százalékára van beállítva](height_percent_100.png) | ![3D oszlopdiagram, amelynek magassága a szélességének 200 százalékára van beállítva](height_percent_200.png) |

Ezek a metódusok a diagram különböző aspektusait szabályozzák:

| Metódus | Hatás |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | A 3D jelenet magassága a szélességének százalékában. |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | A diagram objektum magassága a dián pontban. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | A 3D jelenet mélysége a szélességének százalékában. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | A sorozatok közötti távolság a mélységi tengely mentén, a jelölő szélességének százalékában. |

A magasságbeállítás hatással van a 3D oszlop- és sávdiagramokra, beleértve a henger-, kúp- és piramis változatokat, valamint a 3D vonal-, terület-, kör- és felületdiagramokra. A fenti összehasonlítás a hitelesített `Column3D` típust használja. A beállítás nem módosítja egy 2D `ClusteredColumn` diagram vagy egy `BubbleWith3D` diagram megjelenését; ezek a nevek a [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) osztály tagjai. A diagramok egyéb megjelenési beállításaiért lásd a [Chart Formatting](/slides/hu/python-java/chart-formatting/) oldalt.

## **A sorozatok közötti hézag állítása**

A [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) segítségével szabályozható az adat-sorozatok közötti távolság a 3D diagram mélységi tengelye mentén, a jelölő szélességének százalékában kifejezve. Használjon **0 és 500** közötti értékeket, beleértve: a `0` eltávolítja a hézagot, míg a nagyobb értékek növelik a távolságot. Ha a diagram mélysége rögzített, a hézag növelése a jelölőket vékonyabbá teszi a mélységi tengelyen.

A csoportot a [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) segítségével érheti el. A beállítás a csoport minden sorozatára vonatkozik, nem csak arra a sorozatra, amelyikhez hozzáfért. A [ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) visszaadja a mélységi hézagot, és tükrözi a szülőcsoport beállítását.

Ez a beállítás hatással van a 3D oszlop- és sávdiagramokra, beleértve azok henger-, kúp- és piramis változatait, valamint a 3D vonal- és területdiagramokra. A megjelenés attól függ, hogy a sorozatok mélységben, csoportosan vagy halmozottan vannak-e rendezve. A különálló sorozatok közötti hézagok egyértelmű összehasonlításához használja a `ChartType.Column3D` típust a [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) osztályból.

Ezek a metódusok a diagram különböző aspektusait szabályozzák:

| Metódus | Hatás |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | A sorozatok közötti távolság a mélységi tengely mentén, a jelölő szélességének százalékában. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | A szomszédos sáv- vagy oszlopcsoportok közötti távolság, a sáv vagy oszlop szélességének százalékában. |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | A diagram teljes mélysége, a diagram szélességének százalékában. |

Az alábbi önálló példa az alapértelmezett diagramadatokat használja, amelyek három sorozatot és négy kategóriát tartalmaznak. Két prezentációt ment, amelyekben az adatok, a forgatás, a hézag szélessége és a diagram mélysége azonos; csak a hézag mélysége változik.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230)

    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setDepthPercents(100)

    series = chart.getChartData().getSeries().get_Item(0)
    group = series.getParentSeriesGroup()
    group.setGapWidth(150)

    for gap_depth in [0, 500]:
        group.setGapDepth(gap_depth)

        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az alábbi képek bemutatják ugyanazokat a hézag mélység beállításokat a megfelelő .NET példában, és a Microsoft PowerPoint segítségével exportálták.

| Hézag mélysége: 0% | Hézag mélysége: 500% |
| --- | --- |
| ![3D oszlopdiagram, amelynek nincs hézag a sorozatok között a mélységi tengely mentén](gap_depth_0.png) | ![3D oszlopdiagram, amelynek 500 százalékos hézag van a sorozatok között a mélységi tengely mentén](gap_depth_500.png) |

## **A 3D sorozattípus és sáv alakjának módosítása**

Egy csoportosított hengerdiagram esetén az első sorozat henger alakú sávval kezdődik. A példa kiírja a [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) és a [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) által visszaadott egész értékeket minden módosítás előtt és után. A táblázat a megfelelő állandó neveket mutatja.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartShapeType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)
    
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setType(ChartType.ClusteredCone)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setBar3DShape(ChartShapeType.Box)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    presentation.save("series_shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Módosítás az első sorozaton | Sorozattípus | Sáv alak |
| --- | --- | --- |
| Diagram létrehozása | `ClusteredCylinder` | `Cylinder` |
| A sorozattípus beállítása `ClusteredCone`-ra | `ClusteredCone` | `Cone` |
| A sáv alak beállítása `Box`-ra | `ClusteredColumn3D` | `Box` |

A `Box` alak beállítása a sorozattípust is `ClusteredColumn3D`-re módosítja. Ha a kód a sorozattípus szerint ágazik, akkor a forma módosítása után hívja meg a `series.getType()` metódust. A hozzárendelés előtti tárolt érték még mindig a `ClusteredCone` ágat választaná.

![PowerPoint összehasonlítás, amely balról jobbra az első sorozatot hengerként, kúpként és téglalap oszlopként mutatja](series-shapes.png)

## **GYIK**

**Mely diagramtípusok támogatják a 3D módot az Aspose.Slides-ban?**

Az Aspose.Slides a oszlopdiagramok 3D változatait támogatja, beleértve a Column 3D, Clustered Column 3D, Stacked Column 3D és a 100 % Stacked Column 3D típusokat, valamint a kapcsolódó 3D típusokat, amelyeket a [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) osztály tesz elérhetővé. A pontos, naprakész lista megtekintéséhez ellenőrizze a [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) tagjait a telepített verzió API referenciájában.

**Kaphatok raszteres képet egy 3D diagramról jelentéshez vagy a webhez?**

Igen. A diagramot exportálhatja képként a [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) vagy a [render the entire slide](/slides/hu/python-java/convert-powerpoint-to-png/) segítségével PNG vagy JPEG formátumokba. Ez hasznos, ha raszteres előnézetre van szüksége, vagy a diagramot dokumentumokba, műszerfalakba vagy weboldalakba szeretné beágyazni anélkül, hogy a PowerPointra lenne szükség.

**Mennyire hatékony a nagy 3D diagramok építése és renderelése?**

A teljesítmény az adatmenyiségtől és a vizuális összetettségtől függ. A legjobb eredmény érdekében tartsa minimálisra a 3D hatásokat, kerüljön el nehéz textúrákat a falakon és a diagramterületeken, korlátozza a sorozatonkénti adatpontok számát, ha lehetséges, és rendereljen megfelelő méretű kimenetre (felbontás és méretek) a célkijelzőhöz vagy nyomtatási igényekhez.