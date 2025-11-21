---
title: Управление показом слайдов в .NET
linktitle: Показ слайдов
type: docs
weight: 90
url: /ru/net/manage-slide-show/
keywords:
- тип показа
- представлено спикером
- просмотрено отдельным пользователем
- просмотр в киоске
- параметры показа
- непрерывно зацикливать
- показ без диктовки
- показ без анимации
- цвет пера
- показать слайды
- пользовательский показ
- перемещение слайдов
- вручную
- использование таймингов
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как управлять показами слайдов в Aspose.Slides для .NET. Контролируйте переходы слайдов, тайминги и многое другое в форматах PPT, PPTX и ODP с лёгкостью."
---

В Microsoft PowerPoint настройки **Slide Show** являются ключевым инструментом для подготовки и проведения профессиональных презентаций. Одна из важнейших функций в этом разделе — **Set Up Show**, которая позволяет адаптировать презентацию под конкретные условия и аудиторию, обеспечивая гибкость и удобство. С её помощью можно выбрать тип показа (например, представление спикером, просмотр отдельным пользователем или просмотр в режиме киоска), включать или отключать повторение, выбирать определённые слайды для отображения и использовать тайминги. Этот этап подготовки критически важен для повышения эффективности и профессионализма вашей презентации.

`SlideShowSettings` — свойство класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), типа [SlideShowSettings](https://reference.aspose.com/slides/net/aspose.slides/presentation/slideshowsettings/), которое позволяет управлять настройками показа в презентации PowerPoint. В этой статье мы рассмотрим, как использовать это свойство для конфигурирования и контроля различных аспектов настроек показа.

## **Выбор типа показа**

`SlideShowSettings.SlideShowType` определяет тип показа, который может быть экземпляром одного из следующих классов: [PresentedBySpeaker](https://reference.aspose.com/slides/net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/net/aspose.slides/browsedbyindividual/), или [BrowsedAtKiosk](https://reference.aspose.com/slides/net/aspose.slides/browsedatkiosk/). Используя это свойство, вы можете адаптировать презентацию для разных сценариев использования, таких как автоматические киоски или ручные презентации.

В примере кода ниже создаётся новая презентация и устанавливается тип показа «Browsed by an individual» без отображения полосы прокрутки.
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

`SlideShowSettings.Loop` определяет, будет ли показ повторяться в цикле до ручной остановки. Это полезно для автоматических презентаций, которые должны работать непрерывно. `SlideShowSettings.ShowNarration` определяет, будет ли воспроизводиться голосовое сопровождение во время показа. Это полезно для автоматических презентаций, содержащих аудиогид для аудитории. `SlideShowSettings.ShowAnimation` определяет, будут ли воспроизводиться анимации, добавленные к объектам слайдов. Это полезно для полного визуального эффекта презентации.

В следующем примере кода создаётся новая презентация и включается повторение показа.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Выбор слайдов для показа**

Свойство `SlideShowSettings.Slides` позволяет выбрать диапазон слайдов, которые будут показаны во время презентации. Это полезно, когда необходимо показать только часть презентации, а не все слайды. В примере кода ниже создаётся новая презентация и задаётся диапазон слайдов от `2` до `9`.
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


## **Использовать автопереходы**

Свойство `SlideShowSettings.UseTimings` позволяет включать или отключать использование предустановленных таймингов для каждого слайда. Это полезно для автоматического отображения слайдов с заранее определёнными длительностями. В примере кода ниже создаётся новая презентация и отключается использование таймингов.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Показ элементов управления медиа**

Свойство `SlideShowSettings.ShowMediaControls` определяет, будут ли отображаться элементы управления медиа (например, воспроизведение, пауза и остановка) во время показа, когда воспроизводится мультимедийный контент (видео или аудио). Это полезно, когда требуется предоставить ведущему контроль над воспроизведением медиа во время презентации.

В следующем примере кода создаётся новая презентация и включается отображение элементов управления медиа.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Можно ли сохранить презентацию так, чтобы она открывалась напрямую в режиме показа?**

Да. Сохраните файл в формате PPSX или PPSM; эти форматы запускаются напрямую в режиме показа при открытии в PowerPoint. В Aspose.Slides выберите соответствующий формат сохранения [during export](/slides/ru/net/save-presentation/).

**Можно ли исключить отдельные слайды из показа, не удаляя их из файла?**

Да. Отметьте слайд как [Hidden](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/). Скрытые слайды остаются в презентации, но не отображаются во время показа.

**Может ли Aspose.Slides воспроизводить показ или управлять живой презентацией на экране?**

Нет. Aspose.Slides редактирует, анализирует и конвертирует файлы презентаций; фактическое воспроизведение обрабатывается приложением‑просмотрщиком, таким как PowerPoint.