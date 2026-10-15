---
title: Настройка осей диаграмм в презентациях на .NET
linktitle: Ось диаграммы
type: docs
url: /ru/net/chart-axis/
keywords:
- ось диаграммы
- вертикальная ось
- горизонтальная ось
- настроить ось
- управлять осью
- управлять осью
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
description: "Узнайте, как использовать Aspose.Slides для .NET, чтобы настраивать оси диаграмм в презентациях PowerPoint для отчётов и визуализаций."
---
## **Обзор**

В этой статье объясняется, как настраивать оси диаграмм с помощью Aspose.Slides для .NET. Описываются расчётные значения осей, переключение строк и столбцов диаграммы, видимость осей, интервалы подписи категорий и делений, даты и форматирование, вращение заголовка, позиционирование осей, единицы отображения и логарифмическое масштабирование.

## **Получить максимальные значения по вертикальной оси диаграмм**

Создайте [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) и добавьте областную диаграмму с данными по умолчанию. Вызовите [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) перед чтением расчётных значений осей, чтобы макет диаграммы был актуален.

Считайте [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) и [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) для пределов оси, а также [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) и [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) для интервалов делений. [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) и [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) предоставляют масштабы единиц времени, что актуально для датированных осей. Пример сохраняет эти значения в локальные переменные и сохраняет диаграмму.

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

Используйте [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) для обмена ролями рядов и категорий в данных диаграммы. Каждая прежняя категория становится рядом, а каждый прежний ряд — категорией. Это меняет способ группировки данных; оси не меняются местами. В примере используется [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) для привязки данных по умолчанию к `Sheet1!A1:D5`, включая строку заголовка и столбец категорий, перед переключением строк и столбцов. Сохраняется диаграмма с четырьмя рядами и тремя категориями.

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

## **Изменить порядок построения оси**

Используйте [IsPlotOrderReversed](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isplotorderreversed/) для обратного порядка построения категориальной или значительной оси. Например, горизонтальная гистограмма может показывать стадии проекта сверху вниз в том же порядке, что в таблице: Планирование, Разработка, Тестирование. Обратный порядок меняет направление построения; он не сортирует и не перестраивает данные листа. Для сравнения, [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) меняет роли рядов и категорий.

В следующем примере создаётся горизонтальная гистограмма с тремя стадиями и одним рядом. Сохраняется презентация из трёх слайдов: обычный порядок, обратные категории и обратные значения. Каждый копия использует тот же набор данных, и только одна ось обратна в каждой копии.

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

// Slide 2: display the first category at the top.
 // Слайд 2: отобразить первую категорию вверху.
categoryChart.Axes.VerticalAxis.IsPlotOrderReversed = true;
// Keep the horizontal value axis at the bottom.
 // Сохранить горизонтальную ось значений внизу.
categoryChart.Axes.VerticalAxis.CrossType = CrossesType.Maximum;

// Slide 3: reverse only the horizontal numeric scale.
 // Слайд 3: обратить только горизонтальную числовую шкалу.
var valueSlide = presentation.Slides.AddClone(slide);
var valueChart = (IChart)valueSlide.Shapes[0];
valueChart.Axes.HorizontalAxis.IsPlotOrderReversed = true;

presentation.Save("ReversedAxes.pptx", SaveFormat.Pptx);
```

Обратный порядок оси может также переместить перпендикулярную ось на противоположную сторону графика. [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) определяет, где другая ось пересекает настраиваемую ось. На слайде 2 установка значения `Maximum` на обратной категориальной оси оставляет горизонтальную значительную ось внизу. Для указания конкретной точки пересечения используйте [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Проверьте настройки пересечения при изменении направления, особенно если у диаграммы уже задана пользовательская точка пересечения. Установите `IsPlotOrderReversed` обратно в `false`, чтобы восстановить обычное направление построения; настройки пересечения независимы.

| Обычный порядок (слайд 1) | Обратные категории (слайд 2) | Обратные значения (слайд 3) |
| --- | --- | --- |
| ![Горизонтальная гистограмма с обычным порядком категорий и значений](axis-order-normal.png) | ![Горизонтальная гистограмма с категориями, отображаемыми сверху вниз](axis-order-categories-reversed.png) | ![Горизонтальная гистограмма с обратной значительной осью и нулём справа](axis-order-values-reversed.png) |
| Категории идут снизу вверх; значения растут слева направо. | Планирование, Разработка и Тестирование идут сверху вниз. Значения и порядок строк листа не меняются. | Категории сохраняют обычный порядок; значения растут справа налево. Категориальная ось пересекает ноль справа. |

## **Отключить вертикальную ось для линейных диаграмм**

Установите [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) в `false` для вертикальной оси, чтобы скрыть её. В примере создаётся линейная диаграмма с данными по умолчанию и сохраняется с скрытой вертикальной осью.

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

Установите [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) в `false` для горизонтальной оси, чтобы скрыть её. В примере создаётся линейная диаграмма с данными по умолчанию и сохраняется с скрытой горизонтальной осью.

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

## **Изменить категориальную ось**

Установите [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) для выбора датированной или текстовой категориальной оси. Этот пример требует `ExistingChart.pptx`, где диаграмма является первой фигурой на первом слайде, а ячейки категорий содержат числовые даты Excel. Он меняет горизонтальную ось на датированную. Установка [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) в `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) в `1` и [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) в `months` размещает основные деления через один‑месячный интервал.

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

