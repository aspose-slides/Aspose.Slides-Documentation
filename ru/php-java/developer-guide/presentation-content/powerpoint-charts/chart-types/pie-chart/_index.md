---
title: Круговая диаграмма
type: docs
url: /ru/php-java/pie-chart/
---

## **Вторичные параметры построения для Круговой диаграммы и Круговой диаграммы с боковой частью**
Aspose.Slides для PHP через Java теперь поддерживает вторичные параметры построения для Круговой диаграммы с боковой частью или Круговой диаграммы с боковой частью. В этой теме мы покажем вам, как задать эти параметры с помощью Aspose.Slides. Чтобы задать свойства, выполните следующие действия:

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Добавьте диаграмму на слайд.
1. Задайте вторичные параметры построения диаграммы.
1. Сохраните презентацию на диск.

В приведенном ниже примере мы установили разные свойства круговой диаграммы с боковой частью.

```php
  # Создайте экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Добавьте диаграмму на слайд
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    # Установите разные свойства
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setSecondPieSize(149);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitBy(PieSplitType::ByPercentage);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitPosition(53);
    # Сохраните презентацию на диск
    $pres->save("SecondPlotOptionsforCharts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Установка автоматических цветов секторов круговой диаграммы**
Aspose.Slides для PHP через Java предоставляет простой API для установки автоматических цветов секторов круговой диаграммы. Пример кода применяет настройку вышеуказанных свойств.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите первый слайд.
1. Добавьте диаграмму с данными по умолчанию.
1. Установите заголовок диаграммы.
1. Установите первый ряд на показ значений.
1. Установите индекс листа данных диаграммы.
1. Получите рабочий лист данных диаграммы.
1. Удалите автоматически сгенерированные ряды и категории.
1. Добавьте новые категории.
1. Добавьте новые ряды.

Запишите измененную презентацию в файл PPTX.

```php
  # Создайте экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Добавьте диаграмму с данными по умолчанию
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Установка заголовка диаграммы
    $chart->getChartTitle()->addTextFrameForOverriding("Пример заголовка");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # Установите первый ряд на показ значений
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Установка индекса листа данных диаграммы
    $defaultWorksheetIndex = 0;
    # Получение рабочего листа данных диаграммы
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Удалите автоматически сгенерированные ряды и категории
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Добавление новых категорий
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "Первый квартал"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "Второй квартал"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "Третий квартал"));
    # Добавление новых рядов
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Ряд 1"), $chart->getType());
    # Теперь заполним данные ряда
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getParentSeriesGroup()->setColorVaried(true);
    $pres->save("Pie.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```