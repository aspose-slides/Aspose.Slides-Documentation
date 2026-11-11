---
title: Управление зумом презентации в Python через Java
linktitle: Управление зумом
type: docs
weight: 60
url: /ru/python-java/manage-zoom/
keywords:
- зум
- зум-кадр
- зум слайда
- зум раздела
- зум резюме
- добавить зум
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Создавайте и настраивайте зум с помощью Aspose.Slides for Python via Java — перемещайтесь между разделами, добавляйте миниатюры и переходы в презентациях PowerPoint."
---
## **Введение**

PowerPoint zoom позволяет перемещаться между отдельными слайдами и разделами во время показа слайдов. С помощью Aspose.Slides for Python via Java вы можете создавать зумы слайдов, разделов и резюме, а также настраивать их предварительные просмотры, рамки и переходы.

![Обзор зумов PowerPoint](overview.png)

* Чтобы суммировать всю презентацию на одном слайде, используйте [Summary Zoom](#summary-zoom).
* Чтобы показывать только выбранные слайды, используйте [Slide Zoom](#slide-zoom).
* Чтобы показывать только один раздел, используйте [Section Zoom](#section-zoom).

## **Slide Zoom**

Zoom слайда может сделать вашу презентацию более динамичной, позволяя свободно перемещаться между слайдами в любом порядке без прерывания потока презентации. Zoom слайды отлично подходят для коротких презентаций без множества разделов, но их можно использовать и в других сценариях.

Zoom слайды позволяют исследовать связанную информацию с одного обзорного слайда.

![Выбор слайдов для зума слайда](slidezoomsel.png)

Для объектов Zoom слайда Aspose.Slides предоставляет перечисление [ZoomImageType](https://reference.aspose.com/slides/python-java/aspose.slides/zoomimagetype/), класс [ZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/zoomframe/) и методы класса [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/).

### **Создание Zoom‑кадров**

Используйте [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addZoomFrame) для размещения ссылок на отдельные слайды на обзорном слайде. Этот пример создает два целевых слайда с разными фонами и метками, затем добавляет предварительный просмотр каждого на первый слайд и сохраняет презентацию как PPTX. Позиция и размеры кадров задаются в пунктах.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    second_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())

    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(189, 183, 107))

    text_box = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Third Slide")

    overview_slide.getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    overview_slide.getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Создание Zoom‑кадров с пользовательскими изображениями**

Передайте пользовательское изображение в [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addZoomFrame), чтобы заменить стандартный предварительный просмотр целевого слайда. В этом примере используется локальное изображение, загружаемое с помощью [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile), и добавляемое в презентацию через [ImageCollection.addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). Полученный кадр отображает это изображение, оставаясь ссылкой на второй слайд.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    overview_slide.getShapes().addZoomFrame(20, 20, 300, 200, slide, preview_image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Форматирование Zoom‑кадров**

В этом примере настраиваются два Zoom‑кадра слайда. К первому кадру через [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage) присваивается локальное изображение, а второму задаётся пятиточечная пунктирно‑точечная розовая рамка через [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat). Передача `False` в [ZoomObject.setShowBackground](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setShowBackground) скрывает фон второго кадра. Для пользовательского предварительного просмотра требуется локальное изображение; оба кадра сохраняют ссылки на свои слайды в сохранённом PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    second_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())

    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(189, 183, 107))

    text_box = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Third Slide")

    first_zoom_frame = overview_slide.getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    second_zoom_frame = overview_slide.getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    first_zoom_frame.setZoomImage(preview_image)

    second_zoom_frame.getLineFormat().setWidth(5)
    second_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    second_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(255, 105, 180))
    second_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)

    second_zoom_frame.setShowBackground(False)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Section Zoom**

Section Zoom связывает с разделом вашей презентации. Используйте его, чтобы вернуться к теме или показать, как разные части презентации связаны между собой.

![Выбор раздела для зума раздела](seczoomsel.png)

Для объектов Section Zoom Aspose.Slides предоставляет класс [SectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/sectionzoomframe/) и методы класса [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/).

### **Создание Section Zoom‑кадров**

