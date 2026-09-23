---
title: Получить и обновить свойства представления презентации в .NET
linktitle: Свойства представления
type: docs
weight: 80
url: /ru/net/presentation-view-properties/
keywords: 
- свойства представления
- обычный режим
- содержание плана
- значки плана
- фиксировать вертикальный разделитель
- одиночный режим
- состояние панели
- размер измерения
- автоматическая настройка
- масштаб по умолчанию
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Откройте свойства представления Aspose.Slides для .NET, чтобы настраивать форматы слайдов PPT, PPTX и ODP — корректировать макеты, уровни масштабирования и параметры отображения."
---
## **Введение**

Обычный режим просмотра состоит из трёх областей содержимого: самого слайда, боковой области содержимого и нижней области содержимого. Свойства, относящиеся к расположению различных областей содержимого. Эта информация позволяет приложению сохранять состояние представления в файл, чтобы при повторном открытии представление было в том же состоянии, в котором презентация была сохранена в последний раз.

Свойство [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/iviewproperties/properties/normalviewproperties) было добавлено для доступа к свойствам обычного режима просмотра презентации.  

Были добавлены интерфейсы [INormalViewProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/inormalviewrestoredproperties), их наследники и перечисление [SplitterBarStateType](https://reference.aspose.com/slides/ru/net/aspose.slides/splitterbarstatetype).

## **Об INormalViewProperties**

Представляет свойства обычного режима просмотра.

Свойство **ShowOutlineIcons** указывает, должен ли приложение отображать значки при отображении содержания плана в любой из областей обычного режима просмотра.

Свойство **SnapVerticalSplitter** указывает, должен ли вертикальный разделитель фиксироваться в свернутом состоянии, когда боковая область достаточно мала.

Свойство **PreferSingleView** указывает, предпочитает ли пользователь видеть одну область содержимого на весь экран вместо стандартного обычного режима с тремя областями. При включённом значении приложение может отобразить одну из областей содержимого во всём окне.

Свойства **VerticalBarState** и **HorizontalBarState** определяют состояние, в котором должна отображаться горизонтальная или вертикальная полоса разделителя. Горизонтальная полоса разделителя отделяет слайд от области содержимого под слайдом, вертикальная полоса разделителя отделяет слайд от боковой области. Возможные значения: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** и **SplitterBarStateType.Restored**.

Свойства **RestoredLeft** и **RestoredTop** задают размеры верхней или боковой области слайда в обычном режиме, когда для **VerticalBarState** и **HorizontalBarState** соответственно применяется значение **SplitterBarStateType.Restored**.

## **О восстановлении INormalViewProperties**

Определяет размеры области слайда (ширина, когда она является дочерним элементом RestoredTop, высота, когда она является дочерним элементом RestoredLeft) обычного режима, когда область имеет переменный восстановленный размер (не свернутый и не развернутый).  

Свойство **DimensionSize** задает размер области слайда (ширина, когда это дочерний элемент restoredTop, высота, когда это дочерний элемент restoredLeft).  

Свойство **AutoAdjust** указывает, должна ли область бокового содержимого корректировать свой размер при изменении размеров окна, содержащего представление в приложении.  

Ниже приведён пример, показывающий, как получить доступ к свойствам **ViewProperties.NormalViewProperties** презентации.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // Восстановить свойства представления презентации
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **Установить значение масштаба по умолчанию**

Aspose.Slides for .NET теперь поддерживает установку значения масштаба по умолчанию для презентации, так что при открытии презентации масштаб уже установлен. Это можно сделать, задав [ViewProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/viewproperties) презентации. Свойства представления слайда, а также [NotesViewProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/viewproperties/properties/notesviewproperties) могут устанавливаться программно. В этой статье мы рассмотрим пример, как задать свойства представления презентации в Aspose.Slides.

Чтобы задать свойства представления, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation)
1. Установите свойства представления (ViewProperties) презентации
1. Сохраните презентацию в файл PPTX

В приведённом ниже примере мы задали значение масштаба для представления слайда и представления заметок.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Установка свойств представления презентации
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Значение масштаба в процентах для просмотра слайда
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Значение масштаба в процентах для просмотра заметок 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **Установить интервал сетки**

