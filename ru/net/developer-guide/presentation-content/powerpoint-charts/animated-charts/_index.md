---
title: Анимация диаграмм PowerPoint в .NET
linktitle: Анимированные диаграммы
type: docs
weight: 80
url: /ru/net/animated-charts/
keywords:
- диаграмма
- анимированная диаграмма
- анимация диаграммы
- серия диаграммы
- категория диаграммы
- элемент серии
- элемент категории
- добавить эффект
- тип эффекта
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Создавайте впечатляющие анимированные диаграммы в .NET с помощью Aspose.Slides. Улучшайте презентации динамической визуализацией в файлах PPT и PPTX — начните прямо сейчас."
---

Aspose.Slides for .NET поддерживает анимацию элементов диаграммы. **Series**, **Categories**, **Series Elements**, **Categories Elements** можно анимировать с помощью метода [**ISequence**.**AddEffect** ](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/methods/addeffect) и двумя перечислениями [**EffectChartMajorGroupingType** ](https://reference.aspose.com/slides/net/aspose.slides.animation/effectchartmajorgroupingtype) и [**EffectChartMinorGroupingType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effectchartminorgroupingtype).
## **Анимация серии диаграммы**
Если вы хотите анимировать серию диаграммы, напишите код в соответствии с шагами, перечисленными ниже:

1. Загрузите презентацию.
1. Получите ссылку на объект диаграммы.
1. Анимируйте серию.
1. Запишите файл презентации на диск.

В приведённом ниже примере мы анимировали серию диаграммы.
```c#
 // Создайте объект класса Presentation, представляющий файл презентации 
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Получите ссылку на объект диаграммы
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animate the series
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,
    EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 0,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 1,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 2,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 3,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Запишите изменённую презентацию на диск 
    presentation.Save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
}
```


## **Анимация категории диаграммы**
Если вы хотите анимировать категорию диаграммы, напишите код в соответствии с шагами, перечисленными ниже:

1. Загрузите презентацию.
1. Получите ссылку на объект диаграммы.
1. Анимируйте категорию.
1. Запишите файл презентации на диск.

В приведённом ниже примере мы анимировали категорию диаграммы.
```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Получить ссылку на объект диаграммы
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Анимировать элементы категорий
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Записать файл презентации на диск
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```


## **Анимация в элементе серии**
Если вы хотите анимировать элементы серии, напишите код в соответствии с шагами, перечисленными ниже:

1. Загрузите презентацию.
1. Получите ссылку на объект диаграммы.
1. Анимируйте элементы серии.
1. Запишите файл презентации на диск.

В приведённом ниже примере мы анимировали элементы серии.
```c#
 // Загрузить презентацию
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Получить ссылку на объект диаграммы
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Анимировать элементы серии
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Записать файл презентации на диск
    presentation.Save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
}
```


## **Анимация в элементе категории**
Если вы хотите анимировать элементы категории, напишите код в соответствии с шагами, перечисленными ниже:

1. Загрузите презентацию.
1. Получите ссылку на объект диаграммы.
1. Анимируйте элементы категории.
1. Запишите файл презентации на диск.

В приведённом ниже примере мы анимировали элементы категории.
```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Получить ссылку на объект диаграммы
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Анимировать элементы категорий
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Записать файл презентации на диск
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Поддерживаются ли разные типы эффектов (например, вход, акцент, выход) для диаграмм так же, как и для обычных фигур?**

Да. Диаграмма рассматривается как фигура, поэтому она поддерживает стандартные типы анимационных эффектов, включая вход, акцент и выход, с полной настройкой через временную шкалу слайда и последовательности анимаций.

**Можно ли комбинировать анимацию диаграммы с переходами слайда?**

Да. [Transitions](/slides/ru/net/slide-transition/) применяются к слайду, в то время как анимационные эффекты применяются к объектам на слайде. Вы можете использовать их вместе в одной презентации и управлять ими независимо.

**Сохраняются ли анимации диаграмм при сохранении в PPTX?**

Да. Когда вы [сохранить в PPTX](/slides/ru/net/save-presentation/), все анимационные эффекты и их порядок сохраняются, потому что они являются частью родной модели анимации презентации.

**Можно ли прочитать существующие анимации диаграмм из презентации и изменить их?**

Да. [API](https://reference.aspose.com/slides/net/aspose.slides.animation/) предоставляет доступ к временной шкале слайда, последовательностям и эффектам, позволяя просматривать существующие анимации диаграмм и корректировать их без необходимости воссоздавать всё заново.

**Можно ли создать видео, включающее анимацию диаграмм, используя Aspose.Slides?**

Да. Вы можете [экспортировать презентацию в видео](/slides/ru/net/convert-powerpoint-to-video/) с сохранением анимаций, настройкой таймингов и других параметров экспорта, чтобы полученный клип воспроизводил анимированное воспроизведение.