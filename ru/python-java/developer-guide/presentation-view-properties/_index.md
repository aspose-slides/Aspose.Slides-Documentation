---
title: Получение и обновление свойств представления презентации в Python через Java
linktitle: Свойства представления
type: docs
weight: 80
url: /ru/python-java/presentation-view-properties/
keywords:
- свойства представления
- обычный режим
- содержание схемы
- значки схемы
- фиксация вертикального разделителя
- один вид
- состояние панели
- размер измерения
- автоматическая настройка
- масштаб по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Используйте Aspose.Slides for Python via Java для настройки макета обычного режима, масштабирования слайда и заметок, интервала сетки и отображения комментариев в презентациях PowerPoint."
---
## **Введение**

В обычном режиме просмотра PowerPoint слайд отображается между боковой панелью с миниатюрами или схемой и панелью заметок внизу. Aspose.Slides for Python via Java предоставляет сохранённые настройки редактирования презентации через [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties). Эти настройки включают расположение панелей, уровни масштабирования, интервалы сетки и отображение комментариев.

## **О NormalViewProperties**

Используйте [getNormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNormalViewProperties) для доступа к классу [NormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/). Метод [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) управляет отображением значков рядом с заголовками слайдов в схеме. Метод [setSnapVerticalSplitter](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) позволяет боковой панели автоматически переходить в минимизированное состояние, когда пользователь сжимает её. Метод [setPreferSingleView](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) указывает предпочтение отображения одной панели во всем окне.

[setVerticalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setVerticalBarState) управляет разделителем между боковой панелью и слайдом. [setHorizontalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setHorizontalBarState) управляет разделителем над панелью заметок. Оба метода принимают значение [SplitterBarStateType](https://reference.aspose.com/slides/python-java/aspose.slides/splitterbarstatetype/) `Minimized`, `Maximized` или `Restored`.

## **О восстановлении NormalViewProperties**

Когда разделитель восстанавливается, [getRestoredLeft](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) возвращает сохранённый размер боковой панели, а [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) — сохранённый размер верхней части слайда. Оба метода возвращают экземпляр [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/). Его метод [setDimensionSize](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) принимает процент от 0 до 100, а [setAutoAdjust](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) управляет тем, будет ли редактор автоматически менять размер при изменении окна.

В этом примере обновляется существующая презентация. Восстанавливается горизонтальный разделитель, размер, полученный от [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop), устанавливается в 80 % с включённой автоматической корректировкой, а вертикальный разделитель разворачивается в максимальное состояние. Также вызывается [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) для отображения значков в схеме.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation("demo.pptx")
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Установить значение масштабирования по умолчанию**

[getSlideViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getSlideViewProperties) и [getNotesViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNotesViewProperties) сохраняют независимые параметры масштабирования для редактора. Эти настройки не влияют на размеры слайдов, воспроизведение слайд-шоу или разрешение при экспорте изображений.

В этом примере открывается существующая презентация и вызывается [setVariableScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setVariableScale) для подгонки слайда под окно редактирования. Для страницы заметок отключается автоматическое масштабирование и вызывается [setScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setScale) для установки фиксированного масштаба 80 %.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    view_properties = presentation.getViewProperties()
    view_properties.getSlideViewProperties().setVariableScale(True)
    notes_view = view_properties.getNotesViewProperties()
    notes_view.setVariableScale(False)
    notes_view.setScale(80)

    presentation.save("zoom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Установить интервал сетки**

[setGridSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setGridSpacing) задаёт расстояние между линиями редактирующей сетки во всей презентации. Принимает положительное значение в пунктах, где 72 пункта = 1 дюйм. В этом примере выводится текущий интервал в существующей презентации и сохраняется сетка с шагом четверти дюйма, задав интервал 18 пунктов.

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

Сетка повторяется с фиксированным интервалом. [Руководящие линии](/slides/ru/python-java/drawing-guides/) отмечают отдельные горизонтальные или вертикальные позиции. Оба являются вспомогательными средствами редактирования и отображаются только в редакторах, которые их показывают. Слайд-шоу и экспорты в PDF, изображения или SVG их не включают.

## **Показать или скрыть комментарии при открытии презентации**

[setShowComments](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setShowComments) сохраняет предпочтение, которое совместимые редакторы используют при открытии презентации. Для существующей презентации с комментариями этот пример выводит текущую настройку и сохраняет копию с скрытыми комментариями. Также вызывается [setLastView](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setLastView) с параметром [ViewType.SlideView](https://reference.aspose.com/slides/python-java/aspose.slides/viewtype/#SlideView), чтобы копия открылась в режиме просмотра слайда.

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

Скрытие комментариев сохраняет их текст, авторов, позиции, ответы и статусы. Чтобы изменить сами комментарии, см. [Комментарии к презентации](/slides/ru/python-java/presentation-comments/). Параметры экспорта определяют, будут ли комментарии отображаться в PDF, HTML, изображениях, заметках или раздаточных материалах.

## **Часто задаваемые вопросы**

**Почему сетка скрыта, когда я повторно открываю презентацию?**  
Презентация сохраняет интервал сетки. Чтобы увидеть сетку, включите её отображение в редакторе.

**Изменит ли удаление руководящих линий интервал сетки?**  
Нет. Добавление, перемещение или удаление линии не меняет интервал сетки.

**Могут ли разные разделы презентации иметь разные настройки просмотра?**  
Нет. [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) применяется ко всей презентации.

**Могу ли я сохранить разные настройки просмотра для разных пользователей?**  
Файл хранит один набор свойств просмотра для всех. Редактор может также применять локальные предпочтения пользователя.

**Могу ли я сохранить настройки просмотра в шаблоне?**  
Да. Презентации, созданные из шаблона, наследуют его сохранённые настройки просмотра.