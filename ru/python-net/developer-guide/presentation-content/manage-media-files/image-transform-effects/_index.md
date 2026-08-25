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
- градация серого
- дуотон
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
- Aspose.Slides
description: "Применяйте, объединяйте, проверяйте, удаляйте и подтверждайте эффекты преобразования изображений для рамок изображений с Aspose.Slides для Python через .NET."
---
## **Обзор**

Aspose.Slides представляет коррекцию изображений как упорядоченную коллекцию операций преобразования изображений. Для кадра изображения начните с свойства [Picture](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picture/) и получите доступ к его свойству [image_transform](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picture/image_transform/). Возвращаемая [ImageTransformOperationCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/imagetransformoperationcollection/) позволяет добавлять, перечислять, просматривать, удалять и очищать эффекты без переписывания оригинальных байтов изображения.

В этой статье демонстрируется полный рабочий процесс для яркости и контрастности, цветовых преобразований, размытия, прозрачности, упорядоченных цепочек эффектов, эффективных значений, удаления и проверки обратного прохода PPTX.

## **Понимание владения эффектами и повторного использования изображений**

Ресурс изображения и изображение, которое его отображает, являются разными объектами:

- [PPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/) хранит или ссылается на исходные данные изображения, принадлежащие презентации.
- [Picture](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picture/) относится к заливке изображения и ссылается на ресурс изображения, одновременно храня коллекцию преобразований изображения.
- [PictureFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframe/) — это форма слайда, которая владеет соответствующей заливкой изображения, геометрией, параметрами обрезки и другими форматированиями уровня кадра.

Следовательно, операции преобразования изображения не изменяют байты в [PPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/). Когда один и тот же `PPImage` передаётся в [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapecollection/add_picture_frame/) более одного раза, каждый новый кадр получает свой собственный `Picture` и собственную коллекцию преобразований. Применение градации серого к одному кадру не делает остальные кадры градацией серого, хотя все они используют один и тот же встроенный ресурс изображения.

Та же модель `Picture.image_transform` используется и другими заливками изображений, например фигурой или фоном слайда. Примеры ниже сосредоточены на кадрах изображений.

## **Использование допустимых диапазонов параметров и единиц измерения**

Продемонстрированные методы используют следующие семантические диапазоны и единицы. Сохраняйте значения в этих диапазонах, даже если конкретная версия библиотеки не отклоняет каждое выходящее за пределы значение сразу; целевой формат презентации может нормализовать, опустить или отклонить недопустимые данные при сохранении или при открытии файла в PowerPoint.

