---
title: Управление Zoom презентаций в Python через Java
linktitle: Управление Zoom
type: docs
weight: 60
url: /ru/python-java/manage-zoom/
keywords:
- масштабирование
- кадр масштабирования
- масштабирование слайда
- масштабирование раздела
- масштабирование свода
- добавить масштабирование
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Создавайте и настраивайте Zoom с помощью Aspose.Slides для Python через Java — перемещайтесь между разделами, добавляйте миниатюры и переходы в презентациях PPT, PPTX и ODP."
---
## **Introduction**

Zoom в PowerPoint позволяют перемещаться к определённым слайдам, разделам и частям презентации и обратно. При демонстрации эта возможность быстрой навигации по материалу может оказаться очень полезной.

![overview_image](overview.png)

* Чтобы суммировать всю презентацию на одном слайде, используйте [Summary Zoom](#summary-zoom).
* Чтобы показать только выбранные слайды, используйте [Slide Zoom](#slide-zoom).
* Чтобы показать только один раздел, используйте [Section Zoom](#section-zoom).

## **Slide Zoom**
Zoom слайда может сделать вашу презентацию более динамичной, позволяя свободно перемещаться между слайдами в любом порядке без прерывания потока презентации. Zoom слайда отлично подходит для коротких презентаций без большого количества разделов, но их можно использовать и в других сценариях.

Zoom слайда помогает детализировать несколько фрагментов информации, создавая ощущение работы на едином холсте.

![overview_image](slidezoomsel.png)

Для объектов Zoom слайда Aspose.Slides предоставляет перечисление [ZoomImageType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/zoomimagetype/), класс [ZoomFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/zoomframe/) и некоторые методы класса [ShapeCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/).

### **Create Zoom Frames**

Вы можете добавить кадр увеличения на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Создайте новые слайды, к которым планируете привязать кадры увеличения.
3. Добавьте идентифицирующий текст и фон к созданным слайдам.
4. Добавьте кадры увеличения (ссылка на созданные слайды) на первый слайд.
5. Сохраните изменённую презентацию в виде файла PPTX.

Этот код Python показывает, как создать кадр увеличения на слайде:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Добавляет новые слайды в презентацию
    second_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Создаёт фон для второго слайда
    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Создаёт текстовое поле для второго слайда
    auto_shape = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Создаёт фон для третьего слайда
    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray)

    #  Создаёт текстовое поле для третьего слайда
    auto_shape = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Third Slide")

    # Добавляет объекты ZoomFrame
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    #  Сохраняет презентацию
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Create Zoom Frames with Custom Images**
С помощью Aspose.Slides for Python via Java вы можете создать кадр увеличения с другим изображением превью слайда следующим образом:
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Создайте новый слайд, к которому планируете привязать кадр увеличения.
3. Добавьте идентифицирующий текст и фон к слайду.
4. Создайте объект [PPImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/), добавив изображение в коллекцию изображений, связанную с объектом [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/), которое будет использовано для заполнения кадра.
5. Добавьте кадры увеличения (ссылка на созданный слайд) на первый слайд.
6. Сохраните изменённую презентацию в виде файла PPTX.

Этот код Python показывает, как создать кадр увеличения с другим изображением:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Добавляет новый слайд в презентацию
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Создаёт фон для второго слайда
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Создаёт текстовое поле для второго слайда
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Создаёт новое изображение для объекта Zoom
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Добавляет объект ZoomFrame
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture)

    #  Сохраняет презентацию
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Format Zoom Frames**
В предыдущих разделах мы показывали, как создавать простые кадры увеличения. Чтобы создать более сложные кадры, необходимо изменить их форматирование. Существует несколько вариантов форматирования, которые можно применить к кадру увеличения.

Вы можете управлять форматированием кадра увеличения на слайде следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Создайте новые слайды, к которым планируете привязать кадры увеличения.
3. Добавьте идентифицирующий текст и фон к созданным слайдам.
4. Добавьте кадры увеличения (ссылка на созданные слайды) на первый слайд.
5. Создайте объект [PPImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/) и добавьте изображение в коллекцию изображений, связанную с объектом [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/), которое будет использовано для заполнения кадра.
6. Установите пользовательское изображение для первого объекта кадра увеличения.
7. Измените формат линии для второго объекта кадра увеличения.
8. Удалите фон изображения у второго объекта кадра увеличения.
9. Сохраните изменённую презентацию в виде файла PPTX.

Этот код Python показывает, как изменить форматирование кадра увеличения на слайде:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Adds new slides to the presentation
    # Добавляет новые слайды в презентацию
    second_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Creates a background for the second slide
    #  Создаёт фон для второго слайда
    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Creates a text box for the second slide
    #  Создаёт текстовое поле для второго слайда
    auto_shape = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Creates a background for the third slide
    #  Создаёт фон для третьего слайда
    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray)

    #  Creates a text box for the third slide
    #  Создаёт текстовое поле для третьего слайда
    auto_shape = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Third Slide")

    # Adds ZoomFrame objects
    # Добавляет объекты ZoomFrame
    first_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    second_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    #  Creates a new image for the zoom object
    #  Создаёт новое изображение для объекта zoom
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    #  Sets custom image for first_zoom_frame object
    #  Устанавливает пользовательское изображение для объекта first_zoom_frame
    first_zoom_frame.setZoomImage(picture)

    #  Sets a zoom frame format for the second_zoom_frame object
    #  Устанавливает формат кадра zoom для объекта second_zoom_frame
    second_zoom_frame.getLineFormat().setWidth(5)
    second_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    second_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink)
    second_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)

    #  Setting for Do not show background for second_zoom_frame object
    #  Настройка: не показывать фон для объекта second_zoom_frame
    second_zoom_frame.setShowBackground(False)

    #  Saves the presentation
    #  Сохраняет презентацию
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Section Zoom**

