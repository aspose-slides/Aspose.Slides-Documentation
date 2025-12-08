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
description: "Конвертировать PowerPoint (PPT/PPTX) в SWF Flash на Python с Aspose.Slides. Пошаговые примеры кода, быстрый качественный вывод, без автоматизации PowerPoint."
---

## **Конвертировать презентации в Flash**

Метод [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) можно использовать для преобразования всей презентации в документ SWF. Вы также можете включать комментарии в генерируемый SWF, используя класс [SWFOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) и интерфейс [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/). Следующий пример показывает, как конвертировать презентацию в документ SWF с помощью параметров, предоставляемых классом SWFOptions.
```py
import aspose.slides as slides

# Создать объект Presentation, представляющий файл презентации
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Сохранить презентацию и страницы заметок
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```


## **FAQ**

**Могу ли я включить скрытые слайды в SWF?**

Да. Включите параметр [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/show_hidden_slides/) в [SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/). По умолчанию скрытые слайды не экспортируются.

**Как я могу контролировать сжатие и конечный размер SWF?**

Используйте флаг [compressed](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/compressed/) (по умолчанию включён) и настройте [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/jpeg_quality/), чтобы сбалансировать размер файла и качество изображения.

**Для чего нужен 'viewer_included' и когда его следует отключать?**

[viewer_included](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/viewer_included/) добавляет встроенный пользовательский интерфейс проигрывателя (элементы навигации, панели, поиск). Отключите его, если планируете использовать собственный проигрыватель или нужен чистый SWF без интерфейса.

**Что происходит, если исходный шрифт отсутствует на машине экспорта?**

Aspose.Slides заменит шрифт, указанный через [default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/default_regular_font/) в [SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/), чтобы избежать нежелательного отката.