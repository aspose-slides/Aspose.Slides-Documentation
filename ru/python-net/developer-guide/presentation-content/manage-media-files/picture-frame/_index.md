---
title: Добавьте рамки изображений в презентации с помощью Python
linktitle: Рамка изображения
type: docs
weight: 10
url: /ru/python-net/picture-frame/
keywords:
- рамка изображения
- добавить рамку изображения
- создать рамку изображения
- добавить изображение
- создать изображение
- извлечь изображение
- растровое изображение
- векторное изображение
- обрезать изображение
- обрезанная область
- свойство StretchOff
- форматирование рамки изображения
- свойства рамки изображения
- относительный масштаб
- эффект изображения
- соотношение сторон
- прозрачность изображения
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Добавляйте рамки изображений в презентации PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET. Оптимизируйте рабочий процесс и улучшайте дизайн слайдов."
---

## **Обзор**

Рамки изображений в Aspose.Slides для Python позволяют размещать и управлять растровыми и векторными изображениями как нативными фигурами слайда. Вы можете вставлять изображения из файлов или потоков, позиционировать и менять их размер с точными координатами, применять вращение, задавать прозрачность и контролировать порядок наложения вместе с другими фигурами. API также поддерживает обрезку, сохранение соотношения сторон, установку границ и эффектов, а также замену базового изображения без перестройки макета. Поскольку рамки изображений ведут себя как обычные фигуры, к ним можно добавлять анимацию, гиперссылки и альтернативный текст, что упрощает создание визуально насыщенных и доступных презентаций.

## **Создание рамок изображений**

В этом разделе показано, как вставить изображение в слайд, создав [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) с помощью Aspose.Slides для Python. Вы узнаете, как загрузить изображение, точно разместить его на слайде и управлять его размером и форматированием.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите слайд по его индексу.
3. Создайте [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/), добавив изображение в [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) презентации. Это изображение будет использоваться для заполнения фигуры.
4. Укажите ширину и высоту рамки.
5. Создайте [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) нужного размера с помощью метода [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/).
6. Сохраните презентацию в файл PPTX.

Ниже приведён пример кода на Python, показывающий, как создать рамку изображения:

```py
import aspose.slides as slides

# Instantiate the Presentation class to represent a PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add the image to the presentation.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Add a picture frame sized to the image.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Save the presentation as PPTX.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}

Рамки изображений позволяют быстро создавать слайды презентаций из изображений. Комбинируя рамки изображений с параметрами сохранения Aspose.Slides, вы можете управлять операциями ввода‑вывода для конвертации изображений из одного формата в другой. Возможно, вас заинтересуют следующие страницы: конвертация [изображения в JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); конвертация [JPG в изображение](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); конвертация [JPG в PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/); конвертация [PNG в JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); конвертация [PNG в SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/); конвертация [SVG в PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).

{{% /alert %}}

## **Создание рамок изображений с относительным масштабом**

В этом разделе демонстрируется размещение изображения фиксированного размера, а затем применение процентного масштабирования независимо по ширине и высоте. Поскольку проценты могут различаться, соотношение сторон может измениться. Масштабирование выполняется относительно оригинальных размеров изображения.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите слайд по его индексу.
3. Создайте [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/), добавив изображение в [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) презентации.
4. Добавьте [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) на слайд.
5. Установите относительные значения ширины и высоты рамки.
6. Сохраните презентацию в файл PPTX.

Ниже пример кода на Python, показывающий, как создать рамку изображения с относительным масштабом:

```py
import aspose.slides as slides

# Instantiate the Presentation class to represent a PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add the image to the presentation's image collection.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Add a picture frame to the slide.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Set the relative scale width and height.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # Save the presentation.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **Извлечение растровых изображений из рамок**

Вы можете извлекать растровые изображения из объектов [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) и сохранять их в PNG, JPG и других форматах. Пример кода ниже демонстрирует, как извлечь изображение из документа «sample.pptx» и сохранить его в формате PNG.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **Извлечение SVG‑изображений из рамок**

Когда презентация содержит SVG‑графику, помещённую внутри фигур [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), Aspose.Slides для Python через .NET позволяет получить оригинальные векторные изображения с полной точностью. Просматривая коллекцию фигур слайда, вы можете определить каждую [PictureFrame], проверить, хранит ли лежащее в основе [PPImage] SVG‑контент, и затем сохранить это изображение в файл или поток в его нативном SVG‑формате.

Ниже пример кода, показывающий, как извлечь SVG‑изображение из рамки:

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

