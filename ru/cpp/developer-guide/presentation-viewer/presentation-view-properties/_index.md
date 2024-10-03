---
title: Свойства режима представления
type: docs
url: /ru/cpp/presentation-view-properties/
---

{{% alert color="primary" %}} 

Обычное представление состоит из трех областей содержимого: самого слайда, боковой области содержимого и нижней области содержимого. Свойства, касающиеся позиционирования различных областей содержимого. Эта информация позволяет приложению сохранять состояние своего представления в файл, чтобы при повторном открытии представление находилось в том же состоянии, что и при последнем сохранении презентации.

Метод [**IViewProperties::get_NormalViewProperties()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_view_properties#aa8add44edf3e3ac578e0bf8f32617b06) был добавлен для предоставления доступа к свойствам обычного представления презентации. 

Добавлены интерфейсы [**INormalViewProperties**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_normal_view_properties), [**INormalViewRestoredProperties**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_normal_view_restored_properties) и их потомки, перечисление [**SplitterBarStateType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#ac12b36e68eb35cfd6ae026915e071950).

{{% /alert %}} 



## **О INormalViewProperties** #

Представляет свойства обычного представления.

Свойство **ShowOutlineIcons** указывает, следует ли приложению отображать значки, если отображается контент структуры в любой из областей содержимого обычного режима представления.

Свойство **SnapVerticalSplitter** указывает, должен ли вертикальный разделитель сжиматься в минимальное состояние, когда боковая область достаточно мала.

Свойство **PreferSingleView** указывает, предпочитает ли пользователь видеть полноэкранную однообъектную область вместо стандартного обычного представления с тремя областями содержимого. Если включено, приложение может выбрать отображение одной из областей содержимого на весь экран.

Свойства **VerticalBarState** и **HorizontalBarState** указывают состояние, в котором должен отображаться горизонтальный или вертикальный разделитель. Горизонтальный разделитель отделяет слайд от области содержимого под слайдом, вертикальный разделитель отделяет слайд от боковой области содержимого. Возможные значения: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** и **SplitterBarStateType.Restored.**

Свойства **RestoredLeft** и **RestoredTop** указывают размеры верхней или боковой области слайда обычного представления, когда значение **SplitterBarStateType.Restored** применяется для **VerticalBarState** и **HorizontalBarState** соответственно.



## **О INormalViewRestoredProperties** #

Указывает размеры области слайда (ширина, когда это дочерний элемент RestoredTop, высота, когда это дочерний элемент RestoredLeft) обычного представления, когда область имеет переменный восстановленный размер (не минимизированный и не максимизированный).

Свойство **DimensionSize** указывает размер области слайда (ширина, когда это дочерний элемент restoredTop, высота, когда это дочерний элемент restoredLeft).

Свойство **AutoAdjust** указывает, следует ли размер боковой области содержимого компенсировать новый размер при изменении размеров окна, содержащего представление в приложении.

Пример приведен ниже, показывающий, как можно получить доступ к свойствам **ViewProperties.NormalViewProperties** для презентации.

``` cpp
//Создание объекта-презентации, представляющего файл презентации
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```


## **Установить значение зума по умолчанию**
Aspose.Slides для C++ теперь поддерживает установку значения зума по умолчанию для презентации, так что при открытии презентации зум уже установлен. Это можно сделать, установив [**ViewProperties**](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties) презентации. Свойства вида слайдов, а также [get_NotesViewProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties#a86ad6559c9c0768d8210fdb86c86cf98) могут быть установлены программно. В этой теме мы увидим на примере, как установить свойства представления презентации в Aspose.Slides.

Чтобы установить свойства представления, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Установите свойства представления [Properties](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties) презентации.
1. Сохраните презентацию в виде файла PPTX.

В приведенном ниже примере мы установили значение зума для представления слайдов, а также для представления заметок.

``` cpp
// Создание объекта-презентации, представляющего файл презентации
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
// Установка свойств представления презентации

presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100);
// Значение зума в процентах для представления слайдов
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100);
// Значение зума в процентах для представления заметок 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```



## **Установить свойства представления**
Чтобы установить свойства представления, выполните следующие действия:

1. Создайте экземпляр класса Presentation.
1. Установите свойства представления презентации.
1. Сохраните презентацию в виде файла PPTX.

В приведенном ниже примере мы установили значение зума для представления слайдов, а также для представления заметок.

``` cpp
// Создание объекта-презентации, представляющего файл презентации
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Установка свойств представления презентации
// Значение зума в процентах для представления слайдов
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100);
// Значение зума в процентах для представления заметок
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100);

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```