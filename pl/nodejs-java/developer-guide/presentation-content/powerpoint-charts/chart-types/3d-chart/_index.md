---
title: Dostosowywanie wykresów 3D w prezentacjach przy użyciu JavaScript
linktitle: Wykres 3D
type: docs
url: /pl/nodejs-java/3d-chart/
keywords:
- wykres 3D
- obrót
- głębokość
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Twórz wykresy 3D w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Node.js via Java. Dostosuj obrót, proporcje wysokości, głębokość wykresu oraz odstępy między seriami przy przykładach JavaScript."
---
## **Przegląd**

Aspose.Slides for Node.js via Java pozwala dostosować widok wykresu 3D przy pomocy metody [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/). Ten artykuł pokazuje, jak regulować obrót, proporcje wysokości, głębokość, osie pod kątem prostym oraz odstępy między seriami, a następnie zapisać prezentację w formacie PPTX.

## **Ustaw obrót i głębokość wykresu 3D**

Poniższy przykład tworzy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) i używa [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) do dodania skumulowanego wykresu słupkowego 3D na pierwszym slajdzie. Zastępuje domyślne serie i kategorie dwoma seriami zawierającymi po trzy wartości. Indeks arkusza `0` identyfikuje pierwszy arkusz danych wykresu; wiersz `0` zawiera nazwy serii, a kolumna `0` etykiety kategorii.

Metody [setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) i [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) ustawiają obrót wykresu na 40 i 270 stopni. [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) ustawia jego głębokość na 150 % szerokości, a [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) włącza osie pod kątem prostym zamiast perspektywy. Powstała prezentacja zawiera wykres z tymi ustawieniami widoku 3D.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    const values = [[20, 50, 30], [30, 10, 60]];

    for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        const categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            const valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dostosuj proporcje wysokości wykresu 3D**

Użyj [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/), aby ustawić wysokość wykresu 3D jako procent jego szerokości. Zmienia to proporcje sceny 3D bez zmiany rozmiaru obiektu wykresu na slajdzie.

Poniższy przykład tworzy wykres [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) z domyślnymi danymi: trzy serie i cztery kategorie. Zapisuje trzy prezentacje z proporcjami wysokości 50 %, 100 % i 200 %. Pozycja, szerokość i wysokość wykresu pozostają niezmienione. Dane, obrót, głębokość, odstępy między seriami i formatowanie są identyczne we wszystkich trzech plikach; zmienia się tylko procent wysokości.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (const heightPercent of [50, 100, 200]) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Poniższe obrazy ilustrują te same ustawienia wysokości w równoważnym przykładzie .NET i zostały wyeksportowane przy użyciu Microsoft PowerPoint. Mniejszy procent tworzy płaską scenę, większy procent – wyższą scenę w tym samym obiekcie wykresu. PowerPoint może także dostosować interwały podziałek osi i rozmieszczenie etykiet, aby dopasować scenę.

| Wysokość: 50% | Wysokość: 100% | Wysokość: 200% |
| --- | --- | --- |
| ![Wykres słupkowy 3D z wysokością ustawioną na 50 % szerokości](height_percent_50.png) | ![Wykres słupkowy 3D z wysokością ustawioną na 100 % szerokości](height_percent_100.png) | ![Wykres słupkowy 3D z wysokością ustawioną na 200 % szerokości](height_percent_200.png) |

Te metody kontrolują różne aspekty wykresu:

| Metoda | Efekt |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | Wysokość sceny 3D wyrażona w procentach jej szerokości. |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | Wysokość obiektu wykresu na slajdzie, w punktach. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Głębokość sceny 3D wyrażona w procentach jej szerokości. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Odstęp między seriami wzdłuż osi głębokości, wyrażony w procentach szerokości znacznika. |

Ustawienie wysokości wpływa na wykresy słupkowe i kolumnowe 3D, w tym warianty cylindryczne, stożkowe i piramidalne, a także wykresy liniowe, powierzchniowe i kołowe 3D. Powyższe porównanie używa zweryfikowanego typu `Column3D`. Ustawienie nie zmienia wyglądu wykresu 2D `ClusteredColumn` ani wykresu `BubbleWith3D`; nazwy te są członkami klasy [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). Inne ustawienia wyglądu wykresu znajdziesz w [Chart Formatting](/slides/pl/nodejs-java/chart-formatting/).

## **Dostosuj odstęp między seriami**

Użyj [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/), aby kontrolować odległość między seriami danych wzdłuż osi głębokości wykresu 3D, wyrażoną w procentach szerokości znacznika. Używaj wartości od **0 do 500**, włącznie: `0` usuwa odstęp, większe wartości zwiększają go. Przy stałej głębokości wykresu zwiększanie odstępu powoduje, że znaczniki są cieńsze wzdłuż osi głębokości.

