---
title: Настройка осей диаграмм в презентациях с использованием C++
linktitle: Ось диаграммы
type: docs
url: /ru/cpp/chart-axis/
keywords:
- ось диаграммы
- вертикальная ось
- горизонтальная ось
- настроить ось
- управлять осью
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
description: "Узнайте, как использовать Aspose.Slides для C++, чтобы настраивать оси диаграмм в презентациях PowerPoint для отчетов и визуализаций."
---
## **Обзор**

В этой статье объясняется, как настраивать оси диаграмм с помощью Aspose.Slides for C++. Рассматриваются вычисленные значения осей, переключение строк и столбцов диаграммы, видимость осей, интервалы меток категорий и делений, даты категорий и их форматирование, вращение заголовка, позиционирование осей, единицы отображения и логарифмическое масштабирование.

## **Получение максимальных значений на вертикальной оси диаграмм**

Создайте [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) и добавьте областную диаграмму с данными по умолчанию. Вызовите [ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/validatechartlayout/) перед чтением вычисленных значений осей, чтобы макет диаграммы был актуален.

Прочитайте [get_ActualMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmaxvalue/) и [get_ActualMinValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminvalue/) для пределов оси, а также [get_ActualMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunit/) и [get_ActualMinorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunit/) для интервалов делений. [get_ActualMajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunitscale/) и [get_ActualMinorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunitscale/) предоставляют масштабы временных единиц, которые актуальны для осей дат. Пример сохраняет эти значения в локальные переменные и сохраняет диаграмму.

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

Используйте [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) для обмена ролями рядов и столбцов в данных диаграммы. Каждая прежняя категория становится рядом, а каждый прежний ряд — категорией. Это меняет способ группировки данных; оси горизонтальная и вертикальная не меняются местами. В примере используется [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setrange/) для привязки данных по умолчанию к `Sheet1!A1:D5`, включая строку заголовка и столбец категорий, перед переключением строк и столбцов. Сохраняется диаграмма с четырьмя рядами и тремя категориями.

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

## **Обратный порядок построения оси**

Используйте [set_IsPlotOrderReversed](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isplotorderreversed/) для обратного порядка построения категории или оси значений. Например, горизонтальная гистограмма может отображать стадии проекта сверху вниз в том же порядке, что и лист: Planning, Development, Testing. Обратный порядок оси меняет направление построения; сортировка или переупорядочивание данных листа не происходит. Для сравнения, [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) меняет роли рядов и категорий.

В следующем примере создаётся горизонтальная гистограмма с тремя стадиями и одним рядом. Сохраняется презентация из трёх слайдов: обычный порядок, обратные категории и обратные значения. Каждая копия использует одинаковый набор данных, и на каждой копии обратна только одна ось.

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

Обратный порядок оси также может переместить перпендикулярную ось на противоположную сторону графика. [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) управляет тем, где другая ось пересекает настраиваемую ось. На слайде 2 установка значения `Maximum` для обратной оси категории удерживает горизонтальную ось значений внизу. Для указания конкретной точки пересечения используйте [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/). Проверяйте настройки пересечения при изменении направления, особенно если диаграмма уже имеет пользовательскую точку пересечения. Вызов `set_IsPlotOrderReversed` с `false` восстанавливает обычное направление построения; настройки пересечения остаются отдельными.

| Обычный порядок (слайд 1) | Обратные категории (слайд 2) | Обратные значения (слайд 3) |
| --- | --- | --- |
| ![Горизонтальная гистограмма с обычным порядком осей категорий и значений](axis-order-normal.png) | ![Горизонтальная гистограмма с отображением категорий сверху вниз](axis-order-categories-reversed.png) | ![Горизонтальная гистограмма с обратной осью значений и нулём справа](axis-order-values-reversed.png) |
| Категории идут снизу вверх; значения увеличиваются слева направо. | Planning, Development и Testing идут сверху вниз. Значения и порядок строк листа остаются без изменений. | Категории сохраняют обычный порядок; значения увеличиваются справа налево. Ось категорий пересекает ноль справа. |

## **Отключение вертикальной оси для линейных диаграмм**

Используйте [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) со значением `false` для вертикальной оси, чтобы скрыть её. В примере создаётся линейная диаграмма с данными по умолчанию и сохраняется с скрытой вертикальной осью.

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

## **Отключение горизонтальной оси для линейных диаграмм**

Используйте [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) со значением `false` для горизонтальной оси, чтобы скрыть её. В примере создаётся линейная диаграмма с данными по умолчанию и сохраняется с скрытой горизонтальной осью.

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

## **Изменение оси категории**

