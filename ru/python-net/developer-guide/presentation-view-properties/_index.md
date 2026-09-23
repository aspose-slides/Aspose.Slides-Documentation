---
title: Получить и обновить свойства представления презентации в Python
linktitle: Свойства представления
type: docs
weight: 80
url: /ru/python-net/presentation-view-properties/
keywords:
- свойства представления
- нормальный режим
- содержимое плана
- значки плана
- прилипание вертикального разделителя
- одиночный режим
- состояние полосы
- размер измерения
- автоматическая настройка
- масштаб по умолчанию
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Откройте для себя свойства представления Aspose.Slides for Python via .NET, чтобы настраивать форматы слайдов PPT, PPTX и ODP — изменять макеты, уровни масштабирования и параметры отображения."
---
## **Введение**

Нормальный режим представления состоит из трёх областей содержимого: самого слайда, боковой области содержимого и нижней области содержимого. Свойства, относящиеся к позиционированию различных областей, позволяют приложению сохранять состояние представления в файл, так что при повторном открытии представление будет в том же состоянии, в котором презентация была сохранена в последний раз.

Свойство [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/viewproperties/normal_view_properties/) было добавлено для предоставления доступа к свойствам нормального представления презентации.  

Были добавлены классы [NormalViewProperties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/normalviewrestoredproperties/), их наследники и перечисление [SplitterBarStateType](https://reference.aspose.com/slides/ru/python-net/aspose.slides/splitterbarstatetype/) .

## **О INormalViewProperties**

Представляет свойства нормального представления.

Свойство **ShowOutlineIcons** указывает, должно ли приложение отображать значки при отображении содержимого плана в любой из областей режима нормального представления.

Свойство **SnapVerticalSplitter** определяет, должен ли вертикальный разделитель переходить в минимизированное состояние, когда боковая область достаточно мала.

Свойство **PreferSingleView** указывает, предпочитает ли пользователь видеть одну область содержимого во весь экран вместо стандартного нормального представления с тремя областями. Если включено, приложение может отобразить одну из областей содержимого во всем окне.

Свойства **VerticalBarState** и **HorizontalBarState** задают состояние, в котором должна отображаться горизонтальная или вертикальная полоса разделителя. Горизонтальная полоса разделяет слайд от области содержимого под слайдом, вертикальная — слайд от боковой области. Возможные значения: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** и **SplitterBarStateType.Restored**.

Свойства **RestoredLeft** и **RestoredTop** задают размеры верхней или боковой области слайда в нормальном представлении, когда для **VerticalBarState** и **HorizontalBarState** применено значение **SplitterBarStateType.Restored**.

## **О восстановлении INormalViewProperties**

Определяет размеры области слайда (ширина, когда является дочерним элементом RestoredTop, высота, когда является дочерним элементом RestoredLeft) в нормальном представлении, когда область имеет переменный восстановленный размер (ни минимизированный, ни максимизированный).

Свойство **DimensionSize** задает размер области слайда (ширина, когда дочерний элемент restoredTop, высота, когда дочерний элемент restoredLeft).

Свойство **AutoAdjust** определяет, должна ли боковая область содержимого компенсировать новый размер при изменении размера окна, содержащего представление в приложении.

Ниже приведён пример, показывающий, как получить доступ к свойствам **ViewProperties.NormalViewProperties** для презентации.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Восстановить свойства представления презентации
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить значение масштаба по умолчанию**

Aspose.Slides for Python via .NET теперь поддерживает установку значения масштаба по умолчанию для презентации, так что при открытии презентации масштаб уже установлен. Это можно сделать, задав [view_properties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/view_properties/) презентации. Свойства просмотра слайда, а также [notes_view_properties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/viewproperties/notes_view_properties/) могут устанавливаться программно. В этой статье мы посмотрим на пример, как установить свойства представления презентации в Aspose.Slides.

Чтобы установить свойства представления, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/)  
1. Задайте [view properties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/viewproperties/) презентации  
1. Сохраните презентацию как файл PPTX  

В приведённом ниже примере мы задали значение масштаба как для просмотра слайда, так и для просмотра заметок.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # Установка свойств представления презентации
    presentation.view_properties.slide_view_properties.scale = 100 # Значение масштабирования в процентах для просмотра слайда
    presentation.view_properties.notes_view_properties.scale = 100 # Значение масштабирования в процентах для просмотра заметок

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить интервал сетки**

