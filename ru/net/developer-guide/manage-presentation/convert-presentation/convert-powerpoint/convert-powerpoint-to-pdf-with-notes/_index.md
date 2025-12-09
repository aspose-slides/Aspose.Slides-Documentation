---
title: Преобразование презентаций PowerPoint в PDF с примечаниями в .NET
linktitle: PowerPoint в PDF с примечаниями
type: docs
weight: 50
url: /ru/net/convert-powerpoint-to-pdf-with-notes/
keywords:
- конвертировать PowerPoint
- преобразовать презентацию
- преобразовать слайд
- преобразовать PPT
- преобразовать PPTX
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
description: "Преобразуйте форматы PPT и PPTX в PDF с примечаниями с помощью Aspose.Slides для .NET. Сохраните макеты и примечания докладчика для профессиональных презентаций."
---

## **Обзор**

В этой статье вы узнаете, как конвертировать презентации PowerPoint в формат PDF с примечаниями докладчика, используя Aspose.Slides. Это руководство охватит необходимые шаги и предоставит примеры кода, чтобы помочь вам эффективно выполнить эту задачу. К концу статьи вы сможете:

- Реализовать процесс конвертации, преобразовать слайды PowerPoint в PDF‑документы, сохраняя примечания докладчика.  
- Настроить выходной PDF, чтобы примечания докладчика были включены и отформатированы в соответствии с вашими требованиями.

## **Конвертировать PowerPoint в PDF с примечаниями**

Метод `Save` в классе [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) можно использовать для преобразования презентации PPT или PPTX в PDF с примечаниями докладчика. С Aspose.Slides вы просто загружаете презентацию, настраиваете параметры макета, используя класс [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) для включения примечаний докладчика, а затем сохраняете файл в формате PDF. Следующий фрагмент кода демонстрирует, как конвертировать пример презентации в PDF в режиме слайдов с примечаниями.
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Настройте параметры PDF для отображения примечаний докладчика.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Отобразить примечания докладчика под слайдом.
        }
    };

    // Сохраните презентацию в PDF с примечаниями докладчика.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```


{{% alert color="primary" %}} 
Возможно, вам будет интересно ознакомиться с онлайн‑конвертером Aspose [Онлайн‑конвертер PowerPoint в PDF](https://products.aspose.app/slides/conversion). 
{{% /alert %}}