---
title: Добавление кадров изображений в презентации с Python
linktitle: Кадр изображения
type: docs
weight: 10
url: /ru/python-net/picture-frame/
keywords:
- кадр изображения
- добавление кадра изображения
- создание кадра изображения
- добавление изображения
- создание изображения
- извлечение изображения
- растровое изображение
- векторное изображение
- обрезка изображения
- обрезанная область
- свойство StretchOff
- форматирование кадра изображения
- свойства кадра изображения
- относительное масштабирование
- эффект изображения
- соотношение сторон
- прозрачность изображения
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Добавляйте кадры изображений в презентации PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET. Упрощайте рабочий процесс и улучшайте дизайн слайдов."
---
## **Введение**

Кадры изображений в Aspose.Slides for Python позволяют размещать и управлять растровыми и векторными изображениями как нативными объектами слайда. Вы можете вставлять изображения из файлов или потоков, позиционировать и изменять их размер с точными координатами, применять вращение, задавать прозрачность и управлять порядком наложения вместе с другими объектами. API также поддерживает кадрирование, сохранение соотношения сторон, установку рамок и эффектов, а также замену исходного изображения без пересборки макета. Поскольку кадры изображений ведут себя как обычные формы, вы можете добавлять анимацию, гиперссылки и альтернативный текст, что упрощает создание визуально насыщенных, доступных презентаций.

## **Создание кадров изображений**

В этом разделе показано, как вставить изображение в слайд, создав [PictureFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframe/) с помощью Aspose.Slides for Python. Вы узнаете, как загрузить изображение, точно разместить его на слайде и управлять его размерами и форматированием.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
2. Получите слайд по его индексу.
3. Создайте объект [PPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/), добавив изображение в [ImageCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/imagecollection/) презентации. Это изображение будет использоваться для заполнения формы.
4. Укажите ширину и высоту кадра.
5. Создайте [PictureFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframe/) нужного размера с помощью метода [add_picture_frame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapecollection/add_picture_frame/).
6. Сохраните презентацию как файл PPTX.

Следующий код на Python демонстрирует создание кадра изображения:

```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation для представления файла PPTX.
with slides.Presentation() as presentation:
    # Получите первый слайд.
    slide = presentation.slides[0]

    # Добавьте изображение в презентацию.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Добавьте кадр изображения размером с изображение.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Сохраните презентацию в формате PPTX.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}

Кадры изображений позволяют быстро создавать слайды презентаций из изображений. При комбинировании кадров изображений с параметрами сохранения Aspose.Slides вы можете управлять операциями ввода/вывода для преобразования изображений из одного формата в другой. Возможно, вас заинтересуют эти страницы: преобразовать [изображение в JPG](https://products.aspose.com/slides/ru/python-net/conversion/image-to-jpg/); преобразовать [JPG в изображение](https://products.aspose.com/slides/ru/python-net/conversion/jpg-to-image/); преобразовать [JPG в PNG](https://products.aspose.com/slides/ru/python-net/conversion/jpg-to-png/); преобразовать [PNG в JPG](https://products.aspose.com/slides/ru/python-net/conversion/png-to-jpg/); преобразовать [PNG в SVG](https://products.aspose.com/slides/ru/python-net/conversion/png-to-svg/); преобразовать [SVG в PNG](https://products.aspose.com/slides/ru/python-net/conversion/svg-to-png/).

{{% /alert %}}

## **Создание кадров изображений с относительным масштабом**

В этом разделе демонстрируется размещение изображения фиксированного размера, а затем применение масштабирования на основе процентов независимо для ширины и высоты. Поскольку проценты могут различаться, соотношение сторон может измениться. Масштабирование выполняется относительно оригинальных размеров изображения.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
2. Получите слайд по его индексу.
3. Создайте объект [PPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/), добавив изображение в [ImageCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/imagecollection/) презентации.
4. Добавьте [PictureFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframe/) на слайд.
5. Установите относительные ширину и высоту кадра изображения.
6. Сохраните презентацию как файл PPTX.

Следующий код на Python демонстрирует создание кадра изображения с относительным масштабированием:

```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation для представления файла PPTX.
with slides.Presentation() as presentation:
    # Получите первый слайд.
    slide = presentation.slides[0]

    # Добавьте изображение в коллекцию изображений презентации.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Добавьте кадр изображения на слайд.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Установите относительные масштабные значения ширины и высоты.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # Сохраните презентацию.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **Извлечение растровых изображений из кадров изображений**

