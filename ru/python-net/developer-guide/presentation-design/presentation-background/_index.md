---
title: Фоновое изображение презентации
type: docs
weight: 20
url: /python-net/presentation-background/
keywords: "фон PowerPoint, установить фон, Python, Aspose.Slides для Python через .NET"
description: "Установить фон в презентации PowerPoint на Python"
---

Однотонные цвета, градиентные цвета и картинки часто используются в качестве фоновых изображений для слайдов. Вы можете установить фон либо для **обычного слайда** (один слайд), либо для **мастера слайда** (несколько слайдов сразу).

<img src="powerpoint-background.png" alt="powerpoint-background" />

## **Установить однотонный цвет в качестве фона для обычного слайда**

Aspose.Slides позволяет установить однотонный цвет в качестве фона для конкретного слайда в презентации (даже если эта презентация содержит мастер слайда). Изменение фона затрагивает только выбранный слайд.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Установите перечисление [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) для слайда на `OwnBackground`.
3. Установите перечисление [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) для фона слайда на `Solid`.
4. Используйте свойство [SolidFillColor](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/#properties), предоставляемое [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/), чтобы указать однотонный цвет для фона.
5. Сохраните изменённую презентацию.

Этот код на Python показывает, как установить однотонный цвет (синий) в качестве фона для обычного слайда:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Создаёт экземпляр класса Presentation
with slides.Presentation() as pres:
    # Устанавливает цвет фона для первого ISlide на Синий
    pres.slides[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.slides[0].background.fill_format.fill_type = slides.FillType.SOLID
    pres.slides[0].background.fill_format.solid_fill_color.color = draw.Color.blue
    # Записывает презентацию на диск
    pres.save("ContentBG_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить однотонный цвет в качестве фона для мастера слайда**

Aspose.Slides позволяет установить однотонный цвет в качестве фона для мастера слайда в презентации. Мастер слайда действует как шаблон, который содержит и контролирует настройки форматирования для всех слайдов. Поэтому, когда вы выбираете однотонный цвет в качестве фона для мастера слайда, этот новый фон будет использоваться для всех слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Установите перечисление [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) для мастера слайда (`Masters`) на `OwnBackground`.
3. Установите перечисление [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) для фона мастера слайда на `Solid`.
4. Используйте свойство [SolidFillColor](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/#properties), предоставляемое [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/), чтобы указать однотонный цвет для фона.
5. Сохраните изменённую презентацию.

Этот код на Python показывает, как установить однотонный цвет (лесной зелёный) в качестве фона для мастера слайда в презентации:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Создаёт экземпляр класса Presentation
with slides.Presentation() as pres:
    # Устанавливает цвет фона для мастер ISlide на Лесной Зелёный
    pres.masters[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.masters[0].background.fill_format.fill_type = slides.FillType.SOLID
    pres.masters[0].background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # Записывает презентацию на диск
    pres.save("SetSlideBackgroundMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить градиентный цвет в качестве фона для слайда**

Градиент — это графический эффект, основанный на постепенном изменении цвета. Градиентные цвета, когда они используются в качестве фонов для слайдов, придают презентациям художественный и профессиональный вид. Aspose.Slides позволяет установить градиентный цвет в качестве фона для слайдов в презентациях.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Установите перечисление [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) для слайда на `OwnBackground`.
3. Установите перечисление [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) для фона мастера слайда на `Gradient`.
4. Используйте свойство [GradientFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/#properties), предоставляемое [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/), чтобы указать ваши предпочтения по настройкам градиента.
5. Сохраните изменённую презентацию.

Этот код на Python показывает, как установить градиентный цвет в качестве фона для слайда:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Создаёт экземпляр класса Presentation
with slides.Presentation(path + "SetBackgroundToGradient.pptx") as pres:
    # Применяет эффект градиента к фону
    pres.slides[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.slides[0].background.fill_format.fill_type = slides.FillType.GRADIENT
    pres.slides[0].background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Записывает презентацию на диск
    pres.save("ContentBG_Grad_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить изображение в качестве фона для слайда**

Кроме однотонных и градиентных цветов, Aspose.Slides также позволяет установить изображения в качестве фона для слайдов в презентациях.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Установите перечисление [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) для слайда на `OwnBackground`.
3. Установите перечисление [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) для фона мастера слайда на `Picture`.
4. Загрузите изображение, которое вы хотите использовать в качестве фонового изображения для слайда.
5. Добавьте изображение в коллекцию изображений презентации.
6. Используйте свойство [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/#properties), предоставляемое [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/), чтобы установить изображение в качестве фона.
7. Сохраните изменённую презентацию.

Этот код на Python показывает, как установить изображение в качестве фона для слайда:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Создаёт экземпляр класса Presentation
with slides.Presentation(path + "SetImageAsBackground.pptx") as pres:
    # Устанавливает условия для фонового изображения
    pres.slides[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.slides[0].background.fill_format.fill_type = slides.FillType.PICTURE
    pres.slides[0].background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Загружает изображение
    img = draw.Bitmap(path + "Tulips.jpg")

    # Добавляет изображение в коллекцию изображений презентации
    imgx = pres.images.add_image(img)

    pres.slides[0].background.fill_format.picture_fill_format.picture.image = imgx

    # Записывает презентацию на диск
    pres.save("ContentBG_Img_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Изменить прозрачность фонового изображения**

Возможно, вы захотите отрегулировать прозрачность фонового изображения слайда, чтобы выделить содержимое слайда. Этот код на Python показывает, как изменить прозрачность фонового изображения слайда:

```python
transparencyValue = 30 # например

# Получает коллекцию операций преобразования изображения
imageTransform = pres.slides[0].background.fill_format.picture_fill_format.picture.image_transform

transparencyOperation = None
# Находит эффект прозрачности с фиксированным процентом.
for operation in imageTransform:
    if type(operation) is slides.AlphaModulateFixed:
        transparencyOperation = operation
        break

# Устанавливает новое значение прозрачности.
if transparencyOperation is None:
    imageTransform.add_alpha_modulate_fixed_effect(100 - transparencyValue)
else:
    transparencyOperation.amount = (100 - transparencyValue)
```

## **Получить значение фона слайда**

Aspose.Slides предоставляет интерфейс [IBackgroundEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/), который позволяет получать эффективные значения фонов слайдов. Этот интерфейс содержит информацию об эффективном [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/#properties) и эффективном [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/#properties).

Используя свойство [Background](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/#properties) из класса [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/), вы можете получить эффективное значение для фона слайда.

Этот код на Python показывает, как получить эффективное значение фона слайда:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Создаёт экземпляр класса Presentation
with slides.Presentation(path + "SamplePresentation.pptx") as pres:

    effBackground = pres.slides[0].background.get_effective()

    if effBackground.fill_format.fill_type == slides.FillType.SOLID:
        print("Цвет заливки: " + str(effBackground.fill_format.solid_fill_color))
    else:
        print("Тип заливки: " + str(effBackground.fill_format.fill_type))
```