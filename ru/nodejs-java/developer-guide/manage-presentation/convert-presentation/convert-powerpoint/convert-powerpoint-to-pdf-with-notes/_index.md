---
title: Конвертировать презентации PowerPoint в PDF с заметками на JavaScript
linktitle: PowerPoint в PDF с заметками
type: docs
weight: 50
url: /ru/nodejs-java/convert-powerpoint-to-pdf-with-notes/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Конвертировать форматы PPT и PPTX в PDF с заметками на JavaScript с помощью Aspose.Slides для Node.js. Сохранять макеты и примечания докладчика для профессиональных презентаций."
---
## **Обзор**

В этой статье вы узнаете, как преобразовать презентации PowerPoint в формат PDF с примечаниями к докладчику, используя Aspose.Slides. Это руководство охватывает необходимые шаги и предоставляет примеры кода, чтобы помочь вам выполнить эту задачу эффективно. К концу этой статьи вы сможете:

- Реализовать процесс конвертации, преобразующий слайды PowerPoint в PDF‑документы с сохранением примечаний к докладчику.
- Настроить выходной PDF таким образом, чтобы примечания к докладчику были включены и отформатированы в соответствии с вашими требованиями.

Чтобы задать размеры и ориентацию страницы заметок перед экспортом, см. [Размер страницы заметок](/slides/ru/nodejs-java/notes-size/).

## **Преобразовать PowerPoint в PDF с заметками**

`save` метод в классе [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) можно использовать для преобразования презентации PPT или PPTX в PDF с примечаниями к докладчику. С помощью Aspose.Slides вы просто загружаете презентацию, настраиваете параметры макета, используя класс [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/notescommentslayoutingoptions/) чтобы включить примечания к докладчику, а затем сохраняете файл как PDF. Следующий фрагмент кода демонстрирует, как преобразовать пример презентации в PDF в режиме слайдов заметок.

```js
const asposeSlides = require("aspose.slides.via.java");

let presentation = new asposeSlides.Presentation("sample.pptx");

// Настроить параметры PDF для рендеринга примечаний докладчика.
let notesOptions = new asposeSlides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(asposeSlides.NotesPositions.BottomFull); // Отобразить примечания докладчика под слайдом.

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Сохранить презентацию в PDF с примечаниями докладчика.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Note" %}}
Возможно, вам будет интересно ознакомиться с Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/ru/conversion).
{{% /alert %}}