Используйте [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) для выбора оси категории типа дата или текст. Этот пример требует `ExistingChart.pptx`, в котором диаграмма является первой фигурой на первом слайде, а ячейки категорий содержат численные значения дат Excel. Он меняет горизонтальную ось на ось даты. Вызов [set_IsAutomaticMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isautomaticmajorunit/) со значением `false`, [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunit/) со значением `1` и [set_MajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunitscale/) со значением месяцев размещает основные деления с интервалом в один месяц.

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

## **Управление интервалами меток оси категории**

Когда в диаграмме много категорий, уменьшите количество видимых меток оси, не удаляя категории или точки данных. Используйте [set_IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticticklabelspacing/) со значением `false`, затем [set_TickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_ticklabelspacing/) с нужным интервалом категории. Для текстовых категорий в их обычном порядке отсчёт начинается с первой категории:

| Интервал | Меток, отображаемых в примере |
| --- | --- |
| `1` | Категория 1, Категория 2, Категория 3, ... Категория 24 |
| `2` | Категория 1, Категория 3, Категория 5, ... Категория 23 |
| `3` | Категория 1, Категория 4, Категория 7, ... Категория 22 |

Интервал `3` отображает каждую третью метку, скрывая две между отображаемыми метками. Он не удаляет соответствующие столбцы. Автоматический интервал выбирает значение исходя из доступного пространства; он не обязательно отображает каждую метку.

Отметки делений имеют отдельные настройки. Используйте [set_IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomatictickmarksspacing/) со значением `false` и [set_TickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_tickmarksspacing/) для установки их интервала. Например, `1` сохраняет отметку на каждом интервале категории, в то время как метки отображаются только каждые три категории. Используйте [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majortickmark/) с видимым стилем, чтобы увидеть результат. Установка любого свойства автоматического интервала обратно в `true` позволяет диаграмме вновь выбирать интервал.

В следующем автономном примере создаются 24 категории и один ряд, затем сохраняются три слайда в `CategoryAxisIntervals.pptx`: автоматический интервал, ручной интервал меток с независимыми делениями и восстановленный автоматический интервал. Две копии сохраняют исходные данные диаграммы. Входная презентация не требуется. Горизонтальный текст меток облегчает восприятие различий в плотности.

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

**Автоматический интервал (слайд 1):** В этом визуальном представлении каждая вторая метка категории отображается и переносится на две строки. Автоматический результат может варьироваться в зависимости от размера диаграммы, шрифтов и рендерера.

![Автоматический интервал меток категории с видимыми всеми 24 столбцами](category-axis-automatic.png)

**Ручной интервал (слайд 2):** Каждая третья метка отображается в одну строку, в то время как деления остаются на каждом интервале категории. Все 24 столбца, включая те, что без меток, остаются видимыми с теми же значениями. Слайд 3 восстанавливает автоматический вид, показанный выше.

![Ручной интервал меток категории в три с видимыми всеми 24 столбцами](category-axis-manual.png)

### **Выбор правильной оси и интервала**

Используйте этот интервал количества категорий для текстовой оси категории, например оси категории столбчатой, линейной, областной или гистограммы. В столбчатой диаграмме это горизонтальная ось. В горизонтальной гистограмме ось категории вертикальна, поэтому применяйте эти настройки к [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). Расстояние между делениями также применяется к оси рядов в диаграммах, где она присутствует.

