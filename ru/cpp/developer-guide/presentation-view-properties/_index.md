---
title: "Получить и обновить свойства представления презентации в C++"
linktitle: "Свойства представления"
type: docs
weight: 80
url: /ru/cpp/presentation-view-properties/
keywords:
- "свойства представления"
- "обычный режим"
- "контурное содержимое"
- "значки контуров"
- "привязка вертикального разделителя"
- "одиночный просмотр"
- "состояние полосы"
- "размер измерения"
- "автоматическая настройка"
- "масштаб по умолчанию"
- "PowerPoint"
- "OpenDocument"
- "презентация"
- "C++"
- "Aspose.Slides"
description: "Откройте для себя свойства представления Aspose.Slides для C++, чтобы настраивать форматы слайдов PPT, PPTX и ODP — изменять макеты, уровни масштабирования и параметры отображения."
---
## **Введение**

Обычный режим просмотра состоит из трех областей содержимого: самого слайда, боковой области содержимого и нижней области содержимого. Свойства, относящиеся к позиционированию различных областей содержимого. Эта информация позволяет приложению сохранять состояние просмотра в файл, чтобы при повторном открытии просмотр был в том же состоянии, в котором презентация была сохранена в последний раз.

Метод [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) был добавлен для предоставления доступа к свойствам обычного режима просмотра презентации.

Интерфейсы [INormalViewProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/inormalviewrestoredproperties/) и их потомки, перечисление [SplitterBarStateType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/splitterbarstatetype/) были добавлены.

## **О INormalViewProperties**

Представляет свойства обычного режима просмотра.

Свойство **ShowOutlineIcons** указывает, должен ли приложение показывать значки при отображении контурного содержимого в любой из областей обычного режима просмотра.

Свойство **SnapVerticalSplitter** указывает, должен ли вертикальный разделитель переходить в свернутое состояние, когда боковая область достаточно мала.

Свойство **PreferSingleView** указывает, предпочитает ли пользователь видеть одну область содержимого на весь экран вместо стандартного обычного режима с тремя областями. Если включено, приложение может выбрать отображать одну из областей содержимого во всем окне.

Свойства **VerticalBarState** и **HorizontalBarState** указывают состояние, в котором должна отображаться горизонтальная или вертикальная полоса разделителя. Горизонтальная полоса разделителя отделяет слайд от области содержимого под слайдом, вертикальная полоса разделителя отделяет слайд от боковой области содержимого. Возможные значения: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** и **SplitterBarStateType.Restored**.

Свойства **RestoredLeft** и **RestoredTop** задают размер верхней или боковой области слайда обычного режима, когда для **VerticalBarState** и **HorizontalBarState** соответственно применяется значение **SplitterBarStateType.Restored**.

## **О восстановлении INormalViewProperties**

Задает размеры области слайда (ширина, когда является дочерним объектом RestoredTop, высота, когда является дочерним объектом RestoredLeft) обычного режима, когда область имеет переменный восстановленный размер (не свернута и не развернута).

Свойство **DimensionSize** указывает размер области слайда (ширина, когда дочерний объект RestoredTop, высота, когда дочерний объект RestoredLeft).

Свойство **AutoAdjust** указывает, должна ли боковая область содержимого компенсировать новый размер при изменении размера окна, содержащего просмотр в приложении.

Ниже приведен пример, показывающий, как получить доступ к свойствам **ViewProperties.NormalViewProperties** презентации.

``` cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// Восстановить свойства представления презентации
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Установить значение масштаба по умолчанию**

Aspose.Slides для C++ теперь поддерживает установку значения масштаба по умолчанию для презентации, так что при открытии презентации масштаб уже установлен. Это можно сделать, задав [ViewProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/viewproperties/) презентации. Свойства просмотра слайда, а также [get_NotesViewProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/viewproperties/get_notesviewproperties/) могут быть установлены программно. В этой теме мы посмотрим на примере, как установить свойства просмотра презентации в Aspose.Slides.

Для установки свойств просмотра выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/)
1. Установите [Properties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/viewproperties/) просмотра для презентации
1. Сохраните презентацию в файл PPTX

В приведенном ниже примере мы задали значение масштаба для просмотра слайда, а также для просмотра заметок.

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Установка свойств просмотра презентации
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Значение масштаба в процентах для просмотра слайда
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Значение масштаба в процентах для просмотра заметок 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **Установить интервал сетки**

Используйте [Presentation::get_ViewProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_viewproperties/), чтобы получить доступ к общим настройкам просмотра презентации. Методы [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iviewproperties/get_gridspacing/) и [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iviewproperties/set_gridspacing/) читают или изменяют интервал базовой сетки редактирования. Эта настройка применяется ко всей презентации, а не к отдельному слайду. Интервал сетки задается в пунктах, где 72 пункта соответствуют одному дюйму. Используйте положительное значение, как указано в документации API.

Следующий пример открывает существующий `demo.pptx`, выводит текущий интервал сетки, устанавливает интервал в четверть дюйма и сохраняет результат.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto gridSpacing = presentation->get_ViewProperties()->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

presentation->get_ViewProperties()->set_GridSpacing(18.0f);
presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

Сетка отличается от [drawing guides](/slides/ru/cpp/drawing-guides/). Интервал сетки задает регулярный интервал, тогда как направляющие рисуются отдельными горизонтальными или вертикальными линиями выравнивания. Добавление, перемещение или удаление направляющих не изменяют интервал сетки.

И сетка, и направляющие являются вспомогательными средствами редактирования. Они не выводятся как содержимое слайда в PDF, изображениях, SVG или в режиме показа слайдов. Сохранение интервала сетки не гарантирует, что редактор отобразит сетку: её видимость также зависит от настроек просмотра или редактора.

## **Показать или скрыть комментарии при открытии презентации**

Используйте [Presentation::get_ViewProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_viewproperties/), чтобы получить доступ к общим настройкам просмотра презентации. Используйте [IViewProperties::get_ShowComments](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iviewproperties/get_showcomments/) и [IViewProperties::set_ShowComments](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iviewproperties/set_showcomments/), чтобы сохранить предпочтение, показывать ли комментарии при открытии презентации в PowerPoint или другом совместимом редакторе.

Эта настройка управляет только сохранённым предпочтением просмотра. Она не добавляет, не удаляет, не редактирует и не решает комментарии. Сокрытие комментариев сохраняет их содержимое, авторов, позиции, ответы и статусы. См. [Presentation Comments](/slides/ru/cpp/presentation-comments/) для операций, изменяющих сами комментарии.

Следующий пример требует существующего `comments.pptx`, содержащего комментарии. Он выводит текущую настройку видимости, запрашивает скрыть комментарии и сохраняет новый PPTX, не удаляя комментарии. Он также использует [IViewProperties::set_LastView](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iviewproperties/set_lastview/) вместе с [ViewType::SlideView](https://reference.aspose.com/slides/ru/cpp/aspose.slides/viewtype/), чтобы настроить начальный режим редактирования вместе с видимостью комментариев.

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
auto showComments = presentation->get_ViewProperties()->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

presentation->get_ViewProperties()->set_ShowComments(NullableBool::False);
presentation->get_ViewProperties()->set_LastView(ViewType::SlideView);
presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

Эта настройка не определяет, будут ли комментарии включены в экспорт PDF, HTML, изображений, заметок или раздаточных материалов. Настройте соответствующие параметры экспорта отдельно.

## **FAQ**

**Почему сетка не видна после повторного открытия презентации?**

Файл хранит интервал сетки, но редактор управляет её отображением. Проверьте настройки видимости сетки в редакторе.

**Изменяется ли интервал сетки при удалении направляющих?**

Нет. Направляющие и интервал сетки — независимые настройки. Очистка направляющих не изменяет сохранённый интервал сетки.

**Можно ли задать разные настройки просмотра для разных разделов презентации?**

Настройки просмотра ([View settings](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_viewproperties/)) определяются на уровне презентации ([Normal View](https://reference.aspose.com/slides/ru/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ru/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), а не для каждого раздела, поэтому один набор параметров применяется ко всему документу при открытии.

**Можно ли заранее определить разные состояния просмотра для разных пользователей?**

Нет. Настройки хранятся в файле и являются общими. Приложения‑просмотрщики могут учитывать предпочтения пользователя, но в файле содержится один набор свойств просмотра.

**Можно ли подготовить шаблон с предустановленными свойствами просмотра, чтобы новые презентации открывались одинаково?**

Да. Поскольку [view properties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_viewproperties/) сохраняются на уровне презентации, их можно включить в шаблон и создавать новые документы с тем же начальным конфигурированием просмотра.