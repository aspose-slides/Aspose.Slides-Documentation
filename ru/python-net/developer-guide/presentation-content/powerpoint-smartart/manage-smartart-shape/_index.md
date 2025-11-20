---
title: Управление графикой SmartArt в презентациях с помощью Python
linktitle: Графика SmartArt
type: docs
weight: 20
url: /ru/python-net/manage-smartart-shape/
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
description: "Автоматизируйте создание, редактирование и стильизацию SmartArt в PowerPoint на Python через .NET с использованием Aspose.Slides, предоставляя лаконичные примеры кода и ориентированные на производительность рекомендации."
---

## **Создание фигур SmartArt**

Aspose.Slides for Python via .NET позволяет добавлять пользовательские фигуры SmartArt на слайды с нуля. API упрощает это. Чтобы добавить фигуру SmartArt на слайд:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
1. Получите целевой слайд по его индексу.
1. Добавьте фигуру SmartArt, указав тип её макета.
1. Сохраните изменённую презентацию в файл PPTX.
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Создать экземпляр класса Presentation.
with slides.Presentation() as presentation:
    # Получить слайд презентации.
    slide = presentation.slides[0]
    # Добавить фигуру SmartArt.
    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    # Сохранить презентацию на диск.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Доступ к фигурам SmartArt на слайдах**

Следующий код демонстрирует, как получить доступ к фигурам SmartArt на слайде. Пример перебирает каждую фигуру на слайде и проверяет, является ли она объектом [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/).
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Загрузить файл презентации.
with slides.Presentation("SmartArt.pptx") as presentation:
    # Перебрать каждую фигуру на первом слайде.
    for shape in presentation.slides[0].shapes:
        # Проверить, является ли фигура SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Вывести имя фигуры.
            print("Shape name:", shape.name)
```


## **Доступ к фигурам SmartArt с указанным типом макета**

Следующий пример показывает, как получить доступ к фигуре SmartArt с указанным типом макета. Обратите внимание, что тип макета SmartArt изменить нельзя — он доступен только для чтения и задаётся при создании фигуры.

1. Создайте экземпляр [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и загрузите презентацию, содержащую фигуру SmartArt.
1. Получите ссылку на первый слайд по индексу.
1. Переберите все фигуры на первом слайде.
1. Проверьте, является ли фигура объектом [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/).
1. Если тип макета фигуры SmartArt соответствует нужному, выполните требуемые действия.
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Перебрать каждую фигуру на первом слайде.
    for shape in presentation.slides[0].shapes:
        # Проверить, является ли фигура SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Проверить тип макета SmartArt.
            if shape.layout == smartart.SmartArtLayoutType.BASIC_BLOCK_LIST:
                print("Do something here...")
```


## **Изменение стиля фигуры SmartArt**

Следующий пример показывает, как найти фигуры SmartArt и изменить их стиль:

1. Создайте [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и загрузите файл, содержащий фигуру(и) SmartArt.
1. Получите ссылку на первый слайд по индексу.
1. Переберите каждую фигуру на первом слайде.
1. Найдите фигуру SmartArt с указанным стилем.
1. Назначьте новый стиль фигуре SmartArt.
1. Сохраните презентацию.
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Перебрать каждую фигуру на первом слайде.
    for shape in presentation.slides[0].shapes:
        # Проверить, является ли фигура SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Проверить стиль SmartArt.
            if shape.quick_style == smartart.SmartArtQuickStyleType.SIMPLE_FILL:
                # Изменить стиль SmartArt.
                smart.quick_style = smartart.SmartArtQuickStyleType.CARTOON
    # Сохранить презентацию.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Изменение цветового стиля фигур SmartArt**

Этот пример показывает, как изменить цветовой стиль фигуры SmartArt. Пример кода находит фигуру SmartArt с указанным цветовым стилем и обновляет её.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и загрузите презентацию, содержащую фигуру(и) SmartArt.
1. Получите ссылку на первый слайд по индексу.
1. Переберите каждую фигуру на первом слайде.
1. Проверьте, является ли фигура объектом [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/).
1. Найдите фигуру SmartArt с указанным цветовым стилем.
1. Установите новый цветовой стиль для этой фигуры SmartArt.
1. Сохраните презентацию.
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Перебрать каждую фигуру на первом слайде.
    for shape in presentation.slides[0].shapes:
        # Проверить, является ли фигура SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Проверить тип цвета.
            if shape.color_style == smartart.SmartArtColorType.COLORED_FILL_ACCENT1:
                # Изменить тип цвета.
                shape.color_style = smartart.SmartArtColorType.COLORFUL_ACCENT_COLORS
    # Сохранить презентацию.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Часто задаваемые вопросы**

**Могу ли я анимировать SmartArt как единый объект?**

Да. SmartArt является фигурой, поэтому вы можете применять [стандартные анимации](/slides/ru/python-net/powerpoint-animation/) через API анимаций (вход, выход, акцент, траектории движения) так же, как и к другим фигурам.

**Как найти конкретный SmartArt на слайде, если я не знаю его внутренний ID?**

Установите и используйте альтернативный текст (AltText) и ищите фигуру по этому значению — это рекомендованный способ найти нужную фигуру.

**Могу ли я группировать SmartArt с другими фигурами?**

Да. Вы можете группировать SmartArt с другими фигурами (изображения, таблицы и т.д.) и затем [управлять группой](/slides/ru/python-net/group/).

**Как получить изображение конкретного SmartArt (например, для превью или отчёта)?**

Экспортируйте миниатюру/изображение фигуры; библиотека может [рисовать отдельные фигуры](/slides/ru/python-net/create-shape-thumbnails/) в растровые файлы (PNG/JPG/TIFF).

**Сохранится ли внешний вид SmartArt при конвертации всей презентации в PDF?**

Да. Рендеринг‑движок обеспечивает высокую точность при [экспорте в PDF](/slides/ru/python-net/convert-powerpoint-to-pdf/), с набором опций качества и совместимости.