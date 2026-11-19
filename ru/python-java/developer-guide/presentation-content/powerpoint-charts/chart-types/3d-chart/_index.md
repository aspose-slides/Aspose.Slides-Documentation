---
title: Настройка 3D‑диаграмм в презентациях с использованием Python
linktitle: 3D‑диаграмма
type: docs
url: /ru/python-java/3d-chart/
keywords:
- 3D‑диаграмма
- вращение
- глубина
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Создавайте 3D‑диаграммы в презентациях PowerPoint с помощью Aspose.Slides для Python через Java. Регулируйте вращение, пропорции высоты, глубину диаграммы и интервалы между рядами с примерами на Python."
---
## **Обзор**

Aspose.Slides for Python via Java позволяет настраивать вид 3D‑диаграммы с помощью метода [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D). Эта статья демонстрирует, как изменить вращение, пропорции высоты, глубину, оси под прямым углом и интервалы между рядами, а затем сохранить презентацию в формате PPTX.

## **Установка вращения и глубины 3D‑диаграммы**

Пример ниже создаёт объект [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) и использует [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) для добавления сложенной 3D‑столбчатой диаграммы на первый слайд. Он заменяет рядовые и категориальные данные по умолчанию двумя рядами, каждый из которых содержит по три значения. Индекс листа `0` указывает на первый лист данных диаграммы; строка `0` содержит имена рядов, а столбец `0` — метки категорий.

Методы [setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) и [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) задают вращение диаграммы соответственно 40 и 270 градусов. [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) задаёт её глубину 150 % от ширины, а [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) включает оси под прямым углом вместо перспективы. Полученная презентация содержит заполненную диаграмму с этими настройками 3D‑вида.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.getCell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.getChartData().getCategories().add(category_cell)

    for series_index in range(2):
        series_cell = workbook.getCell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())

        for category_index in range(3):
            value_cell = workbook.getCell(worksheet_index, category_index + 1, series_index + 1, jpype.JDouble(values[series_index][category_index]))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Регулировка пропорций высоты 3D‑диаграммы**

Используйте [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) для установки высоты 3D‑диаграммы в процентах от её ширины. Это изменяет пропорции 3D‑сцены без изменения размеров объекта диаграммы на слайде.

Следующий пример создаёт диаграмму [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) с данными по умолчанию: три ряда и четыре категории. Он сохраняет три презентации с пропорциями высоты 50 %, 100 % и 200 %. Положение, ширина и высота диаграммы остаются фиксированными. Данные, вращение, глубина, интервалы между рядами и форматирование одинаковы во всех трёх файлах; меняется только процент высоты.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460)
    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setDepthPercents(100)
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150)

    for height_percent in [50, 100, 200]:
        chart.getRotation3D().setHeightPercents(height_percent)
        presentation.save(f"chart_height_{height_percent}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Следующие изображения иллюстрируют одинаковые настройки высоты в эквивалентном примере .NET и экспортированы с помощью Microsoft PowerPoint. Более низкий процент создаёт более плоскую сцену, а более высокий — более высокую сцену в пределах того же объекта диаграммы. PowerPoint также может корректировать интервалы делений осей и размещение меток для лучшего соответствия сцены.

| Высота: 50% | Высота: 100% | Высота: 200% |
| --- | --- | --- |
| ![3D столбчатая диаграмма с высотой, установленной в 50% от её ширины](height_percent_50.png) | ![3D столбчатая диаграмма с высотой, установленной в 100% от её ширины](height_percent_100.png) | ![3D столбчатая диаграмма с высотой, установленной в 200% от её ширины](height_percent_200.png) |

Эти методы управляют разными аспектами диаграммы:

| Метод | Описание |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | Высота 3D‑сцены в процентах от её ширины. |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | Высота объекта диаграммы на слайде, в пунктах. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Глубина 3D‑сцены в процентах от её ширины. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Расстояние между рядами вдоль оси глубины, в процентах от ширины маркера. |

Настройка высоты влияет на 3D‑столбчатые и 3D‑полосовые диаграммы, включая варианты цилиндр, конус и пирамида, а также 3D‑линейные, площадные, круговые и поверхностные диаграммы. Сравнение выше использует проверенный тип `Column3D`. Настройка не меняет внешний вид 2D‑диаграммы `ClusteredColumn` или `BubbleWith3D`; эти имена являются членами класса [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). Для остальных параметров внешнего вида диаграмм см. [Форматирование диаграммы](/slides/ru/python-java/chart-formatting/).

## **Регулировка промежутка между рядами**

Используйте [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) для управления расстоянием между рядами данных вдоль оси глубины 3D‑диаграммы, выраженным в процентах от ширины маркера. Допустимые значения от **0 до 500**, включительно: `0` удаляет промежуток, более крупные значения увеличивают его. При фиксированной глубине диаграммы увеличение промежутка делает маркеры уже вдоль оси глубины.

Получить группу можно через [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup). Настройка применяется ко всем рядам в этой группе, а не только к тому ряду, через который был выполнен доступ. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) возвращает текущий промежуток глубины и отражает значение, установленное у родительской группы.