Zoom раздела представляет собой ссылку на раздел вашей презентации. Вы можете использовать Zoom раздела, чтобы возвращаться к разделам, которые хотите особо подчеркнуть, или чтобы показать, как различные части вашей презентации связаны между собой.

![overview_image](seczoomsel.png)

Для объектов Zoom раздела Aspose.Slides предоставляет класс [SectionZoomFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sectionzoomframe/) и некоторые методы класса [ShapeCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/).

### **Create Section Zoom Frames**

Вы можете добавить кадр Zoom раздела на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Создайте новый слайд.
3. Добавьте отличительный фон к созданному слайду.
4. Создайте новый раздел, к которому планируете привязать кадр увеличения.
5. Добавьте кадр Zoom раздела (ссылка на созданный раздел) на первый слайд.
6. Сохраните изменённую презентацию в виде файла PPTX.

Этот код Python показывает, как создать кадр увеличения на слайде:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Добавляет новый слайд в презентацию
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Добавляет новый раздел в презентацию
    presentation.getSections().addSection("Section 1", slide)

    #  Добавляет объект SectionZoomFrame
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1))

    #  Сохраняет презентацию
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Create Section Zoom Frames with Custom Images**

С помощью Aspose.Slides for Python via Java вы можете создать кадр Zoom раздела с другим изображением превью слайда следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Создайте новый слайд.
3. Добавьте отличительный фон к созданному слайду.
4. Создайте новый раздел, к которому планируете привязать кадр увеличения.
5. Создайте объект [PPImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/) и добавьте изображение в коллекцию изображений, связанную с объектом [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/), которое будет использовано для заполнения кадра.
6. Добавьте кадр Zoom раздела (ссылка на созданный раздел) на первый слайд.
7. Сохраните изменённую презентацию в виде файла PPTX.

Этот код Python показывает, как создать кадр увеличения с другим изображением:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Adds new slide to the presentation
    # Добавляет новый слайд в презентацию
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Adds a new Section to the presentation
    #  Добавляет новый раздел в презентацию
    presentation.getSections().addSection("Section 1", slide)

    #  Creates a new image for the zoom object
    #  Создаёт новое изображение для объекта zoom
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    #  Adds SectionZoomFrame object
    #  Добавляет объект SectionZoomFrame
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1), picture)

    #  Saves the presentation
    #  Сохраняет презентацию
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Format Section Zoom Frames**

