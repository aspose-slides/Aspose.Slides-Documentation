---
title: Конвертация PowerPoint в PDF с заметками на C#
linktitle: Конвертация PowerPoint в PDF с заметками
type: docs
weight: 50
url: /net/convert-powerpoint-to-pdf-with-notes/
keywords: "конвертация PowerPoint, Презентация, PowerPoint в PDF, заметки, c#, csharp, .NET, Aspose.Slides"
description: "Конвертируйте PowerPoint в PDF с заметками с помощью C# или .NET"
---

## **Обзор**

Во время [конвертации PowerPoint в PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/) вы также можете контролировать, как заметки и комментарии размещаются в экспортированном документе. Он охватывает следующие темы.

- [C# Конвертация PPT в PDF с заметками](#convert-powerpoint-to-pdf-with-notes)
- [C# Конвертация PPTX в PDF с заметками](#convert-powerpoint-to-pdf-with-notes)
- [C# Конвертация ODP в PDF с заметками](#convert-powerpoint-to-pdf-with-notes)
- [C# Конвертация PowerPoint в PDF с заметками](#convert-powerpoint-to-pdf-with-notes)

## **Конвертация PowerPoint в PDF с заметками**

Метод [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index), предоставленный классом Presentation, может быть использован для конвертации презентации PowerPoint PPT или PPTX в PDF с заметками. Сохранение презентации Microsoft PowerPoint в формате PDF с заметками с помощью Aspose.Slides для .NET - это двухстрочный процесс. Вам просто нужно открыть презентацию и сохранить ее в формате PDF с заметками. Приведенные ниже фрагменты кода C# обновляют пример презентации в формате PDF в режиме заметок о слайде:

```c#
// Создать объект Presentation, представляющий файл презентации 
Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

auxPresentation.Slides.InsertClone(0, slide);

// Установка типа и размера слайда 
//auxPresentation.SlideSize.SetSize(presentation.SlideSize.Size.Width, presentation.SlideSize.Size.Height,SlideSizeScaleType.EnsureFit);
auxPresentation.SlideSize.SetSize(612F, 792F, SlideSizeScaleType.EnsureFit);

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.NotesCommentsLayouting.NotesPosition = NotesPositions.BottomFull;

auxPresentation.Save("PDFnotes_out.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="primary" %}} 

Вам может быть интересно ознакомиться с конвертером Aspose [PowerPoint в PDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf) или [PPT в PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf). 

{{% /alert %}} 