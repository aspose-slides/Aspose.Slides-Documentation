---
title: "Получить и обновить свойства представления презентации в C++"
linktitle: "Свойства представления"
type: docs
weight: 80
url: /ru/cpp/presentation-view-properties/
keywords:
  - "свойства представления"
  - "обычный просмотр"
  - "содержимое плана"
  - "значки плана"
  - "привязка вертикального разделителя"
  - "один просмотр"
  - "состояние полосы"
  - "размер измерения"
  - "автонастройка"
  - "масштаб по умолчанию"
  - "PowerPoint"
  - "OpenDocument"
  - "презентация"
  - "C++"
  - "Aspose.Slides"
description: "Откройте для себя свойства представления Aspose.Slides для C++, позволяющие настраивать форматы слайдов PPT, PPTX и ODP — регулировать макеты, уровни масштабирования и параметры отображения."
---

{{% alert color="primary" %}} 

Обычный просмотр состоит из трёх областей содержимого: самого слайда, боковой области содержимого и нижней области содержимого. Свойства, относящиеся к позиционированию разных областей содержимого. Эта информация позволяет приложению сохранить состояние представления в файл, чтобы при повторном открытии представление находилось в том же состоянии, в котором презентация была сохранена в последний раз.

Метод [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_view_properties#aa8add44edf3e3ac578e0bf8f32617b06) был добавлен для предоставления доступа к свойствам обычного просмотра презентации. 

Интерфейсы [INormalViewProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_normal_view_properties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_normal_view_restored_properties) и их потомки, перечисление [SplitterBarStateType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#ac12b36e68eb35cfd6ae026915e071950) были добавлены.

{{% /alert %}} 

## **About INormalViewProperties**

Представляет свойства обычного просмотра.

Свойство **ShowOutlineIcons** указывает, должен ли приложение показывать значки при отображении содержимого плана в любой из областей содержимого режима обычного просмотра.

Свойство **SnapVerticalSplitter** указывает, должен ли вертикальный разделитель «прилипать» к минимизированному состоянию, когда боковая область достаточно маленька.

Свойство **PreferSingleView** указывает, предпочитает ли пользователь видеть одно окно с единой областью содержимого вместо стандартного обычного просмотра с тремя областями. Если включено, приложение может выбрать отображение одной из областей содержимого во весь экран.

Свойства **VerticalBarState** и **HorizontalBarState** указывают состояние, в котором должна отображаться горизонтальная или вертикальная полоса разделителя. Горизонтальная полоса разделяет слайд от области содержимого под слайдом, вертикальная полоса разделяет слайд от боковой области содержимого. Возможные значения: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** и **SplitterBarStateType.Restored**.

Свойства **RestoredLeft** и **RestoredTop** указывают размеры верхней или боковой области слайда обычного просмотра, когда для **VerticalBarState** и **HorizontalBarState** соответственно применено значение **SplitterBarStateType.Restored**.

## **About Restoring INormalViewProperties**

Указывает размеры области слайда (ширина, когда является дочерним элементом RestoredTop, высота, когда является дочерним элементом RestoredLeft) обычного просмотра, когда область имеет переменный восстановленный размер (не минимизирована и не максимизирована). 

Свойство **DimensionSize** указывает размер области слайда (ширина, когда является дочерним элементом restoredTop, высота, когда является дочерним элементом restoredLeft).

Свойство **AutoAdjust** указывает, должна ли размер боковой области содержимого компенсировать новый размер при изменении размеров окна, содержащего представление в приложении.

Ниже приведён пример, показывающий, как получить доступ к свойствам **ViewProperties.NormalViewProperties** презентации.
``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// Восстановить свойства представления презентации
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```


## **Set the Default Zoom Value**

Aspose.Slides for C++ теперь поддерживает установку значения масштаба по умолчанию для презентации, так что при открытии презентации масштаб уже установлен. Это можно сделать, задав [ViewProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties) презентации. Свойства просмотра слайда, а также [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties#a86ad6559c9c0768d8210fdb86c86cf98) могут быть установлены программно. В этой статье мы рассмотрим пример, как задать свойства просмотра презентации в Aspose.Slides.

Чтобы задать свойства просмотра, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)
1. Задайте свойства просмотра [Properties](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties) презентации
1. Сохраните презентацию в файл PPTX

В приведённом ниже примере мы задали значение масштаба для просмотра слайда, а также для просмотра заметок.
``` cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Установка свойств представления презентации
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Значение масштаба в процентах для просмотра слайда
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Значение масштаба в процентах для просмотра заметок

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Can I set different view settings for different sections of a presentation?**

[View settings](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) определяются на уровне презентации ([Normal View](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), а не для каждой секции, поэтому один набор параметров применяется ко всему документу при открытии.

**Can I predefine different view states for different users?**

Нет. Настройки сохраняются в файле и являются общими. Приложения‑просмотрщики могут учитывать предпочтения пользователя, но сам файл содержит один набор свойств просмотра.

**Can I prepare a template with predefined View Properties so new presentations open the same way?**

Да. Поскольку [view properties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) хранятся на уровне презентации, вы можете внедрить их в шаблон и создавать новые документы на его основе с теми же начальными настройками просмотра.