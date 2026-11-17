---
title: Управление эффектами преобразования изображений в презентациях с Python
linktitle: Эффекты преобразования изображений
type: docs
weight: 11
url: /ru/python-net/image-transform-effects/
keywords:
- преобразование изображения
- эффект изображения
- яркость
- контраст
- градация
- дутон
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
- Aspose.Slides
description: "Применяйте, комбинируйте, проверяйте, удаляйте и проверяйте эффекты преобразования изображений для рамок изображений с Aspose.Slides для Python через .NET."
---
## **Обзор**

Aspose.Slides представляет корректировки изображения как упорядоченную коллекцию операций преобразования изображений. Для рамки изображения начните с её [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) и получайте её свойство [image_transform](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image_transform/). Возвращаемый [ImageTransformOperationCollection](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/) позволяет добавлять, перечислять, проверять, удалять и очищать эффекты без переписывания оригинальных байтов изображения.

В этой статье демонстрируется полный рабочий процесс для яркости и контрастности, цветовых преобразований, размытия, прозрачности, упорядоченных цепочек эффектов, эффективных значений, удаления и проверки раунд‑трипом PPTX.

## **Понимание владения эффектом и повторного использования изображения**

Ресурс изображения и изображение, которое его отображает, — это разные объекты:

- [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) хранит или ссылается на исходные данные изображения, принадлежащие презентации.
- [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) относится к заполнению изображения и ссылается на ресурс изображения, одновременно храня коллекцию преобразований изображения.
- [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) — это объект формы слайда, который владеет соответствующим заполнением изображения, геометрией, настройками кадрирования и другими параметрами уровня рамки.

Поэтому операции преобразования изображения не изменяют байты в [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/). Когда один и тот же `PPImage` передаётся в [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) более одного раза, каждый новый кадр получает собственный `Picture` и собственную коллекцию преобразований. Применение градации к одному кадру не делает остальные кадры градационными, даже если они используют один и тот же встроенный ресурс изображения.

Та же модель `Picture.image_transform` используется другими заполнениями изображений, например формой или фоном слайда. Примеры ниже сосредоточены на кадрах изображений.

## **Используйте допустимые диапазоны параметров и единицы измерения**

Продемонстрированные методы используют следующие семантические диапазоны и единицы измерения. Сохраняйте значения в этих диапазонах, даже если конкретная версия библиотеки не отклоняет каждое выходящее за пределы значение сразу; целевой формат презентации может нормализовать, опустить или отклонить недопустимые данные при сохранении или при открытии файла PowerPoint.

| Операция | Параметры | Допустимый диапазон и единица измерения |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100` … `100`, процентов; `0` оставляет компонент без изменений. |
| [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | Нет | Нет числовых параметров. Альфа остаётся без изменений. |
| [add_duotone_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | Два цвета для тёмных и светлых пикселей. Каналы RGB и альфа используют значения от `0` до `255`. |
| [add_tint_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | Оттенок от `0` включительно до `360` исключительно, в градусах; количество от `-100` до `100`, процентов. |
| [add_hsl_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | Оттенок от `0` включительно до `360` исключительно, в градусах; насыщенность и яркость от `-100` до `100`, процентов. |
| [add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | Цвет замены использует значения каналов от `0` до `255`. Существующая альфа остаётся без изменений. |
| [add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | Радиус неотрицательный и измеряется в пунктах; `grow` — Boolean, определяющий, может ли размазанный контент выходить за пределы оригинального изображения. |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | Неотрицательный процент. Используйте `0` … `100` для обычного масштабирования непрозрачности: `0` полностью прозрачно, `100` сохраняет существующую альфу. |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0` … `100`, процентов непрозрачности. |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0` … `100`, процентов порога альфа. Значения ниже становятся прозрачными; значения, равные или выше – непрозрачными. |

Для фиксированной модуляции альфа прозрачность и непрозрачность являются взаимодополняющими. Например, 35 % прозрачности соответствует значению модуляции альфа 65 %.

## **Применение яркости и контрастности**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) возвращает объект операции [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/). Его скалярные настройки задаются при создании операции. [BrightnessContrast.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) возвращает вычисленные только для чтения значения, которые можно просматривать или записывать в лог.

Следующий пример увеличивает яркость на 15 % и контрастность на 20 %, затем отображает предварительный просмотр без изменения встроенного изображения:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    brightness_contrast = image_transform.add_brightness_contrast_effect(15, 20)

    effective_values = brightness_contrast.get_effective()
    print("Brightness: " + str(effective_values.brightness) + "%")
    print("Contrast: " + str(effective_values.contrast) + "%")

    with slide.get_image() as preview:
        preview.save("brightness-contrast-preview.png")
```

[BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) является расширением эффекта изображения Office 2010 и менее переносим, чем стандартный эффект яркости DrawingML. Когда яркость и контрастность должны оставаться редактируемыми после раунд‑трипа PPTX, используйте [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) и проверьте результат после повторного открытия файла. Раздел ограничений формата объясняет это различие подробнее.

## **Применение цветовых преобразований**

Цветовые эффекты можно применять независимо к различным кадрам, использующим один ресурс изображения. Следующий пример создаёт пять кадров и применяет градацию, дутон, оттенок, регулировку HSL и замену цвета.

[Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) содержит два независимо редактируемых параметра цвета: `color1` отвечает за тёмные пиксели, а `color2` — за светлые. Это делает его полезным примером эффекта с более сложными настройками, чем один скаляр.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    gray_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 180, 120, image)
    gray_frame.picture_format.picture.image_transform.add_gray_scale_effect()

    duotone_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 180, 120, image)
    duotone = duotone_frame.picture_format.picture.image_transform.add_duotone_effect()
    duotone.color1.color = draw.Color.navy
    duotone.color2.color = draw.Color.gold

    tint_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 420, 20, 180, 120, image)
    tint_frame.picture_format.picture.image_transform.add_tint_effect(210, 35)

    hsl_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 120, 170, 180, 120, image)
    hsl_frame.picture_format.picture.image_transform.add_hsl_effect(30, 20, -10)

    replacement_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.picture_format.picture.image_transform.add_color_replace_effect()
    color_replacement.color.color = draw.Color.cornflower_blue

    presentation.save("color-transformations.pptx", slides.export.SaveFormat.PPTX)
```

[add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) заменяет каждый пиксель фиксированным цветом, сохраняя альфа‑канал. Это отличается от [add_color_change_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/), который сопоставляет один исходный цвет с другим и раскрывает форматы как исходного, так и целевого цвета.

### **Применение порога яркости**

Порог яркости может сделать слабые следы на отсканированной странице более различимыми от фона. [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) сохраняет промежуточные оттенки серого. [add_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_bi_level_effect/) сопоставляет яркость чёрному или белому, тогда как [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) применяет порог к непрозрачности.

Порог яркости варьируется от 0 % до 100 % включительно. Пиксели ниже порога становятся чёрными. Пиксели, равные или выше порога, становятся белыми. Повышение порога делает больше оттенков чёрными, потому что больше их попадает ниже порога.

Скачайте [grayscale-swatches.png](grayscale-swatches.png) в рабочий каталог. Каждая метка указывает исходный уровень серого от 0 до 255. Пример размещает оригинал рядом с двумя копиями и сохраняет порог каждой копии в презентации.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 150, slides.SlideSizeScaleType.DO_NOT_SCALE)
    shapes = presentation.slides[0].shapes

    with slides.Images.from_file("grayscale-swatches.png") as source_image:
        image = presentation.images.add_image(source_image)

    def add_frame(x, caption):
        label = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, 12, 216, 36)
        label.text_frame.text = caption
        return shapes.add_picture_frame(slides.ShapeType.RECTANGLE, x, 60, 216, 72, image)

    add_frame(12, "Original")

    low_threshold = add_frame(252, "Threshold 20%")
    low_threshold.picture_format.picture.image_transform.add_bi_level_effect(20)
    
    high_threshold = add_frame(492, "Threshold 60%")
    high_threshold.picture_format.picture.image_transform.add_bi_level_effect(60)

    presentation.save("luminance-threshold.pptx", slides.export.SaveFormat.PPTX)
```

