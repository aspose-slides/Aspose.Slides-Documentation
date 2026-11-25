---
title: Настройка 3D‑диаграмм в презентациях с Python
linktitle: 3D диаграмма
type: docs
url: /ru/python-net/3d-chart/
keywords:
- 3D диаграмма
- вращение
- глубина
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Создавайте 3D‑диаграммы в презентациях PowerPoint с помощью Aspose.Slides for Python via .NET. Регулируйте вращение, пропорции высоты, глубину диаграммы и расстояние между рядами с примерами на Python."
---
## **Обзор**

Aspose.Slides for Python via .NET позволяет настраивать представление 3D‑диаграммы с помощью свойства [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/) . Эта статья демонстрирует, как изменить вращение, пропорции высоты, глубину, оси прямого угла и расстояние между рядами, а затем сохранить презентацию в формате PPTX.

## **Установить вращение и глубину 3D‑диаграммы**

Пример ниже создает [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и использует [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) для добавления сложенной 3D‑столбчатой диаграммы на первый слайд. Он заменяет стандартные ряды и категории на два ряда, каждый из которых содержит три значения. Индекс листа `0` указывает на первый рабочий лист данных диаграммы; строка `0` содержит имена рядов, а столбец `0` — подписи категорий.

Свойства [rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) и [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) задают вращение диаграммы соответственно 40 и 270 градусов. [depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) устанавливает её глубину на 150 % от ширины, а [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) включает оси прямого угла вместо перспективы. Полученная презентация содержит заполненную диаграмму с этими настройками 3D‑вида.

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

## **Применить заполнение изображением к поверхности 3D‑диаграммы**

Можно независимо заполнить [side wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/side_wall/), [back wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) и [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/) 3D‑диаграммы. Установите тип заполнения поверхности [fill type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) в `PICTURE` и назначьте изображение. Чтобы один экземпляр изображения заполнял всю поверхность, установите как [picture fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/), так и [picture type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartwall/picture_type/) поверхности в `STRETCH`.

Сохраните [arrow.png](arrow.png) в рабочем каталоге. Пример вращает диаграмму и увеличивает максимальное значение по вертикальной оси, чтобы пол был виден между столбцами. Он клонирует слайд дважды, затем применяет стрелку к разной поверхности на каждом слайде. Все три диаграммы используют одни и те же данные, угол обзора и фон.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 20, 30, 680, 480)
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 30
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 24

    back_slide = presentation.slides.add_clone(slide)
    floor_slide = presentation.slides.add_clone(slide)
    back_chart = back_slide.shapes[0]
    floor_chart = floor_slide.shapes[0]

    with open("arrow.png", "rb") as image_file:
        image_bytes = image_file.read()
    arrow = presentation.images.add_image(image_bytes)

    for surface in (chart.side_wall, back_chart.back_wall, floor_chart.floor):
        fill = surface.format.fill
        fill.fill_type = slides.FillType.PICTURE
        fill.picture_fill_format.picture.image = arrow
        fill.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        surface.picture_type = charts.PictureType.STRETCH

    presentation.save("chart-surfaces.pptx", slides.export.SaveFormat.PPTX)
