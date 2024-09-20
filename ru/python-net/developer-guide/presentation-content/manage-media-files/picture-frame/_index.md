---
title: Рамка для изображения
type: docs
weight: 10
url: /python-net/picture-frame/
keywords: "Добавить рамку для изображения, создать рамку для изображения, добавить изображение, создать изображение, извлечь изображение, свойство StretchOff, форматирование рамки для изображения, свойства рамки для изображения, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Добавление рамки для изображения в презентацию PowerPoint на Python"
---

Рамка для изображения — это фигура, содержащая изображение; это как картина в рамке.

Вы можете добавить изображение на слайд через рамку для изображения. Таким образом, вы можете отформатировать изображение, отформатировав рамку для изображения.

{{% alert  title="Совет" color="primary" %}} 

Aspose предоставляет бесплатные конвертеры — [JPEG в PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) и [PNG в PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — которые позволяют людям быстро создавать презентации из изображений. 

{{% /alert %}} 

## **Создание рамки для изображения**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). 
2. Получите ссылку на слайд через его индекс. 
3. Создайте объект [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) добавив изображение в коллекцию [IImages](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) связанной с объектом презентации, который будет использоваться для заполнения фигуры.
4. Укажите ширину и высоту изображения.
5. Создайте [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) на основе ширины и высоты изображения через метод `AddPictureFrame`, предоставляемый объектом фигуры, связанным с слайдом по ссылке.
6. Добавьте рамку для изображения (содержащую изображение) на слайд.
7. Запишите изменённую презентацию как PPTX файл.

Этот код на Python показывает вам, как создать рамку для изображения:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Создает экземпляр класса Presentation, который представляет файл PPTX
with slides.Presentation() as pres:
    # Получает первый слайд
    sld = pres.slides[0]

    # Создает экземпляр класса ImageEx
    with open("img.jpeg", "rb") as in_file:
        image = pres.images.add_image(in_file)

        # Добавляет рамку с эквивалентной высотой и шириной изображения
        pf = sld.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 150, image.width, image.height, image)

        # Применяет некоторые форматы к PictureFrameEx
        pf.line_format.fill_format.fill_type = slides.FillType.SOLID
        pf.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        pf.line_format.width = 20
        pf.rotation = 45

        # Записывает файл PPTX на диск
        pres.save("RectPicFrameFormat_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}} 

Рамки для изображений позволяют быстро создавать слайды презентации на основе изображений. Когда вы комбинируете рамку для изображения с параметрами сохранения Aspose.Slides, вы можете манипулировать операциями ввода/вывода для конвертации изображений из одного формата в другой. Вам могут быть интересны эти страницы: конвертировать [изображение в JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); конвертировать [JPG в изображение](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); конвертировать [JPG в PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/), конвертировать [PNG в JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); конвертировать [PNG в SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/), конвертировать [SVG в PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).

{{% /alert %}}

## **Создание рамки для изображения с относительным масштабом**

Изменяя относительное масштабирование изображения, вы можете создать более сложную рамку для изображения. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд через его индекс. 
3. Добавьте изображение в коллекцию изображений презентации.
4. Создайте объект [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) добавив изображение в коллекцию [IImages](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) связанную с объектом презентации, который будет использоваться для заполнения фигуры.
5. Укажите относительную ширину и высоту изображения в рамке для изображения.
6. Запишите изменённую презентацию как PPTX файл.

Этот код на Python показывает вам, как создать рамку для изображения с относительным масштабом:

```py
import aspose.slides as slides

# Создает экземпляр класса Presentation, который представляет файл PPTX
with slides.Presentation() as presentation:
    # Загружает изображение, которое будет добавлено в коллекцию изображений презентации
    with open("img.jpeg", "rb") as in_file:
        image = presentation.images.add_image(in_file)

        # Добавляет рамку для изображения на слайд
        pf = presentation.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Устанавливает относительное масштабирование ширины и высоты
        pf.relative_scale_height = 0.8
        pf.relative_scale_width = 1.35

        # Сохраняет презентацию
        presentation.save("Adding Picture Frame with Relative Scale_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Извлечение изображения из рамки для изображения**

Вы можете извлекать изображения из объектов [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) и сохранять их в формате PNG, JPG и других форматах. Пример кода ниже демонстрирует, как извлечь изображение из документа "sample.pptx" и сохранить его в формате PNG.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **Получение прозрачности изображения**

Aspose.Slides позволяет вам получать прозрачность изображения. Этот код на Python демонстрирует операцию: 

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    pictureFrame = presentation.slides[0].shapes[0]
    imageTransform = pictureFrame.picture_format.picture.image_transform
    for effect in imageTransform:
        if type(effect) is slides.AlphaModulateFixed:
            transparencyValue = 100 - effect.amount
            print("Прозрачность изображения: " + str(transparencyValue))
```

## **Форматирование рамки для изображения**

Aspose.Slides предоставляет множество параметров форматирования, которые можно применить к рамке для изображения. Используя эти параметры, вы можете изменить рамку для изображения, чтобы она соответствовала определенным требованиям.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/) .
2. Получите ссылку на слайд через его индекс. 
3. Создайте объект [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage) добавив изображение в коллекцию [IImages](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) связанную с объектом презентации, который будет использоваться для заполнения фигуры.
4. Укажите ширину и высоту изображения.
5. Создайте `PictureFrame` на основе ширины и высоты изображения через метод [AddPictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) предоставленный объектом [IShapes](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection) связанным с ссылкой на слайд.
6. Добавьте рамку для изображения (содержащую изображение) на слайд.
7. Установите цвет линии рамки для изображения.
8. Установите ширину линии рамки для изображения.
9. Поверните рамку для изображения, задав положительное или отрицательное значение.
   * Положительное значение поворачивает изображение по часовой стрелке. 
   * Отрицательное значение поворачивает изображение против часовой стрелки.
