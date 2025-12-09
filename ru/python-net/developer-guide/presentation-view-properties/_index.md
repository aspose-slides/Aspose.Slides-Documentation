---
title: Получить и обновить свойства представления презентации в Python
linktitle: Свойства представления
type: docs
weight: 80
url: /ru/python-net/presentation-view-properties/
keywords:
- свойства представления
- обычный просмотр
- содержание контура
- иконки контура
- привязать вертикальный разделитель
- одиночный просмотр
- состояние полосы
- размер измерения
- автоматическая настройка
- масштаб по умолчанию
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Ознакомьтесь со свойствами представления Aspose.Slides для Python via .NET, позволяющими настраивать форматы слайдов PPT, PPTX и ODP — регулировать макеты, уровни масштабирования и параметры отображения."
---

{{% alert color="primary" %}} 

Обычный просмотр состоит из трех областей содержимого: самого слайда, боковой области содержимого и нижней области содержимого. Свойства, касающиеся позиционирования различных областей содержимого. Эта информация позволяет приложению сохранять состояние просмотра в файл, чтобы при повторном открытии просмотр находился в том же состоянии, в котором презентация была сохранена в последний раз.

Свойство [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/iviewproperties/) было добавлено для предоставления доступа к свойствам обычного просмотра презентации. 

Интерфейсы [INormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/inormalviewrestoredproperties/) и их наследники, а также перечисление [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) были добавлены.

{{% /alert %}} 

## **О INormalViewProperties** 

Представляет свойства обычного просмотра.

Свойство **ShowOutlineIcons** указывает, должно ли приложение отображать значки при выводе контента структуры в любой из областей содержимого режима обычного просмотра.

Свойство **SnapVerticalSplitter** указывает, должен ли вертикальный разделитель переходить в минимизированное состояние, когда боковая область достаточно мала.

Свойство **PreferSingleView** указывает, предпочитает ли пользователь видеть одну область содержимого на весь экран вместо стандартного обычного просмотра с тремя областями содержимого. При включении приложение может выбрать отображение одной из областей содержимого во всем окне.

Свойства **VerticalBarState** и **HorizontalBarState** указывают состояние, в котором должна отображаться горизонтальная или вертикальная полоса разделителя. Горизонтальная полоса разделителя отделяет слайд от области содержимого под слайдом, вертикальная полоса разделителя отделяет слайд от боковой области содержимого. Возможные значения: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** и **SplitterBarStateType.Restored**.

Свойства **RestoredLeft** и **RestoredTop** задают размеры верхней или боковой области слайда обычного просмотра, когда для **VerticalBarState** и **HorizontalBarState** соответственно применено значение **SplitterBarStateType.Restored**.

## **О восстановлении INormalViewProperties**

Указывает размеры области слайда (ширина, когда это дочерний элемент RestoredTop, высота, когда это дочерний элемент RestoredLeft) обычного просмотра, когда область имеет переменный восстановленный размер (ни минимизированный, ни максимизированный). 

Свойство **DimensionSize** задает размер области слайда (ширина, когда это дочерний элемент restoredTop, высота, когда это дочерний элемент restoredLeft).

Свойство **AutoAdjust** указывает, должна ли боковая область содержимого компенсировать новый размер при изменении размеров окна, содержащего просмотр в приложении.

Пример ниже показывает, как получить доступ к свойствам **ViewProperties.NormalViewProperties** презентации.
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Восстановить свойства представления презентации
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```


## **Установить значение масштабирования по умолчанию**

Aspose.Slides for Python via .NET теперь поддерживает установку значения масштабирования по умолчанию для презентации, так что при открытии презентации масштаб уже установлен. Это можно сделать, задав [view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) презентации. Свойства просмотра слайдов, а также [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) можно установить программно. В этой теме мы посмотрим на примере, как задать свойства просмотра презентации в Aspose.Slides.

Чтобы задать свойства просмотра, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Установите View [Properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) презентации.
3. Запишите презентацию в файл PPTX.

В примере ниже мы задали значение масштабирования для просмотра слайда, а также для просмотра заметок.
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Установка свойств представления презентации
    presentation.view_properties.slide_view_properties.scale = 100 # Значение масштабирования в процентах для просмотра слайда
    presentation.view_properties.notes_view_properties.scale = 100 # Значение масштабирования в процентах для просмотра заметок

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Часто задаваемые вопросы**

**Могу ли я задать разные настройки просмотра для разных секций презентации?**

[Настройки просмотра](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) определяются на уровне презентации ([Normal View](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/)), а не для каждой секции, поэтому единственный набор параметров применяется ко всему документу при его открытии.

**Могу ли я заранее определить разные состояния просмотра для разных пользователей?**

Нет. Настройки сохраняются в файле и являются общими. Приложения‑просмотрщики могут учитывать предпочтения пользователя, но сам файл содержит один набор свойств просмотра.

**Могу ли я подготовить шаблон с предустановленными свойствами просмотра, чтобы новые презентации открывались одинаково?**

Да. Поскольку [свойства просмотра](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) хранятся на уровне презентации, их можно встроить в шаблон и создавать из него новые документы с той же начальной конфигурацией просмотра.