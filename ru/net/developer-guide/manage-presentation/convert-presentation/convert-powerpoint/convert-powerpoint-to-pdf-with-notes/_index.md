---
title: Преобразовать презентации PowerPoint в PDF с примечаниями в .NET
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
description: "Конвертировать форматы PPT и PPTX в PDF с примечаниями с помощью Aspose.Slides для .NET. Сохранять макеты и примечания докладчика для профессиональных презентаций."
---

## **Обзор**

В этой статье вы узнаете, как преобразовать презентации PowerPoint в формат PDF с примечаниями докладчика с помощью Aspose.Slides. Это руководство охватывает необходимые шаги и предоставляет примеры кода, чтобы помочь вам эффективно выполнить эту задачу. По завершении статьи вы сможете:

- Реализовать процесс конвертации, преобразующий слайды PowerPoint в PDF‑документы с сохранением примечаний докладчика.
- Настроить вывод PDF так, чтобы примечания докладчика были включены и отформатированы в соответствии с вашими требованиями.

## **Преобразование PowerPoint в PDF с примечаниями**

Метод `Save` класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) можно использовать для преобразования презентации PPT или PPTX в PDF с примечаниями докладчика. С помощью Aspose.Slides вы просто загружаете презентацию, настраиваете параметры макета, используя класс [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) для включения примечаний докладчика, а затем сохраняете файл в формате PDF. Ниже приведён фрагмент кода, демонстрирующий, как преобразовать образец презентации в PDF в режиме слайда с примечаниями.
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Настроить параметры PDF для рендеринга примечаний докладчика.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Отобразить примечания докладчика под слайдом.
        }
    };

    // Сохранить презентацию в PDF с примечаниями докладчика.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```


{{% alert color="primary" %}} 

Возможно, вам будет интересно попробовать онлайн‑конвертер Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/conversion). 

{{% /alert %}}