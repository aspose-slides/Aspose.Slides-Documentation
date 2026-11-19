---
title: Настройка 3D-диаграмм в презентациях с помощью PHP
linktitle: 3D-диаграмма
type: docs
url: /ru/php-java/3d-chart/
keywords:
- 3D-диаграмма
- вращение
- глубина
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Создавайте 3D-диаграммы в презентациях PowerPoint с помощью Aspose.Slides для PHP через Java. Регулируйте вращение, пропорции высоты, глубину диаграммы и расстояние между сериями в примерах на PHP."
---
## **Обзор**

Aspose.Slides for PHP via Java позволяет настраивать вид 3D‑диаграммы с помощью метода [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D). В этой статье показано, как изменить вращение, пропорции высоты, глубину, оси под прямым углом и расстояние между сериями, а затем сохранить презентацию в формате PPTX.

## **Установить вращение и глубину 3D‑диаграммы**

В приведённом ниже примере создаётся объект [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) и с помощью [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) добавляется сложенная 3D‑столбчатая диаграмма на первый слайд. Он заменяет серии и категории по умолчанию двумя сериями, каждая из которых содержит три значения. Индекс листа `0` указывает на первый лист данных диаграммы; строка `0` содержит имена серий, а столбец `0` — подписи категорий.

Методы [setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) и [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) устанавливают вращение диаграммы соответственно на 40 и 270 градусов. [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) задаёт её глубину как 150 % от ширины, а [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) включает оси под прямым углом вместо перспективы. Получившаяся презентация содержит заполненную диаграмму с этими настройками 3D‑вида.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $values = [[20, 50, 30], [30, 10, 60]];

    for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, 0, "Category " . ($categoryIndex + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    for ($seriesIndex = 0; $seriesIndex < 2; $seriesIndex++) {
        $seriesCell = $workbook->getCell($worksheetIndex, 0, $seriesIndex + 1, "Series " . ($seriesIndex + 1));
        $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());

        for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
            $valueCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, $seriesIndex + 1, $values[$seriesIndex][$categoryIndex]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }
    }

    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);

    $presentation->save("Rotation3D_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Регулировка пропорций высоты 3D‑диаграммы**

Используйте [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) для задания высоты 3D‑диаграммы в процентах от её ширины. Это изменяет пропорции 3D‑сцены без изменения размеров объекта диаграммы на слайде.

В следующем примере создаётся диаграмма [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) с данными по умолчанию: три серии и четыре категории. Он сохраняет три презентации с пропорциями высоты 50 %, 100 % и 200 %. Позиция, ширина и высота диаграммы остаются фиксированными. Данные, вращение, глубина, расстояние между сериями и форматирование одинаковы во всех трёх файлах; меняется только процент высоты.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 460);
    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setDepthPercents(100);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setGapDepth(150);

    foreach ([50, 100, 200] as $heightPercent) {
        $chart->getRotation3D()->setHeightPercents($heightPercent);
        $presentation->save("chart_height_" . $heightPercent . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Следующие изображения иллюстрируют одинаковые настройки высоты в эквивалентном примере .NET и были экспортированы с помощью Microsoft PowerPoint. Меньший процент создаёт более плоскую сцену, а больший процент — более высокую сцену внутри того же объекта диаграммы. PowerPoint может также корректировать интервалы делений осей и размещение меток, чтобы подогнать сцену.

| Высота: 50% | Высота: 100% | Высота: 200% |
| --- | --- | --- |
| ![3D‑столбчатая диаграмма с высотой, установленной в 50 % от её ширины](height_percent_50.png) | ![3D‑столбчатая диаграмма с высотой, установленной в 100 % от её ширины](height_percent_100.png) | ![3D‑столбчатая диаграмма с высотой, установленной в 200 % от её ширины](height_percent_200.png) |

Эти методы управляют различными аспектами диаграммы:

| Метод | Эффект |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | Высота 3D‑сцены в процентах от её ширины. |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | Высота объекта диаграммы на слайде в пунктах. |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Глубина 3D‑сцены в процентах от её ширины. |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Расстояние между сериями вдоль оси глубины в процентах от ширины маркера. |

Настройка высоты влияет на 3D‑столбчатые и 3D‑гистограммные диаграммы, включая варианты цилиндр, конус и пирамида, а также 3D‑линейные, 3D‑плоские, 3D‑круговые и 3D‑поверхностные диаграммы. Приведённое сравнение использует проверенный тип `Column3D`. Эта настройка не меняет внешний вид 2D‑диаграммы `ClusteredColumn` или диаграммы `BubbleWith3D`; эти имена являются членами класса [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). Для других настроек внешнего вида диаграмм см. [Chart Formatting](/slides/ru/php-java/chart-formatting/).

## **Регулировка промежутка между serиями**

Используйте [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) для управления расстоянием между данными сериями вдоль оси глубины 3D‑диаграммы, выраженным в процентах от ширины маркера. Допускаются значения от **0 до 500**, включительно: `0` удаляет промежуток, а большие значения увеличивают расстояние. При фиксированной глубине диаграммы увеличение промежутка делает маркеры более тонкими вдоль оси глубины.

Получить группу можно через [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup). Эта настройка применяется ко всем сериям в группе, а не только к серии, через которую был выполнен доступ. [ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) возвращает значение промежутка по глубине и отражает настройку родительской группы.

Эта настройка влияет на 3D‑столбчатые и 3D‑гистограммные диаграммы, включая их варианты цилиндр, конус и пирамида, а также 3D‑линейные и 3D‑плоские диаграммы. Вид зависит от того, расположены ли серии по глубине, сгруппированы или сложены. Для наглядного сравнения промежутков между отдельными сериями используйте `ChartType::Column3D` из класса [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/).

Эти методы управляют различными аспектами диаграммы:

| Метод | Эффект |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Расстояние между сериями вдоль оси глубины в процентах от ширины маркера. |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | Расстояние между соседними группами столбцов или гистограмм в процентах от ширины столбца или гистограммы. |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Общая глубина диаграммы в процентах от её ширины. |

В приведённом ниже автономном примере используются данные диаграммы по умолчанию, содержащие три серии и четыре категории. Он сохраняет две презентации с одинаковыми данными, вращением, шириной промежутка и глубиной диаграммы; меняется только глубина промежутка.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 230);

    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setDepthPercents(100);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $group = $series->getParentSeriesGroup();
    $group->setGapWidth(150);

    foreach ([0, 500] as $gapDepth) {
        $group->setGapDepth($gapDepth);

        $fileName = "series_gap_depth_" . $gapDepth . ".pptx";
        $presentation->save($fileName, SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Следующие изображения иллюстрируют одинаковые настройки глубины промежутка в эквивалентном примере .NET и были экспортированы с помощью Microsoft PowerPoint.

| Глубина промежутка: 0% | Глубина промежутка: 500% |
| --- | --- |
| ![3D‑столбчатая диаграмма без промежутка между сериями вдоль оси глубины](gap_depth_0.png) | ![3D‑столбчатая диаграмма с промежутком 500 % между сериями вдоль оси глубины](gap_depth_500.png) |

## **Изменение типа серии 3D и формы столбца**

В сгруппированной цилиндрической диаграмме первая серия начинается с цилиндрической формы столбца. В примере выводятся целочисленные значения, возвращаемые [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) и [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) до и после каждого изменения. Таблица содержит соответствующие имена констант.

```php
use aspose\slides\ChartShapeType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setType(ChartType::ClusteredCone);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setBar3DShape(ChartShapeType::Box);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $presentation->save("series_shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Изменение первой серии | Тип серии | Форма столбца |
| --- | --- | --- |
| Создать диаграмму | `ClusteredCylinder` | `Cylinder` |
| Установить тип серии `ClusteredCone` | `ClusteredCone` | `Cone` |
| Установить форму столбца `Box` | `ClusteredColumn3D` | `Box` |

Установка формы `Box` также изменяет тип серии на `ClusteredColumn3D`. Если ваш код ветвится по типу серии, вызовите [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) после изменения формы. Значение, кэшированное до присваивания, всё равно будет выбирать ветку `ClusteredCone`.

![Сравнение PowerPoint, показывающее первую серию как цилиндры, конусы и прямоугольные столбцы слева направо](series-shapes.png)

## **FAQ**

**Какие типы диаграмм поддерживают 3D‑режим в Aspose.Slides?**

Aspose.Slides поддерживает 3D‑варианты столбчатых диаграмм, включая Column 3D, Clustered Column 3D, Stacked Column 3D и 100 % Stacked Column 3D, а также связанные 3D‑типы, доступные через класс [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). Для точного актуального списка проверьте члены [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) в справочнике API установленной версии.

**Могу ли я получить растровое изображение 3D‑диаграммы для отчёта или веба?**

Да. Вы можете экспортировать диаграмму в изображение с помощью [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) или [render the entire slide](/slides/ru/php-java/convert-powerpoint-to-png/) в форматы PNG или JPEG. Это полезно, когда нужен растровый превью или необходимо встроить диаграмму в документы, панели мониторинга или веб‑страницы без использования PowerPoint.

**Насколько производительно построение и рендеринг больших 3D‑диаграмм?**

Производительность зависит от объёма данных и визуальной сложности. Для лучшего результата минимизируйте 3D‑эффекты, избегайте тяжёлых текстур на стенах и областях построения, по возможности ограничивайте количество точек данных в каждой серии и рендерите в вывод подходящего размера (разрешения и размеров), соответствующего целевому дисплею или печати.