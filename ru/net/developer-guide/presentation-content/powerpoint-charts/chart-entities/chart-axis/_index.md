---
title: Настройка осей диаграмм в презентациях на .NET
linktitle: Ось диаграммы
type: docs
url: /ru/net/chart-axis/
keywords:
- ось диаграммы
- вертикальная ось
- горизонтальная ось
- настройка оси
- манипулировать осью
- управление осью
- свойства оси
- максимальное значение
- минимальное значение
- линия оси
- формат даты
- заголовок оси
- позиция оси
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как использовать Aspose.Slides для .NET, чтобы настроить оси диаграмм в презентациях PowerPoint для отчетов и визуализаций."
---
## **Обзор**

Эта статья объясняет, как настраивать оси диаграмм с помощью Aspose.Slides для .NET. Она охватывает рассчитанные значения осей, переключение строк и столбцов диаграммы, видимость осей, интервалы меток категорий и делений, датированные категории и их форматирование, поворот заголовка, положение оси, единицы отображения и логарифмическое масштабирование.

## **Получить максимальные значения на вертикальной оси диаграмм**

Создайте [Презентацию](https://reference.aspose.com/slides/net/aspose.slides/presentation/) и добавьте областную диаграмму с данными по умолчанию. Вызовите [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) перед чтением рассчитанных значений осей, чтобы макет диаграммы был актуален.

Прочитайте [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) и [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) для пределов оси, а также [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) и [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) для интервалов делений. [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) и [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) предоставляют шкалы единиц времени, актуальные для датированных осей. Пример сохраняет эти значения в локальные переменные и сохраняет диаграмму.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
chart.ValidateChartLayout();

var maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
var minValue = chart.Axes.VerticalAxis.ActualMinValue;

var majorUnit = chart.Axes.VerticalAxis.ActualMajorUnit;
var minorUnit = chart.Axes.VerticalAxis.ActualMinorUnit;

var majorUnitScale = chart.Axes.VerticalAxis.ActualMajorUnitScale;
var minorUnitScale = chart.Axes.VerticalAxis.ActualMinorUnitScale;

presentation.Save("AxisValues_out.pptx", SaveFormat.Pptx);
```

## **Поменять данные между осями**

Используйте [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) для обмена ролями рядов и категорий в данных диаграммы. Каждая прежняя категория становится рядом, а каждый прежний ряд становится категорией. Это меняет способ группировки данных; оси горизонтальная и вертикальная при этом не меняются местами. Пример использует [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) для привязки данных по умолчанию к `Sheet1!A1:D5`, включая строку заголовка и столбец категорий, перед переключением строк и столбцов. Сохраняется диаграмма с четырьмя рядами и тремя категориями.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

chart.ChartData.SetRange("Sheet1!A1:D5");
chart.ChartData.SwitchRowColumn();

presentation.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
```

## **Обратить порядок построения оси**

Используйте [IsPlotOrderReversed](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isplotorderreversed/) для обращения категории или оси значений. Например, горизонтальная гистограмма может показывать стадии проекта сверху вниз в том же порядке, что и лист: Планирование, Разработка, Тестирование. Обращение оси меняет направление построения; оно не сортирует и не переставляет данные листа. Для сравнения, [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) меняет роли рядов и категорий.

Ниже приведён пример, создающий горизонтальную гистограмму с тремя стадиями и одним рядом. Он сохраняет презентацию из трёх слайдов: обычный порядок, обратные категории и обратные значения. Каждая копия использует одинаковый набор данных, и на каждой копии обращена только одна ось.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredBar, 50, 40, 620, 320);
chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredBar);
var stages = new[] { "Planning", "Development", "Testing" };
var values = new[] { 10, 30, 20 };
for (var i = 0; i < stages.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, stages[i]);
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

// Слайд 2: отобразить первую категорию вверху.
var categorySlide = presentation.Slides.AddClone(slide);
var categoryChart = (IChart)categorySlide.Shapes[0];
categoryChart.Axes.VerticalAxis.IsPlotOrderReversed = true;
// Сохранить горизонтальную ось значений внизу.
categoryChart.Axes.VerticalAxis.CrossType = CrossesType.Maximum;