| Операция | Параметры | Действительный диапазон и единица измерения |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100` до `100`, в процентах; `0` оставляет компонент без изменений. |
| [add_gray_scale_effect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | Нет | Нет числовых параметров. Альфа остаётся неизменной. |
| [add_duotone_effect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | Два цвета для тёмных и светлых пикселей. Каналы RGB и альфа используют значения от `0` до `255`. |
| [add_tint_effect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | Тон (`hue`) от `0` включительно до `360` исключительно, в градусах; количество (`amount`) от `-100` до `100`, в процентах. |
| [add_hsl_effect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | Тон от `0` включительно до `360` исключительно, в градусах; насыщенность и яркость от `-100` до `100`, в процентах. |
| [add_color_replace_effect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | Цвет замены использует значения каналов от `0` до `255`. Существующая альфа остаётся неизменной. |
| [add_blur_effect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | Радиус неотрицательный, измеряется в пунктах; `grow` — логическое, контролирующее, может ли размытый контент выходить за пределы исходных границ. |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | Неотрицательный процент. Используйте `0`–`100` для обычного масштабирования непрозрачности: `0` — полностью прозрачный, `100` — сохраняет существующую альфа. |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0`–`100`, процент непрозрачности. |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0`–`100`, процентный порог альфа. Значения ниже становятся прозрачными; значения, равные или превышающие порог, становятся непрозрачными. |

Для фиксированной модуляции альфа прозрачность и непрозрачность являются взаимодополняющими. Например, 35 % прозрачности соответствует параметру модуляции альфа = 65 %.

## **Применение яркости и контраста**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) возвращает операцию [BrightnessContrast](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/brightnesscontrast/). Ее скалярные настройки задаются при создании операции. [BrightnessContrast.get_effective](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) возвращает вычисленные только для чтения значения, которые можно просмотреть или записать в журнал.

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

[BrightnessContrast](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/brightnesscontrast/) — расширение эффекта изображения Office 2010 и менее переносимо, чем стандартный эффект luminance DrawingML. Когда яркость и контрастность должны оставаться редактируемыми после обратного прохода PPTX, используйте [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) и проверьте результат после повторного открытия файла. Раздел ограничений формата объясняет это различие более подробно.

## **Применение цветовых преобразований**

Цветовые эффекты могут применяться независимо к разным кадрам, использующим один и тот же ресурс изображения. Следующий пример создаёт пять кадров и применяет градацию серого, дуотон, оттенок, настройку HSL и замену цвета.

[Duotone](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/duotone/) содержит два независимо редактируемых параметра цвета: `color1` сопоставляется тёмным пикселям, а `color2` — светлым пикселям. Это делает его полезным примером эффекта с более сложными настройками, чем один скаляр.

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

[add_color_replace_effect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) заменяет цвет каждого пикселя на один фиксированный цвет, сохраняя альфа‑канал. Это отличается от [add_color_change_effect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/), который сопоставляет один исходный цвет другому и раскрывает форматы как исходного, так и целевого цвета.

## **Добавление размытия, прозрачности и альфа‑эффектов**

[add_blur_effect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) воздействует на все каналы цвета, включая альфа. Установите `grow` в `True`, когда размытый край может выходить за пределы исходных границ изображения.

Для равномерной прозрачности используйте [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/). Он умножает каждое существующее значение альфа, поэтому частично прозрачные пиксели сохраняют относительные различия. [add_alpha_replace_effect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) вместо этого назначает одно значение альфа всем пикселям. [add_alpha_bi_level_effect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) преобразует альфа в два уровня на основе порога.

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

К другим альфа‑операциям без параметров относятся [add_alpha_ceiling_effect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/), который делает каждый ненулевой альфа полностью непрозрачным; [add_alpha_floor_effect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/), который делает каждый альфа ниже 100 % полностью прозрачным; и [add_alpha_inverse_effect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/), который меняет альфа на `100% - alpha`.

## **Создание упорядоченной цепочки эффектов**

Каждый метод `add_..._effect` добавляет новую операцию в конец коллекции. Рендерер использует коллекцию как упорядоченный конвейер: вывод операции 0 становится входом операции 1 и т.д. Следовательно, одинаковые операции в разном порядке могут дать разный результат.

Например, градация серого, а затем оттенок сначала удаляют цветовую информацию, а затем перекрашивают полученный результат яркости. Оттенок, за которым следует градация серого, снова удаляет оттенок. Аналогично, замена альфа может переопределить значения альфа, рассчитанные более ранними операциями, тогда как модуляция альфа сохраняет их относительные различия.

Следующий пример создает цепочку из четырёх операций, сохраняет её как PPTX, открывает презентацию снова, проверяет типы операций и их порядок, а затем отображает результат после повторного открытия:

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

Коллекция не накладывает матрицу совместимости, ограничивающую цветовые, альфа‑ и размытие операции отдельными цепочками. Их можно комбинировать, но комбинации не всегда полезны. Фиксированная замена цвета удаляет вариации RGB, созданные ранее цветными эффектами; градация серого после дуотона удаляет два выбранных цвета; а операции альфа‑ceiling, floor, replacement или bi‑level могут отбрасывать детали альфа, созданные ранее. Формируйте цепочку согласно желаемой последовательности обработки пикселей, а не рассматривайте её элементы как неупорядоченные флаги форматирования.

## **Проверка редактируемых и эффективных значений**

Редактируемая операция — это объект, хранящийся в `Picture.image_transform`. В зависимости от эффекта, он может напрямую раскрывать записываемые члены. Например, [Blur](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/blur/) раскрывает записываемые свойства `radius` и `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/alphamodulatefixed/) раскрывает записываемое свойство `amount`, а [AlphaBiLevel](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/alphabilevel/) раскрывает записываемое свойство `threshold`. Цветовые эффекты, такие как [Duotone](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/duotone/), раскрывают изменяемые объекты [ColorFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/colorformat/).

Некоторые операции, включая [BrightnessContrast](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/hsl/), [Tint](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/tint/) и [AlphaReplace](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/alphareplace/), не раскрывают свои скалярные параметры как записываемые свойства. Чтобы изменить эти настройки, удалите операцию и добавьте замену на нужной позиции.

