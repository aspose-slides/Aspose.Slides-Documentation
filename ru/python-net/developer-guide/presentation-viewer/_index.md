---
title: Создание просмотрщика презентаций на Python
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

Aspose.Slides для Python используется для создания файлов презентаций со слайдами. Эти слайды можно просматривать, открыв презентацию в Microsoft PowerPoint, например. Однако разработчикам иногда требуется просматривать слайды как изображения в предпочитаемом просмотрщике изображений или использовать их в пользовательском просмотрщике презентаций. В таких случаях Aspose.Slides позволяет экспортировать отдельные слайды как изображения. В этой статье объясняется, как это сделать.

## **Создание SVG‑изображения из слайда**

Чтобы создать SVG‑изображение из слайда презентации с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
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

Aspose.Slides помогает создавать миниатюрные изображения слайдов. Чтобы создать миниатюру слайда с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Создайте изображение‑миниатюру выбранного слайда в нужном масштабе.
1. Сохраните изображение‑миниатюру в предпочитаемом формате изображения.

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

Чтобы создать изображение‑миниатюру слайда с пользовательскими размерами, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Сгенерируйте изображение‑миниатюру выбранного слайда с указанными размерами.
1. Сохраните изображение‑миниатюру в предпочитаемом формате изображения.

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

## **Создание миниатюры слайда с примечаниями докладчика**

Чтобы создать миниатюру слайда с примечаниями докладчика с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) .
1. Используйте свойство `RenderingOptions.slides_layout_options` для установки положения примечаний докладчика.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Сгенерируйте изображение‑миниатюру выбранного слайда с использованием параметров рендеринга.
1. Сохраните изображение‑миниатюру в предпочитаемом формате изображения.

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

## **Онлайн‑пример**

Попробуйте бесплатное приложение [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) и посмотрите, что можно реализовать с помощью API Aspose.Slides:

[![Online PowerPoint Viewer](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/viewer/)

## **FAQ**

**Можно ли встроить просмотрщик презентаций в веб‑приложение ASP.NET?**

Да. Вы можете использовать Aspose.Slides на стороне сервера для рендеринга слайдов как [images](/slides/ru/python-net/convert-powerpoint-to-png/) или [HTML](/slides/ru/python-net/convert-powerpoint-to-html/) и отображать их в браузере. Навигацию и функции масштабирования можно реализовать с помощью JavaScript для интерактивного опыта.

**Как лучше всего отображать слайды внутри пользовательского .NET‑просмотрщика?**

Рекомендуемый подход — рендерить каждый слайд как [image](/slides/ru/python-net/convert-powerpoint-to-png/) (например, PNG или SVG) или конвертировать его в [HTML](/slides/ru/python-net/convert-powerpoint-to-html/) с помощью Aspose.Slides, затем выводить результат в элементе изображения (для настольных приложений) или в HTML‑контейнере (для веба).

**Как обрабатывать большие презентации с множеством слайдов?**

Для больших наборов слайдов рекомендуется использовать ленивую загрузку или рендеринг по требованию. Это означает генерацию содержимого слайда только при переходе пользователя к нему, что снижает потребление памяти и время загрузки.