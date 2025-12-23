---
title: تحويل العروض التقديمية PowerPoint إلى فلاش SWF في PHP
linktitle: PowerPoint إلى SWF
type: docs
weight: 80
url: /ar/php-java/convert-powerpoint-to-swf-flash/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى SWF
- العرض التقديمي إلى SWF
- الشريحة إلى SWF
- PPT إلى SWF
- PPTX إلى SWF
- PowerPoint إلى فلاش
- العرض التقديمي إلى فلاش
- الشريحة إلى فلاش
- PPT إلى فلاش
- PPTX إلى فلاش
- حفظ PPT كـ SWF
- حفظ PPTX كـ SWF
- تصدير PPT إلى SWF
- تصدير PPTX إلى SWF
- PowerPoint
- العرض التقديمي
- PHP
- Aspose.Slides
description: "تحويل PowerPoint (PPT/PPTX) إلى فلاش SWF في PHP باستخدام Aspose.Slides. عينات شفرة خطوة بخطوة، إخراج سريع وعالي الجودة، دون أتمتة PowerPoint."
---

## **تحويل العروض التقديمية إلى فلاش**
يمكن استخدام طريقة [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) التي توفرها فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) لتحويل العرض التقديمي بالكامل إلى مستند **SWF**. يوضح المثال التالي كيفية تحويل عرض تقديمي إلى مستند **SWF** باستخدام الخيارات المتوفرة في فئة [**SWFOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/SwfOptions). يمكنك أيضًا تضمين التعليقات في ملف SWF المُولد باستخدام فئة [**ISWFOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/ISwfOptions) والواجهة [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/INotesCommentsLayoutingOptions).
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
  }
```


## **الأسئلة المتداولة**

**هل يمكنني تضمين الشرائح المخفية في ملف SWF؟**

نعم. فعّل الشرائح المخفية باستخدام طريقة [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setshowhiddenslides/) في فئة [SwfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/). بشكل افتراضي، لا يتم تصدير الشرائح المخفية.

**كيف يمكنني التحكم في الضغط وحجم ملف SWF النهائي؟**

استخدم طريقة [setCompressed](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setcompressed/) و[adjust JPEG quality](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setjpegquality/) لتحقيق التوازن بين حجم الملف وجودة الصورة.

**ما هو الغرض من 'setViewerIncluded' ومتى يجب تعطيله؟**

[setViewerIncluded](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setviewerincluded/) يضيف واجهة مستخدم مشغٍّ مدمج (عناصر تحكم التنقل، الألواح، البحث). عطلها إذا كنت تخطط لاستخدام مشغٍّ خاص بك أو تحتاج إلى إطار SWF بسيط بدون واجهة مستخدم.

**ماذا يحدث إذا كان الخط الأصلي مفقودًا على جهاز التصدير؟**

ستقوم Aspose.Slides باستبدال الخط الذي تحدده عبر [setDefaultRegularFont](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) في فئة [SwfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/) لتجنب الانتقال إلى خط افتراضي غير مقصود.