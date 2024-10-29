---
title: رأس وتذييل العرض التقديمي
type: docs
weight: 140
url: /ar/php-java/presentation-header-and-footer/
keywords: "رأس وتذييل باوربوينت"
description: "رأس وتذييل باوربوينت"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/ar/php-java/) يوفر الدعم للعمل مع نصوص رؤوس وتذييلات الشريحة التي تُحافظ عليها في مستوى شريحة الماستر.

{{% /alert %}} 

[Aspose.Slides for PHP via Java](/slides/ar/php-java/) يوفر ميزة إدارة رؤوس وتذييلات داخل شرائح العرض التقديمي. هذه تُدار في الواقع على مستوى الماستر.

## **إدارة الرأس والتذييل في العرض التقديمي**
يمكن إزالة ملاحظات بعض الشرائح المحددة كما هو موضح في المثال أدناه:

```php
  # تحميل العرض التقديمي
  $pres = new Presentation("headerTest.pptx");
  try {
    # إعداد التذييل
    $pres->getHeaderFooterManager()->setAllFootersText("نص تذييل الخاص بي");
    $pres->getHeaderFooterManager()->setAllFootersVisibility(true);
    # الوصول إلى وتحديث الرأس
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (null != $masterNotesSlide) {
      updateHeaderFooterText($masterNotesSlide);
    }
    # حفظ العرض التقديمي
    $pres->save("HeaderFooterJava.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **إدارة الرأس والتذييل في شرائح الكتيب والملاحظات**
يدعم Aspose.Slides for PHP عبر Java الرأس والتذييل في شرائح الكتيب والملاحظات. يرجى اتباع الخطوات أدناه:

- تحميل [عرض تقديمي](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) يحتوي على فيديو.
- تغيير إعدادات الرأس والتذييل لماستر الملاحظات وجميع شرائح الملاحظات.
- جعل شريحة الملاحظات الرئيسية وجميع أماكن تذييلها مرئية.
- جعل شريحة الملاحظات الرئيسية وجميع أماكن التاريخ والوقت مرئية.
- تغيير إعدادات الرأس والتذييل لشريحة الملاحظات الأولى فقط.
- جعل مكان الرأس لشريحة الملاحظات مرئيًا.
- تعيين نص لمكان الرأس لشريحة الملاحظات.
- تعيين نص لمكان التاريخ والوقت لشريحة الملاحظات.
- كتابة ملف العرض التقديمي المعدل.

مقتطف الشفرة موفر في المثال أدناه.

```php
  $pres = new Presentation("presentation.pptx");
  try {
    # تغيير إعدادات الرأس والتذييل لماستر الملاحظات وجميع شرائح الملاحظات
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($masterNotesSlide)) {
      $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();
      $headerFooterManager->setHeaderAndChildHeadersVisibility(true);// جعل شريحة الملاحظات الرئيسية وجميع أماكن تذييلها مرئية

      $headerFooterManager->setFooterAndChildFootersVisibility(true);// جعل شريحة الملاحظات الرئيسية وجميع أماكن رأسها مرئية

      $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// جعل شريحة الملاحظات الرئيسية وجميع أماكن رقم الشريحة مرئية

      $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// جعل شريحة الملاحظات الرئيسية وجميع أماكن التاريخ والوقت مرئية

      $headerFooterManager->setHeaderAndChildHeadersText("نص الرأس");// تعيين نص لشريحة الملاحظات الرئيسية وجميع أماكن الرأس

      $headerFooterManager->setFooterAndChildFootersText("نص التذييل");// تعيين نص لشريحة الملاحظات الرئيسية وجميع أماكن التذييل

      $headerFooterManager->setDateTimeAndChildDateTimesText("نص التاريخ والوقت");// تعيين نص لشريحة الملاحظات الرئيسية وجميع أماكن التاريخ والوقت

    }
    # تغيير إعدادات الرأس والتذييل لشريحة الملاحظات الأولى فقط
    $notesSlide = $pres->getSlides()->get_Item(0)->getNotesSlideManager()->getNotesSlide();
    if (!java_is_null($notesSlide)) {
      $headerFooterManager = $notesSlide->getHeaderFooterManager();
      if (!$headerFooterManager->isHeaderVisible()) {
        $headerFooterManager->setHeaderVisibility(true);
      }// جعل هذا المكان خاص بالرأس مرئيًا

      if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
      }// جعل هذا المكان خاص بالتذييل مرئيًا

      if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
      }// جعل هذا المكان خاص برقم الشريحة مرئيًا

      if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
      }// جعل هذا المكان خاص بالتاريخ والوقت مرئيًا

      $headerFooterManager->setHeaderText("نص رأس جديد");// تعيين نص لمكان رأس شريحة الملاحظات

      $headerFooterManager->setFooterText("نص تذييل جديد");// تعيين نص لمكان تذييل شريحة الملاحظات

      $headerFooterManager->setDateTimeText("نص جديد للتاريخ والوقت");// تعيين نص لمكان التاريخ والوقت في شريحة الملاحظات

    }
    $pres->save("testresult.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```