---
title: Trendvonalak hozzáadása prezentációs diagramokhoz Pythonban
linktitle: Trendvonal
type: docs
url: /hu/python-java/trend-line/
keywords:
- diagram
- trendvonal
- exponenciális trendvonal
- lineáris trendvonal
- logaritmikus trendvonal
- mozgó átlag trendvonal
- polinomiális trendvonal
- hatvány trendvonal
- egyéni trendvonal
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Gyorsan hozzáadhat és testreszabhat trendvonalakat a PowerPoint diagramokhoz az Aspose.Slides for Python via Java segítségével — egy gyakorlati útmutató, amely segít lebilincselni a közönségét."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet trendvonalakat hozzáadni a prezentáció diagramjaihoz az Aspose.Slides használatával. Megmutatja, hogyan hozhatunk létre diagramot, hogyan adhatunk trendvonalakat a diagram sorozataihoz, és hogyan dolgozhatunk többféle trendvonal típussal, beleértve az exponenciális, lineáris, logaritmikus, mozgó átlag, polinomiális és hatvány típusokat.

Leírja továbbá, hogyan adhatunk egy egyéni vonalat a diagramhoz egy vonal alakzat beszúrásával, és egy rövid GYIK-ot tartalmaz a trendvonal előre és hátra irányú projektált értékeiről, valamint arról, hogy a trendvonalak megmaradnak-e PDF vagy SVG exportáláskor és a diagramok képként történő renderelésekor.

## **Trendvonal hozzáadása**

