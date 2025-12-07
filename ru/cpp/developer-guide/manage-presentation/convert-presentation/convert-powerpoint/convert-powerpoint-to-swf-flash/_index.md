---
title: Конвертировать презентации PowerPoint в SWF Flash на C++
linktitle: PowerPoint в SWF
type: docs
weight: 80
url: /ru/cpp/convert-powerpoint-to-swf-flash/
keywords:
- Конвертировать PowerPoint
- Конвертировать презентацию
- Конвертировать слайд
- Конвертировать PPT
- Конвертировать PPTX
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
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Конвертировать PowerPoint (PPT/PPTX) в SWF Flash на C++ с помощью Aspose.Slides. Пошаговые примеры кода, быстрый качественный вывод, без автоматизации PowerPoint."
---

## **Конвертировать презентации в Flash**

Метод [Сохранить](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e), предоставляемый классом [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation), может быть использован для конвертации всей презентации в документ SWF. Вы также можете включать комментарии в генерируемый SWF, используя класс [SWFOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.swf_options) и интерфейс [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options). Следующий пример показывает, как конвертировать презентацию в документ SWF, используя параметры, предоставляемые классом SWFOptions.
``` cpp
// Путь к директории документов.
    // Создать объект Presentation, представляющий файл презентации
    auto presentation = System::MakeObject<Presentation>(dataDir + u"HelloWorld.pptx");

    auto swfOptions = System::MakeObject<SwfOptions>();
    swfOptions->set_ViewerIncluded(false);

    auto notesOptions = swfOptions->get_NotesCommentsLayouting();
    notesOptions->set_NotesPosition(NotesPositions::BottomFull);

    // Сохранение презентации и страниц заметок
    presentation->Save(dataDir + u"SaveAsSwf_out.swf", SaveFormat::Swf, swfOptions);
    swfOptions->set_ViewerIncluded(true);
    presentation->Save(dataDir + u"SaveNotes_out.swf", SaveFormat::Swf, swfOptions);
```


## **Часто задаваемые вопросы**

**Могу ли я включить скрытые слайды в SWF?**

Да. Используйте метод [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/) в классе [SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/). По умолчанию скрытые слайды не экспортируются.

**Как я могу контролировать сжатие и конечный размер SWF?**

Используйте метод [set_Compressed](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_compressed/) и настройте [JPEG quality](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_jpegquality/) для балансировки размера файла и качества изображения.

**Для чего нужен set_ViewerIncluded и когда его следует использовать?**

Метод [set_ViewerIncluded](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_viewerincluded/) добавляет встроенный пользовательский интерфейс проигрывателя (элементы навигации, панели, поиск). Отключите его, если планируете использовать собственный проигрыватель или нужен чистый SWF‑фрейм без UI.

**Что происходит, если исходный шрифт отсутствует на машине экспорта?**

Aspose.Slides заменит шрифт, указанный через [set_DefaultRegularFont](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) в классе [SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/), чтобы избежать нежелательного fallback.