---
title: Свойства представления в нормальном режиме
type: docs
url: /ru/python-net/presentation-view-properties/
keywords: "Просмотрщик PowerPoint, свойства просмотрщика, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Свойства просмотрщика презентаций PowerPoint на Python"
---

{{% alert color="primary" %}} 

Нормальное представление состоит из трех областей содержимого: слайда, боковой области содержимого и нижней области содержимого. Свойства, касающиеся позиционирования различных областей содержимого. Эта информация позволяет приложению сохранять состояние просмотра в файл, чтобы при повторном открытии представление находилось в том же состоянии, что и при последнем сохранении презентации.

Свойство [**IViewProperties.NormalViewProperties**](https://reference.aspose.com/slides/python-net/aspose.slides/iviewproperties/) было добавлено для доступа к свойствам нормального представления презентации. 

Добавлены интерфейсы [**INormalViewProperties**](https://reference.aspose.com/slides/python-net/aspose.slides/inormalviewproperties/) и [**INormalViewRestoredProperties**](https://reference.aspose.com/slides/python-net/aspose.slides/inormalviewrestoredproperties/), а также перечисление [**SplitterBarStateType**](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/).

{{% /alert %}} 



## **О INormalViewProperties** 

Представляет свойства нормального представления.

Свойство **ShowOutlineIcons** указывает, должно ли приложение показывать значки, если отображается контент слайда в какой-либо из областей содержимого в режиме нормального представления.

Свойство **SnapVerticalSplitter** указывает, должна ли вертикальная разделительная полоса зажаться в минимизированное состояние, когда боковая область достаточно мала.

Свойство **PreferSingleView** указывает, предпочитает ли пользователь видеть полный экран одного содержимого вместо стандартного нормального представления с тремя областями содержимого. Если включено, приложение может выбрать отображение одной из областей содержимого на всем окне.

Свойства **VerticalBarState** и **HorizontalBarState** указывают состояние, в котором должна быть показана горизонтальная или вертикальная разделительная полоса. Горизонтальная разделительная полоса отделяет слайд от области содержимого ниже слайда, вертикальная разделительная полоса отделяет слайд от боковой области содержимого. Возможные значения: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** и **SplitterBarStateType.Restored.**

Свойства **RestoredLeft** и **RestoredTop** указывают размеры верхней или боковой области слайда нормального представления, когда для **VerticalBarState** и **HorizontalBarState** применяется значение **SplitterBarStateType.Restored** соответственно.



## **О INormalViewRestoredProperties** 

Указывает размеры области слайда (ширина, когда она является дочерней для RestoredTop, высота, когда она является дочерней для RestoredLeft) нормального представления, когда область имеет переменные восстановленные размеры (не минимизированные и не максимизированные).

Свойство **DimensionSize** указывает размер области слайда (ширина, когда она является дочерней для RestoredTop, высота, когда она является дочерней для RestoredLeft).

Свойство **AutoAdjust** указывает, следует ли размер боковой области содержимого компенсировать новый размер при изменении размера окна, содержащего представление в приложении.

Пример, приведенный ниже, показывает, как вы можете получить доступ к свойствам **ViewProperties.NormalViewProperties** для презентации.

```py
import aspose.slides as slides

#Создать объект презентации, представляющий файл презентации
with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```




## **Установить значение масштабирования по умолчанию**
Aspose.Slides для Python через .NET теперь поддерживает установку значения масштабирования по умолчанию для презентации, чтобы когда презентация открывается, масштаб уже был установлен. Это можно сделать, установив [**view_properties**](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) презентации. Свойства слайдов, а также [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) могут быть установлены программно. В этой теме мы покажем на примере, как установить свойства просмотра презентации в Aspose.Slides.

Чтобы установить свойства просмотра, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Установите [Properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) просмотра презентации.
1. Сохраните презентацию в виде файла PPTX.

В примере ниже мы установили значение масштабирования для просмотра слайда, а также для просмотра заметок.

```py
import aspose.slides as slides

# Создать объект презентации, представляющий файл презентации
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Установить свойства просмотра презентации
    presentation.view_properties.slide_view_properties.scale = 100 # Значение масштабирования в процентах для просмотра слайдов
    presentation.view_properties.notes_view_properties.scale = 100 # Значение масштабирования в процентах для просмотра заметок 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Установить свойства просмотра**
Чтобы установить свойства просмотра, выполните следующие шаги:

1. Создайте экземпляр класса Presentation.
1. Установите свойства просмотра презентации.
1. Сохраните презентацию в виде файла PPTX.

В примере ниже мы установили значение масштабирования для просмотра слайда, а также для просмотра заметок.

```py
import aspose.slides as slides

# Создать объект презентации, представляющий файл презентации
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Установить свойства просмотра презентации
    presentation.view_properties.slide_view_properties.scale = 100 # Значение масштабирования в процентах для просмотра слайдов
    presentation.view_properties.notes_view_properties.scale = 100 # Значение масштабирования в процентах для просмотра заметок 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```