Чтобы создать более сложные кадры Zoom раздела, необходимо изменить их форматирование. Существует несколько вариантов форматирования, которые можно применить к кадру Zoom раздела.

Вы можете управлять форматированием кадра Zoom раздела на слайде следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Создайте новый слайд.
3. Добавьте отличительный фон к созданному слайду.
4. Создайте новый раздел, к которому планируете привязать кадр увеличения.
5. Добавьте кадр Zoom раздела (ссылка на созданный раздел) на первый слайд.
6. Измените размер и положение созданного объекта Zoom раздела.
7. Создайте объект [PPImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/) и добавьте изображение в коллекцию изображений, связанную с объектом [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/), которое будет использовано для заполнения кадра.
8. Установите пользовательское изображение для созданного объекта Zoom раздела.
9. Включите возможность *возврата к оригинальному слайду из связанного раздела*.
10. Удалите фон изображения у объекта Zoom раздела.
11. Измените формат линии для объекта Zoom раздела.
12. Измените длительность перехода.
13. Сохраните изменённую презентацию в виде файла PPTX.

Этот код Python показывает, как изменить форматирование кадра Zoom раздела:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Добавляет новый слайд в презентацию
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Добавляет новый раздел в презентацию
    presentation.getSections().addSection("Section 1", slide)

    #  Добавляет объект SectionZoomFrame
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1))

    #  Форматирование для SectionZoomFrame
    section_zoom_frame.setX(100)
    section_zoom_frame.setY(300)
    section_zoom_frame.setWidth(100)
    section_zoom_frame.setHeight(75)

    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    section_zoom_frame.setZoomImage(picture)

    section_zoom_frame.setReturnToParent(True)
    section_zoom_frame.setShowBackground(False)

    section_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    section_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray)
    section_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    section_zoom_frame.getLineFormat().setWidth(2.5)

    section_zoom_frame.setTransitionDuration(1.5)

    #  Сохраняет презентацию
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```


## **Summary Zoom**

Zoom свода представляет собой «главную страницу», где все части вашей презентации отображаются одновременно. При демонстрации вы можете использовать Zoom, чтобы перемещаться от одного места к другому в произвольном порядке, пропускать части или возвращаться к ним без прерывания потока презентации.

![overview_image](sumzoomsel.png)

Для объектов Zoom свода Aspose.Slides предоставляет классы [SummaryZoomFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/summaryzoomsection/) и [SummaryZoomSectionCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/summaryzoomsectioncollection/), а также некоторые методы класса [ShapeCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/).

### **Create a Summary Zoom**

Вы можете добавить кадр Zoom свода на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Создайте новые слайды с отличительным фоном и новые разделы для этих слайдов.
3. Добавьте кадр Summary Zoom на первый слайд.
4. Сохраните изменённую презентацию в виде файла PPTX.

Этот код Python показывает, как создать кадр Summary Zoom на слайде:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Добавляет новый слайд в презентацию
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Добавляет новый раздел в презентацию
    presentation.getSections().addSection("Section 1", slide)

    # Adds a new slide to the presentation
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Добавляет новый раздел в презентацию
    presentation.getSections().addSection("Section 2", slide)

    # Adds a new slide to the presentation
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Добавляет новый раздел в презентацию
    presentation.getSections().addSection("Section 3", slide)

    # Adds a new slide to the presentation
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Добавляет новый раздел в презентацию
    presentation.getSections().addSection("Section 4", slide)

    #  Adds a SummaryZoomFrame object
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    #  Saves the presentation
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Add and Remove a Summary Zoom Section**

Все разделы в кадре Summary Zoom представлены объектами [SummaryZoomSection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/summaryzoomsection/), которые хранятся в объекте [SummaryZoomSectionCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/summaryzoomsectioncollection/). Вы можете добавить или удалить объект раздела Summary Zoom через класс [SummaryZoomSectionCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/summaryzoomsectioncollection/) следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Создайте новые слайды с отличительным фоном и новые разделы для этих слайдов.
3. Добавьте кадр Summary Zoom в первый слайд.
4. Добавьте новый слайд и раздел в презентацию.
5. Добавьте созданный раздел в кадр Summary Zoom.
6. Удалите первый раздел из кадра Summary Zoom.
7. Сохраните изменённую презентацию в виде файла PPTX.

Этот код Python показывает, как добавить и удалить разделы в кадре Summary Zoom:

```python
import jpype
import asposeslides

