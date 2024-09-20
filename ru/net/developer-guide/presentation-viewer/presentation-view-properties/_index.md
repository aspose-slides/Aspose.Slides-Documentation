---
title: Свойства представления
type: docs
url: /net/presentation-view-properties/
keywords: "просмотрщик PowerPoint, свойства просмотра, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Свойства просмотрщика презентаций PowerPoint на C# или .NET"
---

{{% alert color="primary" %}} 

Нормальное представление состоит из трех областей контента: слайд, область контента сбоку и область контента внизу. Свойства, относящиеся к позиционированию различных областей контента. Эта информация позволяет приложению сохранять свое состояние представления в файл, чтобы при повторном открытии представление находилось в том же состоянии, в котором презентация была сохранена в последний раз.

Свойство [**IViewProperties.NormalViewProperties**](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/properties/normalviewproperties) было добавлено для доступа к свойствам нормального представления презентации. 

Добавлены интерфейсы [**INormalViewProperties**](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties), [**INormalViewRestoredProperties**](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties) и их потомки, перечисление [**SplitterBarStateType**](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype).

{{% /alert %}} 



## **О INormalViewProperties** #

Представляет свойства нормального представления.

Свойство **ShowOutlineIcons** указывает, должен ли приложение отображать значки, если отображается контент в виде схемы в любой из областей контента нормального режима представления.

Свойство **SnapVerticalSplitter** указывает, должен ли вертикальный разделитель прилипать к минимизированному состоянию, когда боковая область достаточно мала.

Свойство **PreferSingleView** указывает, предпочитает ли пользователь видеть одноконтентную область во весь экран вместо стандартного нормального представления с тремя областями контента. Если включено, приложение может выбирать для отображения одну из областей контента на весь экран.

Свойства **VerticalBarState** и **HorizontalBarState** указывают состояние, в котором должен быть показан горизонтальный или вертикальный разделитель. Горизонтальный разделитель отделяет слайд от области контента под слайдом, вертикальный разделитель отделяет слайд от боковой области контента. Возможные значения: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** и **SplitterBarStateType.Restored.**

Свойства **RestoredLeft** и **RestoredTop** указывают размеры верхней или боковой области слайда нормального представления, когда применяется значение **SplitterBarStateType.Restored** для **VerticalBarState** и **HorizontalBarState** соответственно.



## **О INormalViewRestoredProperties** #

Указывает размер области слайда (ширина при дочернем элементе RestoredTop, высота при дочернем элементе RestoredLeft) нормального представления, когда область имеет переменный восстановленный размер (ни минимизированный, ни максимизированный).

Свойство **DimensionSize** указывает размер области слайда (ширина при дочернем элементе restoredTop, высота при дочернем элементе restoredLeft).

Свойство **AutoAdjust** указывает, должен ли размер боковой области контента компенсировать новый размер при изменении размера окна, содержащего представление внутри приложения.

Пример ниже показывает, как можно получить доступ к свойствам **ViewProperties.NormalViewProperties** для презентации.

```c#
// Создание объекта презентации, представляющего файл презентации
using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```




## **Установка значения по умолчанию для значения зума**
Aspose.Slides для .NET теперь поддерживает установку значения по умолчанию для зума презентации, чтобы при открытии презентации зум уже был установлен. Это можно сделать, установив [**ViewProperties**](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) презентации. Свойства просмотра слайдов, а также [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/properties/notesviewproperties) можно установить программно. В этой теме мы увидим на примере, как установить свойства просмотра презентации в Aspose.Slides.

Чтобы установить свойства просмотра, пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Установите свойства просмотра [Properties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) презентации.
1. Запишите презентацию в файл PPTX.

В приведенном ниже примере мы установили значение зума для просмотра слайдов, а также для просмотра заметок.

```c#
// Создание объекта презентации, представляющего файл презентации
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Установка свойств просмотра презентации

    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Значение зума в процентах для просмотра слайдов
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Значение зума в процентах для просмотра заметок

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```



## **Установка свойств просмотра**
Чтобы установить свойства просмотра, пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса Presentation.
1. Установите свойства просмотра презентации.
1. Запишите презентацию в файл PPTX.

В приведенном ниже примере мы установили значение зума для просмотра слайдов, а также для просмотра заметок.

```c#
// Создание объекта презентации, представляющего файл презентации
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Установка свойств просмотра презентации

    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Значение зума в процентах для просмотра слайдов
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Значение зума в процентах для просмотра заметок

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```