Вы можете извлекать растровые изображения из объектов [PictureFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframe/) и сохранять их в форматах PNG, JPG и других. Пример кода ниже показывает, как извлечь изображение из документа «sample.pptx» и сохранить его в формате PNG.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **Извлечение SVG‑изображений из кадров изображений**

Когда презентация содержит SVG‑графику, размещённую внутри фигур [PictureFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframe/), Aspose.Slides for Python via .NET позволяет получить оригинальные векторные изображения с полной точностью. Путём обхода коллекции фигур слайда вы можете определить каждый [PictureFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframe/), проверить, содержит ли соответствующий [PPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/) SVG‑контент, а затем сохранить это изображение на диск или в поток в его родном формате SVG.

Следующий пример кода демонстрирует извлечение SVG‑изображения из кадра:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.PictureFrame):
        svg_image = shape.picture_format.picture.image.svg_image

        if svg_image is not None:
            with open("output.svg", "w", encoding="utf-8") as svg_stream:
                svg_stream.write(svg_image.svg_content)
```

## **Получение прозрачности изображения**

Aspose.Slides позволяет получать эффект прозрачности, применённый к изображению. Этот код на Python демонстрирует эту операцию:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    picture_frame = presentation.slides[0].shapes[0]
    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.AlphaModulateFixed):
            transparency_value = 100 - effect.amount
            print("Picture transparency: " + str(transparency_value))
```

{{% alert color="primary" %}}
Все эффекты, применяемые к изображениям, можно найти в [aspose.slides.effects](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/).
{{% /alert %}}

## **Получение яркости и контрастности изображения**

Aspose.Slides позволяет получать эффекты яркости и контрастности, применённые к изображению. Класс [Luminance](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/luminance/) представляет этот трансформирующий эффект изображения.

Этот код на Python демонстрирует, как получить настройки яркости и контрастности из кадра изображения:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    picture_frame = shape

    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.Luminance):
            luminance = effect.get_effective()
            brightness = luminance.brightness
            contrast = luminance.contrast

            print("Brightness: " + str(brightness))
            print("Contrast: " + str(contrast))
