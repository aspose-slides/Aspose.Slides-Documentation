---
title: Trendvonalak hozzáadása a prezentáció diagramjaihoz Pythonban
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
description: "Gyorsan adjon hozzá és testre szabjon trendvonalakat a PowerPoint diagramokban az Aspose.Slides for Python via Java használatával – egy gyakorlati útmutató a közönség bevonásához."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet trendvonalakat hozzáadni a prezentáció diagramjaihoz az Aspose.Slides használatával. Megmutatja, hogyan hozhatunk létre diagramot, hogyan adhatunk hozzá trendvonalakat a diagram sorozataihoz, és hogyan dolgozhatunk többféle trendvonal típussal, beleértve az exponenciális, lineáris, logaritmikus, mozgóátlag, polinomiális és hatvány típusúakat.

Leírja továbbá, hogyan adhatunk egy egyéni vonalat a diagramhoz egy vonal alakzat beszúrásával, és tartalmaz egy rövid GYIK-et a trendvonal előre és hátra vetített értékeiről, valamint arról, hogy a trendvonalak megmaradnak-e a PDF vagy SVG formátumba történő exportálás során, illetve a diagramok képként való renderelésekor.

## **Trendvonal hozzáadása**

Az Aspose.Slides for Python via Java egyszerű API-t biztosít a különböző diagram trendvonalak kezelése érdekében:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal és a kívánt típussal (ez a példa a [ChartType.ClusteredColumn](https://reference.aspose.com/slides/hu/python-java/aspose.slides/charttype/#ClusteredColumn) típust használja).
1. Adjon hozzá egy exponenciális trendvonalat a diagram 1. sorozatához.
1. Adjon hozzá egy lineáris trendvonalat a diagram 1. sorozatához.
1. Adjon hozzá egy logaritmikus trendvonalat a diagram 2. sorozatához.
1. Adjon hozzá egy mozgóátlag trendvonalat a diagram 2. sorozatához.
1. Adjon hozzá egy polinomiális trendvonalat a diagram 3. sorozatához.
1. Adjon hozzá egy hatvány trendvonalat a diagram 3. sorozatához.
1. Írja ki a módosított prezentációt egy PPTX fájlba.

Az alábbi kód egy diagramot hoz létre trendvonalakkal.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

# Hozzon létre egy példányt a Presentation osztályból.
presentation = Presentation()
try:
    # Hozzon létre egy csoportosított oszlop diagramot.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    # Adjon hozzá egy exponenciális trendvonalat az 1. diagram sorozathoz.
    exponential_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential)
    exponential_trend_line.setDisplayEquation(False)
    exponential_trend_line.setDisplayRSquaredValue(False)

    # Adjon hozzá egy lineáris trendvonalat az 1. diagram sorozathoz.
    linear_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear)
    linear_trend_line.setTrendlineType(TrendlineType.Linear)
    linear_trend_line.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trend_line.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # Adjon hozzá egy logaritmikus trendvonalat a 2. diagram sorozathoz.
    logarithmic_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trend_line.setTrendlineType(TrendlineType.Logarithmic)
    logarithmic_trend_line.addTextFrameForOverriding("New log trend line")

    # Adjon hozzá egy mozgóátlag trendvonalat a 2. diagram sorozathoz.
    moving_average_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trend_line.setTrendlineType(TrendlineType.MovingAverage)
    moving_average_trend_line.setPeriod(jpype.JByte(3))
    moving_average_trend_line.setTrendlineName("New TrendLine Name")

    # Adjon hozzá egy polinomiális trendvonalat a 3. diagram sorozathoz.
    polynomial_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trend_line.setTrendlineType(TrendlineType.Polynomial)
    polynomial_trend_line.setForward(1)
    polynomial_trend_line.setOrder(jpype.JByte(3))

    # Adjon hozzá egy hatvány trendvonalat a 3. diagram sorozathoz.
    power_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Power)
    power_trend_line.setTrendlineType(TrendlineType.Power)
    power_trend_line.setBackward(1)

    # Mentse a prezentációt.
    presentation.save("ChartTrendLines_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Egyéni vonal hozzáadása**

Az Aspose.Slides for Python via Java egyszerű API-t biztosít egyéni vonalak diagramhoz való hozzáadásához. Egy egyszerű vonal hozzáadásához egy kiválasztott dián lévő diagramhoz kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
- Szerezzen hivatkozást egy diára az indexe alapján.
- Hozzon létre egy új diagramot a [addChart](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addChart) metódus segítségével a [ShapeCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/) osztályban.
- Adjon hozzá egy vonal alakzatot a [addAutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addAutoShape) metódus használatával a [ShapeType.Line](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapetype/#Line) típussal.
- Állítsa be az alakzat vonalának színét.
- Írja ki a módosított prezentációt egy PPTX fájlba.

Az alábbi kód egy diagramot hoz létre egy egyéni vonallal.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Hozzon létre egy példányt a Presentation osztályból.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)
    shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0)

    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("Presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Mit jelentenek a 'forward' és a 'backward' egy trendvonal esetén?**

A trendvonal előre vagy hátra vetített hosszát jelentik: szórás (XY) diagramok esetén tengelyegységekben mérik; nem szórás diagramok esetén a kategóriák számában. Csak nem negatív értékek engedélyezettek.

**Megmarad-e a trendvonal a prezentáció PDF vagy SVG formátumba történő exportálásakor, illetve a dia képként való renderelésekor?**

Igen. Az Aspose.Slides a prezentációkat [PDF](/slides/hu/python-java/convert-powerpoint-to-pdf/)/[SVG](/slides/hu/python-java/render-a-slide-as-an-svg-image/) formátumba konvertálja, és a diagramokat képekké rendereli; a trendvonalak, mint a diagram része, megmaradnak ezek során. Egy metódus is elérhető a diagram [képének exportálásához](/slides/hu/python-java/create-shape-thumbnails/).