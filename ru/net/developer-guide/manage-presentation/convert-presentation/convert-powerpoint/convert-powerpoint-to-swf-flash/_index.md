---
title: Преобразование презентаций PowerPoint в SWF Flash в .NET
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
description: "Конвертировать PowerPoint (PPT/PPTX) в SWF Flash на .NET с помощью Aspose.Slides. Пошаговые примеры кода C#, быстрый качественный вывод, без автоматизации PowerPoint."
---

## **Преобразование презентаций в Flash**

Метод [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index), предоставляемый классом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), можно использовать для преобразования всей презентации в документ SWF. Вы также можете включить комментарии в создаваемый SWF, используя класс [SWFOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions) и интерфейс [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions). Следующий пример показывает, как преобразовать презентацию в документ SWF, используя параметры, предоставленные классом SWFOptions.
```c#
// Создать объект Presentation, который представляет файл презентации
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

**Можно ли включать скрытые слайды в SWF?**

Да. Включите параметр [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/showhiddenslides/) в [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/). По умолчанию скрытые слайды не экспортируются.

**Как я могу контролировать сжатие и окончательный размер SWF?**

Используйте флаг [Compressed](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/compressed/) (включён по умолчанию) и настройте [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/jpegquality/) для балансировки размера файла и качества изображений.

**Для чего нужен 'ViewerIncluded' и когда его следует отключать?**

[ViewerIncluded](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/viewerincluded/) добавляет встроенный пользовательский интерфейс проигрывателя (элементы навигации, панели, поиск). Отключите его, если планируете использовать собственный проигрыватель или вам нужен чистый фрейм SWF без UI.

**Что происходит, если исходный шрифт отсутствует на машине экспорта?**

Aspose.Slides заменит шрифт, указанный через [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) в [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/), чтобы избежать непреднамеренного переключения.