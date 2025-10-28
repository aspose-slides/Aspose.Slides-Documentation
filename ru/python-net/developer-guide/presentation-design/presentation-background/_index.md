---
title: Управление фоновыми изображениями презентаций в Python
linktitle: Фон слайда
type: docs
weight: 20
url: /ru/python-net/presentation-background/
keywords:
- фон презентации
- фон слайда
- сплошной цвет
- градиентный цвет
- фон изображения
- прозрачность фона
- свойства фона
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как задавать динамические фоны в файлах PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET, с подсказками кода для улучшения ваших презентаций."
---

## **Обзор**

Сплошные цвета, градиенты и изображения часто используют в качестве фоновых изображений слайдов. Вы можете задать фон для **обычного слайда** (одного слайда) или **слайда‑мастера** (который применяется сразу к нескольким слайдам).

![Фон PowerPoint](powerpoint-background.png)

## **Установка сплошного цветного фона для обычного слайда**

Aspose.Slides позволяет задать сплошной цвет в качестве фона для конкретного слайда в презентации — даже если презентация использует слайд‑мастер. Изменение применяется только к выбранному слайду.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Установите для слайда свойство [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) в значение `OWN_BACKGROUND`.
3. Установите для фонового заливки слайда свойство [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) в значение `SOLID`.
4. Используйте свойство `solid_fill_color` на [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) для указания сплошного цвета фона.
5. Сохраните изменённую презентацию.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Set the background color of the slide to blue.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # Save the presentation to disk.
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Установка сплошного цветного фона для слайда‑мастера**

Aspose.Slides позволяет задать сплошной цвет в качестве фона для слайда‑мастера презентации. Слайд‑мастер действует как шаблон, контролирующий форматирование всех слайдов, поэтому при выборе сплошного цвета для его фона он будет применён ко всем слайдам.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Установите для слайда‑мастера свойство [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) (через `masters`) в значение `OWN_BACKGROUND`.
3. Установите для фоновой заливки слайда‑мастера свойство [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) в значение `SOLID`.
4. Используйте свойство `solid_fill_color` на [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) для указания сплошного цвета фона.
5. Сохраните изменённую презентацию.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # Set the background color for the Master slide to Forest Green.
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # Save the presentation to disk.
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Установка градиентного фона для слайда**

Градиент — это графический эффект, создаваемый постепённым изменением цвета. При использовании в качестве фонового изображения слайда градиенты делают презентацию более художественной и профессиональной. Aspose.Slides позволяет задать градиентный цвет в качестве фона для слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Установите для слайда свойство [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) в значение `OWN_BACKGROUND`.
3. Установите для фоновой заливки слайда свойство [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) в значение `GRADIENT`.
4. Используйте свойство `gradient_format` на [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) для настройки нужных параметров градиента.
5. Сохраните изменённую презентацию.

```python
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Apply a gradient effect to the background.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Save the presentation to disk.
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Установка изображения в качестве фона слайда**

Помимо сплошных и градиентных заливок, Aspose.Slides позволяет использовать изображения в качестве фоновых изображений слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Установите для слайда свойство [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) в значение `OWN_BACKGROUND`.
3. Установите для фоновой заливки слайда свойство [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) в значение `PICTURE`.
4. Загрузите изображение, которое хотите использовать в качестве фонового.
5. Добавьте изображение в коллекцию изображений презентации.
6. Используйте свойство `picture_fill_format` на [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) для назначения изображения фоном.
7. Сохраните изменённую презентацию.

```python
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Set background image properties.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Load the image.
    with slides.Images.from_file("Tulips.jpg") as image:
        # Add the image to the presentation's image collection.
        pp_image = presentation.images.add_image(image)

    slide.background.fill_format.picture_fill_format.picture.image = pp_image

    # Save the presentation to disk.
    presentation.save("ImageAsBackground.pptx", slides.export.SaveFormat.PPTX)
```

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # Set the image used for the background fill.
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # Set the picture fill mode to Tile and adjust the tile properties.
    back_picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    back_picture_fill_format.tile_offset_x = 15.0
    back_picture_fill_format.tile_offset_y = 15.0
    back_picture_fill_format.tile_scale_x = 46.0
    back_picture_fill_format.tile_scale_y = 87.0
    back_picture_fill_format.tile_alignment = slides.RectangleAlignment.CENTER
    back_picture_fill_format.tile_flip = slides.TileFlip.FLIP_Y

    presentation.save("TileBackground.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}}
Подробнее: [**Tile Picture As Texture**](/slides/ru/python-net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Изменение прозрачности фонового изображения**

Возможно, вам понадобится отрегулировать прозрачность фонового изображения слайда, чтобы выделить содержимое слайда. Следующий Python‑код показывает, как изменить прозрачность фонового изображения слайда:

```python
transparency_value = 30  # For example.

# Get the collection of picture transform operations.
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# Find an existing fixed-percentage transparency effect.
for operation in image_transform:
    if type(operation) is slides.AlphaModulateFixed:
        transparency_operation = operation
        break

# Set the new transparency value.
if transparency_operation is None:
    image_transform.add_alpha_modulate_fixed_effect(100 - transparency_value)
else:
    transparency_operation.amount = 100 - transparency_value
```

## **Получение значения фонa слайда**

Aspose.Slides предоставляет класс [IBackgroundEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/) для получения эффективных значений фона слайда. Этот класс раскрывает эффективные свойства [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) и [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/).

Используя свойство `background` класса [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/), вы можете получить эффективный фон слайда.

```python
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Retrieve the effective background, taking into account master, layout, and theme.
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```

## **Вопросы и ответы**

**Могу ли я сбросить пользовательский фон и восстановить фон темы/макета?**

Да. Удалите пользовательскую заливку слайда, и фон вновь будет унаследован от соответствующего слайда [layout](/slides/ru/python-net/slide-layout/)/[master](/slides/ru/python-net/slide-master/) (т. е. от [theme background](/slides/ru/python-net/presentation-theme/)).

**Что произойдёт с фоном, если я позже изменю тему презентации?**

Если у слайда собственная заливка, она останется без изменений. Если фон унаследован от [layout](/slides/ru/python-net/slide-layout/)/[master](/slides/ru/python-net/slide-master/), он обновится в соответствии с новой темой.