---
title: Kördiagramok testreszabása prezentációkban Pythonon keresztül Java-val
linktitle: Kördiagram
type: docs
url: /hu/python-java/pie-chart/
keywords:
- kördiagram
- diagram kezelése
- diagram testreszabása
- diagram beállításai
- diagram beállítások
- rajzolási beállítások
- szelet színe
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és testreszabhat kördiagramokat Pythonon keresztül Java-val az Aspose.Slides segítségével, exportálhatók PowerPointba, és másodpercek alatt erősítheti adatmesélését."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan dolgozhatunk kördiagramokkal az Aspose.Slides-ben. Bemutatja, hogyan állíthatók be a másodlagos diagrambeállítások a Pie of Pie és Bar of Pie diagramokhoz, valamint hogyan engedélyezhető az automatikus szeletfestés egy szabványos kördiagram esetén.

A példák a gyakorlati diagramtestreszabási lépésekre összpontosítanak, például diagram hozzáadására egy diára, sorok és címkék beállításainak módosítására, az alapértelmezett diagramadatok egyéni kategóriákkal és értékekkel való helyettesítésére, valamint a frissített prezentáció mentésére.

## **Másodlagos diagrambeállítások a Pie of Pie és Bar of Pie diagramokhoz**

Az Aspose.Slides for Python via Java támogatja a másodlagos diagrambeállításokat a Pie of Pie és Bar of Pie diagramokhoz. Ez a rész bemutatja, hogyan adhatók meg ezek a beállítások az Aspose.Slides használatával. Kövesse az alábbi lépéseket:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt.  
1. Adjon hozzá egy diagramot a diára.  
1. Adja meg a diagram másodlagos diagrambeállításait.  
1. Írja a prezentációt a lemezre.

A következő példa a Pie of Pie diagram különböző tulajdonságait állítja be.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

# Hozzon létre egy példányt a Presentation osztályból.
presentation = Presentation()
try:
    # Adj hozzá egy diagramot a diára.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)

    # Állítson be különböző tulajdonságokat.
    series = chart.getChartData().getSeries().get_Item(0)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    # Mentse a prezentációt lemezre.
    presentation.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Automatikus kördiagram-szelet színek beállítása**

Az Aspose.Slides for Python via Java egyszerű API-t biztosít az automatikus kördiagram-szelet színek beállításához. A következő példa bemutatja, hogyan alkalmazhatók ezek a beállítások.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.  
1. Nyissa meg az első diát.  
1. Adjon hozzá egy diagramot az alapértelmezett adatokkal.  
1. Állítsa be a diagram címét.  
1. Állítsa be a diagramadat munkalap indexét.  
1. Szerezze be a diagramadat munkafüzetet.  
1. Törölje az alapértelmezett sorokat és kategóriákat.  
1. Adjon hozzá új kategóriákat.  
1. Adjon hozzá egy új sort.  
1. Állítsa be, hogy az új sor értékeket jelenítsen meg.

Írja a módosított prezentációt egy PPTX fájlba.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Hozzon létre egy példányt a Presentation osztályból.
presentation = Presentation()
try:
    # Adj hozzá egy diagramot az alapértelmezett adatokkal.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Állítsa be a diagram címét.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Állítsa be a diagramadat munkalap indexét.
    default_worksheet_index = 0

    # Szerezze be a diagramadat munkafüzetet.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Törölje az alapértelmezett sorokat és kategóriákat.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Adjon hozzá új kategóriákat.
    first_category_cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(second_category_cell)
    third_category_cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(third_category_cell)

    # Adjon hozzá egy új sort.
    series_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())

    # Töltse fel a sor adatait.
    first_value_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForPieSeries(first_value_cell)
    second_value_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForPieSeries(second_value_cell)
    third_value_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForPieSeries(third_value_cell)

    # Állítsa be, hogy az új sor értékeket jelenítsen meg.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    series.getParentSeriesGroup().setColorVaried(True)
    presentation.save("Pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Támogatottak a 'Pie of Pie' és 'Bar of Pie' változatok?**

Igen, a könyvtár [támogatja](https://reference.aspose.com/slides/hu/python-java/aspose.slides/charttype/) egy másodlagos diagramot a kördiagramokhoz, beleértve a 'Pie of Pie' és 'Bar of Pie' típusokat.

**Exportálhatom csak a diagramot képként (például PNG)?**

Igen, [exportálhatja a diagramot képként](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getImage) (például PNG) a teljes prezentáció nélkül.