---
title: Utwórz lub zaktualizuj wykresy w prezentacjach PowerPoint w JavaScript
linktitle: Utwórz lub zaktualizuj wykresy
type: docs
weight: 10
url: /pl/nodejs-java/create-chart/
keywords:
- dodaj wykres
- utwórz wykres
- edytuj wykres
- zmień wykres
- zaktualizuj wykres
- wykres punktowy
- wykres kołowy
- wykres liniowy
- wykres mapy drzewa
- wykres giełdowy
- wykres pudełkowo-wąsłowy
- wykres lejkowy
- wykres promieniowy
- wykres histogramu
- wykres radarowy
- wykres wielokategorii
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Twórz i dostosowuj wykresy w prezentacjach PowerPoint przy użyciu Aspose.Slides for Node.js via Java. Dodawaj, formatuj i edytuj wykresy za pomocą praktycznych przykładów kodu w JavaScript."
---
## **Przegląd**

Ten artykuł zawiera kompleksowy przewodnik, jak tworzyć i dostosowywać wykresy przy użyciu Aspose.Slides for Node.js via Java. Dowiesz się, jak programowo dodać wykres do slajdu, wypełnić go danymi oraz zastosować różne opcje formatowania, aby spełnić określone wymagania projektowe. W całym artykule szczegółowe przykłady kodu ilustrują każdy krok – od inicjalizacji prezentacji i obiektu wykresu po konfigurowanie serii, osi i legend. Postępując zgodnie z tym przewodnikiem, zdobędziesz solidne zrozumienie, jak integrować dynamiczne generowanie wykresów w aplikacjach Node.js, upraszczając proces tworzenia prezentacji opartych na danych.

## **Tworzenie wykresu**

Wykresy pomagają szybko zwizualizować dane i uzyskać wnioski, które mogą nie być od razu oczywiste w tabeli lub arkuszu kalkulacyjnym.

**Dlaczego tworzyć wykresy?**

Korzystając z wykresów, możesz:

* agregować, kondensować lub podsumowywać duże ilości danych na jednym slajdzie prezentacji;
* ujawniać wzorce i trendy w danych;
* wyznaczać kierunek i momentum danych w czasie lub względem określonej jednostki miary;
* wykrywać obserwacje odstające, aberracje, odchylenia, błędy i nielogiczne dane;
* przekazywać lub prezentować złożone dane.

W PowerPoint możesz tworzyć wykresy za pomocą funkcji *Wstaw*, która zapewnia szablony do projektowania wielu typów wykresów. Korzystając z Aspose.Slides, możesz tworzyć zarówno standardowe wykresy (oparte na popularnych typach) oraz wykresy niestandardowe.

{{% alert color="info" title="Note" %}}
Użyj wyliczenia [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) w module [aspose.slides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/). Wartości w tym wyliczeniu odpowiadają różnym typom wykresów.
{{% /alert %}}

### **Utwórz wykresy słupkowe grupowane**

