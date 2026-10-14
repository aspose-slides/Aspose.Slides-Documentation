---
title: Dostosowywanie wykresów kołowych w prezentacjach przy użyciu Python via Java
linktitle: Wykres kołowy
type: docs
url: /pl/python-java/pie-chart/
keywords:
- wykres kołowy
- zarządzanie wykresem
- dostosowywanie wykresu
- opcje wykresu
- ustawienia wykresu
- opcje wykresu
- kolor wycinka
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Utwórz i dostosuj wykresy kołowe w Python via Java przy użyciu Aspose.Slides. Skonfiguruj wykresy drugorzędne, wyświetlaj etykiety danych i zastosuj automatyczne kolory wycinków w PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z wykresami kołowymi w Aspose.Slides. Pokazuje, jak skonfigurować opcje drugorzędnego wykresu dla wykresów Pie of Pie i Bar of Pie oraz jak włączyć automatyczne kolorowanie wycinków w standardowym wykresie kołowym.

Przykłady koncentrują się na zadaniach dostosowywania wykresu, takich jak dodawanie wykresu do slajdu, dostosowywanie ustawień serii i etykiet, zastępowanie domyślnych danych wykresu własnymi kategoriami i wartościami oraz zapisywanie zaktualizowanej prezentacji.

## **Opcje drugiego wykresu dla wykresów Pie of Pie i Bar of Pie**

Aspose.Slides for Python via Java obsługuje opcje drugorzędnego wykresu dla wykresów Pie of Pie i Bar of Pie. Opcje te kontrolują rozmiar wykresu drugiego oraz sposób podziału punktów danych pomiędzy dwa wykresy.

Poniższy przykład tworzy wykres Pie of Pie w nowej prezentacji i wyświetla wartości punktów danych jako etykiety. Metoda [setSecondPieSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setSecondPieSize) ustawia rozmiar drugiego wykresu na 149% głównego wykresu, [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) wybiera podział oparty na procentach, a [setPieSplitPosition](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) ustawia próg na 53%.

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

    # Wyświetl wartości i skonfiguruj wykres drugorzędny.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Wybierz kategorie dla drugiego wykresu**

Użyj podziału niestandardowego, gdy chcesz grupować określone kategorie w drugorzędnym wykresie bez względu na ich wartości procentowe. Na przykład raport sprzedaży może wyświetlać Online i Events razem, aby czytelnicy mogli porównać te dwa kanały, mimo że stanowią one 35% i 10% całkowitej sprzedaży.

Wywołaj [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) z [PieSplitType.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/piesplittype/#Custom) i wybierz punkty za pomocą [getPieSplitCustomPoints](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). Metoda [add](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#add) kolekcji przyjmuje indeks zerowy w serii; użyj [addItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#addItem), aby dodać obiekt punktu danych. W tym przykładzie indeks 1 wybiera Online, a punkt o indeksie 3 wybiera Events. Partners jest również dodany tymczasowo, a następnie wykluczony przy użyciu [removeItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#removeItem).

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

    # Zastąp domyślne dane sprzedażą według kanału.
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

    # Wybierz Online według jego indeksu zerowego oraz Events według obiektu punktu danych.
    series_group.getPieSplitCustomPoints().add(1)
    series_group.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3))

    # Wyklucz Partners z wyboru bez usuwania jego danych źródłowych.
    series_group.getPieSplitCustomPoints().add(2)
    series_group.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2))

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Online (35) i Events (10) pojawiają się jako osobne wycinki w drugorzędnym wykresie. W głównym wykresie są reprezentowane przez jeden połączony wycinek o wartości 45, obok Retail (40) i Partners (15). Usunięcie Partners z wyboru niestandardowego pozostawia go w głównym wykresie; nie usuwa to kategorii ani jej wartości z danych źródłowych wykresu.

Poniższy obrazek przedstawia zapisaną prezentację w programie PowerPoint:

![Pie of Pie chart with Online and Events in the secondary plot and their combined value of 45 in the primary plot](pie_of_pie_custom.png)

## **Ustaw automatyczne kolory wycinków wykresu kołowego**

Aspose.Slides for Python via Java może automatycznie przydzielać różne kolory wycinkom wykresu kołowego. Poniższy przykład tworzy wykres kołowy z wyśrodkowanym tytułem i zastępuje domyślne dane trzema kwartalnymi kategoriami oraz ich wartościami. Metoda [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) wyświetla wartości 20, 50 i 30 jako etykiety, natomiast [setColorVaried](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setColorVaried) włącza odrębny kolor dla każdego wycinka.

```python
import jpype
import asposeslides

if not jpame.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Dodaj wyśrodkowany tytuł wykresu.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Zastąp domyślne dane, używając pierwszego arkusza.
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

    # Pokaż wartości i przydziel różne kolory wycinkom.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getParentSeriesGroup().setColorVaried(True)

    presentation.save("pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Czy warianty Pie of Pie i Bar of Pie są obsługiwane?**

Tak, biblioteka [obsługuje](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) drugorzędny wykres dla wykresów kołowych, w tym typy Pie of Pie i Bar of Pie.

**Czy mogę wyeksportować sam wykres jako obraz (na przykład PNG)?**

Tak, możesz [wyeksportować sam wykres jako obraz](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) (np. PNG) bez eksportowania całej prezentacji.