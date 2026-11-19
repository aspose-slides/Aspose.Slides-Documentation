---
title: Настройка 3D‑диаграмм в презентациях с помощью JavaScript
linktitle: 3D Диаграмма
type: docs
url: /ru/nodejs-java/3d-chart/
keywords:
- 3D диаграмма
- вращение
- глубина
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Создавайте 3D‑диаграммы в презентациях PowerPoint с помощью Aspose.Slides for Node.js via Java. Регулируйте вращение, пропорции высоты, глубину диаграммы и расстояние между сериями с примерами на JavaScript."
---
## **Обзор**

Aspose.Slides for Node.js via Java позволяет настроить вид 3D‑диаграммы с помощью метода [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/) . Эта статья демонстрирует, как изменить вращение, пропорции высоты, глубину, оси под прямым углом и расстояние между сериями, а затем сохранить презентацию в формате PPTX.

## **Установить вращение и глубину 3D‑диаграммы**

Пример ниже создает [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) и использует [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) , чтобы добавить наложенную 3D‑столбчатую диаграмму на первый слайд. Он заменяет серии и категории по умолчанию двумя сериями, каждая из которых содержит по три значения. Индекс листа `0` указывает на первый лист данных диаграммы; строка `0` содержит имена серий, а столбец `0` — подписи категорий.

Методы [setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) и [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) задают вращение диаграммы соответственно 40 и 270 градусов. [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) устанавливает глубину равной 150 % от её ширины, а [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) включает оси под прямым углом вместо перспективы. Получившаяся презентация содержит заполненную диаграмму с этими настройками 3D‑вида.

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

## **Настроить пропорции высоты 3D‑диаграммы**

Используйте [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) , чтобы задать высоту 3D‑диаграммы в процентах от её ширины. Это изменяет пропорции 3D‑сцены без изменения размеров объекта диаграммы на слайде.

Следующий пример создает диаграмму [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) , используя данные по умолчанию: три серии и четыре категории. Он сохраняет три презентации с пропорциями высоты 50 %, 100 % и 200 %. Позиция, ширина и высота диаграммы остаются фиксированными. Данные, вращение, глубина, расстояние между сериями и форматирование одинаковы во всех трёх файлах; изменяется только процент высоты.

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

Ниже показаны изображения, иллюстрирующие одинаковые настройки высоты в эквивалентном примере .NET, экспортированные с помощью Microsoft PowerPoint. Меньший процент создает более плоскую сцену, а больший процент — более высокую сцену внутри того же объекта диаграммы. PowerPoint также может корректировать интервалы деления осей и размещение меток, чтобы вписать сцену.

| Высота: 50% | Высота: 100% | Высота: 200% |
| --- | --- | --- |
| ![3D столбчатая диаграмма с высотой, установленной в 50 % от её ширины](height_percent_50.png) | ![3D столбчатая диаграмма с высотой, установленной в 100 % от её ширины](height_percent_100.png) | ![3D столбчатая диаграмма с высотой, установленной в 200 % от её ширины](height_percent_200.png) |

Эти методы управляют различными аспектами диаграммы:

| Метод | Эффект |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | Высота 3D‑сцены в процентах от её ширины. |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | Высота объекта диаграммы на слайде, в пунктах. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Глубина 3D‑сцены в процентах от её ширины. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Расстояние между сериями вдоль оси глубины, в процентах от ширины маркера. |

Настройка высоты влияет на 3D‑столбчатые и 3D‑полосовые диаграммы, включая варианты цилиндрических, конусных и пирамидальных, а также на 3D‑линейные, площадные, круговые и поверхностные диаграммы. Сравнение выше использует проверенный тип `Column3D`. Эта настройка не меняет внешний вид 2D‑диаграммы `ClusteredColumn` или `BubbleWith3D`; эти названия являются членами класса [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) . Для других настроек внешнего вида диаграмм см. [Chart Formatting](/slides/ru/nodejs-java/chart-formatting/) .

## **Настроить зазор между сериями**