Ten przykład używa [addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) do stworzenia wykresu słupkowego grupowanego porównującego dwie serie w trzech kategoriach. Serie używają wypełnień na czerwono i zielono, a indywidualne etykiety pokazują nazwy kategorii, nazwy serii i wartości. Indeks arkusza 0 odnosi się do pierwszego arkusza w osadzonym skoroszycie wykresu.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    let workbook = chart.getChartData().getChartDataWorkbook();
    let worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    chart.getChartData().getSeries().add(seriesNameCell, chart.getType());
    seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    let categoryCell = workbook.getCell(worksheetIndex, 1, 0, "Category 1");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(worksheetIndex, 2, 0, "Category 2");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(worksheetIndex, 3, 0, "Category 3");
    chart.getChartData().getCategories().add(categoryCell);

    let series = chart.getChartData().getSeries().get_Item(0);

    let valueCell = workbook.getCell(worksheetIndex, 1, 1, 20);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 1, 50);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 1, 30);
    series.getDataPoints().addDataPointForBarSeries(valueCell);

    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    series = chart.getChartData().getSeries().get_Item(1);

    valueCell = workbook.getCell(worksheetIndex, 1, 2, 30);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 2, 10);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 2, 60);
    series.getDataPoints().addDataPointForBarSeries(valueCell);

    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 128, 0));

    let label = series.getDataPoints().get_Item(0).getLabel();
    label.getDataLabelFormat().setShowCategoryName(true);

    label = series.getDataPoints().get_Item(1).getLabel();
    label.getDataLabelFormat().setShowSeriesName(true);

    label = series.getDataPoints().get_Item(2).getLabel();
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setShowSeriesName(true);
    label.getDataLabelFormat().setSeparator("/");

    presentation.save("AsposeChart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Wynik:

![Wykres słupkowy grupowany](clustered_column_chart.png)

### **Utwórz wykresy punktowe**

Wykresy punktowe (znane także jako wykresy rozrzutu lub wykresy x‑y) są często używane do sprawdzania wzorców lub demonstrowania korelacji między dwoma zmiennymi.

Użyj wykresu punktowego, gdy:

* masz sparowane dane liczbowe;
* masz dwie zmienne, które dobrze ze sobą współgrają;
* chcesz określić, czy dwie zmienne są ze sobą powiązane;
* masz zmienną niezależną, która ma wiele wartości dla zmiennej zależnej.

Ten przykład rysuje dwa zestawy wartości x‑y. Pierwsza seria używa prostych linii ze znacznikami‑gwiazdkami, druga – wygładzonych linii ze znacznikami‑kołami; obie używają rozmiaru znacznika 10, skonfigurowanego metodą [setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/marker/setsize/). Metoda [setSymbol](https://reference.aspose.com/slides/nodejs-java/aspose.slides/marker/setsymbol/) kontroluje kształt znacznika.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    let workbook = chart.getChartData().getChartDataWorkbook();
    let worksheetIndex = 0;

    chart.getChartData().getSeries().clear();

    let seriesNameCell = workbook.getCell(worksheetIndex, 1, 1, "Series 1");
    chart.getChartData().getSeries().add(seriesNameCell, chart.getType());
    seriesNameCell = workbook.getCell(worksheetIndex, 1, 3, "Series 2");
    chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    let series = chart.getChartData().getSeries().get_Item(0);

    let xValueCell = workbook.getCell(worksheetIndex, 2, 1, 1);
    let yValueCell = workbook.getCell(worksheetIndex, 2, 2, 3);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    xValueCell = workbook.getCell(worksheetIndex, 3, 1, 2);
    yValueCell = workbook.getCell(worksheetIndex, 3, 2, 10);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);

    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);

    series = chart.getChartData().getSeries().get_Item(1);

    xValueCell = workbook.getCell(worksheetIndex, 2, 3, 5);
    yValueCell = workbook.getCell(worksheetIndex, 2, 4, 2);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    xValueCell = workbook.getCell(worksheetIndex, 3, 3, 3);
    yValueCell = workbook.getCell(worksheetIndex, 3, 4, 1);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    xValueCell = workbook.getCell(worksheetIndex, 4, 3, 2);
    yValueCell = workbook.getCell(worksheetIndex, 4, 4, 2);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    xValueCell = workbook.getCell(worksheetIndex, 5, 3, 5);
    yValueCell = workbook.getCell(worksheetIndex, 5, 4, 1);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);

    presentation.save("AsposeChart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Wynik:

![Wykres punktowy](scatter_chart.png)

### **Utwórz wykresy kołowe**

Wykresy kołowe najlepiej służą do pokazania zależności części do całości w danych, szczególnie gdy dane zawierają etykiety kategorii ze wartościami liczbowymi. Jeśli jednak Twoje dane zawierają wiele części lub etykiet, rozważ użycie wykresu słupkowego.

Ten przykład tworzy wykres kołowy z trzema wartościami kwartalnymi. Każdy wycinek ma niestandardowe wypełnienie i obramowanie, a etykiety wyświetlają różne kombinacje wartości, procentów i informacji o serii. Metoda [setFirstSliceAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setfirstsliceangle/) ustawia początek pierwszego wycinka pod kątem 180 stopni.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 20, 20, 500, 300);

    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    let workbook = chart.getChartData().getChartDataWorkbook();
    let worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    let categoryCell = workbook.getCell(0, 1, 0, "1st Qtr");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, 2, 0, "2nd Qtr");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, 3, 0, "3rd Qtr");
    chart.getChartData().getCategories().add(categoryCell);

    let seriesNameCell = workbook.getCell(0, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    let valueCell = workbook.getCell(worksheetIndex, 1, 1, 20);
    series.getDataPoints().addDataPointForPieSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 1, 50);
    series.getDataPoints().addDataPointForPieSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 1, 30);
    series.getDataPoints().addDataPointForPieSeries(valueCell);

    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);

    let firstSlice = series.getDataPoints().get_Item(0);
    firstSlice.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstSlice.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));

    firstSlice.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstSlice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    firstSlice.getFormat().getLine().setWidth(3.0);
    firstSlice.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThick));
    firstSlice.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDash));

    let secondSlice = series.getDataPoints().get_Item(1);
    secondSlice.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondSlice.getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 165, 42, 42));

    secondSlice.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondSlice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    secondSlice.getFormat().getLine().setWidth(3.0);
    secondSlice.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.Single));
    secondSlice.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDot));

    let thirdSlice = series.getDataPoints().get_Item(2);
    thirdSlice.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdSlice.getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 127, 80));

    thirdSlice.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdSlice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    thirdSlice.getFormat().getLine().setWidth(2.0);
    thirdSlice.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThin));
    thirdSlice.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDotDot));

    let firstLabel = series.getDataPoints().get_Item(0).getLabel();
    firstLabel.getDataLabelFormat().setShowValue(true);

    let secondLabel = series.getDataPoints().get_Item(1).getLabel();
    secondLabel.getDataLabelFormat().setShowValue(true);
    secondLabel.getDataLabelFormat().setShowLegendKey(true);
    secondLabel.getDataLabelFormat().setShowPercentage(true);

    let thirdLabel = series.getDataPoints().get_Item(2).getLabel();
    thirdLabel.getDataLabelFormat().setShowSeriesName(true);
    thirdLabel.getDataLabelFormat().setShowPercentage(true);

    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);

    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);

    presentation.save("PieChart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Wynik:

![Wykres kołowy](pie_chart.png)

Aby poprawić czytelność etykiet poza wykresem kołowym, zobacz [Format Leader Lines](/slides/pl/nodejs-java/chart-data-label/#format-leader-lines) – przykład pozycjonowania etykiet i dostosowywania koloru, szerokości, przezroczystości oraz stylu kreski linii.

### **Utwórz wykresy liniowe**

Wykresy liniowe (znane także jako wykresy liniowe) są najlepsze w sytuacjach, gdy chcesz pokazać zmiany wartości w czasie. Korzystając z wykresu liniowego, możesz jednocześnie porównać dużą ilość danych, śledzić zmiany i trendy w czasie, uwydatniać anomalie w seriach danych i nie tylko.

Ten przykład używa [addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) do stworzenia wykresu liniowego z domyślnymi seriami i kategoriami, po czym zapisuje prezentację jako PPTX.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let lineChart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 20, 20, 500, 300);

    presentation.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Domyślnie punkty na wykresie liniowym są łączone prostymi ciągłymi liniami. Jeśli chcesz, aby punkty były łączone kreskami, wywołaj [setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setdashstyle/) z wartością z [LineDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let lineChart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 20, 20, 500, 300);

    for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++)
    {
        let series = lineChart.getChartData().getSeries().get_Item(i);
        series.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));
    }
}
finally
{
    presentation.dispose();
}
```

Wynik:

![Wykres liniowy](line_chart.png)

### **Utwórz wykresy mapy drzewa**

Wykresy mapy drzewa są najlepsze dla danych sprzedażowych, gdy chcesz pokazać względny rozmiar kategorii danych i szybko zwrócić uwagę na elementy, które są dużymi wkładami w każdej kategorii.

Ten przykład tworzy mapę drzewa z ośmioma liśćmi pogrupowanymi w cztery pędy i dwie gałęzie. Metoda [setGroupingItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategorylevelsmanager/setgroupingitem/) przypisuje pędy na poziomie grupowania 1 oraz gałęzie na poziomie 2. Wartości określają względne rozmiary prostokątów, a etykiety kategorii i nakładające się etykiety nadrzędne identyfikują hierarchię.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.Treemap, 20, 20, 500, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // Gałąź 1
    let categoryCell = workbook.getCell(0, "C1", "Leaf1");
    let leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    categoryCell = workbook.getCell(0, "C2", "Leaf2");
    chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "C3", "Leaf3");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    categoryCell = workbook.getCell(0, "C4", "Leaf4");
    chart.getChartData().getCategories().add(categoryCell);

    // Gałąź 2
    categoryCell = workbook.getCell(0, "C5", "Leaf5");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    categoryCell = workbook.getCell(0, "C6", "Leaf6");
    chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "C7", "Leaf7");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    categoryCell = workbook.getCell(0, "C8", "Leaf8");
    chart.getChartData().getCategories().add(categoryCell);

    let series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    let valueCell = workbook.getCell(0, "D1", 4);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D2", 5);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D3", 3);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D4", 6);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D5", 9);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D6", 9);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D7", 4);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D8", 3);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);

    series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);

    presentation.save("Treemap.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Wynik:

![Wykres mapy drzewa](treemap_chart.png)

### **Utwórz wykresy wodospadowe**

Wykres wodospadowy pokazuje, jak zmiany dodatnie i ujemne przyczyniają się do wartości końcowej. Na przykład rozbiórka zysku może zaczynać się od przychodów, odejmować koszty i dodawać inne przychody. Kolumny zmian „pływają” pomiędzy poprzednią a nową wartością bieżącą, a kolumny sumy rozciągają się od zera do wartości skumulowanej.

Poniższy przykład używa kwot w tysiącach dolarów amerykańskich:

| Kategoria | Wartość w skoroszycie | Typ kolumny |
| --- | ---: | --- |
| Przychody | 1000 | Wzrost |
| Koszt sprzedaży | -400 | Spadek |
| Zysk brutto | 600 | Suma pośrednia |
| Koszty operacyjne | -200 | Spadek |
| Inny przychód | 50 | Wzrost |
| Zysk netto | 450 | Suma końcowa |

Aby oznaczyć punkt jako sumę pośrednią lub końcową, wywołaj jego metodę [setSetAsTotal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setsetastotal/) z wartością `true`. Podaj rzeczywistą skumulowaną kwotę w komórce skoroszytu tego punktu: `600` dla zysku brutto (`1000 - 400`) i `450` dla zysku netto (`600 - 200 + 50`). Metoda oznacza kolumnę jako sumę; nie oblicza ani nie wypełnia wartości komórki. Nie używaj zera jako zastępnika ani nie podawaj innej zmiany dla punktu sumy. Kolumna sumy wyświetla wartość skumulowaną bez ponownego dodawania jej do wartości bieżącej.

Ten kompletny przykład JavaScript tworzy wykres przy użyciu członka `Waterfall` wyliczenia [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/), czyści domyślne dane i wypełnia osadzony skoroszyt. Indeks arkusza `0` wybiera pierwszy arkusz; kolumna A zawiera nazwy kategorii, a kolumna B – wartości. Każda komórka wartości jest dodawana metodą [addDataPointForWaterfallSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/adddatapointforwaterfallseries/). Indeksy punktów zerobazowe `2` i `5` identyfikują sumy pośrednie i końcowe. Wywołanie [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) z `true` wyświetla kwoty na kolumnach. Nie wymaga się żadnej prezentacji ani skoroszytu wejściowego.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.Waterfall, 20, 20, 680, 200);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Profit breakdown (USD thousands)");
    chart.getChartTitle().setOverlay(false);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    let worksheetIndex = 0;

    workbook.clear(worksheetIndex);

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Profit");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.Waterfall);
    let categories = [ "Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit" ];
    let values = [ 1000, -400, 600, -200, 50, 450 ];

    for (let i = 0; i < categories.length; i++)
    {
        let categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categories[i]);
        chart.getChartData().getCategories().add(categoryCell);
        let valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForWaterfallSeries(valueCell);
    }

    // Trzeci i szósty punkt reprezentują sumy, a nie dodatkowe zmiany.
    series.getDataPoints().get_Item(2).setSetAsTotal(true);
    series.getDataPoints().get_Item(5).setSetAsTotal(true);
    series.setShowConnectorLines(true);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("WaterfallChart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Wywołaj metodę poziomu serii [setShowConnectorLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setshowconnectorlines/) z `true`, aby pokazać linie łączące kolejne kolumny i ułatwić śledzenie wartości bieżącej. Aby ukryć te linie, zamień wywołanie metody w przykładzie na `series.setShowConnectorLines(false);` przed zapisem. Zmiana wpływa tylko na widoczność linii, nie na dane ani sumy.

Zapisana prezentacja pokazuje zysk brutto 600 oraz zysk netto 450, przy czym obie sumy są rysowane od zera:

![Wykres wodospadowy pokazujący przychody, koszty, zysk brutto 600 i zysk netto 450, z etykietami wartości i liniami łączącymi](waterfall_chart.png)

### **Utwórz wykresy giełdowe**

Wykresy giełdowe służą do wyświetlania danych finansowych, takich jak otwarcie, maksimum, minimum i zamknięcie, pomagając analizować trendy rynkowe i zmienność. Dostarczają istotnych informacji o wynikach akcji, wspierając inwestorów i analityków w podejmowaniu świadomych decyzji.

Ten przykład tworzy wykres otwarcie‑wysoko‑nisko‑zamknięcie z czterema seriami w tej kolejności i trzema kategoriami. Metoda [setUpDownBars](https://reference.aspose.com/slides/nodejs-java/aspose.slides/updownbarsmanager/setupdownbars/) włącza słupki w górę/dół, a [getHiLowLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/gethilowlinesformat/) kontroluje linie wysokie‑niskie pokazujące zakres cen, podczas gdy indywidualne linie serii i drobne poziome linie siatki są ukryte.

Menedżer zwrócony przez [getUpDownBars](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/getupdownbars/) udostępnia oddzielne obiekty formatowania poprzez [getUpBarsFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/updownbarsmanager/getupbarsformat/) i [getDownBarsFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/updownbarsmanager/getdownbarsformat/). Użyj metod [getFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/format/getfill/) i [getLine](https://reference.aspose.com/slides/nodejs-java/aspose.slides/format/getline/) każdego obiektu, aby niezależnie ustawić wypełnienie i obrys. Ten przykład używa zielonych słupków z ciemno‑zielonym obrysem dla rosnących przedziałów oraz pomarańczowo‑czerwonych słupków z ciemno‑czerwonym obrysem dla spadających przedziałów.

Podaj wartości liczbowe dla wszystkich czterech serii w każdej kategorii, przy czym Wysokość i Niskość obejmują Otwarcie i Zamknięcie. Słupki porównują Zamknięcie z Otwarciem **w tej samej kategorii**, nie z poprzednią kategorią: A spada z 72 do 25, podczas gdy B rośnie z 25 do 38, a C rośnie z 38 do 50. Równe wartości Otwarcia i Zamknięcia nie tworzą widocznego wypełnionego przedziału. Słupki w górę/dół rozciągają się od Otwarcia do Zamknięcia; linie wysokie‑niskie rozciągają się od Niskiego do Wysokiego. Te słupki należą do grupy serii i nie są zwykłymi seriami wykresu słupkowego.

To formatowanie działa również z wykresami [Line and LineWithMarkers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) zawierającymi co najmniej dwie serie w tej samej grupie i odpowiednie wartości liczbowe dla każdej kategorii. Dla tych niewyświetlanych wykresów liniowych słupki w górę/dół porównują pierwszą i ostatnią serię: wyższa ostatnia wartość powoduje słupek w górę, niższa – słupek w dół. Odwrócenie tych serii odwraca klasyfikację. Poniższy przykład używa [OpenHighLowClose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/); nie zakładaj, że inne warianty giełdowe, skumulowane‑liniowe lub 3D używają tej samej struktury danych lub interpretacji przedziału.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 20, 20, 500, 150, false);

    let workbook = chart.getChartData().getChartDataWorkbook();

    let categoryCell = workbook.getCell(0, 1, 0, "A");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, 2, 0, "B");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, 3, 0, "C");
    chart.getChartData().getCategories().add(categoryCell);

    let seriesNameCell = workbook.getCell(0, 0, 1, "Open");
    chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.OpenHighLowClose);
    seriesNameCell = workbook.getCell(0, 0, 2, "High");
    chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.OpenHighLowClose);
    seriesNameCell = workbook.getCell(0, 0, 3, "Low");
    chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.OpenHighLowClose);
    seriesNameCell = workbook.getCell(0, 0, 4, "Close");
    chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.OpenHighLowClose);

    let series = chart.getChartData().getSeries().get_Item(0);
    let valueCell = workbook.getCell(0, 1, 1, 72);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 1, 25);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 1, 38);
    series.getDataPoints().addDataPointForStockSeries(valueCell);

    series = chart.getChartData().getSeries().get_Item(1);
    valueCell = workbook.getCell(0, 1, 2, 172);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 2, 57);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 2, 57);
    series.getDataPoints().addDataPointForStockSeries(valueCell);

    series = chart.getChartData().getSeries().get_Item(2);
    valueCell = workbook.getCell(0, 1, 3, 12);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 3, 12);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 3, 13);
    series.getDataPoints().addDataPointForStockSeries(valueCell);

    series = chart.getChartData().getSeries().get_Item(3);
    valueCell = workbook.getCell(0, 1, 4, 25);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 4, 38);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 4, 50);
    series.getDataPoints().addDataPointForStockSeries(valueCell);

    let upDownBars = chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars();
    upDownBars.setUpDownBars(true);

    upDownBars.getUpBarsFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    upDownBars.getUpBarsFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 50, 205, 50));
    upDownBars.getUpBarsFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    upDownBars.getUpBarsFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 100, 0));
    upDownBars.getUpBarsFormat().getLine().setWidth(2);

    upDownBars.getDownBarsFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    upDownBars.getDownBarsFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 69, 0));
    upDownBars.getDownBarsFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    upDownBars.getDownBarsFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 139, 0, 0));
    upDownBars.getDownBarsFormat().getLine().setWidth(2);
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        let stockSeries = chart.getChartData().getSeries().get_Item(i);
        stockSeries.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    presentation.save("Stock-chart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Wynik, wyeksportowany z PowerPoint:

![Wykres giełdowy z pomarańczowo‑czerwonym spadającym przedziałem dla A i zielonymi rosnącymi przedziałami dla B i C](stock_chart.png)

### **Utwórz wykresy pudełkowo‑wąsłowe**

Wykresy pudełkowo‑wąsłowe służą do wyświetlania rozkładu danych poprzez podsumowanie kluczowych miar statystycznych, takich jak mediana, kwartyle i ewentualne obserwacje odstające. Są szczególnie przydatne w analizie eksploracyjnej i badaniach statystycznych, umożliwiając szybkie zrozumienie zmienności danych i identyfikację anomalii.

Ten przykład tworzy wykres pudełkowo‑wąsłowy z sześciu wartości. Metoda [setQuartileMethod](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setquartilemethod/) wybiera wyłączną metodę obliczania kwartylów. Przykład włącza również linie średniej, znaczniki średniej, punkty wewnętrzne i punkty odstające.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.BoxAndWhisker, 20, 20, 500, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    let categoryCell = workbook.getCell(0, "A1", "Category 1");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A2", "Category 2");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A3", "Category 3");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A4", "Category 4");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A5", "Category 5");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A6", "Category 6");
    chart.getChartData().getCategories().add(categoryCell);

    let series = chart.getChartData().getSeries().add(aspose.slides.ChartType.BoxAndWhisker);

    series.setQuartileMethod(aspose.slides.QuartileMethodType.Exclusive);
    series.setShowMeanLine(true);
    series.setShowMeanMarkers(true);
    series.setShowInnerPoints(true);
    series.setShowOutlierPoints(true);

    let valueCell = workbook.getCell(0, "B1", 15);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B2", 41);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B3", 16);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B4", 10);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B5", 23);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B6", 16);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);

    presentation.save("BoxAndWhisker.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

### **Utwórz wykresy lejkowe**

Wykresy lejkowe służą do wizualizacji procesów obejmujących kolejne etapy, w których wolumen danych maleje wraz z przejściem z jednego kroku do kolejnego. Są szczególnie pomocne przy analizie współczynników konwersji, identyfikacji wąskich gardeł oraz monitorowaniu efektywności procesów sprzedaży lub marketingu.

Ten przykład używa [addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) do dodania wykresu lejkowego do pierwszego slajdu istniejącej prezentacji. Zastępuje domyślne dane sześcioma kategoriami i wartościami od 50 do 500, po czym zapisuje zaktualizowaną prezentację. Wejściowa prezentacja musi zawierać co najmniej jeden slajd.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation("test.pptx");
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.Funnel, 50, 50, 500, 400);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    let categoryCell = workbook.getCell(0, "A1", "Category 1");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A2", "Category 2");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A3", "Category 3");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A4", "Category 4");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A5", "Category 5");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A6", "Category 6");
    chart.getChartData().getCategories().add(categoryCell);

    let series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Funnel);

    let valueCell = workbook.getCell(0, "B1", 50);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B2", 100);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B3", 200);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B4", 300);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B5", 400);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B6", 500);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);

    presentation.save("Funnel.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Wynik:

![Wykres lejkowy](funnel_chart.png)

### **Utwórz wykresy promieniowe**

Wykresy promieniowe służą do wizualizacji danych hierarchicznych, wyświetlając poziomy jako koncentryczne pierścienie. Pomagają ilustrować zależności części‑do‑całości i są idealne do przedstawiania zagnieżdżonych kategorii i podkategorii w przejrzystym, zwartym formacie.

Ten przykład tworzy wykres promieniowy z ośmioma liśćmi pogrupowanymi w cztery pędy i dwie gałęzie. Metoda [setGroupingItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategorylevelsmanager/setgroupingitem/) przypisuje pędy na poziomie grupowania 1 oraz gałęzie na poziomie 2. Etykiety kategorii identyfikują segmenty, a wartości określają ich względne rozmiary.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.Sunburst, 20, 20, 500, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // Gałąź 1
    let categoryCell = workbook.getCell(0, "C1", "Leaf1");
    let leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    categoryCell = workbook.getCell(0, "C2", "Leaf2");
    chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "C3", "Leaf3");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    categoryCell = workbook.getCell(0, "C4", "Leaf4");
    chart.getChartData().getCategories().add(categoryCell);

    // Gałąź 2
    categoryCell = workbook.getCell(0, "C5", "Leaf5");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    categoryCell = workbook.getCell(0, "C6", "Leaf6");
    chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "C7", "Leaf7");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    categoryCell = workbook.getCell(0, "C8", "Leaf8");
    chart.getChartData().getCategories().add(categoryCell);

    let series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    let valueCell = workbook.getCell(0, "D1", 4);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D2", 5);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D3", 3);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D4", 6);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D5", 9);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D6", 9);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D7", 4);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D8", 3);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);

    presentation.save("Sunburst.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Wynik:

![Wykres promieniowy](sunburst_chart.png)

### **Utwórz wykresy histogramu**

Wykresy histogramu pokazują, jak wartości liczbowe rozkładają się w przedziały (kosze). Dla comiesięcznych raportów czasu przetwarzania zamówień używaj tej samej szerokości kosza i progów, aby utrzymać spójność przedziałów i ułatwić porównywanie rozkładów.

Wywołaj [setAggregationType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaggregationtype/) na osi poziomej z trybem z [AxisAggregationType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axisaggregationtype/). [setBinWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setbinwidth/) ma zastosowanie tylko do `ByBinWidth`; [setNumberOfBins](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberofbins/) – tylko do `ByNumberOfBins`. Użyj `Automatic`, aby pozwolić wykresowi wybrać kosze.

#### **Użyj stałej szerokości kosza**

Ten przykład grupuje czasy przetwarzania w przedziały 10‑minutowe, z oddzielnymi koszami dla czasów ≤ 10 min i > 40 min. Włącz te kosze metodami [setUnderflowBin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setunderflowbin/) i [setOverflowBin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setoverflowbin/). Podając wyraźne progi przy użyciu [setUnderflowBin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setunderflowbin/) i [setOverflowBin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setoverflowbin/), wywołaj [setAutomaticUnderflowBin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticunderflowbin/) i [setAutomaticOverflowBin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticoverflowbin/) z `false`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.Histogram, 20, 20, 680, 200);

    chart.setLegend(false);
    chart.setTitle(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    let series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Histogram);
    let values = [ 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 ];
    for (let i = 0; i < values.length; i++)
    {
        let valueCell = workbook.getCell(0, i, 0, values[i]);
        series.getDataPoints().addDataPointForHistogramSeries(valueCell);
    }

    let axis = chart.getAxes().getHorizontalAxis();
    axis.setAggregationType(aspose.slides.AxisAggregationType.ByBinWidth);
    axis.setBinWidth(10);
    axis.setUnderflowBin(true);
    axis.setAutomaticUnderflowBin(false);
    axis.setUnderflowBin(10);
    axis.setOverflowBin(true);
    axis.setAutomaticOverflowBin(false);
    axis.setOverflowBin(40);

    presentation.save("Histogram-bin-width.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Prezentacja wyświetlana w PowerPoint pokazuje liczbę elementów w koszach **3, 4, 4, 4 i 2**. Kosz podprzepływu zawiera `5, 10, 10`, więc jego próg jest inkluzywny. Kosz przepełnienia obejmuje tylko `41, 50`, więc jego próg jest ekskluzywny; oba wartości równe `40` pozostają w poprzednim przedziale. Kosze wewnętrzne zawierają wartości większe niż ich dolna granica i mniejsze lub równe górnej granicy.

![Histogram z koszami 10‑minutowymi i wyraźnymi progami podprzepływu i przepełnienia](histogram_bin_width.png)

#### **Określ liczbę koszy**

Aby uzyskać stały poziom szczegółowości zamiast stałych przedziałów, poproś o pięć koszy dla tych samych danych. Ten przykład wyłącza kosze podprzepływu i przepełnienia. Wykres określa szerokość na podstawie zakresu danych, więc granice mogą się zmieniać między raportami.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.Histogram, 20, 20, 680, 200);

    chart.setLegend(false);
    chart.setTitle(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    let series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Histogram);
    let values = [ 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 ];
    for (let i = 0; i < values.length; i++)
    {
        let valueCell = workbook.getCell(0, i, 0, values[i]);
        series.getDataPoints().addDataPointForHistogramSeries(valueCell);
    }

    let axis = chart.getAxes().getHorizontalAxis();
    axis.setAggregationType(aspose.slides.AxisAggregationType.ByNumberOfBins);
    axis.setNumberOfBins(5);

    presentation.save("Histogram-bin-count.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Pięć koszy ma liczby elementów **4, 4, 4, 4 i 1**. Porównaj ten rozkład z wynikiem o stałej szerokości powyżej: wartości wejściowe są identyczne, ale granice się różnią.

![Histogram z pięcioma koszami obliczonymi na podstawie tych samych danych](histogram_bin_count.png)

### **Utwórz wykresy radarowe**

Wykresy radarowe służą do wyświetlania danych wielozmiennych w dwuwymiarowym formacie, umożliwiając łatwe porównanie kilku zmiennych jednocześnie. Są szczególnie przydatne do identyfikacji wzorców, mocnych i słabych stron w wielu miarach wydajności lub atrybutach.

Ten przykład używa [addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) do utworzenia wykresu radarowego z domyślnymi seriami i kategoriami, po czym zapisuje prezentację jako PPTX.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addChart(aspose.slides.ChartType.Radar, 20, 20, 500, 300);

    presentation.save("Radar-chart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Wynik:

![Wykres radarowy](radar_chart.png)

### **Utwórz wykresy wielokategorii**

Wykresy wielokategorii służą do wyświetlania danych, które obejmują więcej niż jedną grupę kategorialną, umożliwiając porównywanie wartości w wielu wymiarach jednocześnie. Są szczególnie przydatne, gdy trzeba analizować trendy i zależności w złożonych, wielowarstwowych zestawach danych.

Ten przykład tworzy wykres słupkowy grupowany z ośmioma kategoriami ustawionymi w czterech parach. Metoda [setGroupingItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategorylevelsmanager/setgroupingitem/) nadaje każdej parze wspólną etykietę na poziomie grupowania 1, tworząc oś kategorii z zarówno indywidualnymi, jak i grupowymi etykietami.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    let worksheetIndex = 0;

    let categoryCell = workbook.getCell(0, "c2", "A");
    let category = chart.getChartData().getCategories().add(categoryCell);
    category.getGroupingLevels().setGroupingItem(1, "Group1");
    categoryCell = workbook.getCell(0, "c3", "B");
    category = chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "c4", "C");
    category = chart.getChartData().getCategories().add(categoryCell);
    category.getGroupingLevels().setGroupingItem(1, "Group2");
    categoryCell = workbook.getCell(0, "c5", "D");
    category = chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "c6", "E");
    category = chart.getChartData().getCategories().add(categoryCell);
    category.getGroupingLevels().setGroupingItem(1, "Group3");
    categoryCell = workbook.getCell(0, "c7", "F");
    category = chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "c8", "G");
    category = chart.getChartData().getCategories().add(categoryCell);
    category.getGroupingLevels().setGroupingItem(1, "Group4");
    categoryCell = workbook.getCell(0, "c9", "H");
    category = chart.getChartData().getCategories().add(categoryCell);

    let seriesNameCell = workbook.getCell(0, "D1", "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.ClusteredColumn);

    let valueCell = workbook.getCell(worksheetIndex, "D2", 10);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D3", 20);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D4", 30);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D5", 40);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D6", 50);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D7", 60);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D8", 70);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D9", 80);
    series.getDataPoints().addDataPointForBarSeries(valueCell);

    presentation.save("AsposeChart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Wynik:

![Wykres wielokategorii](multi_category_chart.png)

#### **Usuń etykietę kwartału**

Pobierz [quarters.pptx](quarters.pptx) i umieść go w katalogu roboczym. Jego wykres pokazuje dziewięć miesięcy i jedną serię sprzedaży z wartościami od 10 do 18. Na osi kategorii Q1 obejmuje stycznia‑marzec, Q2 – kwiecień‑czerwiec, Q3 – lipiec‑wrzesień.

Kwiecień jest czwartą kategorią (indeks 3) i zawiera etykietę Q2. Użyj [getGroupingLevels](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/getgroupinglevels/) aby uzyskać poziomy grupowania kwietnia, a następnie wywołaj [deleteGroupingItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategorylevelsmanager/deletegroupingitem/) z poziomem 1, aby usunąć jego etykietę kwartału. Poziom 0 reprezentuje sam miesiąc i nie może być usunięty tą metodą.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("quarters.pptx");
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const april = chart.getChartData().getCategories().get_Item(3);
    april.getGroupingLevels().deleteGroupingItem(1);

    presentation.save("quarters-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopened = new aspose.slides.Presentation("quarters-updated.pptx");
try {
    const chart = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
    const data = chart.getChartData();

    const categories = data.getCategories();
    const months = [];
    
    for (let i = 0; i < categories.size(); i++) {
        months.push(categories.get_Item(i).getAsCell().getValue());
    }
    const points = data.getSeries().get_Item(0).getDataPoints();
    const sales = [];
    for (let i = 0; i < points.size(); i++) {
        sales.push(points.get_Item(i).getValue().getData());
    }
    console.log(months.join(", "));
    console.log(sales.join(", "));
} finally {
    reopened.dispose();
}
```

