---
title: Настройка 3D‑диаграмм в презентациях на Android
linktitle: 3D Диаграмма
type: docs
url: /ru/androidjava/3d-chart/
keywords:
- 3D‑диаграмма
- вращение
- глубина
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Создавайте 3D‑диаграммы в презентациях PowerPoint с помощью Aspose.Slides for Android via Java. Регулируйте вращение, пропорции высоты, глубину диаграммы и расстояние между сериями с примерами на Java."
---
## **Обзор**

Aspose.Slides for Android via Java позволяет настроить вид 3D‑диаграммы с помощью метода [IChart.getRotation3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getRotation3D--) . В этой статье показано, как изменить вращение, пропорции высоты, глубину, прямоугольные оси и расстояние между сериями, а затем сохранить презентацию в формате PPTX.

## **Установка вращения и глубины 3D‑диаграммы**

Пример ниже создает [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) и с помощью [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) добавляет стековую 3D‑столбчатую диаграмму на первый слайд. Он заменяет серии и категории по умолчанию двумя сериями, каждая из которых содержит три значения. Индекс листа `0` указывает на первый лист данных диаграммы; строка `0` содержит имена серий, а столбец `0` – подписи категорий.

Методы [setRotationX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationX-byte-) и [setRotationY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationY-int-) задают вращение диаграммы соответственно 40 и 270 градусов. [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) устанавливает её глубину в 150 % от ширины, а [setRightAngleAxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) включает прямоугольные оси вместо перспективы. Полученная презентация содержит заполненную диаграмму с этими настройками 3D‑вида.

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

## **Применение заливки картинкой к поверхности 3D‑диаграммы**

