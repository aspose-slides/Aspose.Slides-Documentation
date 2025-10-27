---
title: Управление гиперссылками в презентациях с помощью Python
linktitle: Управление гиперссылкой
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
- гиперссылка в тексте
- гиперссылка на слайд
- гиперссылка на фигуру
- гиперссылка на изображение
- гиперссылка на видео
- изменяемая гиперссылка
- PowerPoint
- OpenDocument
- презентация
- Python
description: "Легко управляйте гиперссылками в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET — улучшайте интерактивность и рабочий процесс за считанные минуты."
---

## **Обзор**

Гиперссылка — это ссылка на внешний ресурс, объект или элемент данных, либо конкретное место внутри файла. Распространённые типы гиперссылок в презентациях PowerPoint включают:

* Ссылки на веб‑сайты, встроенные в текст, фигуры или медиа
* Ссылки на слайды

Aspose.Slides for Python via .NET предоставляет широкий спектр операций, связанных с гиперссылками, в презентациях.

## **Добавление URL‑гиперссылок**

Этот раздел объясняет, как добавить URL‑гиперссылки к элементам слайдов при работе с Aspose.Slides. Он охватывает назначение адресов ссылок тексту, фигурам и изображениям для обеспечения плавной навигации во время презентаций.

### **Добавление URL‑гиперссылок к тексту**

Следующий пример кода показывает, как добавить гиперссылку на веб‑сайт в текст:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")
    
    text_portion = shape.text_frame.paragraphs[0].portions[0]

    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Добавление URL‑гиперссылок к фигурам или фреймам**

Следующий пример кода показывает, как добавить гиперссылку на веб‑сайт к фигуре:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)

    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Добавление URL‑гиперссылок к медиа**

Aspose.Slides позволяет добавлять гиперссылки к изображениям, аудио‑ и видеофайлам.

Следующий пример кода показывает, как добавить гиперссылку к **изображению**:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add an image to the presentation.
    with open("image.jpeg", "rb") as image_stream:
        image_data = image_stream.read()
        image = presentation.images.add_image(image_data)

    # Create a picture frame on slide 1 using the image added earlier.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    picture_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    picture_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Следующий пример кода показывает, как добавить гиперссылку к **аудиофайлу**:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()
        audio = presentation.audios.add_audio(audio_data)
        
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 100, 100, audio)

    audio_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    audio_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Следующий пример кода показывает, как добавить гиперссылку к **видео**:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.avi", "rb") as video_stream:
        video_data = video_stream.read()
        video = presentation.videos.add_video(video_data)
        
    video_frame = slide.shapes.add_video_frame(10, 10, 100, 100, video)

    video_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    video_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Подсказка" color="primary" %}}
Возможно, вам будет интересно посмотреть [Управление OLE в презентациях с использованием Python](/slides/ru/python-net/manage-ole/).
{{% /alert %}}

## **Использование гиперссылок для создания оглавления**

Поскольку гиперссылки позволяют ссылаться на объекты или места, их можно использовать для создания оглавления.

Ниже приведён пример кода, показывающий, как создать оглавление с гиперссылками:

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
    paragraph.text = "Title of slide 2 .......... "

    link_text_portion = slides.Portion()
    link_text_portion.text = "Page 2"
    link_text_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)

    paragraph.portions.add(link_text_portion)
    content_table.text_frame.paragraphs.add(paragraph)

    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **Форматирование гиперссылок**

В этом разделе показано, как оформить внешний вид гиперссылок в Aspose.Slides. Вы узнаете, как управлять цветом и другими параметрами стиля, чтобы обеспечить единообразное форматирование гиперссылок в тексте, фигурах и изображениях.

### **Цвет гиперссылки**

С помощью свойства [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) класса [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) можно задавать цвет гиперссылки и считывать информацию о её цвете. Эта возможность была введена в PowerPoint 2019, поэтому изменения, внесённые через это свойство, не применяются к более ранним версиям PowerPoint.

Следующий пример демонстрирует, как добавить гиперссылки с разными цветами на один слайд:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("This is a sample of a colored hyperlink.")

    text_portion1 = shape1.text_frame.paragraphs[0].portions[0]
    text_portion1.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion1.portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    text_portion1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_portion1.portion_format.fill_format.solid_fill_color.color = draw.Color.red

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    shape2.add_text_frame("This is a sample of a regular hyperlink.")

    text_portion2 = shape2.text_frame.paragraphs[0].portions[0]
    text_portion2.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")

    presentation.save("hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **Удаление гиперссылок из презентаций**

В этом разделе объясняется, как удалять гиперссылки из презентаций при работе с Aspose.Slides. Вы узнаете, как очищать цели ссылок в тексте, фигурах и изображениях, сохраняя оригинальное содержание и форматирование.

### **Удаление гиперссылок из текста**

Следующий пример кода показывает, как удалить гиперссылки из текста на слайде презентации:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if type(shape) is slides.AutoShape:
            for paragraph in shape.text_frame.paragraphs:
                for text_portion in paragraph.portions:
                    text_portion.portion_format.hyperlink_manager.remove_hyperlink_click()

    presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

### **Удаление гиперссылок из фигур или фреймов**

Следующий пример кода показывает, как удалить гиперсылки из фигур на слайде презентации: 

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   slide = presentation.slides[0]

   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()

   presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **Изменяемые гиперссылки**

Класс [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) является изменяемым. С помощью этого класса можно изменять значения следующих свойств:

- [target_frame](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_frame/)
- [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/)
- [history](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/history/)
- [highlight_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/highlight_click/)
- [stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/)

Следующий фрагмент кода показывает, как добавить гиперссылку на слайд и затем изменить её всплывающую подсказку:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")

    text_portion = shape.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Поддерживаемые свойства в IHyperlinkQueries**

Вы можете получить доступ к [HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) из презентации, слайда или текста, содержащего гиперссылку.

- [Presentation.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/hyperlink_queries/)
- [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/hyperlink_queries/)
- [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/)

Класс [HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) поддерживает следующие методы: 

- [get_hyperlink_clicks()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/)
- [get_hyperlink_mouse_overs()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/)
- [get_any_hyperlinks()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/)
- [remove_all_hyperlinks()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/)

{{% alert color="primary" %}}
Возможно, вам будет интересно ознакомиться с простым бесплатным онлайн‑редактором PowerPoint от Aspose — [Редактор PowerPoint](https://products.aspose.app/slides/editor).
{{% /alert %}}

## **Вопросы и ответы**

**Как я могу создать внутреннюю навигацию не только к слайду, но и к «разделу» или первому слайду раздела?**

Разделы в PowerPoint представляют собой группы слайдов; навигация технически направлена на конкретный слайд. Чтобы «перейти к разделу», обычно связывают его с первым слайдом.

**Могу ли я привязать гиперссылку к элементам слайда-шаблона, чтобы она работала на всех слайдах?**

Да. Элементы слайда-шаблона и макета поддерживают гиперссылки. Такие ссылки отображаются на дочерних слайдах и кликабельны во время показа.

**Сохранятся ли гиперссылки при экспорте в PDF, HTML, изображения или видео?**

В [PDF](/slides/ru/python-net/convert-powerpoint-to-pdf/) и [HTML](/slides/ru/python-net/convert-powerpoint-to-html/) — да, ссылки, как правило, сохраняются. При экспорте в [изображения](/slides/ru/python-net/convert-powerpoint-to-png/) и [видео](/slides/ru/python-net/convert-powerpoint-to-video/) кликабельность не сохраняется из‑за характера этих форматов (растровые кадры/видео не поддерживают гиперссылки).