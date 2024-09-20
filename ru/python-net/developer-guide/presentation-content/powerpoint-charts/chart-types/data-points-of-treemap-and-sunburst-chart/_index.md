---
title: Точки данных для графика с иерархией и графика Солнечного Всплеска
type: docs
url: /python-net/data-points-of-treemap-and-sunburst-chart/
keywords: "График с солнечным всплеском, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Добавьте график с солнечным всплеском в презентацию PowerPoint на Python"
---

Среди других типов графиков PowerPoint есть два "иерархических" типа - **Иерархический график** и **График солнечного всплеска** (также известный как Солнечный график, Солнечная диаграмма, Радиальный график или Многоуровневый круговой график). Эти графики отображают иерархические данные, организованные в виде дерева - от листьев до верхушки ветки. Листья определяются точками данных серии, а каждый последующий вложенный уровень группировки определяется соответствующей категорией. Aspose.Slides для Python через .NET позволяет форматировать точки данных графика Солнечного Всплеска и Иерархического Графика на Python.

Вот график солнечного всплеска, где данные в столбце Series1 определяют листья, в то время как другие столбцы определяют иерархические точки данных:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Давайте начнем с добавления нового графика солнечного всплеска в презентацию:



```py
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 100, 100, 450, 400)
```

{{% alert color="primary" title="Смотрите также" %}} 
- [**Создание графика солнечного всплеска**](/slides/python-net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}


Если необходимо отформатировать точки данных графика, нам следует использовать следующее:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartDataPointLevelsManager/), 
[IChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapointlevel/) классы 
и [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapoint/) свойство 
обеспечивают доступ для форматирования точек данных графиков Иерархического графика и Солнечного Всплеска. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartDataPointLevelsManager/) 
используется для доступа к многоуровневым категориям - он представляет контейнер объектов 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartDataPointLevel/). 
По сути, это обертка для 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartCategoryLevelsManager/) с 
добавленными свойствами, специфичными для точек данных. 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartDataPointLevel/) класс имеет 
два свойства: [**Format**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapointlevel/) и 
[**DataLabel** ](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapointlevel/), которые 
обеспечивают доступ к соответствующим настройкам.
## **Показать значение точки данных**
Показать значение точки данных "Лист 4":



```py
    dataPoints = chart.chart_data.series[0].data_points
    dataPoints[3].data_point_levels[0].label.data_label_format.show_value = True
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)
## **Установить метку и цвет точки данных**
Установите метку данных "Ветка 1", чтобы отображать название серии ("Series1") вместо названия категории. Затем установите цвет текста на желтый:



```py
    branch1Label = dataPoints[0].data_point_levels[2].label
    branch1Label.data_label_format.show_category_name = False
    branch1Label.data_label_format.show_series_name = True

    branch1Label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    branch1Label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)
## **Установить цвет ветки точки данных**

Измените цвет ветки "Стебель 4":

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 100, 100, 450, 400)
    dataPoints = chart.chart_data.series[0].data_points

    stem4branch = dataPoints[9].data_point_levels[1]
    
    stem4branch.format.fill.fill_type = slides.FillType.SOLID
    stem4branch.format.fill.solid_fill_color.color = draw.Color.red
      
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)
