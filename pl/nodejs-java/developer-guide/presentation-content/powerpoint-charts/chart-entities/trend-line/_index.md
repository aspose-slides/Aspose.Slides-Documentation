---
title: Dodaj linie trendu do wykresów w prezentacji w JavaScript
linktitle: Linia trendu
type: docs
url: /pl/nodejs-java/trend-line/
keywords:
- wykres
- linia trendu
- wykładnicza linia trendu
- liniowa linia trendu
- logarytmiczna linia trendu
- linia trendu średniej kroczącej
- wielomianowa linia trendu
- potęgowa linia trendu
- niestandardowa linia trendu
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Szybko dodawaj i dostosowuj linie trendu w wykresach PowerPoint przy użyciu JavaScript i Aspose.Slides dla Node.js via Java — praktyczny przewodnik, który zaangażuje Twoją publiczność."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dodać linie trendu do wykresów w prezentacji przy użyciu Aspose.Slides. Pokazuje, jak utworzyć wykres, dodać linie trendu do serii wykresu oraz pracować z kilkoma typami linii trendu, w tym wykładniczym, liniowym, logarytmicznym, średnią kroczącą, wielomianowym i potęgowym.

Opisuje również, jak dodać własną linię do wykresu poprzez wstawienie kształtu linii, oraz zawiera krótkie FAQ dotyczące wartości projekcji linii trendu w przód i w tył oraz tego, czy linie trendu są zachowywane podczas eksportu do PDF lub SVG i przy renderowaniu wykresów jako obrazy.

## **Dodaj linię trendu**

Użyj [TrendlineCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinecollection/#add), aby dodać linię trendu do serii wykresu, wybierając jej typ za pomocą [TrendlineType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinetype/). Przykład tworzy skumulowany wykres kolumnowy z domyślnymi danymi i dodaje dwie linie trendu do każdej z trzech serii.

Wykładnicza linia trendu ukrywa swoje równanie i wartość R-kwadrat przy użyciu [setDisplayEquation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayEquation) oraz [setDisplayRSquaredValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayRSquaredValue), natomiast liniowa linia trendu jest czerwona. Logarytmiczna linia trendu używa [addTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#addTextFrameForOverriding) do niestandardowej etykiety. Średnia krocząca używa [setPeriod](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setPeriod) o wartości trzech punktów danych oraz niestandardowego [setTrendlineName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setTrendlineName).

Wielomianowa linia trendu ma [setOrder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setOrder) równy trzy i rozszerza jedną kategorię do przodu przy użyciu [setForward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setForward). Potęgowa linia trendu rozszerza jedną kategorię do tyłu przy użyciu [setBackward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setBackward).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);

    const firstSeries = chart.getChartData().getSeries().get_Item(0);

    const exponentialTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    const linearTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(red);

    const secondSeries = chart.getChartData().getSeries().get_Item(1);

    const logarithmicTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    const movingAverageTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod(java.newByte(3));
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    const thirdSeries = chart.getChartData().getSeries().get_Item(2);

    const polynomialTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder(java.newByte(3));

    const powerTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw przecięcie linii trendu**

Użyj [setIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setIntercept), aby ustawić wartość Y linii trendu przy X = 0. To ustawienie jest obsługiwane dla linii trendu liniowych, wykładniczych i wielomianowych.

Na przykład model kosztów produkcji może wymagać rozpoczęcia od znanych stałych kosztów rzędu 100, nawet gdy pomiary przy niezerowych wolumenach produkcji sugerują inną bazę. Dla liniowej linii trendu, ustalenie przecięcia ogranicza równanie `y = ax + b` do `b = 100`; nachylenie jest dopasowywane do danych przy tym ograniczeniu. Nie powoduje to po prostu przesunięcia już dopasowanej linii. Ustawienia przecięcia osi kontrolują, gdzie osie wykresu się spotykają, a nie współczynniki dopasowanej linii trendu.

Poniższy przykład tworzy wykres rozrzutu (XY) z wolumenami produkcji od 1 do 4 oraz kosztami 170, 200, 230 i 260. Zapisuje wykres z domyślnym automatycznym przecięciem, ustawia przecięcie na 100 i zapisuje drugi plik PPTX. Dwa pliki różnią się wyłącznie ustawieniem przecięcia. Linia trendu wyświetla swoje równanie i rozciąga się do X = 0.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const nameCell = workbook.getCell(0, 0, 1, "Production cost");
    const series = chart.getChartData().getSeries().add(nameCell, aspose.slides.ChartType.ScatterWithMarkers);
    const costs = [170, 200, 230, 260];

    for (let i = 0; i < costs.length; i++) {
        const xCell = workbook.getCell(0, i + 1, 0, i + 1);
        const yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    const trendline = series.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", aspose.slides.SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Przy automatycznym obliczeniu te dane dają `y = 30x + 140`. Ustawienie przecięcia na 100 powoduje natomiast przybliżenie `y = 43.33x + 100`: dopasowana wartość przy zerze odpowiada znanej bazie, podczas gdy linia już nie przechodzi przez każdy punkt danych.

| Automatyczne przecięcie | Stałe przecięcie 100 |
| --- | --- |
| ![Liniowa linia trendu z automatycznie obliczonym przecięciem 140](intercept-automatic.png) | ![Liniowa linia trendu ze stałym przecięciem 100](intercept-fixed.png) |

Oba obrazy używają tych samych danych i skal osi. Linie trendu są rozciągnięte do X = 0, aby pokazać ich przecięcia.

Domyślnie, [getIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#getIntercept) zwraca `NaN`, co oznacza nieokreślone przecięcie, a nie zero. Przecięcie jest wtedy obliczane automatycznie na podstawie danych.

## **Dodaj własną linię**

Własna linia to kształt narysowany nad wykresem, a nie linia trendu obliczana na podstawie danych serii. Ten przykład używa [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAutoShape), aby dodać poziomą linię do slajdu nad wykresem. Pozycja linii jest określona w współrzędnych slajdu, mierzonych w punktach, więc zaczyna się od lewego krawędzi wykresu i znajduje się w połowie wysokości wykresu. Jej szerokość odpowiada szerokości wykresu. [getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) nadaje linii jednolity czerwony kolor.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);

    const line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);

    presentation.save("AddCustomLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Co oznaczają 'forward' i 'backward' w kontekście linii trendu?**

Są to długości linii trendu projekowane w przód lub w tył: dla wykresów rozrzutu (XY) — w jednostkach osi; dla wykresów nie‑rozrzutu — w liczbie kategorii. Dozwolone są tylko wartości nieujemne.

**Czy linia trendu zostanie zachowana przy eksportowaniu prezentacji do PDF lub SVG, lub przy renderowaniu slajdu jako obrazu?**

Tak. Aspose.Slides konwertuje prezentacje do [PDF](/slides/pl/nodejs-java/convert-powerpoint-to-pdf/) lub [SVG](/slides/pl/nodejs-java/render-a-slide-as-an-svg-image/) i renderuje wykresy jako obrazy; linie trendu, jako część wykresu, są zachowywane podczas tych operacji. Dostępna jest również metoda do [eksportowania obrazu wykresu](/slides/pl/nodejs-java/create-shape-thumbnails/).