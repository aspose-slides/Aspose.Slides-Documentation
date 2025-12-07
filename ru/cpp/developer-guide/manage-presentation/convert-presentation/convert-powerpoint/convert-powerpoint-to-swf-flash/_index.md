---
title: Переобразование презентаций PowerPoint в SWF Flash на C++
linktitle: PowerPoint в SWF
type: docs
weight: 80
url: /ru/cpp/convert-powerpoint-to-swf-flash/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в SWF
- презентацию в SWF
- слайд в SWF
- PPT в SWF
- PPTX в SWF
- PowerPoint в Flash
- презентацию в Flash
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
description: "Преобразуйте PowerPoint (PPT/PPTX) в SWF Flash на C++ с помощью Aspose.Slides. Пошаговые примеры кода, быстрый вывод высокого качества, без автоматизации PowerPoint."
---

## **Конвертация презентаций в Flash**

Метод [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) может использоваться для преобразования всей презентации в документ SWF. Вы также можете включать комментарии в генерируемый SWF, используя класс [SWFOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.swf_options) и интерфейс [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options). Ниже приведён пример, показывающий, как конвертировать презентацию в документ SWF с использованием параметров, предоставляемых классом SWFOptions.
``` cpp
// Путь к каталогу документов.
    System::String dataDir = GetDataPath();

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


## **FAQ**

**Можно ли включать скрытые слайды в SWF?**

Yes. Use the [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/) method in [SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/). By default, hidden slides are not exported.

**Как контролировать сжатие и окончательный размер SWF?**

Use the [set_Compressed](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_compressed/) method and adjust [JPEG quality](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_jpegquality/) to balance file size and image fidelity.

**Для чего предназначен 'set_ViewerIncluded' и когда его следует использовать?**

[set_ViewerIncluded](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_viewerincluded/) adds an embedded player UI (navigation controls, panels, search). Disable it if you plan to use your own player or need a bare SWF frame without UI.

**Что происходит, если исходный шрифт отсутствует на машине экспорта?**

Aspose.Slides will substitute the font you specify via [set_DefaultRegularFont](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) in [SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/) to avoid an unintended fallback.