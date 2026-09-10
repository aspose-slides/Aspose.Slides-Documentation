---
title: Dostosuj słupki błędów w wykresach prezentacji przy użyciu Pythona
linktitle: Słupki błędów
type: docs
url: /pl/python-java/error-bar/
keywords:
- słupki błędów
- wartość niestandardowa
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Dowiedz się, jak dodawać i dostosowywać słupki błędów w wykresach przy użyciu Aspose.Slides dla Pythona via Java — optymalizuj wizualizacje danych w prezentacjach PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z słupkami błędów w wykresach prezentacji przy użyciu Aspose.Slides. Pokazuje, jak dodać słupki błędów do serii wykresu, skonfigurować ustawienia słupków błędów X i Y oraz zastosować różne typy wartości, takie jak stałe, procentowe i niestandardowe.

Pokazuje również, jak przypisać własne wartości słupków błędów dla pojedynczych punktów danych w serii, używając odpowiedniej kolekcji punktów danych. Dodatkowo artykuł zawiera krótkie uwagi na temat zachowania słupków błędów podczas eksportu, ich kompatybilności ze znacznikami i etykietami danych oraz gdzie znaleźć powiązane klasy i wyliczenia w dokumentacji API.

## **Dodaj słupki błędów**

Aspose.Slides for Python via Java udostępnia prosty interfejs API do zarządzania wartościami słupków błędów. Poniższy przykładowy kod wykorzystuje typy wartości stałej i procentowej.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Dodaj wykres bąbelkowy do wybranego slajdu.
3. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format słupka błędów X.
4. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format słupka błędów Y.
5. Ustaw wartości i formatowanie słupków błędów.
6. Zapisz zmodyfikowaną prezentację do pliku PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Utwórz instancję klasy Presentation.
presentation = Presentation()
try:
    # Utwórz wykres bąbelkowy.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # Dodaj słupki błędów i ustaw ich formatowanie.
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

    # Zapisz prezentację.
    presentation.save("ErrorBars.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dodaj własne wartości słupków błędów**

Aspose.Slides for Python via Java udostępnia prosty interfejs API do zarządzania własnymi wartościami słupków błędów. Poniższy przykładowy kod ma zastosowanie, gdy [getValueType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/errorbarsformat/#getValueType) zwraca [ErrorBarValueType.Custom](https://reference.aspose.com/slides/pl/python-java/aspose.slides/errorbarvaluetype/#Custom). Aby określić wartość, użyj [getErrorBarsCustomValues](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatapoint/#getErrorBarsCustomValues) dla konkretnego punktu danych w kolekcji zwróconej przez metodę serii [getDataPoints](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseries/#getDataPoints).

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Dodaj wykres bąbelkowy do wybranego slajdu.
3. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format słupka błędów X.
4. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format słupka błędów Y.
5. Uzyskaj dostęp do indywidualnych punktów danych w serii wykresu i ustaw ich wartości słupków błędów.
6. Ustaw wartości i formatowanie słupków błędów.
7. Zapisz zmodyfikowaną prezentację do pliku PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Utwórz instancję klasy Presentation.
presentation = Presentation()
try:
    # Utwórz wykres bąbelkowy.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # Dodaj własne słupki błędów i ustaw ich formatowanie.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()
    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Custom)
    error_bar_y.setValueType(ErrorBarValueType.Custom)

    # Uzyskaj dostęp do punktów danych serii wykresu i skonfiguruj ich źródła wartości słupków błędów.
    points = series.getDataPoints()
    data_source = points.getDataSourceTypeForErrorBarsCustomValues()
    data_source.setDataSourceTypeForXPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForXMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))

    # Ustaw wartości słupków błędów dla punktów danych serii wykresu.
    for i in range(points.size()):
        custom_values = points.get_Item(i).getErrorBarsCustomValues()
        custom_values.getXMinus().setAsLiteralDouble(i + 1)
        custom_values.getXPlus().setAsLiteralDouble(i + 1)
        custom_values.getYMinus().setAsLiteralDouble(i + 1)
        custom_values.getYPlus().setAsLiteralDouble(i + 1)

    # Zapisz prezentację.
    presentation.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Co się dzieje ze słupkami błędów podczas eksportowania prezentacji do PDF lub obrazów?**

Są renderowane jako część wykresu i zachowywane podczas konwersji wraz z resztą formatowania wykresu, zakładając użycie kompatybilnej wersji lub renderera.

**Czy słupki błędów mogą być łączone ze znacznikami i etykietami danych?**

Tak. Słupki błędów są osobnym elementem i są kompatybilne ze znacznikami i etykietami danych; jeśli elementy zachodzą na siebie, może być konieczne dostosowanie formatowania.

**Gdzie mogę znaleźć listę właściwości i klas do pracy ze słupkami błędów w API?**

W dokumentacji API: klasa [ErrorBarsFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/errorbarsformat/) oraz powiązane klasy [ErrorBarType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/errorbartype/) i [ErrorBarValueType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/errorbarvaluetype/).