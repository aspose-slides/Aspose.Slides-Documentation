---
title: Manage Presentation Backgrounds in Python
linktitle: Slide Background
type: docs
weight: 20
url: /ru/python-net/presentation-background/
keywords:
- presentation background
- slide background
- solid color
- gradient color
- image background
- background transparency
- background properties
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Learn how to set dynamic backgrounds in PowerPoint and OpenDocument files using Aspose.Slides for Python via .NET, with code tips to boost your presentations."
---

## **Обзор**

Сплошные цвета, градиенты и изображения часто используют в качестве фона слайдов. Вы можете задать фон для **обычного слайда** (одного слайда) или **мастер‑слайда** (применяется сразу к нескольким слайдам).

![PowerPoint background](powerpoint-background.png)

## **Установка сплошного цветного фона для обычного слайда**

Aspose.Slides позволяет задать сплошной цвет фона для конкретного слайда презентации — даже если презентация использует мастер‑слайд. Изменение применяется только к выбранному слайду.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Установите свойство [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) слайда в `OWN_BACKGROUND`.
3. Установите [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) фона слайда в `SOLID`.
4. Используйте свойство `solid_fill_color` объекта [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) для указания сплошного цвета фона.
5. Сохраните изменённую презентацию.

Ниже приведён пример на Python, показывающий, как установить синий сплошной цвет в качестве фона обычного слайда:

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

## **Установка сплошного цветного фона для мастер‑слайда**

Aspose.Slides позволяет задать сплошной цвет в качестве фона мастер‑слайда презентации. Мастер‑слайд выступает как шаблон, управляя форматированием всех слайдов, поэтому при выборе сплошного цвета для фона мастер‑слайда он будет применён к каждому слайду.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Установите [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) мастер‑слайда (через `masters`) в `OWN_BACKGROUND`.
3. Установите [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) фона мастер‑слайда в `SOLID`.
4. Используйте свойство `solid_fill_color` объекта [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) для указания сплошного цвета фона.
5. Сохраните изменённую презентацию.

Ниже показан пример Python, где в качестве фона мастер‑слайда задаётся сплошной цвет (лесной зелёный):

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

Градиент — это графический эффект, создаваемый постепённым изменением цвета. При использовании его в качестве фона слайда градиенты делают презентацию более художественной и профессиональной. Aspose.Slides позволяет задать градиентный цвет фона для слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Установите [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) слайда в `OWN_BACKGROUND`.
3. Установите [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) фона слайда в `GRADIENT`.
4. Используйте свойство `gradient_format` объекта [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) для настройки желаемых параметров градиента.
5. Сохраните изменённую презентацию.

Пример Python, показывающий, как задать градиентный цвет в качестве фона слайда:

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

Помимо сплошных и градиентных заливок, Aspose.Slides позволяет использовать изображения в качестве фона слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Установите [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) слайда в `OWN_BACKGROUND`.
3. Установите [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) фона слайда в `PICTURE`.
4. Загрузите изображение, которое хотите использовать в качестве фона слайда.
5. Добавьте изображение в коллекцию изображений презентации.
6. Используйте свойство `picture_fill_format` объекта [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) для назначения изображения фоном.
7. Сохраните изменённую презентацию.

Пример Python, показывающий, как задать изображение в качестве фона слайда:

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

Ниже пример кода, показывающий, как задать тип заливки фона в виде замощённого изображения и изменить свойства замощения:

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

Подробнее: [**Картинка плитки как текстура**](/slides/ru/python-net/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Изменение прозрачности фонового изображения**

Возможно, потребуется отрегулировать прозрачность фонового изображения слайда, чтобы выделить содержимое. Ниже показан пример кода на Python, который меняет прозрачность фонового изображения слайда:

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

## **Получение значения фона слайда**

Aspose.Slides предоставляет класс [IBackgroundEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/) для получения фактических значений фона слайда. Этот класс раскрывает эффективные [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) и [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/).

С помощью свойства `background` класса [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/) можно получить эффективный фон слайда.

Пример Python, показывающий, как получить эффективное значение фона слайда:

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

## **FAQ**

**Можно ли сбросить пользовательский фон и восстановить фон темы/макета?**

Да. Удалите пользовательскую заливку слайда, и фон будет вновь наследоваться от соответствующего [layout](/slides/ru/python-net/slide-layout/)/[master](/slides/ru/python-net/slide-master/) слайда (т.е. от [theme background](/slides/ru/python-net/presentation-theme/)).

**Что произойдёт с фоном, если позже изменить тему презентации?**

Если у слайда есть собственная заливка, она останется неизменной. Если фон наследуется от [layout](/slides/ru/python-net/slide-layout/)/[master](/slides/ru/python-net/slide-master/), он обновится в соответствии с новой темой.