```

## **Форматирование кадра изображения**

Aspose.Slides предоставляет множество параметров форматирования, которые можно применить к кадру изображения. С их помощью вы можете настроить кадр в соответствии с конкретными требованиями.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
2. Получите слайд по его индексу.
3. Создайте объект [PPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/), добавив изображение в [ImageCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/imagecollection/) презентации. Это изображение будет использоваться для заполнения формы.
4. Укажите ширину и высоту кадра.
5. Создайте [PictureFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframe/) нужного размера с помощью метода [add_picture_frame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapecollection/add_picture_frame/) слайда.
6. Задайте цвет линии кадра изображения.
7. Задайте толщину линии кадра изображения.
8. Поверните кадр, задав положительное (по часовой стрелке) или отрицательное (против часовой стрелки) значение.
9. Сохраните изменённую презентацию как файл PPTX.

Следующий код на Python демонстрирует процесс форматирования кадра изображения:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Создайте экземпляр класса Presentation для представления файла PPTX.
with slides.Presentation() as presentation:
    # Получите первый слайд.
    slide = presentation.slides[0]

    # Добавьте изображение в коллекцию изображений презентации.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Добавьте кадр изображения размером с изображение.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Примените форматирование к кадру изображения.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # Сохраните презентацию в формате PPTX.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}

Aspose разработала бесплатный сервис [Collage Maker](https://products.aspose.app/slides/ru/collage). Если вам нужно [объединить JPG/JPEG](https://products.aspose.app/slides/ru/collage/jpg) или PNG‑изображения, либо [создать фотосетки](https://products.aspose.app/slides/ru/collage/photo-grid), вы можете воспользоваться этим сервисом.
{{% /alert %}}

## **Добавление изображений как ссылок**

Чтобы уменьшить размер файлов презентаций, вы можете добавлять изображения или видео через ссылки вместо их встраивания непосредственно в презентацию. Следующий код на Python показывает, как вставить изображение и видео в заполнитель:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    shapes_to_remove = []

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_frame = slide.shapes.add_picture_frame(
                slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, None)

            picture_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            shapes_to_remove.append(shape)

        elif shape.placeholder.type == slides.PlaceholderType.MEDIA:
            video_frame = slide.shapes.add_video_frame(shape.X, shape.Y, shape.width, shape.height, "")

            video_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            video_frame.link_path_long = "https://youtu.be/t_1LYZ102RA"
            shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.shapes.remove(shape)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Кадрирование изображений**

В этом разделе вы научитесь кадрировать видимую область изображения внутри кадра без изменения исходного файла. Вы также узнаете базовый метод применения отступов кадрирования для создания чистой, сфокусированной композиции непосредственно на слайде.

Следующий код на Python показывает, как кадрировать изображение на слайде:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Добавьте изображение в коллекцию изображений презентации.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Добавьте кадр изображения на слайд.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # Обрежьте изображение (значения в процентах).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # Сохраните результат.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Удаление обрезанных областей изображений**

Если необходимо удалить обрезанные области изображения в кадре, используйте метод [delete_picture_cropped_areas](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/). Этот метод возвращает обрезанное изображение или оригинальное изображение, если обрезка не требовалась.

Следующий код на Python демонстрирует эту операцию:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Получить кадр изображения с первого слайда.
    picture_frame = slides.shape[0]

    # Получить кадр изображения с первого слайда.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # Сохранить результат.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

Метод [delete_picture_cropped_areas](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) добавляет обрезанное изображение в коллекцию изображений презентации. Если изображение используется только в обработанном [PictureFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframe/), это может уменьшить размер презентации; в противном случае количество изображений в результирующей презентации может возрасти.

Во время кадрирования этот метод конвертирует метафайлы WMF/EMF в растровое PNG‑изображение.
{{% /alert %}}

## **Сжатие изображений**

Вы можете сжимать изображение в презентации, используя метод [PictureFillFormat.compress_image](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picturefillformat/compress_image/). Этот метод уменьшает размер изображения, исходя из размеров формы и указанного разрешения, с опцией удаления обрезанных областей.

Он изменяет размер и разрешение изображения аналогично функции PowerPoint **Формат рисунка → Сжать изображения → Разрешение**.

Следующие примеры на Python демонстрируют, как сжать изображение в презентации, указав целевое разрешение и, при желании, удалив обрезанные области:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Сжать изображение с целевым разрешением 150 DPI (разрешение для web) и удалить обрезанные области.
    result = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)

    # Проверить результат сжатия.
    if result:
        print("Image successfully compressed.")
    else:
        print("Image compression failed or no changes were necessary.")

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

Или указав пользовательское значение DPI напрямую:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Сжать изображение до 150 DPI (разрешение для web), удаляя обрезанные области.
    picture_frame.picture_format.compress_image(True, 150)

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

Метод конвертирует изображение в более низкое разрешение на основе размеров формы и заданного DPI. Обрезанные области также могут быть удалены для оптимизации размера файла. Если изображение является метафайлом (WMF/EMF) или SVG, сжатие применено не будет. Кроме того, качество JPEG сохраняется или слегка снижается в зависимости от разрешения, аналогично тому, как PowerPoint обрабатывает JPEG‑изображения высокого разрешения.
{{% /alert %}}

## **Блокировка соотношения сторон**

Если вы хотите, чтобы форма, содержащая изображение, сохраняла своё соотношение сторон после изменения размеров изображения, установите свойство [aspect_ratio_locked](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) в значение `True`.

Следующий код на Python показывает, как заблокировать соотношение сторон формы:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # Заблокировать соотношение сторон при изменении размеров.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

Эта настройка *Lock Aspect Ratio* сохраняет только соотношение сторон формы, а не соотношение сторон изображения внутри неё.
{{% /alert %}}

## **Использование свойств смещения растяжения**

С помощью свойств `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right` и `stretch_offset_bottom` класса [PictureFillFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picturefillformat/) вы можете задать прямоугольник заполнения.

Когда для изображения указана растяжка, исходный прямоугольник масштабируется до размеров прямоугольника заполнения. Каждая грань прямоугольника заполнения определяется процентным смещением от соответствующей грани ограничивающего прямоугольника формы. Положительный процент задаёт отступ, отрицательный — выступ.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте прямоугольный [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/).
4. Установите тип заливки формы.
5. Установите режим заливки изображения формы.
6. Загрузите изображение.
7. Присвойте изображение в качестве заливки формы.
8. Укажите смещения изображения от соответствующих граней ограничивающего прямоугольника формы.
9. Сохраните презентацию как файл PPTX.

Следующий код на Python демонстрирует использование свойств смещения растяжения:

```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation, представляющего файл PPTX.
with slides.Presentation() as presentation:
    # Получите первый слайд.
    slide = presentation.slides[0]

    # Добавьте прямоугольную AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # Установите тип заливки формы.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Установите режим заливки изображения формы.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Загрузите изображение и добавьте его в презентацию.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # Присвойте изображение для заполнения формы.
    shape.fill_format.picture_fill_format.picture.image = image

    # Укажите смещения изображения от соответствующих краёв ограничивающего прямоугольника формы.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # Сохраните файл PPTX на диск.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}

