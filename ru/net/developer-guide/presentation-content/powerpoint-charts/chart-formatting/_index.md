---
title: Форматирование графиков презентаций в .NET
linktitle: Форматирование графиков
type: docs
weight: 60
url: /ru/net/chart-formatting/
keywords:
- формат графика
- форматирование графика
- сущность графика
- свойства графика
- настройки графика
- опции графика
- свойства шрифта
- скруглённая граница
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Изучите форматирование графиков в Aspose.Slides для .NET и улучшите свою презентацию PowerPoint с помощью пользовательских осей, шрифтов, числовых форматов и скруглённых границ графика."
---
## **Обзор**

В этой статье объясняется, как форматировать графики в презентациях PowerPoint с помощью Aspose.Slides. Показано, как настраивать ключевые элементы графика, такие как оси, линии сетки, заголовки, легенды, область построения и заливки стен, чтобы улучшить внешний вид и читаемость данных графика.  

Также демонстрируется, как задавать свойства шрифта для текста графика, применять предустановленные числовые форматы к данным графика и включать скругленные углы области графика. В совокупности эти примеры показывают, как управлять как визуальным стилем, так и представлением данных графиков в презентации.

## **Форматирование сущностей графика**

Используйте [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) для форматирования заголовков графика, осей, линий сетки, легенд и области построения. Этот пример создает линейный график с маркерами и данными по умолчанию, затем применяет отдельные стили текста и линий к его оси значений и оси категорий. Размеры шрифтов и толщины линий указаны в пунктах; подписи категорий повёрнуты на 45 градусов.  

Ось значений использует [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) независимо от исходных ячеек. Ее масштаб идет от -2 до 15, с основными интервалами 2 и второстепенными интервалами 0,5. Пример также сочетает форматирование в процентах с [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/displayunit/) , установленным в тысячи, поэтому адаптируйте эти настройки к смыслу и масштабу ваших данных. Легенда находится вне области построения, поскольку [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegend/overlay/) отключен. Заполнения задней стенки и пола настраиваются через [BackWall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) и [Floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/), но эти поверхности видны только в 3D‑графиках.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
var chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

var valueAxisText = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
valueAxisText.FontBold = NullableBool.True;
valueAxisText.FontHeight = 16;
valueAxisText.FontItalic = NullableBool.True;
valueAxisText.FillFormat.FillType = FillType.Solid;
valueAxisText.FillFormat.SolidFillColor.Color = Color.DarkGreen;
valueAxisText.LatinFont = new FontData("Times New Roman");

chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
var valueAxisTitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valueAxisTitle.Text = "Primary Axis";
valueAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valueAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valueAxisTitle.PortionFormat.FontHeight = 20;
valueAxisTitle.PortionFormat.FontBold = NullableBool.True;
valueAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

var categoryAxisText = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
categoryAxisText.FontBold = NullableBool.True;
categoryAxisText.FontHeight = 16;
categoryAxisText.FontItalic = NullableBool.True;
categoryAxisText.FillFormat.FillType = FillType.Solid;
categoryAxisText.FillFormat.SolidFillColor.Color = Color.Blue;
categoryAxisText.LatinFont = new FontData("Arial");

chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

var categoryAxisTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
categoryAxisTitle.Text = "Sample Category";
categoryAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
categoryAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
categoryAxisTitle.PortionFormat.FontHeight = 20;
categoryAxisTitle.PortionFormat.FontBold = NullableBool.True;
categoryAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

var legendText = chart.Legend.TextFormat.PortionFormat;
legendText.FontBold = NullableBool.True;
legendText.FontHeight = 16;
legendText.FontItalic = NullableBool.True;
legendText.FillFormat.FillType = FillType.Solid;
legendText.FillFormat.SolidFillColor.Color = Color.DarkRed;

chart.Legend.Overlay = false;

chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;

chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

presentation.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```

## **Установка свойств шрифта для графика**

Установите размер шрифта по умолчанию для текста графика через [Chart.TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/textformat/). Пример создает сгруппированный столбчатый график с шрифтом 20 пунктов и включает подписи значений для первой серии через [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). Текстовые элементы с собственными явными настройками шрифта могут переопределять значение по умолчанию графика.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
chart.TextFormat.PortionFormat.FontHeight = 20;
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
```

## **Установка числового формата**

