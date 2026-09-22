---
title: "Получить и обновить свойства представления презентации в Python через Java"
linktitle: "Свойства представления"
type: docs
weight: 80
url: /ru/python-java/presentation-view-properties/
keywords:
- "свойства представления"
- "обычный режим"
- "содержание конспекта"
- "значки конспекта"
- "привязка вертикального разделителя"
- "одиночный режим"
- "состояние полосы"
- "размер измерения"
- "автоматическая настройка"
- "масштаб по умолчанию"
- "PowerPoint"
- "OpenDocument"
- "презентация"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Узнайте о свойствах представления Aspose.Slides для Python через Java, позволяющих настраивать слайды PPT, PPTX и ODP — изменять макеты, уровни масштабирования и параметры отображения."
---
## **Введение**

Обычный режим отображения состоит из трёх областей содержимого: самого слайда, боковой области содержимого и нижней области содержимого. Свойства обычного режима описывают расположение этих областей. Эта информация позволяет приложению сохранять состояние представления в файл, чтобы при повторном открытии представление было в том же состоянии, что и при последнем сохранении презентации.

Метод [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/#getNormalViewProperties) был добавлен для предоставления доступа к свойствам обычного режима презентации.

Классы [NormalViewProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/) и [NormalViewRestoredProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewrestoredproperties/) и перечисление [SplitterBarStateType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/splitterbarstatetype/) также были добавлены.

## **О NormalViewProperties**

Представляет свойства обычного режима.

Методы [getShowOutlineIcons](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) и [setShowOutlineIcons](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) указывают, следует ли приложению показывать значки при отображении содержания конспекта в любой из областей обычного режима.

Методы [getSnapVerticalSplitter](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) и [setSnapVerticalSplitter](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) указывают, должен ли вертикальный разделитель переходить в свернутое состояние, когда боковая область достаточно мала.

Методы [getPreferSingleView](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) и [setPreferSingleView](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) определяют, предпочитает ли пользователь видеть одну большую область содержимого на весь экран вместо стандартного обычного режима с тремя областями. При включении приложение может выбрать отображать одну из областей содержимого во всём окне.

Методы [getVerticalBarState](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) и [getHorizontalBarState](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) указывают состояние, в котором должна отображаться горизонтальная или вертикальная полоса разделителя. Горизонтальная полоса разделяет слайд и область содержимого под слайдом; вертикальная полоса разделяет слайд и боковую область содержимого. Возможные значения: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ru/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ru/python-java/aspose.slides/splitterbarstatetype/#Maximized) и [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ru/python-java/aspose.slides/splitterbarstatetype/#Restored).

Методы [getRestoredLeft](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) и [getRestoredTop](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getRestoredTop) задают размеры верхней или боковой области слайда в обычном режиме, когда значение [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ru/python-java/aspose.slides/splitterbarstatetype/#Restored) применяется к [getVerticalBarState](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) и [getHorizontalBarState](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) соответственно.

## **О восстановлении NormalViewProperties**

Указывает размеры области слайда (ширина, когда это дочерний элемент [getRestoredTop](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getRestoredTop), высота, когда это дочерний элемент [getRestoredLeft](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) обычного режима, когда область имеет переменный восстановленный размер (ни свернута, ни развернута).

Метод [getDimensionSize](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) задаёт размер области слайда (ширина, когда это дочерний элемент [getRestoredTop](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getRestoredTop), высота, когда это дочерний элемент [getRestoredLeft](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

Метод [getAutoAdjust](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) указывает, должна ли боковая область содержимого компенсировать новый размер при изменении размеров окна, в котором отображается представление в приложении.

Ниже приведён пример того, как получить доступ к [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/#getNormalViewProperties) для презентации.

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

## **Установить значение масштаба по умолчанию**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java поддерживает установку значения масштаба по умолчанию, чтобы оно применялось сразу при открытии презентации. Это можно сделать, задав [ViewProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/) презентации. Методы [getSlideViewProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/#getSlideViewProperties) и [getNotesViewProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/#getNotesViewProperties) могут быть сконфигурированы программно. В этой статье мы покажем на примере, как установить [View Properties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/) для [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) в Aspose.Slides.
{{% /alert %}}

Для установки свойств представления выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Установите [View Properties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/) для [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Сохраните презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).

В примере ниже задаётся значение масштаба как для режима просмотра слайдов, так и для режима просмотра заметок.

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

## **Установить интервал сетки**

Используйте [Presentation.getViewProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getViewProperties) для доступа к глобальным настройкам представления презентации. Методы [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/#getGridSpacing) и [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/#setGridSpacing) читают или изменяют интервал базовой сетки редактирования. Эта настройка применяется ко всей презентации, а не к отдельному слайду. Интервал сетки задаётся в пунктах, где 72 пункта = один дюйм. Используйте положительное значение, как указано в документации API.

В следующем примере открывается существующий файл `demo.pptx`, выводится текущий интервал сетки, устанавливается интервал в четверть дюйма и сохраняется результат.

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

Сетка отличается от [drawing guides](/slides/ru/python-java/drawing-guides/). Интервал сетки задаёт регулярный шаг, тогда как направляющие – это индивидуально расположенные горизонтальные или вертикальные линии выравнивания. Добавление, перемещение или удаление направляющих не меняет интервал сетки.

И сетка, и направляющие являются вспомогательными средствами редактирования. Они не отображаются как содержимое слайда в PDF, изображениях, SVG или при показе слайдов. Сохранение интервала сетки не гарантирует, что редактор отобразит её: видимость также зависит от настроек просмотрового или редактирующего приложения.

## **FAQ**

**Почему сетка не видна после повторного открытия презентации?**

Файл сохраняет интервал сетки, но отображение сетки контролируется редактором. Проверьте параметры видимости сетки в используемом редакторе.

**Изменит ли удаление направляющих интервал сетки?**

Нет. Направляющие и интервал сетки – независимые настройки. Очистка направляющих не меняет сохранённый интервал сетки.

**Можно ли задать разные настройки представления для разных разделов презентации?**

Настройки представления ([View settings](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getViewProperties)) определяются на уровне всей презентации ([Normal View](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), а не для отдельных разделов, поэтому один набор параметров применяется ко всему документу при открытии.

**Можно ли заранее задать разные состояния представления для разных пользователей?**

Нет. Настройки сохраняются в файле и общие для всех. Приложения‑просмотрщики могут учитывать пользовательские предпочтения, но сам файл содержит единственный набор свойств представления.

**Можно ли создать шаблон с предустановленными свойствами представления, чтобы новые презентации открывались одинаково?**

Да. Поскольку [view properties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getViewProperties) хранятся на уровне презентации, их можно включить в шаблон и создавать на его основе новые документы с одинаковой начальной конфигурацией представления.