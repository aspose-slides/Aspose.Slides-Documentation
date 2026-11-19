---
title: Настройка 3D‑диаграмм в презентациях с использованием Java
linktitle: 3D‑диаграмма
type: docs
url: /ru/java/3d-chart/
keywords:
- 3D‑диаграмма
- вращение
- глубина
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Создавайте 3D‑диаграммы в презентациях PowerPoint с помощью Aspose.Slides for Java. Регулируйте вращение, пропорции высоты, глубину диаграммы и интервалы между рядами, используя примеры на Java."
---
## **Обзор**

Aspose.Slides for Java позволяет настроить отображение 3D‑диаграммы с помощью метода [IChart.getRotation3D](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getRotation3D--) . В этой статье демонстрируется, как отрегулировать вращение, пропорции высоты, глубину, оси под прямым углом и интервал между рядами, а затем сохранить презентацию в формате PPTX.

## **Задать вращение и глубину 3D‑диаграммы**

В приведённом примере создаётся объект [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) и используется метод [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) для добавления стековой 3D‑столбчатой диаграммы на первый слайд. Он заменяет стандартные ряды и категории двумя рядами, каждый из которых содержит три значения. Индекс листа `0` указывает на первый лист данных диаграммы; строка `0` содержит имена рядов, а столбец `0` – метки категорий.

Методы [setRotationX](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationX-byte-) и [setRotationY](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationY-int-) устанавливают вращение диаграммы соответственно на 40 и 270 градусов. [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) задаёт её глубину в 150 % от ширины, а [setRightAngleAxes](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) включают оси под прямым углом вместо перспективы. Получившаяся презентация содержит заполненную диаграмму с этими настройками 3D‑отображения.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    double[][] values = { { 20, 50, 30 }, { 30, 10, 60 } };

    for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (int seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Настроить пропорции высоты 3D‑диаграммы**

Используйте метод [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) для установки высоты 3D‑диаграммы в процентах от её ширины. Это изменяет пропорции 3D‑сцены без изменения размеров объекта диаграммы на слайде.

В следующем примере создаётся диаграмма [Column3D](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) с данными по умолчанию: три ряда и четыре категории. Он сохраняет три презентации с пропорциями высоты 50 %, 100 % и 200 %. Позиция, ширина и высота диаграммы остаются фиксированными. Данные, вращение, глубина, интервал между рядами и форматирование идентичны во всех трёх файлах; изменяется только процент высоты.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (int heightPercent : new int[] { 50, 100, 200 }) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Следующие изображения иллюстрируют одинаковые настройки высоты в эквивалентном примере .NET и были экспортированы с помощью Microsoft PowerPoint. Более низкий процент создаёт более плоскую сцену, а более высокий процент — более высокую сцену внутри того же объекта диаграммы. PowerPoint также может корректировать интервалы делений осей и расположение подписей, чтобы подогнать сцену.

| Высота: 50% | Высота: 100% | Высота: 200% |
| --- | --- | --- |
| ![3D столбчатая диаграмма с высотой, установленной в 50 % её ширины](height_percent_50.png) | ![3D столбчатая диаграмма с высотой, установленной в 100 % её ширины](height_percent_100.png) | ![3D столбчатая диаграмма с высотой, установленной в 200 % её ширины](height_percent_200.png) |

Эти методы управляют разными аспектами диаграммы:

| Метод | Эффект |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) | Высота 3D‑сцены в процентах от её ширины. |
| [IChart.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setHeight-float-) | Высота объекта диаграммы на слайде, в пунктах. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Глубина 3D‑сцены в процентах от её ширины. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Расстояние между рядами вдоль оси глубины, в процентах от ширины маркера. |

Настройка высоты влияет на 3D‑столбчатые и 3D‑полосные диаграммы, включая варианты цилиндр, конус и пирамида, а также на 3D‑линейные, 3D‑плоские, 3D‑круговые и 3D‑поверхностные диаграммы. В приведённом сравнении используется проверенный тип `Column3D`. Эта настройка не меняет внешний вид 2D‑диаграммы `ClusteredColumn` или диаграммы `BubbleWith3D`; эти имена являются членами класса [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). Для других параметров внешнего вида диаграмм см. [Chart Formatting](/slides/ru/java/chart-formatting/).

## **Настроить промежуток между рядами**

Используйте метод [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) для управления расстоянием между рядами данных вдоль оси глубины 3D‑диаграммы, выраженным в процентах от ширины маркера. Допустимые значения от **0 до 500**, включительно: `0` удаляет промежуток, более высокие значения увеличивают интервал. При фиксированной глубине диаграммы увеличение промежутка делает маркеры тоньше вдоль оси глубины.

