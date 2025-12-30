---
title: Настройка точек данных в диаграммах Treemap и Sunburst с использованием PHP
linktitle: Точки данных в диаграммах Treemap и Sunburst
type: docs
url: /ru/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- диаграмма Treemap
- диаграмма Sunburst
- точка данных
- цвет метки
- цвет ветки
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как управлять точками данных в диаграммах Treemap и Sunburst с помощью Aspose.Slides for PHP via Java, совместимо с форматами PowerPoint."
---

Среди прочих типов диаграмм PowerPoint существуют два «иерархических» типа — **Treemap** и **Sunburst** (также известные как Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph или Multi Level Pie Chart). Эти диаграммы отображают иерархические данные, организованные в виде дерева — от листьев к вершине ветви. Листья определяются точками данных серии, а каждый последующий уровень вложенной группы определяется соответствующей категорией. Aspose.Slides for PHP via Java позволяет форматировать точки данных диаграмм Sunburst и Treemap.

Here is a Sunburst Chart, where data in Series1 column define the leaf nodes, while other columns define hierarchical datapoints:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Let’s start with adding a new Sunburst chart to the presentation:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" title="Смотрите также" %}} 
- [**Создание диаграммы Sunburst**](/slides/ru/php-java/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

If there is a need to format data points of the chart, we should use the following:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevelsManager),
[IChartDataPointLevel](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel) классы
и [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPoint#getDataPointLevels--) метод
обеспечивают доступ к форматированию точек данных диаграмм Treemap и Sunburst.
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevelsManager)
используется для доступа к многоуровневым категориям — он представляет контейнер
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartCategoryLevelsManager) с
свойствами, добавленными специально для точек данных.
Класс [**IChartDataPointLevel**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel)
имеет два метода: [**getFormat**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel#getFormat--) и
[**getDataLabel**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel#getLabel--) которые
обеспечивают доступ к соответствующим настройкам.

## **Показать значение точки данных**
Show value of "Leaf 4" data point:
```php
  $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
  $dataPoints->get_Item(3)->getDataPointLevels()->get_Item(0)->getLabel()->getDataLabelFormat()->setShowValue(true);

```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Установить метку и цвет точки данных**
Set "Branch 1" data label to show series name ("Series1") instead of category name. Then set text color to yellow:
```php
  $branch1Label = $dataPoints->get_Item(0)->getDataPointLevels()->get_Item(0)->getLabel();
  $branch1Label->getDataLabelFormat()->setShowCategoryName(false);
  $branch1Label->getDataLabelFormat()->setShowSeriesName(true);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Установить цвет ветви точки данных**
Change color of "Steam 4" branch:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
    $stem4branch = $dataPoints->get_Item(9)->getDataPointLevels()->get_Item(1);
    $stem4branch->getFormat()->getFill()->setFillType(FillType::Solid);
    $stem4branch->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **Часто задаваемые вопросы**

**Могу ли я изменить порядок (сортировку) сегментов в Sunburst/Treemap?**

Нет. PowerPoint сортирует сегменты автоматически (обычно по убывающим значениям, по часовой стрелке). Aspose.Slides отражает это поведение: изменить порядок напрямую нельзя; его можно добиться, предварительно обработав данные.

**Как тема презентации влияет на цвета сегментов и меток?**

Цвета диаграмм наследуют [тема/палитра](/slides/ru/php-java/presentation-theme/) презентации, если вы явно не задаёте заливки/шрифты. Для согласованных результатов фиксируйте сплошные заливки и форматирование текста на требуемых уровнях.

**Сохранит ли экспорт в PDF/PNG пользовательские цвета ветвей и настройки меток?**

Да. При экспортировании презентации настройки диаграммы (заливки, метки) сохраняются в выходных форматах, поскольку Aspose.Slides рендерит их с применённым форматированием.

**Могу ли я вычислить фактические координаты метки/элемента для пользовательского наложения поверх диаграммы?**

Да. После того как макет диаграммы проверен, доступны фактические *x* и *y* для элементов (например, [DataLabel](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/)), что помогает точно позиционировать накладки.