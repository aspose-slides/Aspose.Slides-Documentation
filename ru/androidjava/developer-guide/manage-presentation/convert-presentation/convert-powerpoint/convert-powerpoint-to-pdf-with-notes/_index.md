---
title: Преобразование презентаций PowerPoint в PDF с примечаниями на Android
linktitle: PowerPoint в PDF с примечаниями
type: docs
weight: 50
url: /ru/androidjava/convert-powerpoint-to-pdf-with-notes/
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
- Android
- Java
- Aspose.Slides
description: "Преобразуйте форматы PPT и PPTX в PDF с примечаниями с помощью Aspose.Slides для Android на Java. Сохраняйте макеты и примечания докладчика для профессиональных презентаций."
---
## **Обзор**

В этой статье вы узнаете, как преобразовать презентации PowerPoint в формат PDF с примечаниями докладчика с помощью Aspose.Slides. В руководстве описаны необходимые шаги и представлены примеры кода, которые помогут эффективно выполнить эту задачу. К концу статьи вы сможете:

- Реализовать процесс конвертации, превращая слайды PowerPoint в PDF‑документы при сохранении примечаний докладчика.
- Настроить выходной PDF так, чтобы примечания докладчика были включены и отформатированы в соответствии с вашими требованиями.

## **Конвертация PowerPoint в PDF с примечаниями**

Метод `save` в классе [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) можно использовать для преобразования презентации PPT или PPTX в PDF с примечаниями докладчика. С помощью Aspose.Slides вы просто загружаете презентацию, настраиваете параметры макета с помощью класса [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/notescommentslayoutingoptions/) для включения примечаний докладчика и затем сохраняете файл как PDF. Ниже приведён фрагмент кода, демонстрирующий, как преобразовать пример презентации в PDF в представлении «Слайды с примечаниями».

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
	// Настройте параметры PDF для отображения примечаний докладчика.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // Отобразить примечания докладчика под слайдом.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// Сохраните презентацию в PDF с примечаниями докладчика.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="info" %}} 

Возможно, вам тоже будет интересно проверить Aspose [Онлайн‑конвертер PowerPoint в PDF](https://products.aspose.app/slides/ru/conversion). 

{{% /alert %}}