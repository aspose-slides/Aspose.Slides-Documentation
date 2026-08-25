---
title: Управление кадрами изображений в презентациях с помощью Python
linktitle: Кадр изображения
type: docs
weight: 10
url: /ru/python-net/picture-frame/
keywords:
- кадр изображения
- добавить кадр изображения
- создать кадр изображения
- встроенное изображение
- связанное изображение
- извлечь изображение
- растровое изображение
- SVG-изображение
- обрезать изображение
- удалить обрезанные области
- сжать изображение
- смещение растяжения
- форматирование кадра изображения
- относительный масштаб
- эффект изображения
- соотношение сторон
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Создавайте, форматируйте, связывайте, обрезайте, извлекайте и сжимайте кадры изображений в презентациях с помощью Aspose.Slides для Python через .NET."
---
## **Обзор**

PictureFrame — это форма слайда, отображающая изображение. В Aspose.Slides ресурс изображения и форма, которая его отображает, являются отдельными объектами: объект [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) владеет встроенными ресурсами изображений через свой [ImageCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/imagecollection/), а объект [PictureFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframe/) управляет позицией изображения, его размером, форматированием линии, вращением, обрезкой, эффектами изображения и другими настройками уровня кадра.

Такое разделение полезно, когда одно и то же изображение показывается более одного раза. Добавьте изображение в презентацию один раз, сохраните полученный объект [PPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/), и используйте этот ресурс изображения при создании кадров.

Кадры могут содержать растровые изображения, такие как PNG или JPEG, а также векторные изображения SVG. Они также могут ссылаться на связанные изображения вместо хранения байтов изображения в презентации. Выбор влияет на переносимость, размер файла, извлечение и поведение экспорта, поэтому полезно решить, как изображение должно храниться, до применения форматирования или оптимизации.

## **Добавление и форматирование встроенного изображения**

Для встроенного изображения добавьте данные изображения в презентацию и создайте кадр с помощью [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapecollection/add_picture_frame/). Изображение становится частью пакета презентации, поэтому презентация остаётся автономной при перемещении на другой компьютер.

Следующий пример добавляет JPEG‑изображение, создаёт кадр с исходными размерами изображения и применяет форматирование линии и вращение:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
    picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    picture_frame.line_format.width = 3
    picture_frame.rotation = 15

    presentation.save("picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

Кадр управляет отображаемой геометрией; изменение размера кадра не меняет исходные пиксельные размеры, хранящиеся во встроенном ресурсе изображения. Это различие становится важным при последующей обрезке или сжатии изображения.

## **Использование относительного масштаба**

[PictureFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframe/) предоставляет свойства [relative_scale_width](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframe/relative_scale_width/) и [relative_scale_height](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframe/relative_scale_height/) для кадра. Значение `1.0` соответствует 100 % оригинального размера картинки. Относительный масштаб полезен, когда рабочий процесс требует сохранять отношение к исходному размеру изображения вместо расчёта окончательных размеров вручную.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)
    picture_frame.relative_scale_width = 1.35
    picture_frame.relative_scale_height = 0.8

    presentation.save("relative-scale.pptx", slides.export.SaveFormat.PPTX)
```

Относительный масштаб изменяет настройки масштаба кадра; он не пересчитывает и не сжимает встроенное изображение.

## **Встроенные и связанные изображения**

Встроенная картинка хранит данные изображения внутри презентации и поэтому является самым надёжным выбором для переносимости и предсказуемого рендеринга. Связанная картинка сохраняет внешний путь через ссылку [Picture](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picture/) вместо встраивания данных изображения тем же способом.

Связанные изображения могут уменьшить объём данных изображения, хранящихся в PPTX, но вводят внешнюю зависимость. Связанный файл должен оставаться доступным приложению, которое открывает или рендерит презентацию. Если путь изменится, файл будет перемещён или ресурс недоступен, связанная картинка может не отобразиться должным образом. Для презентаций, которые должны отправляться по электронной почте, архивироваться или рендериться в изолированных средах, встроенные изображения обычно более надёжны.

### **Добавление связанного изображения**

Следующий пример создаёт кадр и указывает его на локальный файл изображения. Пример касается только связывания изображений; связывание видео — это отдельный медиа‑рабочий процесс и намеренно не смешивается с этим примером.

```python
import os
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 320, 180, None)
    linked_image_path = os.path.abspath("linked-image.jpg")
    picture_frame.picture_format.picture.link_path_long = linked_image_path

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

Используйте ссылки, когда управление внешними файлами намеренно. Не используйте их просто как замену сжатию: небольшой PPTX с нарушенными зависимостями изображений обычно менее полезен, чем более крупная автономная презентация.

## **Извлечение изображений из кадров**

