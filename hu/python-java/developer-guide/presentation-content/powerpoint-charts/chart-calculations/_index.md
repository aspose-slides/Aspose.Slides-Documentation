---
title: Diagram számítások optimalizálása prezentációkhoz Pythonon keresztül Java-val
linktitle: Diagram számítások
type: docs
weight: 50
url: /hu/python-java/chart-calculations/
keywords:
- diagram számítások
- diagram elemek
- elem pozíció
- tényleges pozíció
- gyermek elem
- szülő elem
- diagram értékek
- tényleges érték
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Értsd meg a diagram számításokat, az adatok frissítését és a pontosság szabályozását az Aspose.Slides for Python via Java segítségével PPT és PPTX fájlokhoz, gyakorlati Python kódrészletekkel."
---
## **Áttekintés**

Aspose.Slides API-kat biztosít diagramok számításaihoz és elrendezési adataihoz prezentációkban. Ez a cikk bemutatja, hogyan lehet lekérni a diagramelemek tényleges értékeit, beleértve a diagramelemek valós pozícióját és méretét, valamint a tengelyek tényleges értékeit. Továbbá elmagyarázza, hogy ezek az értékek a diagramelrendezés ellenőrzése után kerülnek feltöltésre.

Továbbá a cikk bemutatja, hogyan lehet lekérni a szülő diagramelemek tényleges pozícióját, és hogyan lehet elrejteni a diagram komponenseit, mint a cím, tengelyek, jelmagyarázat és rácsvonalak. Ezek a példák segítenek a diagramelrendezés információinak vizsgálatában és a diagramelemek láthatóságának programozott vezérlésében PowerPoint prezentációkban.

## **Diagramelemek tényleges értékeinek kiszámítása**
Az Aspose.Slides for Python via Java egyszerű API-t biztosít ezen tulajdonságok lekéréséhez. Az [Axis](https://reference.aspose.com/slides/hu/python-java/aspose.slides/axis/) osztály metódusai információt adnak a diagramtengelyek tényleges értékeiről ([getActualMaxValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/axis/#getActualMaxValue),[getActualMinValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/axis/#getActualMinValue),[getActualMajorUnit](https://reference.aspose.com/slides/hu/python-java/aspose.slides/axis/#getActualMajorUnit),[getActualMinorUnit](https://reference.aspose.com/slides/hu/python-java/aspose.slides/axis/#getActualMinorUnit),[getActualMajorUnitScale](https://reference.aspose.com/slides/hu/python-java/aspose.slides/axis/#getActualMajorUnitScale),[getActualMinorUnitScale](https://reference.aspose.com/slides/hu/python-java/aspose.slides/axis/#getActualMinorUnitScale)). Először hívd meg a [Chart.validateChartLayout](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/#validateChartLayout) metódust, hogy ezek a tulajdonságok tényleges értékekkel legyenek feltöltve.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getHorizontalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getHorizontalAxis().getActualMinorUnit()
finally:
    presentation.dispose()
```

## **Szülő diagramelemek tényleges pozíciójának kiszámítása**
Az Aspose.Slides for Python via Java egyszerű API-t biztosít ezen tulajdonságok lekéréséhez. A [ChartPlotArea](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartplotarea/) osztály metódusai információt adnak a diagramrajzterület tényleges pozíciójáról és méretéről ([getActualX](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartplotarea/#getActualX),[getActualY](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartplotarea/#getActualY),[getActualWidth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartplotarea/#getActualWidth),[getActualHeight](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartplotarea/#getActualHeight)). Először hívd meg a [Chart.validateChartLayout](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/#validateChartLayout) metódust, hogy ezek a tulajdonságok tényleges értékekkel legyenek feltöltve.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    x = chart.getPlotArea().getActualX()
    y = chart.getPlotArea().getActualY()
    width = chart.getPlotArea().getActualWidth()
    height = chart.getPlotArea().getActualHeight()
finally:
    presentation.dispose()
```

## **Diagramelemek elrejtése**
Ez a szakasz elmagyarázza, hogyan lehet információt elrejteni egy diagramról. Az Aspose.Slides for Python via Java használatával elrejtheted a **Címet**, a **vertikális tengelyt**, a **horizontális tengelyt** és a **rácsvonalakat**. Az alábbi kódrészlet bemutatja, hogyan használhatók ezek a tulajdonságok.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, MarkerStyleType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370)

    # A diagram címének elrejtése.
    chart.setTitle(False)

    # Az értéktengely elrejtése.
    chart.getAxes().getVerticalAxis().setVisible(False)

    # A kategóriatengely elrejtése.
    chart.getAxes().getHorizontalAxis().setVisible(False)

    # A jelmagyarázat elrejtése.
    chart.setLegend(False)

    # A fő rácsvonalak elrejtése.
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # Csak az első sorozat megtartása. A sorozatok eltávolítása a végéről biztosítja, hogy a fennmaradó indexek érvényesek maradjanak.
    series_collection = chart.getChartData().getSeries()
    while series_collection.size() > 1:
        series_collection.removeAt(series_collection.size() - 1)

    series = series_collection.get_Item(0)

    series.getMarker().setSymbol(MarkerStyleType.Circle)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top)
    series.getMarker().setSize(15)

    # A sorozat vonalszínének beállítása.
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid)

    presentation.save("HideInformationFromChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Működnek-e külső Excel munkafüzetek adatforrásként, és hogyan befolyásolja ez az újraszámítást?**

Igen. A diagram hivatkozhat egy külső munkafüzetre: amikor csatlakozol vagy frissíted a külső forrást, a képletek és értékek az adott munkafüzettől származnak, és a diagram a nyitás/szerkesztés során a változásokat tükrözi. Az API lehetővé teszi, hogy [megadd a külső munkafüzet](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#setExternalWorkbook) útvonalát, és kezeld a kapcsolt adatokat.

**Számíthatok és megjeleníthetek trendvonalakat anélkül, hogy saját regressziót implementálnék?**

Igen. A [Trendvonalak](/slides/hu/python-java/trend-line/) (lineáris, exponenciális és egyebek) hozzáadódnak és frissülnek az Aspose.Slides által; paramétereik automatikusan újraszámításra kerülnek a sorozat adataiból, így nem szükséges saját számításokat implementálni.

**Ha egy prezentáció több diagrammal rendelkezik, amelyek külső hivatkozásokat tartalmaznak, szabályozhatom-e, mely munkafüzetet használja az egyes diagram a számított értékekhez?**

Igen. Minden diagram saját [külső munkafüzetre](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#setExternalWorkbook) mutathat, vagy létrehozhatsz/cserélhetsz egy külső munkafüzetet diagramonként függetlenül a többitől.