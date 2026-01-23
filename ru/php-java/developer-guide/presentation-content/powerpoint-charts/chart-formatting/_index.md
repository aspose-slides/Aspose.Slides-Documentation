---
title: Форматирование диаграмм презентации в PHP
linktitle: Форматирование диаграмм
type: docs
weight: 60
url: /ru/php-java/chart-formatting/
keywords:
- форматировать диаграмму
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
description: "Изучите форматирование диаграмм в Aspose.Slides для PHP через Java и улучшите свою презентацию PowerPoint с профессиональным, привлекающим внимание оформлением."
---

## **Форматирование элементов диаграммы**
Aspose.Slides for PHP via Java позволяет разработчикам создавать пользовательские диаграммы на слайдах с нуля. В этой статье рассматривается, как форматировать различные элементы диаграммы, включая оси категорий и значений.

Aspose.Slides for PHP via Java предоставляет простой API для управления различными элементами диаграммы и их форматирования с использованием пользовательских значений:

1. Создайте экземпляр класса [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. Получите ссылку на слайд по его индексу.
3. Добавьте диаграмму с данными по умолчанию и выбранным типом (в этом примере используется ChartType::LineWithMarkers).
4. Получите доступ к оси значений диаграммы и задайте следующие свойства:
   1. Установка **Формат линии** для основных линий сетки оси значений
   2. Установка **Формат линии** для вспомогательных линий сетки оси значений
   3. Установка **Числовой формат** для оси значений
   4. Установка **Минимум, максимум, основной и вспомогательный шаг** для оси значений
   5. Установка **Свойства текста** для данных оси значений
   6. Установка **Заголовка** для оси значений
   7. Установка **Формат линии** для оси значений
5. Получите доступ к оси категорий диаграммы и задайте следующие свойства:
   1. Установка **Формат линии** для основных линий сетки оси категорий
   2. Установка **Формат линии** для вспомогательных линий сетки оси категорий
   3. Установка **Свойства текста** для данных оси категорий
   4. Установка **Заголовка** для оси категорий
   5. Установка **Позиционирования меток** для оси категорий
   6. Установка **Угла поворота** меток оси категорий
6. Получите доступ к легенде диаграммы и задайте **Свойства текста** для неё
7. Настройте отображение легенд диаграммы без перекрытия диаграммы
8. Получите доступ к **Вторичной оси значений** и задайте следующие свойства:
   1. Включите вторичную **Ось значений**
   2. Установка **Формат линии** для вторичной оси значений
   3. Установка **Числовой формат** для вторичной оси значений
   4. Установка **Минимум, максимум, основной и вспомогательный шаг** для вторичной оси значений
9. Постройте первую серию диаграммы по вторичной оси значений
10. Установите цвет заливки задней стенки диаграммы
11. Установите цвет заливки области построения диаграммы
12. Сохраните изменённую презентацию в файл PPTX
```php
  # Создать экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Получение первого слайда
    $slide = $pres->getSlides()->get_Item(0);
    # Добавление образца диаграммы
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
    # Установка формата основных линий сетки для оси значений
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    # Установка формата вспомогательных линий сетки для оси значений
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
    $valtitle->setText("Primary Axis");
    $valtitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valtitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valtitle->getPortionFormat()->setFontHeight(20);
    $valtitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valtitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Установка формата основных линий сетки для оси категорий
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    # Установка формата вспомогательных линий сетки для оси категорий
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
    $catTitle->setText("Sample Category");
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
    # Отображение легенд диаграммы без перекрытия диаграммы
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
Aspose.Slides for PHP via Java поддерживает настройку свойств шрифта для диаграммы. Следуйте приведённым ниже шагам для установки свойств шрифта диаграммы.

- Создайте объект класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
- Добавьте диаграмму на слайд.
- Установите высоту шрифта.
- Сохраните изменённую презентацию.

Ниже приведён пример.
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

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
2. Получите ссылку на слайд по его индексу.
3. Добавьте диаграмму с данными по умолчанию и выбранным типом (в этом примере используется **ChartType::ClusteredColumn**).
4. Установите предустановленный числовой формат из доступных значений.
5. Пройдитесь по каждому элементу данных в каждой серии диаграммы и задайте числовой формат данных диаграммы.
6. Сохраните презентацию.
7. Установите пользовательский числовой формат.
8. Пройдитесь по элементам данных в каждой серии диаграммы и задайте различный числовой формат данных диаграммы.
9. Сохраните презентацию.
```php
  # Создать экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Получить первый слайд презентации
    $slide = $pres->getSlides()->get_Item(0);
    # Добавить диаграмму с группированными колонками по умолчанию
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    # Доступ к коллекции серий диаграммы
    $series = $chart->getChartData()->getSeries();
    # Перебор всех серий диаграммы
    foreach($series as $ser) {
      # Перебор всех ячеек данных в серии
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


Возможные предустановленные значения числового формата вместе с их индексом указаны ниже:

|**0**|Общий|
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
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Установка скруглённых границ области диаграммы**
Aspose.Slides for PHP via Java поддерживает настройку области диаграммы. Методы [**hasRoundedCorners**](https://reference.aspose.com/slides/php-java/aspose.slides/chart/hasroundedcorners/) и [**setRoundedCorners**](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setroundedcorners/) добавлены в класс [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/Chart) .

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
2. Добавьте диаграмму на слайд.
3. Установите тип заливки и цвет заливки диаграммы
4. Установите свойство скруглённого угла в значение True.
5. Сохраните изменённую презентацию.

Ниже приведён пример.
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


## **FAQ**

**Можно ли установить полупрозрачные заливки для столбцов/областей, оставив границу непрозрачной?**

Да. Прозрачность заливки и обводка настраиваются отдельно. Это полезно для повышения читаемости сетки и данных в плотных визуализациях.

**Как поступить с метками данных, когда они перекрываются?**

Уменьшите размер шрифта, отключите несущественные компоненты меток (например, категории), измените смещение/позицию метки, при необходимости показывайте метки только для выбранных точек или переключите формат на “значение + легенда”.

**Можно ли применять градиентные или узорные заливки к сериям?**

Да. Обычно доступны как сплошные, так и градиентные/узорные заливки. На практике используйте градиенты умеренно и избегайте сочетаний, которые снижают контраст сетки и текста.