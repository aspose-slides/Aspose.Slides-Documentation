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
description: "Készítsen 3D diagramokat PowerPoint prezentációkban az Aspose.Slides for Python via Java segítségével. Állítsa be a forgást, a magasságarányokat, a diagram mélységét és a sorok közti távolságot Python példákkal."
---
## **Áttekintés**

Az Aspose.Slides for Python via Java lehetővé teszi, hogy a 3D diagram nézetét testreszabja a [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D) metódus segítségével. Ez a cikk bemutatja, hogyan állítható be a forgatás, magasságarányok, mélység, derékszögű tengelyek és a sorok közötti távolság, majd hogyan menthető a bemutató PPTX formátumban.

## **Állítsa be a 3D diagram forgatásét és mélységét**

Az alábbi példa létrehoz egy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) objektumot, és a [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) metódussal egy egymásra rakott 3D oszlopdiagramot ad az első diájához. Lecseréli az alapértelmezett sorozatokat és kategóriákat két sorozatra, amelyek mindegyike három értéket tartalmaz. A `0` indexű munkalap a diagram első adatlapját jelöli; a `0`‑s sor a sorozatneveket, a `0`‑s oszlop pedig a kategória címkéket tárolja.

A [setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) és a [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) metódusok a diagram forgását állítják be 40‑re és 270‑re fokban. A [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) a mélységet a szélesség 150 %-ára állítja, míg a [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) a perspektíva helyett derékszögű tengelyeket aktiválja. Az így kapott bemutató a kitöltött diagramot tartalmazza a megadott 3D nézeti beállításokkal.

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

## **Képpel kitöltés alkalmazása a 3D diagram felületére**

Egy 3D diagramnak három felülete van, amelyeket függetlenül tölthetünk ki: a [side wall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getSideWall), a [back wall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getBackWall) és a [floor](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getFloor). Állítsa a felület [fill type](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) tulajdonságát `Picture`‑ra, és adjon meg egy képet. Állítsa a [picture fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) és a felület [picture type](https://reference.aspose.com/slides/python-java/aspose.slides/chartwall/#setPictureType) értékét `Stretch`‑re, hogy a kép egy példánya kitöltse a felületet.

Mentse a [arrow.png](arrow.png) fájlt a munkakönyvtárba. A példa elforgatja a diagramot, és megnöveli a függőleges tengely legnagyobb értékét, hogy a talaj látható legyen az oszlopok között. Ezután kétszer klónozza a diát, és az egyes diákon különböző felületekre alkalmazza a nyilat. Mindhárom diagram ugyanazokat az adatokat, nézeti szöget és háttérszínt tartja meg.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, PictureFillMode, PictureType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(30)
    
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(24)

    back_slide = presentation.getSlides().addClone(slide)
    floor_slide = presentation.getSlides().addClone(slide)
    back_chart = back_slide.getShapes().get_Item(0)
    floor_chart = floor_slide.getShapes().get_Item(0)

    image_bytes = Path("arrow.png").read_bytes()
    arrow = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_bytes))

    surfaces = (chart.getSideWall(), back_chart.getBackWall(), floor_chart.getFloor())
    for surface in surfaces:
        fill = surface.getFormat().getFill()
        fill.setFillType(FillType.Picture)
        picture_fill = fill.getPictureFillFormat()
        picture_fill.getPicture().setImage(arrow)
        picture_fill.setPictureFillMode(PictureFillMode.Stretch)
        surface.setPictureType(PictureType.Stretch)

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A Microsoft PowerPoint a három diát a következőképpen jeleníti meg.

| Oldalfal | Háttérfal | Alj |
| --- | --- | --- |
| ![Nyíl, amely a diagram felé mutat az oldalfalon](side-wall.png) | ![Nyíl, amely jobbra mutat a háttérfalon](back-wall.png) | ![Nyíl, amely jobbra mutat az oszlopok közötti alapon](floor.png) |

## **A 3D diagram magasságarányainak módosítása**

A [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) metódussal a 3D diagram magasságát a szélesség százalékában állíthatja be. Ez a 3D jelenet arányait módosítja anélkül, hogy a diagram objektum mérete megváltozna a dián.

Az alábbi példa létrehoz egy [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) diagramot az alapértelmezett adatokkal: három sorozat és négy kategória. Három bemutatót ment 50 %, 100 % és 200 % magasságarányokkal. A diagram pozíciója, szélessége és magassága rögzített marad. Az adatok, a forgatás, a mélység, a sorok közötti távolság és a formázás minden fájlban azonos; csak a magasság százaléka változik.

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

Az alábbi képek ugyanazokat a magasságbeállításokat mutatják be a megfelelő .NET példában, és a Microsoft PowerPoint segítségével lettek exportálva. Az alacsonyabb százalék laposabb jelenetet eredményez, míg a magasabb százalék magasabb jelenetet hoz létre ugyanazon diagramobjektumon belül. A PowerPoint a jelenethez igazodva módosíthatja a tengely jelölőinek intervallumát és a címkék elhelyezését.

| Magasság: 50% | Magasság: 100% | Magasság: 200% |
| --- | --- | --- |
| ![3D oszlopdiagram, amelynek magassága a szélesség 50 %-a](height_percent_50.png) | ![3D oszlopdiagram, amelynek magassága a szélesség 100 %-a](height_percent_100.png) | ![3D oszlopdiagram, amelynek magassága a szélesség 200 %-a](height_percent_200.png) |

Ezek a módszerek a diagram különböző aspektusait szabályozzák:

| Módszer | Hatás |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | A 3D jelenet magassága a szélességének százalékában. |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | A diagram objektum magassága a dián pontban. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | A 3D jelenet mélysége a szélességének százalékában. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Sorok közötti távolság a mélységi tengelyen, a jelző szélességének százalékában. |

