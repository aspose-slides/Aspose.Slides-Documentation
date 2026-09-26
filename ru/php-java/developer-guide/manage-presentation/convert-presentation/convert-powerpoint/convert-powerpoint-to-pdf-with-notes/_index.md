---
title: Преобразование презентаций PowerPoint в PDF с заметками на PHP
linktitle: PowerPoint в PDF с заметками
type: docs
weight: 50
url: /ru/php-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- преобразовать PowerPoint
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
- PDF с заметками
- PHP
- Aspose.Slides
description: "Преобразуйте форматы PPT и PPTX в PDF с заметками, используя Aspose.Slides для PHP через Java. Сохраняйте макеты и примечания докладчика для профессиональных презентаций."
---
## **Обзор**

В этой статье вы узнаете, как преобразовать презентации PowerPoint в формат PDF с примечаниями докладчика с помощью Aspose.Slides. Это руководство охватывает необходимые шаги и предоставляет примеры кода, которые помогут эффективно выполнить эту задачу. К концу статьи вы сможете:

- Реализовать процесс конвертации, преобразующий слайды PowerPoint в PDF‑документы с сохранением примечаний докладчика.
- Настроить вывод PDF так, чтобы примечания докладчика были включены и отформатированы в соответствии с вашими требованиями.

Чтобы задать размеры и ориентацию страницы заметок перед экспортом, смотрите [Размер страницы заметок](/slides/ru/php-java/notes-size/).

## **Преобразование PowerPoint в PDF с заметками**

`save` метод в классе [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) можно использовать для преобразования презентации PPT или PPTX в PDF с примечаниями докладчика. С Aspose.Slides вы просто загружаете презентацию, настраиваете параметры макета, используя класс [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/notescommentslayoutingoptions/) чтобы включить примечания докладчика, и затем сохраняете файл в формате PDF. Ниже приведён фрагмент кода, демонстрирующий, как преобразовать пример презентации в PDF в режиме слайдов заметок.

```php
$presentation = new Presentation("sample.pptx");

// Настройте параметры PDF для отображения заметок докладчика.
$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // Отобразить заметки докладчика под слайдом.

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// Сохраните презентацию в PDF с заметками докладчика.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="info" title="Note" %}}

Возможно, вам будет интересно посмотреть онлайн‑конвертер Aspose [Онлайн‑конвертер PowerPoint в PDF](https://products.aspose.app/slides/ru/conversion).

{{% /alert %}}