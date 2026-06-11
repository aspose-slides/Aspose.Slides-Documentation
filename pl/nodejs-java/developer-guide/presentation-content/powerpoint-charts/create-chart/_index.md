---
title: Tworzenie lub aktualizacja wykresów w prezentacjach PowerPoint w JavaScript
linktitle: Tworzenie lub aktualizacja wykresów
type: docs
weight: 10
url: /pl/nodejs-java/create-chart/
keywords:
- dodaj wykres
- twórz wykres
- edytuj wykres
- zmień wykres
- aktualizuj wykres
- wykres rozproszony
- wykres kołowy
- wykres liniowy
- wykres mapy drzewa
- wykres giełdowy
- wykres pudełkowo‑wąsowy
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
description: "Twórz i dostosowuj wykresy w prezentacjach PowerPoint za pomocą Aspose.Slides dla Node.js. Dodawaj, formatuj i edytuj wykresy z praktycznymi przykładami kodu w JavaScript."
---
## **Przegląd**

Ten artykuł zapewnia kompleksowy przewodnik, jak tworzyć i dostosowywać wykresy przy użyciu Aspose.Slides. Dowiesz się, jak programowo dodać wykres do slajdu, wypełnić go danymi oraz zastosować różne opcje formatowania, aby spełnić określone wymagania projektowe. W całym artykule szczegółowe przykłady kodu ilustrują każdy krok, od inicjalizacji prezentacji i obiektu wykresu po konfigurowanie serii, osi i legend. Postępując zgodnie z tym przewodnikiem, zdobędziesz solidne zrozumienie, jak integrować dynamiczne generowanie wykresów w aplikacjach, upraszczając proces tworzenia prezentacji opartych na danych.

## **Tworzenie wykresu**
Wykresy pomagają szybko wizualizować dane i uzyskiwać wnioski, które nie są od razu oczywiste z tabeli lub arkusza kalkulacyjnego. 


**Dlaczego tworzyć wykresy?**

Korzystając z wykresów, możesz

* zagregować, skondensować lub podsumować duże ilości danych na jednym slajdzie w prezentacji
* ujawnić wzorce i trendy w danych
* wywnioskować kierunek i dynamikę danych w czasie lub w odniesieniu do określonej jednostki miary 
* wykrywać wartości odstające, aberracje, odchylenia, błędy, nielogiczne dane itp.
* przekazywać lub prezentować złożone dane

W programie PowerPoint możesz tworzyć wykresy za pomocą funkcji wstawiania, która udostępnia szablony do projektowania wielu typów wykresów. Korzystając z Aspose.Slides, możesz tworzyć zwykłe wykresy (oparte na popularnych typach) oraz wykresy niestandardowe. 

{{% alert color="primary" %}} 

Aby umożliwić tworzenie wykresów, Aspose.Slides udostępnia klasę [ChartType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartType). Pola w tej klasie odpowiadają różnym typom wykresów.

{{% /alert %}} 

### **Tworzenie normalnych wykresów**

*_Kroki: Utwórz wykres_*
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Kroki:</em> Utwórz wykres PowerPoint w JavaScript</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Kroki:</em> Utwórz wykres prezentacji w JavaScript</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Kroki:</em> Utwórz wykres prezentacji PowerPoint w JavaScript</strong></a>

_Kroki kodu:_

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
2. Pobierz odniesienie do slajdu za pomocą jego indeksu.
3. Dodaj wykres z danymi i określ preferowany typ wykresu. 
4. Dodaj tytuł wykresu. 
5. Uzyskaj dostęp do arkusza danych wykresu.
6. Wyczyść wszystkie domyślne serie i kategorie.
7. Dodaj nowe serie i kategorie.
8. Dodaj nowe dane wykresu dla serii.
9. Dodaj kolor wypełnienia dla serii wykresu.
10. Dodaj etykiety dla serii wykresu. 
11. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod JavaScript pokazuje, jak utworzyć zwykły wykres:

