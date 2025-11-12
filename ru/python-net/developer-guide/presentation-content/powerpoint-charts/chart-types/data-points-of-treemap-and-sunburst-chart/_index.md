---
title: Настройка точек данных в иерархических диаграммах Treemap и Sunburst в Python
linktitle: Точки данных в диаграммах Treemap и Sunburst
type: docs
url: /ru/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- диаграмма Treemap
- диаграмма Sunburst
- точка данных
- цвет подписи
- цвет ветки
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как управлять точками данных в диаграммах Treemap и Sunburst с помощью Aspose.Slides для Python через .NET, совместимых с форматами PowerPoint и OpenDocument."
---

## **Введение**

Помимо других типов диаграмм PowerPoint, существуют два иерархических типа — **Treemap** и **Sunburst** (также известные как Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph или Multi-Level Pie Chart). Эти диаграммы отображают иерархические данные, организованные в виде дерева — от листьев к вершине ветви. Листья задаются точками данных серии, а каждый последующий уровень группировки определяется соответствующей категорией. Aspose.Slides для Python через .NET позволяет формировать точки данных диаграмм Sunburst и Treemap в Python.

Ниже приведён пример диаграммы Sunburst, где данные в столбце Series1 задают листовые узлы, а остальные столбцы — иерархические точки данных:

![Sunburst chart example](sunburst_example.png)

Начнём с добавления новой диаграммы Sunburst в презентацию:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```

{{% alert color="primary" title="Смотрите также" %}}
- [**Создать Sunburst диаграммы**](/slides/ru/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

Если необходимо формировать точки данных диаграммы, используйте следующие API:

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/), [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/) и свойство [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/). Они предоставляют доступ к формированию точек данных в диаграммах Treemap и Sunburst. [ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/) используется для доступа к многоуровневым категориям; он представляет контейнер объектов [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/). По сути, это обёртка над [ChartCategoryLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/) с дополнительными свойствами, специфичными для точек данных. Тип [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/) раскрывает два свойства — [format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/format/) и [label](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/label/) — которые предоставляют доступ к соответствующим настройкам.

## **Отображение значений точек данных**

В этом разделе показано, как отобразить значение отдельной точки данных в диаграммах Treemap и Sunburst. Вы увидите, как включить подписи со значениями для выбранных точек.

Отобразить значение точки данных «Leaf 4»:

```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```

![Data point value](data_point_value.png)

## **Настройка подписей и цветов точек данных**

В этом разделе показано, как задать пользовательские подписи и цвета отдельных точек данных в диаграммах Treemap и Sunburst. Вы научитесь получать доступ к конкретной точке данных, назначать подпись и применять сплошную заливку для выделения важных узлов.

Задайте подпись для «Branch 1», чтобы отображалось название серии («Series1») вместо названия категории, и установите цвет текста — жёлтый:

```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![Data point's label and color](data_point_color.png)

## **Настройка цветов веток для точек данных**

Используйте цвета веток, чтобы визуально сгруппировать родительские и дочерние узлы в диаграммах Treemap и Sunburst. В этом разделе показано, как задать пользовательский цвет ветки для конкретной точки данных, чтобы выделить важные поддеревья и повысить читаемость диаграммы.

Изменить цвет ветки «Stem 4»:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
    data_points = chart.chart_data.series[0].data_points

    stem4_branch = data_points[9].data_point_levels[1]
    
    stem4_branch.format.fill.fill_type = slides.FillType.SOLID
    stem4_branch.format.fill.solid_fill_color.color = draw.Color.red
      
    presentation.save("branch_color.pptx", slides.export.SaveFormat.PPTX)
```

![Branch color](branch_color.png)

## **FAQ**

**Можно ли изменить порядок (сортировку) сегментов в Sunburst/Treemap?**

Нет. PowerPoint автоматически сортирует сегменты (обычно по убыванию значений по часовой стрелке). Aspose.Slides отражает это поведение: изменить порядок напрямую нельзя; это делается предварительной обработкой данных.

**Как тема презентации влияет на цвета сегментов и подписей?**

Цвета диаграммы наследуются из [тема/палитра](/slides/ru/python-net/presentation-theme/) презентации, если только вы явно не задаёте заливки/шрифты. Для согласованного результата фиксируйте сплошные заливки и форматирование текста на нужных уровнях.

**Сохранятся ли пользовательские цвета веток и настройки подписей при экспорте в PDF/PNG?**

Да. При экспорте презентации настройки диаграммы (заливки, подписи) сохраняются в выходных форматах, поскольку Aspose.Slides рендерит их с применённым форматированием.

**Можно ли вычислить фактические координаты подписи/элемента для пользовательского наложения поверх диаграммы?**

Да. После подтверждения размещения диаграммы доступны `actual_x`/`actual_y` для элементов (например, для [DataLabel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/)), что облегчает точное позиционирование наложений.