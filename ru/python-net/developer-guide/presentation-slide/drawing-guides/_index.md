---
title: Управление руководящими линиями в презентациях на Python
linktitle: Руководящие линии
type: docs
weight: 85
url: /ru/python-net/drawing-guides/
keywords:
- руководящая линия
- горизонтальная линия
- вертикальная линия
- линия выравнивания
- просмотр слайда
- мастер-слайд
- слайд-макет
- мастер заметок
- мастер раздаточного листа
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Добавляйте, получайте доступ и удаляйте горизонтальные и вертикальные руководящие линии в презентациях PowerPoint с помощью Aspose.Slides для Python через .NET."
---
## **Обзор**

Руководящие линии — это регулируемые горизонтальные и вертикальные линии, которые помогают пользователям постоянно выравнивать фигуры при редактировании презентации в PowerPoint. Они особенно полезны, когда приложение генерирует презентацию, которая позже будет дорабатываться вручную: приложение может сохранить те же вспомогательные линии выравнивания, которым авторы должны следовать при добавлении или перемещении содержимого.

Руководящие линии являются вспомогательными инструментами редактирования, а не содержимым слайда. Они не отображаются в показе слайдов или в визуализированном выводе. Aspose.Slides для Python через .NET предоставляет их через интерфейс [IDrawingGuidesCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/idrawingguidescollection/). Руководящая линия представлена объектом [IDrawingGuide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/idrawingguide/) и имеет ориентацию, позицию и цвет.

Позиция измеряется в пунктах от верхнего левого угла соответствующего слайда или мастера. Вертикальная линия использует горизонтальную координату, обычно в диапазоне от нуля до ширины слайда. Горизонтальная линия использует вертикальную координату, обычно в диапазоне от нуля до высоты слайда.

## **Добавление руководящих линий в представление слайда**

Используйте [ICommonSlideViewProperties.drawing_guides](https://reference.aspose.com/slides/ru/python-net/aspose.slides/icommonslideviewproperties/drawing_guides/) для управления линиями, отображаемыми во время редактирования обычных слайдов. Вызовите [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/ru/python-net/aspose.slides/idrawingguidescollection/add/) с параметром [Orientation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/orientation/) и позицией в пунктах.

В следующем примере добавляется одна вертикальная линия справа от центра слайда и одна горизонтальная линия ниже него:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 + 12.5)
    guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 12.5)

    presentation.save("drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Доступ к руководящим линиям**

Свойство [IDrawingGuidesCollection.count](https://reference.aspose.com/slides/ru/python-net/aspose.slides/idrawingguidescollection/count/) и индексатор предоставляют доступ к существующим линиям. Свойства [IDrawingGuide.orientation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.position](https://reference.aspose.com/slides/ru/python-net/aspose.slides/idrawingguide/position/) и [IDrawingGuide.color](https://reference.aspose.com/slides/ru/python-net/aspose.slides/idrawingguide/color/) можно читать и изменять.

В следующем примере читаются линии представления слайда из ранее созданной презентации:

```py
import aspose.slides as slides

with slides.Presentation("drawing-guides.pptx") as presentation:
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    for index in range(guides.count):
        guide = guides[index]
        print(f"Guide {index}: orientation = {guide.orientation}, position = {guide.position}, color = {guide.color}")
```

## **Добавление руководящих линий в мастер‑слайды и шаблоны**

Мастер‑слайд и каждый из его шаблонов могут иметь собственные коллекции руководящих линий. Используйте [IMasterSlide.drawing_guides](https://reference.aspose.com/slides/ru/python-net/aspose.slides/imasterslide/drawing_guides/) для мастера и [ILayoutSlide.drawing_guides](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ilayoutslide/drawing_guides/) для шаблона слайда.

В следующем примере добавляется вертикальная линия к первому мастер‑слайду и горизонтальная линия к первому шаблону слайда:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    master_guides = presentation.masters[0].drawing_guides
    layout_guides = presentation.layout_slides[0].drawing_guides

    master_guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 - 20)
    layout_guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Добавление руководящих линий в заметки и раздаточные мастера**

Мастера заметок и раздаточных листов также поддерживают руководящие линии. Используйте [IMasterNotesSlide.drawing_guides](https://reference.aspose.com/slides/ru/python-net/aspose.slides/imasternotesslide/drawing_guides/) и [IMasterHandoutSlide.drawing_guides](https://reference.aspose.com/slides/ru/python-net/aspose.slides/imasterhandoutslide/drawing_guides/) для доступа к их коллекциям. Если в презентации нет одного из этих мастеров, [IMasterNotesSlideManager.set_default_master_notes_slide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/imasternotesslidemanager/set_default_master_notes_slide/) или [IMasterHandoutSlideManager.set_default_master_handout_slide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) создают мастер по умолчанию и возвращают его.

В следующем примере добавляется горизонтальная линия к мастеру заметок и вертикальная линия к раздаточному мастеру:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    notes_size = presentation.notes_size.size
    notes_master = presentation.master_notes_slide_manager.set_default_master_notes_slide()
    handout_master = presentation.master_handout_slide_manager.set_default_master_handout_slide()

    notes_master.drawing_guides.add(slides.Orientation.HORIZONTAL, notes_size.height / 2 + 50)
    handout_master.drawing_guides.add(slides.Orientation.VERTICAL, notes_size.width / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Очистка руководящих линий**

Вызовите [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/ru/python-net/aspose.slides/idrawingguidescollection/clear/) для удаления каждой линии из конкретной коллекции. Очистка одной коллекции не влияет на линии, хранящиеся в другой области.

В следующем примере очищаются линии представления слайда и все линии на мастерах слайдов, шаблонах, мастере заметок и раздаточном мастере без создания отсутствующих мастеров:

```py
import aspose.slides as slides

with slides.Presentation("presentation-with-guides.pptx") as presentation:
    presentation.view_properties.slide_view_properties.drawing_guides.clear()

    for master_slide in presentation.masters:
        master_slide.drawing_guides.clear()

    for layout_slide in presentation.layout_slides:
        layout_slide.drawing_guides.clear()

    notes_master = presentation.master_notes_slide_manager.master_notes_slide
    if notes_master is not None:
        notes_master.drawing_guides.clear()

    handout_master = presentation.master_handout_slide_manager.master_handout_slide
    if handout_master is not None:
        handout_master.drawing_guides.clear()

    presentation.save("presentation-without-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Отображаются ли руководящие линии в показе слайдов или экспортированных изображениях?**

Нет. Руководящие линии служат вспомогательным средством выравнивания при редактировании и не рендерятся как содержимое презентации.

**Можно ли добавить руководящую линию непосредственно к отдельному обычному слайду?**

Руководящие линии для обычных слайдов хранятся в свойствах представления слайда презентации. Отдельные коллекции линий доступны для мастеров слайдов, шаблонов, мастеров заметок и раздаточных листов.

**Какие единицы измерения используются для позиций линий?**

Позиции указываются в пунктах, где 72 пункта соответствуют одному дюйму. Вертикальные позиции измеряются от левого края, горизонтальные — от верхнего края.

**Удаляет ли очистка руководящих линий формы или изменяет содержимое слайда?**

Нет. Метод `clear` удаляет только линии в выбранной коллекции. Формы и другое содержимое слайда остаются без изменений.