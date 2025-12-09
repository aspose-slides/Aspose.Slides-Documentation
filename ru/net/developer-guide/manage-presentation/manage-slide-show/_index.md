---
title: Управление показом слайдов в .NET
linktitle: Слайд-шоу
type: docs
weight: 90
url: /ru/net/manage-slide-show/
keywords:
- тип показа
- представлено спикером
- просмотр отдельным пользователем
- просмотр в киоске
- параметры показа
- непрерывное зацикливание
- показ без озвучки
- показ без анимации
- цвет пера
- показывать слайды
- пользовательский показ
- перемотка слайдов
- вручную
- использование таймингов
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как управлять показами слайдов в Aspose.Slides для .NET. Контролируйте переходы слайдов, тайминги и многое другое в форматах PPT, PPTX и ODP с легкостью."
---

В Microsoft PowerPoint параметры **Slide Show** являются ключевым инструментом для подготовки и проведения профессиональных презентаций. Одной из важнейших функций в этом разделе является **Set Up Show**, позволяющая адаптировать презентацию под конкретные условия и аудиторию, обеспечивая гибкость и удобство. С помощью этой функции вы можете выбрать тип показа (например, представление спикером, просмотр отдельным пользователем или просмотр в режиме киоска), включить или отключить зацикливание, выбрать конкретные слайды для отображения и использовать тайминги. Этот шаг подготовки имеет решающее значение для повышения эффективности и профессионализма вашей презентации.

`SlideShowSettings` — это свойство класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), типа [SlideShowSettings](https://reference.aspose.com/slides/net/aspose.slides/presentation/slideshowsettings/), которое позволяет управлять настройками показа слайдов в презентации PowerPoint. В этой статье мы рассмотрим, как использовать это свойство для настройки и управления различными аспектами параметров показа слайдов. 

## **Выбор типа показа**

`SlideShowSettings.SlideShowType` определяет тип показа слайдов, который может быть экземпляром одной из следующих классов: [PresentedBySpeaker](https://reference.aspose.com/slides/net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/net/aspose.slides/browsedbyindividual/), или [BrowsedAtKiosk](https://reference.aspose.com/slides/net/aspose.slides/browsedatkiosk/). Использование этого свойства позволяет адаптировать презентацию к различным сценариям использования, таким как автоматические киоски или ручные презентации.

Пример кода ниже создает новую презентацию и устанавливает тип показа "Browsed by an individual" без отображения полосы прокрутки.
```cs
using var presentation = new Presentation();

var showType = new BrowsedByIndividual
{
    ShowScrollbar = false
};

presentation.SlideShowSettings.SlideShowType = showType;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Включение параметров показа**

`SlideShowSettings.Loop` определяет, будет ли показ слайдов повторяться в цикле до ручной остановки. Это полезно для автоматических презентаций, которые должны работать непрерывно. `SlideShowSettings.ShowNarration` определяет, будут ли воспроизводиться голосовые комментарии во время показа слайдов. Это полезно для автоматических презентаций, содержащих голосовое сопровождение для аудитории. `SlideShowSettings.ShowAnimation` определяет, будут ли воспроизводиться анимации, добавленные к объектам слайдов. Это необходимо для обеспечения полного визуального эффекта презентации.

В следующем примере кода создается новая презентация и включается зацикливание показа слайдов.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Выбор слайдов для показа**

Свойство `SlideShowSettings.Slides` позволяет выбрать диапазон слайдов, которые будут показываться во время презентации. Это полезно, когда необходимо показать только часть презентации, а не все слайды. В следующем примере кода создается новая презентация и задаётся диапазон слайдов для отображения с `2` по `9`.
```cs
using var presentation = new Presentation();

var slideRange = new SlidesRange 
{
    Start = 2,
    End = 9
};

presentation.SlideShowSettings.Slides = slideRange;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Использовать автоматический переход слайдов**

Свойство `SlideShowSettings.UseTimings` позволяет включать или отключать использование предустановленных таймингов для каждого слайда. Это полезно для автоматического показа слайдов с заранее заданными продолжительностями. В приведённом ниже примере кода создается новая презентация и отключается использование таймингов.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Отображение медиа‑элементов управления**

Свойство `SlideShowSettings.ShowMediaControls` определяет, должны ли отображаться элементы управления медиа (например, воспроизведение, пауза и остановка) во время показа слайдов, когда воспроизводится мультимедийный контент (например, видео или аудио). Это полезно, когда необходимо предоставить ведущему возможность управлять воспроизведением медиа во время презентации.

В следующем примере кода создается новая презентация и включается отображение элементов управления медиа.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Can I save a presentation so it opens directly in slide show mode?**

Да. Сохраните файл в формате PPSX или PPSM; эти форматы открываются сразу в режиме показа слайдов в PowerPoint. В Aspose.Slides выберите соответствующий формат сохранения [при экспорте](/slides/ru/net/save-presentation/).

**Can I exclude individual slides from the show without deleting them from the file?**

Да. Пометьте слайд как [Hidden](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/). Скрытые слайды остаются в презентации, но не отображаются во время показа слайдов.

**Can Aspose.Slides play a slide show or control a live presentation on screen?**

Нет. Aspose.Slides редактирует, анализирует и преобразует файлы презентаций; фактическое воспроизведение осуществляется приложением‑просмотрщиком, например PowerPoint.