Откройте полученную презентацию в PowerPoint, чтобы сравнить три кадра. Образец, помеченный 96, имеет около 38 % яркости (96 из 255). Он становится белым при пороге 20 % и чёрным при пороге 60 %.

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **Добавление размытия, прозрачности и альфа‑эффектов**

[add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) влияет на все цветовые каналы, включая альфа. Установите `grow` в `True`, когда размытый край может выходить за пределы исходных границ изображения.

Для равномерной прозрачности используйте [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/). Он умножает каждое существующее значение альфа, поэтому частично прозрачные пиксели остаются пропорционально различными. [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) вместо этого присваивает одно значение альфа всем пикселям. [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) преобразует альфа в два уровня на основе порога.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    blurred_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 140, image)
    blur = blurred_frame.picture_format.picture.image_transform.add_blur_effect(4.5, True)
    blur.radius = 5

    transparent_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.picture_format.picture.image_transform.add_alpha_modulate_fixed_effect(65)
    alpha_modulate.amount = 60

    uniform_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 180, 200, 140, image)
    uniform_alpha_frame.picture_format.picture.image_transform.add_alpha_replace_effect(55)

    binary_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.picture_format.picture.image_transform.add_alpha_bi_level_effect(50)
    alpha_bi_level.threshold = 45
    binary_alpha_frame.picture_format.picture.image_transform.add_alpha_inverse_effect()

    presentation.save("blur-and-alpha-effects.pptx", slides.export.SaveFormat.PPTX)
```

Другие операции альфа без параметров включают [add_alpha_ceiling_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/), который делает каждый ненулевой альфа полностью непрозрачным; [add_alpha_floor_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/), который делает каждый альфа ниже 100 % полностью прозрачным; и [add_alpha_inverse_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/), который меняет альфа на `100% - alpha`.

## **Создание упорядоченной цепочки эффектов**

Каждый метод `add_..._effect` добавляет новую операцию в конец коллекции. Рендерер использует коллекцию как упорядоченный конвейер: вывод операции 0 становится вводом операции 1 и так далее. Поэтому одинаковые операции в разном порядке могут дать разный результат.

Например, градация, а затем оттенок сначала удаляют хроматическую информацию, а затем перекрашивают результат яркости. Оттенок, а затем градация удаляют оттенок снова. Аналогично, замена альфа может переопределить значения альфа, вычисленные предыдущими операциями, тогда как модуляция альфа сохраняет их относительные различия.

Следующий пример строит цепочку из четырёх операций, сохраняет её как PPTX, повторно открывает презентацию, проверяет типы и порядок операций и рендерит полученный результат:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    image_transform.add_gray_scale_effect()
    image_transform.add_tint_effect(220, 25)
    image_transform.add_blur_effect(2.5, False)
    image_transform.add_alpha_modulate_fixed_effect(80)

    presentation.save("image-transform-chain.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("image-transform-chain.pptx") as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]

    if isinstance(reopened_shape, slides.PictureFrame):
        reopened_transform = reopened_shape.picture_format.picture.image_transform
        order_is_preserved = (
            len(reopened_transform) == 4 and
            isinstance(reopened_transform[0], slides.effects.GrayScale) and
            isinstance(reopened_transform[1], slides.effects.Tint) and
            isinstance(reopened_transform[2], slides.effects.Blur) and
            isinstance(reopened_transform[3], slides.effects.AlphaModulateFixed)
        )
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        with reopened_presentation.slides[0].get_image() as rendered_slide:
            rendered_slide.save("reopened-effect-chain.png")
    else:
        print("The reopened shape is not a picture frame.")
```

