---
title: Dostosowywanie wykresów 3D w prezentacjach na Androidzie
linktitle: Wykres 3D
type: docs
url: /pl/androidjava/3d-chart/
keywords:
- Wykres 3D
- obrót
- głębokość
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Twórz wykresy 3D w prezentacjach PowerPoint za pomocą Aspose.Slides for Android via Java. Dostosuj obrót, proporcje wysokości, głębokość wykresu oraz odstępy między seriami przy użyciu przykładów w Java."
---
## **Przegląd**

Aspose.Slides for Android via Java umożliwia dostosowanie widoku wykresu 3D za pomocą metody [IChart.getRotation3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getRotation3D--) . Ten artykuł pokazuje, jak ustawić obrót, proporcje wysokości, głębokość, osie pod kątem prostym oraz odstępy między seriami, a następnie zapisać prezentację w formacie PPTX.

## **Ustaw obrót i głębokość wykresu 3D**

Poniższy przykład tworzy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) i używa [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) do dodania skumulowanego wykresu kolumnowego 3D na pierwszym slajdzie. Zastępuje domyślne serie i kategorie dwoma seriami po trzy wartości każda. Indeks arkusza `0` identyfikuje pierwszy arkusz danych wykresu; wiersz `0` zawiera nazwy serii, a kolumna `0` etykiety kategorii.