Не используйте интервал меток категории для установки числовой шкалы оси значений. На оси значений [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majorunit/) определяет разницу в значениях: например, основной интервал `10` создаёт деления на 0, 10, 20 и т.д., если ось начинается с нуля. Интервал меток категории `3` считает позиции категорий независимо от их значений. Диаграммы разброса и пузырьковые используют оси значений, а не текстовую ось категории. Для оси даты используйте временные основные единицы и масштабы, как описано в [Изменение оси категории](#change-a-category-axis).

## **Установка формата даты для значений оси категории**

В примере заменяются данные диаграммы по умолчанию четырьмя годовыми значениями. Даты хранятся как серийные номера OLE Automation в первом листе (индекс `0`). Используйте [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) для выбора оси даты, отключите привязку формата к источнику с помощью [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isnumberformatlinkedtosource/) и задайте `yyyy` через [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_numberformat/), чтобы метки категорий отображали четырёхзначные годы независимо от формата ячеек.

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

## **Установка угла вращения заголовка оси диаграммы**

Включите заголовок вертикальной оси с помощью [set_HasTitle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_hastitle/), задайте текст заголовка и используйте [set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextblockformat/set_rotationangle/) для его поворота. Угол измеряется в градусах; в этом примере сохраняется столбчатая диаграмма с заголовком оси значений, повернутым на 90 градусов.

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

## **Установка положения оси на оси категории или значения**

Используйте [set_AxisBetweenCategories](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_axisbetweencategories/) для управления тем, пересекает ли ось значений ось категории между категориями или на отметках категории. Это свойство применяется к осям категории. В примере оно устанавливается в `true` для горизонтальной оси категории столбчатой диаграммы и сохраняет результат.

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

## **Установка единицы отображения на оси значений диаграммы**

Используйте [set_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_displayunit/) для масштабирования меток оси значений без изменения исходных данных. При установке [DisplayUnitType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/displayunittype/) в `Millions` значение 60 000 000 отображается как 60. В примере создаётся столбчатая диаграмма и применяется единица отображения миллионов к её вертикальной оси.

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

## **Настройка логарифмической оси значений**

Логарифмическая ось значений полезна, когда положительные значения охватывают несколько порядков величины. Например, сервис может получать 10, 100, 1 000, 10 000 и 100 000 запросов за пять периодов. На линейной шкале меньшие значения находятся близко друг к другу рядом с нулём. Логарифмическая шкала упрощает сравнение их относительного роста: равные расстояния представляют равные отношения, а не равные разницы.

Вызовите [set_IsLogarithmic](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_islogarithmic/) со значением `true` на оси значений и используйте [set_LogBase](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_logbase/) для выбора основания. Это меняет способ отображения существующих значений; данные не изменяются и логарифмическая линий тренда не добавляется. Линия тренда представляет собой аппроксимирующую зависимость в данных и является отдельной функцией.

### **Выбор оси значений и основания**

Для линейной или столбчатой диаграммы осью значений является [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). Для горизонтальной гистограммы – [get_HorizontalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_horizontalaxis/). Диаграммы разброса и пузырьковые имеют две оси значений, поэтому выбирайте горизонтальную ось для значений X, вертикальную – для Y, либо обе. Не применяйте логарифмическое масштабирование к оси категории.

Основание логарифма по умолчанию — `10`. Для диаграмм PPTX используйте основание от `2` до `1000` включительно; поддерживаются также дробные основания, такие как `2.5`. При основании `10` последовательные степени 10, 100, 1 000 и 10 000 расположены на одинаковом расстоянии.

### **Сравнение линейного и логарифмического масштабирования**

В следующем автономном примере создаётся линейная диаграмма с пятью количествами запросов на первом слайде, затем этот слайд клонируется и на втором включается логарифмическая ось значений с основанием 10. Оба слайда сохраняют одинаковые данные.

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

// Сохранить первый слайд линейным и изменить только масштаб оси значений копии.
auto logarithmicSlide = presentation->get_Slides()->AddClone(slide);
auto logarithmicChart = System::ExplicitCast<IChart>(logarithmicSlide->get_Shape(0));
auto valueAxis = logarithmicChart->get_Axes()->get_VerticalAxis();
valueAxis->set_IsLogarithmic(true);
valueAxis->set_LogBase(10);

presentation->Save(u"LogarithmicAxis.pptx", SaveFormat::Pptx);
```

**Линейная шкала (слайд 1):** Равные вертикальные расстояния означают равные различия в количестве запросов. Наибольшее значение доминирует в диаграмме, делая меньшие значения трудно различимыми.

![Линейная диаграмма в PowerPoint, показывающая пять количеств запросов на линейной оси значений](value-axis-linear.png)

**Логарифмическая шкала (слайд 2):** Равные вертикальные расстояния означают равные отношения. Каждый период имеет в десять раз больше запросов, чем предыдущий, поэтому точки образуют прямую восходящую линию на шкале с основанием 10. Метки оси по‑прежнему показывают исходные количества запросов.

![Те же пять количеств запросов в PowerPoint на логарифмической оси значений с основанием 10](value-axis-logarithmic.png)

### **Обработка нулевых и отрицательных значений**

Логарифмическая шкала может отображать только строго положительные значения. Проверьте данные перед её включением. Если нулевые или отрицательные значения имеют смысл, сохраняйте линейную шкалу или отображайте их отдельно. Если исключение этих значений оправдано для анализа, объясните его. Не заменяйте их тихо небольшими положительными числами, так как это меняет смысл данных. Любой вручную установленный минимум или максимум для логарифмической оси также должен быть положительным.

## **FAQ**

**Как задать значение, в котором одна ось пересекает другую (пересечение осей)?**

Используйте [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) для выбора поведения пересечения. Чтобы задать числовое значение пересечения, используйте [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/). Эти настройки позволяют переместить точку пересечения осей к подходящей базовой линии.

**Как разместить метки делений относительно оси?**

Используйте [set_TickLabelPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_ticklabelposition/) со значением из [TickLabelPositionType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo` или `None`. Для управления самими делениями используйте [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) или [set_MinorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_minortickmark/); они независимы от позиционирования меток.