---
title: Конвертация PowerPoint в PDF с заметками
type: docs
weight: 50
url: /ru/androidjava/convert-powerpoint-to-pdf-with-notes/
keywords: "конвертация powerpoint в pdf с заметками на java"
description: "Конвертация PowerPoint в PDF с заметками на Java"
---

## **Конвертация PowerPoint в PDF с пользовательским размером слайда**
Следующий пример показывает, как конвертировать презентацию в PDF-документ с заметками и пользовательским размером слайда. Где каждый дюйм равен 72.

```java
// Создание объекта Presentation, представляющего файл презентации
Presentation presIn = new Presentation("SelectedSlides.pptx");
Presentation presOut = new Presentation();
try {
    ISlide slide = presIn.getSlides().get_Item(0);
    presOut.getSlides().insertClone(0, slide);
    
    // Установка типа и размера слайда
    presOut.getSlideSize().setSize(612F, 792F,SlideSizeScaleType.EnsureFit);
        
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);

    presOut.save("PDF-SelectedSlide.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presIn != null) presIn.dispose();
    if (presOut != null) presOut.dispose();
}
```

## **Конвертация PowerPoint в PDF в режиме просмотра заметок**
Метод [**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) класса [**Presentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) может быть использован для конвертации всей презентации в режиме просмотра заметок в PDF. Приведенные ниже фрагменты кода обновляют образец презентации в PDF в режиме просмотра заметок.

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

Вам может быть интересно ознакомиться с конвертером Aspose [PowerPoint в PDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf) или [PPT в PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf). 

{{% /alert %}} 