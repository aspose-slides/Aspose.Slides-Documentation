---
title: Управление рамками изображений в презентациях с использованием Python
linktitle: Рамка изображения
type: docs
weight: 10
url: /ru/python-java/picture-frame/
keywords:
- рамка изображения
- добавить рамку изображения
- создать рамку изображения
- встроенное изображение
- связанное изображение
- извлечь изображение
- растровое изображение
- SVG‑изображение
- обрезать изображение
- удалить обрезанные области
- сжать изображение
- StretchOffset
- форматирование рамки изображения
- относительное масштабирование
- эффект изображения
- соотношение сторон
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Создавайте, форматируйте, связывайте, обрезайте, извлекайте и сжимайте рамки изображений в презентациях с Aspose.Slides для Python через Java."
---
## **Обзор**

Рамка изображения — это фигура слайда, которая отображает изображение. В Aspose.Slides ресурс изображения и фигура, отображающая его, являются отдельными объектами: [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) владеет встроенными ресурсами изображений через свою [ImageCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imagecollection/), а [PictureFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pictureframe/) управляет положением изображения, размером, форматированием линий, вращением, обрезкой, эффектами изображения и другими настройками уровня рамки.

Это разделение полезно, когда одно и то же изображение отображается более одного раза. Добавьте изображение в презентацию один раз, сохраните возвращённый [PPImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/), и используйте этот ресурс изображения при создании рамок изображения.

Рамки изображения могут содержать растровые изображения, такие как PNG или JPEG, и векторные SVG‑изображения. Они также могут ссылаться на связанные изображения вместо хранения байтов изображения в презентации. Выбор влияет на портативность, размер файла, извлечение и поведение экспорта, поэтому полезно решить, как изображение должно храниться, до применения форматирования или оптимизации.

## **Добавление и форматирование встроенного изображения**

