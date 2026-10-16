---
title: Добавление линий тренда к диаграммам презентаций на C++
linktitle: Линия тренда
type: docs
url: /ru/cpp/trend-line/
keywords:
- диаграмма
- линия тренда
- экспоненциальная линия тренда
- линейная линия тренда
- логарифмическая линия тренда
- линия скользящего среднего
- полиномиальная линия тренда
- степенная линия тренда
- пользовательская линия тренда
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Быстро добавляйте и настраивайте линии тренда в диаграммах PowerPoint с помощью Aspose.Slides для C++ — практическое руководство для привлечения аудитории."
---
## **Обзор**

Эта статья объясняет, как добавить линии тренда к диаграммам презентаций с помощью Aspose.Slides. В ней показано, как создать диаграмму, добавить линии тренда к сериям диаграммы и работать с несколькими типами линий тренда, включая экспоненциальную, линейную, логарифмическую, скользящее среднее, полиномиальную и степенную.

Также она описывает, как добавить пользовательскую линию к диаграмме, вставив форму линии, и включает короткий раздел FAQ о значениях проекции линии тренда вперёд и назад, а также о том, сохраняются ли линии тренда при экспорте в PDF или SVG и при рендеринге диаграмм в виде изображений.

## **Добавить линию тренда**

Используйте [ITrendlineCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendlinecollection/add/) для добавления линии тренда к серии диаграммы, выбирая её тип с помощью [TrendlineType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/trendlinetype/). В примере создаётся сгруппированная столбчатая диаграмма с данными по умолчанию и добавляются две линии тренда к каждой из её трёх серий.

Экспоненциальная линия тренда скрывает своё уравнение и значение R‑квадрат с помощью [ITrendline::set_DisplayEquation](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayequation/) и [ITrendline::set_DisplayRSquaredValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayrsquaredvalue/), тогда как линейная линия тренда окрашена в красный цвет. Логарифмическая линия тренда использует [IOverridableText::AddTextFrameForOverriding](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ioverridabletext/addtextframeforoverriding/) для пользовательской подписи. Скользящее среднее использует [ITrendline::set_Period](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_period/) для усреднения трёх точек данных и [ITrendline::set_TrendlineName](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_trendlinename/) для задания пользовательского имени.

Полиномиальная линия тренда использует [ITrendline::set_Order](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_order/) для установки степени в три и расширяется на одну категорию вперёд с помощью [ITrendline::set_Forward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_forward/). Степенная линия тренда расширяется на одну категорию назад с помощью [ITrendline::set_Backward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_backward/).

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ILineFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/ITrendline.h>
#include <DOM/Chart/ITrendlineCollection.h>
#include <DOM/Chart/TrendlineType.h>
#include <DOM/Chart/IFormat.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 20, 500, 400);

auto firstSeries = chart->get_ChartData()->get_Series()->idx_get(0);

auto exponentialTrendline = firstSeries->get_TrendLines()->Add(TrendlineType::Exponential);
exponentialTrendline->set_DisplayEquation(false);
exponentialTrendline->set_DisplayRSquaredValue(false);

auto linearTrendline = firstSeries->get_TrendLines()->Add(TrendlineType::Linear);
linearTrendline->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
linearTrendline->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

auto secondSeries = chart->get_ChartData()->get_Series()->idx_get(1);

auto logarithmicTrendline = secondSeries->get_TrendLines()->Add(TrendlineType::Logarithmic);
logarithmicTrendline->AddTextFrameForOverriding(u"New log trend line");

auto movingAverageTrendline = secondSeries->get_TrendLines()->Add(TrendlineType::MovingAverage);
movingAverageTrendline->set_Period(3);
movingAverageTrendline->set_TrendlineName(u"New TrendLine Name");

auto thirdSeries = chart->get_ChartData()->get_Series()->idx_get(2);

auto polynomialTrendline = thirdSeries->get_TrendLines()->Add(TrendlineType::Polynomial);
polynomialTrendline->set_Forward(1);
polynomialTrendline->set_Order(3);

auto powerTrendline = thirdSeries->get_TrendLines()->Add(TrendlineType::Power);
powerTrendline->set_Backward(1);

