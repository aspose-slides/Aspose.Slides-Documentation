---
title: Конвертировать PowerPoint в SWF Flash
type: docs
weight: 80
url: /ru/net/convert-powerpoint-to-swf-flash/
keywords: "Конвертировать PowerPoint, Презентация, PowerPoint в SWF, SWF flash PPT в SWF, PPTX в SWF, C#, Csharp, .NET"
description: "Конвертировать презентацию PowerPoint в SWF Flash на C# или .NET"
---

## **Конвертировать презентации в Flash**

Метод [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) в классе [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) может быть использован для преобразования всей презентации в документ SWF. Вы также можете включить комментарии в генерируемый SWF, используя класс [SWFOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions) и интерфейс [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions). Следующий пример показывает, как преобразовать презентацию в документ SWF, используя параметры, предоставляемые классом SWFOptions.
```c#
// Создать объект Presentation, представляющий файл презентации
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;


    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // Сохранение презентации и страниц заметок
    presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```


## **Вопросы и ответы**

**Могу ли я включить скрытые слайды в SWF?**

Да. Включите параметр [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/showhiddenslides/) в [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/). По умолчанию скрытые слайды не экспортируются.

**Как я могу контролировать сжатие и конечный размер SWF?**

Используйте флаг [Compressed](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/compressed/) (включён по умолчанию) и отрегулируйте [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/jpegquality/), чтобы сбалансировать размер файла и качество изображения.

**Для чего предназначен параметр 'ViewerIncluded' и когда его следует отключать?**

[ViewerIncluded](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/viewerincluded/) добавляет встроенный интерфейс плеера (элементы управления навигацией, панели, поиск). Отключайте его, если планируете использовать собственный плеер или вам нужен «чистый» SWF‑фрейм без пользовательского интерфейса.

**Что происходит, если исходный шрифт отсутствует на машине, где происходит экспорт?**

Aspose.Slides заменит шрифт, указанный через [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) в [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/), чтобы избежать непреднамеренного возврата к другому шрифту.