---
title: Управление зумами в презентациях с помощью Python
linktitle: Зум
type: docs
weight: 60
url: /ru/python-net/manage-zoom/
keywords:
- зум
- зум-рамка
- зум слайда
- зум раздела
- обзорный зум
- добавить зум
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Создавайте и настраивайте зум с помощью Aspose.Slides для Python через .NET — переходите между разделами, добавляйте миниатюры и переходы в презентациях PPT, PPTX и ODP."
---

## **Обзор**
Zoom‑ы в PowerPoint позволяют переходить к определённым слайдам, разделам и частям презентации и обратно. При демонстрации эта возможность быстро перемещаться по содержимому может оказаться очень полезной. 

![overview](overview.png)

* Чтобы суммировать всю презентацию на одном слайде, используйте [Summary Zoom](#Summary-Zoom).
* Чтобы показывать только выбранные слайды, используйте [Slide Zoom](#Slide-Zoom).
* Чтобы показывать только один раздел, используйте [Section Zoom](#Section-Zoom).

## **Zoom слайда**

Zoom слайда может сделать вашу презентацию более динамичной, позволяя свободно перемещаться между слайдами в любом порядке без прерывания хода презентации. Zoom‑ы слайда отлично подходят для коротких презентаций без большого количества разделов, но их можно использовать и в других сценариях.

Zoom‑ы слайда помогают сосредоточиться на нескольких кусках информации, будто вы работаете на едином холсте. 

![slidezoomsel](slidezoomsel.png)

Для объектов Zoom слайда Aspose.Slides предоставляет перечисление [ZoomImageType](https://reference.aspose.com/slides/python-net/aspose.slides/zoomimagetype/), класс [ZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/zoomframe/) и некоторые методы в классе [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).

### **Создание рамок Zoom**
Вы можете добавить рамку Zoom на слайд следующим образом:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.  
2.	Create new slides to which you intend to link.  
3.	Add an identification text and background to the created slides.  
4.	Add zoom frames (containing the references to created slides) into the first slide.  
5.	Write the modified presentation as a PPTX file.

Этот пример кода показывает, как создать рамку Zoom на слайде:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Добавьте новые слайды в презентацию
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Создайте фон для второго слайда
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Создайте текстовое поле для второго слайда
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Создайте фон для третьего слайда
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Создайте текстовое поле для третьего слайда
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #Добавьте объекты ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Сохраните презентацию
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```

### **Создание рамок Zoom с пользовательскими изображениями**
С помощью Aspose.Slides for Python via .NET вы можете создать рамку Zoom с изображением, отличным от изображения‑превью слайда, следующим образом: 
1.	Create an instance of the `Presentation` class.  
2.	Create a new slide to which you intend to link.  
3.	Add an identification text and background to created slide.  
4.	Create a [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) object by adding an image to the Images collection associated with the Presentation object that will be used to fill the frame.  
5.	Add zoom frames (containing the reference to created slide) into the first slide.  
6.	Write the modified presentation as a PPTX file.

Этот python‑код показывает, как создать рамку Zoom с другим изображением:
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Добавьте новый слайд в презентацию
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Создайте фон для второго слайда
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Создайте текстовое поле для третьего слайда
    autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Создайте новое изображение для объекта Zoom
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    #Добавьте объект ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    # Сохраните презентацию
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **Форматирование рамок Zoom**
В предыдущих разделах (выше) мы показали, как создавать простые рамки Zoom. Чтобы создать более сложные рамки, необходимо изменить их форматирование. Существует несколько параметров форматирования, которые можно применить к рамке Zoom. 

Вы можете управлять форматированием рамки Zoom на слайде следующим способом:

1.	Create an instance of the `Presentation` class.  
2.	Create new slides to link to.  
3.	Add identification text and background to created slides.  
4.	Add zoom frames (containing the references to created slides) into the first slide.  
5.	Create a [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) object by adding an image to the Images collection associated with the Presentation object that will be used to fill the frame.  
6.	Set a custom image for the first zoom frame object.  
7.	Change the line format for the second zoom frame object.  
8.	Remove the background from an image of the second zoom frame object.  
5.	Write the modified presentation as a PPTX file.

Этот python‑пример кода показывает, как изменить форматирование рамки Zoom: 
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Добавьте новые слайды в презентацию
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Создайте фон для второго слайда
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Создайте текстовое поле для второго слайда
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Создайте фон для третьего слайда
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Создайте текстовое поле для третьего слайда
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #Добавьте объекты ZoomFrame
    zoomFrame1 = pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    zoomFrame2 = pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Создайте новое изображение для объекта zoom
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    # Установите пользовательское изображение для объекта zoomFrame1
    zoomFrame1.image = image

    # Установите формат Zoom-рамки для объекта zoomFrame2
    zoomFrame2.line_format.width = 5
    zoomFrame2.line_format.fill_format.fill_type = slides.FillType.SOLID
    zoomFrame2.line_format.fill_format.solid_fill_color.color = draw.Color.hot_pink
    zoomFrame2.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    # Не показывать фон для объекта zoomFrame2
    zoomFrame2.show_background = False

    # Сохраните презентацию
    pres.save("presentation-zoom2.pptx", slides.export.SaveFormat.PPTX)
```


## **Zoom раздела**

Zoom раздела — это ссылка на раздел вашей презентации. Вы можете использовать Zoom‑ы разделов, чтобы возвращаться к разделам, которые хотите особенно подчеркнуть, либо чтобы показать, как отдельные части презентации связаны между собой. 

![seczoomsel](seczoomsel.png)

Для объектов Zoom раздела Aspose.Slides предоставляет класс [SectionZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/sectionzoomframe/) и некоторые методы в классе [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).

### **Создание рамок Zoom раздела**

Вы можете добавить рамку Zoom раздела на слайд следующим образом:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.  
2.	Create a new slide.  
3.	Add an identification background to the created slide.  
4.	Create a new section to which you intend to link the zoom frame.  
5.	Add a section zoom frame (containing references to the created section) to the first slide.  
6.	Write the modified presentation as a PPTX file.

Этот python‑код показывает, как создать рамку Zoom на слайде:
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


### **Создание рамок Zoom раздела с пользовательскими изображениями**

С помощью Aspose.Slides for Python вы можете создать рамку Zoom раздела с другим изображением‑превью слайда следующим способом: 

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.  
2.	Create a new slide.  
3.	Add an identification background to created slide.  
4.	Create a new section to which you intend to link the zoom frame.  
5.	Create a [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) object by adding an image to the Images collection associated with the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) object that will be used to fill the frame.  
6.	Add a section zoom frame (containing a reference to the created section) to the first slide.  
7.	Write the modified presentation as a PPTX file.

Этот python‑код показывает, как создать рамку Zoom с другим изображением:
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

    # Создаёт новое изображение для объекта zoom
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    # Добавляет объект SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1], image)

    # Сохраняет презентацию
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **Форматирование рамок Zoom раздела**

Чтобы создать более сложные рамки Zoom раздела, необходимо изменить форматирование простой рамки. Существует несколько параметров форматирования, которые можно применить к рамке Zoom раздела. 

Вы можете управлять форматированием рамки Zoom раздела на слайде следующим способом:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.  
2.	Create a new slide.  
3.	Add identification background to created slide.  
4.	Create a new section to which you intend to link the zoom frame.  
5.	Add a section zoom frame (containing references to created section) to the first slide.  
6.	Change the size and position for the created section zoom object.  
7.	Create a [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) object by adding an image to the Images collection associated with the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) object that will be used to fill the frame.  
8.	Set a custom image for the created section zoom frame object.  
9.	Set the *return to the original slide from the linked section* ability.  
10.	Remove the background from an image of the section zoom frame object.  
11.	Change the line format for the second zoom frame object.  
12.	Change the transition duration.  
13.	Write the modified presentation as a PPTX file.

Этот python‑код показывает, как изменить форматирование рамки Zoom раздела:
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

    # Добавляет объект SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Форматирование SectionZoomFrame
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


## **Обзорный Zoom**

Обзорный Zoom — это своего рода стартовая страница, где одновременно отображаются все части вашей презентации. Во время демонстрации вы можете использовать Zoom, чтобы переходить от одной части к другой в любом порядке. Можно проявлять креативность, перемещаться вперёд или возвращаться к предыдущим частям слайд‑шоу без прерывания потока презентации.

![overview_image](summaryzoom.png)

Для объектов обзорного Zoom Aspose.Slides предоставляет классы [SummaryZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsection/), [SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsectioncollection/) и некоторые методы в классе [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).

### **Создание обзорного Zoom**

Вы можете добавить рамку обзорного Zoom на слайд следующим образом:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.  
2.	Create new slides with identification background and new sections for created slides.  
3.	Add the summary zoom frame to the first slide.  
4.	Write the modified presentation as a PPTX file.

Этот python‑код показывает, как создать рамку обзорного Zoom на слайде:
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # Создать массив слайдов
    for slideNumber in range(5):
        #Добавить новые слайды в презентацию
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


### **Добавление и удаление разделов обзорного Zoom**

Все разделы в рамке обзорного Zoom представлены объектами [SummaryZoomSection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsection/), которые хранятся в объекте [SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsectioncollection/). Вы можете добавить или удалить объект раздела через класс [SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsectioncollection/) следующим способом:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.  
2.	Create new slides with identification background and new sections for created slides.  
3.	Add a summary zoom frame into the first slide.  
4.	Add a new slide and section to the presentation.  
5.	Add the created section to the summary zoom frame.  
6.	Remove the first section from the summary zoom frame.  
7.	Write the modified presentation as a PPTX file.

Этот python‑код показывает, как добавить и удалить разделы в рамке обзорного Zoom:
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


### **Форматирование разделов обзорного Zoom**

Чтобы создать более сложные объекты разделов обзорного Zoom, необходимо изменить форматирование простой рамки. Существует несколько параметров форматирования, которые можно применить к объекту раздела обзорного Zoom. 

Вы можете управлять форматированием объекта раздела обзорного Zoom в рамке обзорного Zoom следующим способом:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.  
2.	Create new slides with identification background and new sections for created slides.  
3.	Add a summary zoom frame to the first slide.  
4.	Get a summary zoom section object for the first object from the `SummaryZoomSectionCollection`.  
5.	Create a `PPImage` object by adding an image to the images collection associated with the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) object that will be used to fill the frame.  
6.	Set a custom image for the created section zoom frame object.  
7.	Set the *return to the original slide from the linked section* ability.  
8.	Change the line format for the second zoom frame object.  
9.	Change the transition duration.  
10.	Write the modified presentation as a PPTX file.

Этот python‑код показывает, как изменить форматирование объекта раздела обзорного Zoom:
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

**Можно ли контролировать возврат к «родительскому» слайду после показа цели?**

Да. У [Zoom‑рамки](https://reference.aspose.com/slides/python-net/aspose.slides/zoomframe/) или [раздела](https://reference.aspose.com/slides/python-net/aspose.slides/sectionzoomframe/) есть поведение `return_to_parent`, которое при включении отправляет зрителя обратно на исходный слайд после посещения целевого содержимого.

**Можно ли настроить «скорость» или продолжительность перехода Zoom?**

Да. Zoom поддерживает настройку `transition_duration`, позволяя управлять длительностью анимации прыжка.

**Есть ли ограничения на количество объектов Zoom в презентации?**

Жёсткого ограничения API нет. Практические ограничения зависят от общей сложности презентации и производительности устройства просмотра. Можно добавлять множество Zoom‑рамок, но следует учитывать размер файла и время рендеринга.