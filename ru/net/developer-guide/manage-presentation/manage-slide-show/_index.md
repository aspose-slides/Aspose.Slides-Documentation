---
title: Управление показом слайдов в .NET
linktitle: Показ слайдов
type: docs
weight: 90
url: /ru/net/manage-slide-show/
keywords:
- тип показа
- представляет докладчиком
- просматривается отдельным пользователем
- просматривается в режиме киоска
- параметры показа
- непрерывное зацикливание
- показ без озвучивания
- показ без анимации
- цвет пера
- показ слайдов
- пользовательский показ
- автоматический переход
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

В Microsoft PowerPoint параметры **Slide Show** являются ключевым инструментом для подготовки и проведения профессиональных презентаций. Одной из самых важных функций в этом разделе является **Set Up Show**, которая позволяет адаптировать вашу презентацию к конкретным условиям и аудиториям, обеспечивая гибкость и удобство. С помощью этой функции вы можете выбрать тип показа (например, представляемый докладчиком, просматриваемый отдельным пользователем или в режиме киоска), включить или отключить зацикливание, выбрать определённые слайды для отображения и задать тайминги. Этот этап подготовки имеет решающее значение для повышения эффективности и профессионализма вашей презентации.

`SlideShowSettings` — свойство класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) типа [SlideShowSettings](https://reference.aspose.com/slides/net/aspose.slides/presentation/slideshowsettings/), позволяющее управлять параметрами показа в презентации PowerPoint. В этой статье мы рассмотрим, как использовать это свойство для настройки и контроля различных аспектов параметров показа. 

## **Выберите тип показа**

`SlideShowSettings.SlideShowType` определяет тип показа, который может быть экземпляром следующих классов: [PresentedBySpeaker](https://reference.aspose.com/slides/net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/net/aspose.slides/browsedbyindividual/) или [BrowsedAtKiosk](https://reference.aspose.com/slides/net/aspose.slides/browsedatkiosk/). Использование этого свойства позволяет адаптировать презентацию под разные сценарии использования, такие как автоматические киоски или ручные презентации.

Ниже приведён пример кода, создающий новую презентацию и устанавливающий тип показа «Browsed by an individual» без отображения полосы прокрутки.
```cs
using var presentation = new Presentation();

var showType = new BrowsedByIndividual
{
    ShowScrollbar = false
};

presentation.SlideShowSettings.SlideShowType = showType;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Включить параметры показа**

`SlideShowSettings.Loop` определяет, будет ли показ повторяться в бесконечном цикле до его ручного прекращения. Это полезно для автоматических презентаций, которые должны работать непрерывно. `SlideShowSettings.ShowNarration` определяет, будет ли воспроизводиться голосовое озвучивание во время показа. Это полезно для автоматических презентаций, содержащих голосовые подсказки для аудитории. `SlideShowSettings.ShowAnimation` определяет, будут ли воспроизводиться анимации, добавленные к объектам слайдов. Это полезно для полного визуального восприятия презентации.

Следующий пример кода создаёт новую презентацию и зацикливает показ.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Выберите слайды для показа**

Свойство `SlideShowSettings.Slides` позволяет выбрать диапазон слайдов, которые будут показываться во время презентации. Это удобно, когда нужно показывать только часть презентации, а не все слайды. Ниже приведён пример кода, создающий новую презентацию и задающий диапазон слайдов от `2` до `9`.
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


## **Использовать автоматический переход**

Свойство `SlideShowSettings.UseTimings` позволяет включать или отключать использование предустановленных таймингов для каждого слайда. Это полезно для автоматического показа слайдов с заранее заданной длительностью отображения. Пример кода ниже создаёт новую презентацию и отключает использование таймингов.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Отображать элементы управления медиа**

Свойство `SlideShowSettings.ShowMediaControls` определяет, будут ли отображаться элементы управления медиа (например, воспроизведение, пауза и остановка) во время показа, когда воспроизводится мультимедийный контент (например, видео или аудио). Это полезно, если вы хотите предоставить презентеру возможность управлять воспроизведением медиа во время презентации.

Следующий пример кода создаёт новую презентацию и включает отображение элементов управления медиа.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Вопросы и ответы**

**Могу ли я сохранить презентацию так, чтобы она открывалась сразу в режиме показа?**

Да. Сохраните файл в формате PPSX или PPSM; эти форматы открываются напрямую в режиме показа в PowerPoint. В Aspose.Slides выберите соответствующий формат сохранения [во время экспорта](/slides/ru/net/save-presentation/).

**Могу ли я исключить отдельные слайды из показа, не удаляя их из файла?**

Да. Пометьте слайд как [Hidden](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/). Скрытые слайды остаются в презентации, но не отображаются во время показа.

**Может ли Aspose.Slides воспроизводить показ или управлять живой презентацией на экране?**

Нет. Aspose.Slides редактирует, анализирует и конвертирует файлы презентаций; фактическое воспроизведение осуществляется приложением‑просмотрщиком, таким как PowerPoint.