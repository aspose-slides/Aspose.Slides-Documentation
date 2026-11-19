---
title: Dostosuj wykresy 3D w prezentacjach przy użyciu Pythona
linktitle: Wykres 3D
type: docs
url: /pl/python-java/3d-chart/
keywords:
- wykres 3D
- obrót
- głębokość
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Twórz wykresy 3D w prezentacjach PowerPoint przy użyciu Aspose.Slides for Python via Java. Dostosuj obrót, proporcje wysokości, głębokość wykresu oraz odstępy między seriami przy użyciu przykładów w Pythonie."
---
## **Przegląd**

Aspose.Slides for Python via Java umożliwia dostosowanie widoku wykresu 3D za pomocą metody [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D). Ten artykuł pokazuje, jak dostosować obrót, proporcje wysokości, głębokość, osie pod kątem prostym oraz odstępy między seriami, a następnie zapisać prezentację w formacie PPTX.

## **Ustaw obrót i głębokość wykresu 3D**

Przykład poniżej tworzy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) i używa [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) do dodania skumulowanego wykresu kolumnowego 3D na pierwszym slajdzie. Zastępuje domyślne serie i kategorie dwoma seriami zawierającymi po trzy wartości. Indeks arkusza `0` określa pierwszy arkusz danych wykresu; wiersz `0` zawiera nazwy serii, a kolumna `0` zawiera etykiety kategorii.

Metody [setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) i [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) ustawiają obrót wykresu odpowiednio na 40 i 270 stopni. [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) ustawia jego głębokość na 150 % szerokości, natomiast [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) włącza osie pod kątem prostym zamiast perspektywy. Powstała prezentacja zawiera wykres z tymi ustawieniami widoku 3D.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.getCell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.getChartData().getCategories().add(category_cell)

    for series_index in range(2):
        series_cell = workbook.getCell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())

        for category_index in range(3):
            value_cell = workbook.getCell(worksheet_index, category_index + 1, series_index + 1, jpype.JDouble(values[series_index][category_index]))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dostosuj proporcje wysokości wykresu 3D**

Użyj [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents), aby ustawić wysokość wykresu 3D jako procent jego szerokości. Zmienia to proporcje sceny 3D bez zmiany rozmiaru obiektu wykresu na slajdzie.

Poniższy przykład tworzy wykres [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) z domyślnymi danymi: trzy serie i cztery kategorie. Zapisuje trzy prezentacje z proporcjami wysokości 50 %, 100 % i 200 %. Pozycja, szerokość i wysokość wykresu pozostają niezmienione. Dane, obrót, głębokość, odstępy serii i formatowanie są identyczne we wszystkich trzech plikach; jedynie zmienia się procent wysokości.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460)
    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setDepthPercents(100)
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150)

    for height_percent in [50, 100, 200]:
        chart.getRotation3D().setHeightPercents(height_percent)
        presentation.save(f"chart_height_{height_percent}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Poniższe obrazy ilustrują te same ustawienia wysokości w równoważnym przykładzie .NET i zostały wyeksportowane przy użyciu Microsoft PowerPoint. Mniejszy procent generuje płaską scenę, natomiast większy procent tworzy wyższą scenę w tym samym obiekcie wykresu. PowerPoint może także dostosować interwały znaczników osi i rozmieszczenie etykiet, aby dopasować scenę.

| Wysokość: 50% | Wysokość: 100% | Wysokość: 200% |
| --- | --- | --- |
| ![Wykres kolumnowy 3D z wysokością ustawioną na 50 % jego szerokości](height_percent_50.png) | ![Wykres kolumnowy 3D z wysokością ustawioną na 100 % jego szerokości](height_percent_100.png) | ![Wykres kolumnowy 3D z wysokością ustawioną na 200 % jego szerokości](height_percent_200.png) |

Te metody kontrolują różne aspekty wykresu:

| Metoda | Efekt |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | Wysokość sceny 3D wyrażona jako procent jej szerokości. |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | Wysokość obiektu wykresu na slajdzie, w punktach. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Głębokość sceny 3D wyrażona jako procent jej szerokości. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Odstęp między seriami wzdłuż osi głębokości, wyrażony jako procent szerokości markera. |

Ustawienie wysokości wpływa na wykresy kolumnowe i słupkowe 3D, w tym warianty cylinder, stożek i piramida, a także wykresy liniowe, powierzchniowe, kołowe i powierzchniowe 3D. Powyższe porównanie używa zweryfikowanego typu `Column3D`. Ustawienie nie zmienia wyglądu dwuwymiarowego wykresu `ClusteredColumn` ani wykresu `BubbleWith3D`; te nazwy są członkami klasy [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). Aby uzyskać inne ustawienia wyglądu wykresu, zobacz [Formatowanie wykresu](/slides/pl/python-java/chart-formatting/).

## **Dostosuj odstęp między seriami**

Użyj [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth), aby kontrolować odległość między seriami danych wzdłuż osi głębokości wykresu 3D, wyrażoną jako procent szerokości markera. Używaj wartości od **0 do 500**, włącznie: `0` usuwa odstęp, natomiast większe wartości zwiększają odległość. Przy stałej głębokości wykresu zwiększanie odstępu powoduje cieńsze markery wzdłuż osi głębokości.

Dostęp do grupy uzyskuje się poprzez [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup). Ustawienie ma zastosowanie do każdej serii w tej grupie, nie tylko do serii użytej do jej uzyskania. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) zwraca odstęp w głębokości i odzwierciedla ustawienie grupy nadrzędnej.

