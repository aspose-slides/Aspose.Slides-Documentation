---
title: Настройка 3D‑диаграмм в презентациях с помощью Python
linktitle: 3D Диаграмма
type: docs
url: /ru/python-java/3d-chart/
keywords:
- 3D диаграмма
- вращение
- глубина
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Создавайте 3D‑диаграммы в презентациях PowerPoint с помощью Aspose.Slides для Python через Java. Настраивайте вращение, пропорции высоты, глубину диаграммы и расстояние между рядами с примерами на Python."
---
## **Обзор**

Aspose.Slides for Python via Java позволяет настроить вид 3D‑диаграммы с помощью метода [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D). В этой статье показано, как изменить вращение, пропорции высоты, глубину, оси под прямым углом и расстояние между рядами, а затем сохранить презентацию в формате PPTX.

## **Установка вращения и глубины 3D‑диаграммы**

Ниже приведён пример, создающий [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) и использующий [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) для добавления сложенной 3D‑столбчатой диаграммы на первый слайд. По умолчанию заменяются серии и категории двумя сериями, содержащими по три значения. Индекс листа `0` указывает на первый лист данных диаграммы; строка `0` содержит имена серий, а столбец `0` — подписи категорий.

Методы [setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) и [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) задают вращение диаграммы соответственно 40 и 270 градусов. [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) устанавливает её глубину в 150 % от ширины, а [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) включает оси под прямым углом вместо перспективы. Полученная презентация содержит заполненную диаграмму с этими настройками 3D‑вида.

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

## **Применение заливки изображением к поверхности 3D‑диаграммы**

У 3D‑диаграммы есть три поверхности, которые можно заполнять независимо: [side wall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getSideWall), [back wall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getBackWall) и [floor](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getFloor). Установите для [fill type](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) поверхности значение `Picture` и задайте изображение. Установите как [picture fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode), так и [picture type](https://reference.aspose.com/slides/python-java/aspose.slides/chartwall/#setPictureType) поверхности в `Stretch`, чтобы одна копия изображения растянулась по всей поверхности.

Сохраните [arrow.png](arrow.png) в рабочем каталоге. Пример вращает диаграмму и повышает максимальное значение вертикальной оси, чтобы пол был виден между столбцами. Затем он клонирует слайд дважды и применяет стрелку к различной поверхности на каждом слайде. Все три диаграммы сохраняют одинаковые данные, угол обзора и фон.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, PictureFillMode, PictureType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(30)
    
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(24)

    back_slide = presentation.getSlides().addClone(slide)
    floor_slide = presentation.getSlides().addClone(slide)
    back_chart = back_slide.getShapes().get_Item(0)
    floor_chart = floor_slide.getShapes().get_Item(0)

    image_bytes = Path("arrow.png").read_bytes()
    arrow = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_bytes))

    surfaces = (chart.getSideWall(), back_chart.getBackWall(), floor_chart.getFloor())
    for surface in surfaces:
        fill = surface.getFormat().getFill()
        fill.setFillType(FillType.Picture)
        picture_fill = fill.getPictureFillFormat()
        picture_fill.getPicture().setImage(arrow)
        picture_fill.setPictureFillMode(PictureFillMode.Stretch)
        surface.setPictureType(PictureType.Stretch)

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Microsoft PowerPoint отображает три слайда следующим образом.

| Боковая стена | Задняя стена | Пол |
| --- | --- | --- |
| ![Arrow pointing into the chart along the side wall](side-wall.png) | ![Arrow pointing right across the back wall](back-wall.png) | ![Arrow pointing right across the floor between the columns](floor.png) |

## **Регулировка пропорций высоты 3D‑диаграммы**

Используйте [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) для задания высоты 3D‑диаграммы в процентах от её ширины. Это изменяет пропорции 3D‑сцены без изменения размеров объекта диаграммы на слайде.

В следующем примере создаётся диаграмма [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) с данными по умолчанию: три серии и четыре категории. Сохраняются три презентации с пропорциями высоты 50 %, 100 % и 200 %. Позиция, ширина и высота диаграммы остаются фиксированными. Данные, вращение, глубина, расстояние между сериями и форматирование одинаковы во всех трёх файлах; меняется только процент высоты.

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

Ниже изображены те же настройки высоты в эквивалентном примере .NET, экспортированные с помощью Microsoft PowerPoint. Более небольшой процент создаёт более плоскую сцену, более большой — более высокую сцену в том же объекте диаграммы. PowerPoint также может подстроить интервалы делений осей и размещение меток, чтобы сцена вписалась.

| Высота: 50 % | Высота: 100 % | Высота: 200 % |
| --- | --- | --- |
| ![3D column chart with height set to 50 percent of its width](height_percent_50.png) | ![3D column chart with height set to 100 percent of its width](height_percent_100.png) | ![3D column chart with height set to 200 percent of its width](height_percent_200.png) |

Эти методы управляют различными аспектами диаграммы:

| Метод | Описание |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | Высота 3D‑сцены в процентах от её ширины. |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | Высота объекта диаграммы на слайде в пунктах. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Глубина 3D‑сцены в процентах от её ширины. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Расстояние между сериями вдоль оси глубины, в процентах от ширины маркера. |

Настройка высоты влияет на 3D‑столбчатые и 3D‑полосовые диаграммы, включая цилиндрические, конусные и пирамидальные варианты, а также 3D‑линейные, площадные, круговые и поверхностные диаграммы. Сравнение выше использует проверенный тип `Column3D`. Настройка не меняет внешний вид 2D‑диаграммы `ClusteredColumn` или диаграммы `BubbleWith3D`; эти имена являются членами класса [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). Для других параметров внешнего вида диаграммы см. [Chart Formatting](/slides/ru/python-java/chart-formatting/).

## **Регулировка промежутка между сериями**

Используйте [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) для управления расстоянием между данными сериями вдоль оси глубины 3D‑диаграммы, выраженным в процентах от ширины маркера. Допустимые значения **от 0 до 500** включительно: `0` удаляет промежуток, больший показатель увеличивает расстояние. При фиксированной глубине диаграммы увеличение промежутка делает маркеры тоньше по оси глубины.

Получите группу через [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup). Настройка применяется ко всем сериям в этой группе, а не только к серии, через которую был выполнен вызов. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) возвращает текущий промежуток по глубине и отражает настройку родительской группы.

Эта настройка влияет на 3D‑столбчатые и 3D‑полосовые диаграммы, включая их цилиндрические, конусные и пирамидальные варианты, а также 3D‑линейные и площадные диаграммы. Внешний вид зависит от того, расположены ли серии в глубину, сгруппированы или сложены. Для наглядного сравнения промежутков между отдельными сериями используйте `ChartType.Column3D` из класса [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/).

Эти методы управляют различными аспектами диаграммы:

| Метод | Описание |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Расстояние между сериями вдоль оси глубины, в процентах от ширины маркера. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | Расстояние между соседними группами столбцов или полос, в процентах от их ширины. |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Общая глубина диаграммы, в процентах от её ширины. |

Следующий самостоятельный пример использует данные диаграммы по умолчанию, содержащие три серии и четыре категории. Сохраняются две презентации с одинаковыми данными, вращением, шириной промежутка и глубиной диаграммы; меняется только глубина промежутка.

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

Ниже представлены изображения, иллюстрирующие одинаковые настройки глубины промежутка в эквивалентном примере .NET, экспортированные с помощью Microsoft PowerPoint.

| Глубина промежутка: 0 % | Глубина промежутка: 500 % |
| --- | --- |
| ![3D column chart with no gap between series along the depth axis](gap_depth_0.png) | ![3D column chart with a 500 percent gap between series along the depth axis](gap_depth_500.png) |

## **Изменение 3D‑типа серии и формы столбца**

В кластерной цилиндрической диаграмме первая серия начинается с цилиндрической формы столбца. Пример выводит целочисленные значения, возвращаемые [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) и [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) до и после каждого изменения. Таблица содержит соответствующие имена констант.

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

| Изменение первой серии | Тип серии | Форма столбца |
| --- | --- | --- |
| Создание диаграммы | `ClusteredCylinder` | `Cylinder` |
| Установка типа серии в `ClusteredCone` | `ClusteredCone` | `Cone` |
| Установка формы столбца в `Box` | `ClusteredColumn3D` | `Box` |

Установка формы в `Box` также меняет тип серии на `ClusteredColumn3D`. Если ваш код ветвится в зависимости от типа серии, вызывайте `series.getType()` после изменения формы. Значение, полученное до присвоения, всё равно будет указывать на ветку `ClusteredCone`.

![PowerPoint comparison showing the first series as cylinders, cones, and rectangular columns from left to right](series-shapes.png)

## **FAQ**

**Какие типы диаграмм поддерживают 3D‑режим в Aspose.Slides?**

Aspose.Slides поддерживает 3D‑варианты столбчатых диаграмм, включая Column 3D, Clustered Column 3D, Stacked Column 3D и 100 % Stacked Column 3D, а также связанные 3D‑типы, доступные через класс [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). Для актуального полного списка проверьте члены [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) в справочнике API установленной версии.

**Можно ли получить растровое изображение 3D‑диаграммы для отчёта или веба?**

Да. Вы можете экспортировать диаграмму в изображение с помощью [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) или [render the entire slide](/slides/ru/python-java/convert-powerpoint-to-png/) в форматы PNG или JPEG. Это удобно, когда нужен растровый предварительный просмотр или требуется внедрить диаграмму в документы, аналитические панели или веб‑страницы без необходимости использовать PowerPoint.

**Насколько производительно построение и рендеринг крупных 3D‑диаграмм?**

Производительность зависит от объёма данных и визуальной сложности. Для достижения лучших результатов держите 3D‑эффекты минимальными, избегайте тяжёлых текстур на стенах и площадях графиков, по возможности ограничивайте количество точек данных в серии и рендерьте в подходящем разрешении и размерах, соответствующих целевому экрану или печати.