Коллекция не накладывает матрицу совместимости, ограничивающую цветовые, альфа‑ и размытие операции отдельными цепочками. Их можно комбинировать, но комбинации не всегда полезны. Фиксированная замена цвета удаляет вариацию RGB, созданную предыдущими цветовыми эффектами; градация после дутон удаляет два выбранных цвета; операции потолка, пола, замены альфа или би‑уровня могут отбрасывать детали альфа, созданные ранее. Формируйте цепочку согласно желаемой последовательности обработки пикселей, а не как набор несортированных флагов форматирования.

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In this illustrative Aspose.Slides for .NET 26.11 render, a 220° tint at 25% leaves the grayscale image unchanged. Applying the same tint before grayscale produces different tones.*
<!-- visual-explanation:image-transform-effects:end -->

## **Проверка редактируемых и эффективных значений**

Редактируемая операция — это объект, хранящийся в `Picture.image_transform`. В зависимости от эффекта могут быть доступны записываемые члены напрямую. Например, [Blur](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/) предоставляет записываемые свойства `radius` и `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphamodulatefixed/) — записываемое свойство `amount`, а [AlphaBiLevel](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphabilevel/) — записываемое свойство `threshold`. Цветовые эффекты, такие как [Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/), раскрывают изменяемые объекты [ColorFormat](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/).

Некоторые операции, включая [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/python-net/aspose.slides.effects/hsl/), [Tint](https://reference.aspose.com/slides/python-net/aspose.slides.effects/tint/), и [AlphaReplace](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphareplace/), не раскрывают свои скалярные параметры как записываемые свойства. Чтобы изменить эти настройки, удалите операцию и добавьте замену в нужном положении.

Эффективные данные, возвращаемые `get_effective()`, вычисляются и доступны только для чтения. Они полезны для разрешения зависящих от темы цветов и чтения нормализованных значений, используемых рендерером, но не являются отдельной поверхностью редактирования. Следующий пример перечисляет цепочку и проверяет эффективные значения там, где соответствующий API их предоставляет:

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform

        for index, operation in enumerate(image_transform):
            print(str(index) + ": " + type(operation).__name__)

            if isinstance(operation, slides.effects.BrightnessContrast):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Luminance):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Duotone):
                effect_data = operation.get_effective()
                print("  Dark color: " + str(effect_data.color1))
                print("  Light color: " + str(effect_data.color2))
            elif isinstance(operation, slides.effects.ColorReplace):
                effect_data = operation.get_effective()
                print("  Replacement color: " + str(effect_data.color))
            elif isinstance(operation, slides.effects.HSL):
                effect_data = operation.get_effective()
                print("  HSL: " + str(effect_data.hue) + ", " + str(effect_data.saturation) + ", " + str(effect_data.luminance))
            elif isinstance(operation, slides.effects.Tint):
                effect_data = operation.get_effective()
                print("  Tint: " + str(effect_data.hue) + ", " + str(effect_data.amount))
            elif isinstance(operation, slides.effects.Blur):
                effect_data = operation.get_effective()
                print("  Blur radius: " + str(effect_data.radius) + " pt")
            elif isinstance(operation, slides.effects.AlphaModulateFixed):
                effect_data = operation.get_effective()
                print("  Alpha amount: " + str(effect_data.amount) + "%")
            elif isinstance(operation, slides.effects.AlphaReplace):
                effect_data = operation.get_effective()
                print("  Replacement alpha: " + str(effect_data.alpha) + "%")
            elif isinstance(operation, slides.effects.AlphaBiLevel):
                effect_data = operation.get_effective()
                print("  Alpha threshold: " + str(effect_data.threshold) + "%")
```

Эффекты без параметров, такие как градация, потолок альфа и обратный альфа, тоже имеют объект эффективных данных, но скалярных настроек для вывода нет. Их наличие и позиция в коллекции — важная информация.

## **Удаление или очистка преобразований изображения**

