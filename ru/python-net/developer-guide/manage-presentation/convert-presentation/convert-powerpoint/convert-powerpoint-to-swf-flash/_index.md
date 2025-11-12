---
title: Конвертировать презентации PowerPoint в SWF Flash в Python
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
description: "Конвертировать PowerPoint (PPT/PPTX) в SWF Flash в Python с Aspose.Slides. Пошаговые примеры кода, быстрый качественный вывод, без автоматизации PowerPoint."
---

## **Преобразование презентаций в Flash**

Метод [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) может быть использован для преобразования всей презентации в документ SWF. Вы также можете включить комментарии в сгенерированный SWF, используя класс [SWFOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) и интерфейс [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/). Ниже приведён пример, показывающий, как конвертировать презентацию в документ SWF с помощью параметров, предоставляемых классом SWFOptions.

```py
import aspose.slides as slides

# Создать объект Presentation, представляющий файл презентации
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

**Можно ли включить скрытые слайды в SWF?**

Да. Включите параметр [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/show_hidden_slides/) в [SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/). По умолчанию скрытые слайды не экспортируются.

**Как контролировать степень сжатия и итоговый размер SWF?**

Используйте флаг [compressed](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/compressed/) (включён по умолчанию) и настройте [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/jpeg_quality/) для баланса между размером файла и качеством изображения.

**Для чего нужен параметр 'viewer_included' и когда его следует отключать?**

[viewer_included](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/viewer_included/) добавляет встроенный интерфейс проигрывателя (элементы управления навигацией, панели, поиск). Отключите его, если планируете использовать собственный проигрыватель или нужен «чистый» SWF‑фрейм без UI.

**Что происходит, если на машине экспорта отсутствует исходный шрифт?**

Aspose.Slides заменит шрифт, указанный через [default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/default_regular_font/) в [SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/), чтобы избежать нежелательного отката.