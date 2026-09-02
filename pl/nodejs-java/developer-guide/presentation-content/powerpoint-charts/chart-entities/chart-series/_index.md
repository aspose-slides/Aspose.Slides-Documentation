---
title: Zarządzanie seriami danych wykresu w prezentacjach przy użyciu JavaScript
linktitle: Serie danych
type: docs
url: /pl/nodejs-java/chart-series/
keywords:
- seria wykresu
- nakładanie serii
- kolor serii
- nazwa serii
- punkt danych
- komórka skoroszytu
- przerwa między seriami
- wartość ujemna
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak zarządzać seriami wykresu, punktami danych, komórkami skoroszytu, formatowaniem, nakładaniem, szerokością przerwy i wartościami ujemnymi w prezentacjach przy użyciu JavaScript."
---
## **Przegląd**

Wykres przechowuje swoje rysowane dane w skoroszycie danych wykresu. Obiekt [ChartSeries](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartseries/) reprezentuje jeden zestaw powiązanych wartości, a każdy [ChartDataPoint](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdatapoint/) w serii odnosi się do jednej lub wielu komórek skoroszytu. Obiekty [ChartCategory](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartcategory/) dostarczają etykiety lub wartości grupowania współdzielone przez serie. Nazwa serii, kategorie i wartości punktów są więc powiązane z obiektami [ChartDataCell](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdatacell/) zamiast być przechowywane wyłącznie jako tekst wyświetlany.

