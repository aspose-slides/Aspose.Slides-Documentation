---
title: Конвертируйте презентаций PowerPoint в документы Word на Python
linktitle: PowerPoint в Word
type: docs
weight: 110
url: /ru/python-net/convert-powerpoint-to-word/
keywords:
- PowerPoint в DOCX
- OpenDocument в DOCX
- презентация в DOCX
- слайд в DOCX
- PPT в DOCX
- PPTX в DOCX
- ODP в DOCX
- PowerPoint в DOC
- OpenDocument в DOC
- презентация в DOC
- слайд в DOC
- PPT в DOC
- PPTX в DOC
- ODP в DOC
- PowerPoint в Word
- OpenDocument в Word
- презентация в Word
- слайд в Word
- PPT в Word
- PPTX в Word
- ODP в Word
- конвертация PowerPoint
- конвертация OpenDocument
- конвертация презентации
- конвертация слайда
- конвертация PPT
- конвертация PPTX
- конвертация ODP
- Python
- Aspose.Slides
description: "Узнайте, как без усилий конвертировать презентации PowerPoint и OpenDocument в документы Word с помощью Aspose.Slides for Python via .NET. Наш пошаговый гид с примером кода на Python предоставляет решение для разработчиков, стремящихся оптимизировать рабочие процессы с документами."
---

Если вы планируете использовать текстовое содержание или информацию из презентации (PPT или PPTX) новыми способами, вам может быть полезна конвертация презентации в Word (DOC или DOCX).

* В отличие от Microsoft PowerPoint, приложение Microsoft Word предоставляет больше возможности для работы с содержимым.
* Кроме функций редактирования в Word, вы также можете получить выгоду от улучшенного сотрудничества, печати и функций обмена.

{{% alert color="primary" %}}

Вы можете попробовать наш [**Онлайн-конвертер презентаций в Word**](https://products.aspose.app/slides/conversion/ppt-to-word), чтобы увидеть, что вы можете получить, работая с текстовым содержимым слайдов.

{{% /alert %}}

## **Aspose.Slides и Aspose.Words**

Чтобы конвертировать файл PowerPoint (PPTX или PPT) в Word (DOCX или DOC), вам нужны как [Aspose.Slides для Python через .NET](https://products.aspose.com/slides/python-net/), так и [Aspose.Words для Python через .NET](https://products.aspose.com/words/python-net/).

Как отдельный API, [Aspose.Slides](https://products.aspose.com/slides/python-net/) для Python через .NET предоставляет функции, которые позволяют извлекать тексты из презентаций.

[Aspose.Words](https://products.aspose.com/words/python-net/) — это продвинутый API для обработки документов, который позволяет приложениям создавать, изменять, конвертировать, визуализировать, печатать файлы и выполнять другие задачи с документами без использования Microsoft Word.

## **Конвертация PowerPoint в Word на Python**

1. Добавьте эти пространства имен в ваш файл program.py:

```py
import aspose.slides as slides
import aspose.words as words
```

2. Используйте этот фрагмент кода, чтобы конвертировать PowerPoint в Word:

```py
presentation = slides.Presentation("pres.pptx")
doc = words.Document()
builder = words.DocumentBuilder(doc)

for index in range(presentation.slides.length):
    slide = presentation.slides[index]
    # генерирует и вставляет изображение слайда
    with slide.get_image(2, 2) as image:
        image.save("slide_{i}.png".format(i = index), slides.ImageFormat.PNG)

    builder.insert_image("slide_{i}.png".format(i = index))
    
    for shape in slide.shapes:
        # вставляет тексты слайда
        if (type(shape) is slides.AutoShape):
            builder.writeln(shape.text_frame.text)
   
    builder.insert_break(words.BreakType.PAGE_BREAK)

doc.save("presentation.docx")
```