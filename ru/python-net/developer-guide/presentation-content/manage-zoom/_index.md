---
title: Управление Zoom
type: docs
weight: 60
url: /python-net/manage-zoom/
keywords: "Zoom, Zoom фрейм, Добавить зум, Форматировать рамку зума, Сводка зума, Презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Добавьте зум или зум рамки к презентациям PowerPoint на Python"
---

## **Обзор**
Зумы в PowerPoint позволяют вам быстро переходить к конкретным слайдам, разделам и частям презентации. Когда вы представляете, эта способность быстро перемещаться по содержимому может оказаться очень полезной.

![overview](overview.png)

* Чтобы суммировать всю презентацию на одном слайде, используйте [Сводку зума](#Summary-Zoom).
* Чтобы показать только выбранные слайды, используйте [Зум слайдов](#Slide-Zoom).
* Чтобы показать только один раздел, используйте [Зум раздела](#Section-Zoom).

## **Зум слайдов**

Зум слайдов может сделать вашу презентацию более динамичной, позволяя вам свободно перемещаться между слайдами в любом порядке, который вы выберете, не прерывая поток вашей презентации. Зумы слайдов прекрасно подходят для коротких презентаций без множества разделов, но вы все равно можете использовать их в различных сценариях презентации.

Зумы слайдов помогают вам углубиться в несколько частей информации, когда вы чувствуете, что находитесь на одном холсте.

![slidezoomsel](slidezoomsel.png)

Для объектов зума слайдов Aspose.Slides предоставляет перечисление [ZoomImageType](https://reference.aspose.com/slides/python-net/aspose.slides/zoomimagetype/), интерфейс [IZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/izoomframe/) и некоторые методы в интерфейсе [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).

### **Создание зум рамок**
Вы можете добавить зум рамку на слайде следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Создайте новые слайды, к которым вы намереваетесь подключить.
3. Добавьте идентификационный текст и фон к созданным слайдам.
4. Добавьте зум рамки (ссылающиеся на созданные слайды) на первый слайд.
5. Запишите измененную презентацию в файл PPTX.

Этот пример кода показывает, как создать зум рамку на слайде:
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Добавить новые слайды к презентации
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Создайте фон для второго слайда
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Создайте текстовое поле для второго слайда
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Второй слайд"

    # Создайте фон для третьего слайда
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Создайте текстовое поле для третьего слайда
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Третий слайд"

    #Добавьте объекты ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Сохраните презентацию
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```
### **Создание зум рамок с пользовательскими изображениями**
С помощью Aspose.Slides для Python через .NET вы можете создать зум рамку с изображением, отличным от изображения предпросмотра слайда следующим образом: 
1. Создайте экземпляр класса `Presentation`.
2. Создайте новый слайд, к которому вы намереваетесь подключить. 
3. Добавьте идентификационный текст и фон к созданному слайду.
4. Создайте объект [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/), добавив изображение в коллекцию Images, связанную с объектом Presentation, которое будет использоваться для заполнения рамки.
5. Добавьте зум рамки (ссылающиеся на созданный слайд) на первый слайд.
6. Запишите измененную презентацию в файл PPTX.

Этот код python показывает, как создать зум рамку с другим изображением:

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Добавить новый слайд к презентации
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Создайте фон для второго слайда
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Создайте текстовое поле для третьего слайда
    autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Второй слайд"

    # Создайте новое изображение для объекта зума
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    #Добавьте объект ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    # Сохраните презентацию
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Форматирование зум рамок**
В предыдущих разделах (выше) мы показали вам, как создать простые зум рамки. Чтобы создать более сложные зум рамки, вам нужно изменить форматирование рамок. Существует несколько настроек форматирования, которые вы можете применить к зум рамке. 

Вы можете контролировать форматирование зум рамки на слайде следующим образом:

1. Создайте экземпляр класса `Presentation`.
2. Создайте новые слайды для связывания.
3. Добавьте идентификационный текст и фон к созданным слайдам.
4. Добавьте зум рамки (ссылающиеся на созданные слайды) на первый слайд.
5. Создайте объект [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/), добавив изображение в коллекцию Images, связанную с объектом Presentation, которое будет использоваться для заполнения рамки.
6. Установите пользовательское изображение для первого объекта зум рамки.
7. Измените формат линии для второго объекта зум рамки.
8. Удалите фон из изображения второго объекта зум рамки.
9. Запишите измененную презентацию в файл PPTX.

Этот пример кода python показывает, как изменить форматирование зум рамки: 

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Добавить новые слайды к презентации
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Создайте фон для второго слайда
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Создайте текстовое поле для второго слайда
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Второй слайд"

    # Создайте фон для третьего слайда
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Создайте текстовое поле для третьего слайда
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Третий слайд"

    #Добавьте объекты ZoomFrame
    zoomFrame1 = pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    zoomFrame2 = pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Создайте новое изображение для объекта зума
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    # Установите пользовательское изображение для объекта zoomFrame1
    zoomFrame1.image = image

    # Установите формат зум рамки для объекта zoomFrame2
    zoomFrame2.line_format.width = 5
    zoomFrame2.line_format.fill_format.fill_type = slides.FillType.SOLID
    zoomFrame2.line_format.fill_format.solid_fill_color.color = draw.Color.hot_pink
    zoomFrame2.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    # Не показывайте фон для объекта zoomFrame2
    zoomFrame2.show_background = False

    # Сохраните презентацию
    pres.save("presentation-zoom2.pptx", slides.export.SaveFormat.PPTX)
```

## **Зум раздела**

Зум раздела — это ссылка на раздел в вашей презентации. Вы можете использовать зумы разделов, чтобы вернуться к разделам, которые хотите сильно подчеркнуть. Или вы можете использовать их, чтобы подчеркнуть, как определенные части вашей презентации соединяются.

![seczoomsel](seczoomsel.png)

Для объектов зума раздела Aspose.Slides предоставляет интерфейс [ISectionZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/isectionzoomframe/) и некоторые методы в интерфейсе [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).

### **Создание рамок зум раздела**

Вы можете добавить зум рамку раздела на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Создайте новый слайд. 
3. Добавьте идентификационный фон к созданному слайду.
4. Создайте новый раздел, к которому вы намереваетесь подключить зум рамку. 
5. Добавьте зум рамку раздела (ссылающуюся на созданный раздел) на первый слайд.
6. Запишите измененную презентацию в файл PPTX.

Этот код python показывает, как создать зум рамку на слайде:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Добавляет новый слайд к презентации
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green

    # Добавляет новый раздел к презентации
    pres.sections.add_section("Раздел 1", slide)

    # Добавляет объект SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Сохраняет презентацию
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Создание рамок зум раздела с пользовательскими изображениями**

С использованием Aspose.Slides для Python вы можете создать рамку зума раздела с другим изображением предпросмотра слайда следующим образом: 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Создайте новый слайд.
3. Добавьте идентификационный фон к созданному слайду.
4. Создайте новый раздел, к которому вы намереваетесь подключить зум рамку. 
5. Создайте объект `IPPImage`, добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), которое будет использоваться для заполнения рамки.
6. Добавьте зум рамку раздела (ссылающуюся на созданный раздел) на первый слайд.
7. Запишите измененную презентацию в файл PPTX.

Этот код python показывает, как создать зум рамку с другим изображением:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Добавляет новый слайд к презентации
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green

    # Добавляет новый раздел к презентации
    pres.sections.add_section("Раздел 1", slide)

    # Создайте новое изображение для объекта зума
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    # Добавляет объект SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1], image)

    # Сохраняет презентацию
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Форматирование рамок зум раздела**

Чтобы создать более сложные рамки зум раздела, вам нужно изменить форматирование простой рамки. Есть несколько параметров форматирования, которые вы можете применить к зум рамке раздела. 

Вы можете контролировать форматирование зум рамки раздела на слайде следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Создайте новый слайд.
3. Добавьте идентификационный фон к созданному слайду.
4. Создайте новый раздел, к которому вы намереваетесь подключить зум рамку. 
5. Добавьте зум рамку раздела (ссылающуюся на созданный раздел) на первый слайд.
6. Измените размер и положение созданного объекта зума раздела.
7. Создайте объект `IPPImage`, добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), которое будет использоваться для заполнения рамки.
8. Установите пользовательское изображение для созданного объекта зум рамки.
9. Установите возможность *возврата к оригинальному слайду из связанного раздела*. 
10. Удалите фон из изображения объекта зум рамки раздела.
11. Измените формат линии для второго объекта зум рамки.
12. Измените длительность перехода.
13. Запишите измененную презентацию в файл PPTX.

Этот код python показывает, как изменить форматирование объекта зум рамки раздела:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Добавляет новый слайд к презентации
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Добавляет новый раздел к презентации
    pres.sections.add_section("Раздел 1", slide)

    # Добавление объекта SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Форматирование для SectionZoomFrame
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

## **Сводка зума**

Сводка зума — это как посадочная страница, где отображаются все части вашей презентации одновременно. Когда вы представляете, вы можете использовать зум, чтобы переходить из одного места в презентации в другое в любом порядке, который вам нравится. Вы можете проявить креативность, пропускать вперед или возвращаться к частям вашей презентации, не прерывая ее поток.

![overview_image](summaryzoom.png)

Для объектов сводки зума Aspose.Slides предоставляет интерфейсы [ISummaryZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomframe/), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsection/) и [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/) и некоторые методы в интерфейсе [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).

### **Создание сводки зума**

Вы можете добавить зум рамку сводки на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Создайте новые слайды с идентификационным фоном и новыми разделами для созданных слайдов.
3. Добавьте зум рамку сводки на первый слайд.
4. Запишите измененную презентацию в файл PPTX.

Этот код python показывает, как создать зум рамку сводки на слайде:

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # Создайте массив слайдов
    for slideNumber in range(5):
        #Добавить новые слайды к презентации
        slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

        # Создайте фон для слайда
        slide.background.type = slides.BackgroundType.OWN_BACKGROUND
        slide.background.fill_format.fill_type = slides.FillType.SOLID
        slide.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

        # Создайте текстовое поле для слайда
        autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
        autoshape.text_frame.text = "Слайд - {num}".format(num = (slideNumber + 2))

    # Создайте объекты зума для всех слайдов на первом слайде
    for slideNumber in range(1, len(pres.slides)):
        x = (slideNumber - 1) * 100
        y = (slideNumber - 1) * 100
        zoomFrame = pres.slides[0].shapes.add_zoom_frame(x, y, 150, 120, pres.slides[slideNumber])

        # Установите свойство ReturnToParent, чтобы вернуться на первый слайд
        zoomFrame.return_to_parent = True

    # Сохраните презентацию
    pres.save("presentation-zoom3.pptx", slides.export.SaveFormat.PPTX)
```

### **Добавление и удаление секции сводки зума**

Все разделы в рамке сводки зума представлены объектами [ISummaryZoomFrameSection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsection/), которые хранятся в объекте [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/). Вы можете добавлять или удалять объект секции сводки зума через интерфейс [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/) следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Создайте новые слайды с идентификационным фоном и новыми разделами для созданных слайдов.
3. Добавьте рамку зум сводки на первый слайд.
4. Добавьте новый слайд и раздел в презентацию.
5. Добавьте созданный раздел в рамку зум сводки.
6. Удалите первый раздел из рамки зум сводки.
7. Запишите измененную презентацию в файл PPTX.

Этот код python показывает, как добавлять и удалять секции в рамке зум сводки:

``` python
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Добавляет новый слайд к презентации
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Добавляет новый раздел к презентации
    pres.sections.add_section("Раздел 1", slide)

    #Добавляет новый слайд к презентации
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Добавляет новый раздел к презентации
    pres.sections.add_section("Раздел 2", slide)

    # Добавляет объект SummaryZoomFrame
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    #Добавляет новый слайд к презентации
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.chartreuse
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Добавляет новый раздел к презентации
    section3 = pres.sections.add_section("Раздел 3", slide)

    # Добавляет секцию в зум сводки
    summaryZoomFrame.summary_zoom_collection.add_summary_zoom_section(section3)

    # Удаляет секцию из зума сводки
    summaryZoomFrame.summary_zoom_collection.remove_summary_zoom_section(pres.sections[1])

    # Сохраняет презентацию
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Форматирование секций сводки зума**

Чтобы создать более сложные объекты секции зума сводки, вам нужно изменить форматирование простой рамки. Есть несколько параметров форматирования, которые вы можете применить к объекту секции зума сводки. 

Вы можете контролировать форматирование для объекта секции зума сводки в рамке сводки зума следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Создайте новые слайды с идентификационным фоном и новыми разделами для созданных слайдов.
3. Добавьте рамку зум сводки на первый слайд.
4. Получите объект секции зума сводки для первого объекта из `ISummaryZoomSectionCollection`.
5. Создайте объект `IPPImage`, добавив изображение в коллекцию изображений, связанную с объектом  [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), которое будет использоваться для заполнения рамки.
6. Установите пользовательское изображение для созданного объекта секции зума сводки.
7. Установите возможность *возврата к оригинальному слайду из связанного раздела*. 
8. Измените формат линии для второго объекта зум рамки.
9. Измените длительность перехода.
10. Запишите измененную презентацию в файл PPTX.

Этот код python показывает, как изменить форматирование для объекта секции зума сводки:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Добавляет новый слайд к презентации
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.brown
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Добавляет новый раздел к презентации
    pres.sections.add_section("Раздел 1", slide)

    #Добавляет новый слайд к презентации
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Добавляет новый раздел к презентации
    pres.sections.add_section("Раздел 2", slide)

    # Добавляет объект SummaryZoomFrame
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    # Получает первый объект SummaryZoomSection
    summarySection = summaryZoomFrame.summary_zoom_collection[0]

    # Форматирование для объекта SummaryZoomSection
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