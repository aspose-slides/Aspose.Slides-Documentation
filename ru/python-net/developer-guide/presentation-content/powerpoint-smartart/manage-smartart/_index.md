---
title: Управление SmartArt в презентациях PowerPoint с помощью Python
linktitle: Управление SmartArt
type: docs
weight: 10
url: /ru/python-net/developer-guide/presentation-content/powerpoint-smartart/manage-smartart/
keywords:
- SmartArt
- текст из SmartArt
- тип макета
- скрытое свойство
- организационная диаграмма
- картинная организационная диаграмма
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как создавать и редактировать SmartArt в PowerPoint с помощью Aspose.Slides для Python через .NET, используя понятные примеры кода, ускоряющие разработку слайдов и автоматизацию."
---

## **Обзор**

Это руководство демонстрирует, как создавать и управлять SmartArt в Aspose.Slides для Python. Вы узнаете, как извлекать текст из SmartArt (включая содержимое [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) внутри фигур‑узлов), добавлять SmartArt на слайды и менять его макет, определять и обрабатывать скрытые узлы, настраивать макеты организационных диаграмм и создавать картинные организационные диаграммы — всё это с помощью кратких, готовых к копированию примеров на Python, которые открывают [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), работают со слайдами и узлами SmartArt и сохраняют результаты в PPTX.

## **Получить текст из SmartArt**

Свойство `text_frame` класса [SmartArtShape](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/) позволяет получить весь текст из фигуры SmartArt — не только текст, содержащийся в её узлах. Ниже приведён пример кода, показывающий, как получить текст из узла SmartArt.

```py
import aspose.slides as slides

with slides.Presentation("SmartArt.pptx") as presentation:
    slide = presentation.slides[0]
    smart_art = slide.shapes[0]

    for smart_art_node in smart_art.all_nodes:
        for node_shape in smart_art_node.shapes:
            if node_shape.text_frame is not None:
                print(node_shape.text_frame.text)
```

## **Изменить тип макета SmartArt**

Чтобы изменить тип макета SmartArt, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте фигуру SmartArt с макетом `BASIC_BLOCK_LIST`.
4. Измените её макет на `BASIC_PROCESS`.
5. Сохраните презентацию в файл PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Добавляем фигуру SmartArt с макетом BASIC_BLOCK_LIST.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    # Меняем тип макета на BASIC_PROCESS.
    smart.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    # Сохраняем презентацию.
    presentation.save("ChangedSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Проверить скрытое свойство SmartArt**

Свойство `SmartArtNode.is_hidden` возвращает `True`, если узел скрыт в модели данных. Чтобы проверить, скрыт ли узел SmartArt, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Добавьте фигуру SmartArt с макетом `RADIAL_CYCLE`.
3. Добавьте узел в SmartArt.
4. Проверьте свойство `is_hidden`.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Добавляем фигуру SmartArt с макетом RADIAL_CYCLE.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    # Добавляем узел в SmartArt.
    node = smart.all_nodes.add_node()

    # Проверяем свойство is_hidden.
    if node.is_hidden:
        print("The node is hidden.")
```

## **Получить или установить тип организационной диаграммы**

Свойство `SmartArtNode.organization_chart_layout` получает или задает тип организационной диаграммы, связанный с текущим узлом. Чтобы получить или установить этот тип, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Добавьте фигуру SmartArt на слайд.
3. Получите или задайте тип организационной диаграммы.
4. Сохраните презентацию в файл PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Добавляем фигуру SmartArt с макетом ORGANIZATION_CHART.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    # Задаём тип организационной диаграммы.
    smart.nodes[0].organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    # Сохраняем презентацию.
    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Создать картинную организационную диаграмму**

Aspose.Slides для Python предоставляет простой API для лёгкого создания картинных организационных диаграмм. Чтобы создать диаграмму на слайде:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте диаграмму с данными по умолчанию нужного типа.
4. Сохраните изменённую презентацию в файл PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)
    
    presentation.save("OrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Часто задаваемые вопросы**

**Поддерживает ли SmartArt зеркальное отражение/реверсирование для RTL-языков?**

Да. Свойство [is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) переключает направление диаграммы (LTR/RTL), если выбранный тип SmartArt поддерживает реверсирование.

**Как скопировать SmartArt на тот же слайд или в другую презентацию, сохранив форматирование?**

Можно [клонировать фигуру SmartArt](/slides/ru/python-net/shape-manipulations/) через коллекцию фигур ([ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/)) или [клонировать весь слайд](/slides/ru/python-net/clone-slides/), содержащий эту фигуру. Оба подхода сохраняют размер, позицию и стили.

**Как отрисовать SmartArt в растровое изображение для предпросмотра или веб-экспорта?**

[Отрендерите слайд](/slides/ru/python-net/convert-powerpoint-to-png/) (или всю презентацию) в PNG/JPEG с помощью API, который преобразует слайды/презентации в изображения — SmartArt будет изображён как часть слайда.

**Как программно выбрать конкретный SmartArt на слайде, если их несколько?**

Обычная практика — использовать [альтернативный текст](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/alternative_text/) (Alt Text) или [имя](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/name/) и искать фигуру по этому атрибуту в [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/), затем проверять тип, чтобы убедиться, что это [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/). Документация описывает типичные приёмы поиска и работы с фигурами.