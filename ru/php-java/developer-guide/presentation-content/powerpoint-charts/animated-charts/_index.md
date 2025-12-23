---
title: Анимация диаграмм PowerPoint в PHP
linktitle: Анимированные диаграммы
type: docs
weight: 80
url: /ru/php-java/animated-charts/
keywords:
- диаграмма
- анимированная диаграмма
- анимация диаграммы
- ряд диаграммы
- категория диаграммы
- элемент ряда
- элемент категории
- добавить эффект
- тип эффекта
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Создайте впечатляющие анимированные диаграммы с помощью Aspose.Slides for PHP via Java. Улучшите презентации динамичными визуальными элементами в файлах PPT и PPTX — начните сейчас."
---

{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java поддерживает анимацию элементов диаграммы. **Series**, **Categories**, **Series Elements**, **Categories Elements** могут быть анимированы с помощью метода [**ISequence**.**addEffect**](https://reference.aspose.com/slides/php-java/aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) и двух перечислений [**EffectChartMajorGroupingType**](https://reference.aspose.com/slides/php-java/aspose.slides/EffectChartMajorGroupingType) и [**EffectChartMinorGroupingType**](https://reference.aspose.com/slides/php-java/aspose.slides/EffectChartMinorGroupingType).

{{% /alert %}} 

## **Анимация рядов диаграммы**
Если вы хотите анимировать ряд диаграммы, напишите код согласно перечисленным ниже шагам:

1. Загрузите презентацию.
1. Получите ссылку на объект диаграммы.
1. Анимируйте ряд.
1. Запишите файл презентации на диск.

В приведённом ниже примере мы анимировали ряды диаграммы.
```php
  # Создать экземпляр класса Presentation, представляющего файл презентации
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Получить ссылку на объект диаграммы
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Анимировать ряд
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
Если вы хотите анимировать категории диаграммы, напишите код согласно перечисленным ниже шагам:

1. Загрузите презентацию.
1. Получите ссылку на объект диаграммы.
1. Анимируйте категорию.
1. Запишите файл презентации на диск.

В приведённом ниже примере мы анимировали категории диаграммы.
```php
  # Создать экземпляр класса Presentation, представляющего файл презентации
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


## **Анимация элемента ряда**
Если вы хотите анимировать элементы рядов, напишите код согласно перечисленным ниже шагам:

1. Загрузите презентацию.
1. Получите ссылку на объект диаграммы.
1. Анимируйте элементы рядов.
1. Запишите файл презентации на диск.

В приведённом ниже примере мы анимировали элементы рядов.
```php
  # Создать экземпляр класса Presentation, представляющего файл презентации
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
Если вы хотите анимировать элементы категорий, напишите код согласно перечисленным ниже шагам:

1. Загрузите презентацию.
1. Получите ссылку на объект диаграммы.
1. Анимируйте элементы категорий.
1. Запишите файл презентации на диск.

В приведённом ниже примере мы анимировали элементы категорий.
```php
  # Создать экземпляр класса Presentation, представляющего файл презентации
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


## **Вопросы и ответы**

**Поддерживаются ли разные типы эффектов (например, появление, акцент, завершение) для диаграмм так же, как для обычных фигур?**  
Да. Диаграмма рассматривается как фигура, поэтому она поддерживает стандартные типы анимационных эффектов, включая появление, акцент и завершение, с полным управлением через временную шкалу слайда и последовательности анимаций.

**Можно ли комбинировать анимацию диаграммы с переходами слайдов?**  
Да. [Transitions](/slides/ru/php-java/slide-transition/) применяются к слайду, тогда как анимационные эффекты — к объектам на слайде. Вы можете использовать их одновременно в одной презентации и управлять ими независимо.

**Сохраняются ли анимации диаграмм при сохранении в PPTX?**  
Да. При [сохранении в PPTX](/slides/ru/php-java/save-presentation/) все анимационные эффекты и их порядок сохраняются, так как они являются частью родной модели анимации презентации.

**Можно ли читать существующие анимации диаграмм из презентации и изменять их?**  
Да. API предоставляет доступ к временной шкале слайда, последовательностям и эффектам, позволяя просматривать существующие анимации диаграмм и корректировать их без полного пересоздания.

**Можно ли создать видео, включающее анимацию диаграмм, с помощью Aspose.Slides?**  
Да. Вы можете [экспортировать презентацию в видео](/slides/ru/php-java/convert-powerpoint-to-video/), сохраняя анимацию, настраивая тайминги и другие параметры экспорта, чтобы полученный видеоклип отражал анимированное воспроизведение.