// Слайд 3: обратить только горизонтальную числовую шкалу.
var valueSlide = presentation.Slides.AddClone(slide);
var valueChart = (IChart)valueSlide.Shapes[0];
valueChart.Axes.HorizontalAxis.IsPlotOrderReversed = true;

presentation.Save("ReversedAxes.pptx", SaveFormat.Pptx);
```

Обращение оси также может переместить перпендикулярную ось на противоположную сторону графика. [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) управляет тем, где другая ось пересекает настроенную ось. На слайде 2 установка её в `Maximum` на обращённой оси категорий оставляет горизонтальную ось значений внизу. Для конкретной точки пересечения используйте [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Проверьте настройки пересечения при изменении направления, особенно если в диаграмме уже был пользовательский пункт пересечения. Установите `IsPlotOrderReversed` обратно в `false`, чтобы восстановить обычное направление построения; настройки пересечения остаются отдельными.

| Обычный порядок (слайд 1) | Обратные категории (слайд 2) | Обратные значения (слайд 3) |
| --- | --- | --- |
| ![Горизонтальная гистограмма с обычным порядком категорий и оси значений](axis-order-normal.png) | ![Горизонтальная гистограмма с категориями, отображаемыми сверху вниз](axis-order-categories-reversed.png) | ![Горизонтальная гистограмма с обратной осью значений и нулём справа](axis-order-values-reversed.png) |
| Категории идут снизу вверх; значения растут слева направо. | Планирование, Разработка и Тестирование идут сверху вниз. Значения и порядок строк листа остаются без изменений. | Категории сохраняют обычный порядок; значения растут справа налево. Ось категорий пересекает ось значений в нуле справа. |

## **Отключить вертикальную ось для линейных диаграмм**

Установите [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) в `false` для вертикальной оси, чтобы скрыть её. Пример создаёт линейную диаграмму с данными по умолчанию и сохраняет её с скрытой вертикальной осью.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.VerticalAxis.IsVisible = false;

presentation.Save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
```

## **Отключить горизонтальную ось для линейных диаграмм**

Установите [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) в `false` для горизонтальной оси, чтобы скрыть её. Пример создаёт линейную диаграмму с данными по умолчанию и сохраняет её с скрытой горизонтальной осью.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.HorizontalAxis.IsVisible = false;

presentation.Save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
```

## **Показать или скрыть линии сетки диаграммы**

Прочитайте [ShowMajorGridLines](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/showmajorgridlines/) и [ShowMinorGridLines](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/showminorgridlines/) чтобы узнать, какие сетки отображает ось. Обе свойства только для чтения. Используйте заполнение линий [MinorGridLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/minorgridlinesformat/) для показа или скрытия мелких линий сетки. Установите сплошное заполнение с видимым цветом, чтобы показать их, или используйте `FillType.NoFill`, чтобы скрыть. Соответствующая настройка для основных линий сетки — [MajorGridLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorgridlinesformat/)`.Line.FillFormat`. Изменение заполнения линии сетки сохраняет видимость оси и деления.

Вертикальная ось этой групповой столбчатой диаграммы начинается с отображения основных линий сетки и скрытыми мелкими линиями сетки. Пример показывает мелкие линии сетки оранжевым цветом, затем снова скрывает их перед сохранением презентации.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 30, 660, 230);
var axis = chart.Axes.VerticalAxis;
Console.WriteLine($"Initial: major={axis.ShowMajorGridLines}, minor={axis.ShowMinorGridLines}");

var minorFill = axis.MinorGridLinesFormat.Line.FillFormat;
minorFill.FillType = FillType.Solid;
minorFill.SolidFillColor.Color = Color.DarkOrange;
Console.WriteLine($"Enabled: minor={axis.ShowMinorGridLines}");

minorFill.FillType = FillType.NoFill;
Console.WriteLine($"Hidden: major={axis.ShowMajorGridLines}, minor={axis.ShowMinorGridLines}");

presentation.Save("ChartGridlines.pptx", SaveFormat.Pptx);
```

