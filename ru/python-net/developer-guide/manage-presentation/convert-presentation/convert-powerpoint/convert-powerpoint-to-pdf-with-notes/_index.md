---
title: Конвертируйте презентации в PDF с заметками на Python
linktitle: Презентация в PDF с заметками
type: docs
weight: 50
url: /ru/python-net/convert-powerpoint-to-pdf-with-notes/
keywords:
- конвертировать PowerPoint
- конвертировать OpenDocument
- конвертировать презентацию
- конвертировать PPT
- конвертировать PPTX
- конвертировать ODP
- PowerPoint в PDF
- OpenDocument в PDF
- презентация в PDF
- PPT в PDF
- PPTX в PDF
- ODP в PDF
- заметки докладчика
- PDF с заметками
- Python
- Aspose.Slides
description: "Конвертируйте форматы PPT, PPTX и ODP в PDF с заметками с помощью Aspose.Slides для Python. Сохраняйте макеты и заметки докладчика для профессиональных презентаций."
---

Метод [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) класса Presentation можно использовать для конвертации презентации PowerPoint PPT или PPTX в PDF с заметками. Сохранение презентации Microsoft PowerPoint в PDF с заметками с помощью Aspose.Slides для Python через .NET — это процесс из двух строк. Вы просто открываете презентацию и сохраняете её в формате PDF с заметками. Ниже приведены фрагменты кода, которые обновляют пример презентации в формате PDF в режиме заметок:

```py
import aspose.slides as slides

# Создаем объект Presentation, представляющий файл презентации 
presentation = slides.Presentation("SelectedSlides.pptx")
auxPresentation = slides.Presentation()

slide = presentation.slides[0]

auxPresentation.slides.insert_clone(0, slide)

# Установка типа и размера слайда 
auxPresentation.slide_size.set_size(612, 792, slides.SlideSizeScaleType.ENSURE_FIT)

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

auxPresentation.save("PDFnotes_out.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

{{% alert color="primary" %}} 

Вам может быть интересно ознакомиться с конвертером Aspose [PowerPoint в PDF](https://products.aspose.app/slides/conversion) или [PPT в PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf). 

{{% /alert %}}