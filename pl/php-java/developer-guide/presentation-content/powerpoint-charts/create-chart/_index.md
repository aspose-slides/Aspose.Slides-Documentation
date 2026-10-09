---
title: Utworzenie lub aktualizacja wykresów w prezentacji PowerPoint w PHP
linktitle: Utworzenie lub aktualizacja wykresów
type: docs
weight: 10
url: /pl/php-java/create-chart/
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
- wykres pudełkowy i wąsy
- wykres lejkowy
- wykres promieniowy
- wykres histogramu
- wykres radarowy
- wykres wielokategorii
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Twórz i dostosowuj wykresy w prezentacjach PowerPoint przy użyciu Aspose.Slides dla PHP poprzez Javę. Dodawaj, formatuj i edytuj wykresy, korzystając z praktycznych przykładów kodu."
---
## **Przegląd**

Ten artykuł zapewnia kompleksowy przewodnik, jak tworzyć i dostosowywać wykresy przy użyciu Aspose.Slides. Dowiesz się, jak programowo dodać wykres do slajdu, wypełnić go danymi oraz zastosować różne opcje formatowania, aby spełnić określone wymagania projektowe. W całym artykule szczegółowe przykłady kodu ilustrują każdy krok, od inicjalizacji prezentacji i obiektu wykresu po konfigurację serii, osi i legend. Postępując zgodnie z tym przewodnikiem, zdobędziesz solidną wiedzę na temat integracji dynamicznego generowania wykresów w aplikacjach, upraszczając proces tworzenia prezentacji opartych na danych.

## **Utworzenie wykresu**

Wykresy pomagają szybko wizualizować dane i uzyskać wnioski, które nie są od razu oczywiste w tabeli lub arkuszu kalkulacyjnym.

**Dlaczego tworzyć wykresy?**

Korzystając z wykresów, możesz:

* agregować, kondensować lub podsumowywać duże ilości danych na jednym slajdzie prezentacji
* ujawniać wzorce i trendy w danych
* wyznaczać kierunek i dynamikę danych w czasie lub w odniesieniu do określonej jednostki miary
* wykrywać odstające wartości, aberracje, odchylenia, błędy, nielogiczne dane itp.
* komunikować lub prezentować złożone dane

W programie PowerPoint możesz tworzyć wykresy za pomocą funkcji *Wstaw*, która zapewnia szablony do projektowania wielu rodzajów wykresów. Korzystając z Aspose.Slides, możesz tworzyć zarówno standardowe wykresy (oparte na popularnych typach) jak i wykresy niestandardowe.

{{% alert color="info" title="Uwaga" %}}

Aby tworzyć wykresy, użyj klasy [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). Pola w tej klasie odpowiadają różnym typom wykresów.

{{% /alert %}}

### **Utworzenie wykresów kolumnowych grupowanych**

W tej sekcji wyjaśniamy, jak tworzyć wykresy kolumnowe grupowane przy użyciu Aspose.Slides. Nauczysz się inicjalizować prezentację, dodać wykres i dostosować jego elementy, takie jak tytuł, dane, serie, kategorie i styl. Postępuj zgodnie z poniższymi krokami, aby zobaczyć, jak generowany jest standardowy wykres kolumnowy grupowany:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) .
1. Uzyskaj odniesienie do slajdu przy użyciu jego indeksu.
1. Dodaj wykres z pewnymi danymi i określ typ `ChartType::ClusteredColumn` .
1. Dodaj tytuł do wykresu.
1. Uzyskaj dostęp do arkusza danych wykresu.
1. Wyczyść wszystkie domyślne serie i kategorie.
1. Dodaj nowe serie i kategorie.
1. Dodaj nowe dane do serii wykresu.
1. Zastosuj kolor wypełnienia do serii wykresu.
1. Dodaj etykiety do serii wykresu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod C# demonstruje, jak utworzyć wykres kolumnowy grupowany:

