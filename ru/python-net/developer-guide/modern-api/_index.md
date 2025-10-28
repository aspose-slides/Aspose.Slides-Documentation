---
title: Улучшение обработки изображений с помощью современного API
linktitle: Современный API
type: docs
weight: 280
url: /ru/python-net/modern-api/
keywords:
- современный API
- рисование
- миниатюра слайда
- слайд в изображение
- миниатюра фигуры
- фигура в изображение
- миниатюра презентации
- презентация в изображения
- добавить изображение
- добавить картинку
- Python
- Aspose.Slides
description: "Модернизируйте обработку изображений слайдов, заменив устаревшие API обработки изображений на современный Python API для беспроблемной автоматизации PowerPoint и OpenDocument."
---

## **Введение**

Общедоступный API Aspose.Slides for Python в настоящее время зависит от следующих типов `aspose.pydrawing`:
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

Начиная с версии 24.4 этот публичный API **устарел** из‑за [изменений](https://releases.aspose.com/slides/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/#introducing-a-new-modern-api) в общедоступном API Aspose.Slides for Python.

Чтобы избавиться от `aspose.pydrawing` в публичном API, мы представили **Современный API**. Методы, использующие `aspose.pydrawing.Image` и `aspose.pydrawing.Bitmap`, устарели и будут заменены их аналогами из Современного API. Методы, использующие `aspose.pydrawing.Graphics`, также устарели, и поддержка их будет удалена из публичного API.

Удаление устаревшего API, зависящего от `aspose.pydrawing`, запланировано для выпуска **24.8**.

## **Современный API**

В публичный API добавлены следующие классы и перечисления:

- [`aspose.slides.IImage`](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) — представляет растровое или векторное изображение.
- [`aspose.slides.ImageFormat`](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) — представляет формат файлов изображения.
- [`aspose.slides.Images`](https://reference.aspose.com/slides/python-net/aspose.slides/images/) — предоставляет методы для создания и работы с `IImage`.

Типичный сценарий использования нового API выглядит так:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)

    with slide.get_image(drawing.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

## **Замена старого кода на Современный API**

Для облегчения перехода новый интерфейс `IImage` зеркально отражает отдельные API классов `Image` и `Bitmap`. В большинстве случаев достаточно заменить вызовы методов, использующих `aspose.pydrawing`, их эквивалентами из Современного API.

### **Получить миниатюру слайда**

**Устаревший API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.get_thumbnail().save("slide1.png")
```

**Современный API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("slide1.png")
```

### **Получить миниатюру фигуры**

**Устаревший API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    
    shape.get_thumbnail().save("shape.png")
```

**Современный API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    with shape.get_image() as image:
        image.save("shape.png")
```

### **Получить миниатюру презентации**

**Устаревший API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_thumbnails(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", drawing.imaging.ImageFormat.png)
```

**Современный API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_images(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

### **Добавить изображение в презентацию**

**Устаревший API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    image = drawing.Image.from_file("image.png")
    pp_image = presentation.images.add_image(image)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

**Современный API:**

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

## **Методы и свойства, которые будут удалены, и их современные замены**

### **Класс Presentation**

|Подпись метода|Подпись заменяющего метода|
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingssize)|
|save(fname, format, response, show_inline)|Будет полностью удалён|
|save(fname, format, options, response, show_inline)|Будет полностью удалён|
|print()|Будет полностью удалён|
|print(printer_settings)|Будет полностью удалён|
|print(printer_name)|Будет полностью удалён|
|print(printer_settings, pres_name)|Будет полностью удалён|

### **Класс Slide**

|Подпись метода|Подпись заменяющего метода|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOotions)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingssize)|
|render_to_graphics(options, graphics)|Будет полностью удалён|
|render_to_graphics(options, graphics, scale_x, scale_y)|Будет полностью удалён|
|render_to_graphics(options, graphics, rendering_size)|Будет полностью удалён|

### **Класс Shape**

|Подпись метода|Подпись заменяющего метода|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### **Класс ImageCollection**

|Подпись метода|Подпись заменяющего метода|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### **Класс PPImage**

|Подпись метода/свойства|Подпись заменяющего метода/свойства|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/image/)|

### **Класс ImageWrapperFactory**

|Подпись метода|Подпись заменяющего метода|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### **Класс PatternFormat**

|Подпись метода|Подпись заменяющего метода|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### **Класс IPatternFormatEffectiveData**

|Подпись метода|Подпись заменяющего метода|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### **Класс Output**

|Подпись метода|Подпись заменяющего метода|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## **Поддержка aspose.pydrawing.Graphics будет прекращена**

Методы, использующие `aspose.pydrawing.Graphics`, устарели; поддержка их будет удалена из публичного API.

К членам API, зависящим от `aspose.pydrawing.Graphics` и подлежащим удалению, относятся:
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`

# **FAQ**

**Почему был удалён aspose.pydrawing.Graphics?**

Поддержка Graphics удаляется из публичного API для унификации работы с рендерингом и изображениями, устранения привязки к платформенно‑зависимым компонентам и перехода к кроссплатформенному подходу с использованием [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/). Все методы рендеринга в Graphics будут удалены.

**В чём практическая выгода IImage по сравнению с Image/Bitmap?**

[IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) объединяет работу как с растровыми, так и с векторными изображениями, упрощает сохранение в различные форматы через [ImageFormat](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/), уменьшает зависимость от pydrawing и повышает переносимость кода между средами.

**Повлияет ли Современный API на производительность генерации миниатюр?**

Переход от `get_thumbnail` к `get_image` не ухудшает производительность: новые методы предоставляют те же возможности по созданию изображений с параметрами и размерами, сохраняя поддержку параметров рендеринга. Конкретный прирост или падение зависит от сценария, но функционально замены эквивалентны.