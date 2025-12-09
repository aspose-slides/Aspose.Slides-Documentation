---
title: Конвертировать презентации PowerPoint в PDF с примечаниями на Java
linktitle: PowerPoint в PDF с примечаниями
type: docs
weight: 50
url: /ru/java/convert-powerpoint-to-pdf-with-notes/
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
- примечания выступающего
- PDF с примечаниями
- Java
- Aspose.Slides
description: "Конвертировать форматы PPT и PPTX в PDF с примечаниями с помощью Aspose.Slides для Java. Сохранять макеты и примечания выступающего для профессиональных презентаций."
---

## **Обзор**

В этой статье вы узнаете, как конвертировать презентации PowerPoint в формат PDF с примечаниями выступающего, используя Aspose.Slides. Это руководство охватит необходимые шаги и предоставит примеры кода, чтобы вы смогли эффективно выполнить эту задачу. К концу статьи вы сможете:

- Реализовать процесс конвертации, преобразующий слайды PowerPoint в документы PDF, сохраняя при этом примечания выступающего.
- Настроить выходной PDF так, чтобы примечания выступающего были включены и отформатированы согласно вашим требованиям.

## **Конвертировать PowerPoint в PDF с примечаниями**

Метод `save` в классе [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) можно использовать для конвертации презентации PPT или PPTX в PDF с примечаниями выступающего. С помощью Aspose.Slides вы просто загружаете презентацию, настраиваете параметры компоновки, используя класс [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/), чтобы включить примечания выступающего, а затем сохраняете файл как PDF. Ниже приведён фрагмент кода, демонстрирующий, как конвертировать пример презентации в PDF в виде слайдов с примечаниями.
```java
Presentation presentation = new Presentation("sample.pptx");

// Настройте параметры PDF для отображения примечаний выступающего.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Отображать примечания выступающего под слайдом.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Сохраните презентацию в PDF с примечаниями выступающего.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```


{{% alert color="primary" %}} 
Возможно, вы захотите ознакомиться с Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/conversion). 
{{% /alert %}}