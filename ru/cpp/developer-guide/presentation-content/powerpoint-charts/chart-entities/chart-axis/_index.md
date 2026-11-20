---
title: Настройка осей диаграмм в презентациях с использованием C++
linktitle: Ось диаграммы
type: docs
url: /ru/cpp/chart-axis/
keywords:
- ось диаграммы
- вертикальная ось
- горизонтальная ось
- настройка оси
- манипулирование осью
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
- C++
- Aspose.Slides
description: "Узнайте, как использовать Aspose.Slides для C++ для настройки осей диаграмм в презентациях PowerPoint для отчетов и визуализации."
---
## **Обзор**

Эта статья объясняет, как настраивать оси диаграмм с помощью Aspose.Slides для C++. Она охватывает вычисленные значения осей, переключение строк и столбцов диаграммы, видимость осей, интервалы меток категорий и делений, даты категорий и их форматирование, поворот заголовка, позиционирование осей, единицы отображения и логарифмическое масштабирование.

## **Получить максимальные значения на вертикальной оси диаграмм**

Создайте [Презентацию](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) и добавьте областьную диаграмму с данными по умолчанию. Вызовите [ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/validatechartlayout/) перед чтением вычисленных значений осей, чтобы макет диаграммы был актуальным.

Прочитайте [get_ActualMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmaxvalue/) и [get_ActualMinValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminvalue/) для пределов оси, а также [get_ActualMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunit/) и [get_ActualMinorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunit/) для интервалов делений. [get_ActualMajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunitscale/) и [get_ActualMinorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunitscale/) предоставляют шкалы единиц времени, которые актуальны для осей дат. Пример сохраняет эти значения в локальные переменные и сохраняет диаграмму.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 100, 100, 500, 350);
chart->ValidateChartLayout();

auto maxValue = chart->get_Axes()->get_VerticalAxis()->get_ActualMaxValue();
auto minValue = chart->get_Axes()->get_VerticalAxis()->get_ActualMinValue();

auto majorUnit = chart->get_Axes()->get_VerticalAxis()->get_ActualMajorUnit();
auto minorUnit = chart->get_Axes()->get_VerticalAxis()->get_ActualMinorUnit();

auto majorUnitScale = chart->get_Axes()->get_VerticalAxis()->get_ActualMajorUnitScale();
auto minorUnitScale = chart->get_Axes()->get_VerticalAxis()->get_ActualMinorUnitScale();

presentation->Save(u"AxisValues_out.pptx", SaveFormat::Pptx);
```

## **Обмен данными между осями**

Используйте [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) для обмена ролями рядов и категорий в данных диаграммы. Каждая прежняя категория становится рядом, а каждый прежний ряд — категорией. Это меняет способ группировки данных; оси по горизонтали и вертикали не меняются местами. В примере используется [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setrange/) для привязки данных по умолчанию к `Sheet1!A1:D5`, включая строку заголовка и столбец категорий, перед переключением строк и столбцов. Сохраняется диаграмма с четырьмя рядами и тремя категориями.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 400, 300);

chart->get_ChartData()->SetRange(u"Sheet1!A1:D5");
chart->get_ChartData()->SwitchRowColumn();

presentation->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **Обратить порядок построения оси**

Используйте [set_IsPlotOrderReversed](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isplotorderreversed/) для обратного порядка построения категориальной или значительной оси. Например, горизонтальная столбчатая диаграмма может отображать стадии проекта сверху вниз в том же порядке, что и в листе: Планирование, Разработка, Тестирование. Обратный порядок оси меняет направление построения; он не сортирует и не переупорядочивает данные книги. Для сравнения, [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) меняет роли рядов и категорий.

В следующем примере создаётся горизонтальная столбчатая диаграмма с тремя стадиями и одним рядом. Сохраняется презентация с тремя слайдами: обычный порядок, обратные категории и обратные значения. Каждая копия использует одинаковый набор данных, и на каждой копии обратна только одна ось.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/CrossesType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredBar, 50, 40, 620, 320);
chart->set_HasLegend(false);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::ClusteredBar);
auto stages = std::array<System::String, 3>{u"Planning", u"Development", u"Testing"};
auto values = std::array<int, 3>{10, 30, 20};
for (auto i = 0; i < stages.size(); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(stages[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

// Слайд 2: отобразить первую категорию вверху.
auto categorySlide = presentation->get_Slides()->AddClone(slide);
auto categoryChart = System::ExplicitCast<IChart>(categorySlide->get_Shape(0));
categoryChart->get_Axes()->get_VerticalAxis()->set_IsPlotOrderReversed(true);
// Сохранить горизонтальную ось значений внизу.
categoryChart->get_Axes()->get_VerticalAxis()->set_CrossType(CrossesType::Maximum);

// Слайд 3: обратить только горизонтальную числовую шкалу.
auto valueSlide = presentation->get_Slides()->AddClone(slide);
auto valueChart = System::ExplicitCast<IChart>(valueSlide->get_Shape(0));
valueChart->get_Axes()->get_HorizontalAxis()->set_IsPlotOrderReversed(true);

presentation->Save(u"ReversedAxes.pptx", SaveFormat::Pptx);
```