Прежде чем извлекать изображение из существующей презентации, проверьте, является ли форма действительно [PictureFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframe/) и содержит ли она встроенное изображение. Связанные кадры могут не содержать байтов изображения, которые можно извлечь тем же способом.

### **Извлечение растрового изображения**

Современный API изображений использует [IImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iimage/) напрямую. Следующий пример находит первое встроенное растровое изображение на слайде и сохраняет его как PNG:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        if embedded_image is None or embedded_image.svg_image is not None:
            continue

        raster_image = embedded_image.image
        raster_image.save("extracted-image.png", slides.ImageFormat.PNG)
        break
```

Сохранение через [IImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iimage/) преобразует извлечённое изображение в требуемый формат вывода. Если вам нужны закодированные байты, хранящиеся в презентации, а не преобразованный растровый файл, используйте свойство [PPImage.binary_data](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/binary_data/).

### **Извлечение SVG‑изображения**

Для SVG‑картинки объект [PPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/) предоставляет объект [SvgImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/svgimage/). Это позволяет получить SVG‑данные напрямую, без предварительного растеризования картинки.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        svg_image = embedded_image.svg_image if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = bytes(svg_image.svg_data)
        with open("extracted-image.svg", "wb") as svg_stream:
            svg_stream.write(svg_data)
        break
```

