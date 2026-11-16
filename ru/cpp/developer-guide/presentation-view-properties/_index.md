---
title: Получить и обновить свойства представления презентации в C++
linktitle: Свойства представления
type: docs
weight: 80
url: /ru/cpp/presentation-view-properties/
keywords:
- свойства представления
- нормальный вид
- содержание схемы
- значки схемы
- фиксация вертикального разделителя
- однопанельный режим
- состояние панели
- размер измерения
- автоматическая настройка
- масштаб по умолчанию
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Используйте Aspose.Slides для C++, чтобы настроить макет нормального вида, масштаб слайда и заметок, интервал сетки и видимость комментариев в презентациях PowerPoint."
---
## **Введение**

В обычном представлении PowerPoint слайд отображается между боковой панелью миниатюр или схемой и панелью заметок внизу. Aspose.Slides for C++ раскрывает сохранённые настройки редактирования презентации через [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/). Эти настройки включают расположение панелей, уровни масштабирования, интервал сетки и видимость комментариев.

## **О INormalViewProperties**

Используйте [get_NormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) для доступа к интерфейсу [INormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/). [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) управляет тем, появляются ли значки рядом с заголовками слайдов в схеме. [set_SnapVerticalSplitter](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_snapverticalsplitter/) позволяет боковой панели зафиксировать своё минимизированное состояние, когда пользователь сжимает её. [set_PreferSingleView](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_prefersingleview/) указывает предпочтение отображения одной панели во весь окно.

[set_VerticalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_verticalbarstate/) управляет разделителем между боковой панелью и слайдом. [set_HorizontalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_horizontalbarstate/) управляет разделителем над панелью заметок. Оба принимают значение типа [SplitterBarStateType](https://reference.aspose.com/slides/cpp/aspose.slides/splitterbarstatetype/) — `Minimized`, `Maximized` или `Restored`.

## **О восстановлении INormalViewProperties**

Когда разделитель восстанавливается, [get_RestoredLeft](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredleft/) возвращает сохранённый размер боковой панели, а [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) — сохранённый размер верхней области слайда. Оба раскрывают интерфейс [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/). Его метод [set_DimensionSize](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_dimensionsize/) принимает процент от 0 до 100, а [set_AutoAdjust](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_autoadjust/) управляет тем, будет ли редактор автоматически корректировать размер при изменении окна.

В этом примере обновляется существующая презентация. Восстанавливается горизонтальный разделитель, устанавливается размер верхней области слайда, получаемый через [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/), на 80 % с включённым автоматическим подстройкой, а вертикальный разделитель разворачивается в максимальное состояние. Также включаются значки схемы с помощью [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) для режима схемы.

```cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto normalView = presentation->get_ViewProperties()->get_NormalViewProperties();
normalView->set_HorizontalBarState(SplitterBarStateType::Restored);
normalView->set_VerticalBarState(SplitterBarStateType::Maximized);
auto restoredTop = normalView->get_RestoredTop();
restoredTop->set_AutoAdjust(true);
restoredTop->set_DimensionSize(80.0f);
normalView->set_ShowOutlineIcons(true);

presentation->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Установить значение масштабирования по умолчанию**

[get_SlideViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_slideviewproperties/) и [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_notesviewproperties/) хранят независимые настройки масштабирования для редактора. Эти настройки не влияют на размеры слайдов, воспроизведение показа или разрешение при экспорте изображений.

В этом примере открывается существующая презентация и включается автоматическое масштабирование с помощью [set_VariableScale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_variablescale/) для подгонки слайда под окно редактирования. Для страницы заметок автоматическое масштабирование отключается, а [set_Scale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_scale/) задаёт фиксированный масштаб 80 %.

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
viewProperties->get_SlideViewProperties()->set_VariableScale(true);
auto notesView = viewProperties->get_NotesViewProperties();
notesView->set_VariableScale(false);
notesView->set_Scale(80);

presentation->Save(u"zoom.pptx", SaveFormat::Pptx);
```

## **Установить интервал сетки**

[set_GridSpacing](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_gridspacing/) задаёт расстояние между линиями редактирующей сетки по всей презентации. Принимает положительное значение в пунктах, где 72 пункта = 1 дюйм. В этом примере выводится текущее значение интервала в существующей презентации и сохраняется сетка с шагом в четверть дюйма, установив интервал в 18 пунктов.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
auto gridSpacing = viewProperties->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

viewProperties->set_GridSpacing(18.0f);

presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

Сетка повторяется через фиксированный интервал. [Drawing guides](/slides/ru/cpp/drawing-guides/) отмечают отдельные горизонтальные или вертикальные позиции. Оба служат вспомогательными средствами редактирования и отображаются только в редакторах, которые их показывают. При показе слайдов и экспорте в PDF, изображения или SVG они не учитываются.

## **Показать или скрыть комментарии при открытии презентации**

[set_ShowComments](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_showcomments/) сохраняет предпочтение, которое совместимые редакторы используют при открытии презентации. Для существующей презентации с комментариями этот пример выводит текущую настройку и сохраняет копию с скрытыми комментариями. Также вызывается [set_LastView](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_lastview/) с параметром [ViewType::SlideView](https://reference.aspose.com/slides/cpp/aspose.slides/viewtype/)‑, чтобы копия открылась в режиме просмотра слайдов.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <ViewType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"comments.pptx");

auto viewProperties = presentation->get_ViewProperties();
auto showComments = viewProperties->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

viewProperties->set_ShowComments(NullableBool::False);
viewProperties->set_LastView(ViewType::SlideView);

presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

Скрытие комментариев сохраняет их текст, авторов, позиции, ответы и статусы. Чтобы изменить сами комментарии, см. раздел [Presentation Comments](/slides/ru/cpp/presentation-comments/). Параметры экспорта управляют тем, будут ли комментарии отображаться в PDF, HTML, изображениях, заметках или раздаточных материалах.

## **Часто задаваемые вопросы**

**Почему сетка скрыта при повторном открытии презентации?**  
Презентация хранит значение интервала сетки. Чтобы увидеть сетку, включите её отображение в редакторе.

**Изменяет ли удаление направляющих сетку?**  
Нет. Добавление, перемещение или удаление направляющей не меняет значение интервала сетки.

**Могут ли разные секции презентации иметь разные настройки представления?**  
Нет. [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) применяется ко всей презентации.

**Могу ли я сохранять разные настройки представления для разных пользователей?**  
Файл хранит один набор свойств представления для всех. Редактор может также применять локальные предпочтения пользователя.

**Можно ли сохранять настройки представления в шаблоне?**  
Да. Презентации, созданные из шаблона, наследуют сохранённые в нём настройки представления.