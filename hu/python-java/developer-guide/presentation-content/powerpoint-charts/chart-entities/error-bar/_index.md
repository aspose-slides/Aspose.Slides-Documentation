---
title: Hibasávok testreszabása prezentációs diagramokban Python használatával
linktitle: Hibasáv
type: docs
url: /hu/python-java/error-bar/
keywords:
- hibasáv
- egyéni érték
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá és testreszabhat hibasávokat diagramokban az Aspose.Slides for Python via Java használatával – optimalizálja az adatvizualizációt PowerPoint prezentációkban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet hibasávokat használni prezentációs diagramokban az Aspose.Slides segítségével. Megmutatja, hogyan adhat hibasávokat egy diagram sorozathoz, hogyan állítható be az X és Y hibasáv beállítás, valamint különböző értéktípusok alkalmazása, például rögzített, százalékos és egyéni értékek.

Emellett bemutatja, hogyan lehet egyéni hibasáv értékeket hozzárendelni egy sorozat egyes adatpontjaihoz a megfelelő adatpontgyűjtemény használatával. Továbbá a cikk rövid megjegyzéseket tartalmaz arról, hogy a hibasávok hogyan viselkednek exportáláskor, kompatibilitásuk jelölőkkel és adatcímkékkel, valamint hogy hol találhatók a kapcsolódó API referencia osztályok és felsorolások.

## **Hibásávok hozzáadása**

Az Aspose.Slides for Python via Java egyszerű API-t biztosít a hibasáv értékek kezeléséhez. A következő példa kód rögzített és százalékos értéktípusokat használ.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Adjon hozzá egy buborékdiagramot a kívánt diára.
1. Érje el az első diagram sorozatot, és állítsa be a hibasáv X formátumát.
1. Érje el az első diagram sorozatot, és állítsa be a hibasáv Y formátumát.
1. Állítsa be a hibasáv értékeket és formázást.
1. Írja a módosított prezentációt egy PPTX fájlba.

```python
import jpype
import asposeslides

if not jpway.isJVMStarted():
    jpway.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Hozzon létre egy példányt a Presentation osztályból.
presentation = Presentation()
try:
    # Készítsen egy buborékdiagramot.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # Adjon hozzá hibasávokat, és állítsa be azok formázását.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()

    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Fixed)
    error_bar_x.setValue(0.1)
    error_bar_y.setValueType(ErrorBarValueType.Percentage)
    error_bar_y.setValue(5)
    error_bar_x.setType(ErrorBarType.Plus)
    error_bar_y.getFormat().getLine().setWidth(2.0)
    error_bar_x.setEndCap(True)

    # Mentse a prezentációt.
    presentation.save("ErrorBars.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Egyéni hibasáv értékek hozzáadása**

Az Aspose.Slides for Python via Java egyszerű API-t biztosít az egyéni hibasáv értékek kezeléséhez. A következő példa kód akkor alkalmazandó, amikor a [getValueType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/errorbarsformat/#getValueType) visszaadja a [ErrorBarValueType.Custom](https://reference.aspose.com/slides/hu/python-java/aspose.slides/errorbarvaluetype/#Custom) értéket. Egy érték megadásához használja a [getErrorBarsCustomValues](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatapoint/#getErrorBarsCustomValues) metódust egy adott adatponthoz, amely a sorozat [getDataPoints](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#getDataPoints) metódusa által visszaadott gyűjteményben található.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Adjon hozzá egy buborékdiagramot a kívánt diára.
1. Érje el az első diagram sorozatot, és állítsa be a hibasáv X formátumát.
1. Érje el az első diagram sorozatot, és állítsa be a hibasáv Y formátumát.
1. Érje el a diagram sorozat egyéni adatpontjait, és állítsa be azok hibasáv értékeit.
1. Állítsa be a hibasáv értékeket és formázást.
1. Írja a módosított prezentációt egy PPTX fájlba.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Hozzon létre egy példányt a Presentation osztályból.
presentation = Presentation()
try:
    # Készítsen egy buborékdiagramot.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # Adjon hozzá egyéni hibasávokat, és állítsa be azok formázását.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()
    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Custom)
    error_bar_y.setValueType(ErrorBarValueType.Custom)

    # Hozzáférés a diagram sorozat adatpontjaihoz, és a hibasáv értékforrásainak beállítása.
    points = series.getDataPoints()
    data_source = points.getDataSourceTypeForErrorBarsCustomValues()
    data_source.setDataSourceTypeForXPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForXMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))

    # Állítsa be a hibasáv értékeket a diagram sorozat adatpontjaihoz.
    for i in range(points.size()):
        custom_values = points.get_Item(i).getErrorBarsCustomValues()
        custom_values.getXMinus().setAsLiteralDouble(i + 1)
        custom_values.getXPlus().setAsLiteralDouble(i + 1)
        custom_values.getYMinus().setAsLiteralDouble(i + 1)
        custom_values.getYPlus().setAsLiteralDouble(i + 1)

    # Mentse a prezentációt.
    presentation.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Mi történik a hibasávokkal, amikor a prezentációt PDF‑re vagy képekre exportálják?**

A hibasávok a diagram részeként kerülnek renderelésre, és a konverzió során megmaradnak a diagram többi formázásával együtt, feltéve, hogy kompatibilis verzió vagy renderelő áll rendelkezésre.

**Kombinálhatók a hibasávok jelölőkkel és adatcímkékkel?**

Igen. A hibasávok külön elemek, és kompatibilisek a jelölőkkel és adatcímkékkel; ha az elemek átfedik egymást, előfordulhat, hogy a formázást módosítani kell.

**Hol található a hibasávok kezeléséhez szükséges tulajdonságok és osztályok listája az API-ban?**

Az API referencia: a [ErrorBarsFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/errorbarsformat/) osztály és a kapcsolódó [ErrorBarType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/errorbartype/) valamint [ErrorBarValueType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/errorbarvaluetype/) osztályok.