if not jpase.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Добавляет новый слайд в презентацию
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Добавляет новый раздел в презентацию
    presentation.getSections().addSection("Section 1", slide)

    # Adds a new slide to the presentation
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Добавляет новый раздел в презентацию
    presentation.getSections().addSection("Section 2", slide)

    #  Добавляет объект SummaryZoomFrame
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    # Adds a new slide to the presentation
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Добавляет новый раздел в презентацию
    third_section = presentation.getSections().addSection("Section 3", slide)

    #  Добавляет раздел в Summary Zoom
    summary_zoom_frame.getSummaryZoomCollection().addSummaryZoomSection(third_section)

    #  Удаляет раздел из Summary Zoom
    summary_zoom_frame.getSummaryZoomCollection().removeSummaryZoomSection(presentation.getSections().get_Item(1))

    #  Сохраняет презентацию
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Format Summary Zoom Sections**

Чтобы создать более сложные объекты разделов Summary Zoom, необходимо изменить их форматирование. Существует несколько вариантов форматирования, которые можно применить к объекту раздела Summary Zoom.

Вы можете управлять форматированием объекта раздела Summary Zoom в кадре Summary Zoom следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Создайте новые слайды с отличительным фоном и новые разделы для этих слайдов.
3. Добавьте кадр Summary Zoom на первый слайд.
4. Получите первый объект Summary Zoom Section из [SummaryZoomSectionCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/summaryzoomsectioncollection/).
5. Создайте объект [PPImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/) и добавьте изображение в коллекцию изображений, связанную с объектом [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/), которое будет использовано для заполнения кадра.
6. Установите пользовательское изображение для объекта раздела Summary Zoom.
7. Включите возможность *возврата к оригинальному слайду из связанного раздела*.
8. Измените формат линии для объекта раздела Summary Zoom.
9. Измените длительность перехода.
10. Сохраните изменённую презентацию в виде файла PPTX.

Этот код Python показывает, как изменить форматирование объекта раздела Summary Zoom:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Добавляет новый слайд в презентацию
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Добавляет новый раздел в презентацию
    presentation.getSections().addSection("Section 1", slide)

    # Adds a new slide to the presentation
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Добавляет новый раздел в презентацию
    presentation.getSections().addSection("Section 2", slide)

    #  Добавляет объект SummaryZoomFrame
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    #  Получает первый объект SummaryZoomSection
    summary_section = summary_zoom_frame.getSummaryZoomCollection().get_Item(0)

    #  Форматирование объекта SummaryZoomSection
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    summary_section.setZoomImage(picture)

    summary_section.setReturnToParent(False)

    summary_section.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    summary_section.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black)
    summary_section.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    summary_section.getLineFormat().setWidth(1.5)

    summary_section.setTransitionDuration(1.5)

    #  Сохраняет презентацию
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Can I control returning to the 'parent' slide after showing the target?**

Yes. The [ZoomFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/zoomframe/) or [SectionZoomFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sectionzoomframe/) supports returning to the originating slide through [setReturnToParent](https://reference.aspose.com/slides/ru/python-java/aspose.slides/zoomobject/#setReturnToParent), which sends viewers back after they visit the target content when enabled.

**Can I adjust the 'speed' or duration of the Zoom transition?**

Yes. Zoom supports setting a transition duration with [setTransitionDuration](https://reference.aspose.com/slides/ru/python-java/aspose.slides/zoomobject/#setTransitionDuration) so you can control how long the jump animation takes.

**Are there limits on how many Zoom objects a presentation can contain?**

There is no hard API limit documented. Practical limits depend on overall presentation complexity and the viewer's performance. You can add many Zoom frames, but consider file size and rendering time.