Po ponownym otwarciu wykresu przykład wypisuje oryginalne miesiące (`Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep`) oraz wartości sprzedaży (`10, 11, 12, 13, 14, 15, 16, 17, 18`) w tej samej kolejności. Otwórz `quarters-updated.pptx` w PowerPoint, aby porównać etykiety osi. Etykieta Q2 oraz granica grupy przed kwietniem znikają, więc Q1 obejmuje styczeń‑czerwiec. Q3 nadal zaczyna się w lipcu.

![Etykiety kwartałów przed i po usunięciu. Po lewej Q2 obejmuje kwiecień‑czerwiec. Po prawej Q1 obejmuje styczeń‑czerwiec.](quarter-label-comparison.png)

### **Utwórz wykresy map**

Wykresy map służą do wizualizacji danych geograficznych poprzez mapowanie informacji na konkretne lokalizacje, takie jak kraje, stany czy miasta. Są szczególnie przydatne przy analizie trendów regionalnych, danych demograficznych i rozkładów przestrzennych w klarowny, wizualnie atrakcyjny sposób.

Ten przykład używa [addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) do stworzenia wykresu mapy z domyślnymi danymi geograficznymi i zapisuje go do przeglądania w PowerPoint.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.Map, 20, 20, 500, 300);

    presentation.save("mapChart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Wynik:

![Wykres mapy](map_chart.png)

{{% alert color="info" title="Note" %}}
Powyższy obrazek pokazuje zapisany plik prezentacji otwarty w PowerPoint. Aspose.Slides zapisuje wykres mapy i jego dane poprawnie, ale sam nie rysuje wykresów map: gdy slajd zawierający wykres zostanie wyrenderowany do obrazu lub skonwertowany do PDF albo SVG, obszar wykresu pozostaje pusty. Inne kształty na tym samym slajdzie nie są dotknięte.
{{% /alert %}}

### **Utwórz wykresy kombinowane**

Wykres kombinowany (lub wykres combo) łączy dwa lub więcej typów wykresów w jednym grafie. Ten wykres pozwala podkreślić, porównać lub zbadać różnice między dwoma lub więcej zestawami danych, pomagając zidentyfikować zależności między nimi.

![Wykres kombinowany](combination_chart.png)

Ten przykład łączy dwie serie słupkowe grupowane z serią liniową w czterech kategoriach. Kolumny używają głównej pionowej osi, podczas gdy [setPlotOnSecondAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setplotonsecondaxis/) umieszcza linię na drugiej pionowej osi po prawej stronie. Funkcje pomocnicze konfigurują tytuł, legendę, etykiety osi i linie siatki.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function createComboChart()
{
    let presentation = new aspose.slides.Presentation();
    try
    {
        let chart = createChartWithFirstSeries(presentation.getSlides().get_Item(0));

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", aspose.slides.SaveFormat.Pptx);
    }
    finally
    {
        presentation.dispose();
    }
}

function createChartWithFirstSeries(slide)
{
    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let portionFormat = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    portionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    portionFormat.setFontHeight(18);

    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    let worksheetIndex = 0;

    let categoryCell = workbook.getCell(worksheetIndex, 1, 0, "Category 1");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(worksheetIndex, 2, 0, "Category 2");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(worksheetIndex, 3, 0, "Category 3");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(worksheetIndex, 4, 0, "Category 4");
    chart.getChartData().getCategories().add(categoryCell);

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    let valueCell = workbook.getCell(worksheetIndex, 1, 1, 4.3);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 1, 2.5);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 1, 3.5);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 4, 1, 4.5);
    series.getDataPoints().addDataPointForBarSeries(valueCell);

    return chart;
}

