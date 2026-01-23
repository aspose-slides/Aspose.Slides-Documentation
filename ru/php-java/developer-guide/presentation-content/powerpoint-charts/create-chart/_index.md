---
title: Создание или обновление диаграмм PowerPoint в PHP
linktitle: Создать или обновить диаграммы
type: docs
weight: 10
url: /ru/php-java/create-chart/
keywords:
- добавить диаграмму
- создать диаграмму
- редактировать диаграмму
- изменить диаграмму
- обновить диаграмму
- разбросанная диаграмма
- круговая диаграмма
- линейная диаграмма
- диаграмма Tree Map
- диаграмма акций
- коробчатая диаграмма
- воронкообразная диаграмма
- диаграмма Sunburst
- гистограмма
- радиальная диаграмма
- многокатегориальная диаграмма
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Создавайте и настраивайте диаграммы в презентациях PowerPoint с помощью Aspose.Slides для PHP через Java. Добавляйте, форматируйте и редактируйте диаграммы с практическими примерами кода."
---

## **Обзор**

В этой статье описывается, как **создавать диаграммы PowerPoint Presentation на Java**. Вы также можете **обновлять диаграммы**. Рассмотрены следующие темы.

_Диаграмма_: **Normal**
- [Java Create PowerPoint Chart](#java-create-powerpoint-chart)
- [Java Create Presentation Chart](#java-create-presentation-chart)
- [Java Create PowerPoint Presentation Chart](#java-create-powerpoint-presentation-chart)

_Диаграмма_: **Scattered**
- [Java Create Scattered Chart](#java-create-scattered-chart)
- [Java Create PowerPoint Scattered Chart](#java-create-powerpoint-scattered-chart)
- [Java Create PowerPoint Presentation Scattered Chart](#java-create-powerpoint-presentation-scattered-chart)

_Диаграмма_: **Pie**
- [Java Create Pie Chart](#java-create-pie-chart)
- [Java Create PowerPoint Pie Chart](#java-create-powerpoint-pie-chart)
- [Java Create PowerPoint Presentation Pie Chart](#java-create-powerpoint-presentation-pie-chart)

_Диаграмма_: **Tree Map**
- [Java Create Tree Map Chart](#java-create-tree-map-chart)
- [Java Create PowerPoint Tree Map Chart](#java-create-powerpoint-tree-map-chart)
- [Java Create PowerPoint Presentation Tree Map Chart](#java-create-powerpoint-presentation-tree-map-chart)

_Диаграмма_: **Stock**
- [Java Create Stock Chart](#java-create-stock-chart)
- [Java Create PowerPoint Stock Chart](#java-create-powerpoint-stock-chart)
- [Java Create PowerPoint Presentation Stock Chart](#java-create-powerpoint-presentation-stock-chart)

_Диаграмма_: **Box and Whisker**
- [Java Create Box and Whisker Chart](#java-create-box-and-whisker-chart)
- [Java Create PowerPoint Box and Whisker Chart](#java-create-powerpoint-box-and-whisker-chart)
- [Java Create PowerPoint Presentation Box and Whisker Chart](#java-create-powerpoint-presentation-box-and-whisker-chart)

_Диаграмма_: **Funnel**
- [Java Create Funnel Chart](#java-create-funnel-chart)
- [Java Create PowerPoint Funnel Chart](#java-create-powerpoint-funnel-chart)
- [Java Create PowerPoint Presentation Funnel Chart](#java-create-powerpoint-presentation-funnel-chart)

_Диаграмма_: **Sunburst**
- [Java Create Sunburst Chart](#java-create-sunburst-chart)
- [Java Create PowerPoint Sunburst Chart](#java-create-powerpoint-sunburst-chart)
- [Java Create PowerPoint Presentation Sunburst Chart](#java-create-powerpoint-presentation-sunburst-chart)

_Диаграмма_: **Histogram**
- [Java Create Histogram Chart](#java-create-histogram-chart)
- [Java Create PowerPoint Histogram Chart](#java-create-powerpoint-histogram-chart)
- [Java Create PowerPoint Presentation Histogram Chart](#java-create-powerpoint-presentation-histogram-chart)

_Диаграмма_: **Radar**
- [Java Create Radar Chart](#java-create-radar-chart)
- [Java Create PowerPoint Radar Chart](#java-create-powerpoint-radar-chart)
- [Java Create PowerPoint Presentation Radar Chart](#java-create-powerpoint-presentation-radar-chart)

_Диаграмма_: **Multi Category**
- [Java Create Multi Category Chart](#java-create-multi-category-chart)
- [Java Create PowerPoint Multi Category Chart](#java-create-powerpoint-multi-category-chart)
- [Java Create PowerPoint Presentation Multi Category Chart](#java-create-powerpoint-presentation-multi-category-chart)

_Диаграмма_: **Map**
- [Java Create Map Chart](#java-create-map-chart)
- [Java Create PowerPoint Map Chart](#java-create-powerpoint-map-chart)
- [Java Create PowerPoint Presentation Map Chart](#java-create-powerpoint-presentation-map-chart)

_Действие_: **Update Chart**
- [Java Update PowerPoint Chart](#java-update-powerpoint-chart)
- [Java Update Presentation Chart](#java-update-presentation-chart)
- [Java Update PowerPoint Presentation Chart](#java-update-powerpoint-presentation-chart)


## **Создание диаграммы**
Диаграммы помогают быстро визуализировать данные и получать инсайты, которые могут быть не очевидны из таблицы или электронной таблицы. 


**Зачем создавать диаграммы?**

Используя диаграммы, вы можете

* агрегировать, уплотнять или суммировать большие объёмы данных на одном слайде презентации
* выявлять шаблоны и тенденции в данных
* определять направление и динамику данных во времени или относительно конкретной единицы измерения 
* обнаруживать выбросы, аномалии, отклонения, ошибки, бессмысленные данные и т.д. 
* эффективно передавать или представлять сложные данные

В PowerPoint диаграммы создаются через функцию вставки, которая предоставляет шаблоны для построения множества типов диаграмм. С помощью Aspose.Slides вы можете создавать обычные диаграммы (на основе популярных типов) и пользовательские диаграммы. 

{{% alert color="primary" %}} 

Чтобы вы могли создавать диаграммы, Aspose.Slides предоставляет класс [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType). Поля этого класса соответствуют различным типам диаграмм.

{{% /alert %}} 

### **Создание обычных диаграмм**

_Шаги: Создать диаграмму_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Шаги:</em> Создать диаграмму PowerPoint </strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Шаги:</em> Создать диаграмму Presentation </strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Шаги:</em> Создать диаграмму PowerPoint Presentation </strong></a>

_Кодовые шаги:_

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получить ссылку на слайд по его индексу.
3. Добавить диаграмму с некоторыми данными и указать предпочтительный тип диаграммы. 
4. Добавить заголовок к диаграмме. 
5. Доступ к рабочему листу данных диаграммы. 
6. Очистить все серии и категории по умолчанию. 
7. Добавить новые серии и категории. 
8. Добавить новые данные к сериям диаграммы. 
9. Указать цвет заливки для серии. 
10. Добавить подписи к сериям. 
11. Сохранить изменённую презентацию как файл PPTX. 

Этот PHP‑код демонстрирует, как создать обычную диаграмму:
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
    # Настраивает первую серию для отображения значений
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Устанавливает индекс листа данных диаграммы
    $defaultWorksheetIndex = 0;
    # Получает лист данных диаграммы
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Удаляет серию и категории, сгенерированные по умолчанию
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $s = $chart->getChartData()->getSeries()->size();
    $s = $chart->getChartData()->getCategories()->size();
    # Добавляет новые серии
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Добавляет новые категории
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Берёт первую серию диаграммы
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Заполняет данные серии
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Устанавливает цвет заливки для серии
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Берёт вторую серию диаграммы
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Заполняет данные серии
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Устанавливает цвет заливки для серии
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Создаёт пользовательские подписи для каждой категории новой серии
    # Настраивает первую подпись для отображения имени категории
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


### **Создание разбросанных диаграмм**
Разбросанные диаграммы (также известные как scatter‑plots или графики x‑y) часто используются для проверки шаблонов или демонстрации корреляций между двумя переменными. 

Вы можете использовать разбросанную диаграмму, когда 

* у вас есть парные числовые данные
* у вас есть 2 переменные, хорошо сочетающиеся друг с другом
* вы хотите определить, связаны ли 2 переменные
* у вас есть независимая переменная с множеством значений для зависимой переменной

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Шаги:</em> Создать разбросанную диаграмму </strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Шаги:</em> Создать разбросанную диаграмму PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Шаги:</em> Создать разбросанную диаграмму PowerPoint Presentation </strong></a>

1. Пожалуйста, следуйте шагам, описанным выше в разделе [Создание обычных диаграмм](#creating-normal-charts)
2. На третьем шаге добавьте диаграмму с данными и укажите тип диаграммы как один из следующих
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithMarkers) - _Представляет разбросанную диаграмму с маркерами._
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Разбросанная диаграмма, соединённая кривыми, с маркерами данных._
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Разбросанная диаграмма, соединённая кривыми, без маркеров данных._
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Разбросанная диаграмма, соединённая прямыми линиями, с маркерами данных._
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Разбросанная диаграмма, соединённая прямыми линиями, без маркеров данных._

Этот PHP‑код демонстрирует, как создать разбросанные диаграммы с разными типами маркеров:
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
    # Получает лист данных диаграммы
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Удаляет демонстрационную серию
    $chart->getChartData()->getSeries()->clear();
    # Добавляет новые серии
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 3, "Series 2"), $chart->getType());
    # Берёт первую серию диаграммы
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Добавляет новую точку (1:3) в серию
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 1), $fact->getCell($defaultWorksheetIndex, 2, 2, 3));
    # Добавляет новую точку (2:10)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 2), $fact->getCell($defaultWorksheetIndex, 3, 2, 10));
    # Изменяет тип серии
    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);
    # Изменяет маркер серии диаграммы
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);
    # Берёт вторую серию диаграммы
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Добавляет новую точку (5:2) туда
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 5), $fact->getCell($defaultWorksheetIndex, 2, 4, 2));
    # Добавляет новую точку (3:1)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 3), $fact->getCell($defaultWorksheetIndex, 3, 4, 1));
    # Добавляет новую точку (2:2)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 4, 3, 2), $fact->getCell($defaultWorksheetIndex, 4, 4, 2));
    # Добавляет новую точку (5:1)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 5, 3, 5), $fact->getCell($defaultWorksheetIndex, 5, 4, 1));
    # Изменяет маркер серии диаграммы
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

Круговые диаграммы лучше всего показывают соотношение части к целому, особенно когда данные содержат категориальные метки с численными значениями. Однако если в данных слишком много частей или меток, возможно, стоит использовать столбчатую диаграмму.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Шаги:</em> Создать круговую диаграмму </strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Шаги:</em> Создать круговую диаграмму PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Шаги:</em> Создать круговую диаграмму PowerPoint Presentation </strong></a>

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получить ссылку на слайд по его индексу.
3. Добавить диаграмму с данными по умолчанию и нужным типом (в данном случае [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).Pie).
4. Доступ к [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/).
5. Очистить серии и категории по умолчанию.
6. Добавить новые серии и категории.
7. Добавить новые данные к сериям.
8. Добавить новые точки и задать пользовательские цвета секторов круговой диаграммы.
9. Установить подписи для серий.
10. Установить линии‑выноски для подписей серий.
11. Установить угол поворота для слайдов с круговой диаграммой.
12. Сохранить изменённую презентацию в файл PPTX.

Этот PHP‑код демонстрирует, как создать круговую диаграмму:
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
    # Настраивает первую серию для отображения значений
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Устанавливает индекс листа данных диаграммы
    $defaultWorksheetIndex = 0;
    # Получает лист данных диаграммы
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Удаляет автоматически сгенерированные серии и категории
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Добавляет новые категории
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # Добавляет новые серии
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # Заполняет данные серии
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Не работает в новой версии
    # Добавление новых точек и задание цвета секторов
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
    # Создаёт пользовательские подписи для каждой категории новой серии
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
    # Показывает линии‑выноски для диаграммы
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

Линейные диаграммы (также известные как линейные графики) лучше всего подходят для демонстрации изменений значения во времени. С их помощью можно сравнивать большие объёмы данных, отслеживать изменения и тенденции, выделять аномалии в рядах данных и т.д.

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получить ссылку на слайд по его индексу.
1. Добавить диаграмму с данными по умолчанию и типом `ChartType::Line`.
1. Доступ к IChartDataWorkbook.
1. Очистить серии и категории по умолчанию.
1. Добавить новые серии и категории.
1. Добавить новые данные к сериям.
1. Сохранить изменённую презентацию в файл PPTX.

Этот PHP‑код демонстрирует, как создать линейную диаграмму:
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


По умолчанию точки линейной диаграммы соединяются сплошными прямыми. Если нужно соединить их пунктиром, укажите желаемый тип пунктирной линии так:
```php
  $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
  foreach($lineChart->getChartData()->getSeries() as $series) {
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Dash);
  }
```


### **Создание диаграмм Tree Map**

Диаграммы Tree Map лучше всего подходят для данных продаж, когда необходимо показать относительный размер категорий и одновременно быстро привлечь внимание к крупным вносителям в каждой категории. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Шаги:</em> Создать диаграмму Tree Map </strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Шаги:</em> Создать диаграмму Tree Map PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Шаги:</em> Создать диаграмму Tree Map PowerPoint Presentation </strong></a>

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
2. Получить ссылку на слайд по его индексу.
3. Добавить диаграмму с данными по умолчанию и типом [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).TreeMap.
4. Доступ к [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/).
5. Очистить серии и категории по умолчанию.
6. Добавить новые серии и категории.
7. Добавить новые данные к сериям.
8. Сохранить изменённую презентацию в файл PPTX.

Этот PHP‑код демонстрирует, как создать диаграмму Tree Map:
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


### **Создание диаграмм Stock**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Шаги:</em> Создать диаграмму Stock </strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Шаги:</em> Создать диаграмму Stock PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Шаги:</em> Создать диаграмму Stock PowerPoint Presentation </strong></a>

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
2. Получить ссылку на слайд по его индексу.
3. Добавить диаграмму с данными по умолчанию и типом ([ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).OpenHighLowClose).
4. Доступ к [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/).
5. Очистить серии и категории по умолчанию.
6. Добавить новые серии и категории.
7. Добавить новые данные к сериям.
8. Указать формат HiLowLines.
9. Сохранить изменённую презентацию в файл PPTX.

Пример PHP‑кода для создания диаграммы Stock:
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
    foreach($chart->getChartData()->getSeries() as $ser) {
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

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Шаги:</em> Создать диаграмму Box and Whisker </strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Шаги:</em> Создать диаграмму Box and Whisker PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Шаги:</em> Создать диаграмму Box and Whisker PowerPoint Presentation </strong></a>

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
2. Получить ссылку на слайд по его индексу.
3. Добавить диаграмму с данными по умолчанию и типом ([ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).BoxAndWhisker).
4. Доступ к [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/).
5. Очистить серии и категории по умолчанию.
6. Добавить новые серии и категории.
7. Добавить новые данные к сериям.
8. Сохранить изменённую презентацию в файл PPTX.

Этот PHP‑код демонстрирует, как создать диаграмму Box and Whisker:
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


### **Создание диаграмм Funnel**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Шаги:</em> Создать диаграмму Funnel </strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Шаги:</em> Создать диаграмму Funnel PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Шаги:</em> Создать диаграмму Funnel PowerPoint Presentation </strong></a>


1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
2. Получить ссылку на слайд по его индексу.
3. Добавить диаграмму с данными по умолчанию и типом ([ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).Funnel).
4. Сохранить изменённую презентацию в файл PPTX.

PHP‑код, показывающий, как создать диаграмму Funnel:
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


### **Создание диаграмм Sunburst**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Шаги:</em> Создать диаграмму Sunburst </strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Шаги:</em> Создать диаграмму Sunburst PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Шаги:</em> Создать диаграмму Sunburst PowerPoint Presentation </strong></a>

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
2. Получить ссылку на слайд по его индексу.
3. Добавить диаграмму с данными по умолчанию и типом (в данном случае [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).sunburst).
4. Сохранить изменённую презентацию в файл PPTX.

Этот PHP‑код демонстрирует, как создать диаграмму Sunburst:
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

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Шаги:</em> Создать гистограмму </strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Шаги:</em> Создать гистограмму PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Шаги:</em> Создать гистограмму PowerPoint Presentation </strong></a>

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
2. Получить ссылку на слайд по его индексу.
3. Добавить диаграмму с данными по умолчанию и типом ([ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).Histogram).
4. Доступ к [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/).
5. Очистить серии и категории по умолчанию.
6. Добавить новые серии и категории.
7. Сохранить изменённую презентацию в файл PPTX.

Этот PHP‑код демонстрирует, как создать гистограмму:
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

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Шаги:</em> Создать радиальную диаграмму </strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Шаги:</em> Создать радиальную диаграмму PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Шаги:</em> Создать радиальную диаграмму PowerPoint Presentation </strong></a>

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
2. Получить ссылку на слайд по его индексу. 
3. Добавить диаграмму с данными и указать тип `ChartType::Radar`.
4. Сохранить изменённую презентацию в файл PPTX.

Этот PHP‑код демонстрирует, как создать радиальную диаграмму:
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


### **Создание многокатегориальных диаграмм**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Шаги:</em> Создать многокатегориальную диаграмму </strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Шаги:</em> Создать многокатегориальную диаграмму PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Шаги:</em> Создать многокатегориальную диаграмму PowerPoint Presentation </strong></a>

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
2. Получить ссылку на слайд по его индексу. 
3. Добавить диаграмму с данными по умолчанию и типом ([ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).ClusteredColumn).
4. Доступ к [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/).
5. Очистить серии и категории по умолчанию.
6. Добавить новые серии и категории.
7. Добавить новые данные к сериям.
8. Сохранить изменённую презентацию в файл PPTX.

Этот PHP‑код демонстрирует, как создать многокатегориальную диаграмму:
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
    # Добавление серии
    $series = $ch->getChartData()->getSeries()->add($fact->getCell(0, "D1", "Series 1"), ChartType::ClusteredColumn);
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D2", 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D3", 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D4", 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D5", 40));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D6", 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D7", 60));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D8", 70));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D9", 80));
    # Сохранить презентацию с диаграммой
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Создание картографических диаграмм**

Картографическая диаграмма визуализирует область, содержащую данные. Такие диаграммы лучше всего использовать для сравнения данных или значений по географическим регионам.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Шаги:</em> Создать картографическую диаграмму </strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Шаги:</em> Создать картографическую диаграмму PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Шаги:</em> Создать картографическую диаграмму PowerPoint Presentation </strong></a>

Этот PHP‑код демонстрирует, как создать картографическую диаграмму:
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

Комбинированная диаграмма (или combo‑chart) объединяет два или более типов диаграмм в одном графике. Такая диаграмма позволяет выделять, сравнивать или изучать различия между несколькими наборами данных, помогая выявлять взаимосвязи.

![The combination chart](combination_chart.png)

Следующий PHP‑код показывает, как создать комбинированную диаграмму, показанную выше, в презентации PowerPoint:
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

    // Удалить автоматически сгенерированные серии и категории.
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $worksheetIndex = 0;
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    // Добавить новые категории.
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 3, 0, "Category 3"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 4, 0, "Category 4"));

    // Добавить первую серию.
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

    // Установить цвет основных линий сетки по вертикали.
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

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Шаги:</em> Обновить диаграмму PowerPoint </strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Шаги:</em> Обновить диаграмму Presentation </strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Шаги:</em> Обновить диаграмму PowerPoint Presentation </strong></a>

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), представляющего презентацию, содержащую диаграмму, которую необходимо обновить.
2. Получить ссылку на нужный слайд, используя его индекс.
3. Пройтись по всем фигурам, чтобы найти требуемую диаграмму.
4. Доступ к рабочему листу данных диаграммы.
5. Изменить данные серии, изменив значения серии.
6. Добавить новую серию и заполнить её данными.
7. Сохранить изменённую презентацию в файл PPTX.

Этот PHP‑код демонстрирует, как обновить диаграмму:
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
    # Выбор первой серии диаграммы
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Обновление данных серии
    $fact->getCell($defaultWorksheetIndex, 0, 1, "New_Series1");// Изменение имени серии

    $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(44);
    # Выбор второй серии диаграммы
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Обновление данных серии
    $fact->getCell($defaultWorksheetIndex, 0, 2, "New_Series2");// Изменение имени серии

    $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(99);
    # Добавление новой серии
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 3, "Series 3"), $chart->getType());
    # Выбор третьей серии диаграммы
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    # Заполнение данных серии
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 3, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 30));
    $chart->setType(ChartType::ClusteredCylinder);
    # Сохранение презентации с диаграммой
    $pres->save("AsposeChartModified_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Установка диапазона данных для диаграммы**

Чтобы установить диапазон данных для диаграммы, выполните следующее:

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), представляющего презентацию с диаграммой.
2. Получить ссылку на слайд по его индексу.
3. Пройтись по всем фигурам, чтобы найти требуемую диаграмму.
4. Доступ к данным диаграммы и установка диапазона.
5. Сохранить изменённую презентацию в файл PPTX.

Этот PHP‑код демонстрирует, как установить диапазон данных для диаграммы:
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
При использовании стандартного маркера в диаграммах каждая серия получает автоматически разные маркеры по умолчанию.

Этот PHP‑код показывает, как автоматически задать маркеры сериям диаграммы:
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
    # Выбираем вторую серию диаграммы
    $series2 = $chart->getChartData()->getSeries()->get_Item(1);
    # Теперь заполняем данные серии
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

Aspose.Slides поддерживает широкий спектр [типов диаграмм](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/), включая столбчатые, линейные, круговые, областные, разбросанные, гистограммы, радиальные и многие другие. Это позволяет выбрать оптимальный тип диаграммы для ваших задач визуализации данных.

**Как добавить новую диаграмму на слайд?**

Чтобы добавить диаграмму, сначала создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), получите нужный слайд по индексу, а затем вызовите метод добавления диаграммы, указав тип диаграммы и начальные данные. Таким образом диаграмма интегрируется непосредственно в вашу презентацию.

**Как обновить данные, отображаемые в диаграмме?**

Вы можете обновить данные диаграммы, получив доступ к её рабочему листу ([ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/)), очистив любые серии и категории по умолчанию и добавив свои собственные данные. Это позволяет освежить диаграмму в соответствии с актуальными данными.

**Можно ли настроить внешний вид диаграммы?**

Да, Aspose.Slides предоставляет обширные возможности настройки. Вы можете менять цвета, шрифты, подписи, легенды и другие [элементы форматирования](/slides/ru/php-java/chart-entities/), адаптируя внешний вид диаграммы под конкретные требования дизайна.