---
title: Настройка 3D‑диаграмм в презентациях в .NET
linktitle: 3D‑диаграмма
type: docs
url: /ru/net/3d-chart/
keywords:
- 3D‑диаграмма
- вращение
- глубина
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Создавайте 3D‑диаграммы в презентациях PowerPoint с помощью Aspose.Slides для .NET. Регулируйте вращение, пропорции высоты, глубину диаграммы и расстояние между рядами с примерами на C#."
---
## **Обзор**

Aspose.Slides for .NET позволяет вам настраивать вид 3D‑диаграммы через свойство [IChart.Rotation3D](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/rotation3d/) . Эта статья демонстрирует, как регулировать вращение, пропорции высоты, глубину, оси под прямым углом и расстояние между рядами, а затем сохранить презентацию в формате PPTX.

## **Установить вращение и глубину 3D‑диаграммы**

Пример ниже создаёт объект [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) и использует [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) для добавления сложенной 3D‑колоночной диаграммы на первый слайд. Он заменяет стандартные ряды и категории двумя рядами, каждый из которых содержит три значения. Индекс листа `0` указывает на первый лист данных диаграммы; строка `0` содержит имена рядов, а столбец `0` — подписи категорий.

Свойства [RotationX](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationx/) и [RotationY](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationy/) задают вращение диаграммы соответственно на 40 и 270 градусов. Свойство [DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) устанавливает её глубину в 150 % от ширины, а [RightAngleAxes](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rightangleaxes/) включает оси под прямым углом вместо перспективы. В результате презентация содержит заполненную диаграмму с этими настройками 3D‑вида.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

var values = new double[,] { { 20, 50, 30 }, { 30, 10, 60 } };

for (var categoryIndex = 0; categoryIndex < 3; categoryIndex++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, categoryIndex + 1, 0, $"Category {categoryIndex + 1}");
    chart.ChartData.Categories.Add(categoryCell);
}

for (var seriesIndex = 0; seriesIndex < 2; seriesIndex++)
{
    var seriesCell = workbook.GetCell(worksheetIndex, 0, seriesIndex + 1, $"Series {seriesIndex + 1}");
    var series = chart.ChartData.Series.Add(seriesCell, chart.Type);

    for (var categoryIndex = 0; categoryIndex < 3; categoryIndex++)
    {
        var valueCell = workbook.GetCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex, categoryIndex]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }
}

chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```

## **Применить заливку изображением к поверхности 3D‑диаграммы**

У 3D‑диаграммы три поверхности, которые можно заполнять независимо: [side wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/sidewall/), [back wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) и [floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/). Установите для выбранной поверхности тип заливки [fill type](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) `Picture` и задайте изображение. Установите как [picture fill mode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/), так и тип изображения поверхности [picture type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartwall/picturetype/) в `Stretch`, чтобы один экземпляр изображения растянулся по всей поверхности.

Сохраните файл [arrow.png](arrow.png) в рабочем каталоге. Пример вращает диаграмму и увеличивает максимальное значение вертикальной оси, чтобы было видно пол между колоннами. Затем он клонирует слайд дважды, применяя стрелку к разной поверхности на каждом слайде. Все три диаграммы сохраняют одинаковые данные, угол просмотра и фон.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 20, 30, 680, 480);
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 30;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 24;

var backSlide = presentation.Slides.AddClone(slide);
var floorSlide = presentation.Slides.AddClone(slide);
var backChart = (IChart)backSlide.Shapes[0];
var floorChart = (IChart)floorSlide.Shapes[0];

var imageBytes = File.ReadAllBytes("arrow.png");
var arrow = presentation.Images.AddImage(imageBytes);

foreach (var surface in new[] { chart.SideWall, backChart.BackWall, floorChart.Floor })
{
    var fill = surface.Format.Fill;
    fill.FillType = FillType.Picture;
    fill.PictureFillFormat.Picture.Image = arrow;
    fill.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    surface.PictureType = PictureType.Stretch;
}

presentation.Save("chart-surfaces.pptx", SaveFormat.Pptx);
```

Microsoft PowerPoint отображает три слайда следующим образом.