Aspose предоставляет бесплатные конвертеры — [JPEG в PowerPoint](https://products.aspose.app/slides/ru/import/jpg-to-ppt) и [PNG в PowerPoint](https://products.aspose.app/slides/ru/import/png-to-ppt) — которые позволяют быстро создавать презентации из изображений.
{{% /alert %}}

## **FAQ**

**Как узнать, какие форматы изображений поддерживаются для PictureFrame?**

Aspose.Slides поддерживает как растровые изображения (PNG, JPEG, BMP, GIF и т.д.), так и векторные (например, SVG) через объект изображения, присваиваемый [PictureFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframe/). Список поддерживаемых форматов в целом совпадает с возможностями движка преобразования слайдов и изображений.

**Как добавление десятков больших изображений отразится на размере и производительности PPTX?**

Встраивание больших изображений увеличивает размер файла и потребление памяти; связывание изображений помогает уменьшить размер презентации, но требует постоянного доступа к внешним файлам. Aspose.Slides предоставляет возможность добавлять изображения по ссылке для снижения размера файла.

**Как заблокировать объект изображения от случайного перемещения/изменения размера?**

Используйте [shape locks](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframe/picture_frame_lock/) для [PictureFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframe/) (например, отключите перемещение или изменение размера). Механизм блокировки описан для фигур в отдельной [статье о защите](/slides/ru/python-net/applying-protection-to-presentation/) и поддерживается различными типами фигур, включая [PictureFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframe/).

**Сохраняется ли векторная точность SVG при экспорте презентации в PDF/изображения?**

Aspose.Slides позволяет извлекать SVG из [PictureFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframe/) как оригинальный вектор. При [экспорте в PDF](/slides/ru/python-net/convert-powerpoint-to-pdf/) или [растровые форматы](/slides/ru/python-net/convert-powerpoint-to-png/) результат может быть растровым в зависимости от настроек экспорта; факт того, что оригинальный SVG хранится как вектор, подтверждается поведением функции извлечения.