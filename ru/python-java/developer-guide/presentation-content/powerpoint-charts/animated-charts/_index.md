---
title: Анимировать диаграммы PowerPoint в Python через Java
linktitle: Анимированные диаграммы
type: docs
weight: 80
url: /ru/python-java/animated-charts/
keywords:
- диаграмма
- анимированная диаграмма
- анимация диаграммы
- серии диаграммы
- категория диаграммы
- элемент серии
- элемент категории
- добавить эффект
- тип эффекта
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Создайте впечатляющие анимированные диаграммы в Python через Java с помощью Aspose.Slides. Улучшите презентации динамической визуализацией в файлах PPT и PPTX — начните прямо сейчас."
---
## **Введение**

Aspose.Slides for Python via Java поддерживает анимацию элементов диаграммы. **Series**, **Categories**, **Series Elements** и **Category Elements** можно анимировать с помощью метода [Sequence.addEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sequence/#addEffect) и двух перечислений: [EffectChartMajorGroupingType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/effectchartmajorgroupingtype/) и [EffectChartMinorGroupingType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/effectchartminorgroupingtype/).

## **Анимация серии диаграммы**

Если вы хотите анимировать серию диаграммы, напишите код в соответствии с перечисленными ниже шагами:

1. Загрузить презентацию.
1. Получить ссылку на объект диаграммы.
1. Анимировать серию.
1. Сохранить файл презентации на диск.

Следующий пример анимирует серии диаграммы. Диаграмма в примере содержит три серии, поэтому эффект добавляется для каждого индекса от 0 до 2. Aspose.Slides не проверяет индекс относительно данных диаграммы, и эффект, добавленный для несуществующей серии, записывается в файл, но не анимирует ничего — держите индекс меньше количества серий в вашей диаграмме.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Загрузить презентацию.
presentation = Presentation("ExistingChart.pptx")
try:
    # Получить ссылку на объект диаграммы.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Анимировать элементы диаграммы.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Сохранить измененную презентацию на диск.
    presentation.save("AnimatingSeries_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Анимация категории диаграммы**

Если вы хотите анимировать категорию диаграммы, напишите код в соответствии с перечисленными ниже шагами:

1. Загрузить презентацию.
1. Получить ссылку на объект диаграммы.
1. Анимировать категорию.
1. Сохранить файл презентации на диск.

Следующий пример анимирует категории диаграммы.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Загрузить презентацию.
presentation = Presentation("ExistingChart.pptx")
try:
    # Получить ссылку на объект диаграммы.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Анимировать элементы диаграммы.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Сохранить измененную презентацию на диск.
    presentation.save("Sample_Animation_C.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Анимация в элементе серии**

Если вы хотите анимировать элементы серии, напишите код в соответствии с перечисленными ниже шагами:

1. Загрузить презентацию.
1. Получить ссылку на объект диаграммы.
1. Анимировать элементы серии.
1. Сохранить файл презентации на диск.

Следующий пример анимирует элементы серии.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Загрузить презентацию.
presentation = Presentation("ExistingChart.pptx")
try:
    # Получить ссылку на объект диаграммы.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Анимировать элементы диаграммы.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Сохранить измененную презентацию на диск.
    presentation.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Анимация в элементе категории**

Если вы хотите анимировать элементы категории, напишите код в соответствии с перечисленными ниже шагами:

1. Загрузить презентацию.
1. Получить ссылку на объект диаграммы.
1. Анимировать элементы категории.
1. Сохранить файл презентации на диск.

Следующий пример анимирует элементы категории.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Загрузить презентацию.
presentation = Presentation("ExistingChart.pptx")
try:
    # Получить ссылку на объект диаграммы.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Анимировать элементы диаграммы.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Сохранить измененную презентацию на диск.
    presentation.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Поддерживаются ли разные типы эффектов (например, появление, акцент, завершение) для диаграмм, как и для обычных фигур?**

Да. Диаграмма рассматривается как фигура, поэтому она поддерживает стандартные типы анимационных эффектов, включая появление, акцент и завершение, с полным управлением через временную шкалу слайда и последовательности анимаций.

**Можно ли комбинировать анимацию диаграммы с переходами слайдов?**

Да. [Transitions](/slides/ru/python-java/slide-transition/) относятся к слайду, в то время как анимационные эффекты применяются к объектам на слайде. Вы можете использовать их вместе в одной презентации и управлять ими независимо.

**Сохраняются ли анимации диаграмм при сохранении в PPTX?**

Да. При [save to PPTX](/slides/ru/python-java/save-presentation/) все анимационные эффекты и их порядок сохраняются, так как они являются частью нативной модели анимации презентации.

**Можно ли прочитать существующие анимации диаграмм из презентации и изменить их?**

Да. API предоставляет доступ к временной шкале слайда, последовательностям и эффектам, позволяя просматривать существующие анимации диаграмм и корректировать их без необходимости воссоздавать всё заново.

**Можно ли создавать видео, включающее анимацию диаграмм, используя Aspose.Slides?**

Да. Вы можете [export a presentation to video](/slides/ru/python-java/convert-powerpoint-to-video/) с сохранением анимаций, настроив тайминги и другие параметры экспорта, чтобы получившийся ролик отражал анимированное воспроизведение.