Aspose.Slides позволяет получить эффект прозрачности, применённый к изображению. Ниже показан соответствующий код на Python:

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
Все эффекты, применённые к изображениям, можно найти в [aspose.slides.effects](https://reference.aspose.com/slides/python-net/aspose.slides.effects/).
{{% /alert %}}

## **Форматирование рамки изображения**

Aspose.Slides предоставляет множество параметров форматирования, которые можно применить к рамке изображения. С их помощью можно настроить рамку под конкретные требования.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите слайд по его индексу.
3. Создайте [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/), добавив изображение в [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) презентации. Это изображение будет использоваться для заполнения фигуры.
4. Укажите ширину и высоту рамки.
5. Создайте [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) нужного размера с помощью метода [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) слайда.
6. Установите цвет линии рамки.
7. Установите толщину линии рамки.
8. Поверните рамку, задав положительное (по часовой стрелке) или отрицательное (против часовой стрелки) значение.
9. Сохраните изменённую презентацию в файл PPTX.

Пример кода на Python, демонстрирующий процесс форматирования рамки изображения:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class to represent a PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add the image to the presentation's image collection.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Add a picture frame sized to the image.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Apply formatting to the picture frame.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # Save the presentation as PPTX.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}

Aspose разработала бесплатный сервис [Collage Maker](https://products.aspose.app/slides/collage). Если нужно [объединить JPG/JPEG](https://products.aspose.app/slides/collage/jpg) или PNG‑изображения, либо [создать фотогриды](https://products.aspose.app/slides/collage/photo-grid), воспользуйтесь этим сервисом.
{{% /alert %}}

## **Добавление изображений как ссылок**

Чтобы уменьшить размер файлов презентаций, можно добавлять изображения или видео через ссылки, а не встраивать файлы непосредственно в презентацию. Ниже показан код на Python, который вставляет изображение и видео в заполнитель:

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

## **Обрезка изображений**

В этом разделе вы узнаете, как обрезать видимую область изображения внутри рамки без изменения исходного файла. Вы также изучите базовый метод применения полей обрезки для создания чистой, сфокусированной композиции непосредственно на слайде.

Пример кода на Python, показывающий, как обрезать изображение на слайде:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add the image to the presentation's image collection.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Add a picture frame to the slide.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # Crop the image (percentage values).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # Save the result.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Удаление обрезанных областей изображений**

Если необходимо удалить обрезанные области изображения в рамке, используйте метод [delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/). Этот метод возвращает обрезанное изображение или оригинальное, если обрезка не требуется.

Пример кода на Python, демонстрирующий эту операцию:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Get the PictureFrame from the first slide.
    picture_frame = slides.shape[0]

    # Get the PictureFrame from the first slide.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # Save the result.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

Метод [delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) добавляет обрезанное изображение в коллекцию изображений презентации. Если изображение используется только в обработанной [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), это может уменьшить размер презентации; в противном случае количество изображений в полученной презентации может увеличиться.

Во время обрезки метод преобразует метафайлы WMF/EMF в растровое PNG‑изображение.
{{% /alert %}}

## **Блокировка соотношения сторон**

Если необходимо, чтобы фигура, содержащая изображение, сохраняла своё соотношение сторон после изменения размеров изображения, установите свойство [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) в значение `True`.

Пример кода на Python, показывающий, как заблокировать соотношение сторон фигуры:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # Lock the aspect ratio when resizing.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

Эта настройка *Блокировка соотношения сторон* сохраняет только соотношение сторон фигуры, а не изображение внутри неё.
{{% /alert %}}

## **Использование свойств смещения растяжения**

С помощью свойств `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right` и `stretch_offset_bottom` класса [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) можно задать прямоугольник заполнения.

Когда для изображения указана растяжка, исходный прямоугольник масштабируется до размеров прямоугольника заполнения. Каждая граница прямоугольника заполнения определяется процентным смещением от соответствующей границы ограничивающего прямоугольника фигуры. Положительный процент задаёт отступ внутрь, отрицательный — наружу.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте прямоугольную [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
4. Установите тип заполнения фигуры.
5. Установите режим заполнения фигурой изображением.
6. Загрузите изображение.
7. Присвойте изображение для заполнения фигуры.
8. Укажите смещения изображения от соответствующих границ ограничивающего прямоугольника фигуры.
9. Сохраните презентацию в файл PPTX.

Пример кода на Python, демонстрирующий использование свойств смещения растяжения:

```py
import aspose.slides as slides

# Instantiate the Presentation class that represents a PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add a rectangle AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # Set the shape's fill type.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Set the shape's picture fill mode.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Load the image and add it to the presentation.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # Assign the image to fill the shape.
    shape.fill_format.picture_fill_format.picture.image = image

    # Specify image offsets from the corresponding edges of the shape's bounding box.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # Save the PPTX file to disk.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}

Aspose предоставляет бесплатные конвертеры — [JPEG в PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) и [PNG в PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — которые позволяют быстро создавать презентации из изображений.
{{% /alert %}}

## **FAQ**

**Как узнать, какие форматы изображений поддерживаются для PictureFrame?**

Aspose.Slides поддерживает как растровые изображения (PNG, JPEG, BMP, GIF и т.д.), так и векторные (например, SVG) через объект изображения, назначенный [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/). Список поддерживаемых форматов в целом совпадает с возможностями движка конвертации слайдов и изображений.

**Как добавление десятков больших изображений влияет на размер и производительность PPTX?**

Встраивание больших изображений увеличивает размер файла и объем памяти; использование ссылок на изображения помогает уменьшить размер презентации, но требует доступности внешних файлов. Aspose.Slides предоставляет возможность добавлять изображения по ссылке для снижения размера файла.

**Как заблокировать объект изображения от случайного перемещения/изменения размеров?**

Используйте [блокировки фигур](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/picture_frame_lock/) для [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) (например, отключить перемещение или изменение размеров). Механизм блокировки описан в отдельной статье о защите [здесь](/slides/ru/python-net/applying-protection-to-presentation/) и поддерживается для различных типов фигур, включая [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).

**Сохраняется ли векторная точность SVG при экспорте презентации в PDF/изображения?**

Aspose.Slides позволяет извлечь SVG из [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) как оригинальный вектор. При [экспорте в PDF](/slides/ru/python-net/convert-powerpoint-to-pdf/) или [растровые форматы](/slides/ru/python-net/convert-powerpoint-to-png/) результат может быть растрирован в зависимости от параметров экспорта; факт того, что оригинальный SVG хранится как вектор, подтверждается поведением при извлечении.