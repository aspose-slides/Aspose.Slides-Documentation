---
title: Dostosowywanie wykresów 3D w prezentacjach przy użyciu Pythona
linktitle: Wykres 3D
type: docs
url: /pl/python-net/3d-chart/
keywords:
- wykres 3D
- obrót
- głębokość
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Twórz wykresy 3D w prezentacjach PowerPoint przy pomocy Aspose.Slides for Python via .NET. Dostosuj obrót, proporcje wysokości, głębokość wykresu i odstępy między seriami przy użyciu przykładów w Pythonie."
---
## **Przegląd**

Aspose.Slides for Python via .NET umożliwia dostosowanie widoku wykresu 3D za pomocą własności [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/) . Ten artykuł pokazuje, jak dostosować obrót, proporcje wysokości, głębokość, osie pod kątem prostym oraz odstępy między seriami, a następnie zapisać prezentację w formacie PPTX.

## **Ustaw obrót i głębokość wykresu 3D**

Poniższy przykład tworzy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) i używa [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) aby dodać skumulowany wykres kolumnowy 3D do pierwszego slajdu. Zastępuje domyślne serie i kategorie dwoma seriami zawierającymi po trzy wartości. Indeks arkusza `0` określa pierwszy arkusz danych wykresu; wiersz `0` zawiera nazwy serii, a kolumna `0` etykiety kategorii.

Właściwości [rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) i [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) ustawiają obrót wykresu odpowiednio na 40 i 270 stopni. [depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) ustawia jego głębokość na 150% szerokości, natomiast [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) włącza osie pod kątem prostym zamiast perspektywy. Powstała prezentacja zawiera wykres wypełniony danymi z tymi ustawieniami widoku 3D.

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

## **Zastosuj wypełnienie obrazem na powierzchni wykresu 3D**

Możesz niezależnie wypełnić [ściana boczna](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/side_wall/), [ściana tylna](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/), oraz [podłoga](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/) wykresu 3D. Ustaw [typ wypełnienia](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) powierzchni na `PICTURE` i przypisz obraz. Aby dopasować jedną kopię obrazu do powierzchni, ustaw zarówno [tryb wypełnienia obrazem](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) jak i [typ obrazu](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartwall/picture_type/) powierzchni na `STRETCH`.

Zapisz [arrow.png](arrow.png) w katalogu roboczym. Przykład obraca wykres i podnosi maksymalną wartość na osi pionowej, aby podłoga była widoczna między kolumnami. Klonuje slajd dwukrotnie, a następnie aplikuje strzałkę do innej powierzchni na każdym slajdzie. Wszystkie trzy wykresy korzystają z tych samych danych, kąta widzenia i tła.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 20, 30, 680, 480)
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 30
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 24

    back_slide = presentation.slides.add_clone(slide)
    floor_slide = presentation.slides.add_clone(slide)
    back_chart = back_slide.shapes[0]
    floor_chart = floor_slide.shapes[0]

    with open("arrow.png", "rb") as image_file:
        image_bytes = image_file.read()
    arrow = presentation.images.add_image(image_bytes)

    for surface in (chart.side_wall, back_chart.back_wall, floor_chart.floor):
        fill = surface.format.fill
        fill.fill_type = slides.FillType.PICTURE
        fill.picture_fill_format.picture.image = arrow
        fill.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        surface.picture_type = charts.PictureType.STRETCH

    presentation.save("chart-surfaces.pptx", slides.export.SaveFormat.PPTX)
