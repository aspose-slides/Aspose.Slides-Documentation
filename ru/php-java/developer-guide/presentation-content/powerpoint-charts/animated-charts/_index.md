---
title: Анимировать диаграммы PowerPoint в PHP
linktitle: Анимированные диаграммы
type: docs
weight: 80
url: /ru/php-java/animated-charts/
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
- PHP
- Aspose.Slides
description: "Создавайте потрясающие анимированные диаграммы с помощью Aspose.Slides for PHP via Java. Улучшайте презентации динамичной визуализацией в файлах PPT и PPTX — начните прямо сейчас."
---

{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java поддерживает анимацию элементов диаграммы. **Series**, **Categories**, **Series Elements**, **Categories Elements** можно анимировать с помощью метода [**Sequence::addEffect**](https://reference.aspose.com/slides/php-java/aspose.slides/sequence/#addEffect) и двух перечислений [**EffectChartMajorGroupingType**](https://reference.aspose.com/slides/php-java/aspose.slides/EffectChartMajorGroupingType) и [**EffectChartMinorGroupingType**](https://reference.aspose.com/slides/php-java/aspose.slides/EffectChartMinorGroupingType).

{{% /alert %}} 

## **Анимация серий диаграммы**
Если вы хотите анимировать серию диаграммы, напишите код согласно шагам, перечисленным ниже:

1. Загрузите презентацию.
1. Получите ссылку на объект диаграммы.
1. Анимируйте серию.
1. Сохраните файл презентации на диск.

В приведённом ниже примере мы анимировали серию диаграммы.
```php
  # Создать экземпляр класса Presentation, который представляет файл презентации
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Получить ссылку на объект диаграммы
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Анимировать серию
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Сохранить изменённую презентацию на диск
    $pres->save("AnimatingSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Анимация категорий диаграммы**
Если вы хотите анимировать категорию диаграммы, напишите код согласно шагам, перечисленным ниже:

1. Загрузите презентацию.
1. Получите ссылку на объект диаграммы.
1. Анимируйте категорию.
1. Сохраните файл презентации на диск.

В приведённом ниже примере мы анимировали категорию диаграммы.
```php
  # Создать экземпляр класса Presentation, который представляет файл презентации
  $pres = new Presentation("ExistingChart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $pres->save("Sample_Animation_C.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Анимация элемента серии**
Если вы хотите анимировать элементы серии, напишите код согласно шагам, перечисленным ниже:

1. Загрузите презентацию.
1. Получите ссылку на объект диаграммы.
1. Анимируйте элементы серии.
1. Сохраните файл презентации на диск.

В приведённом ниже примере мы анимировали элементы серии.
```php
  # Создать экземпляр класса Presentation, который представляет файл презентации
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Получить ссылку на объект диаграммы
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Анимировать элементы серии
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Сохранить файл презентации на диск
    $pres->save("AnimatingSeriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Анимация элемента категории**
Если вы хотите анимировать элементы категорий, напишите код согласно шагам, перечисленным ниже:

1. Загрузите презентацию.
1. Получите ссылку на объект диаграммы.
1. Анимируйте элементы категорий.
1. Сохраните файл презентации на диск.

В приведённом ниже примере мы анимировали элементы категорий.
```php
  # Создать экземпляр класса Presentation, который представляет файл презентации
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Получить ссылку на объект диаграммы
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Анимировать элементы категорий
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Сохранить файл презентации на диск
    $pres->save("AnimatingCategoriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Поддерживаются ли разные типы эффектов (например, появление, акцент, завершение) для диаграмм, как и для обычных фигур?**

Да. Диаграмма рассматривается как фигура, поэтому она поддерживает стандартные типы анимационных эффектов, включая появление, акцент и завершение, с полным управлением через временную шкалу слайда и последовательности анимаций.

**Могу ли я сочетать анимацию диаграммы с переходами между слайдами?**

Да. [Transitions](/slides/ru/php-java/slide-transition/) применяются к слайду, тогда как анимационные эффекты применяются к объектам на слайде. Вы можете использовать их вместе в одной презентации и управлять ими независимо.

**Сохраняются ли анимации диаграмм при сохранении в PPTX?**

Да. При [save to PPTX](/slides/ru/php-java/save-presentation/) все анимационные эффекты и их порядок сохраняются, поскольку они являются частью родной модели анимации презентации.

**Могу ли я читать существующие анимации диаграмм из презентации и изменять их?**

Да. API предоставляет доступ к временной шкале слайда, последовательностям и эффектам, что позволяет просматривать существующие анимации диаграмм и корректировать их без необходимости воссоздавать всё с нуля.

**Могу ли я создать видео, включающее анимацию диаграмм, с помощью Aspose.Slides?**

Да. Вы можете [export a presentation to video](/slides/ru/php-java/convert-powerpoint-to-video/) с сохранением анимаций, настроив тайминги и другие параметры экспорта, чтобы получившийся клип отражал анимированное воспроизведение.