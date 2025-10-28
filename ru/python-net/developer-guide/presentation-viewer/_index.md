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
description: "Узнайте, как создать пользовательский просмотрщик презентаций на Python с помощью Aspose.Slides. Легко отображайте файлы PowerPoint (PPTX, PPT) и OpenDocument (ODP) без Microsoft PowerPoint или другого офисного программного обеспечения."
---

## **Обзор**

Aspose.Slides для Python используется для создания файлов презентаций со слайдами. Эти слайды можно просматривать, открывая презентации в Microsoft PowerPoint, например. Однако разработчикам иногда требуется просматривать слайды как изображения в предпочитаемом просмотрщике изображений или использовать их в пользовательском просмотрщике презентаций. В таких случаях Aspose.Slides позволяет экспортировать отдельные слайды в виде изображений. В этой статье объясняется, как это сделать.

## **Создание SVG‑изображения со слайда**

Чтобы создать SVG‑изображение со слайда презентации с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Получите ссылку на слайд по его индексу.
3. Откройте файловый поток.
4. Сохраните слайд как SVG‑изображение в файловом потоке.

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with open("output.svg", "wb") as svg_stream:
        slide.write_as_svg(svg_stream)
```

## **Создание миниатюры слайда**

Aspose.Slides помогает генерировать миниатюрные изображения слайдов. Чтобы создать миниатюру слайда с помощью Aspose.Slides, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Получите ссылку на слайд по его индексу.
3. Создайте миниатюрное изображение указанного слайда в требуемом масштабе.
4. Сохраните миниатюрное изображение в предпочитаемом формате.

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

Чтобы создать миниатюру слайда с пользовательскими размерами, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Получите ссылку на слайд по его индексу.
3. Сгенерируйте миниатюрное изображение указанного слайда с заданными размерами.
4. Сохраните миниатюрное изображение в предпочитаемом формате.

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

## **Создание миниатюры слайда с заметками докладчика**

Чтобы создать миниатюру слайда с заметками докладчика с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) .
2. Используйте свойство `RenderingOptions.slides_layout_options`, чтобы задать положение заметок докладчика.
3. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
4. Получите ссылку на слайд по его индексу.
5. Создайте миниатюрное изображение указанного слайда, используя параметры рендеринга.
6. Сохраните миниатюрное изображение в предпочитаемом формате.

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

Попробуйте бесплатное приложение [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/), чтобы увидеть, что можно реализовать с помощью API Aspose.Slides:

[![Online PowerPoint Viewer](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/viewer/)

## **FAQ**

**Можно ли встроить просмотрщик презентаций в веб‑приложение ASP.NET?**

Да. Вы можете использовать Aspose.Slides на стороне сервера для рендеринга слайдов в виде [images](/slides/ru/python-net/convert-powerpoint-to-png/) или [HTML](/slides/ru/python-net/convert-powerpoint-to-html/) и отображать их в браузере. Навигацию и масштабирование можно реализовать с помощью JavaScript для интерактивного опыта.

**Как лучше всего отображать слайды в пользовательском .NET‑просмотрщике?**

Рекомендуемый подход — рендерить каждый слайд как [image](/slides/ru/python-net/convert-powerpoint-to-png/) (например, PNG или SVG) или конвертировать его в [HTML](/slides/ru/python-net/convert-powerpoint-to-html/) с помощью Aspose.Slides, затем выводить полученный результат в элементе picture box (для настольных приложений) или в HTML‑контейнере (для веба).

**Как обрабатывать большие презентации с множеством слайдов?**

Для больших наборов слайдов рекомендуется использовать отложенную загрузку или рендеринг по запросу. Это означает генерацию содержимого слайда только в момент, когда пользователь переходит к нему, что снижает потребление памяти и время загрузки.