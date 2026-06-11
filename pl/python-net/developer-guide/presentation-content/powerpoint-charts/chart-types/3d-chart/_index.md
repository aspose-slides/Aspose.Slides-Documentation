---
title: Dostosowywanie wykresów 3D w prezentacjach przy użyciu Pythona
linktitle: Wykres 3D
type: docs
url: /pl/python-net/3d-chart/
keywords:
- wykres 3d
- obrót
- głębokość
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i dostosowywać wykresy 3D w Aspose.Slides dla Pythona via .NET, obsługując pliki PPT, PPTX i ODP — podnieś jakość swoich prezentacji już dziś."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować wykres 3D w Aspose.Slides, konfigurować ustawienia `rotation_3d`, takie jak `rotation_x`, `rotation_y`, `depth_percents` i `right_angle_axes`. Przeprowadza krok po kroku przez tworzenie prezentacji, dodawanie wykresu 3D z domyślnymi danymi, zastosowanie wymaganych ustawień widoku 3D oraz zapis zmodyfikowanej prezentacji jako plik PPTX.

## **Ustaw właściwości RotationX, RotationY i DepthPercents wykresu 3D**

Aspose.Slides for Python via .NET udostępnia prosty interfejs API do ustawiania tych właściwości. Poniższy artykuł pomoże Ci ustawić różne właściwości, takie jak rotacja X,Y, **DepthPercents** itp. Przykładowy kod stosuje ustawienie wymienionych powyżej właściwości.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Dodaj wykres z domyślnymi danymi.
4. Ustaw właściwości Rotation3D.
5. Zapisz zmodyfikowaną prezentację do pliku PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Utwórz instancję klasy Presentation
with slides.Presentation() as presentation:
            
    # Uzyskaj dostęp do pierwszego slajdu
    slide = presentation.slides[0]

    # Dodaj wykres z domyślnymi danymi
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    # Ustaw indeks arkusza danych wykresu
    defaultWorksheetIndex = 0

    # Pobieranie arkusza danych wykresu
    fact = chart.chart_data.chart_data_workbook

    # Dodaj serię
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.type)

    # Dodaj kategorie
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"))

    # Ustaw właściwości Rotation3D
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    # Pobierz drugą serię wykresu
    series = chart.chart_data.series[1]

    # Teraz wypełniamy dane serii
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Ustaw wartość OverLap
    series.parent_series_group.overlap = 100         

    # Zapisz prezentację na dysk
    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Które typy wykresów obsługują tryb 3D w Aspose.Slides?**

Aspose.Slides obsługuje warianty 3D wykresów kolumnowych, w tym Column 3D, Clustered Column 3D, Stacked Column 3D i 100% Stacked Column 3D, wraz z powiązanymi typami 3D udostępnionymi przez wyliczenie [ChartType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/charttype/). Aby uzyskać dokładną, aktualną listę, sprawdź członków [ChartType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/charttype/) w dokumentacji API zainstalowanej wersji.

**Czy mogę uzyskać obraz rastrowy wykresu 3D do raportu lub sieci?**

Tak. Możesz wyeksportować wykres do obrazu za pomocą [chart API](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chart/get_image/) lub [render the entire slide](/slides/pl/python-net/convert-powerpoint-to-png/) do formatów takich jak PNG lub JPEG. Jest to przydatne, gdy potrzebujesz podglądu w pełni odzwierciedlającego piksele lub chcesz osadzić wykres w dokumentach, pulpitach nawigacyjnych lub stronach internetowych bez konieczności używania PowerPoint.

**Jak wydajne jest tworzenie i renderowanie dużych wykresów 3D?**

Wydajność zależy od wielkości danych i złożoności wizualnej. Aby uzyskać najlepsze rezultaty, utrzymuj efekty 3D na minimalnym poziomie, unikaj ciężkich tekstur na ścianach i obszarach wykresu, ogranicz liczbę punktów danych w serii, gdy to możliwe, oraz renderuj do wyjścia o odpowiednich rozmiarach (rozdzielczość i wymiary), aby dopasować je do docelowego wyświetlacza lub wymagań drukowania.