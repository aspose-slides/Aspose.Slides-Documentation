---
title: Управляйте эффектами преобразования изображений в презентациях с помощью Python
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
- дуотон
- оттенок
- HSL
- замена цвета
- размытие
- прозрачность
- альфа‑эффект
- цепочка эффектов
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Применяйте, комбинируйте, просматривайте, удаляйте и проверяйте эффекты преобразования изображений для кадров изображений с Aspose.Slides для Python через Java."
---
## **Обзор**

Aspose.Slides представляет настройки изображения как упорядоченную коллекцию операций преобразования изображения. Для кадра изображения начните с [Picture](https://reference.aspose.com/slides/python-java/aspose.slides/picture/) кадра и вызовите [Picture.getImageTransform](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#getImageTransform). Возвращаемый [ImageTransformOperationCollection](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/) позволяет добавлять, перечислять, просматривать, удалять и очищать эффекты без переписывания исходных байтов изображения.

В этой статье показан полный рабочий процесс для яркости и контраста, цветовых преобразований, размытия, прозрачности, упорядоченных цепочек эффектов, эффективных значений, удаления и проверки кругового прохождения PPTX.

## **Понимание владения эффектом и повторного использования изображения**

Ресурс изображения и изображение, которое его отображает, — это разные объекты:

- [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) хранит или ссылается на исходные данные изображения, принадлежащие презентации.
- [Picture](https://reference.aspose.com/slides/python-java/aspose.slides/picture/) относится к заливке изображения и указывает на ресурс изображения, одновременно храня коллекцию преобразований изображения.
- [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) — это фигура слайда, которая владеет соответствующей заливкой изображения, геометрией, настройками обрезки и другими параметрами уровня кадра.

Поэтому операции преобразования изображения не изменяют байты в [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/). Когда один и тот же `PPImage` передаётся в [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) более одного раза, каждый новый кадр получает собственный `Picture` и собственную коллекцию преобразований. Применение градации серого к одному кадру не делает остальные кадры градацией серого, даже если они используют один и тот же встроенный ресурс изображения.

Та же модель `Picture.getImageTransform` используется и другими заливками изображений, такими как форма или фон слайда. Приведённые ниже примеры сосредоточены на кадрах изображений.

## **Использование допустимых диапазонов параметров и единиц измерения**

Продемонстрированные методы используют следующие семантические диапазоны и единицы. Сохраняйте значения в этих диапазонах, даже если конкретная версия библиотеки не отклоняет каждое недопустимое значение сразу; целевой формат презентации может нормализовать, опустить или отклонить некорректные данные при сохранении или открытии файла PowerPoint.

| Operation | Parameters | Valid range and unit |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | `-100`‒`100`, процент; `0` оставляет компонент без изменения. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | None | Без числовых параметров. Альфа остаётся без изменения. |
| [addDuotoneEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | Два цвета для тёмных и светлых пикселей. Каналы RGB и альфа в `java.awt.Color` используют диапазон `0`‒`255`. |
| [addTintEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | Оттенок `0` включительно до `360` исключительно, в градусах; количество `-100`‒`100`, процент. |
| [addHSLEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | Оттенок `0` включительно до `360` исключительно, в градусах; насыщенность и яркость `-100`‒`100`, процент. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | Заменяющий цвет использует значения каналов от `0` до `255`. Существующая альфа остаётся без изменения. |
| [addBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | Радиус неотрицательный и измеряется в пунктах; `grow` — логический параметр, определяющий, может ли размазанный контент выходить за пределы исходных границ. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | Неотрицательный процент. Используйте `0`‒`100` для обычного масштабирования непрозрачности: `0` — полностью прозрачно, `100` — сохраняет исходную альфу. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | `0`‒`100`, процент непрозрачности. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | `0`‒`100`, процентный порог альфа. Значения ниже порога становятся прозрачными; значения, равные или превышающие порог, — непрозрачными. |

Для фиксированной модуляции альфа прозрачность и непрозрачность являются дополнительными. Например, 35 % прозрачности соответствует модуляции альфа 65 %.

## **Применение яркости и контраста**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) возвращает операцию [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/). Его скалярные параметры задаются при создании операции. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/#getEffective) возвращает вычисленные только для чтения значения, которые можно просмотреть или записать в журнал.

В следующем примере яркость увеличивается на 15 %, контраст — на 20 %, после чего отображается предварительный просмотр без изменения встроенного изображения:

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

[BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) является расширением эффекта изображения Office 2010 и менее переносим, чем стандартный эффект яркости DrawingML. Когда яркость и контраст должны оставаться редактируемыми после кругового прохождения PPTX, используйте [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) и проверьте результат после повторного открытия файла. Раздел о ограничениях формата объясняет это различие подробнее.

## **Применение цветовых преобразований**

Цветовые эффекты можно применять независимо к разным кадрам, использующим один ресурс изображения. В следующем примере создаются пять кадров и применяются градация серого, дутон, оттенок, коррекция HSL и замена цвета.

[Duotone](https://reference.aspose.com/slides/python-java/aspose.slides/duotone/) содержит два независимо редактируемых цветовых параметра: `color1` отвечает за тёмные пиксели, `color2` — за светлые. Это делает его полезным примером эффекта с более сложными настройками, чем один скаляр.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) заменяет цвет каждого пикселя на один фиксированный, сохраняя альфа‑канал. Это отличается от [addColorChangeEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect), который сопоставляет один исходный цвет с другим и раскрывает форматы как исходного, так и целевого цвета.

### **Применение порога яркости**

Порог яркости может облегчить различие слабых отметок на отсканированной странице от фона. [addGrayScaleEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) сохраняет промежуточные оттенки серого. [addBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBiLevelEffect) преобразует яркость в чёрный или белый, а [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) применяет порог к непрозрачности.

Порог яркости варьируется от 0 % до 100 %, включительно. Пиксели ниже порога становятся черными. Пиксели, равные или превышающие порог, становятся белыми. Повышение порога делает больше оттенков чёрными, поскольку они попадают ниже отсечения.

Сохраните [grayscale-swatches.png](grayscale-swatches.png) в рабочий каталог. Каждая подпись указывает исходный уровень серого по шкале от 0 до 255. Пример помещает оригинал рядом с двумя копиями и сохраняет порог каждой копии в презентации.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720.0, 150.0, SlideSizeScaleType.DoNotScale)
    shapes = presentation.getSlides().get_Item(0).getShapes()

    image_data = Path("grayscale-swatches.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    frames = []
    for index, caption in enumerate(("Original", "Threshold 20%", "Threshold 60%")):
        x = 12 + 240 * index
        label = shapes.addAutoShape(ShapeType.Rectangle, x, 12, 216, 36)
        label.getTextFrame().setText(caption)
        frame = shapes.addPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image)
        frames.append(frame)

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20.0)
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60.0)

    presentation.save("luminance-threshold.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Откройте полученную презентацию в PowerPoint, чтобы сравнить три кадра. Образец со значением 96 имеет около 38 % яркости (96 из 255). При пороге 20 % он становится белым, а при пороге 60 % — черным.

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **Добавление размытия, прозрачности и альфа‑эффектов**

[addBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) влияет на все цветовые каналы, включая альфа. Установите `grow` в `True`, когда размазанный край может выходить за пределы исходных границ изображения.

Для равномерной прозрачности воспользуйтесь [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect). Он умножает каждое существующее значение альфа, поэтому частично прозрачные пиксели сохраняют пропорциональные различия. [addAlphaReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) вместо этого задаёт одно значение альфа для всех пикселей. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) переводит альфа в два уровня по порогу.

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

Другие операции альфа без параметров включают [addAlphaCeilingEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect), который делает каждый ненулевой альфа полностью непрозрачным; [addAlphaFloorEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect), который делает каждый альфа ниже 100 % полностью прозрачным; и [addAlphaInverseEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect), который меняет альфа на `100% - alpha`.

## **Создание упорядоченной цепочки эффектов**

Каждый метод `add...Effect` добавляет новую операцию в конец коллекции. Рендерер использует коллекцию как упорядоченный конвейер: вывод операции 0 становится входом операции 1 и так далее. Поэтому одинаковые операции в разном порядке могут дать разный результат.

Например, градация серого, а затем оттенок сначала удаляет цветовую информацию, а затем перекрашивает полученную яркость. Оттенок, а затем градация серого удаляет оттенок. Аналогично, замена альфа может переопределить значения альфа, вычисленные более ранними операциями, тогда как модуляция альфа сохраняет их относительные различия.

В следующем примере создаётся цепочка из четырёх операций, сохраняется как PPTX, файл повторно открывается, проверяются типы и порядок операций, после чего рендерится повторно открытый результат:

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

Коллекция не накладывает матрицу совместимости, ограничивающую цветовые, альфа‑ и размывающие операции отдельными цепочками. Их можно комбинировать, но комбинации не всегда полезны. Фиксированная замена цвета удаляет вариацию RGB, созданную предыдущими цветовыми эффектами; градация серого после дутон удаляет два выбранных цвета; а операции альфа‑потолок, пол, замена или би‑уровень могут отбрасывать детали альфа, созданные ранее. Формируйте цепочку согласно желаемой последовательности обработки пикселей, а не как набор несортированных флагов форматирования.

<!-- visual-explanation:image-transform-effects:start -->
[![То же изображение проходит через градацию серого, затем оттенок, и оттенок, затем градацию серого. Два итоговых изображения в градации серого имеют разные тона.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*В этом иллюстративном рендере Aspose.Slides for .NET 26.11 тон 220° при 25 % не меняет градацию серого. Применение того же тона до градации серого даёт разные тона.*
<!-- visual-explanation:image-transform-effects:end -->

## **Просмотр редактируемых и эффективных значений**

Редактируемая операция — это объект, хранящийся в `Picture.getImageTransform`. В зависимости от эффекта она может напрямую раскрывать записываемые члены. Например, [Blur](https://reference.aspose.com/slides/python-java/aspose.slides/blur/) раскрывает записываемые значения `radius` и `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/python-java/aspose.slides/alphamodulatefixed/) — записываемый `amount`, а [AlphaBiLevel](https://reference.aspose.com/slides/python-java/aspose.slides/alphabilevel/) — записываемый `threshold`. Цветовые эффекты, такие как [Duotone](https://reference.aspose.com/slides/python-java/aspose.slides/duotone/), раскрывают изменяемые объекты [ColorFormat](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/).

Некоторые классы операций, включая [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/python-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/python-java/aspose.slides/tint/), и [AlphaReplace](https://reference.aspose.com/slides/python-java/aspose.slides/alphareplace/), не раскрывают свои скалярные параметры как записываемые свойства. Чтобы изменить эти настройки, удалите операцию и добавьте замену в необходимом месте.

Эффективные данные, возвращаемые `getEffective`, вычисляются и являются только для чтения. Они полезны для разрешения зависимых от темы цветов и чтения нормализованных значений, используемых рендерером, но не представляют собой дополнительный слой редактирования. В следующем примере перечисляется цепочка и просматриваются эффективные значения, где соответствующий API их предоставляет:

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

Эффекты без параметров, такие как градация серого, альфа‑потолок и альфа‑обратный, также имеют объект эффективных данных, но нет скалярных настроек для вывода. Их наличие и позиция в коллекции — важная информация.

## **Удаление или очистка преобразований изображения**

Используйте [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#removeAt) для удаления одной операции по индексу. Поскольку индексы смещаются после удаления, сначала найдите нужный элемент, а затем удалите его после перечисления. Для удаления всей цепочки используйте [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#clear).

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

Удаление или очистка преобразований меняет только форматирование изображения. Это не удаляет, не перекомпрессирует и не изменяет повторно используемый ресурс [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/).

## **Учёт форматов презентаций и целей экспорта**

Преобразования изображения происходят в DrawingML, поэтому PPTX является предпочтительным редактируемым форматом для цепочек эффектов. Даже в PPTX не каждый эффект обладает одинаковой переносимостью:

- Стандартные операции DrawingML, такие как яркость, градация серого, дутон, оттенок, HSL, размытие и общие альфа‑операции, имеют наилучшие шансы выжить после кругового прохождения PPTX. Всегда повторно открывайте созданный файл и проверяйте коллекцию, если требуется сохранение.
- [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) — расширение Office 2010, а не стандартная операция яркости DrawingML. Его можно использовать для рендеринга в памяти, но нет гарантии, что после сохранения и повторного открытия PPTX он останется редактируемым [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/). Предпочтительно использовать [addLuminanceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) для постоянных настроек яркости и контраста.
- Бинарный формат PPT предшествует полной модели эффектов DrawingML. Сохранение в PPT может опустить неподдерживаемые операции, сократить цепочку до поддерживаемого подмножества или приблизительно воспроизвести внешний вид. Не используйте PPT как формат проверки для сложной редактируемой цепочки.
- Рендеринг в PNG, JPEG, TIFF, PDF, SVG, HTML и другие визуальные форматы применяет поддерживаемую цепочку к визуальному представлению. Эти выводы не содержат редактируемой `ImageTransformOperationCollection`; растровые форматы фиксируют результат в пикселях, а документ/векторные экспорты сохраняют собственное представление рендеринга.
- Эффекты не делают связанные изображения самодостаточными. Рендеринг связанного изображения всё равно требует наличия связанного ресурса при загрузке презентации.

Разные потребители презентаций могут по‑разному обрабатывать граничные случаи, особенно при комбинировании нескольких альфа‑ или цветоквантизационных операций. Для критически важного вывода протестируйте как редактируемый круговой проход, так и конечный экспортный формат той же версии Aspose.Slides, что используется в продакшене.

## **FAQ**

**Модифицируют ли эффекты преобразования изображения встроенные данные изображения?**

Нет. Операции относятся к `Picture`, используемому в заливке изображения. Базовые байты `PPImage` остаются без изменений.

**Будут ли два кадра, использующие одно и то же изображение, делить свои эффекты?**

Нет. Повторное использование `PPImage` устраняет дублирование данных изображения, но каждый кадр обычно имеет отдельный `Picture` и отдельную коллекцию преобразований изображения.

**Можно ли комбинировать цветовые, размазывающие и альфа‑эффекты?**

Да. Коллекция принимает их в одной упорядоченной цепочке. Учитывайте, как каждая операция воздействует на результат предыдущей, поскольку операции замены и пороговые операции могут отбрасывать ранее созданные цветовые или альфа‑детали.

**Почему эффективные значения только для чтения?**

Эффективные данные представляют вычисленные значения, используемые для рендеринга, включая разрешённые цвета. Изменяйте операцию, хранящуюся в коллекции преобразований, где доступны записываемые члены; иначе удалите её и добавьте замену с новыми параметрами создания.

**Какой формат использовать для сохранения цепочки преобразований?**

Используйте PPTX и проверьте файл, повторно открыв его. Устаревший PPT не может полностью представить модель эффектов DrawingML, а экспортные форматы сохраняют только внешний вид, а не редактируемые операции преобразования.