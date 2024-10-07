---
title: تحويل PowerPoint إلى SWF فلاش
type: docs
weight: 80
url: /php-java/convert-powerpoint-to-swf-flash/
keywords: "PPT، PPTX إلى SWF"
description: "تحويل PowerPoint PPT، PPTX إلى SWF"
---

## **تحويل PPT(X) إلى SWF**
يمكن استخدام طريقة [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) التي توفرها فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) لتحويل العرض التقديمي بالكامل إلى وثيقة **SWF**. يظهر المثال التالي كيفية تحويل عرض تقديمي إلى وثيقة **SWF** باستخدام الخيارات التي توفرها فئة [**SWFOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/SwfOptions). يمكنك أيضًا تضمين التعليقات في SWF الناتج باستخدام فئة [**ISWFOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/ISwfOptions) وواجهة [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/INotesCommentsLayoutingOptions).

```php
  $pres = new Presentation("Sample.pptx");
  try {
    $swfOptions = new SwfOptions();
    $swfOptions->setViewerIncluded(false);
    $swfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # حفظ العرض التقديمي
    $pres->save("Sample.swf", SaveFormat::Swf, $swfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
```php

```