Сохранение SVG‑контента как SVG сохраняет векторный источник внутри презентации. Растровый экспорт, такой как PNG или JPEG, неизбежно рендерит векторный контент в пиксели. Экспорт слайдов в PDF или SVG также является операцией рендеринга, поэтому экспортированная графика не должна рассматриваться как побайтовая копия оригинального встроенного SVG; используйте встроенный [SvgImage.svg_data](https://reference.aspose.com/slides/ru/python-net/aspose.slides/svgimage/svg_data/), когда требуется сам векторный ресурс.

## **Обрезка изображения**

Обрезка изменяет видимую часть изображения внутри кадра. Значения обрезки в [PictureFillFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picturefillformat/) задаются в процентах от размеров исходного изображения. Обрезка изначально не удаляет скрытые пиксели из встроенного изображения; она лишь меняет видимую область.

Следующий пример безопасно находит кадр и применяет значения обрезки:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.picture_format.crop_left = 23.6
        picture_frame.picture_format.crop_right = 21.5
        picture_frame.picture_format.crop_top = 3
        picture_frame.picture_format.crop_bottom = 31
        presentation.save("cropped-image.pptx", slides.export.SaveFormat.PPTX)
```

Поскольку скрытые данные изображения всё ещё присутствуют, обрезку можно изменить позже без потери оригинальных пикселей. Если важен размер файла больше, чем обратимость, обрезанные области можно физически удалить, как описано в следующем разделе.

## **Удаление данных обрезанных изображений**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) удаляет данные изображения за пределами текущего прямоугольника обрезки и возвращает полученный ресурс изображения. Это может уменьшить размер файла, но является деструктивной оптимизацией: после сохранения презентации удалённые пиксели больше недоступны для последующей операции «разобрезки».

```python
import aspose.slides as slides

with slides.Presentation("cropped-image.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", slides.export.SaveFormat.PPTX)
```

Метод может добавить новый ресурс изображения в презентацию. Если оригинальное изображение также используется другими кадрами, эти кадры всё равно нуждаются в своём текущем ресурсе, поэтому удаление обрезанных областей не обязательно уменьшает общее количество изображений. Обрезка содержимого WMF или EMF этим методом растеризует результат в PNG.

## **Сжатие растровых изображений**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picturefillformat/compress_image/) уменьшает разрешение растрового изображения относительно размера, при котором картинка отображается. Он также может удалить обрезанные области в той же операции. Метод возвращает `True`, когда изображение было изменено в размере или обрезано, и `False`, когда изменений не требовалось.

Используйте предопределённое значение [PicturesCompression](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/picturescompression/), когда достаточно стандартного целевого разрешения:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", slides.export.SaveFormat.PPTX)
```

Вместо enum‑значения можно передать пользовательское положительное значение DPI, когда требуется конкретное целевое разрешение.

Сжатие предназначено для растровых изображений. SVG‑ и метафайлы не уменьшаются этим растровым процессом. Также помните, что более низкое разрешение и удалённые обрезанные области нельзя восстановить из оптимизированной презентации. Выбирайте целевое разрешение, исходя из максимального размера, с которым изображение будет просматриваться или экспортироваться, а не из минимального DPI для всей презентации.

## **Управление эффектами трансформации изображения**

Для полного рабочего процесса, охватывающего яркость, контраст, цветовые трансформации, размытие, альфа‑эффекты, упорядоченные цепочки, проверку и обратную верификацию, см. [Image Transform Effects](/slides/ru/python-net/image-transform-effects/).

## **Блокировка геометрии кадра**

Настройки [PictureFrameLock](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframelock/) управляют тем, какие операции редактирования отключены для кадра. Например, свойство [aspect_ratio_locked](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) сохраняет пропорции формы при её изменении размера.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("locked-picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

Блокировка применяется к форме кадра. Она не принуждает исходное изображение к пересэмплированию или постоянному изменению пропорций.

## **Настройка значений StretchOffset**

Когда режим заполнения картинки — stretch, значения stretch‑offset в [PictureFillFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picturefillformat/) определяют прямоугольник заполнения относительно ограничивающего бокса кадра. Положительные проценты создают отступ от края, отрицательные — выступ.

Это отличается от обрезки. Параметры обрезки выбирают, какая часть исходного изображения видима; stretch‑offset изменяют прямоугольник, в который растягивается видимая заполненная картинка.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 400, 300, image)
    picture_frame.picture_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    picture_frame.picture_format.stretch_offset_left = 12
    picture_frame.picture_format.stretch_offset_right = 12
    picture_frame.picture_format.stretch_offset_top = 8
    picture_frame.picture_format.stretch_offset_bottom = 8

    presentation.save("stretch-offsets.pptx", slides.export.SaveFormat.PPTX)
```

Используйте stretch‑offset для размещения заполнения. Используйте параметры обрезки, когда цель — скрыть края исходного изображения.

## **Хранение, размер файла и соображения экспорта**

Основные компромиссы легче управлять, когда хранение изображений и форматирование кадра рассматриваются отдельно:

- **Встроенные изображения** делают презентацию автономной и являются наиболее надёжными для совместного использования и серверного рендеринга, но крупные растровые изображения увеличивают размер PPTX и потребление памяти.
- **Связанные изображения** могут уменьшить размер пакета, но презентация зависит от доступности внешних файлов по указанным путям.
- **Обрезка** изначально не разрушительна. Скрытые пиксели остаются встроенными до тех пор, пока обрезанные области не будут явно удалены или удалены во время сжатия.
- **Сжатие** может существенно уменьшить размер файла для слишком больших растровых изображений, но отдаёт предпочтение исходному разрешению. Применять его следует после того, как известен окончательный размер изображения на слайде.
- **SVG‑изображения** следует оставлять в виде SVG, когда важна векторная точность. Извлекайте встроенный SVG напрямую, когда нужен сам векторный ресурс. Растровый экспорт слайдов всегда преобразует отрисованный слайд в пиксели.
- **Повторяющиеся изображения** следует переиспользовать существующий ресурс [PPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/), когда это возможно, вместо многократной загрузки одного и того же файла в рабочий процесс презентации.

Для больших презентаций оптимизация изображений обычно наиболее эффективна при выборочном применении: держите логотипы и схемы в векторном виде, сжимайте фотографии в соответствии с их реальным размером отображения, удаляйте обрезанные пиксели только когда дальнейшее редактирование не требуется, и избегайте внешних ссылок, если только управление зависимостями не является частью дизайна развертывания.

## **FAQ**

**В чём разница между кадром изображения и ресурсом изображения?**

[PPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/) представляет ресурс изображения, связанный с презентацией. [PictureFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframe/) — это форма на слайде, отображающая изображение и хранящая геометрию и форматирование уровня кадра, такие как размер, вращение, значения обрезки, эффекты и блокировки.

**Стоит ли встраивать или связывать изображения?**

Встраивайте изображения, когда презентация должна быть переносимой, архивируемой или рендериться без доступа к внешним ресурсам. Связывайте изображения только когда намеренно хранить файлы изображений вне PPTX и внешние расположения могут быть надёжно поддержаны.

**Уменьшает ли обрезка размер файла PPTX?**

Не сама по себе. Обычные настройки обрезки скрывают части исходного изображения, но сохраняют подлежащие пиксели. Используйте [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) или сжатие изображения с удалением обрезанных областей, когда эти пиксели могут быть окончательно удалены.

**Можно ли восстановить качество изображения после сжатия?**

Нет. Сжатие может уменьшить сохранённое растровое разрешение, а удаление обрезанных областей отбрасывает данные изображения. Храните оригинальное исходное изображение вне презентации, если позже может потребоваться редактирование в высоком разрешении.

**Как следует обращаться с SVG‑изображениями?**

Сохраняйте SVG‑контент как SVG, когда важна векторная точность. Встроенный [SvgImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/svgimage/) можно извлечь напрямую. Рендеринг слайда в растровый формат, такой как PNG или JPEG, растеризует SVG как часть изображения слайда.

**Как избежать небезопасных привидений при чтении существующих слайдов?**

Проверьте тип формы перед использованием членов, специфичных для кадра. Использование `isinstance(shape, slides.PictureFrame)` предотвращает недопустимые приведения типов и позволяет коду корректно обрабатывать слайды, не содержащие кадры.