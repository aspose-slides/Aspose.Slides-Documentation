---
title: Получение и обновление свойств представления презентации в C++
linktitle: Свойства представления
type: docs
weight: 80
url: /ru/cpp/presentation-view-properties/
keywords:
- свойства представления
- обычный режим
- контурное содержимое
- контурные значки
- фиксировать вертикальный разделитель
- одиночный просмотр
- состояние полосы
- размер измерения
- автоматическая настройка
- масштаб по умолчанию
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Ознакомьтесь со свойствами представления Aspose.Slides для C++, чтобы настраивать форматы слайдов PPT, PPTX и ODP — регулировать макеты, уровни масштабирования и параметры отображения."
---

{{% alert color="primary" %}} 

Обычный режим просмотра состоит из трёх областей содержимого: самого слайда, боковой области содержимого и нижней области содержимого. Свойства, относящиеся к позиционированию разных областей содержимого. Эта информация позволяет приложению сохранять состояние просмотра в файл, чтобы при повторном открытии просмотр был в том же состоянии, что и при последнем сохранении презентации.

Метод [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) был добавлен для предоставления доступа к свойствам обычного режима просмотра презентации. 

Интерфейсы [INormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/), а также их наследники и перечисление [SplitterBarStateType](https://reference.aspose.com/slides/cpp/aspose.slides/splitterbarstatetype/) были добавлены.

{{% /alert %}} 

## **About INormalViewProperties**

Представляет свойства обычного режима просмотра.

Свойство **ShowOutlineIcons** указывает, следует ли приложению отображать значки при отображении контурного содержимого в любой из областей обычного режима просмотра.

Свойство **SnapVerticalSplitter** определяет, должен ли вертикальный разделитель фиксироваться в свернутом состоянии, когда боковая область достаточно мала.

Свойство **PreferSingleView** указывает, предпочитает ли пользователь видеть одностороннюю область содержимого на весь экран вместо стандартного обычного режима с тремя областями. При включённом значении приложение может отображать одну из областей содержимого во всём окне.

Свойства **VerticalBarState** и **HorizontalBarState** задают состояние, в котором должна отображаться горизонтальная или вертикальная полоса разделителя. Горизонтальная полоса разделителя отделяет слайд от области содержимого под слайдом, вертикальная полоса разделителя отделяет слайд от боковой области содержимого. Возможные значения: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** и **SplitterBarStateType.Restored**.

Свойства **RestoredLeft** и **RestoredTop** определяют размер верхней или боковой области слайда в обычном режиме, когда для **VerticalBarState** и **HorizontalBarState** соответственно применено значение **SplitterBarStateType.Restored**.

## **About Restoring INormalViewProperties**

Указывает размер области слайда (ширина, если это дочерний элемент RestoredTop, высота, если это дочерний элемент RestoredLeft) в обычном режиме, когда область имеет переменный восстановленный размер (не свернута и не развернута). 

Свойство **DimensionSize** задаёт размер области слайда (ширина, если это дочерний элемент restoredTop, высота, если это дочерний элемент restoredLeft).

Свойство **AutoAdjust** определяет, должна ли боковая область содержимого компенсировать новый размер при изменении размера окна, содержащего просмотр в приложении.

Ниже приведён пример, показывающий, как получить доступ к свойствам **ViewProperties.NormalViewProperties** презентации.
```cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// Восстановить свойства просмотра презентации
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```


## **Set the Default Zoom Value**

Aspose.Slides для C++ теперь поддерживает установку значения масштабирования по умолчанию для презентации, так что при открытии презентации масштаб уже установлен. Это можно сделать, задав [ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/) презентации. Свойства просмотра слайда, а также [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_notesviewproperties/) могут быть заданы программно. В этой статье мы рассмотрим на примере, как установить свойства просмотра презентации в Aspose.Slides.

Чтобы установить свойства просмотра, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Задайте [Properties](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/) просмотра презентации.
3. Сохраните презентацию в файл PPTX.

В приведённом ниже примере мы установили значение масштаба как для просмотра слайда, так и для просмотра заметок.
``` cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Установка свойств просмотра презентации
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Значение масштабирования в процентах для просмотра слайда
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Значение масштабирования в процентах для просмотра заметок

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Могу ли я задать разные настройки просмотра для разных секций презентации?**

[View settings](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) определяются на уровне презентации ([Normal View](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), а не для каждой секции, поэтому один набор параметров применяется ко всему документу при открытии.

**Могу ли я заранее задать разные состояния просмотра для разных пользователей?**

Нет. Настройки сохраняются в файле и являются общими. Приложения‑просмотрщики могут учитывать предпочтения пользователя, но сам файл содержит один набор свойств просмотра.

**Могу ли я подготовить шаблон с предопределёнными свойствами просмотра, чтобы новые презентации открывались одинаково?**

Да. Поскольку [view properties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) хранятся на уровне презентации, их можно включить в шаблон и создавать из него новые документы с той же начальной конфигурацией просмотра.