Эффективные данные, возвращаемые `get_effective()`, вычисляются и только для чтения. Они полезны для определения цветов, зависящих от темы, и чтения нормализованных значений, используемых рендерером, но не являются отдельной поверхностью редактирования. Следующий пример перечисляет цепочку и проверяет эффективные значения, где соответствующий API их предоставляет:

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

Эффекты без параметров, такие как градация серого, альфа‑ceiling и альфа‑inverse, также имеют объект эффективных данных, но нет скалярных настроек для вывода. Их наличие и позиция в коллекции являются важной информацией.

## **Удаление или очистка преобразований изображения**

Используйте [ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) для удаления одной операции по индексу. Поскольку индексы смещаются после удаления, сначала найдите нужный элемент, а затем удалите его после перечисления. Вызов `clear()` удаляет всю цепочку.

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

Удаление или очистка преобразований меняет только форматирование изображения. Это не удаляет, не перекомпрессирует и не изменяет повторно используемый ресурс [PPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/).

## **Рассмотрение форматов презентаций и целей экспорта**

Преобразования изображений происходят в DrawingML, поэтому PPTX — предпочтительный редактируемый формат для цепочек эффектов. Даже в PPTX не каждый эффект обладает одинаковой переносимостью:

- Стандартные операции DrawingML, такие как luminance, grayscale, duotone, tint, HSL, blur и распространённые альфа‑операции, имеют наибольшие шансы сохраниться после обратного прохода PPTX. Всегда повторно открывайте сгенерированный файл и проверяйте коллекцию, когда сохранность является требованием.
- [BrightnessContrast](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/brightnesscontrast/) — расширение Office 2010, а не стандартная операция DrawingML luminance. Его можно использовать для рендеринга в памяти, но нет гарантии, что после сохранения и повторного открытия PPTX он останется редактируемой операцией `BrightnessContrast`. Предпочтительно использовать [add_luminance_effect](https://reference.aspose.com/slides/ru/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) для постоянных настроек яркости и контрастности.
- Бинарный формат PPT предшествует полной модели эффектов DrawingML. Сохранение в PPT может опустить неподдерживаемые операции, сократить цепочку до поддерживаемого подмножества или приблизительно оценить внешний вид. Не используйте PPT для проверки сложных редактируемых цепочек.
- Рендеринг в PNG, JPEG, TIFF, PDF, SVG, HTML или другие визуальные форматы применяет поддерживаемую цепочку к полученному изображению. Эти выводы не содержат редактируемой `ImageTransformOperationCollection`; растровые форматы фиксируют результат в пикселях, а экспорт в документы или векторы сохраняет собственное представление рендеринга.
- Эффекты не делают связанное изображение автономным. При рендеринге связанного изображения всё равно требуется наличие связанного ресурса при загрузке презентации.

Разные потребители презентаций могут по‑разному обрабатывать пограничные случаи, особенно когда комбинируются несколько альфа‑ или цветоквантизационных операций. Для критически важного вывода протестируйте как редактируемый обратный проход, так и окончательный экспортный формат с той же версией Aspose.Slides, используемой в продакшене.

## **FAQ**

**Изменяют ли эффекты преобразования изображения встроенные данные изображения?**

Нет. Операции принадлежат `Picture`, используемому в заливке изображения. Базовые байты `PPImage` остаются неизменными.

**Будут ли два кадра, использующие один и тот же ресурс изображения, делить свои эффекты?**

Нет. Повторное использование `PPImage` экономит дублирование данных изображения, но каждый кадр обычно имеет отдельный `Picture` и отдельную коллекцию преобразований изображения.

**Можно ли комбинировать цветовые, размывающие и альфа‑эффекты?**

Да. Коллекция принимает их в одной упорядоченной цепочке. Учитывайте, как каждая операция влияет на результат предыдущей, поскольку операции замены и пороговые операции могут отбрасывать ранее созданные цветовые или альфа‑детали.

**Почему эффективные значения только для чтения?**

Эффективные данные представляют вычисленные значения, используемые для рендеринга, включая разрешённые цвета. Изменяйте операцию, хранящуюся в коллекции преобразований, там где существуют записываемые члены; в противном случае удалите её и добавьте замену с новыми параметрами создания.

**Какой формат следует использовать для сохранения цепочки преобразований?**

Используйте PPTX и проверьте файл, открыв его повторно. Устаревший PPT не может представить полную модель эффектов DrawingML, а форматы экспортируемого изображения сохраняют только внешний вид, а не редактируемые операции преобразования.