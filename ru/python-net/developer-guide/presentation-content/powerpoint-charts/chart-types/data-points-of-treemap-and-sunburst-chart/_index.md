---
title: Настройка точек данных в диаграммах «Дерево» и «Солнечный луч» в Python
linktitle: Точки данных в диаграммах «Дерево» и «Солнечный луч»
type: docs
url: /ru/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- диаграмма дерево
- диаграмма солнечный луч
- точка данных
- цвет метки
- цвет ветки
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как управлять точками данных в диаграммах «Дерево» и «Солнечный луч» с помощью Aspose.Slides for Python via .NET, совместимых с форматами PowerPoint и OpenDocument."
---

## **Введение**

Среди других типов диаграмм PowerPoint есть две иерархические — **TreeMap** и **Sunburst** (также известные как Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph или Multi-Level Pie Chart). Эти диаграммы отображают иерархические данные, упорядоченные в виде дерева — от листьев к вершине ветки. Листья определяются точками данных серии, а каждый последующий вложенный уровень группировки определяется соответствующей категорией. Aspose.Slides for Python via .NET позволяет форматировать точки данных диаграмм Sunburst и TreeMap в Python.

Ниже показана диаграмма Sunburst, где данные в столбце Series1 определяют листовые узлы, а остальные столбцы — иерархические точки данных:

![Sunburst chart example](sunburst_example.png)

Начнём с добавления новой диаграммы Sunburst в презентацию:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```

{{% alert color="primary" title="Смотрите также" %}}
- [**Создание диаграмм Sunburst**](/slides/ru/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

Если необходимо отформатировать точки данных диаграммы, используйте следующие API:

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/), [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/) и свойство [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/). Они предоставляют доступ к форматированию точек данных в диаграммах TreeMap и Sunburst. [ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/) используется для доступа к многоуровневым категориям; он представляет собой контейнер объектов [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/). По сути, это обёртка над [ChartCategoryLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/) с дополнительными свойствами, специфичными для точек данных. Тип [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/) раскрывает два свойства — [format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/format/) и [label](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/label/) — которые предоставляют доступ к соответствующим настройкам.

## **Отображение значений точек данных**

В этом разделе показано, как отобразить значение отдельной точки данных в диаграммах TreeMap и Sunburst. Вы увидите, как включить подписи со значениями для выбранных точек.

Отобразить значение точки данных «Leaf 4»:

```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```

![Data point value](data_point_value.png)

## **Установка меток и цветов для точек данных**

В этом разделе показано, как задать пользовательские метки и цвета для отдельных точек данных в диаграммах TreeMap и Sunburst. Вы узнаете, как получить доступ к конкретной точке данных, присвоить ей метку и применить сплошную заливку для выделения важных узлов.

Задать для метки «Branch 1» отображение имени серии («Series1») вместо имени категории, а затем установить цвет текста желтым:

```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![Data point's label and color](data_point_color.png)

## **Установка цветов веток для точек данных**

Используйте цвета веток, чтобы управлять визуальной группировкой родительских и дочерних узлов в диаграммах TreeMap и Sunburst. Этот раздел показывает, как задать пользовательский цвет ветки для конкретной точки данных, чтобы выделить важные поддеревья и улучшить читаемость диаграммы.

Изменить цвет ветки «Stem 4»:

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

**Можно ли изменить порядок (сортировку) сегментов в Sunburst/TreeMap?**

Нет. PowerPoint сортирует сегменты автоматически (обычно по убывающим значениям, по часовой стрелке). Aspose.Slides отражает это поведение: изменить порядок напрямую нельзя; необходимо выполнить предобработку данных.

**Как тема презентации влияет на цвета сегментов и меток?**

Цвета диаграммы наследуются из [тема/палитра](/slides/ru/python-net/presentation-theme/) презентации, если только не заданы явно заливки/шрифты. Для согласованных результатов фиксируйте сплошные заливки и форматирование текста на нужных уровнях.

**Сохранятся ли пользовательские цвета веток и настройки меток при экспорте в PDF/PNG?**

Да. При экспорте презентации настройки диаграммы (заливки, метки) сохраняются в выходных форматах, поскольку Aspose.Slides рендерит их с учётом применённого форматирования.

**Можно ли вычислить фактические координаты метки/элемента для пользовательского наложения поверх диаграммы?**

Да. После того как макет диаграммы подтверждён, доступны `actual_x`/`actual_y` для элементов (например, для [DataLabel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/)), что упрощает точное позиционирование наложений.