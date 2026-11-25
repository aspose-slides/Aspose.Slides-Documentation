---
title: Настройка 3D‑диаграмм в презентациях с помощью JavaScript
linktitle: 3D‑диаграмма
type: docs
url: /ru/nodejs-java/3d-chart/
keywords:
- 3D‑диаграмма
- вращение
- глубина
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Создавайте 3D‑диаграммы в презентациях PowerPoint с помощью Aspose.Slides для Node.js через Java. Регулируйте вращение, пропорции высоты, глубину диаграммы и расстояние между сериями с примерами на JavaScript."
---
## **Обзор**

Aspose.Slides for Node.js via Java позволяет настроить отображение 3D‑диаграммы с помощью метода [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/) . Эта статья демонстрирует, как изменить вращение, пропорции высоты, глубину, оси под прямым углом и расстояние между сериями, а затем сохранить презентацию в формате PPTX.

## **Установить вращение и глубину 3D‑диаграммы**

В примере ниже создаётся объект [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) и с помощью [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) добавляется стэкованная 3D‑столбчатая диаграмма на первый слайд. Он заменяет серии и категории по умолчанию на две серии, каждая из которых содержит три значения. Индекс листа `0` указывает на первый лист данных диаграммы; строка `0` содержит имена серий, а столбец `0` — подписи категорий.

Методы [setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) и [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) задают вращение диаграммы соответственно 40 и 270 градусов. [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) задаёт её глубину 150 % от ширины, а [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) включает оси под прямым углом вместо перспективы. Полученная презентация содержит диаграмму с этими настройками 3D‑просмотра.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    const values = [[20, 50, 30], [30, 10, 60]];

    for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        const categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            const valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Применить заливку изображением к поверхности 3D‑диаграммы**

Можно независимо заполнить [side wall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getsidewall/), [back wall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getbackwall/) и [floor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getfloor/) 3D‑диаграммы. Установите для поверхности тип заливки [fill type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) `Picture` и назначьте изображение. Установите обе [picture fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/setpicturefillmode/) и [picture type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartwall/setpicturetype/) поверхности в значение `Stretch`, чтобы одно копию изображения растянуть на всю поверхность.

Сохраните файл [arrow.png](arrow.png) в рабочем каталоге. Пример вращает диаграмму и повышает максимальное значение по вертикальной оси, чтобы пол был виден между столбцами. Затем он клонирует слайд дважды и применяет стрелку к разной поверхности на каждом слайде. Все три диаграммы сохраняют одинаковые данные, угол обзора и фон.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    const backSlide = presentation.getSlides().addClone(slide);
    const floorSlide = presentation.getSlides().addClone(slide);
    const backChart = backSlide.getShapes().get_Item(0);
    const floorChart = floorSlide.getShapes().get_Item(0);

    const image = slides.Images.fromFile("arrow.png");
    try {
        const arrow = presentation.getImages().addImage(image);
        const surfaces = [chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor()];
        for (const surface of surfaces) {
            const fill = surface.getFormat().getFill();
            fill.setFillType(java.newByte(slides.FillType.Picture));
            const pictureFill = fill.getPictureFillFormat();
            pictureFill.getPicture().setImage(arrow);
            pictureFill.setPictureFillMode(slides.PictureFillMode.Stretch);
            surface.setPictureType(slides.PictureType.Stretch);
        }
    } finally {
        image.dispose();
    }

    presentation.save("chart-surfaces.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint отображает три слайда следующим образом.

| Боковая стенка | Задняя стенка | Пол |
| --- | --- | --- |
| ![Стрелка, указывающая в диаграмму вдоль боковой стенки](side-wall.png) | ![Стрелка, указывающая вправо по задней стенке](back-wall.png) | ![Стрелка, указывающая вправо по полу между столбцами](floor.png) |

## **Отрегулировать пропорции высоты 3D‑диаграммы**

Используйте [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) для задания высоты 3D‑диаграммы в процентах от её ширины. Это изменяет пропорции 3D‑сцены без изменения размеров объекта диаграммы на слайде.

В следующем примере создаётся диаграмма [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) с данными по умолчанию: три серии и четыре категории. Он сохраняет три презентации с пропорциями высоты 50 %, 100 % и 200 %. Позиция, ширина и высота диаграммы остаются фиксированными. Данные, вращение, глубина, расстояние между сериями и форматирование одинаковы во всех трёх файлах; меняется только процент высоты.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (const heightPercent of [50, 100, 200]) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Ниже представлены изображения, иллюстрирующие одинаковые настройки высоты в эквивалентном примере .NET, экспортированные с помощью Microsoft PowerPoint. Меньший процент создаёт более плоскую сцену, больший — более высокую сцену в пределах того же объекта диаграммы. PowerPoint также может корректировать интервалы делений осей и размещение меток, чтобы вписать сцену.

| Высота: 50 % | Высота: 100 % | Высота: 200 % |
| --- | --- | --- |
| ![3D‑столбчатая диаграмма с высотой 50 % от её ширины](height_percent_50.png) | ![3D‑столбчатая диаграмма с высотой 100 % от её ширины](height_percent_100.png) | ![3D‑столбчатая диаграмма с высотой 200 % от её ширины](height_percent_200.png) |

Эти методы управляют разными аспектами диаграммы:

| Метод | Эффект |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | Высота 3D‑сцены в процентах от её ширины. |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | Высота объекта диаграммы на слайде в пунктах. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Глубина 3D‑сцены в процентах от её ширины. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Расстояние между сериями вдоль оси глубины, в процентах от ширины маркера. |

Настройка высоты влияет на 3D‑столбчатые и 3D‑барные диаграммы, включая варианты цилиндр, конус и пирамида, а также 3D‑линейные, областные, круговые и поверхностные диаграммы. Сравнение выше использует проверенный тип `Column3D`. Настройка не меняет внешний вид 2D‑диаграммы `ClusteredColumn` или `BubbleWith3D`; эти имена являются членами класса [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). Для остальных параметров внешнего вида диаграммы см. [Chart Formatting](/slides/ru/nodejs-java/chart-formatting/).

## **Отрегулировать зазор между сериями**

Используйте [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) для управления расстоянием между сериями данных вдоль оси глубины 3D‑диаграммы, выраженным в процентах от ширины маркера. Принимаются значения от **0 до 500**, включительно: `0` удаляет зазор, более высокие значения увеличивают его. При фиксированной глубине диаграммы увеличение зазора делает маркеры уже вдоль оси глубины.

Получите группу через [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/). Настройка применяется ко всем сериям в этой группе, а не только к серии, через которую она получена. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) возвращает текущий зазор по глубине и отражает настройку родительской группы.