Обращение оси может также переместить перпендикулярную ось на противоположную сторону графика. [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) управляет тем, где другая ось пересекает настраиваемую ось. На слайде 2 установка её в `Maximum` для обратной категориальной оси сохраняет горизонтальную ось значений внизу. Для конкретной точки пересечения используйте [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/). Проверьте настройки пересечения при изменении направления, особенно если диаграмма уже имеет пользовательскую точку пересечения. Вызовите `set_IsPlotOrderReversed` с `false`, чтобы восстановить обычное направление построения; настройки пересечения остаются отдельными.

| Обычный порядок (слайд 1) | Обратные категории (слайд 2) | Обратные значения (слайд 3) |
| --- | --- | --- |
| ![Горизонтальная столбчатая диаграмма с обычным порядком категориальной и значительной осей](axis-order-normal.png) | ![Горизонтальная столбчатая диаграмма с категориями, отображаемыми сверху вниз](axis-order-categories-reversed.png) | ![Горизонтальная столбчатая диаграмма с обратной значительной осью и нулём справа](axis-order-values-reversed.png) |
| Категории идут снизу вверх; значения увеличиваются слева направо. | Планирование, Разработка и Тестирование идут сверху вниз. Значения и порядок строк книги остаются без изменений. | Категории сохраняют обычный порядок; значения увеличиваются справа налево. Категориальная ось пересекает ноль справа. |

## **Отключить вертикальную ось для линейных диаграмм**

Используйте [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) с `false` для вертикальной оси, чтобы скрыть её. В примере создаётся линейная диаграмма с данными по умолчанию и сохраняется с скрытой вертикальной осью.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 100, 100, 400, 300);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

presentation->Save(u"HiddenVerticalAxis.pptx", SaveFormat::Pptx);
```

## **Отключить горизонтальную ось для линейных диаграмм**

Используйте [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) с `false` для горизонтальной оси, чтобы скрыть её. В примере создаётся линейная диаграмма с данными по умолчанию и сохраняется с скрытой горизонтальной осью.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 100, 100, 400, 300);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

presentation->Save(u"HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
```

## **Показать или скрыть линии сетки диаграммы**

Используйте [get_ShowMajorGridLines](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_showmajorgridlines/) и [get_ShowMinorGridLines](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_showminorgridlines/) , чтобы проверить, какие линии сетки отображает ось. Обе свойства только для чтения. Чтобы показать мелкие линии сетки, используйте [get_MinorGridLinesFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_minorgridlinesformat/) и задайте заливку линии сплошным, видимым цветом. Чтобы скрыть их, установите заливку в [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/). Используйте [get_MajorGridLinesFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_majorgridlinesformat/) , чтобы изменить основные линии сетки аналогичным способом. Изменение заливки линий сетки сохраняет видимость оси и деления.

Вертикальная ось этой сгруппированной колонной диаграммы изначально отображает только основные линии сетки. В примере мелкие линии сетки выводятся оранжевым цветом, затем снова скрываются перед сохранением презентации.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartLinesFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 30, 30, 660, 230);
auto axis = chart->get_Axes()->get_VerticalAxis();
std::cout << std::boolalpha << "Initial: major=" << axis->get_ShowMajorGridLines() << ", minor=" << axis->get_ShowMinorGridLines() << '\n';

