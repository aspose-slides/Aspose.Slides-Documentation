---
title: Dodaj linie trendu do wykresów w prezentacji w PHP
linktitle: Linia trendu
type: docs
url: /pl/php-java/trend-line/
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
- PHP
- Aspose.Slides
description: "Szybko dodawaj i dostosowuj linie trendu w wykresach PowerPoint przy użyciu Aspose.Slides for PHP via Java — praktyczny poradnik, który przyciągnie uwagę Twojej publiczności."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dodać linie trendu do wykresów w prezentacji przy użyciu Aspose.Slides. Pokazuje, jak utworzyć wykres, dodać linie trendu do serii wykresu oraz pracować z różnymi typami linii trendu, w tym wykładniczym, liniowym, logarytmicznym, średnią kroczącą, wielomianowym i potęgowym.

Opisuje także, jak dodać własną linię do wykresu, wstawiając kształt linii, oraz zawiera krótkie FAQ dotyczące wartości projekcji linii trendu w przód i w tył oraz tego, czy linie trendu są zachowywane podczas eksportu do PDF lub SVG oraz przy renderowaniu wykresów jako obrazy.

## **Dodawanie linii trendu**
Aspose.Slides for PHP via Java udostępnia prosty interfejs API do zarządzania różnymi liniami trendu wykresu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
1. Uzyskaj odwołanie do slajdu za jego indeksem.
1. Dodaj wykres z domyślnymi danymi wraz z wybranym typem (w tym przykładzie użyto ChartType::ClusteredColumn).
1. Dodaj wykładniczą linię trendu dla serii wykresu 1.
1. Dodaj liniową linię trendu dla serii wykresu 1.
1. Dodaj logarytmiczną linię trendu dla serii wykresu 2.
1. Dodaj linię trendu będącą średnią kroczącą dla serii wykresu 2.
1. Dodaj wielomianową linię trendu dla serii wykresu 3.
1. Dodaj potęgową linię trendu dla serii wykresu 3.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

Poniższy kod służy do utworzenia wykresu z liniami trendu.

```php
  # Utwórz instancję klasy Presentation
  $pres = new Presentation();
  try {
    # Tworzenie wykresu kolumnowego grupowanego
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);
    # Dodawanie wykładniczej linii trendu dla serii wykresu 1
    $tredLinep = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Exponential);
    $tredLinep->setDisplayEquation(false);
    $tredLinep->setDisplayRSquaredValue(false);
    # Dodawanie liniowej linii trendu dla serii wykresu 1
    $tredLineLin = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Linear);
    $tredLineLin->setTrendlineType(TrendlineType::Linear);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Dodawanie logarytmicznej linii trendu dla serii wykresu 2
    $tredLineLog = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Logarithmic);
    $tredLineLog->setTrendlineType(TrendlineType::Logarithmic);
    $tredLineLog->addTextFrameForOverriding("New log trend line");
    # Dodawanie linii trendu średniej kroczącej dla serii wykresu 2
    $tredLineMovAvg = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::MovingAverage);
    $tredLineMovAvg->setTrendlineType(TrendlineType::MovingAverage);
    $tredLineMovAvg->setPeriod(3);
    $tredLineMovAvg->setTrendlineName("New TrendLine Name");
    # Dodawanie wielomianowej linii trendu dla serii wykresu 3
    $tredLinePol = $chart->getChartData()->getSeries()->get_Item(2)->getTrendLines()->add(TrendlineType::Polynomial);
    $tredLinePol->setTrendlineType(TrendlineType::Polynomial);
    $tredLinePol->setForward(1);
    $tredLinePol->setOrder(3);
    # Dodawanie potęgowej linii trendu dla serii wykresu 3
    $tredLinePower = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Power);
    $tredLinePower->setTrendlineType(TrendlineType::Power);
    $tredLinePower->setBackward(1);
    # Zapisywanie prezentacji
    $pres->save("ChartTrendLines_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Dodawanie własnej linii**
Aspose.Slides for PHP via Java udostępnia prosty interfejs API do dodawania własnych linii w wykresie. Aby dodać prostą linię do wybranego slajdu prezentacji, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation)
- Uzyskaj odwołanie do slajdu, używając jego indeksu
- Utwórz nowy wykres, korzystając z metody AddChart udostępnionej przez obiekt Shapes
- Dodaj AutoShape typu Line, używając metody AddAutoShape udostępnionej przez obiekt Shapes
- Ustaw kolor linii kształtu.
- Zapisz zmodyfikowaną prezentację jako plik PPTX

Poniższy kod służy do utworzenia wykresu z własnymi liniami.

```php
  # Utwórz instancję klasy Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $shape = $chart->getUserShapes()->getShapes()->addAutoShape(ShapeType::Line, 0, $chart->getHeight() / 2, $chart->getWidth(), 0);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("Presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Co oznaczają terminy „forward” i „backward” w kontekście linii trendu?**

Są to długości linii trendu projekowanej w przód/w tył: dla wykresów punktowych (XY) – w jednostkach osi; dla wykresów nie‑punktowych – w liczbie kategorii. Dozwolone są wyłącznie wartości nieujemne.

**Czy linia trendu zostanie zachowana przy eksporcie prezentacji do PDF lub SVG oraz przy renderowaniu slajdu jako obrazu?**

Tak. Aspose.Slides konwertuje prezentacje do [PDF](/slides/pl/php-java/convert-powerpoint-to-pdf/)/[SVG](/slides/pl/php-java/render-a-slide-as-an-svg-image/) i renderuje wykresy jako obrazy; linie trendu, będąc częścią wykresu, są zachowywane podczas tych operacji. Dostępna jest także metoda umożliwiająca [eksport obrazu samego wykresu](/slides/pl/php-java/create-shape-thumbnails/).