---
title: Добавить линии тренда к диаграммам презентаций в .NET
linktitle: Линия тренда
type: docs
url: /ru/net/trend-line/
keywords:
- диаграмма
- линия тренда
- экспоненциальная линия тренда
- линейная линия тренда
- логарифмическая линия тренда
- линия тренда скользящее среднее
- полиномиальная линия тренда
- степеневая линия тренда
- пользовательская линия тренда
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Быстро добавляйте и настраивайте линии тренда в диаграммах PowerPoint с помощью Aspose.Slides для .NET — практическое руководство для привлечения вашей аудитории."
---
## **Обзор**

Эта статья объясняет, как добавить линии тренда к диаграммам презентаций с использованием Aspose.Slides. Она показывает, как создать диаграмму, добавить линии тренда к сериям диаграммы и работать с несколькими типами линий тренда, включая экспоненциальные, линейные, логарифмические, скользящее среднее, полиномиальные и степенные.

Также она описывает, как добавить пользовательскую линию к диаграмме, вставив форму линии, и содержит краткий FAQ о значениях проекций линии тренда вперед и назад, а также о том, сохраняются ли линии тренда при экспорте в PDF или SVG и при рендеринге диаграмм в виде изображений.

## **Добавить линию тренда**

Используйте [ITrendlineCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendlinecollection/add/) для добавления линии тренда к серии диаграммы, выбирая её тип с помощью [TrendlineType](https://reference.aspose.com/slides/net/aspose.slides.charts/trendlinetype/). Пример создаёт сгруппированную столбчатую диаграмму с данными по умолчанию и добавляет две линии тренда к каждой из её трёх серий.

Экспоненциальная линия тренда скрывает своё уравнение и значение R‑квадрата с помощью [DisplayEquation](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayequation/) и [DisplayRSquaredValue](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayrsquaredvalue/), в то время как линейная линия тренда имеет красный цвет. Логарифмическая линия тренда использует [AddTextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/addtextframeforoverriding/) для пользовательской подписи. Скользящее среднее использует [Period](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/period/) из трёх точек данных и пользовательское [TrendlineName](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/trendlinename/).

Полиномиальная линия тренда имеет [Order](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/order/) равный трём и расширяется на одну категорию вперёд с помощью [Forward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/forward/). Степенная линия тренда расширяется на одну категорию назад с помощью [Backward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/backward/).

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

var firstSeries = chart.ChartData.Series[0];

var exponentialTrendline = firstSeries.TrendLines.Add(TrendlineType.Exponential);
exponentialTrendline.DisplayEquation = false;
exponentialTrendline.DisplayRSquaredValue = false;

var linearTrendline = firstSeries.TrendLines.Add(TrendlineType.Linear);
linearTrendline.Format.Line.FillFormat.FillType = FillType.Solid;
linearTrendline.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

var secondSeries = chart.ChartData.Series[1];

var logarithmicTrendline = secondSeries.TrendLines.Add(TrendlineType.Logarithmic);
logarithmicTrendline.AddTextFrameForOverriding("New log trend line");

var movingAverageTrendline = secondSeries.TrendLines.Add(TrendlineType.MovingAverage);
movingAverageTrendline.Period = 3;
movingAverageTrendline.TrendlineName = "New TrendLine Name";

var thirdSeries = chart.ChartData.Series[2];

var polynomialTrendline = thirdSeries.TrendLines.Add(TrendlineType.Polynomial);
polynomialTrendline.Forward = 1;
polynomialTrendline.Order = 3;

var powerTrendline = thirdSeries.TrendLines.Add(TrendlineType.Power);
powerTrendline.Backward = 1;

presentation.Save("ChartTrendLines.pptx", SaveFormat.Pptx);
```

## **Установить пересечение линии тренда**

Используйте [Intercept](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/intercept/) чтобы зафиксировать значение Y линии тренда при X = 0. Эта настройка поддерживается для линейных, экспоненциальных и полиномиальных линий тренда.

Например, модель стоимости производства может потребовать начала с известных фиксированных расходов в размере 100, даже если измерения при ненулевых объёмах производства указывают другую базовую линию. Для линейной линии тренда фиксирование пересечения ограничивает уравнение `y = ax + b` до `b = 100`; наклон подбирается по данным при этом ограничении. Это не просто сдвигает уже построенную линию. Настройки пересечения осей управляют тем, где оси диаграммы встречаются, а не коэффициентами подгоняемой линии тренда.

В следующем примере создаётся точечная (XY) диаграмма с объёмами производства от 1 до 4 и затратами 170, 200, 230 и 260. Она сохраняется с автоматически рассчитываемым пересечением по умолчанию, затем пересечение устанавливается в 100 и сохраняется второй файл PPTX. Два файла отличаются только настройкой пересечения. Линия тренда отображает своё уравнение и распространяется назад до X = 0.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var nameCell = workbook.GetCell(0, 0, 1, "Production cost");
var series = chart.ChartData.Series.Add(nameCell, ChartType.ScatterWithMarkers);
double[] costs = { 170, 200, 230, 260 };

for (var i = 0; i < costs.Length; i++)
{
    var xCell = workbook.GetCell(0, i + 1, 0, i + 1);
    var yCell = workbook.GetCell(0, i + 1, 1, costs[i]);
    series.DataPoints.AddDataPointForScatterSeries(xCell, yCell);
}

var trendline = series.TrendLines.Add(TrendlineType.Linear);
trendline.DisplayEquation = true;
trendline.Backward = 1;

presentation.Save("AutomaticIntercept.pptx", SaveFormat.Pptx);

trendline.Intercept = 100;
presentation.Save("FixedIntercept.pptx", SaveFormat.Pptx);
```

При автоматическом расчёте эти данные дают `y = 30x + 140`. Установка пересечения в 100 вместо этого дает приблизительно `y = 43.33x + 100`: подгоняемое значение при нуле соответствует известной базовой линии, тогда как линия больше не проходит через каждую точку данных.

| Автоматическое пересечение | Фиксированное пересечение 100 |
| --- | --- |
| ![Линейная линия тренда с автоматически рассчитанным пересечением 140](intercept-automatic.png) | ![Линейная линия тренда с фиксированным пересечением 100](intercept-fixed.png) |

Обе изображения используют одни и те же данные и масштабы осей. Линии тренда расширены назад до X = 0, чтобы показать их пересечения.

По умолчанию свойство содержит `double.NaN`, что означает неуказанное пересечение, а не ноль. Затем пересечение рассчитывается автоматически из данных.

## **Добавить пользовательскую линию**

Пользовательская линия — это форма, нарисованная поверх диаграммы, а не линия тренда, вычисленная из данных серии. В этом примере используется [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) для добавления горизонтальной линии на слайд над диаграммой. Позиция линии задаётся в координатах слайда, измеряемых в пунктах, поэтому она начинается от левого края диаграммы и располагается на полпути вниз по диаграмме. Её ширина совпадает с шириной диаграммы. [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) задает линии сплошной красный цвет.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

var line = slide.Shapes.AddAutoShape(ShapeType.Line, chart.X, chart.Y + chart.Height / 2, chart.Width, 0);
line.LineFormat.FillFormat.FillType = FillType.Solid;
line.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("AddCustomLines.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Что означают «forward» и «backward» для линии тренда?**

Это длина линии тренда, проецируемой вперёд/назад: для точечных (XY) диаграмм — в единицах оси; для остальных диаграмм — в количествах категорий. Допустимы только неотрицательные значения.

**Сохранится ли линия тренда при экспорте презентации в PDF или SVG, или при рендеринге слайда в изображение?**

Да. Aspose.Slides преобразует презентации в [PDF](/slides/ru/net/convert-powerpoint-to-pdf/) или [SVG](/slides/ru/net/render-a-slide-as-an-svg-image/) и рендерит диаграммы в изображения; линии тренда, как часть диаграммы, сохраняются во время этих операций. Также доступен метод для [экспорта изображения диаграммы](/slides/ru/net/create-shape-thumbnails/).