---
title: Dostosowywanie słupków błędów w wykresach prezentacji w Pythonie
linktitle: Słupek błędu
type: docs
url: /pl/python-net/error-bar/
keywords:
- słupek błędu
- wartość niestandardowa
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak dodawać i dostosowywać słupki błędów w wykresach przy użyciu Aspose.Slides for Python via .NET — optymalizuj wizualizację danych w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z słupkami błędów w wykresach prezentacji przy użyciu Aspose.Slides. Pokazuje, jak dodać słupki błędów do serii wykresu, skonfigurować ustawienia słupków błędów X i Y oraz zastosować różne typy wartości, takie jak stałe, procentowe i niestandardowe.

Demonstruje również, jak przypisać niestandardowe wartości słupków błędów dla poszczególnych punktów danych w serii, używając odpowiedniej kolekcji punktów danych. Dodatkowo artykuł zawiera krótkie informacje o zachowaniu słupków błędów podczas eksportu, ich kompatybilności z markerami i etykietami danych oraz gdzie znaleźć powiązane klasy i wyliczenia w dokumentacji API.

## **Dodaj słupek błędów**
Aspose.Slides for Python via .NET zapewnia prosty interfejs API do zarządzania wartościami słupków błędów. Przykładowy kod ma zastosowanie przy użyciu typu wartości niestandardowej. Aby określić wartość, użyj właściwości **ErrorBarCustomValues** konkretnego punktu danych w kolekcji **DataPoints** serii:

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Dodaj wykres bąbelkowy na wybranym slajdzie.
1. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format słupka błędów X.
1. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format słupka błędów Y.
1. Ustaw wartości i format słupków.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Tworzenie pustej prezentacji
with slides.Presentation() as presentation:
    # Tworzenie wykresu bąbelkowego
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Dodawanie słupków błędów i ustawianie ich formatu
    errBarX = chart.chart_data.series[0].error_bars_x_format
    errBarY = chart.chart_data.series[0].error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.FIXED
    errBarX.value = 0.1
    errBarY.value_type = charts.ErrorBarValueType.PERCENTAGE
    errBarY.value = 5
    errBarX.type = charts.ErrorBarType.PLUS
    errBarY.format.line.width = 2
    errBarX.has_end_cap = True

    # Zapisanie prezentacji
    presentation.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Dodaj niestandardową wartość słupka błędów**
Aspose.Slides for Python via .NET zapewnia prosty interfejs API do zarządzania niestandardowymi wartościami słupków błędów. Przykładowy kod ma zastosowanie, gdy właściwość **IErrorBarsFormat.ValueType** jest równa **Custom**. Aby określić wartość, użyj właściwości **ErrorBarCustomValues** konkretnego punktu danych w kolekcji **DataPoints** serii:

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Dodaj wykres bąbelkowy na wybranym slajdzie.
1. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format słupka błędów X.
1. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format słupka błędów Y.
1. Uzyskaj dostęp do poszczególnych punktów danych serii i ustaw wartości słupka błędów dla pojedynczych punktów danych.
1. Ustaw wartości i format słupków.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Tworzenie pustej prezentacji
with slides.Presentation() as presentation:
    # Tworzenie wykresu bąbelkowego
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Dodawanie niestandardowych słupków błędów i ustawianie ich formatu
    series = chart.chart_data.series[0]
    errBarX = series.error_bars_x_format
    errBarY = series.error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.CUSTOM
    errBarY.value_type = charts.ErrorBarValueType.CUSTOM

    # Uzyskiwanie dostępu do punktu danych serii wykresu i ustawianie wartości słupków błędów dla pojedynczego punktu
    points = series.data_points
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_minus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_minus_values = charts.DataSourceType.DOUBLE_LITERALS

    # Ustawianie słupków błędów dla punktów serii wykresu
    for i in range(len(points)):
        points[i].error_bars_custom_values.x_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.x_plus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_plus.as_literal_double = i + 1

    # Zapisanie prezentacji
    presentation.save("ErrorBarsCustomValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Co się dzieje ze słupkami błędów podczas eksportu prezentacji do PDF lub obrazów?**

Są renderowane jako część wykresu i zachowywane podczas konwersji wraz z resztą formatowania wykresu, o ile używana jest kompatybilna wersja lub renderer.

**Czy słupki błędów można łączyć z markerami i etykietami danych?**

Tak. Słupki błędów są oddzielnym elementem i są kompatybilne z markerami oraz etykietami danych; jeśli elementy nakładają się, może być konieczne dostosowanie formatowania.

**Gdzie mogę znaleźć listę właściwości i wyliczeń do pracy ze słupkami błędów w API?**

W dokumentacji API: klasa [ErrorBarsFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/errorbarsformat/) oraz powiązane wyliczenia [ErrorBarType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/errorbartype/) i [ErrorBarValueType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/errorbarvaluetype/).