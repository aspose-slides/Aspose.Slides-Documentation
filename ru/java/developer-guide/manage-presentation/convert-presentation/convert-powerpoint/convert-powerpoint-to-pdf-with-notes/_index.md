---
title: Преобразование презентаций PowerPoint в PDF с примечаниями на Java
linktitle: PowerPoint в PDF с примечаниями
type: docs
weight: 50
url: /ru/java/convert-powerpoint-to-pdf-with-notes/
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
- PDF с примечаниями
- Java
- Aspose.Slides
description: "Преобразуйте форматы PPT и PPTX в PDF с примечаниями, используя Aspose.Slides для Java. Сохраните макеты и примечания докладчика для профессиональных презентаций."
---
## **Обзор**

В этой статье вы узнаете, как преобразовать презентации PowerPoint в формат PDF с примечаниями докладчика, используя Aspose.Slides. Это руководство охватывает необходимые шаги и предоставляет примеры кода, чтобы вы могли эффективно выполнить эту задачу. К концу статьи вы сможете:

- Реализовать процесс конверсии, преобразуя слайды PowerPoint в документы PDF с сохранением примечаний докладчика.
- Настроить выходной PDF так, чтобы примечания докладчика были включены и отформатированы согласно вашим требованиям.

## **Преобразование PowerPoint в PDF с примечаниями**

Метод `save` в классе [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) можно использовать для конвертации презентации PPT или PPTX в PDF с примечаниями докладчика. С Aspose.Slides вы просто загружаете презентацию, настраиваете параметры макета с помощью класса [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/notescommentslayoutingoptions/) для включения примечаний докладчика и затем сохраняете файл в формате PDF. Ниже приведён фрагмент кода, демонстрирующий, как преобразовать образец презентации в PDF в представлении «Слайды с примечаниями».

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// Настройте параметры PDF для рендеринга примечаний докладчика.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Отобразить примечания докладчика под слайдом.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Сохранить презентацию в PDF с примечаниями докладчика.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" %}} 
Возможно, вам будет интересно попробовать онлайн-конвертер Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/ru/conversion). 
{{% /alert %}}