---
title: Настройка легенд диаграмм в презентациях с использованием C++
linktitle: Легенда диаграммы
type: docs
url: /ru/cpp/chart-legend/
keywords:
- легенда диаграммы
- позиция легенды
- размер шрифта
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Настройте легенды диаграмм с помощью Aspose.Slides для C++, чтобы оптимизировать презентации PowerPoint с индивидуальным форматированием легенд."
---
## **Обзор**

Aspose.Slides for C++ предоставляет возможности настройки легенд диаграмм в презентациях PowerPoint. В этой статье показано, как задать позицию и размер легенды, установить размер шрифта для всей легенды, отформатировать отдельный элемент легенды и скрыть или восстановить выбранные элементы.

В разделе FAQ рассматриваются связанные поведения, включая резервирование места для легенды, отображение многострочных подписей и наследование форматирования из темы презентации.

## **Позиционирование легенды**

Используйте методы легенды [set_X](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_x/), [set_Y](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_y/), [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_width/) и [set_Height](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_height/), чтобы задать её позицию и размер в виде долей от размеров диаграммы.

Этот пример создаёт презентацию и добавляет группированную столбцовую диаграмму с данными по умолчанию на первый слайд. Деление требуемых смещений и размеров легенды на ширину и высоту диаграммы преобразует их в относительные значения: легенда смещена на 50 пунктов от верхнего левого угла диаграммы и имеет размер 100 × 100 пунктов.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

// Express the legend's position and size relative to the chart.
chart->get_Legend()->set_X(50 / chart->get_Width());
chart->get_Legend()->set_Y(50 / chart->get_Height());
chart->get_Legend()->set_Width(100 / chart->get_Width());
chart->get_Legend()->set_Height(100 / chart->get_Height());

presentation->Save(u"legend_position.pptx", SaveFormat::Pptx);
```

## **Установить размер шрифта легенды**

Используйте метод легенды [get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_textformat/) для доступа к форматированию текста и [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) для установки размера шрифта в пунктах.

Этот пример создаёт диаграмму с данными по умолчанию и задаёт размер текста легенды 20 пунктов. Он также отключает автоматические границы вертикальной оси и задаёт её диапазон от ‑5 до 10.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

chart->get_Legend()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMinValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MinValue(-5);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMaxValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MaxValue(10);

presentation->Save(u"legend_font_size.pptx", SaveFormat::Pptx);
```

## **Установить размер шрифта отдельного элемента легенды**

Используйте коллекцию, возвращаемую методом легенды [get_Entries](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_entries/), чтобы получить форматирование для конкретного элемента. Индексы элементов начинаются с нуля, поэтому индекс `1` относится ко второму элементу.

Этот пример создаёт группированную столбцовую диаграмму, в данных которой присутствует как минимум две серии. Он форматирует второй элемент легенды полужирным, курсивом и синим текстом размером 20 пунктов.

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/ILegendEntryCollection.h>
#include <DOM/Chart/ILegendEntryProperties.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
auto textFormat = chart->get_Legend()->get_Entries()->idx_get(1)->get_TextFormat();

textFormat->get_PortionFormat()->set_FontBold(NullableBool::True);
textFormat->get_PortionFormat()->set_FontHeight(20);
textFormat->get_PortionFormat()->set_FontItalic(NullableBool::True);
textFormat->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
textFormat->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

presentation->Save(u"legend_entry_format.pptx", SaveFormat::Pptx);
```

## **Скрыть отдельные элементы легенды**

Чтобы исключить вспомогательную серию из легенды, оставив её данные видимыми, вызовите [ILegendEntryProperties::set_Hide](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilegendentryproperties/set_hide/) с `true` через [IChartSeries::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_relatedlegendentry/). Это скрывает только выбранный элемент легенды; серия и её точки данных не удаляются. В отличие от этого, вызов [IChart::set_HasLegend](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_haslegend/) с `false` скрывает всю легенду.

Пример ниже создаёт группированную столбцовую диаграмму с несколькими сериями, используя данные по умолчанию. Он скрывает элемент легенды второй серии (индекс `1`) и сохраняет презентацию. Затем он восстанавливает элемент, вызвав `set_Hide` с `false`, и сохраняет вторую копию. Столбцы остаются видимыми в обоих файлах.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/ILegendEntryProperties.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
chart->set_HasLegend(true);

auto legendEntry = chart->get_ChartData()->get_Series()->idx_get(1)->get_RelatedLegendEntry();

legendEntry->set_Hide(true);
presentation->Save(u"hidden_legend_entry.pptx", SaveFormat::Pptx);

// Восстановить тот же элемент без изменения данных диаграммы.
legendEntry->set_Hide(false);
presentation->Save(u"restored_legend_entry.pptx", SaveFormat::Pptx);
```

Сравнение ниже показывает одну и ту же диаграмму с видимыми всеми элементами и с скрытым вторым элементом. Столбцы второй серии остаются без изменений.

![Сравнение диаграммы со всеми видимыми элементами легенды и с скрытым вторым элементом; все столбцы остаются видимыми.](hide-legend-entry.png)

В столбцовых, линейных и гистограммных диаграммах элементы легенды идентифицируют серии. Для круговых диаграмм они идентифицируют отдельные точки данных (секторы), поэтому используйте [IChartDataPoint::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_relatedlegendentry/) для выбранного сектора. API документирует этот метод для типов диаграмм `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` и `BarOfPie`. Не предполагайте, что он применяется к кольцевым диаграммам, которые в этом перечне не указаны.

## **Вопросы и ответы**

**Могу ли я заставить диаграмму выделять место для легенды вместо наложения её?**

Да. Вызовите [set_Overlay](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_overlay/) с `false`, чтобы зарезервировать место для легенды вместо разрешения перекрывать область построения.

**Можно ли сделать многострочные подписи легенды?**

Да. Длинные подписи могут переноситься, если доступной ширины недостаточно. Вы также можете использовать символы новой строки в названиях серий для принудительных переносов.

**Как заставить легенду использовать цветовую схему темы презентации?**

Оставьте цвета, заливки и шрифты легенды не заданными, чтобы они могли наследовать форматирование темы. Явное форматирование переопределяет соответствующие настройки темы.