Для встроенного изображения добавьте данные изображения в презентацию и создайте рамку изображения с помощью [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#addPictureFrame). Изображение становится частью пакета презентации, поэтому презентация остаётся автономной при перемещении на другой компьютер.

Следующий пример добавляет JPEG‑изображение, создаёт рамку с исходными размерами изображения и применяет форматирование линий и вращение:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt import Color
from asposeslides.api import FillType, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    picture_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    picture_frame.getLineFormat().setWidth(3)
    picture_frame.setRotation(15)

    presentation.save("picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Рамка изображения управляет отображаемой геометрией; изменение размера рамки не меняет оригинальные пиксельные размеры, хранящиеся во встроенном ресурсе изображения. Это различие становится важным при последующей обрезке или сжатии изображения.

## **Использование относительного масштабирования**

[PictureFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pictureframe/) предоставляет относительные масштабирования ширины и высоты для рамки через [setRelativeScaleWidth](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) и [setRelativeScaleHeight](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight). Значение `1.0` соответствует 100 % оригинального размера изображения. Относительное масштабирование полезно, когда необходимо сохранять соотношение с исходным размером изображения вместо ручного расчёта конечных размеров.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image)
    picture_frame.setRelativeScaleWidth(1.35)
    picture_frame.setRelativeScaleHeight(0.8)

    presentation.save("relative-scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Относительное масштабирование изменяет настройки масштаба рамки; оно не пере‑сэмплирует и не сжимает встроенное изображение.

## **Встроенные и связанные изображения**

Встроенная картинка хранит данные изображения внутри презентации и поэтому является самым безопасным выбором для портативности и предсказуемого рендеринга. Связанная картинка хранит внешний путь через метод [Picture.setLinkPathLong](https://reference.aspose.com/slides/ru/python-java/aspose.slides/picture/#setLinkPathLong) вместо встраивания данных изображения тем же способом.

Связанные изображения могут уменьшить объём данных изображения, хранящихся в PPTX, но они вводят внешнюю зависимость. Связанный файл должен оставаться доступным приложению, которое открывает или рендерит презентацию. Если путь изменится, файл будет перемещён или ресурс недоступен, связанная картинка может не отобразиться как ожидалось. Для презентаций, которые необходимо отправлять по электронной почте, архивировать или рендерить в изолированных средах, встроенные изображения обычно более надёжны.

### **Добавление связанного изображения**

Следующий пример создаёт рамку изображения и указывает её на локальный файл изображения. Он рассматривает только связывание изображений; связывание видео — отдельный медиа‑рабочий процесс и специально не смешивается в этом примере.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, None)
    linked_image_file = Path("linked-image.jpg").resolve()
    link_path = str(linked_image_file)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong(link_path)

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Используйте ссылки, когда внешнее управление файлами является намеренным. Не используйте их просто в качестве замены сжатию: небольшая PPTX с нарушенными зависимостями изображений обычно менее полезна, чем более крупная автономная презентация.

## **Извлечение изображений из рамок**

Перед извлечением изображения из существующей презентации проверьте, что фигура действительно является [PictureFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pictureframe/) и содержит встроенное изображение. Связанные рамки изображения могут не содержать байтов изображения, которые можно извлечь тем же способом.

### **Извлечение растрового изображения**

Современный API изображений работает напрямую с растровыми изображениями и не требует старого Java‑обёртки. Следующий пример ищет первое встроенное растровое изображение на слайде и сохраняет его как PNG:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        if embedded_image is None or embedded_image.getSvgImage() is not None:
            continue

        raster_image = embedded_image.getImage()
        try:
            raster_image.save("extracted-image.png", ImageFormat.Png)
        finally:
            raster_image.dispose()
        break
finally:
    presentation.dispose()
```

Сохранение растрового изображения преобразует извлечённое изображение в требуемый формат вывода. Если вам нужны закодированные байты, хранящиеся в презентации, а не преобразованный растровый файл, используйте бинарные данные ресурса изображения.

### **Извлечение SVG‑изображения**

Для SVG‑картинки [PPImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/) предоставляет объект [SvgImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/svgimage/). Это позволяет получить SVG‑данные напрямую без предварительной растеризации картинки.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        svg_image = embedded_image.getSvgImage() if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = svg_image.getSvgData()
        Path("extracted-image.svg").write_bytes(bytes(svg_data))
        break
finally:
    presentation.dispose()
```

Сохранение SVG‑содержимого как SVG сохраняет векторный источник внутри презентации. Растровый экспорт, такой как PNG или JPEG, неизбежно рендерит этот вектор в пиксели. Экспорт слайда в PDF или SVG также является операцией рендеринга, поэтому экспортированную графику не следует рассматривать как бит‑в‑бит копию оригинального встроенного SVG; используйте встроенные данные [SvgImage.getSvgData](https://reference.aspose.com/slides/ru/python-java/aspose.slides/svgimage/#getSvgData), когда требуется сам векторный ресурс.

## **Обрезка изображения**

Обрезка изменяет часть изображения, видимую внутри рамки. Значения обрезки в [PictureFillFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/picturefillformat/) задаются в процентах от размеров исходного изображения. Обрезка изначально не удаляет скрытые пиксели из встроенного изображения; она только изменяет видимую область.

Следующий пример безопасно находит рамку изображения и применяет значения обрезки:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.getPictureFormat().setCropLeft(23.6)
        picture_frame.getPictureFormat().setCropRight(21.5)
        picture_frame.getPictureFormat().setCropTop(3)
        picture_frame.getPictureFormat().setCropBottom(31)
        presentation.save("cropped-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Поскольку скрытые данные изображения всё ещё присутствуют, обрезку можно изменить позже без потери оригинальных пикселей. Если размер файла важнее обратимости, обрезанные области можно физически удалить, как описано в следующем разделе.

## **Удаление обрезанных данных изображения**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ru/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) удаляет данные изображения за пределами текущего прямоугольника обрезки и возвращает полученный ресурс изображения. Это может уменьшить размер файла, но является необратимой оптимизацией: после сохранения презентации удалённые пиксели больше недоступны для последующей операции «отброса обрезки».

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("cropped-image.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.getPictureFormat().deletePictureCroppedAreas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Метод может добавить новый ресурс изображения в презентацию. Если оригинальное изображение также используется другими рамками, эти рамки всё равно нуждаются в своём существующем ресурсе, поэтому удаление обрезанных областей не обязательно уменьшает общее количество изображений. Обрезка содержимого WMF или EMF с помощью этого метода растеризует полученный результат в PNG.

## **Сжатие растровых изображений**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/picturefillformat/#compressImage) уменьшает разрешение растрового изображения относительно размера, в котором оно отображается. Он также может удалить обрезанные области в той же операции. Метод возвращает `True`, когда изображение было изменено в размере или обрезано, и `False`, когда изменений не потребовалось.

Используйте предопределённое значение [PicturesCompression](https://reference.aspose.com/slides/ru/python-java/aspose.slides/picturescompression/), когда достаточно стандартного целевого разрешения:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.getPictureFormat().compressImage(True, PicturesCompression.Dpi150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Вместо предопределённого значения можно передать собственное положительное значение DPI, если требуется конкретная цель.

Сжатие предназначено для растровых изображений. SVG‑ и метафайл‑содержимое не уменьшается этим растровым процессом сжатия. Также помните, что более низкое разрешение и удалённые обрезанные области нельзя восстановить из оптимизированной презентации. Выбирайте целевое разрешение, исходя из наибольшего размера, при котором изображение будет действительно просматриваться или экспортироваться, а не применяйте самое низкое DPI глобально.

## **Управление эффектами трансформации изображения**

Для полного рабочего процесса, охватывающего яркость, контраст, цветовые трансформации, размытие, альфа‑эффекты, упорядоченные цепочки, инспекцию, удаление и проверку обратного пути, смотрите [Image Transform Effects](/slides/ru/python-java/image-transform-effects/).

## **Блокировка геометрии рамки изображения**

Настройки [PictureFrameLock](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pictureframelock/) контролируют, какие операции редактирования отключены для рамки изображения. Например, [setAspectRatioLocked](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) сохраняет пропорции фигуры при её изменении размера.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getPictureFrameLock().setAspectRatioLocked(True)

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Блокировка применяется к фигуре рамки изображения. Она не принуждает исходное изображение к пере‑сэмплированию или постоянному изменению пропорций.

## **Настройка значений StretchOffset**

Когда режим заполнения картинки — растяжка, значения stretch‑offset в [PictureFillFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/picturefillformat/) определяют прямоугольник заполнения относительно ограничивающего окна рамки изображения. Положительные проценты создают отступ от края, а отрицательные — выступ.

Это отличается от обрезки. Значения обрезки выбирают, какая часть исходного изображения видима; stretch‑offset меняет прямоугольник, в который растягивается видимая заливка картинки.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image)
    picture_frame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch)
    picture_frame.getPictureFormat().setStretchOffsetLeft(12)
    picture_frame.getPictureFormat().setStretchOffsetRight(12)
    picture_frame.getPictureFormat().setStretchOffsetTop(8)
    picture_frame.getPictureFormat().setStretchOffsetBottom(8)

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Используйте stretch‑offset для размещения заполнения. Используйте свойства обрезки, когда цель — скрыть края исходного изображения.

## **Хранение, размер файла и соображения при экспорте**

Основные компромиссы легче управлять, когда хранение изображений и форматирование рамок рассматриваются отдельно:

- **Встроенные изображения** делают презентацию автономной и являются наиболее надёжными для совместного использования и серверного рендеринга, но крупные растровые изображения увеличивают размер PPTX и потребление памяти.
- **Связанные изображения** могут уменьшить размер пакета, но презентация зависит от доступности внешних файлов по сохранённым путям или местоположениям.
- **Обрезка** изначально необратима. Скрытые пиксели остаются встроенными, пока обрезанные области явно не удаляются или не удаляются при сжатии.
- **Сжатие** может значительно уменьшить размер файла для чрезмерно больших растровых изображений, но снижает исходное разрешение. Его следует применять после того, как известен предполагаемый размер изображения на слайде.
- **SVG‑изображения** следует оставлять в виде SVG, когда важна векторная точность. Извлекайте встроенный SVG напрямую, когда нужен сам векторный ресурс. Растровый экспорт слайдов всегда преобразует отрисованный слайд в пиксели.
- **Повторяющиеся изображения** следует переиспользовать существующий ресурс [PPImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/), когда это возможно, вместо многократной загрузки одного и того же файла в рабочий процесс презентации.

Для крупных презентаций оптимизация изображений обычно наиболее эффективна при выборочном применении: храните логотипы и схемы как векторный контент, сжимайте фотографии в соответствии с их реальным размером отображения, удаляйте обрезанные пиксели только когда дальнейшее редактирование не требуется, и избегайте внешних ссылок, если только управление зависимостями не является частью дизайна развертывания.

## **Часто задаваемые вопросы**

**В чем разница между рамкой изображения и ресурсом изображения?**

[PPImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/) представляет ресурс изображения, связанный с презентацией. [PictureFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pictureframe/) — это фигура на слайде, отображающая изображение и хранящая геометрию и форматирование уровня рамки, такие как размер, вращение, значения обрезки, эффекты и блокировки.

**Стоит ли встраивать или связывать изображения?**

Встраивайте изображения, когда презентация должна быть портативной, архивируемой или рендериться без доступа к внешним ресурсам. Связывайте изображения только тогда, когда намеренно хранить файлы изображений вне PPTX и внешние расположения могут быть поддержаны надёжно.

**Уменьшает ли обрезка размер файла PPTX?**

Не сама по себе. Обычные настройки обрезки скрывают части исходного изображения, но сохраняют underlying пиксели. Используйте [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ru/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) или сжатие изображения с удалением обрезанных областей, когда эти пиксели можно удалить навсегда.

**Можно ли восстановить качество изображения после сжатия?**

Нет. Сжатие может снизить сохранённое растровое разрешение, а удаление обрезанных областей отбрасывает данные изображения. Сохраняйте оригинальный исходный файл изображения вне презентации, если впоследствии может потребоваться редактирование в высоком разрешении.

**Как следует работать с SVG‑изображениями?**

Храните SVG‑контент как SVG, когда важна векторная точность. Встроенный [SvgImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/svgimage/) можно извлечь напрямую. Рендеринг слайда в растровый формат, такой как PNG или JPEG, растеризует SVG как часть изображения слайда.

**Как избежать небезопасных приведения типов при чтении существующих слайдов?**

Проверьте тип фигуры перед использованием членов, специфичных для рамки изображения. Проверка `isinstance` против [PictureFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pictureframe/) предотвращает недопустимые приведения и позволяет коду обрабатывать слайды, не содержащие рамки изображения.