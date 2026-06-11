---
title: Dostosowywanie osi wykresu w prezentacjach przy użyciu Pythona
linktitle: Oś wykresu
type: docs
url: /pl/python-net/chart-axis/
keywords:
- oś wykresu
- pionowa oś
- pozioma oś
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
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Odkryj, jak używać Aspose.Slides for Python via .NET do dostosowywania osi wykresów w prezentacjach PowerPoint i OpenDocument dla raportów i wizualizacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować osie wykresu w Aspose.Slides. Pokazuje, jak uzyskać rzeczywiste wartości osi, zamienić dane między osiami, ukryć pionową lub poziomą oś w wykresach liniowych, zmienić typ osi kategorii, ustawić format daty dla wartości osi kategorii, obrócić tytuł osi, ustawić pozycję osi oraz wyświetlić etykietę jednostki na osi wartości.

## **Uzyskiwanie maksymalnych wartości na pionowej osi w wykresach**

Aspose.Slides for Python via .NET umożliwia pobranie minimalnych i maksymalnych wartości na pionowej osi. Wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj dostęp do pierwszego slajdu.
1. Dodaj wykres z danymi domyślnymi.
1. Pobierz rzeczywistą maksymalną wartość na osi.
1. Pobierz rzeczywistą minimalną wartość na osi.
1. Pobierz rzeczywistą jednostkę główną osi.
1. Pobierz rzeczywistą jednostkę pomocniczą osi.
1. Pobierz rzeczywistą skalę jednostki głównej osi.
1. Pobierz rzeczywistą skalę jednostki pomocniczej osi.

Ten przykładowy kod — implementacja powyższych kroków — pokazuje, jak uzyskać wymagane wartości w Pythonie:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
	chart.validate_chart_layout()

	maxValue = chart.axes.vertical_axis.actual_max_value
	minValue = chart.axes.vertical_axis.actual_min_value

	majorUnit = chart.axes.horizontal_axis.actual_major_unit
	minorUnit = chart.axes.horizontal_axis.actual_minor_unit
	
	# Zapisuje prezentację
	pres.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Zamiana danych między osiami**

Aspose.Slides umożliwia szybkie zamienienie danych między osiami — dane przedstawione na pionowej osi (oś y) przenoszone są na poziomą oś (oś x) i odwrotnie.

Ten kod w Pythonie pokazuje, jak wykonać zamianę danych między osiami na wykresie:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Tworzy pustą prezentację
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    #Zamienia wiersze i kolumny
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Wyłączanie pionowej osi w wykresach liniowych**

Ten kod w Pythonie pokazuje, jak ukryć pionową oś w wykresie liniowym:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```

## **Wyłączanie poziomej osi w wykresach liniowych**

Ten kod pokazuje, jak ukryć poziomą oś w wykresie liniowym:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```

## **Zmiana osi kategorii**

Korzystając z właściwości **CategoryAxisType**, możesz określić preferowany typ osi kategorii (**date** lub **text**). Ten kod w Pythonie demonstruje tę operację:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS
    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustawianie formatu daty dla wartości osi kategorii**

Aspose.Slides for Python via .NET umożliwia ustawienie formatu daty dla wartości osi kategorii. Operacja jest przedstawiona w tym kodzie w Pythonie:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
from datetime import date

def to_oadate(dt):
    delta = dt - date(1899, 12, 30)
    return delta.days + (delta.seconds + delta.microseconds / 1e6) / (24 * 3600)

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 50, 50, 450, 300)

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    chart.chart_data.categories.add(wb.get_cell(0, "A2", to_oadate(date(2015, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", to_oadate(date(2016, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", to_oadate(date(2017, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", to_oadate(date(2018, 1, 1))))

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B2", 1))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B3", 2))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B4", 3))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B5", 4))
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"
    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustawianie kąta obrotu tytułu osi wykresu**

Aspose.Slides for Python via .NET umożliwia ustawienie kąta obrotu tytułu osi wykresu. Ten kod w Pythonie demonstruje tę operację:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustawianie pozycji osi w osi kategorii lub wartości**

Aspose.Slides for Python via .NET umożliwia ustawienie pozycji osi w osi kategorii lub wartości. Ten kod w Pythonie pokazuje, jak wykonać to zadanie:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Włączanie wyświetlania etykiety jednostki na osi wartości wykresu**

Aspose.Slides for Python via .NET umożliwia skonfigurowanie wykresu tak, aby wyświetlał etykietę jednostki na osi wartości wykresu. Ten kod w Pythonie demonstruje tę operację:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Jak ustawić wartość, w której jedna oś przecina drugą (przecięcie osi)?**

Osie oferują [ustawienie przecięcia](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/axis/cross_type/): możesz wybrać przecięcie w zerze, przy maksymalnej kategorii/wartości lub w określonej wartości liczbowej. Jest to przydatne przy przesuwaniu osi X w górę lub w dół lub podkreślaniu linii bazowej.

**Jak mogę pozycjonować etykiety znaczników względem osi (obok, na zewnątrz, wewnątrz)?**

Ustaw [pozycję etykiety](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/axis/major_tick_mark/) na "cross", "outside" lub "inside". Ma to wpływ na czytelność i pomaga oszczędzać miejsce, szczególnie w małych wykresach.