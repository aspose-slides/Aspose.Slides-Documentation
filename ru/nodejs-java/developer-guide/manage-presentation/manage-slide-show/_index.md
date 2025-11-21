---
title: Управление слайд‑шоу
type: docs
weight: 90
url: /ru/nodejs-java/manage-slide-show/
keywords:
- тип показа
- представляемый докладчиком
- просматриваемый отдельным пользователем
- просматриваемый в киоске
- параметры показа
- непрерывный цикл
- без озвучки
- без анимации
- цвет пера
- показывать слайды
- пользовательский показ
- переход к следующему слайду
- вручную
- с использованием таймингов
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides для Node.js через Java
description: "Управляйте параметрами слайд‑шоу в презентациях PowerPoint с помощью JavaScript"
---

В Microsoft PowerPoint настройки **Слайд‑шоу** являются ключевым инструментом для подготовки и проведения профессиональных презентаций. Одной из важнейших функций в этом разделе является **Set Up Show**, которая позволяет адаптировать вашу презентацию к конкретным условиям и аудиториям, обеспечивая гибкость и удобство. С помощью этой функции можно выбрать тип показа (например, представляемый докладчиком, просматриваемый отдельным пользователем или в режиме киоска), включить или отключить повтор, выбрать определённые слайды для отображения и задать тайм‑инг. Этот этап подготовки имеет решающее значение для повышения эффективности и профессионализма вашей презентации.

`getSlideShowSettings` — метод класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), который возвращает объект типа [SlideShowSettings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowsettings/), позволяющий управлять параметрами слайд‑шоу в презентации PowerPoint. В этой статье мы рассмотрим, как использовать этот метод для настройки и контроля различных аспектов параметров слайд‑шоу. 

## **Выбор типа показа**

`SlideShowSettings.setSlideShowType` определяет тип слайд‑шоу, который может быть экземпляром одной из следующих классов: [PresentedBySpeaker](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/nodejs-java/aspose.slides/browsedbyindividual/), или [BrowsedAtKiosk](https://reference.aspose.com/slides/nodejs-java/aspose.slides/browsedatkiosk/). Использование этого метода позволяет адаптировать презентацию под различные сценарии использования, такие как автоматизированные киоски или ручные показы.

Ниже приведён пример кода, который создаёт новую презентацию и устанавливает тип показа «Browsed by an individual» без отображения полосы прокрутки.
```js
var presentation = new asposeSlides.Presentation();

var showType = new asposeSlides.BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Включение параметров показа**

`SlideShowSettings.setLoop` определяет, должна ли презентация повторяться в цикле до её ручного завершения. Это полезно для автоматизированных показов, которые должны работать непрерывно. `SlideShowSettings.setShowNarration` определяет, будет ли воспроизводиться голосовое озвучивание во время слайд‑шоу. Это удобно для автоматических презентаций, содержащих голосовые подсказки для аудитории. `SlideShowSettings.setShowAnimation` определяет, будут ли воспроизводиться анимации, добавленные к объектам слайдов. Это полезно для полного визуального эффекта презентации.

Следующий пример кода создаёт новую презентацию и включаёт зацикливание слайд‑шоу.
```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Выбор слайдов для показа**

Метод `SlideShowSettings.setSlides` позволяет выбрать диапазон слайдов, которые будут показаны во время презентации. Это удобно, когда необходимо отобразить только часть презентации, а не все слайды. Ниже приведён пример кода, который создаёт новую презентацию и задаёт диапазон слайдов от `2` до `9`.
```js
var presentation = new asposeSlides.Presentation();

var slideRange = new asposeSlides.SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Использование таймингов слайдов**

Метод `SlideShowSettings.setUseTimings` позволяет включить или отключить использование предустановленных таймингов для каждого слайда. Это полезно для автоматического показа слайдов с заранее заданными длительностями отображения. Пример кода ниже создаёт новую презентацию и отключает использование таймингов.
```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Отображение медиа‑контролов**

Метод `SlideShowSettings.setShowMediaControls` определяет, должны ли отображаться медиа‑контролы (например, воспроизведение, пауза и остановка) во время слайд‑шоу, когда воспроизводится мультимедийный контент (видео или аудио). Это полезно, если необходимо предоставить докладчику возможность управлять воспроизведением медиа во время презентации.

Следующий пример кода создаёт новую презентацию и включает отображение медиа‑контролов.
```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **FAQ**

**Можно ли сохранить презентацию так, чтобы она открывалась сразу в режиме слайд‑шоу?**

Да. Сохраните файл в формате PPSX или PPSM; эти форматы открываются непосредственно в режиме слайд‑шоу в PowerPoint. В Aspose.Slides выберите соответствующий формат сохранения [во время экспорта](/slides/ru/nodejs-java/save-presentation/).

**Можно ли исключить отдельные слайды из показа, не удаляя их из файла?**

Да. Пометьте слайд как [hidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/sethidden/). Скрытые слайды остаются в презентации, но не отображаются во время слайд‑шоу.

**Может ли Aspose.Slides воспроизводить слайд‑шоу или управлять живой презентацией на экране?**

Нет. Aspose.Slides редактирует, анализирует и конвертирует файлы презентаций; фактическое воспроизведение осуществляется в приложении‑просмотрщике, например PowerPoint.