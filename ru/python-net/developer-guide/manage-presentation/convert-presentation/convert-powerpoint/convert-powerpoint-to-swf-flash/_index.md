---
title: Конвертировать презентации PowerPoint в SWF Flash на Python
linktitle: PowerPoint в SWF Flash
type: docs
weight: 80
url: /ru/python-net/convert-powerpoint-to-swf-flash/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- PowerPoint в SWF
- презентация в SWF
- слайд в SWF
- PPT в SWF
- PPTX в SWF
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Конвертировать PowerPoint (PPT/PPTX) в SWF Flash на Python с помощью Aspose.Slides. Пошаговые примеры кода, быстрое качественное вывод, без автоматизации PowerPoint."
---

## **Конвертировать презентации в Flash**

Метод [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) можно использовать для преобразования всей презентации в документ SWF. Вы также можете включить комментарии в генерируемый SWF, используя класс [SWFOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) и класс [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/). Следующий пример показывает, как конвертировать презентацию в документ SWF, используя параметры, предоставленные классом SWFOptions.
```py
import aspose.slides as slides

# Создать объект Presentation, который представляет файл презентации
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Сохранение презентации и страниц заметок
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```


## **Часто задаваемые вопросы**

**Могу ли я включить скрытые слайды в SWF?**

Да. Включите параметр [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/show_hidden_slides/) в [SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/). По умолчанию скрытые слайды не экспортируются.

**Как я могу управлять сжатием и конечным размером SWF?**

Используйте флаг [compressed](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/compressed/) (включён по умолчанию) и настройте [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/jpeg_quality/), чтобы сбалансировать размер файла и качество изображения.

**Для чего предназначен 'viewer_included' и когда его следует отключить?**

[viewer_included](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/viewer_included/) добавляет встроенный пользовательский интерфейс плеера (элементы навигации, панели, поиск). Отключите его, если планируете использовать собственный плеер или вам нужен чистый кадр SWF без интерфейса.

**Что происходит, если исходный шрифт отсутствует на машине экспорта?**

Aspose.Slides заменит шрифт, указанный через [default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/default_regular_font/) в [SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/), чтобы избежать непреднамеренного fallback.