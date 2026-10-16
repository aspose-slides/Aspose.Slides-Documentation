---
title: Dodaj linie trendu do wykresów w prezentacji na Androidzie
linktitle: Linia trendu
type: docs
url: /pl/androidjava/trend-line/
keywords:
- wykres
- linia trendu
- wykładnicza linia trendu
- liniowa linia trendu
- logarytmiczna linia trendu
- linia trendu średniej kroczącej
- wielomianowa linia trendu
- potęgowa linia trendu
- własna linia trendu
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Szybko dodaj i dostosuj linie trendu w wykresach PowerPoint przy użyciu Aspose.Slides dla Androida w Javie — praktyczny przewodnik, aby przyciągnąć uwagę odbiorców."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dodać linie trendu do wykresów w prezentacji przy użyciu Aspose.Slides. Pokazuje, jak utworzyć wykres, dodać linie trendu do serii wykresu oraz pracować z różnymi typami linii trendu, w tym wykładniczym, liniowym, logarytmicznym, średnią kroczącą, wielomianowym i potęgowym.

Opisuje także, jak dodać własną linię do wykresu poprzez wstawienie kształtu linii, oraz zawiera krótkie FAQ na temat wartości projekcji linii trendu do przodu i do tyłu oraz tego, czy linie trendu są zachowywane podczas eksportu do PDF lub SVG i przy renderowaniu wykresów jako obrazy.

## **Dodaj linię trendu**

Użyj [ITrendlineCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendlinecollection/#add-int-) aby dodać linię trendu do serii wykresu, wybierając jej typ za pomocą [TrendlineType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendlinetype/). Przykład tworzy wykres słupkowy zgrupowany z domyślnymi danymi i dodaje dwie linie trendu do każdej z trzech serii.

Wykładnicza linia trendu ukrywa swoje równanie i wartość R-kwadrat przy użyciu [setDisplayEquation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setDisplayEquation-boolean-) i [setDisplayRSquaredValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setDisplayRSquaredValue-boolean-), podczas gdy liniowa linia trendu jest czerwona. Logarytmiczna linia trendu używa [addTextFrameForOverriding](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#addTextFrameForOverriding-java.lang.String-) do własnej etykiety. Średnia krocząca korzysta z [setPeriod](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setPeriod-byte-) ustawionego na trzy punkty danych oraz własnego [setTrendlineName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setTrendlineName-java.lang.String-).

Wielomianowa linia trendu ma [setOrder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setOrder-byte-) ustawione na trzy i rozszerza jedną kategorię do przodu przy użyciu [setForward](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setForward-double-). Potęgowa linia trendu rozszerza jedną kategorię do tyłu przy użyciu [setBackward](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setBackward-double-).

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Użyj [setIntercept](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#setIntercept-double-) , aby ustawić wartość Y linii trendu przy X = 0. To ustawienie jest obsługiwane dla linii trendu liniowych, wykładniczych i wielomianowych.

Na przykład model kosztów produkcji może wymagać rozpoczęcia od znanych stałych kosztów równych 100, nawet gdy pomiary przy niezerowych wielkościach produkcji sugerują inną bazę. Dla liniowej linii trendu, ustalenie przecięcia ogranicza równanie `y = ax + b` do `b = 100`; nachylenie jest dopasowywane do danych pod tym ograniczeniem. Nie powoduje to jedynie przesunięcia już dopasowanej linii. Ustawienia przecięcia osi określają, gdzie osie wykresu się spotykają, a nie współczynniki dopasowanej linii trendu.

Poniższy przykład tworzy wykres punktowy (XY) z wolumenami produkcji od 1 do 4 oraz kosztami 170, 200, 230 i 260. Zapisuje wykres z domyślnym automatycznym przecięciem, ustawia przecięcie na 100 i zapisuje drugi plik PPTX. Dwa pliki różnią się jedynie ustawieniem przecięcia. Linia trendu wyświetla swoje równanie i rozciąga się do X = 0.

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

Przy automatycznym obliczeniu te dane dają `y = 30x + 140`. Ustawienie przecięcia na 100 powoduje w przybliżeniu `y = 43.33x + 100`: dopasowana wartość przy zerze odpowiada znanej bazie, a linia nie przechodzi już przez każdy punkt danych.

| Automatyczne przecięcie | Stałe przecięcie 100 |
| --- | --- |
| ![Liniowa linia trendu z automatycznie obliczonym przecięciem 140](intercept-automatic.png) | ![Liniowa linia trendu ze stałym przecięciem 100](intercept-fixed.png) |

Oba obrazy używają tych samych danych i skal osi. Linie trendu są rozszerzone do X = 0, aby pokazać ich przecięcia.

Domyślnie, [getIntercept](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#getIntercept--) zwraca `Double.NaN`, co oznacza nieokreślone przecięcie, a nie zero. Przecięcie jest wtedy obliczane automatycznie na podstawie danych.

## **Dodaj własną linię**

Własna linia to kształt narysowany nad wykresem, a nie linia trendu obliczona na podstawie danych serii. Ten przykład używa [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) , aby dodać poziomą linię do slajdu nad wykresem. Pozycja linii jest określona w współrzędnych slajdu, mierzona w punktach, więc zaczyna się od lewego krawędzi wykresu i znajduje się w połowie wysokości wykresu. Jej szerokość odpowiada szerokości wykresu. [getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) nadaje linii jednolity czerwony kolor.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

**Co oznaczają 'forward' i 'backward' w kontekście linii trendu?**

Są to długości linii trendu projekowane do przodu lub do tyłu: dla wykresów punktowych (XY) — w jednostkach osi; dla wykresów innych niż punktowe — w liczbie kategorii. Dozwolone są tylko wartości nieujemne.

**Czy linia trendu zostanie zachowana przy eksporcie prezentacji do PDF lub SVG, albo przy renderowaniu slajdu jako obrazu?**

Tak. Aspose.Slides konwertuje prezentacje do [PDF](/slides/pl/androidjava/convert-powerpoint-to-pdf/) lub [SVG](/slides/pl/androidjava/render-a-slide-as-an-svg-image/) i renderuje wykresy jako obrazy; linie trendu, jako część wykresu, są zachowywane podczas tych operacji. Metoda jest również dostępna do [wyeksportuj obraz wykresu](/slides/pl/androidjava/create-shape-thumbnails/) samego wykresu.