Ustawienie to wpływa na wykresy kolumnowe i słupkowe 3D, w tym ich warianty cylinder, stożek i piramida, a także wykresy liniowe i powierzchniowe 3D. Wygląd zależy od tego, czy serie są rozmieszczone w głębokości, grupowane czy skumulowane. Aby uzyskać wyraźne porównanie odstępów między oddzielnymi seriami, użyj `ChartType.Column3D` z klasy [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/).

Te metody kontrolują różne aspekty wykresu:

| Metoda | Efekt |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Odstęp między seriami wzdłuż osi głębokości, wyrażony jako procent szerokości markera. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | Odstęp między sąsiednimi grupami słupków lub kolumn, wyrażony jako procent szerokości słupka lub kolumny. |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Całkowita głębokość wykresu, wyrażona jako procent szerokości wykresu. |

Poniższy samodzielny przykład używa domyślnych danych wykresu, które zawierają trzy serie i cztery kategorie. Zapisuje dwie prezentacje z identycznymi danymi, obrotem, szerokością odstępu i głębokością wykresu; jedynie zmienia się odstęp w głębokości.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230)

    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setDepthPercents(100)

    series = chart.getChartData().getSeries().get_Item(0)
    group = series.getParentSeriesGroup()
    group.setGapWidth(150)

    for gap_depth in [0, 500]:
        group.setGapDepth(gap_depth)

        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Poniższe obrazy ilustrują te same ustawienia odstępu w głębokości w równoważnym przykładzie .NET i zostały wyeksportowane przy użyciu Microsoft PowerPoint.

| Gap depth: 0% | Gap depth: 500% |
| --- | --- |
| ![Wykres kolumnowy 3D bez odstępu między seriami wzdłuż osi głębokości](gap_depth_0.png) | ![Wykres kolumnowy 3D z odstępem 500% między seriami wzdłuż osi głębokości](gap_depth_500.png) |

## **Zmień typ serii 3D i kształt słupka**

W wykresie grupowanym cylinder pierwsza seria rozpoczyna się kształtem słupka cylindrycznego. Przykład wypisuje wartości całkowite zwracane przez [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) i [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) przed i po każdej zmianie. Tabela podaje odpowiadające nazwy stałych.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartShapeType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)
    
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setType(ChartType.ClusteredCone)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setBar3DShape(ChartShapeType.Box)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    presentation.save("series_shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Zmiana pierwszej serii | Typ serii | Kształt słupka |
| --- | --- | --- |
| Utwórz wykres | `ClusteredCylinder` | `Cylinder` |
| Ustaw typ serii na `ClusteredCone` | `ClusteredCone` | `Cone` |
| Ustaw kształt słupka na `Box` | `ClusteredColumn3D` | `Box` |

Ustawienie kształtu na `Box` zmienia również typ serii na `ClusteredColumn3D`. Jeśli Twój kod warunkowo zależy od typu serii, wywołaj `series.getType()` po zmianie kształtu. Wartość zbuforowana przed przypisaniem nadal wybrałaby gałąź `ClusteredCone`.

![Porównanie w PowerPoint przedstawiające pierwszą serię jako cylindry, stożki i prostokątne kolumny od lewej do prawej](series-shapes.png)

## **FAQ**

**Jakie typy wykresów obsługują tryb 3D w Aspose.Slides?**

Aspose.Slides obsługuje warianty 3D wykresów kolumnowych, w tym Column 3D, Clustered Column 3D, Stacked Column 3D oraz 100% Stacked Column 3D, wraz z powiązanymi typami 3D udostępnionymi przez klasę [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). Aby uzyskać dokładną, aktualną listę, sprawdź członków [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) w dokumentacji API swojej zainstalowanej wersji.

**Czy mogę uzyskać rastrowy obraz wykresu 3D do raportu lub internetu?**

Tak. Możesz wyeksportować wykres do obrazu przy użyciu [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage), lub [renderowanie całego slajdu](/slides/pl/python-java/convert-powerpoint-to-png/) do formatów takich jak PNG lub JPEG. Jest to przydatne, gdy potrzebny jest podgląd rastrowy lub chcesz osadzić wykres w dokumentach, dashboardach lub stronach internetowych, nie wymagając PowerPointa.

**Jak wydajna jest budowa i renderowanie dużych wykresów 3D?**

Wydajność zależy od wolumenu danych i złożoności wizualnej. Aby uzyskać najlepsze wyniki, utrzymuj efekty 3D na minimalnym poziomie, unikaj ciężkich tekstur na ścianach i obszarach wykresu, ogranicz liczbę punktów danych na serię, gdy to możliwe, oraz renderuj do odpowiednio dobranego rozmiaru wyjściowego (rozdzielczość i wymiary), aby dopasować go do docelowego wyświetlacza lub potrzeb druku.