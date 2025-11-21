---
title: Конвертация презентаций PowerPoint в SWF Flash на .NET
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
- сохранить PPT как SWF
- сохранить PPTX как SWF
- экспортировать PPT в SWF
- экспортировать PPTX в SWF
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Конвертировать PowerPoint (PPT/PPTX) в SWF Flash на .NET с помощью Aspose.Slides. Пошаговые примеры кода C#, быстрое качественное преобразование, без автоматизации PowerPoint."
---

## **Преобразование презентаций в Flash**

Метод [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) может быть использован для преобразования всей презентации в документ SWF. Вы также можете включить комментарии в генерируемый SWF, используя класс [SWFOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions) и интерфейс [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions). Ниже приведён пример, показывающий, как преобразовать презентацию в документ SWF с помощью параметров, предоставляемых классом SWFOptions.
```c#
// Создайте объект Presentation, представляющий файл презентации
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


## **Часто задаваемые вопросы**

**Можно ли включить скрытые слайды в SWF?**

Да. Включите параметр [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/showhiddenslides/) в [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/). По умолчанию скрытые слайды не экспортируются.

**Как контролировать степень сжатия и конечный размер SWF?**

Используйте флаг [Compressed](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/compressed/) (включён по умолчанию) и настройте [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/jpegquality/) для балансировки размера файла и качества изображения.

**Для чего нужен параметр 'ViewerIncluded' и когда его следует отключать?**

[ViewerIncluded](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/viewerincluded/) добавляет встроенный пользовательский интерфейс плеера (элементы навигации, панели, поиск). Отключите его, если планируете использовать собственный плеер или вам нужен чистый SWF‑фрейм без UI.

**Что произойдёт, если исходный шрифт отсутствует на машине экспорта?**

Aspose.Slides заменит шрифт, указанный в параметре [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) в [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/), чтобы избежать нежелательной подстановки.