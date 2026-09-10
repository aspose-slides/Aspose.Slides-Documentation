---
title: Создание или обновление диаграмм презентаций PowerPoint в PHP
linktitle: Создание или обновление диаграмм
type: docs
weight: 10
url: /ru/php-java/create-chart/
keywords:
- добавить диаграмму
- создать диаграмму
- редактировать диаграмму
- изменить диаграмму
- обновить диаграмму
- точечная диаграмма
- круговая диаграмма
- линейная диаграмма
- деревовидная диаграмма
- диаграмма акций
- диаграмма ящик с усами
- воронкообразная диаграмма
- диаграмма Sunburst
- гистограмма
- радиальная диаграмма
- многокатегориальная диаграмма
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Создавайте и настраивайте диаграммы в презентациях PowerPoint с помощью Aspose.Slides для PHP через Java. Добавляйте, форматируйте и редактируйте диаграммы, используя практические примеры кода."
---
## **Обзор**

Эта статья предоставляет всестороннее руководство по созданию и настройке диаграмм с использованием Aspose.Slides. Вы узнаете, как программно добавить диаграмму на слайд, заполнить её данными и применить различные параметры форматирования, соответствующие вашим конкретным требованиям к дизайну. На протяжении статьи детальные примеры кода иллюстрируют каждый шаг, от инициализации презентации и объекта диаграммы до конфигурации рядов, осей и легенд. Следуя этому руководству, вы получите прочное понимание того, как интегрировать динамическую генерацию диаграмм в свои приложения, упростив процесс создания презентаций, основанных на данных.

## **Создание диаграммы**

Диаграммы помогают людям быстро визуализировать данные и получать инсайты, которые могут быть неочевидны из таблицы или электронной таблицы.

**Зачем создавать диаграммы?**

Используя диаграммы, вы можете:

* агрегировать, сжимать или обобщать большие объёмы данных на одном слайде презентации
* выявлять закономерности и тенденции в данных
* определять направление и динамику данных во времени или относительно конкретной единицы измерения
* выявлять выбросы, аномалии, отклонения, ошибки, бессмысленные данные и т.д.
* коммуницировать или представлять сложные данные

В PowerPoint вы можете создавать диаграммы через функцию *Insert*, которая предоставляет шаблоны для создания множества типов диаграмм. С помощью Aspose.Slides вы можете создавать как обычные диаграммы (на основе популярных типов), так и пользовательские диаграммы.

{{% alert color="info" title="Note" %}}
Для создания диаграмм используйте класс [ChartType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/charttype/). Поля этого класса соответствуют различным типам диаграмм.
{{% /alert %}}

### **Создание сгруппированных столбчатых диаграмм**

В этом разделе объясняется, как создавать сгруппированные столбчатые диаграммы с помощью Aspose.Slides. Вы узнаете, как инициализировать презентацию, добавить диаграмму и настроить её элементы, такие как заголовок, данные, ряды, категории и стиль. Следуйте инструкциям ниже, чтобы увидеть, как генерируется стандартная сгруппированная столбчатая диаграмма:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте диаграмму с некоторыми данными и укажите тип `ChartType::ClusteredColumn`.
1. Добавьте заголовок к диаграмме.
1. Получите доступ к листу данных диаграммы.
1. Очистите все серии и категории по умолчанию.
1. Добавьте новые серии и категории.
1. Добавьте новые данные диаграммы для серий.
1. Примените цвет заполнения к сериям диаграммы.
1. Добавьте подписи к сериям диаграммы.
1. Сохраните изменённую презентацию как файл PPTX.

Этот код C# демонстрирует, как создать сгруппированную столбчатую диаграмму:

```php
  # Создаёт экземпляр класса презентации, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Получает первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавляет диаграмму с её данными по умолчанию
    $chart = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 0, 0, 500, 500);
    # Устанавливает заголовок диаграммы
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->hasTitle();
    # Настраивает первый ряд для отображения значений
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Устанавливает индекс листа данных диаграммы
    $defaultWorksheetIndex = 0;
    # Получает рабочий лист данных диаграммы
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Удаляет автоматически сгенерированные ряды и категории
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $s = $chart->getChartData()->getSeries()->size();
    $s = $chart->getChartData()->getCategories()->size();
    # Добавляет новые ряды
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Добавляет новые категории
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Берёт первый ряд диаграммы
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Теперь заполняет данные ряда
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Устанавливает цвет заливки для ряда
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Берёт второй ряд диаграммы
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Заполняет данные ряда
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Устанавливает цвет заливки для ряда
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Создаёт пользовательские подписи для каждой категории нового ряда
    # Устанавливает первую подпись для отображения названия категории
    $lbl = $series->getDataPoints()->get_Item(0)->getLabel();
    $lbl->getDataLabelFormat()->setShowCategoryName(true);
    $lbl = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    # Отображает значение для третьей подписи
    $lbl = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl->getDataLabelFormat()->setShowValue(true);
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    $lbl->getDataLabelFormat()->setSeparator("/");
    # Сохраняет презентацию с диаграммой
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Создание точечных диаграмм**

Точечные диаграммы (также известные как scatter plots или x‑y графики) часто используются для проверки закономерностей или демонстрации корреляций между двумя переменными.

Используйте точечную диаграмму, когда:

* у вас есть парные числовые данные
* у вас есть две переменные, которые хорошо сочетаются
* вы хотите определить, связаны ли две переменные
* у вас есть независимая переменная, имеющая несколько значений для зависимой переменной

1. Следуйте инструкциям в [Create Clustered Column Charts](#create-clustered-column-charts).
2. Для третьего шага добавьте диаграмму с некоторыми данными и укажите тип диаграммы как один из следующих:
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/ru/php-java/aspose.slides/charttype/#ScatterWithMarkers) - _Представляет точечную диаграмму._
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/ru/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Представляет точечную диаграмму, соединённую кривыми, с маркерами данных._
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/ru/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Представляет точечную диаграмму, соединённую кривыми, без маркеров данных._
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/ru/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Представляет точечную диаграмму, соединённую линиями, с маркерами данных._
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/ru/php-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Представляет точечную диаграмму, соединённую линиями, без маркеров данных._

Этот PHP‑код показывает, как создать точечную диаграмму с разными маркерами для каждой серии:

```php
  # Создаёт экземпляр класса презентации, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Получает первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Создаёт диаграмму по умолчанию
    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 0, 0, 400, 400);
    # Получает индекс листа данных диаграммы по умолчанию
    $defaultWorksheetIndex = 0;
    # Получает рабочий лист данных диаграммы
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Удаляет демонстрационные ряды
    $chart->getChartData()->getSeries()->clear();
    # Добавляет новые ряды
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 3, "Series 2"), $chart->getType());
    # Берёт первый ряд диаграммы
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Добавляет новую точку (1:3) в ряд
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 1), $fact->getCell($defaultWorksheetIndex, 2, 2, 3));
    # Добавляет новую точку (2:10)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 2), $fact->getCell($defaultWorksheetIndex, 3, 2, 10));
    # Изменяет тип ряда
    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);
    # Изменяет маркер ряда диаграммы
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);
    # Берёт второй ряд диаграммы
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Добавляет новую точку (5:2) туда
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 5), $fact->getCell($defaultWorksheetIndex, 2, 4, 2));
    # Добавляет новую точку (3:1)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 3), $fact->getCell($defaultWorksheetIndex, 3, 4, 1));
    # Добавляет новую точку (2:2)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 4, 3, 2), $fact->getCell($defaultWorksheetIndex, 4, 4, 2));
    # Добавляет новую точку (5:1)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 5, 3, 5), $fact->getCell($defaultWorksheetIndex, 5, 4, 1));
    # Изменяет маркер ряда диаграммы
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Создание круговых диаграмм**

