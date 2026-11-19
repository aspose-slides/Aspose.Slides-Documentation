---
title: Dostosowywanie wykresów 3D w prezentacjach przy użyciu Pythona
linktitle: Wykres 3D
type: docs
url: /pl/python-net/3d-chart/
keywords:
- wykres 3D
- rotacja
- głębia
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Twórz wykresy 3D w prezentacjach PowerPoint przy użyciu Aspose.Slides for Python via .NET. Reguluj rotację, proporcje wysokości, głębokość wykresu oraz odstępy między seriami przy pomocy przykładów w Pythonie."
---
## **Przegląd**

Aspose.Slides for Python via .NET umożliwia dostosowanie widoku wykresu 3D za pomocą właściwości [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/). Ten artykuł pokazuje, jak regulować rotację, proporcje wysokości, głębokość, osie pod kątem prostym oraz odstępy między seriami, a następnie zapisać prezentację w formacie PPTX.

## **Ustawienie rotacji i głębokości wykresu 3D**

Poniższy przykład tworzy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) i przy użyciu [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) dodaje skumulowany wykres kolumnowy 3D do pierwszego slajdu. Zastępuje domyślne serie i kategorie dwiema seriami zawierającymi po trzy wartości. Indeks arkusza kalkulacyjnego `0` wskazuje pierwszy arkusz danych wykresu; wiersz `0` zawiera nazwy serii, a kolumna `0` zawiera etykiety kategorii.

Właściwości [rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) i [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) ustawiają rotację wykresu odpowiednio na 40 i 270 stopni. [depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) ustawia jego głębokość na 150 % szerokości, a [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) włącza osie pod kątem prostym zamiast perspektywy. Wynikowa prezentacja zawiera wykres z tymi ustawieniami widoku 3D.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    
    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.get_cell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.chart_data.categories.add(category_cell)

    for series_index in range(2):
        series_cell = workbook.get_cell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.chart_data.series.add(series_cell, chart.type)

        for category_index in range(3):
            value_cell = workbook.get_cell(worksheet_index, category_index + 1, series_index + 1, values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Regulowanie proporcji wysokości wykresu 3D**

Użyj [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) aby ustawić wysokość wykresu 3D jako procent jego szerokości. Zmienia to proporcje sceny 3D bez zmiany rozmiaru obiektu wykresu na slajdzie.

Poniższy przykład tworzy wykres [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) z domyślnymi danymi: trzy serie i cztery kategorie. Zapisuje trzy prezentacje z proporcjami wysokości 50 %, 100 % i 200 %. Pozycja, szerokość i wysokość wykresu pozostają stałe. Dane, rotacja, głębokość, odstępy między seriami i formatowanie są identyczne we wszystkich trzech plikach; zmienia się tylko procent wysokości.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 460)
    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.depth_percents = 100
    chart.chart_data.series[0].parent_series_group.gap_depth = 150

    for height_percent in (50, 100, 200):
        chart.rotation_3d.height_percents = height_percent
        presentation.save(f"chart_height_{height_percent}.pptx", slides.export.SaveFormat.PPTX)
