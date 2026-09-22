---
title: Получение и обновление свойств просмотра презентации в Python
linktitle: Свойства просмотра
type: docs
weight: 80
url: /ru/python-net/presentation-view-properties/
keywords:
- свойства просмотра
- обычный просмотр
- содержание плана
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
description: "Ознакомьтесь со свойствами просмотра Aspose.Slides для Python via .NET, чтобы настраивать форматы слайдов PPT, PPTX и ODP — изменять макеты, уровни масштабирования и параметры отображения."
---
## **Введение**

Обычный режим просмотра состоит из трех областей содержимого: самого слайда, боковой области содержимого и нижней области содержимого. Свойства, относящиеся к расположению различных областей содержимого. Эта информация позволяет приложению сохранять состояние просмотра в файл, чтобы при повторном открытии просмотр находился в том же состоянии, что и при последнем сохранении презентации.

Свойство [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/viewproperties/normal_view_properties/) было добавлено для предоставления доступа к свойствам обычного режима просмотра презентации.  

Классы [NormalViewProperties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/normalviewrestoredproperties/), а также их наследники, перечисление [SplitterBarStateType](https://reference.aspose.com/slides/ru/python-net/aspose.slides/splitterbarstatetype/) были добавлены.

## **Об INormalViewProperties**

Представляет свойства обычного режима просмотра.

Свойство **ShowOutlineIcons** указывает, следует ли приложению показывать значки при отображении контента плана в любой из областей содержимого режима обычного просмотра.

Свойство **SnapVerticalSplitter** определяет, должен ли вертикальный разделитель переходить в минимизированное состояние, когда боковая область достаточно мала.

Свойство **PreferSingleView** указывает, предпочитает ли пользователь видеть полноэкранную область с единственным содержимым вместо стандартного обычного режима просмотра с тремя областями содержимого. Если включено, приложение может выбрать отображать одну из областей содержимого на всём окне.

Свойства **VerticalBarState** и **HorizontalBarState** задают состояние, в котором должна отображаться горизонтальная или вертикальная полоса‑разделитель. Горизонтальная полоса разделяет слайд и область содержимого под слайдом, вертикальная полоса разделяет слайд и боковую область содержимого. Возможные значения: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** и **SplitterBarStateType.Restored**.

Свойства **RestoredLeft** и **RestoredTop** определяют размер верхней или боковой области слайда в обычном режиме просмотра, когда для **VerticalBarState** и **HorizontalBarState** соответственно установлено значение **SplitterBarStateType.Restored**.

## **О восстановлении INormalViewProperties**

Определяет размер области слайда (ширина, когда является дочерним элементом RestoredTop, высота, когда является дочерним элементом RestoredLeft) в обычном режиме просмотра, когда область имеет переменный восстановленный размер (не минимизирована и не максимизирована).

Свойство **DimensionSize** задаёт размер области слайда (ширина, когда является дочерним элементом restoredTop, высота, когда является дочерним элементом restoredLeft).

Свойство **AutoAdjust** указывает, должна ли размер боковой области содержимого компенсировать новый размер при изменении размеров окна, содержащего просмотр в приложении.

Ниже приведён пример, показывающий, как получить доступ к свойствам **ViewProperties.NormalViewProperties** презентации.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Восстановить свойства просмотра презентации
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить значение масштабирования по умолчанию**

Aspose.Slides for Python via .NET теперь поддерживает установку значения масштабирования по умолчанию для презентации, так что при открытии презентации масштаб уже установлен. Это можно сделать, задав [view_properties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/view_properties/) презентации. Свойства просмотра слайда, а также [notes_view_properties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/viewproperties/notes_view_properties/) могут быть заданы программно. В этой теме мы рассмотрим на примере, как задать свойства просмотра презентации в Aspose.Slides.

Чтобы задать свойства просмотра, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
2. Задайте [view properties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/viewproperties/) презентации.
3. Сохраните презентацию как файл PPTX.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # Установка свойств просмотра презентации
    presentation.view_properties.slide_view_properties.scale = 100 # Значение масштабирования в процентах для просмотра слайда
    presentation.view_properties.notes_view_properties.scale = 100 # Значение масштабирования в процентах для просмотра заметок 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить интервал сетки**

Используйте [Presentation.view_properties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/view_properties/) для доступа к настройкам просмотра на уровне всей презентации. Свойство [ViewProperties.grid_spacing](https://reference.aspose.com/slides/ru/python-net/aspose.slides/viewproperties/grid_spacing/) читает или изменяет интервал базовой сетки редактирования. Эта настройка применяется ко всей презентации, а не к отдельному слайду. Интервал сетки указывается в пунктах, где 72 пункта равны одному дюйму. Используйте положительное значение, как требует документация API.

В следующем примере открывается существующий `demo.pptx`, выводится текущий интервал сетки, устанавливается интервал в четверть дюйма и сохраняется результат.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

Сетка отличается от [drawing guides](/slides/ru/python-net/drawing-guides/). Интервал сетки задаёт равномерный интервал, тогда как направляющие — это отдельные горизонтальные или вертикальные линии выравнивания. Добавление, перемещение или удаление направляющих не изменяют интервал сетки.

И сетка, и направляющие служат вспомогательными средствами редактирования. Они не отображаются как содержимое слайда в PDF, изображениях, SVG или при показе слайд‑шоу. Сохранение интервала сетки не гарантирует, что редактор отобразит её: её видимость также зависит от настроек просмотрщика или редактора.

## **FAQ**

**Почему сетка не видна после повторного открытия презентации?**  
Файл сохраняет интервал сетки, но редактор управляет тем, отображается ли сетка. Проверьте настройки видимости сетки в редакторе.

**Изменяется ли интервал сетки при удалении направляющих?**  
Нет. Направляющие и интервал сетки — независимые параметры. Очистка направляющих не меняет сохранённый интервал сетки.

**Могу ли я задать разные настройки просмотра для разных разделов презентации?**  
[View settings](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/view_properties/) определяются на уровне презентации ([Normal View](https://reference.aspose.com/slides/ru/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/ru/python-net/aspose.slides/viewproperties/slide_view_properties/)), а не для каждого раздела, поэтому один набор параметров применяется ко всему документу при его открытии.

**Можно ли заранее задать разные состояния просмотра для разных пользователей?**  
Нет. Настройки хранятся в файле и общие. Приложения‑просмотрщики могут учитывать пользовательские предпочтения, но сам файл содержит один набор свойств просмотра.

**Можно ли подготовить шаблон с предустановленными свойствами просмотра, чтобы новые презентации открывались одинаково?**  
Да. Поскольку [view properties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/view_properties/) хранятся на уровне презентации, их можно встроить в шаблон и создавать новые документы с той же исходной конфигурацией просмотра.