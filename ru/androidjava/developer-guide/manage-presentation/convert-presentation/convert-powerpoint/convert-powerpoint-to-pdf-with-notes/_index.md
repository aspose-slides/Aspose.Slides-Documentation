---
title: Преобразование презентаций PowerPoint в PDF с заметками на Android
linktitle: PowerPoint в PDF с заметками
type: docs
weight: 50
url: /ru/androidjava/convert-powerpoint-to-pdf-with-notes/
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
- заметки докладчика
- PDF с заметками
- Android
- Java
- Aspose.Slides
description: "Преобразуйте форматы PPT и PPTX в PDF с заметками, используя Aspose.Slides для Android через Java. Сохраняйте макеты и заметки докладчика для профессиональных презентаций."
---
## **Обзор**

В этой статье вы узнаете, как с помощью Aspose.Slides преобразовать презентации PowerPoint в формат PDF с заметками докладчика. Это руководство охватывает необходимые шаги и предоставляет пример кода, который поможет эффективно выполнить задачу. По окончании статьи вы сможете:

- Реализовать процесс конвертации, преобразуя слайды PowerPoint в PDF‑документы с сохранением заметок докладчика.
- Настроить выходной PDF так, чтобы заметки докладчика были включены и отформатированы в соответствии с вашими требованиями.

Чтобы задать размеры и ориентацию страницы заметок перед экспортом, см. [Notes Page Size](/slides/ru/androidjava/notes-size/).

## **Конвертировать PowerPoint в PDF с заметками**

Метод `save` в классе [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) может использоваться для преобразования презентации PPT или PPTX в PDF с заметками докладчика. С помощью Aspose.Slides вы просто загружаете презентацию, настраиваете параметры макета с помощью класса [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/notescommentslayoutingoptions/) для включения заметок докладчика и затем сохраняете файл как PDF. Следующий фрагмент кода демонстрирует, как преобразовать пример презентации в PDF в виде слайда заметок.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
	// Настройте параметры PDF для отображения заметок докладчика.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // Отобразить заметки докладчика под слайдом.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// Сохраните презентацию в PDF с заметками докладчика.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="info" title="Примечание" %}}
Возможно, вам будет интересно ознакомиться с Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/ru/conversion).
{{% /alert %}}