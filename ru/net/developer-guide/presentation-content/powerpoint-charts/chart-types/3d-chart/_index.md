---
title: Настройка 3D‑диаграмм в презентациях на .NET
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
description: "Создавайте 3D‑диаграммы в презентациях PowerPoint с помощью Aspose.Slides для .NET. Регулируйте вращение, пропорции высоты, глубину диаграммы и расстояние между сериями с примерами на C#."
---
## **Обзор**

Aspose.Slides for .NET позволяет настраивать представление 3D‑диаграммы через свойство [IChart.Rotation3D](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/rotation3d/) . В этой статье демонстрируется, как изменить вращение, пропорции высоты, глубину, прямоугольные оси и расстояние между рядом, а затем сохранить презентацию в формате PPTX.

## **Установка вращения и глубины 3D‑диаграммы**

Приведённый ниже пример создаёт [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) и использует [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) для добавления сложенной 3D‑столбчатой диаграммы на первый слайд. Он заменяет серии и категории по умолчанию двумя сериями, содержащими по три значения каждая. Индекс листа `0` указывает на первый лист данных диаграммы; строка `0` содержит имена серий, а столбец `0` — метки категорий. 

Свойства [RotationX](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationx/) и [RotationY](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationy/) задают вращение диаграммы соответственно 40 и 270 градусов. [DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) устанавливает её глубину равной 150 % ширины, а [RightAngleAxes](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rightangleaxes/) включает прямоугольные оси вместо перспективы. Получившаяся презентация содержит диаграмму с этими настройками 3D‑вида.

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

## **Настройка пропорций высоты 3D‑диаграммы**

Используйте [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) чтобы задать высоту 3D‑диаграммы в процентах от её ширины. Это изменяет пропорции 3D‑сцены без изменения размеров объекта диаграммы на слайде. 

Следующий пример создаёт диаграмму [Column3D](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) с данными по умолчанию: три серии и четыре категории. Он сохраняет три презентации с пропорциями высоты 50 %, 100 % и 200 %. Позиция, ширина и высота диаграммы остаются фиксированными. Данные, вращение, глубина, расстояние между сериями и форматирование в всех трёх файлах одинаковы; меняется только процент высоты. 

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

Следующие изображения были экспортированы из сгенерированных презентаций с помощью Microsoft PowerPoint. Более малый процент создаёт более плоскую сцену, а больший процент — более высокую сцену внутри того же объекта диаграммы. PowerPoint также может корректировать интервалы делений осей и размещение подписей, чтобы подогнать сцену. 

| Высота: 50% | Высота: 100% | Высота: 200% |
| --- | --- | --- |
| ![3D‑столбчатая диаграмма с высотой, установленной на 50% от её ширины](height_percent_50.png) | ![3D‑столбчатая диаграмма с высотой, установленной на 100% от её ширины](height_percent_100.png) | ![3D‑столбчатая диаграмма с высотой, установленной на 200% от её ширины](height_percent_200.png) |

Эти свойства управляют различными аспектами диаграммы:

