---
title: Конвертировать презентации PowerPoint в PDF с примечаниями в .NET
linktitle: PowerPoint в PDF с примечаниями
type: docs
weight: 50
url: /ru/net/convert-powerpoint-to-pdf-with-notes/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в PDF
- презентацию в PDF
- слайд в PDF
- PPT в PDF
- PPTX в PDF
- сохранить презентацию как PDF
- сохранить PPT как PDF
- сохранить PPTX как PDF
- экспортировать PPT в PDF
- экспортировать PPTX в PDF
- примечания докладчика
- PDF с примечаниями
- .NET
- C#
- Aspose.Slides
description: "Конвертировать форматы PPT и PPTX в PDF с примечаниями с помощью Aspose.Slides для .NET. Сохранить макеты и примечания докладчика для профессиональных презентаций."
---
## **Обзор**

В этой статье вы узнаете, как конвертировать презентации PowerPoint в формат PDF с заметками докладчика, используя Aspose.Slides. Это руководство охватывает необходимые шаги и предоставляет примеры кода, которые помогут эффективно выполнить задачу. К концу статьи вы сможете:

- Реализовать процесс конвертации, превращая слайды PowerPoint в документы PDF с сохранением заметок докладчика.
- Настроить вывод PDF так, чтобы заметки докладчика были включены и отформатированы в соответствии с вашими требованиями.

## **Конвертировать PowerPoint в PDF с заметками**

Метод `Save` в классе [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) можно использовать для преобразования презентации PPT или PPTX в PDF с заметками докладчика. С Aspose.Slides вы просто загружаете презентацию, настраиваете параметры компоновки с помощью класса [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/notescommentslayoutingoptions/) для включения заметок докладчика и затем сохраняете файл в формате PDF. Следующий фрагмент кода демонстрирует, как конвертировать пример презентации в PDF в режиме слайдов с заметками.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Настроить параметры PDF для отображения заметок докладчика.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Отображать заметки докладчика под слайдом.
        }
    };

    // Сохранить презентацию в PDF с заметками докладчика.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="info" %}} 
Вы можете ознакомиться с Aspose [Онлайн-конвертером PowerPoint в PDF](https://products.aspose.app/slides/ru/conversion). 
{{% /alert %}}