auto minorFill = axis->get_MinorGridLinesFormat()->get_Line()->get_FillFormat();
minorFill->set_FillType(FillType::Solid);
minorFill->get_SolidFillColor()->set_Color(Color::get_DarkOrange());
std::cout << "Enabled: minor=" << axis->get_ShowMinorGridLines() << '\n';

minorFill->set_FillType(FillType::NoFill);
std::cout << "Hidden: major=" << axis->get_ShowMajorGridLines() << ", minor=" << axis->get_ShowMinorGridLines() << '\n';

presentation->Save(u"ChartGridlines.pptx", SaveFormat::Pptx);
```

| Мелкие линии сетки включены | Мелкие линии сетки скрыты |
| --- | --- |
| ![Оранжевые мелкие линии сетки между основными линиями сетки на вертикальной оси](minor-gridlines-enabled.png) | ![Та же колонная диаграмма, где видны только основные линии сетки](minor-gridlines-hidden.png) |

## **Изменить категориальную ось**

Используйте [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) для выбора датовой или текстовой категориальной оси. В этом примере требуется `ExistingChart.pptx`, где диаграмма является первой фигурой на первом слайде, а ячейки категорий содержат числовые даты Excel. Горизонтальная ось меняется на датовую ось. Вызов [set_IsAutomaticMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isautomaticmajorunit/) с `false`, [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunit/) с `1` и [set_MajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunitscale/) со значением месяцев размещает основные деления с интервалом в один месяц.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/TimeUnitType.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto slide = presentation->get_Slide(0);

auto chart = System::ExplicitCast<IChart>(slide->get_Shape(0));
chart->get_Axes()->get_HorizontalAxis()->set_CategoryAxisType(CategoryAxisType::Date);
chart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticMajorUnit(false);
chart->get_Axes()->get_HorizontalAxis()->set_MajorUnit(1);
chart->get_Axes()->get_HorizontalAxis()->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

### **Определить тип категориальной оси по данным**

Вызовите [SetCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/setcategoryaxistypeautomatically/) после заполнения категорий, затем вызовите [get_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_categoryaxistype/) , чтобы проверить выбор. Это полезно, когда одна и та же диаграмма получает либо текстовые метки, либо числовые даты. Метод определяет тип при вызове; он не включает постоянный режим, переоценивающий будущие изменения данных. Вызовите его снова после замены категорий.

В следующем примере создаётся диаграмма с текстовыми категориями и выводится `Text`. Затем значения ячеек категорий заменяются датами, и метод вызывается снова, выводя `Date`. Даты хранятся как числовые значения OLE Automation, возвращаемые [System::DateTime::ToOADate](https://reference.aspose.com/slides/cpp/system/datetime/tooadate/), а не как строковые даты. [set_CustomNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_customnumberformat/) управляет тем, как эти значения отображаются; он не преобразует текст в числовые даты. Подробнее о ячейках категорий см. [Chart Workbook](/slides/ru/cpp/chart-workbook/).

Используйте автоматическое определение, когда известно, что ввод содержит текстовые категории или числовые даты, как в этом примере. Для обычных числовых меток, смешанных категорий или пустых данных явно вызывайте [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_categoryaxistype/) , чтобы соответствовать предполагаемому смыслу. Одни лишь числовые значения не означают, что категории представляют даты.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/date_time.h>
#include <system/console.h>
#include <system/enum.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto seriesName = workbook->GetCell(0, 0, 1, System::ObjectExt::Box(System::String(u"Sales")));
auto series = chart->get_ChartData()->get_Series()->Add(seriesName, chart->get_Type());
auto labels = std::array<System::String, 3>{u"First", u"Second", u"Third"};

for (auto i = 0; i < labels.size(); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(labels[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box((i + 1) * 10));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto axis = chart->get_Axes()->get_HorizontalAxis();
axis->SetCategoryAxisTypeAutomatically();
System::Console::WriteLine(System::Enum<CategoryAxisType>::GetName(axis->get_CategoryAxisType())); // Текст

auto dates = std::array<System::DateTime, 3>{System::DateTime(2026, 1, 1), System::DateTime(2026, 1, 2), System::DateTime(2026, 2, 1)};

for (auto i = 0; i < dates.size(); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0);
    categoryCell->set_Value(System::ObjectExt::Box(dates[i].ToOADate()));
    categoryCell->set_CustomNumberFormat(u"yyyy-mm-dd");
}

axis->SetCategoryAxisTypeAutomatically();
System::Console::WriteLine(System::Enum<CategoryAxisType>::GetName(axis->get_CategoryAxisType())); // Дата

presentation->Save(u"AutomaticCategoryAxis.pptx", SaveFormat::Pptx);
```

