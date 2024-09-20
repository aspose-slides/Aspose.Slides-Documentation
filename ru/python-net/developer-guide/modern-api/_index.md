---
title: Современное API
type: docs
weight: 280
url: /python-net/modern-api/
keywords: "Современное API, Изображение"
description: "Современное API"
---

## Введение

На данный момент библиотека Aspose.Slides для Python через .NET имеет зависимости в своем публичном API от следующих классов из `aspose.pydrawing`:
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

Начиная с версии 24.4, этот публичный API объявлен устаревшим из-за [изменений](https://releases.aspose.com/slides/net/release-notes/2024/aspose-slides-for-net-24-4-release-notes/#introducing-a-new-modern-api) в публичном API Aspose.Slides для .NET.

Для того чтобы избавиться от зависимостей на `aspose.pydrawing` в публичном API, мы добавили так называемое "Современное API". Методы с `aspose.pydrawing.Image` и `aspose.pydrawing.Bitmap` объявлены устаревшими и будут заменены соответствующими методами из Современного API. Методы с `aspose.pydrawing.Graphics` объявлены устаревшими, и их поддержка будет удалена из публичного API.

Удаление устаревшего публичного API с зависимостями от `aspose.pydrawing` будет произведено в версии 24.8.

## Современное API

В публичный API добавлены следующие классы и перечисления:

- [`aspose.slides.IImage`](https://reference.aspose.com/slides/python-net/aspose.slides/iimage) - представляет растровое или векторное изображение.
- [`aspose.slides.ImageFormat`](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat) - представляет формат файла изображения.
- [`aspose.slides.Images`](https://reference.aspose.com/slides/python-net/aspose.slides/images) - методы для создания и работы с интерфейсом `IImage`.

Типичный сценарий использования нового API может выглядеть следующим образом:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as pres:
    image = slides.Images.from_file("image.png")
    pp_image = pres.images.add_image(image)
    pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10.0, 10.0, 100.0, 100.0, pp_image)
    with pres.slides[0].get_image(drawing.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

## Замена старого кода на Современное API

Для упрощения перехода интерфейс нового `IImage` повторяет отдельные сигнатуры классов `Image` и `Bitmap`. В общем, вам просто нужно будет заменить вызов старого метода, используя `aspose.pydrawing`, на новый.

### Получение миниатюры слайда

Код, использующий устаревший API:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    pres.slides[0].get_thumbnail().save("slide1.png")
```

Современное API:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    with pres.slides[0].get_image() as image:
        image.save("slide1.png")
```

### Получение миниатюры фигуры

Код, использующий устаревший API:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    pres.slides[0].shapes[0].get_thumbnail().save("shape.png")
```

Современное API:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    with pres.slides[0].shapes[0].get_image() as image:
        image.save("shape.png")
```

### Получение миниатюры презентации

Код, использующий устаревший API:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("pres.pptx") as pres:
    thumbnails = pres.get_thumbnails(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for idx, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{idx}.png", drawing.imaging.ImageFormat.png)
```

Современное API:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("pres.pptx") as pres:
    thumbnails = pres.get_images(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for idx, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{idx}.png", slides.ImageFormat.PNG)
```

### Добавление изображения в презентацию

Код, использующий устаревший API:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as pres:
    image = drawing.Image.from_file("image.png")
    pp_image = pres.images.add_image(image)
    pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10.0, 10.0, 100.0, 100.0, pp_image)
```

Современное API:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    image = slides.Images.from_file("image.png")
    pp_image = pres.images.add_image(image)
    pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10.0, 10.0, 100.0, 100.0, pp_image)
```

## Методы/свойства, которые будут удалены, и их замена в Современном API

### Класс Presentation
|Сигнатура метода|Сигнатура заменяющего метода|
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingsize)|
|save(fname, format, response, show_inline)|Будет полностью удален|
|save(fname, format, options, response, show_inline)|Будет полностью удален|
|print()|Будет полностью удален|
|print(printer_settings)|Будет полностью удален|
|print(printer_name)|Будет полностью удален|
|print(printer_settings, pres_name)|Будет полностью удален|

### Класс Slide
|Сигнатура метода|Сигнатура заменяющего метода|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOotions)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|render_to_graphics(options, graphics)|Будет полностью удален|
|render_to_graphics(options, graphics, scale_x, scale_y)|Будет полностью удален|
|render_to_graphics(options, graphics, rendering_size)|Будет полностью удален|

### Класс Shape
|Сигнатура метода|Сигнатура заменяющего метода|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### Класс ImageCollection
|Сигнатура метода|Сигнатура заменяющего метода|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### Класс PPImage
|Сигнатура метода/свойства|Сигнатура заменяющего метода/свойства|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/image/)|

### Класс ImageWrapperFactory
|Сигнатура метода|Сигнатура заменяющего метода|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### Класс PatternFormat
|Сигнатура метода|Сигнатура заменяющего метода|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### Класс IPatternFormatEffectiveData
|Сигнатура метода|Сигнатура заменяющего метода|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### Класс Output
|Сигнатура метода|Сигнатура заменяющего метода|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## Поддержка API для `aspose.pydrawing.Graphics` будет прекращена

Методы с `aspose.pydrawing.Graphics` объявлены устаревшими, и их поддержка будет удалена из публичного API.

Часть API, использующая его, будет удалена:
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`