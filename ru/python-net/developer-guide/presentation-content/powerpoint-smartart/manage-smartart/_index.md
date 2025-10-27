---
title: Manage SmartArt in PowerPoint Presentations Using Python
linktitle: Manage SmartArt
type: docs
weight: 10
url: /ru/python-net/manage-smartart/
keywords:
- SmartArt
- text from SmartArt
- layout type
- hidden property
- organization chart
- picture organization chart
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Learn to build and edit PowerPoint SmartArt with Aspose.Slides for Python via .NET using clear code samples that speed up slide design and automation."
---

## **Обзор**

Это руководство демонстрирует, как создавать и управлять SmartArt в Aspose.Slides for Python. Вы узнаете, как извлекать текст из SmartArt (включая содержимое [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) внутри форм узлов), добавлять SmartArt на слайды и менять его макет, определять и обрабатывать скрытые узлы, настраивать макеты организационных схем и создавать организационные схемы с изображениями — всё это с помощью лаконичных, готовых к копированию примеров на Python, которые открывают [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), работают со слайдами и узлами SmartArt и сохраняют результат в PPTX. 

## **Получить текст из SmartArt**

Свойство `text_frame` объекта [SmartArtShape](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/) позволяет получить весь текст из формы SmartArt — не только текст, содержащийся в её узлах. Ниже приведён пример кода, показывающий, как получить текст из узла SmartArt.

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
1. Получите ссылку на слайд по его индексу.
1. Добавьте форму SmartArt с макетом `BASIC_BLOCK_LIST`.
1. Измените её макет на `BASIC_PROCESS`.
1. Сохраните презентацию в файл PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add a SmartArt shape with the BASIC_BLOCK_LIST layout.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    # Change the layout type to BASIC_PROCESS.
    smart.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    # Save the presentation.
    presentation.save("ChangedSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Проверить скрытое свойство SmartArt**

Свойство `SmartArtNode.is_hidden` возвращает `True`, если узел скрыт в модели данных. Чтобы проверить, скрыт ли узел SmartArt, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Добавьте форму SmartArt с макетом `RADIAL_CYCLE`.
1. Добавьте узел к SmartArt.
1. Проверьте свойство `is_hidden`.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add a SmartArt shape with the RADIAL_CYCLE layout.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    # Add a node to the SmartArt.
    node = smart.all_nodes.add_node()

    # Check the is_hidden property.
    if node.is_hidden:
        print("The node is hidden.")
```

## **Получить или установить тип организационной схемы**

Свойство `SmartArtNode.organization_chart_layout` получает или задаёт тип организационной схемы, связанный с текущим узлом. Чтобы получить или установить тип схемы, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Добавьте форму SmartArt на слайд.
1. Получите или задайте тип организационной схемы.
1. Сохраните презентацию в файл PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add a SmartArt shape with the ORGANIZATION_CHART layout.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    # Set the organization chart type.
    smart.nodes[0].organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    # Save the presentation.
    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Создать организационную схему с изображениями**

Aspose.Slides for Python предоставляет простой API для лёгкого создания схем с изображениями. Чтобы создать схему на слайде:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте схему с данными по умолчанию нужного типа.
1. Сохраните изменённую презентацию в файл PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)
    
    presentation.save("OrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Часто задаваемые вопросы**

**Поддерживает ли SmartArt зеркальное отображение/инверсию для RTL‑языков?**

Да. Свойство [is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) переключает направление диаграммы (LTR/RTL), если выбранный тип SmartArt поддерживает инверсию.

**Как скопировать SmartArt на тот же слайд или в другую презентацию, сохранив форматирование?**

Можно [клонировать форму SmartArt](/slides/ru/python-net/shape-manipulations/) через коллекцию форм ([ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/)) или [клонировать весь слайд](/slides/ru/python-net/clone-slides/), содержащий эту форму. Оба подхода сохраняют размер, позицию и стили.

**Как отобразить SmartArt в растровом изображении для предварительного просмотра или экспорта в веб?**

[Отрендерите слайд](/slides/ru/python-net/convert-powerpoint-to-png/) (или всю презентацию) в PNG/JPEG через API, преобразующее слайды/презентации в изображения — SmartArt будет нарисован как часть слайда.

**Как программно выбрать конкретный SmartArt на слайде, если их несколько?**

Обычное решение — использовать [альтернативный текст](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/alternative_text/) (Alt Text) или [имя](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/name/) и искать форму по этому атрибуту в [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/), затем проверять тип, чтобы убедиться, что это [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/). Документация описывает типовые техники нахождения и работы с формами.