function addSecondSeriesToChart(chart)
{
    let workbook = chart.getChartData().getChartDataWorkbook();
    let worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    let valueCell = workbook.getCell(worksheetIndex, 1, 2, 2.4);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 2, 4.4);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 2, 1.8);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 4, 2, 2.8);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
}

function addThirdSeriesToChart(chart)
{
    let workbook = chart.getChartData().getChartDataWorkbook();
    let worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.Line);

    let valueCell = workbook.getCell(worksheetIndex, 1, 3, 2.0);
    series.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 3, 2.0);
    series.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 3, 3.0);
    series.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 4, 3, 5.0);
    series.getDataPoints().addDataPointForLineSeries(valueCell);

    series.setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat(chart)
{
    let horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(horizontalAxis, "X Axis");

    let verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(verticalAxis, "Y Axis 1");

    let majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    majorGridLinesFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat(chart)
{
    let secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(aspose.slides.AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(aspose.slides.CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    let secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(aspose.slides.AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle(axis, axisTitle)
{
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    let titlePortionFormat = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    titlePortionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titlePortionFormat.setFontHeight(12);
}

createComboChart();
```

## **Aktualizacja wykresów**

Aspose.Slides for Node.js via Java umożliwia aktualizację wykresów PowerPoint poprzez modyfikację danych wykresu, formatowania i stylizacji. Ta funkcjonalność upraszcza proces utrzymywania prezentacji na bieżąco z dynamiczną zawartością i zapewnia, że wykresy dokładnie odzwierciedlają aktualne dane i standardy wizualne.

Ten przykład aktualizuje wykres o nazwie "My chart" na pierwszym slajdzie istniejącej prezentacji. Wymaga dwóch serii kolumnowych po trzy punkty danych każda, z etykietami kategorii w kolumnie A i nazwami serii w pierwszym wierszu pierwszego arkusza. Przykład używa [getCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcell/) do zmiany komórek skoroszytu, aktualizuje wartości serii, dodaje trzecią serię i zmienia typ wykresu na cylindry grupowane metodą [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/settype/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let chartName = "My chart";

let presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try
{
    let slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++)
    {
        let shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IChart") && chartName === shape.getName())
        {
            let chart = shape;
            let worksheetIndex = 0;

            let workbook = chart.getChartData().getChartDataWorkbook();

            workbook.getCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.getCell(worksheetIndex, 2, 0, "Modified Category 2");

            let series = chart.getChartData().getSeries().get_Item(0);

            workbook.getCell(worksheetIndex, 0, 1, "New_Series 1");
            series.getDataPoints().get_Item(0).getValue().setData(90);
            series.getDataPoints().get_Item(1).getValue().setData(123);
            series.getDataPoints().get_Item(2).getValue().setData(44);

            series = chart.getChartData().getSeries().get_Item(1);

            workbook.getCell(worksheetIndex, 0, 2, "New_Series 2");
            series.getDataPoints().get_Item(0).getValue().setData(23);
            series.getDataPoints().get_Item(1).getValue().setData(67);
            series.getDataPoints().get_Item(2).getValue().setData(99);

            let seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
            series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

            let valueCell = workbook.getCell(worksheetIndex, 1, 3, 20);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
            valueCell = workbook.getCell(worksheetIndex, 2, 3, 50);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
            valueCell = workbook.getCell(worksheetIndex, 3, 3, 30);
            series.getDataPoints().addDataPointForBarSeries(valueCell);

            chart.setType(aspose.slides.ChartType.ClusteredCylinder);
        }
    }

    presentation.save("AsposeChartModified.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

## **Ustaw zakres danych dla wykresu**

Aby sprawdzić zakres już używany przez istniejący wykres, zobacz [Retrieve a Chart's Data Range](/slides/pl/nodejs-java/chart-workbook/#retrieve-a-charts-data-range).

Aspose.Slides for Node.js via Java zapewnia elastyczność definiowania określonego zakresu danych z arkusza jako źródła dla danych wykresu. Oznacza to, że możesz bezpośrednio mapować fragment arkusza na wykres, kontrolując, które komórki przyczyniają się do serii i kategorii wykresu. W rezultacie możesz łatwo aktualizować i synchronizować wykresy z najnowszymi zmianami danych w arkuszu, zapewniając, że Twoje prezentacje PowerPoint odzwierciedlają bieżące i dokładne informacje.

Ten przykład używa [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) aby ustawić źródło danych wykresu o nazwie "My chart" na pierwszym slajdzie istniejącej prezentacji na `Sheet1!A1:B4`. Skoroszyt wykresu musi zawierać ten arkusz oraz wypełniony zakres z nagłówkiem serii w pierwszym wierszu, etykietami kategorii w kolumnie A i trzema wartościami w kolumnie B.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let chartName = "My chart";

let presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try
{
    let slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++)
    {
        let shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IChart") && chartName === shape.getName())
        {
            let chart = shape;
            chart.getChartData().setRange("Sheet1!A1:B4");
        }
    }

    presentation.save("SetDataRange.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

## **Użyj domyślnych znaczników w wykresach**

Kiedy używasz domyślnych znaczników w wykresach, każda seria wykresu automatycznie otrzymuje inny domyślny symbol znacznika.

Ten przykład używa [addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) do stworzenia wykresu z dwoma seriami liniowymi i legendą. Ustawienia znacznika dostępne poprzez [getMarker](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getmarker/) zachowują automatycznie przydzielone symbole znaczników. Pierwsza seria zawiera wartość ujemną i brakującą wartość, reprezentowaną przez `null`, podczas gdy druga ma wartość dla każdej kategorii.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();

    let seriesNameCell = workbook.getCell(0, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    let categoryCell = workbook.getCell(0, 1, 0, "C1");
    chart.getChartData().getCategories().add(categoryCell);
    let valueCell = workbook.getCell(0, 1, 1, 24);
    series.getDataPoints().addDataPointForLineSeries(valueCell);

    categoryCell = workbook.getCell(0, 2, 0, "C2");
    chart.getChartData().getCategories().add(categoryCell);
    valueCell = workbook.getCell(0, 2, 1, 23);
    series.getDataPoints().addDataPointForLineSeries(valueCell);

    categoryCell = workbook.getCell(0, 3, 0, "C3");
    chart.getChartData().getCategories().add(categoryCell);
    valueCell = workbook.getCell(0, 3, 1, -10);
    series.getDataPoints().addDataPointForLineSeries(valueCell);

    categoryCell = workbook.getCell(0, 4, 0, "C4");
    chart.getChartData().getCategories().add(categoryCell);
    valueCell = workbook.getCell(0, 4, 1, null);
    series.getDataPoints().addDataPointForLineSeries(valueCell);

    seriesNameCell = workbook.getCell(0, 0, 2, "Series 2");
    let secondSeries = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    valueCell = workbook.getCell(0, 1, 2, 30);
    secondSeries.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 2, 10);
    secondSeries.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 2, 60);
    secondSeries.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(0, 4, 2, 40);
    secondSeries.getDataPoints().addDataPointForLineSeries(valueCell);

    chart.setLegend(true);
    chart.getLegend().setOverlay(false);

    presentation.save("DefaultMarkersInChart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

## **FAQ**

**Jakie typy wykresów są obsługiwane przez Aspose.Slides for Node.js via Java?**

Aspose.Slides for Node.js via Java obsługuje szeroką gamę typów wykresów, w tym słupkowe, liniowe, kołowe, obszarowe, punktowe, histogramy, radarowe i wiele innych. Ta elastyczność pozwala wybrać najbardziej odpowiedni typ wykresu do potrzeb wizualizacji danych.

**Jak dodać nowy wykres do slajdu?**

Aby dodać wykres, najpierw tworzysz instancję klasy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), pobierasz żądany slajd przy użyciu jego indeksu, a następnie wywołujesz metodę dodającą wykres, określając typ wykresu i początkowe dane. Ten proces integruje wykres bezpośrednio w Twojej prezentacji.

**Jak mogę zaktualizować dane wyświetlane w wykresie?**

Możesz zaktualizować dane wykresu, uzyskując dostęp do jego skoroszytu danych ([ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/)), usuwając domyślne serie i kategorie, a następnie dodając własne dane. Dzięki temu możesz programowo odświeżyć wykres, aby odzwierciedlał najnowsze dane.

**Czy można dostosować wygląd wykresu?**

Tak, Aspose.Slides for Node.js via Java zapewnia rozbudowane opcje dostosowywania. Możesz modyfikować kolory, czcionki, etykiety, legendy oraz inne elementy formatowania, aby dopasować wygląd wykresu do swoich konkretnych wymagań projektowych.