| Мелкие линии сетки включены | Мелкие линии сетки скрыты |
| --- | --- |
| ![Оранжевые мелкие линии сетки между основными линиями сетки на вертикальной оси](minor-gridlines-enabled.png) | ![Тот же столбчатый график только с видимыми основными линиями сетки](minor-gridlines-hidden.png) |

## **Изменить ось категорий**

Установите [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) чтобы выбрать датированную или текстовую ось категорий. Этот пример требует `ExistingChart.pptx`, где диаграмма является первой фигурой на первом слайде, а ячейки категорий содержат числовые даты Excel. Он меняет горизонтальную ось на датированную. Установка [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) в `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) в `1` и [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) в `Months` размещает основные деления с интервалом один месяц.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

var chart = (IChart) slide.Shapes[0];
chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
chart.Axes.HorizontalAxis.MajorUnit = 1;
chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
```

### **Определить тип оси категорий из данных**

Вызовите [SetCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/setcategoryaxistypeautomatically/) после заполнения категорий, затем прочитайте [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/categoryaxistype/) для проверки выбора. Это полезно, когда одна и та же диаграмма получает либо текстовые метки, либо числовые даты. Метод определяет тип при вызове; он не включает постоянный режим, переоценивающий последующие изменения данных. Вызовите его снова после замены категорий.

В следующем примере создаётся диаграмма с текстовыми категориями и выводится `Text`. Затем значения ячеек категорий заменяются датами, метод вызывается снова и выводится `Date`. Даты хранятся как числовые значения OLE Automation, возвращаемые [DateTime.ToOADate](https://learn.microsoft.com/en-us/dotnet/api/system.datetime.tooadate), а не как строковые даты. [CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/customnumberformat/) управляет способом отображения этих значений; он не преобразует текст в числовые даты. Подробнее о ячейках категорий см. [Chart Workbook](/slides/ru/net/chart-workbook/).

Используйте автоматическое определение, когда входные данные известны как текстовые категории или числовые даты, как в этом примере. Для обычных числовых меток, смешанных категорий или пустых данных явно задайте [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/categoryaxistype/) в соответствии с предполагаемым смыслом. Одни только числовые значения не устанавливают, что категории представляют даты.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var seriesName = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesName, chart.Type);
var labels = new[] { "First", "Second", "Third" };

for (var i = 0; i < labels.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, labels[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, (i + 1) * 10);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.SetCategoryAxisTypeAutomatically();
Console.WriteLine(axis.CategoryAxisType); // Text

var dates = new[] { new DateTime(2026, 1, 1), new DateTime(2026, 1, 2), new DateTime(2026, 2, 1) };

for (var i = 0; i < dates.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0);
    categoryCell.Value = dates[i].ToOADate();
    categoryCell.CustomNumberFormat = "yyyy-mm-dd";
}

axis.SetCategoryAxisTypeAutomatically();
Console.WriteLine(axis.CategoryAxisType); // Date