```php
  # Instantiates a presentation class that represents a PPTX file
  $pres = new Presentation();
  try {
    # Accesses the first slide
    $sld = $pres->getSlides()->get_Item(0);
    # Adds a chart with its default data
    $chart = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 0, 0, 500, 500);
    # Sets the chart Title
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->hasTitle();
    # Sets the first series to show values
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Sets the index for the chart data sheet
    $defaultWorksheetIndex = 0;
    # Gets the chart data WorkSheet
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Deletes the default generated series and categories
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $s = $chart->getChartData()->getSeries()->size();
    $s = $chart->getChartData()->getCategories()->size();
    # Adds new series
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Adds new categories
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Takes the first chart series
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Now populates the series data
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Sets the fill color for series
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Takes the second chart series
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Populates series data
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Sets the fill color for the series
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Create custom labels for each categories for the new series
    # Sets the first label to show Category name
    $lbl = $series->getDataPoints()->get_Item(0)->getLabel();
    $lbl->getDataLabelFormat()->setShowCategoryName(true);
    $lbl = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    # Shows value for the third label
    $lbl = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl->getDataLabelFormat()->setShowValue(true);
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    $lbl->getDataLabelFormat()->setSeparator("/");
    # Saves the presentation with chart
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Utworzenie wykresów punktowych**

Wykresy punktowe (znane również jako wykresy rozrzutu lub wykresy x‑y) są często używane do sprawdzania wzorców lub wykazywania korelacji między dwoma zmiennymi.

Używaj wykresu punktowego, gdy:

* masz sparowane dane liczbowe
* masz dwie zmienne, które dobrze ze sobą współgrają
* chcesz określić, czy dwie zmienne są ze sobą powiązane
* masz zmienną niezależną, która ma wiele wartości dla zmiennej zależnej

1. Postępuj zgodnie z krokami w sekcji [Create Clustered Column Charts](#create-clustered-column-charts) .
2. W trzecim kroku dodaj wykres z pewnymi danymi i określ typ wykresu jako jeden z następujących:
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithMarkers) - _Reprezentuje wykres punktowy z markerami._
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Reprezentuje wykres punktowy połączony krzywymi, z markerami danych._
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Reprezentuje wykres punktowy połączony krzywymi, bez markerów danych._
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Reprezentuje wykres punktowy połączony liniami, z markerami danych._
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Reprezentuje wykres punktowy połączony liniami, bez markerów danych._

Ten kod PHP pokazuje, jak utworzyć wykres punktowy z różnymi markerami dla każdej serii:

```php
  # Tworzy instancję klasy prezentacji, która reprezentuje plik PPTX
  $pres = new Presentation();
  try {
    # Uzyskuje dostęp do pierwszego slajdu
    $slide = $pres->getSlides()->get_Item(0);
    # Tworzy domyślny wykres
    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 0, 0, 400, 400);
    # Pobiera indeks domyślnego arkusza danych wykresu
    $defaultWorksheetIndex = 0;
    # Pobiera arkusz danych wykresu
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Usuwa serię demonstracyjną
    $chart->getChartData()->getSeries()->clear();
    # Dodaje nowe serie
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 3, "Series 2"), $chart->getType());
    # Pobiera pierwszą serię wykresu
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Dodaje nowy punkt (1:3) do serii
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 1), $fact->getCell($defaultWorksheetIndex, 2, 2, 3));
    # Dodaje nowy punkt (2:10)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 2), $fact->getCell($defaultWorksheetIndex, 3, 2, 10));
    # Zmienia typ serii
    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);
    # Zmienia marker serii wykresu
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);
    # Pobiera drugą serię wykresu
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Dodaje nowy punkt (5:2) tam
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 5), $fact->getCell($defaultWorksheetIndex, 2, 4, 2));
    # Dodaje nowy punkt (3:1)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 3), $fact->getCell($defaultWorksheetIndex, 3, 4, 1));
    # Dodaje nowy punkt (2:2)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 4, 3, 2), $fact->getCell($defaultWorksheetIndex, 4, 4, 2));
    # Dodaje nowy punkt (5:1)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 5, 3, 5), $fact->getCell($defaultWorksheetIndex, 5, 4, 1));
    # Zmienia marker serii wykresu
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Utworzenie wykresów kołowych**

