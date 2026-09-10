---
title: Diagramtengelyek testreszabása prezentációkban Python használatával
linktitle: Diagramtengely
type: docs
url: /hu/python-java/chart-axis/
keywords:
- diagramtengely
- függőleges tengely
- vízszintes tengely
- tengely testreszabása
- tengely manipulálása
- tengely kezelése
- tengely tulajdonságok
- maximális érték
- minimális érték
- tengelyvonal
- dátumformátum
- tengelycím
- tengelypozíció
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: Fedezze fel, hogyan használhatja az Aspose.Slides for Python via Java könyvtárat a diagramtengelyek testreszabásához PowerPoint prezentációkban jelentések és vizualizációk készítéséhez.
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan testreszabhatók a diagram tengelyei az Aspose.Slides-ben. Megmutatja, hogyan lehet lekérni a tényleges tengelyértékeket, cserélni az adatokat a tengelyek között, elrejteni a függőleges vagy vízszintes tengelyt vonaldiagramoknál, módosítani a kategória tengely típusát, beállítani a dátumformátumot a kategória tengely értékeihez, elforgatni a tengelycímét, beállítani a tengely pozícióját, illetve beállítani az értéktengely megjelenítési egységét.

## **A diagram függőleges tengelyének maximális értékeinek lekérése**

Aspose.Slides for Python via Java lehetővé teszi a minimum és maximum értékek lekérését egy függőleges tengelyen. Kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Nyissa meg az első diát.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal.
1. Szerezze meg a tényleges maximális értéket a tengelyen.
1. Szerezze meg a tényleges minimális értéket a tengelyen.
1. Szerezze meg a tényleges fő egységet a tengelyen.
1. Szerezze meg a tényleges alsegységet a tengelyen.
1. Szerezze meg a tényleges fő egységskálát a tengelyen.
1. Szerezze meg a tényleges alsegység skálát a tengelyen.

Ez a példakód – a fenti lépések megvalósítása – megmutatja, hogyan szerezhetők meg a szükséges értékek Pythonban:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    # Elmenti a prezentációt
    presentation.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Az adatok cseréje a tengelyek között**

Az Aspose.Slides lehetővé teszi az adatok gyors cseréjét a tengelyek között – a függőleges tengelyen (y-tengely) megjelenített adatok a vízszintes tengelyre (x-tengely) kerülnek, és fordítva.

Ez a Python kód megmutatja, hogyan hajtható végre az adatcserélés a tengelyek között egy diagramon:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)

    # Betölti a diagram alapértelmezett adatait a munkafüzetbe — a switchRowColumn áttranszponálja a munkafüzetet,
    # ezért először fel kell tölteni
    workbook = chart.getChartData().getChartDataWorkbook()

    # Átváltja a sorokat és oszlopokat
    chart.getChartData().switchRowColumn()

    # Elmenti a prezentációt
    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **A függőleges tengely letiltása vonaldiagramoknál**

Ez a Python kód megmutatja, hogyan rejthető el a függőleges tengely egy vonaldiagramon:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **A vízszintes tengely letiltása vonaldiagramoknál**

Ez a kód megmutatja, hogyan rejthető el a vízszintes tengely egy vonaldiagramon:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kategória tengely módosítása**

A [setCategoryAxisType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/axis/#setCategoryAxisType) metódus használatával megadhatja a kívánt kategória tengely típusát (**date** vagy **text**). Ez a Python kód bemutatja a műveletet:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        if isinstance(chart, Chart):
            chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
            chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
            chart.getAxes().getHorizontalAxis().setMajorUnit(1)
            chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)
            presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
        else:
            print("The first shape is not a chart.")
    else:
        print("The presentation has no first shape to update.")
finally:
    presentation.dispose()
```

## **Dátumformátum beállítása a kategória tengely értékeihez**

Az Aspose.Slides for Python via Java lehetővé teszi a dátumformátum beállítását egy kategória tengely értékéhez. A műveletet ez a Python kód mutatja be:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

from datetime import datetime

def convert_to_oa_date(date):
    base_date = datetime(1899, 12, 30)
    return (date - base_date).total_seconds() / 86400


presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 50, 50, 450, 300)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()
    category_date = datetime(2015, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A2", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2016, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A3", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2017, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A4", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2018, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A5", category_value)
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    value_cell = workbook.getCell(0, "B2", 1.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B3", 2.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B4", 3.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B5", 4.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Forgatási szög beállítása a diagram tengelycíméhez**

Az Aspose.Slides for Python via Java lehetővé teszi a diagram tengelycímének forgatási szögének beállítását. Ez a Python kód mutatja be a műveletet:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tengelypozíció beállítása kategória vagy értéktengelyen**

Az Aspose.Slides for Python via Java lehetővé teszi a tengely pozíciójának beállítását egy kategória vagy értéktengelyen. Ez a Python kód bemutatja, hogyan hajtható végre a feladat:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Megjelenítési egység beállítása egy diagram értéktengelyén**

Az Aspose.Slides for Python via Java lehetővé teszi a diagram értéktengely megjelenítési egységének beállítását. A tengely ezután az egységnek megfelelően skálázza a jelölőcímkéket: a [DisplayUnitType.Millions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/displayunittype/#Millions) használatával egy 60 000 000-ig tartó tengely 0–60-ig lesz jelölve. Ez a Python kód mutatja be a műveletet:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Hogyan állíthatom be azt az értéket, ahol egy tengely áthalad a másikon (tengelykereszteződés)?**

A tengelyek [kereszteződés beállítást](https://reference.aspose.com/slides/hu/python-java/aspose.slides/axis/#setCrossType) kínálnak: választhat, hogy a tengely a nullánál, a maximális kategória/értéknél vagy egy adott numerikus értéknél kereszteződjön. Ez hasznos az X-tengely fel vagy le mozgatásához, illetve egy alapvonal hangsúlyozásához.

**Hogyan pozícionálhatom a jelölőket a tengelyhez képest (kereszt, kívül, belül)?**

Állítsa a [jelölő pozícióját](https://reference.aspose.com/slides/hu/python-java/aspose.slides/axis/#setMajorTickMark) „cross”, „outside” vagy „inside” értékre. Ez befolyásolja az olvashatóságot, és segít helyet megtakarítani, különösen kis diagramok esetén.