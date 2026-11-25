---
title: Dostosowywanie wykresów 3D w prezentacjach przy użyciu JavaScript
linktitle: Wykres 3D
type: docs
url: /pl/nodejs-java/3d-chart/
keywords:
- Wykres 3D
- obrót
- głębokość
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Twórz wykresy 3D w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Node.js via Java. Reguluj obrót, proporcje wysokości, głębokość wykresu oraz odstępy między seriami przy pomocy przykładów w JavaScript."
---
## **Przegląd**

Aspose.Slides for Node.js via Java umożliwia dostosowanie widoku wykresu 3D za pomocą metody [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/). Ten artykuł pokazuje, jak regulować obrót, proporcje wysokości, głębokość, osie pod kątem prostym oraz odstępy między seriami, a następnie zapisać prezentację w formacie PPTX.

## **Ustaw obrót i głębokość wykresu 3D**

Poniższy przykład tworzy obiekt [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) i używa [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) do dodania wykresu słupkowego 3D skumulowanego na pierwszym slajdzie. Zastępuje domyślne serie i kategorie dwiema seriami, z których każda zawiera trzy wartości. Indeks arkusza `0` identyfikuje pierwszy arkusz danych wykresu; wiersz `0` zawiera nazwy serii, a kolumna `0` – etykiety kategorii.

Metody [setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) i [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) ustawiają obrót wykresu odpowiednio na 40 i 270 stopni. [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) ustawia jego głębokość na 150 % szerokości, a [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) włącza osie pod kątem prostym zamiast perspektywy. Wynikowa prezentacja zawiera wykres z tymi ustawieniami widoku 3D.

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

## **Zastosuj wypełnienie obrazem na powierzchni wykresu 3D**

Można oddzielnie wypełnić [side wall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getsidewall/), [back wall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getbackwall/) i [floor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getfloor/) wykresu 3D. Ustaw typ wypełnienia powierzchni na [fill type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) `Picture` i przypisz obraz. Ustaw zarówno [picture fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/setpicturefillmode/), jak i [picture type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartwall/setpicturetype/) powierzchni na `Stretch`, aby jedna kopia obrazu rozciągnęła się na całą powierzchnię.

Zapisz plik [arrow.png](arrow.png) w katalogu roboczym. Przykład obraca wykres i podnosi maksymalną wartość na osi pionowej, aby podłoga była widoczna między kolumnami. Następnie klonuje slajd dwukrotnie i nakłada strzałkę na inną powierzchnię w każdym slajdzie. Wszystkie trzy wykresy zachowują te same dane, kąt widzenia i tło.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    const backSlide = presentation.getSlides().addClone(slide);
    const floorSlide = presentation.getSlides().addClone(slide);
    const backChart = backSlide.getShapes().get_Item(0);
    const floorChart = floorSlide.getShapes().get_Item(0);

    const image = slides.Images.fromFile("arrow.png");
    try {
        const arrow = presentation.getImages().addImage(image);
        const surfaces = [chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor()];
        for (const surface of surfaces) {
            const fill = surface.getFormat().getFill();
            fill.setFillType(java.newByte(slides.FillType.Picture));
            const pictureFill = fill.getPictureFillFormat();
            pictureFill.getPicture().setImage(arrow);
            pictureFill.setPictureFillMode(slides.PictureFillMode.Stretch);
            surface.setPictureType(slides.PictureType.Stretch);
        }
    } finally {
        image.dispose();
    }

    presentation.save("chart-surfaces.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint wyświetla trzy slajdy w następujący sposób.

| Ściana boczna | Ściana tylna | Podłoga |
| --- | --- | --- |
| ![Strzałka wskazująca na wykres wzdłuż ściany bocznej](side-wall.png) | ![Strzałka wskazująca w prawo po ścianie tylnej](back-wall.png) | ![Strzałka wskazująca w prawo po podłodze między kolumnami](floor.png) |

## **Dostosuj proporcje wysokości wykresu 3D**

Użyj [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) aby ustawić wysokość wykresu 3D jako procent jego szerokości. Zmienia to proporcje sceny 3D bez zmiany rozmiaru obiektu wykresu na slajdzie.

Poniższy przykład tworzy wykres [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) z domyślnymi danymi: trzy serie i cztery kategorie. Zapisuje trzy prezentacje z proporcjami wysokości 50 %, 100 % i 200 %. Pozycja, szerokość i wysokość wykresu pozostają stałe. Dane, obrót, głębokość, odstępy serii i formatowanie są identyczne we wszystkich trzech plikach; zmienia się jedynie procent wysokości.

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

Poniższe obrazy ilustrują te same ustawienia wysokości w równoważnym przykładzie .NET i zostały wyeksportowane przy użyciu Microsoft PowerPoint. Mniejszy procent daje płaską scenę, większy – wyższą scenę w tym samym obiekcie wykresu. PowerPoint może także dostosować interwały znaczników osi i położenie etykiet, aby dopasować scenę.

| Wysokość: 50 % | Wysokość: 100 % | Wysokość: 200 % |
| --- | --- | --- |
| ![Wykres kolumnowy 3D z wysokością ustawioną na 50 % jego szerokości](height_percent_50.png) | ![Wykres kolumnowy 3D z wysokością ustawioną na 100 % jego szerokości](height_percent_100.png) | ![Wykres kolumnowy 3D z wysokością ustawioną na 200 % jego szerokości](height_percent_200.png) |

Te metody kontrolują różne aspekty wykresu:

| Metoda | Efekt |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | Wysokość sceny 3D jako procent jej szerokości. |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | Wysokość obiektu wykresu na slajdzie, w punktach. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Głębokość sceny 3D jako procent jej szerokości. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Odstęp między seriami wzdłuż osi głębokości, jako procent szerokości markera. |

Ustawienie wysokości wpływa na wykresy słupkowe i kolumnowe 3D, w tym warianty cylinder, stożek i piramida, a także wykresy liniowe, powierzchniowe, kołowe i obszarowe 3D. Powyższe porównanie używa zweryfikowanego typu `Column3D`. Ustawienie nie zmienia wyglądu dwuwymiarowego wykresu `ClusteredColumn` ani wykresu `BubbleWith3D`; te nazwy są członkami klasy [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). Inne ustawienia wyglądu wykresu znajdziesz w sekcji [Chart Formatting](/slides/pl/nodejs-java/chart-formatting/).

## **Dostosuj odstęp między seriami**

Użyj [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) aby kontrolować odległość między seriami danych wzdłuż osi głębokości wykresu 3D, wyrażoną jako procent szerokości markera. Dozwolone wartości to **0 do 500**, włącznie: `0` usuwa odstęp, większe wartości zwiększają go. Przy stałej głębokości wykresu zwiększanie odstępu powoduje, że markery stają się cieńsze wzdłuż osi głębokości.

Dostęp do grupy uzyskuje się przez [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/). Ustawienie dotyczy każdej serii w tej grupie, nie tylko serii użytej do jej pobrania. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) zwraca aktualny odstęp głębokości i odzwierciedla ustawienie grupy nadrzędnej.

