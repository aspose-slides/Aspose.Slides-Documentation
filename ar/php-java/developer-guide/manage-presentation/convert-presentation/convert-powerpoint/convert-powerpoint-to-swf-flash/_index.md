---
title: تحويل عروض PowerPoint إلى فلاش SWF في PHP
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
- PowerPoint إلى Flash
- العرض التقديمي إلى Flash
- الشريحة إلى Flash
- PPT إلى Flash
- PPTX إلى Flash
- حفظ PPT كـ SWF
- حفظ PPTX كـ SWF
- تصدير PPT إلى SWF
- تصدير PPTX إلى SWF
- PowerPoint
- العرض التقديمي
- PHP
- Aspose.Slides
description: "تحويل PowerPoint (PPT/PPTX) إلى فلاش SWF في PHP باستخدام Aspose.Slides. أمثلة شفرة خطوة بخطوة، إخراج سريع عالي الجودة، بدون أتمتة PowerPoint."
---

## **تحويل العروض التقديمية إلى فلاش**

يمكن استخدام طريقة [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) التي توفرها فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) لتحويل العرض التقديمي بالكامل إلى مستند **SWF**. يوضح المثال التالي كيفية تحويل عرض تقديمي إلى مستند **SWF** باستخدام الخيارات المتاحة في فئة [SWFOptions](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/). يمكنك أيضًا تضمين التعليقات في ملف SWF المُنشأ باستخدام فئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/).
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


## **الأسئلة المتكررة**

**هل يمكنني تضمين الشرائح المخفية في ملف SWF؟**

نعم. قم بتمكين الشرائح المخفية باستخدام طريقة [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setshowhiddenslides/) في فئة [SwfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/). بشكل افتراضي، لا يتم تصدير الشرائح المخفية.

**كيف يمكنني التحكم في الضغط وحجم ملف SWF النهائي؟**

استخدم طريقة [setCompressed](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setcompressed/) وطريقة [ضبط جودة JPEG](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setjpegquality/) لتحقيق التوازن بين حجم الملف وجودة الصورة.

**ما هو الغرض من 'setViewerIncluded' ومتى يجب إيقافه؟**

[setViewerIncluded](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setviewerincluded/) يضيف واجهة مستخدم مشغل مدمجة (عناصر تحكم التنقل، اللوحات، البحث). قم بإيقافه إذا كنت تخطط لاستخدام مشغل خاص بك أو تحتاج إلى إطار SWF بسيط بدون واجهة مستخدم.

**ماذا يحدث إذا كان الخط الأصلي مفقودًا على جهاز التصدير؟**

ستقوم Aspose.Slides باستبدال الخط الذي تحدده عبر [setDefaultRegularFont](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) في فئة [SwfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/) لتجنب الرجوع غير المقصود.