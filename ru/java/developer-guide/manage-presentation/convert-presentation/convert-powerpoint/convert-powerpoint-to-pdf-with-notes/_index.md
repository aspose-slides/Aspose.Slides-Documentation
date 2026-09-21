---
title: Конвертировать презентации PowerPoint в PDF с заметками на Java
linktitle: PowerPoint в PDF с заметками
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
- презентацию в PDF
- слайд в PDF
- PPT в PDF
- PPTX в PDF
- сохранить презентацию как PDF
- сохранить PPT как PDF
- сохранить PPTX как PDF
- экспортировать PPT в PDF
- экспортировать PPTX в PDF
- заметки докладчика
- PDF с заметками
- Java
- Aspose.Slides
description: "Конвертировать форматы PPT и PPTX в PDF с заметками, используя Aspose.Slides для Java. Сохранить макеты и заметки докладчика для профессиональных презентаций."
---
## **Обзор**

В этой статье вы узнаете, как конвертировать презентации PowerPoint в формат PDF с заметками докладчика с помощью Aspose.Slides. Это руководство охватит необходимые шаги и предоставит примеры кода, чтобы вы могли эффективно выполнить эту задачу. К концу статьи вы сможете:

- Реализовать процесс конвертации, преобразуя слайды PowerPoint в PDF‑документы с сохранением заметок докладчика.
- Настроить вывод PDF так, чтобы заметки докладчика были включены и отформатированы в соответствии с вашими требованиями.

Чтобы задать размеры и ориентацию страницы заметок перед экспортом, см. [Размер страницы заметок](/slides/ru/java/notes-size/).

## **Конвертировать PowerPoint в PDF с заметками**

Метод `save` в классе [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) можно использовать для конвертации презентации PPT или PPTX в PDF с заметками докладчика. С помощью Aspose.Slides вы просто загружаете презентацию, настраиваете параметры макета, используя класс [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/notescommentslayoutingoptions/) для включения заметок докладчика, а затем сохраняете файл как PDF. Приведённый ниже фрагмент кода демонстрирует, как преобразовать пример презентации в PDF в представлении слайдов с заметками.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// Настроить параметры PDF для рендеринга заметок докладчика.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Отобразить заметки докладчика под слайдом.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Сохранить презентацию в PDF с заметками докладчика.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Note" %}}

Возможно, вам будет интересен онлайн‑конвертер Aspose [PowerPoint в PDF онлайн](https://products.aspose.app/slides/ru/conversion).

{{% /alert %}}