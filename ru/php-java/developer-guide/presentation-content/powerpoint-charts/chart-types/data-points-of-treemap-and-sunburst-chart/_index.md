---
title: Настройка точек данных в диаграммах Treemap и Sunburst с помощью PHP
linktitle: Точки данных в диаграммах Treemap и Sunburst
type: docs
url: /ru/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- диаграмма treemap
- диаграмма sunburst
- точка данных
- цвет подписи
- цвет ветки
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как управлять точками данных в диаграммах Treemap и Sunburst с помощью Aspose.Slides for PHP via Java, совместимыми с форматами PowerPoint."
---

Среди других типов диаграмм PowerPoint есть два «иерархических» типа — **Treemap** и **Sunburst** (также известные как Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph или Multi Level Pie Chart). Эти диаграммы отображают иерархические данные, организованные в виде дерева — от листьев к вершине ветки. Листья определяются точками данных серии, а каждый последующий уровень вложенной группировки определяется соответствующей категорией. Aspose.Slides for PHP via Java позволяет форматировать точки данных диаграмм Sunburst и Treemap.

Ниже представлена диаграмма Sunburst, где данные в колонке Series1 определяют листовые узлы, а остальные колонки определяют иерархические точки данных:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Начнём с добавления новой диаграммы Sunburst в презентацию:
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


{{% alert color="primary" title="См. также" %}} 
- [**Создание или обновление диаграмм PowerPoint в PHP**](/slides/ru/php-java/create-chart/)
{{% /alert %}}

Если необходимо форматировать точки данных диаграммы, следует использовать следующее:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointlevelsmanager/), [**ChartDataPointLevel**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointlevel/) классы и метод [**ChartDataPoint::getDataPointLevels**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) предоставляют доступ к форматированию точек данных диаграмм Treemap и Sunburst.  
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointlevelsmanager/) используется для доступа к многоуровневым категориям — он представляет контейнер объектов [**ChartDataPointLevel**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointlevel/).... По сути это оболочка для [**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategorylevelsmanager/) с свойствами, добавленными специально для точек данных.  
Класс [**ChartDataPointLevel**] имеет два метода: [**getFormat**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointlevel/#getFormat) и [**getDataLabel**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointlevel/#getLabel), которые предоставляют доступ к соответствующим настройкам.

## **Отображение значения точки данных**
Показать значение точки данных «Leaf 4»:
```php
  $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
  $dataPoints->get_Item(3)->getDataPointLevels()->get_Item(0)->getLabel()->getDataLabelFormat()->setShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Установка подписи и цвета точки данных**
Установить подпись точки данных «Branch 1», чтобы отображалось имя серии («Series1») вместо имени категории. Затем установить цвет текста в желтый:
```php
  $branch1Label = $dataPoints->get_Item(0)->getDataPointLevels()->get_Item(0)->getLabel();
  $branch1Label->getDataLabelFormat()->setShowCategoryName(false);
  $branch1Label->getDataLabelFormat()->setShowSeriesName(true);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Установка цвета ветки точки данных**
Изменить цвет ветки «Steam 4»:
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
Нет. PowerPoint сортирует сегменты автоматически (обычно по убыванию значений, по часовой стрелке). Aspose.Slides повторяет это поведение: изменить порядок напрямую нельзя; его можно изменить только предобработкой данных.

**Как тема презентации влияет на цвета сегментов и подписей?**  
Цвета диаграммы наследуют [тему/палитру](/slides/ru/php-java/presentation-theme/) презентации, если явно не задать заполнения/шрифты. Для согласованных результатов фиксируйте сплошные заполнения и форматирование текста на нужных уровнях.

**Сохранит ли экспорт в PDF/PNG пользовательские цвета веток и настройки подписей?**  
Да. При экспорте презентации настройки диаграммы (заполнения, подписи) сохраняются в выходных форматах, так как Aspose.Slides рендерит с применённым форматированием диаграммы.

**Могу ли я вычислить фактические координаты подписи/элемента для пользовательского наложения поверх диаграммы?**  
Да. После проверки разметки диаграммы доступны фактические *x* и *y* для элементов (например, для [DataLabel](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/)), что упрощает точное позиционирование наложений.