W typowym wykresie kategorialnym domyślny skoroszyt używa wiersza 0 dla nazw serii, kolumny 0 dla nazw kategorii oraz pozostałych komórek dla wartości serii. Indeksy arkusza, wiersza i kolumny przekazywane do [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdataworkbook/#getCell) są zerowe. Ten układ jest przydatny przy tworzeniu wykresu z danymi domyślnymi, ale nie należy zakładać, że każdy istniejący wykres go używa. W przypadku wczytanej prezentacji należy sprawdzić komórki odwoływane przez serie, kategorie i punkty danych przed zmianą wartości w skoroszycie.

Ustawienia wykresu mają trzy różne zakresy:

- Ustawienia na poziomie serii, takie jak [ChartSeries.getFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartseries/#getFormat), określają domyślny wygląd wszystkich punktów w jednej serii.
- Ustawienia punktu danych, takie jak [ChartDataPoint.getFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdatapoint/#getFormat), nadpisują wygląd serii dla jednego punktu.
- Ustawienia grupowe mają zastosowanie do kompatybilnych serii należących do tej samej [ChartSeriesGroup](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartseriesgroup/). Dostęp do grupy uzyskuje się przez [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup), gdy trzeba ustawić opcje takie jak nakładanie (overlap) lub szerokość przerwy (gap width).

Gdy nie jest ustawione wyraźne wypełnienie punktu lub serii, styl wykresu i motyw określają automatyczny wygląd. Gdy istnieje zarówno formatowanie serii, jak i punktu, formatowanie punktu ma pierwszeństwo dla tego punktu.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ustaw nakładanie serii wykresu**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartseries/#getOverlap) raportuje, jak bardzo paski lub kolumny nakładają się na siebie w wykresie 2D, w przedziale od -100 do 100 procent. Jest to projekcja ustawienia w grupie nadrzędnej serii, dostępna tylko do odczytu. Użyj [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap), aby zaktualizować wszystkie kompatybilne serie w tej grupie. Ta opcja ma zastosowanie do typów wykresów wyświetlających grupowane paski lub kolumny; nie wpływa na niepowiązane grupy serii w wykresie kombinowanym.

Poniższy przykład ustawia nakładanie dla grupy zawierającej pierwszą serię:

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

Wynik:

![The series overlap](series_overlap.png)

## **Zmień kolor wypełnienia serii**

Użyj [ChartSeries.getFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartseries/#getFormat), aby ustawić domyślne wypełnienie całej serii. Jeśli punkt już ma wyraźne wypełnienie, jego ustawienie [ChartDataPoint.getFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdatapoint/#getFormat) nadpisuje wypełnienie serii dla tego punktu.

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

Wynik:

![The color of the series](series_color.png)

## **Zmień nazwę serii**

Nazwa serii jest przechowywana w skoroszycie danych wykresu i zazwyczaj wyświetlana w legendzie. W domyślnym skoroszycie tworzonym dla wykresu kolumnowego grupowanego, komórka B1 znajduje się w wierszu 0, kolumnie 1 i zawiera nazwę pierwszej serii. Nazwane stałe w poniższym przykładzie wyraźnie określają tę strukturę:

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

Można także zaktualizować komórkę już odwoływaną przez [ChartSeries.getName](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartseries/#getName). To podejście eliminuje konieczność zakładania konkretnego wiersza i kolumny w istniejącym wykresie:

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

Wynik:

![The series name](series_name.png)

## **Pobierz automatyczny kolor wypełnienia serii**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) zwraca kolor obliczony na podstawie indeksu serii i stylu wykresu. Jest to kolor używany, gdy wypełnienie serii nie zostało wyraźnie określone. Wywołanie metody odczytuje obliczony kolor; nie przypisuje nowego wypełnienia.

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

## **Ustaw odwrócony kolor wypełnienia dla serii wykresu**

Dla serii słupkowych, kolumnowych i bąbelkowych, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) może wyświetlać wartości ujemne innym wypełnieniem. Ustaw regularne wypełnienie serii na jednolite, włącz odwrócenie i przypisz kolor dla wartości ujemnych za pomocą [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Ujemne liczby pozostają niezmienione w skoroszycie; zmienia się tylko ich kolor wyświetlania.

Poniższy przykład zastępuje domyślne dane wykresu jedną serią. Wiersz 0 arkusza zawiera nazwę serii, kolumna 0 zawiera nazwy kategorii, a kolumna 1 zawiera wartości:

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

Wynik:

![The inverted solid fill color](inverted_solid_fill_color.png)

Można włączyć odwrócenie dla jednego punktu za pomocą [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). W poniższym przykładzie odwrócenie jest wyłączone dla serii i włączone tylko dla wybranego punktu. Punkt otrzymuje także wartość ujemną, aby efekt był widoczny:

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

Aby uczynić jeden punkt pustym bez usuwania pozostałych punktów, ustaw powiązaną z nim komórkę skoroszytu na `null`. W wykresie kolumnowym wykreślana wartość jest dostępna za pośrednictwem [ChartDataPoint.getValue](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdatapoint/#getValue). Punkt danych pozostaje w tej samej pozycji kategorii, ale wykres traktuje jego wartość jako pustą zgodnie z ustawieniami pustych wartości wykresu.

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

Wykresy punktowe używają oddzielnych komórek X i Y, a wykresy bąbelkowe także używają komórki rozmiaru. Wyczyść tylko komórkę reprezentującą wartość, którą chcesz usunąć. Nie wywołuj [ChartDataPointCollection.clear](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdatapointcollection/#clear), gdy chcesz zachować pozostałe punkty, ponieważ ta metoda usuwa każdy punkt danych z kolekcji.

## **Ustaw szerokość przerwy między seriami**

Szerokość przerwy to przestrzeń między sąsiadującymi skupiskami słupków lub kolumn, wyrażona w procentach szerokości słupka lub kolumny. Podobnie jak nakładanie, należy do grupy nadrzędnej serii, a nie do jednej serii. Wywołaj [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) raz dla grupy. Większa wartość tworzy więcej przestrzeni między skupiskami; mniejsza wartość sprawia, że są gęstsze.

Poniższy przykład zmienia szerokość przerwy i zapisuje tylko ostateczną prezentację:

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

Wynik:

![The gap width](gap_width.png)

## **FAQ**

**Które typy wykresów obsługują serie danych?**

Wszystkie typy wykresów reprezentowane w wyliczeniu [ChartType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/charttype/) korzystają z danych wykresu, ale ich serie nie mają takiej samej struktury wartości ani ustawień. Na przykład wykresy kategorialne używają kategorii i wartości, wykresy punktowe używają wartości X i Y, a wykresy bąbelkowe dodają rozmiary bąbelków. Należy używać metody tworzenia punktów danych zgodnej z typem serii. Opcje takie jak nakładanie i szerokość przerwy obowiązują tylko dla kompatybilnych grup słupków lub kolumn.

**Czym jest grupa serii wykresu?**

A [ChartSeriesGroup](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartseriesgroup/) zawiera kompatybilne serie, które współdzielą ustawienia wykreślania na poziomie grupy. Wykres kombinowany może zawierać więcej niż jedną grupę, więc zmiana grupy uzyskanej przez jedną serię niekoniecznie zmieni wszystkie serie w wykresie.

**Czy nowo utworzony wykres zawiera dane domyślne?**

Tak. Domyślnie [ShapeCollection.addChart](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapecollection/#addChart) tworzy przykładowe serie, kategorie i wartości. Można edytować te komórki lub wyczyścić zarówno kolekcje serii, jak i kategorii przed dodaniem całkowicie własnego zestawu danych. Przeciążenie może również utworzyć wykres bez danych domyślnych.

**Jak obiekty wykresu są powiązane z komórkami skoroszytu?**

Nazwy serii, etykiety kategorii i wartości punktów danych odwołują się do komórek w [ChartDataWorkbook](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdataworkbook/). Zmiana odwoływanej komórki aktualizuje odpowiadający element wykresu. Tworząc własne dane, utrzymuj wiersze kategorii i wiersze wartości serii wyrównane, aby każdy punkt był wykreślony pod właściwą kategorią.

**Jak wyczyścić jeden punkt zamiast całej serii?**

Aby zachować pozycję kategorii punktu jako pusty punkt, ustaw odpowiednią komórkę wartości na `null`. Używaj [ChartDataPointCollection.clear](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdatapointcollection/#clear) tylko wtedy, gdy zamierzasz usunąć wszystkie punkty z tej serii. Jeśli usuwasz także kategorie, zaktualizuj wszystkie serie, aby ich wartości pozostały wyrównane z kolekcją kategorii.

**Jak wyświetlane są puste punkty?**

Rezultat zależy od typu wykresu i ustawienia wartości konfigurowanego przez [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs). Obsługiwane wykresy mogą wyświetlać puste miejsca jako przerwy, jako wartość zero lub poprzez połączenie sąsiednich punktów. Wybierz ustawienie odpowiadające znaczeniu brakujących danych w prezentacji.

**Jak formatowane są wartości ujemne?**

Dla obsługiwanych serii słupkowych, kolumnowych i bąbelkowych wywołaj [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) i ustaw kolor zwracany przez [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Możesz nadpisać zachowanie dla pojedynczego punktu za pomocą [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Metody te wpływają na formatowanie, a nie na przechowywane wartości liczbowe.

**Które formatowanie ma pierwszeństwo, gdy zarówno seria, jak i punkt są sformatowane?**

Wyraźne formatowanie punktu danych ma pierwszeństwo dla tego punktu. Inne punkty nadal używają wyraźnego formatu serii lub, gdy format serii nie jest zdefiniowany, automatycznego stylu i motywu wykresu. Ustawienia grup, takie jak nakładanie i szerokość przerwy, kontrolują układ i nie są nadpisaniami formatowania na poziomie punktu.

**Czy istnieje limit liczby serii, które może zawierać wykres?**

Aspose.Slides nie narzuca oddzielnego stałego limitu liczby serii. W praktyce ograniczenia pliku prezentacji, dostępna pamięć, czas renderowania i czytelność wykresu wyznaczają użyteczny limit.

**Co zmienić, gdy kolumny są zbyt blisko siebie lub zbyt daleko od siebie?**

Wywołaj [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) na odpowiedniej grupie nadrzędnej serii. Zwiększ wartość, aby poszerzyć przestrzeń między grupami, lub zmniejsz ją, aby przybliżyć grupy do siebie.