presentation->Save(u"ChartTrendLines.pptx", SaveFormat::Pptx);
```

## **Установить перехват линии тренда**

Используйте [ITrendline::set_Intercept](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_intercept/) для фиксирования значения Y линии тренда при X = 0. Эта настройка поддерживается для линейных, экспоненциальных и полиномиальных линий тренда.

Например, модель стоимости производства может потребовать начинать с известных фиксированных затрат в размере 100, даже если измерения при ненулевых объёмах производства указывают иную базовую линию. Для линейной линии тренда фиксирование перехвата ограничивает уравнение `y = ax + b` до `b = 100`; наклон подгоняется к данным при этом ограничении. Это не просто смещение уже подогнанной линии. Настройки пересечения осей контролируют точку соприкосновения осей диаграммы, а не коэффициенты подгоняемой линии тренда.

В следующем примере создаётся точечная (XY) диаграмма с объёмами производства от 1 до 4 и затратами 170, 200, 230 и 260. Диаграмма сохраняется с автоматическим перехватом по умолчанию, затем перехват устанавливается в 100, и сохраняется второй файл PPTX. Два файла различаются только настройкой перехвата. Линия тренда отображает своё уравнение и продолжается назад до X = 0.

```cpp
#include <system/shared_ptr.h>
#include <system/object_ext.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/ITrendline.h>
#include <DOM/Chart/ITrendlineCollection.h>
#include <DOM/Chart/TrendlineType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ScatterWithMarkers, 20, 20, 480, 210);
chart->set_HasLegend(false);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto nameCell = workbook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Production cost"));
auto series = chart->get_ChartData()->get_Series()->Add(nameCell, ChartType::ScatterWithMarkers);
const double costs[] = { 170, 200, 230, 260 };

for (auto i = 0; i < 4; i++)
{
    auto xCell = workbook->GetCell(0, i + 1, 0, ObjectExt::Box<int32_t>(i + 1));
    auto yCell = workbook->GetCell(0, i + 1, 1, ObjectExt::Box<double>(costs[i]));
    series->get_DataPoints()->AddDataPointForScatterSeries(xCell, yCell);
}

auto trendline = series->get_TrendLines()->Add(TrendlineType::Linear);
trendline->set_DisplayEquation(true);
trendline->set_Backward(1);

presentation->Save(u"AutomaticIntercept.pptx", SaveFormat::Pptx);

trendline->set_Intercept(100);
presentation->Save(u"FixedIntercept.pptx", SaveFormat::Pptx);
```

При автоматическом расчёте эти данные дают `y = 30x + 140`. Установка перехвата в 100 вместо этого приводит к приблизительному значению `y = 43.33x + 100`: подогнанное значение при нуле совпадает с известной базой, тогда как линия больше не проходит через каждую точку данных.

| Автоматический перехват | Фиксированный перехват 100 |
| --- | --- |
| ![Линейная линия тренда с автоматически рассчитанным перехватом 140](intercept-automatic.png) | ![Линейная линия тренда с фиксированным перехватом 100](intercept-fixed.png) |

Оба изображения используют одинаковые данные и масштаб осей. Линии тренда продлены назад до X = 0, чтобы показать их перехваты.

По умолчанию свойство содержит `std::numeric_limits<double>::quiet_NaN()`, что представляет неуказанный перехват, а не ноль. Затем перехват рассчитывается автоматически из данных.

## **Добавить пользовательскую линию**

Пользовательская линия — это фигура, нарисованная поверх диаграммы, а не линия тренда, рассчитанная по данным серии. В этом примере используется [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) для добавления горизонтальной линии на слайд поверх диаграммы. Позиция линии задаётся в координатах слайда, измеренных в пунктах, поэтому она начинается от левого края диаграммы и располагается на полпути вниз по диаграмме. Её ширина совпадает с шириной диаграммы. Формат линии, возвращаемый [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/), задаёт сплошной красный цвет.

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ILineFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 500, 400);

auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, chart->get_X(), chart->get_Y() + chart->get_Height() / 2, chart->get_Width(), 0);
line->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
line->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

presentation->Save(u"AddCustomLines.pptx", SaveFormat::Pptx);
```

## **Вопросы и ответы**

**Что означают «forward» и «backward» для линии тренда?**

Это длина линии тренда, проецируемой вперёд/назад: для точечных (XY) диаграмм — в единицах осей; для не точечных диаграмм — в количестве категорий. Допустимы только неотрицательные значения.

**Сохранится ли линия тренда при экспорте презентации в PDF или SVG, или при рендеринге слайда в изображение?**

Да. Aspose.Slides преобразует презентации в [PDF](/slides/ru/cpp/convert-powerpoint-to-pdf/) или [SVG](/slides/ru/cpp/render-a-slide-as-an-svg-image/) и рендерит диаграммы в изображения; линии тренда, как часть диаграммы, сохраняются во время этих операций. Также доступен метод для [экспорт изображения диаграммы](/slides/ru/cpp/shape-thumbnails/).