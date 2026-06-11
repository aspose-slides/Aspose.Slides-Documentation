---
title: Dostosuj obszary wykresów w prezentacjach w PHP
linktitle: Obszar wykresu
type: docs
url: /pl/php-java/chart-plot-area/
keywords:
- wykres
- obszar wykresu
- szerokość obszaru wykresu
- wysokość obszaru wykresu
- rozmiar obszaru wykresu
- tryb układu
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Odkryj, jak dostosować obszary wykresów w prezentacjach PowerPoint przy użyciu Aspose.Slides for PHP via Java. Popraw wygląd swoich slajdów w prosty sposób."
---
## **Omówienie**

Ten artykuł pokazuje, jak pracować z obszarem wykresu w Aspose.Slides. Wyjaśnia, jak uzyskać rzeczywistą pozycję i rozmiar obszaru wykresu, walidując układ wykresu, a następnie odczytując jego wartości X, Y, szerokości i wysokości. Pokazuje także, jak skonfigurować tryb układu obszaru wykresu, gdy układ jest ustawiany ręcznie, używając `LayoutTargetType` do określenia, czy obszar wykresu jest obliczany według jego wewnętrznego regionu, czy według zewnętrznego regionu wraz z osiami i etykietami osi.

## **Pobranie szerokości i wysokości obszaru wykresu**
Aspose.Slides for PHP via Java udostępnia prosty interfejs API dla .

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Dodaj wykres z domyślnymi danymi.
4. Wywołaj metodę [Chart.validateChartLayout](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chart/validatechartlayout/) przed pobraniem rzeczywistych wartości.
5. Pobiera rzeczywistą pozycję X (lewa) elementu wykresu względem lewego górnego rogu wykresu.
6. Pobiera rzeczywistą pozycję górną elementu wykresu względem lewego górnego rogu wykresu.
7. Pobiera rzeczywistą szerokość elementu wykresu.
8. Pobiera rzeczywistą wysokość elementu wykresu.

```php
  # Utwórz instancję klasy Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ustawienie trybu układu obszaru wykresu**
Aspose.Slides for PHP via Java udostępnia prosty interfejs API do ustawiania trybu układu obszaru wykresu. Metody [**setLayoutTargetType**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) i [**getLayoutTargetType**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) zostały dodane do klasy [**ChartPlotArea**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ChartPlotArea). Jeśli układ obszaru wykresu jest definiowany ręcznie, ta właściwość określa, czy układać obszar wykresu wewnątrz (bez osi i etykiet osi) czy na zewnątrz (z uwzględnieniem osi i etykiet osi). Dostępne są dwa możliwe wartości, zdefiniowane w wyliczeniu [**LayoutTargetType**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/LayoutTargetType).

- [**LayoutTargetType::Inner**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/LayoutTargetType#Inner) - określa, że rozmiar obszaru wykresu określa rozmiar samego obszaru wykresu, bez uwzględniania znaczników i etykiet osi.
- [**LayoutTargetType::Outer**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/LayoutTargetType#Outer) - określa, że rozmiar obszaru wykresu określa rozmiar obszaru wykresu, znaczników i etykiet osi.

Przykładowy kod znajduje się poniżej.

```php
  # Utwórz instancję klasy Presentation
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getPlotArea()->setX(0.2);
    $chart->getPlotArea()->setY(0.2);
    $chart->getPlotArea()->setWidth(0.7);
    $chart->getPlotArea()->setHeight(0.7);
    $chart->getPlotArea()->setLayoutTargetType(LayoutTargetType::Inner);
    $pres->save("SetLayoutMode_outer.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**W jakich jednostkach zwracane są rzeczywiste x, rzeczywiste y, rzeczywista szerokość i rzeczywista wysokość?**

W punktach; 1 cal = 72 punkty. Są to jednostki współrzędnych Aspose.Slides.

**Jak obszar rysowania (Plot Area) różni się od obszaru wykresu (Chart Area) pod względem zawartości?**

Obszar rysowania (Plot Area) jest regionem, w którym rysowane są dane (serie, linie siatki, linie trendu itp.); obszar wykresu (Chart Area) obejmuje elementy otaczające (tytuł, legendę itp.). W wykresach 3D obszar rysowania obejmuje także ściany/podłogę oraz osie.

**Jak interpretowane są wartości x, y, szerokość i wysokość obszaru rysowania, gdy układ jest ręczny?**

Są to ułamki (0‑1) całkowitego rozmiaru wykresu; w tym trybie automatyczne pozycjonowanie jest wyłączone i używane są podane przez Ciebie ułamki.

**Dlaczego pozycja obszaru rysowania zmieniła się po dodaniu/przeniesieniu legendy?**

Legenda znajduje się w obszarze wykresu poza obszarem rysowania, ale wpływa na układ i dostępne miejsce, dlatego obszar rysowania może się przesunąć, gdy włączone jest automatyczne pozycjonowanie. (Jest to standardowe zachowanie wykresów w PowerPoint.)