---
title: Dostosuj wykresy 3D w prezentacjach przy użyciu Pythona
linktitle: Wykres 3D
type: docs
url: /pl/python-java/3d-chart/
keywords:
- wykres 3D
- rotacja
- głębokość
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i dostosowywać wykresy 3D w Aspose.Slides dla Pythona poprzez Java, z obsługą plików PPT i PPTX - zwiększ jakość swoich prezentacji już dziś."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować wykres 3D w Aspose.Slides poprzez konfigurowanie ustawień [Rotation3D](https://reference.aspose.com/slides/pl/python-java/aspose.slides/rotation3d/) takich jak [setRotationX](https://reference.aspose.com/slides/pl/python-java/aspose.slides/rotation3d/#setRotationX), [setRotationY](https://reference.aspose.com/slides/pl/python-java/aspose.slides/rotation3d/#setRotationY), [setDepthPercents](https://reference.aspose.com/slides/pl/python-java/aspose.slides/rotation3d/#setDepthPercents) oraz [setRightAngleAxes](https://reference.aspose.com/slides/pl/python-java/aspose.slides/rotation3d/#setRightAngleAxes). Przeprowadza krok po kroku proces tworzenia prezentacji, dodawania wykresu 3D z domyślnymi danymi, zastosowania wymaganych ustawień widoku 3D oraz zapisania zmodyfikowanej prezentacji jako pliku PPTX.

## **Ustaw rotację X, rotację Y i głębokość wykresu 3D**
Aspose.Slides dla Pythona poprzez Java udostępnia prosty interfejs API do ustawiania tych właściwości. Poniższy przykład pokazuje, jak ustawić rotację X, rotację Y oraz głębokość wykresu 3D.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Dodaj wykres z danymi domyślnymi.
4. Ustaw właściwości rotacji 3D.
5. Zapisz zmodyfikowaną prezentację do pliku PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    # Uzyskaj dostęp do pierwszego slajdu.
    slide = presentation.getSlides().get_Item(0)

    # Dodaj wykres z danymi domyślnymi.
    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    # Ustaw indeks arkusza danych wykresu.
    default_worksheet_index = 0

    # Pobierz skoroszyt danych wykresu.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Dodaj serie.
    series_cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(series_cell, chart.getType())
    series_cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(series_cell, chart.getType())

    # Dodaj kategorie.
    category_cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(category_cell)

    # Ustaw właściwości rotacji 3D.
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    # Uzyskaj dostęp do drugiej serii wykresu.
    series = chart.getChartData().getSeries().get_Item(1)

    # Wypełnij dane serii.
    data_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 1, 2, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 2, jpype.JInt(10))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 2, jpype.JInt(60))
    series.getDataPoints().addDataPointForBarSeries(data_cell)

    # Zapisz prezentację.
    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Jakie typy wykresów obsługują tryb 3D w Aspose.Slides?**

Aspose.Slides obsługuje 3D warianty wykresów kolumnowych, w tym Column 3D, Clustered Column 3D, Stacked Column 3D oraz 100% Stacked Column 3D, wraz z powiązanymi typami 3D udostępnionymi poprzez klasę [ChartType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/charttype/). Aby uzyskać dokładną, aktualną listę, sprawdź członków [ChartType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/charttype/) w dokumentacji API zainstalowanej wersji.

**Czy mogę uzyskać obraz rastrowy wykresu 3D do raportu lub sieci?**

Tak. Możesz wyeksportować wykres do obrazu za pomocą [chart API](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getImage) lub [renderować cały slajd](/slides/pl/python-java/convert-powerpoint-to-png/) do formatów takich jak PNG lub JPEG. Jest to przydatne, gdy potrzebny jest podgląd w pełni odwzorowujący piksele lub chcesz osadzić wykres w dokumentach, pulpitach nawigacyjnych lub stronach internetowych bez wymogu użycia PowerPointa.

**Jak wydajne jest tworzenie i renderowanie dużych wykresów 3D?**

Wydajność zależy od wielkości danych i złożoności wizualnej. Aby uzyskać najlepsze rezultaty, zachowaj minimalne efekty 3D, unikaj ciężkich tekstur na ścianach i obszarach wykresu, w miarę możliwości ogranicz liczbę punktów danych w serii oraz renderuj do wyjścia o odpowiednich wymiarach (rozdzielczość i rozmiar), aby dopasować je do docelowego wyświetlacza lub wymagań drukowania.