| Свойство | Эффект |
| --- | --- |
| [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) | Высота 3D‑сцены в процентах от её ширины. |
| [IChart.Height](https://reference.aspose.com/slides/net/aspose.slides/ishape/height/) | Высота объекта диаграммы на слайде, в пунктах. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Глубина 3D‑сцены в процентах от её ширины. |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Расстояние между сериями вдоль оси глубины в процентах от ширины маркера. |

Настройка высоты влияет на 3D‑столбчатые и 3D‑гистограммы, включая варианты цилиндра, конуса и пирамиды, а также 3D‑линейные, площадные, круговые и поверхностные диаграммы. Сравнение выше использует проверенный тип `Column3D`. Настройка не меняет внешний вид 2D‑диаграммы `ClusteredColumn` или диаграммы `BubbleWith3D`; эти имена являются членами перечисления [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) . Для других параметров внешнего вида диаграмм см. [Форматирование диаграмм](/slides/ru/net/chart-formatting/).

## **Настройка промежутка между сериями**

Используйте [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) , чтобы задать расстояние между сериями данных вдоль оси глубины 3D‑диаграммы, выраженное в процентах от ширины маркера. Используйте значения от **0 до 500**, включительно: `0` убирает промежуток, а большие значения увеличивают расстояние. При фиксированной глубине диаграммы увеличение промежутка делает маркеры более тонкими вдоль оси глубины. 

Получите доступ к группе через [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/). Настройка применяется ко всем сериям в этой группе, а не только к серии, через которую к ней обращаются. [IChartSeries.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/gapdepth/) только для чтения и отражает значение группы‑родителя. 

Эта настройка влияет на 3D‑столбчатые и 3D‑гистограммы, включая их варианты цилиндра, конуса и пирамиды, а также 3D‑линейные и площадные диаграммы. Внешний вид зависит от того, расположены ли серии в глубину, сгруппированы или сложены. Для наглядного сравнения промежутков между отдельными сериями используйте `ChartType.Column3D` из перечисления [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) . 

Эти свойства управляют различными аспектами диаграммы:

| Свойство | Эффект |
| --- | --- |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Расстояние между сериями вдоль оси глубины в процентах от ширины маркера. |
| [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) | Расстояние между соседними кластерами столбцов или гистограмм в процентах от их ширины. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Общая глубина диаграммы в процентах от её ширины. |

Следующий автономный пример использует данные диаграммы по умолчанию, содержащие три серии и четыре категории. Он сохраняет две презентации с одинаковыми данными, вращением, шириной промежутка и глубиной диаграммы; меняется только глубина промежутка. 

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

Следующие изображения были экспортированы из сгенерированных презентаций с помощью Microsoft PowerPoint. 

| Глубина промежутка: 0% | Глубина промежутка: 500% |
| --- | --- |
| ![3D‑столбчатая диаграмма без промежутка между сериями вдоль оси глубины](gap_depth_0.png) | ![3D‑столбчатая диаграмма с промежутком 500% между сериями вдоль оси глубины](gap_depth_500.png) |

## **Изменение типа 3D‑серии и формы столбца**

В сгруппированной цилиндрической диаграмме первая серия начинается с цилиндрической формы столбца. Пример считывает [IChartSeries.Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/type/) и [IChartSeries.Bar3DShape](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/bar3dshape/) до и после каждого изменения. 

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

| Изменение первой серии | `Type` | `Bar3DShape` |
| --- | --- | --- |
| Создать диаграмму | `ClusteredCylinder` | `Cylinder` |
| Установить `Type` в `ClusteredCone` | `ClusteredCone` | `Cone` |
| Установить `Bar3DShape` в `Box` | `ClusteredColumn3D` | `Box` |

Установка формы `Box` также изменяет тип серии на `ClusteredColumn3D`. Если ваш код ветвится в зависимости от типа серии, считывайте `series.Type` после изменения формы. Значение, закешированное до присвоения, всё равно выберет ветку `ClusteredCone`. 

![Сравнение PowerPoint, показывающее первую серию в виде цилиндров, конусов и прямоугольных столбцов слева направо](series-shapes.png)

## **FAQ**

**Какие типы диаграмм поддерживают 3D‑режим в Aspose.Slides?**

Aspose.Slides поддерживает 3D‑варианты столбчатых диаграмм, включая Column 3D, Clustered Column 3D, Stacked Column 3D и 100 % Stacked Column 3D, а также связанные 3D‑типы, перечисленные в перечислении [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) . Чтобы получить точный актуальный список, проверьте члены [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) в API‑справочнике установленной версии.  

**Можно ли получить растровое изображение 3D‑диаграммы для отчёта или веба?**

Да. Вы можете экспортировать диаграмму в изображение с помощью [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) или [рендерить весь слайд](/slides/ru/net/convert-powerpoint-to-png/) в форматы PNG или JPEG. Это полезно, когда нужен растровый предварительный просмотр или требуется внедрить диаграмму в документы, панели мониторинга или веб‑страницы без необходимости использовать PowerPoint.  

**Насколько производительно создание и рендеринг больших 3D‑диаграмм?**

Производительность зависит от объёма данных и визуальной сложности. Чтобы получить лучшие результаты, сведите 3D‑эффекты к минимуму, избегайте тяжёлых текстур на стенах и областях построения, по возможности ограничьте количество точек данных в серии и рендерьте в вывод подходящего размера (разрешение и размеры), соответствующего целевому отображению или печати.