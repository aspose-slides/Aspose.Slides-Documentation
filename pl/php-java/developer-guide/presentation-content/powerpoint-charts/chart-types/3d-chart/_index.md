---
title: Dostosowywanie wykresów 3D w prezentacjach przy użyciu PHP
linktitle: Wykres 3D
type: docs
url: /pl/php-java/3d-chart/
keywords:
- wykres 3D
- obrót
- głębokość
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Twórz wykresy 3D w prezentacjach PowerPoint przy użyciu Aspose.Slides for PHP via Java. Dostosuj obrót, proporcje wysokości, głębokość wykresu oraz odstępy między seriami, korzystając z przykładów w PHP."
---
## **Przegląd**

Aspose.Slides for PHP via Java umożliwia dostosowanie widoku wykresu 3D za pomocą metody [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D). Ten artykuł pokazuje, jak dostosować obrót, proporcje wysokości, głębokość, osie pod kątem prostym oraz odstępy między seriami, a następnie zapisać prezentację w formacie PPTX.

## **Ustaw obrót i głębokość wykresu 3D**

Poniższy przykład tworzy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) i używa [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart), aby dodać skumulowany wykres słupkowy 3D do pierwszego slajdu. Zastępuje domyślne serie i kategorie dwoma seriami zawierającymi po trzy wartości. Indeks arkusza `0` identyfikuje pierwszy arkusz danych wykresu; wiersz `0` zawiera nazwy serii, a kolumna `0` – etykiety kategorii.

