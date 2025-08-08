---
title: Управляйте гиперссылками в презентациях на Python
linktitle: Управление гиперссылками
type: docs
weight: 20
url: /ru/python-net/manage-hyperlinks/
keywords:
- добавить URL
- добавить гиперссылку
- создать гиперссылку
- форматировать гиперссылку
- удалить гиперссылку
- обновить гиперссылку
- текстовая гиперссылка
- гиперссылка на слайд
- гиперссылка на фигуру
- гиперссылка на изображение
- гиперссылка на видео
- изменяемая гиперссылка
- PowerPoint
- OpenDocument
- презентация
- Python
description: "Легко управляйте гиперссылками в презентациях PowerPoint и OpenDocument с Aspose.Slides for Python via .NET — повышайте интерактивность и ускоряйте рабочие процессы за считанные минуты."
---

Гиперссылка — это ссылка на объект или данные или место в чем-то. Вот распространенные гиперссылки в презентациях PowerPoint:

* Ссылки на веб-сайты внутри текстов, фигур или медиа
* Ссылки на слайды

Aspose.Slides для Python через .NET позволяет выполнять множество задач, связанных с гиперссылками в презентациях.

{{% alert color="primary" %}} 

Вы можете ознакомиться с простым, [бесплатным онлайн-редактором PowerPoint от Aspose.](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Добавление гиперссылок URL**

### **Добавление гиперссылок URL к текстам**

Этот код на Python показывает, как добавить гиперссылку на веб-сайт к тексту:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape1 = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("Aspose: API для работы с форматами файлов")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click.tooltip = "Более 70% компаний из списка Fortune 100 доверяют API Aspose"
    shape1.text_frame.paragraphs[0].portions[0].portion_format.font_height = 32
    
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

### **Добавление гиперссылок URL к фигурам или рамкам**

Этот пример кода на Python показывает, как добавить гиперссылку на веб-сайт к фигуре:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Более 70% компаний из списка Fortune 100 доверяют API Aspose"

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

### **Добавление гиперссылка URL к медиа**

Aspose.Slides позволяет добавлять гиперссылки к изображениям, аудио и видеофайлам.

Этот пример кода показывает, как добавить гиперссылку к **изображению**:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    # Добавление изображения в презентацию
    with open("img.jpeg", "rb") as fs:
        data = fs.read()
        image = pres.images.add_image(data)
        
        # Создание рамки для изображения на слайде 1 на основе ранее добавленного изображения
        pictureFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

        pictureFrame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
        pictureFrame.hyperlink_click.tooltip = "Более 70% компаний из списка Fortune 100 доверяют API Aspose"

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

Этот пример кода показывает, как добавить гиперссылку к **аудиофайлу**:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    with open("audio.mp3", "rb") as fs:
        data = fs.read()
        audio = pres.audios.add_audio(data)
        
        audioFrame = pres.slides[0].shapes.add_audio_frame_embedded(10, 10, 100, 100, audio)

        audioFrame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
        audioFrame.hyperlink_click.tooltip = "Более 70% компаний из списка Fortune 100 доверяют API Aspose"

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

Этот пример кода показывает, как добавить гиперссылку к **видео**:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    with open("video.avi", "rb") as fs:
        data = fs.read()
        video = pres.videos.add_video(data)
        
        videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 100, 100, video)

        videoFrame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
        videoFrame.hyperlink_click.tooltip = "Более 70% компаний из списка Fortune 100 доверяют API Aspose"

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert  title="Совет"  color="primary"  %}} 

Вы можете ознакомиться с *[Управление OLE](https://docs.aspose.com/slides/python-net/manage-ole/)*.

{{% /alert %}}

## **Использование гиперссылок для создания оглавления**

Поскольку гиперссылки позволяют добавлять ссылки на объекты или места, вы можете использовать их для создания оглавления.

Этот пример кода показывает, как создать оглавление с гиперссылками:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)

    content_table = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    content_table.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Заголовок слайда 2 .......... "

    linkPortion = slides.Portion()
    linkPortion.text = "Страница 2"
    linkPortion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)

    paragraph.portions.add(linkPortion)
    content_table.text_frame.paragraphs.add(paragraph)

    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **Форматирование гиперссылок**

### **Цвет**

С помощью свойства [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/) интерфейса [IHyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/) вы можете установить цвет для гиперссылок, а также получить информацию о цвете из гиперссылок. Эта функция была впервые введена в PowerPoint 2019, поэтому изменения, связанные с этим свойством, не применяются к более ранним версиям PowerPoint.

Этот пример кода демонстрирует операцию, при которой гиперссылки с разными цветами добавляются на один и тот же слайд:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape1 = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("Это пример цветной гиперссылки.")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    shape1.text_frame.paragraphs[0].portions[0].portion_format.fill_format.fill_type = slides.FillType.SOLID
    shape1.text_frame.paragraphs[0].portions[0].portion_format.fill_format.solid_fill_color.color = draw.Color.red

    shape2 = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    shape2.add_text_frame("Это пример обычной гиперссылки.")
    shape2.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")

    presentation.save("presentation-out-hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **Удаление гиперссылок в презентациях**

### **Удаление гиперссылок из текстов**

Этот код на Python показывает, как удалить гиперссылку из текста на слайде презентации:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    for shape in slide.shapes:
        if type(shape) is slides.AutoShape:
            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    portion.portion_format.hyperlink_manager.remove_hyperlink_click()
    pres.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

### **Удаление гиперсылок из фигур или рамок**

Этот код на Python показывает, как удалить гиперссылку из фигуры на слайде презентации: 

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as pres:
   slide = pres.slides[0]
   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()
   pres.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **Изменяемая гиперссылка**

Класс [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink) является изменяемым. С помощью этого класса вы можете изменять значения для следующих свойств:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)
- [IHyperlink.History](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)

В приведенном ниже коде показано, как добавить гиперссылку на слайд и позже изменить ее подсказку:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape1 = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("Aspose: API для работы с форматами файлов")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click.tooltip = "Более 70% компаний из списка Fortune 100 доверяют API Aspose"
    shape1.text_frame.paragraphs[0].portions[0].portion_format.font_height = 32

    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Поддерживаемые свойства в IHyperlinkQueries**

Вы можете получить доступ к IHyperlinkQueries из презентации, слайда или текста, для которых определена гиперссылка.

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/)

Класс IHyperlinkQueries поддерживает следующие методы и свойства: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkqueries/)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkqueries/)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkqueries/)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkqueries/)
