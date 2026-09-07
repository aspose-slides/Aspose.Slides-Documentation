---
title: Преобразовать презентации PowerPoint в SWF Flash в Python через Java
linktitle: PowerPoint в SWF
type: docs
weight: 80
url: /ru/python-java/convert-powerpoint-to-swf-flash/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в SWF
- презентация в SWF
- слайд в SWF
- PPT в SWF
- PPTX в SWF
- PowerPoint в Flash
- презентация в Flash
- слайд в Flash
- PPT в Flash
- PPTX в Flash
- сохранить PPT как SWF
- сохранить PPTX как SWF
- экспортировать PPT в SWF
- экспортировать PPTX в SWF
- Python
- Java
- Aspose.Slides
description: "Преобразуйте презентации PowerPoint в SWF Flash в Python через Java с помощью Aspose.Slides. Настройте просмотрщик, заметки, скрытые слайды, сжатие и шрифты."
---
## **Обзор**

Aspose.Slides for Python via Java позволяет конвертировать презентации PowerPoint в SWF без Microsoft PowerPoint. Используйте [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save) для экспорта презентации и [SwfOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/swfoptions/) для настройки параметров просмотрщика, качества изображений и расположения заметок или комментариев.

## **Конвертировать презентации во Flash**

Загрузите исходный файл с помощью [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/), настройте [SwfOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/swfoptions/), и сохраните его, используя [SaveFormat.Swf](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/#Swf).

Следующий пример экспортирует `presentation.pptx` в `presentation.swf`. Он отключает встроенный просмотрщик с помощью [setViewerIncluded](https://reference.aspose.com/slides/ru/python-java/aspose.slides/swfoptions/#setViewerIncluded) и включает заметки выступающего под слайдами, используя [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notescommentslayoutingoptions/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, SwfOptions

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    swf_options = SwfOptions()
    swf_options.setViewerIncluded(False)
    swf_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation.swf", SaveFormat.Swf, swf_options)
finally:
    presentation.dispose()
```

Перед запуском примера [install Aspose.Slides for Python via Java](/slides/ru/python-java/installation/) и разместите `presentation.pptx` в рабочем каталоге. JVM запускается один раз на процесс Python.

Пример применяет [NotesPositions.BottomFull](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notespositions/#BottomFull) через [setNotesPosition](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) и передаёт макет в [SwfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/swfoptions/#setSlidesLayoutOptions). Чтобы также включить комментарии, настройте [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) перед экспортом.

## **FAQ**

**Могу ли я включить скрытые слайды в SWF?**

Да. Вызовите [SwfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/swfoptions/#setShowHiddenSlides) с `True`. По умолчанию скрытые слайды не экспортируются.

**Как я могу контролировать сжатие и окончательный размер SWF?**

Используйте [SwfOptions.setCompressed](https://reference.aspose.com/slides/ru/python-java/aspose.slides/swfoptions/#setCompressed) для включения или отключения сжатия и [SwfOptions.setJpegQuality](https://reference.aspose.com/slides/ru/python-java/aspose.slides/swfoptions/#setJpegQuality) для настройки качества JPEG‑изображений. Более низкое качество JPEG может уменьшить размер файла за счёт потери точности изображения.

**Для чего нужен встроенный просмотрщик и когда его следует отключать?**

[SwfOptions.setViewerIncluded](https://reference.aspose.com/slides/ru/python-java/aspose.slides/swfoptions/#setViewerIncluded) управляет тем, будет ли сгенерированный SWF содержать просмотрщик. Передайте `False`, когда нужны экспортированные слайды без встроенного просмотрщика, как в приведённом выше примере.

**Что происходит, если исходный шрифт отсутствует на машине экспорта?**

Вы можете указать шрифт по умолчанию с помощью [setDefaultRegularFont](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveoptions/#setDefaultRegularFont), который наследуется [SwfOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/swfoptions/). Выберите шрифт, доступный процессу экспорта; подстановка шрифтов может изменить внешний вид текста и макет.