Используйте [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) , чтобы управлять расстоянием между сериями данных вдоль оси глубины 3D‑диаграммы, выраженным в процентах от ширины маркера. Допустимые значения от **0 до 500**, включительно: `0` удаляет зазор, а большие значения увеличивают расстояние. При фиксированной глубине диаграммы увеличение зазора делает маркеры уже вдоль оси глубины.

Обратитесь к группе через [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) . Эта настройка применяется ко всем сериям в группе, а не только к серии, через которую доступ выполнен. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) возвращает зазор по глубине и отражает настройку родительской группы.

Эта настройка влияет на 3D‑столбчатые и 3D‑полосовые диаграммы, включая их цилиндрические, конусные и пирамидальные варианты, а также 3D‑линейные и площадные диаграммы. Вид зависит от того, расположены ли серии в глубине, сгруппированы или наложены. Для наглядного сравнения зазоров между отдельными сериями используйте `ChartType.Column3D` из класса [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) .

Эти методы управляют различными аспектами диаграммы:

| Метод | Эффект |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Расстояние между сериями вдоль оси глубины, в процентах от ширины маркера. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | Расстояние между соседними кластерами столбцов или полос, в процентах от ширины столбца или полосы. |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Общая глубина диаграммы в процентах от её ширины. |

Следующий автономный пример использует данные диаграммы по умолчанию, содержащие три серии и четыре категории. Он сохраняет две презентации с одинаковыми данными, вращением, шириной зазора и глубиной диаграммы; меняется только зазор по глубине.

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

Ниже показаны изображения, иллюстрирующие одинаковые настройки зазора по глубине в эквивалентном примере .NET, экспортированные с помощью Microsoft PowerPoint.

| Зазор по глубине: 0% | Зазор по глубине: 500% |
| --- | --- |
| ![3D столбчатая диаграмма без зазора между сериями вдоль оси глубины](gap_depth_0.png) | ![3D столбчатая диаграмма с зазором 500 % между сериями вдоль оси глубины](gap_depth_500.png) |

## **Изменить тип 3D‑серии и форму столбцов**

В кластеризованной цилиндрической диаграмме первая серия начинается с цилиндрической формы столбца. Пример выводит целочисленные значения, возвращаемые методами [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) и [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) , до и после каждого изменения. Таблица содержит соответствующие имена констант.

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
| Create the chart | `ClusteredCylinder` | `Cylinder` |
| Set the series type to `ClusteredCone` | `ClusteredCone` | `Cone` |
| Set the bar shape to `Box` | `ClusteredColumn3D` | `Box` |

Установка формы `Box` также меняет тип серии на `ClusteredColumn3D`. Если ваш код ветвится по типу серии, вызовите `series.getType()` после изменения формы. Значение, закешированное до присвоения, всё равно выберет ветку `ClusteredCone` .

![Сравнение в PowerPoint, показывающее первую серию как цилиндры, конусы и прямоугольные столбцы слева направо](series-shapes.png)

## **FAQ**

**Какие типы диаграмм поддерживают 3D‑режим в Aspose.Slides?**

Aspose.Slides поддерживает 3D‑варианты столбчатых диаграмм, включая Column 3D, Clustered Column 3D, Stacked Column 3D и 100 % Stacked Column 3D, а также связанные 3D‑типы, представленные классом [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) . Для точного актуального списка проверьте члены [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) в справочнике API установленной версии.

**Можно ли получить растровое изображение 3D‑диаграммы для отчёта или веба?**

Да. Вы можете экспортировать диаграмму в изображение с помощью [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) или [отрисовать весь слайд](/slides/ru/nodejs-java/convert-powerpoint-to-png/) в такие форматы, как PNG или JPEG. Это полезно, когда нужен растровый предварительный просмотр или требуется внедрить диаграмму в документы, панели мониторинга или веб‑страницы без необходимости в PowerPoint.

**Насколько эффективно построение и рендеринг больших 3D‑диаграмм?**

Производительность зависит от объёма данных и визуальной сложности. Для наилучших результатов минимизируйте 3D‑эффекты, избегайте тяжёлых текстур на стенах и областях построения, при возможности ограничивайте количество точек данных в серии и рендерьте в выходной файл подходящего размера (разрешения и габаритов), соответствующего целевому отображению или требованиям печати.