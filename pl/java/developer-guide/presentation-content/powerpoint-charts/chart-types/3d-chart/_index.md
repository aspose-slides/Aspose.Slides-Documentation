---
title: Dostosowywanie wykresów 3D w prezentacjach przy użyciu Javy
linktitle: Wykres 3D
type: docs
url: /pl/java/3d-chart/
keywords:
- wykres 3D
- rotacja
- głębokość
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Twórz wykresy 3D w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Javy. Dostosuj rotację, proporcje wysokości, głębokość wykresu oraz odstępy między seriami przy pomocy przykładów w Javie."
---
## **Przegląd**

Aspose.Slides for Java umożliwia dostosowanie widoku wykresu 3D za pomocą metody [IChart.getRotation3D](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getRotation3D--) . Ten artykuł pokazuje, jak dostosować rotację, proporcje wysokości, głębokość, osie pod kątem prostym oraz odstępy między seriami, a następnie zapisać prezentację w formacie PPTX.

## **Ustaw rotację i głębokość wykresu 3D**

Przykład poniżej tworzy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) i używa [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) do dodania skumulowanego wykresu kolumnowego 3D do jego pierwszego slajdu. Zastępuje domyślne serie i kategorie dwoma seriami zawierającymi po trzy wartości. Indeks arkusza `0` identyfikuje pierwszy arkusz danych wykresu; wiersz `0` zawiera nazwy serii, a kolumna `0` etykiety kategorii.

Metody [setRotationX](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationX-byte-) i [setRotationY](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationY-int-) ustawiają rotację wykresu na 40 i 270 stopni odpowiednio. [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) ustawia jego głębokość na 150% jego szerokości, natomiast [setRightAngleAxes](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) włącza osie pod kątem prostym zamiast perspektywy. Powstała prezentacja zawiera wykres z wypełnionymi danymi i tymi ustawieniami widoku 3D.

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

## **Zastosuj wypełnienie obrazem na powierzchni wykresu 3D**

Wykres 3D ma trzy powierzchnie, które można wypełniać niezależnie: [side wall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getSideWall--), [back wall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getBackWall--) i [floor](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getFloor--) . Ustaw typ wypełnienia powierzchni [fill type](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) na `Picture` i przypisz obraz. Ustaw zarówno [picture fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) jak i [picture type](https://reference.aspose.com/slides/java/com.aspose.slides/ichartwall/#setPictureType-int-) powierzchni na `Stretch`, aby dopasować jedną kopię obrazu do całej powierzchni.

Zapisz [arrow.png](arrow.png) w katalogu roboczym. Przykład obraca wykres i podnosi maksymalną wartość na osi pionowej, aby podłoga była widoczna między kolumnami. Następnie klonuje slajd dwukrotnie i stosuje strzałkę do innej powierzchni na każdym slajdzie. Wszystkie trzy wykresy zachowują te same dane, kąt widzenia i tło.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
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

    byte[] imageBytes = Files.readAllBytes(Paths.get("arrow.png"));
    IPPImage arrow = presentation.getImages().addImage(imageBytes);

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

| Boczna ściana | Tylna ściana | Podłoga |
| --- | --- | --- |
| ![Strzałka wskazująca na wykres wzdłuż bocznej ściany](side-wall.png) | ![Strzałka wskazująca w prawo na tylnej ścianie](back-wall.png) | ![Strzałka wskazująca w prawo na podłodze między kolumnami](floor.png) |

## **Dostosuj proporcje wysokości wykresu 3D**

Użyj [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) aby ustawić wysokość wykresu 3D jako procent jego szerokości. Zmienia to proporcje sceny 3D bez zmiany rozmiaru obiektu wykresu na slajdzie.

Poniższy przykład tworzy wykres [Column3D](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) z domyślnymi danymi: trzy serie i cztery kategorie. Zapisuje trzy prezentacje z proporcjami wysokości 50 %, 100 % i 200 %. Pozycja, szerokość i wysokość wykresu pozostają stałe. Dane, rotacja, głębokość, odstępy serii i formatowanie są identyczne we wszystkich trzech plikach; zmienia się tylko procent wysokości.

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

Poniższe obrazy ilustrują te same ustawienia wysokości w równoważnym przykładzie .NET i zostały wyeksportowane przy użyciu Microsoft PowerPoint. Mniejszy procent daje płaską scenę, większy procent – wyższą scenę w tym samym obiekcie wykresu. PowerPoint może także dostosowywać odstępy znaczników osi i rozmieszczenie etykiet, aby dopasować scenę.

| Wysokość: 50% | Wysokość: 100% | Wysokość: 200% |
| --- | --- | --- |
| ![Wykres kolumnowy 3D z wysokością ustawioną na 50% jego szerokości](height_percent_50.png) | ![Wykres kolumnowy 3D z wysokością ustawioną na 100% jego szerokości](height_percent_100.png) | ![Wykres kolumnowy 3D z wysokością ustawioną na 200% jego szerokości](height_percent_200.png) |

| Metoda | Efekt |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) | Wysokość sceny 3D jako procent jej szerokości. |
| [IChart.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setHeight-float-) | Wysokość obiektu wykresu na slajdzie, w punktach. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Głębokość sceny 3D jako procent jej szerokości. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Odstęp między seriami wzdłuż osi głębokości, jako procent szerokości znacznika. |

