---
title: Свойства просмотра презентации
type: docs
weight: 80
url: /ru/net/presentation-view-properties/
keywords:
- свойства просмотра
- обычный просмотр
- контурное содержание
- значки контура
- фиксировать вертикальный разделитель
- единый просмотр
- состояние полосы
- размер измерения
- автоматическая регулировка
- масштаб по умолчанию
- PowerPoint
- презентация
- C#
- Csharp
- Aspose.Slides для .NET
description: "Управляйте свойствами просмотра презентаций PowerPoint в C# или .NET"
---

{{% alert color="primary" %}} 

Обычный просмотр состоит из трех областей содержимого: самого слайда, боковой области содержимого и нижней области содержимого. Свойства, относящиеся к позиционированию различных областей содержимого. Эта информация позволяет приложению сохранять состояние просмотра в файл, чтобы при повторном открытии просмотр находился в том же состоянии, что и при последнем сохранении презентации.

Свойство [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/properties/normalviewproperties) было добавлено для предоставления доступа к свойствам обычного просмотра презентации.

Интерфейсы [INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties) и их наследники, а также перечисление [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype) были добавлены.

{{% /alert %}}

## **О INormalViewProperties**

Представляет свойства обычного просмотра.

Свойство **ShowOutlineIcons** указывает, следует ли приложению отображать значки при отображении контурного содержания в любой из областей содержимого режима обычного просмотра.

Свойство **SnapVerticalSplitter** указывает, должен ли вертикальный разделитель переходить в свернутое состояние, когда боковая область достаточно мала.

Свойство **PreferSingleView** указывает, предпочитает ли пользователь видеть одноблочную область во весь экран вместо стандартного обычного просмотра с тремя областями содержимого. Если включено, приложение может отобразить одну из областей содержимого на весь экран.

Свойства **VerticalBarState** и **HorizontalBarState** указывают состояние, в котором должна отображаться горизонтальная или вертикальная полоса разделителя. Горизонтальная полоса разделителя отделяет слайд от области содержимого под слайдом, вертикальная полоса разделителя отделяет слайд от боковой области содержимого. Возможные значения: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** и **SplitterBarStateType.Restored**.

Свойства **RestoredLeft** и **RestoredTop** определяют размеры верхней или боковой области слайда в обычном просмотре, когда для **VerticalBarState** и **HorizontalBarState** соответственно применяется значение **SplitterBarStateType.Restored**.

## **О восстановлении INormalViewProperties** 

Указывает размеры области слайда (ширина, когда является дочерним элементом RestoredTop, высота, когда является дочерним элементом RestoredLeft) в обычном просмотре, когда область имеет переменный восстановленный размер (ни свернутый, ни развернутый).

Свойство **DimensionSize** указывает размер области слайда (ширина, когда является дочерним элементом restoredTop, высота, когда является дочерним элементом restoredLeft).

Свойство **AutoAdjust** указывает, должна ли размер боковой области содержимого компенсировать новый размер при изменении размеров окна, содержащего просмотр в приложении.

Ниже приведен пример, показывающий, как получить доступ к свойствам **ViewProperties.NormalViewProperties** презентации.
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


## **Установить значение масштаба по умолчанию**

Aspose.Slides для .NET теперь поддерживает установку значения масштаба по умолчанию для презентации, так что при открытии презентации масштаб уже установлен. Это можно сделать, задав [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) презентации. Свойства просмотра слайда, а также [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/properties/notesviewproperties) можно задавать программно. В этой статье мы рассмотрим пример, как установить свойства просмотра презентации в Aspose.Slides.

Чтобы задать свойства просмотра, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)
1. Задайте свойства просмотра [Properties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) презентации
1. Сохраните презентацию в файл PPTX

В приведенном ниже примере мы задали значение масштаба для просмотра слайда, а также для просмотра заметок.
```c#
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Установка свойств просмотра презентации
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Значение масштаба в процентах для просмотра слайда
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Значение масштаба в процентах для просмотра заметок 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Могу ли я задать разные настройки просмотра для разных разделов презентации?**

[View settings](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) определяются на уровне презентации ([Normal View](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/slideviewproperties/)), а не для каждого раздела, поэтому один набор параметров применяется ко всему документу при его открытии.

**Могу ли я заранее определить разные состояния просмотра для разных пользователей?**

Нет. Настройки хранятся в файле и являются общими. Приложения‑просмотрщики могут учитывать предпочтения пользователя, но сам файл содержит один набор свойств просмотра.

**Могу ли я подготовить шаблон с заранее определёнными свойствами просмотра, чтобы новые презентации открывались одинаково?**

Да. Поскольку [view properties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) хранятся на уровне презентации, их можно встроить в шаблон и создавать новые документы из него с той же начальной конфигурацией просмотра.