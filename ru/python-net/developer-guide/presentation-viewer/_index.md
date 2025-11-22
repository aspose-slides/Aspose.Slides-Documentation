---
title: Создать просмотрщик презентаций на Python
linktitle: Просмотрщик презентаций
type: docs
weight: 50
url: /ru/python-net/presentation-viewer/
keywords:
- просмотр презентации
- просмотрщик презентаций
- создание просмотрщика презентаций
- просмотр PPT
- просмотр PPTX
- просмотр ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Узнайте, как создать пользовательский просмотрщик презентаций на Python с использованием Aspose.Slides. Легко отображайте файлы PowerPoint (PPTX, PPT) и OpenDocument (ODP) без Microsoft PowerPoint или другого офисного программного обеспечения."
---

## **Обзор**

Aspose.Slides for Python используется для создания файлов презентаций со слайдами. Эти слайды можно просматривать, открывая презентации в Microsoft PowerPoint, например. Однако разработчикам иногда требуется просмотреть слайды как изображения в предпочитаемом просмотрщике изображений или использовать их в пользовательском просмотрщике презентаций. В таких случаях Aspose.Slides позволяет экспортировать отдельные слайды как изображения. В этой статье объясняется, как это сделать.

## **Создание SVG‑изображения со слайда**

Чтобы создать SVG‑изображение из слайда презентации с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Откройте поток файла.
1. Сохраните слайд как SVG‑изображение в поток файла.
```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with open("output.svg", "wb") as svg_stream:
        slide.write_as_svg(svg_stream)
```


## **Создание миниатюры слайда**

Aspose.Slides помогает генерировать миниатюрные изображения слайдов. Чтобы создать миниатюру слайда с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Создайте миниатюру ссылки‑слайда с нужным масштабом.
1. Сохраните миниатюру в предпочитаемом формате изображения.
```py
import aspose.slides as slides

slide_index = 0
scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(scale_x, scale_y) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```


## **Создание миниатюры слайда с пользовательскими размерами**

Чтобы создать миниатюрное изображение слайда с пользовательскими размерами, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Сгенерируйте миниатюру ссылки‑слайда с указанными размерами.
1. Сохраните миниатюру в предпочитаемом формате изображения.
```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

slide_index = 0
slide_size = pydrawing.Size(1200, 800)

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(slide_size) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```


## **Создание миниатюры слайда со спикер‑нотатками**

Чтобы создать миниатюру слайда со спикер‑нотатками с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/).
1. Используйте свойство `RenderingOptions.slides_layout_options`, чтобы задать позицию спикер‑нотаток.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Сгенерируйте миниатюру ссылки‑слайда, используя параметры рендеринга.
1. Сохраните миниатюру в предпочитаемом формате изображения.
```py
slide_index = 0

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(rendering_options) as image:
        image.save("output.png", slides.ImageFormat.PNG)
```


## **Рабочий пример**

Попробуйте бесплатное приложение [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/), чтобы увидеть, что можно реализовать с помощью Aspose.Slides API:

[![Online PowerPoint Viewer](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/viewer/)

## **Вопросы и ответы**

**Можно ли внедрить просмотрщик презентаций в веб‑приложение ASP.NET?**

Да. Вы можете использовать Aspose.Slides на стороне сервера для рендеринга слайдов как [изображения](/slides/ru/python-net/convert-powerpoint-to-png/) или [HTML](/slides/ru/python-net/convert-powerpoint-to-html/) и отображать их в браузере. Навигацию и масштабирование можно реализовать с помощью JavaScript для интерактивного опыта.

**Как лучше всего отображать слайды внутри пользовательского .NET‑просмотрщика?**

Рекомендуемый подход — рендерить каждый слайд как [изображение](/slides/ru/python-net/convert-powerpoint-to-png/) (например, PNG или SVG) или конвертировать его в [HTML](/slides/ru/python-net/convert-powerpoint-to-html/) с помощью Aspose.Slides, затем показывать вывод в элементе picture box (для настольных приложений) или в контейнере HTML (для веба).

**Как обрабатывать большие презентации с множеством слайдов?**

Для больших наборов слайдов рекомендуется использовать отложенную загрузку или рендеринг по запросу. Это значит генерировать содержимое слайда только когда пользователь переходит к нему, уменьшая потребление памяти и время загрузки.