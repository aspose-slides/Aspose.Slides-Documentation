---
title: Конвертировать PowerPoint в PDF с заметками
type: docs
weight: 50
url: /php-java/convert-powerpoint-to-pdf-with-notes/
keywords: "конвертировать powerpoint в pdf с заметками на java"
description: "Конвертировать PowerPoint в PDF с заметками"
---

## **Конвертировать PowerPoint в PDF с пользовательским размером слайда**
Следующий пример показывает, как конвертировать презентацию в PDF документ с заметками с пользовательским размером слайда. Где каждый дюйм равен 72.

```php
// Создание объекта Presentation, представляющего файл презентации
  $presIn = new Presentation("SelectedSlides.pptx");
  $presOut = new Presentation();
  try {
    $slide = $presIn->getSlides()->get_Item(0);
    $presOut->getSlides()->insertClone(0, $slide);
    # Установка типа и размера слайда
    $presOut->getSlideSize()->setSize(612.0, 792.0, SlideSizeScaleType::EnsureFit);
    $pdfOptions = new PdfOptions();
    $pdfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    $presOut->save("PDF-SelectedSlide.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($presIn)) {
      $presIn->dispose();
    }
    if (!java_is_null($presOut)) {
      $presOut->dispose();
    }
  }
```

## **Конвертировать PowerPoint в PDF в режиме заметок слайда**
Метод [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) класса [**Presentation**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) может быть использован для конвертации всей презентации в режиме заметок слайда в PDF. Приведенные ниже фрагменты кода обновляют образец презентации в PDF в режиме заметок слайда.

```php
  $pres = new Presentation("presentation.pptx");
  try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    $pres->save($resourcesOutputPath . "PDF-Notes.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

Вы можете проверить конвертер Aspose [PowerPoint в PDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf) или [PPT в PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf). 

{{% /alert %}}