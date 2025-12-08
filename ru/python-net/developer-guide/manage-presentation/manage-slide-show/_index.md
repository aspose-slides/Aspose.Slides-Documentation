---
title: Управление показом слайдов в Python
linktitle: Показ слайдов
type: docs
weight: 90
url: /ru/python-net/manage-slide-show/
keywords:
- тип показа
- представляется спикером
- просмотр отдельным пользователем
- просмотр в киоске
- параметры показа
- зацикливание
- показ без озвучивания
- показ без анимации
- цвет ручки
- показ слайдов
- пользовательский показ
- продвижение слайдов
- вручную
- с использованием таймингов
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как управлять показами слайдов в Aspose.Slides для Python через .NET. Контролируйте переходы слайдов, тайминги и многое другое для форматов PPT, PPTX и ODP с легкостью."
---

В Microsoft PowerPoint параметры **Slide Show** являются ключевым инструментом для подготовки и проведения профессиональных презентаций. Одной из самых важных функций в этом разделе является **Set Up Show**, которая позволяет адаптировать презентацию к конкретным условиям и аудитории, обеспечивая гибкость и удобство. С помощью этой функции вы можете выбрать тип показа (например, представление спикером, просмотр отдельным пользователем или просмотр в режиме киоска), включать или отключать зацикливание, выбирать отдельные слайды для отображения и использовать тайминги. Этот этап подготовки имеет решающее значение для повышения эффективности и профессионализма вашей презентации.

`slide_show_settings` является свойством класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) типа [SlideShowSettings](https://reference.aspose.com/slides/python-net/aspose.slides/slideshowsettings/), которое позволяет управлять настройками показа слайдов в презентации PowerPoint. В этой статье мы рассмотрим, как использовать это свойство для настройки и управления различными аспектами параметров показа слайдов. 

## **Выбор типа показа**

`SlideShowSettings.slide_show_type` определяет тип показа слайдов, который может быть экземпляром одной из следующих классов: [PresentedBySpeaker](https://reference.aspose.com/slides/python-net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/python-net/aspose.slides/browsedbyindividual/), или [BrowsedAtKiosk](https://reference.aspose.com/slides/python-net/aspose.slides/browsedatkiosk/). Использование этого свойства позволяет адаптировать презентацию под различные сценарии использования, такие как автоматические киоски или ручные презентации.

Пример кода ниже создает новую презентацию и устанавливает тип показа «Browsed by an individual» без отображения полосы прокрутки.
```py
with slides.Presentation() as presentation:

    show_type = slides.BrowsedByIndividual()
    show_type.show_scrollbar = False

    presentation.slide_show_settings.slide_show_type = show_type

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Включение параметров показа**

`SlideShowSettings.loop` определяет, будет ли показ слайдов повторяться в цикле до ручной остановки. Это полезно для автоматических презентаций, которые должны работать непрерывно. `SlideShowSettings.show_narration` определяет, будут ли воспроизводиться голосовые комментарии во время показа слайдов. Это полезно для автоматических презентаций, содержащих голосовые подсказки для аудитории. `SlideShowSettings.show_animation` определяет, будут ли воспроизводиться анимации, добавленные к объектам слайдов. Это полезно для обеспечения полного визуального эффекта презентации.

В следующем примере кода создается новая презентация и включается зацикливание показа слайдов.
```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.loop = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Выбор слайдов для показа**

`SlideShowSettings.slides` свойство позволяет выбрать диапазон слайдов, которые будут показаны во время презентации. Это полезно, когда необходимо показать только часть презентации, а не все слайды. В следующем примере кода создается новая презентация и задается диапазон слайдов для отображения от слайда `2` до `9`.
```py
with slides.Presentation() as presentation:
    
    slide_range = slides.SlidesRange()
    slide_range.start = 2
    slide_range.end = 9

    presentation.slide_show_settings.slides = slide_range

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Использование автоматического продвижения слайдов**

`SlideShowSettings.use_timings` свойство позволяет включать или отключать использование предустановленных таймингов для каждого слайда. Это полезно для автоматического показа слайдов с заранее определёнными длительностями отображения. В приведённом ниже примере кода создается новая презентация и отключается использование таймингов.
```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.use_timings = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Отображение элементов управления медиа**

`SlideShowSettings.show_media_controls` свойство определяет, должны ли отображаться элементы управления медиа (например, воспроизведение, пауза и остановка) во время показа слайдов, когда воспроизводится мультимедийный контент (например, видео или аудио). Это полезно, когда необходимо предоставить ведущему возможность управлять воспроизведением медиа во время презентации.

В следующем примере кода создается новая презентация и включается отображение элементов управления медиа.
```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.show_media_controls = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Можно ли сохранить презентацию так, чтобы она открывалась сразу в режиме показа слайдов?**

Да. Сохраните файл в формате PPSX или PPSM; эти форматы открываются напрямую в режиме показа слайдов при открытии в PowerPoint. В Aspose.Slides выберите соответствующий формат сохранения [при экспорте](/slides/ru/python-net/save-presentation/).

**Можно ли исключить отдельные слайды из показа, не удаляя их из файла?**

Да. Отметьте слайд как [скрытый](https://reference.aspose.com/slides/python-net/aspose.slides/slide/hidden/). Скрытые слайды остаются в презентации, но не отображаются во время показа.

**Может ли Aspose.Slides воспроизводить показ слайдов или управлять живой презентацией на экране?**

Нет. Aspose.Slides редактирует, анализирует и конвертирует файлы презентаций; фактическое воспроизведение осуществляется приложением‑просмотрщиком, таким как PowerPoint.