Получите доступ к группе через [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--). Настройка применяется ко всем рядам в этой группе, а не только к ряду, через который она получена. [IChartSeries.getGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getGapDepth--) возвращает значение промежутка по глубине и отражает настройку родительской группы.

Эта настройка влияет на 3D‑столбчатые и 3D‑полосные диаграммы, включая их варианты цилиндр, конус и пирамида, а также на 3D‑линейные и 3D‑плоские диаграммы. Внешний вид зависит от того, расположены ли ряды в глубину, сгруппированы или сложены. Для наглядного сравнения промежутков между отдельными рядами используйте `ChartType.Column3D` из класса [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/).

Эти методы управляют разными аспектами диаграммы:

| Метод | Эффект |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Расстояние между рядами вдоль оси глубины, в процентах от ширины маркера. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | Расстояние между соседними кластерами столбцов или полос, в процентах от их ширины. |
| [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Общая глубина диаграммы, в процентах от её ширины. |

В следующем автономном примере используется набор данных диаграммы по умолчанию, содержащий три ряда и четыре категории. Он сохраняет две презентации с одинаковыми данными, вращением, шириной промежутка и глубиной диаграммы; меняется только глубина промежутка.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartSeriesGroup group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (int gapDepth : new int[] { 0, 500 }) {
        group.setGapDepth(gapDepth);

        String fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Следующие изображения иллюстрируют одинаковые настройки глубины промежутка в эквивалентном примере .NET и были экспортированы с помощью Microsoft PowerPoint.

| Глубина промежутка: 0% | Глубина промежутка: 500% |
| --- | --- |
| ![3D столбчатая диаграмма без промежутка между рядами вдоль оси глубины](gap_depth_0.png) | ![3D столбчатая диаграмма с промежутком 500 % между рядами вдоль оси глубины](gap_depth_500.png) |

## **Изменить тип 3D‑ряда и форму столбца**

В сгруппированной цилиндрической диаграмме первый ряд начинается с цилиндрической формы столбца. Пример выводит целочисленные значения, возвращаемые методами [IChartSeries.getType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getType--) и [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getBar3DShape--) до и после каждого изменения. Таблица показывает соответствующие имена констант.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setType(ChartType.ClusteredCone);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(ChartShapeType.Box);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Изменение первого ряда | Тип ряда | Форма столбца |
| --- | --- | --- |
| Create the chart | `ClusteredCylinder` | `Cylinder` |
| Set the series type to `ClusteredCone` | `ClusteredCone` | `Cone` |
| Set the bar shape to `Box` | `ClusteredColumn3D` | `Box` |

Установка формы `Box` также меняет тип ряда на `ClusteredColumn3D`. Если ваш код ветвится в зависимости от типа ряда, вызовите `series.getType()` после изменения формы. Значение, кэшированное до присвоения, всё равно выберет ветку `ClusteredCone`.

![Сравнение в PowerPoint, показывающее первый ряд как цилиндры, конусы и прямоугольные столбцы слева направо](series-shapes.png)

## **Часто задаваемые вопросы**

**Какие типы диаграмм поддерживают 3D‑режим в Aspose.Slides?**

Aspose.Slides поддерживает 3D‑варианты столбчатых диаграмм, включая Column 3D, Clustered Column 3D, Stacked Column 3D и 100 % Stacked Column 3D, а также связанные 3D‑типы, доступные через класс [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). Для точного актуального списка проверьте члены [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) в справочнике API установленной версии.

**Можно ли получить растровое изображение 3D‑диаграммы для отчёта или веба?**

Да. Вы можете экспортировать диаграмму в изображение с помощью [Shape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) или [отобразить весь слайд](/slides/ru/java/convert-powerpoint-to-png/) в форматы PNG или JPEG. Это удобно, когда нужен растровый предварительный просмотр или требуется внедрить диаграмму в документы, панели мониторинга или веб‑страницы без необходимости в PowerPoint.

**Насколько эффективна работа при построении и рендеринге больших 3D‑диаграмм?**

Производительность зависит от объёма данных и визуальной сложности. Для лучшего результата уменьшайте 3D‑эффекты, избегайте тяжёлых текстур на стенах и областях построения, по возможности ограничивайте количество точек данных в ряду и выводите в выходной файл подходящего размера (разрешения и размеров), соответствующего целевому экрану или требованиям печати.