## **Управление интервалами подписей категориальной оси**

Когда в диаграмме много категорий, уменьшите количество видимых подписей оси без удаления категорий или точек данных. Установите [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) в `false`, затем задайте [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) желаемый интервал категорий. Для текстовых категорий в обычном порядке нумерация начинается с первой категории:

| Интервал | Подписи в примере |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

Интервал `3` отображает каждую третью подпись, скрывая две подписи между отображаемыми. Это не удаляет соответствующие столбцы. Автоматический интервал выбирает значение исходя из доступного места; он не обязателен отображать каждую подпись.

Отметки делений управляются отдельно. Установите [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) в `false` и используйте [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) для задания их интервала. Например, `1` оставит отметку на каждом интервале категории, тогда как подписи будут отображаться лишь каждую третью категорию. Установите [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) в видимый стиль, чтобы увидеть результат. Возврат любого из свойств автоматического интервала к `true` позволяет диаграмме вновь выбрать интервал автоматически.

Следующий самостоятельный пример создаёт 24 категории и один ряд, затем сохраняет три слайда в `CategoryAxisIntervals.pptx`: автоматический интервал, ручной интервал подписей с независимыми отметками и восстановленный автоматический интервал. Две копии сохраняют исходные данные диаграммы. Входная презентация не требуется. Горизонтальный текст подписей делает различие в плотности легко различимым.

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

// Слайд 2: показывать каждую третью подпись, но оставлять деление для каждой категории.
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

**Автоматический интервал (слайд 1):** В этом отображении каждая вторая подпись категории показана и переносится на две строки. Автоматический результат может различаться в зависимости от размера диаграммы, шрифтов и рендерера.

![Автоматический интервал подписей категории со всеми 24 видимыми столбцами](category-axis-automatic.png)

**Ручной интервал (слайд 2):** Каждая третья подпись отображается в одну строку, а отметки делений остаются на каждом интервале категории. Все 24 столбца, включая безподписные, остаются видимыми с теми же значениями. Слайд 3 восстанавливает автоматический вид, показанный выше.

![Ручной интервал подписи категории три с всеми 24 видимыми столбцами](category-axis-manual.png)

### **Выберите правильную ось и интервал**

