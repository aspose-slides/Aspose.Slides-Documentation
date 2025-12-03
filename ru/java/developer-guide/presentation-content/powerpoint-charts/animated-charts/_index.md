---
title: Анимировать диаграммы PowerPoint в Java
linktitle: Анимированные диаграммы
type: docs
weight: 80
url: /ru/java/animated-charts/
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
- Java
- Aspose.Slides
description: "Создайте потрясающие анимированные диаграммы в Java с Aspose.Slides. Усильте презентации динамической визуализацией в файлах PPT и PPTX — начните сейчас."
---

{{% alert color="primary" %}} 

Aspose.Slides for Java поддерживает анимацию элементов диаграммы. **Series**, **Categories**, **Series Elements**, **Categories Elements** можно анимировать с помощью метода [**ISequence**.**addEffect**](https://reference.aspose.com/slides/java/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) и двух перечислений [**EffectChartMajorGroupingType**](https://reference.aspose.com/slides/java/com.aspose.slides/EffectChartMajorGroupingType) и [**EffectChartMinorGroupingType**](https://reference.aspose.com/slides/java/com.aspose.slides/EffectChartMinorGroupingType).

{{% /alert %}} 

## **Анимация серий диаграммы**
Если вы хотите анимировать серию диаграммы, выполните код согласно нижеприведённым шагам:

1. Загрузите презентацию.
1. Получите ссылку на объект диаграммы.
1. Анимируйте серию.
1. Сохраните файл презентации на диск.

В примере ниже мы анимировали серии диаграммы.
```java
// Создать объект класса Presentation, представляющий файл презентации
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Получить ссылку на объект диаграммы
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Анимировать серию
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 0,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 1,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 2,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 3,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Сохранить изменённую презентацию на диск
    pres.save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Анимация категорий диаграммы**
Если вы хотите анимировать категорию диаграммы, выполните код согласно нижеприведённым шагам:

1. Загрузите презентацию.
1. Получите ссылку на объект диаграммы.
1. Анимируйте категорию.
1. Сохраните файл презентации на диск.

В примере ниже мы анимировали категорию диаграммы.
```java
// Создать объект класса Presentation, представляющий файл презентации
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.ByCategory, 0, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 1, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 2, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 3, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    pres.save("Sample_Animation_C.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Анимация элементов серии**
Если вы хотите анимировать элементы серии, выполните код согласно нижеприведённым шагам:

1. Загрузите презентацию.
1. Получите ссылку на объект диаграммы.
1. Анимируйте элементы серии.
1. Сохраните файл презентации на диск.

В примере ниже мы анимировали элементы серии.
```java
// Создать объект класса Presentation, представляющий файл презентации
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Получить ссылку на объект диаграммы
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Анимировать элементы серии
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Сохранить файл презентации на диск 
    pres.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Анимация элементов категории**
Если вы хотите анимировать элементы категорий, выполните код согласно нижеприведённым шагам:

1. Загрузите презентацию.
1. Получите ссылку на объект диаграммы.
1. Анимируйте элементы категорий.
1. Сохраните файл презентации на диск.

В примере ниже мы анимировали элементы категорий.
```java
// Создать объект класса Presentation, который представляет файл презентации
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Получить ссылку на объект диаграммы
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Анимировать элементы категорий
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Записать файл презентации на диск
    pres.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Поддерживаются ли различные типы эффектов (например, появление, акцент, исчезновение) для диаграмм, как и для обычных фигур?**

Да. Диаграмма рассматривается как фигура, поэтому поддерживает стандартные типы анимационных эффектов, включая появление, акцент и исчезновение, с полным контролем через таймлайн слайда и последовательности анимаций.

**Можно ли комбинировать анимацию диаграммы с переходами слайдов?**

Да. [Transitions](/slides/ru/java/slide-transition/) применяются к слайду, тогда как анимационные эффекты применяются к объектам на слайде. Вы можете использовать их вместе в одной презентации и управлять ими независимо.

**Сохраняются ли анимации диаграмм при сохранении в PPTX?**

Да. При [save to PPTX](/slides/ru/java/save-presentation/) все анимационные эффекты и их порядок сохраняются, так как они являются частью нативной модели анимации презентации.

**Можно ли считывать существующие анимации диаграмм из презентации и изменять их?**

Да. API предоставляет доступ к таймлайну слайда, последовательностям и эффектам, позволяя инспектировать существующие анимации диаграмм и корректировать их без необходимости воссоздавать всё заново.

**Можно ли создать видео, включающее анимацию диаграмм, с помощью Aspose.Slides?**

Да. Вы можете [export a presentation to video](/slides/ru/java/convert-powerpoint-to-video/) с сохранением анимаций, настроив тайминги и другие параметры экспорта, чтобы полученный клип отражал анимированное воспроизведение.