Wykresy kołowe najlepiej służą do pokazania relacji części do całości w danych, szczególnie gdy dane zawierają etykiety kategoryczne z wartościami liczbowymi. Jednak jeśli Twoje dane zawierają wiele części lub etykiet, rozważ użycie wykresu słupkowego.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Uzyskaj odniesienie do slajdu przy użyciu jego indeksu.
3. Dodaj wykres z domyślnymi danymi i określ typ [ChartType::Pie](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#Pie) .
4. Uzyskaj dostęp do skoroszytu danych wykresu [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) .
5. Wyczyść domyślne serie i kategorie.
6. Dodaj nowe serie i kategorie.
7. Dodaj nowe dane do serii wykresu.
8. Dodaj nowe punkty do wykresu i zastosuj niestandardowe kolory sektorów wykresu kołowego.
9. Ustaw etykiety dla serii.
10. Włącz linie prowadzące dla etykiet serii.
11. Ustaw kąt obrotu sektorów wykresu kołowego.
12. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod PHP pokazuje, jak utworzyć wykres kołowy:

```php
  # Tworzy instancję klasy prezentacji, która reprezentuje plik PPTX
  $pres = new Presentation();
  try {
    # Uzyskuje dostęp do pierwszego slajdu
    $slides = $pres->getSlides()->get_Item(0);
    # Dodaje wykres z domyślnymi danymi
    $chart = $slides->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Ustawia tytuł wykresu
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # Ustawia pierwszą serię, aby wyświetlała wartości
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Ustawia indeks dla arkusza danych wykresu
    $defaultWorksheetIndex = 0;
    # Pobiera arkusz danych wykresu
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Usuwa domyślnie wygenerowane serie i kategorie
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Dodaje nowe kategorie
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # Dodaje nowe serie
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # Wypełnia dane serii
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Nie działa w nowej wersji
    # Dodawanie nowych punktów i ustawianie koloru sektora
    # series.IsColorVaried = true;
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setColorVaried(true);
    $point = $series->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    # Ustawia obramowanie sektora
    $point->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $point->getFormat()->getLine()->setWidth(3.0);
    $point->getFormat()->getLine()->setStyle(LineStyle->ThinThick);
    $point->getFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    $point1 = $series->getDataPoints()->get_Item(1);
    $point1->getFormat()->getFill()->setFillType(FillType::Solid);
    $point1->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # Ustawia obramowanie sektora
    $point1->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point1->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $point1->getFormat()->getLine()->setWidth(3.0);
    $point1->getFormat()->getLine()->setStyle(LineStyle->Single);
    $point1->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDot);
    $point2 = $series->getDataPoints()->get_Item(2);
    $point2->getFormat()->getFill()->setFillType(FillType::Solid);
    $point2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # Ustawia obramowanie sektora
    $point2->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point2->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $point2->getFormat()->getLine()->setWidth(2.0);
    $point2->getFormat()->getLine()->setStyle(LineStyle->ThinThin);
    $point2->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDotDot);
    # Tworzy niestandardowe etykiety dla każdej kategorii w nowej serii
    $lbl1 = $series->getDataPoints()->get_Item(0)->getLabel();
    # lbl.ShowCategoryName = true;
    $lbl1->getDataLabelFormat()->setShowValue(true);
    $lbl2 = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl2->getDataLabelFormat()->setShowValue(true);
    $lbl2->getDataLabelFormat()->setShowLegendKey(true);
    $lbl2->getDataLabelFormat()->setShowPercentage(true);
    $lbl3 = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl3->getDataLabelFormat()->setShowSeriesName(true);
    $lbl3->getDataLabelFormat()->setShowPercentage(true);
    # Wyświetla linie prowadzące wykresu
    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);
    # Ustawia kąt obrotu sektorów wykresu kołowego
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setFirstSliceAngle(180);
    # Zapisuje prezentację z wykresem
    $pres->save("PieChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Utworzenie wykresów liniowych**

Wykresy liniowe (znane również jako wykresy liniowe) najlepiej sprawdzają się w sytuacjach, gdy chcesz pokazać zmiany wartości w czasie. Korzystając z wykresu liniowego, możesz jednocześnie porównać dużą ilość danych, śledzić zmiany i trendy w czasie, podkreślać anomalie w seriach danych i nie tylko.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
1. Uzyskaj odniesienie do slajdu przy użyciu jego indeksu.
1. Dodaj wykres z domyślnymi danymi i określ typ [ChartType::Line](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#Line) .
1. Uzyskaj dostęp do skoroszytu danych wykresu ([ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) ) .
1. Wyczyść domyślne serie i kategorie.
1. Dodaj nowe serie i kategorie.
1. Dodaj nowe dane do serii wykresu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod PHP pokazuje, jak utworzyć wykres liniowy:

```php
  $pres = new Presentation();
  try {
    $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
    $pres->save("lineChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Domyślnie punkty na wykresie liniowym są łączone prostymi ciągłymi liniami. Jeśli chcesz, aby punkty były łączone kreskami, możesz określić preferowany typ kreski w następujący sposób:

```php
  $pres = new Presentation();
  try {
    $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
    $seriesCollection = $lineChart->getChartData()->getSeries();
    foreach ($seriesCollection as $series) {
      $series->getFormat()->getLine()->setDashStyle(LineDashStyle::Dash);
    }
    $pres->save("lineChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Utworzenie wykresów mapy drzewa**

Wykresy mapy drzewa najlepiej sprawdzają się przy danych sprzedażowych, gdy chcesz pokazać względny rozmiar kategorii danych i szybko zwrócić uwagę na elementy będące dużymi wkładami w każdej kategorii.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Uzyskaj odniesienie do slajdu przy użyciu jego indeksu.
3. Dodaj wykres z domyślnymi danymi i określ typ [ChartType::Treemap](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#Treemap) .
4. Uzyskaj dostęp do skoroszytu danych wykresu [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) .
5. Wyczyść domyślne serie i kategorie.
6. Dodaj nowe serie i kategorie.
7. Dodaj nowe dane do serii wykresu.
8. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod PHP pokazuje, jak utworzyć wykres mapy drzewa:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Treemap, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # gałąź 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # gałąź 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Treemap);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D8", 3));
    $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
    $pres->save("Treemap.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Utworzenie wykresów giełdowych**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Uzyskaj odniesienie do slajdu przy użyciu jego indeksu.
3. Dodaj wykres z domyślnymi danymi i określ typ [ChartType::OpenHighLowClose](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#OpenHighLowClose) .
4. Uzyskaj dostęp do skoroszytu danych wykresu [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) .
5. Wyczyść domyślne serie i kategorie.
6. Dodaj nowe serie i kategorie.
7. Dodaj nowe dane do serii wykresu.
8. Określ format linii high‑low.
9. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod PHP pokazuje, jak utworzyć wykres giełdowy:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::OpenHighLowClose, 50, 50, 600, 400, false);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 1, 0, "A"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 2, 0, "B"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 3, 0, "C"));
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 1, "Open"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 2, "High"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 3, "Low"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 4, "Close"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 1, 72));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 1, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 1, 38));
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 2, 172));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 2, 57));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 2, 57));
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 3, 13));
    $series = $chart->getChartData()->getSeries()->get_Item(3);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 4, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 4, 38));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 4, 50));
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getUpDownBars()->setUpDownBars(true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getHiLowLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $seriesCollection = $chart->getChartData()->getSeries();
    foreach ($seriesCollection as $ser) {
      $ser->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Utworzenie wykresów pudełkowych i wąsów**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Uzyskaj odniesienie do slajdu przy użyciu jego indeksu.
3. Dodaj wykres z domyślnymi danymi i określ typ [ChartType::BoxAndWhisker](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#BoxAndWhisker) .
4. Uzyskaj dostęp do skoroszytu danych wykresu [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) .
5. Wyczyść domyślne serie i kategorie.
6. Dodaj nowe serie i kategorie.
7. Dodaj nowe dane do serii wykresu.
8. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod PHP pokazuje, jak utworzyć wykres pudełkowy i wąsy:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::BoxAndWhisker, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 1"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::BoxAndWhisker);
    $series->setQuartileMethod(QuartileMethodType::Exclusive);
    $series->setShowMeanLine(true);
    $series->setShowMeanMarkers(true);
    $series->setShowInnerPoints(true);
    $series->setShowOutlierPoints(true);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B1", 15));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B2", 41));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B3", 16));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B4", 10));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B5", 23));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B6", 16));
    $pres->save("BoxAndWhisker.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Utworzenie wykresów lejkowych**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Uzyskaj odniesienie do slajdu przy użyciu jego indeksu.
3. Dodaj wykres z domyślnymi danymi i określ typ [ChartType::Funnel](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#Funnel) .
4. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod PHP pokazuje, jak utworzyć wykres lejkowy:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Funnel, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 2"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 3"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 4"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 5"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 6"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Funnel);
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B1", 50));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B2", 100));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B3", 200));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B4", 300));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B5", 400));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B6", 500));
    $pres->save("Funnel.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Utworzenie wykresów promieniowych**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Uzyskaj odniesienie do slajdu przy użyciu jego indeksu.
3. Dodaj wykres z domyślnymi danymi i określ typ [ChartType::Sunburst](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#Sunburst) .
4. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod PHP pokazuje, jak utworzyć wykres promieniowy:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # gałąź 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # gałąź 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Sunburst);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D8", 3));
    $pres->save("Sunburst.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Utworzenie wykresów histogramów**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Uzyskaj odniesienie do slajdu przy użyciu jego indeksu.
3. Dodaj wykres z domyślnymi danymi i określ typ [ChartType::Histogram](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#Histogram) .
4. Uzyskaj dostęp do skoroszytu danych wykresu [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) .
5. Wyczyść domyślne serie i kategorie.
6. Dodaj nowe serie i kategorie.
7. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod PHP pokazuje, jak utworzyć wykres histogramu:

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Histogram, 50, 50, 500, 400);
  $chart->getChartData()->getCategories()->clear();
  $chart->getChartData()->getSeries()->clear();
  $wb = $chart->getChartData()->getChartDataWorkbook();
  $wb->clear(0);
  $series = $chart->getChartData()->getSeries()->add(ChartType::Histogram);
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A1", 15));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A2", -41));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A3", 16));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A4", 10));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A5", -23));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A6", 16));
  $chart->getAxes()->getHorizontalAxis()->setAggregationType(AxisAggregationType::Automatic);

```

### **Utworzenie wykresów radarowych**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Uzyskaj odniesienie do slajdu przy użyciu jego indeksu.
3. Dodaj wykres z pewnymi danymi i określ preferowany typ wykresu ([ChartType::Radar](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#Radar) w tym przypadku).
4. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod PHP pokazuje, jak utworzyć wykres radarowy:

```php
  $pres = new Presentation();
  try {
    $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Radar, 20, 20, 400, 300);
    $pres->save("Radar-chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Utworzenie wykresów wielokategorii**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Uzyskaj odniesienie do slajdu przy użyciu jego indeksu.
3. Dodaj wykres z domyślnymi danymi i określ typ [ChartType::ClusteredColumn](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ClusteredColumn) .
4. Uzyskaj dostęp do skoroszytu danych wykresu [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) .
5. Wyczyść domyślne serie i kategorie.
6. Dodaj nowe serie i kategorie.
7. Dodaj nowe dane do serii wykresu.
8. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod PHP pokazuje, jak utworzyć wykres wielokategorii:

```php
  $pres = new Presentation();
  try {
    $ch = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 600, 450);
    $ch->getChartData()->getSeries()->clear();
    $ch->getChartData()->getCategories()->clear();
    $fact = $ch->getChartData()->getChartDataWorkbook();
    $fact->clear(0);
    $defaultWorksheetIndex = 0;
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c2", "A"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group1");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c3", "B"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c4", "C"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group2");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c5", "D"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c6", "E"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group3");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c7", "F"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c8", "G"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group4");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c9", "H"));
    # Dodawanie serii
    $series = $ch->getChartData()->getSeries()->add($fact->getCell(0, "D1", "Series 1"), ChartType::ClusteredColumn);
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D2", 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D3", 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D4", 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D5", 40));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D6", 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D7", 60));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D8", 70));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D9", 80));
    # Zapisz prezentację z wykresem
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Utworzenie wykresów mapowych**