Круговые диаграммы лучше всего использовать для отображения соотношения части к целому в данных, особенно когда данные содержат категориальные метки с числовыми значениями. Однако если в ваших данных много частей или меток, имеет смысл использовать столбчатую диаграмму.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType::Pie](https://reference.aspose.com/slides/ru/php-java/aspose.slides/charttype/#Pie).
4. Получите доступ к рабочей книге данных диаграммы [ChartDataWorkbook](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdataworkbook/).
5. Очистите серии и категории по умолчанию.
6. Добавьте новые серии и категории.
7. Добавьте новые данные диаграммы для серий.
8. Добавьте новые точки в диаграмму и примените пользовательские цвета для секторов круговой диаграммы.
9. Установите подписи для серий.
10. Включите линии‑выноски для подписей серий.
11. Установите угол поворота секторов круговой диаграммы.
12. Сохраните изменённую презентацию как файл PPTX.

Этот PHP‑код показывает, как создать круговую диаграмму:

```php
  # Создаёт экземпляр класса презентации, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Получает первый слайд
    $slides = $pres->getSlides()->get_Item(0);
    # Добавляет диаграмму с данными по умолчанию
    $chart = $slides->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Устанавливает заголовок диаграммы
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # Настраивает первый ряд для отображения значений
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Устанавливает индекс листа данных диаграммы
    $defaultWorksheetIndex = 0;
    # Получает рабочий лист данных диаграммы
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Удаляет автоматически сгенерированные ряды и категории
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Добавляет новые категории
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # Добавляет новые ряды
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # Заполняет данные ряда
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Не работает в новой версии
    # Добавление новых точек и установка цвета сектора
    # series.IsColorVaried = true;
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setColorVaried(true);
    $point = $series->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    # Устанавливает границу сектора
    $point->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $point->getFormat()->getLine()->setWidth(3.0);
    $point->getFormat()->getLine()->setStyle(LineStyle->ThinThick);
    $point->getFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    $point1 = $series->getDataPoints()->get_Item(1);
    $point1->getFormat()->getFill()->setFillType(FillType::Solid);
    $point1->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # Устанавливает границу сектора
    $point1->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point1->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $point1->getFormat()->getLine()->setWidth(3.0);
    $point1->getFormat()->getLine()->setStyle(LineStyle->Single);
    $point1->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDot);
    $point2 = $series->getDataPoints()->get_Item(2);
    $point2->getFormat()->getFill()->setFillType(FillType::Solid);
    $point2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # Устанавливает границу сектора
    $point2->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point2->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $point2->getFormat()->getLine()->setWidth(2.0);
    $point2->getFormat()->getLine()->setStyle(LineStyle->ThinThin);
    $point2->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDotDot);
    # Создаёт пользовательские подписи для каждой категории нового ряда
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
    # Отображает линии‑выноски для диаграммы
    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);
    # Устанавливает угол поворота секторов круговой диаграммы
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setFirstSliceAngle(180);
    # Сохраняет презентацию с диаграммой
    $pres->save("PieChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Создание линейных диаграмм**

Линейные диаграммы (также известные как line graphs) лучше всего использовать в ситуациях, когда необходимо продемонстрировать изменения значения во времени. С помощью линейной диаграммы вы можете сравнивать большой объём данных одновременно, отслеживать изменения и тренды во времени, выделять аномалии в рядах данных и многое другое.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType::Line](https://reference.aspose.com/slides/ru/php-java/aspose.slides/charttype/#Line).
1. Получите доступ к рабочей книге данных диаграммы ([ChartDataWorkbook](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdataworkbook/)).
1. Очистите серии и категории по умолчанию.
1. Добавьте новые серии и категории.
1. Добавьте новые данные диаграммы для серий.
1. Сохраните изменённую презентацию как файл PPTX.

Этот PHP‑код показывает, как создать линейную диаграмму:

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

По умолчанию точки на линейной диаграмме соединяются прямыми непрерывными линиями. Если вы хотите, чтобы точки соединялись пунктиром, можете указать предпочтительный тип пунктирной линии следующим образом:

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

### **Создание диаграмм Tree Map**

Диаграммы Tree Map лучше всего использовать для данных продаж, когда необходимо показать относительный размер категорий данных и быстро привлечь внимание к элементам, являющимся крупными вкладчиками в каждой категории.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType::Treemap](https://reference.aspose.com/slides/ru/php-java/aspose.slides/charttype/#Treemap).
4. Получите доступ к рабочей книге данных диаграммы [ChartDataWorkbook](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdataworkbook/).
5. Очистите серии и категории по умолчанию.
6. Добавьте новые серии и категории.
7. Добавьте новые данные диаграммы для серий.
8. Сохраните изменённую презентацию как файл PPTX.

Этот PHP‑код показывает, как создать диаграмму Tree Map:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Treemap, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # ветка 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # ветка 2
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

### **Создание Stock диаграмм**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType::OpenHighLowClose](https://reference.aspose.com/slides/ru/php-java/aspose.slides/charttype/#OpenHighLowClose).
4. Получите доступ к рабочей книге данных диаграммы [ChartDataWorkbook](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdataworkbook/).
5. Очистите серии и категории по умолчанию.
6. Добавьте новые серии и категории.
7. Добавьте новые данные диаграммы для серий.
8. Укажите формат линий high‑low.
9. Сохраните изменённую презентацию как файл PPTX.

Этот PHP‑код показывает, как создать Stock диаграмму:

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

### **Создание диаграмм Box and Whisker**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType::BoxAndWhisker](https://reference.aspose.com/slides/ru/php-java/aspose.slides/charttype/#BoxAndWhisker).
4. Получите доступ к рабочей книге данных диаграммы [ChartDataWorkbook](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdataworkbook/).
5. Очистите серии и категории по умолчанию.
6. Добавьте новые серии и категории.
7. Добавьте новые данные диаграммы для серий.
8. Сохраните изменённую презентацию как файл PPTX.

Этот PHP‑код показывает, как создать диаграмму Box and Whisker:

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

### **Создание воронкообразных диаграмм**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType::Funnel](https://reference.aspose.com/slides/ru/php-java/aspose.slides/charttype/#Funnel).
4. Сохраните изменённую презентацию как файл PPTX.

Этот PHP‑код показывает, как создать воронкообразную диаграмму:

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

### **Создание Sunburst диаграмм**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType::Sunburst](https://reference.aspose.com/slides/ru/php-java/aspose.slides/charttype/#Sunburst).
4. Сохраните изменённую презентацию как файл PPTX.

Этот PHP‑код показывает, как создать Sunburst диаграмму:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # ветка 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # ветка 2
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

### **Создание гистограмм**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType::Histogram](https://reference.aspose.com/slides/ru/php-java/aspose.slides/charttype/#Histogram).
4. Получите доступ к рабочей книге данных диаграммы [ChartDataWorkbook](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdataworkbook/).
5. Очистите серии и категории по умолчанию.
6. Добавьте новые серии и категории.
7. Сохраните изменённую презентацию как файл PPTX.

Этот PHP‑код показывает, как создать гистограмму:

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

### **Создание радиальных диаграмм**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте диаграмму с некоторыми данными и укажите предпочтительный тип диаграммы ([ChartType::Radar](https://reference.aspose.com/slides/ru/php-java/aspose.slides/charttype/#Radar) в данном случае).
4. Сохраните изменённую презентацию как файл PPTX.

Этот PHP‑код показывает, как создать радиальную диаграмму:

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

### **Создание многокатегорийных диаграмм**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType::ClusteredColumn](https://reference.aspose.com/slides/ru/php-java/aspose.slides/charttype/#ClusteredColumn).
4. Получите доступ к рабочей книге данных диаграммы [ChartDataWorkbook](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdataworkbook/).
5. Очистите серии и категории по умолчанию.
6. Добавьте новые серии и категории.
7. Добавьте новые данные диаграммы для серий.
8. Сохраните изменённую презентацию как файл PPTX.

Этот PHP‑код показывает, как создать многокатегорийную диаграмму:

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
    # Добавление рядов
    $series = $ch->getChartData()->getSeries()->add($fact->getCell(0, "D1", "Series 1"), ChartType::ClusteredColumn);
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D2", 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D3", 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D4", 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D5", 40));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D6", 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D7", 60));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D8", 70));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D9", 80));
    # Save presentation with chart
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Создание картографических диаграмм**

Картографические диаграммы визуализируют географические данные и помогают сравнивать значения между регионами.

Этот PHP‑код показывает, как создать картографическую диаграмму:

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

### **Создание комбинированных диаграмм**

Комбинированная диаграмма (или combo chart) объединяет два или более типов диаграмм в одном графике. Эта диаграмма позволяет выделять, сравнивать или исследовать различия между двумя и более наборами данных, помогая выявлять взаимосвязи между ними.

![The combination chart](combination_chart.png)

Следующий PHP‑код показывает, как создать отображённую выше комбинированную диаграмму в презентации PowerPoint:

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

    // Установить заголовок диаграммы.
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Chart Title");
    $chart->getChartTitle()->setOverlay(false);
    $titleParagraph = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(18);
    
    // Установить легенду диаграммы.
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(12);

    // Удалить автоматически сгенерированные ряды и категории.
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $worksheetIndex = 0;
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    // Добавить новые категории.
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 3, 0, "Category 3"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 4, 0, "Category 4"));

    // Добавить первый ряд.
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
    // Установить горизонтальную ось.
    $horizontalAxis = $chart->getAxes()->getHorizontalAxis();
    $horizontalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $horizontalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($horizontalAxis, "X Axis");

    // Установить вертикальную ось.
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $verticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($verticalAxis, "Y Axis 1");

    // Установить цвет основных линий сетки вертикальной оси.
    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $majorGridLinesFormat->getSolidFillColor()->setColor(new java("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat($chart) {
    // Установить вторичную горизонтальную ось.
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    // Установить вторичную вертикальную ось.
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

## **Обновление диаграмм**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/), представляющего презентацию, содержащую диаграмму, которую требуется обновить.
2. Получите ссылку на слайд, используя его индекс.
3. Пройдите по всем фигурам, чтобы найти нужную диаграмму.
4. Получите доступ к листу данных диаграммы.
5. Измените ряд данных диаграммы, изменив значения ряда.
6. Добавьте новый ряд и заполните его данными.
7. Сохраните изменённую презентацию как файл PPTX.

Этот PHP‑код показывает, как обновить диаграмму:

```php
  $pres = new Presentation();
  try {
    # Доступ к первому слайду
    $sld = $pres->getSlides()->get_Item(0);
    # Получить диаграмму с данными по умолчанию
    $chart = $sld->getShapes()->get_Item(0);
    # Установка индекса листа данных диаграммы
    $defaultWorksheetIndex = 0;
    # Получение листа данных диаграммы
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Изменение названия категории диаграммы
    $fact->getCell($defaultWorksheetIndex, 1, 0, "Modified Category 1");
    $fact->getCell($defaultWorksheetIndex, 2, 0, "Modified Category 2");
    # Получить первый ряд диаграммы
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Сейчас обновляются данные ряда
    $fact->getCell($defaultWorksheetIndex, 0, 1, "New_Series1");// Изменение названия ряда

    $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(44);
    # Получить второй ряд диаграммы
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Сейчас обновляются данные ряда
    $fact->getCell($defaultWorksheetIndex, 0, 2, "New_Series2");// Изменение названия ряда

    $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(99);
    # Сейчас добавляем новый ряд
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 3, "Series 3"), $chart->getType());
    # Получить третий ряд диаграммы
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    # Сейчас заполняем данные ряда
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 3, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 30));
    $chart->setType(ChartType::ClusteredCylinder);
    # Сохранить презентацию с диаграммой
    $pres->save("AsposeChartModified_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Установка диапазона данных для диаграммы**

Чтобы установить диапазон данных для диаграммы, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/), представляющего презентацию, содержащую диаграмму.
2. Получите ссылку на слайд, используя его индекс.
3. Пройдите по всем фигурам, чтобы найти нужную диаграмму.
4. Получите доступ к данным диаграммы и задайте диапазон.
5. Сохраните изменённую презентацию как файл PPTX.

