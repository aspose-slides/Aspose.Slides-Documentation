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
- привязка вертикального разделителя
- единый режим
- состояние полосы
- размер
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

Обычное представление состоит из трёх областей содержимого: самого слайда, боковой области содержимого и нижней области содержимого. Свойства, относящиеся к позиционированию различных областей содержимого. Эта информация позволяет приложению сохранять состояние представления в файл, чтобы при повторном открытии представление находилось в том же состоянии, что и при последнем сохранении презентации.

Свойство [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/iviewproperties/properties/normalviewproperties) было добавлено для доступа к свойствам обычного представления презентации. 

Интерфейсы [INormalViewProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/inormalviewrestoredproperties) и их потомки, перечисление [SplitterBarStateType](https://reference.aspose.com/slides/ru/net/aspose.slides/splitterbarstatetype) были добавлены.

## **О INormalViewProperties**

Представляет свойства обычного представления.

Свойство **ShowOutlineIcons** указывает, следует ли приложению отображать значки при выводе содержания плана в любой из областей обычного режима представления.

Свойство **SnapVerticalSplitter** указывает, следует ли вертикальному разделителю «привязываться» к сведённому состоянию, когда боковая область достаточно мала.

Свойство **PreferSingleView** указывает, предпочитает ли пользователь видеть одну область содержимого во весь экран вместо стандартного обычного представления с тремя областями. Если включено, приложение может выбрать отображение одной из областей содержимого во всём окне.

Свойства **VerticalBarState** и **HorizontalBarState** определяют состояние, в котором должно отображаться горизонтальное или вертикальное разделительное ползунок. Горизонтальный ползунок отделяет слайд от области содержимого под слайдом, вертикальный ползунок отделяет слайд от боковой области содержимого. Возможные значения: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** и **SplitterBarStateType.Restored.**

Свойства **RestoredLeft** и **RestoredTop** определяют размер верхней или боковой области слайда обычного представления, когда для **VerticalBarState** и **HorizontalBarState** соответственно применено значение **SplitterBarStateType.Restored**.

## **О восстановлении INormalViewProperties**

Определяет размер области слайда (ширина, если дочерний элемент RestoredTop, высота, если дочерний элемент RestoredLeft) обычного представления, когда область имеет переменный восстановленный размер (ни сведённый, ни развернутый). 

Свойство **DimensionSize** задаёт размер области слайда (ширина, если дочерний элемент restoredTop, высота, если дочерний элемент restoredLeft).

Свойство **AutoAdjust** указывает, должна ли боковая область содержимого компенсировать новый размер при изменении размеров окна, содержащего представление в приложении.

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

## **Установить значение масштабирования по умолчанию**

Aspose.Slides for .NET теперь поддерживает установку значения масштабирования по умолчанию для презентации, так что при открытии презентации масштаб уже установлен. Это можно сделать, задав [ViewProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/viewproperties) презентации. Свойства представления слайда, а также [NotesViewProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/viewproperties/properties/notesviewproperties) могут быть заданы программно. В этой статье мы покажем пример, как задать свойства представления презентации в Aspose.Slides.

Чтобы задать свойства представления, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation)
2. Установите View [Properties](https://reference.aspose.com/slides/ru/net/aspose.slides/viewproperties) презентации
3. Запишите презентацию в файл PPTX

В приведённом ниже примере мы задали значение масштабирования для представления слайда, а также для заметок.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Установка свойств представления презентации
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Значение масштабирования в процентах для представления слайда
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Значение масштабирования в процентах для представления заметок 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **Установить интервал сетки**

Используйте [Presentation.ViewProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/viewproperties/) для доступа к настройкам представления на уровне всей презентации. Свойство [IViewProperties.GridSpacing](https://reference.aspose.com/slides/ru/net/aspose.slides/iviewproperties/gridspacing/) читает или изменяет интервал базовой сетки редактирования. Эта настройка применяется ко всей презентации, а не к отдельному слайду. Интервал сетки указывается в пунктах, где 72 пункта равны одному дюйму. Используйте положительное значение, как указано в документации API.

В следующем примере открывается существующий `demo.pptx`, выводится текущий интервал сетки, устанавливается интервал в четверть дюйма и сохраняется результат.

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

Сетка отличается от [drawing guides](/slides/ru/net/drawing-guides/). Интервал сетки задаёт регулярный промежуток, тогда как направляющие — это отдельно позиционированные горизонтальные или вертикальные линии выравнивания. Добавление, перемещение или удаление направляющих не меняет интервал сетки.

И сетка, и направляющие являются вспомогательными средствами редактирования. Они не отображаются как содержимое слайда в PDF, изображениях, SVG или демонстрации. Сохранение интервала сетки не гарантирует, что редактор его отобразит: видимость также зависит от настроек просмотрщика или редактора.

## **FAQ**

**Почему сетка не видна после повторного открытия презентации?**

Файл сохраняет интервал сетки, но редактор решает, отображать её или нет. Проверьте настройки видимости сетки в редакторе.

**Изменит ли удаление направляющих интервал сетки?**

Нет. Направляющие и интервал сетки — независимые настройки. Очистка направляющих не меняет сохранённый интервал сетки.

**Могу ли я задать разные настройки представления для разных разделов презентации?**

[Настройки представления](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/viewproperties/) задаются на уровне презентации ([Normal View](https://reference.aspose.com/slides/ru/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ru/net/aspose.slides/viewproperties/slideviewproperties/)), а не для каждого раздела, поэтому один набор параметров применяется ко всему документу при открытии.

**Можно ли заранее определить разные состояния представления для разных пользователей?**

Нет. Настройки хранятся в файле и являются общими. Приложения‑просмотрщики могут учитывать предпочтения пользователя, но сам файл содержит один набор свойств представления.

**Можно ли создать шаблон с предустановленными свойствами представления, чтобы новые презентации открывались одинаково?**

Да. Поскольку [свойства представления](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/viewproperties/) сохраняются на уровне презентации, их можно вложить в шаблон и создавать новые документы на его основе с тем же начальным конфигурированием представления.