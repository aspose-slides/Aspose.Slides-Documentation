---
title: Управление графикой SmartArt в презентациях с помощью Python
linktitle: Графика SmartArt
type: docs
weight: 20
url: /ru/python-java/manage-smartart-shape/
keywords:
- объект SmartArt
- графика SmartArt
- стиль SmartArt
- цвет SmartArt
- создание SmartArt
- добавление SmartArt
- редактирование SmartArt
- изменение SmartArt
- доступ к SmartArt
- тип макета SmartArt
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Автоматизируйте создание, редактирование и стилизацию SmartArt в PowerPoint на Python с помощью Aspose.Slides, предоставляя лаконичные примеры кода и рекомендации, ориентированные на производительность."
---
## **Обзор**

Aspose.Slides позволяет создавать и управлять графикой SmartArt в презентациях PowerPoint программно. В этой статье объясняется, как добавить форму SmartArt на слайд, получить доступ к существующим формам SmartArt, найти SmartArt по определённому типу макета и обновить её визуальное оформление, изменив стиль SmartArt или стиль цветов.

Примеры показывают, как работать с формами SmartArt через коллекцию форм слайда презентации, проверять, является ли форма SmartArt, а затем изменять или проверять её свойства.

## **Создать форму SmartArt**
Aspose.Slides for Python via Java предоставляет API для создания форм SmartArt. Чтобы создать форму SmartArt на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Получите слайд по его индексу.
1. [Добавить форму SmartArt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#addSmartArt) с указанием [SmartArtLayoutType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartartlayouttype/).
1. Сохраните изменённую презентацию в файл PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    # Получить первый слайд.
    slide = presentation.getSlides().get_Item(0)

    # Добавить форму SmartArt.
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList)

    # Сохранить презентацию.
    presentation.save("SimpleSmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Рисунок: форма SmartArt, добавленная на слайд**|

## **Доступ к форме SmartArt на слайде**
Следующий пример получает доступ к формам SmartArt на слайде презентации. Он перебирает каждую форму на слайде и проверяет, является ли форма экземпляром [SmartArt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartart/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # Пройти каждую форму на первом слайде.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            print("Shape Name: " + str(smart_art.getName()))
finally:
    presentation.dispose()
```

## **Доступ к форме SmartArt с определённым типом макета**
Следующий пример получает доступ к форме [SmartArt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartart/) с определённым типом макета, возвращаемым методом [SmartArt.getLayout](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartart/#getLayout).

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и загрузите презентацию, содержащую форму SmartArt.
1. Получите первый слайд по его индексу.
1. Переберите каждую форму на первом слайде.
1. Проверьте, является ли форма экземпляром [SmartArt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartart/).
1. Проверьте, имеет ли форма SmartArt указанный тип макета, и выполните требуемую операцию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # Пройти каждую форму на первом слайде.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Проверить макет SmartArt.
            if smart_art.getLayout() == SmartArtLayoutType.BasicBlockList:
                print("Perform the required operation here.")
finally:
    presentation.dispose()
```

## **Изменить стиль формы SmartArt**
Этот пример показывает, как изменить быстрый стиль формы SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и загрузите презентацию, содержащую форму SmartArt.
1. Получите первый слайд по его индексу.
1. Переберите каждую форму на первом слайде.
1. Проверьте, является ли форма экземпляром [SmartArt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartart/).
1. Найдите форму SmartArt с указанным стилем.
1. Установите новый стиль для формы SmartArt.
1. Сохраните презентацию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtQuickStyleType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Пройти каждую форму на первом слайде.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Проверить и изменить стиль SmartArt.
            if smart_art.getQuickStyle() == SmartArtQuickStyleType.SimpleFill:
                smart_art.setQuickStyle(SmartArtQuickStyleType.Cartoon)

    presentation.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Рисунок: форма SmartArt со изменённым стилем**|

## **Изменить стиль цвета формы SmartArt**
Этот пример получает доступ к форме SmartArt с определённым стилем цвета и изменяет его.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и загрузите презентацию, содержащую форму SmartArt.
1. Получите первый слайд по его индексу.
1. Переберите каждую форму на первом слайде.
1. Проверьте, является ли форма экземпляром [SmartArt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartart/).
1. Найдите форму SmartArt с указанным стилем цвета.
1. Установите новый стиль цвета для формы SmartArt.
1. Сохраните презентацию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtColorType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Пройти каждую форму на первом слайде.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Проверить и изменить стиль SmartArt.
            if smart_art.getColorStyle() == SmartArtColorType.ColoredFillAccent1:
                smart_art.setColorStyle(SmartArtColorType.ColorfulAccentColors)

    presentation.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Рисунок: форма SmartArt со изменённым стилем цвета**|

## **Часто задаваемые вопросы**

**Могу ли я анимировать SmartArt как единый объект?**

Да. SmartArt является формой, поэтому вы можете применять [стандартные анимации](/slides/ru/python-java/powerpoint-animation/) через API анимаций (вход, выход, акцент, траектории движения) так же, как и к другим формам.

**Как найти конкретный SmartArt на слайде, если я не знаю его внутренний ID?**

Установите и используйте [альтернативный текст](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#setAlternativeText) и ищите форму по этому значению — это рекомендуемый способ найти нужную форму.

**Могу ли я сгруппировать SmartArt с другими формами?**

Да. Вы можете группировать SmartArt с другими формами (изображения, таблицы и т.д.) и затем [управлять группой](/slides/ru/python-java/group/).

**Как получить изображение конкретного SmartArt (например, для превью или отчёта)?**

Экспортируйте миниатюру/изображение формы; библиотека может [визуализировать отдельные формы](/slides/ru/python-java/create-shape-thumbnails/) в растровые файлы (PNG/JPG/TIFF).

**Сохранится ли внешний вид SmartArt при конвертации всей презентации в PDF?**

Да. Движок рендеринга нацелен на высокую точность при [экспорте в PDF](/slides/ru/python-java/convert-powerpoint-to-pdf/), предоставляя широкий набор параметров качества и совместимости.