---
title: Přizpůsobení os grafu v prezentacích pomocí Pythonu
linktitle: Osa grafu
type: docs
url: /cs/python-java/chart-axis/
keywords:
- osa grafu
- vertikální osa
- horizontální osa
- přizpůsobení osy
- manipulace s osou
- správa osy
- vlastnosti osy
- maximální hodnota
- minimální hodnota
- čára osy
- formát data
- název osy
- pozice osy
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Objevte, jak použít Aspose.Slides pro Python via Java k přizpůsobení os grafu v prezentacích PowerPoint pro zprávy a vizualizace."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit osy grafu v Aspose.Slides. Ukazuje, jak získat skutečné hodnoty os, vyměnit data mezi osami, skrýt vertikální nebo horizontální osu u čárových grafů, změnit typ kategoriální osy, nastavit formát data pro hodnoty kategoriální osy, natočit název osy, nastavit pozici osy a nastavit zobrazovací jednotku hodnotové osy.

## **Získání maximálních hodnot na vertikální ose grafu**

Aspose.Slides pro Python via Java umožňuje získat minimální a maximální hodnoty na svislé ose. Postupujte podle těchto kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Získejte první snímek.
1. Přidejte graf s výchozími daty.
1. Získejte skutečnou maximální hodnotu na ose.
1. Získejte skutečnou minimální hodnotu na ose.
1. Získejte skutečnou hlavní jednotku osy.
1. Získejte skutečnou menší jednotku osy.
1. Získejte skutečné měřítko hlavní jednotky osy.
1. Získejte skutečné měřítko menší jednotky osy.

Ukázkový kód — implementace výše uvedených kroků — vám ukazuje, jak získat požadované hodnoty v Pythonu:

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

    # Uloží prezentaci
    presentation.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Výměna dat mezi osami**

Aspose.Slides umožňuje rychle vyměnit data mezi osami — data zobrazená na vertikální ose (y-ose) se přesunou na horizontální osu (x-ose) a naopak.

Tento Python kód vám ukazuje, jak provést výměnu dat mezi osami v grafu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)

    # Načte výchozí data grafu do sešitu — switchRowColumn transponuje sešit, takže je třeba jej nejprve naplnit
    workbook = chart.getChartData().getChartDataWorkbook()

    # Přepne řádky a sloupce
    chart.getChartData().switchRowColumn()

    # Uloží prezentaci
    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zakázání vertikální osy pro čárové grafy**

Tento Python kód vám ukazuje, jak skrýt vertikální osu v čárovém grafu:

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

## **Zakázání horizontální osy pro čárové grafy**

Tento kód vám ukazuje, jak skrýt horizontální osu v čárovém grafu:

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

## **Změna kategoriální osy**

S metodou [setCategoryAxisType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/axis/#setCategoryAxisType) můžete zadat preferovaný typ kategoriální osy (**date** nebo **text**). Tento Python kód demonstruje operaci:

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

## **Nastavení formátu data pro hodnoty kategoriální osy**

Aspose.Slides pro Python via Java umožňuje nastavit formát data pro hodnotu kategoriální osy. Operace je demonstrována v tomto Python kódu:

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

## **Nastavení úhlu otočení názvu osy grafu**

Aspose.Slides pro Python via Java umožňuje nastavit úhel otočení názvu osy grafu. Tento Python kód demonstruje operaci:

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

## **Nastavení pozice osy na kategoriální nebo hodnotové ose**

Aspose.Slides pro Python via Java umožňuje nastavit pozici osy na kategoriální nebo hodnotové ose. Tento Python kód ukazuje, jak úlohu provést:

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

## **Nastavení zobrazovací jednotky na hodnotové ose grafu**

Aspose.Slides pro Python via Java umožňuje nastavit zobrazovací jednotku hodnotové osy grafu. Osa pak měří své popisky značek podle této jednotky: s [DisplayUnitType.Millions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/displayunittype/#Millions) je osa, která jde až do 60,000,000, označena 0 až 60. Tento Python kód demonstruje operaci:

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

## **FAQ**

**Jak nastavit hodnotu, při které se jedna osa protíná s druhou (průsečík osy)?**

Osy poskytují [nastavení průsečíku](https://reference.aspose.com/slides/cs/python-java/aspose.slides/axis/#setCrossType): můžete zvolit průsečík při nule, při maximální kategorii/hodnotě nebo při konkrétní číselné hodnotě. To je užitečné pro posun osy X nahoru nebo dolů či pro zdůraznění referenční čáry.

**Jak mohu umístit značky měřítka relativně k ose (průsečík, vnější, vnitřní)?**

Nastavte [pozici značek měřítka](https://reference.aspose.com/slides/cs/python-java/aspose.slides/axis/#setMajorTickMark) na „cross“, „outside“ nebo „inside“. To ovlivňuje čitelnost a pomáhá šetřit místo, zejména u menších grafů.