Этот PHP‑код показывает, как установить диапазон данных для диаграммы:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->get_Item(0);
    $chart->getChartData()->setRange("Sheet1!A1:B4");
    $pres->save("SetDataRange_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Использование стандартных маркеров в диаграммах**

При использовании стандартных маркеров в диаграммах каждый ряд диаграммы автоматически получает отдельный символ маркера.

Этот PHP‑код показывает, как автоматически задать маркер ряда диаграммы:

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
    # Взять второй ряд диаграммы
    $series2 = $chart->getChartData()->getSeries()->get_Item(1);
    # Сейчас заполняем данные ряда
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

**Какие типы диаграмм поддерживает Aspose.Slides?**

Aspose.Slides поддерживает широкий спектр [типов диаграмм](https://reference.aspose.com/slides/ru/php-java/aspose.slides/charttype/), включая столбчатые, линейные, круговые, областные, точечные, гистограммы, радиальные и многие другие. Эта гибкость позволяет выбрать наиболее подходящий тип диаграммы для ваших задач визуализации данных.

**Как добавить новую диаграмму на слайд?**

Чтобы добавить диаграмму, сначала создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/), получите нужный слайд по его индексу, а затем вызовите метод добавления диаграммы, указав тип диаграммы и начальные данные. Этот процесс интегрирует диаграмму непосредственно в вашу презентацию.

**Как обновить данные, отображаемые в диаграмме?**

Вы можете обновить данные диаграммы, получив доступ к её рабочей книге данных ([ChartDataWorkbook](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdataworkbook/)), очистив любые серии и категории по умолчанию, а затем добавив свои собственные данные. Это позволяет обновить диаграмму, чтобы она отражала актуальные данные.

**Можно ли настроить внешний вид диаграммы?**

Да, Aspose.Slides предоставляет обширные возможности настройки. Вы можете изменять цвета, шрифты, подписи, легенды и другие [элементы форматирования](/slides/ru/php-java/chart-entities/), чтобы адаптировать внешний вид диаграммы к вашим конкретным требованиям дизайна.