---
title: Управление формой SmartArt
type: docs
weight: 20
url: /ru/python-net/manage-smartart-shape/
keywords: "форма SmartArt, стиль формы SmartArt, стиль цвета формы SmartArt, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Управление SmartArt в презентациях PowerPoint на Python"
---

## **Создание формы SmartArt**
Aspose.Slides для Python через .NET теперь позволяет добавлять собственные формы SmartArt в их слайды с нуля. Aspose.Slides для Python через .NET предоставляет самый простой API для создания форм SmartArt самым легким способом. Чтобы создать форму SmartArt на слайде, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Получите ссылку на слайд, используя его индекс.
- Добавьте форму SmartArt, задав ее LayoutType.
- Запишите измененную презентацию как файл PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# Инициализация презентации
with slides.Presentation() as pres:
    # Доступ к слайду презентации
    slide = pres.slides[0]

    # Добавить форму Smart Art
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.BASIC_BLOCK_LIST)

    # Сохранение презентации
    pres.save("SimpleSmartArt_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Доступ к форме SmartArt на слайде**
Следующий код будет использоваться для доступа к формам SmartArt, добавленным на слайд презентации. В образце кода мы пройдемся по каждой форме на слайде и проверим, является ли она формой SmartArt. Если форма является типом SmartArt, то мы приведем ее к экземпляру SmartArt.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# Загрузите желаемую презентацию
with slides.Presentation(path + "SmartArt.pptx") as pres:

    # Пройдите по каждой форме внутри первого слайда
    for shape in pres.slides[0].shapes:
        # Проверьте, является ли форма типом SmartArt
        if type(shape) is art.SmartArt:
            # Приведение формы к SmartArtEx
            print("Имя формы:" + shape.name)
```



## **Доступ к форме SmartArt с определенным типом макета**
Следующий образец кода поможет получить доступ к форме SmartArt с определенным LayoutType. Обратите внимание, что вы не можете изменить LayoutType формы SmartArt, так как он является доступом только для чтения и устанавливается только при добавлении формы SmartArt.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с формой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдите по каждой форме на первом слайде.
- Проверьте, является ли форма типом SmartArt и приведите выбранную форму к SmartArt, если это SmartArt.
- Проверьте форму SmartArt с определенным LayoutType и выполните требуемые действия впоследствии.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation(path + "SmartArt.pptx") as presentation:
    # Пройдите по каждой форме внутри первого слайда
    for shape in presentation.slides[0].shapes:
        # Проверьте, является ли форма типом SmartArt
        if type(shape) is art.SmartArt:
            # Проверка макета SmartArt
            if shape.layout == art.SmartArtLayoutType.BASIC_BLOCK_LIST:
                print("Здесь что-то сделайте....")
```



## **Изменение стиля формы SmartArt**
Следующий образец кода поможет получить доступ к форме SmartArt с определенным LayoutType.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с формой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдите по каждой форме на первом слайде.
- Проверьте, является ли форма типом SmartArt и приведите выбранную форму к SmartArt, если это SmartArt.
- Найдите форму SmartArt с определенным стилем.
- Установите новый стиль для формы SmartArt.
- Сохраните презентацию.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation(path + "SmartArt.pptx") as presentation:
    # Пройдите по каждой форме внутри первого слайда
    for shape in presentation.slides[0].shapes:
        # Проверьте, является ли форма типом SmartArt
        if type(shape) is art.SmartArt:
            # Проверка стиля SmartArt
            if shape.quick_style == art.SmartArtQuickStyleType.SIMPLE_FILL:
                # Изменение стиля SmartArt
                smart.quick_style = art.SmartArtQuickStyleType.CARTOON

    # Сохранение презентации
    presentation.save("ChangeSmartArtStyle_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Изменение цветового стиля формы SmartArt**
В этом примере мы научимся изменять цветовой стиль для любой формы SmartArt. В следующем образце кода доступ к форме SmartArt с определенным цветовым стилем и изменение его стиля.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с формой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдите по каждой форме на первом слайде.
- Проверьте, является ли форма типом SmartArt и приведите выбранную форму к SmartArt, если это SmartArt.
- Найдите форму SmartArt с определенным цветовым стилем.
- Установите новый цветовой стиль для формы SmartArt.
- Сохраните презентацию.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation(path + "SmartArt.pptx") as presentation:
    # Пройдите по каждой форме внутри первого слайда
    for shape in presentation.slides[0].shapes:
        # Проверьте, является ли форма типом SmartArt
        if type(shape) is art.SmartArt:
            # Проверка цветового типа SmartArt
            if shape.color_style == art.SmartArtColorType.COLORED_FILL_ACCENT1:
                # Изменение цветового типа SmartArt
                shape.color_style = art.SmartArtColorType.COLORFUL_ACCENT_COLORS

    # Сохранение презентации
    presentation.save("ChangeSmartArtColorStyle_out.pptx", slides.export.SaveFormat.PPTX)
```