10. Добавьте рамку для изображения (содержащую изображение) на слайд.
11. Запишите изменённую презентацию как PPTX файл.

Этот код на Python демонстрирует процесс форматирования рамки для изображения:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Создает экземпляр класса Presentation, который представляет файл PPTX
with slides.Presentation() as pres:
    # Получает первый слайд
    sld = pres.slides[0]

    with open("img.jpeg", "rb") as in_file:
        imgx = pres.images.add_image(in_file)

         # Добавляет рамку для изображения с эквивалентной высотой и шириной изображения
        pf = sld.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 150, imgx.width, imgx.height, imgx)

        # Применяет некоторые форматы к PictureFrameEx
        pf.line_format.fill_format.fill_type = slides.FillType.SOLID
        pf.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        pf.line_format.width = 20
        pf.rotation = 45

    # Записывает файл PPTX на диск
    pres.save("RectPicFrameFormat_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Совет" color="primary" %}}

Aspose недавно разработал [бесплатный Конструктор Коллажей](https://products.aspose.app/slides/collage). Если вам когда-либо нужно будет [объединить JPG/JPEG](https://products.aspose.app/slides/collage/jpg) или PNG изображения, [создать сетки из фотографий](https://products.aspose.app/slides/collage/photo-grid), вы можете воспользоваться этой услугой. 

{{% /alert %}}

## **Добавление изображения в качестве ссылки**

Чтобы избежать больших размеров презентации, вы можете добавлять изображения (или видео) по ссылкам вместо того, чтобы встраивать файлы непосредственно в презентацию. Этот код на Python показывает вам, как добавить изображение и видео в заполнители:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapesToRemove = []

    for autoShape in presentation.slides[0].shapes:
        if autoShape.placeholder is None:
            continue
        
        if autoShape.placeholder.type == slides.PlaceholderType.PICTURE:
            pictureFrame = presentation.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE,
                    autoShape.x, autoShape.y, autoShape.width, autoShape.height, None)

            pictureFrame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            shapesToRemove.append(autoShape)

        elif autoShape.placeholder.type == slides.PlaceholderType.MEDIA:
            videoFrame = presentation.slides[0].shapes.add_video_frame(
                autoShape.X, autoShape.Y, autoShape.width, autoShape.height, "")

            videoFrame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            videoFrame.link_path_long = "https://youtu.be/t_1LYZ102RA"
            shapesToRemove.append(autoShape)
        
    

    for shape in shapesToRemove:
        presentation.slides[0].shapes.remove(shape)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Обрезка изображения**

Этот код на Python показывает вам, как обрезать существующее изображение на слайде:

``` py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Создает новый объект изображения
    newImage = presentation.images.add_image(slides.Images.from_file(imagePath))

    # Добавляет рамку для изображения на слайд
    picFrame = presentation.slides[0].shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE, 100, 100, 420, 250, newImage)

    # Обрезает изображение (значения в процентах)
    picFrame.picture_format.crop_left = 23.6
    picFrame.picture_format.crop_right = 21.5
    picFrame.picture_format.crop_top = 3
    picFrame.picture_format.crop_bottom = 31

    # Сохраняет результат
    presentation.save(outPptxFile, slides.export.SaveFormat.PPTX)

```

## Удаление обрезанных областей изображения

Если вы хотите удалить обрезанные области изображения, содержащегося в рамке, вы можете использовать метод [delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/ipicturefillformat/). Этот метод возвращает обрезанное изображение или исходное изображение, если обрезка не нужна.