Эта настройка влияет на 3D‑столбчатые и 3D‑полосовые диаграммы, включая их цилиндрические, конические и пирамидальные варианты, а также 3D‑линейные и площадные диаграммы. Вид зависит от того, располагаются ли ряды в глубину, сгруппированы или сложены. Для наглядного сравнения промежутков между отдельными рядами используйте `ChartType.Column3D` из класса [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/).

Эти методы управляют разными аспектами диаграммы:

| Метод | Описание |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Расстояние между рядами вдоль оси глубины, в процентах от ширины маркера. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | Расстояние между соседними кластерами столбцов или полос, в процентах от их ширины. |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Общая глубина диаграммы, в процентах от её ширины. |

Следующий автономный пример использует данные диаграммы по умолчанию, содержащие три ряда и четыре категории. Он сохраняет две презентации с одинаковыми данными, вращением, шириной промежутка и глубиной диаграммы; меняется только глубина промежутка.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230)

    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setDepthPercents(100)

    series = chart.getChartData().getSeries().get_Item(0)
    group = series.getParentSeriesGroup()
    group.setGapWidth(150)

    for gap_depth in [0, 500]:
        group.setGapDepth(gap_depth)

        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Следующие изображения иллюстрируют одинаковые настройки промежутка глубины в эквивалентном примере .NET и экспортированы с помощью Microsoft PowerPoint.

| Промежуток глубины: 0% | Промежуток глубины: 500% |
| --- | --- |
| ![3D столбчатая диаграмма без промежутка между рядами вдоль оси глубины](gap_depth_0.png) | ![3D столбчатая диаграмма с промежутком 500% между рядами вдоль оси глубины](gap_depth_500.png) |

## **Изменение 3D‑типа серии и формы столбца**

В сгруппированной цилиндрической диаграмме первый ряд начинается с цилиндрической формы столбца. Пример выводит целочисленные значения, возвращаемые методами [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) и [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) до и после каждого изменения. Таблица содержит соответствующие имена констант.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartShapeType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)
    
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setType(ChartType.ClusteredCone)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setBar3DShape(ChartShapeType.Box)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    presentation.save("series_shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Изменение первого ряда | Тип ряда | Форма столбца |
| --- | --- | --- |
| Создать диаграмму | `ClusteredCylinder` | `Cylinder` |
| Установить тип ряда в `ClusteredCone` | `ClusteredCone` | `Cone` |
| Установить форму столбца в `Box` | `ClusteredColumn3D` | `Box` |

Установка формы `Box` также меняет тип ряда на `ClusteredColumn3D`. Если ваш код ветвится в зависимости от типа ряда, вызовите `series.getType()` после изменения формы. Значение, кешированное до присваивания, всё равно будет указывать на ветку `ClusteredCone`.

![Сравнение PowerPoint, показывающее первый ряд как цилиндры, конусы и прямоугольные столбцы слева направо](series-shapes.png)

## **Часто задаваемые вопросы**

**Какие типы диаграмм поддерживают 3D‑режим в Aspose.Slides?**

Aspose.Slides поддерживает 3D‑варианты столбчатых диаграмм, включая Column 3D, Clustered Column 3D, Stacked Column 3D и 100 % Stacked Column 3D, а также связанные 3D‑типы, доступные через класс [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). Для точного актуального списка проверьте члены [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) в справочнике API установленной версии.

**Могу ли я получить растровое изображение 3D‑диаграммы для отчёта или веба?**

Да. Вы можете экспортировать диаграмму в изображение с помощью [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) или [render the entire slide](/slides/ru/python-java/convert-powerpoint-to-png/) в форматы PNG или JPEG. Это удобно, когда нужен растровый предварительный просмотр или нужно встроить диаграмму в документы, панели мониторинга или веб‑страницы без необходимости PowerPoint.

**Насколько производительно построение и рендеринг больших 3D‑диаграмм?**

Производительность зависит от объёма данных и визуальной сложности. Для получения наилучших результатов следует минимизировать 3D‑эффекты, избегать тяжёлых текстур на стенах и областях графика, по возможности ограничивать количество точек данных в каждом ряду и рендерить в оптимальном разрешении и размерах, соответствующих целевому экрану или печати.