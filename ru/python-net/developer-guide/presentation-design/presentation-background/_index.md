---
title: Управление фонами презентаций в Python
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
description: "Узнайте, как устанавливать динамические фоны в файлах PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET, получая советы по коду для улучшения ваших презентаций."
---

## **Обзор**

Сплошные цвета, градиенты и изображения часто используются в качестве фонов слайдов. Вы можете задать фон для **обычного слайда** (одного слайда) или для **главного слайда** (применяется сразу к нескольким слайдам).

![PowerPoint background](powerpoint-background.png)

## **Установить сплошной цвет фона для обычного слайда**

Aspose.Slides позволяет задать сплошной цвет как фон для конкретного слайда в презентации — даже если презентация использует главный слайд. Изменение применяется только к выбранному слайду.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Установите свойству слайда [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) значение `OWN_BACKGROUND`.
3. Установите свойству фона слайда [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) значение `SOLID`.
4. Используйте свойство `solid_fill_color` в [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) для указания сплошного цвета фона.
5. Сохраните изменённую презентацию.

Следующий пример на Python показывает, как задать синий сплошной цвет в качестве фона обычного слайда:
```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Создайте экземпляр класса Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Установите синий цвет фона слайда.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # Сохраните презентацию на диск.
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```


## **Установить сплошной цвет фона для главного слайда**

Aspose.Slides позволяет задать сплошной цвет как фон для главного слайда в презентации. Главный слайд выступает в роли шаблона, контролирующего форматирование всех слайдов, поэтому при выборе сплошного цвета фона главного слайда он применяется к каждому слайду.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Установите свойству главного слайда [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) (через `masters`) значение `OWN_BACKGROUND`.
3. Установите свойству фона главного слайда [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) значение `SOLID`.
4. Используйте свойство `solid_fill_color` в [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) для указания сплошного цвета фона.
5. Сохраните изменённую презентацию.

Следующий пример на Python показывает, как задать сплошной цвет (лесной зелёный) в качестве фона главного слайда:
```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Создайте экземпляр класса Presentation.
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # Установите цвет фона главного слайда в лесной зелёный.
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # Сохраните презентацию на диск.
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```


## **Установить градиентный фон для слайда**

Градиент — это графический эффект, создаваемый постепенным изменением цвета. При использовании в качестве фона слайда градиенты могут сделать презентацию более художественной и профессиональной. Aspose.Slides позволяет задать градиентный цвет в качестве фона слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Установите свойству слайда [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) значение `OWN_BACKGROUND`.
3. Установите свойству фона слайда [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) значение `GRADIENT`.
4. Используйте свойство `gradient_format` в [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) для настройки желаемых параметров градиента.
5. Сохраните изменённую презентацию.

Следующий пример на Python показывает, как задать градиентный цвет в качестве фона слайда:
```python
import aspose.slides as slides

# Создайте экземпляр класса Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Примените градиентный эффект к фону.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Сохраните презентацию на диск.
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```


## **Установить изображение в качестве фона слайда**

Помимо сплошных и градиентных заполнений, Aspose.Slides позволяет использовать изображения в качестве фонов слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Установите свойству слайда [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) значение `OWN_BACKGROUND`.
3. Установите свойству фона слайда [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) значение `PICTURE`.
4. Загрузите изображение, которое хотите использовать в качестве фона слайда.
5. Добавьте изображение в коллекцию изображений презентации.
6. Используйте свойство `picture_fill_format` в [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) для назначения изображения в качестве фона.
7. Сохраните изменённую презентацию.

Следующий пример на Python показывает, как установить изображение в качестве фона слайда:
```python
import aspose.slides as slides

# Создайте экземпляр класса Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Установите свойства фонового изображения.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Загрузите изображение.
    with slides.Images.from_file("Tulips.jpg") as image:
        # Добавьте изображение в коллекцию изображений презентации.
        pp_image = presentation.images.add_image(image)

    slide.background.fill_format.picture_fill_format.picture.image = pp_image

    # Сохраните презентацию на диск.
    presentation.save("ImageAsBackground.pptx", slides.export.SaveFormat.PPTX)
```


Следующий фрагмент кода показывает, как установить тип заполнения фона в режим «мозаика» изображения и изменить свойства мозаики:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # Установите изображение, используемое для заполнения фона.
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # Установите режим заполнения изображения в режим Tile и настройте свойства плитки.
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
Читайте далее: [**Tile Picture As Texture**](/slides/ru/python-net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Изменить прозрачность фонового изображения**

Возможно, вам понадобится отрегулировать прозрачность фонового изображения слайда, чтобы выделить содержимое слайда. Следующий код на Python показывает, как изменить прозрачность фонового изображения слайда:
```python
transparency_value = 30  # Например.

# Получить коллекцию операций трансформации изображения.
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# Найти существующий эффект прозрачности с фиксированным процентом.
for operation in image_transform:
    if type(operation) is slides.AlphaModulateFixed:
        transparency_operation = operation
        break

# Установить новое значение прозрачности.
if transparency_operation is None:
    image_transform.add_alpha_modulate_fixed_effect(100 - transparency_value)
else:
    transparency_operation.amount = 100 - transparency_value
```


## **Получить значение фона слайда**

Aspose.Slides предоставляет класс [IBackgroundEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/) для получения эффективных значений фона слайда. Этот класс раскрывает эффективные [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) и [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/).

Используя свойство `background` класса [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/), вы можете получить эффективный фон слайда.

Следующий пример на Python показывает, как получить эффективное значение фона слайда:
```python
import aspose.slides as slides

# Создайте экземпляр класса Presentation.
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Получите эффективный фон с учётом мастер‑слайда, макета и темы.
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```


## **FAQ**

**Можно ли сбросить пользовательский фон и восстановить фон темы/макета?**

Да. Удалите пользовательское заполнение слайда, и фон будет снова наследоваться от соответствующего слайда [layout](/slides/ru/python-net/slide-layout/)/[master](/slides/ru/python-net/slide-master/) (то есть от [theme background](/slides/ru/python-net/presentation-theme/)).

**Что произойдёт с фоном, если позже изменить тему презентации?**

Если у слайда есть собственное заполнение, оно останется без изменений. Если фон наследуется от [layout](/slides/ru/python-net/slide-layout/)/[master](/slides/ru/python-net/slide-master/), он обновится в соответствии с [новой темой](/slides/ru/python-net/presentation-theme/).