Создайте раздел с помощью [SectionCollection.addSection](https://reference.aspose.com/slides/python-java/aspose.slides/sectioncollection/#addSection), затем передайте полученный раздел в [ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSectionZoomFrame). Этот пример размещает Section Zoom на первом слайде и связывает его с разделом, начинающимся с цветного слайда. Позиция и размеры кадра задаются в пунктах, презентация сохраняется как PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    section = presentation.getSections().addSection("Section 1", slide)
    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Создание Section Zoom‑кадров с пользовательскими изображениями**

Перегрузка метода изображения [ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSectionZoomFrame) позволяет отображать пользовательский предварительный просмотр без изменения целевого раздела. В этом примере требуется локальное изображение, которое загружается с помощью [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) и добавляется через [ImageCollection.addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). Сохранённая презентация содержит Section Zoom на первом слайде, связанный с только что созданным разделом.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    section = presentation.getSections().addSection("Section 1", slide)
    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section, preview_image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Изменение целевого раздела Section Zoom**

Используйте [SectionZoomFrame.setTargetSection](https://reference.aspose.com/slides/python-java/aspose.slides/sectionzoomframe/#setTargetSection), чтобы перенаправить существующий Section Zoom без его повторного создания. Выберите заполненный раздел из коллекции [Presentation.getSections](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSections) той же презентации. Присвоение пустого раздела оставляет текущую цель без изменений, поэтому перед присвоением проверьте [Section.getSlidesListOfSection](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getSlidesListOfSection). См. [Manage Slide Sections](/slides/ru/python-java/slide-section/) для получения дополнительной информации о разделах.

В следующем примере загружается файл презентации, который должен содержать несколько заполненных разделов, существующий Section Zoom с именем `Section navigation` и раздел с уникальным именем `Results`. Поиск происходит по всем слайдам для зума и определяет пункт назначения по имени, а не по индексу коллекции, который может измениться при переупорядочивании разделов. Если имена не уникальны, используйте [Section.getSectionId](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getSectionId) для идентификации пункта назначения.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SectionZoomFrame

presentation = Presentation("section-zoom.pptx")
try:
    zoom = None
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, SectionZoomFrame) and shape.getName() == "Section navigation":
                zoom = shape
                break
        if zoom is not None:
            break

    target_section = None
    for section in presentation.getSections():
        if section.getName() == "Results":
            target_section = section
            break

    if zoom is None or target_section is None:
        print("The section zoom or destination section was not found.")
    elif target_section.getSlidesListOfSection().size() == 0:
        print("The destination section is empty.")
    else:
        current_section = zoom.getTargetSection()
        current_name = "" if current_section is None else current_section.getName()
        print("Current section: " + str(current_name))
        zoom.setTargetSection(target_section)
        presentation.save("section-zoom-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Форматирование Section Zoom‑кадров**

Этот пример перемещает и изменяет размер Section Zoom до 100 × 75 пунктов, назначает локальное изображение через [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage) и применяет 2,5‑пунктовую пунктирно‑точечную коричневую рамку. Включает [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent), чтобы возвращаться к исходному слайду после раздела, отключает [ZoomObject.setShowBackground](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setShowBackground) и задаёт [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) в 1,5 секунды. Для пользовательского предварительного просмотра требуется локальное изображение.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    section = presentation.getSections().addSection("Section 1", slide)

    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section)
    section_zoom_frame.setX(100)
    section_zoom_frame.setY(300)
    section_zoom_frame.setWidth(100)
    section_zoom_frame.setHeight(75)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    section_zoom_frame.setZoomImage(preview_image)

    section_zoom_frame.setReturnToParent(True)
    section_zoom_frame.setShowBackground(False)

    section_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    section_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    section_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    section_zoom_frame.getLineFormat().setWidth(2.5)

    section_zoom_frame.setTransitionDuration(1.5)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Summary Zoom**

Summary Zoom предоставляет обзор разделов презентации. Во время показа слайдов вы можете использовать его для перехода к разделу, пропуска вперед или возврата к теме без соблюдения порядка слайдов.

![Выбор разделов для резюме‑зума](sumzoomsel.png)

Для объектов Summary Zoom Aspose.Slides предоставляет классы [SummaryZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsection/) и [SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/), а также методы класса [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/).

### **Создание Summary Zoom**

Используйте [ShapeCollection.addSummaryZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSummaryZoomFrame) для создания обзора разделов презентации. Этот пример создает четыре раздела с различными фонами слайдов и добавляет Summary Zoom на первый слайд. Позиция и размеры кадра задаются в пунктах, итоговый обзор сохраняется в PPTX‑презентацию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(127, 255, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 3", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(0, 100, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 4", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Добавление и удаление раздела Summary Zoom**

Summary Zoom хранит свои объекты [SummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsection/) в [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection). Этот пример создаёт обзор из двух разделов, добавляет третий раздел с помощью [SummaryZoomSectionCollection.addSummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/#addSummaryZoomSection) и удаляет запись первого раздела через [SummaryZoomSectionCollection.removeSummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/#removeSummaryZoomSection). Удаление записи оставляет раздел презентации и его слайды нетронутыми.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    first_section = presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(127, 255, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    third_section = presentation.getSections().addSection("Section 3", slide)

    summary_zoom_frame.getSummaryZoomCollection().addSummaryZoomSection(third_section)

    summary_zoom_frame.getSummaryZoomCollection().removeSummaryZoomSection(first_section)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Форматирование разделов Summary Zoom**

В этом примере форматируется первая запись в [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection), используя нулевой индекс `0`. Требуется локальное изображение для [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage), применяется 1,5‑пунктовая пунктирно‑точечная чёрная рамка и задаётся [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) в 1,5 секунды. Передача `False` в [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) отключает автоматический возврат к обзорному слайду для этой записи.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    summary_section = summary_zoom_frame.getSummaryZoomCollection().get_Item(0)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    summary_section.setZoomImage(preview_image)
    summary_section.setReturnToParent(False)

    summary_section.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    summary_section.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    summary_section.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    summary_section.getLineFormat().setWidth(1.5)

    summary_section.setTransitionDuration(1.5)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Могу ли я управлять возвратом к «родительскому» слайду после показа цели?**

Да. Вызовите [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) с `True`, чтобы после отображения целевого содержимого вернуться к исходному слайду.

**Можно ли настроить «скорость» или длительность перехода Zoom?**

Да. Используйте [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) для управления длительностью перехода в секундах.

**Есть ли ограничения на количество Zoom‑объектов в презентации?**

Твёрдых ограничений API в документации нет. Практические ограничения зависят от общей сложности презентации и производительности устройства. Можно добавить множество Zoom‑кадров, но следует учитывать размер файла и время рендеринга.