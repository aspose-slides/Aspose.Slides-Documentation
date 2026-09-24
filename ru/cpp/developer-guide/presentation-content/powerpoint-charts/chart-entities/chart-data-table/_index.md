---
title: Настройка таблиц данных диаграмм в презентациях с помощью C++
linktitle: Таблица данных
type: docs
url: /ru/cpp/chart-data-table/
keywords:
- данные диаграммы
- таблица данных
- свойства шрифта
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Настройте шрифты, границы и ключи легенды таблицы данных диаграммы в презентациях PowerPoint с использованием Aspose.Slides для C++."
---
## **Обзор**

Aspose.Slides для C++ позволяет отображать таблицу данных диаграммы и настраивать форматирование текста, границы и ключи легенды. В этой статье объясняется, как включить таблицу, отформатировать её текст, управлять каждым типом границы и показывать или скрывать ключи легенды. Примеры сохраняют сконфигурированные диаграммы в файлы PPTX.

## **Установить свойства шрифта**

Чтобы отобразить таблицу данных диаграммы, передайте `true` в [IChart::set_HasDataTable](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichart/set_hasdatatable/). Используйте [IChart::get_ChartDataTable](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichart/get_chartdatatable/) , чтобы получить доступ к таблице и настроить её форматирование текста.

1. Загрузите презентацию, используя класс [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
1. Добавьте сгруппированную столбчатую диаграмму на первый слайд.
1. Включите таблицу данных диаграммы.
1. Включите полужирный текст с помощью [IBasePortionFormat::set_FontBold](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseportionformat/set_fontbold/) и передайте `20` в [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseportionformat/set_fontheight/) для текста размером 20 пунктов.
1. Сохраните изменённую презентацию.

Следующий пример требует файл `test.pptx` в рабочем каталоге, содержащий по крайней мере один слайд. Он добавляет диаграмму с данными по умолчанию в позицию (50, 50) с шириной 600 пунктов и высотой 400 пунктов. Сохранённый `output.pptx` содержит диаграмму с включённой таблицей данных и применёнными указанными параметрами шрифта.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"test.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto portionFormat = chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat();
portionFormat->set_FontBold(NullableBool::True);
portionFormat->set_FontHeight(20.0f);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Настроить границы таблицы данных**

Включите таблицу с помощью [IChart::set_HasDataTable](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichart/set_hasdatatable/) и получите к ней доступ через [IChart::get_ChartDataTable](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichart/get_chartdatatable/). Вы можете управлять тремя типами границ независимо:

- [IDataTable::set_HasBorderHorizontal](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/idatatable/set_hasborderhorizontal/) контролирует горизонтальные границы ячеек.
- [IDataTable::set_HasBorderVertical](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/idatatable/set_hasbordervertical/) контролирует вертикальные границы ячеек.
- [IDataTable::set_HasBorderOutline](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/idatatable/set_hasborderoutline/) контролирует внешнюю границу таблицы.

Передайте `true` каждому сеттеру, чтобы отобразить соответствующие границы, или `false`, чтобы скрыть их. Следующий пример создаёт сгруппированную столбчатую диаграмму с данными по умолчанию, отображает горизонтальные границы и внешнюю границу, а вертикальные границы скрывает. Входной файл не требуется. Позиция и размер диаграммы указаны в пунктах.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(false);
dataTable->set_HasBorderOutline(true);

presentation->Save(u"data-table-borders.pptx", SaveFormat::Pptx);
```

Сравнение ниже использует одинаковые данные диаграммы и настройки ключей легенды во всех четырёх случаях. Начиная с включённых всех границ, каждый последующий вариант отключает только одну настройку границы. Нижний левый вариант соответствует настройкам границ в примере.

![Таблицы данных диаграмм со всеми включёнными границами, без горизонтальных границ, без вертикальных границ и без внешней границы](data-table-borders.png)

## **Показать или скрыть ключи легенды**

Ключи легенды — небольшие цветные маркеры рядом с названиями рядов в таблице данных. Они помогают читателям сопоставлять каждую строку таблицы с рядом диаграммы. Передайте `true` в [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/idatatable/set_showlegendkey/), чтобы показать эти маркеры, или `false`, чтобы скрыть их.

Отдельная легенда диаграммы управляется с помощью [IChart::set_HasLegend](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichart/set_haslegend/). Эти настройки независимы: скрытие отдельной легенды не скрывает ключи внутри таблицы данных, и скрытие ключей таблицы не скрывает отдельную легенду.

Следующий пример создаёт диаграмму с данными по умолчанию, включает её таблицу данных и показывает ключи легенды внутри неё, одновременно скрывая отдельную легенду. Все границы таблицы явно включены. Входная презентация не требуется. Чтобы скрыть только ключи таблицы, передайте `false` в [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/idatatable/set_showlegendkey/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);
chart->set_HasLegend(false);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(true);
dataTable->set_HasBorderOutline(true);
dataTable->set_ShowLegendKey(true);

presentation->Save(u"data-table-legend-keys.pptx", SaveFormat::Pptx);
```

Сравнение ниже показывает одну и ту же таблицу с включенными и отключёнными ключами легенды. Все границы остаются включёнными, а отдельная легенда диаграммы скрыта в обоих случаях.

![Таблицы данных диаграмм с показанными слева ключами легенды и скрытыми справа](data-table-legend-keys.png)

## **FAQ**

**Могу ли я показывать ключи легенды в таблице данных диаграммы?**

Да. Передайте `true` в [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/idatatable/set_showlegendkey/), чтобы отобразить ключи легенды, или `false`, чтобы скрыть их.

**Сохраняется ли таблица данных при экспорте презентации в PDF, HTML или изображения?**

Да. Aspose.Slides рендерит диаграмму и её отображаемую таблицу данных как часть слайда при экспорте в [PDF](/slides/ru/cpp/convert-powerpoint-to-pdf/), [HTML](/slides/ru/cpp/convert-powerpoint-to-html/) или [images](/slides/ru/cpp/convert-powerpoint-to-png/).

**Можно ли работать с таблицами данных в диаграммах, загруженных из шаблона?**

Да. Для диаграммы, загруженной из существующей презентации или шаблона, используйте [IChart::get_HasDataTable](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichart/get_hasdatatable/), чтобы проверить, отображается ли её таблица данных, и [IChart::set_HasDataTable](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichart/set_hasdatatable/), чтобы изменить её видимость.

**Как найти диаграммы, у которых включена таблица данных?**

Итерируйте формы на каждом слайде, определяйте диаграммы и проверяйте результат [IChart::get_HasDataTable](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichart/get_hasdatatable/). Значение `true` указывает, что таблица данных включена.