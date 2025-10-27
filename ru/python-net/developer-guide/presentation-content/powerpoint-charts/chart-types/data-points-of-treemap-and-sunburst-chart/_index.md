---
title: Настройка точек данных в диаграммах Treemap и Sunburst в Python
linktitle: Точки данных в диаграммах Treemap и Sunburst
type: docs
url: /ru/python-net/developer-guide/presentation-content/powerpoint-charts/chart-types/data-points-of-treemap-and-sunburst-chart/
keywords:
- диаграмма Treemap
- диаграмма Sunburst
- точка данных
- цвет метки
- цвет ветки
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как управлять точками данных в диаграммах Treemap и Sunburst с помощью Aspose.Slides для Python via .NET, совместимых с форматами PowerPoint и OpenDocument."
---

## **Введение**

Помимо других типов диаграмм PowerPoint, существуют два иерархических типа — **Treemap** и **Sunburst** (известные также как Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph или Multi-Level Pie Chart). Эти диаграммы отображают иерархические данные, организованные в виде дерева — от листьев к верхушке ветки. Листья определяются точками данных серии, а каждый последующий уровень вложенной группировки определяется соответствующей категорией. Aspose.Slides for Python via .NET позволяет форматировать точки данных диаграмм Sunburst и Treemap в Python.

Это пример диаграммы Sunburst, где данные в столбце Series1 определяют листовые узлы, а остальные столбцы определяют иерархические точки данных:

![Пример диаграммы Sunburst](sunburst_example.png)

Начнём с добавления новой диаграммы Sunburst в презентацию:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```

{{% alert color="primary" title="См. также" %}}
- [**Создать диаграммы Sunburst**](/slides/ru/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

Если необходимо форматировать точки данных диаграммы, используйте следующие API:

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/), [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/) и свойство [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/). Они предоставляют доступ к форматированию точек данных в диаграммах Treemap и Sunburst. [ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/) используется для доступа к многоуровневым категориям; он представляет собой контейнер объектов [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/). По сути это обёртка над [ChartCategoryLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/) с дополнительными свойствами, специфичными для точек данных. Тип [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/) раскрывает два свойства — [format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/format/) и [label](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/label/) — которые дают доступ к соответствующим настройкам.

## **Отображение значений точек данных**

В этом разделе показано, как отобразить значение отдельной точки данных в диаграммах Treemap и Sunburst. Вы увидите, как включить отображение значений для выбранных точек.

Отобразить значение точки данных «Leaf 4»:

```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```

![Значение точки данных](data_point_value.png)

## **Установка меток и цветов для точек данных**

В этом разделе показано, как задать пользовательские метки и цвета для отдельных точек данных в диаграммах Treemap и Sunburst. Вы узнаете, как обратиться к конкретной точке данных, задать метку и применить сплошную заливку для выделения важных узлов.

Задать для метки «Branch 1» отображение имени серии («Series1») вместо имени категории, а затем установить цвет текста — желтый:

```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![Метка и цвет точки данных](data_point_color.png)

## **Установка цветов веток для точек данных**

Используйте цвета веток, чтобы визуально сгруппировать родительские и дочерние узлы в диаграммах Treemap и Sunburst. В этом разделе показано, как задать пользовательский цвет ветки для конкретной точки данных, чтобы подчеркнуть важные поддеревья и улучшить читаемость диаграммы.

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

![Цвет ветки](branch_color.png)

## **FAQ**

**Могу ли я изменить порядок (сортировку) сегментов в диаграммах Sunburst/Treemap?**

Нет. PowerPoint автоматически сортирует сегменты (обычно по убыванию значений по часовой стрелке). Aspose.Slides копирует это поведение: изменить порядок напрямую нельзя; нужно предварительно подготовить данные.

**Как тема презентации влияет на цвета сегментов и меток?**

Цвета диаграмм наследуют [тему/палитру](/slides/ru/python-net/presentation-theme/) презентации, если только вы явно не задаёте заливки или шрифты. Для получения предсказуемых результатов фиксируйте сплошные заливки и текстовое форматирование на нужных уровнях.

**Сохранит ли экспорт в PDF/PNG пользовательские цвета веток и настройки меток?**

Да. При экспорте презентации настройки диаграммы (заливки, метки) сохраняются в выходных форматах, так как Aspose.Slides рендерит их с учётом заданного форматирования.

**Могу ли я вычислить фактические координаты метки/элемента для размещения пользовательского наложения поверх диаграммы?**

Да. После того как расположение диаграммы подтверждено, доступны свойства `actual_x`/`actual_y` у элементов (например, у [DataLabel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/)), что позволяет точно позиционировать наложения.