presentation.Save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx);
```

## **Управлять интервалами меток оси категорий**

Когда в диаграмме много категорий, уменьшите количество видимых меток оси без удаления категорий или точек данных. Установите [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) в `false`, затем задайте [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) желаемый интервал категорий. Для текстовых категорий в их обычном порядке отсчёт начинается с первой категории:

| Интервал | Метки, отображённые в примере |
| --- | --- |
| `1` | Категория 1, Категория 2, Категория 3, … Категория 24 |
| `2` | Категория 1, Категория 3, Категория 5, … Категория 23 |
| `3` | Категория 1, Категория 4, Категория 7, … Категория 22 |

Интервал `3` отображает каждую третью метку, скрывая две метки между отображёнными. Он не удаляет соответствующие столбцы. Автоматический выбор интервала основывается на доступном месте; он не обязательно отображает каждую метку.

Для делений отметок существуют отдельные настройки. Установите [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) в `false` и используйте [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) для задания их интервала. Например, `1` оставляет отметку на каждом интервале категории, пока метки отображаются только каждые три категории. Установите [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) в видимый стиль, чтобы увидеть результат. Возврат любого из автоматических свойств к `true` позволяет диаграмме вновь выбрать интервал автоматически.

Следующий самостоятельный пример создаёт 24 категории и один ряд, затем сохраняет три слайда в `CategoryAxisIntervals.pptx`: автоматический интервал, ручной интервал меток с независимыми отметками и восстановленный автоматический интервал. Две копии сохраняют исходные данные диаграммы. Входная презентация не требуется. Горизонтальный текст меток делает различие в плотности легко заметным.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

chart.HasLegend = false;
chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredColumn);
for (var i = 0; i < 24; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, 10 + i % 6 * 5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.CategoryAxisType = CategoryAxisType.Text;
axis.TextFormat.TextBlockFormat.RotationAngle = 0;
axis.TextFormat.PortionFormat.FontHeight = 12;
axis.MajorTickMark = TickMarkType.Outside;
axis.IsAutomaticTickLabelSpacing = true;
axis.IsAutomaticTickMarksSpacing = true;

// Слайд 2: отображать каждую третью метку, но сохранять деление для каждой категории.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// Слайд 3: позволить диаграмме снова выбрать оба интервала.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**Автоматический интервал (слайд 1):** В этом варианте отображается каждая вторая метка категории, они переходят на две строки. Автоматический результат может варьироваться в зависимости от размера диаграммы, шрифтов и рендерера.

![Автоматический интервал меток категорий при видимых всех 24 столбцах](category-axis-automatic.png)

**Ручной интервал (слайд 2):** Каждая третья метка отображается в одной строке, в то время как отметки остаются на каждом интервале категории. Все 24 столбца, включая те, что без меток, остаются видимыми с теми же значениями. Слайд 3 восстанавливает автоматический вид, показанный выше.

![Ручной интервал меток категорий (три) при видимых всех 24 столбцах](category-axis-manual.png)

### **Выбрать правильную ось и интервал**

Используйте этот интервал количества категорий для текстовой оси категорий, такой как ось категорий столбчатой, линейной, областной или гистограммы. В столбчатой диаграмме это горизонтальная ось. В горизонтальной гистограмме ось категорий вертикальна, поэтому применяйте эти настройки к [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Интервал делений также применяется к оси рядов в диаграммах, где она присутствует.

Не используйте интервал меток категорий для задания числовой шкалы оси значений. На оси значений [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) определяет разницу в значениях: например, основной интервал `10` создаёт отметки на 0, 10, 20 и т.д., когда ось начинается с нуля. Интервал меток категорий `3` считает позиции категорий независимо от их значений. Диаграммы рассеяния и пузырьковые используют оси значений, а не текстовую ось категорий. Для датированной оси используйте основанные на времени основные интервалы и шкалы, описанные в разделе [Изменить ось категорий](#изменить-ось-категорий).

## **Установить формат даты для значений оси категорий**

Пример заменяет данные диаграммы четырьмя годовыми значениями. Даты хранятся как числа OLE Automation в первом листе (индекс `0`). Установите [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) в датированную ось, отключите [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) и задайте `yyyy` для [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/), чтобы метки категорий отображали четырёхзначный год независимо от форматирования ячеек.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
for (var i = 0; i < 4; i++)
{
    var date = new DateTime(2015 + i, 1, 1);
    var categoryCell = workbook.GetCell(0, i + 1, 0, date.ToOADate());
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, i + 1);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.HorizontalAxis.NumberFormat = "yyyy";

presentation.Save("DateAxisFormat.pptx", SaveFormat.Pptx);
```

## **Установить угол поворота заголовка оси диаграммы**

Включите [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) на вертикальной оси, укажите текст заголовка и задайте [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) для его поворота. Угол измеряется в градусах; пример сохраняет столбчатую диаграмму с заголовком оси значений, повернутым на 90 градусов.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("Value");
chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

