---
title: Конвертировать PowerPoint в SWF Flash
type: docs
weight: 80
url: /net/convert-powerpoint-to-swf-flash/
keywords: "Конвертировать PowerPoint, Презентация, PowerPoint в SWF, SWF Flash PPT в SWF, PPTX в SWF, C#, Csharp, .NET"
description: "Конвертировать презентацию PowerPoint в SWF Flash на C# или .NET"
---

Метод [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index), предоставленный классом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), может быть использован для конвертации всей презентации в документ SWF. Вы также можете включить комментарии в сгенерированный SWF, используя класс [SWFOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions) и интерфейс [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions). Следующий пример показывает, как конвертировать презентацию в документ SWF, используя параметры, предоставленные классом SWFOptions.

```c#
// Создание объекта Presentation, представляющего файл презентации
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;

    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // Сохранение презентации и страниц с заметками
    presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```