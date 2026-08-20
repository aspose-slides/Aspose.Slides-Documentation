---
title: "Управление рамками изображений в презентациях с помощью Python"
linktitle: "Рамка изображения"
type: docs
weight: 10
url: /ru/python-net/picture-frame/
keywords:
- "рамка изображения"
- "добавить рамку изображения"
- "создать рамку изображения"
- "встроенное изображение"
- "связанное изображение"
- "извлечь изображение"
- "растровое изображение"
- "SVG‑изображение"
- "обрезка изображения"
- "удалить обрезанные области"
- "сжать изображение"
- "StretchOffset"
- "форматирование рамки изображения"
- "относительный масштаб"
- "эффект изображения"
- "соотношение сторон"
- "PowerPoint"
- "OpenDocument"
- "презентация"
- "Python"
- "Aspose.Slides"
description: "Создавайте, форматируйте, связывайте, обрезайте, извлекайте и сжимайте рамки изображений в презентациях с помощью Aspose.Slides для Python через .NET."
---
## **Обзор**

Рамка изображения — это объект слайда, отображающий изображение. В Aspose.Slides ресурс изображения и объект, отображающий его, являются отдельными объектами: [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) владеет встроенными ресурсами изображений через свою [ImageCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/imagecollection/), в то время как [PictureFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframe/) управляет положением изображения, размером, оформлением линии, вращением, обрезкой, эффектами изображения и другими настройками уровня рамки.

Это разделение полезно, когда одно и то же изображение отображается более одного раза. Добавьте изображение в презентацию один раз, сохраните возвращённый [PPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/), и используйте этот ресурс изображения при создании рамок изображений.

Рамки изображений могут содержать растровые изображения, такие как PNG или JPEG, а также векторные SVG‑изображения. Они также могут ссылаться на связанные изображения вместо того, чтобы хранить байты изображения в презентации. Выбор влияет на портативность, размер файла, извлечение и поведение экспорта, поэтому полезно решить, как изображение должно храниться, до применения формата или оптимизации.

## **Добавление и форматирование встроенного изображения**

Для встроенного изображения добавьте данные изображения в презентацию и создайте рамку изображения с помощью [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapecollection/add_picture_frame/). Изображение становится частью пакета презентации, поэтому презентация остаётся автономной при перемещении на другой компьютер.

Следующий пример добавляет JPEG‑изображение, создает рамку с оригинальными размерами изображения и применяет оформление линии и вращение:

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

Рамка изображения управляет отображаемой геометрией; изменение размера рамки не изменяет исходные пиксельные размеры, хранящиеся во встроенном ресурсе изображения. Это различие становится важным при последующей обрезке или сжатии изображения.

## **Использование относительного масштаба**

[PictureFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframe/) предоставляет свойства [relative_scale_width](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframe/relative_scale_width/) и [relative_scale_height](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframe/relative_scale_height/) для рамки. Значение `1.0` соответствует 100 % исходного размера изображения. Относительный масштаб полезен, когда рабочий процесс требует сохранения соотношения с размером исходного изображения вместо ручного расчёта конечных размеров.

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

Относительный масштаб меняет настройки масштаба рамки; он не переотображает и не сжимает встроенное изображение.

## **Встроенные и связанные изображения**

Встроенное изображение хранит данные изображения внутри презентации и поэтому является самым безопасным вариантом для портативности и предсказуемого рендеринга. Связанное изображение хранит внешний путь через ссылку [Picture](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picture/) вместо встраивания данных изображения тем же способом.

Связанные изображения могут уменьшить объём данных изображения, хранящихся в PPTX, но они вводят внешнюю зависимость. Связанный файл должен оставаться доступным приложению, которое открывает или рендерит презентацию. Если путь изменится, файл будет перемещён или ресурс недоступен, связанное изображение может не отобразиться как ожидалось. Для презентаций, которые необходимо отправлять по электронной почте, архивировать или рендерить в изолированных средах, встроенные изображения обычно надёжнее.

### **Добавление связанного изображения**

Следующий пример создаёт рамку изображения и указывает её на локальный файл изображения. Рассматривается только связывание изображений; связывание видео — отдельный медиа‑рабочий процесс и намеренно не смешивается в этом примере.

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

Используйте ссылки, когда управление внешними файлами намеренно. Не используйте их просто как замену сжатию: небольшая PPTX с разрушенными зависимостями изображений обычно менее полезна, чем более крупная автономная презентация.

## **Извлечение изображений из рамок изображений**