## **Управление интервалами меток категориальной оси**

Когда в диаграмме много категорий, уменьшите количество видимых меток оси, не удаляя категории или точки данных. Используйте [set_IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticticklabelspacing/) с `false`, затем [set_TickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_ticklabelspacing/) с нужным интервалом категорий. Для текстовых категорий в обычном порядке отсчёт начинается с первой категории:

| Интерал | Меток, отображённых в примере |
| --- | --- |
| `1` | Категория 1, Категория 2, Категория 3, ... Категория 24 |
| `2` | Категория 1, Категория 3, Категория 5, ... Категория 23 |
| `3` | Категория 1, Категория 4, Категория 7, ... Категория 22 |

Интервал `3` отображает каждую третью метку, скрывая две метки между отображаемыми. Он не удаляет соответствующие столбцы. Автоматический интервал выбирает значение исходя из доступного пространства; он не обязательно отображает каждую метку.

Деления имеют отдельные настройки. Используйте [set_IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomatictickmarksspacing/) с `false` и [set_TickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_tickmarksspacing/) , чтобы задать их интервал. Например, `1` оставляет деление на каждом интервале категории, в то время как метки отображаются только каждую третью категорию. Используйте [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majortickmark/) с видимым стилем, чтобы увидеть результат. Возврат любого свойства автоматического интервала к `true` позволяет диаграмме вновь выбирать этот интервал.

В следующем автономном примере создаются 24 категории и один ряд, затем сохраняются три слайда в `CategoryAxisIntervals.pptx`: автоматический интервал, ручной интервал меток с независимыми делениями и восстановленный автоматический интервал. Обе копии сохраняют исходные данные диаграммы. Входная презентация не требуется. Горизонтальный текст меток облегчает визуальное различие плотности.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/TickMarkType.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTextBlockFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>
#include <DOM/ISlideCollection.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

chart->set_HasLegend(false);
chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::ClusteredColumn);
for (auto i = 0; i < 24; i++)
{
    auto categoryName = System::String::Format(u"Category {0}", i + 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(10 + i % 6 * 5));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto axis = chart->get_Axes()->get_HorizontalAxis();
axis->set_CategoryAxisType(CategoryAxisType::Text);
axis->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(0);
axis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12);
axis->set_MajorTickMark(TickMarkType::Outside);
axis->set_IsAutomaticTickLabelSpacing(true);
axis->set_IsAutomaticTickMarksSpacing(true);

// Слайд 2: показывать каждую третью метку, но оставлять деление для каждой категории.
auto manualSlide = presentation->get_Slides()->AddClone(slide);
auto manualChart = System::ExplicitCast<IChart>(manualSlide->get_Shape(0));
auto manualAxis = manualChart->get_Axes()->get_HorizontalAxis();
manualAxis->set_IsAutomaticTickLabelSpacing(false);
manualAxis->set_TickLabelSpacing(3);
manualAxis->set_IsAutomaticTickMarksSpacing(false);
manualAxis->set_TickMarksSpacing(1);

// Слайд 3: позволить диаграмме снова выбрать оба интервала.
auto restoredSlide = presentation->get_Slides()->AddClone(manualSlide);
auto restoredChart = System::ExplicitCast<IChart>(restoredSlide->get_Shape(0));
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickLabelSpacing(true);
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickMarksSpacing(true);

