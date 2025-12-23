---
title: Управление показом слайдов в PHP
linktitle: Показ слайдов
type: docs
weight: 90
url: /ru/php-java/manage-slide-show/
keywords:
- тип показа
- представляемый докладчиком
- просматриваемый отдельным пользователем
- просматриваемый в киоске
- параметры показа
- непрерывное зацикливание
- без озвучки
- без анимации
- цвет пера
- показывать слайды
- пользовательский показ
- автоматический переход
- вручную
- с использованием таймингов
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как управлять показом слайдов в Aspose.Slides для PHP через Java. Управляйте переходами слайдов, таймингами и многим другим в форматах PPT, PPTX и ODP с лёгкостью."
---

В Microsoft PowerPoint параметры **Показ слайдов** являются ключевым инструментом для подготовки и проведения профессиональных презентаций. Одна из самых важных функций в этом разделе — **Настройка показа**, которая позволяет адаптировать вашу презентацию к определённым условиям и аудиториям, обеспечивая гибкость и удобство. С помощью этой функции вы можете выбрать тип показа (например, представляемый докладчиком, просматриваемый отдельным пользователем или просматриваемый в киоске), включить или отключить зацикливание, выбрать определённые слайды для отображения и использовать тайминги. Этот этап подготовки имеет решающее значение для повышения эффективности и профессионализма вашей презентации.

`getSlideShowSettings` — метод класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) , который возвращает объект типа [SlideShowSettings](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowsettings/), позволяющий управлять настройками показа слайдов в презентации PowerPoint. В этой статье мы рассмотрим, как использовать этот метод для настройки и контроля различных аспектов параметров показа слайдов. 

## **Выбор типа показа**

`SlideShowSettings->setSlideShowType` определяет тип показа слайдов, который может быть экземпляром одного из следующих классов: [PresentedBySpeaker](https://reference.aspose.com/slides/php-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/php-java/aspose.slides/browsedbyindividual/), или [BrowsedAtKiosk](https://reference.aspose.com/slides/php-java/aspose.slides/browsedatkiosk/). Использование этого метода позволяет адаптировать презентацию к различным сценариям использования, таким как автоматические киоски или ручные презентации.

Пример кода ниже создаёт новую презентацию и устанавливает тип показа «Browsed by an individual» без отображения полосы прокрутки.
```php
$presentation = new Presentation();

$showType = new BrowsedByIndividual();
$showType->setShowScrollbar(false);

$presentation->getSlideShowSettings()->setSlideShowType($showType);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Включение параметров показа**

`SlideShowSettings->setLoop` определяет, будет ли показ слайдов повторяться в цикле до ручной остановки. Это полезно для автоматических презентаций, которые должны работать непрерывно. `SlideShowSettings->setShowNarration` определяет, будет ли воспроизводиться голосовое озвучивание во время показа слайдов. Это полезно для автоматических презентаций, содержащих голосовые подсказки для аудитории. `SlideShowSettings->setShowAnimation` определяет, будут ли воспроизводиться анимации, добавленные к объектам слайдов. Это полезно для предоставления полного визуального эффекта презентации.

Следующий пример кода создаёт новую презентацию и зацикливает показ слайдов.
```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setLoop(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Выбор слайдов для отображения**

`SlideShowSettings->setSlides` метод позволяет выбрать диапазон слайдов, которые будут показаны во время презентации. Это полезно, когда необходимо отобразить только часть презентации, а не все слайды. Следующий пример кода создаёт новую презентацию и задаёт диапазон слайдов для отображения от слайда `2` до `9`.
```php
$presentation = new Presentation();

$slideRange = new SlidesRange();
$slideRange->setStart(2);
$slideRange->setEnd(9);

$presentation->getSlideShowSettings()->setSlides($slideRange);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Использовать автоматический переход**

`SlideShowSettings->setUseTimings` метод позволяет включить или отключить использование предустановленных таймингов для каждого слайда. Это полезно для автоматического показа слайдов с заранее определённой длительностью отображения. Пример кода ниже создаёт новую презентацию и отключает использование таймингов.
```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setUseTimings(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Отображение медиа‑контролов**

`SlideShowSettings->setShowMediaControls` метод определяет, должны ли отображаться медиа‑контролы (например, воспроизведение, пауза и остановка) во время показа слайдов при воспроизведении мультимедийного контента (например, видео или аудио). Это полезно, когда нужно предоставить ведущему возможность управлять воспроизведением медиа во время презентации.

Следующий пример кода создаёт новую презентацию и включает отображение медиа‑контролов.
```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setShowMediaControls(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **FAQ**

**Можно ли сохранить презентацию так, чтобы она открывалась сразу в режиме показа слайдов?**

Да. Сохраните файл в формате PPSX или PPSM; эти форматы открываются сразу в режиме показа слайдов в PowerPoint. В Aspose.Slides выберите соответствующий формат сохранения [during export](/slides/ru/php-java/save-presentation/).

**Можно ли исключить отдельные слайды из показа, не удаляя их из файла?**

Да. Отметьте слайд как [hidden](https://reference.aspose.com/slides/php-java/aspose.slides/slide/sethidden/). Скрытые слайды остаются в презентации, но не отображаются во время показа слайдов.

**Может ли Aspose.Slides воспроизводить показ слайдов или управлять живой презентацией на экране?**

Нет. Aspose.Slides редактирует, анализирует и преобразует файлы презентаций; фактическое воспроизведение осуществляется приложением‑просмотрщиком, таким как PowerPoint.