| Боковая стена | Задняя стена | Пол |
| --- | --- | --- |
| ![Стрелка указывает в диаграмму вдоль боковой стены](side-wall.png) | ![Стрелка указывает вправо вдоль задней стены](back-wall.png) | ![Стрелка указывает вправо вдоль пола между колоннами](floor.png) |

## **Регулировка пропорций высоты 3D‑диаграммы**

Используйте [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) для задания высоты 3D‑диаграммы в процентах от её ширины. Это изменяет пропорции 3D‑сцены без изменения размеров объекта диаграммы на слайде.

В следующем примере создаётся диаграмма [Column3D](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) с данными по умолчанию: три ряда и четыре категории. Он сохраняет три презентации с пропорциями высоты 50 %, 100 % и 200 %. Позиция, ширина и высота диаграммы остаются фиксированными. Данные, вращение, глубина, зазор между рядами и форматирование одинаковы во всех трёх файлах; меняется только процент высоты.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 40, 30, 620, 460);
chart.Rotation3D.RotationX = 20;
chart.Rotation3D.RotationY = 30;
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.DepthPercents = 100;
chart.ChartData.Series[0].ParentSeriesGroup.GapDepth = 150;

foreach (ushort heightPercent in new ushort[] { 50, 100, 200 })
{
    chart.Rotation3D.HeightPercents = heightPercent;
    presentation.Save($"chart_height_{heightPercent}.pptx", SaveFormat.Pptx);
}
```

Следующие изображения экспортированы из сгенерированных презентаций с помощью Microsoft PowerPoint. Небольшой процент создаёт более плоскую сцену, а больший — более высокую сцену внутри того же объекта диаграммы. PowerPoint может также корректировать интервалы делений осей и размещение подписей, чтобы втиснуть сцену.

| Высота: 50% | Высота: 100% | Высота: 200% |
| --- | --- | --- |
| ![3D столбчатая диаграмма с высотой, установленной на 50 percent of its width](height_percent_50.png) | ![3D столбчатая диаграмма с высотой, установленной на 100 percent of its width](height_percent_100.png) | ![3D столбчатая диаграмма с высотой, установленной на 200 percent of its width](height_percent_200.png) |

Эти свойства управляют различными аспектами диаграммы:

| Свойство | Эффект |
| --- | --- |
| [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) | Высота 3D‑сцены в процентах от её ширины. |
| [IChart.Height](https://reference.aspose.com/slides/net/aspose.slides/ishape/height/) | Высота объекта диаграммы на слайде, в пунктах. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Глубина 3D‑сцены в процентах от её ширины. |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Расстояние между рядами вдоль оси глубины, в процентах от ширины маркера. |

Настройка высоты влияет на 3D‑столбчатые и 3D‑полосовые диаграммы, включая варианты цилиндр, конический и пирамидальный, а также 3D‑линейные, 3D‑облачные, 3D‑круговые и 3D‑поверхностные диаграммы. В примере используется проверенный тип `Column3D`. Настройка не меняет внешний вид 2D‑диаграммы `ClusteredColumn` или диаграммы `BubbleWith3D`; эти названия являются членами перечисления [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). Для других параметров внешнего вида диаграммы см. [Chart Formatting](/slides/ru/net/chart-formatting/).

## **Регулировать зазор между рядами**

Используйте [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) для управления расстоянием между рядами данных вдоль оси глубины 3D‑диаграммы, выраженным в процентах от ширины маркера. Допустимые значения от **0 до 500**, включительно: `0` удаляет зазор, более высокие значения увеличивают пространство. При фиксированной глубине диаграммы увеличение зазора делает маркеры более тонкими вдоль оси глубины.

Получить доступ к группе можно через [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/). Настройка применяется ко всем рядам в этой группе, а не только к тому ряду, через который выполнен доступ. Свойство [IChartSeries.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/gapdepth/) лишь для чтения и отражает настройку родительской группы.

Эта настройка влияет на 3D‑столбчатые и 3D‑полосовые диаграммы, включая их цилиндрические, конические и пирамидальные варианты, а также 3D‑линейные и 3D‑облачные диаграммы. Внешний вид зависит от того, расположены ли ряды в глубину, сгруппированы или сложены. Для наглядного сравнения зазоров между отдельными рядами используйте `ChartType.Column3D` из перечисления [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/).

Эти свойства управляют различными аспектами диаграммы:

| Свойство | Эффект |
| --- | --- |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Расстояние между рядами вдоль оси глубины, в процентах от ширины маркера. |
| [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) | Расстояние между соседними кластерами баров или колонн, в процентах от их ширины. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Общая глубина диаграммы, в процентах от её ширины. |

Следующий самостоятельный пример использует данные диаграммы по умолчанию (три ряда и четыре категории). Он сохраняет две презентации с одинаковыми данными, вращением, шириной зазора и глубиной диаграммы; меняется только глубина зазора.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 40, 30, 620, 230);

chart.Rotation3D.RotationX = 20;
chart.Rotation3D.RotationY = 30;
chart.Rotation3D.DepthPercents = 100;

var series = chart.ChartData.Series[0];
var group = series.ParentSeriesGroup;
group.GapWidth = 150;

foreach (ushort gapDepth in new ushort[] { 0, 500 })
{
    group.GapDepth = gapDepth;

    var fileName = $"series_gap_depth_{gapDepth}.pptx";
    presentation.Save(fileName, SaveFormat.Pptx);

}
```

