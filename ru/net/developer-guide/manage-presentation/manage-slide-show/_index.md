---
title: Управление показом слайдов
type: docs
weight: 90
url: /ru/net/manage-slide-show/
keywords:
- тип показа
- представляется докладчиком
- просматривается отдельным пользователем
- просматривается в киоске
- параметры показа
- непрерывное зацикливание
- показ без озвучивания
- показ без анимации
- цвет пера
- показывать слайды
- пользовательский показ
- переключать слайды
- вручную
- с использованием таймингов
- PowerPoint
- презентация
- C#
- .NET
- Aspose.Slides for .NET
description: "Управление настройками показа слайдов в презентациях PowerPoint с использованием C#"
---

В Microsoft PowerPoint параметры **Slide Show** являются ключевым инструментом для подготовки и проведения профессиональных презентаций. Одной из самых важных функций в этом разделе является **Set Up Show**, позволяющая адаптировать презентацию к конкретным условиям и аудиториям, обеспечивая гибкость и удобство. С помощью этой функции вы можете выбрать тип показа (например, представляемый докладчиком, просматриваемый отдельным лицом или в киоске), включать или отключать зацикливание, выбирать определённые слайды для отображения и использовать тайминги. Этот шаг подготовки имеет решающее значение для повышения эффективности и профессионализма вашей презентации.

`SlideShowSettings` — это свойство класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), типа [SlideShowSettings](https://reference.aspose.com/slides/net/aspose.slides/presentation/slideshowsettings/), которое позволяет управлять параметрами показа в презентации PowerPoint. В этой статье мы рассмотрим, как использовать это свойство для настройки и контроля различных аспектов параметров показа. 

## **Выбор типа показа**

`SlideShowSettings.SlideShowType` определяет тип показа, который может быть экземпляром одной из следующих классов: [PresentedBySpeaker](https://reference.aspose.com/slides/net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/net/aspose.slides/browsedbyindividual/), или [BrowsedAtKiosk](https://reference.aspose.com/slides/net/aspose.slides/browsedatkiosk/). Использование этого свойства позволяет адаптировать презентацию к различным сценариям использования, таким как автоматические киоски или ручные презентации.

Ниже приведён пример кода, который создаёт новую презентацию и устанавливает тип показа «Browsed by an individual» без отображения полосы прокрутки.
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

`SlideShowSettings.Loop` определяет, должен ли показ повторяться в цикле до ручной остановки. Это полезно для автоматических презентаций, которые должны работать непрерывно. `SlideShowSettings.ShowNarration` определяет, следует ли воспроизводить голосовые комментарии во время показа. Это полезно для автоматических презентаций, содержащих голосовые подсказки для аудитории. `SlideShowSettings.ShowAnimation` определяет, должны ли воспроизводиться анимации, добавленные к объектам слайда. Это полезно для предоставления полного визуального эффекта презентации.

В следующем примере кода создаётся новая презентация и включается зацикливание показа.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Выбор слайдов для отображения**

Свойство `SlideShowSettings.Slides` позволяет выбрать диапазон слайдов, которые будут показаны во время презентации. Это полезно, когда нужно показать только часть презентации, а не все слайды. В следующем примере кода создаётся новая презентация и задаётся диапазон слайдов для отображения от слайда `2` до `9`.
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


## **Использование таймингов слайдов**

Свойство `SlideShowSettings.UseTimings` позволяет включать или отключать использование заранее заданных таймингов для каждого слайда. Это полезно для автоматического отображения слайдов с предопределённой продолжительностью. Пример кода ниже создаёт новую презентацию и отключает использование таймингов.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Отображение медиаконтролов**

Свойство `SlideShowSettings.ShowMediaControls` определяет, следует ли отображать медиаконтролы (например, воспроизведение, паузу и остановку) во время показа, когда воспроизводится мультимедийный контент (видео или аудио). Это полезно, когда требуется предоставить ведущему контроль над воспроизведением медиа во время презентации.

В следующем примере кода создаётся новая презентация и включается отображение медиаконтролов.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Можно ли сохранить презентацию так, чтобы она открывалась сразу в режиме показа?**

Да. Сохраните файл в формате PPSX или PPSM; эти форматы запускаются сразу в режиме показа при открытии в PowerPoint. В Aspose.Slides выберите соответствующий формат сохранения [during export](/slides/ru/net/save-presentation/).

**Можно ли исключить отдельные слайды из показа, не удаляя их из файла?**

Да. Отметьте слайд как [Hidden](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/). Скрытые слайды остаются в презентации, но не отображаются во время показа.

**Может ли Aspose.Slides воспроизводить показ или управлять живой презентацией на экране?**

Нет. Aspose.Slides редактирует, анализирует и конвертирует файлы презентаций; фактическое воспроизведение осуществляется приложением‑просмотрщиком, таким как PowerPoint.