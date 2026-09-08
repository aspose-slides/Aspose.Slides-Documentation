---
title: Управление эффектами преобразования изображений в презентациях с Python
linktitle: Эффекты преобразования изображений
type: docs
weight: 11
url: /ru/python-java/image-transform-effects/
keywords:
- преобразование изображения
- эффект изображения
- яркость
- контраст
- градация серого
- двухтонный
- оттенок
- HSL
- замена цвета
- размытие
- прозрачность
- альфа-эффект
- цепочка эффектов
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Применяйте, соединяйте, просматривайте, удаляйте и проверяйте эффекты преобразования изображений для рамок картинок с Aspose.Slides для Python через Java."
---
## **Обзор**

Aspose.Slides представляет коррекцию изображений как упорядоченную коллекцию операций преобразования изображений. Для рамки изображения начните с [Picture](https://reference.aspose.com/slides/ru/python-java/aspose.slides/picture/) и получите [Picture.getImageTransform](https://reference.aspose.com/slides/ru/python-java/aspose.slides/picture/#getImageTransform). Возвращаемый [ImageTransformOperationCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imagetransformoperationcollection/) позволяет добавлять, перечислять, проверять, удалять и очищать эффекты, не переписывая исходные байты изображения.

В этой статье демонстрируется полный рабочий процесс для яркости и контраста, цветовых преобразований, размытия, прозрачности, упорядоченных цепочек эффектов, эффективных значений, удаления и проверки обратного прохода PPTX.

## **Понимание владения эффектом и повторного использования изображения**

Ресурс изображения и объект, отображающий его, — разные сущности:

- [PPImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/) хранит или ссылается на исходные данные изображения, принадлежащие презентации.
- [Picture](https://reference.aspose.com/slides/ru/python-java/aspose.slides/picture/) относится к заливке изображения и указывает на ресурс изображения, одновременно храня коллекцию преобразований изображения.
- [PictureFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pictureframe/) — фигура слайда, владеющая соответствующей заливкой изображения, геометрией, настройками кадрирования и другими параметрами уровня рамки.

Следовательно, операции преобразования изображения не изменяют байты в [PPImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/). Когда один и тот же `PPImage` передаётся в [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#addPictureFrame) более одного раза, каждая новая рамка получает собственный `Picture` и собственную коллекцию преобразований. Применение градации серого к одной рамке не делает остальные рамки серыми, хотя все они используют один и тот же встроенный ресурс изображения.

Та же модель `Picture.getImageTransform` используется и другими заливками изображений, например фигурой или фоном слайда. Приведённые ниже примеры сосредоточены на рамках изображений.

## **Используйте допустимые диапазоны параметров и единицы измерения**

Продемонстрированные методы используют следующие семантические диапазоны и единицы. Сохраняйте значения в этих диапазонах, даже если конкретная версия библиотеки не отклоняет сразу каждое неверное значение; целевой формат презентации может нормализовать, опустить или отклонить некорректные данные при сохранении или открытии файла PowerPoint.

| Операция | Параметры | Допустимый диапазон и единица измерения |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | от `-100` до `100`, процентов; `0` оставляет компонент без изменений. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | None | Нет числовых параметров. Альфа остается без изменений. |
| [addDuotoneEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | Два цвета для тёмных и светлых пикселей. Каналы RGB и альфа в `java.awt.Color` используют значения от `0` до `255`. |
| [addTintEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | Оттенок (hue) включительно от `0` до `360` (не включительно), в градусах; значение amount — от `-100` до `100`, процентов. |
| [addHSLEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | Оттенок (hue) включительно от `0` до `360` (не включительно), в градусах; насыщенность и светимость от `-100` до `100`, процентов. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | Цвет замены использует значения каналов от `0` до `255`. Существующая альфа остаётся без изменений. |
| [addBlurEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | Радиус неотрицателен и измеряется в пунктах; `grow` — булево значение, контролирующее, может ли размазанное содержимое выходить за границы оригинального изображения. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | Неотрицательный процент. Используйте `0`‑`100` для обычного масштабирования непрозрачности: `0` — полностью прозрачно, `100` — сохраняет существующую альфа. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | от `0` до `100`, процентов непрозрачности. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | от `0` до `100`, процентов альфа‑порога. Значения ниже порога становятся прозрачными; значения, равные или выше порога, становятся непрозрачными. |

Для фиксированного модулирования альфа‑прозрачность и непрозрачность являются взаимодополняющими. Например, 35 % прозрачности соответствует модуляции альфа‑значения на 65 %.

## **Применение яркости и контраста**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) возвращает операцию [BrightnessContrast](https://reference.aspose.com/slides/ru/python-java/aspose.slides/brightnesscontrast/). Ее скалярные настройки задаются при создании операции. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/ru/python-java/aspose.slides/brightnesscontrast/#getEffective) возвращает вычисленные только для чтения значения, которые можно проверить или записать в журнал.

Следующий пример увеличивает яркость на 15 % и контраст на 20 %, затем отображает предварительный просмотр без изменения встроенного изображения:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    brightness_contrast = image_transform.addBrightnessContrastEffect(15.0, 20.0)

    effective_values = brightness_contrast.getEffective()
    print("Brightness: ", effective_values.getBrightness(), "%", sep="")
    print("Contrast: ", effective_values.getContrast(), "%", sep="")

    preview = slide.getImage()
    try:
        preview.save("brightness-contrast-preview.png", ImageFormat.Png)
    finally:
        preview.dispose()
finally:
    presentation.dispose()
```

[BrightnessContrast](https://reference.aspose.com/slides/ru/python-java/aspose.slides/brightnesscontrast/) — расширение Office 2010 для эффектов изображений и менее портируемо, чем стандартный эффект Drawing ML luminance. Когда требуется сохранить редактируемость яркости и контраста после обратного прохода PPTX, используйте [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) и проверьте результат после повторного открытия файла. Раздел «Ограничения форматов» объясняет это различие подробнее.

## **Применение цветовых преобразований**

Цветовые эффекты могут применяться независимо к различным рамкам изображений, использующим один ресурс изображения. Следующий пример создаёт пять рамок и применяет градацию серого, дуотон, оттенок, корректировку HSL и замену цвета.

[Duotone](https://reference.aspose.com/slides/ru/python-java/aspose.slides/duotone/) содержит два независимо редактируемых параметра цвета: `color1` сопоставляется тёмным пикселям, а `color2` — светлым. Это делает его полезным примером эффекта, настройки которого сложнее, чем один скалярный параметр.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    gray_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image)
    gray_frame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect()

    duotone_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image)
    duotone = duotone_frame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect()
    duotone.getColor1().setColor(Color(0, 0, 128))
    duotone.getColor2().setColor(Color(255, 215, 0))

    tint_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image)
    tint_frame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210.0, 35.0)

    hsl_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image)
    hsl_frame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30.0, 20.0, -10.0)

    replacement_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect()
    color_replacement.getColor().setColor(Color(100, 149, 237))

    presentation.save("color-transformations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[addColorReplaceEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) заменяет цвет каждого пикселя на один фиксированный цвет, сохраняя альфа‑канал. Это отличается от [addColorChangeEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect), который сопоставляет один исходный цвет с другим и раскрывает форматы как исходного, так и целевого цвета.

## **Добавление размытия, прозрачности и альфа‑эффектов**

[addBlurEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) влияет на все цветовые каналы, включая альфа. Установите `grow` в `True`, когда размытие может выходить за пределы оригинального изображения.

Для равномерной прозрачности используйте [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect). Он умножает каждое существующее альфа‑значение, поэтому частично прозрачные пиксели остаются пропорционально различными. [addAlphaReplaceEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) вместо этого задаёт одно альфа‑значение для всех пикселей. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) преобразует альфа в два уровня на основе порога.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    blurred_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image)
    blur = blurred_frame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, True)
    blur.setRadius(5)

    transparent_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65.0)
    alpha_modulate.setAmount(60.0)

    uniform_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image)
    uniform_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55.0)

    binary_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50.0)
    alpha_bi_level.setThreshold(45.0)
    binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect()

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Другие операции без параметров включают [addAlphaCeilingEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect), который делает каждый ненулевой альфа‑канал полностью непрозрачным; [addAlphaFloorEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect), который делает каждый альфа‑канал ниже 100 % полностью прозрачным; и [addAlphaInverseEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect), который меняет альфа‑значение на `100% - alpha`.

## **Создание упорядоченной цепочки эффектов**

Каждый метод `add...Effect` добавляет новую операцию в конец коллекции. Рендерер использует коллекцию как упорядоченный конвейер: вывод операции 0 становится вводом операции 1 и т.д. Следовательно, одинаковые операции в разном порядке могут дать различный результат.

Например, градация серого, а затем оттенок сначала удаляют хроматическую информацию, а затем перекрашивают полученную яркость. Оттенок, а потом градация серого удаляют оттенок обратно. Аналогично, замена альфа может переопределить значения альфа, вычисленные более ранними операциями, тогда как модуляция альфа сохраняет их относительные различия.

Следующий пример собирает цепочку из четырёх операций, сохраняет её в PPTX, заново открывает презентацию, проверяет типы операций и их порядок, а затем отображает результат после повторного открытия:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Blur, GrayScale, ImageFormat, PictureFrame, Presentation, SaveFormat, ShapeType, Tint

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    image_transform.addGrayScaleEffect()
    image_transform.addTintEffect(220.0, 25.0)
    image_transform.addBlurEffect(2.5, False)
    image_transform.addAlphaModulateFixedEffect(80.0)

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("image-transform-chain.pptx")
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    if isinstance(reopened_shape, PictureFrame):
        reopened_transform = reopened_shape.getPictureFormat().getPicture().getImageTransform()
        expected_types = (GrayScale, Tint, Blur, AlphaModulateFixed)
        order_is_preserved = reopened_transform.size() == len(expected_types)
        for index, expected_type in enumerate(expected_types):
            order_is_preserved = order_is_preserved and isinstance(reopened_transform.get_Item(index), expected_type)
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        rendered_slide = reopened_presentation.getSlides().get_Item(0).getImage()
        try:
            rendered_slide.save("reopened-effect-chain.png", ImageFormat.Png)
        finally:
            rendered_slide.dispose()
    else:
        print("The reopened shape is not a picture frame.")
finally:
    reopened_presentation.dispose()
```

Коллекция не накладывает матрицу совместимости, ограничивая цветовые, альфа‑ и размытие операции отдельными цепочками. Их можно комбинировать, но не все комбинации полезны. Фиксированная замена цвета убирает вариацию RGB, созданную предыдущими цветовыми эффектами; градация серого после дуотона удаляет два выбранных цвета; а операции альфа‑ceiling, floor, replace или bi‑level могут отбрасывать детали альфа, созданные ранее. Стройте цепочку в соответствии с желаемой последовательностью обработки пикселей, а не как набор неупорядоченных флагов форматирования.

## **Просмотр редактируемых и эффективных значений**

Редактируемая операция — это объект, хранящийся в `Picture.getImageTransform`. В зависимости от эффекта он может напрямую раскрывать записываемые члены. Например, [Blur](https://reference.aspose.com/slides/ru/python-java/aspose.slides/blur/) раскрывает записываемые `radius` и `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/ru/python-java/aspose.slides/alphamodulatefixed/) — `amount`, а [AlphaBiLevel](https://reference.aspose.com/slides/ru/python-java/aspose.slides/alphabilevel/) — `threshold`. Цветовые эффекты, такие как [Duotone](https://reference.aspose.com/slides/ru/python-java/aspose.slides/duotone/), раскрывают изменяемые объекты [ColorFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/colorformat/).

Некоторые классы операций, включая [BrightnessContrast](https://reference.aspose.com/slides/ru/python-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/ru/python-java/aspose.slides/tint/) и [AlphaReplace](https://reference.aspose.com/slides/ru/python-java/aspose.slides/alphareplace/), не раскрывают свои скалярные параметры создания как записываемые свойства. Чтобы изменить эти настройки, удалите операцию и добавьте замену в требуемой позиции.

Эффективные данные, возвращаемые `getEffective`, вычисляются и являются только для чтения. Они полезны для разрешения цветовых зависимостей от темы и для чтения нормализованных значений, которые использует рендерер, но не представляют собой отдельный слой редактирования. Следующий пример перечисляет цепочку и проверяет эффективные значения там, где соответствующий API их предоставляет:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaBiLevel, AlphaModulateFixed, AlphaReplace, Blur, BrightnessContrast, ColorReplace, Duotone, HSL, Luminance, PictureFrame, Presentation, Tint

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()

        for index in range(image_transform.size()):
            operation = image_transform.get_Item(index)
            print(index, ": ", operation.getClass().getSimpleName(), sep="")

            if isinstance(operation, BrightnessContrast):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Luminance):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Duotone):
                data = operation.getEffective()
                print("  Dark color: ", data.getColor1(), sep="")
                print("  Light color: ", data.getColor2(), sep="")
            elif isinstance(operation, ColorReplace):
                data = operation.getEffective()
                print("  Replacement color: ", data.getColor(), sep="")
            elif isinstance(operation, HSL):
                data = operation.getEffective()
                print("  HSL: ", data.getHue(), ", ", data.getSaturation(), ", ", data.getLuminance(), sep="")
            elif isinstance(operation, Tint):
                data = operation.getEffective()
                print("  Tint: ", data.getHue(), ", ", data.getAmount(), sep="")
            elif isinstance(operation, Blur):
                data = operation.getEffective()
                print("  Blur radius: ", data.getRadius(), " pt", sep="")
            elif isinstance(operation, AlphaModulateFixed):
                data = operation.getEffective()
                print("  Alpha amount: ", data.getAmount(), "%", sep="")
            elif isinstance(operation, AlphaReplace):
                data = operation.getEffective()
                print("  Replacement alpha: ", data.getAlpha(), "%", sep="")
            elif isinstance(operation, AlphaBiLevel):
                data = operation.getEffective()
                print("  Alpha threshold: ", data.getThreshold(), "%", sep="")
finally:
    presentation.dispose()
```

Эффекты без параметров, такие как градация серого, альфа‑ceiling и альфа‑inverse, также имеют объект эффективных данных, но нет скалярных настроек для вывода. Их присутствие и позиция в коллекции являются важной информацией.

## **Удаление или очистка преобразований изображения**

Используйте [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imagetransformoperationcollection/#removeAt), чтобы удалить одну операцию по индексу. Поскольку индексы смещаются после удаления, сначала найдите нужный элемент, а затем удалите его после перечисления. Используйте [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imagetransformoperationcollection/#clear), чтобы удалить всю цепочку.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Blur, PictureFrame, Presentation, SaveFormat

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
        blur_index = -1

        for index in range(image_transform.size()):
            if isinstance(image_transform.get_Item(index), Blur):
                blur_index = index
                break

        if blur_index >= 0:
            image_transform.removeAt(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: ", image_transform.size(), sep="")
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Удаление или очистка преобразований меняет только форматирование изображения. Это не удаляет, не перекодирует и не изменяет повторно используемый ресурс [PPImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/).

## **Учтите форматы презентаций и целевые форматы экспорта**

Преобразования изображений происходят в DrawingML, поэтому PPTX является предпочтительным редактируемым форматом для цепочек эффектов. Даже в PPTX не каждый оператор обладает одинаковой портируемостью:

- Стандартные операции DrawingML, такие как luminance, grayscale, duotone, tint, HSL, blur и общие альфа‑операции, имеют наибольшие шансы сохраниться после обратного прохода PPTX. Всегда переоткрывайте сгенерированный файл и проверяйте коллекцию, если требуется сохранность.
- [BrightnessContrast](https://reference.aspose.com/slides/ru/python-java/aspose.slides/brightnesscontrast/) — расширение Office 2010, а не стандартный оператор DrawingML luminance. Его можно использовать для рендеринга в памяти, но нет гарантии, что после сохранения и повторного открытия PPTX он останется редактируемым [BrightnessContrast](https://reference.aspose.com/slides/ru/python-java/aspose.slides/brightnesscontrast/). Для постоянных корректировок яркости и контраста предпочтительно использовать [addLuminanceEffect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect).
- Бинарный формат PPT появился раньше полной модели эффектов DrawingML. Сохранение в PPT может опустить неподдерживаемые операции, сократить цепочку до поддерживаемого подмножества или приблизительно воспроизвести внешний вид. Не используйте PPT в качестве формата проверки для сложной редактируемой цепочки.
- Рендеринг в PNG, JPEG, TIFF, PDF, SVG, HTML или другие визуальные форматы применяет поддерживаемую цепочку к визуальному представлению. Эти выводы не содержат редактируемой `ImageTransformOperationCollection`; растровые форматы уплощают результат в пиксели, а документы/векторные экспорты хранят собственное представление рендеринга.
- Эффекты не делают связанную картинку самостоятельной. При рендеринге связанного изображения всё равно требуется наличие связанного ресурса при загрузке презентации.

Разные потребители презентаций могут по‑разному обрабатывать граничные случаи, особенно когда объединяются несколько альфа‑ или цветоквантующих операций. Для критически важного вывода тестируйте как редактируемый обратный проход, так и окончательный экспортный формат с той же версией Aspose.Slides, что используется в продакшене.

## **FAQ**

**Модифицируют ли эффекты преобразования изображения встроенные данные изображения?**

Нет. Операции принадлежат `Picture`, используемому заливкой изображения. Байты базового `PPImage` остаются неизменными.

**Будут ли две рамки изображений, использующие один и тот же ресурс, делить эффекты?**

Нет. Повторное использование `PPImage` избавляет от дублирования данных изображения, но каждая рамка обычно имеет отдельный `Picture` и отдельную коллекцию преобразований.

**Можно ли комбинировать цветовые, размытие и альфа‑эффекты?**

Да. Коллекция принимает их в одной упорядоченной цепочке. Учитывайте, как каждая операция воздействует на вывод предыдущей, поскольку операции замены и пороговые операции могут отбрасывать ранее созданные цветовые или альфа‑детали.

**Почему эффективные значения только для чтения?**

Эффективные данные представляют вычисленные значения, используемые для рендеринга, включая разрешённые цвета. Изменяйте операцию, хранящуюся в коллекции преобразований, где существуют записываемые члены; иначе удалите её и добавьте замену с новыми параметрами создания.

**Какой формат использовать, чтобы сохранить цепочку преобразований?**

Используйте PPTX и проверьте файл, переоткрыв его. Устаревший PPT не может отобразить полную модель эффектов DrawingML, а экспортные форматы сохраняют лишь внешний вид, а не редактируемые операции преобразования.