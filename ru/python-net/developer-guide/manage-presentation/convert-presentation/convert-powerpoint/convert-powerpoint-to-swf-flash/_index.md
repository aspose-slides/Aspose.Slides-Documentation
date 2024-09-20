---
title: Конвертация PowerPoint в SWF Flash
type: docs
weight: 80
url: /python-net/convert-powerpoint-to-swf-flash/
keywords: "Конвертация PowerPoint, Презентация, PowerPoint в SWF, SWF flash PPT в SWF, PPTX в SWF, Python"
description: "Конвертируйте презентацию PowerPoint в SWF Flash на Python"
---

Метод [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) может использоваться для конвертации всей презентации в документ SWF. Вы также можете включать комментарии в сгенерированный SWF, используя класс [SWFOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) и интерфейс [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/). В следующем примере показано, как конвертировать презентацию в документ SWF, используя параметры, предоставленные классом SWFOptions.

```py
import aspose.slides as slides

# Создание объекта Presentation, представляющего файл презентации
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Сохранение презентации и страниц с заметками
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```