```javascript
// Tworzy instancję klasy prezentacji, która reprezentuje plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Uzyskuje dostęp do pierwszego slajdu
    var sld = pres.getSlides().get_Item(0);
    // Dodaje wykres z domyślnymi danymi
    var chart = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 0, 0, 500, 500);
    // Ustawia tytuł wykresu
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    // Ustawia pierwszą serię, aby wyświetlała wartości
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Ustawia indeks arkusza danych wykresu
    var defaultWorksheetIndex = 0;
    // Pobiera arkusz danych wykresu
    var fact = chart.getChartData().getChartDataWorkbook();
    // Usuwa domyślnie wygenerowane serie i kategorie
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    // Dodaje nowe serie
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Dodaje nowe kategorie
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Pobiera pierwszą serię wykresu
    var series = chart.getChartData().getSeries().get_Item(0);
    // Teraz wypełnia dane serii
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Ustawia kolor wypełnienia dla serii
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Pobiera drugą serię wykresu
    series = chart.getChartData().getSeries().get_Item(1);
    // Wypełnia dane serii
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Ustawia kolor wypełnienia dla serii
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // Tworzy niestandardowe etykiety dla każdej kategorii dla nowej serii
    // Ustawia pierwszą etykietę, aby wyświetlała nazwę kategorii
    var lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    // Wyświetla wartość dla trzeciej etykiety
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    // Zapisuje prezentację z wykresem
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Tworzenie wykresów rozproszonych**
Wykresy rozproszone (znane także jako wykresy punktowe lub wykresy x‑y) są często używane do sprawdzania wzorców lub demonstrowania korelacji pomiędzy dwoma zmiennymi. 

Możesz chcieć użyć wykresu rozproszonego, gdy 

* masz sparowane dane liczbowe
* masz 2 zmienne, które dobrze współgrają
* chcesz określić, czy 2 zmienne są ze sobą powiązane
* masz zmienną niezależną, która ma wiele wartości dla zmiennej zależnej

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Kroki:</em> Utwórz wykres rozproszony w JavaScript</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Kroki:</em> Utwórz wykres rozproszony PowerPoint w JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Kroki:</em> Utwórz wykres rozproszony w prezentacji PowerPoint w JavaScript</strong></a>

1. Postępuj zgodnie z krokami opisanymi w sekcji [Tworzenie normalnych wykresów](#creating-normal-charts)
2. W trzecim kroku dodaj wykres z danymi i określ typ wykresu jako jeden z następujących
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/charttype/#ScatterWithMarkers) - _Reprezentuje wykres rozproszony z markerami._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Reprezentuje wykres rozproszony połączony krzywymi, z markerami danych._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Reprezentuje wykres rozproszony połączony krzywymi, bez markerów danych._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Reprezentuje wykres rozproszony połączony liniami, z markerami danych._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Reprezentuje wykres rozproszony połączony liniami, bez markerów danych._

Ten kod JavaScript pokazuje, jak utworzyć wykresy rozproszone z różnymi seriami markerów:

```javascript
// Tworzy instancję klasy prezentacji, która reprezentuje plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Uzyskuje dostęp do pierwszego slajdu
    var slide = pres.getSlides().get_Item(0);
    // Tworzy domyślny wykres
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    // Pobiera indeks domyślnego arkusza danych wykresu
    var defaultWorksheetIndex = 0;
    // Pobiera arkusz danych wykresu
    var fact = chart.getChartData().getChartDataWorkbook();
    // Usuwa serię demonstracyjną
    chart.getChartData().getSeries().clear();
    // Dodaje nowe serie
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    // Pobiera pierwszą serię wykresu
    var series = chart.getChartData().getSeries().get_Item(0);
    // Dodaje nowy punkt (1:3) do serii
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    // Dodaje nowy punkt (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    // Zmienia typ serii
    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);
    // Zmienia znacznik serii wykresu
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);
    // Pobiera drugą serię wykresu
    series = chart.getChartData().getSeries().get_Item(1);
    // Dodaje nowy punkt (5:2) tam
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    // Dodaje nowy punkt (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    // Dodaje nowy punkt (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    // Dodaje nowy punkt (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    // Zmienia znacznik serii wykresu
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Tworzenie wykresów kołowych**

