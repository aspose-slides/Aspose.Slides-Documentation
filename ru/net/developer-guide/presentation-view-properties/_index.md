---
title: Получить и обновить свойства просмотра презентации в .NET
linktitle: Свойства просмотра
type: docs
weight: 80
url: /ru/net/presentation-view-properties/
keywords:
- свойства просмотра
- обычный просмотр
- содержание контура
- значки контура
- фиксация вертикального разделителя
- одиночный просмотр
- состояние полосы
- размер измерения
- автоматическая настройка
- масштаб по умолчанию
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте о свойствах просмотра Aspose.Slides для .NET, позволяющих настраивать форматы PPT, PPTX и ODP — изменять макеты, уровни масштабирования и параметры отображения."
---

{{% alert color="primary" %}} 

Обычный просмотр состоит из трёх областей содержимого: самого слайда, боковой области содержимого и нижней области содержимого. Свойства, относящиеся к позиционированию разных областей содержимого. Эта информация позволяет приложению сохранять состояние просмотра в файл, чтобы при повторном открытии просмотр был в том же состоянии, что и при последнем сохранении презентации.

Свойство [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/properties/normalviewproperties) было добавлено для доступа к свойствам обычного просмотра презентации. 

Были добавлены интерфейсы [INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties) и их потомки, а также перечисление [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype). 

{{% /alert %}}

## **О INormalViewProperties**

Представляет свойства обычного просмотра.

Свойство **ShowOutlineIcons** указывает, должны ли приложения отображать значки при отображении содержимого контура в любой из областей содержимого режима обычного просмотра.

Свойство **SnapVerticalSplitter** указывает, должен ли вертикальный разделитель фиксироваться в свернутом состоянии, когда боковая область достаточно мала.

Свойство **PreferSingleView** указывает, предпочитает ли пользователь видеть одно содержимое во весь экран вместо стандартного обычного просмотра с тремя областями содержимого. Если включено, приложение может выбрать отображение одной из областей содержимого на весь экран.

Свойства **VerticalBarState** и **HorizontalBarState** указывают состояние, в котором должна отображаться горизонтальная или вертикальная полоса разделителя. Горизонтальная полоса разделителя отделяет слайд от области содержимого под слайдом, вертикальная полоса разделителя отделяет слайд от боковой области содержимого. Возможные значения: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** и **SplitterBarStateType.Restored**.

Свойства **RestoredLeft** и **RestoredTop** задают размеры верхней или боковой области слайда обычного просмотра, когда для **VerticalBarState** и **HorizontalBarState** соответственно применяется значение **SplitterBarStateType.Restored**.

## **О восстановлении INormalViewProperties** 

Задает размеры области слайда (ширина, когда является дочерним элементом RestoredTop, высота, когда является дочерним элементом RestoredLeft) обычного просмотра, когда область имеет переменный восстановленный размер (не свернута и не развёрнута). 

Свойство **DimensionSize** задает размер области слайда (ширина, когда дочерний элемент restoredTop, высота, когда дочерний элемент restoredLeft).

Свойство **AutoAdjust** указывает, должна ли ширина боковой области содержимого компенсировать новый размер при изменении размеров окна, содержащего просмотр в приложении.

Ниже приведён пример, показывающий, как получить доступ к свойствам **ViewProperties.NormalViewProperties** для презентации.
```c#
using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // Восстановить свойства просмотра презентации
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```


## **Установка значения масштаба по умолчанию**

Aspose.Slides для .NET теперь поддерживает установку значения масштаба по умолчанию для презентации, так чтобы при открытии презентации масштаб уже был установлен. Это можно сделать, задав [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) презентации. Свойства просмотра слайда, а также [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/properties/notesviewproperties) могут быть заданы программно. В этой статье мы рассмотрим на примере, как установить свойства просмотра презентации в Aspose.Slides.

Чтобы установить свойства просмотра, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)
1. Задайте [Properties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) просмотра для презентации
1. Сохраните презентацию в файл PPTX

В приведённом ниже примере мы задали значение масштаба как для просмотра слайда, так и для просмотра заметок.
```c#
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Установка свойств просмотра презентации
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Значение масштабирования в процентах для просмотра слайда
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Значение масштабирования в процентах для просмотра заметок 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Могу ли я задать разные настройки просмотра для разных разделов презентации?**

[Настройки просмотра](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) определяются на уровне презентации ([Normal View](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/slideviewproperties/)), а не для каждого раздела, поэтому один набор параметров применяется ко всему документу при открытии.

**Могу ли я заранее задать разные состояния просмотра для разных пользователей?**

Нет. Настройки хранятся в файле и являются общими. Приложения‑просмотрщики могут учитывать предпочтения пользователя, но сам файл содержит один набор свойств просмотра.

**Могу ли я подготовить шаблон с предопределёнными свойствами просмотра, чтобы новые презентации открывались одинаково?**

Да. Поскольку [свойства просмотра](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) хранятся на уровне презентации, их можно встроить в шаблон и создавать из него новые документы с одинаковой первоначальной конфигурацией просмотра.