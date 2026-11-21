---
title: Конвертировать презентации PowerPoint в PDF с заметками в .NET
linktitle: PowerPoint в PDF с заметками
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
- заметки выступающего
- PDF с заметками
- .NET
- C#
- Aspose.Slides
description: Конвертировать форматы PPT и PPTX в PDF с заметками с помощью Aspose.Slides для .NET. Сохраняйте макеты и заметки выступающего для профессиональных презентаций.
---
## **Обзор**

В этой статье вы узнаете, как преобразовать презентации PowerPoint в формат PDF с нотами выступающего с помощью Aspose.Slides. В этом руководстве рассматриваются необходимые шаги и приводятся примеры кода, которые помогут эффективно выполнить эту задачу. По окончании статьи вы сможете:

- Реализовать процесс конвертации, преобразующий слайды PowerPoint в PDF‑документы, сохраняя при этом заметки выступающего.
- Настроить выходной PDF так, чтобы заметки выступающего были включены и отформатированы согласно вашим требованиям.

Чтобы задать размеры и ориентацию страницы заметок перед экспортом, см. [Размер страницы заметок](/slides/ru/net/notes-size/).

## **Преобразование PowerPoint в PDF с заметками**

Метод `Save` класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) можно использовать для преобразования презентации PPT или PPTX в PDF с заметками выступающего. С Aspose.Slides вы просто загружаете презентацию, настраиваете параметры макета с помощью класса [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/notescommentslayoutingoptions/) для включения заметок выступающего, а затем сохраняете файл в формате PDF. Ниже приведён фрагмент кода, демонстрирующий, как преобразовать пример презентации в PDF в представлении слайдов заметок.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Настройте параметры PDF для отображения заметок выступающего.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Отображать заметки выступающего под слайдом.
        }
    };

    // Сохраните презентацию в PDF с заметками выступающего.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="info" %}} 
Возможно, вы захотите ознакомиться с онлайн‑конвертером Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/ru/conversion). 
{{% /alert %}}