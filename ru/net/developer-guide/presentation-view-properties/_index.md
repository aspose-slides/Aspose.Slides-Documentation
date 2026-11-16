---
title: Получить и обновить свойства представления презентации в .NET
linktitle: Свойства представления
type: docs
weight: 80
url: /ru/net/presentation-view-properties/
keywords:
- свойства представления
- обычный вид
- содержание схемы
- значки схемы
- привязка вертикального разделителя
- одиночный вид
- состояние полосы
- размер измерения
- автонастройка
- масштаб по умолчанию
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Используйте Aspose.Slides для .NET, чтобы настроить макет обычного вида, масштаб слайда и заметок, интервал сетки и видимость комментариев в презентациях PowerPoint."
---
## **Введение**

В обычном виде PowerPoint слайд отображается между боковой панелью для эскизов или схемой и панелью заметок внизу. Aspose.Slides for .NET предоставляет сохранённые пользовательские настройки редактирования презентации через [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/). Эти настройки включают расположение панелей, уровни масштабирования, интервал сетки и отображение комментариев.

## **О INormalViewProperties**

Используйте [NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/normalviewproperties/) для доступа к интерфейсу [INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/). [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) управляет тем, появляются ли значки рядом с названиями слайдов в схеме. [SnapVerticalSplitter](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/snapverticalsplitter/) позволяет боковой панели переходить в свёрнутое состояние, когда пользователь уменьшает её. [PreferSingleView](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/prefersingleview/) указывает предпочтение отображать одну панель во всём окне.

[VerticalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/verticalbarstate/) контролирует разделитель между боковой панелью и слайдом. [HorizontalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/horizontalbarstate/) контролирует разделитель над панелью заметок. Оба принимают значение [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype/) `Minimized`, `Maximized` или `Restored`.

## **О восстановлении INormalViewProperties**

Когда разделитель восстанавливается, [RestoredLeft](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredleft/) предоставляет сохранённый размер боковой панели, а [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) — сохранённый размер верхней части слайда. Оба раскрывают [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/). Его свойство [DimensionSize](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/dimensionsize/) принимает процент от 0 до 100, а [AutoAdjust](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/autoadjust/) управляет тем, корректирует ли редактор размер при изменении размеров окна.

В этом примере обновляется существующая презентация. Восстанавливается горизонтальный разделитель, [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) устанавливается в 80% с включённой автоматической настройкой, и вертикальный разделитель разворачивается. Также включается [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) для режима схеми.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var normalView = presentation.ViewProperties.NormalViewProperties;
normalView.HorizontalBarState = SplitterBarStateType.Restored;
normalView.VerticalBarState = SplitterBarStateType.Maximized;
normalView.RestoredTop.AutoAdjust = true;
normalView.RestoredTop.DimensionSize = 80;
normalView.ShowOutlineIcons = true;

presentation.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
```

## **Установить значение масштаба по умолчанию**

[SlideViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/slideviewproperties/) и [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/notesviewproperties/) хранят независимые параметры масштабирования для редактора. Эти настройки не влияют на размеры слайда, воспроизведение слайд‑шоу или разрешение при экспорте изображений.

В этом примере открывается существующая презентация и включается [VariableScale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/variablescale/) чтобы подогнать слайд под окно редактирования. Для страницы заметок отключается автоматическое масштабирование и устанавливается [Scale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/scale/) в фиксированный масштаб 80%.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
viewProperties.SlideViewProperties.VariableScale = true;
viewProperties.NotesViewProperties.VariableScale = false;
viewProperties.NotesViewProperties.Scale = 80;

presentation.Save("zoom.pptx", SaveFormat.Pptx);
```

## **Установить интервал сетки**

[GridSpacing](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/gridspacing/) задаёт расстояние между линиями сетки редактирования во всей презентации. Принимает положительное значение в пунктах, где 72 пункта = один дюйм. В этом примере выводится текущий интервал в существующей презентации и сохраняется сетка с шагом четверти дюйма, задав интервал 18 пунктов.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current grid spacing: {viewProperties.GridSpacing} points");

viewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

Сетка повторяется с фиксированным интервалом. [Drawing guides](/slides/ru/net/drawing-guides/) отмечают отдельные горизонтальные или вертикальные позиции. Оба являются вспомогательными элементами редактирования и отображаются только в редакторах, которые их показывают. Слайд‑шоу и экспорт в PDF, изображения или SVG их не включают.

## **Показать или скрыть комментарии при открытии презентации**

[ShowComments](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/showcomments/) сохраняет предпочтение, которое совместимые редакторы используют при открытии презентации. Для существующей презентации с комментариями в этом примере выводится текущее значение и сохраняется копия с скрытыми комментариями. Также устанавливается [LastView](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/lastview/) в [ViewType.SlideView](https://reference.aspose.com/slides/net/aspose.slides/viewtype/) чтобы копия открылась в режиме просмотра слайда.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current comment visibility: {viewProperties.ShowComments}");

viewProperties.ShowComments = NullableBool.False;
viewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

Сокрытие комментариев сохраняет их текст, авторов, позиции, ответы и статусы. Чтобы изменить сами комментарии, см. [Presentation Comments](/slides/ru/net/presentation-comments/). Параметры экспорта управляют тем, появляются ли комментарии в PDF, HTML, изображениях, заметках или раздаточных материалах.

## **FAQ**

**Почему сетка скрыта при повторном открытии презентации?**  
Презентация сохраняет интервал сетки. Чтобы увидеть сетку, включите её отображение в редакторе.

**Удаление направляющих меняет интервал сетки?**  
Нет. Добавление, перемещение или удаление направляющей не изменяют интервал сетки.

**Можно ли задать разные настройки просмотра для различных разделов презентации?**  
Нет. [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) применяются ко всей презентации.

**Могу ли я сохранить разные настройки просмотра для разных пользователей?**  
Файл сохраняет один набор свойств просмотра для всех. Редактор может также применять локальные предпочтения пользователя.

**Можно ли сохранить настройки просмотра в шаблоне?**  
Да. Презентации, созданные из шаблона, наследуют сохранённые в нём настройки просмотра.