Следующие изображения экспортированы из сгенерированных презентаций с помощью Microsoft PowerPoint.

| Глубина зазора: 0% | Глубина зазора: 500% |
| --- | --- |
| ![3D столбчатая диаграмма без зазора между рядами вдоль оси глубины](gap_depth_0.png) | ![3D столбчатая диаграмма с зазором 500 % между рядами вдоль оси глубины](gap_depth_500.png) |

## **Изменить тип 3D‑ряда и форму столбца**

В сгруппированной цилиндрической диаграмме первый ряд начинается с цилиндрической формы столбца. Пример считывает [IChartSeries.Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/type/) и [IChartSeries.Bar3DShape](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/bar3dshape/) до и после каждого изменения.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
var series = chart.ChartData.Series[0];

Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

series.Type = ChartType.ClusteredCone;
Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

series.Bar3DShape = ChartShapeType.Box;
Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

presentation.Save("series_shape.pptx", SaveFormat.Pptx);
```

| Изменить первый ряд | `Type` | `Bar3DShape` |
| --- | --- | --- |
| Создание диаграммы | `ClusteredCylinder` | `Cylinder` |
| Установить `Type` в `ClusteredCone` | `ClusteredCone` | `Cone` |
| Установить `Bar3DShape` в `Box` | `ClusteredColumn3D` | `Box` |

Установка формы в `Box` также меняет тип ряда на `ClusteredColumn3D`. Если ваш код ветвится в зависимости от типа ряда, считывайте `series.Type` после изменения формы. Значение, полученное до назначения, всё равно выберет ветку `ClusteredCone`.

![Сравнение в PowerPoint, показывающее первый ряд как цилиндры, конусы и прямоугольные столбцы слева направо](series-shapes.png)

## **Вопросы и ответы**

**Какие типы диаграмм поддерживают 3D‑режим в Aspose.Slides?**

Aspose.Slides поддерживает 3D‑варианты столбчатых диаграмм, включая Column 3D, Clustered Column 3D, Stacked Column 3D и 100 % Stacked Column 3D, а также связанные 3D‑типы, объявленные в перечислении [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). Точный актуальный список смотрите в членах [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) в справочнике API вашей установленной версии.

**Могу ли я получить растровое изображение 3D‑диаграммы для отчёта или веба?**

Да. Вы можете экспортировать диаграмму в изображение с помощью [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) или [отрендерить весь слайд](/slides/ru/net/convert-powerpoint-to-png/) в форматы PNG или JPEG. Это удобно, когда нужен растровый предварительный просмотр или требуется внедрить диаграмму в документы, приборные панели или веб‑страницы без необходимости использовать PowerPoint.

**Насколько производительно построение и рендеринг больших 3D‑диаграмм?**

Производительность зависит от объёма данных и визуальной сложности. Для наилучших результатов минимизируйте 3D‑эффекты, избегайте тяжёлой текстуры на стенах и областях построения, по возможности ограничьте количество точек данных в ряде и отрисовывайте в подходящем разрешении и размерах, соответствующих целевому дисплею или печати.