Metody [setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) i [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) ustawiają obrót wykresu odpowiednio na 40 i 270 stopni. [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) ustawia jego głębokość na 150 % szerokości, natomiast [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) włącza osie pod kątem prostym zamiast perspektywy. Wynikowa prezentacja zawiera wykres z tymi ustawieniami widoku 3D.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $values = [[20, 50, 30], [30, 10, 60]];

    for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, 0, "Category " . ($categoryIndex + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    for ($seriesIndex = 0; $seriesIndex < 2; $seriesIndex++) {
        $seriesCell = $workbook->getCell($worksheetIndex, 0, $seriesIndex + 1, "Series " . ($seriesIndex + 1));
        $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());

        for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
            $valueCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, $seriesIndex + 1, $values[$seriesIndex][$categoryIndex]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }
    }

    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);

    $presentation->save("Rotation3D_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Zastosuj wypełnienie obrazem na powierzchni wykresu 3D**

Możesz wypełnić [side wall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getsidewall/), [back wall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getbackwall/) i [floor](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getfloor/) wykresu 3D niezależnie. Ustaw typ wypełnienia powierzchni na `Picture` za pomocą [fill type](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) i przypisz obraz. Ustaw zarówno [picture fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setpicturefillmode/), jak i [picture type](https://reference.aspose.com/slides/php-java/aspose.slides/chartwall/setpicturetype/) na `Stretch`, aby dopasować jedną kopię obrazu do całej powierzchni.

Zapisz [arrow.png](arrow.png) obok skryptu PHP. Przykład obraca wykres i podnosi maksymalną wartość na osi pionowej, aby podłoga była widoczna pomiędzy słupkami. Następnie dwukrotnie klonuje slajd i nakłada strzałkę na inną powierzchnię w każdym slajdzie. Wszystkie trzy wykresy zachowują te same dane, kąt widzenia i tło.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\PictureType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 20, 30, 680, 480);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(30);
    
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->setAutomaticMaxValue(false);
    $verticalAxis->setMaxValue(24);

    $backSlide = $presentation->getSlides()->addClone($slide);
    $floorSlide = $presentation->getSlides()->addClone($slide);
    $backChart = $backSlide->getShapes()->get_Item(0);
    $floorChart = $floorSlide->getShapes()->get_Item(0);

    $image = Images::fromFile(__DIR__ . "/arrow.png");
    try {
        $arrow = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $surfaces = [$chart->getSideWall(), $backChart->getBackWall(), $floorChart->getFloor()];
    foreach ($surfaces as $surface) {
        $fill = $surface->getFormat()->getFill();
        $fill->setFillType(FillType::Picture);
        $pictureFill = $fill->getPictureFillFormat();
        $pictureFill->getPicture()->setImage($arrow);
        $pictureFill->setPictureFillMode(PictureFillMode::Stretch);
        $surface->setPictureType(PictureType::Stretch);
    }

    $presentation->save(__DIR__ . "/chart-surfaces.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Microsoft PowerPoint wyświetla trzy slajdy w następujący sposób.

| Ściana boczna | Ściana tylna | Podłoga |
| --- | --- | --- |
| ![Strzałka wskazująca na wykres wzdłuż ściany bocznej](side-wall.png) | ![Strzałka wskazująca w prawo na ścianie tylnej](back-wall.png) | ![Strzałka wskazująca w prawo na podłodze między kolumnami](floor.png) |

## **Dostosuj proporcje wysokości wykresu 3D**

Użyj [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents), aby ustawić wysokość wykresu 3D jako procent jego szerokości. Zmienia to proporcje sceny 3D bez zmiany rozmiaru obiektu wykresu na slajdzie.

Poniższy przykład tworzy wykres [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) z domyślnymi danymi: trzy serie i cztery kategorie. Zapisuje trzy prezentacje z proporcjami wysokości 50 %, 100 % i 200 %. Pozycja, szerokość i wysokość wykresu pozostają stałe. Dane, obrót, głębokość, odstępy serii i formatowanie są identyczne we wszystkich trzech plikach; zmienia się tylko procent wysokości.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 460);
    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setDepthPercents(100);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setGapDepth(150);

    foreach ([50, 100, 200] as $heightPercent) {
        $chart->getRotation3D()->setHeightPercents($heightPercent);
        $presentation->save("chart_height_" . $heightPercent . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Poniższe obrazy ilustrują te same ustawienia wysokości w równoważnym przykładzie .NET i zostały wyeksportowane przy użyciu Microsoft PowerPoint. Mniejszy procent daje płaską scenę, większy – wyższą scenę w obrębie tego samego obiektu wykresu. PowerPoint może także dostosować interwały znaczników osi i rozmieszczenie etykiet, aby dopasować scenę.

| Wysokość: 50% | Wysokość: 100% | Wysokość: 200% |
| --- | --- | --- |
| ![Wykres kolumnowy 3D z wysokością ustawioną na 50% jego szerokości](height_percent_50.png) | ![Wykres kolumnowy 3D z wysokością ustawioną na 100% jego szerokości](height_percent_100.png) | ![Wykres kolumnowy 3D z wysokością ustawioną na 200% jego szerokości](height_percent_200.png) |

Te metody kontrolują różne aspekty wykresu:

| Metoda | Efekt |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | Wysokość sceny 3D jako procent jej szerokości. |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | Wysokość obiektu wykresu na slajdzie, w punktach. |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Głębokość sceny 3D jako procent jej szerokości. |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Odstęp między seriami wzdłuż osi głębokości, jako procent szerokości znacznika. |

Ustawienie wysokości wpływa na wykresy słupkowe i kolumnowe 3D, w tym warianty cylindryczne, stożkowe i piramidalne, a także wykresy liniowe, powierzchniowe i kołowe 3D. Powyższe porównanie używa zweryfikowanego typu `Column3D`. Ustawienie nie zmienia wyglądu wykresu 2D `ClusteredColumn` ani wykresu `BubbleWith3D`; są to członkowie klasy [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). Inne ustawienia wyglądu wykresu znajdziesz w [Chart Formatting](/slides/pl/php-java/chart-formatting/).

## **Dostosuj odstęp między seriami**

Użyj [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth), aby kontrolować odległość między seriami danych wzdłuż osi głębokości wykresu 3D, wyrażoną jako procent szerokości znacznika. Dozwolone wartości to **0 do 500**, włącznie: `0` usuwa przerwę, wyższe wartości zwiększają odstęp. Przy stałej głębokości wykresu zwiększanie przerwy powoduje, że markery są cieńsze wzdłuż osi głębokości.

Dostęp do grupy uzyskuje się przez [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup). Ustawienie dotyczy każdej serii w tej grupie, a nie tylko serii użytej do jej pobrania. [ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) zwraca aktualny odstęp w głębokości i odzwierciedla ustawienie grupy nadrzędnej.

Ustawienie wpływa na wykresy słupkowe i kolumnowe 3D, w tym ich warianty cylindryczne, stożkowe i piramidalne, a także wykresy liniowe i powierzchniowe 3D. Wygląd zależy od tego, czy serie są rozmieszczone w głębokości, grupowane czy skumulowane. Do wyraźnego porównania przerw między oddzielnymi seriami użyj `ChartType::Column3D` z klasy [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/).

Te metody kontrolują różne aspekty wykresu:

| Metoda | Efekt |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Odstęp między seriami wzdłuż osi głębokości, jako procent szerokości znacznika. |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | Odstęp między sąsiadującymi grupami słupków lub kolumn, jako procent ich szerokości. |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Całkowita głębokość wykresu, jako procent szerokości wykresu. |

Poniższy, samodzielny przykład używa domyślnych danych wykresu, które zawierają trzy serie i cztery kategorie. Zapisuje dwie prezentacje z identycznymi danymi, obrotem, szerokością przerwy i głębokością wykresu; zmienia się tylko głębokość przerwy.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 230);

    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setDepthPercents(100);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $group = $series->getParentSeriesGroup();
    $group->setGapWidth(150);

    foreach ([0, 500] as $gapDepth) {
        $group->setGapDepth($gapDepth);

        $fileName = "series_gap_depth_" . $gapDepth . ".pptx";
        $presentation->save($fileName, SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

| Głębokość przerwy: 0% | Głębokość przerwy: 500% |
| --- | --- |
| ![Wykres kolumnowy 3D bez przerwy między seriami wzdłuż osi głębokości](gap_depth_0.png) | ![Wykres kolumnowy 3D z przerwą 500 % między seriami wzdłuż osi głębokości](gap_depth_500.png) |

## **Zmień typ serii 3D i kształt słupka**

W wykresie skumulowanym cylindrycznym pierwsza seria zaczyna się od słupka o kształcie cylindrycznym. Przykład wypisuje wartości całkowite zwracane przez [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) i [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) przed i po każdej zmianie. Tabela podaje odpowiadające nazwy stałych.

```php
use aspose\slides\ChartShapeType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setType(ChartType::ClusteredCone);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setBar3DShape(ChartShapeType::Box);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $presentation->save("series_shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Zmiana pierwszej serii | Typ serii | Kształt słupka |
| --- | --- | --- |
| Utwórz wykres | `ClusteredCylinder` | `Cylinder` |
| Ustaw typ serii na `ClusteredCone` | `ClusteredCone` | `Cone` |
| Ustaw kształt słupka na `Box` | `ClusteredColumn3D` | `Box` |

Ustawienie kształtu na `Box` zmienia także typ serii na `ClusteredColumn3D`. Jeśli twój kod rozgałęzia się w zależności od typu serii, wywołaj [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) po zmianie kształtu. Wartość pobrana przed przypisaniem nadal wybierałaby gałąź `ClusteredCone`.

![Porównanie w PowerPoint pokazujące pierwszą serię jako cylindry, stożki i prostokątne kolumny od lewej do prawej](series-shapes.png)

## **FAQ**

**Jakie typy wykresów obsługują tryb 3D w Aspose.Slides?**

Aspose.Slides obsługuje warianty 3D wykresów słupkowych, w tym Column 3D, Clustered Column 3D, Stacked Column 3D i 100 % Stacked Column 3D, a także powiązane typy 3D udostępniane przez klasę [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). Aktualną, dokładną listę znajdziesz w członkach [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) w dokumentacji API swojej wersji.

**Czy mogę uzyskać obraz rastrowy wykresu 3D do raportu lub internetu?**

Tak. Możesz wyeksportować wykres do obrazu przy użyciu [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) lub [renderować cały slajd](/slides/pl/php-java/convert-powerpoint-to-png/) do formatów takich jak PNG czy JPEG. Jest to przydatne, gdy potrzebny jest podgląd rastrowy lub chcesz osadzić wykres w dokumentach, pulpitach nawigacyjnych czy stronach internetowych bez wymogu posiadania PowerPointa.

**Jak wydajne jest budowanie i renderowanie dużych wykresów 3D?**

Wydajność zależy od objętości danych i złożoności wizualnej. Dla najlepszych rezultatów ogranicz efekty 3D, unikaj ciężkich tekstur na ścianach i obszarach wykresu, redukuj liczbę punktów danych w serii, kiedy to możliwe, oraz renderuj do odpowiednio dobranej rozdzielczości i rozmiaru, aby dopasować się do docelowego wyświetlacza lub wymagań drukarskich.