Wykresy kołowe najlepiej służą do pokazania relacji część‑całość w danych, szczególnie gdy dane zawierają etykiety kategoryczne z wartościami liczbowymi. Jednakże, jeśli Twoje dane zawierają wiele części lub etykiet, rozważ użycie wykresu słupkowego.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Kroki:</em> Utwórz wykres kołowy w JavaScript</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Kroki:</em> Utwórz wykres kołowy PowerPoint w JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Kroki:</em> Utwórz wykres kołowy w prezentacji PowerPoint w JavaScript</strong></a>

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
2. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
3. Dodaj wykres z domyślnymi danymi wraz z żądanym typem (w tym przypadku [ChartType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartType).Pie).
4. Uzyskaj dostęp do danych wykresu [ChartDataWorkbook](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Wyczyść domyślne serie i kategorie.
6. Dodaj nowe serie i kategorie.
7. Dodaj nowe dane wykresu dla serii.
8. Dodaj nowe punkty dla wykresu i niestandardowe kolory dla sektorów wykresu kołowego.
9. Ustaw etykiety dla serii.
10. Ustaw linie pomocnicze dla etykiet serii.
11. Ustaw kąt obrotu dla slajdów wykresu kołowego.
12. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod JavaScript pokazuje, jak utworzyć wykres kołowy:

```javascript
// Tworzy instancję klasy prezentacji, która reprezentuje plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Uzyskuje dostęp do pierwszego slajdu
    var slides = pres.getSlides().get_Item(0);
    // Dodaje wykres z domyślnymi danymi
    var chart = slides.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Ustawia tytuł wykresu
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Ustawia pierwszą serię, aby wyświetlała wartości
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Ustawia indeks arkusza danych wykresu
    var defaultWorksheetIndex = 0;
    // Pobiera arkusz danych wykresu
    var fact = chart.getChartData().getChartDataWorkbook();
    // Usuwa domyślnie wygenerowane serie i kategorie
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Dodaje nowe kategorie
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Dodaje nowe serie
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Wypełnia dane serii
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Nie działa w nowej wersji
    // Adding new points and setting sector color
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    var point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    // Ustawia obramowanie sektora
    point.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    var point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // Ustawia obramowanie sektora
    point1.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(aspose.slides.LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDot);
    var point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    // Ustawia obramowanie sektora
    point2.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDotDot);
    // Tworzy niestandardowe etykiety dla każdej kategorii nowej serii
    var lbl1 = series.getDataPoints().get_Item(0).getLabel();
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    var lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    var lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    // Wyświetla linie prowadzące dla wykresu
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    // Ustawia kąt obrotu sektorów wykresu kołowego
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    // Zapisuje prezentację z wykresem
    pres.save("PieChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Tworzenie wykresów liniowych**

Wykresy liniowe (znane także jako wykresy liniowe) najlepiej sprawdzają się w sytuacjach, w których chcesz pokazać zmiany wartości w czasie. Dzięki wykresowi liniowemu możesz porównywać wiele danych jednocześnie, śledzić zmiany i trendy w czasie, uwydatniać anomalie w seriach danych itp.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
1. Pobierz odniesienie do slajdu za pomocą jego indeksu.
1. Dodaj wykres z domyślnymi danymi wraz z żądanym typem (w tym przypadku `ChartType.Line`).
1. Uzyskaj dostęp do danych wykresu IChartDataWorkbook.
1. Wyczyść domyślne serie i kategorie.
1. Dodaj nowe serie i kategorie.
1. Dodaj nowe dane wykresu dla serii.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX

Ten kod JavaScript pokazuje, jak utworzyć wykres liniowy:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Domyślnie punkty na wykresie liniowym są połączone prostymi ciągłymi liniami. Jeśli chcesz, aby punkty były połączone kreskami, możesz określić preferowany typ kreski w następujący sposób:

```javascript
var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++) {
    let series = lineChart.getChartData().getSeries().get_Item(i);
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Dash);
});
```

### **Tworzenie wykresów mapy drzewa**

Wykresy mapy drzewa najlepiej sprawdzają się przy danych sprzedażowych, gdy chcesz pokazać względny rozmiar kategorii danych i jednocześnie szybko zwrócić uwagę na elementy, które są dużymi wkładami w każdą kategorię. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Kroki:</em> Utwórz wykres mapy drzewa w JavaScript</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Kroki:</em> Utwórz wykres mapy drzewa PowerPoint w JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Kroki:</em> Utwórz wykres mapy drzewa w prezentacji PowerPoint w JavaScript</strong></a>

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) .
2. Pobierz odniesienie do slajdu za pomocą jego indeksu.
3. Dodaj wykres z domyślnymi danymi wraz z żądanym typem (w tym przypadku [ChartType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartType).TreeMap).
4. Uzyskaj dostęp do danych wykresu [ChartDataWorkbook](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Wyczyść domyślne serie i kategorie.
6. Dodaj nowe serie i kategorie.
7. Dodaj nowe dane wykresu dla serii.
8. Zapisz zmodyfikowaną prezentację jako plik PPTX

Ten kod JavaScript pokazuje, jak utworzyć wykres mapy drzewa:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // gałąź 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // gałąź 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));
    series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
    pres.save("Treemap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Tworzenie wykresów giełdowych**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Kroki:</em> Utwórz wykres giełdowy w JavaScript</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Kroki:</em> Utwórz wykres giełdowy PowerPoint w JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Kroki:</em> Utwórz wykres giełdowy w prezentacji PowerPoint w JavaScript</strong></a>

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) .
2. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
3. Dodaj wykres z domyślnymi danymi wraz z żądanym typem ([ChartType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartType).OpenHighLowClose).
4. Uzyskaj dostęp do danych wykresu [ChartDataWorkbook](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Wyczyść domyślne serie i kategorie.
6. Dodaj nowe serie i kategorie.
7. Dodaj nowe dane wykresu dla serii.
8. Określ format HiLowLines.
9. Zapisz zmodyfikowaną prezentację jako plik PPTX

Przykładowy kod JavaScript używany do utworzenia wykresu giełdowego:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 50, 50, 600, 400);
  
    var wb = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 1, 72));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 1, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 1, 38));
    series = chart.getChartData().getSeries().get_Item(1);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 2, 172));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 2, 57));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 2, 57));
    series = chart.getChartData().getSeries().get_Item(2);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 3, 13));
    series = chart.getChartData().getSeries().get_Item(3);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 4, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 4, 38));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 4, 50));
    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(true);
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        let ser = chart.getChartData().getSeries().get_Item(i);
        ser.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Tworzenie wykresów pudełkowo‑wąsowych**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Kroki:</em> Utwórz wykres pudełkowo‑wąsowy w JavaScript</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Kroki:</em> Utwórz wykres pudełkowo‑wąsowy PowerPoint w JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Kroki:</em> Utwórz wykres pudełkowo‑wąsowy w prezentacji PowerPoint w JavaScript</strong></a>

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) .
2. Pobierz odniesienie do slajdu za pomocą jego indeksu.
3. Dodaj wykres z domyślnymi danymi wraz z żądanym typem ([ChartType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartType).BoxAndWhisker).
4. Uzyskaj dostęp do danych wykresu [ChartDataWorkbook](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Wyczyść domyślne serie i kategorie.
6. Dodaj nowe serie i kategorie.
7. Dodaj nowe dane wykresu dla serii.
8. Zapisz zmodyfikowaną prezentację jako plik PPTX

Ten kod JavaScript pokazuje, jak utworzyć wykres pudełkowo‑wąsowy:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.BoxAndWhisker);
    series.setQuartileMethod(aspose.slides.QuartileMethodType.Exclusive);
    series.setShowMeanLine(true);
    series.setShowMeanMarkers(true);
    series.setShowInnerPoints(true);
    series.setShowOutlierPoints(true);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B1", 15));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B2", 41));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B3", 16));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B4", 10));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B5", 23));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B6", 16));
    pres.save("BoxAndWhisker.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Tworzenie wykresów lejkowych**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Kroki:</em> Utwórz wykres lejkowy w JavaScript</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Kroki:</em> Utwórz wykres lejkowy PowerPoint w JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Kroki:</em> Utwórz wykres lejkowy w prezentacji PowerPoint w JavaScript</strong></a>


1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) .
2. Pobierz odniesienie do slajdu za pomocą jego indeksu.
3. Dodaj wykres z domyślnymi danymi wraz z żądanym typem ([ChartType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartType).Funnel).
4. Zapisz zmodyfikowaną prezentację jako plik PPTX

Kod JavaScript pokazuje, jak utworzyć wykres lejkowy:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Funnel);
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));
    pres.save("Funnel.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Tworzenie wykresów promieniowych**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Kroki:</em> Utwórz wykres promieniowy w JavaScript</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Kroki:</em> Utwórz wykres promieniowy PowerPoint w JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Kroki:</em> Utwórz wykres promieniowy w prezentacji PowerPoint w JavaScript</strong></a>

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) .
2. Pobierz odniesienie do slajdu za pomocą jego indeksu.
3. Dodaj wykres z domyślnymi danymi wraz z żądanym typem (w tym przypadku [ChartType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartType).sunburst).
4. Zapisz zmodyfikowaną prezentację jako plik PPTX

Ten kod JavaScript pokazuje, jak utworzyć wykres promieniowy:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // gałąź 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // gałąź 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    pres.save("Sunburst.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Tworzenie wykresów histogramu**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Kroki:</em> Utwórz wykres histogramu w JavaScript</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Kroki:</em> Utwórz wykres histogramu PowerPoint w JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Kroki:</em> Utwórz wykres histogramu w prezentacji PowerPoint w JavaScript</strong></a>

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) .
2. Pobierz odniesienie do slajdu za pomocą jego indeksu.
3. Dodaj wykres z domyślnymi danymi wraz z żądanym typem ([ChartType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartType).Histogram).
4. Uzyskaj dostęp do danych wykresu [ChartDataWorkbook](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Wyczyść domyślne serie i kategorie.
6. Dodaj nowe serie i kategorie.
7. Zapisz zmodyfikowaną prezentację jako plik PPTX

Ten kod JavaScript pokazuje, jak utworzyć wykres histogramu:

```javascript
var pres = new aspose.slides.Presentation();
var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Histogram, 50, 50, 500, 400);
chart.getChartData().getCategories().clear();
chart.getChartData().getSeries().clear();
var wb = chart.getChartData().getChartDataWorkbook();
wb.clear(0);
var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Histogram);
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));
chart.getAxes().getHorizontalAxis().setAggregationType(aspose.slides.AxisAggregationType.Automatic);
```

### **Tworzenie wykresów radarowych**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Kroki:</em> Utwórz wykres radarowy w JavaScript</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Kroki:</em> Utwórz wykres radarowy PowerPoint w JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Kroki:</em> Utwórz wykres radarowy w prezentacji PowerPoint w JavaScript</strong></a>

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) .
2. Pobierz odniesienie do slajdu za pomocą jego indeksu. 
3. Dodaj wykres z danymi i określ preferowany typ wykresu (`ChartType.Radar` w tym przypadku).
4. Zapisz zmodyfikowaną prezentację jako plik PPTX

Ten kod JavaScript pokazuje, jak utworzyć wykres radarowy:

```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Tworzenie wykresów wielokategorii**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Kroki:</em> Utwórz wykres wielokategorii w JavaScript</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Kroki:</em> Utwórz wykres wielokategorii PowerPoint w JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Kroki:</em> Utwórz wykres wielokategorii w prezentacji PowerPoint w JavaScript</strong></a>

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) .
2. Pobierz odniesienie do slajdu za pomocą jego indeksu. 
3. Dodaj wykres z domyślnymi danymi wraz z żądanym typem ([ChartType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartType).ClusteredColumn).
4. Uzyskaj dostęp do danych wykresu [ChartDataWorkbook](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Wyczyść domyślne serie i kategorie.
6. Dodaj nowe serie i kategorie.
7. Dodaj nowe dane wykresu dla serii.
8. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod JavaScript pokazuje, jak utworzyć wykres wielokategorii:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var ch = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    var fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    var defaultWorksheetIndex = 0;
    var category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
    category.getGroupingLevels().setGroupingItem(1, "Group1");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c3", "B"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c4", "C"));
    category.getGroupingLevels().setGroupingItem(1, "Group2");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c5", "D"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c6", "E"));
    category.getGroupingLevels().setGroupingItem(1, "Group3");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c7", "F"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c8", "G"));
    category.getGroupingLevels().setGroupingItem(1, "Group4");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c9", "H"));
    // Dodawanie serii
    var series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"), aspose.slides.ChartType.ClusteredColumn);
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    // Zapisz prezentację z wykresem
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Tworzenie wykresów mapowych**

