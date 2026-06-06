---
title: Улучшите обработку изображений с Modern API
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
description: "Модернизируйте обработку изображений слайдов, заменив устаревшие API обработки изображений на Modern API для Python, обеспечивая бесшовную автоматизацию PowerPoint и OpenDocument."
---
## **Введение**

Публичный API Aspose.Slides for Python в настоящее время зависит от следующих типов `aspose.pydrawing`:
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

Начиная с версии 24.4, этот публичный API **устарел** из‑за [изменений](https://releases.aspose.com/slides/ru/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/#introducing-a-new-modern-api) в публичном API Aspose.Slides for Python.

Чтобы избавиться от `aspose.pydrawing` в публичном API, мы внедрили **Modern API**. Методы, использующие `aspose.pydrawing.Image` и `aspose.pydrawing.Bitmap`, помечены как устаревшие и должны быть заменены их эквивалентами Modern API. Методы, использующие `aspose.pydrawing.Graphics`, помечены как устаревшие и не имеют прямой замены в Modern API.

В текущих версиях рассматривайте публичный API, зависящий от `aspose.pydrawing`, как устаревший/наследуемый. Используйте Modern API для нового кода и при миграции существующих рабочих процессов обработки изображений.

## **Modern API**

В публичный API были добавлены следующие классы и перечисления:

- [aspose.slides.IImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iimage/) – представляет растровое или векторное изображение.
- [aspose.slides.ImageFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/imageformat/) – представляет формат файла изображения.
- [aspose.slides.Images](https://reference.aspose.com/slides/ru/python-net/aspose.slides/images/) – предоставляет методы для создания и работы с [IImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iimage/).

Используйте `get_image` для рендеринга отдельного слайда или фигуры. Используйте `get_images` для рендеринга нескольких слайдов презентации. Используйте методы [Images](https://reference.aspose.com/slides/ru/python-net/aspose.slides/images/) для загрузки изображений, `add_image` с [IImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iimage/) для добавления их в презентацию и `replace_image` с [IImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iimage/) для обновления существующего изображения в презентации.

Типичный сценарий использования нового API выглядит следующим образом:

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

## **Замена старого кода на Modern API**

Для облегчения перехода новый класс [IImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iimage/) отражает отдельные API классов `aspose.pydrawing.Image` и `aspose.pydrawing.Bitmap`. В большинстве случаев достаточно заменить вызовы методов, использующих `aspose.pydrawing`, их эквивалентами Modern API.

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

## **Методы и свойства, подлежащие удалению, и их современные замены**

### **Класс Presentation**

|Подпись метода|Подпись заменяющего метода|
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingsize)|
|save(fname, format, response, show_inline)|Нет замены в Modern API|
|save(fname, format, options, response, show_inline)|Нет замены в Modern API|
|print()|Нет замены в Modern API|
|print(printer_settings)|Нет замены в Modern API|
|print(printer_name)|Нет замены в Modern API|
|print(printer_settings, pres_name)|Нет замены в Modern API|

### **Класс Slide**

|Подпись метода|Подпись заменяющего метода|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOptions)](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|render_to_graphics(options, graphics)|Нет замены в Modern API|
|render_to_graphics(options, graphics, scale_x, scale_y)|Нет замены в Modern API|
|render_to_graphics(options, graphics, rendering_size)|Нет замены в Modern API|

### **Класс Shape**

|Подпись метода|Подпись заменяющего метода|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### **Класс ImageCollection**

|Подпись метода|Подпись заменяющего метода|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/ru/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### **Класс PPImage**

|Подпись метода/свойства|Подпись заменяющего метода/свойства|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/image/)|

### **Класс ImageWrapperFactory**

|Подпись метода|Подпись заменяющего метода|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### **Класс PatternFormat**

|Подпись метода|Подпись заменяющего метода|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/ru/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/ru/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### **Класс IPatternFormatEffectiveData**

|Подпись метода|Подпись заменяющего метода|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### **Класс Output**

|Подпись метода|Подпись заменяющего метода|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## **Поддержка API для aspose.pydrawing.Graphics**

Методы, использующие `aspose.pydrawing.Graphics`, помечены как устаревшие и не имеют прямой замены в Modern API.

Используйте методы рендеринга изображений Modern API вместо API, который рендерит в `aspose.pydrawing.Graphics`:
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`

# **FAQ**

**Почему `aspose.pydrawing.Graphics` был удалён?**

Поддержка `aspose.pydrawing.Graphics` помечена как устаревшая в публичном API, чтобы упростить работу с рендерингом и изображениями, избавиться от привязки к платформенно‑специфичным зависимостям и перейти к кроссплатформенному подходу с использованием [IImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iimage/). Используйте `get_image` или `get_images` вместо рендеринга в `aspose.pydrawing.Graphics`.

**Какова практическая польза [IImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iimage/) по сравнению с `aspose.pydrawing.Image`/`aspose.pydrawing.Bitmap`?**

[IImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iimage/) объединяет работу как с растровыми, так и с векторными изображениями, упрощает сохранение в различные форматы через [ImageFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/imageformat/), уменьшает зависимость от pydrawing и делает код более переносимым между средами.

**Повлияет ли Modern API на производительность генерации миниатюр?**

Переход от `get_thumbnail` к `get_image` не ухудшает сценарии: новые методы предоставляют те же возможности по созданию изображений с опциями и размерами, сохраняя поддержку параметров рендеринга. Конкретный прирост или падение зависят от сценария, но функционально замены эквивалентны.