```

Microsoft PowerPoint wyświetla trzy slajdy w następujący sposób.

| Ściana boczna | Ściana tylna | Podłoga |
| --- | --- | --- |
| ![Strzałka wskazująca na wykres wzdłuż ściany bocznej](side-wall.png) | ![Strzałka wskazująca w prawo po ścianie tylnej](back-wall.png) | ![Strzałka wskazująca w prawo po podłodze między kolumnami](floor.png) |

## **Dostosuj proporcje wysokości wykresu 3D**

Użyj [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) aby ustawić wysokość wykresu 3D jako procent jego szerokości. Zmienia to proporcje sceny 3D bez zmiany rozmiaru obiektu wykresu na slajdzie.

Poniższy przykład tworzy wykres [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) z domyślnymi danymi: trzy serie i cztery kategorie. Zapisuje trzy prezentacje z proporcjami wysokości 50%, 100% i 200%. Pozycja, szerokość i wysokość wykresu pozostają stałe. Dane, obrót, głębokość, odstępy serii i formatowanie są identyczne we wszystkich trzech plikach; zmienia się tylko procent wysokości.

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

Poniższe obrazy zostały wyeksportowane z wygenerowanych prezentacji przy użyciu Microsoft PowerPoint. Mniejszy procent daje płaską scenę, natomiast większy procent tworzy wyższą scenę w ramach tego samego obiektu wykresu. PowerPoint może również dostosować przedziały podziałek osi i położenie etykiet, aby dopasować scenę.

| Wysokość: 50% | Wysokość: 100% | Wysokość: 200% |
| --- | --- | --- |
| ![Wykres kolumnowy 3D z wysokością ustawioną na 50% szerokości](height_percent_50.png) | ![Wykres kolumnowy 3D z wysokością ustawioną na 100% szerokości](height_percent_100.png) | ![Wykres kolumnowy 3D z wysokością ustawioną na 200% szerokości](height_percent_200.png) |

Te właściwości kontrolują różne aspekty wykresu:

| Właściwość | Efekt |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | Wysokość sceny 3D jako procent jej szerokości. |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | Wysokość obiektu wykresu na slajdzie, w punktach. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Głębokość sceny 3D jako procent jej szerokości. |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Odstęp między seriami wzdłuż osi głębokości, jako procent szerokości znacznika. |

Ustawienie wysokości wpływa na wykresy kolumnowe i słupkowe 3D, w tym warianty cylindryczne, stożkowe i piramidalne, a także wykresy 3D liniowe, powierzchniowe, kołowe i powierzchniowe. Powyższe porównanie używa zweryfikowanego typu `COLUMN_3D`. Ustawienie nie zmienia wyglądu wykresu 2D `CLUSTERED_COLUMN` ani wykresu `BUBBLE_WITH_3D`; te nazwy są członkami wyliczenia [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Aby uzyskać inne ustawienia wyglądu wykresu, zobacz [Chart Formatting](/slides/pl/python-net/chart-formatting/).

## **Dostosuj odstęp między seriami**

Użyj [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) , aby kontrolować odległość między seriami danych wzdłuż osi głębokości wykresu 3D, wyrażoną jako procent szerokości znacznika. Używaj wartości od **0 do 500**, włącznie: `0` usuwa odstęp, natomiast większe wartości zwiększają odległość. Przy stałej głębokości wykresu zwiększanie odstępu powoduje, że znaczniki są cieńsze wzdłuż osi głębokości.

Uzyskaj dostęp do grupy przez [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/). Ustawienie ma zastosowanie do każdej serii w tej grupie, nie tylko do serii użytej do uzyskania dostępu. [ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) jest tylko do odczytu i odzwierciedla ustawienie grupy nadrzędnej.

To ustawienie wpływa na wykresy kolumnowe i słupkowe 3D, w tym ich warianty cylindryczne, stożkowe i piramidalne, a także wykresy 3D liniowe i powierzchniowe. Wygląd zależy od tego, czy serie są rozmieszczone wzdłuż głębokości, grupowane czy skumulowane. Aby uzyskać wyraźne porównanie odstępów między oddzielnymi seriami, użyj `ChartType.COLUMN_3D` z wyliczenia [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) .

Te właściwości kontrolują różne aspekty wykresu:

| Właściwość | Efekt |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Odstęp między seriami wzdłuż osi głębokości, jako procent szerokości znacznika. |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | Odstęp między sąsiadującymi grupami słupków lub kolumn, jako procent szerokości słupka lub kolumny. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Całkowita głębokość wykresu jako procent szerokości wykresu. |

Poniższy samodzielny przykład używa domyślnych danych wykresu, które zawierają trzy serie i cztery kategorie. Zapisuje dwie prezentacje z identycznymi danymi, obrotem, szerokością odstępu i głębokością wykresu; zmienia się jedynie głębokość odstępu.

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
| ![Wykres kolumnowy 3D bez odstępu między seriami wzdłuż osi głębokości](gap_depth_0.png) | ![Wykres kolumnowy 3D z odstępem 500% między seriami wzdłuż osi głębokości](gap_depth_500.png) |

## **Zmień typ serii 3D i kształt słupka**

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

Ustawienie kształtu na `BOX` zmienia również typ serii na `CLUSTERED_COLUMN_3D`. Jeśli Twój kod rozgałęzia się w zależności od typu serii, odczytaj `series.type` po zmianie kształtu. Wartość zbuforowana przed przypisaniem nadal wybierałaby gałąź `CLUSTERED_CONE`.

![Porównanie w PowerPoint pokazujące pierwszą serię jako cylindry, stożki i prostokątne kolumny od lewej do prawej](series-shapes.png)

## **FAQ**

**Jakie typy wykresów obsługują tryb 3D w Aspose.Slides?**

Aspose.Slides obsługuje warianty 3D wykresów kolumnowych, w tym Column 3D, Clustered Column 3D, Stacked Column 3D i 100% Stacked Column 3D, oraz powiązane typy 3D udostępniane poprzez wyliczenie [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) . Aby uzyskać dokładną, aktualną listę, sprawdź elementy [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) w dokumentacji API swojej zainstalowanej wersji.

**Czy mogę uzyskać rastrowy obraz wykresu 3D do raportu lub internetu?**

Tak. Możesz wyeksportować wykres jako obraz za pomocą [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) lub [renderować cały slajd](/slides/pl/python-net/convert-powerpoint-to-png/) do formatów takich jak PNG lub JPEG. Jest to przydatne, gdy potrzebny jest podgląd rastrowy lub chcesz osadzić wykres w dokumentach, pulpitach nawigacyjnych lub stronach internetowych bez wymogu użycia PowerPoint.

**Jak wydajna jest budowa i renderowanie dużych wykresów 3D?**

Wydajność zależy od objętości danych i złożoności wizualnej. Aby uzyskać najlepsze wyniki, ogranicz efekty 3D, unikaj ciężkich tekstur na ścianach i obszarach wykresu, ogranicz liczbę punktów danych w serii, kiedy to możliwe, oraz renderuj do odpowiednio rozmiaru wyjścia (rozdzielczość i wymiary), aby dopasować je do docelowego wyświetlacza lub potrzeb drukowania.