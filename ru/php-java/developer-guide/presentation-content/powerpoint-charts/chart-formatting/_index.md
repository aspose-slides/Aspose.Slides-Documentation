---
title: Форматирование диаграмм презентации в PHP
linktitle: Форматирование диаграмм
type: docs
weight: 60
url: /ru/php-java/chart-formatting/
keywords:
- формат диаграммы
- форматирование диаграмм
- элемент диаграммы
- свойства диаграммы
- настройки диаграммы
- опции диаграммы
- свойства шрифта
- скруглённая граница
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Изучите форматирование диаграмм в Aspose.Slides for PHP via Java и улучшите свою презентацию PowerPoint с помощью профессионального, привлекающего внимание оформления."
---

## **Форматирование элементов диаграммы**
Aspose.Slides for PHP via Java позволяет разработчикам добавлять пользовательские диаграммы в свои слайды с нуля. Эта статья объясняет, как форматировать различные элементы диаграммы, включая оси категорий и значений.

Aspose.Slides for PHP via Java предоставляет простой API для управления различными элементами диаграммы и их форматирования с использованием пользовательских значений:

1. Создать экземпляр класса [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получить ссылку на слайд по его индексу.
1. Добавить диаграмму с данными по умолчанию и желаемым типом (в этом примере мы используем ChartType::LineWithMarkers).
1. Получить доступ к оси значений диаграммы и задать следующие свойства:
   1. Установка **Line format** для основных линий сетки оси значений
   1. Установка **Line format** для вспомогательных линий сетки оси значений
   1. Установка **Number Format** для оси значений
   1. Установка **Min, Max, Major and Minor units** для оси значений
   1. Установка **Text Properties** для данных оси значений
   1. Установка **Title** для оси значений
   1. Установка **Line Format** для оси значений
1. Получить доступ к оси категорий диаграммы и задать следующие свойства:
   1. Установка **Line format** для основных линий сетки оси категорий
   1. Установка **Line format** для вспомогательных линий сетки оси категорий
   1. Установка **Text Properties** для данных оси категорий
   1. Установка **Title** для оси категорий
   1. Установка **Label Positioning** для оси категорий
   1. Установка **Rotation Angle** для меток оси категорий
1. Получить доступ к легенде диаграммы и задать для неё **Text Properties**.
1. Отобразить легенды диаграммы без наложения на диаграмму.
1. Получить доступ к **Secondary Value Axis** диаграммы и задать следующие свойства:
   1. Включить вторичную **Value Axis**
   1. Установка **Line Format** для вторичной оси значений
   1. Установка **Number Format** для вторичной оси значений
   1. Установка **Min, Max, Major and Minor units** для вторичной оси значений
1. Теперь построить первый ряд диаграммы на вторичной оси значений.
1. Установить цвет заполнения задней стены диаграммы.
1. Установить цвет заполнения области построения диаграммы.
1. Сохранить изменённую презентацию в файл PPTX.
```php
  # Создать экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Доступ к первому слайду
    $slide = $pres->getSlides()->get_Item(0);
    # Добавление примерной диаграммы
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 50, 50, 500, 400);
    # Установка заголовка диаграммы
    $chart->hasTitle();
    $chart->getChartTitle()->addTextFrameForOverriding("");
    $chartTitle = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $chartTitle->setText("Sample Chart");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Задание формата основных линий сетки для оси значений
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    # Задание формата вспомогательных линий сетки для оси значений
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Установка числового формата оси значений
    $chart->getAxes()->getVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Thousands);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.0%");
    # Задание максимальных и минимальных значений диаграммы
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
    $valtitle->setText("Primary Axis");
    $valtitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valtitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valtitle->getPortionFormat()->setFontHeight(20);
    $valtitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valtitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Задание формата основных линий сетки для оси категорий
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    # Задание формата вспомогательных линий сетки для оси категорий
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
    # Установка заголовка оси категорий
    $chart->getAxes()->getHorizontalAxis()->hasTitle();
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");
    $catTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $catTitle->setText("Sample Category");
    $catTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $catTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $catTitle->getPortionFormat()->setFontHeight(20);
    $catTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $catTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Задание положения меток оси категорий
    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    # Задание угла вращения меток оси категорий
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);
    # Установка свойств текста легенд
    $txtleg = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $txtleg->setFontBold(NullableBool::True);
    $txtleg->setFontHeight(16);
    $txtleg->setFontItalic(NullableBool::True);
    $txtleg->getFillFormat()->setFillType(FillType::Solid);
    $txtleg->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkRed));
    # Отображение легенд диаграммы без перекрытия диаграммы
    $chart->getLegend()->setOverlay(true);
    # chart.ChartData.Series[0].PlotOnSecondAxis=true;
    $chart->getChartData()->getSeries()->get_Item(0)->setPlotOnSecondAxis(true);
    # Задание вторичной оси значений
    $chart->getAxes()->getSecondaryVerticalAxis()->isVisible();
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setStyle(LineStyle->ThickBetweenThin);
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setWidth(20);
    # Установка числового формата вторичной оси значений
    $chart->getAxes()->getSecondaryVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getSecondaryVerticalAxis()->setDisplayUnit(DisplayUnitType::Hundreds);
    $chart->getAxes()->getSecondaryVerticalAxis()->setNumberFormat("0.0%");
    # Задание максимальных и минимальных значений диаграммы
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->setMaxValue(20.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinValue(-5.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMajorUnit(2.0);
    # Задание цвета задней стенки диаграммы
    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Задание цвета области построения
    $chart->getPlotArea()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->LightCyan));
    # Сохранить презентацию
    $pres->save("FormattedChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Установка свойств шрифта для диаграммы**
Aspose.Slides for PHP via Java предоставляет поддержку установки свойств шрифта для диаграммы. Пожалуйста, следуйте нижеуказанным шагам для установки свойств шрифта для диаграммы.

- Создать объект класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Добавить диаграмму на слайд.
- Установить высоту шрифта.
- Сохранить изменённую презентацию.

```php
  # Создать экземпляр класса Presentation
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


## **Установка числового формата**
Aspose.Slides for PHP via Java предоставляет простой API для управления форматом данных диаграммы:

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получить ссылку на слайд по его индексу.
1. Добавить диаграмму с данными по умолчанию и желаемым типом (в этом примере используется **ChartType::ClusteredColumn**).
1. Установить предустановленный числовой формат из возможных предустановленных значений.
1. Пройти по ячейкам данных диаграммы в каждом ряду диаграммы и установить числовой формат данных диаграммы.
1. Сохранить презентацию.
1. Установить пользовательский числовой формат.
1. Пройти по ячейкам данных диаграммы в каждом ряду диаграммы и задать разный числовой формат данных диаграммы.
1. Сохранить презентацию.

```php
  # Создать экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Доступ к первому слайду презентации
    $slide = $pres->getSlides()->get_Item(0);
    # Добавление диаграммы кластерных столбцов по умолчанию
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    # Получение коллекции рядов диаграммы
    $series = $chart->getChartData()->getSeries();
    # Перебор всех рядов диаграммы
    foreach($series as $ser) {
      # Перебор всех ячеек данных в ряду
      foreach($ser->getDataPoints() as $cell) {
        # Установка числового формата
        $cell->getValue()->getAsCell()->setPresetNumberFormat(10);// 0.00%

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


Возможные значения предустановленного числового формата вместе с их индексом, которые можно использовать, приведены ниже:

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
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
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **Установка скруглённых границ области диаграммы**
Aspose.Slides for PHP via Java предоставляет поддержку установки области диаграммы. Методы [**hasRoundedCorners**](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#hasRoundedCorners--) и [**setRoundedCorners**](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#setRoundedCorners-boolean-) были добавлены в интерфейс [IChart](https://reference.aspose.com/slides/php-java/aspose.slides/IChart) и класс [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/Chart).

1. Создать объект класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Добавить диаграмму на слайд.
1. Установить тип заливки и цвет заливки диаграммы.
1. Установить свойство скруглённых углов в значение True.
1. Сохранить изменённую презентацию.

```php
  # Создать экземпляр класса Presentation
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


## **Часто задаваемые вопросы**

**Могу ли я задать полупрозрачные заливки для столбцов/областей, сохранив границу непрозрачной?**

Да. Прозрачность заливки и контур настраиваются отдельно. Это полезно для повышения читаемости сетки и данных в плотных визуализациях.

**Как справиться с метками данных, когда они перекрываются?**

Уменьшить размер шрифта, отключить необязательные компоненты меток (например, категории), задать смещение/позицию метки, при необходимости показывать метки только для выбранных точек или переключить формат на «значение + легенда».

**Можно ли применять градиентные или шаблонные заливки к рядам?**

Да. Как сплошные, так и градиентные/шаблонные заливки обычно доступны. На практике используйте градиенты экономно и избегайте комбинаций, снижающих контраст сетки и текста.