presentation.Save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
```

## **Установить положение оси на категории или оси значений**

Используйте [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) для управления тем, пересекает ли ось значений ось категорий между категориями или на отметках категорий. Это свойство относится к осям категорий. Пример устанавливает его в `true` на горизонтальной оси категорий столбчатой диаграммы и сохраняет результат.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

presentation.Save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
```

## **Установить единицу отображения на оси значений диаграммы**

Установите [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) для масштабирования меток оси значений без изменения исходных данных. При [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) `Millions` значение 60 000 000 отображается как 60. Пример создаёт столбчатую диаграмму и применяет единицу отображения «миллионы» к её вертикальной оси.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

## **Настроить логарифмическую ось значений**

Логарифмическая ось значений полезна, когда положительные значения охватывают несколько порядков величины. Например, сервис может получать 10, 100, 1 000, 10 000 и 100 000 запросов за пять периодов. При линейной шкале небольшие значения оказываются близко друг к другу у нуля. Логарифмическая шкала делает их относительный рост легче сравнивать: равные расстояния представляют равные отношения, а не равные разницы.

Установите [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) в `true` на оси значений и используйте [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) для выбора основания. Это меняет только отображение существующих значений; данные и логарифмическую трендовую линию это не меняет. Трендовая линия представляет подогнанную зависимость в данных и является отдельной функцией.

### **Выбрать ось значений и основание**

Для линейной или столбчатой диаграммы осью значений является [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Для горизонтальной гистограммы — [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/). Диаграммы рассеяния и пузырьковые имеют две оси значений, поэтому выбирайте горизонтальную ось для X‑значений, вертикальную — для Y‑значений, либо обе. Не применяйте логарифмическое масштабирование к оси категорий.

Основание логарифма по умолчанию `10`. Для PPTX‑диаграмм допускаются основания от `2` до `1000` включительно; поддерживаются также дробные основания, такие как `2.5`. При основании `10` последовательные степени 10, 100, 1 000 и 10 000 расположены равномерно.

### **Сравнить линейное и логарифмическое масштабирование**

Ниже самостоятельный пример создаёт линейную диаграмму с пятью подсчётами запросов на первом слайде, затем клонирует этот слайд и включает логарифмическую ось значений с основанием 10 на втором. Оба слайда сохраняют одинаковые данные.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 30, 40, 660, 200);

chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
var values = new double[] { 10, 100, 1000, 10000, 100000 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Period {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// Сохранить первый слайд линейным и изменить только масштаб оси значений в копии.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**Линейная шкала (слайд 1):** Равные вертикальные расстояния представляют равные различия в количестве запросов. Наибольшее значение доминирует в диаграмме, делая меньшие значения трудно различимыми.

![Линейная диаграмма в PowerPoint, показывающая пять подсчётов запросов на линейной оси значений](value-axis-linear.png)

**Логарифмическая шкала (слайд 2):** Равные вертикальные расстояния представляют равные отношения. Каждый период имеет в десять раз больше запросов, чем предыдущий, поэтому точки образуют прямую восходящую линию на шкале с основанием 10. Метки оси всё равно показывают оригинальное количество запросов.

![Те же пять подсчётов запросов в PowerPoint на логарифмической оси значений с основанием 10](value-axis-logarithmic.png)

### **Обработать нулевые и отрицательные значения**

Логарифмическая шкала может отображать только строго положительные значения. Проверьте данные перед её включением. Если нулевые или отрицательные значения имеют смысл, оставьте линейную шкалу или показывайте их отдельно. Если исключение этих значений уместно для анализа, объясните исключение. Не заменяйте их молча небольшими положительными числами, так как это изменит смысл данных. Любой вручную настроенный минимум или максимум для логарифмической оси также должен быть положительным.

## **FAQ**

**Как установить значение, где одна ось пересекает другую (пересечение осей)?**

Используйте [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) для выбора поведения пересечения. Чтобы указать числовое значение пересечения, задайте [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Эти настройки позволяют переместить пересечение осей к удобному базовому уровню.

**Как позиционировать метки делений относительно оси?**

Установите [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) с помощью [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo` или `None`. Чтобы управлять самими делениями, используйте [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) или [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/); они независимы от позиционирования меток.