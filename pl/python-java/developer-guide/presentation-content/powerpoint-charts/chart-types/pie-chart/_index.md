---
title: Dostosowywanie wykresów kołowych w prezentacjach przy użyciu Pythona via Java
linktitle: Wykres kołowy
type: docs
url: /pl/python-java/pie-chart/
keywords:
- wykres kołowy
- zarządzanie wykresem
- dostosowywanie wykresu
- opcje wykresu
- ustawienia wykresu
- opcje wykreślania
- kolor segmentu
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i dostosowywać wykresy kołowe w Pythonie via Java przy użyciu Aspose.Slides, które można eksportować do PowerPointa, zwiększając skuteczność prezentacji danych w kilka sekund."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z wykresami kołowymi w Aspose.Slides. Pokazuje, jak skonfigurować opcje drugiego wykresu dla wykresów Pie of Pie i Bar of Pie oraz jak włączyć automatyczne kolorowanie segmentów dla standardowego wykresu kołowego.

Przykłady koncentrują się na praktycznych krokach dostosowywania wykresu, takich jak dodanie wykresu do slajdu, regulacja ustawień serii i etykiet, zastąpienie domyślnych danych wykresu własnymi kategoriami i wartościami oraz zapis zaktualizowanej prezentacji.

## **Opcje drugiego wykresu dla wykresów Pie of Pie i Bar of Pie**

Aspose.Slides for Python via Java obsługuje opcje drugiego wykresu dla wykresów Pie of Pie i Bar of Pie. Ten rozdział pokazuje, jak określić te opcje przy użyciu Aspose.Slides. Postępuj zgodnie z poniższymi krokami:

1. Utwórz obiekt [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
2. Dodaj wykres do slajdu.
3. Określ drugie opcje wykresu.
4. Zapisz prezentację na dysku.

Poniższy przykład ustawia różne właściwości wykresu typu Pie of Pie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

# Utwórz instancję klasy Presentation.
presentation = Presentation()
try:
    # Dodaj wykres do slajdu.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)

    # Ustaw różne właściwości.
    series = chart.getChartData().getSeries().get_Item(0)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    # Zapisz prezentację na dysku.
    presentation.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ustaw automatyczne kolory fragmentów wykresu kołowego**

Aspose.Slides for Python via Java udostępnia prosty interfejs API do ustawiania automatycznych kolorów segmentów wykresu kołowego. Poniższy przykład pokazuje, jak zastosować te ustawienia.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
2. Uzyskaj dostęp do pierwszego slajdu.
3. Dodaj wykres z domyślnymi danymi.
4. Ustaw tytuł wykresu.
5. Ustaw indeks arkusza danych wykresu.
6. Pobierz skoroszyt danych wykresu.
7. Usuń domyślne serie i kategorie.
8. Dodaj nowe kategorie.
9. Dodaj nową serię.
10. Ustaw, aby nowa seria wyświetlała wartości.

Zapisz zmodyfikowaną prezentację do pliku PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Utwórz instancję klasy Presentation.
presentation = Presentation()
try:
    # Dodaj wykres z domyślnymi danymi.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Ustaw tytuł wykresu.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Ustaw indeks arkusza danych wykresu.
    default_worksheet_index = 0

    # Pobierz skoroszyt danych wykresu.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Usuń domyślne serie i kategorie.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Dodaj nowe kategorie.
    first_category_cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(second_category_cell)
    third_category_cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(third_category_cell)

    # Dodaj nową serię.
    series_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())

    # Wypełnij dane serii.
    first_value_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForPieSeries(first_value_cell)
    second_value_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForPieSeries(second_value_cell)
    third_value_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForPieSeries(third_value_cell)

    # Ustaw, aby nowa seria wyświetlała wartości.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    series.getParentSeriesGroup().setColorVaried(True)
    presentation.save("Pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Czy warianty „Pie of Pie” i „Bar of Pie” są obsługiwane?**

Tak, biblioteka [obsługuje](https://reference.aspose.com/slides/pl/python-java/aspose.slides/charttype/) drugi wykres dla wykresów kołowych, w tym typy „Pie of Pie” i „Bar of Pie”.

**Czy mogę wyeksportować sam wykres jako obraz (na przykład PNG)?**

Tak, możesz [wyeksportować sam wykres jako obraz](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getImage) (np. PNG) bez całej prezentacji.