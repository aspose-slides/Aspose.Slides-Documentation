---
title: Управление фоновыми изображениями презентации в Python
linktitle: Фоновый слайд
type: docs
weight: 20
url: /ru/python-net/presentation-background/
keywords:
- фон презентации
- фон слайда
- сплошной цвет
- градиентный цвет
- фоновое изображение
- прозрачность фона
- свойства фона
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как задавать динамические фоны в файлах PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET, с советами по коду для улучшения ваших презентаций."
---

## **Обзор**

Сплошные цвета, градиенты и изображения часто используются в качестве фонов слайдов. Вы можете задать фон для **обычного слайда** (один слайд) или **главного слайда** (применяется сразу к нескольким слайдам).

![PowerPoint background](powerpoint-background.png)

## **Задать сплошной цвет фона для обычного слайда**

Aspose.Slides позволяет задать сплошной цвет фона для конкретного слайда в презентации — даже если презентация использует главный слайд. Изменение применяется только к выбранному слайду.

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Установить свойство слайда [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) в `OWN_BACKGROUND`.
3. Установить свойство фона слайда [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) в `SOLID`.
4. Использовать свойство `solid_fill_color` класса [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) для указания сплошного цвета фона.
5. Сохранить изменённую презентацию.

Следующий пример на Python показывает, как задать синий сплошной цвет в качестве фона обычного слайда:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Создать экземпляр класса Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Установить цвет фона слайда в синий.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # Сохранить презентацию на диск.
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Задать сплошной цвет фона для главного слайда**

Aspose.Slides позволяет задать сплошной цвет фона главного слайда в презентации. Главный слайд выступает шаблоном, управляющим форматированием всех слайдов, поэтому выбранный сплошной цвет будет применён ко всем слайдам.

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Установить свойство главного слайда [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) (через `masters`) в `OWN_BACKGROUND`.
3. Установить свойство фона главного слайда [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) в `SOLID`.
4. Использовать свойство `solid_fill_color` класса [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) для указания сплошного цвета фона.
5. Сохранить изменённую презентацию.

Следующий пример на Python показывает, как задать сплошной цвет (лесной зелёный) в качестве фона главного слайда:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Создать экземпляр класса Presentation.
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # Установить цвет фона главного слайда в лесной зелёный.
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # Сохранить презентацию на диск.
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Задать градиентный фон для слайда**

Градиент — это графический эффект, создаваемый плавным переходом цвета. При использовании в качестве фона слайда градиенты делают презентацию более художественной и профессиональной. Aspose.Slides позволяет задать градиентный цвет в качестве фона слайдов.

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Установить свойство слайда [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) в `OWN_BACKGROUND`.
3. Установить свойство фона слайда [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) в `GRADIENT`.
4. Использовать свойство `gradient_format` класса [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) для настройки нужных параметров градиента.
5. Сохранить изменённую презентацию.

Следующий пример на Python показывает, как задать градиентный цвет в качестве фона слайда:

```python
import aspose.slides as slides

# Создать экземпляр класса Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Применить градиентный эффект к фону.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Сохранить презентацию на диск.
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Задать изображение в качестве фона слайда**

Помимо сплошных и градиентных заливок, Aspose.Slides позволяет использовать изображения в качестве фона слайдов.

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Установить свойство слайда [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) в `OWN_BACKGROUND`.
3. Установить свойство фона слайда [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) в `PICTURE`.
4. Загрузить изображение, которое будет использоваться в качестве фона слайда.
5. Добавить изображение в коллекцию изображений презентации.
6. Использовать свойство `picture_fill_format` класса [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) для назначения изображения в качестве фона.
7. Сохранить изменённую презентацию.

Следующий пример на Python показывает, как задать изображение в качестве фона слайда:

```python
import aspose.slides as slides

# Создать экземпляр класса Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Установить свойства фонового изображения.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Загрузить изображение.
    with slides.Images.from_file("Tulips.jpg") as image:
        # Добавить изображение в коллекцию изображений презентации.
        pp_image = presentation.images.add_image(image)

    slide.background.fill_format.picture_fill_format.picture.image = pp_image

    # Сохранить презентацию на диск.
    presentation.save("ImageAsBackground.pptx", slides.export.SaveFormat.PPTX)
```

Следующий пример кода показывает, как задать тип заливки фона в виде мозаичного изображения и изменить свойства мозаики:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # Установить изображение, используемое для заливки фона.
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # Установить режим заливки изображения в Tile и скорректировать свойства мозаики.
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
Подробнее: [**Картинка как текстура**](/slides/ru/python-net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Изменить прозрачность фонового изображения**

Возможно, потребуется отрегулировать прозрачность фонового изображения слайда, чтобы выделить его содержимое. Ниже приведён код Python, показывающий, как изменить прозрачность фонового изображения слайда:

```python
transparency_value = 30  # Например.

# Получить коллекцию операций трансформации изображения.
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# Найти существующий эффект фиксированной процентной прозрачности.
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

## **Получить значение фоновых настроек слайда**

Aspose.Slides предоставляет класс [IBackgroundEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/) для получения эффективных значений фона слайда. Этот класс раскрывает эффективный [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) и [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/).

Используя свойство `background` класса [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/), можно получить эффективный фон слайда.

Следующий пример на Python показывает, как получить эффективное значение фона слайда:

```python
import aspose.slides as slides

# Создать экземпляр класса Presentation.
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Получить эффективный фон с учётом мастер‑слайда, макета и темы.
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```

## **FAQ**

**Можно ли сбросить пользовательский фон и восстановить фон темы/макета?**

Да. Удалите пользовательскую заливку слайда, и фон будет снова наследоваться от соответствующего [layout](/slides/ru/python-net/slide-layout/)/[master](/slides/ru/python-net/slide-master/) слайда (т.е. от [theme background](/slides/ru/python-net/presentation-theme/)).

**Что происходит с фоном, если позже изменить тему презентации?**

Если у слайда есть собственная заливка, она останется без изменений. Если фон наследуется от [layout](/slides/ru/python-net/slide-layout/)/[master](/slides/ru/python-net/slide-master/), он обновится в соответствии с новой темой.