У 3D‑диаграммы есть три поверхности, которые можно заполнять независимо: [боковая стенка](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getSideWall--), [задняя стенка](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getBackWall--) и [пол](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getFloor--) . Установите тип заливки поверхности [fill type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) в `Picture` и задайте изображение. Установите как [picture fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-), так и [picture type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartwall/#setPictureType-int-) поверхности в `Stretch`, чтобы одна копия изображения покрывала всю поверхность.

Сохраните [arrow.png](arrow.png) в рабочем каталоге. Пример вращает диаграмму и повышает максимальное значение по вертикальной оси, чтобы пол был виден между столбцами. Затем слайд копируется дважды, и стрелка применяется к разной поверхности на каждом слайде. Все три диаграммы сохраняют одинаковые данные, угол обзора и фон.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try (FileInputStream image = new FileInputStream("arrow.png")) {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    ISlide backSlide = presentation.getSlides().addClone(slide);
    ISlide floorSlide = presentation.getSlides().addClone(slide);
    IChart backChart = (IChart) backSlide.getShapes().get_Item(0);
    IChart floorChart = (IChart) floorSlide.getShapes().get_Item(0);

    IPPImage arrow = presentation.getImages().addImage(image);

    IChartWall[] surfaces = { chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor() };
    for (IChartWall surface : surfaces) {
        IFillFormat fill = surface.getFormat().getFill();
        fill.setFillType(FillType.Picture);
        fill.getPictureFillFormat().getPicture().setImage(arrow);
        fill.getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
        surface.setPictureType(PictureType.Stretch);
    }

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint показывает три слайда следующим образом.

| Боковая стенка | Задняя стенка | Пол |
| --- | --- | --- |
| ![Стрелка, указывающая в диаграмму вдоль боковой стенки](side-wall.png) | ![Стрелка, указывающая вправо по задней стенке](back-wall.png) | ![Стрелка, указывающая вправо по полу между столбцами](floor.png) |

## **Регулировка пропорций высоты 3D‑диаграммы**

Используйте [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) для задания высоты 3D‑диаграммы в процентах от её ширины. Это меняет пропорции 3D‑сцены без изменения размеров объекта диаграммы на слайде.

В следующем примере создаётся диаграмма [Column3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) с данными по умолчанию: три серии и четыре категории. Сохраняются три презентации с пропорциями высоты 50 %, 100 % и 200 %. Позиция, ширина и высота диаграммы остаются неизменными. Данные, вращение, глубина, расстояние между сериями и форматирование одинаковы во всех файлах; меняется только процент высоты.

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

Ниже показаны изображения, иллюстрирующие те же настройки высоты в эквивалентном примере .NET, экспортированные из Microsoft PowerPoint. Более небольшой процент дает более плоскую сцену, больший — более высокую сцену внутри того же объекта диаграммы. PowerPoint может также подстраивать интервалы делений осей и размещение подписей, чтобы вместить сцену.

| Высота: 50 % | Высота: 100 % | Высота: 200 % |
| --- | --- | --- |
| ![3D‑столбчатая диаграмма с высотой 50 % от ширины](height_percent_50.png) | ![3D‑столбчатая диаграмма с высотой 100 % от ширины](height_percent_100.png) | ![3D‑столбчатая диаграмма с высотой 200 % от ширины](height_percent_200.png) |

Эти методы управляют различными аспектами диаграммы:

| Метод | Эффект |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) | Высота 3D‑сцены в процентах от её ширины. |
| [IChart.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setHeight-float-) | Высота объекта диаграммы на слайде, в пунктах. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Глубина 3D‑сцены в процентах от её ширины. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Расстояние между сериями вдоль оси глубины, в процентах от ширины маркера. |

Настройка высоты влияет на 3D‑столбчатые и 3D‑полосовые диаграммы, включая варианты цилиндр, конус и пирамида, а также на 3D‑линейные, 3D‑плоские, 3D‑круговые и 3D‑поверхностные диаграммы. Сравнение выше демонстрирует проверенный тип `Column3D`. Настройка не меняет внешний вид 2D‑диаграммы `ClusteredColumn` или `BubbleWith3D`; эти имена являются членами класса [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/). Для других параметров оформления диаграмм см. [Chart Formatting](/slides/ru/androidjava/chart-formatting/).

## **Регулировка зазора между сериями**

Используйте [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) для управления расстоянием между данными сериями вдоль оси глубины 3D‑диаграммы, выраженным в процентах от ширины маркера. Допустимые значения от **0 до 500** включительно: `0` убирает зазор, большие значения увеличивают пространство. При фиксированной глубине диаграммы увеличение зазора делает маркеры уже вдоль оси глубины.

Получить группу можно через [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) . Параметр применяется ко всем сериям в этой группе, а не только к серии, через которую он был получен. [IChartSeries.getGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getGapDepth--) возвращает текущий зазор по глубине и отражает настройку родительской группы.

Эта настройка влияет на 3D‑столбчатые и 3D‑полосовые диаграммы, включая их цилиндрические, конические и пирамидальные варианты, а также на 3D‑линейные и 3D‑плоские диаграммы. Внешний вид зависит от того, расположены ли серии в глубину, сгруппированы или сложены. Для наглядного сравнения зазоров между отдельными сериями используйте `ChartType.Column3D` из класса [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/).

Эти методы управляют различными аспектами диаграммы:

| Метод | Эффект |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Расстояние между сериями вдоль оси глубины, в процентах от ширины маркера. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | Расстояние между соседними кластерами столбцов или полос, в процентах от их ширины. |
| [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Общая глубина диаграммы, в процентах от её ширины. |

Ниже представлено самостоятельное примерное приложение, использующее данные диаграммы по умолчанию (три серии и четыре категории). Сохраняются две презентации с одинаковыми данными, вращением, шириной зазора и глубиной диаграммы; меняется только глубина зазора.

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

Ниже показаны изображения, иллюстрирующие одинаковые настройки глубины зазора в эквивалентном примере .NET, экспортированные из Microsoft PowerPoint.

| Глубина зазора: 0 % | Глубина зазора: 500 % |
| --- | --- |
| ![3D‑столбчатая диаграмма без зазора между сериями вдоль оси глубины](gap_depth_0.png) | ![3D‑столбчатая диаграмма с зазором 500 % между сериями вдоль оси глубины](gap_depth_500.png) |

## **Изменение типа 3D‑серии и формы столбца**

В сгруппированной цилиндрической диаграмме первая серия начинается с цилиндрической формы столбца. Пример выводит целочисленные значения, возвращаемые [IChartSeries.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getType--) и [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getBar3DShape--) до и после каждого изменения. В таблице указаны соответствующие имена констант.

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

| Изменение первой серии | Тип серии | Форма столбца |
| --- | --- | --- |
| Создание диаграммы | `ClusteredCylinder` | `Cylinder` |
| Установка типа серии в `ClusteredCone` | `ClusteredCone` | `Cone` |
| Установка формы столбца в `Box` | `ClusteredColumn3D` | `Box` |

Установка формы в `Box` также меняет тип серии на `ClusteredColumn3D`. Если ваш код ветвится по типу серии, вызывайте `series.getType()` после изменения формы. Значение, полученное до присваивания, всё равно будет указывать на ветку `ClusteredCone`.

![Сравнение в PowerPoint, показывающее первую серию как цилиндры, конусы и прямоугольные столбцы слева направо](series-shapes.png)

## **FAQ**

**Какие типы диаграмм поддерживают 3D‑режим в Aspose.Slides?**

Aspose.Slides поддерживает 3D‑варианты столбчатых диаграмм, включая Column 3D, Clustered Column 3D, Stacked Column 3D и 100 % Stacked Column 3D, а также связанные 3D‑типы, доступные через класс [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/). Для точного актуального списка проверьте члены [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) в справочнике API установленной версии.

**Можно ли получить растровое изображение 3D‑диаграммы для отчёта или веба?**

Да. Вы можете экспортировать диаграмму в изображение с помощью [Shape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) или [отрендерить весь слайд](/slides/ru/androidjava/convert-powerpoint-to-png/) в форматы PNG или JPEG. Это удобно, когда нужен растровый предварительный просмотр или требуется внедрить диаграмму в документы, панели мониторинга или веб‑страницы без необходимости использования PowerPoint.

**Насколько производительно создание и рендеринг крупных 3D‑диаграмм?**

Производительность зависит от объёма данных и визуальной сложности. Для лучшего результата минимизируйте 3D‑эффекты, избегайте тяжёлых текстур на стенках и областях построения, по возможности ограничивайте количество точек данных в серии и рендерьте в подходящем по размеру выходе (разрешение и размеры), соответствующем целевому дисплею или печати.