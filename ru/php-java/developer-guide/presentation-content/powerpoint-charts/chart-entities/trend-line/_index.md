---
title: Трендовая линия
type: docs
url: /ru/php-java/trend-line/
---

## **Добавление трендовой линии**
Aspose.Slides для PHP на базе Java предоставляет простой API для управления различными трендовыми линиями графиков:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте график с данными по умолчанию и любого желаемого типа (в этом примере используется ChartType::ClusteredColumn).
1. Добавление экспоненциальной трендовой линии для первой серии графика.
1. Добавление линейной трендовой линии для первой серии графика.
1. Добавление логарифмической трендовой линии для второй серии графика.
1. Добавление трендовой линии скользящего среднего для второй серии графика.
1. Добавление полиномиальной трендовой линии для третьей серии графика.
1. Добавление степени для третьей серии графика.
1. Запишите измененную презентацию в файл PPTX.

Следующий код используется для создания графика с трендовыми линиями.

```php
  # Создайте экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Создание графика со столбчатым кластером
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);
    # Добавление экспоненциальной трендовой линии для первой серии графика
    $tredLinep = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Exponential);
    $tredLinep->setDisplayEquation(false);
    $tredLinep->setDisplayRSquaredValue(false);
    # Добавление линейной трендовой линии для первой серии графика
    $tredLineLin = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Linear);
    $tredLineLin->setTrendlineType(TrendlineType::Linear);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Добавление логарифмической трендовой линии для второй серии графика
    $tredLineLog = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Logarithmic);
    $tredLineLog->setTrendlineType(TrendlineType::Logarithmic);
    $tredLineLog->addTextFrameForOverriding("Новая логарифмическая трендовая линия");
    # Добавление трендовой линии скользящего среднего для второй серии графика
    $tredLineMovAvg = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::MovingAverage);
    $tredLineMovAvg->setTrendlineType(TrendlineType::MovingAverage);
    $tredLineMovAvg->setPeriod(3);
    $tredLineMovAvg->setTrendlineName("Новое имя трендовой линии");
    # Добавление полиномиальной трендовой линии для третьей серии графика
    $tredLinePol = $chart->getChartData()->getSeries()->get_Item(2)->getTrendLines()->add(TrendlineType::Polynomial);
    $tredLinePol->setTrendlineType(TrendlineType::Polynomial);
    $tredLinePol->setForward(1);
    $tredLinePol->setOrder(3);
    # Добавление степени для третьей серии графика
    $tredLinePower = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Power);
    $tredLinePower->setTrendlineType(TrendlineType::Power);
    $tredLinePower->setBackward(1);
    # Сохранение презентации
    $pres->save("ChartTrendLines_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Добавление пользовательской линии**
Aspose.Slides для PHP на базе Java предоставляет простой API для добавления пользовательских линий в график. Чтобы добавить простую прямую линию на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)
- Получите ссылку на слайд, используя его индекс
- Создайте новый график, используя метод AddChart, предоставленный объектом Shapes
- Добавьте автоформу типа линия, используя метод AddAutoShape, предоставленный объектом Shapes
- Установите цвет линий формы.
- Запишите измененную презентацию в файл PPTX

Следующий код используется для создания графика с пользовательскими линиями.

```php
  # Создайте экземпляр класса Presentation
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