Metody [setRotationX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationX-byte-) i [setRotationY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationY-int-) ustawiają obrót wykresu odpowiednio na 40 i 270 stopni. Metoda [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) ustawia jego głębokość na 150 % szerokości, a [setRightAngleAxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) włącza osie pod kątem prostym zamiast perspektywy. Wynikowa prezentacja zawiera wykres z tymi ustawieniami widoku 3D.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    double[][] values = { { 20, 50, 30 }, { 30, 10, 60 } };

    for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (int seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zastosuj wypełnienie obrazem do powierzchni wykresu 3D**

Wykres 3D ma trzy powierzchnie, które można wypełniać niezależnie: [side wall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getSideWall--), [back wall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getBackWall--) i [floor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getFloor--) . Ustaw [fill type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) powierzchni na `Picture` i przypisz obraz. Ustaw zarówno [picture fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) jak i [picture type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartwall/#setPictureType-int-) powierzchni na `Stretch`, aby jedna kopia obrazu wypełniła całą powierzchnię.

Zapisz [arrow.png](arrow.png) w katalogu roboczym. Przykład obraca wykres i podnosi maksymalną wartość na osi pionowej, aby podłoga była widoczna między kolumnami. Następnie klonuje slajd dwukrotnie i stosuje strzałkę do innej powierzchni na każdym slajdzie. Wszystkie trzy wykresy zachowują te same dane, kąt widzenia i tło.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try (FileInputStream image = new FileInputStream("arrow.png")) {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    ISlide backSlide = presentation.getSlides().addClone(slide);
    ISlide floorSlide = presentation.getSlides().addClone(slide);
    IChart backChart = (IChart) backSlide.getShapes().get_Item(0);
    IChart floorChart = (IChart) floorSlide.getShapes().get_Item(0);

    IPPImage arrow = presentation.getImages().addImage(image);

    IChartWall[] surfaces = { chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor() };
    for (IChartWall surface : surfaces) {
        IFillFormat fill = surface.getFormat().getFill();
        fill.setFillType(FillType.Picture);
        fill.getPictureFillFormat().getPicture().setImage(arrow);
        fill.getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
        surface.setPictureType(PictureType.Stretch);
    }

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint wyświetla trzy slajdy w następujący sposób.

| Ściana boczna | Ściana tylna | Podłoga |
| --- | --- | --- |
| ![Strzałka wskazująca na wykres wzdłuż ściany bocznej](side-wall.png) | ![Strzałka wskazująca w prawo wzdłuż ściany tylnej](back-wall.png) | ![Strzałka wskazująca w prawo na podłodze między kolumnami](floor.png) |

## **Dostosuj proporcje wysokości wykresu 3D**

Użyj [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) do ustawienia wysokości wykresu 3D jako procentu jego szerokości. Zmienia to proporcje sceny 3D bez zmiany rozmiaru obiektu wykresu na slajdzie.

Poniższy przykład tworzy wykres [Column3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) z domyślnymi danymi: trzema seriami i czterema kategoriami. Zapisuje trzy prezentacje z proporcjami wysokości 50 %, 100 % i 200 %. Pozycja, szerokość i wysokość wykresu pozostają stałe. Dane, obrót, głębokość, odstępy serii i formatowanie są identyczne we wszystkich trzech plikach; zmienia się tylko procent wysokości.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (int heightPercent : new int[] { 50, 100, 200 }) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Poniższe obrazy ilustrują te same ustawienia wysokości w równoważnym przykładzie .NET i zostały wyeksportowane przy użyciu Microsoft PowerPoint. Mniejszy procent tworzy płaską scenę, większy procent – wyższą scenę w tym samym obiekcie wykresu. PowerPoint może także dostosować interwały podziałek osi i rozmieszczenie etykiet, aby dopasować scenę.

| Wysokość: 50 % | Wysokość: 100 % | Wysokość: 200 % |
| --- | --- | --- |
| ![Wykres kolumnowy 3D z wysokością ustawioną na 50 % szerokości](height_percent_50.png) | ![Wykres kolumnowy 3D z wysokością ustawioną na 100 % szerokości](height_percent_100.png) | ![Wykres kolumnowy 3D z wysokością ustawioną na 200 % szerokości](height_percent_200.png) |

Te metody kontrolują różne aspekty wykresu:

| Metoda | Efekt |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) | Wysokość sceny 3D jako procent szerokości. |
| [IChart.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setHeight-float-) | Wysokość obiektu wykresu na slajdzie, w punktach. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Głębokość sceny 3D jako procent szerokości. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Odstęp między seriami wzdłuż osi głębokości, jako procent szerokości znacznika. |

Ustawienie wysokości wpływa na wykresy kolumnowe i słupkowe 3D, w tym warianty cylindryczne, stożkowe i piramidalne, a także wykresy liniowe, powierzchniowe i kołowe 3D. Powyższe porównanie używa zweryfikowanego typu `Column3D`. Ustawienie nie zmienia wyglądu wykresu 2D `ClusteredColumn` ani wykresu `BubbleWith3D`; są to członkowie klasy [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/). Dla innych ustawień wyglądu wykresu zobacz [Chart Formatting](/slides/pl/androidjava/chart-formatting/).

## **Dostosuj odstęp między seriami**

Użyj [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) do kontrolowania odległości między seriami danych wzdłuż osi głębokości wykresu 3D, wyrażonej jako procent szerokości znacznika. Dozwolone wartości to **0 do 500**, włącznie: `0` usuwa odstęp, wyższe wartości zwiększają go. Przy stałej głębokości wykresu zwiększenie odstępu powoduje cieńcze znaczniki wzdłuż osi głębokości.

Uzyskaj grupę przez [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) . Ustawienie dotyczy każdej serii w tej grupie, nie tylko serii użytej do uzyskania grupy. [IChartSeries.getGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getGapDepth--) zwraca bieżący odstęp w głębokości i odzwierciedla ustawienie grupy nadrzędnej.

Ustawienie wpływa na wykresy kolumnowe i słupkowe 3D, w tym ich warianty cylindryczne, stożkowe i piramidalne, a także wykresy liniowe i powierzchniowe 3D. Wygląd zależy od tego, czy serie są rozmieszczone w głębokości, grupowane czy skumulowane. Dla przejrzystego porównania odstępów między oddzielnymi seriami użyj `ChartType.Column3D` z klasy [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/).

Te metody kontrolują różne aspekty wykresu:

| Metoda | Efekt |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Odstęp między seriami wzdłuż osi głębokości, jako procent szerokości znacznika. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | Odstęp między sąsiadującymi grupami słupków lub kolumn, jako procent ich szerokości. |
| [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Całkowita głębokość wykresu, jako procent szerokości wykresu. |

Poniższy, samodzielny przykład używa domyślnych danych wykresu, które zawierają trzy serie i cztery kategorie. Zapisuje dwie prezentacje z identycznymi danymi, obrotem, szerokością odstępu i głębokością wykresu; zmienia się jedynie głębokość odstępu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartSeriesGroup group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (int gapDepth : new int[] { 0, 500 }) {
        group.setGapDepth(gapDepth);

        String fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Poniższe obrazy ilustrują te same ustawienia głębokości odstępu w równoważnym przykładzie .NET i zostały wyeksportowane przy użyciu Microsoft PowerPoint.

| Głębokość odstępu: 0 % | Głębokość odstępu: 500 % |
| --- | --- |
| ![Wykres kolumnowy 3D bez odstępu między seriami wzdłuż osi głębokości](gap_depth_0.png) | ![Wykres kolumnowy 3D z 500‑procentowym odstępem między seriami wzdłuż osi głębokości](gap_depth_500.png) |

## **Zmień typ serii 3D i kształt słupka**

W wykresie grupowanym z cylindrycznymi słupkami pierwsza seria zaczyna się od cylindrycznego kształtu słupka. Przykład wypisuje wartości całkowite zwracane przez [IChartSeries.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getType--) i [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getBar3DShape--) przed i po każdej zmianie. Tabela podaje odpowiadające nazwy stałych.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setType(ChartType.ClusteredCone);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(ChartShapeType.Box);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Zmiana pierwszej serii | Typ serii | Kształt słupka |
| --- | --- | --- |
| Utwórz wykres | `ClusteredCylinder` | `Cylinder` |
| Ustaw typ serii na `ClusteredCone` | `ClusteredCone` | `Cone` |
| Ustaw kształt słupka na `Box` | `ClusteredColumn3D` | `Box` |

Ustawienie kształtu na `Box` zmienia również typ serii na `ClusteredColumn3D`. Jeśli Twój kod rozgałęzia się w zależności od typu serii, wywołaj `series.getType()` po zmianie kształtu. Wartość zbuforowana przed przypisaniem nadal wybrałaby gałąź `ClusteredCone`.

![Porównanie w PowerPoint pokazujące pierwszą serię jako cylindry, stożki i prostokątne kolumny od lewej do prawej](series-shapes.png)

## **FAQ**

**Jakie typy wykresów obsługują tryb 3D w Aspose.Slides?**

Aspose.Slides obsługuje 3‑d warianty wykresów kolumnowych, w tym Column 3D, Clustered Column 3D, Stacked Column 3D i 100 % Stacked Column 3D, oraz powiązane typy 3D dostępne poprzez klasę [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/). Aktualną, dokładną listę znajdziesz w członkach [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) w dokumentacji API Twojej zainstalowanej wersji.

**Czy mogę uzyskać rasterowy obraz wykresu 3D do raportu lub witryny?**

Tak. Możesz wyeksportować wykres jako obraz przy użyciu [Shape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) lub [render the entire slide](/slides/pl/androidjava/convert-powerpoint-to-png/) do formatów takich jak PNG lub JPEG. Jest to przydatne, gdy potrzebny jest podgląd rastrowy lub gdy chcesz osadzić wykres w dokumentach, pulpitach nawigacyjnych lub stronach internetowych bez wymogu posiadania PowerPointa.

**Jak wydajna jest budowa i renderowanie dużych wykresów 3D?**

Wydajność zależy od objętości danych i złożoności wizualnej. Aby uzyskać najlepsze wyniki, ogranicz efekty 3D, unikaj ciężkich tekstur na ścianach i obszarach wykresu, ogranicz liczbę punktów danych w serii, gdy to możliwe, oraz renderuj do odpowiednio dobranej rozdzielczości i wymiarów, aby dopasować je do docelowego wyświetlacza lub potrzeb druku.