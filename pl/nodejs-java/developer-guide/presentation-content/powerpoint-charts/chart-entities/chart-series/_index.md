---
title: Zarządzanie danymi serii wykresu w prezentacjach przy użyciu JavaScript
linktitle: Serie danych
type: docs
url: /pl/nodejs-java/chart-series/
keywords:
- serie wykresu
- nakładanie się serii
- kolor serii
- nazwa serii
- punkt danych
- komórka skoroszytu
- luka serii
- wartość ujemna
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak zarządzać seriami wykresu, punktami danych, komórkami skoroszytu, formatowaniem, nakładaniem się, szerokością luki oraz wartościami ujemnymi w prezentacjach przy użyciu JavaScript."
---
## **Przegląd**

Wykres może przechowywać swoje wyświetlane wartości w komórkach skoroszytu lub bezpośrednio jako literały numeryczne. [ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/) reprezentuje jeden zestaw powiązanych wartości, a każdy [ChartDataPoint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/) reprezentuje punkt w tej serii. Obiekty [ChartCategory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/) zapewniają etykiety lub wartości grupujące współdzielone przez serie. W wykresach tworzonych z danymi domyślnymi, nazwy serii, kategorie i wartości punktów używają obiektów [ChartDataCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/) z skoroszytu wykresu.

Dla typowego wykresu kategorialnego domyślny skoroszyt używa wiersza 0 dla nazw serii, kolumny 0 dla nazw kategorii i pozostałych komórek dla wartości serii. Indeksy arkusza, wiersza i kolumny przekazywane do [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcell/) są zerowo‑indeksowane. Ten układ jest przydatny, gdy tworzysz wykres z danymi domyślnymi, ale nie zakładaj, że każdy istniejący wykres go używa. Wczytując prezentację, sprawdź komórki odwoływane przez serie, kategorie i punkty danych przed zmianą wartości w skoroszycie.

Ustawienia wykresu mają trzy różne zakresy:

- Ustawienia na poziomie serii, takie jak [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/), dostarczają domyślny wygląd dla wszystkich punktów w jednej serii.
- Ustawienia punktu danych, takie jak [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/), nadpisują wygląd serii dla jednego punktu.
- Ustawienia grupy dotyczą kompatybilnych serii należących do tego samego [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/). Uzyskaj dostęp do grupy przez [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/), gdy musisz ustawić opcje takie jak nakładanie się lub szerokość luki.

Gdy nie jest ustawione jawne wypełnienie punktu lub serii, styl wykresu i motyw określają automatyczny wygląd. Gdy istnieje zarówno formatowanie serii, jak i punktu, formatowanie punktu ma pierwszeństwo dla tego punktu.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ustaw wartości serii przy użyciu literałów numerycznych**

Używaj literałów numerycznych, gdy wartości serii pochodzą z danych aplikacji lub obliczeń i nie wymagają odwołań do komórek arkusza. Wywołaj [setDataSourceTypeForValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) z [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) przed przypisaniem wyniku [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/) każdego punktu poprzez [setAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/setasliteraldouble/).

Ustawienie kolekcji kontroluje typ źródła wszystkich wartości punktów w tej serii. Metoda [getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/basechartvalue/) każdego punktu zgłasza wybrany typ; zmień go poprzez ustawienie kolekcji. W przypadku `Worksheet`, użyj [getAsCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getascell/) aby uzyskać dostęp do odwołanej komórki. W przypadku `DoubleLiterals`, użyj [getAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getasliteraldouble/) lub `setAsLiteralDouble`, aby odczytać lub zapisać liczbę bezpośrednio.

