---
title: Управление показом слайдов на Android
linktitle: Показ слайдов
type: docs
weight: 90
url: /ru/androidjava/manage-slide-show/
keywords:
- тип показа
- представляемый спикером
- просматриваемый отдельным пользователем
- просмотр в киоске
- параметры показа
- непрерывное зацикливание
- показ без озвучивания
- показ без анимации
- цвет пера
- показывать слайды
- пользовательский показ
- переход к следующему слайду
- вручную
- использование таймингов
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как управлять показами слайдов в Aspose.Slides для Android через Java. Контролируйте переходы слайдов, тайминги и многое другое в форматах PPT, PPTX и ODP с лёгкостью."
---

В Microsoft PowerPoint настройки **Показ слайдов** являются ключевым инструментом для подготовки и проведения профессиональных презентаций. Одной из самых важных функций в этом разделе является **Настройка показа**, которая позволяет адаптировать вашу презентацию к конкретным условиям и аудитории, обеспечивая гибкость и удобство. С помощью этой функции вы можете выбрать тип показа (например, представляемый спикером, просматриваемый отдельным пользователем или в режиме киоска), включать или отключать зацикливание, выбирать отдельные слайды для отображения и использовать тайминги. Этот шаг подготовки имеет решающее значение для повышения эффективности и профессионализма вашей презентации.

`getSlideShowSettings` — это метод класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) , который возвращает объект типа [SlideShowSettings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowsettings/), позволяющий управлять настройками показа слайдов в презентации PowerPoint. В этой статье мы рассмотрим, как использовать этот метод для настройки и контроля различных аспектов настроек показа слайдов. 

## **Выбор типа показа**

`SlideShowSettings.setSlideShowType` определяет тип показа слайдов, который может быть экземпляром следующих классов: [PresentedBySpeaker](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/androidjava/com.aspose.slides/browsedbyindividual/), или [BrowsedAtKiosk](https://reference.aspose.com/slides/androidjava/com.aspose.slides/browsedatkiosk/). Использование этого метода позволяет адаптировать презентацию к различным сценариям использования, таким как автоматизированные киоски или ручные презентации.

Пример кода ниже создает новую презентацию и устанавливает тип показа «Browsed by an individual» без отображения полосы прокрутки.
```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Включить параметры показа**

`SlideShowSettings.setLoop` определяет, будет ли показ слайдов повторяться в цикле до ручной остановки. Это полезно для автоматических презентаций, которые должны работать непрерывно. `SlideShowSettings.setShowNarration` определяет, будет ли воспроизводиться голосовое повествование во время показа слайдов. Это полезно для автоматических презентаций, содержащих голосовые подсказки для аудитории. `SlideShowSettings.setShowAnimation` определяет, будут ли воспроизводиться анимации, добавленные к объектам слайдов. Это полезно для предоставления полного визуального эффекта презентации.

Следующий пример кода создает новую презентацию и зацикливает показ слайдов.
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Выбор слайдов для показа**

`SlideShowSettings.setSlides` метод позволяет выбрать диапазон слайдов, которые будут показаны во время презентации. Это полезно, если необходимо показать только часть презентации, а не все слайды. Следующий пример кода создает новую презентацию и задает диапазон слайдов для отображения от `2` до `9`.
```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Использовать автоматический переход слайдов**

`SlideShowSettings.setUseTimings` метод позволяет включить или отключить использование предустановленных таймингов для каждого слайда. Это полезно для автоматического показа слайдов с заранее определенными длительностями отображения. Пример кода ниже создает новую презентацию и отключает использование таймингов.
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Отображать элементы управления медиа**

`SlideShowSettings.setShowMediaControls` метод определяет, должны ли отображаться элементы управления медиа (например, воспроизведение, пауза и остановка) во время показа слайдов, когда воспроизводится мультимедийный контент (например, видео или аудио). Это полезно, когда вы хотите дать ведущему возможность управлять воспроизведением медиа во время презентации.

Следующий пример кода создает новую презентацию и включает отображение элементов управления медиа.
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Часто задаваемые вопросы**

**Могу ли я сохранить презентацию так, чтобы она открывалась сразу в режиме показа слайдов?**

Да. Сохраните файл в формате PPSX или PPSM; эти форматы запускаются сразу в режиме показа слайдов при открытии в PowerPoint. В Aspose.Slides выберите соответствующий формат сохранения [во время экспорта](/slides/ru/androidjava/save-presentation/).

**Могу ли я исключить отдельные слайды из показа, не удаляя их из файла?**

Да. Отметьте слайд как [скрытый](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#setHidden-boolean-). Скрытые слайды остаются в презентации, но не отображаются во время показа слайдов.

**Может ли Aspose.Slides воспроизводить показ слайдов или управлять живой презентацией на экране?**

Нет. Aspose.Slides редактирует, анализирует и конвертирует файлы презентаций; фактическое воспроизведение осуществляется приложением‑просмотрщиком, таким как PowerPoint.