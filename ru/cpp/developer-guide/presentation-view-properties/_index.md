---
title: Получить и обновить свойства просмотра презентации в C++
linktitle: Свойства просмотра
type: docs
weight: 80
url: /ru/cpp/presentation-view-properties/
keywords:
- свойства просмотра
- нормальный режим
- содержание плана
- значки плана
- привязка вертикального разделителя
- одиночный режим
- состояние разделителя
- размер измерения
- автоматическая корректировка
- масштаб по умолчанию
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Узнайте о свойствах просмотра Aspose.Slides for C++, позволяющих настраивать форматы слайдов PPT, PPTX и ODP — изменять макеты, уровни масштабирования и параметры отображения."
---
## **Введение**

Нормальный режим просмотра состоит из трёх областей содержимого: самого слайда, боковой области содержимого и нижней области содержимого. Свойства, относящиеся к позиционированию разных областей содержимого. Эта информация позволяет приложению сохранять состояние вида в файл, чтобы при повторном открытии вид был в том же состоянии, в каком презентация была сохранена в последний раз.

Метод [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) добавлен для предоставления доступа к свойствам normal view презентации.

Интерфейсы [INormalViewProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/inormalviewrestoredproperties/) и их потомки, перечисление [SplitterBarStateType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/splitterbarstatetype/) были добавлены.

## **О INormalViewProperties**

Представляет свойства normal view.

Свойство **ShowOutlineIcons** указывает, следует ли приложению отображать значки при отображении контента плана в любой из областей содержимого режима normal view.

Свойство **SnapVerticalSplitter** указывает, следует ли вертикальному разделителю переходить в свернутое состояние, когда боковая область достаточно мала.

Свойство **PreferSingleView** указывает, предпочитает ли пользователь видеть одну полноэкранную область содержимого вместо стандартного normal view с тремя областями содержимого. При включённом параметре приложение может выбрать отображение одной из областей содержимого на весь экран.

Свойства **VerticalBarState** и **HorizontalBarState** указывают состояние, в котором должна отображаться горизонтальная или вертикальная полоса разделителя. Горизонтальная полоса разделителя отделяет слайд от области содержимого под слайдом, вертикальная полоса разделителя отделяет слайд от боковой области содержимого. Возможные значения: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** и **SplitterBarStateType.Restored**.

Свойства **RestoredLeft** и **RestoredTop** задают размеры верхней или боковой области слайда normal view, когда для **VerticalBarState** и **HorizontalBarState** соответственно применяется значение **SplitterBarStateType.Restored**.

## **О восстановлении INormalViewProperties**

Задает размеры области слайда (ширина, когда является дочерним элементом RestoredTop, высота, когда является дочерним элементом RestoredLeft) normal view, когда область имеет переменный восстановленный размер (не свернута и не развернута).

Свойство **DimensionSize** задает размер области слайда (ширина, когда является дочерним элементом restoredTop, высота, когда является дочерним элементом restoredLeft).

Свойство **AutoAdjust** указывает, должна ли боковая область содержимого компенсировать новый размер при изменении размеров окна, содержащего вид в приложении.

Ниже приведён пример, показывающий, как получить доступ к свойствам **ViewProperties.NormalViewProperties** для презентации.

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

// Восстановить свойства просмотра презентации
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Установить значение масштабирования по умолчанию**

Aspose.Slides for C++ теперь поддерживает установку значения масштабирования по умолчанию для презентации, так что при её открытии масштаб уже установлен. Это можно сделать, задав [ViewProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/viewproperties/) презентации. Свойства просмотра слайда, а также [get_NotesViewProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/viewproperties/get_notesviewproperties/) можно установить программно. В этой теме мы покажем на примере, как установить свойства вида презентации в Aspose.Slides.

Чтобы установить свойства вида, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/)
1. Задайте View [Properties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/viewproperties/) презентации
1. Сохраните презентацию как файл PPTX

В приведённом ниже примере мы задали значение масштабирования как для просмотра слайда, так и для просмотра заметок.

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Установка свойств просмотра презентации
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Значение масштабирования в процентах для просмотра слайда
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Значение масштабирования в процентах для просмотра заметок 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **Установить интервал сетки**

Используйте [Presentation::get_ViewProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_viewproperties/) для доступа к настройкам просмотра на уровне презентации. Методы [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iviewproperties/get_gridspacing/) и [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iviewproperties/set_gridspacing/) читают или изменяют интервал базовой сетки редактирования. Эта настройка применяется ко всей презентации, а не к отдельному слайду. Интервал сетки указывается в пунктах, где 72 пункта равны одному дюйму. Используйте положительное значение, как указано в документации API.

В следующем примере открывается существующий `demo.pptx`, выводится текущий интервал сетки, устанавливается интервал в четверть дюйма и сохраняется результат.

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

Сетка отличается от [drawing guides](/slides/ru/cpp/drawing-guides/). Интервал сетки задаёт регулярный шаг, тогда как направляющие — отдельные горизонтальные или вертикальные линии выравнивания. Добавление, перемещение или удаление направляющих не меняет интервал сетки.

И сетка, и направляющие являются вспомогательными средствами редактирования. Они не рендерятся как содержимое слайда в PDF, изображениях, SVG или при показе слайдов. Сохранение интервала сетки не гарантирует, что редактор отобразит её: её видимость также зависит от настроек просмотрщика или редактора.

## **FAQ**

**Почему сетка не видна после повторного открытия презентации?**

Файл сохраняет интервал сетки, но редактор решает, отображать её или нет. Проверьте настройки видимости сетки в редакторе.

**Изменяется ли интервал сетки при удалении направляющих?**

Нет. Направляющие и интервал сетки — независимые настройки. Очистка направляющих оставляет сохранённый интервал сетки без изменений.

**Можно ли задать разные настройки просмотра для разных разделов презентации?**

[View settings](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_viewproperties/) определяются на уровне презентации ([Normal View](https://reference.aspose.com/slides/ru/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ru/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), а не для каждого раздела, поэтому один набор параметров применяется ко всему документу при открытии.

**Можно ли заранее определить разные состояния просмотра для разных пользователей?**

Нет. Настройки сохраняются в файле и являются общими. Приложения‑просмотрщики могут учитывать предпочтения пользователя, но сам файл содержит один набор свойств просмотра.

**Можно ли подготовить шаблон с предустановленными свойствами просмотра, чтобы новые презентации открывались одинаково?**

Да. Поскольку [view properties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_viewproperties/) хранятся на уровне презентации, их можно включить в шаблон и создавать новые документы на его основе с той же начальной конфигурацией вида.