Эта настройка влияет на 3D‑столбчатые и 3D‑барные диаграммы, включая их цилиндрические, конусные и пирамидальные варианты, а также 3D‑линейные и областные диаграммы. Внешний вид зависит от того, расположены ли серии в глубину, сгруппированы или стэкуются. Для наглядного сравнения зазоров между отдельными сериями используйте `ChartType.Column3D` из класса [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/).

Эти методы управляют разными аспектами диаграммы:

| Метод | Эффект |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Расстояние между сериями вдоль оси глубины, в процентах от ширины маркера. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | Расстояние между соседними кластерами столбцов или полос, в процентах от их ширины. |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Общая глубина диаграммы, в процентах от её ширины. |

Ниже представлено самостоятельное примерное приложение, использующее данные диаграммы по умолчанию (три серии и четыре категории). Оно сохраняет две презентации с одинаковыми данными, вращением, шириной зазора и глубиной диаграммы; меняется только зазор по глубине.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    const series = chart.getChartData().getSeries().get_Item(0);
    const group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (const gapDepth of [0, 500]) {
        group.setGapDepth(gapDepth);

        const fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Следующие изображения иллюстрируют одинаковые настройки зазора по глубине в эквивалентном примере .NET и экспортированы с помощью Microsoft PowerPoint.

| Зазор по глубине: 0 % | Зазор по глубине: 500 % |
| --- | --- |
| ![3D‑столбчатая диаграмма без зазора между сериями вдоль оси глубины](gap_depth_0.png) | ![3D‑столбчатая диаграмма с зазором 500 % между сериями вдоль оси глубины](gap_depth_500.png) |

## **Изменить тип 3D‑сериии и форму столбца**

В кластеризованной цилиндрической диаграмме первая серия начинается с цилиндрической формы столбца. Пример выводит целочисленные значения, возвращаемые методами [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) и [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) до и после каждого изменения. Таблица содержит соответствующие имена констант.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.ClusteredCylinder, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setType(slides.ChartType.ClusteredCone);
    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(slides.ChartShapeType.Box);
    console.log(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Изменение первой серии | Тип серии | Форма столбца |
| --- | --- | --- |
| Создание диаграммы | `ClusteredCylinder` | `Cylinder` |
| Установка типа серии в `ClusteredCone` | `ClusteredCone` | `Cone` |
| Установка формы столбца в `Box` | `ClusteredColumn3D` | `Box` |

Установка формы `Box` также меняет тип серии на `ClusteredColumn3D`. Если ваш код ветвится по типу серии, вызывайте `series.getType()` после изменения формы. Значение, полученное до присвоения, всё равно выберет ветку `ClusteredCone`.

![Сравнение PowerPoint, показывающее первую серию как цилиндры, конусы и прямоугольные колонки слева направо](series-shapes.png)

## **FAQ**

**Какие типы диаграмм поддерживают 3D‑режим в Aspose.Slides?**

Aspose.Slides поддерживает 3D‑варианты столбчатых диаграмм, включая Column 3D, Clustered Column 3D, Stacked Column 3D и 100 % Stacked Column 3D, а также связанные 3D‑типы, представленные в классе [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). Для точного актуального списка проверьте члены [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) в справочнике API установленной версии.

**Можно ли получить растровое изображение 3D‑диаграммы для отчёта или веба?**

Да. Вы можете экспортировать диаграмму в изображение с помощью [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) или [render the entire slide](/slides/ru/nodejs-java/convert-powerpoint-to-png/) в форматы PNG или JPEG. Это удобно, когда нужен растровый предварительный просмотр или требуется внедрить диаграмму в документы, дашборды или веб‑страницы без необходимости использовать PowerPoint.

**Насколько производительно построение и рендеринг больших 3D‑диаграмм?**

Производительность зависит от объёма данных и визуальной сложности. Для оптимальных результатов держите 3D‑эффекты минимальными, избегайте тяжёлых текстур на стенах и областях построения, по возможности ограничивайте количество точек данных в серии и рендерьте в размер, соответствующий целевому экрану или печати.