presentation->Save(u"CategoryAxisIntervals.pptx", SaveFormat::Pptx);
```

**Автоматический интервал (слайд 1):** В этом отображении каждая вторая метка категории выводится и переносится на две строки. Автоматический результат может варьироваться в зависимости от размера диаграммы, шрифтов и рендерера.

![Автоматический интервал меток категорий при видимых всех 24 столбцах](category-axis-automatic.png)

**Ручной интервал (слайд 2):** Каждая третья метка отображается в одну строку, в то время как деления остаются на каждом интервале категории. Все 24 столбца, включая те, что без меток, остаются видимыми с теми же значениями. Слайд 3 восстанавливает автоматическое отображение, показанное выше.

![Ручной интервал меток категорий в три при видимых всех 24 столбцах](category-axis-manual.png)

### **Выберите правильную ось и интервал**

Используйте такой интервал количества категорий для текстовой категориальной оси, например оси категорий в колонной, линейной, областной или столбчатой диаграмме. В колонной диаграмме это горизонтальная ось. В горизонтальной столбчатой диаграмме категориальная ось вертикальна, поэтому применяйте эти настройки к [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). Интервал делений также применяется к оси рядов в диаграммах, где она присутствует.

Не используйте интервал меток категории для задания числовой шкалы значительной оси. На значительной оси [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majorunit/) задаёт разницу значений: например, основной шаг `10` создаёт деления на 0, 10, 20 и т.д., если ось начинается с нуля. Интервал меток категории `3` считает позиции категорий, независимо от их значений. Точечные и пузырьковые диаграммы используют значительные оси, а не текстовую категориальную. Для датовой оси используйте основанные на времени основные единицы и шкалы, как описано в [Change a Category Axis](#change-a-category-axis).

## **Установить формат даты для значений категориальной оси**

В примере заменяются данные диаграммы по умолчанию четырьмя годовыми значениями. Даты хранятся как серийные номера OLE Automation в первом листе (индекс `0`). Используйте [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) для выбора датовой оси, отключите привязку к формату источника с помощью [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isnumberformatlinkedtosource/), и задайте `yyyy` через [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_numberformat/) , чтобы метки категорий отображали четырёхзначные годы независимо от формата ячеек.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 450, 300);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
for (auto i = 0; i < 4; i++)
{
    auto date = System::DateTime(2015 + i, 1, 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(date.ToOADate()));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(i + 1));
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

chart->get_Axes()->get_HorizontalAxis()->set_CategoryAxisType(CategoryAxisType::Date);
chart->get_Axes()->get_HorizontalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_HorizontalAxis()->set_NumberFormat(u"yyyy");

presentation->Save(u"DateAxisFormat.pptx", SaveFormat::Pptx);
```

## **Задать угол поворота заголовка оси диаграммы**

Включите заголовок вертикальной оси с помощью [set_HasTitle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_hastitle/), задайте текст заголовка и используйте [set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextblockformat/set_rotationangle/) , чтобы повернуть заголовок. Угол измеряется в градусах; в этом примере сохраняется колонная диаграмма с заголовком оси значений, повернутым на 90 градусов.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTextBlockFormat.h>
#include <DOM/Chart/IChartTitle.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_VerticalAxis()->set_HasTitle(true);
chart->get_Axes()->get_VerticalAxis()->get_Title()->AddTextFrameForOverriding(u"Value");
chart->get_Axes()->get_VerticalAxis()->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90);

presentation->Save(u"RotatedAxisTitle.pptx", SaveFormat::Pptx);
```

## **Установить позицию оси на категориальной или значительной оси**

Используйте [set_AxisBetweenCategories](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_axisbetweencategories/) , чтобы управлять тем, пересекает ли значительная ось категориальную ось между категориями или на делениях категорий. Это свойство применяется к категориальным осям. В примере оно устанавливается в `true` для горизонтальной категориальной оси колонной диаграммы и сохраняет результат.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

presentation->Save(u"AxisBetweenCategories.pptx", SaveFormat::Pptx);
```

## **Установить единицу отображения на значительной оси диаграммы**

Используйте [set_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_displayunit/) , чтобы масштабировать метки на значительной оси без изменения исходных данных. При установленном [DisplayUnitType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/displayunittype/) в `Millions` значение 60 000 000 отображается как 60. В примере создаётся колонная диаграмма и к её вертикальной оси применяется единица отображения «миллионы».

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/DisplayUnitType.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

presentation->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **Настроить логарифмическую значительную ось**

Логарифмическая значительная ось полезна, когда положительные значения охватывают несколько порядков величины. Например, сервис может получать 10, 100, 1 000, 10 000 и 100 000 запросов за пять периодов. На линейной шкале меньшие значения располагаются близко друг к другу около нуля. Логарифмическая шкала облегчает сравнение их относительного роста: равные расстояния представляют равные отношения, а не равные разницы.

