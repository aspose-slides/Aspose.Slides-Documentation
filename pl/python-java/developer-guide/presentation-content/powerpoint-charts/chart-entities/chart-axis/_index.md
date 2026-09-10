---
title: Dostosowywanie osi wykresu w prezentacjach przy użyciu Pythona
linktitle: Oś wykresu
type: docs
url: /pl/python-java/chart-axis/
keywords:
- oś wykresu
- oś pionowa
- oś pozioma
- dostosowywanie osi
- manipulowanie osią
- zarządzanie osią
- właściwości osi
- wartość maksymalna
- wartość minimalna
- linia osi
- format daty
- tytuł osi
- pozycja osi
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak używać Aspose.Slides for Python via Java do dostosowywania osi wykresów w prezentacjach PowerPointa dla raportów i wizualizacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować osie wykresu w Aspose.Slides. Pokazuje, jak uzyskać rzeczywiste wartości osi, zamienić dane między osiami, ukryć pionową lub poziomą oś w wykresach liniowych, zmienić typ osi kategorii, ustawić format daty dla wartości osi kategorii, obrócić tytuł osi, ustawić pozycję osi oraz ustawić jednostkę wyświetlania osi wartości.

## **Uzyskaj maksymalne wartości na pionowej osi wykresu**

Aspose.Slides for Python via Java pozwala uzyskać minimalne i maksymalne wartości na pionowej osi. Postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Dodaj wykres z domyślnymi danymi.
4. Pobierz rzeczywistą maksymalną wartość na osi.
5. Pobierz rzeczywistą minimalną wartość na osi.
6. Pobierz rzeczywistą główną jednostkę osi.
7. Pobierz rzeczywistą podrzędną jednostkę osi.
8. Pobierz rzeczywistą skalę głównej jednostki osi.
9. Pobierz rzeczywistą skalę podrzędnej jednostki osi.

Ten przykładowy kod — implementacja powyższych kroków — pokazuje, jak uzyskać wymagane wartości w języku Python:

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

    # Zapisuje prezentację
    presentation.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zamień dane pomiędzy osiami**

Aspose.Slides umożliwia szybkie zamienienie danych pomiędzy osiami — dane przedstawione na pionowej osi (y) przenoszone są na poziomą oś (x) i odwrotnie.

Ten kod w Pythonie pokazuje, jak wykonać zamianę danych między osiami na wykresie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)

    # Ładuje domyślne dane wykresu do skoroszytu — switchRowColumn transponuje skoroszyt,
    # tak więc musi być najpierw wypełniony
    workbook = chart.getChartData().getChartDataWorkbook()

    # Zamienia wiersze i kolumny
    chart.getChartData().switchRowColumn()

    # Zapisuje prezentację
    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Wyłącz pionową oś w wykresach liniowych**

Ten kod w Pythonie pokazuje, jak ukryć pionową oś w wykresie liniowym:

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

## **Wyłącz poziomą oś w wykresach liniowych**

Ten kod pokazuje, jak ukryć poziomą oś w wykresie liniowym:

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

## **Zmień oś kategorii**

Używając metody [setCategoryAxisType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/axis/#setCategoryAxisType) możesz określić preferowany typ osi kategorii (**date** lub **text**). Ten kod w Pythonie demonstruje tę operację:

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

## **Ustaw format daty dla wartości osi kategorii**

Aspose.Slides for Python via Java pozwala ustawić format daty dla wartości osi kategorii. Operacja jest przedstawiona w tym kodzie w Pythonie:

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

## **Ustaw kąt obrotu tytułu osi wykresu**

Aspose.Slides for Python via Java pozwala ustawić kąt obrotu tytułu osi wykresu. Ten kod w Pythonie demonstruje tę operację:

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

## **Ustaw pozycję osi na osi kategorii lub wartości**

Aspose.Slides for Python via Java pozwala ustawić pozycję osi na osi kategorii lub wartości. Ten kod w Pythonie pokazuje, jak wykonać to zadanie:

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

## **Ustaw jednostkę wyświetlania na osi wartości wykresu**

Aspose.Slides for Python via Java pozwala ustawić jednostkę wyświetlania osi wartości wykresu. Oś skaluje wtedy swoje etykiety podziałek według tej jednostki: przy [DisplayUnitType.Millions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/displayunittype/#Millions), oś dochodząca do 60 000 000 jest oznaczona od 0 do 60. Ten kod w Pythonie demonstruje tę operację:

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

**Jak ustawić wartość, w której jedna oś przecina drugą (przecięcie osi)?**

Osie oferują [ustawienie przecięcia](https://reference.aspose.com/slides/pl/python-java/aspose.slides/axis/#setCrossType): możesz wybrać przecięcie w zerze, w maksymalnej kategorii/wartości lub w określonej wartości liczbowej. Jest to przydatne do przesuwania osi X w górę lub w dół lub do podkreślenia linii bazowej.

**Jak mogę ustawić pozycję znaczników podziałek względem osi (przecięcie, na zewnątrz, wewnątrz)?**

Ustaw [pozycję znaczników podziałek](https://reference.aspose.com/slides/pl/python-java/aspose.slides/axis/#setMajorTickMark) na „cross”, „outside” lub „inside”. Ma to wpływ na czytelność i pomaga oszczędzać miejsce, szczególnie w małych wykresach.