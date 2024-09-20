---
title: Конвертация PowerPoint в SWF Flash
type: docs
weight: 80
url: /cpp/convert-powerpoint-to-swf-flash/
keywords: "PPT, PPTX в SWF"
description: "Конвертируйте PowerPoint PPT, PPTX в формат SWF Flash с помощью Aspose.Slides API."
---

Метод [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e), предоставляемый классом [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation), может использоваться для преобразования всей презентации в документ SWF. Вы также можете включить комментарии в созданный SWF, используя класс [SWFOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.swf_options) и интерфейс [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options). Следующий пример показывает, как конвертировать презентацию в документ SWF, используя параметры, предоставляемые классом SWFOptions.

``` cpp
// Путь к директории документов.
    System::String dataDir = GetDataPath();

    // Создание объекта Presentation, представляющего файл презентации
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