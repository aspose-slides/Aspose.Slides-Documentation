---
title: Dodaj linie trendu do wykresów w prezentacji w Javie
linktitle: Linia trendu
type: docs
url: /pl/java/trend-line/
keywords:
- wykres
- linia trendu
- wykładnicza linia trendu
- liniowa linia trendu
- logarytmiczna linia trendu
- linia trendu średniej ruchomej
- wielomianowa linia trendu
- potęgowa linia trendu
- własna linia trendu
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Szybko dodaj i dostosuj linie trendu w wykresach PowerPoint przy użyciu Aspose.Slides dla Javy — praktyczny przewodnik, który przyciągnie uwagę Twojej publiczności."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dodać linie trendu do wykresów w prezentacji przy użyciu Aspose.Slides. Pokazuje, jak utworzyć wykres, dodać linie trendu do serii wykresu oraz pracować z kilkoma typami linii trendu, w tym wykładniczymi, liniowymi, logarytmicznymi, średnią ruchomą, wielomianowymi i potęgowymi.

Opisuje także, jak dodać własną linię do wykresu poprzez wstawienie kształtu linii, oraz zawiera krótkie FAQ dotyczące wartości projekcji linii trendu „forward” i „backward” oraz tego, czy linie trendu są zachowywane podczas eksportu do PDF lub SVG i przy renderowaniu wykresów jako obrazów.

## **Dodaj linię trendu**

Użyj [ITrendlineCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/itrendlinecollection/#add-int-) aby dodać linię trendu do serii wykresu, wybierając jej typ za pomocą [TrendlineType](https://reference.aspose.com/slides/java/com.aspose.slides/trendlinetype/). Przykład tworzy wykres słupkowy grupowany z danymi domyślnymi i dodaje dwie linie trendu do każdej z trzech serii.

Linia trendu wykładnicza ukrywa równanie i wartość R‑squared za pomocą [setDisplayEquation](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayEquation-boolean-) i [setDisplayRSquaredValue](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayRSquaredValue-boolean-), podczas gdy linia trendu liniowa jest czerwona. Linia trendu logarytmiczna używa [addTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#addTextFrameForOverriding-java.lang.String-) do własnej etykiety. Średnia ruchoma używa [setPeriod](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setPeriod-byte-) wynoszącego trzy punkty danych oraz własnej [setTrendlineName](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setTrendlineName-java.lang.String-).

Linia trendu wielomianowa ma [setOrder](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setOrder-byte-) równy trzem i wydłuża jedną kategorię do przodu za pomocą [setForward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setForward-double-). Linia trendu potęgowa wydłuża jedną kategorię do tyłu za pomocą [setBackward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setBackward-double-).

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

    IChartSeries firstSeries = chart.getChartData().getSeries().get_Item(0);

    ITrendline exponentialTrendline = firstSeries.getTrendLines().add(TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    ITrendline linearTrendline = firstSeries.getTrendLines().add(TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);

    IChartSeries secondSeries = chart.getChartData().getSeries().get_Item(1);

    ITrendline logarithmicTrendline = secondSeries.getTrendLines().add(TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    ITrendline movingAverageTrendline = secondSeries.getTrendLines().add(TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod((byte) 3);
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    IChartSeries thirdSeries = chart.getChartData().getSeries().get_Item(2);

    ITrendline polynomialTrendline = thirdSeries.getTrendLines().add(TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder((byte) 3);

    ITrendline powerTrendline = thirdSeries.getTrendLines().add(TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw przecięcie linii trendu**

Użyj [setIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#setIntercept-double-) aby ustalić wartość Y linii trendu przy X = 0. To ustawienie jest obsługiwane dla linii trendu liniowych, wykładniczych i wielomianowych.

Na przykład model kosztów produkcji może wymagać rozpoczęcia od znanych stałych kosztów równej 100, nawet gdy pomiary przy niezerowych wolumenach produkcji sugerują inną bazę. Dla linii trendu liniowej, ustalenie przecięcia wymusza równanie `y = ax + b` na `b = 100`; nachylenie jest dopasowywane do danych przy tym ograniczeniu. Nie powoduje to po prostu przesunięcia już dopasowanej linii. Ustawienia przecięcia osi kontrolują, gdzie osie wykresu się spotykają, a nie współczynniki dopasowanej linii trendu.

Poniższy przykład tworzy wykres rozrzutu (XY) z wolumenami produkcji od 1 do 4 oraz kosztami 170, 200, 230 i 260. Zapisuje wykres z domyślnym automatycznym przecięciem, ustawia przecięcie na 100 i zapisuje drugi plik PPTX. Dwa pliki różnią się wyłącznie ustawieniem przecięcia. Linia trendu wyświetla równanie i rozciąga się do X = 0.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell nameCell = workbook.getCell(0, 0, 1, "Production cost");
    IChartSeries series = chart.getChartData().getSeries().add(nameCell, ChartType.ScatterWithMarkers);
    double[] costs = { 170, 200, 230, 260 };

    for (int i = 0; i < costs.length; i++) {
        IChartDataCell xCell = workbook.getCell(0, i + 1, 0, i + 1);
        IChartDataCell yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    ITrendline trendline = series.getTrendLines().add(TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Przy automatycznym obliczeniu te dane dają `y = 30x + 140`. Ustawienie przecięcia na 100 zamiast tego daje w przybliżeniu `y = 43.33x + 100`: dopasowana wartość przy zerze odpowiada znanej bazie, a linia nie przechodzi już przez każdy punkt danych.

| Automatyczne przecięcie | Stałe przecięcie 100 |
| --- | --- |
| ![Linia trendu liniowa z automatycznie obliczonym przecięciem 140](intercept-automatic.png) | ![Linia trendu liniowa ze stałym przecięciem 100](intercept-fixed.png) |

Oba obrazy używają tych samych danych i skali osi. Linie trendu są rozciągnięte do X = 0, aby pokazać ich przecięcia.

Domyślnie, [getIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#getIntercept--) zwraca `Double.NaN`, co oznacza nieokreślone przecięcie, a nie zero. Przecięcie jest wtedy obliczane automatycznie na podstawie danych.

## **Dodaj niestandardową linię**

Niestandardowa linia to kształt narysowany nad wykresem, a nie linia trendu obliczona na podstawie danych serii. Ten przykład używa [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) aby dodać poziomą linię do slajdu nad wykresem. Pozycja linii jest określona w współrzędnych slajdu, mierzonych w punktach, więc zaczyna się od lewej krawędzi wykresu i znajduje się w połowie wysokości wykresu. Jej szerokość odpowiada szerokości wykresu. Metoda [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) nadaje linii jednolity czerwony kolor.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

    IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Co oznaczają ‘forward’ i ‘backward’ w kontekście linii trendu?**

Są to długości linii trendu projekowane do przodu lub do tyłu: dla wykresów rozrzutu (XY) – w jednostkach osi; dla wykresów nie‑rozrzutu – w liczbie kategorii. Dozwolone są tylko wartości nieujemne.

**Czy linia trendu zostanie zachowana przy eksporcie prezentacji do PDF lub SVG, lub przy renderowaniu slajdu jako obrazu?**

Tak. Aspose.Slides konwertuje prezentacje do [PDF](/slides/pl/java/convert-powerpoint-to-pdf/) lub [SVG](/slides/pl/java/render-a-slide-as-an-svg-image/) oraz renderuje wykresy jako obrazy; linie trendu, jako część wykresu, są zachowywane podczas tych operacji. Dostępna jest również metoda, aby [wyeksportować obraz wykresu](/slides/pl/java/create-shape-thumbnails/).