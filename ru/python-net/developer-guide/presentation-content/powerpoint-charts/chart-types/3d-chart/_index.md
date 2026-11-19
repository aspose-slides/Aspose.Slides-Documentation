---
title: Настройка 3D‑диаграмм в презентациях с помощью Python
linktitle: 3D‑диаграмма
type: docs
url: /ru/python-net/3d-chart/
keywords:
- 3D‑диаграмма
- вращение
- глубина
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Создавайте 3D‑диаграммы в презентациях PowerPoint с Aspose.Slides for Python via .NET. Регулируйте вращение, пропорции высоты, глубину диаграммы и расстояние между рядами с примерами на Python."
---
## **Обзор**

Aspose.Slides for Python via .NET позволяет настроить отображение 3D‑диаграммы через свойство [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/) . В этой статье показано, как изменить вращение, пропорции высоты, глубину, оси под прямым углом и расстояние между рядами, а затем сохранить презентацию в формате PPTX.

## **Установить вращение и глубину 3D‑диаграммы**

Пример ниже создаёт [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и использует [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) для добавления сложенной 3D‑столбчатой диаграммы на первый слайд. Он заменяет стандартные ряды и категории двумя рядами, содержащими по три значения каждый. Индекс листа `0` указывает на первый лист данных диаграммы; строка `0` содержит имена рядов, а столбец `0` — подписи категорий.

Свойства [rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) и [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) задают вращение диаграммы на 40 и 270 градусов соответственно. [depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) устанавливает её глубину в 150 % от ширины, а [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) включает оси под прямым углом вместо перспективы. Получившаяся презентация содержит заполненную диаграмму с этими настройками 3D‑вида.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    
    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.get_cell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.chart_data.categories.add(category_cell)

    for series_index in range(2):
        series_cell = workbook.get_cell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.chart_data.series.add(series_cell, chart.type)

        for category_index in range(3):
            value_cell = workbook.get_cell(worksheet_index, category_index + 1, series_index + 1, values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Регулировка пропорций высоты 3D‑диаграммы**

Используйте [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) для задания высоты 3D‑диаграммы в процентах от её ширины. Это меняет пропорции 3D‑сцены без изменения размеров объекта диаграммы на слайде.

Следующий пример создаёт диаграмму [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) с данными по умолчанию: три ряда и четыре категории. Он сохраняет три презентации с пропорциями высоты 50 %, 100 % и 200 %. Позиция, ширина и высота диаграммы остаются фиксированными. Данные, вращение, глубина, расстояние между рядами и форматирование одинаковы во всех трёх файлах; меняется только процент высоты.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 460)
    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.depth_percents = 100
    chart.chart_data.series[0].parent_series_group.gap_depth = 150

    for height_percent in (50, 100, 200):
        chart.rotation_3d.height_percents = height_percent
        presentation.save(f"chart_height_{height_percent}.pptx", slides.export.SaveFormat.PPTX)
```

Следующие изображения экспортированы из сгенерированных презентаций с помощью Microsoft PowerPoint. Более маленький процент создает более плоскую сцену, в то время как более высокий процент создаёт более высокую сцену внутри того же объекта диаграммы. PowerPoint может также корректировать интервалы деления осей и расположение подписей, чтобы вписать сцену.

| Высота: 50% | Высота: 100% | Высота: 200% |
| --- | --- | --- |
| ![3D‑столбчатая диаграмма с высотой, равной 50 % от её ширины](height_percent_50.png) | ![3D‑столбчатая диаграмма с высотой, равной 100 % от её ширины](height_percent_100.png) | ![3D‑столбчатая диаграмма с высотой, равной 200 % от её ширины](height_percent_200.png) |

Эти свойства управляют различными аспектами диаграммы:

| Свойство | Эффект |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | Высота 3D‑сцены в процентах от её ширины. |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | Высота объекта диаграммы на слайде, в пунктах. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Глубина 3D‑сцены в процентах от её ширины. |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Расстояние между рядами вдоль оси глубины, в процентах от ширины маркера. |

Настройка высоты влияет на 3D‑столбчатые и 3D‑барные диаграммы, включая их цилиндрические, конические и пирамидальные варианты, а также на 3D‑линейные, 3D‑площадные, 3D‑круговые и 3D‑поверхностные диаграммы. Сравнение выше использует проверенный тип `COLUMN_3D`. Настройка не изменяет внешний вид 2D‑диаграммы `CLUSTERED_COLUMN` или `BUBBLE_WITH_3D`; эти имена являются членами перечисления [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Для других параметров оформления диаграмм смотрите [Chart Formatting](/slides/ru/python-net/chart-formatting/).

## **Регулировка зазора между рядами**

Используйте [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) для управления расстоянием между рядами данных вдоль оси глубины 3D‑диаграммы, выраженным в процентах от ширины маркера. Допустимые значения от **0 до 500**, включительно: `0` убирает зазор, большие значения увеличивают его. При фиксированной глубине диаграммы увеличение зазора делает маркеры более тонкими вдоль оси глубины.

Получить доступ к группе можно через [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/). Настройка применяется ко всем рядам в этой группе, а не только к тому, через который был получен доступ. Свойство [ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) только для чтения и отражает значение родительской группы.

Эта настройка влияет на 3D‑столбчатые и 3D‑барные диаграммы, включая их цилиндрические, конические и пирамидальные варианты, а также на 3D‑линейные и 3D‑площадные диаграммы. Вид зависит от того, находятся ли ряды в глубине, сгруппированы или сложены. Для наглядного сравнения зазоров между отдельными рядами используйте `ChartType.COLUMN_3D` из перечисления [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/).

Эти свойства управляют различными аспектами диаграммы:

| Свойство | Эффект |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Расстояние между рядами вдоль оси глубины, в процентах от ширины маркера. |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | Расстояние между соседними кластерами столбцов или полос, в процентах от их ширины. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Общая глубина диаграммы, в процентах от её ширины. |

Следующий автономный пример использует данные диаграммы по умолчанию, содержащие три ряда и четыре категории. Он сохраняет две презентации с одинаковыми данными, вращением, шириной зазора и глубиной диаграммы; меняется только зазор по глубине.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 230)

    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.depth_percents = 100

    series = chart.chart_data.series[0]
    group = series.parent_series_group
    group.gap_width = 150

    for gap_depth in (0, 500):
        group.gap_depth = gap_depth
        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

Следующие изображения экспортированы из сгенерированных презентаций с помощью Microsoft PowerPoint.

| Зазор по глубине: 0% | Зазор по глубине: 500% |
| --- | --- |
| ![3D‑столбчатая диаграмма без зазора между рядами вдоль оси глубины](gap_depth_0.png) | ![3D‑столбчатая диаграмма с зазором 500 % между рядами вдоль оси глубины](gap_depth_500.png) |

## **Изменить тип 3D‑ряда и форму столбца**

В кластерной цилиндрической диаграмме первый ряд начинается с цилиндрических столбцов. Пример считывает [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) и [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/) до и после каждого изменения.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_CYLINDER, 20, 20, 500, 300)
    series = chart.chart_data.series[0]
    
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.type = charts.ChartType.CLUSTERED_CONE
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.bar_3d_shape = charts.ChartShapeType.BOX
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    presentation.save("series_shape.pptx", slides.export.SaveFormat.PPTX)
```

| Изменение первого ряда | `type` | `bar_3d_shape` |
| --- | --- | --- |
| Создать диаграмму | `CLUSTERED_CYLINDER` | `CYLINDER` |
| Установить `type` в `CLUSTERED_CONE` | `CLUSTERED_CONE` | `CONE` |
| Установить `bar_3d_shape` в `BOX` | `CLUSTERED_COLUMN_3D` | `BOX` |

Установка формы `BOX` также меняет тип ряда на `CLUSTERED_COLUMN_3D`. Если ваш код ветвится в зависимости от типа ряда, считайте `series.type` после изменения формы. Значение, сохранённое до назначения, всё равно выберет ветку `CLUSTERED_CONE`.

![Сравнение в PowerPoint, показывающее первый ряд как цилиндры, конусы и прямоугольные столбцы слева направо](series-shapes.png)

## **Вопросы и ответы**

**Какие типы диаграмм поддерживают режим 3D в Aspose.Slides?**

Aspose.Slides поддерживает 3D‑варианты столбчатых диаграмм, включая Column 3D, Clustered Column 3D, Stacked Column 3D и 100 % Stacked Column 3D, а также связанные 3D‑типы, доступные через перечисление [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Для точного актуального списка проверьте члены [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) в справочнике API установленной версии.

**Можно ли получить растровое изображение 3D‑диаграммы для отчёта или веба?**

Да. Вы можете экспортировать диаграмму в изображение с помощью [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) или [рендерить весь слайд](/slides/ru/python-net/convert-powerpoint-to-png/) в форматы PNG или JPEG. Это удобно, когда нужен растровый предварительный просмотр или требуется встроить диаграмму в документы, панели мониторинга или веб‑страницы без необходимости использования PowerPoint.

**Насколько производительно создание и рендеринг больших 3D‑диаграмм?**

Производительность зависит от объёма данных и визуальной сложности. Для лучших результатов держите 3D‑эффекты минимальными, избегайте тяжёлых текстур на стенах и областях построения, ограничьте количество точек данных в ряду, где это возможно, и рендерьте в размер, соответствующий целевому отображению или печати.