Wykresy mapowe wizualizują dane geograficzne i pomagają porównywać wartości w różnych regionach.

Ten kod PHP pokazuje, jak utworzyć wykres mapowy:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Map, 50, 50, 500, 400);
    $pres->save("mapChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Utworzenie wykresów kombinowanych**

Wykres kombinowany (lub wykres combo) łączy dwa lub więcej typów wykresów w jednym diagramie. Ten wykres pozwala wyróżniać, porównywać lub analizować różnice między dwoma lub więcej zestawami danych, pomagając zidentyfikować zależności między nimi.

![The combination chart](combination_chart.png)

Poniższy kod PHP pokazuje, jak utworzyć powyższy wykres kombinowany w prezentacji PowerPoint:

```php
function createComboChart() {
    $presentation = new Presentation();
    $slide = $presentation->getSlides()->get_Item(0);
    try {
        $chart = createChartWithFirstSeries($slide);

        addSecondSeriesToChart($chart);
        addThirdSeriesToChart($chart);

        setPrimaryAxesFormat($chart);
        setSecondaryAxesFormat($chart);

        $presentation->save("combo-chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}

function createChartWithFirstSeries($slide) {
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    // Ustaw tytuł wykresu.
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Chart Title");
    $chart->getChartTitle()->setOverlay(false);
    $titleParagraph = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(18);
    
    // Ustaw legendę wykresu.
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(12);

    // Usuń domyślnie wygenerowane serie i kategorie.
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $worksheetIndex = 0;
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    // Dodaj nowe kategorie.
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 3, 0, "Category 3"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 4, 0, "Category 4"));

    // Dodaj pierwszą serię.
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 1, 4.3));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 1, 2.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 1, 3.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 1, 4.5));

    return $chart;
}

function addSecondSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 2, "Series 2");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::ClusteredColumn);

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 2, 2.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 2, 4.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 2, 1.8));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Series 3");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::Line);

    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 1, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 2, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 3, 3, 3.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 4, 3, 5.0));

    $series->setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat($chart) {
    // Ustaw oś poziomą.
    $horizontalAxis = $chart->getAxes()->getHorizontalAxis();
    $horizontalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $horizontalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($horizontalAxis, "X Axis");

    // Ustaw oś pionową.
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $verticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($verticalAxis, "Y Axis 1");

    // Ustaw kolor głównych linii siatki pionowej.
    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $majorGridLinesFormat->getSolidFillColor()->setColor(new java("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat($chart) {
    // Ustaw drugą oś poziomą.
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    // Ustaw drugą oś pionową.
    $secondaryVerticalAxis = $chart->getAxes()->getSecondaryVerticalAxis();
    $secondaryVerticalAxis->setPosition(AxisPositionType::Right);
    $secondaryVerticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $secondaryVerticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle($axis, $axisTitle) {
    $axis->setTitle(true);
    $axis->getTitle()->setOverlay(false);
    $titleParagraph = $axis->getTitle()->addTextFrameForOverriding($axisTitle)->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(12);
}
```

## **Aktualizacja wykresów**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) reprezentującej prezentację zawierającą wykres, który chcesz zaktualizować.
2. Uzyskaj odniesienie do slajdu przy użyciu jego indeksu.
3. Przejdź przez wszystkie kształty, aby znaleźć żądany wykres.
4. Uzyskaj dostęp do arkusza danych wykresu.
5. Zmodyfikuj serie danych wykresu, zmieniając wartości serii.
6. Dodaj nową serię i wypełnij jej dane.
7. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod PHP pokazuje, jak zaktualizować wykres:

```php
  $pres = new Presentation();
  try {
    # Uzyskaj dostęp do pierwszego slajdu
    $sld = $pres->getSlides()->get_Item(0);
    # Pobierz wykres z domyślnymi danymi
    $chart = $sld->getShapes()->get_Item(0);
    # Ustawianie indeksu arkusza danych wykresu
    $defaultWorksheetIndex = 0;
    # Pobieranie arkusza danych wykresu
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Zmienianie nazwy kategorii wykresu
    $fact->getCell($defaultWorksheetIndex, 1, 0, "Modified Category 1");
    $fact->getCell($defaultWorksheetIndex, 2, 0, "Modified Category 2");
    # Pobierz pierwszą serię wykresu
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Teraz aktualizacja danych serii
    $fact->getCell($defaultWorksheetIndex, 0, 1, "New_Series1");// Modyfikowanie nazwy serii

    $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(44);
    # Pobierz drugą serię wykresu
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Teraz aktualizacja danych serii
    $fact->getCell($defaultWorksheetIndex, 0, 2, "New_Series2");// Modyfikowanie nazwy serii

    $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(99);
    # Teraz, dodawanie nowej serii
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 3, "Series 3"), $chart->getType());
    # Pobierz trzecią serię wykresu
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    # Teraz wypełnianie danych serii
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 3, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 30));
    $chart->setType(ChartType::ClusteredCylinder);
    # Zapisz prezentację z wykresem
    $pres->save("AsposeChartModified_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ustawienie zakresu danych dla wykresu**

Aby sprawdzić zakres już używany przez istniejący wykres, zobacz [Retrieve a Chart's Data Range](/slides/pl/php-java/chart-workbook/#retrieve-a-charts-data-range) .

Aby ustawić zakres danych dla wykresu, wykonaj następujące czynności:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) reprezentującej prezentację zawierającą wykres.
2. Uzyskaj odniesienie do slajdu przy użyciu jego indeksu.
3. Przejdź przez wszystkie kształty, aby znaleźć żądany wykres.
4. Uzyskaj dostęp do danych wykresu i ustaw zakres.
5. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod PHP pokazuje, jak ustawić zakres danych dla wykresu:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->get_Item(0);
    $chart->getChartData()->setRange("Sheet1!A1:B4");
    $pres->save("SetDataRange_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is??? null($pres)) {
      $pres->dispose();
    }
  }
```

## **Użycie domyślnych markerów w wykresach**

Gdy używasz domyślnych markerów w wykresach, każda seria wykresu automatycznie otrzymuje inny symbol markera.

Ten kod PHP pokazuje, jak automatycznie ustawić marker serii wykresu:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 10, 10, 400, 400);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $fact = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "C1"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 1, 24));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "C2"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 1, 23));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "C3"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 1, -10));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 4, 0, "C4"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 1, null));
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 2, "Series 2"), $chart->getType());
    # Pobierz drugą serię wykresu
    $series2 = $chart->getChartData()->getSeries()->get_Item(1);
    # Teraz wypełnianie danych serii
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 2, 30));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 2, 10));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 2, 60));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 2, 40));
    $chart->setLegend(true);
    $chart->getLegend()->setOverlay(false);
    $pres->save("DefaultMarkersInChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Jakie typy wykresów są obsługiwane przez Aspose.Slides?**

Aspose.Slides obsługuje szeroką gamę [chart types](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/), w tym słupkowe, liniowe, kołowe, powierzchniowe, punktowe, histogramy, radarowe i wiele innych. Ta elastyczność pozwala wybrać najbardziej odpowiedni typ wykresu do potrzeb wizualizacji danych.

**Jak dodać nowy wykres do slajdu?**

Aby dodać wykres, najpierw tworzysz instancję klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) , pobierasz żądany slajd przy użyciu jego indeksu, a następnie wywołujesz metodę dodającą wykres, określając typ wykresu i początkowe dane. Proces ten integruje wykres bezpośrednio z prezentacją.

**Jak mogę zaktualizować dane wyświetlane w wykresie?**

Możesz zaktualizować dane wykresu, uzyskując dostęp do jego skoroszytu danych ([ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/)), wyczyszczając domyślne serie i kategorie, a następnie dodając własne dane. Umożliwia to odświeżenie wykresu, aby odzwierciedlał najnowsze informacje.

**Czy można dostosować wygląd wykresu?**

Tak, Aspose.Slides oferuje rozbudowane opcje dostosowywania. Możesz modyfikować kolory, czcionki, etykiety, legendy oraz inne [formatting elements](/slides/pl/php-java/chart-entities/) aby dopasować wygląd wykresu do konkretnych wymagań projektowych.