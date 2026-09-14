---
title: Управление направляющими в презентациях на Python
linktitle: Направляющие
type: docs
weight: 85
url: /ru/python-java/drawing-guides/
keywords:
- направляющая
- горизонтальная направляющая
- вертикальная направляющая
- направляющая выравнивания
- просмотр слайда
- главный слайд
- макет слайда
- мастер заметок
- мастер раздаточного листа
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Добавляйте, получайте доступ и удаляйте горизонтальные и вертикальные направляющие в презентациях PowerPoint с использованием Aspose.Slides for Python via Java."
---
## **Обзор**

Направляющие – это регулируемые горизонтальные и вертикальные линии, помогающие пользователям последовательно выравнивать фигуры при редактировании презентации в PowerPoint. Они особенно полезны, когда приложение генерирует презентацию, которую затем необходимо доработать вручную: приложение может сохранить те же вспомогательные ориентиры, которым должны следовать авторы при добавлении или перемещении содержимого.

Направляющие являются средствами редактирования, а не содержимым слайда. Они не отображаются в режиме показа слайдов и не попадают в готовый вывод. Aspose.Slides for Python via Java предоставляет их через класс [DrawingGuidesCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/drawingguidescollection/). Одна направляющая представлена объектом [DrawingGuide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/drawingguide/) и имеет ориентацию, позицию и цвет.

Позиция измеряется в пунктах от верхнего левого угла соответствующего слайда или шаблона. Вертикальная направляющая использует горизонтальную координату, обычно в диапазоне от нуля до ширины слайда. Горизонтальная направляющая использует вертикальную координату, обычно в диапазоне от нуля до высоты слайда.

## **Добавление направляющих в режим слайда**

Используйте [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) для управления направляющими, отображаемыми при редактировании обычных слайдов. Вызовите [DrawingGuidesCollection.add](https://reference.aspose.com/slides/ru/python-java/aspose.slides/drawingguidescollection/#add) с значением [Orientation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/orientation/) и позицией в пунктах.

В следующем примере добавляется одна вертикальная направляющая справа от центра слайда и одна горизонтальная направляющая ниже него:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    guides.add(Orientation.Vertical, slide_size.getWidth() / 2 + 12.5)
    guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 12.5)

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Доступ к направляющим**

Методы [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/ru/python-java/aspose.slides/drawingguidescollection/#getCount) и [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/ru/python-java/aspose.slides/drawingguidescollection/#get_Item) предоставляют доступ к существующим направляющим. Методы [DrawingGuide.getOrientation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/ru/python-java/aspose.slides/drawingguide/#getPosition) и [DrawingGuide.getColor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/drawingguide/#getColor) возвращают значения, которые также можно изменить соответствующими методами‑установщиками.

В следующем примере читаются направляющие режима слайда из презентации, созданной выше:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("drawing-guides.pptx")
try:
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    for index in range(guides.getCount()):
        guide = guides.get_Item(index)
        print(f"Guide {index}: orientation = {guide.getOrientation()}, position = {guide.getPosition()}, color = {guide.getColor()}")
finally:
    presentation.dispose()
```

## **Добавление направляющих к слайдам‑мастерам и макетам**

Слайд‑мастер и каждый из его макетов могут иметь собственные коллекции направляющих. Используйте [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterslide/#getDrawingGuides) для слайда‑мастера и [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutslide/#getDrawingGuides) для макет‑слайда.

В следующем примере добавляется вертикальная направляющая к первому слайду‑мастеру и горизонтальная направляющая к первому макет‑слайду:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    master_guides = presentation.getMasters().get_Item(0).getDrawingGuides()
    layout_guides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides()

    master_guides.add(Orientation.Vertical, slide_size.getWidth() / 2 - 20)
    layout_guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Добавление направляющих к заметкам и раздаточным листам мастеров**

Мастера заметок и раздаточных листов также поддерживают направляющие. Используйте [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masternotesslide/#getDrawingGuides) и [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterhandoutslide/#getDrawingGuides) для доступа к их коллекциям. Если в презентации отсутствует один из этих мастеров, `MasterNotesSlideManager.setDefaultMasterNotesSlide` или `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` создаёт мастер по умолчанию и возвращает его.

В следующем примере добавляется горизонтальная направляющая к мастеру заметок и вертикальная направляющая к мастеру раздаточного листа:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    notes_size = presentation.getNotesSize().getSize()
    notes_master = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide()
    handout_master = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    notes_master.getDrawingGuides().add(Orientation.Horizontal, notes_size.getHeight() / 2 + 50)
    handout_master.getDrawingGuides().add(Orientation.Vertical, notes_size.getWidth() / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Очистка направляющих**

Вызовите [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/ru/python-java/aspose.slides/drawingguidescollection/#clear), чтобы удалить все направляющие из конкретной коллекции. Очистка одной коллекции не влияет на направляющие, хранящиеся в другой области.

В следующем примере очищаются направляющие режима слайда и все направляющие на слайдах‑мастерах, макет‑слайдах, мастере заметок и мастере раздаточного листа без создания недостающих мастеров:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation-with-guides.pptx")
try:
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear()

    for master_slide in presentation.getMasters():
        master_slide.getDrawingGuides().clear()

    for layout_slide in presentation.getLayoutSlides():
        layout_slide.getDrawingGuides().clear()

    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()
    if notes_master is not None:
        notes_master.getDrawingGuides().clear()

    handout_master = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()
    if handout_master is not None:
        handout_master.getDrawingGuides().clear()

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Часто задаваемые вопросы**

**Появляются ли направляющие в показе слайдов или экспортированных изображениях?**

Нет. Направляющие служат вспомогательными средствами выравнивания при редактировании и не выводятся как содержимое презентации.

**Можно ли добавить направляющую непосредственно к отдельному обычному слайду?**

Обычные направляющие хранятся в свойствах режима просмотра слайдов презентации. Отдельные коллекции направляющих доступны для мастеров слайдов, макет‑слайдов, мастеров заметок и мастеров раздаточных листов.

**Какие единицы измерения используются для позиций направляющих?**

Позиции задаются в пунктах, где 72 пункта равны одному дюйму. Вертикальные позиции измеряются от левого края, горизонтальные – от верхнего края.

**Удаляет ли очистка направляющих формы или изменяет содержимое слайда?**

Нет. Метод [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/ru/python-java/aspose.slides/drawingguidescollection/#clear) удаляет только направляющие в выбранной коллекции. Формы и прочее содержимое слайда остаются без изменений.