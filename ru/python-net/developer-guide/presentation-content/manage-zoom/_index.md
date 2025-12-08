---
title: Управление зумами в презентациях с Python
linktitle: Зум
type: docs
weight: 60
url: /ru/python-net/manage-zoom/
keywords:
- зум
- зум-кадр
- зум слайда
- зум раздела
- зум-резюме
- добавить зум
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Создавайте и настраивайте зум с помощью Aspose.Slides для Python через .NET — переходите между разделами, добавляйте миниатюры и переходы в презентациях PPT, PPTX и ODP."
---

## **Обзор**
Zoom в PowerPoint позволяет переключаться к отдельным слайдам, разделам и частям презентации и обратно. При проведении презентации эта возможность быстро перемещаться по содержимому может оказаться очень полезной. 

![обзор](overview.png)

* Чтобы суммировать всю презентацию на одном слайде, используйте [Summary Zoom](#Summary-Zoom).
* Чтобы показывать только выбранные слайды, используйте [Slide Zoom](#Slide-Zoom).
* Чтобы показывать только один раздел, используйте [Section Zoom](#Section-Zoom).

## **Slide Zoom**

Slide Zoom может сделать вашу презентацию более динамичной, позволяя свободно переключаться между слайдами в любом порядке без прерывания потока презентации. Slide Zoom отлично подходит для коротких презентаций без множества разделов, но их также можно использовать в разных сценариях представления.

Slide Zoom помогает детализировать несколько фрагментов информации, будто вы работаете на едином холсте. 

![slidezoomsel](slidezoomsel.png)

Для объектов Slide Zoom Aspose.Slides предоставляет перечисление [ZoomImageType](https://reference.aspose.com/slides/python-net/aspose.slides/zoomimagetype/), интерфейс [IZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/izoomframe/) и некоторые методы в интерфейсе [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).

### **Создание Zoom‑кадров**
Вы можете добавить Zoom‑кадр на слайд следующим образом:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2.	Create new slides to which you intend to link. 
3.	Add an identification text and background to the created slides.
4.	Add zoom frames (containing the references to created slides) into the first slide.
5.	Write the modified presentation as a PPTX file.

Этот пример кода показывает, как создать Zoom‑кадр на слайде:
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Добавить новые слайды в презентацию
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Создать фон для второго слайда
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Создать текстовое поле для второго слайда
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Создать фон для третьего слайда
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Создать текстовое поле для третьего слайда
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #Add ZoomFrame objects
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Сохранить презентацию
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```

### **Создание Zoom‑кадров с пользовательскими изображениями**
С помощью Aspose.Slides for Python via .NET можно создать Zoom‑кадр с изображением, отличающимся от изображения превью слайда, следующим образом: 
1.	Create an instance of the `Presentation` class.
2.	Create a new slide to which you intend to link. 
3.	Add an identification text and background to created slide.
4.	Create an [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) object by adding an image to the Images collection associated with the Presentation object that will be used to fill the frame.
5.	Add zoom frames (containing the reference to created slide) into the first slide.
6.	Write the modified presentation as a PPTX file.

Этот python‑код показывает, как создать Zoom‑кадр с другим изображением:
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Добавить новый слайд в презентацию
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Создать фон для второго слайда
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Создать текстовое поле для третьего слайда
    autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Создать новое изображение для объекта зум
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    #Добавить объект ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    # Сохранить презентацию
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **Форматирование Zoom‑кадров**
В предыдущих разделах (выше) мы показали, как создавать простые Zoom‑кадры. Чтобы создавать более сложные Zoom‑кадры, необходимо изменить их форматирование. Существует несколько параметров форматирования, которые можно применить к Zoom‑кадру. 

Вы можете управлять форматированием Zoom‑кадра на слайде следующим образом:

1.	Create an instance of the `Presentation` class.
2.	Create new slides to link to.
3.	Add identification text and background to created slides.
4.	Add zoom frames (containing the references to created slides) into the first slide.
5.	Create an [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) object by adding an image to the Images collection associated with the Presentation object that will be used to fill the frame.
6.Set a custom image for the first zoom frame object.
7.Change the line format for the second zoom frame object.
8.Remove the background from an image of the second zoom frame object.
5.Write the modified presentation as a PPTX file.

Этот python‑пример кода показывает, как изменить форматирование Zoom‑кадра: 
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Добавить новые слайды в презентацию
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Создать фон для второго слайда
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Создать текстовое поле для второго слайда
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Создать фон для третьего слайда
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Создать текстовое поле для третьего слайда
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #Добавить объекты ZoomFrame
    zoomFrame1 = pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    zoomFrame2 = pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Создать новое изображение для объекта зум
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    # Установить пользовательское изображение для объекта zoomFrame1
    zoomFrame1.image = image

    # Установить формат ZoomFrame для объекта zoomFrame2
    zoomFrame2.line_format.width = 5
    zoomFrame2.line_format.fill_format.fill_type = slides.FillType.SOLID
    zoomFrame2.line_format.fill_format.solid_fill_color.color = draw.Color.hot_pink
    zoomFrame2.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    # Не показывать фон для объекта zoomFrame2
    zoomFrame2.show_background = False

    # Сохранить презентацию
    pres.save("presentation-zoom2.pptx", slides.export.SaveFormat.PPTX)
```


## **Section Zoom**

Section Zoom — это ссылка на раздел в вашей презентации. Вы можете использовать Section Zoom, чтобы возвращаться к разделам, которым хотите уделить особое внимание. Или использовать их, чтобы подчеркнуть взаимосвязи между различными частями презентации. 

![seczoomsel](seczoomsel.png)

Для объектов Section Zoom Aspose.Slides предоставляет интерфейс [ISectionZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/isectionzoomframe/) и некоторые методы в интерфейсе [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).

### **Создание Section Zoom‑кадров**

Вы можете добавить Section Zoom‑кадр на слайд следующим образом:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2.	Create a new slide. 
3.	Add an identification background to the created slide.
4.	Create a new section to which you intend to link the zoom frame. 
5.	Add a section zoom frame (containing references to the created section) to the first slide.
6.	Write the modified presentation as a PPTX file.

Этот python‑код показывает, как создать Zoom‑кадр на слайде:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Добавляет новый слайд в презентацию
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Добавляет новый раздел в презентацию
    pres.sections.add_section("Section 1", slide)

    # Добавляет объект SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Сохраняет презентацию
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **Создание Section Zoom‑кадров с пользовательскими изображениями**

С помощью Aspose.Slides for Python можно создать Section Zoom‑кадр с другим изображением превью слайда следующим образом: 

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2.	Create a new slide.
3.	Add an identification background to created slide.
4.	Create a new section to which you intend to link the zoom frame. 
5.	Create an `IPPImage` object by adding an image to the Images collection associated with the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) object that will be used to fill the frame.
6.	Add a section zoom frame (containing a reference to the created section) to the first slide.
7.	Write the modified presentation as a PPTX file.

Этот python‑код показывает, как создать Zoom‑кадр с другим изображением:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Добавляет новый слайд в презентацию
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Добавляет новый раздел в презентацию
    pres.sections.add_section("Section 1", slide)

    # Создает новое изображение для зум-объекта
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    # Добавляет объект SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1], image)

    # Сохраняет презентацию
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **Форматирование Section Zoom‑кадров**

Чтобы создавать более сложные Section Zoom‑кадры, необходимо изменить форматирование простого кадра. Существует несколько вариантов форматирования, которые можно применить к Section Zoom‑кадру. 

Вы можете управлять форматированием Section Zoom‑кадра на слайде следующим образом:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2.	Create a new slide.
3.	Add identification background to created slide.
4.	Create a new section to which you intend to link the zoom frame. 
5.	Add a section zoom frame (containing references to created section) to the first slide.
6.Change the size and position for the created section zoom object.
7.Create an `IPPImage` object by adding an image to the Images collection associated with the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) object that will be used to fill the frame.
8.Set a custom image for the created section zoom frame object.
9.Set the *return to the original slide from the linked section* ability. 
10.Remove the background from an image of the section zoom frame object.
11.Change the line format for the second zoom frame object.
12.Change the transition duration.
13.Write the modified presentation as a PPTX file.

Этот python‑код показывает, как изменить форматирование Section Zoom‑кадра:
```py
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Добавляет новый слайд в презентацию
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Добавляет новый раздел в презентацию
    pres.sections.add_section("Section 1", slide)

    # Add SectionZoomFrame object
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Formatting for SectionZoomFrame
    sectionZoomFrame.x = 100
    sectionZoomFrame.y = 300
    sectionZoomFrame.width = 100
    sectionZoomFrame.height = 75

    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    sectionZoomFrame.image = image

    sectionZoomFrame.return_to_parent = True
    sectionZoomFrame.show_background = False

    sectionZoomFrame.line_format.fill_format.fill_type = slides.FillType.SOLID
    sectionZoomFrame.line_format.fill_format.solid_fill_color.color = draw.Color.brown
    sectionZoomFrame.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    sectionZoomFrame.line_format.width = 2.5

    sectionZoomFrame.transition_duration = 1.5

    # Сохраняет презентацию
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **Summary Zoom**

Summary Zoom — это своего рода целевая страница, на которой одновременно отображаются все части презентации. При проведении презентации вы можете использовать Zoom, чтобы переходить от одного места к другому в произвольном порядке. Вы можете креативно перемещаться вперёд, назад или возвращаться к отдельным частям слайд‑шоу без прерывания потока презентации.

![overview_image](summaryzoom.png)

Для объектов Summary Zoom Aspose.Slides предоставляет интерфейсы [ISummaryZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomframe/), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsection/), [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/) и некоторые методы в интерфейсе [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).

### **Создание Summary Zoom**

Вы можете добавить Summary Zoom‑кадр на слайд следующим образом:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2.	Create new slides with identification background and new sections for created slides.
3.	Add the summary zoom frame to the first slide.
4.	Write the modified presentation as a PPTX file.

Этот python‑код показывает, как создать Summary Zoom‑кадр на слайде:
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # Создать массив слайдов
    for slideNumber in range(5):
        #Add новые слайды в презентацию
        slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

        # Создать фон для слайда
        slide.background.type = slides.BackgroundType.OWN_BACKGROUND
        slide.background.fill_format.fill_type = slides.FillType.SOLID
        slide.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

        # Создать текстовое поле для слайда
        autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
        autoshape.text_frame.text = "Slide - {num}".format(num = (slideNumber + 2))

    # Создать объекты зума для всех слайдов на первом слайде
    for slideNumber in range(1, len(pres.slides)):
        x = (slideNumber - 1) * 100
        y = (slideNumber - 1) * 100
        zoomFrame = pres.slides[0].shapes.add_zoom_frame(x, y, 150, 120, pres.slides[slideNumber])

        # Установить свойство ReturnToParent для возврата к первому слайду
        zoomFrame.return_to_parent = True

    # Сохранить презентацию
    pres.save("presentation-zoom3.pptx", slides.export.SaveFormat.PPTX)
```


### **Добавление и удаление секций Summary Zoom**

Все секции в Summary Zoom‑кадре представлены объектами [ISummaryZoomFrameSection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsection/), которые хранятся в объекте [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/). Вы можете добавить или удалить объект секции Summary Zoom через интерфейс [ISummaryZoomSectionCollection] следующим образом:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2.	Create new slides with identification background and new sections for created slides.
3.	Add a summary zoom frame into the first slide.
4.	Add a new slide and section to the presentation.
5.	Add the created section to the summary zoom frame.
6.	Remove the first section from the summary zoom frame.
7.	Write the modified presentation as a PPTX file.

Этот python‑код показывает, как добавить и удалить секции в Summary Zoom‑кадре:
``` python
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Добавляет новый слайд в презентацию
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Добавляет новый раздел в презентацию
    pres.sections.add_section("Section 1", slide)

    #Добавляет новый слайд в презентацию
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Добавляет новый раздел в презентацию
    pres.sections.add_section("Section 2", slide)

    # Добавляет объект SummaryZoomFrame
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    #Добавляет новый слайд в презентацию
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.chartreuse
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Добавляет новый раздел в презентацию
    section3 = pres.sections.add_section("Section 3", slide)

    # Добавляет раздел в Summary Zoom
    summaryZoomFrame.summary_zoom_collection.add_summary_zoom_section(section3)

    # Удаляет раздел из Summary Zoom
    summaryZoomFrame.summary_zoom_collection.remove_summary_zoom_section(pres.sections[1])

    # Сохраняет презентацию
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **Форматирование секций Summary Zoom**

Чтобы создавать более сложные объекты секций Summary Zoom, необходимо изменить форматирование простого кадра. Существует несколько вариантов форматирования, которые можно применить к объекту секции Summary Zoom. 

Вы можете управлять форматированием объекта секции Summary Zoom в Summary Zoom‑кадре следующим образом:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2.	Create new slides with identification background and new sections for created slides.
3.	Add a summary zoom frame to the first slide.
4.	Get a summary zoom section object for the first object from the `ISummaryZoomSectionCollection`.
5.	Create an `IPPImage` object by adding an image to the images collection associated with the  [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) object that will be used to fill the frame.
6.	Set a custom image for the created section zoom frame object.
7.	Set the *return to the original slide from the linked section* ability. 
8.	Change the line format for the second zoom frame object.
9.	Change the transition duration.
10.	Write the modified presentation as a PPTX file.

Этот python‑код показывает, как изменить форматирование объекта секции Summary Zoom:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Добавляет новый слайд в презентацию
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.brown
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Добавляет новый раздел в презентацию
    pres.sections.add_section("Section 1", slide)

    #Добавляет новый слайд в презентацию
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Добавляет новый раздел в презентацию
    pres.sections.add_section("Section 2", slide)

    # Добавляет объект SummaryZoomFrame
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    # Получает первый объект SummaryZoomSection
    summarySection = summaryZoomFrame.summary_zoom_collection[0]

    # Форматирование объекта SummaryZoomSection
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    summarySection.image = image

    summarySection.return_to_parent = False

    summarySection.line_format.fill_format.fill_type = slides.FillType.SOLID
    summarySection.line_format.fill_format.solid_fill_color.color = draw.Color.black
    summarySection.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    summarySection.line_format.width = 1.5

    summarySection.transition_duration = 1.5

    # Сохраняет презентацию
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Можно ли управлять возвратом к «родительскому» слайду после показа цели?**

Да. У [Zoom‑кадра](https://reference.aspose.com/slides/python-net/aspose.slides/zoomframe/) или [section](https://reference.aspose.com/slides/python-net/aspose.slides/sectionzoomframe/) есть поведение `return_to_parent`, которое при включении отправляет зрителей обратно к исходному слайду после просмотра целевого содержимого.

**Можно ли настроить «скорость» или длительность перехода Zoom?**

Да. Zoom поддерживает установку `transition_duration`, позволяя контролировать, сколько времени занимает анимация перехода.

**Есть ли ограничения на количество Zoom‑объектов в презентации?**

Твёрдого ограничения API не задокументировано. Практические ограничения зависят от общей сложности презентации и производительности устройства просмотра. Вы можете добавить много Zoom‑кадров, но учитывайте размер файла и время рендеринга.