Ustawienie wysokości wpływa na wykresy kolumnowe i słupkowe 3D, w tym warianty cylindryczne, stożkowe i piramidalne, a także wykresy 3D liniowe, powierzchniowe, kołowe i powierzchniowe. Powyższe porównanie używa zweryfikowanego typu `Column3D`. Ustawienie nie zmienia wyglądu 2D wykresu `ClusteredColumn` ani wykresu `BubbleWith3D`; są to nazwy członków klasy [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). Inne ustawienia wyglądu wykresu znajdziesz w [Chart Formatting](/slides/pl/java/chart-formatting/).

## **Dostosuj odstęp między seriami**

Użyj [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) aby kontrolować odległość między seriami danych wzdłuż osi głębokości wykresu 3D, wyrażoną jako procent szerokości znacznika. Używaj wartości od **0 do 500**, włącznie: `0` usuwa odstęp, a większe wartości zwiększają przerwę. Przy stałej głębokości wykresu zwiększanie przerwy powoduje cieńsze znaczniki wzdłuż osi głębokości.

Uzyskaj grupę przez [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) . Ustawienie dotyczy każdej serii w tej grupie, nie tylko serii użytej do jej pobrania. [IChartSeries.getGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getGapDepth--) zwraca przerwę w głębokości i odzwierciedla ustawienie grupy nadrzędnej.

To ustawienie wpływa na wykresy kolumnowe i słupkowe 3D, w tym ich warianty cylindryczne, stożkowe i piramidalne, a także wykresy 3D liniowe i powierzchniowe. Wygląd zależy od tego, czy serie są rozmieszczone w głębokości, grupowane lub skumulowane. Dla wyraźnego porównania przerw między oddzielnymi seriami użyj `ChartType.Column3D` z klasy [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/).

| Metoda | Efekt |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Odstęp między seriami wzdłuż osi głębokości, jako procent szerokości znacznika. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | Odstęp między sąsiadującymi grupami słupków lub kolumn, jako procent szerokości słupka lub kolumny. |
| [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Całkowita głębokość wykresu, jako procent szerokości wykresu. |

Poniższy przykład jest samodzielny i używa domyślnych danych wykresu, które zawierają trzy serie i cztery kategorie. Zapisuje dwie prezentacje z identycznymi danymi, rotacją, szerokością przerwy i głębokością wykresu; zmienia się tylko przerwa w głębokości.

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

Poniższe obrazy ilustrują te same ustawienia przerwy w głębokości w równoważnym przykładzie .NET i zostały wyeksportowane przy użyciu Microsoft PowerPoint.

| Głębokość przerwy: 0% | Głębokość przerwy: 500% |
| --- | --- |
| ![Wykres kolumnowy 3D bez przerwy między seriami wzdłuż osi głębokości](gap_depth_0.png) | ![Wykres kolumnowy 3D z przerwą 500% między seriami wzdłuż osi głębokości](gap_depth_500.png) |

## **Zmień typ serii 3D i kształt słupka**

W wykresie grupowanym cylindrycznym pierwsza seria zaczyna się od cylindrycznego kształtu słupka. Przykład wypisuje wartości liczbowe zwracane przez [IChartSeries.getType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getType--) i [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getBar3DShape--) przed i po każdej zmianie. Tabela podaje odpowiadające nazwy stałych.

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

| Zmieniana pierwsza seria | Typ serii | Kształt słupka |
| --- | --- | --- |
| Utwórz wykres | `ClusteredCylinder` | `Cylinder` |
| Ustaw typ serii na `ClusteredCone` | `ClusteredCone` | `Cone` |
| Ustaw kształt słupka na `Box` | `ClusteredColumn3D` | `Box` |

Ustawienie kształtu na `Box` zmienia również typ serii na `ClusteredColumn3D`. Jeśli Twój kod rozgałęzia się w zależności od typu serii, wywołaj `series.getType()` po zmianie kształtu. Wartość zbuforowana przed przypisaniem nadal wybierze gałąź `ClusteredCone`.

![Porównanie w PowerPoint pokazujące pierwszą serię jako cylindry, stożki i prostokątne kolumny od lewej do prawej](series-shapes.png)

## **FAQ**

**Jakie typy wykresów obsługują tryb 3D w Aspose.Slides?**

Aspose.Slides obsługuje warianty 3D wykresów kolumnowych, w tym Column 3D, Clustered Column 3D, Stacked Column 3D i 100 % Stacked Column 3D, oraz powiązane typy 3D udostępniane przez klasę [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). Aby uzyskać dokładną, aktualną listę, sprawdź członków [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) w dokumentacji API swojej zainstalowanej wersji.

**Czy mogę uzyskać rastrowy obraz wykresu 3D do raportu lub witryny?**

Tak. Możesz wyeksportować wykres do obrazu przy użyciu [Shape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) lub [renderować cały slajd](/slides/pl/java/convert-powerpoint-to-png/) do formatów takich jak PNG lub JPEG. Jest to przydatne, gdy potrzebny jest podgląd rastrowy lub chcesz osadzić wykres w dokumentach, pulpitach nawigacyjnych lub stronach internetowych bez wymogu PowerPoint.

**Jak wydajna jest budowa i renderowanie dużych wykresów 3D?**

Wydajność zależy od objętości danych i złożoności wizualnej. Aby uzyskać najlepsze wyniki, ogranicz efekty 3D, unikaj ciężkich tekstur na ścianach i obszarach wykresu, zmniejsz liczbę punktów danych w serii, gdy to możliwe, oraz renderuj do odpowiednio dobranej rozdzielczości i wymiarów, dopasowanych do docelowego wyświetlacza lub wymagań druku.