```

Poniższe obrazy zostały wyeksportowane z wygenerowanych prezentacji przy użyciu Microsoft PowerPoint. Mniejszy procent powoduje płaską scenę, natomiast większy procent tworzy wyższą scenę w tym samym obiekcie wykresu. PowerPoint może także dostosować interwały znaczników osi i rozmieszczenie etykiet, aby dopasować scenę.

| Wysokość: 50% | Wysokość: 100% | Wysokość: 200% |
| --- | --- | --- |
| ![Wykres kolumnowy 3D z wysokością ustawioną na 50 procent szerokości](height_percent_50.png) | ![Wykres kolumnowy 3D z wysokością ustawioną na 100 procent szerokości](height_percent_100.png) | ![Wykres kolumnowy 3D z wysokością ustawioną na 200 procent szerokości](height_percent_200.png) |

Te właściwości kontrolują różne aspekty wykresu:

| Właściwość | Efekt |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | Wysokość sceny 3D jako procent jej szerokości. |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | Wysokość obiektu wykresu na slajdzie, w punktach. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Głębokość sceny 3D jako procent jej szerokości. |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Odstęp między seriami wzdłuż osi głębokości, jako procent szerokości markera. |

Ustawienie wysokości wpływa na wykresy kolumnowe i słupkowe 3D, w tym warianty cylindryczne, stożkowe i piramidowe, a także wykresy 3D liniowe, powierzchniowe, kołowe i powierzchniowe. Powyższe porównanie używa zweryfikowanego typu `COLUMN_3D`. Ustawienie nie zmienia wyglądu dwuwymiarowego wykresu `CLUSTERED_COLUMN` ani wykresu `BUBBLE_WITH_3D`; te nazwy są elementami wyliczenia [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Aby uzyskać inne ustawienia wyglądu wykresu, zobacz [Chart Formatting](/slides/pl/python-net/chart-formatting/).

## **Regulowanie odstępu między seriami**

Użyj [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) aby kontrolować odległość między seriami danych wzdłuż osi głębokości wykresu 3D, wyrażoną jako procent szerokości markera. Używaj wartości od **0 do 500**, włącznie: `0` usuwa odstęp, a większe wartości zwiększają odstęp. Przy stałej głębokości wykresu zwiększanie odstępu powoduje, że markery są cieńsze wzdłuż osi głębokości.

Dostęp do grupy uzyskuje się przez [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/). Ustawienie ma zastosowanie do każdej serii w tej grupie, nie tylko do serii użytej do uzyskania dostępu. [ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) jest tylko do odczytu i odzwierciedla ustawienie grupy nadrzędnej.

To ustawienie wpływa na wykresy kolumnowe i słupkowe 3D, w tym ich warianty cylindryczne, stożkowe i piramidowe, a także wykresy 3D liniowe i powierzchniowe. Wygląd zależy od tego, czy serie są rozmieszczone w głębokości, grupowane czy skumulowane. Aby uzyskać wyraźne porównanie odstępów między oddzielnymi seriami, użyj `ChartType.COLUMN_3D` z wyliczenia [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/).

Te właściwości kontrolują różne aspekty wykresu:

| Właściwość | Efekt |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Odstęp między seriami wzdłuż osi głębokości, jako procent szerokości markera. |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | Odstęp między sąsiadującymi grupami słupków lub kolumn, jako procent szerokości słupka lub kolumny. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Całkowita głębokość wykresu, jako procent szerokości wykresu. |

Poniższy samodzielny przykład używa domyślnych danych wykresu, które zawierają trzy serie i cztery kategorie. Zapisuje dwie prezentacje z identycznymi danymi, rotacją, szerokością odstępu i głębokością wykresu; zmienia się tylko głębokość odstępu.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 230)

    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.depth_percents = 100

    series = chart.chart_data.series[0]
    group = series.parent_series_group
    group.gap_width = 150

    for gap_depth in (0, 500):
        group.gap_depth = gap_depth
        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

Poniższe obrazy zostały wyeksportowane z wygenerowanych prezentacji przy użyciu Microsoft PowerPoint.

| Głębokość odstępu: 0% | Głębokość odstępu: 500% |
| --- | --- |
| ![Wykres kolumnowy 3D bez odstępu między seriami wzdłuż osi głębokości](gap_depth_0.png) | ![Wykres kolumnowy 3D z 500 procentowym odstępem między seriami wzdłuż osi głębokości](gap_depth_500.png) |

## **Zmiana typu serii 3D i kształtu słupka**

W wykresie grupowanym cylindrycznym pierwsza seria zaczyna się od słupków cylindrycznych. Przykład odczytuje [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) i [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/) przed i po każdej zmianie.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_CYLINDER, 20, 20, 500, 300)
    series = chart.chart_data.series[0]
    
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.type = charts.ChartType.CLUSTERED_CONE
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.bar_3d_shape = charts.ChartShapeType.BOX
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    presentation.save("series_shape.pptx", slides.export.SaveFormat.PPTX)
```

| Zmiana pierwszej serii | `type` | `bar_3d_shape` |
| --- | --- | --- |
| Utwórz wykres | `CLUSTERED_CYLINDER` | `CYLINDER` |
| Ustaw `type` na `CLUSTERED_CONE` | `CLUSTERED_CONE` | `CONE` |
| Ustaw `bar_3d_shape` na `BOX` | `CLUSTERED_COLUMN_3D` | `BOX` |

Ustawienie kształtu na `BOX` zmienia również typ serii na `CLUSTERED_COLUMN_3D`. Jeśli Twój kod rozgałęzia się w zależności od typu serii, odczytaj `series.type` po zmianie kształtu. Wartość zbuforowana przed przypisaniem nadal wybrałaby gałąź `CLUSTERED_CONE`.

![Porównanie w PowerPoint pokazujące pierwszą serię jako cylindry, stożki i prostokątne kolumny od lewej do prawej](series-shapes.png)

## **FAQ**

**Jakie typy wykresów obsługują tryb 3D w Aspose.Slides?**

Aspose.Slides obsługuje warianty 3D wykresów kolumnowych, w tym Column 3D, Clustered Column 3D, Stacked Column 3D i 100 % Stacked Column 3D, wraz z powiązanymi typami 3D udostępnionymi w wyliczeniu [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Aby uzyskać dokładną, aktualną listę, sprawdź członków [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) w dokumentacji API zainstalowanej wersji.

**Czy mogę uzyskać obraz rastrowy wykresu 3D do raportu lub sieci?**

Tak. Możesz wyeksportować wykres jako obraz przy użyciu [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) lub [renderować cały slajd](/slides/pl/python-net/convert-powerpoint-to-png/) do formatów takich jak PNG lub JPEG. Jest to przydatne, gdy potrzebujesz podglądu rastrowego lub chcesz osadzić wykres w dokumentach, pulpitach nawigacyjnych lub stronach internetowych bez wymogu użycia PowerPoint.

**Jak wydajna jest budowa i renderowanie dużych wykresów 3D?**

Wydajność zależy od wielkości danych i złożoności wizualnej. Aby uzyskać najlepsze rezultaty, ogranicz efekty 3D do minimum, unikaj ciężkich tekstur na ścianach i obszarach wykresu, ogranicz liczbę punktów danych w serii, gdy to możliwe, oraz renderuj do odpowiednio rozmiaru wyjścia (rozdzielczości i wymiarów), aby dopasować je do docelowego wyświetlacza lub potrzeb drukowania.