Перед извлечением изображения из существующей презентации проверьте, что объект действительно является [PictureFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframe/) и что он содержит встроенное изображение. Связанные рамки изображений могут не содержать байты изображения, которые можно извлечь тем же способом.

### **Извлечение растрового изображения**

Современный API изображения использует [IImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iimage/) напрямую. Следующий пример находит первое встроенное растровое изображение на слайде и сохраняет его как PNG:

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

Сохранение через [IImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iimage/) преобразует извлечённое изображение в запрашиваемый выходной формат. Если вам нужны кодированные байты, хранящиеся в презентации, а не преобразованный растровый файл, используйте свойство [PPImage.binary_data](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/binary_data/).

### **Извлечение SVG‑изображения**

Для SVG‑изображения [PPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/) предоставляет объект [SvgImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/svgimage/). Это позволяет получить данные SVG напрямую без предварительной растеризации изображения.

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

Сохранение SVG‑контента в виде SVG сохраняет векторный источник внутри презентации. Растровый экспорт, такой как PNG или JPEG, обязательно преобразует векторный контент в пиксели. Экспорт слайда в PDF или SVG также является операцией рендеринга, поэтому экспортированную графику не следует воспринимать как точную копию оригинального встроенного SVG; используйте встроенный [SvgImage.svg_data](https://reference.aspose.com/slides/ru/python-net/aspose.slides/svgimage/svg_data/), когда требуется сам векторный ресурс.

## **Обрезка изображения**

Обрезка меняет часть изображения, видимую внутри рамки. Значения обрезки на [PictureFillFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picturefillformat/) задаются в процентах от размеров исходного изображения. Обрезка первоначально не удаляет скрытые пиксели из встроенного изображения; она лишь изменяет видимую область.

Следующий пример безопасно находит рамку изображения и применяет значения обрезки:

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

Поскольку скрытые данные изображения всё ещё присутствуют, обрезку можно изменить позже без потери оригинальных пикселей. Если размер файла важнее обратимости, обрезанные области можно физически удалить, как описано в следующем разделе.

## **Удаление обрезанных данных изображения**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) удаляет данные изображения за пределами текущего прямоугольника обрезки и возвращает полученный ресурс изображения. Это может уменьшить размер файла, но является разрушительной оптимизацией: после сохранения презентации удалённые пиксели более недоступны для последующего “открепления”.

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

Метод может добавить новый ресурс изображения в презентацию. Если исходное изображение также используется другими рамками, эти рамки всё равно нуждаются в своём текущем ресурсе, поэтому удаление обрезанных областей не обязательно уменьшит общее количество изображений. Обрезка содержимого WMF или EMF этим методом растеризует полученный результат в PNG.

## **Сжатие растровых изображений**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picturefillformat/compress_image/) уменьшает разрешение растрового изображения относительно размера, в котором изображение отображается. Он также может одновременно удалять обрезанные области. Метод возвращает `True`, когда изображение было изменено по размеру или обрезано, и `False`, когда изменение не потребовалось.

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

Можно передать пользовательское положительное значение DPI вместо значения перечисления, когда требуется конкретная цель.

Сжатие предназначено для растровых изображений. SVG‑и метафайлы не уменьшаются этим растровым процессом сжатия. Также помните, что более низкое разрешение и удалённые обрезанные области нельзя восстановить из оптимизированной презентации. Выбирайте целевое разрешение, ориентируясь на наибольший размер, при котором изображение будет действительно просматриваться или экспортироваться, а не применяя минимальное DPI глобально.

## **Проверка эффектов изображения**

Эффекты изображения хранятся на изображении, используемом рамкой. Коллекция трансформаций изображения может содержать такие эффекты, как фиксированная альфа‑модуляция для прозрачности и яркость для контрастности. Пример ниже безопасно считывает оба типа эффектов из первой рамки изображения на слайде:

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
        for effect in picture_frame.picture_format.picture.image_transform:
            if isinstance(effect, slides.effects.AlphaModulateFixed):
                transparency = 100 - effect.amount
                print("Transparency: " + str(transparency))

            if isinstance(effect, slides.effects.Luminance):
                luminance = effect.get_effective()
                print("Brightness: " + str(luminance.brightness))
                print("Contrast: " + str(luminance.contrast))
```

[AlphaModulateFixed](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/alphamodulatefixed/) и [Luminance](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/luminance/) изменяют способ рендеринга изображения в рамке; они не переписывают оригинальные байты встроенного изображения.

## **Блокировка геометрии рамки изображения**

Настройки [PictureFrameLock](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframelock/) управляют тем, какие операции редактирования отключены для рамки изображения. Например, свойство [aspect_ratio_locked](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) сохраняет пропорции фигуры при изменении её размера.

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

Блокировка применяется к фигуре рамки изображения. Она не заставляет исходное изображение быть переотображённым или постоянно изменённым до тех же пропорций.

## **Настройка значений StretchOffset**

Когда режим заполнения изображения установлен в растягивание, значения stretch‑offset на [PictureFillFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picturefillformat/) определяют прямоугольник заполнения относительно ограничивающего бокса рамки изображения. Положительные проценты создают отступ от края, а отрицательные — выступ.

Это отличается от обрезки. Значения обрезки выбирают, какая часть исходного изображения видима; stretch‑offset меняет прямоугольник, в который растягивается видимая часть заполнения.

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

Используйте stretch‑offset для размещения заполнения. Используйте свойства обрезки, когда цель — скрыть края исходного изображения.

## **Хранение, размер файла и соображения при экспорте**

Основные компромиссы проще управлять, когда хранение изображений и форматирование рамки рассматриваются отдельно:

- **Встроенные изображения** делают презентацию автономной и являются наиболее надёжными для совместного использования и серверного рендеринга, но большие растровые изображения увеличивают размер PPTX и потребление памяти.
- **Связанные изображения** могут уменьшить размер пакета, но презентация зависит от доступности внешних файлов по сохранённым путям или местоположениям.
- **Обрезка** первоначально неразрушительна. Скрытые пиксели остаются встроенными, пока обрезанные области явно не удаляются или не удаляются при сжатии.
- **Сжатие** может существенно уменьшить размер файла для слишком больших растровых изображений, но оно уменьшает исходное разрешение. Его следует применять после того, как известен планируемый размер изображения на слайде.
- **SVG‑изображения** следует оставлять в виде SVG, когда важна векторная сохранность. Извлеките встроенный SVG напрямую, когда нужен сам векторный ресурс. Растровый экспорт слайда всегда преобразует отрисованный слайд в пиксели.
- **Повторяющиеся изображения** следует по возможности переиспользовать существующий ресурс [PPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/), а не неоднократно загружать один и тот же файл в рабочий процесс презентации.

Для больших презентаций оптимизация изображений обычно наиболее эффективна при выборочном применении: сохраняйте логотипы и схемы как векторный контент, сжимайте фотографии в соответствии с их реальным размером отображения, удаляйте обрезанные пиксели только когда дальнейшее редактирование не требуется, и избегайте внешних ссылок, если только управление зависимостями не является частью стратегии развертывания.

## **Часто задаваемые вопросы**

**В чём разница между рамкой изображения и ресурсом изображения?**

[PPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/) представляет ресурс изображения, связанный с презентацией. [PictureFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframe/) — это фигура на слайде, отображающая изображение и хранящая геометрию и форматирование уровня рамки, такие как размер, вращение, значения обрезки, эффекты и блокировки.

**Нужно ли встраивать или связывать изображения?**

Встраивайте изображения, когда презентация должна быть портативной, архивной или рендериться без доступа к внешним ресурсам. Связывайте изображения только когда хранение файлов изображений вне PPTX намеренно и внешние местоположения могут быть надёжно поддержаны.

**Уменьшает ли обрезка размер файла PPTX?**

Не сама по себе. Обычные настройки обрезки скрывают части исходного изображения, но сохраняют подлежащие пиксели. Используйте [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) или сжатие изображения с удалением обрезанных областей, когда эти пиксели можно удалить окончательно.

**Можно ли восстановить качество изображения после сжатия?**

Нет. Сжатие может уменьшить сохранённое растровое разрешение, а удаление обрезанных областей отбрасывает данные изображения. Храните оригинальное исходное изображение вне презентации, если может потребоваться последующее редактирование в высоком разрешении.

**Как следует работать с SVG‑изображениями?**

Сохраняйте SVG‑контент как SVG, когда важна векторная точность. Встроенный [SvgImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/svgimage/) можно извлечь напрямую. Рендеринг слайда в растровый формат, такой как PNG или JPEG, растеризует SVG как часть изображения слайда.

**Как избежать небезопасных приведения типов при чтении существующих слайдов?**

Проверьте тип фигуры перед использованием членов, специфичных для рамки изображения. Использование `isinstance(shape, slides.PictureFrame)` избегает недопустимых приведения типов и позволяет коду корректно обрабатывать слайды, не содержащие рамки изображения.