Используйте [Presentation.view_properties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/view_properties/) для доступа к глобальным настройкам представления презентации. Свойство [ViewProperties.grid_spacing](https://reference.aspose.com/slides/ru/python-net/aspose.slides/viewproperties/grid_spacing/) читает или изменяет интервал базовой сетки редактирования. Эта настройка применяется ко всей презентации, а не к отдельному слайду. Интервал сетки задаётся в пунктах, где 72 пункта равны одному дюйму. Используйте положительное значение, как требуется в документации API.

В следующем примере открывается существующий `demo.pptx`, выводится текущий интервал сетки, устанавливается интервал в четверть дюйма и сохраняется результат.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

Сетка отличается от [drawing guides](/slides/ru/python-net/drawing-guides/). Интервал сетки определяет регулярный шаг, тогда как направляющие – это отдельные горизонтальные или вертикальные линии выравнивания. Добавление, перемещение или удаление направляющих не изменяют интервал сетки.

И сетка, и направляющие являются вспомогательными элементами редактирования. Они не отображаются как содержимое слайда в PDF, изображениях, SVG или в слайд‑шоу. Сохранение интервала сетки не гарантирует, что редактор отобразит сетку: её видимость также зависит от настроек просмотрщика или редактора.

## **Показать или скрыть комментарии при открытии презентации**

Используйте [Presentation.view_properties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/view_properties/) для доступа к глобальным настройкам представления презентации. Читайте или изменяйте [ViewProperties.show_comments](https://reference.aspose.com/slides/ru/python-net/aspose.slides/viewproperties/show_comments/) чтобы сохранить предпочтение, показывать ли комментарии при открытии презентации в PowerPoint или другом совместимом редакторе.

Эта настройка управляет только сохранённым предпочтением представления. Она не добавляет, не удаляет, не редактирует и не решает комментарии. Скрытие комментариев сохраняет их содержимое, авторов, позиции, ответы и статусы. См. [Presentation Comments](/slides/ru/python-net/presentation-comments/) для операций, изменяющих сами комментарии.

В следующем примере требуется существующий `comments.pptx` с комментариями. Он выводит текущую настройку видимости, запрашивает скрыть комментарии и сохраняет новый PPTX без удаления комментариев. Также он задаёт [ViewProperties.last_view](https://reference.aspose.com/slides/ru/python-net/aspose.slides/viewproperties/last_view/) равным [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/ru/python-net/aspose.slides/viewtype/) чтобы настроить начальное представление редактирования вместе с видимостью комментариев.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    show_comments = presentation.view_properties.show_comments
    print(f"Current comment visibility: {show_comments}")

    presentation.view_properties.show_comments = slides.NullableBool.FALSE
    presentation.view_properties.last_view = slides.ViewType.SLIDE_VIEW
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

Эта настройка не определяет, будут ли комментарии включены в экспорты PDF, HTML, изображений, заметок или раздаточных материалов. Настройте соответствующие параметры экспорта отдельно.

## **FAQ**

**Почему сетка не видна после повторного открытия презентации?**

Файл сохраняет интервал сетки, но редактор управляет тем, отображается ли сетка. Проверьте настройки видимости сетки в редакторе.

**Изменит ли удаление направляющих интервал сетки?**

Нет. Направляющие и интервал сетки — независимые настройки. Удаление направляющих не меняет сохранённый интервал сетки.

**Могу ли я задать разные настройки представления для разных разделов презентации?**

Настройки представления ([View settings](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/view_properties/)) определяются на уровне презентации ([Normal View](https://reference.aspose.com/slides/ru/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/ru/python-net/aspose.slides/viewproperties/slide_view_properties/)), а не для каждого раздела, поэтому один набор параметров применяется ко всему документу при открытии.

**Могу ли я предопределить разные состояния представления для разных пользователей?**

Нет. Настройки хранятся в файле и общие. Приложения‑просмотрщики могут учитывать предпочтения пользователя, но сам файл содержит один набор свойств представления.

**Могу ли я подготовить шаблон с предустановленными свойствами представления, чтобы новые презентации открывались одинаково?**

Да. Поскольку [view properties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/view_properties/) хранятся на уровне презентации, их можно встроить в шаблон и создавать из него новые документы с одинаковой начальной конфигурацией представления.