Используйте [IChartDataCell.PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/presetnumberformat/) для применения встроенного числового формата к ячейкам книги графика. Этот пример создает сгруппированный столбчатый график с данными по умолчанию, поддерживаемыми ячейками, и применяет индекс формата 10 (`0.00%`) к ячейке значения каждой серии. Это меняет способ отображения значений в книге без изменения самих чисел; например, 0,25 отображается как 25,00 %. Форматы осей и подписей данных могут быть настроены отдельно.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
var series = chart.ChartData.Series;

foreach (var chartSeries in series)
{
    foreach (var dataPoint in chartSeries.DataPoints)
    {
        dataPoint.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

presentation.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

В следующей таблице перечислены встроенные индексы числовых форматов с типичными форматами Excel для локали English (United States). Точные строковые форматы и их отображение могут различаться в зависимости от приложения и локали, особенно для валют и дат. Некоторые форматы Excel также отличаются от значений по умолчанию в стандарте OOXML, как описано в [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Индекс | Формат |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Установка скруглённых границ области графика**

Включите [IChart.HasRoundedCorners](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/hasroundedcorners/) для скругления углов области графика. Пример создает сгруппированный столбчатый график и использует [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) для задания его контуру сплошного серого цвета и однослойного стиля перед сохранением презентации.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
chart.LineFormat.FillFormat.FillType = FillType.Solid;
chart.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chart.LineFormat.Style = LineStyle.Single;
chart.HasRoundedCorners = true;

presentation.Save("out.pptx", SaveFormat.Pptx);
```

## **Редактирование существующих аннотаций графика**

График может содержать пользовательские фигуры, такие как текстовая аннотация, объясняющая статус отчёта. Доступ к этим фигурам осуществляется через [IChart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/usershapes/), также перечисленные в [Chart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/usershapes/) в справочнике API графика. Его коллекция [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) содержит фигуры, принадлежащие графику.  

Обычный текстовый блок, размещённый поверх графика, принадлежит слайду, даже если выглядит как часть графика. Перебор через [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) находит график и обычные фигуры слайда, но не перечисляет отдельные фигуры внутри графика. Заголовки графиков и подписи данных являются отдельными элементами графика, а не пользовательскими аннотациями в этой коллекции.  

Скачайте [chart-annotations.pptx](chart-annotations.pptx) и поместите его в рабочий каталог приложения. Его первый слайд содержит график с разгруппированной аннотацией «Preliminary results», линией, принадлежащей графику, и обычным текстовым блоком слайда «Slide overlay». Пример находит первый график на этом слайде и меняет аннотацию на «Final results», когда отчёт готов к публикации. Он проверяет, не пуста ли коллекция, и редактирует только [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) с ненулевым [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) и ожидаемым текстом.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-annotations.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.OfType<IChart>().FirstOrDefault();

if (chart == null || chart.UserShapes.Shapes.Count == 0)
{
    Console.WriteLine("No chart or chart-owned shapes found.");
    return;
}

var updated = false;
foreach (var shape in chart.UserShapes.Shapes)
{
    if (shape is IAutoShape annotation && 
        annotation.TextFrame != null && 
        annotation.TextFrame.Text == "Preliminary results")
    {
        annotation.TextFrame.Text = "Final results";
        updated = true;
        break;
    }
}

if (updated)
{
    presentation.Save("chart-annotations-updated.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No matching text annotation found.");
}
```

Линия и текстовый блок слайда остаются без изменений. Ниже показаны изображения исходного состояния и сохранённого, повторно открытого результата:

| Перед редактированием | После редактирования |
| --- | --- |
| ![Аннотация графика: Preliminary results](chart-annotations-before.png) | ![Аннотация графика: Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Пример проверяет только фигуры верхнего уровня, принадлежащие графику. Если аннотация находится внутри [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), проверьте также коллекцию [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) этой группы. Повторяйте это рекурсивно для вложенных групп, применяя те же проверки текста к их дочерним фигурам. Сама группа является контейнером; не рассматривайте её как текстовый блок.
{{% /alert %}}

## **FAQ**

**Могу ли я задать полупрозрачные заливки для столбцов/областей, сохранив границу непрозрачной?**  
Да. Прозрачность заливки и контур настраиваются отдельно. Это полезно для повышения читаемости сетки и данных в плотных визуализациях.

**Как бороться с наложением подписей данных?**  
Уменьшите размер шрифта, отключите необязательные компоненты подписи (например, категории), отрегулируйте положение подписи, при необходимости показывайте подписи только для выбранных точек или переключите формат на «значение + легенда».

**Могу ли я применять градиентные или узорчатые заливки к сериям?**  
Да. Серии поддерживают сплошные, градиентные и узорчатые заливки. На практике используйте градиенты умеренно и избегайте комбинаций, снижающих контраст с сеткой и текстом.