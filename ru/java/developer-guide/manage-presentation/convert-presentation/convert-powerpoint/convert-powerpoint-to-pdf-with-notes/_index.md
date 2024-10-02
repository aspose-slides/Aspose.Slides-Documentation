---
title: Преобразование PowerPoint в PDF с заметками
type: docs
weight: 50
url: /ru/java/convert-powerpoint-to-pdf-with-notes/
keywords: "преобразование powerpoint в pdf с заметками на java"
description: "Преобразование PowerPoint в PDF с заметками на Java"
---

## **Преобразование PowerPoint в PDF с пользовательским размером слайдов**
Следующий пример показывает, как преобразовать презентацию в документ PDF с заметками с пользовательским размером слайдов. Где каждый дюйм равен 72.

```java
// Создание объекта Presentation, представляющего файл презентации
Presentation presIn = new Presentation("SelectedSlides.pptx");
Presentation presOut = new Presentation();
try {
    ISlide slide = presIn.getSlides().get_Item(0);
    presOut.getSlides().insertClone(0, slide);
    
    // Установка типа и размера слайда
    presOut.getSlideSize().setSize(612F, 792F, SlideSizeScaleType.EnsureFit);
        
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);

    presOut.save("PDF-SelectedSlide.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presIn != null) presIn.dispose();
    if (presOut != null) presOut.dispose();
}
```

## **Преобразование PowerPoint в PDF в режиме просмотра слайдов с заметками**
Метод [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) класса [**Presentation**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) может быть использован для преобразования всей презентации в режиме просмотра слайдов с заметками в PDF. Примеры кода ниже обновляют выбранную презентацию в PDF в режиме просмотра слайдов с заметками.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);

    pres.save(resourcesOutputPath+"PDF-Notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

Вы можете ознакомиться с конвертером Aspose [PowerPoint в PDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf) или [PPT в PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf). 

{{% /alert %}} 