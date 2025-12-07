---
title: Конвертировать презентации PowerPoint в SWF Flash на C++
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
description: "Конвертировать PowerPoint (PPT/PPTX) в SWF Flash на C++ с помощью Aspose.Slides. Пошаговые образцы кода, быстрый качественный вывод, без автоматизации PowerPoint."
---

## **Преобразование презентаций в Flash**

Метод [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) может использоваться для преобразования всей презентации в документ SWF. Вы также можете включить комментарии в генерируемый SWF, используя класс [SWFOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.swf_options) и интерфейс [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options). Следующий пример показывает, как преобразовать презентацию в документ SWF с помощью параметров, предоставляемых классом SWFOptions.
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


## **Часто задаваемые вопросы**

**Можно ли включать скрытые слайды в SWF?**

Да. Используйте метод [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/) в классе [SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/). По умолчанию скрытые слайды не экспортируются.

**Как контролировать сжатие и конечный размер SWF?**

Используйте метод [set_Compressed](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_compressed/) и настройте [JPEG quality](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_jpegquality/), чтобы достичь баланса между размером файла и качеством изображения.

**Для чего предназначен 'set_ViewerIncluded' и когда его следует использовать?**

[set_ViewerIncluded](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_viewerincluded/) добавляет встроенный пользовательский интерфейс проигрывателя (элементы навигации, панели, поиск). Отключите его, если планируете использовать собственный проигрыватель или нужен чистый кадр SWF без UI.

**Что происходит, если исходный шрифт отсутствует на машине экспорта?**

Aspose.Slides заменит шрифт, указанный с помощью [set_DefaultRegularFont](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) в [SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/), чтобы избежать непреднамеренного возврата к другому шрифту.