Используйте этот интервал подсчёта категорий для текстовой категориальной оси, например для оси категорий столбчатой, линейной, областной или гистограммы. В столбчатой диаграмме это горизонтальная ось. В горизонтальной гистограмме категориальная ось вертикальна, поэтому применяйте эти настройки к [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Интервал делений также применяется к оси рядов в диаграммах, где она присутствует.

Не используйте интервал подписей категории для задания числовой шкалы значительной оси. На значительной оси [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) задаёт разницу значений: например, основной интервал `10` создаёт деления 0, 10, 20 и т.д., когда ось начинается с нуля. Интервал подписи категории `3` считает позиции категорий независимо от их значений. Точечные и пузырьковые диаграммы используют значительные оси, а не текстовую категориальную. Для датированной оси используйте временные основные единицы и масштабы, как описано в разделе [Изменить категориальную ось](#изменить-категориальную-ось).

## **Установить формат даты для значений категориальной оси**

Пример заменяет данные диаграммы по умолчанию четырьмя годовыми значениями. Даты хранятся как серийные числа OLE Automation в первой таблице (индекс `0`). Установите [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) в датированную ось, отключите [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) и задайте `yyyy` в [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/), чтобы подписи категории показывали четырёхзначные годы независимо от формата ячейки.

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

## **Установить угол вращения заголовка оси диаграммы**

Включите [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) на вертикальной оси, задайте текст заголовка и установите [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) для поворота заголовка. Угол измеряется в градусах; пример сохраняет столбчатую диаграмму с заголовком значительной оси, вращённым на 90 градусов.

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

## **Установить позицию оси на категориальной или значительной оси**

Используйте [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) для управления тем, пересекает ли значительная ось категориальную ось между категориями или на отметках категорий. Это свойство применяется к категориальным осям. Пример устанавливает его в `true` на горизонтальной категориальной оси столбчатой диаграммы и сохраняет результат.

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

## **Установить единицу отображения на значительной оси диаграммы**

Установите [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) для масштабирования подписей на значительной оси без изменения исходных данных. При [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) = `Millions` значение 60 000 000 отображается как 60. Пример создаёт столбчатую диаграмму и применяет единицу отображения «миллионы» к её вертикальной оси.

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

## **Настроить логарифмическую значительную ось**

Логарифмическая значительная ось полезна, когда положительные значения охватывают несколько порядков magnitude. Например, сервис может получать 10, 100, 1 000, 10 000 и 100 000 запросов за пять периодов. На линейной шкале меньшие значения находятся близко друг к другу рядом с нулём. Логарифмическая шкала облегчает сравнение их относительного роста: равные расстояния представляют одинаковые отношения, а не одинаковые разности.

Установите [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) в `true` на значительной оси и используйте [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) для выбора основания. Это меняет отображение существующих значений; данные и логарифмическая тренд‑линия не изменяются. Тренд‑линия представляет подогнанную зависимость в данных и является отдельной функцией.

### **Выберите значительную ось и основание**

Для линейной или столбчатой диаграммы значительная ось — это [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Для горизонтальной гистограммы — [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/). Точечные и пузырьковые диаграммы имеют две значительные оси, поэтому выбирайте горизонтальную ось для значений X, вертикальную — для Y, или обе. Не применяйте логарифмическое масштабирование к категориальной оси.

Основание логарифма по умолчанию — `10`. Для диаграмм PPTX используйте основание от `2` до `1000` включительно; поддерживаются и дробные основания, такие как `2.5`. При основании `10` последовательные степени 10, 100, 1 000 и 10 000 расположены равномерно.

### **Сравнение линейного и логарифмического масштабирования**

Следующий самостоятельный пример создаёт линейную диаграмму с пятью подсчётами запросов на первом слайде, затем клонирует слайд и включает логарифмическую значительную ось с основанием 10 на втором. Оба слайда сохраняют одинаковые данные.

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

// Сохраняем первый слайд линейным и меняем только масштаб оси значений в копии.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**Линейная шкала (слайд 1):** Равные вертикальные расстояния представляют равные разности в количестве запросов. Наибольшее значение доминирует, делая меньшие значения трудноразличимыми.

![Линейная диаграмма в PowerPoint, показывающая пять подсчётов запросов на линейной значительной оси](value-axis-linear.png)

**Логарифмическая шкала (слайд 2):** Равные вертикальные расстояния представляют равные отношения. Каждый период содержит в десять раз больше запросов, поэтому точки образуют прямую восходящую линию на шкале с основанием 10. Подписи оси всё равно показывают оригинальные подсчёты запросов.

![Те же пять подсчётов запросов в PowerPoint на логарифмической значительной оси с основанием 10](value-axis-logarithmic.png)

### **Обработка нулевых и отрицательных значений**

Логарифмическая шкала может отображать только строго положительные значения. Проверьте данные перед её включением. Если нулевые или отрицательные значения имеют смысл, оставьте линейную шкалу или показывайте их отдельно. Если исключение этих значений оправдано, объясните причину. Не заменяйте их «тихо» небольшими положительными числами, так как это меняет смысл данных. Любой вручную заданный минимум или максимум для логарифмической оси также должен быть положительным.

## **FAQ**

**Как задать значение, где одна ось пересекает другую (пересечение осей)?**

Используйте [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) для выбора поведения пересечения. Чтобы указать числовое значение пересечения, задайте [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Эти настройки позволяют переместить пересечение осей к удобному базовому уровню.

**Как позиционировать подписи делений относительно оси?**

Установите [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) с помощью [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo` или `None`. Для управления самими делениями используйте [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) или [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/); они независимы от позиционирования подписей.