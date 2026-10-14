---
title: Testreszabott kördiagramok készítése bemutatókhoz Python via Java segítségével
linktitle: Kördiagram
type: docs
url: /hu/python-java/pie-chart/
keywords:
- kördiagram
- diagram kezelése
- diagram testreszabása
- diagram beállításai
- diagram beállítások
- ábrázolási beállítások
- szelet szín
- PowerPoint
- bemutató
- Python
- Java
- Aspose.Slides
description: "Készítsen és testreszabjon kördiagramokat Python via Java segítségével az Aspose.Slides használatával. Állítsa be a másodlagos ábrákat, jelenítse meg az adatcímkéket, és alkalmazzon automatikus szelet színeket a PowerPointban."
---
## **Áttekintés**

Ez a cikk ismerteti, hogyan dolgozhatunk kördiagramokkal az Aspose.Slides-ban. Bemutatja, hogyan állíthatók be a másodlagos ábrázolási beállítások a Pie of Pie és Bar of Pie diagramokhoz, valamint hogyan lehet automatikus szelet színezést engedélyezni egy standard kördiagramnál.

A példák a diagram testreszabási feladataira összpontosítanak, például diagram hozzáadására egy diára, sorozat- és címkebeállítások módosítására, az alapértelmezett diagramadatok egyéni kategóriákkal és értékekkel való helyettesítésére, valamint a módosított bemutató mentésére.

## **Másodlagos ábrázolási beállítások a Pie of Pie és Bar of Pie diagramokhoz**

Az Aspose.Slides for Python via Java támogatja a másodlagos ábrázolási beállításokat a Pie of Pie és Bar of Pie diagramokhoz. Ezek a beállítások szabályozzák a másodlagos ábra méretét és azt, hogy az adatpontok hogyan oszlanak meg a két ábra között.

A következő példa létrehoz egy Pie of Pie diagramot egy új bemutatóban, és adatpont értékeket jelenít meg címkeként. A [setSecondPieSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setSecondPieSize) metódus a másodlagos ábra méretét a fő ábra 149%-ára állítja. A [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) százalékos alapú felosztást választ, és a [setPieSplitPosition](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) a küszöböt 53%-ra állítja.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)
    series = chart.getChartData().getSeries().get_Item(0)

    # Értékek megjelenítése és a másodlagos ábra konfigurálása.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Kategóriák kiválasztása a másodlagos ábrához**

Használjon egyedi felosztást, ha szeretné egyes kategóriákat csoportosítani a másodlagos ábrában anélkül, hogy figyelembe venné azok százalékos értékeit. Például egy értékesítési jelentés megjelenítheti az Online és Events kategóriákat együtt, hogy az olvasók összehasonlíthassák ezt a két csatornát, még akkor is, ha azok a teljes eladások 35%-át és 10%-át teszik ki.

Az [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) metódust [PieSplitType.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/piesplittype/#Custom) értékkel hívja meg, és a pontokat a [getPieSplitCustomPoints](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints) segítségével válassza ki. A gyűjtemény [add](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#add) metódusa egy nulla-alapú indexet fogad a sorozatban; használja az [addItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#addItem) metódust egy adatpont objektum hozzáadásához. Ebben a példában az 1-es index az Online kategóriát választja, a 3-as index pedig az Events-et. A Partners kategória is ideiglenesen hozzáadásra kerül, majd a [removeItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#removeItem) segítségével kizárásra.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200)

    # Cserélje le az alapértelmezett adatokat a csatornánkénti eladásokra.
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.getCell(0, 0, 1, "Sales")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(0, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setPieSplitBy(PieSplitType.Custom)
    series_group.setColorVaried(True)

    # Válassza ki az Online-t a nulla-alapú indexe alapján, és az Events-et az adatpont objektuma alapján.
    series_group.getPieSplitCustomPoints().add(1)
    series_group.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3))

    # Zárja ki a Partners-t a kiválasztásból anélkül, hogy törölné a forrásadatát.
    series_group.getPieSplitCustomPoints().add(2)
    series_group.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2))

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az Online (35) és Events (10) külön szeletekként jelennek meg a másodlagos ábrában. Az elsődleges ábrában egy kombinált szeletként, 45 értékkel jelennek meg, a Retail (40) és Partners (15) mellett. A Partners eltávolítása az egyedi kiválasztásból az elsődleges ábrában marad; nem távolítja el a kategóriát vagy az értékét a diagram forrásadataiból.

Az alábbi kép mutatja a mentett bemutatót PowerPointban:

![Pie of Pie diagram Online és Events kategóriákkal a másodlagos ábrában és a kombinált 45 értékkel az elsődleges ábrában](pie_of_pie_custom.png)

## **Automatikus kördiagram szelet színek beállítása**

Az Aspose.Slides for Python via Java automatikusan különböző színeket rendelhet a kördiagram szeleteihez. A következő példa létrehoz egy kördiagramot középre igazított címmel, és a három negyedéves kategóriát és értéküket helyettesíti az alapértelmezett adatokkal. A [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) metódus megjeleníti a 20, 50 és 30 értékeket címkeként, míg a [setColorVaried](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setColorVaried) engedélyezi, hogy minden szelet más színt kapjon.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Középre igazított diagramcím hozzáadása.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Cserélje le az alapértelmezett adatokat az első munkalap használatával.
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    # Értékek megjelenítése és különböző színek hozzárendelése a szeletekhez.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getParentSeriesGroup().setColorVaried(True)

    presentation.save("pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Támogatottak a Pie of Pie és Bar of Pie változatok?**

Igen, a könyvtár [supports](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) másodlagos ábrát biztosít kördiagramokhoz, beleértve a Pie of Pie és Bar of Pie típusokat.

**Exportálhatom csak a diagramot képként (például PNG)?**

Igen, a [export the chart itself as an image](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) (például PNG) exportálható anélkül, hogy a teljes bemutatót exportálná.