```

Microsoft PowerPoint показывает три слайда следующим образом.

| Боковая стенка | Задняя стенка | Пол |
| --- | --- | --- |
| ![Стрелка, указывающая в диаграмму вдоль боковой стенки](side-wall.png) | ![Стрелка, указывающая вправо по задней стенке](back-wall.png) | ![Стрелка, указывающая вправо по полу между столбцами](floor.png) |

## **Настроить пропорции высоты 3D‑диаграммы**

Используйте [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) для установки высоты 3D‑диаграммы в процентах от её ширины. Это изменяет пропорции 3D‑сцены без изменения размеров объекта диаграммы на слайде.

Следующий пример создает диаграмму [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) с данными по умолчанию: три ряда и четыре категории. Он сохраняет три презентации с пропорциями высоты 50 %, 100 % и 200 %. Положение, ширина и высота диаграммы остаются фиксированными. Данные, вращение, глубина, расстояние между рядами и форматирование одинаковы во всех трех файлах; меняется только процент высоты.

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

Следующие изображения экспортированы из сгенерированных презентаций с помощью Microsoft PowerPoint. Небольшой процент создает более плоскую сцену, больший процент — более высокую сцену внутри того же объекта диаграммы. PowerPoint также может корректировать интервалы делений осей и размещение подписей для подгонки сцены.

| Высота: 50% | Высота: 100% | Высота: 200% |
| --- | --- | --- |
| ![3D столбчатая диаграмма с высотой, установленной на 50 % от её ширины](height_percent_50.png) | ![3D столбчатая диаграмма с высотой, установленной на 100 % от её ширины](height_percent_100.png) | ![3D столбчатая диаграмма с высотой, установленной на 200 % от её ширины](height_percent_200.png) |

Эти свойства управляют разными аспектами диаграммы:

| Свойство | Эффект |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | Высота 3D‑сцены в процентах от её ширины. |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | Высота объекта диаграммы на слайде, в пунктах. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Глубина 3D‑сцены в процентах от её ширины. |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Расстояние между рядами вдоль оси глубины, в процентах от ширины маркера. |

Настройка высоты влияет на 3D‑столбчатые и 3D‑линейные диаграммы, включая варианты цилиндрических, конических и пирамидальных столбцов, а также на 3D‑линейные, областные, круговые и surface‑диаграммы. В сравнении использован проверенный тип `COLUMN_3D`. Параметр не меняет внешний вид 2D‑диаграммы `CLUSTERED_COLUMN` или диаграммы `BUBBLE_WITH_3D`; эти имена являются членами перечисления [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Для других настроек внешнего вида диаграмм см. [Chart Formatting](/slides/ru/python-net/chart-formatting/).

## **Настроить промежуток между рядами**

Используйте [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) для управления расстоянием между рядами данных вдоль оси глубины 3D‑диаграммы, выраженным в процентах от ширины маркера. Допустимые значения от **0 до 500** включительно: `0` убирает промежуток, большие значения увеличивают расстояние. При фиксированной глубине диаграммы увеличение промежутка делает маркеры тоньше вдоль оси глубины.

Доступ к группе осуществляется через [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/). Настройка применяется ко всем рядам в этой группе, а не только к тому, через который был выполнен доступ. [ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) доступен только для чтения и отражает настройку родительской группы.

Эта настройка влияет на 3D‑столбчатые и 3D‑линейные диаграммы, включая их цилиндрические, конические и пирамидальные варианты, а также на 3D‑линейные и областные диаграммы. Вид зависит от того, располагаются ли ряды по глубине, сгруппированы или сложены. Для наглядного сравнения промежутков между отдельными рядами используйте `ChartType.COLUMN_3D` из перечисления [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/).

Эти свойства управляют разными аспектами диаграммы:

| Свойство | Эффект |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Расстояние между рядами вдоль оси глубины, в процентах от ширины маркера. |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | Расстояние между соседними кластерами столбцов или баров, в процентах от их ширины. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Общая глубина диаграммы, в процентах от её ширины. |

Следующий автономный пример использует стандартные данные диаграммы, содержащие три ряда и четыре категории. Он сохраняет две презентации с одинаковыми данными, вращением, шириной промежутка и глубиной диаграммы; меняется только глубина промежутка.

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

| Промежуток по глубине: 0% | Промежуток по глубине: 500% |
| --- | --- |
| ![3D столбчатая диаграмма без промежутка между рядами вдоль оси глубины](gap_depth_0.png) | ![3D столбчатая диаграмма со 500 % промежутка между рядами вдоль оси глубины](gap_depth_500.png) |

## **Изменить тип 3D‑ряда и форму столбца**

В диаграмме с кластером цилиндрических столбцов первый ряд начинается с цилиндрических столбцов. Пример считывает [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) и [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/) до и после каждого изменения.

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

| Изменения первого ряда | `type` | `bar_3d_shape` |
| --- | --- | --- |
| Создать диаграмму | `CLUSTERED_CYLINDER` | `CYLINDER` |
| Установить `type` в `CLUSTERED_CONE` | `CLUSTERED_CONE` | `CONE` |
| Установить `bar_3d_shape` в `BOX` | `CLUSTERED_COLUMN_3D` | `BOX` |

Установка формы в `BOX` также меняет тип ряда на `CLUSTERED_COLUMN_3D`. Если ваш код ветвится по типу ряда, читайте `series.type` после изменения формы. Значение, кэшированное до присваивания, всё равно выберет ветку `CLUSTERED_CONE`.

![Сравнение в PowerPoint, показывающее первый ряд как цилиндры, конусы и прямоугольные столбцы слева направо](series-shapes.png)

## **Часто задаваемые вопросы**

**Какие типы диаграмм поддерживают 3D‑режим в Aspose.Slides?**

Aspose.Slides поддерживает 3D‑варианты столбчатых диаграмм, включая Column 3D, Clustered Column 3D, Stacked Column 3D и 100% Stacked Column 3D, а также связанные 3D‑типы, доступные через перечисление [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Для точного актуального списка см. члены [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) в справочнике API установленной версии.

**Могу ли я получить растровое изображение 3D‑диаграммы для отчёта или веба?**

Да. Вы можете экспортировать диаграмму в изображение с помощью [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) или [отрисовать весь слайд](/slides/ru/python-net/convert-powerpoint-to-png/) в форматы PNG или JPEG. Это удобно, когда нужен растровый предварительный просмотр или требуется внедрить диаграмму в документы, панели мониторинга или веб‑страницы без необходимости использовать PowerPoint.

**Насколько быстро происходит построение и рендеринг больших 3D‑диаграмм?**

Производительность зависит от объёма данных и визуальной сложности. Для лучших результатов ограничьте использование 3D‑эффектов, избегайте тяжёлых текстур на стенах и областях построения, по возможности уменьшайте количество точек данных в каждом ряду и рендерьте в подходящем размере выходного файла (разрешение и размеры), соответствующем целевому дисплею или печати.