A magasságbeállítás a 3D oszlop‑ és sávdiagramokra, köztük a henger-, kúp- és piramis‑variánsokra, valamint a 3D vonal‑, terület‑, kör‑ és felületdiagramokra hat. A fenti összehasonlítás a hitelesített `Column3D` típust használja. A beállítás nem változtatja meg egy 2D `ClusteredColumn` vagy egy `BubbleWith3D` diagram megjelenését; ezek a nevek a [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) osztály tagjai. Egyéb diagramformázási beállításokért lásd a [Chart Formatting](/slides/hu/python-java/chart-formatting/) oldalt.

## **A sorok közötti hézag módosítása**

A [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) metódussal szabályozható a sorok közötti távolság a 3D diagram mélységi tengelyén, amelyet a jelző szélességének százalékában adunk meg. **0‑tól 500‑ig** terjedő értékek használhatók: a `0` eltávolítja a hézagot, nagyobb értékek növelik a távolságot. Rögzített diagrammélység mellett a hézag növelése vékonyabb jelzőket eredményez a mélységi tengelyen.

A csoport a [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) metódussal érhető el. A beállítás minden sorra vonatkozik a csoportban, nem csak arra, amelyen keresztül hozzáférünk. A [ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) visszaadja a mélységi hézagot, és tükrözi a szülőcsoport beállítását.

Ez a beállítás a 3D oszlop‑ és sávdiagramokra, valamint a 3D vonal‑ és területdiagramokra is hatással van. A megjelenés attól függ, hogy a sorok a mélység mentén rendeződnek‑e, csoportosak‑e vagy egymásra rakottak‑e. A sorok közti hézag világos összehasonlításához használja a `ChartType.Column3D` típust a [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) osztályból.

Ezek a módszerek a diagram különböző aspektusait szabályozzák:

| Módszer | Hatás |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Sorok közötti távolság a mélységi tengelyen, a jelző szélességének százalékában. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | Szomszédos oszlop‑ vagy sávcsoportok közötti távolság, a oszlop vagy sáv szélességének százalékában. |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | A diagram összes mélysége, a diagram szélességének százalékában. |

Az alábbi önálló példa az alapértelmezett diagramadatokat használja, amelyek három sorozatot és négy kategóriát tartalmaznak. Két bemutatót ment, amelyek azonos adatokat, forgatást, hézag‑szélességet és diagrammélységet tartalmaznak; csak a hézag‑mélység változik.

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

Az alábbi képek ugyanazokat a hézag‑mélység beállításokat mutatják be a megfelelő .NET példában, és a Microsoft PowerPoint segítségével lettek exportálva.

| Hézag mélysége: 0% | Hézag mélysége: 500% |
| --- | --- |
| ![3D oszlopdiagram, amelyik nem tart hézagot a sorok között a mélységi tengelyen](gap_depth_0.png) | ![3D oszlopdiagram, amelyik 500 % hézagot tart a sorok között a mélységi tengelyen](gap_depth_500.png) |

## **A 3D sor típusának és oszlop alakjának módosítása**

Egy csoportos henger diagram első sorozata henger alakú oszlopokkal indul. A példa kiírja a [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) és a [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) által visszaadott egész értékeket minden változtatás előtt és után. A táblázat a megfelelő állandóneveket mutatja.

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

| Az első sor módosítása | Sor típusa | Oszlop alakja |
| --- | --- | --- |
| Diagram létrehozása | `ClusteredCylinder` | `Cylinder` |
| Sor típusa állítása `ClusteredCone`‑ra | `ClusteredCone` | `Cone` |
| Oszlop alak beállítása `Box`‑ra | `ClusteredColumn3D` | `Box` |

A `Box` alak beállítása egyúttal a sor típusát is `ClusteredColumn3D`‑re változtatja. Ha a kód a sor típusán alapuló elágazást használ, a forma módosítása után hívja a `series.getType()`‑t. Egy korábban cache‑elt érték még a `ClusteredCone` ágat választaná.

![PowerPoint összehasonlítás, amely az első sorozatot henger, kúp és téglalap alakú oszlopokként mutatja balról jobbra](series-shapes.png)

## **GYIK**

**Mely diagramtípusok támogatják a 3D módot az Aspose.Slides-ben?**

Az Aspose.Slides támogatja a 3D oszlopdiagramok változatait, beleértve a Column 3D, Clustered Column 3D, Stacked Column 3D és 100 % Stacked Column 3D típusokat, valamint az azokhoz kapcsolódó 3D típusokat, amelyeket a [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) osztály biztosít. A pontos, naprakész listáért ellenőrizze a [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) tagjait az adott verzió API‑referenciájában.

**Kaphatok raszteres képet egy 3D diagramról jelentéshez vagy a webhez?**

Igen. A diagramot exportálhatja képként a [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) vagy az egész dia [renderelésével](/slides/hu/python-java/convert-powerpoint-to-png/) PNG vagy JPEG formátumba. Ez akkor hasznos, ha raszteres előnézetre van szükség, vagy be szeretné ágyazni a diagramot dokumentumokba, műszerfalakba vagy weboldalakra, anélkül hogy a PowerPointra támaszkodna.

**Milyen teljesítményű a nagy 3D diagramok felépítése és renderelése?**

A teljesítmény az adatmérettől és a vizuális komplexitástól függ. A legjobb eredmény érdekében tartsa minimális szinten a 3D effektusokat, kerüljön el nehéz textúrákat a falakon és a diagramterületeken, korlátozza a sorozatonkénti adatpontok számát, amikor csak lehetséges, és rendereljen a célkijelző vagy nyomtatási igényeknek megfelelő felbontásban és méretben.