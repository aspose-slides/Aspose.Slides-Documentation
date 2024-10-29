---
title: تحويل PowerPoint إلى PDF مع الملاحظات
type: docs
weight: 50
url: /ar/php-java/convert-powerpoint-to-pdf-with-notes/
keywords: "تحويل PowerPoint إلى PDF مع الملاحظات في جافا"
description: "تحويل PowerPoint إلى PDF مع الملاحظات "
---

## **تحويل PowerPoint إلى PDF بحجم شريحة مخصص**
يوضح المثال التالي كيفية تحويل عرض تقديمي إلى مستند PDF يحتوي على ملاحظات بحجم شريحة مخصص. حيث تعادل كل بوصة 72.

```php
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
  $presIn = new Presentation("SelectedSlides.pptx");
  $presOut = new Presentation();
  try {
    $slide = $presIn->getSlides()->get_Item(0);
    $presOut->getSlides()->insertClone(0, $slide);
    # تعيين نوع وحجم الشريحة
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

## **تحويل PowerPoint إلى PDF في عرض شريحة الملاحظات**
يمكن استخدام طريقة [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) المكشوفة بواسطة فئة [**Presentation**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) لتحويل العرض التقديمي الكامل في عرض شريحة الملاحظات إلى PDF. تحديث الشفرات أدناه العرض التقديمي النموذجي إلى PDF في عرض شريحة الملاحظات.

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

يمكنك الاطلاع على محول Aspose [PowerPoint إلى PDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf) أو [PPT إلى PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf). 

{{% /alert %}}