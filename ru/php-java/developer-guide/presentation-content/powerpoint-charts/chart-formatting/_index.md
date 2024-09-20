---
title: Форматирование диаграммы
type: docs
weight: 60
url: /php-java/chart-formatting/
---

## **Форматирование сущностей диаграммы**
Aspose.Slides для PHP через Java позволяет разработчикам добавлять настраиваемые диаграммы в слайды с нуля. В этой статье объясняется, как форматировать различные сущности диаграммы, включая категорию и ось значений диаграммы.

Aspose.Slides для PHP через Java предоставляет простой API для управления различными сущностями диаграммы и их форматирования с использованием пользовательских значений:

1. Создайте экземпляр класса [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию любого желаемого типа (в этом примере мы будем использовать ChartType::LineWithMarkers).
1. Получите доступ к оси значений диаграммы и установите следующие свойства:
   1. Установите **Формат линии** для основных горизонтальных линий оси значений.
   1. Установите **Формат линии** для второстепенных горизонтальных линий оси значений.
   1. Установите **Числовой формат** для оси значений.
   1. Установите **Минимальные, максимальные, основные и вспомогательные единицы** для оси значений.
   1. Установите **Свойства текста** для данных оси значений.
   1. Установите **Заголовок** для оси значений.
   1. Установите **Формат линии** для оси значений.
1. Получите доступ к оси категорий диаграммы и установите следующие свойства:
   1. Установите **Формат линии** для основных горизонтальных линий оси категорий.
   1. Установите **Формат линии** для второстепенных горизонтальных линий оси категорий.
   1. Установите **Свойства текста** для данных оси категорий.
   1. Установите **Заголовок** для оси категорий.
   1. Установите **Положение меток** для оси категорий.
   1. Установите **Угол поворота** для меток оси категорий.
1. Получите доступ к легенде диаграммы и установите **Свойства текста** для них.
1. Убедитесь, что легенды диаграммы не перекрываются с диаграммой.
1. Получите доступ к **Вторичной оси значений** диаграммы и установите следующие свойства:
   1. Включите вторичную **Ось значений**.
   1. Установите **Формат линии** для вторичной оси значений.
   1. Установите **Числовой формат** для вторичной оси значений.
   1. Установите **Минимальные, максимальные, основные и вспомогательные единицы** для вторичной оси значений.
1. Теперь постройте первую серию диаграмм на вторичной оси значений.
1. Установите цвет заливки задней стенки диаграммы.
1. Установите цвет заливки области построения диаграммы.
1. Запишите изменённую презентацию в файл PPTX.

```php
  # Создайте экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Получение первого слайда
    $slide = $pres->getSlides()->get_Item(0);
    # Добавление примера диаграммы
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 50, 50, 500, 400);
    # Установка заголовка диаграммы
    $chart->hasTitle();
    $chart->getChartTitle()->addTextFrameForOverriding("");
    $chartTitle = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $chartTitle->setText("Пример диаграммы");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Установка формата основных горизонтальных линий для оси значений
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    # Установка формата вспомогательных горизонтальных линий для оси значений
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Установка числового формата оси значений
    $chart->getAxes()->getVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Thousands);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.0%");
    # Установка максимальных и минимальных значений диаграммы
    $chart->getAxes()->getVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getVerticalAxis()->setMaxValue(15.0);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-2.0);
    $chart->getAxes()->getVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(2.0);
    # Установка свойств текста оси значений
    $txtVal = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $txtVal->setFontBold(NullableBool::True);
    $txtVal->setFontHeight(16);
    $txtVal->setFontItalic(NullableBool::True);
    $txtVal->getFillFormat()->setFillType(FillType::Solid);
    $txtVal->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkGreen));
    $txtVal->setLatinFont(new FontData("Times New Roman"));
    # Установка заголовка оси значений
    $chart->getAxes()->getVerticalAxis()->hasTitle();
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valtitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valtitle->setText("Первичная ось");
    $valtitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valtitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valtitle->getPortionFormat()->setFontHeight(20);
    $valtitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valtitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Установка формата основных горизонтальных линий для оси категорий
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    # Установка формата вспомогательных горизонтальных линий для оси категорий
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Установка свойств текста оси категорий
    $txtCat = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();
    $txtCat->setFontBold(NullableBool::True);
    $txtCat->setFontHeight(16);
    $txtCat->setFontItalic(NullableBool::True);
    $txtCat->getFillFormat()->setFillType(FillType::Solid);
    $txtCat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $txtCat->setLatinFont(new FontData("Arial"));
    # Установка заголовка категории
    $chart->getAxes()->getHorizontalAxis()->hasTitle();
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");
    $catTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $catTitle->setText("Пример категории");
    $catTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $catTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $catTitle->getPortionFormat()->setFontHeight(20);
    $catTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $catTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Установка положения меток оси категорий
    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    # Установка угла поворота меток оси категорий
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);
    # Установка свойств текста легенд
    $txtleg = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $txtleg->setFontBold(NullableBool::True);
    $txtleg->setFontHeight(16);
    $txtleg->setFontItalic(NullableBool::True);
    $txtleg->getFillFormat()->setFillType(FillType::Solid);
    $txtleg->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkRed));
    # Убедитесь, что легенды диаграммы не перекрываются с диаграммой
    $chart->getLegend()->setOverlay(true);
    # chart.ChartData.Series[0].PlotOnSecondAxis=true;
    $chart->getChartData()->getSeries()->get_Item(0)->setPlotOnSecondAxis(true);
    # Установка вторичной оси значений
    $chart->getAxes()->getSecondaryVerticalAxis()->isVisible();
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setStyle(LineStyle->ThickBetweenThin);
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setWidth(20);
    # Установка числового формата вторичной оси значений
    $chart->getAxes()->getSecondaryVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getSecondaryVerticalAxis()->setDisplayUnit(DisplayUnitType::Hundreds);
    $chart->getAxes()->getSecondaryVerticalAxis()->setNumberFormat("0.0%");
    # Установка максимальных и минимальных значений диаграммы
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->setMaxValue(20.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinValue(-5.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMajorUnit(2.0);
    # Установка цвета задней стенки диаграммы
    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Установка цвета области построения
    $chart->getPlotArea()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->LightCyan));
    # Сохранение презентации
    $pres->save("FormattedChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Установка свойств шрифта для диаграммы**
Aspose.Slides для PHP через Java предоставляет поддержку для установки свойств, связанных со шрифтом, для диаграммы. Пожалуйста, выполните следующие шаги для установки свойств шрифта для диаграммы.

- Создайте объект класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Добавьте диаграмму на слайд.
- Установите высоту шрифта.
- Сохраните изменённую презентацию.

Ниже приведён пример.

```php
  # Создайте экземпляр класса Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $pres->save("FontPropertiesForChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Установка формата чисел**
Aspose.Slides для PHP через Java предоставляет простой API для управления форматом данных диаграммы:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию любого желаемого типа (в этом примере используется **ChartType::ClusteredColumn**).
1. Установите заранее заданный числовой формат из возможных предустановленных значений.
1. Пройдитесь по ячейке данных диаграммы в каждой серии диаграммы и установите числовой формат данных диаграммы.
1. Сохраните презентацию.
1. Установите пользовательский числовой формат.
1. Пройдитесь по ячейке данных диаграммы внутри каждой серии диаграммы и установите другой числовой формат данных диаграммы.
1. Сохраните презентацию.

```php
  # Создайте экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Получите доступ к первому слайду презентации
    $slide = $pres->getSlides()->get_Item(0);
    # Добавление стандартной диаграммы с учётом группировки
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    # Получение коллекции серий диаграммы
    $series = $chart->getChartData()->getSeries();
    # Пройдитесь по каждой серии диаграмм
    foreach($series as $ser) {
      # Пройдитесь по каждой ячейке данных в серии
      foreach($ser->getDataPoints() as $cell) {
        # Установите числовой формат
        $cell->getValue()->getAsCell()->setPresetNumberFormat(10); // 0.00%

      }
    }
    # Сохранение презентации
    $pres->save("PresetNumberFormat.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Возможные значения предустановленного числового формата, вместе с их предустановленным индексом, которые могут быть использованы, приведены ниже:

|**0**|Общий|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Красный$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Красный$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Красный-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Красный-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **Установка закруглённых краёв области диаграммы**
Aspose.Slides для PHP через Java предоставляет поддержку для задания области диаграммы. Методы [**hasRoundedCorners**](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#hasRoundedCorners--) и [**setRoundedCorners**](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#setRoundedCorners-boolean-) были добавлены в интерфейс [IChart](https://reference.aspose.com/slides/php-java/aspose.slides/IChart) и класс [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/Chart). 

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Добавьте диаграмму на слайд.
1. Установите тип заливки и цвет заливки диаграммы.
1. Установите свойство скруглённых углов на True.
1. Сохраните изменённую презентацию.

Ниже приведён пример. 

```php
  # Создайте экземпляр класса Presentation
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getLineFormat()->setStyle(LineStyle->Single);
    $chart->setRoundedCorners(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```