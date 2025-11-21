---
title: Преобразовать презентации PowerPoint в SWF Flash на .NET
linktitle: PowerPoint в SWF
type: docs
weight: 80
url: /ru/net/convert-powerpoint-to-swf-flash/
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
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Преобразовать PowerPoint (PPT/PPTX) в SWF Flash на .NET с помощью Aspose.Slides. Пошаговые примеры кода C#, быстрое качественное вывoд, без автоматизации PowerPoint."
---

## **Преобразовать презентации в Flash**

Метод [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) предоставляемый классом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) можно использовать для преобразования всей презентации в документ SWF. Вы также можете включить комментарии в генерируемый SWF, используя класс [SWFOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions) и интерфейс [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions). Следующий пример показывает, как преобразовать презентацию в документ SWF, используя параметры, предоставленные классом SWFOptions.
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


## **FAQ**

**Можно ли включить скрытые слайды в SWF?**

Да. Включите параметр [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/showhiddenslides/) в [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/). По умолчанию скрытые слайды не экспортируются.

**Как я могу контролировать сжатие и конечный размер SWF?**

Используйте флаг [Compressed](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/compressed/) (включён по умолчанию) и настройте [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/jpegquality/) для баланса между размером файла и качеством изображений.

**Для чего нужен 'ViewerIncluded' и когда следует его отключать?**

[ViewerIncluded](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/viewerincluded/) добавляет встроенный пользовательский интерфейс плеера (элементы навигации, панели, поиск). Отключайте его, если планируете использовать собственный плеер или нужен чистый SWF‑фрейм без UI.

**Что происходит, если исходный шрифт отсутствует на машине экспорта?**

Aspose.Slides заменит шрифт, указанный через [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) в [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/), чтобы избежать нежелательного перехода к другому шрифту.