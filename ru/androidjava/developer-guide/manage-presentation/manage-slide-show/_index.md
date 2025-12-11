---
title: Управление слайд-шоу в Android
linktitle: Слайд-шоу
type: docs
weight: 90
url: /ru/androidjava/manage-slide-show/
keywords:
- тип показа
- представление спикером
- просмотр отдельным пользователем
- просмотр в киоске
- параметры показа
- непрерывное зацикливание
- показ без озвучки
- показ без анимации
- цвет пера
- показ слайдов
- пользовательский показ
- автопереход слайдов
- вручную
- с использованием таймингов
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как управлять слайд-шоу в Aspose.Slides для Android с помощью Java. Легко контролируйте переходы слайдов, тайминги и многое другое в форматах PPT, PPTX и ODP."
---

В Microsoft PowerPoint настройки **Slide Show** являются ключевым инструментом для подготовки и проведения профессиональных презентаций. Одной из самых важных функций в этом разделе является **Set Up Show**, которая позволяет адаптировать вашу презентацию к конкретным условиям и аудитории, обеспечивая гибкость и удобство. С помощью этой функции вы можете выбрать тип показа (например, представление спикером, просмотр отдельным пользователем или просмотр в киоске), включить или отключить зацикливание, выбрать определённые слайды для отображения и использовать тайминги. Этот этап подготовки имеет решающее значение для повышения эффективности и профессионализма вашей презентации.

`getSlideShowSettings` — это метод класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) , который возвращает объект типа [SlideShowSettings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowsettings/), позволяющий управлять настройками слайд-шоу в презентации PowerPoint. В этой статье мы рассмотрим, как использовать этот метод для настройки и управления различными аспектами параметров слайд-шоу. 

## **Выбор типа показа**

`SlideShowSettings.setSlideShowType` определяет тип слайд-шоу, который может быть экземпляром следующих классов: [PresentedBySpeaker](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/androidjava/com.aspose.slides/browsedbyindividual/), или [BrowsedAtKiosk](https://reference.aspose.com/slides/androidjava/com.aspose.slides/browsedatkiosk/). Использование этого метода позволяет адаптировать презентацию под различные сценарии использования, такие как автоматические киоски или ручные презентации.

В следующем примере кода создаётся новая презентация и тип показа устанавливается в «Browsed by an individual» без отображения полосы прокрутки.
```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Включение параметров показа**

`SlideShowSettings.setLoop` определяет, будет ли слайд-шоу повторяться в цикле до ручной остановки. Это полезно для автоматических презентаций, которые должны работать непрерывно. `SlideShowSettings.setShowNarration` определяет, будет ли воспроизводиться голосовое повествование во время слайд-шоу. Это полезно для автоматических презентаций, содержащих голосовое руководство для аудитории. `SlideShowSettings.setShowAnimation` определяет, будут ли воспроизводиться анимации, добавленные к объектам слайдов. Это полезно для полного визуального эффекта презентации.

В следующем примере кода создаётся новая презентация и слайд-шоу зацикливается.
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Выбор слайдов для показа**

`SlideShowSettings.setSlides` позволяет выбрать диапазон слайдов, которые будут показаны во время презентации. Это полезно, когда необходимо показывать только часть презентации, а не все слайды.

В следующем примере кода создаётся новая презентация и устанавливается диапазон слайдов для отображения от слайда `2` до слайда `9`.
```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Использование автоматического перехода слайдов**

`SlideShowSettings.setUseTimings` позволяет включать или отключать использование предустановленных таймингов для каждого слайда. Это полезно для автоматического показа слайдов с заранее заданными длительностями. В приведённом ниже примере кода создаётся новая презентация и отключается использование таймингов.
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Отображение элементов управления медиа**

`SlideShowSettings.setShowMediaControls` определяет, будут ли отображаться элементы управления медиа (например, воспроизведение, пауза и остановка) во время слайд-шоу, когда воспроизводится мультимедийный контент (видео или аудио). Это полезно, если вы хотите предоставить ведущему возможность управлять воспроизведением медиа во время презентации.

В следующем примере кода создаётся новая презентация и включается отображение элементов управления медиа.
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **FAQ**

**Могу ли я сохранить презентацию так, чтобы она открывалась сразу в режиме слайд-шоу?**

Да. Сохраните файл в формате PPSX или PPSM; эти форматы открываются сразу в режиме слайд-шоу в PowerPoint. В Aspose.Slides выберите соответствующий формат сохранения [при экспорте](/slides/ru/androidjava/save-presentation/).

**Могу ли я исключить отдельные слайды из показа, не удаляя их из файла?**

Да. Пометьте слайд как [hidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#setHidden-boolean-). Скрытые слайды остаются в презентации, но не отображаются во время слайд-шоу.

**Может ли Aspose.Slides воспроизводить слайд-шоу или управлять живой презентацией на экране?**

Нет. Aspose.Slides редактирует, анализирует и конвертирует файлы презентаций; фактическое воспроизведение осуществляется приложением‑просмотрщиком, таким как PowerPoint.