Wykres mapowy to wizualizacja obszaru zawierającego dane. Wykresy mapowe najlepiej służą do porównywania danych lub wartości w różnych regionach geograficznych.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Kroki:</em> Utwórz wykres mapowy w JavaScript</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Kroki:</em> Utwórz wykres mapowy PowerPoint w JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Kroki:</em> Utwórz wykres mapowy w prezentacji PowerPoint w JavaScript</strong></a>

Ten kod JavaScript pokazuje, jak utworzyć wykres mapowy:

```javascript
let pres = new aspose.slides.Presentation();
try {
    let chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Tworzenie wykresów kombinowanych**

Wykres kombinowany (lub wykres combo) łączy dwa lub więcej typów wykresów w jednym grafie. Ten wykres pozwala podkreślić, porównać lub zbadać różnice między dwoma lub więcej zestawami danych, pomagając zidentyfikować zależności między nimi.

![The combination chart](combination_chart.png)

Poniższy kod JavaScript pokazuje, jak stworzyć wykres kombinowany przedstawiony powyżej w prezentacji PowerPoint:

```js
function createComboChart() {
    let presentation = new aspose.slides.Presentation();
    let slide = presentation.getSlides().get_Item(0);
    try {
        let chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

function createChartWithFirstSeries(slide) {
    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Ustaw tytuł wykresu.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(18);

    // Ustaw legendę wykresu.
    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    // Usuń domyślnie wygenerowane serie i kategorie.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const worksheetIndex = 0;
    let workbook = chart.getChartData().getChartDataWorkbook();

    // Dodaj nowe kategorie.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Dodaj pierwszą serię.
    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

function addSecondSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat(chart) {
    // Ustaw oś poziomą.
    let horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(horizontalAxis, "X Axis");

    // Ustaw oś pionową.
    let verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Ustaw kolor głównych linii siatki pionowej.
    let majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    majorGridLinesFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat(chart) {
    // Ustaw drugą oś poziomą.
    let secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(aspose.slides.AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(aspose.slides.CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Ustaw drugą oś pionową.
    let secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(aspose.slides.AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle(axis, axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    let titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(12);
}
```

## **Aktualizowanie wykresów**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Kroki:</em> Aktualizuj wykres PowerPoint w JavaScript</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Kroki:</em> Aktualizuj wykres prezentacji w JavaScript</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Kroki:</em> Aktualizuj wykres prezentacji PowerPoint w JavaScript</strong></a>

1. Zainicjuj klasę [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation), która reprezentuje prezentację zawierającą wykres, który chcesz zaktualizować.
2. Uzyskaj odniesienie do slajdu, używając jego indeksu.
3. Przejdź przez wszystkie kształty, aby znaleźć żądany wykres.
4. Uzyskaj dostęp do arkusza danych wykresu.
5. Zmodyfikuj dane serii wykresu, zmieniając wartości serii.
6. Dodaj nową serię i wypełnij ją danymi.
7. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod JavaScript pokazuje, jak zaktualizować wykres:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Uzyskaj dostęp do pierwszego slajdu
    var sld = pres.getSlides().get_Item(0);
    // Pobierz wykres z domyślnymi danymi
    var chart = sld.getShapes().get_Item(0);
    // Ustawianie indeksu arkusza danych wykresu
    var defaultWorksheetIndex = 0;
    // Pobieranie arkusza danych wykresu
    var fact = chart.getChartData().getChartDataWorkbook();
    // Zmiana nazwy kategorii wykresu
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");
    // Pobierz pierwszą serię wykresu
    var series = chart.getChartData().getSeries().get_Item(0);
    // Teraz aktualizowanie danych serii
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Modyfikacja nazwy serii
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);
    // Pobierz drugą serię wykresu
    series = chart.getChartData().getSeries().get_Item(1);
    // Teraz aktualizowanie danych serii
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Modyfikacja nazwy serii
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);
    // Teraz, dodawanie nowej serii
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());
    // Pobierz trzecią serię wykresu
    series = chart.getChartData().getSeries().get_Item(2);
    // Teraz wypełnianie danych serii
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));
    chart.setType(aspose.slides.ChartType.ClusteredCylinder);
    // Zapisz prezentację z wykresem
    pres.save("AsposeChartModified_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ustawianie zakresu danych dla wykresów**

Aby ustawić zakres danych dla wykresu, wykonaj następujące kroki:

1. Zainicjuj klasę [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation), która reprezentuje prezentację zawierającą wykres.
2. Pobierz odniesienie do slajdu za pomocą jego indeksu.
3. Przejdź przez wszystkie kształty, aby znaleźć żądany wykres.
4. Uzyskaj dostęp do danych wykresu i ustaw zakres.
5. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod JavaScript pokazuje, jak ustawić zakres danych dla wykresu:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().get_Item(0);
    chart.getChartData().setRange("Sheet1!A1:B4");
    pres.save("SetDataRange_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Używanie domyślnych markerów w wykresach**
Gdy używasz domyślnego markera w wykresach, każda seria wykresu automatycznie otrzymuje inny domyślny symbol markera.

Ten kod JavaScript pokazuje, jak automatycznie ustawić marker serii wykresu:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 10, 10, 400, 400);
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType());
    // Pobierz drugą serię wykresu
    var series2 = chart.getChartData().getSeries().get_Item(1);
    // Teraz wypełnianie danych serii
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));
    chart.setLegend(true);
    chart.getLegend().setOverlay(false);
    pres.save("DefaultMarkersInChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Jakie typy wykresów są obsługiwane przez Aspose.Slides?**

Aspose.Slides obsługuje szeroką gamę typów wykresów, w tym słupkowe, liniowe, kołowe, powierzchniowe, rozproszone, histogramy, radarowe i wiele innych. Ta elastyczność pozwala wybrać najodpowiedniejszy typ wykresu do potrzeb wizualizacji danych.

**Jak dodać nowy wykres do slajdu?**

Aby dodać wykres, najpierw utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/), pobierz żądany slajd przy użyciu jego indeksu, a następnie wywołaj metodę dodającą wykres, określając typ wykresu i początkowe dane. Proces ten integruje wykres bezpośrednio z prezentacją.

**Jak mogę zaktualizować dane wyświetlane w wykresie?**

Możesz zaktualizować dane wykresu, uzyskując dostęp do jego skoroszytu danych ([ChartDataWorkbook](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdataworkbook/)), usuwając domyślne serie i kategorie, a następnie dodając własne dane. Umożliwia to programowe odświeżenie wykresu, aby odzwierciedlał najnowsze informacje.

**Czy można dostosować wygląd wykresu?**

Tak, Aspose.Slides oferuje rozbudowane opcje dostosowywania. Możesz modyfikować kolory, czcionki, etykiety, legendy i inne elementy formatowania, aby dopasować wygląd wykresu do konkretnych wymagań projektowych.