Poniższy przykład tworzy wykres kolumnowy z domyślnymi seriami i kategoriami, a następnie przypisuje obliczone wartości 10, 20, … do istniejących punktów pierwszej serii. Zapisuje prezentację, otwiera ją ponownie i wypisuje zapisane wartości.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(aspose.slides.DataSourceType.DoubleLiterals);
    for (let i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("numeric_literals.pptx");
try {
    const reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    const reopenedChart = reopenedSlide.getShapes().get_Item(0);
    const reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (let i = 0; i < reopenedSeries.getDataPoints().size(); i++) {
        const point = reopenedSeries.getDataPoints().get_Item(i);
        console.log(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

Typ źródła wartości punktu jest oddzielny od [ChartData.getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/), który identyfikuje wewnętrzną lub zewnętrzną konfigurację skoroszytu wykresu. Użycie literałów numerycznych nie usuwa wbudowanego skoroszytu. W tym przykładzie skoroszyt pozostaje dostępny dla etykiet kategorii, nazw serii i pozostałych serii. Zobacz [Chart Workbook](/slides/pl/nodejs-java/chart-workbook/) po więcej informacji o zarządzaniu skoroszytem.

Dla wykresów punktowych i bąbelkowych użyj [setDataSourceTypeForXValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) i [setDataSourceTypeForYValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) aby wybrać źródła dla [getXValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getxvalue/) i [getYValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getyvalue/). Wykresy bąbelkowe używają także [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) dla [getBubbleSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getbubblesize/). Ustaw każdy odpowiedni źródło na `DoubleLiterals` przed przypisaniem liczb przez metodę `setAsLiteralDouble` tego źródła.

## **Ustaw nakładanie się serii wykresu**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getoverlap/) zwraca, jak bardzo słupki lub kolumny nakładają się w wykresie 2D, w przedziale od –100 do 100 procent. Jest to odczytywana projekcja ustawienia w grupie serii nadrzędnej. Użyj [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/) aby zaktualizować wszystkie kompatybilne serie w tej grupie. Opcja ma zastosowanie do typów wykresów wyświetlających grupowane słupki lub kolumny; nie wpływa na niezależne grupy serii w wykresie kombinowanym.

Poniższy przykład ustawia nakładanie się dla grupy zawierającej pierwszą serię:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const overlapPercent = java.newByte(30);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Nowy wykres zawiera przykładowe serie, kategorie i wartości.
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rezultat:

![The series overlap](series_overlap.png)

## **Zmień kolor wypełnienia serii**

Użyj [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/) aby ustawić domyślne wypełnienie dla całej serii. Jeśli punkt ma już jawne wypełnienie, jego ustawienie [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/) nadpisuje wypełnienie serii dla tego punktu.

Poniższy przykład stosuje jednolite niebieskie wypełnienie do pierwszej serii:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(blueColor);

    presentation.save("series_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rezultat:

![The color of the series](series_color.png)

## **Zmień nazwę serii**

Nazwa serii jest przechowywana w skoroszycie danych wykresu i zwykle wyświetlana w legendzie. W domyślnym skoroszycie utworzonym dla wykresu kolumnowego grupowanego komórka B1 znajduje się w wierszu 0, kolumnie 1 i zawiera nazwę pierwszej serii. Stałe nazwane w poniższym przykładzie czynią tę strukturę explicite:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const seriesNameRowIndex = 0;
const firstSeriesColumnIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const workbook = chart.getChartData().getChartDataWorkbook();
    const seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Możesz także zaktualizować komórkę już odwoływaną przez [ChartSeries.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getname/). To podejście unika zakładania konkretnego wiersza i kolumny w istniejącym wykresie:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const firstNameCellIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rezultat:

![The series name](series_name.png)

### **Utwórz serię z nazwą z wielu komórek**

Złożona nazwa serii jest przydatna, gdy nazwa produktu i okres raportowania są przechowywane w oddzielnych komórkach skoroszytu. Na przykład możesz połączyć `Product A` w B1 i `2026` w C1 w jedną nazwę serii, zachowując jednocześnie powiązanie obu części z ich komórkami źródłowymi.

Użyj [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcellcollection/), aby pobrać zakres nazw, a następnie przekaż tę kolekcję do [ChartSeriesCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriescollection/add/). Argument `skipHiddenCells` steruje tym, czy ukryte komórki są uwzględniane: `true` je wyklucza, `false` włącza. Ten przykład używa `false`, aby uwzględnić każdą komórkę w zakresie nazw.

Poniższy przykład tworzy prezentację z jedną serią i dwoma punktami danych. Komórki B1:C1 dostarczają tylko nazwę serii; A2:A3 dostarczają etykiety kategorii, a B2:B3 wartości liczbowe.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // Te dwie komórki dostarczają nazwę serii.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    const nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    const series = chart.getChartData().getSeries().add(nameCells, aspose.slides.ChartType.ClusteredColumn);

    // Oddzielne komórki dostarczają kategorie i numeryczne punkty danych.
    const northCategory = workbook.getCell(0, 1, 0, "North");
    const southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    const northValue = workbook.getCell(0, 1, 1, 120);
    const southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynikowa nazwa serii to `Product A 2026`, ze spacją pomiędzy dwoma wartościami komórek. Legenda wyświetla to jako jedną pozycję dla obu kolumn. Poniższy obraz ilustruje rezultat:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Pobierz automatyczny kolor wypełnienia serii**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getautomaticseriescolor/) zwraca kolor obliczony na podstawie indeksu serii i stylu wykresu. Jest to kolor używany, gdy wypełnienie serii nie zostało jawnie określone. Wywołanie metody odczytuje obliczony kolor; nie przypisuje nowego wypełnienia.

Poniższy przykład wypisuje automatyczny kolor każdej domyślnej serii:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const seriesCount = chart.getChartData().getSeries().size();
    for (let seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const automaticColor = series.getAutomaticSeriesColor();
        const automaticColorText = automaticColor.toString();
        console.log("Series " + seriesIndex + ": " + automaticColorText);
    }
} finally {
    presentation.dispose();
}
```

Przykładowe wyjście dla domyślnego stylu wykresu:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Dokładne kolory zależą od stylu wykresu i motywu.

## **Ustaw odwrócone wypełnienie koloru dla serii wykresu**

Dla serii słupkowych, kolumnowych i bąbelkowych [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) może wyświetlać wartości ujemne innym wypełnieniem. Ustaw regularne wypełnienie serii na jednolite, włącz odwrócenie i przypisz kolor ujemnych wartości przez [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Liczby ujemne pozostają niezmienione w skoroszycie; zmienia się jedynie ich kolor wyświetlania.

Poniższy przykład zastępuje domyślne dane wykresu jedną serią. Wiersz 0 arkusza zawiera nazwę serii, kolumna 0 nazwy kategorii, a kolumna 1 wartości:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const headerRowIndex = 0;
const categoryColumnIndex = 0;
const firstSeriesColumnIndex = 1;
const firstDataRowIndex = 1;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const categoryNames = ["Category 1", "Category 2", "Category 3"];
const seriesValues = [-20, 50, -30];

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    const chartType = chart.getType();
    const series = chartData.getSeries().add(seriesNameCell, chartType);

    for (let categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        const dataRowIndex = firstDataRowIndex + categoryIndex;
        const categoryName = categoryNames[categoryIndex];
        const seriesValue = seriesValues[categoryIndex];

        const categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(redColor);

    presentation.save("inverted_solid_fill_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rezultat:

![The inverted solid fill color](inverted_solid_fill_color.png)

Możesz włączyć odwrócenie dla jednego punktu przez [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/). W poniższym przykładzie odwrócenie jest wyłączone dla serii i włączone tylko dla wybranego punktu. Punkt otrzymuje także wartość ujemną, aby efekt był widoczny:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 2;
const negativeValue = -30;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(redColor);
    series.setInvertIfNegative(false);

    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Wyczyść konkretną wartość punktu danych**

Aby uczynić jeden punkt pustym bez usuwania pozostałych, ustaw jego komórkę w skoroszycie na `null`. Dla wykresu kolumnowego wyświetlana wartość jest dostępna przez [ChartDataPoint.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/). Punkt pozostaje w tym samym miejscu kategorii, ale wykres traktuje jego wartość jako pustą zgodnie z ustawieniami pustych wartości wykresu.

Poniższy przykład czyści tylko drugi punkt w pierwszej serii:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wykresy punktowe używają oddzielnych komórek X i Y, a wykresy bąbelkowe dodatkowo komórki rozmiaru. Czyść tylko tę komórkę, którą zamierzasz usunąć. Nie wywołuj [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/), gdy chcesz zachować pozostałe punkty, ponieważ metoda usuwa wszystkie punkty z kolekcji.

## **Kontroluj wyświetlanie pustych komórek**

Ukryte komórki zawierające wartości to odrębny przypadek od pustych komórek. Aby włączać lub wyłączać dane z ukrytych wierszy i kolumn arkusza, zobacz [Include Data from Hidden Rows and Columns](/slides/pl/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Pusta komórka skoroszytu oznacza brak danych; komórka zawierająca `0` oznacza znaną wartość numeryczną. Wywołaj [ChartDataCell.setValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setvalue/) z `null`, aby uczynić komórkę pustą. Liczba zero pozostaje zero, niezależnie od ustawień pustych komórek.

Użyj [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) aby wybrać, jak wykres wyświetla puste komórki. To ustawienie ma zastosowanie do całego wykresu. Zmienia sposób rysowania pustych miejsc, nie wypełniając pustej komórki zerem ani wartością interpolowaną.

Poniższy, samodzielny przykład tworzy wykres liniowy z jedną serią, czyści wartość dla Dnia 3 i zapisuje wykres w trzech trybach. Nie wymaga pliku wejściowego. [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) używa arkusza 0, kolumny 0 dla etykiet kategorii i kolumny 1 dla wartości; wiersz 0 przechowuje nazwę serii. Końcowe dane to `10, 20, empty, 30, 40`.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 40, 40, 640, 400);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    const series = chartData.getSeries().add(seriesNameCell, chart.getType());
    const values = [10, 20, 25, 30, 40];

    for (let i = 0; i < values.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Pozostaw Dzień 3 naprawdę pusty, zachowując jego kategorię i punkt danych.
    workbook.getCell(0, 3, 1).setValue(null);

    const modes = [aspose.slides.DisplayBlanksAsType.Gap, aspose.slides.DisplayBlanksAsType.Zero, aspose.slides.DisplayBlanksAsType.Span];
    const modeNames = ["Gap", "Zero", "Span"];
    for (let i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Każdy plik wyjściowy przechowuje tryb wybrany przed zapisem: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` i `empty_cells_Span.pptx`. Aby zapisać tylko jedną wersję, ustaw żądany tryb i zapisz prezentację raz, zamiast iterować po trybach.

Poniższe porównanie pokazuje te same dane w trzech plikach. Dzień 3 jest pusty w skoroszycie we wszystkich przypadkach:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Widoczny efekt zależy od typu wykresu. Wykres liniowy ułatwia porównanie wszystkich trzech trybów. Wykresy słupkowe i kolumnowe nie mają linii łączącej brakującą kategorię, więc `Span` nie może wygenerować połączenia pokazanego powyżej; brakująca kolumna i kolumna o zerowej wysokości mogą wyglądać podobnie. Podobnie wykres punktowy z samymi znacznikami nie ma linii łączącej. Nie oczekuj trzech odrębnych wyników dla każdego typu wykresu; sprawdź wynik dla używanego typu.

## **Ustaw szerokość luki serii**

Szerokość luki to odstęp między sąsiadującymi grupami słupków lub kolumn, wyrażony jako procent szerokości słupka lub kolumny. Podobnie jak nakładanie się, należy ona do grupy serii nadrzędnej, a nie do jednej serii. Wywołaj [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) raz dla grupy. Większa wartość tworzy więcej przestrzeni między grupami; mniejsza – bardziej zagęszczone grupy.

Poniższy przykład zmienia szerokość luki i zapisuje tylko końcową prezentację:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const gapWidthPercent = 30;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rezultat:

![The gap width](gap_width.png)

## **FAQ**

**Które typy wykresów obsługują serie danych?**

Wszystkie typy wykresów reprezentowane przez wyliczenie [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) używają danych wykresu, ale ich serie nie zawsze mają taką samą strukturę wartości lub ustawienia. Na przykład wykresy kategorialne używają kategorii i wartości, wykresy punktowe – wartości X i Y, a wykresy bąbelkowe dodatkowo rozmiary bąbelków. Używaj metody tworzenia punktu danych odpowiadającej typowi serii. Opcje takie jak nakładanie się i szerokość luki mają zastosowanie tylko do kompatybilnych grup słupków lub kolumn.

**Czym jest grupa serii wykresu?**

[ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) zawiera kompatybilne serie, które współdzielą ustawienia poziomu grupy. Wykres kombinowany może zawierać więcej niż jedną grupę, więc zmiana grupy uzyskanej przez jedną serię niekoniecznie zmienia wszystkie serie w wykresie.

**Czy nowo utworzony wykres zawiera dane domyślne?**

Tak. Domyślnie [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) tworzy przykładowe serie, kategorie i wartości. Możesz edytować te komórki lub wyczyścić zarówno kolekcje serii, jak i kategorii przed dodaniem w pełni własnego zestawu danych. Istnieje przeciążenie, które może także utworzyć wykres bez danych domyślnych.

**Jak obiekty wykresu są połączone z komórkami skoroszytu?**

Nazwy serii, etykiety kategorii i wartości punktów danych odwołują się do komórek w [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/). Zmiana odwołanej komórki aktualizuje odpowiadający element wykresu. Tworząc własne dane, utrzymuj wyrównanie wierszy kategorii i wierszy wartości serii, aby każdy punkt był rysowany pod właściwą kategorią.

**Jak wyczyścić jeden punkt zamiast całej serii?**

Ustaw odpowiednią komórkę wartości na `null`, aby zachować pozycję kategorii punktu jako pusty punkt. Używaj [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/) wyłącznie wtedy, gdy zamierzasz usunąć wszystkie punkty z tej serii. Jeśli usuwasz także kategorie, zaktualizuj każdą serię, aby ich wartości pozostały wyrównane z kolekcją kategorii.

**Jak wyświetlane są puste punkty?**

Rezultat zależy od typu wykresu oraz wartości skonfigurowanej przez [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/). Obsługiwane wykresy mogą wyświetlać puste miejsca jako przerwy, jako wartości zero lub łącząc sąsiadujące punkty. Wybierz ustawienie odpowiadające znaczeniu brakujących danych w prezentacji. Zobacz [Control the Display of Empty Cells](#control-the-display-of-empty-cells) po kompletny przykład i porównanie wizualne.

**Jak formatowane są wartości ujemne?**

Dla obsługiwanych serii słupkowych, kolumnowych i bąbelkowych wywołaj [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) i ustaw kolor zwracany przez [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Możesz nadpisać zachowanie dla pojedynczego punktu przy pomocy [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/). Metody te wpływają na formatowanie, nie na zapisane wartości liczbowe.

**Które formatowanie wygrywa, gdy zarówno seria, jak i punkt są sformatowane?**

Jawne formatowanie punktu danych ma pierwszeństwo dla tego punktu. Inne punkty kontynuują używanie jawnego formatu serii lub, gdy format serii nie jest określony, automatycznego stylu i motywu wykresu. Ustawienia grupy, takie jak nakładanie się i szerokość luki, kontrolują układ i nie są nadpisaniami formatowania punktowego.

**Czy istnieje limit liczby serii w wykresie?**

Aspose.Slides nie narzuca osobnego, stałego limitu liczby serii. W praktyce ograniczenia pliku prezentacji, dostępna pamięć, czas renderowania i czytelność wykresu określają praktyczny limit.

**Co zmienić, gdy kolumny są za blisko siebie lub za daleko?**

Wywołaj [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) na odpowiedniej grupie serii nadrzędnej. Zwiększ wartość, aby poszerzyć odstęp między grupami, lub zmniejsz, aby przybliżyć je do siebie.