Uzyskaj grupę poprzez [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/). Ustawienie dotyczy każdej serii w tej grupie, nie tylko serii użytej do uzyskania grupy. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) zwraca aktualny odstęp w głębokości i odzwierciedla ustawienie grupy nadrzędnej.

Ustawienie to wpływa na wykresy słupkowe i kolumnowe 3D, w tym ich warianty cylindryczne, stożkowe i piramidalne, a także wykresy liniowe i powierzchniowe 3D. Wygląd zależy od tego, czy serie są rozmieszczone w głębokości, grupowane czy skumulowane. Do wyraźnego porównania odstępów między oddzielnymi seriami użyj `ChartType.Column3D` z klasy [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/).

Te metody kontrolują różne aspekty wykresu:

| Metoda | Efekt |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Odstęp między seriami wzdłuż osi głębokości, wyrażony w procentach szerokości znacznika. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | Odstęp między sąsiadującymi grupami słupków lub kolumn, wyrażony w procentach ich szerokości. |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Całkowita głębokość wykresu, wyrażona w procentach szerokości wykresu. |

Poniższy samodzielny przykład używa domyślnych danych wykresu, które zawierają trzy serie i cztery kategorie. Zapisuje dwie prezentacje z identycznymi danymi, obrotem, szerokością odstępu i głębokością wykresu; zmienia się jedynie odstęp w głębokości.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    const series = chart.getChartData().getSeries().get_Item(0);
    const group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (const gapDepth of [0, 500]) {
        group.setGapDepth(gapDepth);

        const fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Poniższe obrazy ilustrują te same ustawienia odstępu w równoważnym przykładzie .NET i zostały wyeksportowane przy użyciu Microsoft PowerPoint.

| Odstęp w głębokości: 0% | Odstęp w głębokości: 500% |
| --- | --- |
| ![Wykres słupkowy 3D bez odstępu między seriami wzdłuż osi głębokości](gap_depth_0.png) | ![Wykres słupkowy 3D z 500 % odstępu między seriami wzdłuż osi głębokości](gap_depth_500.png) |

## **Zmień typ serii 3D i kształt słupka**

W wykresie skumulowanym cylindrycznym pierwsza seria zaczyna się od kształtu słupka cylindrycznego. Przykład wypisuje wartości całkowite zwrócone przez [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) i [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) przed i po każdej zmianie. Tabela podaje odpowiadające nazwy stałych.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.ClusteredCylinder, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setType(slides.ChartType.ClusteredCone);
    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(slides.ChartShapeType.Box);
    console.log(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Zmiana w pierwszej serii | Typ serii | Kształt słupka |
| --- | --- | --- |
| Utwórz wykres | `ClusteredCylinder` | `Cylinder` |
| Ustaw typ serii na `ClusteredCone` | `ClusteredCone` | `Cone` |
| Ustaw kształt słupka na `Box` | `ClusteredColumn3D` | `Box` |

Ustawienie kształtu na `Box` zmienia również typ serii na `ClusteredColumn3D`. Jeśli Twój kod rozgałęzia się w zależności od typu serii, wywołaj `series.getType()` po zmianie kształtu. Wartość zbuforowana przed przypisaniem wciąż wybierze gałąź `ClusteredCone`.

![Porównanie w PowerPoint pokazujące pierwszą serię jako cylindry, stożki i prostokątne kolumny od lewej do prawej](series-shapes.png)

## **FAQ**

**Jakie typy wykresów obsługują tryb 3D w Aspose.Slides?**

Aspose.Slides obsługuje 3D‑owe warianty wykresów słupkowych, w tym Column 3D, Clustered Column 3D, Stacked Column 3D oraz 100 % Stacked Column 3D, a także powiązane typy 3D dostępne w klasie [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). Aby uzyskać dokładną i aktualną listę, sprawdź członków [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) w dokumentacji API swojej wersji.

**Czy mogę otrzymać rasterowy obraz wykresu 3D do raportu lub sieci?**

Tak. Możesz wyeksportować wykres jako obraz przy pomocy [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) lub [renderować cały slajd](/slides/pl/nodejs-java/convert-powerpoint-to-png/) do formatów takich jak PNG lub JPEG. Jest to przydatne, gdy potrzebny jest podgląd rastrowy lub chcesz osadzić wykres w dokumentach, pulpitach nawigacyjnych lub stronach internetowych bez konieczności używania PowerPointa.

**Jak wydajna jest budowa i renderowanie dużych wykresów 3D?**

Wydajność zależy od ilości danych i złożoności wizualnej. Aby uzyskać najlepsze wyniki, ogranicz efekty 3D, unikaj ciężkich tekstur na ścianach i obszarach wykresu, minimalizuj liczbę punktów danych w serii, gdy to możliwe, oraz renderuj do odpowiednio dobranego rozmiaru wyjścia (rozdzielczość i wymiary), aby dopasować się do docelowego wyświetlacza lub wymagań drukarskich.