Используйте [ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) для удаления одной операции по индексу. Поскольку индексы сдвигаются после удаления, сначала найдите целевой элемент, а затем удалите его после перечисления. Вызов `clear()` удалит всю цепочку.

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform
        blur_index = None

        for index, operation in enumerate(image_transform):
            if isinstance(operation, slides.effects.Blur):
                blur_index = index
                break

        if blur_index is not None:
            image_transform.remove_at(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: " + str(len(image_transform)))
        presentation.save("image-transforms-cleared.pptx", slides.export.SaveFormat.PPTX)
```

Удаление или очистка преобразований меняет только форматирование изображения. Это не удаляет, не перепаковывает и не изменяет повторно используемый ресурс [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/).

## **Учёт форматов презентаций и целевых экспортов**

Преобразования изображений происходят в DrawingML, поэтому PPTX является предпочтительным редактируемым форматом для цепочек эффектов. Даже в PPTX не каждая операция обладает одинаковой портативностью:

- Стандартные операции DrawingML, такие как luminance, grayscale, duotone, tint, HSL, blur и обычные альфа‑операции, имеют наибольшие шансы сохраниться после раунд‑трипа PPTX. Всегда переоткрывайте сгенерированный файл и проверяйте коллекцию, когда требуется сохранность.
- [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) — расширение Office 2010, а не стандартная операция luminance DrawingML. Его можно использовать для рендеринга в памяти, но нет гарантии, что после сохранения и повторного открытия PPTX он останется редактируемой операцией `BrightnessContrast`. Предпочтительно использовать [add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) для постоянных настроек яркости и контрастности.
- Бинарный формат PPT предшествовал полной модели эффектов DrawingML. Сохранение в PPT может опускать неподдерживаемые операции, сокращать цепочку до поддерживаемого подмножества или приближать внешний вид. Не используйте PPT как формат проверки для сложных редактируемых цепочек.
- Рендеринг в PNG, JPEG, TIFF, PDF, SVG, HTML или другие визуальные форматы применяет поддерживаемую цепочку к визуальному результату. Эти выводы не содержат редактируемой `ImageTransformOperationCollection`; растровые форматы «плоско» фиксируют результат в пикселях, а документные или векторные экспорты сохраняют собственное представление рендеринга.
- Эффекты не делают связанную картинку самостоятельной. Рендеринг связанного изображения всё равно требует наличия связанного ресурса при загрузке презентации.

Разные потребители презентаций могут по‑разному отображать граничные случаи, особенно при комбинировании нескольких альфа‑ или цветоквантизационных операций. Для критически важного вывода тестируйте как редактируемый раунд‑трип, так и конечный экспортный формат с тем же вариантом Aspose.Slides, который используется в продакшене.

## **FAQ**

**Модифицируют ли эффекты преобразования изображения встроенные данные изображения?**

Нет. Операции принадлежат `Picture`, используемому в заполнении изображения. Байты базового `PPImage` остаются без изменений.

**Будут ли два кадра, использующие одно и то же изображение, делить свои эффекты?**

Нет. Повторное использование `PPImage` избавляет от дублирования данных изображения, но каждый кадр обычно имеет отдельный `Picture` и собственную коллекцию преобразований изображения.

**Можно ли комбинировать цветовые, размытие и альфа‑эффекты?**

Да. Коллекция принимает их в одной упорядоченной цепочке. Учтите, как каждая операция влияет на вывод предыдущей, потому что операции замены и пороговые могут отбрасывать прежние цветовые или альфа‑детали.

**Почему эффективные значения только для чтения?**

Эффективные данные представляют вычисленные значения, используемые при рендеринге, включая разрешённые цвета. Редактируйте операцию, хранящуюся в коллекции, где доступны записываемые члены; иначе удалите её и добавьте замену с новыми параметрами создания.

**Какой формат следует использовать для сохранения цепочки преобразований?**

Используйте PPTX и проверьте файл, переоткрыв его. Устаревший PPT не может полностью представить модель эффектов DrawingML, а форматы визуального экспорта сохраняют только внешний вид, а не редактируемые операции преобразования.