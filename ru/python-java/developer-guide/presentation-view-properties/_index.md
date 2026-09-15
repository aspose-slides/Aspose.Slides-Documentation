---
title: "Получить и обновить свойства просмотра презентации в Python через Java"
linktitle: "Свойства просмотра"
type: docs
weight: 80
url: /ru/python-java/presentation-view-properties/
keywords:
- свойства просмотра
- обычный просмотр
- контурное содержимое
- контурные значки
- привязка вертикального разделителя
- одиночный просмотр
- состояние полосы
- размер измерения
- автонастройка
- масштаб по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Откройте для себя свойства просмотра Aspose.Slides для Python через Java, чтобы настраивать слайды PPT, PPTX и ODP — регулировать макеты, уровни масштабирования и параметры отображения."
---
## **Введение**

Обычный просмотр состоит из трех областей содержимого: самого слайда, боковой области содержимого и нижней области содержимого. Свойства обычного просмотра описывают расположение этих областей содержимого. Эта информация позволяет приложению сохранять состояние просмотра в файл, чтобы при повторном открытии просмотр находился в том же состоянии, в котором презентация была сохранена в последний раз.

Метод [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/#getNormalViewProperties) был добавлен для предоставления доступа к свойствам обычного просмотра презентации.

Классы [NormalViewProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/) и [NormalViewRestoredProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewrestoredproperties/) и перечисление [SplitterBarStateType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/splitterbarstatetype/) также были добавлены.

## **О NormalViewProperties**

Представляет свойства обычного просмотра.

Методы [getShowOutlineIcons](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) и [setShowOutlineIcons](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) определяют, должно ли приложение показывать значки при отображении контурного содержимого в любой из областей обычного режима просмотра.

Методы [getSnapVerticalSplitter](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) и [setSnapVerticalSplitter](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) определяют, должен ли вертикальный разделитель переключаться в минимизированное состояние, когда боковая область достаточно мала.

Методы [getPreferSingleView](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) и [setPreferSingleView](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) определяют, предпочитает ли пользователь видеть одну область содержимого на весь экран вместо стандартного обычного просмотра с тремя областями. При включении приложение может отобразить одну из областей содержимого во всем окне.

Методы [getVerticalBarState](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) и [getHorizontalBarState](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) определяют состояние, в котором должна показываться горизонтальная или вертикальная полоса разделителя. Горизонтальная полоса разделяет слайд и область содержимого под слайдом; вертикальная полоса разделяет слайд и боковую область содержимого. Возможные значения: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ru/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ru/python-java/aspose.slides/splitterbarstatetype/#Maximized) и [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ru/python-java/aspose.slides/splitterbarstatetype/#Restored).

Методы [getRestoredLeft](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) и [getRestoredTop](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getRestoredTop) задают размеры верхней или боковой области слайда обычного просмотра, когда значение [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ru/python-java/aspose.slides/splitterbarstatetype/#Restored) применяется к [getVerticalBarState](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) и [getHorizontalBarState](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) соответственно.

## **О восстановлении NormalViewProperties**

Определяет размеры области слайда (ширина, если это дочерний элемент [getRestoredTop](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getRestoredTop), высота, если это дочерний элемент [getRestoredLeft](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) обычного просмотра, когда область имеет переменный восстановленный размер (ни минимизированный, ни максимизированный).

Метод [getDimensionSize](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) задает размер области слайда (ширина, если это дочерний элемент [getRestoredTop](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getRestoredTop), высота, если это дочерний элемент [getRestoredLeft](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

Метод [getAutoAdjust](https://reference.aspose.com/slides/ru/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) определяет, должна ли боковая область содержимого компенсировать новый размер при изменении размера окна, содержащего просмотр в приложении.

Ниже приведен пример доступа к [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/#getNormalViewProperties) для презентации.

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

    # Восстановить свойства просмотра презентации.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Установить значение масштабирования по умолчанию**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java поддерживает установку значения масштабирования по умолчанию, которое будет применено уже при открытии презентации. Это можно сделать, задав [ViewProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/) презентации. Методы [getSlideViewProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/#getSlideViewProperties) и [getNotesViewProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/#getNotesViewProperties) можно настроить программно. В этой статье мы покажем пример, как задать [View Properties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/) для [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) в [Aspose.Slides](/slides/ru/).
{{% /alert %}}

Чтобы задать свойства просмотра, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Задайте [View Properties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/) для [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Сохраните презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).

В примере ниже мы задаём значение масштабирования как для просмотра слайдов, так и для просмотра заметок.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Установить свойства просмотра презентации.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Процент масштабирования для просмотра слайда.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Процент масштабирования для просмотра заметок.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Часто задаваемые вопросы**

**Можно ли задать разные настройки просмотра для разных разделов презентации?**

[View settings](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getViewProperties) определяются на уровне всей презентации ([Normal View](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), а не для отдельных разделов, поэтому один набор параметров применяется ко всему документу при открытии.

**Можно ли заранее определить разные состояния просмотра для разных пользователей?**

Нет. Настройки сохраняются в файле и общие для всех. Приложения‑просмотрщики могут учитывать предпочтения пользователя, но сам файл содержит один набор свойств просмотра.

**Можно ли подготовить шаблон с предустановленными свойствами просмотра, чтобы новые презентации открывались одинаково?**

Да. Поскольку [view properties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getViewProperties) хранятся на уровне презентации, их можно встроить в шаблон и создавать новые документы на его основе с той же начальной конфигурацией просмотра.