Ustawienie wpływa na wykresy słupkowe i kolumnowe 3D, w tym ich warianty cylinder, stożek i piramida, a także wykresy liniowe i powierzchniowe 3D. Wygląd zależy od tego, czy serie są rozmieszczone w głębokości, grupowane czy skumulowane. Do wyraźnego porównania odstępów między oddzielnymi seriami użyj `ChartType.Column3D` z klasy [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/).

Te metody kontrolują różne aspekty wykresu:

| Metoda | Efekt |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Odstęp między seriami wzdłuż osi głębokości, jako procent szerokości markera. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | Odstęp między sąsiadującymi grupami słupków lub kolumn, jako procent szerokości słupka lub kolumny. |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Całkowita głębokość wykresu, jako procent szerokości wykresu. |

Poniższy samodzielny przykład używa domyślnych danych wykresu, które zawierają trzy serie i cztery kategorie. Zapisuje dwa pliki prezentacji z identycznymi danymi, obrotem, szerokością odstępu i głębokością wykresu; zmienia się tylko głębokość odstępu.

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

Poniższe obrazy ilustrują te same ustawienia odstępu głębokości w równoważnym przykładzie .NET i zostały wyeksportowane przy użyciu Microsoft PowerPoint.

| Odstęp głębokości: 0 % | Odstęp głębokości: 500 % |
| --- | --- |
| ![Wykres kolumnowy 3D bez odstępu między seriami wzdłuż osi głębokości](gap_depth_0.png) | ![Wykres kolumnowy 3D z 500 % odstępem między seriami wzdłuż osi głębokości](gap_depth_500.png) |

## **Zmień typ serii 3D i kształt słupka**

W wykresie grupowanym cylindrycznym pierwsza seria zaczyna się od kształtu słupka cylindrycznego. Przykład wypisuje wartości całkowite zwracane przez [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) i [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) przed i po każdej zmianie. Tabela podaje odpowiadające nazwy stałych.

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

| Zmień pierwszą serię | Typ serii | Kształt słupka |
| --- | --- | --- |
| Utwórz wykres | `ClusteredCylinder` | `Cylinder` |
| Ustaw typ serii na `ClusteredCone` | `ClusteredCone` | `Cone` |
| Ustaw kształt słupka na `Box` | `ClusteredColumn3D` | `Box` |

Ustawienie kształtu na `Box` również zmienia typ serii na `ClusteredColumn3D`. Jeśli twój kod rozgałęzia się w zależności od typu serii, wywołaj `series.getType()` po zmianie kształtu. Wartość zbuforowana przed przypisaniem nadal wybrałaby gałąź `ClusteredCone`.

![Porównanie w PowerPoint pokazujące pierwszą serię jako cylindry, stożki i prostokątne kolumny od lewej do prawej](series-shapes.png)

## **FAQ**

**Jakie typy wykresów obsługują tryb 3D w Aspose.Slides?**

Aspose.Slides obsługuje warianty 3D wykresów słupkowych, w tym Column 3D, Clustered Column 3D, Stacked Column 3D i 100 % Stacked Column 3D, a także powiązane typy 3D dostępne poprzez klasę [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). Aktualną, precyzyjną listę znajdziesz w członkach [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) w dokumentacji API swojej zainstalowanej wersji.

**Czy mogę uzyskać rastrowy obraz wykresu 3D do raportu lub sieci?**

Tak. Możesz wyeksportować wykres jako obraz przy użyciu [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) lub [renderować cały slajd](/slides/pl/nodejs-java/convert-powerpoint-to-png/) do formatów takich jak PNG czy JPEG. Jest to przydatne, gdy potrzebny jest podgląd rastrowy lub chcesz osadzić wykres w dokumentach, pulpitach nawigacyjnych lub stronach internetowych bez wymogu użycia PowerPointa.

**Jak wydajne jest budowanie i renderowanie dużych wykresów 3D?**

Wydajność zależy od ilości danych i złożoności wizualnej. Dla najlepszych rezultatów utrzymuj efekty 3D na minimalnym poziomie, unikaj ciężkich tekstur na ścianach i powierzchniach wykresu, ogranicz liczbę punktów danych w serii, o ile to możliwe, oraz renderuj do odpowiednio dobranej rozdzielczości i wymiarów, dopasowanych do docelowego wyświetlacza lub druku.