Используйте [Presentation.ViewProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/viewproperties/) для доступа к настройкам представления для всей презентации. Свойство [IViewProperties.GridSpacing](https://reference.aspose.com/slides/ru/net/aspose.slides/iviewproperties/gridspacing/) считывает или изменяет интервал базовой сетки редактирования. Эта настройка применяется ко всей презентации, а не к отдельному слайду. Интервал сетки указывается в пунктах, где 72 пункта соответствуют одному дюйму. Используйте положительное значение, как указано в документации API.

Следующий пример открывает существующий `demo.pptx`, выводит текущий интервал сетки, задаёт интервал в четверть дюйма и сохраняет результат.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");
var gridSpacing = presentation.ViewProperties.GridSpacing;
Console.WriteLine($"Current grid spacing: {gridSpacing} points");

presentation.ViewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

Сетка отличается от [drawing guides](/slides/ru/net/drawing-guides/). Интервал сетки задаёт регулярный шаг, тогда как руководящие линии — это индивидуально расположенные горизонтальные или вертикальные линии выравнивания. Добавление, перемещение или удаление руководящих линий не меняет интервал сетки.

И сетка, и руководящие линии являются вспомогательными средствами редактирования. Они не отображаются как содержимое слайда в PDF, изображениях, SVG или при показе слайдов. Сохранение интервала сетки не гарантирует, что редактор отобразит сетку: её видимость также зависит от настроек просмотрщика или редактора.

## **Показать или скрыть комментарии при открытии презентации**

Используйте [Presentation.ViewProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/viewproperties/) для доступа к настройкам представления для всей презентации. Считайте или измените [IViewProperties.ShowComments](https://reference.aspose.com/slides/ru/net/aspose.slides/iviewproperties/showcomments/), чтобы сохранить предпочтение отображать комментарии при открытии презентации в PowerPoint или другом совместимом редакторе.

Эта настройка управляет лишь сохранённым предпочтением представления. Она не добавляет, не удаляет, не редактирует и не решает комментарии. Скрытие комментариев сохраняет их содержание, авторов, позиции, ответы и статусы. См. [Presentation Comments](/slides/ru/net/presentation-comments/) для операций, изменяющих сами комментарии.

В следующем примере требуется существующий `comments.pptx` с комментариями. Он выводит текущее значение видимости, задаёт скрытие комментариев и сохраняет новый PPTX без удаления комментариев. Также он устанавливает [IViewProperties.LastView](https://reference.aspose.com/slides/ru/net/aspose.slides/iviewproperties/lastview/) в [ViewType.SlideView](https://reference.aspose.com/slides/ru/net/aspose.slides/viewtype/), чтобы настроить начальное представление редактирования вместе с видимостью комментариев.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");
var showComments = presentation.ViewProperties.ShowComments;
Console.WriteLine($"Current comment visibility: {showComments}");

presentation.ViewProperties.ShowComments = NullableBool.False;
presentation.ViewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

Эта настройка не определяет, будут ли комментарии включены в экспорте в PDF, HTML, изображение, заметки или раздаточные материалы. Настройте соответствующие параметры экспорта отдельно.

## **Часто задаваемые вопросы**

**Почему сетка не видна после повторного открытия презентации?**

Файл сохраняет интервал сетки, но отображение сетки контролирует редактор. Проверьте настройки видимости сетки в редакторе.

**Удаление руководящих линий меняет интервал сетки?**

Нет. Руководящие линии и интервал сетки — независимые настройки. Очистка линий не меняет сохранённый интервал сетки.

**Можно ли задать разные настройки представления для разных разделов презентации?**

Настройки представления ([View settings](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/viewproperties/)) определяются на уровне презентации ([Normal View](https://reference.aspose.com/slides/ru/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ru/net/aspose.slides/viewproperties/slideviewproperties/)), а не для каждого раздела, поэтому при открытии документа применяется один набор параметров для всего документа.

**Можно ли предварительно задать разные состояния представления для разных пользователей?**

Нет. Настройки сохраняются в файле и являются общими. Приложения‑просмотрщики могут учитывать предпочтения пользователей, но сам файл содержит один набор свойств представления.

**Можно ли подготовить шаблон с предопределёнными свойствами представления, чтобы новые презентации открывались одинаково?**

Да. Поскольку [view properties](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/viewproperties/) хранятся на уровне презентации, их можно встроить в шаблон и создавать из него новые документы с той же начальной конфигурацией представления.