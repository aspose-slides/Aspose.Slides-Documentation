---
title: Получить и обновить свойства просмотра презентации в Python
linktitle: Свойства просмотра
type: docs
weight: 80
url: /ru/python-net/presentation-view-properties/
keywords:
- свойства просмотра
- нормальный режим
- контент плана
- значки плана
- привязка вертикального разделителя
- одиночный просмотр
- состояние полосы
- размер измерения
- автоматическая настройка
- масштаб по умолчанию
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Ознакомьтесь со свойствами просмотра Aspose.Slides для Python via .NET, позволяющими настраивать форматы слайдов PPT, PPTX и ODP — изменять макеты, уровни масштабирования и параметры отображения."
---

{{% alert color="primary" %}} 

Нормальный режим просмотра состоит из трёх областей содержимого: самого слайда, боковой области содержимого и нижней области содержимого. Свойства, относящиеся к расположению различных областей содержимого. Эта информация позволяет приложению сохранять состояние представления в файл, так что при повторном открытии представление будет в том же состоянии, в котором презентация была сохранена в последний раз.

Свойство [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/) было добавлено для доступа к свойствам нормального режима просмотра презентации.  

Классы [NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/) и их наследники, а также перечисление [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) были добавлены.

{{% /alert %}} 

## **О INormalViewProperties** 

Представляет свойства нормального режима просмотра.

Свойство **ShowOutlineIcons** указывает, следует ли приложению показывать значки при отображении контента плана в любой из областей содержимого режима нормального просмотра.

Свойство **SnapVerticalSplitter** указывает, должен ли вертикальный разделитель переходить в минимизированное состояние, когда боковая область достаточно мала.

Свойство **PreferSingleView** указывает, предпочитает ли пользователь видеть полнопанельную одиночную область содержимого вместо стандартного нормального режима с тремя областями. При включении приложение может выбрать отображение одной из областей содержимого во всём окне.

Свойства **VerticalBarState** и **HorizontalBarState** определяют состояние, в котором должен отображаться соответствующий разделитель. Горизонтальный разделитель отделяет слайд от области содержимого под слайдом, вертикальный – слайд от боковой области содержимого. Возможные значения: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** и **SplitterBarStateType.Restored**.

Свойства **RestoredLeft** и **RestoredTop** задают размеры верхней или боковой области слайда в нормальном режиме, когда для **VerticalBarState** и **HorizontalBarState** соответственно применяется значение **SplitterBarStateType.Restored**.

## **О восстановлении INormalViewProperties**

Указывает размер области слайда (ширина, если это дочерний элемент RestoredTop; высота, если это дочерний элемент RestoredLeft) в нормальном режиме, когда область имеет переменный восстановленный размер (не минимизирована и не развернута).

Свойство **DimensionSize** задаёт размер области слайда (ширина, если это дочерний элемент restoredTop; высота, если это дочерний элемент restoredLeft).

Свойство **AutoAdjust** указывает, должна ли боковая область содержимого компенсировать новый размер при изменении размеров окна, содержащего представление в приложении.

Ниже приведён пример, показывающий, как получить доступ к свойствам **ViewProperties.NormalViewProperties** презентации.
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Восстановить свойства просмотра презентации
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```


## **Установка значения масштаба по умолчанию**

Aspose.Slides for Python via .NET теперь поддерживает установку значения масштаба по умолчанию для презентации, так что при открытии презентации масштаб уже установлен. Это можно сделать, задав [view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) презентации. Свойства просмотра слайда, а также [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/notes_view_properties/) можно задать программно. В этой теме мы на примере покажем, как установить свойства просмотра презентации в Aspose.Slides.

Для установки свойств просмотра выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Задайте [view properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) презентации.
1. Сохраните презентацию в файл PPTX.

В приведённом ниже примере мы задали значение масштаба для просмотра слайда, а также для просмотра заметок.
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Установка свойств просмотра презентации
    presentation.view_properties.slide_view_properties.scale = 100 # Значение масштабирования в процентах для просмотра слайда
    presentation.view_properties.notes_view_properties.scale = 100 # Значение масштабирования в процентах для просмотра заметок 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Можно ли задать разные настройки просмотра для разных секций презентации?**

[View settings](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) определяются на уровне презентации ([Normal View](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/)), а не для каждой секции, поэтому один набор параметров применяется к всему документу при открытии.

**Можно ли заранее определить разные состояния просмотра для разных пользователей?**

Нет. Настройки хранятся в файле и являются общими. Приложения‑просмотрщики могут учитывать предпочтения пользователя, но сам файл содержит один набор свойств просмотра.

**Можно ли подготовить шаблон с предустановленными свойствами просмотра, чтобы новые презентации открывались одинаково?**

Да. Поскольку [view properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) сохраняются на уровне презентации, их можно встроить в шаблон и создавать из него новые документы с той же начальной конфигурацией просмотра.