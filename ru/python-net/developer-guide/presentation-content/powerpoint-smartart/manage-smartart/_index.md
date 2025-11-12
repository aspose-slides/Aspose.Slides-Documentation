---
title: Управление SmartArt в презентациях PowerPoint с помощью Python
linktitle: Управление SmartArt
type: docs
weight: 10
url: /ru/python-net/manage-smartart/
keywords:
- SmartArt
- текст из SmartArt
- тип макета
- свойство скрытого
- организационная схема
- схема организации с изображениями
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как создавать и редактировать SmartArt в PowerPoint с помощью Aspose.Slides для Python через .NET, используя понятные образцы кода, ускоряющие разработку слайдов и автоматизацию."
---

## **Обзор**

Это руководство показывает, как создавать и управлять SmartArt в Aspose.Slides для Python. Вы узнаете, как извлекать текст из SmartArt (включая содержимое [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) внутри форм узлов), добавлять SmartArt на слайды и менять его макет, определять и обрабатывать скрытые узлы, настраивать макеты организационных схем и создавать схемы организации с изображениями — все это с помощью лаконичных, готовых к копированию примеров на Python, которые открывают [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), работают со слайдами и узлами SmartArt и сохраняют результат в PPTX.

## **Получить текст из SmartArt**

Свойство `text_frame` [SmartArtShape](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/) позволяет получить весь текст из SmartArt‑формы — не только текст, содержащийся в её узлах. Следующий пример кода показывает, как получить текст из узла SmartArt.

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
3. Добавьте SmartArt‑форму с макетом `BASIC_BLOCK_LIST`.
4. Измените её макет на `BASIC_PROCESS`.
5. Сохраните презентацию в файл PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Добавить SmartArt-форму с макетом BASIC_BLOCK_LIST.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    # Изменить тип макета на BASIC_PROCESS.
    smart.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    # Сохранить презентацию.
    presentation.save("ChangedSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Проверить свойство скрытого узла SmartArt**

Свойство `SmartArtNode.is_hidden` возвращает `True`, если узел скрыт в модели данных. Чтобы проверить, скрыт ли узел SmartArt, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Добавьте SmartArt‑форму с макетом `RADIAL_CYCLE`.
3. Добавьте узел к SmartArt.
4. Проверить свойство `is_hidden`.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Добавить SmartArt-форму с макетом RADIAL_CYCLE.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    # Добавить узел к SmartArt.
    node = smart.all_nodes.add_node()

    # Проверить свойство is_hidden.
    if node.is_hidden:
        print("The node is hidden.")
```

## **Получить или установить тип организационной схемы**

Свойство `SmartArtNode.organization_chart_layout` получает или задает тип организационной схемы, связанный с текущим узлом. Чтобы получить или задать тип схемы, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Добавьте SmartArt‑форму на слайд.
3. Получите или задайте тип схемы.
4. Сохраните презентацию в файл PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Добавить SmartArt-форму с макетом ORGANIZATION_CHART.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    # Установить тип организационной схемы.
    smart.nodes[0].organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    # Сохранить презентацию.
    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Создать схему организации с изображениями**

Aspose.Slides для Python предоставляет простой API для лёгкого создания схем организации с изображениями. Чтобы создать схему на слайде:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте схему с данными по умолчанию нужного типа.
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

**Поддерживает ли SmartArt зеркальное отображение/реверсирование для RTL‑языков?**

Да. Свойство [is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) переключает направление диаграммы (LTR/RTL), если выбранный тип SmartArt поддерживает реверс.

**Как скопировать SmartArt на тот же слайд или в другую презентацию, сохранив форматирование?**

Можно [клонировать SmartArt‑форму](/slides/ru/python-net/shape-manipulations/) через коллекцию фигур ([ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/)) или [клонировать весь слайд](/slides/ru/python-net/clone-slides/), содержащий эту форму. Оба подхода сохраняют размер, позицию и стили.

**Как отрендерить SmartArt в растровое изображение для предварительного просмотра или веб‑экспорта?**

[Отрендерить слайд](/slides/ru/python-net/convert-powerpoint-to-png/) (или всю презентацию) в PNG/JPEG через API, конвертирующий слайды/презентации в изображения — SmartArt будет отрисован как часть слайда.

**Как программно выбрать конкретный SmartArt на слайде, если их несколько?**

Обычно используют [альтернативный текст](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/alternative_text/) (Alt Text) или [имя](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/name/) и ищут форму по этому атрибуту в коллекции [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/), затем проверяют тип, чтобы убедиться, что это [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/). Документация описывает типовые приёмы поиска и работы с формами.