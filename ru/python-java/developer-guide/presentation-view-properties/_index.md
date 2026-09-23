---
title: Получение и обновление свойств представления презентации в Python через Java
linktitle: Свойства представления
type: docs
weight: 80
url: /ru/python-java/presentation-view-properties/
keywords:
- свойства представления
- обычный вид
- контурное содержимое
- контурные значки
- привязка вертикального разделителя
- одиночный вид
- состояние полосы
- размер измерения
- автоматическая настройка
- масштаб по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Узнайте о свойствах представления Aspose.Slides для Python через Java, позволяющих настраивать слайды PPT, PPTX и ODP — изменять макеты, уровни масштабирования и настройки отображения."
---
## **Введение**

Обычный вид состоит из трёх областей содержимого: самого слайда, боковой области содержимого и нижней области содержимого. Свойства обычного вида описывают расположение этих областей. Эта информация позволяет приложению сохранять состояние представления в файл, так что при повторном открытии вид будет находиться в том же состоянии, в котором презентация была сохранена в последний раз.

Метод [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/#getNormalViewProperties) был добавлен для предоставления доступа к свойствам обычного вида презентации.

Классы [NormalViewProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/) и [NormalViewRestoredProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewrestoredproperties/) и перечисление [SplitterBarStateType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/splitterbarstatetype/) были добавлены.

## **О NormalViewProperties**

Представляет свойства обычного вида.

Методы [getShowOutlineIcons](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) и [setShowOutlineIcons](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) указывают, следует ли приложению показывать значки при отображении контурного содержимого в любой из областей обычного режима просмотра.

Методы [getSnapVerticalSplitter](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) и [setSnapVerticalSplitter](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) задают, должен ли вертикальный разделитель переходить в минимизированное состояние, когда боковая область достаточно мала.

Методы [getPreferSingleView](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) и [setPreferSingleView](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) определяют, предпочитает ли пользователь видеть одну область содержимого во весь экран вместо стандартного обычного вида с тремя областями. При включении приложение может отобразить одну из областей содержимого на всём окне.

Методы [getVerticalBarState](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) и [getHorizontalBarState](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) задают состояние, в котором должна отображаться горизонтальная или вертикальная полоса разделителя. Горизонтальная полоса разделяет слайд и область содержимого под слайдом; вертикальная полоса разделяет слайд и боковую область содержимого. Возможные значения: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ru/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ru/python-java/aspose.slides/splitterbarstatetype/#Maximized) и [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ru/python-java/aspose.slides/splitterbarstatetype/#Restored).

Методы [getRestoredLeft](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) и [getRestoredTop](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getRestoredTop) определяют размеры верхней или боковой области слайда обычного вида, когда значение [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ru/python-java/aspose.slides/splitterbarstatetype/#Restored) применяется к [getVerticalBarState](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) и [getHorizontalBarState](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) соответственно.

## **О восстановлении NormalViewProperties**

Определяет размеры области слайда (ширина, когда это дочерний элемент [getRestoredTop](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getRestoredTop), высота, когда это дочерний элемент [getRestoredLeft](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) обычного вида, когда область имеет переменный восстановленный размер (не минимизирована и не максимизирована).

Метод [getDimensionSize](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) задаёт размер области слайда (ширина, когда это дочерний элемент [getRestoredTop](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getRestoredTop), высота, когда это дочерний элемент [getRestoredLeft](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

Метод [getAutoAdjust](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) указывает, должна ли боковая область содержимого компенсировать новый размер при изменении размеров окна, содержащего представление в приложении.

Ниже показан пример, как получить доступ к [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/#getNormalViewProperties) для презентации.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation()
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    # Восстановить свойства представления презентации.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Установка значения масштабирования по умолчанию**

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python via Java поддерживает установку значения масштабирования по умолчанию, которое применяется сразу при открытии презентации. Это можно сделать, задав [ViewProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/) презентации. Методы [getSlideViewProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/#getSlideViewProperties) и [getNotesViewProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/#getNotesViewProperties) могут быть сконфигурированы программно. В этой статье мы покажем пример того, как задать [View Properties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/) у [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) в Aspose.Slides.

{{% /alert %}}

Чтобы задать свойства представления, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Задайте [View Properties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/) у [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Сохраните презентацию как файл [PPTX](https://docs.fileformat.com/presentation/pptx/).

В приведённом ниже примере задаётся значение масштабирования как для просмотра слайдов, так и для просмотра заметок.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Установить свойства представления презентации.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Процент масштабирования для просмотра слайда.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Процент масштабирования для просмотра заметок.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Установка интервала сетки**

Используйте [Presentation.getViewProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getViewProperties) для доступа к настройкам представления, применимым ко всей презентации. Методы [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/#getGridSpacing) и [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/#setGridSpacing) читают или изменяют интервал базовой сетки редактирования. Эта настройка применяется ко всей презентации, а не к отдельному слайду. Интервал сетки указывается в пунктах, где 72 пункта равны одному дюйму. Используйте положительное значение, как предписано в документации API.

В следующем примере открывается существующий файл `demo.pptx`, выводится текущий интервал сетки, задаётся интервал в четверть дюйма и сохраняется результат.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    grid_spacing = presentation.getViewProperties().getGridSpacing()
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.getViewProperties().setGridSpacing(18.0)
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Сетка отличается от [drawing guides](/slides/ru/python-java/drawing-guides/). Интервал сетки задаёт регулярный шаг, тогда как направляющие — это отдельные горизонтальные или вертикальные линии выравнивания. Добавление, перемещение или удаление направляющих не меняет интервал сетки.

И сетка, и направляющие являются вспомогательными средствами редактирования. Они не отображаются как содержимое слайда в PDF, изображениях, SVG или при показе слайдов. Сохранение интервала сетки не гарантирует, что редактор отобразит её: её видимость также зависит от настроек просмотрщика или редактора.

## **Показ или скрытие комментариев при открытии презентации**

Используйте [Presentation.getViewProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getViewProperties) для доступа к настройкам представления, применимым ко всей презентации. Методы [ViewProperties.getShowComments](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/#getShowComments) и [ViewProperties.setShowComments](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/#setShowComments) позволяют считать или изменить сохранённую настройку отображения комментариев при открытии презентации в PowerPoint или другом совместимом редакторе.

Эта настройка управляет только сохранённым предпочтением представления. Она не добавляет, не удаляет, не редактирует и не разрешает комментарии. Скрытие комментариев сохраняет их содержимое, авторов, позиции, ответы и статусы. См. раздел [Presentation Comments](/slides/ru/python-java/presentation-comments/) для операций, изменяющих сами комментарии.

В следующем примере требуется существующий файл `comments.pptx` с комментариями. Пример выводит текущую настройку видимости, запрашивает скрытие комментариев и сохраняет новый PPTX без удаления каких‑либо комментариев. Он также использует [ViewProperties.setLastView](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/#setLastView) с [ViewType.SlideView](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewtype/#SlideView) для конфигурирования начального режима редактирования вместе с видимостью комментариев.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ViewType

presentation = Presentation("comments.pptx")
try:
    show_comments = presentation.getViewProperties().getShowComments()
    print(f"Current comment visibility: {show_comments}")

    presentation.getViewProperties().setShowComments(NullableBool.False_)
    presentation.getViewProperties().setLastView(ViewType.SlideView)
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Эта настройка не определяет, будут ли комментарии включены в экспорты PDF, HTML, изображений, заметок или раздаточных материалов. Настройте соответствующие параметры экспорта отдельно.

## **FAQ**

**Почему сетка не видна после повторного открытия презентации?**

Файл сохраняет интервал сетки, но редактор контролирует её отображение. Проверьте настройки видимости сетки в редакторе.

**Изменит ли очистка направляющих интервал сетки?**

Нет. Направляющие и интервал сетки — независимые параметры. Очистка направляющих не меняет сохранённый интервал сетки.

**Можно ли задать разные настройки представления для разных секций презентации?**

[View settings](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getViewProperties) определяются на уровне презентации ([Normal View](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), а не для каждой секции, поэтому один набор параметров применяется ко всему документу при открытии.

**Можно ли заранее определить разные состояния представления для разных пользователей?**

Нет. Настройки хранятся в файле и являются общими. Приложения‑просмотрщики могут учитывать предпочтения пользователя, но сам файл содержит один набор свойств представления.

**Можно ли подготовить шаблон с предустановленными свойствами представления, чтобы новые презентации открывались одинаково?**

Да. Поскольку [view properties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getViewProperties) сохраняются на уровне презентации, их можно включить в шаблон и создавать новые документы на его основе с тем же начальным конфигурированием представления.