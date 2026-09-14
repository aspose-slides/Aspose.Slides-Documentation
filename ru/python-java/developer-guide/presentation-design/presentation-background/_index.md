---
title: Управление фонами презентаций в Python через Java
linktitle: Фон слайда
type: docs
weight: 20
url: /ru/python-java/presentation-background/
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
- Java
- Aspose.Slides
description: "Узнайте, как задавать динамические фоны в файлах PowerPoint и OpenDocument с помощью Aspose.Slides для Python через Java, с советами по коду для улучшения ваших презентаций."
---
## **Введение**

Сплошные цвета, градиенты и изображения часто используются в качестве фона слайдов. Вы можете задать фон для **обычного слайда** (одного слайда) или **главного слайда** (применяется к нескольким слайдам одновременно).

![Фон PowerPoint](powerpoint-background.png)

## **Задать сплошной цвет фона для обычного слайда**

Aspose.Slides позволяет задать сплошной цвет в качестве фона для конкретного слайда презентации — даже если презентация использует главный слайд. Изменение применяется только к выбранному слайду.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Установите у слайда свойство [BackgroundType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/backgroundtype/) в значение `OwnBackground`.
3. Установите у фона слайда свойство [FillType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/filltype/) в значение `Solid`.
4. Вызовите метод [getSolidFillColor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fillformat/#getsolidfillcolor) у [FillFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fillformat/) для указания сплошного цвета фона.
5. Сохраните изменённую презентацию.

Ниже приведён пример на Python, показывающий, как задать синий сплошной цвет в качестве фона обычного слайда:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# Создать экземпляр класса Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Установить цвет фона слайда в синий.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Сохранить презентацию на диск.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Задать сплошной цвет фона для главного слайда**

Aspose.Slides позволяет задать сплошной цвет в качестве фона главного слайда презентации. Главный слайд выступает шаблоном, который управляет форматированием всех слайдов, поэтому при выборе сплошного цвета фона главного слайда он применяется ко всем слайдам.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Установите у главного слайда свойство [BackgroundType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/backgroundtype/) (через [getMasters](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getmasters)) в значение `OwnBackground`.
3. Установите у фона главного слайда свойство [FillType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/filltype/) в значение `Solid`.
4. Вызовите метод [getSolidFillColor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fillformat/#getsolidfillcolor) для указания сплошного цвета фона.
5. Сохраните изменённую презентацию.

Ниже приведён пример на Python, показывающий, как задать сплошной зелёный цвет в качестве фона главного слайда:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# Создать экземпляр класса Presentation.
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # Установить цвет фона мастер‑слайда в зеленый.
    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # Сохранить презентацию на диск.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Задать градиентный фон для слайда**

Градиент — это графический эффект, создаваемый плавным переходом цвета. При использовании в качестве фона слайда градиенты могут сделать презентацию более художественной и профессиональной. Aspose.Slides позволяет задать градиентный цвет в качестве фона слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Установите у слайда свойство [BackgroundType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/backgroundtype/) в значение `OwnBackground`.
3. Установите у фона слайда свойство [FillType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/filltype/) в значение `Gradient`.
4. Вызовите метод [getGradientFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fillformat/#getgradientformat) у [FillFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fillformat/) для настройки желаемых параметров градиента.
5. Сохраните изменённую презентацию.

Ниже приведён пример на Python, показывающий, как задать градиентный цвет в качестве фона слайда:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, TileFlip
from java.awt import Color

# Создать экземпляр класса Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Применить градиентный эффект к фону.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient)

    gradient_format = slide.getBackground().getFillFormat().getGradientFormat()
    gradient_format.setTileFlip(TileFlip.FlipBoth)

    # Добавить цвета градиента. Без остановок градиента фон будет использовать стандартный переход от черного к белому.
    gradient_format.getGradientStops().add(0.0, Color.CYAN)
    gradient_format.getGradientStops().add(1.0, Color.BLUE)

    # Сохранить презентацию на диск.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Задать изображение в качестве фона слайда**

Помимо сплошных и градиентных заливок, Aspose.Slides позволяет использовать изображения в качестве фона слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Установите у слайда свойство [BackgroundType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/backgroundtype/) в значение `OwnBackground`.
3. Установите у фона слайда свойство [FillType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/filltype/) в значение `Picture`.
4. Загрузите изображение, которое хотите использовать в качестве фона слайда.
5. Добавьте изображение в коллекцию изображений презентации.
6. Вызовите метод [getPictureFillFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fillformat/#getpicturefillformat) у [FillFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fillformat/) для назначения изображения в качестве фона.
7. Сохраните изменённую презентацию.

Ниже приведён пример на Python, показывающий, как задать изображение в качестве фона слайда:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, SaveFormat

# Создать экземпляр класса Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Установить свойства фонового изображения.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Picture)
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    # Загрузить изображение.
    image = Images.fromFile("Tulips.jpg")
    # Добавить изображение в коллекцию изображений презентации.
    presentation_image = presentation.getImages().addImage(image)
    image.dispose()

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    # Сохранить презентацию на диск.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ниже приведён пример кода, показывающий, как установить тип заливки фона в растровое изображение с повторением и изменить свойства повторения:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, TileFlip

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    background = first_slide.getBackground()

    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Picture)

    new_image = Images.fromFile("image.png")
    presentation_image = presentation.getImages().addImage(new_image)
    new_image.dispose()

    # Установить изображение, используемое для заполнения фона.
    background_picture_fill_format = background.getFillFormat().getPictureFillFormat()
    background_picture_fill_format.getPicture().setImage(presentation_image)

    # Установить режим заполнения изображения в режим плитки и настроить свойства плитки.
    background_picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    background_picture_fill_format.setTileOffsetX(15.0)
    background_picture_fill_format.setTileOffsetY(15.0)
    background_picture_fill_format.setTileScaleX(46.0)
    background_picture_fill_format.setTileScaleY(87.0)
    background_picture_fill_format.setTileAlignment(RectangleAlignment.Center)
    background_picture_fill_format.setTileFlip(TileFlip.FlipY)

    presentation.save("TileBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Read more: [Tile Picture as Texture](/slides/ru/python-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Изменить прозрачность фонового изображения**

Возможно, вам потребуется отрегулировать прозрачность фонового изображения слайда, чтобы содержимое слайда лучше выделялось. Ниже приведён код на Python, показывающий, как изменить прозрачность фонового изображения слайда:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Presentation, SaveFormat

transparency_value = 30  # Например.

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Получить коллекцию операций преобразования картинки.
    image_transform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform()

    # Найти существующий эффект фиксированной процентной прозрачности.
    transparency_operation = None
    for operation in image_transform:
        if isinstance(operation, AlphaModulateFixed):
            transparency_operation = operation
            break

    # Установить новое значение прозрачности.
    if transparency_operation is None:
        image_transform.addAlphaModulateFixedEffect(100 - transparency_value)
    else:
        transparency_operation.setAmount(100 - transparency_value)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Получить значение фона слайда**

Aspose.Slides позволяет получить эффективные значения фона слайда с помощью метода [getEffective](https://reference.aspose.com/slides/ru/python-java/aspose.slides/background/#geteffective) у [Background](https://reference.aspose.com/slides/ru/python-java/aspose.slides/background/). Возвращаемые данные содержат эффективные форматы заливки и эффектов.

С помощью метода [getBackground](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseslide/#getbackground) класса [BaseSlide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseslide/) можно получить фон слайда.

Ниже приведён пример на Python, показывающий, как получить эффективное значение фона слайда:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

# Создать экземпляр класса Presentation.
presentation = Presentation("Sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Получить эффективный фон, учитывая мастер-слайд, макет и тему.
    effective_background = slide.getBackground().getEffective()

    if effective_background.getFillFormat().getFillType() == FillType.Solid:
        print("Fill color:", effective_background.getFillFormat().getSolidFillColor())
    else:
        print("Fill type:", effective_background.getFillFormat().getFillType())
finally:
    presentation.dispose()
```

## **FAQ**

**Можно ли сбросить пользовательский фон и вернуть фон темы/макета?**

Да. Удалите пользовательскую заливку слайда, и фон вновь будет наследоваться от соответствующего [layout](/slides/ru/python-java/slide-layout/)/[master](/slides/ru/python-java/slide-master/) слайда (т. е. от [theme background](/slides/ru/python-java/presentation-theme/)).

**Что произойдёт с фоном, если позже изменить тему презентации?**

Если у слайда есть собственная заливка, она останется без изменений. Если фон наследуется от [layout](/slides/ru/python-java/slide-layout/)/[master](/slides/ru/python-java/slide-master/), он обновится в соответствии с новой темой.