A [TrendlineCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinecollection/#add) használatával adhatunk hozzá trendvonalat egy diagram sorozatához, a típusát a [TrendlineType](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinetype/) segítségével választhatjuk ki. A példa egy klaszteres oszlopdiagramot hoz létre alapértelmezett adatokkal, és mindhárom sorozatához két trendvonalat ad hozzá.

Az exponenciális trendvonal elrejti egyenletét és az R-négyzet értékét a [setDisplayEquation](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayEquation) és a [setDisplayRSquaredValue](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayRSquaredValue) használatával, míg a lineáris trendvonal piros. A logaritmikus trendvonal egy egyéni címkehez a [addTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#addTextFrameForOverriding) metódust használja. A mozgó átlag három adatpontos [setPeriod](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setPeriod) értéket és egy egyéni [setTrendlineName](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setTrendlineName) beállítást használ.

A polinomiális trendvonal rendje három, a [setOrder](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setOrder) segítségével van beállítva, és egy kategóriát előre nyújt a [setForward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setForward) segítségével. A hatvány trendvonal egy kategóriát hátra nyújt a [setBackward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setBackward) segítségével.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    first_series = chart.getChartData().getSeries().get_Item(0)

    exponential_trendline = first_series.getTrendLines().add(TrendlineType.Exponential)
    exponential_trendline.setDisplayEquation(False)
    exponential_trendline.setDisplayRSquaredValue(False)

    linear_trendline = first_series.getTrendLines().add(TrendlineType.Linear)
    linear_trendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    second_series = chart.getChartData().getSeries().get_Item(1)

    logarithmic_trendline = second_series.getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trendline.addTextFrameForOverriding("New log trend line")

    moving_average_trendline = second_series.getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trendline.setPeriod(jpype.JByte(3))
    moving_average_trendline.setTrendlineName("New TrendLine Name")

    third_series = chart.getChartData().getSeries().get_Item(2)

    polynomial_trendline = third_series.getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trendline.setForward(1)
    polynomial_trendline.setOrder(jpype.JByte(3))

    power_trendline = third_series.getTrendLines().add(TrendlineType.Power)
    power_trendline.setBackward(1)

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Trendvonal metszéspont beállítása**

A [setIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setIntercept) használatával rögzíthetjük a trendvonal Y értékét X = 0‑nál. Ez a beállítás támogatott a lineáris, exponenciális és polinomiális trendvonalak esetén.

Például egy termelési költségmodellnek szüksége lehet arra, hogy a 100 ismert fix költségnél induljon, még akkor is, ha a nemnulla termelési mennyiségeknél mért értékek más kiindulási pontot sugallnak. Lineáris trendvonal esetén a metszéspont rögzítése korlátozza a `y = ax + b` egyenletet `b = 100`‑ra; a meredekség a korlátozás mellett van illesztve az adatokhoz. Ez nem egyszerűen csak egy már illesztett vonalat mozgat. A tengelykereszteződés beállítások szabályozzák, hogy a diagram tengelyei hol találkoznak, nem pedig az illesztett trendvonal együtthatóit.

Az alábbi példa egy szórás (XY) diagramot hoz létre 1‑től 4‑ig terjedő termelési mennyiségekkel és 170, 200, 230 és 260 költségekkel. A diagramot elmenti az alapértelmezett automatikus metszésponttal, beállítja a metszéspontot 100-ra, és egy második PPTX‑et ment. A két fájl csak a metszéspont beállításában tér el. A trendvonal megjeleníti az egyenletét és visszanyúlik X = 0‑ra.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, TrendlineType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    name_cell = workbook.getCell(0, 0, 1, "Production cost")
    series = chart.getChartData().getSeries().add(name_cell, ChartType.ScatterWithMarkers)
    costs = [170, 200, 230, 260]

    for i in range(len(costs)):
        x_cell = workbook.getCell(0, i + 1, 0, i + 1)
        y_cell = workbook.getCell(0, i + 1, 1, costs[i])
        series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    trendline = series.getTrendLines().add(TrendlineType.Linear)
    trendline.setDisplayEquation(True)
    trendline.setBackward(1)

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx)

    trendline.setIntercept(100)
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Automatikus számítás esetén ezek az adatok `y = 30x + 140` eredményt adnak. A metszéspont 100‑ra állításával körülbelül `y = 43.33x + 100` lesz: a nulla értékénél illesztett érték megegyezik a ismert kiindulási ponttal, míg a vonal már nem halad át minden adatponton.

| Automatikus metszéspont | 100‑as rögzített metszéspont |
| --- | --- |
| ![Lineáris trendvonal automatikusan kiszámított 140‑as metszésponttal](intercept-automatic.png) | ![Lineáris trendvonal 100‑as rögzített metszésponttal](intercept-fixed.png) |

Mindkét kép ugyanazt az adatot és tengelyskálát használja. A trendvonalak visszanyúlnak X = 0‑ra, hogy megjelenítsék a metszéspontjaikat.

Alapértelmezés szerint a [getIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#getIntercept) `NaN`‑t ad vissza, ami egy nem meghatározott metszéspontot jelent, nem pedig nullát. A metszéspont ezután automatikusan lesz kiszámítva az adatokból.

## **Egyéni vonal hozzáadása**

Az egyéni vonal egy alakzat, amelyet a diagram fölött rajzolunk, nem pedig a sorozati adatokból számított trendvonal. Ez a példa a [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape) használatával ad hozzá egy vízszintes vonalat a diára a diagram felett. A vonal pozíciója a diakoordinátákban van megadva pontokban, így a diagram bal szélén kezdődik, és a diagram közepénél helyezkedik el. Szélessége megegyezik a diagram szélességével. A [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) metódus hozzáférést biztosít a vonal formázásához, amely egy tiszta piros színt alkalmaz.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0)
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Mit jelentenek a 'forward' és a 'backward' egy trendvonal esetén?**

Ezek a trendvonal előre/hátra kiterjesztett hosszát jelentik: szórás (XY) diagramok esetén – tengelyegységekben; nem szórás diagramok esetén – kategóriák számában. Csak nem negatív értékek megengedettek.

**Megmarad a trendvonal a prezentáció PDF‑ vagy SVG‑formátumba exportálása, illetve a dia képként való renderelése esetén?**

Igen. Az Aspose.Slides a prezentációkat [PDF](/slides/hu/python-java/convert-powerpoint-to-pdf/) vagy [SVG](/slides/hu/python-java/render-a-slide-as-an-svg-image/) formátumba konvertálja, és a diagramokat képekké rendereli; a trendvonalak, mint a diagram részei, megmaradnak ezek során. Egy módszer szintén elérhető a diagram [a diagram képének exportálása](/slides/hu/python-java/create-shape-thumbnails/) számára.