Этот код на Python демонстрирует операцию:

```python
import aspose.slides as slides

with slides.Presentation(path + "PictureFrameCrop.pptx") as pres:
    slide = pres.slides[0]

    # Получает рамку для изображения с первого слайда
    picture_frame = slides.shape[0]

    # Удаляет обрезанные области изображения рамки для изображения и возвращает обрезанное изображение
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # Сохраняет результат
    pres.save(path + "PictureFrameDeleteCroppedAreas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="ПРИМЕЧАНИЕ" color="warning" %}} 

Метод delete_picture_cropped_areas добавляет обрезанное изображение в коллекцию изображений презентации. Если изображение используется только в обработанной [рамке для изображения](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), эта настройка может уменьшить размер презентации. В противном случае количество изображений в результирующей презентации увеличится.

Этот метод преобразует метафайлы WMF/EMF в растровое изображение PNG в процессе обрезки. 

{{% /alert %}}

## **Блокировка соотношения сторон**

Если вы хотите, чтобы фигура, содержащая изображение, сохраняла свое соотношение сторон, даже после изменения размеров изображения, вы можете использовать свойство *aspect_ratio_locked*, чтобы установить параметр *Блокировка соотношения сторон*. 

Этот код на Python показывает вам, как заблокировать соотношение сторон фигуры: 

```python
from aspose.slides import SlideLayoutType, Presentation, ShapeType
from aspose.pydrawing import Image

with Presentation("pres.pptx") as pres:
    layout = pres.layout_slides.get_by_type(SlideLayoutType.CUSTOM)
    emptySlide = pres.slides.add_empty_slide(layout)
    image = Image.from_file("image.png")
    presImage = pres.images.add_image(image)

    pictureFrame = emptySlide.shapes.add_picture_frame(ShapeType.RECTANGLE, 50, 150, presImage.width, presImage.height, presImage)

    # Устанавливает фигуру для сохранения соотношения сторон при изменении размеров
    pictureFrame.picture_frame_lock.aspect_ratio_locked = True
```

{{% alert title="ПРИМЕЧАНИЕ" color="warning" %}} 

Эта настройка *Блокировка соотношения сторон* сохраняет только соотношение сторон фигуры, а не изображения, которое она содержит.

{{% /alert %}}

## **Использование свойства StretchOff**

Используя свойства `StretchOffsetLeft`, `StretchOffsetTop`, `StretchOffsetRight` и `StretchOffsetBottom` интерфейса [IPictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ipicturefillformat/) и класса [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/), вы можете задать заполненный прямоугольник. 

Когда для изображения задается масштабирование, исходный прямоугольник масштабируется, чтобы соответствовать указанному заполненному прямоугольнику. Каждый край заполненного прямоугольника определяется процентным смещением от соответствующего края ограничивающего прямоугольника фигуры. Положительный процент указывает на вкладку, в то время как отрицательный процент указывает на вылет.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/) .
2. Получите ссылку на слайд через его индекс.
3. Добавьте прямоугольник `AutoShape`. 
4. Создайте изображение.
5. Установите тип заполнения фигуры.
6. Установите режим заполнения фигурой.
7. Добавьте устанавливаемое изображение для заполнения фигуры.
8. Укажите смещения изображения от соответствующего края ограничивающего прямоугольника фигуры.
9. Запишите изменённую презентацию как PPTX файл.

Этот код на Python демонстрирует процесс, в котором используется свойство StretchOff:

```py
import aspose.slides as slides

# Создает экземпляр класса Presentation, который представляет файл PPTX
with slides.Presentation() as pres:

    # Получает первый слайд
    slide = pres.slides[0]

    # Создает экземпляр класса ImageEx
    with open("img.jpeg", "rb") as in_file:
        imgx = pres.images.add_image(in_file)

        # Добавляет рамку для изображения с эквивалентной высотой и шириной изображения
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

        # Устанавливает тип заполнения фигуры
        shape.fill_format.fill_type = slides.FillType.PICTURE

        # Устанавливает режим заполнения фигурой
        shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

        # Устанавливает изображение для заполнения фигуры
        shape.fill_format.picture_fill_format.picture.image = imgx

        # Указывает смещения изображения от соответствующего края ограничивающего прямоугольника фигуры
        shape.fill_format.picture_fill_format.stretch_offset_left = 25
        shape.fill_format.picture_fill_format.stretch_offset_right = 25
        shape.fill_format.picture_fill_format.stretch_offset_top = -20
        shape.fill_format.picture_fill_format.stretch_offset_bottom = -10
    
    # Записывает файл PPTX на диск
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", slides.export.SaveFormat.PPTX)
```