Вызовите [set_IsLogarithmic](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_islogarithmic/) с `true` для значительной оси и используйте [set_LogBase](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_logbase/) , чтобы выбрать основание. Это меняет отображение существующих значений; данные не изменяются и не добавляется логарифмическая тренд‑линия. Тренд‑линия представляет собой построенную зависимость в данных и является отдельной функцией.

### **Выберите значительную ось и основание**

Для линейной или колонной диаграммы значительной осью является [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). Для горизонтальной столбчатой диаграммы — [get_HorizontalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_horizontalaxis/). Точечные и пузырьковые диаграммы имеют две значительные оси, поэтому выбирайте горизонтальную ось для значений X, вертикальную для Y, или обе. Не применяйте логарифмическое масштабирование к категориальной оси.

Базовое логарифмическое основание по умолчанию — `10`. Для PPTX‑диаграмм используйте основание от `2` до `1000` включительно; поддерживаются также дробные основания, такие как `2.5`. При основе `10` последовательные степени (10, 100, 1 000, 10 000) располагаются с одинаковыми интервалами.

### **Сравнение линейного и логарифмического масштабирования**

В следующем автономном примере создаётся линейная диаграмма с пятью подсчётами запросов на первом слайде, затем этот слайд клонируется и на втором включается логарифмическая значительная ось с основанием 10. Оба слайда сохраняют одинаковые данные.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 30, 40, 660, 200);

chart->set_HasLegend(false);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto values = std::array<double, 5>{10, 100, 1000, 10000, 100000};

for (auto i = 0; i < values.size(); i++)
{
    auto categoryName = System::String::Format(u"Period {0}", i + 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

// Оставить первый слайд линейным и изменить только масштаб оси значений у копии.
auto logarithmicSlide = presentation->get_Slides()->AddClone(slide);
auto logarithmicChart = System::ExplicitCast<IChart>(logarithmicSlide->get_Shape(0));
auto valueAxis = logarithmicChart->get_Axes()->get_VerticalAxis();
valueAxis->set_IsLogarithmic(true);
valueAxis->set_LogBase(10);

presentation->Save(u"LogarithmicAxis.pptx", SaveFormat::Pptx);
```

**Линейная шкала (слайд 1):** Равные вертикальные расстояния представляют равные различия в количестве запросов. Наибольшее значение доминирует в диаграмме, делая меньшие значения трудно различимыми.

![Линейная диаграмма в PowerPoint, показывающая пять подсчётов запросов на линейной значительной оси](value-axis-linear.png)

**Логарифмическая шкала (слайд 2):** Равные вертикальные расстояния представляют равные отношения. Каждый период имеет в десять раз больше запросов, чем предыдущий, поэтому точки образуют прямую восходящую линию на шкале с основанием 10. Метки оси всё ещё показывают исходные количества запросов.

![Те же пять подсчётов запросов в PowerPoint на логарифмической значительной оси с основанием 10](value-axis-logarithmic.png)

### **Обработка нулевых и отрицательных значений**

Логарифмическая шкала может отображать только строго положительные значения. Проверьте данные перед включением. Если нулевые или отрицательные значения имеют смысл, сохраняйте линейную шкалу или отображайте их отдельно. Если исключение этих значений оправдано для анализа, объясните причину. Не заменяйте их тихо небольшими положительными числами, так как это меняет смысл данных. Любой вручную настроенный минимум или максимум для логарифмической оси также должен быть положительным.

## **Часто задаваемые вопросы**

**Как задать значение, в котором одна ось пересекает другую (пересечение осей)?**

Используйте [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) , чтобы выбрать поведение пересечения. Чтобы указать числовое значение пересечения, используйте [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/). Эти настройки позволяют переместить пересечение осей к подходящей базовой линии.

**Как позиционировать метки делений относительно оси?**

Используйте [set_TickLabelPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_ticklabelposition/) со значением из [TickLabelPositionType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ticklabelpositiontype/) : `Low`, `High`, `NextTo` или `None`. Чтобы управлять самими делениями, используйте [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) или [set_MinorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_minortickmark/) ; они отделены от позиционирования меток.