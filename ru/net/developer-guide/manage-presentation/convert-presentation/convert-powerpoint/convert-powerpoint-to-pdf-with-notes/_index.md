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
- презентация в PDF
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
description: "Конвертировать форматы PPT и PPTX в PDF с примечаниями, используя Aspose.Slides для .NET. Сохранять макеты и примечания докладчика для профессиональных презентаций."
---

## **Обзор**

В этой статье вы узнаете, как конвертировать презентации PowerPoint в PDF‑формат с заметками докладчика, используя Aspose.Slides. Это руководство охватывает необходимые шаги и предоставляет примеры кода, помогающие эффективно выполнить задачу. К концу статьи вы сможете:

- Реализовать процесс конвертации, преобразующий слайды PowerPoint в PDF‑документы с сохранением заметок докладчика.
- Настроить вывод PDF так, чтобы заметки докладчика были включены и отформатированы согласно вашим требованиям.

## **Конвертировать PowerPoint в PDF с заметками**

Метод `Save` класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) можно использовать для преобразования презентации PPT или PPTX в PDF с заметками докладчика. С помощью Aspose.Slides вы просто загружаете презентацию, настраиваете параметры макета с помощью класса [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) для включения заметок, а затем сохраняете файл в PDF. Следующий фрагмент кода демонстрирует, как конвертировать пример презентации в PDF в режиме «Слайды с заметками».
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Настройте параметры PDF для рендеринга заметок докладчика.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Рендерить заметки докладчика под слайдом.
        }
    };

    // Сохранить презентацию в PDF с заметками докладчика.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```


{{% alert color="primary" %}} 

Возможно, вам будет интересно посмотреть онлайн‑конвертер Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/conversion). 

{{% /alert %}}